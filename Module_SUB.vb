Module Module_SUB
    Public P_SqlCmd1 As New SqlClient.SqlCommand
    Public P_DaList1 As New SqlClient.SqlDataAdapter
    Public P_DsList1 As New DataSet

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet

    Dim DtView1 As DataView
    Dim strSQL As String

    Public P_trbl_code, P_trbl_memo, P_rpar_mome, P_Remarks As String
    'Public P_ordr_no, P_line_no As String
    Public P_seq As Integer

    Public P_rtn As String
    Public P_PRAM1, P_PRAM2, P_PRAM3, P_PRAM4, P_PRAM5, P_PRAM6, P_PRAM7 As String


    Public Function Count_Get(ByVal cls) As Integer

        DB_OPEN("best_wrn")
        P_DsList1.Clear()
        P_SqlCmd1 = New SqlClient.SqlCommand("SELECT seq FROM Count_tbl WHERE (cls = '" & cls & "')", cnsqlclient)
        P_DaList1.SelectCommand = P_SqlCmd1
        P_DaList1.Fill(P_DsList1, "Count001")
        DB_CLOSE()

        DtView1 = New DataView(P_DsList1.Tables("Count001"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO Count_tbl"
            strSQL += " (cls, seq, remarks)"
            strSQL += " VALUES ('" & cls & "', 1, '請求手入力SEQ' )"
            DB_OPEN("best_wrn")
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return 1
        Else
            strSQL = "UPDATE Count_tbl"
            strSQL += " SET seq = seq + 1"
            strSQL += " WHERE (cls = '" & cls & "')"
            DB_OPEN("best_wrn")
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()
            Return DtView1(0)("seq") + 1
        End If

    End Function

    Public Function kakesyu_Get(ByVal kbn_No As String) As String
        DsList1.Clear()
        strSQL = "SELECT kakesyu FROM insurance_co_decision WHERE (kbn_No = '" & kbn_No & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "insurance_co_decision")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("insurance_co_decision"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Return DtView1(0)("kakesyu")
        Else
            Return ""
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

    Public Function RoundDOWN(ByVal pdblX As Decimal, ByVal keta As Integer) As Decimal
        Dim wkn1 As Integer
        wkn1 = Fix(pdblX * 10 ^ keta)
        Return wkn1 / 10 ^ keta
    End Function

    Public Function IsDate(ByVal YearPart As Object, ByVal MonthPart As Object, ByVal DayPart As Object) As Boolean

        If IsNumeric(YearPart) And IsNumeric(MonthPart) And IsNumeric(DayPart) Then
            'If CInt(YearPart) > DateTime.MaxValue.Year OrElse _
            '  CInt(MonthPart) > DateTime.MaxValue.Month OrElse _
            '  CInt(DayPart) > DateTime.MaxValue.Day OrElse _
            '  CInt(YearPart) < DateTime.MinValue.Year OrElse _
            '  CInt(MonthPart) < DateTime.MinValue.Month OrElse _
            '  CInt(DayPart) < DateTime.MinValue.Day Then
            If CInt(YearPart) > 2100 OrElse _
              CInt(MonthPart) > DateTime.MaxValue.Month OrElse _
              CInt(DayPart) > DateTime.MaxValue.Day OrElse _
              CInt(YearPart) < 1997 OrElse _
              CInt(MonthPart) < DateTime.MinValue.Month OrElse _
              CInt(DayPart) < DateTime.MinValue.Day Then
                Return False
            Else
                Select Case CInt(MonthPart)
                    Case 1, 3, 5, 7, 8, 10, 11, 12

                    Case 4, 6, 9
                        If CInt(DayPart) > 30 Then
                            Return False
                        End If
                    Case 2
                        If DateTime.IsLeapYear(CInt(YearPart)) Then
                            If CInt(DayPart) > 29 Then
                                Return False
                            End If
                        Else
                            If CInt(DayPart) > 28 Then
                                Return False
                            End If
                        End If
                End Select
            End If
            Return True
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
