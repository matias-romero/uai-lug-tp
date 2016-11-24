Imports Chinchon.Entities

'Este repositorio es de consumo interno
Friend Class ParticipacionJugadorRepositorio
    Private ReadOnly _conector As IConector

    Public Sub New(conector As IConector)
        _conector = conector
    End Sub

    Public Sub CargarParticipacionesPorJugador(jugador As Jugador)
        Const consulta As String = "SELECT Id, IdentificadorPartida, TiempoDeJuegoNeto, PuntosAcumulados, FueGanador FROM ParticipacionJugador WHERE JugadorId=@JUGADORID"
        Dim parametroJugadorId As IDbDataParameter = _conector.CrearNuevoParametro("@JUGADORID", jugador.Id)

        Dim tabla As DataTable = _conector.LeerResultados(consulta, parametroJugadorId)
        For Each row As DataRow In tabla.Rows
            Call Me.CargarParticipacionJugadorDesdeDataRow(jugador, row)
        Next
    End Sub

    Public Function ActualizarParticipacionesPorJugador(jugador As Jugador) As Integer
        Const consulta As String = "INSERT INTO ParticipacionJugador(Id, JugadorId, IdentificadorPartida, TiempoDeJuegoNeto, PuntosAcumulados, FueGanador) " _
                                   & "VALUES(@ID, @JUGID, @IDPARTIDA, @TIEMPO, @PUNTOS, @GANADOR)"

        'Borro lo que tenga para ese jugador e inserto nuevamente todas las participaciones del mismo
        Dim filasInsertadas As Integer = 0
        Dim filasBorradas As Integer = Me.BorrarDatosExistentes(jugador)
        If jugador.ParticipacionesRegistradasEnPartidas.Any() Then

            'Por cada participacion actualizo los parametros y ejecuto la consulta de inserción
            Dim proximoId As Integer = Me.CalcularProximoID()
            For Each participacion As ParticipacionJugadorEnPartida In jugador.ParticipacionesRegistradasEnPartidas
                participacion.Id = proximoId

                Dim parametroId As IDbDataParameter = _conector.CrearNuevoParametro("@ID", proximoId)
                Dim parametroJugadorId As IDbDataParameter = _conector.CrearNuevoParametro("@JUGID", jugador.Id)
                Dim parametroPartidaId As IDbDataParameter = _conector.CrearNuevoParametro("@IDPARTIDA", participacion.IdentificadorPartida.ToString())
                Dim parametroTiempoNeto As IDbDataParameter = _conector.CrearNuevoParametro("@TIEMPO", participacion.TiempoDeJuegoNeto.Ticks)
                Dim parametroPuntaje As IDbDataParameter = _conector.CrearNuevoParametro("@PUNTOS", participacion.PuntosAcumulados)
                Dim parametroGanador As IDbDataParameter = _conector.CrearNuevoParametro("@GANADOR", participacion.FueGanador)

                filasInsertadas += _conector.ModificarFilas(consulta, parametroId, parametroJugadorId, parametroPartidaId, parametroTiempoNeto, parametroPuntaje, parametroGanador)
                proximoId += 1
            Next
        End If

        Return filasInsertadas
    End Function

    ''' <summary>
    ''' Borra los registros de un jugador dado a que no trackeo cuales se borraron de la coleccion relacionada
    ''' </summary>
    Private Function BorrarDatosExistentes(jugador As Jugador) As Integer
        Dim parametroJugadorId As IDbDataParameter = _conector.CrearNuevoParametro("@JUGADORID", jugador.Id)
        Return _conector.ModificarFilas("DELETE FROM ParticipacionJugador WHERE JUGADORID=@JUGADORID", parametroJugadorId)
    End Function

    Private Function CargarParticipacionJugadorDesdeDataRow(jugador As Jugador, dataRow As DataRow) As ParticipacionJugadorEnPartida
        Dim participacion = Me.MaterializarParticipacionJugadorDesdeDataRow(dataRow)
        jugador.ParticipacionesRegistradasEnPartidas.Add(participacion)
    End Function

    Private Function MaterializarParticipacionJugadorDesdeDataRow(dataRow As DataRow) As ParticipacionJugadorEnPartida
        Dim participacion As New ParticipacionJugadorEnPartida()
        participacion.Id = dataRow.Item("Id")
        participacion.IdentificadorPartida = Guid.Parse(dataRow.Item("IdentificadorPartida"))
        participacion.TiempoDeJuegoNeto = TimeSpan.FromTicks(dataRow.Item("TiempoDeJuegoNeto"))
        participacion.PuntosAcumulados = dataRow.Item("PuntosAcumulados")
        participacion.FueGanador = dataRow.Item("FueGanador")
        Return participacion
    End Function

    Private Function CalcularProximoID() As Integer
        Const consulta As String = "SELECT ISNULL(MAX(ID),0) + 1 AS ID FROM ParticipacionJugador"
        Return _conector.LeerEscalar(Of Integer)(consulta)
    End Function
End Class
