
--4. 4.	Tạo view thống kê số lượng sách bán ra và số lượng nhập trong năm 2014

create view slSach2014
as

select A.MaSach as 'Mã sách bán', B.MaSach as 'Mã sách nhập' , sln-slb as chenhLech
from
(
select s.MaSach, sum(cthdb.SLBan) as slb
from tSach s join tChiTietHDB cthdb on cthdb.MaSach = s.MaSach
	join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
where year(hdb.NgayBan) = 2014
group by  s.MaSach) A join 
(
select s.MaSach,  sum(cthdn.SLNhap) as sln
from tSach s join tChiTietHDN cthdn on cthdn.MaSach = s.MaSach
	join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
where year(hdn.NgayNhap) = 2014
group by  s.MaSach) B
on A.MaSach = B.MaSach

--4. Tạo view thống kê số lượng sách bán ra trong năm 2014 và số lượng sách còn tồn trong nam 2014 kho ứng với mỗi đầu sách
create view cau4 as
select tsach.masach,TenSach,isnull(SLN,0) as SoLuongNhap, isnull(SLB,0) as SoLuongBan, isnull(SLN,0)-isnull(SLB,0) as SLChenh from 
 tsach left join
 (select s.MaSach, sum(SLBan) as SLB
from tSach s join tChiTietHDB ctb on ctb.MaSach=s.MaSach
 join tHoaDonBan hdb on ctb.sohdb=hdb.SoHDB where year(ngayban)=2014
group by s.MaSach,TenSach) BangSLB on tSach.MaSach=BangSLB.MaSach
 full outer join
 (select s.MaSach,sum(SLNhap) as SLN 
from tSach s join tChiTietHDN ctn on ctn.MaSach=s.MaSach
 join tHoaDonNhap hdn on ctn.SoHDN=hdn.SoHDN where year(ngaynhap)=2014
group by s.MaSach,TenSach) BangSLN
 on BangSLN.MaSach=BangSLB.MaSach
where SLN>0 or SLB>0
--5.	Tạo view đưa ra những thông tin hóa đơn và tổng tiền của hóa đơn đó trong ngày 16/11/2021
go
create view TTHoaDon
as
select hdb.SoHDB , sum(s.SoLuong * s.DonGiaBan) as TongTien
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where day(hdb.NgayBan) = 16 and MONTH(hdb.NgayBan) = 11 and YEAR(hdb.NgayBan) = 2014
group by hdb.SoHDB


--6. Tạo view đưa ra doanh thu bán hàng của từng tháng trong năm 2014, những tháng không có doanh thu thì ghi là 0.


go
create view cau6
as
select month(hdb.NgayBan) as Thang, case  when sum(s.SoLuong * s.DonGiaBan) <= 0 then '0' else sum(s.SoLuong * s.DonGiaBan) end
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where year(hdb.NgayBan) = 2014
group by month(hdb.NgayBan)

--6: của cô: create view DoanhThu2014 as
select
isnull(sum(case month(NgayBan) when 1 then (SLBan*DonGiaBan) end)  ,0 ) as Thang1,
isnull(sum(case month(NgayBan) when 2 then (SLBan*DonGiaBan) end),0) as Thang2,
isnull(sum(case month(NgayBan) when 3 then (SLBan*DonGiaBan) end),0) as Thang3,
isnull(sum(case month(NgayBan) when 4 then (SLBan*DonGiaBan) end),0) as Thang4,
isnull(sum(case month(NgayBan) when 5 then (SLBan*DonGiaBan) end),0) as Thang5,
isnull(sum(case month(NgayBan) when 6 then (SLBan*DonGiaBan) end),0) as Thang6,
isnull(sum(case month(NgayBan) when 7 then (SLBan*DonGiaBan) end),0) as Thang7,
isnull(sum(case month(NgayBan) when 8 then (SLBan*DonGiaBan) end),0) as Thang8,
isnull(sum(case month(NgayBan) when 9 then (SLBan*DonGiaBan) end),0) as Thang9,
isnull(sum(case month(NgayBan) when 10 then (SLBan*DonGiaBan) end),0) as Thang10,
isnull(sum(case month(NgayBan) when 11 then (SLBan*DonGiaBan) end),0) as Thang11,
isnull(sum(case month(NgayBan) when 12 then (SLBan*DonGiaBan) end),0) as Thang12,
isnull(sum(SLBan*DonGiaBan),0) as CaNam
from tChiTietHDB ct join tHoaDonBan hd on ct.SoHDB=hd.SoHDB join tSach s on ct.MaSach=s.MaSach
where year(NgayBan)=2014




--1.	 Tạo thủ tục có đầu vào là mã sách, đầu ra là số lượng sách đó được bán trong năm 2014
go
create procedure cau1 @MaSach nvarchar(10) , @sl int output
as
begin
	select @sl =  count(s.MaSach)
	from tSach s join tChiTietHDB cthdb on cthdb.MaSach = s.MaSach
		join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
	where year(hdb.NgayBan) = 2014
end

declare @sluong int
exec cau1 'S01' , @sluong output
print @sluong


