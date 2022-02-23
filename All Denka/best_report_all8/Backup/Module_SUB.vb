Module Module_SUB
    Public P_Pram, P_Rtn As String

    Public P_int1, P_int2 As Integer

    Public Function GET_wrn_fee(ByVal wrn_prod As Integer, ByVal item_cat_code As String) As String
        If wrn_prod = 96 Then '8年保証
            Select Case item_cat_code
                Case Is = "100501", "100502", "100503", "100504"
                    P_int1 = 7143
                    P_int2 = 7500
                    Return "0310"
                Case Is = "100601"
                    P_int1 = 9334
                    P_int2 = 9800
                    Return "0320"
                Case Is = "100602", "100603", "100604"
                    P_int1 = 23334
                    P_int2 = 24500
                    Return "0330"
                Case Else
                    'If DtView1(i)("wrn_fee_tax_ORG") < 10000 Then
                    P_int1 = 0
                    P_int2 = 0
                    Return "0320"
                    'Else
                    '    Return "0330"
                    '    P_int1 = 0
                    '    P_int2 = 0
                    'End If
            End Select
        Else                                '10年保証
            Select Case item_cat_code
                Case Is = "100501", "100502", "100503", "100504"
                    P_int1 = 8572
                    P_int2 = 9000
                    Return "0311"
                Case Is = "100601"
                    P_int1 = 10477
                    P_int2 = 11000
                    Return "0321"
                Case Is = "100602", "100603"
                    P_int1 = 26667
                    P_int2 = 28000
                    Return "0331"
                Case Is = "100604", "100605"
                    P_int1 = 0
                    P_int2 = 0
                    Return "0332"
                Case Else
                    P_int1 = 0
                    P_int2 = 0
                    Return "0332"
            End Select
        End If

    End Function



    Public Function IsDate(ByVal YearPart As Object, ByVal MonthPart As Object, ByVal DayPart As Object) As Boolean

        If IsNumeric(YearPart) And IsNumeric(MonthPart) And IsNumeric(DayPart) Then
            If CInt(YearPart) > DateTime.MaxValue.Year OrElse _
              CInt(MonthPart) > DateTime.MaxValue.Month OrElse _
              CInt(DayPart) > DateTime.MaxValue.Day OrElse _
              CInt(YearPart) < DateTime.MinValue.Year OrElse _
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
        Dim wkn2 As Decimal
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
        Dim wkn2 As Decimal
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

    Function es(ByVal s)
        Const One = 1

        Dim r

        Dim t
        t = VarType(s)

        If t = 0 Then ' vbEmpty
            r = "''"
        ElseIf t = 1 Then ' vbNull
            r = "NULL"
        ElseIf t = 2 Or t = 3 Or t = 4 Or t = 5 Or t = 6 Then
            ' vbInteger=2, vbLong=3, vbSingle=4, vbDouble=5, vbCurrency=6
            r = s
        ElseIf t = 7 Then ' vbDate
            Const dbtype = 1 ' 通常の ADO での使用ならば 1 で良いでしょう。
            If dbtype = 1 Then
                ' ODBC や OLEDB 用の標準の日付形式(MS SQL Server を ODBC や OLEDB 経由で使う場合も含む)
                ' "{ts 'yyyy-mm-dd hh:mm:ss'}" (前 0 詰めは必須)
                r = "{ts '" & Right("000" & Year(s), 4) & "-" & Right("0" & Month(s), 2) & "-" & Right("0" & Format(s, "dd"), 2) & " " & _
                    Right("0" & Hour(s), 2) & ":" & Right("0" & Minute(s), 2) & ":" & Right("0" & Second(s), 2) & "'}"
            ElseIf dbtype = 2 Then
                ' MS Access(Jet) のネイティブな標準の日付形式
                '#dd Month Year hh:mm:ss#
                Const MonthString = "JanFebMarAprMayJunJulAugSepOctNovDec"
                r = "#" & Right("0" & Format(s, "dd"), 2) & " " & Mid(MonthString, (Month(s) - One) * 3 + One, 3) & " " & Right("000" & Year(s), 4) & " " & _
                    Right("0" & Hour(s), 2) & ":" & Right("0" & Minute(s), 2) & ":" & Right("0" & Second(s), 2) & "#"
            ElseIf dbtype = 3 Then
                ' MS SQL Server のネイティブな標準の日付形式
                ' 'yyyymmdd hh:mm:ss'
                r = "'" & Right("000" & Year(s), 4) & Right("0" & Month(s), 2) & Right("0" & Format(s, "dd"), 2) & " " & _
                    Right("0" & Hour(s), 2) & ":" & Right("0" & Minute(s), 2) & ":" & Right("0" & Second(s), 2) & "'"
            ElseIf dbtype = 4 Then
                ' Oracle のネイティブな標準の日付形式
                ' 'YYYY/MM/DD HH24:MI:SS'
                r = "TO_DATE('" & Right("000" & Year(s), 4) & "/" & Right("0" & Month(s), 2) & "/" & Right("0" & Format(s, "dd"), 2) & " " & _
                    Right("0" & Hour(s), 2) & ":" & Right("0" & Minute(s), 2) & ":" & Right("0" & Second(s), 2) & "', 'YYYY/MM/DD HH24:MI:SS')"
            Else
                r = "'" & s & "'"
            End If
        ElseIf t = 8 Then ' vbString
            r = "'" & Replace(s, "'", "''") & "'"
        ElseIf t = 9 Then ' vbObject
            r = s
        ElseIf t = 10 Then ' vbError
            r = s
        ElseIf t = 11 Then ' vbBoolean
            r = s
        ElseIf t = 12 Then ' vbVariant
            r = s
        ElseIf t = 13 Then ' vbDataObject
            r = s
        Else
            r = s
        End If

        es = r
    End Function

End Module
