--câu 1: tạo view đưa ra hóa đơn và tổng tiền của mỗi hóa đơn trong các ngày của tháng 4 và tổng tiền của 4/2015
create view cau1 
as 
select hdb.SoHDB, DAY(hdb.NgayBan) as NgayBan , SUM(cthd.SLBan * s.DonGiaBan) as TT
from tHoaDonBan hdb join tChiTietHDB cthd on cthd.SoHDB =hdb.SoHDB
		join tSach s on s.MaSach = cthd.MaSach
where MONTH(hdb.NgayBan) = 4 and year(hdb.NgayBan) = 2015
group by DAY(hdb.NgayBan),hdb.SoHDB

create view cau1_2 
select SUM(TT) as TongTien
from cau1


--câu 2: tạo thủ tục có đầu vào là tháng, đầu ra là số tiền và số lượng hóa đơn thu được trong tháng đó
go
create procedure sotien @thang int, @tien money output, @sl int output 
as
begin 
	select @tien = SUM(SLBan * DonGiaBan), @sl = COUNT(distinct tChiTietHDB.SoHDB)
	from tSach, tChiTietHDB, tHoaDonBan 
	where tSach.MaSach = tChiTietHDB.MaSach and tChiTietHDB.SoHDB = tHoaDonBan.SoHDB
	and MONTH(NgayBan) = @thang
end


declare @tongTien money, @sluong int
exec sotien 4, @tongTien output, @sluong output
print @tongTien
print @sluong






--câu 3:  
CREATE LOGIN TranThanhPhong
WITH PASSWORD = '123'
go
CREATE USER TranThanhPhong
FOR LOGIN TranThanhPhong

GRANT SELECT on Cau1_1 to TranThanhPhong with grant option

CREATE LOGIN PhamVanNam
WITH PASSWORD = '123'
go
CREATE USER PhamVanNam
FOR LOGIN PhamVanNam
GRANT Update on Cau1_1 to TranThanhPhong with grant option

--câu 4: tạp view danh sách nhân viên xuất sắc của tháng 5/2014 bao gồm các nhân viên có tổng hóa đơn nhập và bán là cao nhất trong tháng đó 

create view cau4
select *
from tNhanVien nv 
where nv.MaNV in(
select top(1) with ties tHoaDonBan.MaNV
from tHoaDonBan join tHoaDonNhap on tHoaDonBan.MaNV = tHoaDonNhap.MaNV 
	join tChiTietHDB on tChiTietHDB.SoHDB = tHoaDonBan.SoHDB join tChiTietHDN on tChiTietHDN.SoHDN = tHoaDonNhap.SoHDN 
	JOIN TSACH on tSach.MaSach = tChiTietHDB.MaSach
where YEAR(NgayBan) = 2014 and MONTH(NgayBan) = 5
group by tHoaDonBan.MaNV 
order by sum(SLBan* DonGiaBan + SLNhap * DonGiaNhap)  desc
)



