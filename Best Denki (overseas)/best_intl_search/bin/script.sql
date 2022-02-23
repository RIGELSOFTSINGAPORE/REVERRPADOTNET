USE [master]
GO
/****** Object:  Database [best_intl]    Script Date: 04-08-2020 11:41:33 PM ******/
CREATE DATABASE [best_intl]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'best_intl', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\best_intl.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'best_intl_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\best_intl_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [best_intl] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [best_intl].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [best_intl] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [best_intl] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [best_intl] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [best_intl] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [best_intl] SET ARITHABORT OFF 
GO
ALTER DATABASE [best_intl] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [best_intl] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [best_intl] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [best_intl] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [best_intl] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [best_intl] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [best_intl] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [best_intl] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [best_intl] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [best_intl] SET  DISABLE_BROKER 
GO
ALTER DATABASE [best_intl] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [best_intl] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [best_intl] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [best_intl] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [best_intl] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [best_intl] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [best_intl] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [best_intl] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [best_intl] SET  MULTI_USER 
GO
ALTER DATABASE [best_intl] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [best_intl] SET DB_CHAINING OFF 
GO
ALTER DATABASE [best_intl] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [best_intl] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [best_intl] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [best_intl] SET QUERY_STORE = OFF
GO
USE [best_intl]
GO
/****** Object:  Table [dbo].[Cat_mtr]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_mtr](
	[BY_cls] [char](1) NOT NULL,
	[cd1] [varchar](4) NOT NULL,
	[cd2] [char](2) NOT NULL,
	[cd3] [char](2) NOT NULL,
	[品種名(ｶﾅ)] [nvarchar](255) NULL,
	[品種名(漢字)] [nvarchar](255) NULL,
	[avlbty] [nvarchar](255) NULL,
	[cd12] [char](6) NULL,
	[wrn_prod] [int] NULL,
	[GRP] [char](1) NULL,
	[crt_date] [smalldatetime] NULL,
 CONSTRAINT [PK_Cat_mtr] PRIMARY KEY CLUSTERED 
(
	[BY_cls] ASC,
	[cd1] ASC,
	[cd2] ASC,
	[cd3] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Cat_mtr]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_Cat_mtr]
AS
SELECT                  cd12, [品種名(漢字)], [品種名(ｶﾅ)], GRP, BY_cls
FROM                     dbo.Cat_mtr
WHERE                   (cd3 = '00')
GO
/****** Object:  Table [dbo].[Memo]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memo](
	[ordr_no] [char](14) NOT NULL,
	[memo] [varchar](1000) NULL,
 CONSTRAINT [PK_Memo] PRIMARY KEY CLUSTERED 
(
	[ordr_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shop_mtr]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop_mtr](
	[BY_cls] [char](1) NOT NULL,
	[shop_code] [nvarchar](4) NOT NULL,
	[店舗名(ｶﾅ)] [nvarchar](255) NULL,
	[店舗名(漢字)] [nvarchar](255) NULL,
	[分類CD] [nvarchar](255) NULL,
	[分類名] [nvarchar](255) NULL,
	[会社GRP] [float] NULL,
	[住所CD] [float] NULL,
	[郵便番号] [nvarchar](255) NULL,
	[都道府県名] [nvarchar](255) NULL,
	[市区町村名] [nvarchar](255) NULL,
	[住所１] [nvarchar](255) NULL,
	[住所２] [nvarchar](255) NULL,
	[TEL(市外)] [nvarchar](255) NULL,
	[TEL(市内)] [nvarchar](255) NULL,
	[TEL(番号)] [nvarchar](255) NULL,
	[FAX(市外)] [nvarchar](255) NULL,
	[FAX(市内)] [nvarchar](255) NULL,
	[FAX(番号)] [nvarchar](255) NULL,
	[close_date] [datetime] NULL,
 CONSTRAINT [PK_Shop_mtr] PRIMARY KEY CLUSTERED 
(
	[BY_cls] ASC,
	[shop_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[total_loss]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[total_loss](
	[ordr_no] [char](14) NOT NULL,
	[line_no] [char](2) NOT NULL,
	[seq] [int] NOT NULL,
	[total_loss_date] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_total_loss] PRIMARY KEY CLUSTERED 
(
	[ordr_no] ASC,
	[line_no] ASC,
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wrn_ivc]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wrn_ivc](
	[ordr_no] [char](14) NOT NULL,
	[line_no] [char](2) NOT NULL,
	[seq] [int] NOT NULL,
	[close_date] [datetime] NOT NULL,
	[seq_sub] [int] NOT NULL,
	[FLD002] [nvarchar](6) NULL,
	[FLD004] [nvarchar](4) NULL,
	[FLD005] [smalldatetime] NULL,
	[FLD006] [nvarchar](1) NULL,
	[FLD007] [nvarchar](1) NULL,
	[FLD008] [nvarchar](1) NULL,
	[FLD009] [nvarchar](1) NULL,
	[FLD010] [nvarchar](4) NULL,
	[FLD011] [nvarchar](4) NULL,
	[FLD012] [nvarchar](4) NULL,
	[FLD013] [char](2) NULL,
	[FLD014] [nvarchar](13) NULL,
	[FLD015] [varchar](120) NULL,
	[FLD016] [varchar](20) NULL,
	[FLD017] [nvarchar](5) NULL,
	[FLD018] [nvarchar](6) NULL,
	[FLD019] [varchar](30) NULL,
	[FLD020] [varchar](15) NULL,
	[FLD021] [smalldatetime] NULL,
	[FLD022] [smalldatetime] NULL,
	[FLD023] [int] NULL,
	[FLD024] [int] NULL,
	[FLD025] [int] NULL,
	[FLD026] [int] NULL,
	[FLD027] [int] NULL,
	[FLD028] [int] NULL,
	[FLD029] [int] NULL,
	[FLD030] [nvarchar](13) NULL,
	[FLD031] [smalldatetime] NULL,
	[FLD032] [nvarchar](1) NULL,
	[FLD033] [char](5) NULL,
	[FLD034] [char](4) NULL,
	[trbl_code] [char](1) NULL,
	[trbl_memo] [varchar](256) NULL,
	[rpar_mome] [varchar](256) NULL,
	[Remarks] [varchar](256) NULL,
	[kbn_No] [char](3) NULL,
	[Limit_money] [int] NULL,
	[Cancel_flg] [char](1) NULL,
	[Cancel_date] [smalldatetime] NULL,
	[close_flg] [char](1) NULL,
	[inp_seq] [int] NULL,
	[Limit_money_off] [bit] NULL,
	[FLD020_off] [bit] NULL,
	[BY_cls] [char](1) NULL,
	[entry_flg] [char](2) NULL,
	[buy_BY_cls] [char](1) NULL,
	[ent_BY_cls] [char](1) NULL,
	[fin_BY_cls] [char](1) NULL,
	[pos_code] [varchar](10) NULL,
	[imp_date] [datetime] NULL,
 CONSTRAINT [PK_Wrn_ivc] PRIMARY KEY CLUSTERED 
(
	[ordr_no] ASC,
	[line_no] ASC,
	[seq] ASC,
	[close_date] ASC,
	[seq_sub] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wrn_mtr]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wrn_mtr](
	[ordr_no] [char](14) NOT NULL,
	[cust_no] [varchar](15) NULL,
	[cust_fname] [varchar](15) NULL,
	[cust_lname] [varchar](120) NULL,
	[adrs1] [varchar](120) NULL,
	[adrs2] [varchar](120) NULL,
	[city_name] [varchar](24) NULL,
	[pref_code] [char](2) NULL,
	[zip_code] [char](7) NULL,
	[srch_phn] [varchar](15) NULL,
	[disp_phn] [varchar](20) NULL,
	[cid] [char](3) NULL,
	[shop_code] [char](4) NULL,
	[empl_code] [varchar](7) NULL,
	[org_ordr_no] [varchar](13) NULL,
	[corp_flg] [char](1) NULL,
	[entry_date] [datetime] NULL,
	[entry_flg] [char](1) NULL,
	[s_flg] [bit] NULL,
	[old_comp_flg] [bit] NULL,
	[b_flg] [bit] NULL,
	[aka_ordr_no] [varchar](13) NULL,
	[BY_cls] [char](1) NULL,
	[country] [varchar](10) NULL,
 CONSTRAINT [PK_Wrn_mtr] PRIMARY KEY CLUSTERED 
(
	[ordr_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wrn_sub]    Script Date: 04-08-2020 11:41:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wrn_sub](
	[ordr_no] [char](14) NOT NULL,
	[line_no] [char](2) NOT NULL,
	[seq] [int] NOT NULL,
	[prch_price] [decimal](18, 0) NULL,
	[prch_tax] [decimal](18, 0) NULL,
	[prch_date] [datetime] NULL,
	[item_cat_code] [varchar](6) NULL,
	[cat_name] [varchar](15) NULL,
	[prvd_cls] [char](1) NULL,
	[prch_unit] [char](4) NULL,
	[dlvr_cls] [char](1) NULL,
	[f_full] [char](1) NULL,
	[wrn_prod] [char](2) NULL,
	[wrn_part_prod] [char](2) NULL,
	[wrn_comp_prod] [char](2) NULL,
	[prm_comp_prod] [char](2) NULL,
	[cont_flg] [char](1) NULL,
	[bend_code] [char](5) NULL,
	[brnd_name] [varchar](10) NULL,
	[model_name] [varchar](30) NULL,
	[pos_code] [varchar](10) NULL,
	[ser_no] [char](15) NULL,
	[bend_wrn_prod] [char](3) NULL,
	[wrn_fee] [decimal](18, 0) NULL,
	[cxl_shop_code] [char](4) NULL,
	[cxl_date] [datetime] NULL,
	[op_date] [datetime] NULL,
	[cxl_op_date] [datetime] NULL,
	[close_date] [datetime] NULL,
	[close_cont_flg] [char](1) NULL,
	[target] [char](1) NULL,
	[total_loss_flg] [char](1) NULL,
	[wrn_fee_BF] [decimal](18, 0) NULL,
	[corp_flg] [char](1) NULL,
	[b_flg] [bit] NULL,
	[fin_date] [smalldatetime] NULL,
	[item_cat_code1] [varchar](4) NULL,
	[item_cat_code1_name] [varchar](10) NULL,
	[item_cat_code2] [char](2) NULL,
	[item_cat_code2_name] [varchar](10) NULL,
	[item_cat_code3] [char](2) NULL,
	[item_cat_code3_name] [varchar](10) NULL,
	[data_seq] [int] NULL,
	[wrn_item_code] [varchar](10) NULL,
	[wrn_item_name] [varchar](30) NULL,
	[BY_cls] [char](1) NULL,
	[cxl_close_date] [smalldatetime] NULL,
 CONSTRAINT [PK_Wrn_sub] PRIMARY KEY CLUSTERED 
(
	[ordr_no] ASC,
	[line_no] ASC,
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Memo] ([ordr_no], [memo]) VALUES (N'1             ', N'yuh')
GO
INSERT [dbo].[Shop_mtr] ([BY_cls], [shop_code], [店舗名(ｶﾅ)], [店舗名(漢字)], [分類CD], [分類名], [会社GRP], [住所CD], [郵便番号], [都道府県名], [市区町村名], [住所１], [住所２], [TEL(市外)], [TEL(市内)], [TEL(番号)], [FAX(市外)], [FAX(市内)], [FAX(番号)], [close_date]) VALUES (N'1', N'1', N'dsf', N'ffght', N'fdfdgf', N'dsdsf', 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Wrn_mtr] ([ordr_no], [cust_no], [cust_fname], [cust_lname], [adrs1], [adrs2], [city_name], [pref_code], [zip_code], [srch_phn], [disp_phn], [cid], [shop_code], [empl_code], [org_ordr_no], [corp_flg], [entry_date], [entry_flg], [s_flg], [old_comp_flg], [b_flg], [aka_ordr_no], [BY_cls], [country]) VALUES (N'1             ', N'1', N'testing', N'testing', N'check', N'check', N'chennai', N'1 ', N'7865   ', N'1256', N'123', N'1  ', N'1   ', N'1', N'1', N'1', CAST(N'2020-08-04T23:26:35.387' AS DateTime), NULL, NULL, NULL, NULL, NULL, N'B', N'india')
GO
ALTER TABLE [dbo].[Cat_mtr] ADD  CONSTRAINT [DF_Cat_mtr_BY_cls]  DEFAULT ('B') FOR [BY_cls]
GO
ALTER TABLE [dbo].[Shop_mtr] ADD  CONSTRAINT [DF_Shop_mtr_BY_cls]  DEFAULT ('B') FOR [BY_cls]
GO
ALTER TABLE [dbo].[Wrn_ivc] ADD  CONSTRAINT [DF_Wrn_ivc_BY_cls]  DEFAULT ('B') FOR [BY_cls]
GO
ALTER TABLE [dbo].[Wrn_ivc] ADD  CONSTRAINT [DF_Wrn_ivc_buy_BY_cls]  DEFAULT ('B') FOR [buy_BY_cls]
GO
ALTER TABLE [dbo].[Wrn_ivc] ADD  CONSTRAINT [DF_Wrn_ivc_ent_BY_cls]  DEFAULT ('B') FOR [ent_BY_cls]
GO
ALTER TABLE [dbo].[Wrn_ivc] ADD  CONSTRAINT [DF_Wrn_ivc_fin_BY_cls]  DEFAULT ('B') FOR [fin_BY_cls]
GO
ALTER TABLE [dbo].[Wrn_ivc] ADD  CONSTRAINT [DF_Wrn_ivc_imp_date]  DEFAULT (getdate()) FOR [imp_date]
GO
ALTER TABLE [dbo].[Wrn_mtr] ADD  CONSTRAINT [DF_Wrn_mtr_entry_date]  DEFAULT (getdate()) FOR [entry_date]
GO
ALTER TABLE [dbo].[Wrn_mtr] ADD  CONSTRAINT [DF_Wrn_mtr_BY_cls]  DEFAULT ('B') FOR [BY_cls]
GO
ALTER TABLE [dbo].[Wrn_sub] ADD  CONSTRAINT [DF_Wrn_sub_BY_cls]  DEFAULT ('B') FOR [BY_cls]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'システム区分 [B]：Brainsでの加入　[Y]：Yシステムでの加入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cat_mtr', @level2type=N'COLUMN',@level2name=N'BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'システム区分 [B]：Brainsでの加入　[Y]：Yシステムでの加入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shop_mtr', @level2type=N'COLUMN',@level2name=N'BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'ordr_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'line_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'seq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'締め日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'close_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'sub_seq' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'seq_sub'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'請求番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD002'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承認番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD004'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD005'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故場所' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD006'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故状況ﾌﾗｸﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD007'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'項目有無ﾌﾗｸﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD008'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全損ﾌﾗｸﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD009'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理品購入店' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD010'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理受付店' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD011'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理完了店' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD012'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'伝票区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD013'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理伝票番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD014'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顧客名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD015'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD016'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メーカー' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD017'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品種' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD018'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD019'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理品製造番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD020'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理受付日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD021'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理完了日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD022'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出張料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD023'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作業料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD024'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部品料計' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD025'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'値引き額' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD026'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'請求除外金額' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD027'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'請求額' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD028'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'見積額' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD029'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD030'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'処理日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD031'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'請求区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD032'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'掛種ｺｰﾄﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD033'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'余白' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD034'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'期間区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'kbn_No'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証限度額' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'Limit_money'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取消フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'Cancel_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取消日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'Cancel_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限度額チェックなし' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'Limit_money_off'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理品製造番号不一致チェックしない' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'FLD020_off'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'システム区分 [B]：Brainsでの加入　[Y]：Yシステムでの加入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手入力フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'entry_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理購入店コード体系 ベストコード体系は[B]、ヤマダ体系は[Y]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'buy_BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理受付店コード体系 ベストコード体系は[B]、ヤマダ体系は[Y]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'ent_BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理完了店コード体系 ベストコード体系は[B]、ヤマダ体系は[Y]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'fin_BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POSコード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_ivc', @level2type=N'COLUMN',@level2name=N'pos_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'伝票番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'ordr_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顧客番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'cust_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顧客名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'cust_fname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顧客姓（顧客姓名）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'cust_lname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'住所1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'adrs1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'住所2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'adrs2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市区町村名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'city_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'県コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'pref_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'郵便番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'zip_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話番号(検索)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'srch_phn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話番号(表示)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'disp_phn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'店舗コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'shop_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'担当者コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'empl_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'元伝票番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'org_ordr_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'法人フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'corp_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'entry_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手入力フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'entry_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'sonia引受分ﾌﾗｸﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N's_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'旧保険料率で計算ﾌﾗｸﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'old_comp_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Best引受分ﾌﾗｸﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'b_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赤伝票番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'aka_ordr_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'システム区分 [B]：Brainsでの加入　[Y]：Yシステムでの加入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_mtr', @level2type=N'COLUMN',@level2name=N'BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'伝票番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'ordr_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'line_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'seq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'売価' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'prch_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税額' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'prch_tax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'購入日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'prch_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品種コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'item_cat_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品種名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'cat_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'持配区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'prvd_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'購入数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'prch_unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'引渡方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'dlvr_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FULL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'f_full'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証修理期間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'wrn_prod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証部品期間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'wrn_part_prod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証主要コンポ期間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'wrn_comp_prod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主要コンポコード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'prm_comp_prod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'契約状況' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'cont_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メーカーコード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'bend_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メーカー名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'brnd_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'model_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POSコード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'pos_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'製造番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'ser_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メーカー保証期間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'bend_wrn_prod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'wrn_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取消店舗コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'cxl_shop_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取消日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'cxl_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'データ処理日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'op_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取消データ処理日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'cxl_op_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'締め日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'close_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'締め処理をした時の契約状況' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'close_cont_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'（未使用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'target'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全損フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'total_loss_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'料率変更前の値（未使用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'wrn_fee_BF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'法人フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'corp_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Best引受分ﾌﾗｸﾞ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'b_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完了日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'fin_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'大分類No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'item_cat_code1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'大分類名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'item_cat_code1_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中分類No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'item_cat_code2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中分類名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'item_cat_code2_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小分類No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'item_cat_code3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小分類名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'item_cat_code3_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'データ連番' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'data_seq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証商品コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'wrn_item_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保証商品型式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'wrn_item_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'システム区分 [B]：Brainsでの加入　[Y]：Yシステムでの加入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wrn_sub', @level2type=N'COLUMN',@level2name=N'BY_cls'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[32] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cat_mtr"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 245
               Right = 186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Cat_mtr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Cat_mtr'
GO
USE [master]
GO
ALTER DATABASE [best_intl] SET  READ_WRITE 
GO
