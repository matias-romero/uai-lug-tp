Imports System.Data.Common

'Encapsula la conexion con el repositorio de datos
Public Class Conector
    Implements IDisposable

    'Defino el proveedor ADO.NET compatible que utilizara la capa de persistencia y lo trabajo agnóstico al motor de DB
    Public Shared Property ProveedorPorDefecto As DbProviderFactory = SqlClient.SqlClientFactory.Instance

    Private _conexion As DbConnection

    Public Sub New(cnnString As String)
        _conexion = ProveedorPorDefecto.CreateConnection()
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                _conexion.Dispose()
            End If
            _conexion = Nothing
        End If
        disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
    End Sub
#End Region

End Class
