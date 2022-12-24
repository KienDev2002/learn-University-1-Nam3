--1.	Tạo view in ra danh sách các sách của nhà xuất bản giáo dục nhập trong năm 2014
go
create view Cau1 as
select s.MaSach, TenSach
from tSach s join tChiTietHDN ctn on s.MaSach=ctn.MaSach
	join tHoaDonNhap hdn on ctn.SoHDN=hdn.SoHDN
	join tNhaXuatBan nxb on s.MaNXB=nxb.MaNXB
where year(NgayNhap)=2014 and TenNXB=N'NXB Giáo Dục'
go
select * from Cau1
--2. Tạo view thống kê các sách không bán được trong năm 2014
create view Cau2 as
select MaSach, TenSach from tSach
where MaSach not in 
(select MaSach from tChiTietHDB join tHoaDonBan on tChiTietHDB.SoHDB=tHoaDonBan.SoHDB
where year(NgayBan)=2014)
--3. Tạo view thống kê 2 khách hàng có tổng tiền tiêu dùng cao nhất trong năm 2014
create view Cau3 as
select top(2) with ties tKhachHang.MaKH, TenKH, sum(SLBan * DonGiaBan) as TongTienTieuDung
from tKhachHang join tHoaDonBan on tKhachHang.MaKH = tHoaDonBan.MaKH
				join tChiTietHDB on tChiTietHDB.SoHDB = tHoaDonBan.SoHDB
				join tSach on tSach.MaSach = tChiTietHDB.MaSach
where year(NgayBan) = 2014
group by tKhachHang.MaKH, TenKH
order by TongTienTieuDung desc

select * from Cau3

--4. Tạo view thống kê số lượng sách bán ra trong năm 2014 và số lượng sách nhập trong năm 2014 và chênh lệch giữa hai số lượng này ứng với mỗi đầu sách
create view cau4 as
select tsach.masach,TenSach,isnull(SLN,0) as SoLuongNhap, isnull(SLB,0) as SoLuongBan, isnull(SLN,0)-isnull(SLB,0) as SLChenh from 
	tsach left join
	(select MaSach, sum(SLBan) as SLB
from tChiTietHDB ctb join tHoaDonBan hdb on ctb.sohdb=hdb.SoHDB where year(ngayban)=2014
group by MaSach) BangSLB on tSach.MaSach=BangSLB.MaSach
	full outer join
	(select MaSach,sum(SLNhap) as SLN 
from tChiTietHDN ctn join tHoaDonNhap hdn on ctn.SoHDN=hdn.SoHDN where year(ngaynhap)=2014
group by MaSach) BangSLN
	on BangSLN.MaSach=BangSLB.MaSach
where SLN>0 or SLB>0
--5. Tạo view đưa ra những thông tin hóa đơn và tổng tiền của hóa đơn đó trong ngày 16/11/2021
--6.	 Tạo view đưa ra doanh thu bán hàng của từng tháng trong năm 2014, những tháng không có doanh thu thì ghi là 0.

--15. Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, tạo trigger cập nhật tự động cho trường này biết ThanhTien=SLBan*DonGiaBan
alter table tchitiethdb
add ThanhTien money

create trigger ThanhTien on tchitiethdb
for insert, update as
begin
	declare @sohdb nvarchar(10), @gia money, @masach nvarchar(10)
	select @sohdb=sohdb, @masach=MaSach from inserted
	select @gia=dongiaban from tsach where MaSach=@masach
	update tChiTietHDB set ThanhTien=SLBan*@gia where  sohdb=@sohdb and MaSach=@masach
end

--16.	Thêm trường đơn giá (DonGia) cho bảng chi tiết hóa đơn bán, cập nhật dữ liệu cho trường này mỗi khi thêm, sửa bản ghi vào bảng chi tiết hóa đơn bán.

use QLBanSach
alter table tchitiethdb
add DonGia money

create trigger ThemDonGia on tchitiethdb
for insert, update as
begin
	declare @masach nvarchar(10), @sohdb nvarchar(10), @dongia money
	select @masach=masach, @sohdb=sohdb from inserted
	select @dongia=dongiaban from tSach where masach=@masach
	update tChiTietHDB set dongia=@dongia where masach=@masach and sohdb=@sohdb
end

--17.	Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn
alter table tHoaDonBan
add SoSP int
create trigger SoLuongSP on tchitiethdb
for insert, update, delete as
begin
	declare @sohdb nvarchar(10), @sohdb1 nvarchar(10), @sohdb2 nvarchar(10), @dongia money, @SL1 int, @SL2 int
	select @sohdb1=sohdb, @SL1=SLBan from inserted
	select @sohdb2=sohdb, @SL2=SLBan from deleted
	if @sohdb1 is null 
		set @sohdb=@sohdb2
	else 
		set @sohdb=@sohdb1	
	update tHoaDonBan set SoSP=isnull(SoSP,0)+isnull(@SL1,0)- isnull(@SL2,0) where  sohdb=@sohdb
end
insert into tHoaDonBan (SoHDB, MaNV, NgayBan, MaKH) values ('HDB18', 'NV01', '2022-9-19', 'KH01')
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB18', 'S01', 3)
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB18', 'S02', 5)
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB18', 'S03', 2)
update tChiTietHDB set SLBan=2 where SoHDB='HDB18' and MaSach='S02'
delete from tChiTietHDB where SoHDB='HDB18' and MaSach='S03'
select * from tHoaDonBan where SoHDB='HDB18'
--19.	Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn

