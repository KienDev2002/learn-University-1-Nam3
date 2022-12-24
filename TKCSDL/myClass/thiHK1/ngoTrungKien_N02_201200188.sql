-- đề 2201: Ngô Trung Kiên - 201200188

--cau2: 
create or alter procedure cau2pro @sdt nvarchar(20), @year int, @sl int output
as
begin 
	select COUNT(pd.MaBooking)
	from KHACHHANG kh join PHIEUDAT pd on pd.MaKH = kh.MaKH
	where kh.Dienthoai = @sdt and YEAR(NgayDenDukien) = @year
end


declare @sluong int
exec cau2pro '0987654123', 2022 , @sluong output
print @sluong

select * from KHACHHANG
select * from PHIEUDAT


--cau3
go
create or alter function cau3Fun (@day date)
returns table
as
return
	(
		select ctpd.MaBooking, pd.NgayDenDukien, pd.NgayDiDuKien , lp.Kieuphong  , ctpd.SLPhong
		from PHIEUDAT pd join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
		join LOAIPHONG lp on lp.MaLP = ctpd.MaLP
		where pd.NgayDenDukien = @day
	)

select * from cau3Fun('2022-01-09')

--cau 4
go
create or alter trigger cau4 on Phieuthue for insert, update, delete 
as
begin
	declare @inSoNgayThue int, @inMP nvarchar(20), @deSoNgayThue int, @deMP nvarchar(20)

	select @inSoNgayThue = case when Thoigiancheckin = Thoigiancheckout then 1 else DATEDIFF(DAY,Thoigiancheckin,Thoigiancheckout) end, @inMP  = Maphong
	from inserted

	select @deSoNgayThue = case when Thoigiancheckin = Thoigiancheckout then 1 else DATEDIFF(DAY,Thoigiancheckin,Thoigiancheckout) end, @deMP  = Maphong
	from deleted

	update PHONG
	set SoNgayThue = ISNULL(SoNgayThue,0) + ISNULL(@inSoNgayThue,0) - ISNULL(@deSoNgayThue,0)
	where Maphong = ISNULL(@inMP,@deMP)


end




select * from PHIEUTHUE
select * from PHONG


insert into PHIEUTHUE(MaPT,MaBooking,Thoigiancheckin,Thoigiancheckout,Maphong) 
values('PT0025','PD0001','2022-01-09 00:00:00.000','2022-01-11 00:00:00.000','P201')

delete from PHIEUTHUE
where MaPT = 'PT0025'

update PHIEUTHUE
set Thoigiancheckout = '2022-01-15 00:00:00.000'
where MaPT = 'PT0025'



--cau5
go
create or alter view cau5View 
as
select kh.MaKH, kh.TenKH, kh.Diachi, kh.Dienthoai, pd.MaBooking, pd.Tiendatcoc, ctpd.MaLP, ctpd.SLPhong
from KHACHHANG kh join PHIEUDAT pd on pd.MaKH = kh.MaKH
	join CHITIETPHONGDAT ctpd on ctpd.MaBooking =  pd.MaBooking
where pd.NgayDenDukien between '2022-12-12' and  '2022-12-19'

select * from cau5View


-- cau6

exec sp_addlogin TranHuyHiep, 123
exec sp_adduser TranHuyHiep,TranHuyHiep
grant select on cau5View to TranHuyHiep with grant option

exec sp_addlogin PhamVietTrung, 123
exec sp_adduser PhamVietTrung,PhamVietTrung



--cau7
go
create view cau7View
as
select kh.MaKH, kh.TenKH, kh.Gioitinh, SUM(SLPhong * Dongiaphong) as TTDKH
from KHACHHANG kh join PHIEUDAT pd on pd.MaKH =kh.MaKH join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking join LOAIPHONG lp on lp.MaLP = ctpd.MaLP
group by kh.MaKH, kh.TenKH,kh.Gioitinh
having SUM(SLPhong * Dongiaphong) in
(
	select distinct top(3) SUM(SLPhong * Dongiaphong) as TTDKH
	from PHIEUDAT pd join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
		join LOAIPHONG lp on lp.MaLP = ctpd.MaLP
	group by pd.MaKH
	order by TTDKH desc
)