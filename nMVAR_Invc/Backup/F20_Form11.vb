Public Class F20_Form11
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, WK_DtView1, WK_DtView2 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, WK_str, WK_str2, strFile, strData, ANS As String
    Dim i, j, r, WK_sum1, WK_sum2 As Integer

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
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Number005 As GrapeCity.Win.Input.Number
    Friend WithEvents Number004 As GrapeCity.Win.Input.Number
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents Label_Re As System.Windows.Forms.Label
    Friend WithEvents Label_tax As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridEx1 As nMVAR_Invc.DataGridEx
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents DD As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F20_Form11))
        Me.CL002 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Label3 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Number005 = New GrapeCity.Win.Input.Number
        Me.Number004 = New GrapeCity.Win.Input.Number
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.Label_Re = New System.Windows.Forms.Label
        Me.Label_tax = New System.Windows.Forms.Label
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridEx1 = New nMVAR_Invc.DataGridEx
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Label132 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.DD = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(501, 8)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1864
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo002.Location = New System.Drawing.Point(325, 24)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(232, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 1844
        Me.Combo002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo002.Value = "Combo002"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(229, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 1863
        Me.Label3.Text = "���[�J�["
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(169, 8)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1862
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Enabled = False
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(101, 24)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1843
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 1861
        Me.Label1.Text = "���_"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number005
        '
        Me.Number005.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number005.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number005.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number005.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number005.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number005.Enabled = False
        Me.Number005.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number005.HighlightText = True
        Me.Number005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number005.Location = New System.Drawing.Point(633, 524)
        Me.Number005.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number005.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number005.Name = "Number005"
        Me.Number005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number005.Size = New System.Drawing.Size(76, 20)
        Me.Number005.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number005.TabIndex = 1859
        Me.Number005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number005.Value = Nothing
        '
        'Number004
        '
        Me.Number004.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number004.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number004.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number004.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number004.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number004.Enabled = False
        Me.Number004.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###", "", "", "-", "", "", "")
        Me.Number004.HighlightText = True
        Me.Number004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number004.Location = New System.Drawing.Point(561, 524)
        Me.Number004.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number004.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number004.Name = "Number004"
        Me.Number004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number004.Size = New System.Drawing.Size(76, 20)
        Me.Number004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number004.TabIndex = 1858
        Me.Number004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number004.Value = Nothing
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
        Me.Number003.Location = New System.Drawing.Point(485, 524)
        Me.Number003.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number003.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number003.Name = "Number003"
        Me.Number003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number003.Size = New System.Drawing.Size(76, 20)
        Me.Number003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.TabIndex = 1857
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number003.Value = Nothing
        '
        'Label_Re
        '
        Me.Label_Re.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label_Re.Location = New System.Drawing.Point(369, 52)
        Me.Label_Re.Name = "Label_Re"
        Me.Label_Re.Size = New System.Drawing.Size(28, 16)
        Me.Label_Re.TabIndex = 1856
        Me.Label_Re.Text = "0"
        Me.Label_Re.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_Re.Visible = False
        '
        'Label_tax
        '
        Me.Label_tax.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label_tax.Location = New System.Drawing.Point(405, 52)
        Me.Label_tax.Name = "Label_tax"
        Me.Label_tax.Size = New System.Drawing.Size(28, 16)
        Me.Label_tax.TabIndex = 1855
        Me.Label_tax.Text = "5"
        Me.Label_tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_tax.Visible = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "scan"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(13, 80)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(875, 444)
        Me.DataGridEx1.TabIndex = 1847
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "���[�J�[�R�[�h"
        Me.DataGridTextBoxColumn6.MappingName = "vndr_code"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 84
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "���[�J�[��"
        Me.DataGridTextBoxColumn7.MappingName = "vndr_name"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 200
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "##,##0"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "�����z"
        Me.DataGridTextBoxColumn8.MappingName = "amnt1"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 76
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn12.Format = "##,##0"
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "�����"
        Me.DataGridTextBoxColumn12.MappingName = "tax"
        Me.DataGridTextBoxColumn12.ReadOnly = True
        Me.DataGridTextBoxColumn12.Width = 76
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn13.Format = "##,##0"
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "���������z"
        Me.DataGridTextBoxColumn13.MappingName = "ttl_amnt"
        Me.DataGridTextBoxColumn13.ReadOnly = True
        Me.DataGridTextBoxColumn13.Width = 76
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = "##,##0"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "�ō����v�z"
        Me.DataGridTextBoxColumn1.MappingName = "invc_amnt"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 76
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "����"
        Me.DataGridTextBoxColumn2.MappingName = "cnt"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 68
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = "####"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "�����ԍ�"
        Me.DataGridTextBoxColumn3.MappingName = "i��vc_no"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 76
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "���_"
        Me.DataGridTextBoxColumn4.MappingName = "rcpt_brch_name"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.MappingName = "rcpt_brch_code"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 0
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
        Me.Number002.Location = New System.Drawing.Point(409, 524)
        Me.Number002.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number002.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(76, 20)
        Me.Number002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 1854
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = Nothing
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.Navy
        Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label132.ForeColor = System.Drawing.Color.White
        Me.Label132.Location = New System.Drawing.Point(281, 524)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(52, 20)
        Me.Label132.TabIndex = 1853
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
        Me.Number001.Location = New System.Drawing.Point(333, 524)
        Me.Number001.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(76, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1852
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = Nothing
        '
        'DD
        '
        Me.DD.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.DD.Location = New System.Drawing.Point(305, 52)
        Me.DD.Name = "DD"
        Me.DD.Size = New System.Drawing.Size(52, 16)
        Me.DD.TabIndex = 1851
        Me.DD.Text = "00"
        Me.DD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DD.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(485, 48)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 1846
        Me.Button4.Text = "����"
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(101, 48)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1845
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(21, 48)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 20)
        Me.Label35.TabIndex = 1850
        Me.Label35.Text = "��������"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(816, 548)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1848
        Me.Button98.Text = "�߂�"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(17, 556)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(779, 16)
        Me.msg.TabIndex = 1849
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F20_Form11
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(898, 580)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Number005)
        Me.Controls.Add(Me.Number004)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label_Re)
        Me.Controls.Add(Me.Label_tax)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.Label132)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.DD)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F20_Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���������(���[�J�[)"
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F20_Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        ACES()      '**  �����`�F�b�N
        CmbSet()
        sql()       '**  �f�[�^�Z�b�g
        DtGd()
        dsp_clr()
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
        DD.Text = "0"
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

        'If P_ACES_brch_code = "19" Or (P_ACES_brch_code = "90" And P_ACES_post_code = "02") Then 'QGHQ
        Combo001.Enabled = True
        'End If
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='211'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    DataGridEx1.Enabled = False
                Case Is = "3", "4"
                    DataGridEx1.Enabled = True
            End Select
        Else
            DataGridEx1.Enabled = False
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

        '���[�J�[
        strSQL = "SELECT vndr_code, vndr_code + ':' + name AS vndr_name"
        strSQL = strSQL & " FROM M05_VNDR"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "M05_VNDR")
        DB_CLOSE()

        Combo002.DataSource = DsCMB.Tables("M05_VNDR")
        Combo002.DisplayMember = "vndr_name"
        Combo002.ValueMember = "vndr_code"

        CL002.Text = Nothing
        Combo002.Text = Nothing

    End Sub

    Sub dsp_clr()
        P_DsPRT.Clear()
        msg.Text = Nothing
        Number001.Value = 0
        Number002.Value = 0
        Number003.Value = 0
        Number004.Value = 0
        Number005.Value = 0
    End Sub

    '********************************************************************
    '**  �f�[�^�Z�b�g
    '********************************************************************
    Sub sql()
        P_DsList1.Clear()
        dsp_clr()
        DB_OPEN("nMVAR")

        '�����ςݕ�
        strSQL = "SELECT T20_INVC_MTR.i��vc_no, T20_INVC_MTR.invc_date, T20_INVC_MTR.rcpt_brch_code"
        strSQL = strSQL & ", M03_BRCH.name AS rcpt_brch_name, T20_INVC_MTR.bf_amnt, T20_INVC_MTR.amnt1, T20_INVC_MTR.tax"
        strSQL = strSQL & ", T20_INVC_MTR.ttl_amnt, T20_INVC_MTR.invc_amnt, T20_INVC_MTR.cnt, T20_INVC_MTR.tax_rate"
        strSQL = strSQL & ", T20_INVC_MTR.vndr_code, M05_VNDR.name AS vndr_name"
        strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
        strSQL = strSQL & " M03_BRCH ON T20_INVC_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
        strSQL = strSQL & " M05_VNDR ON T20_INVC_MTR.vndr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
        strSQL = strSQL & " T30_CLCT ON T20_INVC_MTR.i��vc_no = T30_CLCT.i��vc_no"
        strSQL = strSQL & " WHERE (T20_INVC_MTR.cls = '3')"
        strSQL = strSQL & " AND (T30_CLCT.i��vc_no IS NULL)"
        strSQL = strSQL & " AND (T20_INVC_MTR.invc_date = CONVERT(DATETIME, '" & Date001.Text & "', 102))"
        If CL001.Text <> Nothing Then
            strSQL = strSQL & " AND (T20_INVC_MTR.rcpt_brch_code = '" & CL001.Text & "')"
        End If
        If CL002.Text <> Nothing Then
            strSQL = strSQL & " AND (T20_INVC_MTR.vndr_code = '" & CL002.Text & "')"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsList1, "scan")
        DaList1.Fill(P_DsList1, "scan1")
        P_DsList1.Tables("scan").Clear()

        '��������
        strSQL = "SELECT SUM(T10_SALS.sals_amnt) AS amnt1, SUM(T10_SALS.sals_tax) AS tax, COUNT(*) AS cnt"
        strSQL = strSQL & ", T01_REP_MTR.rcpt_brch_code, M03_BRCH.name AS rcpt_brch_name, T01_REP_MTR.vndr_code"
        strSQL = strSQL & ", M05_VNDR.name AS vndr_name"
        strSQL = strSQL & " FROM T01_REP_MTR INNER JOIN"
        strSQL = strSQL & " T10_SALS ON T01_REP_MTR.rcpt_no = T10_SALS.rcpt_no INNER JOIN"
        strSQL = strSQL & " M03_BRCH ON T01_REP_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
        strSQL = strSQL & " M05_VNDR ON T01_REP_MTR.vndr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
        strSQL = strSQL & " T21_INVC_SUB ON T01_REP_MTR.rcpt_no = T21_INVC_SUB.rcpt_no"
        strSQL = strSQL & " WHERE (T10_SALS.cls = '3')"
        strSQL = strSQL & " AND (T10_SALS.neva_chek_flg = 1)"
        strSQL = strSQL & " AND (T21_INVC_SUB.rcpt_no IS NULL)"
        strSQL = strSQL & " AND (T10_SALS.invc_flg = 0)"
        strSQL = strSQL & " AND (T10_SALS.invc_cls_date = CONVERT(DATETIME, '" & Date001.Text & "', 102))"
        If CL001.Text <> Nothing Then
            strSQL = strSQL & " AND (T01_REP_MTR.rcpt_brch_code = '" & CL001.Text & "')"
        End If
        If CL002.Text <> Nothing Then
            strSQL = strSQL & " AND (M05_VNDR.vndr_code = '" & CL002.Text & "')"
        End If
        strSQL = strSQL & " GROUP BY M03_BRCH.name, T01_REP_MTR.rcpt_brch_code, T01_REP_MTR.vndr_code, M05_VNDR.name, M05_VNDR.vndr_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsList1, "scan2")

        WK_DtView1 = New DataView(P_DsList1.Tables("scan2"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then

            For i = 0 To WK_DtView1.Count - 1
                WK_DtView2 = New DataView(P_DsList1.Tables("scan1"), "rcpt_brch_code = '" & WK_DtView1(i)("rcpt_brch_code") & "' AND vndr_code = '" & WK_DtView1(i)("vndr_code") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView2.Count = 0 Then    'ALL�V�K

                    '�Վ�����
                    If IsDBNull(WK_DtView1(i)("tax")) Then WK_DtView1(i)("tax") = RoundDOWN(WK_DtView1(i)("amnt1") * 0.1, 0)

                    dttable = P_DsList1.Tables("scan1")
                    dtRow = dttable.NewRow
                    dtRow("invc_no") = 0
                    dtRow("vndr_code") = WK_DtView1(i)("vndr_code")
                    dtRow("vndr_name") = WK_DtView1(i)("vndr_name")
                    dtRow("invc_date") = Date001.Text
                    dtRow("rcpt_brch_code") = CL001.Text
                    dtRow("bf_amnt") = 0
                    dtRow("amnt1") = WK_DtView1(i)("amnt1")
                    dtRow("tax") = WK_DtView1(i)("tax")
                    dtRow("ttl_amnt") = WK_DtView1(i)("amnt1") + WK_DtView1(i)("tax")
                    dtRow("invc_amnt") = WK_DtView1(i)("amnt1") + WK_DtView1(i)("tax")
                    dtRow("cnt") = WK_DtView1(i)("cnt")
                    dtRow("tax_rate") = 5
                    dtRow("rcpt_brch_code") = WK_DtView1(i)("rcpt_brch_code")
                    dtRow("rcpt_brch_name") = WK_DtView1(i)("rcpt_brch_name")
                    dttable.Rows.Add(dtRow)

                Else                            '�ꕔ�o�͍ς�
                End If
            Next
        End If
        DB_CLOSE()

        DtView1 = New DataView(P_DsList1.Tables("scan1"), "", "vndr_code", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            msg.Text = "�Y������f�[�^������܂���B"
        Else
            For i = 0 To DtView1.Count - 1
                dttable = P_DsList1.Tables("scan")
                dtRow = dttable.NewRow
                dtRow("invc_no") = DtView1(i)("invc_no")
                dtRow("vndr_code") = DtView1(i)("vndr_code")
                dtRow("vndr_name") = DtView1(i)("vndr_name")
                dtRow("invc_date") = DtView1(i)("invc_date")
                dtRow("rcpt_brch_code") = DtView1(i)("rcpt_brch_code")
                dtRow("bf_amnt") = DtView1(i)("bf_amnt")
                dtRow("amnt1") = DtView1(i)("amnt1")
                dtRow("tax") = DtView1(i)("tax")
                dtRow("ttl_amnt") = DtView1(i)("ttl_amnt")
                dtRow("invc_amnt") = DtView1(i)("invc_amnt")
                dtRow("cnt") = DtView1(i)("cnt")
                dtRow("tax_rate") = DtView1(i)("tax_rate")
                dtRow("rcpt_brch_code") = DtView1(i)("rcpt_brch_code")
                dtRow("rcpt_brch_name") = DtView1(i)("rcpt_brch_name")
                dttable.Rows.Add(dtRow)

                Number001.Value = Number001.Value + DtView1(i)("amnt1")
                Number002.Value = Number002.Value + DtView1(i)("tax")
                Number003.Value = Number003.Value + DtView1(i)("ttl_amnt")
                Number004.Value = Number004.Value + DtView1(i)("invc_amnt")
                Number005.Value = Number005.Value + DtView1(i)("cnt")
            Next
        End If
    End Sub
    Sub DtGd()
        Dim tbl As New DataTable
        tbl = P_DsList1.Tables("scan")
        DataGridEx1.DataSource = tbl
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

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        Combo002.Text = Trim(Combo002.Text)
        Combo002.BackColor = System.Drawing.SystemColors.Window
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
        Number001.Value = 0 : Number002.Value = 0 : Number003.Value = 0 : Number004.Value = 0 : Number005.Value = 0

        If Combo001.Text = Nothing Then
            CL001.Text = Nothing
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_name ='" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                msg.Text = "�Y���̋��_������܂���B"
                Combo001.Focus() : GoTo err
            Else
                CL001.Text = WK_DtView1(0)("brch_code")
            End If
        End If

        If Combo002.Text = Nothing Then
            CL002.Text = Nothing
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M05_VNDR"), "vndr_name ='" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                msg.Text = "�Y���̃��[�J�[������܂���B"
                Combo002.Focus() : GoTo err
            Else
                CL002.Text = WK_DtView1(0)("vndr_code")
            End If
        End If

        If Date001.Number = 0 Then
            msg.Text = "������������͂��Ă��������B"
            Date001.Focus() : GoTo err
        End If

        sql()       '**  �f�[�^�Z�b�g
        P_close_DATE = Date001.Text
err:
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�N���b�N
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim hitinfo As DataGrid.HitTestInfo
        P_HSTY_DATE = Now

        hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
        If hitinfo.Row >= 0 Then

            P_F60_0 = "M"                                           '���[�J�[����
            P_F60_1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 7)   '�����ԍ�

            If P_F60_1 = "0" Then
                WK_DtView1 = New DataView(P_DsList1.Tables("scan"), "vndr_code ='" & DataGridEx1(DataGridEx1.CurrentRowIndex, 0) & "' AND invc_no = 0", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 1 Then
                    P_F60_2 = DataGridEx1(DataGridEx1.CurrentRowIndex, 9)  '���_�R�[�h
                Else
                    P_F60_2 = Nothing                                       '���_�R�[�h
                End If
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT i��vc_no FROM T20_INVC_MTR WHERE (i��vc_no = " & P_F60_1 & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                r = DaList1.Fill(WK_DsList1, "T20_INVC_MTR")
                DB_CLOSE()
                If r = 1 Then
                    P_F60_2 = DataGridEx1(DataGridEx1.CurrentRowIndex, 9)  '���_�R�[�h
                Else
                    P_F60_2 = Nothing                                       '���_�R�[�h
                End If

            End If
            P_F60_3 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)   '���[�J�[�R�[�h
            P_F60_4 = Date001.Text                                  '���ߓ�

            Dim F60_Form01 As New F60_Form01
            F60_Form01.ShowDialog()

            sql()       '**  �f�[�^�Z�b�g
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
