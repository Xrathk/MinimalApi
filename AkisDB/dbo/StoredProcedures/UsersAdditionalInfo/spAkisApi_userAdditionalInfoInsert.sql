CREATE PROCEDURE [dbo].[spAkisApi_userAdditionalInfoInsert]
	@DateOfBirth date,
	@Gender varchar(10),
	@Height float,
	@Weight float,
	@PlanetOfOriginId int,
	@CountryOfOrigin nvarchar(90),
	@UserId int
AS
BEGIN
	INSERT INTO dbo.[UsersAdditionalInfo] (DateOfBirth,Gender,Height,Weight,PlanetOfOriginId,CountryOfOrigin,UserId)
	VALUES (@DateOfBirth,@Gender,@Height,@Weight,@PlanetOfOriginId,@CountryOfOrigin,@UserId)
END
