Imports GrapeCity.Win.Input.Interop

Public Class F00_Form11
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    'Friend WithEvents Furigana As New ImeHandler
    'Friend WithEvents Furigana2 As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DsCMB1, DsCMB2 As New DataSet
    Dim DtView1, WK_DtView1 As DataView
    Dim strSQL, Err_F, ANS, WK_str, WK_code, upd_date, S_Edit04, S_Edit05 As String
    Dim i, r, WK_IHD, WK_fee_un, WK_fee_cp, WK_amt, WK_max, loop_n As Integer
    Dim WK_date As Date

    Dim set_f As String = "0"

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        'Me.Furigana = Me.Edit04.Ime
        '↓↓↓↓↓↓ 2021/10/15 修正
        'Me.Furigana = Me.Edit05.Ime
        '↑↑↑↑↑↑ 2021/10/15 修正

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Date01 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button_S1 As System.Windows.Forms.Button
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Mask01 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Combo02 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo03 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo05 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Combo06 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Edit09 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CheckBox01 As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents CheckBox03 As System.Windows.Forms.CheckBox
    Friend WithEvents Date03 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents cmb05 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents Number02 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number03 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents br_cmb05 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox04 As System.Windows.Forms.CheckBox
    Friend WithEvents ittpan As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Date04 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents br_cmb09 As System.Windows.Forms.Label
    Friend WithEvents CheckBox06 As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Number04 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox07 As System.Windows.Forms.CheckBox
    Friend WithEvents tax_rate As System.Windows.Forms.Label
    Friend WithEvents add_date As System.Windows.Forms.Label
    Friend WithEvents cmb07 As System.Windows.Forms.Label
    Friend WithEvents Combo07 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents br_cmb07 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button99 = New System.Windows.Forms.Button
        Me.Date01 = New GrapeCity.Win.Input.Interop.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Button_S1 = New System.Windows.Forms.Button
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Mask01 = New GrapeCity.Win.Input.Interop.Mask
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label8 = New System.Windows.Forms.Label
        Me.Combo01 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Combo02 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo03 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo05 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Combo06 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label19 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Interop.Date
        Me.Edit08 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label20 = New System.Windows.Forms.Label
        Me.Number02 = New GrapeCity.Win.Input.Interop.Number
        Me.Label21 = New System.Windows.Forms.Label
        Me.Number03 = New GrapeCity.Win.Input.Interop.Number
        Me.Label22 = New System.Windows.Forms.Label
        Me.Combo09 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Edit09 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label24 = New System.Windows.Forms.Label
        Me.CheckBox01 = New System.Windows.Forms.CheckBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label01 = New System.Windows.Forms.Label
        Me.CheckBox03 = New System.Windows.Forms.CheckBox
        Me.Date03 = New GrapeCity.Win.Input.Interop.Date
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.cmb05 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.cmb01 = New System.Windows.Forms.Label
        Me.br_cmb05 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox04 = New System.Windows.Forms.CheckBox
        Me.ittpan = New System.Windows.Forms.Label
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Date04 = New GrapeCity.Win.Input.Interop.Date
        Me.br_cmb09 = New System.Windows.Forms.Label
        Me.CheckBox06 = New System.Windows.Forms.CheckBox
        Me.Number04 = New GrapeCity.Win.Input.Interop.Number
        Me.Label16 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.CheckBox07 = New System.Windows.Forms.CheckBox
        Me.tax_rate = New System.Windows.Forms.Label
        Me.add_date = New System.Windows.Forms.Label
        Me.cmb07 = New System.Windows.Forms.Label
        Me.Combo07 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label17 = New System.Windows.Forms.Label
        Me.br_cmb07 = New System.Windows.Forms.Label
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(912, 608)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 38
        Me.Button99.Text = "閉じる"
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(120, 40)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 0
        Me.Date01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 24)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "申込日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "加入番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit01
        '
        Me.Edit01.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Edit01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(120, 72)
        Me.Edit01.MaxLength = 10
        Me.Edit01.Name = "Edit01"
        Me.Edit01.ReadOnly = True
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(104, 24)
        Me.Edit01.TabIndex = 1
        Me.Edit01.TabStop = False
        Me.Edit01.Text = "EDIT01"
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button_S1
        '
        Me.Button_S1.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S1.Location = New System.Drawing.Point(232, 160)
        Me.Button_S1.Name = "Button_S1"
        Me.Button_S1.Size = New System.Drawing.Size(64, 24)
        Me.Button_S1.TabIndex = 7
        Me.Button_S1.Text = "〒→住所"
        '
        'Edit03
        '
        Me.Edit03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(120, 212)
        Me.Edit03.MaxLength = 100
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(548, 24)
        Me.Edit03.TabIndex = 9
        Me.Edit03.Text = "Edit03"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(120, 188)
        Me.Edit02.MaxLength = 100
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(548, 24)
        Me.Edit02.TabIndex = 8
        Me.Edit02.Text = "Edit02"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Mask01
        '
        Me.Mask01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask01.Format = New GrapeCity.Win.Input.Interop.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask01.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Mask01.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask01.Location = New System.Drawing.Point(120, 160)
        Me.Mask01.Name = "Mask01"
        Me.Mask01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Mask01.Size = New System.Drawing.Size(104, 24)
        Me.Mask01.TabIndex = 6
        Me.Mask01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask01.Value = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(0, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 72)
        Me.Label4.TabIndex = 166
        Me.Label4.Text = "住所"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(0, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 24)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "カナ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(0, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 24)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "氏名"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit05
        '
        Me.Edit05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(120, 132)
        Me.Edit05.MaxLength = 25
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(548, 24)
        Me.Edit05.TabIndex = 4
        Me.Edit05.Text = "Edit05"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(120, 104)
        Me.Edit04.MaxLength = 25
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(548, 24)
        Me.Edit04.TabIndex = 2
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit06
        '
        Me.Edit06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit06.Format = "9#"
        Me.Edit06.HighlightText = True
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(120, 240)
        Me.Edit06.MaxLength = 20
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(160, 24)
        Me.Edit06.TabIndex = 10
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(0, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 24)
        Me.Label8.TabIndex = 174
        Me.Label8.Text = "電話番号"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo01.Location = New System.Drawing.Point(112, 288)
        Me.Combo01.MaxDropDownItems = 20
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(240, 24)
        Me.Combo01.TabIndex = 13
        Me.Combo01.Value = "Combo01"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(0, 288)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 24)
        Me.Label9.TabIndex = 179
        Me.Label9.Text = "大学"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(360, 292)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 24)
        Me.Label10.TabIndex = 180
        Me.Label10.Text = "学部"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(672, 288)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 24)
        Me.Label11.TabIndex = 181
        Me.Label11.Text = "学科"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo02
        '
        Me.Combo02.AutoSelect = True
        Me.Combo02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo02.Location = New System.Drawing.Point(428, 288)
        Me.Combo02.MaxDropDownItems = 20
        Me.Combo02.Name = "Combo02"
        Me.Combo02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo02.Size = New System.Drawing.Size(240, 24)
        Me.Combo02.TabIndex = 14
        Me.Combo02.Value = "Combo02"
        '
        'Combo03
        '
        Me.Combo03.AutoSelect = True
        Me.Combo03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo03.Location = New System.Drawing.Point(740, 288)
        Me.Combo03.MaxDropDownItems = 20
        Me.Combo03.Name = "Combo03"
        Me.Combo03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo03.Size = New System.Drawing.Size(240, 24)
        Me.Combo03.TabIndex = 15
        Me.Combo03.Value = "Combo03"
        '
        'Combo05
        '
        Me.Combo05.AutoSelect = True
        Me.Combo05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Combo05.Location = New System.Drawing.Point(116, 340)
        Me.Combo05.MaxDropDownItems = 20
        Me.Combo05.Name = "Combo05"
        Me.Combo05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo05.Size = New System.Drawing.Size(240, 24)
        Me.Combo05.TabIndex = 16
        Me.Combo05.Value = "Combo05"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(116, 316)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(240, 24)
        Me.Label13.TabIndex = 186
        Me.Label13.Text = "メーカー"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo06
        '
        Me.Combo06.AutoSelect = True
        Me.Combo06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Combo06.Location = New System.Drawing.Point(360, 340)
        Me.Combo06.MaxDropDownItems = 20
        Me.Combo06.Name = "Combo06"
        Me.Combo06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo06.Size = New System.Drawing.Size(308, 24)
        Me.Combo06.TabIndex = 17
        Me.Combo06.Value = "Combo06"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(360, 316)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(308, 24)
        Me.Label14.TabIndex = 188
        Me.Label14.Text = "商品名"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(672, 316)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(176, 24)
        Me.Label15.TabIndex = 190
        Me.Label15.Text = "シリアル番号"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit07
        '
        Me.Edit07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit07.HighlightText = True
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(672, 340)
        Me.Edit07.MaxLength = 50
        Me.Edit07.Name = "Edit07"
        Me.Edit07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit07.Size = New System.Drawing.Size(176, 24)
        Me.Edit07.TabIndex = 18
        Me.Edit07.Text = "Edit07"
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(28, 404)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 24)
        Me.Label19.TabIndex = 222
        Me.Label19.Text = "保証開始"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(116, 404)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 20
        Me.Date02.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Edit08
        '
        Me.Edit08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit08.HighlightText = True
        Me.Edit08.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit08.LengthAsByte = True
        Me.Edit08.Location = New System.Drawing.Point(580, 404)
        Me.Edit08.MaxLength = 300
        Me.Edit08.Multiline = True
        Me.Edit08.Name = "Edit08"
        Me.Edit08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit08.Size = New System.Drawing.Size(404, 164)
        Me.Edit08.TabIndex = 27
        Me.Edit08.Text = "Edit08"
        Me.Edit08.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Top
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(536, 404)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 164)
        Me.Label20.TabIndex = 223
        Me.Label20.Text = "メモ"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Number02
        '
        Me.Number02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number02.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.HighlightText = True
        Me.Number02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number02.Location = New System.Drawing.Point(120, 436)
        Me.Number02.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(104, 24)
        Me.Number02.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.TabIndex = 22
        Me.Number02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(0, 436)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 24)
        Me.Label21.TabIndex = 225
        Me.Label21.Text = "加入料金(税別)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number03
        '
        Me.Number03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number03.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number03.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number03.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number03.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number03.HighlightText = True
        Me.Number03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number03.Location = New System.Drawing.Point(120, 464)
        Me.Number03.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number03.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number03.Name = "Number03"
        Me.Number03.ReadOnly = True
        Me.Number03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number03.Size = New System.Drawing.Size(104, 24)
        Me.Number03.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.TabIndex = 23
        Me.Number03.TabStop = False
        Me.Number03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number03.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(0, 468)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(116, 24)
        Me.Label22.TabIndex = 227
        Me.Label22.Text = "(税込)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(120, 504)
        Me.Combo09.MaxDropDownItems = 35
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(356, 24)
        Me.Combo09.TabIndex = 25
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(0, 504)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(116, 24)
        Me.Label23.TabIndex = 229
        Me.Label23.Text = "取扱店"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit09
        '
        Me.Edit09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit09.HighlightText = True
        Me.Edit09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit09.LengthAsByte = True
        Me.Edit09.Location = New System.Drawing.Point(120, 536)
        Me.Edit09.MaxLength = 50
        Me.Edit09.Name = "Edit09"
        Me.Edit09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit09.Size = New System.Drawing.Size(352, 24)
        Me.Edit09.TabIndex = 26
        Me.Edit09.Text = "Edit09"
        Me.Edit09.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(0, 536)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 24)
        Me.Label24.TabIndex = 231
        Me.Label24.Text = "販売員"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBox01
        '
        Me.CheckBox01.Location = New System.Drawing.Point(692, 100)
        Me.CheckBox01.Name = "CheckBox01"
        Me.CheckBox01.TabIndex = 28
        Me.CheckBox01.Text = "加入証戻り"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(296, 468)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(92, 24)
        Me.Label25.TabIndex = 235
        Me.Label25.Text = "入金状況"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.SystemColors.Window
        Me.Label01.Location = New System.Drawing.Point(392, 468)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(136, 24)
        Me.Label01.TabIndex = 23
        Me.Label01.Text = "Label01"
        Me.Label01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox03
        '
        Me.CheckBox03.Location = New System.Drawing.Point(692, 128)
        Me.CheckBox03.Name = "CheckBox03"
        Me.CheckBox03.Size = New System.Drawing.Size(60, 24)
        Me.CheckBox03.TabIndex = 29
        Me.CheckBox03.Text = "全損"
        '
        'Date03
        '
        Me.Date03.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date03.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date03.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date03.Location = New System.Drawing.Point(756, 128)
        Me.Date03.Name = "Date03"
        Me.Date03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date03.Size = New System.Drawing.Size(104, 24)
        Me.Date03.TabIndex = 30
        Me.Date03.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date03.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 608)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "クリア"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(112, 608)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 28)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "検索"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(220, 608)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 28)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "更新"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(328, 608)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 28)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "削除"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(436, 608)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 28)
        Me.Button5.TabIndex = 37
        Me.Button5.Text = "加入証"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(0, 340)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 24)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "機種"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 580)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(980, 20)
        Me.msg.TabIndex = 1347
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.SystemColors.Window
        Me.Label02.Location = New System.Drawing.Point(480, 504)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(48, 24)
        Me.Label02.TabIndex = 1348
        Me.Label02.Text = "一般"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb05
        '
        Me.cmb05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb05.Location = New System.Drawing.Point(304, 324)
        Me.cmb05.Name = "cmb05"
        Me.cmb05.Size = New System.Drawing.Size(52, 16)
        Me.cmb05.TabIndex = 1350
        Me.cmb05.Text = "cmb05"
        Me.cmb05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb05.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(420, 492)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1354
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(308, 256)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1355
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'br_cmb05
        '
        Me.br_cmb05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb05.Location = New System.Drawing.Point(632, 48)
        Me.br_cmb05.Name = "br_cmb05"
        Me.br_cmb05.Size = New System.Drawing.Size(120, 16)
        Me.br_cmb05.TabIndex = 1358
        Me.br_cmb05.Text = "br_cmb05"
        Me.br_cmb05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb05.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(252, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(740, 32)
        Me.Label3.TabIndex = 1359
        Me.Label3.Text = "QG-Care  iPad　加入申込"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox04
        '
        Me.CheckBox04.Location = New System.Drawing.Point(860, 336)
        Me.CheckBox04.Name = "CheckBox04"
        Me.CheckBox04.Size = New System.Drawing.Size(120, 36)
        Me.CheckBox04.TabIndex = 19
        Me.CheckBox04.Text = "シリアル番号連絡待ち"
        '
        'ittpan
        '
        Me.ittpan.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.ittpan.Location = New System.Drawing.Point(476, 488)
        Me.ittpan.Name = "ittpan"
        Me.ittpan.Size = New System.Drawing.Size(52, 16)
        Me.ittpan.TabIndex = 1360
        Me.ittpan.Text = "False"
        Me.ittpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ittpan.Visible = False
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####", "", "", "-", "", "", "")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####", "", "", "-", "", "", "")
        Me.Number1.Location = New System.Drawing.Point(56, 0)
        Me.Number1.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.ReadOnly = True
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(64, 28)
        Me.Number1.TabIndex = 1361
        Me.Number1.TabStop = False
        Me.Number1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Number1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number1.Value = Nothing
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(124, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 24)
        Me.Label12.TabIndex = 1362
        Me.Label12.Text = "年度"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(224, 404)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 24)
        Me.Label26.TabIndex = 1364
        Me.Label26.Text = "終期"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date04
        '
        Me.Date04.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date04.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date04.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date04.Location = New System.Drawing.Point(284, 404)
        Me.Date04.Name = "Date04"
        Me.Date04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date04.Size = New System.Drawing.Size(104, 24)
        Me.Date04.TabIndex = 21
        Me.Date04.TabStop = False
        Me.Date04.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date04.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'br_cmb09
        '
        Me.br_cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb09.Location = New System.Drawing.Point(632, 68)
        Me.br_cmb09.Name = "br_cmb09"
        Me.br_cmb09.Size = New System.Drawing.Size(352, 16)
        Me.br_cmb09.TabIndex = 1368
        Me.br_cmb09.Text = "br_cmb09"
        Me.br_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb09.Visible = False
        '
        'CheckBox06
        '
        Me.CheckBox06.Location = New System.Drawing.Point(228, 468)
        Me.CheckBox06.Name = "CheckBox06"
        Me.CheckBox06.Size = New System.Drawing.Size(60, 24)
        Me.CheckBox06.TabIndex = 24
        Me.CheckBox06.Text = "手動"
        '
        'Number04
        '
        Me.Number04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number04.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number04.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number04.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number04.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number04.Enabled = False
        Me.Number04.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number04.HighlightText = True
        Me.Number04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number04.Location = New System.Drawing.Point(756, 160)
        Me.Number04.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number04.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number04.Name = "Number04"
        Me.Number04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number04.Size = New System.Drawing.Size(104, 24)
        Me.Number04.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number04.TabIndex = 30
        Me.Number04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number04.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(692, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 24)
        Me.Label16.TabIndex = 1370
        Me.Label16.Text = "解約金"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(116, 264)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton1.TabIndex = 11
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "大学"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(184, 264)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton2.TabIndex = 12
        Me.RadioButton2.Text = "法人"
        '
        'CheckBox07
        '
        Me.CheckBox07.Location = New System.Drawing.Point(300, 40)
        Me.CheckBox07.Name = "CheckBox07"
        Me.CheckBox07.Size = New System.Drawing.Size(148, 24)
        Me.CheckBox07.TabIndex = 2
        Me.CheckBox07.Text = "消費税追徴あり"
        '
        'tax_rate
        '
        Me.tax_rate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.tax_rate.Location = New System.Drawing.Point(460, 48)
        Me.tax_rate.Name = "tax_rate"
        Me.tax_rate.Size = New System.Drawing.Size(52, 16)
        Me.tax_rate.TabIndex = 1371
        Me.tax_rate.Text = "tax_rate"
        Me.tax_rate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tax_rate.Visible = False
        '
        'add_date
        '
        Me.add_date.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.add_date.Location = New System.Drawing.Point(300, 64)
        Me.add_date.Name = "add_date"
        Me.add_date.Size = New System.Drawing.Size(104, 16)
        Me.add_date.TabIndex = 1372
        Me.add_date.Text = "add_date"
        Me.add_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.add_date.Visible = False
        '
        'cmb07
        '
        Me.cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb07.Location = New System.Drawing.Point(224, 372)
        Me.cmb07.Name = "cmb07"
        Me.cmb07.Size = New System.Drawing.Size(52, 16)
        Me.cmb07.TabIndex = 1375
        Me.cmb07.Text = "cmb07"
        Me.cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb07.Visible = False
        '
        'Combo07
        '
        Me.Combo07.AutoSelect = True
        Me.Combo07.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo07.Location = New System.Drawing.Point(116, 372)
        Me.Combo07.MaxDropDownItems = 20
        Me.Combo07.Name = "Combo07"
        Me.Combo07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo07.Size = New System.Drawing.Size(104, 24)
        Me.Combo07.TabIndex = 20
        Me.Combo07.Value = "Combo07"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(-4, 372)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 24)
        Me.Label17.TabIndex = 1374
        Me.Label17.Text = "保証期間"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'br_cmb07
        '
        Me.br_cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb07.Location = New System.Drawing.Point(500, 68)
        Me.br_cmb07.Name = "br_cmb07"
        Me.br_cmb07.Size = New System.Drawing.Size(120, 16)
        Me.br_cmb07.TabIndex = 1376
        Me.br_cmb07.Text = "br_cmb07"
        Me.br_cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb07.Visible = False
        '
        'F00_Form11
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 643)
        Me.Controls.Add(Me.br_cmb07)
        Me.Controls.Add(Me.cmb07)
        Me.Controls.Add(Me.Combo07)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.add_date)
        Me.Controls.Add(Me.tax_rate)
        Me.Controls.Add(Me.CheckBox07)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Number04)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CheckBox06)
        Me.Controls.Add(Me.br_cmb09)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Date04)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ittpan)
        Me.Controls.Add(Me.CheckBox04)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.br_cmb05)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.cmb05)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Date03)
        Me.Controls.Add(Me.CheckBox03)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.CheckBox01)
        Me.Controls.Add(Me.Edit09)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Number03)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Number02)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Edit08)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Combo06)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Combo05)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Combo03)
        Me.Controls.Add(Me.Combo02)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button_S1)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Mask01)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入者データ更新"
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call clr()      '** 項目クリア
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        ''消費税率
        'WK_DsList1.Clear()
        'strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & Mid(Now.Date, 9, 2) & ")"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nQGCare")
        'r = DaList1.Fill(WK_DsList1, "cls_TAX")
        'DB_CLOSE()
        'If r <> 0 Then
        '    WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
        '    tax_rate.Text = WK_DtView1(0)("cls_code_name")
        'Else
        '    tax_rate.Text = 8
        'End If

        'iPad加入料（税別）大学版
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'IUN')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "cls_IUN")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_IUN"), "", "", DataViewRowState.CurrentRows)
            WK_fee_un = WK_DtView1(0)("cls_code_name")
        Else
            WK_fee_un = 0
        End If

        'iPad加入料（税別）法人版
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'ICP')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "cls_ICP")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_ICP"), "", "", DataViewRowState.CurrentRows)
            WK_fee_cp = WK_DtView1(0)("cls_code_name")
        Else
            WK_fee_cp = 0
        End If

        'QG-Care iPad HD
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'IHD')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "cls_IHD")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_IHD"), "", "", DataViewRowState.CurrentRows)
            WK_IHD = WK_DtView1(0)("cls_code_name")
        Else
            WK_IHD = 0
        End If

        Call clr()  '** 項目クリア
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        '大学
        strSQL = "SELECT univ_code, univ_name FROM M01_univ WHERE (delt_flg = 0) ORDER BY univ_name_kana, univ_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M01_univ")
        Combo01.DataSource = DsCMB1.Tables("M01_univ")
        Combo01.DisplayMember = "univ_name"
        Combo01.ValueMember = "univ_code"

        '学部
        strSQL = "SELECT dpmt_name FROM T01_member WHERE (delt_flg = 0) GROUP BY dpmt_name HAVING (dpmt_name IS NOT NULL) ORDER BY dpmt_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "dpmt_name")
        Combo02.DataSource = DsCMB1.Tables("dpmt_name")
        Combo02.DisplayMember = "dpmt_name"
        Combo02.ValueMember = "dpmt_name"

        '学科
        strSQL = "SELECT sbjt_name FROM T01_member WHERE (delt_flg = 0) GROUP BY sbjt_name ORDER BY sbjt_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "sbjt_name")
        Combo03.DataSource = DsCMB1.Tables("sbjt_name")
        Combo03.DisplayMember = "sbjt_name"
        Combo03.ValueMember = "sbjt_name"

        '↓↓↓↓↓↓ 2021/10/15 修正
        '保証期間
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSK') AND (cls_code = 3 OR cls_code = 4) ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_HSK")
        Combo07.DataSource = DsCMB1.Tables("cls_HSK")
        Combo07.DisplayMember = "cls_code_name"
        Combo07.ValueMember = "cls_code"
        '↑↑↑↑↑↑ 2021/10/15 修正

        '販売店
        strSQL = "SELECT shop_code, shop_name, ittpan FROM M04_shop WHERE (shop_code <> 0) AND (delt_flg = 0) ORDER BY shop_name_kana, shop_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M04_shop")
        Combo09.DataSource = DsCMB1.Tables("M04_shop")
        Combo09.DisplayMember = "shop_name"
        Combo09.ValueMember = "shop_code"

        DB_CLOSE()

        Call cmb_modl_name() '商品名

        DB_OPEN("nQGCare")

        'メーカー
        strSQL = "SELECT vndr_code, name FROM M05_VNDR WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M05_VNDR")
        Combo05.DataSource = DsCMB1.Tables("M05_VNDR")
        Combo05.DisplayMember = "name"
        Combo05.ValueMember = "vndr_code"

        DB_CLOSE()
    End Sub
    Sub cmb_modl_name()
        DsCMB2.Clear()
        DB_OPEN("nQGCare")

        '商品名
        strSQL = "SELECT modl_name FROM T01_member"
        strSQL += " WHERE (delt_flg = 0)"
        If cmb05.Text <> Nothing Then
            strSQL += " AND (makr_code = '" & cmb05.Text & "')"
        End If
        strSQL += " GROUP BY modl_name "
        strSQL += "HAVING (modl_name IS NOT NULL)"
        strSQL += " ORDER BY modl_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB2, "modl_name")
        Combo06.DataSource = DsCMB2.Tables("modl_name")
        Combo06.DisplayMember = "modl_name"
        Combo06.ValueMember = "modl_name"

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 項目クリア
    '******************************************************************
    Sub clr()
        Date01.Number = 0 : Date01.BackColor = System.Drawing.SystemColors.Window
        CheckBox07.Checked = False : CheckBox07.Visible = False
        Edit01.Text = Nothing : Edit01.BackColor = System.Drawing.SystemColors.Window

        Date02.Number = 0 : Date02.BackColor = System.Drawing.SystemColors.Window
        Date03.Number = 0 : Date03.BackColor = System.Drawing.SystemColors.Window
        Date04.Number = 0 : Date04.BackColor = System.Drawing.SystemColors.Window

        Edit02.Text = Nothing : Edit02.BackColor = System.Drawing.SystemColors.Window
        Edit03.Text = Nothing : Edit03.BackColor = System.Drawing.SystemColors.Window
        Edit04.Text = Nothing : Edit04.BackColor = System.Drawing.SystemColors.Window
        Edit05.Text = Nothing : Edit05.BackColor = System.Drawing.SystemColors.Window
        Edit06.Text = Nothing : Edit06.BackColor = System.Drawing.SystemColors.Window
        Edit07.Text = Nothing : Edit07.BackColor = System.Drawing.SystemColors.Window
        Edit08.Text = Nothing : Edit08.BackColor = System.Drawing.SystemColors.Window
        Edit09.Text = Nothing : Edit09.BackColor = System.Drawing.SystemColors.Window
        '↓↓↓↓↓↓ 2021/10/15 修正
        'Edit14.Text = Nothing : Edit14.BackColor = System.Drawing.SystemColors.Window
        'Edit15.Text = Nothing : Edit15.BackColor = System.Drawing.SystemColors.Window 
        '↑↑↑↑↑↑ 2021/10/15 修正

        Mask01.Value = Nothing : Mask01.BackColor = System.Drawing.SystemColors.Window

        Combo01.Text = Nothing : Combo01.BackColor = System.Drawing.SystemColors.Window : cmb01.Text = Nothing
        Combo02.Text = Nothing : Combo02.BackColor = System.Drawing.SystemColors.Window
        Combo03.Text = Nothing : Combo03.BackColor = System.Drawing.SystemColors.Window
        Combo05.Text = Nothing : Combo05.BackColor = System.Drawing.SystemColors.Window : cmb05.Text = Nothing : br_cmb05.Text = "-"
        Combo06.Text = Nothing : Combo06.BackColor = System.Drawing.SystemColors.Window
        '↓↓↓↓↓↓ 2021/10/15 修正
        Combo07.Text = Nothing : Combo07.BackColor = System.Drawing.SystemColors.Window : cmb07.Text = Nothing : br_cmb07.Text = "-"
        '↑↑↑↑↑↑ 2021/10/15 修正
        Combo09.Text = Nothing : Combo09.BackColor = System.Drawing.SystemColors.Window : cmb09.Text = Nothing : br_cmb09.Text = "-" : Label02.Visible = False

        Number02.Value = 0 : Number02.BackColor = System.Drawing.SystemColors.Window
        Number03.Value = 0 : Number03.BackColor = System.Drawing.SystemColors.Window
        Number03.ReadOnly = True
        Number04.Value = 0 : Number04.BackColor = System.Drawing.SystemColors.Window

        Label01.Text = Nothing

        CheckBox01.Checked = False
        CheckBox03.Checked = False
        CheckBox04.Checked = False
        CheckBox06.Checked = False

        RadioButton1.Checked = True
        amn_set()

        If P_proc_y = 0 Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
        Number1.Value = P_proc_y

        Button4.Enabled = False
        Button5.Enabled = False

        ittpan.Text = Nothing
        msg.Text = Nothing
        Date01.Focus()
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        Call CK_Date01()    '申込日
        If msg.Text <> Nothing Then Err_F = "1" : Date01.Focus() : Exit Sub

        Call CK_Edit04()    '姓
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        '↓↓↓↓↓↓ 2021/10/15 修正
        'Call CK_Edit14()    '名
        'If msg.Text <> Nothing Then Err_F = "1" : Edit14.Focus() : Exit Sub
        '↑↑↑↑↑↑ 2021/10/15 修正

        Call CK_Edit05()    '姓カナ
        If msg.Text <> Nothing Then Err_F = "1" : Edit05.Focus() : Exit Sub

        '↓↓↓↓↓↓ 2021/10/15 修正
        'Call CK_Edit15()    '名カナ
        'If msg.Text <> Nothing Then Err_F = "1" : Edit15.Focus() : Exit Sub
        '↑↑↑↑↑↑ 2021/10/15 修正

        Call CK_Mask01()    '郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask01.Focus() : Exit Sub

        Call CK_Edit02()    '住所1
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        Call CK_Edit03()    '住所2
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        Call CK_Combo01()   '大学
        If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

        Call CK_Combo05()   'メーカー
        If msg.Text <> Nothing Then Err_F = "1" : Combo05.Focus() : Exit Sub

        Call CK_Combo06()   '商品名
        If msg.Text <> Nothing Then Err_F = "1" : Combo06.Focus() : Exit Sub

        Call CK_CheckBox04() 'シリアル番号連絡待ち
        If msg.Text <> Nothing Then Err_F = "1" : CheckBox04.Focus() : Exit Sub

        '↓↓↓↓↓↓ 2021/10/15 修正
        Call CK_Combo07()   '保証期間
        If msg.Text <> Nothing Then Err_F = "1" : Combo07.Focus() : Exit Sub
        '↑↑↑↑↑↑ 2021/10/15 修正

        Call CK_Date02()    '保証開始
        If msg.Text <> Nothing Then Err_F = "1" : Date02.Focus() : Exit Sub

        Call CK_Date04()    '終期
        If msg.Text <> Nothing Then Err_F = "1" : Date04.Focus() : Exit Sub

        Call CK_Combo09()   '販売店
        If msg.Text <> Nothing Then Err_F = "1" : Combo09.Focus() : Exit Sub

        Call CK_Edit09()    '販売員
        If msg.Text <> Nothing Then Err_F = "1" : Edit09.Focus() : Exit Sub

        Call CK_Date03()    '盗難または全損日
        If msg.Text <> Nothing Then Err_F = "1" : Date03.Focus() : Exit Sub

    End Sub
    Sub CK_Date01()     '申込日
        msg.Text = Nothing

        If Date01.Number = 0 Then
            msg.Text = "申込日の入力がありません。"
            Date01.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Date01.Text < "2019/10/01" Then
                CheckBox07.Visible = True       '追徴
                CheckBox07.Focus()
            Else
                CheckBox07.Visible = False
            End If
            '消費税率
            WK_DsList1.Clear()
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Date01.Number, 1, 8) & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_TAX")
            DB_CLOSE()
            If r <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
                tax_rate.Text = WK_DtView1(0)("cls_code_name")
            Else
                tax_rate.Text = 8
            End If
        End If
        Date01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit04()     '氏名(姓)
        msg.Text = Nothing
        Edit04.Text = Trim(Edit04.Text)
        Edit04.Text = Replace(Edit04.Text, vbCrLf, "")

        If Edit04.Text = Nothing Then
            '↓↓↓↓↓↓ 2021/10/15 修正
            'msg.Text = "氏名(姓)の入力がありません。"
            msg.Text = "氏名の入力がありません。"
            '↑↑↑↑↑↑ 2021/10/15 修正
            Edit04.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    '↓↓↓↓↓↓ 2021/10/15 修正
    'Sub CK_Edit14()     '氏名(名)
    '    msg.Text = Nothing
    '    Edit14.Text = Trim(Edit14.Text)
    '    Edit14.Text = Replace(Edit14.Text, vbCrLf, "")

    '    If RadioButton1.Checked = True Then
    '        If Edit14.Text = Nothing Then
    '            msg.Text = "氏名(名)の入力がありません。"
    '            Edit14.BackColor = System.Drawing.Color.Red : Exit Sub
    '        End If
    '    End If
    '    Edit14.BackColor = System.Drawing.SystemColors.Window
    'End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正
    Sub CK_Edit05()     'カナ(姓)
        msg.Text = Nothing
        Edit05.Text = Trim(Edit05.Text)
        Edit05.Text = Replace(Edit05.Text, vbCrLf, "")

        Edit05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    '↓↓↓↓↓↓ 2021/10/15 修正
    'Sub CK_Edit15()     'カナ(名)
    '    msg.Text = Nothing
    '    Edit15.Text = Trim(Edit15.Text)
    '    Edit15.Text = Replace(Edit15.Text, vbCrLf, "")

    '    Edit15.BackColor = System.Drawing.SystemColors.Window
    'End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正
    Sub CK_Mask01()     '郵便番号
        msg.Text = Nothing

        If Mask01.Value = Nothing Then
        Else
            If Len(Mask01.Value) <> 7 Then
                msg.Text = "郵便番号は7桁入力してください。"
                Mask01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Mask01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit02()     '住所1
        msg.Text = Nothing
        Edit02.Text = Trim(Edit02.Text)
        Edit02.Text = Replace(Edit02.Text, vbCrLf, "")

        If Edit02.Text = Nothing Then
            msg.Text = "住所の入力がありません。"
            Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit03()     '住所2
        msg.Text = Nothing
        Edit03.Text = Trim(Edit03.Text)
        Edit03.Text = Replace(Edit03.Text, vbCrLf, "")

        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo01()    '大学
        msg.Text = Nothing
        cmb01.Text = Nothing
        Combo01.Text = Trim(Combo01.Text)

        If Combo01.Text = Nothing Then
            If RadioButton1.Checked = True Then
                msg.Text = "大学の入力がありません。"
                Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        Else
            DtView1 = New DataView(DsCMB1.Tables("M01_univ"), "univ_name ='" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb01.Text = DtView1(0)("univ_code")
            Else
                If RadioButton1.Checked = True Then
                    msg.Text = "該当の大学はありません。"
                Else
                    msg.Text = "該当の法人はありません。"
                End If
                Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo05()    'メーカー
        msg.Text = Nothing
        Combo05.Text = Trim(Combo05.Text)

        If Combo05.Text <> br_cmb05.Text Then
            cmb05.Text = Nothing
            If Combo05.Text = Nothing Then
                msg.Text = "メーカーの入力がありません。"
                Combo05.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("M05_VNDR"), "name ='" & Combo05.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb05.Text = DtView1(0)("vndr_code")
                Else
                    msg.Text = "該当のメーカーはありません。"
                    Combo05.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If

            Call cmb_modl_name() '商品名
            Combo06.Text = Nothing
            br_cmb05.Text = Combo05.Text
        End If
        Combo05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo06()    '商品名
        msg.Text = Nothing
        Combo06.Text = Trim(Combo06.Text)

        If Combo06.Text = Nothing Then
            msg.Text = "商品名の入力がありません。"
            Combo06.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Combo06.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit07()     'シリアル番号
        msg.Text = Nothing
        Edit07.Text = Trim(Edit07.Text)

        If Edit07.Text <> Nothing Then
            CheckBox04.Checked = False
        End If
        CheckBox04.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Sub CK_CheckBox04() 'シリアル番号連絡待ち
        msg.Text = Nothing
        If Edit07.Text <> Nothing Then
            If CheckBox04.Checked = True Then
                msg.Text = "シリアル番号連絡待ちはシリアル番号が未入力の時のみ入力可"
                CheckBox04.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        CheckBox04.BackColor = System.Drawing.SystemColors.Control
    End Sub
    '↓↓↓↓↓↓ 2021/10/15 修正
    Sub CK_Combo07()    '保証期間
        msg.Text = Nothing
        Combo07.Text = Trim(Combo07.Text)

        If Combo07.Text <> br_cmb07.Text Then
            cmb07.Text = Nothing
            If Combo07.Text = Nothing Then
                msg.Text = "保証期間の入力がありません。"
                Combo07.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("cls_HSK"), "cls_code_name ='" & Combo07.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb07.Text = DtView1(0)("cls_code")
                Else
                    msg.Text = "該当の保証期間はありません。"
                    Combo07.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            'If Inz_F = "0" Then Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
            If cmb07.Text <> Nothing And Date02.Number <> 0 Then
                Date04.Text = wrn_end_Get(cmb07.Text, Date02.Text)
            Else
                Date04.Text = Nothing
            End If

            br_cmb07.Text = Combo07.Text
        End If
        Combo07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正
    Sub CK_Date02()     '保証開始
        msg.Text = Nothing

        If Date02.Number = 0 Then
            msg.Text = "保証開始の入力がありません。"
            Date02.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Date02.Number > Date01.Number Then
                msg.Text = "申込日後になっています。"
                Date02.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
            If Date04.Number = 0 Then
                Date04.Text = wrn_end_Get("3", Date02.Text)
            End If
        End If

        cx_amt_get()
        Date02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date04()     '終期
        msg.Text = Nothing

        If Date04.Number = 0 Then
            msg.Text = "終期の入力がありません。"
            Date04.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Date04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo09()    '販売店
        msg.Text = Nothing
        Combo09.Text = Trim(Combo09.Text)

        If Combo09.Text <> br_cmb09.Text Then
            cmb09.Text = Nothing
            ittpan.Text = Nothing
            Label02.Visible = False

            If Combo09.Text = Nothing Then
                msg.Text = "販売店の入力がありません。"
                Combo09.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("M04_shop"), "shop_name ='" & Combo09.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb09.Text = DtView1(0)("shop_code")
                    If DtView1(0)("ittpan") = "True" Then
                        Label02.Visible = True
                        ittpan.Text = "True"
                    Else
                        ittpan.Text = "False"
                    End If
                Else
                    msg.Text = "該当の販売店はありません。"
                    Combo09.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            br_cmb09.Text = Combo09.Text
        End If
        Combo09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit09()     '販売員
        msg.Text = Nothing
        Edit09.Text = Trim(Edit09.Text)
        Edit09.Text = Replace(Edit09.Text, vbCrLf, "")

        Edit09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date03()     '盗難または全損日
        msg.Text = Nothing
        If CheckBox03.Checked = True Then
            If Date03.Number = 0 Then
                msg.Text = "全損の時は日付の入力をしてください。"
                Date03.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        Else
            If Date03.Number <> 0 Then
                msg.Text = "全損でない時は日付の入力は出来ません。"
                Date03.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        cx_amt_get()
        Date03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_daburi()

        '重複チェック（大学名と氏名）
        WK_DsList1.Clear()
        strSQL = "SELECT univ_code, user_name FROM T01_member"
        strSQL += " WHERE (univ_code = " & cmb01.Text & ")"
        strSQL += " AND (user_name = '" & Edit04.Text & "')"
        strSQL += " AND (delt_flg = 0)"
        If Edit01.Text <> Nothing Then   '修正
            strSQL += " AND (code <> '" & Edit01.Text & "')"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(WK_DsList1, "T01_member")
        DB_CLOSE()

    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        Call CK_Date01()    '申込日
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Call CK_Edit04()    '氏名(姓)
    End Sub
    '↓↓↓↓↓↓ 2021/10/15 修正
    'Private Sub Edit14_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call CK_Edit14()    '氏名(名)
    'End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Call CK_Edit05()    'カナ(姓)
    End Sub
    '↓↓↓↓↓↓ 2021/10/15 修正
    'Private Sub Edit15_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call CK_Edit15()    'カナ(名)
    'End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正
    Private Sub Mask01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask01.LostFocus
        Call CK_Mask01()    '郵便番号
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CK_Edit02()    '住所1
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CK_Edit03()    '住所2
    End Sub
    Private Sub Combo01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.LostFocus
        Call CK_Combo01()   '大学
    End Sub
    Private Sub Combo05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo05.LostFocus
        Call CK_Combo05()   'メーカー
    End Sub
    Private Sub Combo06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo06.LostFocus
        Call CK_Combo06()   '商品名
    End Sub
    Private Sub Edit07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit07.LostFocus
        Call CK_Edit07()    'シリアル番号
    End Sub
    '↓↓↓↓↓↓ 2021/10/15 修正
    Private Sub Combo07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo07.LostFocus
        Call CK_Combo07()   '保証期間
        amn_set()
    End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正
    Private Sub Date02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date02.LostFocus
        Call CK_Date02()   '保証開始
    End Sub
    Private Sub Date04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date04.LostFocus
        Call CK_Date04()   '終期
    End Sub
    Private Sub Combo09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.LostFocus
        Call CK_Combo09()   '販売店
    End Sub
    Private Sub Edit09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit09.LostFocus
        Call CK_Edit09()    '販売員
    End Sub
    Private Sub Date03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date03.LostFocus
        Call CK_Date03()    '盗難または全損日
    End Sub
    Private Sub CheckBox04_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox04.CheckedChanged
        Call CK_CheckBox04() 'シリアル番号連絡待ち
    End Sub

    '******************************************************************
    '** 変更時
    '******************************************************************
    '加入料金(税別)
    Private Sub Number02_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.TextChanged
        Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)
    End Sub
    '全損フラグ
    Private Sub CheckBox03_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox03.CheckedChanged
        If CheckBox03.Checked = False Then
            Date03.Text = Nothing
            Number04.Value = 0
        End If
    End Sub
    Sub cx_amt_get()
        Number04.Value = 0
        If Date02.Number <> 0 And Date03.Number <> 0 Then   '保証開始と全損日入力
            If Date02.Text <= Date03.Text Then    '保証開始と全損日入力
                If DateAdd(DateInterval.Year, 1, CDate(Date02.Text)) > Date03.Text Then  '1年目
                    If RadioButton1.Checked = True Then '大学
                        Number04.Value = 4100
                    Else                                '法人
                        Number04.Value = 4300
                    End If
                Else
                    If DateAdd(DateInterval.Year, 2, CDate(Date02.Text)) > Date03.Text Then  '2年目
                        If RadioButton1.Checked = True Then '大学
                            Number04.Value = 2000
                        Else                                '法人
                            Number04.Value = 2100
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    '大学/法人
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If set_f = "0" Then
            Label9.Text = "大学"
            Label10.Text = "学部"
            Number02.Value = 0
            amn_set()
            cx_amt_get()
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If set_f = "0" Then
            Label9.Text = "会社"
            Label10.Text = "部署"
            Number02.Value = 0
            amn_set()
            cx_amt_get()
        End If
    End Sub
    Sub amn_set()
        '↓↓↓↓↓↓ 2021/10/15 修正
        'If Number02.Value = 0 Then
        If RadioButton1.Checked = True Then '大学
            'Number02.Value = WK_fee_un
            'iPad加入料（税別）大学版
            WK_DsList1.Clear()
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'IUN') AND (cls_code = '" & cmb07.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_IUN")
            DB_CLOSE()
            If r <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("cls_IUN"), "", "", DataViewRowState.CurrentRows)
                Number02.Value = WK_DtView1(0)("cls_code_name")
            Else
                Number02.Value = 0
            End If
        Else                                '法人
            Number02.Value = WK_fee_cp
        End If
        'End If
        '↑↑↑↑↑↑ 2021/10/15 修正
    End Sub
    '手動
    Private Sub CheckBox06_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox06.CheckedChanged
        If CheckBox06.Checked = True Then
            Number03.ReadOnly = False
            Number03.Focus()
        Else
            Number03.ReadOnly = True
            Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)
        End If
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' 取得したふりがなを表示します。
    '    If Edit04.ReadOnly = False Then
    '        Edit05.Text += e.ReadString
    '    End If
    'End Sub
    '↓↓↓↓↓↓ 2021/10/15 修正
    'Private Sub Furigana2_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana2.ResultString
    '    ' 取得したふりがなを表示します。
    '    If Edit14.ReadOnly = False Then
    '        Edit15.Text += e.ReadString
    '    End If
    'End Sub
    '↑↑↑↑↑↑ 2021/10/15 修正

    '******************************************************************
    '** 〒→住所
    '******************************************************************
    Private Sub Button_S1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S1.Click
        '郵便番号->住所
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList1.Clear()
        strSQL = "SELECT adrs FROM M15_ZIP"
        strSQL += " WHERE (zip = '" & Mask01.Value & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(P_DsList1, "M15_ZIP")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                msg.Text = "該当郵便番号なし"
                Mask01.Focus()
            Case Is = 1
                WK_DtView1 = New DataView(P_DsList1.Tables("M15_ZIP"), "", "", DataViewRowState.CurrentRows)
                Edit02.Text = Trim(WK_DtView1(0)("adrs"))
                Edit02.Focus()
                Edit02.BackColor = System.Drawing.SystemColors.Window
            Case Else
                Dim F00_Form10_02 As New F00_Form10_02
                F00_Form10_02.ShowDialog()

                If P_RTN <> Nothing Then Edit02.Text = P_RTN : Edit02.Focus() : Edit02.BackColor = System.Drawing.SystemColors.Window
        End Select

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** クリア
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call clr()  '** 項目クリア
    End Sub

    '******************************************************************
    '** 検索
    '******************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        iPad = "1"
        'Me.Hide()
        Dim F00_Form10_01 As New F00_Form10_01
        F00_Form10_01.ShowDialog()
        'Me.Show()

        If P_RTN = "1" Then
            set_f = "1"
            Call clr()  '** 項目クリア
            DsList1.Clear()

            SqlCmd1 = New SqlClient.SqlCommand("sp_T01_member", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 10)
            Pram1.Value = P_PRAM1
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "T01_member")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True

                Number1.Value = DtView1(0)("nendo")
                If Not IsDBNull(DtView1(0)("upd_date")) Then upd_date = DtView1(0)("upd_date") Else upd_date = Nothing
                If Not IsDBNull(DtView1(0)("Part_date")) Then Date01.Text = DtView1(0)("Part_date") Else Date01.Text = Nothing
                Call CK_Date01()    '申込日
                Edit01.Text = DtView1(0)("code")
                'If Not IsDBNull(DtView1(0)("user_name")) Then Edit04.Text = DtView1(0)("user_name") Else Edit04.Text = Nothing
                'If Not IsDBNull(DtView1(0)("use_name_kana")) Then Edit05.Text = DtView1(0)("use_name_kana") Else Edit05.Text = Nothing
                '↓↓↓↓↓↓ 2021/10/15 修正
                If Not IsDBNull(DtView1(0)("user_name")) Then Edit04.Text = DtView1(0)("user_name") Else Edit04.Text = Nothing
                If Not IsDBNull(DtView1(0)("use_name_kana")) Then Edit05.Text = DtView1(0)("use_name_kana") Else Edit05.Text = Nothing
                '↑↑↑↑↑↑ 2021/10/15 修正
                If Not IsDBNull(DtView1(0)("zip")) Then Mask01.Value = DtView1(0)("zip") Else DtView1(0)("zip") = Nothing
                If Not IsDBNull(DtView1(0)("adrs1")) Then Edit02.Text = DtView1(0)("adrs1") Else Edit02.Text = Nothing
                If Not IsDBNull(DtView1(0)("adrs2")) Then Edit03.Text = DtView1(0)("adrs2") Else Edit03.Text = Nothing
                If Not IsDBNull(DtView1(0)("tel")) Then Edit06.Text = DtView1(0)("tel") Else Edit06.Text = Nothing
                If Not IsDBNull(DtView1(0)("univ_code")) Then cmb01.Text = DtView1(0)("univ_code") Else cmb01.Text = Nothing
                If Not IsDBNull(DtView1(0)("univ_name")) Then Combo01.Text = DtView1(0)("univ_name") Else Combo01.Text = Nothing
                If Not IsDBNull(DtView1(0)("dpmt_name")) Then Combo02.Text = DtView1(0)("dpmt_name") Else Combo02.Text = Nothing
                If Not IsDBNull(DtView1(0)("sbjt_name")) Then Combo03.Text = DtView1(0)("sbjt_name") Else Combo03.Text = Nothing

                If Not IsDBNull(DtView1(0)("makr_code")) Then cmb05.Text = DtView1(0)("makr_code") Else cmb05.Text = Nothing
                WK_DtView1 = New DataView(DsCMB1.Tables("M05_VNDR"), "vndr_code = '" & cmb05.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Combo05.Text = WK_DtView1(0)("name")
                Else
                    Combo05.Text = Nothing
                End If
                br_cmb05.Text = Combo05.Text
                If Not IsDBNull(DtView1(0)("modl_name")) Then Combo06.Text = DtView1(0)("modl_name") Else Combo06.Text = Nothing
                If Not IsDBNull(DtView1(0)("s_no")) Then Edit07.Text = DtView1(0)("s_no") Else Edit07.Text = Nothing
                If Not IsDBNull(DtView1(0)("s_no_wait")) Then
                    If DtView1(0)("s_no_wait") = "True" Then CheckBox04.Checked = True Else CheckBox04.Checked = False
                Else
                    CheckBox04.Checked = False
                End If

                '↓↓↓↓↓↓ 2021/10/15 修正
                If Not IsDBNull(DtView1(0)("wrn_tem")) Then cmb07.Text = DtView1(0)("wrn_tem") Else cmb07.Text = Nothing
                If Not IsDBNull(DtView1(0)("wrn_tem_name")) Then Combo07.Text = DtView1(0)("wrn_tem_name") Else Combo07.Text = Nothing
                br_cmb07.Text = Combo07.Text
                '↑↑↑↑↑↑ 2021/10/15 修正

                If Not IsDBNull(DtView1(0)("makr_wrn_stat")) Then Date02.Text = DtView1(0)("makr_wrn_stat") Else Date02.Text = Nothing
                If Not IsDBNull(DtView1(0)("wrn_end")) Then Date04.Text = DtView1(0)("wrn_end") Else Date04.Text = Nothing

                If Not IsDBNull(DtView1(0)("wrn_fee")) Then Number02.Value = DtView1(0)("wrn_fee") Else Number02.Value = 0
                Number03.Value = Number02.Value + RoundDOWN(Number02.Value * DtView1(0)("tax_rate") / 100, 0)
                If Not IsDBNull(DtView1(0)("clct_stts_name")) Then Label01.Text = DtView1(0)("clct_stts_name") Else Label01.Text = Nothing
                If Not IsDBNull(DtView1(0)("shop_code")) Then cmb09.Text = DtView1(0)("shop_code") Else cmb09.Text = Nothing
                If Not IsDBNull(DtView1(0)("shop_name")) Then Combo09.Text = DtView1(0)("shop_name") Else Combo09.Text = Nothing
                br_cmb09.Text = Combo09.Text
                If DtView1(0)("ittpan") = "True" Then
                    Label02.Visible = True
                    ittpan.Text = "True"
                Else
                    Label02.Visible = False
                    ittpan.Text = "False"
                End If
                If Not IsDBNull(DtView1(0)("sale_pson")) Then Edit09.Text = DtView1(0)("sale_pson") Else Edit09.Text = Nothing
                If Not IsDBNull(DtView1(0)("memo")) Then Edit08.Text = DtView1(0)("memo") Else Edit08.Text = Nothing

                If DtView1(0)("Part_prt_bak") = "True" Then CheckBox01.Checked = True Else CheckBox01.Checked = False
                If DtView1(0)("zenson_flg") = "True" Then CheckBox03.Checked = True Else CheckBox03.Checked = False
                If Not IsDBNull(DtView1(0)("tonan_date")) Then Date03.Text = DtView1(0)("tonan_date") Else Date03.Text = Nothing
            End If

            'T05_iPad
            strSQL = "SELECT * FROM T05_iPad WHERE (code = '" & Edit01.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "T05_iPad")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("T05_iPad"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                '↓↓↓↓↓↓ 2021/10/15 修正
                'If Not IsDBNull(DtView1(0)("user_name_sei")) Then Edit04.Text = DtView1(0)("user_name_sei") Else Edit04.Text = Nothing
                'If Not IsDBNull(DtView1(0)("user_name_mei")) Then Edit14.Text = DtView1(0)("user_name_mei") Else Edit14.Text = Nothing
                'If Not IsDBNull(DtView1(0)("use_name_kana_sei")) Then Edit05.Text = DtView1(0)("use_name_kana_sei") Else Edit05.Text = Nothing
                'If Not IsDBNull(DtView1(0)("use_name_kana_mei")) Then Edit15.Text = DtView1(0)("use_name_kana_mei") Else Edit15.Text = Nothing
                '↑↑↑↑↑↑ 2021/10/15 修正
                If DtView1(0)("wrn_fee_flg") = "True" Then CheckBox06.Checked = True Else CheckBox06.Checked = False
                If Not IsDBNull(DtView1(0)("cxl_amnt")) Then Number04.Value = DtView1(0)("cxl_amnt") Else Number04.Value = 0
                If DtView1(0)("corp_flg") = "True" Then RadioButton2.Checked = True Else RadioButton1.Checked = True
                If DtView1(0)("add_flg") = "True" Then CheckBox07.Checked = True Else CheckBox07.Checked = False
                If Not IsDBNull(DtView1(0)("add_date")) Then add_date.Text = DtView1(0)("add_date") Else add_date.Text = Nothing
            End If
        End If

        set_f = "0"
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 更新
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then

            If RadioButton1.Checked = True Then
                Call CK_daburi()    '重複チェック（大学名と氏名）
                If r <> 0 Then
                    ANS = MessageBox.Show("大学名と氏名で既に入力済みですが" & System.Environment.NewLine & "登録してよろしいですか", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                    If ANS = "2" Then Cursor = System.Windows.Forms.Cursors.Default : Exit Sub 'いいえ
                End If
            End If

            If Edit01.Text = Nothing Then   '登録

                WK_code = Count_Get("G" & P_proc_y1 & "03") '大学生協
                'WK_code = Count_Get("H" & P_proc_y1 & "03") '販社
                'WK_code = Count_Get("K" & P_proc_y1 & "03") 'TRC・DNP・GSS
                Edit01.Text = WK_code

                strSQL = "INSERT INTO T01_member"
                strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1"
                strSQL += ", adrs2, tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt"
                strSQL += ", wrn_tem, makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee"
                strSQL += ", tax_rate, Part_prt, Part_prt_bak, tonan_flg, zenson_flg, tonan_date, suisen_flg"
                strSQL += ", memo, imp_seq, nendo, reg_date, delt_flg)"
                strSQL += " VALUES ('" & Edit01.Text & "'"                              '加入番号
                '↓↓↓↓↓↓ 2021/10/15 修正
                'strSQL += ", '" & Edit04.Text & "　" & Edit14.Text & "'"                '氏名
                'S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "") & Replace(Replace(Edit14.Text, " ", ""), "　", "")
                'strSQL += ", '" & S_Edit04 & "'"                                        '検索用氏名
                'strSQL += ", '" & Edit05.Text & " " & Edit15.Text & "'"                 'カナ
                'S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "") & Replace(Replace(Edit15.Text, " ", ""), "　", "")
                strSQL += ", '" & Edit04.Text & "'"                                     '氏名
                S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
                strSQL += ", '" & S_Edit04 & "'"                                        '検索用氏名
                strSQL += ", '" & Edit05.Text & "'"                                     'カナ
                S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
                '↑↑↑↑↑↑ 2021/10/15 修正
                strSQL += ", '" & S_Edit05 & "'"                                        '検索用カナ
                strSQL += ", '" & Mask01.Value & "'"                                    '郵便番号
                strSQL += ", '" & Edit02.Text & "'"                                     '住所1
                strSQL += ", '" & Edit03.Text & "'"                                     '住所2
                strSQL += ", '" & Edit06.Text & "'"                                     '電話番号
                If Combo01.Text <> Nothing Then
                    strSQL += ", " & cmb01.Text                                         '大学
                Else
                    strSQL += ", NULL"                                                  '大学
                End If
                strSQL += ", '" & Combo02.Text & "'"                                    '学部
                strSQL += ", '" & Combo03.Text & "'"                                    '学科
                strSQL += ", '" & cmb05.Text & "'"                                      'メーカー
                strSQL += ", '" & Combo06.Text & "'"                                    '商品名
                strSQL += ", '" & Edit07.Text & "'"                                     'シリアル№
                strSQL += ", 0"                                                         '購入価格
                'strSQL += ", '3'"                                                       '保証期間
                strSQL += ", '" & DateDiff("yyyy", Date02.Text, Date04.Text) & "'"      '保証期間
                strSQL += ", CONVERT(DATETIME, '" & Date02.Text & "', 102)"             '保証開始日
                strSQL += ", CONVERT(DATETIME, '" & Date04.Text & "', 102)"             '終期
                strSQL += ", 10"                                                         '保証範囲
                strSQL += ", " & cmb09.Text                                             '販売店
                strSQL += ", '" & Edit09.Text & "'"                                     '販売員
                strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)"             '申込日
                strSQL += ", " & Number02.Value                                         '加入料金(税別)
                strSQL += ", " & tax_rate.Text                                          '消費税率
                strSQL += ", 0"                                                         '加入証印刷
                If CheckBox01.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '加入証戻り
                strSQL += ", 0"                                                         '盗難
                If CheckBox03.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '全損
                If Date03.Number <> 0 Then
                    strSQL += ", CONVERT(DATETIME, '" & Date03.Text & "', 102)"         '全損日
                Else
                    strSQL += ", NULL"
                End If
                strSQL += ", 0"                                                         '推薦
                strSQL += ", '" & Edit08.Text & "'"                                     'メモ
                strSQL += ", 0"                                                         '取込み№
                strSQL += ", " & P_proc_y                                               '年度
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"                '登録日
                strSQL += ", 0)"                                                        '削除ﾌﾗｸﾞ
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()

                'シリアル№待ち
                If CheckBox04.Checked = True Then
                    'T03_s_no_wait
                    strSQL = "INSERT INTO T03_s_no_wait"
                    strSQL += " (code, s_no_wait)"
                    strSQL += " VALUES ('" & Edit01.Text & "'"              '加入番号
                    strSQL += ", 1)"                                        'S/N連絡待ち
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                End If

                'T05_iPad
                strSQL = "INSERT INTO T05_iPad"
                strSQL += " (code, user_name_sei, user_name_mei, use_name_kana_sei, use_name_kana_mei, wrn_fee_flg, cxl_amnt, corp_flg, add_flg, add_date)"
                strSQL += " VALUES ('" & Edit01.Text & "'"                                              '加入番号
                '↓↓↓↓↓↓ 2021/10/15 修正
                'strSQL += ", '" & Edit04.Text & "'"                                                     '氏名(姓)
                'If Edit14.Text <> Nothing Then
                '    strSQL += ", '" & Edit14.Text & "'"                                                 '氏名(名)
                'Else
                '    strSQL += ", NULL"
                'End If
                'strSQL += ", '" & Edit05.Text & "'"                                                     'カナ(姓)
                'If Edit15.Text <> Nothing Then
                '    strSQL += ", '" & Edit15.Text & "'"                                                 'カナ(名)
                'Else
                '    strSQL += ", NULL"
                'End If
                strSQL += ", NULL, NULL, NULL, NULL"
                '↑↑↑↑↑↑ 2021/10/15 修正
                If CheckBox06.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '手動
                strSQL += ", " & Number04.Value & ""                                                    '解約金
                If RadioButton2.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '法人
                If CheckBox07.Checked = True Then
                    strSQL += ", 1"                                                                     '追徴
                    strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102))"                           '追徴日
                Else
                    strSQL += ", 0"
                    strSQL += ", NULL"
                End If
                strSQL += ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()

                ''T40_計上(ヘルプデスク分)
                'strSQL = "INSERT INTO T40_計上"
                'strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                'strSQL += " VALUES ('" & Edit01.Text & "'"                                  '加入番号
                'strSQL += ", N'" & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & "'"          '計上月
                'strSQL += ", 2"                                                             '計上区分
                'strSQL += ", " & WK_IHD                                                     '計上金額
                'strSQL += ", 0"                                                             '預かり金
                'strSQL += ", 1)"                                                            '計上回数
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'SqlCmd1.ExecuteNonQuery()

                ''T40_計上(保証分)
                'loop_n = DateDiff(DateInterval.Month, CDate(Date02.Text), Now.Date)
                'For i = 0 To loop_n
                '    If i = 0 Then
                '        strSQL = "INSERT INTO T40_計上"
                '        strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                '        strSQL += " VALUES ('" & Edit01.Text & "'"                                  '加入番号
                '        strSQL += ", N'" & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & "'"          '計上月
                '        strSQL += ", 1"                                                             '計上区分
                '        If Number02.Value = 6600 Then
                '            WK_amt = 200
                '        Else
                '            WK_amt = (Number02.Value - WK_IHD) - Round((Number02.Value - WK_IHD) / 36, 0) * 35
                '        End If
                '        strSQL += ", " & WK_amt                                                     '計上金額
                '        strSQL += ", " & Number02.Value - WK_IHD - WK_amt                           '預かり金
                '        strSQL += ", 1)"                                                            '計上回数
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.ExecuteNonQuery()
                '    Else
                '        strSQL = "INSERT INTO T40_計上"
                '        strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                '        strSQL += " VALUES ('" & Edit01.Text & "'"                                  '加入番号
                '        strSQL += ", N'" & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & "'"          '計上月
                '        strSQL += ", 1"                                                             '計上区分
                '        If Number02.Value = 6600 Then
                '            WK_amt = 180
                '        Else
                '            WK_amt = Round((Number02.Value - WK_IHD) / 36, 0)
                '        End If
                '        strSQL += ", " & WK_amt                                                     '計上金額
                '        strSQL += ", " & WK_amt * (35 - i)                                          '預かり金
                '        strSQL += ", " & i + 1 & ")"                                                '計上回数
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.ExecuteNonQuery()
                '    End If
                'Next
                DB_CLOSE()

                MessageBox.Show("加入番号：" & Edit01.Text & " で登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else                            '更新

                WK_DsList1.Clear()
                strSQL = "SELECT upd_date FROM T01_member WHERE (code = '" & Edit01.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                DaList1.Fill(WK_DsList1, "T01_member")
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                If Not IsDBNull(WK_DtView1(0)("upd_date")) Then
                    If upd_date <> WK_DtView1(0)("upd_date") Then
                        MessageBox.Show("別の担当者がデータを修正しています。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DB_CLOSE()
                        Cursor = System.Windows.Forms.Cursors.WaitCursor : Exit Sub
                    End If
                End If

                strSQL = "UPDATE T01_member"
                '↓↓↓↓↓↓ 2021/10/15 修正
                'strSQL += " SET user_name = '" & Edit04.Text & "　" & Edit14.Text & "'"     '氏名
                'S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "") & Replace(Replace(Edit14.Text, " ", ""), "　", "")
                'strSQL += ", user_name_search = '" & S_Edit04 & "'"                         '検索用氏名
                'strSQL += ", use_name_kana = '" & Edit05.Text & " " & Edit15.Text & "'"     'カナ
                'S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "") & Replace(Replace(Edit15.Text, " ", ""), "　", "")
                strSQL += " SET user_name = '" & Edit04.Text & "'"                          '氏名
                S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
                strSQL += ", user_name_search = '" & S_Edit04 & "'"                         '検索用氏名
                strSQL += ", use_name_kana = '" & Edit05.Text & "'"                         'カナ
                S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
                '↑↑↑↑↑↑ 2021/10/15 修正
                strSQL += ", use_name_kana_search = '" & S_Edit05 & "'"                     '検索用カナ
                strSQL += ", zip = '" & Mask01.Value & "'"                                  '郵便番号
                strSQL += ", adrs1 = '" & Edit02.Text & "'"                                 '住所1
                strSQL += ", adrs2 = '" & Edit03.Text & "'"                                 '住所2
                strSQL += ", tel = '" & Edit06.Text & "'"                                   '電話番号
                If cmb01.Text <> Nothing Then
                    strSQL += ", univ_code = " & cmb01.Text                                 '大学
                Else
                    strSQL += ", univ_code = NULL"                                          '大学
                End If
                strSQL += ", dpmt_name = '" & Combo02.Text & "'"                            '学部
                strSQL += ", sbjt_name = '" & Combo03.Text & "'"                            '学科
                strSQL += ", makr_code = '" & cmb05.Text & "'"                              'メーカー
                strSQL += ", modl_name = '" & Combo06.Text & "'"                            '商品名
                strSQL += ", s_no = '" & Edit07.Text & "'"                                  'シリアル№
                strSQL += ", prch_amnt = 0"                                                 '購入価格
                'strSQL += ", wrn_tem = 3"                                                   '保証期間
                strSQL += ", wrn_tem = " & DateDiff("yyyy", Date02.Text, Date04.Text)       '保証期間
                strSQL += ", makr_wrn_stat = CONVERT(DATETIME, '" & Date02.Text & "', 102)" '保証開始日
                strSQL += ", wrn_end = CONVERT(DATETIME, '" & Date04.Text & "', 102)"       '終期
                strSQL += ", wrn_range = 10"                                                 '保証範囲
                strSQL += ", shop_code = " & cmb09.Text                                     '販売店
                strSQL += ", sale_pson = '" & Edit09.Text & "'"                             '販売員
                strSQL += ", Part_date = CONVERT(DATETIME, '" & Date01.Text & "', 102)"     '申込日
                strSQL += ", wrn_fee = " & Number02.Value                                   '加入料金(税別)
                strSQL += ", tax_rate = " & tax_rate.Text                                   '消費税率
                If CheckBox01.Checked = True Then strSQL += ", Part_prt_bak = 1" Else strSQL += ", Part_prt_bak = 0" '加入証戻り
                strSQL += ", tonan_flg = 0"                                                 '盗難
                If CheckBox03.Checked = True Then strSQL += ", zenson_flg = 1" Else strSQL += ", zenson_flg = 0" '全損
                If Date03.Number <> 0 Then                                                  '全損日
                    strSQL += ", tonan_date = CONVERT(DATETIME, '" & Date03.Text & "', 102)"
                Else
                    strSQL += ", tonan_date = NULL"
                End If
                strSQL += ", suisen_flg = 0"                                                '推薦
                strSQL += ", memo = '" & Edit08.Text & "'"                                  'メモ
                strSQL += ", upd_date = CONVERT(DATETIME, '" & Now & "', 102)"         '更新日
                strSQL += " WHERE (code = '" & Edit01.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                '請求データ
                WK_DsList1.Clear()
                strSQL = "SELECT * FROM T02_clct WHERE (code = '" & Edit01.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                r = DaList1.Fill(WK_DsList1, "T02_clct")
                If r = 1 Then
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T02_clct"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1(0)("clct_stts") <> "9" Then
                        strSQL = "UPDATE T02_clct"
                        strSQL += " SET invc_amnt = " & Number02.Value
                        strSQL += " WHERE (code = '" & Edit01.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If
                End If
                DB_CLOSE()

                'シリアル№待ち
                WK_DsList1.Clear()
                strSQL = "SELECT code FROM T03_s_no_wait WHERE (code = '" & Edit01.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                r = DaList1.Fill(WK_DsList1, "T01_member")
                If r = 0 Then
                    If CheckBox04.Checked = True Then
                        strSQL = "INSERT INTO T03_s_no_wait"
                        strSQL += " (code, s_no_wait)"
                        strSQL += " VALUES ('" & Edit01.Text & "'"
                        strSQL += ", 1)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If
                Else
                    If CheckBox04.Checked = False Then
                        strSQL = "DELETE FROM T03_s_no_wait"
                        strSQL += " WHERE (code = '" & Edit01.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If
                End If
                DB_CLOSE()

                'T05_iPad
                WK_DsList1.Clear()
                strSQL = "SELECT code FROM T05_iPad WHERE (code = '" & Edit01.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                r = DaList1.Fill(WK_DsList1, "T05_iPad")
                If r = 0 Then
                    strSQL = "INSERT INTO T05_iPad"
                    strSQL += " (code, user_name_sei, user_name_mei, use_name_kana_sei, use_name_kana_mei, wrn_fee_flg, cxl_amnt, corp_flg, add_flg, add_date)"
                    strSQL += " VALUES ('" & Edit01.Text & "'"                                              '加入番号
                    '↓↓↓↓↓↓ 2021/10/15 修正
                    'strSQL += ", '" & Edit04.Text & "'"                                                     '氏名(姓)
                    'strSQL += ", '" & Edit14.Text & "'"                                                     '氏名(名)
                    'strSQL += ", '" & Edit05.Text & "'"                                                     'カナ(姓)
                    'strSQL += ", '" & Edit15.Text & "'"                                                     'カナ(名) 
                    strSQL += ", NULL, NULL, NULL, NULL"
                    '↑↑↑↑↑↑ 2021/10/15 修正

                    If CheckBox06.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '手動
                    strSQL += ", " & Number04.Value                                                         '解約金
                    If RadioButton2.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '法人
                    If CheckBox07.Checked = True Then
                        strSQL += ", 1"                                                                     '追徴
                        strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102))"                           '追徴日
                    Else
                        strSQL += ", 0"
                        strSQL += ", NULL"
                    End If
                    strSQL += ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                Else
                    strSQL = "UPDATE T05_iPad"
                    '↓↓↓↓↓↓ 2021/10/15 修正
                    'strSQL += " SET user_name_sei = '" & Edit04.Text & "'"                                              '氏名(姓)
                    'strSQL += ", user_name_mei = '" & Edit14.Text & "'"                                                 '氏名(名)
                    'strSQL += ", use_name_kana_sei = '" & Edit05.Text & "'"                                             'カナ(姓)
                    'strSQL += ", use_name_kana_mei = '" & Edit15.Text & "'"                                             'カナ(名)
                    strSQL += " SET user_name_sei = NULL"                                                               '氏名(姓)
                    strSQL += ", user_name_mei = NULL"                                                                  '氏名(名)
                    strSQL += ", use_name_kana_sei = NULL"                                                              'カナ(姓)
                    strSQL += ", use_name_kana_mei = NULL"                                                              'カナ(名)
                    '↑↑↑↑↑↑ 2021/10/15 修正
                    If CheckBox06.Checked = True Then strSQL += ", wrn_fee_flg = 1" Else strSQL += ", wrn_fee_flg = 0" '手動
                    strSQL += ", cxl_amnt = " & Number04.Value                                                          '解約金
                    If RadioButton2.Checked = True Then strSQL += ", corp_flg = 1" Else strSQL += ", corp_flg = 0" '法人
                    If CheckBox07.Checked = True Then
                        strSQL += ", add_flg = 1"                                                                       '追徴
                        If add_date.Text = Nothing Then
                            strSQL += ", add_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                        End If
                    Else
                        strSQL += ", add_flg = 0"
                        strSQL += ", add_date = NULL"
                    End If
                    strSQL += " WHERE (code = '" & Edit01.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                End If
                DB_CLOSE()

                ''T40_計上(ヘルプデスク分)
                'WK_DsList1.Clear()
                'strSQL = "SELECT * FROM T40_計上 WHERE (加入番号 = '" & Edit01.Text & "') AND (計上区分 = 2)"
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'DaList1.SelectCommand = SqlCmd1
                'DB_OPEN("nQGCare")
                'r = DaList1.Fill(WK_DsList1, "T40_計上")
                'If r = 0 Then
                '    strSQL = "INSERT INTO T40_計上"
                '    strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                '    strSQL += " VALUES ('" & Edit01.Text & "'"                                  '加入番号
                '    strSQL += ", N'" & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & "'"          '計上月
                '    strSQL += ", 2"                                                             '計上区分
                '    strSQL += ", " & WK_IHD                                                     '計上金額
                '    strSQL += ", 0"                                                             '預かり金
                '    strSQL += ", 1)"                                                            '計上回数
                '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '    SqlCmd1.ExecuteNonQuery()
                'Else
                '    WK_DtView1 = New DataView(WK_DsList1.Tables("T40_計上"), "", "", DataViewRowState.CurrentRows)
                '    strSQL = "UPDATE T40_計上"
                '    strSQL += " SET 計上金額 = " & WK_IHD
                '    strSQL += ", 預かり金 = 0"
                '    strSQL += ", 計上回数 = 1"
                '    strSQL += " WHERE (seq = " & WK_DtView1(0)("seq") & ")"
                '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '    SqlCmd1.ExecuteNonQuery()
                'End If
                'DB_CLOSE()

                ''T40_計上(保証分)
                'If CheckBox03.Checked = True Then   '全損
                '    DB_OPEN("nQGCare")
                '    WK_DsList1.Clear()
                '    strSQL = "SELECT MIN(預かり金) AS 預かり金 FROM T40_計上 WHERE (加入番号 = '" & Edit01.Text & "') AND (全損flg = 0) AND (計上区分 = 1)"
                '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '    DaList1.SelectCommand = SqlCmd1
                '    r = DaList1.Fill(WK_DsList1, "T40_計上_zan")
                '    If r <> 0 Then
                '        WK_DtView1 = New DataView(WK_DsList1.Tables("T40_計上_zan"), "", "", DataViewRowState.CurrentRows)
                '        WK_amt = WK_DtView1(0)("預かり金")
                '    Else
                '        WK_amt = 0
                '    End If

                '    strSQL = "SELECT MAX(計上回数) AS MAX_計上回数 FROM T40_計上 WHERE (加入番号 = '" & Edit01.Text & "') AND (計上区分 = 1)"
                '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '    DaList1.SelectCommand = SqlCmd1
                '    r = DaList1.Fill(WK_DsList1, "T40_計上_max")
                '    If r <> 0 Then
                '        WK_DtView1 = New DataView(WK_DsList1.Tables("T40_計上_max"), "", "", DataViewRowState.CurrentRows)
                '        WK_max = WK_DtView1(0)("MAX_計上回数") + 1
                '    Else
                '        WK_max = 1
                '    End If

                '    strSQL = "SELECT seq FROM T40_計上 WHERE (加入番号 = '" & Edit01.Text & "')  AND (全損flg = 1)"
                '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '    DaList1.SelectCommand = SqlCmd1
                '    r = DaList1.Fill(WK_DsList1, "T40_計上")
                '    If r = 0 Then
                '        '未計上分すべて計上
                '        strSQL = "INSERT INTO T40_計上"
                '        strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数, 全損flg)"
                '        strSQL += " VALUES ('" & Edit01.Text & "'"                                  '加入番号
                '        strSQL += ", N'" & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & "'"          '計上月
                '        strSQL += ", 1"                                                             '計上区分
                '        strSQL += ", " & WK_amt                                                     '計上金額
                '        strSQL += ", 0"                                                             '預かり金
                '        strSQL += ", " & WK_max                                                     '計上回数
                '        strSQL += ", 1)"                                                            '全損flg
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.ExecuteNonQuery()
                '        '解約金
                '        strSQL = "INSERT INTO T40_計上"
                '        strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数, 全損flg)"
                '        strSQL += " VALUES ('" & Edit01.Text & "'"                                  '加入番号
                '        strSQL += ", N'" & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & "'"          '計上月
                '        strSQL += ", 1"                                                             '計上区分
                '        strSQL += ", " & Number04.Value * -1                                        '計上金額
                '        strSQL += ", 0"                                                             '預かり金
                '        strSQL += ", " & WK_max + 1                                                 '計上回数
                '        strSQL += ", 1)"                                                            '全損flg
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.ExecuteNonQuery()
                '    Else
                '        WK_DtView1 = New DataView(WK_DsList1.Tables("T40_計上"), "", "seq", DataViewRowState.CurrentRows)
                '        '未計上分すべて計上
                '        strSQL = "UPDATE T40_計上"
                '        strSQL += " SET 計上金額 = " & WK_amt
                '        strSQL += ", 預かり金 = 0"
                '        strSQL += " WHERE (seq = " & WK_DtView1(0)("seq") & ")"
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.ExecuteNonQuery()
                '        '解約金
                '        strSQL = "UPDATE T40_計上"
                '        strSQL += " SET 計上金額 = " & Number04.Value * -1
                '        strSQL += ", 預かり金 = 0"
                '        strSQL += " WHERE (seq = " & WK_DtView1(1)("seq") & ")"
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.ExecuteNonQuery()
                '    End If
                '    DB_CLOSE()
                'Else
                '    loop_n = DateDiff(DateInterval.Month, CDate(Date02.Text), Now.Date)
                '    DB_OPEN("nQGCare")
                '    For i = 0 To loop_n
                '        WK_date = DateAdd(DateInterval.Month, i, CDate(Date02.Text))

                '        WK_DsList1.Clear()
                '        strSQL = "SELECT * FROM T40_計上 WHERE (加入番号 = '" & Edit01.Text & "') AND (計上区分 = 1) AND (計上回数 = " & i + 1 & ")"
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        DaList1.SelectCommand = SqlCmd1
                '        r = DaList1.Fill(WK_DsList1, "T40_計上")
                '        If r = 0 Then
                '            strSQL = "INSERT INTO T40_計上"
                '            strSQL += " (加入番号, 計上月, 計上区分, 計上金額, 預かり金, 計上回数)"
                '            strSQL += " VALUES ('" & Edit01.Text & "'"                                  '加入番号
                '            strSQL += ", N'" & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & "'"          '計上月
                '            strSQL += ", 1"                                                             '計上区分
                '            If Date01.Text <= "2014/03/31" Then
                '                If CheckBox07.Checked = False Then
                '                    If Number02.Value = 6600 Then
                '                        WK_amt = Round(180 * 1.05 / 1.08, 0)
                '                    Else
                '                        WK_amt = Round((Number02.Value - WK_IHD) / 36 * 1.05 / 1.08, 0)
                '                    End If
                '                Else



                '                End If
                '            Else
                '                If Number02.Value = 6600 Then
                '                    WK_amt = 180
                '                Else
                '                    WK_amt = Round((Number02.Value - WK_IHD) / 36, 0)
                '                End If
                '            End If
                '            strSQL += ", " & WK_amt                                                     '計上金額
                '            strSQL += ", " & WK_amt * (35 - i)                                          '預かり金
                '            strSQL += ", " & i + 1 & ")"                                                '計上回数
                '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '            SqlCmd1.ExecuteNonQuery()
                '        Else
                '            WK_DtView1 = New DataView(WK_DsList1.Tables("T40_計上"), "", "", DataViewRowState.CurrentRows)
                '            If i = 0 Then
                '                strSQL = "UPDATE T40_計上"
                '                If Number02.Value = 6600 Then
                '                    WK_amt = 200
                '                Else
                '                    WK_amt = (Number02.Value - WK_IHD) - Round((Number02.Value - WK_IHD) / 36, 0) * 35
                '                End If
                '                strSQL += " SET 計上金額 = " & WK_amt
                '                strSQL += ", 預かり金 = " & Number02.Value - 100 - WK_amt
                '                strSQL += ", 計上回数 = 1"
                '                strSQL += " WHERE (seq = " & WK_DtView1(0)("seq") & ")"
                '                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '                SqlCmd1.ExecuteNonQuery()
                '            Else
                '                strSQL = "UPDATE T40_計上"
                '                WK_date = DateAdd(DateInterval.Month, i, CDate(Date02.Text))
                '                If Date01.Text <= "2014/03/31" _
                '                    And CheckBox07.Checked = False _
                '                    And WK_DtView1(0)("計上月") >= "201404" Then
                '                    If Number02.Value = 6600 Then
                '                        WK_amt = Round(180 * 1.05 / 1.08, 0)
                '                    Else
                '                        WK_amt = Round((Number02.Value - WK_IHD) / 36 * 1.05 / 1.08, 0)
                '                    End If
                '                Else
                '                    If Number02.Value = 6600 Then
                '                        WK_amt = 180
                '                    Else
                '                        WK_amt = Round((Number02.Value - WK_IHD) / 36, 0)
                '                    End If
                '                End If
                '                strSQL += " SET 計上金額 = " & WK_amt
                '                strSQL += ", 預かり金 = " & WK_amt * (35 - i)
                '                strSQL += ", 計上回数 = " & i + 1
                '                strSQL += " WHERE (seq = " & WK_DtView1(0)("seq") & ")"
                '                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '                SqlCmd1.ExecuteNonQuery()
                '            End If
                '        End If
                '    Next
                '    DB_CLOSE()
                'End If

                MessageBox.Show("更新しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
            Call clr()  '** 項目クリア
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 削除
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'P_PRAM1 = Edit01.Text
        P_PRAM2 = upd_date

        Dim F00_Form10_03 As New F00_Form10_03
        F00_Form10_03.ShowDialog()

        If P_RTN = "1" Then
            strSQL = "UPDATE T01_member"
            strSQL += " SET delt_flg = 1"
            strSQL += ", upd_date = CONVERT(DATETIME, '" & Now & "', 102)"              '更新日
            strSQL += " WHERE (code = '" & Edit01.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "INSERT INTO T04_del"
            strSQL += " (code, del_Reason, del_date, empl_code)"
            strSQL += " VALUES ('" & Edit01.Text & "'"
            strSQL += ", '" & P_PRAM3 & "'"
            strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
            strSQL += ", " & P_EMPL_NO & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Call clr()  '** 項目クリア
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 加入証
    '******************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        WK_DsList1.Clear()
        strSQL = "SELECT Part_prt_date FROM T01_member WHERE (code = '" & Edit01.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(WK_DsList1, "Part_prt_date")
        DB_CLOSE()
        DtView1 = New DataView(WK_DsList1.Tables("Part_prt_date"), "", "", DataViewRowState.CurrentRows)
        If Not IsDBNull(DtView1(0)("Part_prt_date")) Then
            ANS = MessageBox.Show(DtView1(0)("Part_prt_date") & "に印刷をしています。再印刷をしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            If ANS = "2" Then Exit Sub 'いいえ
        End If
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        P_DsPRT.Clear()
        strSQL = "SELECT T01_member.*, M04_shop.shop_name, V_M02_HSK.cls_code_name AS wrn_tem_name"
        strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name, M05_VNDR.name AS makr_name, M01_univ.univ_name"
        strSQL += " FROM T01_member LEFT OUTER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code LEFT OUTER JOIN"
        strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code"
        strSQL += " WHERE (T01_member.code = '" & Edit01.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(P_DsPRT, "Print01")
        DB_CLOSE()

        DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            DtView1(0)("user_name") = DtView1(0)("user_name") & "　様"
            DtView1(0)("adrs1") = DtView1(0)("adrs1") & "　" & DtView1(0)("adrs2")
            DtView1(0)("univ_name") = DtView1(0)("univ_name") & "　" & DtView1(0)("dpmt_name")
        End If

        PRT_PRAM1 = "R_Kanyu_iPad"

        Dim Print_View As New Print_View
        Print_View.ShowDialog()

        P_DsPRT.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        DsCMB1.Clear()
        DsCMB2.Clear()
        P_DsPRT.Clear()
        Close()
    End Sub

    '******************************************************************
    '** 申込日変更時
    '******************************************************************
    Private Sub Date01_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date01.TextChanged
        If IsDate(Date01.Text) Then
            '消費税率
            WK_DsList1.Clear()
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Date01.Text, 1, 4) & Mid(Date01.Text, 6, 2) & Mid(Date01.Text, 9, 2) & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_TAX")
            DB_CLOSE()
            If r <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
                tax_rate.Text = WK_DtView1(0)("cls_code_name")
            Else
                tax_rate.Text = 10
            End If
        Else
            tax_rate.Text = 10
        End If
        Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)
    End Sub
End Class
