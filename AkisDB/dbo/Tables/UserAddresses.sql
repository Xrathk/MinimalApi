CREATE TABLE [dbo].[UserAddresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PlanetId] INT NOT NULL, 
    [Country] NVARCHAR(90) NULL, 
    [Address] NVARCHAR(128) NOT NULL, 
    [AreaCode] NVARCHAR(20) NULL, 
    [UserInfoId] INT NOT NULL, 
    CONSTRAINT [FK_UsersAddresses_ToUserInfos] FOREIGN KEY ([UserInfoId]) REFERENCES [UsersAdditionalInfo]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsersAddresses_ToPlanets] FOREIGN KEY ([PlanetId]) REFERENCES [Planets]([Id])
)
