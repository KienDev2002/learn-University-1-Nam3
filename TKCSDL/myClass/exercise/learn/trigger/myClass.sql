--1. Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, tạo trigger cập nhật tự động 
--cho trường này biết ThanhTien=SLBan*DonGiaBan (thêm nhiều)

go
create trigger ThanhTien on tChiTietHDB
for insert, update as
begin
	update tChiTietHDB set thanhtien = inserted.SLBan * DonGiaBan from inserted
		join tSach on inserted.MaSach = tSach.MaSach
		join tChiTietHDB on inserted.SoHDB = tChiTietHDB.SoHDB
	and inserted.MaSach = tChiTietHDB.MaSach

end

select * from tChiTietHDB


insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB02','S09',10)
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB02','S10',10)
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB02','S11',10)

--1. Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, tạo trigger cập nhật tự động 
--cho trường này biết ThanhTien=SLBan*DonGiaBan (thêm 1)
go
create trigger ThanhTien on tChiTietHDB
for insert , update as
begin
	declare @sohdb nvarchar(10), @donggia money ,  @masach nvarchar(10)
	select @sohdb = soHDB , @masach = masach from inserted
	select @donggia = tSach.DonGiaBan 
	from tSach where tSach.MaSach = @masach
	update tChiTietHDB set thanhtien = SLBan * @donggia 
	where SoHDB = @sohdb and MaSach = @masach
end


alter table tChiTietHDB
add thanhtien money


--2. Thêm trường đơn giá (DonGia) cho bảng chi tiết hóa đơn bán, cập nhật dữ liệu cho trường 
--này mỗi khi thêm, sửa bản ghi vào bảng chi tiết hóa đơn bán.
alter table tChiTietHDB
add DonGia money

go
create trigger DonGia on tChiTietHDB 
for insert , update as
begin
	declare @soHDB nvarchar(10) ,  @masach nvarchar(10), @DonGia money
	select @soHDB = soHDB , @masach = masach from inserted
	select @DonGia = tSach.DonGiaBan  from tSach where tSach.MaSach = @masach
	update tChiTietHDB 
	set DonGia = @DonGia
	where SoHDB = @sohdb and MaSach = @masach
end


--3. Thêm trường tổng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
alter table tKhachHang
add TongHD int
go
create trigger TongSOHDB on tHoaDonBan 
for insert , update, delete as
begin

	--insert
	update tKhachHang
	set TongHD = ISNULL(TongHD,0) + 1
	where  tKhachHang.MaKH in(select MaKh from inserted)

	--delete 
	update tKhachHang
	set TongHD = ISNULL(TongHD,0) - 1
	where  tKhachHang.MaKH in(select MaKh from inserted)
end






--4. Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi 
--thêm, xóa, sửa chi tiết hóa đơn (insert 1 bản ghi)
alter table tHoaDonBan
add SoSP int
go
alter trigger TongSOHDBCau4
on tChiTietHDB 
for insert , update, delete as
begin
	declare @sohdb nvarchar(10), @sl int , @sohdb1 nvarchar(10) , @sl1 int
	select @sohdb = soHDB, @sl = ISNULL(slBan,0) from inserted
	select @sohdb1 = soHDB, @sl1 = ISNULL(slBan,0) from deleted


	update tHoaDonBan 
	set SoSP = ISNULL(SoSP,0) + ISNULL(@sl,0) -  ISNULL(@sl1,0)
	where SoHDB = ISNULL(@sohdb, @sohdb1)
end

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB04','S15',10),('HDB04','S13',5),('HDB04','S14',1)

select * from tChiTietHDB where SoHDB = 'HDB04'
select * from tHoaDonBan

delete from tChiTietHDB where SoHDB = 'HDB04'
update tHoaDonBan set SoSP = null where SoHDB = 'HDB04'

