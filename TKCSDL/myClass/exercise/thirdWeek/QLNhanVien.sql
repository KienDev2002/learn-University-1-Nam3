create database [QLNhanVien]

USE [QLNhanVien]
GO
/****** Object:  Table [dbo].[tChiTietNhanVien]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietNhanVien](
	[MaNV] [nvarchar](3) NOT NULL,
	[ChucVu] [nvarchar](3) NULL,
	[HSLuong] [tinyint] NULL,
	[MucDoCV] [nvarchar](2) NULL,
	[GTGC] [tinyint] NULL,
 CONSTRAINT [PK_tChiTietNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNhanVien]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhanVien](
	[MaNV] [nvarchar](3) NOT NULL,
	[HO] [nvarchar](15) NULL,
	[TEN] [nvarchar](7) NULL,
	[PHAI] [bit] NOT NULL,
	[NTNS] [datetime] NULL,
	[NgayBD] [datetime] NULL,
	[MaPB] [nvarchar](2) NULL,
	[HINH] [image] NULL,
	[GHICHU] [nvarchar](max) NULL,
 CONSTRAINT [PK_tNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPhongBan](
	[MaPB] [nvarchar](2) NOT NULL,
	[TENPB] [nvarchar](30) NULL,
	[TruongPhong] [nvarchar](3) NULL,
 CONSTRAINT [PK_tPhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'001', N'NV', 4, N'C1', 1)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'002', N'NV', 5, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'003', N'NV', 3, N'C2', 2)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'004', N'NV', 2, N'C1', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'005', N'NV', 6, N'C3', 4)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'006', N'TL', 6, N'B2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'007', N'PP', 5, N'B2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'008', N'PGD', 7, N'A2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'009', N'PP', 7, N'B2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'010', N'NV', 6, N'C3', 1)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'011', N'NV', 5, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'012', N'NV', 4, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'013', N'NV', 7, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'014', N'TX', 4, N'B3', 2)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'015', N'TK', 4, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'016', N'NV', 5, N'C1', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'017', N'PP', 8, N'B2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'018', N'NV', 3, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'019', N'PGD', 7, N'A2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'020', N'TK', 4, N'C2', 2)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'021', N'TL', 5, N'B2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'022', N'TP', 7, N'A3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'023', N'NV', 4, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'024', N'NV', 4, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'025', N'NV', 3, N'C3', 1)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'026', N'TL', 4, N'B2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'027', N'TX', 5, N'B3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'028', N'NV', 7, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'029', N'NV', 3, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'030', N'NV', 3, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'031', N'NV', 4, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'032', N'PP', 6, N'B3', 3)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'033', N'TP', 7, N'A3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'034', N'NV', 5, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'035', N'PP', 6, N'B3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'036', N'TK', 4, N'B1', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'037', N'NV', 3, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'038', N'TK', 4, N'B1', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'039', N'NV', 4, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'040', N'TP', 7, N'A3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'041', N'PGD', 8, N'A2', 1)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'042', N'NV', 5, N'C3', 1)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'043', N'TK', 4, N'B1', 1)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'044', N'NV', 4, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'045', N'NV', 3, N'C1', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'046', N'NV', 2, N'C1', 3)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'047', N'TP', 8, N'A2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'048', N'NV', 5, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'049', N'NV', 3, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'050', N'NV', 6, N'C3', 2)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'051', N'NV', 4, N'C2', 2)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'052', N'PP', 7, N'B3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'053', N'NV', 2, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'054', N'NV', 4, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'055', N'NV', 3, N'C2', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'056', N'NV', 4, N'C3', 3)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'057', N'GD', 9, N'A3', 4)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'058', N'NV', 4, N'C3', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'059', N'NV', 3, N'C1', NULL)
INSERT [dbo].[tChiTietNhanVien] ([MaNV], [ChucVu], [HSLuong], [MucDoCV], [GTGC]) VALUES (N'060', N'TP', 7, N'A3', NULL)
GO
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'001', N'Lại Văn', N'Sâm', 0, CAST(N'1966-01-01T00:00:00.000' AS DateTime), CAST(N'1990-04-30T00:00:00.000' AS DateTime), N'VP', NULL, N'Nam nhan vien khoe manh, tre trung, co trinh do; Tot nghiep dai hoc loai uu; Nhanh nhen, hoat bat')
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'002', N'Trần Văn', N'Minh', 0, CAST(N'1965-02-23T00:00:00.000' AS DateTime), CAST(N'1990-05-10T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'003', N'Tống Cảnh', N'Sơn', 0, CAST(N'1963-04-12T00:00:00.000' AS DateTime), CAST(N'1996-10-24T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'004', N'Ngô Việt', N'Hương', 0, CAST(N'1977-02-11T00:00:00.000' AS DateTime), CAST(N'1997-06-04T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'005', N'Mai Thị', N'Loan', 1, CAST(N'1970-05-23T00:00:00.000' AS DateTime), CAST(N'1989-03-08T00:00:00.000' AS DateTime), N'TK', NULL, N'La can bo nang no, Co trình do trung cap. Tot nghiep loai kha')
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'006', N'Mạc Xuân', N'Tiến', 0, CAST(N'1963-04-12T00:00:00.000' AS DateTime), CAST(N'1992-03-28T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'007', N'Vũ Hoài', N'Anh', 0, CAST(N'1968-06-15T00:00:00.000' AS DateTime), CAST(N'1993-03-09T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'008', N'Trần Thanh', N'hanh', 0, CAST(N'1942-07-15T00:00:00.000' AS DateTime), CAST(N'1985-10-11T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'009', N'Nguyễn Hồng', N'Hạnh', 1, CAST(N'1962-01-13T00:00:00.000' AS DateTime), CAST(N'1987-06-06T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'010', N'Lê Thị', N'Hồng', 1, CAST(N'1962-05-23T00:00:00.000' AS DateTime), CAST(N'1988-06-06T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'011', N'Lâm Quốc', N'Khanh', 0, CAST(N'1963-06-21T00:00:00.000' AS DateTime), CAST(N'1991-09-27T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'012', N'Nguyễn Hồng', N'Vân', 1, CAST(N'1976-05-11T00:00:00.000' AS DateTime), CAST(N'1995-05-05T00:00:00.000' AS DateTime), N'TK', NULL, N'Co trình do dai hoc, Co the phat trien trong nganh tin hoc')
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'013', N'Nguyễn Minh', N'Quang', 0, CAST(N'1951-06-13T00:00:00.000' AS DateTime), CAST(N'1978-05-05T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'014', N'Trang Phi', N'Hương', 0, CAST(N'1953-03-23T00:00:00.000' AS DateTime), CAST(N'1996-07-07T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'015', N'Trần Nguyệt', N'Minh', 1, CAST(N'1963-09-19T00:00:00.000' AS DateTime), CAST(N'1995-10-10T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'016', N'Nguyền Ngọc', N'Hiền', 1, CAST(N'1961-03-14T00:00:00.000' AS DateTime), CAST(N'1990-04-08T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'017', N'Đỗ Ánh', N'Hoàng', 0, CAST(N'1960-01-11T00:00:00.000' AS DateTime), CAST(N'1979-05-05T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'018', N'Đinh Thị', N'Tâm', 1, CAST(N'1962-03-04T00:00:00.000' AS DateTime), CAST(N'1995-05-05T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'019', N'Nguyễn Kim', N'Toàn', 1, CAST(N'1960-09-01T00:00:00.000' AS DateTime), CAST(N'1990-07-31T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'020', N'Nguyễn Bích', N'Liên', 1, CAST(N'1969-03-03T00:00:00.000' AS DateTime), CAST(N'1996-12-16T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'021', N'Huỳnh Bạch', N'Tuyết', 1, CAST(N'1968-03-07T00:00:00.000' AS DateTime), CAST(N'1994-05-23T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'022', N'Lê Phương', N'Thanh', 1, CAST(N'1957-02-12T00:00:00.000' AS DateTime), CAST(N'1981-05-05T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'023', N'Tạ Thế', N'Khanh', 0, CAST(N'1969-05-23T00:00:00.000' AS DateTime), CAST(N'1993-09-15T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'024', N'Bùi Sơn', N'Hải', 0, CAST(N'1951-03-14T00:00:00.000' AS DateTime), CAST(N'1990-05-08T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'025', N'Lưu Vũ', N'Duẩn', 0, CAST(N'1970-06-17T00:00:00.000' AS DateTime), CAST(N'1995-08-22T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'026', N'Đoàn Đức', N'Chi', 0, CAST(N'1960-05-12T00:00:00.000' AS DateTime), CAST(N'1994-10-30T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'027', N'Trần Quang', N'Thành', 0, CAST(N'1963-09-14T00:00:00.000' AS DateTime), CAST(N'1992-05-05T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'028', N'Trương Lệ', N'Xuaân', 1, CAST(N'1968-04-13T00:00:00.000' AS DateTime), CAST(N'1994-05-23T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'029', N'Nguyễn Văn', N'Thanh', 0, CAST(N'1969-09-02T00:00:00.000' AS DateTime), CAST(N'1996-02-08T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'030', N'Đặng Văn', N'Thụy', 0, CAST(N'1968-01-01T00:00:00.000' AS DateTime), CAST(N'1992-08-23T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'031', N'Nguyễn Văn', N'Hoàng', 0, CAST(N'1979-02-02T00:00:00.000' AS DateTime), CAST(N'1994-05-23T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'032', N'Lâm Văn', N'Tuấn', 0, CAST(N'1969-02-12T00:00:00.000' AS DateTime), CAST(N'1993-09-09T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'033', N'Hoàng Ngọc', N'Thanh', 0, CAST(N'1944-05-13T00:00:00.000' AS DateTime), CAST(N'1978-03-09T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'034', N'Nguyễn Văn', N'Nuôi', 0, CAST(N'1970-04-23T00:00:00.000' AS DateTime), CAST(N'1990-10-02T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'035', N'Dư Đình', N'Việt', 0, CAST(N'1945-04-12T00:00:00.000' AS DateTime), CAST(N'1985-07-31T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'036', N'Lê Trung', N'Bình', 0, CAST(N'1977-04-13T00:00:00.000' AS DateTime), CAST(N'1997-05-30T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'037', N'Trần Thế', N'Duyệt', 0, CAST(N'1970-04-14T00:00:00.000' AS DateTime), CAST(N'1996-04-26T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'038', N'Lê Bích', N'Phương', 1, CAST(N'1974-03-13T00:00:00.000' AS DateTime), CAST(N'1995-08-04T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'039', N'Mai Văn', N'Đức', 0, CAST(N'1960-04-14T00:00:00.000' AS DateTime), CAST(N'1993-10-04T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'040', N'Trương Xuân', N'Hoàng', 0, CAST(N'1940-05-15T00:00:00.000' AS DateTime), CAST(N'1979-04-28T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'041', N'Huỳnh Ngọc', N'Quang', 0, CAST(N'1964-05-23T00:00:00.000' AS DateTime), CAST(N'1990-05-30T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'042', N'Đào Thanh', N'Hương', 1, CAST(N'1969-03-12T00:00:00.000' AS DateTime), CAST(N'1993-08-08T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'043', N'Phạm Hoài', N'Nam', 1, CAST(N'1978-06-15T00:00:00.000' AS DateTime), CAST(N'1992-07-28T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'044', N'Lê Thị Mỹ', N'Linh', 1, CAST(N'1971-09-19T00:00:00.000' AS DateTime), CAST(N'1995-05-30T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'045', N'Phạm Thế', N'Dung', 0, CAST(N'1980-05-23T00:00:00.000' AS DateTime), CAST(N'1997-12-30T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'046', N'Hoàng Thanh', N'Trang', 1, CAST(N'1970-03-12T00:00:00.000' AS DateTime), CAST(N'1997-03-03T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'047', N'Nguyễn Văn', N'Hiền', 0, CAST(N'1960-06-15T00:00:00.000' AS DateTime), CAST(N'1988-05-05T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'048', N'Trần Nguyệt', N'Nga', 1, CAST(N'1965-07-12T00:00:00.000' AS DateTime), CAST(N'1993-04-26T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'049', N'Mai Thị Hồng', N'Xuân', 1, CAST(N'1962-06-02T00:00:00.000' AS DateTime), CAST(N'1995-09-09T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'050', N'Nguyễn Thị', N'Nam', 1, CAST(N'1960-07-06T00:00:00.000' AS DateTime), CAST(N'1987-06-06T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'051', N'Tôn Thị Thanh', N'Nhàn', 1, CAST(N'1965-06-14T00:00:00.000' AS DateTime), CAST(N'1993-10-04T00:00:00.000' AS DateTime), N'TC', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'052', N'Nguyễn Tố', N'Uyên', 1, CAST(N'1963-06-05T00:00:00.000' AS DateTime), CAST(N'1990-10-07T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'053', N'Lương Anh', N'Tuyền', 1, CAST(N'1975-01-23T00:00:00.000' AS DateTime), CAST(N'1997-10-02T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'054', N'Đỗ Văn', N'Thanh', 0, CAST(N'1971-03-24T00:00:00.000' AS DateTime), CAST(N'1993-06-06T00:00:00.000' AS DateTime), N'VP', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'055', N'Lương Văn', N'Chính', 0, CAST(N'1963-05-20T00:00:00.000' AS DateTime), CAST(N'1997-01-12T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'056', N'Trương Tường', N'Nhật', 0, CAST(N'1972-12-25T00:00:00.000' AS DateTime), CAST(N'1994-05-23T00:00:00.000' AS DateTime), N'KH', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'057', N'Nguyễn Xuân', N'Phương', 0, CAST(N'1960-04-14T00:00:00.000' AS DateTime), CAST(N'1986-01-05T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'058', N'Võ Ngọc', N'Quang', 0, CAST(N'1960-02-12T00:00:00.000' AS DateTime), CAST(N'1990-10-07T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'059', N'Nguyễn Thanh', N'Thơ', 1, CAST(N'1960-05-19T00:00:00.000' AS DateTime), CAST(N'1996-07-07T00:00:00.000' AS DateTime), N'TK', NULL, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [HO], [TEN], [PHAI], [NTNS], [NgayBD], [MaPB], [HINH], [GHICHU]) VALUES (N'060', N'Nguyễn Trường', N'Sơn', 0, CAST(N'1941-05-20T00:00:00.000' AS DateTime), CAST(N'1989-07-22T00:00:00.000' AS DateTime), N'KT', NULL, NULL)
GO
INSERT [dbo].[tPhongBan] ([MaPB], [TENPB], [TruongPhong]) VALUES (N'KH', N'Phòng Kinh tế Kế hoạch', N'022')
INSERT [dbo].[tPhongBan] ([MaPB], [TENPB], [TruongPhong]) VALUES (N'KT', N'Phòng Kế toán Tài chánh', N'011')
INSERT [dbo].[tPhongBan] ([MaPB], [TENPB], [TruongPhong]) VALUES (N'TC', N'Phòng Tổ chức Nhân sự', N'029')
INSERT [dbo].[tPhongBan] ([MaPB], [TENPB], [TruongPhong]) VALUES (N'TK', N'Phòng Kỷ thuật Thiết kế', N'012')
INSERT [dbo].[tPhongBan] ([MaPB], [TENPB], [TruongPhong]) VALUES (N'VP', N'Văn phòng Xí nghiệp', N'014')
GO
ALTER TABLE [dbo].[tChiTietNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietNhanVien_tNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tChiTietNhanVien] CHECK CONSTRAINT [FK_tChiTietNhanVien_tNhanVien]
GO
ALTER TABLE [dbo].[tNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_tNhanVien_tPhongBan1] FOREIGN KEY([MaPB])
REFERENCES [dbo].[tPhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[tNhanVien] CHECK CONSTRAINT [FK_tNhanVien_tPhongBan1]
GO