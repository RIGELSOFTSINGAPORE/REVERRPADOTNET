Module Module_Sub
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String
    Dim i, r, r2 As Integer

    '********************************************************************
    '**  �ύX�����쐬
    '********************************************************************
    Sub add_hsty(ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String)
        strSQL = "INSERT INTO L01_HSTY"
        strSQL += " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
        strSQL += " VALUES (CONVERT(DATETIME, '" & P_HSTY_DATE & "', 102)"
        strSQL += ", " & P_EMPL_NO
        strSQL += ", '" & P1 & "'"
        strSQL += ", '" & P2 & "'"
        strSQL += ", '" & P3 & "'"
        strSQL += ", '" & P4 & "')"
        DB_OPEN("nMVAR")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub
    '�R���^�N�g���O
    Sub add_hsty2(ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String)
        strSQL = "INSERT INTO L07_CONTACT_HSTY"
        strSQL += " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
        strSQL += " VALUES (CONVERT(DATETIME, '" & P_HSTY_DATE & "', 102)"
        strSQL += ", " & P_EMPL_NO
        strSQL += ", '" & P1 & "'"
        strSQL += ", '" & P2 & "'"
        strSQL += ", '" & P3 & "'"
        strSQL += ", '" & P4 & "')"
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
        strSQL += " (cls, code, upd_date, upd_empl_code, chge_item, befr, aftr)"
        strSQL += " VALUES ('" & P1 & "'"
        strSQL += ", '" & P2 & "'"
        strSQL += ", CONVERT(DATETIME, '" & P_HSTY_DATE & "', 102)"
        strSQL += ", " & P_EMPL_NO
        strSQL += ", '" & P3 & "'"
        strSQL += ", '" & P4 & "'"
        strSQL += ", '" & P5 & "')"
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
            strSQL += " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL += " VALUES ('" & T2 & "', 1, N'��t�ԍ�')"
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
                strSQL += " SET CNT  = CNT  + 1"
                strSQL += " WHERE (CNT_NO  = '" & T2 & "')"
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
            strSQL += " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL += " VALUES ('002', 1, N'�������ԍ�')"
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
                strSQL += " SET CNT  = CNT  + 1"
                strSQL += " WHERE (CNT_NO  = '002')"
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
        strSQL += " VALUES ('" & rcpt_no & "', '" & P_EMPL_NO & "', '" & Now & "')"
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
    '**  �l�̌ܓ�
    '********************************************************************
    Public Function Round(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        Dim wkn2 As Double
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn1 > 0 Then
            If wkn2 - wkn1 >= 0.5 Then
                Return (wkn1 + 1) / 10 ^ keta
            Else
                Return wkn1 / 10 ^ keta
            End If
        Else
            If wkn2 - wkn1 <= -0.5 Then
                Return (wkn1 - 1) / 10 ^ keta
            Else
                Return wkn1 / 10 ^ keta
            End If
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
        If wkn2 - wkn1 <> 0 Then
            If wkn1 > 0 Then
                Return (wkn1 + 1) / 10 ^ keta
            Else
                Return (wkn1 - 1) / 10 ^ keta
            End If
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
        Return Trim(str.Replace(System.Environment.NewLine, " "))
    End Function

    '********************************************************************
    '**  �J���}���X�y�[�X�ɒu������
    '********************************************************************
    Public Function comma_Cng(ByVal str As String) As String
        Return Trim(str.Replace(",", " "))
    End Function

    '********************************************************************
    '**  AP SE
    '********************************************************************
    Public Function APSE_GET(ByVal rpar_comp_code As String, ByVal comp_date As Date) As Integer
        DsList1.Clear()
        strSQL = "SELECT M42_AP_BNAS_SUB.rate"
        strSQL += " FROM M41_AP_BNAS INNER JOIN M42_AP_BNAS_SUB ON M41_AP_BNAS.id = M42_AP_BNAS_SUB.id"
        strSQL += " WHERE (M42_AP_BNAS_SUB.rpar_comp_code = '" & rpar_comp_code & "')"
        strSQL += " AND (M41_AP_BNAS.date_from <= CONVERT(DATETIME, '" & comp_date & "', 102))"
        strSQL += " AND (M41_AP_BNAS.date_to >= CONVERT(DATETIME, '" & comp_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M42_AP_BNAS_SUB")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("M42_AP_BNAS_SUB"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Return DtView1(0)("rate")
        Else
            Return 0
        End If
    End Function

    '********************************************************************
    '**  �R���^�N�g���擾
    '********************************************************************
    Public Function CONTACT_GET(ByVal rcpt_no As String)
        P1_CONTACT = Nothing
        P2_CONTACT = Nothing
        P3_CONTACT = Nothing
        DsList1.Clear()
        strSQL = "SELECT TOP (100) PERCENT T08_CONTACT.contact_date, M01_EMPL.name, T08_CONTACT.contact_fin_flg"
        strSQL += " FROM  T08_CONTACT LEFT OUTER JOIN M01_EMPL ON T08_CONTACT.contact_empl = M01_EMPL.empl_code"
        strSQL += " WHERE  (T08_CONTACT.rcpt_no = '" & rcpt_no & "')"
        strSQL += " UNION"
        strSQL += " SELECT TOP (100) PERCENT T05_INQUIRY.inq_date AS contact_date, M01_EMPL_1.name, 0 AS contact_fin_flg"
        strSQL += " FROM T05_INQUIRY LEFT OUTER JOIN M01_EMPL AS M01_EMPL_1 ON T05_INQUIRY.inq_empl = M01_EMPL_1.empl_code"
        strSQL += " WHERE (T05_INQUIRY.rcpt_no = '" & rcpt_no & "')"
        strSQL += " ORDER BY contact_date DESC"
        'strSQL = "SELECT T08_CONTACT.contact_date, M01_EMPL.name, T08_CONTACT.contact_fin_flg"
        'strSQL += " FROM T08_CONTACT LEFT OUTER JOIN"
        'strSQL += " M01_EMPL ON T08_CONTACT.contact_empl = M01_EMPL.empl_code"
        'strSQL += " WHERE (T08_CONTACT.rcpt_no = '" & rcpt_no & "')"
        'strSQL += " ORDER BY T08_CONTACT.contact_date DESC"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "T08_CONTACT")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("T08_CONTACT"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            P1_CONTACT = Format(DtView1(0)("contact_date"), "yyyy/MM/dd HH:mm")
            P2_CONTACT = DtView1(0)("name")
            DtView1 = New DataView(DsList1.Tables("T08_CONTACT"), "contact_fin_flg = 1 ", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                P3_CONTACT = "True"
            End If
        End If
        DsList1.Clear()
    End Function

    '********************************************************************
    '**  ���x�[�g�E���ȕ��S�Z�o
    '********************************************************************
    Public Function rebate_idvd_Get(ByVal store_code As String, ByVal rpar_cls As String, ByVal rcpt_cls As String, ByVal wrn_limt_amnt As Integer, ByVal menseki_amnt As Integer, ByVal gTTL As Integer, ByVal sTTL As Integer, ByVal own_F As String, ByVal vndr_code As String, ByVal note_kbn As String)
        P_idvd = 0      '���ȕ��S
        P_rebate = 0    '���x�[�g
        P_chn_F = "0"   '�`�F�[���`�[�����ǒʏ���z

        '����ŗ�
        Dim Wk_TAX As Integer
        Dim WK_mnsk As String
        Wk_TAX = tax_rate_get(Now) '����ŗ��擾
        If Wk_TAX = "10" Then
            WK_mnsk = "4546"
        Else
            WK_mnsk = "4630"
        End If

        DsList1.Clear()
        strSQL = "SELECT grup_code FROM M08_STORE WHERE (store_code = '" & store_code & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "dlvr_rprt_cls")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("dlvr_rprt_cls"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Select Case DtView1(0)("grup_code")                     '�̎ЃO���[�v
                Case Is = "02", "89", "90", "96"                    '���̔̎ЃO���[�v�̓��x�[�g����
                    Select Case rpar_cls    '�C�����
                        Case Is = "02"      '�@���[�J�[�ۏ�
                            If own_F = "True" And sTTL <> 0 And vndr_code <> "01" Then '���ЏC�� �� �v�゠�� �� Apple�ȊO
                                P_idvd = 0                                                              '���ȕ��S
                                P_rebate = 0                                                            '���x�[�g
                            Else
                                P_idvd = 0                                                              '���ȕ��S
                                P_rebate = 0                                                            '���x�[�g
                            End If
                        Case Else               '�L��
                            Select Case rcpt_cls    '��t���
                                Case Is = "02"      'QG-Care
                                    If DtView1(0)("grup_code") = "90" Then  '�A
                                        If wrn_limt_amnt < sTTL Then        '���x�I�[�o�[
                                            If menseki_amnt <> 0 Then           '���Y����
                                                If gTTL = 0 Then
                                                    P_idvd = sTTL - wrn_limt_amnt                       '���ȕ��S
                                                Else
                                                    P_idvd = sTTL - wrn_limt_amnt + CInt(WK_mnsk)       '���ȕ��S
                                                End If
                                                If sTTL < 35000 Then
                                                    P_rebate = Round(sTTL * 0.13, 0)                    '���x�[�g
                                                Else
                                                    P_rebate = 4550
                                                End If
                                            Else                                '�ʏ�̏�
                                                P_idvd = sTTL - wrn_limt_amnt                           '���ȕ��S
                                                If sTTL < 35000 Then
                                                    P_rebate = Round(sTTL * 0.13, 0)                    '���x�[�g
                                                Else
                                                    P_rebate = 4550
                                                End If
                                            End If
                                        Else                                '���x��
                                            If menseki_amnt <> 0 Then           '���Y����
                                                If gTTL = 0 Then
                                                    P_idvd = 0                                          '���ȕ��S
                                                Else
                                                    P_idvd = CInt(WK_mnsk)                              '���ȕ��S
                                                End If
                                                If sTTL < 35000 Then
                                                    P_rebate = Round(sTTL * 0.13, 0)                    '���x�[�g
                                                Else
                                                    P_rebate = 4550
                                                End If
                                            Else                                '�ʏ�̏�
                                                P_idvd = 0                                              '���ȕ��S
                                                If sTTL < 35000 Then
                                                    P_rebate = Round(sTTL * 0.13, 0)                    '���x�[�g
                                                Else
                                                    P_rebate = 4550
                                                End If
                                            End If
                                        End If
                                    Else                                    '�B
                                        If wrn_limt_amnt < sTTL Then        '���x�I�[�o�[
                                            If menseki_amnt <> 0 Then           '���Y����
                                                If gTTL = 0 Then
                                                    P_idvd = sTTL - wrn_limt_amnt                       '���ȕ��S
                                                Else
                                                    P_idvd = sTTL - wrn_limt_amnt + CInt(WK_mnsk)       '���ȕ��S
                                                End If
                                                P_rebate = 0                                            '���x�[�g
                                            Else                                '�ʏ�̏�
                                                P_idvd = sTTL - wrn_limt_amnt                           '���ȕ��S
                                                P_rebate = 0                                            '���x�[�g
                                            End If
                                        Else                                '���x��
                                            If menseki_amnt <> 0 Then           '���Y����
                                                If gTTL = 0 Then
                                                    P_idvd = 0                                          '���ȕ��S
                                                Else
                                                    P_idvd = CInt(WK_mnsk)                              '���ȕ��S
                                                End If
                                                P_rebate = 0                                            '���x�[�g
                                            Else                                '�ʏ�̏�
                                                P_idvd = 0                                              '���ȕ��S
                                                P_rebate = 0                                            '���x�[�g
                                            End If
                                        End If
                                    End If
                                Case Is = "03"      '�C�����ۏ؏C��
                                    Select Case DtView1(0)("grup_code")         '�̎ЃO���[�v
                                        Case Is = "02", "90"
                                            If wrn_limt_amnt < sTTL Then        '���x�I�[�o�[
                                                P_idvd = sTTL - wrn_limt_amnt                           '���ȕ��S
                                                If sTTL < 35000 Then
                                                    P_rebate = Round(sTTL * 0.13, 0)                    '���x�[�g
                                                Else
                                                    P_rebate = 4550
                                                End If
                                            Else                                '���x��
                                                P_idvd = 0                                              '���ȕ��S
                                                If sTTL < 35000 Then
                                                    P_rebate = Round(sTTL * 0.13, 0)                    '���x�[�g
                                                Else
                                                    P_rebate = 4550
                                                End If
                                            End If
                                        Case Else
                                            If wrn_limt_amnt < sTTL Then        '���x�I�[�o�[
                                                P_idvd = sTTL - wrn_limt_amnt                           '���ȕ��S
                                                P_rebate = 0                                            '���x�[�g
                                            Else                                '���x��
                                                P_idvd = 0                                              '���ȕ��S
                                                P_rebate = 0                                            '���x�[�g
                                            End If
                                    End Select
                                Case Else           '�D���̑�
                                    If DtView1(0)("grup_code") = "89" Then
                                        P_idvd = sTTL                                                   '���ȕ��S
                                        P_rebate = 0                                                    '���x�[�g
                                    Else
                                        If vndr_code = "20" Then    'iOS
                                            P_idvd = sTTL                                                   '���ȕ��S
                                            P_rebate = 0                                                    '���x�[�g
                                        Else
                                            If vndr_code = "01" And note_kbn = "01" Then    'Apple Note
                                                If own_F = "True" Then  '���ЏC�� 
                                                    If sTTL < 35000 Then
                                                        P_rebate = Round(sTTL * 0.13, 0)                        'WK���x�[�g
                                                    Else
                                                        P_rebate = 4550
                                                    End If
                                                    P_idvd = sTTL - P_rebate                                    '���ȕ��S
                                                    P_rebate = 0                                                '���x�[�g
                                                Else
                                                    P_idvd = sTTL                                               '���ȕ��S
                                                    P_rebate = 0                                                '���x�[�g
                                                End If
                                            Else
                                                If sTTL < 35000 Then
                                                    P_rebate = Round(sTTL * 0.13, 0)                        'WK���x�[�g
                                                Else
                                                    P_rebate = 4550
                                                End If
                                                P_idvd = sTTL - P_rebate                                    '���ȕ��S
                                                P_rebate = 0                                                '���x�[�g
                                            End If
                                        End If
                                    End If
                            End Select
                    End Select
                Case Else                                           '���̔̎ЃO���[�v�̓��x�[�g�Ȃ�
                    P_idvd = 0                                                                          '���ȕ��S
                    P_rebate = 0                                                                        '���x�[�g
                    P_chn_F = "1"
            End Select
        End If
    End Function
    Public Function rebate_idvd_Get2(ByVal store_code As String, ByVal rpar_cls As String, ByVal rcpt_cls As String, ByVal wrn_limt_amnt As Integer, ByVal menseki_amnt As Integer, ByVal gTTL As Integer, ByVal sTTL As Integer, ByVal own_F As String, ByVal vndr_code As String, ByVal note_kbn As String)
        P_idvd = 0      '���ȕ��S
        P_rebate = 0    '���x�[�g

        DsList1.Clear()
        strSQL = "SELECT grup_code FROM M08_STORE WHERE (store_code = '" & store_code & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "dlvr_rprt_cls")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("dlvr_rprt_cls"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            If DtView1(0)("grup_code") = "88" Then  '�����x�m�ʕی�
                If rpar_cls = "10" Then             '����Fujitsu�ی�
                    P_idvd = 0                                                                              '���ȕ��S
                Else
                    P_idvd = 0                                                                              '���ȕ��S
                End If
                P_rebate = 0                                                                                '���x�[�g

            End If
        End If
    End Function

    '********************************************************************
    '**  QG Care �C�����z�݌v
    '********************************************************************
    Public Function QG_HSTY(ByVal qg_care_no As String, ByVal rcpt_no As String, ByVal acdt_date As Date, ByVal amnt As Integer) As Decimal

        DsList1.Clear()
        strSQL = "SELECT * FROM L03_QG_AMNT_LOG"
        strSQL += " WHERE (qg_care_no = '" & qg_care_no & "')"
        strSQL += " AND (rcpt_no = '" & rcpt_no & "')"
        strSQL += " AND (from_date <= CONVERT(DATETIME, '" & acdt_date & "', 102))"
        strSQL += " AND (to_date >= CONVERT(DATETIME, '" & acdt_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "L03_QG_AMNT_LOG")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("L03_QG_AMNT_LOG"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            SqlCmd1 = New SqlClient.SqlCommand("SELECT code, makr_wrn_stat FROM T01_member WHERE (code = '" & qg_care_no & "')", cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("QGCare")
            DaList1.Fill(DsList1, "T01")
            DB_CLOSE()
            DtView2 = New DataView(DsList1.Tables("T01"), "", "", DataViewRowState.CurrentRows)

            '���N�ڂ����߂�
            Dim WK_date1, WK_date2 As Date
            For i = 1 To 10
                If DateAdd(DateInterval.Year, i, CDate(DtView2(0)("makr_wrn_stat"))) > CDate(acdt_date) Then
                    WK_date1 = DateAdd(DateInterval.Year, i - 1, CDate(DtView2(0)("makr_wrn_stat")))
                    WK_date2 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, i, CDate(DtView2(0)("makr_wrn_stat"))))
                    Exit For
                End If
            Next

            strSQL = "INSERT INTO L03_QG_AMNT_LOG"
            strSQL += " (qg_care_no, rcpt_no, from_date, to_date, repr_chrg)"
            strSQL += " VALUES ('" & qg_care_no & "'"
            strSQL += ", '" & rcpt_no & "'"
            strSQL += ", CONVERT(DATETIME, '" & WK_date1 & "', 102)"
            strSQL += ", CONVERT(DATETIME, '" & WK_date2 & "', 102)"
            strSQL += ", " & amnt & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
        Else
            strSQL = "UPDATE L03_QG_AMNT_LOG"
            strSQL += " SET repr_chrg = " & amnt
            strSQL += " WHERE (qg_care_no = '" & qg_care_no & "')"
            strSQL += " AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " AND (from_date <= CONVERT(DATETIME, '" & acdt_date & "', 102))"
            strSQL += " AND (to_date >= CONVERT(DATETIME, '" & acdt_date & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
        End If

    End Function

    '********************************************************************
    '**  �ی����x�z�擾
    '********************************************************************
    Public Function Limit_Get(ByVal qg_care_no As String, ByVal acdt_stts As String, ByVal acdt_date As Date, ByVal prch_amnt As Integer) As Integer
        Dim wrn_F As String = "0"
        Dim y As Integer
        Dim use_amnt As Integer

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT code, Part_date, makr_wrn_stat, wrn_tem, wrn_range FROM T01_member WHERE (code = '" & qg_care_no & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("QGCare")
        DaList1.Fill(DsList1, "T01")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("T01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Select Case DtView1(0)("wrn_range")
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
                Case Is = "3", "8"  '�X�y�V�����A�X�y�V�����U
                    Select Case acdt_stts
                        Case Is = "01", "02", "03", "04" '�̏�A�����A�j���A���G��
                            wrn_F = "1"
                    End Select
                Case Is = "4", "9", "11", "12"  '�Z�[�t�e�B�A�Z�[�t�e�B�U�A�Z�[�t�e�B�v���X�A�Z�[�t�e�B�U�v���X
                    Select Case acdt_stts
                        Case Is = "02", "03", "04" '�����A�j���A���G��
                            wrn_F = "1"
                    End Select
                Case Is = "7"   '�����ۏ�
                    Select Case acdt_stts
                        Case Is = "01"   '�̏�
                            wrn_F = "1"
                    End Select
                Case Is = "2"   '���C�g
                    Select Case acdt_stts
                        Case Is = "02", "03", "04" '�����A�j���A���G��
                            wrn_F = "S"
                    End Select
            End Select

            If wrn_F = "1" Or wrn_F = "S" Then '�ۏ؂��肩 or ���C�g
                '���N�ڂ����߂�
                y = 5
                For i = 1 To 5
                    If DateAdd(DateInterval.Year, i, CDate(DtView1(0)("makr_wrn_stat"))) > acdt_date Then
                        y = i
                        Exit For
                    End If
                Next

                If wrn_F = "1" Then '�ۏ؂���
                    '�����N�x�ʏ���
                    Select Case Mid(qg_care_no, 1, 1)
                        Case Is = "A", "E", "M"
                            '�ߋ��g�p����
                            strSQL = "SELECT * FROM L03_QG_AMNT_LOG"
                            strSQL += " WHERE (qg_care_no = '" & qg_care_no & "')"
                            strSQL += " AND (from_date <= CONVERT(DATETIME, '" & acdt_date & "', 102))"
                            strSQL += " AND (to_date >= CONVERT(DATETIME, '" & acdt_date & "', 102))"
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

                            If y <= DtView1(0)("wrn_tem") Then
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
                                    Case Is = 4, 5, 6
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
                            If y <= DtView1(0)("wrn_tem") Then
                                Return 200000
                            Else
                                Return 0
                            End If
                    End Select
                Else    '���C�g
                    Select Case y
                        Case Is = 1
                            Return 80000
                        Case Is = 2
                            Return 60000
                        Case Is = 3
                            Return 40000
                        Case Is = 4
                            Return 20000
                        Case Else
                            Return 0
                    End Select
                End If
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function

    '********************************************************************
    '**  �x�m�ʕی��@�[�i������@���f
    '********************************************************************
    Public Function Fuji_neva(ByVal rcpt_no As String) As String
        '** �@Return="1":������� �@
        '** �@Return="0":������Ȃ� �@
        '** �@Return="-":���f���Ȃ�
        Dim part_cnt, part_cnt_exp, wrn_prod As Integer
        Dim Wk_TAX As Integer
        Dim Wk_TAX_1, Wk_TAX_0 As Decimal

        '����ŗ�
        Wk_TAX = tax_rate_get(Now) '����ŗ��擾
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0

        DsList1.Clear()
        strSQL = "SELECT T01_REP_MTR.rpar_cls, T01_REP_MTR.model_2, T01_REP_MTR.wrn_limt_amnt, T01_REP_MTR.acdt_stts"
        strSQL += ", T01_REP_MTR.qg_care_no, T01_REP_MTR.comp_shop_ttl, M08_STORE.grup_code, T01_REP_MTR.rcpt_cls"
        strSQL += " FROM T01_REP_MTR INNER JOIN"
        strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Return "-"
        Else
            If DtView1(0)("grup_code") <> "88" _
                Or DtView1(0)("rcpt_cls") <> "10" Then
                Return "-"
            Else
                strSQL = "SELECT exp_flg"
                strSQL += " FROM T04_REP_PART"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "') AND (kbn = '2')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(DsList1, "T04_REP_PART")
                DB_CLOSE()

                DtView2 = New DataView(DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then
                    For i = 0 To DtView2.Count - 1
                        If IsDBNull(DtView2(i)("exp_flg")) Then DtView2(i)("exp_flg") = "False"
                        If DtView2(i)("exp_flg") = "True" Then
                            part_cnt_exp = part_cnt_exp + 1 '���Օi�̐�
                        Else
                            part_cnt = part_cnt + 1         '���Օi�ȊO�̐�
                        End If
                    Next
                End If

                'strSQL = "SELECT M01_insurance_co_decision.wrn_prod"
                'strSQL += " FROM T01_wrn_date INNER JOIN"
                'strSQL += " M01_insurance_co_decision ON T01_wrn_date.Securities_no = M01_insurance_co_decision.Securities_no"
                'strSQL += " WHERE (T01_wrn_date.wrn_id = '" & DtView1(0)("qg_care_no") & "')"
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'DaList1.SelectCommand = SqlCmd1
                'DB_OPEN("Fujitsu")
                'DaList1.Fill(DsList1, "T01_wrn_date")
                'DB_CLOSE()

                'DtView2 = New DataView(DsList1.Tables("T01_wrn_date"), "", "", DataViewRowState.CurrentRows)
                'If DtView2.Count <> 0 Then
                '    wrn_prod = DtView2(0)("wrn_prod")
                'End If

                If DtView1(0)("rpar_cls") = "02" Then   '���[�J�[�ۏ�
                    If part_cnt_exp = 0 Then            '���Օi�Ȃ�
                        Return "0"                      'B
                    Else                                '���Օi����
                        Return "1"                      'A
                    End If
                Else                                    '�L��
                    If part_cnt = 0 And part_cnt_exp <> 0 Then  '���Օi�̂�
                        Return "1"                      'A
                    Else
                        If part_cnt_exp <> 0 _
                            Or RoundDOWN(DtView1(0)("wrn_limt_amnt") / Wk_TAX_1, 0) < DtView1(0)("comp_shop_ttl") Then    '���Օi���� or ���x�z����
                            Return "1"                  'E
                        Else
                            Return "0"                  'C D
                        End If
                    End If
                End If
            End If
        End If
    End Function

    '********************************************************************
    '**  ���Օi�@���f
    '********************************************************************
    Public Function exp_part(ByVal rcpt_no As String) As String
        '** �@Return="1":���Օi�̂� �@
        '** �@Return="2":���Օi�Ȃ� �@
        '** �@Return="3":���Օi����
        Dim part_cnt, part_cnt_exp As Integer
        P_exp_cnt = 0 : P_Nexp_cnt = 0
        P_exp_amt = 0 : P_Nexp_amt = 0

        DsList1.Clear()
        strSQL = "SELECT exp_flg, shop_chrg"
        strSQL += " FROM T04_REP_PART"
        strSQL += " WHERE (rcpt_no = '" & rcpt_no & "') AND (kbn = '2')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "T04_REP_PART")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("exp_flg")) Then DtView1(i)("exp_flg") = "False"
                If DtView1(i)("exp_flg") = "True" Then
                    part_cnt_exp = part_cnt_exp + 1 '���Օi�̐�
                    P_exp_cnt = P_exp_cnt + 1
                    P_exp_amt = P_exp_amt + DtView1(i)("shop_chrg")
                Else
                    part_cnt = part_cnt + 1         '���Օi�ȊO�̐�
                    P_Nexp_cnt = P_Nexp_cnt + 1
                    P_Nexp_amt = P_Nexp_amt + DtView1(i)("shop_chrg")
                End If
            Next

            If part_cnt_exp <> 0 Then
                If part_cnt <> 0 Then
                    Return "3"
                Else
                    Return "1"
                End If
            Else
                Return "2"
            End If
        Else
            Return "2"
        End If

    End Function

    '********************************************************************
    '**  Q&A�A�g�f�[�^�����f(�߂�l 0:�X�V���Ȃ��@1:�X�V����j
    '********************************************************************
    Public Function QA_data(ByVal rcpt_no As String) As String
        DsList1.Clear()
        strSQL = "SELECT stts, rep_ng_flg FROM QA02_data WHERE (gss_rcpt_no = N'" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "QA02_data")
        DB_CLOSE()
        If r = 0 Then   'QA�ΏۊO
            Return "0"
        Else
            DtView1 = New DataView(DsList1.Tables("QA02_data"), "", "", DataViewRowState.CurrentRows)
            Select Case DtView1(0)("stts")
                Case Is = "100", "120", "90", "91"  '�o�׎w���A�p���w���Ȃ�X�V���Ȃ�
                    Return "0"
                Case Else
                    If DtView1(0)("rep_ng_flg") = "True" Then   '�C���s��
                        Return "0"
                    Else                                        '�C���\�̎��̂ݍX�V
                        Return "1"
                    End If
            End Select
        End If
    End Function

    '********************************************************************
    '**  Q&A�A�C���\�����f(�߂�l 0:�C���\�@1:�C���s�j
    '********************************************************************
    Public Function QA_rep(ByVal rcpt_no As String) As String
        DsList1.Clear()
        strSQL = "SELECT stts, rep_ng_flg FROM QA02_data WHERE (gss_rcpt_no = N'" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "QA02_data")
        DB_CLOSE()
        If r = 0 Then   'QA�ΏۊO
            Return "0"
        Else
            DtView1 = New DataView(DsList1.Tables("QA02_data"), "", "", DataViewRowState.CurrentRows)
            Select Case DtView1(0)("stts")
                Case Is = "40", "50"  '��t�A���ς���˗��A�̎��̂ݍX�V
                    If DtView1(0)("rep_ng_flg") = "True" Then   '�C���s��
                        Return "1"
                    Else                                        '�C���\
                        Return "0"
                    End If
                Case Else
                    Return "9"
            End Select
        End If
    End Function

    '********************************************************************
    '**  Q&A ����σt���O�X�V
    '********************************************************************
    Public Function QA_started_flg_ON(ByVal rcpt_no As String)
        DB_OPEN("nMVAR")
        DsList1.Clear()
        strSQL = "SELECT gss_rcpt_no"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (started_flg = 0) AND (gss_rcpt_no = N'" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(DsList1, "QA02_data")
        If r <> 0 Then
            strSQL = "SELECT rcpt_no"
            strSQL += " FROM T01_REP_MTR"
            strSQL += " WHERE (sindan_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (etmt_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (rsrv_cacl_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (part_ordr_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (part_rcpt_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (rep_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (renraku_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (comp_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (sals_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (ship_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            strSQL += " OR (rqst_date IS NOT NULL) AND (rcpt_no = '" & rcpt_no & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r2 = DaList1.Fill(DsList1, "T01_REP_MTR")
            If r2 <> 0 Then
                strSQL = "UPDATE QA02_data SET started_flg = 1 WHERE (gss_rcpt_no = N'" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()
    End Function

    '********************************************************************
    '**  ����ŗ��擾
    '********************************************************************
    Public Function tax_rate_get(ByVal p_date) As Integer
        If p_date >= "2019/10/01" Then
            'If p_date >= "2019/09/30" Then
            DsList1.Clear()
            strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '008') AND (delt_flg = 0)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(DsList1, "cls008")
            DB_CLOSE()
            If r = 0 Then   'QA�ΏۊO
                Return 10
            Else
                DtView1 = New DataView(DsList1.Tables("cls008"), "", "", DataViewRowState.CurrentRows)
                Return DtView1(0)("cls_code_name")
            End If
        Else
            Return 8
        End If
    End Function

End Module