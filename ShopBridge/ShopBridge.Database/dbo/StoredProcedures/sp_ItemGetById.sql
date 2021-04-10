CREATE PROCEDURE [dbo].[sp_ItemGetById]
	@ItemId int
AS
	begin
	  set nocount on

	  select [ItemId], [Name], [Description], [Price], [Quantity]
	  from dbo.Item
	  where [ItemId]=@ItemId

	end
