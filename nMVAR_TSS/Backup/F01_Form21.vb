Public Class F01_Form21
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, WK_str, strData, strFile As String
    Dim r, r2, r_sum, i, j, k, pos, WK_sum As Integer
    Dim snd_date As Date
    Dim WK_cls As String
    Dim WK_etmt_meas, WK_etmt_comn As String
    Dim WK_comp_meas, WK_comp_comn As String
    Dim kisyu(3) As String
    Dim WK_part_name, WK_part_F As String

    Dim WK_01, WK_02, WK_09, WK_15, WK_20, WK_21, WK_aka2 As Integer

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.FunctionKey
    Friend WithEvents DataGridEx1 As nMVAR_TSS.DataGridEx
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form21))
        Me.Label1 = New System.Windows.Forms.Label
        Me.f12 = New System.Windows.Forms.Button
        Me.f01 = New System.Windows.Forms.Button
        Me.FunctionKey1 = New GrapeCity.Win.Input.FunctionKey
        Me.DataGridEx1 = New nMVAR_TSS.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "����/�������o��"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(896, 8)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 1
        Me.f12.Text = "F12:����"
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Location = New System.Drawing.Point(784, 8)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 0
        Me.f01.Text = "F1:CSV�o��"
        '
        'FunctionKey1
        '
        Me.FunctionKey1.ActiveKeySet = "Default"
        Me.FunctionKey1.Location = New System.Drawing.Point(0, 688)
        Me.FunctionKey1.Name = "FunctionKey1"
        Me.FunctionKey1.Size = New System.Drawing.Size(1002, 0)
        Me.FunctionKey1.TabIndex = 19
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(988, 636)
        Me.DataGridEx1.TabIndex = 20
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGridEx1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn21})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "TSS_snd"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "�敪"
        Me.DataGridTextBoxColumn1.MappingName = "cls_name"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 70
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "���Ӑ�ԍ�"
        Me.DataGridTextBoxColumn2.MappingName = "store_repr_no"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 95
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "��t�ԍ�"
        Me.DataGridTextBoxColumn3.MappingName = "rcpt_no"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 70
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "���q�l��"
        Me.DataGridTextBoxColumn4.MappingName = "user_name"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "���ϋZ�p��"
        Me.DataGridTextBoxColumn7.MappingName = "etmt_shop_tech_chrg"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "##,##0"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "���ϕ��i��"
        Me.DataGridTextBoxColumn8.MappingName = "etmt_shop_part_chrg"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = "##,##0"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "���ς��̑�"
        Me.DataGridTextBoxColumn9.MappingName = "etmt_shop_fee"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn10.Format = "##,##0"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "���ϑ���"
        Me.DataGridTextBoxColumn10.MappingName = "etmt_shop_pstg"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.Width = 60
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "���ϓ�"
        Me.DataGridTextBoxColumn12.MappingName = "etmt_date"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "���㇂"
        Me.DataGridTextBoxColumn13.MappingName = "sals_no"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.Width = 70
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn16.Format = "##,##0"
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "�����Z�p��"
        Me.DataGridTextBoxColumn16.MappingName = "comp_shop_tech_chrg"
        Me.DataGridTextBoxColumn16.NullText = ""
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn17.Format = "##,##0"
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "�������i��"
        Me.DataGridTextBoxColumn17.MappingName = "comp_shop_part_chrg"
        Me.DataGridTextBoxColumn17.NullText = ""
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn18.Format = "##,##0"
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "�������̑�"
        Me.DataGridTextBoxColumn18.MappingName = "comp_shop_fee"
        Me.DataGridTextBoxColumn18.NullText = ""
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn19.Format = "##,##0"
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "��������"
        Me.DataGridTextBoxColumn19.MappingName = "comp_shop_pstg"
        Me.DataGridTextBoxColumn19.NullText = ""
        Me.DataGridTextBoxColumn19.Width = 60
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "������"
        Me.DataGridTextBoxColumn21.MappingName = "comp_date"
        Me.DataGridTextBoxColumn21.NullText = ""
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(28, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 20)
        Me.CheckBox1.TabIndex = 21
        Me.CheckBox1.Text = "���Ϗ��"
        '
        'CheckBox2
        '
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(28, 24)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(88, 20)
        Me.CheckBox2.TabIndex = 22
        Me.CheckBox2.Text = "�������"
        '
        'F01_Form21
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.f01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form21"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "����/�������o��"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F01_Form21_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()   '**  ��������
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()

        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        '�ް���د�ސݒ�
        sql()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("TSS_snd")
        DataGridEx1.DataSource = tbl
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        sql()
    End Sub
    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        sql()
    End Sub

    Sub sql()
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DsList1.Clear()
        r_sum = 0
        DB_OPEN("nMVAR")

        If CheckBox1.Checked = True Then '����
            strSQL = "SELECT CASE WHEN tss_etmt_stts = '1' THEN '���ϐV�K' ELSE '���ύX�V' END AS cls_name, T01_REP_MTR.*"
            strSQL = strSQL & " FROM T01_REP_MTR"
            strSQL = strSQL & " WHERE (tss_etmt_stts = '1' OR tss_etmt_stts = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(DsList1, "TSS_snd")
            r_sum = r
        End If

        If CheckBox2.Checked = True Then '����
            strSQL = "SELECT CASE WHEN tss_comp_stts = '1' THEN '�����V�K' ELSE '�����X�V' END AS cls_name, T01_REP_MTR.*"
            strSQL = strSQL & " FROM T01_REP_MTR"
            strSQL = strSQL & " WHERE (tss_comp_stts = '1' OR tss_comp_stts = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(DsList1, "TSS_snd")
            r_sum = r_sum + r

            strSQL = "SELECT CASE WHEN tss_aka_stts = '1' THEN '�ԓ`�V�K' ELSE '�ԓ`�X�V' END AS cls_name, T01_REP_MTR.*"
            strSQL = strSQL & " FROM T01_REP_MTR"
            strSQL = strSQL & " WHERE (tss_aka_stts = '1' OR tss_aka_stts = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(DsList1, "TSS_snd")
            r_sum = r_sum + r
        End If
