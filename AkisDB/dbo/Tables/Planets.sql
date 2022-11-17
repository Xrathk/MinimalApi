CREATE TABLE [dbo].[Planets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[PlanetName] nvarchar(50) NOT NULL UNIQUE
)
