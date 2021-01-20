Module Module3

    Public P_SqlCmd1 As New SqlClient.SqlCommand
    Public P_DaList1 As New SqlClient.SqlDataAdapter
    Public P_DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim strSQL As String

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

    ''**********************************
    ''**  SB èàóùî‘çÜçÃî‘
    ''**********************************
    'Function SB_seq_get(ByVal SB_cls) As Integer
    '    WK_DsList1.Clear()
    '    strSQL = "SELECT SB_seq FROM SB_seq WHERE (SB_cls = '" & SB_cls & "') AND (SB_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
    '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '    DaList1.SelectCommand = SqlCmd1
    '    DB_OPEN()
    '    r = DaList1.Fill(WK_DsList1, "SB_seq")
    '    DB_CLOSE()

    '    If r = 0 Then
    '        strSQL = "SELECT MAX(SB_seq) AS MAX_seq FROM SB_seq WHERE (SB_cls = '" & SB_cls & "')"
    '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '        DaList1.SelectCommand = SqlCmd1
    '        DB_OPEN()
    '        DaList1.Fill(WK_DsList1, "MAX_seq")
    '        DB_CLOSE()
    '        WK_DtView1 = New DataView(WK_DsList1.Tables("MAX_seq"), "", "", DataViewRowState.CurrentRows)
    '        If IsDBNull(WK_DtView1(0)("MAX_seq")) Then
    '            WK_seq = 1
    '        Else
    '            WK_seq = WK_DtView1(0)("MAX_seq") + 1
    '        End If

    '        strSQL = "INSERT INTO SB_seq (SB_cls, SB_date, SB_seq)"
    '        strSQL += " VALUES ('" & SB_cls & "'"
    '        strSQL += ", CONVERT(DATETIME, '" & Label01.Text & "', 102)"
    '        strSQL += ", " & WK_seq & ")"
    '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '        DB_OPEN()
    '        SqlCmd1.ExecuteNonQuery()
    '        DB_CLOSE()

    '        SB_seq_get = WK_seq
    '    Else
    '        WK_DtView1 = New DataView(WK_DsList1.Tables("SB_seq"), "", "", DataViewRowState.CurrentRows)
    '        SB_seq_get = WK_DtView1(0)("SB_seq")
    '    End If
    'End Function

End Module
