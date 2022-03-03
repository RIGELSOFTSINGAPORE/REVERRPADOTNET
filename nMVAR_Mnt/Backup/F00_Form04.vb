Public Class F00_Form04
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, DsCMB2 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F As String

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
    Friend WithEvents DataGridEx1 As nMVAR_Mnt.DataGridEx
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Edit
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label_cnt As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo004 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents CL004 As System.Windows.Forms.Label
    Friend WithEvents CL005 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Combo
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CL006 As System.Windows.Forms.Label
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL007 As System.Windows.Forms.Label
    Friend WithEvents Combo007 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGridEx1 = New nMVAR_Mnt.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Edit002 = New GrapeCity.Win.Input.Edit
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Label010 = New System.Windows.Forms.Label
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Date2 = New GrapeCity.Win.Input.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Edit004 = New GrapeCity.Win.Input.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Edit005 = New GrapeCity.Win.Input.Edit
        Me.Label12 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Edit006 = New GrapeCity.Win.Input.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_cnt = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.CL001 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.CL003 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.CL004 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Combo004 = New GrapeCity.Win.Input.Combo
        Me.CL005 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Combo005 = New GrapeCity.Win.Input.Combo
        Me.CL006 = New System.Windows.Forms.Label
        Me.Label006 = New System.Windows.Forms.Label
        Me.Combo006 = New GrapeCity.Win.Input.Combo
        Me.CL007 = New System.Windows.Forms.Label
        Me.Label007 = New System.Windows.Forms.Label
        Me.Combo007 = New GrapeCity.Win.Input.Combo
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(20, 176)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(964, 472)
        Me.DataGridEx1.TabIndex = 200
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "scan"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "受付番号"
        Me.DataGridTextBoxColumn1.MappingName = "rcpt_no"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 85
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "受付日"
        Me.DataGridTextBoxColumn2.MappingName = "accp_date"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 80
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "お客様名"
        Me.DataGridTextBoxColumn3.MappingName = "user_name"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 120
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "販社修理番号"
        Me.DataGridTextBoxColumn7.MappingName = "store_repr_no"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 115
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "メーカー修理番号"
        Me.DataGridTextBoxColumn8.MappingName = "vndr_repr_no"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 115
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "S/N"
        Me.DataGridTextBoxColumn9.MappingName = "s_n"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 90
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "入荷部署"
        Me.DataGridTextBoxColumn10.MappingName = "rcpt_brch_name"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 110
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "状況"
        Me.DataGridTextBoxColumn11.MappingName = "stts"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 50
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "販社グループ"
        Me.DataGridTextBoxColumn4.MappingName = "grup_name"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 110
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "販社"
        Me.DataGridTextBoxColumn5.MappingName = "store_name"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 110
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "メーカー"
        Me.DataGridTextBoxColumn6.MappingName = "vndr_name"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "受付種別"
        Me.DataGridTextBoxColumn12.MappingName = "rcpt_name"
        Me.DataGridTextBoxColumn12.ReadOnly = True
        Me.DataGridTextBoxColumn12.Width = 120
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "修理種別"
        Me.DataGridTextBoxColumn13.MappingName = "rpar_name"
        Me.DataGridTextBoxColumn13.ReadOnly = True
        Me.DataGridTextBoxColumn13.Width = 90
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 660)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 300
        Me.Button98.Text = "戻る"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(20, 144)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 24)
        Me.Button4.TabIndex = 100
        Me.Button4.Text = "検索"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 24)
        Me.Label4.TabIndex = 1263
        Me.Label4.Text = "ｶﾅ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit002
        '
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.Format = "K"
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(132, 72)
        Me.Edit002.MaxLength = 15
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(232, 24)
        Me.Edit002.TabIndex = 3
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit001
        '
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(132, 44)
        Me.Edit001.MaxLength = 30
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(232, 24)
        Me.Edit001.TabIndex = 2
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label010
        '
        Me.Label010.BackColor = System.Drawing.Color.Navy
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.ForeColor = System.Drawing.Color.White
        Me.Label010.Location = New System.Drawing.Point(20, 44)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(112, 24)
        Me.Label010.TabIndex = 1262
        Me.Label010.Text = "お客様名"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit003
        '
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.Format = "9#"
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(132, 100)
        Me.Edit003.MaxLength = 14
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(116, 24)
        Me.Edit003.TabIndex = 4
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label011
        '
        Me.Label011.BackColor = System.Drawing.Color.Navy
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.ForeColor = System.Drawing.Color.White
        Me.Label011.Location = New System.Drawing.Point(20, 100)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(112, 24)
        Me.Label011.TabIndex = 1265
        Me.Label011.Text = "電話番号"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(236, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 1269
        Me.Label2.Text = "～"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(132, 16)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(104, 24)
        Me.Date1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.TabIndex = 0
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.Value = Nothing
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(260, 16)
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(104, 24)
        Me.Date2.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.TabIndex = 1
        Me.Date2.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date2.Value = Nothing
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(20, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(112, 24)
        Me.Label35.TabIndex = 1268
        Me.Label35.Text = "受付日"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit004
        '
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit004.Location = New System.Drawing.Point(492, 16)
        Me.Edit004.MaxLength = 30
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(184, 24)
        Me.Edit004.TabIndex = 5
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(380, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 24)
        Me.Label6.TabIndex = 1273
        Me.Label6.Text = "メーカー修理№"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit005
        '
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.Format = "9#aA"
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(492, 44)
        Me.Edit005.MaxLength = 25
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(184, 24)
        Me.Edit005.TabIndex = 6
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(380, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 24)
        Me.Label12.TabIndex = 1275
        Me.Label12.Text = "販社修理番号"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 660)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(872, 24)
        Me.msg.TabIndex = 1276
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(120, 144)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 110
        Me.Button1.Text = "クリア"
        '
        'Edit006
        '
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Format = "9#aA"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(492, 72)
        Me.Edit006.MaxLength = 20
        Me.Edit006.Name = "Edit006"
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(184, 24)
        Me.Edit006.TabIndex = 7
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(380, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 1279
        Me.Label1.Text = "S/N"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_cnt
        '
        Me.Label_cnt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label_cnt.ForeColor = System.Drawing.Color.White
        Me.Label_cnt.Location = New System.Drawing.Point(884, 180)
        Me.Label_cnt.Name = "Label_cnt"
        Me.Label_cnt.Size = New System.Drawing.Size(88, 16)
        Me.Label_cnt.TabIndex = 1280
        Me.Label_cnt.Text = "Label_cnt"
        Me.Label_cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(380, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 1282
        Me.Label7.Text = "入荷部署"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo001.Location = New System.Drawing.Point(492, 100)
        Me.Combo001.MaxDropDownItems = 30
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(184, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 8
        Me.Combo001.Value = "Combo001"
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(644, 100)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(44, 24)
        Me.CL001.TabIndex = 1283
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(380, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 1285
        Me.Label3.Text = "状況"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo002.Items.AddRange(New GrapeCity.Win.Input.ComboItem() {New GrapeCity.Win.Input.ComboItem(0, Nothing, "入荷", Nothing, "", System.Drawing.Color.Transparent, True, System.Drawing.Color.Empty, "", True), New GrapeCity.Win.Input.ComboItem(0, Nothing, "見積", Nothing, "", System.Drawing.Color.Transparent, True, System.Drawing.Color.Empty, Nothing, True), New GrapeCity.Win.Input.ComboItem(0, Nothing, "完了", Nothing, "", System.Drawing.Color.Transparent, True, System.Drawing.Color.Empty, Nothing, True)})
        Me.Combo002.Location = New System.Drawing.Point(492, 128)
        Me.Combo002.MaxDropDownItems = 30
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(184, 24)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 9
        Me.Combo002.Value = "Combo002"
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(956, 16)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(44, 24)
        Me.CL003.TabIndex = 1288
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(692, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 24)
        Me.Label8.TabIndex = 1287
        Me.Label8.Text = "販社グループ"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo003
        '
        Me.Combo003.AutoSelect = True
        Me.Combo003.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo003.Location = New System.Drawing.Point(804, 16)
        Me.Combo003.MaxDropDownItems = 30
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(184, 24)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 10
        Me.Combo003.Value = "Combo003"
        '
        'CL004
        '
        Me.CL004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL004.Location = New System.Drawing.Point(956, 44)
        Me.CL004.Name = "CL004"
        Me.CL004.Size = New System.Drawing.Size(44, 24)
        Me.CL004.TabIndex = 1291
        Me.CL004.Text = "CL004"
        Me.CL004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL004.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(692, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 24)
        Me.Label10.TabIndex = 1290
        Me.Label10.Text = "販社"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo004
        '
        Me.Combo004.AutoSelect = True
        Me.Combo004.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo004.Location = New System.Drawing.Point(804, 44)
        Me.Combo004.MaxDropDownItems = 30
        Me.Combo004.Name = "Combo004"
        Me.Combo004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo004.Size = New System.Drawing.Size(184, 24)
        Me.Combo004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo004.TabIndex = 11
        Me.Combo004.Value = "Combo004"
        '
        'CL005
        '
        Me.CL005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL005.Location = New System.Drawing.Point(956, 72)
        Me.CL005.Name = "CL005"
        Me.CL005.Size = New System.Drawing.Size(44, 24)
        Me.CL005.TabIndex = 1294
        Me.CL005.Text = "CL005"
        Me.CL005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL005.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(692, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 24)
        Me.Label9.TabIndex = 1293
        Me.Label9.Text = "メーカー"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo005
        '
        Me.Combo005.AutoSelect = True
        Me.Combo005.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo005.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo005.Location = New System.Drawing.Point(804, 72)
        Me.Combo005.MaxDropDownItems = 30
        Me.Combo005.Name = "Combo005"
        Me.Combo005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo005.Size = New System.Drawing.Size(184, 24)
        Me.Combo005.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo005.TabIndex = 12
        Me.Combo005.Value = "Combo005"
        '
        'CL006
        '
        Me.CL006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL006.Location = New System.Drawing.Point(956, 100)
        Me.CL006.Name = "CL006"
        Me.CL006.Size = New System.Drawing.Size(44, 24)
        Me.CL006.TabIndex = 1297
        Me.CL006.Text = "CL006"
        Me.CL006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL006.Visible = False
        '
        'Label006
        '
        Me.Label006.BackColor = System.Drawing.Color.Navy
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.ForeColor = System.Drawing.Color.White
        Me.Label006.Location = New System.Drawing.Point(692, 100)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(112, 24)
        Me.Label006.TabIndex = 1296
        Me.Label006.Text = "受付種別"
        Me.Label006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label006.Visible = False
        '
        'Combo006
        '
        Me.Combo006.AutoSelect = True
        Me.Combo006.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo006.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo006.Location = New System.Drawing.Point(804, 100)
        Me.Combo006.MaxDropDownItems = 30
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(184, 24)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 13
        Me.Combo006.Value = "Combo006"
        Me.Combo006.Visible = False
        '
        'CL007
        '
        Me.CL007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL007.Location = New System.Drawing.Point(956, 128)
        Me.CL007.Name = "CL007"
        Me.CL007.Size = New System.Drawing.Size(44, 24)
        Me.CL007.TabIndex = 1300
        Me.CL007.Text = "CL007"
        Me.CL007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL007.Visible = False
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(692, 128)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(112, 24)
        Me.Label007.TabIndex = 1299
        Me.Label007.Text = "修理種別"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label007.Visible = False
        '
        'Combo007
        '
        Me.Combo007.AutoSelect = True
        Me.Combo007.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo007.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo007.Location = New System.Drawing.Point(804, 128)
        Me.Combo007.MaxDropDownItems = 30
        Me.Combo007.Name = "Combo007"
        Me.Combo007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo007.Size = New System.Drawing.Size(184, 24)
        Me.Combo007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo007.TabIndex = 14
        Me.Combo007.Value = "Combo007"
        Me.Combo007.Visible = False
        '
        'F00_Form04
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.CL007)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Combo007)
        Me.Controls.Add(Me.CL006)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.CL005)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Combo005)
        Me.Controls.Add(Me.CL004)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Combo004)
        Me.Controls.Add(Me.CL003)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Combo003)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label_cnt)
        Me.Controls.Add(Me.Edit006)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form04"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "あいまい検索"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '**  コンボボックスセット

        If P_EMPL_NO < 0 Then   '受付種別、修理種別表示
            Label006.Visible = True : Combo006.Visible = True
            Label007.Visible = True : Combo007.Visible = True
        End If
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        DsList1.Clear()
        strSQL = "SELECT rcpt_no, accp_date, user_name, user_name_kana, tel1, tel2, store_repr_no, vndr_repr_no, s_n"
        strSQL = strSQL & ", '' AS rcpt_brch_name, '' AS stts, '' AS grup_name, '' AS store_name, '' AS vndr_name"
        strSQL = strSQL & " FROM T01_REP_MTR"
        strSQL = strSQL & " WHERE (rcpt_no IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "scan")
        DB_CLOSE()
        DsList1.Tables("scan").Clear()

        DtView1 = New DataView(DsList1.Tables("scan"), "", "", DataViewRowState.CurrentRows)

        Dim tbl As New DataTable
        tbl = DsList1.Tables("scan")
        DataGridEx1.DataSource = tbl

        P_RTN = "0"
        msg.Text = Nothing
        Label_cnt.Text = Nothing
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        '部署
        strSQL = "SELECT brch_code, brch_code + ':' + name AS brch_name"
        strSQL = strSQL & " FROM M03_BRCH"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M03_BRCH")

        Combo001.DataSource = DsCMB.Tables("M03_BRCH")
        Combo001.DisplayMember = "brch_name"
        Combo001.ValueMember = "brch_code"

        Combo001.Text = Nothing
        CL001.Text = Nothing

        Combo002.Text = Nothing

        '販社グループ
        strSQL = "SELECT M08_STORE.grup_code, M08_STORE.grup_code + ':' + cls006.cls_code_name AS grup_name"
        strSQL = strSQL & " FROM M08_STORE INNER JOIN"
        strSQL = strSQL & " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '006')) cls006 ON"
        strSQL = strSQL & " M08_STORE.grup_code = cls006.cls_code COLLATE Japanese_CI_AS"
        strSQL = strSQL & " AND (dbo.M08_STORE.delt_flg = 0)"
        strSQL = strSQL & " GROUP BY M08_STORE.grup_code, M08_STORE.grup_code + ':' + cls006.cls_code_name"
        strSQL = strSQL & " ORDER BY M08_STORE.grup_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_006")

        Combo003.DataSource = DsCMB.Tables("CLS_CODE_006")
        Combo003.DisplayMember = "grup_name"
        Combo003.ValueMember = "grup_code"
        Combo003.Text = Nothing
        CL003.Text = Nothing

        'メーカー
        strSQL = "SELECT vndr_code, vndr_code + ':' + name AS vndr_name"
        strSQL = strSQL & " FROM M05_VNDR"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M05_VNDR")

        Combo005.DataSource = DsCMB.Tables("M05_VNDR")
        Combo005.DisplayMember = "vndr_name"
        Combo005.ValueMember = "vndr_code"
        Combo005.Text = Nothing
        CL005.Text = Nothing

        '受付種別
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '007') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_007")

        Combo006.DataSource = DsCMB.Tables("CLS_CODE_007")
        Combo006.DisplayMember = "cls_code_name"
        Combo006.ValueMember = "cls_code"
        Combo006.Text = Nothing
        CL006.Text = Nothing

        '修理種別
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '001') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_001")

        Combo007.DataSource = DsCMB.Tables("CLS_CODE_001")
        Combo007.DisplayMember = "cls_code_name"
        Combo007.ValueMember = "cls_code"
        Combo007.Text = Nothing
        CL007.Text = Nothing

        DB_CLOSE()

        CmbSet2()
    End Sub
    Sub CmbSet2()
        DB_OPEN("nMVAR")

        '販社
        DsCMB2.Clear()
        strSQL = "SELECT store_code, store_code + ':' + name AS name"
        strSQL = strSQL & " FROM M08_STORE"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        If CL003.Text <> Nothing Then strSQL = strSQL & " AND (grup_code = '" & CL003.Text & "')"
        strSQL = strSQL & " ORDER BY grup_code, name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB2, "M08_STORE")

        Combo004.DataSource = DsCMB2.Tables("M08_STORE")
        Combo004.DisplayMember = "name"
        Combo004.ValueMember = "store_code"
        Combo004.Text = Nothing
        CL004.Text = Nothing

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGridEx1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　エンター
    '********************************************************************
    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent

        If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    P_RTN = "1"
                    P_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                    DsList1.Clear()
                    Close()
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                P_RTN = "1"
                P_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                DsList1.Clear()
                Close()
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Combo001()   '部署
        msg.Text = Nothing
        CL001.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する部署がありません。"
                Exit Sub
            Else
                CL001.Text = DtView1(0)("brch_code")
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo003()   '販社グループ
        msg.Text = Nothing

        Combo003.Text = Trim(Combo003.Text)
        If Combo003.Text = Nothing Then
            If CL003.Text <> Nothing Then
                CL003.Text = Nothing
                CmbSet2()
            End If
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_006"), "grup_name = '" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                CL003.Text = Nothing
                Combo003.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する販社グループがありません。"
                Exit Sub
            Else
                If CL003.Text <> DtView1(0)("grup_code") Then
                    CL003.Text = DtView1(0)("grup_code")
                    CmbSet2()
                End If
            End If
        End If
        Combo003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo004()   '販社
        msg.Text = Nothing
        CL004.Text = Nothing

        Combo004.Text = Trim(Combo004.Text)
        If Combo004.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB2.Tables("M08_STORE"), "name = '" & Combo004.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo004.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する販社がありません。"
                Exit Sub
            Else
                CL004.Text = DtView1(0)("store_code")
            End If
        End If
        Combo004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo005()   'メーカー
        msg.Text = Nothing
        CL005.Text = Nothing

        Combo005.Text = Trim(Combo005.Text)
        If Combo005.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB.Tables("M05_VNDR"), "vndr_name = '" & Combo005.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo005.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するメーカーがありません。"
                Exit Sub
            Else
                CL005.Text = DtView1(0)("vndr_code")
            End If
        End If
        Combo005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo006()   '受付種別
        msg.Text = Nothing
        CL006.Text = Nothing

        Combo006.Text = Trim(Combo006.Text)
        If Combo006.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_007"), "cls_code_name = '" & Combo006.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo006.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する受付種別がありません。"
                Exit Sub
            Else
                CL006.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo007()   '修理種別
        msg.Text = Nothing
        CL007.Text = Nothing

        Combo007.Text = Trim(Combo007.Text)
        If Combo007.Text = Nothing Then
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_001"), "cls_code_name = '" & Combo007.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo007.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する修理種別がありません。"
                Exit Sub
            Else
                CL007.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        CHK_Combo001()  '部署
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Combo003()  '販社グループ
        If msg.Text <> Nothing Then Err_F = "1" : Combo003.Focus() : Exit Sub

        CHK_Combo004()  '販社
        If msg.Text <> Nothing Then Err_F = "1" : Combo004.Focus() : Exit Sub

        CHK_Combo005()  'メーカー
        If msg.Text <> Nothing Then Err_F = "1" : Combo005.Focus() : Exit Sub

        CHK_Combo006()  '受付種別
        If msg.Text <> Nothing Then Err_F = "1" : Combo006.Focus() : Exit Sub

        CHK_Combo007()  '修理種別
        If msg.Text <> Nothing Then Err_F = "1" : Combo007.Focus() : Exit Sub

    End Sub

    '********************************************************************
    '**  検索
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing

        F_Check()   '**  項目チェック
        If Err_F = "0" Then

            DsList1.Clear()
            strSQL = "SELECT T01_REP_MTR.rcpt_no, T01_REP_MTR.accp_date, T01_REP_MTR.user_name, T01_REP_MTR.user_name_kana"
            strSQL = strSQL & ", T01_REP_MTR.tel1, T01_REP_MTR.tel2, T01_REP_MTR.store_repr_no, T01_REP_MTR.vndr_repr_no"
            strSQL = strSQL & ", T01_REP_MTR.s_n, T01_REP_MTR.rcpt_brch_code, M03_BRCH.name AS rcpt_brch_name"
            strSQL = strSQL & ", V_cls_006.cls_code_name AS grup_name, M08_STORE.name AS store_name"
            strSQL = strSQL & ", CASE WHEN T01_REP_MTR.comp_date IS NOT NULL THEN '完了' ELSE CASE WHEN T01_REP_MTR.etmt_date IS NOT NULL THEN '見積' ELSE '入荷' END END AS stts"
            strSQL = strSQL & ", T01_REP_MTR.vndr_code, M05_VNDR.name AS vndr_name, T01_REP_MTR.rcpt_cls"
            strSQL = strSQL & ", V_cls_007.cls_code_name AS rcpt_name, T01_REP_MTR.rpar_cls, V_cls_001.cls_code_name AS rpar_name"
            strSQL = strSQL & " FROM T01_REP_MTR INNER JOIN"
            strSQL = strSQL & " M03_BRCH ON T01_REP_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
            strSQL = strSQL & " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
            strSQL = strSQL & " V_cls_006 ON M08_STORE.grup_code = V_cls_006.cls_code INNER JOIN"
            strSQL = strSQL & " M05_VNDR ON T01_REP_MTR.vndr_code = M05_VNDR.vndr_code INNER JOIN"
            strSQL = strSQL & " V_cls_001 ON T01_REP_MTR.rpar_cls = V_cls_001.cls_code INNER JOIN"
            strSQL = strSQL & " V_cls_007 ON T01_REP_MTR.rcpt_cls = V_cls_007.cls_code"
            strSQL = strSQL & " WHERE (T01_REP_MTR.rcpt_no IS NOT NULL)"
            If Date1.Number <> 0 Then
                strSQL = strSQL & " AND (T01_REP_MTR.accp_date >= CONVERT(DATETIME, '" & Date1.Text & "', 102))"
            End If
            If Date2.Number <> 0 Then
                strSQL = strSQL & " AND (T01_REP_MTR.accp_date <= CONVERT(DATETIME, '" & Date2.Text & "', 102))"
            End If
            If Edit001.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.user_name LIKE '" & Edit001.Text & "%')"
            End If
            If Edit002.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.user_name_kana LIKE '" & Edit002.Text & "%')"
            End If
            If Edit004.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.store_repr_no LIKE '" & Edit004.Text & "%')"
            End If
            If Edit005.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.vndr_repr_no LIKE '" & Edit005.Text & "%')"
            End If
            If Edit006.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.s_n LIKE '" & Edit006.Text & "%')"
            End If
            If CL001.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.rcpt_brch_code = '" & CL001.Text & "')"
            End If
            If Combo002.Text <> Nothing Then
                strSQL = strSQL & " AND (CASE WHEN T01_REP_MTR.comp_date IS NOT NULL THEN '完了' ELSE CASE WHEN T01_REP_MTR.etmt_date IS NOT NULL THEN '見積' ELSE '入荷' END END = '" & Combo002.Text & "')"
            End If
            If CL003.Text <> Nothing Then
                strSQL = strSQL & " AND (M08_STORE.grup_code = '" & CL003.Text & "')"
            End If
            If CL004.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.store_code = '" & CL004.Text & "')"
            End If
            If CL005.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.vndr_code = '" & CL005.Text & "')"
            End If
            If CL006.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.rcpt_cls = '" & CL006.Text & "')"
            End If
            If CL007.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.rpar_cls = '" & CL007.Text & "')"
            End If
            If Edit003.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.tel1 LIKE '" & Edit003.Text & "%')"
                strSQL = strSQL & " OR (T01_REP_MTR.rcpt_no IS NOT NULL)"

                If Date1.Number <> 0 Then
                    strSQL = strSQL & " AND (T01_REP_MTR.accp_date >= CONVERT(DATETIME, '" & Date1.Text & "', 102))"
                End If
                If Date2.Number <> 0 Then
                    strSQL = strSQL & " AND (T01_REP_MTR.accp_date <= CONVERT(DATETIME, '" & Date2.Text & "', 102))"
                End If
                If Edit001.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.user_name LIKE '" & Edit001.Text & "%')"
                End If
                If Edit002.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.user_name_kana LIKE '" & Edit002.Text & "%')"
                End If
                If Edit004.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.store_repr_no LIKE '" & Edit004.Text & "%')"
                End If
                If Edit005.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.vndr_repr_no LIKE '" & Edit005.Text & "%')"
                End If
                If Edit006.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.s_n LIKE '" & Edit006.Text & "%')"
                End If
                If CL001.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.rcpt_brch_code = '" & CL001.Text & "')"
                End If
                If Combo002.Text <> Nothing Then
                    strSQL = strSQL & " AND (CASE WHEN T01_REP_MTR.comp_date IS NOT NULL THEN '完了' ELSE CASE WHEN T01_REP_MTR.etmt_date IS NOT NULL THEN '見積' ELSE '入荷' END END = '" & Combo002.Text & "')"
                End If
                If CL003.Text <> Nothing Then
                    strSQL = strSQL & " AND (M08_STORE.grup_code = '" & CL003.Text & "')"
                End If
                If CL004.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.store_code = '" & CL004.Text & "')"
                End If
                If CL005.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.vndr_code = '" & CL005.Text & "')"
                End If
                If CL006.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.rcpt_cls = '" & CL006.Text & "')"
                End If
                If CL007.Text <> Nothing Then
                    strSQL = strSQL & " AND (T01_REP_MTR.rpar_cls = '" & CL007.Text & "')"
                End If
                strSQL = strSQL & " AND (T01_REP_MTR.tel2 LIKE '" & Edit003.Text & "%')"
            End If
            strSQL = strSQL & " ORDER BY T01_REP_MTR.rcpt_no"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "scan")
            DB_CLOSE()

            Dim tbl As New DataTable
            tbl = DsList1.Tables("scan")
            DataGridEx1.DataSource = tbl

            DtView1 = New DataView(DsList1.Tables("scan"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Label_cnt.Text = "0件"
                msg.Text = "該当するデータがありません。"
            Else
                Label_cnt.Text = Format(DtView1.Count, "##,##0") & "件"
                DataGridEx1.Focus()
            End If

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Date1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.GotFocus
        Date1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.GotFocus
        Date2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.GotFocus
        Edit002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.GotFocus
        Edit004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.GotFocus
        Edit005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.GotFocus
        Edit006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
        Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.GotFocus
        Combo002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.GotFocus
        Combo003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo004.GotFocus
        Combo004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo005.GotFocus
        Combo005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo006.GotFocus
        Combo006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo007.GotFocus
        Combo007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Date1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.LostFocus
        Date1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.LostFocus
        Date2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.LostFocus
        Edit004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.LostFocus
        Edit005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.LostFocus
        Edit006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   '部署
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.LostFocus
        CHK_Combo003()   '販社グループ
    End Sub
    Private Sub Combo004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo004.LostFocus
        CHK_Combo004()   '販社
    End Sub
    Private Sub Combo005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo005.LostFocus
        CHK_Combo005()   'メーカー
    End Sub
    Private Sub Combo006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo006.LostFocus
        CHK_Combo006()   '受付種別
    End Sub
    Private Sub Combo007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo007.LostFocus
        CHK_Combo007()   '修理種別
    End Sub

    '********************************************************************
    '**  クリア
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Date1.Text = Nothing
        Date2.Text = Nothing
        Edit001.Text = Nothing
        Edit002.Text = Nothing
        Edit003.Text = Nothing
        Edit004.Text = Nothing
        Edit005.Text = Nothing
        Edit006.Text = Nothing
        Combo001.Text = Nothing : CL001.Text = Nothing
        Combo002.Text = Nothing
        Combo003.Text = Nothing : CL003.Text = Nothing
        Combo004.Text = Nothing : CL004.Text = Nothing
        Combo005.Text = Nothing : CL005.Text = Nothing
        Combo006.Text = Nothing : CL006.Text = Nothing
        Combo007.Text = Nothing : CL007.Text = Nothing
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_RTN = "0"
        DsList1.Clear()
        Close()
    End Sub
End Class
