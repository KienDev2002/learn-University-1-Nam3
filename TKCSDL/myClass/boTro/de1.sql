

--Câu 1: Tạo hàm đưa ra danh sách các nhân viên có địa chỉ cho trước với địa chỉ là tham số đầu vào
go
--create/alter function + function_name (tham số 1,2,3...)
--returns: chú ý ra kiểu dữ liệu hoặc table
--as begin end nếu nó là trả về biến tức là nó sẽ nhóm các dòng code lại thành 1 block để thực thi
--còn as return ra 1 table thì nó sẽ ko cần nhóm thành 1 block kiểu là thế.
create or alter function cau1Function (@DiaChi nvarchar(20))
returns table 
as
	return(
		select * --không nên select * mà nên liệt kê các trường cụ thể
		from tNhanVien nv
		where nv.DiaChi = @DiaChi  -- có thể nói thêm nếu địa chỉ dài như có tên phường, xã thì mình dùng like N'%'+@DiaChi
	)

select * from tNhanVien
select * from cau1Function(N'Hà Nội')

--trả về 1 dữ liệu nào đó
create function cau4(@TrongTai int ,@maLoTrinh nvarchar(20) )
returns int
as
begin
	declare @SLxe int
	select @SLxe = COUNT(distinct ctvt.SoXe)
	from ChiTietVanTai ctvt join TrongTai tt on tt.MaTrongTai = ctvt.MaTrongTai
		where tt.TrongTaiQD >= @TrongTai and ctvt.MaLoTrinh = @maLoTrinh
	return @SLxe
end
select dbo.cau4(5,N'NT')


--Câu 2: Tạo thủ tục có đầu vào là tỉnh (thành phố) đầu ra là số nhân viên nam, số nhân viên nữ của tỉnh (thành phố) đó
go
--create/alter procedure + procedure_name +  tham số đầu vào,... +  đầu ra chú ý các tham số đầu ra có output và ko có trả về 1 table và có begin end để nhóm code lại thành 1 block
create or alter procedure cau2Procedure @Tinh nvarchar(20) , @SoNVNam int output, @SoNVNu int output
as
begin
	select @SoNVNam = sum(case when nv.GioiTinh = N'Nam' then 1 else 0 end),
		@SoNVNu = sum(case when nv.GioiTinh = N'Nữ' then 1 else 0 end)
	from tNhanVien nv
	where nv.DiaChi like @Tinh
end

go
create Procedure ThongKeNhanVienTheoTinh @tinh nvarchar(50), @soNvNam int output, @soNvNu int output as
begin
		select @soNvNam = sum(iif(gioiTinh like N'Nam',1,0)),
			@soNvNu = sum(iif(gioiTinh like N'Nữ',1,0))
		from tNhanVien where DiaChi like @tinh
end

select * from tNhanVien
declare @SoNam int, @SoNu int
exec cau2Procedure N'Hà Nội' , @SoNam output , @SoNu output
print N'Có ' + convert(nvarchar(10) , @SoNam) + N' sinh viên nam ở Hà Nội' 
print N'Có ' + convert(nvarchar(10) , @SoNu) + N' sinh viên nữ ở Hà Nội'

--Câu 3: Tạo view đưa ra thông tin các nhân viên và hóa đơn bán, hóa đơn nhập họ đã xử lý của các nhân viên ở HN trong năm 2014
go
--create/alter view + view_name as select ....
create or alter view cau3View 
as
select distinct nv.MaNV,nv.TenNV, 'HDB' as LoaiHD ,hdb.SoHDB as SoHD
from tNhanVien nv join tHoaDonBan hdb on hdb.MaNV = nv.MaNV
where nv.DiaChi = N'Hà Nội' and YEAR(hdb.NgayBan) = 2014 
Union --để kết hợp kết quả 2 select lại với nhau tạo thành 1 bảng 
--liệt kê những trường cần, lưu ý để union được thì ở hai truy vấn phải cùng số trường liệt kê và kiểu dữ liệu giống nhau (khả hợp)
select distinct nv.MaNV,nv.TenNV,'HDN' as LoaiHD, hdn.SoHDN as SoHD
from tNhanVien nv join tHoaDonNhap hdn on hdn.MaNV = nv.MaNV
where nv.DiaChi = N'Hà Nội' and YEAR(hdn.NgayNhap) = 2014