Tab1:
        DB_CLOSE()

        If r_sum = 0 Then
            f01.Enabled = False
        Else
            f01.Enabled = True
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  CSV�o�̓{�^��
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor


        Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
        sfd.FileName = "���ϊ���data.CSV"                       '�͂��߂̃t�@�C�������w�肷��
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

            '�i�s�󋵃_�C�A���O�̏���������
            waitDlg = New WaitDialog            ' �i�s�󋵃_�C�A���O
            waitDlg.Owner = Me                  ' �_�C�A���O�̃I�[�i�[��ݒ肷��
            waitDlg.MainMsg = Nothing           ' �����̊T�v��\��
            waitDlg.ProgressMax = 0             ' �S�̂̏���������ݒ�
            waitDlg.ProgressMin = 0             ' ���������̍ŏ��l��ݒ�i0������J�n�j
            waitDlg.ProgressStep = 1            ' �������ƂɃ��[�^��i�߂邩��ݒ�
            waitDlg.ProgressValue = 0           ' �ŏ��̌�����ݒ�
            Me.Enabled = False                  ' �I�[�i�[�̃t�H�[���𖳌��ɂ���
            waitDlg.Show()                      ' �i�s�󋵃_�C�A���O��\������
            Application.DoEvents()              ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            snd_date = Now
            DB_OPEN("nMVAR")

            DtView1 = New DataView(DsList1.Tables("TSS_snd"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                '�X�V�i���M�ρj
                strSQL = "UPDATE T01_REP_MTR"
                Select Case DtView1(i)("cls_name")
                    Case Is = "���ϐV�K", "���ύX�V"
                        strSQL = strSQL & " SET tss_etmt_stts = '9'"
                    Case Is = "�����V�K", "�����X�V"
                        strSQL = strSQL & " SET tss_comp_stts = '9'"
                    Case Is = "�ԓ`�V�K", "�ԓ`�X�V"
                        strSQL = strSQL & " SET tss_aka_stts = '9'"
                End Select
                strSQL = strSQL & " WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                '�敪�R�[�h
                Select Case DtView1(i)("cls_name")
                    Case Is = "���ϐV�K"
                        WK_cls = "10"
                    Case Is = "���ύX�V"
                        WK_cls = "20"
                    Case Is = "�����V�K", "�ԓ`�V�K"
                        WK_cls = "30"
                    Case Is = "�����X�V", "�ԓ`�X�V"
                        WK_cls = "40"
                End Select

                '�w�b�_�[
                strSQL = "INSERT INTO TSS_ETMT_COMP"
                strSQL = strSQL & " (cls, rcd_cls, snd_date, cust_repr_no, rcpt_no, sals_no, comp_meas, comp_comn"
                strSQL = strSQL & ", tech_chrg, pstg, comp_chrg, comp_chrg_tax, comp_chrg_ttl, ajst_cls, ajst"
                strSQL = strSQL & ", max_tech_chrg, max_pstg, max_chrg, max_chrg_tax, max_chrg_ttl, etmt_cx_chrg, etmt_cx_chrg_tax"
                strSQL = strSQL & ", etmt_cx_chrg_ttl, user_cx_chrg, user_cx_chrg_tax, user_cx_chrg_ttl, etmt_cls, etmt_date"
                strSQL = strSQL & ", rep_yn, comp_date, sals_date, rb_cls)"
                strSQL = strSQL & " VALUES ('" & WK_cls & "'"                                       '01cls
                strSQL = strSQL & ", '10'"                                                          '02rcd_cls
                strSQL = strSQL & ", CONVERT(DATETIME, '" & snd_date & "', 102)"                    '03���M��
                strSQL = strSQL & ", '" & DtView1(i)("store_repr_no") & "'"                         '04�J���e�ԍ�
                strSQL = strSQL & ", '" & DtView1(i)("rcpt_no") & "'"                               '05��t�ԍ�

                Select Case DtView1(i)("cls_name")
                    Case Is = "���ϐV�K", "���ύX�V"
                        strSQL = strSQL & ", NULL"                                                  '06�`�[�ԍ�
                        WK_etmt_meas = Trim(DtView1(i)("etmt_meas"))
                        If WK_etmt_meas <> Nothing Then
                            WK_str = WK_etmt_meas.Replace(Chr(34), Chr(34) & Chr(34) & Chr(34)) '"��"""
                        Else
                            WK_str = Nothing
                        End If
                        strSQL = strSQL & ", '" & WK_str & "'"                                      '07�Ή����e
                        strSQL = strSQL & ", ''"                                                    '08�m�F����
                        strSQL = strSQL & ", " & DtView1(i)("etmt_shop_tech_chrg")                  '09�Z�p���i���ώd�؁j
                        strSQL = strSQL & ", " & DtView1(i)("etmt_shop_pstg")                       '11�����i���ώd�؁j

                        WK_sum = DtView1(i)("etmt_shop_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_apes")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_fee")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '15���v���z�Ŕ����i���ώd�؁j
                        strSQL = strSQL & ", " & DtView1(i)("etmt_shop_tax")                        '16���v���z����Łi���ώd�؁j
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("etmt_shop_tax")               '17���v���z�ō��݁i���ώd�؁j
                        strSQL = strSQL & ", '0'"                                                   '18�l�����敪
                        strSQL = strSQL & ", 0"                                                     '19�l����
                        strSQL = strSQL & ", " & DtView1(i)("etmt_eu_tech_chrg")                    '20�Z�p���i���q�l�����j
                        strSQL = strSQL & ", " & DtView1(i)("etmt_eu_pstg")                         '21�����i���q�l�����j

                        WK_sum = DtView1(i)("etmt_eu_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_apes")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_fee")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '23���v���z�Ŕ����i���q�l�����j
                        strSQL = strSQL & ", " & DtView1(i)("etmt_eu_tax")                          '24���v���z����Łi���q�l�����j
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("etmt_eu_tax")                 '25���v���z�ō��݁i���q�l�����j

                    Case Is = "�����V�K", "�����X�V", "�ԓ`�V�K", "�ԓ`�X�V"
                        If Not IsDBNull(DtView1(i)("sals_no")) Then
                            strSQL = strSQL & ", " & DtView1(i)("sals_no")                          '06�`�[�ԍ�
                        Else
                            strSQL = strSQL & ", NULL"
                        End If
                        WK_comp_meas = Trim(DtView1(i)("comp_meas"))
                        If WK_comp_meas <> Nothing Then
                            WK_str = WK_comp_meas.Replace(Chr(34), Chr(34) & Chr(34) & Chr(34)) '"��"""
                        Else
                            WK_str = Nothing
                        End If
                        strSQL = strSQL & ", '" & WK_str & "'"                                      '07�Ή����e
                        strSQL = strSQL & ", ''"                                                    '08�m�F����
                        strSQL = strSQL & ", " & DtView1(i)("comp_shop_tech_chrg")                  '09�Z�p���i�����d�؁j
                        strSQL = strSQL & ", " & DtView1(i)("comp_shop_pstg")                       '11�����i�����d�؁j

                        WK_sum = DtView1(i)("comp_shop_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_apes")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_fee")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '15���v���z�Ŕ����i�����d�؁j
                        strSQL = strSQL & ", " & DtView1(i)("comp_shop_tax")                        '16���v���z����Łi�����d�؁j
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("comp_shop_tax")               '17���v���z�ō��݁i�����d�؁j
                        strSQL = strSQL & ", '0'"                                                   '18�l�����敪
                        strSQL = strSQL & ", 0"                                                     '19�l����
                        strSQL = strSQL & ", " & DtView1(i)("comp_eu_tech_chrg")                    '20�Z�p���i���q�l�����j
                        strSQL = strSQL & ", " & DtView1(i)("comp_eu_pstg")                         '21�����i���q�l�����j

                        WK_sum = DtView1(i)("comp_eu_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_apes")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_fee")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '23���v���z�Ŕ����i���q�l�����j
                        strSQL = strSQL & ", " & DtView1(i)("comp_eu_tax")                          '24���v���z����Łi���q�l�����j
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("comp_eu_tax")                 '25���v���z�ō��݁i���q�l�����j

                End Select

                strSQL = strSQL & ", 0"                                                             '26���σL�����Z�����Ŕ���
                strSQL = strSQL & ", 0"                                                             '27���σL�����Z���������
                strSQL = strSQL & ", 0"                                                             '28���σL�����Z�����ō���
                strSQL = strSQL & ", 0"                                                             '29���σL�����Z�����Ŕ����i���q�l�����j
                strSQL = strSQL & ", 0"                                                             '30���σL�����Z��������Łi���q�l�����j
                strSQL = strSQL & ", 0"                                                             '31���σL�����Z�����Ŕ����i���q�l�����j

                If Not IsDBNull(DtView1(i)("etmt_date")) Then
                    strSQL = strSQL & ", 1"                                                         '32���ϋ敪
                    strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("etmt_date") & "', 102)" '33���ύ쐬��
                Else
                    strSQL = strSQL & ", NULL"
                    strSQL = strSQL & ", NULL"
                End If

                Select Case DtView1(i)("cls_name")
                    Case Is = "���ϐV�K", "���ύX�V"
                        strSQL = strSQL & ", NULL"                                                  '39�C����
                        strSQL = strSQL & ", NULL"                                                  '40������
                        strSQL = strSQL & ", NULL"                                                  '41�o�ד�
                        strSQL = strSQL & ", NULL)"                                                 '42�ԍ�

                    Case Is = "�����V�K", "�����X�V"
                        If IsDBNull(DtView1(i)("zh_code")) Then DtView1(i)("zh_code") = "Z"
                        Select Case DtView1(i)("zh_code")
                            Case Is = "H"
                                strSQL = strSQL & ", '02'"  '�ԋp                                               '39�C����
                            Case Else
                                strSQL = strSQL & ", '01'"  '���s
                        End Select
                        strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("comp_date") & "', 102)"         '40������

                        If Not IsDBNull(DtView1(i)("sals_date")) Then
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("sals_date") & "', 102)"     '41�o�ד�
                        Else
                            strSQL = strSQL & ", NULL"
                        End If
                        strSQL = strSQL & ", 1)"                                                                '42�ԍ�

                    Case Is = "�ԓ`�V�K", "�ԓ`�X�V"
                        If IsDBNull(DtView1(i)("zh_code")) Then DtView1(i)("zh_code") = "Z"
                        Select Case DtView1(i)("zh_code")
                            Case Is = "H"
                                strSQL = strSQL & ", '02'"  '�ԋp                                               '39�C����
                            Case Else
                                strSQL = strSQL & ", '01'"  '���s
                        End Select
                        strSQL = strSQL & ", NULL"                                                              '40������

                        If Not IsDBNull(DtView1(i)("sals_date")) Then
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("sals_date") & "', 102)"     '41�o�ד�
                        Else
                            strSQL = strSQL & ", NULL"
                        End If
                        strSQL = strSQL & ", 2)"                                                                '42�ԍ�
                End Select
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                '����
                Select Case DtView1(i)("cls_name")
                    Case Is = "���ϐV�K", "���ύX�V", "�����V�K", "�����X�V"

                        WK_part_name = Nothing

                            WK_DsList1.Clear()
                        strSQL = "SELECT * FROM T04_REP_PART"
                        strSQL = strSQL & " WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                        Select Case DtView1(i)("cls_name")
                            Case Is = "���ϐV�K", "���ύX�V"
                                strSQL = strSQL & " AND (kbn = '1')"
                            Case Is = "�����V�K", "�����X�V"
                                strSQL = strSQL & " AND (kbn = '2')"
                        End Select
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        r = DaList1.Fill(WK_DsList1, "T04_REP_PART")

                        If r <> 0 Then
                            DtView2 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)

                            For j = 0 To DtView2.Count - 1
                                If j = 0 Then
                                    WK_part_name = Trim(DtView2(j)("part_name"))
                                Else
                                    WK_part_name = WK_part_name & " " & Trim(DtView2(j)("part_name"))
                                End If
                            Next j
                            strSQL = "INSERT INTO TSS_ETMT_COMP"
                            strSQL = strSQL & " (cls, rcd_cls, snd_date, cust_repr_no"
                            strSQL = strSQL & ", dtl_no, part_no, part_name, part_chrg, user_part_chrg)"
                            strSQL = strSQL & " VALUES ('" & WK_cls & "'"                                       '01cls
                            strSQL = strSQL & ", '20'"                                                          '02rcd_cls
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & snd_date & "', 102)"                    '03���M��
                            strSQL = strSQL & ", '" & DtView1(i)("store_repr_no") & "'"                         '04�J���e�ԍ�
                            strSQL = strSQL & ", 1"                                                             '����No
                            strSQL = strSQL & ", NULL"                                                          '�߰ԍ�

                            WK_str = WK_part_name
                            If WK_str <> Nothing Then WK_str = WK_str.Replace(Chr(34), Chr(34) & Chr(34) & Chr(34)) '"��"""
                            strSQL = strSQL & ", '" & WK_str & "'"                                              '�߰�
                            Select Case DtView1(i)("cls_name")
                                Case Is = "���ϐV�K", "���ύX�V"
                                    strSQL = strSQL & ", " & DtView1(i)("etmt_shop_part_chrg")                  '�߰��z�ŕ�
                                    strSQL = strSQL & ", " & DtView1(i)("etmt_eu_part_chrg") & ")"              '�߰��q�l�����ŕ�
                                Case Is = "�����V�K", "�����X�V"
                                    strSQL = strSQL & ", " & DtView1(i)("comp_shop_part_chrg") & ""
                                    strSQL = strSQL & ", " & DtView1(i)("comp_eu_part_chrg") & ")"
                            End Select

                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                        End If
                End Select
            Next i

            '********************************************************************
            '**  CSV�o��
            '********************************************************************
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM TSS_ETMT_COMP"
            strSQL = strSQL & " WHERE (snd_date = CONVERT(DATETIME, '" & snd_date & "', 102))"
            strSQL = strSQL & " ORDER BY id"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(WK_DsList1, "TSS_ETMT_COMP")

            strFile = sfd.FileName   'OK�{�^�����N���b�N���ꂽ�Ƃ�

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

            DtView1 = New DataView(WK_DsList1.Tables("TSS_ETMT_COMP"), "", "", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "CSV�o�͒�"       ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMsg = ""            ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           ' �ŏ��̌�����ݒ�
            Application.DoEvents()              ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            'strData = "�敪,���R�[�h�敪,�f�[�^���M��,�J���e�ԍ�,�C���Ǘ��ԍ�,E�`�ԍ�,�Ή����e,�m�F����,�Z�p��,�Z�p��_���S�敪"
            'strData = strData & ",�z����,�z����_���S�敪,���̑�,���̑�_���S�敪,���v���z_�ŕ�,�����,���v���z_�ō�,�l���敪"
            'strData = strData & ",�l���z,���q�l����_�Z�p��_�ŕ�,���q�l����_�z����,���q�l����_���̑�,���q�l�����@���v���z_�ŕ�"
            'strData = strData & ",���q�l�����@�����,���q�l�����@���v���z_�ō�,���σL�����Z����,���σL�����Z����_�����"
            'strData = strData & ",���σL�����Z����_�ō�,���q�l�����@���σL�����Z����,���q�l����_���σL�����Z����_�����"
            'strData = strData & ",���q�l�����@���σL�����Z����_�ō�,���ϋ敪,���ύ쐬��,���ϘA����,���ω񓚓�,���ω񓚘A����"
            'strData = strData & ",���ω񓚃R�[�h,���ω񓚓�,�C���ۃR�[�h,�C��������,�o�ד�,�ԍ��敪,�C�������\���"
            'strData = strData & ",�[�i�\���,����No,�p�[�c�ԍ�,�p�[�c��,�p�[�c���z_�ŕ�,�p�[�c_���S�敪,���q�l����_�ŕ�"
            'swFile.WriteLine(strData)

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " �s�j"
                waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strData = Chr(34) & DtView1(i)("cls") & Chr(34)                                                 '�敪
                strData = strData & "," & Chr(34) & DtView1(i)("rcd_cls") & Chr(34)                             '���R�[�h�敪
                strData = strData & "," & Chr(34) & Format(DtView1(i)("snd_date"), "yyyyMMdd") & Chr(34)        '�f�[�^���M��
                strData = strData & "," & Chr(34) & DtView1(i)("cust_repr_no") & Chr(34)                        '�J���e�ԍ�
                If Not IsDBNull(DtView1(i)("rcpt_no")) Then
                    strData = strData & "," & Chr(34) & Trim(DtView1(i)("rcpt_no")) & Chr(34)                   '�C���Ǘ��ԍ�
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & DtView1(i)("sals_no") & Chr(34)                             '�d�`�ԍ�
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    strData = strData & "," & Chr(34) & DtView1(i)("comp_meas") & Chr(34)                       '�Ή����e
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    strData = strData & "," & Chr(34) & DtView1(i)("comp_comn") & Chr(34)                       '�m�F����
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & DtView1(i)("tech_chrg") & Chr(34)                           '�Z�p��
                strData = strData & "," & Chr(34) & Chr(34)                                                     '�Z�p�����S�敪
                strData = strData & "," & Chr(34) & DtView1(i)("pstg") & Chr(34)                                '�z����
                strData = strData & "," & Chr(34) & Chr(34)                                                     '�z�������S�敪
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���̑�
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���̑����S�敪
                strData = strData & "," & Chr(34) & DtView1(i)("comp_chrg") & Chr(34)                           '���v���z�ŕ�
                strData = strData & "," & Chr(34) & DtView1(i)("comp_chrg_tax") & Chr(34)                       '�����
                strData = strData & "," & Chr(34) & DtView1(i)("comp_chrg_ttl") & Chr(34)                       '���v���z�ō�
                strData = strData & "," & Chr(34) & DtView1(i)("ajst_cls") & Chr(34)                            '�����敪
                strData = strData & "," & Chr(34) & DtView1(i)("ajst") & Chr(34)                                '�����z
                strData = strData & "," & Chr(34) & DtView1(i)("max_tech_chrg") & Chr(34)                       '���q�l�����Z�p���ŕ�
                strData = strData & "," & Chr(34) & DtView1(i)("max_pstg") & Chr(34)                            '���q�l�����z����
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���q�l�������̑�
                strData = strData & "," & Chr(34) & DtView1(i)("max_chrg") & Chr(34)                            '���q�l�������v���z�ŕ�
                strData = strData & "," & Chr(34) & DtView1(i)("max_chrg_tax") & Chr(34)                        '���q�l���������
                strData = strData & "," & Chr(34) & DtView1(i)("max_chrg_ttl") & Chr(34)                        '���q�l�������v���z�ō�
                strData = strData & "," & Chr(34) & DtView1(i)("etmt_cx_chrg") & Chr(34)                        '���σL�����Z����
                strData = strData & "," & Chr(34) & DtView1(i)("etmt_cx_chrg_tax") & Chr(34)                    '���σL�����Z���������
                strData = strData & "," & Chr(34) & DtView1(i)("etmt_cx_chrg_ttl") & Chr(34)                    '���σL�����Z�����ō�
                strData = strData & "," & Chr(34) & DtView1(i)("user_cx_chrg") & Chr(34)                        '���q�l�������σL�����Z����
                strData = strData & "," & Chr(34) & DtView1(i)("user_cx_chrg_tax") & Chr(34)                    '���q�l�������σL�����Z���������
                strData = strData & "," & Chr(34) & DtView1(i)("user_cx_chrg_ttl") & Chr(34)                    '���q�l�������σL�����Z�����ō�
                If Not IsDBNull(DtView1(i)("etmt_date")) Then
                    strData = strData & "," & Chr(34) & DtView1(i)("etmt_cls") & Chr(34)                        '���ϋ敪
                    strData = strData & "," & Chr(34) & Format(DtView1(i)("etmt_date"), "yyyyMMdd") & Chr(34)   '���ύ쐬��
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���ϘA����
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���ω񓚓�
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���ω񓚘A����
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���ω񓚃R�[�h
                strData = strData & "," & Chr(34) & Chr(34)                                                     '���ω񓚓�
                strData = strData & "," & Chr(34) & DtView1(i)("rep_yn") & Chr(34)                              '�C���ۃR�[�h
                If Not IsDBNull(DtView1(i)("comp_date")) Then
                    strData = strData & "," & Chr(34) & Format(DtView1(i)("comp_date"), "yyyyMMdd") & Chr(34)   '�C��������
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("sals_date")) Then
                    strData = strData & "," & Chr(34) & Format(DtView1(i)("sals_date"), "yyyyMMdd") & Chr(34)   '�o�ד�
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & DtView1(i)("rb_cls") & Chr(34)                              '�ԍ��敪
                strData = strData & "," & Chr(34) & Chr(34)                                                     '�C�������\���
                strData = strData & "," & Chr(34) & Chr(34)                                                     '�[�i�\���

                strData = strData & "," & Chr(34) & DtView1(i)("dtl_no") & Chr(34)                              '���׍s
                strData = strData & "," & Chr(34) & Chr(34)                                                     '�p�[�c�ԍ�
                strData = strData & "," & Chr(34) & DtView1(i)("part_name") & Chr(34)                           '�p�[�c��
                strData = strData & "," & Chr(34) & DtView1(i)("part_chrg") & Chr(34)                           '�p�[�c���z�ŕ�
                strData = strData & "," & Chr(34) & Chr(34)                                                     '�p�[�c���S�敪
                strData = strData & "," & Chr(34) & DtView1(i)("user_part_chrg") & Chr(34)                      '���q�l�����ŕ�
                strData = strData.Replace(System.Environment.NewLine, " ")    '���s��" "
                'strData = strData.Replace(System.Environment.NewLine, " / ")    '���s��/
                swFile.WriteLine(strData)
            Next

            swFile.Close()          '�t�@�C�������
            DB_CLOSE()
            MessageBox.Show("�o�͂��܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
            Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            sql()
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ����E�I���{�^��
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        WK_DsList2.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  �t�@���N�V�����L�[
    '********************************************************************
    Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

        e.Handled = True        '�t�@���N�V�����L�[�Ɋ���t����ꂽ�ݒ�𖳌��ɂ��܂��B
        Select Case e.KeyIndex  '�t�@���N�V�����L�[���������ꂽ�ꍇ�̏������s���܂��B
            Case 0  'F1
                If f01.Enabled = True Then f01.Focus() : f01_Click(sender, e)
            Case 1  'F2
            Case 2  'F3
            Case 3  'F4
            Case 4  'F5
            Case 5  'F6
            Case 6  'F7
            Case 7  'F8
            Case 8  'F9
            Case 9  'F10
            Case 10 'F11
            Case 11 'F12
                f12_Click(sender, e)
        End Select
    End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub CheckBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.GotFocus
        CheckBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub CheckBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.GotFocus
        CheckBox2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.GotFocus
        f01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub CheckBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.LostFocus
        CheckBox1.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.LostFocus
        CheckBox2.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.LostFocus
        f01.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
