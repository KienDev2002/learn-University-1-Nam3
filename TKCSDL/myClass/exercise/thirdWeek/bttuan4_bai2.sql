

--1. Tạo hàm với đầu vào là năm, đầu ra là danh sách nhân viên sinh vào năm đó
go
create function cau1 (@nam int)
returns table
as
	return(
		select * from tNhanVien nv
		where YEAR(nv.NTNS) = @nam
	)

select * from cau1(1968)


--2. Tạo hàm với đầu vào là số thâm niên (số năm làm việc) đầu ra là danh sách nhân viên có thâm niên đó
go
create function cau2(@SoNamLV int)
returns table
as
	return(
		select *
		from tNhanVien nv
		where @SoNamLV = datediff(year,nv.NgayBD,getdate())
	)

select * from cau2(26)

--3. Tạo hàm đầu vào là chức vụ đầu ra là những nhân viên cùng chức vụ đó
go
create function cau3(@ChucVuNV nvarchar(10))
returns table
as
	return(
		select nv.MaNV, nv.HO + ' ' + nv.TEN as 'Họ và tên', nv.PHAI , ctnv.ChucVu , nv.NgayBD 
		from tNhanVien nv join tChiTietNhanVien ctnv on ctnv.MaNV = nv.MaNV
		where ctnv.ChucVu = @ChucVuNV
	)

select * from cau3(N'PGD')

--4. Tạo hàm đưa ra thông tin về nhân viên được tăng lương của ngày hôm nay (giả sử 3 năm lên lương 1 lần)  
go
create function cau4() 
returns table
as
	return(
		select * 
		from tNhanVien nv 
		where day(nv.NgayBD) = day(GETDATE()) and month(nv.NgayBD) = month(GETDATE()) and DATEDIFF(YEAR,GETDATE(),nv.NgayBD) %3=0
	)

select * from cau4()

--5. Tạo Hàm xây dựng bảng lương của nhân viên gồm các thông tin sau:
go
create function BangLuong()
returns table
as return
(
select BangA.MaNV, BangA.TEN, Luong, BHXH, BHYT, BHTN, ThueTN, Luong-BHXH- BHYT-BHTN-ThueTN as THucNhan
from(
	select n.MaNV, TEN, 
	HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)) as Luong, 
	(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)))*0.08 as BHXH,
	(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)))*0.015 as BHYT,
	(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)))*0.01 as BHTN,
	iif(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000  > 0 , 
			HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000,0) as ThuNhap,
	(case 
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000-isnull(isnull(GTGC,0),0)*4400000 <=0 
			then 0
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=5000000 
			then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.05
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=10000000 
			then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.10-250000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=18000000 
			then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.15-750000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=32000000 
			then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.20-1650000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=52000000 
			then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.25-3250000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=80000000 
			then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.30-5850000
		else (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.35-9850000		
	end) as ThueTN
	from tNhanVien n join tChiTietNhanVien c on n.MaNV=c.MaNV) as BangA
)

select * from BangLuong()

--6. Tạo thủ tục có đầu vào là mã phòng, đầu ra là số nhân viên của phòng đó và tên trưởng phòng
go
create procedure cau6 @maPhong nvarchar(10), @soNV int output, @tenTP nvarchar(10) output
as
begin
	select @soNV = COUNT(nv.MaNV)
	from tPhongBan pb join tNhanVien nv on nv.MaPB = pb.MaPB
	where @maPhong = pb.MaPB

	select @tenTP = nv.TEN
	from tNhanVien nv
	where nv.MaNV in(
		select pb.TruongPhong
		from tPhongBan pb
		where @maPhong = pb.MaPB )
end

declare @soLuongNV int, @tenTPhong nvarchar(10)
exec cau6 N'KT' ,  @soLuongNV output , @tenTPhong output
print N'Số nhân viên của phòng KT là: ' + convert(nvarchar(10),@soLuongNV)  
print N'Tên trưởng phòng của phòng KT là: ' + convert(nvarchar(10),@tenTPhong)  

--7. Tạo thủ tục có đầu vào là mã phòng, đầu ra là số tiền lương của phòng đó
go
create procedure cau7  @maPhong nvarchar(10), @soTien money output
as
begin
	select @soTien = TienLuong
	from(
	select nv.MaPB, SUM( bl.Luong) as TienLuong
	from BangLuong() bl join tNhanVien nv on nv.MaNV = bl.MaNV
	where nv.MaPB = @maPhong
	group by nv.MaPB)tongLuong
end

declare @soTienCaPhong money
exec cau7 N'KT', @soTienCaPhong output
print N'Số tiền lương của phòng KT là: ' + convert(nvarchar(20),@soTienCaPhong)  
