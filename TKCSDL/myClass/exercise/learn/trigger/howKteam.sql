﻿CREATE TRIGGER trg_CapNhatSoLuong
	ON ChiTietHD
	AFTER INSERT	
AS BEGIN
	--Lấy thông tin vừa INSERT
	DECLARE @MaHH int
	DECLARE @SoLuongMua int
	SELECT @MaHH = MaHH, @SoLuongMua = SoLuong 
	FROM inserted

	--Cập nhật giảm số lượng tồn của hàng hóa
	UPDATE HangHoa
	SET SoLuong = SoLuong - @SoLuongMua
	WHERE MaHH = @MaHH
END

--Demo thử thêm 1 CTHD vào hóa đơn
SELECT  * FROM ChiTietHD WHERE MaHD = 10250

SELECT * FROM HangHoa WHERE MaHH = 1001

INSERT INTO ChiTietHD(MaHD, MaHH, SoLuong, DonGia, GiamGia) 
	VALUES(10250, 1001, 79, 190, 0)

--VD2: Tự động cập nhật tổng tiền của hóa đơn khi thay đổi chi tiết HD
CREATE TRIGGER trg_CapNhatThanhTien
	ON ChiTietHD
	AFTER INSERT, UPDATE, DELETE
AS BEGIN
	DECLARE @MaHD int
	DECLARE @Tong float

	--Lấy mã hóa đơn đang thao tác
	WITH tmp AS (
		SELECT MaHD FROM inserted
		UNION
		SELECT MaHD FROM deleted
	)
	SELECT @MaHD = MaHD FROM tmp

	--Tính tổng tiền theo hóa đơn đó
	SELECT @Tong = SUM(SoLuong * DonGia * (1 - GiamGia))
	FROM ChiTietHD
	WHERE MaHD = @MaHD

	--Cập nhật cột tổng tiền ở bảng hóa đơn ứng với hóa đơn đó
	UPDATE HoaDon
	SET TongTien = @Tong
	WHERE MaHD = @MaHD
END

--Demo
SELECT  * FROM HoaDon WHERE MaHD = 10250
SELECT  * FROM ChiTietHD WHERE MaHD = 10250

SELECT * FROM HangHoa WHERE MaHH = 1002

INSERT INTO ChiTietHD(MaHD, MaHH, SoLuong, DonGia, GiamGia) 
	VALUES(10250, 1002, 79, 19, 0)

--DEMO 02: INSTEAD OF Trigger
SELECT * FROM Loai

--Tạo bảng LoaiHistory
CREATE TABLE LoaiHistory(
	Id int primary key identity(1,1),
	MaLoai int NOT NULL,
	TenLoai nvarchar(50) not null,
	MoTa nvarchar(max),
	Hinh nvarchar(50),
	ActionDate datetime default getutcdate()
)

CREATE TRIGGER trg_ins_of_Loai
	On Loai
	instead of insert
AS BEGIN
	DECLARE @MaLoai int
	--Chèn vào bảng loại
	INSERT INTO Loai(TenLoai, MoTa, Hinh)
		SELECT TenLoai, MoTa, Hinh FROM inserted

	SET @MaLoai = @@IDENTITY
	--Chèn vào bảng LoaiHistory
	INSERT INTO LoaiHistory(MaLoai, TenLoai, MoTa, Hinh)
		SELECT @MaLoai, TenLoai, MoTa, Hinh FROM inserted
END

INSERT INTO Loai(TenLoai, MoTa, Hinh) VALUES('Demo', 'N/A', NULL)

SELECT * FROM Loai
SELECT * FROM LoaiHistory