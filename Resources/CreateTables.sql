IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Entries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Entries](
	[EntryID] [int] IDENTITY(1,1) NOT NULL,
	[IDNumber] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Club] [nvarchar](255) NULL,
	[Province] [nvarchar](255) NULL
 CONSTRAINT [PK_STat] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END