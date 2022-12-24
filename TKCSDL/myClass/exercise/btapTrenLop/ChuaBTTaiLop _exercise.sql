
--view




--4. Tạo view thống kê số lượng sách bán ra trong năm 2014 và số lượng sách nhập trong năm 2014 và chênh lệch giữa hai số lượng này ứng với mỗi đầu sách
select s.MaSach, s.TenSach, ISNULL(BangSLB.SLB,0) as SLSachBan, ISNULL(SLN,0) as SLSachNhap, isnull(SLN,0)-isnull(SLB,0) as SLChenh
from tSach s left join (
	select MaSach, SUM(cthdb.SLBan) as SLB
	from tChiTietHDB cthdb join tHoaDonBan  hdb on hdb.SoHDB = cthdb.SoHDB
	where year(hdb.NgayBan) = 2014
	group by MaSach)BangSLB on BangSLB.MaSach = s.MaSach
	full outer join
	(select MaSach, SUM(cthdn.SLNhap) as SLN
	from tChiTietHDN cthdn join tHoaDonNhap  hdn on hdn.SoHDN = cthdn.SoHDN
	where year(hdn.NgayNhap) = 2014
	group by cthdn.MaSach)BangSLN on BangSLB.MaSach = BangSLN.MaSach
where SLB > 0 or SLN > 0

--5.Tạo view đưa ra những thông tin hóa đơn và tổng tiền của hóa đơn đó trong ngày 16/11/2021
go
create view cau5View
as
select hdb.SoHDB , SUM(SLBan * s.DonGiaBan) as TT
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where DAY(hdb.NgayBan) = 12 and month(hdb.NgayBan) = 11 and year(hdb.NgayBan) = 2013
group by hdb.SoHDB


--6. Tạo view đưa ra doanh thu bán hàng của từng tháng trong năm 2014, những tháng không có doanh thu thì ghi là 0.
create view DoanhThuBanHang2014
as
select 
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=1,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang1,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=2,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang2,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=3,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang3,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=4,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang4,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=5,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang5,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=6,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang6,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=7,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang7,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=8,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang8,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=9,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang9,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=10,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang10,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=11,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0) as Thang11,
ISNULL(   SUM(    iif(MONTH(hdb.NgayBan)=12,(cthdb.SLBan * s.DonGiaBan),0)   )  ,0)  as Thang12,
ISNULL(SUM(cthdb.SLBan * s.DonGiaBan),0) as CaNam
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(hdb.NgayBan) = 2014

select * from tHoaDonBan

----Tìm số hóa đơn đã mua tất cả các sách của NXB Giáo Dục.
select cthdb.SoHDB
from tChiTietHDB cthdb join tSach s on s.MaSach = cthdb.MaSach
	join tNhaXuatBan nxb on nxb.MaNXB = s.MaNXB
where TenNXB = N'NXB Giáo Dục' 
group by cthdb.SoHDB
having COUNT(distinct cthdb.MaSach) = 
(
select COUNT(distinct MaSach)
from tSach s join tNhaXuatBan nxb on nxb.MaNXB = s.MaNXB
where TenNXB = N'NXB Giáo Dục'
)


--46. Đưa ra thông tin toàn bộ sách, nếu sách được bán trong năm 2014 thì đưa ra SL bán
select s.MaSach, s.TenSach , s.TacGia, ISNULL(BangSL.SLB,0)
from tSach s left join 
(
select cthdb.MaSach ,  SUM(cthdb.SLBan) as SLB
from tChiTietHDB cthdb join tHoaDonBan hdb on hdb.SoHDB= cthdb.SoHDB
where YEAR(hdb.NgayBan) = 2014
group by cthdb.MaSach
)BangSL
on BangSL.MaSach = s.MaSach



--4.	Tạo View danh sách Nhân viên xuất sắc của năm 2014 bao gồm các nhân viên có tổng số hóa đơn nhập và bán là cao nhất trong tháng đó
create view NVXuatSac
as
select *
from tNhanVien nv
left join(
select hdb.MaNV, SUM(SLBan) as TongBan
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
where YEAR(hdb.NgayBan) = 2014
group by hdb.MaNV)BangBanCuaSV
on BangBanCuaSV.MaNV = nv.MaNV














--trigger:
--Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, tạo trigger cập nhật tự động cho trường này biết ThanhTien=SLBan*DonGiaBan
alter table tChitietHDB
add ThanhTien money
go
create or alter trigger ThanhTienChoCTHDB on tChitietHDB for insert, update 
as
begin
	declare @soHDB nvarchar(20) ,@TT int, @MaSach nvarchar(20)

	select @soHDB = i.SoHDB , @MaSach = i.MaSach , @TT = (i.SLBan *s.DonGiaBan)
	from inserted i join tSach s on s.MaSach = i.MaSach


	update tChiTietHDB
	set ThanhTien =  ISNULL(@TT,0)
	where tChiTietHDB.SoHDB = @soHDB and MaSach = @MaSach
