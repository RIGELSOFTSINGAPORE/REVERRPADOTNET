Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F, strDATA As String
    Dim strcurdir As String
    Dim i As Integer

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
        Me.ClientSize = New System.Drawing.Size(292, 53)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("QA_export_START", "", System.Diagnostics.EventLogEntryType.Information)
        Call inz()      '** ��������
        Call ds_set()  '** �f�[�^�Z�b�g
        DsList1.Clear()

        Call stts_20()  '** 20:���ב҂��f�[�^���o
        Call stts_30()  '** 30:���ׂ���i�\�����Ȃ��j�f�[�^���o
        Call stts_40()  '** 40:��t�f�[�^���o
        Call stts_60()  '** 60:���ς��茋�ʃf�[�^���o
        Call stts_80()  '** 80:�C���s�f�[�^���o
        Call stts_90()  '** 90:�C�������f�[�^���o
        Call stts_110() '** 110:�o�׃f�[�^���o
        Call stts_130() '** 130:�j�������f�[�^���o

        Call csv_out()  '** CSV�o��

        '60�b�ԁi60000�~���b�j��~����
        System.Threading.Thread.Sleep(60000)

        Call FTP_up()   '** CSV�f�[�^�A�b�v���[�h

        '60�b�ԁi60000�~���b�j��~����
        System.Threading.Thread.Sleep(60000)

        '̧�وړ�
        For Each strFile In System.IO.Directory.GetFiles(dl_fldr, "*.csv")
            filename = strFile.Substring(strFile.LastIndexOf("\") + 1)
            Dim csvFileName As String = filename '"test.csv"
            System.IO.File.Move(dl_fldr & "\" & csvFileName, log_fldr & "\" & csvFileName)
        Next

        System.Diagnostics.EventLog.WriteEntry("QA_export_END", "", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

    '******************************************************************
    '** ��������
    '******************************************************************
    Sub inz()
        Call DB_INIT()
        strcurdir = System.IO.Directory.GetCurrentDirectory                                 '���s�t�H���_�[
        Err_F = "0"
    End Sub

    '******************************************************************
    '** �f�[�^�Z�b�g
    '******************************************************************
    Sub ds_set()
        DsList1.Clear()

        strSQL = "SELECT * FROM QA_ftp_ini"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "QA_ftp_ini")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("QA_ftp_ini"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            dl_fldr = DtView1(0)("dl_fldr_SND")
            If System.IO.Directory.Exists(dl_fldr) = False Then       '���M�t�H���_�@������΍쐬����
                System.IO.Directory.CreateDirectory(dl_fldr)
            End If

            log_fldr = DtView1(0)("log_fldr_SND")
            If System.IO.Directory.Exists(log_fldr) = False Then       '���M�t�H���_�@������΍쐬����
                System.IO.Directory.CreateDirectory(log_fldr)
            End If
        Else
            'msg.Text = "�e�s�o�ݒ�t�@�C�����ݒ�"
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '******************************************************************
    '** 20:���ב҂��f�[�^���o
    '******************************************************************
    Sub stts_20()
        If Format(Now, "HH") = "17" Then
            DB_OPEN()

            strSQL = "SELECT QA02_data.*"
            strSQL += " FROM QA02_data"
            strSQL += " WHERE (snd_flg = 1)"
            strSQL += " AND (stts = N'20')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "Qsnd_csv")

            DB_CLOSE()
        End If
    End Sub

    '******************************************************************
    '** 30:���ׂ���i�\�����Ȃ��j�f�[�^���o
    '******************************************************************
    Sub stts_30()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'30')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 40:��t�f�[�^���o
    '******************************************************************
    Sub stts_40()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'40')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 60:���ς��茋�ʃf�[�^���o
    '******************************************************************
    Sub stts_60()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'60')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 80:�C���s�f�[�^���o
    '******************************************************************
    Sub stts_80()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'80')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 90:�C�������f�[�^���o
    '******************************************************************
    Sub stts_90()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'90')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 110:�o�׃f�[�^���o
    '******************************************************************
    Sub stts_110()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'110')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 130:�j�������f�[�^���o
    '******************************************************************
    Sub stts_130()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'130')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** CSV�o��
    '******************************************************************
    Sub csv_out()
        DB_OPEN()
        DtView1 = New DataView(DsList1.Tables("Qsnd_csv"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim swFile As New System.IO.StreamWriter(dl_fldr & "\DP001A_" & Format(Now, "yyyyMMddHHmm") & ".csv", False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

            '�f�[�^����������
            strDATA = Chr(34) & "�Č��敪" & Chr(34) & "," & Chr(34) & "QAC�Ǘ��ԍ�" & Chr(34) & "," & Chr(34) & "�i�s�X�e�[�^�X"
            strDATA += Chr(34) & "," & Chr(34) & "���q�l����" & Chr(34) & "," & Chr(34) & "���q�l�����J�i"
            strDATA += Chr(34) & "," & Chr(34) & "�X�֔ԍ�" & Chr(34) & "," & Chr(34) & "�Z��1" & Chr(34) & "," & Chr(34) & "�Z��2"
            strDATA += Chr(34) & "," & Chr(34) & "�Z��3" & Chr(34) & "," & Chr(34) & "�d�b�ԍ�_����"
            strDATA += Chr(34) & "," & Chr(34) & "�d�b�ԍ�_�g��" & Chr(34) & "," & Chr(34) & "�C����z��"
            strDATA += Chr(34) & "," & Chr(34) & "���[�J�[��" & Chr(34) & "," & Chr(34) & "�@�햼"
            strDATA += Chr(34) & "," & Chr(34) & "���i�o�ד�" & Chr(34) & "," & Chr(34) & "�̏᎖�R"
            strDATA += Chr(34) & "," & Chr(34) & "�̏�Ǐ�" & Chr(34) & "," & Chr(34) & "���l" & Chr(34) & "," & Chr(34) & "�����i�s"
            strDATA += Chr(34) & "," & Chr(34) & "������z" & Chr(34) & "," & Chr(34) & "GSS�`�[�ԍ�"
            strDATA += Chr(34) & "," & Chr(34) & "�C���敪" & Chr(34) & "," & Chr(34) & "���[�J�[��"
            strDATA += Chr(34) & "," & Chr(34) & "�̏��" & Chr(34) & "," & Chr(34) & "���i��" & Chr(34) & "," & Chr(34) & "���i���i"
            strDATA += Chr(34) & "," & Chr(34) & "���ϗ�" & Chr(34) & "," & Chr(34) & "�Z�p��" & Chr(34) & "," & Chr(34) & "���[�J�掟�萔��"
            strDATA += Chr(34) & "," & Chr(34) & "����" & Chr(34) & "," & Chr(34) & "����萔��" & Chr(34) & "," & Chr(34) & "�L�����Z����"
            strDATA += Chr(34) & "," & Chr(34) & "���v�z" & Chr(34) & "," & Chr(34) & "������" & Chr(34) & "," & Chr(34) & "�z���`�[�ԍ�"
            strDATA += Chr(34) & "," & Chr(34) & "GSS���l" & Chr(34) & "," & Chr(34) & "�C�������\���"
            strDATA += Chr(34) & "," & Chr(34) & "�p����" & Chr(34)
            swFile.WriteLine(strDATA)

            For i = 0 To DtView1.Count - 1
                strDATA = Chr(34) & DtView1(i)("kbn") & Chr(34)                     '�Č��敪
                strDATA += "," & Chr(34) & DtView1(i)("qac_no") & Chr(34)           'QAC�Ǘ��ԍ�
                strDATA += "," & Chr(34) & DtView1(i)("stts") & Chr(34)             '�i�s�X�e�[�^�X
                strDATA += "," & Chr(34) & DtView1(i)("user_name") & Chr(34)        '���q�l�w��
                strDATA += "," & Chr(34) & DtView1(i)("user_kana") & Chr(34)        '���q�l�w���J�i
                strDATA += "," & Chr(34) & DtView1(i)("zip") & Chr(34)              '�X�֔ԍ�
                strDATA += "," & Chr(34) & DtView1(i)("adrs1") & Chr(34)            '�Z��1
                strDATA += "," & Chr(34) & DtView1(i)("adrs2") & Chr(34)            '�Z��2
                strDATA += "," & Chr(34) & DtView1(i)("adrs3") & Chr(34)            '�Z��3
                strDATA += "," & Chr(34) & DtView1(i)("tel") & Chr(34)              '�d�b�ԍ��i����j
                strDATA += "," & Chr(34) & DtView1(i)("tel2") & Chr(34)             '�d�b�ԍ��i�g�сj
                strDATA += "," & Chr(34) & DtView1(i)("tehai_date") & Chr(34)       '�C����z��
                strDATA += "," & Chr(34) & DtView1(i)("maker_name") & Chr(34)       '���[�J�[��
                strDATA += "," & Chr(34) & DtView1(i)("model_name") & Chr(34)       '�@�햼
                strDATA += "," & Chr(34) & DtView1(i)("ship_date") & Chr(34)        '���i�o�ד�
                strDATA += "," & Chr(34) & DtView1(i)("trouble_reason") & Chr(34)   '�̏᎖�R
                strDATA += "," & Chr(34) & DtView1(i)("trouble_symptom") & Chr(34)  '�̏�Ǐ�
                strDATA += "," & Chr(34) & DtView1(i)("remark") & Chr(34)           '���l
                strDATA += "," & Chr(34) & DtView1(i)("auto_shinkou") & Chr(34)     '�����i�s
                strDATA += "," & Chr(34) & DtView1(i)("daibiki") & Chr(34)          '������z
                strDATA += "," & Chr(34) & DtView1(i)("gss_rcpt_no") & Chr(34)      'GSS�`�[�ԍ�
                strDATA += "," & Chr(34) & DtView1(i)("repr_post") & Chr(34)        '�C���敪�i1:���� 2:���Ёj
                strDATA += "," & Chr(34) & DtView1(i)("repr_maker_name") & Chr(34)  '�C�����[�J�[��
                strDATA += "," & Chr(34) & DtView1(i)("trouble_point") & Chr(34)    '�̏��
                strDATA += "," & Chr(34) & DtView1(i)("parts_name") & Chr(34)       '���i��
                strDATA += "," & Chr(34) & DtView1(i)("parts_amnt") & Chr(34)       '���i���i
                strDATA += "," & Chr(34) & DtView1(i)("etmt_amnt") & Chr(34)        '���ϗ�
                strDATA += "," & Chr(34) & DtView1(i)("tech_amnt") & Chr(34)        '�Z�p��
                strDATA += "," & Chr(34) & DtView1(i)("maker_fee") & Chr(34)        '���[�J�[�掟�萔��
                strDATA += "," & Chr(34) & DtView1(i)("pstg") & Chr(34)             '����
                strDATA += "," & Chr(34) & DtView1(i)("daibiki_fee") & Chr(34)      '����萔��
                strDATA += "," & Chr(34) & DtView1(i)("cxl_amnt") & Chr(34)         '�L�����Z����
                strDATA += "," & Chr(34) & DtView1(i)("ttl_amnt") & Chr(34)         '���v�z
                strDATA += "," & Chr(34) & DtView1(i)("haso_date") & Chr(34)        '������
                strDATA += "," & Chr(34) & DtView1(i)("haiso_den_no") & Chr(34)     '�z���`�[�ԍ�
                strDATA += "," & Chr(34) & DtView1(i)("gss_remark") & Chr(34)       'GSS���l
                strDATA += "," & Chr(34) & DtView1(i)("comp_plan_date") & Chr(34)   '�C�������\���
                strDATA += "," & Chr(34) & DtView1(i)("disposal_date") & Chr(34)    '�p����
                swFile.WriteLine(strDATA)

                If DtView1(i)("stts") <> "20" Then    '���ב҂��ȊO�͑��M�t���OOFF
                    strSQL = "UPDATE QA02_data SET snd_flg = 0 WHERE (id = " & DtView1(i)("id") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If
            Next
            swFile.Close()          '�t�@�C�������
        End If
        DB_CLOSE()
    End Sub

End Class
