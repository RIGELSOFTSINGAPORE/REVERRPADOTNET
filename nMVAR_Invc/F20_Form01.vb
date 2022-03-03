Public Class F20_Form01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0
    Dim flag As Boolean

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, strFile, strData, inz_F As String
    Dim i, r As Integer
    Dim WK_date As Date

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGridEx1 As nMVAR_Invc.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents kengen As System.Windows.Forms.Label
    Friend WithEvents DataGridBoolColumn3 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date001 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents DD As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Date002 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F20_Form01))
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.DataGridEx1 = New nMVAR_Invc.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridBoolColumn3 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.kengen = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date001 = New GrapeCity.Win.Input.Interop.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.DD = New System.Windows.Forms.Label
        Me.Date002 = New GrapeCity.Win.Input.Interop.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date002, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(932, 568)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 8
        Me.Button98.Text = "戻る"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(4, 568)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 24)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "更新"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(80, 572)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(660, 16)
        Me.msg.TabIndex = 1237
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 72)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(992, 488)
        Me.DataGridEx1.TabIndex = 4
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridBoolColumn3, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "scan"
        '
        'DataGridBoolColumn3
        '
        Me.DataGridBoolColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn3.FalseValue = False
        Me.DataGridBoolColumn3.HeaderText = "検収（QG）"
        Me.DataGridBoolColumn3.MappingName = "neva_chek_flg"
        Me.DataGridBoolColumn3.NullText = ""
        Me.DataGridBoolColumn3.NullValue = "False"
        Me.DataGridBoolColumn3.TrueValue = True
        Me.DataGridBoolColumn3.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "請求先名"
        Me.DataGridTextBoxColumn2.MappingName = "invc_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 190
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "伝票番号"
        Me.DataGridTextBoxColumn3.MappingName = "sals_no"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 70
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = "yyyy/MM/dd"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "売上日"
        Me.DataGridTextBoxColumn4.MappingName = "sals_date"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "受付番号"
        Me.DataGridTextBoxColumn7.MappingName = "rcpt_no"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "ユーザー名"
        Me.DataGridTextBoxColumn6.MappingName = "user_name"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 150
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "##,##0"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "金額"
        Me.DataGridTextBoxColumn8.MappingName = "sals_amnt"
        Me.DataGridTextBoxColumn8.NullText = "0"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "拠点"
        Me.DataGridTextBoxColumn5.MappingName = "rcpt_brch_name"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "販社グループ"
        Me.DataGridTextBoxColumn9.MappingName = "grup_name"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 110
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "invc_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.MappingName = "rcpt_brch_code"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 0
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.MappingName = "kakutei"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 25
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(936, 8)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1248
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(964, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1247
        Me.CheckBox1.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(264, 16)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1766
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        'Me.Combo001.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(108, 12)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(232, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 0
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1765
        Me.Label1.Text = "拠点"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kengen
        '
        Me.kengen.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.kengen.Location = New System.Drawing.Point(84, 584)
        Me.kengen.Name = "kengen"
        Me.kengen.Size = New System.Drawing.Size(52, 16)
        Me.kengen.TabIndex = 1836
        Me.kengen.Text = "kengen"
        Me.kengen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.kengen.Visible = False
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(596, 16)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1839
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        'Me.Combo002.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
        Me.Combo002.Location = New System.Drawing.Point(440, 12)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(232, 24)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 1
        Me.Combo002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo002.Value = "Combo002"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(344, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 1838
        Me.Label3.Text = "販社グループ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/MM", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/MM", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(756, 12)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(72, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 2
        Me.Date001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(676, 12)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(80, 20)
        Me.Label007.TabIndex = 1841
        Me.Label007.Text = "対象年月"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(828, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 1842
        Me.Label2.Text = "以前"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(848, 568)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 24)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "明細CSV"
        '
        'DD
        '
        Me.DD.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.DD.Location = New System.Drawing.Point(240, 44)
        Me.DD.Name = "DD"
        Me.DD.Size = New System.Drawing.Size(52, 16)
        Me.DD.TabIndex = 1858
        Me.DD.Text = "00"
        Me.DD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DD.Visible = False
        '
        'Date002
        '
        Me.Date002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date002.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date002.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date002.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date002.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date002.Location = New System.Drawing.Point(108, 44)
        Me.Date002.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date002.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date002.Name = "Date002"
        Me.Date002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date002.TabIndex = 3
        Me.Date002.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date002.Value = Nothing
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(12, 44)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 20)
        Me.Label35.TabIndex = 1857
        Me.Label35.Text = "請求締日"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(760, 568)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 24)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "〆確定"
        '
        'F20_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(1006, 604)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DD)
        Me.Controls.Add(Me.Date002)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.kengen)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.msg)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F20_Form01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "納品書検収(販社)"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date002, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F20_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        CmbSet()
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Date002.MaxDate = "9999/12/31 23:59:59"
        Date001.MaxDate = "9999/12/31 23:59:59"
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date002.Text = Now.Date
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  権限チェック
    '********************************************************************
    Sub ACES()

        SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = P_ACES_brch_code
        Pram2.Value = P_ACES_post_code
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='201'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            kengen.Text = DtView1(0)("access_cls")
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button2.Enabled = False
                    Button3.Enabled = False
                Case Is = "3", "4"
                    Button2.Enabled = True
                    Button3.Enabled = True
            End Select
        Else
            kengen.Text = Nothing
            Button2.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()

        '部署
        strSQL = "SELECT T01_REP_MTR.rcpt_brch_code AS brch_code, T01_REP_MTR.rcpt_brch_code + ':' + M03_BRCH.name AS brch_name"
        strSQL = strSQL & " FROM T10_SALS INNER JOIN"
        strSQL = strSQL & " T01_REP_MTR ON T10_SALS.rcpt_no = T01_REP_MTR.rcpt_no INNER JOIN"
        strSQL = strSQL & " M03_BRCH ON T01_REP_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
        strSQL = strSQL & " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
        strSQL = strSQL & " M08_STORE AS M08_STORE_1 ON M08_STORE.invc_code = M08_STORE_1.store_code"
        strSQL = strSQL & " WHERE (T10_SALS.invc_flg = 0) AND (T10_SALS.cls = '1') AND (M08_STORE_1.dlvr_rprt_cls <> '0')"
        strSQL = strSQL & " GROUP BY T01_REP_MTR.rcpt_brch_code + ':' + M03_BRCH.name, T01_REP_MTR.rcpt_brch_code"
        strSQL = strSQL & " ORDER BY brch_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "M03_BRCH")
        DB_CLOSE()

        Combo001.DataSource = DsCMB.Tables("M03_BRCH")
        Combo001.DisplayMember = "brch_name"
        Combo001.ValueMember = "brch_code"

        WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_code ='" & P_EMPL_BRCH & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            CL001.Text = P_EMPL_BRCH
            Combo001.Text = WK_DtView1(0)("brch_name")
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                CL001.Text = WK_DtView1(0)("brch_code")
                Combo001.Text = WK_DtView1(0)("brch_name")
            Else
                CL001.Text = Nothing
                Combo001.Text = Nothing
            End If
        End If

        '販社グループ
        strSQL = "SELECT cls_code AS grup_code, cls_code + ':' + cls_code_name AS grup_name"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '006') AND (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "CLS_006")
        DB_CLOSE()

        Combo002.DataSource = DsCMB.Tables("CLS_006")
        Combo002.DisplayMember = "grup_name"
        Combo002.ValueMember = "grup_code"

        CL002.Text = Nothing
        Combo002.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        inz_F = "1"
        sql()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("scan")
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

    End Sub

    Sub sql()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If inz_F = "1" And Date002.Number <> 0 Then
            DsList1.Clear()
            msg.Text = Nothing

            strSQL = "SELECT T10_SALS.neva_chek_flg, T10_SALS.neva_chek_flg2, T01_REP_MTR.store_code, M08_STORE.name AS store_name"
            strSQL = strSQL & ", M08_STORE.dlvr_code, M08_STORE_1.name AS dlvr_name, M08_STORE.invc_code, M08_STORE_2.name AS invc_name"
            strSQL = strSQL & ", M08_STORE_2.grup_code, V_cls_006.cls_code_name AS grup_name, T01_REP_MTR.rcpt_brch_code"
            strSQL = strSQL & ", M03_BRCH.name AS rcpt_brch_name, T01_REP_MTR.vndr_code, M05_VNDR.name AS vndr_name, T01_REP_MTR.comp_date"
            strSQL = strSQL & ", T01_REP_MTR.sals_no, T01_REP_MTR.sals_date, T01_REP_MTR.user_name, T01_REP_MTR.store_repr_no"
            strSQL = strSQL & ", T10_SALS.rcpt_no, T10_SALS.cls, T10_SALS.neva_chek_list, T10_SALS.invc_flg, T10_SALS.sals_amnt"
            strSQL = strSQL & ", T10_SALS.invc_cls_date, M08_STORE_2.cls_date, '' AS kakutei"
            strSQL = strSQL & " FROM T10_SALS INNER JOIN"
            strSQL = strSQL & " T01_REP_MTR ON T10_SALS.rcpt_no = T01_REP_MTR.rcpt_no INNER JOIN"
            strSQL = strSQL & " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
            strSQL = strSQL & " M03_BRCH ON T01_REP_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
            strSQL = strSQL & " M05_VNDR ON T01_REP_MTR.vndr_code = M05_VNDR.vndr_code INNER JOIN"
            strSQL = strSQL & " M08_STORE AS M08_STORE_1 ON M08_STORE.dlvr_code = M08_STORE_1.store_code INNER JOIN"
            strSQL = strSQL & " M08_STORE AS M08_STORE_2 ON M08_STORE.invc_code = M08_STORE_2.store_code INNER JOIN"
            strSQL = strSQL & " V_cls_006 ON M08_STORE_2.grup_code = V_cls_006.cls_code"
            strSQL = strSQL & " WHERE (T10_SALS.cls = '1')"
            strSQL = strSQL & " AND (T10_SALS.invc_flg = 0)"
            strSQL = strSQL & " AND (M08_STORE_1.dlvr_rprt_cls <> '0')"
            If CL001.Text <> Nothing Then
                strSQL = strSQL & " AND (T01_REP_MTR.rcpt_brch_code = '" & CL001.Text & "')"
            End If
            If CL002.Text <> Nothing Then
                strSQL = strSQL & " AND (M08_STORE_2.grup_code = '" & CL002.Text & "')"
            End If
            If Date001.Number <> 0 Then
                WK_date = Mid(Date001.Number, 1, 4) & "/" & Mid(Date001.Number, 5, 2) & "/01"
                WK_date = DateAdd(DateInterval.Month, 1, WK_date)
                strSQL = strSQL & " AND (T01_REP_MTR.sals_date < CONVERT(DATETIME, '" & WK_date & "', 102))"
            End If
            strSQL = strSQL & " AND (M08_STORE_2.cls_date = " & DD.Text & " OR M08_STORE_2.cls_date = 0)"
            strSQL = strSQL & " AND (T01_REP_MTR.sals_date <= CONVERT(DATETIME, '" & Date002.Text & "', 102))"
            strSQL = strSQL & " AND (T10_SALS.invc_cls_date = CONVERT(DATETIME, '" & Date002.Text & "', 102) OR T10_SALS.invc_cls_date IS NULL)"
            strSQL = strSQL & " ORDER BY M08_STORE.invc_code, T01_REP_MTR.comp_date, T10_SALS.rcpt_no"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "scan")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("scan"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                msg.Text = "対象データがありません。"
                Button2.Enabled = False : Button3.Enabled = False : Button5.Enabled = False
            Else
                For i = 0 To DtView1.Count - 1
                    If Not IsDBNull(DtView1(i)("invc_cls_date")) Then
                        DtView1(i)("kakutei") = "確"
                    End If
                Next
                Button2.Enabled = True : Button3.Enabled = True : Button5.Enabled = True
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGrid1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        'prabu add 2021-06-10
        If flag <> True Then
            If DataGridEx1.CurrentRowIndex >= 0 Then
                DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
            End If
        End If

    End Sub

    '********************************************************************
    '**  データグリッド　スペース
    '********************************************************************
    Private Sub DataGrid1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                Case Is = Keys.Space
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 11) <> "確" Then
                        If kensyu_CHK(Date002.Text, DataGridEx1(DataGridEx1.CurrentRowIndex, 9), DataGridEx1(DataGridEx1.CurrentRowIndex, 10)) = "OK" Then
                            If DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = "False" Then
                                DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox1.Checked
                            Else
                                DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                            End If
                        End If
                    End If
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))

            If hitinfo.Column = 0 Then  'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 11) <> "確" Then
                        If kensyu_CHK(Date002.Text, DataGridEx1(DataGridEx1.CurrentRowIndex, 9), DataGridEx1(DataGridEx1.CurrentRowIndex, 10)) = "OK" Then
                            If DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = "False" Then
                                DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox1.Checked
                            Else
                                DataGridEx1(DataGridEx1.CurrentRowIndex, 0) = CheckBox2.Checked
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
        Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.GotFocus
        Combo002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.GotFocus
        Date001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date002.GotFocus
        Date002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date002.LostFocus
        Date002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Combo001_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.SelectedIndexChanged
        cmb01_chg()
    End Sub
    Private Sub Combo001_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.TextChanged
        cmb01_chg()
    End Sub
    Private Sub Combo002_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.SelectedIndexChanged
        cmb02_chg()
    End Sub
    Private Sub Combo002_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.TextChanged
        cmb02_chg()
    End Sub

    Sub cmb01_chg()
        If Combo001.Text = Nothing Then
            CL001.Text = Nothing
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_name ='" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                CL001.Text = "Err"
            Else
                CL001.Text = WK_DtView1(0)("brch_code")
            End If
        End If
        sql()
    End Sub
    Sub cmb02_chg()
        If Combo002.Text = Nothing Then
            CL002.Text = Nothing
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("CLS_006"), "grup_name ='" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                CL002.Text = "Err"
            Else
                CL002.Text = WK_DtView1(0)("grup_code")
            End If
        End If
        sql()
    End Sub
    Private Sub Date001_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.TextChanged
        sql()
    End Sub
    Private Sub Date002_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date002.TextChanged
        If Date002.Number <> 0 Then
            DD.Text = Mid(DateAdd(DateInterval.Day, 1, CDate(Date002.Text)), 9, 2)
            If DD.Text = "01" Then
                DD.Text = "99"
            Else
                DD.Text = Mid(Date002.Text, 9, 2)
            End If
        Else
            DD.Text = "00"
        End If
        sql()
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        upd()

        sql()    '**  画面セット
        flag = True
        msg.Text = "更新しました。"

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Sub upd()
        DtView1 = New DataView(DsList1.Tables("scan"), "", "", DataViewRowState.CurrentRows)
        DB_OPEN("nMVAR")
        For i = 0 To DtView1.Count - 1

            strSQL = "UPDATE T10_SALS"
            If DtView1(i)("neva_chek_flg") = "True" Then
                strSQL = strSQL & " SET neva_chek_flg = 1"
                strSQL = strSQL & ", neva_chek_date = '" & Now.Date & "'"
            Else
                strSQL = strSQL & " SET neva_chek_flg = 0"
                strSQL = strSQL & ", neva_chek_date = Null"
                strSQL = strSQL & ", neva_chek_list = Null"
            End If
            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
            strSQL = strSQL & " AND (cls = '" & DtView1(i)("cls") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

        Next
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  〆確定
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        upd()    '**  更新

        WK_DtView1 = New DataView(DsList1.Tables("scan"), "neva_chek_flg = 1 AND invc_cls_date IS NULL", "dlvr_code, comp_date, rcpt_no", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            DB_OPEN("nMVAR")
            For i = 0 To WK_DtView1.Count - 1

                strSQL = "UPDATE T10_SALS"
                strSQL = strSQL & " SET invc_cls_date = CONVERT(DATETIME, '" & Date002.Text & "', 102)"
                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(i)("rcpt_no") & "')"
                strSQL = strSQL & " AND (cls = '" & WK_DtView1(i)("cls") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()

                WK_DsList1.Clear()
                strSQL = "SELECT * FROM L06_kensyu"
                strSQL = strSQL & " WHERE (invc_date = CONVERT(DATETIME, '" & Date002.Text & "', 102))"
                strSQL = strSQL & " AND (invc_code = '" & WK_DtView1(i)("invc_code") & "')"
                strSQL = strSQL & " AND (brch_code = '" & WK_DtView1(i)("rcpt_brch_code") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                r = DaList1.Fill(WK_DsList1, "L06_kensyu")

                If r = 0 Then
                    strSQL = "INSERT INTO L06_kensyu (invc_date, invc_code, brch_code)"
                    strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & Date002.Text & "', 102)"
                    strSQL = strSQL & ", '" & WK_DtView1(i)("invc_code") & "'"
                    strSQL = strSQL & ", '" & WK_DtView1(i)("rcpt_brch_code") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                End If

            Next
            DB_CLOSE()
            msg.Text = "〆確定しました。"
            Button5_Click(sender, e)    '**  明細CSV
            sql()    '**  画面セット
        Else
            'prabu add 2021-06-17
            flag = True
            msg.Text = "対象データがありません。"
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  明細CSV
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        WK_DtView1 = New DataView(DsList1.Tables("scan"), "neva_chek_flg = 1", "dlvr_code, comp_date, rcpt_no", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "検収明細.CSV"                           'はじめのファイル名を指定する
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
            flag = True
            If sfd.ShowDialog() = DialogResult.OK Then     'ダイアログを表示する
                strFile = sfd.FileName   'OKボタンがクリックされたとき

                Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

                'データを書き込む
                strData = "伝票番号,計上QG,受付種別,グループコード,グループ名,取次店コード,取次店名,販社伝番,請求先コード"
                strData = strData & ",請求先名,お客様名,受付年月日,修理完了日,売上日,メーカー名,モデル,機種,製造番号,小計"
                strData = strData & ",消費税,合計,ネバ伝番号,申告症状,修理内容,QG-Care番号"
                swFile.WriteLine(strData)

                DB_OPEN("nMVAR")
                For i = 0 To WK_DtView1.Count - 1

                    WK_DsList1.Clear()
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F20", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram1.Value = WK_DtView1(i)("rcpt_no")
                    DaList1.SelectCommand = SqlCmd1
                    DaList1.Fill(WK_DsList1, "sp_F20")
                    WK_DtView2 = New DataView(WK_DsList1.Tables("sp_F20"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView2.Count <> 0 Then

                        strData = WK_DtView2(0)("rcpt_no")                                                          '伝票番号
                        strData = strData & "," & WK_DtView2(0)("kjo_brch_name")                                    '計上QG   
                        strData = strData & "," & WK_DtView2(0)("rcpt_cls_name")                                    '受付種別
                        strData = strData & "," & WK_DtView2(0)("grup_code")                                        'グループコード
                        strData = strData & "," & WK_DtView2(0)("grup_name")                                        'グループ名
                        strData = strData & "," & WK_DtView2(0)("store_code")                                       '取次店コード
                        strData = strData & "," & WK_DtView2(0)("store_name")                                       '取次店名
                        strData = strData & "," & WK_DtView2(0)("store_repr_no")                                    '販社伝番
                        strData = strData & "," & WK_DtView2(0)("invc_code")                                        '請求先コード
                        strData = strData & "," & WK_DtView2(0)("invc_name")                                        '請求先名
                        strData = strData & "," & WK_DtView2(0)("user_name")                                        'お客様名
                        strData = strData & "," & WK_DtView2(0)("accp_date")                                        '受付年月日
                        strData = strData & "," & WK_DtView2(0)("comp_date")                                        '修理完了日
                        strData = strData & "," & WK_DtView2(0)("sals_date")                                        '売上日
                        strData = strData & "," & WK_DtView2(0)("vndr_name")                                        'メーカー名
                        strData = strData & "," & New_Line_Cng(WK_DtView2(0)("model_1"))                            'モデル
                        strData = strData & "," & New_Line_Cng(WK_DtView2(0)("model_2"))                            '機種
                        strData = strData & "," & WK_DtView2(0)("s_n")                                              '製造番号
                        strData = strData & "," & WK_DtView2(0)("comp_eu_ttl")                                      '小計
                        strData = strData & "," & WK_DtView2(0)("comp_eu_tax")                                      '消費税
                        strData = strData & "," & WK_DtView2(0)("comp_eu_ttl") + WK_DtView2(0)("comp_eu_tax")       '合計
                        strData = strData & "," & WK_DtView2(0)("sals_no")                                          'ネバ伝番号
                        strData = strData & "," & New_Line_Cng(WK_DtView2(0)("user_trbl"))                          '申告症状
                        strData = strData & "," & New_Line_Cng(WK_DtView2(0)("comp_meas"))                          '修理内容
                        strData = strData & "," & WK_DtView2(0)("qg_care_no")                                       'QG-Care番号
                        swFile.WriteLine(strData)

                    End If
                Next
                DB_CLOSE()
                swFile.Close()          'ファイルを閉じる

                'DB_CLOSE() #comment prabu 2021-06-10
                'Exit Sub
                MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub



    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub
End Class
