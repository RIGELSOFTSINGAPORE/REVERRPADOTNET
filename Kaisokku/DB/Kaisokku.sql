USE [master]
GO
/****** Object:  Database [Kaisokku]    Script Date: 2022/04/13 11.35.33 AM ******/
CREATE DATABASE [Kaisokku]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kaisokku', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kaisokku.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kaisokku_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Kaisokku_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Kaisokku] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kaisokku].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kaisokku] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kaisokku] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kaisokku] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kaisokku] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kaisokku] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kaisokku] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kaisokku] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kaisokku] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kaisokku] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kaisokku] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kaisokku] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kaisokku] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kaisokku] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kaisokku] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kaisokku] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kaisokku] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kaisokku] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kaisokku] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kaisokku] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kaisokku] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kaisokku] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kaisokku] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kaisokku] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Kaisokku] SET  MULTI_USER 
GO
ALTER DATABASE [Kaisokku] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kaisokku] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kaisokku] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kaisokku] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kaisokku] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Kaisokku] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Kaisokku', N'ON'
GO
ALTER DATABASE [Kaisokku] SET QUERY_STORE = OFF
GO
USE [Kaisokku]
GO
/****** Object:  Table [dbo].[ActivityReport]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityReport](
	[SerialNo] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[MenuId] [int] NULL,
	[MenuName] [varchar](50) NULL,
	[VisitedDate] [datetime] NULL,
 CONSTRAINT [PK_ActivityReport] PRIMARY KEY CLUSTERED 
(
	[SerialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[address]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[Name] [varchar](100) NULL,
	[BuildingName] [varchar](100) NULL,
	[BuidingNo] [varchar](100) NULL,
	[street] [varchar](100) NULL,
	[Area] [varchar](100) NULL,
	[state_pin_Country] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientMGT]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientMGT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[image] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[ClientName] [nvarchar](100) NULL,
	[Website] [nvarchar](500) NULL,
 CONSTRAINT [PK_ClientMGT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClintUser]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClintUser](
	[image] [varchar](100) NULL,
	[Description] [varchar](max) NULL,
	[ClientName] [nvarchar](100) NULL,
	[Website] [nvarchar](100) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contentManagement]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contentManagement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](4000) NULL,
	[created_by] [nvarchar](100) NULL,
	[created_date] [datetime] NULL,
	[Updated_by] [nvarchar](100) NULL,
	[Updated_date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRMContents]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMContents](
	[UserCustomId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NULL,
	[ContactName] [varchar](100) NULL,
	[CompanyName] [varchar](250) NULL,
	[RoleId] [int] NULL,
	[Lang] [varchar](10) NULL,
	[IpAddress] [varchar](20) NULL,
	[IsActive] [bit] NULL,
	[createddate] [datetime] NULL,
	[createdby] [varchar](30) NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
	[Email] [varchar](50) NULL,
	[CustomerType] [int] NULL,
 CONSTRAINT [PK_CRMContents] PRIMARY KEY CLUSTERED 
(
	[UserCustomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustUserID] [varchar](20) NOT NULL,
	[Password] [varchar](10) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Mobile] [varchar](20) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Zipcode] [varchar](20) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
	[CustomerType] [int] NOT NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerRequestData]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerRequestData](
	[CustRequestID] [int] IDENTITY(1,1) NOT NULL,
	[CustUserID] [varchar](20) NOT NULL,
	[CustomerRquests] [nvarchar](1000) NOT NULL,
	[Createddate] [datetime] NOT NULL,
	[Createdby] [varchar](50) NOT NULL,
	[CustIpAddress] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CustomerRequestData] PRIMARY KEY CLUSTERED 
(
	[CustRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentfiles]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentfiles](
	[mediaid] [int] NULL,
	[filename] [varchar](40) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[enquiryform]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enquiryform](
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[phoneno] [int] NULL,
	[comments] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HitCounter]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HitCounter](
	[HitCounterId] [int] NOT NULL,
	[CountryName] [varchar](30) NOT NULL,
	[Visiteddate] [datetime] NOT NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_HitCounter] PRIMARY KEY CLUSTERED 
(
	[HitCounterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuMaster]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuMaster](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](50) NULL,
	[ControllerName] [varchar](50) NULL,
	[ActionMethod] [varchar](50) NULL,
	[MenuParentId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[MenuParentCss1] [varchar](30) NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
	[LanguageJapanease] [nvarchar](70) NULL,
	[IsJapanLang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PageManagement]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageManagement](
	[pagefilename] [varchar](100) NOT NULL,
	[pagedescription] [nvarchar](1000) NULL,
	[mediafiletype] [varchar](5) NOT NULL,
	[pagecontent] [nvarchar](max) NULL,
	[mediafolder] [varchar](100) NOT NULL,
	[FolderID] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
	[pageId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NOT NULL,
	[AdminRights] [varchar](10) NOT NULL,
	[PageMenuId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[pageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PageManagementFolder]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageManagementFolder](
	[folderId] [int] NOT NULL,
	[folderName] [varchar](50) NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_tblPageManagementFolder] PRIMARY KEY CLUSTERED 
(
	[folderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PPTfiles]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PPTfiles](
	[mediaid] [int] NULL,
	[filename] [varchar](40) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PPTFolder]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PPTFolder](
	[FolderID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[FolderName] [nvarchar](510) NOT NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_PPTFolder] PRIMARY KEY CLUSTERED 
(
	[FolderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PPTMedia]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PPTMedia](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[Filename] [nvarchar](200) NULL,
	[FolderID] [int] NOT NULL,
	[UploadType] [nvarchar](1) NULL,
	[ViewCount] [int] NOT NULL,
	[PhysicalIsActive] [bit] NOT NULL,
	[PhysicalIsActivecreatedby] [nvarchar](50) NULL,
	[PhysicalIsActivecreatedDate] [datetime] NULL,
	[PhysicalIsActiveIPAddress] [nvarchar](50) NULL,
	[FileSize] [bigint] NULL,
	[Registerer] [nvarchar](50) NULL,
	[Accepter] [nvarchar](50) NULL,
	[ApprovalStatus] [int] NULL,
	[Duration] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_tblPPTDemo] PRIMARY KEY CLUSTERED 
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pricemgt]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pricemgt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [nvarchar](100) NULL,
	[Validity] [nvarchar](100) NULL,
	[Price] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenuMapping]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenuMapping](
	[RoleMenuMapId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuId] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleMenuMapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialMediaFiles]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMediaFiles](
	[SocialMediaId] [int] NOT NULL,
	[Filename] [nvarchar](50) NULL,
 CONSTRAINT [PK_SocialMediaFiles] PRIMARY KEY CLUSTERED 
(
	[SocialMediaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialMeida]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMeida](
	[SocialMediaID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[URL] [nvarchar](50) NULL,
	[Filename] [nvarchar](max) NULL,
 CONSTRAINT [PK_SocialMeida] PRIMARY KEY CLUSTERED 
(
	[SocialMediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableMapping]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableMapping](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NULL,
	[TableName] [varchar](50) NULL,
 CONSTRAINT [PK_Search] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableMappingClient]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableMappingClient](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NULL,
	[MenuName] [nvarchar](50) NULL,
	[ControllerName] [varchar](50) NULL,
	[ActionMethod] [varchar](50) NULL,
	[DummyMenuId] [int] NULL,
 CONSTRAINT [PK_TableMappingClient] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskMaster]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskMaster](
	[TaskMasterId] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](100) NULL,
	[TaskDescription] [varchar](50) NULL,
	[UserId] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK__tbl_Task__3214EC07C258E18A] PRIMARY KEY CLUSTERED 
(
	[TaskMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Document]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Document](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[Filename] [nvarchar](200) NULL,
	[Thumbnail] [nvarchar](200) NULL,
	[UploadType] [nvarchar](1) NULL,
	[ViewCount] [int] NOT NULL,
	[PhysicalIsActive] [bit] NOT NULL,
	[PhysicalIsActivecreatedby] [nvarchar](50) NULL,
	[PhysicalIsActivecreatedDate] [datetime] NULL,
	[PhysicalIsActiveIPAddress] [nvarchar](50) NULL,
	[FileSize] [bigint] NULL,
	[Registerer] [nvarchar](50) NULL,
	[Accepter] [nvarchar](50) NULL,
	[ApprovalStatus] [int] NULL,
	[Duration] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_tbl_Document] PRIMARY KEY CLUSTERED 
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_DRS_rep]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DRS_rep](
	[ServiceOrderNo] [int] IDENTITY(1,1) NOT NULL,
	[LastUpdatedUser] [varchar](100) NULL,
	[BillingUser] [varchar](50) NULL,
	[BillingDate] [datetime] NULL,
	[GoodsDeliveredDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[Engineer] [varchar](50) NULL,
	[Product] [varchar](50) NULL,
	[inLabour] [decimal](18, 0) NULL,
	[inParts] [decimal](18, 0) NULL,
	[inTransport] [decimal](18, 0) NULL,
	[inothers] [decimal](18, 0) NULL,
	[inTax] [decimal](18, 0) NULL,
	[inTotal] [decimal](18, 0) NULL,
	[outLabour] [decimal](18, 0) NULL,
	[outParts] [decimal](18, 0) NULL,
	[outTransport] [decimal](18, 0) NULL,
	[outothers] [decimal](18, 0) NULL,
	[outTax] [decimal](18, 0) NULL,
	[outTotal] [decimal](18, 0) NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK__tbl_DRSrep__3214EC07C258E18A] PRIMARY KEY CLUSTERED 
(
	[ServiceOrderNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PPTUPLOAD]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PPTUPLOAD](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[Filename] [nvarchar](200) NULL,
	[Thumbnail] [nvarchar](200) NULL,
	[UploadType] [nvarchar](1) NULL,
	[ViewCount] [int] NOT NULL,
	[PhysicalIsActive] [bit] NOT NULL,
	[PhysicalIsActivecreatedby] [nvarchar](50) NULL,
	[PhysicalIsActivecreatedDate] [datetime] NULL,
	[PhysicalIsActiveIPAddress] [nvarchar](50) NULL,
	[FileSize] [bigint] NULL,
	[Registerer] [nvarchar](50) NULL,
	[Accepter] [nvarchar](50) NULL,
	[ApprovalStatus] [int] NULL,
	[Duration] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_tbl_PPTUPLOAD] PRIMARY KEY CLUSTERED 
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_VideoMedia]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_VideoMedia](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[Filename] [nvarchar](200) NULL,
	[Thumbnail] [nvarchar](200) NULL,
	[UploadType] [nvarchar](1) NULL,
	[ViewCount] [int] NOT NULL,
	[PhysicalIsActive] [bit] NOT NULL,
	[PhysicalIsActivecreatedby] [nvarchar](50) NULL,
	[PhysicalIsActivecreatedDate] [datetime] NULL,
	[PhysicalIsActiveIPAddress] [nvarchar](50) NULL,
	[FileSize] [bigint] NULL,
	[Registerer] [nvarchar](50) NULL,
	[Accepter] [nvarchar](50) NULL,
	[ApprovalStatus] [int] NULL,
	[Duration] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
	[Usertype] [int] NULL,
 CONSTRAINT [PK_tbl_VideoDemo] PRIMARY KEY CLUSTERED 
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserMasterId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NULL,
	[UserName] [varchar](100) NULL,
	[password] [varchar](10) NULL,
	[RoleId] [int] NULL,
	[Lang] [varchar](10) NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
	[Email] [varchar](50) NULL,
	[CustomerType] [int] NULL,
	[IsClient] [bit] NULL,
 CONSTRAINT [PK__tbl_User__3214EC07C258E18A] PRIMARY KEY CLUSTERED 
(
	[UserMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Video_view_log]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video_view_log](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[ClientIPAddress] [varchar](20) NULL,
	[UserAgent] [varchar](30) NULL,
	[StoreIPAddress] [varchar](20) NULL,
	[StoreName] [varchar](50) NULL,
	[StoreId] [int] NULL,
	[ClientSubnetId] [varchar](20) NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_tbl_Video_view_log] PRIMARY KEY CLUSTERED 
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoComments]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoComments](
	[Sno] [int] IDENTITY(1,1) NOT NULL,
	[VideoId] [int] NULL,
	[VideoName] [nvarchar](50) NULL,
	[VideoComments] [nvarchar](max) NULL,
	[FilePath] [varchar](300) NULL,
	[VisitedDate] [datetime] NULL,
	[IsApproved] [bit] NULL,
	[ApprovedBy] [varchar](50) NULL,
	[UserId] [varchar](50) NULL,
	[VisitorName] [varchar](50) NULL,
	[IPAddress] [varchar](50) NULL,
	[FileName] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_VideoComments1] PRIMARY KEY CLUSTERED 
(
	[Sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[videofiles]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[videofiles](
	[mediaid] [int] NULL,
	[filename] [varchar](40) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoFolder]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoFolder](
	[FolderID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[FolderName] [nvarchar](510) NOT NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_Folder] PRIMARY KEY CLUSTERED 
(
	[FolderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoMedia]    Script Date: 2022/04/13 11.35.33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoMedia](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[Filename] [nvarchar](200) NULL,
	[Thumbnail] [nvarchar](200) NULL,
	[FolderID] [int] NOT NULL,
	[UploadType] [nvarchar](1) NULL,
	[ViewCount] [int] NOT NULL,
	[PhysicalIsActive] [bit] NOT NULL,
	[PhysicalIsActivecreatedby] [nvarchar](50) NULL,
	[PhysicalIsActivecreatedDate] [datetime] NULL,
	[PhysicalIsActiveIPAddress] [nvarchar](50) NULL,
	[FileSize] [bigint] NULL,
	[Registerer] [nvarchar](50) NULL,
	[Accepter] [nvarchar](50) NULL,
	[ApprovalStatus] [int] NULL,
	[Duration] [int] NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](30) NOT NULL,
	[updateddate] [datetime] NULL,
	[updatedby] [varchar](30) NULL,
 CONSTRAINT [PK_tblVideoDemo] PRIMARY KEY CLUSTERED 
(
	[MediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ActivityReport] ON 
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-13T00:00:46.893' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-13T00:01:29.317' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-13T00:03:01.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (4, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-13T00:03:17.943' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (5, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-13T00:03:28.960' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (6, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-13T00:03:38.007' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (127, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T10:25:02.927' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (128, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-15T16:06:01.340' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (129, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T16:06:04.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (130, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T16:06:07.403' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (131, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T16:06:28.027' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (132, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T16:07:26.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (133, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-15T16:07:35.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (134, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T16:07:52.433' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (135, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T16:08:11.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (136, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T16:08:15.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (137, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T16:08:26.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (138, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-15T16:08:27.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (139, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-15T16:08:40.183' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (140, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T16:10:46.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (141, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T16:11:48.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (142, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T16:12:37.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (143, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-15T16:33:37.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (144, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-15T16:36:01.637' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (145, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T16:36:29.357' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (146, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-15T16:36:53.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (147, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T16:40:16.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (148, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T16:40:22.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (149, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-15T16:40:32.403' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (150, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T16:40:35.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (151, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T16:41:35.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (152, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T17:01:49.607' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (153, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T17:03:43.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (154, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-15T17:03:48.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (155, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T17:03:56.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (156, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-15T17:03:59.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (157, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T17:04:30.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (158, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T17:05:34.107' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (159, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-15T17:34:11.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (160, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-15T17:34:23.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (161, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T17:41:18.357' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (162, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-15T18:26:07.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (163, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-18T13:50:21.023' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (164, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T13:51:01.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (165, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-18T13:52:53.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (166, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-18T13:54:17.523' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (167, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-18T13:54:29.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (168, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-18T13:54:55.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (169, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-18T13:55:42.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (170, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-18T13:56:11.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (171, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-18T13:57:51.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (172, N'100', N'ilaya', 76, N'Contact us ', CAST(N'2020-05-18T13:58:12.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (173, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T13:59:35.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (174, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-18T14:00:33.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (175, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-18T14:02:03.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (176, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-18T14:43:34.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (177, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T14:43:41.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (178, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-18T14:45:40.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (179, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-18T14:48:00.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (180, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-18T14:52:09.930' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (181, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T15:28:55.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (182, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-18T15:28:57.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (183, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T15:29:12.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (184, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T15:36:35.023' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (185, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-18T15:37:57.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (186, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-18T16:27:42.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (187, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-18T16:30:18.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (188, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-18T16:30:23.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (189, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T16:30:27.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (190, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-18T17:32:29.320' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (191, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-18T17:32:41.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (192, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-18T18:42:50.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (193, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-18T18:43:01.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (194, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-18T18:43:30.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (195, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-18T18:43:42.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (196, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-18T18:44:05.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (197, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-18T18:44:16.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (198, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-18T22:58:59.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (199, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-19T12:13:05.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (200, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-19T12:13:07.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (201, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T12:13:18.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (202, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T12:13:32.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (203, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-19T12:13:55.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (204, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-19T12:14:04.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (205, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T12:14:14.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (206, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T12:14:23.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (207, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-19T12:14:39.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (208, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T12:27:16.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (209, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T12:27:20.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (210, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-19T12:27:36.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (211, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-19T12:28:05.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (212, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-19T12:36:28.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (213, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T12:36:34.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (214, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T12:36:40.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (215, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T12:36:41.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (216, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T12:36:42.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (217, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-19T12:36:50.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (218, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-19T12:37:00.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (219, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T12:37:27.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (220, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T12:37:28.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (221, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-19T12:37:34.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (222, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-19T12:37:39.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (223, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T13:59:23.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (224, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T14:25:02.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (225, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-19T14:33:31.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (226, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T14:47:12.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (227, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T14:49:17.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (228, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-19T14:50:19.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (229, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-19T14:50:27.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (230, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-19T15:44:45.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (231, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-19T15:44:47.337' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (232, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T15:44:53.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (233, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-19T15:44:58.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (234, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T15:45:06.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (235, N'100', N'ilaya', 76, N'Contact us ', CAST(N'2020-05-19T15:45:18.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (236, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-19T15:45:22.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (237, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T15:45:29.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (238, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-19T15:45:42.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (239, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T15:45:42.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (240, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T15:45:58.447' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (241, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-19T15:46:14.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (242, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-19T15:47:34.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (243, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-19T15:49:31.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (244, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T16:16:43.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (245, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T16:16:51.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (246, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T16:17:32.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (247, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T16:18:43.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (248, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T16:21:11.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (249, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-19T16:30:43.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (250, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-19T16:36:13.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (251, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-19T22:42:43.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (252, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-19T22:43:06.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (253, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-19T22:43:08.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (254, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-19T22:43:12.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (255, N'107', N'Raja', 4, N'VideoManagement', CAST(N'2020-05-19T22:44:27.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (256, N'107', N'Raja', 4, N'VideoManagement', CAST(N'2020-05-19T22:44:39.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (257, N'107', N'Raja', 5, N'PPT Management', CAST(N'2020-05-19T22:48:54.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (258, N'107', N'Raja', 5, N'PPT Management', CAST(N'2020-05-19T22:49:16.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (259, N'107', N'Raja', 6, N'RPASampleReport', CAST(N'2020-05-19T22:50:39.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (260, N'107', N'Raja', 75, N'Social Media ', CAST(N'2020-05-19T22:50:46.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (261, N'107', N'Raja', 8, N'Menu Management', CAST(N'2020-05-19T22:52:03.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (262, N'107', N'Raja', 10, N'CRM', CAST(N'2020-05-19T22:52:33.523' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (263, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-20T12:40:53.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (264, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T12:40:57.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (265, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T12:41:33.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (266, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T12:41:37.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (267, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-20T12:42:25.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (268, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-20T12:42:45.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (269, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T12:43:10.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (270, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-20T12:43:26.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (271, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T12:43:49.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (272, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T12:44:25.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (273, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T12:44:28.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (274, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T12:45:28.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (275, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T12:45:55.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (276, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T13:05:35.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (277, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T13:24:26.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (278, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T13:26:51.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (279, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T13:27:49.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (280, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T13:27:53.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (281, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T13:38:47.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (282, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-20T13:57:36.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (283, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T13:58:01.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (284, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-20T13:58:24.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (285, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T13:58:32.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (286, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T14:01:08.697' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (287, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T14:01:21.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (288, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T14:19:07.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (289, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-20T14:19:54.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (290, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-20T14:20:03.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (291, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T14:20:10.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (292, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-20T14:20:56.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (293, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T14:22:17.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (294, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T14:22:29.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (295, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-20T14:22:37.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (296, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-20T14:24:31.773' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (297, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-20T14:24:35.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (298, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-20T14:24:46.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (299, N'100', N'ilaya', 78, N'Test ', CAST(N'2020-05-20T14:25:36.290' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (300, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-20T14:27:00.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (301, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T14:27:07.773' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (302, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T14:27:11.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (303, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T14:28:12.070' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (304, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-20T14:28:14.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (305, N'100', N'ilaya', 76, N'Contact us ', CAST(N'2020-05-20T14:33:30.773' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (306, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-20T14:36:18.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (307, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-20T14:36:33.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (308, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T15:05:49.023' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (309, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-20T15:06:24.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (310, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T15:06:28.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (311, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T16:15:44.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (312, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T16:15:54.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (313, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T16:16:32.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (314, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T16:17:59.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (315, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T17:12:45.320' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (316, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T17:23:33.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (317, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T17:25:26.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (318, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T17:25:30.557' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (319, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T18:43:00.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (320, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T18:49:43.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (321, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T18:50:00.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (322, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T19:51:38.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (323, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T19:51:46.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (324, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-20T20:30:30.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (325, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-20T20:30:45.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (326, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-21T20:20:10.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (327, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-21T20:49:59.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (328, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-21T20:50:09.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (329, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-21T20:50:13.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (330, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-21T20:50:28.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (331, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-21T20:56:18.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (332, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-21T20:56:28.023' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (333, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-21T21:12:36.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (334, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-21T21:50:22.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (335, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-21T21:57:08.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (336, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-21T21:57:15.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (337, N'100', N'ilaya', 78, N'Test ', CAST(N'2020-05-21T21:57:25.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (338, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-21T22:09:55.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (339, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-21T22:10:28.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (340, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-21T22:11:37.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (341, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-21T22:16:21.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (342, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-21T22:16:36.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (343, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-21T22:17:03.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (344, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-21T22:17:07.383' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (345, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-21T22:17:41.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (346, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-21T22:18:20.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (347, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-21T22:20:32.563' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (348, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-21T22:20:47.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (349, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T01:07:34.557' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (350, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T01:10:56.820' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (351, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T01:21:44.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (352, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T01:45:03.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (353, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T12:14:30.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (354, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T12:24:42.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (355, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T12:25:40.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (356, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T12:45:57.820' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (357, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T13:15:56.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (358, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T13:19:24.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (359, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T13:26:55.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (360, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T13:27:05.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (361, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T13:33:21.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (362, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T13:50:50.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (363, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T14:01:04.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (364, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T14:01:28.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (365, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T14:01:53.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (366, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T14:03:36.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (367, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T14:04:27.320' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (368, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T14:05:58.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (369, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-22T14:06:05.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (370, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T14:07:07.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (371, N'100', N'ilaya', 76, N'Contact us ', CAST(N'2020-05-22T14:07:17.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (372, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T14:07:33.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (373, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T14:07:40.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (374, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T14:15:40.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (375, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T14:19:28.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (376, N'100', N'ilaya', 4, N'VideoManagement', CAST(N'2020-05-22T14:20:22.743' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (377, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T14:20:44.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (378, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T14:45:12.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (379, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T14:45:24.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (380, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T14:45:38.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (381, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T14:45:52.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (382, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T14:53:32.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (383, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T14:56:12.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (384, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T15:03:25.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (385, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T15:04:03.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (386, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T15:21:09.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (387, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T15:21:51.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (388, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T15:22:02.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (389, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T15:24:07.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (390, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T15:30:56.820' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (391, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T15:49:04.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (392, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T15:49:09.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (393, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T15:52:24.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (394, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T15:54:48.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (395, N'100', N'ilaya', 76, N'Contact us ', CAST(N'2020-05-22T15:55:27.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (396, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T15:55:32.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (397, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T15:58:22.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (398, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T16:02:13.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (399, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T16:02:19.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (400, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:06:42.290' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (401, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:07:43.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (402, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T16:07:58.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (403, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T16:08:45.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (404, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:10:25.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (405, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:12:24.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (406, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:14:09.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (407, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:17:39.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (408, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:17:52.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (409, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:19:13.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (410, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T16:21:36.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (411, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:21:42.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (412, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:21:45.447' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (413, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:24:22.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (414, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:25:59.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (415, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T16:28:07.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (416, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:29:47.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (417, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T16:35:15.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (418, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:44:24.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (419, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:44:31.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (420, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:46:10.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (421, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:46:17.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (422, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:46:25.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (423, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:46:32.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (424, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:47:34.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (425, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T16:47:40.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (426, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:53:49.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (427, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-22T16:54:15.930' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (428, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T16:56:33.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (429, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T17:02:44.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (430, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:02:48.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (431, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T17:02:58.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (432, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T17:03:08.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (433, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:03:12.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (434, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T17:03:25.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (435, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T17:03:30.743' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (436, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:03:35.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (437, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T17:03:45.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (438, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:03:53.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (439, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T17:03:56.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (440, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:04:05.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (441, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T17:04:10.383' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (442, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:04:13.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (443, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T17:04:21.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (444, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T17:04:30.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (445, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:04:35.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (446, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T17:05:01.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (447, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T17:05:10.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (448, N'100', N'ilaya', 0, N'', CAST(N'2020-05-22T17:05:26.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (449, N'100', N'ilaya', 0, N'', CAST(N'2020-05-22T17:05:49.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (450, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T17:05:53.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (451, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T17:06:07.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (452, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T17:06:20.523' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (453, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-22T17:06:46.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (454, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:06:51.743' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (455, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-22T17:07:20.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (456, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T17:33:25.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (457, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T17:33:34.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (458, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-22T17:33:39.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (459, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T17:33:43.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (460, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T17:33:46.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (461, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T17:33:48.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (462, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T17:34:01.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (463, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T17:34:06.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (464, N'100', N'ilaya', 84, N'testing', CAST(N'2020-05-22T17:34:17.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (465, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T17:34:39.697' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (466, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T17:35:13.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (467, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T17:37:22.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (468, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-22T17:38:19.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (469, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T17:38:40.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (470, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T17:47:28.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (471, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T18:00:56.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (472, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T18:01:01.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (473, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T18:01:21.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (474, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T18:01:51.290' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (475, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T18:02:06.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (476, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-22T18:02:37.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (477, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T18:03:58.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (478, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T18:03:59.337' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (479, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-22T18:04:06.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (480, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T18:04:14.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (481, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T18:05:56.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (482, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T18:09:50.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (483, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T18:09:54.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (484, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-22T18:10:12.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (485, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-22T18:11:41.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (486, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T18:11:47.570' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (487, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T18:13:41.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (488, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-22T18:13:49.557' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (489, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T18:14:53.070' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (490, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T18:14:58.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (491, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T18:15:11.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (492, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T18:20:30.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (493, N'100', N'ilaya', 6, N'RPASampleReport', CAST(N'2020-05-22T18:20:40.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (494, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T18:20:43.223' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (495, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T18:24:17.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (496, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T18:26:34.697' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (497, N'100', N'ilaya', 75, N'Social Media ', CAST(N'2020-05-22T18:29:39.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (498, N'100', N'ilaya', 76, N'Contact us ', CAST(N'2020-05-22T18:29:51.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (499, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T18:30:34.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (500, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T18:30:48.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (501, N'100', N'ilaya', 85, N'Message ', CAST(N'2020-05-22T18:31:04.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (502, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T18:35:01.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (503, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T18:35:59.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (504, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T18:57:15.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (505, N'100', N'ilaya', 85, N'Message ', CAST(N'2020-05-22T19:24:20.447' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (506, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-22T20:10:23.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (507, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T20:10:28.090' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (508, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T20:10:39.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (509, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T20:10:49.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (510, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-22T20:11:02.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (511, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-22T20:11:17.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (512, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T20:11:24.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (513, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-22T20:11:38.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (514, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T20:24:15.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (515, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T20:31:01.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (516, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T20:46:52.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (517, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T20:46:58.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (518, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T20:47:06.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (519, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T20:47:51.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (520, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-22T20:48:08.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (521, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T20:48:45.930' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (522, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T20:49:30.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (523, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T20:49:47.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (524, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-22T20:50:33.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (525, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T20:51:30.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (526, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-22T20:52:13.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (527, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T20:52:38.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (528, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T20:55:37.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (529, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T20:55:53.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (530, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-22T20:56:17.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (531, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T20:56:21.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (532, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-22T20:56:41.930' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (533, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-22T20:56:48.447' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (534, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T21:15:03.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (535, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T21:24:24.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (536, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T21:25:14.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (537, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-22T21:25:27.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (538, N'100', N'ilaya', 13, N'Hit Counter', CAST(N'2020-05-22T21:27:04.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (539, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-22T21:30:45.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (540, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-22T21:35:15.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (541, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-22T21:37:04.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (542, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T21:45:17.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (543, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T21:45:23.447' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (544, N'100', N'ilaya', 75, N'Social Media1 ', CAST(N'2020-05-22T21:45:39.697' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (545, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T21:45:51.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (546, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-22T21:46:33.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (547, N'100', N'ilaya', 75, N'Page1 ', CAST(N'2020-05-22T21:46:39.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (548, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T21:47:07.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (549, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T21:55:29.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (550, N'100', N'ilaya', 75, N'Page1 ', CAST(N'2020-05-22T21:55:42.523' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (551, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T21:56:01.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (552, N'100', N'ilaya', 75, N'Page1 ', CAST(N'2020-05-22T21:56:12.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (553, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T21:57:01.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (554, N'100', N'ilaya', 75, N'Page1 ', CAST(N'2020-05-22T21:57:26.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (555, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-22T22:00:29.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (556, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:12:44.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (557, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:12:54.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (558, N'100', N'ilaya', 86, N'rajarajan ', CAST(N'2020-05-23T02:13:01.773' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (559, N'100', N'ilaya', 86, N'rajarajan ', CAST(N'2020-05-23T02:14:40.773' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (560, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:14:46.383' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (561, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-23T02:14:59.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (562, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:15:03.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (563, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:19:49.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (564, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-23T02:20:01.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (565, N'100', N'ilaya', 87, N'ttt ', CAST(N'2020-05-23T02:20:08.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (566, N'100', N'ilaya', 87, N'ttt ', CAST(N'2020-05-23T02:22:18.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (567, N'100', N'ilaya', 87, N'ttt ', CAST(N'2020-05-23T02:24:06.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (568, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:44:02.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (569, N'100', N'ilaya', 87, N'ttt ', CAST(N'2020-05-23T02:44:07.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (570, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:45:33.773' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (571, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:46:25.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (572, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-23T02:46:49.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (573, N'100', N'ilaya', 87, N'goatggg ', CAST(N'2020-05-23T02:47:00.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (574, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:47:09.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (575, N'100', N'ilaya', 87, N'goatggg ', CAST(N'2020-05-23T02:47:14.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (576, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:47:35.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (577, N'100', N'ilaya', 87, N'hhhh ', CAST(N'2020-05-23T02:48:02.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (578, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:48:37.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (579, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:49:01.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (580, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:50:49.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (581, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-23T02:56:49.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (582, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-23T02:58:16.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (583, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T02:58:47.743' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (584, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T03:04:25.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (585, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T03:04:30.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (586, N'100', N'ilaya', 89, N'teeee ', CAST(N'2020-05-23T03:04:47.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (587, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T03:55:52.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (588, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T03:56:00.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (589, N'100', N'ilaya', 90, N'KKK ', CAST(N'2020-05-23T03:56:08.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (590, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T03:56:12.070' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (591, N'100', N'ilaya', 90, N'KKKEEEE ', CAST(N'2020-05-23T03:56:30.197' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (592, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-23T03:56:38.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (593, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-23T03:57:09.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (594, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-23T03:57:22.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (595, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-23T03:59:14.570' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (596, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T03:03:21.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (597, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T03:03:33.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (598, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T03:05:18.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (599, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T03:33:26.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (600, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T03:42:22.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (601, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-24T15:13:07.937' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (602, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T15:13:13.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (603, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T15:14:21.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (604, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T15:15:15.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (605, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T15:15:35.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (606, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T15:16:55.907' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (607, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T15:17:21.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (608, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T15:17:29.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (609, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T15:17:49.547' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (610, N'100', N'ilaya', 91, N'ppp ', CAST(N'2020-05-24T15:17:54.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (611, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T15:18:24.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (612, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T15:19:39.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (613, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T15:20:02.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (614, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T15:20:07.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (615, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T15:20:38.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (616, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T15:21:18.033' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (617, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T15:22:20.453' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (618, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T15:38:32.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (619, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T15:39:42.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (620, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T15:39:49.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (621, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T15:39:55.533' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (622, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T15:40:16.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (623, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T15:43:25.453' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (624, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T15:44:41.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (625, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T15:45:43.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (626, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T16:04:25.937' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (627, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T16:11:41.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (628, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T16:14:25.280' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (629, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:35:39.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (630, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:37:06.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (631, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T16:37:12.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (632, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T16:37:20.207' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (633, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T16:37:27.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (634, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T16:39:10.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (635, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T16:39:41.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (636, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T16:40:09.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (637, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-24T16:40:20.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (638, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T16:40:50.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (639, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:48:59.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (640, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:50:54.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (641, N'101', N'adminvideo', 83, N'ManageComments', CAST(N'2020-05-24T16:53:33.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (642, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:54:33.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (643, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:55:09.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (644, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-24T16:55:54.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (645, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:56:02.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (646, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T16:56:11.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (647, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:56:17.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (648, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T16:56:23.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (649, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T16:56:31.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (650, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T16:56:39.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (651, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T16:56:51.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (652, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T16:56:58.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (653, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T16:57:17.047' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (654, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T16:57:32.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (655, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:01:18.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (656, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:02:09.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (657, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:02:19.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (658, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T17:03:41.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (659, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T17:04:27.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (660, N'101', N'demovideo', 83, N'ManageComments', CAST(N'2020-05-24T17:04:32.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (661, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-24T17:04:34.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (662, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T17:05:18.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (663, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:05:44.220' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (664, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T17:06:01.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (665, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:06:24.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (666, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T17:07:18.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (667, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:08:00.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (668, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T17:08:29.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (669, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:08:36.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (670, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:08:39.047' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (671, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:08:50.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (672, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:09:22.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (673, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:09:52.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (674, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:09:57.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (675, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:10:12.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (676, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:11:34.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (677, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:12:49.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (678, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:13:06.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (679, N'', N'', 83, N'ManageComments', CAST(N'2020-05-24T17:16:14.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (680, N'', N'', 83, N'ManageComments', CAST(N'2020-05-24T17:17:04.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (681, N'', N'', 80, N'ManageVideos', CAST(N'2020-05-24T17:17:19.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (682, N'', N'', 80, N'ManageVideos', CAST(N'2020-05-24T17:17:30.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (683, N'', N'', 12, N'Reports', CAST(N'2020-05-24T17:17:54.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (684, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:18:06.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (685, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:18:12.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (686, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:19:03.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (687, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:19:11.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (688, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:19:35.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (689, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:20:49.047' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (690, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-24T17:21:58.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (691, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:21:59.337' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (692, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:22:15.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (693, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:23:12.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (694, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:23:50.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (695, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:24:26.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (696, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:24:48.297' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (697, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:24:54.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (698, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:25:03.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (699, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:27:08.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (700, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:27:19.127' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (701, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:27:24.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (702, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:27:46.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (703, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:28:41.070' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (704, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:28:57.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (705, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:29:19.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (706, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:29:32.563' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (707, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:30:58.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (708, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:32:36.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (709, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T17:36:13.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (710, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:36:45.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (711, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:37:01.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (712, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T17:38:35.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (713, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:52:35.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (714, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:53:52.703' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (715, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:53:58.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (716, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T17:54:24.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (717, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T17:54:58.343' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (718, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:00:03.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (719, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T18:02:44.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (720, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:03:42.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (721, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T18:04:46.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (722, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T18:08:50.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (723, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:11:26.453' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (724, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T18:11:35.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (725, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T18:12:01.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (726, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:12:23.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (727, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T18:15:23.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (728, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T18:17:27.297' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (729, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:18:40.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (730, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:18:53.797' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (731, N'100', N'ilaya', 99, N'Message ', CAST(N'2020-05-24T18:18:58.220' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (732, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:19:40.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (733, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T18:19:51.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (734, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T18:22:40.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (735, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-24T18:25:02.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (736, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T18:25:21.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (737, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T18:29:17.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (738, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T18:43:58.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (739, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T18:45:17.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (740, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T18:50:57.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (741, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T18:51:08.547' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (742, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-24T18:59:35.280' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (743, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T19:04:12.797' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (744, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T19:06:23.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (745, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T19:07:37.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (746, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T19:07:58.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (747, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T19:07:59.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (748, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T19:08:13.907' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (749, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T19:10:35.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (750, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T19:11:31.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (751, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T19:21:12.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (752, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T19:22:00.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (753, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T19:22:12.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (754, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T19:49:24.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (755, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T19:49:31.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (756, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T19:49:44.377' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (757, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T19:50:46.687' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (758, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T19:52:37.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (759, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T19:52:52.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (760, N'100', N'ilaya', 98, N'test ', CAST(N'2020-05-24T19:55:09.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (761, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T19:57:40.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (762, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T20:01:02.297' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (763, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T20:03:34.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (764, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T20:06:40.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (765, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:12:48.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (766, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:12:58.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (767, N'100', N'ilaya', 100, N'yuvi ', CAST(N'2020-05-24T20:13:25.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (768, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:14:38.127' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (769, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T20:15:20.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (770, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:15:32.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (771, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:15:41.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (772, N'100', N'ilaya', 101, N'rajarajan ', CAST(N'2020-05-24T20:15:55.797' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (773, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:19:17.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (774, N'100', N'ilaya', 101, N'cholan ', CAST(N'2020-05-24T20:19:46.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (775, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:20:27.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (776, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:21:49.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (777, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:21:55.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (778, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-24T20:22:01.563' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (779, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-24T20:22:24.033' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (780, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:22:27.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (781, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:22:41.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (782, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:22:42.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (783, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T20:23:17.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (784, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:23:29.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (785, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:23:29.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (786, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T20:23:37.127' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (787, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:23:42.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (788, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:23:43.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (789, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:25:11.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (790, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:25:43.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (791, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:26:11.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (792, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T20:26:18.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (793, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:45:36.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (794, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-24T20:45:52.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (795, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:46:39.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (796, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-24T20:47:43.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (797, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-24T20:48:26.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (798, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T20:50:55.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (799, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T20:59:44.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (800, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-24T21:01:36.797' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (801, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-24T21:01:44.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (802, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-24T21:04:37.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (803, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T21:06:05.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (804, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-24T21:07:02.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (805, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-24T21:15:40.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (806, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T21:16:24.547' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (807, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-24T21:17:21.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (808, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T21:30:03.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (809, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T22:08:02.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (810, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T22:14:10.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (811, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T22:18:11.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (812, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T22:28:04.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (813, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-24T22:42:36.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (814, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-25T03:58:03.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (815, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T03:58:12.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (816, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T03:58:30.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (817, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T03:58:34.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (818, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-25T15:31:33.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (819, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T15:31:40.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (820, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-25T15:32:22.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (821, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T15:32:46.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (822, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T15:33:07.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (823, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-25T15:38:38.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (824, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-25T15:38:45.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (825, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T15:39:04.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (826, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-25T16:07:11.127' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (827, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T16:07:38.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (828, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T16:08:38.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (829, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-25T16:09:24.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (830, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-25T16:14:18.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (831, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-25T17:13:40.047' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (832, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-26T12:13:00.703' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (833, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T12:13:38.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (834, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-26T12:14:05.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (835, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-26T12:14:16.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (836, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T12:15:03.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (837, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-26T12:15:24.703' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (838, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T12:40:11.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (839, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T12:48:02.547' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (840, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T12:48:19.343' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (841, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T12:48:29.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (842, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T12:48:40.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (843, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T13:03:32.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (844, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-26T13:05:28.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (845, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-26T13:09:32.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (846, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-26T13:11:54.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (847, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-26T13:19:05.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (848, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-26T13:20:26.797' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (849, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-26T13:26:52.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (850, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-26T13:29:33.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (851, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T13:33:45.220' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (852, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-26T13:49:46.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (853, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T13:50:07.377' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (854, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-26T13:50:23.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (855, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T14:00:32.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (856, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-26T14:15:48.940' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (857, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-26T14:21:36.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (858, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T14:25:06.797' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (859, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T14:25:41.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (860, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-26T14:27:20.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (861, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-26T14:41:39.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (862, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T14:54:01.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (863, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-26T14:54:13.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (864, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-26T14:55:08.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (865, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-26T14:56:00.533' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (866, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-26T14:57:16.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (867, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-26T14:58:08.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (868, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T15:00:52.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (869, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T15:02:51.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (870, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-26T15:24:16.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (871, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-26T15:24:25.563' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (872, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-26T15:27:31.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (873, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-26T15:47:15.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (874, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-26T15:58:31.377' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (875, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-26T16:03:46.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (876, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T16:04:57.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (877, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-26T16:05:56.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (878, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-26T16:17:45.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (879, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-26T16:20:54.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (880, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-26T16:24:46.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (881, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-26T16:26:28.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (882, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-26T16:42:45.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (883, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-26T16:44:44.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (884, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T16:51:14.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (885, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-26T16:56:02.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (886, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-26T17:14:40.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (887, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-26T17:19:49.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (888, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-26T17:41:11.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (889, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-26T17:41:59.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (890, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-26T17:43:55.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (891, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-26T17:46:19.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (892, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-26T17:48:11.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (893, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-26T17:49:38.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (894, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-26T17:50:07.907' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (895, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-26T17:50:19.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (896, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-26T17:53:18.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (897, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-26T17:53:26.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (898, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-26T17:56:20.453' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (899, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-26T18:18:32.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (900, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T00:11:41.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (901, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T00:12:13.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (902, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T00:12:17.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (903, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T00:12:29.050' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (904, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T00:12:49.377' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (905, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T00:12:57.687' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (906, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-27T00:13:03.297' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (907, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-27T00:13:15.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (908, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-27T00:13:25.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (909, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T00:13:32.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (910, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-27T00:13:39.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (911, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-27T00:13:45.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (912, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-27T00:13:49.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (913, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-27T00:13:55.047' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (914, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-27T00:14:00.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (915, N'101', N'demovideo', 83, N'ManageComments', CAST(N'2020-05-27T00:14:26.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (916, N'101', N'demovideo', 80, N'ManageVideos', CAST(N'2020-05-27T00:14:41.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (917, N'101', N'demovideo', 80, N'ManageVideos', CAST(N'2020-05-27T00:15:14.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (918, N'101', N'demovideo', 11, N'SocialMedia', CAST(N'2020-05-27T00:15:59.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (919, N'101', N'demovideo', 10, N'CRM', CAST(N'2020-05-27T00:16:41.687' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (920, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T00:31:19.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (921, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T00:31:24.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (922, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T00:31:30.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (923, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T00:31:46.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (924, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T10:55:03.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (925, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T10:55:09.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (926, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-27T10:55:15.687' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (927, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-27T10:55:24.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (928, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-27T10:55:39.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (929, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T10:56:13.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (930, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-27T10:57:23.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (931, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-27T10:57:29.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (932, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-27T10:57:35.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (933, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-27T10:57:41.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (934, N'101', N'demovideo', 83, N'ManageComments', CAST(N'2020-05-27T10:58:18.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (935, N'101', N'demovideo', 83, N'ManageComments', CAST(N'2020-05-27T10:58:45.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (936, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T11:39:20.737' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (937, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T11:39:27.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (938, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T11:41:10.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (939, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T11:41:33.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (940, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-27T11:41:41.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (941, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-05-27T11:42:39.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (942, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-27T11:42:48.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (943, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T11:43:25.703' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (944, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-27T11:44:24.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (945, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T11:45:02.297' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (946, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T11:45:59.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (947, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-27T11:46:07.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (948, N'100', N'ilaya', 105, N'Message ', CAST(N'2020-05-27T11:46:12.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (949, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T11:46:28.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (950, N'100', N'ilaya', 103, N'test ', CAST(N'2020-05-27T11:47:04.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (951, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-27T11:50:39.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (952, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-27T11:50:49.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (953, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T11:51:29.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (954, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T12:38:55.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (955, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T12:39:00.703' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (956, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-27T12:39:05.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (957, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T12:39:18.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (958, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-27T12:39:21.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (959, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-27T12:39:26.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (960, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-27T12:39:32.343' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (961, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T12:39:37.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (962, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T12:39:42.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (963, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T12:39:49.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (964, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T12:40:00.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (965, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-27T12:40:48.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (966, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T12:41:28.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (967, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-27T12:41:30.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (968, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-27T12:43:42.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (969, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T12:46:47.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (970, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T12:47:28.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (971, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T13:25:07.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (972, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T13:25:19.377' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (973, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T13:26:41.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (974, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T13:27:30.190' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (975, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T13:34:04.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (976, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T13:38:45.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (977, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T13:39:39.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (978, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-05-27T13:40:01.563' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (979, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T13:40:47.047' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (980, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T13:42:57.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (981, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T13:43:15.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (982, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T13:52:10.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (983, N'100', N'ilaya', 105, N'Message ', CAST(N'2020-05-27T13:58:06.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (984, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T13:58:10.767' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (985, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T13:58:30.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (986, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-05-27T13:58:39.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (987, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T13:58:44.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (988, N'100', N'ilaya', 102, N'brtest', CAST(N'2020-05-27T13:59:05.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (989, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T14:00:42.047' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (990, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T14:01:23.813' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (991, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T14:02:39.343' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (992, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T18:27:14.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (993, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T18:30:18.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (994, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T18:31:51.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (995, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-05-27T19:51:30.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (996, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T19:56:44.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (997, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T21:08:39.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (998, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T21:09:14.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (999, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T21:10:42.127' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1000, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-27T21:10:56.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1001, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-27T22:03:13.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1002, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:06:05.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1003, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:06:31.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1004, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:07:04.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1005, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:07:27.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1006, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:10:21.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1007, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:11:33.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1008, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:15:58.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1009, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:16:11.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1010, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-05-27T22:17:27.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1011, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-27T22:19:35.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1012, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-27T23:28:26.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1013, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T12:32:53.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1014, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-28T12:37:04.127' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1015, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-28T12:37:28.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1016, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-28T12:37:39.050' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1017, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T12:38:34.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1018, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T12:41:55.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1019, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-28T12:48:36.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1020, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T12:49:49.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1021, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-28T12:51:22.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1022, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-05-28T12:53:42.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1023, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-28T12:54:49.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1024, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T12:54:52.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1025, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-05-28T13:19:37.550' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1026, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-05-28T13:20:49.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1027, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T13:22:25.820' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1028, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T15:19:23.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1029, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T16:30:58.907' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1030, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T16:45:01.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1031, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-28T17:49:24.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1032, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-05-28T22:30:44.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1033, N'100', N'ilaya', 105, N'Message ', CAST(N'2020-05-28T22:30:55.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1034, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-29T12:19:26.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1035, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-29T15:44:09.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1036, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-29T17:12:12.063' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1037, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-05-29T17:32:52.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1038, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-05-31T18:32:36.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1039, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-01T00:52:27.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1040, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-01T00:52:32.670' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1041, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-01T00:52:53.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1042, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-01T01:01:42.967' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1043, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-01T01:02:19.937' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1044, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-02T14:03:06.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1045, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T18:22:07.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1046, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-03T18:22:20.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1047, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-03T18:22:53.327' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1048, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-03T18:25:11.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1049, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-03T18:26:38.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1050, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-03T18:26:51.107' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1051, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-03T18:27:18.687' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1052, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-03T18:27:26.327' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1053, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T18:40:04.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1054, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T18:40:52.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1055, N'101', N'demovideo', 83, N'ManageComments', CAST(N'2020-06-03T18:41:36.827' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1056, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-03T18:43:10.903' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1057, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-03T18:43:28.717' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1058, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-03T18:44:45.903' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1059, N'101', N'demovideo', 83, N'ManageComments', CAST(N'2020-06-03T18:45:23.670' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1060, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-03T18:47:49.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1061, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-03T19:06:11.623' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1062, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-03T19:10:59.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1063, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-03T19:11:07.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1064, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T19:20:27.467' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1065, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-03T19:21:35.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1066, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T19:21:39.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1067, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-03T19:21:43.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1068, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-03T19:21:52.873' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1069, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T19:22:37.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1070, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-03T19:23:07.967' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1071, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T19:23:28.077' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1072, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T19:23:28.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1073, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-03T19:23:49.607' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1074, N'100', N'ilaya', 103, N'test ', CAST(N'2020-06-03T19:24:04.717' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1075, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-03T19:24:16.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1076, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-03T19:24:42.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1077, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-03T19:24:49.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1078, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-03T19:25:39.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1079, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-04T15:31:48.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1080, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-04T21:22:31.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1081, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-04T21:22:36.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1082, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T12:50:42.340' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1083, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T12:50:49.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1084, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T12:51:02.077' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1085, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-05T12:51:38.280' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1086, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T13:49:10.857' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1087, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-05T13:49:14.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1088, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T13:52:34.263' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1089, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T13:52:58.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1090, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T13:53:08.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1091, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T13:56:25.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1092, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T13:56:38.263' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1093, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T14:00:04.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1094, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T14:30:53.170' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1095, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-05T14:31:13.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1096, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T14:31:30.857' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1097, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-05T14:31:42.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1098, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T14:31:59.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1099, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T14:32:57.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1100, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T15:27:42.763' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1101, N'105', N'testing', 83, N'ManageComments', CAST(N'2020-06-05T15:32:28.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1102, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T15:32:53.763' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1103, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:33:00.107' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1104, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:42:09.577' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1105, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:42:39.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1106, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:43:03.623' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1107, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T15:43:25.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1108, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:44:12.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1109, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:44:19.513' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1110, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T15:50:25.653' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1111, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:50:43.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1112, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T15:51:33.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1113, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:51:49.280' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1114, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T15:51:58.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1115, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T15:53:29.687' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1116, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T15:53:35.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1117, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T16:09:07.373' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1118, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T16:10:01.590' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1119, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T16:10:11.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1120, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T16:10:24.340' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1121, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T16:10:28.967' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1122, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T16:14:09.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1123, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T16:15:14.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1124, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T16:28:40.920' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1125, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T16:29:21.170' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1126, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T16:33:44.577' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1127, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T16:33:50.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1128, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T16:33:55.043' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1129, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T16:38:05.687' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1130, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T16:39:33.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1131, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T16:40:30.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1132, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-05T16:42:40.937' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1133, N'100', N'ilaya', 103, N'test ', CAST(N'2020-06-05T16:42:49.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1134, N'100', N'ilaya', 105, N'Message ', CAST(N'2020-06-05T16:43:03.403' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1135, N'100', N'ilaya', 103, N'test ', CAST(N'2020-06-05T16:43:17.090' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1136, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-05T16:51:16.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1137, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-05T16:55:38.123' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1138, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-05T16:56:16.170' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1139, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-05T16:59:51.373' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1140, N'100', N'ilaya', 103, N'test ', CAST(N'2020-06-05T17:02:59.827' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1141, N'100', N'ilaya', 105, N'Message ', CAST(N'2020-06-05T17:05:29.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1142, N'100', N'ilaya', 103, N'test ', CAST(N'2020-06-05T17:06:02.467' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1143, N'100', N'ilaya', 105, N'Message ', CAST(N'2020-06-05T17:06:18.467' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1144, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:08:29.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1145, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:08:50.327' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1146, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:09:12.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1147, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:09:39.263' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1148, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-05T17:10:31.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1149, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:10:36.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1150, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:10:41.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1151, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:16:38.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1152, N'100', N'ilaya', 105, N'Message ', CAST(N'2020-06-05T17:20:09.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1153, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-05T17:20:33.967' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1154, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T17:22:53.793' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1155, N'100', N'ilaya', 102, N'brtest ', CAST(N'2020-06-05T17:23:11.780' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1156, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T17:23:40.467' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1157, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T17:24:08.873' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1158, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T17:24:28.153' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1159, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T17:24:48.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1160, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T17:24:55.903' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1161, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-05T17:31:01.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1162, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-05T17:31:12.013' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1163, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-05T17:31:30.327' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1164, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-05T17:32:59.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1165, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-05T17:37:15.123' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1166, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-05T17:46:05.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1167, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-05T17:48:45.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1168, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T17:49:57.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1169, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T17:50:00.577' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1170, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-05T17:50:08.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1171, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T18:02:25.547' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1172, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T18:02:49.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1173, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T18:04:02.920' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1174, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T18:09:12.373' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1175, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T18:13:37.513' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1176, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T18:14:41.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1177, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T18:37:38.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1178, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T18:41:28.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1179, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-05T18:41:58.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1180, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-05T18:47:26.217' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1181, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:05:41.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1182, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:09:45.903' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1183, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:10:48.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1184, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:12:44.920' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1185, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:13:06.090' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1186, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:13:44.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1187, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:14:25.247' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1188, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:18:52.967' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1189, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:25:10.090' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1190, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-05T19:26:20.590' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1191, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T19:35:14.607' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1192, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-05T19:35:22.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1193, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-05T19:35:45.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1194, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-05T19:36:54.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1195, N'100', N'ilaya', 10, N'CRM', CAST(N'2020-06-05T19:37:04.920' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1196, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T17:35:13.497' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1197, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T18:20:43.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1198, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-06T18:21:02.637' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1199, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-06T18:21:22.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1200, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-06T18:21:35.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1201, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-06T18:22:06.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1202, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-06T20:06:48.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1203, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-06T20:06:51.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1204, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-06T20:07:14.090' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1205, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-06T20:07:29.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1206, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-06T20:08:41.137' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1207, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-06T20:08:45.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1208, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-06T20:08:51.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1209, N'100', N'ilaya', 116, N'rrr ', CAST(N'2020-06-06T20:08:58.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1210, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-06T20:09:35.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1211, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-06T20:10:33.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1212, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T20:10:49.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1213, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T21:27:18.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1214, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T21:28:24.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1215, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T21:41:14.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1216, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T21:46:33.590' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1217, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-06T21:59:30.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1218, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-07T01:14:11.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1219, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-08T12:47:20.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1220, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-08T12:47:27.700' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1221, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-08T12:47:42.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1222, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-08T12:47:57.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1223, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-08T12:48:15.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1224, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-08T12:48:26.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1225, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-08T12:49:26.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1226, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-08T12:51:48.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1227, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-08T12:52:29.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1228, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-08T12:52:59.433' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1229, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-08T12:53:49.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1230, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-08T12:54:15.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1231, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-09T17:15:38.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1232, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-09T17:17:18.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1233, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T17:19:01.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1234, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-09T17:25:50.807' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1235, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T17:26:06.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1236, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T17:26:44.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1237, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T17:28:44.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1238, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T17:34:42.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1239, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T17:35:45.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1240, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T17:35:57.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1241, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T17:39:25.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1242, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T17:40:33.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1243, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-09T17:47:49.497' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1244, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-09T17:48:34.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1245, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T18:00:04.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1246, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T18:00:28.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1247, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-09T18:02:09.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1248, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T18:03:55.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1249, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T18:04:01.090' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1250, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-09T18:04:08.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1251, N'100', N'ilaya', 116, N'rrr ', CAST(N'2020-06-09T18:38:45.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1252, N'100', N'ilaya', 116, N'rrr ', CAST(N'2020-06-09T18:39:41.700' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1253, N'100', N'ilaya', 116, N'rrr ', CAST(N'2020-06-09T18:54:15.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1254, N'100', N'ilaya', 116, N'rrr ', CAST(N'2020-06-09T18:54:45.220' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1255, N'100', N'ilaya', 116, N'rrr ', CAST(N'2020-06-09T18:55:03.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1256, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-09T18:55:38.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1257, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-09T18:56:04.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1258, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-09T18:56:06.107' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1259, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-09T18:56:25.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1260, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-09T19:13:48.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1261, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-09T19:14:26.707' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1262, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-09T19:14:43.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1263, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-09T19:15:26.183' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1264, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-09T19:16:11.497' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1265, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-09T19:16:37.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1266, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-09T20:50:24.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1267, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T20:52:19.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1268, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-09T20:52:57.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1269, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T20:53:12.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1270, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-09T20:53:41.590' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1271, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-09T20:53:48.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1272, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-09T20:54:05.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1273, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-09T21:24:58.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1274, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T21:25:17.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1275, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-09T21:26:35.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1276, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-09T21:28:58.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1277, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T21:29:21.637' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1278, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T21:32:13.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1279, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-09T21:34:06.323' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1280, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-09T21:34:22.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1281, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T21:34:25.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1282, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-09T21:34:31.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1283, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T21:34:36.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1284, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T21:34:40.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1285, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-09T21:34:44.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1286, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-09T21:34:49.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1287, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-09T21:34:53.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1288, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-09T21:35:01.013' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1289, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-09T21:35:07.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1290, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-09T21:35:13.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1291, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-09T21:35:19.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1292, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-09T21:35:29.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1293, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-09T21:35:36.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1294, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-09T21:36:29.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1295, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-09T21:41:15.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1296, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-09T21:41:23.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1297, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T00:45:41.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1298, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T00:46:01.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1299, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T00:46:06.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1300, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T00:46:10.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1301, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T00:46:14.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1302, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T00:46:17.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1303, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T00:46:20.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1304, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T00:46:42.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1305, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T00:46:50.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1306, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T00:47:08.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1307, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T00:47:13.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1308, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T00:47:19.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1309, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-10T00:47:29.027' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1310, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T00:47:32.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1311, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T00:47:48.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1312, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T01:02:07.637' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1313, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T01:02:17.933' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1314, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T01:02:20.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1315, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T01:03:00.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1316, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T01:04:10.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1317, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T01:04:38.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1318, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T01:04:53.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1319, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T01:05:44.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1320, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T01:06:05.823' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1321, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T01:06:17.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1322, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T01:06:25.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1323, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T01:06:36.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1324, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T01:06:47.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1325, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T01:06:55.793' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1326, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T01:07:15.027' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1327, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-10T01:07:24.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1328, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-10T01:07:28.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1329, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T01:07:33.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1330, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T01:09:17.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1331, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T01:21:26.043' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1332, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T01:21:35.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1333, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T12:57:06.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1334, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T13:03:03.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1335, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T13:05:18.823' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1336, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T13:09:24.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1337, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T13:11:00.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1338, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T13:12:49.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1339, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T14:08:35.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1340, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T14:38:39.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1341, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T15:17:29.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1342, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T15:20:29.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1343, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T15:31:01.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1344, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T15:32:12.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1345, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T15:32:14.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1346, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T15:34:07.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1347, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T15:39:15.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1348, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T15:47:21.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1349, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T15:47:30.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1350, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T15:47:58.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1351, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T15:48:31.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1352, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T15:48:42.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1353, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T15:50:16.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1354, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T16:04:27.387' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1355, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T16:05:56.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1356, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T16:06:09.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1357, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T16:06:45.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1358, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T16:10:15.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1359, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T16:11:12.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1360, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T16:29:28.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1361, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T16:29:45.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1362, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T16:29:52.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1363, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T16:30:04.340' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1364, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T16:30:23.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1365, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T16:30:37.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1366, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T16:31:26.043' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1367, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T16:32:08.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1368, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T16:32:38.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1369, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T16:33:50.497' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1370, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T16:33:57.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1371, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T16:35:56.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1372, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T16:36:11.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1373, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T16:36:43.550' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1374, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T16:36:44.823' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1375, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T16:37:32.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1376, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T16:37:38.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1377, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T16:38:00.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1378, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T16:38:04.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1379, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T16:38:09.590' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1380, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T17:07:13.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1381, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T17:10:43.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1382, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T17:11:14.323' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1383, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T17:21:20.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1384, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T17:22:00.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1385, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T17:25:42.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1386, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T17:25:56.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1387, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T17:26:02.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1388, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T17:31:41.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1389, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T17:35:07.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1390, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T17:36:09.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1391, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T18:17:50.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1392, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T18:21:47.450' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1393, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T18:23:06.327' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1394, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T18:23:58.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1395, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T18:24:30.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1396, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T18:25:57.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1397, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T18:26:40.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1398, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T18:30:11.323' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1399, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T18:30:33.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1400, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T18:50:49.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1401, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T18:51:28.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1402, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T18:55:56.183' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1403, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T19:00:14.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1404, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T19:02:03.027' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1405, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T19:04:08.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1406, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T19:12:37.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1407, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T19:14:13.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1408, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-10T19:14:49.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1409, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-10T19:15:03.247' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1410, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-10T19:19:41.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1411, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T19:19:47.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1412, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T19:20:13.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1413, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T19:21:04.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1414, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T19:21:16.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1415, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T19:31:11.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1416, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T19:31:29.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1417, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T19:31:34.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1418, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T19:40:45.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1419, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T19:45:03.137' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1420, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T19:45:15.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1421, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-10T19:46:14.793' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1422, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T19:49:19.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1423, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T19:54:18.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1424, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T19:56:05.590' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1425, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T19:56:36.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1426, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T19:57:06.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1427, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T19:57:26.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1428, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-10T19:59:15.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1429, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T20:00:19.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1430, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T20:01:24.027' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1431, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T20:05:08.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1432, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T20:05:22.340' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1433, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T20:08:04.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1434, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:10:07.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1435, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-10T20:16:20.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1436, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T20:20:00.557' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1437, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-10T20:20:36.933' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1438, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T20:27:54.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1439, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:28:12.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1440, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:30:28.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1441, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:32:04.933' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1442, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:32:21.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1443, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:32:40.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1444, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:34:26.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1445, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:34:35.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1446, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:34:48.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1447, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:36:16.433' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1448, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T20:37:07.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1449, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:39:54.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1450, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T20:40:09.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1451, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T20:40:20.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1452, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T20:40:28.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1453, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T20:43:35.137' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1454, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:44:01.183' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1455, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-10T20:44:10.823' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1456, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:44:32.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1457, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:44:52.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1458, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:45:02.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1459, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:46:58.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1460, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T20:47:03.027' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1461, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T20:47:24.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1462, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-10T20:47:26.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1463, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T20:47:36.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1464, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T20:49:07.323' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1465, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T20:51:17.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1466, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T20:59:38.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1467, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T21:03:04.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1468, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T21:03:31.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1469, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T21:03:38.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1470, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T21:03:40.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1471, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-10T21:03:52.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1472, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T21:03:57.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1473, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T21:04:10.823' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1474, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T21:04:35.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1475, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T21:04:47.183' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1476, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T21:06:57.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1477, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T21:08:27.433' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1478, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T21:08:32.620' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1479, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T21:08:36.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1480, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T21:08:41.933' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1481, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T21:08:48.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1482, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-10T21:09:34.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1483, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-10T21:10:08.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1484, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T21:11:01.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1485, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T21:11:22.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1486, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T21:11:37.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1487, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-10T21:13:20.307' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1488, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-10T21:14:28.323' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1489, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-10T21:15:50.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1490, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-10T21:15:56.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1491, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-10T21:18:33.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1492, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T21:18:41.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1493, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-10T21:18:48.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1494, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T21:19:02.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1495, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T21:20:44.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1496, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-10T21:21:10.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1497, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T21:22:01.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1498, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-10T21:22:32.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1499, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-10T21:23:11.350' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1500, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T21:23:20.290' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1501, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T21:23:47.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1502, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T21:24:05.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1503, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-10T21:26:05.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1504, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-12T15:46:19.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1505, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-12T15:46:34.997' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1506, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-12T15:48:46.043' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1507, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-12T16:22:40.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1508, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-12T16:23:39.183' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1509, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-12T16:33:11.090' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1510, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-12T16:33:14.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1511, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-12T16:33:23.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1512, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-12T16:36:17.840' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1513, N'100', N'ilaya', 116, N'Rating ', CAST(N'2020-06-12T17:32:52.700' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1514, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-12T18:03:09.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1515, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-12T18:18:13.497' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1516, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-12T18:44:55.950' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1517, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-12T21:26:02.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1518, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-12T21:40:48.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1519, N'100', N'ilaya', 116, N'Ratings ', CAST(N'2020-06-12T21:41:00.823' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1520, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-12T21:42:02.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1521, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-12T21:48:36.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1522, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-12T21:49:21.853' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1523, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-12T21:49:37.247' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1524, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-12T21:49:43.213' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1525, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-12T21:50:14.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1526, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-19T12:41:57.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1527, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-19T12:42:02.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1528, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-19T12:42:11.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1529, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-19T12:42:21.337' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1530, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-19T12:42:42.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1531, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-19T12:44:10.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1532, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-19T12:46:41.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1533, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-19T12:50:42.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1534, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-19T12:51:28.823' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1535, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-19T13:51:02.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1536, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-19T13:51:47.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1537, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-19T13:52:09.510' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1538, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-19T14:08:25.073' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1539, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-19T14:12:45.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1540, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-19T14:21:54.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1541, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-19T14:22:11.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1542, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-19T14:22:32.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1543, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-19T14:23:11.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1544, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-19T14:26:28.883' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1545, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-19T14:27:47.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1546, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-19T15:12:45.383' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1547, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-19T15:16:50.963' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1548, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-19T15:17:16.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1549, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-19T15:17:21.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1550, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-19T16:06:45.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1551, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-19T16:07:31.200' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1552, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-19T16:12:16.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1553, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-19T17:07:16.697' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1554, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-19T17:12:05.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1555, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-19T17:12:38.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1556, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-19T18:26:11.760' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1557, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-19T18:27:52.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1558, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-19T18:29:34.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1559, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-19T18:58:29.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1560, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-19T18:58:42.290' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1561, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-19T19:11:43.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1562, N'100', N'ilaya', 116, N'Ratings ', CAST(N'2020-06-19T19:37:22.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1563, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-19T19:38:13.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1564, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-19T19:38:40.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1565, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-19T19:38:57.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1566, N'100', N'ilaya', 116, N'Ratings ', CAST(N'2020-06-19T19:40:51.027' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1567, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-20T21:33:42.350' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1568, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-20T21:40:45.350' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1569, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-20T21:41:02.707' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1570, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-20T22:48:51.393' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1571, N'100', N'ilaya', 116, N'Ratings ', CAST(N'2020-06-20T22:49:23.410' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1572, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-20T22:50:19.193' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1573, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-20T22:51:12.067' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1574, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-20T22:51:15.787' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1575, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-20T23:02:35.503' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1576, N'', N'', 2, N'User Management', CAST(N'2020-06-20T23:05:27.660' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1577, N'', N'', 80, N'ManageVideos', CAST(N'2020-06-20T23:05:39.550' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1578, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-20T23:06:06.490' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1579, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-20T23:15:02.253' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1580, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-20T23:21:03.893' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1581, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-20T23:21:57.223' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1582, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-20T23:22:55.630' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1583, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-20T23:38:45.553' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1584, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-20T23:42:39.100' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1585, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-20T23:46:23.770' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1586, N'100', N'ilaya', 116, N'Ratings ', CAST(N'2020-06-20T23:52:05.880' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1587, N'100', N'ilaya', 116, N'Ratings ', CAST(N'2020-06-20T23:56:22.753' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1588, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-20T23:56:26.817' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1589, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-20T23:57:22.287' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1590, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-20T23:59:15.410' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1591, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-21T00:03:17.660' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1592, N'', N'', 22, N'CRM', CAST(N'2020-06-21T00:06:16.973' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1593, N'', N'', 22, N'CRM', CAST(N'2020-06-21T00:07:26.253' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1594, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-21T00:07:41.440' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1595, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-21T00:10:09.990' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1596, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-21T00:15:23.210' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1597, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-21T00:17:00.677' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1598, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-21T00:24:22.353' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1599, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-21T00:27:31.050' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1600, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-21T00:34:08.707' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1601, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-21T02:04:49.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1602, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-21T02:06:18.270' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1603, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-21T13:52:38.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1604, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-21T14:04:46.783' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1605, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-21T14:05:58.533' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1606, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T01:15:57.440' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1607, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T01:16:00.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1608, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-23T01:17:07.270' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1609, N'105', N'testings', 116, N'Ratings ', CAST(N'2020-06-23T01:18:17.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1610, N'105', N'testings', 116, N'Ratings ', CAST(N'2020-06-23T01:19:30.987' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1611, N'105', N'testings', 83, N'ManageComments', CAST(N'2020-06-23T01:20:31.457' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1612, N'100', N'ilaya', 116, N'Ratings ', CAST(N'2020-06-23T01:21:18.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1613, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T01:21:28.050' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1614, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T01:21:34.957' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1615, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T01:21:54.783' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1616, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-23T01:26:07.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1617, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T01:26:11.020' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1618, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T01:26:15.643' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1619, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-23T01:26:21.533' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1620, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T01:26:28.253' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1621, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T01:26:38.817' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1622, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T01:26:58.393' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1623, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-23T01:27:37.347' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1624, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-23T01:27:43.737' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1625, N'100', N'ilaya', 12, N'Reports', CAST(N'2020-06-23T01:30:34.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1626, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-23T01:31:05.737' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1627, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-23T01:32:38.690' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1628, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T01:33:28.893' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1629, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-06-23T01:33:57.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1630, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T01:51:54.800' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1631, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:20:48.520' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1632, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:34:15.690' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1633, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:37:30.207' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1634, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:41:27.987' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1635, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-23T02:41:41.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1636, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-23T02:41:55.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1637, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-23T02:41:56.487' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1638, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:42:08.550' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1639, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:42:52.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1640, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:43:35.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1641, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:43:50.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1642, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:46:26.847' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1643, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T02:51:54.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1644, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T03:03:47.940' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1645, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T04:03:12.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1646, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-23T13:54:50.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1647, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T13:54:59.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1648, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T13:55:15.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1649, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T13:55:19.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1650, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T13:56:02.800' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1651, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-23T13:56:21.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1652, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T13:56:33.253' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1653, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T14:04:14.707' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1654, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T14:17:27.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1655, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-23T14:30:31.503' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1656, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-23T14:43:30.283' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1657, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T14:44:06.690' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1658, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-23T15:15:02.597' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1659, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T15:15:06.097' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1660, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T15:37:58.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1661, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T15:51:35.143' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1662, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T15:52:03.753' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1663, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T15:52:13.283' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1664, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T15:52:17.987' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1665, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T16:05:41.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1666, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T16:09:56.893' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1667, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T16:09:57.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1668, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-23T16:10:25.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1669, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T16:10:39.393' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1670, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T16:22:50.957' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1671, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T16:24:40.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1672, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-23T16:25:32.440' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1673, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-06-23T16:39:39.753' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1674, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-06-23T16:39:45.533' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1675, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-23T16:39:55.597' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1676, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-23T17:32:43.487' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1677, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T17:48:44.423' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1678, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T17:56:27.283' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1679, N'100', N'ilaya', 115, N'Document Management', CAST(N'2020-06-23T18:26:06.237' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1680, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-06-23T18:31:10.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1681, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-06-23T18:36:56.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1682, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T18:41:30.690' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1683, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T18:43:09.237' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1684, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-06-23T18:47:29.067' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1685, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T18:47:47.003' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1686, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T18:49:58.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1687, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T18:50:07.987' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1688, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T18:50:22.020' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1689, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T18:50:35.207' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1690, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T18:51:12.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1691, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-06-23T18:52:44.237' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1692, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T18:52:51.753' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1693, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T18:53:34.300' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1694, N'100', N'ilaya', 120, N'RPATest ', CAST(N'2020-06-23T18:53:53.270' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1695, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T18:58:51.863' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1696, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T19:00:13.487' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1697, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T19:00:28.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1698, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-06-23T19:00:35.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1699, N'100', N'ilaya', 22, N'CRM', CAST(N'2020-06-23T19:17:15.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1700, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-06-23T19:18:04.737' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1701, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-07-24T15:07:23.697' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1702, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-07-24T15:10:44.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1703, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-07-24T15:58:59.023' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1704, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-07-24T20:15:11.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1705, N'100', N'ilaya', 121, N'Sam ', CAST(N'2020-07-31T14:14:05.097' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1706, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-07-31T14:14:13.410' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1707, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-07-31T14:14:36.880' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1708, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-07-31T15:14:47.427' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1709, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-07-31T15:23:36.050' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1710, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-07-31T15:23:52.753' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1711, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T18:35:16.020' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1712, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T18:35:52.880' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1713, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T22:15:24.160' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1714, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T22:21:16.910' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1715, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T22:25:07.283' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1716, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T22:33:12.520' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1717, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T22:53:47.550' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1718, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-01T22:55:48.300' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1719, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T01:27:22.533' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1720, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T14:02:42.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1721, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T14:11:51.907' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1722, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T14:18:06.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1723, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T14:38:29.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1724, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T15:03:12.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1725, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T16:47:49.377' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1726, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T17:33:18.237' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1727, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T19:16:12.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1728, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T21:04:29.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1729, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-02T22:33:53.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1730, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-03T02:02:42.533' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1731, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-08-03T14:57:00.300' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1732, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-08-03T14:57:07.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1733, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-08-03T14:57:09.940' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1734, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-08-03T14:57:17.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1735, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-08-03T14:57:26.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1736, N'100', N'ilaya', 1, N'DashBoard', CAST(N'2020-08-03T14:57:28.160' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1737, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-03T15:45:43.673' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1738, N'109', N'admin', 83, N'ManageComments', CAST(N'2020-08-07T01:34:05.157' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1739, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-07T12:34:28.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1740, N'100', N'ilaya', 120, N'RPATests ', CAST(N'2020-08-07T12:51:27.563' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1741, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-08-13T15:08:05.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1742, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-08-19T22:34:30.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1743, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-08-19T22:48:11.060' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1744, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-08-20T20:14:43.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1745, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-08-20T20:14:49.417' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1746, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-08-20T20:15:04.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1747, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-08-27T15:15:21.787' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1748, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-08-27T15:16:02.380' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1749, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2020-08-27T15:16:07.410' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1750, N'100', N'ilaya', 18, N'TaskManagement', CAST(N'2020-08-27T15:16:15.520' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1751, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2020-08-27T15:16:21.850' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1752, N'100', N'ilaya', 109, N'CRM Contact', CAST(N'2020-08-27T15:16:44.037' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1753, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-08-27T15:17:11.067' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1754, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2020-08-27T15:17:37.677' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1755, N'100', N'ilaya', 11, N'SocialMedia', CAST(N'2020-08-27T15:18:31.613' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1756, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T12:30:03.897' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1757, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:28:16.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1758, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:29:20.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1759, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:34:48.910' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1760, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:36:00.490' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1761, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:44:05.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1762, N'', N'', 2, N'User Management', CAST(N'2020-10-01T14:48:05.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1763, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:49:03.430' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1764, N'', N'', 2, N'User Management', CAST(N'2020-10-01T14:50:53.567' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1765, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:51:52.803' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1766, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:57:16.580' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1767, N'', N'', 2, N'User Management', CAST(N'2020-10-01T14:57:49.433' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1768, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:58:44.793' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1769, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T14:58:59.727' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1770, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T15:00:50.693' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1771, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T15:02:56.420' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1772, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T15:03:29.067' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1773, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T16:18:51.967' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1774, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-10-01T16:20:08.743' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1775, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2020-10-01T16:20:44.700' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1776, N'100', N'ilaya', 2, N'User Management', CAST(N'2020-10-01T16:21:35.080' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1777, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T15:25:59.193' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1778, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T15:29:20.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1779, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T15:29:44.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1780, N'100', N'ilaya', 83, N'ManageComments', CAST(N'2021-10-04T15:37:50.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1781, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T16:03:11.113' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1782, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-10-04T16:10:16.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1783, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T16:15:57.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1784, N'103', N'karouji', 83, N'ManageComments', CAST(N'2021-10-04T16:17:35.180' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1785, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T16:33:37.330' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1786, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T16:49:11.940' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1787, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2021-10-04T16:58:11.177' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1788, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2021-10-04T16:58:15.373' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1789, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2021-10-04T16:58:16.210' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1790, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2021-10-04T16:58:20.897' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1791, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2021-10-04T16:58:45.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1792, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2021-10-04T16:59:26.250' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1793, N'100', N'ilaya', 8, N'Menu Management', CAST(N'2021-10-04T16:59:28.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1794, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-10-04T17:01:29.930' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1795, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2021-10-04T17:17:04.993' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1796, N'100', N'ilaya', 5, N'PPT Management', CAST(N'2021-10-04T17:21:26.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1797, N'103', N'karouji', 2, N'User Management', CAST(N'2021-10-25T12:51:00.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1798, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-25T15:15:50.983' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (1799, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-25T16:11:41.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2797, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T09:49:31.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2798, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T09:49:38.370' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2799, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T09:51:59.487' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2800, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T09:55:54.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2801, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T09:56:09.887' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2802, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:00:54.170' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2803, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:06:43.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2804, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:08:05.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2805, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:08:36.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2806, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:11:22.577' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2807, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:42:24.647' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2808, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:42:41.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2809, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:42:44.520' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2810, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:44:05.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2811, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:46:23.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2812, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:47:39.187' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2813, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:48:33.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2814, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:50:25.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2815, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:52:03.140' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2816, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:52:57.697' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2817, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:53:13.710' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2818, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:53:56.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2819, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:54:11.800' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2820, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:54:36.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2821, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:55:45.230' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2822, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T10:57:18.077' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2823, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:00:36.973' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2824, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:03:12.880' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2825, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:04:02.103' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2826, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:22:07.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2827, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:23:45.247' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2828, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:25:07.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2829, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:26:05.360' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2830, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-26T11:29:19.837' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2831, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T11:33:36.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2832, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-26T11:34:56.087' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2833, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-26T11:40:12.397' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2834, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-26T11:41:05.390' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2835, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T12:20:56.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2836, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T12:21:25.463' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2837, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T12:24:30.183' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2838, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T12:38:41.237' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2839, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T12:53:24.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2840, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T13:57:36.053' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2841, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T15:02:19.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2842, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T15:26:41.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2843, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T15:39:38.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2844, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T17:05:16.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2845, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T17:09:46.177' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2846, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T17:12:42.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2847, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T17:12:44.210' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2848, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T17:14:46.973' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2849, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T18:52:18.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2850, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-26T18:52:57.023' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2851, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T09:56:18.990' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2852, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T09:59:21.713' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2853, N'103', N'karouji', 2, N'User Management', CAST(N'2021-10-27T10:07:32.930' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2854, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T13:34:17.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2855, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T13:38:43.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2856, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T13:39:25.933' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2857, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T13:40:56.947' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2858, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T13:50:02.203' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2859, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T13:50:48.790' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2860, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T14:41:11.000' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2861, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T14:43:52.563' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2862, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T14:45:40.820' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2863, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T14:48:33.560' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2864, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T15:03:48.507' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2865, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T15:10:56.260' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2866, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T15:13:45.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2867, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T15:15:14.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2868, N'103', N'karouji', 2, N'User Management', CAST(N'2021-10-27T15:48:42.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2869, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T18:45:37.650' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2870, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-27T19:02:09.627' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2871, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T09:35:21.917' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2872, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T09:37:07.690' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2873, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T09:39:03.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2874, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T09:39:48.730' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2875, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T10:22:39.433' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2876, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:06:30.720' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2877, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:08:07.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2878, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:16:47.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2879, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:17:25.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2880, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:20:43.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2881, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:22:59.150' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2882, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:29:59.830' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2883, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:34:29.870' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2884, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:44:26.070' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2885, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:44:44.923' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2886, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:44:57.970' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2887, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:45:01.040' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2888, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:47:43.897' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2889, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:50:57.873' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2890, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:57:13.520' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2891, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T11:59:53.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2892, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:17:31.263' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2893, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:26:32.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2894, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:28:34.827' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2895, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:31:03.100' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2896, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:37:47.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2897, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:38:23.223' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2898, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:40:58.867' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2899, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:41:25.233' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2900, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T13:42:00.930' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2901, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:07:49.867' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2902, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:09:36.603' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2903, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:11:14.173' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2904, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:17:37.587' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2905, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:20:33.393' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2906, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:25:19.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2907, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:29:24.317' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2908, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:33:50.127' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2909, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:35:04.400' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2910, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:36:27.910' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2911, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:42:09.117' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2912, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:44:10.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2913, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-28T15:49:38.277' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2914, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-28T15:50:35.907' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2915, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-28T15:52:30.547' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2916, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-28T15:54:03.657' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2917, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T15:55:12.957' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2918, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-28T16:00:12.777' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2919, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T16:07:54.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2920, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T17:25:11.210' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2921, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T17:26:18.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2922, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T17:31:40.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2923, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T17:36:37.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2924, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T17:37:37.957' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2925, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T17:38:41.170' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2926, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T17:39:21.890' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2927, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T19:30:22.623' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2928, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T19:32:53.810' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2929, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T19:33:12.070' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2930, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T19:33:14.100' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2931, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T19:49:02.913' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2932, N'', N'', 80, N'ManageVideos', CAST(N'2021-10-28T19:53:23.500' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2933, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T19:59:31.750' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2934, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:01:22.403' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2935, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:02:22.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2936, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:03:26.817' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2937, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:04:18.327' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2938, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:12:23.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2939, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:15:45.433' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2940, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:18:16.280' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2941, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:23:15.473' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2942, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:26:51.523' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2943, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:42:30.540' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2944, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T20:50:07.953' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2945, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T21:04:10.410' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2946, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T21:21:37.243' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2947, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-28T22:01:42.310' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2948, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2021-10-29T20:40:23.667' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2949, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T11:13:52.163' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2950, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T11:15:44.717' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2951, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T11:25:39.703' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2952, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T11:26:18.980' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2953, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T11:26:39.770' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2954, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T11:58:12.313' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2955, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T11:59:22.030' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2956, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:00:34.407' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2957, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:01:46.003' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2958, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:02:23.107' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2959, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:04:03.860' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2960, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:06:15.460' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2961, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:07:00.123' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2962, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:08:28.900' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2963, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:09:01.680' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2964, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:10:09.057' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2965, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:12:43.553' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2966, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:13:18.630' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2967, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:14:34.437' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2968, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:15:21.517' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2969, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:18:15.497' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2970, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:20:18.457' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2971, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:20:40.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2972, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:21:24.623' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2973, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:23:31.267' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2974, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:26:44.793' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2975, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:39:55.877' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2976, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:41:15.190' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2977, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:42:03.653' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2978, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:43:35.010' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2979, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:44:02.273' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2980, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T12:45:53.757' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2981, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:47:43.523' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2982, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:48:50.440' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2983, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:49:17.117' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2984, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:51:54.530' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2985, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:52:27.527' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2986, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:53:20.263' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2987, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:54:52.573' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2988, N'', N'', 2, N'User Management', CAST(N'2021-11-01T12:56:12.543' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2989, N'', N'', 2, N'User Management', CAST(N'2021-11-01T13:04:14.007' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2990, N'', N'', 2, N'User Management', CAST(N'2021-11-01T13:04:38.683' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2991, N'', N'', 2, N'User Management', CAST(N'2021-11-01T13:10:04.120' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2992, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T13:10:16.293' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2993, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:11:03.643' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2994, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:11:28.553' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2995, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:12:13.820' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2996, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T13:24:50.367' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2997, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:25:15.317' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2998, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:25:35.547' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (2999, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:29:54.537' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3000, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:32:15.647' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3001, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:33:36.740' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3002, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:34:05.600' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3003, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:35:26.110' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3004, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:36:03.100' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3005, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:36:36.263' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3006, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:37:12.677' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3007, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:38:16.640' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3008, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:39:26.457' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3009, N'103', N'karouji', 2, N'User Management', CAST(N'2021-11-01T13:40:00.130' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3010, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T16:12:42.470' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3011, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:13:12.610' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3012, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T16:13:29.167' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3013, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T16:13:36.480' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3014, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:45:53.733' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3015, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:47:52.483' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3016, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:50:21.637' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3017, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:50:55.093' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3018, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:51:38.493' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3019, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T16:51:42.017' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3020, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:51:51.303' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3021, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:51:59.070' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3022, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T16:52:03.163' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3023, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-01T16:52:06.633' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3024, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-01T16:52:16.077' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3025, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-02T15:47:33.523' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3026, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-03T09:22:43.843' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3027, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-03T10:22:24.137' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3028, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-03T10:23:04.117' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3029, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-03T12:08:11.133' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3030, N'100', N'ilaya', 2, N'User Management', CAST(N'2021-11-05T17:59:18.100' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3031, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-05T18:00:44.013' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3032, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-05T19:43:42.747' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3033, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2021-11-05T19:46:14.380' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3034, N'103', N'karouji', 2, N'User Management', CAST(N'2022-01-27T16:35:35.593' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3035, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2022-01-27T16:35:55.003' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3036, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2022-01-27T16:38:15.513' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3037, N'103', N'karouji', 2, N'User Management', CAST(N'2022-01-27T16:51:29.153' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3038, N'103', N'karouji', 2, N'User Management', CAST(N'2022-01-28T14:37:30.707' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3039, N'103', N'karouji', 2, N'User Management', CAST(N'2022-02-07T09:58:22.717' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3040, N'103', N'karouji', 80, N'ManageVideos', CAST(N'2022-02-07T09:58:31.270' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3041, N'100', N'ilaya', 2, N'User Management', CAST(N'2022-02-23T17:26:47.850' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3042, N'100', N'ilaya', 2, N'User Management', CAST(N'2022-02-23T18:39:11.113' AS DateTime))
GO
INSERT [dbo].[ActivityReport] ([SerialNo], [UserId], [UserName], [MenuId], [MenuName], [VisitedDate]) VALUES (3043, N'100', N'ilaya', 80, N'ManageVideos', CAST(N'2022-02-23T18:39:13.020' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ActivityReport] OFF
GO
INSERT [dbo].[address] ([Name], [BuildingName], [BuidingNo], [street], [Area], [state_pin_Country]) VALUES (N'REVERPRO SERVICES (INDIA) PRIVATE LIMITED', N'HQ10 PRIMUS BUILDING', N' PLOT NO 7A, 1ST FLOOR', N'SIDCO INDUSTRIAL ESTATE', N' GUINDY, CHENNAI', N'TAMIL NADU 600032,INDIA')
GO
SET IDENTITY_INSERT [dbo].[ClientMGT] ON 
GO
INSERT [dbo].[ClientMGT] ([ID], [image], [Description], [ClientName], [Website]) VALUES (1, N'453.txt', N'asdas', N'sasd', N'asdsa')
GO
INSERT [dbo].[ClientMGT] ([ID], [image], [Description], [ClientName], [Website]) VALUES (2, N'3157648.png', N'xaax', N'GSS', N'www.gss.com')
GO
SET IDENTITY_INSERT [dbo].[ClientMGT] OFF
GO
SET IDENTITY_INSERT [dbo].[ClintUser] ON 
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'GSS.png', N'GSS Corporation aims to render valuable services for those companies which will fight to survive and aspire to win and grow in the current globalization moves.Together with those companies which are engaged with todayfs global mega-changes, GSS Corporation seeks to contribute to build a better place to live for the people in Japan and the rest of the world.



', N'GSS', N'www.gss.com', 1)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'Rlogic.jpg', N'R-Logic provides a range of services across three cores. And as such we would be able to meet all your needs in end-to-end solutions from customer service, onsite to back end component repair Depot Repair', N'Rlogic', N'rlogic.com', 2)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'challenger.png', N' Now 37 years old, Singaporefs only homegrown consumer electronics chain Challenger serves over 500,000 ValueClub members across 40 stores island-wide. Shop the latest IT gadgets, lifestyle products and services with peace of mind. Plus, earn up to 1.5% member rebates to maximise your big-ticket tech purchase. Canft find a product? Search Hachi.tech, Challengerfs online marketplace with over 50,000 products, offering local delivery or convenient in-store pickup.', N'Challenger', N'Challenger.com', 3)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', N'rwe
', N'AS', N'test.com', 4)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', NULL, N'QEWQW', NULL, 5)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', NULL, N'QEWQW', NULL, 6)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', N'tyu', N'yrtr', NULL, 7)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', N'ghjg', N'jghj', N'jghj', 8)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', N'asA', N'AS', N'zxz.com', 9)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', N'samsung', N'Samsung', N'www.samsung.com', 10)
GO
INSERT [dbo].[ClintUser] ([image], [Description], [ClientName], [Website], [id]) VALUES (N'[object FileList]', N'zcxxzc', N'user', N'www.perss.com', 11)
GO
SET IDENTITY_INSERT [dbo].[ClintUser] OFF
GO
SET IDENTITY_INSERT [dbo].[contentManagement] ON 
GO
INSERT [dbo].[contentManagement] ([Id], [Title], [Description], [created_by], [created_date], [Updated_by], [Updated_date]) VALUES (1, N'KAISOKKU', N'<span style="font-weight: bold;">The management reports include:</span><div><span style="font-weight: bold;">&nbsp; &nbsp; » </span>DRS Daily Reports&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; * DRS Daily Reports Statement<br></div><div><span style="font-weight: 700;">&nbsp; &nbsp; » </span>Warranty Daily Reports<br></div><div><span style="font-weight: 700;">&nbsp; &nbsp; »&nbsp;</span>Saw Discount
Daily Reports&nbsp; * Saw Service Action Works</div><div><span lang="EN-US" style="text-indent: -18pt;"><span style="font-variant-numeric: normal; font-variant-east-asian: normal; font-stretch: normal; line-height: normal;"><span style="font-weight: 700;">&nbsp; &nbsp; »</span>&nbsp;&nbsp;</span></span><span lang="EN-US" style="text-indent: -18pt;">Invoice
Update</span></div><div><span lang="EN-US" style="text-indent: -18pt;"><span style="font-weight: 700; text-indent: 0px;">&nbsp; &nbsp; »</span><span style="text-indent: 0px;"> Purchase Summary</span><br></span></div><div><span lang="EN-US" style="text-indent: -18pt;"><span style="font-weight: 700; text-indent: 0px;">&nbsp; &nbsp; » </span><span style="text-indent: 0px;">Profit &amp; Loss Reports</span><span style="text-indent: 0px;"><br></span></span></div><div><span lang="EN-US" style="text-indent: -18pt;"><span style="text-indent: 0px;"><br></span></span></div><div><span lang="EN-US" style="text-indent: -18pt;"><span style="text-indent: 0px;">&nbsp; &nbsp;Others</span></span></div>', N'User', CAST(N'2021-11-01T10:06:16.583' AS DateTime), N'User', CAST(N'2022-01-28T14:49:30.790' AS DateTime))
GO
INSERT [dbo].[contentManagement] ([Id], [Title], [Description], [created_by], [created_date], [Updated_by], [Updated_date]) VALUES (2, N'About KAisokku', N'<div>By using KAISOKKU, complicated management and aggregation processing by the store manager becomes unnecessary.</div><div>This enables strategic sales activities and increases sales.</div><div>In addition, it operates as an RPA (Robotic Process Automation) function to acquire and report accurate data.</div><div><div>This enables strategic sales activities and increases sales.</div><div>In addition, it operates as an RPA (Robotic Process Automation) function to acquire and report accurate data.</div></div><div><div>This enables strategic sales activities and increases sales.</div><div>In addition, it operates as an RPA (Robotic Process Automation) function to acquire and report accurate data.</div></div><div><div>This enables strategic sales activities and increases sales.</div><div>In addition, it operates as an RPA (Robotic Process Automation) function to acquire and report accurate data.</div></div><div><div>This enables strategic sales activities and increases sales.</div><div>In addition, it operates as an RPA (Robotic Process Automation) function to acquire and report accurate data.</div></div>', N'User', CAST(N'2021-11-01T10:08:13.353' AS DateTime), N'User', CAST(N'2022-02-07T14:16:02.087' AS DateTime))
GO
INSERT [dbo].[contentManagement] ([Id], [Title], [Description], [created_by], [created_date], [Updated_by], [Updated_date]) VALUES (3, N'Technology', N'Selenium is a powerful tool for controlling web browsers through programs and performing browser automation. It is functional for all browsers, works on all major OS and its scripts are written in various languages i.e Python, Java, C#, etc, we will be working with Python.', N'User', CAST(N'2021-11-01T10:08:51.140' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[contentManagement] ([Id], [Title], [Description], [created_by], [created_date], [Updated_by], [Updated_date]) VALUES (4, N'Product and Services', N'<div><div><span style="font-weight: bold;">There are two types of KAISOKKU.</span></div><div>» Cloud service and PC service.&nbsp;</div><div>» Contact our sales agent to get details for more information on the management report.</div></div><div><div><span style="font-weight: bold;">There are two types of KAISOKKU.</span></div><div>» Cloud service and PC service.&nbsp;</div><div>» Contact our sales agent to get details for more information on the management report.</div><div><span style="font-weight: bold;">There are two types of KAISOKKU.</span></div><div>» Cloud service and PC service.&nbsp;</div><div>» Contact our sales agent to get details for more information on the management report.</div></div><div><br></div>', N'User', CAST(N'2021-11-01T10:10:11.423' AS DateTime), N'User', CAST(N'2022-02-07T14:19:24.720' AS DateTime))
GO
INSERT [dbo].[contentManagement] ([Id], [Title], [Description], [created_by], [created_date], [Updated_by], [Updated_date]) VALUES (5, N'vastu', N'<span style="font-weight: bold; font-style: italic; text-decoration-line: underline;">to perform operation into the data</span>', N'User', CAST(N'2021-11-05T18:25:28.560' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[contentManagement] OFF
GO
SET IDENTITY_INSERT [dbo].[CRMContents] ON 
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (1, N'1', N'Alwin', N'alwin chimp', 1, NULL, N'test', 1, CAST(N'2020-06-06T20:09:46.793' AS DateTime), N'ilaya', CAST(N'2020-06-19T14:12:04.463' AS DateTime), NULL, N'alwin@gmail.com', 1)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (2, NULL, N'Contact', N'Company', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Email
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (3, NULL, N'Patrick', N'Adams', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Inactive
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (4, NULL, N'Karen', N'Adams', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Active
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (5, NULL, N'Nancy', N'Adams', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Inactive
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (6, NULL, N'Eric', N'Adams', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Inactive
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (7, NULL, N'Christine', N'Adams', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Inactive
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (8, N'2', N'Avon', N'AV', 1, NULL, N'test', 1, CAST(N'2020-06-10T18:24:46.277' AS DateTime), N'ilaya', NULL, NULL, N'avon@gmail.com', 1)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (9, N'3', N'Kevin', N'Owen', 1, NULL, N'test', 1, CAST(N'2020-06-10T19:32:27.103' AS DateTime), N'ilaya', NULL, NULL, N'kevin@gmail.com', 1)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (10, NULL, N'Contact', N'Company', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Email
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (11, NULL, N'Robery ', N'Dk', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'robert@gmail.com
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (12, NULL, N'Alvin', N'Dn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'alvin@gmail.com
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (13, NULL, N'Contact', N'Company', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Email
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (14, NULL, N'Robert', N'FJ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'robertg@gmail.com
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (15, NULL, N'Albert', N'SD', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'alvins@gmail.com
', NULL)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (16, N'3', NULL, NULL, 1, NULL, N'test', 1, CAST(N'2020-06-10T19:38:25.510' AS DateTime), N'ilaya', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (17, N'4', NULL, NULL, 1, NULL, N'test', 1, CAST(N'2020-06-19T13:52:58.400' AS DateTime), N'ilaya', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (18, N'4', N'test', N'qa', 1, NULL, N'test', 1, CAST(N'2020-06-19T14:02:48.777' AS DateTime), N'ilaya', NULL, NULL, N'testing@gmail.com', 1)
GO
INSERT [dbo].[CRMContents] ([UserCustomId], [UserId], [ContactName], [CompanyName], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType]) VALUES (19, N'5', N'Alwin', N'alwin chimp', 1, NULL, N'test', 1, CAST(N'2020-06-21T00:12:31.363' AS DateTime), N'ilaya', NULL, NULL, N'alwin@gmail.com', 1)
GO
SET IDENTITY_INSERT [dbo].[CRMContents] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerDetails] ON 
GO
INSERT [dbo].[CustomerDetails] ([CustomerID], [CustUserID], [Password], [FirstName], [LastName], [Mobile], [Email], [State], [Country], [Zipcode], [CompanyName], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [CustomerType]) VALUES (1, N'100', N'123', N'raja', N'ram', N'4545', N'ramsguna97@gmail.com', N'tn', N'india', N'634334', N'prodev', N'ip', 1, CAST(N'2018-10-04T11:42:02.040' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:42:02.040' AS DateTime), N'ilaya', 1)
GO
INSERT [dbo].[CustomerDetails] ([CustomerID], [CustUserID], [Password], [FirstName], [LastName], [Mobile], [Email], [State], [Country], [Zipcode], [CompanyName], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [CustomerType]) VALUES (2, N'101', N'4555', N'senthil', N'kumar', N'3434', N'smartdavidm@gmail.com', N'tn', N'india', N'634334', N'prodep', N'ip', 1, CAST(N'2018-10-04T11:42:02.040' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:42:02.040' AS DateTime), N'ilaya', 2)
GO
INSERT [dbo].[CustomerDetails] ([CustomerID], [CustUserID], [Password], [FirstName], [LastName], [Mobile], [Email], [State], [Country], [Zipcode], [CompanyName], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [CustomerType]) VALUES (6, N'102', N'124', N'david', N'chandran', N'43434', N'balrajswamy@gmail.com', N'tn', N'india', N'644444', N'hcl', N'ip', 1, CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', 2)
GO
INSERT [dbo].[CustomerDetails] ([CustomerID], [CustUserID], [Password], [FirstName], [LastName], [Mobile], [Email], [State], [Country], [Zipcode], [CompanyName], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [CustomerType]) VALUES (7, N'103', N'454', N'rahem', N'billa', N'4555', N'prabu6694@gmail.com', N'tn', N'india', N'454545', N'syntel', N'ip', 1, CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', 1)
GO
SET IDENTITY_INSERT [dbo].[CustomerDetails] OFF
GO
INSERT [dbo].[Documentfiles] ([mediaid], [filename]) VALUES (1, N'testsam.pptx')
GO
INSERT [dbo].[Documentfiles] ([mediaid], [filename]) VALUES (2, N'Report.xlsx')
GO
INSERT [dbo].[enquiryform] ([Name], [Email], [phoneno], [comments]) VALUES (N'bharathiraja', N'test@gmail.com', 23323, N'no')
GO
INSERT [dbo].[enquiryform] ([Name], [Email], [phoneno], [comments]) VALUES (N'rrr', N'rrr', 33, N'gg')
GO
INSERT [dbo].[enquiryform] ([Name], [Email], [phoneno], [comments]) VALUES (NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[HitCounter] ([HitCounterId], [CountryName], [Visiteddate], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'India', CAST(N'2020-05-04T00:00:00.000' AS DateTime), N'172.168.87.34', 1, CAST(N'2020-05-04T00:00:00.000' AS DateTime), N'Admin', CAST(N'2020-05-04T00:00:00.000' AS DateTime), N'Admin')
GO
INSERT [dbo].[HitCounter] ([HitCounterId], [CountryName], [Visiteddate], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (5, N'India', CAST(N'2020-05-11T00:00:00.000' AS DateTime), N'172.168.72.43', 1, CAST(N'2020-05-11T00:00:00.000' AS DateTime), N'LocalUser', CAST(N'2020-05-11T00:00:00.000' AS DateTime), N'LocalUser')
GO
SET IDENTITY_INSERT [dbo].[MenuMaster] ON 
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (1, N'Dashboard', N'Home', N'DashBoard', 0, 1, N'fa fa-tachometer', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'ダッシュボード', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (2, N'User Management', N'Home', N'UserManagement', 0, 1, N'fa fa-user', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'ユーザー管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (4, N'Video Management', N'Home', NULL, 0, 1, N'fa fa-laptop', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'ビデオ管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (5, N'PPT Management', N'Home', N'PPTManagement', 0, 1, N'fa fa-file-powerpoint-o', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'PPT管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (6, N'RPA Sample Report', N'Home', NULL, 0, 1, N'fa fa-pie-chart', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'RPAサンプルレポート', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (7, N'Page Management', N'Home', NULL, 0, 1, N'fa fa-edit', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'ページ管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (8, N'Menu Management', N'Home', N'MenuManagement', 0, 1, N'fa fa-table', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'メニュー管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (9, N'Activity Management', N'Home', N'ActivityManagement', 0, 1, N'fa fa-map', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'活動管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (10, N'CRM', N'Home', NULL, 0, 1, N'fa fa-handshake-o', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'CRM', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (11, N'Socila Media', N'Home', NULL, 0, 1, N'fa fa-th-large', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'ソーシャルメディア', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (12, N'Reports', N'Home', N'Reports', 0, 1, N'fa fa-list-alt', N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'報告書', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (18, N'Task Management', N'Home', N'RPASampleReports', 6, 1, NULL, N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'タスク管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (22, N'CRM1', N'Home', N'CRM', 10, 1, NULL, N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'CRM1', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (23, N'SocialMedia1', N'Home', N'SocialMedia', 11, 1, NULL, N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:22.993' AS DateTime), N'ilaya', N'ソーシャルメディア1', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (80, N'ManageVideos', N'Home', N'VideoManagement', 4, 1, NULL, N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', N'ビデオを管理する', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (83, N'ManageComments', N'Home', N'VideoComments', 4, 1, NULL, N'ip', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', N'マネージャーコメント', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (109, N'CRM Contact', N'Home', N'CRMContact', 10, 1, NULL, N'ip', CAST(N'2020-05-26T21:09:57.703' AS DateTime), N'ilaya', CAST(N'2020-05-26T21:09:57.703' AS DateTime), N'ilaya', N'CRM連絡先', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (115, N'Document Management', N'Home', N'DocManagement', 0, 1, N'fa fa-file-text', N'ip', CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya', CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya', N'
文書管理', 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (120, N'RPATests', N'Home', N'PageManagement', 7, 1, NULL, N'ip', CAST(N'2020-06-23T01:21:34.933' AS DateTime), N'ilaya', CAST(N'2020-06-23T18:59:58.433' AS DateTime), N'', NULL, 0)
GO
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [ControllerName], [ActionMethod], [MenuParentId], [IsActive], [MenuParentCss1], [IpAddress], [createddate], [createdby], [updateddate], [updatedby], [LanguageJapanease], [IsJapanLang]) VALUES (121, N'Sam', N'Home', N'PageManagement', 7, 1, NULL, N'ip', CAST(N'2020-06-23T19:00:28.980' AS DateTime), N'ilaya', CAST(N'2020-06-23T19:01:36.247' AS DateTime), N'ilaya', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[MenuMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PageManagement] ON 
GO
INSERT [dbo].[PageManagement] ([pagefilename], [pagedescription], [mediafiletype], [pagecontent], [mediafolder], [FolderID], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [pageId], [UserId], [AdminRights], [PageMenuId]) VALUES (N'RPATests', N'hai', N'MIX', N'bharathiraja<div>hai</div>', N'PM', 1, N'testip', 1, CAST(N'2020-06-23T01:22:10.097' AS DateTime), N'ilaya', CAST(N'2020-08-07T13:01:35.157' AS DateTime), N'ilaya', 83, N'109', N'Yes', 120)
GO
INSERT [dbo].[PageManagement] ([pagefilename], [pagedescription], [mediafiletype], [pagecontent], [mediafolder], [FolderID], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [pageId], [UserId], [AdminRights], [PageMenuId]) VALUES (N'RPATests', NULL, N'MIX', N'test - Page management', N'PM', 1, N'testip', 1, CAST(N'2020-06-23T01:26:54.970' AS DateTime), N'ilaya', NULL, NULL, 84, N'109', N'Yes', 120)
GO
INSERT [dbo].[PageManagement] ([pagefilename], [pagedescription], [mediafiletype], [pagecontent], [mediafolder], [FolderID], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [pageId], [UserId], [AdminRights], [PageMenuId]) VALUES (N'RPATests', N'Run', N'MIX', N'<span style="font-size: xx-large;">,kkkm</span>', N'PM', 1, N'testip', 1, CAST(N'2020-06-23T18:51:54.487' AS DateTime), N'ilaya', CAST(N'2021-10-19T13:54:02.510' AS DateTime), N'ilaya', 85, N'105', N'Yes', 120)
GO
SET IDENTITY_INSERT [dbo].[PageManagement] OFF
GO
INSERT [dbo].[PageManagementFolder] ([folderId], [folderName], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'PM', N'TEST', 1, CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya', CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (0, N'dummy_1.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (3, N'dummy_1.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (6, N'KUMAR.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (7, N'billa.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (8, N'sugumar.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (21, N'ol.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (20, N'hjhj.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (26, N'skyblue.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (27, N'jack.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (25, N'NaturalFlower-.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (28, N'hss.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (29, N'eee.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (30, N'general.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (39, N'testsam (1).pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (41, N']IndiaLab_English.pptx')
GO
INSERT [dbo].[PPTfiles] ([mediaid], [filename]) VALUES (42, N'NaturalFlower-.pptx')
GO
SET IDENTITY_INSERT [dbo].[Pricemgt] ON 
GO
INSERT [dbo].[Pricemgt] ([Id], [Product_Name], [Validity], [Price]) VALUES (1, N'Colud', N'365 days', CAST(449.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricemgt] ([Id], [Product_Name], [Validity], [Price]) VALUES (2, N'Private cloud', N'90 days', CAST(299.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricemgt] ([Id], [Product_Name], [Validity], [Price]) VALUES (3, N'Premises', N'90 days', CAST(599.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Pricemgt] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 
GO
INSERT [dbo].[RoleMaster] ([RoleId], [Name], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'Normal User', N'ip', 1, CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya', CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMaster] ([RoleId], [Name], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (2, N'Admin', N'ip', 1, CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya', CAST(N'2018-12-18T07:02:31.317' AS DateTime), N'ilaya')
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMenuMapping] ON 
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, 2, 1, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (2, 2, 2, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (4, 2, 4, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (5, 2, 5, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (6, 2, 6, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (7, 2, 7, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (8, 2, 8, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (9, 2, 9, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (10, 2, 10, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (11, 2, 11, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (12, 2, 12, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (29, 2, 18, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (33, 2, 22, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (34, 2, 23, N'ip', 1, CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya', CAST(N'2018-10-04T11:50:34.570' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (88, 2, 80, N'ip', 1, CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (89, 2, 83, N'ip', 1, CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (114, 2, 109, N'ip', 1, CAST(N'2020-05-26T21:09:57.703' AS DateTime), N'ilaya', CAST(N'2020-05-26T21:09:57.703' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (115, 2, 115, N'ip', 1, CAST(N'2020-05-26T21:09:57.703' AS DateTime), N'ilaya', CAST(N'2020-05-26T21:09:57.703' AS DateTime), N'ilaya')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (120, 2, 120, N'ip', 1, CAST(N'2020-06-23T01:21:34.933' AS DateTime), N'ilaya', CAST(N'2020-06-23T18:59:58.433' AS DateTime), N'')
GO
INSERT [dbo].[RoleMenuMapping] ([RoleMenuMapId], [RoleId], [MenuId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (121, 2, 121, N'ip', 1, CAST(N'2020-06-23T19:00:28.980' AS DateTime), N'ilaya', CAST(N'2020-06-23T19:01:36.247' AS DateTime), N'ilaya')
GO
SET IDENTITY_INSERT [dbo].[RoleMenuMapping] OFF
GO
INSERT [dbo].[SocialMediaFiles] ([SocialMediaId], [Filename]) VALUES (12, N'facebook.png')
GO
INSERT [dbo].[SocialMediaFiles] ([SocialMediaId], [Filename]) VALUES (16, N'dc.jpg')
GO
INSERT [dbo].[SocialMediaFiles] ([SocialMediaId], [Filename]) VALUES (17, N'Tree.png')
GO
SET IDENTITY_INSERT [dbo].[SocialMeida] ON 
GO
INSERT [dbo].[SocialMeida] ([SocialMediaID], [Title], [URL], [Filename]) VALUES (8, N't', N't', N'C:\inetpub\wwwroot\RpaSaleDev\Images\')
GO
INSERT [dbo].[SocialMeida] ([SocialMediaID], [Title], [URL], [Filename]) VALUES (12, N'Demo', N'https://www.facebook.com/', N'C:\inetpub\wwwroot\RpaSaleDev\Images\')
GO
INSERT [dbo].[SocialMeida] ([SocialMediaID], [Title], [URL], [Filename]) VALUES (16, N'Insta', N'https://www.instagram.com', N'C:\inetpub\wwwroot\RpaSaleDev\Images\')
GO
INSERT [dbo].[SocialMeida] ([SocialMediaID], [Title], [URL], [Filename]) VALUES (17, N'', N'', N'C:\inetpub\wwwroot\RpaSaleDev\Images\')
GO
SET IDENTITY_INSERT [dbo].[SocialMeida] OFF
GO
SET IDENTITY_INSERT [dbo].[TableMapping] ON 
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (1, 9, N'[dbo].[ActivityReport]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (2, 22, N'[dbo].[CustomerDetails]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (3, 1, N'[dbo].[HitCounter]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (5, 7, N'[dbo].[PageManagementFolder]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (6, 5, N'[dbo].[PPTfiles]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (7, 5, N'[dbo].[PPTFolder]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (8, 2, N'[dbo].[RoleMaster]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (9, 8, N'[dbo].[RoleMenuMapping]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (10, 5, N'[dbo].[tbl_PPTUPLOAD]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (11, 80, N'[dbo].[tbl_VideoMedia]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (12, 2, N'[dbo].[UserMaster]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (13, 1, N'[dbo].[Video_view_log]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (14, 80, N'[dbo].[videofiles]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (15, 8, N'[dbo].[MenuMaster]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (16, 12, N'[dbo].[tbl_PPTUPLOAD]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (17, 12, N'[dbo].[tbl_VideoMedia]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (22, 83, N'[dbo].[VideoComments]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (24, 18, N'[dbo].[TaskMaster]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (45, 23, N'[dbo].[SocialMedia1]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (46, 23, N'[dbo].[SocialMediaFiles]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (49, 115, N'[dbo].[tbl_Document]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (50, 115, N'[dbo].[tbl_Document]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (51, 109, N'[dbo].[CRMContents]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (52, 116, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (53, 116, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (54, 116, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (55, 116, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (56, 116, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (57, 116, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (58, 119, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (59, 120, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (60, 120, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (61, 120, N'[dbo].[PageManagement]')
GO
INSERT [dbo].[TableMapping] ([Sno], [MenuId], [TableName]) VALUES (62, 120, N'[dbo].[PageManagement]')
GO
SET IDENTITY_INSERT [dbo].[TableMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TableMappingClient] ON 
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (1, N'[dbo].[VideoComments]', N'Video', N'Home', N'UserVideo', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (2, N'[dbo].[tbl_videomedia]', N'Video', N'Home', N'UserVideo', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (3, N'[dbo].[videofiles]', N'Video', N'Home', N'UserVideo', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (4, N'[dbo].[PPTfiles]', N'Presentation', N'Home', N'UserPresentation', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (5, N'[dbo].[tbl_PPTUPLOAD]', N'Presentation', N'Home', N'UserPresentation', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (6, N'[dbo].[ClintUser]', N'Clients', N'Home', N'UserClient', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (7, N'[dbo].[SocialMeida]', N'Social Media', N'Home', N'UserSocialMedia', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (8, N'[dbo].[SocialMediaFiles]', N'Social Media', N'Home', N'UserSocialMedia', 0)
GO
INSERT [dbo].[TableMappingClient] ([Sno], [TableName], [MenuName], [ControllerName], [ActionMethod], [DummyMenuId]) VALUES (9, N'[dbo].[enquiryform]', N'Contact Us', N'Home', N'UserContactUs', 0)
GO
SET IDENTITY_INSERT [dbo].[TableMappingClient] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskMaster] ON 
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'Smaple1', N'SampleVideo1111', 101, N'67.90.890', 0, CAST(N'2020-05-22T14:06:30.013' AS DateTime), N'ilaya', CAST(N'2020-05-24T19:11:52.483' AS DateTime), NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (2, N'DemoTask', N'Task', 107, N'67.90.890', 0, CAST(N'2020-05-22T18:03:18.450' AS DateTime), N'ilaya', CAST(N'2020-05-22T18:03:38.670' AS DateTime), NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (3, N'RPA Download', N'RPA Download', 100, N'67.90.890', 1, CAST(N'2020-05-24T19:12:15.403' AS DateTime), N'ilaya', CAST(N'2020-06-21T02:06:25.197' AS DateTime), NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (4, N'demo1', N'demo1', 100, N'67.90.890', 0, CAST(N'2020-05-24T19:26:29.810' AS DateTime), N'ilaya', CAST(N'2020-05-24T19:27:10.637' AS DateTime), NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (5, N'QAA', N'Testing', 100, N'67.90.890', 0, CAST(N'2020-06-05T16:34:21.697' AS DateTime), N'ilaya', CAST(N'2020-06-05T16:34:35.617' AS DateTime), NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (6, N'RPA ', N'Upload', 100, N'67.90.890', 1, CAST(N'2020-06-05T16:38:19.773' AS DateTime), N'ilaya', CAST(N'2020-06-23T18:46:22.107' AS DateTime), NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (7, N'', N'', 105, N'67.90.890', 0, CAST(N'2020-06-09T17:49:40.160' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (8, N'', N'', 100, N'67.90.890', 0, CAST(N'2020-06-09T17:50:18.113' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (9, N'Auto', N'Auto', 100, N'67.90.890', 0, CAST(N'2020-06-10T19:13:48.490' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (10, N'Login', N'test', 105, N'67.90.890', 0, CAST(N'2020-06-10T20:06:26.897' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (11, N'illl', N'illll', 100, N'67.90.890', 0, CAST(N'2020-06-20T21:34:04.107' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[TaskMaster] ([TaskMasterId], [TaskName], [TaskDescription], [UserId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (12, N'Tests', N'Tests', 105, N'67.90.890', 0, CAST(N'2020-06-23T18:42:26.543' AS DateTime), N'ilaya', CAST(N'2020-06-23T18:45:03.810' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[TaskMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Document] ON 
GO
INSERT [dbo].[tbl_Document] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'aaa', N'aaa', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'111.121.345', 0, CAST(N'2020-06-10T01:09:13.333' AS DateTime), N'ilaya', CAST(N'2020-06-10T19:52:57.910' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_Document] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (2, N'Avon', N'qa', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'111.121.345', 1, CAST(N'2020-06-10T19:49:56.537' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_Document] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (3, N'', N'', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'111.121.345', 0, CAST(N'2020-06-19T17:08:54.310' AS DateTime), N'ilaya', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_Document] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_DRS_rep] ON 
GO
INSERT [dbo].[tbl_DRS_rep] ([ServiceOrderNo], [LastUpdatedUser], [BillingUser], [BillingDate], [GoodsDeliveredDate], [IsActive], [Engineer], [Product], [inLabour], [inParts], [inTransport], [inothers], [inTax], [inTotal], [outLabour], [outParts], [outTransport], [outothers], [outTax], [outTotal], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'MAHESWARI', N'MAHESWARI', CAST(N'2020-06-01T12:00:09.937' AS DateTime), CAST(N'2020-06-01T12:00:09.937' AS DateTime), 1, N'RAJAK', N'HHP', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(839 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(151 AS Decimal(18, 0)), CAST(990 AS Decimal(18, 0)), CAST(N'2020-06-01T12:00:09.937' AS DateTime), N'admin', NULL, NULL)
GO
INSERT [dbo].[tbl_DRS_rep] ([ServiceOrderNo], [LastUpdatedUser], [BillingUser], [BillingDate], [GoodsDeliveredDate], [IsActive], [Engineer], [Product], [inLabour], [inParts], [inTransport], [inothers], [inTax], [inTotal], [outLabour], [outParts], [outTransport], [outothers], [outTax], [outTotal], [createddate], [createdby], [updateddate], [updatedby]) VALUES (2, N'POOJA', N'POOJA', CAST(N'2020-06-01T12:02:22.777' AS DateTime), CAST(N'2020-06-01T12:02:22.777' AS DateTime), 1, N'KADAM', N'HHP', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), CAST(3381 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(151 AS Decimal(18, 0)), CAST(990 AS Decimal(18, 0)), CAST(N'2020-06-01T12:02:22.777' AS DateTime), N'admin', NULL, NULL)
GO
INSERT [dbo].[tbl_DRS_rep] ([ServiceOrderNo], [LastUpdatedUser], [BillingUser], [BillingDate], [GoodsDeliveredDate], [IsActive], [Engineer], [Product], [inLabour], [inParts], [inTransport], [inothers], [inTax], [inTotal], [outLabour], [outParts], [outTransport], [outothers], [outTax], [outTotal], [createddate], [createdby], [updateddate], [updatedby]) VALUES (3, N'POOJA', N'POOJA', CAST(N'2020-06-01T12:02:51.023' AS DateTime), CAST(N'2020-06-01T12:02:51.023' AS DateTime), 1, N'KADAM', N'HHP', CAST(111 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(123 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), CAST(3381 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(151 AS Decimal(18, 0)), CAST(990 AS Decimal(18, 0)), CAST(N'2020-06-01T12:02:51.023' AS DateTime), N'admin', NULL, NULL)
GO
INSERT [dbo].[tbl_DRS_rep] ([ServiceOrderNo], [LastUpdatedUser], [BillingUser], [BillingDate], [GoodsDeliveredDate], [IsActive], [Engineer], [Product], [inLabour], [inParts], [inTransport], [inothers], [inTax], [inTotal], [outLabour], [outParts], [outTransport], [outothers], [outTax], [outTotal], [createddate], [createdby], [updateddate], [updatedby]) VALUES (4, N'Mahes', N'Mahes', CAST(N'2020-06-01T12:03:40.557' AS DateTime), CAST(N'2020-06-01T12:03:40.557' AS DateTime), 1, N'Rafik', N'HHP', CAST(111 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(123 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2345 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), CAST(3381 AS Decimal(18, 0)), CAST(5788 AS Decimal(18, 0)), CAST(151 AS Decimal(18, 0)), CAST(150 AS Decimal(18, 0)), CAST(N'2020-06-01T12:03:40.557' AS DateTime), N'admin', NULL, NULL)
GO
INSERT [dbo].[tbl_DRS_rep] ([ServiceOrderNo], [LastUpdatedUser], [BillingUser], [BillingDate], [GoodsDeliveredDate], [IsActive], [Engineer], [Product], [inLabour], [inParts], [inTransport], [inothers], [inTax], [inTotal], [outLabour], [outParts], [outTransport], [outothers], [outTax], [outTotal], [createddate], [createdby], [updateddate], [updatedby]) VALUES (5, N'rojku', N'rojku', CAST(N'2020-06-01T12:04:05.677' AS DateTime), CAST(N'2020-06-01T12:04:05.677' AS DateTime), 1, N'Rafik', N'HHP', CAST(111 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(123 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2345 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), CAST(3381 AS Decimal(18, 0)), CAST(5788 AS Decimal(18, 0)), CAST(151 AS Decimal(18, 0)), CAST(150 AS Decimal(18, 0)), CAST(N'2020-06-01T12:04:05.677' AS DateTime), N'admin', NULL, NULL)
GO
INSERT [dbo].[tbl_DRS_rep] ([ServiceOrderNo], [LastUpdatedUser], [BillingUser], [BillingDate], [GoodsDeliveredDate], [IsActive], [Engineer], [Product], [inLabour], [inParts], [inTransport], [inothers], [inTax], [inTotal], [outLabour], [outParts], [outTransport], [outothers], [outTax], [outTotal], [createddate], [createdby], [updateddate], [updatedby]) VALUES (6, N'Bolu', N'bolunk', CAST(N'2020-06-01T12:04:30.143' AS DateTime), CAST(N'2020-06-01T12:04:30.143' AS DateTime), 1, N'Rafik', N'HHP', CAST(111 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(123 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2345 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), CAST(3381 AS Decimal(18, 0)), CAST(5788 AS Decimal(18, 0)), CAST(151 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)), CAST(N'2020-06-01T12:04:30.143' AS DateTime), N'admin', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_DRS_rep] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_PPTUPLOAD] ON 
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (15, N'te', N'te', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-20T13:59:04.577' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (16, NULL, NULL, N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-20T14:28:11.780' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (17, N'test', N'ing', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-20T16:16:33.013' AS DateTime), N'ilaya', CAST(N'2020-05-20T17:35:31.030' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (18, N'hjjg', N'ghjj', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-20T17:54:20.687' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (19, N'fg1', N'fg1', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-22T01:11:31.950' AS DateTime), N'ilaya', CAST(N'2020-05-22T18:02:22.483' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (20, N'gh', N'gh', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-22T12:48:40.043' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (21, N'ol', N'ol', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-24T15:16:31.637' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (22, N'Nature', N'Flower', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-24T15:45:09.873' AS DateTime), N'ilaya', CAST(N'2020-06-05T16:13:40.760' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (23, N'ggg', N'ppt', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-24T16:14:50.263' AS DateTime), N'ilaya', CAST(N'2020-06-05T16:14:59.133' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (24, N'Sample', N'Sapme', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-24T18:55:26.077' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (25, N'Demo1', N'Demo1', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-05-24T18:56:24.983' AS DateTime), N'ilaya', CAST(N'2020-05-24T18:59:56.967' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (26, N'sky', N'sky', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-06T20:11:32.537' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (27, N'jacks', N'jacks', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-06T21:28:19.257' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (28, N'hss', N'hss', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-06T21:41:33.460' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (29, N'eee', N'eee', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-06T21:46:56.363' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (30, N'general', N'general', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-06T22:00:04.973' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (31, N'.net', N'testsam', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-07T01:14:59.863' AS DateTime), N'ilaya', CAST(N'2020-06-09T17:29:17.740' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (32, N'New', N'latest', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-09T17:34:25.803' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (33, N'Build', N'Auto', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-09T17:36:41.927' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (34, N'', N'', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-09T18:00:22.333' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (35, N'Georges', N'Jungles', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 1, CAST(N'2020-06-09T21:26:20.037' AS DateTime), N'ilaya', CAST(N'2020-06-23T18:38:43.107' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (36, N'Alpha', N'beta', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-10T15:39:14.863' AS DateTime), N'ilaya', CAST(N'2020-06-10T15:45:55.520' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (37, N'', N'', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-10T19:06:39.693' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (38, N'Testing ', N'QAA', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 1, CAST(N'2020-06-10T19:07:30.020' AS DateTime), N'ilaya', CAST(N'2020-06-10T19:08:36.333' AS DateTime), NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (39, N'Test', N'', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 0, CAST(N'2020-06-10T19:10:44.007' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (40, N'Testings', N'test', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 1, CAST(N'2020-06-10T20:01:59.750' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (41, N'Testing1', N'12', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 1, CAST(N'2020-06-10T20:03:17.460' AS DateTime), N'ilaya', NULL, NULL)
GO
INSERT [dbo].[tbl_PPTUPLOAD] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (42, N'DemoVideo', N'VIdeo1', N'C:\inetpub\wwwroot\RpaSaleDev\', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'566.6554445', 1, CAST(N'2020-06-20T23:49:16.573' AS DateTime), N'ilaya', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_PPTUPLOAD] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_VideoMedia] ON 
GO
INSERT [dbo].[tbl_VideoMedia] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Usertype]) VALUES (1061, N'RPA', N'RPA', N'D:\Kaisokku\Kaisokku\Kaisokku_', NULL, N'B', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'192.168.1.6', 1, CAST(N'2022-02-23T19:09:29.830' AS DateTime), N'ilaya', NULL, NULL, 0)
GO
INSERT [dbo].[tbl_VideoMedia] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Usertype]) VALUES (1062, N'RPA', N'RPA', N'D:\Kaisokku\Kaisokku\Kaisokku_', NULL, N'B', 2, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'192.168.1.6', 1, CAST(N'2022-02-23T19:09:42.513' AS DateTime), N'ilaya', NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_VideoMedia] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON 
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (5, N'100', N'ilaya', N'ilaya', 2, NULL, N'ip', 1, CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', CAST(N'2018-10-04T14:23:11.227' AS DateTime), N'ilaya', N'guhanelaya@gmail.com', 0, NULL)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (36, N'103', N'karouji', N'123', 1, NULL, N'test', 1, CAST(N'2020-05-27T11:40:40.297' AS DateTime), N'ilaya', CAST(N'2021-11-01T12:56:52.723' AS DateTime), N'', N'karouji.fumihiko@gssltd.co.jp', 2, 0)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (38, N'105', N'QA', N'QA', 1, NULL, N'test', 1, CAST(N'2020-06-05T14:33:35.293' AS DateTime), N'ilaya', CAST(N'2021-10-04T16:52:39.680' AS DateTime), N'ilaya', N'qaengineer@gmail.com', 2, 0)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (40, N'107', N'demovideo', N'test123', 1, NULL, N'test', 0, CAST(N'2020-06-10T01:02:55.213' AS DateTime), N'ilaya', NULL, NULL, N'prabu6694@gmail.com', 1, 0)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (46, N'109', N'admin', N'admin', 1, NULL, N'test', 1, CAST(N'2020-06-20T23:11:33.630' AS DateTime), N'ilaya', NULL, NULL, N'admin@gmail.com', 1, 0)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (48, N'110', N'tony', N'tonyjha', 1, NULL, N'test', 1, CAST(N'2020-06-23T16:24:17.610' AS DateTime), N'ilaya', NULL, NULL, N'tony@gmail.com', 2, 1)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (51, N'112', N'vijay', N'vijay', 1, NULL, N'test', 1, CAST(N'2021-10-04T16:03:31.287' AS DateTime), N'ilaya', CAST(N'2021-10-04T16:05:52.590' AS DateTime), N'ilaya', N'vijayakumar.ra30@gmail.com', 1, 0)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (52, N'113', N'dasd', N'asdasd', 1, NULL, N'test', 0, CAST(N'2021-10-04T16:53:36.743' AS DateTime), N'ilaya', CAST(N'2021-10-05T18:13:33.837' AS DateTime), N'ilaya', N'sdddsa', 1, 0)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (53, N'114', N'xzczc', N'zxczx', 1, NULL, N'test', 1, CAST(N'2021-10-25T12:51:17.300' AS DateTime), N'karouji', NULL, NULL, N'zxczx@gmail.com', 1, 1)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (1005, N'115', N'sadad', N'asda', 1, NULL, N'test', 1, CAST(N'2021-10-27T10:09:25.490' AS DateTime), N'karouji', NULL, NULL, N'sadads', 1, 1)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (1006, N'115', N'sdad', N'asda', 1, NULL, N'test', 1, CAST(N'2021-10-27T10:11:06.247' AS DateTime), N'karouji', NULL, NULL, N'asda', 1, 1)
GO
INSERT [dbo].[UserMaster] ([UserMasterId], [UserId], [UserName], [password], [RoleId], [Lang], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby], [Email], [CustomerType], [IsClient]) VALUES (1011, N'115', N'Ramsanthosh', N'12121', 1, NULL, N'test', 1, CAST(N'2021-11-01T12:49:08.373' AS DateTime), N'', NULL, NULL, N'r@gmail.com', 2, 0)
GO
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Video_view_log] ON 
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'Admin', N'172.168.1.1', N'Admin', N'172.168.1.1', N'Prbu', 1, N'1', N'172.168.43.72', 1, CAST(N'2020-05-04T00:00:00.000' AS DateTime), N'Admin', CAST(N'2020-05-04T00:00:00.000' AS DateTime), N'Admin')
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (5, N'Admin', N'172.168.1.1', N'Admin', N'172.168.1.1', N'Prabu', 1, N'1', N'172.168.1.1', 1, CAST(N'2020-05-11T00:00:00.000' AS DateTime), N'Admin', CAST(N'2020-05-11T00:00:00.000' AS DateTime), N'Admin')
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (6, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T09:50:55.247' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (7, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T10:04:46.280' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (8, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T10:04:58.560' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (9, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T10:05:05.227' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (10, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T10:07:02.047' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (11, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T10:07:20.577' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (12, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T10:15:35.927' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (13, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T10:19:41.310' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (14, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T16:07:44.543' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (15, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-15T16:11:00.123' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (16, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-18T13:46:56.540' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (17, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-18T13:47:15.620' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (18, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-18T14:51:43.930' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (19, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-18T15:27:14.353' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (20, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-19T12:14:52.073' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (21, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-19T12:38:07.087' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (22, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-19T12:39:05.417' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (23, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-19T15:45:56.400' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (24, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-19T16:06:29.057' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (25, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-19T16:32:52.493' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (26, N'Raja', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-19T22:48:16.167' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (27, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-20T14:19:18.837' AS DateTime), N'Admin', NULL, NULL)
GO
INSERT [dbo].[Video_view_log] ([MediaID], [Username], [ClientIPAddress], [UserAgent], [StoreIPAddress], [StoreName], [StoreId], [ClientSubnetId], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (28, N'ilaya', NULL, NULL, NULL, NULL, NULL, NULL, N'172.168.72.57', 1, CAST(N'2020-05-20T14:30:29.180' AS DateTime), N'Admin', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Video_view_log] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoComments] ON 
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (5, 31, N'gud.mp4', N'very gud scenes', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-22T13:37:37.760' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'image_2020_04_24T10_28_39_022Z.png', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (6, 34, N'Nature.mp4', N'Worst Video', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-22T16:17:19.430' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (7, 35, N'SampleVideo.mp4', N'WorstVideo', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-22T16:25:50.760' AS DateTime), 0, NULL, N'100', N'ilaya', NULL, N'facebook.png', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (8, 36, N'v.mp4', N'super natural', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-22T20:49:22.353' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'2.png', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (9, 36, N'v.mp4', N'nice picture', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-22T21:25:04.743' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'image_2020_04_24T10_29_12_697Z.png', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (10, 36, N'v.mp4', N'worst film', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-24T15:18:46.483' AS DateTime), 0, NULL, N'100', N'ilaya', NULL, N'image_2020_04_24T10_28_39_022Z.png', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (11, 38, N'Nature.mp4', N'Worst Video', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-24T17:11:21.483' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'vh.png', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (12, 38, N'SampleVideo.mp4', N'Super Video', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-24T17:16:58.890' AS DateTime), 0, NULL, N'', N'', NULL, N'vb.netCurrentDateTime.jpg', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (13, 38, N'Nature.mp4', N'Demo', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-24T17:28:36.530' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'allvideos.png.PNG', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (14, 39, N'video2.mp4', N'Demo', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-24T17:34:45.000' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'01-01-2020-Tasks Status.xlsx', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (15, 39, N'video2.mp4', N'no', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-05-24T18:14:28.233' AS DateTime), 0, NULL, N'100', N'ilaya', NULL, N'maker-faire-social-media-logo-instagram-instagram-thumbnail.jpg', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (16, 47, N'GGG.mp4', N'GoodVideo', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-03T18:42:54.437' AS DateTime), 1, NULL, N'101', N'demovideo', NULL, N'image_2020_04_02T03_50_59_074Z.png', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (17, 47, N'GGG.mp4', N'Good', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-05T19:07:43.187' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (18, 47, N'GGG.mp4', N'Nice', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-05T19:13:37.403' AS DateTime), 0, NULL, N'100', N'ilaya', NULL, N'', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (19, 48, N'threee.mp4', N'Nice', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-10T16:06:38.620' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (20, 52, N'videoplayback.mp4', N'Good', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-10T19:55:12.683' AS DateTime), 1, NULL, N'100', N'ilaya', NULL, N'dc.jpg', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (21, 48, N'threee.mp4', N'Super', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-10T20:00:01.777' AS DateTime), 1, NULL, N'105', N'testings', NULL, N'dc.jpg', 0)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (22, 52, N'videoplayback.mp4', N'', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-19T19:09:19.930' AS DateTime), 0, NULL, N'105', N'testings', NULL, N'', 1)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (23, 52, N'videoplayback.mp4', N'test', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-19T19:11:08.527' AS DateTime), 0, NULL, N'105', N'testings', NULL, N'News page.png', 0)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (24, 52, N'videoplayback.mp4', N'test', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-19T19:11:29.447' AS DateTime), 1, NULL, N'105', N'testings', NULL, N'News page.png', 0)
GO
INSERT [dbo].[VideoComments] ([Sno], [VideoId], [VideoName], [VideoComments], [FilePath], [VisitedDate], [IsApproved], [ApprovedBy], [UserId], [VisitorName], [IPAddress], [FileName], [IsDeleted]) VALUES (25, 52, N'videoplayback.mp4', N'Nice Video', N'C:\inetpub\wwwroot\RpaSaleDev\VideoComments\', CAST(N'2020-06-21T00:37:24.787' AS DateTime), 0, NULL, N'100', N'ilaya', NULL, N'NR_RPA-for-NR_Insight_12-18_pic-x675.jpg', 0)
GO
SET IDENTITY_INSERT [dbo].[VideoComments] OFF
GO
INSERT [dbo].[videofiles] ([mediaid], [filename]) VALUES (1061, N'1061.mp4')
GO
INSERT [dbo].[videofiles] ([mediaid], [filename]) VALUES (1062, N'1062.mp4')
GO
SET IDENTITY_INSERT [dbo].[VideoFolder] ON 
GO
INSERT [dbo].[VideoFolder] ([FolderID], [ParentID], [FolderName], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (2, 1, N'Demo', N'ip', 1, CAST(N'2020-04-22T00:00:00.000' AS DateTime), N'ilaya', CAST(N'2020-04-22T00:00:00.000' AS DateTime), N'ilaya')
GO
SET IDENTITY_INSERT [dbo].[VideoFolder] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoMedia] ON 
GO
INSERT [dbo].[VideoMedia] ([MediaID], [Title], [Description], [Filename], [Thumbnail], [FolderID], [UploadType], [ViewCount], [PhysicalIsActive], [PhysicalIsActivecreatedby], [PhysicalIsActivecreatedDate], [PhysicalIsActiveIPAddress], [FileSize], [Registerer], [Accepter], [ApprovalStatus], [Duration], [IpAddress], [IsActive], [createddate], [createdby], [updateddate], [updatedby]) VALUES (1, N'Demo', N'SampleVideo', N'Test.mp4', N'', 2, N'1', 25, 1, N'ip', CAST(N'2020-04-28T00:00:00.000' AS DateTime), N'ip', 800, N'yes', N'yes', 1, 10, N'172.168.48.72', 1, CAST(N'2020-04-28T00:00:00.000' AS DateTime), N'ilay', CAST(N'2020-04-28T00:00:00.000' AS DateTime), N'ilaya')
GO
SET IDENTITY_INSERT [dbo].[VideoMedia] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PPTFolde__856BE6EB8E78391B]    Script Date: 2022/04/13 11.35.34 AM ******/
ALTER TABLE [dbo].[PPTFolder] ADD UNIQUE NONCLUSTERED 
(
	[FolderName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PPTFolde__856BE6EB918D5AC2]    Script Date: 2022/04/13 11.35.34 AM ******/
ALTER TABLE [dbo].[PPTFolder] ADD UNIQUE NONCLUSTERED 
(
	[FolderName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VideoFol__856BE6EB6A70A3AF]    Script Date: 2022/04/13 11.35.34 AM ******/
ALTER TABLE [dbo].[VideoFolder] ADD UNIQUE NONCLUSTERED 
(
	[FolderName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VideoFol__856BE6EB88BB0B53]    Script Date: 2022/04/13 11.35.34 AM ******/
ALTER TABLE [dbo].[VideoFolder] ADD UNIQUE NONCLUSTERED 
(
	[FolderName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PPTMedia] ADD  DEFAULT ((0)) FOR [FolderID]
GO
ALTER TABLE [dbo].[PPTMedia] ADD  DEFAULT ('B') FOR [UploadType]
GO
ALTER TABLE [dbo].[PPTMedia] ADD  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[PPTMedia] ADD  DEFAULT ((0)) FOR [PhysicalIsActive]
GO
ALTER TABLE [dbo].[tbl_Document] ADD  DEFAULT ('B') FOR [UploadType]
GO
ALTER TABLE [dbo].[tbl_Document] ADD  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[tbl_Document] ADD  DEFAULT ((0)) FOR [PhysicalIsActive]
GO
ALTER TABLE [dbo].[tbl_PPTUPLOAD] ADD  DEFAULT ('B') FOR [UploadType]
GO
ALTER TABLE [dbo].[tbl_PPTUPLOAD] ADD  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[tbl_PPTUPLOAD] ADD  DEFAULT ((0)) FOR [PhysicalIsActive]
GO
ALTER TABLE [dbo].[tbl_VideoMedia] ADD  DEFAULT ('B') FOR [UploadType]
GO
ALTER TABLE [dbo].[tbl_VideoMedia] ADD  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[tbl_VideoMedia] ADD  DEFAULT ((0)) FOR [PhysicalIsActive]
GO
ALTER TABLE [dbo].[VideoMedia] ADD  DEFAULT ((0)) FOR [FolderID]
GO
ALTER TABLE [dbo].[VideoMedia] ADD  DEFAULT ('B') FOR [UploadType]
GO
ALTER TABLE [dbo].[VideoMedia] ADD  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[VideoMedia] ADD  DEFAULT ((0)) FOR [PhysicalIsActive]
GO
ALTER TABLE [dbo].[HitCounter]  WITH CHECK ADD  CONSTRAINT [FK_HitCounter_Video_view_log] FOREIGN KEY([HitCounterId])
REFERENCES [dbo].[Video_view_log] ([MediaID])
GO
ALTER TABLE [dbo].[HitCounter] CHECK CONSTRAINT [FK_HitCounter_Video_view_log]
GO
ALTER TABLE [dbo].[PageManagement]  WITH CHECK ADD  CONSTRAINT [FK_PageManagement_PageManagementFolder] FOREIGN KEY([FolderID])
REFERENCES [dbo].[PageManagementFolder] ([folderId])
GO
ALTER TABLE [dbo].[PageManagement] CHECK CONSTRAINT [FK_PageManagement_PageManagementFolder]
GO
ALTER TABLE [dbo].[PPTMedia]  WITH CHECK ADD  CONSTRAINT [FK_tblPPTMedia_tblPPTFolder] FOREIGN KEY([FolderID])
REFERENCES [dbo].[PPTFolder] ([FolderID])
GO
ALTER TABLE [dbo].[PPTMedia] CHECK CONSTRAINT [FK_tblPPTMedia_tblPPTFolder]
GO
ALTER TABLE [dbo].[RoleMenuMapping]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoleMenuMapping_tbl_MenuMaster] FOREIGN KEY([MenuId])
REFERENCES [dbo].[MenuMaster] ([MenuId])
GO
ALTER TABLE [dbo].[RoleMenuMapping] CHECK CONSTRAINT [FK_tbl_RoleMenuMapping_tbl_MenuMaster]
GO
ALTER TABLE [dbo].[RoleMenuMapping]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoleMenuMapping_tbl_RoleMaster] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleMaster] ([RoleId])
GO
ALTER TABLE [dbo].[RoleMenuMapping] CHECK CONSTRAINT [FK_tbl_RoleMenuMapping_tbl_RoleMaster]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserMaster_tbl_RoleMaster] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleMaster] ([RoleId])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_tbl_UserMaster_tbl_RoleMaster]
GO
ALTER TABLE [dbo].[VideoMedia]  WITH CHECK ADD  CONSTRAINT [FK_tblMedia_tblFolder] FOREIGN KEY([FolderID])
REFERENCES [dbo].[VideoFolder] ([FolderID])
GO
ALTER TABLE [dbo].[VideoMedia] CHECK CONSTRAINT [FK_tblMedia_tblFolder]
GO
/****** Object:  StoredProcedure [dbo].[AddDynamicMenu]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================      
-- Author:  Bharathiraja      
-- Create date: 26/04/2020      
-- Description: Add Dynamic Menu When Menumanagement is click      
-- =============================================      
CREATE PROCEDURE [dbo].[AddDynamicMenu]      
@MenuName VARCHAR(50),      
@ControllerName VARCHAR(50),      
@ActionMethod VARCHAR(50),      
@MenuParentId INT,      
@IsActive BIT,      
@RoleId INT,      
@IpAddress VARCHAR(20),      
@createddate DATETIME,      
@createdby VARCHAR(30),      
@updateddate DATETIME,      
@updatedby VARCHAR(30)  
--@Result INT OUTPUT    
AS      
BEGIN      
 DECLARE @LastInsertedRecord INT       
 --DECLARE @LastMenuId INT     
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;      
 BEGIN TRY      
  INSERT INTO MenuMaster      
  (      
  MenuName,      
  ControllerName,      
  ActionMethod,      
  MenuParentId,      
  IsActive,      
  IpAddress,      
  createddate,      
  createdby,      
  updateddate,      
  updatedby      
  )      
      
  VALUES      
  (      
  @MenuName,      
  @ControllerName,      
  @ActionMethod,      
  @MenuParentId,      
  @IsActive,      
  @IpAddress,      
  @createddate,      
  @createdby,      
  @updateddate,      
  @updatedby      
  )      
      
  SET @LastInsertedRecord=SCOPE_IDENTITY()      
      
  INSERT INTO RoleMenuMapping(      
  RoleId,      
  MenuId,      
  IsActive,      
  IpAddress,      
  createddate,      
  createdby,      
  updateddate,      
  updatedby)      
  VALUES      
  (      
  @RoleId,      
  @LastInsertedRecord,      
  @IsActive,      
  @IpAddress,      
  @createddate,      
  @createdby,      
  @updateddate,      
  @updatedby      
  )      
      
  --SET @LastMenuId=(SELECT  TOP 1 MenuId  FROM MenuMaster ORDER BY 1 DESC)      
  --   INSERT INTO [TableMapping](MenuId,TableName)VALUES(@LastMenuId,'[dbo].[PageManagement]')      
      
  --SELECT @Result=1      
    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Added Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
    
 END TRY      
 BEGIN CATCH      
      
  --SELECT @Result=2      
  SET @ErrorCode='2'    
  SET @ErrorMessage='Updation Failed'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH      
       
      
END 
GO
/****** Object:  StoredProcedure [dbo].[AuthenticatedUsers]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AuthenticatedUsers]  
@UserName varchar(100),  
@password varchar(10)  
AS  
BEGIN  
   
 SET NOCOUNT ON;  
 IF EXISTS(select 1 from [UserMaster] WHERE UserName = @UserName AND password=@password)  
 BEGIN  
  SELECT   
  UM.UserId,  
   UM.usermasterID, 
  UM.UserName,  
  UM.RoleId,  
  UM.IsActive,  
    
  RM.Name  AS RoleName  
  
  FROM [UserMaster] UM INNER JOIN [RoleMaster] RM ON  
  UM.RoleId=RM.RoleId WHERE UM.IsActive=1 AND UM.UserName=@UserName  ANd UM.password=@password  
 END  
 ELSE  
 BEGIN  
  SELECT '0','Test',0,CAST(0 AS BIT),'Test'  
 END  
END  
GO
/****** Object:  StoredProcedure [dbo].[CheckEmailExists]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bharathiraja
-- Create date: 27/04/2020
-- Description:	Get Email 
-- =============================================
CREATE PROCEDURE [dbo].[CheckEmailExists] 
@Email varchar(30)
AS
BEGIN
	
	SET NOCOUNT ON;
	--IF EXISTS(select 1 from [UserMaster] WHERE Email = @Email)
	--BEGIN
	--	SELECT 		
	--	password
	--	FROM [tbl_UserMaster]  WHERE Email=@Email
		
	--END
	--ELSE
	--BEGIN
	--	SELECT 'NOEMAIL'
	--END
END
GO
/****** Object:  StoredProcedure [dbo].[Createclient]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Createclient]   
@Description VARCHAR(max),        
@ClientName VARCHAR(50),        
@Website VARCHAR(50),  
@image VARCHAR(50)  
  
AS    
BEGIN        
 DECLARE @ErrorCode VARCHAR(10)        
 DECLARE @ErrorMessage VARCHAR(50)        
 SET NOCOUNT ON;        
 BEGIN TRY       
            
  insert into ClientMGT([Description],ClientName,Website,[image]) values (@Description,@ClientName,@Website,@image)     
      
    SET @ErrorCode='0'        
  SET @ErrorMessage='Created Successfully'        
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage        
 END TRY        
 BEGIN CATCH        
  SET @ErrorCode='1'        
  SET @ErrorMessage='Creation Failure'        
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage        
 END CATCH     
END 
GO
/****** Object:  StoredProcedure [dbo].[CreateContent]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[CreateContent]       
     
@Title VARCHAR(100),            
@Description VARCHAR(4000),      
@Created_by VARCHAR(100),
@Created_date datetime
      
AS        
BEGIN            
 DECLARE @ErrorCode VARCHAR(10)            
 DECLARE @ErrorMessage VARCHAR(50)            
 SET NOCOUNT ON;            
 BEGIN TRY           
                
  insert into contentManagement(Title,[Description],created_by,Created_date) 
  values (@Title,@Description,@Created_by,@Created_date)         
          
    SET @ErrorCode='0'            
  SET @ErrorMessage='Created Successfully'            
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage            
 END TRY            
 BEGIN CATCH            
  SET @ErrorCode='1'            
  SET @ErrorMessage='Creation Failure'            
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage            
 END CATCH         
END 
GO
/****** Object:  StoredProcedure [dbo].[CreateDocDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================    
 Author:  sabeena    
 Create date: 04/05/2020    
 Description: Edit Video Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[CreateDocDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@VideoName VARCHAR(50),    
@updateddate DATETIME,    
@VideoDesc VARCHAR(150),    
@VideoFile VARCHAR(30)    
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  insert into tbl_Document (title,createddate,[description],[filename],ipaddress,isactive,createdby) values (@VideoName,   @updateddate,  @VideoDesc,   @VideoFile ,'111.121.345', 1,'ilaya')    
      
  SET @ErrorCode='0'    
  SET @ErrorMessage='Created Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Creation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[CreateDocFileDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================      
 Author:  sabeena      
 Create date: 04/05/2020      
 Description: add Video Details      
 =============================================*/      
