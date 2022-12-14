USE [Florabank_online]
GO
/****** Object:  Table [dbo].[ApiParam]    Script Date: 1/20/2021 11:49:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ApiParam](
	[SendAft] [int] NULL,
	[ReloadAft] [int] NULL,
	[ApiUrl] [varchar](350) NULL,
	[ApiUser] [varchar](100) NULL,
	[ApiPass] [varchar](100) NULL,
	[autoyn] [varchar](1) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[cus_depositor_trn_traceno]    Script Date: 1/20/2021 11:49:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cus_depositor_trn_traceno](
	[traceno] [numeric](16, 0) NOT NULL,
	[accbranch_code] [char](4) NOT NULL,
	[conformYN] [char](1) NOT NULL CONSTRAINT [DF_cus_depositor_trn_traceno_conformYN]  DEFAULT ('N'),
	[Conform_sysdate] [datetime] NULL,
 CONSTRAINT [PK_cus_depositor_trn_traceno] PRIMARY KEY CLUSTERED 
(
	[traceno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
INSERT [dbo].[ApiParam] ([SendAft], [ReloadAft], [ApiUrl], [ApiUser], [ApiPass], [autoyn]) VALUES (2, 301, N'https://runner.prangroup.com:44322/api/mrx', N'12122', N'yegt54$hgFd65f5fH', N'Y')
