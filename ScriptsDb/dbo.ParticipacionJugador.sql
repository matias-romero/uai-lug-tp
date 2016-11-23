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

