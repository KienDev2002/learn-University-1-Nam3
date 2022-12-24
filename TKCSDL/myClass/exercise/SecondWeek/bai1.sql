

--1. Tạo View danh sách sinh viên, gồm các thông tin sau: Mã sinh viên, Họ sinh viên,Tên sinh viên, Học bổng.

CREATE VIEW cau1
AS
SELECT sv.MaSV,  sv.HoSV + ' ' + sv.TenSV AS N'Ho Ten' , sv.HocBong
FROM dbo.DSSinhVien sv


--2. Tạo view Liệt kê các sinh viên có học bổng từ 150,000 trở lên và sinh ở Hà Nội, gồm các thông tin: Họ tên sinh viên, Mã khoa, Nơi sinh, Học bổng.
go
CREATE VIEW cau2
AS
SELECT   sv.HoSV + ' ' + sv.TenSV AS N'Ho Ten'  , sv.MaKhoa , sv.NoiSinh , sv.HocBong
FROM dbo.DSSinhVien sv
WHERE sv.HocBong > 150000 AND sv.NoiSinh = N'Hà Nội'


GO

--3. Tạo view liệt kê những sinh viên nam của khoa Anh văn và khoa tin học, gồm các thông tin: Mã sinh viên, Họ tên sinh viên, tên khoa, Phái.
CREATE VIEW cau3
AS 
SELECT sv.MaSV ,  sv.HoSV + ' ' + sv.TenSV AS N'HoTen' , k.TenKhoa, sv.Phai
FROM dbo.DSSinhVien sv JOIN dbo.DMKhoa k ON k.MaKhoa = sv.MaKhoa
WHERE sv.Phai = N'Nam' AND (k.TenKhoa = N'Anh Văn' OR k.TenKhoa = N'Tin Học')

--4. Tạo view gồm những sinh viên có tuổi từ 20 đến 25, thông tin gồm: Họ tên sinh viên, Tuổi, Tên khoa.
GO
CREATE VIEW cau4
AS
SELECT  sv.HoSV + ' ' + sv.TenSV AS N'Ho Ten'  , YEAR(GETDATE()) - YEAR(sv.NgaySinh) AS Tuoi , k.TenKhoa
FROM dbo.DSSinhVien sv JOIN dbo.DMKhoa k ON k.MaKhoa = sv.MaKhoa
WHERE YEAR(GETDATE()) - YEAR(sv.NgaySinh) BETWEEN 20 AND 25





--5. Tạo view cho biết thông tin về mức học bổng của các sinh viên, gồm: Mã sinh viên, Phái, Mã khoa, Mức học bổng.
--Trong đó, mức học bổng sẽ hiển thị là “Học bổng cao” nếu giá trị của field học bổng lớn hơn 500,000 và ngược lại hiển thị
--là “Mức trung bình”
go
CREATE VIEW cau5
AS
SELECT sv.MaSV, sv.Phai , sv.MaKhoa , CASE WHEN sv.HocBong > 500000 THEN N'Học bổng cao' ELSE N'Mức trung bình' END AS N'Mức học bổng'
FROM dbo.DSSinhVien sv



--6. Tạo view đưa ra thông tin những sinh viên có học bổng lớn hơn bất kỳ học bổng của sinh viên học khóa anh văn
go
CREATE VIEW cau6
AS
SELECT sv.MaSV, sv.Phai , sv.MaKhoa , sv.HocBong
FROM dbo.DSSinhVien sv JOIN dbo.DMKhoa k ON k.MaKhoa = sv.MaKhoa
WHERE k.TenKhoa != N'Anh Văn'  AND  sv.HocBong > 
(
	SELECT MAX(sv.HocBong)
	FROM dbo.DSSinhVien sv JOIN dbo.DMKhoa k ON k.MaKhoa = sv.MaKhoa
	WHERE k.TenKhoa = N'Anh Văn'
)

--7. Tạo view đưa ra thông tin những sinh viên đạt điểm cao nhất trong từng môn.
go
CREATE VIEW cau7
AS
SELECT sv.MaSV,  sv.HoSV + ' ' + sv.TenSV AS 'Họ Tên', sv.Phai, sv.NoiSinh , sv.MaKhoa , kq.MaMH, kq.Diem
FROM dbo.DSSinhVien sv JOIN dbo.KetQua kq ON kq.MaSV = sv.MaSV
JOIN 
(
	SELECT kq.MaMH AS Mamh, MAX(kq.Diem) AS Diem
	FROM dbo.KetQua kq
	GROUP BY kq.MaMH
)bang7 ON bang7.Mamh = kq.MaMH AND bang7.Diem = kq.Diem

--8. Tạo view đưa ra những sinh viên chưa thi môn cơ sở dữ liệu.

GO
CREATE VIEW cau8
AS
SELECT DISTINCT  sv.MaSV,  sv.HoSV + ' ' + sv.TenSV AS N'HoTen', sv.Phai, sv.NoiSinh , sv.MaKhoa , sv.HocBong
FROM dbo.DSSinhVien sv 
WHERE sv.MaSV NOT in
(
	SELECT DISTINCT kq.MaSV
	FROM dbo.KetQua kq JOIN dbo.DMMonHoc mh ON mh.MaMH = kq.MaMH
	WHERE mh.TenMH = N'Cơ Sở Dữ Liệu'
)

--9. Tạo view đưa ra thông tin những sinh viên không trượt môn nào.
GO
CREATE VIEW cau9
AS
SELECT DISTINCT sv.MaSV , sv.HoSV + ' ' + sv.TenSV AS N'Ho Ten' , sv.Phai
FROM dbo.DSSinhVien sv JOIN dbo.KetQua kq ON kq.MaSV = sv.MaSV
WHERE sv.MaSV NOT IN
(
	SELECT DISTINCT kq.MaSV
	FROM KetQua kq 
	WHERE kq.Diem < 4
)
















