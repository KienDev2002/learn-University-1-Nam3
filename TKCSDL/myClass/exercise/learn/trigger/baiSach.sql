
create trigger ThanhTien on tChiTietHDB
for insert , update as
begin
	declare @sohdb nvarchar(10), @donggia money , @thanhTien money, @masach nvarchar(10)
	select @sohdb = soHDB , @masach = masach from inserted
	select @donggia = tSach.DonGiaBan  from tSach where tSach.MaSach = @masach
	update tChiTietHDB set thanhtien = @thanhTien
end