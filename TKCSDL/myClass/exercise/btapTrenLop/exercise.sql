--cau1: Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, tạo trigger cập nhật tự động cho trường này biết
--ThanhTien=SLBan*DonGiaBan
alter table  tChitietHDB
add ThanhTien money

go
create or alter trigger triggerCau1 on tChitietHDB for insert, update
as begin
	declare @tt money
	select @tt = i.SLBan * s.DonGiaBan
	from inserted i join tSach s on s.MaSach = i.MaSach

	update tChitietHDB
	set ThanhTien = ISNULL(ThanhTien,0) + ISNULL(@tt,0)
	where SoHDB in (select SoHDB from inserted) and MaSach IN (SELECT MaSach FROM Inserted)
end

delete from tChiTietHDB
where SoHDB = 'HDB15' -- 864000

select * from tChiTietHDB
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB15','S03',4)

update tChiTietHDB
set SLBan = 6
where SoHDB = 'HDB14' --648000



--2. Thêm trường đơn giá (DonGia) cho bảng chi tiết hóa đơn bán, cập nhật dữ liệu cho trường 
--này mỗi khi thêm, sửa bản ghi vào bảng chi tiết hóa đơn bán.
alter table tChiTietHDB
add DonGiaTT MONEY

alter table tChiTietHDB
drop column DonGia 

go
create or alter trigger DonGiaTrigger
on tChiTietHDB for insert, update as
begin
	declare @DonGia money
	select @DonGia = s.DonGiaBan
	from inserted i join tSach s on s.MaSach = i.MaSach

	UPDATE dbo.tChiTietHDB
	SET DonGiaTT = ISNULL(DonGiaTT,0) + ISNULL(@DonGia,0)
	WHERE SoHDB IN (SELECT SoHDB FROM Inserted) and MaSach IN (SELECT MaSach FROM Inserted)
end

SELECT * FROM dbo.tSach

select * from tChiTietHDB
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB06','S03',8)


--3. Thêm trường tổng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
go
CREATE OR ALTER TRIGGER cau3trigger 
ON tHoaDonBan FOR INSERT , UPDATE, DELETE
AS
BEGIN
	
	declare @MaKH1 nvarchar(10), @MaKH2 nvarchar(10), @in int, @de int
	select @MaKH1=MaKH, @in =1 from inserted
	select @MaKH2=MaKH, @de =1 from deleted
	update tKhachHang set SoLuong=isnull(soluong,0)+isnull(@in,0)-isnull(@de,0) 
	where MaKH=isnull(@MaKH1, @MaKH2)
END

SELECT * FROM dbo.tKhachHang
SELECT * FROM dbo.tHoaDonBan

delete from tHoaDonBan
where SoHDB = 'HDB24'

insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB24','NV01','2014-08-11 00:00:00.000','KH01')


--4. Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi 
--thêm, xóa, sửa chi tiết hóa đơn (insert 1 bản ghi)
ALTER TABLE dbo.tHoaDonBan
ADD SoSP INT

go
CREATE or alter TRIGGER cau4Trigger ON tChiTietHDB FOR INSERT, UPDATE , DELETE
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
insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB25','NV01','2014-08-11 00:00:00.000','KH02')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB25','S01',8)
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB25','S03',10)

update tChiTietHDB
set SLBan = 3
where SoHDB = N'HDB17'


----5. Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, 
--xóa, sửa chi tiết hóa đơn
go
create or alter trigger cau5trigger on tChiTietHDB for insert, update, delete
as
begin
	DECLARE @tt money, @sohdb nvarchar(10)
	select @sohdb = SoHDB , @tt = inserted.SLBan * s.DonGiaBan
	from inserted join tSach s on inserted.MaSach = s.MaSach

	DECLARE @tt1 money, @sohdb1 nvarchar(10)
	select @sohdb1 = SoHDB, @tt1 = deleted.SLBan * s.DonGiaBan
	from deleted join tSach s on deleted.MaSach = s.MaSach

	update tHoaDonBan
	set TongTien = ISNULL(TongTien,0) + ISNULL(@tt,0) - ISNULL(@tt1,0)
	where SoHDB = ISNULL(@sohdb,@sohdb1)
end

select * from tSach
select * from tHoaDonBan
select * from tChiTietHDB
insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB18','NV01','2014-08-11 00:00:00.000','KH02')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB18','S01',3)

update tChiTietHDB
set SLBan = 5
where SoHDB = N'HDB18'




--11.Tạo trigger trên bảng thoadonban thực hiện xóa các chi tiết hóa đơn mỗi khi xóa hóa đơn
go
create trigger cau6Trigger on tHoaDonBan instead of delete 
as 
begin
	delete from tChiTietHDB
	where SoHDB in (
		select deleted.SoHDB
		from deleted
	)

	delete from tHoaDonBan
	where SoHDB in (
		select deleted.SoHDB
		from deleted
	)
end

delete from tHoaDonBan
where SoHDB = N'HDB16'
select * from tHoaDonBan
select * from tChiTietHDB


--7. Thêm trường Tổng tiền tiêu dùng cho bảng khách hàng, cập nhật thông tin cho trường này.   Xem lại
alter table tKhachHang
add TongTienTD money

