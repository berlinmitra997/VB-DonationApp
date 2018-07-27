Public Class Transaksi

    Private Sub BackHome_Click(sender As Object, e As EventArgs) Handles BackHome.Click
        Dim pnl As New Menu_Staff(Form1)
        pnl.swipe(True)
    End Sub
    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call OpenDB()

        'Penerimaan ///
        'Donasi Bencana Alam
        Call isicombokdba()
        Call isicomboiddonaturba()
        Call isicombotuba()
        Call isicomboidadminba()

        'Donasi Dana Sekolah
        Call isicombokdba()
        Call isicomboiddonaturba()
        Call isicombotuba()
        Call isicomboidadminba()

        'Donasi Panti Asuhan
        Call isicombokdpa()
        Call isicomboiddonaturpa()
        Call isicombotupa()
        Call isicomboidadminpa()

        'Donasi Yayasan Penyakit
        Call isicombokdyp()
        Call isicomboiddonaturyp()
        Call isicombotuyp()
        Call isicomboidadminyp()
        '///




        'Pengirimian///
        'Bencana Alam
        Call isigridLP_ba()
        Call isicomboidadmin_ba()
        Call bersihpl_ba()
        Call isicomboidrelawan_ba()

        'Dana Sekolah
        Call isigridLP_ds()
        Call isicomboidadmin_ds()
        Call bersihpl_ds()
        Call isicomboidrelawan_ds()

        'Panti Asuhan
        Call isigridLP_pa()
        Call isicomboidadmin_pa()
        Call bersihpl_pa()
        Call isicomboidrelawan_pa()

        'Yayasan Penyakit
        Call isigridLP_yp()
        Call isicomboidadmin_yp()
        Call bersihpl_yp()
        Call isicomboidrelawan_yp()
        '///

    End Sub






    'Penerimaan///
    'Donasi Penerimaan Bencana Alam
    Sub bersihprba()
        kd_penerimaan_ba.Text = ""
        fn_donatur_ba.Text = ""
        ln_donatur_ba.Text = ""
        daerah_ba.Text = ""
        jenis_ba.Text = ""
        nominal_uang_ba.Text = ""
        total_ba.Text = ""
        tgl_penerimaan_ba.Text = ""
        ln_admin_ba.Text = ""
        cb_id_admin_ba.Text = ""
        cb_id_donatur_ba.Text = ""
        cb_tu_ba.Text = ""
        kd_penerimaan_ba.Focus()
        terima_ba.Text = "Terima"
    End Sub
    Sub isicombokdba()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_ba from bencana_alam", connect)
        DR = CMD.ExecuteReader
        cb_id_donatur_ba.Items.Clear()
        Do While DR.Read
            cb_id_donatur_ba.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Sub isicomboiddonaturba()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_donatur from donatur", connect)
        DR = CMD.ExecuteReader
        cb_id_donatur_ba.Items.Clear()
        Do While DR.Read
            cb_id_donatur_ba.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicombotuba()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_tpuang from tipe_uang", connect)
        DR = CMD.ExecuteReader
        cb_tu_ba.Items.Clear()
        Do While DR.Read
            cb_tu_ba.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidadminba()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_ba.Items.Clear()
        Do While DR.Read
            cb_id_admin_ba.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Private Sub terima_ba_Click(sender As Object, e As EventArgs) Handles terima_ba.Click
        If terima_ba.Text = "Terima" Then
            terima_ba.Text = "Simpan"
            kd_penerimaan_ba.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_penerimaan_ba from penerimaan_ba WHERE kd_penerimaan_ba = '" & kd_penerimaan_ba.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO penerimaan_ba (kd_penerimaan_ba,id_donatur,kd_ba,uang_ba,tgl_penerimaan_ba,id_admin) VALUES('" & kd_penerimaan_ba.Text & "','" & cb_id_donatur_ba.Text & "','" & cb_kd_ba.Text & "','" & total_ba.Text & "','" & Format(tgl_penerimaan_ba.Value, "yyyy-MM-dd") & "','" & cb_id_admin_ba.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihprba()
                    Call isicomboiddonaturba()
                    Call isicombokdba()
                    Call isicomboidadminba()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub cb_id_donatur_ba_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_donatur_ba.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT fn_donatur,ln_donatur FROM donatur WHERE id_donatur = '" & cb_id_donatur_ba.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            fn_donatur_ba.Text = DR.Item(0)
            ln_donatur_ba.Text = DR.Item(1)

            fn_donatur_ba.Enabled = False
            ln_donatur_ba.Enabled = False
            fn_donatur_ba.Focus()
        End If
    End Sub

    Private Sub cb_kd_ba_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_kd_ba.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT daerah_ba,jenis_ba FROM bencana_alam WHERE kd_ba = '" & cb_kd_ba.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            daerah_ba.Text = DR.Item(0)
            jenis_ba.Text = DR.Item(1)

            daerah_ba.Enabled = False
            jenis_ba.Enabled = False
            daerah_ba.Focus()
        End If
    End Sub

    Private Sub cb_tu_ba_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_tu_ba.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT nominal_uang FROM tipe_uang WHERE kd_tpuang = '" & cb_tu_ba.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            nominal_uang_ba.Text = DR.Item(0)
            nominal_uang_ba.Text = (3 / 100 * nominal_uang_ba.Text)
            nominal_uang_ba.Enabled = False
            nominal_uang_ba.Focus()
        End If
    End Sub

    Private Sub cb_id_admin_ba_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_ba.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_ba.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_ba.Text = DR.Item(0)

            ln_admin_ba.Enabled = False
            ln_admin_ba.Focus()
        End If
    End Sub

    Private Sub hitung_ba_Click(sender As Object, e As EventArgs) Handles hitung_ba.Click
        total_ba.Text = cb_tu_ba.Text - nominal_uang_ba.Text
    End Sub

    Private Sub batal_ba_Click(sender As Object, e As EventArgs) Handles batal_ba.Click
        Call bersihprba()
    End Sub







    'Donasi Penerimaan Dana Sekolah
    Sub bersihprds()
        kd_penerimaan_ds.Text = ""
        fn_donatur_ds.Text = ""
        ln_donatur_ds.Text = ""
        nama_ds.Text = ""
        daerah_ds.Text = ""
        nominal_uang_ds.Text = ""
        total_ds.Text = ""
        tgl_penerimaan_ds.Text = ""
        ln_admin_ds.Text = ""
        cb_id_admin_ds.Text = ""
        cb_id_donatur_ds.Text = ""
        cb_tu_ds.Text = ""
        kd_penerimaan_ds.Focus()
        terima_ds.Text = "Terima"
    End Sub
    Sub isicombokdds()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_ds from dana_sekolah", connect)
        DR = CMD.ExecuteReader
        cb_id_donatur_ds.Items.Clear()
        Do While DR.Read
            cb_id_donatur_ds.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Sub isicomboiddonaturds()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_donatur from donatur", connect)
        DR = CMD.ExecuteReader
        cb_id_donatur_ds.Items.Clear()
        Do While DR.Read
            cb_id_donatur_ds.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicombotuds()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_tpuang from tipe_uang", connect)
        DR = CMD.ExecuteReader
        cb_tu_ds.Items.Clear()
        Do While DR.Read
            cb_tu_ds.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidadminds()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_ds.Items.Clear()
        Do While DR.Read
            cb_id_admin_ds.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Private Sub terima_ds_Click(sender As Object, e As EventArgs) Handles terima_ds.Click
        If terima_ds.Text = "Terima" Then
            terima_ds.Text = "Simpan"
            kd_penerimaan_ds.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_penerimaan_ds from penerimaan_ds WHERE kd_penerimaan_ds = '" & kd_penerimaan_ds.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO penerimaan_ds (kd_penerimaan_ds,id_donatur,kd_ds,uang_ds,tgl_penerimaan_ds,id_admin) VALUES('" & kd_penerimaan_ds.Text & "','" & cb_id_donatur_ds.Text & "','" & cb_kd_ds.Text & "','" & total_ds.Text & "','" & Format(tgl_penerimaan_ds.Value, "yyyy-MM-dd") & "','" & cb_id_admin_ds.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihprds()
                    Call isicomboiddonaturds()
                    Call isicombokdds()
                    Call isicomboidadminds()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub
    Private Sub cb_id_donatur_ds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_donatur_ds.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT fn_donatur,ln_donatur FROM donatur WHERE id_donatur = '" & cb_id_donatur_ds.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            fn_donatur_ds.Text = DR.Item(0)
            ln_donatur_ds.Text = DR.Item(1)

            fn_donatur_ds.Enabled = False
            ln_donatur_ds.Enabled = False
            fn_donatur_ds.Focus()
        End If
    End Sub

    Private Sub cb_kd_ds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_kd_ds.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT nama_sekolah,daerah_sekolah FROM dana_sekolah WHERE kd_ds = '" & cb_kd_ds.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            nama_ds.Text = DR.Item(0)
            daerah_ds.Text = DR.Item(1)

            nama_ds.Enabled = False
            daerah_ds.Enabled = False
            nama_ds.Focus()
        End If
    End Sub

    Private Sub cb_tu_ds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_tu_ds.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT nominal_uang FROM tipe_uang WHERE kd_tpuang = '" & cb_tu_ds.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            nominal_uang_ds.Text = DR.Item(0)
            nominal_uang_ds.Text = (3 / 100 * nominal_uang_ds.Text)
            nominal_uang_ds.Enabled = False
            nominal_uang_ds.Focus()
        End If
    End Sub

    Private Sub cb_id_admin_ds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_ds.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_ds.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_ds.Text = DR.Item(0)

            ln_admin_ds.Enabled = False
            ln_admin_ds.Focus()
        End If
    End Sub
    Private Sub hitung_ds_Click(sender As Object, e As EventArgs) Handles hitung_ds.Click
        total_ds.Text = cb_tu_ds.Text - nominal_uang_ds.Text
    End Sub

    Private Sub batal_ds_Click(sender As Object, e As EventArgs) Handles batal_ds.Click
        Call bersihprds()
    End Sub

    'Donasi Penerimaan Panti Asuhan
    Sub bersihprpa()
        kd_penerimaan_pa.Text = ""
        fn_donatur_pa.Text = ""
        ln_donatur_pa.Text = ""
        nama_pa.Text = ""
        daerah_pa.Text = ""
        nominal_uang_pa.Text = ""
        total_pa.Text = ""
        tgl_penerimaan_pa.Text = ""
        ln_admin_pa.Text = ""
        cb_id_admin_pa.Text = ""
        cb_id_donatur_pa.Text = ""
        cb_tu_pa.Text = ""
        kd_penerimaan_pa.Focus()
        terima_pa.Text = "Terima"
    End Sub
    Sub isicombokdpa()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_pa from panti_asuhan", connect)
        DR = CMD.ExecuteReader
        cb_id_donatur_pa.Items.Clear()
        Do While DR.Read
            cb_id_donatur_pa.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Sub isicomboiddonaturpa()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_donatur from donatur", connect)
        DR = CMD.ExecuteReader
        cb_id_donatur_pa.Items.Clear()
        Do While DR.Read
            cb_id_donatur_pa.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicombotupa()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_tpuang from tipe_uang", connect)
        DR = CMD.ExecuteReader
        cb_tu_pa.Items.Clear()
        Do While DR.Read
            cb_tu_pa.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidadminpa()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_pa.Items.Clear()
        Do While DR.Read
            cb_id_admin_pa.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Private Sub terima_pa_Click(sender As Object, e As EventArgs) Handles terima_pa.Click
        If terima_pa.Text = "Terima" Then
            terima_pa.Text = "Simpan"
            kd_penerimaan_pa.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_penerimaan_pa from penerimaan_pa WHERE kd_penerimaan_pa = '" & kd_penerimaan_pa.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO penerimaan_pa (kd_penerimaan_pa,id_donatur,kd_pa,uang_pa,tgl_penerimaan_pa,id_admin) VALUES('" & kd_penerimaan_pa.Text & "','" & cb_id_donatur_pa.Text & "','" & cb_kd_pa.Text & "','" & total_pa.Text & "','" & Format(tgl_penerimaan_pa.Value, "yyyy-MM-dd") & "','" & cb_id_admin_pa.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihprpa()
                    Call isicomboiddonaturpa()
                    Call isicombokdpa()
                    Call isicomboidadminpa()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub cb_id_donatur_pa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_donatur_pa.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT fn_donatur,ln_donatur FROM donatur WHERE id_donatur = '" & cb_id_donatur_pa.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            fn_donatur_pa.Text = DR.Item(0)
            ln_donatur_pa.Text = DR.Item(1)

            fn_donatur_pa.Enabled = False
            ln_donatur_pa.Enabled = False
            fn_donatur_pa.Focus()
        End If
    End Sub

    Private Sub cb_kd_pa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_kd_pa.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT nama_sekolah,daerah_sekolah FROM dana_sekolah WHERE kd_pa = '" & cb_kd_pa.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            nama_pa.Text = DR.Item(0)
            daerah_pa.Text = DR.Item(1)

            nama_pa.Enabled = False
            daerah_pa.Enabled = False
            nama_pa.Focus()
        End If
    End Sub

    Private Sub cb_tu_pa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_tu_pa.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT nominal_uang FROM tipe_uang WHERE kd_tpuang = '" & cb_tu_pa.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            nominal_uang_pa.Text = DR.Item(0)
            nominal_uang_pa.Text = (3 / 100 * nominal_uang_pa.Text)
            nominal_uang_pa.Enabled = False
            nominal_uang_pa.Focus()
        End If
    End Sub

    Private Sub cb_id_admin_pa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_pa.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_pa.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_pa.Text = DR.Item(0)

            ln_admin_pa.Enabled = False
            ln_admin_pa.Focus()
        End If
    End Sub

    Private Sub hitung_pa_Click(sender As Object, e As EventArgs) Handles hitung_pa.Click
        total_pa.Text = cb_tu_pa.Text - nominal_uang_pa.Text
    End Sub

    Private Sub batal_pa_Click(sender As Object, e As EventArgs) Handles batal_pa.Click
        Call bersihprpa()
    End Sub



    'Donasi Penerimaan Yayasan Penyakit
    Sub bersihpryp()
        kd_penerimaan_yp.Text = ""
        fn_donatur_yp.Text = ""
        ln_donatur_yp.Text = ""
        nama_yp.Text = ""
        daerah_yp.Text = ""
        nominal_uang_yp.Text = ""
        total_yp.Text = ""
        tgl_penerimaan_yp.Text = ""
        ln_admin_yp.Text = ""
        cb_id_admin_yp.Text = ""
        cb_id_donatur_yp.Text = ""
        cb_tu_yp.Text = ""
        kd_penerimaan_pa.Focus()
        terima_pa.Text = "Terima"
    End Sub
    Sub isicombokdyp()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_yp from yayasan_penyakit", connect)
        DR = CMD.ExecuteReader
        cb_kd_yp.Items.Clear()
        Do While DR.Read
            cb_kd_yp.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboiddonaturyp()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT id_donatur from donatur", connect)
        DR = CMD.ExecuteReader
        cb_id_donatur_yp.Items.Clear()
        Do While DR.Read
            cb_id_donatur_yp.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicombotuyp()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT kd_tpuang from tipe_uang", connect)
        DR = CMD.ExecuteReader
        cb_tu_yp.Items.Clear()
        Do While DR.Read
            cb_tu_yp.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidadminyp()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_yp.Items.Clear()
        Do While DR.Read
            cb_id_admin_yp.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Private Sub terima_yp_Click(sender As Object, e As EventArgs) Handles terima_yp.Click
        If terima_yp.Text = "Terima" Then
            terima_yp.Text = "Simpan"
            kd_penerimaan_yp.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_penerimaan_yp from penerimaan_yp WHERE kd_penerimaan_yp = '" & kd_penerimaan_yp.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO penerimaan_yp (kd_penerimaan_yp,id_donatur,kd_yp,uang_yp,tgl_penerimaan_yp,id_admin) VALUES('" & kd_penerimaan_yp.Text & "','" & cb_id_donatur_yp.Text & "','" & cb_kd_yp.Text & "','" & total_yp.Text & "','" & Format(tgl_penerimaan_yp.Value, "yyyy-MM-dd") & "','" & cb_id_admin_yp.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihpryp()
                    Call isicomboiddonaturyp()
                    Call isicombokdyp()
                    Call isicomboidadminyp()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub cb_id_donatur_yp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_donatur_yp.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT fn_donatur,ln_donatur FROM donatur WHERE id_donatur = '" & cb_id_donatur_yp.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            fn_donatur_yp.Text = DR.Item(0)
            ln_donatur_yp.Text = DR.Item(1)

            fn_donatur_yp.Enabled = False
            ln_donatur_yp.Enabled = False
            fn_donatur_yp.Focus()
        End If
    End Sub

    Private Sub cb_kd_yp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_kd_yp.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT nama_yys,daerah_yp,jenis_penyakit FROM yayasan_penyakit WHERE kd_yp = '" & cb_kd_yp.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            nama_yp.Text = DR.Item(0)
            daerah_yp.Text = DR.Item(1)
            jenis_penyakit.Text = DR.Item(2)

            nama_yp.Enabled = False
            daerah_yp.Enabled = False
            jenis_penyakit.Enabled = False
            nama_yp.Focus()
        End If
    End Sub

    Private Sub cb_tu_yp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_tu_yp.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT nominal_uang FROM tipe_uang WHERE kd_tpuang = '" & cb_tu_yp.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            nominal_uang_yp.Text = DR.Item(0)
            nominal_uang_yp.Text = (3 / 100 * nominal_uang_yp.Text)
            nominal_uang_yp.Enabled = False
            nominal_uang_yp.Focus()
        End If
    End Sub

    Private Sub cb_id_admin_yp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_yp.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_yp.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_yp.Text = DR.Item(0)

            ln_admin_yp.Enabled = False
            ln_admin_yp.Focus()
        End If
    End Sub

    Private Sub hitung_yp_Click(sender As Object, e As EventArgs) Handles hitung_yp.Click
        total_yp.Text = cb_tu_yp.Text - nominal_uang_yp.Text
    End Sub

    Private Sub batal_yp_Click(sender As Object, e As EventArgs) Handles batal_yp.Click
        Call bersihpryp()
    End Sub
    '///





    'Pengiriman ///
    'Donasi Pengiriman Bencana Alam
    Sub isigridLP_ba()
        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ba", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ba")
        DGLP_ba.DataSource = (DS.Tables("penerimaan_ba")) 'setting datasource dari datagridview
        DGLP_ba.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub bersihpl_ba()
        kd_pengeluaran_ba.Text = ""
        saring_ba.Text = ""
        td_ba.Text = ""
        tgl_pengeluaran_ba.Text = ""
        TT_ba.Text = ""
        cb_id_admin_pba.Text = ""
        cb_id_relawan_ba.Text = ""
        nm_perusahaan_ba.Text = ""
        kd_pengeluaran_ba.Focus()
        kirim_ba.Text = "Kirim"
    End Sub
    Sub isicomboidadmin_ba()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_pba.Items.Clear()
        Do While DR.Read
            cb_id_admin_pba.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidrelawan_ba()
        Call openDB()
        CMD = New Odbc.OdbcCommand("SELECT id_relawan from relawan", connect)
        DR = CMD.ExecuteReader
        cb_id_relawan_ba.Items.Clear()
        Do While DR.Read
            cb_id_relawan_ba.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Private Sub hitung_tdba_Click(sender As Object, e As EventArgs) Handles hitung_tdba.Click
        Dim total_ba As Integer = 0
        For i As Integer = 0 To DGLP_ba.RowCount - 1
            If DGLP_ba.Rows(i).Cells(4).Value Then
                total_ba += DGLP_ba.Rows(i).Cells(4).Value
            End If
        Next
        If total_ba = 0 Then
            MessageBox.Show("No Records Found")
        End If
        td_ba.Text = total_ba
    End Sub

    Private Sub saring_ba_TextChanged(sender As Object, e As EventArgs) Handles saring_ba.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ba WHERE kd_ba LIKE '" & saring_ba.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ba")
        DGLP_ba.DataSource = (DS.Tables("penerimaan_ba")) 'setting datasource dari datagridview
        DGLP_ba.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub kirim_ba_Click(sender As Object, e As EventArgs) Handles kirim_ba.Click
        If kirim_ba.Text = "Kirim" Then
            kirim_ba.Text = "Simpan"
            kd_pengeluaran_ba.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_pengeluaran_ba from pengeluaran_ba WHERE kd_pengeluaran_ba = '" & kd_pengeluaran_ba.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO pengeluaran_ba (kd_pengeluaran_ba,td_ba,tgl_pengeluaran_ba,tipe_transaksi,id_admin,id_relawan,nm_perusahaan) VALUES('" & kd_pengeluaran_ba.Text & "','" & td_ba.Text & "','" & Format(tgl_pengeluaran_ba.Value, "yyyy-MM-dd") & "','" & TT_ba.Text & "','" & cb_id_admin_pba.Text & "','" & cb_id_relawan_ba.Text & "','" & nm_perusahaan_ba.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihpl_ba()
                    Call isicomboidadmin_ba()
                    Call isicomboidrelawan_ba()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub cb_id_admin_pba_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_pba.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_ba.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_pba.Text = DR.Item(0)

            ln_admin_pba.Enabled = False
            ln_admin_pba.Focus()
        End If
    End Sub

    Private Sub cb_id_relawan_ba_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_relawan_ba.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_relawan,nm_perusahaan FROM relawan WHERE id_relawan = '" & cb_id_relawan_ba.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_relawan_ba.Text = DR.Item(0)
            nm_perusahaan_ba.Text = DR.Item(1)

            ln_relawan_ba.Enabled = False
            nm_perusahaan_ba.Enabled = False
            ln_relawan_ba.Focus()
        End If
    End Sub

    Private Sub batal_pba_Click(sender As Object, e As EventArgs) Handles batal_pba.Click
        Call bersihpl_ba()
    End Sub





    'Donasi Pengiriman Dana Sekolah
    Sub isigridLP_ds()
        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ds", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ds")
        DGLP_ds.DataSource = (DS.Tables("penerimaan_ds")) 'setting datasource dari datagridview
        DGLP_ds.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub bersihpl_ds()
        kd_pengeluaran_ds.Text = ""
        saring_ds.Text = ""
        td_ds.Text = ""
        tgl_pengeluaran_ds.Text = ""
        TT_ds.Text = ""
        cb_id_admin_pds.Text = ""
        cb_id_relawan_ds.Text = ""
        nm_perusahaan_ds.Text = ""
        kd_pengeluaran_ds.Focus()
        kirim_ds.Text = "Kirim"
    End Sub
    Sub isicomboidadmin_ds()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_pds.Items.Clear()
        Do While DR.Read
            cb_id_admin_pds.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidrelawan_ds()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_relawan from relawan", connect)
        DR = CMD.ExecuteReader
        cb_id_relawan_ds.Items.Clear()
        Do While DR.Read
            cb_id_relawan_ds.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Private Sub hitung_tdds_Click(sender As Object, e As EventArgs) Handles hitung_tdds.Click
        Dim total_ds As Integer = 0
        For i As Integer = 0 To DGLP_ds.RowCount - 1
            If DGLP_ds.Rows(i).Cells(4).Value Then
                total_ds += DGLP_ds.Rows(i).Cells(4).Value
            End If
        Next
        If total_ds = 0 Then
            MessageBox.Show("No Records Found")
        End If
        td_ds.Text = total_ds
    End Sub

    Private Sub saring_ds_TextChanged(sender As Object, e As EventArgs) Handles saring_ds.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ds WHERE kd_ds LIKE '" & saring_ds.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ds")
        DGLP_ds.DataSource = (DS.Tables("penerimaan_ds")) 'setting datasource dari datagridview
        DGLP_ds.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub kirim_ds_Click(sender As Object, e As EventArgs) Handles kirim_ds.Click
        If kirim_ds.Text = "Kirim" Then
            kirim_ds.Text = "Simpan"
            kd_pengeluaran_ds.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_pengeluaran_ds from pengeluaran_ds WHERE kd_pengeluaran_ds = '" & kd_pengeluaran_ds.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO pengeluaran_ds (kd_pengeluaran_ds,td_ds,tgl_pengeluaran_ds,tipe_transaksi,id_admin,id_relawan,nm_perusahaan) VALUES('" & kd_pengeluaran_ds.Text & "','" & td_ds.Text & "','" & Format(tgl_pengeluaran_ds.Value, "yyyy-MM-dd") & "','" & TT_ds.Text & "','" & cb_id_admin_pds.Text & "','" & cb_id_relawan_ds.Text & "','" & nm_perusahaan_ds.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihpl_ds()
                    Call isicomboidadmin_ds()
                    Call isicomboidrelawan_ds()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub cb_id_admin_pds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_pds.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_ds.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_pds.Text = DR.Item(0)

            ln_admin_pds.Enabled = False
            ln_admin_pds.Focus()
        End If
    End Sub

    Private Sub cb_id_relawan_ds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_relawan_ds.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_relawan,nm_perusahaan FROM relawan WHERE id_relawan = '" & cb_id_relawan_ds.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_relawan_ds.Text = DR.Item(0)
            nm_perusahaan_ds.Text = DR.Item(1)

            ln_relawan_ds.Enabled = False
            nm_perusahaan_ds.Enabled = False
            ln_relawan_ds.Focus()
        End If
    End Sub

    Private Sub batal_pds_Click(sender As Object, e As EventArgs) Handles batal_pds.Click
        Call bersihpl_ds()
    End Sub




    'Donasi Pengiriman Panti Asuhan
    Sub isigridLP_pa()
        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_pa", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_pa")
        DGLP_pa.DataSource = (DS.Tables("penerimaan_pa")) 'setting datasource dari datagridview
        DGLP_pa.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub bersihpl_pa()
        kd_pengeluaran_pa.Text = ""
        saring_pa.Text = ""
        td_pa.Text = ""
        tgl_pengeluaran_pa.Text = ""
        TT_pa.Text = ""
        cb_id_admin_ppa.Text = ""
        cb_id_relawan_pa.Text = ""
        nm_perusahaan_pa.Text = ""
        kd_pengeluaran_pa.Focus()
        kirim_pa.Text = "Kirim"
    End Sub
    Sub isicomboidadmin_pa()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_ppa.Items.Clear()
        Do While DR.Read
            cb_id_admin_ppa.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidrelawan_pa()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_relawan from relawan", connect)
        DR = CMD.ExecuteReader
        cb_id_relawan_pa.Items.Clear()
        Do While DR.Read
            cb_id_relawan_pa.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Private Sub hitung_tdpa_Click(sender As Object, e As EventArgs) Handles hitung_tdpa.Click
        Dim total_pa As Integer = 0
        For i As Integer = 0 To DGLP_pa.RowCount - 1
            If DGLP_pa.Rows(i).Cells(4).Value Then
                total_pa += DGLP_pa.Rows(i).Cells(4).Value
            End If
        Next
        If total_pa = 0 Then
            MessageBox.Show("No Records Found")
        End If
        td_pa.Text = total_pa
    End Sub

    Private Sub saring_pa_TextChanged(sender As Object, e As EventArgs) Handles saring_pa.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_pa WHERE kd_pa LIKE '" & saring_pa.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_pa")
        DGLP_pa.DataSource = (DS.Tables("penerimaan_pa")) 'setting datasource dari datagridview
        DGLP_pa.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub kirim_pa_Click(sender As Object, e As EventArgs) Handles kirim_pa.Click
        If kirim_pa.Text = "Kirim" Then
            kirim_pa.Text = "Simpan"
            kd_pengeluaran_pa.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_pengeluaran_pa from pengeluaran_pa WHERE kd_pengeluaran_pa = '" & kd_pengeluaran_pa.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO pengeluaran_pa (kd_pengeluaran_pa,td_pa,tgl_pengeluaran_pa,tipe_transaksi,id_admin,id_relawan,nm_perusahaan) VALUES('" & kd_pengeluaran_pa.Text & "','" & td_pa.Text & "','" & Format(tgl_pengeluaran_pa.Value, "yyyy-MM-dd") & "','" & TT_pa.Text & "','" & cb_id_admin_ppa.Text & "','" & cb_id_relawan_pa.Text & "','" & nm_perusahaan_pa.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihpl_pa()
                    Call isicomboidadmin_pa()
                    Call isicomboidrelawan_pa()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub cb_id_admin_ppa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_ppa.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_pa.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_ppa.Text = DR.Item(0)

            ln_admin_ppa.Enabled = False
            ln_admin_ppa.Focus()
        End If
    End Sub

    Private Sub cb_id_relawan_pa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_relawan_pa.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_relawan,nm_perusahaan FROM relawan WHERE id_relawan = '" & cb_id_relawan_pa.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_relawan_pa.Text = DR.Item(0)
            nm_perusahaan_pa.Text = DR.Item(1)

            ln_relawan_pa.Enabled = False
            nm_perusahaan_pa.Enabled = False
            ln_relawan_pa.Focus()
        End If
    End Sub

    Private Sub batal_ppa_Click(sender As Object, e As EventArgs) Handles batal_ppa.Click
        Call bersihpl_pa()
    End Sub




    'Donasi Pengiriman Yayasan Penyakit
    Sub isigridLP_yp()
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_yp", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_yp")
        DGLP_yp.DataSource = (DS.Tables("penerimaan_yp")) 'setting datasource dari datagridview
        DGLP_yp.Enabled = True 'jadikan datagridview hanya readonly
    End Sub
    Sub bersihpl_yp()
        kd_pengeluaran_yp.Text = ""
        saring_yp.Text = ""
        td_yp.Text = ""
        tgl_pengeluaran_yp.Text = ""
        TT_yp.Text = ""
        cb_id_admin_pyp.Text = ""
        cb_id_relawan_yp.Text = ""
        nm_perusahaan_yp.Text = ""
        kd_pengeluaran_yp.Focus()
        kirim_yp.Text = "Kirim"
    End Sub
    Sub isicomboidadmin_yp()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_admin from admin", connect)
        DR = CMD.ExecuteReader
        cb_id_admin_pyp.Items.Clear()
        Do While DR.Read
            cb_id_admin_pyp.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub
    Sub isicomboidrelawan_yp()
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT id_relawan from relawan", connect)
        DR = CMD.ExecuteReader
        cb_id_relawan_yp.Items.Clear()
        Do While DR.Read
            cb_id_relawan_yp.Items.Add(DR.Item(0))
        Loop
        CMD.Dispose()
        DR.Close()
        connect.Close()
    End Sub

    Private Sub hitung_tdyp_Click(sender As Object, e As EventArgs) Handles hitung_tdyp.Click
        Dim total_yp As Integer = 0
        For i As Integer = 0 To DGLP_yp.RowCount - 1
            If DGLP_yp.Rows(i).Cells(4).Value Then
                total_yp += DGLP_yp.Rows(i).Cells(4).Value
            End If
        Next
        If total_yp = 0 Then
            MessageBox.Show("No Records Found")
        End If
        td_yp.Text = total_yp
    End Sub

    Private Sub saring_yp_TextChanged(sender As Object, e As EventArgs) Handles saring_yp.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_yp WHERE kd_yp LIKE '" & saring_yp.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_yp")
        DGLP_yp.DataSource = (DS.Tables("penerimaan_yp")) 'setting datasource dari datagridview
        DGLP_yp.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub kirim_yp_Click(sender As Object, e As EventArgs) Handles kirim_yp.Click
        If kirim_yp.Text = "Kirim" Then
            kirim_yp.Text = "Simpan"
            kd_pengeluaran_yp.Focus()
        Else
            Try
                Call OpenDB()
                CMD = New Odbc.OdbcCommand("SELECT kd_pengeluaran_yp from pengeluaran_yp WHERE kd_pengeluaran_yp = '" & kd_pengeluaran_yp.Text & "'", connect)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    MsgBox("Maaf, Data dengan ID tersebut telah ada !", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call OpenDB()
                    simpan = "INSERT INTO pengeluaran_yp (kd_pengeluaran_yp,td_yp,tgl_pengeluaran_yp,tipe_transaksi,id_admin,id_relawan,nm_perusahaan) VALUES('" & kd_pengeluaran_yp.Text & "','" & td_yp.Text & "','" & Format(tgl_pengeluaran_yp.Value, "yyyy-MM-dd") & "','" & TT_yp.Text & "','" & cb_id_admin_pyp.Text & "','" & cb_id_relawan_yp.Text & "','" & nm_perusahaan_yp.Text & "')"

                    CMD = New Odbc.OdbcCommand(simpan, connect)
                    CMD.ExecuteNonQuery()
                    Call bersihpl_yp()
                    Call isicomboidadmin_yp()
                    Call isicomboidrelawan_yp()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub cb_id_admin_pyp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_admin_pyp.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_admin FROM admin WHERE id_admin = '" & cb_id_admin_pyp.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_admin_pyp.Text = DR.Item(0)

            ln_admin_pyp.Enabled = False
            ln_admin_pyp.Focus()
        End If
    End Sub

    Private Sub cb_id_relawan_yp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_id_relawan_yp.SelectedIndexChanged
        Call OpenDB()
        CMD = New Odbc.OdbcCommand("SELECT ln_relawan,nm_perusahaan FROM relawan WHERE id_relawan = '" & cb_id_relawan_yp.Text & "'", connect)

        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            ln_relawan_yp.Text = DR.Item(0)
            nm_perusahaan_yp.Text = DR.Item(1)

            ln_relawan_yp.Enabled = False
            nm_perusahaan_yp.Enabled = False
            ln_relawan_yp.Focus()
        End If
    End Sub

    Private Sub batal_pyp_Click(sender As Object, e As EventArgs) Handles batal_pyp.Click
        Call bersihpl_yp()
    End Sub

    Private Sub MetroTabPage3_Click(sender As Object, e As EventArgs) Handles MetroTabPage3.Click

    End Sub
End Class
