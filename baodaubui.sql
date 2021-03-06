USE [FashionShopManagemnet]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Fullname] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](12) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](30) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILL]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [nvarchar](15) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TotalMoney] [decimal](18, 0) NOT NULL,
	[Status] [int] NOT NULL,
	[receiverAddress] [nvarchar](max) NULL,
	[ReceiverName] [nvarchar](50) NULL,
	[ReceiverPhone] [nchar](15) NULL,
 CONSTRAINT [PK_BILL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CustomerSex] [nvarchar](7) NULL,
	[CustomerAddress] [nvarchar](max) NULL,
	[CustomerEmail] [nvarchar](50) NULL,
	[CustomerPhone] [nvarchar](11) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [nvarchar](15) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductPrice] [decimal](18, 0) NOT NULL,
	[ProductImage] [nvarchar](max) NOT NULL,
	[ProductCount] [int] NULL,
	[Size] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Brand] [int] NOT NULL,
	[Sale] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[ProductCreatedDate] [date] NULL,
 CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_BRAND]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_BRAND](
	[Brand] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](50) NULL,
 CONSTRAINT [PK_PRODUCT_BRAND] PRIMARY KEY CLUSTERED 
(
	[Brand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_DETAIL]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_DETAIL](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[BillID] [int] NOT NULL,
	[ProductCount] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_PRODUCT_DETAIL] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_SALE]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_SALE](
	[Sale] [int] IDENTITY(1,1) NOT NULL,
	[SaleName] [int] NOT NULL,
 CONSTRAINT [PK_PRODUCT_SALE] PRIMARY KEY CLUSTERED 
(
	[Sale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_SIZE]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_SIZE](
	[Size] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](5) NULL,
 CONSTRAINT [PK_PRODUCT_SIZE] PRIMARY KEY CLUSTERED 
(
	[Size] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_TYPE]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_TYPE](
	[Type] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NULL,
 CONSTRAINT [PK_PRODUCT_TYPE] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REVIEWS]    Script Date: 03/07/2021 11:08:21 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REVIEWS](
	[Reviews] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Contentt] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_REVIEWS] PRIMARY KEY CLUSTERED 
(
	[Reviews] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CUSTOMER] ON 

INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [CustomerSex], [CustomerAddress], [CustomerEmail], [CustomerPhone], [Username], [Password]) VALUES (1, N'Đặng Hoàng Khang', N'Nam', N'Mỹ chánh, Ba tri, Bến Tre', N'dhkhang0103@gmail.com', N'0332283252', N'thormetal0103', N'123')
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [CustomerSex], [CustomerAddress], [CustomerEmail], [CustomerPhone], [Username], [Password]) VALUES (2, N'Nguyễn Hà Quốc Bảo', N'Nam', N'HCM', N'bao@gamil.com', N'0199999999', N'bao', N'123')
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [CustomerSex], [CustomerAddress], [CustomerEmail], [CustomerPhone], [Username], [Password]) VALUES (3, N'Nguyễn Minh Dự', N'Nam', N'Bạc Liêu', N'du@gmail.com', N'098765432', N'du123', N'123')
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [CustomerSex], [CustomerAddress], [CustomerEmail], [CustomerPhone], [Username], [Password]) VALUES (4, N'Nguyễn Minh Dự', N'Nam', N'Bạc Liêu', N'du@gmail.com', N'098765432', N'du123', N'123')
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [CustomerSex], [CustomerAddress], [CustomerEmail], [CustomerPhone], [Username], [Password]) VALUES (5, N'Nguyễn Thi Kim Yên', N'Nữ', N'Mỹ Hòa, Ba Tri, Bến Tre', N'yenmyhoa0103@gmail.com', N'0123456789', N'yenyen', N'1234')
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [CustomerSex], [CustomerAddress], [CustomerEmail], [CustomerPhone], [Username], [Password]) VALUES (6, N'khang', N'nam', N'1212', N'khang@gmail.com', N'âs', N'sa', N'123')
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [CustomerSex], [CustomerAddress], [CustomerEmail], [CustomerPhone], [Username], [Password]) VALUES (7, N'Đặng Hoàng An', N'Nam', N'Bến Tre', N'an@gmail.com', N'0123456798', N'an', N'1234')
SET IDENTITY_INSERT [dbo].[CUSTOMER] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCT] ON 

INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (1, N'A000001', N'ÁO KHUY CỔ VUÔNG', CAST(100000 AS Decimal(18, 0)), N'aocovuongkhuy.jpg', 12, 1, 1, 1, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (2, N'A000002', N'ÁO 2 DÂY CỔ TIM', CAST(100000 AS Decimal(18, 0)), N'ao2daycotim.jpg', 10, 1, 1, 1, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (4, N'A000003', N'ÁO 2 DÂY PHỐI REN', CAST(100000 AS Decimal(18, 0)), N'ao2dayphoiren.jpg', 10, 1, 1, 1, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (10, N'A000004', N'ÁO 2 DÂY VẠT KIỂU', CAST(100000 AS Decimal(18, 0)), N'ao2dayvatkieu.jpg', 10, 1, 1, 1, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (17, N'A000005', N'ÁO KIỂU HOA VĂN', CAST(200000 AS Decimal(18, 0)), N'aocroptoptayxep.jpg', 10, 1, 1, 1, 1, NULL, CAST(N'2021-06-25' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (20, N'A000006', N'ÁO SƠ MI XẾP DÁNG', CAST(200000 AS Decimal(18, 0)), N'ao2dayxepdang.jpg', 3, 2, 1, 1, 2, NULL, CAST(N'2021-06-25' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (24, N'A000007', N'ÁO CROPTOP CỔ 2 VE', CAST(200000 AS Decimal(18, 0)), N'aocroptopco2ve.jpg', 13, 1, 1, 1, 2, NULL, CAST(N'2021-06-25' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (27, N'A000008', N'ÁO CROPTOP DÂY KÉO RÚT', CAST(150000 AS Decimal(18, 0)), N'aocroptopdaykeorut.jpg', 12, 1, 1, 1, 3, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (28, N'Q000001', N'QUẦN BAGGY GẤU GẤP', CAST(120000 AS Decimal(18, 0)), N'quanbaggygaugap.jpg', 10, 2, 2, 1, 2, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (30, N'Q000002', N'QUẦN BÓ ỐNG ĐỨNG', CAST(130000 AS Decimal(18, 0)), N'quanboongdung.jpg', 4, 1, 2, 1, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (32, N'Q000003', N'QUẦN DÀI 6 KHUY', CAST(120000 AS Decimal(18, 0)), N'quandai6khuy.jpg', 10, 3, 2, 1, 3, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (33, N'Q000004', N'QUẦN DÀI CẤP LỆCH', CAST(130000 AS Decimal(18, 0)), N'quandaicaplech.jpg', 10, 2, 2, 1, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (35, N'Đ000001', N'ĐẦM ĐUÔI CÁ CHÂN CHUM', CAST(150000 AS Decimal(18, 0)), N'damduoicachanchun.jpg', 10, 1, 3, 2, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (39, N'Đ000002', N'ĐẦM XÒE 2 LỚP', CAST(200000 AS Decimal(18, 0)), N'damxoe2lop.jpg', 10, 1, 3, 2, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (40, N'Đ000003', N'ĐẦM XÒE CỔ BÈO', CAST(250000 AS Decimal(18, 0)), N'damxoecobeo.jpg', 10, 1, 3, 3, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (41, N'Đ000004', N'ĐẦM XÒE HỌA TIẾT CỔ VUÔNG', CAST(150000 AS Decimal(18, 0)), N'damxoehoatietcovuong.jpg', 15, 1, 3, 3, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (42, N'Đ000005', N'ĐẦM XÒE XẾP BÈO NHÚM', CAST(200000 AS Decimal(18, 0)), N'damxoexepbeonhum.jpg', 10, 1, 3, 3, 2, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (43, N'Đ000006', N'ĐẦM XÒE XẾP LY', CAST(250000 AS Decimal(18, 0)), N'damxoexeply.jpg', 2, 2, 3, 3, 2, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (45, N'PK00001', N'KHĂN LỤA NHỎ DÁNG DÀI', CAST(100000 AS Decimal(18, 0)), N'khanluanhodangdai.jpg', 10, 1, 4, 3, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (46, N'PK00002', N'KHĂN LỤA VUÔNG BẢN TO', CAST(10000 AS Decimal(18, 0)), N'khanluavuongbanto.jpg', 15, 1, 4, 3, 2, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (47, N'PK00003', N'MŨ CỐI RỘNG VÀNH CÓ NƠ', CAST(13000 AS Decimal(18, 0)), N'mucoirongvanhcono.jpg', 5, 1, 4, 3, 1, NULL, CAST(N'2021-06-05' AS Date))
INSERT [dbo].[PRODUCT] ([ID], [ProductID], [ProductName], [ProductPrice], [ProductImage], [ProductCount], [Size], [Type], [Brand], [Sale], [Note], [ProductCreatedDate]) VALUES (48, N'PK00004', N'MŨ NỒI THÔ', CAST(12000 AS Decimal(18, 0)), N'munoitho.jpg', 12, 1, 4, 3, 1, NULL, CAST(N'2021-06-05' AS Date))
SET IDENTITY_INSERT [dbo].[PRODUCT] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCT_BRAND] ON 

INSERT [dbo].[PRODUCT_BRAND] ([Brand], [BrandName]) VALUES (1, N'Gucci')
INSERT [dbo].[PRODUCT_BRAND] ([Brand], [BrandName]) VALUES (2, N'IVyModa')
INSERT [dbo].[PRODUCT_BRAND] ([Brand], [BrandName]) VALUES (3, N'ThorMetal')
SET IDENTITY_INSERT [dbo].[PRODUCT_BRAND] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCT_SALE] ON 

INSERT [dbo].[PRODUCT_SALE] ([Sale], [SaleName]) VALUES (1, 5)
INSERT [dbo].[PRODUCT_SALE] ([Sale], [SaleName]) VALUES (2, 10)
INSERT [dbo].[PRODUCT_SALE] ([Sale], [SaleName]) VALUES (3, 15)
INSERT [dbo].[PRODUCT_SALE] ([Sale], [SaleName]) VALUES (4, 20)
SET IDENTITY_INSERT [dbo].[PRODUCT_SALE] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCT_SIZE] ON 

INSERT [dbo].[PRODUCT_SIZE] ([Size], [SizeName]) VALUES (1, N'M')
INSERT [dbo].[PRODUCT_SIZE] ([Size], [SizeName]) VALUES (2, N'L')
INSERT [dbo].[PRODUCT_SIZE] ([Size], [SizeName]) VALUES (3, N'S')
INSERT [dbo].[PRODUCT_SIZE] ([Size], [SizeName]) VALUES (4, N'XL')
SET IDENTITY_INSERT [dbo].[PRODUCT_SIZE] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCT_TYPE] ON 

INSERT [dbo].[PRODUCT_TYPE] ([Type], [TypeName]) VALUES (1, N'Áo')
INSERT [dbo].[PRODUCT_TYPE] ([Type], [TypeName]) VALUES (2, N'Quần')
INSERT [dbo].[PRODUCT_TYPE] ([Type], [TypeName]) VALUES (3, N'Đầm')
INSERT [dbo].[PRODUCT_TYPE] ([Type], [TypeName]) VALUES (4, N'Phụ kiện')
SET IDENTITY_INSERT [dbo].[PRODUCT_TYPE] OFF
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD  CONSTRAINT [FK_BILL_CUSTOMER] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CUSTOMER] ([CustomerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BILL] CHECK CONSTRAINT [FK_BILL_CUSTOMER]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_PRODUCT_BRAND] FOREIGN KEY([Brand])
REFERENCES [dbo].[PRODUCT_BRAND] ([Brand])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_PRODUCT_BRAND]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_PRODUCT_SALE] FOREIGN KEY([Sale])
REFERENCES [dbo].[PRODUCT_SALE] ([Sale])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_PRODUCT_SALE]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_PRODUCT_SIZE] FOREIGN KEY([Size])
REFERENCES [dbo].[PRODUCT_SIZE] ([Size])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_PRODUCT_SIZE]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_PRODUCT_TYPE] FOREIGN KEY([Type])
REFERENCES [dbo].[PRODUCT_TYPE] ([Type])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_PRODUCT_TYPE]
GO
ALTER TABLE [dbo].[PRODUCT_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_DETAIL_BILL] FOREIGN KEY([BillID])
REFERENCES [dbo].[BILL] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PRODUCT_DETAIL] CHECK CONSTRAINT [FK_PRODUCT_DETAIL_BILL]
GO
ALTER TABLE [dbo].[PRODUCT_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_DETAIL_PRODUCT] FOREIGN KEY([ProductID])
REFERENCES [dbo].[PRODUCT] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PRODUCT_DETAIL] CHECK CONSTRAINT [FK_PRODUCT_DETAIL_PRODUCT]
GO
ALTER TABLE [dbo].[REVIEWS]  WITH CHECK ADD  CONSTRAINT [FK_REVIEWS_CUSTOMER] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CUSTOMER] ([CustomerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[REVIEWS] CHECK CONSTRAINT [FK_REVIEWS_CUSTOMER]
GO
ALTER TABLE [dbo].[REVIEWS]  WITH CHECK ADD  CONSTRAINT [FK_REVIEWS_PRODUCT] FOREIGN KEY([ProductID])
REFERENCES [dbo].[PRODUCT] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[REVIEWS] CHECK CONSTRAINT [FK_REVIEWS_PRODUCT]
GO