go
create or alter trigger cau7Trigger on tChiTietHDB for insert,update , delete
as
begin
	declare @tt money, @maKH nvarchar(10), @maKH1 nvarchar(10)
	select @tt = SUM(inserted.SLBan * s.DonGiaBan)
	from inserted join tSach s on s.MaSach = inserted.MaSach

	declare @tt1 money 
	select @tt1 = SUM(deleted.SLBan * s.DonGiaBan)
	from deleted join tSach s on s.MaSach = deleted.MaSach

	select @maKH = maKH from inserted join tHoaDonBan hdb on hdb.SoHDB = inserted.SoHDB
	select @maKH1 = maKH from deleted join tHoaDonBan hdb on hdb.SoHDB = deleted.SoHDB

	update tKhachHang
	set TongTienTD = ISNULL(TongTienTD,0) + ISNULL(@tt,0) - ISNULL(@tt1,0)
	where MaKH = isnull(@maKH,@maKH1)
end


select * from tHoaDonBan
select * from tChiTietHDB
select * from tKhachHang

insert into tKhachHang(MaKH,TenKH,DiaChi,DienThoai,GioiTinh)
values('KH12',N'Ngô Trung Kiên',N'Hà Nội','0487748574',1)
delete from tKhachHang
where MaKH = 'KH12'


delete from tChiTietHDB
where SoHDB = N'HDB19'

delete from tHoaDonBan
where SoHDB = N'HDB19'


insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB18','NV01','2014-08-11 00:00:00.000','KH12')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB18','S01',3)

insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB19','NV01','2014-08-11 00:00:00.000','KH12')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB19','S01',3)



--8. Thêm trường Số đầu sách cho bảng nhà cung cấp, cập nhật tự động số đầu sách nhà cung cấp cung cấp cho cửa hàng 
alter table tNhaCungCap
add SoDS int

go
create or alter trigger cau8Trigger on tChiTietHDN for insert , update, delete as begin
	
	declare @sds int
	select @sds = COUNT( distinct inserted.MaSach) 
	from inserted


		

	update tNhaCungCap 
	set SoDS = isNUll(SoDS,0) + isNUll(@sds,0) 
	where tNhaCungCap.MaNCC in (select MaNCC from inserted join tHoaDonNhap hdn on hdn.SoHDN = inserted.SoHDN )


end

select * from tNhaCungCap
select * from tHoaDonNhap
select * from tChiTietHDN


insert into tNhaCungCap(MaNCC, TenNCC) values('NCC07',N'NXB Giáo dục')


delete from tChiTietHDN
where SoHDN= 'HDN07'

delete from tHoaDonNhap
where SoHDN= 'HDN06'

insert into tHoaDonNhap values('HDN07','NV05','2014-03-05 00:00:00.000','NCC07')
insert into tChiTietHDN (SoHDN,MaSach,SLNhap) values('HDN06','S03','23')
insert into tChiTietHDN (SoHDN,MaSach,SLNhap) values('HDN06','S09','23')







--9. Thêm trường Số lượng sách và Tổng tiền hàng vào bảng nhà cung cấp, cập nhật dữ liệu 
--cho trường này mỗi khi nhập hàng
alter table tNhaCungCap
add SLSach int, TongTien money

go
create or alter trigger cau9Trigger on tChiTietHDN for insert, update , delete
as
begin
	declare @inncc nvarchar(10), @dencc nvarchar(10), @inSL int, @deSL int, @inTien money, @deTien money
	
	select @inncc = hdn.MaNCC , @inSL = SLNhap, @inTien = SLNhap * s.DonGiaNhap
	from inserted join tSach s on s.MaSach = inserted.MaSach 
		join tHoaDonNhap hdn on hdn.SoHDN = inserted.SoHDN

	select @dencc = hdn.MaNCC , @deSL = SLNhap, @deTien = SLNhap * s.DonGiaNhap
	from deleted join tSach s on s.MaSach = deleted.MaSach 
		join tHoaDonNhap hdn on hdn.SoHDN = deleted.SoHDN

	update tNhaCungCap 
	set SLSach = isNUll(SLSach,0) + isNUll(@inSL,0),  TongTien = ISNULL(TongTien,0) + ISNULL(@inTien,0)
	where tNhaCungCap.MaNCC = @inncc

	update tNhaCungCap 
	set SLSach = isNUll(SLSach,0) - isNUll(@deSL,0),  TongTien = ISNULL(TongTien,0) - ISNULL(@deTien,0)
	where tNhaCungCap.MaNCC = @dencc

end


select * from tNhaCungCap
select * from tHoaDonNhap
select * from tChiTietHDN
select * from tSach

insert into tNhaCungCap(MaNCC, TenNCC) values('NCC10',N'NXB Giáo dục')


delete from tChiTietHDN
where SoHDN= 'HDN10'

delete from tHoaDonNhap
where SoHDN= 'HDN10'

insert into tHoaDonNhap values('HDN10','NV05','2014-03-05 00:00:00.000','NCC10')
insert into tChiTietHDN (SoHDN,MaSach,SLNhap) values('HDN10','S03',2)

insert into tHoaDonNhap values('HDN11','NV05','2014-03-05 00:00:00.000','NCC10')
insert into tChiTietHDN (SoHDN,MaSach,SLNhap) values('HDN11','S03',5)


insert into tChiTietHDN (SoHDN,MaSach,SLNhap) values('HDN08','S01',10)
