Public Class F20_Form07
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, WK_DtView1 As DataView

    Dim strSQL, WK_str, WK_str2, strFile, strData, WK_invc_no As String
    Dim i, j, WK_sum1, sai, sin As Integer

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
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label_tax As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridEx1 As nMVAR_Invc.DataGridEx
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents DD As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Number013 As GrapeCity.Win.Input.Number
    Friend WithEvents Number012 As GrapeCity.Win.Input.Number
    Friend WithEvents Number011 As GrapeCity.Win.Input.Number
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F20_Form07))
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label_tax = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.CL001 = New System.Windows.Forms.Label
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridEx1 = New nMVAR_Invc.DataGridEx
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Label132 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.DD = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.msg = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Number013 = New GrapeCity.Win.Input.Number
        Me.Number012 = New GrapeCity.Win.Input.Number
        Me.Number011 = New GrapeCity.Win.Input.Number
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number011, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(100, 20)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1770
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 1789
        Me.Label1.Text = "���_"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(12, 548)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(108, 24)
        Me.Button6.TabIndex = 1775
        Me.Button6.Text = "�����f�[�^�o��"
        '
        'Number003
        '
        Me.Number003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number003.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number003.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number003.Enabled = False
        Me.Number003.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number003.HighlightText = True
        Me.Number003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number003.Location = New System.Drawing.Point(684, 516)
        Me.Number003.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number003.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number003.Name = "Number003"
        Me.Number003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number003.Size = New System.Drawing.Size(76, 20)
        Me.Number003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.TabIndex = 1785
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number003.Value = Nothing
        '
        'Label_tax
        '
        Me.Label_tax.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label_tax.Location = New System.Drawing.Point(404, 48)
        Me.Label_tax.Name = "Label_tax"
        Me.Label_tax.Size = New System.Drawing.Size(28, 16)
        Me.Label_tax.TabIndex = 1783
        Me.Label_tax.Text = "5"
        Me.Label_tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_tax.Visible = False
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(796, 548)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1776
        Me.Button98.Text = "�߂�"
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(228, 20)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1790
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = "##,##0"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "�����"
        Me.DataGridTextBoxColumn1.MappingName = "comp_shop_tax"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 76
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "##,##0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "�ō����v�z"
        Me.DataGridTextBoxColumn3.MappingName = "invc_amnt"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 76
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = "####"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "�����ԍ�"
        Me.DataGridTextBoxColumn5.MappingName = "i��vc_no"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 76
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(12, 76)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(852, 436)
        Me.DataGridEx1.TabIndex = 1773
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.DataGridTableStyle2.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn5})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "scan"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "QG_Care�ԍ�"
        Me.DataGridTextBoxColumn2.MappingName = "qg_care_no"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 85
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "��t�ԍ�"
        Me.DataGridTextBoxColumn4.MappingName = "rcpt_no"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "���q�l��"
        Me.DataGridTextBoxColumn6.MappingName = "user_name"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 95
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "MAKERN"
        Me.DataGridTextBoxColumn7.MappingName = "vndr_name_en"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "�掟�X��"
        Me.DataGridTextBoxColumn9.MappingName = "store_name"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 150
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "##,##0"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "�����z"
        Me.DataGridTextBoxColumn8.MappingName = "comp_shop_ttl"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 76
        '
        'Number002
        '
        Me.Number002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number002.Enabled = False
        Me.Number002.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number002.HighlightText = True
        Me.Number002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number002.Location = New System.Drawing.Point(608, 516)
        Me.Number002.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number002.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(76, 20)
        Me.Number002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 1782
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = Nothing
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.Navy
        Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label132.ForeColor = System.Drawing.Color.White
        Me.Label132.Location = New System.Drawing.Point(480, 516)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(52, 20)
        Me.Label132.TabIndex = 1781
        Me.Label132.Text = "���@�v"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number001
        '
        Me.Number001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Enabled = False
        Me.Number001.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(532, 516)
        Me.Number001.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(76, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1780
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = Nothing
        '
        'DD
        '
        Me.DD.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.DD.Location = New System.Drawing.Point(304, 48)
        Me.DD.Name = "DD"
        Me.DD.Size = New System.Drawing.Size(52, 16)
        Me.DD.TabIndex = 1779
        Me.DD.Text = "00"
        Me.DD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DD.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(228, 40)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 1772
        Me.Button4.Text = "����"
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(100, 44)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1771
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(128, 552)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(640, 16)
        Me.msg.TabIndex = 1777
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(20, 44)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 20)
        Me.Label35.TabIndex = 1778
        Me.Label35.Text = "������"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(764, 520)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 1791
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number013
        '
        Me.Number013.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number013.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number013.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number013.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number013.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number013.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number013.Enabled = False
        Me.Number013.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number013.HighlightText = True
        Me.Number013.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number013.Location = New System.Drawing.Point(684, 536)
        Me.Number013.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number013.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number013.Name = "Number013"
        Me.Number013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number013.Size = New System.Drawing.Size(76, 20)
        Me.Number013.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number013.TabIndex = 1795
        Me.Number013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number013.Value = Nothing
        Me.Number013.Visible = False
        '
        'Number012
        '
        Me.Number012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number012.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number012.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number012.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number012.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number012.Enabled = False
        Me.Number012.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number012.HighlightText = True
        Me.Number012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number012.Location = New System.Drawing.Point(608, 536)
        Me.Number012.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number012.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number012.Name = "Number012"
        Me.Number012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number012.Size = New System.Drawing.Size(76, 20)
        Me.Number012.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.TabIndex = 1794
        Me.Number012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number012.Value = Nothing
        Me.Number012.Visible = False
        '
        'Number011
        '
        Me.Number011.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number011.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number011.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number011.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number011.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number011.Enabled = False
        Me.Number011.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number011.HighlightText = True
        Me.Number011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number011.Location = New System.Drawing.Point(532, 536)
        Me.Number011.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number011.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number011.Name = "Number011"
        Me.Number011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number011.Size = New System.Drawing.Size(76, 20)
        Me.Number011.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.TabIndex = 1792
        Me.Number011.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number011.Value = Nothing
        Me.Number011.Visible = False
        '
        'F20_Form07
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(874, 580)
        Me.Controls.Add(Me.Number013)
        Me.Controls.Add(Me.Number012)
        Me.Controls.Add(Me.Number011)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label_tax)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.Label132)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.DD)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Combo001)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F20_Form07"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���������(�ی����)"
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number011, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F20_Form07_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        ACES()      '**  �����`�F�b�N
        CmbSet()
        sql()       '**  �f�[�^�Z�b�g
        DtGd()
        P_DsPRT.Clear()
        msg.Text = Nothing
        Number001.Value = 0 : Number011.Value = 0
        Number002.Value = 0 : Number012.Value = 0
        Number003.Value = 0 : Number013.Value = 0
        Label2.Text = Nothing
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date001.Text = Now.Date
        DD.Text = Mid(DateAdd(DateInterval.Day, 1, CDate(Date001.Text)), 9, 2)
        If DD.Text = "01" Then
            DD.Text = "99"
        Else
            DD.Text = Mid(Date001.Text, 9, 2)
        End If

        msg.Text = Nothing

        '����ŗ�GET
        strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '008')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "cls008")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("cls008"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Label_tax.Text = DtView1(0)("cls_code_name")
        Else
            Label_tax.Text = "5"
        End If
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='207'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button6.Enabled = False
                Case Is = "3", "4"
                    Button6.Enabled = True
            End Select
        Else
            Button6.Enabled = False
        End If

    End Sub

    '********************************************************************
    '**  �R���{�{�b�N�X�Z�b�g
    '********************************************************************
    Sub CmbSet()

        '����
        strSQL = "SELECT brch_code, brch_code + ':' + name AS brch_name"
        strSQL = strSQL & " FROM M03_BRCH"
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
    End Sub

    '********************************************************************
    '**  �f�[�^�Z�b�g
    '********************************************************************
    Sub sql()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        SqlCmd1 = New SqlClient.SqlCommand("sp_F20_07_5", cnsqlclient)  '���ɐ����ς��H
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = CL001.Text
        Pram2.Value = Date001.Text
        DaList1.SelectCommand = SqlCmd1
        sai = DaList1.Fill(P_DsPRT, "scan")

        SqlCmd1 = New SqlClient.SqlCommand("sp_F20_07", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram3.Value = DateAdd(DateInterval.Day, 1, CDate(Date001.Text))
        Pram4.Value = CL001.Text
        DaList1.SelectCommand = SqlCmd1
        sin = DaList1.Fill(P_DsPRT, "scan")
        DB_CLOSE()

        DtView1 = New DataView(P_DsPRT.Tables("scan"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            msg.Text = "�Y������f�[�^������܂���B"
        Else
            For i = 0 To DtView1.Count - 1
                Number001.Value = Number001.Value + DtView1(i)("comp_shop_ttl")
                Number002.Value = Number002.Value + DtView1(i)("comp_shop_tax")
                Number003.Value = Number003.Value + DtView1(i)("invc_amnt")
                If DtView1(i)("i��vc_no") = 0 Then
                    Number011.Value = Number011.Value + DtView1(i)("comp_shop_ttl")
                    Number012.Value = Number012.Value + DtView1(i)("comp_shop_tax")
                    Number013.Value = Number013.Value + DtView1(i)("invc_amnt")
                End If
            Next
        End If
        Label2.Text = Format(DtView1.Count, "##,##0") & " ��"

    End Sub
    Sub DtGd()
        Dim tbl As New DataTable
        tbl = P_DsPRT.Tables("scan")
        DataGridEx1.DataSource = tbl
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
        Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.GotFocus
        Date001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        If Date001.Number <> 0 Then
            DD.Text = Mid(DateAdd(DateInterval.Day, 1, CDate(Date001.Text)), 9, 2)
            If DD.Text = "01" Then
                DD.Text = "99"
            Else
                DD.Text = Mid(Date001.Text, 9, 2)
            End If
        Else
            DD.Text = "00"
        End If
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Date001_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.TextChanged
        P_DsPRT.Clear()
    End Sub

    '********************************************************************
    '** ����
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing
        Number001.Value = 0 : Number002.Value = 0 : Number003.Value = 0


        WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_name ='" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            msg.Text = "���_����͂��Ă��������B"
            Combo001.Focus()
        Else
            CL001.Text = WK_DtView1(0)("brch_code")

            If Date001.Number = 0 Then
                msg.Text = "����������͂��Ă��������B"
                Date001.Focus()
            Else
                If Date001.Text > Now.Date Then
                    msg.Text = "�{���ȍ~�̔������͓��͂ł��܂���B"
                    Date001.Focus()
                Else
                    sql()       '**  �f�[�^�Z�b�g
                End If
            End If
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** �����f�[�^�o��
    '********************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If DtView1.Count = 0 Then
            msg.Text = "�Y������f�[�^������܂���B"
            Exit Sub
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_HSTY_DATE = Now

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F20_07_5", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = CL001.Text
        Pram2.Value = Date001.Text
        DaList1.SelectCommand = SqlCmd1
        sai = DaList1.Fill(WK_DsList1, "Print01")

        SqlCmd1 = New SqlClient.SqlCommand("sp_F20_07", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram3.Value = DateAdd(DateInterval.Day, 1, CDate(Date001.Text))
        Pram4.Value = CL001.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "Print01")
        DB_CLOSE()

        WK_sum1 = 0
        DtView2 = New DataView(WK_DsList1.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        If DtView2.Count <> 0 Then
            For j = 0 To DtView2.Count - 1
                WK_sum1 = WK_sum1 + DtView2(j)("comp_shop_ttl")
            Next
        End If
        If Number001.Value <> WK_sum1 Or DtView2.Count <> DtView1.Count Then
            msg.Text = "�������ƃf�[�^������Ă��܂��B�ēx�������s���Ă��������B"
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        '�f�[�^�o��
        Dim sfd As New SaveFileDialog                                   'SaveFileDialog�N���X�̃C���X�^���X���쐬
        sfd.FileName = "����" & Format(Now, "yyyyMMddHHmmss") & ".CSV"  '�͂��߂̃t�@�C�������w�肷��
        sfd.Filter = "CSV�t�@�C��(*.CSV)|*.CSV"                         '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
        sfd.FilterIndex = 2                                             '[�t�@�C���̎��]�ł͂��߂� �u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
        sfd.Title = "�ۑ���̃t�@�C����I�����Ă�������"                '�^�C�g����ݒ肷��
        sfd.RestoreDirectory = True                                     '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���

        '���ɑ��݂���t�@�C�������w�肵���Ƃ��x������
        '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
        sfd.OverwritePrompt = True

        '���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
        '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then     '�_�C�A���O��\������
            strFile = sfd.FileName   'OK�{�^�����N���b�N���ꂽ�Ƃ�

            WK_DtView1 = New DataView(P_DsPRT.Tables("scan"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then '�V�K���X�V

                WK_invc_no = Count_Get2()

                '�����f�[�^�쐬
                strSQL = "INSERT INTO T20_INVC_MTR"
                strSQL = strSQL & " (i��vc_no, rcpt_brch_code, cls, invc_code, invc_date, bf_amnt, amnt1, tax, ttl_amnt, invc_amnt, cnt, tax_rate)"
                strSQL = strSQL & " VALUES (" & WK_invc_no & ""
                strSQL = strSQL & ", '" & CL001.Text & "'"
                strSQL = strSQL & ", '2'"
                strSQL = strSQL & ", ' '"
                strSQL = strSQL & ", '" & Date001.Text & "'"
                strSQL = strSQL & ", 0"
                strSQL = strSQL & ", " & Number011.Value
                strSQL = strSQL & ", " & Number012.Value
                strSQL = strSQL & ", " & Number013.Value
                strSQL = strSQL & ", " & Number013.Value
                strSQL = strSQL & ", " & sin & ""
                strSQL = strSQL & ", 5)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                For i = 0 To WK_DtView1.Count - 1
                    If WK_DtView1(i)("invc_no") = 0 Then

                        WK_DtView1(i)("invc_no") = WK_invc_no

                        '�����ڍ׃f�[�^�쐬
                        strSQL = "INSERT INTO T21_INVC_SUB"
                        strSQL = strSQL & " (i��vc_no, brch_code, rcpt_no, invc_amnt, cxl_flg, fin_flg)"
                        strSQL = strSQL & " VALUES (" & WK_invc_no & ""
                        strSQL = strSQL & ", '" & WK_DtView1(i)("rcpt_brch_code") & "'"
                        strSQL = strSQL & ", '" & WK_DtView1(i)("rcpt_no") & "'"
                        strSQL = strSQL & ", " & WK_DtView1(i)("comp_shop_ttl") & ""
                        strSQL = strSQL & ", 0, 0)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        '��t�e�[�u���ɐ������X�V
                        strSQL = "UPDATE T01_REP_MTR"
                        strSQL = strSQL & " SET rqst_date = '" & Date001.Text & "'"
                        strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(i)("rcpt_no") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        '����f�[�^�����σt���OON
                        strSQL = "UPDATE T10_SALS"
                        strSQL = strSQL & " SET invc_flg = 1"
                        strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(i)("rcpt_no") & "')"
                        strSQL = strSQL & " AND (cls = '2')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        '�ύX�����X�V
                        WK_str = Date001.Text
                        add_hsty(DtView1(i)("rcpt_no"), "������", "", WK_str)

                        '��������e�[�u���X�V
                        DB_OPEN("nMVAR")
                        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & WK_DtView1(i)("rcpt_no") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(DsList1, "T06_PRNT_DATE")
                        DtView2 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
                        If DtView2.Count = 0 Then
                            strSQL = "INSERT INTO T06_PRNT_DATE"
                            strSQL = strSQL & " (rcpt_no, IVC)"
                            strSQL = strSQL & " VALUES ('" & WK_DtView1(i)("rcpt_no") & "'"
                            strSQL = strSQL & ", '" & P_HSTY_DATE & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                        Else
                            If IsDBNull(DtView2(0)("IVC")) Then
                                strSQL = "UPDATE T06_PRNT_DATE"
                                strSQL = strSQL & " SET IVC = '" & P_HSTY_DATE & "'"
                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(i)("rcpt_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()
                            End If
                        End If
                        DB_CLOSE()
                    End If
                Next
            End If

            '�f�[�^�o��
            WK_DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_F20_07_5", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
            Dim Pram6 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
            Pram5.Value = CL001.Text
            Pram6.Value = CDate(Date001.Text)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "CSV")
            DB_CLOSE()
            DtView1 = New DataView(WK_DsList1.Tables("CSV"), "", "", DataViewRowState.CurrentRows)

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
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
            Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

            '�f�[�^����������
            strData = "������,QG_Care��t�ԍ�,�`�[�ԍ�,���q�l��,MAKERN,���i��,�����ԍ�,�̏�Ǐ�P,�掟�X��,�r�b�R�[�h,��t�N����"
            strData = strData & ",�C��������,�C���S���Җ�,�C�����e�P,�L�����i,�L���Z�p,�L�����v,�������ԍ�,�������t,�ۏ؍��v"
            strData = strData & ",�ۏ؏��,�ۏ؏��,���i��,�Z�p��"
            swFile.WriteLine(strData)

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strData = Now.Date                                                              '������
                strData = strData & "," & DtView1(i)("qg_care_no")                              'QG_Care��t�ԍ�
                strData = strData & "," & DtView1(i)("rcpt_no")                                 '�`�[�ԍ�
                strData = strData & "," & DtView1(i)("user_name")                               '���q�l��
                strData = strData & "," & DtView1(i)("vndr_name_en")                            '��MAKERN
                strData = strData & "," & comma_Cng(DtView1(i)("model_1"))                      '���i��
                strData = strData & "," & DtView1(i)("s_n")                                     '�����ԍ�
                strData = strData & "," & comma_Cng(New_Line_Cng(DtView1(i)("user_trbl")))      '�̏�Ǐ�P
                strData = strData & "," & DtView1(i)("store_name")                              '�掟�X��
                strData = strData & "," & DtView1(i)("CS_code")                                 '�r�b�R�[�h
                strData = strData & "," & DtView1(i)("accp_date")                               '��t�N����
                strData = strData & "," & DtView1(i)("comp_date")                               '�C��������
                strData = strData & "," & DtView1(i)("repr_empl_name")                          '�C���S���Җ�
                strData = strData & "," & comma_Cng(New_Line_Cng(DtView1(i)("comp_meas")))      '�C�����e�P
                If DtView1(i)("rpar_cls") = "01" Then '�L��
                    strData = strData & "," & DtView1(i)("comp_shop_part_chrg")                 '�L�����i
                    strData = strData & "," & DtView1(i)("comp_shop_tech_chrg")                 '�L���Z�p
                    strData = strData & "," & DtView1(i)("comp_shop_ttl")                       '�L�����v
                Else
                    strData = strData & ",0,0,0"
                End If
                strData = strData & "," & DtView1(i)("rcpt_no")                                '�������ԍ�
                strData = strData & ","                                                         '�������t
                If DtView1(i)("rpar_cls") = "01" Then '�L��
                    strData = strData & ",0"
                Else
                    strData = strData & "," & DtView1(i)("comp_shop_ttl")                       '�ۏ؍��v
                End If
                strData = strData & "," & DtView1(i)("rpar_cls")                                '�ۏ؏��
                strData = strData & "," & DtView1(i)("rpar_cls_name")                           '�ۏ؏��
                strData = strData & "," & DtView1(i)("comp_shop_part_chrg")                     '���i��
                strData = strData & "," & DtView1(i)("comp_shop_tech_chrg")                     '�Z�p��
                swFile.WriteLine(strData)

            Next
            swFile.Close()          '�t�@�C�������
            waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
            Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���


            msg.Text = "�������f�[�^���o�͂��܂����B"
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �߂�
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_DsPRT.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
