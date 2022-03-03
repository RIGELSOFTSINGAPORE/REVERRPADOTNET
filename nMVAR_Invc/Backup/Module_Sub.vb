Module Module_Sub
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String
    Dim i, r As Integer

    '********************************************************************
    '**  �ύX�����쐬
    '********************************************************************
    Sub add_hsty(ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String)
        strSQL = "INSERT INTO L01_HSTY"
        strSQL = strSQL & " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
        strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & P_HSTY_DATE & "', 102)"
        strSQL = strSQL & ", " & P_EMPL_NO
        strSQL = strSQL & ", '" & P1 & "'"
        strSQL = strSQL & ", '" & P2 & "'"
        strSQL = strSQL & ", '" & P3 & "'"
        strSQL = strSQL & ", '" & P4 & "')"
        DB_OPEN("nMVAR")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  �}�X�^�ύX�����쐬
    '********************************************************************
    Sub add_MTR_hsty(ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String)
        strSQL = "INSERT INTO L02_MTR_HSTY"
        strSQL = strSQL & " (cls, code, upd_date, upd_empl_code, chge_item, befr, aftr)"
        strSQL = strSQL & " VALUES ('" & P1 & "'"
        strSQL = strSQL & ", '" & P2 & "'"
        strSQL = strSQL & ", CONVERT(DATETIME, '" & P_HSTY_DATE & "', 102)"
        strSQL = strSQL & ", " & P_EMPL_NO
        strSQL = strSQL & ", '" & P3 & "'"
        strSQL = strSQL & ", '" & P4 & "'"
        strSQL = strSQL & ", '" & P5 & "')"
        DB_OPEN("nMVAR")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  ��t�ԍ��̍̔� 
    '********************************************************************
    Public Function Count_Get(ByVal T2 As String) As String
        Dim WK_cnt As String
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT FROM S02_CNT_MTR WHERE (CNT_NO = '" & T2 & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "Count001")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Count001"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO S02_CNT_MTR"
            strSQL = strSQL & " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL = strSQL & " VALUES ('" & T2 & "', 1, N'��t�ԍ�')"
            DB_OPEN("nMVAR")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return T2 & "000001" & CD_Get(1)
        Else
            If DtView1(0)("CNT") = 999999 Then
                MessageBox.Show("��t�ԍ��G���[�F�V�X�e���Ǘ��҂ɂ��₢���킹���������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return 0
            Else
                strSQL = "UPDATE S02_CNT_MTR"
                strSQL = strSQL & " SET CNT  = CNT  + 1"
                strSQL = strSQL & " WHERE (CNT_NO  = '" & T2 & "')"
                DB_OPEN("nMVAR")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                WK_cnt = DtView1(0)("CNT") + 1
                Return T2 & WK_cnt.PadLeft(6, "0") & CD_Get(DtView1(0)("CNT") + 1)
            End If
        End If
    End Function

    '********************************************************************
    '**  �������ԍ��̍̔� 
    '********************************************************************
    Public Function Count_Get2() As String
        Dim WK_cnt As String
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT FROM S02_CNT_MTR WHERE (CNT_NO = '002')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "Count002")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Count002"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO S02_CNT_MTR"
            strSQL = strSQL & " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL = strSQL & " VALUES ('002', 1, N'�������ԍ�')"
            DB_OPEN("nMVAR")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return "1"
        Else
            If DtView1(0)("CNT") = 999999 Then
                MessageBox.Show("��t�ԍ��G���[�F�V�X�e���Ǘ��҂ɂ��₢���킹���������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return 0
            Else
                strSQL = "UPDATE S02_CNT_MTR"
                strSQL = strSQL & " SET CNT  = CNT  + 1"
                strSQL = strSQL & " WHERE (CNT_NO  = '002')"
                DB_OPEN("nMVAR")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                WK_cnt = DtView1(0)("CNT") + 1
                Return WK_cnt
            End If
        End If
    End Function

    '********************************************************************
    '**  �`�F�b�N�f�W�b�g 
    '********************************************************************
    Public Function CD_Get(ByVal no As String) As Decimal
        Dim wk As String
        Dim GS, KS, TL As Integer

        wk = no.PadLeft(12, "0")
        GS = CInt(Mid(wk, 2, 1)) + CInt(Mid(wk, 4, 1)) + CInt(Mid(wk, 6, 1)) + CInt(Mid(wk, 8, 1)) + CInt(Mid(wk, 10, 1)) + CInt(Mid(wk, 12, 1))
        KS = CInt(Mid(wk, 1, 1)) + CInt(Mid(wk, 3, 1)) + CInt(Mid(wk, 5, 1)) + CInt(Mid(wk, 7, 1)) + CInt(Mid(wk, 9, 1)) + CInt(Mid(wk, 11, 1))
        TL = Right(GS * 3 + KS, 1)

        If TL = 0 Then
            Return 0
        Else
            Return 10 - TL
        End If
    End Function

    '********************************************************************
    '**  �r��ON
    '********************************************************************
    Public Function HAITA_ON(ByVal rcpt_no As String)
        strSQL = "INSERT INTO S01_HAITA (rcpt_no, empl_code, use_date)"
        strSQL = strSQL & " VALUES ('" & rcpt_no & "', '" & P_EMPL_NO & "', '" & Now & "')"
        DB_OPEN("nMVAR")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        P_HAITA = "1"
    End Function

    '********************************************************************
    '**  �r��OFF
    '********************************************************************
    Public Function HAITA_OFF(ByVal rcpt_no As String)
        If P_HAITA = "1" Then
            strSQL = "DELETE FROM S01_HAITA WHERE (rcpt_no = '" & rcpt_no & "')"
            DB_OPEN("nMVAR")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            P_HAITA = "0"
        End If
    End Function

    '********************************************************************
    '**  �v�����^���݃`�F�b�N
    '********************************************************************
    Public Function PRT_CHK(ByVal prt_name) As String
        Dim Mach_F As String = "0"
        If Mid(prt_name, 1, 1) = "\" Then
            Return "1"  'OK
        Else
            For Each p As String In Printing.PrinterSettings.InstalledPrinters
                If prt_name = p Then Mach_F = "1" : Exit For
            Next
            If Mach_F <> "1" Then
                Return "0"  'NG
            Else
                Return "1"  'OK
            End If
        End If
    End Function

    '********************************************************************
    '**  �v�����^���ҏW
    '********************************************************************
    Public Function PRT_NAME(ByVal WK_p) As String
        Dim int1 As Integer
        int1 = WK_p.LastIndexOf("(���_�C���N�g")
        If int1 <> -1 Then
            Return Trim(Mid(WK_p, 1, int1))
        Else
            Return WK_p
        End If
    End Function

    '********************************************************************
    '**  �v�����^���擾
    '********************************************************************
    Public Function PRT_GET(ByVal cls) As String
        Dim WK_str As String
        P_mojibake = Nothing
        P_uppr_mrgn = 0
        P_left_mrgn = 0
        DsList1.Clear()

        '�v�����^�ݒ�
        strSQL = "SELECT * FROM M11_PRINTER WHERE (pc_name = '" & P_PC_NAME & "') AND (print_id = '" & cls & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M11_PRINTER")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("M11_PRINTER"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            P_uppr_mrgn = DtView1(0)("uppr_mrgn")
            P_left_mrgn = DtView1(0)("left_mrgn")

            If Not IsDBNull(DtView1(0)("mojibake")) Then
                P_mojibake = DtView1(0)("mojibake")
            End If
            If Mid(DtView1(0)("printer_name"), 1, 1) = "\" Then
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    WK_str = DtView1(0)("printer_name")
                    Return WK_str.Replace("\", "!")
                Else
                    P_mojibake = "True"
                    Return DtView1(0)("printer_name")
                End If
            Else
                For Each p As String In Printing.PrinterSettings.InstalledPrinters
                    If cls = "01" Then  'A4
                        Dim int1 As Integer
                        int1 = p.LastIndexOf("(���_�C���N�g")
                        If int1 <> -1 Or P_PC_NAME2 = "" Then
                            If p.IndexOf(DtView1(0)("printer_name")) <> -1 Then
                                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                    Return DtView1(0)("printer_name")
                                Else
                                    Return p
                                End If
                                Exit For
                            End If
                        End If
                    Else
                        If p = DtView1(0)("printer_name") Then
                            Return DtView1(0)("printer_name")
                            Exit For
                        End If
                    End If
                Next
            End If
        End If
        Return Nothing
    End Function

    '********************************************************************
    '**  �v�����^���擾(�e�X�g����p)
    '********************************************************************
    Public Function PRT_test_GET(ByVal prt, ByVal moji, ByVal redi) As String
        Dim WK_str As String
        P_mojibake = Nothing

        '�v�����^�ݒ�
        P_mojibake = moji

        If Mid(prt, 1, 1) = "\" Then
            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                WK_str = prt
                Return WK_str.Replace("\", "!")
            Else
                P_mojibake = "True"
                Return prt
            End If
        Else
            For Each p As String In Printing.PrinterSettings.InstalledPrinters
                If redi = "1" Then  'A4
                    Dim int1 As Integer
                    int1 = p.LastIndexOf("(���_�C���N�g")
                    If int1 <> -1 Or P_PC_NAME2 = "" Then
                        If p.IndexOf(prt) <> -1 Then
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                Return prt
                            Else
                                Return p
                            End If
                            Exit For
                        End If
                    End If
                Else
                    If p = prt Then
                        Return prt
                        Exit For
                    End If
                End If
            Next
        End If
        Return Nothing
    End Function

    '********************************************************************
    '**  EDIT���ڂ̍s���ƈ�s������̍ő啶�������擾���� 
    '********************************************************************
    Public Function Line_Get(ByVal Str As String)
        Dim M_cnt, G_cnt, i, j As Integer
        P_Line = 0
        P_Moji = 0

        If RTrim(Str) = Nothing Then
        Else
            G_cnt = 1
            For i = 1 To LenB(RTrim(Str))
                j = j + 1
                If MidB(Str, i, 2) = System.Environment.NewLine Then
                    G_cnt = G_cnt + 1
                    If M_cnt < j - 1 Then
                        M_cnt = j - 1
                        j = 0
                    End If
                End If
            Next
            P_Line = G_cnt
            If P_Line = 1 Then
                P_Moji = j
            Else
                P_Moji = M_cnt
            End If
        End If
    End Function

    '********************************************************************
    '**  Shift JIS�ɕϊ������Ƃ��ɕK�v�ȃo�C�g����Ԃ�
    '********************************************************************
    Function LenB(ByVal str As String) As Integer
        Return System.Text.Encoding.GetEncoding(932).GetByteCount(str)
    End Function

    Function LeftB(ByVal Str As String, ByVal n1 As Integer) As String
        Dim i As Integer
        Dim WkStr As String
        For i = 1 To n1
            WkStr = WkStr & Mid(Str, i, 1)
            Select Case LenB(WkStr)
                Case Is = n1
                    Return WkStr
                    Exit Function
                Case Is > n1
                    Return Mid(WkStr, 1, Len(WkStr) - 1) & " "
                    Exit Function
            End Select
        Next

        For i = 1 To n1 - LenB(WkStr)
            WkStr = WkStr & " "
        Next
        Return WkStr

    End Function

    Public Function MidB(ByVal str As String, ByVal Start As Integer, Optional ByVal Length As Integer = 0) As String
        '���󕶎��ɑ΂��Ă͏�ɋ󕶎���Ԃ�

        If str = "" Then
            Return ""
        End If

        '��Length�̃`�F�b�N

        'Length��0���AStart�ȍ~�̃o�C�g�����I�[�o�[����ꍇ��Start�ȍ~�̑S�o�C�g���w�肳�ꂽ���̂Ƃ݂Ȃ��B

        Dim RestLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str) - Start + 1

        If Length = 0 OrElse Length > RestLength Then
            Length = RestLength
        End If

        '���؂蔲��

        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
        Dim B() As Byte = CType(Array.CreateInstance(GetType(Byte), Length), Byte())

        Array.Copy(SJIS.GetBytes(str), Start - 1, B, 0, Length)

        Dim st1 As String = SJIS.GetString(B)

        '���؂蔲�������ʁA�Ō�̂P�o�C�g���S�p�����̔����������ꍇ�A���̔����͐؂�̂Ă�B

        Dim ResultLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(st1) - Start + 1

        If Asc(Strings.Right(st1, 1)) = 0 Then
            'VB.NET2002,2003�̏ꍇ�A�Ō�̂P�o�C�g���S�p�̔����̎�
            Return st1.Substring(0, st1.Length - 1)
        ElseIf Length = ResultLength - 1 Then
            'VB2005�̏ꍇ�ōŌ�̂P�o�C�g���S�p�̔����̎�
            Return st1.Substring(0, st1.Length - 1)
        Else
            '���̑��̏ꍇ
            Return st1
        End If
    End Function

    '********************************************************************
    '**  �w�蕶�����ɂȂ�܂ŃX�y�[�X������
    '********************************************************************
    Public Function PadRightB(ByVal str As String, ByVal len As Integer) As String
        Dim wk_int As Integer
        Dim wk_str As String
        If len <= LenB(str) Then
            Return str  '���Ɏw�蕶�����ȏ�Ȃ̂ł��̂܂ܕԂ�
        Else
            wk_int = len - LenB(str)
            For i = 1 To wk_int
                wk_str = wk_str & " "
            Next
            Return str & wk_str
        End If
    End Function

    '********************************************************************
    '**  �l�̌ܓ�
    '********************************************************************
    Public Function Round(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        Dim wkn2 As Double
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn2 - wkn1 >= 0.5 Then
            Return (wkn1 + 1) / 10 ^ keta
        Else
            Return wkn1 / 10 ^ keta
        End If
    End Function

    '********************************************************************
    '**  �؂�グ
    '********************************************************************
    Public Function RoundUP(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        Dim wkn2 As Double
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn2 - wkn1 > 0 Then
            Return (wkn1 + 1) / 10 ^ keta
        Else
            Return wkn1 / 10 ^ keta
        End If
    End Function

    '********************************************************************
    '**  �؎̂�
    '********************************************************************
    Public Function RoundDOWN(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        wkn1 = Fix(pdblX * 10 ^ keta)
        Return wkn1 / 10 ^ keta
    End Function

    '********************************************************************
    '**  ���s�����X�y�[�X�ɒu������
    '********************************************************************
    Public Function New_Line_Cng(ByVal str As String) As String
        Return str.Replace(System.Environment.NewLine, " ")
    End Function

    '********************************************************************
    '**  �J���}���X�y�[�X�ɒu������
    '********************************************************************
    Public Function comma_Cng(ByVal str As String) As String
        Return str.Replace(",", " ")
    End Function

    '********************************************************************
    '**  �ی����x�z�擾
    '********************************************************************
    Public Function Limit_Get(ByVal qg_care_no As String, ByVal acdt_stts As String, ByVal acdt_date As Date, ByVal prch_amnt As Integer) As Integer
        Dim wrn_F As String = "0"
        Dim y As Integer
        Dim use_amnt As Integer

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT �����ԍ�, ������, �ۏ؊���, �ۏ͈ؔ� FROM T01_������ WHERE (�����ԍ� = '" & qg_care_no & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("QGCare")
        DaList1.Fill(DsList1, "T01")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("T01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Select Case DtView1(0)("�ۏ͈ؔ�")
                Case Is = "6"   '�X�^���_�[�h
                    Select Case acdt_stts
                        Case Is = "01"   '�̏�
                            wrn_F = "1"
                    End Select
                Case Is = "5"   '�X�^���_�[�h�v���X
                    Select Case acdt_stts
                        Case Is = "01", "03", "04" '�̏�A�j���A���G��
                            wrn_F = "1"
                    End Select
                Case Is = "3"   '�X�y�V����
                    Select Case acdt_stts
                        Case Is = "01", "02", "03", "04" '�̏�A�����A�j���A���G��
                            wrn_F = "1"
                    End Select
                Case Is = "4"   '�Z�[�t�e�B�[
                    Select Case acdt_stts
                        Case Is = "02", "03", "04" '�����A�j���A���G��
                            wrn_F = "1"
                    End Select
                Case Is = "7"   '�����ۏ�
                    Select Case acdt_stts
                        Case Is = "01"   '�̏�
                            wrn_F = "1"
                    End Select
            End Select

            If wrn_F = "1" Then '�ۏ؂���
                '���N�ڂ����߂�
                For i = 1 To 10
                    If DateAdd(DateInterval.Year, i, CDate(DtView1(0)("������"))) > acdt_date Then
                        y = i
                        Exit For
                    End If
                Next

                '�����N�x�ʏ���
                Select Case Mid(qg_care_no, 1, 1)
                    Case Is = "A"
                        '�ߋ��g�p����
                        strSQL = "SELECT * FROM L03_QG_AMNT_LOG"
                        strSQL = strSQL & " WHERE (qg_care_no = '" & qg_care_no & "')"
                        strSQL = strSQL & " AND (from_date <= CONVERT(DATETIME, '" & acdt_date & "', 102))"
                        strSQL = strSQL & " AND (to_date >= CONVERT(DATETIME, '" & acdt_date & "', 102))"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        DaList1.Fill(DsList1, "T01_REP_MTR")
                        DB_CLOSE()
                        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

                        use_amnt = 0
                        If DtView2.Count <> 0 Then
                            For i = 0 To DtView2.Count - 1
                                use_amnt = use_amnt + DtView2(i)("repr_chrg")
                            Next
                        End If

                        If y <= DtView1(0)("�ۏ؊���") Then
                            Select Case y
                                Case Is = 1
                                    If prch_amnt < 150000 Then
                                        If prch_amnt - use_amnt >= 0 Then
                                            Return prch_amnt - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    Else
                                        If 150000 - use_amnt >= 0 Then
                                            Return 150000 - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    End If
                                Case Is = 2
                                    If prch_amnt < 120000 Then
                                        If prch_amnt - use_amnt >= 0 Then
                                            Return prch_amnt - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    Else
                                        If 120000 - use_amnt >= 0 Then
                                            Return 120000 - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    End If
                                Case Is = 3
                                    If prch_amnt < 100000 Then
                                        If prch_amnt - use_amnt >= 0 Then
                                            Return prch_amnt - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    Else
                                        If 100000 - use_amnt >= 0 Then
                                            Return 100000 - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    End If
                                Case Is = 4
                                    If prch_amnt < 60000 Then
                                        If prch_amnt - use_amnt >= 0 Then
                                            Return prch_amnt - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    Else
                                        If 60000 - use_amnt >= 0 Then
                                            Return 60000 - use_amnt
                                        Else
                                            Return 0
                                        End If
                                    End If
                                Case Else
                                    Return 0
                            End Select
                        Else
                            Return 0
                        End If

                    Case Else
                        If y <= DtView1(0)("�ۏ؊���") Then
                            Return 200000
                        Else
                            Return 0
                        End If
                End Select
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function

    '********************************************************************
    '**  �����Y�ς݃`�F�b�N
    '********************************************************************
    Public Function kensyu_CHK(ByVal invc_date, ByVal invc_code, ByVal brch_code) As String
        DsList1.Clear()
        strSQL = "SELECT * FROM L06_kensyu"
        strSQL = strSQL & " WHERE (invc_date = CONVERT(DATETIME, '" & invc_date & "', 102))"
        strSQL = strSQL & " AND (invc_code = '" & invc_code & "')"
        strSQL = strSQL & " AND (brch_code = '" & brch_code & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "L06_kensyu")
        DB_CLOSE()
        If r = 0 Then
            Return "OK"
        Else
            Return "NG"
        End If
    End Function
End Module