select * from tNhanVien




--Câu 4: Thêm trường Tổng tiền vào bảng nhân viên, cập nhật tự động cho trường này mỗi khi thêm một chi tiết hóa đơn bán
alter table tNhanVien
add TongTien money

go
--create/alter triiger + trigger_name on + table_name + for + insert,delete,... as begin ... end
create or alter trigger cau4Trigger on tChiTietHDB for insert

as
begin
	--declare + tên biến + kiểu dữ liệu của biến.
	declare @tt money, @MaNV nvarchar(10)
	select @tt = i.SLBan * s.DonGiaBan
	from inserted i join tSach s on s.MaSach = i.MaSach

	select @MaNV = hdb.MaNV from inserted i join tHoaDonBan hdb on hdb.SoHDB = i.SoHDB


	update tNhanVien 
	set TongTien = ISNULL(TongTien,0) + ISNULL(@tt,0) 
	where MaNV = @MaNV
end




create or alter trigger cau4Trigger on tChiTietHDB for insert, update, delete
--, update, delete; đề 1 chỉ cần cho phần thêm, phần update, delete em có thể nói nếu mở rộng thêm thì sẽ code như này
--phần này code lại cho chỉ insert nhé
as
begin
	--declare + tên biến + kiểu dữ liệu của biến.
	declare @tt money,@tt1 money, @MaNV nvarchar(10), @MaNV1 nvarchar(10)
	select @tt = i.SLBan * s.DonGiaBan
	from inserted i join tSach s on s.MaSach = i.MaSach

	
	select @tt1 = d.SLBan * s.DonGiaBan
	from deleted d join tSach s on s.MaSach = d.MaSach

	select @MaNV = hdb.MaNV from inserted i join tHoaDonBan hdb on hdb.SoHDB = i.SoHDB
	select @MaNV1 = hdb.MaNV from deleted d join tHoaDonBan hdb on hdb.SoHDB = d.SoHDB


	update tNhanVien 
	set TongTien = ISNULL(TongTien,0) + ISNULL(@tt,0) - ISNULL(@tt1,0)
	where MaNV = ISNULL(@MaNV, @MaNV1)
end

select * from tNhanVien
select * from tChiTietHDB
select * from tHoaDonBan
select * from tSach

delete from tChiTietHDB
where SoHDB = N'HDB19'

delete from tHoaDonBan
where SoHDB = N'HDB19'


insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB16','NV08','2014-08-11 00:00:00.000','KH02')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB16','S01',3)



/*
Câu 5: Tạo login TranThanhPhong, tạo user TranThanhPhong cho TranThanhPhong 
trên CSDL QLBanSach
Phân quyền Select, update trên bảng tSach cho TranThanhPhong và TranThanhPhong 
được phép phân quyền cho người khác
Đăng nhập TranThanhPhong để kiểm tra
Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLBanSach
Đăng nhập PhamVanNam để kiểm tra
Từ login TranThanhPhong, phân quyền Select trên bảng tSach cho PhamVanNam
Đăng nhập PhamVanNam để kiểm tra
*/
exec sp_addlogin TranThanhPhong,123
exec sp_adduser TranThanhPhong, TranThanhPhong
grant select , update on tSach to TranThanhPhong with grant option


exec sp_addlogin PhamVanNam,123
exec sp_adduser PhamVanNam, PhamVanNam


--Câu 6: Tạo view đưa ra những nhân viên có tổng tiền hóa đơn cao nhất và cao nhì trong năm 2014 
go
create or alter view viewCau6
as
select nv.MaNV, nv.TenNV ,nv.NgaySinh , nv.GioiTinh,nv.DiaChi,nv.DienThoai, SUM(SLBan * s.DonGiaBan) as TongTien 
from tNhanVien nv join tHoaDonBan hdb on nv.MaNV=hdb.MaNV
	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(hdb.NgayBan) = 2014
group by nv.MaNV, nv.TenNV ,nv.NgaySinh , nv.GioiTinh,nv.DiaChi,nv.DienThoai
having SUM(SLBan * s.DonGiaBan) in
(
select distinct top(2) SUM(SLBan * s.DonGiaBan) as TongTien 
--distinct để chỉ lấy giá trị cao nhất và cao nhì
from tHoaDonBan hdb join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(hdb.NgayBan) = 2014
group by hdb.MaNV
order by TongTien desc
)