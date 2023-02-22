CREATE PROCEDURE [dbo].[sp_InsertDriver]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Number tinyint,
    @PhotoPath nvarchar(260)
AS
	INSERT INTO Driver
	VALUES (@FirstName,@LastName,@Number,@PhotoPath)