end

select * from tChiTietHDB
select * from tHoaDonBan
delete from tChiTietHDB
where SoHDB = 'HDB14'
update tChiTietHDB
set SLBan = 1
where SoHDB = 'HDB14' and MaSach = 'S01'
insert into tHoaDonBan(SoHDB,MaNV,NgayBan,MaKH) values('HDB14','NV02','2014-05-03 00:00:00.000','KH01')
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB14','S05',3)


--Thêm trường đơn giá (DonGia) cho bảng chi tiết hóa đơn bán, cập nhật dữ liệu cho trường này mỗi khi thêm, sửa bản ghi vào bảng chi tiết hóa đơn bán.
alter table tChiTietHDB 
add DonGia money
create or alter trigger DonGiaChoCTHDB on tChiTietHDB 
for insert , update
as
begin
	declare  @soHDB nvarchar(20) ,@DonGia int, @MaSach nvarchar(20)
	select @soHDB = SoHDB , @DonGia =  s.DonGiaBan, @MaSach = inserted.MaSach
	from inserted join tSach s on s.MaSach = inserted.MaSach


	update tChiTietHDB
	set DonGia = isnull(@DonGia,0)
	where SoHDB = @soHDB and MaSach = @MaSach
end

select * from tChiTietHDB
select * from tHoaDonBan


select * from tSach

update tChiTietHDB
set SLBan = 1
where SoHDB = 'HDB14' and MaSach = 'S05'

insert into tHoaDonBan(SoHDB,MaNV,NgayBan,MaKH) values('HDB14','NV02','2014-05-03 00:00:00.000','KH01')
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB14','S05',3)


--cau4:Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn

alter table tHoaDonBan 
add SoSP int

create or alter trigger soSPhamHDB on tChiTietHDB 
for insert , update,delete
as
begin
	declare  @inSoHDB nvarchar(20) ,@inSL int , @deSoHDB nvarchar(20) ,@deSL int 
	select @inSoHDB = SoHDB , @inSL = SLBan from inserted
	select @deSoHDB = SoHDB , @deSL = SLBan from deleted


	update tHoaDonBan
	set SoSP = ISNULL(SoSP,0) + ISNULL(@inSL,0) - ISNULL(@deSL,0)
	where SoHDB = ISNULL(@inSoHDB,@deSoHDB) 
end

select * from tChiTietHDB
select * from tHoaDonBan


select * from tSach

update tChiTietHDB
set SLBan = 1
where SoHDB = 'HDB15' and MaSach = 'S05'

delete from tChiTietHDB
where SoHDB = 'HDB15' and MaSach = 'S04'


insert into tHoaDonBan(SoHDB,MaNV,NgayBan,MaKH) values('HDB15','NV02','2014-05-03 00:00:00.000','KH01')
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB15','S05',6)
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB15','S04',5)


--cau5.	Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn
alter table tHoaDonBan 
add TongTien money

create or alter trigger TinhTongTienHDB on tChiTietHDB 
for insert , update,delete
as
begin
	declare  @inSoHDB nvarchar(20) ,@inTT money , @deSoHDB nvarchar(20) ,@deTT money
	select @inSoHDB = SoHDB , @inTT = SLBan * DonGiaBan from inserted join tSach s on s.MaSach = inserted.MaSach
	select @deSoHDB = SoHDB , @deTT = SLBan * DonGiaBan from deleted join tSach s on s.MaSach = deleted.MaSach
	
	update tHoaDonBan
	set TongTien = ISNULL(TongTien,0) + ISNULL(@inTT,0) - ISNULL(@deTT,0)
	where SoHDB = ISNULL(@inSoHDB,@deSoHDB) 
end

select * from tChiTietHDB
select * from tHoaDonBan


select * from tSach

update tChiTietHDB
set SLBan = 1
where SoHDB = 'HDB15' and MaSach = 'S05'

delete from tChiTietHDB
where SoHDB = 'HDB15' and MaSach = 'S01'


insert into tHoaDonBan(SoHDB,MaNV,NgayBan,MaKH) values('HDB15','NV02','2014-05-03 00:00:00.000','KH01')
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB15','S01',6)
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values('HDB15','S15',5)

--cau 6: Số lượng trong bảng Sách là số lượng tồn kho, cập nhật tự động dữ liệu cho trường này mỗi khi nhập hay bán sách.
alter table tSach
add SoLuongTon int

create or alter trigger SLNhapSachtSach on tChiTietHDN for insert , update, delete
as
begin
	declare @mSach nvarchar(20), @TongNhap int,@mSach1 nvarchar(20), @TongNhap1 int
	select @mSach= i.MaSach , @TongNhap= i.SLNhap
	from inserted i 

	select @mSach1= d.MaSach , @TongNhap1= d.SLNhap
	from deleted d

	update tSach
	set SoLuongTon = ISNULL(SoLuongTon,0) + ISNULL(@TongNhap,0) - ISNULL(@TongNhap1,0)
	where MaSach = ISNULL(@mSach,@mSach1)
	
