USE [master]
GO
/****** Object:  Database [ferreteria_db]    Script Date: 1/06/2022 22:48:50 ******/
CREATE DATABASE [ferreteria_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ferreteria_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ferreteria_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ferreteria_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ferreteria_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ferreteria_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ferreteria_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ferreteria_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ferreteria_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ferreteria_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ferreteria_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ferreteria_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [ferreteria_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ferreteria_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ferreteria_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ferreteria_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ferreteria_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ferreteria_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ferreteria_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ferreteria_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ferreteria_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ferreteria_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ferreteria_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ferreteria_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ferreteria_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ferreteria_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ferreteria_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ferreteria_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ferreteria_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ferreteria_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ferreteria_db] SET  MULTI_USER 
GO
ALTER DATABASE [ferreteria_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ferreteria_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ferreteria_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ferreteria_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ferreteria_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ferreteria_db] SET QUERY_STORE = OFF
GO
USE [ferreteria_db]
GO
/****** Object:  Table [dbo].[buy]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[buy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[date] [date] NULL,
	[total] [numeric](10, 2) NULL,
	[no_doc] [varchar](50) NULL,
	[serie] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[buy_det]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[buy_det](
	[id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[price] [numeric](10, 2) NULL,
	[units] [int] NULL,
	[discount] [numeric](10, 2) NULL,
	[sub_total] [numeric](10, 2) NULL,
 CONSTRAINT [pk_buy_det] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cellar]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cellar](
	[id] [int] NOT NULL,
	[name] [varchar](60) NOT NULL,
	[address] [varchar](80) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cellar_transfer]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cellar_transfer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[no_transfer] [varchar](50) NOT NULL,
	[cellar_origin_id] [int] NOT NULL,
	[cellar_destination_id] [int] NOT NULL,
	[date] [date] NULL,
 CONSTRAINT [pk_id_cell_trans] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cellar_transfer_det]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cellar_transfer_det](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cellar_trans_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[units] [int] NULL,
 CONSTRAINT [pk_cellar_trans_det] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nit] [varchar](15) NOT NULL,
	[name] [varchar](75) NOT NULL,
	[address] [varchar](100) NULL,
	[phone] [varchar](15) NULL,
	[category_id] [int] NOT NULL,
 CONSTRAINT [pk_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer_cat]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_cat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventory]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[cellar_id] [int] NOT NULL,
	[buy_id] [int] NULL,
	[sale_id] [int] NULL,
	[cellar_trans_id] [int] NULL,
	[units] [int] NULL,
 CONSTRAINT [pk_inventory_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[measure]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[measure](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[min_max_prod]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[min_max_prod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[minimm] [int] NOT NULL,
	[maximum] [int] NOT NULL,
	[cellar_id] [int] NOT NULL,
 CONSTRAINT [pk_min_max] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sku] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[description] [varchar](100) NULL,
	[buy_price] [numeric](10, 2) NULL,
	[stock] [int] NULL,
	[category_id] [int] NULL,
	[status_id] [tinyint] NULL,
	[measure_id] [int] NULL,
 CONSTRAINT [pk_id_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_cat]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_cat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_sta]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_sta](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol_user]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sale]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[tran_status_id] [tinyint] NOT NULL,
	[date] [date] NULL,
	[total] [numeric](10, 2) NULL,
	[no_doc] [varchar](50) NULL,
	[serie] [varchar](50) NULL,
 CONSTRAINT [pk_sale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sale_det]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale_det](
	[id_sale] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[price] [numeric](10, 2) NOT NULL,
	[units] [int] NOT NULL,
	[discount] [numeric](10, 2) NULL,
	[sub_total] [numeric](10, 2) NULL,
 CONSTRAINT [pk_sale_det] PRIMARY KEY CLUSTERED 
(
	[id_sale] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[supplier]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nit] [varchar](15) NOT NULL,
	[name] [varchar](75) NOT NULL,
	[address] [varchar](100) NULL,
	[phone] [varchar](15) NULL,
	[category_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[supplier_cat]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier_cat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tran_status]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tran_status](
	[id] [tinyint] NOT NULL,
	[description] [varchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type_document]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type_document](
	[id] [int] NOT NULL,
	[name] [varchar](75) NOT NULL,
 CONSTRAINT [pk_type_doc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_sys]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_sys](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](100) NULL,
	[rol_id] [int] NULL,
	[email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[buy] ON 

INSERT [dbo].[buy] ([id], [supplier_id], [user_id], [date], [total], [no_doc], [serie]) VALUES (2, 1, 1, CAST(N'2004-01-22' AS Date), CAST(200.00 AS Numeric(10, 2)), NULL, NULL)
INSERT [dbo].[buy] ([id], [supplier_id], [user_id], [date], [total], [no_doc], [serie]) VALUES (3, 1, 1, CAST(N'2004-01-22' AS Date), CAST(300.00 AS Numeric(10, 2)), NULL, NULL)
INSERT [dbo].[buy] ([id], [supplier_id], [user_id], [date], [total], [no_doc], [serie]) VALUES (4, 1, 1, CAST(N'2004-01-22' AS Date), CAST(400.00 AS Numeric(10, 2)), NULL, NULL)
INSERT [dbo].[buy] ([id], [supplier_id], [user_id], [date], [total], [no_doc], [serie]) VALUES (5, 1, 1, CAST(N'2004-01-22' AS Date), CAST(500.00 AS Numeric(10, 2)), NULL, NULL)
INSERT [dbo].[buy] ([id], [supplier_id], [user_id], [date], [total], [no_doc], [serie]) VALUES (6, 1, 1, CAST(N'2004-01-22' AS Date), CAST(600.00 AS Numeric(10, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[buy] OFF
GO
INSERT [dbo].[buy_det] ([id], [product_id], [price], [units], [discount], [sub_total]) VALUES (2, 3, CAST(100.00 AS Numeric(10, 2)), 3, CAST(0.00 AS Numeric(10, 2)), CAST(300.00 AS Numeric(10, 2)))
INSERT [dbo].[buy_det] ([id], [product_id], [price], [units], [discount], [sub_total]) VALUES (3, 3, CAST(100.00 AS Numeric(10, 2)), 3, CAST(0.00 AS Numeric(10, 2)), CAST(300.00 AS Numeric(10, 2)))
INSERT [dbo].[buy_det] ([id], [product_id], [price], [units], [discount], [sub_total]) VALUES (3, 5, CAST(50.00 AS Numeric(10, 2)), 2, CAST(10.00 AS Numeric(10, 2)), CAST(90.00 AS Numeric(10, 2)))
GO
INSERT [dbo].[cellar] ([id], [name], [address]) VALUES (1, N'Bodega 1', N'Guatemala, Guatemala')
INSERT [dbo].[cellar] ([id], [name], [address]) VALUES (2, N'Bodega 2', N'Suchitepequez')
GO
SET IDENTITY_INSERT [dbo].[cellar_transfer] ON 

INSERT [dbo].[cellar_transfer] ([id], [no_transfer], [cellar_origin_id], [cellar_destination_id], [date]) VALUES (2, N'0000002', 2, 1, CAST(N'2022-05-16' AS Date))
SET IDENTITY_INSERT [dbo].[cellar_transfer] OFF
GO
SET IDENTITY_INSERT [dbo].[cellar_transfer_det] ON 

INSERT [dbo].[cellar_transfer_det] ([id], [cellar_trans_id], [product_id], [units]) VALUES (1, 2, 3, 10)
INSERT [dbo].[cellar_transfer_det] ([id], [cellar_trans_id], [product_id], [units]) VALUES (2, 2, 5, 5)
INSERT [dbo].[cellar_transfer_det] ([id], [cellar_trans_id], [product_id], [units]) VALUES (3, 2, 7, 15)
SET IDENTITY_INSERT [dbo].[cellar_transfer_det] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([id], [nit], [name], [address], [phone], [category_id]) VALUES (1, N'1111111', N'cliente 1', N'string', N'string', 1)
INSERT [dbo].[customer] ([id], [nit], [name], [address], [phone], [category_id]) VALUES (4, N'3425', N'Pedro', N'gasee', N'1234523', 1)
INSERT [dbo].[customer] ([id], [nit], [name], [address], [phone], [category_id]) VALUES (7, N'1494', N'Cliente editado', N'Guatemala', N'1234-4834', 4)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[customer_cat] ON 

INSERT [dbo].[customer_cat] ([id], [name]) VALUES (1, N'Clientes locales')
INSERT [dbo].[customer_cat] ([id], [name]) VALUES (2, N'Clientes extranjerossssssssssss')
INSERT [dbo].[customer_cat] ([id], [name]) VALUES (4, N'nueva categoriaaaaaaaaaa')
SET IDENTITY_INSERT [dbo].[customer_cat] OFF
GO
SET IDENTITY_INSERT [dbo].[inventory] ON 

INSERT [dbo].[inventory] ([id], [product_id], [cellar_id], [buy_id], [sale_id], [cellar_trans_id], [units]) VALUES (1, 0, 0, 0, 0, 0, 30)
INSERT [dbo].[inventory] ([id], [product_id], [cellar_id], [buy_id], [sale_id], [cellar_trans_id], [units]) VALUES (2, 5, 1, 3, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[measure] ON 

INSERT [dbo].[measure] ([id], [name]) VALUES (1, N'DEFAULT')
INSERT [dbo].[measure] ([id], [name]) VALUES (2, N'cm')
INSERT [dbo].[measure] ([id], [name]) VALUES (3, N'mm')
INSERT [dbo].[measure] ([id], [name]) VALUES (5, N'nueva medida')
INSERT [dbo].[measure] ([id], [name]) VALUES (6, N'otra medida')
INSERT [dbo].[measure] ([id], [name]) VALUES (7, N'MEDIDA EDITADA')
SET IDENTITY_INSERT [dbo].[measure] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (3, N'C-001-2828', N'Piocha', N'Picha nueva', CAST(500.00 AS Numeric(10, 2)), 20, 1, 2, 3)
INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (5, N'string', N'string', N'string', CAST(200.00 AS Numeric(10, 2)), 200, 1, 1, 1)
INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (7, N'string4', N'string 4', N'string', CAST(0.00 AS Numeric(10, 2)), 0, 2, 2, 1)
INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (9, N'Sku001', N'Clavos', N'nueva descripción', CAST(15.00 AS Numeric(10, 2)), 20, 1, 1, 1)
INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (10, N'Sku002', N'Calvoss  2', N'string', CAST(10.00 AS Numeric(10, 2)), NULL, 1, 1, 1)
INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (13, N'Product11', N'Galon de tinner', N'Galon de tinner', CAST(20.00 AS Numeric(10, 2)), 5, 1, 1, 1)
INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (16, N'BR-001', N'Brocha 5 pulgadas', N'Brocha 5 pulgadas para pintar', CAST(0.00 AS Numeric(10, 2)), NULL, 1, 1, 1)
INSERT [dbo].[product] ([id], [sku], [name], [description], [buy_price], [stock], [category_id], [status_id], [measure_id]) VALUES (33, N'VP-001', N'nuevo producto', N'descripcion nueva', CAST(20.00 AS Numeric(10, 2)), NULL, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[product] OFF
GO
SET IDENTITY_INSERT [dbo].[product_cat] ON 

INSERT [dbo].[product_cat] ([id], [name]) VALUES (1, N'DEFAULT')
INSERT [dbo].[product_cat] ([id], [name]) VALUES (2, N'Herramientas de trabajo')
INSERT [dbo].[product_cat] ([id], [name]) VALUES (3, N'Tornillos')
INSERT [dbo].[product_cat] ([id], [name]) VALUES (4, N'ClavosSSSS')
SET IDENTITY_INSERT [dbo].[product_cat] OFF
GO
SET IDENTITY_INSERT [dbo].[product_sta] ON 

INSERT [dbo].[product_sta] ([id], [name]) VALUES (1, N'alta')
INSERT [dbo].[product_sta] ([id], [name]) VALUES (2, N'baja')
SET IDENTITY_INSERT [dbo].[product_sta] OFF
GO
SET IDENTITY_INSERT [dbo].[rol_user] ON 

INSERT [dbo].[rol_user] ([id], [name]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[rol_user] OFF
GO
SET IDENTITY_INSERT [dbo].[supplier] ON 

INSERT [dbo].[supplier] ([id], [nit], [name], [address], [phone], [category_id]) VALUES (1, N'17274', N'Carlos Ramos', N'Guatemala', N'87654321', 1)
INSERT [dbo].[supplier] ([id], [nit], [name], [address], [phone], [category_id]) VALUES (4, N'43213', N'Carlos Franco', N'Guatemala', N'1234-1883', 2)
INSERT [dbo].[supplier] ([id], [nit], [name], [address], [phone], [category_id]) VALUES (8, N'124', N'nuevo cliente', N'guatemala', N'1231244', 1)
SET IDENTITY_INSERT [dbo].[supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[supplier_cat] ON 

INSERT [dbo].[supplier_cat] ([id], [name]) VALUES (1, N'departamental')
INSERT [dbo].[supplier_cat] ([id], [name]) VALUES (2, N'extranjero USA')
INSERT [dbo].[supplier_cat] ([id], [name]) VALUES (4, N'nueva categoria de proveedor')
SET IDENTITY_INSERT [dbo].[supplier_cat] OFF
GO
INSERT [dbo].[tran_status] ([id], [description]) VALUES (0, N'Generated2')
GO
SET IDENTITY_INSERT [dbo].[user_sys] ON 

INSERT [dbo].[user_sys] ([id], [username], [password], [rol_id], [email]) VALUES (1, N'admin', N'1234', 1, NULL)
INSERT [dbo].[user_sys] ([id], [username], [password], [rol_id], [email]) VALUES (2, N'Pasante', N'4321', 1, NULL)
INSERT [dbo].[user_sys] ([id], [username], [password], [rol_id], [email]) VALUES (3, N'prueba', N'123456', 1, NULL)
INSERT [dbo].[user_sys] ([id], [username], [password], [rol_id], [email]) VALUES (4, N'nuevo', N'654321', 1, N'user@example.com')
INSERT [dbo].[user_sys] ([id], [username], [password], [rol_id], [email]) VALUES (5, N'nuevo', N'654321', 1, N'user@example.com')
SET IDENTITY_INSERT [dbo].[user_sys] OFF
GO
ALTER TABLE [dbo].[buy]  WITH CHECK ADD  CONSTRAINT [fk_buy_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[supplier] ([id])
GO
ALTER TABLE [dbo].[buy] CHECK CONSTRAINT [fk_buy_supplier]
GO
ALTER TABLE [dbo].[buy]  WITH CHECK ADD  CONSTRAINT [fk_user_buy] FOREIGN KEY([user_id])
REFERENCES [dbo].[user_sys] ([id])
GO
ALTER TABLE [dbo].[buy] CHECK CONSTRAINT [fk_user_buy]
GO
ALTER TABLE [dbo].[buy_det]  WITH CHECK ADD  CONSTRAINT [fk_id_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[buy_det] CHECK CONSTRAINT [fk_id_product]
GO
ALTER TABLE [dbo].[cellar_transfer]  WITH CHECK ADD  CONSTRAINT [fk_cellar_dest_id] FOREIGN KEY([cellar_destination_id])
REFERENCES [dbo].[cellar] ([id])
GO
ALTER TABLE [dbo].[cellar_transfer] CHECK CONSTRAINT [fk_cellar_dest_id]
GO
ALTER TABLE [dbo].[cellar_transfer]  WITH CHECK ADD  CONSTRAINT [fk_cellar_origin_id] FOREIGN KEY([cellar_origin_id])
REFERENCES [dbo].[cellar] ([id])
GO
ALTER TABLE [dbo].[cellar_transfer] CHECK CONSTRAINT [fk_cellar_origin_id]
GO
ALTER TABLE [dbo].[cellar_transfer_det]  WITH CHECK ADD  CONSTRAINT [fk_cellar_trans_id] FOREIGN KEY([cellar_trans_id])
REFERENCES [dbo].[cellar_transfer] ([id])
GO
ALTER TABLE [dbo].[cellar_transfer_det] CHECK CONSTRAINT [fk_cellar_trans_id]
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD  CONSTRAINT [fk_customer_cat] FOREIGN KEY([category_id])
REFERENCES [dbo].[customer_cat] ([id])
GO
ALTER TABLE [dbo].[customer] CHECK CONSTRAINT [fk_customer_cat]
GO
ALTER TABLE [dbo].[min_max_prod]  WITH CHECK ADD  CONSTRAINT [fk_min_max_cellar] FOREIGN KEY([cellar_id])
REFERENCES [dbo].[cellar] ([id])
GO
ALTER TABLE [dbo].[min_max_prod] CHECK CONSTRAINT [fk_min_max_cellar]
GO
ALTER TABLE [dbo].[min_max_prod]  WITH CHECK ADD  CONSTRAINT [pk_prod_min_max] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[min_max_prod] CHECK CONSTRAINT [pk_prod_min_max]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[product_cat] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_category]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_measure] FOREIGN KEY([measure_id])
REFERENCES [dbo].[measure] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_measure]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[product_sta] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_status]
GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [fk_sale_customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [fk_sale_customer]
GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [fk_sale_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user_sys] ([id])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [fk_sale_user]
GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [fk_tran_status] FOREIGN KEY([tran_status_id])
REFERENCES [dbo].[tran_status] ([id])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [fk_tran_status]
GO
ALTER TABLE [dbo].[supplier]  WITH CHECK ADD  CONSTRAINT [fk_suppplier_cat] FOREIGN KEY([category_id])
REFERENCES [dbo].[supplier_cat] ([id])
GO
ALTER TABLE [dbo].[supplier] CHECK CONSTRAINT [fk_suppplier_cat]
GO
ALTER TABLE [dbo].[user_sys]  WITH CHECK ADD  CONSTRAINT [fk_rol_user] FOREIGN KEY([rol_id])
REFERENCES [dbo].[rol_user] ([id])
GO
ALTER TABLE [dbo].[user_sys] CHECK CONSTRAINT [fk_rol_user]
GO
/****** Object:  StoredProcedure [dbo].[buy_delete_register]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[buy_delete_register] @id int
AS
	DELETE FROM buy_det WHERE id = @id;
	DELETE FROM buy WHERE id = @id;
GO
/****** Object:  StoredProcedure [dbo].[insert_buy_detail]    Script Date: 1/06/2022 22:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[insert_buy_detail] 
@id int,
@id_product int,
@price numeric(10,2),
@units int,
@discount numeric(10,2)
AS
BEGIN
	DECLARE @sub_total numeric(10,2);
	DECLARE @exist int; 
	SET @sub_total = @price * @units - @discount;
	SELECT @exist = COUNT(*) FROM buy WHERE id = @id; -- verifica si hay una compra con ese id

	IF @exist != 0
	BEGIN
		INSERT INTO buy_det(id, id_product, price, units, discount, sub_total) 
			VALUES(@id, @id_product, @price, @units, @discount, @sub_total);
	END
END
GO
USE [master]
GO
ALTER DATABASE [ferreteria_db] SET  READ_WRITE 
GO
