--test
update HoaDonBan
set TongTien = BangA.tt
from (select HoaDonBan.SoHDB, sum(SLBan * DonGiaBan) as tt
from hoadonban join ChiTietHDB on hoadonban.sohdb = ChiTietHDB.sohdb
join sanpham on sanpham.masp = ChiTietHDB.masp
group by hoadonban.sohdb) BangA where hoadonban.sohdb = BangA.sohdb

select * from HoaDonBan
select * from ChiTietHDB

--view1 liệt kê các sản phẩm đã bán được trong tháng
go
create or alter view view1 as
	select SanPham.MaSP, TenSP, DonGiaBan, DonGiaNhap, SoLuong ,HangSanXuat, ChiTietHDB.SoHDB, NgayBan
	from SanPham join ChiTietHDB on SanPham.MaSP =  ChiTietHDB.MaSP join HoaDonBan on ChiTietHDB.SoHDB = HoaDonBan.SoHDB
	where MONTH(GETDATE()) = MONTH(NgayBan) and YEAR(GETDATE()) = YEAR(NgayBan)

--view2 liệt kê các sản phẩm đã nhập trong tháng
go
create or alter view view2 as
	select SanPham.MaSP, TenSP, DonGiaBan, DonGiaNhap, SoLuong ,HangSanXuat, ChiTietHDN.SoHDN, NgayNhap
	from SanPham join ChiTietHDN on SanPham.MaSP =  ChiTietHDN.MaSP join HoaDonNhap on ChiTietHDN.SoHDN = HoaDonNhap.SoHDN
	where MONTH(GETDATE()) = MONTH(NgayNhap) and YEAR(GETDATE()) = YEAR(NgayNhap)

--view3 Thống kê tổng doanh thu theo ngày trong tháng
go
create or alter view view3 as
select NgayBan, sum(TongTien) as DoanhThuTrongNgay
from HoaDonBan
where MONTH(GETDATE()) = MONTH(NgayBan) 
group by NgayBan
go

--view4 Đưa ra danh sách nhân viên(đang làm, ghi chú khác đã nghỉ)
create or alter view view4 as
select MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDienThoai, MaCV, GhiChu
from NhanVien
where GhiChu = N'Đang làm'
go

--view5 Đưa ra danh sách các khách hàng
create or alter view view5 as
select MaKH, TenKH, DiaChi, SoDienThoai from KhachHang
select * from view5
go

--view6 Đưa ra danh sách thông tin các sản phẩm hiện có và số lượng bán
go
create or alter view view6 as
select SanPham.MaSP, TenSP, DonGiaBan, DonGiaNhap, SLBan from SanPham
join ChiTietHDB on SanPham.MaSP = ChiTietHDB.MaSP
select * from view6
go

--view7 Đưa ra danh sách các chức vụ
create or alter view view7 as
select MaCV, TenCV
from ChucVu

--view8 Đưa ra danh sách các đơn đặt hàng mà khách chưa thanh toán (Đang trong thời gian chờ giao)
go
create view view8 as
select MaDH, MaKH, MaNV, TrangThai
from DonDatHang
where TrangThai = N'Đang giao'
go
select * from view8


--trigger1: tự động cập nhật tongtien ở hoadonban khi thêm chitiethoadonban.
go
create or alter trigger Trigger1 on ChiTietHDB for insert, update, delete 
as
begin	
	declare @soHDB1 nvarchar(10), @TT1 money ,@soHDB2 nvarchar(10), @TT2 money
	begin tran
		begin try
			select @soHDB1 = i.SoHDB , @TT1 = (i.SLBan * sp.DonGiaBan)
			from inserted i join SanPham sp on sp.MaSP = i.MaSP

			select @soHDB2 = d.SoHDB , @TT2 = (d.SLBan * sp.DonGiaBan)
			from deleted d join SanPham sp on sp.MaSP = d.MaSP

			update HoaDonBan
			set TongTien = ISNULL(TongTien,0) + ISNULL(@TT1,0) - ISNULL(@TT2,0)
			where SoHDB = isnull(@sohdb1,@sohdb2)
			commit 
		end try
		begin catch
			print 'Error:Thêm không thành công, bạn cần phải thêm số SoHDB trong HoaDonBan trước vì SoHDB không tồn tại!';
			rollback tran
		end catch
end

update HoaDonBan
set TongTien = Banga.TT
from 
(
	select SoHDB, SUM(SanPham.DonGiaBan * ChiTietHDB.SLBan) as TT
	from ChiTietHDB join SanPham on SanPham.MaSP = ChiTietHDB.MaSP
	group by SoHDB
)Banga
where Banga.SoHDB = HoaDonBan.SoHDB



