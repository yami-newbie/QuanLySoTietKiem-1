/****** Object:  Table [dbo].[BCDOANHSOTHEONGAY]    Script Date: 7/6/2021 8:31:56 PM ******/

create database QuanLySoTietKiem
use QuanLySoTietKiem

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BCDOANHSOTHEONGAY](
	[MaBaoCaoDoanhSo] [int] IDENTITY(1,1) NOT NULL,
	[Ngay] [smalldatetime] NULL,
	[LoaiTietKiem] [int] NULL,
	[TongThu] [int] NULL,
	[TongChi] [int] NULL,
	[ChenhLech] [int] NULL,
 CONSTRAINT [PK_BCDOANHSOTHEONGAY] PRIMARY KEY CLUSTERED 
(
	[MaBaoCaoDoanhSo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BCMODONGSOTHANG]    Script Date: 7/6/2021 8:31:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BCMODONGSOTHANG](
	[MaBaoCaoMoDongSo] [int] IDENTITY(1,1) NOT NULL,
	[LoaiTietKiem] [int] NULL,
	[Thang] [int] NULL,
	[Nam] [int] NULL,
 CONSTRAINT [PK_BCMODONGSOTHANG] PRIMARY KEY CLUSTERED 
(
	[MaBaoCaoMoDongSo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCNANG]    Script Date: 7/6/2021 8:31:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCNANG](
	[MaChucNang] [int] IDENTITY(1,1) NOT NULL,
	[TenChucNang] [nvarchar](40) NULL,
	[TenManHinhDuocLoad] [nvarchar](40) NULL,
	[BiXoa] [bit] NULL,
 CONSTRAINT [PK_CHUCNANG] PRIMARY KEY CLUSTERED 
(
	[MaChucNang] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTBCMODONGSOTHANG]    Script Date: 7/6/2021 8:31:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTBCMODONGSOTHANG](
	[MaCTBaoCaoMoDongSo] [int] IDENTITY(1,1) NOT NULL,
	[MaBaoCaoMoDongSo] [int] NULL,
	[Ngay] [int] NULL,
	[SoMo] [int] NULL,
	[SoDong] [int] NULL,
	[ChenhLech] [int] NULL,
 CONSTRAINT [PK_CTBCMODONGSOTHANG] PRIMARY KEY CLUSTERED 
(
	[MaCTBaoCaoMoDongSo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](40) NULL,
	[CMND] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](40) NULL,
	[BiXoa] [bit] NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAITIETKIEM]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITIETKIEM](
	[MaLoaiTietKiem] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiTietKiem] [nvarchar](40) NULL,
	[BiDong] [bit] NULL,
	[LaiSuat] [numeric](5, 4) NULL,
	[ThoiGianGoiToiThieu] [int] NULL,
	[PhaiRutToanBo] [bit] NULL,
 CONSTRAINT [PK_LOAITIETKIEM] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTietKiem] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[TenDangNhap] [nvarchar](40) NOT NULL,
	[MatKhau] [nvarchar](100) NULL,
	[MaNhom] [int] NULL,
	[TenThat] [nvarchar](40) NULL,
 CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHOMNGUOIDUNG]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMNGUOIDUNG](
	[MaNhom] [int] IDENTITY(1,1) NOT NULL,
	[TenNhom] [nvarchar](40) NULL,
 CONSTRAINT [PK_NHOMNGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[MaNhom] [int] NOT NULL,
	[MaChucNang] [int] NOT NULL,
 CONSTRAINT [PK_PHANQUYEN] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC,
	[MaChucNang] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUGOITIEN]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUGOITIEN](
	[MaPhieuGoiTien] [int] IDENTITY(1,1) NOT NULL,
	[MaSo] [int] NOT NULL,
	[NgayGoi] [smalldatetime] NULL,
	[SoTienGoi] [int] NULL,
 CONSTRAINT [PK_PHIEUGOITIEN] PRIMARY KEY CLUSTERED 
(
	[MaPhieuGoiTien] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEURUTTIEN]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEURUTTIEN](
	[MaPhieuRutTien] [int] IDENTITY(1,1) NOT NULL,
	[MaSo] [int] NOT NULL,
	[NgayRut] [smalldatetime] NULL,
	[SoTienRut] [int] NULL,
 CONSTRAINT [PK_PHIEURUTTIEN] PRIMARY KEY CLUSTERED 
(
	[MaPhieuRutTien] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOTIETKIEM]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOTIETKIEM](
	[MaSo] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiTietKiem] [int] NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[NgayMoSo] [smalldatetime] NULL,
	[SoTienGoi] [int] NULL,
	[BiDong] [bit] NULL,
	[NgayTinhLaiGanNhat] [smalldatetime] NULL,
	[LaiSuat] [numeric](5, 4) NULL,
 CONSTRAINT [PK_SOTIETKIEM] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 7/6/2021 8:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[TenThamSo] [varchar](40) NOT NULL,
	[GiaTri] [int] NULL,
 CONSTRAINT [PK_THAMSO] PRIMARY KEY CLUSTERED 
