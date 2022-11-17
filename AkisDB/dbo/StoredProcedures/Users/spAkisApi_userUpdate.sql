CREATE PROCEDURE [dbo].[spAkisApi_userUpdate]
	@Id int,
	@FirstName nvarchar(60),
	@LastName nvarchar(60),
	@DateCreated date
AS
BEGIN
	UPDATE dbo.[Users] 
	SET FirstName = @FirstName, LastName = @LastName
	WHERE Id = @Id
END
