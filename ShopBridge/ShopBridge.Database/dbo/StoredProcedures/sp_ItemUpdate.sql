CREATE PROCEDURE [dbo].[sp_ItemUpdate]
	@Name nvarchar(50),
	@Description nvarchar(250),
	@Price money,
	@Quantity int,
	@ItemId int output
AS
BEGIN

SET NOCOUNT ON
 UPDATE dbo.Item
 SET [Name]=@Name,
     [Description]=@Description,
	 [Price]=@Price,
	 [Quantity]=@Quantity
	 WHERE ItemId=@ItemId

END