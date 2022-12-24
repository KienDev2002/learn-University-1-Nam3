
/*
	Câu 1: Tạo hàm đưa ra danh sách các nhân viên có địa chỉ cho trước với địa chỉ là 
		tham số đầu vào.
	Câu 2: Tạo thủ tục có đầu vào là tỉnh (thành phố) đầu ra là số nhân viên nam, số nhân 
		viên nữ của tỉnh (thành phố) đó.
	Câu 3: Tạo view đưa ra thông tin các nhân viên và hóa đơn bán, hóa đơn nhập họ đã 
		xử lý của các nhân viên ở HN trong năm 2014
	Câu 4: Thêm trường Tổng tiền và bảng nhân viên, cập nhật tự động cho trường này 
		mỗi khi thêm một chi tiết hóa đơn bán
	Câu 5: Tạo login TranThanhPhong, tạo user TranThanhPhong cho TranThanhPhong 
		trên CSDL QLBanSach
		Phân quyền Select, update trên bảng tSach cho TranThanhPhong và TranThanhPhong 
		được phép phân quyền cho người khác
		Đăng nhập TranThanhPhong để kiểm tra
		Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLBanSach
		Đăng nhập PhamVanNam để kiểm tra
		Từ login TranThanhPhong, phân quyền Select trên bảng tSach cho PhamVanNam
		Đăng nhập PhamVanNam để kiểm tra
	Câu 6: Tạo view đưa ra những nhân viên có tổng tiền hóa đơn cao nhất và cao nhì 
		trong năm 2014
*/
--Câu 1: Tạo hàm đưa ra danh sách các nhân viên có địa chỉ cho trước với địa chỉ là tham số đầu vào
--cú pháp: create/alter function + function_name (tham số 1, tham số 2...) 
--returns table/Kiểu dữ liệu(int)
--as 
	--return(select ... )
	--begin  end

create or alter function cau1Function(@diachi nvarchar(20))
returns table
as
	return(
		select MaNV , TenNV , GioiTinh,NgaySinh, DiaChi
		from tNhanVien
		where DiaChi like N'%' + @diachi + '%' -- N'Trung Hòa - Cầu Giấy - Hà Nội'
	)

select * from cau1Function(N'Hà Nội')

select * from tNhanVien
--Câu 2: Tạo thủ tục có đầu vào là tỉnh (thành phố) đầu ra là số nhân viên nam, số nhân viên nữ của tỉnh (thành phố) đó.
/*
	cú pháp: create/alter procedure + procedure_name + tham số đầu vào1 + tham số đầu vào 2... + đầu ra 1, đầu ra 2
	as
	begin
		...
	end
*/
go
create or alter procedure cau2Procedure @Tinh nvarchar(30), @soNVNam int output, @soNVNu int output
as
begin
	select @soNVNam = SUM(case when GioiTinh = N'Nam' then 1 else 0 end),
		@soNVNu = SUM(case when GioiTinh = N'Nữ' then 1 else 0 end)
	from tNhanVien
	where DiaChi = @Tinh
end

declare @soNam int , @soNu int
exec cau2Procedure N'Hà Nội', @soNam output , @soNu output
print N'Số nhân viên nam là: ' +  convert(nvarchar(20),@soNam)
print N'Số nhân viên nữ là: ' +  convert(nvarchar(20),@soNam)



--Câu 3: Tạo view đưa ra thông tin các nhân viên và hóa đơn bán, hóa đơn nhập 
--họ đã xử lý của các nhân viên ở HN trong năm 2014
/*
	cú pháp: create/alter + view + view_name as select ...
*/
create or alter view cau3View 
as
--so hdb
select distinct nv.MaNV , nv.TenNV , 'HDB' as LoaiHD
from tNhanVien nv join tHoaDonBan on nv.MaNV = tHoaDonBan.MaNV
where nv.DiaChi = N'Hà Nội' and year(tHoaDonBan.NgayBan) = 2014
union
--số hdn
select distinct nv.MaNV , nv.TenNV , 'HDN' as LoaiHD
from tNhanVien nv join tHoaDonNhap on nv.MaNV = tHoaDonNhap.MaNV
where nv.DiaChi = N'Hà Nội' and year(tHoaDonNhap.NgayNhap) = 2014