(
	[TenThamSo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHUCNANG] ADD  DEFAULT ((0)) FOR [BiXoa]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT ((0)) FOR [BiXoa]
GO
ALTER TABLE [dbo].[LOAITIETKIEM] ADD  CONSTRAINT [DF__LOAITIETK__BiXoa__6B24EA82]  DEFAULT ((0)) FOR [BiDong]
GO
ALTER TABLE [dbo].[SOTIETKIEM] ADD  DEFAULT ((0)) FOR [BiDong]
GO
ALTER TABLE [dbo].[BCDOANHSOTHEONGAY]  WITH CHECK ADD  CONSTRAINT [FK_BCDOANHSOTHEONGAY_LoaiTietKiem] FOREIGN KEY([LoaiTietKiem])
REFERENCES [dbo].[LOAITIETKIEM] ([MaLoaiTietKiem])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BCDOANHSOTHEONGAY] CHECK CONSTRAINT [FK_BCDOANHSOTHEONGAY_LoaiTietKiem]
GO
ALTER TABLE [dbo].[BCMODONGSOTHANG]  WITH CHECK ADD  CONSTRAINT [FK_BCMODONGSOTHANG_LoaiTietKiem] FOREIGN KEY([LoaiTietKiem])
REFERENCES [dbo].[LOAITIETKIEM] ([MaLoaiTietKiem])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BCMODONGSOTHANG] CHECK CONSTRAINT [FK_BCMODONGSOTHANG_LoaiTietKiem]
GO
ALTER TABLE [dbo].[CTBCMODONGSOTHANG]  WITH CHECK ADD  CONSTRAINT [FK_CTBCMODONGSOTHANG_MaBaoCaoMoDongSo] FOREIGN KEY([MaBaoCaoMoDongSo])
REFERENCES [dbo].[BCMODONGSOTHANG] ([MaBaoCaoMoDongSo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CTBCMODONGSOTHANG] CHECK CONSTRAINT [FK_CTBCMODONGSOTHANG_MaBaoCaoMoDongSo]
GO
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_MaNhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([MaNhom])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_MaNhom]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_MaChucNang] FOREIGN KEY([MaChucNang])
REFERENCES [dbo].[CHUCNANG] ([MaChucNang])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_MaChucNang]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_MaNhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([MaNhom])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_MaNhom]
GO
ALTER TABLE [dbo].[PHIEUGOITIEN]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUGOITIEN_MaSo] FOREIGN KEY([MaSo])
REFERENCES [dbo].[SOTIETKIEM] ([MaSo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PHIEUGOITIEN] CHECK CONSTRAINT [FK_PHIEUGOITIEN_MaSo]
GO
ALTER TABLE [dbo].[PHIEURUTTIEN]  WITH CHECK ADD  CONSTRAINT [FK_PHIEURUTTIEN_MaSo] FOREIGN KEY([MaSo])
REFERENCES [dbo].[SOTIETKIEM] ([MaSo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PHIEURUTTIEN] CHECK CONSTRAINT [FK_PHIEURUTTIEN_MaSo]
GO
ALTER TABLE [dbo].[SOTIETKIEM]  WITH CHECK ADD  CONSTRAINT [FK_SOTIETKIEM_MaKhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACHHANG] ([MaKhachHang])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SOTIETKIEM] CHECK CONSTRAINT [FK_SOTIETKIEM_MaKhachHang]
GO
ALTER TABLE [dbo].[SOTIETKIEM]  WITH CHECK ADD  CONSTRAINT [FK_SOTIETKIEM_MaLoaiTietKiem] FOREIGN KEY([MaLoaiTietKiem])
REFERENCES [dbo].[LOAITIETKIEM] ([MaLoaiTietKiem])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SOTIETKIEM] CHECK CONSTRAINT [FK_SOTIETKIEM_MaLoaiTietKiem]
GO
USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[LOAITIETKIEM]
           ([TenLoaiTietKiem]
       
           ,[LaiSuat]
           ,[ThoiGianGoiToiThieu]
           ,[PhaiRutToanBo]
           ,[BiDong])
     VALUES
           ('Không kì hạn'
           
           ,0.5
           ,15
           ,0
           ,0)
GO

INSERT INTO [dbo].[LOAITIETKIEM]
           ([TenLoaiTietKiem]
       
           ,[LaiSuat]
           ,[ThoiGianGoiToiThieu]
           ,[PhaiRutToanBo]
           ,[BiDong])
     VALUES
           ('Kì hạn 3 tháng'
           
           ,1.2000
           ,90
           ,1
           ,0)
GO
USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[THAMSO]
           ([TenThamSo]
           ,[GiaTri])
     VALUES
           ('SoTienGoiBanDau'
           ,1000000)
GO

USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[THAMSO]
           ([TenThamSo]
           ,[GiaTri])
     VALUES
           ('SoTienGoiThemToiThieu'
           ,100000)
GO

USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[KHACHHANG]
           ([TenKhachHang]
           ,[CMND]
           ,[DiaChi])
     VALUES
           ('Anh'
           ,'123'
           ,'123')
GO

USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[KHACHHANG]
           ([TenKhachHang]
           ,[CMND]
           ,[DiaChi])
     VALUES
           ('yami'
           ,'456'
           ,'13543')
GO

USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[NHOMNGUOIDUNG]
           ([TenNhom])
     VALUES
           ('admin')
GO

USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[NHOMNGUOIDUNG]
           ([TenNhom])
     VALUES
           ('staff')
GO

USE [QuanLySoTietKiem]
GO

INSERT INTO [dbo].[NGUOIDUNG]
           ([TenDangNhap]
           ,[MatKhau]
           ,[TenThat]
           ,[MaNhom])
     VALUES
           ('admin'
           ,'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'
           ,'admin'
           ,1)
GO