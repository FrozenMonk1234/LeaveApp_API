# LeaveApp_API with sql server script

USE [master]
GO

/****** Object:  Database [LeaveDb]    Script Date: 4/7/2022 9:33:34 AM ******/
CREATE DATABASE [LeaveDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeaveDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LeaveDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LeaveDb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LeaveDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeaveDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LeaveDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LeaveDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LeaveDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LeaveDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LeaveDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [LeaveDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [LeaveDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LeaveDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LeaveDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LeaveDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LeaveDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LeaveDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LeaveDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LeaveDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LeaveDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [LeaveDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LeaveDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LeaveDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LeaveDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LeaveDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LeaveDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LeaveDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LeaveDb] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [LeaveDb] SET  MULTI_USER 
GO

ALTER DATABASE [LeaveDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LeaveDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [LeaveDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [LeaveDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [LeaveDb] SET  READ_WRITE 
GO

USE [LeaveDb]
GO

/****** Object:  Table [dbo].[Leave]    Script Date: 4/7/2022 9:35:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [LeaveDb]
GO

/****** Object:  Table [dbo].[User]    Script Date: 4/7/2022 9:36:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[LeaveDays] [int] NULL,
	[LeaveLeft] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[Leave](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[DateCreated] [date] NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[LeaveDays] [int] NULL,
	[LeaveLeft] [int] NULL,
	[TypeOfLeave] [varchar](20) NULL,
	[Reason] [varchar](50) NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [LeaveDb]
GO

/****** Object:  Table [dbo].[TypeOfLeave]    Script Date: 4/7/2022 9:36:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TypeOfLeave](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](20) NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_TypeOfLeave] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




