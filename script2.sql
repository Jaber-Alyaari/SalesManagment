USE [SalesManagerDB22]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountNumber] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [date] NULL,
	[UserAdds] [int] NULL,
	[GroupID] [int] NULL,
	[CustomerID] [int] NULL,
	[SupplierID] [int] NULL,
	[State] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Describtion] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PoNumber] [nvarchar](15) NOT NULL,
	[Date] [date] NULL,
	[IsSales] [bit] NULL,
	[Customer_ID] [int] NULL,
	[Remarks] [nvarchar](50) NULL,
	[User_ID] [int] NULL,
	[SupplierID] [int] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[ProcessID] [int] IDENTITY(1,1) NOT NULL,
	[ProcessType] [nvarchar](50) NULL,
	[UserID] [int] NULL,
	[ReferenceID] [int] NULL,
	[AccountNumber] [int] NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Creditor] [bit] NULL,
	[Debtor] [bit] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[ProcessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Code] [nvarchar](50) NOT NULL,
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Unit] [nvarchar](50) NULL,
	[CatID] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/16/2023 10:07:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[StateAcount] [bit] NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230316143245_initNew', N'6.0.15')
GO
SET IDENTITY_INSERT [dbo].[AccountGroup] ON 

INSERT [dbo].[AccountGroup] ([ID], [Name], [Description]) VALUES (1, N'Sales', NULL)
INSERT [dbo].[AccountGroup] ([ID], [Name], [Description]) VALUES (2, N'Purchases', NULL)
INSERT [dbo].[AccountGroup] ([ID], [Name], [Description]) VALUES (3, N'Bank', NULL)
INSERT [dbo].[AccountGroup] ([ID], [Name], [Description]) VALUES (4, N'Box', NULL)
SET IDENTITY_INSERT [dbo].[AccountGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountNumber], [CreateDate], [UserAdds], [GroupID], [CustomerID], [SupplierID], [State]) VALUES (1, NULL, 1, 1, NULL, NULL, 0)
INSERT [dbo].[Accounts] ([AccountNumber], [CreateDate], [UserAdds], [GroupID], [CustomerID], [SupplierID], [State]) VALUES (2, NULL, 1, 2, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountNumber], [CreateDate], [UserAdds], [GroupID], [CustomerID], [SupplierID], [State]) VALUES (3, NULL, 1, 3, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountNumber], [CreateDate], [UserAdds], [GroupID], [CustomerID], [SupplierID], [State]) VALUES (4, NULL, 1, 4, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountNumber], [CreateDate], [UserAdds], [GroupID], [CustomerID], [SupplierID], [State]) VALUES (5, NULL, 1, NULL, 1, 1, NULL)
INSERT [dbo].[Accounts] ([AccountNumber], [CreateDate], [UserAdds], [GroupID], [CustomerID], [SupplierID], [State]) VALUES (6, NULL, 1, NULL, 2, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountNumber], [CreateDate], [UserAdds], [GroupID], [CustomerID], [SupplierID], [State]) VALUES (7, NULL, 1, NULL, NULL, 2, NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Name], [Describtion]) VALUES (1, N'ادوات مدرسية', N'لاشي')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [Name], [Phone], [Email], [Address]) VALUES (1, N'الحساب العام', N'99999', NULL, NULL)
INSERT [dbo].[Customers] ([ID], [Name], [Phone], [Email], [Address]) VALUES (2, N'احمد ', N'77874587', N'gg@gmail.com', NULL)
INSERT [dbo].[Customers] ([ID], [Name], [Phone], [Email], [Address]) VALUES (3, N'جابر', N'7778', N'j@g.com', NULL)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([ID], [PoNumber], [Date], [IsSales], [Customer_ID], [Remarks], [User_ID], [SupplierID]) VALUES (4, N'PO00001', NULL, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Invoice] ([ID], [PoNumber], [Date], [IsSales], [Customer_ID], [Remarks], [User_ID], [SupplierID]) VALUES (6, N'PO00002', CAST(N'2023-03-16' AS Date), 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Invoice] ([ID], [PoNumber], [Date], [IsSales], [Customer_ID], [Remarks], [User_ID], [SupplierID]) VALUES (7, N'PO00003', CAST(N'2023-03-16' AS Date), 1, NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 

INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductCode], [Quantity], [Price]) VALUES (20, 6, N'333', CAST(12.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductCode], [Quantity], [Price]) VALUES (21, 7, N'44', CAST(23.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [ProductCode], [Quantity], [Price]) VALUES (22, 7, N'333', CAST(3.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Journal] ON 

INSERT [dbo].[Journal] ([ProcessID], [ProcessType], [UserID], [ReferenceID], [AccountNumber], [Amount], [Creditor], [Debtor], [Date]) VALUES (1, N'فاتورة شراء اجل', NULL, 7, 7, CAST(1980.00 AS Decimal(18, 2)), 0, 1, CAST(N'2023-03-16' AS Date))
INSERT [dbo].[Journal] ([ProcessID], [ProcessType], [UserID], [ReferenceID], [AccountNumber], [Amount], [Creditor], [Debtor], [Date]) VALUES (2, N'فاتورة شراء اجل', NULL, 7, 2, CAST(1980.00 AS Decimal(18, 2)), 1, 0, CAST(N'2023-03-16' AS Date))
SET IDENTITY_INSERT [dbo].[Journal] OFF
GO
INSERT [dbo].[Products] ([Code], [ID], [Name], [Price], [Quantity], [Unit], [CatID]) VALUES (N'333', 0, N'دفتر', 200, 300, N'الحبة', 1)
INSERT [dbo].[Products] ([Code], [ID], [Name], [Price], [Quantity], [Unit], [CatID]) VALUES (N'44', 1, N'قلم', 60, 666, N'الحبة', NULL)
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([ID], [Name], [Phone], [Email], [Address]) VALUES (1, N'الحساب العام', NULL, NULL, NULL)
INSERT [dbo].[Suppliers] ([ID], [Name], [Phone], [Email], [Address]) VALUES (2, N'حفظ الله حسن', N'77887878787', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [Phone], [Email], [StateAcount], [UserName], [Password], [IsAdmin]) VALUES (1, N'حمود', N'8877676', N'k@f.com', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_AccountGroup_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[AccountGroup] ([ID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_AccountGroup_GroupID]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Customers_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Customers_CustomerID]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Users_UserAdds] FOREIGN KEY([UserAdds])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Users_UserAdds]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customers_Customer_ID] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customers_Customer_ID]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Users_User_ID] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Users_User_ID]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoice_InvoiceID] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoice] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoice_InvoiceID]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products_ProductCode] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[Products] ([Code])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products_ProductCode]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Accounts_AccountNumber] FOREIGN KEY([AccountNumber])
REFERENCES [dbo].[Accounts] ([AccountNumber])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Accounts_AccountNumber]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CatID] FOREIGN KEY([CatID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CatID]
GO
