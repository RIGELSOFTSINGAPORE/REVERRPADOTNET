Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim Line_No, x, i, r As Integer
    Dim strSQL, strWH As String

    Dim WK_date As Date

    Dim label(99, 8) As Label
    Dim edit(99, 2) As GrapeCity.Win.Input.Interop.Edit
    Dim num(99, 1) As GrapeCity.Win.Input.Interop.Number
    Dim datBox(99, 1) As GrapeCity.Win.Input.Interop.Date

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_adrs1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_zip As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Date_ent As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lbl_wrnttl As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_no As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tel1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents tel2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents kbn As System.Windows.Forms.Label
    Friend WithEvents cust_name As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents cust_name_srch As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents slct As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Date_ent = New GrapeCity.Win.Input.Interop.Date
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_zip = New GrapeCity.Win.Input.Interop.Mask
        Me.txt_adrs1 = New GrapeCity.Win.Input.Interop.Edit
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.tel1 = New GrapeCity.Win.Input.Interop.Edit
        Me.lbl_wrnttl = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pos = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txt_no = New GrapeCity.Win.Input.Interop.Edit
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.tel2 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.kbn = New System.Windows.Forms.Label
        Me.cust_name = New GrapeCity.Win.Input.Interop.Edit
        Me.cust_name_srch = New GrapeCity.Win.Input.Interop.Edit
        Me.slct = New GrapeCity.Win.Input.Interop.Edit
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_name, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_name_srch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Date_ent
        '
        Me.Date_ent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Date_ent.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_ent.DropDownCalendar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.DropDownCalendar.Size = New System.Drawing.Size(186, 207)
        Me.Date_ent.ExitOnLastChar = True
        Me.Date_ent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Date_ent.Location = New System.Drawing.Point(840, 48)
        Me.Date_ent.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        Me.Date_ent.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        Me.Date_ent.Name = "Date_ent"
        Me.Date_ent.ReadOnly = True
        Me.Date_ent.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date_ent.Size = New System.Drawing.Size(120, 25)
        Me.Date_ent.TabIndex = 2
        Me.Date_ent.TabStop = False
        Me.Date_ent.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_ent.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date_ent.Value = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(752, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "申込日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 32)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "商品名"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(216, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 32)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "メーカー"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(336, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 32)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "型  式"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(504, 176)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 32)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "品種コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(620, 176)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 32)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "保証限度額（合計値）"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(708, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 32)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "購入日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(796, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 32)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "保証料　　（税込）"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(756, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 101
        Me.Button2.Text = "クリア"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 24)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "電話番号"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 24)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "使用者"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(752, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 24)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "No."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_zip
        '
        Me.txt_zip.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_zip.ExitOnLastChar = True
        Me.txt_zip.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_zip.Format = New GrapeCity.Win.Input.Interop.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.txt_zip.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_zip.Location = New System.Drawing.Point(416, 80)
        Me.txt_zip.Name = "txt_zip"
        Me.txt_zip.ReadOnly = True
        Me.txt_zip.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_zip.Size = New System.Drawing.Size(88, 25)
        Me.txt_zip.TabIndex = 14
        Me.txt_zip.TabStop = False
        Me.txt_zip.Value = ""
        '
        'txt_adrs1
        '
        Me.txt_adrs1.AllowSpace = False
        Me.txt_adrs1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_adrs1.ExitOnLastChar = True
        Me.txt_adrs1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txt_adrs1.LengthAsByte = True
        Me.txt_adrs1.Location = New System.Drawing.Point(416, 112)
        Me.txt_adrs1.Multiline = True
        Me.txt_adrs1.Name = "txt_adrs1"
        Me.txt_adrs1.ReadOnly = True
        Me.txt_adrs1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_adrs1.Size = New System.Drawing.Size(416, 48)
        Me.txt_adrs1.TabIndex = 17
        Me.txt_adrs1.TabStop = False
        Me.txt_adrs1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Top
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(860, 480)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 32)
        Me.Button3.TabIndex = 103
        Me.Button3.Text = "終 了"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(320, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 24)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "住所1"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(320, 80)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 24)
        Me.Label21.TabIndex = 108
        Me.Label21.Text = "郵便番号"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tel1
        '
        Me.tel1.AllowSpace = False
        Me.tel1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.tel1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tel1.Format = "9"
        Me.tel1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tel1.Location = New System.Drawing.Point(128, 80)
        Me.tel1.MaxLength = 15
        Me.tel1.Name = "tel1"
        Me.tel1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.tel1.Size = New System.Drawing.Size(176, 25)
        Me.tel1.TabIndex = 13
        '
        'lbl_wrnttl
        '
        Me.lbl_wrnttl.BackColor = System.Drawing.Color.White
        Me.lbl_wrnttl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wrnttl.ForeColor = System.Drawing.Color.Black
        Me.lbl_wrnttl.Location = New System.Drawing.Point(784, 432)
        Me.lbl_wrnttl.Name = "lbl_wrnttl"
        Me.lbl_wrnttl.Size = New System.Drawing.Size(104, 32)
        Me.lbl_wrnttl.TabIndex = 129
        Me.lbl_wrnttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(668, 432)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 32)
        Me.Label24.TabIndex = 130
        Me.Label24.Text = "保証料合計"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pos)
        Me.Panel1.Location = New System.Drawing.Point(8, 208)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1060, 216)
        Me.Panel1.TabIndex = 10000
        '
        'pos
        '
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(1, 1)
        Me.pos.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(636, 480)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 10002
        Me.Button1.Text = "検 索"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(868, 176)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(28, 32)
        Me.Label25.TabIndex = 10005
        Me.Label25.Text = "契約"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.DarkBlue
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Font = New System.Drawing.Font("Arial", 11.25!)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(896, 176)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 32)
        Me.Label26.TabIndex = 10006
        Me.Label26.Text = "取消日"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_no
        '
        Me.txt_no.AllowSpace = False
        Me.txt_no.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.txt_no.ExitOnLastChar = True
        Me.txt_no.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no.Format = "A9"
        Me.txt_no.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_no.LengthAsByte = True
        Me.txt_no.Location = New System.Drawing.Point(840, 16)
        Me.txt_no.MaxLength = 14
        Me.txt_no.Name = "txt_no"
        Me.txt_no.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_no.Size = New System.Drawing.Size(120, 25)
        Me.txt_no.TabIndex = 1
        Me.txt_no.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_no.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(856, 88)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 10007
        Me.Button4.Text = "メモ"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.DarkBlue
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(984, 176)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 32)
        Me.Label27.TabIndex = 10008
        Me.Label27.Text = "保証期間"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tel2
        '
        Me.tel2.AllowSpace = False
        Me.tel2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.tel2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tel2.Format = "9"
        Me.tel2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tel2.Location = New System.Drawing.Point(128, 112)
        Me.tel2.MaxLength = 15
        Me.tel2.Name = "tel2"
        Me.tel2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.tel2.Size = New System.Drawing.Size(176, 25)
        Me.tel2.TabIndex = 10009
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 10010
        Me.Label1.Text = "携帯電話"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kbn
        '
        Me.kbn.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.kbn.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kbn.Location = New System.Drawing.Point(16, 8)
        Me.kbn.Name = "kbn"
        Me.kbn.Size = New System.Drawing.Size(112, 24)
        Me.kbn.TabIndex = 10011
        Me.kbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cust_name
        '
        Me.cust_name.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cust_name.ExitOnLastChar = True
        Me.cust_name.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_name.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.cust_name.LengthAsByte = True
        Me.cust_name.Location = New System.Drawing.Point(128, 48)
        Me.cust_name.MaxLength = 15
        Me.cust_name.Name = "cust_name"
        Me.cust_name.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_name.Size = New System.Drawing.Size(176, 25)
        Me.cust_name.TabIndex = 11
        Me.cust_name.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_name.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_name_srch
        '
        Me.cust_name_srch.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.cust_name_srch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cust_name_srch.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.cust_name_srch.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.cust_name_srch.Enabled = False
        Me.cust_name_srch.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_name_srch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cust_name_srch.Location = New System.Drawing.Point(320, 48)
        Me.cust_name_srch.Name = "cust_name_srch"
        Me.cust_name_srch.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_name_srch.Size = New System.Drawing.Size(176, 25)
        Me.cust_name_srch.TabIndex = 10012
        Me.cust_name_srch.TabStop = False
        Me.cust_name_srch.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.cust_name_srch.Visible = False
        '
        'slct
        '
        Me.slct.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.slct.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slct.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.slct.Location = New System.Drawing.Point(968, 16)
        Me.slct.MaxLength = 15
        Me.slct.Name = "slct"
        Me.slct.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.slct.Size = New System.Drawing.Size(24, 25)
        Me.slct.TabIndex = 10013
        Me.slct.TabStop = False
        Me.slct.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(592, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 32)
        Me.Label3.TabIndex = 10014
        Me.Label3.Text = "ｾｯﾄ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1074, 525)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.slct)
        Me.Controls.Add(Me.cust_name_srch)
        Me.Controls.Add(Me.kbn)
        Me.Controls.Add(Me.tel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txt_no)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lbl_wrnttl)
        Me.Controls.Add(Me.tel1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cust_name)
        Me.Controls.Add(Me.txt_adrs1)
        Me.Controls.Add(Me.txt_zip)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date_ent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ストリーム検索"
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_name, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_name_srch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()

        'Label10.Text = "購入価格" & vbCrLf & "（税込）"
        Label10.Text = "保証限度額" & vbCrLf & "（合計値）"
        Label12.Text = "保証料" & vbCrLf & "（税込）"
        Label27.Text = "保証" & vbCrLf & "期間"

    End Sub

    '検索
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If txt_no.Text = Nothing And cust_name_srch.Text = Nothing And tel1.Text = Nothing And tel2.Text = Nothing Then
            MessageBox.Show("検索キーを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_no.Focus()
        Else

re_scn:
            '保証データ_マスタ
            P_DsList1.Clear()
            strSQL = "SELECT Wrn_mtr.*, V_cls_001.CLS_CODE_NAME AS kbn_name"
            strSQL = strSQL & " FROM Wrn_mtr INNER JOIN V_cls_001 ON Wrn_mtr.kbn = V_cls_001.CLS_CODE"
            strWH = " WHERE"

            If slct.Text = "1" Then
                strWH = strWH & " (Wrn_mtr.ordr_no = '" & txt_no.Text & "')"
            Else
                Dim and_F As String = "0"
                If txt_no.Text <> Nothing Then
                    strWH = strWH & " (Wrn_mtr.ordr_no LIKE '" & txt_no.Text & "%')"
                    and_F = "1"
                End If
                If cust_name_srch.Text <> Nothing Then
                    If and_F = "1" Then strWH = strWH & " AND"
                    strWH = strWH & " (Wrn_mtr.cust_name_srch LIKE '" & cust_name_srch.Text & "%')"
                    and_F = "1"
                End If
                If tel1.Text <> Nothing Then
                    If and_F = "1" Then strWH = strWH & " AND"
                    strWH = strWH & " (Wrn_mtr.tel1 LIKE '" & tel1.Text & "%')"
                    and_F = "1"
                End If
                If tel2.Text <> Nothing Then
                    If and_F = "1" Then strWH = strWH & " AND"
                    strWH = strWH & " (Wrn_mtr.tel2 LIKE '" & tel2.Text & "%')"
                End If
            End If
            strSQL = strSQL & strWH
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN()
            r = DaList1.Fill(P_DsList1, "wrn_mtr")
            DB_CLOSE()

            Select Case r
                Case Is = 0
                    MessageBox.Show("該当するデータはありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case Is = 1
                    DtView1 = New DataView(P_DsList1.Tables("wrn_mtr"), "", "", DataViewRowState.CurrentRows)
                    Call disp_main()
                Case Is <= 100
                    strSQL = "SELECT RTRIM(Wrn_mtr.ordr_no) AS ordr_no, RTRIM(Wrn_mtr.cust_name) AS cust_name"
                    strSQL += ", RTRIM(Wrn_mtr.tel1) AS tel1, RTRIM(Wrn_mtr.tel2) AS tel2"
                    strSQL += ", V_cls_001.CLS_CODE_NAME AS kbn_name, Wrn_sub.prch_date, Wrn_sub.cont_flg"
                    strSQL += ", Cat_mtr.cat_name, Wrn_sub.model_name"
                    strSQL += " FROM Wrn_mtr INNER JOIN"
                    strSQL += " V_cls_001 ON Wrn_mtr.kbn = V_cls_001.CLS_CODE INNER JOIN"
                    strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
                    strSQL += " Cat_mtr ON Wrn_sub.item_cat_code = Cat_mtr.cat_code"
                    strSQL += strWH

                    'strSQL = "SELECT RTRIM(Wrn_mtr.ordr_no) AS ordr_no, RTRIM(Wrn_mtr.cust_name) AS cust_name"
                    'strSQL = strSQL & ", RTRIM(Wrn_mtr.tel1) AS tel1, RTRIM(Wrn_mtr.tel2) AS tel2"
                    'strSQL = strSQL & ", V_cls_001.CLS_CODE_NAME AS kbn_name, SUBSTRING(Wrn_mtr.adrs, 1, 3) AS ken"
                    'strSQL = strSQL & ", Wrn_sub.prch_date, Wrn_sub.cont_flg"
                    'strSQL = strSQL & " FROM Wrn_mtr INNER JOIN"
                    'strSQL = strSQL & " V_cls_001 ON Wrn_mtr.kbn = V_cls_001.CLS_CODE INNER JOIN"
                    'strSQL = strSQL & " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
                    'strSQL = strSQL & strWH
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN()
                    DaList1.Fill(P_DsList1, "List")
                    DB_CLOSE()

                    p_ordr_no = Nothing
                    Me.Enabled = False

                    Dim List As New List
                    List.ShowDialog()

                    Me.Enabled = True
                    txt_no.Text = p_ordr_no
                    slct.Text = "1"

                    GoTo re_scn
                Case Else
                    MessageBox.Show("検索結果が100件を超えています。条件を再度設定してください。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'クリア
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'CANCEL
        Call initial()
        txt_no.Focus()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '終了
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    'メインデータ表示
    Sub disp_main()

        kbn.Text = DtView1(0)("kbn_name")
        txt_no.Text = DtView1(0)("ordr_no")
        If Not IsDBNull(DtView1(0)("entry_date")) Then Date_ent.Text = DtView1(0)("entry_date") Else Date_ent.Text = Nothing
        'Date_ent.Text = DtView1(0)("entry_date")
        If Not IsDBNull(DtView1(0)("cust_name")) Then cust_name.Text = DtView1(0)("cust_name") Else cust_name.Text = Nothing
        cust_name_srch.Text = Replace(Replace(cust_name.Text, "　", ""), " ", "")
        If Not IsDBNull(DtView1(0)("tel1")) Then tel1.Text = Trim(DtView1(0)("tel1")) Else tel1.Text = Nothing
        If Not IsDBNull(DtView1(0)("tel2")) Then tel2.Text = Trim(DtView1(0)("tel2")) Else tel2.Text = Nothing
        If Not IsDBNull(DtView1(0)("zip_code")) Then txt_zip.Value = DtView1(0)("zip_code") Else txt_zip.Text = Nothing
        If Not IsDBNull(DtView1(0)("adrs")) Then txt_adrs1.Text = DtView1(0)("adrs") Else txt_adrs1.Text = Nothing

        'memo
        Button4.Enabled = True
        DsList1.Clear()
        strSQL = "SELECT * FROM Memo WHERE (ordr_no = '" & txt_no.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN()
        DaList1.Fill(DsList1, "Memo")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Memo"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Button4.BackColor = System.Drawing.Color.Yellow
            p_rtn = "1"
        Else
            Button4.BackColor = System.Drawing.SystemColors.Control
            p_rtn = "0"
        End If

        Call disp_sub()

    End Sub

    'サブデータ表示
    Sub disp_sub()

        '保証データ_サブ
        strSQL = "SELECT Wrn_sub.*, vdr_mtr.vdr_name, Cat_mtr.cat_name"
        strSQL = strSQL & " FROM Wrn_sub LEFT OUTER JOIN"
        strSQL = strSQL & " Cat_mtr ON Wrn_sub.item_cat_code = Cat_mtr.cat_code LEFT OUTER JOIN"
        strSQL = strSQL & " vdr_mtr ON Wrn_sub.bend_code = vdr_mtr.vdr_code"
        strSQL = strSQL & " WHERE (Wrn_sub.ordr_no = '" & txt_no.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN()
        DaList1.Fill(DsList1, "Wrn_sub")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Wrn_sub"), "", "line_no, seq", DataViewRowState.CurrentRows)
        For Line_No = 0 To DtView1.Count - 1

            '商品名
            x = 0
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(0, 29 * Line_No + pos.Location.Y)
            label(Line_No, x).Name = "lbl_item1"
            label(Line_No, x).Size = New System.Drawing.Size(208, 28)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            label(Line_No, x).Tag = Line_No
            If Not IsDBNull(DtView1(Line_No)("cat_name")) Then label(Line_No, x).Text = Trim(DtView1(Line_No)("cat_name")) Else label(Line_No, x).Text = Nothing
            Panel1.Controls.Add(label(Line_No, x))

            'メーカー
            x = 1
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(208, 29 * Line_No + pos.Location.Y)
            label(Line_No, x).Name = "lbl_vdr"
            label(Line_No, x).Size = New System.Drawing.Size(120, 28)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            If Not IsDBNull(DtView1(Line_No)("vdr_name")) Then label(Line_No, x).Text = Trim(DtView1(Line_No)("vdr_name")) Else label(Line_No, x).Text = Trim(DtView1(Line_No)("bend_code"))
            Panel1.Controls.Add(label(Line_No, x))

            '型式
            x = 0
            edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
            edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            edit(Line_No, x).Format = "AaK#@"
            edit(Line_No, x).MaxLength = 20
            edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
            edit(Line_No, x).Location = New System.Drawing.Point(328, 29 * Line_No + pos.Location.Y)
            edit(Line_No, x).Tag = Line_No
            edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            edit(Line_No, x).Size = New System.Drawing.Size(168, 28)
            edit(Line_No, x).TabIndex = 102
            edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
            edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            edit(Line_No, x).ReadOnly = True
            edit(Line_No, x).TabStop = False
            If Not IsDBNull(DtView1(Line_No)("model_name")) Then edit(Line_No, x).Text = Trim(DtView1(Line_No)("model_name")) Else edit(Line_No, x).Text = Nothing
            Panel1.Controls.Add(edit(Line_No, x))

            '品種コード
            x = 1
            edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
            edit(Line_No, x).AllowSpace = False
            edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            edit(Line_No, x).ExitOnLastChar = True
            edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            edit(Line_No, x).Format = "9"
            edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            edit(Line_No, x).LengthAsByte = True
            edit(Line_No, x).Location = New System.Drawing.Point(496, 29 * Line_No + pos.Location.Y)
            edit(Line_No, x).MaxLength = 9
            edit(Line_No, x).Tag = Line_No
            edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            edit(Line_No, x).Size = New System.Drawing.Size(88, 28)
            edit(Line_No, x).TabIndex = 103
            edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
            edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            edit(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            edit(Line_No, x).ReadOnly = True
            edit(Line_No, x).TabStop = False
            If Not IsDBNull(DtView1(Line_No)("item_cat_code")) Then edit(Line_No, x).Text = DtView1(Line_No)("item_cat_code")
            Panel1.Controls.Add(edit(Line_No, x))

            'セット
            x = 8
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(584, 29 * Line_No + pos.Location.Y)
            label(Line_No, x).Size = New System.Drawing.Size(28, 28)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            If Not IsDBNull(DtView1(Line_No)("set_flg")) Then label(Line_No, x).Text = Trim(DtView1(Line_No)("set_flg")) Else label(Line_No, x).Text = "0"
            Panel1.Controls.Add(label(Line_No, x))

            '保証限度額（合計値）
            x = 0
            num(Line_No, x) = New GrapeCity.Win.Input.Interop.Number
            num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
            'num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberFormat("##,###,##0", "", "", "-", "", "", "")
            num(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
            num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
            num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'num(Line_No, x).Format = New GrapeCity.Win.Input.Interop.NumberFormat("##,###,##0", "", "", "-", "", "", "")
            num(Line_No, x).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")


            num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            num(Line_No, x).Location = New System.Drawing.Point(612, 29 * Line_No + pos.Location.Y)
            num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
            num(Line_No, x).MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
            num(Line_No, x).Tag = Line_No
            num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            num(Line_No, x).Size = New System.Drawing.Size(88, 28)
            num(Line_No, x).TabIndex = 106
            num(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            num(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            num(Line_No, x).ReadOnly = True
            num(Line_No, x).TabStop = False
            If Not IsDBNull(DtView1(Line_No)("ttl")) Then
                num(Line_No, x).Value = DtView1(Line_No)("ttl")
            Else
                num(Line_No, x).Value = DtView1(Line_No)("prch_price") + DtView1(Line_No)("prch_tax")
            End If
            Panel1.Controls.Add(num(Line_No, x))

            '購入日
            x = 0
            datBox(Line_No, x) = New GrapeCity.Win.Input.Interop.Date
            datBox(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            datBox(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
            datBox(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
            datBox(Line_No, x).ExitOnLastChar = True
            datBox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            datBox(Line_No, x).Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
            datBox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            datBox(Line_No, x).Location = New System.Drawing.Point(700, 29 * Line_No + pos.Location.Y)
            datBox(Line_No, x).MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
            datBox(Line_No, x).MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
            datBox(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
            datBox(Line_No, x).Size = New System.Drawing.Size(88, 28)
            datBox(Line_No, x).TabIndex = 107
            datBox(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
            datBox(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            datBox(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            datBox(Line_No, x).ReadOnly = True
            datBox(Line_No, x).TabStop = False
            datBox(Line_No, x).Tag = Line_No
            datBox(Line_No, x).Text = DtView1(Line_No)("prch_date")
            WK_date = DateAdd(DateInterval.Year, CInt(DtView1(Line_No)("wrn_prod")), CDate(DtView1(Line_No)("prch_date")))
            If WK_date >= Now.Date Then
                datBox(Line_No, x).ForeColor = System.Drawing.SystemColors.WindowText
            Else
                datBox(Line_No, x).ForeColor = System.Drawing.Color.Red
            End If
            Panel1.Controls.Add(datBox(Line_No, x))

            '保証料
            x = 2
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(788, 29 * Line_No + pos.Location.Y)
            label(Line_No, x).Tag = Line_No
            label(Line_No, x).Size = New System.Drawing.Size(72, 28)
            label(Line_No, x).TabIndex = 108
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleRight
            label(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            label(Line_No, x).Text = Format(DtView1(Line_No)("wrn_fee") + DtView1(Line_No)("wrn_fee_tax"), "##,##0")
            Panel1.Controls.Add(label(Line_No, x))

            '契約状況
            x = 3
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(860, 29 * Line_No + pos.Location.Y)
            label(Line_No, x).Tag = Line_No
            label(Line_No, x).Size = New System.Drawing.Size(28, 28)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            label(Line_No, x).Text = DtView1(Line_No)("cont_flg")
            Panel1.Controls.Add(label(Line_No, x))

            '取消日
            x = 4
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(888, 29 * Line_No + pos.Location.Y)
            label(Line_No, x).Tag = Line_No
            label(Line_No, x).Size = New System.Drawing.Size(88, 28)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(Line_No, x).BorderStyle = BorderStyle.Fixed3D
            If Not IsDBNull(DtView1(Line_No)("cxl_date")) Then
                label(Line_No, x).Text = Format(DtView1(Line_No)("cxl_date"), "yyyy/MM/dd")
            Else
                label(Line_No, x).Text = Nothing
            End If
            Panel1.Controls.Add(label(Line_No, x))

            '保証期間
            x = 5
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(976, 29 * Line_No + pos.Location.Y)
            label(Line_No, x).Tag = Line_No
            label(Line_No, x).Size = New System.Drawing.Size(40, 28)
            label(Line_No, x).TabIndex = 109
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(Line_No, x).BorderStyle = BorderStyle.Fixed3D

            '2015/08/13 電動工具追加対応
            If Not IsDBNull(DtView1(Line_No)("wrn_plan")) Then
                Select Case DtView1(Line_No)("wrn_plan")
                    Case Is = "10"
                        label(Line_No, x).Text = DtView1(Line_No)("wrn_prod")
                    Case Is = "20"
                        label(Line_No, x).Text = "工" & DtView1(Line_No)("wrn_prod")
                    Case Else
                        label(Line_No, x).Text = DtView1(Line_No)("wrn_prod")
                End Select
            Else
                label(Line_No, x).Text = DtView1(Line_No)("wrn_prod")
            End If

            Panel1.Controls.Add(label(Line_No, x))

            '行番号
            x = 6
            label(Line_No, x) = New Label
            label(Line_No, x).Text = DtView1(Line_No)("line_no")

            'SEQ
            x = 7
            label(Line_No, x) = New Label
            label(Line_No, x).Text = DtView1(Line_No)("seq")
        Next

        lbl_wrnttl.Text = 0

        For i = 0 To Line_No - 1
            lbl_wrnttl.Text = Format(CInt(lbl_wrnttl.Text) + CInt(label(i, 2).Text), "##,##0")
        Next

    End Sub

    '**********************************
    'メモボタン
    '**********************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        p_ordr_no = txt_no.Text

        Dim frmform3 As New Form3
        frmform3.ShowDialog()

        If p_rtn = "1" Then
            Button4.BackColor = System.Drawing.Color.Yellow
        Else
            Button4.BackColor = System.Drawing.SystemColors.Control
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '画面の初期化
    Sub initial()

        kbn.Text = Nothing
        txt_no.Text = Nothing
        slct.Text = Nothing
        Date_ent.Text = "____/__/__"
        cust_name.Text = Nothing
        cust_name_srch.Text = Nothing
        tel1.Text = Nothing
        tel2.Text = Nothing
        txt_zip.Text = Nothing
        txt_adrs1.Text = Nothing
        lbl_wrnttl.Text = 0

        Panel1.Controls.Clear()
        Button4.Enabled = False        'memo
        Button4.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub cust_name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cust_name.LostFocus
        cust_name_srch.Text = Replace(Replace(cust_name.Text, "　", ""), " ", "")
    End Sub
End Class
