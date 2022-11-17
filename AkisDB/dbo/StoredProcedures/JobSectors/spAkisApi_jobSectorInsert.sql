CREATE PROCEDURE [dbo].[spAkisApi_jobSectorInsert]
	@SectorName nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.[JobSectors] (SectorName)
	VALUES (@SectorName)
END
