--1
create procedure Cau1Kt @matheloai nvarchar(50), @nam int, @tien money output, @sodausach int output
as begin
select @tien=sum(ct.slban*s.dongiaban), @sodausach=count(distinct s.masach)
from tsach s join tChiTietHDB ct on s.MaSach=ct.MaSach
		join tHoaDonBan hd on hd.SoHDB=ct.SoHDB
where year(ngayban)=@nam and s.MaTheLoai=@matheloai
end

declare @t money , @sodaus int 
exec Cau1Kt N'TL01', 2014, @t output, @sodaus output
print @t
print @sodaus



--2. Thêm trường số SLDauSach (số lượng đầu sách) vào bảng thể loại, cập nhật tự động số lượng đầu sách của thể loại đó mỗi khi nhập sách.
alter table tTheLoai
add SLDauSach int
create trigger Cau2kt on tsach
for insert, update, delete
as begin
	declare @matheloai1 nvarchar(10),  @matheloai2 nvarchar(10)
	select @matheloai1=matheloai from inserted
	update tTheLoai set SLDauSach=isnull(SLDauSach,0)+1 where MaTheLoai=@matheloai1

	select @matheloai2=matheloai from deleted
	update tTheLoai set SLDauSach=isnull(SLDauSach,0)-1 where MaTheLoai=@matheloai2
end



select * from tTheLoai
insert into tSach(MaSach, TenSach, MaTheLoai) values ('S31', N'Thép đã tôi thế đấy', N'TL01')
select * from tTheLoai


--4. Tạo hàm có đầu vào là tháng, đầu ra danh sách các ngày trong tháng đó có nhiều hóa đơn bán nhất và số lượng hóa đơn là bao nhiêu
go
create function cau4kt(@thang int, @nam int)
returns table
as return
(
	select top 1 with ties NgayBan, COUNT(soHDB) as SoHD
	from tHoaDonBan 
	where month(NgayBan)=@thang and year(NgayBan)=@nam
	group by NgayBan
	order by SoHD desc
)
select * from cau4kt(8, 2014)