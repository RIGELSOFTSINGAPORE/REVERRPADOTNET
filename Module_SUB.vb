Module Module3

    Public P_SqlCmd1 As New SqlClient.SqlCommand
    Public P_DaList1 As New SqlClient.SqlDataAdapter
    Public P_DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim strSQL As String
    Dim r As Integer

    Public Function Count_Get(ByVal cls, ByVal remarks) As Integer

        DB_OPEN()
        P_DsList1.Clear()
        P_SqlCmd1 = New SqlClient.SqlCommand("SELECT seq FROM Count_tbl WHERE (cls = '" & cls & "')", cnsqlclient)
        P_DaList1.SelectCommand = P_SqlCmd1
        P_DaList1.Fill(P_DsList1, "Count001")
        DB_CLOSE()

        DtView1 = New DataView(P_DsList1.Tables("Count001"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO Count_tbl"
            strSQL = strSQL & " (cls, seq, remarks)"
            strSQL = strSQL & " VALUES ('" & cls & "', 1, '" & remarks & "')"
            DB_OPEN()
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return 1
        Else
            strSQL = "UPDATE Count_tbl"
            strSQL = strSQL & " SET seq = seq + 1"
            strSQL = strSQL & " WHERE (cls = '" & cls & "')"
            DB_OPEN()
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return DtView1(0)("seq") + 1
        End If

    End Function

    '**********************************
    '**  è¡îÔê≈ó¶ GET
    '**********************************
    Public Function Tax_rate_Get(ByVal P_date As Date) As Integer

        DB_OPEN()
        P_DsList1.Clear()
        strSQL = "SELECT TOP (1) PERCENT CLS_CODE_NAME"
        strSQL += " FROM CLS_CODE"
        strSQL += " WHERE (CLS_NO = '017') AND (CLS_CODE <= '" & P_date & "')"
        strSQL += " ORDER BY CLS_CODE DESC"
        P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        P_DaList1.SelectCommand = P_SqlCmd1
        r = P_DaList1.Fill(P_DsList1, "cls017")
        DB_CLOSE()

        If r <> 0 Then
            DtView1 = New DataView(P_DsList1.Tables("cls017"), "", "", DataViewRowState.CurrentRows)
            Return DtView1(0)("CLS_CODE_NAME")
        Else
            Return 10
        End If

    End Function

    '********************************************************************
    '**  éléÃå‹ì¸
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
    '**  êÿÇËè„Ç∞
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
    '**  êÿéÃÇƒ
    '********************************************************************
    Public Function RoundDOWN(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        wkn1 = Fix(pdblX * 10 ^ keta)
        Return wkn1 / 10 ^ keta
    End Function
End Module
