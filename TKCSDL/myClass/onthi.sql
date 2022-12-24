

--cau 1:Tạo view in ra danh sách các sách của nhà xuất bản giáo dục nhập trong năm 2021
create view cau1view
as
select s.MaSach, TenSach 
from tSach s join tNhaXuatBan nxb on nxb.MaNXB = s.MaNXB
	join tChiTietHDN cthdn on cthdn.MaSach = s.MaSach
	join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
where YEAR(NgayNhap) = 2014 and TenNXB = N'NXB Giáo Dục'


--2.Tạo view thống kê các sách không bán được trong năm 2021
go
create view cau2View 
as
select s.MaSach
from tSach s 
where s.MaSach not in 
(
	select cthdb.MaSach
	from tChiTietHDB cthdb join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
	where YEAR(hdb.NgayBan) = 2014
)


--3.Tạo view thống kê 10 khách hàng có tổng tiền tiêu dùng cao nhất trong năm 2021
go
create view cau3View 
as
select top(2) with ties kh.MaKH, kh.TenKH, SUM(SLBan * DonGiaBan) as TTD
from tKhachHang kh join tHoaDonBan hdb on hdb.MaKH = kh.MaKH
	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(hdb.NgayBan) = 2014
group by kh.MaKH , kh.TenKH
order by TTD desc

--4---Xem LẠI-----.Tạo view thống kê số lượng sách bán ra trong năm 2021 và số lượng sách nhập trong năm 2021 và chênh lệch giữa hai số lượng này ứng với mỗi đầu sách

select tSach.MaSach , tSach.TenSach, ISNULL(BangSLB.SLB,0) as SLB, ISNULL(BangSLN.SLN,0) as SLN, ISNULL(ISNULL(SLN,0) - ISNULL(SLB,0) ,0) as CL
from tSach left join
(select MaSach, sum(SLBan) as SLB
from tChiTietHDB cthdb join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
where YEAR(hdb.NgayBan) = 2014
group by MaSach
)BangSLB on BangSLB.MaSach = tSach.MaSach
full outer join
(
select MaSach, sum(SLNhap) as SLN
from tChiTietHDN cthdn join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
where YEAR(hdn.NgayNhap) = 2014
group by MaSach
)BangSLN on BangSLN.MaSach = BangSLB.MaSach
where SLB>0 or SLN>0



--5.Tạo view đưa ra những thông tin hóa đơn và tổng tiền của hóa đơn đó trong ngày 16/11/2021
create view cauView
as
select hdb.SoHDB, SUM(cthdb.SLBan * s.DonGiaBan)
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = cthdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where day(NgayBan) = 11 and month(NgayBan) = 8 and  YEAR(NgayBan) = 2014
group by hdb.SoHDB

-- 6. Tạo view đưa ra doanh thu bán hàng của từng tháng trong năm 2014, những tháng không có doanh thu thì ghi là 0.
create view cau6View 
as
select ISNULL( SUM(case when MONTH(NgayBan)=1 then SLBan * DonGiaBan end)  , 0) as Thang1,
 ISNULL( SUM(case when MONTH(NgayBan)=2 then SLBan * DonGiaBan end)  , 0) as Thang2,
 ISNULL( SUM(case when MONTH(NgayBan)=3 then SLBan * DonGiaBan end)  , 0) as Thang3,
 ISNULL( SUM(case when MONTH(NgayBan)=4 then SLBan * DonGiaBan end)  , 0) as Thang4,
 ISNULL( SUM(case when MONTH(NgayBan)=5 then SLBan * DonGiaBan end)  , 0) as Thang5,
 ISNULL( SUM(case when MONTH(NgayBan)=6 then SLBan * DonGiaBan end)  , 0) as Thang6,
 ISNULL( SUM(case when MONTH(NgayBan)=7 then SLBan * DonGiaBan end)  , 0) as Thang7,
 ISNULL( SUM(case when MONTH(NgayBan)=8 then SLBan * DonGiaBan end)  , 0) as Thang8,
 ISNULL( SUM(case when MONTH(NgayBan)=9 then SLBan * DonGiaBan end)  , 0) as Thang9,
 ISNULL( SUM(case when MONTH(NgayBan)=10 then SLBan * DonGiaBan end)  , 0) as Thang10,
 ISNULL( SUM(case when MONTH(NgayBan)=11 then SLBan * DonGiaBan end)  , 0) as Thang11,
 ISNULL( SUM(case when MONTH(NgayBan)=12 then SLBan * DonGiaBan end)  , 0) as Thang12,
 ISNULL(SUM (SLBan * DonGiaBan),0) as CaNam
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(NgayBan) = 2014



