

--cau1
create view cau1 
as 
select hdb.SoHDB, DAY(hdb.NgayBan) as NgayBan , SUM(cthd.SLBan * s.DonGiaBan) as TT
from tHoaDonBan hdb join tChiTietHDB cthd on cthd.SoHDB =hdb.SoHDB
		join tSach s on s.MaSach = cthd.MaSach
where MONTH(hdb.NgayBan) = 5 and year(hdb.NgayBan) = 2014
group by DAY(hdb.NgayBan),hdb.SoHDB

create view cau1_2 
select SUM(TT) as TongTien
from cau1




--cau2




--cau4
create view cau4
as

select BangHDB.THDB + BangHDN.THDN
from (select COUNT(hdb.SoHDB) as THDB,hdb.MaNV as MNV1
from tNhanVien nv join tHoaDonBan hdb on nv.MaNV = hdb.MaNV
where MONTH(hdb.NgayBan) = 5 and YEAR(hdb.NgayBan) = 2014
group by hdb.MaNV) BangHDB,
(select COUNT(hdn.SoHDN) as THDN,hdn.MaNV as MNV2
from tNhanVien nv join tHoaDonNhap hdn on nv.MaNV = hdn.MaNV
where MONTH(hdn.NgayNhap) = 5 and YEAR(hdn.NgayNhap) = 2014
group by hdn.MaNV)BangHDN



select top(1) with ties tHoaDonBan.MaNV
from tHoaDonBan join tHoaDonNhap on tHoaDonBan.MaNV = tHoaDonNhap.MaNV 
	join tChiTietHDB on tChiTietHDB.SoHDB = tHoaDonBan.SoHDB 
	join tChiTietHDN on tChiTietHDN.SoHDN = tHoaDonNhap.SoHDN 
	JOIN TSACH on tSach.MaSach = tChiTietHDB.MaSach
where YEAR(NgayBan) = 2014 and MONTH(NgayBan) = 5
group by tHoaDonBan.MaNV 
order by sum(SLBan* DonGiaBan + SLNhap * DonGiaNhap)  desc

select *
from tHoaDonBan