insert into HoaDonBan(SoHDB,NgayBan,HinhThucThanhToan,MaKH,MaNV,MaDH) values('HDB14','2022-03-02',N'Tiền mặt','KH01','NV03',null)
exec themChiTietHDB N'HDB14','SP02',4


select * from ChiTietHDB 
select * from HoaDonBan 


--trigger2: tự động cập nhật soluong ở sanpham khi thêm,sửa,xóa chitiethoadonnhap
go
create or alter trigger Trigger2 on ChiTietHDN for insert, update, delete
as
begin
	declare @inMaSP nvarchar(10), @inSL int,@deMaSP nvarchar(10), @deSL int

	select @inMaSP = i.MaSP , @inSL = i.SLNhap
	from inserted i join SanPham sp on sp.MaSP = i.MaSP

	select @deMaSP = d.MaSP , @deSL = d.SLNhap
	from deleted d join SanPham sp on sp.MaSP = d.MaSP

	update SanPham
	set SoLuong = ISNULL(SoLuong,0) + ISNULL(@inSL,0) - ISNULL(@deSL,0)
	where MaSP = ISNULL(@inMaSP,@deMaSP)
end

insert into HoaDonNhap(SoHDN,NgayNhap,HinhThucThanhToan,MaNCC,MaNV) values('HDN08','2022-04-09',N'Tiền mặt','NCC05','NV03')
insert into ChiTietHDN(SoHDN,MaSP,SLNhap) values('HDN08','SP04',4)

delete from ChiTietHDN
where SoHDN = 'HDN08'

update ChiTietHDN
set SLNhap = 1
where SoHDN = 'HDN08' and MaSP = 'SP04'

select * from ChiTietHDN 
select * from HoaDonNhap 
select * from SanPham 



--trigger3: Số lần mua sẽ tự động tăng lên khi khách hàng thanh toán.

go
create or alter trigger trigger3 on HoaDonBan for insert
as
begin
	declare @MaKH nvarchar(20), @Sl int
	select @MaKH = inserted.MaKH, @Sl = 1
	from inserted

	update KhachHang
	set SoLanMua = ISNULL(SoLanMua,0) + @Sl
	where MaKH = @MaKH
end

select * from KhachHang
insert into HoaDonBan(SoHDB,NgayBan,HinhThucThanhToan,MaKH,MaNV,MaDH) values('HDB15','2022-03-02',N'Tiền mặt','KH01','NV03',null)
select * from HoaDonBan 


--trigger4: khi xóa nhân viên, dùng instead of, k xóa nhân viên mà thay trạng thái ghi chú thành đã nghỉ việc
go
create trigger trigger4 on nhanvien
instead of delete as
begin
	declare @manv nvarchar(10)
	select @manv = deleted.manv from deleted
	update NhanVien
	set GhiChu = N'Đã nghỉ việc'
	where MaNV = @manv
end
select * from nhanvien 

delete from nhanvien 
where MaNV = 'NV02'

--trigger5: Khi xóa nhà cung cấp, k xóa mà thay trạng thái đang hợp tác thành không còn hợp tác
go
create trigger trigger5 on NhaCungCap instead of delete
as
begin
	update NhaCungCap 
	set GhiChu = N'Không còn hợp tác'
	where MaNCC in (select deleted.MaNCC from deleted)
end


select * from NhaCungCap 
delete from NhaCungCap 
where MaNCC = N'NCC06'



--triger6: thêm trường ghi chú ở sản phẩm, khi xóa 1 sản phẩm,  k xóa mà thay trạng thái thành không còn kinh doanh
go
create trigger trigger6 on SanPham instead of delete
as
begin
	update SanPham 
	set GhiChu = N'Không còn kinh doanh'
	where MaSP in (select deleted.MaSP from deleted)
end


select * from SanPham 
delete from SanPham 
where MaSP = N'SP02'



--procedure1: truyền vào 1 mã khách hàng, đưa ra tổng tiền khách hàng đã mua
go
create procedure procedure1 (@makh nvarchar(30), @tongtien money output) as
begin
	select @tongtien = sum(SLBan * DonGiaBan)
	from HoaDonBan join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB
	join SanPham on SanPham.MaSP = ChiTietHDB.MaSP
	where MaKH = @makh
end 

declare @tongtien money
exec procedure1 'KH01', @tongtien output
print @tongtien