--7. Tạo view đưa ra doanh thu bán hàng theo ngày, và tổng doanh thu cho mỗi tháng (dùng roll up)


--8.Tạo view đưa ra danh sách 3 khách hàng có tiền tiêu dùng cao nhất
select top(3) with ties kh.MaKH, kh.TenKH, SUM(SLBan * DonGiaBan) as TTD
from tKhachHang kh join tHoaDonBan hdb on hdb.MaKH = kh.MaKH 
	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
group by kh.MaKH, kh.TenKH
order by TTD desc

--cau9:.Tạo view đưa ra 10 đầu sách được tiêu thụ nhiều nhất trong năm 2022 và số lượng tiêu thụ mỗi đầu sách.
create view cau9View 
as
select top(2) with ties s.MaSach, sum(SLBan) as TT
from tSach s join tChiTietHDB cthdb on cthdb.MaSach = s.MaSach
	join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
where YEAR(hdb.NgayBan) = 2014
group by s.MaSach
order by TT desc

--10.Tạo view SachGD đưa ra danh sách các sách với các thông tin MaSach,TenSach, tên thể loại, tổng số lượng nhập, tổng số lượng bán, số lượng tồn do Nhà xuất bản Giáo Dục xuất bản.

create view cau10View 
as
select s.MaSach, s.TenSach, s.MaTheLoai, ISNULL(BangSLN.SLN,0) as SLN, ISNULL(BangSLB.SLB,0) as SLB , ISNULL(ISNULL(BangSLN.SLN,0) - ISNULL(BangSLB.SLB,0), 0)
from tSach s left join
(
	select cthdn.MaSach , SUM(cthdn.SLNhap) as SLN
	from tChiTietHDN cthdn
	group by cthdn.MaSach
)BangSLN on BangSLN.MaSach = s.MaSach
full outer join 
(
	select cthdb.MaSach , SUM(cthdb.SLBan) as SLB
	from tChiTietHDB cthdb
	group by cthdb.MaSach
)BangSLB on BangSLB.MaSach = BangSLN.MaSach
join tNhaXuatBan nxb on nxb.MaNXB = s.MaNXB
where nxb.TenNXB = N'NXB Giáo Dục' and (SLB >0 or SLN > 0)


--11.Tạo view KhachVip đưa ra khách hàng gồm thông tin MaKH, TenKH, địa chỉ, điện thoại cho những khách hàng đã mua hàng với tổng tất cả các trị giá hóa đơn trong năm hiện tại lớn hơn 30.000.00

create view KhachVip
as
select kh.MaKH, kh.TenKH, kh.DiaChi, kh.DienThoai, SUM(SLBan * DonGiaBan) as THD
from tKhachHang kh join tHoaDonBan hdb on hdb.MaKH = kh.MaKH 
	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(NgayBan) = YEAR(GETDATE())
group by kh.MaKH, kh.TenKH, kh.DiaChi, kh.DienThoai
having SUM(SLBan * DonGiaBan) > 3000000

--12.Tạo view đưa ra số hóa đơn, trị giá các hóa đơn và tổng toàn bộ trị giá của các hoa đơn do nhân viên có tên “Trần Huy” lập trong tháng hiện tại
create view cau12View
as
select hdb.SoHDB,  SUM(SLBan * DonGiaBan) as TGHD
from tNhanVien nv join tHoaDonBan hdb on hdb.MaNV = nv.MaNV
	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where nv.TenNV = N'Trần Huy' and (MONTH(NgayBan) = 8  or MONTH(NgayBan) = 1)
group by hdb.SoHDB

go
create view cau12View_2
as
select SUM(ll.TGHD)  
from cau12View ll

select * from tHoaDonBan
--13.Tạo view đưa thông tin các các sách còn tồn 
create view SachTon
as
select s.MaSach, s.TenSach
from tSach s 
where s.MaSach not in
(
select cthdb.MaSach
from tChiTietHDB cthdb 
)

--14.Tạo view đưa ra danh sách các sách không bán được trong năm 2014.
create view cau14View
as
select s.MaSach, s.TenSach
from tSach s 
where s.MaSach not in
(
	select cthdb.MaSach
	from tChiTietHDB cthdb join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
	where YEAR(hdb.NgayBan) = 2014
)

