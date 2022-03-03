Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strData, WKstr As String
    Dim i, r As Integer
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
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("nQGCare OBIC START", "�I�[�r�b�N�p�f�[�^���o�͂��J�n���܂��B", System.Diagnostics.EventLogEntryType.Information)
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

        System.Diagnostics.EventLog.WriteEntry("nQGCare OBIC END", "�I�[�r�b�N�p�f�[�^���o�͂��I�����܂��B", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

    '******************************************************************
    '** �f�[�^�Z�b�g
    '******************************************************************
    Sub ds_set()
        WK_DsList1.Clear()
        strSQL = "SELECT cls_code_name FROM M02_cls WHERE (cls = 'OBC')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(WK_DsList1, "cls_OBC")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("cls_OBC"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then strFile = Trim(WK_DtView1(0)("cls_code_name")) & "\" & Trim(WK_DtView1(1)("cls_code_name"))
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then dl_fldr = Trim(WK_DtView1(0)("cls_code_name"))
            log_fldr = dl_fldr & "\log"
        End If
    End Sub

    '******************************************************************
    '** CSV�o��
    '******************************************************************
    Sub csv_out()
        fr_date = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM") & "/01"
        to_date = DateAdd(DateInterval.Month, 1, fr_date)
        'fr_date = "2019/04/01"
        'to_date = "2019/04/10"

        DsList1.Clear()
        strSQL = "SELECT T01_member.code, T01_member.user_name, T01_member.use_name_kana, T01_member.zip, T01_member.adrs1"
        strSQL += ", T01_member.adrs2, T01_member.tel, M01_univ.univ_name, T01_member.dpmt_name, T01_member.sbjt_name"
        strSQL += ", T01_member.makr_code, M05_VNDR.name AS makr_name, T01_member.modl_name, T01_member.s_no"
        strSQL += ", T01_member.prch_amnt, V_M02_HSK.cls_code_name AS wrn_tem_name, T01_member.makr_wrn_stat"
        strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name, M04_shop.shop_name, T01_member.wrn_fee"
        strSQL += ", T01_member.Part_date, T01_member.reg_date, M04_shop.ittpan, T02_clct.clct_date"
        strSQL += ", M04_shop.shop_shop_code, M04_shop.ivc_old_flg, T01_member.wrn_range"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
        strSQL += " T02_clct ON T01_member.code = T02_clct.code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code"
        strSQL += " WHERE (T01_member.delt_flg = 0)"
        strSQL += " AND (M04_shop.ittpan = 0)"
        strSQL += " AND (T01_member.wrn_range <> 7)"
        strSQL += " AND (T01_member.wrn_range <> 10)"
        strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & fr_date & "', 102))"
        strSQL += " AND (T01_member.reg_date < CONVERT(DATETIME, '" & to_date & "', 102))"
        'strSQL += " AND (T02_clct.clct_date >= CONVERT(DATETIME, '" & fr_date & "', 102))"
        'strSQL += " AND (T02_clct.clct_date <= CONVERT(DATETIME, '" & to_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T01_member")
        DB_CLOSE()

        If r <> 0 Then

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

            '�f�[�^����������
            strData = "�����ԍ�,����,�����J�i,�X�֔ԍ�,�Z���P,�Z���Q,�d�b�ԍ�,��w��,�w����,�w�Ȗ�"
            strData = strData & ",���[�J�[�R�[�h,���[�J�[��,���f����,S/N,�w�����z,�ۏ؊���,���[�J�[�ۏ؊J�n"
            strData = strData & ",�ۏ͈ؔ̓R�[�h,�ۏ͈͖ؔ�,�̔��X,�ی���,������,�o�^���t,Coop,�X�܃R�[�h,��������,�ō��g��,�ۏ؊J�n��"
            swFile.WriteLine(strData)

            Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                strData = DtView1(i)("code")                            '�����ԍ�
                If Not IsDBNull(DtView1(i)("user_name")) Then WKstr = Replace(DtView1(i)("user_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '����
                If Not IsDBNull(DtView1(i)("use_name_kana")) Then WKstr = Replace(DtView1(i)("use_name_kana"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�����J�i
                strData = strData & "," & DtView1(i)("zip")             '�X�֔ԍ�
                If Not IsDBNull(DtView1(i)("adrs1")) Then WKstr = Replace(DtView1(i)("adrs1"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�Z���P
                If Not IsDBNull(DtView1(i)("adrs2")) Then WKstr = Replace(DtView1(i)("adrs2"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�Z���Q
                If Not IsDBNull(DtView1(i)("tel")) Then WKstr = Replace(DtView1(i)("tel"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�d�b�ԍ�
                If Not IsDBNull(DtView1(i)("univ_name")) Then WKstr = Replace(DtView1(i)("univ_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '��w��
                If Not IsDBNull(DtView1(i)("dpmt_name")) Then WKstr = Replace(DtView1(i)("dpmt_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�w����
                If Not IsDBNull(DtView1(i)("sbjt_name")) Then WKstr = Replace(DtView1(i)("sbjt_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�w�Ȗ�
                If Not IsDBNull(DtView1(i)("makr_code")) Then WKstr = Replace(DtView1(i)("makr_code"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '���[�J�[�R�[�h
                If Not IsDBNull(DtView1(i)("makr_name")) Then WKstr = Replace(DtView1(i)("makr_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '���[�J�[��
                If Not IsDBNull(DtView1(i)("modl_name")) Then WKstr = Replace(DtView1(i)("modl_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '���f����
                If Not IsDBNull(DtView1(i)("s_no")) Then WKstr = Replace(DtView1(i)("s_no"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         'S/N
                strData = strData & "," & DtView1(i)("prch_amnt")       '�w�����z
                strData = strData & "," & DtView1(i)("wrn_tem_name")    '�ۏ؊���
                strData = strData & "," & DtView1(i)("makr_wrn_stat")   '���[�J�[�ۏ؊J�n
                strData = strData & "," & DtView1(i)("wrn_range")       '�ۏ͈ؔ̓R�[�h
                strData = strData & "," & DtView1(i)("wrn_range_name")  '�ۏ͈͖ؔ�
                If Not IsDBNull(DtView1(i)("shop_name")) Then WKstr = Replace(DtView1(i)("shop_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�̔��X
                strData = strData & "," & DtView1(i)("wrn_fee")         '�ی���
                strData = strData & "," & DtView1(i)("Part_date")       '������
                strData = strData & "," & DtView1(i)("reg_date")        '�o�^���t
                If Not IsDBNull(DtView1(i)("ittpan")) Then
                    If DtView1(i)("ittpan") = "False" Then
                        strData = strData & ",Y"                        'Coop
                    Else
                        strData = strData & ",N"
                    End If
                Else
                    strData = strData & ","
                End If
                If Not IsDBNull(DtView1(i)("shop_shop_code")) Then WKstr = Replace(DtView1(i)("shop_shop_code"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '�X�܃R�[�h
                If DtView1(i)("ivc_old_flg") = "False" Then
                    strData = strData & ",0"                            '��������
                Else
                    strData = strData & ",1"
                End If
                strData = strData & "," & DtView1(i)("wrn_fee") * 1.1   '�ō��g��
                strData = strData & "," & DtView1(i)("makr_wrn_stat")   '�ۏ؊J�n��

                strData = Replace(strData, System.Environment.NewLine, "")
                strData = Replace(strData, vbCrLf, "")
                strData = Replace(strData, vbCr, "")
                strData = Replace(strData, vbLf, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          '�t�@�C�������
            'System.Diagnostics.EventLog.WriteEntry("nQGCare OBIC " & r & "��", "�I�[�r�b�N�p�f�[�^���o�͂��܂����B" & fr_date & "�`" & DateAdd(DateInterval.Day, -1, to_date), System.Diagnostics.EventLogEntryType.Information)
        End If

    End Sub
End Class
