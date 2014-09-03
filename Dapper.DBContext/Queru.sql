

select * from Articles



USE [teamontrack]
GO

/****** Object:  Table [dbo].[Articles]    Script Date: 9/3/2014 8:42:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Articles](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdated] [datetime] NULL,
	[Status] [varchar](100) NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