--15.Tạo view đưa ra danh sách các sách của NXB Giáo Dục không bán được trong năm 
--2014.
create view cau15View
as
select s.MaSach, s.TenSach,nxb.TenNXB
from tSach s join tNhaXuatBan nxb on nxb.MaNXB = s.MaNXB
where nxb.TenNXB = N'NXB Thủ Đô' and  s.MaSach not in
(
	select cthdb.MaSach
	from tChiTietHDB cthdb join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
	where YEAR(hdb.NgayBan) = 2014
)
select * from tNhaXuatBan
select * from tSach
select * from tChiTietHDB


--16.Tạo view đưa ra các thông tin về sách và số lượng từng sách được bán ra trong năm 
--2014.
create view cau16View
as
select s.MaSach, s.TenSach, s.TacGia, SUM(SLBan) as SLS
from tSach s join tChiTietHDB cthdb on cthdb.MaSach = s.MaSach 
	join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
where YEAR(hdb.NgayBan) = 2014
group by s.MaSach, s.TenSach, s.TacGia

--17.Tạo view đưa ra họ tên khách hàng đã mua hóa đơn có trị giá cao nhất trong năm 2014.
create view cau17View
as
select top(1) with ties kh.TenKH, SUM(SLBan * DonGiaBan) TG
from tKhachHang kh join tHoaDonBan hdb on hdb.MaKH = kh.MaKH
	join tChiTietHDB cthdb on hdb.SoHDB = cthdb.SoHDB
	join tSach s on cthdb.MaSach = s.MaSach 
where YEAR(NgayBan) = 2014
group by kh.TenKH
order by TG desc



--18.Tạo view đưa ra danh sách 3 nhân viên (MaKH, TenKH) có doanh số cao nhất của năm 
--hiện tại.
create view cau18View 
as
select top(3) with ties nv.MaNV, nv.TenNV, SUM(SLBan * DonGiaBan) as DS
from tNhanVien nv join tHoaDonBan hdb on hdb.MaNV = nv.MaNV
	join tChiTietHDB cthdb on hdb.SoHDB = cthdb.SoHDB
	join tSach s on cthdb.MaSach = s.MaSach 
where YEAR(NgayBan) = 2014
group by nv.MaNV, nv.TenNV
order by DS desc


--19.Tạo view đưa ra danh sách sách và số lượng nhập của mỗi nhà xuất bản trong năm hiện 
--tại
create view cau19View 
as
select s.MaSach, s.TenSach, nxb.TenNXB
from tSach s join tNhaXuatBan nxb on nxb.MaNXB = s.MaNXB 
where nxb.TenNXB in 
(select cau19View_2.nxb
from cau19View_2
)
GO
create or alter view cau19View_2
as
select nxb.TenNXB as nxb, SUM(SLNhap) As sl
from tSach s join tNhaXuatBan nxb on nxb.MaNXB = s.MaNXB
	join tChiTietHDN cthdn on cthdn.MaSach = s.MaSach 
	join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
where YEAR(NgayNhap) = 2014
group by nxb.TenNXB


/*
Thủ tục

1. Tạo thủ tục có đầu vào là mã sách, đầu ra là số lượng sách đó được bán trong năm 2014
*/
go
create or alter procedure cau1procedure @maSach nvarchar(20) , @sl int output
as
begin
	select @sl = SUM(SLBan)
	from tSach s join tChiTietHDB cthdb on cthdb.MaSach = s.MaSach
		join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
	where s.MaSach = @maSach and  YEAR(NgayBan) = 2014
end

declare @sluong int
exec cau1procedure N'S01' , @sluong output
print(@sluong)

select * from tSach
select * from tChiTietHDB
select * from tHoaDonBan

/*
2. Tạo thủ tục có đầu vào là ngày, đầy ra là số lượng hóa đơn và số lượng tiền bán của sách 
trong ngày đó
*/
create or alter procedure cau2Procedures @ngay date, @slHD int output , @slTien money output
as
begin
	select @slHD = count(distinct hdb.SoHDB) , @slTien = sum(cthdb.SLBan * s.DonGiaBan)
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where hdb.NgayBan = @ngay
end

declare @soLuongHD int , @soLuongTien money 
exec cau2Procedures N'2014-08-11', @soLuongHD output , @soLuongTien output
print(@soLuongHD)
print(@soLuongTien)


