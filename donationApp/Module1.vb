Imports System.Data
Imports System.Data.Odbc

Module Module1
    Public connect As OdbcConnection
    Public DA As OdbcDataAdapter
    Public DS As DataSet
    Public DR As OdbcDataReader
    Public CMD As OdbcCommand
    Public DT As DataTable
    Public simpan, ubah, hapus As String

    Sub OpenDB()
        Try
            connect = New OdbcConnection("DSN=donation_go;MultipleActiveResultSets=True")
            If connect.State = ConnectionState.Closed Then
                connect.Open()
            End If
        Catch ex As Exception
            MsgBox("Error, Check Again your connection")
        End Try
    End Sub
End Module
