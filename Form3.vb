Public Class Form3
    Inherits System.Windows.Forms.Form

    Dim dsItem1, dsItem2, dsItem3, dsItem4, dsWrnMtr, dsWrnSub As New DataSet
    Dim DtView1, DtView5, DtView12 As DataView
    Dim dttbl_mtr, dttbl_sub As DataTable
    Dim prch_price(99), prch_tax(99), wrn_fee(99), wrn_tax(99) As Integer
    Dim Line_No, x, i, j, k, r As Integer
    Dim strSQL, strSQL2, err_flg, chk_flg, Add_flg As String
    Dim empl_code As Integer

    Dim label(99, 9) As label
    Dim cmbbox(99, 9) As ComboBox
    Dim edit(99, 9) As GrapeCity.Win.Input.Interop.Edit
    Dim num(99, 9) As GrapeCity.Win.Input.Interop.Number
    Dim datBox(99, 9) As GrapeCity.Win.Input.Interop.Date
    Dim btn(99, 9) As Button

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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
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
    Friend WithEvents txt_no As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbx_pref As System.Windows.Forms.ComboBox
    Friend WithEvents txt_phone As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_shop_code As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lbl_shop As System.Windows.Forms.Label
    Friend WithEvents cnt_flg As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lbl_wrnttl As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cbx_pref = New System.Windows.Forms.ComboBox()
        Me.Date_ent = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_zip = New GrapeCity.Win.Input.Interop.Mask()
        Me.txt_no = New GrapeCity.Win.Input.Interop.Mask()
        Me.txt_city = New GrapeCity.Win.Input.Interop.Edit()
        Me.txt_adrs1 = New GrapeCity.Win.Input.Interop.Edit()
        Me.txt_adrs2 = New GrapeCity.Win.Input.Interop.Edit()
        Me.cust_lname = New GrapeCity.Win.Input.Interop.Edit()
        Me.cust_fname = New GrapeCity.Win.Input.Interop.Edit()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_phone = New GrapeCity.Win.Input.Interop.Edit()
        Me.txt_shop_code = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbl_shop = New System.Windows.Forms.Label()
        Me.cnt_flg = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lbl_wrnttl = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pos = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_city, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_adrs2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_lname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_fname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_phone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_shop_code, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbx_pref
        '
        Me.cbx_pref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_pref.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_pref.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbx_pref.Location = New System.Drawing.Point(616, 95)
        Me.cbx_pref.Name = "cbx_pref"
        Me.cbx_pref.Size = New System.Drawing.Size(120, 25)
        Me.cbx_pref.TabIndex = 15
        '
        'Date_ent
        '
        Me.Date_ent.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_ent.DropDownCalendar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.DropDownCalendar.Size = New System.Drawing.Size(186, 207)
        Me.Date_ent.ExitOnLastChar = True
        Me.Date_ent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Date_ent.Location = New System.Drawing.Point(760, 52)
        Me.Date_ent.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        Me.Date_ent.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        Me.Date_ent.Name = "Date_ent"
        Me.Date_ent.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date_ent.Size = New System.Drawing.Size(120, 27)
        Me.Date_ent.TabIndex = 2
        Me.Date_ent.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_ent.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date_ent.Value = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(672, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 26)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "申込日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 35)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "商品名"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(128, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 35)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "メーカー"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(248, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 35)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "型  式"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkBlue
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(416, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 17)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "品種コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkBlue
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(416, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 18)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "（部門）（品種）"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkBlue
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(504, 234)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 35)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "POSコード"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkBlue
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(576, 234)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 35)
        Me.Label10.TabIndex = 29
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(660, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 35)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "購入日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkBlue
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(744, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 35)
        Me.Label12.TabIndex = 32
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(672, 520)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 35)
        Me.Button2.TabIndex = 101
        Me.Button2.Text = "クリア"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 156)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 26)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "電話番号"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 52)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "使用者"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkBlue
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(72, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 26)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "（姓）"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DarkBlue
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(72, 121)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 26)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "（名）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkBlue
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(672, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 26)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "No."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_zip
        '
        Me.txt_zip.ExitOnLastChar = True
        Me.txt_zip.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_zip.Format = New GrapeCity.Win.Input.Interop.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.txt_zip.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_zip.Location = New System.Drawing.Point(432, 95)
        Me.txt_zip.Name = "txt_zip"
        Me.txt_zip.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_zip.Size = New System.Drawing.Size(88, 27)
        Me.txt_zip.TabIndex = 14
        Me.txt_zip.Value = ""
        '
        'txt_no
        '
        Me.txt_no.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_no.ExitOnLastChar = True
        Me.txt_no.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no.Format = New GrapeCity.Win.Input.Interop.MaskFormat("110 - \D{14}", "", "")
        Me.txt_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_no.Location = New System.Drawing.Point(720, 17)
        Me.txt_no.Name = "txt_no"
        Me.txt_no.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_no.Size = New System.Drawing.Size(160, 27)
        Me.txt_no.TabIndex = 1
        Me.txt_no.Value = ""
        '
        'txt_city
        '
        Me.txt_city.AllowSpace = False
        Me.txt_city.ExitOnLastChar = True
        Me.txt_city.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_city.Format = "K"
        Me.txt_city.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_city.LengthAsByte = True
        Me.txt_city.Location = New System.Drawing.Point(432, 121)
        Me.txt_city.MaxLength = 24
        Me.txt_city.Name = "txt_city"
        Me.txt_city.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_city.Size = New System.Drawing.Size(304, 27)
        Me.txt_city.TabIndex = 16
        Me.txt_city.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_city.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs1
        '
        Me.txt_adrs1.AllowSpace = False
        Me.txt_adrs1.ExitOnLastChar = True
        Me.txt_adrs1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs1.Format = "AaK#@"
        Me.txt_adrs1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs1.LengthAsByte = True
        Me.txt_adrs1.Location = New System.Drawing.Point(432, 147)
        Me.txt_adrs1.MaxLength = 36
        Me.txt_adrs1.Name = "txt_adrs1"
        Me.txt_adrs1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_adrs1.Size = New System.Drawing.Size(304, 27)
        Me.txt_adrs1.TabIndex = 17
        Me.txt_adrs1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs2
        '
        Me.txt_adrs2.AllowSpace = False
        Me.txt_adrs2.ExitOnLastChar = True
        Me.txt_adrs2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs2.Format = "AaK#@"
        Me.txt_adrs2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs2.LengthAsByte = True
        Me.txt_adrs2.Location = New System.Drawing.Point(432, 173)
        Me.txt_adrs2.MaxLength = 36
        Me.txt_adrs2.Name = "txt_adrs2"
        Me.txt_adrs2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_adrs2.Size = New System.Drawing.Size(304, 27)
        Me.txt_adrs2.TabIndex = 18
        Me.txt_adrs2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_lname
        '
        Me.cust_lname.AllowSpace = False
        Me.cust_lname.ExitOnLastChar = True
        Me.cust_lname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_lname.Format = "AaK"
        Me.cust_lname.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cust_lname.LengthAsByte = True
        Me.cust_lname.Location = New System.Drawing.Point(128, 95)
        Me.cust_lname.MaxLength = 15
        Me.cust_lname.Name = "cust_lname"
        Me.cust_lname.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_lname.Size = New System.Drawing.Size(176, 27)
        Me.cust_lname.TabIndex = 11
        Me.cust_lname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_lname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_fname
        '
        Me.cust_fname.AllowSpace = False
        Me.cust_fname.ExitOnLastChar = True
        Me.cust_fname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_fname.Format = "AaK"
        Me.cust_fname.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cust_fname.LengthAsByte = True
        Me.cust_fname.Location = New System.Drawing.Point(128, 121)
        Me.cust_fname.MaxLength = 15
        Me.cust_fname.Name = "cust_fname"
        Me.cust_fname.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_fname.Size = New System.Drawing.Size(176, 27)
        Me.cust_fname.TabIndex = 12
        Me.cust_fname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_fname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(776, 520)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 35)
        Me.Button3.TabIndex = 103
        Me.Button3.Text = "戻 る"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(520, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 26)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "都道府県"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(336, 121)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 26)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "市区町村名"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkBlue
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(336, 147)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 26)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "住所1"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkBlue
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(336, 173)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 26)
        Me.Label20.TabIndex = 107
        Me.Label20.Text = "住所2"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkBlue
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(336, 95)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 26)
        Me.Label21.TabIndex = 108
        Me.Label21.Text = "郵便番号"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_phone
        '
        Me.txt_phone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_phone.Format = "9#"
        Me.txt_phone.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_phone.Location = New System.Drawing.Point(128, 156)
        Me.txt_phone.MaxLength = 15
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_phone.Size = New System.Drawing.Size(176, 27)
        Me.txt_phone.TabIndex = 13
        '
        'txt_shop_code
        '
        Me.txt_shop_code.AllowSpace = False
        Me.txt_shop_code.ExitOnLastChar = True
        Me.txt_shop_code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_shop_code.Format = "9"
        Me.txt_shop_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_shop_code.LengthAsByte = True
        Me.txt_shop_code.Location = New System.Drawing.Point(88, 494)
        Me.txt_shop_code.MaxLength = 4
        Me.txt_shop_code.Name = "txt_shop_code"
        Me.txt_shop_code.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_shop_code.Size = New System.Drawing.Size(64, 35)
        Me.txt_shop_code.TabIndex = 31
        Me.txt_shop_code.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.txt_shop_code.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(16, 494)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 35)
        Me.Label22.TabIndex = 125
        Me.Label22.Text = "店コード"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_shop
        '
        Me.lbl_shop.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lbl_shop.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shop.ForeColor = System.Drawing.Color.Navy
        Me.lbl_shop.Location = New System.Drawing.Point(224, 494)
        Me.lbl_shop.Name = "lbl_shop"
        Me.lbl_shop.Size = New System.Drawing.Size(248, 35)
        Me.lbl_shop.TabIndex = 126
        Me.lbl_shop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cnt_flg
        '
        Me.cnt_flg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cnt_flg.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cnt_flg.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cnt_flg.Items.AddRange(New Object() {"0-個人", "1-法人"})
        Me.cnt_flg.Location = New System.Drawing.Point(128, 61)
        Me.cnt_flg.Name = "cnt_flg"
        Me.cnt_flg.Size = New System.Drawing.Size(80, 25)
        Me.cnt_flg.TabIndex = 10
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkBlue
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(16, 61)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 26)
        Me.Label23.TabIndex = 128
        Me.Label23.Text = "契約者タイプ"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_wrnttl
        '
        Me.lbl_wrnttl.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lbl_wrnttl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wrnttl.ForeColor = System.Drawing.Color.Navy
        Me.lbl_wrnttl.Location = New System.Drawing.Point(704, 468)
        Me.lbl_wrnttl.Name = "lbl_wrnttl"
        Me.lbl_wrnttl.Size = New System.Drawing.Size(104, 35)
        Me.lbl_wrnttl.TabIndex = 129
        Me.lbl_wrnttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkBlue
        Me.Label24.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(592, 468)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 35)
        Me.Label24.TabIndex = 130
        Me.Label24.Text = "保証料合計"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pos)
        Me.Panel1.Location = New System.Drawing.Point(8, 269)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(880, 190)
        Me.Panel1.TabIndex = 10000
        '
        'pos
        '
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(1, 1)
        Me.pos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(152, 494)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 35)
        Me.Label1.TabIndex = 10001
        Me.Label1.Text = "店舗名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Salmon
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(560, 520)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 35)
        Me.Button1.TabIndex = 10002
        Me.Button1.Text = "修 正"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label25.Location = New System.Drawing.Point(416, 23)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(248, 17)
        Me.Label25.TabIndex = 10003
        Me.Label25.Text = "伝票番号を入力すると検索を行います →"
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(896, 625)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lbl_wrnttl)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cnt_flg)
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
        Me.Controls.Add(Me.txt_no)
        Me.Controls.Add(Me.txt_zip)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date_ent)
        Me.Controls.Add(Me.cbx_pref)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "延長保証データ修正"
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_zip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_city, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_adrs2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_lname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_fname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_phone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_shop_code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        k = 0
        empl_code = 1

        Label10.Text = "購入価格" & vbCrLf & "（税込）"
        Label12.Text = "保証料" & vbCrLf & "（税込）"

        '都道府県マスタ
        Dim SqlSelectCommand1 As New SqlClient.SqlCommand
        SqlSelectCommand1 = New SqlClient.SqlCommand("SELECT pref_code, 都道府県名 AS pref_name FROM pref_mtr", cnsqlclient)
        SqlSelectCommand1.CommandType = CommandType.Text
        Dim daItem1 As New SqlClient.SqlDataAdapter
        daItem1.SelectCommand = SqlSelectCommand1

        '品種マスタ
        Dim SqlSelectCommand2 As New SqlClient.SqlCommand
        SqlSelectCommand2 = New SqlClient.SqlCommand("SELECT cd1, cd2, cd3, [品種名(漢字)] as cat_name, [品種名(ｶﾅ)] as cat_kana FROM cat_mtr WHERE (BY_cls = 'Y')", cnsqlclient)
        SqlSelectCommand2.CommandType = CommandType.Text
        Dim daItem2 As New SqlClient.SqlDataAdapter
        daItem2.SelectCommand = SqlSelectCommand2

        '店舗マスタ
        Dim SqlSelectCommand4 As New SqlClient.SqlCommand
        SqlSelectCommand4 = New SqlClient.SqlCommand("SELECT shop_code, [店舗名(漢字)] as shop_name, close_date FROM shop_mtr WHERE (BY_cls = 'Y')", cnsqlclient)
        SqlSelectCommand4.CommandType = CommandType.Text
        Dim daItem4 As New SqlClient.SqlDataAdapter
        daItem4.SelectCommand = SqlSelectCommand4

        DB_OPEN("best_wrn")
        daItem1.Fill(dsItem1, "pref")
        daItem2.Fill(dsItem2, "cat")
        daItem4.Fill(dsItem4, "shop")
        DB_CLOSE()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'MODIFY
        If r = 1 Then
            Call err_chk()  'Error Check 
            If err_flg = "0" Then
                Call modify()   'Update
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'CANCEL
        Call initial()
        Line_No = -1
        txt_no.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Back To Menu
        Me.Close()
        Dim Menu As New Menu
        Menu.Show()
    End Sub

    'メインデータ表示
    Sub disp_main()

        dttbl_mtr = dsWrnMtr.Tables("wrn_mtr")

        txt_no.Text = "110 - " & dttbl_mtr.Rows(0)("ordr_no")
        ' Date_ent.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(Year(dttbl_mtr.Rows(0)("entry_date")), Month(dttbl_mtr.Rows(0)("entry_date")), Format(dttbl_mtr.Rows(0)("entry_date"), "dd"), 0, 0, 0, 0))
        cust_lname.Text = dttbl_mtr.Rows(0)("cust_lname")
        cust_fname.Text = dttbl_mtr.Rows(0)("cust_fname")
        txt_phone.Text = dttbl_mtr.Rows(0)("srch_phn")
        txt_zip.Value = dttbl_mtr.Rows(0)("zip_code")
        txt_city.Text = dttbl_mtr.Rows(0)("city_name")
        txt_adrs1.Text = dttbl_mtr.Rows(0)("adrs1")
        txt_adrs2.Text = dttbl_mtr.Rows(0)("adrs2")

        txt_shop_code.Text = dttbl_mtr.Rows(0)("shop_code")
        DtView5 = New DataView(dsItem4.Tables("shop"), "shop_code ='" & txt_shop_code.Text & "'", "", DataViewRowState.CurrentRows)
        lbl_shop.Text = DtView5(0)("shop_name")

        If dttbl_mtr.Rows(0)("corp_flg") = "1" Then
            cnt_flg.SelectedItem = "1-個人"
        ElseIf dttbl_mtr.Rows(0)("corp_flg") = "2" Then
            cnt_flg.SelectedItem = "2-法人"
        End If

        k = 1

        cbx_pref.DataSource = dsItem1
        cbx_pref.DisplayMember = "pref.pref_name"
        cbx_pref.ValueMember = "pref.pref_code"
        cbx_pref.SelectedValue = dttbl_mtr.Rows(0)("pref_code")

        Call disp_sub()

    End Sub

    'サブデータ表示
    Sub disp_sub()

        '保証データ_サブ
        Dim SqlSelectCommand As New SqlClient.SqlCommand
        strSQL = "SELECT ordr_no, line_no, prch_price, prch_tax, prch_date,"
        strSQL += " item_cat_code, cat_name, bend_code, brnd_name, "
        strSQL += " model_name, pos_code, wrn_fee"
        strSQL += " FROM Wrn_sub"
        strSQL += " WHERE ordr_no = '" & dttbl_mtr.Rows(0)("ordr_no") & "'"
        strSQL += " ORDER BY line_no"

        SqlSelectCommand = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dim daWrnSub As New SqlClient.SqlDataAdapter
        daWrnSub.SelectCommand = SqlSelectCommand

        dsWrnSub.Clear()
        Try
            DB_OPEN("best_wrn")
            daWrnSub.Fill(dsWrnSub, "wrn_sub")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            DB_CLOSE()
        End Try

        dttbl_sub = dsWrnSub.Tables("wrn_sub")

        If dttbl_sub.Rows.Count <> 0 Then
            MessageBox.Show("この伝票番号には、既に商品情報が存在します。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call initial()
            Line_No = -1
            txt_no.Focus()
        End If

    End Sub

    Sub ADD_LINE()

        Line_No = Line_No + 1

        '商品名
        x = 0
        label(Line_No, x) = New Label
        label(Line_No, x).BackColor = System.Drawing.Color.LightSkyBlue
        label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        label(Line_No, x).ForeColor = System.Drawing.Color.Navy
        label(Line_No, x).Location = New System.Drawing.Point(0, 25 * Line_No + pos.Location.Y)
        label(Line_No, x).Name = "lbl_item1"
        label(Line_No, x).Size = New System.Drawing.Size(120, 24)
        label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))

        'メーカー
        Dim SqlSelectCommand3 As New SqlClient.SqlCommand
        SqlSelectCommand3 = New SqlClient.SqlCommand("SELECT vdr_code, vdr_name FROM vdr_mtr ORDER BY use_date DESC, vdr_name", cnsqlclient)
        SqlSelectCommand3.CommandType = CommandType.Text
        Dim daItem3 As New SqlClient.SqlDataAdapter
        daItem3.SelectCommand = SqlSelectCommand3

        DB_OPEN("best_wrn")
        daItem3.Fill(dsItem3, "vdr" & Line_No)
        DB_CLOSE()

        x = 0
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(120, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).DropDownWidth = 180
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = 202
        cmbbox(Line_No, x).DataSource = dsItem3
        cmbbox(Line_No, x).DisplayMember = "vdr" & Line_No & ".vdr_name"
        cmbbox(Line_No, x).ValueMember = "vdr" & Line_No & ".vdr_code"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing

        '型式
        x = 0
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "AaK#@"
        edit(Line_No, x).MaxLength = 20
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
        edit(Line_No, x).Location = New System.Drawing.Point(240, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(167, 24)
        edit(Line_No, x).TabIndex = 203
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))

        '品種コード(部門)
        x = 1
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).AllowSpace = False
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "9"
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(408, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 2
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(43, 24)
        edit(Line_No, x).TabIndex = 204
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))
        AddHandler edit(Line_No, x).Leave, AddressOf cat1_Leave

        '品種コード(品種)
        x = 2
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).AllowSpace = False
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "9"
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(452, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 2
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(43, 24)
        edit(Line_No, x).TabIndex = 205
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Panel1.Controls.Add(edit(Line_No, x))
        AddHandler edit(Line_No, x).Leave, AddressOf cat2_Leave

        'POSコード
        x = 3
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "9"
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(496, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 8
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(71, 24)
        edit(Line_No, x).TabIndex = 206
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))

        '購入金額
        x = 0
        num(Line_No, x) = New GrapeCity.Win.Input.Interop.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.Interop.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(568, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        num(Line_No, x).Size = New System.Drawing.Size(83, 24)
        num(Line_No, x).TabIndex = 207
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        AddHandler num(Line_No, x).Leave, AddressOf prch_Leave

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
        datBox(Line_No, x).Location = New System.Drawing.Point(652, 25 * Line_No + pos.Location.Y)
        datBox(Line_No, x).MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        datBox(Line_No, x).MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        datBox(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        datBox(Line_No, x).Size = New System.Drawing.Size(84, 24)
        datBox(Line_No, x).TabIndex = 208
        datBox(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        datBox(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        datBox(Line_No, x).Tag = Line_No
        datBox(Line_No, x).Value = Nothing
        datBox(Line_No, x).Text = "____/__/__"
        Panel1.Controls.Add(datBox(Line_No, x))
        AddHandler datBox(Line_No, x).Leave, AddressOf DRWG_chg

        '保証料
        x = 1
        label(Line_No, x) = New Label
        label(Line_No, x).BackColor = System.Drawing.Color.LightSkyBlue
        label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        label(Line_No, x).ForeColor = System.Drawing.Color.Navy
        label(Line_No, x).Location = New System.Drawing.Point(736, 25 * Line_No + pos.Location.Y)
        label(Line_No, x).Tag = Line_No
        label(Line_No, x).Size = New System.Drawing.Size(70, 24)
        label(Line_No, x).TabIndex = 209
        label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleRight
        label(Line_No, x).Text = 0
        Panel1.Controls.Add(label(Line_No, x))

        '商品名ｶﾅ
        x = 2
        label(Line_No, x) = New Label
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))

        '複ボタン
        x = 0
        btn(Line_No, x) = New Button
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Location = New Drawing.Point(810, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "複"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf c_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

        '削ボタン
        x = 1
        btn(Line_No, x) = New Button
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Location = New Drawing.Point(836, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "削"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(0, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf d_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

        cmbbox(Line_No, 0).Focus()

    End Sub

    '画面の初期化
    Sub initial()

        txt_no.Text = Nothing
        Date_ent.Text = "____/__/__"
        cust_lname.Text = Nothing
        cust_fname.Text = Nothing
        txt_phone.Text = Nothing
        txt_zip.Text = Nothing
        txt_city.Text = Nothing
        txt_adrs1.Text = Nothing
        txt_adrs2.Text = Nothing
        txt_shop_code.Text = Nothing
        lbl_shop.Text = Nothing
        lbl_wrnttl.Text = 0

        cbx_pref.DataSource = dsItem1
        cbx_pref.DisplayMember = "pref.pref_name"
        cbx_pref.ValueMember = "pref.pref_code"
        cbx_pref.SelectedValue = "01"

        dsItem3.Clear()
        Panel1.Controls.Clear()

    End Sub

    'データ修正、追加
    Sub modify()

        Dim DaWrn_mtr As New SqlClient.SqlDataAdapter
        Dim DsWrn_mtr As New DataSet
        Dim SqlSelectCommand1 As New SqlClient.SqlCommand

        strSQL = "SELECT ordr_no FROM Wrn_mtr WHERE ordr_no = '" & txt_no.Value & "'"
        SqlSelectCommand1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        Dim daOrdr As New SqlClient.SqlDataAdapter
        Dim dsOrdr As New DataSet
        Dim r As Integer
        daOrdr.SelectCommand = SqlSelectCommand1

        Try
            DB_OPEN("best_wrn")
            r = daOrdr.Fill(dsOrdr)
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            DB_CLOSE()
        End Try

        If r < 2 Then
            strSQL = "UPDATE Wrn_mtr SET"
            strSQL += " ordr_no = '" & txt_no.Value & "'"
            strSQL += ", cust_fname = '" & cust_fname.Text & "'"
            strSQL += ", cust_lname = '" & cust_lname.Text & "'"
            strSQL += ", adrs1 = '" & txt_adrs1.Text & "'"
            strSQL += ", adrs2 = '" & txt_adrs2.Text & "'"
            strSQL += ", city_name = '" & txt_city.Text & "'"
            strSQL += ", pref_code = '" & cbx_pref.SelectedValue & "'"
            strSQL += ", zip_code = '" & txt_zip.Value & "'"
            strSQL += ", srch_phn = '" & txt_phone.Text & "'"
            strSQL += ", shop_code = '" & txt_shop_code.Text & "'"
            strSQL += ", corp_flg = '" & Mid(cnt_flg.Text, 1, 1) & "'"
            strSQL += ", entry_date = CONVERT(DATETIME, '" & Date_ent.Text & "', 102)"
            strSQL += " WHERE ordr_no = '" & dttbl_mtr.Rows(0)("ordr_no") & "'"
            Dim sqlUpdateCommand As New SqlClient.SqlCommand
            Try
                DB_OPEN("best_wrn")
                sqlUpdateCommand = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                sqlUpdateCommand.CommandTimeout = 600
                sqlUpdateCommand.ExecuteNonQuery()
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            Dim SqlInsertCommand As New SqlClient.SqlCommand

            j = 0
            '追加データ処理
            For i = 0 To Line_No
                If label(i, 0).Text <> Nothing Then
                    j = j + 1
                    strSQL = "INSERT INTO Wrn_sub"
                    strSQL += " (ordr_no, line_no, seq, prch_price, prch_tax, prch_date, item_cat_code"
                    strSQL += ", cat_name, prvd_cls, prch_unit, dlvr_cls, f_full, wrn_prod, wrn_part_prod"
                    strSQL += ", wrn_comp_prod, prm_comp_prod, cont_flg, bend_code"
                    strSQL += ", model_name, pos_code, ser_no, bend_wrn_prod, wrn_fee, op_date)"
                    strSQL += " VALUES ('" & txt_no.Value & "'"
                    If j < 10 Then
                        strSQL += ", '0" & Trim(Str(j)) & "'"
                    Else
                        strSQL += ", '" & Trim(Str(j)) & "'"
                    End If
                    strSQL += ", '1'"
                    strSQL += ", " & (num(i, 0).Value / 1.05) & ""
                    strSQL += ", " & (num(i, 0).Value - num(i, 0).Value / 1.05) & ""
                    strSQL += ", CONVERT(DATETIME, '" & datBox(i, 0).Text & "', 102)"
                    strSQL += ", '" & edit(i, 1).Text & edit(i, 2).Text & "'"
                    strSQL += ", '" & label(i, 2).Text & "'"
                    strSQL += ", NULL"
                    strSQL += ", '1'"
                    strSQL += ", NULL"
                    strSQL += ", 'F'"
                    strSQL += ", '60'"
                    strSQL += ", '60'"
                    strSQL += ", '60'"
                    strSQL += ", NULL"
                    strSQL += ", 'A'"
                    strSQL += ", '" & cmbbox(i, 0).SelectedValue & "'"
                    'strSQL +=  ", '" & cmbbox(i, 0).SelectedText & "'"
                    strSQL += ", '" & edit(i, 0).Text & "'"
                    strSQL += ", '" & edit(i, 3).Text & "'"
                    strSQL += ", NULL"
                    strSQL += ", NULL"
                    strSQL += ", " & CInt(label(i, 1).Text) & ""
                    strSQL += ", CONVERT(DATETIME, '" & Date_ent.Text & "', 102))"
                    SqlInsertCommand = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlInsertCommand.CommandTimeout = 600

                    strSQL2 = "UPDATE Vdr_mtr"
                    strSQL2 = strSQL2 & " SET use_date = GETDATE()"
                    strSQL2 = strSQL2 & " WHERE vdr_code = '" & cmbbox(i, 0).SelectedValue & "'"
                    sqlUpdateCommand = New SqlClient.SqlCommand(strSQL2, cnsqlclient)
                    sqlUpdateCommand.CommandTimeout = 600

                    Try
                        DB_OPEN("best_wrn")
                        SqlInsertCommand.ExecuteNonQuery()
                        sqlUpdateCommand.ExecuteNonQuery()
                        DB_CLOSE()
                    Catch ex As System.Exception
                        MessageBox.Show(ex.Message)
                        DB_CLOSE()
                    End Try
                End If
            Next

            MessageBox.Show("データを修正しました。", "修正", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("この伝票番号は既に登録されています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    'エラーチェック
    Sub err_chk()

        err_flg = "0"
        chk_flg = "0"

        If txt_no.Text Is DBNull.Value Then
            MessageBox.Show("受注番号を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_no.Focus()
            err_flg = "1"
            Exit Sub
        End If

        If Len(txt_no.Value) <> 14 Then
            MessageBox.Show("受注番号は14桁です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_no.Focus()
            err_flg = "1"
            Exit Sub
        End If

        If Date_ent.Text = "____/__/__" Then
            MessageBox.Show("申込日を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Date_ent.Focus()
            err_flg = "1"
            Exit Sub
        End If

        If CDate(Date_ent.Text) > Now() Then
            MessageBox.Show("未来日付の申込日は入力できません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Date_ent.Focus()
            err_flg = "1"
            Exit Sub
        ElseIf CDate(DateAdd("m", 6, CDate(Date_ent.Text))) < Now() Then
            MessageBox.Show("6ヶ月以前の申込日は入力きません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Date_ent.Focus()
            err_flg = "1"
            Exit Sub
        End If

        If cnt_flg.Text = Nothing Then
            MessageBox.Show("契約者タイプを選択してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cnt_flg.Focus()
            err_flg = "1"
            Exit Sub
        End If

        If cust_lname.Text = Nothing Then
            MessageBox.Show("顧客(姓)を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cust_lname.Focus()
            err_flg = "1"
            Exit Sub
        End If

        If txt_phone.Text = Nothing Then
            MessageBox.Show("電話番号を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_phone.Focus()
            err_flg = "1"
            Exit Sub
        End If

        If cbx_pref.Text = Nothing Then
            MessageBox.Show("都道府県を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbx_pref.Focus()
            err_flg = "1"
            Exit Sub
        End If

        For i = 0 To Line_No
            If cmbbox(i, 0).Text <> Nothing Or edit(i, 0).Text <> Nothing Or edit(i, 1).Text <> Nothing Or edit(i, 2).Text <> Nothing Or edit(i, 3).Text <> Nothing Or num(i, 0).Value <> 0 Or datBox(i, 0).Text <> "____/__/__" Then
                If cmbbox(i, 0).Text = Nothing Then
                    MessageBox.Show("メーカーを選択してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbbox(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                ElseIf edit(i, 0).Text = Nothing Then
                    MessageBox.Show("型式を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                ElseIf edit(i, 1).Text = Nothing Then
                    MessageBox.Show("品種コード(部門)を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 1).Focus()
                    err_flg = "1"
                    Exit Sub
                ElseIf edit(i, 2).Text = Nothing Then
                    MessageBox.Show("品種コード(品種)を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 2).Focus()
                    err_flg = "1"
                    Exit Sub
                ElseIf edit(i, 3).Text = Nothing Then
                    MessageBox.Show("POSコードを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 3).Focus()
                    err_flg = "1"
                    Exit Sub
                ElseIf Len(edit(i, 3).Text) <> 8 Then
                    MessageBox.Show("POSコードは8桁です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 3).Focus()
                    err_flg = "1"
                    Exit Sub
                ElseIf num(i, 0).Value < 10500 Then
                    MessageBox.Show("購入金額は 10,500円以上です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    num(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                ElseIf datBox(i, 0).Text = "____/__/__" Then
                    MessageBox.Show("購入日を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    datBox(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                    'ElseIf CDate(datBox(i, 0).Text) > CDate(Date_ent.Text) Then
                    '    MessageBox.Show("未来日付の購入日は入力できません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    datBox(i, 0).Focus()
                    '    err_flg = "1"
                    '    Exit Sub
                    'ElseIf CDate(DateAdd("m", 2, CDate(datBox(i, 0).Text))) < CDate(Date_ent.Text) Then
                    '    MessageBox.Show("2ヶ月以前の購入日は入力きません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    datBox(i, 0).Focus()
                    '    err_flg = "1"
                    '    Exit Sub
                Else
                    DtView12 = New DataView(dsItem3.Tables("vdr0"), "vdr_code ='" & cmbbox(i, 0).SelectedValue & "'", "", DataViewRowState.CurrentRows)
                    If DtView12.Count = 0 Then
                        MessageBox.Show("メーカーを正しく選択してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cmbbox(i, 0).Focus()
                        err_flg = "1"
                        Exit Sub
                    End If
                End If
            End If
        Next

        For i = 0 To Line_No
            If label(i, 0).Text <> Nothing Then
                chk_flg = "1"
            End If
        Next
        If chk_flg <> "1" Then
            MessageBox.Show("購入商品情報を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            label(0, 0).Focus()
            err_flg = "1"
            Exit Sub
        End If

        If txt_shop_code.Text = Nothing Then
            MessageBox.Show("店コードを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_shop_code.Focus()
            err_flg = "1"
            Exit Sub
        End If

    End Sub

    Private Sub shop_code_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_shop_code.Leave
        If txt_shop_code.Text <> Nothing Then
            DtView5 = New DataView(dsItem4.Tables("shop"), "shop_code ='" & txt_shop_code.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView5.Count <> 0 Then
                If Now() >= DateAdd(DateInterval.Day, -1, CDate(Format((DateAdd(DateInterval.Month, 2, DtView5(0)("close_date"))), "yyyy/MM/01"))) Then
                    MessageBox.Show("閉鎖店舗です。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_shop_code.Focus()
                Else
                    lbl_shop.Text = DtView5(0)("shop_name")
                End If
            Else
                MessageBox.Show("該当する店舗がありません。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_shop_code = Nothing
                txt_shop_code.Focus()
            End If
        End If
    End Sub

    Private Sub cat1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim edt As GrapeCity.Win.Input.Interop.Edit
        edt = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)

        If edit(edt.Tag, 2).Text <> Nothing Then
            DtView1 = New DataView(dsItem2.Tables("cat"), "cd1 ='" & edit(edt.Tag, 1).Text & "' AND cd2 ='" & edit(edt.Tag, 2).Text & "' AND cd3 = '00'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                label(edt.Tag, 0).Text = DtView1(0)("cat_name")
                label(edt.Tag, 2).Text = DtView1(0)("cat_kana")
            Else
                MessageBox.Show("該当する商品がありません")
                label(edt.Tag, 0).Text = Nothing
            End If
        End If
    End Sub

    Private Sub cat2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim edt As GrapeCity.Win.Input.Interop.Edit
        edt = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)

        If edit(edt.Tag, 1).Text <> Nothing Then
            DtView1 = New DataView(dsItem2.Tables("cat"), "cd1 ='" & edit(edt.Tag, 1).Text & "' AND cd2 ='" & edit(edt.Tag, 2).Text & "' AND cd3 = '00'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                label(edt.Tag, 0).Text = DtView1(0)("cat_name")
                label(edt.Tag, 2).Text = DtView1(0)("cat_kana")
            Else
                MessageBox.Show("該当する商品がありません")
                label(edt.Tag, 0).Text = Nothing
            End If
        End If
    End Sub

    Private Sub prch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim numbox As GrapeCity.Win.Input.Interop.Number
        numbox = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)

        If Mid(cnt_flg.SelectedItem, 1, 1) <> "0" And Mid(cnt_flg.SelectedItem, 1, 1) <> "1" Then
            MessageBox.Show("契約タイプを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cnt_flg.Focus()
            Exit Sub
        Else
            If num(numbox.Tag, 0).Value >= 10500 Then
                If Mid(cnt_flg.SelectedItem, 1, 1) = "0" Then
                    label(numbox.Tag, 1).Text = Format(RoundDOWN(num(numbox.Tag, 0).Value * 0.05 * 1.05, 0), "##,##0")
                    prch_price(numbox.Tag) = num(numbox.Tag, 0).Value / 1.05
                    prch_tax(numbox.Tag) = num(numbox.Tag, 0).Value - num(numbox.Tag, 0).Value / 1.05
                    wrn_fee(numbox.Tag) = RoundDOWN(num(numbox.Tag, 0).Value * 0.05, 0)
                    wrn_tax(numbox.Tag) = CInt(label(numbox.Tag, 1).Text) - wrn_fee(numbox.Tag)
                    lbl_wrnttl.Text = 0
                ElseIf Mid(cnt_flg.SelectedItem, 1, 1) = "1" Then
                    label(numbox.Tag, 1).Text = Format(RoundDOWN(num(numbox.Tag, 0).Value * 0.1 * 1.05, 0), "##,##0")
                    prch_price(numbox.Tag) = num(numbox.Tag, 0).Value / 1.05
                    prch_tax(numbox.Tag) = num(numbox.Tag, 0).Value - num(numbox.Tag, 0).Value / 1.05
                    wrn_fee(numbox.Tag) = RoundDOWN(num(numbox.Tag, 0).Value * 0.1, 0)
                    wrn_tax(numbox.Tag) = CInt(label(numbox.Tag, 1).Text) - wrn_fee(numbox.Tag)
                    lbl_wrnttl.Text = 0
                End If

                'MsgBox(prch_price(numbox.Tag) & "," & prch_tax(numbox.Tag) & "," & wrn_fee(numbox.Tag) & "," & wrn_tax(numbox.Tag))

                For i = 0 To Line_No
                    lbl_wrnttl.Text = Format(CInt(lbl_wrnttl.Text) + CInt(label(i, 1).Text), "##,##0")
                Next
            Else
                MessageBox.Show("購入金額(税別)は、10,500円以上です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                num(numbox.Tag, 0).Value = 0
                label(numbox.Tag, 1).Text = 0
            End If
        End If
    End Sub

    Private Sub c_Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button
        btn = DirectCast(sender, Button)

        If Line_No = btn.Tag Then
            Call ADD_LINE()
            label(btn.Tag + 1, 0).Text = label(btn.Tag, 0).Text
            If cmbbox(btn.Tag, 0).SelectedValue <> Nothing Then
                cmbbox(btn.Tag + 1, 0).SelectedValue = cmbbox(btn.Tag, 0).SelectedValue
            End If
            edit(btn.Tag + 1, 0).Text = edit(btn.Tag, 0).Text
            edit(btn.Tag + 1, 1).Text = edit(btn.Tag, 1).Text
            edit(btn.Tag + 1, 2).Text = edit(btn.Tag, 2).Text
            edit(btn.Tag + 1, 3).Text = edit(btn.Tag, 3).Text
            num(btn.Tag + 1, 0).Value = num(btn.Tag, 0).Value
            datBox(btn.Tag + 1, 0).Value = datBox(btn.Tag, 0).Value
            label(btn.Tag + 1, 1).Text = label(btn.Tag, 1).Text
        Else
            label(btn.Tag + 1, 0).Text = label(btn.Tag, 0).Text
            If cmbbox(btn.Tag, 0).SelectedValue <> Nothing Then
                cmbbox(btn.Tag + 1, 0).SelectedValue = cmbbox(btn.Tag, 0).SelectedValue
            End If
            edit(btn.Tag + 1, 0).Text = edit(btn.Tag, 0).Text
            edit(btn.Tag + 1, 1).Text = edit(btn.Tag, 1).Text
            edit(btn.Tag + 1, 2).Text = edit(btn.Tag, 2).Text
            edit(btn.Tag + 1, 3).Text = edit(btn.Tag, 3).Text
            num(btn.Tag + 1, 0).Value = num(btn.Tag, 0).Value
            datBox(btn.Tag + 1, 0).Value = datBox(btn.Tag, 0).Value
            label(btn.Tag + 1, 1).Text = label(btn.Tag, 1).Text
        End If

        lbl_wrnttl.Text = 0
        For i = 0 To Line_No
            lbl_wrnttl.Text = Format(CInt(lbl_wrnttl.Text) + CInt(label(i, 1).Text), "##,##0")
        Next

    End Sub

    Private Sub d_Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btnx As Button
        btnx = DirectCast(sender, Button)
        If btnx.Tag >= dttbl_sub.Rows.Count Then
            MessageBox.Show("このデータはまだ登録されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("この行のデータを削除しますか。 削除後、元に戻すことはできません。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim SqlDeleteCommand As New SqlClient.SqlCommand
                SqlDeleteCommand.CommandText = "DELETE wrn_sub WHERE ordr_no = '" & dttbl_mtr.Rows(0)("ordr_no") & "' AND line_no = '" & label(btnx.Tag, 2).Text & "'"
                SqlDeleteCommand.CommandType = CommandType.Text
                SqlDeleteCommand.Connection = cnsqlclient
                Try
                    DB_OPEN("best_wrn")
                    SqlDeleteCommand.ExecuteNonQuery()
                    DB_CLOSE()
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message)
                    DB_CLOSE()
                End Try
                label(btnx.Tag, 0).Text = Nothing
                cmbbox(btnx.Tag, 0).Text = Nothing
                cmbbox(btnx.Tag, 0).SelectedValue = ""
                edit(btnx.Tag, 0).Text = Nothing
                edit(btnx.Tag, 1).Text = Nothing
                edit(btnx.Tag, 2).Text = Nothing
                edit(btnx.Tag, 2).Text = Nothing
                edit(btnx.Tag, 3).Text = Nothing
                num(btnx.Tag, 0).Value = 0
                datBox(btnx.Tag, 0).Value = Nothing
                datBox(btnx.Tag, 0).Text = "____/__/__"
                label(btnx.Tag, 1).Text = 0
                btn(btnx.Tag, 1).Visible = False

                lbl_wrnttl.Text = 0
                For i = 0 To Line_No
                    lbl_wrnttl.Text = Format(CInt(lbl_wrnttl.Text) + CInt(label(i, 1).Text), "##,##0")
                Next
            Else
            End If
        End If
    End Sub

    Private Sub DRWG_chg(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dat As GrapeCity.Win.Input.Interop.Date
        dat = DirectCast(sender, GrapeCity.Win.Input.Interop.Date)
        If dat.Tag = Line_No Then
            Call ADD_LINE()
            cmbbox(Line_No, 0).Focus()
        ElseIf dat.Tag > 99 Then
            MessageBox.Show("100行以上は作成できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub txt_adrs2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_adrs2.Leave
        label(Line_No, 0).Focus()
    End Sub

    Private Sub txt_no_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_no.Leave

        If txt_no.Value <> Nothing Then
            Me.Cursor.Current = Cursors.WaitCursor
            '保証データ_マスタ
            Dim SqlSelectCommand5 As New SqlClient.SqlCommand
            strSQL = "SELECT Wrn_mtr.ordr_no, Wrn_mtr.cust_fname,"
            strSQL += " Wrn_mtr.cust_lname, Wrn_mtr.adrs1, Wrn_mtr.adrs2,"
            strSQL += " Wrn_mtr.city_name, Wrn_mtr.pref_code, Wrn_mtr.zip_code,"
            strSQL += " Wrn_mtr.srch_phn, Wrn_mtr.shop_code, Wrn_mtr.entry_date,"
            strSQL += " Wrn_mtr.corp_flg, Wrn_mtr.entry_flg"
            strSQL += " FROM Wrn_mtr"
            strSQL += " WHERE (Wrn_mtr.entry_flg = '1') AND (Wrn_mtr.ordr_no = '" & txt_no.Value & "')"

            SqlSelectCommand5 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlSelectCommand5.CommandType = CommandType.Text
            Dim daWrnMtr As New SqlClient.SqlDataAdapter
            daWrnMtr.SelectCommand = SqlSelectCommand5

            dsWrnMtr.Clear()

            Try
                DB_OPEN("best_wrn")
                r = daWrnMtr.Fill(dsWrnMtr, "wrn_mtr")
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try

            If r = 0 Then
                Me.Cursor.Current = Cursors.Default
                MessageBox.Show("該当するデータはありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Cursor.Current = Cursors.Default
                Call initial()
                Line_No = -1
                Call disp_main()
                Call ADD_LINE()
            End If
        End If
    End Sub

    Private Sub cnt_flg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cnt_flg.SelectedIndexChanged
        If k <> 0 Then
            If r = 1 Then
                For i = 0 To Line_No
                    If Mid(cnt_flg.SelectedItem, 1, 1) = "0" Then
                        label(i, 1).Text = Format(RoundDOWN(num(i, 0).Value * 0.05 * 1.05, 0), "##,##0")
                        prch_price(i) = num(i, 0).Value / 1.05
                        prch_tax(i) = num(i, 0).Value - num(i, 0).Value / 1.05
                        wrn_fee(i) = RoundDOWN(num(i, 0).Value * 0.05, 0)
                        wrn_tax(i) = CInt(label(i, 1).Text) - wrn_fee(i)
                        lbl_wrnttl.Text = 0
                    ElseIf Mid(cnt_flg.SelectedItem, 1, 1) = "1" Then
                        label(i, 1).Text = Format(RoundDOWN(num(i, 0).Value * 0.1 * 1.05, 0), "##,##0")
                        prch_price(i) = num(i, 0).Value / 1.05
                        prch_tax(i) = num(i, 0).Value - num(i, 0).Value / 1.05
                        wrn_fee(i) = RoundDOWN(num(i, 0).Value * 0.1, 0)
                        wrn_tax(i) = CInt(label(i, 1).Text) - wrn_fee(i)
                        lbl_wrnttl.Text = 0
                    End If
                Next

                For i = 0 To Line_No
                    lbl_wrnttl.Text = Format(CInt(lbl_wrnttl.Text) + CInt(label(i, 1).Text), "##,##0")
                Next
            End If
        End If
    End Sub

    Private Sub add_ln_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call ADD_LINE2()

    End Sub

    Private Sub ADD_LINE2()

        Line_No = Line_No + 1

        '商品名
        x = 0
        label(Line_No, x) = New Label
        label(Line_No, x).BackColor = System.Drawing.Color.LightSkyBlue
        label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        label(Line_No, x).ForeColor = System.Drawing.Color.Navy
        label(Line_No, x).Location = New System.Drawing.Point(0, 25 * Line_No + pos.Location.Y)
        label(Line_No, x).Name = "lbl_item1"
        label(Line_No, x).Size = New System.Drawing.Size(120, 24)
        label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))

        'メーカー
        Dim SqlSelectCommand3 As New SqlClient.SqlCommand
        SqlSelectCommand3 = New SqlClient.SqlCommand("SELECT vdr_code, vdr_name FROM vdr_mtr ORDER BY use_date DESC, vdr_name", cnsqlclient)
        SqlSelectCommand3.CommandType = CommandType.Text
        Dim daItem3 As New SqlClient.SqlDataAdapter
        daItem3.SelectCommand = SqlSelectCommand3

        DB_OPEN("best_wrn")
        daItem3.Fill(dsItem3, "vdr" & Line_No)
        DB_CLOSE()

        x = 0
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(120, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).DropDownWidth = 180
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = 202
        cmbbox(Line_No, x).DataSource = dsItem3
        cmbbox(Line_No, x).DisplayMember = "vdr" & Line_No & ".vdr_name"
        cmbbox(Line_No, x).ValueMember = "vdr" & Line_No & ".vdr_code"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing

        '型式
        x = 0
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "AaK#@"
        edit(Line_No, x).MaxLength = 20
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
        edit(Line_No, x).Location = New System.Drawing.Point(240, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(167, 24)
        edit(Line_No, x).TabIndex = 203
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))

        '品種コード(部門)
        x = 1
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).AllowSpace = False
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "9"
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(408, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 2
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(43, 24)
        edit(Line_No, x).TabIndex = 204
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))
        AddHandler edit(Line_No, x).Leave, AddressOf cat1_Leave

        '品種コード(品種)
        x = 2
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).AllowSpace = False
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "9"
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(452, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 2
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(43, 24)
        edit(Line_No, x).TabIndex = 205
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Panel1.Controls.Add(edit(Line_No, x))
        AddHandler edit(Line_No, x).Leave, AddressOf cat2_Leave

        'POSコード
        x = 3
        edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        edit(Line_No, x).ExitOnLastChar = True
        edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        edit(Line_No, x).Format = "9"
        edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        edit(Line_No, x).LengthAsByte = True
        edit(Line_No, x).Location = New System.Drawing.Point(496, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 8
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(71, 24)
        edit(Line_No, x).TabIndex = 206
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
        Panel1.Controls.Add(edit(Line_No, x))

        '購入金額
        x = 0
        num(Line_No, x) = New GrapeCity.Win.Input.Interop.Number
        num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        num(Line_No, x).DropDownCalculator.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
        num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        num(Line_No, x).Format = New GrapeCity.Win.Input.Interop.NumberFormat("##,###,##0", "", "", "-", "", "", "")
        num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        num(Line_No, x).Location = New System.Drawing.Point(568, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        num(Line_No, x).Size = New System.Drawing.Size(83, 24)
        num(Line_No, x).TabIndex = 207
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        AddHandler num(Line_No, x).Leave, AddressOf prch_Leave

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
        datBox(Line_No, x).Location = New System.Drawing.Point(652, 25 * Line_No + pos.Location.Y)
        datBox(Line_No, x).MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        datBox(Line_No, x).MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        datBox(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        datBox(Line_No, x).Size = New System.Drawing.Size(84, 24)
        datBox(Line_No, x).TabIndex = 208
        datBox(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        datBox(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        datBox(Line_No, x).Tag = Line_No
        datBox(Line_No, x).Value = Nothing
        datBox(Line_No, x).Text = "____/__/__"
        Panel1.Controls.Add(datBox(Line_No, x))
        AddHandler datBox(Line_No, x).Leave, AddressOf DRWG_chg2

        '保証料
        x = 1
        label(Line_No, x) = New Label
        label(Line_No, x).BackColor = System.Drawing.Color.LightSkyBlue
        label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        label(Line_No, x).ForeColor = System.Drawing.Color.Navy
        label(Line_No, x).Location = New System.Drawing.Point(736, 25 * Line_No + pos.Location.Y)
        label(Line_No, x).Tag = Line_No
        label(Line_No, x).Size = New System.Drawing.Size(70, 24)
        label(Line_No, x).TabIndex = 209
        label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleRight
        label(Line_No, x).Text = 0
        Panel1.Controls.Add(label(Line_No, x))

        '複ボタン
        x = 0
        btn(Line_No, x) = New Button
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Location = New Drawing.Point(810, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "複"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf c_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

        '削ボタン
        x = 1
        btn(Line_No, x) = New Button
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Location = New Drawing.Point(836, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "削"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(0, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf d_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

    End Sub

    Private Sub DRWG_chg2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dat As GrapeCity.Win.Input.Interop.Date
        dat = DirectCast(sender, GrapeCity.Win.Input.Interop.Date)
        If dat.Tag = Line_No Then
            Call ADD_LINE()
            cmbbox(Line_No, 0).Focus()
        ElseIf dat.Tag > 99 Then
            MessageBox.Show("100行以上は作成できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class
