

--Câu 1: Tạo hàm có đầu vào là tên thể loại đầu ra là thông tin các sách thuộc thể loại đó.
--cú pháp: create/alter function + function_name (tham số 1, tham số 2...) 
--returns table/Kiểu dữ liệu(int)
--as 
	--return(select ... )
	--begin  end
go
create or alter function BooksInfo (@tenTL nvarchar(20)) 
returns table
as
	return(
		select MaSach,TenSach,TacGia,s.MaTheLoai,MaNXB,DonGiaBan,DonGiaNhap,SoLuong,SoTrang,TrongLuong,Anh
		from tTheLoai tl join tSach s on s.MaTheLoai = tl.MaTheLoai
		where tl.TenTheLoai = @tenTL
	)

select * from BooksInfo(N'Bí quyết Cuộc sống')


--Câu 2: Tạo thủ tục có đầu vào là mã nhà xuất bản, đầu ra là số lượng đầu sách, số lượng tiền nhập hàng mà cửa hàng đã nhập của nhà xuất bản đó.
/*
	cú pháp: create/alter procedure + procedure_name + tham số đầu vào1 + tham số đầu vào 2... + đầu ra 1, đầu ra 2
	as
	begin
		...
	end
*/
go
create or alter procedure NumberOfBooks @MaNXB nvarchar(20), @slSach int output , @slTien money output
as
begin 
	select @slSach = COUNT(distinct s.MaSach) , @slTien = SUM(hdn.SLNhap * s.DonGiaNhap) 
	from tSach s join tChiTietHDN hdn on hdn.MaSach = s.MaSach
	where s.MaNXB = @MaNXB
end

declare @soLuongSach int , @soLuongTien money
exec NumberOfBooks 'NXB06', @soLuongSach output , @soLuongTien output
print @soLuongSach
print @soLuongTien


--Câu 3: Tạo view đưa ra thông tin các nhà cung cấp và thông tin hóa đơn nhập, trị giá hóa đơn cửa hàng đã nhập trong năm 2014
/*
	cú pháp: create/alter + view + view_name as select ...
*/
go
create or alter view NCCInfo 
as
select ncc.MaNCC , ncc.TenNCC , hdn.SoHDN , hdn.NgayNhap , hdn.MaNV , SUM(cthdn.SLNhap * s.DonGiaNhap) as TriGia
from tHoaDonNhap hdn join tChiTietHDN cthdn on cthdn.SoHDN = hdn.SoHDN
	join tNhaCungCap ncc on ncc.MaNCC = hdn.MaNCC
	join tSach s on s.MaSach = cthdn.MaSach
where YEAR(hdn.NgayNhap) = 2014
group by ncc.MaNCC , ncc.TenNCC,hdn.SoHDN , hdn.NgayNhap , hdn.MaNV


--Câu 4: Thêm trường Tổng số đầu sách vào bảng tNhaXuatBan, cập nhật tự động cho trường này mỗi khi thêm, sửa, xóa một cuốn sách
/*
	cú pháp: create/alter + trigger + trigger_name + on + table_name  + for + delete, update, insert
*/
alter table tNhaXuatBan
add TongSoDauSach int

go
create or alter trigger Cau4HD3 on tsach for insert, update, delete as
begin
	update tNhaXuatBan 
	set TongSoDauSach = isnull(TongSoDauSach, 0) + 1 
	from inserted 
	where inserted.MaNXB = tNhaXuatBan.MaNXB

	update tNhaXuatBan 
	set TongSoDauSach = isnull(TongSoDauSach, 0) - 1 
	from deleted 
	where deleted.MaNXB = tNhaXuatBan.MaNXB
end

/*
go
create or alter trigger TotalBooks on tSach for insert,delete,update
as
begin
	declare @inMaNXB nvarchar(20) , @inSL int,@deMaNXB nvarchar(20) , @deSL int, @MaNXB nvarchar(20)

	select @inMaNXB = MaNXB, @inSL = 1
	from inserted 

	select @deMaNXB = MaNXB, @deSL = 1
	from deleted 

	if @inMaNXB is null
		set @MaNXB = @deMaNXB
	else
		set @MaNXB = @inMaNXB

	if (@inMaNXB is not null ) and (@deMaNXB is not null)
		begin 
			update tNhaXuatBan
			set TongSoDauSach = ISNULL(TongSoDauSach,0) + ISNULL(@inSL,0) 
			where MaNXB = @inMaNXB

			update tNhaXuatBan
			set TongSoDauSach = ISNULL(TongSoDauSach,0) - ISNULL(@deSL,0) 
			where MaNXB = @deMaNXB
		end
	else
		begin
			update tNhaXuatBan
			set TongSoDauSach = ISNULL(TongSoDauSach,0) + ISNULL(@inSL,0) - ISNULL(@deSL,0)
			where MaNXB = @MaNXB
		end
end
*/

select * from tNhaXuatBan
select * from tSach

insert into tSach(MaSach,TenSach,TacGia,MaTheLoai,MaNXB,DonGiaNhap,DonGiaBan,SoLuong,SoTrang,TrongLuong)
values('S21',N'Khéo ăn nói sẽ có được thiên hạ',N'abc','TL02',N'NXB01',100000,200000,23,487,N'740 gram')

update tSach
set MaNXB = N'NXB02'
where MaSach = 'S21' 

delete from tSach
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

exec sp_addlogin TranThanhPhong,123
exec sp_adduser TranThanhPhong,userTranThanhPhong1
grant select,update on tSach to userTranThanhPhong1 with grant option

exec sp_addlogin PhamVanNam,123
exec sp_adduser PhamVanNam, userPhamVanNam1




--Câu 6: Tạo thủ tục thống kê số lượng hóa đơn mà không tồn tại chi tiết hóa đơn, đồng thời xóa những bản ghi mồ côi này
/*
	cú pháp: create/alter procedure + procedure_name + tham số đầu vào1 + tham số đầu vào 2... + đầu ra 1, đầu ra 2
	as
	begin
		...
	end
*/
go
create or alter procedure NumberOfBill  @slHoaDon int output 
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
print N'Số lượng hóa đơn mà không tồn tại chi tiết hóa đơn là : ' +  convert(nvarchar(20),@soLuongHoaDon)

select * from tHoaDonBan
select * from tChiTietHDB

insert into tHoaDonBan (SoHDB,MaNV,NgayBan)
values('HDB15','NV02','2013-01-01 00:00:00.000')

