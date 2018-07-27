Public Class Menu_Staff



    Private Sub TransaksiButton_Click(sender As Object, e As EventArgs) Handles TransaksiButton.Click
        Dim pnl As New Transaksi(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        Dim pnl As New Login_Staff(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub PendaftaranButton_Click(sender As Object, e As EventArgs) Handles PendaftaranButton.Click
        Dim pnl As New Pendaftaran(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub PembaruanButton_Click(sender As Object, e As EventArgs) Handles PembaruanButton.Click
        Dim pnl As New Pembaruan(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub LaporanButton_Click(sender As Object, e As EventArgs) Handles LaporanButton.Click
        Dim pnl As New Laporan_Staff(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub Menu_Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
