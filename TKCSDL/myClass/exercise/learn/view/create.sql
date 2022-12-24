
--Tạo view danh sách các nxb giáo dục nhập năm 2014
create view DS_Sach_GiaoDuc_2014
as
SELECT ts.MaSach, ts.TenSach
from tSach ts join tNhaXuatBan nxb on nxb.MaNXB = ts.MaNXB
join tChiTietHDN cthd on cthd.MaSach = ts.MaSach
join tHoaDonNhap hdn on hdn.SoHDN = cthd.SoHDN
where nxb.TenNXB = N'NXB Giáo dục' and YEAR(hdn.NgayNhap) = 2014


-- tạo view thống kê các sách ko bán đc trong năm 2021
create view TK_Sach_KhongBanDuoc_2021
as
select ts.MaSach, ts.TenSach
from tSach ts 
where ts.MaSach not in (
		select cthdb.MaSach
		from tChiTietHDB cthdb join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
		where YEAR(hdb.NgayBan) = 2021
	)


-- tạo view thống kê 10 khách hàng có tổng hóa đơn cao nhất trong năm 2014
create view Top10_HD_CN
as
select top (10)  kh.TenKH , sum(ts.SoLuong * ts.DonGiaBan) as TongHD
from tKhachHang kh join tHoaDonBan hdb on kh.MaKH = hdb.MaKH
	join tChiTietHDB cthd on cthd.SoHDB = hdb.SoHDB
	join tSach ts on ts.MaSach = cthd.MaSach
where YEAR(hdb.NgayBan) = 2014
group by kh.TenKH
order by TongHD desc









