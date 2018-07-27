Public Class Pembaruan
    'Back Button
    Private Sub BackHome_Click(sender As Object, e As EventArgs) Handles BackHome.Click
        Dim pnl As New Menu_Staff(Form1)
        pnl.swipe(True)
    End Sub


    Private Sub Pembaruan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Admin
        Call isigridpda() 'menjalankan perintah dari sub isigrid()
        Call OpenDB()
        Call isicombopda()

        'Donatur
        Call isigridpdd() 'menjalankan perintah dari sub isigrid()
        Call OpenDB()
        Call isicombopdd()

        'Relawan
        Call isigridpdr()
        Call OpenDB()
        Call isicombopdr()

        'Donasi Bencana Alam
        Call OpenDB()
        Call isigridpdba()
        Call isicombopdba()

        'Donasi Dana Sekolah
        Call OpenDB()
        Call isigridpdds()
        Call isicombopdds()

        'Donasi Panti Asuhan
        Call OpenDB()
        Call isigridpdpa()
        Call isicombopdpa()

        'Donasi Yayasan Penyakit
        Call OpenDB()
        Call isigridpdyp()
        Call isicombopdyp()
    End Sub



    'Admin
    Sub isigridpda()

        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM admin", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "admin")
        grid_admin.DataSource = (DS.Tables("admin")) 'setting datasource dari datagridview
        grid_admin.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub isicombopda()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_admin.Items.Clear()
        Do While DR.Read
            cb_admin.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Sub bersihadmin()
        id_admin.Text = ""
        pass_admin.Text = ""
        fn_admin.Text = ""
        ln_admin.Text = ""
        jbtn_admin.Text = ""
        cb_gender_admin.Text = ""
        ttl_admin.Text = ""
        contact_admin.Text = ""
        id_admin.Focus()
    End Sub

    Private Sub cb_admin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_admin.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin,pass_admin,fn_admin,ln_admin,jbtn_admin,gender_admin,ttl_admin,contact_admin FROM admin WHERE id_admin = '" & cb_admin.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            id_admin.Text = DR.Item(0)
            pass_admin.Text = DR.Item(1)
            fn_admin.Text = DR.Item(2)
            ln_admin.Text = DR.Item(3)
            jbtn_admin.Text = DR.Item(4)
            cb_gender_admin.Text = DR.Item(5)
            ttl_admin.Text = DR.Item(6)
            contact_admin.Text = DR.Item(7)

            id_admin.Enabled = False
            id_admin.Focus()
        End If
    End Sub

    Private Sub ubah_admin_Click(sender As Object, e As EventArgs) Handles ubah_admin.Click
        Try
            Call OpenDB()
            ubah = "UPDATE admin SET pass_admin='" & pass_admin.Text & "',fn_admin='" & fn_admin.Text & "',ln_admin='" & ln_admin.Text & "',jbtn_admin='" & jbtn_admin.Text & "',gender_admin='" & cb_gender_admin.Text & "',ttl_admin='" & ttl_admin.Text & "',contact_admin='" & contact_admin.Text & "' WHERE id_admin = '" & id_admin.Text & "'"

            CMD = New Odbc.OdbcCommand(ubah, connect)
            CMD.ExecuteNonQuery()
            Call bersihadmin()
            Call isigridpda()
            Call isicombopda()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub hapus_admin_Click(sender As Object, e As EventArgs) Handles hapus_admin.Click
        Try
            Call OpenDB()
            hapus = "DELETE FROM admin WHERE id_admin='" & id_admin.Text & "'"
            CMD = New Odbc.OdbcCommand(hapus, connect)
            CMD.ExecuteNonQuery()
            Call bersihadmin()
            Call isigridpda()
            Call isicombopda()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub batal_admin_Click(sender As Object, e As EventArgs) Handles batal_admin.Click
        Call bersihadmin()
    End Sub






    'Donatur

    Sub isigridpdd()

        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM donatur", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "donatur")
        grid_donatur.DataSource = (DS.Tables("donatur")) 'setting datasource dari datagridview
        grid_donatur.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Sub isicombopdd()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT id_donatur from donatur", connect)
        DR = CMD.ExecuteReader
        cb_donatur.Items.Clear()
        Do While DR.Read
            cb_donatur.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub bersihdonatur()
        id_donatur.Text = ""
        fn_donatur.Text = ""
        ln_donatur.Text = ""
        cb_gender_donatur.Text = ""
        ttl_donatur.Text = ""
        profesi_donatur.Text = ""
        contact_donatur.Text = ""
        id_donatur.Focus()
    End Sub

    Private Sub cb_donatur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_donatur.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_donatur,fn_donatur,ln_donatur,profesi_donatur,gender_donatur,ttl_donatur,contact_donatur FROM donatur WHERE id_donatur = '" & cb_donatur.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            id_donatur.Text = DR.Item(0)
            fn_donatur.Text = DR.Item(1)
            ln_donatur.Text = DR.Item(2)
            profesi_donatur.Text = DR.Item(3)
            cb_gender_donatur.Text = DR.Item(4)
            ttl_donatur.Text = DR.Item(5)
            contact_donatur.Text = DR.Item(6)


            id_donatur.Enabled = False
            id_donatur.Focus()
        End If
    End Sub

    Private Sub ubah_donatur_Click(sender As Object, e As EventArgs) Handles ubah_donatur.Click
        Try
            Call OpenDB()
            ubah = "UPDATE donatur SET fn_donatur='" & fn_donatur.Text & "',ln_donatur='" & ln_donatur.Text & "',profesi_donatur='" & profesi_donatur.Text & "',gender_donatur='" & cb_gender_donatur.Text & "',ttl_donatur='" & Format(ttl_donatur.Value, "yyyy-MM-dd") & "',contact_donatur='" & contact_donatur.Text & "' WHERE id_donatur = '" & id_donatur.Text & "'"

            CMD = New Odbc.OdbcCommand(ubah, connect)
            CMD.ExecuteNonQuery()
            Call bersihdonatur()
            Call isigridpdd()
            Call isicombopdd()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub hapus_donatur_Click(sender As Object, e As EventArgs) Handles hapus_donatur.Click
        Try
            Call OpenDB()
            hapus = "DELETE FROM donatur WHERE id_donatur='" & id_donatur.Text & "'"
            CMD = New Odbc.OdbcCommand(hapus, connect)
            CMD.ExecuteNonQuery()
            Call bersihdonatur()
            Call isigridpdd()
            Call isicombopdd()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub batal_donatur_Click(sender As Object, e As EventArgs) Handles batal_donatur.Click
        Call bersihdonatur()
    End Sub






    'Relawan
    Sub isigridpdr()

        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM relawan", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "relawan")
        grid_relawan.DataSource = (DS.Tables("relawan")) 'setting datasource dari datagridview
        grid_relawan.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub isicombopdr()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_relawan from relawan", connect)
        DR = CMD.ExecuteReader
        cb_relawan.Items.Clear()
        Do While DR.Read
            cb_relawan.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub bersihrelawan()
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
    End Sub

    Private Sub cb_relawan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_relawan.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_relawan,fn_relawan,ln_relawan,gender_relawan,nm_perusahaan,alamat_perusahaan,jenis_perusahaan,ttl_relawan,contact_relawan FROM relawan WHERE id_relawan = '" & cb_relawan.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            id_relawan.Text = DR.Item(0)
            fn_relawan.Text = DR.Item(1)
            ln_relawan.Text = DR.Item(2)
            cb_gender_relawan.Text = DR.Item(3)
            nm_perusahaan.Text = DR.Item(4)
            alamat_perusahaan.Text = DR.Item(5)
            cb_jenis_perusahaan.Text = DR.Item(6)
            ttl_relawan.Text = DR.Item(7)
            contact_relawan.Text = DR.Item(8)
            id_relawan.Focus()

            id_relawan.Enabled = False
            id_relawan.Focus()
        End If
    End Sub

    Private Sub ubah_relawan_Click(sender As Object, e As EventArgs) Handles ubah_relawan.Click
       Try
            Call OpenDB()
            ubah = "UPDATE donatur SET fn_relawan='" & fn_relawan.Text & "',ln_relawan='" & ln_relawan.Text & "',gender_relawan='" & cb_gender_relawan.Text & "',nm_perusahaan='" & nm_perusahaan.Text & "',alamat_perusahaan='" & alamat_perusahaan.Text & "',jenis_perusahaan='" & cb_jenis_perusahaan.Text & "',ttl_relawan='" & Format(ttl_relawan.Value, "yyyy-MM-dd") & "',contact_relawan='" & contact_relawan.Text & "' WHERE id_relawan = '" & id_relawan.Text & "'"

            CMD = New Odbc.OdbcCommand(ubah, connect)
            CMD.ExecuteNonQuery()
            Call bersihrelawan()
            Call isigridpdr()
            Call isicombopdr()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub hapus_relawan_Click(sender As Object, e As EventArgs) Handles hapus_relawan.Click
        Try
            Call OpenDB()
            hapus = "DELETE FROM relawan WHERE id_relawan='" & id_relawan.Text & "'"
            CMD = New Odbc.OdbcCommand(hapus, connect)
            CMD.ExecuteNonQuery()
            Call bersihrelawan()
            Call isigridpdr()
            Call isicombopdr()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub batal_relawan_Click(sender As Object, e As EventArgs) Handles batal_relawan.Click
        Call bersihrelawan()
    End Sub






    'Donasi Bencana Alam
    Sub isigridpdba()
        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM bencana_alam", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "bencana_alam")
        grid_ba.DataSource = (DS.Tables("bencana_alam")) 'setting datasource dari datagridview
        grid_ba.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub isicombopdba()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_ba from bencana_alam", connect)
        DR = CMD.ExecuteReader
        cb_pdba.Items.Clear()
        Do While DR.Read
            cb_pdba.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub bersihba()
        kd_ba.Text = ""
        daerah_ba.Text = ""
        jenis_ba.Text = ""
        kd_ba.Focus()
    End Sub
    Private Sub cb_pdba_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_pdba.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_ba,daerah_ba,jenis_ba FROM bencana_alam WHERE kd_ba = '" & cb_pdba.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            kd_ba.Text = DR.Item(0)
            daerah_ba.Text = DR.Item(1)
            jenis_ba.Text = DR.Item(2)

            kd_ba.Enabled = False
            kd_ba.Focus()
        End If
    End Sub
    Private Sub ubah_pdba_Click(sender As Object, e As EventArgs) Handles ubah_pdba.Click
        Try
            Call OpenDB()
            ubah = "UPDATE bencana_alam SET daerah_ba='" & daerah_ba.Text & "',jenis_ba='" & jenis_ba.Text & "' WHERE kd_ba= '" & kd_ba.Text & "'"

            CMD = New Odbc.OdbcCommand(ubah, connect)
            CMD.ExecuteNonQuery()
            Call bersihba()
            Call isigridpdba()
            Call isicombopdba()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub
    Private Sub hapus_pdba_Click(sender As Object, e As EventArgs) Handles hapus_pdba.Click
        Try
            Call OpenDB()
            hapus = "DELETE FROM bencana_alam WHERE kd_ba='" & kd_ba.Text & "'"
            CMD = New Odbc.OdbcCommand(hapus, connect)
            CMD.ExecuteNonQuery()
            Call bersihba()
            Call isigridpdba()
            Call isicombopdba()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub
    Private Sub batal_pdba_Click(sender As Object, e As EventArgs) Handles batal_pdba.Click
        Call bersihba()
    End Sub







    'Donasi Dana Sekolah

    Sub isigridpdds()

        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM dana_sekolah", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "dana_sekolah")
        grid_ds.DataSource = (DS.Tables("dana_sekolah")) 'setting datasource dari datagridview
        grid_ds.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub isicombopdds()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_ds from dana_sekolah", connect)
        DR = CMD.ExecuteReader
        cb_pdds.Items.Clear()
        Do While DR.Read
            cb_pdds.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub bersihds()
        kd_ds.Text = ""
        nama_sekolah.Text = ""
        alamat_sekolah.Text = ""
        daerah_sekolah.Text = ""
        kd_ds.Focus()
    End Sub

   
    Private Sub cb_pdds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_pdds.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_ds,nama_sekolah,alamat_sekolah,daerah_sekolah FROM dana_sekolah WHERE kd_ds = '" & cb_pdds.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            kd_ds.Text = DR.Item(0)
            nama_sekolah.Text = DR.Item(1)
            alamat_sekolah.Text = DR.Item(2)
            daerah_sekolah.Text = DR.Item(3)

            kd_ds.Enabled = False
            kd_ds.Focus()
        End If
    End Sub

    Private Sub ubah_pdds_Click(sender As Object, e As EventArgs) Handles ubah_pdds.Click
        Try
            Call OpenDB()
            ubah = "UPDATE dana_sekolah SET nama_sekolah='" & nama_sekolah.Text & "',alamat_sekolah='" & alamat_sekolah.Text & "',daerah_sekolah='" & daerah_sekolah.Text & "' WHERE kd_ds = '" & kd_ds.Text & "'"

            CMD = New Odbc.OdbcCommand(ubah, connect)
            CMD.ExecuteNonQuery()
            Call bersihds()
            Call isigridpdds()
            Call isicombopdds()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub hapus_pdds_Click(sender As Object, e As EventArgs) Handles hapus_pdds.Click
        Try
            Call OpenDB()
            hapus = "DELETE FROM bencana_alam WHERE kd_ba='" & kd_ba.Text & "'"
            CMD = New Odbc.OdbcCommand(hapus, connect)
            CMD.ExecuteNonQuery()
            Call bersihba()
            Call isigridpdba()
            Call isicombopdba()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub batal_pdds_Click(sender As Object, e As EventArgs) Handles batal_pdds.Click
        Call bersihds()
    End Sub




    'Donasi Panti Asuhan

    Sub isigridpdpa()
        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM panti_asuhan", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "panti_asuhan")
        grid_pa.DataSource = (DS.Tables("panti_asuhan")) 'setting datasource dari datagridview
        grid_pa.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub isicombopdpa()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_pa from panti_asuhan", connect)
        DR = CMD.ExecuteReader
        cb_pdpa.Items.Clear()
        Do While DR.Read
            cb_pdpa.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub bersihpa()
        kd_pa.Text = ""
        nama_panti.Text = ""
        alamat_panti.Text = ""
        daerah_panti.Text = ""
        kd_pa.Focus()
    End Sub

    Private Sub cb_pdpa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_pdpa.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_pa,nama_panti,alamat_panti,daerah_panti FROM panti_asuhan WHERE kd_pa = '" & cb_pdpa.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            kd_pa.Text = DR.Item(0)
            nama_panti.Text = DR.Item(1)
            alamat_panti.Text = DR.Item(2)
            daerah_panti.Text = DR.Item(3)

            kd_pa.Enabled = False
            kd_pa.Focus()
        End If
    End Sub

    Private Sub ubah_pdpa_Click(sender As Object, e As EventArgs) Handles ubah_pdpa.Click
        Try
            Call OpenDB()
            ubah = "UPDATE panti_asuhan SET nama_panti='" & nama_panti.Text & "',alamat_panti='" & alamat_panti.Text & "',daerah_panti='" & daerah_panti.Text & "' WHERE kd_pa = '" & kd_pa.Text & "'"

            CMD = New Odbc.OdbcCommand(ubah, connect)
            CMD.ExecuteNonQuery()
            Call bersihpa()
            Call isigridpdpa()
            Call isicombopdpa()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub hapus_pdpa_Click(sender As Object, e As EventArgs) Handles hapus_pdpa.Click
        Try
            Call OpenDB()
            hapus = "DELETE FROM dana_sekolah WHERE kd_ds='" & kd_ds.Text & "'"
            CMD = New Odbc.OdbcCommand(hapus, connect)
            CMD.ExecuteNonQuery()
            Call bersihds()
            Call isigridpdds()
            Call isicombopdds()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub batal_pdpa_Click(sender As Object, e As EventArgs) Handles batal_pdpa.Click
        Call bersihpa()
    End Sub





    'Donasi Yayasan Penyakit
    Sub isigridpdyp()

        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM yayasan_penyakit", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "yayasan_penyakit")
        grid_yp.DataSource = (DS.Tables("yayasan_penyakit")) 'setting datasource dari datagridview
        grid_yp.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub isicombopdyp()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_yp from yayasan_penyakit", connect)
        DR = CMD.ExecuteReader
        cb_pdyp.Items.Clear()
        Do While DR.Read
            cb_pdyp.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub bersihyp()
        kd_yp.Text = ""
        nama_yys.Text = ""
        alamat_yys.Text = ""
        daerah_yp.Text = ""
        jenis_penyakit.Text = ""
        kd_yp.Focus()
    End Sub

    Private Sub cb_pdyp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_pdyp.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_yp,nama_yys,alamat_yys,daerah_yp,jenis_penyakit FROM yayasan_penyakit WHERE kd_yp = '" & cb_pdyp.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            kd_yp.Text = DR.Item(0)
            nama_yys.Text = DR.Item(1)
            alamat_yys.Text = DR.Item(2)
            daerah_yp.Text = DR.Item(3)
            jenis_penyakit.Text = DR.Item(4)

            kd_yp.Enabled = False
            kd_yp.Focus()
        End If
    End Sub

    Private Sub ubah_pdyp_Click(sender As Object, e As EventArgs) Handles ubah_pdyp.Click
        Try
            Call OpenDB()
            ubah = "UPDATE yayasan_penyakit SET nama_yys='" & nama_yys.Text & "',alamat_yys='" & alamat_yys.Text & "',daerah_yp='" & daerah_yp.Text & "', jenis_penyakit='" & jenis_penyakit.Text & "' WHERE kd_yp = '" & kd_yp.Text & "'"

            CMD = New Odbc.OdbcCommand(ubah, connect)
            CMD.ExecuteNonQuery()
            Call bersihyp()
            Call isigridpdyp()
            Call isicombopdyp()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub hapus_pdyp_Click(sender As Object, e As EventArgs) Handles hapus_pdyp.Click
        Try
            Call OpenDB()
            hapus = "DELETE FROM yayasan_penyakit WHERE kd_yp='" & kd_yp.Text & "'"
            CMD = New Odbc.OdbcCommand(hapus, connect)
            CMD.ExecuteNonQuery()
            Call bersihyp()
            Call isigridpdyp()
            Call isicombopdyp()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
        End Try
    End Sub

    Private Sub batal_pdyp_Click(sender As Object, e As EventArgs) Handles batal_pdyp.Click
        Call bersihyp()
    End Sub

   
End Class
