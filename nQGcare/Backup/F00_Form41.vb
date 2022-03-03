Public Class F00_Form41
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
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, str_WH(3), Err_F, WK_str, strFile, strData As String
    Dim i, j, r, n As Integer

    Dim BR_str As String
    Dim txt1, txt2, txt3, txt4, txt5 As String
    Dim txt11, txt12, txt13 As String
    Dim txt14, txt15, txt16 As Integer
    Dim txt21, txt22, txt23 As String
    Dim txt24, txt25, txt26 As Integer
    Dim txt31, txt32, txt33 As String
    Dim txt34, txt35, txt36 As Integer
    Dim txt41, txt42, txt43 As String
    Dim txt44, txt45, txt46 As Integer
    Dim txt51, txt52, txt53 As String
    Dim txt54, txt55, txt56 As Integer
    Dim txt61, txt62, txt63 As String
    Dim txt64, txt65, txt66 As Integer
    Dim txt74, txt76 As Integer

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
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents imp_seq2 As GrapeCity.Win.Input.Edit
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents br_imp_seq As System.Windows.Forms.Label
    Friend WithEvents br_Date02 As System.Windows.Forms.Label
    Friend WithEvents br_Date01 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Date
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents br_imp_seq3 As System.Windows.Forms.Label
    Friend WithEvents br_imp_seq2 As System.Windows.Forms.Label
    Friend WithEvents br_cmb09 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents imp_seq As GrapeCity.Win.Input.Edit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox05 As System.Windows.Forms.CheckBox
    Friend WithEvents imp_seq3 As GrapeCity.Win.Input.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Date
        Me.Combo09 = New GrapeCity.Win.Input.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.imp_seq2 = New GrapeCity.Win.Input.Edit
        Me.msg = New System.Windows.Forms.Label
        Me.br_imp_seq = New System.Windows.Forms.Label
        Me.br_Date02 = New System.Windows.Forms.Label
        Me.br_Date01 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Date
        Me.Button4 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.br_imp_seq3 = New System.Windows.Forms.Label
        Me.br_imp_seq2 = New System.Windows.Forms.Label
        Me.br_cmb09 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.imp_seq = New GrapeCity.Win.Input.Edit
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox05 = New System.Windows.Forms.CheckBox
        Me.imp_seq3 = New GrapeCity.Win.Input.Edit
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imp_seq2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imp_seq3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(635, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 1483
        Me.Label2.Text = "取込み№"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(459, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 1482
        Me.Label1.Text = "登録日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(523, 3)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1469
        Me.Date01.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Combo09
        '
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(95, 3)
        Me.Combo09.MaxDropDownItems = 35
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(356, 24)
        Me.Combo09.TabIndex = 1468
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(11, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 24)
        Me.Label23.TabIndex = 1481
        Me.Label23.Text = "取扱店"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(495, 651)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 28)
        Me.Button3.TabIndex = 1476
        Me.Button3.Text = "加入者リスト"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(919, 651)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 1480
        Me.Button99.Text = "閉じる"
        '
        'imp_seq2
        '
        Me.imp_seq2.AllowSpace = False
        Me.imp_seq2.Format = "9"
        Me.imp_seq2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.imp_seq2.Location = New System.Drawing.Point(715, 27)
        Me.imp_seq2.MaxLength = 7
        Me.imp_seq2.Name = "imp_seq2"
        Me.imp_seq2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.imp_seq2.Size = New System.Drawing.Size(124, 24)
        Me.imp_seq2.TabIndex = 1472
        Me.imp_seq2.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Right
        Me.imp_seq2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(11, 651)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(480, 28)
        Me.msg.TabIndex = 1490
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'br_imp_seq
        '
        Me.br_imp_seq.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_imp_seq.Location = New System.Drawing.Point(851, 31)
        Me.br_imp_seq.Name = "br_imp_seq"
        Me.br_imp_seq.Size = New System.Drawing.Size(92, 16)
        Me.br_imp_seq.TabIndex = 1489
        Me.br_imp_seq.Text = "br_imp_seq"
        Me.br_imp_seq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.br_imp_seq.Visible = False
        '
        'br_Date02
        '
        Me.br_Date02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date02.Location = New System.Drawing.Point(527, 55)
        Me.br_Date02.Name = "br_Date02"
        Me.br_Date02.Size = New System.Drawing.Size(100, 16)
        Me.br_Date02.TabIndex = 1488
        Me.br_Date02.Text = "br_Date02"
        Me.br_Date02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date02.Visible = False
        '
        'br_Date01
        '
        Me.br_Date01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date01.Location = New System.Drawing.Point(415, 55)
        Me.br_Date01.Name = "br_Date01"
        Me.br_Date01.Size = New System.Drawing.Size(100, 16)
        Me.br_Date01.TabIndex = 1487
        Me.br_Date01.Text = "br_Date01"
        Me.br_Date01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date01.Visible = False
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(523, 27)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 1470
        Me.Date02.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button4.Location = New System.Drawing.Point(631, 651)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 28)
        Me.Button4.TabIndex = 1477
        Me.Button4.Text = "ネバ伝"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridBoolColumn1, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T01_member"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = "##,##0"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "件数"
        Me.DataGridTextBoxColumn1.MappingName = "cnt"
        Me.DataGridTextBoxColumn1.Width = 110
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.MappingName = "shop_code"
        Me.DataGridTextBoxColumn2.Width = 0
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(11, 83)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(980, 560)
        Me.DataGrid1.TabIndex = 1475
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid1.TabStop = False
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "取扱店"
        Me.DataGridTextBoxColumn4.MappingName = "shop_name"
        Me.DataGridTextBoxColumn4.Width = 300
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "登録日"
        Me.DataGridTextBoxColumn5.MappingName = "reg_date"
        Me.DataGridTextBoxColumn5.Width = 110
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "取込み№"
        Me.DataGridTextBoxColumn6.MappingName = "imp_seq"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "推薦"
        Me.DataGridBoolColumn1.MappingName = "suisen_flg"
        Me.DataGridBoolColumn1.NullText = "False"
        Me.DataGridBoolColumn1.NullValue = "False"
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 75
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button6.Location = New System.Drawing.Point(823, 651)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 28)
        Me.Button6.TabIndex = 1479
        Me.Button6.Text = "CSV出力"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button5.Location = New System.Drawing.Point(727, 651)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 28)
        Me.Button5.TabIndex = 1478
        Me.Button5.Text = "確認表"
        '
        'br_imp_seq3
        '
        Me.br_imp_seq3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_imp_seq3.Location = New System.Drawing.Point(851, 63)
        Me.br_imp_seq3.Name = "br_imp_seq3"
        Me.br_imp_seq3.Size = New System.Drawing.Size(92, 16)
        Me.br_imp_seq3.TabIndex = 1492
        Me.br_imp_seq3.Text = "br_imp_seq3"
        Me.br_imp_seq3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.br_imp_seq3.Visible = False
        '
        'br_imp_seq2
        '
        Me.br_imp_seq2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_imp_seq2.Location = New System.Drawing.Point(851, 47)
        Me.br_imp_seq2.Name = "br_imp_seq2"
        Me.br_imp_seq2.Size = New System.Drawing.Size(92, 16)
        Me.br_imp_seq2.TabIndex = 1491
        Me.br_imp_seq2.Text = "br_imp_seq2"
        Me.br_imp_seq2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.br_imp_seq2.Visible = False
        '
        'br_cmb09
        '
        Me.br_cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb09.Location = New System.Drawing.Point(95, 27)
        Me.br_cmb09.Name = "br_cmb09"
        Me.br_cmb09.Size = New System.Drawing.Size(356, 16)
        Me.br_cmb09.TabIndex = 1486
        Me.br_cmb09.Text = "br_cmb09"
        Me.br_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb09.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(327, 47)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1485
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'imp_seq
        '
        Me.imp_seq.AllowSpace = False
        Me.imp_seq.Format = "9"
        Me.imp_seq.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.imp_seq.Location = New System.Drawing.Point(715, 3)
        Me.imp_seq.MaxLength = 7
        Me.imp_seq.Name = "imp_seq"
        Me.imp_seq.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.imp_seq.Size = New System.Drawing.Size(124, 24)
        Me.imp_seq.TabIndex = 1471
        Me.imp_seq.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Right
        Me.imp_seq.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(495, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 24)
        Me.Label3.TabIndex = 1484
        Me.Label3.Text = "～"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox05
        '
        Me.CheckBox05.Location = New System.Drawing.Point(859, 3)
        Me.CheckBox05.Name = "CheckBox05"
        Me.CheckBox05.Size = New System.Drawing.Size(64, 24)
        Me.CheckBox05.TabIndex = 1474
        Me.CheckBox05.Text = "推薦"
        '
        'imp_seq3
        '
        Me.imp_seq3.AllowSpace = False
        Me.imp_seq3.Format = "9"
        Me.imp_seq3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.imp_seq3.Location = New System.Drawing.Point(715, 51)
        Me.imp_seq3.MaxLength = 7
        Me.imp_seq3.Name = "imp_seq3"
        Me.imp_seq3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.imp_seq3.Size = New System.Drawing.Size(124, 24)
        Me.imp_seq3.TabIndex = 1473
        Me.imp_seq3.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Right
        Me.imp_seq3.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'F00_Form41
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.imp_seq2)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.br_imp_seq)
        Me.Controls.Add(Me.br_Date02)
        Me.Controls.Add(Me.br_Date01)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.br_imp_seq3)
        Me.Controls.Add(Me.br_imp_seq2)
        Me.Controls.Add(Me.br_cmb09)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.imp_seq)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox05)
        Me.Controls.Add(Me.imp_seq3)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form41"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入者リスト印刷(iPad)"
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imp_seq2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imp_seq3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form40_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
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

        DsList1.Clear()
        strSQL = "SELECT T01_member.shop_code, M04_shop.shop_name, T01_member.reg_date, T01_member.imp_seq, T01_member.suisen_flg, COUNT(*) AS cnt"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code INNER JOIN"
        strSQL += " T05_iPad ON T01_member.code = T05_iPad.code"

        n = 0
        str_WH(1) = Nothing : str_WH(2) = Nothing : str_WH(3) = Nothing
        If imp_seq.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
        End If
        If imp_seq2.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq2.Text & ")"
        End If
        If imp_seq3.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq3.Text & ")"
        End If
        Select Case n
            Case Is = 0
                strSQL += " WHERE (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
                If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                If Date01.Number <> 0 Then strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                If Date02.Number <> 0 Then strSQL += " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                If CheckBox05.Checked = True Then strSQL += "  AND (T01_member.suisen_flg = 1)"
            Case Is = 1
                strSQL += " WHERE"
                strSQL += str_WH(1)
            Case Is = 2
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
            Case Is = 3
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
                strSQL += " OR"
                strSQL += str_WH(3)
        End Select
        strSQL += " GROUP BY T01_member.shop_code, M04_shop.shop_name, T01_member.reg_date, T01_member.imp_seq, T01_member.suisen_flg"
        strSQL += " ORDER BY M04_shop.shop_name, T01_member.imp_seq"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T01_member")
        DB_CLOSE()

        If r = 0 Then
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            msg.Text = "対象データなし"
        Else
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            msg.Text = Nothing
        End If

        Dim tbl1 As New DataTable
        tbl1 = DsList1.Tables("T01_member")
        DataGrid1.DataSource = tbl1

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
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
    Private Sub imp_seq2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles imp_seq2.LostFocus
        imp_seq2.Text = Trim(imp_seq2.Text)
        If imp_seq2.Text <> br_imp_seq2.Text Then
            Call sql()      '** SQL
            br_imp_seq2.Text = imp_seq2.Text
        End If
    End Sub
    Private Sub imp_seq3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles imp_seq3.LostFocus
        imp_seq3.Text = Trim(imp_seq3.Text)
        If imp_seq3.Text <> br_imp_seq3.Text Then
            Call sql()      '** SQL
            br_imp_seq3.Text = imp_seq3.Text
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
    Private Sub CheckBox05_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox05.CheckedChanged
        Call sql()      '** SQL
    End Sub

    '******************************************************************
    '** 加入者リスト
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        P_DsPRT.Clear()
        strSQL = "SELECT '' AS sort1, '' AS sort2, T01_member.shop_code, M04_shop.shop_name, T01_member.imp_seq, 0 AS seq"
        strSQL += ", T01_member.code, T01_member.user_name, T01_member.makr_code, M05_VNDR.name AS makr_name"
        strSQL += ", T01_member.modl_name, T01_member.s_no, T01_member.prch_amnt, T01_member.wrn_range"
        strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name, T01_member.makr_wrn_stat, T01_member.wrn_tem"
        strSQL += ", V_M02_HSK.cls_code_name AS wrn_tem_name, T01_member.wrn_fee, '' AS kikan, T01_member.Part_date"
        strSQL += ", T01_member.reg_date"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
        strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"

        n = 0
        str_WH(1) = Nothing : str_WH(2) = Nothing : str_WH(3) = Nothing
        If imp_seq.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
        End If
        If imp_seq2.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq2.Text & ")"
        End If
        If imp_seq3.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq3.Text & ")"
        End If
        Select Case n
            Case Is = 0
                strSQL += " WHERE (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
                If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                If Date01.Number <> 0 Then strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                If Date02.Number <> 0 Then strSQL += " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                If CheckBox05.Checked = True Then strSQL += "  AND (T01_member.suisen_flg = 1)"
            Case Is = 1
                strSQL += " WHERE"
                strSQL += str_WH(1)
            Case Is = 2
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
            Case Is = 3
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
                strSQL += " OR"
                strSQL += str_WH(3)
        End Select
        strSQL += " ORDER BY M04_shop.shop_name, T01_member.imp_seq, wrn_range_name, wrn_tem_name, T01_member.code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(P_DsPRT, "Print01")
        DB_CLOSE()

        DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                DtView1(i)("sort1") = DtView1(i)("shop_name") & DtView1(i)("imp_seq")
                DtView1(i)("sort2") = DtView1(i)("wrn_tem_name") & " " & DtView1(i)("wrn_range_name")
                'DtView1(i)("seq") = i
                DtView1(i)("kikan") = DtView1(i)("makr_wrn_stat") & " ～ " & DtView1(i)("wrn_tem_name")
            Next
        End If

        PRT_PRAM1 = "R_member_list_iPad"

        Dim Print_View As New Print_View
        Print_View.ShowDialog()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ネバ伝
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        P_DsPRT.Clear()
        strSQL = "SELECT '' AS txt1, '' AS txt2, '' AS txt3, '' AS txt4, '' AS txt5"
        strSQL += ", '' AS txt11, '' AS txt12, '' AS txt13, '' AS txt14, '' AS txt15, '' AS txt16"
        strSQL += ", '' AS txt21, '' AS txt22, '' AS txt23, '' AS txt24, '' AS txt25, '' AS txt26"
        strSQL += ", '' AS txt31, '' AS txt32, '' AS txt33, '' AS txt34, '' AS txt35, '' AS txt36"
        strSQL += ", '' AS txt41, '' AS txt42, '' AS txt43, '' AS txt44, '' AS txt45, '' AS txt46"
        strSQL += ", '' AS txt51, '' AS txt52, '' AS txt53, '' AS txt54, '' AS txt55, '' AS txt56"
        strSQL += ", '' AS txt61, '' AS txt62, '' AS txt63, '' AS txt64, '' AS txt65, '' AS txt66"
        strSQL += ", '' AS txt74, '' AS txt76"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DsPRT.Clear()
        strSQL = "SELECT T01_member.univ_code, M01_univ.univ_name, T01_member.shop_code, M04_shop.shop_name"
        strSQL += ", M04_shop.shop_shop_code, M04_shop.torihiki_code, T01_member.reg_date"
        strSQL += ", T01_member.wrn_range, V_M02_HSY.cls_code_name AS wrn_range_name"
        strSQL += ", MAX(T01_member.code) AS code_max, MIN(T01_member.code) AS code_min"
        strSQL += ", T01_member.wrn_tem, V_M02_HSK.cls_code_name AS wrn_tem_name, COUNT(*) AS cnt"
        strSQL += ", T01_member.wrn_fee, SUM(T01_member.wrn_fee) AS wrn_fee_ttl"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code INNER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code INNER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code INNER JOIN"
        strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code"

        n = 0
        str_WH(1) = Nothing : str_WH(2) = Nothing : str_WH(3) = Nothing
        If imp_seq.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
        End If
        If imp_seq2.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq2.Text & ")"
        End If
        If imp_seq3.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq3.Text & ")"
        End If
        Select Case n
            Case Is = 0
                strSQL += " WHERE (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
                If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                If Date01.Number <> 0 Then strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                If Date02.Number <> 0 Then strSQL += " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                If CheckBox05.Checked = True Then strSQL += "  AND (T01_member.suisen_flg = 1)"
            Case Is = 1
                strSQL += " WHERE"
                strSQL += str_WH(1)
            Case Is = 2
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
            Case Is = 3
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
                strSQL += " OR"
                strSQL += str_WH(3)
        End Select
        strSQL += " GROUP BY T01_member.univ_code, M01_univ.univ_name, T01_member.shop_code, M04_shop.shop_name"
        strSQL += ", T01_member.wrn_range, V_M02_HSY.cls_code_name, T01_member.wrn_tem, V_M02_HSK.cls_code_name"
        strSQL += ", T01_member.reg_date, T01_member.wrn_fee, M04_shop.shop_shop_code, M04_shop.torihiki_code"
        strSQL += " ORDER BY T01_member.univ_code, T01_member.shop_code, T01_member.reg_date, T01_member.wrn_range"
        strSQL += ", T01_member.wrn_tem"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(P_DsPRT, "WK_Print01")
        DB_CLOSE()

        Call txt_clr()
        DtView1 = New DataView(P_DsPRT.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            BR_str = DtView1(0)("univ_code") & DtView1(0)("shop_code") & DtView1(0)("reg_date")
            For i = 0 To DtView1.Count - 1

                If BR_str <> DtView1(i)("univ_code") & DtView1(i)("shop_code") & DtView1(i)("reg_date") Then
                    Call neva()

                    BR_str = DtView1(i)("univ_code") & DtView1(i)("shop_code") & DtView1(i)("reg_date")
                End If

                j = j + 1
                Select Case j
                    Case Is = 1
                        If Not IsDBNull(DtView1(i)("univ_name")) Then txt1 = DtView1(i)("univ_name") Else txt1 = Nothing
                        txt2 = DtView1(i)("shop_name")
                        If Not IsDBNull(DtView1(i)("shop_shop_code")) Then txt3 = DtView1(i)("shop_shop_code") Else txt3 = Nothing
                        If Not IsDBNull(DtView1(i)("torihiki_code")) Then txt4 = DtView1(i)("torihiki_code") Else txt4 = Nothing
                        'If DtView1(i)("wrn_range") <> "7" Then
                        '    txt5 = "非課税"
                        'Else
                        txt5 = Nothing
                        'End If
                        txt11 = "ＱＧ－Ｃａｒｅ　アカデミック"
                        txt12 = DtView1(i)("wrn_range_name") & "　" & Trim(DtView1(i)("wrn_tem_name")) & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt13 = DtView1(i)("wrn_tem")
                        txt14 = DtView1(i)("cnt")
                        txt15 = DtView1(i)("wrn_fee")
                        txt16 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 2
                        txt21 = "ＱＧ－Ｃａｒｅ　アカデミック"
                        txt22 = DtView1(i)("wrn_range_name") & "　" & Trim(DtView1(i)("wrn_tem_name")) & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt23 = DtView1(i)("wrn_tem")
                        txt24 = DtView1(i)("cnt")
                        txt25 = DtView1(i)("wrn_fee")
                        txt26 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 3
                        txt31 = "ＱＧ－Ｃａｒｅ　アカデミック"
                        txt32 = DtView1(i)("wrn_range_name") & "　" & Trim(DtView1(i)("wrn_tem_name")) & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt33 = DtView1(i)("wrn_tem")
                        txt34 = DtView1(i)("cnt")
                        txt35 = DtView1(i)("wrn_fee")
                        txt36 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 4
                        txt41 = "ＱＧ－Ｃａｒｅ　アカデミック"
                        txt42 = DtView1(i)("wrn_range_name") & "　" & Trim(DtView1(i)("wrn_tem_name")) & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt43 = DtView1(i)("wrn_tem")
                        txt44 = DtView1(i)("cnt")
                        txt45 = DtView1(i)("wrn_fee")
                        txt46 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 5
                        txt51 = "ＱＧ－Ｃａｒｅ　アカデミック"
                        txt52 = DtView1(i)("wrn_range_name") & "　" & Trim(DtView1(i)("wrn_tem_name")) & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt53 = DtView1(i)("wrn_tem")
                        txt54 = DtView1(i)("cnt")
                        txt55 = DtView1(i)("wrn_fee")
                        txt56 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 6
                        txt61 = "ＱＧ－Ｃａｒｅ　アカデミック"
                        txt62 = DtView1(i)("wrn_range_name") & "　" & Trim(DtView1(i)("wrn_tem_name")) & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt63 = DtView1(i)("wrn_tem")
                        txt64 = DtView1(i)("cnt")
                        txt65 = DtView1(i)("wrn_fee")
                        txt66 = DtView1(i)("wrn_fee_ttl")
                End Select
                txt74 = txt74 + DtView1(i)("cnt")
                txt76 = txt76 + DtView1(i)("wrn_fee_ttl")
            Next
            Call neva()
        End If

        PRT_PRAM1 = "R_neva"

        Dim Print_View As New Print_View
        Print_View.ShowDialog()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Sub neva()

        dttable = P_DsPRT.Tables("Print01")
        dtRow = dttable.NewRow
        dtRow("txt1") = txt1

        WK_str = Trim(txt2).Replace("　", " ")
        n = WK_str.LastIndexOf(" ")
        If n > 0 Then
            dtRow("txt2") = Trim(Mid(WK_str, n + 1, 100))
        Else
            dtRow("txt2") = txt2
        End If
        dtRow("txt3") = txt3
        dtRow("txt4") = txt4
        dtRow("txt5") = txt5

        dtRow("txt11") = txt11
        dtRow("txt12") = txt12
        dtRow("txt14") = Format(txt14, "##,##0")
        dtRow("txt15") = Format(txt15, "##,##0")
        dtRow("txt16") = Format(txt16, "##,##0")

        If txt21 <> Nothing Then
            dtRow("txt21") = txt21
            dtRow("txt22") = txt22
            dtRow("txt24") = Format(txt24, "##,##0")
            dtRow("txt25") = Format(txt25, "##,##0")
            dtRow("txt26") = Format(txt26, "##,##0")
        End If

        If txt31 <> Nothing Then
            dtRow("txt31") = txt31
            dtRow("txt32") = txt32
            dtRow("txt34") = Format(txt34, "##,##0")
            dtRow("txt35") = Format(txt35, "##,##0")
            dtRow("txt36") = Format(txt36, "##,##0")
        End If

        If txt41 <> Nothing Then
            dtRow("txt41") = txt41
            dtRow("txt42") = txt42
            dtRow("txt44") = Format(txt44, "##,##0")
            dtRow("txt45") = Format(txt45, "##,##0")
            dtRow("txt46") = Format(txt46, "##,##0")
        End If

        If txt51 <> Nothing Then
            dtRow("txt51") = txt51
            dtRow("txt52") = txt52
            dtRow("txt54") = Format(txt54, "##,##0")
            dtRow("txt55") = Format(txt55, "##,##0")
            dtRow("txt56") = Format(txt56, "##,##0")
        End If

        If txt61 <> Nothing Then
            dtRow("txt61") = txt61
            dtRow("txt62") = txt62
            dtRow("txt64") = Format(txt64, "##,##0")
            dtRow("txt65") = Format(txt65, "##,##0")
            dtRow("txt66") = Format(txt66, "##,##0")
        End If

        dtRow("txt74") = Format(txt74, "##,##0")
        dtRow("txt76") = Format(txt76, "##,##0")
        dttable.Rows.Add(dtRow)

        Call txt_clr()
    End Sub

    '******************************************************************
    '** 確認表
    '******************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        P_DsPRT.Clear()
        strSQL = "SELECT '' AS txt1, '' AS txt2, '' AS txt3"
        strSQL += ", '' AS txt11, '' AS txt12, '' AS txt13, '' AS txt14, '' AS txt15, '' AS txt16"
        strSQL += ", '' AS txt21, '' AS txt22, '' AS txt23, '' AS txt24, '' AS txt25, '' AS txt26"
        strSQL += ", '' AS txt31, '' AS txt32, '' AS txt33, '' AS txt34, '' AS txt35, '' AS txt36"
        strSQL += ", '' AS txt41, '' AS txt42, '' AS txt43, '' AS txt44, '' AS txt45, '' AS txt46"
        strSQL += ", '' AS txt51, '' AS txt52, '' AS txt53, '' AS txt54, '' AS txt55, '' AS txt56"
        strSQL += ", '' AS txt74, '' AS txt76"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DsPRT.Clear()
        strSQL = "SELECT T01_member.univ_code, M01_univ.univ_name, T01_member.shop_code, M04_shop.shop_name"
        strSQL += ", T01_member.reg_date, T01_member.wrn_range, V_M02_HSY.cls_code_name AS wrn_range_name"
        strSQL += ", MAX(T01_member.code) AS code_max, MIN(T01_member.code) AS code_min"
        strSQL += ", T01_member.wrn_tem, V_M02_HSK.cls_code_name AS wrn_tem_name, COUNT(*) AS cnt"
        strSQL += ", T01_member.wrn_fee, SUM(T01_member.wrn_fee) AS wrn_fee_ttl"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code INNER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code INNER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code INNER JOIN"
        strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code"

        n = 0
        str_WH(1) = Nothing : str_WH(2) = Nothing : str_WH(3) = Nothing
        If imp_seq.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.wrn_range <> 7) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
        End If
        If imp_seq2.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.wrn_range <> 7) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq2.Text & ")"
        End If
        If imp_seq3.Text <> Nothing Then
            n = n + 1
            str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.wrn_range <> 7) AND (T01_member.nendo = " & P_proc_y & ")"
            If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
            If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
            If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
            If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
            str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq3.Text & ")"
        End If
        Select Case n
            Case Is = 0
                strSQL += " WHERE (T01_member.delt_flg = 0) AND (T01_member.wrn_range <> 7) AND (T01_member.nendo = " & P_proc_y & ")"
                If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                If Date01.Number <> 0 Then strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                If Date02.Number <> 0 Then strSQL += " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                If CheckBox05.Checked = True Then strSQL += "  AND (T01_member.suisen_flg = 1)"
            Case Is = 1
                strSQL += " WHERE"
                strSQL += str_WH(1)
            Case Is = 2
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
            Case Is = 3
                strSQL += " WHERE"
                strSQL += str_WH(1)
                strSQL += " OR"
                strSQL += str_WH(2)
                strSQL += " OR"
                strSQL += str_WH(3)
        End Select
        strSQL += " GROUP BY T01_member.univ_code, M01_univ.univ_name, T01_member.shop_code, M04_shop.shop_name"
        strSQL += ", T01_member.wrn_range, V_M02_HSY.cls_code_name, T01_member.wrn_tem, V_M02_HSK.cls_code_name"
        strSQL += ", T01_member.reg_date, T01_member.wrn_fee"
        strSQL += " ORDER BY T01_member.univ_code, T01_member.shop_code, T01_member.reg_date, T01_member.wrn_range"
        strSQL += ", T01_member.wrn_tem"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(P_DsPRT, "WK_Print01")
        DB_CLOSE()

        Call txt_clr()
        DtView1 = New DataView(P_DsPRT.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            BR_str = DtView1(0)("univ_code") & DtView1(0)("shop_code") & DtView1(0)("reg_date")
            For i = 0 To DtView1.Count - 1

                If BR_str <> DtView1(i)("univ_code") & DtView1(i)("shop_code") & DtView1(i)("reg_date") Then
                    Call kakunin()

                    BR_str = DtView1(i)("univ_code") & DtView1(i)("shop_code") & DtView1(i)("reg_date")
                End If

                j = j + 1
                Select Case j
                    Case Is = 1
                        If Not IsDBNull(DtView1(i)("univ_name")) Then txt1 = DtView1(i)("univ_name") Else txt1 = Nothing
                        txt2 = DtView1(i)("shop_name")
                        txt3 = DtView1(i)("reg_date")
                        txt11 = "1"
                        txt12 = DtView1(i)("wrn_range_name") & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt13 = DtView1(i)("wrn_tem")
                        txt14 = DtView1(i)("cnt")
                        txt15 = DtView1(i)("wrn_fee")
                        txt16 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 2
                        txt21 = "2"
                        txt22 = DtView1(i)("wrn_range_name") & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt23 = DtView1(i)("wrn_tem")
                        txt24 = DtView1(i)("cnt")
                        txt25 = DtView1(i)("wrn_fee")
                        txt26 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 3
                        txt31 = "3"
                        txt32 = DtView1(i)("wrn_range_name") & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt33 = DtView1(i)("wrn_tem")
                        txt34 = DtView1(i)("cnt")
                        txt35 = DtView1(i)("wrn_fee")
                        txt36 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 4
                        txt41 = "4"
                        txt42 = DtView1(i)("wrn_range_name") & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt43 = DtView1(i)("wrn_tem")
                        txt44 = DtView1(i)("cnt")
                        txt45 = DtView1(i)("wrn_fee")
                        txt46 = DtView1(i)("wrn_fee_ttl")
                    Case Is = 5
                        txt51 = "5"
                        txt52 = DtView1(i)("wrn_range_name") & "(" & DtView1(i)("code_min") & " ～ " & DtView1(i)("code_max") & ")"
                        txt53 = DtView1(i)("wrn_tem")
                        txt54 = DtView1(i)("cnt")
                        txt55 = DtView1(i)("wrn_fee")
                        txt56 = DtView1(i)("wrn_fee_ttl")
                End Select
                txt74 = txt74 + DtView1(i)("cnt")
                txt76 = txt76 + DtView1(i)("wrn_fee_ttl")
            Next
            Call kakunin()
        End If

        PRT_PRAM1 = "R_kakunin"

        Dim Print_View As New Print_View
        Print_View.ShowDialog()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub kakunin()

        dttable = P_DsPRT.Tables("Print01")
        dtRow = dttable.NewRow
        'dtRow("txt1") = txt1

        WK_str = Trim(txt2).Replace("　", " ")
        n = WK_str.LastIndexOf(" ")
        If n > 0 Then
            dtRow("txt1") = Trim(Mid(WK_str, 1, n))
            dtRow("txt2") = Trim(Mid(WK_str, n + 1, 100))
        Else
            dtRow("txt1") = WK_str
            dtRow("txt2") = Nothing
        End If
        dtRow("txt3") = Format(CDate(txt3), "yyyy年MM月dd日")

        dtRow("txt11") = txt11
        dtRow("txt12") = txt12
        dtRow("txt13") = txt13
        dtRow("txt14") = Format(txt14, "##,##0")
        dtRow("txt15") = Format(txt15, "##,##0")
        dtRow("txt16") = Format(txt16, "##,##0")

        If txt21 <> Nothing Then
            dtRow("txt21") = txt21
            dtRow("txt22") = txt22
            dtRow("txt23") = txt23
            dtRow("txt24") = Format(txt24, "##,##0")
            dtRow("txt25") = Format(txt25, "##,##0")
            dtRow("txt26") = Format(txt26, "##,##0")
        End If

        If txt31 <> Nothing Then
            dtRow("txt31") = txt31
            dtRow("txt32") = txt32
            dtRow("txt33") = txt33
            dtRow("txt34") = Format(txt34, "##,##0")
            dtRow("txt35") = Format(txt35, "##,##0")
            dtRow("txt36") = Format(txt36, "##,##0")
        End If

        If txt41 <> Nothing Then
            dtRow("txt41") = txt41
            dtRow("txt42") = txt42
            dtRow("txt43") = txt43
            dtRow("txt44") = Format(txt44, "##,##0")
            dtRow("txt45") = Format(txt45, "##,##0")
            dtRow("txt46") = Format(txt46, "##,##0")
        End If

        If txt51 <> Nothing Then
            dtRow("txt51") = txt51
            dtRow("txt52") = txt52
            dtRow("txt53") = txt53
            dtRow("txt54") = Format(txt54, "##,##0")
            dtRow("txt55") = Format(txt55, "##,##0")
            dtRow("txt56") = Format(txt56, "##,##0")
        End If

        dtRow("txt74") = Format(txt74, "##,##0")
        dtRow("txt76") = Format(txt76, "##,##0")
        dttable.Rows.Add(dtRow)

        Call txt_clr()
    End Sub

    Sub txt_clr()

        j = 0
        txt1 = Nothing : txt2 = Nothing : txt3 = Nothing : txt4 = Nothing : txt5 = Nothing
        txt11 = Nothing : txt12 = Nothing : txt13 = Nothing : txt14 = 0 : txt15 = 0 : txt16 = 0
        txt21 = Nothing : txt22 = Nothing : txt23 = Nothing : txt24 = 0 : txt25 = 0 : txt26 = 0
        txt31 = Nothing : txt32 = Nothing : txt33 = Nothing : txt34 = 0 : txt35 = 0 : txt36 = 0
        txt41 = Nothing : txt42 = Nothing : txt43 = Nothing : txt44 = 0 : txt45 = 0 : txt46 = 0
        txt51 = Nothing : txt52 = Nothing : txt53 = Nothing : txt54 = 0 : txt55 = 0 : txt56 = 0
        txt61 = Nothing : txt62 = Nothing : txt63 = Nothing : txt64 = 0 : txt65 = 0 : txt66 = 0
        txt74 = 0 : txt76 = 0

    End Sub

    '******************************************************************
    '** CSV
    '******************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "加入者リスト" & Format(Now, "yyyyMMddHHmmss") & ".CSV" 'はじめのファイル名を指定する
        sfd.Filter = "CSVファイル(*.CSV)|*.CSV"                 '[ファイルの種類]に表示される選択肢を指定する
        sfd.FilterIndex = 2                                     '[ファイルの種類]ではじめに 「すべてのファイル」が選択されているようにする
        sfd.Title = "保存先のファイルを選択してください"        'タイトルを設定する
        sfd.RestoreDirectory = True                             'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True

        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then     'ダイアログを表示する
            strFile = sfd.FileName   'OKボタンがクリックされたとき
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            P_DsPRT.Clear()
            strSQL = "SELECT '' AS sort1, '' AS sort2, T01_member.shop_code, M04_shop.shop_name, T01_member.imp_seq, 0 AS seq"
            strSQL += ", T01_member.code, T01_member.user_name, T01_member.makr_code, M05_VNDR.name AS makr_name"
            strSQL += ", T01_member.modl_name, T01_member.s_no, T01_member.prch_amnt, T01_member.wrn_range"
            strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name, T01_member.makr_wrn_stat, T01_member.wrn_tem"
            strSQL += ", V_M02_HSK.cls_code_name AS wrn_tem_name, T01_member.wrn_fee, '' AS kikan, T01_member.reg_date"
            strSQL += " FROM T01_member INNER JOIN"
            strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
            strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
            strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
            strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code LEFT OUTER JOIN"
            strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"

            n = 0
            str_WH(1) = Nothing : str_WH(2) = Nothing : str_WH(3) = Nothing
            If imp_seq.Text <> Nothing Then
                n = n + 1
                str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
                If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
                str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
            End If
            If imp_seq2.Text <> Nothing Then
                n = n + 1
                str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
                If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
                str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq2.Text & ")"
            End If
            If imp_seq3.Text <> Nothing Then
                n = n + 1
                str_WH(n) = " (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
                If Combo09.Text <> Nothing Then str_WH(n) = str_WH(n) & " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                If Date01.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                If Date02.Number <> 0 Then str_WH(n) = str_WH(n) & " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                If CheckBox05.Checked = True Then str_WH(n) = str_WH(n) & "  AND (T01_member.suisen_flg = 1)"
                str_WH(n) = str_WH(n) & " AND (T01_member.imp_seq = " & imp_seq3.Text & ")"
            End If
            Select Case n
                Case Is = 0
                    strSQL += " WHERE (T01_member.delt_flg = 0) AND (T01_member.nendo = " & P_proc_y & ")"
                    If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
                    If Date01.Number <> 0 Then strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
                    If Date02.Number <> 0 Then strSQL += " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
                    If CheckBox05.Checked = True Then strSQL += "  AND (T01_member.suisen_flg = 1)"
                Case Is = 1
                    strSQL += " WHERE"
                    strSQL += str_WH(1)
                Case Is = 2
                    strSQL += " WHERE"
                    strSQL += str_WH(1)
                    strSQL += " OR"
                    strSQL += str_WH(2)
                Case Is = 3
                    strSQL += " WHERE"
                    strSQL += str_WH(1)
                    strSQL += " OR"
                    strSQL += str_WH(2)
                    strSQL += " OR"
                    strSQL += str_WH(3)
            End Select
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(P_DsPRT, "csv")
            DB_CLOSE()

            DtView1 = New DataView(P_DsPRT.Tables("csv"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                For i = 0 To DtView1.Count - 1
                    DtView1(i)("sort1") = DtView1(i)("shop_name") & DtView1(i)("imp_seq")
                    DtView1(i)("sort2") = DtView1(i)("wrn_tem_name") & " " & DtView1(i)("wrn_range_name")
                    DtView1(i)("kikan") = DtView1(i)("makr_wrn_stat") & " ～ " & DtView1(i)("wrn_tem_name")
                Next
            End If

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "ｿｰﾄ,ｿｰﾄ2,取込処理№,販売店名,加入証番号,加入者名,メーカー,型番,シリアル№,購入金額,保証種類,保証開始日,保証範囲,加入者請求金額,登録日付"
            swFile.WriteLine(strData)

            DtView1 = New DataView(P_DsPRT.Tables("csv"), "", "sort1, sort2, code", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                strData = DtView1(i)("sort1")                           'ｿｰﾄ
                strData = strData & "," & DtView1(i)("sort2")           'ｿｰﾄ2
                strData = strData & "," & DtView1(i)("imp_seq")         '取込処理№
                strData = strData & "," & DtView1(i)("shop_name")       '販売店名
                strData = strData & "," & DtView1(i)("code")            '加入証番号
                strData = strData & "," & DtView1(i)("user_name")       '加入者名
                strData = strData & "," & DtView1(i)("makr_name")       'メーカー
                strData = strData & "," & DtView1(i)("modl_name")       '型番
                strData = strData & "," & DtView1(i)("s_no")            'シリアル№
                strData = strData & "," & DtView1(i)("prch_amnt")       '購入金額
                strData = strData & "," & DtView1(i)("wrn_range_name") '保証種類
                strData = strData & "," & DtView1(i)("makr_wrn_stat")   '保証開始日
                strData = strData & "," & DtView1(i)("kikan")           '保証範囲
                strData = strData & "," & DtView1(i)("wrn_fee")         '加入者請求金額
                strData = strData & "," & DtView1(i)("reg_date")        '登録日付
                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          'ファイルを閉じる
            MessageBox.Show("CSV出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_DsPRT.Clear()
        DsList1.Clear()
        DsCMB1.Clear()
        Close()
    End Sub
End Class
