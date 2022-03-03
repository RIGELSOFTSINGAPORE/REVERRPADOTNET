Module Module_Sub
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim strSQL As String
    Dim i As Integer

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
        Return Trim(str.Replace(System.Environment.NewLine, " "))
    End Function

    '********************************************************************
    '**  カンマをスペースに置き換え
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
        strSQL = strSQL & " FROM M41_AP_BNAS INNER JOIN M42_AP_BNAS_SUB ON M41_AP_BNAS.id = M42_AP_BNAS_SUB.id"
        strSQL = strSQL & " WHERE (M42_AP_BNAS_SUB.rpar_comp_code = '" & rpar_comp_code & "')"
        strSQL = strSQL & " AND (M41_AP_BNAS.date_from <= CONVERT(DATETIME, '" & comp_date & "', 102))"
        strSQL = strSQL & " AND (M41_AP_BNAS.date_to >= CONVERT(DATETIME, '" & comp_date & "', 102))"
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

End Module