--procedure2: truyền vào một mã sản phẩm, đưa ra số lượng sẵn có hiện tại
go
create procedure procedure2 (@masp nvarchar(30), @sluong int output) as
begin
	select @sluong = SLNhap - SLBan
	from SanPham join ChiTietHDB on SanPham.MaSP = ChiTietHDB.MaSP
	join ChiTietHDN on ChiTietHDN.MaSP = SanPham.MaSP
	where SanPham.MaSP = @masp
end 

declare @sluong int
exec procedure2 'SP01', @sluong output
print @sluong


go
--procedure3 truyền vào mã nhân viên, đưa ra chức vụ của nhân viên đó
create or alter procedure procedure3 @manv nvarchar(255), @tennv nvarchar(255) output , @tencv nvarchar(255) output
as begin
	select @tennv = TenNV, @tencv = TenCV
	from NhanVien join ChucVu on NhanVien.MaCV = ChucVu.MaCV
	where MaNV = @manv
end

declare @tennv nvarchar(255), @tencv nvarchar(255)
exec procedure3 'NV01', @tennv output, @tencv output
print N'Tên nhân viên: ' + @tennv
print N'Tên chức vụ: ' + @tencv




--procedure4: insert into cho chiTietHDB (Nếu SoHDB chưa tồn tại trong HoaDonBan thì sẽ hiển thị lỗi) 
go
create or alter procedure procedure4 @SoHDB nvarchar(20),@MaSP nvarchar(20), @SLBan int
as
begin 
	begin tran
	begin try
		insert into ChiTietHDB (SoHDB,MaSP,SLBan) values(@SoHDB,@MaSP,@SLBan)
		commit
	end try

	begin catch
		print N'Error:Thêm không thành công, bạn cần phải thêm số SoHDB trong HoaDonBan trước vì SoHDB không tồn tại!';
		rollback tran
	end catch
end

exec procedure4 N'HDB14','SP02',4



--procedure5 truyền vào mã sản phẩm, đưa thông tin(RAM, ROM, màu sắc, TGBH, Hãng SX, Giá Bán) về sản phẩm đó
go
create or alter procedure procedure5 @masp nvarchar(10), @ram nvarchar(255) output, @rom nvarchar(255) output, @mausac nvarchar(255) output, @tgbh nvarchar(255) output, @hsx nvarchar(255) output, @giaban money output 
as begin
	select @ram = Ram, @rom = Rom, @mausac = MauSac, @tgbh = ThoiGianBaoHanh, @hsx = HangSanXuat, @giaban = DonGiaBan
	from SanPham join ChiTietSanPham on SanPham.MaSP = ChiTietSanPham.MaSP
	where SanPham.MaSP = @masp
end

go
declare @ram nvarchar(255), @rom nvarchar(255), @mausac nvarchar(255), @tgbh nvarchar(255), @hsx nvarchar(255), @giaban money 
exec procedure5 'SP01', @ram output, @rom output, @mausac output, @tgbh output, @hsx output, @giaban output
print N'Ram: ' + @ram
print N'Rom: ' + @rom
print N'Màu sắc: ' + @mausac
print N'Thời gian bao hành: ' + @tgbh
print N'Hãng sản xuất: ' + @hsx
print N'Giá bán: ' + cast(@giaban as nvarchar(255))

go
--procedure6	truyền vào số điện thoại, đưa ra khách hàng có số điện thoại đó
create or alter procedure procedure6 @sodt nvarchar(255), @makh nvarchar(255) output, @tenkh nvarchar(255) output, @dc nvarchar(255) output
as begin
	select @makh = MaKH, @tenkh = TenKH, @dc = DiaChi
	from KhachHang
	where SoDienThoai = @sodt
end


go
declare @makh nvarchar(255), @tenkh nvarchar(255), @dc nvarchar(255)
exec procedure6 '0345655785', @makh output, @tenkh output, @dc output
print N'Mã khách hàng: ' + @makh
print N'Tên khách hàng: ' + @tenkh
print N'Địa chỉ: ' + @dc



--function1 truyền vào tên khách hàng, tìm tất cả các hóa đơn của khách có tên đó(dùng like%ten%)
go
create or alter function function1 (@tenkh nvarchar(40))
returns table
as
return (
	select SoHDB, NgayBan, HinhThucThanhToan
	from HoaDonBan join KhachHang on HoaDonBan.MaKH = KhachHang.MaKH
	where TenKH like '%' + @tenkh
)
select * from function1(N'Linh')

