Public Class F00_Form16
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData As String
    Dim WK_str1, WK_str2 As String
    Dim i, r, chg_itm As Integer
    Dim CG_str(5) As String

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    ' Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    'Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
    Friend WithEvents key As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label16_1 As System.Windows.Forms.Label
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label0 As System.Windows.Forms.Label
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form16))
        Me.key = New System.Windows.Forms.Label
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Label16_1 = New System.Windows.Forms.Label
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label0 = New System.Windows.Forms.Label
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Button5 = New System.Windows.Forms.Button
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'key
        '
        Me.key.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.key.Location = New System.Drawing.Point(0, 0)
        Me.key.Name = "key"
        Me.key.Size = New System.Drawing.Size(52, 16)
        Me.key.TabIndex = 1445
        Me.key.Text = "key"
        Me.key.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.key.Visible = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridBoolColumn1, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T08_CONTACT"
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionText = "����"
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(20, 364)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(964, 316)
        Me.DataGridEx1.TabIndex = 1435
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGridEx1.TabStop = False
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = "yyyy/MM/dd HH:mm"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "�R���^�N�g����"
        Me.DataGridTextBoxColumn1.MappingName = "contact_date"
        Me.DataGridTextBoxColumn1.Width = 110
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "�R���^�N�g����"
        Me.DataGridTextBoxColumn2.MappingName = "contact_name"
        Me.DataGridTextBoxColumn2.Width = 99
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "�R���^�N�g�S��"
        Me.DataGridTextBoxColumn3.MappingName = "contact_empl_name"
        Me.DataGridTextBoxColumn3.Width = 110
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "�R���^�N�g���e"
        Me.DataGridTextBoxColumn4.MappingName = "contact_memo"
        Me.DataGridTextBoxColumn4.Width = 590
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.MappingName = "contact_fin_flg"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.ReadOnly = True
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 0
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
        Me.DataGridTextBoxColumn6.MappingName = "contact_code"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 0
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.MappingName = "contact_empl"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 0
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(228, 336)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "�N���A"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(128, 336)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "CSV���o"
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
        Me.Button3.Text = "��No�Ɖ�"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(380, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 1443
        Me.Label2.Text = "����Č���"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(300, 40)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1442
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(660, 24)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1441
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(24, 312)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(956, 16)
        Me.msg.TabIndex = 1440
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Label16_1.TabIndex = 1439
        Me.Label16_1.Text = "����ē��e"
        Me.Label16_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date001
        '
        Me.Date001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Enabled = False
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
        Me.Label35.TabIndex = 1438
        Me.Label35.Text = "����ē���"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(20, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 20)
        Me.Label20.TabIndex = 1437
        Me.Label20.Text = "����ĒS��"
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
        Me.Label18.TabIndex = 1436
        Me.Label18.Text = "��t�ԍ�"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo001.Location = New System.Drawing.Point(460, 20)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 0
        Me.Combo001.Value = "Combo001"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 336)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 9
        Me.Button98.Text = "�߂�"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "�X�V"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(368, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 32)
        Me.Label1.TabIndex = 1446
        Me.Label1.Text = "�V�K"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Magenta
        Me.Label3.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(368, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 32)
        Me.Label3.TabIndex = 1447
        Me.Label3.Text = "�X�V"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label0
        '
        Me.Label0.Location = New System.Drawing.Point(100, 20)
        Me.Label0.Name = "Label0"
        Me.Label0.Size = New System.Drawing.Size(112, 16)
        Me.Label0.TabIndex = 1448
        Me.Label0.Text = "Label0"
        Me.Label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox001
        '
        Me.CheckBox001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(848, 56)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 3
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(752, 56)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 1450
        Me.Label52.Text = "����Ċ���"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(708, 336)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 1451
        Me.Button5.TabStop = False
        Me.Button5.Text = "����"
        '
        'F00_Form16
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1000, 686)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label0)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.key)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
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
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F00_Form16"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�R���^�N�g���O"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F00_Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()                       '**  ��������
        ACES()                      '**  �����`�F�b�N
        CmbSet()                    '**  �R���{�{�b�N�X�Z�b�g
        DspSet()                    '**  ��ʃZ�b�g
        Button4_Click(sender, e)    '**  �N���A
    End Sub

    '********************************************************************
    '**  �����`�F�b�N
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='997'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button2.Enabled = False
                Case Is = "3"
                    Button2.Enabled = True
                Case Is = "4"
                    Button2.Enabled = True
            End Select
        Else
            Button2.Enabled = False
        End If
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Label0.Text = P_PRAM1   '��t�ԍ�
    End Sub

    '********************************************************************
    '**  �R���{�{�b�N�X�Z�b�g
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        '����Č���
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '036') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_036")

        Combo001.DataSource = DsCMB.Tables("CLS_CODE_036")
        Combo001.DisplayMember = "cls_code_name"
        Combo001.ValueMember = "cls_code"
        Combo001.Text = Nothing

        '�R���^�N�g�S��
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

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  ��ʃZ�b�g
    '********************************************************************
    Sub DspSet()

        DsList1.Clear()
        strSQL = "SELECT TOP (100) PERCENT T08_CONTACT.*, V_cls_036.cls_code_name AS contact_name, M01_EMPL.name AS contact_empl_name"
        strSQL += " FROM T08_CONTACT INNER JOIN"
        strSQL += " M01_EMPL ON T08_CONTACT.contact_empl = M01_EMPL.empl_code LEFT OUTER JOIN"
        strSQL += " V_cls_036 ON T08_CONTACT.contact_code = V_cls_036.cls_code"
        strSQL += " WHERE (T08_CONTACT.rcpt_no = '" & P_PRAM1 & "')"
        strSQL += " ORDER BY T08_CONTACT.contact_date DESC, T08_CONTACT.contact_code, T08_CONTACT.contact_empl"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "T08_CONTACT")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("T08_CONTACT"), "", "", DataViewRowState.CurrentRows)

        Dim tbl As New DataTable
        tbl = DsList1.Tables("T08_CONTACT")
        DataGridEx1.DataSource = tbl

    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�F
    '********************************************************************
    Private Sub DataGridEx1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�G���^�[
    '********************************************************************
    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    msg.Text = Nothing
                    Combo001.BackColor = System.Drawing.SystemColors.Window
                    Combo002.BackColor = System.Drawing.SystemColors.Window
                    Edit001.BackColor = System.Drawing.SystemColors.Window

                    key.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 5)
                    CL001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 6)
                    Combo001.Text = CL001.Text & ":" & DataGridEx1(DataGridEx1.CurrentRowIndex, 1) : CG_str(1) = Combo001.Text
                    CL002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 7)
                    Combo002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 2) : CG_str(2) = Combo002.Text
                    Date001.Text = Format(DataGridEx1(DataGridEx1.CurrentRowIndex, 0), "yyyy/MM/dd HH:mm")
                    Edit001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 3) : CG_str(4) = Edit001.Text
                    If DataGridEx1(DataGridEx1.CurrentRowIndex, 4) = "True" Then
                        CheckBox001.Checked = True
                    Else
                        CheckBox001.Checked = False
                    End If
                    CG_str(5) = CheckBox001.Checked

                    Label1.Visible = False
                    Label3.Visible = True
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�N���b�N
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                msg.Text = Nothing
                Combo001.BackColor = System.Drawing.SystemColors.Window
                Combo002.BackColor = System.Drawing.SystemColors.Window
                Edit001.BackColor = System.Drawing.SystemColors.Window

                key.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 5)
                CL001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 6)
                Combo001.Text = CL001.Text & ":" & DataGridEx1(DataGridEx1.CurrentRowIndex, 1) : CG_str(1) = Combo001.Text
                CL002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 7)
                Combo002.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 2) : CG_str(2) = Combo002.Text
                Date001.Text = Format(DataGridEx1(DataGridEx1.CurrentRowIndex, 0), "yyyy/MM/dd HH:mm")
                Edit001.Text = DataGridEx1(DataGridEx1.CurrentRowIndex, 3) : CG_str(4) = Edit001.Text
                If DataGridEx1(DataGridEx1.CurrentRowIndex, 4) = "True" Then
                    CheckBox001.Checked = True
                Else
                    CheckBox001.Checked = False
                End If
                CG_str(5) = CheckBox001.Checked

                Label1.Visible = False
                Label3.Visible = True
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  ���ڃ`�F�b�N
    '********************************************************************
    Sub CHK_Combo001()   '����Č���
        msg.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            Combo001.BackColor = System.Drawing.Color.Red
            msg.Text = "����Č��������͂���Ă��܂���B"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("CLS_CODE_036"), "cls_code_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "�Y���������Č���������܂���B"
                Exit Sub
            Else
                CL001.Text = WK_DtView1(0)("cls_code")
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo002()   '����ĒS��
        msg.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            Combo002.BackColor = System.Drawing.Color.Red
            msg.Text = "����ĒS�������͂���Ă��܂���B"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M01_EMPL"), "name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "�Y���������ĒS��������܂���B"
                Exit Sub
            Else
                CL002.Text = WK_DtView1(0)("empl_code")
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit001()   '����ē��e
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "����ē��e�����͂���Ă��܂���B"
            Exit Sub
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        CHK_Combo001()   '����Č���
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Combo002()  '����ĒS��
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Edit001()   '����ē��e
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
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   '�⍇����
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()   '�⍇���S��
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '�⍇�����e
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        CheckBox001.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  �X�V
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_Check()
        If Err_F = "0" Then

            CHG_HSTY()  '**  �ύX����

            If key.Text = Nothing Then
                strSQL = "INSERT INTO T08_CONTACT"
                strSQL += " (rcpt_no, contact_code, contact_empl, contact_date, contact_memo, contact_fin_flg)"
                strSQL += " VALUES ('" & P_PRAM1 & "'"
                strSQL += ", '" & CL001.Text & "'"
                strSQL += ", " & CL002.Text & ""
                strSQL += ", '" & Date001.Text & "'"
                strSQL += ", '" & Edit001.Text & "'"
                If CheckBox001.Checked = True Then strSQL += ", 1)" Else strSQL += ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                add_hsty2(P_PRAM1, Date001.Text & " �V�K", "", "")

                '�����X�V
                strSQL = "UPDATE T08_CONTACT"
                If CheckBox001.Checked = True Then strSQL += " SET contact_fin_flg = 1" Else strSQL += " SET contact_fin_flg = 0"
                strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                DspSet()                    '**  ��ʃZ�b�g
                Button4_Click(sender, e)    '**  �N���A
                msg.Text = "�o�^���܂����B"
            Else
                If chg_itm <> 0 Then

                    strSQL = "UPDATE T08_CONTACT"
                    strSQL += " SET contact_code = '" & CL001.Text & "'"
                    strSQL += ", contact_empl = " & CL002.Text & ""
                    strSQL += ", contact_date = CONVERT(DATETIME, '" & Date001.Text & "', 102)"
                    strSQL += ", contact_memo = '" & Edit001.Text & "'"
                    If CheckBox001.Checked = True Then strSQL += ", contact_fin_flg = 1" Else strSQL += ", contact_fin_flg = 0"
                    strSQL += " WHERE (key_no = " & key.Text & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nMVAR")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    '�����X�V
                    strSQL = "UPDATE T08_CONTACT"
                    If CheckBox001.Checked = True Then strSQL += " SET contact_fin_flg = 1" Else strSQL += " SET contact_fin_flg = 0"
                    strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nMVAR")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    DspSet()                    '**  ��ʃZ�b�g
                    Button4_Click(sender, e)    '**  �N���A
                    msg.Text = "�X�V���܂����B"
                Else
                    msg.Text = "�ύX�ӏ�������܂���B"
                End If
            End If

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �ύX����
    '********************************************************************
    Sub CHG_HSTY()
        chg_itm = 0
        P_HSTY_DATE = Now

        If key.Text <> Nothing Then

            If Combo001.Text <> CG_str(1) Then
                chg_itm = chg_itm + 1 : add_hsty2(P_PRAM1, Date001.Text & " ����Č���", CG_str(1), Combo001.Text)
            End If

            If Combo002.Text <> CG_str(2) Then
                chg_itm = chg_itm + 1 : add_hsty2(P_PRAM1, Date001.Text & " ����ĒS��", CG_str(2), Combo002.Text)
            End If

            If Edit001.Text <> CG_str(4) Then
                chg_itm = chg_itm + 1 : add_hsty2(P_PRAM1, Date001.Text & " ����ē��e", CG_str(4), Edit001.Text)
            End If

        End If

        If CheckBox001.Checked = True Then WK_str1 = "�Ώ�" Else WK_str1 = "�ΏۊO"
        If CG_str(5) = "True" Then WK_str2 = "�Ώ�" Else WK_str2 = "�ΏۊO"
        If WK_str1 <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty2(P_PRAM1, "����Ċ���", WK_str2, WK_str1)
        End If

    End Sub

    '********************************************************************
    '**  CSV���o
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
        sfd.FileName = "�����۸�_" & P_PRAM1 & ".CSV"           '�͂��߂̃t�@�C�������w�肷��
        sfd.Filter = "CSV�t�@�C��(*.CSV)|*.CSV"                 '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
        sfd.FilterIndex = 2                                     '[�t�@�C���̎��]�ł͂��߂� �u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
        sfd.Title = "�ۑ���̃t�@�C����I�����Ă�������"        '�^�C�g����ݒ肷��
        sfd.RestoreDirectory = True                             '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���

        '���ɑ��݂���t�@�C�������w�肵���Ƃ��x������
        '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
        sfd.OverwritePrompt = True

        '���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
        '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then     '�_�C�A���O��\������
            strFile = sfd.FileName   'OK�{�^�����N���b�N���ꂽ�Ƃ�

            ' �i�s�󋵃_�C�A���O�̏���������
            waitDlg = New WaitDialog        ' �i�s�󋵃_�C�A���O
            waitDlg.Owner = Me              ' �_�C�A���O�̃I�[�i�[��ݒ肷��
            waitDlg.MainMsg = Nothing       ' �����̊T�v��\��
            waitDlg.ProgressMax = 0         ' �S�̂̏���������ݒ�
            waitDlg.ProgressMin = 0         ' ���������̍ŏ��l��ݒ�i0������J�n�j
            waitDlg.ProgressStep = 1        ' �������ƂɃ��[�^��i�߂邩��ݒ�
            waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
            Me.Enabled = False              ' �I�[�i�[�̃t�H�[���𖳌��ɂ���
            waitDlg.Show()                  ' �i�s�󋵃_�C�A���O��\������

            waitDlg.MainMsg = "CSV�o�͒�"   ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMsg = ""        ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = r         ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
            Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

            '�f�[�^����������
            strData = "��t�ԍ�,�R���^�N�g����,�R���^�N�g����,�R���^�N�g�S��,�R���^�N�g���e"
            swFile.WriteLine(strData)

            DtView1 = New DataView(DsList1.Tables("T08_CONTACT"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strData = DtView1(i)("rcpt_no")                             '�`�[�ԍ�
                strData = strData & "," & DtView1(i)("contact_date")        '�R���^�N�g����
                strData = strData & "," & DtView1(i)("contact_name")        '�R���^�N�g����
                strData = strData & "," & DtView1(i)("contact_empl_name")   '�R���^�N�g�S��
                strData = strData & "," & DtView1(i)("contact_memo")        '�R���^�N�g���e
                strData = strData.Replace(System.Environment.NewLine, " ")
                swFile.WriteLine(strData)
            Next
            swFile.Close()          '�t�@�C�������
            MessageBox.Show("�o�͂��܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
            Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �N���A
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        key.Text = Nothing
        Combo001.Text = Nothing : CL001.Text = Nothing
        Combo002.Text = P_EMPL_NAME : CL002.Text = P_EMPL_NO
        Date001.Text = Format(Now, "yyyy/MM/dd HH:mm")
        Edit001.Text = Nothing
        Label1.Visible = True
        Label3.Visible = False
        msg.Text = Nothing
        CheckBox001.Checked = False
        If DtView1.Count <> 0 Then
            If DtView1(0)("contact_fin_flg") = "True" Then
                CheckBox001.Checked = True
            End If
        End If
        CG_str(5) = CheckBox001.Checked
    End Sub

    '********************************************************************
    '**  �����Ɖ�
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '�ύX����
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L07_HSTY", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = P_PRAM1
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ��No�Ɖ�
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_search.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("�N���ł��܂���ł���", "�G���[�ʒm")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �߂�
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub

End Class