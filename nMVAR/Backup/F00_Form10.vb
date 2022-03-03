Public Class F00_Form10
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label16_1 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents key As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form10))
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label20 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Label16_1 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.CL003 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.key = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 336)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 9
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "更新"
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionText = "履歴"
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(20, 364)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(964, 316)
        Me.DataGridEx1.TabIndex = 10
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGridEx1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T05_INQUIRY"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = "yyyy/MM/dd HH:mm"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "問合せ日時"
        Me.DataGridTextBoxColumn1.MappingName = "inq_date"
        Me.DataGridTextBoxColumn1.Width = 110
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "問合せ先"
        Me.DataGridTextBoxColumn2.MappingName = "inq_code_name"
        Me.DataGridTextBoxColumn2.Width = 99
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "問合せ担当"
        Me.DataGridTextBoxColumn3.MappingName = "inq_empl_name"
        Me.DataGridTextBoxColumn3.Width = 110
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "問合せ内容"
        Me.DataGridTextBoxColumn4.MappingName = "inq_memo"
        Me.DataGridTextBoxColumn4.Width = 470
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.MappingName = "key_no"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 0
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "FAXﾌｫｰﾑ"
        Me.DataGridTextBoxColumn6.MappingName = "fax_form_name"
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.MappingName = "fax_form"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 0
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.MappingName = "inq_code"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 0
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.MappingName = "inq_empl"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 0
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(20, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 20)
        Me.Label20.TabIndex = 1413
        Me.Label20.Text = "問合せ担当"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo002.Location = New System.Drawing.Point(100, 40)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(196, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 1
        Me.Combo002.Value = "Combo002"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Navy
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(20, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 20)
        Me.Label18.TabIndex = 1412
        Me.Label18.Text = "問合せ先"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo001.Location = New System.Drawing.Point(100, 16)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 0
        Me.Combo001.Value = "Combo001"
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(100, 64)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2030, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(144, 20)
        Me.Date001.TabIndex = 2
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(20, 64)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 20)
        Me.Label35.TabIndex = 1415
        Me.Label35.Text = "問合せ日時"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.AcceptsReturn = True
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(100, 88)
        Me.Edit001.MaxLength = 3000
        Me.Edit001.Multiline = True
        Me.Edit001.Name = "Edit001"
        Me.Edit001.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit001.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(884, 216)
        Me.Edit001.TabIndex = 4
        '
        'Label16_1
        '
        Me.Label16_1.BackColor = System.Drawing.Color.Navy
        Me.Label16_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16_1.ForeColor = System.Drawing.Color.White
        Me.Label16_1.Location = New System.Drawing.Point(20, 88)
        Me.Label16_1.Name = "Label16_1"
        Me.Label16_1.Size = New System.Drawing.Size(80, 216)
        Me.Label16_1.TabIndex = 1417
        Me.Label16_1.Text = "内容"
        Me.Label16_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(24, 312)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(956, 16)
        Me.msg.TabIndex = 1418
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(300, 40)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1420
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(300, 20)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1419
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(660, 20)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(52, 16)
        Me.CL003.TabIndex = 1423
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(380, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 1422
        Me.Label2.Text = "ＦＡＸフォーム"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo003
        '
        Me.Combo003.AutoSelect = True
        Me.Combo003.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo003.Location = New System.Drawing.Point(460, 20)
        Me.Combo003.MaxDropDownItems = 20
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(196, 20)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 3
        Me.Combo003.Value = "Combo003"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(804, 336)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 24)
        Me.Button3.TabIndex = 8
        Me.Button3.TabStop = False
        Me.Button3.Text = "別No照会"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(128, 336)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 24)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "印刷"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(228, 336)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "クリア"
        '
        'key
        '
        Me.key.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.key.Location = New System.Drawing.Point(0, 0)
        Me.key.Name = "key"
        Me.key.Size = New System.Drawing.Size(52, 16)
        Me.key.TabIndex = 1424
        Me.key.Text = "key"
        Me.key.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.key.Visible = False
        '
        'F00_Form10
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.key)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CL003)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Combo003)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Label16_1)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F00_Form10"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "問合せ"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        Button4_Click(sender, e)    '**  クリア
        CmbSet()    '**  コンボボックスセット
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        '問合せ先
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '027') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_027")

        Combo001.DataSource = DsCMB.Tables("CLS_CODE_027")
        Combo001.DisplayMember = "cls_code_name"
        Combo001.ValueMember = "cls_code"
        Combo001.Text = Nothing

        '問合せ担当
        strSQL = "SELECT empl_code, name"
        strSQL += " FROM (SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (delt_flg = 0) AND (brch_code = '" & P_EMPL_BRCH & "')"
        strSQL += " UNION"
        strSQL += " SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (empl_code = " & P_EMPL_NO & ")) M01_EMPL"
        strSQL += " ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M01_EMPL")

        Combo002.DataSource = DsCMB.Tables("M01_EMPL")
        Combo002.DisplayMember = "name"
        Combo002.ValueMember = "empl_code"
        Combo002.Text = P_EMPL_NAME
        CL002.Text = P_EMPL_NO

        'ＦＡＸフォーム
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '028') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_028")

        Combo003.DataSource = DsCMB.Tables("CLS_CODE_028")
        Combo003.DisplayMember = "cls_code_name"
        Combo003.ValueMember = "cls_code"
        Combo003.Text = Nothing

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()

        DsList1.Clear()
        strSQL = "SELECT TOP (100) PERCENT T05_INQUIRY.inq_code, V_cls_027.cls_code_name AS inq_code_name, T05_INQUIRY.inq_date"
        strSQL += ", T05_INQUIRY.inq_empl, M01_EMPL.name AS inq_empl_name, T05_INQUIRY.inq_memo, T05_INQUIRY.key_no"
        strSQL += ", T05_INQUIRY.fax_form, V_cls_028.cls_code_name AS fax_form_name"
        strSQL += " FROM T05_INQUIRY INNER JOIN"
        strSQL += " M01_EMPL ON T05_INQUIRY.inq_empl = M01_EMPL.empl_code LEFT OUTER JOIN"
        strSQL += " V_cls_028 ON T05_INQUIRY.fax_form = V_cls_028.cls_code LEFT OUTER JOIN"
        strSQL += " V_cls_027 ON T05_INQUIRY.inq_code = V_cls_027.cls_code"
        strSQL += " WHERE (T05_INQUIRY.rcpt_no = '" & P_PRAM1 & "')"
        strSQL += " ORDER BY T05_INQUIRY.inq_date DESC, T05_INQUIRY.inq_code, T05_INQUIRY.inq_empl"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "T05_INQUIRY")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("T05_INQUIRY"), "", "", DataViewRowState.CurrentRows)

        Dim tbl As New DataTable
        tbl = DsList1.Tables("T05_INQUIRY")
        DataGridEx1.DataSource = tbl

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
                    msg.Text = Nothing
                    Combo001.BackColor = System.Drawing.SystemColors.Window
                    Combo002.BackColor = System.Drawing.SystemColors.Window
                    Combo003.BackColor = System.Drawing.SystemColors.Window
                    Date001.BackColor = System.Drawing.SystemColors.Window
                    Edit001.BackColor = System.Drawing.SystemColors.Window

                    key.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 4)
                    CL001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 7)
                    Combo001.Text = CL001.Text & ":" & DataGridEx1(DataGridEx1.CurrentRowIndex, 1)
                    CL002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 8)
                    Combo002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 2)
                    CL003.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 6)
                    Combo003.Text = CL003.Text & ":" & DataGridEx1(DataGridEx1.CurrentRowIndex, 5)
                    Date001.Text = Format(DataGridEx1(DataGridEx1.CurrentRowIndex, 0), "yyyy/MM/dd HH:mm")
                    Edit001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 3)
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
                msg.Text = Nothing
                Combo001.BackColor = System.Drawing.SystemColors.Window
                Combo002.BackColor = System.Drawing.SystemColors.Window
                Combo003.BackColor = System.Drawing.SystemColors.Window
                Date001.BackColor = System.Drawing.SystemColors.Window
                Edit001.BackColor = System.Drawing.SystemColors.Window

                key.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 4)
                CL001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 7)
                Combo001.Text = CL001.Text & ":" & DataGridEx1(DataGridEx1.CurrentRowIndex, 1)
                CL002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 8)
                Combo002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 2)
                CL003.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 6)
                Combo003.Text = CL003.Text & ":" & DataGridEx1(DataGridEx1.CurrentRowIndex, 5)
                Date001.Text = Format(DataGridEx1(DataGridEx1.CurrentRowIndex, 0), "yyyy/MM/dd HH:mm")
                Edit001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 3)
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Combo001()   '問合せ先
        msg.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            Combo001.BackColor = System.Drawing.Color.Red
            msg.Text = "問合せ先が入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_027"), "cls_code_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する問合せ先がありません。"
                Exit Sub
            Else
                CL001.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo002()   '問合せ担当
        msg.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            Combo002.BackColor = System.Drawing.Color.Red
            msg.Text = "問合せ担当が入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("M01_EMPL"), "name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する問合せ担当がありません。"
                Exit Sub
            Else
                CL002.Text = DtView1(0)("empl_code")
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo003()   'ＦＡＸフォーム
        msg.Text = Nothing

        Combo003.Text = Trim(Combo003.Text)
        If Combo003.Text = Nothing Then
            Combo003.BackColor = System.Drawing.Color.Red
            msg.Text = "ＦＡＸフォームが入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_028"), "cls_code_name = '" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo003.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するＦＡＸフォームがありません。"
                Exit Sub
            Else
                CL003.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date001()   '問合せ日
        msg.Text = Nothing

        If Date001.Number = 0 Then
            Date001.BackColor = System.Drawing.Color.Red
            msg.Text = "問合せ日が入力されていません。"
            Exit Sub
        End If
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit001()   '問合せ内容
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            'Edit001.BackColor = System.Drawing.Color.Red
            'msg.Text = "問合せ内容が入力されていません。"
            'Exit Sub
        Else
            Select Case CL003.Text
                Case Is = "01"
                    If LenB(Edit001.Text) > 3000 Then
                        msg.Text = "ＦＡＸフォームが「" & Combo003.Text & "」 の時は、全角1500文字以内で入力してください。"
                        Exit Sub
                    End If
                Case Is = "02"
                    If LenB(Edit001.Text) > 1200 Then
                        msg.Text = "ＦＡＸフォームが「" & Combo003.Text & "」 の時は、全角600文字以内で入力してください。"
                        Exit Sub
                    End If
                Case Is = "03"
                    If LenB(Edit001.Text) > 2000 Then
                        msg.Text = "ＦＡＸフォームが「" & Combo003.Text & "」 の時は、全角1000文字以内で入力してください。"
                        Exit Sub
                    End If
                Case Is = "04"
                    If LenB(Edit001.Text) > 1000 Then
                        msg.Text = "ＦＡＸフォームが「" & Combo003.Text & "」 の時は、全角500文字以内で入力してください。"
                        Exit Sub
                    End If
            End Select
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        CHK_Combo001()   '問合せ先
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Combo002()  '問合せ担当
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Date001()   '問合せ日
        If msg.Text <> Nothing Then Err_F = "1" : Date001.Focus() : Exit Sub

        CHK_Combo003()  'ＦＡＸフォーム
        If msg.Text <> Nothing Then Err_F = "1" : Combo003.Focus() : Exit Sub

        CHK_Edit001()   '問合せ内容
        If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub

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
    Private Sub Combo003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.GotFocus
        Combo003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.GotFocus
        Date001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   '問合せ先
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()   '問合せ担当
    End Sub
    Private Sub Combo003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.LostFocus
        CHK_Combo003()   'ＦＡＸフォーム
    End Sub
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        CHK_Date001()   '問合せ日
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '問合せ内容
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_Check()
        If Err_F = "0" Then

            DB_OPEN("nMVAR")
            If key.Text = Nothing Then
                strSQL = "INSERT INTO T05_INQUIRY"
                strSQL += " (rcpt_no, inq_code, fax_form, inq_empl, inq_date, inq_memo)"
                strSQL += " VALUES ('" & P_PRAM1 & "'"
                strSQL += ", '" & CL001.Text & "'"
                strSQL += ", '" & CL003.Text & "'"
                strSQL += ", " & CL002.Text & ""
                strSQL += ", '" & Date001.Text & "'"
                strSQL += ", '" & Edit001.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                msg.Text = "登録しました。"
            Else
                strSQL = "UPDATE T05_INQUIRY"
                strSQL += " SET inq_code = '" & CL001.Text & "'"
                strSQL += ", fax_form = '" & CL003.Text & "'"
                strSQL += ", inq_empl = " & CL002.Text & ""
                strSQL += ", inq_date = CONVERT(DATETIME, '" & Date001.Text & "', 102)"
                strSQL += ", inq_memo = '" & Edit001.Text & "'"
                strSQL += " WHERE (key_no = " & key.Text & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                msg.Text = "更新しました。"
            End If
            DB_CLOSE()

            DspSet()                    '**  画面セット
            Button4_Click(sender, e)    '**  クリア
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  印刷
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_Check()
        If Err_F = "0" Then

            DB_OPEN("nMVAR")
            If key.Text = Nothing Then
                strSQL = "INSERT INTO T05_INQUIRY"
                strSQL += " (rcpt_no, inq_code, fax_form, inq_empl, inq_date, inq_memo)"
                strSQL += " VALUES ('" & P_PRAM1 & "'"
                strSQL += ", '" & CL001.Text & "'"
                strSQL += ", '" & CL003.Text & "'"
                strSQL += ", " & CL002.Text & ""
                strSQL += ", '" & Date001.Text & "'"
                strSQL += ", '" & Edit001.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()

                WK_DsList1.Clear()
                strSQL = "SELECT key_no FROM T05_INQUIRY"
                strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                strSQL += " AND (inq_code = '" & CL001.Text & "')"
                strSQL += " AND (fax_form = '" & CL003.Text & "')"
                strSQL += " AND (inq_empl = " & CL002.Text & ")"
                strSQL += " AND (inq_date = CONVERT(DATETIME, '" & Date001.Text & "', 102))"
                strSQL += " AND (inq_memo = '" & Edit001.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(WK_DsList1, "T05_INQUIRY")
                WK_DtView1 = New DataView(WK_DsList1.Tables("T05_INQUIRY"), "", "key_no DESC", DataViewRowState.CurrentRows)
                key.Text = WK_DtView1(0)("key_no")
            Else
                strSQL = "UPDATE T05_INQUIRY"
                strSQL += " SET inq_code = '" & CL001.Text & "'"
                strSQL += ", fax_form = '" & CL003.Text & "'"
                strSQL += ", inq_empl = " & CL002.Text & ""
                strSQL += ", inq_date = CONVERT(DATETIME, '" & Date001.Text & "', 102)"
                strSQL += ", inq_memo = '" & Edit001.Text & "'"
                strSQL += " WHERE (key_no = " & key.Text & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If
            DB_CLOSE()

            P_PRAM2 = key.Text
            P_PRAM3 = CL003.Text
            P_PRAM4 = Combo003.Text

            Dim F00_Form10_2 As New F00_Form10_2
            F00_Form10_2.ShowDialog()

            DspSet()                    '**  画面セット
            Button4_Click(sender, e)    '**  クリア

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  クリア
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        key.Text = Nothing
        Combo001.Text = Nothing : CL001.Text = Nothing
        Combo002.Text = P_EMPL_NAME : CL002.Text = P_EMPL_NO
        Combo003.Text = Nothing : CL003.Text = Nothing
        Date001.Text = Format(Now, "yyyy/MM/dd HH:mm")
        Edit001.Text = Nothing
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  別No照会
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_search.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub
End Class