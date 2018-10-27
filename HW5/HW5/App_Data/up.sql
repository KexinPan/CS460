-- Users table
CREATE TABLE [dbo].[RequestForms]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[FirstName]	NVARCHAR(64)		NOT NULL,
	[LastName]	NVARCHAR(128)		NOT NULL,
	[PhoneNumber]		NVARCHAR(64)			NOT NULL,
	[ApartmentName]		NVARCHAR(64)			NOT NULL,
	[UnitNumber]		INT NOT NUll,
	[Description]		NVARCHAR(64)			NOT NULL,
	[Permission]		BIT			  NOT NULL,
	[DateValue]		DATE	NOT NULL
	CONSTRAINT [PK_dbo.RequestForms] PRIMARY KEY CLUSTERED ([ID])
);

INSERT INTO [dbo].[RequestForms] (FirstName, LastName, PhoneNumber,ApartmentName,UnitNumber,Description,Permission,DateValue) VALUES
	('Jia','Li','971-707-9069','Sunshine',22,'The sink in the bathroom on the first floor is broken',0,'10/15/2018'),
	('Sue','Suzanne','839-472-9203','Sunshine',6,'The window in the living room is broken',0, '10/14/2017'),
	('Mira','Kuzak','976-282-6284','Garden',19,'Microwave does not work',1,'09/25/2018'),
	('Big','Simpson','637-383-3284','Homested',8,'Refridge does not work',1,'08/29/2018'),
	('Monster','Sherc','976-282-6284','Garden',8,'The sink in the kitchen is broken',1,'10/18/2018')
GO 