CREATE PROCEDURE [dbo].[CreateDocFileDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'      
@VideoName VARCHAR(50)  ,  
@mediaid int    
AS      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
      
  insert into Documentfiles  values (@mediaid,@VideoName)      
        
  SET @ErrorCode='0'      
  SET @ErrorMessage='Created Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Creation Failure'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END 
GO
/****** Object:  StoredProcedure [dbo].[CreatePPTDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 /*=============================================    
 Author:  sabeena    
 Create date: 04/05/2020    
 Description: Edit PPT Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[CreatePPTDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@VideoName VARCHAR(50),    
@updateddate DATETIME,    
@VideoDesc VARCHAR(150),    
@VideoFile VARCHAR(30)    
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  insert into [tbl_PPTUPLOAD] (title,createddate,[description],[filename],ipaddress,isactive,createdby) values (@VideoName,   @updateddate,  @VideoDesc,   @VideoFile ,'566.6554445', 1,'ilaya')    
      
  SET @ErrorCode='0'    
  SET @ErrorMessage='Created Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Creation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[CreatePPTFileDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================      
 Author:  sabeena      
 Create date: 04/05/2020      
 Description: add Video Details      
 =============================================*/      
CREATE PROCEDURE [dbo].[CreatePPTFileDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'      
@VideoName VARCHAR(50)  ,  
@mediaid int    
AS      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
      
  insert into PPTfiles  values (@mediaid,@VideoName)      
        
  SET @ErrorCode='0'      
  SET @ErrorMessage='Created Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Creation Failure'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END 
GO
/****** Object:  StoredProcedure [dbo].[CreatePrice]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[CreatePrice]     
   
@Productname VARCHAR(100),          
@Validity VARCHAR(100),    
@Price decimal  
    
AS      
BEGIN          
 DECLARE @ErrorCode VARCHAR(10)          
 DECLARE @ErrorMessage VARCHAR(50)          
 SET NOCOUNT ON;          
 BEGIN TRY         
              
  insert into PriceMGT(Product_name,Validity,Price) values (@Productname,@Validity,@Price)       
        
    SET @ErrorCode='0'          
  SET @ErrorMessage='Created Successfully'          
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage          
 END TRY          
 BEGIN CATCH          
  SET @ErrorCode='1'          
  SET @ErrorMessage='Creation Failure'          
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage          
 END CATCH       
END 
GO
/****** Object:  StoredProcedure [dbo].[CreateSocialFileDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateSocialFileDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'      
@Filename  NVARCHAR(50)  ,  
@SocialMediaId int    
AS      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
      
  insert into SocialMediaFiles  values (@SocialMediaId,@Filename)      
        
  SET @ErrorCode='0'      
  SET @ErrorMessage='Created Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Creation Failure'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END 
GO
/****** Object:  StoredProcedure [dbo].[CreateSocialMedia]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateSocialMedia] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@Title VARCHAR(max),    
@Url VARCHAR(50),    
@Filename VARCHAR(max)        
AS
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY   
        
  insert into [SocialMeida] (Title,[Url],[Filename]) values (@Title,   @Url,  @Filename) 
  
    SET @ErrorCode='0'    
  SET @ErrorMessage='Created Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Creation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH 
END 
GO
/****** Object:  StoredProcedure [dbo].[CreateTaskDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================    
 Author:  sabeena    
 Create date: 04/05/2020    
 Description: Create Task Details   
 =============================================*/    
CREATE PROCEDURE [dbo].[CreateTaskDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@TaskName VARCHAR(50),    
@Createddate DATETIME,    
@taskdescription VARCHAR(150),    
@userid int  
AS    
BEGIN    

 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  insert into taskmaster ([TaskName],[TaskDescription],[UserId],isactive,[createddate],ipaddress,createdby) values (@TaskName, @taskdescription,@userid,'1',  @createddate,'67.90.890','ilaya')    
      
  SET @ErrorCode='0'    
  SET @ErrorMessage='Created Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Creation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[CreateVideoDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateVideoDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'        
@VideoName NVARCHAR(400),        
@updateddate DATETIME,        
@VideoDesc NVARCHAR(4000),        
@VideoFile NVARCHAR(30),  
@FileName NVARCHAR(40),  
@Extn NVARCHAR(5),  
@userName NVARCHAR(400),  
@ipAddress varchar(400),
@Usertype NVARCHAR(400) 

AS        
BEGIN        
 DECLARE @ErrorCode NVARCHAR(10)        
 DECLARE @ErrorMessage NVARCHAR(4000)      
 DECLARE @Identity int    
 set @Identity = 0    
 SET NOCOUNT ON;        
 BEGIN TRY        
        
  insert into tbl_VideoMedia (title,createddate,[description],[filename],ipaddress,isactive,createdby,Usertype) values (@VideoName,   @updateddate,  @VideoDesc,   @VideoFile ,@ipAddress, 1,@userName,@Usertype)        
  SELECT @Identity = SCOPE_IDENTITY();     
  SET @ErrorCode='0'       
    
   
  --select @ErrorCode = ERROR_NUMBER()     
  --select @ErrorMessage = ERROR_MESSAGE()    
    
  SET @ErrorMessage='Created Successfully'       
   insert into videofiles values (@Identity,convert(varchar,@Identity)+@Extn)  
  SELECT @Identity AS ScopeIden, @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage        
 END TRY        
 BEGIN CATCH        
  --SET @ErrorCode='1'        
  select @ErrorCode = ERROR_NUMBER()     
  --SET @ErrorMessage='Creation Failure'       
  select @ErrorMessage = ERROR_MESSAGE()    
  SELECT @Identity AS ScopeIden, @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage        
 END CATCH        
END   
GO
/****** Object:  StoredProcedure [dbo].[CreateVideoFileDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
        
 /*=============================================            
 Author:  sabeena            
 Create date: 04/05/2020            
 Description: add Video Details            
 =============================================*/            
CREATE PROCEDURE [dbo].[CreateVideoFileDetails] --'ABC.mp4',31      
@VideoName VARCHAR(50)  ,        
@mediaid int,  
@IsResetCount BIT ,
@IsVideoChanged BIT

AS            
BEGIN            
 DECLARE @ErrorCode VARCHAR(10)            
 DECLARE @ErrorMessage VARCHAR(50)           
 DECLARE @VideoName1 VARCHAR(50)      
 SET NOCOUNT ON;            
 BEGIN TRY            
 IF   @IsVideoChanged=1  
 BEGIN
	insert into videofiles  values (@mediaid,@VideoName)    
 END


  IF @IsResetCount=1  
  BEGIN  
  UPDATE tbl_videomedia SET ViewCount=0 WHERE mediaid= @mediaid    
  END     
  SET @ErrorCode='0'            
  SET @ErrorMessage='Created Successfully'            
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage            
 END TRY            
 BEGIN CATCH            
  SET @ErrorCode='1'            
  SET @ErrorMessage='Creation Failure'            
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage            
 END CATCH            
END 
GO
/****** Object:  StoredProcedure [dbo].[CRMBulkEmail]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Balraj
-- Create date: 02/05/2020
-- Description:	Bulk Email for CRM
-- =============================================
CREATE PROCEDURE [dbo].[CRMBulkEmail]
@CustomerType INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SELECT [Email] FROM [CustomerDetails] WHERE CustomerType=@CustomerType AND IsActive=1
	END TRY
	BEGIN CATCH
	  SELECT '-1'
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteClientDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteClientDetails]      
@Id INT      
AS      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
    delete from ClientMGT        
          
  WHERE id=@Id     
      
  delete from ClientMGT        
          
  WHERE id=@Id      
      
  SET @ErrorCode='0'      
  SET @ErrorMessage='Deleted Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Deleted Fail'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END 
GO
/****** Object:  StoredProcedure [dbo].[DeletecontentManagement]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeletecontentManagement]          
@Id INT          
AS          
BEGIN          
 DECLARE @ErrorCode VARCHAR(10)          
 DECLARE @ErrorMessage VARCHAR(50)          
 SET NOCOUNT ON;          
 BEGIN TRY          
          
          
  delete from contentManagement            
              
  WHERE id=@Id          
          
  SET @ErrorCode='0'          
  SET @ErrorMessage='Deleted Successfully'          
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage          
 END TRY          
 BEGIN CATCH          
  SET @ErrorCode='1'          
  SET @ErrorMessage='Deleted Fail'          
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage          
 END CATCH          
END 
GO
/****** Object:  StoredProcedure [dbo].[DeleteCRMDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCRMDetails]  
@UserCustomId INT  
AS  
BEGIN  
 DECLARE @ErrorCode VARCHAR(10)  
 DECLARE @ErrorMessage VARCHAR(50)  
 SET NOCOUNT ON;  
 BEGIN TRY  
  --DELETE FROM CRMContent  WHERE UserCustomId=@UserCustomId  
     DELETE FROM CRMContents  WHERE UserCustomId=@UserCustomId  
  SET @ErrorCode='0'  
  SET @ErrorMessage='Deleted Successfully'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END TRY  
 BEGIN CATCH  
  SET @ErrorCode='1'  
  SET @ErrorMessage='Deleted Fail'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END CATCH  
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDocDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
 /*=============================================    
 Author:  Sabeena    
 Create date: 04/05/2020    
 Description: Delete Doc Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[DeleteDocDetails]    
@MediaId INT    
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
      
  UPDATE tbl_Document    
  SET     
  ISactive = 0    
      
  WHERE mediaid=@MediaId    
    
  SET @ErrorCode='0'    
  SET @ErrorMessage='Deleted Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Deleted Fail'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END    
GO
/****** Object:  StoredProcedure [dbo].[DeleteMenuDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  Bharathiraja    
-- Create date: 04/05/2020    
-- Description: Delete Menu Details    
-- =============================================    
CREATE PROCEDURE [dbo].[DeleteMenuDetails]    
@MenuId INT    
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
	DELETE FROM RoleMenuMapping  WHERE MenuId=@MenuId    
	DELETE FROM MenuMaster  WHERE MenuId=@MenuId   
  
	IF EXISTS(select 1 from PageManagement WHERE PageMenuId = @MenuId)
	BEGIN
		DELETE FROM PageManagement WHERE PageMenuId=@MenuId  
	END
	
	SET @ErrorCode='0'    
	SET @ErrorMessage='Deleted Successfully'    
	SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
	SET @ErrorCode='1'    
	SET @ErrorMessage='Deleted Fail'    
	SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[DeletePageDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bharathiraja
-- Create date: 04/05/2020
-- Description:	Delete Menu Details
-- =============================================
CREATE PROCEDURE [dbo].[DeletePageDetails]
@PageId INT,
@PageMenuId INT

AS
BEGIN
	DECLARE @ErrorCode VARCHAR(10)
	DECLARE @ErrorMessage VARCHAR(50)
	SET NOCOUNT ON;
	BEGIN TRY
		DELETE FROM PageManagement  WHERE pageId=@PageId
		DELETE FROM TableMapping   WHERE MenuId=@PageMenuId
		
		SET @ErrorCode='0'
		SET @ErrorMessage='Deleted Successfully'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage
	END TRY
	BEGIN CATCH
		SET @ErrorCode='1'
		SET @ErrorMessage='Deleted Fail'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePPTDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=============================================  
 Author:  Sabeena  
 Create date: 04/05/2020  
 Description: Delete Menu Details  
 =============================================*/  
CREATE PROCEDURE [dbo].[DeletePPTDetails]  
@MediaId INT  
AS  
BEGIN  
 DECLARE @ErrorCode VARCHAR(10)  
 DECLARE @ErrorMessage VARCHAR(50)  
 SET NOCOUNT ON;  
 BEGIN TRY  
    
  UPDATE [tbl_PPTUPLOAD]  
  SET   
  ISactive = 0  
    
  WHERE mediaid=@MediaId  
  
  SET @ErrorCode='0'  
  SET @ErrorMessage='Deleted Successfully'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END TRY  
 BEGIN CATCH  
  SET @ErrorCode='1'  
  SET @ErrorMessage='Deleted Fail'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END CATCH  
END  
GO
/****** Object:  StoredProcedure [dbo].[DeletePriceDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeletePriceDetails]        
@Id INT        
AS        
BEGIN        
 DECLARE @ErrorCode VARCHAR(10)        
 DECLARE @ErrorMessage VARCHAR(50)        
 SET NOCOUNT ON;        
 BEGIN TRY        
    delete from ClientMGT          
            
  WHERE id=@Id       
        
  delete from PriceMGT          
            
  WHERE id=@Id        
        
  SET @ErrorCode='0'        
  SET @ErrorMessage='Deleted Successfully'        
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage        
 END TRY        
 BEGIN CATCH        
  SET @ErrorCode='1'        
  SET @ErrorMessage='Deleted Fail'        
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage        
 END CATCH        
END  
GO
/****** Object:  StoredProcedure [dbo].[DeleteSocialMediaDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSocialMediaDetails]  
@SocialMediaID INT  
AS  
BEGIN  
 DECLARE @ErrorCode VARCHAR(10)  
 DECLARE @ErrorMessage VARCHAR(50)  
 SET NOCOUNT ON;  
 BEGIN TRY  
    delete from SocialMediaFiles    
      
  WHERE SocialMediaiD=@SocialMediaID 
  
  delete from [SocialMeida]    
      
  WHERE SocialMediaID=@SocialMediaID  
  
  SET @ErrorCode='0'  
  SET @ErrorMessage='Deleted Successfully'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END TRY  
 BEGIN CATCH  
  SET @ErrorCode='1'  
  SET @ErrorMessage='Deleted Fail'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END CATCH  
END  
GO
/****** Object:  StoredProcedure [dbo].[DeleteTaskDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================  
 Author:  Sabeena  
 Create date: 04/05/2020  
 Description: Delete Task Details
 =============================================*/  
CREATE PROCEDURE [dbo].[DeleteTaskDetails]  
@TaskId INT  
AS  
BEGIN  
 DECLARE @ErrorCode VARCHAR(10)  
 DECLARE @ErrorMessage VARCHAR(50)  
 SET NOCOUNT ON;  
 BEGIN TRY  
    
  UPDATE taskmaster  
  SET   
  ISactive = 0  
    
  WHERE [TaskMasterId]=@TaskId
  
  SET @ErrorCode='0'  
  SET @ErrorMessage='Deleted Successfully'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END TRY  
 BEGIN CATCH  
  SET @ErrorCode='1'  
  SET @ErrorMessage='Deleted Fail'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END CATCH  
END  
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bharathiraja
-- Create date: 11/05/2020
-- Description:	Delete User Details
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUserDetails]
@UserMasterId INT
AS
BEGIN
	DECLARE @ErrorCode VARCHAR(10)
	DECLARE @ErrorMessage VARCHAR(50)
	SET NOCOUNT ON;
	BEGIN TRY
		DELETE FROM UserMaster  WHERE UserMasterId=@UserMasterId
		
		SET @ErrorCode='0'
		SET @ErrorMessage='Deleted Successfully'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage
	END TRY
	BEGIN CATCH
		SET @ErrorCode='1'
		SET @ErrorMessage='Deleted Fail'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteVideoDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=============================================    
 Author:  Sabeena    
 Create date: 04/05/2020    
 Description: Delete Video Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[DeleteVideoDetails]    
@MediaId INT    
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  DELETE FROM tbl_VideoMedia WHERE  mediaid=@MediaId    
  DELETE FROM videofiles WHERE  mediaid=@MediaId    
  --UPDATE tbl_VideoMedia    
  --SET     
  --ISactive = 0    
      
  --WHERE mediaid=@MediaId    
    
  SET @ErrorCode='0'    
  SET @ErrorMessage='Deleted Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  --SET @ErrorCode='1'    
  --SET @ErrorMessage='Deleted Fail'    
  select @ErrorCode = ERROR_NUMBER()
  select @ErrorMessage = ERROR_MESSAGE()
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END    
GO
/****** Object:  StoredProcedure [dbo].[EditContentMGT]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditContentMGT] --51,'testmail','2020-05-05 00:36:06.240','sunil'      
@ContentID INT,      
@Title nvarchar(100),      
@Description VARCHAR(4000),
@updated_by nvarchar(100),
@updated_date datetime
  
AS   
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
      
    
   
  UPDATE contentManagement      
  SET   
  [Description]=@Description,
  Title = @Title,        
  updated_by=@updated_by , 
  Updated_date=@updated_date
  WHERE id=@ContentID      
  
  
 
  SET @ErrorCode='0'      
  SET @ErrorMessage='Updated Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Updation Failure'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END   
GO
/****** Object:  StoredProcedure [dbo].[EditDocDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================    
 Author:  sabeena    
 Create date: 04/05/2020    
 Description: Edit Video Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[EditDocDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@VideoId INT,    
@VideoName VARCHAR(50),    
@updateddate DATETIME,    
@VideoDesc VARCHAR(150)  
   
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  delete from Documentfiles where mediaid = @VideoId    
  
  UPDATE tbl_Document    
  SET     
  title = @VideoName,     
  updateddate = @updateddate,    
  [description]=@VideoDesc  
  WHERE mediaid=@VideoId    
      
  SET @ErrorCode='0'    
  SET @ErrorMessage='Updated Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Updation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[EditMenuDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  Bharathiraja    
-- Create date: 04/05/2020    
-- Description: Edit Menu Details    
-- =============================================    
CREATE PROCEDURE [dbo].[EditMenuDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@MenuId INT,    
@MenuName VARCHAR(50),    
@updateddate DATETIME,    
@updatedby VARCHAR(30)    
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  UPDATE RoleMenuMapping    
  SET     
  updateddate = @updateddate,     
  updatedby = @updatedby    
  WHERE MenuId=@MenuId    
    
  UPDATE MenuMaster    
  SET     
  MenuName = @MenuName,     
  updateddate = @updateddate,     
  updatedby = @updatedby    
  WHERE MenuId=@MenuId    
    
  
  IF EXISTS(select 1 from PageManagement WHERE PageMenuId = @MenuId)
	BEGIN
		UPDATE PageManagement    
		SET     
		pagefilename = @MenuName     
		WHERE PageMenuId=@MenuId  
	END
  SET @ErrorCode='0'    
  SET @ErrorMessage='Updated Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Updation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[EditPage]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bharathiraja
-- Create date: 09/05/2020
-- Description:	Edit page management details
-- =============================================
CREATE PROCEDURE [dbo].[EditPage]
@IsActive BIT,
@UserId VARCHAR(20),
@UpdatedBy VARCHAR(30),
@pagecontent NVARCHAR(MAX),
@pagedescription NVARCHAR(1000),
@PageId INT
AS
BEGIN
	DECLARE @ErrorCode VARCHAR(10)
	DECLARE @ErrorMessage VARCHAR(50)
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE PageManagement
		SET 
		IsActive = @IsActive, 
		UserId = @UserId,
		UpdatedBy = @UpdatedBy,
		pagecontent = @pagecontent,
		pagedescription = @pagedescription,
		UpdatedDate=GETDATE()
		WHERE UserId=@UserId AND pageId=@PageId


		SET @ErrorCode='0'
		SET @ErrorMessage='Updated Successfully'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage

	END TRY
	BEGIN CATCH

		SET @ErrorCode='1'
		SET @ErrorMessage='Updation Failed'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage

	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[EditPPTDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================    
 Author:  sabeena    
 Create date: 04/05/2020    
 Description: Edit Video Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[EditPPTDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@VideoId INT,    
@VideoName VARCHAR(50),    
@updateddate DATETIME,    
@VideoDesc VARCHAR(150)  
   
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  delete from PPTfiles where mediaid = @VideoId    
  
  UPDATE [tbl_PPTUPLOAD]    
  SET     
  title = @VideoName,     
  updateddate = @updateddate,    
  [description]=@VideoDesc  
  WHERE mediaid=@VideoId    
      
  SET @ErrorCode='0'    
  SET @ErrorMessage='Updated Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Updation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[EditSocialMediaImages]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditSocialMediaImages] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@SocialMediaID INT,    
@Title nvarchar(MAX),    
@URL VARCHAR(50),    
@Filename nvarchar(MAX) 
   
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
    
  
 
  UPDATE [SocialMeida]    
  SET     
  Title = @Title,      
  [URL]=@URL
  WHERE SocialMediaID=@SocialMediaID    


 UPDATE SocialMediaFiles    
  SET     
  [Filename] =@Filename
  WHERE SocialMediaID=@SocialMediaID    
      
  SET @ErrorCode='0'    
  SET @ErrorMessage='Updated Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Updation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[EditTaskDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 /*=============================================    
 Author:  sabeena    
 Create date: 04/05/2020    
 Description: Edit Task Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[EditTaskDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@taskId INT,    
@taskName VARCHAR(50),    
@updateddate DATETIME,    
@taskDesc VARCHAR(150) ,
@userid VARCHAR(50)
   
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
      
  UPDATE taskmaster    
  SET     
  [TaskName] = @taskName,     
  updateddate = @updateddate,    
  [TaskDescription]=@taskDesc  ,
  userid = @userid
  WHERE [TaskMasterId]=@taskId    
      
  SET @ErrorCode='0'    
  SET @ErrorMessage='Updated Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Updation Failure'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[EditVideoDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=============================================    
 Author:  sabeena    
 Create date: 04/05/2020    
 Description: Edit Video Details    
 =============================================*/    
CREATE PROCEDURE [dbo].[EditVideoDetails] --51,'testmail','2020-05-05 00:36:06.240','sunil'    
@VideoId INT,  
@VideoTitle NVARCHAR(400), 
@VideoDesc NVARCHAR(4000),
@isNewVideo int,      
@path NVARCHAR(400),
@ext NVARCHAR(5),
@ExistingVideoName NVARCHAR(400),
@userName NVARCHAR(400),
@ipAddress varchar(400)
AS      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
  IF   @isNewVideo=1  
  BEGIN  
		  update videofiles 
		  set filename = convert(varchar,@VideoId)+@ext 
		  where mediaid = @VideoId      
  
		  update tbl_VideoMedia set  Title = @VideoTitle,
		  Description = @VideoDesc,
		  Filename = @path,
		  ViewCount = 0,
		  IpAddress = @ipAddress,
		  updatedby =@userName,
		  updateddate = getdate()
		  where mediaid = @VideoId
  END  
  ELSE
  BEGIN
		update tbl_VideoMedia set  Title = @VideoTitle,
		  Description = @VideoDesc,
		  Filename = @path,
		  IpAddress = @ipAddress,
		  updatedby =@userName,
		  updateddate = getdate()
		  where mediaid = @VideoId
  END
    
       
  SET @ErrorCode='0'      
  SET @ErrorMessage='Updated Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  --SET @ErrorCode='1'      
  --SET @ErrorMessage='Updation Failure' 
  select @ErrorCode = ERROR_NUMBER()
  select @ErrorMessage = ERROR_MESSAGE() 
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END  
GO
/****** Object:  StoredProcedure [dbo].[Enquiryinsert]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Enquiryinsert] (
@Name varchar(50),
@Email Varchar (50),
@Phone varchar (50),
@comments Varchar (100))


AS 
Begin
insert into enquiryform(Name,Email,phoneno,comments) values ( @Name, @Email, @Phone, @comments)

End
GO
/****** Object:  StoredProcedure [dbo].[GetClint]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE procedure [dbo].[GetClint]  
   as     
begin    
select ID,ClientName,Website,Description from ClientMGT  
   End 
GO
/****** Object:  StoredProcedure [dbo].[Getprice]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE procedure [dbo].[Getprice]    
   as       
begin      
select* from PriceMGT    
   End 
GO
/****** Object:  StoredProcedure [dbo].[GetSocialMedia]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetSocialMedia]  
as begin


--select * From [SocialMeida] F  inner join SocialMediaFiles   
--   M on F.SocialMediaID = M.SocialMediaId order by F.SocialMediaID asc  

   select F.URL,M.Filename From [SocialMeida] F  inner join SocialMediaFiles   
   M on F.SocialMediaID = M.SocialMediaId order by F.SocialMediaID asc  
   
   
   End
GO
/****** Object:  StoredProcedure [dbo].[GetSocialMediaGrid]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetSocialMediaGrid]
as 
begin
select SM.SocialMediaID, SM.Title, SM.URL, SF.Filename From [SocialMeida] SM  inner join SocialMediaFiles 
	  SF on SM.SocialMediaID = SF.SocialMediaId
	  End
GO
/****** Object:  StoredProcedure [dbo].[InsertActivityReport]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bharathiraja
-- Create date: 11/05/2020
-- Description:	Insert ActivityDetails
-- =============================================
CREATE PROCEDURE [dbo].[InsertActivityReport] 
@UserId  VARCHAR(50),
@UserName VARCHAR(50),
@MenuId int,
@MenuName VARCHAR(50)

AS
BEGIN
	DECLARE @ErrorCode VARCHAR(10)
	DECLARE @ErrorMessage VARCHAR(50)
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO [ActivityReport]
		(
		UserId, 
		UserName,
		MenuId,
		MenuName, 
		VisitedDate 
		
		)
		VALUES
		(
		@UserId,
		@UserName,
		@MenuId,
		@MenuName,
		GETDATE()
		)
		SET @ErrorCode='0'
		SET @ErrorMessage='Added Successfully'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage
	END TRY
	BEGIN CATCH
		SET @ErrorCode='1'
		SET @ErrorMessage='Added Fail'
		SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCrmContent]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  Sabeena    
-- Create date: 11/05/2020    
-- Description: Insert CRM Content Details    
-- =============================================    
CREATE PROCEDURE [dbo].[InsertCrmContent]     
@UserId VARCHAR(20),    
@ContactName VARCHAR(100),    
@CompanyName VARCHAR(250),    
@Active BIT,    
@CreatedBy VARCHAR(30),    
@RoleId INT,  
@Email VARCHAR(50),
@CustomerTYPE INT
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
  INSERT INTO CrmContents    
  (    
  UserId,     
  ContactName,    
  CompanyName ,    
  IsActive,     
  CreatedBy ,    
  IpAddress,    
  RoleId ,    
  CreatedDate ,  
  Email,
  CustomerType
  )    
  VALUES    
  (    
  @UserId,     
  @ContactName,    
  @CompanyName ,    
  @Active,     
  @CreatedBy ,    
  'test',    
  @RoleId,    
  GETDATE(),  
  @Email,
  @CustomerType
  )    
  SET @ErrorCode='0'    
  SET @ErrorMessage='Added Successfully'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END TRY    
 BEGIN CATCH    
  SET @ErrorCode='1'    
  SET @ErrorMessage='Added Fail'    
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
 END CATCH    
END 

GO
/****** Object:  StoredProcedure [dbo].[InsertForm]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertForm]  
@Name VARCHAR(50),  
@Email VARCHAR(50),  
@phoneno INT,  
@comments VARCHAR(100) 
--@pagedescription NVARCHAR(1000),  
--@PageId INT  
AS  
BEGIN  
 DECLARE @ErrorCode VARCHAR(10)  
 DECLARE @ErrorMessage VARCHAR(50)  
 SET NOCOUNT ON;  
 BEGIN TRY  
  insert into  enquiryform (Name,Email,phoneno,comments) values(@Name,@Email,@phoneno,@comments)  
  SET @ErrorCode='0'  
  SET @ErrorMessage='Inserted Successfully'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
  
 END TRY  
 BEGIN CATCH  
  
  SET @ErrorCode='1'  
  SET @ErrorMessage='Insertion Failed'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
  
 END CATCH  
END  
GO
/****** Object:  StoredProcedure [dbo].[InsertPage]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Bharathiraja  
-- Create date: 08/05/2020  
-- Description: Insert page management details  
-- =============================================  
CREATE PROCEDURE [dbo].[InsertPage] --'bestbest','dfdd','fdf','sdsd','true','1001','yes'  
@pagefilename VARCHAR(50),  
@pagedescription NVARCHAR(1000),  
@pagecontent NVARCHAR(MAX),  
@createdby VARCHAR(30),  
@IsActive bit,  
@UserId VARCHAR(20),  
@AdminRights VARCHAR(10),  
@IpAddress VARCHAR(10), 
@PageMenuId INT
AS  
BEGIN  
 DECLARE @ErrorCode VARCHAR(10)  
 DECLARE @ErrorMessage VARCHAR(50)  
 DECLARE @LastMenuId INT   
 SET NOCOUNT ON;  
 BEGIN TRY  
  INSERT INTO PageManagement  
  (  
  pagefilename,  
  pagedescription,  
  mediafiletype,  
  pagecontent,  
  mediafolder,  
  FolderID,  
  IsActive,  
  createddate,  
  createdby,  
  UserId,  
  AdminRights,  
  IpAddress,  
  PageMenuId
  )  
  VALUES  
  (  
    
  @pagefilename,  
  @pagedescription,  
  'MIX',  
  @pagecontent,  
  'PM' ,  
  1,  
  @IsActive,  
  GETDATE(),  
  @createdby,  
  @UserId,  
  @AdminRights,  
  @IpAddress,
  @PageMenuId
  ) 
  
   SET @LastMenuId=(SELECT  TOP 1 MenuId  FROM MenuMaster ORDER BY 1 DESC)      
     INSERT INTO [TableMapping](MenuId,TableName)VALUES(@LastMenuId,'[dbo].[PageManagement]')    


  SET @ErrorCode='0'  
  SET @ErrorMessage='Added Successfully'  
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END TRY  
 BEGIN CATCH  
  SET @ErrorCode='1'  
  --SET @ErrorMessage='Added Fail'  
  SET @ErrorMessage=ERROR_MESSAGE()
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage  
 END CATCH  
END  
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================      
-- Author:  Bharathiraja      
-- Create date: 11/05/2020      
-- Description: Insert User Details      
-- =============================================      
CREATE PROCEDURE [dbo].[InsertUser]       
@UserId VARCHAR(20),      
@UserName VARCHAR(100),      
@Password VARCHAR(10),      
@Active BIT,      
@CreatedBy VARCHAR(30),      
@RoleId INT ,    
@Email VARCHAR(50),  
@CustomerTYPE INT,
@IsClient BIT
AS      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
  INSERT INTO UserMaster      
  (      
  UserId,       
  UserName,      
  [Password] ,      
  IsActive,       
  CreatedBy ,      
  IpAddress,      
  RoleId ,      
  CreatedDate ,    
  Email,  
  CustomerType,
  IsClient
  )      
  VALUES      
  (      
  @UserId,       
  @UserName,      
  @Password ,      
  @Active,       
  @CreatedBy ,      
  'test',      
  @RoleId,      
  GETDATE(),    
  @Email,  
  @CustomerTYPE,
  @IsClient
  )      
  SET @ErrorCode='0'      
  SET @ErrorMessage='Added Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Added Fail'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END 
GO
/****** Object:  StoredProcedure [dbo].[InsertVideoComments]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================    
 Author:  Bharathiraja    
 Create date: 2020/05/19   
 Description: Insert Video Comments    
 =============================================*/    
CREATE PROCEDURE [dbo].[InsertVideoComments] --5,'video2.mp4','GGGGGGGG','filepath',false,'userid','username'
@VideoId INT,    
@VideoName NVARCHAR(100),    
@VideoComments NVARCHAR(MAX),    
@FilePath VARCHAR(300),

@IsApproved BIT,
@UserId VARCHAR(50),
@VisitorName VARCHAR(50),
@FileName NVARCHAR(200),
@IsDeleted BIT
AS    
BEGIN    
 DECLARE @ErrorCode VARCHAR(10)    
 DECLARE @ErrorMessage VARCHAR(50)    
 SET NOCOUNT ON;    
 BEGIN TRY    
 INSERT INTO [VideoComments] 
 (
 VideoId,
 VideoName,
 VideoComments,
 FilePath,
 VisitedDate,
 IsApproved,
 UserId,
 VisitorName,
 FileName,
 IsDeleted
 )
 VALUES
 (
 @VideoId,
 @VideoName,
 @VideoComments,
 @FilePath,
 GETDATE(),
 @IsApproved,
 @UserId,
 @VisitorName,
 @FileName,
 @IsDeleted
 )   

      
SET @ErrorCode='0'    
SET @ErrorMessage='Insert Successfully'    
SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
END TRY    
BEGIN CATCH    
SET @ErrorCode='1'    
SET @ErrorMessage=ERROR_MESSAGE()


SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[SaveEditCRMDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveEditCRMDetails]       
@UserCustomId INT,      
@ContactName VARCHAR(100),      
@CompanyName VARCHAR(250),         
@Email VARCHAR(50)  
  
AS      
      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
      
  UPDATE [CRMContents]      
  SET       
  ContactName  = @ContactName,       
  CompanyName = @CompanyName,             
  Updateddate=GETDATE(),    
  Email=@Email  
    
  WHERE UserCustomId=@UserCustomId      
      
       
  SET @ErrorCode='0'      
  SET @ErrorMessage='Updated Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Updation Failure'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END   
  
  
GO
/****** Object:  StoredProcedure [dbo].[SaveEditUserDetails]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROCEDURE [dbo].[SaveEditUserDetails]       
@UserMasterId INT,      
@UserName VARCHAR(100),      
@Password VARCHAR(10),      
@IsActive BIT,      
@Updatedby VARCHAR(30),    
@Email VARCHAR(50),  
@CustomerType INT,
@IsClient BIT
AS      
      
BEGIN      
 DECLARE @ErrorCode VARCHAR(10)      
 DECLARE @ErrorMessage VARCHAR(50)      
 SET NOCOUNT ON;      
 BEGIN TRY      
      
  UPDATE [UserMaster]      
  SET       
  UserName  = @UserName,       
  [Password] = @Password,      
  IsActive= @IsActive,      
  Updatedby= @Updatedby,      
  Updateddate=GETDATE() ,    
  Email=@Email,  
  CustomerType=@CustomerType,
  IsClient=@IsClient
  WHERE UserMasterId=@UserMasterId      
      
       
  SET @ErrorCode='0'      
  SET @ErrorMessage='Updated Successfully'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END TRY      
 BEGIN CATCH      
  SET @ErrorCode='1'      
  SET @ErrorMessage='Updation Failure'      
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage      
 END CATCH      
END 
GO
/****** Object:  StoredProcedure [dbo].[SearchAllTables]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
      
CREATE PROC [dbo].[SearchAllTables] --'il'      
(      
@SearchStr nvarchar(100)      
)      
      
AS      
BEGIN      
      
    CREATE TABLE #Results (TableName nvarchar(400),ColumnName nvarchar(370), ColumnValue nvarchar(3630))      
      
    SET NOCOUNT ON      
      
    DECLARE @TableName nvarchar(256), @ColumnName nvarchar(128), @SearchStr2 nvarchar(110)      
    SET  @TableName = ''      
    SET @SearchStr2 = QUOTENAME('%' + @SearchStr + '%','''')      
      
    WHILE @TableName IS NOT NULL      
      
    BEGIN      
        SET @ColumnName = ''      
        SET @TableName =       
        (      
            SELECT MIN(QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME))      
            FROM     INFORMATION_SCHEMA.TABLES      
            WHERE         TABLE_TYPE = 'BASE TABLE'      
                AND    QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) > @TableName      
                AND    OBJECTPROPERTY(      
                        OBJECT_ID(      
                            QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME)      
                             ), 'IsMSShipped'      
                               ) = 0      
        )      
      
        WHILE (@TableName IS NOT NULL) AND (@ColumnName IS NOT NULL)      
      
        BEGIN      
            SET @ColumnName =      
            (      
                SELECT MIN(QUOTENAME(COLUMN_NAME))      
                FROM     INFORMATION_SCHEMA.COLUMNS      
                WHERE         TABLE_SCHEMA    = PARSENAME(@TableName, 2)      
                    AND    TABLE_NAME    = PARSENAME(@TableName, 1)      
                    AND    DATA_TYPE IN ('char', 'varchar', 'nchar', 'nvarchar', 'int', 'decimal')      
                    AND    QUOTENAME(COLUMN_NAME) > @ColumnName      
            )      
      
            IF @ColumnName IS NOT NULL      
      
            BEGIN      
                INSERT INTO #Results      
                EXEC      
                (      
                    'SELECT ''' + @TableName + ''',''' + @ColumnName + ''', LEFT(' + @ColumnName + ', 3630)       
                    FROM ' + @TableName + 'WITH (NOLOCK) ' +      
                    ' WHERE ' + @ColumnName + ' LIKE ' + @SearchStr2      
                )      
            END      
        END          
    END      
    
     
   --SELECT DISTINCT TableName, ColumnName, ColumnValue FROM #Results      
       
 --SELECT * FROM #Results     
 SELECT  DISTINCT MM.MenuId AS MID, MM.MenuName,MM.ControllerName,MM.ActionMethod FROM  TableMapping TM LEFT JOIN  #Results  RE    ON TM.TableName=RE.TableName    
             LEFT JOIN MenuMaster MM ON TM.MenuId=MM.MenuId    
 WHERE RE.TableName IS NOT NULL    AND MM.ActionMethod IS NOT NULL
    
END
GO
/****** Object:  StoredProcedure [dbo].[SearchAllTablesForClient]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
CREATE PROC [dbo].[SearchAllTablesForClient] --'okok'      
( 

@SearchStr nvarchar(100)  
)      
      
AS      
BEGIN      
      
    CREATE TABLE #Results (TableName nvarchar(400),ColumnName nvarchar(370), ColumnValue nvarchar(3630))      
      
    SET NOCOUNT ON      
      
    DECLARE @TableName nvarchar(256), @ColumnName nvarchar(128), @SearchStr2 nvarchar(110)      
    SET  @TableName = ''      
    SET @SearchStr2 = QUOTENAME('%' + @SearchStr + '%','''')      
      
    WHILE @TableName IS NOT NULL      
      
    BEGIN      
        SET @ColumnName = ''      
        SET @TableName =       
        (      
            SELECT MIN(QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME))      
            FROM     INFORMATION_SCHEMA.TABLES      
            WHERE         TABLE_TYPE = 'BASE TABLE'      
                AND    QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) > @TableName      
                AND    OBJECTPROPERTY(      
                        OBJECT_ID(      
                            QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME)      
                             ), 'IsMSShipped'      
                               ) = 0      
        )      
      
        WHILE (@TableName IS NOT NULL) AND (@ColumnName IS NOT NULL)      
      
        BEGIN      
            SET @ColumnName =      
            (      
                SELECT MIN(QUOTENAME(COLUMN_NAME))      
                FROM     INFORMATION_SCHEMA.COLUMNS      
                WHERE         TABLE_SCHEMA    = PARSENAME(@TableName, 2)      
                    AND    TABLE_NAME    = PARSENAME(@TableName, 1)      
                    AND    DATA_TYPE IN ('char', 'varchar', 'nchar', 'nvarchar', 'int', 'decimal')      
                    AND    QUOTENAME(COLUMN_NAME) > @ColumnName      
            )      
      
            IF @ColumnName IS NOT NULL      
      
            BEGIN      
                INSERT INTO #Results      
                EXEC      
                (      
                    'SELECT ''' + @TableName + ''',''' + @ColumnName + ''', LEFT(' + @ColumnName + ', 3630)       
                    FROM ' + @TableName + 'WITH (NOLOCK) ' +      
                    ' WHERE ' + @ColumnName + ' LIKE ' + @SearchStr2      
                )      
            END      
        END          
    END      
 --SELECT * FROM #Results     
 SELECT TC.MenuName,TC.ControllerName,TC.ActionMethod FROM TableMappingClient TC RIGHT JOIN #Results RES ON TC.TableName=RES.TableName WHERE TC.MenuName IS NOT NULL
 UNION
 SELECT DISTINCT PM.pagefilename AS MenuName,'Home'AS ControllerName,'UserClientPage' AS ActionMethod  FROM  #Results  RE LEFT JOIN  PageManagement PM ON RE.ColumnValue=PM.pagefilename 
 or RE.ColumnValue=PM.pagedescription
 or RE.ColumnValue=PM.pagecontent
 or re.ColumnValue=pm.createdby WHERE PM.pagefilename is not null
END
GO
/****** Object:  StoredProcedure [dbo].[Select_Clint]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Select_Clint]
As begin
Select * From [ClintUser]
end
GO
/****** Object:  StoredProcedure [dbo].[selectAddress]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectAddress]
AS 
Begin
select * From address
end
GO
/****** Object:  StoredProcedure [dbo].[Updateclient]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Updateclient]     
@Description VARCHAR(max),          
@ClientName VARCHAR(50),          
@Website VARCHAR(50),    
@id int  
    
AS      
BEGIN          
 DECLARE @ErrorCode VARCHAR(10)          
 DECLARE @ErrorMessage VARCHAR(50)          
 SET NOCOUNT ON;          
 BEGIN TRY         
              
  Update ClientMGT set [Description]=@Description ,  
  ClientName=@ClientName,Website=@Website where id=@id   
        
    SET @ErrorCode='0'          
  SET @ErrorMessage='updated Successfully'          
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage          
 END TRY          
 BEGIN CATCH          
  SET @ErrorCode='1'          
  SET @ErrorMessage='updated Failure'          
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage          
 END CATCH       
END 
GO
/****** Object:  StoredProcedure [dbo].[UpdatePrice]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdatePrice]       
@Productname VARCHAR(100),            
@Validity VARCHAR(100),            
@Price decimal,      
@id int    
      
AS        
BEGIN            
 DECLARE @ErrorCode VARCHAR(10)            
 DECLARE @ErrorMessage VARCHAR(50)            
 SET NOCOUNT ON;            
 BEGIN TRY           
                
  Update PriceMGT set Product_name=@Productname ,    
  Price=@Price,Validity=@Validity where id=@id     
          
    SET @ErrorCode='0'            
  SET @ErrorMessage='updated Successfully'            
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage            
 END TRY            
 BEGIN CATCH            
  SET @ErrorCode='1'            
  SET @ErrorMessage='updated Failure'            
  SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage            
 END CATCH         
END 
GO
/****** Object:  StoredProcedure [dbo].[UpdateVideoVisitingCount]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 /*=============================================    
 Author:  Bharathiraja    
 Create date: 2020/05/19   
 Description: Update Video Visiting Count    
 =============================================*/    
CREATE PROCEDURE [dbo].[UpdateVideoVisitingCount] --5,'video2.mp4','GGGGGGGG','filepath',false,'userid','username'
@VideoId INT  

AS    
BEGIN    
DECLARE @ErrorCode VARCHAR(10)    
DECLARE @ErrorMessage VARCHAR(50)    
SET NOCOUNT ON;    
BEGIN TRY    
 
  UPDATE tbl_VideoMedia SET ViewCount = ViewCount + 1 WHERE MediaID =@VideoId; 

  SELECT ViewCount FROM tbl_VideoMedia WHERE MediaID =@VideoId; 

--SET @ErrorCode='0'    
--SET @ErrorMessage='Insert Successfully'    
--SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
END TRY    
BEGIN CATCH    
--SET @ErrorCode='1'    
--SET @ErrorMessage=ERROR_MESSAGE()


--SELECT @ErrorCode AS ErrorCode ,@ErrorMessage AS ErrorMessage    
END CATCH    
END 
GO
/****** Object:  StoredProcedure [dbo].[UserManagementForClient]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bharathiraja
-- Create date: 27/04/2020
-- Description:	Get Email 
-- =============================================
CREATE PROCEDURE [dbo].[UserManagementForClient] 
--@UserId varchar(20),
--@RoleId  INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT pagefileName,pagedescription,pagecontent,pageid,userid,adminrights FROM PageManagement
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetHitCounter]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetHitCounter] 
	
AS
BEGIN

	SET NOCOUNT ON;

   --   select * 
	  --from HitCounter
	  select VML.Username, VML.IpAddress, VML.createddate, VML.createdby from Video_view_log VML left JOIN VideoMedia VM ON VM.MediaID = VML.MediaID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMenuData]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Bharathiraja
-- Create date: 24/04/2020
-- Description: Load Menu Dynamically by the below tables to partialview
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetMenuData] --100, 'jn'
@UserId varchar(20)

--@UserLanguage varchar(50)
AS
BEGIN
DECLARE @JapanLang INT

SET NOCOUNT ON;
SET @JapanLang=(SELECT TOP 1 ISNULL(IsJapanLang,0) FROM MenuMaster )

IF @JapanLang=0
BEGIN
SELECT
mm.MenuID MID,
mm.MenuName MenuName,
mm.ControllerName ControllerName,
mm.ActionMethod ActionMethod,
mm.MenuParentID MenuParentID,
mm.MenuParentCss1 MenuParentCss1
FROM
UserMaster um
INNER join RoleMenuMapping rm on um.RoleID=rm.RoleID
INNER join MenuMaster mm on mm.MenuId=rm.MenuID
INNER join RoleMaster br on br.RoleId =rm.RoleID
WHERE um.UserId = @UserId and rm.IsActive=1
END
ELSE
BEGIN
SELECT
mm.MenuID MID,
mm.LanguageJapanease LanguageJapanease,
mm.ControllerName ControllerName,
mm.ActionMethod ActionMethod,
mm.MenuParentID MenuParentID,
mm.MenuParentCss1 MenuParentCss1
FROM
UserMaster um
INNER join RoleMenuMapping rm on um.RoleID=rm.RoleID
INNER join MenuMaster mm on mm.MenuId=rm.MenuID
INNER join RoleMaster br on br.RoleId =rm.RoleID
WHERE um.UserId = @UserId and rm.IsActive=1
END
END

--IF @UserLanguage = 'en'
--BEGIN
-- SELECT
-- mm.MenuID MID,
-- mm.MenuName MenuName,
-- mm.ControllerName ControllerName,
-- mm.ActionMethod ActionMethod,
-- mm.MenuParentID MenuParentID,
-- mm.MenuParentCss1 MenuParentCss1
-- FROM
-- UserMaster um
-- INNER join RoleMenuMapping rm on um.RoleID=rm.RoleID
-- INNER join MenuMaster mm on mm.MenuId=rm.MenuID
-- INNER join RoleMaster br on br.RoleId =rm.RoleID
-- WHERE um.UserId = @UserId and rm.IsActive=1

-- END

-- ELSE
-- BEGIN
-- SELECT
-- mm.MenuID MID,
-- mm.LanguageJapanease LanguageJapanease,
-- mm.ControllerName ControllerName,
-- mm.ActionMethod ActionMethod,
-- mm.MenuParentID MenuParentID,
-- mm.MenuParentCss1 MenuParentCss1
-- FROM
-- UserMaster um
-- INNER join RoleMenuMapping rm on um.RoleID=rm.RoleID
-- INNER join MenuMaster mm on mm.MenuId=rm.MenuID
-- INNER join RoleMaster br on br.RoleId =rm.RoleID
-- WHERE um.UserId = @UserId and rm.IsActive=1



-- END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPresentation]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPresentation] 
	
AS
BEGIN

	SET NOCOUNT ON;

      select PF.mediaid, PF.filename, PPTU.Title, PPTU.Description from PPTfiles PF inner join tbl_PPTUPLOAD PPTU ON PF.mediaid = PPTU.MediaID WHERE IsActive='1';   
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetVideo]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetVideo] 
	@MediaID varchar(20), @Username varchar(20)
AS
BEGIN

	SET NOCOUNT ON;
	--UPDATE VideoMedia SET ViewCount = ViewCount + 1 WHERE MediaID =@MediaID;

      select M.ViewCount, F.FolderName, M.Title, M.Filename, M.Description 
	  from VideoFolder F inner join VideoMedia 
	  M on F.FolderID = M.FolderID where M.MediaID = @MediaID;
	  
	  insert into Video_view_log (Username, IpAddress, IsActive, createddate,createdby)
	  values(@Username, '172.168.72.57',1,GETDATE(),'Admin');
	  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_VideoMediaCountincrease]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_VideoMediaCountincrease] 
	@MediaID varchar(20)
AS
BEGIN
Declare @viewcount integer
	SET NOCOUNT ON;

     UPDATE VideoMedia SET ViewCount = ViewCount + 1 WHERE MediaID =@MediaID;

END
GO
/****** Object:  StoredProcedure [dbo].[ViewSocialMedia]    Script Date: 2022/04/13 11.35.34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ViewSocialMedia]   
   @SocialMediaID INT
AS  
BEGIN  
  
 SET NOCOUNT ON;  
  
   --   select *   
   --from HitCounter  
SELECT  SM.SocialMediaID, SM.Title, SM.URL, SMF.Filename from SocialMeida SM   
inner JOIN SocialMediaFiles SMF ON SM.SocialMediaID = SMF.SocialMediaId WHERE SM.SocialMediaID=@SocialMediaID
END  
GO
USE [master]
GO
ALTER DATABASE [Kaisokku] SET  READ_WRITE 
GO
