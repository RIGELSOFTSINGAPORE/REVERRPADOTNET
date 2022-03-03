Module Module_Sub
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL, WK_str As String
    Dim i, r As Integer

    '********************************************************************
    '**  処理年度を求める
    '********************************************************************
    Function proc_y() As Integer

        DsList1.Clear()
        strSQL = "SELECT MAX(nendo) AS nendo_max FROM M03_amnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsList1, "nendo_max")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("nendo_max"), "", "", DataViewRowState.CurrentRows)
        If Not IsDBNull(DtView1(0)("nendo_max")) = True Then
            Return DtView1(0)("nendo_max")
        Else
            Return 0
        End If
    End Function

    '********************************************************************
    '**  受付番号の採番 
    '********************************************************************
    Public Function Count_Get(ByVal T2 As String) As String
        Dim WK_cnt As String
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT FROM S01_count WHERE (CNT_NO = '" & T2 & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsList1, "Count001")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Count001"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO S01_count"
            strSQL += " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL += " VALUES ('" & T2 & "', 1, '加入番号')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return T2 & "-00001"
        Else
            If DtView1(0)("CNT") = 99999 Then
                MessageBox.Show("加入番号エラー：システム管理者にお問い合わせください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return 0
            Else
                strSQL = "UPDATE S01_count"
                strSQL += " SET CNT  = CNT  + 1"
                strSQL += " WHERE (CNT_NO  = '" & T2 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nQGCare")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                WK_cnt = DtView1(0)("CNT") + 1
                Return T2 & "-" & WK_cnt.PadLeft(5, "0")
            End If
        End If
    End Function
    Public Function Count_Get2(ByVal T2 As String) As Integer
        Dim WK_cnt As Integer
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT FROM S01_count WHERE (CNT_NO = '" & T2 & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsList1, "Count001")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Count001"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO S01_count"
            strSQL += " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL += " VALUES ('" & T2 & "', 1, '取込み№')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return 1
        Else
            strSQL = "UPDATE S01_count"
            strSQL += " SET CNT  = CNT  + 1"
            strSQL += " WHERE (CNT_NO  = '" & T2 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            WK_cnt = DtView1(0)("CNT") + 1
            Return WK_cnt
        End If
    End Function

    '********************************************************************
    '**  加入料金取得
    '********************************************************************
    Public Function wrn_fee_Get(ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As Integer) As Integer

        If P1 <> Nothing And P2 <> Nothing And P3 <> Nothing And P4 <> Nothing And P5 <> 0 Then
            DsList1.Clear()
            strSQL = "SELECT amnt FROM M03_amnt"
            strSQL += " WHERE (nendo = " & P5 & ")"
            strSQL += " AND (ittpan = '" & P1 & "')"
            If P2 = "01" Then
                strSQL += " AND (apple = '1')"
            Else
                strSQL += " AND (apple = '0')"
            End If
            strSQL += " AND (wrn_tem = " & P3 & ")"
            strSQL += " AND (wrn_range = " & P4 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(DsList1, "M03_amnt")
            DB_CLOSE()

            If r <> 0 Then
                DtView1 = New DataView(DsList1.Tables("M03_amnt"), "", "", DataViewRowState.CurrentRows)
                Return DtView1(0)("amnt")
            Else
                Return 0
            End If
        Else
            Return 0
        End If

    End Function

    '********************************************************************
    '**  保証終期取得
    '********************************************************************
    Public Function wrn_end_Get(ByVal P1 As Integer, ByVal P2 As Date) As String

        If P1 <> Nothing And P2 <> Nothing Then
            Return DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, P1, P2))
        Else
            Return Nothing
        End If

    End Function

    '********************************************************************
    '**  伝票到着予定日取得
    '********************************************************************
    Public Function neva_arr_date_Get(ByVal P1 As Date) As Date
        Dim to_date As Date
        Dim WK_int As Integer

        If P1 <> Nothing Then
            DsList1.Clear()
            strSQL = "SELECT cls_code_name FROM M02_cls WHERE (cls = 'arr') AND (cls_code = 1)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "cls_arr")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("cls_arr"), "", "", DataViewRowState.CurrentRows)
            WK_int = DtView1(0)("cls_code_name") - 1
            to_date = DateAdd(DateInterval.Month, 2, P1)

            strSQL = "SELECT M22_CLND.*"
            strSQL += " FROM M22_CLND"
            strSQL += " WHERE (hldy_flg = 0)"
            strSQL += " AND (clnd_date > CONVERT(DATETIME, '" & P1 & "', 102)"
            strSQL += " AND clnd_date < CONVERT(DATETIME, '" & to_date & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "M22_CLND")
            DB_CLOSE()
            DtView2 = New DataView(DsList1.Tables("M22_CLND"), "", "", DataViewRowState.CurrentRows)

            'Return DtView2(WK_int)("clnd_date")
        Else
            Return Nothing
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
                    'If cls = "01" Then  'A4
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
                    'Else
                    '    If p = DtView1(0)("printer_name") Then
                    '        Return DtView1(0)("printer_name")
                    '        Exit For
                    '    End If
                    'End If
                Next
            End If
        End If
        Return Nothing
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
    '**  四捨五入
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
    '**  切り上げ
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
        Return Trim(str.Replace(System.Environment.NewLine, " "))
    End Function

    '********************************************************************
    '**  カンマをスペースに置き換え
    '********************************************************************
    Public Function comma_Cng(ByVal str As String) As String
        Return Trim(str.Replace(",", " "))
    End Function

    '********************************************************************
    '**  数値のみに変換
    '********************************************************************
    Public Function nmc_Cng(ByVal str As String) As String
        str = Trim(str)
        WK_str = Nothing
        If str <> Nothing Then
            Dim wkn1 As Integer = Len(str)
            For i = 1 To wkn1
                If Mid(str, 1, 1) >= "0" And Mid(str, 1, 1) <= "9" Then
                    WK_str = WK_str & Mid(str, 1, 1)
                End If
                str = Mid(str, 2, wkn1)
            Next
            Return WK_str
        Else
            Return ""
        End If
    End Function
End Module