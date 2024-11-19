USE [master]
GO
/****** Object:  Database [IngenieriaRequisitos]    Script Date: 19/11/2024 22:07:59 ******/
CREATE DATABASE [IngenieriaRequisitos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IngenieriaRequisitos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\IngenieriaRequisitos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IngenieriaRequisitos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\IngenieriaRequisitos_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IngenieriaRequisitos] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IngenieriaRequisitos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IngenieriaRequisitos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET ARITHABORT OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IngenieriaRequisitos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IngenieriaRequisitos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IngenieriaRequisitos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IngenieriaRequisitos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IngenieriaRequisitos] SET  MULTI_USER 
GO
ALTER DATABASE [IngenieriaRequisitos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IngenieriaRequisitos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IngenieriaRequisitos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IngenieriaRequisitos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [IngenieriaRequisitos] SET DELAYED_DURABILITY = DISABLED 
GO
USE [IngenieriaRequisitos]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 19/11/2024 22:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[SKU] [varchar](50) NOT NULL,
	[GTIN] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Thumbnail] [image] NULL,
	[CategoriaId] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[SKU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductosRelacionados]    Script Date: 19/11/2024 22:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductosRelacionados](
	[ProductoSKU1] [varchar](50) NULL,
	[ProductoSKU2] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [IngenieriaRequisitos] SET  READ_WRITE 
GO
