CREATE PROCEDURE [dbo].[spAkisApi_jobSectorUpdate]
	@Id int,
	@SectorName nvarchar(50)
AS
BEGIN
	UPDATE dbo.[JobSectors] 
	SET SectorName = @SectorName
	WHERE Id = @Id
END