--3. Tạo thủ tục có đầu vào là mã nhà cung cấp, đầu ra là số đầu sách và số tiền cửa hàng đã 
--nhập của nhà cung cấp đó
create or alter procedure cau3Pro @maNCC nvarchar(20), @soDauSach int output, @soTien money output
as
begin
	select @soDauSach = COUNT(distinct cthdn.MaSach) , @soTien = SUM(SLNhap * DonGiaNhap)  
	from tHoaDonNhap hdn join tChiTietHDN cthdn on cthdn.SoHDN = hdn.SoHDN
		join tSach s on s.MaSach = cthdn.MaSach
	where hdn.MaNCC = @maNCC
end

declare @soDS int , @soT money
exec cau3Pro N'NCC01', @soDS output , @soT output
print(@soDS)
print(@soT)

select * from tHoaDonNhap
select * from tChiTietHDN

--4.Tạo thủ tục có đầu vào là năm, đầu ra là số tiền nhập hàng, số tiền bán hàng của năm đó.
create or alter procedure cau4Pro @year int,  @soTienN money output,@soTienB money output
as
begin
	select @soTienN = SUM(SLNhap * DonGiaNhap)
	from tHoaDonNhap hdn join tChiTietHDN cthdn on cthdn.SoHDN = hdn.SoHDN
		join tSach s on s.MaSach = cthdn.MaSach
	where YEAR(NgayNhap) = @year

	select @soTienB = SUM(SLBan * DonGiaBan)
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where YEAR(NgayBan) = @year
end

declare @soTN money , @soTB money
exec cau4Pro 2014, @soTN output , @soTB output
print(@soTN)
print(@soTB)


--5. Tạo thủ tục có đầu vào là mã NXB, đầu ra là số lượng sách tồn của nhà xuất bản đó
create or alter procedure cau5Pro @maNXB nvarchar(20), @soLuongTon int output
as
begin
	select @soLuongTon =  SUM(cthdn.SLNhap ) - SUM(cthdb.SLBan)
	from tSach s join tChiTietHDB cthdb on cthdb.MaSach = s.MaSach
		join tChiTietHDN cthdn on cthdn.MaSach = s.MaSach
	where s.MaNXB = @maNXB
end

declare @soLuongTon1 int 
exec cau5Pro N'NXB01', @soLuongTon1 output
print(@soLuongTon1)



--8.Tạo thủ tục có đầu vào là năm, đầu ra là số lượng sách nhập, sách bán và sách tồn của năm 
--đó
create or alter procedure cau8Pro @year int, @soLuongNhap int output, @soLuongban int output,  @soLuongTon int output
as
begin

	select @soLuongNhap = COUNT(distinct cthdn.MaSach)
	from tHoaDonNhap hdn join tChiTietHDN cthdn on cthdn.SoHDN = hdn.SoHDN
	where YEAR(NgayNhap) = @year

	select @soLuongban = COUNT(distinct cthdb.MaSach)
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	where YEAR(NgayBan) = @year

	select @soLuongTon = ISNULL(@soLuongNhap,0) - ISNULL(@soLuongban,0)

end

declare @soLuongTon1 int ,@soLuongNhap1 int , @soLuongban1 int
exec cau8Pro 2014, @soLuongNhap1 output , @soLuongban1 output ,@soLuongTon1 output
print(@soLuongNhap1)
print(@soLuongban1)
print(@soLuongTon1)



--9. Tạo thủ tục có đầu vào là mã sách, năm, đầu ra số lượng sách nhập, số lượng sách bán
--trong năm đó
create or alter procedure cau9Pro @maSach nvarchar(20), @year int, @soLuongNhap int output, @soLuongban int output
as
begin
	select @soLuongNhap = SUM(SLNhap)
	from tHoaDonNhap hdn join tChiTietHDN cthdn on cthdn.SoHDN = hdn.SoHDN
	where cthdn.MaSach = @maSach and YEAR(NgayNhap) = @year

	select @soLuongban = SUM(SLBan)
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	where cthdb.MaSach = @maSach and YEAR(NgayBan) = @year

end

declare @soLuongNhap1 int , @soLuongban1 int
exec cau9Pro N'S01', 2014, @soLuongNhap1 output , @soLuongban1 output 
print(@soLuongNhap1)
print(@soLuongban1)



--10. Tạo thủ tục có đầu vào là mã khách hàng, năm, đầu ra là số lượng sách đã mua và số 
--lượng tiền tiêu dùng của khách hàng đó trong năm nhập vào
create or alter procedure cau10Pro @maKh nvarchar(20), @year int, @sl int output , @slTien money output
as
begin
	select @sl = SUM(SLBan) , @slTien = SUM(SLBan * DonGiaBan)
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where hdb.MaKH = @maKh and YEAR(NgayBan) = @year
end

