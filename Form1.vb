Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, strWH, WK_strSQL As String
    Dim i, k, r, sum, WK_cnt As Integer

    Dim DGTS As New DataGridTableStyle
    Dim tbl As New DataTable

    Dim style01 As New DataGridTextBoxColumn
    Dim style02 As New DataGridTextBoxColumn
    Dim style03 As New DataGridTextBoxColumn
    Dim style04 As New DataGridTextBoxColumn
    Dim style05 As New DataGridTextBoxColumn
    Dim style06 As New DataGridTextBoxColumn
    Dim style07 As New DataGridTextBoxColumn
    Dim style08 As New DataGridTextBoxColumn
    Dim style09 As New DataGridTextBoxColumn
    Dim style10 As New DataGridTextBoxColumn
    Dim style11 As New DataGridTextBoxColumn
    Dim style12 As New MyDataGridTextBoxColumn1
    Dim style13 As New DataGridTextBoxColumn
    Dim style14 As New DataGridTextBoxColumn
    Dim style15 As New DataGridTextBoxColumn
    Dim style16 As New DataGridTextBoxColumn

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
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_city As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_adrs1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_adrs2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_zip As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents cust_lname As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents cust_fname As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Date_ent As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_phone As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_shop_code As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lbl_shop As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lbl_wrnttl As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbl_pref As System.Windows.Forms.Label
    Friend WithEvents lbl_corp_flg As System.Windows.Forms.Label
    Friend WithEvents txt_no As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents slct As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents DataGridEx1 As best_search.DataGridEx
    Friend WithEvents cnt As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Date_ent = New GrapeCity.Win.Input.Interop.Date
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_zip = New GrapeCity.Win.Input.Interop.Mask
        Me.txt_city = New GrapeCity.Win.Input.Interop.Edit
        Me.txt_adrs1 = New GrapeCity.Win.Input.Interop.Edit
        Me.txt_adrs2 = New GrapeCity.Win.Input.Interop.Edit
        Me.cust_lname = New GrapeCity.Win.Input.Interop.Edit
        Me.cust_fname = New GrapeCity.Win.Input.Interop.Edit
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_phone = New GrapeCity.Win.Input.Interop.Edit
        Me.txt_shop_code = New GrapeCity.Win.Input.Interop.Edit
        Me.Label22 = New System.Windows.Forms.Label
        Me.lbl_shop = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.lbl_wrnttl = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.lbl_pref = New System.Windows.Forms.Label
        Me.lbl_corp_flg = New System.Windows.Forms.Label
        Me.txt_no = New GrapeCity.Win.Input.Interop.Edit
        Me.Button4 = New System.Windows.Forms.Button
        Me.slct = New GrapeCity.Win.Input.Interop.Edit
        Me.DataGridEx1 = New best_search.DataGridEx
        Me.cnt = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_city, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_adrs2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_lname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_fname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_phone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_shop_code, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Date_ent.Location = New System.Drawing.Point(896, 48)
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
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(808, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "申込日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(800, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 101
        Me.Button2.Text = "クリア"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 24)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "電話番号"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 48)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "使用者"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkBlue
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(72, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 24)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "（姓）"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DarkBlue
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(72, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 24)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "（名）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkBlue
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(808, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 24)
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
        Me.txt_zip.Location = New System.Drawing.Point(432, 52)
        Me.txt_zip.Name = "txt_zip"
        Me.txt_zip.ReadOnly = True
        Me.txt_zip.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_zip.Size = New System.Drawing.Size(88, 25)
        Me.txt_zip.TabIndex = 14
        Me.txt_zip.TabStop = False
        Me.txt_zip.Value = ""
        '
        'txt_city
        '
        Me.txt_city.AllowSpace = False
        Me.txt_city.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_city.ExitOnLastChar = True
        Me.txt_city.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_city.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_city.LengthAsByte = True
        Me.txt_city.Location = New System.Drawing.Point(432, 76)
        Me.txt_city.MaxLength = 24
        Me.txt_city.Name = "txt_city"
        Me.txt_city.ReadOnly = True
        Me.txt_city.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_city.Size = New System.Drawing.Size(304, 25)
        Me.txt_city.TabIndex = 16
        Me.txt_city.TabStop = False
        Me.txt_city.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_city.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs1
        '
        Me.txt_adrs1.AllowSpace = False
        Me.txt_adrs1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_adrs1.ExitOnLastChar = True
        Me.txt_adrs1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs1.LengthAsByte = True
        Me.txt_adrs1.Location = New System.Drawing.Point(432, 100)
        Me.txt_adrs1.MaxLength = 36
        Me.txt_adrs1.Name = "txt_adrs1"
        Me.txt_adrs1.ReadOnly = True
        Me.txt_adrs1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_adrs1.Size = New System.Drawing.Size(304, 25)
        Me.txt_adrs1.TabIndex = 17
        Me.txt_adrs1.TabStop = False
        Me.txt_adrs1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs2
        '
        Me.txt_adrs2.AllowSpace = False
        Me.txt_adrs2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_adrs2.ExitOnLastChar = True
        Me.txt_adrs2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs2.LengthAsByte = True
        Me.txt_adrs2.Location = New System.Drawing.Point(432, 124)
        Me.txt_adrs2.MaxLength = 36
        Me.txt_adrs2.Name = "txt_adrs2"
        Me.txt_adrs2.ReadOnly = True
        Me.txt_adrs2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_adrs2.Size = New System.Drawing.Size(304, 25)
        Me.txt_adrs2.TabIndex = 18
        Me.txt_adrs2.TabStop = False
        Me.txt_adrs2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_lname
        '
        Me.cust_lname.AllowSpace = False
        Me.cust_lname.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cust_lname.ExitOnLastChar = True
        Me.cust_lname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_lname.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cust_lname.LengthAsByte = True
        Me.cust_lname.Location = New System.Drawing.Point(128, 64)
        Me.cust_lname.MaxLength = 15
        Me.cust_lname.Name = "cust_lname"
        Me.cust_lname.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_lname.Size = New System.Drawing.Size(176, 25)
        Me.cust_lname.TabIndex = 11
        Me.cust_lname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_lname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_fname
        '
        Me.cust_fname.AllowSpace = False
        Me.cust_fname.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cust_fname.ExitOnLastChar = True
        Me.cust_fname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_fname.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cust_fname.LengthAsByte = True
        Me.cust_fname.Location = New System.Drawing.Point(128, 88)
        Me.cust_fname.MaxLength = 15
        Me.cust_fname.Name = "cust_fname"
        Me.cust_fname.ReadOnly = True
        Me.cust_fname.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_fname.Size = New System.Drawing.Size(176, 25)
        Me.cust_fname.TabIndex = 12
        Me.cust_fname.TabStop = False
        Me.cust_fname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_fname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(904, 480)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 32)
        Me.Button3.TabIndex = 103
        Me.Button3.Text = "終 了"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(520, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "都道府県"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(336, 76)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 24)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "市区町村名"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkBlue
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(336, 100)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 24)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "住所1"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkBlue
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(336, 124)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 24)
        Me.Label20.TabIndex = 107
        Me.Label20.Text = "住所2"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkBlue
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(336, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 24)
        Me.Label21.TabIndex = 108
        Me.Label21.Text = "郵便番号"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_phone
        '
        Me.txt_phone.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.txt_phone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_phone.Format = "9#"
        Me.txt_phone.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_phone.Location = New System.Drawing.Point(128, 120)
        Me.txt_phone.MaxLength = 15
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_phone.Size = New System.Drawing.Size(176, 25)
        Me.txt_phone.TabIndex = 13
        '
        'txt_shop_code
        '
        Me.txt_shop_code.AllowSpace = False
        Me.txt_shop_code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_shop_code.ExitOnLastChar = True
        Me.txt_shop_code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_shop_code.Format = "9"
        Me.txt_shop_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_shop_code.LengthAsByte = True
        Me.txt_shop_code.Location = New System.Drawing.Point(88, 464)
        Me.txt_shop_code.MaxLength = 4
        Me.txt_shop_code.Name = "txt_shop_code"
        Me.txt_shop_code.ReadOnly = True
        Me.txt_shop_code.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_shop_code.Size = New System.Drawing.Size(64, 32)
        Me.txt_shop_code.TabIndex = 31
        Me.txt_shop_code.TabStop = False
        Me.txt_shop_code.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.txt_shop_code.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(16, 464)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 32)
        Me.Label22.TabIndex = 125
        Me.Label22.Text = "店コード"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_shop
        '
        Me.lbl_shop.BackColor = System.Drawing.Color.White
        Me.lbl_shop.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shop.ForeColor = System.Drawing.Color.Black
        Me.lbl_shop.Location = New System.Drawing.Point(224, 464)
        Me.lbl_shop.Name = "lbl_shop"
        Me.lbl_shop.Size = New System.Drawing.Size(248, 32)
        Me.lbl_shop.TabIndex = 126
        Me.lbl_shop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkBlue
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(16, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 16)
        Me.Label23.TabIndex = 128
        Me.Label23.Text = "契約者タイプ"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label23.Visible = False
        '
        'lbl_wrnttl
        '
        Me.lbl_wrnttl.BackColor = System.Drawing.Color.White
        Me.lbl_wrnttl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wrnttl.ForeColor = System.Drawing.Color.Black
        Me.lbl_wrnttl.Location = New System.Drawing.Point(680, 440)
        Me.lbl_wrnttl.Name = "lbl_wrnttl"
        Me.lbl_wrnttl.Size = New System.Drawing.Size(104, 28)
        Me.lbl_wrnttl.TabIndex = 129
        Me.lbl_wrnttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkBlue
        Me.Label24.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(568, 440)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 28)
        Me.Label24.TabIndex = 130
        Me.Label24.Text = "保証料合計"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(152, 464)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 32)
        Me.Label1.TabIndex = 10001
        Me.Label1.Text = "店舗名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(680, 480)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 10002
        Me.Button1.Text = "検 索"
        '
        'lbl_pref
        '
        Me.lbl_pref.BackColor = System.Drawing.Color.White
        Me.lbl_pref.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_pref.Location = New System.Drawing.Point(616, 52)
        Me.lbl_pref.Name = "lbl_pref"
        Me.lbl_pref.Size = New System.Drawing.Size(120, 24)
        Me.lbl_pref.TabIndex = 10003
        Me.lbl_pref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_corp_flg
        '
        Me.lbl_corp_flg.BackColor = System.Drawing.Color.White
        Me.lbl_corp_flg.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_corp_flg.Location = New System.Drawing.Point(128, 44)
        Me.lbl_corp_flg.Name = "lbl_corp_flg"
        Me.lbl_corp_flg.Size = New System.Drawing.Size(80, 16)
        Me.lbl_corp_flg.TabIndex = 10004
        Me.lbl_corp_flg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_corp_flg.Visible = False
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
        Me.txt_no.Location = New System.Drawing.Point(856, 16)
        Me.txt_no.MaxLength = 14
        Me.txt_no.Name = "txt_no"
        Me.txt_no.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_no.Size = New System.Drawing.Size(160, 25)
        Me.txt_no.TabIndex = 1
        Me.txt_no.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_no.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(908, 80)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 10007
        Me.Button4.Text = "メモ"
        '
        'slct
        '
        Me.slct.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.slct.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slct.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.slct.Location = New System.Drawing.Point(1016, 16)
        Me.slct.MaxLength = 15
        Me.slct.Name = "slct"
        Me.slct.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.slct.Size = New System.Drawing.Size(24, 25)
        Me.slct.TabIndex = 10011
        Me.slct.TabStop = False
        Me.slct.Visible = False
        '
        'DataGridEx1
        '
        Me.DataGridEx1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridEx1.HeaderBackColor = System.Drawing.Color.Navy
        Me.DataGridEx1.HeaderForeColor = System.Drawing.Color.White
        Me.DataGridEx1.Location = New System.Drawing.Point(4, 156)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(1092, 276)
        Me.DataGridEx1.TabIndex = 10012
        Me.DataGridEx1.TabStop = False
        '
        'cnt
        '
        Me.cnt.BackColor = System.Drawing.SystemColors.Control
        Me.cnt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cnt.ForeColor = System.Drawing.Color.Black
        Me.cnt.Location = New System.Drawing.Point(924, 440)
        Me.cnt.Name = "cnt"
        Me.cnt.Size = New System.Drawing.Size(104, 28)
        Me.cnt.TabIndex = 10013
        Me.cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Enabled = False
        Me.Button5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(908, 116)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 32)
        Me.Button5.TabIndex = 10014
        Me.Button5.Text = "商品詳細"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1106, 525)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.cnt)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.slct)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txt_no)
        Me.Controls.Add(Me.lbl_corp_flg)
        Me.Controls.Add(Me.lbl_pref)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lbl_wrnttl)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lbl_shop)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txt_shop_code)
        Me.Controls.Add(Me.txt_phone)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cust_fname)
        Me.Controls.Add(Me.cust_lname)
        Me.Controls.Add(Me.txt_adrs2)
        Me.Controls.Add(Me.txt_adrs1)
        Me.Controls.Add(Me.txt_city)
        Me.Controls.Add(Me.txt_zip)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date_ent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "保証内容検索 Var 2.0"
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_city, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_adrs2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_lname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_fname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_phone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_shop_code, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()
        inz()       '**  初期処理
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        slct.Text = "1"

        Call sql0()     '保証データ_マスタ
        Call sql()      '保証データ_サブ

        tbl = DsList1.Tables("Wrn_sub")
        DGTS.MappingName = "Wrn_sub"
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

        Dim dc As DataColumn
        dc = New DataColumn("Column1", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column2", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column3", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column4", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column5", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column6", GetType(Integer))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column7", GetType(DateTime))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column16", GetType(DateTime))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column8", GetType(Integer))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column9", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column10", GetType(DateTime))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column11", GetType(Integer))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column12", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column13", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column14", GetType(Integer))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column15", GetType(String))
        tbl.Columns.Add(dc)

        With style15
            .FormatInfo = Nothing
            .HeaderText = "保証種類"
            .MappingName = "corp"
            .ReadOnly = True
            .Width = 40
        End With

        With style01
            .FormatInfo = Nothing
            .HeaderText = "商品名"
            .MappingName = "cat_name"
            .ReadOnly = True
            .Width = 112
        End With

        With style02
            .FormatInfo = Nothing
            .HeaderText = "メーカー"
            .MappingName = "vdr_name"
            .ReadOnly = True
            .Width = 112
        End With

        With style03
            .FormatInfo = Nothing
            .HeaderText = "型  式"
            .MappingName = "model_name"
            .ReadOnly = True
            .Width = 156
        End With

        With style04
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "品種"
            .MappingName = "item_cat_code"
            .ReadOnly = True
            .Width = 52
        End With

        With style05
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "POSコード"
            .MappingName = "pos_code"
            .ReadOnly = True
            .Width = 72
        End With

        With style06
            .Alignment = System.Windows.Forms.HorizontalAlignment.Right
            .Format = "##,##0"
            .FormatInfo = Nothing
            .HeaderText = "購入価格（税込）"
            .MappingName = "prch_price"
            .NullText = ""
            .ReadOnly = True
            .Width = 76
        End With

        With style07
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "受注日"
            .MappingName = "prch_date"
            .NullText = ""
            .ReadOnly = True
            .Width = 88
        End With

        With style16
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "完了日"
            .MappingName = "fin_date"
            .NullText = ""
            .ReadOnly = True
            .Width = 88
        End With

        With style08
            .Alignment = System.Windows.Forms.HorizontalAlignment.Right
            .Format = "##,##0"
            .FormatInfo = Nothing
            .HeaderText = "保証料（税抜）"
            .MappingName = "wrn_fee"
            .NullText = ""
            .ReadOnly = True
            .Width = 72
        End With

        With style09
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "契約"
            .MappingName = "cont_flg"
            .NullText = ""
            .ReadOnly = True
            .Width = 24
        End With

        With style10
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "取消日"
            .MappingName = "cxl_date"
            .NullText = ""
            .ReadOnly = True
            .Width = 88
        End With

        With style11
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "保証期間"
            .MappingName = "wrn_prod"
            .NullText = ""
            .ReadOnly = True
            .Width = 44
        End With

        With style12
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = Nothing
            .MappingName = "ivc"
            .NullText = ""
            .ReadOnly = True
            .Width = 48
        End With

        With style13
            .HeaderText = Nothing
            .MappingName = "line_no"
            .ReadOnly = True
            .Width = 0
        End With

        With style14
            .HeaderText = Nothing
            .MappingName = "seq"
            .ReadOnly = True
            .Width = 0
        End With

        DGTS.GridColumnStyles.Add(style15)
        DGTS.GridColumnStyles.Add(style01)
        DGTS.GridColumnStyles.Add(style02)
        DGTS.GridColumnStyles.Add(style03)
        DGTS.GridColumnStyles.Add(style04)
        DGTS.GridColumnStyles.Add(style05)
        DGTS.GridColumnStyles.Add(style06)
        DGTS.GridColumnStyles.Add(style07)
        DGTS.GridColumnStyles.Add(style16)
        DGTS.GridColumnStyles.Add(style08)
        DGTS.GridColumnStyles.Add(style09)
        DGTS.GridColumnStyles.Add(style10)
        DGTS.GridColumnStyles.Add(style11)
        DGTS.GridColumnStyles.Add(style12)
        DGTS.GridColumnStyles.Add(style13)
        DGTS.GridColumnStyles.Add(style14)
        DataGridEx1.TableStyles.Add(DGTS)

        DGTS.RowHeaderWidth = 10

        Call initial()
    End Sub

    Sub sql0()      '保証データ_マスタ
        DsList1.Clear()

        strSQL = "SELECT Wrn_mtr.*, Pref_mtr.都道府県名 as pref_name, Shop_mtr.[店舗名(漢字)] as shop_name"
        strSQL += " FROM Wrn_mtr INNER JOIN "
        strSQL += " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code AND Wrn_mtr.BY_cls = Shop_mtr.BY_cls LEFT OUTER JOIN"
        strSQL += " Pref_mtr ON Wrn_mtr.pref_code = Pref_mtr.pref_code"
        strWH = " WHERE"

        If slct.Text = "1" Then
            strWH = strWH & " (Wrn_mtr.ordr_no = '" & Trim(txt_no.Text) & "')"
        Else
            Dim and_F As String = "0"
            If Trim(txt_no.Text) <> Nothing Then
                strWH = strWH & " (Wrn_mtr.ordr_no LIKE '" & Trim(txt_no.Text) & "%')"
                and_F = "1"
            End If
            If cust_lname.Text <> Nothing Then
                If and_F = "1" Then strWH = strWH & " AND"
                strWH = strWH & " (Wrn_mtr.cust_lname LIKE '" & cust_lname.Text & "%')"
                and_F = "1"
            End If
            If txt_phone.Text <> Nothing Then
                If and_F = "1" Then strWH = strWH & " AND"
                strWH = strWH & " (Wrn_mtr.srch_phn LIKE '" & txt_phone.Text & "%')"
            End If
        End If
        strSQL += strWH
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("best_wrn")
        r = DaList1.Fill(DsList1, "wrn_mtr")
        DB_CLOSE()

    End Sub

    Sub sql()       '保証データ_サブ
        sum = 0

        strSQL = "SELECT V_Cat_mtr.[品種名(漢字)] AS cat_name, vdr_mtr.vdr_name, RTRIM(dbo.Wrn_sub.model_name) AS model_name"
        strSQL += ", Wrn_sub.item_cat_code, Wrn_sub.pos_code, Wrn_sub.prch_price + Wrn_sub.prch_tax AS prch_price"
        strSQL += ", Wrn_sub.prch_date, Wrn_sub.wrn_fee, Wrn_sub.cont_flg, Wrn_sub.cxl_date, Wrn_sub.wrn_prod"
        strSQL += ", xa.ordr_no AS ivc, Wrn_sub.ordr_no, Wrn_sub.line_no, Wrn_sub.seq, Wrn_sub.bend_code"
        strSQL += ", Wrn_sub.total_loss_flg, total_loss.total_loss_date, V_cls_015.CLS_CODE_NAME AS corp"
        strSQL += ", Wrn_sub_2.wrn_prod2, Wrn_sub.fin_date"
        strSQL += " FROM Wrn_sub INNER JOIN"
        strSQL += " vdr_mtr ON Wrn_sub.bend_code = vdr_mtr.vdr_code AND Wrn_sub.BY_cls = vdr_mtr.BY_cls INNER JOIN"
        strSQL += " V_Cat_mtr ON Wrn_sub.item_cat_code = V_Cat_mtr.cd12 AND Wrn_sub.BY_cls = V_Cat_mtr.BY_cls LEFT OUTER JOIN"
        strSQL += " Wrn_sub_2 ON Wrn_sub.seq = Wrn_sub_2.seq AND Wrn_sub.line_no = Wrn_sub_2.line_no AND "
        strSQL += " Wrn_sub.ordr_no = Wrn_sub_2.ordr_no LEFT OUTER JOIN"
        strSQL += " V_cls_015 ON Wrn_sub.corp_flg = V_cls_015.CLS_CODE LEFT OUTER JOIN"
        strSQL += " total_loss ON Wrn_sub.seq = total_loss.seq AND Wrn_sub.ordr_no = total_loss.ordr_no AND "
        strSQL += " Wrn_sub.line_no = total_loss.line_no LEFT OUTER JOIN"
        strSQL += " (SELECT ordr_no, line_no, seq FROM Wrn_ivc GROUP BY ordr_no, line_no, seq HAVING (ordr_no = '" & txt_no.Text & "')) AS xa"
        strSQL += " ON Wrn_sub.ordr_no = xa.ordr_no AND Wrn_sub.line_no = xa.line_no AND "
        strSQL += " Wrn_sub.seq = xa.seq"
        strSQL += " WHERE (Wrn_sub.ordr_no = '" & txt_no.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("best_wrn")
        DaList1.Fill(DsList1, "Wrn_sub")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1
            If Not IsDBNull(DtView1(i)("ivc")) Then
                DtView1(i)("ivc") = "事故"
            End If
            If Not IsDBNull(DtView1(i)("wrn_prod2")) Then
                DtView1(i)("wrn_prod") = DtView1(i)("wrn_prod2")
            End If
            sum = sum + DtView1(i)("wrn_fee")
            lbl_wrnttl.Text = Format(sum, "##,##0")
            'If Not IsDBNull(DtView1(i)("total_loss_flg")) Then  '2013/10/07 全損Z表示
            '    If DtView1(i)("total_loss_flg") = "1" Then
            '        DtView1(i)("cont_flg") = "Z"
            '    End If
            'End If
        Next
        If DtView1.Count <> 0 Then cnt.Text = Format(DtView1.Count, "##,##0") & "件"
        WK_cnt = DtView1.Count
        WK_strSQL = strSQL
    End Sub

    '検索
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If txt_no.Text = Nothing And cust_lname.Text = Nothing And txt_phone.Text = Nothing Then
            MessageBox.Show("検索キーを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_no.Focus()
        Else

re_scn:
            Call sql0()     '保証データ_マスタ

            Select Case r
                Case Is = 0
                    MessageBox.Show("該当するデータはありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case Is = 1
                    DtView1 = New DataView(DsList1.Tables("wrn_mtr"), "", "", DataViewRowState.CurrentRows)
                    Call disp_main()
                Case Is <= 100
                    P_DsList1.Clear()
                    strSQL = "SELECT Wrn_mtr.ordr_no, RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS cust_name"
                    strSQL += ", Wrn_mtr.srch_phn, Pref_mtr.都道府県名 AS pref_name, Wrn_sub.prch_date, Wrn_sub.cont_flg"
                    strSQL += ", Shop_mtr.[店舗名(漢字)] AS shop_name"
                    strSQL += " FROM Wrn_mtr INNER JOIN"
                    strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
                    strSQL += " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code AND Wrn_mtr.BY_cls = Shop_mtr.BY_cls LEFT OUTER JOIN"
                    strSQL += " Pref_mtr ON Wrn_mtr.pref_code = Pref_mtr.pref_code"
                    strSQL += strWH
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN("best_wrn")
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

        If Not IsDBNull(DtView1(0)("s_flg")) Then
            If DtView1(0)("s_flg") = "1" Then
                MsgBox("ソニア引受分")
            End If
        End If
        If Not IsDBNull(DtView1(0)("b_flg")) Then
            If DtView1(0)("b_flg") = "1" Then
                MsgBox("ベスト引受分")
            End If
        End If

        txt_no.Text = DtView1(0)("ordr_no")
        Date_ent.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(Year(DtView1(0)("entry_date")), Month(DtView1(0)("entry_date")), Format(DtView1(0)("entry_date"), "dd"), 0, 0, 0))
        cust_lname.Text = DtView1(0)("cust_lname")
        cust_fname.Text = DtView1(0)("cust_fname")
        txt_phone.Text = RTrim(DtView1(0)("srch_phn"))
        txt_zip.Value = DtView1(0)("zip_code")
        txt_city.Text = DtView1(0)("city_name")
        txt_adrs1.Text = DtView1(0)("adrs1")
        If Not IsDBNull(DtView1(0)("adrs2")) Then txt_adrs2.Text = DtView1(0)("adrs2") Else txt_adrs2.Text = Nothing
        txt_shop_code.Text = DtView1(0)("shop_code")
        lbl_shop.Text = DtView1(0)("shop_name")

        k = 1

        If Not IsDBNull(DtView1(0)("pref_name")) Then lbl_pref.Text = DtView1(0)("pref_name") Else lbl_pref.Text = Nothing

        'memo
        Button4.Enabled = True
        strSQL = "SELECT * FROM Memo WHERE (ordr_no = '" & txt_no.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("best_wrn")
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

        Button5.Enabled = True
        Call sql()      '保証データ_サブ
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Column = 13 And hitinfo.Row >= 0 Then
                If Not IsDBNull(DataGridEx1(DataGridEx1.CurrentRowIndex, 12)) Then
                    p_ordr_no = txt_no.Text
                    p_line_no = DataGridEx1(DataGridEx1.CurrentRowIndex, 14)
                    p_seq = DataGridEx1(DataGridEx1.CurrentRowIndex, 15)

                    Dim frmform2 As New Form2
                    frmform2.ShowDialog()
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '**********************************
    '**  メモボタン
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

    '**********************************
    '**  商品詳細
    '**********************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        p_ordr_no = txt_no.Text

        Dim frmform4 As New Form4
        frmform4.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '画面の初期化
    Sub initial()

        'lbl_corp_flg.Text = Nothing
        txt_no.Text = Nothing
        slct.Text = Nothing
        Date_ent.Number = 0
        cust_lname.Text = Nothing
        cust_fname.Text = Nothing
        txt_phone.Text = Nothing
        txt_zip.Text = Nothing
        txt_city.Text = Nothing
        txt_adrs1.Text = Nothing
        txt_adrs2.Text = Nothing
        txt_shop_code.Text = Nothing
        lbl_shop.Text = Nothing
        lbl_wrnttl.Text = Nothing
        cnt.Text = Nothing
        lbl_pref.Text = Nothing

        If WK_cnt = 1 Then
            SqlCmd1 = New SqlClient.SqlCommand("SELECT '' AS cat_name, '' AS vdr_name, '' AS model_name, '' AS item_cat_code, '' AS pos_code, 0 AS prch_price, NULL AS prch_date, 0 AS wrn_fee, 0 AS cont_flg, NULL AS cxl_date, 0 AS wrn_prod, '' AS ivc, '' AS ordr_no, '' AS line_no, 0 AS seq, '' AS bend_code, 0 AS total_loss_flg, NULL AS total_loss_date", cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "Wrn_sub")
        End If

        Dim curCell As DataGridCell = DataGridEx1.CurrentCell
        If curCell.RowNumber = 0 Then
            DataGridEx1.CurrentCell = New DataGridCell(1, curCell.ColumnNumber)
            DataGridEx1.CurrentCell = New DataGridCell(1, 14)
        Else
            DataGridEx1.CurrentCell = New DataGridCell(0, curCell.ColumnNumber)
            DataGridEx1.CurrentCell = New DataGridCell(0, 14)
        End If

        DsList1.Clear()

        Button4.Enabled = False        'memo
        Button4.BackColor = System.Drawing.SystemColors.Control
        Button5.Enabled = False        '商品詳細

    End Sub
End Class
