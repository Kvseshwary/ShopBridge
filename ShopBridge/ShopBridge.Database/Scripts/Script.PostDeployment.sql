/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists(select * from dbo.Item)
begin
 insert into dbo.Item([Name],[Description],Price,Quantity)
 values('Washing Machines','Front Load',20000,2),
 ('Decor Lamps','Light Angle Wood Table Lamp, Beige',1000,1),
 ('Security Cameras','1080p Full HD 360° Viewing Area Smart Security Camera, White',2899.99,12);

end
