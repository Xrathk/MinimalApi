CREATE PROCEDURE [dbo].[spAkisApi_userJobUpdate]
	@Id int,
	@Title nvarchar(60),
	@Company nvarchar(100),
	@SectorId int,
	@YearsOfExperience int,
	@Salary float,
	@WorkModel varchar(20),
	@UserInfoId int
AS
BEGIN
	UPDATE dbo.[UserJobs] 
	SET Title = @Title, Company = @Company, SectorId = @SectorId, YearsOfExperience = @YearsOfExperience, 
		Salary = @Salary, WorkModel = @WorkModel, UserInfoId = @UserInfoId
	WHERE Id = @Id
END
