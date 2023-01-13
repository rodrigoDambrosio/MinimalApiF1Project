CREATE PROCEDURE [dbo].[sp_GetDriverPhotoPath]
	@Id int
AS
	SELECT Driver.PhotoPath
	FROM Driver
	Where Id=@Id

