<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_Staff
    Inherits BaseUserControl
    Sub New(ByVal owner As Form)
        MyBase.New(owner)

        InitializeComponent()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_Staff))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LogoutButton = New MetroFramework.Controls.MetroButton()
        Me.LaporanButton = New MetroFramework.Controls.MetroButton()
        Me.PembaruanButton = New MetroFramework.Controls.MetroButton()
        Me.PendaftaranButton = New MetroFramework.Controls.MetroButton()
        Me.TransaksiButton = New MetroFramework.Controls.MetroButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Panel3.Controls.Add(Me.LogoutButton)
        Me.Panel3.Controls.Add(Me.LaporanButton)
        Me.Panel3.Controls.Add(Me.PembaruanButton)
        Me.Panel3.Controls.Add(Me.PendaftaranButton)
        Me.Panel3.Controls.Add(Me.TransaksiButton)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Location = New System.Drawing.Point(0, 111)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(251, 372)
        Me.Panel3.TabIndex = 4
        '
        'LogoutButton
        '
        Me.LogoutButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.LogoutButton.BackgroundImage = CType(resources.GetObject("LogoutButton.BackgroundImage"), System.Drawing.Image)
        Me.LogoutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LogoutButton.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.LogoutButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.LogoutButton.Location = New System.Drawing.Point(0, 261)
        Me.LogoutButton.Name = "LogoutButton"
        Me.LogoutButton.Size = New System.Drawing.Size(251, 31)
        Me.LogoutButton.TabIndex = 15
        Me.LogoutButton.Text = "Keluar"
        Me.LogoutButton.UseCustomBackColor = True
        Me.LogoutButton.UseCustomForeColor = True
        Me.LogoutButton.UseSelectable = True
        '
        'LaporanButton
        '
        Me.LaporanButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.LaporanButton.BackgroundImage = CType(resources.GetObject("LaporanButton.BackgroundImage"), System.Drawing.Image)
        Me.LaporanButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LaporanButton.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.LaporanButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.LaporanButton.Location = New System.Drawing.Point(0, 231)
        Me.LaporanButton.Name = "LaporanButton"
        Me.LaporanButton.Size = New System.Drawing.Size(251, 31)
        Me.LaporanButton.TabIndex = 14
        Me.LaporanButton.Text = "Laporan"
        Me.LaporanButton.UseCustomBackColor = True
        Me.LaporanButton.UseCustomForeColor = True
        Me.LaporanButton.UseSelectable = True
        '
        'PembaruanButton
        '
        Me.PembaruanButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.PembaruanButton.BackgroundImage = CType(resources.GetObject("PembaruanButton.BackgroundImage"), System.Drawing.Image)
        Me.PembaruanButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PembaruanButton.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.PembaruanButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.PembaruanButton.Location = New System.Drawing.Point(0, 201)
        Me.PembaruanButton.Name = "PembaruanButton"
        Me.PembaruanButton.Size = New System.Drawing.Size(251, 31)
        Me.PembaruanButton.TabIndex = 13
        Me.PembaruanButton.Text = "Pembaruan"
        Me.PembaruanButton.UseCustomBackColor = True
        Me.PembaruanButton.UseCustomForeColor = True
        Me.PembaruanButton.UseSelectable = True
        '
        'PendaftaranButton
        '
        Me.PendaftaranButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.PendaftaranButton.BackgroundImage = CType(resources.GetObject("PendaftaranButton.BackgroundImage"), System.Drawing.Image)
        Me.PendaftaranButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PendaftaranButton.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.PendaftaranButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.PendaftaranButton.Location = New System.Drawing.Point(0, 171)
        Me.PendaftaranButton.Name = "PendaftaranButton"
        Me.PendaftaranButton.Size = New System.Drawing.Size(251, 31)
        Me.PendaftaranButton.TabIndex = 12
        Me.PendaftaranButton.Text = "Pendaftaran"
        Me.PendaftaranButton.UseCustomBackColor = True
        Me.PendaftaranButton.UseCustomForeColor = True
        Me.PendaftaranButton.UseSelectable = True
        '
        'TransaksiButton
        '
        Me.TransaksiButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TransaksiButton.BackgroundImage = CType(resources.GetObject("TransaksiButton.BackgroundImage"), System.Drawing.Image)
        Me.TransaksiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TransaksiButton.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.TransaksiButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.TransaksiButton.Location = New System.Drawing.Point(0, 141)
        Me.TransaksiButton.Name = "TransaksiButton"
        Me.TransaksiButton.Size = New System.Drawing.Size(251, 31)
        Me.TransaksiButton.TabIndex = 11
        Me.TransaksiButton.Text = "Transaksi"
        Me.TransaksiButton.UseCustomBackColor = True
        Me.TransaksiButton.UseCustomForeColor = True
        Me.TransaksiButton.UseSelectable = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(49, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(151, 119)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 10
        Me.PictureBox3.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(0, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(831, 28)
        Me.Panel2.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(31, 27)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(46, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Menu Staff"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(831, 82)
        Me.Panel1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(363, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 74)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Menu_Staff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Menu_Staff"
        Me.Size = New System.Drawing.Size(831, 483)
        Me.UseCustomBackColor = True
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TransaksiButton As MetroFramework.Controls.MetroButton
    Friend WithEvents PendaftaranButton As MetroFramework.Controls.MetroButton
    Friend WithEvents PembaruanButton As MetroFramework.Controls.MetroButton
    Friend WithEvents LaporanButton As MetroFramework.Controls.MetroButton
    Friend WithEvents LogoutButton As MetroFramework.Controls.MetroButton

End Class