create trigger TongTien on tchitiethdb
for insert, update, delete as
begin
	declare @sohdb nvarchar(10), @sohdb1 nvarchar(10), @sohdb2 nvarchar(10), @thanhtien1 money,@thanhtien2 money
	select @sohdb1=sohdb, @thanhtien1=SLBan*DonGiaBan from inserted join tSach on inserted.MaSach=tSach.MaSach
	select @sohdb2=sohdb, @thanhtien2=SLBan*DonGiaBan from deleted join tSach on deleted.MaSach=tSach.MaSach
	if @sohdb1 is null 
		set @sohdb=@sohdb2
	else 
		set @sohdb=@sohdb1
	
	update tHoaDonBan set TongTien=isnull(TongTien,0)+isnull(@thanhtien1,0)- isnull(@thanhtien2,0) where  sohdb=@sohdb
end

insert into tHoaDonBan (SoHDB, MaNV, NgayBan, MaKH) values ('HDB16', 'NV01', '2022-9-19', 'KH01')
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB16', 'S01', 3)
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB16', 'S02', 5)
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB15', 'S03', 2)
update tChiTietHDB set SLBan=2 where SoHDB='HDB15' and MaSach='S02'
delete from tChiTietHDB where SoHDB='HDB16' and MaSach='S03'
select * from tHoaDonBan where SoHDB='HDB16'
select * from tChiTietHDB where SoHDB='HDB16'
--18.	Số lượng trong bảng Sách là số lượng tồn kho, cập nhật tự động dữ liệu cho trường này mỗi khi nhập hay bán sách

--17. Thêm trường tổng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn bán
--4.Tạo view thống kê số lượng sách bán ra trong năm 2021 và số lượng sách nhập trong năm 2021 và chênh lệch giữa hai số lượng này ứng với mỗi đầu sách
create view SachChenh as
select s.MaSach, s.TenSach, A.Masach as SachNhap, B.MaSach as SachBan, SoLuongNhap,SoLuongBan, isnull(SoLuongNhap,0)-isnull(SoLuongBan,0) as ChenhLech
from tsach s left join
(
select masach, sum(isnull(SLNhap,0)) as SoLuongNhap
from tChiTietHDN ctn join tHoaDonNhap hdn  on ctn.SoHDN=hdn.SoHDN
where year(NgayNhap)=2014
group by MaSach
)A on s.MaSach=A.MaSach
full outer join
(
select masach, sum(isnull(SLBan,0)) as SoLuongBan
from tChiTietHDB ctb join tHoaDonBan hdb  on ctb.SoHDB=hdb.SoHDB
where year(NgayBan)=2014 
group by MaSach
) B
on A.MaSach=B.MaSach
where (SoLuongNhap is not null) or (SoLuongBan is not null)


 --4. Tạo view thống kê số lượng sách bán ra trong năm 2014 và số lượng sách còn tồn trong nam 2014 kho ứng với mỗi đầu sách
create view cau4 as
select tsach.masach,TenSach,isnull(SLN,0) as SoLuongNhap, isnull(SLB,0) as SoLuongBan, isnull(SLN,0)-isnull(SLB,0) as SLChenh 
from tsach left join
 (select MaSach, sum(SLBan) as SLB
from tChiTietHDB ctb join tHoaDonBan hdb on ctb.sohdb=hdb.SoHDB where year(ngayban)=2014
group by MaSach) BangSLB 
on tSach.MaSach=BangSLB.MaSach
 full outer join
 (select MaSach,sum(SLNhap) as SLN 
from tChiTietHDN ctn join tHoaDonNhap hdn on ctn.SoHDN=hdn.SoHDN where year(ngaynhap)=2014
group by MaSach) BangSLN
 on BangSLN.MaSach=BangSLB.MaSach
where SLN>0 or SLB>0


--5.	Tạo view đưa ra những thông tin hóa đơn và tổng tiền của hóa đơn đó trong ngày 16/11/2021
--6. Tạo view đưa ra doanh thu bán hàng của từng tháng trong năm 2014, những tháng không có doanh thu thì ghi là 0.
go
create view DoanhThu2014 as
select
isnull(sum(case month(NgayBan) when 1 then (SLBan*DonGiaBan) end),0) as Thang1,
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

--Tìm số hóa đơn đã mua tất cả các sách của NXB Giáo Dục.
select SoHDB, count(ct.masach) as sosach
from tChiTietHDB ct join tSach s on ct.MaSach=s.MaSach 
join tNhaXuatBan nxb on s.MaNXB=nxb.MaNXB
where TenNXB=N'NXB Giáo Dục'
group by SoHDB
having count(ct.masach)=(select count(masach) from tSach s join tNhaXuatBan nxb on s.MaNXB=nxb.MaNXB
where TenNXB=N'NXB Giáo Dục')
--46. Đưa ra thông tin toàn bộ sách, nếu sách được bán trong năm 2014 thì đưa ra SL bán
select tsach.masach,TenSach,isnull(SLB,0) as SoLuongBan from 
 tsach left join
 (
select MaSach, sum(SLBan) as SLB
from tChiTietHDB ctb join tHoaDonBan hdb on ctb.sohdb=hdb.SoHDB 
where year(ngayban)=2014
group by MaSach) BangSLB 
on tSach.MaSach=BangSLB.MaSach

