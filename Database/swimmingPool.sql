USE [master]
GO
/****** Object:  Database [swimmingPool]    Script Date: 8/16/2019 9:12:08 PM ******/
CREATE DATABASE [swimmingPool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'swimmingPool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SNO7Y\MSSQL\DATA\swimmingPool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'swimmingPool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SNO7Y\MSSQL\DATA\swimmingPool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [swimmingPool] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [swimmingPool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [swimmingPool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [swimmingPool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [swimmingPool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [swimmingPool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [swimmingPool] SET ARITHABORT OFF 
GO
ALTER DATABASE [swimmingPool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [swimmingPool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [swimmingPool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [swimmingPool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [swimmingPool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [swimmingPool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [swimmingPool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [swimmingPool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [swimmingPool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [swimmingPool] SET  ENABLE_BROKER 
GO
ALTER DATABASE [swimmingPool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [swimmingPool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [swimmingPool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [swimmingPool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [swimmingPool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [swimmingPool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [swimmingPool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [swimmingPool] SET RECOVERY FULL 
GO
ALTER DATABASE [swimmingPool] SET  MULTI_USER 
GO
ALTER DATABASE [swimmingPool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [swimmingPool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [swimmingPool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [swimmingPool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [swimmingPool] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'swimmingPool', N'ON'
GO
ALTER DATABASE [swimmingPool] SET QUERY_STORE = OFF
GO
USE [swimmingPool]
GO
/****** Object:  Table [dbo].[activity]    Script Date: 8/16/2019 9:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[activity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 8/16/2019 9:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ssna] [nvarchar](14) NOT NULL,
	[first_name] [nvarchar](255) NOT NULL,
	[last_name] [nvarchar](255) NOT NULL,
	[Number_of_member] [int] NULL,
	[phone] [nvarchar](11) NOT NULL,
	[strat_subscription] [date] NOT NULL,
	[Num_of_receipt] [nvarchar](max) NULL,
	[school_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ssna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer_activity]    Script Date: 8/16/2019 9:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_activity](
	[customer_ssna] [nvarchar](14) NOT NULL,
	[activity_ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[school]    Script Date: 8/16/2019 9:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[school](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[number_type] [int] NOT NULL,
	[activity_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[school_trainer]    Script Date: 8/16/2019 9:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[school_trainer](
	[trainer_ID] [int] NOT NULL,
	[school_ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trainer]    Script Date: 8/16/2019 9:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trainer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ssna] [nvarchar](14) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[salary] [decimal](18, 0) NOT NULL,
	[number_customer] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ssna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type_school]    Script Date: 8/16/2019 9:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type_school](
	[number] [int] IDENTITY(1,1) NOT NULL,
	[period] [decimal](18, 0) NULL,
	[time] [time](7) NOT NULL,
	[num_of_intervals] [int] NOT NULL,
	[value_in] [decimal](18, 0) NULL,
	[value_out] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD FOREIGN KEY([school_ID])
REFERENCES [dbo].[school] ([ID])
GO
ALTER TABLE [dbo].[customer_activity]  WITH CHECK ADD FOREIGN KEY([activity_ID])
REFERENCES [dbo].[activity] ([ID])
GO
ALTER TABLE [dbo].[customer_activity]  WITH CHECK ADD FOREIGN KEY([customer_ssna])
REFERENCES [dbo].[customer] ([ssna])
GO
ALTER TABLE [dbo].[school]  WITH CHECK ADD FOREIGN KEY([activity_ID])
REFERENCES [dbo].[activity] ([ID])
GO
ALTER TABLE [dbo].[school]  WITH CHECK ADD FOREIGN KEY([number_type])
REFERENCES [dbo].[type_school] ([number])
GO
ALTER TABLE [dbo].[school_trainer]  WITH CHECK ADD FOREIGN KEY([school_ID])
REFERENCES [dbo].[school] ([ID])
GO
ALTER TABLE [dbo].[school_trainer]  WITH CHECK ADD FOREIGN KEY([trainer_ID])
REFERENCES [dbo].[trainer] ([ID])
GO
USE [master]
GO
ALTER DATABASE [swimmingPool] SET  READ_WRITE 
GO
