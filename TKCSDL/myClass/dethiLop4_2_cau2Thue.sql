

--cau2
create or alter procedure cau2Pro2 @maKH nvarchar(20), @ngay date,  @sl int output
as
begin
	select @sl =  SUM(ctpd.SLPhong) 
	from PhieuDat pd join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
	where MaKH = @maKH and NgayDenDukien = @ngay
end

declare @sluong int
exec cau2Pro2 'KH0001', '2022-01-09', @sluong output
print @sluong



select * from CHITIETPHONGDAT
select * from PHIEUDAT
select * from PHIEUTHUE

--cau3
create or alter function cau3Fun2 (@MaLP nvarchar(20))
returns table
as
	return (
		select lp.MaLP, lp.Kieuphong, lp.Dientich, lp.Dongiaphong, p.Maphong
		from LOAIPHONG lp join PHONG p on p.MaLP = p.MaLP
		where lp.MaLP = @MaLP
	)


select * from cau3Fun2('Standard01')

--cau 4
alter table PhieuDat
add slPD int

create or alter trigger cau4Trigger2 on ChiTietPhongDat for insert , update, delete
as
begin
	declare @inMaBook nvarchar(20) , @inSl int,@deMaBook nvarchar(20) , @deSl int

	select @inMaBook = MaBooking , @inSl = SLPhong
	from inserted

	select @deMaBook = MaBooking , @deSl = SLPhong
	from deleted

	update PHIEUDAT
	set slPD = ISNULL(slPD,0) + ISNULL(@inSl,0) - ISNULL(@deSl,0)
	where MaBooking = ISNULL(@inMaBook,@deMaBook)
end


insert into CHITIETPHONGDAT (MaBooking, MaLP,SLPhong) values(N'PD0014',N'Suite02',5)

delete from CHITIETPHONGDAT
where MaBooking = N'PD0014'

update CHITIETPHONGDAT
set SLPhong = 6
where MaBooking= N'PD0014'

select * from CHITIETPHONGDAT
select * from PHIEUDAT


--cau 5
create view cau5View
as
select pd.MaBooking, pd.Tiendatcoc, pt.Maphong, lp.Kieuphong, pd.NgayDenDukien, pt.Thoigiancheckin, pt.Thoigiancheckout
from PHIEUDAT pd join PHIEUTHUE pt on pt.MaBooking = pd.MaBooking
	join PHONG p on p.Maphong = pt.Maphong 
	join LOAIPHONG lp on lp.MaLP = p.MaLP
where pd.NgayDenDukien between '2022-12-12' and '2022-12-19'



--cau 6
exec sp_addlogin NgoTrungKien,123
exec sp_adduser NgoTrungKien,NgoTrungKien
grant select, update on NhanVien to NgoTrungKien with grant option
grant select, update on NhanVien to NguyenXuanNgoc


exec sp_addlogin NguyenXuanNgoc,123
exec sp_adduser NguyenXuanNgoc,NguyenXuanNgoc

--cau 7

create view cau7View2
as
select distinct kh.MaKH, kh.TenKH , (case when pd.NgayDenDukien = pd.NgayDiDuKien then 1 else DATEDIFF(DAY, pd.NgayDenDukien,pd.NgayDiDuKien) end) as SND
from PHIEUDAT pd join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
	join KHACHHANG kh on kh.MaKH = pd.MaKH
where ctpd.MaLP like N'Standard%' and  (case when pd.NgayDenDukien = pd.NgayDiDuKien then 1 else DATEDIFF(DAY, pd.NgayDenDukien,pd.NgayDiDuKien) end)
	in 
(
	select distinct top(3) (case when pd.NgayDenDukien = pd.NgayDiDuKien then 1 else DATEDIFF(DAY, pd.NgayDenDukien,pd.NgayDiDuKien) end) as SoNgayDat
	from PHIEUDAT pd join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
	where ctpd.MaLP like N'Standard%'
	order by SoNgayDat desc
)


