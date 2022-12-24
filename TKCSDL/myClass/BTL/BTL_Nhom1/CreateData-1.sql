--CREATE DATABASE QLBanDienThoai
--USE QLBanDienThoai

create table ChucVu(
	MaCV nvarchar(10) not NULL primary key,
	TenCV nvarchar(255) not null,
)


create table KhachHang(
	MaKH nvarchar(10) not NULL primary key,
	TenKH nvarchar(255) not null,
	DiaChi nvarchar(255) not null,
	SoDienThoai nvarchar(10) not null,
	SoLanMua int,
)


create table NhanVien(
	MaNV nvarchar(10) not NULL primary key,
	TenNV nvarchar(255) not null,
	NgaySinh DATE not null,
	GioiTinh nvarchar(5) not null,
	DiaChi nvarchar(255) not null,
	SoDienThoai nvarchar(10) not null,
	MaCV nvarchar(10) not null,
	GhiChu NVARCHAR(255) DEFAULT N'Đang làm',
	constraint FK_NV_MaCV foreign key(MaCV) references ChucVu(MaCV),
)

create table SanPham(
	MaSP nvarchar(10) not NULL primary key,
	TenSP nvarchar(255) not null,
	DonGiaBan money not null,
	DonGiaNhap money not null,
	SoLuong int not null,
	HangSanXuat NVARCHAR(255) not null,
	GhiChu NVARCHAR(255) DEFAULT N'Đang kinh doanh'
)




create TABLE ChiTietSanPham(
	MaSP nvarchar(10) not null,
	Ram nvarchar(10) not null,
	Rom nvarchar(10) not null,
	MauSac nvarchar(20) not null,
	ThoiGianBaoHanh nvarchar(15) not NULL
    
	constraint FK_ChiTietSanPham_MaSP foreign key(MaSP) references SanPham(MaSP),
)

CREATE TABLE DonDatHang(
	MaDH nvarchar(10) not NULL PRIMARY KEY,
	MaKH nvarchar(10) not NULL,
	MaNV nvarchar(10) not NULL,
	NgayDat DATE NOT NULL,
	NgayGiao DATE NOT NULL,
	TrangThai nvarchar(100),
	constraint FK_DonDatHang_MaKH foreign key(MaKH) references KhachHang(MaKH),
	constraint FK_DonDatHang_MaNV foreign key(MaNV) references NhanVien(MaNV),
)

CREATE TABLE ChiTietDDH(
	MaDH nvarchar(10) not NULL,
	MaSP nvarchar(10) not NULL,
	SoLuong INT NOT NULL,
	constraint FK_ChiTietDDH_MaDH foreign key(MaDH) references DonDatHang(MaDH),
	constraint FK_ChiTietDDH_MaSP foreign key(MaSP) references SanPham(MaSP),
)

create table NhaCungCap(
	MaNCC nvarchar(10) not NULL primary key,
	TenNCC nvarchar(255) not null,
	DiaChi nvarchar(255) not null,
	SoDienThoai nvarchar(10) not null,
	GhiChu NVARCHAR(255) DEFAULT N'Hợp tác',
)

CREATE TABLE HoaDonBan(
	SoHDB nvarchar(10) not NULL PRIMARY KEY,
	NgayBan date not null,
	TongTien money,
	HinhThucThanhToan nvarchar(30) not null,
	MaKH nvarchar(10) not null,
	MaNV nvarchar(10) not null,
	MaDH nvarchar(10),

	constraint FK_HDB_NCC foreign key(MaKH) references KhachHang(MaKH),
	constraint FK_HDB_NV foreign key(MaNV) references NhanVien(MaNV),
	constraint FK_HDB_DDH foreign key(MaDH) references DonDatHang(MaDH),	
)



CREATE TABLE ChiTietHDB(
	SoHDB nvarchar(10) not NULL,
	MaSP nvarchar(10) not NULL,
	SLBan int not NULL,
	KhuyenMai INT,
	constraint FK_ChiTietHDB_SoHDB foreign key(SoHDB) references HoaDonBan(SoHDB),
	constraint FK_ChiTietHDB_MaSP foreign key(MaSP) references SanPham(MaSP),
	 CONSTRAINT [PK_ChiTietHDB] PRIMARY KEY CLUSTERED 
(
	SoHDB ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE HoaDonNhap(
	SoHDN nvarchar(10) not NULL PRIMARY KEY,
	NgayNhap date not null,
	TongTien money,
	HinhThucThanhToan nvarchar(100) not null,
	MaNCC nvarchar(10) not NULL,
	MaNV nvarchar(10) not null,
	constraint FK_NhaCungCap_MaNCC foreign key(MaNCC) references NhaCungCap(MaNCC),
	constraint FK_NhanVien_MaNV foreign key(MaNV) references NhanVien(MaNV)
)

CREATE TABLE ChiTietHDN(
	SoHDN nvarchar(10) not NULL,
	MaSP nvarchar(10) not NULL,
	SLNhap int not NULL,
	KhuyenMai int,
	constraint FK_ChiTietHDN_SoHDN foreign key(SoHDN) references HoaDonNhap(SoHDN),
	constraint FK_ChiTietHDN_MaSP foreign key(MaSP) REFERENCES SanPham(MaSP),
 CONSTRAINT [PK_ChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[SoHDN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