declare @sluong int, @soTien money
exec cau10Pro N'KH01', 2014 , @sluong output, @soTien output
print(@sluong)
print(@soTien)

/* 11.	Tạo thủ tục có đầu vào là mã khách hàng, năm, đầu ra là số lượng hóa đơn đã mua và số lượng tiền tiêu dùng của khách hàng đó trong năm đó.*/

create or alter procedure cau11Pro @maKh nvarchar(20), @year int, @sl int output , @slTien money output
as
begin
	select @sl = COUNT(distinct hdb.SoHDB), @slTien = SUM(SLBan * DonGiaBan)
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where hdb.MaKH = @maKh and YEAR(NgayBan) = @year
end

declare @sluong int, @soTien money
exec cau11Pro N'KH01', 2014 , @sluong output, @soTien output
print(@sluong)
print(@soTien)




--Hàm




--1. Tạo hàm đưa ra tổng số tiền đã nhập sách trong một năm với tham số đầu vào là năm
go
create or alter function cau1Fun (@year int)
returns int
as
begin
	declare @soTien money
	select @soTien = SUM(SLNhap * DonGiaNhap)
	from tHoaDonNhap hdn join tChiTietHDN cthdn on cthdn.SoHDN = hdn.SoHDN
		join tSach s on s.MaSach = cthdn.MaSach
	where YEAR(NgayNhap) = @year
	return @soTien
end

select dbo.cau1Fun(2014)


--2. Tạo hàm đưa ra danh sách 5 đầu sách bán chạy nhất trong tháng nào đó (tháng là tham số 
--đầu vào)
go
create or alter function cau5Fun (@month int)
returns table
as
	return(
		select top(5) with ties s.MaSach, s.TacGia, s.TenSach, COUNT(cthdb.MaSach) as SDS
		from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
			join tSach s on s.MaSach = cthdb.MaSach
		where MONTH(NgayBan) = @month
		group by s.MaSach, s.TacGia, s.TenSach
		order by SDS desc
	)

select * from cau5Fun(2)


--3. Tạo hàm đưa ra danh sách n nhân viên có doanh thu cao nhất trong một năm với n và năm 
--là tham số đầu vào
go
create or alter function cau3Fun (@n int, @year int)
returns table 
as
	return(
		select top(@n) with ties nv.MaNV, SUM(SLBan * DonGiaBan) as DT
		from tNhanVien nv join tHoaDonBan hdb on hdb.MaNV = nv.MaNV
			join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
			join tSach s on s.MaSach = cthdb.MaSach
		where YEAR(hdb.NgayBan) = @year
		group by nv.MaNV
		order by SUM(SLBan * DonGiaBan) desc
	)

select * from cau3Fun(2,2014)

--4. Tạo hàm đưa ra thông tin Nhân viên sinh nhật trong ngày là tham số nhập vào
create or alter function cau4Fun (@ngay int, @thang int)
returns table
as
	return (
		select nv.MaNV, nv.TenNV
		from tNhanVien nv
		where DAY(nv.NgaySinh) = @ngay and  month(nv.NgaySinh) = @thang
	)

select * from cau4Fun(11,9)

select * from tNhanVien


--5. Tạo hàm đưa ra danh sách tồn trong kho quá 2 năm (nhập nhưng không bán hết trong hai 
--năm)

create or alter function cau5Fun ()
returns table
as
return(
	select s.MaSach, s.TenSach
	from tSach s join tChiTietHDN cthdn on cthdn.MaSach = s.MaSach
		join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
	where (YEAR(GETDATE()) - YEAR(hdn.NgayNhap) > 2) and  s.MaSach not in
		(
			select cthdb.MaSach
			from tChiTietHDB cthdb
		)
	
)

select * from cau5Fun()




--6. Tạo hàm với đầu vào là ngày, đầu ra là thông tin các hóa đơn và trị giá của hóa đơn trong 
--ngày đó
create or alter function cau6Fun(@ngay int)
returns table
as
return(
	select hdb.SoHDB , SUM(SLBan * DonGiaBan) as DGB
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where DAY(hdb.NgayBan) = @ngay
	group by hdb.SoHDB
)

select * from cau6Fun(1)



