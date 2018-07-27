Public Class Pendaftaran

    'Back Button
    Private Sub BackHome_Click(sender As Object, e As EventArgs) Handles BackHome.Click
        Dim pnl As New Menu_Staff(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub Pendaftaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call OpenDB()
    End Sub


    'Admin

    Sub bersih_admin()
        id_admin.Text = ""
        pass_admin.Text = ""
        fn_admin.Text = ""
        ln_admin.Text = ""
        jbtn_admin.Text = ""
        cb_gender_admin.Text = ""
        ttl_admin.Text = ""
        contact_admin.Text = ""
        id_admin.Focus()
        daftar_admin.Text = "Daftar"
    End Sub

    Private Sub daftar_admin_Click(sender As Object, e As EventArgs) Handles daftar_admin.Click
        If daftar_admin.Text = "Daftar" Then
            daftar_admin.Text = "Simpan"
            id_admin.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT id_admin from admin WHERE id_admin = '" & id_admin.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO admin (id_admin,pass_admin,fn_admin,ln_admin,jbtn_admin,gender_admin,ttl_admin,contact_admin) VALUES('" & id_admin.Text & "','" & pass_admin.Text & "','" & fn_admin.Text & "','" & ln_admin.Text & "','" & jbtn_admin.Text & "','" & cb_gender_admin.Text & "','" & Format(ttl_admin.Value, "yyyy-MM-dd") & "','" & contact_admin.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersih_admin()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub batal_admin_Click(sender As Object, e As EventArgs) Handles batal_admin.Click
        Call bersih_admin()
    End Sub



    'Donatur
    Sub bersih_donatur()
        id_donatur.Text = ""
        fn_donatur.Text = ""
        ln_donatur.Text = ""
        cb_gender_donatur.Text = ""
        ttl_donatur.Text = ""
        profesi_donatur.Text = ""
        contact_donatur.Text = ""
        id_donatur.Focus()
        daftar_donatur.Text = "Daftar"
    End Sub

    Private Sub daftar_donatur_Click(sender As Object, e As EventArgs) Handles daftar_donatur.Click
        If daftar_donatur.Text = "Daftar" Then
            daftar_donatur.Text = "Simpan"
            id_donatur.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT id_donatur from donatur WHERE id_donatur = '" & id_donatur.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO donatur (id_donatur,fn_donatur,ln_donatur,gender_donatur,ttl_donatur,profesi_donatur,contact_donatur) VALUES('" & id_donatur.Text & "','" & fn_donatur.Text & "','" & ln_donatur.Text & "','" & cb_gender_donatur.Text & "','" & Format(ttl_donatur.Value, "yyyy-MM-dd") & "','" & profesi_donatur.Text & "','" & contact_donatur.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersih_donatur()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub batal_donatur_Click(sender As Object, e As EventArgs) Handles batal_donatur.Click
        Call bersih_donatur()
    End Sub




    'Relawan
    Sub bersih_relawan()
        id_relawan.Text = ""
        fn_relawan.Text = ""
        ln_relawan.Text = ""
        cb_gender_relawan.Text = ""
        cb_jenis_perusahaan.Text = ""
        ttl_relawan.Text = ""
        nm_perusahaan.Text = ""
        alamat_perusahaan.Text = ""
        contact_relawan.Text = ""
        id_relawan.Focus()
        daftar_relawan.Text = "Daftar"
    End Sub

    Private Sub daftar_relawan_Click(sender As Object, e As EventArgs) Handles daftar_relawan.Click
        If daftar_relawan.Text = "Daftar" Then
            daftar_relawan.Text = "Simpan"
            id_relawan.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT id_relawan from relawan WHERE id_relawan = '" & id_relawan.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO relawan (id_relawan,fn_relawan,ln_relawan,gender_relawan,ttl_relawan,nm_perusahaan,jenis_perusahaan,alamat_perusahaan,contact_relawan) VALUES('" & id_relawan.Text & "','" & fn_relawan.Text & "','" & ln_relawan.Text & "','" & cb_gender_relawan.Text & "','" & Format(ttl_relawan.Value, "yyyy-MM-dd") & "','" & nm_perusahaan.Text & "','" & cb_jenis_perusahaan.Text & "','" & alamat_perusahaan.Text & "','" & contact_relawan.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersih_relawan()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub batal_relawan_Click(sender As Object, e As EventArgs) Handles batal_relawan.Click
        Call bersih_relawan()
    End Sub






    'Donasi Bencana Alam
    Sub bersihba()
        kd_ba.Text = ""
        daerah_ba.Text = ""
        jenis_ba.Text = ""
        kd_ba.Focus()
        daftar_ba.Text = "Daftar"
    End Sub

    Private Sub daftar_ba_Click(sender As Object, e As EventArgs) Handles daftar_ba.Click
        If daftar_ba.Text = "Daftar" Then
            daftar_ba.Text = "Simpan"
            kd_ba.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_ba from bencana_alam WHERE kd_ba = '" & kd_ba.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO bencana_alam (kd_ba,daerah_ba,jenis_ba) VALUES('" & kd_ba.Text & "','" & daerah_ba.Text & "','" & jenis_ba.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihba()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub batal_ba_Click(sender As Object, e As EventArgs) Handles batal_ba.Click
        Call bersihba()
    End Sub



    'Donasi Dana Sekolah
    Sub bersihds()
        kd_ds.Text = ""
        nama_sekolah.Text = ""
        alamat_sekolah.Text = ""
        daerah_sekolah.Text = ""
        kd_ds.Focus()
        daftar_ds.Text = "Daftar"
    End Sub

    Private Sub daftar_ds_Click(sender As Object, e As EventArgs) Handles daftar_ds.Click
        If daftar_ds.Text = "Daftar" Then
            daftar_ds.Text = "Simpan"
            kd_ds.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_ds from dana_sekolah WHERE kd_ds = '" & kd_ds.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO dana_sekolah (kd_ds,nama_sekolah,alamat_sekolah,daerah_sekolah) VALUES('" & kd_ds.Text & "','" & nama_sekolah.Text & "','" & alamat_sekolah.Text & "','" & daerah_sekolah.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihds()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub batal_ds_Click(sender As Object, e As EventArgs) Handles batal_ds.Click
        Call bersihds()
    End Sub




    'Donasi Panti Asuhan
    Sub bersihpa()
        kd_pa.Text = ""
        nama_panti.Text = ""
        alamat_panti.Text = ""
        daerah_panti.Text = ""
        kd_pa.Focus()
        daftar_pa.Text = "Daftar"
    End Sub

    Private Sub daftar_pa_Click(sender As Object, e As EventArgs) Handles daftar_pa.Click
        If daftar_pa.Text = "Daftar" Then
            daftar_pa.Text = "Simpan"
            kd_pa.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_pa from panti_asuhan WHERE kd_pa = '" & kd_pa.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO panti_asuhan (kd_pa,nama_panti,alamat_panti,daerah_panti) VALUES('" & kd_pa.Text & "','" & nama_panti.Text & "','" & alamat_panti.Text & "','" & daerah_panti.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihpa()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub batal_pa_Click(sender As Object, e As EventArgs) Handles batal_pa.Click
        Call bersihpa()
    End Sub




    'Donasi Yayasan Penyakit
    Sub bersihyp()
        kd_yp.Text = ""
        nama_yys.Text = ""
        alamat_yys.Text = ""
        daerah_yp.Text = ""
        jenis_penyakit.Text = ""
        kd_yp.Focus()
        daftar_yp.Text = "Daftar"
    End Sub

    Private Sub daftar_yp_Click(sender As Object, e As EventArgs) Handles daftar_yp.Click
        If daftar_yp.Text = "Daftar" Then
            daftar_yp.Text = "Simpan"
            kd_yp.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_yp from yayasan_penyakit WHERE kd_yp = '" & kd_yp.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO yayasan_penyakit (kd_yp,nama_yys,alamat_yys,daerah_yp,jenis_penyakit) VALUES('" & kd_yp.Text & "','" & nama_yys.Text & "','" & alamat_yys.Text & "','" & daerah_yp.Text & "','" & jenis_penyakit.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihyp()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub batal_yp_Click(sender As Object, e As EventArgs) Handles batal_yp.Click
        Call bersihyp()
    End Sub

End Class
