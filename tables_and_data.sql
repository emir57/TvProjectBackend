USE [TvProjectDb]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 4.06.2022 17:09:51 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 4.06.2022 17:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](max) NULL,
	[Date] [date] NULL,
	[Audit] [nchar](50) NULL,
	[UserEmail] [nchar](50) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4.06.2022 17:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TvId] [int] NOT NULL,
	[ShippedDate] [datetime] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 4.06.2022 17:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TvId] [int] NULL,
	[ImageUrl] [varchar](250) NOT NULL,
	[IsMain] [bit] NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4.06.2022 17:09:51 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TvBrands]    Script Date: 4.06.2022 17:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TvBrands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Address] [varchar](250) NULL,
 CONSTRAINT [PK_TvBrands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tvs]    Script Date: 4.06.2022 17:09:51 ******/
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
	[Stock] [tinyint] NULL,
 CONSTRAINT [PK_Tvs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddresses]    Script Date: 4.06.2022 17:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressName] [nvarchar](50) NULL,
	[UserId] [int] NOT NULL,
	[AddressText] [nvarchar](250) NOT NULL,
	[CityId] [tinyint] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCodes]    Script Date: 4.06.2022 17:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Code] [nvarchar](4) NULL,
 CONSTRAINT [PK_UserCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCreditCards]    Script Date: 4.06.2022 17:09:51 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 4.06.2022 17:09:51 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4.06.2022 17:09:51 ******/
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
	[Key] [nvarchar](250) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (1, N'{
  "Message": {
    "MethodName": "GetListTvWithPhotosAsync",
    "LogParameters": [],
    "MyProperty": 0
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (2, N'{
  "Message": {
    "MethodName": "GetByMailAsync",
    "LogParameters": [
      {
        "Name": "email",
        "Type": "System.String",
        "Value": "emir.gurbuz06@hotmail.com"
      }
    ],
    "UserEmail": null
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (3, N'{
  "Message": {
    "MethodName": "LoginAsync",
    "LogParameters": [
      {
        "Name": "userForLoginDto",
        "Type": "Core.Entities.Dtos.UserForLoginDto",
        "Value": {
          "Email": "emir.gurbuz06@hotmail.com",
          "Password": "12345"
        }
      }
    ],
    "UserEmail": null
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (4, N'{
  "Message": {
    "MethodName": "CreateAccessTokenAsync",
    "LogParameters": [
      {
        "Name": "user",
        "Type": "Core.Entities.Concrete.User",
        "Value": {
          "Id": 2,
          "FirstName": "Emir",
          "LastName": "Gürbüz",
          "Email": "emir.gurbuz06@hotmail.com",
          "PasswordHash": "yrmAG/H8pUX9+nXukKOmbpayWjBuicq6kPrFN109JeZen/oiWThycua1jHB4QLlM0QrxeVftbx8c9lLVpsoEpA==",
          "PasswordSalt": "GcV4YFES6/L7A7hD2D3qTwq7a7XCGS03yYXJis2lJeq1JjqMhd54ogsmB36mCMeDrXJfYL6NGQgyjcxIe1hUr7ENqeEO1WMkfGzUWycXldONwDGv90CftltQ31KTyMQJf4YvGPK1gOqZ6uhrkQaCUchk9Y0OeukDxy6Sf/yMcGc=",
          "Status": true,
          "Key": "db46870c-8353-404a-9f17-09f1e1c4d0a4"
        }
      }
    ],
    "UserEmail": null
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (5, N'{
  "Message": {
    "MethodName": "GetClaimsAsync",
    "LogParameters": [
      {
        "Name": "user",
        "Type": "Core.Entities.Concrete.User",
        "Value": {
          "Id": 2,
          "FirstName": "Emir",
          "LastName": "Gürbüz",
          "Email": "emir.gurbuz06@hotmail.com",
          "PasswordHash": "yrmAG/H8pUX9+nXukKOmbpayWjBuicq6kPrFN109JeZen/oiWThycua1jHB4QLlM0QrxeVftbx8c9lLVpsoEpA==",
          "PasswordSalt": "GcV4YFES6/L7A7hD2D3qTwq7a7XCGS03yYXJis2lJeq1JjqMhd54ogsmB36mCMeDrXJfYL6NGQgyjcxIe1hUr7ENqeEO1WMkfGzUWycXldONwDGv90CftltQ31KTyMQJf4YvGPK1gOqZ6uhrkQaCUchk9Y0OeukDxy6Sf/yMcGc=",
          "Status": true,
          "Key": "db46870c-8353-404a-9f17-09f1e1c4d0a4"
        }
      }
    ],
    "UserEmail": null
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (6, N'{
  "Message": {
    "MethodName": "GetListTvWithPhotosAsync",
    "LogParameters": [],
    "UserEmail": "emir.gurbuz06@hotmail.com"
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (7, N'{
  "Message": {
    "MethodName": "GetListTvWithPhotosAsync",
    "LogParameters": [],
    "UserEmail": "emir.gurbuz06@hotmail.com",
    "UserRoles": [
      "Admin",
      "User"
    ]
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (8, N'{
  "Message": {
    "MethodName": "GetListTvWithPhotosAsync",
    "LogParameters": [],
    "UserEmail": "emir.gurbuz06@hotmail.com",
    "UserRoles": [
      "Admin",
      "User"
    ]
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit], [UserEmail]) VALUES (9, N'{
  "Message": {
    "MethodName": "GetListTvWithPhotosAsync",
    "LogParameters": [],
    "UserEmail": "<Anonymous>",
    "UserRoles": []
  }
}', CAST(N'2022-03-09' AS Date), N'INFO                                              ', NULL)
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [UserId], [TvId], [ShippedDate], [TotalPrice], [AddressId]) VALUES (1, 2, 1, CAST(N'2021-12-14T00:00:00.000' AS DateTime), 5999.0000, 4)
INSERT [dbo].[Orders] ([Id], [UserId], [TvId], [ShippedDate], [TotalPrice], [AddressId]) VALUES (1016, 2, 22, CAST(N'2022-05-24T17:23:35.903' AS DateTime), 8799.0000, 1003)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Photos] ON 

INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (1, 1, N'/images/m_xiaomi-mi-tv-q1-75-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2, 3, N'/images/m_xiaomi-mi-led-tv-4s-65-5asp-4.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (3, 6, N'/images/m_xiaomi-mi-led-tv-4s-55-2.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (4, 8, N'/images/m_lg-oled77g16la-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (5, 10, N'/images/m_lg-oled48c14lb-tr-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (6, 11, N'/images/m_samsung-43au8000-9.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (7, 12, N'/images/m_samsung-50q60t-6.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (8, 13, N'/images/m_philips-43pus7805-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (9, 15, N'/images/m_philips-55pus8505-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (10, 17, N'/images/m_philips-55oled705-12-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (11, 18, N'/images/m_tcl-50c725-2.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (12, 19, N'/images/m_tcl-55p725-1.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (13, 21, N'/images/m_sony-kd-48a9-4.jpg', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2014, 1, N'/images/6059c60f8e474.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2015, 3, N'/images/Mi-TV-4S-65__11.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2016, 6, N'/images/H032421ff3e2d4a2b8c3f4cc0fc6304d9C.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2017, 10, N'/images/104723LG OLED48C14LB.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2018, 11, N'/images/43-50-2_large.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2019, 11, N'/images/Samsung-89130662-tr-crystal-uhd-au8000-ue43au8000uxtk-417027520Download-Source-zoom.png', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2020, 12, N'/images/515947363_.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2021, 12, N'/images/tr-feature----237423626.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2022, 13, N'/images/43PUS7805_62-U2P-global-001.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2023, 13, N'/images/43PUS7805_62-U1P-global-001.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2024, 15, N'/images/919OAdjt6QL.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2025, 15, N'/images/50PUS8505_62-RTP-global-001.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2026, 17, N'/images/53047064.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2027, 17, N'/images/41Rl3Eh8vES._AC_SY350_.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2028, 18, N'/images/tcl-21312847124.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2029, 18, N'/images/maxresdefault.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2030, 19, N'/images/tcl-21389217421312.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2031, 19, N'/images/617a6c6099e34.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2032, 21, N'/images/110000046676284.jpg', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2033, 21, N'/images/50636f88224d3cc022ebfe7edb53dd11.webp', 0)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2034, 22, N'/images/arcelik-8-serisi-a65-b-880-b-4k-ultra-hd-65-164-ekran-uydu-alicili-android-smart-led-tv.png', 1)
INSERT [dbo].[Photos] ([id], [TvId], [ImageUrl], [IsMain]) VALUES (2035, 22, N'/images/m_arcelik-a65-b-880-b-4.webp', 0)
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
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (7, N'Arçelik', N'', NULL)
INSERT [dbo].[TvBrands] ([Id], [Name], [PhoneNumber], [Address]) VALUES (8, N'Xiaomi', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TvBrands] OFF
GO
SET IDENTITY_INSERT [dbo].[Tvs] ON 

INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (1, N'Xiaomi Mi TV Q1', NULL, N'QLed', N'75"', N'30W Ses Çıkış Gücü 4K', 8, 5999.0000, 8, 1, 4)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (3, N'Xiaomi Mi LED TV 4S', N'L65M5-5ASP', N'Led', N'65"', N'20W Ses Çıkış Gücü 4K', 8, 4899.0000, 2, 1, 6)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (6, N'Xiaomi Mi LED TV 4S', N'L55M5-5ASP', N'Led', N'55"', N'20W ses Çıkış Gücü 4K', 8, 4599.0000, 2, 1, 3)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (8, N'LG OLED55G16La', NULL, N'Oled', N'55"', N'60W Ses Çıkış Gücü 4K', 2, 16700.0000, 5, 1, 5)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (10, N'LG OLED48C14LB', NULL, N'Oled', N'48"', N'40W Ses Çıkış Gücü 4K', 2, 10300.0000, 3, 1, 3)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (11, N'Samsung 43AU8000', N'UE43AU8000UXTK', N'Led', N'43"', N'20W Ses Çıkış Gücü 4K', 1, 6000.0000, 12, 1, 4)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (12, N'Samsung 50Q60T', N'QE50Q60TAUXTK', N'QLed', N'50"', N'20W Ses Çıkış Gücü 4K', 1, 7999.0000, 2, 1, 5)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (13, N'Philips 43PUS7805', N'43PUS7805/62', N'Led', N'43"', N'20W Ses Çıkış Gücü 4K Ambilight', 3, 4800.0000, 3, 1, 3)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (15, N'Philips 50PUS8505', N'50PUS8505/62', N'Led', N'50"', N'20W Ses Çıkış Gücü 4K Ambilight', 3, 7200.0000, 4, 1, 2)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (17, N'Philips 55OLED705', N'55OLED705/12', N'Oled', N'55"', N'50W Ses Çıkış Gücü 4K Ambilight 3', 3, 14020.0000, 1, 1, 0)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (18, N'TCL 50C725', NULL, N'Led', N'50"', N'20W Ses Çıkış Gücü 4K', 4, 6200.0000, 5, 1, 3)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (19, N'TCL 55P725', NULL, N'Led', N'55"', N'20W Ses Çıkış Gücü 4K', 4, 6800.0000, 3, 1, 2)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (21, N'Sony KE-48A9', N'KE48A9BAEP', N'Oled', N'48"', N'25W Ses Çıkış Gücü 4K', 5, 15200.0000, 4, 1, 2)
INSERT [dbo].[Tvs] ([Id], [ProductName], [ProductCode], [ScreenType], [ScreenInch], [Extras], [BrandId], [UnitPrice], [Discount], [IsDiscount], [Stock]) VALUES (22, N'Arçelik A65 B 880 Ultra', NULL, N'Led', N'65"', N'20W Ses Çıkış Gücü 4K', 7, 8799.0000, 12, 0, 4)
SET IDENTITY_INSERT [dbo].[Tvs] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAddresses] ON 

INSERT [dbo].[UserAddresses] ([Id], [AddressName], [UserId], [AddressText], [CityId], [DeletedDate]) VALUES (4, N'Ev', 2, N'Telsizler Örnek', 6, CAST(N'2022-03-20T15:28:13.357' AS DateTime))
INSERT [dbo].[UserAddresses] ([Id], [AddressName], [UserId], [AddressText], [CityId], [DeletedDate]) VALUES (5, N'Okul', 2, N'Elmadağ', 6, CAST(N'2022-04-26T21:14:24.470' AS DateTime))
INSERT [dbo].[UserAddresses] ([Id], [AddressName], [UserId], [AddressText], [CityId], [DeletedDate]) VALUES (1003, N'Ev', 2, N'Telsizler Örnek', 6, NULL)
INSERT [dbo].[UserAddresses] ([Id], [AddressName], [UserId], [AddressText], [CityId], [DeletedDate]) VALUES (2003, N'dsfdsf', 2, N'Telsizler Örnek', 6, CAST(N'2022-05-07T16:25:57.870' AS DateTime))
INSERT [dbo].[UserAddresses] ([Id], [AddressName], [UserId], [AddressText], [CityId], [DeletedDate]) VALUES (3003, N'deneme2', 2, N'asd', 6, CAST(N'2022-05-30T14:52:16.700' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserAddresses] OFF
GO
SET IDENTITY_INSERT [dbo].[UserCodes] ON 

INSERT [dbo].[UserCodes] ([Id], [UserId], [Code]) VALUES (2, 2, N'2581')
SET IDENTITY_INSERT [dbo].[UserCodes] OFF
GO
SET IDENTITY_INSERT [dbo].[UserCreditCards] ON 

INSERT [dbo].[UserCreditCards] ([Id], [UserId], [CreditCardNumber], [CVV], [Date]) VALUES (5, 2, N'5444444444444444', N'123', N'02/23')
INSERT [dbo].[UserCreditCards] ([Id], [UserId], [CreditCardNumber], [CVV], [Date]) VALUES (6, 2, N'4444444444444444', N'222', N'08/29')
SET IDENTITY_INSERT [dbo].[UserCreditCards] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (2, 1, 2)
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (5, 3, 1005)
INSERT [dbo].[UserRoles] ([Id], [RoleId], [UserId]) VALUES (4006, 3, 2)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status], [Key]) VALUES (2, N'Emir', N'Gürbüz', N'emir.gurbuz06@hotmail.com', 0xCAB9801BF1FCA545FDFA75EE90A3A66E96B25A306E89CABA90FAC5375D3D25E65E9FFA2259387272E6B58C707840B94CD10AF17957ED6F1F1CF652D5A6CA04A4, 0x19C578605112EBF2FB03B843D83DEA4F0ABB6BB5C2192D37C985C98ACDA525EAB5263A8C85DE78A20B26077EA608C783AD725F60BE8D1908328DCC487B5854AFB10DA9E10ED563247C6CD45B271795D38DC031AFF7409FB65B50DF5293C8C4097F862F18F2B580EA99EAE86B91068251C864F58D0E7AE903C72E927FFC8C7067, 1, N'db46870c-8353-404a-9f17-09f1e1c4d0a4')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status], [Key]) VALUES (1005, N'DenemeAd', N'DenemeSoyad', N'deneme@hotmail.com', 0x3B0B45175F057196FCD5F59D3D8F621EE663AAF342DE7928F7E6D16D0BEFBBC98B1E54C313F5CC92734720E8C6A85A755C301D76B9C27077EE0AB162578E38ED, 0x2EF320DBE0124421DB82A5751175B00AE0988A30C055002F178AE5B4030F6A5924AD4D32EFBBA494FAFE46B05CCB7F2E9E74DF8E55D40CF0325786FDC54BB255011B964BA2BB716AC05B5998D7EB12E4B8FD2FF4D0ED938D8CDFAE890544371D535DB55CB2398C7F3CBCE301EEDDA81E3537757A0D3050F2DCE13FDCD1B66265, 1, NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status], [Key]) VALUES (2006, N'Emir', N'Gürbüz', N'emir.gurbuz066@hotmail.com', 0x8A94AE2B94EAF73F65A3F3FDAAC128958E9F893A12474B666E4F0A4E9F16C617F42F535817D99AB3815532825BAC9B775583C97E743CAB54851761DA19F02831, 0x526444DF2C48AEA9BFC1A673224E3710094D38BE649F9F1AA64AFFCE6D1AB18160C72599D8BFB57084AFA12CA454339823062713B2EB43713C666779363E826341EB2C4D5CF91BE56851008289C3DF9E649D22D2B3C1BFCD2E6E3C257D78AA871EBFFC6E231053CDFE353141CC3C1B6238E4CE98557DE2366EE65A8FBAC48C16, 1, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Photos] ADD  CONSTRAINT [DF_Photos_IsMain]  DEFAULT ((0)) FOR [IsMain]
GO
ALTER TABLE [dbo].[Tvs] ADD  CONSTRAINT [DF_Tvs_IsDiscount]  DEFAULT ((0)) FOR [IsDiscount]
GO
ALTER TABLE [dbo].[UserAddresses] ADD  CONSTRAINT [DF_UserAddresses_DeletedDate]  DEFAULT (NULL) FOR [DeletedDate]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Tvs] FOREIGN KEY([TvId])
REFERENCES [dbo].[Tvs] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Tvs]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_Photos_Tvs] FOREIGN KEY([TvId])
REFERENCES [dbo].[Tvs] ([Id])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_Photos_Tvs]
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