--Tạo trigger cập nhật thành tiền cho bảng chi tiết hoá đơn khi insert một lúc nhiều bản ghi
go
create trigger ThanhTien on [dbo].[tChiTietHDB]
for insert, update as
begin
update tChiTietHDB set ThanhTien=inserted.SLban*tsach.DonGiaBan 
from inserted join tSach on inserted.MaSach=tSach.MaSach join tChiTietHDB on inserted.SoHDB=tChiTietHDB.SoHDB and  inserted.MaSach=tChiTietHDB.MaSach
End


insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB01', 'S09',10),('HDB01', 'S10',10),('HDB01', 'S11',10)

--4. Tạo hàm có đầu vào là trọng tải và mã lộ trình, đầu ra là số lượng xe có trọng tải quy định lớn hơn hoặc bằng trọng tải đó và thuộc lộ trình đó.

create function Cau4Ham (@TT int, @maLT nvarchar(255))
returns int
as begin
	declare @slx int
	select @slx=count(soxe) 
	from ChiTietVanTai 
	where MaLoTrinh=@maLT and @TT<(select TrongTaiQD from TrongTai where ChiTietVanTai.MaTrongTai=TrongTai.MaTrongTai)
	return @slx
end
select * from ChiTietVanTai join TrongTai on ChiTietVanTai.MaTrongTai=TrongTai.MaTrongTai
select dbo.Cau4Ham(5, 'NT')

go
--3.	 Thêm trường số lượng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
alter table tkhachhang
add SoLuong int
---------
go
create trigger Cau3trigger on thoadonban
for insert as begin
	declare @MaKH1 nvarchar(10)
	select @MaKH1=MaKH  from inserted
	update tKhachHang set SoLuong=isnull(soluong,0)+1 where MaKH=@MaKH1
end

select * from tKhachHang where MaKH='KH01'
insert into tHoaDonBan values('HDB34','NV06','2014-05-10','KH01',NULL,NULL)
select * from tKhachHang where MaKH='KH01'
-- 4.	 Thêm trường số lượng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm, sửa, xóa hóa đơn
go
alter trigger Cau4trigger on thoadonban
for insert, update, delete
as begin
	declare @MaKH1 nvarchar(10), @MaKH2 nvarchar(10), @in int, @de int
	select @MaKH1=MaKH, @in =1 from inserted
	select @MaKH2=MaKH, @de =1 from deleted
	update tKhachHang set SoLuong=isnull(soluong,0)+isnull(@in,0)-isnull(@de,0) where MaKH=isnull(@MaKH1, @MaKH2)
	--update tKhachHang set SoLuong=isnull(soluong,0)-isnull(@de,0) where MaKH= @MaKH2
end
select * from tKhachHang where MaKH='KH01'
insert into tHoaDonBan values('HDB34','NV06','2014-05-10','KH01',NULL,NULL)
select * from tKhachHang where MaKH='KH01'
update tHoaDonBan set MaNV='NV06' where SoHDB='HDB34'
select * from tKhachHang where MaKH='KH01'
update tHoaDonBan set MaKH='KH02' where SoHDB='HDB34'
select * from tKhachHang where MaKH='KH01'
select * from tKhachHang where MaKH='KH02'

select * from tKhachHang where MaKH='KH02'
delete from tHoaDonBan where SoHDB='HDB34'
select * from tKhachHang where MaKH='KH02'

select * from tHoaDonBan where SoHDB='HDB34'

--5. Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn

create trigger Cau5trigger on tChiTietHDB
for insert, update, delete
as begin
	declare @sohdb1 nvarchar(10), @sohdb2 nvarchar(10), @in int, @de int
	select @sohdb1= SoHDB, @in = SLBan from inserted
	select @sohdb2= SoHDB, @de =SLBan from deleted
	update tHoaDonBan set SoSP=isnull(soSP,0)+isnull(@in,0) -isnull(@de,0) 
	where SoHDB = isnull(@sohdb1, @sohdb2)
end

select * from tHoaDonBan
select * from tChiTietHDB 

select * from tHoaDonBan where SoHDB = 'HDB03' 
insert into tChiTietHDB
values ('HDB03','S01',10,NULL,108000.00,NULL,NULL)
select * from tHoaDonBan where SoHDB = 'HDB03' 

delete from tChiTietHDB where SoHDB = 'HDB03' and MaSach = 'S01'
select * from tHoaDonBan where SoHDB = 'HDB03' 

update tChiTietHDB set SLBan = 20 where SoHDB = 'HDB03' and MaSach = 'S01' 
select * from tHoaDonBan where SoHDB = 'HDB03' 
--cách 2 cho insert, delete nhiều dòng
--5. Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn
go
alter trigger Cau5trigger on tChiTietHDB
for insert, update, delete
as begin
	update tHoaDonBan set SoSP=isnull(soSP,0)+ SLB
	from (select SoHDB, sum(SLBan) as SLB from inserted group by inserted.SoHDB) A
	where tHoaDonBan.SoHDB=A.SoHDB

	update tHoaDonBan set SoSP=isnull(soSP,0)- SLB
	from (select SoHDB, sum(SLBan) as SLB from deleted group by deleted.SoHDB) A
	where tHoaDonBan.SoHDB=A.SoHDB
end
select * from tChiTietHDB where SoHDB='HDB01'
delete from tChiTietHDB where SoHDB='HDB01' and MaSach like 'S1%'

insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB01', 'S16',10),('HDB01', 'S17',10),('HDB01', 'S18',10)
select * from tHoaDonBan where SoHDB = 'HDB01' 
select * from tHoaDonBan where SoHDB = 'HDB02' 


--6. Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn
alter table thoadonban 
add TongTien int

create trigger Cau6 on tChiTietHDB
for insert, update, delete as
begin
	declare @insohdb nvarchar(10), @desohdb nvarchar(10), @inTien int, @deTien int
	select @insohdb = SoHDB, @inTien = SLBan * tSach.DonGiaBan from inserted join tSach on tSach.MaSach = inserted.MaSach
	select @desohdb = SoHDB, @deTien = SLBan * tSach.DonGiaBan from deleted join tSach on tSach.MaSach = deleted.MaSach
	update tHoaDonBan 
	set TongTien=isnull(TongTien,0)+isnull(@inTien,0) -isnull(@deTien,0) 
	where SoHDB = isnull(@insohdb, @desohdb)
end



select * from tChiTietHDB
select * from tSach
--7. Số lượng trong bảng Sách là số lượng tồn kho, cập nhật tự động dữ liệu cho trường này mỗi khi nhập hay bán sách
--10.	 Thêm trường Số lượng sách và Tổng tiền hàng vào bảng nhà cung cấp, cập nhật dữ liệu cho trường này mỗi khi nhập hàng.
alter table tnhacungcap
add SLSach int
alter table tnhacungcap
alter column TongTien money
go
alter trigger Cau10 on tChiTietHDN
for insert, update, delete as
begin
	declare @inncc nvarchar(10), @dencc nvarchar(10), @inSL int, @deSL int, @inTien money, @deTien money	
	select @inncc = MaNCC, @inTien = SLNhap * tSach.DonGiaNHap, @inSL=SLNhap 
	from inserted join tSach on tSach.MaSach = inserted.MaSach join tHoaDonNhap on inserted.SoHDN=tHoaDonNhap.SoHDN


	select @dencc = MaNCC, @deTien = SLNhap * tSach.DonGiaNhap, @deSL=SLNhap 
	from deleted join tSach on tSach.MaSach = deleted.MaSach join tHoaDonNhap on deleted.SoHDN=tHoaDonNhap.SoHDN

	update tNhaCungCap set TongTien=isnull(TongTien,0)+isnull(@inTien,0), SLSach=isnull(SLSach,0)+isnull(@inSL,0) 
	where MaNCC = @inncc


	update tNhaCungCap set TongTien=isnull(TongTien,0)-isnull(@deTien,0), SLSach=isnull(SLSach,0)-isnull(@deSL,0) 
	where MaNCC = @inncc
end
select * from tNhaCungCap where MaNCC='NCC01'
insert into tChiTietHDN values('HDN01','S03',20, NULL)
select * from tNhaCungCap where MaNCC='NCC01'
insert into tChiTietHDN values('HDN01','S04',10, NULL)
select * from tNhaCungCap where MaNCC='NCC01'
delete from tChiTietHDN where sohdn='HDN01' and MaSach='S04'
select * from tNhaCungCap where MaNCC='NCC01'
update tChiTietHDN set SLNhap=15 where sohdn='HDN01' and MaSach='S03'
select * from tNhaCungCap where MaNCC='NCC01'

/*5.	Tạo login TranVietAnh, tạo user TranVietAnh cho TranVietAnh trên CSDL QLBanSach
Phân quyền Select trên view ở câu 1 cho TranVietAnh và TranVietAnh được phép phân quyền cho người khác
Đăng nhập TranVietAnh để kiểm tra
Tạo login NguyenCongHieu, tạo user NguyenCongHieu cho NguyenCongHieu trên CSDL QLBanSach
Đăng nhập NguyenCongHieu để kiểm tra
Từ login NguyenCongHieu, phân quyền Select trên view Câu 1 cho NguyenCongHieu
Đăng nhập NguyenCongHieu để kiểm tra*/

exec sp_addlogin TranVietAnh, 123
exec sp_adduser TranVietAnh, TranVietAnh
grant select on tsach to TranVietAnh with grant option
exec sp_addlogin NguyenCongHieu, 123
exec sp_adduser NguyenCongHieu, NguyenCongHieu
--2.	Tạo thủ tục có đầu vào là năm, đầu ra là số lượng sách nhập, sách bán và sách tồn của năm đó
create procedure Cau2ThiThu @nam int, @slnhap int output, @slban int output, @slton int output
as begin
	select @slnhap

end


--11.	Tạo trigger trên bảng thoadonban thực hiện xóa các chi tiết hóa đơn mỗi khi xóa hóa đơn
create trigger XoaHD on [dbo].[tHoaDonBan]
instead of delete as
begin
declare @sohdb nvarchar(10)
select @sohdb = soHDB from deleted
delete from tChiTietHDB where SoHDB = @sohdb
delete from tHoaDonBan where SoHDB = @sohdb
end
--cachs 2
create trigger XoaHD on [dbo].[tHoaDonBan]
instead of delete as
begin
delete from tChiTietHDB where SoHDB in (select SoHDB from deleted)
delete from tHoaDonBan where SoHDB in (select SoHDB from deleted)
end

