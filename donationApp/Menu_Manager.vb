Public Class Menu_Manager

    Private Sub Menu_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LaporanButton_Click(sender As Object, e As EventArgs) Handles LaporanButton.Click
        Dim pnl As New Laporan_Manager(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        Dim pnl As New Login_Manager(Form1)
        pnl.swipe(True)
    End Sub
End Class
