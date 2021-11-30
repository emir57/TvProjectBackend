USE [TvProjectDb]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](70) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [varchar](250) NOT NULL,
	[IsMain] [bit] NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TvBrands]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TvBrands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Address] [varchar](250) NULL,
 CONSTRAINT [PK_TvBrands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TvPhotos]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TvPhotos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TvId] [int] NULL,
	[PhotoId] [int] NULL,
 CONSTRAINT [PK_TvPhotos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tvs]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tvs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](50) NULL,
	[ScreenType] [varchar](50) NOT NULL,
	[ScreenInch] [varchar](10) NOT NULL,
	[Extras] [nvarchar](50) NULL,
	[BrandId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Discount] [tinyint] NULL,
	[IsDiscount] [bit] NULL,
 CONSTRAINT [PK_Tvs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddresses]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AddressText] [nvarchar](250) NOT NULL,
	[CityId] [tinyint] NOT NULL,
 CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCreditCards]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CreditCardNumber] [varchar](16) NULL,
	[CVV] [varchar](4) NULL,
	[Date] [varchar](5) NULL,
 CONSTRAINT [PK_UserCreditCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.11.2021 17:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PasswordHash] [varbinary](500) NULL,
	[PasswordSalt] [varbinary](500) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (1, N'Adana')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (2, N'Adiyaman')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (3, N'Afyon')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (4, N'Agri')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (5, N'Amasya')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (6, N'Ankara')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (7, N'Antalya')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (8, N'Artvin')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (9, N'Aydin')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (10, N'Balikesir')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (11, N'Bilecik')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (12, N'Bingöl')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (13, N'Bitlis')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (14, N'Bolu')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (15, N'Burdur')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (16, N'Bursa')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (17, N'Çanakkale')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (18, N'Çankiri')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (19, N'Çorum')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (20, N'Denizli')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (21, N'Diyarbakir')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (22, N'Edirne')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (23, N'Elazig')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (24, N'Erzincan')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (25, N'Erzurum')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (26, N'Eskisehir')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (27, N'Gaziantep')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (28, N'Giresun')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (29, N'Gümüshane')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (30, N'Hakkari')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (31, N'Hatay')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (32, N'Isparta')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (33, N'Mersin')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (34, N'Istanbul')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (35, N'Izmir')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (36, N'Kars')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (37, N'Kastamonu')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (38, N'Kayseri')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (39, N'Kirklareli')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (40, N'Kirsehir')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (41, N'Kocaeli')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (42, N'Konya')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (43, N'Kütahya')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (44, N'Malatya')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (45, N'Manisa')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (46, N'K.Maras')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (47, N'Mardin')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (48, N'Mugla')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (49, N'Mus')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (50, N'Nevsehir')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (51, N'Nigde')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (52, N'Ordu')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (53, N'Rize')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (54, N'Sakarya')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (55, N'Samsun')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (56, N'Siirt')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (57, N'Sinop')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (58, N'Sivas')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (59, N'Tekirdag')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (60, N'Tokat')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (61, N'Trabzon')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (62, N'Tunceli')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (63, N'Sanliurfa')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (64, N'Usak')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (65, N'Van')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (66, N'Yozgat')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (67, N'Zonguldak')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (68, N'Aksaray')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (69, N'Bayburt')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (70, N'Karaman')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (71, N'Kirikkale')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (72, N'Batman')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (73, N'Sirnak')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (74, N'Bartin')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (75, N'Ardahan')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (76, N'Igdir')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (77, N'Yalova')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (78, N'Karabük')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (79, N'Kilis')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (80, N'Osmaniye')
INSERT [dbo].[Cities] ([Id], [CityName]) VALUES (81, N'Düzce')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Photos] ON 

INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (1, N'/images/m_xiaomi-mi-tv-q1-75-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (2, N'/images/m_xiaomi-mi-led-tv-4s-65-5asp-4.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (3, N'/images/m_xiaomi-mi-led-tv-4s-55-2.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (4, N'/images/m_lg-oled77g16la-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (5, N'/images/m_lg-oled48c14lb-tr-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (6, N'/images/m_samsung-43au8000-9.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (7, N'/images/m_samsung-50q60t-6.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (8, N'/images/m_philips-43pus7805-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (9, N'/images/m_philips-55pus8505-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (10, N'/images/m_philips-55oled705-12-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (11, N'/images/m_tcl-50c725-2.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (12, N'/images/m_tcl-55p725-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [ImageUrl], [IsMain]) VALUES (13, N'/images/m_sony-kd-48a9-4.jpg', 1)
SET IDENTITY_INSERT [dbo].[Photos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Editor')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[TvBrands] ON 

INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (1, N'Samsung', NULL, NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (2, N'Lg', NULL, NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (3, N'Philips', NULL, NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (4, N'TCL', NULL, NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (5, N'Sony', NULL, NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (6, N'Vestel', NULL, NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (7, N'Arçelik', NULL, NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (8, N'Xiaomi', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TvBrands] OFF
GO
SET IDENTITY_INSERT [dbo].[TvPhotos] ON 

INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (1, 1, 1)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (2, 3, 2)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (3, 6, 3)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (4, 8, 4)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (5, 10, 5)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (6, 11, 6)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (7, 12, 7)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (8, 13, 8)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (9, 15, 9)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (10, 17, 10)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (11, 18, 11)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (12, 19, 12)
INSERT [dbo].[TvPhotos] ([id], [TvId], [PhotoId]) VALUES (13, 21, 13)
SET IDENTITY_INSERT [dbo].[TvPhotos] OFF
GO
SET IDENTITY_INSERT [dbo].[Tvs] ON 

INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (1, N'Xiaomi Mi TV Q1', NULL, N'QLed', N'75"', N'30W Ses Çıkış Gücü 4K', 8, 5999.0000, 8, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (3, N'Xiaomi Mi LED TV 4S', N'L65M5-5ASP', N'Led', N'65"', N'20W Ses Çıkış Gücü 4K', 8, 4899.0000, 2, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (6, N'Xiaomi Mi LED TV 4S', N'L55M5-5ASP', N'Led', N'55"', N'20W ses Çıkış Gücü 4K', 8, 4599.0000, 2, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (8, N'LG OLED55G16La', NULL, N'Oled', N'55"', N'60W Ses Çıkış Gücü 4K', 2, 16700.0000, 5, 0)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (10, N'LG OLED48C14LB', NULL, N'Oled', N'48"', N'40W Ses Çıkış Gücü 4K', 2, 10300.0000, 3, 0)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (11, N'Samsung 43AU8000', N'UE43AU8000UXTK', N'Led', N'43"', N'20W Ses Çıkış Gücü 4K', 1, 6000.0000, 12, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (12, N'Samsung 50Q60T', N'QE50Q60TAUXTK', N'QLed', N'50"', N'20W Ses Çıkış Gücü 4K', 1, 7999.0000, 2, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (13, N'Philips 43PUS7805', N'43PUS7805/62', N'Led', N'43"', N'20W Ses Çıkış Gücü 4K Ambilight', 3, 4800.0000, 3, 0)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (15, N'Philips 50PUS8505', N'50PUS8505/62', N'Led', N'50"', N'20W Ses Çıkış Gücü 4K Ambilight', 3, 7200.0000, 4, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (17, N'Philips 55OLED705', N'55OLED705/12', N'Oled', N'55"', N'50W Ses Çıkış Gücü 4K Ambilight 3', 3, 14020.0000, 1, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (18, N'TCL 50C725', NULL, N'Led', N'50"', N'20W Ses Çıkış Gücü 4K', 4, 6200.0000, 5, 1)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (19, N'TCL 55P725', NULL, N'Led', N'55"', N'20W Ses Çıkış Gücü 4K', 4, 6800.0000, 3, 0)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount]) VALUES (21, N'Sony KE-48A9', N'KE48A9BAEP', N'Oled', N'48"', N'25W Ses Çıkış Gücü 4K', 5, 15200.0000, 4, 1)
SET IDENTITY_INSERT [dbo].[Tvs] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAddresses] ON 

INSERT [dbo].[UserAddresses] ([Id], [UserId], [AddressText], [CityId]) VALUES (1, 2, N'Çankaya', 6)
INSERT [dbo].[UserAddresses] ([Id], [UserId], [AddressText], [CityId]) VALUES (2, 2, N'Etimesgut', 6)
SET IDENTITY_INSERT [dbo].[UserAddresses] OFF
GO
SET IDENTITY_INSERT [dbo].[UserCreditCards] ON 

INSERT [dbo].[UserCreditCards] ([Id], [UserId], [CreditCardNumber], [CVV], [Date]) VALUES (1, 2, N'8888888888888888', N'403', N'01/01')
INSERT [dbo].[UserCreditCards] ([Id], [UserId], [CreditCardNumber], [CVV], [Date]) VALUES (2, 2, N'8888888888888888', N'404', N'01/01')
SET IDENTITY_INSERT [dbo].[UserCreditCards] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (2, 1, 2)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (2, N'Emir', N'Gürbüz', N'emir.gurbuz06@hotmail.com', 0x1AC603985B931713810AE89C202529285A2D733E6B93CB4D23FA68FEBEAE33A3F3C9A2FF9A5C29134536B7D971D5D8A703E598CE58F5A13499D0DFF02A83D0B7, 0x76D1879632A3ED51AA1D0CED5161ACF237651DC2A40D3501BCBD4A85624124B53A9CD16B9C7B2663B1D80EBB2C1C3EAEF88D624DE5C0107DD1773A882DB6A19B6888BA3B7153A0E249B78228729A1E275FC0098991392F91B34F411B523B8AE169931FB781500F730572F239032516A450BAC8309612AE76C1CE098A9EA8E098, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Tvs] ADD  CONSTRAINT [DF_Tvs_IsDiscount]  DEFAULT ((0)) FOR [IsDiscount]
GO
ALTER TABLE [dbo].[TvPhotos]  WITH CHECK ADD  CONSTRAINT [FK_TvPhotos_Photos] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photos] ([id])
GO
ALTER TABLE [dbo].[TvPhotos] CHECK CONSTRAINT [FK_TvPhotos_Photos]
GO
ALTER TABLE [dbo].[TvPhotos]  WITH CHECK ADD  CONSTRAINT [FK_TvPhotos_Tvs] FOREIGN KEY([TvId])
REFERENCES [dbo].[Tvs] ([Id])
GO
ALTER TABLE [dbo].[TvPhotos] CHECK CONSTRAINT [FK_TvPhotos_Tvs]
GO
ALTER TABLE [dbo].[Tvs]  WITH CHECK ADD  CONSTRAINT [FK_Tvs_TvBrands1] FOREIGN KEY([BrandId])
REFERENCES [dbo].[TvBrands] ([Id])
GO
ALTER TABLE [dbo].[Tvs] CHECK CONSTRAINT [FK_Tvs_TvBrands1]
GO
ALTER TABLE [dbo].[UserAddresses]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[UserAddresses] CHECK CONSTRAINT [FK_UserAddress_Cities]
GO
ALTER TABLE [dbo].[UserAddresses]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserAddresses] CHECK CONSTRAINT [FK_UserAddress_Users]
GO
ALTER TABLE [dbo].[UserCreditCards]  WITH CHECK ADD  CONSTRAINT [FK_UserCreditCards_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserCreditCards] CHECK CONSTRAINT [FK_UserCreditCards_Users]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