--function2 truyền vào mã nhà cung cấp, đưa ra danh sách các sản phẩm đã nhập từ nhà cung cấp đó
go
create or alter function function2 (@mancc nvarchar(40))
returns table
as
return (
	select SanPham.MaSP, TenSP, DonGiaBan, DonGiaNhap, SoLuong from SanPham
	join ChiTietHDN on ChiTietHDN.MaSP = SanPham.MaSP
	join HoaDonNhap on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN
	join NhaCungCap on NhaCungCap.MaNCC = HoaDonNhap.MaNCC
	where NhaCungCap.MaNCC = @mancc
)
select * from function2('NCC02')

go
--function3 truyền vào mã nhân viên, đưa ra thông tin của nhân viên đó, gồm cả chức vụ
create or alter function function3 (@maNV nvarchar(40))
returns TABLE as
return (
		select NhanVien.TenNV, NgaySinh, GioiTinh, DiaChi, SoDienThoai, GhiChu, TenCV
		from NhanVien join ChucVu on NhanVien.MaCV = ChucVu.MaCV
		where NhanVien.MaNV = @maNV
		)


go
--function4 Tìm thông tin các sản phẩm có giá rẻ(dưới 4.000.000đ)
create or alter function function4 ()
returns TABLE as
return (
		select TenSP, DonGiaBan, DonGiaNhap, SoLuong, HangSanXuat
		from SanPham
		where DonGiaBan < 4000000
		)

--function5 Đưa ra thông tin top 10 khách có tổng tiền hóa đơn cao nhất trong tháng được truyền vào

go
create or alter function function5 (@month int , @year int)
returns table
as
	return (
		select top(10) with ties HoaDonBan.MaKH , sum(SanPham.DonGiaBan * ChiTietHDB.SLBan) as TongTienHD
		from SanPham join ChiTietHDB on SanPham.MaSP = ChiTietHDB.MaSP
				join HoaDonBan on ChiTietHDB.SoHDB = HoaDonBan.SoHDB
		where month(NgayBan) = @month and year(NgayBan) = @year
		group by HoaDonBan.MaKH
		order by TongTienHD desc
	)
go


select * from function5 (4,2022)

select * from ChiTietHDB
--function6 truyền vào hãng sản xuất, mức giá, đưa ra danh sách các sản phẩm của hãng sản xuất đó và có giá <= giá truyền vào
go
create or alter function function6(@hangsx nvarchar(255), @mucgia money)
returns table
as return(
	select MaSP, TenSP, DonGiaBan, SoLuong, HangSanXuat
	from SanPham
	where HangSanXuat = @hangsx and DonGiaBan <= @mucgia
)
select * from function6('Samsung', '5000000000')
go


--Giả sử chủ cửa hàng có toàn quyền trên cơ sở dữ liệu
--chủ cửa hàng tạo cho nhân viên quản lý login, user và cấp quyền select, update, delete, và được phép phân quyền cho nhân viên khác
exec sp_addlogin NguyenThanhHong,NguyenThanhHong --nhan vien quan ly
exec sp_adduser NguyenThanhHong,NguyenThanhHong
grant select, update, delete on QLBanDienThoai  to NguyenThanhHong with grant option
--Nhân viên quản lý tạo login, user cho nhân viên bán hàng, phân quyền cho nhân viên bán hàng:
--Bảng hoadonban, chitiethoadonban, khach, dondh, chitietdondh: select, update, delete
--++Đăng nhập = NguyenThanhHong
exec sp_addlogin NguyenQuynhAnh,NguyenQuynhAnh --nhan vien ban hang
exec sp_adduser NguyenQuynhAnh,NguyenQuynhAnh
--Bảng sanpham: select
--++Đăng nhập = NguyenThanhHong
grant select, update, delete on hoadonban to NguyenQuynhAnh
grant select, update, delete on chitiethoadonban to NguyenQuynhAnh
grant select, update, delete on khach to NguyenQuynhAnh
grant select, update, delete on dondh to NguyenQuynhAnh
grant select, update, delete on chitietdondh to NguyenQuynhAnh
--Nhân viên quản lý tạo login, user và phân quyền select trên toàn cơ sở dữ liệu cho nhân viên kế toán
--++Đăng nhập = NguyenThanhHong
exec sp_addlogin NguyenBaTuan,NguyenBaTuan --nhan vien ke toan
exec sp_adduser NguyenBaTuan,NguyenBaTuan
grant select on QLBanDienThoai  to NguyenBaTuan 






