CREATE TABLE [dbo].[Item]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(250) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Quantity] INT NOT NULL
)