--7. Tạo hàm có đầu vào là năm đầu ra là thống kê doanh thu theo từng tháng và cả năm (dùng 
--roll up)
--8. Tạo hàm có đầu vào là sách, đầu ra là số lượng tồn của sách
go
create or alter function cau8Fun (@maSach nvarchar(20))
returns int
as
begin
	declare @slTon int 
	select @slTon =  ISNULL(SUM(SLNhap) -  SUM(SLBan),0)
	from tSach s join tChiTietHDB cthdb on cthdb.MaSach = s.MaSach
	join tChiTietHDN cthdn on cthdb.MaSach = cthdn.SoHDN
	where s.MaSach = @maSach
	return @slTon
end

select dbo.cau8Fun(N'S01')


--9. Tạo hàm có đầu vào là mã loại, đầu ra là thông tin sách, số lượng sách nhập, số lượng sách 
--bán của mỗi sách thuộc mã loại đó
create or alter function cau9Fun (@MaLoai nvarchar(20))
returns table
as
	return(
		select s.MaSach, s.TenSach, SUM(SLNhap) as SLN , SUM(SLBan) as SLB
		from tSach s join tChiTietHDN cthdn on cthdn.MaSach = s.MaSach
			join tChiTietHDB cthdb on cthdb.MaSach = cthdb.MaSach
		where s.MaTheLoai = @MaLoai
		group by s.MaSach, s.TenSach
	)

select * from cau9Fun(N'TL01')

--Trigger


--1. Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, tạo trigger cập nhật tự động 
--cho trường này biết ThanhTien=SLBan*DonGiaBan

alter table tChitietHDB
add ThanhTien money
go
create or alter trigger Cau1Triger on tChitietHDB for insert, update , delete
as
begin
	declare @inSoHDB nvarchar(20), @deSoHDB nvarchar(20), @inSlBan int , @deSlBan int, @inMaSach nvarchar(20),@deMaSach nvarchar(20), @inthanhTien money , @dethanhTien money


	select @inSoHDB = inserted.SoHDB, @inSlBan = inserted.SLBan, @inMaSach = MaSach
	from inserted

	select @deSoHDB = deleted.SoHDB, @deSlBan = deleted.SLBan, @deMaSach = MaSach
	from deleted

	select @inthanhTien = (DonGiaBan * @inSlBan)
	from tSach 
	where MaSach = @inMaSach

	select @dethanhTien = (DonGiaBan * @deSlBan)
	from tSach 
	where MaSach = @deMaSach
	
	update tChiTietHDB 
	set ThanhTien = ISNULL(ThanhTien,0) + ISNULL(@inthanhTien,0) - ISNULL(@dethanhTien,0)
	where SoHDB = ISNULL(@inSoHDB,@deSoHDB) and MaSach = ISNULL(@inMaSach,@deMaSach)
end

select * from tChiTietHDB

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB12','S01',3)


--2. Thêm trường đơn giá (DonGia) cho bảng chi tiết hóa đơn bán, cập nhật dữ liệu cho trường 
--này mỗi khi thêm, sửa bản ghi vào bảng chi tiết hóa đơn bán.
alter table tChiTietHDB
add DonGia money

go
create or alter trigger cau2trigger on tChiTietHDB for insert, update
as
begin
	declare @inSoHDB nvarchar(20), @deSoHDB nvarchar(20), @inMaSach nvarchar(20),@deMaSach nvarchar(20), @inDonGia money, @deDonGia money
	select @inSoHDB = SoHDB , @inMaSach = MaSach
	from inserted

	select @inDonGia = DonGiaBan
	from tSach
	where tSach.MaSach = @inMaSach

	select @deSoHDB = SoHDB , @deMaSach = MaSach
	from deleted

	select @deDonGia = DonGiaBan
	from tSach
	where tSach.MaSach = @deMaSach


	update tChiTietHDB
	set DonGia = ISNULL(DonGia,0) + ISNULL(@inDonGia,0) - ISNULL(@deDonGia,0)
	where SoHDB = ISNULL(@inSoHDB,@deSoHDB) and MaSach = ISNULL(@inMaSach, @deMaSach)
end

select * from tChiTietHDB
select * from tSach

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB12','S02',3)




--3. Thêm trường tổng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi 
--khi thêm hóa đơn
alter table tKhachHang
add TongHoaDon int
go
create or alter trigger cau3Trigger on tHoaDonBan for insert, delete, update
as
begin
	declare @inMaKh nvarchar(20) , @deMaKh nvarchar(20), @inSl int , @deSl int
	select @inMaKh = MaKH, @inSl = 1
	from inserted

	select @deMaKh = MaKH, @deSl = 1
	from deleted

	update tKhachHang
	set TongHoaDon = isnull(TongHoaDon,0) + ISNULL(@inSl,0) - ISNULL(@deSl,0)
	where MaKH = isnull(@inMaKh,@deMaKh)

