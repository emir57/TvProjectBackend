USE [TvProjectDb]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 28.11.2021 21:33:15 ******/
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
/****** Object:  Table [dbo].[Photos]    Script Date: 28.11.2021 21:33:15 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 28.11.2021 21:33:15 ******/
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
/****** Object:  Table [dbo].[TvBrands]    Script Date: 28.11.2021 21:33:15 ******/
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
/****** Object:  Table [dbo].[TvPhotos]    Script Date: 28.11.2021 21:33:15 ******/
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
/****** Object:  Table [dbo].[Tvs]    Script Date: 28.11.2021 21:33:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tvs](
	[Id] [int] NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[ScreenType] [varchar](50) NOT NULL,
	[ScreenInch] [varchar](10) NOT NULL,
	[Extras] [varchar](50) NULL,
	[BrandId] [int] NULL,
	[UnitPrice] [money] NOT NULL,
	[Discount] [tinyint] NULL,
 CONSTRAINT [PK_Tvs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddresses]    Script Date: 28.11.2021 21:33:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[AddressText] [nvarchar](250) NULL,
	[CityId] [tinyint] NULL,
 CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCreditCards]    Script Date: 28.11.2021 21:33:15 ******/
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
/****** Object:  Table [dbo].[UserRoles]    Script Date: 28.11.2021 21:33:15 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 28.11.2021 21:33:15 ******/
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
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Editor')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
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
