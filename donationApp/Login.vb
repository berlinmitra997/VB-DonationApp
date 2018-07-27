Imports MetroFramework
Public Class Login
    Private Sub idadmin_gotfocus() Handles IDadmin.GotFocus
        If IDadmin.Text = "ID" Then
            IDadmin.ForeColor = Color.Black
            IDadmin.Text = String.Empty

        End If
    End Sub

    Private Sub idadmin_lostfocus() Handles IDadmin.LostFocus
        If IDadmin.Text = String.Empty Then
            IDadmin.ForeColor = Color.Silver
            IDadmin.Text = "ID"
        End If
    End Sub

    Private Sub passadmin_gotfocus() Handles PassAdmin.GotFocus
        If PassAdmin.Text = "Password" Then
            PassAdmin.ForeColor = Color.Black
            PassAdmin.Text = String.Empty
            PassAdmin.PasswordChar = "•"c

        End If
    End Sub

    Private Sub passadmin_lostfocus() Handles PassAdmin.LostFocus
        If PassAdmin.Text = String.Empty Then
            PassAdmin.ForeColor = Color.Silver
            PassAdmin.Text = "Password"
            PassAdmin.PasswordChar = CChar(String.Empty)
        End If
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim pnl As New Menu(Form1)
        pnl.swipe(True)
    End Sub


    Private Sub idadmin_lostfocus(sender As Object, e As EventArgs) Handles IDadmin.LostFocus

    End Sub
    Private Sub idadmin_gotfocus(sender As Object, e As EventArgs) Handles IDadmin.GotFocus

    End Sub
    Private Sub passadmin_lostfocus(sender As Object, e As EventArgs) Handles PassAdmin.LostFocus

    End Sub
    Private Sub passadmin_gotfocus(sender As Object, e As EventArgs) Handles PassAdmin.GotFocus

    End Sub


End Class
