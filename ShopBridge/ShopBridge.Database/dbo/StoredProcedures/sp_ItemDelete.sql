CREATE PROCEDURE [dbo].[sp_ItemDelete]
	@ItemId INT
AS
	
BEGIN
   SET NOCOUNT ON

   DELETE FROM dbo.Item
   WHERE ItemId=@ItemId

END