--2.	 Tạo thủ tục có đầu vào là ngày, đầy ra là số lượng hóa đơn và số lượng tiền bán của sách trong ngày đó
go
alter procedure cau2 @Ngay datetime, @solHD int output,  @SoTien money output
as
	begin

		select @solHD = count(hdb.SoHDB), @SoTien =  sum(cthdb.SLBan * s.DonGiaBan)
		from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
			join tSach s on s.MaSach = cthdb.MaSach
		where hdb.NgayBan = @Ngay
	end


declare @soluongHD int, @SoTienBan money
exec cau2 '2014-09-01' , @soluongHD output, @SoTienBan output
print  N'Số lượng hóa đơn: ' + Convert(nvarchar(10),@soluongHD ) + N'Số lượng tiền bán: ' + Convert(nvarchar(10), @SoTienBan)


-- 3.	 Tạo thủ tục có đầu vào là mã nhà cung cấp, đầu ra là số đầu sách và số tiền cửa hàng đã nhập của nhà cung cấp đó

go
create procedure cau3  @MaNCCap nvarchar(10) , @soDS int output,  @SoTien money output
as
begin
	select @soDS = count(s.MaSach)
	from tSach s join tChiTietHDN cthdn on s.MaSach = cthdn.MaSach
		join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
		join tNhaCungCap ncc on ncc.MaNCC = hdn.MaNCC
	where ncc.MaNCC =  @MaNCCap

	select @SoTien = sum(SLNhap * DonGiaNhap)
	from tSach s join tChiTietHDN cthdn on s.MaSach = cthdn.MaSach
		join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
		join tNhaCungCap ncc on ncc.MaNCC = hdn.MaNCC
	where ncc.MaNCC =  @MaNCCap
	group by  ncc.MaNCC
end


declare  @soDauSach int, @SoTienCH money
exec cau3 'NCC01' , @soDauSach output, @SoTienCH  output
print  N'Số đầu sách: ' + Convert(nvarchar(10),@soDauSach ) + N'Số tiền cửa hàng đã nhập: ' + Convert(nvarchar(10), @SoTienCH)

--4:
alter procedure cau4 @year datetime, @sotienNhap money output, @sotienBan money output
as
begin
	select @sotienNhap = sum(cthdn.SLNhap * s.DonGiaNhap)
		from tHoaDonNhap hdn join tChiTietHDN cthdn on cthdn.SoHDN = hdn.SoHDN
		join tSach s on s.MaSach = cthdn.MaSach
	where hdn.NgayNhap = @year
	group by hdn.NgayNhap

	select @sotienBan = sum(cthdb.SLBan * s.DonGiaBan)
		from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where hdb.NgayBan = @year
	group by hdb.NgayBan
end

declare  @sotienN money , @sotienB money
exec cau4 '2014-06-30' , @sotienN output, @sotienB  output
print  N'Số tiền cửa hàng đã nhập: ' + Convert(nvarchar(10),@sotienN ) + N'Số tiền cửa hàng đã bán: ' + Convert(nvarchar(10), @sotienB)



--5



-- Hàm
--10: 
create function TongTien (@year int)
returns int
as 
begin
	declare @tt int
	select @tt =  sum(cthdn.SLNhap * ts.DonGiaNhap) 
			from tChiTietHDN cthdn join tHoaDonNhap hdn on hdn.SoHDN = cthdn.SoHDN
				join tSach ts on ts.MaSach = cthdn.MaSach
			where year(hdn.NgayNhap) = @year
			group by year(hdn.NgayNhap)
	return @tt
end

select dbo.TongTien(2014) 

--11: 
go
alter function cau11 (@month int, @year int)
returns table
as 
return(
		select  top(10) ts.MaSach , ts.TenSach
		from tSach ts join tChiTietHDB cthdb on cthdb.MaSach = ts.MaSach
			join tHoaDonBan hdb on hdb.SoHDB = cthdb.SoHDB
			where month(hdb.NgayBan) = @month and year(hdb.NgayBan) = @year
		group by ts.MaSach , ts.TenSach
		order by sum(SLBan) desc
	)

select * from cau11(4,2014)


-- 12: 
alter function cau12 (@n int , @year int)
returns table
as 
return(
		select  top(@n) nv.MaNV , nv.TenNV , sum(cthdb.SLBan * ts.DonGiaBan) as TT
		from tNhanVien nv join tHoaDonBan hdb on hdb.MaNV = nv.MaNV join
			tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
			join tSach ts on cthdb.MaSach = ts.MaSach
			where year(hdb.NgayBan) = @year
		group by nv.MaNV , nv.TenNV
		order by sum(cthdb.SLBan * ts.DonGiaBan) desc
	)

select * from cau12(4,2014)

-- 13.
create function cau13 (@day int )
returns table
as
return
	(
		select kh.MaKH , kh.TenKH
		from tKhachHang kh
		where kh.
	)


select * from cau13(13)


--14.
create function cau14()
returns table
as
return 
(
	select ts.MaSach
	from tSach ts
)