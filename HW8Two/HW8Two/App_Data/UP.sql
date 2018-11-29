-- Buyer table
CREATE TABLE [dbo].[Buyers]
(
	[BuyerID]		INT IDENTITY (1,1)	NOT NULL,
	[BuyerName]	NVARCHAR(64)		NOT NULL,
	CONSTRAINT [PK_dbo.Buyer] PRIMARY KEY CLUSTERED ([BuyerName])
);

-- Seller table
CREATE TABLE [dbo].[Sellers]
(
	[SellerID]		INT IDENTITY (1,1)	NOT NULL,
	[SellerName]	NVARCHAR(64)		NOT NULL,
	CONSTRAINT [PK_dbo.Seller] PRIMARY KEY CLUSTERED ([SellerName])
);

-- Item table
CREATE TABLE [dbo].[Items]
(
	[ItemID]		INT IDENTITY (1,1)	NOT NULL,
	[ItemName]	NVARCHAR(64)		NOT NULL,
	[Description]	NVARCHAR(225)		NOT NULL,
	[SellerName]		NVARCHAR(64)		NOT NULL,
	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([ItemID]),
	CONSTRAINT [FK_dbo.Items] FOREIGN KEY ([SellerName]) REFERENCES [dbo].[Sellers] ([SellerName]),
);

--  Bid table
CREATE TABLE [dbo].[Bids]
(
	[BidID]		INT IDENTITY (1,1)	NOT NULL,
	[ItemID]	INT NOT NULL,
	[BuyerName]	NVARCHAR(64)		NOT NULL,
	[Price]	NVARCHAR(64)		NOT NULL,
	[DateValue]		DATETIME	NOT NULL,
	
	CONSTRAINT [PK_dbo.Bids] PRIMARY KEY CLUSTERED ([BidID]),
	CONSTRAINT [FK_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES [dbo].[Items] ([ItemID]),
	CONSTRAINT [FK2_dbo.Bids] FOREIGN KEY (BuyerName) REFERENCES [dbo].[Buyers] ([BuyerName])
);

INSERT INTO [dbo].[Buyers] (BuyerName) VALUES
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall')
GO 

INSERT INTO [dbo].[Sellers] (SellerName) VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene')
GO 

SET IDENTITY_INSERT Items ON
INSERT INTO [dbo].[Items] (ItemID,ItemName,Description,SellerName) VALUES 
	(1001,'Abraham Lincoln Hammer','A bench mallet fashioned from a broken rail-
splitting maul in 1829 and owned by Abraham Lincoln','Pearl Greene'),
	(1002,'Albert Einsteins Telescope','A brass telescope owned by Albert Einstein 
in Germany, circa 1927','Gayle Hardy'),
	(1003,'Bob Dylan Love Poems','Five versions of an original unpublished, 
handwritten, love poem by Bob Dylan','Lyle Banks')

GO 

INSERT INTO [dbo].[Bids] (ItemID,BuyerName,Price,DateValue) VALUES
	(1001,'Otto Vanderwall','250,000','12/04/2017 09:04:22'),
	(1003,'Jane Stone','95,000','12/04/2017 08:44:03')
	
GO 