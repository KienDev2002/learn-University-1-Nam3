
--cau1
create view cau1
as 
begin
	select hdb.NgayBan as NgayBan , SUM(cthdb.SLBan * s.DonGiaBan) as TongTien
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where MONTH(hdb.NgayBan) = 4 and YEAR(hdb.NgayBan) = 2014
	group by hdb.NgayBan
end






--cau2_2: 
alter function cau2_2 (@tenKH nvarchar(50)) 
returns table
as 
	return (
		select tHoaDonBan.SoHDB , sum(tSach.DonGiaBan * tChiTietHDB.SLBan) as TriGia
		from tChiTietHDB join tSach on tChiTietHDB.MaSach = tSach.MaSach
			join tHoaDonBan on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
			join tKhachHang on tHoaDonBan.MaKH = tKhachHang.MaKH
		where @tenKH = tKhachHang.TenKH
		group by tHoaDonBan.SoHDB
)

select * from cau2_2(N'Nguyễn Đình Sơn')


--cau3
exec sp_addlogin NguyenHoangLan,123
exec sp_adduser NguyenHoangLan,NguyenHoangLan

grant select, update on cau1 to NguyenHoangLan with grant option

exec sp_addlogin TrinhXuanBach,123
exec sp_adduser TrinhXuanBach,TrinhXuanBach



--cau4
go
create view cau4 
as
select Top(10) with ties tKhachHang.MaKH, sum(tSach.DonGiaBan * tChiTietHDB.SLBan) as tieudung
		from tChiTietHDB join tSach on tChiTietHDB.MaSach = tSach.MaSach
			join tHoaDonBan on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
			join tKhachHang on tHoaDonBan.MaKH = tKhachHang.MaKH
		where year(tHoaDonBan.NgayBan) = 2014
		group by tKhachHang.MaKH
		order by tieudung desc

select * from cau4
