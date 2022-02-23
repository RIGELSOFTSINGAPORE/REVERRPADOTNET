Public Class F00_Form04
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, Err_F, WK_str, ans As String
    Dim i, r, WK_wrn_prod As Integer
    Dim BR_Edit01, WK_Combo16, WK_Combo17, WK_Combo18, WK_Combo19, WK_Combo21, WK_Combo28 As String

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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Mask09 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Combo28 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Number27 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number26 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number24 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Edit30 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit29 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit23 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit22 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit15 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit14 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit13 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit12 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit11 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit10 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Date31 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date25 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Combo21 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo19 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo18 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo17 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo16 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Edit20 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Date01 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Number01 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Number02 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Combo1 As GrapeCity.Win.Input.Interop.Combo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form04))
        Me.msg = New System.Windows.Forms.Label
        Me.Mask09 = New GrapeCity.Win.Input.Interop.Mask
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Combo28 = New GrapeCity.Win.Input.Interop.Combo
        Me.Number27 = New GrapeCity.Win.Input.Interop.Number
        Me.Number26 = New GrapeCity.Win.Input.Interop.Number
        Me.Number24 = New GrapeCity.Win.Input.Interop.Number
        Me.Edit30 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit29 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit23 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit22 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit15 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit14 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit13 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit12 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit11 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit10 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit08 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Button3 = New System.Windows.Forms.Button
        Me.Date31 = New GrapeCity.Win.Input.Interop.Date
        Me.Date25 = New GrapeCity.Win.Input.Interop.Date
        Me.Button4 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Combo21 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo19 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo18 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo17 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo16 = New GrapeCity.Win.Input.Interop.Combo
        Me.Edit20 = New GrapeCity.Win.Input.Interop.Edit
        Me.Date01 = New GrapeCity.Win.Input.Interop.Date
        Me.Label32 = New System.Windows.Forms.Label
        Me.Number01 = New GrapeCity.Win.Input.Interop.Number
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Number02 = New GrapeCity.Win.Input.Interop.Number
        Me.Label37 = New System.Windows.Forms.Label
        Me.Combo1 = New GrapeCity.Win.Input.Interop.Combo
        CType(Me.Mask09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 524)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(916, 24)
        Me.msg.TabIndex = 1258
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Mask09
        '
        Me.Mask09.Format = New GrapeCity.Win.Input.Interop.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask09.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Mask09.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask09.Location = New System.Drawing.Point(160, 236)
        Me.Mask09.Name = "Mask09"
        Me.Mask09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Mask09.Size = New System.Drawing.Size(100, 24)
        Me.Mask09.TabIndex = 10
        Me.Mask09.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask09.Value = "0900006"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 560)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 28)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(856, 560)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(76, 28)
        Me.Button98.TabIndex = 38
        Me.Button98.Text = "戻る"
        '
        'Combo28
        '
        Me.Combo28.AutoSelect = True
        Me.Combo28.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo28.Location = New System.Drawing.Point(160, 432)
        Me.Combo28.MaxDropDownItems = 30
        Me.Combo28.Name = "Combo28"
        Me.Combo28.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo28.Size = New System.Drawing.Size(280, 24)
        Me.Combo28.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo28.TabIndex = 17
        Me.Combo28.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo28.Value = "Combo28"
        '
        'Number27
        '
        Me.Number27.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "0")
        Me.Number27.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number27.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number27.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number27.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "")
        Me.Number27.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number27.Location = New System.Drawing.Point(608, 404)
        Me.Number27.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number27.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number27.Name = "Number27"
        Me.Number27.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number27.Size = New System.Drawing.Size(120, 24)
        Me.Number27.TabIndex = 32
        Me.Number27.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number27.Value = Nothing
        '
        'Number26
        '
        Me.Number26.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "0")
        Me.Number26.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number26.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number26.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number26.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "")
        Me.Number26.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number26.Location = New System.Drawing.Point(608, 376)
        Me.Number26.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Number26.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number26.Name = "Number26"
        Me.Number26.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number26.Size = New System.Drawing.Size(120, 24)
        Me.Number26.TabIndex = 31
        Me.Number26.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number26.Value = Nothing
        '
        'Number24
        '
        Me.Number24.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number24.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number24.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number24.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number24.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###,###,##0", "", "", "-", "", "", "")
        Me.Number24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number24.Location = New System.Drawing.Point(608, 320)
        Me.Number24.MaxValue = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.Number24.MinValue = New Decimal(New Integer() {1316134911, 2328, 0, -2147483648})
        Me.Number24.Name = "Number24"
        Me.Number24.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number24.Size = New System.Drawing.Size(120, 24)
        Me.Number24.TabIndex = 29
        Me.Number24.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number24.Value = Nothing
        '
        'Edit30
        '
        Me.Edit30.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit30.HighlightText = True
        Me.Edit30.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit30.LengthAsByte = True
        Me.Edit30.Location = New System.Drawing.Point(160, 460)
        Me.Edit30.MaxLength = 60
        Me.Edit30.Name = "Edit30"
        Me.Edit30.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit30.Size = New System.Drawing.Size(328, 24)
        Me.Edit30.TabIndex = 19
        Me.Edit30.Text = "Edit30"
        Me.Edit30.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit29
        '
        Me.Edit29.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit29.HighlightText = True
        Me.Edit29.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit29.LengthAsByte = True
        Me.Edit29.Location = New System.Drawing.Point(816, 452)
        Me.Edit29.MaxLength = 10
        Me.Edit29.Name = "Edit29"
        Me.Edit29.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit29.Size = New System.Drawing.Size(120, 24)
        Me.Edit29.TabIndex = 18
        Me.Edit29.Text = "Edit29"
        Me.Edit29.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Edit29.Visible = False
        '
        'Edit23
        '
        Me.Edit23.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit23.Enabled = False
        Me.Edit23.HighlightText = True
        Me.Edit23.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit23.LengthAsByte = True
        Me.Edit23.Location = New System.Drawing.Point(608, 124)
        Me.Edit23.MaxLength = 30
        Me.Edit23.Name = "Edit23"
        Me.Edit23.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit23.Size = New System.Drawing.Size(332, 24)
        Me.Edit23.TabIndex = 23
        Me.Edit23.Text = "Edit23"
        Me.Edit23.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit22
        '
        Me.Edit22.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit22.Enabled = False
        Me.Edit22.HighlightText = True
        Me.Edit22.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit22.LengthAsByte = True
        Me.Edit22.Location = New System.Drawing.Point(608, 96)
        Me.Edit22.MaxLength = 30
        Me.Edit22.Name = "Edit22"
        Me.Edit22.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit22.Size = New System.Drawing.Size(332, 24)
        Me.Edit22.TabIndex = 22
        Me.Edit22.Text = "123456789012345678901234567890"
        Me.Edit22.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit15
        '
        Me.Edit15.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit15.HighlightText = True
        Me.Edit15.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit15.LengthAsByte = True
        Me.Edit15.Location = New System.Drawing.Point(160, 404)
        Me.Edit15.MaxLength = 40
        Me.Edit15.Name = "Edit15"
        Me.Edit15.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit15.Size = New System.Drawing.Size(328, 24)
        Me.Edit15.TabIndex = 16
        Me.Edit15.Text = "Edit15"
        Me.Edit15.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit14
        '
        Me.Edit14.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit14.HighlightText = True
        Me.Edit14.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit14.LengthAsByte = True
        Me.Edit14.Location = New System.Drawing.Point(160, 376)
        Me.Edit14.MaxLength = 10
        Me.Edit14.Name = "Edit14"
        Me.Edit14.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit14.Size = New System.Drawing.Size(100, 24)
        Me.Edit14.TabIndex = 15
        Me.Edit14.Text = "Edit14"
        Me.Edit14.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit13
        '
        Me.Edit13.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit13.HighlightText = True
        Me.Edit13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit13.LengthAsByte = True
        Me.Edit13.Location = New System.Drawing.Point(160, 348)
        Me.Edit13.MaxLength = 2
        Me.Edit13.Name = "Edit13"
        Me.Edit13.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit13.Size = New System.Drawing.Size(32, 24)
        Me.Edit13.TabIndex = 14
        Me.Edit13.Text = "Ed"
        Me.Edit13.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit12
        '
        Me.Edit12.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit12.HighlightText = True
        Me.Edit12.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit12.LengthAsByte = True
        Me.Edit12.Location = New System.Drawing.Point(160, 320)
        Me.Edit12.MaxLength = 80
        Me.Edit12.Name = "Edit12"
        Me.Edit12.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit12.Size = New System.Drawing.Size(328, 24)
        Me.Edit12.TabIndex = 13
        Me.Edit12.Text = "Edit12"
        Me.Edit12.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit11
        '
        Me.Edit11.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit11.HighlightText = True
        Me.Edit11.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit11.LengthAsByte = True
        Me.Edit11.Location = New System.Drawing.Point(160, 292)
        Me.Edit11.MaxLength = 80
        Me.Edit11.Name = "Edit11"
        Me.Edit11.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit11.Size = New System.Drawing.Size(328, 24)
        Me.Edit11.TabIndex = 12
        Me.Edit11.Text = "Edit11"
        Me.Edit11.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit10
        '
        Me.Edit10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit10.HighlightText = True
        Me.Edit10.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit10.LengthAsByte = True
        Me.Edit10.Location = New System.Drawing.Point(160, 264)
        Me.Edit10.MaxLength = 80
        Me.Edit10.Name = "Edit10"
        Me.Edit10.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit10.Size = New System.Drawing.Size(328, 24)
        Me.Edit10.TabIndex = 11
        Me.Edit10.Text = "Edit10"
        Me.Edit10.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit08
        '
        Me.Edit08.AllowSpace = False
        Me.Edit08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit08.Format = "9"
        Me.Edit08.HighlightText = True
        Me.Edit08.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit08.LengthAsByte = True
        Me.Edit08.Location = New System.Drawing.Point(160, 208)
        Me.Edit08.MaxLength = 11
        Me.Edit08.Name = "Edit08"
        Me.Edit08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit08.Size = New System.Drawing.Size(100, 24)
        Me.Edit08.TabIndex = 9
        Me.Edit08.Text = "08"
        Me.Edit08.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit07
        '
        Me.Edit07.AllowSpace = False
        Me.Edit07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit07.HighlightText = True
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(160, 180)
        Me.Edit07.MaxLength = 40
        Me.Edit07.Name = "Edit07"
        Me.Edit07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit07.Size = New System.Drawing.Size(328, 24)
        Me.Edit07.TabIndex = 8
        Me.Edit07.Text = "Edit07"
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit06
        '
        Me.Edit06.AllowSpace = False
        Me.Edit06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit06.HighlightText = True
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(160, 152)
        Me.Edit06.MaxLength = 40
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(328, 24)
        Me.Edit06.TabIndex = 7
        Me.Edit06.Text = "Edit06"
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit05
        '
        Me.Edit05.AllowSpace = False
        Me.Edit05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit05.Format = "9"
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(160, 124)
        Me.Edit05.MaxLength = 11
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(100, 24)
        Me.Edit05.TabIndex = 6
        Me.Edit05.Text = "12345678901"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.AllowSpace = False
        Me.Edit04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit04.HighlightText = True
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(160, 96)
        Me.Edit04.MaxLength = 40
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(328, 24)
        Me.Edit04.TabIndex = 5
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit03
        '
        Me.Edit03.AllowSpace = False
        Me.Edit03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(160, 68)
        Me.Edit03.MaxLength = 40
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(328, 24)
        Me.Edit03.TabIndex = 4
        Me.Edit03.Text = "1234567890123456789012345678901234567890"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.HighlightText = True
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(160, 36)
        Me.Edit02.MaxLength = 2
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(32, 24)
        Me.Edit02.TabIndex = 1
        Me.Edit02.Text = "12"
        Me.Edit02.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Navy
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(16, 432)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(144, 24)
        Me.Label28.TabIndex = 1253
        Me.Label28.Text = "店舗"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(672, 452)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(144, 24)
        Me.Label29.TabIndex = 1251
        Me.Label29.Text = "受付者社員コード"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label29.Visible = False
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(16, 460)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(144, 24)
        Me.Label30.TabIndex = 1249
        Me.Label30.Text = "受付者名"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Navy
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(16, 488)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(144, 24)
        Me.Label31.TabIndex = 1247
        Me.Label31.Text = "データ入力日"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(496, 264)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 24)
        Me.Label19.TabIndex = 1244
        Me.Label19.Text = "サブクラス"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(496, 68)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 24)
        Me.Label20.TabIndex = 1242
        Me.Label20.Text = "商品コード"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Navy
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(496, 152)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 24)
        Me.Label21.TabIndex = 1241
        Me.Label21.Text = "メーカー"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(496, 96)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 24)
        Me.Label22.TabIndex = 1239
        Me.Label22.Text = "商品名"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Navy
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(496, 124)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 24)
        Me.Label23.TabIndex = 1236
        Me.Label23.Text = "規格"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(496, 320)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 24)
        Me.Label24.TabIndex = 1234
        Me.Label24.Text = "税込本体価格"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(496, 348)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 24)
        Me.Label25.TabIndex = 1231
        Me.Label25.Text = "保証開始日"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(496, 376)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 24)
        Me.Label26.TabIndex = 1230
        Me.Label26.Text = "保証年数"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Navy
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(496, 404)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 24)
        Me.Label27.TabIndex = 1227
        Me.Label27.Text = "税込保証料"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(16, 264)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 24)
        Me.Label10.TabIndex = 1225
        Me.Label10.Text = "住所"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(16, 292)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 24)
        Me.Label11.TabIndex = 1223
        Me.Label11.Text = "丁目"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(16, 320)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 24)
        Me.Label12.TabIndex = 1221
        Me.Label12.Text = "建物名"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 348)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 24)
        Me.Label13.TabIndex = 1220
        Me.Label13.Text = "階上"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 376)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(144, 24)
        Me.Label14.TabIndex = 1217
        Me.Label14.Text = "部屋名"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(16, 404)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 24)
        Me.Label15.TabIndex = 1216
        Me.Label15.Text = "同居先"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Navy
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(496, 180)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 24)
        Me.Label16.TabIndex = 1214
        Me.Label16.Text = "部門"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(496, 208)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 24)
        Me.Label17.TabIndex = 1211
        Me.Label17.Text = "ライン"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Navy
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(496, 236)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 24)
        Me.Label18.TabIndex = 1210
        Me.Label18.Text = "クラス"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(16, 236)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 24)
        Me.Label9.TabIndex = 1208
        Me.Label9.Text = "郵便番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(16, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 24)
        Me.Label8.TabIndex = 1205
        Me.Label8.Text = "お申込者電話番号"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 24)
        Me.Label7.TabIndex = 1203
        Me.Label7.Text = "お申込者（漢字）"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 24)
        Me.Label6.TabIndex = 1202
        Me.Label6.Text = "お申込者（カナ）"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 24)
        Me.Label5.TabIndex = 1200
        Me.Label5.Text = "ご使用者電話番号"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 24)
        Me.Label4.TabIndex = 1197
        Me.Label4.Text = "ご使用者（漢字）"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 24)
        Me.Label3.TabIndex = 1195
        Me.Label3.Text = "ご使用者（カナ）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 24)
        Me.Label2.TabIndex = 1194
        Me.Label2.Text = "行No."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 24)
        Me.Label1.TabIndex = 1192
        Me.Label1.Text = "伝票No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit01
        '
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.HighlightText = True
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(160, 8)
        Me.Edit01.MaxLength = 15
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(132, 24)
        Me.Edit01.TabIndex = 0
        Me.Edit01.Text = "123456789012345"
        Me.Edit01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(252, 560)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 28)
        Me.Button3.TabIndex = 36
        Me.Button3.Text = "クリア"
        '
        'Date31
        '
        Me.Date31.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date31.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date31.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date31.Location = New System.Drawing.Point(160, 488)
        Me.Date31.Name = "Date31"
        Me.Date31.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date31.Size = New System.Drawing.Size(120, 24)
        Me.Date31.TabIndex = 20
        Me.Date31.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date31.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date31.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 4, 17, 20, 19, 0))
        '
        'Date25
        '
        Me.Date25.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date25.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date25.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date25.Location = New System.Drawing.Point(608, 348)
        Me.Date25.Name = "Date25"
        Me.Date25.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date25.Size = New System.Drawing.Size(120, 24)
        Me.Date25.TabIndex = 30
        Me.Date25.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date25.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date25.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 4, 17, 20, 19, 0))
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(492, 560)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(76, 28)
        Me.Button4.TabIndex = 37
        Me.Button4.Text = "取消"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(612, 464)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox1.TabIndex = 34
        Me.CheckBox1.Text = "CheckBox1"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Navy
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(496, 460)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(112, 24)
        Me.Label34.TabIndex = 1268
        Me.Label34.Text = "削除フラグ"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo21
        '
        Me.Combo21.AutoSelect = True
        Me.Combo21.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo21.Location = New System.Drawing.Point(608, 152)
        Me.Combo21.MaxDropDownItems = 30
        Me.Combo21.Name = "Combo21"
        Me.Combo21.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo21.Size = New System.Drawing.Size(248, 24)
        Me.Combo21.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo21.TabIndex = 24
        Me.Combo21.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo21.Value = "Combo21"
        '
        'Combo19
        '
        Me.Combo19.AutoSelect = True
        Me.Combo19.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo19.Location = New System.Drawing.Point(608, 264)
        Me.Combo19.MaxDropDownItems = 30
        Me.Combo19.Name = "Combo19"
        Me.Combo19.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo19.Size = New System.Drawing.Size(248, 24)
        Me.Combo19.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo19.TabIndex = 28
        Me.Combo19.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo19.Value = "Combo19"
        '
        'Combo18
        '
        Me.Combo18.AutoSelect = True
        Me.Combo18.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo18.Location = New System.Drawing.Point(608, 236)
        Me.Combo18.MaxDropDownItems = 30
        Me.Combo18.Name = "Combo18"
        Me.Combo18.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo18.Size = New System.Drawing.Size(248, 24)
        Me.Combo18.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo18.TabIndex = 27
        Me.Combo18.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo18.Value = "Combo18"
        '
        'Combo17
        '
        Me.Combo17.AutoSelect = True
        Me.Combo17.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo17.Location = New System.Drawing.Point(608, 208)
        Me.Combo17.MaxDropDownItems = 30
        Me.Combo17.Name = "Combo17"
        Me.Combo17.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo17.Size = New System.Drawing.Size(248, 24)
        Me.Combo17.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo17.TabIndex = 26
        Me.Combo17.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo17.Value = "Combo17"
        '
        'Combo16
        '
        Me.Combo16.AutoSelect = True
        Me.Combo16.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo16.Location = New System.Drawing.Point(608, 180)
        Me.Combo16.MaxDropDownItems = 30
        Me.Combo16.Name = "Combo16"
        Me.Combo16.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo16.Size = New System.Drawing.Size(248, 24)
        Me.Combo16.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo16.TabIndex = 25
        Me.Combo16.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo16.Value = "Combo16"
        '
        'Edit20
        '
        Me.Edit20.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Edit20.Location = New System.Drawing.Point(608, 68)
        Me.Edit20.Name = "Edit20"
        Me.Edit20.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit20.Size = New System.Drawing.Size(248, 24)
        Me.Edit20.TabIndex = 21
        Me.Edit20.Text = "12345678901234"
        Me.Edit20.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Date01
        '
        Me.Date01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM", "", "")
        Me.Date01.Location = New System.Drawing.Point(608, 8)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(76, 24)
        Me.Date01.TabIndex = 2
        Me.Date01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 4, 17, 20, 19, 0))
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(496, 8)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(112, 24)
        Me.Label32.TabIndex = 1270
        Me.Label32.Text = "計上月"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number01
        '
        Me.Number01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "0")
        Me.Number01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number01.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "")
        Me.Number01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number01.Location = New System.Drawing.Point(608, 36)
        Me.Number01.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01.Name = "Number01"
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(76, 24)
        Me.Number01.TabIndex = 3
        Me.Number01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number01.Value = Nothing
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Navy
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(496, 36)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(112, 24)
        Me.Label33.TabIndex = 1272
        Me.Label33.Text = "SEQ"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(496, 432)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(112, 24)
        Me.Label35.TabIndex = 1274
        Me.Label35.Text = "赤黒フラグ"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(612, 436)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox2.TabIndex = 33
        Me.CheckBox2.Text = "CheckBox2"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Navy
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(496, 292)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(112, 24)
        Me.Label36.TabIndex = 1276
        Me.Label36.Text = "料金表区分"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(648, 560)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 28)
        Me.Button2.TabIndex = 1277
        Me.Button2.Text = "エラーに戻す"
        '
        'Number02
        '
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "0")
        Me.Number02.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number02.Enabled = False
        Me.Number02.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "")
        Me.Number02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number02.Location = New System.Drawing.Point(608, 488)
        Me.Number02.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(76, 24)
        Me.Number02.TabIndex = 1278
        Me.Number02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number02.Value = Nothing
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Navy
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(496, 488)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(112, 24)
        Me.Label37.TabIndex = 1279
        Me.Label37.Text = "TXT_id"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo1
        '
        Me.Combo1.AutoSelect = True
        Me.Combo1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(608, 292)
        Me.Combo1.MaxDropDownItems = 30
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo1.Size = New System.Drawing.Size(120, 24)
        Me.Combo1.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo1.TabIndex = 29
        Me.Combo1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo1.Value = "Combo1"
        '
        'F00_Form04
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(944, 599)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Number02)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Edit20)
        Me.Controls.Add(Me.Combo21)
        Me.Controls.Add(Me.Combo19)
        Me.Controls.Add(Me.Combo18)
        Me.Controls.Add(Me.Combo17)
        Me.Controls.Add(Me.Combo16)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Date25)
        Me.Controls.Add(Me.Date31)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Mask09)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Combo28)
        Me.Controls.Add(Me.Number27)
        Me.Controls.Add(Me.Number26)
        Me.Controls.Add(Me.Number24)
        Me.Controls.Add(Me.Edit30)
        Me.Controls.Add(Me.Edit29)
        Me.Controls.Add(Me.Edit23)
        Me.Controls.Add(Me.Edit22)
        Me.Controls.Add(Me.Edit15)
        Me.Controls.Add(Me.Edit14)
        Me.Controls.Add(Me.Edit13)
        Me.Controls.Add(Me.Edit12)
        Me.Controls.Add(Me.Edit11)
        Me.Controls.Add(Me.Edit10)
        Me.Controls.Add(Me.Edit08)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F00_Form04"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac データ修正"
        CType(Me.Mask09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call clr()
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN = "0"
        msg.Text = Nothing
        DsList1.Clear()
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN()

        '店舗マスタ
        strSQL = "SELECT shop_code, shop_code + ':' + shop_name AS shop_name"
        strSQL = strSQL & " FROM Shop_mtr"
        strSQL = strSQL & " ORDER BY shop_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "Shop_mtr")

        Combo28.DataSource = DsCMB.Tables("Shop_mtr")
        Combo28.DisplayMember = "shop_name"
        Combo28.ValueMember = "shop_code"

        'メーカーマスタ
        strSQL = "SELECT vdr_code, vdr_code + ':' + vdr_name AS vdr_name"
        strSQL = strSQL & " FROM vdr_mtr"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "vdr_mtr")

        Combo21.DataSource = DsCMB.Tables("vdr_mtr")
        Combo21.DisplayMember = "vdr_name"
        Combo21.ValueMember = "vdr_code"

        '部門
        strSQL = "SELECT section_code, section_code + ':' + RTRIM(section_name) AS section_name"
        strSQL = strSQL & " FROM section_mtr"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "section_mtr")

        Combo16.DataSource = DsCMB.Tables("section_mtr")
        Combo16.DisplayMember = "section_name"
        Combo16.ValueMember = "section_code"

        'ライン
        strSQL = "SELECT section_code, line_code, line_code + ':' + line_name AS line_name"
        strSQL = strSQL & " FROM line_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & WK_Combo16 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "line_mtr")

        Combo17.DataSource = DsCMB.Tables("line_mtr")
        Combo17.DisplayMember = "line_name"
        Combo17.ValueMember = "line_code"

        'クラス
        strSQL = "SELECT section_code, line_code, cls_code, cls_code + ':' + cls_name AS cls_name, fee_kbn"
        strSQL = strSQL & " FROM cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & WK_Combo16 & "')"
        strSQL = strSQL & " AND (line_code = '" & WK_Combo17 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "cls_mtr")

        Combo18.DataSource = DsCMB.Tables("cls_mtr")
        Combo18.DisplayMember = "cls_name"
        Combo18.ValueMember = "cls_code"

        'サブクラス
        strSQL = "SELECT section_code, line_code, cls_code, sub_cls_code, sub_cls_code + ':' + sub_cls_name AS sub_cls_name"
        strSQL = strSQL & " FROM sub_cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & WK_Combo16 & "')"
        strSQL = strSQL & " AND (line_code = '" & WK_Combo17 & "')"
        strSQL = strSQL & " AND (cls_code = '" & WK_Combo18 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "sub_cls_mtr")

        Combo19.DataSource = DsCMB.Tables("sub_cls_mtr")
        Combo19.DisplayMember = "sub_cls_name"
        Combo19.ValueMember = "sub_cls_code"

        '料金表区分
        strSQL = "SELECT *"
        strSQL = strSQL & " FROM fee_mtr"
        'strSQL = strSQL & " WHERE (fee_kbn <> 'B')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "fee_mtr")

        Combo1.DataSource = DsCMB.Tables("fee_mtr")
        Combo1.DisplayMember = "fee_kbn"
        Combo1.ValueMember = "fee_kbn"

        DB_CLOSE()
    End Sub
    Sub CmbSet_2()          'ライン

        DsCMB.Tables("line_mtr").Clear()
        strSQL = "SELECT section_code, line_code, line_code + ':' + line_name AS line_name"
        strSQL = strSQL & " FROM line_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & WK_Combo16 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "line_mtr")
        DB_CLOSE()

        WK_Combo18 = Nothing
        Combo18.Text = Nothing
        WK_Combo19 = Nothing
        Combo19.Text = Nothing
    End Sub
    Sub CmbSet_3()          'クラス

        DsCMB.Tables("cls_mtr").Clear()
        strSQL = "SELECT section_code, line_code, cls_code, cls_code + ':' + cls_name AS cls_name, fee_kbn"
        strSQL = strSQL & " FROM cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & WK_Combo16 & "')"
        strSQL = strSQL & " AND (line_code = '" & WK_Combo17 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "cls_mtr")
        DB_CLOSE()

        WK_Combo19 = Nothing
        Combo19.Text = Nothing
    End Sub
    Sub CmbSet_4()          'サブクラス

        DsCMB.Tables("sub_cls_mtr").Clear()
        strSQL = "SELECT section_code, line_code, cls_code, sub_cls_code, sub_cls_code + ':' + sub_cls_name AS sub_cls_name"
        strSQL = strSQL & " FROM sub_cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & WK_Combo16 & "')"
        strSQL = strSQL & " AND (line_code = '" & WK_Combo17 & "')"
        strSQL = strSQL & " AND (cls_code = '" & WK_Combo18 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "sub_cls_mtr")
        DB_CLOSE()

    End Sub

    Sub clr()
        Edit01.Text = Nothing : Edit01.Enabled = True : Edit01.Focus()
        Edit02.Text = Nothing : Edit02.Enabled = True '行No.
        Date01.Number = 0 : Date01.Enabled = True '計上月
        Number01.Value = 0 : Number01.Enabled = True 'SEQ

        Edit03.Text = Nothing : Edit03.Enabled = False 'ご使用者（カナ）
        Edit04.Text = Nothing : Edit04.Enabled = False 'ご使用者（漢字）
        Edit05.Text = Nothing : Edit05.Enabled = False 'ご使用者電話番号
        Edit06.Text = Nothing : Edit06.Enabled = False 'お申込者（カナ）
        Edit07.Text = Nothing : Edit07.Enabled = False 'お申込者（漢字）
        Edit08.Text = Nothing : Edit08.Enabled = False 'お申込者電話番号
        Mask09.Text = Nothing : Mask09.Enabled = False '郵便番号
        Edit10.Text = Nothing : Edit10.Enabled = False '住所
        Edit11.Text = Nothing : Edit11.Enabled = False '丁目
        Edit12.Text = Nothing : Edit12.Enabled = False '建物名
        Edit13.Text = Nothing : Edit13.Enabled = False '階上
        Edit14.Text = Nothing : Edit14.Enabled = False '部屋名
        Edit15.Text = Nothing : Edit15.Enabled = False '同居先
        Combo28.Text = Nothing : Combo28.Enabled = False '店舗
        'Edit29.Text = Nothing : Edit29.Enabled = False '受付者社員コード
        Edit30.Text = Nothing : Edit30.Enabled = False '受付者名
        Date31.Number = 0 : Date31.Enabled = False 'データ入力日
        Edit20.Text = Nothing : Edit20.Enabled = False '商品コード
        Combo21.Text = Nothing : Combo21.Enabled = False 'メーカー
        Edit22.Text = Nothing : Edit22.Enabled = False '商品名
        Edit23.Text = Nothing : Edit23.Enabled = False '規格
        Combo16.Text = Nothing : Combo16.Enabled = False '部門
        Combo17.Text = Nothing : Combo17.Enabled = False 'ライン
        Combo18.Text = Nothing : Combo18.Enabled = False 'クラス
        Combo19.Text = Nothing : Combo19.Enabled = False 'サブクラス
        Combo1.Text = Nothing : Combo1.Enabled = False '料金表区分
        Number24.Value = 0 : Number24.Enabled = False '税込本体価格
        Date25.Number = 0 : Date25.Enabled = False '保証開始日
        Number26.Value = 0 : Number26.Enabled = False '保証年数
        Number27.Value = 0 : Number27.Enabled = False '税込保証料
        CheckBox1.Checked = False : CheckBox1.Enabled = False '削除フラグ
        CheckBox2.Checked = False : CheckBox2.Enabled = False '赤黒フラグ
        Number02.Value = 0                                      'txt_id

        Button1.Enabled = False
        Button4.Enabled = False
        Button2.Enabled = False

    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        Call CHK_Edit01()       '伝票No.
        If msg.Text <> Nothing Then Err_F = "1" : Edit01.Focus() : Exit Sub

        Call CHK_Edit02()       '行No.
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        Call CHK_Edit03()       'ご使用者（カナ）
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        Call CHK_Edit04()       'ご使用者（漢字）
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        Call CHK_Edit05()       'ご使用者電話番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit05.Focus() : Exit Sub

        Call CHK_Edit06()       'お申込者（カナ）
        If msg.Text <> Nothing Then Err_F = "1" : Edit06.Focus() : Exit Sub

        Call CHK_Edit07()       'お申込者（漢字）
        If msg.Text <> Nothing Then Err_F = "1" : Edit07.Focus() : Exit Sub

        Call CHK_Edit08()       'お申込者電話番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit08.Focus() : Exit Sub

        Call CHK_Mask09()       '郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask09.Focus() : Exit Sub

        Call CHK_Combo28()      '店舗コード
        If msg.Text <> Nothing Then Err_F = "1" : Combo28.Focus() : Exit Sub

        Call CHK_Date31()       'データ入力日
        If msg.Text <> Nothing Then Err_F = "1" : Date31.Focus() : Exit Sub

        Call CHK_Edit20()       '商品コード
        If msg.Text <> Nothing Then Err_F = "1" : Edit20.Focus() : Exit Sub

        Call CHK_Edit22()       '商品名
        If msg.Text <> Nothing Then Err_F = "1" : Edit22.Focus() : Exit Sub

        Call CHK_Edit23()       '規格
        If msg.Text <> Nothing Then Err_F = "1" : Edit23.Focus() : Exit Sub

        Call CHK_Combo21()      'メーカー
        If msg.Text <> Nothing Then Err_F = "1" : Combo21.Focus() : Exit Sub

        Call CHK_Combo16()      '部門
        If msg.Text <> Nothing Then Err_F = "1" : Combo16.Focus() : Exit Sub

        Call CHK_Combo17()      'ライン
        If msg.Text <> Nothing Then Err_F = "1" : Combo17.Focus() : Exit Sub

        Call CHK_Combo18()      'クラス
        If msg.Text <> Nothing Then Err_F = "1" : Combo18.Focus() : Exit Sub

        Call CHK_Combo19()      'サブクラス
        If msg.Text <> Nothing Then Err_F = "1" : Combo19.Focus() : Exit Sub

        Call CHK_Combo1()    '料金表区分
        If msg.Text <> Nothing Then Err_F = "1" : Combo1.Focus() : Exit Sub

        Call CHK_Number24()     '税込本体価格
        If msg.Text <> Nothing Then Err_F = "1" : Number24.Focus() : Exit Sub

        Call CHK_Date25()       '保証開始日
        If msg.Text <> Nothing Then Err_F = "1" : Date25.Focus() : Exit Sub

        'Call CHK_Number26()     '保証年数
        'If msg.Text <> Nothing Then Err_F = "1" : Number26.Focus() : Exit Sub

        Call CHK_Number27()     '税込保証料
        If msg.Text <> Nothing Then Err_F = "1" : Number27.Focus() : Exit Sub

    End Sub
    Sub CHK_Edit01()    '伝票No.
        msg.Text = Nothing

        Edit01.Text = Trim(Edit01.Text)
        If BR_Edit01 <> Edit01.Text Then
            BR_Edit01 = Edit01.Text

            If Edit01.Text = Nothing Then
                Edit01.BackColor = System.Drawing.Color.Red
                msg.Text = "伝票No. 未入力エラー"
                Exit Sub
            Else
                If LenB(Edit01.Text) <> 15 Then
                    Edit01.BackColor = System.Drawing.Color.Red
                    msg.Text = "伝票No. 15桁以外エラー"
                    Exit Sub
                End If
            End If
        End If

        Edit01.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit02()    '行No.
        msg.Text = Nothing

        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            Edit02.BackColor = System.Drawing.Color.Red
            msg.Text = "行No. 未入力エラー"
            Exit Sub
        Else
            If numeric_check(Edit02.Text) = "NG" Then
                Edit02.BackColor = System.Drawing.Color.Red
                msg.Text = "行No. 数値以外エラー"
                Exit Sub
            Else
                WK_str = Edit02.Text
                Edit02.Text = WK_str.PadLeft(2, "0")
            End If
        End If

        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit03()    'ご使用者（カナ）
        msg.Text = Nothing

        Edit03.Text = Trim(Edit03.Text)
        If Edit03.Text = Nothing Then
            Edit03.BackColor = System.Drawing.Color.Red
            msg.Text = "ご使用者（カナ） 未入力エラー"
            Exit Sub
        End If
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit04()    'ご使用者（漢字）
        msg.Text = Nothing

        Edit04.Text = Trim(Edit04.Text)
        If Edit04.Text = Nothing Then
            Edit04.BackColor = System.Drawing.Color.Red
            msg.Text = "ご使用者（漢字） 未入力エラー"
            Exit Sub
        End If
        Edit04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit05()    'ご使用者電話番号
        msg.Text = Nothing

        Edit05.Text = Trim(Edit05.Text)
        If Edit05.Text = Nothing Then
            Edit05.BackColor = System.Drawing.Color.Red
            msg.Text = "ご使用者電話番号 未入力エラー"
            Exit Sub
        End If
        Edit05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit06()    'お申込者（カナ）
        msg.Text = Nothing

        Edit06.Text = Trim(Edit06.Text)
        'If Edit06.Text = Nothing Then
        '    Edit06.BackColor = System.Drawing.Color.Red
        '    msg.Text = "お申込者（カナ） 未入力エラー"
        '    Exit Sub
        'End If
        Edit06.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit07()    'お申込者（漢字）
        msg.Text = Nothing

        Edit07.Text = Trim(Edit07.Text)
        'If Edit07.Text = Nothing Then
        '    Edit07.BackColor = System.Drawing.Color.Red
        '    msg.Text = "お申込者（漢字） 未入力エラー"
        '    Exit Sub
        'End If
        Edit07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit08()    'お申込者電話番号
        msg.Text = Nothing

        Edit08.Text = Trim(Edit08.Text)
        'If Edit08.Text = Nothing Then
        '    Edit08.BackColor = System.Drawing.Color.Red
        '    msg.Text = "お申込者電話番号 未入力エラー"
        '    Exit Sub
        'End If
        Edit08.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Mask09()     '郵便番号
        msg.Text = Nothing

        If Mask09.Value = Nothing Then
        Else
            If LenB(Mask09.Value) <> 7 Then
                Mask09.BackColor = System.Drawing.Color.Red
                msg.Text = "郵便番号は7桁入力してください。"
                Exit Sub
            End If
        End If
        Mask09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo28()    '店舗コード
        msg.Text = Nothing

        Combo28.Text = Trim(Combo28.Text)
        If Combo28.Text = Nothing Then
            Combo28.BackColor = System.Drawing.Color.Red
            msg.Text = "店舗コード 未入力エラー"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("Shop_mtr"), "shop_name = '" & Combo28.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo28.BackColor = System.Drawing.Color.Red
                msg.Text = "店舗コード 該当なし"
                Exit Sub
            Else
                WK_Combo28 = WK_DtView1(0)("shop_code")
            End If
        End If
        Combo28.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date31()    'データ入力日
        msg.Text = Nothing

        If Date31.Number = 0 Then
            Date31.BackColor = System.Drawing.Color.Red
            msg.Text = "データ入力日 未入力エラー"
            Exit Sub
        Else
            If Date31.Text < "1753/01/01" Or Date31.Text > "2079/06/06" Then
                Date31.BackColor = System.Drawing.Color.Red
                msg.Text = "データ入力日 範囲エラー"
                Exit Sub
            End If
        End If
        Date31.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit20()    '商品コード
        msg.Text = Nothing

        Edit20.Text = Trim(Edit20.Text)
        'If Edit20.Text = Nothing Then
        '    Edit20.BackColor = System.Drawing.Color.Red
        '    msg.Text = "商品コード 未入力エラー"
        '    Exit Sub
        'End If
        Edit20.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit22()    '商品名
        msg.Text = Nothing

        Edit22.Text = Trim(Edit22.Text)
        If Edit22.Text = Nothing Then
            Edit22.BackColor = System.Drawing.Color.Red
            msg.Text = "商品名 未入力エラー"
            Exit Sub
        End If
        Edit22.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit23()    '規格
        msg.Text = Nothing

        Edit23.Text = Trim(Edit23.Text)
        If Edit23.Text = Nothing Then
            Edit23.BackColor = System.Drawing.Color.Red
            msg.Text = "規格 未入力エラー"
            Exit Sub
        End If
        Edit23.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo21()    'メーカー
        msg.Text = Nothing

        Combo21.Text = Trim(Combo21.Text)
        If Combo21.Text = Nothing Then
            'Combo21.BackColor = System.Drawing.Color.Red
            'msg.Text = "メーカー 未入力エラー"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("vdr_mtr"), "vdr_name = '" & Combo21.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                'Combo21.BackColor = System.Drawing.Color.Red
                'msg.Text = "メーカー 該当なし"
                Exit Sub
            Else
                WK_Combo21 = WK_DtView1(0)("vdr_code")
            End If
        End If
        Combo21.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo16()    '部門
        msg.Text = Nothing

        Combo16.Text = Trim(Combo16.Text)
        If Combo16.Text = Nothing Then
            'Combo16.BackColor = System.Drawing.Color.Red
            'msg.Text = "部門 未入力エラー"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("section_mtr"), "section_name = '" & Combo16.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                'Combo16.BackColor = System.Drawing.Color.Red
                'msg.Text = "部門 該当なし"
                Exit Sub
            Else
                If WK_Combo16 <> WK_DtView1(0)("section_code") Then
                    WK_Combo16 = WK_DtView1(0)("section_code")
                    WK_Combo17 = Nothing
                    Combo17.Text = Nothing
                    Call CmbSet_2()
                    WK_Combo17 = Nothing
                End If
            End If
        End If
        Combo16.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo17()    'ライン
        msg.Text = Nothing

        Combo17.Text = Trim(Combo17.Text)
        If Combo17.Text = Nothing Then
            'Combo17.BackColor = System.Drawing.Color.Red
            'msg.Text = "ライン 未入力エラー"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("line_mtr"), "section_code = '" & WK_Combo16 & "' AND line_name = '" & Combo17.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                'Combo17.BackColor = System.Drawing.Color.Red
                'msg.Text = "ライン 該当なし"
                Exit Sub
            Else
                If WK_Combo17 <> WK_DtView1(0)("line_code") Then
                    WK_Combo17 = WK_DtView1(0)("line_code")
                    Call CmbSet_3()
                    WK_Combo18 = Nothing
                End If
            End If
        End If
        Combo17.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo18()    'クラス
        msg.Text = Nothing

        Combo18.Text = Trim(Combo18.Text)
        If Combo18.Text = Nothing Then
            'Combo18.BackColor = System.Drawing.Color.Red
            'msg.Text = "クラス 未入力エラー"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("cls_mtr"), "section_code = '" & WK_Combo16 & "' AND line_code = '" & WK_Combo17 & "' AND cls_name = '" & Combo18.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                'Combo18.BackColor = System.Drawing.Color.Red
                'msg.Text = "クラス 該当なし"
                Exit Sub
            Else
                If WK_Combo18 <> WK_DtView1(0)("cls_code") Then
                    WK_Combo18 = WK_DtView1(0)("cls_code")
                    Call CmbSet_4()
                End If
                'If Not IsDBNull(WK_DtView1(0)("fee_kbn")) Then Combo1.Text = WK_DtView1(0)("fee_kbn") : Combo1.BackColor = System.Drawing.SystemColors.Window
            End If
        End If
        Combo18.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo19()    'サブクラス
        msg.Text = Nothing

        Combo19.Text = Trim(Combo19.Text)
        If Combo19.Text = Nothing Then
            'Combo19.BackColor = System.Drawing.Color.Red
            'msg.Text = "サブクラス 未入力エラー"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("sub_cls_mtr"), "section_code = '" & WK_Combo16 & "' AND line_code = '" & WK_Combo17 & "' AND cls_code = '" & WK_Combo18 & "' AND sub_cls_name = '" & Combo19.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                'Combo19.BackColor = System.Drawing.Color.Red
                'msg.Text = "サブクラス 該当なし"
                Exit Sub
            Else
                WK_Combo19 = WK_DtView1(0)("sub_cls_code")
            End If
        End If
        Combo19.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Number24()  '税込本体価格
        msg.Text = Nothing

        If Number24.Value = 0 Then
            Number24.BackColor = System.Drawing.Color.Red
            msg.Text = "税込本体価格 未入力エラー"
            Exit Sub
        End If
        Number24.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date25()  '保証開始日
        msg.Text = Nothing

        If Date25.Number = 0 Then
            Date25.BackColor = System.Drawing.Color.Red
            msg.Text = "保証開始日 未入力エラー"
            Exit Sub
        Else
            If Date25.Text < "1753/01/01" Or Date25.Text > "2079/06/06" Then
                Date25.BackColor = System.Drawing.Color.Red
                msg.Text = "保証開始日 範囲エラー"
                Exit Sub
            End If
        End If
        Date25.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Number26()  '保証年数
        msg.Text = Nothing

        If Number26.Value = 0 Then
            Number26.BackColor = System.Drawing.Color.Red
            msg.Text = "保証年数 未入力エラー"
            Exit Sub
            'Else
            '    If WK_wrn_prod <> Number26.Value Then
            '        Number26.BackColor = System.Drawing.Color.Red
            '        msg.Text = "保証年数 料金表区分の年数と不一致"
            '        Exit Sub
            '    End If
        End If
        Number26.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Number27()  '税込保証料
        msg.Text = Nothing

        If Number27.Value = 0 Then
            Number27.BackColor = System.Drawing.Color.Red
            msg.Text = "税込保証料 未入力エラー"
            Exit Sub
        End If
        Number27.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo1()     '料金表区分
        msg.Text = Nothing
        WK_wrn_prod = 0

        Combo1.Text = Trim(Combo1.Text)
        If Combo1.Text = Nothing Then
            Combo1.BackColor = System.Drawing.Color.Red
            msg.Text = "料金表区分が選択されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("fee_mtr"), "fee_kbn = '" & Combo1.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo1.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する料金表区分がありません。"
                Err_F = "1" : Exit Sub
            Else
                WK_wrn_prod = WK_DtView1(0)("wrn_prod")
            End If
        End If
        Combo1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        Call CHK_Edit01()    '伝票No.
        If msg.Text = Nothing Then
            Call scan()
        End If
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CHK_Edit02()    '行No.
        If msg.Text = Nothing Then
            Call scan()
        End If
    End Sub
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        Call scan()
    End Sub
    Private Sub Number01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.LostFocus
        Call scan()
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CHK_Edit03()       'ご使用者（カナ）
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Call CHK_Edit04()       'ご使用者（漢字）
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Call CHK_Edit05()       'ご使用者電話番号
    End Sub
    Private Sub Edit06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.LostFocus
        Call CHK_Edit06()       'お申込者（カナ）
    End Sub
    Private Sub Edit07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit07.LostFocus
        Call CHK_Edit07()       'お申込者（漢字）
    End Sub
    Private Sub Edit08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit08.LostFocus
        Call CHK_Edit08()       'お申込者電話番号
    End Sub
    Private Sub Mask09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask09.LostFocus
        Call CHK_Mask09()       '郵便番号
    End Sub
    Private Sub Combo28_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo28.LostFocus
        Call CHK_Combo28()      '店舗コード
    End Sub
    Private Sub Date31_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date31.LostFocus
        Call CHK_Date31()       'データ入力日
    End Sub
    Private Sub Edit20_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit20.LostFocus
        Call CHK_Edit20()       '商品コード
    End Sub
    Private Sub Edit22_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit22.LostFocus
        Call CHK_Edit22()       '商品名
    End Sub
    Private Sub Edit23_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit23.LostFocus
        Call CHK_Edit23()       '規格
    End Sub
    Private Sub Combo21_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo21.LostFocus
        Call CHK_Combo21()      'メーカー
    End Sub
    Private Sub Combo16_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo16.LostFocus
        Call CHK_Combo16()      '部門
    End Sub
    Private Sub Combo17_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo17.LostFocus
        Call CHK_Combo17()      'ライン
    End Sub
    Private Sub Combo18_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo18.LostFocus
        Call CHK_Combo18()      'クラス
    End Sub
    Private Sub Combo19_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo19.LostFocus
        Call CHK_Combo19()      'サブクラス
    End Sub
    Private Sub Number24_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number24.LostFocus
        Call CHK_Number24()     '税込本体価格
    End Sub
    Private Sub Date25_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date25.LostFocus
        Call CHK_Date25()       '保証開始日
    End Sub
    Private Sub Number26_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number26.LostFocus
        Call CHK_Number26()     '保証年数
    End Sub
    Private Sub Number27_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number27.LostFocus
        Call CHK_Number27()     '税込保証料
    End Sub
    Private Sub Combo1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo1.LostFocus
        Call CHK_Combo1()    '料金表区分
    End Sub

    Sub scan()

        WK_DsList1.Clear()
        strSQL = "SELECT WRN_MAIN.*, WRN_SUB.*, Shop_mtr.shop_name, vdr_mtr.vdr_name, section_mtr.section_name"
        strSQL = strSQL & ", line_mtr.line_name, cls_mtr.cls_name, sub_cls_mtr.sub_cls_name"
        strSQL = strSQL & " FROM WRN_MAIN INNER JOIN"
        strSQL = strSQL & " WRN_SUB ON WRN_MAIN.wrn_no = WRN_SUB.wrn_no LEFT OUTER JOIN"
        strSQL = strSQL & " sub_cls_mtr ON WRN_SUB.sub_cls_code = sub_cls_mtr.sub_cls_code AND"
        strSQL = strSQL & " WRN_SUB.cls_code = sub_cls_mtr.cls_code AND WRN_SUB.line_code = sub_cls_mtr.line_code AND"
        strSQL = strSQL & " WRN_SUB.section_code = sub_cls_mtr.section_code LEFT OUTER JOIN"
        strSQL = strSQL & " cls_mtr ON WRN_SUB.cls_code = cls_mtr.cls_code AND WRN_SUB.line_code = cls_mtr.line_code AND"
        strSQL = strSQL & " WRN_SUB.section_code = cls_mtr.section_code LEFT OUTER JOIN"
        strSQL = strSQL & " Shop_mtr ON WRN_MAIN.shop_code = Shop_mtr.shop_code LEFT OUTER JOIN"
        strSQL = strSQL & " vdr_mtr ON WRN_SUB.vdr_code = vdr_mtr.vdr_code LEFT OUTER JOIN"
        strSQL = strSQL & " section_mtr ON WRN_SUB.section_code = section_mtr.section_code LEFT OUTER JOIN"
        strSQL = strSQL & " line_mtr ON WRN_SUB.section_code = line_mtr.section_code AND WRN_SUB.line_code = line_mtr.line_code"
        strSQL = strSQL & " WHERE (WRN_MAIN.wrn_no = '" & Edit01.Text & "')"
        If Edit02.Text <> Nothing Then
            strSQL = strSQL & " AND (WRN_SUB.line_no = '" & Edit02.Text & "')"
        End If
        If Date01.Number <> 0 Then
            strSQL = strSQL & " AND (WRN_SUB.close_date = '" & Date01.Text & "/01')"
        End If
        If Number01.Value <> 0 Then
            strSQL = strSQL & " AND (WRN_SUB.seq = " & Number01.Value & ")"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(WK_DsList1, "WRN_MAIN")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                Edit01.BackColor = System.Drawing.Color.Red
                If Edit02.Text <> Nothing Then Edit02.BackColor = System.Drawing.Color.Red
                msg.Text = "該当なし"
            Case Is = 1
                Button1.Enabled = True
                Button4.Enabled = True
                Button2.Enabled = True
                DtView1 = New DataView(WK_DsList1.Tables("WRN_MAIN"), "", "", DataViewRowState.CurrentRows)
                Edit01.Enabled = False
                Edit02.Text = DtView1(0)("line_no") : Edit02.Enabled = False '行No.
                Date01.Text = Format(DtView1(0)("close_date"), "yyyy/MM") : Date01.Enabled = False '計上月
                Number01.Value = DtView1(0)("seq") : Number01.Enabled = False '税込本体価格

                Edit03.Focus()
                Edit03.Text = DtView1(0)("user_name_KANA") : Edit03.Enabled = True 'ご使用者（カナ）
                Edit04.Text = DtView1(0)("user_name") : Edit04.Enabled = True 'ご使用者（漢字）
                Edit05.Text = DtView1(0)("user_tel_no") : Edit05.Enabled = True 'ご使用者電話番号
                Edit06.Text = DtView1(0)("appl_name_KANA") : Edit06.Enabled = True 'お申込者（カナ）
                Edit07.Text = DtView1(0)("appl_name") : Edit07.Enabled = True 'お申込者（漢字）
                Edit08.Text = DtView1(0)("appl_tel_no") : Edit08.Enabled = True 'お申込者電話番号
                Mask09.Value = DtView1(0)("zip") : Mask09.Enabled = True '郵便番号
                Edit10.Text = DtView1(0)("adrs1") : Edit10.Enabled = True '住所
                Edit11.Text = DtView1(0)("adrs2") : Edit11.Enabled = True '丁目
                Edit12.Text = DtView1(0)("adrs3") : Edit12.Enabled = True '建物名
                Edit13.Text = DtView1(0)("floor") : Edit13.Enabled = True '階上
                Edit14.Text = DtView1(0)("room_name") : Edit14.Enabled = True '部屋名
                Edit15.Text = DtView1(0)("livi_togr") : Edit15.Enabled = True '同居先

                If Not IsDBNull(DtView1(0)("shop_name")) Then
                    Combo28.Text = DtView1(0)("shop_code") & ":" & DtView1(0)("shop_name") '店舗
                Else
                    Combo28.Text = DtView1(0)("shop_code")
                End If
                WK_Combo28 = DtView1(0)("shop_code") : Combo28.Enabled = True

                'Edit29.Text = DtView1(0)("rcpt_empl_code") : Edit29.Enabled = True '受付者社員コード
                Edit30.Text = DtView1(0)("rcpt_empl_name") : Edit30.Enabled = True '受付者名
                Date31.Text = DtView1(0)("input_date") : Date31.Enabled = True 'データ入力日

                Edit20.Text = DtView1(0)("item_code") : Edit20.Enabled = True '商品コード
                Edit22.Text = DtView1(0)("item_name") : Edit22.Enabled = True '商品名
                Edit23.Text = DtView1(0)("standard_name") : Edit23.Enabled = True '規格

                If Not IsDBNull(DtView1(0)("vdr_name")) Then
                    Combo21.Text = DtView1(0)("vdr_code") & ":" & DtView1(0)("vdr_name") 'メーカー
                Else
                    Combo21.Text = DtView1(0)("vdr_code")
                End If
                WK_Combo21 = DtView1(0)("section_code") : Combo21.Enabled = True

                If Not IsDBNull(DtView1(0)("section_name")) Then
                    Combo16.Text = DtView1(0)("section_code") & ":" & DtView1(0)("section_name") '部門
                Else
                    Combo16.Text = DtView1(0)("section_code")
                End If
                WK_Combo16 = DtView1(0)("section_code") : Combo16.Enabled = True

                Call CmbSet_2()                         'ライン
                If Not IsDBNull(DtView1(0)("line_name")) Then
                    Combo17.Text = DtView1(0)("line_code") & ":" & DtView1(0)("line_name") 'ライン
                Else
                    Combo17.Text = DtView1(0)("line_code")
                End If
                WK_Combo17 = DtView1(0)("line_code") : Combo17.Enabled = True

                Call CmbSet_3()                         'クラス
                'Combo1.Text = Nothing
                If Not IsDBNull(DtView1(0)("cls_name")) Then
                    Combo18.Text = DtView1(0)("cls_code") & ":" & DtView1(0)("cls_name") 'クラス
                Else
                    Combo18.Text = DtView1(0)("cls_code")
                End If
                'If Not IsDBNull(DtView1(0)("fee_kbn")) Then Combo1.Text = DtView1(0)("fee_kbn")
                Combo1.Enabled = True
                WK_Combo18 = DtView1(0)("cls_code") : Combo18.Enabled = True

                Call CmbSet_4()                         'サブクラス
                If Not IsDBNull(DtView1(0)("sub_cls_name")) Then
                    Combo19.Text = DtView1(0)("sub_cls_code") & ":" & DtView1(0)("sub_cls_name") 'サブクラス
                Else
                    Combo19.Text = DtView1(0)("sub_cls_code")
                End If
                WK_Combo19 = DtView1(0)("sub_cls_code") : Combo19.Enabled = True

                If Not IsDBNull(DtView1(0)("fee_kbn")) Then
                    Combo1.Text = DtView1(0)("fee_kbn") '料金表区分
                Else
                    Combo1.Text = Nothing
                End If

                Number24.Value = DtView1(0)("prch_price") : Number24.Enabled = True '税込本体価格
                Date25.Text = DtView1(0)("wrn_date") : Date25.Enabled = True '保証開始日
                Number26.Value = DtView1(0)("wrn_prod") : Number26.Enabled = True '保証年数
                Number27.Value = DtView1(0)("wrn_fee") : Number27.Enabled = True '税込保証料
                If DtView1(0)("dlt_f") = "True" Then
                    CheckBox1.Checked = True                                    '削除フラグ
                Else
                    CheckBox1.Checked = False
                End If
                CheckBox1.Enabled = True
                If DtView1(0)("aka_kuro") = "True" Then
                    CheckBox2.Checked = True                                    '赤黒フラグ
                Else
                    CheckBox2.Checked = False
                End If
                CheckBox2.Enabled = True
                If Not IsDBNull(DtView1(0)("txt_all_id")) Then Number02.Value = DtView1(0)("txt_all_id")

            Case Else

                'Edit02.BackColor = System.Drawing.Color.Red
                'msg.Text = "行No. 未入力エラー"
        End Select
    End Sub

    '******************************************************************
    '** 更新
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then
            DB_OPEN()

            strSQL = "UPDATE WRN_MAIN"
            strSQL = strSQL & " SET user_name_KANA = '" & Edit03.Text & "'"
            strSQL = strSQL & ", user_name = '" & Edit04.Text & "'"
            strSQL = strSQL & ", user_tel_no = '" & Edit05.Text & "'"
            strSQL = strSQL & ", appl_name_KANA = '" & Edit06.Text & "'"
            strSQL = strSQL & ", appl_name = '" & Edit07.Text & "'"
            strSQL = strSQL & ", appl_tel_no = '" & Edit08.Text & "'"
            strSQL = strSQL & ", zip = '" & Mask09.Value & "'"
            strSQL = strSQL & ", adrs1 = '" & Edit10.Text & "'"
            strSQL = strSQL & ", adrs2 = '" & Edit11.Text & "'"
            strSQL = strSQL & ", adrs3 = '" & Edit12.Text & "'"
            strSQL = strSQL & ", floor = '" & Edit13.Text & "'"
            strSQL = strSQL & ", room_name = '" & Edit14.Text & "'"
            strSQL = strSQL & ", livi_togr = '" & Edit15.Text & "'"
            strSQL = strSQL & ", shop_code = '" & WK_Combo28 & "'"
            'strSQL = strSQL & ", rcpt_empl_code = '" & Edit29.Text & "'"
            strSQL = strSQL & ", rcpt_empl_name = '" & Edit30.Text & "'"
            strSQL = strSQL & ", input_date = CONVERT(DATETIME, '" & Date31.Text & "', 102)"
            strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE WRN_SUB"
            strSQL = strSQL & " SET item_code = '" & Edit20.Text & "'"
            strSQL = strSQL & ", vdr_code = '" & WK_Combo21 & "'"
            strSQL = strSQL & ", section_code = '" & WK_Combo16 & "'"
            strSQL = strSQL & ", line_code = '" & WK_Combo17 & "'"
            strSQL = strSQL & ", cls_code = '" & WK_Combo18 & "'"
            strSQL = strSQL & ", sub_cls_code = '" & WK_Combo19 & "'"
            strSQL = strSQL & ", item_name = '" & Edit22.Text & "'"
            strSQL = strSQL & ", standard_name = '" & Edit23.Text & "'"
            strSQL = strSQL & ", prch_price = " & Number24.Value & ""
            strSQL = strSQL & ", wrn_date = CONVERT(DATETIME, '" & Date25.Text & "', 102)"
            strSQL = strSQL & ", wrn_prod = " & Number26.Value & ""
            strSQL = strSQL & ", wrn_fee = " & Number27.Value & ""
            strSQL = strSQL & ", fee_kbn = '" & Combo1.Text & "'"
            If CheckBox1.Checked = True Then strSQL = strSQL & ", dlt_f = 1" Else strSQL = strSQL & ", dlt_f = 0"
            If CheckBox2.Checked = True Then strSQL = strSQL & ", aka_kuro = 1" Else strSQL = strSQL & ", aka_kuro = 0"
            strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
            strSQL = strSQL & " AND (line_no = '" & Edit02.Text & "')"
            strSQL = strSQL & " AND (close_date = CONVERT(DATETIME, '" & Date01.Text & "/01', 102))"
            strSQL = strSQL & " AND (seq = " & Number01.Value & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            DB_CLOSE()
            MessageBox.Show("更新しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call clr()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** クリア
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call clr()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 取消
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ans = MessageBox.Show("取消ししてもよろしいですか。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If ans = "2" Then Exit Sub 'いいえ

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()

        'CX_WRN_SUB コピー
        strSQL = "INSERT INTO CX_WRN_SUB"
        strSQL = strSQL & " (wrn_no, close_date, line_no, seq, item_code, vdr_code, section_code, line_code, cls_code"
        strSQL = strSQL & ", sub_cls_code, item_name, standard_name, prch_price, wrn_date, wrn_prod, wrn_fee, cont_flg"
        strSQL = strSQL & ", add_date, dlt_f, aka_kuro, cx_date)"
        strSQL = strSQL & " SELECT wrn_no, close_date, line_no, seq, item_code, vdr_code, section_code, line_code"
        strSQL = strSQL & ", cls_code, sub_cls_code, item_name, standard_name, prch_price, wrn_date, wrn_prod"
        strSQL = strSQL & ", wrn_fee, cont_flg, add_date, dlt_f, aka_kuro, '2013/04/16 16:10:44' AS cx_date"
        strSQL = strSQL & " FROM WRN_SUB"
        strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
        strSQL = strSQL & " AND (line_no = '" & Edit02.Text & "')"
        strSQL = strSQL & " AND (close_date = CONVERT(DATETIME, '" & Date01.Text & "/01', 102))"
        strSQL = strSQL & " AND (seq = " & Number01.Value & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        'WRN_SUB 削除
        strSQL = "DELETE FROM WRN_SUB"
        strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
        strSQL = strSQL & " AND (line_no = '" & Edit02.Text & "')"
        strSQL = strSQL & " AND (close_date = CONVERT(DATETIME, '" & Date01.Text & "/01', 102))"
        strSQL = strSQL & " AND (seq = " & Number01.Value & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        WK_DsList1.Clear()
        strSQL = "SELECT wrn_no"
        strSQL = strSQL & " FROM CX_WRN_MAIN"
        strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(WK_DsList1, "CX_WRN_MAIN")
        If r = 0 Then   'CXに無かったらコピー
            'CX_WRN_MAIN コピー
            strSQL = "INSERT INTO CX_WRN_MAIN"
            strSQL = strSQL & " (wrn_no, user_name_KANA, user_name, user_tel_no, appl_name_KANA, appl_name, appl_tel_no, zip"
            strSQL = strSQL & ", adrs1, adrs2, adrs3, floor, room_name, livi_togr, shop_code, rcpt_empl_code, rcpt_empl_name, input_date, new_txt)"
            strSQL = strSQL & " SELECT wrn_no, user_name_KANA, user_name, user_tel_no, appl_name_KANA, appl_name"
            strSQL = strSQL & ", appl_tel_no, zip, adrs1, adrs2, adrs3, floor, room_name, livi_togr, shop_code"
            strSQL = strSQL & ", rcpt_empl_code, rcpt_empl_name, input_date, new_txt"
            strSQL = strSQL & " FROM WRN_MAIN"
            strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        End If

        strSQL = "SELECT wrn_no"
        strSQL = strSQL & " FROM WRN_SUB"
        strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(WK_DsList1, "WRN_SUB")
        If r = 0 Then  '他にsubが無かったら削除
            'CX_WRN_MAIN 削除
            strSQL = "DELETE FROM WRN_MAIN"
            strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        End If

        DB_CLOSE()
        MessageBox.Show("取消しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call clr()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** エラーに戻す
    '******************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Number02.Value = 0 Then
            msg.Text = "戻せないデータです。TXT_idなし"
        Else
            WK_DsList2.Clear()
            DB_OPEN()
            strSQL = "SELECT txt_all_id FROM err WHERE (txt_all_id = " & Number02.Value & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(WK_DsList2, "err")
            If r = 0 Then
                strSQL = "INSERT INTO err"
                strSQL = strSQL & " (txt_all_id, err_code, fin_f, wrn_no, line_no, delt_flg, close_date)"
                strSQL = strSQL & " VALUES (" & Number02.Value
                strSQL = strSQL & ", '000'"
                strSQL = strSQL & ", 0"
                strSQL = strSQL & ", '" & Edit01.Text & "'"
                strSQL = strSQL & ", '" & Edit02.Text & "'"
                strSQL = strSQL & ", 0"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Date01.Text & "/01', 102))"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Else
                strSQL = "UPDATE err"
                strSQL = strSQL & " SET fin_f = 0, delt_flg = 0"
                strSQL = strSQL & " WHERE (txt_all_id = " & Number02.Value & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If

            strSQL = "DELETE FROM WRN_SUB"
            strSQL = strSQL & " WHERE (wrn_no = '" & Edit01.Text & "')"
            strSQL = strSQL & " AND (close_date = CONVERT(DATETIME, '" & Date01.Text & "/01', 102))"
            strSQL = strSQL & " AND (line_no = '" & Edit02.Text & "')"
            strSQL = strSQL & " AND (seq = " & Number01.Value & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            strSQL = "SELECT wrn_no FROM WRN_SUB WHERE (wrn_no = '" & Edit01.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(WK_DsList2, "WRN_SUB")
            If r = 0 Then
                strSQL = "DELETE FROM WRN_MAIN WHERE (wrn_no = '" & Edit01.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()

            End If

            DB_CLOSE()
            MessageBox.Show("エラーに戻しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call clr()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 戻る
    '******************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB.Clear()
        P_RTN = "0"
        Close()
    End Sub
End Class
