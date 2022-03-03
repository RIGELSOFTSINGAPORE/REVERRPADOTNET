Module Module_Sub
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String
    Dim i, r As Integer

    '********************************************************************
    '**  変更履歴作成
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
    '**  マスタ変更履歴作成
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
    '**  受付番号の採番 
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
            strSQL = strSQL & " VALUES ('" & T2 & "', 1, N'受付番号')"
            DB_OPEN("nMVAR")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return T2 & "000001" & CD_Get(1)
        Else
            If DtView1(0)("CNT") = 999999 Then
                MessageBox.Show("受付番号エラー：システム管理者にお問い合わせください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    '**  請求書番号の採番 
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
            strSQL = strSQL & " VALUES ('002', 1, N'請求書番号')"
            DB_OPEN("nMVAR")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return "1"
        Else
            If DtView1(0)("CNT") = 999999 Then
                MessageBox.Show("受付番号エラー：システム管理者にお問い合わせください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    '**  チェックデジット 
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
    '**  排他ON
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
    '**  排他OFF
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
    '**  プリンタ存在チェック
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
    '**  プリンタ名編集
    '********************************************************************
    Public Function PRT_NAME(ByVal WK_p) As String
        Dim int1 As Integer
        int1 = WK_p.LastIndexOf("(リダイレクト")
        If int1 <> -1 Then
            Return Trim(Mid(WK_p, 1, int1))
        Else
            Return WK_p
        End If
    End Function

    '********************************************************************
    '**  プリンタ名取得
    '********************************************************************
    Public Function PRT_GET(ByVal cls) As String
        Dim WK_str As String
        P_mojibake = Nothing
        P_uppr_mrgn = 0
        P_left_mrgn = 0
        DsList1.Clear()

        'プリンタ設定
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
                        int1 = p.LastIndexOf("(リダイレクト")
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
    '**  プリンタ名取得(テスト印刷用)
    '********************************************************************
    Public Function PRT_test_GET(ByVal prt, ByVal moji, ByVal redi) As String
        Dim WK_str As String
        P_mojibake = Nothing

        'プリンタ設定
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
                    int1 = p.LastIndexOf("(リダイレクト")
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
    '**  EDIT項目の行数と一行あたりの最大文字数を取得する 
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
    '**  Shift JISに変換したときに必要なバイト数を返す
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
        '▼空文字に対しては常に空文字を返す

        If str = "" Then
            Return ""
        End If

        '▼Lengthのチェック

        'Lengthが0か、Start以降のバイト数をオーバーする場合はStart以降の全バイトが指定されたものとみなす。

        Dim RestLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str) - Start + 1

        If Length = 0 OrElse Length > RestLength Then
            Length = RestLength
        End If

        '▼切り抜き

        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift-JIS")
        Dim B() As Byte = CType(Array.CreateInstance(GetType(Byte), Length), Byte())

        Array.Copy(SJIS.GetBytes(str), Start - 1, B, 0, Length)

        Dim st1 As String = SJIS.GetString(B)

        '▼切り抜いた結果、最後の１バイトが全角文字の半分だった場合、その半分は切り捨てる。

        Dim ResultLength As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(st1) - Start + 1

        If Asc(Strings.Right(st1, 1)) = 0 Then
            'VB.NET2002,2003の場合、最後の１バイトが全角の半分の時
            Return st1.Substring(0, st1.Length - 1)
        ElseIf Length = ResultLength - 1 Then
            'VB2005の場合で最後の１バイトが全角の半分の時
            Return st1.Substring(0, st1.Length - 1)
        Else
            'その他の場合
            Return st1
        End If
    End Function

    '********************************************************************
    '**  指定文字数になるまでスペースを入れる
    '********************************************************************
    Public Function PadRightB(ByVal str As String, ByVal len As Integer) As String
        Dim wk_int As Integer
        Dim wk_str As String
        If len <= LenB(str) Then
            Return str  '既に指定文字数以上なのでそのまま返す
        Else
            wk_int = len - LenB(str)
            For i = 1 To wk_int
                wk_str = wk_str & " "
            Next
            Return str & wk_str
        End If
    End Function

    '********************************************************************
    '**  四捨五入
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
    '**  切り上げ
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
    '**  切捨て
    '********************************************************************
    Public Function RoundDOWN(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        wkn1 = Fix(pdblX * 10 ^ keta)
        Return wkn1 / 10 ^ keta
    End Function

    '********************************************************************
    '**  改行ををスペースに置き換え
    '********************************************************************
    Public Function New_Line_Cng(ByVal str As String) As String
        Return str.Replace(System.Environment.NewLine, " ")
    End Function

    '********************************************************************
    '**  カンマをスペースに置き換え
    '********************************************************************
    Public Function comma_Cng(ByVal str As String) As String
        Return str.Replace(",", " ")
    End Function

    '********************************************************************
    '**  保険限度額取得
    '********************************************************************
    Public Function Limit_Get(ByVal qg_care_no As String, ByVal acdt_stts As String, ByVal acdt_date As Date, ByVal prch_amnt As Integer) As Integer
        Dim wrn_F As String = "0"
        Dim y As Integer
        Dim use_amnt As Integer

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT 加入番号, 加入日, 保証期間, 保証範囲 FROM T01_加入者 WHERE (加入番号 = '" & qg_care_no & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("QGCare")
        DaList1.Fill(DsList1, "T01")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("T01"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Select Case DtView1(0)("保証範囲")
                Case Is = "6"   'スタンダード
                    Select Case acdt_stts
                        Case Is = "01"   '故障
                            wrn_F = "1"
                    End Select
                Case Is = "5"   'スタンダードプラス
                    Select Case acdt_stts
                        Case Is = "01", "03", "04" '故障、破損、水濡れ
                            wrn_F = "1"
                    End Select
                Case Is = "3"   'スペシャル
                    Select Case acdt_stts
                        Case Is = "01", "02", "03", "04" '故障、落雷、破損、水濡れ
                            wrn_F = "1"
                    End Select
                Case Is = "4"   'セーフティー
                    Select Case acdt_stts
                        Case Is = "02", "03", "04" '落雷、破損、水濡れ
                            wrn_F = "1"
                    End Select
                Case Is = "7"   '延長保証
                    Select Case acdt_stts
                        Case Is = "01"   '故障
                            wrn_F = "1"
                    End Select
            End Select

            If wrn_F = "1" Then '保証あり
                '何年目か求める
                For i = 1 To 10
                    If DateAdd(DateInterval.Year, i, CDate(DtView1(0)("加入日"))) > acdt_date Then
                        y = i
                        Exit For
                    End If
                Next

                '加入年度別処理
                Select Case Mid(qg_care_no, 1, 1)
                    Case Is = "A"
                        '過去使用実績
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

                        If y <= DtView1(0)("保証期間") Then
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
                        If y <= DtView1(0)("保証期間") Then
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
    '**  検収〆済みチェック
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
