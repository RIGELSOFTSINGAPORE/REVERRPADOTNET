Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strData As String
    Dim i, j, r, r2, seq As Integer
    Dim WK_AMT As Integer
    Dim WK_str, WK_str2, Br_rcpt_no As String
    Dim fr_date, to_date As Date

    Dim strFile, filename As String

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(240, 117)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC START", "�I�[�r�b�N�p�f�[�^���o�͂��J�n���܂��B", System.Diagnostics.EventLogEntryType.Information)
        If DB_INIT() = "1" Then Application.Exit() : Exit Sub

        Call ds_set()  '** �f�[�^�Z�b�g
        Call csv_out()  '** CSV�o��

        '60�b�ԁi60000�~���b�j��~����
        System.Threading.Thread.Sleep(60000)

        Call FTP_up()   '** CSV�f�[�^�A�b�v���[�h

        '60�b�ԁi60000�~���b�j��~����
        System.Threading.Thread.Sleep(60000)

        '̧�وړ�
        For Each strFile In System.IO.Directory.GetFiles(dl_fldr, "*.csv")
            filename = strFile.Substring(strFile.LastIndexOf("\") + 1).ToUpper
            Dim csvFileName As String = filename.ToUpper
            Dim WK_date As String = Format(Now, "yyyyMMddhhmm") & ".csv"
            Dim logFileName As String = filename.Replace(".CSV", WK_date)
            System.IO.File.Move(dl_fldr & "\" & csvFileName, log_fldr & "\" & logFileName)
        Next

        System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC END", "�I�[�r�b�N�p�f�[�^���o�͂��I�����܂��B", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

    '******************************************************************
    '** �f�[�^�Z�b�g
    '******************************************************************
    Sub ds_set()
        WK_DsList1.Clear()
        strSQL = "SELECT cls_code_name, cls_code_name_abbr FROM V_cls_053"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "cls_053")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("cls_053"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then strFile = Trim(WK_DtView1(0)("cls_code_name")) & "\" & Trim(WK_DtView1(0)("cls_code_name_abbr"))
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then dl_fldr = Trim(WK_DtView1(0)("cls_code_name"))
            log_fldr = dl_fldr & "\log"
        End If
    End Sub

    '******************************************************************
    '** CSV�o��
    '******************************************************************
    Sub csv_out()
        '���s���Ԃ��[��0���̑O��Œ��o�������ς��
        Dim WK_HH As String = Format(Now, "HH")
        fr_date = Format(Now.Date, "yyyy/MM" & "/01")
        If WK_HH < "12" Then
            to_date = Now.Date
        Else
            to_date = DateAdd(DateInterval.Day, 1, Now.Date)
        End If

        'fr_date = "2020/01/08"
        'to_date = "2020/01/09"

        'DataTable�쐬()
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_15", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = fr_date
        Pram2.Value = to_date
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "WK_Print01")
        DB_CLOSE()

        If r <> 0 Then

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

            '�f�[�^����������
            strData = "�`�[�ԍ�,�s�ԍ�,�v��QG�R�[�h,�v��QG,��t��ʃR�[�h,��t���,���׋敪�R�[�h,���׋敪��,�O���[�v�R�[�h,�O���[�v��,�掟�X�R�[�h"
            strData += ",�掟�X��,�̎Г`��,������R�[�h,�����於,���q�l��,���̓�,�C��������,�����,�������t,���ϓ��t,�񓚎�M��,���i������"
            strData += ",���i��̓�,���Ϗ����z,�Ј��R�[�h,�C���S���Җ�,���[�J�[�R�[�h,���[�J�[��,���f��,�@��,�����ԍ�,�ۏ؏��,�ۏ؏��,���i�ԍ�"
            strData += ",���i��,���i����,���i�R�X�g,���i�v��z,���iEU�z,���i��,APSE,�Z�p��,���̑�,����,���v,�����,���v,�a���,�̎Ѓ��x�[�g"
            strData += ",���ȕ��S��,QG-Care�ۏ͈ؔ̓R�[�h,QG-Care�ۏ͈ؔ�,�C�����,��t�p�f,�[���~���R,�l�o�`�ԍ�,�l�o�`�ԍ��i���x�[�g�j,�ԓ`����t�ԍ�"
            strData += ",�I���W�i�����[�J�[�R�[�h,�\���Ǐ�,�C�����e,QG-Care�ԍ�,Note,�����R�����g,Mobile���,���W�ԍ�,�o�^QG,iMVAR�Ǘ��ԍ�"
            strData += ",��t�R�����g,SB/IMEI�ԍ�,SB/�VIMEI�ԍ�,������ʃR�[�h,�������"
            swFile.WriteLine(strData)

            DtView1 = New DataView(DsList1.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                If Br_rcpt_no = DtView1(i)("rcpt_no") Then
                    seq = seq + 1
                Else
                    Br_rcpt_no = DtView1(i)("rcpt_no")
                    seq = 1
                End If

                strData = Chr(34) & DtView1(i)("rcpt_no") & Chr(34)                             '�`�[�ԍ�
                strData += "," & Chr(34) & seq & Chr(34)                                        '�s�ԍ�
                strData += "," & Chr(34) & DtView1(i)("kjo_brch_code") & Chr(34)                '�v��QG�R�[�h
                strData += "," & Chr(34) & DtView1(i)("kjo_brch_name") & Chr(34)                '�v��QG
                strData += "," & Chr(34) & DtView1(i)("rcpt_cls") & Chr(34)                     '��t��ʃR�[�h
                strData += "," & Chr(34) & DtView1(i)("rcpt_name") & Chr(34)                    '��t���
                strData += "," & Chr(34) & DtView1(i)("arvl_cls") & Chr(34)                     '���׋敪�R�[�h
                strData += "," & Chr(34) & DtView1(i)("arvl_name") & Chr(34)                    '���׋敪��
                strData += "," & Chr(34) & DtView1(i)("grup_code") & Chr(34)                    '�O���[�v�R�[�h
                strData += "," & Chr(34) & DtView1(i)("grup_name") & Chr(34)                    '�O���[�v��
                strData += "," & Chr(34) & DtView1(i)("store_code") & Chr(34)                   '�掟�X�R�[�h
                strData += "," & Chr(34) & DtView1(i)("store_name") & Chr(34)                   '�掟�X��
                strData += "," & Chr(34) & DtView1(i)("store_repr_no") & Chr(34)                '�̎Г`��
                strData += "," & Chr(34) & DtView1(i)("invc_code") & Chr(34)                    '������R�[�h
                strData += "," & Chr(34) & DtView1(i)("invc_name") & Chr(34)                    '�����於
                strData += "," & Chr(34) & DQM_Cng(DtView1(i)("user_name")) & Chr(34)           '���q�l��
                strData += "," & Chr(34) & DtView1(i)("accp_date") & Chr(34)                    '���̓�//Edited by ram acdt_date to accp_date
                strData += "," & Chr(34) & DtView1(i)("comp_date") & Chr(34)                    '�C��������
                strData += "," & Chr(34) & DtView1(i)("sals_date") & Chr(34)                    '�����
                strData += "," & Chr(34) & DtView1(i)("clct_date") & Chr(34)                    '�������t
                strData += "," & Chr(34) & DtView1(i)("etmt_date") & Chr(34)                    '���ϓ��t
                strData += "," & Chr(34) & DtView1(i)("rsrv_cacl_date") & Chr(34)               '�񓚎�M��
                strData += "," & Chr(34) & DtView1(i)("part_ordr_date") & Chr(34)               '���i������
                strData += "," & Chr(34) & DtView1(i)("part_rcpt_date") & Chr(34)               '���i��̓�
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                strData += "," & Chr(34) & WK_AMT & Chr(34)                                     '���Ϗ����z
                strData += "," & Chr(34) & DtView1(i)("repr_empl_code") & Chr(34)               '�Ј��R�[�h
                strData += "," & Chr(34) & DtView1(i)("repr_empl_name") & Chr(34)               '�C���S���Җ�
                strData += "," & Chr(34) & DtView1(i)("vndr_code") & Chr(34)                    '���[�J�[�R�[�h
                strData += "," & Chr(34) & DtView1(i)("vndr_name") & Chr(34)                    '���[�J�[��
                WK_str = New_Line_Cng(DtView1(i)("model_1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '���f��
                WK_str = New_Line_Cng(DtView1(i)("model_2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '�@��
                WK_str = New_Line_Cng(DtView1(i)("s_n"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '�����ԍ�
                strData += "," & Chr(34) & DtView1(i)("rpar_cls") & Chr(34)                     '�ۏ؏��
                strData += "," & Chr(34) & DtView1(i)("rpar_name") & Chr(34)                    '�ۏ؏��
                If Not IsDBNull(DtView1(i)("part_code")) Then
                    WK_str = New_Line_Cng(DtView1(i)("part_code"))
                    strData += "," & Chr(34) & WK_str & Chr(34)                                 '���i�ԍ�
                    WK_str = New_Line_Cng(DtView1(i)("part_name"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '���i��
                    strData += "," & Chr(34) & DtView1(i)("use_qty") & Chr(34)                  '���i����
                    strData += "," & Chr(34) & DtView1(i)("cost_chrg") & Chr(34)                '���i�R�X�g
                    strData += "," & Chr(34) & DtView1(i)("shop_chrg") & Chr(34)                '���i�v��z
                    strData += "," & Chr(34) & DtView1(i)("eu_chrg") & Chr(34)                  '���iEU�z
                Else
                    strData += "," & Chr(34) & Chr(34)                                          '���i�ԍ�
                    strData += "," & Chr(34) & Chr(34)                                          '���i��
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '���i����
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '���i�R�X�g
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '���i�v��z
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '���iEU�z
                End If
                strData += "," & Chr(34) & DtView1(i)("comp_shop_part_chrg") & Chr(34)          '���i��
                strData += "," & Chr(34) & DtView1(i)("comp_shop_apes") & Chr(34)               'APSE
                strData += "," & Chr(34) & DtView1(i)("comp_shop_tech_chrg") & Chr(34)          '�Z�p��
                strData += "," & Chr(34) & DtView1(i)("comp_shop_fee") & Chr(34)                '���̑�
                strData += "," & Chr(34) & DtView1(i)("comp_shop_pstg") & Chr(34)               '����
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("comp_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("comp_shop_ttl")
                strData += "," & Chr(34) & WK_AMT & Chr(34)                                     '���v
                If Not IsDBNull(DtView1(i)("comp_shop_tax")) Then
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_tax") & Chr(34)            '�����
                    strData += "," & Chr(34) & WK_AMT + DtView1(i)("comp_shop_tax") & Chr(34)   '���v
                Else
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '�����
                    strData += "," & Chr(34) & WK_AMT & Chr(34)                                 '���v
                End If
                strData += "," & Chr(34) & DtView1(i)("recv_amnt") & Chr(34)                    '�a���
                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)                   '�̎Ѓ��x�[�g
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData += "," & Chr(34) & "0" & Chr(34)
                    Else
                        strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)
                    End If
                End If
                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)                '���ȕ��S��
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData += "," & Chr(34) & "0" & Chr(34)
                    Else
                        strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)
                    End If
                End If

                WK_str = Nothing : WK_str2 = Nothing
                If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                    WK_DsList1.Clear()
                    strSQL = "SELECT T01_member.wrn_range, V_M02_HSY.cls_code_name AS HSY_name"
                    strSQL += " FROM T01_member INNER JOIN"
                    strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                    strSQL += " WHERE (T01_member.code = '" & DtView1(i)("qg_care_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("QGCare")
                    DaList1.Fill(WK_DsList1, "T01_member")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        If Not IsDBNull(WK_DtView1(0)("wrn_range")) Then WK_str = Trim(WK_DtView1(0)("wrn_range"))
                        If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str2 = Trim(WK_DtView1(0)("HSY_name"))
                    End If
                End If
                strData += "," & Chr(34) & WK_str & Chr(34)                                     'QG-Care�ۏ͈ؔ̓R�[�h
                strData += "," & Chr(34) & WK_str2 & Chr(34)                                    'QG-Care�ۏ͈ؔ�

                strData += "," & Chr(34) & DtView1(i)("rpar_comp_name") & Chr(34)               '�C�����
                strData += "," & Chr(34) & DtView1(i)("rcpt_brch_name") & Chr(34)               '��t�p�f
                If Not IsDBNull(DtView1(i)("zero_name")) Then
                    WK_str = DtView1(i)("zero_name")
                    strData += "," & Chr(34) & WK_str & Chr(34)                                 '\0���R
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("sals_no") & Chr(34)                      '�l�o�`�ԍ�
                strData += "," & Chr(34) & DtView1(i)("sals_no2") & Chr(34)                     '�l�o�`�ԍ��i���x�[�g�j
                strData += "," & Chr(34) & DtView1(i)("rcpt_no_aka") & Chr(34)                  '�ԓ`��t�ԍ�
                strData += "," & Chr(34) & DtView1(i)("orgnl_vndr_code") & Chr(34)              '�I���W�i�����[�J�[�R�[�h
                If Not IsDBNull(DtView1(i)("user_trbl")) Then
                    WK_str = New_Line_Cng(DtView1(i)("user_trbl"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '�\���Ǐ�
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_meas"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '�C�����e
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & DtView1(i)("qg_care_no")                                       'QG-Care�ԍ�
                If IsDBNull(DtView1(i)("note_kbn2")) Then
                    strData += "," & Chr(34) & Chr(34)                                          'Note
                Else
                    If DtView1(i)("note_kbn2") = "01" Then
                        strData += "," & Chr(34) & "1" & Chr(34)
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_comn"))
                    strData += "," & Chr(34) & WK_str & Chr(34)                                 '�����R�����g
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("defe_name") & Chr(34)                    'Mobile��ʁiCLS�F035�j
                strData += "," & Chr(34) & DtView1(i)("reference_no") & Chr(34)                 '���W�ԍ�
                If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then
                    strData += "," & Chr(34) & Mid(DtView1(i)("imv_rcpt_no"), 1, 2) & Chr(34)   '�o�^QG
                    strData += "," & Chr(34) & DtView1(i)("imv_rcpt_no") & Chr(34)              'iMVAR�Ǘ��ԍ�
                Else
                    strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                End If
                WK_str = New_Line_Cng(DtView1(i)("rcpt_comn"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '��t�R�����g
                strData += "," & Chr(34) & DtView1(i)("sb_imei_old") & Chr(34)                  'SB/IMEI�ԍ�
                strData += "," & Chr(34) & DtView1(i)("sb_imei_new") & Chr(34)                  'SB/�VIMEI�ԍ�
                strData += "," & Chr(34) & DtView1(i)("payment_type") & Chr(34)                 '������ʃR�[�h
                strData += "," & Chr(34) & DtView1(i)("payment_type_name") & Chr(34)            '�������

                strData = Replace(strData, System.Environment.NewLine, " ")
                strData = Replace(strData, vbCrLf, " ")
                strData = Replace(strData, vbCr, " ")
                strData = Replace(strData, vbLf, " ")
                swFile.WriteLine(strData)
            Next
            swFile.Close()          '�t�@�C�������
            'System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC " & r & "��", "�I�[�r�b�N�p�f�[�^���o�͂��܂����B" & fr_date & "�`" & DateAdd(DateInterval.Day, -1, to_date), System.Diagnostics.EventLogEntryType.Information)

            DB_OPEN("nMVAR")

            '���M�ϋL�^
            For i = 0 To DtView1.Count - 1
                WK_DsList1.Clear()
                strSQL = "SELECT rcpt_no FROM T_OBIC_SND WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                r2 = DaList1.Fill(WK_DsList1, "T_OBIC_SND")
                If r2 = 0 Then
                    strSQL = "INSERT INTO T_OBIC_SND"
                    strSQL += " (rcpt_no, snd_date)"
                    strSQL += " VALUES ('" & DtView1(i)("rcpt_no") & "'"
                    strSQL += ", CONVERT(DATETIME, '" & Now & "', 102))"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If
            Next
            DB_CLOSE()
            'System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC UPD", "�I�[�r�b�N�p�f�[�^�𑗐M�ύX�V", System.Diagnostics.EventLogEntryType.Information)

        End If
        DsList1.Clear()
        WK_DsList1.Clear()

    End Sub
End Class
