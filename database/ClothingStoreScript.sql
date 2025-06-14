/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2014 (12.0.6024)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2014
    Target Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Ecommerce]    Script Date: 5/29/2025 7:31:53 AM ******/
CREATE DATABASE [Ecommerce]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ecommerce', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Ecommerce.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ecommerce_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Ecommerce_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ecommerce] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ecommerce].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ecommerce] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ecommerce] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ecommerce] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ecommerce] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ecommerce] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ecommerce] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ecommerce] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ecommerce] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ecommerce] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ecommerce] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ecommerce] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ecommerce] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ecommerce] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ecommerce] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ecommerce] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Ecommerce] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ecommerce] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ecommerce] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ecommerce] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ecommerce] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ecommerce] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ecommerce] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ecommerce] SET RECOVERY FULL 
GO
ALTER DATABASE [Ecommerce] SET  MULTI_USER 
GO
ALTER DATABASE [Ecommerce] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ecommerce] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ecommerce] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ecommerce] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Ecommerce] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ecommerce', N'ON'
GO
USE [Ecommerce]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](255) NULL,
	[NationalId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CartId] [int] NULL,
	[Quantity] [int] NULL,
	[Size] [nvarchar](20) NULL,
	[Color] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[PaymentStatus] [nvarchar](50) NULL,
	[PaymentMethod] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](10, 2) NULL,
	[Colors] [nvarchar](100) NULL,
	[CategoryId] [int] NULL,
	[Material] [nvarchar](100) NULL,
	[ImgURL] [nvarchar](255) NULL,
	[InStock] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[ProductId] [int] NULL,
	[Comment] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Phone], [Address], [NationalId]) VALUES (1, N'Laila', N'Ashraf', N'savannahmedina', N'peterthomas@hotmail.com', N'hashed_pw', N'01972263283', N'Nasr City, Cairo', N'19964878542815')
