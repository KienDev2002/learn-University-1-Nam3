CREATE DATABASE QLVanTai
 
GO
USE QLVanTai
GO
/****** Object:  Table [dbo].[ChiTietVanTai]    Script Date: 23/02/2017 11:58:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietVanTai](
	[MaVT] [int] NOT NULL,
	[SoXe] [nvarchar](255) NULL,
	[MaTrongTai] [nvarchar](255) NULL,
	[MaLoTrinh] [nvarchar](255) NULL,
	[SoLuongVT] [int] NULL,
	[NgayDi] [datetime] NULL,
	[NgayDen] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoTrinh]    Script Date: 23/02/2017 11:58:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoTrinh](
	[MaLoTrinh] [nvarchar](255) NOT NULL,
	[TenLoTrinh] [nvarchar](255) NULL,
	[DonGia] [int] NULL,
	[ThoiGianQD] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrongTai]    Script Date: 23/02/2017 11:58:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrongTai](
	[MaTrongTai] [nvarchar](255) NOT NULL,
	[TrongTaiQD] [int] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (1, N'333', N'50', N'PK', 5, CAST(N'2014-05-01T00:00:00.000' AS DateTime), CAST(N'2014-05-03T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (2, N'123', N'52', N'QN', 10, CAST(N'2014-05-03T00:00:00.000' AS DateTime), CAST(N'2014-05-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (3, N'444', N'50', N'NT', 2, CAST(N'2014-05-03T00:00:00.000' AS DateTime), CAST(N'2014-05-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (4, N'333', N'50', N'HN', 3, CAST(N'2014-05-04T00:00:00.000' AS DateTime), CAST(N'2014-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (5, N'111', N'51', N'NT', 6, CAST(N'2014-05-06T00:00:00.000' AS DateTime), CAST(N'2014-05-06T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (6, N'222', N'52', N'HN', 5, CAST(N'2014-05-10T00:00:00.000' AS DateTime), CAST(N'2014-05-16T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (7, N'444', N'50', N'HN', 3, CAST(N'2014-05-25T00:00:00.000' AS DateTime), CAST(N'2014-05-31T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (8, N'111', N'51', N'DN', 4, CAST(N'2014-05-10T00:00:00.000' AS DateTime), CAST(N'2014-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (9, N'333', N'50', N'PK', 4, CAST(N'2014-05-05T00:00:00.000' AS DateTime), CAST(N'2014-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietVanTai] ([MaVT], [SoXe], [MaTrongTai], [MaLoTrinh], [SoLuongVT], [NgayDi], [NgayDen]) VALUES (10, N'123', N'52', N'HN', 14, CAST(N'2014-05-07T00:00:00.000' AS DateTime), CAST(N'2014-05-15T00:00:00.000' AS DateTime))
INSERT [dbo].[LoTrinh] ([MaLoTrinh], [TenLoTrinh], [DonGia], [ThoiGianQD]) VALUES (N'DN', N'Đà nẵng', 5000, 3)
INSERT [dbo].[LoTrinh] ([MaLoTrinh], [TenLoTrinh], [DonGia], [ThoiGianQD]) VALUES (N'HN', N'Hà Nội', 10000, 5)
INSERT [dbo].[LoTrinh] ([MaLoTrinh], [TenLoTrinh], [DonGia], [ThoiGianQD]) VALUES (N'NT', N'Nha Trang', 3000, 1)
INSERT [dbo].[LoTrinh] ([MaLoTrinh], [TenLoTrinh], [DonGia], [ThoiGianQD]) VALUES (N'PK', N'Pleiku', 6000, 4)
INSERT [dbo].[LoTrinh] ([MaLoTrinh], [TenLoTrinh], [DonGia], [ThoiGianQD]) VALUES (N'QN', N'Quảng Nam', 4000, 2)
INSERT [dbo].[TrongTai] ([MaTrongTai], [TrongTaiQD]) VALUES (N'50', 4)
INSERT [dbo].[TrongTai] ([MaTrongTai], [TrongTaiQD]) VALUES (N'51', 8)
INSERT [dbo].[TrongTai] ([MaTrongTai], [TrongTaiQD]) VALUES (N'52', 12)
USE [master]
GO
ALTER DATABASE [BT3] SET  READ_WRITE 
GO