CREATE PROCEDURE [dbo].[sp_GetItems]
	
AS
	BEGIN

	SET NOCOUNT ON;

	SELECT [ItemId], [Name], [Description], [Price], [Quantity]
	FROM dbo.Item

	END
