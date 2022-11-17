CREATE PROCEDURE [dbo].[spAkisApi_userJobInsert]
	@Title nvarchar(60),
	@Company nvarchar(100),
	@SectorId int,
	@YearsOfExperience int,
	@Salary float,
	@WorkModel varchar(20),
	@UserInfoId int
AS
BEGIN
	INSERT INTO dbo.[UserJobs] (Title,Company,SectorId,YearsOfExperience,Salary,WorkModel,UserInfoId)
	VALUES (@Title,@Company,@SectorId,@YearsOfExperience,@Salary,@WorkModel,@UserInfoId)
END
