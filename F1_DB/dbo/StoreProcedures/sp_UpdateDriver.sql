CREATE PROCEDURE [dbo].[sp_UpdateDriver]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Number smallint
AS
	UPDATE Driver
	set FirstName=@FirstName, LastName=@LastName, Number=@Number
	Where Id=@Id