end

create or alter trigger SLBanSachtSach on tChiTietHDB for insert , update, delete
as
begin
	
	declare @mSach nvarchar(20), @TongBan int,@mSach1 nvarchar(20), @TongBan1 int
	select @mSach= i.MaSach , @TongBan= i.SLBan
	from inserted i 

	select @mSach1= d.MaSach , @TongBan1= d.SLBan
	from deleted d 

	update tSach
	set SoLuongTon = ISNULL(SoLuongTon,0) - ISNULL(@TongBan,0) - ISNULL(@TongBan1,0)
	where MaSach = ISNULL(@mSach,@mSach1)
end

begin tran t1
select MaSach, SoLuong from tSach where MaSach = 'S07' or MaSach = 'S08'

insert into tChiTietHDN
values
('HDN03', 'S04', 2, null)

delete from tChiTietHDN
where SoHDN = 'HDN03' and MaSach = 'S04'

select MaSach, SoLuong from tSach where MaSach = 'S07' or MaSach = 'S08'

insert into tChiTietHDB (SoHDB, MaSach, SLBan)
values
('HDB15', 'S04', 7)

select MaSach, SoLuong from tSach where MaSach = 'S07' or MaSach = 'S08'
rollback tran t1


select * from tChiTietHDN
select * from tChiTietHDB
select * from tSach


--17. Thêm trường tổng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn bán

alter table tKhachHang
add TongHD int

go
create trigger TongHDCuaKH on tHoaDonBan for insert,update, delete
as
begin
	declare @inmaKH nvarchar(20), @ind int ,@demaKH nvarchar(20), @ded int 
	select @inmaKH = i.MaKH, @ind = 1
	from inserted i

	select @demaKH = d.MaKH, @ded = 1
	from deleted d

	update tKhachHang
	set TongHD = ISNULL(TongHD,0) + ISNULL(@ind,0)  - ISNULL(@ded,0) 
	where MaKH = ISNULL(@inmaKH,@demaKH)
end



select * from tKhachHang
select * from tHoaDonBan

insert into tHoaDonBan values('HDB16','NV06','2014-05-10','KH01',NULL,NULL)
delete from tHoaDonBan
where SoHDB = 'HDB16'



--cau 9:thêm trường Số lượng sách và Tổng tiền hàng vào bảng nhà cung cấp, cập nhật dữ liệu  cho trường này mỗi khi nhập hàng
alter table tNhaCungCap 
add SLSach int , TT money

go
create or alter trigger SLSachVaTongTienNCC on tChiTietHDN for insert , delete , update
as
begin
	declare @inncc nvarchar(10), @dencc nvarchar(10), @inSL int, @deSL int, @inTien money, @deTien money
	select @inncc = MaNCC , @inSL = SLNhap , @inTien = (SLNhap * s.DonGiaNhap)
	from inserted i join tSach s on s.MaSach = i.MaSach
		join tHoaDonNhap hdn on hdn.SoHDN = i.SoHDN

	select @dencc = MaNCC , @deSL = SLNhap , @deTien = (SLNhap * s.DonGiaNhap)
	from deleted  join tSach s on s.MaSach = deleted.MaSach
		join tHoaDonNhap hdn on hdn.SoHDN = deleted.SoHDN

	update tNhaCungCap
	set SLSach = ISNULL(SLSach,0) + ISNULL(@inSL,0) - ISNULL(@deSL,0), TT = ISNULL(TT,0)+ ISNULL(@inTien,0) - isnull(@deTien,0)
	where MaNCC = ISNULL(@inncc,@dencc)
	
end

insert into tChiTietHDN values('HDN01','S03',20, NULL)

insert into tChiTietHDN values('HDN01','S02',10, NULL)

select * from tNhaCungCap where MaNCC='NCC01'

delete from tChiTietHDN where sohdn='HDN01' and MaSach='S02'

select * from tNhaCungCap where MaNCC='NCC01'
update tChiTietHDN set SLNhap=15 where sohdn='HDN01' and MaSach='S03'
select * from tNhaCungCap where MaNCC='NCC01'

select * from tNhaCungCap
select * from tChiTietHDN
select * from tHoaDonNhap
select * from tSach



--	Tạo trigger trên bảng thoadonban thực hiện xóa các chi tiết hóa đơn mỗi khi xóa hóa đơn

go
create trigger DeleteHDB on tHoaDonBan instead of delete
as
begin
	delete from tChiTietHDB
	where SoHDB  in (select SoHDB from deleted)

	delete from tHoaDonBan
	where SoHDB  in (select SoHDB from deleted)
end

select * from tHoaDonBan
select * from tChiTietHDB

delete from tHoaDonBan 
where SoHDB='HDB14' 

drop trigger DeleteHDB