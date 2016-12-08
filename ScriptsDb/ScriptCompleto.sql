CREATE DATABASE ChinchonSql

GO

USE ChinchonSql

GO

CREATE TABLE [dbo].[Jugador]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Apodo] VARCHAR(255) NOT NULL, 
    [PasswordHash] NVARCHAR(255) NOT NULL
)

GO

CREATE TABLE [dbo].[ParticipacionJugador] (
    [Id]                   INT          NOT NULL,
	[JugadorId]			   INT			NOT NULL,
    [IdentificadorPartida] VARCHAR (64) NOT NULL,
    [TiempoDeJuegoNeto]    INT          CONSTRAINT [DF_TiempoDeJuegoNeto] DEFAULT ((0)) NOT NULL,
    [PuntosAcumulados]     INT          CONSTRAINT [DF_PuntosAcumulados] DEFAULT ((0)) NOT NULL,
    [FueGanador]           BIT          CONSTRAINT [DF_FueGanador] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT FK_ParticipacionJugador_Jugador FOREIGN KEY (JugadorId) REFERENCES Jugador(Id)
);

GO

--Cargo dos jugadores por defecto para agilizar las pruebas
INSERT INTO Jugador(Id, Apodo, PasswordHash) VALUES(1, 'Red', '123');
INSERT INTO Jugador(Id, Apodo, PasswordHash) VALUES(2, 'Blue', '123');

GO
