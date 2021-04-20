CREATE PROCEDURE [dbo].[sp_ItemUpdate]
	@ItemId int,
	@Name nvarchar(50),
	@Description nvarchar(250),
	@Price money,
	@Quantity int,
	@ItemDetailId int output
AS
BEGIN

SET NOCOUNT ON
 UPDATE dbo.Item
 SET [Name]=@Name,
     [Description]=@Description,
	 [Price]=@Price,
	 [Quantity]=@Quantity
	 WHERE ItemId=@ItemId

select @ItemDetailId=@ItemId
From  [dbo].[Item]

END