create trigger ThanhTien on [dbo].[tChiTietHDB]
for insert, update as
begin
declare @sohdb nvarchar(10), @dongia money, @thanhtien money, @masach nvarchar(10)
select @sohdb=sohdb, @masach=masach from inserted
select @dongia=dongiaban from tsach where MaSach=@masach
update tChiTietHDB set ThanhTien=SLban*@dongia where  sohdb=@sohdb and MaSach=@masach
End

insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB02', 'S10',10)
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB02', 'S11',10)

select * from tChiTietHDB

insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB03', 'S12',10),('HDB03', 'S13',10),('HDB03', 'S14',10)

alter trigger ThanhTien on [dbo].[tChiTietHDB]
for insert, update as
begin
update tChiTietHDB set ThanhTien=inserted.SLban*DonGiaBan 
from inserted join tSach on inserted.MaSach=tSach.MaSach join tChiTietHDB on inserted.SoHDB=tChiTietHDB.SoHDB and  inserted.MaSach=tChiTietHDB.MaSach
End

--5.	 Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn
alter trigger CapNhatSoSP on [dbo].[tChiTietHDB]
for insert, update, delete as
begin
	declare @sohdb nvarchar(10), @sl int, @sohdb1 nvarchar(10), @sl1 int
	select @sohdb=sohdb, @sl=SLBan from inserted
	select @sohdb1=sohdb, @sl1=SLBan from deleted
	update tHoaDonBan set SoSP=isnull(SoSP,0)+isnull(@sl,0)-isnull(@sl1,0) 
	where  sohdb=isnull(@sohdb , @sohdb1)
End

insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB04','S12',10),('HDB04','S13',5),('HDB04', 'S14',2)
select *  from tChiTietHDB where SoHDB='HDB04'
select * from tHoaDonBan
delete from tChiTietHDB where SoHDB='HDB04'
update tHoaDonBan 
set SoSP=null 
where SoHDB='HDB04'

drop trigger thanhtien
alter trigger CapNhatSoSP on [dbo].[tChiTietHDB]
for insert as
begin
update tHoaDonBan set SoSP=isnull(SoSP,0)+ A.SL  
from 
(select sum(inserted.SLBan) as SL from inserted join tHoaDonBan on tHoaDonBan.SoHDB =inserted.SoHDB
group by inserted.SoHDB) A
where SoHDB in (select SoHDB from inserted)
End

use QLBanSach
alter table tchitiethdb
	add dongia money
go
alter trigger DonGia on tChiTietHDB
for insert,update as
begin
declare @gia money,@masach nvarchar(15), @sohdb nvarchar(10)
select @masach=MaSach, @sohdb=SoHDB from inserted
select @gia=tSach.DonGiaBan from tSach where MaSach=@masach
update tChiTietHDB set DonGia=@gia where MaSach=@masach and SoHDB=@sohdb
end

alter table tKhachHang add SoLuong int
alter trigger cau4Trigger on tHoaDonBan
for insert
as
begin
	declare @MaKH nvarchar(10)
	select @MaKH = MaKH from inserted
	update tKhachHang set SoLuong = isnull(SoLuong,0) + 1 where MaKH = @MaKH
end

select * from tKhachHang where MaKH ='KH04';
insert into tHoaDonBan values ('HDB29', 'NV02',	'2014-08-11 00:00:00.000','KH04' ,NULL,	NULL);
select * from tKhachHang where MaKH ='KH04';

alter table tKhachHang add SoLuong int
DROP trigger cau4Trigger
go
ALTER trigger cau4Trigger on tHoaDonBan
for insert,delete,update
as
begin
	declare @MaKH1 nvarchar(10),@MaKH2 nvarchar(10), @in int, @de int
	select @MaKH1 = MaKH, @in=1  from inserted
	select @MaKH2 = MaKH, @de=1 from deleted
	update tKhachHang set SoLuong = isnull(SoLuong,0) + isnull(@in,0) where MaKH=@MaKH1 
	update tKhachHang set SoLuong = isnull(SoLuong,0) - isnull(@de,0) where MaKH=@MaKH2
end

select * from tKhachHang where MaKH ='KH04';
insert into tHoaDonBan values ('HDB31', 'NV02',	'2014-08-11 00:00:00.000 ','KH04' ,NULL,	NULL);
select * from tKhachHang where MaKH ='KH04';

select * from tKhachHang where MaKH ='KH04';
delete from tHoaDonBan where SoHDB ='HDB31'
select * from tKhachHang where MaKH ='KH04';
select * from tKhachHang where MaKH ='KH05';


update tHoaDonBan set MaKH='KH05' where SoHDB='HDB31'

--cách 2
ALTER trigger cau4Trigger on tHoaDonBan
for insert,delete,update
as
begin
	update tKhachHang set SoLuong = isnull(SoLuong,0) + A.SL  
	from (select MaKH, count(*) as SL from inserted group by MaKH) A where tKhachHang.MaKH=A.MaKH
	update tKhachHang set SoLuong = isnull(SoLuong,0) + B.SL1  
	from (select MaKH, count(*) as SL1 from deleted group by MaKH) B where tKhachHang.MaKH=B.MaKH
