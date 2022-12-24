



--câu 1: tạo view đưa ra danh sách các sách đc bán trong tháng 5 năm 2014
create view cau1
as
select s.MaSach
from tHoaDonBan hdb	join tChiTietHDB cthdb on cthdb.SoHDB = hdb.SoHDB
join tSach s on s.MaSach = cthdb.MaSach
where month(hdb.NgayBan) = 5 and YEAR(hdb.NgayBan) = 2014



--câu 2:
go
create procedure cau2 @year int , @slNhap int output,  @slBan int output, @slTon int output
as
begin
	select @slNhap = cthdn.SLNhap
	from tChiTietHDN cthdn
	select @slBan = cthdb.SLBan
	from tChiTietHDB cthdb
	set @slTon = @slNhap- @slBan
end

declare @sluongNhap int , @sluongBan int, @sluongTon int
exec cau2 2014 , @sluongNhap output ,@sluongBan output,@sluongTon output
print @sluongNhap
print @sluongBan
print @sluongTon

--cau3: Tạo hàm có đầu ra thông tin nhân viên sinh nhật trong ngày là tham số nhập vào.
go
alter function cau3 (@day datetime)
returns table 
as
	return (
		select *
		from tNhanVien nv
		where nv.NgaySinh = @day
	)

select * from cau3('1990-04-04')


--câu 4: Thêm truownfgf số lượng sách và tổng tiền hàng vào bảng nhà cung cấp, cập nhật dự liệu cho trường nay mỗi khi nhập hàng (gồm cả thêm , sửa, xóa).
alter table tNhaCungCap
add SLSach int, TongTien money 

go
create trigger cau4 on tChiTietHDN for insert,update,delete 
as
begin
	declare @soHDN nvarchar(10),@soL int
	select @soHDN = SoHDN,@soL  = SLNhap  from inserted
	select @soHDN = SoHDN , @soL  = SLNhap from deleted
	update tNhaCungCap
	set SLSach = @soL
	from tHoaDonNhap join tChiTietHDN on tHoaDonNhap.SoHDN = tChiTietHDN.SoHDN
	where tHoaDonNhap.SoHDN = @soHDN
end

insert into tChiTietHDN(SoHDN, MaSach,SLNhap)
values('HDN03','S03',10)


--cau 5
