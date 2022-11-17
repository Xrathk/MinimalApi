CREATE PROCEDURE [dbo].[spAkisApi_planetUpdate]
	@Id int,
	@PlanetName nvarchar(50)
AS
BEGIN
	UPDATE dbo.[Planets] 
	SET PlanetName = @PlanetName
	WHERE Id = @Id
END

