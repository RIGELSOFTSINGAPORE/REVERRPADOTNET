Public Class F00_Form20
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB1, DsImp As New DataSet
    Dim WK_DsList1, WK_DsList2, WK_DsCMB1 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DtView1, WK_DtView2 As DataView
    Dim dttable0, dttable1, dttable2 As DataTable
    Dim dtRow0, dtRow1, dtRow2 As DataRow

    Dim strSQL, Err_F, DG_Err_F, Ans, WK_err_msg As String
    Dim i, j, k, r, en, Line_No, WK_SUI, WK_SU2, WK_Sou, WK_int, ok_cnt, err_cnt, imp_seq1, imp_seq2, imp_seq3 As Integer
    Dim file_name As String
    Dim WK_code, WK_str, WK_str2, WK_str3, WK_str4 As String
    Dim now_date, WK_date As Date

    Dim WK_ittpan, WK_vndr_code, WK_wrn_tem, WK_wrn_range As String
    Dim S_Edit04, S_Edit05 As String

    Dim fr_date, to_date As Date

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox04 As System.Windows.Forms.CheckBox
    Friend WithEvents Edit09 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Date
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn22 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn23 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn24 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn25 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn26 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn27 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn28 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn29 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn30 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn31 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents BR_cmb01 As System.Windows.Forms.Label
    Friend WithEvents BR_cmb09 As System.Windows.Forms.Label
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents tax_rate As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridBoolColumn2 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.CheckBox04 = New System.Windows.Forms.CheckBox
        Me.Edit09 = New GrapeCity.Win.Input.Edit
        Me.Label24 = New System.Windows.Forms.Label
        Me.Combo09 = New GrapeCity.Win.Input.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Combo01 = New GrapeCity.Win.Input.Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Date
        Me.Button2 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button4 = New System.Windows.Forms.Button
        Me.cmb01 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn31 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn23 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn24 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn25 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn26 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn27 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn28 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn29 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn30 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridBoolColumn2 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.BR_cmb01 = New System.Windows.Forms.Label
        Me.BR_cmb09 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.tax_rate = New System.Windows.Forms.Label
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(920, 652)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 11
        Me.Button99.Text = "����"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 652)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(724, 28)
        Me.msg.TabIndex = 1347
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "�捞"
        '
        'CheckBox04
        '
        Me.CheckBox04.AutoCheck = False
        Me.CheckBox04.Location = New System.Drawing.Point(932, 68)
        Me.CheckBox04.Name = "CheckBox04"
        Me.CheckBox04.Size = New System.Drawing.Size(60, 24)
        Me.CheckBox04.TabIndex = 5
        Me.CheckBox04.TabStop = False
        Me.CheckBox04.Text = "���"
        '
        'Edit09
        '
        Me.Edit09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit09.HighlightText = True
        Me.Edit09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit09.LengthAsByte = True
        Me.Edit09.Location = New System.Drawing.Point(624, 68)
        Me.Edit09.MaxLength = 50
        Me.Edit09.Name = "Edit09"
        Me.Edit09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit09.Size = New System.Drawing.Size(300, 24)
        Me.Edit09.TabIndex = 4
        Me.Edit09.Text = "Edit09"
        Me.Edit09.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(556, 68)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 24)
        Me.Label24.TabIndex = 1357
        Me.Label24.Text = "�S����"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(160, 68)
        Me.Combo09.MaxDropDownItems = 30
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(392, 24)
        Me.Combo09.TabIndex = 3
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(96, 68)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 24)
        Me.Label23.TabIndex = 1356
        Me.Label23.Text = "�戵�X"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(96, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 24)
        Me.Label9.TabIndex = 1355
        Me.Label9.Text = "��w"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo01.Location = New System.Drawing.Point(160, 40)
        Me.Combo01.MaxDropDownItems = 30
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(392, 24)
        Me.Combo01.TabIndex = 2
        Me.Combo01.Value = "Combo01"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(96, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 1351
        Me.Label1.Text = "�\����"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(160, 12)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1
        Me.Date01.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(832, 652)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 28)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "���f"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(744, 652)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 28)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "�N���A"
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(552, 28)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1363
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(612, 28)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1364
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'DataGrid2
        '
        Me.DataGrid2.BackgroundColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid2.CaptionForeColor = System.Drawing.SystemColors.Window
        Me.DataGrid2.CaptionText = " �G���[���X�g"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(8, 380)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.RowHeaderWidth = 10
        Me.DataGrid2.Size = New System.Drawing.Size(988, 264)
        Me.DataGrid2.TabIndex = 1368
        Me.DataGrid2.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        Me.DataGrid2.TabStop = False
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DataGrid2
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn31, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28, Me.DataGridTextBoxColumn29, Me.DataGridTextBoxColumn30})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "err"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn31
        '
        Me.DataGridTextBoxColumn31.Format = ""
        Me.DataGridTextBoxColumn31.FormatInfo = Nothing
        Me.DataGridTextBoxColumn31.HeaderText = "�G���[���b�Z�[�W"
        Me.DataGridTextBoxColumn31.MappingName = "err_msg"
        Me.DataGridTextBoxColumn31.NullText = ""
        Me.DataGridTextBoxColumn31.Width = 95
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "�w��"
        Me.DataGridTextBoxColumn16.MappingName = "dpmt_name"
        Me.DataGridTextBoxColumn16.NullText = ""
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "�w��"
        Me.DataGridTextBoxColumn17.MappingName = "sbjt_name"
        Me.DataGridTextBoxColumn17.NullText = ""
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "����"
        Me.DataGridTextBoxColumn18.MappingName = "name"
        Me.DataGridTextBoxColumn18.NullText = ""
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "������"
        Me.DataGridTextBoxColumn19.MappingName = "name_kana"
        Me.DataGridTextBoxColumn19.NullText = ""
        Me.DataGridTextBoxColumn19.Width = 75
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "�X�֔ԍ�"
        Me.DataGridTextBoxColumn20.MappingName = "zip"
        Me.DataGridTextBoxColumn20.NullText = ""
        Me.DataGridTextBoxColumn20.Width = 75
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "�Z���P"
        Me.DataGridTextBoxColumn21.MappingName = "adrs1"
        Me.DataGridTextBoxColumn21.NullText = ""
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "�Z���Q"
        Me.DataGridTextBoxColumn22.MappingName = "adrs2"
        Me.DataGridTextBoxColumn22.NullText = ""
        Me.DataGridTextBoxColumn22.Width = 75
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "�d�b�ԍ�"
        Me.DataGridTextBoxColumn23.MappingName = "tel"
        Me.DataGridTextBoxColumn23.NullText = ""
        Me.DataGridTextBoxColumn23.Width = 75
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "���[�J�["
        Me.DataGridTextBoxColumn24.MappingName = "vndr_name"
        Me.DataGridTextBoxColumn24.NullText = ""
        Me.DataGridTextBoxColumn24.Width = 75
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Format = ""
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.HeaderText = "���i���i�^���j"
        Me.DataGridTextBoxColumn25.MappingName = "modl_name"
        Me.DataGridTextBoxColumn25.NullText = ""
        Me.DataGridTextBoxColumn25.Width = 75
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.HeaderText = "�رٔԍ�"
        Me.DataGridTextBoxColumn26.MappingName = "s_no"
        Me.DataGridTextBoxColumn26.NullText = ""
        Me.DataGridTextBoxColumn26.Width = 75
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.HeaderText = "�w�����z�i�ŕʁj"
        Me.DataGridTextBoxColumn27.MappingName = "prch_amnt"
        Me.DataGridTextBoxColumn27.NullText = ""
        Me.DataGridTextBoxColumn27.Width = 75
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.HeaderText = "�ۏ؊���"
        Me.DataGridTextBoxColumn28.MappingName = "wrn_tem"
        Me.DataGridTextBoxColumn28.NullText = ""
        Me.DataGridTextBoxColumn28.Width = 75
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.HeaderText = "�ۏ؊J�n��"
        Me.DataGridTextBoxColumn29.MappingName = "makr_wrn_stat"
        Me.DataGridTextBoxColumn29.NullText = ""
        Me.DataGridTextBoxColumn29.Width = 75
        '
        'DataGridTextBoxColumn30
        '
        Me.DataGridTextBoxColumn30.Format = ""
        Me.DataGridTextBoxColumn30.FormatInfo = Nothing
        Me.DataGridTextBoxColumn30.HeaderText = "�ۏ͈ؔ�"
        Me.DataGridTextBoxColumn30.MappingName = "wrn_range"
        Me.DataGridTextBoxColumn30.NullText = ""
        Me.DataGridTextBoxColumn30.Width = 75
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 100)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(988, 272)
        Me.DataGrid1.TabIndex = 1369
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridBoolColumn1, Me.DataGridBoolColumn2, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ok"
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "���E"
        Me.DataGridBoolColumn1.MappingName = "suisen"
        Me.DataGridBoolColumn1.NullText = ""
        Me.DataGridBoolColumn1.NullValue = "False"
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 40
        '
        'DataGridBoolColumn2
        '
        Me.DataGridBoolColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn2.FalseValue = False
        Me.DataGridBoolColumn2.HeaderText = "����"
        Me.DataGridBoolColumn2.MappingName = "souki"
        Me.DataGridBoolColumn2.NullText = ""
        Me.DataGridBoolColumn2.NullValue = "False"
        Me.DataGridBoolColumn2.TrueValue = True
        Me.DataGridBoolColumn2.Width = 40
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "�w��"
        Me.DataGridTextBoxColumn1.MappingName = "dpmt_name"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "�w��"
        Me.DataGridTextBoxColumn2.MappingName = "sbjt_name"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "����"
        Me.DataGridTextBoxColumn3.MappingName = "name"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "������"
        Me.DataGridTextBoxColumn4.MappingName = "name_kana"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "�X�֔ԍ�"
        Me.DataGridTextBoxColumn5.MappingName = "zip"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "�Z���P"
        Me.DataGridTextBoxColumn6.MappingName = "adrs1"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "�Z���Q"
        Me.DataGridTextBoxColumn7.MappingName = "adrs2"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "�d�b�ԍ�"
        Me.DataGridTextBoxColumn8.MappingName = "tel"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "���[�J�["
        Me.DataGridTextBoxColumn9.MappingName = "vndr_name"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "���i���i�^���j"
        Me.DataGridTextBoxColumn10.MappingName = "modl_name"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "�رٔԍ�"
        Me.DataGridTextBoxColumn11.MappingName = "s_no"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "�w�����z�i�ŕʁj"
        Me.DataGridTextBoxColumn12.MappingName = "prch_amnt"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.ReadOnly = True
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "�ۏ؊���"
        Me.DataGridTextBoxColumn13.MappingName = "wrn_tem"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.ReadOnly = True
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "�ۏ؊J�n��"
        Me.DataGridTextBoxColumn14.MappingName = "makr_wrn_stat"
        Me.DataGridTextBoxColumn14.NullText = ""
        Me.DataGridTextBoxColumn14.ReadOnly = True
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "�ۏ͈ؔ�"
        Me.DataGridTextBoxColumn15.MappingName = "wrn_range"
        Me.DataGridTextBoxColumn15.NullText = ""
        Me.DataGridTextBoxColumn15.ReadOnly = True
        Me.DataGridTextBoxColumn15.Width = 75
        '
        'BR_cmb01
        '
        Me.BR_cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.BR_cmb01.Location = New System.Drawing.Point(268, 20)
        Me.BR_cmb01.Name = "BR_cmb01"
        Me.BR_cmb01.Size = New System.Drawing.Size(280, 16)
        Me.BR_cmb01.TabIndex = 1370
        Me.BR_cmb01.Text = "BR_cmb01"
        Me.BR_cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BR_cmb01.Visible = False
        '
        'BR_cmb09
        '
        Me.BR_cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.BR_cmb09.Location = New System.Drawing.Point(564, 8)
        Me.BR_cmb09.Name = "BR_cmb09"
        Me.BR_cmb09.Size = New System.Drawing.Size(280, 16)
        Me.BR_cmb09.TabIndex = 1371
        Me.BR_cmb09.Text = "BR_cmb09"
        Me.BR_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BR_cmb09.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(936, 8)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1373
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(964, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1372
        Me.CheckBox1.Visible = False
        '
        'tax_rate
        '
        Me.tax_rate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.tax_rate.Location = New System.Drawing.Point(272, 0)
        Me.tax_rate.Name = "tax_rate"
        Me.tax_rate.Size = New System.Drawing.Size(52, 16)
        Me.tax_rate.TabIndex = 1374
        Me.tax_rate.Text = "tax_rate"
        Me.tax_rate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tax_rate.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.Location = New System.Drawing.Point(40, 84)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(12, 16)
        Me.CheckBox3.TabIndex = 1375
        '
        'CheckBox4
        '
        Me.CheckBox4.Location = New System.Drawing.Point(72, 84)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(12, 16)
        Me.CheckBox4.TabIndex = 1376
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(568, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 24)
        Me.Label2.TabIndex = 1377
        Me.Label2.Text = "�X�܃R�[�h�F"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F00_Form20
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.tax_rate)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.BR_cmb09)
        Me.Controls.Add(Me.BR_cmb01)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CheckBox04)
        Me.Controls.Add(Me.Edit09)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form20"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�����҃f�[�^�捞"
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub F00_Form20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CmbSet()   '** �R���{�{�b�N�X�Z�b�g
        Call ds_set()   '** �f�[�^�Z�b�g
        Call inz()      '** ��������
        Call clr()      '** �N���A
    End Sub

    '********************************************************************
    '** �R���{�{�b�N�X�Z�b�g
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        '��w
        strSQL = "SELECT univ_code, univ_name FROM M01_univ WHERE (delt_flg = 0) ORDER BY univ_name_kana, univ_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M01_univ")
        Combo01.DataSource = DsCMB1.Tables("M01_univ")
        Combo01.DisplayMember = "univ_name"
        Combo01.ValueMember = "univ_code"

        '�̔��X
        strSQL = "SELECT shop_code, shop_name + '(' + shop_shop_code + ')' AS shop_name, ittpan FROM M04_shop WHERE (shop_code <> 0) AND (delt_flg = 0) ORDER BY shop_name_kana, shop_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M04_shop")
        Combo09.DataSource = DsCMB1.Tables("M04_shop")
        Combo09.DisplayMember = "shop_name"
        Combo09.ValueMember = "shop_code"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** �f�[�^�Z�b�g
    '********************************************************************
    Sub ds_set()
        DsList1.Clear()
        DB_OPEN("nQGCare")

        '�ۏ؊���
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSK')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "cls_HSK")

        '�ۏ͈ؔ�
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSY')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "cls_HSY")

        ''����ŗ�
        'WK_DsList1.Clear()
        'strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & Mid(Now.Date, 9, 2) & ")"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'r = DaList1.Fill(WK_DsList1, "cls_TAX")
        'If r <> 0 Then
        '    WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
        '    tax_rate.Text = WK_DtView1(0)("cls_code_name")
        'Else
        '    tax_rate.Text = 8
        'End If

        '���E��������
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'SUI') AND (cls_code = " & P_proc_y & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(DsList1, "cls_SUI")
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_SUI"), "", "", DataViewRowState.CurrentRows)
            WK_SUI = WK_DtView1(0)("cls_code_name")
        Else
            WK_SUI = 0
        End If

        '���E��������(forSurface)
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'SU2') AND (cls_code = " & P_proc_y & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(DsList1, "cls_SU2")
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_SU2"), "", "", DataViewRowState.CurrentRows)
            WK_SU2 = WK_DtView1(0)("cls_code_name")
        Else
            WK_SU2 = 0
        End If

        '������������
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'sou') AND (cls_code = " & P_proc_y & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(DsList1, "cls_sou")
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_sou"), "", "", DataViewRowState.CurrentRows)
            WK_sou = WK_DtView1(0)("cls_code_name")
        Else
            WK_sou = 0
        End If

        '���[�J�[
        strSQL = "SELECT vndr_code, name FROM M05_VNDR"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "M05_VNDR")

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing

        strSQL = "SELECT * FROM W01_impt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsImp, "imp")
        DaList1.Fill(DsImp, "ok")
        DaList1.Fill(DsImp, "err")
        DB_CLOSE()

        DsImp.Clear()

        Dim tbl1 As New DataTable
        tbl1 = DsImp.Tables("ok")
        DataGrid1.DataSource = tbl1

        Dim tbl2 As New DataTable
        tbl2 = DsImp.Tables("err")
        DataGrid2.DataSource = tbl2

        '�V�����s�̒ǉ����֎~����
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGrid1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

    End Sub

    '********************************************************************
    '** �N���A
    '********************************************************************
    Sub clr()
        Date01.Number = 0
        Combo01.Text = Nothing : cmb01.Text = Nothing : BR_cmb01.Text = Nothing
        Combo09.Text = Nothing : cmb09.Text = Nothing : BR_cmb09.Text = "@"
        Edit09.Text = Nothing
        Label2.Text = "�X�܃R�[�h�F"
        CheckBox04.Checked = False
        Button2.Enabled = False : Button4.Enabled = False
    End Sub

    '******************************************************************
    '** �捞��
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        DsImp.Clear()

        With OpenFileDialog1
            .CheckFileExists = True     '�t�@�C�������݂��邩�m�F
            .RestoreDirectory = True    '�f�B���N�g���̕���
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "Excel ̧��(*.xls)|*.xls|Excel ̧��(*.xlsx)|*.xlsx|���ׂẴt�@�C��(*.*)|*.*"
            .FilterIndex = 1            'Filter�v���p�e�B��2�ڂ�\��
            '�_�C�A���O�{�b�N�X��\�����A�m�J��]���N���b�N�����ꍇ
            If .ShowDialog = DialogResult.OK Then

                file_name = .FileName

                Dim oExcel As Object
                Dim oBook As Object
                Dim oSheet As Object
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Open(filename:=file_name)
                oSheet = oBook.Worksheets(1)

                If IsDate(oSheet.Range("C9").Value) = True Then
                    Date01.Text = Format(oSheet.Range("C9").Value, "yyyy/MM/dd")
                End If
                Call CK_Date01()    '�\����
                Combo01.Text = oSheet.Range("C10").Value
                BR_cmb01.Text = Nothing
                Call CK_Combo01()   '��w
                Combo09.Text = oSheet.Range("F10").Value
                BR_cmb09.Text = "@"
                Call CK_Combo09()   '�̔��X
                Edit09.Text = oSheet.Range("C11").Value
                If Edit09.Text <> Nothing Then Edit09.Text = Edit09.Text.Replace("'", "�f")
                Label2.Text = "�X�܃R�[�h�F" & oSheet.Range("F9").Value


                For j = 17 To 65536
                    If oSheet.Range("B" & j).Value = "" Then Exit For

                    dttable0 = DsImp.Tables("imp")
                    dtRow0 = dttable0.NewRow
                    dtRow0("univ_name") = Trim(oSheet.Range("B" & j).Value)                             '��w
                    dtRow0("dpmt_name") = MidB(Trim(oSheet.Range("C" & j).Value), 1, 50)                '�w��
                    dtRow0("sbjt_name") = MidB(Trim(oSheet.Range("D" & j).Value), 1, 50)                '�w��
                    WK_str = Trim(Trim(oSheet.Range("E" & j).Value) & " " & Trim(oSheet.Range("F" & j).Value))
                    If WK_str <> Nothing Then WK_str = WK_str.Replace(vbCrLf, "")
                    dtRow0("name") = MidB(WK_str, 1, 50)         '����
                    'dtRow0("name") = MidB(Trim(Trim(oSheet.Range("E" & j).Value) & " " & Trim(oSheet.Range("F" & j).Value)), 1, 50)         '����
                    WK_str = Trim(Trim(oSheet.Range("G" & j).Value) & " " & Trim(oSheet.Range("H" & j).Value))
                    If WK_str <> Nothing Then WK_str = WK_str.Replace(vbCrLf, "")
                    dtRow0("name_kana") = MidB(WK_str, 1, 50)    '�J�i
                    'dtRow0("name_kana") = MidB(Trim(Trim(oSheet.Range("G" & j).Value) & " " & Trim(oSheet.Range("H" & j).Value)), 1, 50)    '�J�i
                    dtRow0("zip") = StrConv(Trim(oSheet.Range("I" & j).Value), VbStrConv.Narrow)        '�X�֔ԍ�
                    WK_str = Trim(oSheet.Range("J" & j).Value)
                    If WK_str <> Nothing Then WK_str = WK_str.Replace("'", "")
                    If WK_str <> Nothing Then WK_str = WK_str.Replace(vbCrLf, "")
                    dtRow0("adrs1") = MidB(StrConv(WK_str, VbStrConv.Narrow).Replace("'", ""), 1, 100)  '�Z��1
                    WK_str = Trim(oSheet.Range("K" & j).Value)
                    If WK_str <> Nothing Then WK_str = WK_str.Replace(vbCrLf, "")
                    If WK_str <> Nothing Then WK_str = WK_str.Replace("'", "")
                    dtRow0("adrs2") = MidB(StrConv(WK_str, VbStrConv.Narrow).Replace("'", ""), 1, 100)  '�Z��2  
                    dtRow0("tel") = MidB(StrConv(Trim(oSheet.Range("L" & j).Value), VbStrConv.Narrow), 1, 20)   '�d�b�ԍ�
                    WK_str = Trim(oSheet.Range("M" & j).Value)
                    If WK_str <> Nothing Then WK_str = WK_str.Replace("'", "")
                    dtRow0("vndr_name") = StrConv(WK_str, VbStrConv.Narrow)                             '���[�J�[��
                    WK_str = Trim(oSheet.Range("N" & j).Value)
                    If WK_str <> Nothing Then WK_str = WK_str.Replace("'", "")
                    dtRow0("modl_name") = MidB(WK_str, 1, 50)                                           '���i��
                    WK_str = Trim(oSheet.Range("O" & j).Value)
                    If WK_str <> Nothing Then WK_str = WK_str.Replace("'", "")
                    dtRow0("s_no") = MidB(WK_str, 1, 50)                                                '�V���A���ԍ�
                    dtRow0("prch_amnt") = Trim(oSheet.Range("P" & j).Value)                             '�w�����z�i�ŕʁj
                    dtRow0("wrn_tem") = Trim(oSheet.Range("Q" & j).Value)                               '�ۏ؊���
                    dtRow0("makr_wrn_stat") = Trim(oSheet.Range("R" & j).Value)                         '���[�J�[�ۏ؊J�n
                    dtRow0("wrn_range") = Trim(oSheet.Range("S" & j).Value)                             '�ۏ͈ؔ�
                    dttable0.Rows.Add(dtRow0)

                Next

                '==================  �I������  =====================  
                oSheet = Nothing
                oBook = Nothing
                oExcel.Quit()
                oExcel = Nothing
                GC.Collect()

                Call ok_err()    '** �n�j�f�[�^�ƃG���[�f�[�^�̐U�蕪��

                CheckBox3.Checked = False
                CheckBox4.Checked = False

            End If
        End With

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** �n�j�f�[�^�ƃG���[�f�[�^�̐U�蕪��
    '******************************************************************
    Sub ok_err()
        ok_cnt = 0
        err_cnt = 0
        DsImp.Tables("ok").Clear()
        DsImp.Tables("err").Clear()

        DtView1 = New DataView(DsImp.Tables("imp"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For k = 0 To DtView1.Count - 1

                Call DG_chk()
                If DG_Err_F = "0" Then
                    ok_cnt = ok_cnt + 1
                    dttable1 = DsImp.Tables("ok")
                    dtRow1 = dttable1.NewRow
                    dtRow1("univ_name") = DtView1(k)("univ_name")
                    dtRow1("dpmt_name") = DtView1(k)("dpmt_name")
                    dtRow1("sbjt_name") = DtView1(k)("sbjt_name")
                    dtRow1("name") = DtView1(k)("name")
                    dtRow1("name_kana") = DtView1(k)("name_kana")
                    dtRow1("zip") = DtView1(k)("zip")
                    dtRow1("adrs1") = DtView1(k)("adrs1")
                    dtRow1("adrs2") = DtView1(k)("adrs2")
                    dtRow1("tel") = DtView1(k)("tel")
                    dtRow1("vndr_name") = DtView1(k)("vndr_name")
                    dtRow1("modl_name") = DtView1(k)("modl_name")
                    dtRow1("s_no") = DtView1(k)("s_no")
                    dtRow1("prch_amnt") = DtView1(k)("prch_amnt")
                    dtRow1("wrn_tem") = DtView1(k)("wrn_tem")
                    dtRow1("makr_wrn_stat") = DtView1(k)("makr_wrn_stat")
                    dtRow1("wrn_range") = DtView1(k)("wrn_range")
                    dtRow1("suisen") = 0
                    dtRow1("souki") = 0
                    dttable1.Rows.Add(dtRow1)
                Else
                    err_cnt = err_cnt + 1
                    dttable2 = DsImp.Tables("err")
                    dtRow2 = dttable2.NewRow
                    dtRow2("err_msg") = WK_err_msg
                    dtRow2("univ_name") = DtView1(k)("univ_name")
                    dtRow2("dpmt_name") = DtView1(k)("dpmt_name")
                    dtRow2("sbjt_name") = DtView1(k)("sbjt_name")
                    dtRow2("name") = DtView1(k)("name")
                    dtRow2("name_kana") = DtView1(k)("name_kana")
                    dtRow2("zip") = DtView1(k)("zip")
                    dtRow2("adrs1") = DtView1(k)("adrs1")
                    dtRow2("adrs2") = DtView1(k)("adrs2")
                    dtRow2("tel") = DtView1(k)("tel")
                    dtRow2("vndr_name") = DtView1(k)("vndr_name")
                    dtRow2("modl_name") = DtView1(k)("modl_name")
                    dtRow2("s_no") = DtView1(k)("s_no")
                    dtRow2("prch_amnt") = DtView1(k)("prch_amnt")
                    dtRow2("wrn_tem") = DtView1(k)("wrn_tem")
                    dtRow2("makr_wrn_stat") = DtView1(k)("makr_wrn_stat")
                    dtRow2("wrn_range") = DtView1(k)("wrn_range")
                    dttable2.Rows.Add(dtRow2)
                End If
            Next
            Button4.Enabled = True
            Button2.Enabled = True
        Else
            Button4.Enabled = False
            Button2.Enabled = False
        End If

    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�F
    '********************************************************************
    Private Sub DataGrid1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
        If DataGrid1.CurrentRowIndex >= 0 Then
            DataGrid1.Select(DataGrid1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�N���b�N
    '********************************************************************
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))

            If hitinfo.Column = 0 Then  '�����ޯ�� �د�
                If DataGrid1.CurrentRowIndex <= ok_cnt Then
                    If DataGrid1(DataGrid1.CurrentRowIndex, 0) = "False" Then
                        DataGrid1(DataGrid1.CurrentRowIndex, 0) = CheckBox1.Checked
                    Else
                        DataGrid1(DataGrid1.CurrentRowIndex, 0) = CheckBox2.Checked
                        DataGrid1(DataGrid1.CurrentRowIndex, 1) = CheckBox2.Checked
                    End If
                End If
            End If
            If hitinfo.Column = 1 Then  '�����ޯ�� �د�
                If DataGrid1.CurrentRowIndex <= ok_cnt Then
                    If DataGrid1(DataGrid1.CurrentRowIndex, 1) = "False" Then
                        DataGrid1(DataGrid1.CurrentRowIndex, 1) = CheckBox1.Checked
                        DataGrid1(DataGrid1.CurrentRowIndex, 0) = CheckBox1.Checked
                    Else
                        DataGrid1(DataGrid1.CurrentRowIndex, 1) = CheckBox2.Checked
                    End If
                End If
            End If

        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '******************************************************************
    '** ���ڃ`�F�b�N
    '******************************************************************
    Sub DG_chk()
        DG_Err_F = "0"

        '����
        If DtView1(k)("name") = Nothing Then
            WK_err_msg = "����������"
            DG_Err_F = "1" : Exit Sub
        End If

        '�Z��1
        If LenB(DtView1(k)("adrs1")) = 100 Then
            WK_err_msg = "�Z���P �����I�[�o�["
            DG_Err_F = "1" : Exit Sub
        End If

        '�Z��2
        If LenB(DtView1(k)("adrs2")) = 100 Then
            WK_err_msg = "�Z���Q �����I�[�o�["
            DG_Err_F = "1" : Exit Sub
        End If

        '���[�J�[��
        WK_vndr_code = Nothing
        If DtView1(k)("vndr_name") = Nothing Then
            WK_err_msg = "���[�J�[��������"
            DG_Err_F = "1" : Exit Sub
        Else
            WK_DtView1 = New DataView(DsList1.Tables("M05_VNDR"), "name = '" & DtView1(k)("vndr_name") & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                WK_err_msg = "�Y�����[�J�[���Ȃ�"
                DG_Err_F = "1" : Exit Sub
            Else
                WK_vndr_code = WK_DtView1(0)("vndr_code")
            End If
        End If

        '���i��
        If DtView1(k)("modl_name") = Nothing Then
            WK_err_msg = "���i��������"
            DG_Err_F = "1" : Exit Sub
        End If

        '�w�����z�i�ŕʁj
        If DtView1(k)("prch_amnt") = Nothing Then
            WK_err_msg = "�w�����z�i�ŕʁj������"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsNumeric(DtView1(k)("prch_amnt")) = False Then
                WK_err_msg = "�w�����z�i�ŕʁj���l�G���["
                DG_Err_F = "1" : Exit Sub
            End If
        End If

        '�ۏ؊���
        WK_wrn_tem = Nothing
        If DtView1(k)("wrn_tem") = Nothing Then
            WK_err_msg = "�ۏ؊��Ԗ�����"
            DG_Err_F = "1" : Exit Sub
        Else
            WK_DtView1 = New DataView(DsList1.Tables("cls_HSK"), "cls_code_name = '" & DtView1(k)("wrn_tem") & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                WK_err_msg = "�Y���ۏ؊��ԂȂ�"
                DG_Err_F = "1" : Exit Sub
            Else
                WK_wrn_tem = WK_DtView1(0)("cls_code")
            End If
        End If

        '���[�J�[�ۏ؊J�n
        If DtView1(k)("makr_wrn_stat") = Nothing Then
            WK_err_msg = "���[�J�[�ۏ؊J�n������"
            DG_Err_F = "1" : Exit Sub
        Else
            If IsDate(DtView1(k)("makr_wrn_stat")) = False Then
                WK_err_msg = "���[�J�[�ۏ؊J�n���t�G���["
                DG_Err_F = "1" : Exit Sub
            Else
                Dim a1 As String
                a1 = DtView1(k)("makr_wrn_stat")
                DtView1(k)("makr_wrn_stat") = Format(CDate(DtView1(k)("makr_wrn_stat")), "yyyy/MM/dd")
            End If
        End If

        '�ۏ͈ؔ�
        WK_wrn_range = Nothing
        If DtView1(k)("wrn_range") = Nothing Then
            WK_err_msg = "�ۏ͈͖ؔ�����"
            DG_Err_F = "1" : Exit Sub
        Else
            WK_DtView1 = New DataView(DsList1.Tables("cls_HSY"), "cls_code_name = '" & DtView1(k)("wrn_range") & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                WK_err_msg = "�Y���ۏ͈ؔ͂Ȃ�"
                DG_Err_F = "1" : Exit Sub
            Else
                WK_wrn_range = WK_DtView1(0)("cls_code")
            End If
        End If

        '��������(�ŕ�)�擾
        If CheckBox04.Checked = True Then WK_ittpan = "True" Else WK_ittpan = "False"
        If wrn_fee_Get(WK_ittpan, WK_vndr_code, WK_wrn_tem, WK_wrn_range, P_proc_y) = 0 Then
            WK_err_msg = "���������}�X�^�̐ݒ肪����܂���B"
            DG_Err_F = "1" : Exit Sub
        End If

        '�d���`�F�b�N�i��w���Ǝ����j
        If cmb01.Text <> Nothing Then
            WK_DtView1 = New DataView(DsImp.Tables("ok"), "name = '" & DtView1(k)("name") & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                WK_err_msg = "�t�@�C�����ɓ�����������"
                DG_Err_F = "1" : Exit Sub
            End If

            WK_DsList1.Clear()
            strSQL = "SELECT univ_code, user_name FROM T01_member"
            strSQL += " WHERE (univ_code = " & cmb01.Text & ")"
            strSQL += " AND (user_name = '" & DtView1(k)("name") & "')"
            strSQL += " AND (nendo = " & P_proc_y & ") AND (delt_flg = 0)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "T01_member")
            DB_CLOSE()
            If r <> 0 Then
                WK_err_msg = "��w���Ǝ����Ŋ��ɓ��͍ς�"
                DG_Err_F = "1" : Exit Sub
            End If
        End If

    End Sub

    Sub F_chk()
        msg.Text = Nothing
        Err_F = "0"

        Call CK_Date01()    '�\����
        If msg.Text <> Nothing Then Err_F = "1" : Date01.Focus() : Exit Sub

        Call CK_Combo01()   '��w
        If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

        Call CK_Combo09()   '�̔��X
        If msg.Text <> Nothing Then Err_F = "1" : Combo09.Focus() : Exit Sub

        Call CK_Edit09()    '�S����
        If msg.Text <> Nothing Then Err_F = "1" : Edit09.Focus() : Exit Sub

    End Sub

    Sub CK_Date01()     '�\����
        msg.Text = Nothing
        If Date01.Number = 0 Then
            Date01.BackColor = System.Drawing.Color.Red
            msg.Text = "�\�������o�^" : Exit Sub
        Else
            '����ŗ�
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
                tax_rate.Text = 10
            End If
        End If
        Date01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo01()    '��w
        msg.Text = Nothing
        Combo01.Text = Trim(Combo01.Text)

        If BR_cmb01.Text <> Combo01.Text Then
            cmb01.Text = Nothing
            If Combo01.Text = Nothing Then
                Combo01.BackColor = System.Drawing.Color.Red
                msg.Text = "��w���o�^" : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("M01_univ"), "univ_name = '" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    Combo01.BackColor = System.Drawing.Color.Red
                    msg.Text = "�Y����w�Ȃ�" : Exit Sub
                Else
                    cmb01.Text = DtView1(0)("univ_code")
                End If
            End If
            BR_cmb01.Text = Combo01.Text

            Call ok_err()
        End If

        Combo01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo09()    '�̔��X
        msg.Text = Nothing
        Combo09.Text = Trim(Combo09.Text)

        If BR_cmb09.Text <> Combo09.Text Then
            CheckBox04.Checked = False
            cmb09.Text = "0"
            If Combo09.Text = Nothing Then
                Combo09.BackColor = System.Drawing.Color.Red
                msg.Text = "�̔��X���o�^" : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("M04_shop"), "shop_name = '" & Combo09.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    Combo09.BackColor = System.Drawing.Color.Red
                    msg.Text = "�Y���̔��X�Ȃ�" : Exit Sub
                Else
                    cmb09.Text = DtView1(0)("shop_code")
                    If DtView1(0)("ittpan") = "True" Then
                        CheckBox04.Checked = True   '���
                    End If
                End If
            End If
            BR_cmb09.Text = Combo09.Text

            Call ok_err()
        End If

        Combo09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit09()     '�̔���
        msg.Text = Nothing
        Edit09.Text = Trim(Edit09.Text).Replace("'", "�f")

        'If Edit09.Text = Nothing Then
        '    Edit09.BackColor = System.Drawing.Color.Red
        '    msg.Text = "�̔������o�^" : Exit Sub
        'End If
        Edit09.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** �N���A
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Ans = MessageBox.Show("��ƒ��̃f�[�^���������܂��B", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If Ans = "1" Then
            DsImp.Clear()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ���f
    '******************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** ���ڃ`�F�b�N
        If Err_F = "0" Then
            now_date = Now.Date

            Dim F00_Form20_01 As New F00_Form20_01
            F00_Form20_01.ShowDialog()
            If cmnt = "@Cancel" Then Cursor = System.Windows.Forms.Cursors.Default : Exit Sub

            'OK��
            WK_DtView1 = New DataView(DsImp.Tables("ok"), "", "", DataViewRowState.CurrentRows)
            imp_seq1 = Count_Get2("IMP") '�捞�݇�
            For j = 0 To WK_DtView1.Count - 1

                WK_DtView2 = New DataView(DsList1.Tables("cls_HSY"), "cls_code_name = '" & WK_DtView1(j)("wrn_range") & "'", "", DataViewRowState.CurrentRows)
                WK_str3 = WK_DtView2(0)("cls_code") '�ۏ͈ؔ�

                Select Case WK_str3
                    Case Is = "7"           '�����ۏ�
                        WK_code = Count_Get("A" & P_proc_y1 & "03")
                    Case Is = "11", "12", "17", "18"    '�Z�[�t�e�B�v���X�A�Z�[�t�e�B�U�v���X�A�t���b�g�v���X�A�t���b�g�U�v���X
                        WK_code = Count_Get("M" & P_proc_y1 & "01")
                    Case Else
                        If CheckBox04.Checked = True Then
                            WK_code = Count_Get("E" & P_proc_y1 & "01")
                        Else
                            WK_code = Count_Get("A" & P_proc_y1 & "01")
                        End If
                End Select

                '�ۏ؊���
                WK_DtView2 = New DataView(DsList1.Tables("cls_HSK"), "cls_code_name = '" & WK_DtView1(j)("wrn_tem") & "'", "", DataViewRowState.CurrentRows)
                WK_str2 = WK_DtView2(0)("cls_code")

                '�ۏ؊J�n�I��
                If WK_DtView1(j)("suisen") = "True" Then
                    WK_date = P_proc_y & "/04/01"
                Else
                    WK_date = WK_DtView1(j)("makr_wrn_stat")
                End If
                fr_date = WK_date
                to_date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, CInt(WK_str2), WK_date))

                strSQL = "INSERT INTO T01_member"
                strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1, adrs2"
                strSQL += ", tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt, wrn_tem"
                strSQL += ", makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee, tax_rate"
                strSQL += ", Part_prt, Part_prt_bak, tonan_flg, zenson_flg, suisen_flg, souki_flg, imp_seq, memo, nendo, reg_date, delt_flg)"
                strSQL += " VALUES ('" & WK_code & "'"                                          '�����ԍ�
                strSQL += ", '" & WK_DtView1(j)("name") & "'"                                   '����
                S_Edit04 = Replace(Replace(WK_DtView1(j)("name"), " ", ""), "�@", "")
                strSQL += ", '" & S_Edit04 & "'"                                                '�����p����
                strSQL += ", '" & WK_DtView1(j)("name_kana") & "'"                              '�J�i
                S_Edit05 = Replace(Replace(WK_DtView1(j)("name_kana"), " ", ""), "�@", "")
                strSQL += ", '" & S_Edit05 & "'"                                                '�����p�J�i
                WK_str = WK_DtView1(j)("zip")
                WK_str = nmc_Cng(WK_str)
                strSQL += ", '" & Mid(WK_str, 1, 7) & "'"                                       '�X�֔ԍ�
                strSQL += ", '" & WK_DtView1(j)("adrs1") & "'"                                  '�Z��1
                strSQL += ", '" & WK_DtView1(j)("adrs2") & "'"                                  '�Z��2
                strSQL += ", '" & WK_DtView1(j)("tel") & "'"                                    '�d�b�ԍ�
                strSQL += ", " & cmb01.Text                                                     '��w
                strSQL += ", '" & WK_DtView1(j)("dpmt_name") & "'"                              '�w��
                strSQL += ", '" & WK_DtView1(j)("sbjt_name") & "'"                              '�w��

                WK_DtView2 = New DataView(DsList1.Tables("M05_VNDR"), "name = '" & WK_DtView1(j)("vndr_name") & "'", "", DataViewRowState.CurrentRows)
                strSQL += ", '" & WK_DtView2(0)("vndr_code") & "'"                              '���[�J�[
                WK_str = WK_DtView2(0)("vndr_code")
                strSQL += ", '" & WK_DtView1(j)("modl_name") & "'"                              '���i��
                strSQL += ", '" & WK_DtView1(j)("s_no") & "'"                                   '�V���A����
                strSQL += ", " & WK_DtView1(j)("prch_amnt")                                     '�w�����i
                strSQL += ", '" & WK_str2 & "'"                                                 '�ۏ؊���

                If WK_DtView1(j)("suisen") = "True" Then
                    WK_date = P_proc_y & "/04/01"
                Else
                    WK_date = WK_DtView1(j)("makr_wrn_stat")
                End If
                strSQL += ", CONVERT(DATETIME, '" & fr_date & "', 102)"                         '�ۏ؊J�n��
                strSQL += ", CONVERT(DATETIME, '" & to_date & "', 102)"                         '�I��

                strSQL += ", " & WK_str3                                                        '�ۏ͈ؔ�
                strSQL += ", " & cmb09.Text                                                     '�̔��X
                strSQL += ", '" & Edit09.Text & "'"                                             '�S����
                strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)"                     '�\����
                WK_int = wrn_fee_Get(CheckBox04.Checked, WK_str, WK_str2, WK_str3, P_proc_y)
                strSQL += ", " & WK_int                                                         '��������(�ŕ�)
                strSQL += ", " & tax_rate.Text                                                  '����ŗ�
                strSQL += ", 0"                                                                 '�����؈��
                strSQL += ", 0"                                                                 '�����ؖ߂�
                strSQL += ", 0"                                                                 '����
                strSQL += ", 0"                                                                 '�S��
                strSQL += ", 0"                                                                 '���E
                strSQL += ", 0"                                                                 '����
                strSQL += ", " & imp_seq1                                                       '�捞�݇�
                strSQL += ", '" & cmnt & "'"                                                    '����
                strSQL += ", " & P_proc_y                                                       '�N�x
                strSQL += ", CONVERT(DATETIME, '" & now_date & "', 102)"
                strSQL += ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Next

            '���E��
            imp_seq2 = 0
            WK_DtView1 = New DataView(DsImp.Tables("ok"), "suisen = 1", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then

                imp_seq2 = Count_Get2("IMP") '�捞�݇�
                For j = 0 To WK_DtView1.Count - 1

                    WK_str3 = "7" '�ۏ͈ؔ�
                    WK_code = Count_Get("A" & P_proc_y1 & "03")

                    '�ۏ؊J�n�I��
                    fr_date = DtView1(j)("makr_wrn_stat")
                    to_date = P_proc_y & "/03/31'"

                    strSQL = "INSERT INTO T01_member"
                    strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1, adrs2"
                    strSQL += ", tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt, wrn_tem"
                    strSQL += ", makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee, tax_rate"
                    strSQL += ", Part_prt, Part_prt_bak, tonan_flg, zenson_flg, suisen_flg, souki_flg, imp_seq, memo, nendo, reg_date, delt_flg)"
                    strSQL += " VALUES ('" & WK_code & "'"                                          '�����ԍ�
                    strSQL += ", '" & WK_DtView1(j)("name") & "'"                                   '����
                    S_Edit04 = Replace(Replace(WK_DtView1(j)("name"), " ", ""), "�@", "")
                    strSQL += ", '" & S_Edit04 & "'"                                                '�����p����
                    strSQL += ", '" & WK_DtView1(j)("name_kana") & "'"                              '�J�i
                    S_Edit05 = Replace(Replace(WK_DtView1(j)("name_kana"), " ", ""), "�@", "")
                    strSQL += ", '" & S_Edit05 & "'"                                                '�����p�J�i
                    WK_str = WK_DtView1(j)("zip") : WK_str = WK_str.Replace("-", "")
                    strSQL += ", '" & Mid(WK_str, 1, 7) & "'"                                       '�X�֔ԍ�
                    strSQL += ", '" & WK_DtView1(j)("adrs1") & "'"                                  '�Z��1
                    strSQL += ", '" & WK_DtView1(j)("adrs2") & "'"                                  '�Z��2
                    strSQL += ", '" & WK_DtView1(j)("tel") & "'"                                    '�d�b�ԍ�
                    strSQL += ", " & cmb01.Text                                                     '��w
                    strSQL += ", '" & WK_DtView1(j)("dpmt_name") & "'"                              '�w��
                    strSQL += ", '" & WK_DtView1(j)("sbjt_name") & "'"                              '�w��

                    WK_DtView2 = New DataView(DsList1.Tables("M05_VNDR"), "name = '" & WK_DtView1(j)("vndr_name") & "'", "", DataViewRowState.CurrentRows)
                    strSQL += ", '" & WK_DtView2(0)("vndr_code") & "'"                              '���[�J�[
                    WK_str = WK_DtView2(0)("vndr_code")
                    strSQL += ", '" & WK_DtView1(j)("modl_name") & "'"                              '���i��
                    strSQL += ", '" & WK_DtView1(j)("s_no") & "'"                                   '�V���A����
                    strSQL += ", " & WK_DtView1(j)("prch_amnt")                                     '�w�����i

                    WK_DtView2 = New DataView(DsList1.Tables("cls_HSK"), "cls_code_name = '" & WK_DtView1(j)("wrn_tem") & "'", "", DataViewRowState.CurrentRows)
                    strSQL += ", '" & WK_DtView2(0)("cls_code") & "'"                               '�ۏ؊���
                    WK_str2 = WK_DtView2(0)("cls_code")

                    strSQL += ", CONVERT(DATETIME, '" & fr_date & "', 102)"                         '�ۏ؊J�n��
                    strSQL += ", CONVERT(DATETIME, '" & to_date & "', 102)"                         '�I��

                    strSQL += ", " & WK_str3                                                        '�ۏ͈ؔ�
                    strSQL += ", " & cmb09.Text                                                     '�̔��X
                    strSQL += ", '" & Edit09.Text & "'"                                             '�S����
                    strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)"                     '�\����
                    If WK_DtView1(j)("wrn_range").indexof("forSurface") >= 0 Then
                        WK_int = WK_SU2
                    Else
                        WK_int = WK_SUI
                    End If
                    strSQL += ", " & WK_int                                                         '��������(�ŕ�)
                    strSQL += ", " & tax_rate.Text                                                  '����ŗ�
                    strSQL += ", 0"                                                                 '�����؈��
                    strSQL += ", 0"                                                                 '�����ؖ߂�
                    strSQL += ", 0"                                                                 '����
                    strSQL += ", 0"                                                                 '�S��
                    strSQL += ", 1"                                                                 '���E
                    strSQL += ", 0"                                                                 '����
                    strSQL += ", " & imp_seq2                                                       '�捞�݇�
                    strSQL += ", '" & cmnt & "'"                                                    '����
                    strSQL += ", " & P_proc_y                                                       '�N�x
                    strSQL += ", CONVERT(DATETIME, '" & now_date & "', 102)"
                    strSQL += ", 0)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nQGCare")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                Next
            End If

            '������
            imp_seq3 = 0
            WK_DtView1 = New DataView(DsImp.Tables("ok"), "souki = 1", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then

                imp_seq3 = Count_Get2("IMP") '�捞�݇�
                For j = 0 To WK_DtView1.Count - 1

                    WK_str3 = "7" '�ۏ͈ؔ�

                    '�ۏ؊���
                    WK_DtView2 = New DataView(DsList1.Tables("cls_HSK"), "cls_code_name = '" & WK_DtView1(j)("wrn_tem") & "'", "", DataViewRowState.CurrentRows)
                    WK_str2 = WK_DtView2(0)("cls_code")

                    '�ۏ؊J�n�I��
                    WK_date = P_proc_y & "/04/01"
                    fr_date = DateAdd(DateInterval.Year, CInt(WK_str2) - 1, WK_date)
                    to_date = P_proc_y + CInt(WK_str2) & "/03/31'"

                    WK_code = Count_Get("A" & Mid(fr_date, 4, 1) & "03")

                    strSQL = "INSERT INTO T01_member"
                    strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1, adrs2"
                    strSQL += ", tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt, wrn_tem"
                    strSQL += ", makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee, tax_rate"
                    strSQL += ", Part_prt, Part_prt_bak, tonan_flg, zenson_flg, suisen_flg, souki_flg, imp_seq, memo, nendo, reg_date, delt_flg)"
                    strSQL += " VALUES ('" & WK_code & "'"                                          '�����ԍ�
                    strSQL += ", '" & WK_DtView1(j)("name") & "'"                                   '����
                    S_Edit04 = Replace(Replace(WK_DtView1(j)("name"), " ", ""), "�@", "")
                    strSQL += ", '" & S_Edit04 & "'"                                                '�����p����
                    strSQL += ", '" & WK_DtView1(j)("name_kana") & "'"                              '�J�i
                    S_Edit05 = Replace(Replace(WK_DtView1(j)("name_kana"), " ", ""), "�@", "")
                    strSQL += ", '" & S_Edit05 & "'"                                                '�����p�J�i
                    WK_str = WK_DtView1(j)("zip") : WK_str = WK_str.Replace("-", "")
                    strSQL += ", '" & Mid(WK_str, 1, 7) & "'"                                       '�X�֔ԍ�
                    strSQL += ", '" & WK_DtView1(j)("adrs1") & "'"                                  '�Z��1
                    strSQL += ", '" & WK_DtView1(j)("adrs2") & "'"                                  '�Z��2
                    strSQL += ", '" & WK_DtView1(j)("tel") & "'"                                    '�d�b�ԍ�
                    strSQL += ", " & cmb01.Text                                                     '��w
                    strSQL += ", '" & WK_DtView1(j)("dpmt_name") & "'"                              '�w��
                    strSQL += ", '" & WK_DtView1(j)("sbjt_name") & "'"                              '�w��

                    WK_DtView2 = New DataView(DsList1.Tables("M05_VNDR"), "name = '" & WK_DtView1(j)("vndr_name") & "'", "", DataViewRowState.CurrentRows)
                    strSQL += ", '" & WK_DtView2(0)("vndr_code") & "'"                              '���[�J�[
                    WK_str = WK_DtView2(0)("vndr_code")
                    strSQL += ", '" & WK_DtView1(j)("modl_name") & "'"                              '���i��
                    strSQL += ", '" & WK_DtView1(j)("s_no") & "'"                                   '�V���A����
                    strSQL += ", " & WK_DtView1(j)("prch_amnt")                                     '�w�����i
                    strSQL += ", '" & WK_str2 & "'"                                                 '�ۏ؊���

                    strSQL += ", CONVERT(DATETIME, '" & fr_date & "', 102)"                         '�ۏ؊J�n��
                    strSQL += ", CONVERT(DATETIME, '" & to_date & "', 102)"                         '�I��

                    strSQL += ", " & WK_str3                                                        '�ۏ͈ؔ�
                    strSQL += ", " & cmb09.Text                                                     '�̔��X
                    strSQL += ", '" & Edit09.Text & "'"                                             '�S����
                    strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)"                     '�\����
                    WK_int = WK_Sou
                    strSQL += ", " & WK_int                                                         '��������(�ŕ�)
                    strSQL += ", " & tax_rate.Text                                                  '����ŗ�
                    strSQL += ", 0"                                                                 '�����؈��
                    strSQL += ", 0"                                                                 '�����ؖ߂�
                    strSQL += ", 0"                                                                 '����
                    strSQL += ", 0"                                                                 '�S��
                    strSQL += ", 0"                                                                 '���E
                    strSQL += ", 1"                                                                 '����
                    strSQL += ", " & imp_seq3                                                       '�捞�݇�
                    strSQL += ", '" & cmnt & "'"                                                    '����
                    strSQL += ", " & P_proc_y                                                       '�N�x
                    strSQL += ", CONVERT(DATETIME, '" & now_date & "', 102)"
                    strSQL += ", 0)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nQGCare")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                Next
            End If

            'Error��
            WK_DtView1 = New DataView(DsImp.Tables("err"), "", "", DataViewRowState.CurrentRows)
            For j = 0 To WK_DtView1.Count - 1

                strSQL = "INSERT INTO E01_member"
                strSQL += " (imp_date, err_msg, empl_code, univ_name, dpmt_name, sbjt_name, name"
                strSQL += ", name_kana, zip, adrs1, adrs2, tel, vndr_name, modl_name, s_no, prch_amnt"
                strSQL += ", wrn_tem, makr_wrn_stat, wrn_range, Part_date, univ_code, shop_code"
                strSQL += ", sale_pson, imp_seq, imp_seq2, imp_seq3, nendo)"
                strSQL += " VALUES (CONVERT(DATETIME, '" & now_date & "', 102)"     '�捞�ݓ�
                strSQL += ", '" & WK_DtView1(j)("err_msg") & "'"                    '�G���[���b�Z�[�W
                strSQL += ", " & P_EMPL_NO                                          '�捞�ݒS��
                strSQL += ", '" & WK_DtView1(j)("univ_name") & "'"                  '��w
                strSQL += ", '" & WK_DtView1(j)("dpmt_name") & "'"                  '�w��
                strSQL += ", '" & WK_DtView1(j)("sbjt_name") & "'"                  '�w��
                strSQL += ", '" & WK_DtView1(j)("name") & "'"                       '����
                strSQL += ", '" & WK_DtView1(j)("name_kana") & "'"                  '�J�i
                strSQL += ", '" & WK_DtView1(j)("zip") & "'"                        '�X�֔ԍ�
                strSQL += ", '" & WK_DtView1(j)("adrs1") & "'"                      '�Z��1
                strSQL += ", '" & WK_DtView1(j)("adrs2") & "'"                      '�Z��2
                strSQL += ", '" & WK_DtView1(j)("tel") & "'"                        '�d�b�ԍ�
                strSQL += ", '" & WK_DtView1(j)("vndr_name") & "'"                  '���[�J�[
                strSQL += ", '" & WK_DtView1(j)("modl_name") & "'"                  '���i��
                strSQL += ", '" & WK_DtView1(j)("s_no") & "'"                       '�V���A����
                strSQL += ", '" & WK_DtView1(j)("prch_amnt") & "'"                  '�w�����i
                strSQL += ", '" & WK_DtView1(j)("wrn_tem") & "'"                    '�ۏ؊���
                strSQL += ", '" & WK_DtView1(j)("makr_wrn_stat") & "'"              '�ۏ؊J�n��
                strSQL += ", '" & WK_DtView1(j)("wrn_range") & "'"                  '�ۏ͈ؔ�
                strSQL += ", '" & Date01.Text & "'"                                 '�\����
                strSQL += ", '" & cmb01.Text & "'"                                  '��w
                strSQL += ", '" & cmb09.Text & "'"                                  '�̔��X
                strSQL += ", '" & Edit09.Text & "'"                                 '�S����
                strSQL += ", " & imp_seq1                                           '�捞�݇�
                strSQL += ", " & imp_seq2                                           '�捞�݇�(���E)
                strSQL += ", " & imp_seq3                                           '�捞�݇�(����)
                strSQL += ", " & P_proc_y & ")"                                     '�N�x
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Next
            If imp_seq3 <> 0 Then
                MessageBox.Show("���f���܂����B" & System.Environment.NewLine & "�捞�݇�        �F" & imp_seq1 & System.Environment.NewLine & "�捞�݇�(���E)�F" & imp_seq2 & System.Environment.NewLine & "�捞�݇�(����)�F" & imp_seq3, "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            Else
                If imp_seq2 = 0 Then
                    MessageBox.Show("���f���܂����B" & System.Environment.NewLine & "�捞�݇��F" & imp_seq1, "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                Else
                    MessageBox.Show("���f���܂����B" & System.Environment.NewLine & "�捞�݇�        �F" & imp_seq1 & System.Environment.NewLine & "�捞�݇�(���E)�F" & imp_seq2, "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                End If
            End If

            DsImp.Clear()
            Call clr()      '** �N���A
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ����
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        WK_DsList1.Clear()
        WK_DsList2.Clear()
        WK_DsCMB1.Clear()
        DsList1.Clear()
        DsCMB1.Clear()
        DsImp.Clear()
        Close()
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        Call CK_Date01()    '�\����
    End Sub
    Private Sub Combo01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.LostFocus
        Call CK_Combo01()   '��w
    End Sub
    Private Sub Combo09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.LostFocus
        Call CK_Combo09()   '�̔��X
    End Sub
    Private Sub Edit09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit09.LostFocus
        Call CK_Edit09()    '�S����
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        WK_DtView1 = New DataView(DsImp.Tables("ok"), "", "", DataViewRowState.CurrentRows)
        For j = 0 To WK_DtView1.Count - 1
            If CheckBox3.Checked = "true" Then
                WK_DtView1(j)("suisen") = "true"
            Else
                WK_DtView1(j)("suisen") = "false"
                WK_DtView1(j)("souki") = "false"
            End If
        Next j
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        WK_DtView1 = New DataView(DsImp.Tables("ok"), "", "", DataViewRowState.CurrentRows)
        For j = 0 To WK_DtView1.Count - 1
            If CheckBox4.Checked = "true" Then
                WK_DtView1(j)("souki") = "true"
                WK_DtView1(j)("suisen") = "true"
            Else
                WK_DtView1(j)("souki") = "false"
            End If
        Next j
    End Sub

    ''******************************************************************
    ''** �\�����ύX��
    ''******************************************************************
    'Private Sub Date01_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date01.TextChanged
    '    If IsDate(Date01.Text) Then
    '        '����ŗ�
    '        WK_DsList1.Clear()
    '        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Date01.Text, 1, 4) & Mid(Date01.Text, 6, 2) & Mid(Date01.Text, 9, 2) & ")"
    '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '        DaList1.SelectCommand = SqlCmd1
    '        DB_OPEN("nQGCare")
    '        r = DaList1.Fill(WK_DsList1, "cls_TAX")
    '        DB_CLOSE()
    '        If r <> 0 Then
    '            WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
    '            tax_rate.Text = WK_DtView1(0)("cls_code_name")
    '        Else
    '            tax_rate.Text = 10
    '        End If
    '    Else
    '        tax_rate.Text = 10
    '    End If
    'End Sub
End Class
