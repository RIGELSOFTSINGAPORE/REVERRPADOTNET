Public Class F30_Form01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL, WK_str, WK_str2 As String
    Dim i, j, WK_sum1, WK_sum2 As Integer

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
    Friend WithEvents DataGridEx1 As nMVAR_Clct.DataGridEx
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F30_Form01))
        Me.DataGridEx1 = New nMVAR_Clct.DataGridEx
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button4 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Interop.Combo
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(16, 72)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(956, 464)
        Me.DataGridEx1.TabIndex = 3
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.DataGridTableStyle2.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "scan"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn10.Format = "####"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "�����ԍ�"
        Me.DataGridTextBoxColumn10.MappingName = "i��vc_no"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 76
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "���_"
        Me.DataGridTextBoxColumn1.MappingName = "brch_name"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "������R�[�h"
        Me.DataGridTextBoxColumn6.MappingName = "invc_code"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 84
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "������"
        Me.DataGridTextBoxColumn7.MappingName = "invc_name"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 200
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn11.Format = "##,##0"
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "�挎�����c"
        Me.DataGridTextBoxColumn11.MappingName = "bf_amnt"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 76
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "##,##0"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "�����z"
        Me.DataGridTextBoxColumn8.MappingName = "amnt1"
        Me.DataGridTextBoxColumn8.NullText = ""
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
        Me.DataGridTextBoxColumn12.NullText = ""
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
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.ReadOnly = True
        Me.DataGridTextBoxColumn13.Width = 76
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn14.Format = "##,##0"
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "�ō����v�z"
        Me.DataGridTextBoxColumn14.MappingName = "invc_amnt"
        Me.DataGridTextBoxColumn14.NullText = ""
        Me.DataGridTextBoxColumn14.ReadOnly = True
        Me.DataGridTextBoxColumn14.Width = 76
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "����"
        Me.DataGridTextBoxColumn9.MappingName = "cnt"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 68
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(320, 40)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "����"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 548)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(784, 16)
        Me.msg.TabIndex = 1579
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(896, 544)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 4
        Me.Button98.Text = "�߂�"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Navy
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(24, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 20)
        Me.Label18.TabIndex = 1595
        Me.Label18.Text = "������"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo002.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Combo002.Location = New System.Drawing.Point(104, 44)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(196, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 1
        Me.Combo002.Value = "Combo002"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 1594
        Me.Label7.Text = "���_"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Combo001.Location = New System.Drawing.Point(104, 20)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 0
        Me.Combo001.Value = "Combo001"
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(400, 44)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(48, 16)
        Me.CL002.TabIndex = 1710
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(400, 24)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(48, 16)
        Me.CL001.TabIndex = 1709
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'F30_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(986, 584)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F30_Form01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���������i�̎Ёj"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F30_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        CmbSet()    '**  �R���{�{�b�N�X�Z�b�g
        sql()       '**  �f�[�^�Z�b�g
        DtGd()
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  �R���{�{�b�N�X�Z�b�g
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        '���_
        strSQL = "SELECT T20_INVC_MTR.rcpt_brch_code AS brch_code, T20_INVC_MTR.rcpt_brch_code + ':' + M03_BRCH.name AS name"
        strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
        strSQL = strSQL & " T21_INVC_SUB ON T20_INVC_MTR.i��vc_no = T21_INVC_SUB.i��vc_no INNER JOIN"
        strSQL = strSQL & " M03_BRCH ON T20_INVC_MTR.rcpt_brch_code = M03_BRCH.brch_code"
        strSQL = strSQL & " WHERE (T21_INVC_SUB.fin_flg = 0) AND (T21_INVC_SUB.cxl_flg = 0) AND (T20_INVC_MTR.cls = '1')"
        strSQL = strSQL & " GROUP BY T20_INVC_MTR.rcpt_brch_code, T20_INVC_MTR.rcpt_brch_code + ':' + M03_BRCH.name"
        strSQL = strSQL & " ORDER BY brch_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M03_BRCH")

        Combo001.DataSource = DsCMB.Tables("M03_BRCH")
        Combo001.DisplayMember = "name"
        Combo001.ValueMember = "brch_code"
        Combo001.Text = Nothing
        CL001.Text = Nothing

        '�̎�
        strSQL = "SELECT T20_INVC_MTR.invc_code AS store_code, M08_STORE.invc_code + ':' + M08_STORE.name AS name"
        strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
        strSQL = strSQL & " T21_INVC_SUB ON T20_INVC_MTR.i��vc_no = T21_INVC_SUB.i��vc_no INNER JOIN"
        strSQL = strSQL & " M08_STORE ON T20_INVC_MTR.invc_code = M08_STORE.store_code"
        strSQL = strSQL & " WHERE (T21_INVC_SUB.fin_flg = 0) AND (T21_INVC_SUB.cxl_flg = 0) AND (T20_INVC_MTR.cls = '1')"
        strSQL = strSQL & " GROUP BY T20_INVC_MTR.invc_code, M08_STORE.invc_code + ':' + M08_STORE.name"
        strSQL = strSQL & " ORDER BY store_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M08_STORE")

        Combo002.DataSource = DsCMB.Tables("M08_STORE")
        Combo002.DisplayMember = "name"
        Combo002.ValueMember = "store_code"
        Combo002.Text = Nothing
        CL002.Text = Nothing

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  �f�[�^�Z�b�g
    '********************************************************************
    Sub sql()
        DsList1.Clear()
        DB_OPEN("nMVAR")

        strSQL = "SELECT T20_INVC_MTR.i��vc_no, T20_INVC_MTR.invc_date, T20_INVC_MTR.invc_code, M08_STORE.name AS invc_name"
        strSQL = strSQL & ", T20_INVC_MTR.rcpt_brch_code, M03_BRCH.name AS brch_name, T20_INVC_MTR.bf_amnt, T20_INVC_MTR.amnt1"
        strSQL = strSQL & ", T20_INVC_MTR.tax, T20_INVC_MTR.ttl_amnt, T20_INVC_MTR.invc_amnt, T20_INVC_MTR.cnt"
        strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
        strSQL = strSQL & " T21_INVC_SUB ON T20_INVC_MTR.i��vc_no = T21_INVC_SUB.i��vc_no INNER JOIN"
        strSQL = strSQL & " M03_BRCH ON T20_INVC_MTR.rcpt_brch_code = M03_BRCH.brch_code LEFT OUTER JOIN"
        strSQL = strSQL & " M08_STORE ON T20_INVC_MTR.invc_code = M08_STORE.store_code"
        strSQL = strSQL & " WHERE (T21_INVC_SUB.fin_flg = 0) AND (T21_INVC_SUB.cxl_flg = 0) AND (T20_INVC_MTR.cls = '1')"
        If CL001.Text <> Nothing Then
            strSQL = strSQL & " AND (T20_INVC_MTR.rcpt_brch_code = '" & CL001.Text & "')"
        End If
        If CL002.Text <> Nothing Then
            strSQL = strSQL & " AND (T20_INVC_MTR.invc_code = '" & CL002.Text & "')"
        End If
        strSQL = strSQL & " GROUP BY T20_INVC_MTR.i��vc_no, T20_INVC_MTR.invc_date, T20_INVC_MTR.invc_code, M08_STORE.name"
        strSQL = strSQL & ", T20_INVC_MTR.rcpt_brch_code, M03_BRCH.name, T20_INVC_MTR.bf_amnt, T20_INVC_MTR.amnt1"
        strSQL = strSQL & ", T20_INVC_MTR.tax, T20_INVC_MTR.ttl_amnt, T20_INVC_MTR.invc_amnt, T20_INVC_MTR.cnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "scan")

        DB_CLOSE()
    End Sub
    Sub DtGd()
        Dim tbl As New DataTable
        tbl = DsList1.Tables("scan")
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
                    P_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                    P_PRAM2 = "0"
                    Dim F30_Form01_2 As New F30_Form01_2
                    F30_Form01_2.ShowDialog()

                    If P_PRAM2 = "1" Then
                        sql()
                    End If

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
                P_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                P_PRAM2 = "0"
                Dim F30_Form01_2 As New F30_Form01_2
                F30_Form01_2.ShowDialog()

                If P_PRAM2 = "1" Then
                    sql()
                End If

            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '** ����
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing
        sql()       '**  �f�[�^�Z�b�g
        DtView1 = New DataView(DsList1.Tables("scan"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            msg.Text = "�Y������f�[�^������܂���B"
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ���ڃ`�F�b�N
    '********************************************************************
    Sub CHK_Combo001()   '���_
        msg.Text = Nothing
        CL001.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            'Combo001.BackColor = System.Drawing.Color.Red
            'msg.Text = "���_�����͂���Ă��܂���B"
            'Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "�Y�����鋒�_������܂���B"
                Exit Sub
            Else
                CL001.Text = DtView1(0)("brch_code")
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo002()   '�̎�
        msg.Text = Nothing
        CL002.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            'Combo002.BackColor = System.Drawing.Color.Red
            'msg.Text = "�̎Ђ����͂���Ă��܂���B"
            'Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("M08_STORE"), "name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "�Y������̎Ђ�����܂���B"
                Exit Sub
            Else
                CL002.Text = DtView1(0)("store_code")
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   '���_
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()   '�̎�
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
