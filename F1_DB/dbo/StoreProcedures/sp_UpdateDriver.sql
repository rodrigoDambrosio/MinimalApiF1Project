CREATE PROCEDURE [dbo].[sp_UpdateDriver]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Number tinyint,
    @PhotoPath nvarchar(260)
AS
	UPDATE Driver
	set FirstName=@FirstName, LastName=@LastName, Number=@Number, PhotoPath=@PhotoPath
	Where Id=@Id

