USE [ShopNum1]
GO

/****** Object:  Table [dbo].[ShopNum1_MemberRank_LinkCategory]    Script Date: 08/25/2014 00:43:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ShopNum1_MemberRank_LinkCategory](
	[id] [int] IDENTITY(1,1) NOT NULL ,
	[Rank_ID] [uniqueidentifier] NOT NULL,
	[Category_ID] [nvarchar](max) NOT NULL,
	[IsReadOrBuy] [int] NOT NULL,
 CONSTRAINT [PK_ShopNum1_MemberRank_LinkCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