end
drop function BangLuong
create function BangLuong()
returns table
as return
(
select Luong, BHXH, BHYT, BHTN, ThueTN, Luong-BHXH- BHYT-BHTN-ThueTN as THucNhan
from(
	
	select n.MaNV, TEN, 
	HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)) as Luong, 
	(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)))*0.08 as BHXH,
	(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)))*0.015 as BHYT,
	(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000)))*0.01 as BHTN,
	iif(HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000>0, HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000,0) as ThuNhap,
	(case 
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000-isnull(isnull(GTGC,0),0)*4400000 <=0 then 0
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=5000000 then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.05
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=10000000 then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.10-250000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=18000000 then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.15-750000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=32000000 then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.20-1650000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=52000000 then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.25-3250000
		when HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000 <=80000000 then (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.30-5850000
		else (HSLuong*1490000 + iif(MucDOCV like 'A%', 10000000, iif(MucDOCV like 'B%', 8000000, 5000000))-11000000-isnull(GTGC,0)*4400000)*0.35-9850000		
	end) as ThueTN
from tNhanVien n join tChiTietNhanVien c on n.MaNV=c.MaNV) as BangA
)

select * from BangLuong()
--4.	Tạo View danh sách Nhân viên xuất sắc của năm 2014 bao gồm các nhân viên có tổng số hóa đơn nhập và bán là cao nhất trong tháng đó
CREATE or alter VIEW DSNVXS
AS
WITH tTMP
AS
(
	SELECT tNhanVien.MaNV, TongHoaDon = COUNT(SoHDN) + COUNT(SoHDB)
	FROM dbo.tNhanVien FULL JOIN dbo.tHoaDonBan ON tHoaDonBan.MaNV = tNhanVien.MaNV
						FULL JOIN dbo.tHoaDonNhap ON tHoaDonNhap.MaNV = tNhanVien.MaNV
	WHERE YEAR(NgayBan) = 2014 AND YEAR(NgayNhap) = 2014
	GROUP BY tNhanVien.MaNV
)



SELECT dbo.tNhanVien.* , tTMP.TongHoaDon
FROM tTMP JOIN dbo.tNhanVien ON	tNhanVien.MaNV = tTMP.MaNV 
WHERE tTMP.TongHoaDon = (SELECT MAX(tTMP.TongHoaDon) FROM tTMP)
GO

SELECT * FROM DSNVXS

SELECT manv, count(*) as tonghdb FROM tHoaDonBan
where YEAR(NgayBan) = 2014
GROUP BY MaNV

SELECT manv,count(*) as tonghdn FROM tHoaDonNhap
where YEAR(NgayNhap) = 2014
group by MaNV

--8. Tạo view đưa ra danh sách 3 khách hàng có tiền tiêu dùng cao nhất
CREATE VIEW CAU8 AS
SELECT TOP 3 WITH TIES tKhachHang.MaKH, TenKH, 
SUM(SLBan * tSach.DonGiaBan) N'Tiền tiêu dùng'
FROM tKhachHang JOIN tHoaDonBan
ON tKhachHang.MaKH = tHoaDonBan.MaKH JOIN tChiTietHDB
ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB JOIN tSach
ON tChiTietHDB.MaSach = tSach.MaSach
GROUP BY tKhachHang.MaKH, TenKH
ORDER BY 3 DESC

SELECT * FROM Cau8

create procedure cau11 @maKH nvarchar(10), @nam int, @sl int output, @tien money output
as
begin
	select @sl = count(distinct tHoaDonBan.SoHDB), @tien = sum(SLBan*tSach.DonGiaBan)
	from tKhachHang join tHoaDonBan on tKhachHang.MaKH = tHoaDonBan.MaKH
	join tChiTietHDB on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
	join tSach on tChiTietHDB.DonGiaBan = tSach.DonGiaBan
	where year(NgayBan) = @nam and @maKH = tKhachHang.MaKH
end
declare @slhd int, @sotien money
exec cau11 'KH01',2014,@slhd output,@sotien output
print N'Số lượng hóa đơn: ' + cast(@slhd as nvarchar(10))+ N' Số tiền: ' + cast(@sotien as nvarchar(10))

--3. Thêm trường số lượng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
go
create trigger triggerCau3 on tHoaDonBan for insert as
begin
	update tKhachHang 
	set SLHoaDon = ISNULL(SLHoaDon,0) + 1
	where tKhachHang.MaKH in(select MaKH from inserted)
end

insert into tHoaDonBan(SoHDB,MaNV,NgayBan,MaKH) values('HDB37','NV06','2014-08-11','KH02')
select * from tKhachHang


--6.	 Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm một bản ghi vào chi tiết hóa đơn
alter table tHoaDonBan
add TongTien int

create or alter trigger TinhTTien on tChiTietHDB
for insert as
begin
	declare @tt int
	select @tt = sum(inserted.SLBan*tSach.DonGiaBan) from inserted join tSach on tSach.MaSach = inserted.MaSach
	update tHoaDonBan set TongTien = isnull(TongTien,0)+ @tt
	where tHoaDonBan.SoHDB in (select inserted.SoHDB from inserted)
end
insert into tHoaDonBan(SoHDB,MaNV,NgayBan,MaKH) values('HDB99','NV06','2014-08-11','KH02')
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB99', 'S01', 3)
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB99', 'S02', 5)
insert into tChiTietHDB (SoHDB, MaSach, SLBan) values ('HDB99', 'S03', 2)

select * from tHoaDonBan where tHoaDonBan.SoHDB=N'HDB99'
---Cau 7 trigger
alter table tKhachHang
add sl int null

