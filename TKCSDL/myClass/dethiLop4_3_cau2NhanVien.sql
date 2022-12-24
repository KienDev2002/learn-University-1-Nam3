

--cau 2
create or alter procedure cau2Pro3 @maNV nvarchar(20), @year int, @slHD int output
as
begin
	select COUNT(MaHDTT)
	from HOADONTT hdtt
	where hdtt.MaNV = @maNV and YEAR(hdtt.NgayTT) = @year
end



declare @sl int
exec cau2Pro3 'NV003' , 2022 , @sl output
print @sl

select * from NHANVIEN
select * from HOADONTT



--cau 3
go
create or alter function cau3Fun3 (@MaBook nvarchar(20))
returns table
as
	return(
		select pd.MaBooking, pd.NgayDenDukien, pd.NgayDiDuKien , lp.Kieuphong, ctpd.SLPhong
		from PHIEUDAT pd join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
			join LOAIPHONG lp on lp.MaLP = ctpd.MaLP
		where pd.MaBooking = @MaBook
	)

select * from cau3Fun3('PD0001')



--cau 4
alter table LoaiPhong
add sl int

create or alter trigger cau4Trigger3 on Phong for insert, delete, update
as
begin
	declare @inMaLP nvarchar(20), @inSL int,@deMaLP nvarchar(20), @deSL int

	select @inMaLP = MaLP, @inSL = 1
	from inserted

	select @deMaLP = MaLP, @deSL = 1
	from deleted

	update LOAIPHONG
	set sl = ISNULL(sl,0) + ISNULL(@inSL,0) - ISNULL(@deSL,0)
	where MaLP = ISNULL(@inMaLP,@deMaLP)


end


select * from PHONG
select * from LOAIPHONG

insert into PHONG(Maphong, MaLP) values('503','Standard01')

delete from PHONG
where Maphong = '503'



--cau 5
create or alter view cau5View3
as
select nv.MaNV, nv.TenNV, hdtt.MaHDTT , hdtt.NgayTT, hdtt.MaBooking, pd.NgayDenDukien, pd.Tiendatcoc, ctpd.MaLP, ctpd.SLPhong,pd.NgayDiDuKien
from NHANVIEN nv join HOADONTT hdtt on hdtt.MaNV = nv.MaNV
	join PHIEUDAT pd on pd.MaBooking = hdtt.MaBooking
	join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
where pd.NgayDenDukien = '2022-12-12' and pd.NgayDiDuKien = '2022-12-19'


--cau 6
exec sp_addlogin NguyenQuocDung, 123
exec sp_adduser NguyenQuocDung,NguyenQuocDung

grant select , insert, update on KhachHang to NguyenQuocDung with grant option
grant select , update on KhachHang to NguyenNgocHiep

exec sp_addlogin NguyenNgocHiep, 123
exec sp_adduser NguyenNgocHiep,NguyenNgocHiep


--cau7
create view cau7View3
as
select kh.MaKH, kh.TenKH, (case when NgayDenDukien = NgayDiDuKien then 1 else DATEDIFF(DAY,NgayDenDukien,NgayDiDuKien) end) as SoNgayDatP
from KHACHHANG kh join PHIEUDAT pd on pd.MaKH = kh.MaKH
	join CHITIETPHONGDAT  ctpd on ctpd.MaBooking = pd.MaBooking 
where ctpd.MaLP like N'Deluxe%' and (case when NgayDenDukien = NgayDiDuKien then 1 else DATEDIFF(DAY,NgayDenDukien,NgayDiDuKien) end)
in
(
	select distinct top(3) (case when NgayDenDukien = NgayDiDuKien then 1 else DATEDIFF(DAY,NgayDenDukien,NgayDiDuKien) end) as SoNgayDatP
	from  PHIEUDAT pd join CHITIETPHONGDAT ctpd on ctpd.MaBooking = pd.MaBooking
	where MaLP like N'Deluxe%'
	order by SoNgayDatP desc
)

select * from LOAIPHONG

