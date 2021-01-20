Module Module2
    Public P_DsList1 As New DataSet
    Public P_DsCMB As New DataSet
    Public P_DsList2 As New DataSet

    Public P_Error_seq As Decimal
    Public P_Error_msg As String
    Public P_Rtn, P_FLD031 As String
    Public P_close_date As Date


    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet

    Dim DtView1 As DataView
    Dim strSQL As String

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

End Module
