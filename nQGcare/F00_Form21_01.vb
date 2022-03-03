Imports GrapeCity.Win.Input.Interop

Public Class F00_Form21_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DsCMB1, DsCMB2 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, strSQL2, Err_F, WK_str, WK_str2, WK_code, WK_code2, ANS, fin_f As String
    Dim i, r, WK_SUI, WK_sou As Integer
    Dim WK_date As Date

    Dim S_Edit04, S_Edit05 As String

    Dim fr_date, to_date As Date

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        'Me.Furigana = Me.Edit04.Ime

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents br_cmb05 As System.Windows.Forms.Label
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents cmb08 As System.Windows.Forms.Label
    Friend WithEvents cmb07 As System.Windows.Forms.Label
    Friend WithEvents cmb05 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Edit09 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Number03 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Number02 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Combo08 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo07 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Number01 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Combo06 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Combo05 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Combo03 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo02 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button_S1 As System.Windows.Forms.Button
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Mask01 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents imp_seq As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents CheckBox04 As System.Windows.Forms.CheckBox
    Friend WithEvents ittpan As System.Windows.Forms.Label
    Friend WithEvents CheckBox05 As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Date04 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents br_cmb09 As System.Windows.Forms.Label
    Friend WithEvents br_cmb08 As System.Windows.Forms.Label
    Friend WithEvents br_cmb07 As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents imp_seq2 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents tax_rate As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents imp_seq3 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents CheckBox06 As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.br_cmb05 = New System.Windows.Forms.Label
        Me.cmb01 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.cmb08 = New System.Windows.Forms.Label
        Me.cmb07 = New System.Windows.Forms.Label
        Me.cmb05 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Edit09 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label24 = New System.Windows.Forms.Label
        Me.Combo09 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Number03 = New GrapeCity.Win.Input.Interop.Number
        Me.Label22 = New System.Windows.Forms.Label
        Me.Number02 = New GrapeCity.Win.Input.Interop.Number
        Me.Label21 = New System.Windows.Forms.Label
        Me.Edit08 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Interop.Date
        Me.Combo08 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo07 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label17 = New System.Windows.Forms.Label
        Me.Number01 = New GrapeCity.Win.Input.Interop.Number
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Combo06 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label14 = New System.Windows.Forms.Label
        Me.Combo05 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Combo03 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo02 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Combo01 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label8 = New System.Windows.Forms.Label
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button_S1 = New System.Windows.Forms.Button
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Mask01 = New GrapeCity.Win.Input.Interop.Mask
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Interop.Date
        Me.imp_seq = New GrapeCity.Win.Input.Interop.Number
        Me.CheckBox04 = New System.Windows.Forms.CheckBox
        Me.ittpan = New System.Windows.Forms.Label
        Me.CheckBox05 = New System.Windows.Forms.CheckBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Date04 = New GrapeCity.Win.Input.Interop.Date
        Me.br_cmb09 = New System.Windows.Forms.Label
        Me.br_cmb08 = New System.Windows.Forms.Label
        Me.br_cmb07 = New System.Windows.Forms.Label
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.Label25 = New System.Windows.Forms.Label
        Me.imp_seq2 = New GrapeCity.Win.Input.Interop.Number
        Me.tax_rate = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.imp_seq3 = New GrapeCity.Win.Input.Interop.Number
        Me.CheckBox06 = New System.Windows.Forms.CheckBox
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imp_seq2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imp_seq3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(912, 608)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 30
        Me.Button99.Text = "閉じる"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(244, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(748, 32)
        Me.Label3.TabIndex = 1431
        Me.Label3.Text = "QG-Care アカデミーパック　加入申込 エラー修正"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'br_cmb05
        '
        Me.br_cmb05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb05.Location = New System.Drawing.Point(504, 84)
        Me.br_cmb05.Name = "br_cmb05"
        Me.br_cmb05.Size = New System.Drawing.Size(176, 16)
        Me.br_cmb05.TabIndex = 1430
        Me.br_cmb05.Text = "br_cmb05"
        Me.br_cmb05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb05.Visible = False
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(312, 264)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1429
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(420, 496)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1428
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'cmb08
        '
        Me.cmb08.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb08.Location = New System.Drawing.Point(352, 408)
        Me.cmb08.Name = "cmb08"
        Me.cmb08.Size = New System.Drawing.Size(52, 16)
        Me.cmb08.TabIndex = 1427
        Me.cmb08.Text = "cmb08"
        Me.cmb08.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb08.Visible = False
        '
        'cmb07
        '
        Me.cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb07.Location = New System.Drawing.Point(172, 388)
        Me.cmb07.Name = "cmb07"
        Me.cmb07.Size = New System.Drawing.Size(52, 16)
        Me.cmb07.TabIndex = 1426
        Me.cmb07.Text = "cmb07"
        Me.cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb07.Visible = False
        '
        'cmb05
        '
        Me.cmb05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb05.Location = New System.Drawing.Point(308, 324)
        Me.cmb05.Name = "cmb05"
        Me.cmb05.Size = New System.Drawing.Size(52, 16)
        Me.cmb05.TabIndex = 1425
        Me.cmb05.Text = "cmb05"
        Me.cmb05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb05.Visible = False
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.SystemColors.Window
        Me.Label02.Location = New System.Drawing.Point(480, 508)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(48, 24)
        Me.Label02.TabIndex = 1423
        Me.Label02.Text = "一般"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 580)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(980, 20)
        Me.msg.TabIndex = 1422
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(0, 336)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 24)
        Me.Label5.TabIndex = 1421
        Me.Label5.Text = "機種"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(116, 608)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 28)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "削除"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(12, 608)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 28)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "更新"
        '
        'Edit09
        '
        Me.Edit09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit09.HighlightText = True
        Me.Edit09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit09.LengthAsByte = True
        Me.Edit09.Location = New System.Drawing.Point(120, 540)
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
        Me.Label24.Location = New System.Drawing.Point(0, 540)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 24)
        Me.Label24.TabIndex = 1418
        Me.Label24.Text = "販売員"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(120, 508)
        Me.Combo09.MaxDropDownItems = 20
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(356, 24)
        Me.Combo09.TabIndex = 25
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(0, 508)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(116, 24)
        Me.Label23.TabIndex = 1417
        Me.Label23.Text = "取扱店"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number03
        '
        Me.Number03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number03.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number03.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number03.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number03.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number03.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number03.HighlightText = True
        Me.Number03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number03.Location = New System.Drawing.Point(120, 468)
        Me.Number03.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number03.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number03.Name = "Number03"
        Me.Number03.ReadOnly = True
        Me.Number03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number03.Size = New System.Drawing.Size(104, 24)
        Me.Number03.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.TabIndex = 24
        Me.Number03.TabStop = False
        Me.Number03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number03.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(0, 472)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(116, 24)
        Me.Label22.TabIndex = 1416
        Me.Label22.Text = "(税込)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number02
        '
        Me.Number02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number02.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.HighlightText = True
        Me.Number02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number02.Location = New System.Drawing.Point(120, 440)
        Me.Number02.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(104, 24)
        Me.Number02.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.TabIndex = 23
        Me.Number02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(0, 440)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 24)
        Me.Label21.TabIndex = 1415
        Me.Label21.Text = "加入料金(税別)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Label20.TabIndex = 1414
        Me.Label20.Text = "メモ"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(228, 372)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 24)
        Me.Label19.TabIndex = 1413
        Me.Label19.Text = "保証開始"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(316, 372)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 21
        Me.Date02.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Combo08
        '
        Me.Combo08.AutoSelect = True
        Me.Combo08.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo08.Location = New System.Drawing.Point(120, 404)
        Me.Combo08.MaxDropDownItems = 20
        Me.Combo08.Name = "Combo08"
        Me.Combo08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo08.Size = New System.Drawing.Size(240, 24)
        Me.Combo08.TabIndex = 22
        Me.Combo08.Value = "Combo08"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(0, 404)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 24)
        Me.Label18.TabIndex = 1412
        Me.Label18.Text = "保証範囲"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo07
        '
        Me.Combo07.AutoSelect = True
        Me.Combo07.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo07.Location = New System.Drawing.Point(120, 372)
        Me.Combo07.MaxDropDownItems = 20
        Me.Combo07.Name = "Combo07"
        Me.Combo07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo07.Size = New System.Drawing.Size(104, 24)
        Me.Combo07.TabIndex = 20
        Me.Combo07.Value = "Combo07"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(0, 372)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(116, 24)
        Me.Label17.TabIndex = 1411
        Me.Label17.Text = "保証期間"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number01
        '
        Me.Number01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number01.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number01.HighlightText = True
        Me.Number01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number01.Location = New System.Drawing.Point(856, 336)
        Me.Number01.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number01.Name = "Number01"
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(128, 24)
        Me.Number01.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.TabIndex = 19
        Me.Number01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number01.Value = Nothing
        '
        'Edit07
        '
        Me.Edit07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit07.HighlightText = True
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(676, 336)
        Me.Edit07.MaxLength = 50
        Me.Edit07.Name = "Edit07"
        Me.Edit07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit07.Size = New System.Drawing.Size(176, 24)
        Me.Edit07.TabIndex = 18
        Me.Edit07.Text = "Edit07"
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(860, 312)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 24)
        Me.Label16.TabIndex = 1410
        Me.Label16.Text = "購入金額（税別）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(676, 312)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(176, 24)
        Me.Label15.TabIndex = 1409
        Me.Label15.Text = "シリアル番号"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo06
        '
        Me.Combo06.AutoSelect = True
        Me.Combo06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Combo06.Location = New System.Drawing.Point(364, 336)
        Me.Combo06.MaxDropDownItems = 20
        Me.Combo06.Name = "Combo06"
        Me.Combo06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo06.Size = New System.Drawing.Size(308, 24)
        Me.Combo06.TabIndex = 17
        Me.Combo06.Value = "Combo06"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(364, 312)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(308, 24)
        Me.Label14.TabIndex = 1408
        Me.Label14.Text = "商品名"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo05
        '
        Me.Combo05.AutoSelect = True
        Me.Combo05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Combo05.Location = New System.Drawing.Point(120, 336)
        Me.Combo05.MaxDropDownItems = 20
        Me.Combo05.Name = "Combo05"
        Me.Combo05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo05.Size = New System.Drawing.Size(240, 24)
        Me.Combo05.TabIndex = 16
        Me.Combo05.Value = "Combo05"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(120, 312)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(240, 24)
        Me.Label13.TabIndex = 1407
        Me.Label13.Text = "メーカー"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo03
        '
        Me.Combo03.AutoSelect = True
        Me.Combo03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo03.Location = New System.Drawing.Point(744, 276)
        Me.Combo03.MaxDropDownItems = 20
        Me.Combo03.Name = "Combo03"
        Me.Combo03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo03.Size = New System.Drawing.Size(240, 24)
        Me.Combo03.TabIndex = 14
        Me.Combo03.Value = "Combo03"
        '
        'Combo02
        '
        Me.Combo02.AutoSelect = True
        Me.Combo02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo02.Location = New System.Drawing.Point(432, 276)
        Me.Combo02.MaxDropDownItems = 20
        Me.Combo02.Name = "Combo02"
        Me.Combo02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo02.Size = New System.Drawing.Size(240, 24)
        Me.Combo02.TabIndex = 13
        Me.Combo02.Value = "Combo02"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(676, 276)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 24)
        Me.Label11.TabIndex = 1405
        Me.Label11.Text = "学科"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(364, 276)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 24)
        Me.Label10.TabIndex = 1404
        Me.Label10.Text = "学部"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(0, 276)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 24)
        Me.Label9.TabIndex = 1403
        Me.Label9.Text = "大学"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo01.Location = New System.Drawing.Point(120, 276)
        Me.Combo01.MaxDropDownItems = 20
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(240, 24)
        Me.Combo01.TabIndex = 12
        Me.Combo01.Value = "Combo01"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(0, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 24)
        Me.Label8.TabIndex = 1402
        Me.Label8.Text = "電話番号"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Edit06.TabIndex = 8
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(0, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 24)
        Me.Label6.TabIndex = 1401
        Me.Label6.Text = "カナ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(0, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 24)
        Me.Label7.TabIndex = 1400
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
        Me.Edit05.MaxLength = 50
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(300, 24)
        Me.Edit05.TabIndex = 3
        Me.Edit05.Text = "Edit05"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit04.HighlightText = True
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(120, 104)
        Me.Edit04.MaxLength = 50
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(300, 24)
        Me.Edit04.TabIndex = 2
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(0, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 72)
        Me.Label4.TabIndex = 1399
        Me.Label4.Text = "住所"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button_S1
        '
        Me.Button_S1.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S1.Location = New System.Drawing.Point(232, 160)
        Me.Button_S1.Name = "Button_S1"
        Me.Button_S1.Size = New System.Drawing.Size(64, 24)
        Me.Button_S1.TabIndex = 5
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
        Me.Edit03.TabIndex = 7
        Me.Edit03.Text = "Edit03"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.HighlightText = True
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(120, 188)
        Me.Edit02.MaxLength = 100
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(548, 24)
        Me.Edit02.TabIndex = 6
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
        Me.Mask01.TabIndex = 4
        Me.Mask01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask01.Value = ""
        '
        'Edit01
        '
        Me.Edit01.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Edit01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.HighlightText = True
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 24)
        Me.Label2.TabIndex = 1360
        Me.Label2.Text = "加入番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 24)
        Me.Label1.TabIndex = 1379
        Me.Label1.Text = "申込日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'imp_seq
        '
        Me.imp_seq.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.imp_seq.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "Null")
        Me.imp_seq.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.imp_seq.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.imp_seq.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.imp_seq.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "")
        Me.imp_seq.Location = New System.Drawing.Point(228, 72)
        Me.imp_seq.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.imp_seq.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.imp_seq.Name = "imp_seq"
        Me.imp_seq.ReadOnly = True
        Me.imp_seq.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.imp_seq.Size = New System.Drawing.Size(92, 24)
        Me.imp_seq.TabIndex = 1432
        Me.imp_seq.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.imp_seq.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.imp_seq.Visible = False
        '
        'CheckBox04
        '
        Me.CheckBox04.Location = New System.Drawing.Point(696, 364)
        Me.CheckBox04.Name = "CheckBox04"
        Me.CheckBox04.Size = New System.Drawing.Size(180, 24)
        Me.CheckBox04.TabIndex = 19
        Me.CheckBox04.Text = "シリアル番号連絡待ち"
        '
        'ittpan
        '
        Me.ittpan.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.ittpan.Location = New System.Drawing.Point(480, 488)
        Me.ittpan.Name = "ittpan"
        Me.ittpan.Size = New System.Drawing.Size(52, 16)
        Me.ittpan.TabIndex = 1433
        Me.ittpan.Text = "False"
        Me.ittpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ittpan.Visible = False
        '
        'CheckBox05
        '
        Me.CheckBox05.Location = New System.Drawing.Point(688, 240)
        Me.CheckBox05.Name = "CheckBox05"
        Me.CheckBox05.TabIndex = 9
        Me.CheckBox05.Text = "推薦"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(424, 372)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 24)
        Me.Label26.TabIndex = 1436
        Me.Label26.Text = "終期"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date04
        '
        Me.Date04.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date04.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date04.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date04.Location = New System.Drawing.Point(484, 372)
        Me.Date04.Name = "Date04"
        Me.Date04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date04.Size = New System.Drawing.Size(104, 24)
        Me.Date04.TabIndex = 22
        Me.Date04.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date04.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'br_cmb09
        '
        Me.br_cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb09.Location = New System.Drawing.Point(504, 152)
        Me.br_cmb09.Name = "br_cmb09"
        Me.br_cmb09.Size = New System.Drawing.Size(352, 16)
        Me.br_cmb09.TabIndex = 1439
        Me.br_cmb09.Text = "br_cmb09"
        Me.br_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb09.Visible = False
        '
        'br_cmb08
        '
        Me.br_cmb08.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb08.Location = New System.Drawing.Point(504, 128)
        Me.br_cmb08.Name = "br_cmb08"
        Me.br_cmb08.Size = New System.Drawing.Size(120, 16)
        Me.br_cmb08.TabIndex = 1438
        Me.br_cmb08.Text = "br_cmb08"
        Me.br_cmb08.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb08.Visible = False
        '
        'br_cmb07
        '
        Me.br_cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb07.Location = New System.Drawing.Point(504, 104)
        Me.br_cmb07.Name = "br_cmb07"
        Me.br_cmb07.Size = New System.Drawing.Size(120, 16)
        Me.br_cmb07.TabIndex = 1437
        Me.br_cmb07.Text = "br_cmb07"
        Me.br_cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb07.Visible = False
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
        Me.Number1.TabIndex = 1440
        Me.Number1.TabStop = False
        Me.Number1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Number1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number1.Value = Nothing
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(124, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 24)
        Me.Label25.TabIndex = 1441
        Me.Label25.Text = "年度"
        '
        'imp_seq2
        '
        Me.imp_seq2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.imp_seq2.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "Null")
        Me.imp_seq2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.imp_seq2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.imp_seq2.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.imp_seq2.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "")
        Me.imp_seq2.Location = New System.Drawing.Point(324, 72)
        Me.imp_seq2.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.imp_seq2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.imp_seq2.Name = "imp_seq2"
        Me.imp_seq2.ReadOnly = True
        Me.imp_seq2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.imp_seq2.Size = New System.Drawing.Size(92, 24)
        Me.imp_seq2.TabIndex = 1442
        Me.imp_seq2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.imp_seq2.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.imp_seq2.Visible = False
        '
        'tax_rate
        '
        Me.tax_rate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.tax_rate.Location = New System.Drawing.Point(232, 48)
        Me.tax_rate.Name = "tax_rate"
        Me.tax_rate.Size = New System.Drawing.Size(52, 16)
        Me.tax_rate.TabIndex = 1443
        Me.tax_rate.Text = "tax_rate"
        Me.tax_rate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tax_rate.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(796, 240)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.TabIndex = 1444
        Me.CheckBox1.Text = "早期"
        '
        'imp_seq3
        '
        Me.imp_seq3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.imp_seq3.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "Null")
        Me.imp_seq3.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.imp_seq3.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.imp_seq3.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.imp_seq3.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("######0", "", "", "-", "", "", "")
        Me.imp_seq3.Location = New System.Drawing.Point(416, 71)
        Me.imp_seq3.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.imp_seq3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.imp_seq3.Name = "imp_seq3"
        Me.imp_seq3.ReadOnly = True
        Me.imp_seq3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.imp_seq3.Size = New System.Drawing.Size(76, 24)
        Me.imp_seq3.TabIndex = 1445
        Me.imp_seq3.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.imp_seq3.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.imp_seq3.Visible = False
        '
        'CheckBox06
        '
        Me.CheckBox06.Location = New System.Drawing.Point(688, 204)
        Me.CheckBox06.Name = "CheckBox06"
        Me.CheckBox06.Size = New System.Drawing.Size(180, 24)
        Me.CheckBox06.TabIndex = 9
        Me.CheckBox06.Text = "PCパック申込者確認"
        '
        'F00_Form21_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 643)
        Me.Controls.Add(Me.CheckBox06)
        Me.Controls.Add(Me.imp_seq3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.tax_rate)
        Me.Controls.Add(Me.imp_seq2)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.br_cmb09)
        Me.Controls.Add(Me.br_cmb08)
        Me.Controls.Add(Me.br_cmb07)
        Me.Controls.Add(Me.CheckBox05)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Date04)
        Me.Controls.Add(Me.ittpan)
        Me.Controls.Add(Me.CheckBox04)
        Me.Controls.Add(Me.imp_seq)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.br_cmb05)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.cmb08)
        Me.Controls.Add(Me.cmb07)
        Me.Controls.Add(Me.cmb05)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
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
        Me.Controls.Add(Me.Combo08)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Combo07)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Label16)
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
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form21_01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "取込みエラー修正"
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imp_seq2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imp_seq3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form21_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call DsSet()    '** データセット
        Call CmbSet()   '** コンボボックスセット
        Call dsp_set()  '** 画面セット

    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        DsList1.Clear()

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

        cmb05.Text = Nothing
        msg.Text = Nothing

    End Sub

    '********************************************************************
    '** データセット
    '********************************************************************
    Sub DsSet()

        '社員
        strSQL = "SELECT * FROM M01_EMPL"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

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

        '保証期間
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSK') ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_HSK")
        Combo07.DataSource = DsCMB1.Tables("cls_HSK")
        Combo07.DisplayMember = "cls_code_name"
        Combo07.ValueMember = "cls_code"

        '保証範囲
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSY') ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "cls_HSY")
        Combo08.DataSource = DsCMB1.Tables("cls_HSY")
        Combo08.DisplayMember = "cls_code_name"
        Combo08.ValueMember = "cls_code"

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

    '********************************************************************
    '** 画面セット
    '********************************************************************
    Sub dsp_set()

        SqlCmd1 = New SqlClient.SqlCommand("sp_E01_member_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 9)
        Pram1.Value = P_PRAM1
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsList1, "E01_member")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("E01_member"), "", "", DataViewRowState.CurrentRows)

        Number1.Value = DtView1(0)("nendo")
        If IsDate(DtView1(0)("Part_date")) = True Then
            Date01.Text = DtView1(0)("Part_date")
        Else
            Date01.Text = Nothing
        End If
        Call CK_Date01()    '申込日
        imp_seq.Value = DtView1(0)("imp_seq")
        imp_seq2.Value = DtView1(0)("imp_seq2")
        imp_seq3.Value = DtView1(0)("imp_seq3")
        Edit01.Text = Nothing
        Edit04.Text = DtView1(0)("name")
        Edit05.Text = DtView1(0)("name_kana")
        WK_str = DtView1(0)("zip") : WK_str = WK_str.Replace("-", "") : Mask01.Value = WK_str
        Edit02.Text = DtView1(0)("adrs1")
        Edit03.Text = DtView1(0)("adrs2")
        Edit06.Text = DtView1(0)("tel")
        cmb01.Text = DtView1(0)("univ_code")
        If Not IsDBNull(DtView1(0)("univ_name2")) Then Combo01.Text = DtView1(0)("univ_name2") Else Combo01.Text = Nothing
        Combo02.Text = DtView1(0)("dpmt_name")
        Combo03.Text = DtView1(0)("sbjt_name")

        Combo05.Text = DtView1(0)("vndr_name") : br_cmb05.Text = DtView1(0)("vndr_name")
        WK_DtView1 = New DataView(DsCMB1.Tables("M05_VNDR"), "name = '" & Combo05.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            cmb05.Text = WK_DtView1(0)("vndr_code")
        End If
        Combo06.Text = DtView1(0)("modl_name")
        Edit07.Text = DtView1(0)("s_no")
        If IsNumeric(DtView1(0)("prch_amnt")) = True Then Number01.Value = DtView1(0)("prch_amnt") Else Number01.Value = 0
        Combo07.Text = DtView1(0)("wrn_tem")
        If Not IsDBNull(DtView1(0)("wrn_tem_code")) Then cmb07.Text = DtView1(0)("wrn_tem_code") Else cmb07.Text = Nothing
        If IsDate(DtView1(0)("makr_wrn_stat")) = True Then
            Date02.Text = DtView1(0)("makr_wrn_stat")
        Else
            Date02.Text = Nothing
        End If
        If cmb07.Text <> Nothing And Date02.Number <> 0 Then
            If CheckBox05.Checked = True Then
                Date04.Text = wrn_end_Get(cmb07.Text, Number1.Value & "/04/01")
            Else
                Date04.Text = wrn_end_Get(cmb07.Text, Date02.Text)
            End If
        Else
            Date04.Text = Nothing
        End If
        Combo08.Text = DtView1(0)("wrn_range")
        If Not IsDBNull(DtView1(0)("wrn_range_code")) Then cmb08.Text = DtView1(0)("wrn_range_code") Else cmb08.Text = Nothing

        cmb09.Text = DtView1(0)("shop_code")
        If Not IsDBNull(DtView1(0)("shop_name")) Then Combo09.Text = DtView1(0)("shop_name") Else Combo09.Text = Nothing
        If Not IsDBNull(DtView1(0)("ittpan")) Then
            If DtView1(0)("ittpan") = "True" Then
                Label02.Visible = True
                ittpan.Text = "True"
            Else
                Label02.Visible = False
                ittpan.Text = "False"
            End If
        Else
            Label02.Visible = False
            ittpan.Text = "False"
        End If
        Edit09.Text = DtView1(0)("sale_pson")
        Edit08.Text = Nothing

        Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
        Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)

        CheckBox04.Checked = False
        CheckBox05.Checked = False

        '↓↓↓↓↓↓ 2021/10/15 修正
        If Not IsDBNull(DtView1(0)("pc_pack")) Then
            If DtView1(0)("pc_pack") = "〇" Then
                CheckBox06.Checked = True
            End If
        End If
        '↑↑↑↑↑↑ 2021/10/15 修正

        msg.Text = DtView1(0)("err_msg")

        If Not IsDBNull(DtView1(0)("fin_empl_code")) Then
            WK_DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "empl_code =" & DtView1(0)("fin_empl_code"), "", DataViewRowState.CurrentRows)
            If Not IsDBNull(DtView1(0)("fin_date")) Then
                msg.Text = "既に" & WK_DtView1(0)("name") & "さんが" & DtView1(0)("fin_date") & "に修正済みです。"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            If Not IsDBNull(DtView1(0)("del_date")) Then
                msg.Text = "既に" & WK_DtView1(0)("name") & "さんが" & DtView1(0)("del_date") & "に削除済みです。"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            fin_f = "1"
        Else
            Button3.Enabled = True
            Button4.Enabled = True
            fin_f = "0"
        End If

        '推薦加入料金
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'SUI') AND (cls_code = " & Number1.Value & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "cls_SUI")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_SUI"), "", "", DataViewRowState.CurrentRows)
            WK_SUI = WK_DtView1(0)("cls_code_name")
        Else
            WK_SUI = 0
        End If

        '早期加入料金
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'sou') AND (cls_code = " & Number1.Value & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(DsList1, "cls_sou")
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_sou"), "", "", DataViewRowState.CurrentRows)
            WK_sou = WK_DtView1(0)("cls_code_name")
        Else
            WK_sou = 0
        End If
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        Call CK_fin()       '既に処理済
        If msg.Text <> Nothing Then Err_F = "1" : Exit Sub

        Call CK_Date01()    '申込日
        If msg.Text <> Nothing Then Err_F = "1" : Date01.Focus() : Exit Sub

        Call CK_Edit04()    '氏名
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        Call CK_Edit05()    'カナ
        If msg.Text <> Nothing Then Err_F = "1" : Edit05.Focus() : Exit Sub

        Call CK_Mask01()    '郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask01.Focus() : Exit Sub

        Call CK_Edit02()    '住所1
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        Call CK_Combo01()   '大学
        If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

        Call CK_Combo05()   'メーカー
        If msg.Text <> Nothing Then Err_F = "1" : Combo05.Focus() : Exit Sub

        Call CK_Combo06()   '商品名
        If msg.Text <> Nothing Then Err_F = "1" : Combo06.Focus() : Exit Sub

        Call CK_CheckBox04() 'シリアル番号連絡待ち
        If msg.Text <> Nothing Then Err_F = "1" : CheckBox04.Focus() : Exit Sub

        Call CK_Combo07()   '保証期間
        If msg.Text <> Nothing Then Err_F = "1" : Combo07.Focus() : Exit Sub

        Call CK_Combo08()   '保証範囲
        If msg.Text <> Nothing Then Err_F = "1" : Combo08.Focus() : Exit Sub

        Call CK_Date02()    '保証開始
        If msg.Text <> Nothing Then Err_F = "1" : Date02.Focus() : Exit Sub

        Call CK_Date04()    '終期
        If msg.Text <> Nothing Then Err_F = "1" : Date04.Focus() : Exit Sub

        Call CK_Combo09()   '販売店
        If msg.Text <> Nothing Then Err_F = "1" : Combo09.Focus() : Exit Sub

    End Sub
    Sub CK_fin()    '既に処理済
        WK_DsList1.Clear()
        strSQL = "SELECT id, fin_date, del_date, fin_empl_code"
        strSQL += " FROM E01_member"
        strSQL += " WHERE (id = " & P_PRAM1 & ")"
        strSQL += " AND (fin_empl_code IS NOT NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(WK_DsList1, "E01_member")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView2 = New DataView(WK_DsList1.Tables("E01_member"), "", "", DataViewRowState.CurrentRows)

            WK_DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "empl_code =" & WK_DtView2(0)("fin_empl_code"), "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView2(0)("fin_date")) Then
                msg.Text = "既に" & WK_DtView1(0)("name") & "さんが" & WK_DtView2(0)("fin_date") & "に修正済みです。"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            If Not IsDBNull(WK_DtView2(0)("del_date")) Then
                msg.Text = "既に" & WK_DtView1(0)("name") & "さんが" & WK_DtView2(0)("del_date") & "に削除済みです。"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            fin_f = "1"
        End If

    End Sub
    Sub CK_Date01()     '申込日
        msg.Text = Nothing

        If Date01.Number = 0 Then
            msg.Text = "申込日の入力がありません。"
            Date01.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
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
    Sub CK_Edit04()     '氏名
        msg.Text = Nothing
        Edit04.Text = Trim(Edit04.Text)

        If Edit04.Text = Nothing Then
            msg.Text = "氏名の入力がありません。"
            Edit04.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit05()     'カナ
        msg.Text = Nothing
        Edit05.Text = Trim(Edit05.Text)

        'If Edit05.Text = Nothing Then
        '    msg.Text = "カナの入力がありません。"
        '    Edit05.BackColor = System.Drawing.Color.Red : Exit Sub
        'End If
        Edit05.BackColor = System.Drawing.SystemColors.Window
    End Sub
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

        If Edit02.Text = Nothing Then
            msg.Text = "住所の入力がありません。"
            Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    'Sub CK_CheckBox05() '推薦
    '    msg.Text = Nothing
    '    If CheckBox05.Checked = True Then
    '        Number02.Value = WK_SUI
    '        Date04.Text = Number1.Value & "/03/31"
    '    Else
    '        Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
    '        If cmb07.Text <> Nothing And Date02.Number <> 0 Then
    '            If CheckBox05.Checked = True Then
    '                Date04.Text = wrn_end_Get(cmb07.Text, Number1.Value & "/04/01")
    '            Else
    '                Date04.Text = wrn_end_Get(cmb07.Text, Date02.Text)
    '            End If
    '        Else
    '            Date04.Text = Nothing
    '        End If
    '    End If
    'End Sub
    Sub CK_Combo01()    '大学
        msg.Text = Nothing
        cmb01.Text = Nothing
        Combo01.Text = Trim(Combo01.Text)

        If Combo01.Text = Nothing Then
            msg.Text = "大学の入力がありません。"
            Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DtView1 = New DataView(DsCMB1.Tables("M01_univ"), "univ_name ='" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb01.Text = DtView1(0)("univ_code")
            Else
                msg.Text = "該当の大学はありません。"
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
            'If CheckBox05.Checked = True Then
            '    Number02.Value = WK_SUI
            'Else
            Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
            'End If

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
            Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
            If cmb07.Text <> Nothing And Date02.Number <> 0 Then
                If CheckBox05.Checked = True Then
                    Date04.Text = wrn_end_Get(cmb07.Text, Number1.Value & "/04/01")
                Else
                    Date04.Text = wrn_end_Get(cmb07.Text, Date02.Text)
                End If
            Else
                Date04.Text = Nothing
            End If

            br_cmb07.Text = Combo07.Text
        End If
        Combo07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo08()    '保証範囲
        msg.Text = Nothing
        Combo08.Text = Trim(Combo08.Text)

        If Combo08.Text <> br_cmb08.Text Then
            cmb08.Text = Nothing
            If Combo08.Text = Nothing Then
                msg.Text = "保証範囲の入力がありません。"
                Combo08.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("cls_HSY"), "cls_code_name ='" & Combo08.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb08.Text = DtView1(0)("cls_code")
                Else
                    msg.Text = "該当の保証範囲はありません。"
                    Combo08.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            'If CheckBox05.Checked = True Then
            '    Number02.Value = WK_SUI
            'Else
            Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
            'End If
            br_cmb08.Text = Combo08.Text
        End If
        Combo08.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date02()     '保証開始
        msg.Text = Nothing

        If Date02.Number = 0 Then
            msg.Text = "保証開始の入力がありません。"
            Date02.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        If cmb07.Text <> Nothing And Date02.Number <> 0 Then
            If CheckBox05.Checked = True Then
                Date04.Text = wrn_end_Get(cmb07.Text, Number1.Value & "/04/01")
            Else
                Date04.Text = wrn_end_Get(cmb07.Text, Date02.Text)
            End If
        Else
            Date04.Text = Nothing
        End If

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
            'If CheckBox05.Checked = True Then
            '    Number02.Value = WK_SUI
            'Else
            Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
            'End If
            br_cmb09.Text = Combo09.Text
        End If
        Combo09.BackColor = System.Drawing.SystemColors.Window
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
        Call CK_Edit04()    '氏名
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Call CK_Edit05()    'カナ
    End Sub
    Private Sub Mask01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask01.LostFocus
        Call CK_Mask01()    '郵便番号
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CK_Edit02()    '住所1
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
    Private Sub Combo07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo07.LostFocus
        Call CK_Combo07()   '保証期間
    End Sub
    Private Sub Combo08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo08.LostFocus
        Call CK_Combo08()   '保証範囲
    End Sub
    Private Sub Date02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date02.LostFocus
        Call CK_Date02()   '保証開始
    End Sub
    Private Sub Date04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date04.LostFocus
        Call CK_Date04()   '終期
    End Sub
    Private Sub Combo09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.LostFocus
        Call CK_Combo09()   '販売店
    End Sub
    Private Sub CheckBox04_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox04.CheckedChanged
        Call CK_CheckBox04() 'シリアル番号連絡待ち
    End Sub
    Private Sub CheckBox05_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox05.CheckedChanged
        'Call CK_CheckBox05() '推薦
        If CheckBox05.Checked = False Then
            CheckBox1.Checked = False
        End If
    End Sub

    '******************************************************************
    '** TextChanged
    '******************************************************************
    Private Sub Number02_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.TextChanged
        Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)
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
    '** 更新
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then

            Call CK_daburi()    '重複チェック（大学名と氏名）
            If r <> 0 Then
                ANS = MessageBox.Show("大学名と氏名で既に入力済みですが" & System.Environment.NewLine & "登録してよろしいですか", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then Cursor = System.Windows.Forms.Cursors.Default : Exit Sub 'いいえ
            End If

            Select Case cmb08.Text
                Case Is = "7"           '延長保証
                    WK_code = Count_Get("A" & Mid(Number1.Text, Len(Number1.Text), 1) & "03")       '延長保証
                Case Is = "11", "12", "17", "18"    'セーフティプラス、セーフティⅡプラス、フラットプラス、フラットⅡプラス
                    WK_code = Count_Get("M" & Mid(Number1.Text, Len(Number1.Text), 1) & "01")
                Case Else
                    If Label02.Visible = True Then
                        WK_code = Count_Get("E" & Mid(Number1.Text, Len(Number1.Text), 1) & "01")   '一般
                    Else
                        WK_code = Count_Get("A" & Mid(Number1.Text, Len(Number1.Text), 1) & "01")
                    End If
            End Select
            Edit01.Text = WK_code

            strSQL = "INSERT INTO T01_member"
            strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1, adrs2"
            strSQL += ", tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt, wrn_tem"
            strSQL += ", makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee, tax_rate"
            '↓↓↓↓↓↓ 2021/10/15 修正
            'strSQL += ", Part_prt, Part_prt_bak, tonan_flg, zenson_flg, suisen_flg, souki_flg, memo, imp_seq, nendo"
            strSQL += ", Part_prt, Part_prt_bak, tonan_flg, zenson_flg, suisen_flg, souki_flg, memo, pc_pack, imp_seq, nendo"
            '↑↑↑↑↑↑ 2021/10/15 修正
            strSQL += ", reg_date, delt_flg)"
            strSQL += " VALUES ('" & WK_code & "'"                      '加入番号
            strSQL += ", '" & Edit04.Text & "'"                         '氏名
            S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
            strSQL += ", '" & S_Edit04 & "'"                            '検索用氏名
            strSQL += ", '" & Edit05.Text & "'"                         'カナ
            S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
            strSQL += ", '" & S_Edit05 & "'"                            '検索用カナ
            strSQL += ", '" & Mask01.Value & "'"                        '郵便番号
            strSQL += ", '" & Edit02.Text & "'"                         '住所1
            strSQL += ", '" & Edit03.Text & "'"                         '住所2
            strSQL += ", '" & Edit06.Text & "'"                         '電話番号
            strSQL += ", " & cmb01.Text                                 '大学
            strSQL += ", '" & Combo02.Text & "'"                        '学部
            strSQL += ", '" & Combo03.Text & "'"                        '学科
            strSQL += ", '" & cmb05.Text & "'"                          'メーカー
            strSQL += ", '" & Combo06.Text & "'"                        '商品名
            strSQL += ", '" & Edit07.Text & "'"                         'シリアル№
            strSQL += ", " & Number01.Value                             '購入価格
            strSQL += ", '" & cmb07.Text & "'"                          '保証期間
            If CheckBox05.Checked = True Then
                WK_date = Number1.Value & "/04/01"
            Else
                WK_date = Date02.Text
            End If
            strSQL += ", CONVERT(DATETIME, '" & WK_date & "', 102)"     '保証開始日
            strSQL += ", CONVERT(DATETIME, '" & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, CInt(cmb07.Text), WK_date)) & "', 102)"     '終期
            strSQL += ", " & cmb08.Text                                 '保証範囲
            strSQL += ", " & cmb09.Text                                 '販売店
            strSQL += ", '" & Edit09.Text & "'"                         '販売員
            strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)" '申込日
            strSQL += ", " & Number02.Value                             '加入料金(税別)
            strSQL += ", " & tax_rate.Text                              '消費税率
            strSQL += ", 0"                                             '加入証印刷
            strSQL += ", 0"                                             '加入証戻り
            strSQL += ", 0"                                             '盗難
            strSQL += ", 0"                                             '全損
            strSQL += ", 0"                                             '推薦
            strSQL += ", 0"                                             '早期
            strSQL += ", '" & Edit08.Text & "'"                         'メモ
            '↓↓↓↓↓↓ 2021/10/15 修正
            If CheckBox06.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" 'PCパック申込者確認
            '↑↑↑↑↑↑ 2021/10/15 修正
            strSQL += ", " & imp_seq.Value                              '取込み№
            strSQL += ", " & Number1.Value                              '年度
            strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"    '登録日
            strSQL += ", 0)"                                            '削除ﾌﾗｸﾞ
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()

            'シリアル№待ち
            If CheckBox04.Checked = True Then
                strSQL = "INSERT INTO T03_s_no_wait"
                strSQL += " (code, s_no_wait)"
                strSQL += " VALUES ('" & WK_code & "'"
                strSQL += ", 1)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If
            DB_CLOSE()

            '************************************
            '** 推薦
            '************************************
            If CheckBox05.Checked = True Then

                WK_code = Count_Get("A" & Mid(Number1.Text, Len(Number1.Text), 1) & "03")       '延長保証
                'Edit01.Text = WK_code

                strSQL = "INSERT INTO T01_member"
                strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1, adrs2"
                strSQL += ", tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt, wrn_tem"
                strSQL += ", makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee, tax_rate"
                strSQL += ", Part_prt, Part_prt_bak, tonan_flg, zenson_flg, suisen_flg, souki_flg, memo, imp_seq, nendo"
                strSQL += ", reg_date, delt_flg)"
                strSQL += " VALUES ('" & WK_code & "'"                      '加入番号
                strSQL += ", '" & Edit04.Text & "'"                         '氏名
                S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
                strSQL += ", '" & S_Edit04 & "'"                            '検索用氏名
                strSQL += ", '" & Edit05.Text & "'"                         'カナ
                S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
                strSQL += ", '" & S_Edit05 & "'"                            '検索用カナ
                strSQL += ", '" & Mask01.Value & "'"                        '郵便番号
                strSQL += ", '" & Edit02.Text & "'"                         '住所1
                strSQL += ", '" & Edit03.Text & "'"                         '住所2
                strSQL += ", '" & Edit06.Text & "'"                         '電話番号
                strSQL += ", " & cmb01.Text                                 '大学
                strSQL += ", '" & Combo02.Text & "'"                        '学部
                strSQL += ", '" & Combo03.Text & "'"                        '学科
                strSQL += ", '" & cmb05.Text & "'"                          'メーカー
                strSQL += ", '" & Combo06.Text & "'"                        '商品名
                strSQL += ", '" & Edit07.Text & "'"                         'シリアル№
                strSQL += ", " & Number01.Value                             '購入価格
                strSQL += ", '" & cmb07.Text & "'"                          '保証期間
                strSQL += ", CONVERT(DATETIME, '" & Date02.Text & "', 102)" '保証開始日
                strSQL += ", CONVERT(DATETIME, '" & Number1.Value & "/03/31', 102)" '終期
                strSQL += ", 7"                                             '保証範囲
                strSQL += ", " & cmb09.Text                                 '販売店
                strSQL += ", '" & Edit09.Text & "'"                         '販売員
                strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)" '申込日
                strSQL += ", " & WK_SUI                                     '加入料金(税別)
                strSQL += ", " & tax_rate.Text                              '消費税率
                strSQL += ", 0"                                             '加入証印刷
                strSQL += ", 0"                                             '加入証戻り
                strSQL += ", 0"                                             '盗難
                strSQL += ", 0"                                             '全損
                strSQL += ", 1"                                             '推薦
                strSQL += ", 0"                                             '早期
                strSQL += ", '" & Edit08.Text & "'"                         'メモ
                If imp_seq2.Value = 0 Then
                    imp_seq2.Value = Count_Get2("IMP")

                    strSQL2 = "UPDATE E01_member"
                    strSQL2 = strSQL2 & " SET imp_seq2 = " & imp_seq2.Value
                    strSQL2 = strSQL2 & " WHERE (imp_seq = " & imp_seq.Value & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL2, cnsqlclient)
                    DB_OPEN("nQGCare")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If
                strSQL += ", " & imp_seq2.Value
                strSQL += ", " & Number1.Value                              '年度
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"    '登録日
                strSQL += ", 0)"                                            '削除ﾌﾗｸﾞ
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()

                'シリアル№待ち
                If CheckBox04.Checked = True Then
                    strSQL = "INSERT INTO T03_s_no_wait"
                    strSQL += " (code, s_no_wait)"
                    strSQL += " VALUES ('" & WK_code & "'"
                    strSQL += ", 1)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                End If
                DB_CLOSE()
            End If

            '************************************
            '** 早期
            '************************************
            If CheckBox05.Checked = True Then

                '保証期間
                WK_str2 = cmb07.Text

                '保証開始終了
                WK_date = Number1.Value & "/04/01"
                fr_date = DateAdd(DateInterval.Year, CInt(WK_str2) - 1, WK_date)
                to_date = Number1.Value + CInt(WK_str2) & "/03/31'"

                'WK_code2 = Count_Get("A" & Mid(Number1.Text, Len(Number1.Text), 1) & "03")       '延長保証
                WK_code2 = Count_Get("A" & Mid(fr_date, 4, 1) & "03")

                strSQL = "INSERT INTO T01_member"
                strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1, adrs2"
                strSQL += ", tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt, wrn_tem"
                strSQL += ", makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee, tax_rate"
                strSQL += ", Part_prt, Part_prt_bak, tonan_flg, zenson_flg, suisen_flg, souki_flg, memo, imp_seq, nendo"
                strSQL += ", reg_date, delt_flg)"
                strSQL += " VALUES ('" & WK_code2 & "'"                     '加入番号
                strSQL += ", '" & Edit04.Text & "'"                         '氏名
                S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
                strSQL += ", '" & S_Edit04 & "'"                            '検索用氏名
                strSQL += ", '" & Edit05.Text & "'"                         'カナ
                S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
                strSQL += ", '" & S_Edit05 & "'"                            '検索用カナ
                strSQL += ", '" & Mask01.Value & "'"                        '郵便番号
                strSQL += ", '" & Edit02.Text & "'"                         '住所1
                strSQL += ", '" & Edit03.Text & "'"                         '住所2
                strSQL += ", '" & Edit06.Text & "'"                         '電話番号
                strSQL += ", " & cmb01.Text                                 '大学
                strSQL += ", '" & Combo02.Text & "'"                        '学部
                strSQL += ", '" & Combo03.Text & "'"                        '学科
                strSQL += ", '" & cmb05.Text & "'"                          'メーカー
                strSQL += ", '" & Combo06.Text & "'"                        '商品名
                strSQL += ", '" & Edit07.Text & "'"                         'シリアル№
                strSQL += ", " & Number01.Value                             '購入価格
                strSQL += ", '" & cmb07.Text & "'"                          '保証期間
                'strSQL += ", CONVERT(DATETIME, '" & Date02.Text & "', 102)" '保証開始日
                'strSQL += ", CONVERT(DATETIME, '" & Number1.Value & "/03/31', 102)" '終期
                strSQL += ", CONVERT(DATETIME, '" & fr_date & "', 102)"     '保証開始日
                strSQL += ", CONVERT(DATETIME, '" & to_date & "', 102)"     '終期
                strSQL += ", 7"                                             '保証範囲
                strSQL += ", " & cmb09.Text                                 '販売店
                strSQL += ", '" & Edit09.Text & "'"                         '販売員
                strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)" '申込日
                strSQL += ", " & WK_sou                                     '加入料金(税別)
                strSQL += ", " & tax_rate.Text                              '消費税率
                strSQL += ", 0"                                             '加入証印刷
                strSQL += ", 0"                                             '加入証戻り
                strSQL += ", 0"                                             '盗難
                strSQL += ", 0"                                             '全損
                strSQL += ", 0"                                             '推薦
                strSQL += ", 1"                                             '早期
                strSQL += ", '" & Edit08.Text & "'"                         'メモ
                If imp_seq3.Value = 0 Then
                    imp_seq3.Value = Count_Get2("IMP")

                    strSQL2 = "UPDATE E01_member"
                    strSQL2 = strSQL2 & " SET imp_seq3 = " & imp_seq3.Value
                    strSQL2 = strSQL2 & " WHERE (imp_seq = " & imp_seq.Value & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL2, cnsqlclient)
                    DB_OPEN("nQGCare")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If
                strSQL += ", " & imp_seq3.Value
                strSQL += ", " & Number1.Value                              '年度
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"    '登録日
                strSQL += ", 0)"                                            '削除ﾌﾗｸﾞ
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()

                'シリアル№待ち
                If CheckBox04.Checked = True Then
                    strSQL = "INSERT INTO T03_s_no_wait"
                    strSQL += " (code, s_no_wait)"
                    strSQL += " VALUES ('" & WK_code2 & "'"
                    strSQL += ", 1)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                End If
                DB_CLOSE()
            End If

            strSQL = "UPDATE E01_member"
            strSQL += " SET fin_date = CONVERT(DATETIME, '" & Now & "', 102)"
            strSQL += ", fin_empl_code = " & P_EMPL_NO
            strSQL += " WHERE (id = " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            P_RTN = "1"
            DsList1.Clear()

            If CheckBox1.Checked = True Then
                MessageBox.Show("加入番号：" & Edit01.Text & " 推薦：" & WK_code & " 早期：" & WK_code2 & " で登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If CheckBox05.Checked = True Then
                    MessageBox.Show("加入番号：" & Edit01.Text & " 推薦：" & WK_code & " で登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("加入番号：" & Edit01.Text & " で登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 削除
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Err_F = "0"

        Call CK_fin()       '既に処理済
        If msg.Text <> Nothing Then Err_F = "1" : Exit Sub

        ANS = MessageBox.Show("削除してよろしいですか", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If ANS = "2" Then Exit Sub 'いいえ
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        strSQL = "UPDATE E01_member"
        strSQL += " SET del_date = CONVERT(DATETIME, '" & Now & "', 102)"
        strSQL += ", fin_empl_code = " & P_EMPL_NO
        strSQL += " WHERE (id = " & P_PRAM1 & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DB_OPEN("nQGCare")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        P_RTN = "1"
        DsList1.Clear()
        MessageBox.Show("削除しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Close()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        If fin_f = "1" Then
            P_RTN = "1"     '既に処理済
        Else
            P_RTN = "0"
        End If
        DsList1.Clear()
        Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox05.Checked = True
        End If
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
