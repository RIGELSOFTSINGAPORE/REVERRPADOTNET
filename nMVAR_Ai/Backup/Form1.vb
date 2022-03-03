Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2, WK_DsList3 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim date_now As Date

    Dim strSQL, Err_F, WK_str, WK_str2, apse_f, strFile, strData As String
    Dim csv(256), dir, Fname, fullname As String
    Dim i, j, r, r2, pos, apse_r, WK_apse, cnt, ttl_cnt As Integer

    Dim WK_rcpt_no, WK_T1 As String
    Dim CG_rcpt_ent_empl_code, CG_repr_empl_code, CG_rcpt_brch_code, CG_arvl_cls As String
    Dim CG_vndr_code, CG_repr_brch_code, CG_defe_cls As String

    Dim sum_cost_part, sum_cost_tax, sum_cost_ttl As Integer
    Dim sum_shop_part, sum_shop_tax, sum_shop_ttl As Integer
    Dim sum_eu_part, sum_eu_tax, sum_eu_ttl As Integer
    Dim WK_tech_chrg, WK_fee As Integer

    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer

    Public P_EMPL_NO As Integer   'LogIn User���
    Public P_EMPL As String   'LogIn User���

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
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.f01 = New System.Windows.Forms.Button
        Me.f12 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Location = New System.Drawing.Point(20, 16)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 1
        Me.f01.Text = "�捞��"
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(132, 16)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 3
        Me.f12.Text = "����"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(250, 75)
        Me.ControlBox = False
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.f01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "��MVAR����f�[�^�捞��"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DB_INIT()
        inz()   '**  ��������
        If Err_F = "1" Then Application.Exit() : Exit Sub
        Call ds_set()
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Err_F = "0"
        P_EMPL = System.Environment.UserName
        If P_EMPL = "otsuki" Then P_EMPL = "administrator" '��΃e�X�g�p

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_Login_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 20)
        Pram1.Value = P_EMPL
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Err_F = "1"
            MessageBox.Show("���[�U�[���o�^����Ă��܂���B", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DtView1(0)("delt_flg") = "1" Then
                Err_F = "1"
                MessageBox.Show("���[�U�[�o�^�������ł��B", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                P_EMPL_NO = DtView1(0)("empl_code")
            End If
        End If
    End Sub

    Sub ds_set()
        DsList1.Clear()
        DB_OPEN("nMVAR")

        strSQL = "SELECT seq, vndr_code, select_case, tech_amnt"
        strSQL = strSQL & " FROM M14_VNDR_SUB"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "M14_VNDR_SUB")

        strSQL = "SELECT * FROM M21_CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "CLS_CODE")

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  �捞�݃{�^��
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click

        With OpenFileDialog1
            .CheckFileExists = True     '�t�@�C�������݂��邩�m�F
            .RestoreDirectory = True    '�f�B���N�g���̕���
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "CSV ̧��(*.csv)|*.csv"
            .FilterIndex = 0
            .InitialDirectory = "\\tsclient\c\nMVAR"

            '�_�C�A���O�{�b�N�X��\�����A�m�J��]���N���b�N�����ꍇ
            If .ShowDialog = DialogResult.OK Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor

                date_now = Now
                fullname = .FileName
                dir = Mid(fullname, 1, fullname.LastIndexOf("\") + 1)
                Fname = fullname.Substring(fullname.LastIndexOf("\") + 1)

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

                waitDlg.MainMsg = "�捞�ݒ�"   ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMsg = ""        ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMax = r         ' �S�̂̏���������ݒ�
                waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim csvDir As String = dir              'CSV�t�@�C���̂���t�H���_
                Dim csvFileName As String = Fname       'CSV�t�@�C���̖��O

                '�ڑ�������
                Dim conString As String = _
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" _
                    + csvDir + ";Extended Properties=""text;HDR=No;FMT=Delimited"""
                Dim con As New System.Data.OleDb.OleDbConnection(conString)

                Dim commText As String = "SELECT * FROM [" + csvFileName + "]"
                Dim da As New System.Data.OleDb.OleDbDataAdapter(commText, con)

                'DataTable�Ɋi�[����
                Dim dt As New DataTable
                da.Fill(dt)
                Dim colCount As Integer = dt.Columns.Count
                Dim row As DataRow

                ttl_cnt = dt.Rows.Count()
                If ttl_cnt > 1 Then

                    ttl_cnt = ttl_cnt - 1
                    waitDlg.MainMsg = "�o�^��"      ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                    waitDlg.ProgressMsg = ""        ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                    waitDlg.ProgressMax = r         ' �S�̂̏���������ݒ�
                    waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                    Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    cnt = 0
                    For Each row In dt.Rows
                        If cnt <> 0 Then

                            For i = 0 To colCount - 1
                                Dim field As String = row(i).ToString()
                                csv(i + 1) = field
                            Next i

                            waitDlg.ProgressMsg = Fix((cnt) * 100 / ttl_cnt) & "%�@�i" & Format(cnt, "##,##0") & " / " & Format(ttl_cnt, "##,##0") & " ���j"
                            waitDlg.Text = "���s���E�E�E" & Fix((cnt) * 100 / ttl_cnt) & "%"
                            Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                            waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                            DB_OPEN("nMVAR")

                            '���[�J�[�R�[�h�ϊ�
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '043' AND cls_code_name = '" & csv(234) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_vndr_code = WK_DtView1(0)("cls_code_name_abbr")                          '���[�J�[�R�[�h
                            Else
                                CG_vndr_code = ""
                            End If

                            '�S���҃R�[�h�ϊ�
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '044' AND cls_code_name = '" & csv(51) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_rcpt_ent_empl_code = WK_DtView1(0)("cls_code_name_abbr")                 '�S���҃R�[�h
                            Else
                                CG_rcpt_ent_empl_code = "0"
                            End If

                            '�����R�[�h�ϊ�
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '045' AND cls_code_name = '" & csv(1) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_rcpt_brch_code = WK_DtView1(0)("cls_code_name_abbr")                     '�����R�[�h
                            Else
                                CG_rcpt_brch_code = ""
                            End If

                            '���׋敪�ϊ�
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '046' AND cls_code_name = '" & csv(6) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_arvl_cls = WK_DtView1(0)("cls_code_name_abbr")                           '���׋敪
                            Else
                                CG_arvl_cls = ""
                            End If

                            '�C�����_�R�[�h�ϊ�
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '047' AND cls_code_name = '" & csv(1) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_repr_brch_code = WK_DtView1(0)("cls_code_name_abbr")                     '�C�����_�R�[�h
                            Else
                                CG_repr_brch_code = ""
                            End If

                            'Mobile��ʕϊ�
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '048' AND cls_code_name = '" & csv(229) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_defe_cls = WK_DtView1(0)("cls_code_name_abbr")                           'Mobile���
                            Else
                                CG_defe_cls = ""
                            End If

                            WK_DsList1.Clear()
                            strSQL = "SELECT *"
                            strSQL = strSQL & " FROM T01_REP_MTR"
                            strSQL = strSQL & " WHERE (imv_rcpt_no = '" & CG_rcpt_brch_code & csv(2) & "')" '�`�[�ԍ�
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            SqlCmd1.CommandTimeout = 600
                            r = DaList1.Fill(WK_DsList1, "T01_REP_MTR")

                            DB_CLOSE()

                            If r = 0 Then   '�V�K�o�^

                                '���[�J�[�}�X�^�����t�ԍ���2���擾
                                strSQL = "SELECT rcpt_up2 FROM M05_VNDR"
                                strSQL = strSQL & " WHERE (vndr_code = '" & CG_vndr_code & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("nMVAR")
                                DaList1.Fill(WK_DsList1, "M05_VNDR")
                                DB_CLOSE()
                                WK_DtView2 = New DataView(WK_DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)
                                If WK_DtView2.Count <> 0 Then
                                    '��t�ԍ��̔�
                                    WK_T1 = WK_DtView2(0)("rcpt_up2")
                                    WK_rcpt_no = Count_Get(WK_T1)
                                End If

                                strSQL = "INSERT INTO T01_REP_MTR"
                                strSQL = strSQL & " (rcpt_no, rcpt_ent_empl_code, rcpt_brch_code, rcpt_cls, qg_care_no, arvl_cls, arvl_empl"
                                strSQL = strSQL & ", store_code, store_prsn, store_repr_no, store_accp_date, store_wrn_info, store_tech_rate"
                                strSQL = strSQL & ", store_tech_mrgn_rate, store_part_mrgn_rate, user_name, user_name_kana, zip, adrs1, adrs2"
                                strSQL = strSQL & ", tel1, tel2, rpar_cls, prch_date, vndr_wrn_date, vndr_wrn_date_chk, vndr_code, model_1"
                                strSQL = strSQL & ", model_2, note_kbn, note_kbn2, s_n, rpar_comp_code, user_trbl, rcpt_comn, orgnl_vndr_code"
                                strSQL = strSQL & ", wrn_limt_amnt, menseki_amnt, acdt_stts, acdt_date, recv_amnt, tech_rate1, fix1, tech_rate2"
                                strSQL = strSQL & ", part_rate2, etmt_ent_empl_code, etmt_brch_code, etmt_empl_code, tier, vndr_repr_no"
                                strSQL = strSQL & ", etmt_meas, etmt_comn, rsrv_cacl_comn, etmt_cost_tech_chrg, etmt_cost_apes"
                                strSQL = strSQL & ", etmt_cost_part_chrg, etmt_cost_fee, etmt_cost_pstg, etmt_cost_tax, etmt_cost_cxl"
                                strSQL = strSQL & ", etmt_cost_ttl, etmt_shop_tech_chrg, etmt_shop_apes, etmt_shop_part_chrg, etmt_shop_fee"
                                strSQL = strSQL & ", etmt_shop_pstg, etmt_shop_tax, etmt_shop_cxl, etmt_shop_ttl, etmt_eu_tech_chrg"
                                strSQL = strSQL & ", etmt_eu_apes, etmt_eu_part_chrg, etmt_eu_fee, etmt_eu_pstg, etmt_eu_tax, etmt_eu_cxl"
                                strSQL = strSQL & ", etmt_eu_ttl, zh_code, etmt_sum_flg, fin_ent_empl_code, repr_empl_code, repr_brch_code"
                                strSQL = strSQL & ", comp_meas, m_tech_seq, comp_comn, comp_cost_tech_chrg, comp_cost_apes, comp_cost_part_chrg"
                                strSQL = strSQL & ", comp_cost_fee, comp_cost_pstg, comp_cost_tax, comp_cost_cxl, comp_cost_ttl"
                                strSQL = strSQL & ", comp_shop_tech_chrg, comp_shop_apes, comp_shop_part_chrg, comp_shop_fee, comp_shop_pstg"
                                strSQL = strSQL & ", comp_shop_tax, comp_shop_cxl, comp_shop_ttl, comp_eu_tech_chrg, comp_eu_apes"
                                strSQL = strSQL & ", comp_eu_part_chrg, comp_eu_fee, comp_eu_pstg, comp_eu_tax, comp_eu_cxl, comp_eu_ttl"
                                strSQL = strSQL & ", comp_sum_flg, zero_code, zero_name, re_rpar_date, rebate, kjo_brch_code, rcpt_no_aka"
                                strSQL = strSQL & ", rcpt_no_kuro, aka_flg, rpt_ex_flg, accp_date, etmt_date, rsrv_cacl_date, part_ordr_date"
                                strSQL = strSQL & ", part_rcpt_date, comp_date, sals_date, sals_no, sals_no2, ship_date, rqst_date, tax_rate"
                                strSQL = strSQL & ", wrn_period, idvd_chrg, neva_chek_flg, neva_amnt, defe_cls, reference_no, imv_rcpt_no)"

                                strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"               '��t�ԍ�
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '��t���͎҃R�[�h
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"   '��t�����R�[�h
                                If csv(234) = "3" Then
                                    strSQL = strSQL & ", '11'"                                  '��t���(CLS:007)
                                Else
                                    strSQL = strSQL & ", '01'"
                                End If
                                strSQL = strSQL & ", ''"                                        'QG Care��
                                strSQL = strSQL & ", '" & MidB(CG_arvl_cls, 1, 2) & "'"         '���׋敪(CLS:018)
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '���גS��
                                strSQL = strSQL & ", '0020'"                                    '�̎ЃR�[�h
                                strSQL = strSQL & ", ''"                                        '�̎ВS����
                                strSQL = strSQL & ", ''"                                        '�̎ЏC���ԍ�
                                strSQL = strSQL & ", NULL"                                      '�̎Ў�t��
                                strSQL = strSQL & ", ''"                                        '�̎Љ������
                                strSQL = strSQL & ", 0"                                         '�̎ЋZ�p���|��
                                strSQL = strSQL & ", 0"                                         '�̎ЋZ�p���}�[�W����
                                strSQL = strSQL & ", 0"                                         '�̎Е��i��}�[�W����
                                strSQL = strSQL & ", '" & MidB(csv(12), 1, 30) & "'"            '���[�U�[��
                                strSQL = strSQL & ", '" & MidB(csv(13), 1, 15) & "'"            '���[�U�[���J�i
                                strSQL = strSQL & ", '" & MidB(csv(16), 1, 7) & "'"             '�X�֔ԍ�
                                strSQL = strSQL & ", '" & MidB(csv(17), 1, 40) & "'"            '�Z��1
                                strSQL = strSQL & ", '" & MidB(csv(18) & csv(19), 1, 40) & "'"  '�Z��2
                                strSQL = strSQL & ", '" & MidB(csv(14), 1, 14) & "'"            '���[�U�[�d�b�ԍ�1
                                strSQL = strSQL & ", ''"                                        '���[�U�[�d�b�ԍ�2
                                If csv(220) = "1" Then
                                    strSQL = strSQL & ", '02'"                                  '�C�����(CLS:001)
                                    apse_f = "1"
                                Else
                                    strSQL = strSQL & ", '01'"
                                    apse_f = "0"
                                End If
                                If IsDate(csv(65)) = True Then
                                    strSQL = strSQL & ", '" & csv(65) & "'"                     '�w����
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      '���[�J�[�ۏ؊J�n��
                                strSQL = strSQL & ", 0"                                         '���y�A�G�N�X�e���V�����t���O
                                strSQL = strSQL & ", '" & MidB(CG_vndr_code, 1, 2) & "'"        '���[�J�[�R�[�h
                                If CG_vndr_code = "01" Or CG_vndr_code = "20" Then
                                    apse_f = apse_f & "1"
                                Else
                                    apse_f = apse_f & "0"
                                End If
                                strSQL = strSQL & ", '" & MidB(csv(58), 1, 50) & "'"            '�@�햼
                                strSQL = strSQL & ", '" & MidB(csv(59), 1, 50) & "'"            '���f��
                                strSQL = strSQL & ", ''"                                        '�m�[�gPC�敪(CLS:011) Apple�̎��͒�z�A�|��
                                strSQL = strSQL & ", ''"                                        '�m�[�gPC�敪(CLS:011)
                                strSQL = strSQL & ", '" & MidB(csv(61), 1, 25) & "'"            'S/N
                                strSQL = strSQL & ", '" & MidB(CG_repr_brch_code, 1, 2) & "'"   '�C����ЃR�[�h
                                strSQL = strSQL & ", '" & MidB(csv(78), 1, 500) & "'"           '�̏���e
                                strSQL = strSQL & ", '" & MidB(csv(222), 1, 200) & "'"          '��t�R�����g
                                strSQL = strSQL & ", '" & MidB(csv(11), 1, 50) & "'"            '�ؼ���Ұ������
                                strSQL = strSQL & ", 0"                                         '�ۏ،��x�z
                                strSQL = strSQL & ", 0"                                         '�Ɛӊz
                                strSQL = strSQL & ", '01'"                                      '���̏󋵃R�[�h(CLS:022)
                                strSQL = strSQL & ", NULL"                                      '���̓�
                                strSQL = strSQL & ", " & CInt(csv(201))                         '�a�����
                                strSQL = strSQL & ", 0"                                         '�̎ЋZ�p���|��
                                strSQL = strSQL & ", 0"                                         '��z
                                strSQL = strSQL & ", 0"                                         'EU�Z�p���|��
                                strSQL = strSQL & ", 0"                                         'EU���i�|��
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '���ϓ��͎҃R�[�h
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"   '���ϕ����R�[�h
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '���ώ҃R�[�h
                                strSQL = strSQL & ", ''"                                        '�ڈ�Tier(CLS:013)
                                strSQL = strSQL & ", ''"                                        '���[�J�[�C���ԍ�
                                strSQL = strSQL & ", '" & MidB(csv(241), 1, 300) & "'"          '���ϓ��e
                                strSQL = strSQL & ", ''"                                        '���σR�����g
                                strSQL = strSQL & ", ''"                                        '�ۗ������A��

                                If csv(39) <> Nothing Then  '���σf�[�^
                                    If csv(220) = "1" Then  '������ʃR�[�h
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If

                                    strSQL = strSQL & ", 0"                                         '���σR�X�g�Z�p��
                                    strSQL = strSQL & ", 0"                                         '���σR�X�gAPES
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", " & sum_cost_part                          '���σR�X�g���i��
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g���̑�
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g����
                                    sum_cost_ttl = sum_cost_part
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_cost_tax                           '���σR�X�g�����
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g�L�����Z����
                                    strSQL = strSQL & ", " & sum_cost_ttl                           '���σR�X�g���v

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '���όv��Z�p��
                                    strSQL = strSQL & ", 0"                                         '���όv��APES
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_shop_part                          '���όv�㕔�i��
                                    strSQL = strSQL & ", " & WK_fee                                 '���όv�セ�̑�
                                    strSQL = strSQL & ", 0"                                         '���όv�㑗��
                                    sum_shop_ttl = sum_shop_part + WK_fee + WK_tech_chrg
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_shop_tax                           '���όv������
                                    strSQL = strSQL & ", 0"                                         '���όv��L�����Z����
                                    strSQL = strSQL & ", " & sum_shop_ttl                           '���όv�㏬�v

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '����EU�Z�p��
                                    strSQL = strSQL & ", 0"                                         '����EUAPES
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_eu_part                            '����EU���i��
                                    strSQL = strSQL & ", " & WK_fee                                 '����EU���̑�
                                    strSQL = strSQL & ", 0"                                         '����EU����
                                    sum_eu_ttl = sum_eu_part + WK_fee + WK_tech_chrg
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_eu_tax                             '����EU�����
                                    strSQL = strSQL & ", 0"                                         '����EU�L�����Z����
                                    strSQL = strSQL & ", " & sum_eu_ttl                             '����EU���v
                                Else
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g�Z�p��
                                    strSQL = strSQL & ", 0"                                         '���σR�X�gAPES
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g���i��
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g���̑�
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g����
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g�����
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g�L�����Z����
                                    strSQL = strSQL & ", 0"                                         '���σR�X�g���v

                                    strSQL = strSQL & ", 0"                                         '���όv��Z�p��
                                    strSQL = strSQL & ", 0"                                         '���όv��APES
                                    strSQL = strSQL & ", 0"                                         '���όv�㕔�i��
                                    strSQL = strSQL & ", 0"                                         '���όv�セ�̑�
                                    strSQL = strSQL & ", 0"                                         '���όv�㑗��
                                    strSQL = strSQL & ", 0"                                         '���όv������
                                    strSQL = strSQL & ", 0"                                         '���όv��L�����Z����
                                    strSQL = strSQL & ", 0"                                         '���όv�㏬�v

                                    strSQL = strSQL & ", 0"                                         '����EU�Z�p��
                                    strSQL = strSQL & ", 0"                                         '����EUAPES
                                    strSQL = strSQL & ", 0"                                         '����EU���i��
                                    strSQL = strSQL & ", 0"                                         '����EU���̑�
                                    strSQL = strSQL & ", 0"                                         '����EU����
                                    strSQL = strSQL & ", 0"                                         '����EU�����
                                    strSQL = strSQL & ", 0"                                         '����EU�L�����Z����
                                    strSQL = strSQL & ", 0"                                         '����EU���v
                                End If

                                strSQL = strSQL & ", ''"                                        '���s�ԋp���ށiZ:���s H:�ԋp�j
                                strSQL = strSQL & ", 0"                                         '���ώ����v�Z���Ȃ��t���O
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '�������͎҃R�[�h
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '�C���҃R�[�h
                                strSQL = strSQL & ", '" & MidB(CG_repr_brch_code, 1, 2) & "'"   '�C�������R�[�h
                                strSQL = strSQL & ", '" & MidB(csv(83) & csv(84), 1, 1000) & "'" '�������e

                                If csv(22) <> Nothing Then  '�����f�[�^
                                    If csv(220) = "1" Then
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If

                                    WK_DtView2 = New DataView(DsList1.Tables("M14_VNDR_SUB"), "vndr_code = '" & CG_vndr_code & "' AND tech_amnt = " & WK_tech_chrg, "", DataViewRowState.CurrentRows)
                                    If WK_DtView2.Count <> 0 Then
                                        strSQL = strSQL & ", 0" & WK_DtView2(0)("seq")              '���[�J�[�ۏ؋Z�p��SEQ
                                    Else
                                        strSQL = strSQL & ", 0"
                                    End If
                                    strSQL = strSQL & ", '" & MidB(csv(223), 1, 200) & "'"          '�����R�����g

                                    strSQL = strSQL & ", 0"                                         '�����R�X�g�Z�p��
                                    strSQL = strSQL & ", 0"                                         '�����R�X�gAPES
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", " & sum_cost_part                          '�����R�X�g���i��
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g���̑�
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g����
                                    sum_cost_ttl = sum_cost_part
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_cost_tax                           '�����R�X�g�����
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g�L�����Z����
                                    strSQL = strSQL & ", " & sum_cost_ttl                           '�����R�X�g���v

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '�����v��Z�p��
                                    WK_apse = 0
                                    'If apse_f = "11" Then
                                    '    If IsDate(csv(22)) = True Then
                                    '        apse_r = APSE_GET(CG_repr_brch_code, csv(22))
                                    '        If apse_r <> 0 Then
                                    '            WK_apse = WK_tech_chrg * (apse_r - 100) / 100
                                    '        End If
                                    '    End If
                                    'End If
                                    strSQL = strSQL & ", " & WK_apse                                '�����v��APES
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_shop_part                          '�����v�㕔�i��
                                    strSQL = strSQL & ", " & WK_fee                                 '�����v�セ�̑�
                                    strSQL = strSQL & ", 0"                                         '�����v�㑗��
                                    sum_shop_ttl = sum_shop_part + WK_fee + WK_tech_chrg + WK_apse
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_shop_tax                           '�����v������
                                    strSQL = strSQL & ", 0"                                         '�����v��L�����Z����
                                    strSQL = strSQL & ", " & sum_shop_ttl                           '�����v�㏬�v

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '����EU�Z�p��
                                    strSQL = strSQL & ", 0"                                         '����EUAPES
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_eu_part                            '����EU���i��
                                    strSQL = strSQL & ", " & WK_fee                                 '����EU���̑�
                                    strSQL = strSQL & ", 0"                                         '����EU����
                                    sum_eu_ttl = sum_eu_part + WK_fee + WK_tech_chrg
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_eu_tax                             '����EU�����
                                    strSQL = strSQL & ", 0"                                         '����EU�L�����Z����
                                    strSQL = strSQL & ", " & sum_eu_ttl                             '����EU���v
                                Else
                                    strSQL = strSQL & ", 0"                                         '���[�J�[�ۏ؋Z�p��SEQ
                                    strSQL = strSQL & ", '" & MidB(csv(2), 1, 200) & "'"            '�����R�����g

                                    strSQL = strSQL & ", 0"                                         '�����R�X�g�Z�p��
                                    strSQL = strSQL & ", 0"                                         '�����R�X�gAPES
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g���i��
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g���̑�
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g����
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g�����
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g�L�����Z����
                                    strSQL = strSQL & ", 0"                                         '�����R�X�g���v

                                    strSQL = strSQL & ", 0"                                         '�����v��Z�p��
                                    strSQL = strSQL & ", 0"                                         '�����v��APES
                                    strSQL = strSQL & ", 0"                                         '�����v�㕔�i��
                                    strSQL = strSQL & ", 0"                                         '�����v�セ�̑�
                                    strSQL = strSQL & ", 0"                                         '�����v�㑗��
                                    strSQL = strSQL & ", 0"                                         '�����v������
                                    strSQL = strSQL & ", 0"                                         '�����v��L�����Z����
                                    strSQL = strSQL & ", 0"                                         '�����v�㏬�v

                                    strSQL = strSQL & ", 0"                                         '����EU�Z�p��
                                    strSQL = strSQL & ", 0"                                         '����EUAPES
                                    strSQL = strSQL & ", 0"                                         '����EU���i��
                                    strSQL = strSQL & ", 0"                                         '����EU���̑�
                                    strSQL = strSQL & ", 0"                                         '����EU����
                                    strSQL = strSQL & ", 0"                                         '����EU�����
                                    strSQL = strSQL & ", 0"                                         '����EU�L�����Z����
                                    strSQL = strSQL & ", 0"                                         '����EU���v
                                End If

                                strSQL = strSQL & ", 0"                                         '���������v�Z���Ȃ��t���O
                                strSQL = strSQL & ", ''"                                        '���O���R�R�[�h
                                strSQL = strSQL & ", '" & MidB(csv(233), 1, 33) & "'"           '���O���R
                                strSQL = strSQL & ", NULL"                                      '�ďC���L��������
                                strSQL = strSQL & ", 0"                                         '���x�[�g��
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"   '�v�㕔���R�[�h
                                strSQL = strSQL & ", NULL"                                      '��t�ԍ�_��
                                strSQL = strSQL & ", NULL"                                      '��t�ԍ�_��
                                strSQL = strSQL & ", 0"                                         '�ԓ`�����׸�
                                strSQL = strSQL & ", 0"                                         '�W�v���O�׸�
                                If IsDate(csv(21)) = True Then
                                    strSQL = strSQL & ", '" & csv(21) & "'"                     '��t��
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                If IsDate(csv(39)) = True Then
                                    strSQL = strSQL & ", '" & csv(39) & "'"                     '���ϓ�
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      '�ۗ�������
                                strSQL = strSQL & ", NULL"                                      '���i������
                                strSQL = strSQL & ", NULL"                                      '���i��̓�
                                If IsDate(csv(22)) = True Then
                                    strSQL = strSQL & ", '" & csv(22) & "'"                     '������
                                    strSQL = strSQL & ", '" & csv(22) & "'"                     '�����
                                Else
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      '�l�o�`�ԍ�
                                strSQL = strSQL & ", NULL"                                      '�l�o�`�ԍ��i���x�[�g�j
                                If IsDate(csv(22)) = True Then
                                    strSQL = strSQL & ", '" & csv(22) & "'"                     '�o�ד�
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      '������
                                strSQL = strSQL & ", 5"                                         '����ŗ�
                                strSQL = strSQL & ", 0"                                         '�C���[�ۏ؊��ԁi���j
                                strSQL = strSQL & ", 0"                                         '���ȕ��S��
                                strSQL = strSQL & ", 0"                                         '�l�o�`�������׸ށiQG�j
                                strSQL = strSQL & ", 0"                                         '�l�o�`���z
                                strSQL = strSQL & ", '" & CG_defe_cls & "'"                     '�s�ǎ��(CLS:035)
                                strSQL = strSQL & ", '" & MidB(csv(243), 1, 10) & "'"           '���W�ԍ�
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & csv(2) & "')" 'iMVAR�Ǘ��ԍ�
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DB_OPEN("nMVAR")
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                '�g�p���i
                                If csv(39) <> Nothing Then  '���σf�[�^
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then
                                            strSQL = "INSERT INTO T04_REP_PART"
                                            strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                            strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                            strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"           '��t�ԍ�
                                            strSQL = strSQL & ", '1'"                                   '�敪�i1:���� 2:�����j
                                            strSQL = strSQL & ", " & j                                  'SEQ
                                            strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"       '���i�R�[�h
                                            strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"  '���i��
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 '���i�P��
                                            strSQL = strSQL & ", " & CInt(csv(pos + 2))                 '�g�p��
                                            strSQL = strSQL & ", 0"                                     '�݌Ɏg�p�t���O
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 '�R�X�g
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'GSS�v��
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'EU��
                                            strSQL = strSQL & ", ''"                                    '�����ԍ�
                                            strSQL = strSQL & ", ''"                                    '���󒍔�
                                            strSQL = strSQL & ", 0"                                     'IBM�ً}�t���O
                                            strSQL = strSQL & ", 0)"                                    '���Օi�t���O
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DB_OPEN("nMVAR")
                                            SqlCmd1.ExecuteNonQuery()
                                            DB_CLOSE()
                                        End If
                                    Next
                                End If

                                If csv(22) <> Nothing Then  '�����f�[�^
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then
                                            strSQL = "INSERT INTO T04_REP_PART"
                                            strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                            strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                            strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"           '��t�ԍ�
                                            strSQL = strSQL & ", '2'"                                   '�敪�i1:���� 2:�����j
                                            strSQL = strSQL & ", " & j                                  'SEQ
                                            strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"       '���i�R�[�h
                                            strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"  '���i��
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 '���i�P��
                                            strSQL = strSQL & ", " & CInt(csv(pos + 2))                 '�g�p��
                                            strSQL = strSQL & ", 0"                                     '�݌Ɏg�p�t���O
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 '�R�X�g
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'GSS�v��
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'EU��
                                            strSQL = strSQL & ", ''"                                    '�����ԍ�
                                            strSQL = strSQL & ", ''"                                    '���󒍔�
                                            strSQL = strSQL & ", 0"                                     'IBM�ً}�t���O
                                            strSQL = strSQL & ", 0)"                                    '���Օi�t���O
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DB_OPEN("nMVAR")
                                            SqlCmd1.ExecuteNonQuery()
                                            DB_CLOSE()
                                        End If
                                    Next
                                End If

                                '����
                                DB_OPEN("nMVAR")
                                If IsDate(csv(22)) = True Then
                                    strSQL = "INSERT INTO T10_SALS"
                                    strSQL = strSQL & " (rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2"
                                    strSQL = strSQL & ", neva_chek_date, neva_chek_date2, neva_chek_list, invc_cls_date, invc_flg)"
                                    strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"
                                    strSQL = strSQL & ", '4'"
                                    strSQL = strSQL & ", " & sum_eu_ttl
                                    strSQL = strSQL & ", " & sum_eu_tax
                                    strSQL = strSQL & ", 0"
                                    strSQL = strSQL & ", 0"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", 0)"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.ExecuteNonQuery()
                                End If

                                'CSV�X�V
                                strSQL = "INSERT INTO T50_AI_CSV (imp_date, seq, rcpt_no)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & date_now & "', 102)"
                                strSQL = strSQL & ", 1"
                                strSQL = strSQL & ", '" & WK_rcpt_no & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()

                                '�����X�V
                                strSQL = "INSERT INTO L01_HSTY"
                                strSQL = strSQL & " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & Now & "', 102)"
                                strSQL = strSQL & ", " & P_EMPL_NO
                                strSQL = strSQL & ", '" & WK_rcpt_no & "'"
                                strSQL = strSQL & ", 'Ai�捞��'"
                                strSQL = strSQL & ", ''"
                                strSQL = strSQL & ", '')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()


                            Else            '�X�V
                                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

                                strSQL = "UPDATE T01_REP_MTR"
                                strSQL = strSQL & " SET rcpt_ent_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", rcpt_brch_code = '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"
                                If csv(234) = "3" Then
                                    strSQL = strSQL & ", rcpt_cls = '11'"
                                Else
                                    strSQL = strSQL & ", rcpt_cls = '01'"
                                End If
                                strSQL = strSQL & ", arvl_cls = '" & MidB(CG_arvl_cls, 1, 2) & "'"
                                strSQL = strSQL & ", arvl_empl = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", user_name = '" & MidB(csv(12), 1, 30) & "'"
                                strSQL = strSQL & ", user_name_kana = '" & MidB(csv(13), 1, 15) & "'"
                                strSQL = strSQL & ", zip = '" & MidB(csv(16), 1, 7) & "'"
                                strSQL = strSQL & ", adrs1 = '" & MidB(csv(17), 1, 40) & "'"
                                strSQL = strSQL & ", adrs2 = '" & MidB(csv(18) & csv(19), 1, 40) & "'"
                                strSQL = strSQL & ", tel1 = '" & MidB(csv(14), 1, 14) & "'"
                                If csv(220) = "1" Then
                                    strSQL = strSQL & ", rpar_cls = '02'"
                                    apse_f = "1"
                                Else
                                    strSQL = strSQL & ", rpar_cls = '01'"
                                    apse_f = "0"
                                End If
                                If IsDate(csv(65)) = True Then
                                    strSQL = strSQL & ", prch_date = CONVERT(DATETIME, '" & csv(65) & "', 102)"
                                Else
                                    strSQL = strSQL & ", prch_date = NULL"
                                End If
                                strSQL = strSQL & ", vndr_code = '" & MidB(CG_vndr_code, 1, 2) & "'"
                                If CG_vndr_code = "01" Or CG_vndr_code = "20" Then
                                    apse_f = apse_f & "1"
                                Else
                                    apse_f = apse_f & "0"
                                End If
                                strSQL = strSQL & ", model_1 = '" & MidB(csv(58), 1, 50) & "'"
                                strSQL = strSQL & ", model_2 = '" & MidB(csv(59), 1, 50) & "'"
                                strSQL = strSQL & ", s_n = '" & MidB(csv(61), 1, 25) & "'"
                                strSQL = strSQL & ", rpar_comp_code = '" & MidB(CG_repr_brch_code, 1, 2) & "'"
                                strSQL = strSQL & ", user_trbl = '" & MidB(csv(78), 1, 200) & "'"
                                strSQL = strSQL & ", rcpt_comn = '" & MidB(csv(222), 1, 200) & "'"
                                strSQL = strSQL & ", orgnl_vndr_code = '" & MidB(csv(11), 1, 50) & "'"
                                strSQL = strSQL & ", acdt_stts = '01'"
                                strSQL = strSQL & ", recv_amnt = '" & CInt(csv(201)) & "'"
                                strSQL = strSQL & ", etmt_ent_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", etmt_brch_code = '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"
                                strSQL = strSQL & ", etmt_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", etmt_meas = '" & MidB(csv(241), 1, 300) & "'"

                                If csv(39) <> Nothing Then  '���σf�[�^
                                    If csv(220) = "1" Then  '������ʃR�[�h
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If

                                    'strSQL = strSQL & ", etmt_cost_tech_chrg = " & WK_DtView1(0)("etmt_cost_tech_chrg")
                                    'strSQL = strSQL & ", etmt_cost_apes = " & WK_DtView1(0)("etmt_cost_apes")
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", etmt_cost_part_chrg = " & sum_cost_part
                                    'strSQL = strSQL & ", etmt_cost_fee = " & WK_DtView1(0)("etmt_cost_fee")
                                    'strSQL = strSQL & ", etmt_cost_pstg = " & WK_DtView1(0)("etmt_cost_pstg")
                                    sum_cost_ttl = WK_DtView1(0)("comp_cost_tech_chrg") + WK_DtView1(0)("etmt_cost_apes") + sum_cost_part + WK_DtView1(0)("etmt_cost_fee") + WK_DtView1(0)("etmt_cost_pstg")
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", etmt_cost_tax = " & sum_cost_tax
                                    'strSQL = strSQL & ", etmt_cost_cxl = " & WK_DtView1(0)("etmt_cost_cxl")
                                    strSQL = strSQL & ", etmt_cost_ttl = " & sum_cost_ttl

                                    strSQL = strSQL & ", etmt_shop_tech_chrg = " & WK_tech_chrg
                                    'strSQL = strSQL & ", etmt_shop_apes = " & WK_DtView1(0)("etmt_shop_apes")
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", etmt_shop_part_chrg = " & sum_shop_part
                                    strSQL = strSQL & ", etmt_shop_fee = " & WK_fee
                                    'strSQL = strSQL & ", etmt_shop_pstg = " & WK_DtView1(0)("etmt_shop_pstg")
                                    sum_shop_ttl = WK_tech_chrg + WK_DtView1(0)("etmt_shop_apes") + sum_shop_part + WK_fee + WK_DtView1(0)("etmt_shop_pstg")
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", etmt_shop_tax = " & sum_shop_tax
                                    'strSQL = strSQL & ", etmt_shop_cxl = " & WK_DtView1(0)("etmt_shop_cxl")
                                    strSQL = strSQL & ", etmt_shop_ttl = " & sum_shop_ttl

                                    strSQL = strSQL & ", etmt_eu_tech_chrg = " & WK_tech_chrg
                                    'strSQL = strSQL & ", etmt_eu_apes = " & WK_DtView1(0)("etmt_eu_apes")
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", etmt_eu_part_chrg = " & sum_eu_part
                                    strSQL = strSQL & ", etmt_eu_fee = " & WK_fee
                                    'strSQL = strSQL & ", etmt_eu_pstg = " & WK_DtView1(0)("etmt_eu_pstg")
                                    sum_eu_ttl = WK_tech_chrg + WK_DtView1(0)("etmt_eu_apes") + sum_eu_part + WK_fee + WK_DtView1(0)("etmt_eu_pstg")
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", etmt_eu_tax = " & sum_eu_tax
                                    'strSQL = strSQL & ", etmt_eu_cxl = " & WK_DtView1(0)("etmt_eu_cxl")
                                    strSQL = strSQL & ", etmt_eu_ttl = " & sum_eu_ttl
                                End If

                                strSQL = strSQL & ", fin_ent_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", repr_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", repr_brch_code = '" & MidB(CG_repr_brch_code, 1, 2) & "'"
                                strSQL = strSQL & ", comp_meas = '" & MidB(csv(83) & csv(84), 1, 1000) & "'"
                                strSQL = strSQL & ", comp_comn = '" & MidB(csv(223), 1, 200) & "'"

                                If csv(22) <> Nothing Then  '�����f�[�^
                                    If csv(220) = "1" Then  '������ʃR�[�h
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If
                                    'strSQL = strSQL & ", comp_cost_tech_chrg = " & WK_DtView1(0)("comp_cost_tech_chrg")
                                    'strSQL = strSQL & ", comp_cost_apes = " & WK_DtView1(0)("comp_cost_apes")
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", comp_cost_part_chrg = " & sum_cost_part
                                    'strSQL = strSQL & ", comp_cost_fee = " & WK_DtView1(0)("comp_cost_fee")
                                    'strSQL = strSQL & ", comp_cost_pstg = " & WK_DtView1(0)("comp_cost_pstg")
                                    sum_cost_ttl = WK_DtView1(0)("comp_cost_tech_chrg") + WK_DtView1(0)("comp_cost_apes") + sum_cost_part + WK_DtView1(0)("comp_cost_fee") + WK_DtView1(0)("comp_cost_pstg")
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", comp_cost_tax = " & sum_cost_tax
                                    'strSQL = strSQL & ", comp_cost_cxl = " & WK_DtView1(0)("comp_cost_cxl")
                                    strSQL = strSQL & ", comp_cost_ttl = " & sum_cost_ttl

                                    strSQL = strSQL & ", comp_shop_tech_chrg = " & WK_tech_chrg
                                    WK_apse = 0
                                    'If apse_f = "11" Then
                                    '    If IsDate(csv(22)) = True Then
                                    '        apse_r = APSE_GET(CG_repr_brch_code, csv(22))
                                    '        If apse_r <> 0 Then
                                    '            WK_apse = WK_tech_chrg * (apse_r - 100) / 100
                                    '        End If
                                    '    End If
                                    'End If
                                    strSQL = strSQL & ", comp_shop_apes = " & WK_apse
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", comp_shop_part_chrg = " & sum_shop_part
                                    strSQL = strSQL & ", comp_shop_fee = " & WK_fee
                                    'strSQL = strSQL & ", comp_shop_pstg = " & WK_DtView1(0)("comp_shop_pstg")
                                    sum_shop_ttl = WK_tech_chrg + WK_apse + sum_shop_part + WK_fee + WK_DtView1(0)("comp_shop_pstg")
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", comp_shop_tax = " & sum_shop_tax
                                    'strSQL = strSQL & ", comp_shop_cxl = " & WK_DtView1(0)("comp_shop_cxl")
                                    strSQL = strSQL & ", comp_shop_ttl = " & sum_shop_ttl

                                    strSQL = strSQL & ", comp_eu_tech_chrg = " & WK_tech_chrg
                                    'strSQL = strSQL & ", comp_eu_apes = " & WK_DtView1(0)("comp_eu_apes")
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", comp_eu_part_chrg = " & sum_eu_part
                                    strSQL = strSQL & ", comp_eu_fee = " & WK_fee
                                    'strSQL = strSQL & ", comp_eu_pstg = " & WK_DtView1(0)("comp_eu_pstg")
                                    sum_eu_ttl = WK_tech_chrg + WK_DtView1(0)("comp_eu_apes") + sum_eu_part + WK_fee + WK_DtView1(0)("comp_eu_pstg")
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", comp_eu_tax = " & sum_eu_tax
                                    'strSQL = strSQL & ", comp_eu_cxl = " & WK_DtView1(0)("comp_eu_cxl")
                                    strSQL = strSQL & ", comp_eu_ttl = " & sum_eu_ttl
                                End If

                                strSQL = strSQL & ", zero_name = '" & MidB(csv(233), 1, 33) & "'"
                                strSQL = strSQL & ", kjo_brch_code = '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"
                                If IsDate(csv(21)) = True Then
                                    strSQL = strSQL & ", accp_date = CONVERT(DATETIME, '" & csv(21) & "', 102)"
                                Else
                                    strSQL = strSQL & ", accp_date = NULL"
                                End If
                                If IsDate(csv(39)) = True Then
                                    strSQL = strSQL & ", etmt_date = CONVERT(DATETIME, '" & csv(39) & "', 102)"
                                Else
                                    strSQL = strSQL & ", etmt_date = NULL"
                                End If
                                If IsDate(csv(22)) = True Then
                                    strSQL = strSQL & ", comp_date = CONVERT(DATETIME, '" & csv(22) & "', 102)"
                                    strSQL = strSQL & ", sals_date = CONVERT(DATETIME, '" & csv(22) & "', 102)"
                                    strSQL = strSQL & ", ship_date = CONVERT(DATETIME, '" & csv(22) & "', 102)"
                                Else
                                    strSQL = strSQL & ", comp_date = NULL"
                                    strSQL = strSQL & ", sals_date = NULL"
                                    strSQL = strSQL & ", ship_date = NULL"
                                End If
                                strSQL = strSQL & ", defe_cls = '" & MidB(CG_defe_cls, 1, 2) & "'"
                                strSQL = strSQL & ", reference_no = '" & MidB(csv(243), 1, 10) & "'"
                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DB_OPEN("nMVAR")
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                '�g�p���i
                                If csv(39) <> Nothing Then  '���σf�[�^
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '1')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()

                                            If r2 = 0 Then
                                                strSQL = "INSERT INTO T04_REP_PART"
                                                strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                                strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                                strSQL = strSQL & " VALUES ('" & WK_DtView1(0)("rcpt_no") & "'" '��t�ԍ�
                                                strSQL = strSQL & ", '1'"                                       '�敪�i1:���� 2:�����j
                                                strSQL = strSQL & ", " & j                                      'SEQ
                                                strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"           '���i�R�[�h
                                                strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"      '���i��
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     '���i�P��
                                                strSQL = strSQL & ", " & CInt(csv(pos + 2))                     '�g�p��
                                                strSQL = strSQL & ", 0"                                         '�݌Ɏg�p�t���O
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     '�R�X�g
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'GSS�v��
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'EU��
                                                strSQL = strSQL & ", ''"                                        '�����ԍ�
                                                strSQL = strSQL & ", ''"                                        '���󒍔�
                                                strSQL = strSQL & ", 0"                                         'IBM�ً}�t���O
                                                strSQL = strSQL & ", 0)"                                        '���Օi�t���O
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            Else
                                                'upfate
                                                strSQL = "UPDATE T04_REP_PART"
                                                strSQL = strSQL & " SET part_code = '" & MidB(csv(pos), 1, 20) & "'"
                                                strSQL = strSQL & ", part_name = '" & MidB(csv(pos + 1), 1, 100) & "'"
                                                strSQL = strSQL & ", part_amnt = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", use_qty = " & CInt(csv(pos + 2))
                                                strSQL = strSQL & ", cost_chrg = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", shop_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & ", eu_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '1')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        Else

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '1')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()
                                            If r2 <> 0 Then
                                                'delete
                                                strSQL = "DELETE FROM T04_REP_PART"
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '1')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        End If
                                    Next
                                End If
                                If csv(22) <> Nothing Then  '�����f�[�^
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '2')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()

                                            If r2 = 0 Then
                                                strSQL = "INSERT INTO T04_REP_PART"
                                                strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                                strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                                strSQL = strSQL & " VALUES ('" & WK_DtView1(0)("rcpt_no") & "'" '��t�ԍ�
                                                strSQL = strSQL & ", '2'"                                       '�敪�i1:���� 2:�����j
                                                strSQL = strSQL & ", " & j                                      'SEQ
                                                strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"           '���i�R�[�h
                                                strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"      '���i��
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     '���i�P��
                                                strSQL = strSQL & ", " & CInt(csv(pos + 2))                     '�g�p��
                                                strSQL = strSQL & ", 0"                                         '�݌Ɏg�p�t���O
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     '�R�X�g
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'GSS�v��
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'EU��
                                                strSQL = strSQL & ", ''"                                        '�����ԍ�
                                                strSQL = strSQL & ", ''"                                        '���󒍔�
                                                strSQL = strSQL & ", 0"                                         'IBM�ً}�t���O
                                                strSQL = strSQL & ", 0)"                                        '���Օi�t���O
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            Else
                                                'upfate
                                                strSQL = "UPDATE T04_REP_PART"
                                                strSQL = strSQL & " SET part_code = '" & MidB(csv(pos), 1, 20) & "'"
                                                strSQL = strSQL & ", part_name = '" & MidB(csv(pos + 1), 1, 100) & "'"
                                                strSQL = strSQL & ", part_amnt = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", use_qty = " & CInt(csv(pos + 2))
                                                strSQL = strSQL & ", cost_chrg = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", shop_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & ", eu_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '2')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        Else

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '2')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()
                                            If r2 <> 0 Then
                                                'delete
                                                strSQL = "DELETE FROM T04_REP_PART"
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '2')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        End If
                                    Next
                                End If

                                '����
                                DB_OPEN("nMVAR")
                                WK_DsList2.Clear()
                                strSQL = "SELECT rcpt_no, cls"
                                strSQL = strSQL & " FROM T10_SALS"
                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                strSQL = strSQL & " AND (cls = '4')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                r2 = DaList1.Fill(WK_DsList2, "T10_SALS")

                                If IsDate(csv(22)) = True Then
                                    If r2 = 0 Then
                                        strSQL = "INSERT INTO T10_SALS"
                                        strSQL = strSQL & " (rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2"
                                        strSQL = strSQL & ", neva_chek_date, neva_chek_date2, neva_chek_list, invc_cls_date, invc_flg)"
                                        strSQL = strSQL & " VALUES ('" & WK_DtView1(0)("rcpt_no") & "'"
                                        strSQL = strSQL & ", '4'"
                                        strSQL = strSQL & ", " & sum_eu_ttl
                                        strSQL = strSQL & ", " & sum_eu_tax
                                        strSQL = strSQL & ", 0"
                                        strSQL = strSQL & ", 0"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", 0)"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()
                                    Else
                                        'upfate
                                        strSQL = "UPDATE T10_SALS"
                                        strSQL = strSQL & " SET sals_amnt = " & sum_eu_ttl
                                        strSQL = strSQL & ", sals_tax = " & sum_eu_tax
                                        strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                        strSQL = strSQL & " AND (cls = '4')"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()
                                    End If
                                Else
                                    If r2 <> 0 Then
                                        'delete
                                        strSQL = "DELETE FROM T10_SALS"
                                        strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                        strSQL = strSQL & " AND (cls = '4')"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()
                                    End If
                                End If

                                'CSV�X�V
                                strSQL = "INSERT INTO T50_AI_CSV (imp_date, seq, rcpt_no)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & date_now & "', 102)"
                                strSQL = strSQL & ", 1"
                                strSQL = strSQL & ", '" & WK_DtView1(0)("rcpt_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()

                                '�����X�V
                                strSQL = "INSERT INTO L01_HSTY"
                                strSQL = strSQL & " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & Now & "', 102)"
                                strSQL = strSQL & ", " & P_EMPL_NO
                                strSQL = strSQL & ", '" & WK_DtView1(0)("rcpt_no") & "'"
                                strSQL = strSQL & ", 'Ai�捞�ݏC��'"
                                strSQL = strSQL & ", ''"
                                strSQL = strSQL & ", '')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                            End If
                        End If
                        cnt = cnt + 1
                    Next row
                End If
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���

                Call CSV_output()   'CSV�o��

                MessageBox.Show("�捞����", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        End With
    End Sub

    Sub CSV_output()    'CSV�o��

        WK_DsList3.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_Ai_CSV", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = Format(date_now, "yyyy/MM/dd HH:mm:ss")
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(WK_DsList3, "WK_Print01")
        DB_CLOSE()

        Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
        sfd.FileName = "Ai�捞�ݖ���" & Format(Now, "yyyyMMddHHmmss") & ".CSV" '�͂��߂̃t�@�C�������w�肷��
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
            strData = "�`�[�ԍ�,�v��QG,��t���,���׋敪�R�[�h,���׋敪��,�O���[�v�R�[�h,�O���[�v��,�掟�X�R�[�h,�掟�X��"
            strData = strData & ",�̎Г`��,������R�[�h,�����於,���q�l��,��t�N����,�C��������,�����,�������t,���ϓ��t"
            strData = strData & ",�񓚎�M��,���i������,���i��̓�"
            strData = strData & ",���Ϗ����z,�Ј��R�[�h,�C���S���Җ�,���[�J�[�R�[�h,���[�J�[��,���f��,�@��,�����ԍ�,�ۏ؏��,�ۏ؏��"
            strData = strData & ",���i�ԍ�1,���i��1,����1,�R�X�g1,�v��z1,EU�z1"
            strData = strData & ",���i�ԍ�2,���i��2,����2,�R�X�g2,�v��z2,EU�z2"
            strData = strData & ",���i�ԍ�3,���i��3,����3,�R�X�g3,�v��z3,EU�z3"
            strData = strData & ",���i�ԍ�4,���i��4,����4,�R�X�g4,�v��z4,EU�z4"
            strData = strData & ",���i�ԍ�5,���i��5,����5,�R�X�g5,�v��z5,EU�z5"
            strData = strData & ",���i�ԍ�6,���i��6,����6,�R�X�g6,�v��z6,EU�z6"
            strData = strData & ",���i�ԍ�7,���i��7,����7,�R�X�g7,�v��z7,EU�z7"
            strData = strData & ",���i�ԍ�8,���i��8,����8,�R�X�g8,�v��z8,EU�z8"
            strData = strData & ",���i��,APSE,�Z�p��,���̑�,����,���v,�����,���v,�̎Ѓ��x�[�g,���ȕ��S��,QG-Care�ۏ͈ؔ�"
            strData = strData & ",�C�����,��t�p�f,\0���R,�l�o�`�ԍ�,�l�o�`�ԍ��i���x�[�g�j,�ԓ`����t�ԍ�,�I���W�i�����[�J�[�R�[�h"
            strData = strData & ",�\���Ǐ�,�C�����e,QG-Care�ԍ�,Note,�����R�����g,Mobile���,���W�ԍ�,�o�^QG,iMVAR�Ǘ��ԍ�,��t�R�����g"
            swFile.WriteLine(strData)

            DtView1 = New DataView(WK_DsList3.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strData = DtView1(i)("rcpt_no")                         '�`�[�ԍ�
                strData = strData & "," & DtView1(i)("kjo_brch_name")   '�v��QG
                strData = strData & "," & DtView1(i)("rcpt_name")       '��t���
                strData = strData & "," & DtView1(i)("arvl_cls")        '���׋敪�R�[�h
                strData = strData & "," & DtView1(i)("arvl_name")       '���׋敪��
                strData = strData & "," & DtView1(i)("grup_code")       '�O���[�v�R�[�h
                strData = strData & "," & DtView1(i)("grup_name")       '�O���[�v��
                strData = strData & "," & DtView1(i)("store_code")      '�掟�X�R�[�h
                strData = strData & "," & DtView1(i)("store_name")      '�掟�X��
                strData = strData & "," & DtView1(i)("store_repr_no")   '�̎Г`��
                strData = strData & "," & DtView1(i)("invc_code")       '������R�[�h
                strData = strData & "," & DtView1(i)("invc_name")       '�����於
                strData = strData & "," & DtView1(i)("user_name")       '���q�l��
                strData = strData & "," & DtView1(i)("accp_date")       '��t�N����
                strData = strData & "," & DtView1(i)("comp_date")       '�C��������
                strData = strData & "," & DtView1(i)("sals_date")       '�����
                strData = strData & "," & DtView1(i)("clct_date")       '�������t
                strData = strData & "," & DtView1(i)("etmt_date")       '���ϓ��t
                strData = strData & "," & DtView1(i)("rsrv_cacl_date")  '�񓚎�M��
                strData = strData & "," & DtView1(i)("part_ordr_date")  '���i������
                strData = strData & "," & DtView1(i)("part_rcpt_date")  '���i��̓�
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                strData = strData & "," & WK_AMT                        '���Ϗ����z
                strData = strData & "," & DtView1(i)("repr_empl_code")  '�Ј��R�[�h
                strData = strData & "," & DtView1(i)("repr_empl_name")  '�C���S���Җ�
                strData = strData & "," & DtView1(i)("vndr_code")       '���[�J�[�R�[�h
                strData = strData & "," & DtView1(i)("vndr_name")       '���[�J�[��
                WK_str = New_Line_Cng(comma_Cng(DtView1(i)("model_1")))
                'WK_str = Replace(DtView1(i)("model_1"), ",", " ")
                strData = strData & "," & WK_str                        '���f��
                WK_str = New_Line_Cng(comma_Cng(DtView1(i)("model_2")))
                strData = strData & "," & WK_str                        '�@��
                WK_str = New_Line_Cng(comma_Cng(DtView1(i)("s_n")))
                strData = strData & "," & WK_str                        '�����ԍ�
                strData = strData & "," & DtView1(i)("rpar_cls")        '�ۏ؏��
                strData = strData & "," & DtView1(i)("rpar_name")       '�ۏ؏��

                '���i���
                WK_AMT2 = 0 : WK_AMT3 = 0 : WK_AMT4 = 0 : WK_AMT5 = 0
                WK_DsList1.Clear()
                SqlCmd1 = New SqlClient.SqlCommand("sp_F40_05_2", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                Pram2.Value = DtView1(i)("rcpt_no")
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T04_REP_PART")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    For j = 0 To WK_DtView1.Count - 1
                        Select Case j
                            Case Is < 7
                                WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_code")))
                                strData = strData & "," & WK_str                                    '���i�ԍ�
                                WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_name")))
                                strData = strData & "," & WK_str                                    '���i��
                                strData = strData & "," & WK_DtView1(j)("use_qty")                  '����
                                strData = strData & "," & WK_DtView1(j)("cost_chrg")                '�R�X�g
                                strData = strData & "," & WK_DtView1(j)("shop_chrg")                '�v��z
                                strData = strData & "," & WK_DtView1(j)("eu_chrg")                  'EU�z

                            Case Is = 7
                                If WK_DtView1.Count = 8 Then
                                    WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_code")))
                                    strData = strData & "," & WK_str                                '���i�ԍ�
                                    WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_name")))
                                    strData = strData & "," & WK_str                                '���i��
                                    strData = strData & "," & WK_DtView1(j)("use_qty")              '����
                                    strData = strData & "," & WK_DtView1(j)("cost_chrg")            '�R�X�g
                                    strData = strData & "," & WK_DtView1(j)("shop_chrg")            '�v��z
                                    strData = strData & "," & WK_DtView1(j)("eu_chrg")              'EU�z
                                Else
                                    WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                    WK_AMT3 = WK_AMT3 + WK_DtView1(j)("part_amnt") * WK_DtView1(j)("use_qty")
                                    WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                    WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")
                                End If

                            Case Else
                                WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                WK_AMT3 = WK_AMT3 + WK_DtView1(j)("cost_chrg")
                                WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")

                        End Select
                    Next
                End If

                Select Case WK_DtView1.Count
                    Case Is < 8
                        For j = 1 To 8 - WK_DtView1.Count
                            strData = strData & ",,,,,,"
                        Next
                    Case Is = 8
                    Case Else
                        strData = strData & ","             '���i�ԍ�
                        strData = strData & ",���̑����i"   '���i��
                        strData = strData & "," & WK_AMT2   '����
                        strData = strData & "," & WK_AMT3   '�R�X�g
                        strData = strData & "," & WK_AMT4   '�v��z
                        strData = strData & "," & WK_AMT5   'EU�z
                End Select

                strData = strData & "," & DtView1(i)("comp_shop_part_chrg")     '���i��
                strData = strData & "," & DtView1(i)("comp_shop_apes")          'APSE
                strData = strData & "," & DtView1(i)("comp_shop_tech_chrg")     '�Z�p��
                strData = strData & "," & DtView1(i)("comp_shop_fee")           '���̑�
                strData = strData & "," & DtView1(i)("comp_shop_pstg")          '����
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("comp_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("comp_shop_ttl")
                strData = strData & "," & WK_AMT                                '���v
                If Not IsDBNull(DtView1(i)("comp_shop_tax")) Then
                    strData = strData & "," & DtView1(i)("comp_shop_tax")           '�����
                    strData = strData & "," & WK_AMT + DtView1(i)("comp_shop_tax")  '���v
                Else
                    strData = strData & ",0"                                        '�����
                    strData = strData & "," & WK_AMT                                '���v
                End If
                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData = strData & "," & DtView1(i)("rebate")                  '�̎Ѓ��x�[�g
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData = strData & ",0"
                    Else
                        strData = strData & "," & DtView1(i)("rebate")
                    End If
                End If

                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData = strData & "," & DtView1(i)("sals_amnt")                   '���ȕ��S��
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData = strData & ",0"
                    Else
                        strData = strData & "," & DtView1(i)("sals_amnt")
                    End If
                End If

                WK_str = Nothing
                If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                    WK_DsList1.Clear()
                    strSQL = "SELECT HSY.HSY_name"
                    strSQL = strSQL & " FROM T01_������ LEFT OUTER JOIN"
                    strSQL = strSQL & " (SELECT [�R�[�h] AS HSY_code, ���� AS HSY_name FROM [M_�e�[�u��] WHERE (���� = N'HSY')) HSY ON"
                    strSQL = strSQL & " T01_������.�ۏ͈ؔ� = HSY.HSY_code"
                    strSQL = strSQL & " WHERE (T01_������.�����ԍ� = N'" & DtView1(i)("qg_care_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("QGCare")
                    DaList1.Fill(WK_DsList1, "T01_������")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T01_������"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str = Trim(WK_DtView1(0)("HSY_name"))
                    End If
                End If
                strData = strData & "," & WK_str                                    'QG-Care�ۏ͈ؔ�
                strData = strData & "," & DtView1(i)("rpar_comp_name")              '�C�����
                strData = strData & "," & DtView1(i)("rcpt_brch_name")              '��t�p�f
                If Not IsDBNull(DtView1(i)("zero_name")) Then
                    WK_str = DtView1(i)("zero_name") : WK_str = Replace(WK_str, ",", "�C")
                    strData = strData & "," & WK_str                                '\0���R
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("sals_no")                     '�l�o�`�ԍ�
                strData = strData & "," & DtView1(i)("sals_no2")                    '�l�o�`�ԍ��i���x�[�g�j
                strData = strData & "," & DtView1(i)("rcpt_no_aka")                 '�ԓ`��t�ԍ�
                strData = strData & "," & DtView1(i)("orgnl_vndr_code")             '�I���W�i�����[�J�[�R�[�h
                If Not IsDBNull(DtView1(i)("user_trbl")) Then
                    WK_str = New_Line_Cng(DtView1(i)("user_trbl")) : WK_str = Replace(WK_str, ",", "�C")
                    strData = strData & "," & WK_str                                '�\���Ǐ�
                Else
                    strData = strData & ","
                End If
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_meas")) : WK_str = Replace(WK_str, ",", "�C")
                    strData = strData & "," & WK_str                                '�C�����e
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("qg_care_no")                  'QG-Care�ԍ�
                If IsDBNull(DtView1(i)("note_kbn2")) Then
                    strData = strData & ","                                         'Note
                Else
                    If DtView1(i)("note_kbn2") = "01" Then
                        strData = strData & ",1"
                    Else
                        strData = strData & ","
                    End If
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_comn")) : WK_str = Replace(WK_str, ",", "�C")
                    strData = strData & "," & WK_str                                    '�����R�����g
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("defe_name")                       'Mobile��ʁiCLS�F035�j
                strData = strData & "," & DtView1(i)("reference_no")                    '���W�ԍ�
                If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then
                    strData = strData & "," & Mid(DtView1(i)("imv_rcpt_no"), 1, 2)      '�o�^QG
                    strData = strData & "," & Mid(DtView1(i)("imv_rcpt_no"), 3, 7)      'iMVAR�Ǘ��ԍ�
                Else
                    strData = strData & ",,"
                End If
                WK_str = New_Line_Cng(DtView1(i)("rcpt_comn")) : WK_str = Replace(WK_str, ",", "�C")
                strData = strData & "," & WK_str                                        '��t�R�����g

                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)
            Next
            swFile.Close()          '�t�@�C�������
            waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
            Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
        End If

    End Sub

    '********************************************************************
    '**  ����E�I���{�^��
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        Application.Exit()
    End Sub
End Class
