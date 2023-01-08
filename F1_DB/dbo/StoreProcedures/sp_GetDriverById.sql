CREATE PROCEDURE [dbo].[sp_GetDriverById]
	@id int = 0
AS
BEGIN
 SELECT *
 FROM dbo.Driver
 WHERE ID=@id
END

