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

    Public Function numeric_check(ByVal i_data)
        Dim i As Integer

        For i = 1 To Len(i_data)
            Select Case Mid(i_data, i, 1)
                Case Is = "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                Case Else
                    Return "NG" : Exit Function
            End Select
        Next
        Return "OK"

    End Function

End Module
