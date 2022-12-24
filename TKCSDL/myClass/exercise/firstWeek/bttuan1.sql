

--1. Tạo View danh sách sinh viên, gồm các thông tin sau: Mã sinh viên, Họ sinh viên,Tên sinh viên, Học bổng.

CREATE VIEW cau1
AS
SELECT sv.MaSV, sv.HoSV, sv.TenSV, sv.HocBong
FROM dbo.DSSinhVien sv


--2. Tạo view Liệt kê các sinh viên có học bổng từ 150,000 trở lên và sinh ở Hà Nội, gồm các thông tin: Họ tên sinh viên, Mã khoa, Nơi sinh, Học bổng.
go
CREATE VIEW cau2
AS
SELECT  sv.HoSV , sv.TenSV , sv.MaKhoa , sv.NoiSinh , sv.HocBong
FROM dbo.DSSinhVien sv
WHERE sv.HocBong > 150000 AND sv.NoiSinh = N'Hà Nội'


GO

--3. Tạo view liệt kê những sinh viên nam của khoa Anh văn và khoa tin học, gồm các thông tin: Mã sinh viên, Họ tên sinh viên, tên khoa, Phái.
CREATE VIEW cau3
AS 
SELECT sv.MaSV , sv.HoSV , sv.TenSV , k.TenKhoa, sv.Phai
FROM dbo.DSSinhVien sv JOIN dbo.DMKhoa k ON k.MaKhoa = sv.MaKhoa
WHERE sv.Phai = N'Nam' AND (k.TenKhoa = N'Anh Văn' OR k.TenKhoa = N'Tin Học')

--4. Tạo view gồm những sinh viên có tuổi từ 20 đến 25, thông tin gồm: Họ tên sinh viên, Tuổi, Tên khoa.