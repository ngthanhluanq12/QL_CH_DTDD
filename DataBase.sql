USE [master]
GO
/****** Object:  Database [QL_DTDD_DB]    Script Date: 02/06/2023 5:41:36 SA ******/
CREATE DATABASE [QL_DTDD_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_DTDD_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_DTDD_DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_DTDD_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_DTDD_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_DTDD_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_DTDD_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_DTDD_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_DTDD_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_DTDD_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_DTDD_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_DTDD_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_DTDD_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_DTDD_DB] SET  MULTI_USER 
GO
ALTER DATABASE [QL_DTDD_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_DTDD_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_DTDD_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_DTDD_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_DTDD_DB]
GO
/****** Object:  Table [dbo].[BoPhan]    Script Date: 02/06/2023 5:41:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoPhan](
	[BoPhanId] [int] IDENTITY(1,1) NOT NULL,
	[TenBoPhan] [nvarchar](50) NULL,
 CONSTRAINT [PK_BoPhan] PRIMARY KEY CLUSTERED 
(
	[BoPhanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 02/06/2023 5:41:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiSanPhamId] [int] NOT NULL,
	[SanPhamId] [int] NULL,
	[TenKhachHang] [nvarchar](100) NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[NgayBan] [datetime] NULL,
	[DienThoai] [varchar](13) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SoLuongMua] [int] NULL,
	[GiaBan] [int] NULL,
	[TongTien] [int] NULL,
	[TienKhachDua] [int] NULL,
	[TienThoiLai] [int] NULL,
	[LoiNhuan] [int] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 02/06/2023 5:41:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[LoaiSanPhamId] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[LoaiSanPhamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 02/06/2023 5:41:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[NhanVienId] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](100) NULL,
	[SoDienThoai] [varchar](13) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [varchar](100) NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](100) NULL,
	[BoPhanId] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[NhanVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 02/06/2023 5:41:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[SanPhamId] [int] IDENTITY(1,1) NOT NULL,
	[LoaiSanPhamId] [int] NOT NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[GiaBan] [int] NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NgayNhap] [datetime] NULL,
	[SoLuong] [int] NULL,
	[GiaVon] [int] NULL,
	[TonKho] [int] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[SanPhamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BoPhan] ON 

INSERT [dbo].[BoPhan] ([BoPhanId], [TenBoPhan]) VALUES (1, N'Quản lý')
INSERT [dbo].[BoPhan] ([BoPhanId], [TenBoPhan]) VALUES (2, N'Bán hàng')
INSERT [dbo].[BoPhan] ([BoPhanId], [TenBoPhan]) VALUES (3, N'Thu nhân')
INSERT [dbo].[BoPhan] ([BoPhanId], [TenBoPhan]) VALUES (4, N'Kho')
INSERT [dbo].[BoPhan] ([BoPhanId], [TenBoPhan]) VALUES (5, N'Bảo hành')
SET IDENTITY_INSERT [dbo].[BoPhan] OFF
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (1, 1, 1, N'Nguyễn Văn Tèo', N'iPhone 11', CAST(0x0000B00C00000000 AS DateTime), N'0919522356', N'136/5 Bến Vân Đồn Quận 4', 1, 16290000, 16290000, 17000000, 710000, 6516000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (2, 1, 2, N'Trần Văn Tý', N'iPhone 13 Pro Max', CAST(0x0000B00A00000000 AS DateTime), N'023366259', N'53 Nguyễn Ảnh Thủ', 1, 33990000, 33990000, 34000000, 10000, 13596000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (3, 1, 3, N'Lê Văn Tèo', N'iPhone 13 Pro Max Xanh Lá', CAST(0x0000B00A00000000 AS DateTime), N'0923544856', N'238/8 Trần Bình Trọng', 1, 33990000, 33990000, 40000000, 6010000, 13596000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (4, 1, 2, N'Trần Thanh Tùng', N'iPhone 13 Pro Max', CAST(0x0000B00B00000000 AS DateTime), N'334455621', N'23 Nguyễn Văn Cừ', 2, 29990000, 59980000, 60000000, 20000, 23992000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (5, 1, 11, N'Nguyễn Thành Luân', N'iPhone 13 Mini ', CAST(0x0000B00E00000000 AS DateTime), N'0926544856', N'136/85 Tân Thới Hiệp', 2, 18990000, 37980000, 40000000, 2020000, 15192000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (6, 2, 16, N'Nguyễn Thị Tú Quỳnh', N'Samsung Galaxy S22 Ultra 5G', CAST(0x0000B00B00000000 AS DateTime), N'0916544256', N'12/5 Ngô Đức Kế', 3, 30990000, 92970000, 93000000, 30000, 37188000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (7, 2, 18, N'Lê Thi Thu', N'Samsung Galaxy A52s 5G', CAST(0x0000B00E00000000 AS DateTime), N'0926544128', N'12/8 Lê Văn Lương', 4, 10690000, 42760000, 43000000, 240000, 17104000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (8, 2, 28, N'Lê Thị Như', N'Samsung Galaxy S21 FE 5G', CAST(0x0000B00E00000000 AS DateTime), N'036522345', N'7/8 Tân Chánh Hiệp', 2, 15490000, 30980000, 31000000, 20000, 12392000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (9, 3, 32, N'Trần Thanh Sơn', N'OPPO Reno7 series', CAST(0x0000B00500000000 AS DateTime), N'031177256', N'45/8 Nguyễn Thị Kiệu', 3, 10490000, 31470000, 32000000, 530000, 12588000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (10, 3, 36, N'Trần Thanh Tuấn', N'OPPO A95', CAST(0x0000B00E00000000 AS DateTime), N'0923544265', N'1/5 Lê Văn Ngung', 2, 6990000, 13980000, 14000000, 20000, 5592000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (11, 3, 42, N'Nguyễn Đình Quý', N'OPPO A16K', CAST(0x0000B00700000000 AS DateTime), N'023359863', N'1/523 Trần Bình Trọng', 1, 3290000, 3290000, 3300000, 10000, 1316000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (12, 4, 43, N'Trần Trung Chính', N'Nokia 105', CAST(0x0000B00700000000 AS DateTime), N'023658952', N'12/5 Lê Quý Đôn', 2, 300000, 600000, 700000, 100000, 240000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (13, 3, 39, N'Trần Văn Trí', N'OPPO A55', CAST(0x0000B00E00000000 AS DateTime), N'023365214', N'78/55/5 Trần Bình Trọng', 1, 4990000, 4990000, 5000000, 10000, 1996000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (14, 1, 8, N'Nguyễn Thành Phong', N'iPhone 13 ', CAST(0x0000B00E00000000 AS DateTime), N'023789536', N'25/8 Bùi Thị Xuân', 2, 24190000, 48380000, 50000000, 1620000, 19352000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (15, 2, 21, N'Nguyễn Trần Huy', N'Samsung Galaxy S21+ 5G', CAST(0x0000B00F00000000 AS DateTime), N'023659864', N'136/8 Trần Hữu Trí', 1, 20990000, 20990000, 21000000, 10000, 8396000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (16, 2, 26, N'Trần Thi Thanh Trúc', N'Samsung Galaxy S22 5G', CAST(0x0000B01200000000 AS DateTime), N'023586426', N'123/5 Tân Thới Hiệp ', 1, 21990000, 21990000, 22000000, 10000, 8796000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (17, 2, 26, N'Nguyễn Thành Phong', N'Samsung Galaxy S22 5G', CAST(0x0000AFF500000000 AS DateTime), N'02356986', N'126/5 Nguyễn Thị Búp', 3, 21990000, 65970000, 66000000, 30000, 26388000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (18, 3, 42, N'Lê Chí Thành', N'OPPO A16K', CAST(0x0000AFF600000000 AS DateTime), N'023596486', N'11 Quốc Lộ 1A', 1, 3290000, 3290000, 3300000, 10000, 1316000)
INSERT [dbo].[DonHang] ([id], [LoaiSanPhamId], [SanPhamId], [TenKhachHang], [TenSanPham], [NgayBan], [DienThoai], [DiaChi], [SoLuongMua], [GiaBan], [TongTien], [TienKhachDua], [TienThoiLai], [LoiNhuan]) VALUES (20, 10, 50, N'Nguyễn Luân', N'LG G8 ĐEN', CAST(0x0000B01300000000 AS DateTime), N'123456789', N'123/3 Dương Thị Mười Q12', 1, 3000000, 3000000, 3000000, 0, 1200000)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoai], [MoTa]) VALUES (1, N'iPhone', N'Hãng sản xuất Apple')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoai], [MoTa]) VALUES (2, N'SamSung', N'Hãng sản xuất Samsung')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoai], [MoTa]) VALUES (3, N'Oppo', N'Hãng sản xuất Oppo')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoai], [MoTa]) VALUES (4, N'Nokia', N'Hãng sản xuất Nokia')
INSERT [dbo].[LoaiSanPham] ([LoaiSanPhamId], [TenLoai], [MoTa]) VALUES (10, N'LG', N'Hãng LG sản xuất')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([NhanVienId], [TenNhanVien], [SoDienThoai], [DiaChi], [Email], [TenDangNhap], [MatKhau], [BoPhanId]) VALUES (1, N'Nguyễn Luân', N'0919422356', N'3 Tân Chánh Hiệp Q12', N'nguyenluan@gmail.com', N'admin', N'admin', 1)
INSERT [dbo].[NhanVien] ([NhanVienId], [TenNhanVien], [SoDienThoai], [DiaChi], [Email], [TenDangNhap], [MatKhau], [BoPhanId]) VALUES (2, N'Thu Thủy', N'0123456789', N'1 Cống Quỳnh Q1', N'thuthuy@gmail.com', N'thuthuy', N'123456', 2)
INSERT [dbo].[NhanVien] ([NhanVienId], [TenNhanVien], [SoDienThoai], [DiaChi], [Email], [TenDangNhap], [MatKhau], [BoPhanId]) VALUES (3, N'Hoa Hồng', N'1902365897', N'3 NguyễnVăn Cừ Q5', N'hoahong@gmail.com', N'hoahong', N'123456', 3)
INSERT [dbo].[NhanVien] ([NhanVienId], [TenNhanVien], [SoDienThoai], [DiaChi], [Email], [TenDangNhap], [MatKhau], [BoPhanId]) VALUES (4, N'Lê Long', N'2356985365', N'3 Trần Văn Giàu Q.BT', N'lelong@gmail.com', N'lelong', N'123456', 4)
INSERT [dbo].[NhanVien] ([NhanVienId], [TenNhanVien], [SoDienThoai], [DiaChi], [Email], [TenDangNhap], [MatKhau], [BoPhanId]) VALUES (5, N'Đào Huy ', N'0925687456', N'6 Nguyễn Ảnh Thủ Q12', N'daohuy@gmail.com', N'daohuy', N'123456', 5)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (1, 1, N'iPhone 11', 16290000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone1.jpg', N'Hãng sản xuất Apple', CAST(0x0000A48B00000000 AS DateTime), 5, 48870000, 4)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (2, 1, N'iPhone 13 Pro Max', 33990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone2.jpg', N'Hãng sản xuất Apple', CAST(0x0000A48C00000000 AS DateTime), 4, 67980000, 1)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (3, 1, N'iPhone 13 Pro Max Xanh Lá', 33990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone3.jpg', N'Hãng sản xuất Apple', CAST(0x0000A48D00000000 AS DateTime), 7, 118965000, 6)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (4, 1, N'iPhone 12 Pro Max', 29990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone4.jpg', N'Hãng sản xuất Apple', CAST(0x0000A4A800000000 AS DateTime), 10, 149950000, 10)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (5, 1, N'iPhone 13 Pro Max', 29990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone5.jpg', N'Hãng sản xuất Apple', CAST(0x0000A48F00000000 AS DateTime), 11, 164945000, 11)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (6, 1, N'iPhone 13 Pro Xanh Lá', 29990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone6.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49F00000000 AS DateTime), 8, 119960000, 8)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (7, 1, N'iPhone 12 Pro ', 24590000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone7.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49100000000 AS DateTime), 12, 147540000, 12)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (8, 1, N'iPhone 13 ', 24190000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone8.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49200000000 AS DateTime), 10, 120950000, 8)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (9, 1, N'iPhone 13 Xanh Lá', 24190000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone9.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49D00000000 AS DateTime), 6, 72570000, 6)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (10, 1, N'iPhone 13 Mini Xanh Lá', 21090000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone10.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49400000000 AS DateTime), 9, 94905000, 9)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (11, 1, N'iPhone 13 Mini ', 18990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone11.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49500000000 AS DateTime), 8, 75960000, 6)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (12, 1, N'iPhone 12 ', 18990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone12.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49600000000 AS DateTime), 5, 47475000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (13, 1, N'iPhone 12 Mini', 16190000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone13.jpg', N'Hãng sản xuất Apple', CAST(0x0000A49C00000000 AS DateTime), 2, 16190000, 2)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (14, 1, N'iPhone XR 128GB', 13490000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone14.jpg', N'Hãng sản xuất Apple', CAST(0x0000A4A200000000 AS DateTime), 4, 26980000, 4)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (15, 1, N'iPhone SE (2022)', 12990000, N'D:/QL_CH_DTDD/Images/cellPhone/iphone15.jpg', N'Hãng sản xuất Apple', CAST(0x0000A4A400000000 AS DateTime), 3, 19485000, 3)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (16, 2, N'Samsung Galaxy S22 Ultra 5G', 30990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung1.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A48B00000000 AS DateTime), 4, 61980000, 1)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (17, 2, N'Samsung Galaxy A03', 2990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung2.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A48C00000000 AS DateTime), 7, 10465000, 7)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (18, 2, N'Samsung Galaxy A52s 5G', 10690000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung3.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A48D00000000 AS DateTime), 9, 48105000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (19, 2, N'Samsung Galaxy Z Fold3 5G', 37990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung4.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A48E00000000 AS DateTime), 10, 198950000, 10)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (20, 2, N'
Samsung Galaxy S22+ 5G', 25990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung5.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49900000000 AS DateTime), 8, 103960000, 8)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (21, 2, N'Samsung Galaxy S21+ 5G', 20990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung6.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49000000000 AS DateTime), 8, 62970000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (22, 2, N'Samsung Galaxy S21+ 5G', 20990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung6.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49000000000 AS DateTime), 6, 62970000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (23, 2, N'Samsung Galaxy Z Flip3 5G', 20990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung7.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49B00000000 AS DateTime), 5, 52475000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (24, 2, N'Samsung Galaxy S21 5G', 16990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung8.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49200000000 AS DateTime), 2, 16990000, 2)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (25, 2, N'Samsung Galaxy S21 Ultra 5G 128GB', 25990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung9.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49300000000 AS DateTime), 11, 155940000, 11)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (26, 2, N'Samsung Galaxy S22 5G', 21990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung10.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49400000000 AS DateTime), 12, 131940000, 8)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (27, 2, N'Samsung Galaxy Note 20', 15990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung11.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49D00000000 AS DateTime), 14, 111930000, 14)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (28, 2, N'Samsung Galaxy S21 FE 5G', 15490000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung12.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A49C00000000 AS DateTime), 8, 61960000, 6)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (29, 2, N'Samsung Galaxy S20 FE', 15490000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung13.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A4A100000000 AS DateTime), 9, 69705000, 9)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (30, 2, N'Samsung Galaxy A53 5G 128GB', 9990000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung14.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A4A200000000 AS DateTime), 6, 29970000, 6)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (31, 2, N'Samsung Galaxy A52 128GB', 9290000, N'D:/QL_CH_DTDD/Images/cellPhone/samsung15.jpg', N'Hãng sản xuất SamSung', CAST(0x0000A4A400000000 AS DateTime), 8, 37160000, 8)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (32, 3, N'OPPO Reno7 series', 10490000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo1.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49000000000 AS DateTime), 10, 52450000, 7)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (33, 3, N'OPPO Reno6 series', 12990000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo2.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49100000000 AS DateTime), 15, 97425000, 15)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (34, 3, N'OPPO Reno4 Pro', 10490000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo3.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49200000000 AS DateTime), 11, 97425000, 11)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (35, 3, N'OPPO Reno5 5G', 8990000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo4.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49300000000 AS DateTime), 4, 17980000, 4)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (36, 3, N'OPPO A95', 6990000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo5.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49400000000 AS DateTime), 9, 31455000, 7)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (37, 3, N'OPPO A74 5G', 7990000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo6.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49500000000 AS DateTime), 5, 19975000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (38, 3, N'OPPO A76', 5990000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo7.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49600000000 AS DateTime), 7, 20965000, 7)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (39, 3, N'OPPO A55', 4990000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo8.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49700000000 AS DateTime), 3, 7485000, 2)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (40, 3, N'OPPO A15s', 4290000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo9.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49800000000 AS DateTime), 10, 21450000, 10)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (41, 3, N'OPPO A16', 3990000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo10.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49900000000 AS DateTime), 6, 11970000, 6)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (42, 3, N'OPPO A16K', 3290000, N'D:/QL_CH_DTDD/Images/cellPhone/oppo11.jpg', N'Hãng sản xuất Oppo', CAST(0x0000A49A00000000 AS DateTime), 8, 13160000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (43, 4, N'Nokia 105', 300000, N'D:/QL_CH_DTDD/Images/cellPhone/nokia105.jpg', N'Hãng sản xuất Nokia', CAST(0x0000AE9D00000000 AS DateTime), 10, 1500000, 8)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (44, 4, N'Nokia 110', 250000, N'D:/QL_CH_DTDD/Images/cellPhone/Nokia110.png', N'Hãng sản xuất Nokia', CAST(0x0000AE9E00000000 AS DateTime), 5, 625000, 5)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (45, 4, N'Nokia105 4G', 400000, N'D:/QL_CH_DTDD/Images/cellPhone/nokia105 4G.png', N'Hãng sản xuất Nokia', CAST(0x0000AE9D00000000 AS DateTime), 8, 1600000, 8)
INSERT [dbo].[SanPham] ([SanPhamId], [LoaiSanPhamId], [TenSanPham], [GiaBan], [HinhAnh], [MoTa], [NgayNhap], [SoLuong], [GiaVon], [TonKho]) VALUES (50, 10, N'LG G8 ĐEN', 3000000, N'D:/QL_CH_DTDD/Images/cellPhone/LG-G8-DEN.jpeg', N'Hãng LG sản xuất', CAST(0x0000B01300000000 AS DateTime), 5, 15000000, 4)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_LoaiSanPham] FOREIGN KEY([LoaiSanPhamId])
REFERENCES [dbo].[LoaiSanPham] ([LoaiSanPhamId])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_LoaiSanPham]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_SanPham] FOREIGN KEY([SanPhamId])
REFERENCES [dbo].[SanPham] ([SanPhamId])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_SanPham]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_BoPhan] FOREIGN KEY([BoPhanId])
REFERENCES [dbo].[BoPhan] ([BoPhanId])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_BoPhan]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([LoaiSanPhamId])
REFERENCES [dbo].[LoaiSanPham] ([LoaiSanPhamId])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
USE [master]
GO
ALTER DATABASE [QL_DTDD_DB] SET  READ_WRITE 
GO