create trigger tg_7 on	tHoaDonBan for insert, update, delete
as
begin
	update	tKhachHang
	set sl = isnull(sl, 0) + a.sl2
	from
	(
		select MaKH, count(SoHDB) as sl2
		from inserted
		group by Makh
	) a
	where tKhachHang.MaKH = a.MaKH

	update	tKhachHang
	set sl = isnull(sl, 0) - a.sl2
	from
	(
		select MaKH, count(SoHDB) as sl2
		from deleted
		group by Makh
	) a
	where tKhachHang.MaKH = a.MaKH
end
select * from tKhachHang
select * from tHoaDonBan
insert into tHoaDonBan
values ('HDB90', 'NV01', getdate(), 'KH01', null, null, null, null),
('HDB92', 'NV01', getdate(), 'KH01', null, null, null, null)


-- Cau 3:3.	 Thêm trường số lượng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
ALTER TABLE tKhachHang ADD SLHD int
ALTER TRIGGER Cau3trigger on tHoaDonBan for insert,update,delete as
begin
	DECLARE @de int,@in int,@makh1 varchar(10),@makh2 varchar(10)
	SELECT @in = 1 ,@makh1 = MaKH from inserted 
	SELECT @de = 1 ,@makh2 = MaKH from deleted 
	UPDATE tKhachHang SET SLHD = isnull(SLHD,0) + isnull(@in,0) WHERE MaKH=@makh1
	UPDATE tKhachHang SET SLHD = isnull(SLHD,0) - isnull(@de,0) WHERE MaKH=@makh2
end
SELECT * FROM tHoaDonBan
SELECT * From tKhachHang
INSERT INTO tHoaDonBan VALUES ('HDB40','NV03','2014-10-10','KH01',NULL,NULL,NULL,NULL)
UPDATE tHoaDonBan SET MaKH ='KH03' WHERE SoHDB='HDB40'
DELETE FROM tHoaDonBan WHERE SoHDB ='HDB40'

--Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm chi tiết hóa đơn
alter table tHoaDonBan add SSP int
create trigger trigger_HDB on tChiTietHDB
for insert 
as
begin
	declare @shd nvarchar(10), @sl int
	select @shd = SoHDB, @sl = SLBan from inserted
	update tHoaDonBan set SSP = isnull(SSP,0) + @sl where SoHDB = @shd
end;

select * from tHoaDonBan
insert into tChiTietHDB values ('HDB04'	,'S02'	,8,	NULL,	NULL,	NULL,	0)


-- 10.	 Số lượng trong bảng Sách là số lượng tồn kho, cập nhật tự động dữ liệu cho trường này mỗi khi nhập hay bán sách

create or alter trigger NhapSach on tChiTietHDN for insert, update, delete as
begin
	update tSach
	set SoLuongTon = isnull(SoLuongTon, 0) + isnull(TongSoLuong, 0)
	from (select MaSach, sum(SLNhap) as TongSoLuong 
		from inserted 
		group by MaSach) as tmp
	where tSach.MaSach = tmp.MaSach

	update tSach
	set SoLuongTon = isnull(SoLuongTon, 0) - isnull(TongSoLuong, 0)
	from (select MaSach, sum(SLNhap) as TongSoLuong 
		from deleted 
		group by MaSach) as tmp
	where tSach.MaSach = tmp.MaSach
end

create  or alter trigger BanSach
	on tChiTietHDB
	for insert, update, delete as
begin
	update tSach
	set SoLuongTon = isnull(SoLuongTon, 0) - isnull(TongSoLuong, 0)
	from (select MaSach, sum(SLBan) as TongSoLuong 
		from inserted 
		group by MaSach) as tmp
	where tSach.MaSach = tmp.MaSach

	update tSach
	set SoLuongTon = isnull(SoLuongTon, 0) - isnull(TongSoLuong, 0)
	from (select MaSach, sum(SLBan) as TongSoLuong 
		from deleted 
		group by MaSach) as tmp
	where tSach.MaSach = tmp.MaSach
end

begin tran t1
select MaSach, SoLuong from tSach where MaSach = 'S07' or MaSach = 'S08'

insert into tChiTietHDN
values
('HDN05', 'S07', 3, null),
('HDN05', 'S08', 2, null)

select MaSach, SoLuong from tSach where MaSach = 'S07' or MaSach = 'S08'

insert into tChiTietHDB (SoHDB, MaSach, SLBan)
values
('HDB21', 'S07', 1),
('HDB21', 'S08', 2)

select MaSach, SoLuong from tSach where MaSach = 'S07' or MaSach = 'S08'
rollback tran t1


-- Cau 6:
alter table tHoaDonBan add tongTien money

alter trigger trg_TongTien on tChiTietHDB
for insert, update, delete as
begin
	declare @soHDB_In nvarchar(50), @soHDB_De nvarchar(50)
	select @soHDB_In = soHDB from inserted
	select @soHDB_De = soHDB from deleted

	update tHoaDonBan set tongTien = isnull(tongTien, 0) + inserted.SLBan * tSach.DonGiaBan
	from inserted join tSach on inserted.MaSach = tSach.MaSach	
	where tHoaDonBan.SoHDB = @soHDB_In
	
	update tHoaDonBan set tongTien = isnull(tongTien, 0) - deleted.SLBan * tSach.DonGiaBan
	from deleted join tSach on deleted.MaSach = tSach.MaSach
	where tHoaDonBan.SoHDB = @soHDB_De
end



select * from tHoaDonBan
select * from tChiTietHDB

