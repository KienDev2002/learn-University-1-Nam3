
--Câu 1: Tạo hàm có đầu vào là tháng đầu ra là thông tin các hóa đơn trong tháng đó.

--ĐỀ THI MẪU 2
--Sử dụng cơ sở dữ liệu quản lý bán sách.

--Câu 1: Tạo hàm có đầu vào là tháng đầu ra là thông tin các hóa đơn trong tháng đó.
go
create or alter function TimHoaDonTheoThang(@month int, @year int)
returns table
return (
            select SoHDB, MaNV, NgayBan, MaKH 
            from tHoaDonBan
            where YEAR(NgayBan)=@year and MONTH(NgayBan)=@month
        )
go
select * from TimHoaDonTheoThang(4,2014)
--Câu 2: Tạo thủ tục có đầu vào là mã nhân viên, đầu ra là số lượng hóa đơn nhập, số
--lượng hóa đơn bán mà nhân viên đó xử lý
go
create or alter procedure ThongKeHoadonTheoNhanVien @manv nvarchar(20), @slhdn int output, @slhdb int output
as
begin
    select @slhdn = count(SoHDN)
    from tHoaDonNhap
    where MaNV = @manv
    select @slhdb = count(SoHDB)
    from tHoaDonBan
    where MaNV = @manv
end
go
declare @hdn int, @hdb int
exec ThongKeHoadonTheoNhanVien N'NV02', @hdn output, @hdb output
print @hdn
print @hdb

 

--Câu 3: Tạo view đưa ra thông tin các khách hàng và thông tin hóa đơn, trị giá hóa đơn
--họ đã mua trong năm 2014
go
create or alter view ThongTinKhachNam2014 as
select tKhachHang.MaKH, TenKH, DiaChi, DienThoai, GioiTinh, sum(tChiTietHDB.SLBan*tSach.DonGiaBan) as TriGiaHD
from tKhachHang join tHoaDonBan on tKhachHang.MaKH = tHoaDonBan.MaKH
    join tChiTietHDB on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    join tSach on tChiTietHDB.MaSach = tSach.MaSach
where YEAR(NgayBan) = 2014
group by tKhachHang.MaKH, TenKH, DiaChi, DienThoai,GioiTinh
go
select * from ThongTinKhachNam2014
--Câu 4: Thêm trường Tổng số đầu sách và bảng thể loại, cập nhật tự động cho trường
--này mỗi khi thêm, sửa, xóa một sách trong bảng sách
alter table ttheloai
add TongSoDauSach int

 

--alter table ttheloai
--drop column TongSoDauSach
go
create or alter trigger cau4de2 on tsach
for insert, update, delete as
begin
    declare @matheloai1 nvarchar(10), @matheloai2 nvarchar(10)
    select @matheloai1 = MaTheLoai from inserted
    select @matheloai2 = MaTheLoai from deleted
    
    update tTheLoai
    set TongSoDauSach = ISNULL(TongSoDauSach,0) + 1
    where MaTheLoai = @matheloai1

 

    update tTheLoai
    set TongSoDauSach = ISNULL(TongSoDauSach,0) - 1
    where MaTheLoai = @matheloai2
end
go
select * from tTheLoai
insert into tSach(MaSach, TenSach, MaTheLoai) values ('S1000', N'Thép đã tôi thế đấy', N'TL01')
select * from tTheLoai

 

--Câu 5: Tạo login TranThanhPhong, tạo user TranThanhPhong cho TranThanhPhong
--trên CSDL QLBanSach
use BT1CSDL_banSach
exec sp_addlogin TranThanhPhong,123
exec sp_adduser TranThanhPhong,TranThanhPhong

 

--exec sp_dropuser TranThanhPhong
--exec sp_droplogin TranThanhPhong
--Phân quyền Select, update trên bảng tSach cho TranThanhPhong và TranThanhPhong
--được phép phân quyền cho người khác
grant select, update on tsach to TranThanhPhong with grant option
--Đăng nhập TranThanhPhong để kiểm tra
-- thoát ra, connect lại = tài khoản tranthanhphong, tạo 1 trang query mới
select * from tsach
--Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLBanSach
use BT1CSDL_banSach
exec sp_addlogin PhamVanNam,123
exec sp_adduser PhamVanNam,PhamVanNam
--Đăng nhập PhamVanNam để kiểm tra

 

--Từ login TranThanhPhong, phân quyền Select trên bảng tSach cho PhamVanNam
--+thoát ra, connect lại = tài khoản tranthanhphong, tạo 1 trang query mới
grant select on tsach to PhamVanNam
--Đăng nhập PhamVanNam để kiểm tra
--+thoát ra, connect lại = tài khoản PhamVanNam, tạo 1 trang query mới
select * from tsach
--Câu 6: Tạo view đưa ra những khách hàng có tổng số lượng hóa đơn cao nhất và cao
--nhì trong năm 2014
go
create or alter view KHCoTongHoaDonCaoNhatNhi as
select tkhachhang.MaKH, TenKH, count(sohdb) as SLHD
from tKhachHang join tHoaDonBan on tKhachHang.MaKH = tHoaDonBan.MaKH
where YEAR(NgayBan)=2014
group by tKhachHang.MaKH, TenKH
having count(sohdb) in (select distinct top(2) count(sohdb) as SLHD
                        from tKhachHang join tHoaDonBan on tKhachHang.MaKH = tHoaDonBan.MaKH
                        where YEAR(NgayBan) = 2014
                        group by tKhachHang.MaKH
                        order by SLHD desc)
go
select * from KHCoTongHoaDonCaoNhatNhi