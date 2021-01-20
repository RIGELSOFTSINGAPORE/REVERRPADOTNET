Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2, WK_DsList1 As New DataSet
    Dim DsTrbl, DsWrn, DsCMB5, DsCMB6, DsCMB7, DsCMB9, DsCMB10 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim DtView3, DtView4 As DataView
    Dim DtTbl1 As DataTable

    Dim strSQL, Err_F, New_Old, str_ANS As String
    Dim Data_F05, Data_F06 As String
    Dim WK_ordr_no, WK_line_no, WK_close_date As String
    Dim WK_seq, WK_Limit_money As Integer
    Dim i As Integer
    Dim WK_kbn_No As String
    Dim WK_P As Integer
    Dim WK_date As Date

    Dim BRK_01, BRK_02, BRK_03, BRK_04, BRK_05, BRK_06 As String
    Dim WK_s_flg, WK_b_flg2, WK_b_flg As String  'ソニア引受分、ベスト引受分
    Dim WK_corp_flg As String
    Dim WK_msg As String

    Dim WK_wrn_prod As Integer
    Dim WK_GRP As String
    Dim WK_nen As Integer
    Dim WK_entry_date As Date

    Dim BR_date2 As Date

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim namedif_f As Boolean    '顧客名チェックフラグ：登録名と請求情報の相違有の場合、true

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Number11 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number10 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number9 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number8 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number7 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number6 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Date4 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date3 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Number4 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents ComboBox12 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox11 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Number3 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents MSG As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Number2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button98 = New System.Windows.Forms.Button()
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Number11 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number10 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number9 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number8 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number7 = New GrapeCity.Win.Input.Interop.Number()
        Me.Number6 = New GrapeCity.Win.Input.Interop.Number()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Date4 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Date3 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Date2 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Number4 = New GrapeCity.Win.Input.Interop.Number()
        Me.ComboBox12 = New System.Windows.Forms.ComboBox()
        Me.ComboBox11 = New System.Windows.Forms.ComboBox()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Date1 = New GrapeCity.Win.Input.Interop.[Date]()
        Me.Number3 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number()
        Me.MSG = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Number2 = New GrapeCity.Win.Input.Interop.Number()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Edit5 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 536)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 910
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(720, 536)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 980
        Me.Button98.Text = "戻る"
        '
        'Edit1
        '
        Me.Edit1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit1.Format = "9A"
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit1.Location = New System.Drawing.Point(144, 120)
        Me.Edit1.MaxLength = 14
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Size = New System.Drawing.Size(128, 25)
        Me.Edit1.TabIndex = 10
        Me.Edit1.Text = "99999999999999"
        '
        'Number11
        '
        Me.Number11.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number11.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number11.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number11.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number11.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number11.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number11.Enabled = False
        Me.Number11.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number11.HighlightText = True
        Me.Number11.Location = New System.Drawing.Point(544, 360)
        Me.Number11.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number11.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number11.Name = "Number11"
        Me.Number11.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number11.Size = New System.Drawing.Size(88, 24)
        Me.Number11.TabIndex = 280
        Me.Number11.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number11.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number11.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number10
        '
        Me.Number10.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number10.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number10.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number10.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number10.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number10.Enabled = False
        Me.Number10.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number10.HighlightText = True
        Me.Number10.Location = New System.Drawing.Point(544, 336)
        Me.Number10.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number10.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number10.Name = "Number10"
        Me.Number10.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number10.Size = New System.Drawing.Size(88, 24)
        Me.Number10.TabIndex = 270
        Me.Number10.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number10.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number10.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number9
        '
        Me.Number9.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number9.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number9.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number9.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number9.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number9.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number9.Enabled = False
        Me.Number9.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number9.HighlightText = True
        Me.Number9.Location = New System.Drawing.Point(544, 312)
        Me.Number9.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number9.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number9.Name = "Number9"
        Me.Number9.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number9.Size = New System.Drawing.Size(88, 24)
        Me.Number9.TabIndex = 260
        Me.Number9.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number9.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number9.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number8
        '
        Me.Number8.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number8.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number8.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number8.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number8.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number8.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number8.Enabled = False
        Me.Number8.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number8.HighlightText = True
        Me.Number8.Location = New System.Drawing.Point(544, 288)
        Me.Number8.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number8.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number8.Name = "Number8"
        Me.Number8.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number8.Size = New System.Drawing.Size(88, 24)
        Me.Number8.TabIndex = 250
        Me.Number8.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number8.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number8.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number7
        '
        Me.Number7.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number7.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number7.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number7.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number7.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number7.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number7.Enabled = False
        Me.Number7.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number7.HighlightText = True
        Me.Number7.Location = New System.Drawing.Point(544, 264)
        Me.Number7.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number7.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number7.Name = "Number7"
        Me.Number7.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number7.Size = New System.Drawing.Size(88, 24)
        Me.Number7.TabIndex = 240
        Me.Number7.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number7.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number7.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Number6
        '
        Me.Number6.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number6.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number6.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "")
        Me.Number6.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number6.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number6.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number6.Enabled = False
        Me.Number6.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "")
        Me.Number6.HighlightText = True
        Me.Number6.Location = New System.Drawing.Point(544, 240)
        Me.Number6.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number6.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number6.Name = "Number6"
        Me.Number6.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number6.Size = New System.Drawing.Size(88, 24)
        Me.Number6.TabIndex = 230
        Me.Number6.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number6.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number6.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        '
        'TextBox3
        '
        Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox3.Location = New System.Drawing.Point(144, 240)
        Me.TextBox3.MaxLength = 15
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(232, 24)
        Me.TextBox3.TabIndex = 60
        Me.TextBox3.Text = "TextBox3"
        '
        'TextBox2
        '
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox2.Location = New System.Drawing.Point(144, 216)
        Me.TextBox2.MaxLength = 20
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(232, 24)
        Me.TextBox2.TabIndex = 50
        Me.TextBox2.Text = "TextBox2"
        '
        'Date4
        '
        Me.Date4.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date4.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date4.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date4.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date4.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date4.Location = New System.Drawing.Point(544, 432)
        Me.Date4.Name = "Date4"
        Me.Date4.Size = New System.Drawing.Size(88, 24)
        Me.Date4.TabIndex = 310
        Me.Date4.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Date3
        '
        Me.Date3.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date3.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date3.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date3.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date3.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date3.Location = New System.Drawing.Point(544, 216)
        Me.Date3.Name = "Date3"
        Me.Date3.Size = New System.Drawing.Size(88, 24)
        Me.Date3.TabIndex = 220
        Me.Date3.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date2.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(544, 192)
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(88, 24)
        Me.Date2.TabIndex = 210
        Me.Date2.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Edit2
        '
        Me.Edit2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit2.Format = "9#"
        Me.Edit2.HighlightText = True
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit2.Location = New System.Drawing.Point(544, 168)
        Me.Edit2.MaxLength = 15
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Size = New System.Drawing.Size(120, 25)
        Me.Edit2.TabIndex = 180
        Me.Edit2.Text = "03-1234-5678"
        '
        'Number4
        '
        Me.Number4.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("000000000000", "", "", "-", "", "", "")
        Me.Number4.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number4.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number4.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number4.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("000000000000", "", "", "-", "", "", "")
        Me.Number4.HighlightText = True
        Me.Number4.Location = New System.Drawing.Point(712, 312)
        Me.Number4.MaxValue = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Number4.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number4.Name = "Number4"
        Me.Number4.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number4.Size = New System.Drawing.Size(120, 24)
        Me.Number4.TabIndex = 170
        Me.Number4.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Number4.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number4.Value = Nothing
        Me.Number4.Visible = False
        '
        'ComboBox12
        '
        Me.ComboBox12.Location = New System.Drawing.Point(544, 456)
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(120, 24)
        Me.ComboBox12.TabIndex = 320
        Me.ComboBox12.Text = "ComboBox12"
        '
        'ComboBox11
        '
        Me.ComboBox11.Location = New System.Drawing.Point(144, 144)
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(120, 24)
        Me.ComboBox11.TabIndex = 20
        Me.ComboBox11.Text = "ComboBox11"
        '
        'ComboBox8
        '
        Me.ComboBox8.Location = New System.Drawing.Point(544, 120)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox8.TabIndex = 160
        Me.ComboBox8.Text = "ComboBox8"
        '
        'ComboBox7
        '
        Me.ComboBox7.Location = New System.Drawing.Point(144, 480)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox7.TabIndex = 150
        Me.ComboBox7.Text = "ComboBox7"
        '
        'ComboBox6
        '
        Me.ComboBox6.Location = New System.Drawing.Point(144, 432)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox6.TabIndex = 140
        Me.ComboBox6.Text = "ComboBox6"
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(144, 312)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox4.TabIndex = 90
        Me.ComboBox4.Text = "ComboBox4"
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(144, 384)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox3.TabIndex = 120
        Me.ComboBox3.Text = "ComboBox3"
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(144, 192)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox2.TabIndex = 40
        Me.ComboBox2.Text = "ComboBox2"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(144, 360)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox1.TabIndex = 110
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Date1.DropDownCalendar.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(270, 197)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(144, 288)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(88, 24)
        Me.Date1.TabIndex = 80
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 13, 10, 48, 3, 0))
        '
        'Number3
        '
        Me.Number3.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0000", "", "", "-", "", "", "")
        Me.Number3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number3.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number3.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number3.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0000", "", "", "-", "", "", "")
        Me.Number3.HighlightText = True
        Me.Number3.Location = New System.Drawing.Point(144, 336)
        Me.Number3.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Name = "Number3"
        Me.Number3.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number3.Size = New System.Drawing.Size(48, 24)
        Me.Number3.TabIndex = 100
        Me.Number3.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Number3.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number3.Value = Nothing
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.DarkBlue
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label31.Location = New System.Drawing.Point(416, 456)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(128, 24)
        Me.Label31.TabIndex = 364
        Me.Label31.Text = "掛種ｺｰﾄﾞ"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.DarkBlue
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label30.Location = New System.Drawing.Point(16, 144)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(128, 24)
        Me.Label30.TabIndex = 363
        Me.Label30.Text = "請求区分"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.DarkBlue
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label29.Location = New System.Drawing.Point(416, 432)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(128, 24)
        Me.Label29.TabIndex = 362
        Me.Label29.Text = "処理日"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.DarkBlue
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label28.Location = New System.Drawing.Point(416, 408)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(128, 24)
        Me.Label28.TabIndex = 360
        Me.Label28.Text = "修理番号"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.DarkBlue
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label27.Location = New System.Drawing.Point(416, 360)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(128, 24)
        Me.Label27.TabIndex = 359
        Me.Label27.Text = "請求額"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.DarkBlue
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label26.Location = New System.Drawing.Point(416, 336)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(128, 24)
        Me.Label26.TabIndex = 358
        Me.Label26.Text = "請求除外金額"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label25.Location = New System.Drawing.Point(416, 312)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 24)
        Me.Label25.TabIndex = 357
        Me.Label25.Text = "値引き額"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label24.Location = New System.Drawing.Point(416, 288)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 24)
        Me.Label24.TabIndex = 356
        Me.Label24.Text = "部品計料"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label23.Location = New System.Drawing.Point(416, 264)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(128, 24)
        Me.Label23.TabIndex = 355
        Me.Label23.Text = "作業料"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label22.Location = New System.Drawing.Point(416, 240)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(128, 24)
        Me.Label22.TabIndex = 354
        Me.Label22.Text = "出張料"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label21.Location = New System.Drawing.Point(416, 216)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(128, 24)
        Me.Label21.TabIndex = 353
        Me.Label21.Text = "修理完了日"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label20.Location = New System.Drawing.Point(416, 192)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 24)
        Me.Label20.TabIndex = 352
        Me.Label20.Text = "修理受付日"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label19.Location = New System.Drawing.Point(16, 240)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 24)
        Me.Label19.TabIndex = 351
        Me.Label19.Text = "修理品製造番号"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label18.Location = New System.Drawing.Point(16, 216)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 24)
        Me.Label18.TabIndex = 349
        Me.Label18.Text = "型式"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label15.Location = New System.Drawing.Point(416, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 24)
        Me.Label15.TabIndex = 346
        Me.Label15.Text = "電話番号"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label14.Location = New System.Drawing.Point(16, 264)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 24)
        Me.Label14.TabIndex = 345
        Me.Label14.Text = "顧客名称"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label13.Location = New System.Drawing.Point(416, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 24)
        Me.Label13.TabIndex = 344
        Me.Label13.Text = "修理伝票番号"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label12.Location = New System.Drawing.Point(416, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 24)
        Me.Label12.TabIndex = 343
        Me.Label12.Text = "伝票区分"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label11.Location = New System.Drawing.Point(16, 456)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 48)
        Me.Label11.TabIndex = 342
        Me.Label11.Text = "修理完了店"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label10.Location = New System.Drawing.Point(16, 408)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 48)
        Me.Label10.TabIndex = 341
        Me.Label10.Text = "修理受付店"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label8.Location = New System.Drawing.Point(16, 312)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 24)
        Me.Label8.TabIndex = 339
        Me.Label8.Text = "全損ﾌﾗｸﾞ"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label7.Location = New System.Drawing.Point(16, 384)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 24)
        Me.Label7.TabIndex = 337
        Me.Label7.Text = "項目有無ﾌﾗｸﾞ"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label6.Location = New System.Drawing.Point(16, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 336
        Me.Label6.Text = "事故状況ﾌﾗｸﾞ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label5.Location = New System.Drawing.Point(16, 360)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 24)
        Me.Label5.TabIndex = 335
        Me.Label5.Text = "事故場所"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label4.Location = New System.Drawing.Point(16, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 24)
        Me.Label4.TabIndex = 334
        Me.Label4.Text = "事故日"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(16, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 24)
        Me.Label3.TabIndex = 333
        Me.Label3.Text = "承認番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label2.Location = New System.Drawing.Point(16, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 332
        Me.Label2.Text = "保証番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(16, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 331
        Me.Label1.Text = "請求番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######", "", "", "-", "", "", "")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######", "", "", "-", "", "", "")
        Me.Number1.HighlightText = True
        Me.Number1.Location = New System.Drawing.Point(144, 168)
        Me.Number1.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Size = New System.Drawing.Size(64, 24)
        Me.Number1.TabIndex = 30
        Me.Number1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Number1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number1.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        '
        'MSG
        '
        Me.MSG.ForeColor = System.Drawing.Color.Red
        Me.MSG.Location = New System.Drawing.Point(8, 512)
        Me.MSG.Name = "MSG"
        Me.MSG.Size = New System.Drawing.Size(776, 24)
        Me.MSG.TabIndex = 396
        Me.MSG.Text = "MSG"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Yellow
        Me.Label33.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label33.Location = New System.Drawing.Point(16, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 24)
        Me.Label33.TabIndex = 397
        Me.Label33.Text = "Error SEQ："
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label34.Location = New System.Drawing.Point(104, 8)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 24)
        Me.Label34.TabIndex = 398
        Me.Label34.Text = "Label34"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.ForeColor = System.Drawing.Color.Red
        Me.Label35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label35.Location = New System.Drawing.Point(176, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(296, 24)
        Me.Label35.TabIndex = 399
        Me.Label35.Text = "Label35"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Number2
        '
        Me.Number2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number2.DropDownCalculator.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(242, 220)
        Me.Number2.Enabled = False
        Me.Number2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0", "", "", "-", "", "", "")
        Me.Number2.HighlightText = True
        Me.Number2.Location = New System.Drawing.Point(544, 384)
        Me.Number2.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number2.Name = "Number2"
        Me.Number2.PopUpCalculator.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Size = New System.Drawing.Size(88, 24)
        Me.Number2.TabIndex = 290
        Me.Number2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Number2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number2.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.DarkBlue
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label38.Location = New System.Drawing.Point(416, 384)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(128, 24)
        Me.Label38.TabIndex = 402
        Me.Label38.Text = "見積り額"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(240, 288)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(128, 24)
        Me.Label32.TabIndex = 981
        Me.Label32.Text = "Label32"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(640, 192)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(128, 24)
        Me.Label36.TabIndex = 982
        Me.Label36.Text = "Label36"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.ForeColor = System.Drawing.Color.Red
        Me.Label37.Location = New System.Drawing.Point(640, 216)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(128, 24)
        Me.Label37.TabIndex = 983
        Me.Label37.Text = "Label37"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.ForeColor = System.Drawing.Color.Red
        Me.Label39.Location = New System.Drawing.Point(640, 432)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(128, 24)
        Me.Label39.TabIndex = 984
        Me.Label39.Text = "Label39"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Green
        Me.Label40.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label40.Location = New System.Drawing.Point(120, 48)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(80, 24)
        Me.Label40.TabIndex = 1021
        Me.Label40.Text = "契約状況"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Green
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(200, 48)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(88, 24)
        Me.Label41.TabIndex = 1020
        Me.Label41.Text = "Label41"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Green
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(400, 72)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(64, 24)
        Me.Label42.TabIndex = 1019
        Me.Label42.Text = "Label42"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Green
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(400, 48)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(64, 24)
        Me.Label43.TabIndex = 1018
        Me.Label43.Text = "Label43"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Green
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(200, 72)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(88, 24)
        Me.Label44.TabIndex = 1017
        Me.Label44.Text = "Label44"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Green
        Me.Label45.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label45.Location = New System.Drawing.Point(296, 72)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(104, 24)
        Me.Label45.TabIndex = 1016
        Me.Label45.Text = "保証限度額"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Green
        Me.Label46.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label46.Location = New System.Drawing.Point(296, 48)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(104, 24)
        Me.Label46.TabIndex = 1015
        Me.Label46.Text = "購入価格"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Green
        Me.Label47.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label47.Location = New System.Drawing.Point(120, 72)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(80, 24)
        Me.Label47.TabIndex = 1014
        Me.Label47.Text = "購入日"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Green
        Me.Label48.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label48.Location = New System.Drawing.Point(24, 48)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(96, 24)
        Me.Label48.TabIndex = 1022
        Me.Label48.Text = "加入情報"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Green
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(16, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(832, 64)
        Me.PictureBox1.TabIndex = 1023
        Me.PictureBox1.TabStop = False
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Green
        Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label49.Location = New System.Drawing.Point(544, 48)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(40, 24)
        Me.Label49.TabIndex = 1024
        Me.Label49.Text = "Label49"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Green
        Me.Label50.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label50.Location = New System.Drawing.Point(472, 48)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(72, 24)
        Me.Label50.TabIndex = 1025
        Me.Label50.Text = "全損Flag"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.Font = New System.Drawing.Font("MS PGothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Red
        Me.Label51.Location = New System.Drawing.Point(488, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(352, 16)
        Me.Label51.TabIndex = 1028
        Me.Label51.Text = "Label51"
        '
        'Label52
        '
        Me.Label52.Font = New System.Drawing.Font("MS PGothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Red
        Me.Label52.Location = New System.Drawing.Point(488, 16)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(352, 16)
        Me.Label52.TabIndex = 1027
        Me.Label52.Text = "Label52"
        '
        'CheckBox1
        '
        Me.CheckBox1.ForeColor = System.Drawing.Color.Red
        Me.CheckBox1.Location = New System.Drawing.Point(640, 360)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(168, 24)
        Me.CheckBox1.TabIndex = 1029
        Me.CheckBox1.TabStop = False
        Me.CheckBox1.Text = "限度額ﾁｪｯｸをしない"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.ForeColor = System.Drawing.Color.Yellow
        Me.Button4.Location = New System.Drawing.Point(248, 536)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 920
        Me.Button4.Text = "削除"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox1.LengthAsByte = True
        Me.TextBox1.Location = New System.Drawing.Point(144, 264)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(232, 24)
        Me.TextBox1.TabIndex = 70
        Me.TextBox1.Text = "TextBox1"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Green
        Me.Label53.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label53.Location = New System.Drawing.Point(472, 72)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(72, 24)
        Me.Label53.TabIndex = 1031
        Me.Label53.Text = "期間区分"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Green
        Me.Label54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label54.Location = New System.Drawing.Point(544, 72)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(40, 24)
        Me.Label54.TabIndex = 1030
        Me.Label54.Text = "Label54"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox2
        '
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.ForeColor = System.Drawing.Color.Red
        Me.CheckBox2.Location = New System.Drawing.Point(376, 216)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(32, 24)
        Me.CheckBox2.TabIndex = 1032
        Me.CheckBox2.TabStop = False
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("MS PGothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Red
        Me.Label55.Location = New System.Drawing.Point(384, 240)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(16, 176)
        Me.Label55.TabIndex = 1033
        Me.Label55.Text = "前回不一致ﾁｪｯｸをしない"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Green
        Me.Label56.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label56.Location = New System.Drawing.Point(592, 48)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(48, 24)
        Me.Label56.TabIndex = 1035
        Me.Label56.Text = "品種"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Green
        Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label57.Location = New System.Drawing.Point(640, 48)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(96, 24)
        Me.Label57.TabIndex = 1034
        Me.Label57.Text = "Label57"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit5
        '
        Me.Edit5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit5.Format = "9"
        Me.Edit5.HighlightText = True
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit5.Location = New System.Drawing.Point(544, 144)
        Me.Edit5.MaxLength = 13
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Size = New System.Drawing.Size(120, 25)
        Me.Edit5.TabIndex = 170
        Me.Edit5.Text = "1234567890123"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label60.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(296, 408)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(40, 24)
        Me.Label60.TabIndex = 1114
        Me.Label60.Text = "Label60"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label60.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Location = New System.Drawing.Point(144, 400)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(152, 32)
        Me.GroupBox2.TabIndex = 135
        Me.GroupBox2.TabStop = False
        '
        'RadioButton3
        '
        Me.RadioButton3.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton3.Location = New System.Drawing.Point(8, 12)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.Text = "B"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'RadioButton4
        '
        Me.RadioButton4.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton4.Location = New System.Drawing.Point(84, 12)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton4.TabIndex = 1
        Me.RadioButton4.Text = "Y"
        Me.RadioButton4.UseVisualStyleBackColor = False
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label66.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.Black
        Me.Label66.Location = New System.Drawing.Point(296, 456)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(40, 24)
        Me.Label66.TabIndex = 1116
        Me.Label66.Text = ".Label66"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label66.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.RadioButton5)
        Me.GroupBox3.Controls.Add(Me.RadioButton6)
        Me.GroupBox3.Location = New System.Drawing.Point(144, 448)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(152, 32)
        Me.GroupBox3.TabIndex = 145
        Me.GroupBox3.TabStop = False
        '
        'RadioButton5
        '
        Me.RadioButton5.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton5.Location = New System.Drawing.Point(8, 12)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton5.TabIndex = 0
        Me.RadioButton5.Text = "B"
        Me.RadioButton5.UseVisualStyleBackColor = False
        '
        'RadioButton6
        '
        Me.RadioButton6.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton6.Location = New System.Drawing.Point(84, 12)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(76, 20)
        Me.RadioButton6.TabIndex = 1
        Me.RadioButton6.Text = "Y"
        Me.RadioButton6.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Green
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(784, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 24)
        Me.Label9.TabIndex = 1117
        Me.Label9.Text = "Label9"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Green
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(784, 136)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 24)
        Me.Label16.TabIndex = 1118
        Me.Label16.Text = "Label16"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Green
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(784, 160)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 24)
        Me.Label17.TabIndex = 1119
        Me.Label17.Text = "Label17"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.Visible = False
        '
        'Edit3
        '
        Me.Edit3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit3.Format = "9"
        Me.Edit3.HighlightText = True
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit3.Location = New System.Drawing.Point(544, 408)
        Me.Edit3.MaxLength = 13
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Size = New System.Drawing.Size(120, 25)
        Me.Edit3.TabIndex = 300
        Me.Edit3.Text = "1234567890123"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.Control
        Me.Label58.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label58.Location = New System.Drawing.Point(544, 480)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(120, 24)
        Me.Label58.TabIndex = 1120
        Me.Label58.Text = "Label58"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.DarkBlue
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label59.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label59.Location = New System.Drawing.Point(416, 480)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(128, 24)
        Me.Label59.TabIndex = 1121
        Me.Label59.Text = "取込処理日"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Green
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(784, 184)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(64, 24)
        Me.Label61.TabIndex = 1122
        Me.Label61.Text = "Label61"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label61.Visible = False
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(866, 575)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.MSG)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Number11)
        Me.Controls.Add(Me.Number10)
        Me.Controls.Add(Me.Number9)
        Me.Controls.Add(Me.Number8)
        Me.Controls.Add(Me.Number7)
        Me.Controls.Add(Me.Number6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Date4)
        Me.Controls.Add(Me.Date3)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Number4)
        Me.Controls.Add(Me.ComboBox12)
        Me.Controls.Add(Me.ComboBox11)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Number3)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エラーデータ修正"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '起動時
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        MSG.Text = Nothing
        Label34.Text = P_Error_seq
        Label35.Text = Trim(P_Error_msg)

        '前画面で選択したエラー情報の取得
        Call DsSet()

        'コンボボックス初期表示
        Call CmbSet()

        '初期化処理
        Call mtrClr()

        '画面初期表示
        Call DspSet()

        '加入情報表示
        Call main_set()

        '表示チェック
        Call DspChk()

        ''限度額設定
        'Call up_line()

        If WK_s_flg = "True" Then MsgBox("ソニア引受分")
        If WK_b_flg2 = "True" Then MsgBox("ベスト引受分")

    End Sub

    'エラー情報取得 ----------------------------------------------------------------------
    Sub DsSet()
        DB_OPEN("best_wrn")

        'エラーデータ
        SqlCmd1 = New SqlClient.SqlCommand("SP_best_ivc_err_mnt_4", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 10)
        Pram1.Value = P_Error_seq
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "Error_data_ivc")

        DB_CLOSE()
    End Sub

    'コンボボックス初期表示設定 -----------------------------------------------------------
    Sub CmbSet()

        '事故場所
        ComboBox1.DataSource = P_DsCMB.Tables("CLS_CODE_001")
        ComboBox1.DisplayMember = "CLS_CODE_NAME"
        ComboBox1.ValueMember = "CLS_CODE"

        '事故状況ﾌﾗｸﾞ
        ComboBox2.DataSource = P_DsCMB.Tables("CLS_CODE_002")
        ComboBox2.DisplayMember = "CLS_CODE_NAME"
        ComboBox2.ValueMember = "CLS_CODE"

        '項目有無ﾌﾗｸﾞ
        ComboBox3.DataSource = P_DsCMB.Tables("CLS_CODE_003")
        ComboBox3.DisplayMember = "CLS_CODE_NAME"
        ComboBox3.ValueMember = "CLS_CODE"

        '全損ﾌﾗｸﾞ
        ComboBox4.DataSource = P_DsCMB.Tables("CLS_CODE_004")
        ComboBox4.DisplayMember = "CLS_CODE_NAME"
        ComboBox4.ValueMember = "CLS_CODE"

        '伝票区分
        ComboBox8.DataSource = P_DsCMB.Tables("CLS_CODE_005")
        ComboBox8.DisplayMember = "CLS_CODE_NAME"
        ComboBox8.ValueMember = "CLS_CODE"

        '請求区分
        ComboBox11.DataSource = P_DsCMB.Tables("CLS_CODE_007")
        ComboBox11.DisplayMember = "CLS_CODE_NAME"
        ComboBox11.ValueMember = "CLS_CODE"

        '掛種コード
        ComboBox12.DataSource = P_DsCMB.Tables("kakesyu")
        ComboBox12.DisplayMember = "insurance_code"
        ComboBox12.ValueMember = "kakesyu"

        '修理受付店
        CmbSet6()

        '修理完了店
        CmbSet7()

    End Sub

    '修理受付店取得および設定 ---------------------------------------------------------------------
    Sub CmbSet6()
        DsCMB6.Clear()
        '店舗
        strSQL = "SELECT shop_code, shop_code + ' : ' + RTRIM([店舗名(漢字)]) AS 店舗名"
        strSQL += " FROM Shop_mtr"
        strSQL += " WHERE (BY_cls = '" & Label60.Text & "')"
        strSQL += " ORDER BY shop_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(DsCMB6, "Shop_mtr")
        DB_CLOSE()

        ComboBox6.DataSource = DsCMB6.Tables("Shop_mtr")
        ComboBox6.DisplayMember = "店舗名"
        ComboBox6.ValueMember = "shop_code"
    End Sub

    '修理完了店取得および設定 ---------------------------------------------------------------------
    Sub CmbSet7()
        DsCMB7.Clear()
        '店舗
        strSQL = "SELECT shop_code, shop_code + ' : ' + RTRIM([店舗名(漢字)]) AS 店舗名"
        strSQL += " FROM Shop_mtr"
        strSQL += " WHERE (BY_cls = '" & Label66.Text & "')"
        strSQL += " ORDER BY shop_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(DsCMB7, "Shop_mtr")
        DB_CLOSE()

        ComboBox7.DataSource = DsCMB7.Tables("Shop_mtr")
        ComboBox7.DisplayMember = "店舗名"
        ComboBox7.ValueMember = "shop_code"
    End Sub


    '初期表示
    Sub DspSet()

        DtView1 = New DataView(DsList1.Tables("Error_data_ivc"), "", "", DataViewRowState.CurrentRows)

        'エラーデータがある場合
        If DtView1.Count <> 0 Then

            '締め日
            If Not IsDBNull(DtView1(0)("close_date")) Then
                P_close_date = DtView1(0)("close_date")
                WK_close_date = P_close_date
            End If
            'メッセージ表示用ラベル初期化
            Label51.Text = Nothing
            Label52.Text = Nothing
            'Form1のDsSet()取得したデータ（保険会社, 区分）を格納したP_DsList1を使用
            DtView2 = New DataView(P_DsList1.Tables("CLS_CODE"), "CLS_NO='999' AND CLS_CODE='0'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                If P_close_date <= CDate(DtView2(0)("CLS_CODE_NAME")) Then
                    Label51.Text = "既に" & Format(CDate(DtView2(0)("CLS_CODE_NAME")), "yyyy年MM月度まで") & "締め処理を行っていますので、"
                    Label52.Text = "修正データは" & Format(DateAdd(DateInterval.Month, 1, CDate(DtView2(0)("CLS_CODE_NAME"))), "yyyy年MM月度") & "で処理されます。"
                    P_close_date = DateAdd(DateInterval.Month, 1, CDate(DtView2(0)("CLS_CODE_NAME")))
                    WK_close_date = P_close_date
                End If
            End If

            '保証番号
            If Not IsDBNull(DtView1(0)("ordr_no")) Then Edit1.Text = Trim(DtView1(0)("ordr_no")) Else Edit1.Text = Nothing
            BRK_01 = Trim(Edit1.Text)
            '請求区分（1：請求　2：取消）
            If Not IsDBNull(DtView1(0)("FLD032")) Then ComboBox11.SelectedValue = DtView1(0)("FLD032") Else ComboBox11.Text = Nothing
            '請求番号
            If Not IsDBNull(DtView1(0)("FLD002")) And DtView1(0)("FLD002") <> "      " Then
                Number1.Value = DtView1(0)("FLD002")
            Else
                Number1.Value = 0
            End If
            '事故状況ﾌﾗｸﾞ（0～4：）
            If Not IsDBNull(DtView1(0)("FLD007")) Then ComboBox2.SelectedValue = DtView1(0)("FLD007") Else ComboBox2.Text = Nothing
            BRK_04 = Trim(ComboBox2.Text)
            '型式
            If Not IsDBNull(DtView1(0)("FLD019")) Then TextBox2.Text = Trim(DtView1(0)("FLD019")) Else TextBox2.Text = Nothing
            BRK_02 = Trim(TextBox2.Text)
            '修理品製造番号
            If Not IsDBNull(DtView1(0)("FLD020")) Then TextBox3.Text = Trim(DtView1(0)("FLD020")) Else TextBox3.Text = Nothing
            '顧客名称
            If Not IsDBNull(DtView1(0)("FLD015")) Then TextBox1.Text = Trim(DtView1(0)("FLD015")) Else TextBox1.Text = Nothing
            BRK_03 = Trim(TextBox1.Text)
            '事故日
            If Not IsDBNull(DtView1(0)("FLD005")) Then
                If IsDate(Mid(DtView1(0)("FLD005"), 1, 4), Mid(DtView1(0)("FLD005"), 5, 2), Mid(DtView1(0)("FLD005"), 7, 2)) = True Then
                    Date1.Text = Mid(DtView1(0)("FLD005"), 1, 4) & "/" & Mid(DtView1(0)("FLD005"), 5, 2) & "/" & Mid(DtView1(0)("FLD005"), 7, 2)
                    WK_date = Date1.Text
                    Label32.Text = Nothing
                Else
                    Date1.Text = Nothing
                    WK_date = "1950/01/01"
                    Label32.Text = Mid(DtView1(0)("FLD005"), 1, 4) & "/" & Mid(DtView1(0)("FLD005"), 5, 2) & "/" & Mid(DtView1(0)("FLD005"), 7, 2)  '事故日
                End If
            Else
                Date1.Text = Nothing
                WK_date = "1950/01/01"
                Label32.Text = Nothing
            End If
            BRK_05 = Trim(Date1.Text)
            '全損フラグ（0：修理　1：全損）
            If Not IsDBNull(DtView1(0)("FLD009")) Then ComboBox4.SelectedValue = DtView1(0)("FLD009") Else ComboBox4.Text = Nothing
            '承認番号
            If Not IsDBNull(DtView1(0)("FLD004")) Then Number3.Value = DtView1(0)("FLD004") Else Number3.Value = 0
            '事故場所
            If Not IsDBNull(DtView1(0)("FLD006")) Then ComboBox1.SelectedValue = DtView1(0)("FLD006") Else ComboBox1.Text = Nothing
            '項目有無フラグ
            If Not IsDBNull(DtView1(0)("FLD008")) Then ComboBox3.SelectedValue = DtView1(0)("FLD008") Else ComboBox3.Text = Nothing
            '修理受付店
            If Not IsDBNull(DtView1(0)("ent_BY_cls")) Then
                If DtView1(0)("ent_BY_cls") = "B" Then
                    RadioButton3.Checked = True
                Else
                    RadioButton4.Checked = True
                End If
                Label60.Text = DtView1(0)("ent_BY_cls")
            End If

            CmbSet6()
            If Not IsDBNull(DtView1(0)("FLD011")) Then ComboBox6.SelectedValue = DtView1(0)("FLD011") Else ComboBox6.Text = Nothing '修理受付店
            '修理完了店
            If Not IsDBNull(DtView1(0)("fin_BY_cls")) Then
                If DtView1(0)("fin_BY_cls") = "B" Then
                    RadioButton5.Checked = True
                Else
                    RadioButton6.Checked = True
                End If
                Label66.Text = DtView1(0)("fin_BY_cls")
            End If
            CmbSet7()
            If Not IsDBNull(DtView1(0)("FLD012")) Then ComboBox7.SelectedValue = DtView1(0)("FLD012") Else ComboBox7.Text = Nothing '修理完了店
            '伝票区分（F0：持込、F2：訪問）
            If Not IsDBNull(DtView1(0)("FLD013")) Then ComboBox8.SelectedValue = DtView1(0)("FLD013") Else ComboBox8.Text = Nothing
            '修理伝票番号
            If Not IsDBNull(DtView1(0)("FLD014")) Then Edit5.Text = DtView1(0)("FLD014") Else Edit5.Text = Nothing
            '電話番号
            If Not IsDBNull(DtView1(0)("FLD016")) Then Edit2.Text = Trim(DtView1(0)("FLD016")) Else Edit2.Text = Nothing

            '修理受付日
            If Not IsDBNull(DtView1(0)("FLD021")) Then
                If IsDate(Mid(DtView1(0)("FLD021"), 1, 4), Mid(DtView1(0)("FLD021"), 5, 2), Mid(DtView1(0)("FLD021"), 7, 2)) = True Then
                    Date2.Text = Mid(DtView1(0)("FLD021"), 1, 4) & "/" & Mid(DtView1(0)("FLD021"), 5, 2) & "/" & Mid(DtView1(0)("FLD021"), 7, 2)    '修理受付日
                    Label36.Text = Nothing
                Else
                    Date2.Text = Nothing
                    Label36.Text = Mid(DtView1(0)("FLD021"), 1, 4) & "/" & Mid(DtView1(0)("FLD021"), 5, 2) & "/" & Mid(DtView1(0)("FLD021"), 7, 2)  '修理受付日
                End If
            Else
                Date2.Text = Nothing
                Label36.Text = Nothing
            End If

            '修理完了日
            If Not IsDBNull(DtView1(0)("FLD022")) Then
                If IsDate(Mid(DtView1(0)("FLD022"), 1, 4), Mid(DtView1(0)("FLD022"), 5, 2), Mid(DtView1(0)("FLD022"), 7, 2)) = True Then
                    Date3.Text = Mid(DtView1(0)("FLD022"), 1, 4) & "/" & Mid(DtView1(0)("FLD022"), 5, 2) & "/" & Mid(DtView1(0)("FLD022"), 7, 2)    '修理完了日
                    Label37.Text = Nothing
                Else
                    Date3.Text = Nothing
                    Label37.Text = Mid(DtView1(0)("FLD022"), 1, 4) & "/" & Mid(DtView1(0)("FLD022"), 5, 2) & "/" & Mid(DtView1(0)("FLD022"), 7, 2)    '修理完了日
                End If
            Else
                Date3.Text = Nothing
                Label37.Text = Nothing
            End If

            '出張料
            If Not IsDBNull(DtView1(0)("FLD023")) Then Number6.Value = DtView1(0)("FLD023") Else Number6.Value = 0
            '作業料
            If Not IsDBNull(DtView1(0)("FLD024")) Then Number7.Value = DtView1(0)("FLD024") Else Number7.Value = 0
            '部品計料
            If Not IsDBNull(DtView1(0)("FLD025")) Then Number8.Value = DtView1(0)("FLD025") Else Number8.Value = 0
            '値引き額
            If Not IsDBNull(DtView1(0)("FLD026")) Then Number9.Value = DtView1(0)("FLD026") Else Number9.Value = 0
            '請求除外金額
            If Not IsDBNull(DtView1(0)("FLD027")) Then Number10.Value = DtView1(0)("FLD027") Else Number10.Value = 0
            '請求額
            If Not IsDBNull(DtView1(0)("FLD028")) Then Number11.Value = DtView1(0)("FLD028") Else Number11.Value = 0
            '見積額
            If Not IsDBNull(DtView1(0)("FLD029")) Then Number2.Value = DtView1(0)("FLD029") Else Number2.Value = 0
            '修理番号
            If Not IsDBNull(DtView1(0)("FLD030")) Then Edit3.Text = DtView1(0)("FLD030") Else Edit3.Text = Nothing

            'カコイエラーの場合は、出張料～修理番号まで編集可、ほかは不可。
            If Label35.Text = "ｶｺｲｴﾗｰ" Then
                Number6.Enabled = True
                Number7.Enabled = True
                Number8.Enabled = True
                Number9.Enabled = True
                Number10.Enabled = True
                Number11.Enabled = True
                Number2.Enabled = True
            Else
                Number6.Enabled = False
                Number7.Enabled = False
                Number8.Enabled = False
                Number9.Enabled = False
                Number10.Enabled = False
                Number11.Enabled = False
                Number2.Enabled = False
            End If

            '処理日
            If Not IsDBNull(DtView1(0)("FLD031")) Then
                If IsDate(Mid(DtView1(0)("FLD031"), 1, 4), Mid(DtView1(0)("FLD031"), 5, 2), Mid(DtView1(0)("FLD031"), 7, 2)) = True Then
                    Date4.Text = Mid(DtView1(0)("FLD031"), 1, 4) & "/" & Mid(DtView1(0)("FLD031"), 5, 2) & "/" & Mid(DtView1(0)("FLD031"), 7, 2)    '処理日
                    Label39.Text = Nothing
                Else
                    Date4.Text = Nothing
                    Label39.Text = Mid(DtView1(0)("FLD031"), 1, 4) & "/" & Mid(DtView1(0)("FLD031"), 5, 2) & "/" & Mid(DtView1(0)("FLD031"), 7, 2)    '処理日
                End If
            Else
                Date4.Text = Nothing
                Label39.Text = Nothing
            End If

            '取込処理日
            If Not IsDBNull(DtView1(0)("imp_date")) Then Label58.Text = DtView1(0)("imp_date") Else Label58.Text = Nothing

            '掛種コード
            If Not IsDBNull(DtView1(0)("FLD033")) Then ComboBox12.SelectedValue = DtView1(0)("FLD033") Else ComboBox12.Text = Nothing
        Else
            MsgBox("エラーデータ読み込みエラー")
            Me.Close()
        End If
    End Sub

    'フォーカスアウト時処理 ----------------------------------------------------------------------------

    '保証番号
    Private Sub Edit1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.Leave
        If Trim(Edit1.Text) <> BRK_01 Then
            BRK_01 = Trim(Edit1.Text)
            Call main_set()         '加入情報セット
        End If
    End Sub

    '型式
    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        If Trim(TextBox2.Text) <> BRK_02 Then
            BRK_02 = Trim(TextBox2.Text)
            Call main_set()         '加入情報セット
        End If
    End Sub

    '顧客名
    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If Trim(TextBox1.Text) <> BRK_03 Then
            BRK_03 = Trim(TextBox1.Text)
            Call main_set()         '加入情報セット
        End If
    End Sub

    '事故状況
    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If Trim(ComboBox2.Text) <> BRK_04 Then
            BRK_04 = Trim(ComboBox2.Text)
            Call main_set()         '加入情報セット
        End If
    End Sub

    '事故日
    Private Sub Date1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.Leave
        If Trim(Date1.Text) <> BRK_05 Then
            BRK_05 = Trim(Date1.Text)
            If Date1.Number <> 0 Then
                WK_date = Date1.Text
            Else
                WK_date = "1950/01/01"
            End If
            Call kbn_set()          '期間区分セット
        End If
    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click

    End Sub

    '修理受付日
    Private Sub Date2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.Leave

        If Date2.Number <> 0 Then
            Call kbn_set()          '期間区分セット
        End If

    End Sub

    '各種金額項目
    Private Sub Number6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number6.Leave
        Call sum()
    End Sub

    Private Sub Number7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number7.Leave
        Call sum()
    End Sub

    Private Sub Number8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number8.Leave
        Call sum()
    End Sub

    Private Sub Number9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number9.Leave
        Call sum()
    End Sub

    Private Sub Number10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number10.Leave
        Call sum()
    End Sub

    '請求額算出
    Sub sum()
        Number11.Value = Number6.Value + Number7.Value + Number8.Value - Number9.Value - Number10.Value
    End Sub


    '加入情報セット
    Sub main_set()

        '変数初期化
        WK_msg = Nothing
        Call mtrClr()

        '保証番号と型式よりデータ取得
        If Trim(Edit1.Text) <> Nothing And Trim(TextBox2.Text) <> Nothing Then

            namedif_f = False   '顧客名チェックフラグ初期化

            '保証番号、型式、顧客名（姓）の該当チェック
            Dim Lname As String
            If TextBox1.Text.IndexOf(" ") > 0 Then
                Lname = Mid(TextBox1.Text, 1, TextBox1.Text.IndexOf(" "))   '姓名分割
            Else
                Lname = Trim(TextBox1.Text)
            End If

            WK_DsList1.Clear()

            '新ＤＢよりデータ取得
            strSQL = "SELECT Wrn_mtr.cust_lname, Wrn_sub.*"
            strSQL += ", Wrn_sub_2.wrn_prod2, V_Cat_mtr.GRP, Cat_mtr.GRP AS GRP2"
            strSQL += " FROM V_Cat_mtr RIGHT OUTER JOIN"
            strSQL += " Wrn_mtr INNER JOIN"
            strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no ON V_Cat_mtr.cd12 = Wrn_sub.item_cat_code LEFT OUTER JOIN"
            strSQL += " Wrn_sub_2 LEFT OUTER JOIN"
            strSQL += " Cat_mtr ON Wrn_sub_2.item_cat_code3 = Cat_mtr.cd3 ON Wrn_sub.ordr_no = Wrn_sub_2.ordr_no AND"
            strSQL += " Wrn_sub.line_no = Wrn_sub_2.line_no AND Wrn_sub.seq = Wrn_sub_2.seq AND"
            strSQL += " Wrn_sub.item_cat_code = Cat_mtr.cd12"
            strSQL += " WHERE (Wrn_sub.ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (Wrn_sub.model_name = '" & TextBox2.Text & "')"
            'strSQL += " AND (Wrn_mtr.cust_lname = '" & Lname & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(WK_DsList1, "Wrn_sub")
            DB_CLOSE()

            '取得データよりテーブルWrn_subのデータのみ取得
            DtView2 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            '機種情報データがない場合
            If DtView2.Count = 0 Then
                '旧ＤＢよりデータ取得
                strSQL = "SELECT Wrn_data.*, 'B' AS BY_cls, 0 AS prch_tax"
                strSQL += " FROM Wrn_data"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (model_name = '" & TextBox2.Text & "')"
                'strSQL += " AND (cust_name LIKE '" & Lname & " %')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn_data2")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "Wrn_data")
                DB_CLOSE()
                DtView4 = New DataView(WK_DsList1.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
                If DtView4.Count = 0 Then
                    WK_msg = "該当加入データなし"
                    TextBox1.Focus()
                    Exit Sub
                Else
                    New_Old = "O"   '旧データ
                End If
            Else
                '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 start
                If DtView2(0)("cust_lname") <> Lname Then
                    namedif_f = True
                End If
                '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 end
                New_Old = "N"   '新データ
                End If

                '対象機種の判別
                Dim wk_f As String = "0"
                '新ＤＢデータの場合
                If New_Old = "N" Then
                    '請求の場合
                    If Trim(ComboBox11.SelectedValue) = "1" Then
                        '対象１台の場合
                        If DtView2.Count = 1 Then
                            WK_ordr_no = DtView2(0)("ordr_no")
                            WK_line_no = DtView2(0)("line_no")
                            WK_seq = DtView2(0)("seq")

                            '保証番号重複チェック
                            DsTrbl.Clear()
                            strSQL = "SELECT Wrn_ivc.*"
                            strSQL += " FROM Wrn_ivc"
                            strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                            strSQL += " AND (line_no = '" & WK_line_no & "')"
                            strSQL += " AND (seq = " & WK_seq & ")"
                            strSQL += " AND (close_date = CONVERT(DATETIME, '" & WK_close_date & "', 102))"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("best_wrn")
                            SqlCmd1.CommandTimeout = 600
                            DaList1.Fill(DsTrbl, "Wrn_ivc")
                            DB_CLOSE()
                            DtView3 = New DataView(DsTrbl.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                            If DtView3.Count <> 0 Then
                                WK_msg = "同一締め内に保証番号重複エラー"
                                Edit1.Focus()
                                Err_F = "1"
                                Exit Sub
                            End If

                            '対象複数の場合
                        Else
                            WK_P = -1
                            For i = 0 To DtView2.Count - 1
                                DsTrbl.Clear()
                                '保証番号重複チェック
                                strSQL = "SELECT Wrn_ivc.*"
                                strSQL += " FROM Wrn_ivc"
                                strSQL += " WHERE (ordr_no = '" & DtView2(i)("ordr_no") & "')"
                                strSQL += " AND (line_no = '" & DtView2(i)("line_no") & "')"
                                strSQL += " AND (seq = " & DtView2(i)("seq") & ")"
                                strSQL += " AND (close_date = CONVERT(DATETIME, '" & WK_close_date & "', 102))"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("best_wrn")
                                SqlCmd1.CommandTimeout = 600
                                DaList1.Fill(DsTrbl, "Wrn_ivc")
                                DB_CLOSE()
                                DtView3 = New DataView(DsTrbl.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                                '請求データに重複データなしの場合
                                If DtView3.Count = 0 Then
                                    WK_P = i    'For i = 0 To DtView2.Count - 1
                                    '契約状況がA
                                    If DtView2(i)("cont_flg") = "A" Then
                                        WK_ordr_no = DtView2(i)("ordr_no")
                                        WK_line_no = DtView2(i)("line_no")
                                        WK_seq = DtView2(i)("seq")
                                        wk_f = "1"
                                        Exit For
                                    End If  '契約状況A
                                End If  '重複データなし
                            Next    '該当複数分チェック

                            '加入情報なしの場合
                            If wk_f = "0" Then
                                WK_msg = "同一締め内に保証番号重複エラー"
                                Edit1.Focus()
                                Err_F = "1"
                                Exit Sub
                            End If

                        End If

                        'データ再取得
                        DsWrn.Clear()
                        strSQL = "SELECT Wrn_sub.*, Wrn_mtr.s_flg, Wrn_mtr.b_flg AS b_flg2, Wrn_mtr.entry_date, Wrn_mtr.shop_code"
                        strSQL += ", Wrn_sub_2.wrn_prod2, V_Cat_mtr.GRP, Cat_mtr.GRP AS GRP2"
                    strSQL += " FROM Wrn_mtr INNER JOIN"
                    strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no LEFT OUTER JOIN"
                    strSQL += " Wrn_sub_2 ON Wrn_sub.ordr_no = Wrn_sub_2.ordr_no AND Wrn_sub.line_no = Wrn_sub_2.line_no AND"
                    strSQL += " Wrn_sub.seq = Wrn_sub_2.seq LEFT OUTER JOIN"
                    strSQL += " Cat_mtr ON Wrn_sub_2.item_cat_code3 = Cat_mtr.cd3 AND Wrn_sub.BY_cls = Cat_mtr.BY_cls AND"
                    strSQL += " Wrn_sub.item_cat_code = Cat_mtr.cd12 LEFT OUTER JOIN"
                    strSQL += " V_Cat_mtr ON Wrn_sub.BY_cls = V_Cat_mtr.BY_cls AND Wrn_sub.item_cat_code = V_Cat_mtr.cd12"
                    'strSQL += " FROM V_Cat_mtr RIGHT OUTER JOIN"
                    'strSQL += " Wrn_mtr INNER JOIN"
                    'strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no ON V_Cat_mtr.cd12 = Wrn_sub.item_cat_code LEFT OUTER JOIN"
                    'strSQL += " Wrn_sub_2 LEFT OUTER JOIN"
                    'strSQL += " Cat_mtr ON Wrn_sub_2.item_cat_code3 = Cat_mtr.cd3 ON Wrn_sub.ordr_no = Wrn_sub_2.ordr_no AND"
                    'strSQL += " Wrn_sub.line_no = Wrn_sub_2.line_no AND Wrn_sub.seq = Wrn_sub_2.seq AND"
                    'strSQL += " Wrn_sub.item_cat_code = Cat_mtr.cd12"
                        strSQL += " WHERE (Wrn_sub.ordr_no = '" & WK_ordr_no & "')"
                        strSQL += " AND (Wrn_sub.line_no = '" & WK_line_no & "')"
                        strSQL += " AND (Wrn_sub.seq = " & WK_seq & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("best_wrn")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(DsWrn, "Wrn_sub")
                        DB_CLOSE()
                        DtView1 = New DataView(DsWrn.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
                        '取消の場合
                    Else
                        WK_ordr_no = DtView2(0)("ordr_no")
                        WK_line_no = DtView2(0)("line_no")
                        WK_seq = DtView2(0)("seq")
                    End If

                    '旧ＤＢデータの場合
                Else
                    If Trim(ComboBox11.SelectedValue) = "1" Then
                        WK_seq = 0
                        If DtView4.Count = 1 Then   '対象1台
                            WK_ordr_no = DtView4(0)("ordr_no")
                            WK_line_no = DtView4(0)("line_no")

                            '保証番号重複チェック
                            DsTrbl.Clear()
                            strSQL = "SELECT Wrn_ivc.*"
                            strSQL += " FROM Wrn_ivc"
                            strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                            strSQL += " AND (line_no = '" & WK_line_no & "')"
                            strSQL += " AND (seq = 0)"
                            strSQL += " AND (close_date = CONVERT(DATETIME, '" & WK_close_date & "', 102))"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("best_wrn")
                            SqlCmd1.CommandTimeout = 600
                            DaList1.Fill(DsTrbl, "Wrn_ivc")
                            DB_CLOSE()
                            DtView3 = New DataView(DsTrbl.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                            If DtView3.Count <> 0 Then
                                WK_msg = "同一締め内に保証番号重複エラー"
                                Edit1.Focus()
                                Err_F = "1"
                                Exit Sub
                            End If
                        Else                        '対象複数
                            WK_P = -1
                            For i = 0 To DtView4.Count - 1
                                '保証番号重複チェック
                                DsTrbl.Clear()
                                strSQL = "SELECT Wrn_ivc.*"
                                strSQL += " FROM Wrn_ivc"
                                strSQL += " WHERE (ordr_no = '" & DtView4(i)("ordr_no") & "')"
                                strSQL += " AND (line_no = '" & DtView4(i)("line_no") & "')"
                                strSQL += " AND (seq = 0)"
                                strSQL += " AND (close_date = CONVERT(DATETIME, '" & WK_close_date & "', 102))"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("best_wrn")
                                SqlCmd1.CommandTimeout = 600
                                DaList1.Fill(DsTrbl, "Wrn_ivc")
                                DB_CLOSE()
                                DtView3 = New DataView(DsTrbl.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                                If DtView3.Count = 0 Then
                                    WK_P = i
                                    If DtView4(i)("cont_flg") = "A" Then
                                        WK_ordr_no = DtView4(i)("ordr_no")
                                        WK_line_no = DtView4(i)("line_no")
                                        wk_f = "1"
                                        Exit For
                                    End If
                                End If
                            Next

                            '加入情報なしの場合
                            If wk_f = "0" Then
                                WK_msg = "同一締め内に保証番号重複エラー"
                                Edit1.Focus()
                                Err_F = "1"
                                Exit Sub
                            End If
                        End If

                        '取消の場合
                    Else
                        WK_ordr_no = DtView4(0)("ordr_no")
                        WK_line_no = DtView4(0)("line_no")
                    End If

                    DsWrn.Clear()
                    strSQL = "SELECT wrn_data.*, wrn_data_corp.corp_flg AS corp_flg, '0' AS b_flg2, wrn_data.op_date AS entry_date"
                    strSQL += ", '60' AS wrn_prod, '60' AS wrn_prod2, wrn_data.vend_code AS bend_code"
                    strSQL += ", 'A' AS GRP, 'A' AS GRP2, 'B' AS BY_cls, 0 AS prch_tax"
                    strSQL += " FROM wrn_data LEFT OUTER JOIN"
                    strSQL += " wrn_data_corp ON wrn_data.ordr_no = wrn_data_corp.ordr_no"
                    strSQL += " WHERE (wrn_data.ordr_no = '" & WK_ordr_no & "')"
                    strSQL += " AND (wrn_data.line_no = '" & WK_line_no & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn_data2")
                    DaList1.Fill(DsWrn, "Wrn_data")
                    DB_CLOSE()
                    DtView1 = New DataView(DsWrn.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
                End If

                Call mtrSet()       '加入情報SET
                Call kbn_set()   '期間区分セット

        End If

    End Sub

    '期間区分セット
    'Sub kbn_set(ByVal msg)
    Sub kbn_set()
        WK_msg = Nothing
        WK_kbn_No = Nothing
        Label54.Text = Nothing
        'ComboBox12.Text = Nothing

        If Trim(ComboBox2.Text) <> Nothing _
           And Trim(Date1.Text) <> Nothing _
           And Trim(Label44.Text) <> Nothing Then

            '該当保険会社チェック
            If WK_s_flg = "True" Then
                Label54.Text = "S01"
                WK_kbn_No = "S01"
                If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label54.Text)
                GoTo tab1
            End If

            If WK_b_flg2 = "True" Then
                Label54.Text = "BS1"
                WK_kbn_No = "BS1"
                If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label54.Text)
                GoTo tab1
            End If

            If WK_b_flg = "True" Then
                If Date2.Number <> 0 Then
                    If DateAdd(DateInterval.Year, 3, CDate(Label44.Text)) <= Date2.Text Then
                        Label54.Text = "BS1"
                        WK_kbn_No = "BS1"
                        If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label54.Text)
                        If BR_date2 <> Date2.Text Then
                            BR_date2 = Date2.Text
                            MsgBox("ベスト引受分")
                        End If
                        GoTo tab1
                    End If
                End If
            End If

            '** 臨時処理 2012/08/01
            If Label44.Text >= "2007/11/01" Then                '購入日
                If WK_entry_date <= "2007/10/31" Then           '申込日
                    If WK_GRP = "A" Then                        'Ａ品種
                        If ComboBox2.SelectedValue >= "0" Then  '０：延長修理
                            If Date1.Text >= DateAdd(DateInterval.Year, 3, CDate(Label44.Text)) Then '修理受付日　購入日から３年超
                                Label54.Text = "BS1"
                                WK_kbn_No = "BS1"
                                If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label54.Text)
                                GoTo tab1
                            End If
                        End If
                    End If
                End If
            End If

            '2014/9/24 無料保証の期間区分ＮＧ（BZで誤表示）対応 MOD START
            '            If WK_corp_flg = "0" Then       '個人
            If WK_corp_flg = "0" Or WK_corp_flg = "4" Or WK_corp_flg = "5" Then       '個人(通常 or 無料(4) or　10年無料(5)の場合)
                '2014/9/24 無料保証の期間区分ＮＧ（BZで誤表示）対応 MOD
                DtView2 = New DataView(P_DsList1.Tables("insurance_co_sub"), "start_date <= '" & Label44.Text & "' AND end_date >= '" & Label44.Text & "' AND accident_flg = '" & ComboBox2.SelectedValue & "' AND corp_flg = '0'", "", DataViewRowState.CurrentRows)
            Else                            '法人

                Dim A_YYYY As Integer
                If DateAdd(DateInterval.Year, 1, DtView1(0)("prch_date")) > WK_date Then  '1年以下
                    A_YYYY = 0
                Else
                    If DateAdd(DateInterval.Year, 2, DtView1(0)("prch_date")) > WK_date Then  '2年以下
                        A_YYYY = 1
                    Else
                        If DateAdd(DateInterval.Year, 3, DtView1(0)("prch_date")) > WK_date Then  '3年以下
                            A_YYYY = 2
                        Else
                            If DateAdd(DateInterval.Year, 4, DtView1(0)("prch_date")) > WK_date Then  '4年以下
                                A_YYYY = 3
                            Else
                                If DateAdd(DateInterval.Year, 5, DtView1(0)("prch_date")) > WK_date Then  '5年以下
                                    A_YYYY = 4
                                Else
                                    A_YYYY = 9
                                End If
                            End If
                        End If
                    End If
                End If
                DtView2 = New DataView(P_DsList1.Tables("insurance_co_sub"), "start_date <= '" & Label44.Text & "' AND end_date >= '" & Label44.Text & "' AND accident_flg = '" & ComboBox2.SelectedValue & "' AND corp_flg = '1' AND years_later = " & A_YYYY, "", DataViewRowState.CurrentRows)
            End If
            If DtView2.Count = 0 Then
                WK_msg = "該当する保険会社なし"
                Edit1.Focus()
                ComboBox12.Text = Nothing : ComboBox12.Text = Nothing
                Err_F = "1" : Exit Sub
            Else
                WK_kbn_No = DtView2(0)("kbn_No")
                Label54.Text = WK_kbn_No
                If ComboBox12.Text = Nothing Then ComboBox12.SelectedValue = kakesyu_Get(Label54.Text)
            End If

            '** 臨時処理 2012/08/31
            '2014/9/24 無料保証の期間区分ＮＧ（BZで誤表示）対応 MOD 
            'If WK_corp_flg = "0" Then  '個人
            If WK_corp_flg = "0" Or WK_corp_flg = "4" Or WK_corp_flg = "5" Then
                '2014/9/24 無料保証の期間区分ＮＧ（BZで誤表示）対応 MOD END
                If Trim(ComboBox2.SelectedValue) = "2" Or Trim(ComboBox2.SelectedValue) = "4" Then  '火災・破損
                    Select Case Label54.Text     '期間区分
                        Case Is = "BF1"
                            If WK_entry_date >= "2012/02/01" Then '申込日
                                Label54.Text = Nothing
                                ComboBox12.Text = Nothing : ComboBox12.Text = Nothing
                            End If
                        Case Is = "F04"
                            If Label44.Text >= "2012/02/01" And Label44.Text < "2012/03/01" Then                '購入日
                                If WK_entry_date >= "2012/02/01" Then '申込日
                                    Label54.Text = Nothing
                                    ComboBox12.Text = Nothing : ComboBox12.Text = Nothing
                                End If
                            End If
                    End Select
                End If
            End If

        End If
tab1:
        Call up_line()      '保証限度額セット
    End Sub

    '保証限度額セット
    Sub up_line()
        WK_Limit_money = 0
        Label42.Text = Nothing

        If Trim(ComboBox2.Text) <> Nothing _
           And Trim(WK_kbn_No) <> Nothing Then

            If Trim(ComboBox2.SelectedValue) = "0" Then     '延長保証
                '保証限度額 = 購入価格（税抜） + 消費税
                WK_Limit_money = CInt(Label43.Text) + CInt(Label61.Text)
            Else
                If DateAdd(DateInterval.Year, 1, CDate(Label44.Text)) > WK_date Then  '1年以下
                    WK_Limit_money = CInt(Label43.Text) + CInt(Label61.Text)                                                        '消費税8%対応　2014/04/22
                Else
                    If DateAdd(DateInterval.Year, 2, CDate(Label44.Text)) > WK_date Then   '2年以下
                        WK_Limit_money = Round((CInt(Label43.Text) + CInt(Label61.Text)) * 0.8, 0)                                  '消費税8%対応　2014/04/22
                    Else
                        If DateAdd(DateInterval.Year, 3, CDate(Label44.Text)) > WK_date Then   '3年以下
                            WK_Limit_money = Round((CInt(Label43.Text) + CInt(Label61.Text)) * 0.6, 0)                              '消費税8%対応　2014/04/22
                        Else
                            If DateAdd(DateInterval.Year, 4, CDate(Label44.Text)) > WK_date Then   '4年以下
                                WK_Limit_money = Round((CInt(Label43.Text) + CInt(Label61.Text)) * 0.4, 0)                          '消費税8%対応　2014/04/22
                            Else
                                If DateAdd(DateInterval.Year, 5, CDate(Label44.Text)) > WK_date Then   '5年以下
                                    WK_Limit_money = Round((CInt(Label43.Text) + CInt(Label61.Text)) * 0.2, 0)                      '消費税8%対応　2014/04/22
                                Else
                                    WK_Limit_money = 0
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Label42.Text = Format(WK_Limit_money, "##,##0")
        End If
    End Sub


    '表示データチェック
    Sub DspChk()
        MSG.Text = Nothing
        Err_F = "0"

        '保証番号チェック
        If Trim(Edit1.Text) = Nothing Or Val(Edit1.Text) = 0 Then
            MSG.Text = "保証番号入力エラー"
            Edit1.Focus()
            Err_F = "1" : Exit Sub
        End If

        '顧客名未入力チェック
        If Trim(TextBox1.Text) = Nothing Then
            MSG.Text = "顧客名未入力エラー"
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

        '保証番号該当チェック
        WK_DsList1.Clear()
        strSQL = "SELECT Wrn_mtr.*"
        strSQL += " FROM Wrn_mtr"
        strSQL += " WHERE ordr_no = '" & Edit1.Text & "'"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsList1, "Wrn_mtr")
        DB_CLOSE()
        DtView1 = New DataView(WK_DsList1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "SELECT Wrn_data.*, 0 AS prch_tax"
            strSQL += " FROM Wrn_data"
            strSQL += " WHERE ordr_no = '" & Edit1.Text & "'"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(WK_DsList1, "Wrn_data")
            DB_CLOSE()
            DtView2 = New DataView(WK_DsList1.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
            If DtView2.Count = 0 Then
                MSG.Text = "保証番号該当なし"
                Edit1.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '請求区分チェック
        If Trim(ComboBox11.Text) = Nothing Then
            MSG.Text = "請求区分エラー"
            ComboBox11.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView3 = New DataView(P_DsCMB.Tables("CLS_CODE_007"), "CLS_CODE_NAME='" & ComboBox11.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count <> 0 Then
                ComboBox11.SelectedValue = DtView3(0)("CLS_CODE")
            Else
                MSG.Text = "請求区分エラー"
                ComboBox11.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '請求番号チェック
        If Number1.Value = 0 Then
            MSG.Text = "請求番号エラー"
            Number1.Focus()
            Err_F = "1" : Exit Sub
        End If

        '型式チェック
        If Trim(TextBox2.Text) = Nothing Then
            MSG.Text = "型式エラー"
            TextBox2.Focus()
            Err_F = "1" : Exit Sub
        End If

        '事故状況フラグチェック
        If Trim(ComboBox2.Text) = Nothing Then
            MSG.Text = "事故状況フラグエラー"
            ComboBox2.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView3 = New DataView(P_DsCMB.Tables("CLS_CODE_002"), "CLS_CODE_NAME='" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView3.Count <> 0 Then
                ComboBox2.SelectedValue = DtView3(0)("CLS_CODE")
            Else
                MSG.Text = "事故状況フラグエラー"
                ComboBox2.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '保証番号重複チェック
        DsTrbl.Clear()
        strSQL = "SELECT Wrn_ivc.*"
        strSQL += " FROM Wrn_ivc"
        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
        strSQL += " AND (FLD019 = '" & TextBox2.Text & "')"
        strSQL += " AND (FLD020 = '" & TextBox3.Text & "')"
        strSQL += " AND (close_date = CONVERT(DATETIME, '" & P_close_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsTrbl, "Wrn_ivc")
        DB_CLOSE()
        DtView3 = New DataView(DsTrbl.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If Trim(ComboBox11.SelectedValue) = "1" Then   '請求
            If DtView3.Count <> 0 Then
                MSG.Text = "同一締め内に保証番号重複エラー"
                Edit1.Focus()
                Err_F = "1" : Exit Sub
            End If
        Else                        '取消
            If DtView3.Count = 0 Then
                MSG.Text = "同一締め内に取り消す保証番号なし"
                Edit1.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '保証番号、型式の該当チェック
        WK_DsList1.Clear()
        strSQL = "SELECT Wrn_sub.*"
        strSQL += " FROM Wrn_sub"
        strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
        strSQL += " AND (model_name = '" & TextBox2.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsList1, "Wrn_sub")
        DB_CLOSE()
        DtView3 = New DataView(WK_DsList1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
        If DtView3.Count = 0 Then
            strSQL = "SELECT Wrn_data.*, 0 AS prch_tax"
            strSQL += " FROM Wrn_data"
            strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
            strSQL += " AND (model_name = '" & TextBox2.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(WK_DsList1, "Wrn_data")
            DB_CLOSE()
            DtView4 = New DataView(WK_DsList1.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
            If DtView4.Count = 0 Then
                MSG.Text = "型式の該当なし"
                TextBox2.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        Call main_set() '加入情報セット
        If Err_F = "1" Then MSG.Text = WK_msg : Exit Sub

        '修理品製造番号チェック
        If Trim(ComboBox2.SelectedValue) = "1" Then    '盗難の場合はnullでもOK
        Else
            If Trim(TextBox3.Text) = Nothing Then
                MSG.Text = "修理品製造番号エラー"
                TextBox3.Focus()
                Err_F = "1" : Exit Sub
            Else
                If CheckBox2.Checked = False Then
                    WK_DsList1.Clear()
                    strSQL = "SELECT close_date, seq_sub, FLD020 FROM Wrn_ivc"
                    strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                    strSQL += " AND (line_no = '" & WK_line_no & "')"
                    strSQL += " AND (seq = " & WK_seq & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn")
                    DaList1.Fill(WK_DsList1, "Wrn_ivc")
                    DB_CLOSE()
                    DtView2 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "close_date DESC, seq_sub DESC", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        If Trim(DtView2(0)("FLD020")) <> Trim(TextBox3.Text) Then
                            MSG.Text = "修理品製造番号が前回と不一致"
                            TextBox3.Focus()
                            Err_F = "1" : Exit Sub
                        End If
                    End If
                End If
            End If
        End If

        '事故日チェック
        Data_F05 = "0"
        If Date1.Number = 0 Then
            MSG.Text = "事故日エラー"
            Date1.Focus()
            Err_F = "1" : Exit Sub
            'End If
        Else
            If Date1.Text > Now.Date Then
                MSG.Text = "事故日エラー(未来日付)"
                Date1.Focus()
                Err_F = "1" : Exit Sub
            End If

            'for debug start
            If DtView1.Count > 0 Then
                Debug.WriteLine("cont_flg : " & DtView1(0)("cont_flg"))
                Debug.WriteLine("total_loss_flg : " & DtView1(0)("total_loss_flg"))
                Debug.WriteLine("prch_date : " & DtView1(0)("prch_date"))
            End If
            'for debug end

            'If DtView1(0)("cont_flg") = "C" Then
            If Trim(Label41.Text) = "C" Then
                If Date1.Text > DtView1(0)("cxl_date") Then
                    MSG.Text = "キャンセル日以降の日付エラー（キャンセル日：" & DtView1(0)("cxl_date") & ")"
                    Date1.Focus()
                    Err_F = "1" : Exit Sub
                End If
            End If

        End If

        ''契約状況チェック
        'If DtView1(0)("cont_flg") = "C" Then
        '    MSG.Text = "契約状況=C"
        '    Edit1.Focus()
        '    Err_F = "1" : Exit Sub
        'End If

        '全損チェック
        If Trim(Label49.Text) = "1" Then
            MSG.Text = "全損のため契約満了"
            Edit1.Focus()
            Err_F = "1" : Exit Sub
        End If

        '購入日Null
        If Trim(Label44.Text) = "" Then
            MSG.Text = "加入データの購入日がありません。加入データを修正してください。"
            Err_F = "1" : Exit Sub
        End If

        '保証期間チェック
        WK_nen = Round(WK_wrn_prod / 12, 0)
        If DateAdd(DateInterval.Year, WK_nen, DtView1(0)("prch_date")) <= WK_date Then
            MSG.Text = WK_nen & "年間の保証期限切れ"
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If

        Select Case Trim(ComboBox2.SelectedValue)
            Case Is = "0"   '故障
                If DateAdd(DateInterval.Year, 1, DtView1(0)("prch_date")) > WK_date Then
                    MSG.Text = "故障は2年目から対象"
                    Date1.Focus()
                    Err_F = "1" : Exit Sub
                End If
            Case Is = "4"   '破損
                If DateAdd(DateInterval.Year, 1, DtView1(0)("prch_date")) <= WK_date Then
                    MSG.Text = "破損は1年目のみ対象"
                    Date1.Focus()
                    Err_F = "1" : Exit Sub
                End If
        End Select

        Call kbn_set()   '期間区分セット
        If Err_F = "1" Then MSG.Text = WK_msg : Exit Sub

        '全損フラグチェック
        If Trim(ComboBox4.Text) = Nothing Then
            MSG.Text = "全損フラグエラー"
            ComboBox4.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView2 = New DataView(P_DsCMB.Tables("CLS_CODE_004"), "CLS_CODE_NAME='" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                ComboBox4.SelectedValue = DtView2(0)("CLS_CODE")
            Else
                MSG.Text = "全損フラグエラー"
                ComboBox4.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        ''承認番号チェック
        'If Mid(WK_kbn_No, 1, 1) <> "A" Then
        '    'If Trim(ComboBox2.SelectedValue) = "0" Then   '修理
        '    If Number11.Value > 105000 Then
        '        If Number3.Value = 0 Then
        '            MSG.Text = "承認番号エラー"
        '            Number3.Focus()
        '            Err_F = "1" : Exit Sub
        '        End If
        '    End If
        '    'Else                        '全損
        '    '    If Number11.Value > 52500 Then
        '    '        If Number3.Value = 0 Then
        '    '            MSG.Text = "承認番号エラー"
        '    '            Number3.Focus()
        '    '            Err_F = "1" : Exit Sub
        '    '        End If
        '    '    End If
        '    'End If
        'End If

        '事故場所チェック
        If Trim(ComboBox1.Text) = Nothing And Trim(ComboBox2.SelectedValue) = "0" Then    '延長保証の場合はnullでもOK
        Else
            DtView2 = New DataView(P_DsCMB.Tables("CLS_CODE_001"), "CLS_CODE_NAME='" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                ComboBox1.SelectedValue = DtView2(0)("CLS_CODE")
            Else
                MSG.Text = "事故場所エラー"
                ComboBox1.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '項目有無フラグチェック
        If Trim(ComboBox3.Text) = Nothing Then
            MSG.Text = "項目有無エラー"
            ComboBox3.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView2 = New DataView(P_DsCMB.Tables("CLS_CODE_003"), "CLS_CODE_NAME='" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                ComboBox3.SelectedValue = DtView2(0)("CLS_CODE")
            Else
                MSG.Text = "項目有無エラー"
                ComboBox3.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '修理受付店チェック
        If Trim(ComboBox6.Text) = Nothing Then
            MSG.Text = "修理品受付店コードなし"
            ComboBox6.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView2 = New DataView(DsCMB6.Tables("Shop_mtr"), "店舗名='" & ComboBox6.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                ComboBox6.SelectedValue = DtView2(0)("shop_code")
            Else
                MSG.Text = "修理品受付店コードなし"
                ComboBox6.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '修理完了店チェック
        If Trim(ComboBox7.Text) = Nothing Then
            MSG.Text = "修理完了店コードなし"
            ComboBox7.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView2 = New DataView(DsCMB7.Tables("Shop_mtr"), "店舗名='" & ComboBox7.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                ComboBox7.SelectedValue = DtView2(0)("shop_code")
            Else
                MSG.Text = "修理完了店舗該当なし"
                ComboBox7.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '伝票区分チェック
        If Trim(ComboBox8.Text) = Nothing Then
            MSG.Text = "伝票区分エラー"
            ComboBox8.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView2 = New DataView(P_DsCMB.Tables("CLS_CODE_005"), "CLS_CODE_NAME='" & ComboBox8.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                ComboBox8.SelectedValue = DtView2(0)("CLS_CODE")
            Else
                MSG.Text = "伝票区分エラー"
                ComboBox8.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '修理伝票番号チェック
        Edit5.Text = Trim(Edit5.Text)
        If Edit5.Text = Nothing Then
            MSG.Text = "修理伝票番号エラー"
            Edit5.Focus()
            Err_F = "1" : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT FLD014 FROM Wrn_ivc"
            strSQL += " WHERE (FLD014 = N'" & Format(Edit5.Text, "000000000000") & "' AND (ordr_no = '" & Edit1.Text & "')"
            strSQL += " OR FLD014 = N'" & Edit5.Text & "') AND (ordr_no = '" & Edit1.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            DaList1.Fill(WK_DsList1, "Wrn_ivc")
            DB_CLOSE()
            DtView2 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                MSG.Text = "修理伝票番号重複"
                Edit5.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If
        'If Number4.Value = 0 Then
        '    MSG.Text = "修理伝票番号エラー"
        '    Number4.Focus()
        '    Err_F = "1" : Exit Sub
        'Else
        '    WK_DsList1.Clear()
        '    strSQL = "SELECT FLD014 FROM Wrn_ivc"
        '    strSQL +=  " WHERE (FLD014 = N'" & Format(Number4.Value, "000000000000") & "' AND (ordr_no = '" & Edit1.Text & "')"
        '    strSQL +=  " OR FLD014 = N'" & Number4.Value & "') AND (ordr_no = '" & Edit1.Text & "')"
        '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '    DaList1.SelectCommand = SqlCmd1
        '    DB_OPEN("best_wrn")
        '    DaList1.Fill(WK_DsList1, "Wrn_ivc")
        '    DB_CLOSE()
        '    DtView2 = New DataView(WK_DsList1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        '    If DtView2.Count <> 0 Then
        '        MSG.Text = "修理伝票番号重複"
        '        Number4.Focus()
        '        Err_F = "1" : Exit Sub
        '    End If
        'End If

        '電話番号チェック
        If Trim(Edit2.Text) = Nothing Then
            MSG.Text = "電話番号未入力エラー"
            Edit2.Focus()
            Err_F = "1" : Exit Sub
        End If

        '修理受付日チェック
        If Date2.Number = 0 Then
            MSG.Text = "修理受付日エラー"
            Date2.Focus()
            Err_F = "1" : Exit Sub
        Else
            If Date2.Text > Now.Date Then
                MSG.Text = "修理受付日エラー(未来日付)"
                Date2.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '修理完了日チェック
        If Date3.Number = 0 Then
            MSG.Text = "修理完了日エラー"
            Date3.Focus()
            Err_F = "1" : Exit Sub
        Else
            If Date3.Text > Now.Date Then
                MSG.Text = "修理完了日エラー(未来日付)"
                Date3.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '日付相関チェック
        If Data_F05 = "0" Then
            If Date1.Text > Date2.Text Then
                MSG.Text = "事故日＞修理受付日エラー"
                Date2.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If
        If Data_F05 = "0" Then
            If Date1.Text < DtView1(0)("prch_date") Then
                MSG.Text = "事故日が購入日前エラー"
                Date1.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If
        If Data_F05 = "0" Then
            If Date1.Text > Date3.Text Then
                MSG.Text = "事故日＞修理完了日エラー"
                Date3.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If
        If Date2.Text > Date3.Text Then
            MSG.Text = "修理受付日＞修理完了日エラー"
            Date3.Focus()
            Err_F = "1" : Exit Sub
        End If

        '出張料チェック

        '作業料チェック

        '部品料計チェック

        '値引き額チェック

        '請求除外金額チェック

        '請求額チェック
        If Number11.Value = 0 Then
            MSG.Text = "請求額は入力必須"
            Number11.Focus()
            Err_F = "1" : Exit Sub
        End If

        'If Number11.Value <> Number6.Value + Number7.Value + Number8.Value - Number9.Value - Number10.Value Then
        '    MSG.Text = "請求額計算エラー"
        '    Number11.Focus()
        '    Err_F = "1" : Exit Sub
        'End If

        '修理限度額チェック
        Call up_line()
        If CheckBox1.Checked = False Then
            If WK_Limit_money < Number11.Value Then
                MSG.Text = "修理限度額エラー"
                Number11.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '見積額チェック

        '修理番号チェック
        If Edit3.Text = Nothing Then
            MSG.Text = "修理番号エラー"
            Edit3.Focus()
            Err_F = "1" : Exit Sub
        End If

        '処理日チェック
        If Date4.Number = 0 Then
            MSG.Text = "処理日は入力必須"
            Date4.Focus()
            Err_F = "1" : Exit Sub
        Else
            If Date4.Text > Now.Date Then
                MSG.Text = "処理日エラー(未来日付)"
                Date4.Focus()
                Err_F = "1" : Exit Sub
            Else
                If WK_close_date = Nothing Then
                    P_close_date = Date4.Text
                End If
            End If
        End If

        '掛種コードチェック
        If Trim(ComboBox12.Text) = Nothing Then
            MSG.Text = "掛種コードエラー"
            ComboBox12.Focus()
            Err_F = "1" : Exit Sub
        Else
            'ComboBox12.SelectedValue = DtView2(0)("kakesyu")
            DtView2 = New DataView(P_DsCMB.Tables("kakesyu"), "insurance_code='" & ComboBox12.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then
                WK_DsList1.Clear()
                strSQL = "SELECT kakesyu FROM insurance_co_decision WHERE (kbn_No = '" & Label54.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "insurance_co_decision")
                DB_CLOSE()
                DtView3 = New DataView(WK_DsList1.Tables("insurance_co_decision"), "", "", DataViewRowState.CurrentRows)
                If DtView3.Count <> 0 Then
                    If ComboBox12.SelectedValue <> DtView3(0)("kakesyu") Then
                        MsgBox("掛種コードと期間区分の組合せエラー", MsgBoxStyle.Critical, "Error")
                        ComboBox12.Focus()
                        Err_F = "1" : Exit Sub
                    End If
                End If
            Else
                MSG.Text = "掛種コードエラー"
                ComboBox12.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If
    End Sub


    '初期化処理
    Sub mtrClr()
        Label41.Text = Nothing
        Label42.Text = Nothing
        Label43.Text = Nothing
        Label44.Text = Nothing
        Label49.Text = Nothing
        Label54.Text = Nothing
        'ComboBox12.Text = Nothing
        Label57.Text = Nothing
        WK_s_flg = "False"
        WK_b_flg = "False"
        WK_b_flg2 = "False"
        WK_corp_flg = "0"
        Label9.Text = Nothing
        Label16.Text = Nothing
        Label17.Text = Nothing
    End Sub

    '加入情報表示
    Sub mtrSet()
        Label41.Text = DtView1(0)("cont_flg")   '契約状況
        Label43.Text = Format(DtView1(0)("prch_price"), "##,##0")   '購入価格（税抜）
        Label61.Text = DtView1(0)("prch_tax")                       '消費税     消費税8%対応　2014/04/22
        If Not IsDBNull(DtView1(0)("total_loss_flg")) Then
            Label49.Text = DtView1(0)("total_loss_flg")             '全損フラグ
        End If

        If Not IsDBNull(DtView1(0)("prch_date")) Then
            Label44.Text = DtView1(0)("prch_date")                  '購入日
            Call up_line()
        Else
            Label44.Text = Nothing
        End If
        If Not IsDBNull(DtView1(0)("s_flg")) Then
            WK_s_flg = DtView1(0)("s_flg")
        Else
            WK_s_flg = "False"
        End If
        If Not IsDBNull(DtView1(0)("b_flg2")) Then
            WK_b_flg2 = DtView1(0)("b_flg2")
        Else
            WK_b_flg2 = "False"
        End If
        If Not IsDBNull(DtView1(0)("b_flg")) Then
            WK_b_flg = DtView1(0)("b_flg")
        Else
            WK_b_flg = "False"
        End If
        If Not IsDBNull(DtView1(0)("corp_flg")) Then
            WK_corp_flg = DtView1(0)("corp_flg")
        Else
            WK_corp_flg = "0"
        End If
        Label57.Text = DtView1(0)("item_cat_code")  '品種コード
        Label9.Text = DtView1(0)("BY_cls")          'システム区分
        Label16.Text = DtView1(0)("shop_code")
        Label17.Text = DtView1(0)("bend_code")

        If Not IsDBNull(DtView1(0)("wrn_prod2")) Then
            WK_wrn_prod = DtView1(0)("wrn_prod2")
        Else
            WK_wrn_prod = DtView1(0)("wrn_prod")
        End If
        If Not IsDBNull(DtView1(0)("GRP2")) Then
            WK_GRP = DtView1(0)("GRP2")
        Else
            WK_GRP = DtView1(0)("GRP")
        End If

        WK_entry_date = DtView1(0)("entry_date")
    End Sub

    'データセット初期化
    Sub DsClr()
        DsList1.Clear()
        DsList2.Clear()
        WK_DsList1.Clear()
        DsTrbl.Clear()
        DsWrn.Clear()
    End Sub

    '修正ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call DspChk()

        '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 start
        If Err_F = "0" And namedif_f = True Then
            str_ANS = MsgBox("顧客名称が加入情報と異なります。よろしいですか？", MsgBoxStyle.OKCancel, "確認")
            If str_ANS = DialogResult.Cancel Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                TextBox1.Focus()
                Exit Sub
            End If
        End If
        '2014/11/05 加入情報の顧客名（姓）登録なしデータも登録可に変更 end

        If Err_F = "0" Then

            '請求区分
            If Trim(ComboBox11.SelectedValue) = "1" Then   '請求

                '請求データ
                strSQL = "INSERT INTO Wrn_ivc"
                strSQL += " (ordr_no, line_no, seq, FLD002, FLD004"
                If Data_F05 = "0" Then
                    strSQL += ", FLD005"
                End If
                strSQL += ", FLD006"
                strSQL += ", FLD007, FLD008, FLD009, FLD010, FLD011, FLD012, FLD013"
                strSQL += ", FLD014, FLD015, FLD016, FLD017, FLD018, FLD019, FLD020"
                strSQL += ", FLD021, FLD022, FLD023, FLD024, FLD025, FLD026, FLD027"
                strSQL += ", FLD028, FLD029, FLD030, FLD031, FLD032, FLD033, FLD034"
                strSQL += ", kbn_No, Limit_money, Cancel_flg"
                strSQL += ", close_flg, seq_sub, close_date, Limit_money_off, FLD020_off"
                strSQL += ", BY_cls, entry_flg, buy_BY_cls, ent_BY_cls, fin_BY_cls, pos_code, imp_date)"
                strSQL += " VALUES ('" & WK_ordr_no & "'"
                strSQL += ", '" & WK_line_no & "'"
                strSQL += ", " & WK_seq & ""
                strSQL += ", N'" & Format(Number1.Value, "000000") & "'"
                strSQL += ", N'" & Format(Number3.Value, "0000") & "'"
                If Data_F05 = "0" Then
                    strSQL += ", '" & Date1.Text & "'"
                End If
                strSQL += ", N'" & ComboBox1.SelectedValue & "'"
                strSQL += ", N'" & ComboBox2.SelectedValue & "'"
                strSQL += ", N'" & ComboBox3.SelectedValue & "'"
                strSQL += ", N'" & ComboBox4.SelectedValue & "'"
                strSQL += ", N'" & Label16.Text & "'"
                strSQL += ", N'" & ComboBox6.SelectedValue & "'"
                strSQL += ", N'" & ComboBox7.SelectedValue & "'"
                strSQL += ", '" & ComboBox8.SelectedValue & "'"
                'strSQL +=  ", N'" & Number4.Value & "'"
                strSQL += ", '" & Edit5.Text & "'"
                strSQL += ", '" & TextBox1.Text & "'"
                strSQL += ", '" & Edit2.Text & "'"
                strSQL += ", N'" & Label17.Text & "'"
                strSQL += ", N'" & Label57.Text & "'"
                strSQL += ", '" & TextBox2.Text & "'"
                strSQL += ", '" & TextBox3.Text & "'"
                strSQL += ", '" & Date2.Text & "'"
                strSQL += ", '" & Date3.Text & "'"
                strSQL += ", " & Number6.Value & ""
                strSQL += ", " & Number7.Value & ""
                strSQL += ", " & Number8.Value & ""
                strSQL += ", " & Number9.Value & ""
                strSQL += ", " & Number10.Value & ""
                strSQL += ", " & Number11.Value & ""
                strSQL += ", " & Number2.Value & ""
                strSQL += ", N'" & Edit3.Text & "'"
                strSQL += ", '" & Date4.Text & "'"
                strSQL += ", N'" & ComboBox11.SelectedValue & "'"
                strSQL += ", '" & ComboBox12.SelectedValue & "'"
                strSQL += ", '    '"
                strSQL += ", '" & WK_kbn_No & "'"
                strSQL += ", " & WK_Limit_money & ""
                strSQL += ", '0'"
                strSQL += ", '0'"
                strSQL += ", 1"
                strSQL += ", CONVERT(DATETIME, '" & P_close_date & "', 102)"
                If CheckBox1.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                If CheckBox2.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ", '" & Label9.Text & "'"
                strSQL += ", '00'"
                strSQL += ", '" & Label9.Text & "'"
                strSQL += ", '" & Label60.Text & "'"
                strSQL += ", '" & Label66.Text & "'"
                strSQL += ", ''"
                If Label58.Text <> Nothing Then strSQL += ", '" & Label58.Text & "'" Else strSQL += ", NULL"
                strSQL += ")"

                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                '全損の場合
                If Trim(ComboBox4.SelectedValue) = "1" Then
                    If New_Old = "N" Then
                        strSQL = "UPDATE Wrn_sub"
                        strSQL += " SET total_loss_flg = '1'"
                        strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                        strSQL += " AND (line_no = '" & WK_line_no & "')"
                        strSQL += " AND (seq = " & WK_seq & ")"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "INSERT INTO total_loss"
                        strSQL += " (ordr_no, line_no, seq, total_loss_date)"
                        strSQL += " VALUES ('" & WK_ordr_no & "'"
                        strSQL += ", '" & WK_line_no & "'"
                        strSQL += ", " & WK_seq & ""
                        strSQL += ", '" & Date4.Text & "')"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Else
                        strSQL = "UPDATE Wrn_data"
                        strSQL += " SET total_loss_flg = '1'"
                        strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                        strSQL += " AND (line_no = '" & WK_line_no & "')"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "INSERT INTO total_loss"
                        strSQL += " (ordr_no, line_no, total_loss_date)"
                        strSQL += " VALUES ('" & WK_ordr_no & "'"
                        strSQL += ", '" & WK_line_no & "'"
                        strSQL += ", '" & Date4.Text & "')"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                End If

            Else                    '取消

                '請求データ
                strSQL = "UPDATE Wrn_ivc"
                strSQL += " SET Cancel_flg = '1'"
                strSQL += ", Cancel_date = '" & Date4.Text & "'"
                strSQL += " WHERE (ordr_no = '" & Edit1.Text & "')"
                strSQL += " AND (FLD019 = '" & TextBox2.Text & "')"
                strSQL += " AND (FLD020 = '" & TextBox3.Text & "')"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                '全損の場合
                If Trim(ComboBox4.SelectedValue) = "1" Then
                    If New_Old = "N" Then
                        strSQL = "UPDATE Wrn_sub"
                        strSQL += " SET total_loss_flg = '0'"
                        strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                        strSQL += " AND (line_no = '" & WK_line_no & "')"
                        strSQL += " AND (seq = " & WK_seq & ")"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "DELETE FROM total_loss"
                        strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                        strSQL += " AND (line_no = '" & WK_line_no & "')"
                        strSQL += " AND (seq = " & WK_seq & ")"
                        DB_OPEN("best_wrn")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    Else
                        strSQL = "UPDATE Wrn_data"
                        strSQL += " SET total_loss_flg = '0'"
                        strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                        strSQL += " AND (line_no = '" & WK_line_no & "')"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        strSQL = "DELETE FROM total_loss"
                        strSQL += " WHERE (ordr_no = '" & WK_ordr_no & "')"
                        strSQL += " AND (line_no = '" & WK_line_no & "')"
                        DB_OPEN("best_wrn_data2")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                End If

            End If

            'エラーデータ
            strSQL = "UPDATE Error_data_ivc"
            strSQL += " SET Fixed_flg = '1'"
            strSQL += ", Upd_ordr_no = '" & WK_ordr_no & "'"
            strSQL += ", line_no = '" & WK_line_no & "'"
            strSQL += ", seq = " & WK_seq & ""
            strSQL += ", Fixed_date = CONVERT(DATETIME, '" & Now & "', 102)"
            strSQL += " WHERE (Error_seq = " & CInt(Label34.Text) & ")"
            DB_OPEN("best_wrn")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            P_Rtn = "1"
            Call no_err()
            MsgBox("修正しました", , "")
            Call DsClr()
            Me.Close()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '請求エラーデータテーブルのエラーフラグをＯＦＦ
    Sub no_err()
        WK_DsList1.Clear()
        strSQL = "SELECT FLD031"
        strSQL += " FROM Error_data_ivc"
        strSQL += " WHERE (FLD031 = '" & P_FLD031 & "') AND (Fixed_flg = '0')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsList1, "Error_data_ivc")
        DB_CLOSE()
        DtView1 = New DataView(WK_DsList1.Tables("Error_data_ivc"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            'inp_log
            strSQL = "UPDATE inp_log"
            strSQL += " SET No_Err_F = '1'"
            strSQL += " WHERE (SUBSTRING(A_Data, 4, 6) = '" & Mid(P_FLD031, 3, 6) & "')"
            DB_OPEN("best_wrn")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            P_Rtn = "2"
        End If
    End Sub

    '削除ボタン
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        str_ANS = MsgBox("削除します。よろしいですか？", MsgBoxStyle.OKCancel, "確認")
        If str_ANS = "1" Then   'OK
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'エラーデータ
            strSQL = "UPDATE Error_data_ivc"
            strSQL += " SET Fixed_flg = '1'"
            strSQL += ", Fixed_date = CONVERT(DATETIME, '" & Now & "', 102)"
            strSQL += ", Del_flg = '1'"
            strSQL += " WHERE (Error_seq = " & CInt(Label34.Text) & ")"
            DB_OPEN("best_wrn")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            P_Rtn = "1"
            Call no_err()
            MsgBox("削除しました", , "")
            Call DsClr()
            Me.Close()

            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    '戻るボタン
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_Rtn = "0"
        Call DsClr()
        Me.Close()
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Label60.Text = "B"
        CmbSet6()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Label60.Text = "Y"
        CmbSet6()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Label66.Text = "B"
        CmbSet7()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Label66.Text = "Y"
        CmbSet7()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub MSG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSG.Click

    End Sub
End Class