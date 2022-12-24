
--3. Thêm trường tổng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
alter table tKhachHang
add TongHD int

go
create trigger TongHoaDon on tHoaDonBan
for insert
as
begin
	update tKhachHang 
	set TongHD = isnull(TongHD,0) + 1
	where kh.MaKH in (select hdb.MaKH from inserted)
end


--9. Thêm trường trường Tổng tiền cho HDB, cập nhật tự động cho trường này mỗi khi thêm chi tiết HD
alter table tHoaDonBan
--drop column TongTien
add TongTien money

go
create or alter trigger cau9Trigger on tChiTietHDB for insert as
begin
	declare @tt money
	select @tt = sum(SlBan * s.DonGiaBan) 
	from inserted join tSach s on s.MaSach = inserted.MaSach

	update tHoaDonBan
	set TongTien = isnull(TongTien,0) + @tt
	where SoHDB in (select SoHDB from inserted)
end

select * from tHoaDonBan
select * from tChiTietHDB
select * from tSach


insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB15','NV01','2014-08-11 00:00:00.000','KH02')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB15','S01',8)

delete from tChiTietHDB
where SoHDB = 'HDB15'

--3. Thêm trường tổng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
go
CREATE OR ALTER TRIGGER cau3trigger 
ON tHoaDonBan FOR INSERT , UPDATE, DELETE
AS
BEGIN
	UPDATE dbo.tKhachHang 
	SET TongHD = ISNULL(TongHD,0) + 1
	WHERE MaKH IN (
	SELECT Inserted.MaKH
	FROM Inserted)

	UPDATE dbo.tKhachHang 
	SET TongHD = ISNULL(TongHD,0) - 1
	WHERE MaKH IN (
	SELECT Deleted.MaKH
	FROM Deleted)
END

SELECT * FROM dbo.tKhachHang
SELECT * FROM dbo.tHoaDonBan
delete from tHoaDonBan
where SoHDB = 'HDB16'
insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB16','NV01','2014-08-11 00:00:00.000','KH01')


--4. Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi 
--thêm, xóa, sửa chi tiết hóa đơn (insert 1 bản ghi)
ALTER TABLE dbo.tHoaDonBan
ADD SoSP INT

go
CREATE TRIGGER cau4Trigger ON tChiTietHDB FOR INSERT, UPDATE , DELETE
AS
BEGIN
	DECLARE @soHDB NVARCHAR(10),@soHDB1 NVARCHAR(10)  , @SL INT, @SL1 INT
	SELECT @soHDB = Inserted.SoHDB , @SL = ISNULL(Inserted.SLBan,0)
	FROM Inserted
	SELECT @soHDB1 = Deleted.SoHDB , @SL1 = ISNULL(Deleted.SLBan,0)
	FROM Deleted

	UPDATE tHoaDonBan
	SET SoSP = ISNULL(SoSP,0) + ISNULL(@SL,0) - ISNULL(@sl1,0)
	WHERE SoHDB =  ISNULL(@soHDB,@soHDB1)
end

SELECT * FROM dbo.tHoaDonBan
SELECT * FROM dbo.tChiTietHDB
insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB17','NV01','2014-08-11 00:00:00.000','KH02')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB17','S01',8)

update tChiTietHDB
set SLBan = 3
where SoHDB = N'HDB17'


----5. Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, 
--xóa, sửa chi tiết hóa đơn
go
create trigger cau5trigger on tChiTietHDB for insert, update, delete
as
begin
	DECLARE @tt money
	select @tt = SUM(inserted.SLBan * s.DonGiaBan)
	from inserted join tSach s on inserted.MaSach = s.MaSach
	where SoHDB in (select SoHDB from inserted)

	DECLARE @tt1 money
	select @tt1 = SUM(deleted.SLBan * s.DonGiaBan)
	from deleted join tSach s on deleted.MaSach = s.MaSach
	where SoHDB in (select SoHDB from deleted)

	update tHoaDonBan
	set TongTien = ISNULL(TongTien,0) + ISNULL(@tt,0) - ISNULL(@tt1,0)
	where SoHDB in (select SoHDB from inserted)
end

select * from tSach
select * from tHoaDonBan
select * from tChiTietHDB
insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB18','NV01','2014-08-11 00:00:00.000','KH02')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB18','S01',3)

update tChiTietHDB
set SLBan = 5
where SoHDB = N'HDB18'


--trigger: mỗi khi xóa hdb thì xóa toàn bộ cthdb
go
create trigger cau6Trigger on tHoaDonBan for delete as begin
	delete from tChiTietHDB
	where SoHDB in (
		select deleted.SoHDB
		from deleted
	)
end

delete from tHoaDonBan
where SoHDB = N'HDB18'
select * from tHoaDonBan
select * from tChiTietHDB

-- 