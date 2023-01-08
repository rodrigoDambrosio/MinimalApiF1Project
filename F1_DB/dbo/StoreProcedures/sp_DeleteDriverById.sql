CREATE PROCEDURE [dbo].[sp_DeleteDriverById]
	@id int = 0
AS
BEGIN
 DELETE
 FROM dbo.Driver
 WHERE ID=@id
END

