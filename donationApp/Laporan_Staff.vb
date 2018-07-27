Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Laporan_Staff

    Private Sub BackHome_Click(sender As Object, e As EventArgs) Handles BackHome.Click
        Dim pnl As New Menu_Staff(Form1)
        pnl.swipe(True)
    End Sub

    Private Sub Laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call OpenDB()
        'Penerimaan ///
        'Donasi Penerimaan Bencana Alam
        Call isigridLP_ba()
        DT = New DataTable
        DA.Fill(DT)
        DGLP_ba.DataSource = DT
        DGLP_ba.Refresh()
        connect.Close()
        DA.Dispose()

        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        judul_LPba.Text = ""
        lokasi_LPba.Text = ""


        'Donasi Penerimaan Dana Sekolah
        Call isigridLP_ds()
        DT = New DataTable
        DA.Fill(DT)
        DGLP_ds.DataSource = DT
        DGLP_ds.Refresh()
        connect.Close()
        DA.Dispose()

        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        judul_LPds.Text = ""
        lokasi_LPds.Text = ""


        'Donasi Penerimaan Panti Asuhan
        Call isigridLP_pa()
        DT = New DataTable
        DA.Fill(DT)
        DGLP_pa.DataSource = DT
        DGLP_pa.Refresh()
        connect.Close()
        DA.Dispose()

        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        judul_LPpa.Text = ""
        lokasi_LPpa.Text = ""


        'Donasi Penerimaan Yayasan Penyakit
        Call isigridLP_yp()
        DT = New DataTable
        DA.Fill(DT)
        DGLP_yp.DataSource = DT
        DGLP_yp.Refresh()
        connect.Close()
        DA.Dispose()

        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        judul_LPyp.Text = ""
        lokasi_LPyp.Text = ""
        '///
    End Sub







    'Penerimaan ///
    'Donasi Penerimaan Bencana Alam
    Sub isigridLP_ba()
        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ba", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ba")
        DGLP_ba.DataSource = (DS.Tables("penerimaan_ba")) 'setting datasource dari datagridview
        DGLP_ba.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub filter_ba_TextChanged(sender As Object, e As EventArgs) Handles filter_ba.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ba WHERE kd_ba LIKE '" & filter_ba.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ba")
        DGLP_ba.DataSource = (DS.Tables("penerimaan_ba")) 'setting datasource dari datagridview
        DGLP_ba.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub browse_ba_Click(sender As Object, e As EventArgs) Handles browse_ba.Click
        SaveFileDialog1.FileName = ""
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            lokasi_LPba.Text = SaveFileDialog1.FileName

        End If
    End Sub

    Private Sub cetak_ba_Click(sender As Object, e As EventArgs) Handles cetak_ba.Click
        'untuk paragraph
        Dim paragraph As New Paragraph
        Dim pdffile As New Document(PageSize.A4, 40, 40, 40, 20)
        pdffile.AddTitle(judul_LPba.Text)
        Dim write As PdfWriter = PdfWriter.GetInstance(pdffile, New FileStream(lokasi_LPba.Text, FileMode.Create))
        pdffile.Open()

        'untuk tipe font
        Dim ptitle As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        'untuk insert judul ke pdf
        paragraph = New Paragraph(New Chunk(judul_LPba.Text, ptitle))
        paragraph.Alignment = Element.ALIGN_CENTER
        paragraph.SpacingAfter = 5.0F

        'untuk mengatur dan menambah halaman
        pdffile.Add(paragraph)

        'untuk membuat data ke tabel
        Dim pdftable As New PdfPTable(DGLP_ba.Columns.Count)

        'untuk setting lebar tabel
        pdftable.TotalWidth = 500.0F
        pdftable.LockedWidth = True

        Dim widths(0 To DGLP_ba.Columns.Count - 1) As Single
        For i As Integer = 0 To DGLP_ba.Columns.Count - 1
            widths(i) = 1.0F
        Next

        pdftable.SetWidths(widths)
        pdftable.HorizontalAlignment = 0
        pdftable.SpacingBefore = 5.0F

        'untuk cell pdf
        Dim pdfcell As PdfPCell = New PdfPCell

        'untuk pdf header
        For i As Integer = 0 To DGLP_ba.Columns.Count - 1
            pdfcell = New PdfPCell(New Phrase(New Chunk(DGLP_ba.Columns(i).HeaderText, ptable)))
            'posisi header tabel
            pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            'untuk menambahkan cell ke tabel pdf
            pdftable.AddCell(pdfcell)
        Next
        ' untuk menambahkan data ke pdf
        For i As Integer = 0 To DGLP_ba.Rows.Count - 2
            For j As Integer = 0 To DGLP_ba.Columns.Count - 1
                pdfcell = New PdfPCell(New Phrase(DGLP_ba(j, i).Value.ToString(), ptable))
                pdftable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                pdftable.AddCell(pdfcell)
            Next
        Next
        'untuk menambahkan tabel pdf ke dokumen pdf
        pdffile.Add(pdftable)
        pdffile.Close() 'menutup semua sesi(sessions)

        ' menampilkan pesan jika sudah  tersimpan
        MessageBox.Show("Laporan Berhasil Tersimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub







    'Donasi Penerimaan Dana Sekolah
    Sub isigridLP_ds()
        openDB()
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ds", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ds")
        DGLP_ds.DataSource = (DS.Tables("penerimaan_ds")) 'setting datasource dari datagridview
        DGLP_ds.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub filter_ds_TextChanged(sender As Object, e As EventArgs) Handles filter_ds.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_ds WHERE kd_ds LIKE '" & filter_ds.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_ds")
        DGLP_ds.DataSource = (DS.Tables("penerimaan_ds")) 'setting datasource dari datagridview
        DGLP_ds.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub browse_ds_Click(sender As Object, e As EventArgs) Handles browse_ds.Click
        SaveFileDialog1.FileName = ""
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            lokasi_LPds.Text = SaveFileDialog1.FileName

        End If
    End Sub

    Private Sub cetak_ds_Click(sender As Object, e As EventArgs) Handles cetak_ds.Click
        'untuk paragraph
        Dim paragraph As New Paragraph
        Dim pdffile As New Document(PageSize.A4, 40, 40, 40, 20)
        pdffile.AddTitle(judul_LPds.Text)
        Dim write As PdfWriter = PdfWriter.GetInstance(pdffile, New FileStream(lokasi_LPds.Text, FileMode.Create))
        pdffile.Open()

        'untuk tipe font
        Dim ptitle As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        'untuk insert judul ke pdf
        paragraph = New Paragraph(New Chunk(judul_LPds.Text, ptitle))
        paragraph.Alignment = Element.ALIGN_CENTER
        paragraph.SpacingAfter = 5.0F

        'untuk mengatur dan menambah halaman
        pdffile.Add(paragraph)

        'untuk membuat data ke tabel
        Dim pdftable As New PdfPTable(DGLP_ds.Columns.Count)

        'untuk setting lebar tabel
        pdftable.TotalWidth = 500.0F
        pdftable.LockedWidth = True

        Dim widths(0 To DGLP_ds.Columns.Count - 1) As Single
        For i As Integer = 0 To DGLP_ds.Columns.Count - 1
            widths(i) = 1.0F
        Next

        pdftable.SetWidths(widths)
        pdftable.HorizontalAlignment = 0
        pdftable.SpacingBefore = 5.0F

        'untuk cell pdf
        Dim pdfcell As PdfPCell = New PdfPCell

        'untuk pdf header
        For i As Integer = 0 To DGLP_ds.Columns.Count - 1
            pdfcell = New PdfPCell(New Phrase(New Chunk(DGLP_ds.Columns(i).HeaderText, ptable)))
            'posisi header tabel
            pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            'untuk menambahkan cell ke tabel pdf
            pdftable.AddCell(pdfcell)
        Next
        ' untuk menambahkan data ke pdf
        For i As Integer = 0 To DGLP_ds.Rows.Count - 2
            For j As Integer = 0 To DGLP_ds.Columns.Count - 1
                pdfcell = New PdfPCell(New Phrase(DGLP_ds(j, i).Value.ToString(), ptable))
                pdftable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                pdftable.AddCell(pdfcell)
            Next
        Next
        'untuk menambahkan tabel pdf ke dokumen pdf
        pdffile.Add(pdftable)
        pdffile.Close() 'menutup semua sesi(sessions)

        ' menampilkan pesan jika sudah  tersimpan
        MessageBox.Show("Laporan Berhasil Tersimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub








    'Donasi Penerimaan Panti Asuhan
    Sub isigridLP_pa()
        openDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_pa", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_pa")
        DGLP_pa.DataSource = (DS.Tables("penerimaan_pa")) 'setting datasource dari datagridview
        DGLP_pa.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub filter_pa_TextChanged(sender As Object, e As EventArgs) Handles filter_pa.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_pa WHERE kd_pa LIKE '" & filter_pa.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_pa")
        DGLP_pa.DataSource = (DS.Tables("penerimaan_pa")) 'setting datasource dari datagridview
        DGLP_pa.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub browse_pa_Click(sender As Object, e As EventArgs) Handles browse_pa.Click
        SaveFileDialog1.FileName = ""
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            lokasi_LPds.Text = SaveFileDialog1.FileName

        End If
    End Sub

    Private Sub cetak_pa_Click(sender As Object, e As EventArgs) Handles cetak_pa.Click
        'untuk paragraph
        Dim paragraph As New Paragraph
        Dim pdffile As New Document(PageSize.A4, 40, 40, 40, 20)
        pdffile.AddTitle(judul_LPds.Text)
        Dim write As PdfWriter = PdfWriter.GetInstance(pdffile, New FileStream(lokasi_LPds.Text, FileMode.Create))
        pdffile.Open()

        'untuk tipe font
        Dim ptitle As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        'untuk insert judul ke pdf
        paragraph = New Paragraph(New Chunk(judul_LPds.Text, ptitle))
        paragraph.Alignment = Element.ALIGN_CENTER
        paragraph.SpacingAfter = 5.0F

        'untuk mengatur dan menambah halaman
        pdffile.Add(paragraph)

        'untuk membuat data ke tabel
        Dim pdftable As New PdfPTable(DGLP_pa.Columns.Count)

        'untuk setting lebar tabel
        pdftable.TotalWidth = 500.0F
        pdftable.LockedWidth = True

        Dim widths(0 To DGLP_pa.Columns.Count - 1) As Single
        For i As Integer = 0 To DGLP_pa.Columns.Count - 1
            widths(i) = 1.0F
        Next

        pdftable.SetWidths(widths)
        pdftable.HorizontalAlignment = 0
        pdftable.SpacingBefore = 5.0F

        'untuk cell pdf
        Dim pdfcell As PdfPCell = New PdfPCell

        'untuk pdf header
        For i As Integer = 0 To DGLP_pa.Columns.Count - 1
            pdfcell = New PdfPCell(New Phrase(New Chunk(DGLP_pa.Columns(i).HeaderText, ptable)))
            'posisi header tabel
            pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            'untuk menambahkan cell ke tabel pdf
            pdftable.AddCell(pdfcell)
        Next
        ' untuk menambahkan data ke pdf
        For i As Integer = 0 To DGLP_pa.Rows.Count - 2
            For j As Integer = 0 To DGLP_pa.Columns.Count - 1
                pdfcell = New PdfPCell(New Phrase(DGLP_pa(j, i).Value.ToString(), ptable))
                pdftable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                pdftable.AddCell(pdfcell)
            Next
        Next
        'untuk menambahkan tabel pdf ke dokumen pdf
        pdffile.Add(pdftable)
        pdffile.Close() 'menutup semua sesi(sessions)

        ' menampilkan pesan jika sudah  tersimpan
        MessageBox.Show("Laporan Berhasil Tersimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub







    'Donasi Penerimaan Yayasan Penyakit
    Sub isigridLP_yp()
        openDB()
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_yp", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_yp")
        DGLP_yp.DataSource = (DS.Tables("penerimaan_yp")) 'setting datasource dari datagridview
        DGLP_yp.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub filter_yp_TextChanged(sender As Object, e As EventArgs) Handles filter_yp.TextChanged
        OpenDB() 'memanggil koneksi ke database melalui modul
        DA = New Odbc.OdbcDataAdapter("SELECT * FROM penerimaan_yp WHERE kd_yp LIKE '" & filter_yp.Text & "%'", connect)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "penerimaan_yp")
        DGLP_yp.DataSource = (DS.Tables("penerimaan_yp")) 'setting datasource dari datagridview
        DGLP_yp.Enabled = True 'jadikan datagridview hanya readonly
    End Sub

    Private Sub browse_yp_Click(sender As Object, e As EventArgs) Handles browse_yp.Click
        SaveFileDialog1.FileName = ""
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            lokasi_LPds.Text = SaveFileDialog1.FileName

        End If
    End Sub

    Private Sub cetak_yp_Click(sender As Object, e As EventArgs) Handles cetak_yp.Click
        'untuk paragraph
        Dim paragraph As New Paragraph
        Dim pdffile As New Document(PageSize.A4, 40, 40, 40, 20)
        pdffile.AddTitle(judul_LPds.Text)
        Dim write As PdfWriter = PdfWriter.GetInstance(pdffile, New FileStream(lokasi_LPds.Text, FileMode.Create))
        pdffile.Open()

        'untuk tipe font
        Dim ptitle As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim ptable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        'untuk insert judul ke pdf
        paragraph = New Paragraph(New Chunk(judul_LPds.Text, ptitle))
        paragraph.Alignment = Element.ALIGN_CENTER
        paragraph.SpacingAfter = 5.0F

        'untuk mengatur dan menambah halaman
        pdffile.Add(paragraph)

        'untuk membuat data ke tabel
        Dim pdftable As New PdfPTable(DGLP_yp.Columns.Count)

        'untuk setting lebar tabel
        pdftable.TotalWidth = 500.0F
        pdftable.LockedWidth = True

        Dim widths(0 To DGLP_yp.Columns.Count - 1) As Single
        For i As Integer = 0 To DGLP_yp.Columns.Count - 1
            widths(i) = 1.0F
        Next

        pdftable.SetWidths(widths)
        pdftable.HorizontalAlignment = 0
        pdftable.SpacingBefore = 5.0F

        'untuk cell pdf
        Dim pdfcell As PdfPCell = New PdfPCell

        'untuk pdf header
        For i As Integer = 0 To DGLP_yp.Columns.Count - 1
            pdfcell = New PdfPCell(New Phrase(New Chunk(DGLP_yp.Columns(i).HeaderText, ptable)))
            'posisi header tabel
            pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            'untuk menambahkan cell ke tabel pdf
            pdftable.AddCell(pdfcell)
        Next
        ' untuk menambahkan data ke pdf
        For i As Integer = 0 To DGLP_yp.Rows.Count - 2
            For j As Integer = 0 To DGLP_yp.Columns.Count - 1
                pdfcell = New PdfPCell(New Phrase(DGLP_yp(j, i).Value.ToString(), ptable))
                pdftable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                pdftable.AddCell(pdfcell)
            Next
        Next
        'untuk menambahkan tabel pdf ke dokumen pdf
        pdffile.Add(pdftable)
        pdffile.Close() 'menutup semua sesi(sessions)

        ' menampilkan pesan jika sudah  tersimpan
        MessageBox.Show("Laporan Berhasil Tersimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    '///
End Class
