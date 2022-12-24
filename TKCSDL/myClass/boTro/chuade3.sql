
/*
Câu 1: Tạo hàm có đầu vào là tên thể loại đầu ra là thông tin các sách thuộc thể loại
đó.

Câu 2: Tạo thủ tục có đầu vào là mã nhà xuất bản, đầu ra là số lượng đầu sách, số
lượng tiền nhập hàng mà cửa hàng đã nhập của nhà xuất bản đó.

Câu 3: Tạo view đưa ra thông tin các nhà cung cấp và thông tin hóa đơn nhập, trị giá 
hóa đơn cửa hàng đã nhập trong năm 2014

Câu 4: Thêm trường Tổng số đầu sách vào bảng tNhaXuatBan, cập nhật tự động cho 
trường này mỗi khi thêm, sửa, xóa một cuốn sách

Câu 5: Tạo login TranThanhPhong, tạo user TranThanhPhong cho TranThanhPhong 
trên CSDL QLBanSach
Phân quyền Select, update trên bảng tSach cho TranThanhPhong và TranThanhPhong 
được phép phân quyền cho người khác
Đăng nhập TranThanhPhong để kiểm tra
Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLBanSach
Đăng nhập PhamVanNam để kiểm tra
Từ login TranThanhPhong, phân quyền Select trên bảng tSach cho PhamVanNam
Đăng nhập PhamVanNam để kiểm tra

Câu 6: Tạo thủ tục thống kê số lượng hóa đơn mà không tồn tại chi tiết hóa đơn, đồng 
thời xóa những bản ghi mồ côi này
*/


--Câu 1: Tạo hàm có đầu vào là tên thể loại đầu ra là thông tin các sách thuộc thể loại đó.
/*
	cú pháp: create/alter function function_name (tham số 1, tham số 2...)
	returns 
		+ table
		+ kiểu dữ liệu(int,money...)
	as
		return(select .... )(table)
		begin 
			....
		end
*/
create or alter function BooksInfomation (@tenTL nvarchar(20))
returns table
as
	return(
		select MaSach,TenSach,TacGia,s.MaTheLoai,MaNXB, DonGiaBan,DonGiaNhap,SoLuong,SoTrang, TrongLuong,Anh
		from tSach s join tTheLoai tl on tl.MaTheLoai = s.MaTheLoai
		where tl.TenTheLoai = @tenTL
	)

select * from BooksInfo(N'Bí quyết Cuộc sống')
select * from tTheLoai



--Câu 2: Tạo thủ tục có đầu vào là mã nhà xuất bản, đầu ra là số lượng đầu sách, số lượng tiền nhập hàng mà cửa hàng đã nhập của nhà xuất bản đó.

/*
	cú pháp: create/alter procedure + procedure_name + tham số đầu vào 1 , tham số đầu vào 2,... tham số đầu ra 1,2... output
	as
	begin 
			...
	end

*/
go
create or alter procedure NumverOfBooks @maNXB nvarchar(20), @slSach int output, @slTien money output
as
begin
	select @slSach = COUNT(distinct s.MaSach) , @slTien = SUM(SLNhap * s.DonGiaNhap)
	from tSach s join tChiTietHDN cthdn on s.MaSach = cthdn.MaSach
	where MaNXB = @maNXB
end

declare @soLuongSach int, @soLuongTien money
exec NumverOfBooks 'NXB06', @soLuongSach output , @soLuongTien output
print @soLuongSach
print @soLuongTien

select * from tSach
select * from tChiTietHDN





--Câu 3: Tạo view đưa ra thông tin các nhà cung cấp và thông tin hóa đơn nhập, trị giá  hóa đơn cửa hàng đã nhập trong năm 2014
/*
	create/alter + view + view_name 
	as
	sleect ....
*/
go
create or alter view NCCInfo 
as
	select ncc.MaNCC,ncc.TenNCC, hdn.SoHDN , hdn.MaNV, hdn.NgayNhap , SUM(cthdn.SLNhap * s.DonGiaNhap) as TriGia
	from tHoaDonNhap hdn join tNhaCungCap ncc on ncc.MaNCC = hdn.MaNCC
		join tChiTietHDN cthdn on hdn.SoHDN = cthdn.SoHDN
		join tSach s on s.MaSach  = cthdn.MaSach
	where YEAR(hdn.NgayNhap) = 2014
	group by ncc.MaNCC,ncc.TenNCC, hdn.SoHDN , hdn.MaNV, hdn.NgayNhap 



--Câu 4: Thêm trường Tổng số đầu sách vào bảng tNhaXuatBan, cập nhật tự động cho trường này mỗi khi thêm, sửa, xóa một cuốn sách
/*
	cú pháp: create/alter + trigger + trigger_name + on + table_name + for insert, update, delete 
	as
	begin 
		... 
	end

	update:
		+ sửa: inserted
		+ xóa: deleted
*/
alter table tNhaXuatBan
add TongSoDauSach int 

go
create or alter trigger TotalBooks on tSach for insert, update, delete
as
begin
	update tNhaXuatBan
	set TongSoDauSach = ISNULL(TongSoDauSach,0) + 1
	from inserted
	where inserted.MaNXB = tNhaXuatBan.MaNXB
		

	update tNhaXuatBan
	set TongSoDauSach = ISNULL(TongSoDauSach,0) - 1
	from deleted
	where deleted.MaNXB = tNhaXuatBan.MaNXB
end

select * from tSach
select * from tNhaXuatBan

insert into tSach(MaSach,TenSach,TacGia,MaTheLoai,MaNXB,DonGiaNhap,DonGiaBan) 
values(N'S21', N'Khéo ăn nói sẽ có được thiên hạ', 'abc','TL02','NXB02',200000.00,108000.00)

delete from tSach
where MaSach = 'S21'

update tSach 
set MaNXB = N'NXB03'
where MaSach = 'S21'


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

/*
	cú pháp: Login: exec sp_addlogin ten_login , password
		User: exec sp_addUser ten_login , ten_User

*/
exec sp_addlogin TranThanhPhong1 , 123
exec sp_addUser TranThanhPhong1 , UserTranThanhPhong2

grant select , update on tSach to UserTranThanhPhong2 with grant option

exec sp_addlogin PhamVanNam1 , 123
exec sp_addUser PhamVanNam1 , UserPhamVanNam2



--Câu 6: Tạo thủ tục thống kê số lượng hóa đơn bán mà không tồn tại chi tiết hóa đơn bán, đồng thời xóa những bản ghi mồ côi này
/*
	cú pháp: create/alter procedure + procedure_name + tham số đầu vào 1 , tham số đầu vào 2,... tham số đầu ra 1,2... output
	as
	begin 
		...
	end
*/


go
create or alter procedure NumberOfBill @slHoaDon int output 
as
begin
	select @slHoaDon = COUNT(distinct SoHDB)
	from tHoaDonBan hdb
	where hdb.SoHDB not in (select SoHDB from tChiTietHDB)

	delete from tHoaDonBan
	where SoHDB not in (select SoHDB from tChiTietHDB)
end
declare @soLuongHoaDon int
exec NumberOfBill @soLuongHoaDon output 
print N'Số lượng hóa đơn bán mà không tồn tại chi tiết hóa đơn bán: ' +  convert(nvarchar(20),@soLuongHoaDon)






select * from tHoaDonBan
select * from tChiTietHDB
insert into tHoaDonBan(SoHDB,MaNV,NgayBan) values('HDB14','NV02','2014-05-10 00:00:00.000')
insert into tHoaDonBan(SoHDB,MaNV,NgayBan) values('HDB15','NV03','2014-05-10 00:00:00.000')

