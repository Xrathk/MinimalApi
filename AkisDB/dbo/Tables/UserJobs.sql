CREATE TABLE [dbo].[UserJobs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(60) NOT NULL, 
    [Company] NVARCHAR(100) NULL,
    [SectorId] INT NOT NULL, 
    [YearsOfExperience] int NULL, 
    [Salary] FLOAT NULL, 
    [WorkModel] VARCHAR(20) NOT NULL, 
    [UserInfoId] INT NOT NULL, 
    CONSTRAINT [FK_UsersJobs_ToUserInfos] FOREIGN KEY ([UserInfoId]) REFERENCES [UsersAdditionalInfo]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsersJobs_ToJobSectors] FOREIGN KEY ([SectorId]) REFERENCES [JobSectors]([Id])
)
