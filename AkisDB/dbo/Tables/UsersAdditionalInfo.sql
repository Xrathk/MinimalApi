CREATE TABLE [dbo].[UsersAdditionalInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateOfBirth] DATE NULL, 
    [Gender] VARCHAR(10) NULL, 
    [Height] FLOAT NULL, 
    [Weight] FLOAT NULL, 
    [PlanetOfOriginId] INT NOT NULL,
    [CountryOfOrigin] nvarchar(90) NULL,
    [UserId] INT NOT NULL UNIQUE, 
    CONSTRAINT [FK_UsersAdditionalInfo_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsersAdditionalInfo_ToPlanets] FOREIGN KEY ([PlanetOfOriginId]) REFERENCES [Planets]([Id])
)
