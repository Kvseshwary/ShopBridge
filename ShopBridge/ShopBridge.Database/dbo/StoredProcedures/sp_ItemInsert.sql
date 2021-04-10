CREATE PROCEDURE [dbo].[sp_ItemInsert]
	@Name nvarchar(50),
	@Description nvarchar(250),
	@Price money,
	@Quantity int,
	@ItemId int output

AS
	BEGIN
	  SET NOCOUNT ON
	  INSERT INTO dbo.Item([Name],[Description],Price,Quantity)
	  VALUES (@Name,@Description,@Price,@Quantity);

	  SET @ItemId=SCOPE_IDENTITY();
	END