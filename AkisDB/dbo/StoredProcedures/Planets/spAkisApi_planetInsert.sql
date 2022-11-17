CREATE PROCEDURE [dbo].[spAkisApi_planetInsert]
	@PlanetName nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.[Planets] (PlanetName)
	VALUES (@PlanetName)
END
