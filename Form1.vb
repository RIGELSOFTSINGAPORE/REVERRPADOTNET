Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim dsItem1, dsItem2, dsItem3, dsItem4, DsCMB As New DataSet
    Dim DtView1, DtView5, DtView12, WK_DtView1 As DataView
    Dim Line_No, x, i, j As Integer
    Dim strSQL, strSQL2, err_flg, chk_flg As String
    'Dim empl_code As Integer

    Dim label(99, 9) As Label
    Dim cmbbox(99, 9) As ComboBox
    Dim edit(99, 9) As GrapeCity.Win.Input.Interop.Edit
    Dim num(99, 9) As GrapeCity.Win.Input.Interop.Number
    Dim datBox(99, 9) As GrapeCity.Win.Input.Interop.Date
    Dim btn(99, 9) As Button

    Dim WK_cat_prod(99) As String  '保証期間
    Dim prch_price, prch_tax, wrn_fee, wrn_fee_sum As Integer

    Dim inz As String

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
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
    Friend WithEvents lbl_wrnttl As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents BY_cls As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
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
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.lbl_wrnttl = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pos = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.BY_cls = New System.Windows.Forms.Label()
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
        Me.cbx_pref.Location = New System.Drawing.Point(616, 43)
        Me.cbx_pref.MaxDropDownItems = 20
        Me.cbx_pref.Name = "cbx_pref"
        Me.cbx_pref.Size = New System.Drawing.Size(120, 25)
        Me.cbx_pref.TabIndex = 15
        '
        'Date_ent
        '
        Me.Date_ent.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date_ent.DropDownCalendar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.DropDownCalendar.Size = New System.Drawing.Size(291, 205)
        Me.Date_ent.ExitOnLastChar = True
        Me.Date_ent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Date_ent.Location = New System.Drawing.Point(848, 52)
        Me.Date_ent.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        Me.Date_ent.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        Me.Date_ent.Name = "Date_ent"
        Me.Date_ent.Size = New System.Drawing.Size(120, 27)
        Me.Date_ent.TabIndex = 3
        Me.Date_ent.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_ent.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date_ent.Value = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(760, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 26)
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
        Me.Label4.Location = New System.Drawing.Point(76, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 34)
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
        Me.Label5.Location = New System.Drawing.Point(196, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 34)
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
        Me.Label6.Location = New System.Drawing.Point(328, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 34)
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
        Me.Label7.Location = New System.Drawing.Point(496, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 17)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "品種コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(496, 182)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "（部門）（品種）"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(592, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 34)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "POSコード"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(664, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 34)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "購入価格（税込）"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(748, 165)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 34)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "受注日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(916, 165)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 34)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "保証料（税込）"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.RoyalBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(628, 522)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 35)
        Me.Button1.TabIndex = 101
        Me.Button1.Text = "登 録"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 104)
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
        Me.Label14.Location = New System.Drawing.Point(16, 43)
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
        Me.Label15.Location = New System.Drawing.Point(72, 43)
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
        Me.Label16.Location = New System.Drawing.Point(72, 69)
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
        Me.Label17.Location = New System.Drawing.Point(760, 17)
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
        Me.txt_zip.Location = New System.Drawing.Point(432, 43)
        Me.txt_zip.Name = "txt_zip"
        Me.txt_zip.Size = New System.Drawing.Size(88, 27)
        Me.txt_zip.TabIndex = 14
        Me.txt_zip.Value = ""
        '
        'txt_no
        '
        Me.txt_no.ExitOnLastChar = True
        Me.txt_no.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no.Format = New GrapeCity.Win.Input.Interop.MaskFormat("110 - \D{14}", "", "")
        Me.txt_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_no.Location = New System.Drawing.Point(808, 17)
        Me.txt_no.Name = "txt_no"
        Me.txt_no.Size = New System.Drawing.Size(160, 27)
        Me.txt_no.TabIndex = 2
        Me.txt_no.Value = ""
        '
        'txt_city
        '
        Me.txt_city.ExitOnLastChar = True
        Me.txt_city.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_city.Format = "K"
        Me.txt_city.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_city.LengthAsByte = True
        Me.txt_city.Location = New System.Drawing.Point(432, 69)
        Me.txt_city.MaxLength = 24
        Me.txt_city.Name = "txt_city"
        Me.txt_city.Size = New System.Drawing.Size(304, 27)
        Me.txt_city.TabIndex = 16
        Me.txt_city.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_city.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs1
        '
        Me.txt_adrs1.ExitOnLastChar = True
        Me.txt_adrs1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs1.Format = "AaK#@"
        Me.txt_adrs1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs1.LengthAsByte = True
        Me.txt_adrs1.Location = New System.Drawing.Point(432, 95)
        Me.txt_adrs1.MaxLength = 36
        Me.txt_adrs1.Name = "txt_adrs1"
        Me.txt_adrs1.Size = New System.Drawing.Size(304, 27)
        Me.txt_adrs1.TabIndex = 17
        Me.txt_adrs1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs2
        '
        Me.txt_adrs2.ExitOnLastChar = True
        Me.txt_adrs2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs2.Format = "AaK#@"
        Me.txt_adrs2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs2.LengthAsByte = True
        Me.txt_adrs2.Location = New System.Drawing.Point(432, 121)
        Me.txt_adrs2.MaxLength = 36
        Me.txt_adrs2.Name = "txt_adrs2"
        Me.txt_adrs2.Size = New System.Drawing.Size(304, 27)
        Me.txt_adrs2.TabIndex = 18
        Me.txt_adrs2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_lname
        '
        Me.cust_lname.ExitOnLastChar = True
        Me.cust_lname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_lname.Format = "AaK#@"
        Me.cust_lname.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cust_lname.LengthAsByte = True
        Me.cust_lname.Location = New System.Drawing.Point(128, 43)
        Me.cust_lname.MaxLength = 15
        Me.cust_lname.Name = "cust_lname"
        Me.cust_lname.Size = New System.Drawing.Size(176, 27)
        Me.cust_lname.TabIndex = 11
        Me.cust_lname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_lname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_fname
        '
        Me.cust_fname.ExitOnLastChar = True
        Me.cust_fname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_fname.Format = "AaK#@"
        Me.cust_fname.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cust_fname.LengthAsByte = True
        Me.cust_fname.Location = New System.Drawing.Point(128, 69)
        Me.cust_fname.MaxLength = 15
        Me.cust_fname.Name = "cust_fname"
        Me.cust_fname.Size = New System.Drawing.Size(176, 27)
        Me.cust_fname.TabIndex = 12
        Me.cust_fname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_fname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(740, 520)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 35)
        Me.Button2.TabIndex = 102
        Me.Button2.Text = "キャンセル"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(844, 520)
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
        Me.Label3.Location = New System.Drawing.Point(520, 43)
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
        Me.Label18.Location = New System.Drawing.Point(336, 69)
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
        Me.Label19.Location = New System.Drawing.Point(336, 95)
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
        Me.Label20.Location = New System.Drawing.Point(336, 121)
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
        Me.Label21.Location = New System.Drawing.Point(336, 43)
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
        Me.txt_phone.Location = New System.Drawing.Point(128, 104)
        Me.txt_phone.MaxLength = 15
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Size = New System.Drawing.Size(176, 27)
        Me.txt_phone.TabIndex = 13
        '
        'txt_shop_code
        '
        Me.txt_shop_code.ExitOnLastChar = True
        Me.txt_shop_code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_shop_code.Format = "9"
        Me.txt_shop_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_shop_code.LengthAsByte = True
        Me.txt_shop_code.Location = New System.Drawing.Point(88, 494)
        Me.txt_shop_code.MaxLength = 4
        Me.txt_shop_code.Name = "txt_shop_code"
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
        'lbl_wrnttl
        '
        Me.lbl_wrnttl.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lbl_wrnttl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wrnttl.ForeColor = System.Drawing.Color.Navy
        Me.lbl_wrnttl.Location = New System.Drawing.Point(868, 468)
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
        Me.Label24.Location = New System.Drawing.Point(756, 468)
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
        Me.Panel1.Location = New System.Drawing.Point(16, 199)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1044, 252)
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
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(16, 165)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 34)
        Me.Label25.TabIndex = 10002
        Me.Label25.Text = "契約タイプ"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(832, 165)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 34)
        Me.Label23.TabIndex = 10003
        Me.Label23.Text = "完了日"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.DarkBlue
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(16, 9)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 26)
        Me.Label26.TabIndex = 10004
        Me.Label26.Text = "システム区分"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(136, 9)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(112, 26)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "Brainsでの加入"
        '
        'RadioButton2
        '
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(248, 9)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(124, 26)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Yシステムでの加入"
        '
        'BY_cls
        '
        Me.BY_cls.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BY_cls.Location = New System.Drawing.Point(380, 4)
        Me.BY_cls.Name = "BY_cls"
        Me.BY_cls.Size = New System.Drawing.Size(36, 26)
        Me.BY_cls.TabIndex = 10005
        Me.BY_cls.Text = "BY"
        Me.BY_cls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BY_cls.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1170, 625)
        Me.Controls.Add(Me.BY_cls)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lbl_wrnttl)
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
        Me.Controls.Add(Me.Button2)
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
        Me.Controls.Add(Me.Button1)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "延長保証データ入力"
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

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'empl_code = 1

        Label25.Text = "契約" & vbCrLf & "タイプ"
        Label10.Text = "購入価格" & vbCrLf & "（税込）"
        Label12.Text = "保証料" & vbCrLf & "（税込）"
        BY_cls.Text = "Y"

        '都道府県マスタ
        Dim SqlSelectCommand1 As New SqlClient.SqlCommand
        SqlSelectCommand1 = New SqlClient.SqlCommand("SELECT pref_code, 都道府県名 AS pref_name FROM pref_mtr", cnsqlclient)
        SqlSelectCommand1.CommandType = CommandType.Text
        Dim daItem1 As New SqlClient.SqlDataAdapter
        daItem1.SelectCommand = SqlSelectCommand1

        '品種マスタ
        Dim SqlSelectCommand2 As New SqlClient.SqlCommand
        SqlSelectCommand2 = New SqlClient.SqlCommand("SELECT cd1, cd2, cd3, [品種名(漢字)] as cat_name, [品種名(ｶﾅ)] as cat_kana, wrn_prod, avlbty, GRP FROM cat_mtr", cnsqlclient)
        'WHERE (BY_cls = '" & BY_cls.Text & "')", cnsqlclient)
        SqlSelectCommand2.CommandType = CommandType.Text
        Dim daItem2 As New SqlClient.SqlDataAdapter
        daItem2.SelectCommand = SqlSelectCommand2

        '店舗マスタ
        Dim SqlSelectCommand4 As New SqlClient.SqlCommand
        SqlSelectCommand4 = New SqlClient.SqlCommand("SELECT shop_code, [店舗名(漢字)] as shop_name, close_date FROM shop_mtr", cnsqlclient)
        'WHERE(BY_cls = '" & BY_cls.Text & "')", cnsqlclient)
        SqlSelectCommand4.CommandType = CommandType.Text
        Dim daItem4 As New SqlClient.SqlDataAdapter
        daItem4.SelectCommand = SqlSelectCommand4

        DB_OPEN("best_wrn")
        daItem1.Fill(dsItem1, "pref")
        daItem2.Fill(dsItem2, "cat")
        daItem4.Fill(dsItem4, "shop")
        DB_CLOSE()

        cbx_pref.DataSource = dsItem1
        cbx_pref.DisplayMember = "pref.pref_name"
        cbx_pref.ValueMember = "pref.pref_code"
        cbx_pref.Text = Nothing

        Call initial()
        Line_No = -1
        'Call ADD_LINE()
        inz = "1"
    End Sub

    'SUBMIT
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Call err_chk()  'Error Check 
        If err_flg = "0" Then
            Call submit()   'Insert
            Call initial()
            Line_No = -1
            Panel1.Controls.Clear() : Call ADD_LINE()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'CANCEL
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Call initial()
        Line_No = -1
        'Panel1.Controls.Clear() : Call ADD_LINE()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'Back To Menu
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        dsItem1.Clear()
        dsItem2.Clear()
        dsItem3.Clear()
        dsItem4.Clear()
        DsCMB.Clear()
        Me.Close()
        Dim Menu As New Menu
        Menu.Show()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '画面の初期化
    Sub initial()

        txt_no.Text = Nothing
        Date_ent.Text = "____/__/__"
        cust_lname.Text = Nothing
        cust_fname.Text = Nothing
        txt_phone.Text = Nothing
        txt_zip.Text = Nothing
        cbx_pref.Text = Nothing
        cbx_pref.SelectedValue = ""
        txt_city.Text = Nothing
        txt_adrs1.Text = Nothing
        txt_adrs2.Text = Nothing
        txt_shop_code.Text = Nothing
        lbl_shop.Text = Nothing
        lbl_wrnttl.Text = 0

        dsItem3.Clear()
        DsCMB.Clear()
    End Sub

    '行追加
    Sub ADD_LINE()

        Line_No = Line_No + 1

        '契約タイプ
        SqlCmd1 = New SqlClient.SqlCommand("SELECT RTRIM(CLS_CODE) AS CLS_CODE, RTRIM(CLS_CODE_NAME) AS CLS_NAME FROM CLS_CODE WHERE (CLS_NO = '015')", cnsqlclient)
        SqlCmd1.CommandType = CommandType.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(DsCMB, "cls015" & Line_No)
        DB_CLOSE()

        x = 1
        cmbbox(Line_No, x) = New ComboBox
        cmbbox(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmbbox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.On
        cmbbox(Line_No, x).Location = New System.Drawing.Point(0, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(60, 24)
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100
        cmbbox(Line_No, x).DataSource = DsCMB
        cmbbox(Line_No, x).DisplayMember = "cls015" & Line_No & ".CLS_NAME"
        cmbbox(Line_No, x).ValueMember = "cls015" & Line_No & ".CLS_CODE"
        Panel1.Controls.Add(cmbbox(Line_No, x))
        cmbbox(Line_No, x).Text = Nothing
        AddHandler cmbbox(Line_No, x).Leave, AddressOf cmbbox1_Leave

        '商品名
        x = 0
        label(Line_No, x) = New Label
        label(Line_No, x).BackColor = System.Drawing.Color.LightSkyBlue
        label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        label(Line_No, x).ForeColor = System.Drawing.Color.Navy
        label(Line_No, x).Location = New System.Drawing.Point(60, 25 * Line_No + pos.Location.Y)
        label(Line_No, x).Name = "lbl_item1"
        label(Line_No, x).Size = New System.Drawing.Size(120, 24)
        label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))

        'メーカー
        Dim SqlSelectCommand3 As New SqlClient.SqlCommand
        SqlSelectCommand3 = New SqlClient.SqlCommand("SELECT vdr_code, RTRIM(vdr_name) AS Name FROM vdr_mtr WHERE (BY_cls = '" & BY_cls.Text & "') ORDER BY use_date DESC, vdr_name", cnsqlclient)
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
        cmbbox(Line_No, x).Location = New System.Drawing.Point(180, 25 * Line_No + pos.Location.Y)
        cmbbox(Line_No, x).Size = New System.Drawing.Size(132, 24)
        cmbbox(Line_No, x).DropDownWidth = 180
        cmbbox(Line_No, x).MaxDropDownItems = 18
        cmbbox(Line_No, x).Tag = Line_No
        cmbbox(Line_No, x).TabIndex = Line_No * 100 + 1
        cmbbox(Line_No, x).DataSource = dsItem3
        cmbbox(Line_No, x).DisplayMember = "vdr" & Line_No & ".Name"
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
        edit(Line_No, x).Location = New System.Drawing.Point(312, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(167, 24)
        edit(Line_No, x).TabIndex = Line_No * 100 + 2
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
        edit(Line_No, x).Location = New System.Drawing.Point(480, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 4
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(51, 24)
        edit(Line_No, x).TabIndex = Line_No * 100 + 3
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
        edit(Line_No, x).Location = New System.Drawing.Point(532, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 2
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(43, 24)
        edit(Line_No, x).TabIndex = Line_No * 100 + 4
        edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No, x).Text = Nothing
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
        edit(Line_No, x).Location = New System.Drawing.Point(576, 25 * Line_No + pos.Location.Y)
        edit(Line_No, x).MaxLength = 8
        edit(Line_No, x).Tag = Line_No
        edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No, x).Size = New System.Drawing.Size(71, 24)
        edit(Line_No, x).TabIndex = Line_No * 100 + 5
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
        num(Line_No, x).Location = New System.Drawing.Point(648, 25 * Line_No + pos.Location.Y)
        num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        num(Line_No, x).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        num(Line_No, x).Tag = Line_No
        num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        num(Line_No, x).Size = New System.Drawing.Size(83, 24)
        num(Line_No, x).TabIndex = Line_No * 100 + 6
        num(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        num(Line_No, x).Value = New Decimal(New Integer() {0, 0, 0, 0})
        Panel1.Controls.Add(num(Line_No, x))
        AddHandler num(Line_No, x).Leave, AddressOf prch_Leave

        '受注日
        x = 0
        datBox(Line_No, x) = New GrapeCity.Win.Input.Interop.Date
        datBox(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        datBox(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        datBox(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        datBox(Line_No, x).ExitOnLastChar = True
        datBox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        datBox(Line_No, x).Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        datBox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        datBox(Line_No, x).Location = New System.Drawing.Point(732, 25 * Line_No + pos.Location.Y)
        datBox(Line_No, x).MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        datBox(Line_No, x).MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        datBox(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        datBox(Line_No, x).Size = New System.Drawing.Size(83, 24)
        datBox(Line_No, x).TabIndex = Line_No * 100 + 7
        datBox(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        datBox(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        datBox(Line_No, x).Tag = Line_No
        datBox(Line_No, x).Value = Nothing
        datBox(Line_No, x).Text = "____/__/__"
        Panel1.Controls.Add(datBox(Line_No, x))
        'AddHandler datBox(Line_No, x).Leave, AddressOf DRWG_chg

        '完了日
        x = 1
        datBox(Line_No, x) = New GrapeCity.Win.Input.Interop.Date
        datBox(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
        datBox(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        datBox(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        datBox(Line_No, x).ExitOnLastChar = True
        datBox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        datBox(Line_No, x).Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        datBox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
        datBox(Line_No, x).Location = New System.Drawing.Point(816, 25 * Line_No + pos.Location.Y)
        datBox(Line_No, x).MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        datBox(Line_No, x).MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        datBox(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        datBox(Line_No, x).Size = New System.Drawing.Size(83, 24)
        datBox(Line_No, x).TabIndex = Line_No * 100 + 7
        datBox(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        datBox(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        datBox(Line_No, x).Tag = Line_No
        datBox(Line_No, x).Value = Nothing
        datBox(Line_No, x).Text = "____/__/__"
        Panel1.Controls.Add(datBox(Line_No, x))
        AddHandler datBox(Line_No, x).Leave, AddressOf DRWG_chg

        '保証料(税込)
        x = 1
        label(Line_No, x) = New Label
        label(Line_No, x).BackColor = System.Drawing.Color.LightSkyBlue
        label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        label(Line_No, x).ForeColor = System.Drawing.Color.Navy
        label(Line_No, x).Location = New System.Drawing.Point(900, 25 * Line_No + pos.Location.Y)
        label(Line_No, x).Tag = Line_No
        label(Line_No, x).Size = New System.Drawing.Size(71, 24)
        label(Line_No, x).TabIndex = Line_No * 100 + 8
        label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleRight
        label(Line_No, x).Text = 0
        Panel1.Controls.Add(label(Line_No, x))

        '商品名ｶﾅ
        x = 2
        label(Line_No, x) = New Label
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))

        '契約タイプ
        x = 3
        label(Line_No, x) = New Label
        label(Line_No, x).Tag = Line_No
        Panel1.Controls.Add(label(Line_No, x))

        '複ボタン
        x = 0
        btn(Line_No, x) = New Button
        btn(Line_No, x).Size = New Drawing.Size(25, 25)
        btn(Line_No, x).Location = New Drawing.Point(972, 25 * Line_No + pos.Location.Y)
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
        btn(Line_No, x).Location = New Drawing.Point(998, 25 * Line_No + pos.Location.Y)
        btn(Line_No, x).Font = New Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        btn(Line_No, x).Text = "削"
        btn(Line_No, x).BackColor = Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(0, Byte))
        btn(Line_No, x).Tag = Line_No
        AddHandler btn(Line_No, x).Click, AddressOf d_Btn_click
        Panel1.Controls.Add(btn(Line_No, x))

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    'データ登録
    Sub submit()

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

        If r = 0 Then
            strSQL = "INSERT INTO Wrn_mtr"
            strSQL += " (ordr_no, cust_fname, cust_lname, adrs1, adrs2"
            strSQL += ", city_name, pref_code, zip_code, srch_phn, cid"
            strSQL += ", shop_code, corp_flg, entry_date, entry_flg, BY_cls)"
            strSQL += " VALUES ('" & txt_no.Value & "'"
            strSQL += ", '" & cust_fname.Text & "'"
            strSQL += ", '" & cust_lname.Text & "'"
            strSQL += ", '" & txt_adrs1.Text & "'"
            strSQL += ", '" & txt_adrs2.Text & "'"
            strSQL += ", '" & txt_city.Text & "'"
            strSQL += ", '" & cbx_pref.SelectedValue & "'"
            strSQL += ", '" & txt_zip.Value & "'"
            strSQL += ", '" & txt_phone.Text & "'"
            strSQL += ", '110'"
            strSQL += ", '" & txt_shop_code.Text & "'"
            strSQL += ", '" & label(0, 3).Text & "'"
            strSQL += ", CONVERT(DATETIME, '" & Date_ent.Text & "', 102)"
            strSQL += ", '1'"
            strSQL += ", '" & BY_cls.Text & "')"

            Dim SqlInsertCommand As New SqlClient.SqlCommand
            SqlInsertCommand = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlInsertCommand.CommandTimeout = 600
            DB_OPEN("best_wrn")
            SqlInsertCommand.ExecuteNonQuery()
            DB_CLOSE()

            Dim SqlUpdateCommand As New SqlClient.SqlCommand

            j = 0
            For i = 0 To Line_No
                If label(i, 0).Text <> Nothing Then
                    j = j + 1
                    strSQL = "INSERT INTO Wrn_sub"
                    strSQL += " (ordr_no, line_no, seq, prch_price, prch_tax, prch_date, fin_date, item_cat_code"
                    strSQL += ", cat_name, prvd_cls, prch_unit, dlvr_cls, f_full, wrn_prod, wrn_part_prod"
                    strSQL += ", wrn_comp_prod, prm_comp_prod, cont_flg, bend_code"
                    strSQL += ", model_name, pos_code, ser_no, bend_wrn_prod, wrn_fee, op_date, corp_flg"
                    strSQL += ", item_cat_code1, item_cat_code2, BY_cls)"
                    strSQL += " VALUES ('" & txt_no.Value & "'"
                    If j < 10 Then
                        strSQL += ", '0" & Trim(Str(j)) & "'"
                    Else
                        strSQL += ", '" & Trim(Str(j)) & "'"
                    End If
                    strSQL += ", '1'"
                    If datBox(i, 0).Text >= "2019/10/01" Then
                        If num(i, 0).Value / 1.1 - Int(num(i, 0).Value / 1.1) = 0 Then
                            prch_price = num(i, 0).Value / 1.1
                        Else
                            prch_price = Int(num(i, 0).Value / 1.1) + 1
                        End If
                    Else
                        If num(i, 0).Value / 1.08 - Int(num(i, 0).Value / 1.08) = 0 Then
                            prch_price = num(i, 0).Value / 1.08
                        Else
                            prch_price = Int(num(i, 0).Value / 1.08) + 1
                        End If
                    End If
                    strSQL += ", " & prch_price
                    strSQL += ", " & num(i, 0).Value - prch_price
                    strSQL += ", CONVERT(DATETIME, '" & datBox(i, 0).Text & "', 102)"
                    strSQL += ", CONVERT(DATETIME, '" & datBox(i, 1).Text & "', 102)"
                    strSQL += ", '" & edit(i, 1).Text & edit(i, 2).Text & "'"
                    strSQL += ", '" & label(i, 2).Text & "'"
                    strSQL += ", NULL"
                    strSQL += ", '1'"
                    strSQL += ", NULL"
                    Select Case label(i, 3).Text
                        Case Is = "0"
                            strSQL += ", '1'"
                        Case Is = "1"
                            strSQL += ", '2'"
                        Case Else
                            strSQL += ", '" & label(i, 3).Text & "'"
                    End Select
                    If Date_ent.Text < "2007/11/01" Then
                        strSQL += ", '60'"
                        strSQL += ", '60'"
                        strSQL += ", '60'"
                    Else
                        strSQL += ", '" & WK_cat_prod(i) & "'"
                        strSQL += ", '" & WK_cat_prod(i) & "'"
                        strSQL += ", '" & WK_cat_prod(i) & "'"
                    End If
                    strSQL += ", NULL"
                    strSQL += ", 'A'"
                    strSQL += ", '" & cmbbox(i, 0).SelectedValue & "'"
                    strSQL += ", '" & edit(i, 0).Text & "'"
                    strSQL += ", '" & edit(i, 3).Text & "'"
                    strSQL += ", NULL"
                    strSQL += ", NULL"
                    strSQL += ", " & RoundUP(CInt(label(i, 1).Text) / 1.05, 0)
                    strSQL += ", CONVERT(DATETIME, '" & Date_ent.Text & "', 102)"
                    strSQL += ", '" & label(i, 3).Text & "'"
                    strSQL += ", '" & edit(i, 1).Text & "'"
                    strSQL += ", '" & edit(i, 2).Text & "'"
                    strSQL += ", '" & BY_cls.Text & "')"
                    SqlInsertCommand = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlInsertCommand.CommandTimeout = 600

                    strSQL2 = "UPDATE Vdr_mtr"
                    strSQL2 = strSQL2 & " SET use_date = GETDATE()"
                    strSQL2 = strSQL2 & " WHERE vdr_code = '" & cmbbox(i, 0).SelectedValue & "'"
                    strSQL2 = strSQL2 & " AND BY_cls = 'Y'"
                    SqlUpdateCommand = New SqlClient.SqlCommand(strSQL2, cnsqlclient)
                    SqlUpdateCommand.CommandTimeout = 600

                    Try
                        DB_OPEN("best_wrn")
                        SqlInsertCommand.ExecuteNonQuery()
                        SqlUpdateCommand.ExecuteNonQuery()
                        DB_CLOSE()
                    Catch ex As System.Exception
                        MessageBox.Show(ex.Message)
                        DB_CLOSE()
                    End Try
                End If
            Next

            Dim seq_now, seq_upd As Integer
            Dim drSeq As SqlClient.SqlDataReader
            SqlSelectCommand1 = New SqlClient.SqlCommand("SELECT seq FROM Count_tbl WHERE cls = '002'", cnsqlclient)
            DB_OPEN("best_wrn")
            drSeq = SqlSelectCommand1.ExecuteReader()
            Do While drSeq.Read
                seq_now = drSeq("seq")
            Loop
            DB_CLOSE()

            seq_upd = seq_now + 1

            SqlUpdateCommand = New SqlClient.SqlCommand("UPDATE Count_tbl SET seq = " & seq_upd & " WHERE cls = '002'", cnsqlclient)
            SqlInsertCommand = New SqlClient.SqlCommand("INSERT input_seq (ordr_no, seq, user_name, input_date) VALUES ( '" & txt_no.Value & "', " & seq_now & ", '" & System.Windows.Forms.SystemInformation.UserName & "', GETDATE())", cnsqlclient)

            DB_OPEN("best_wrn")
            SqlUpdateCommand.ExecuteNonQuery()
            SqlInsertCommand.ExecuteNonQuery()
            DB_CLOSE()

            MessageBox.Show("管理番号 " & seq_now & " でデータを登録しました。", "登録", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_no.Focus()
        Else
            MessageBox.Show("この伝票番号は既に登録されています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_no.Focus()
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
            'ElseIf CDate(DateAdd("m", 6, CDate(Date_ent.Text))) < Now() Then
            '    MessageBox.Show("6ヶ月以前の申込日は入力きません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Date_ent.Focus()
            '    err_flg = "1"
            '    Exit Sub
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
            If cmbbox(i, 1).Text <> Nothing Or cmbbox(i, 0).Text <> Nothing Or edit(i, 0).Text <> Nothing Or edit(i, 1).Text <> Nothing Or edit(i, 2).Text <> Nothing Or edit(i, 3).Text <> Nothing Or num(i, 0).Value <> 0 Or datBox(i, 0).Text <> "____/__/__" Then
                If cmbbox(i, 1).Text = Nothing Then
                    MessageBox.Show("契約タイプを選択してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbbox(i, 1).Focus()
                    err_flg = "1"
                    Exit Sub
                Else
                    WK_DtView1 = New DataView(DsCMB.Tables("cls015" & Line_No), "CLS_NAME = '" & cmbbox(i, 1).Text & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count = 0 Then
                        MessageBox.Show("契約タイプが違います。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cmbbox(i, 1).Focus()
                        err_flg = "1"
                        Exit Sub
                    End If
                End If
                If cmbbox(i, 0).Text = Nothing Then
                    MessageBox.Show("メーカーを選択してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbbox(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                Else
                    WK_DtView1 = New DataView(dsItem3.Tables("vdr" & Line_No), "Name = '" & cmbbox(i, 0).Text & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count = 0 Then
                        MessageBox.Show("メーカーが違います。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cmbbox(i, 0).Focus()
                        err_flg = "1"
                        Exit Sub
                    End If
                End If
                If edit(i, 0).Text = Nothing Then
                    MessageBox.Show("型式を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                End If
                If edit(i, 1).Text = Nothing Then
                    MessageBox.Show("品種コード(部門)を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 1).Focus()
                    err_flg = "1"
                    Exit Sub
                End If
                If edit(i, 2).Text = Nothing Then
                    MessageBox.Show("品種コード(品種)を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 2).Focus()
                    err_flg = "1"
                    Exit Sub
                End If
                DtView12 = New DataView(dsItem2.Tables("cat"), "cd1 ='" & edit(i, 1).Text & "' AND cd2 ='" & edit(i, 2).Text & "' AND cd3 = '00'", "", DataViewRowState.CurrentRows)
                If DtView12.Count = 0 Then
                    MessageBox.Show("該当する品種がありません", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 1).Focus()
                    err_flg = "1"
                    Exit Sub
                Else
                    If IsDBNull(DtView12(0)("avlbty")) Then
                        MessageBox.Show("対象外品種です", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        edit(i, 1).Focus()
                        err_flg = "1"
                        Exit Sub
                    Else
                        If DtView12(0)("avlbty") <> "対象" Then
                            MessageBox.Show("対象外品種です", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            edit(i, 1).Focus()
                            err_flg = "1"
                            Exit Sub
                        End If
                    End If
                End If
                If edit(i, 3).Text = Nothing Then
                    MessageBox.Show("POSコードを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 3).Focus()
                    err_flg = "1"
                    Exit Sub
                End If
                If Len(edit(i, 3).Text) <> 8 Then
                    MessageBox.Show("POSコードは8桁です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    edit(i, 3).Focus()
                    err_flg = "1"
                    Exit Sub
                End If
                If num(i, 0).Value < 10500 Then
                    MessageBox.Show("購入金額(税込)は 10,500円以上です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    num(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                End If
                If datBox(i, 0).Text = "____/__/__" Then
                    MessageBox.Show("購入日を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    datBox(i, 0).Focus()
                    err_flg = "1"
                    Exit Sub
                End If
                If datBox(i, 0).Text < "2007/04/01" Then
                    MessageBox.Show("2007/03/31以前の購入日は入力できません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    'SEQ入力時
    Private Sub txt_no_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_no.Leave
        If txt_no.Value <> Nothing Then
            DtView5 = New DataView(dsItem4.Tables("shop"), "shop_code ='" & Mid(txt_no.Value, 1, 4) & "'", "", DataViewRowState.CurrentRows)
            If DtView5.Count <> 0 Then
                If Now() >= DateAdd(DateInterval.Day, -1, CDate(Format((DateAdd(DateInterval.Month, 2, DtView5(0)("close_date"))), "yyyy/MM/01"))) Then
                    MessageBox.Show("この伝票番号は閉鎖店舗のコードです。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    txt_shop_code.Text = Mid(txt_no.Value, 1, 4)
                    lbl_shop.Text = DtView5(0)("shop_name")
                End If
            Else
                MessageBox.Show("この伝票番号のコードに該当する店舗がありません。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    '申込日入力時
    Private Sub Date_ent_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_ent.Leave
        If Date_ent.Number = 0 Then
            MessageBox.Show("申込日が入力されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If IsDate(Date_ent.Text) = False Then
                MessageBox.Show("申込日が正しくありません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If CDate(DateAdd("m", 6, CDate(Date_ent.Text))) < Now() Then
                    MessageBox.Show("6ヶ月以前の申込日が入力されています", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        wrn_fee_sum = 0
        For i = 0 To Line_No
            label(i, 1).Text = Format(wrn_fee_comp(Date_ent.Text, label(i, 3).Text, num(i, 0).Value), "###,##0")
            wrn_fee_sum = wrn_fee_sum + label(i, 1).Text
        Next
        lbl_wrnttl.Text = Format(wrn_fee_sum, "###,##0")
    End Sub

    '店舗コード入力後処理
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
                txt_shop_code.Focus()
            End If
        End If
    End Sub

    '契約タイプ入力後処理
    Private Sub cmbbox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As ComboBox
        cmb = DirectCast(sender, ComboBox)

        label(cmb.Tag, 3).Text = Nothing

        If cmbbox(cmb.Tag, 1).Text <> Nothing Then
            DtView1 = New DataView(DsCMB.Tables("cls015" & Line_No), "CLS_NAME ='" & cmbbox(cmb.Tag, 1).Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                label(cmb.Tag, 3).Text = DtView1(0)("CLS_CODE")
            Else
                MessageBox.Show("該当する契約タイプがありません")
            End If
        End If
        label(cmb.Tag, 1).Text = Format(wrn_fee_comp(Date_ent.Text, label(cmb.Tag, 3).Text, num(cmb.Tag, 0).Value), "###,##0")
        wrn_fee_sum = 0
        For i = 0 To Line_No
            'label(i, 1).Text = wrn_fee_comp(Date_ent.Text, label(i, 3).Text, num(i, 0).Value)
            wrn_fee_sum = wrn_fee_sum + label(i, 1).Text
        Next
        lbl_wrnttl.Text = Format(wrn_fee_sum, "###,##0")
    End Sub

    '品種コード1入力後処理
    Private Sub cat1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim edt As GrapeCity.Win.Input.Interop.Edit
        edt = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)

        If edit(edt.Tag, 2).Text <> Nothing Then
            DtView1 = New DataView(dsItem2.Tables("cat"), "cd1 ='" & edit(edt.Tag, 1).Text & "' AND cd2 ='" & edit(edt.Tag, 2).Text & "' AND cd3 = '00'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                label(edt.Tag, 0).Text = DtView1(0)("cat_name")
                label(edt.Tag, 2).Text = DtView1(0)("cat_kana")
                WK_cat_prod(edt.Tag) = DtView1(0)("wrn_prod")
                If IsDBNull(DtView1(0)("avlbty")) Then
                    MessageBox.Show("対象外品種です")
                Else
                    If DtView1(0)("avlbty") <> "対象" Then
                        MessageBox.Show("対象外品種です")
                    End If
                End If
            Else
                MessageBox.Show("該当する商品がありません")
                label(edt.Tag, 0).Text = Nothing
            End If
        End If
    End Sub

    '品種コード2入力後処理
    Private Sub cat2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim edt As GrapeCity.Win.Input.Interop.Edit
        edt = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)

        If edit(edt.Tag, 1).Text <> Nothing Then
            DtView1 = New DataView(dsItem2.Tables("cat"), "cd1 ='" & edit(edt.Tag, 1).Text & "' AND cd2 ='" & edit(edt.Tag, 2).Text & "' AND cd3 = '00'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                label(edt.Tag, 0).Text = DtView1(0)("cat_name")
                label(edt.Tag, 2).Text = DtView1(0)("cat_kana")
                WK_cat_prod(edt.Tag) = DtView1(0)("wrn_prod")
                If IsDBNull(DtView1(0)("avlbty")) Then
                    MessageBox.Show("対象外品種です")
                Else
                    If DtView1(0)("avlbty") <> "対象" Then
                        MessageBox.Show("対象外品種です")
                    End If
                End If
            Else
                MessageBox.Show("該当する商品がありません")
                label(edt.Tag, 0).Text = Nothing
            End If
        End If
    End Sub

    '購入価格入力後処理
    Private Sub prch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim numbox As GrapeCity.Win.Input.Interop.Number
        numbox = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)

        If num(numbox.Tag, 0).Value >= 10500 Then
            label(numbox.Tag, 1).Text = Format(wrn_fee_comp(Date_ent.Text, label(numbox.Tag, 3).Text, num(numbox.Tag, 0).Value), "###,##0")
        Else
            MessageBox.Show("購入金額(税込)は、10,500円以上です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            num(numbox.Tag, 0).Value = 0
            label(numbox.Tag, 1).Text = 0
        End If
        wrn_fee_sum = 0
        For i = 0 To Line_No
            'label(i, 1).Text = wrn_fee_comp(Date_ent.Text, label(i, 3).Text, num(i, 0).Value)
            wrn_fee_sum = wrn_fee_sum + label(i, 1).Text
        Next
        lbl_wrnttl.Text = Format(wrn_fee_sum, "###,##0")
    End Sub

    '行コピークリック時
    Private Sub c_Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button
        btn = DirectCast(sender, Button)

        'If Line_No = btn.Tag Then
        'Call ADD_LINE()
        'End If

        If cmbbox(btn.Tag, 1).SelectedValue <> Nothing Then
            cmbbox(Line_No, 1).SelectedValue = cmbbox(btn.Tag, 1).SelectedValue
        End If
        label(Line_No, 0).Text = label(btn.Tag, 0).Text
        If cmbbox(btn.Tag, 0).SelectedValue <> Nothing Then
            cmbbox(Line_No, 0).SelectedValue = cmbbox(btn.Tag, 0).SelectedValue
        End If
        edit(Line_No, 0).Text = edit(btn.Tag, 0).Text
        edit(Line_No, 1).Text = edit(btn.Tag, 1).Text
        edit(Line_No, 2).Text = edit(btn.Tag, 2).Text
        edit(Line_No, 3).Text = edit(btn.Tag, 3).Text
        num(Line_No, 0).Value = num(btn.Tag, 0).Value
        datBox(Line_No, 0).Value = datBox(btn.Tag, 0).Value
        label(Line_No, 1).Text = label(btn.Tag, 1).Text
        label(Line_No, 2).Text = label(btn.Tag, 2).Text

        WK_cat_prod(Line_No) = WK_cat_prod(btn.Tag)

        wrn_fee_sum = 0
        For i = 0 To Line_No
            'label(i, 1).Text = wrn_fee_comp(Date_ent.Text, label(i, 3).Text, num(i, 0).Value)
            wrn_fee_sum = wrn_fee_sum + label(i, 1).Text
        Next
        lbl_wrnttl.Text = Format(wrn_fee_sum, "###,##0")
    End Sub

    '行キャンセルクリック時
    Private Sub d_Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button
        btn = DirectCast(sender, Button)

        cmbbox(btn.Tag, 1).Text = Nothing
        cmbbox(btn.Tag, 1).SelectedValue = ""
        label(btn.Tag, 0).Text = Nothing
        cmbbox(btn.Tag, 0).Text = Nothing
        cmbbox(btn.Tag, 0).SelectedValue = ""
        edit(btn.Tag, 0).Text = Nothing
        edit(btn.Tag, 1).Text = Nothing
        edit(btn.Tag, 2).Text = Nothing
        edit(btn.Tag, 3).Text = Nothing
        num(btn.Tag, 0).Value = 0
        datBox(btn.Tag, 0).Value = Nothing
        datBox(btn.Tag, 0).Text = "____/__/__"
        label(btn.Tag, 1).Text = 0
        label(btn.Tag, 3).Text = Nothing

        wrn_fee_sum = 0
        For i = 0 To Line_No
            'label(i, 1).Text = wrn_fee_comp(Date_ent.Text, label(i, 3).Text, num(i, 0).Value)
            wrn_fee_sum = wrn_fee_sum + label(i, 1).Text
        Next
        lbl_wrnttl.Text = Format(wrn_fee_sum, "###,##0")
    End Sub

    '次行作成時
    Private Sub DRWG_chg(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dat As GrapeCity.Win.Input.Interop.Date
        dat = DirectCast(sender, GrapeCity.Win.Input.Interop.Date)
        If dat.Tag = Line_No Then
            'Call ADD_LINE()
            cmbbox(Line_No, 1).Focus()
        ElseIf dat.Tag > 99 Then
            MessageBox.Show("100行以上は作成できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    '住所2入力後処理
    Private Sub txt_adrs2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_adrs2.Leave
        cmbbox(0, 1).Focus()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        BY_cls.Text = "B"
        cmb_reset()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        BY_cls.Text = "Y"
        cmb_reset()
    End Sub

    Sub cmb_reset()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If inz = "1" Then
            For i = 0 To Line_No

                'メーカー
                dsItem3.Clear()
                Dim SqlSelectCommand3 As New SqlClient.SqlCommand
                SqlSelectCommand3 = New SqlClient.SqlCommand("SELECT vdr_code, RTRIM(vdr_name) AS Name FROM vdr_mtr WHERE (BY_cls = '" & BY_cls.Text & "') ORDER BY use_date DESC, vdr_name", cnsqlclient)
                SqlSelectCommand3.CommandType = CommandType.Text
                Dim daItem3 As New SqlClient.SqlDataAdapter
                daItem3.SelectCommand = SqlSelectCommand3

                DB_OPEN("best_wrn")
                daItem3.Fill(dsItem3, "vdr" & Line_No)
                DB_CLOSE()
                cmbbox(i, 0).Text = Nothing

                label(i, 0).Text = Nothing
                edit(i, 1).Text = Nothing
                edit(i, 2).Text = Nothing
            Next

            '品種マスタ
            dsItem2.Clear()
            Dim SqlSelectCommand2 As New SqlClient.SqlCommand
            SqlSelectCommand2 = New SqlClient.SqlCommand("SELECT cd1, cd2, cd3, [品種名(漢字)] as cat_name, [品種名(ｶﾅ)] as cat_kana, wrn_prod, avlbty, GRP FROM cat_mtr WHERE (BY_cls = '" & BY_cls.Text & "')", cnsqlclient)
            SqlSelectCommand2.CommandType = CommandType.Text
            Dim daItem2 As New SqlClient.SqlDataAdapter
            daItem2.SelectCommand = SqlSelectCommand2

            DB_OPEN("best_wrn")
            daItem2.Fill(dsItem2, "cat")
            DB_CLOSE()

            '店舗マスタ
            dsItem4.Clear()
            Dim SqlSelectCommand4 As New SqlClient.SqlCommand
            SqlSelectCommand4 = New SqlClient.SqlCommand("SELECT shop_code, [店舗名(漢字)] as shop_name, close_date FROM shop_mtr WHERE (BY_cls = '" & BY_cls.Text & "')", cnsqlclient)
            SqlSelectCommand4.CommandType = CommandType.Text
            Dim daItem4 As New SqlClient.SqlDataAdapter
            daItem4.SelectCommand = SqlSelectCommand4

            DB_OPEN("best_wrn")
            daItem4.Fill(dsItem4, "shop")
            DB_CLOSE()
            txt_shop_code.Text = Nothing
            lbl_shop.Text = Nothing
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
