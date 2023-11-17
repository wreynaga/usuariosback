USE [master]
GO
/****** Object:  Database [DemoUsuarios]    Script Date: 11/17/2023 1:12:14 PM ******/
CREATE DATABASE [DemoUsuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DemoUsuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DemoUsuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DemoUsuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DemoUsuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DemoUsuarios] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DemoUsuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DemoUsuarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DemoUsuarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DemoUsuarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DemoUsuarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DemoUsuarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [DemoUsuarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DemoUsuarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DemoUsuarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DemoUsuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DemoUsuarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DemoUsuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DemoUsuarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DemoUsuarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DemoUsuarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DemoUsuarios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DemoUsuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DemoUsuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DemoUsuarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DemoUsuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DemoUsuarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DemoUsuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DemoUsuarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DemoUsuarios] SET RECOVERY FULL 
GO
ALTER DATABASE [DemoUsuarios] SET  MULTI_USER 
GO
ALTER DATABASE [DemoUsuarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DemoUsuarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DemoUsuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DemoUsuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DemoUsuarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DemoUsuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DemoUsuarios', N'ON'
GO
ALTER DATABASE [DemoUsuarios] SET QUERY_STORE = OFF
GO
USE [DemoUsuarios]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/17/2023 1:12:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/17/2023 1:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/17/2023 1:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Correo] [nvarchar](max) NOT NULL,
	[Edad] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231117164006_InitialCreate', N'7.0.14')
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password]) VALUES (1, N'William', N'Reynaga', N'wreynaga', N'wreynaga')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Correo], [Edad]) VALUES (1, N'william', N'iwilliamxf@gmail.com', 37)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [PK_Users]    Script Date: 11/17/2023 1:12:15 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UsersGetByUserAndPassword]    Script Date: 11/17/2023 1:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersGetByUserAndPassword]
(
    @UserName varchar(50),
    @Password varchar(50)
)
AS
BEGIN
    SELECT UserId, FirstName, LastName, UserName, NULL as Password
    FROM Users
    WHERE UserName = @UserName and Password = @Password
END
GO
USE [master]
GO
ALTER DATABASE [DemoUsuarios] SET  READ_WRITE 
GO
