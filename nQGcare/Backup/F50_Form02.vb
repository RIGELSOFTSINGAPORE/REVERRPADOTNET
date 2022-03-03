Public Class F50_Form02
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, inz_F, strFile, strData As String
    Dim i, r As Integer

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
    Friend WithEvents br_Date02 As System.Windows.Forms.Label
    Friend WithEvents br_Date01 As System.Windows.Forms.Label
    Friend WithEvents br_cmb09 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Date
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents br_cmb01 As System.Windows.Forms.Label
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents br_Date04 As System.Windows.Forms.Label
    Friend WithEvents br_Date03 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Date04 As GrapeCity.Win.Input.Date
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Date03 As GrapeCity.Win.Input.Date
    Friend WithEvents br_Date06 As System.Windows.Forms.Label
    Friend WithEvents br_Date05 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Date06 As GrapeCity.Win.Input.Date
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Date05 As GrapeCity.Win.Input.Date
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents cnt As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.br_Date02 = New System.Windows.Forms.Label
        Me.br_Date01 = New System.Windows.Forms.Label
        Me.br_cmb09 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Date
        Me.Combo09 = New GrapeCity.Win.Input.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.br_cmb01 = New System.Windows.Forms.Label
        Me.cmb01 = New System.Windows.Forms.Label
        Me.Combo01 = New GrapeCity.Win.Input.Combo
        Me.Label6 = New System.Windows.Forms.Label
        Me.br_Date04 = New System.Windows.Forms.Label
        Me.br_Date03 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Date04 = New GrapeCity.Win.Input.Date
        Me.Label7 = New System.Windows.Forms.Label
        Me.Date03 = New GrapeCity.Win.Input.Date
        Me.br_Date06 = New System.Windows.Forms.Label
        Me.br_Date05 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Date06 = New GrapeCity.Win.Input.Date
        Me.Label11 = New System.Windows.Forms.Label
        Me.Date05 = New GrapeCity.Win.Input.Date
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.msg = New System.Windows.Forms.Label
        Me.cnt = New System.Windows.Forms.Label
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date05, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'br_Date02
        '
        Me.br_Date02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date02.Location = New System.Drawing.Point(892, 8)
        Me.br_Date02.Name = "br_Date02"
        Me.br_Date02.Size = New System.Drawing.Size(100, 16)
        Me.br_Date02.TabIndex = 1475
        Me.br_Date02.Text = "br_Date02"
        Me.br_Date02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date02.Visible = False
        '
        'br_Date01
        '
        Me.br_Date01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date01.Location = New System.Drawing.Point(792, 8)
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
        Me.br_cmb09.Location = New System.Drawing.Point(88, 64)
        Me.br_cmb09.Name = "br_cmb09"
        Me.br_cmb09.Size = New System.Drawing.Size(356, 16)
        Me.br_cmb09.TabIndex = 1473
        Me.br_cmb09.Text = "br_cmb09"
        Me.br_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb09.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(424, 28)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1472
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(664, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 24)
        Me.Label3.TabIndex = 1471
        Me.Label3.Text = "～"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(688, 4)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 3
        Me.Date02.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(496, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 1469
        Me.Label1.Text = "申込日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(560, 4)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 2
        Me.Date01.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(88, 40)
        Me.Combo09.MaxDropDownItems = 35
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(356, 24)
        Me.Combo09.TabIndex = 1
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(4, 40)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 24)
        Me.Label23.TabIndex = 1468
        Me.Label23.Text = "取扱店"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(788, 653)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 28)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "CSV出力"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(919, 653)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 10
        Me.Button99.Text = "閉じる"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "取扱店"
        Me.DataGridTextBoxColumn1.MappingName = "shop_name"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 300
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "申込日"
        Me.DataGridTextBoxColumn2.MappingName = "Part_date"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 95
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "加入番号"
        Me.DataGridTextBoxColumn3.MappingName = "code"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 95
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "氏名"
        Me.DataGridTextBoxColumn4.MappingName = "user_name"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 160
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(11, 96)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(980, 548)
        Me.DataGrid1.TabIndex = 8
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T02_clct"
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "##,##0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "金額"
        Me.DataGridTextBoxColumn5.MappingName = "wrn_fee"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 90
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "請求日"
        Me.DataGridTextBoxColumn6.MappingName = "invc_date"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 95
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "入金日"
        Me.DataGridTextBoxColumn7.MappingName = "clct_date"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 95
        '
        'br_cmb01
        '
        Me.br_cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb01.Location = New System.Drawing.Point(252, 24)
        Me.br_cmb01.Name = "br_cmb01"
        Me.br_cmb01.Size = New System.Drawing.Size(136, 16)
        Me.br_cmb01.TabIndex = 1480
        Me.br_cmb01.Text = "br_cmb01"
        Me.br_cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb01.Visible = False
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(252, 8)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1479
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo01.Location = New System.Drawing.Point(88, 8)
        Me.Combo01.MaxDropDownItems = 20
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(164, 24)
        Me.Combo01.TabIndex = 0
        Me.Combo01.Value = "Combo01"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 24)
        Me.Label6.TabIndex = 1478
        Me.Label6.Text = "入金状況"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'br_Date04
        '
        Me.br_Date04.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date04.Location = New System.Drawing.Point(892, 40)
        Me.br_Date04.Name = "br_Date04"
        Me.br_Date04.Size = New System.Drawing.Size(100, 16)
        Me.br_Date04.TabIndex = 1486
        Me.br_Date04.Text = "br_Date04"
        Me.br_Date04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date04.Visible = False
        '
        'br_Date03
        '
        Me.br_Date03.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date03.Location = New System.Drawing.Point(792, 40)
        Me.br_Date03.Name = "br_Date03"
        Me.br_Date03.Size = New System.Drawing.Size(100, 16)
        Me.br_Date03.TabIndex = 1485
        Me.br_Date03.Text = "br_Date03"
        Me.br_Date03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date03.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(664, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 24)
        Me.Label5.TabIndex = 1484
        Me.Label5.Text = "～"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date04
        '
        Me.Date04.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date04.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date04.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date04.Location = New System.Drawing.Point(688, 36)
        Me.Date04.Name = "Date04"
        Me.Date04.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date04.Size = New System.Drawing.Size(104, 24)
        Me.Date04.TabIndex = 5
        Me.Date04.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date04.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date04.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(496, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 24)
        Me.Label7.TabIndex = 1483
        Me.Label7.Text = "請求日"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date03
        '
        Me.Date03.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date03.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date03.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date03.Location = New System.Drawing.Point(560, 36)
        Me.Date03.Name = "Date03"
        Me.Date03.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date03.Size = New System.Drawing.Size(104, 24)
        Me.Date03.TabIndex = 4
        Me.Date03.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date03.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date03.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'br_Date06
        '
        Me.br_Date06.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date06.Location = New System.Drawing.Point(892, 68)
        Me.br_Date06.Name = "br_Date06"
        Me.br_Date06.Size = New System.Drawing.Size(100, 16)
        Me.br_Date06.TabIndex = 1492
        Me.br_Date06.Text = "br_Date06"
        Me.br_Date06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date06.Visible = False
        '
        'br_Date05
        '
        Me.br_Date05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date05.Location = New System.Drawing.Point(792, 68)
        Me.br_Date05.Name = "br_Date05"
        Me.br_Date05.Size = New System.Drawing.Size(100, 16)
        Me.br_Date05.TabIndex = 1491
        Me.br_Date05.Text = "br_Date05"
        Me.br_Date05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date05.Visible = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(664, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 24)
        Me.Label10.TabIndex = 1490
        Me.Label10.Text = "～"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date06
        '
        Me.Date06.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date06.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date06.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date06.Location = New System.Drawing.Point(688, 64)
        Me.Date06.Name = "Date06"
        Me.Date06.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date06.Size = New System.Drawing.Size(104, 24)
        Me.Date06.TabIndex = 7
        Me.Date06.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date06.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date06.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(496, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 24)
        Me.Label11.TabIndex = 1489
        Me.Label11.Text = "入金日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date05
        '
        Me.Date05.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date05.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date05.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date05.Location = New System.Drawing.Point(560, 64)
        Me.Date05.Name = "Date05"
        Me.Date05.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date05.Size = New System.Drawing.Size(104, 24)
        Me.Date05.TabIndex = 6
        Me.Date05.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date05.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date05.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 652)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(752, 28)
        Me.msg.TabIndex = 1493
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cnt
        '
        Me.cnt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.cnt.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cnt.ForeColor = System.Drawing.Color.White
        Me.cnt.Location = New System.Drawing.Point(840, 96)
        Me.cnt.Name = "cnt"
        Me.cnt.Size = New System.Drawing.Size(140, 20)
        Me.cnt.TabIndex = 1494
        Me.cnt.Text = "cnt"
        Me.cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'F50_Form02
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.cnt)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.br_Date06)
        Me.Controls.Add(Me.br_Date05)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Date06)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Date05)
        Me.Controls.Add(Me.br_Date04)
        Me.Controls.Add(Me.br_Date03)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Date04)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Date03)
        Me.Controls.Add(Me.br_cmb01)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.br_Date02)
        Me.Controls.Add(Me.br_Date01)
        Me.Controls.Add(Me.br_cmb09)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form02"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入金確認"
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date05, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F50_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call sql()      '** SQL
        inz_F = "1"
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
        cnt.Text = Nothing

        Date01.Number = 0 : br_Date01.Text = Nothing
        Date02.Number = 0 : br_Date02.Text = Nothing
        Date03.Number = 0 : br_Date03.Text = Nothing
        Date04.Number = 0 : br_Date04.Text = Nothing
        Date05.Number = 0 : br_Date05.Text = Nothing
        Date06.Number = 0 : br_Date06.Text = Nothing

    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        '入金状況
        strSQL = "SELECT cls_code, cls_code_name FROM V_M02_JOS"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M02_JOS")
        Combo01.DataSource = DsCMB1.Tables("M02_JOS")
        Combo01.DisplayMember = "cls_code_name"
        Combo01.ValueMember = "cls_code"
        Combo01.Text = Nothing : cmb01.Text = Nothing : br_cmb01.Text = Nothing
        Combo01.SelectedIndex = -1

        '取扱店
        strSQL = "SELECT shop_code, shop_name, ittpan FROM M04_shop WHERE (shop_code <> 0) AND (delt_flg = 0) ORDER BY shop_name_kana, shop_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M04_shop")
        Combo09.DataSource = DsCMB1.Tables("M04_shop")
        Combo09.DisplayMember = "shop_name"
        Combo09.ValueMember = "shop_code"
        Combo09.Text = Nothing : cmb09.Text = Nothing : br_cmb09.Text = Nothing
        Combo09.SelectedIndex = -1

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** SQL
    '********************************************************************
    Sub sql()
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DsList1.Clear()
        'If cmb01.Text <> Nothing Then

        strSQL = "SELECT T01_member.shop_code, M04_shop.shop_name, T01_member.Part_date, T01_member.code, T01_member.user_name"
        strSQL += ", T02_clct.invc_date, T02_clct.clct_date, T02_clct.clct_stts"
        Select Case cmb01.Text
            Case Is = "1"
                strSQL += ", T01_member.wrn_fee"
            Case Is = "2"
                strSQL += ", T02_clct.invc_amnt AS wrn_fee"
            Case Is = "9"
                strSQL += ", T02_clct.clct_amnt AS wrn_fee"
            Case Else
                strSQL += ", T01_member.wrn_fee"
        End Select
        strSQL += " FROM T01_member LEFT OUTER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " T02_clct ON T01_member.code = T02_clct.code"
        strSQL += " WHERE (T01_member.delt_flg = 0)"
        Select Case cmb01.Text
            Case Is = "1"
                strSQL += " AND (T02_clct.clct_stts IS NULL OR T02_clct.clct_stts = '1')"
            Case Is = "2", "9"
                strSQL += " AND (dbo.T02_clct.clct_stts = '" & cmb01.Text & "')"
            Case Else
                strSQL += " AND (dbo.T02_clct.clct_stts = 'xx')"
        End Select
        If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
        If Date01.Number <> 0 Then strSQL += " AND (T01_member.Part_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
        If Date02.Number <> 0 Then strSQL += " AND (T01_member.Part_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
        If Date03.Number <> 0 Then strSQL += " AND (T02_clct.invc_date >= CONVERT(DATETIME, '" & Date03.Text & "', 102))"
        If Date04.Number <> 0 Then strSQL += " AND (T02_clct.invc_date <= CONVERT(DATETIME, '" & Date04.Text & "', 102))"
        If Date05.Number <> 0 Then strSQL += " AND (T02_clct.clct_date >= CONVERT(DATETIME, '" & Date05.Text & "', 102))"
        If Date06.Number <> 0 Then strSQL += " AND (T02_clct.clct_date <= CONVERT(DATETIME, '" & Date06.Text & "', 102))"
        strSQL += " ORDER BY M04_shop.shop_name, T01_member.Part_date, T01_member.code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T02_clct")
        DB_CLOSE()
        'Else
        '    r = 0
        'End If

        If r = 0 Then
            Button3.Enabled = False
            If inz_F = "1" Then msg.Text = "対象データなし"
        Else
            Button3.Enabled = True
            msg.Text = Nothing
        End If
        cnt.Text = Format(r, "##,##0") & "件"

        Dim tbl1 As New DataTable
        tbl1 = DsList1.Tables("T02_clct")
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
    Private Sub Date03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date03.LostFocus
        If Date03.Text <> br_Date03.Text Then
            Call sql()      '** SQL
            br_Date03.Text = Date03.Text
        End If
    End Sub
    Private Sub Date04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date04.LostFocus
        If Date04.Text <> br_Date04.Text Then
            Call sql()      '** SQL
            br_Date04.Text = Date04.Text
        End If
    End Sub
    Private Sub Date05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date05.LostFocus
        If Date05.Text <> br_Date05.Text Then
            Call sql()      '** SQL
            br_Date05.Text = Date05.Text
        End If
    End Sub
    Private Sub Date06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date06.LostFocus
        If Date06.Text <> br_Date06.Text Then
            Call sql()      '** SQL
            br_Date06.Text = Date06.Text
        End If
    End Sub
    Private Sub Combo01_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.TextChanged
        If inz_F <> "1" Then Exit Sub

        Combo01.Text = Trim(Combo01.Text)
        If Combo01.Text <> br_cmb01.Text Then
            DtView1 = New DataView(DsCMB1.Tables("M02_JOS"), "cls_code_name = '" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb01.Text = DtView1(0)("cls_code")
            Else
                cmb01.Text = Nothing
            End If
            Call sql()      '** SQL
            br_cmb01.Text = Combo01.Text
        End If
    End Sub
    Private Sub Combo01_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.SelectedIndexChanged
        If inz_F <> "1" Then Exit Sub

        Combo01.Text = Trim(Combo01.Text)
        If Combo01.Text <> br_cmb01.Text Then
            DtView1 = New DataView(DsCMB1.Tables("M02_JOS"), "cls_code_name = '" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb01.Text = DtView1(0)("cls_code")
            Else
                cmb01.Text = Nothing
            End If
            Call sql()      '** SQL
            br_cmb01.Text = Combo01.Text
        End If
    End Sub
    Private Sub Combo09_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.TextChanged
        If inz_F <> "1" Then Exit Sub

        Combo09.Text = Trim(Combo09.Text)
        If Combo09.Text <> br_cmb09.Text Then
            Call sql()      '** SQL
            br_cmb09.Text = Combo09.Text
        End If
    End Sub
    Private Sub Combo09_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.SelectedIndexChanged
        If inz_F <> "1" Then Exit Sub

        Combo09.Text = Trim(Combo09.Text)
        If Combo09.Text <> br_cmb09.Text Then
            Call sql()      '** SQL
            br_cmb09.Text = Combo09.Text
        End If
    End Sub

    '******************************************************************
    '** CSV出力
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "入金確認" & Format(Now, "yyyyMMddHHmmss") & ".CSV" 'はじめのファイル名を指定する
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

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "取扱店,申込日,加入番号,氏名,加入者状況,加入者請求金額,加入者請求日,加入者入金日"
            swFile.WriteLine(strData)

            Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsList1.Tables("T02_clct"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                strData = DtView1(i)("shop_name")                       '取扱店
                strData = strData & "," & DtView1(i)("Part_date")       '申込日
                strData = strData & "," & DtView1(i)("code")            '加入番号
                strData = strData & "," & DtView1(i)("user_name")       '氏名
                strData = strData & "," & Combo01.Text                  '加入者状況
                strData = strData & "," & DtView1(i)("wrn_fee")         '加入者請求金額
                strData = strData & "," & DtView1(i)("invc_date")       '加入者請求日
                strData = strData & "," & DtView1(i)("clct_date")       '加入者入金日
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
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB1.Clear()
        Close()
    End Sub
End Class
