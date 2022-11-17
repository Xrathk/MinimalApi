CREATE PROCEDURE [dbo].[spAkisApi_userInsert]
	@FirstName nvarchar(60),
	@LastName nvarchar(60),
	@DateCreated datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Users] (FirstName,LastName,DateCreated)
	VALUES (@FirstName,@LastName,@DateCreated)
END
