CREATE PROCEDURE [dbo].[spAkisApi_userAdditionalInfoUpdate]
	@Id int,
	@DateOfBirth date,
	@Gender varchar(10),
	@Height float,
	@Weight float,
	@PlanetOfOriginId int,
	@CountryOfOrigin nvarchar(90),
	@UserId int
AS
BEGIN
	UPDATE dbo.[UsersAdditionalInfo] 
	SET DateOfBirth = @DateOfBirth, Gender = @Gender, Height = @Height, Weight = @Weight,
		PlanetOfOriginId = @PlanetOfOriginId, CountryOfOrigin = @CountryOfOrigin, UserId = @UserId
	WHERE Id = @Id
END
