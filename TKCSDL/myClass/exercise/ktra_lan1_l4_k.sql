
--cau1
create view cau1 
as 
select DAY(hdb.NgayBan) , SUM(cthd.SLBan * s.DonGiaBan) as TT
from tHoaDonBan hdb join tChiTietHDB cthd on cthd.SoHDB =hdb.SoHDB
		join tSach s on s.MaSach = cthd.MaSach
where MONTH(hdb.NgayBan) = 4 and year(hdb.NgayBan) = 2014
group by DAY(hdb.NgayBan)



--cau2: 
alter function Bai2 (@tenKH nvarchar(50)) 
returns table
as 
	return (
		select tHoaDonBan.SoHDB, tHoaDonBan.NgayBan, @tenKH as 'Tên KH' , sum(tSach.DonGiaBan * tChiTietHDB.SLBan) as TriGia
		from tChiTietHDB join tSach on tChiTietHDB.MaSach = tSach.MaSach
			join tHoaDonBan on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
			join tKhachHang on tHoaDonBan.MaKH = tKhachHang.MaKH
		where @tenKH = tKhachHang.TenKH
		group by tHoaDonBan.SoHDB,tHoaDonBan.NgayBan
)

select * from Bai2(N'Nguyễn Đình Sơn')


--cau 2: 
alter function Bai2 (@tenKH nvarchar(50)) returns table
as 
return (

		select tChiTietHDB.soHDB ,tChiTietHDB.MaSach,tChiTietHDB.SLBan , BangTriGia.TriGia
		from tChiTietHDB,
		(select tChiTietHDB.soHDB, sum(tSach.DonGiaBan * tChiTietHDB.SLBan) as TriGia
		from tChiTietHDB join tSach on tChiTietHDB.MaSach = tSach.MaSach
			join tHoaDonBan on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
			join tKhachHang on tHoaDonBan.MaKH = tKhachHang.MaKH
		where @tenKH = tKhachHang.TenKH
		group by tChiTietHDB.SoHDB)BangTriGia
		where BangTriGia.SoHDB = tChiTietHDB.soHDB
)

select * from Bai2(N'Nguyễn Đình Sơn')





--cau 3
exec sp_addlogin TranVietAnh, 123
exec sp_adduser TranVietAnh,TranVietAnh

grant select on cau1 to TranVietAnh with grant option
grant select on cau1 to NguyenKhanhNgoc 


exec sp_addlogin NguyenKhanhNgoc, 123
exec sp_adduser NguyenKhanhNgoc,NguyenKhanhNgoc



--cau4
create view Bai4 as
select Top(10) with ties tKhachHang.MaKH, sum(tSach.DonGiaBan * tChiTietHDB.SLBan) as tieudung
		from tChiTietHDB join tSach on tChiTietHDB.MaSach = tSach.MaSach
			join tHoaDonBan on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
			join tKhachHang on tHoaDonBan.MaKH = tKhachHang.MaKH
		where year(tHoaDonBan.NgayBan) = 2014
		group by tKhachHang.MaKH
		order by tieudung desc


select * from B4



























--tạo viewer danh sách khách hàng VIP của năm 2014 bao gồm 10 khách hàng có tổng tiêu dùng 
--là cao nhất trong năm đó
create view B4 as
select Top(10)tenKH, sum(tSach.DonGiaBan * tChiTietHDB.SLBan) as tieudung
		from tChiTietHDB join tSach on tChiTietHDB.MaSach = tSach.MaSach
			join tHoaDonBan on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
			join tKhachHang on tHoaDonBan.MaKH = tKhachHang.MaKH
		where year(tHoaDonBan.NgayBan) = 2014
		group by TenKH
		order by tieudung desc
select * from B4

go

create view cau4
as
select top (10) with ties kh.MaKH, kh.TenKH , kh.DiaChi , kh.DienThoai,COUNT(hdb.SoHDB)
from tKhachHang kh join tHoaDonBan hdb on hdb.MaKH = hdb.MaKH
where YEAR(NgayBan) = 2014
group by kh.MaKH, kh.TenKH , kh.DiaChi , kh.DienThoai
order by COUNT(hdb.SoHDB) desc