end

select * from tKhachHang
select * from tHoaDonBan
insert into tHoaDonBan(SoHDB,MaNV,MaKH) values('HDB14','NV02','KH03')
delete from tHoaDonBan
where SoHDB = 'HDB14'

--4. Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi 
--thêm, xóa, sửa chi tiết hóa đơn

alter table tHoaDonBan
add SoSP int
go
create or alter trigger cau4trigger on tChitietHDB for insert , delete, update
as
begin
	declare @inSoHDB nvarchar(20), @inSl int, @deSoHDB nvarchar(20), @deSl int

	select @inSoHDB = SoHDB , @inSl = SLBan
	from inserted

	select @deSoHDB = SoHDB , @deSl = SLBan
	from deleted


	update tHoaDonBan
	set SoSP = ISNULL(SoSP,0) + ISNULL(@inSl,0) - ISNULL(@deSl,0)
	where SoHDB = ISNULL(@inSoHDB,@deSoHDB)

end


select * from tHoaDonBan
select * from tChiTietHDB


insert into tHoaDonBan(SoHDB,MaNV,MaKH) values('HDB14','NV02','KH03')

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB13','S05',3)
update tChiTietHDB
set SLBan = 5
where SoHDB = 'HDB13' and MaSach = 'S05'
delete from tChiTietHDB
where SoHDB = 'HDB13' and MaSach = 'S05'



--5. Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, 
--xóa, sửa chi tiết hóa đơn
alter table tHoaDonBan
add TongTien money
go
create or alter trigger cau5trigger on tChitietHDB for insert , delete, update
as
begin
	declare @inSoHDB nvarchar(20), @inMaSach nvarchar(20),@deMaSach nvarchar(20), @inSl int, @deSoHDB nvarchar(20), @deSl int, @TT1 money,@TT2 money

	select @inSoHDB = SoHDB , @inSl = SLBan, @inMaSach = MaSach
	from inserted

	select @TT1 = @inSl * DonGiaBan
	from tSach 
	where MaSach = @inMaSach



	select @deSoHDB = SoHDB , @deSl = SLBan, @deMaSach = MaSach
	from deleted


	select @TT2 = @deSl * DonGiaBan
	from tSach 
	where MaSach = @deMaSach

	update tHoaDonBan
	set TongTien = ISNULL(TongTien,0) + ISNULL(@TT1,0) - ISNULL(@TT2,0)
	where SoHDB = ISNULL(@inSoHDB,@deSoHDB)

end
select * from tHoaDonBan
select * from tChiTietHDB


insert into tHoaDonBan(SoHDB,MaNV,MaKH) values('HDB14','NV02','KH03')

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB13','S05',3)
update tChiTietHDB
set SLBan = 5
where SoHDB = 'HDB13' and MaSach = 'S05'
delete from tChiTietHDB
where SoHDB = 'HDB13' and MaSach = 'S05'




--6. Số lượng trong bảng Sách là số lượng tồn kho, cập nhật tự động dữ liệu cho trường này
--mỗi khi nhập hay bán sách

go
create or alter trigger cau6Trigger on tChiTietHDN for insert , delete, update
as
begin
	declare @inSach nvarchar(20), @inSLNhap int, @deSach nvarchar(20), @deSLNhap int

	select @inSach = MaSach ,  @inSLNhap =SLNhap
	from inserted

	select @deSach = MaSach ,  @deSLNhap =SLNhap
	from deleted

	update tSach
	set SoLuong = ISNULL(SoLuong,0) + ISNULL(@inSLNhap,0) - ISNULL(@deSLNhap,0)
	where MaSach = ISNULL(@inSach ,@deSach)

end

select * from tSach
select * from tChiTietHDN
select * from tHoaDonNhap



insert into tChiTietHDN(SoHDN,MaSach,SLNhap) values('HDN05','S05',3)
delete from tChiTietHDN
where SoHDN = 'HDN05' and MaSach = N'S05'


