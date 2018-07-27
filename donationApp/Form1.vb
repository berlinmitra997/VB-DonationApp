Imports MetroFramework

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pnl As New Login_Staff(Me)
        pnl.swipe(True)
    End Sub
End Class