insert into tChiTietHDB(SoHDB, MaSach, SLBan)
values ('HDB04', 'S06', 10)
--Thêm trường số lượng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
select * from tKhachHang
alter table tKhachHang
add slhd1 int
create trigger cau33 on tHoaDonBan
for insert as begin
	declare @makh nvarchar(20)
	select @makh = inserted.MaKH from inserted
	update tKhachHang set slhd1 = ISNULL(slhd1,0)+1 
	where MaKH=@makh
end
select * from tKhachHang
INSERT into tHoaDonBan
values ('HDB102','NV02','2014-08-11 00:00:00.000','KH04','','','','','','')


-- Cau 5
-- 5.	Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi xóa chi tiết hóa đơn
alter table tHoaDonBan
add SoSanPham int
create trigger SoSanPham on dbo.tChiTietHDB
for delete as
begin
	declare @sohdb nvarchar(30), @slban int
	select @sohdb = SoHDB, @slban = SLBan from deleted
	Update tHoaDonBan set SoSanPham =  isnull(SoSanPham,0) - @slban
	where SoHDB = @sohdb
end

--5.	Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm chi tiết hóa đơn
create trigger ThemSanPham on dbo.tChiTietHDB
for insert as
begin
	declare @sohdb nvarchar(30), @slban int
	select @sohdb = SoHDB, @slban = SLBan from inserted
	Update tHoaDonBan set SoSanPham =  isnull(SoSanPham,0) + @slban
	where SoHDB = @sohdb
end

--5.	Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm sửa xóa một bản ghi của bảng chi tiết hóa đơn
go
create trigger ThemSuaXoa on dbo.tChiTietHDB
for insert as
begin
	declare @sohdbin nvarchar(30), @sohdbde nvarchar(30), @slbanthem int, @slbanxoa int 
	select @sohdbin = SoHDB, @slbanthem = SLBan from inserted
	select @sohdbde = SoHDB, @slbanxoa = SLBan from deleted
	Update tHoaDonBan set SoSanPham =  isnull(SoSanPham,0) + isnull(@slbanthem,0) -isnull(@slbanxoa,0)
	where SoHDB = isnull(@sohdbin,@sohdbde)
end

--14.	Tạo trigger trên bảng thoadonban thực hiện xóa các chi tiết hóa đơn mỗi khi xóa hóa đơn
create trigger xoahoadon on tHoaDonBan 
instead of delete as 
begin
	declare @sohoadon nvarchar(20) 
	select @sohoadon = SoHDB from deleted
	delete from tChiTietHDB where SoHDB = @sohoadon
	delete from tHoaDonBan where SoHDB = @sohoadon
end		

--Ham dua ra thong tin cua nhan vien co sinh nhat hom nay
create function SinhNhat() returns table as
return(
select MaNV, TenNV, GioiTinh, DienThoai from tNhanVien
where month(NgaySinh) = month(getdate()) and  day(NgaySinh) = day(getdate())
)


/* Cau 9 */
create function Cau9( @matheloai nvarchar(20))
returns table as
return(
	select MaSach,TenSach,Tacgia,MaNXB,dongiaban,DonGiaNhap,SoLuong,tChiTietHDB.SLBan,tChi
	from tSach inner join tTheLoai on tSach.MaTheLoai = tTheLoai.MaTheLoai inner join tChiTietHDB on tChiTietHDB.MaSach = tSach.MaSach inner join tChiTietHDN on tChiTietHDN.MaSach=tSach.MaSach


	/* Tạo thủ tục có đầu vào là mã sách, năm, đầu ra số lượng sách nhập, số lượng sách bán trong năm đó */
	GO
alter procedure Cau9 @masach nvarchar(20),@nam int,@slnhap int output,@slban int output
as begin
	
	select @slnhap = Sum(SLnhap) 
	from tChiTietHDN inner join tHoaDonNhap on tHoaDonNhap.SoHDN = tChiTietHDN.SoHDN 
	where Year(NgayNhap) = @nam and tChiTietHDN.MaSach =@masach


	select @slban = Sum(SLBan) 
	from tChiTietHDB inner join tHoaDonBan on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
	where Year(NgayBan) = @nam and tChiTietHDB.MaSach =@masach	
end 
		
declare @slnhap int ,@slban int 		
exec Cau9  N'S01',2014,@slnhap output,@slban output
print @slnhap
	print @slban
/* 11.	Tạo thủ tục có đầu vào là mã khách hàng, năm, đầu ra là số lượng hóa đơn đã mua và số lượng tiền tiêu dùng của khách hàng đó trong năm đó.*/
create procedure cau11_1 @makh nvarchar(30), @nam datetime, @slhd int output, @tongtien money output
as 
begin 
	select @slhd = count(SoHDB) 
	from tHoaDonBan 
	where MaKH = @makh and year(NgayBan) = @nam

	select @tongtien = sum(SLBan * S.DonGiaBan) 
	from tHoaDonBan as HD join tChiTietHDB as CTHD on
		HD.SoHDB = CTHD.SoHDB join tSach as S on S.MaSach = CTHD.MaSach
	where year(NgayBan) = @nam and MaKH = @makh
end

declare @quantity int, @total money 
exec cau11_1 'KH01', 2014, @quantity output, @total output
print 'so luong hoa don la: ' + cast(@quantity as nvarchar(100))
print 'Tong tien la: ' + cast(@total as nvarchar(100))