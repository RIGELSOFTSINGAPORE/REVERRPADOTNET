Public Class Form6
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2 As New DataSet
    Dim DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, CHG_F As String
    Dim i, r, n As Integer

    Dim BR_Edit1 As String
    Dim BR_Edit02, BR_Edit03, BR_Edit04, BR_Edit05, BR_Edit06, BR_Edit07, BR_Edit08, BR_Edit09, BR_Edit10, BR_Edit11 As String
    Dim BR_Combo07, BR_Combo08 As String
    Dim BR_Number1, BR_Number2, BR_Number3, BR_Number4, BR_Number5, BR_Number6, BR_Number7 As Integer

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label03 As System.Windows.Forms.Label
    Friend WithEvents Label07 As System.Windows.Forms.Label
    Friend WithEvents Label08 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label017 As System.Windows.Forms.Label
    Friend WithEvents Label190 As System.Windows.Forms.Label
    Friend WithEvents Number2 As GrapeCity.Win.Input.Number
    Friend WithEvents Number1 As GrapeCity.Win.Input.Number
    Friend WithEvents Label04 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label016 As System.Windows.Forms.Label
    Friend WithEvents Label015 As System.Windows.Forms.Label
    Friend WithEvents Label014 As System.Windows.Forms.Label
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Label009 As System.Windows.Forms.Label
    Friend WithEvents Label008 As System.Windows.Forms.Label
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Edit04 = New GrapeCity.Win.Input.Edit
        Me.Edit03 = New GrapeCity.Win.Input.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Edit
        Me.Label03 = New System.Windows.Forms.Label
        Me.Label07 = New System.Windows.Forms.Label
        Me.Label08 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label017 = New System.Windows.Forms.Label
        Me.Label190 = New System.Windows.Forms.Label
        Me.Number2 = New GrapeCity.Win.Input.Number
        Me.Number1 = New GrapeCity.Win.Input.Number
        Me.Label04 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.Label016 = New System.Windows.Forms.Label
        Me.Label015 = New System.Windows.Forms.Label
        Me.Label014 = New System.Windows.Forms.Label
        Me.Label013 = New System.Windows.Forms.Label
        Me.Label012 = New System.Windows.Forms.Label
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label009 = New System.Windows.Forms.Label
        Me.Label008 = New System.Windows.Forms.Label
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label120 = New System.Windows.Forms.Label
        Me.Label110 = New System.Windows.Forms.Label
        Me.Label100 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label43 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Edit05 = New GrapeCity.Win.Input.Edit
        Me.Edit06 = New GrapeCity.Win.Input.Edit
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1092, 108)
        Me.Label1.TabIndex = 1661
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGrid1.CaptionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGrid1.CaptionText = "ﾋﾝﾄ"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(9, 216)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(1083, 360)
        Me.DataGrid1.TabIndex = 1631
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "02_売上データ"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.MappingName = "商品ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "品名漢字"
        Me.DataGridTextBoxColumn2.MappingName = "品名漢字"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "品名ｶﾅ"
        Me.DataGridTextBoxColumn3.MappingName = "品名ｶﾅ"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "分類ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.MappingName = "分類ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "品種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn7.MappingName = "品種ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'Edit04
        '
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(93, 190)
        Me.Edit04.MaxLength = 100
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(200, 20)
        Me.Edit04.TabIndex = 1616
        Me.Edit04.Text = "Edit04"
        '
        'Edit03
        '
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(93, 170)
        Me.Edit03.MaxLength = 100
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(200, 20)
        Me.Edit03.TabIndex = 1615
        Me.Edit03.Text = "Edit03"
        '
        'Edit02
        '
        Me.Edit02.Format = "9"
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(93, 150)
        Me.Edit02.MaxLength = 13
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(200, 20)
        Me.Edit02.TabIndex = 1614
        Me.Edit02.Text = "02"
        '
        'Label03
        '
        Me.Label03.BackColor = System.Drawing.Color.Navy
        Me.Label03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label03.ForeColor = System.Drawing.Color.White
        Me.Label03.Location = New System.Drawing.Point(9, 170)
        Me.Label03.Name = "Label03"
        Me.Label03.Size = New System.Drawing.Size(84, 20)
        Me.Label03.TabIndex = 1672
        Me.Label03.Text = "品名漢字"
        Me.Label03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label07
        '
        Me.Label07.BackColor = System.Drawing.Color.Navy
        Me.Label07.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label07.ForeColor = System.Drawing.Color.White
        Me.Label07.Location = New System.Drawing.Point(300, 152)
        Me.Label07.Name = "Label07"
        Me.Label07.Size = New System.Drawing.Size(84, 20)
        Me.Label07.TabIndex = 1670
        Me.Label07.Text = "分類ｺｰﾄﾞ"
        Me.Label07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label08
        '
        Me.Label08.BackColor = System.Drawing.Color.Navy
        Me.Label08.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label08.ForeColor = System.Drawing.Color.White
        Me.Label08.Location = New System.Drawing.Point(300, 172)
        Me.Label08.Name = "Label08"
        Me.Label08.Size = New System.Drawing.Size(84, 20)
        Me.Label08.TabIndex = 1669
        Me.Label08.Text = "品種ｺｰﾄﾞ"
        Me.Label08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(593, 150)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 20)
        Me.Label12.TabIndex = 1668
        Me.Label12.Text = "売上数"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(593, 170)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 1667
        Me.Label13.Text = "単価"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.Location = New System.Drawing.Point(853, 152)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(100, 20)
        Me.Date1.TabIndex = 1632
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2012, 1, 17, 17, 14, 49, 0))
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(769, 152)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 20)
        Me.Label19.TabIndex = 1684
        Me.Label19.Text = "計上日"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label017
        '
        Me.Label017.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label017.Location = New System.Drawing.Point(961, 34)
        Me.Label017.Name = "Label017"
        Me.Label017.Size = New System.Drawing.Size(116, 20)
        Me.Label017.TabIndex = 1683
        Me.Label017.Text = "Label017"
        Me.Label017.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label190
        '
        Me.Label190.BackColor = System.Drawing.Color.Navy
        Me.Label190.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label190.ForeColor = System.Drawing.Color.White
        Me.Label190.Location = New System.Drawing.Point(877, 34)
        Me.Label190.Name = "Label190"
        Me.Label190.Size = New System.Drawing.Size(84, 20)
        Me.Label190.TabIndex = 1682
        Me.Label190.Text = "処理日"
        Me.Label190.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number2
        '
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,##0", "", "", "-", "", "", "0")
        Me.Number2.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number2.Format = New GrapeCity.Win.Input.NumberFormat("#,###,##0", "", "", "-", "", "", "0")
        Me.Number2.Location = New System.Drawing.Point(677, 170)
        Me.Number2.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number2.Name = "Number2"
        Me.Number2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number2.Size = New System.Drawing.Size(84, 20)
        Me.Number2.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.TabIndex = 1625
        Me.Number2.Value = Nothing
        '
        'Number1
        '
        Me.Number1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(192, 179)
        Me.Number1.Location = New System.Drawing.Point(677, 150)
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(84, 20)
        Me.Number1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.TabIndex = 1624
        Me.Number1.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label04
        '
        Me.Label04.BackColor = System.Drawing.Color.Navy
        Me.Label04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label04.ForeColor = System.Drawing.Color.White
        Me.Label04.Location = New System.Drawing.Point(9, 190)
        Me.Label04.Name = "Label04"
        Me.Label04.Size = New System.Drawing.Size(84, 20)
        Me.Label04.TabIndex = 1663
        Me.Label04.Text = "品名ｶﾅ"
        Me.Label04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.Navy
        Me.Label02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label02.ForeColor = System.Drawing.Color.White
        Me.Label02.Location = New System.Drawing.Point(9, 150)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(84, 20)
        Me.Label02.TabIndex = 1662
        Me.Label02.Text = "商品ｺｰﾄﾞ"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label016
        '
        Me.Label016.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label016.Location = New System.Drawing.Point(753, 114)
        Me.Label016.Name = "Label016"
        Me.Label016.Size = New System.Drawing.Size(116, 20)
        Me.Label016.TabIndex = 1660
        Me.Label016.Text = "Label016"
        Me.Label016.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label015
        '
        Me.Label015.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label015.Location = New System.Drawing.Point(753, 94)
        Me.Label015.Name = "Label015"
        Me.Label015.Size = New System.Drawing.Size(116, 20)
        Me.Label015.TabIndex = 1659
        Me.Label015.Text = "Label015"
        Me.Label015.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label014
        '
        Me.Label014.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label014.Location = New System.Drawing.Point(345, 114)
        Me.Label014.Name = "Label014"
        Me.Label014.Size = New System.Drawing.Size(316, 20)
        Me.Label014.TabIndex = 1658
        Me.Label014.Text = "Label014"
        Me.Label014.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label013
        '
        Me.Label013.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label013.Location = New System.Drawing.Point(345, 94)
        Me.Label013.Name = "Label013"
        Me.Label013.Size = New System.Drawing.Size(316, 20)
        Me.Label013.TabIndex = 1657
        Me.Label013.Text = "Label013"
        Me.Label013.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label012
        '
        Me.Label012.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label012.Location = New System.Drawing.Point(345, 74)
        Me.Label012.Name = "Label012"
        Me.Label012.Size = New System.Drawing.Size(316, 20)
        Me.Label012.TabIndex = 1656
        Me.Label012.Text = "Label012"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label011
        '
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.Location = New System.Drawing.Point(345, 54)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(316, 20)
        Me.Label011.TabIndex = 1655
        Me.Label011.Text = "Label011"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label010
        '
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.Location = New System.Drawing.Point(345, 34)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(316, 20)
        Me.Label010.TabIndex = 1654
        Me.Label010.Text = "Label010"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label009
        '
        Me.Label009.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label009.Location = New System.Drawing.Point(93, 94)
        Me.Label009.Name = "Label009"
        Me.Label009.Size = New System.Drawing.Size(160, 20)
        Me.Label009.TabIndex = 1653
        Me.Label009.Text = "Label009"
        Me.Label009.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label008
        '
        Me.Label008.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label008.Location = New System.Drawing.Point(93, 74)
        Me.Label008.Name = "Label008"
        Me.Label008.Size = New System.Drawing.Size(160, 20)
        Me.Label008.TabIndex = 1652
        Me.Label008.Text = "Label008"
        Me.Label008.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label007
        '
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.Location = New System.Drawing.Point(93, 54)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(160, 20)
        Me.Label007.TabIndex = 1651
        Me.Label007.Text = "Label007"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label006
        '
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.Location = New System.Drawing.Point(93, 34)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(160, 20)
        Me.Label006.TabIndex = 1650
        Me.Label006.Text = "Label006"
        Me.Label006.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label005
        '
        Me.Label005.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label005.Location = New System.Drawing.Point(753, 74)
        Me.Label005.Name = "Label005"
        Me.Label005.Size = New System.Drawing.Size(116, 20)
        Me.Label005.TabIndex = 1649
        Me.Label005.Text = "Label005"
        Me.Label005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.Location = New System.Drawing.Point(753, 54)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(116, 20)
        Me.Label004.TabIndex = 1648
        Me.Label004.Text = "Label004"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label003
        '
        Me.Label003.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label003.Location = New System.Drawing.Point(753, 34)
        Me.Label003.Name = "Label003"
        Me.Label003.Size = New System.Drawing.Size(116, 20)
        Me.Label003.TabIndex = 1647
        Me.Label003.Text = "Label003"
        Me.Label003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.Color.Navy
        Me.Label120.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label120.ForeColor = System.Drawing.Color.White
        Me.Label120.Location = New System.Drawing.Point(669, 114)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(84, 20)
        Me.Label120.TabIndex = 1646
        Me.Label120.Text = "完了日"
        Me.Label120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.Color.Navy
        Me.Label110.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label110.ForeColor = System.Drawing.Color.White
        Me.Label110.Location = New System.Drawing.Point(669, 94)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(84, 20)
        Me.Label110.TabIndex = 1645
        Me.Label110.Text = "販売者ｺｰﾄﾞ"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.Color.Navy
        Me.Label100.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label100.ForeColor = System.Drawing.Color.White
        Me.Label100.Location = New System.Drawing.Point(261, 34)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(84, 100)
        Me.Label100.TabIndex = 1644
        Me.Label100.Text = "住所"
        Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 1643
        Me.Label9.Text = "郵便番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 1642
        Me.Label8.Text = "TEL2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 1641
        Me.Label7.Text = "TEL1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 1640
        Me.Label6.Text = "氏名"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(669, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 1639
        Me.Label5.Text = "一般売掛区分"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(669, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 1638
        Me.Label4.Text = "配送店ｺｰﾄﾞ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(669, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 1637
        Me.Label3.Text = "発行日"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(81, 590)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(920, 16)
        Me.msg.TabIndex = 1636
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(9, 582)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 32)
        Me.Button1.TabIndex = 1633
        Me.Button1.Text = "登　録"
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(1005, 582)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(64, 32)
        Me.Button99.TabIndex = 1634
        Me.Button99.Text = "戻　る"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(0, Byte))
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(9, 6)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(76, 20)
        Me.Label43.TabIndex = 1635
        Me.Label43.Text = "伝票NO"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Edit1.Format = "9"
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(85, 6)
        Me.Edit1.MaxLength = 20
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(124, 20)
        Me.Edit1.TabIndex = 1613
        '
        'Edit05
        '
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(384, 152)
        Me.Edit05.MaxLength = 100
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(200, 20)
        Me.Edit05.TabIndex = 1685
        Me.Edit05.Text = "Edit05"
        '
        'Edit06
        '
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(384, 172)
        Me.Edit06.MaxLength = 100
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(200, 20)
        Me.Edit06.TabIndex = 1686
        Me.Edit06.Text = "Edit06"
        '
        'Form6
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1106, 620)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Label03)
        Me.Controls.Add(Me.Label07)
        Me.Controls.Add(Me.Label08)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label017)
        Me.Controls.Add(Me.Label190)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Label04)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label016)
        Me.Controls.Add(Me.Label015)
        Me.Controls.Add(Me.Label014)
        Me.Controls.Add(Me.Label013)
        Me.Controls.Add(Me.Label012)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Label009)
        Me.Controls.Add(Me.Label008)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label120)
        Me.Controls.Add(Me.Label110)
        Me.Controls.Add(Me.Label100)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Edit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "保証登録"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DsList2.Clear()
        strSQL = "SELECT 分類ｺｰﾄﾞ, 商品ｺｰﾄﾞ, 品名ｶﾅ, 品名漢字, 品種ｺｰﾄﾞ"
        strSQL += " FROM [02_売上データ]"
        strSQL += " WHERE (dlt_f = 0)"
        strSQL += " GROUP BY 分類ｺｰﾄﾞ, 商品ｺｰﾄﾞ, 品名ｶﾅ, 品名漢字, 品種ｺｰﾄﾞ"
        strSQL += " HAVING (分類ｺｰﾄﾞ = '30') OR (分類ｺｰﾄﾞ = '91')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList2, "02_売上データ")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList2.Tables("02_売上データ")
        DataGrid1.DataSource = tbl

        Edit1.Text = Nothing
        clr()

    End Sub

    '********************************************************************
    '**  取込み情報取得
    '********************************************************************
    Sub scan()
        msg.Text = Nothing
        clr()

        DsList1.Clear()
        strSQL = "SELECT *"
        strSQL += " FROM [02_売上データ]"
        strSQL += " WHERE (伝票NO = '" & Edit1.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(DsList1, "02_売上データ")
        DB_CLOSE()

        If r = 0 Then
            msg.Text = "該当なし"
        Else
            Label1.Visible = False
            DtView1 = New DataView(DsList1.Tables("02_売上データ"), "", "", DataViewRowState.CurrentRows)
            Label003.Text = DtView1(0)("発行日")
            Label004.Text = DtView1(0)("配送店ｺｰﾄﾞ")
            Label005.Text = DtView1(0)("一般売掛区分")
            Label006.Text = DtView1(0)("氏名")
            Label007.Text = DtView1(0)("TEL1")
            Label008.Text = DtView1(0)("TEL2")
            Label009.Text = DtView1(0)("郵便番号")
            Label010.Text = DtView1(0)("住所1")
            Label011.Text = DtView1(0)("住所2")
            Label012.Text = DtView1(0)("住所3")
            Label013.Text = DtView1(0)("住所4")
            Label014.Text = DtView1(0)("住所5")
            Label015.Text = DtView1(0)("販売者ｺｰﾄﾞ")
            Label016.Text = DtView1(0)("完了日")
            Label017.Text = DtView1(0)("処理日")
            Date1.Text = P_DATE

            Label02.Visible = True : Edit02.Visible = True : Edit02.Focus()
            Label03.Visible = True : Edit03.Visible = True
            Label04.Visible = True : Edit04.Visible = True
            Label07.Visible = True : Edit05.Visible = True
            Label08.Visible = True : Edit06.Visible = True
            Label12.Visible = True : Number1.Visible = True
            Label13.Visible = True : Number2.Visible = True
            Label19.Visible = True : Date1.Visible = True

            DataGrid1.Visible = True

            Button1.Enabled = True
        End If

    End Sub

    Sub clr()
        msg.Text = Nothing
        Label1.Visible = True

        Edit02.Text = Nothing
        Edit03.Text = Nothing
        Edit04.Text = Nothing
        Edit05.Text = Nothing
        Edit06.Text = Nothing
        Number1.Value = 0
        Number2.Value = 0

        Label02.Visible = False : Edit02.Visible = False
        Label03.Visible = False : Edit03.Visible = False
        Label04.Visible = False : Edit04.Visible = False
        Label07.Visible = False : Edit05.Visible = False
        Label08.Visible = False : Edit06.Visible = False
        Label12.Visible = False : Number1.Visible = False
        Label13.Visible = False : Number2.Visible = False
        Label19.Visible = False : Date1.Visible = False

        DataGrid1.Visible = False

        Button1.Enabled = False
    End Sub

    '********************************************************************
    '** 項目チェック
    '********************************************************************
    Sub F_chk()
        Err_F = "0"

        CK_Edit02()
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        CK_Edit03()
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        CK_Edit04()
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        CK_Edit05()
        If msg.Text <> Nothing Then Err_F = "1" : Edit05.Focus() : Exit Sub

        CK_Edit06()
        If msg.Text <> Nothing Then Err_F = "1" : Edit06.Focus() : Exit Sub

        CK_Number1()
        If msg.Text <> Nothing Then Err_F = "1" : Number1.Focus() : Exit Sub

        CK_Number2()
        If msg.Text <> Nothing Then Err_F = "1" : Number2.Focus() : Exit Sub


    End Sub
    Sub CK_Edit02()
        msg.Text = Nothing

        If Edit02.Text = Nothing Then
            msg.Text = "商品ｺｰﾄﾞ入力必須"
        Else
            If LenB(Edit02.Text) <> 13 Then
                msg.Text = "商品ｺｰﾄﾞは13桁"
            End If
        End If
    End Sub
    Sub CK_Edit03()
        msg.Text = Nothing

        If Edit03.Text = Nothing Then
            msg.Text = "品名漢字入力必須"
        End If
    End Sub
    Sub CK_Edit04()
        msg.Text = Nothing

        If Edit04.Text = Nothing Then
            msg.Text = "品名ｶﾅ入力必須"
        End If
    End Sub
    Sub CK_Edit05()
        msg.Text = Nothing
    End Sub
    Sub CK_Edit06()
        msg.Text = Nothing
    End Sub
    Sub CK_Number1()
        msg.Text = Nothing

        If Number1.Value = 0 Then
            msg.Text = "売上数入力必須"
        End If
    End Sub
    Sub CK_Number2()
        msg.Text = Nothing

        If Number2.Value = 0 Then
            msg.Text = "単価入力必須"
        End If
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        Edit1.Text = Trim(Edit1.Text)
        If BR_Edit1 <> Edit1.Text Then
            scan()    '**  取込み情報取得
            BR_Edit1 = Edit1.Text
        End If
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGrid1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
        If DataGrid1.CurrentRowIndex >= 0 Then
            DataGrid1.Select(DataGrid1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then

                Edit02.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 0))
                Edit03.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 1))
                Edit04.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 2))
                Edit05.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 3))
                Edit06.Text = Trim(DataGrid1(DataGrid1.CurrentRowIndex, 4))

                Number1.Value = 1
                Number2.Value = 0

            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  登録
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_chk()
        If Err_F = "0" Then

            strSQL = "INSERT INTO [02_売上データ]"
            strSQL += " (伝票NO, 発行日, 配送店ｺｰﾄﾞ, 一般売掛区分, 氏名, TEL1, TEL2, 郵便番号, 住所1, 住所2"
            strSQL += ", 住所3, 住所4, 住所5, 販売者ｺｰﾄﾞ, 完了日, 削除ﾌﾗｸﾞ, 行番号, 行区分, 商品ｺｰﾄﾞ, 品名ｶﾅ"
            strSQL += ", 型番ｶﾅ, ｶﾗｰ, ｻｲｽﾞ, ﾚｼｰﾄ, 品名漢字, 型番漢字, 分類ｺｰﾄﾞ, 品種ｺｰﾄﾞ, 売上数, ﾏｽﾀ単価, 単価"
            strSQL += ", 税区分, 値引割引区分, 割引率, 値引額, 単価2, 商品ｺｰﾄﾞ_元, 分割数量, 分割元SEQ, 赤黒SEQ"
            strSQL += ", sprice, WSEQ1, WSEQ2, ERR_F, 法人, 集計区分, 処理日, 処理日2, 元SEQ, dlt_f, wrn_add_f)"
            strSQL += " VALUES ('" & Edit1.Text & "'"       '伝票NO
            strSQL += ", N'" & Label003.Text & "'"          '発行日
            strSQL += ", '" & Label004.Text & "'"           '配送店ｺｰﾄﾞ
            strSQL += ", '" & Label005.Text & "'"           '一般売掛区分
            strSQL += ", '" & Label006.Text & "'"           '氏名
            strSQL += ", '" & Label007.Text & "'"           'TEL1
            strSQL += ", '" & Label008.Text & "'"           'TEL2
            strSQL += ", '" & Label009.Text & "'"           '郵便番号
            strSQL += ", '" & Label010.Text & "'"           '住所1
            strSQL += ", '" & Label011.Text & "'"           '住所2
            strSQL += ", '" & Label012.Text & "'"           '住所3
            strSQL += ", '" & Label013.Text & "'"           '住所4
            strSQL += ", '" & Label014.Text & "'"           '住所5
            strSQL += ", '" & Label015.Text & "'"           '販売者ｺｰﾄﾞ
            strSQL += ", N'" & Label016.Text & "'"          '完了日
            strSQL += ", '0'"                               '削除ﾌﾗｸﾞ
            strSQL += ", 0"                                 '行番号
            strSQL += ", '0'"                               '行区分
            strSQL += ", '" & Edit02.Text & "'"             '商品ｺｰﾄﾞ
            strSQL += ", '" & Edit04.Text & "'"             '品名ｶﾅ
            strSQL += ", ''"                                '型番ｶﾅ
            strSQL += ", ''"                                'ｶﾗｰ
            strSQL += ", ''"                                'ｻｲｽﾞ
            strSQL += ", ''"                                'ﾚｼｰﾄ
            strSQL += ", '" & Edit03.Text & "'"             '品名漢字
            strSQL += ", ''"                                '型番漢字
            strSQL += ", '" & Edit05.Text & "'"             '分類ｺｰﾄﾞ
            strSQL += ", '" & Edit06.Text & "'"             '品種ｺｰﾄﾞ
            strSQL += ", " & Number1.Value                  '売上数
            strSQL += ", 0"                                 'ﾏｽﾀ単価
            strSQL += ", " & Number2.Value                  '単価
            strSQL += ", '5'"                               '税区分
            strSQL += ", '0'"                               '値引割引区分
            strSQL += ", 0"                                 '割引率
            strSQL += ", 0"                                 '値引額
            strSQL += ", " & Number2.Value                  '単価2
            strSQL += ", Null"                              '商品ｺｰﾄﾞ_元
            strSQL += ", " & Number1.Value                  '分割数量
            strSQL += ", 0"                                 '分割元SEQ
            strSQL += ", 0"                                 '赤黒SEQ
            strSQL += ", 0"                                 'sprice
            strSQL += ", 0"                                 'WSEQ1
            strSQL += ", 0"                                 'WSEQ2
            strSQL += ", '0'"                               'ERR_F
            strSQL += ", 0"                                 '法人
            strSQL += ", Null"                              '集計区分
            strSQL += ", N'" & Label017.Text & "'"          '処理日
            strSQL += ", N'" & Date1.Text & "'"             '処理日2
            strSQL += ", Null"                              '元SEQ
            strSQL += ", 0"                                 'dlt_f
            strSQL += ", 0)"                                'wrn_add_f
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN()
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            MsgBox("登録しました")
            clr()

            Edit1.Text = Nothing
            BR_Edit1 = "Null"

        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        DsList2.Clear()
        DsCMB.Clear()
        Close()
    End Sub
End Class
