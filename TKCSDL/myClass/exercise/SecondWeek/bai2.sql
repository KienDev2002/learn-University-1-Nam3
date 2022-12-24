
--bài 2

USE BT1_TKCSDL_HS
--1. Tạo view DSHS10A1 gồm thông tin Mã học sinh, họ tên, giới tính (là “Nữ” nếu Nu=1, ngược lại là “Nam”), 
--các điểm Toán, Lý, Hóa, Văn của các học sinh lớp 10A1
CREATE VIEW DSHS10A1 
AS
SELECT hs.MAHS, hs.HO + ' ' + hs.TEN as N'Họ và Tên' , case when hs.NU = 1 then N'Nữ' else N'Nam' end as N'Giới tính', d.TOAN, d.LY, d.HOA, d.VAN 
FROM DSHS hs join DIEM d on d.MAHS = hs.MAHS
where hs.MALOP = '10A1'


--2.
--Đăng nhập TranThanhPhong để kiểm tra
--Đăng nhập PhamVanNam để kiểm tra
--Đăng nhập PhamVanNam để kiểm tra
--Tạo login TranThanhPhong, tạo user TranThanhPhong cho TranThanhPhong trên CSDL QLHocSinh
EXEC sp_addlogin TranThanhPhong,123
EXEC sp_adduser TranThanhPhong, TranThanhPhong






--Phân quyền Select trên view DSHS10A1 cho TranThanhPhong
GRANT SELECT ON DSHS10A1 TO TranThanhPhong

--Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLHocSinh
EXEC sp_addlogin PhamVanNam,123
EXEC sp_adduser PhamVanNam, PhamVanNam


--Tạo view DSHS10A2 tương tự như câu 1
go
CREATE VIEW DSHS10A2
AS
SELECT hs.MAHS, hs.HO + ' ' + hs.TEN as N'Họ và Tên' , case when hs.NU = 1 then N'Nữ' else N'Nam' end as N'Giới tính', d.TOAN, d.LY, d.HOA, d.VAN 
FROM DSHS hs join DIEM d on d.MAHS = hs.MAHS
where hs.MALOP = '10A1'

--Phân quyền Select trên view DSHS10A2 cho PhamVanNam
GRANT SELECT ON DSHS10A2 TO PhamVanNam


-- 3. Tạo view báo cáo Kết thúc năm học gồm các thông tin: Mã học sinh, Họ và tên, Ngày sinh, 
--Giới tính, Điểm Toán, Lý, Hóa, Văn, Điểm Trung bình, Xếp loại, Sắp xếp theo xếp loại (chọn 1000 bản ghi đầu). Trong đó:
--Điểm trung bình (DTB) = ((Toán + Văn)*2 + Lý + Hóa)/6)
--Cách thức xếp loại như sau:
--- Xét điểm thấp nhất (DTN) của các 4 môn 
--- Nếu DTB>5 và DTN>4 là “Lên Lớp”, ngược lại là lưu ban
go
CREATE VIEW BCKTNAMHOC
AS
SELECT top(1000) hs.MAHS , hs.HO + ' ' + hs.TEN as N'Họ và Tên', hs.NGAYSINH, case when hs.NU = 1 then N'Nữ' else N'Nam' end as N'Giới tính',
d.TOAN, d.LY, d.HOA, d.VAN, bangDTB.DTB,
case when toan<=ly and toan<=hoa and toan<=van then 
	case when  toan > 4 and bangDTB.DTB > 5 then N'Lên Lớp' else N'Lưu ban' end
when ly<=toan and ly<=hoa and ly<=van then 
	case when  ly > 4 and bangDTB.DTB > 5 then N'Lên Lớp' else N'Lưu ban' end
when hoa<=toan and hoa<=van and hoa<=ly then 
	case when  hoa > 4 and bangDTB.DTB > 5 then N'Lên Lớp' else N'Lưu ban' end
when van<=toan and van<=ly and van<=hoa then 
	case when  van > 4 and bangDTB.DTB > 5 then N'Lên Lớp' else N'Lưu ban' end
end as XepLoai
FROM DSHS hs join DIEM d on d.MAHS = hs.MAHS,
(
	select d.MAHS, ((d.Toan + d.Van)*2 + d.LY + d.HOA)/6 as DTB
	from DIEM d
)bangDTB 
where bangDTB.MAHS = hs.MAHS
order by XepLoai desc


--4. Tạo view danh sách HOC SINH XUAT SAC bao gồm các học sinh có DTB>=8.5 và DTN>=8 với các trường: 
--Lop, Mahs, Hoten, Namsinh (năm sinh), Nu, Toan, Ly, Hoa, Van, DTN, DTB
go
create view HOCSINHXUATSAC
as
select hs.MALOP, hs.MaHS ,  hs.HO + ' ' + hs.TEN as N'Họ và Tên', YEAR(hs.NGAYSINH) as N'Năm sinh', hs.NU, d.TOAN, d.LY, d.HOA, d.VAN,bangDTN.DTN, bangDTB.DTB
FROM DSHS hs join DIEM d on d.MAHS = hs.MAHS,
(
	select d.MAHS, ((d.Toan + d.Van)*2 + d.LY + d.HOA)/6 as DTB
	from DIEM d
)bangDTB,
(
	select d.MAHS, case 
	when toan<=ly and toan<=hoa and toan<=van then toan
	when ly<=toan and ly<=hoa and ly<=van then ly
	when hoa<=toan and hoa<=van and hoa<=ly then hoa
	when van<=toan and van<=ly and van<=hoa then van
	end as DTN
	from DIEM d
)bangDTN
where bangDTB.MAHS = hs.MAHS and bangDTN.MAHS = hs.MAHS and  bangDTB.DTB>=8.5 and bangDTN.DTN >=8


--5. Tạo view danh sách HOC SINH DAT THU KHOA KY THI bao gồm các học sinh xuất sắc có DTB lớn nhất với các trường: 
--Lop, Mahs, Hoten, Namsinh, Nu, Toan, Ly, Hoa, Van, DTB
go
create view HSDTK 
as
SELECT TOP(1) WITH TIES hs.MALOP, hs.MAHS ,  hs.HO + ' ' + hs.TEN as N'Họ và Tên', YEAR(hs.NGAYSINH) AS N'Năm sinh', hs.NU, d.TOAN, d.LY, d.HOA, d.VAN,bangDTB.DTB
from DSHS hs join DIEM d on d.MAHS = hs.MAHS,(
	select d.MAHS, ((d.Toan + d.Van)*2 + d.LY + d.HOA)/6 as DTB
	from DIEM d
)bangDTB
where bangDTB.MAHS = hs.MAHS
ORDER BY bangDTB.DTB DESC

