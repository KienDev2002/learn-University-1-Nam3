--create database QLThuongMaiDienTu
--use QLThuongMaiDienTu

create table NguoiDung (
	IDNguoiDung nvarchar(50) not null primary key,
	MaNguoiDung nvarchar(10) not null unique,
	TenNguoiDung nvarchar(100) not null,
	Anh Image not null,
	SoDienThoai nvarchar(10) not null,
	Email nvarchar(30) not null,
	CCCD_CMND nvarchar(20) not null,
	DiaChi nvarchar(10) not null 
)

create table CuaHang (
	IDCuaHang nvarchar(50) not null primary key,
	MaCuaHang nvarchar(10) not null unique,
	TenCuaHang nvarchar(100) not null,
	SoDienThoai nvarchar(10) not null,
	Email nvarchar(30) not null,
	DiaChi nvarchar(10) not null,
	CCCD_CMND_ChuCH nvarchar(20) not null,
	Anh Image not null,
)

create table KhachHang (
	IDKhachHang nvarchar(50) not null primary key,
	MaKhachHang nvarchar(10) not null unique,
	TenKhachHang nvarchar(100) not null,
	SoDienThoai nvarchar(10) not null,
	Email nvarchar(30) not null,
)

create table DanhMuc (
	IDDanhMuc nvarchar(50) not null primary key,
	MaDanhMuc nvarchar(50) not null unique,
	TenDanhMuc nvarchar(50) not null,
	MoTa nvarchar(200) not null,
	TrangThai nvarchar(200) not null,
)


create table SanPham (
	IDSanPham nvarchar(50) not null primary key,
	MaSanPham nvarchar(10) not null unique,
	TenSanPham nvarchar(100) not null,
	Giá nvarchar(10) not null,
	Anh Image not null,
	Mo_Ta nvarchar(30) not null,
	SoLuong int not null,
	IDCuaHang nvarchar(50) not null,
	IDDanhMuc nvarchar(50) not null,
	KhuyenMai nvarchar(20) not null,
	foreign key (IDCuaHang) references CuaHang(IDCuaHang),
	foreign key (IDDanhMuc) references DanhMuc(IDDanhMuc)
)

create table CongTyVanChuyen (
	IDCongTyVC nvarchar(50) not null primary key,
	MaCongTy nvarchar(50) not null unique,
	TenCongTy nvarchar(50) not null,
	MoTa nvarchar(200) not null,
)


create table Shipper (
	IDShipper nvarchar(50) not null primary key,
	MaShipper nvarchar(10) not null unique,
	TenShipper nvarchar(100) not null,
	SoDienThoai nvarchar(10) not null,
	Email nvarchar(30) not null,
	CCCD_CMND nvarchar(20) not null,
	IDCongTyVC nvarchar(50) not null,
	foreign key (IDCongTyVC) references CongTyVanChuyen(IDCongTyVC)
)


create table HoaDonNhap (
	IDHDN nvarchar(50) not null primary key,
	MaHDN nvarchar(50) not null unique,
	NgayNhap date not null,
	TongTien money not null,
	TrangThai nvarchar(200) not null,
	IDCuaHang nvarchar(50) not null,
	FOREIGN KEY (IDCuaHang) REFERENCES CuaHang(IDCuaHang),
)

create table HoaDonXuat (
	IDHDX nvarchar(50) not null primary key,
	MaHDX nvarchar(50) not null unique,
	NgayNhap date not null,
	TongTien money not null,
	TrangThai nvarchar(200) not null,
	Anh image,
	IDShipper nvarchar(50) not null,
	IDKhachHang nvarchar(50) not null,
	FOREIGN KEY (IDShipper) REFERENCES Shipper(IDShipper),
	FOREIGN KEY (IDKhachHang) REFERENCES KhachHang(IDKhachHang)
)

create table DonHang (
	IDDonHang nvarchar(50) not null primary key,
	MaDonHang nvarchar(50) not null unique,
	DiaChiKH nvarchar(200) not null,
	SDT nvarchar(20) not null,
	TongTien money not null,
	TinhTrang nvarchar(100) not null,
	SoLuong int not null,
	IDShipper nvarchar(50) not null,
	IDSanPham nvarchar(50) not null,
	IDCuaHang nvarchar(50) not null,
	IDKhachHang nvarchar(50) not null,
	FOREIGN KEY (IDShipper) REFERENCES Shipper(IDShipper),
	FOREIGN KEY (IDSanPham) REFERENCES SanPham(IDSanPham),
	FOREIGN KEY (IDCuaHang) REFERENCES CuaHang(IDCuaHang),
	FOREIGN KEY (IDKhachHang) REFERENCES KhachHang(IDKhachHang)
)
