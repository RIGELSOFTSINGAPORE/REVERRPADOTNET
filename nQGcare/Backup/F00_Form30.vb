Public Class F00_Form30
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, inz_F, WK_str As String
    Dim i, r As Integer

    Dim S_Edit04, S_Edit05 As String

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Date
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents br_imp_seq As System.Windows.Forms.Label
    Friend WithEvents br_Date02 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Date
    Friend WithEvents br_Date01 As System.Windows.Forms.Label
    Friend WithEvents br_cmb09 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents imp_seq As GrapeCity.Win.Input.Edit
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents br_Edit01 As System.Windows.Forms.Label
    Friend WithEvents br_Edit06 As System.Windows.Forms.Label
    Friend WithEvents br_Edit04 As System.Windows.Forms.Label
    Friend WithEvents br_Edit05 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Date
        Me.Combo09 = New GrapeCity.Win.Input.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.msg = New System.Windows.Forms.Label
        Me.br_imp_seq = New System.Windows.Forms.Label
        Me.br_Date02 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Date
        Me.br_Date01 = New System.Windows.Forms.Label
        Me.br_cmb09 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.imp_seq = New GrapeCity.Win.Input.Edit
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Edit06 = New GrapeCity.Win.Input.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit05 = New GrapeCity.Win.Input.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Edit
        Me.Edit01 = New GrapeCity.Win.Input.Edit
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.br_Edit01 = New System.Windows.Forms.Label
        Me.br_Edit06 = New System.Windows.Forms.Label
        Me.br_Edit04 = New System.Windows.Forms.Label
        Me.br_Edit05 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(644, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 1470
        Me.Label2.Text = "取込み№"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(420, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 1469
        Me.Label1.Text = "登録日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(532, 12)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1464
        Me.Date01.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(724, 40)
        Me.Combo09.MaxDropDownItems = 35
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(272, 24)
        Me.Combo09.TabIndex = 1462
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(644, 40)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 24)
        Me.Label23.TabIndex = 1468
        Me.Label23.Text = "取扱店"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn1})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Print01"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(11, 72)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(980, 572)
        Me.DataGrid1.TabIndex = 1463
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid1.TabStop = False
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "加入番号"
        Me.DataGridTextBoxColumn5.MappingName = "code"
        Me.DataGridTextBoxColumn5.Width = 85
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "氏名"
        Me.DataGridTextBoxColumn6.MappingName = "user_name"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 99
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "氏名カナ"
        Me.DataGridTextBoxColumn7.MappingName = "use_name_kana"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 99
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn8.MappingName = "tel"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.Width = 105
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "登録日"
        Me.DataGridTextBoxColumn2.MappingName = "reg_date"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 85
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "加入証印刷日"
        Me.DataGridTextBoxColumn3.MappingName = "Part_prt_date"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 105
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "取込み№"
        Me.DataGridTextBoxColumn4.MappingName = "imp_seq"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 70
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "取扱店"
        Me.DataGridTextBoxColumn1.MappingName = "shop_name"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 290
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 652)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(772, 28)
        Me.msg.TabIndex = 1477
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'br_imp_seq
        '
        Me.br_imp_seq.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_imp_seq.Location = New System.Drawing.Point(728, -4)
        Me.br_imp_seq.Name = "br_imp_seq"
        Me.br_imp_seq.Size = New System.Drawing.Size(116, 16)
        Me.br_imp_seq.TabIndex = 1476
        Me.br_imp_seq.Text = "br_imp_seq"
        Me.br_imp_seq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.br_imp_seq.Visible = False
        '
        'br_Date02
        '
        Me.br_Date02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date02.Location = New System.Drawing.Point(532, 64)
        Me.br_Date02.Name = "br_Date02"
        Me.br_Date02.Size = New System.Drawing.Size(100, 16)
        Me.br_Date02.TabIndex = 1475
        Me.br_Date02.Text = "br_Date02"
        Me.br_Date02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date02.Visible = False
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(532, 40)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 1465
        Me.Date02.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'br_Date01
        '
        Me.br_Date01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date01.Location = New System.Drawing.Point(532, 0)
        Me.br_Date01.Name = "br_Date01"
        Me.br_Date01.Size = New System.Drawing.Size(100, 16)
        Me.br_Date01.TabIndex = 1474
        Me.br_Date01.Text = "br_Date01"
        Me.br_Date01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date01.Visible = False
        '
        'br_cmb09
        '
        Me.br_cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb09.Location = New System.Drawing.Point(724, 64)
        Me.br_cmb09.Name = "br_cmb09"
        Me.br_cmb09.Size = New System.Drawing.Size(156, 16)
        Me.br_cmb09.TabIndex = 1473
        Me.br_cmb09.Text = "br_cmb09"
        Me.br_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb09.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(944, 24)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1472
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'imp_seq
        '
        Me.imp_seq.AllowSpace = False
        Me.imp_seq.Format = "9"
        Me.imp_seq.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.imp_seq.Location = New System.Drawing.Point(724, 12)
        Me.imp_seq.MaxLength = 7
        Me.imp_seq.Name = "imp_seq"
        Me.imp_seq.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.imp_seq.Size = New System.Drawing.Size(124, 24)
        Me.imp_seq.TabIndex = 1466
        Me.imp_seq.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Right
        Me.imp_seq.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(919, 653)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 1467
        Me.Button99.Text = "閉じる"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 24)
        Me.Label8.TabIndex = 1483
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
        Me.Edit06.Location = New System.Drawing.Point(92, 40)
        Me.Edit06.MaxLength = 20
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(104, 24)
        Me.Edit06.TabIndex = 1480
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(204, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 24)
        Me.Label6.TabIndex = 1482
        Me.Label6.Text = "カナ"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(204, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 24)
        Me.Label7.TabIndex = 1481
        Me.Label7.Text = "氏名"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit05
        '
        Me.Edit05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(252, 40)
        Me.Edit05.MaxLength = 50
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(160, 24)
        Me.Edit05.TabIndex = 1479
        Me.Edit05.Text = "Edit05"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(252, 12)
        Me.Edit04.MaxLength = 50
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(160, 24)
        Me.Edit04.TabIndex = 1478
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit01
        '
        Me.Edit01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.Format = "A9#"
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(92, 12)
        Me.Edit01.MaxLength = 10
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(104, 24)
        Me.Edit01.TabIndex = 1485
        Me.Edit01.TabStop = False
        Me.Edit01.Text = "EDIT01"
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 24)
        Me.Label4.TabIndex = 1484
        Me.Label4.Text = "加入番号"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(420, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 24)
        Me.Label5.TabIndex = 1486
        Me.Label5.Text = "加入証印刷日"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'br_Edit01
        '
        Me.br_Edit01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Edit01.Location = New System.Drawing.Point(92, 0)
        Me.br_Edit01.Name = "br_Edit01"
        Me.br_Edit01.Size = New System.Drawing.Size(100, 16)
        Me.br_Edit01.TabIndex = 1487
        Me.br_Edit01.Text = "br_Edit01"
        Me.br_Edit01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Edit01.Visible = False
        '
        'br_Edit06
        '
        Me.br_Edit06.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Edit06.Location = New System.Drawing.Point(92, 64)
        Me.br_Edit06.Name = "br_Edit06"
        Me.br_Edit06.Size = New System.Drawing.Size(100, 16)
        Me.br_Edit06.TabIndex = 1488
        Me.br_Edit06.Text = "br_Edit06"
        Me.br_Edit06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Edit06.Visible = False
        '
        'br_Edit04
        '
        Me.br_Edit04.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Edit04.Location = New System.Drawing.Point(252, 0)
        Me.br_Edit04.Name = "br_Edit04"
        Me.br_Edit04.Size = New System.Drawing.Size(100, 16)
        Me.br_Edit04.TabIndex = 1489
        Me.br_Edit04.Text = "br_Edit04"
        Me.br_Edit04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Edit04.Visible = False
        '
        'br_Edit05
        '
        Me.br_Edit05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Edit05.Location = New System.Drawing.Point(252, 64)
        Me.br_Edit05.Name = "br_Edit05"
        Me.br_Edit05.Size = New System.Drawing.Size(100, 16)
        Me.br_Edit05.TabIndex = 1490
        Me.br_Edit05.Text = "br_Edit05"
        Me.br_Edit05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Edit05.Visible = False
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(816, 652)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 28)
        Me.Button5.TabIndex = 1491
        Me.Button5.Text = "印刷"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(908, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 1492
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'F00_Form30
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.br_Edit05)
        Me.Controls.Add(Me.br_Edit04)
        Me.Controls.Add(Me.br_Edit06)
        Me.Controls.Add(Me.br_Edit01)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.br_imp_seq)
        Me.Controls.Add(Me.br_Date02)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.br_Date01)
        Me.Controls.Add(Me.br_cmb09)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.imp_seq)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form30"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入証印刷"
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form30_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        inz_F = "1"
        Call sql()      '** SQL
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing
        Button5.Enabled = False

        Edit01.Text = Nothing : br_Edit01.Text = Nothing
        Edit04.Text = Nothing : br_Edit04.Text = Nothing
        Edit05.Text = Nothing : br_Edit05.Text = Nothing
        Edit06.Text = Nothing : br_Edit06.Text = Nothing
        Combo09.Text = Nothing : cmb09.Text = Nothing : br_cmb09.Text = Nothing
        Date01.Number = 0 : br_Date01.Text = Nothing
        Date02.Number = 0 : br_Date02.Text = Nothing
        imp_seq.Text = Nothing : br_imp_seq.Text = Nothing

    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()

        '販売店
        strSQL = "SELECT shop_code, shop_name, ittpan FROM M04_shop WHERE (shop_code <> 0) AND (delt_flg = 0) ORDER BY shop_name_kana, shop_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsCMB1, "M04_shop")
        DB_CLOSE()
        Combo09.DataSource = DsCMB1.Tables("M04_shop")
        Combo09.DisplayMember = "shop_name"
        Combo09.ValueMember = "shop_code"
        Combo09.Text = Nothing
        Combo09.SelectedIndex = -1

    End Sub

    '********************************************************************
    '** SQL
    '********************************************************************
    Sub sql()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If inz_F = "1" Then

            P_DsPRT.Clear()
            strSQL = "SELECT T01_member.*, M04_shop.shop_name, V_M02_HSK.cls_code_name AS wrn_tem_name"
            strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name, M05_VNDR.name AS makr_name, M01_univ.univ_name"
            strSQL += " FROM T01_member INNER JOIN"
            strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code LEFT OUTER JOIN"
            strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
            strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
            strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code LEFT OUTER JOIN"
            strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code LEFT OUTER JOIN"
            strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code"
            strSQL += " WHERE (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ") AND (T05_iPad.code IS NULL)"
            If Edit01.Text <> Nothing Then strSQL += " AND (T01_member.code = '" & Edit01.Text & "')"
            If Edit04.Text <> Nothing Then
                S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
                strSQL += " AND (T01_member.user_name_search LIKE '%" & S_Edit04 & "%')"
            End If
            If Edit05.Text <> Nothing Then
                S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
                strSQL += " AND (T01_member.use_name_kana_search LIKE '%" & S_Edit05 & "%')"
            End If
            If Edit06.Text <> Nothing Then strSQL += " AND (T01_member.tel LIKE '%" & Edit06.Text & "%')"
            If Date01.Number <> 0 Then strSQL += " AND (T01_member.reg_date = CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then strSQL += " AND (T01_member.part_prt_date = CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If imp_seq.Text <> Nothing Then strSQL += " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
            If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(P_DsPRT, "Print01")
            DB_CLOSE()
            If r = 0 Then msg.Text = "対象データなし" : Button5.Enabled = False Else msg.Text = Nothing : Button5.Enabled = True
            Label3.Text = Format(r, "##,##0") & "件"

            Dim tbl1 As New DataTable
            tbl1 = P_DsPRT.Tables("Print01")
            DataGrid1.DataSource = tbl1

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        If Edit01.Text <> br_Edit01.Text Then
            Call sql()      '** SQL
            br_Edit01.Text = Edit01.Text
        End If
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        If Edit04.Text <> br_Edit04.Text Then
            Call sql()      '** SQL
            br_Edit04.Text = Edit04.Text
        End If
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        If Edit05.Text <> br_Edit05.Text Then
            Call sql()      '** SQL
            br_Edit05.Text = Edit05.Text
        End If
    End Sub
    Private Sub Edit06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.LostFocus
        If Edit06.Text <> br_Edit06.Text Then
            Call sql()      '** SQL
            br_Edit06.Text = Edit06.Text
        End If
    End Sub
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        If Date01.Text <> br_Date01.Text Then
            Call sql()      '** SQL
            br_Date01.Text = Date01.Text
        End If
    End Sub
    Private Sub Date02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date02.LostFocus
        If Date02.Text <> br_Date02.Text Then
            Call sql()      '** SQL
            br_Date02.Text = Date02.Text
        End If
    End Sub
    Private Sub imp_seq_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles imp_seq.LostFocus
        imp_seq.Text = Trim(imp_seq.Text)
        If imp_seq.Text <> br_imp_seq.Text Then
            Call sql()      '** SQL
            br_imp_seq.Text = imp_seq.Text
        End If
    End Sub
    Private Sub Combo09_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.TextChanged
        Combo09.Text = Trim(Combo09.Text)
        If Combo09.Text <> br_cmb09.Text Then
            Call sql()      '** SQL
            br_cmb09.Text = Combo09.Text
        End If
    End Sub
    Private Sub Combo09_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.SelectedIndexChanged
        Combo09.Text = Trim(Combo09.Text)
        If Combo09.Text <> br_cmb09.Text Then
            Call sql()      '** SQL
            br_cmb09.Text = Combo09.Text
        End If
    End Sub

    '******************************************************************
    '** 印刷
    '******************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1

                DtView1(i)("user_name") = DtView1(i)("user_name") & "　様"
                If Not IsDBNull(DtView1(i)("shop_name")) Then

                    WK_str = Trim(DtView1(i)("shop_name"))
                    WK_str = WK_str.Replace(" ", System.Environment.NewLine)
                    WK_str = WK_str.Replace("　", System.Environment.NewLine)
                    DtView1(i)("shop_name") = WK_str
                End If
            Next
        End If

        PRT_PRAM1 = "R_Kanyu_Normal"

        Dim Print_View As New Print_View
        Print_View.ShowDialog()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_DsPRT.Clear()
        DsCMB1.Clear()
        Close()
    End Sub
End Class