--4. Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi 
--thêm, xóa, sửa chi tiết hóa đơn ((insert nhiều bản ghi)

go
create trigger TongSOHDBcau4_2 on tChiTietHDB 
for insert , update, delete as
begin
	update tHoaDonBan set SoSP = ISNULL(SoSP,0) + SLBan from 
	update tHoaDonBan set SoSP = ISNULL(SoSP,0) + SLBan from deleted where  tHoaDonBan.SoHDB in (select SoHDB from deleted)
end


--5. Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, 
--xóa, sửa chi tiết hóa đơn
go
create trigger TongTienHDB on tChiTietHDB
for insert, update, delete as
begin	
	declare @sohdb nvarchar(10), @sl int , @sohdb1 nvarchar(10) , @sl1 int, @maSach nvarchar(10), donGiaBan
	select @sohdb = soHDB, @sl = ISNULL(slBan,0),@maSach =   MaSach from inserted
	select @sohdb1 = soHDB, @sl1 = ISNULL(slBan,0),@maSach =   MaSach from deleted

	
	update tHoaDonBan
	set TongTien = SUM(@sl * s.DonGiaBan)
	from tSach s
	where s.MaSach = @MaSach and tHoaDonBan.SoHDB = @sohdb

end

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB04','S15',10)

create table proc_logs(log_id int identity primary key , event_data XML not null,changed_by sysname not null)

go
create trigger trg_proc_changges 
on database
for
	create_procedure, alter_procedure , drop_procedure
as
begin
	set nocount on;
	insert into proc_logs(
		event_data,
		changed_by
	)

	values(
		EVENTDATA(),
		USER
	);
end
go

create procedure LayTTSach @masach nvarchar(10)
as 
begin
	select * from tSach where MaSach = @masach
end

select * from proc_logs

drop procedure LayTTSach


CREATE TRIGGER trgSprocs
ON DATABASE
FOR CREATE_PROCEDURE, ALTER_PROCEDURE, DROP_PROCEDURE
AS
IF DATEPART(hh,GETDATE()) > 7 AND DATEPART(hh,GETDATE()) < 18
BEGIN
	DECLARE @Message nvarchar(max)
	SELECT @Message =
	'Completing work during core hours. Trying to release - '
	+ EVENTDATA().value
	('(/EVENT_INSTANCE/TSQLCommand/CommandText)[1]','nvarchar(max)')
	RAISERROR (@Message, 16, 1)
	ROLLBACK
	EXEC msdb.dbo.sp_send_dbmail
	@profile_name = 'ApressFinancialDBMA',
	@recipients = 'robin@fat-belly.com',
	@body = 'A stored procedure change',
	@subject = 'A stored procedure change has been initiated and rolled back
	during core hours'
END


--trigger: mỗi khi xóa hdb thì xóa toàn bộ cthdb
go
alter trigger delete_ALL on tHoaDonBan
instead of delete as
begin
	declare @soHDB nvarchar(5)
	select @soHDB = SoHDB from deleted
	delete from tChiTietHDB where soHDB = @soHDB
	delete from tHoaDonBan where soHDB = @soHDB
end

delete from tHoaDonBan where soHDB = N'HDB02'



--9. Thêm trường Tổng tiền cho HDB, cập nhật tự động cho trường này mỗi khi thêm chi tiết HD
alter table tHoaDonBan
add TongTien money

go
create trigger cau9Trigger on tChiTietHDB for delete as
begin
	declare @soHDB nvarchar(10), @MaSach nvarchar(10), @SL int, @DonGiaBan money
	
	select  @soHDB = SoHDB ,@MaSach= MaSach,  @SL = SLBan
	from inserted
	select @DonGiaBan  = tSach.DonGiaBan from tSach where tSach.MaSach = @MaSach
	update tHoaDonBan
	set TongTien = SUM(@SL *@DonGiaBan )
	where tHoaDonBan.SoHDB = @soHDB
end

select * from tHoaDonBan
select * from tChiTietHDB


insert into tChiTietHDB (SoHDB,MaSach,SLBan)
values('HDB01','S01',8)
