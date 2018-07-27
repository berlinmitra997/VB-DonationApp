Imports MetroFramework
Imports MySql.Data.MySqlClient
Public Class Login_Staff
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim pnl As New Menu_Staff(Form1)

        Dim conn As MySqlConnection
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost; user id=root; password= ; database=donation_go"

        Try
            conn.Open()
        Catch myerror As MySqlException
            MsgBox("Ada kesalahan dalam koneksi database, silahkan periksa koneksi database")
        End Try

        Dim sql, id_admin, password, jabatan As String
        Dim cmd As MySqlCommand
        Dim dr As MySqlDataReader

        id_admin = id_admin_text.Text
        password = pass_admin_text.Text
        jabatan = cb_jabatan.SelectedItem

        sql = "select * from admin where id_admin='" + id_admin + "'AND pass_admin='" + password + "'AND jbtn_admin='" + jabatan + "'"
        cmd = New MySqlCommand(sql, conn)
        dr = cmd.ExecuteReader()

        If dr.HasRows = True And cb_jabatan.SelectedItem = "Staff" Then
            pnl.swipe(True)
            Me.Hide()
        Else
            MsgBox("Username atau Password ada yang salah !", MsgBoxStyle.Exclamation, "Error Login")
        End If
    End Sub


    Private Sub BackHome_Click(sender As Object, e As EventArgs) Handles BackHome.Click
        Dim pnl As New Login_Manager(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub Login_Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