--7. Thêm trường Tổng tiền tiêu dùng cho bảng khách hàng, cập nhật thông tin cho trường này.
alter table tKhachHang
add TongTien money
create or alter trigger cau7trigger on tChiTietHDB for insert , delete, update
as
begin
	declare @inSoHDB nvarchar(20) , @deSoHDB nvarchar(20),@inMaKH nvarchar(20),@deMaKH nvarchar(20), @inTT money  , @deTT money  

	select @inSoHDB = SoHDB , @inTT = (SLBan * s.DonGiaBan)
	from inserted join tSach s on s.MaSach = inserted.MaSach

	select @deSoHDB = SoHDB , @deTT = (SLBan * s.DonGiaBan)
	from deleted join tSach s on s.MaSach = deleted.MaSach

	select @inMaKH = MaKH
	from tHoaDonBan
	where SoHDB = @inSoHDB

	select @deMaKH = MaKH
	from tHoaDonBan
	where SoHDB = @deSoHDB

	update tKhachHang
	set TongTien = ISNULL(TongTien,0) + ISNULL(@inTT,0) - ISNULL(@deTT,0)
	where MaKH = isnull(@inMaKH,@deMaKH)

end
select * from tHoaDonBan
select * from tChiTietHDB
select * from tKhachHang


insert into tHoaDonBan(SoHDB,MaNV,MaKH) values('HDB14','NV02','KH03')

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB14','S01',3)
update tChiTietHDB
set SLBan = 5
where SoHDB = 'HDB14' and MaSach = 'S01'

delete from tChiTietHDB
where SoHDB = 'HDB14' and MaSach = 'S01'

--8. Thêm trường Số đầu sách cho bảng nhà cung cấp, cập nhật tự động số đầu sách nhà cung 
--cấp cung cấp cho cửa hàng 
alter table tNhaCungCap
add SoDS int

create or alter trigger cau8Trigger on tChiTietHDN for insert , update, delete
as
begin
	declare @inMaNCC nvarchar(20), @inSL int,@deSL int,@deMaNCC nvarchar(20)

	select @inMaNCC = MaNCC , @inSL = 1
	from inserted join tHoaDonNhap hdn on hdn.SoHDN = inserted.SoHDN

	select @deMaNCC = MaNCC , @deSL = 1
	from deleted join tHoaDonNhap hdn on hdn.SoHDN = deleted.SoHDN

	update tNhaCungCap 
	set SoDS = ISNULL(SoDS,0) + ISNULL(@inSL,0) - ISNULL(@deSL,0)
	where MaNCC = ISNULL(@inMaNCC, @deMaNCC)

end
select * from tNhaCungCap
select * from tChiTietHDN
select * from tHoaDonNhap



insert into tChiTietHDN(SoHDN,MaSach,SLNhap) values('HDN05','S05',3)
delete from tChiTietHDN
where SoHDN = 'HDN05' and MaSach = N'S05'

update tChiTietHDN
set MaSach = N'S03'
where SoHDN = 'HDN05' and MaSach = N'S05'


--9. Thêm trường Số lượng sách và Tổng tiền hàng vào bảng nhà cung cấp, cập nhật dữ liệu 
--cho trường này mỗi khi nhập hàng
alter table tNhaCungCap
add SLSach int, TT money

create or alter trigger cau9Trigger on tChiTietHDN for insert , update, delete
as
begin
	declare @inMaNCC nvarchar(20), @inSL int,@deSL int,@deMaNCC nvarchar(20), @TT1 money,@TT2 money

	select @inMaNCC = MaNCC , @inSL = SLNhap, @TT1 = SLNhap * tSach.DonGiaNhap
	from inserted join tHoaDonNhap hdn on hdn.SoHDN = inserted.SoHDN
		join tSach on tSach.MaSach = inserted.MaSach

	select @deMaNCC = MaNCC , @deSL = SLNhap,  @TT2 = SLNhap * tSach.DonGiaNhap
	from deleted join tHoaDonNhap hdn on hdn.SoHDN = deleted.SoHDN
	join tSach on tSach.MaSach = deleted.MaSach

	update tNhaCungCap 
	set SLSach = ISNULL(SLSach,0) + ISNULL(@inSL,0) - ISNULL(@deSL,0),
	TT = ISNULL(TT,0) + ISNULL(@TT1,0) - ISNULL(@TT2,0)

	where MaNCC = ISNULL(@inMaNCC, @deMaNCC)

end
select * from tNhaCungCap
select * from tChiTietHDN
select * from tHoaDonNhap



insert into tChiTietHDN(SoHDN,MaSach,SLNhap) values('HDN08','S04',2)
insert into tHoaDonNhap(SoHDN,MaNCC) values('HDN08','NCC04')

delete from tChiTietHDN
where SoHDN = 'HDN08' and MaSach = N'S04'

update tChiTietHDN
set SLNhap = 4
where SoHDN = 'HDN08' and MaSach = N'S04'


