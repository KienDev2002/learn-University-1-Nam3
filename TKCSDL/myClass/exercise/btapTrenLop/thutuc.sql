

--cau2:Tạo thủ tục có đầu vào là ngày, đầy ra là số lượng hóa đơn và số lượng tiền bán của sách trong ngày đó
create proc review2 @ngay date, @sl int output , @slTien money output 
as
begin
	select @sl = COUNT(distinct hdb.SoHDB), @slTien = SUM(cthdb.SLBan * s.DonGiaBan) 
	from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where hdb.NgayBan = @ngay

end

declare @sluong int , @soTien money
exec review2 '2014-05-14', @sluong output,@soTien output
print @sluong
print @soTien


--caau 11: tạo thủ tục có đầu vào là mã KH, năm, đầu ra là số lượng hđ đã mua và sl tiền tiêu dùng của kH
go
alter procedure review11  @MaKH nvarchar(10), @year int, @sl int output , @sTien money output
as
	
begin
	select @sl = COUNT(distinct hdb.SoHDB) , @sTien = SUM(cthdb.SLBan * s.DonGiaBan)
	from tHoaDonBan hdb
		join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
		join tSach s on s.MaSach = cthdb.MaSach
	where hdb.MaKH = @MaKH and YEAR(hdb.NgayBan) = @year
end


declare @sluong int , @soTien money
exec review11 'KH01', 2014 , @sluong output,@soTien output
print @sluong
print @soTien


--1. Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, 
--tạo trigger cập nhật tự động cho trường này biết ThanhTien=SLBan*DonGiaBan
