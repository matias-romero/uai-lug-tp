CREATE TABLE [dbo].[Jugador]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Apodo] VARCHAR(255) NOT NULL, 
    [PasswordHash] NVARCHAR(255) NOT NULL
)
