USE [master]
GO
/****** Object:  Database [librarymanagement]    Script Date: 9/24/2020 2:11:45 PM ******/
CREATE DATABASE [librarymanagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'librarymanagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\librarymanagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'librarymanagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\librarymanagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [librarymanagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [librarymanagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [librarymanagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [librarymanagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [librarymanagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [librarymanagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [librarymanagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [librarymanagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [librarymanagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [librarymanagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [librarymanagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [librarymanagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [librarymanagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [librarymanagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [librarymanagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [librarymanagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [librarymanagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [librarymanagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [librarymanagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [librarymanagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [librarymanagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [librarymanagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [librarymanagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [librarymanagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [librarymanagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [librarymanagement] SET  MULTI_USER 
GO
ALTER DATABASE [librarymanagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [librarymanagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [librarymanagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [librarymanagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [librarymanagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [librarymanagement] SET QUERY_STORE = OFF
GO
USE [librarymanagement]
GO
/****** Object:  Table [dbo].[admin_login_table]    Script Date: 9/24/2020 2:11:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin_login_table](
	[user_name] [varchar](50) NOT NULL,
	[password] [varchar](50) NULL,
	[full_name] [varchar](50) NULL,
 CONSTRAINT [PK_admin_login_table] PRIMARY KEY CLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[author_master_tbl]    Script Date: 9/24/2020 2:11:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[author_master_tbl](
	[author_id] [varchar](50) NOT NULL,
	[author_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_author_master_tbl] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[book_issue_tbl]    Script Date: 9/24/2020 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_issue_tbl](
	[member_id] [varchar](50) NULL,
	[member_name] [varchar](50) NULL,
	[book_id] [varchar](50) NULL,
	[book_name] [varchar](50) NULL,
	[issue_date] [varchar](50) NULL,
	[due_date] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[book_master_tbl]    Script Date: 9/24/2020 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_master_tbl](
	[book_id] [varchar](50) NOT NULL,
	[book_name] [varchar](50) NULL,
	[genre] [varchar](50) NULL,
	[author_name] [varchar](50) NULL,
	[publisher_name] [varchar](50) NULL,
	[published_date] [varchar](50) NULL,
	[language] [varchar](50) NULL,
	[edition] [varchar](50) NULL,
	[book_cost] [varchar](50) NULL,
	[no_of_pages] [varchar](50) NULL,
	[book_description] [varchar](50) NULL,
	[actual_stock] [varchar](50) NULL,
	[current_stock] [varchar](50) NULL,
	[book_img_link] [varchar](max) NULL,
 CONSTRAINT [PK_book_master_tbl] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[member_master_tbl]    Script Date: 9/24/2020 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member_master_tbl](
	[full_name] [varchar](50) NULL,
	[dob] [varchar](50) NULL,
	[contact_no] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[pin_code] [varchar](50) NULL,
	[full_address] [varchar](50) NULL,
	[member_id] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[account_status] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publisher_master_tbl]    Script Date: 9/24/2020 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publisher_master_tbl](
	[publisher_id] [varchar](50) NULL,
	[publisher_name] [varchar](50) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [librarymanagement] SET  READ_WRITE 
GO