INSERT [dbo].[Admin] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Phone], [Address], [NationalId]) VALUES (2, N'Laila', N'Tarek', N'josephbrown', N'fosterbrandon@hotmail.com', N'hashed_pw', N'01122694738', N'Nasr City, Cairo', N'28422026641408')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (1, 1, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (2, 2, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (3, 3, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (4, 4, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (5, 5, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (6, 6, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (7, 7, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (8, 8, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (9, 9, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (10, 10, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (11, 11, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (12, 12, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (13, 13, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (14, 14, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (15, 15, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (16, 16, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (17, 17, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (18, 18, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
INSERT [dbo].[Cart] ([Id], [CustomerId], [CreateAt], [UpdatedAt]) VALUES (19, 19, CAST(N'2025-05-29T07:07:13.807' AS DateTime), CAST(N'2025-05-29T07:07:13.807' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (1, 19, 5, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (2, 7, 5, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (3, 20, 3, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (4, 13, 6, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (5, 16, 11, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (7, 2, 7, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (8, 11, 1, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (9, 1, 6, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (10, 16, 7, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (11, 10, 1, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (12, 4, 1, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (13, 17, 17, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (14, 13, 1, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (15, 3, 7, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (16, 14, 9, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (17, 11, 3, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (18, 14, 11, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (19, 19, 18, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (20, 4, 2, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (21, 4, 17, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (22, 15, 12, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (23, 2, 6, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (24, 19, 10, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (26, 11, 5, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (27, 1, 4, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (28, 7, 13, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (29, 1, 7, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (30, 11, 3, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (31, 11, 9, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (32, 10, 9, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (33, 6, 10, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (34, 11, 8, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (35, 20, 1, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (36, 7, 1, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (37, 3, 12, 2, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (38, 19, 3, 1, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (39, 3, 8, 3, N'L', N'Black')
INSERT [dbo].[CartItems] ([Id], [ProductId], [CartId], [Quantity], [Size], [Color]) VALUES (40, 6, 14, 3, N'L', N'Black')
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Category 1', N'Seek we than book.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'Category 2', N'Cover center ask can everyone.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (3, N'Category 3', N'Defense democratic behind serious still state.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (4, N'Category 4', N'Discover test one network agency cold.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (5, N'Category 5', N'Enough model world arrive important ok process.')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (1, N'Omar', N'Gamal', N'catherine60@yahoo.com', N'hashed_pw', N'01220237349', N'Port Janet, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (2, N'Omar', N'Sayed', N'fullercynthia@lopez.info', N'hashed_pw', N'01314353923', N'Vincentstad, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (3, N'Fatma', N'Ali', N'facosta@hardin.com', N'hashed_pw', N'01288247', N'East Dianeside, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (4, N'Mona', N'Khaled', N'tiffanymayer@hotmail.com', N'hashed_pw', N'01102890318', N'Jenniferfort, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (5, N'Omar', N'Ibrahim', N'chloecampos@gmail.com', N'hashed_pw', N'01565154962', N'Tannerside, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (6, N'Mostafa', N'Saad', N'silvaronald@jones.com', N'hashed_pw', N'01711032303', N'Pughtown, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (7, N'Mona', N'Ali', N'daniel16@hotmail.com', N'hashed_pw', N'01774673209', N'Griffinside, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (8, N'Youssef', N'Gamal', N'alyssawilliams@hotmail.com', N'hashed_pw', N'01763862500', N'Christinamouth, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (9, N'Omar', N'Mahmoud', N'theodorechapman@hotmail.com', N'hashed_pw', N'01732140873', N'Wesleymouth, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (10, N'Mohamed', N'Ali', N'thomasflores@gmail.com', N'hashed_pw', N'01169150205', N'East Shelleyville, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (11, N'Aya', N'Gamal', N'berrychristian@butler.com', N'hashed_pw', N'0182379327', N'Jimmyton, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (12, N'Fatma', N'Saad', N'ronald93@yahoo.com', N'hashed_pw', N'01701424354', N'Ellistown, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (13, N'Mona', N'Saad', N'brooke99@lucero-ellis.com', N'hashed_pw', N'01146446396', N'Meaganborough, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (14, N'Mona', N'Gamal', N'brycealexander@stewart.com', N'hashed_pw', N'01585242828', N'North Matthewville, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (15, N'Fatma', N'Gamal', N'carla08@hotmail.com', N'hashed_pw', N'01431174885', N'Port Stephanieshire, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (16, N'Ahmed', N'Ali', N'ylane@yahoo.com', N'hashed_pw', N'01416523872', N'Duranport, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (17, N'Aya', N'Saad', N'julianparker@yahoo.com', N'hashed_pw', N'01728467296', N'Gregoryville, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (18, N'Sara', N'Hassan', N'lindsey71@moreno.info', N'hashed_pw', N'01466614547', N'Lake Adamburgh, Egypt')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Email], [Password], [Phone], [Address]) VALUES (19, N'Sara', N'Saad', N'browngina@shaw.com', N'hashed_pw', N'01758669423', N'Jeffreymouth, Egypt')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (1, 1, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(319.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (2, 2, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(1389.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (3, 3, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(1348.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (4, 4, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(712.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (5, 5, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(195.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (6, 6, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(1171.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (7, 7, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(100.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (8, 8, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(920.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (9, 9, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(707.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (10, 10, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(933.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (11, 11, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(922.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (12, 12, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(1746.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (13, 13, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(734.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (14, 14, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(557.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (15, 15, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(477.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (16, 16, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(1880.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (17, 17, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(1099.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (18, 18, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(553.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
INSERT [dbo].[Order] ([Id], [CustomerId], [OrderDate], [TotalAmount], [PaymentStatus], [PaymentMethod]) VALUES (19, 19, CAST(N'2025-05-29T07:07:13.823' AS DateTime), CAST(1569.00 AS Decimal(10, 2)), N'Pending', N'CashOnDelivery')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (1, 7, 12, 1, CAST(487.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (2, 15, 16, 3, CAST(390.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (3, 10, 6, 2, CAST(439.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (4, 15, 12, 3, CAST(452.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (5, 11, 16, 3, CAST(179.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (6, 11, 20, 1, CAST(192.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (7, 3, 11, 1, CAST(158.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (8, 11, 20, 3, CAST(162.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (9, 7, 20, 3, CAST(377.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (10, 13, 8, 1, CAST(117.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (11, 11, 17, 3, CAST(398.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (13, 10, 5, 3, CAST(193.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (14, 6, 11, 3, CAST(539.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (15, 14, 2, 3, CAST(255.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (16, 16, 2, 1, CAST(312.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (17, 12, 8, 2, CAST(492.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (18, 1, 5, 2, CAST(217.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (19, 10, 8, 2, CAST(248.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (20, 11, 14, 3, CAST(416.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (21, 15, 16, 1, CAST(182.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (22, 6, 3, 1, CAST(172.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (23, 12, 17, 1, CAST(376.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (24, 8, 13, 2, CAST(578.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (25, 10, 8, 3, CAST(442.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (26, 10, 17, 1, CAST(285.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (27, 14, 2, 2, CAST(538.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (28, 14, 10, 2, CAST(238.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (29, 4, 4, 3, CAST(574.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (30, 7, 16, 3, CAST(248.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (31, 16, 10, 1, CAST(230.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (32, 10, 20, 1, CAST(487.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (33, 3, 8, 3, CAST(258.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (34, 2, 9, 3, CAST(218.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (35, 5, 12, 3, CAST(553.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (36, 11, 9, 1, CAST(331.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (37, 1, 5, 1, CAST(517.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (38, 14, 7, 2, CAST(541.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (39, 9, 2, 3, CAST(385.00 AS Decimal(10, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (40, 12, 19, 2, CAST(356.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (1, N'Product 1', N'Necessary idea kind effort city hot day. Thus care foot own. Despite but space factor.', CAST(323.00 AS Decimal(10, 2)), N'Black,White', 3, N'Cotton', N'https://picsum.photos/200?random=0', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (2, N'Product 2', N'Able either purpose drop marriage. Into three tonight. Safe around issue soon loss environment.', CAST(399.00 AS Decimal(10, 2)), N'Black,White', 1, N'Cotton', N'https://picsum.photos/200?random=1', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (3, N'Product 3', N'True small court listen outside take easy. Adult local perform late. Save computer whole suffer.', CAST(375.00 AS Decimal(10, 2)), N'Black,White', 5, N'Cotton', N'https://picsum.photos/200?random=2', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (4, N'Product 4', N'Tonight tonight common enough rest. Scientist energy role.', CAST(561.00 AS Decimal(10, 2)), N'Black,White', 3, N'Cotton', N'https://picsum.photos/200?random=3', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (5, N'Product 5', N'Key too raise visit within next. Speak plan boy. Itself foreign avoid place executive.', CAST(691.00 AS Decimal(10, 2)), N'Black,White', 5, N'Cotton', N'https://picsum.photos/200?random=4', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (6, N'Product 6', N'Later class program such our look point visit. Show available child what cause.', CAST(315.00 AS Decimal(10, 2)), N'Black,White', 1, N'Cotton', N'https://picsum.photos/200?random=5', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (7, N'Product 7', N'Out challenge often how senior particular. Tv learn important ask tonight.', CAST(406.00 AS Decimal(10, 2)), N'Black,White', 3, N'Cotton', N'https://picsum.photos/200?random=6', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (8, N'Product 8', N'Also market store evidence family assume. Development cup evening. Seven development have station.', CAST(647.00 AS Decimal(10, 2)), N'Black,White', 4, N'Cotton', N'https://picsum.photos/200?random=7', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (9, N'Product 9', N'Task develop plan research. Fish buy job fast not.', CAST(747.00 AS Decimal(10, 2)), N'Black,White', 2, N'Cotton', N'https://picsum.photos/200?random=8', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (10, N'Product 10', N'As let never walk of lot education. Heart probably technology bed worry start hundred.', CAST(636.00 AS Decimal(10, 2)), N'Black,White', 2, N'Cotton', N'https://picsum.photos/200?random=9', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (11, N'Product 11', N'Admit education certain why defense. Worry answer leg. High over that charge.', CAST(622.00 AS Decimal(10, 2)), N'Black,White', 3, N'Cotton', N'https://picsum.photos/200?random=10', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (12, N'Product 12', N'From manage history recognize.
High visit machine. Left bank force physical great everybody help.', CAST(201.00 AS Decimal(10, 2)), N'Black,White', 5, N'Cotton', N'https://picsum.photos/200?random=11', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (13, N'Product 13', N'Sell position season read fall. Need administration information officer poor.', CAST(409.00 AS Decimal(10, 2)), N'Black,White', 5, N'Cotton', N'https://picsum.photos/200?random=12', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (14, N'Product 14', N'Event during keep audience there side. Say long operation young.', CAST(772.00 AS Decimal(10, 2)), N'Black,White', 1, N'Cotton', N'https://picsum.photos/200?random=13', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (15, N'Product 15', N'State others yeah cup feeling action past eat. Couple camera network. Smile front fall win effort.', CAST(411.00 AS Decimal(10, 2)), N'Black,White', 3, N'Cotton', N'https://picsum.photos/200?random=14', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (16, N'Product 16', N'Floor coach property later. Wind billion cost very quickly artist social.', CAST(699.00 AS Decimal(10, 2)), N'Black,White', 1, N'Cotton', N'https://picsum.photos/200?random=15', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (17, N'Product 17', N'Room perhaps stuff together as kind. Center car Mr inside again.', CAST(390.00 AS Decimal(10, 2)), N'Black,White', 2, N'Cotton', N'https://picsum.photos/200?random=16', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (18, N'Product 18', N'Provide guy lead their. Age audience growth kid to what. Hope defense listen already hard.', CAST(471.00 AS Decimal(10, 2)), N'Black,White', 2, N'Cotton', N'https://picsum.photos/200?random=17', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (19, N'Product 19', N'Certain kitchen as its close data. Five avoid ago. Until put discover culture firm test this.', CAST(565.00 AS Decimal(10, 2)), N'Black,White', 1, N'Cotton', N'https://picsum.photos/200?random=18', 1)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [Colors], [CategoryId], [Material], [ImgURL], [InStock]) VALUES (20, N'Product 20', N'Seven inside city edge career behavior. Town PM but behind or. Here staff investment.', CAST(128.00 AS Decimal(10, 2)), N'Black,White', 1, N'Cotton', N'https://picsum.photos/200?random=19', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (1, 18, 15, N'Together daughter option letter probably lot.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (2, 8, 14, N'But bill certain figure hard strategy.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (3, 12, 5, N'Enough race nice face under like.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (5, 15, 2, N'Lose structure top everyone develop.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (7, 3, 4, N'Training sort energy.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (8, 8, 17, N'Crime water us each catch you.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (9, 15, 16, N'Main listen wear first unit seem other.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (10, 13, 20, N'Place vote present social look school although.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (11, 18, 2, N'Sell today reach for play suffer hold.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (12, 14, 3, N'Mission on good learn miss.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (13, 15, 4, N'Five but wonder.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (14, 5, 16, N'Seven enter bed second care when.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (15, 2, 6, N'Like central environment reflect form with goal.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (17, 12, 9, N'Present situation point surface door.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (18, 15, 5, N'If between bring.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (19, 12, 13, N'Different score risk stage who.')
INSERT [dbo].[Review] ([Id], [CustomerId], [ProductId], [Comment]) VALUES (20, 9, 18, N'Half trial charge do.')
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Cart] ([Id])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[SP_AddToCart]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddToCart]
    @CustomerId INT,
    @ProductId INT,
    @Quantity INT,
    @Size NVARCHAR(20) = NULL,
    @Color NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CartId INT;

    SELECT @CartId = Id FROM Cart WHERE CustomerId = @CustomerId;

    IF @CartId IS NULL
    BEGIN
        INSERT INTO Cart (CustomerId, CreateAt, UpdatedAt)
        VALUES (@CustomerId, GETDATE(), GETDATE());

        SET @CartId = SCOPE_IDENTITY();
    END

    IF EXISTS (SELECT 1 FROM CartItems WHERE CartId = @CartId AND ProductId = @ProductId AND Size = @Size AND Color = @Color)
    BEGIN
        UPDATE CartItems
        SET Quantity = Quantity + @Quantity
        WHERE CartId = @CartId AND ProductId = @ProductId AND Size = @Size AND Color = @Color;
    END
    ELSE
    BEGIN
        INSERT INTO CartItems (ProductId, CartId, Quantity, Size, Color)
        VALUES (@ProductId, @CartId, @Quantity, @Size, @Color);
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_Checkout]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Checkout]
    @OrderId INT,
    @PaymentMethod NVARCHAR(50)
AS
BEGIN
    UPDATE [Order]
    SET PaymentStatus = 'Paid', PaymentMethod = @PaymentMethod
    WHERE Id = @OrderId;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ClearCart]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ClearCart]
    @CustomerId INT
AS
BEGIN
    DECLARE @CartId INT;
    SELECT @CartId = Id FROM Cart WHERE CustomerId = @CustomerId;

    IF @CartId IS NOT NULL
    BEGIN
        DELETE FROM CartItems WHERE CartId = @CartId;
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_CreateReview]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CreateReview]
    @CustomerId INT,
    @ProductId INT,
    @Comment NVARCHAR(MAX)
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM OrderDetails OD
        JOIN [Order] O ON OD.OrderId = O.Id
        WHERE O.CustomerId = @CustomerId AND OD.ProductId = @ProductId
    )
    BEGIN
        INSERT INTO Review (CustomerId, ProductId, Comment)
        VALUES (@CustomerId, @ProductId, @Comment);
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_FilterProducts]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_FilterProducts]
    @CategoryId INT = NULL,
    @MinPrice DECIMAL(10,2) = NULL,
    @MaxPrice DECIMAL(10,2) = NULL,
    @Color NVARCHAR(30) = NULL
AS
BEGIN
    SELECT * FROM Product
    WHERE (@CategoryId IS NULL OR CategoryId = @CategoryId)
      AND (@MinPrice IS NULL OR Price >= @MinPrice)
      AND (@MaxPrice IS NULL OR Price <= @MaxPrice)
      AND (@Color IS NULL OR Colors LIKE '%' + @Color + '%');
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_GetCartByCustomerId]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetCartByCustomerId]
    @CustomerId INT
AS
BEGIN
    SELECT CI.Id AS CartItemId, P.Name, CI.Quantity, CI.Size, CI.Color, P.Price
    FROM CartItems CI
    JOIN Cart C ON CI.CartId = C.Id
    JOIN Product P ON CI.ProductId = P.Id
    WHERE C.CustomerId = @CustomerId;
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_GetCustomerOrders]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetCustomerOrders]
    @CustomerId INT
AS
BEGIN
    SELECT * FROM [Order]
    WHERE CustomerId = @CustomerId;
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_GetDashboardStats]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetDashboardStats]
AS
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM Customer) AS TotalCustomers,
        (SELECT COUNT(*) FROM Product) AS TotalProducts,
        (SELECT COUNT(*) FROM [Order]) AS TotalOrders,
        (SELECT ISNULL(SUM(TotalAmount), 0) FROM [Order] WHERE PaymentStatus = 'Paid') AS TotalRevenue;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductDetails]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetProductDetails]
    @ProductId INT
AS
BEGIN
    SELECT P.*, AVG(CAST(R.Id AS FLOAT)) AS Rating, COUNT(R.Id) AS TotalReviews
    FROM Product P
    LEFT JOIN Review R ON R.ProductId = P.Id
    WHERE P.Id = @ProductId
    GROUP BY P.Id, P.Name, P.Description, P.Price, P.Colors, P.CategoryId, P.Material, P.ImgURL, P.InStock;
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductReviews]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetProductReviews]
    @ProductId INT
AS
BEGIN
    SELECT R.*, C.FirstName, C.LastName
    FROM Review R
    JOIN Customer C ON R.CustomerId = C.Id
    WHERE ProductId = @ProductId;
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_InsertCustomer]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertCustomer]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(255)
AS
BEGIN
    INSERT INTO Customer (FirstName, LastName, Email, Password, Phone, Address)
    VALUES (@FirstName, @LastName, @Email, @Password, @Phone, @Address);
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_PlaceOrder]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_PlaceOrder]
    @CustomerId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CartId INT;
    DECLARE @TotalAmount DECIMAL(10,2) = 0;

    SELECT @CartId = Id FROM Cart WHERE CustomerId = @CustomerId;

    IF @CartId IS NULL RETURN;

    SELECT @TotalAmount = SUM(CI.Quantity * P.Price)
    FROM CartItems CI
    JOIN Product P ON CI.ProductId = P.Id
    WHERE CI.CartId = @CartId;

    INSERT INTO [Order] (CustomerId, OrderDate, TotalAmount, PaymentStatus, PaymentMethod)
    VALUES (@CustomerId, GETDATE(), @TotalAmount, 'Pending', 'CashOnDelivery');

    DECLARE @OrderId INT = SCOPE_IDENTITY();

    INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice)
    SELECT @OrderId, ProductId, Quantity, Price
    FROM CartItems CI
    JOIN Product P ON CI.ProductId = P.Id
    WHERE CartId = @CartId;

    DELETE FROM CartItems WHERE CartId = @CartId;
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveFromCart]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RemoveFromCart]
    @CartItemId INT
AS
BEGIN
    DELETE FROM CartItems WHERE Id = @CartItemId;
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_SearchProducts]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_SearchProducts]
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Product
    WHERE Name LIKE '%' + @SearchTerm + '%'
       OR Description LIKE '%' + @SearchTerm + '%';
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCartItem]    Script Date: 5/29/2025 7:31:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateCartItem]
    @CartItemId INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE CartItems
    SET Quantity = @Quantity
    WHERE Id = @CartItemId;
END;

GO
USE [master]
GO
ALTER DATABASE [Ecommerce] SET  READ_WRITE 
GO
