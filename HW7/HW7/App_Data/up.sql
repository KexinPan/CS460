-- Users table
CREATE TABLE [dbo].[Requests]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[Description]	NVARCHAR(500)		NULL,
	[IPAddress]		NVARCHAR(500)			NOT NULL,
	[Type]		NVARCHAR(500)			NOT NULL,
	[DateValue]		DATETIME	NOT NULL
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID])
);
GO 