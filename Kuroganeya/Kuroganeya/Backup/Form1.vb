Imports GrapeCity.Win.Input

Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim dsItem1, dsItem2, dsItem3, DsCMB, WK_DsList1 As New DataSet
    Dim DtView1, DtView5, DtView12, WK_DtView1 As DataView
    Dim Line_No, x, i, j, r, WK_int As Integer
    Dim strSQL, Err_F, WK_str, WK_str2, ans As String

    Friend WithEvents Furigana As New ImeHandler

    Dim cmbbox(99, 2) As ComboBox
    Dim edit(99, 2) As GrapeCity.Win.Input.Edit
    Dim num(99, 2) As GrapeCity.Win.Input.Number
    Dim btn(99, 2) As Button
    Dim label(99, 1) As label

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.Furigana = Me.Edit2.Ime

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Mask
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit6 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit7 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Edit8 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Date2 As GrapeCity.Win.Input.Date
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Date3 As GrapeCity.Win.Input.Date
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Mask1 = New GrapeCity.Win.Input.Mask
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pos = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Edit2 = New GrapeCity.Win.Input.Edit
        Me.Edit3 = New GrapeCity.Win.Input.Edit
        Me.Edit4 = New GrapeCity.Win.Input.Edit
        Me.Edit5 = New GrapeCity.Win.Input.Edit
        Me.Edit6 = New GrapeCity.Win.Input.Edit
        Me.Edit7 = New GrapeCity.Win.Input.Edit
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Button3 = New System.Windows.Forms.Button
        Me.Edit8 = New GrapeCity.Win.Input.Edit
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Date2 = New GrapeCity.Win.Input.Date
        Me.Label21 = New System.Windows.Forms.Label
        Me.Date3 = New GrapeCity.Win.Input.Date
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "保証番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "お客様名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "カナ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 24)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "郵便番号"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Mask1
        '
        Me.Mask1.Format = New GrapeCity.Win.Input.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Mask1.Location = New System.Drawing.Point(116, 192)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(96, 24)
        Me.Mask1.TabIndex = 8
        Me.Mask1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Mask1.Value = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 24)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "住所1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 24)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "住所2"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 24)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "電話番号①"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(292, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 24)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "電話番号②"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(580, 144)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(56, 24)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "男"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(464, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 24)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "性別"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(636, 144)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(56, 24)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "女"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(692, 144)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "不明"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.pos)
        Me.Panel1.Location = New System.Drawing.Point(12, 344)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 200)
        Me.Panel1.TabIndex = 15
        '
        'pos
        '
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(0, 0)
        Me.pos.TabIndex = 0
        Me.pos.Text = "Label18"
        '
        'Edit1
        '
        Me.Edit1.Format = "9"
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.Location = New System.Drawing.Point(116, 112)
        Me.Edit1.MaxLength = 9
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(96, 24)
        Me.Edit1.TabIndex = 1
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit2
        '
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit2.LengthAsByte = True
        Me.Edit2.Location = New System.Drawing.Point(116, 144)
        Me.Edit2.MaxLength = 50
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(348, 24)
        Me.Edit2.TabIndex = 3
        Me.Edit2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit3
        '
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.Edit3.LengthAsByte = True
        Me.Edit3.Location = New System.Drawing.Point(116, 168)
        Me.Edit3.MaxLength = 30
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(348, 24)
        Me.Edit3.TabIndex = 7
        Me.Edit3.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit4
        '
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit4.LengthAsByte = True
        Me.Edit4.Location = New System.Drawing.Point(116, 216)
        Me.Edit4.MaxLength = 60
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit4.Size = New System.Drawing.Size(456, 24)
        Me.Edit4.TabIndex = 9
        Me.Edit4.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit5
        '
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit5.LengthAsByte = True
        Me.Edit5.Location = New System.Drawing.Point(116, 240)
        Me.Edit5.MaxLength = 60
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(456, 24)
        Me.Edit5.TabIndex = 10
        Me.Edit5.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit6
        '
        Me.Edit6.Format = "9"
        Me.Edit6.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit6.Location = New System.Drawing.Point(116, 264)
        Me.Edit6.MaxLength = 11
        Me.Edit6.Name = "Edit6"
        Me.Edit6.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit6.Size = New System.Drawing.Size(176, 24)
        Me.Edit6.TabIndex = 11
        Me.Edit6.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit7
        '
        Me.Edit7.Format = "9"
        Me.Edit7.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit7.Location = New System.Drawing.Point(396, 264)
        Me.Edit7.MaxLength = 11
        Me.Edit7.Name = "Edit7"
        Me.Edit7.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit7.Size = New System.Drawing.Size(176, 24)
        Me.Edit7.TabIndex = 12
        Me.Edit7.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(12, 320)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 24)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "メーカー"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(132, 320)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 24)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "商品名"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(272, 320)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 24)
        Me.Label12.TabIndex = 101
        Me.Label12.Text = "型式"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(836, 320)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 24)
        Me.Label13.TabIndex = 102
        Me.Label13.Text = "備考"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(412, 320)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 24)
        Me.Label14.TabIndex = 103
        Me.Label14.Text = "購入金額"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1052, 68)
        Me.PictureBox1.TabIndex = 104
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(740, 552)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 28)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "登　録"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(908, 552)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(68, 28)
        Me.Button9.TabIndex = 18
        Me.Button9.Text = "戻　る"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(292, 288)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 24)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "店舗"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DarkBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(712, 320)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 24)
        Me.Label16.TabIndex = 109
        Me.Label16.Text = "保証料額"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(792, 320)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 24)
        Me.Label17.TabIndex = 110
        Me.Label17.Text = "期間"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(220, 112)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(52, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "検索"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 560)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(712, 20)
        Me.msg.TabIndex = 1348
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(12, 288)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 24)
        Me.Label18.TabIndex = 1349
        Me.Label18.Text = "購入日"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date1.Location = New System.Drawing.Point(116, 288)
        Me.Date1.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2030, 12, 31, 23, 59, 59, 0))
        Me.Date1.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(120, 24)
        Me.Date1.TabIndex = 13
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date1.Value = Nothing
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(824, 552)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 28)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "クリア"
        '
        'Edit8
        '
        Me.Edit8.Format = "9"
        Me.Edit8.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit8.Location = New System.Drawing.Point(396, 288)
        Me.Edit8.MaxLength = 4
        Me.Edit8.Name = "Edit8"
        Me.Edit8.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit8.Size = New System.Drawing.Size(52, 24)
        Me.Edit8.TabIndex = 14
        Me.Edit8.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit8.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(448, 292)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(436, 20)
        Me.Label19.TabIndex = 1351
        Me.Label19.Text = "Label19"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(280, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(136, 20)
        Me.Label20.TabIndex = 1352
        Me.Label20.Text = "Label20"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label20.Visible = False
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM", "", "")
        Me.Date2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date2.Location = New System.Drawing.Point(116, 72)
        Me.Date2.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2030, 12, 31, 23, 59, 59, 0))
        Me.Date2.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(80, 24)
        Me.Date2.TabIndex = 0
        Me.Date2.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date2.Value = Nothing
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(12, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 24)
        Me.Label21.TabIndex = 1354
        Me.Label21.Text = "計上年月"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date3
        '
        Me.Date3.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date3.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date3.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date3.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date3.Location = New System.Drawing.Point(200, 72)
        Me.Date3.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2030, 12, 31, 23, 59, 59, 0))
        Me.Date3.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date3.Name = "Date3"
        Me.Date3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date3.Size = New System.Drawing.Size(80, 24)
        Me.Date3.TabIndex = 1355
        Me.Date3.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date3.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date3.Value = Nothing
        Me.Date3.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.Location = New System.Drawing.Point(788, 260)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(36, 24)
        Me.CheckBox1.TabIndex = 1356
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(692, 260)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 1357
        Me.Label52.Text = "削除ﾌﾗｸﾞ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(612, 320)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 24)
        Me.Label22.TabIndex = 1358
        Me.Label22.Text = "商品ｶﾃｺﾞﾘｰ"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(492, 320)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 24)
        Me.Label23.TabIndex = 1359
        Me.Label23.Text = "商品ｺｰﾄﾞ"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1050, 587)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Date3)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Edit8)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Edit7)
        Me.Controls.Add(Me.Edit6)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Mask1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入データ入力"
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '************************************************
    '** 起動時
    '************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clr()
        Date3.Text = Now.Date() : Date2.Text = Mid(Date3.Text, 1, 7)
    End Sub

    Sub clr()
        dsItem1.Clear()
        dsItem2.Clear()
        dsItem3.Clear()
        Edit1.Text = Nothing : Edit1.BackColor = System.Drawing.SystemColors.Window : Label20.Text = Nothing
        Edit2.Text = Nothing : Edit2.BackColor = System.Drawing.SystemColors.Window
        Edit3.Text = Nothing
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        Mask1.Value = Nothing
        Edit4.Text = Nothing
        Edit5.Text = Nothing
        Edit6.Text = Nothing
        Edit7.Text = Nothing
        Edit8.Text = Nothing : Label19.Text = Nothing
        Date1.Text = Nothing : Date1.BackColor = System.Drawing.SystemColors.Window

        Panel1.Controls.Clear()
        Line_No = -1
        Call ADD_LINE()
        Button1.Text = "登　録"
        Button1.Enabled = True
        Button2.Enabled = True  '検索
        Label52.Visible = False : CheckBox1.Visible = False '削除フラグ
        msg.Text = Nothing
        Edit1.Focus()
    End Sub

    '行追加
    Sub ADD_LINE()
        If Line_No = 98 Then Exit Sub

        Line_No = Line_No + 1

        'メーカー
        SqlCmd1 = New SqlClient.SqlCommand("SELECT MKR_CODE, MKR_NAME FROM M_maker WHERE (delt_flg = 0) ORDER BY MKR_NAME", cnsqlclient)
        SqlCmd1.CommandType = CommandType.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(dsItem1, "MKR" & Line_No)
        DB_CLOSE()

        x = 0
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(0, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(120, 24)
        cmbbox(Line_No, x).MaxDropDownItems = 18
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100 + 1
        cmbbox(Line_No, x).DataSource = dsItem1
        cmbbox(Line_No, x).DisplayMember = "MKR" & Line_No & ".MKR_NAME"
        cmbbox(Line_No, x).ValueMember = "MKR" & Line_No & ".MKR_CODE"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing
        AddHandler cmbbox(Line_No, x).Leave, AddressOf cmbbox0_Leave

        '商品名
        x = 0
        edit(Line_No, x) = New GrapeCity.Win.Input.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).MaxLength = 50
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Hiragana
        edit(Line_No, x).Location = New System.Drawing.Point(120, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Size = New System.Drawing.Size(140, 24)
        edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, x).TabIndex = Line_No * 100 + 2
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))
        AddHandler edit(Line_No, x).Leave, AddressOf edit0_Leave

        '型式
        x = 1
        edit(Line_No, x) = New GrapeCity.Win.Input.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "AaK#@"
        edit(Line_No, x).MaxLength = 48
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
        edit(Line_No, x).Location = New System.Drawing.Point(260, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Size = New System.Drawing.Size(140, 24)
        edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, x).TabIndex = Line_No * 100 + 3
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))
        AddHandler edit(Line_No, x).Leave, AddressOf edit1_Leave

        '購入金額
        x = 0
        num(Line_No, x) = New GrapeCity.Win.Input.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(400, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).Size = New System.Drawing.Size(80, 24)
        num(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        num(Line_No, x).TabIndex = Line_No * 100 + 4
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        AddHandler num(Line_No, x).Leave, AddressOf num0_Leave

        '商品
        SqlCmd1 = New SqlClient.SqlCommand("SELECT CLS_CODE, CLS_CODE_NAME FROM V_cls_022 ORDER BY DSP_SEQ, CLS_CODE_NAME", cnsqlclient)
        SqlCmd1.CommandType = CommandType.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(dsItem2, "cls022" & Line_No)
        DB_CLOSE()

        x = 1
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(480, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(120, 24)
        cmbbox(Line_No, x).MaxDropDownItems = 18
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100 + 5
        cmbbox(Line_No, x).DataSource = dsItem2
        cmbbox(Line_No, x).DisplayMember = "cls022" & Line_No & ".CLS_CODE_NAME"
        cmbbox(Line_No, x).ValueMember = "cls022" & Line_No & ".CLS_CODE"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing
        AddHandler cmbbox(Line_No, x).Leave, AddressOf cmbbox1_Leave

        '商品ｶﾃｺﾞﾘｰ
        SqlCmd1 = New SqlClient.SqlCommand("SELECT * FROM M_category", cnsqlclient)
        SqlCmd1.CommandType = CommandType.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(dsItem3, "CAT" & Line_No)
        DB_CLOSE()

        x = 2
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(600, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(100, 24)
        cmbbox(Line_No, x).MaxDropDownItems = 18
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100 + 6
        cmbbox(Line_No, x).DataSource = dsItem3
        cmbbox(Line_No, x).DisplayMember = "CAT" & Line_No & ".CAT_NAME"
        cmbbox(Line_No, x).ValueMember = "CAT" & Line_No & ".CAT_CODE"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing
        AddHandler cmbbox(Line_No, x).Leave, AddressOf cmbbox2_Leave

        '保証料額
        x = 1
        num(Line_No, x) = New GrapeCity.Win.Input.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(700, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).Size = New System.Drawing.Size(80, 24)
        num(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        num(Line_No, x).TabIndex = Line_No * 100 + 7
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        AddHandler num(Line_No, x).Leave, AddressOf num1_Leave

        '保証期間
        x = 2
        num(Line_No, x) = New GrapeCity.Win.Input.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.NumberFormat("#0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(780, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).Size = New System.Drawing.Size(44, 24)
        num(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        num(Line_No, x).MaxValue = New Decimal(New Integer() {10, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        num(Line_No, x).TabIndex = Line_No * 100 + 8
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        AddHandler num(Line_No, x).Leave, AddressOf num2_Leave

        '備考
        x = 2
        edit(Line_No, x) = New GrapeCity.Win.Input.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(824, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Size = New System.Drawing.Size(120, 24)
        edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        edit(Line_No, x).MaxLength = 100
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, x).TabIndex = Line_No * 100 + 9
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))

        '行No
        x = 0
        label(Line_No, x) = New Label
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))

        '複ボタン
        x = 0
        btn(Line_No, x) = New Button
        btn(Line_No, x).Location = New Drawing.Point(944, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "複"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf c_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

        '削ボタン
        x = 1
        btn(Line_No, x) = New Button
        btn(Line_No, x).Location = New Drawing.Point(969, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "削"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(0, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf d_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

    End Sub

    '行
    Sub SET_LINE()

        Line_No = Line_No + 1

        'メーカー
        SqlCmd1 = New SqlClient.SqlCommand("SELECT MKR_CODE, MKR_NAME FROM M_maker WHERE (delt_flg = 0) ORDER BY MKR_NAME", cnsqlclient)
        SqlCmd1.CommandType = CommandType.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(dsItem1, "MKR" & Line_No)
        DB_CLOSE()

        x = 0
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(0, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(120, 24)
        cmbbox(Line_No, x).MaxDropDownItems = 18
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100 + 1
        cmbbox(Line_No, x).DataSource = dsItem1
        cmbbox(Line_No, x).DisplayMember = "MKR" & Line_No & ".MKR_NAME"
        cmbbox(Line_No, x).ValueMember = "MKR" & Line_No & ".MKR_CODE"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing
        If Not IsDBNull(WK_DtView1(i)("MKR_CODE")) Then cmbbox(Line_No, x).SelectedValue = WK_DtView1(i)("MKR_CODE") Else cmbbox(Line_No, x).SelectedValue = ""
        AddHandler cmbbox(Line_No, x).Leave, AddressOf cmbbox0_Leave

        '商品名
        x = 0
        edit(Line_No, x) = New GrapeCity.Win.Input.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).MaxLength = 50
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Hiragana
        edit(Line_No, x).Location = New System.Drawing.Point(120, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Size = New System.Drawing.Size(140, 24)
        edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, x).TabIndex = Line_No * 100 + 2
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))
        If Not IsDBNull(WK_DtView1(i)("CAT_NAME")) Then edit(Line_No, x).Text = WK_DtView1(i)("CAT_NAME") Else edit(Line_No, x).Text = Nothing
        AddHandler edit(Line_No, x).Leave, AddressOf edit0_Leave

        '型式
        x = 1
        edit(Line_No, x) = New GrapeCity.Win.Input.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "AaK#@"
        edit(Line_No, x).MaxLength = 48
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
        edit(Line_No, x).Location = New System.Drawing.Point(260, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Size = New System.Drawing.Size(140, 24)
        edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, x).TabIndex = Line_No * 100 + 3
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        If Not IsDBNull(WK_DtView1(i)("MODEL")) Then edit(Line_No, x).Text = WK_DtView1(i)("MODEL") Else edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))
        AddHandler edit(Line_No, x).Leave, AddressOf edit1_Leave

        '購入金額
        x = 0
        num(Line_No, x) = New GrapeCity.Win.Input.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(400, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).Size = New System.Drawing.Size(80, 24)
        num(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        num(Line_No, x).TabIndex = Line_No * 100 + 4
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        If Not IsDBNull(WK_DtView1(i)("PRICE")) Then num(Line_No, x).Value = WK_DtView1(i)("PRICE") Else num(Line_No, x).Value = 0
        AddHandler num(Line_No, x).Leave, AddressOf num0_Leave

        '商品
        SqlCmd1 = New SqlClient.SqlCommand("SELECT CLS_CODE, CLS_CODE_NAME FROM V_cls_022 ORDER BY DSP_SEQ, CLS_CODE_NAME", cnsqlclient)
        SqlCmd1.CommandType = CommandType.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(dsItem2, "cls022" & Line_No)
        DB_CLOSE()

        x = 1
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(480, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(120, 24)
        cmbbox(Line_No, x).MaxDropDownItems = 18
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100 + 5
        cmbbox(Line_No, x).DataSource = dsItem2
        cmbbox(Line_No, x).DisplayMember = "cls022" & Line_No & ".CLS_CODE_NAME"
        cmbbox(Line_No, x).ValueMember = "cls022" & Line_No & ".CLS_CODE"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing
        If Not IsDBNull(WK_DtView1(i)("CAT_CODE")) Then cmbbox(Line_No, x).SelectedValue = WK_DtView1(i)("CAT_CODE") Else cmbbox(Line_No, x).SelectedValue = ""
        AddHandler cmbbox(Line_No, x).Leave, AddressOf cmbbox1_Leave

        '商品ｶﾃｺﾞﾘｰ
        SqlCmd1 = New SqlClient.SqlCommand("SELECT * FROM M_category", cnsqlclient)
        SqlCmd1.CommandType = CommandType.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(dsItem3, "CAT" & Line_No)
        DB_CLOSE()

        x = 2
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(600, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(100, 24)
        cmbbox(Line_No, x).MaxDropDownItems = 18
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100 + 6
        cmbbox(Line_No, x).DataSource = dsItem3
        cmbbox(Line_No, x).DisplayMember = "CAT" & Line_No & ".CAT_NAME"
        cmbbox(Line_No, x).ValueMember = "CAT" & Line_No & ".CAT_CODE"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing
        If Not IsDBNull(WK_DtView1(i)("bunrui")) Then cmbbox(Line_No, x).SelectedValue = WK_DtView1(i)("bunrui") Else cmbbox(Line_No, x).SelectedValue = ""
        AddHandler cmbbox(Line_No, x).Leave, AddressOf cmbbox2_Leave

        '保証料額
        x = 1
        num(Line_No, x) = New GrapeCity.Win.Input.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(700, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).Size = New System.Drawing.Size(80, 24)
        num(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        num(Line_No, x).TabIndex = Line_No * 100 + 7
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        If Not IsDBNull(WK_DtView1(i)("WRN_PRICE")) Then num(Line_No, x).Value = WK_DtView1(i)("WRN_PRICE") Else num(Line_No, x).Value = 0
        AddHandler num(Line_No, x).Leave, AddressOf num1_Leave

        '保証期間
        x = 2
        num(Line_No, x) = New GrapeCity.Win.Input.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.NumberFormat("#0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(780, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).Size = New System.Drawing.Size(44, 24)
        num(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        num(Line_No, x).MaxValue = New Decimal(New Integer() {10, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        num(Line_No, x).TabIndex = Line_No * 100 + 8
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        If Not IsDBNull(WK_DtView1(i)("WRN_PRD")) Then num(Line_No, x).Value = WK_DtView1(i)("WRN_PRD") Else num(Line_No, x).Value = 0
        AddHandler num(Line_No, x).Leave, AddressOf num2_Leave

        '備考
        x = 2
        edit(Line_No, x) = New GrapeCity.Win.Input.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(824, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Size = New System.Drawing.Size(120, 24)
        edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
        edit(Line_No, x).MaxLength = 100
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, x).TabIndex = Line_No * 100 + 9
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        If Not IsDBNull(WK_DtView1(i)("biko")) Then edit(Line_No, x).Text = WK_DtView1(i)("biko") Else edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))

        '行No
        x = 0
        label(Line_No, x) = New Label
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))
        label(Line_No, x).Text = Mid(WK_DtView1(i)("WRN_NO"), 10, 2)

        '複ボタン
        x = 0
        btn(Line_No, x) = New Button
        btn(Line_No, x).Location = New Drawing.Point(944, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "複"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf c_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

        '削ボタン
        x = 1
        btn(Line_No, x) = New Button
        btn(Line_No, x).Location = New Drawing.Point(969, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "削"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(0, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf d_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

    End Sub

    '行コピークリック時
    Private Sub c_Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button
        btn = DirectCast(sender, Button)

        Call ADD_LINE()

        If cmbbox(btn.Tag, 0).SelectedValue <> Nothing Then
            cmbbox(Line_No, 0).SelectedValue = cmbbox(btn.Tag, 0).SelectedValue
        End If
        If cmbbox(btn.Tag, 1).SelectedValue <> Nothing Then
            cmbbox(Line_No, 1).SelectedValue = cmbbox(btn.Tag, 1).SelectedValue
        End If
        If cmbbox(btn.Tag, 2).SelectedValue <> Nothing Then
            cmbbox(Line_No, 2).SelectedValue = cmbbox(btn.Tag, 2).SelectedValue
        End If

        edit(Line_No, 0).Text = edit(btn.Tag, 0).Text
        edit(Line_No, 1).Text = edit(btn.Tag, 1).Text
        edit(Line_No, 2).Text = edit(btn.Tag, 2).Text

        num(Line_No, 0).Value = num(btn.Tag, 0).Value
        num(Line_No, 1).Value = num(btn.Tag, 1).Value
        num(Line_No, 2).Value = num(btn.Tag, 2).Value

    End Sub

    '行キャンセルクリック時
    Private Sub d_Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button
        btn = DirectCast(sender, Button)

        cmbbox(btn.Tag, 0).Text = Nothing : cmbbox(btn.Tag, 0).SelectedValue = ""
        cmbbox(btn.Tag, 1).Text = Nothing : cmbbox(btn.Tag, 1).SelectedValue = ""
        cmbbox(btn.Tag, 2).Text = Nothing : cmbbox(btn.Tag, 2).SelectedValue = ""
        edit(btn.Tag, 0).Text = Nothing
        edit(btn.Tag, 1).Text = Nothing
        edit(btn.Tag, 2).Text = Nothing
        num(btn.Tag, 0).Value = 0
        num(btn.Tag, 1).Value = 0
        num(btn.Tag, 2).Value = 0
    End Sub

    '************************************************
    '** 項目チェック
    '************************************************
    Sub F_chk()
        Err_F = "0"

        Call chk_Date2()        '計上年月
        If msg.Text <> Nothing Then Err_F = "1" : Date2.Focus() : Exit Sub

        Call chk_Edit1()        '保証番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit1.Focus() : Exit Sub

        Call chk_Edit2()        'お客様名
        If msg.Text <> Nothing Then Err_F = "1" : Edit2.Focus() : Exit Sub

        chk_Edit3()             'カナ
        If msg.Text <> Nothing Then Err_F = "1" : Edit3.Focus() : Exit Sub

        Call chk_RadioButton1() '性別

        Call chk_Edit4()        '住所1
        If msg.Text <> Nothing Then Err_F = "1" : Edit4.Focus() : Exit Sub

        Call chk_Edit5()        '住所2
        If msg.Text <> Nothing Then Err_F = "1" : Edit5.Focus() : Exit Sub

        Call chk_Date1()        '購入日
        If msg.Text <> Nothing Then Err_F = "1" : Date1.Focus() : Exit Sub

        Call chk_Edit8()        '店舗
        If msg.Text <> Nothing Then Err_F = "1" : Edit8.Focus() : Exit Sub

        j = 0
        For i = 0 To Line_No
            If cmbbox(i, 0).Text <> Nothing Then    'メーカーあり
                j += 1
                Call chk_cmbbox0(i)  'メーカー
                If msg.Text <> Nothing Then Err_F = "1" : cmbbox(i, 0).Focus() : Exit Sub

                Call chk_edit0(i)   '商品名
                If msg.Text <> Nothing Then Err_F = "1" : edit(i, 0).Focus() : Exit Sub

                Call chk_Edit1(i)   '型式
                If msg.Text <> Nothing Then Err_F = "1" : edit(i, 1).Focus() : Exit Sub

                Call chk_num0(i)    '購入金額
                If msg.Text <> Nothing Then Err_F = "1" : num(i, 0).Focus() : Exit Sub

                Call chk_cmbbox1(i)  '商品ｺｰﾄﾞ
                If msg.Text <> Nothing Then Err_F = "1" : cmbbox(i, 1).Focus() : Exit Sub

                Call chk_cmbbox2(i)  '商品ｶﾃｺﾞﾘｰ
                If msg.Text <> Nothing Then Err_F = "1" : cmbbox(i, 2).Focus() : Exit Sub

                Call chk_num1(i)    '保証料
                If msg.Text <> Nothing Then Err_F = "1" : num(i, 1).Focus() : Exit Sub

                Call chk_num2(i)    '期間
                If msg.Text <> Nothing Then Err_F = "1" : num(i, 2).Focus() : Exit Sub

            End If
        Next
        If j = 0 Then
            msg.Text = "商品の入力が1件もありません。"
            Err_F = "1" : cmbbox(0, 0).Focus() : Exit Sub
        End If
    End Sub
    Sub chk_Date2()         '計上年月
        msg.Text = Nothing

        If Date2.Number = 0 Then
            msg.Text = "計上年月の入力がありません。"
            Date2.BackColor = System.Drawing.Color.Red : Exit Sub
            'Else
            '    If Date2.Text > Now.Date Then
            '        msg.Text = "未来日付の購入日は入力できません。"
            '        Date2.BackColor = System.Drawing.Color.Red : Exit Sub
            '    End If
        End If
        Date2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_Edit1()         '保証番号
        msg.Text = Nothing
        Edit1.Text = Trim(Edit1.Text)

        If Edit1.Text = Nothing Then
            msg.Text = "保証番号の入力がありません。"
            Edit1.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Len(Edit1.Text) <> 8 And Len(Edit1.Text) <> 9 Then
                msg.Text = "保証番号は8桁か9桁です。"
                Edit1.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT WRN_DATA.*, SHOP.SHOP_NAME"
                strSQL += " FROM WRN_DATA INNER JOIN"
                strSQL += " SHOP ON WRN_DATA.SHOP_CODE = SHOP.SHOP_CODE"
                strSQL += " WHERE (WRN_DATA.WRN_NO  Like '" & Edit1.Text & "%')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                r = DaList1.Fill(WK_DsList1, "WRN_DATA")
                DB_CLOSE()
                If Label20.Text = Nothing Then  '登録モード
                Else                            '更新モード
                    If Label20.Text <> Edit1.Text Then
                        If r <> 0 Then
                            msg.Text = "既に登録済の保証番号です。"
                            Edit1.BackColor = System.Drawing.Color.Red : Exit Sub
                        End If
                    End If
                End If
            End If
        End If
        Edit1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_Edit2()         'お客様名
        msg.Text = Nothing
        Edit2.Text = Trim(Edit2.Text)

        If Edit2.Text = Nothing Then
            msg.Text = "お客様名の入力がありません。"
            Edit2.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_Edit3()         'カナ
        msg.Text = Nothing
        Edit3.Text = Trim(StrConv(Edit3.Text, VbStrConv.Narrow))

        If Edit3.Text = Nothing Then
        Else
            If Len(Edit3.Text) <> lenb(Edit3.Text) Then
                msg.Text = "カナに全角が含まれています。"
                Edit3.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Edit3.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_RadioButton1()  '性別
        msg.Text = Nothing
        If RadioButton1.Checked = False _
            And RadioButton2.Checked = False _
            And RadioButton3.Checked = False Then
            RadioButton3.Checked = True
        End If
    End Sub
    Sub chk_Edit4()         '住所1
        msg.Text = Nothing
        Edit4.Text = Trim(StrConv(Edit4.Text, VbStrConv.Wide))

        If Edit4.Text = Nothing Then
            'msg.Text = "住所1の入力がありません。"
            'Edit4.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            Dim s As String = Edit4.Text
            If Fint_GetLenB(s) <> s.Length * 2 Then
                msg.Text = "住所1に半角が含まれています。"
                Edit4.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Edit4.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_Edit5()         '住所2
        msg.Text = Nothing
        Edit5.Text = Trim(StrConv(Edit5.Text, VbStrConv.Wide))

        If Edit5.Text = Nothing Then
            'msg.Text = "住所2の入力がありません。"
            'Edit5.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            Dim s As String = Edit5.Text
            If Fint_GetLenB(s) <> s.Length * 2 Then
                msg.Text = "住所2に半角が含まれています。"
                Edit5.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Edit5.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Public Shared Function Fint_GetLenB(ByVal vstr_String As String) As Integer
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(vstr_String)
    End Function
    Sub chk_Date1()         '購入日
        msg.Text = Nothing

        If Date1.Number = 0 Then
            msg.Text = "購入日の入力がありません。"
            Date1.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Date1.Text > Now.Date Then
                msg.Text = "未来日付の購入日は入力できません。"
                Date1.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Date1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_Edit8()         '店舗
        msg.Text = Nothing
        Edit8.Text = Trim(Edit8.Text)
        Label19.Text = Nothing

        If Edit8.Text = Nothing Then
            msg.Text = "店舗の入力がありません。"
            Edit8.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT SHOP_NAME FROM SHOP WHERE (SHOP_CODE = N'" & Edit8.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(WK_DsList1, "SHOP")
            DB_CLOSE()
            If r = 0 Then
                msg.Text = "該当の店舗がありません。"
                Edit8.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                WK_DtView1 = New DataView(WK_DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)
                Label19.Text = WK_DtView1(0)("SHOP_NAME")
            End If

        End If
        Edit8.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_cmbbox0(ByVal Line As Integer)  'メーカー
        msg.Text = Nothing
        cmbbox(Line, 0).Text = Trim(cmbbox(Line, 0).Text)

        If cmbbox(Line, 0).Text <> Nothing Then
            WK_DsList1.Clear()
            strSQL = "SELECT MKR_NAME FROM M_maker WHERE (MKR_NAME = '" & cmbbox(Line, 0).Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(WK_DsList1, "M_maker")
            DB_CLOSE()
            If r = 0 Then
                msg.Text = "該当のメーカーがありません。"
                cmbbox(Line, 0).BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        cmbbox(Line, 0).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_cmbbox1(ByVal Line As Integer)  '商品ｺｰﾄﾞ
        msg.Text = Nothing

        If cmbbox(Line, 0).Text <> Nothing Then
            If cmbbox(Line, 1).Text = Nothing Then
                msg.Text = "商品ｺｰﾄﾞの入力がありません。"
                cmbbox(Line, 1).BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT CLS_CODE_NAME"
                strSQL += " FROM V_cls_022"
                strSQL += " WHERE (CLS_CODE_NAME = '" & cmbbox(Line, 1).Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                r = DaList1.Fill(WK_DsList1, "cls022")
                DB_CLOSE()
                If r = 0 Then
                    msg.Text = "該当の商品ｺｰﾄﾞがありません。"
                    cmbbox(Line, 1).BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
        End If
        cmbbox(Line, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_cmbbox2(ByVal Line As Integer)  '商品ｶﾃｺﾞﾘｰ
        msg.Text = Nothing
        cmbbox(Line, 0).Text = Trim(cmbbox(Line, 0).Text)
        cmbbox(Line, 1).Text = Trim(cmbbox(Line, 1).Text)

        If cmbbox(Line, 0).Text <> Nothing Then
            If cmbbox(Line, 2).Text = Nothing Then
                msg.Text = "商品ｶﾃｺﾞﾘｰの入力がありません。"
                cmbbox(Line, 2).BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT *"
                strSQL += " FROM M_category"
                strSQL += " WHERE (CAT_NAME = '" & cmbbox(Line, 2).Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                r = DaList1.Fill(WK_DsList1, "M_category")
                DB_CLOSE()
                If r = 0 Then
                    msg.Text = "該当の商品ｶﾃｺﾞﾘｰがありません。"
                    cmbbox(Line, 2).BackColor = System.Drawing.Color.Red : Exit Sub
                Else
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M_category"), "", "", DataViewRowState.CurrentRows)
                    num(Line, 1).Value = WK_DtView1(0)("WRN_PRICE")
                    num(Line, 2).Value = WK_DtView1(0)("WRN_YEAR")
                End If
            End If
        End If
        cmbbox(Line, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_edit0(ByVal Line As Integer) '商品名
        msg.Text = Nothing
        cmbbox(Line, 0).Text = Trim(cmbbox(Line, 0).Text)
        edit(Line, 0).Text = Trim(edit(Line, 0).Text)

        If cmbbox(Line, 0).Text <> Nothing Then
            If edit(Line, 0).Text = Nothing Then
                msg.Text = "商品名入力がありません。"
                edit(Line, 0).BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        edit(Line, 0).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_edit1(ByVal Line As Integer) '型式
        msg.Text = Nothing
        cmbbox(Line, 0).Text = Trim(cmbbox(Line, 0).Text)
        edit(Line, 1).Text = Trim(edit(Line, 1).Text)

        If cmbbox(Line, 0).Text <> Nothing Then
            If edit(Line, 1).Text = Nothing Then
                msg.Text = "型式の入力がありません。"
                edit(Line, 1).BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        edit(Line, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_num0(ByVal Line As Integer) '購入金額
        msg.Text = Nothing
        cmbbox(Line, 0).Text = Trim(cmbbox(Line, 0).Text)

        If cmbbox(Line, 0).Text <> Nothing Then
            If num(Line, 0).Value = 0 Then
                msg.Text = "購入金額の入力がありません。"
                num(Line, 0).BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        num(Line, 0).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_num1(ByVal Line As Integer) '保証料額
        msg.Text = Nothing
        cmbbox(Line, 0).Text = Trim(cmbbox(Line, 0).Text)

        If cmbbox(Line, 0).Text <> Nothing Then
            If num(Line, 1).Value = 0 Then
                msg.Text = "保証料額の入力がありません。"
                num(Line, 1).BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        num(Line, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub chk_num2(ByVal Line As Integer) '保証期間
        msg.Text = Nothing
        cmbbox(Line, 0).Text = Trim(cmbbox(Line, 0).Text)

        If cmbbox(Line, 0).Text <> Nothing Then
            If num(Line, 2).Value = 0 Then
                msg.Text = "保証期間の入力がありません。"
                num(Line, 2).BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        num(Line, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub

    '************************************************
    '** LostFocus
    '************************************************
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        Call chk_Edit1() '保証番号
        If msg.Text = Nothing Then
            If Label20.Text = Nothing Then
                WK_DsList1.Clear()
                strSQL = "SELECT WRN_DATA.*, SHOP.SHOP_NAME"
                strSQL += " FROM WRN_DATA INNER JOIN"
                strSQL += " SHOP ON WRN_DATA.SHOP_CODE = SHOP.SHOP_CODE"
                strSQL += " WHERE (WRN_DATA.WRN_NO  Like '" & Edit1.Text.PadRight(9, " ") & "%')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN()
                r = DaList1.Fill(WK_DsList1, "WRN_DATA")
                DB_CLOSE()
                If r = 0 Then    '登録モード
                    Button1.Text = "登　録"
                    Button2.Enabled = True
                    Label52.Visible = False : CheckBox1.Visible = False '削除フラグ
                Else            '更新モード
                    ans = MsgBox("登録済みデータです。修正可能にしますか？", MsgBoxStyle.OKCancel, "確認")
                    If ans = "1" Then
                        Button1.Enabled = True
                        Button2.Enabled = False
                    Else
                        Button1.Enabled = False
                        Button2.Enabled = True
                    End If
                    Button1.Text = "更　新"
                    Label52.Visible = True : CheckBox1.Visible = True '削除フラグ
                    dsItem1.Clear() : dsItem2.Clear() : dsItem3.Clear()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)
                    For i = 0 To WK_DtView1.Count - 1
                        If i = 0 Then
                            Label20.Text = Edit1.Text
                            Date3.Text = WK_DtView1(i)("close_date") : Date2.Text = Mid(Date3.Text, 1, 7)
                            If Not IsDBNull(WK_DtView1(i)("CUST_NAME")) Then Edit2.Text = WK_DtView1(i)("CUST_NAME") Else Edit2.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("CUST_NAME_KANA")) Then Edit3.Text = WK_DtView1(i)("CUST_NAME_KANA") Else Edit3.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("SEX")) Then
                                If WK_DtView1(i)("SEX") = "1" Then
                                    RadioButton1.Checked = True
                                Else
                                    RadioButton2.Checked = True
                                End If
                            Else
                                RadioButton3.Checked = True
                            End If
                            Mask1.Value = WK_DtView1(i)("ZIP1") & WK_DtView1(i)("ZIP2")
                            If Not IsDBNull(WK_DtView1(i)("ADRS1")) Then Edit4.Text = WK_DtView1(i)("ADRS1") Else Edit4.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("ADRS2")) Then Edit5.Text = WK_DtView1(i)("ADRS2") Else Edit5.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("TEL_NO")) Then Edit6.Text = WK_DtView1(i)("TEL_NO") Else Edit6.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("CNT_NO")) Then Edit7.Text = WK_DtView1(i)("CNT_NO") Else Edit7.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("WRN_DATE")) Then Date1.Text = WK_DtView1(i)("WRN_DATE") Else Date1.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("SHOP_CODE")) Then Edit8.Text = WK_DtView1(i)("SHOP_CODE") Else Edit8.Text = Nothing
                            If Not IsDBNull(WK_DtView1(i)("SHOP_NAME")) Then Label19.Text = WK_DtView1(i)("SHOP_NAME") Else Label19.Text = Nothing
                            If WK_DtView1(i)("delt_flg") = "1" Then
                                CheckBox1.Checked = True
                            Else
                                CheckBox1.Checked = False
                            End If
                            Line_No = -1
                            Panel1.Controls.Clear()
                        End If
                        Call SET_LINE()
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub Edit1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Edit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Edit1_LostFocus(sender, e)
            Edit2.Focus()
        End If
    End Sub
    Private Sub Date2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.LostFocus
        Call chk_Date2()            '計上年月
    End Sub
    Private Sub Edit2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit2.LostFocus
        Call chk_Edit2()            'お客様名
    End Sub
    Private Sub Edit3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.LostFocus
        Call chk_Edit3()            'カナ
    End Sub
    Private Sub Edit4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit4.LostFocus
        Call chk_Edit4()            '住所1
    End Sub
    Private Sub Edit5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit5.LostFocus
        Call chk_Edit5()            '住所2
    End Sub
    Private Sub Date1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.LostFocus
        Call chk_Date1()            '購入日
    End Sub
    Private Sub Edit8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit8.LostFocus
        Call chk_Edit8()            '店舗
    End Sub
    Private Sub cmbbox0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As ComboBox
        cmb = DirectCast(sender, ComboBox)
        Call chk_cmbbox0(cmb.Tag)   'メーカー
    End Sub
    Private Sub cmbbox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As ComboBox
        cmb = DirectCast(sender, ComboBox)
        Call chk_cmbbox1(cmb.Tag)   '商品ｺｰﾄﾞ
    End Sub
    Private Sub cmbbox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As ComboBox
        cmb = DirectCast(sender, ComboBox)
        Call chk_cmbbox2(cmb.Tag)   '商品ｶﾃｺﾞﾘｰ
    End Sub
    Private Sub edit0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim edt As GrapeCity.Win.Input.Edit
        edt = DirectCast(sender, GrapeCity.Win.Input.Edit)
        Call chk_edit0(edt.Tag)     '商品名
    End Sub
    Private Sub edit1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim edt As GrapeCity.Win.Input.Edit
        edt = DirectCast(sender, GrapeCity.Win.Input.Edit)
        Call chk_Edit1(edt.Tag)     '型式
    End Sub
    Private Sub num0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim numbox As GrapeCity.Win.Input.Number
        numbox = DirectCast(sender, GrapeCity.Win.Input.Number)
        Call chk_num0(numbox.Tag)   '購入金額
    End Sub
    Private Sub num1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim numbox As GrapeCity.Win.Input.Number
        numbox = DirectCast(sender, GrapeCity.Win.Input.Number)
        Call chk_num1(numbox.Tag)   '保証料額
    End Sub
    Private Sub num2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim numbox As GrapeCity.Win.Input.Number
        numbox = DirectCast(sender, GrapeCity.Win.Input.Number)
        Call chk_num2(numbox.Tag)   '保証期間
    End Sub

    '************************************************
    '** 検索
    '************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_RTN = "0"

        Dim Form1_2 As New Form1_2
        Form1_2.ShowDialog()

        If P_RTN = "1" Then
            Edit1.Text = P_PRAM1
            Edit1_LostFocus(sender, e)
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '************************************************
    '** 登録
    '************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk() '** 項目チェック
        If Err_F = "0" Then

            For i = 0 To Line_No
                If label(i, 0).Text <> Nothing Then    '行Noあり
                    If cmbbox(i, 0).Text <> Nothing Then    'メーカーあり
                        strSQL = "UPDATE WRN_DATA"
                        strSQL += " SET WRN_DATE = CONVERT(DATETIME, '" & Date1.Text & "', 102)"
                        If Edit1.Text <> Label20.Text Then
                            strSQL += ", WRN_NO = '" & Edit1.Text.PadRight(9, " ") & label(i, 0).Text & "'"
                        End If
                        strSQL += ", SHOP_CODE = '" & Edit8.Text & "'"
                        strSQL += ", MODEL = '" & edit(i, 1).Text & "'"
                        strSQL += ", CAT_CODE = '" & cmbbox(i, 1).SelectedValue & "'"
                        strSQL += ", CAT_NAME = '" & edit(i, 0).Text & "'"
                        strSQL += ", bunrui = '" & cmbbox(i, 2).SelectedValue & "'"
                        strSQL += ", MKR_CODE = '" & cmbbox(i, 0).SelectedValue & "'"
                        strSQL += ", MKR_NAME = '" & cmbbox(i, 0).Text & "'"
                        strSQL += ", PRICE = " & num(i, 0).Value & ""
                        strSQL += ", WRN_PRICE = " & num(i, 1).Value & ""
                        strSQL += ", WRN_PRD = '" & num(i, 2).Value & "'"
                        strSQL += ", CUST_NAME_KANA = '" & Edit3.Text & "'"
                        strSQL += ", CUST_NAME = '" & Edit2.Text & "'"
                        strSQL += ", ZIP1 = '" & Mid(Mask1.Value, 1, 3) & "'"
                        strSQL += ", ZIP2 = '" & Mid(Mask1.Value, 4, 4) & "'"
                        strSQL += ", ADRS1 = '" & Edit4.Text & "'"
                        strSQL += ", ADRS2 = '" & Edit5.Text & "'"
                        If RadioButton1.Checked = True Then
                            strSQL += ", SEX = '1'"
                        Else
                            If RadioButton2.Checked = True Then
                                strSQL += ", SEX = '0'"
                            Else
                                strSQL += ", SEX = NULL"
                            End If
                        End If
                        strSQL += ", TEL_NO = '" & Edit6.Text & "'"
                        strSQL += ", CNT_NO = '" & Edit7.Text & "'"
                        strSQL += ", biko = '" & edit(i, 2).Text & "'"
                        strSQL += ", close_date = CONVERT(DATETIME, '" & Date2.Text & "/01', 102)"
                        If CheckBox1.Checked = True Then strSQL += ", delt_flg = 1" Else strSQL += ", delt_flg = 0"
                        strSQL += " WHERE (WRN_NO = '" & Label20.Text.PadRight(9, " ") & label(i, 0).Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN()
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Else
                        strSQL = "DELETE FROM WRN_DATA"
                        strSQL += " WHERE (WRN_NO = '" & Label20.Text.PadRight(9, " ") & label(i, 0).Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN()
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If

                Else
                    If cmbbox(i, 0).Text <> Nothing Then    'メーカーあり

                        WK_DsList1.Clear()
                        If Label20.Text = Nothing Then
                            strSQL = "SELECT WRN_NO FROM WRN_DATA WHERE (WRN_NO LIKE '" & Edit1.Text & "%') ORDER BY WRN_NO DESC"
                        Else
                            strSQL = "SELECT WRN_NO FROM WRN_DATA WHERE (WRN_NO LIKE '" & Label20.Text & "%') ORDER BY WRN_NO DESC"
                        End If
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN()
                        DaList1.Fill(WK_DsList1, "WRN_DATA")
                        WK_DtView1 = New DataView(WK_DsList1.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count = 0 Then
                            WK_int = 1
                        Else
                            WK_str = Mid(WK_DtView1(0)("WRN_NO"), 10, 2)
                            WK_int = CInt(WK_str) + 1
                        End If
                        If WK_int < 10 Then
                            WK_str2 = "0" & WK_int
                        Else
                            WK_str2 = WK_int
                        End If

                        strSQL = "INSERT INTO WRN_DATA"
                        strSQL += " (WRN_DATE, WRN_NO, SHOP_CODE, MODEL, CAT_CODE, CAT_NAME, bunrui, MKR_CODE"
                        strSQL += ", MKR_NAME, PRICE, WRN_PRICE, WRN_PRD, SALE_STS, CRT_DATE, CLS_MNTH, PNT_NO"
                        strSQL += ", CUST_NAME_KANA, CUST_NAME, ZIP1, ZIP2, ADRS1, ADRS2, SEX, TEL_NO, CNT_NO"
                        strSQL += ", biko, close_date)"
                        strSQL += " VALUES (CONVERT(DATETIME, '" & Date1.Text & "', 102)"
                        If Label20.Text = Nothing Then
                            strSQL += ", '" & Edit1.Text.PadRight(9, " ") & WK_str2 & "'"
                        Else
                            strSQL += ", '" & Label20.Text.PadRight(9, " ") & WK_str2 & "'"
                        End If
                        strSQL += ", '" & Edit8.Text & "'"
                        strSQL += ", '" & edit(i, 1).Text & "'"
                        strSQL += ", '" & cmbbox(i, 1).SelectedValue & "'"
                        strSQL += ", '" & edit(i, 0).Text & "'"
                        strSQL += ", '" & cmbbox(i, 2).SelectedValue & "'"
                        strSQL += ", '" & cmbbox(i, 0).SelectedValue & "'"
                        strSQL += ", '" & cmbbox(i, 0).Text & "'"
                        strSQL += ", " & num(i, 0).Value & ""
                        strSQL += ", " & num(i, 1).Value & ""
                        strSQL += ", '" & num(i, 2).Value & "'"
                        strSQL += ", '00'"
                        strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                        strSQL += ", NULL"
                        strSQL += ", NULL"
                        strSQL += ", '" & Edit3.Text & "'"
                        strSQL += ", '" & Edit2.Text & "'"
                        strSQL += ", '" & Mid(Mask1.Value, 1, 3) & "'"
                        strSQL += ", '" & Mid(Mask1.Value, 4, 4) & "'"
                        strSQL += ", '" & Edit4.Text & "'"
                        strSQL += ", '" & Edit5.Text & "'"
                        If RadioButton1.Checked = True Then
                            strSQL += ", '1'"
                        Else
                            If RadioButton2.Checked = True Then
                                strSQL += ", '0'"
                            Else
                                strSQL += ", NULL"
                            End If
                        End If
                        strSQL += ", '" & Edit6.Text & "'"
                        strSQL += ", '" & Edit7.Text & "'"
                        strSQL += ", '" & edit(i, 2).Text & "'"
                        strSQL += ", CONVERT(DATETIME, '" & Date2.Text & "/01', 102))"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                End If
            Next
            MsgBox(Replace(Button1.Text, "　", "") & "しました。", MsgBoxStyle.OKOnly, "確認")
            clr()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '************************************************
    '** クリア
    '************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clr()
    End Sub

    '************************************************
    '** 戻る
    '************************************************
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        dsItem1.Clear()
        dsItem2.Clear()
        dsItem3.Clear()
        WK_DsList1.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.ResultStringEventArgs) Handles Furigana.ResultString
        ' 取得したふりがなを表示します。
        If Edit2.ReadOnly = False Then
            Edit3.Text += e.ReadString
        End If
    End Sub
End Class