--Câu 4: Thêm trường Tổng tiền vào bảng nhân viên, cập nhật tự động cho trường này mỗi khi thêm một chi tiết hóa đơn bán
alter table tNhanVien
add TongTien money

/*
	DonGiaBan * SLBan
	cú pháp: create/alter + trigger + trigger_name + on + table_name  + for + delete, update, insert
*/
go
create or alter trigger cau4Trigger on tChiTietHDB for insert
as
begin
	declare @tongTien money , @MaNV nvarchar(20)

	select @tongTien =  s.DonGiaBan * inserted.SLBan from inserted join tSach s on s.MaSach = inserted.MaSach

	select @MaNV = hdb.MaNV
	from inserted i join tHoaDonBan hdb on hdb.SoHDB = i.SoHDB

	update tNhanVien
	set TongTien = ISNULL(Tongtien,0) + ISNULL(@tongTien,0)
	where MaNV = @MaNV
end

select * from tChiTietHDB
select * from tNhanVien

insert into tHoaDonBan (SoHDB,MaNV,NgayBan,MaKH) values('HDB16','NV08','2014-02-12 00:00:00.000','KH02')
insert into tChiTietHDB (SoHDB,MaSach,SLBan) values('HDB16','S01',3)

select * from tSach


/*
	Câu 5: Tạo login TranThanhPhong, tạo user userTranThanhPhong cho TranThanhPhong 
		trên CSDL QLBanSach

		Phân quyền Select, update trên bảng tSach cho TranThanhPhong và TranThanhPhong 
		được phép phân quyền cho người khác

		Đăng nhập TranThanhPhong để kiểm tra

		Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLBanSach
		Đăng nhập PhamVanNam để kiểm tra

		Từ login TranThanhPhong, phân quyền Select trên bảng tSach cho PhamVanNam
		Đăng nhập PhamVanNam để kiểm tra
*/
/*
	cú pháp login: exec sp_addlogin + login_name + ,  +  password
	cú pháp user:  exec sp_adduser + login_name + ,  +  user_name
	cú pháp: grant [select, delete , update ] on + table_name +  to TranThanhPhong [with grant option](phân quyền đc)

*/

exec sp_addlogin TranThanhPhong,123
exec sp_adduser TranThanhPhong, userTranThanhPhong

grant select,update on tSach to userTranThanhPhong with grant option

exec sp_addlogin PhamVanNam,123
exec sp_adduser PhamVanNam, userPhamVanNam



--Câu 6: Tạo view đưa ra những nhân viên có tổng tiền hóa đơn cao nhất và cao nhì trong năm 2014
/*
	01    :     4
	02    :     3
	03    :     4
	04    :     3
	05    :     3
	06    :     2
	 4 - 4 - 3 - 3 - 3 - 2 => 4 4 3 3 3 
*/

/*
	cú pháp: create/alter + view + view_name as select ...
	tongrotien = sum(SLBan * DonGiaBan)
*/
go
create or alter view cau6View 
as 

select nv.MaNV, nv.TenNV,nv.NgaySinh, sum(cthdb.SLBan * s.DonGiaBan) as TT
from tNhanVien nv join tHoaDonBan hdb on hdb.MaNV = nv.MaNV
	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(hdb.NgayBan) = 2014
group by nv.MaNV,nv.TenNV,nv.NgaySinh
having sum(cthdb.SLBan * s.DonGiaBan) in
(
select distinct top(2) sum(cthdb.SLBan * s.DonGiaBan) as TongTien
from tNhanVien nv join tHoaDonBan hdb on hdb.MaNV = nv.MaNV 
	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
	join tSach s on s.MaSach = cthdb.MaSach
where YEAR(hdb.NgayBan) = 2014
group by nv.MaNV
order by TongTien desc)

