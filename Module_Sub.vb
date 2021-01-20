Module Module_Sub
    Public P_SqlCmd1 As New SqlClient.SqlCommand
    Public P_DaList1 As New SqlClient.SqlDataAdapter
    Public P_DsList1 As New DataSet
    Public P_DtView1 As DataView
    Dim DtView1 As DataView
    Dim strSQL As String

    Public pDate As Date
    Public pEmpl_code, pEmpl_cls, pName, pWrn_no, pMode, dsp_mode As String
    Public p_qName, p_qTel_no As String
    Public pID, pqID As Integer
    Public pIcdt_no As String
    Public pq_mtr_no, pq_no As String
    Public DataSet0 As New DataSet
    Public DtTbl0, DtTbl00 As DataTable
    Public get_qmtr_no, upd_qmtr_no As Integer
    'Public frmform2 As New Form2
    'Public frmform2_S As New Form2_S
    'Public frmform3 As New Form3

    Public P_DsCMB As New DataSet
    Public P_DsPRT As New DataSet
    Public pKANA As String
    Public pPROC, pREPAIR_CODE As String
    Public pPROC_DATE As Date

    Function LenB(ByVal str As String) As Integer
        'Shift JISに変換したときに必要なバイト数を返す
        Return System.Text.Encoding.GetEncoding(932).GetByteCount(str)
    End Function

    Public Function CntStr(ByVal s As String, ByVal org As String) As Long

        Dim i As Integer
        Dim j As Integer
        Dim k As Integer

        k = Len(org)
        i = 1
        j = 0

        Do
            i = InStr(i, s, org)
            If i > 0 Then
                i = i + k
                j = j + 1
            End If
        Loop Until i = 0

        CntStr = j

    End Function

    Public Function Count_Get_007() As Integer
        Dim WK_no As Integer

        DB_OPEN()
        P_DsList1.Clear()
        P_SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT, H_LTR FROM CNT_MTR WHERE (CNT_NO = '007')", cnsqlclient)
        P_DaList1.SelectCommand = P_SqlCmd1
        P_SqlCmd1.CommandTimeout = 600
        P_DaList1.Fill(P_DsList1, "Count007")

        DtView1 = New DataView(P_DsList1.Tables("Count007"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO CNT_MTR"
            strSQL = strSQL & " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL = strSQL & " VALUES ('007', 1, N'受付番号')"
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
            WK_no = 1
        Else
            WK_no = DtView1(0)("CNT") + 1
            strSQL = "UPDATE CNT_MTR"
            strSQL = strSQL & " SET CNT = " & WK_no
            strSQL = strSQL & " WHERE (CNT_NO  = '007')"
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
        End If
        DB_CLOSE()
        Return WK_no

    End Function

    Public Function Count_Get_008() As Integer
        Dim WK_no As Integer

        DB_OPEN()
        P_DsList1.Clear()
        P_SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT, H_LTR FROM CNT_MTR WHERE (CNT_NO = '008')", cnsqlclient)
        P_DaList1.SelectCommand = P_SqlCmd1
        P_SqlCmd1.CommandTimeout = 600
        P_DaList1.Fill(P_DsList1, "Count008")

        DtView1 = New DataView(P_DsList1.Tables("Count008"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO CNT_MTR"
            strSQL = strSQL & " (CNT_NO, CNT, CNT_RMRKS)"
            strSQL = strSQL & " VALUES ('008', 1, N'問合番号')"
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
            WK_no = 1
        Else
            WK_no = DtView1(0)("CNT") + 1
            strSQL = "UPDATE CNT_MTR"
            strSQL = strSQL & " SET CNT = " & WK_no
            strSQL = strSQL & " WHERE (CNT_NO  = '008')"
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
        End If
        DB_CLOSE()
        Return WK_no

    End Function

    Public Function Count_Get2(ByVal cls) As String
        Dim WK_no, WK_seq As String

        DB_OPEN()
        P_DsList1.Clear()
        If cls = "0" Then
            P_SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT FROM CNT_MTR WHERE (CNT_NO = '004')", cnsqlclient)
        Else
            P_SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT FROM CNT_MTR WHERE (CNT_NO = '005')", cnsqlclient)
        End If
        P_DaList1.SelectCommand = P_SqlCmd1
        P_SqlCmd1.CommandTimeout = 600
        P_DaList1.Fill(P_DsList1, "Count")
        DB_CLOSE()

        DtView1 = New DataView(P_DsList1.Tables("Count"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO CNT_MTR"
            strSQL = strSQL & " (CNT_NO, CNT, CNT_RMRKS)"
            If cls = "0" Then
                strSQL = strSQL & " VALUES ('004', 1, N'修理受付番号（引取）')"
            Else
                strSQL = strSQL & " VALUES ('005', 1, N'修理受付番号（出張）')"
            End If
            DB_OPEN()
            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            P_SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            If cls = "0" Then
                Return "80990001"
            Else
                Return "89990001"
            End If

        Else
            If DtView1(0)("CNT") >= 9999 Then
                MessageBox.Show("受付番号エラー：システム管理者にお問い合わせください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return Nothing
            Else
                strSQL = "UPDATE CNT_MTR"
                strSQL = strSQL & " SET CNT = CNT + 1"
                If cls = "0" Then
                    strSQL = strSQL & " WHERE (CNT_NO  = '004')"
                Else
                    strSQL = strSQL & " WHERE (CNT_NO  = '005')"
                End If
                DB_OPEN()
                P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                P_SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                WK_no = DtView1(0)("CNT") + 1
                Select Case Len(WK_no)
                    Case Is = 1
                        WK_no = "000" & WK_no
                    Case Is = 2
                        WK_no = "00" & WK_no
                    Case Is = 3
                        WK_no = "0" & WK_no
                    Case Is = 4
                End Select

                If cls = "0" Then
                    Return "8099" & WK_no
                Else
                    Return "8999" & WK_no
                End If

            End If
        End If

    End Function

    Function CD(ByVal NO) As String
        Dim wk1, wk2, wk3 As Integer
        wk1 = (CInt(Mid(NO, 2, 1)) + CInt(Mid(NO, 4, 1)) + CInt(Mid(NO, 6, 1)) + CInt(Mid(NO, 8, 1)) + CInt(Mid(NO, 10, 1)) + CInt(Mid(NO, 12, 1))) * 3
        wk2 = CInt(Mid(NO, 1, 1)) + CInt(Mid(NO, 3, 1)) + CInt(Mid(NO, 5, 1)) + CInt(Mid(NO, 7, 1)) + CInt(Mid(NO, 9, 1)) + CInt(Mid(NO, 11, 1))
        wk3 = wk1 + wk2

        If CInt(Right(wk3, 1)) <> 0 Then
            Return 10 - CInt(Right(wk3, 1))
        Else
            Return 0
        End If
    End Function

    '経過年月を求める
    Public Function A_YYYYMM(ByVal pDATE As Date) As String
        Dim Y, M, D As Integer

        Y = Now.Year - pDATE.Year
        M = Now.Month - pDATE.Month
        D = Now.Day - pDATE.Day

        If D < 0 Then
            M = M - 1
            If M < 0 Then
                Y = Y - 1
                M = M + 12
            End If
        End If

        Return Y & "/" & M

    End Function

    'Public Function Count_Get_001() As String

    '    DB_OPEN()
    '    P_DsList1.Clear()
    '    P_SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT, H_LTR FROM CNT_MTR WHERE (CNT_NO = '001')", cnsqlclient)
    '    P_DaList1.SelectCommand = P_SqlCmd1
    '    P_DaList1.Fill(P_DsList1, "Count001")
    '    DB_CLOSE()

    '    DtView1 = New DataView(P_DsList1.Tables("Count001"), "", "", DataViewRowState.CurrentRows)
    '    If DtView1.Count = 0 Then
    '        strSQL = "INSERT INTO CNT_MTR"
    '        strSQL = strSQL & " (CNT_NO, CNT, CNT_RMRKS, H_LTR)"
    '        strSQL = strSQL & " VALUES ('001', 1, N'問合番号', 'A')"
    '        DB_OPEN()
    '        P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '        P_SqlCmd1.ExecuteNonQuery()
    '        DB_CLOSE()
    '        Return "A0001"
    '    Else
    '        If DtView1(0)("CNT") = 9999 And Asc(DtView1(0)("H_LTR")) = 90 Then
    '            MessageBox.Show("受付番号エラー：システム管理者にお問い合わせください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Return Nothing
    '        Else
    '            Dim WK_no, WK_seq As String
    '            If DtView1(0)("CNT") = 9999 And Asc(DtView1(0)("H_LTR")) < 90 Then
    '                WK_no = Chr(Asc(DtView1(0)("H_LTR")) + 1)
    '                WK_seq = "1"
    '            Else
    '                WK_no = DtView1(0)("H_LTR")
    '                WK_seq = DtView1(0)("CNT") + 1
    '            End If
    '            Select Case Len(WK_seq)
    '                Case Is = 1
    '                    WK_no = WK_no & "000" & WK_seq
    '                Case Is = 2
    '                    WK_no = WK_no & "00" & WK_seq
    '                Case Is = 3
    '                    WK_no = WK_no & "0" & WK_seq
    '                Case Is = 4
    '                    WK_no = WK_no & WK_seq
    '            End Select

    '            strSQL = "UPDATE CNT_MTR"
    '            If DtView1(0)("CNT") = 9999 And Asc(DtView1(0)("H_LTR")) < 90 Then
    '                strSQL = strSQL & " SET CNT  = 1, H_LTR = '" & Chr(Asc(DtView1(0)("H_LTR")) + 1) & "'"
    '            Else
    '                strSQL = strSQL & " SET CNT  = CNT  + 1"
    '            End If
    '            strSQL = strSQL & " WHERE (CNT_NO  = '001')"
    '            DB_OPEN()
    '            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '            P_SqlCmd1.ExecuteNonQuery()
    '            DB_CLOSE()

    '            Return WK_no
    '        End If
    '    End If

    'End Function

    'Public Function Count_Get() As String

    '    DB_OPEN()
    '    P_DsList1.Clear()
    '    P_SqlCmd1 = New SqlClient.SqlCommand("SELECT CNT, H_LTR FROM CNT_MTR WHERE (CNT_NO = '006')", cnsqlclient)
    '    P_DaList1.SelectCommand = P_SqlCmd1
    '    P_DaList1.Fill(P_DsList1, "Count001")
    '    DB_CLOSE()

    '    DtView1 = New DataView(P_DsList1.Tables("Count001"), "", "", DataViewRowState.CurrentRows)
    '    If DtView1.Count = 0 Then
    '        strSQL = "INSERT INTO CNT_MTR"
    '        strSQL = strSQL & " (CNT_NO, CNT, CNT_RMRKS, H_LTR)"
    '        strSQL = strSQL & " VALUES ('006', 1, N'問合番号', 'A')"
    '        DB_OPEN()
    '        P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '        P_SqlCmd1.ExecuteNonQuery()
    '        DB_CLOSE()
    '        Return "A0001"
    '    Else
    '        If DtView1(0)("CNT") = 9999 And Asc(DtView1(0)("H_LTR")) = 90 Then
    '            MessageBox.Show("受付番号エラー：システム管理者にお問い合わせください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Return Nothing
    '        Else
    '            Dim WK_no, WK_seq As String
    '            If DtView1(0)("CNT") = 9999 And Asc(DtView1(0)("H_LTR")) < 90 Then
    '                WK_no = Chr(Asc(DtView1(0)("H_LTR")) + 1)
    '                WK_seq = "1"
    '            Else
    '                WK_no = DtView1(0)("H_LTR")
    '                WK_seq = DtView1(0)("CNT") + 1
    '            End If
    '            Select Case Len(WK_seq)
    '                Case Is = 1
    '                    WK_no = WK_no & "000" & WK_seq
    '                Case Is = 2
    '                    WK_no = WK_no & "00" & WK_seq
    '                Case Is = 3
    '                    WK_no = WK_no & "0" & WK_seq
    '                Case Is = 4
    '                    WK_no = WK_no & WK_seq
    '            End Select

    '            strSQL = "UPDATE CNT_MTR"
    '            If DtView1(0)("CNT") = 9999 And Asc(DtView1(0)("H_LTR")) < 90 Then
    '                strSQL = strSQL & " SET CNT  = 1, H_LTR = '" & Chr(Asc(DtView1(0)("H_LTR")) + 1) & "'"
    '            Else
    '                strSQL = strSQL & " SET CNT  = CNT  + 1"
    '            End If
    '            strSQL = strSQL & " WHERE (CNT_NO  = '006')"
    '            DB_OPEN()
    '            P_SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '            P_SqlCmd1.ExecuteNonQuery()
    '            DB_CLOSE()

    '            Return WK_no
    '        End If
    '    End If

    'End Function

End Module
