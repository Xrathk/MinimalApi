CREATE TABLE [dbo].[JobSectors]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[SectorName] nvarchar(50) NOT NULL UNIQUE
)
