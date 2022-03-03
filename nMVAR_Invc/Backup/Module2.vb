Module Module2
    Sub a()
        'If P_F60_1 = "0" Then   '新規
        '    P_PRAM1 = Count_Get2()
        '    Edit1.Text = P_PRAM1
        '    P_F60_1 = P_PRAM1

        '    DtView2 = New DataView(P_DsList1.Tables("scan"), "invc_code ='" & P_F60_3 & "' AND invc_no = 0", "", DataViewRowState.CurrentRows)
        '    For i = 0 To DtView2.Count - 1
        '        '請求データ作成
        '        strSQL = "INSERT INTO T20_INVC_MTR"
        '        strSQL = strSQL & " (iｎvc_no, rcpt_brch_code, cls, invc_code, invc_date, bf_amnt, amnt1, tax, ttl_amnt"
        '        strSQL = strSQL & ", invc_amnt, cnt, tax_rate, dlvr_no, etmt_no, article_name"
        '        strSQL = strSQL & ", cnt2, cnt3, cnt4, cnt5, cnt6, cnt7, cnt8, cnt9, cnt10"
        '        strSQL = strSQL & ", unit2, unit3, unit4, unit5, unit6, unit7, unit8, unit9, unit10"
        '        strSQL = strSQL & ", amnt2, amnt3, amnt4, amnt5, amnt6, amnt7, amnt8, amnt9, amnt10"
        '        strSQL = strSQL & ", tekiyou1, tekiyou2, tekiyou3, tekiyou4, tekiyou5, tekiyou6, tekiyou7, tekiyou8, tekiyou9, tekiyou10"
        '        strSQL = strSQL & ", memo, invc_empl_name, bank_code)"
        '        strSQL = strSQL & " VALUES (" & P_PRAM1 & ""
        '        strSQL = strSQL & ", '" & DtView2(i)("rcpt_brch_code") & "'"
        '        strSQL = strSQL & ", '1'"
        '        strSQL = strSQL & ", '" & P_F60_3 & "'"
        '        strSQL = strSQL & ", CONVERT(DATETIME, '" & P_F60_4 & "', 102)"
        '        strSQL = strSQL & ", 0"
        '        strSQL = strSQL & ", " & DtView2(i)("amnt1")
        '        strSQL = strSQL & ", " & DtView2(i)("tax")
        '        strSQL = strSQL & ", " & DtView2(i)("ttl_amnt")
        '        strSQL = strSQL & ", " & DtView2(i)("invc_amnt")
        '        strSQL = strSQL & ", " & DtView2(i)("cnt")
        '        strSQL = strSQL & ", " & DtView2(i)("tax_rate")
        '        strSQL = strSQL & ", '" & Edit2.Text & "'"
        '        strSQL = strSQL & ", '" & Edit3.Text & "'"
        '        strSQL = strSQL & ", '" & Edit0.Text & "'"
        '        strSQL = strSQL & ", " & Number02.Value & ""
        '        strSQL = strSQL & ", " & Number03.Value & ""
        '        strSQL = strSQL & ", " & Number04.Value & ""
        '        strSQL = strSQL & ", " & Number05.Value & ""
        '        strSQL = strSQL & ", " & Number06.Value & ""
        '        strSQL = strSQL & ", " & Number07.Value & ""
        '        strSQL = strSQL & ", " & Number08.Value & ""
        '        strSQL = strSQL & ", " & Number09.Value & ""
        '        strSQL = strSQL & ", " & Number10.Value & ""
        '        strSQL = strSQL & ", " & Number12.Value & ""
        '        strSQL = strSQL & ", " & Number13.Value & ""
        '        strSQL = strSQL & ", " & Number14.Value & ""
        '        strSQL = strSQL & ", " & Number15.Value & ""
        '        strSQL = strSQL & ", " & Number16.Value & ""
        '        strSQL = strSQL & ", " & Number17.Value & ""
        '        strSQL = strSQL & ", " & Number18.Value & ""
        '        strSQL = strSQL & ", " & Number19.Value & ""
        '        strSQL = strSQL & ", " & Number20.Value & ""
        '        strSQL = strSQL & ", " & Number22.Value & ""
        '        strSQL = strSQL & ", " & Number23.Value & ""
        '        strSQL = strSQL & ", " & Number24.Value & ""
        '        strSQL = strSQL & ", " & Number25.Value & ""
        '        strSQL = strSQL & ", " & Number26.Value & ""
        '        strSQL = strSQL & ", " & Number27.Value & ""
        '        strSQL = strSQL & ", " & Number28.Value & ""
        '        strSQL = strSQL & ", " & Number29.Value & ""
        '        strSQL = strSQL & ", " & Number30.Value & ""
        '        strSQL = strSQL & ", '" & Edit01.Text & "'"
        '        strSQL = strSQL & ", '" & Edit02.Text & "'"
        '        strSQL = strSQL & ", '" & Edit03.Text & "'"
        '        strSQL = strSQL & ", '" & Edit04.Text & "'"
        '        strSQL = strSQL & ", '" & Edit05.Text & "'"
        '        strSQL = strSQL & ", '" & Edit06.Text & "'"
        '        strSQL = strSQL & ", '" & Edit07.Text & "'"
        '        strSQL = strSQL & ", '" & Edit08.Text & "'"
        '        strSQL = strSQL & ", '" & Edit09.Text & "'"
        '        strSQL = strSQL & ", '" & Edit10.Text & "'"
        '        strSQL = strSQL & ", '" & Edit4.Text & "'"
        '        strSQL = strSQL & ", '" & Edit5.Text & "'"
        '        strSQL = strSQL & ", " & CL002.Text & ")"
        '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '        DB_OPEN("nMVAR")
        '        SqlCmd1.ExecuteNonQuery()
        '        DB_CLOSE()

        '        WK_DsList1.Clear()
        '        SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_6", cnsqlclient)
        '        SqlCmd1.CommandType = CommandType.StoredProcedure
        '        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
        '        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        '        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 2)
        '        Pram1.Value = P_F60_3
        '        Pram2.Value = P_F60_4
        '        Pram3.Value = DtView2(i)("rcpt_brch_code")
        '        DaList1.SelectCommand = SqlCmd1
        '        DB_OPEN("nMVAR")
        '        DaList1.Fill(WK_DsList1, "Print01")
        '        DB_CLOSE()

        '        DtView3 = New DataView(WK_DsList1.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        '        For j = 0 To DtView3.Count - 1
        '            DB_OPEN("nMVAR")
        '            '請求詳細データ作成
        '            strSQL = "INSERT INTO T21_INVC_SUB"
        '            strSQL = strSQL & " (iｎvc_no, brch_code, rcpt_no, invc_amnt, cxl_flg, fin_flg)"
        '            strSQL = strSQL & " VALUES (" & P_PRAM1 & ""
        '            strSQL = strSQL & ", '" & DtView3(j)("rcpt_brch_code") & "'"
        '            strSQL = strSQL & ", '" & DtView3(j)("rcpt_no") & "'"
        '            strSQL = strSQL & ", " & DtView3(j)("sals_amnt") & ""
        '            strSQL = strSQL & ", 0, 0)"
        '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '            SqlCmd1.ExecuteNonQuery()

        '            '受付テーブルに請求日更新
        '            strSQL = "UPDATE T01_REP_MTR"
        '            strSQL = strSQL & " SET rqst_date = '" & P_F60_4 & "'"
        '            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
        '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '            SqlCmd1.ExecuteNonQuery()

        '            '売上データ請求済フラグON
        '            strSQL = "UPDATE T10_SALS"
        '            strSQL = strSQL & " SET invc_flg = 1"
        '            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
        '            strSQL = strSQL & " AND (cls = '1')"
        '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '            SqlCmd1.ExecuteNonQuery()

        '            '印刷履歴テーブル更新
        '            strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
        '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '            DaList1.SelectCommand = SqlCmd1
        '            DaList1.Fill(DsList1, "T06_PRNT_DATE")
        '            DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        '            If DtView1.Count = 0 Then
        '                strSQL = "INSERT INTO T06_PRNT_DATE"
        '                strSQL = strSQL & " (rcpt_no, IVC)"
        '                strSQL = strSQL & " VALUES ('" & DtView3(j)("rcpt_no") & "'"
        '                strSQL = strSQL & ", '" & P_HSTY_DATE & "')"
        '                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '                SqlCmd1.ExecuteNonQuery()
        '            Else
        '                If IsDBNull(DtView1(0)("IVC")) Then
        '                    strSQL = "UPDATE T06_PRNT_DATE"
        '                    strSQL = strSQL & " SET IVC = '" & P_HSTY_DATE & "'"
        '                    strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
        '                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '                    SqlCmd1.ExecuteNonQuery()
        '                End If
        '            End If
        '            DB_CLOSE()

        '            '変更履歴更新
        '            WK_str = P_F60_4
        '            add_hsty(DtView3(j)("rcpt_no"), "請求日", "", WK_str)

        '        Next
        '    Next

        'Else                        '再印刷
        '    P_PRAM1 = P_F60_1

        '    '請求データ更新
        '    strSQL = "UPDATE T20_INVC_MTR"
        '    strSQL = strSQL & " SET dlvr_no = '" & Edit2.Text & "'"
        '    strSQL = strSQL & ", etmt_no = '" & Edit3.Text & "'"
        '    strSQL = strSQL & ", article_name = '" & Edit0.Text & "'"
        '    strSQL = strSQL & ", cnt2 = " & Number02.Value & ""
        '    strSQL = strSQL & ", cnt3 = " & Number03.Value & ""
        '    strSQL = strSQL & ", cnt4 = " & Number04.Value & ""
        '    strSQL = strSQL & ", cnt5 = " & Number05.Value & ""
        '    strSQL = strSQL & ", cnt6 = " & Number06.Value & ""
        '    strSQL = strSQL & ", cnt7 = " & Number07.Value & ""
        '    strSQL = strSQL & ", cnt8 = " & Number08.Value & ""
        '    strSQL = strSQL & ", cnt9 = " & Number09.Value & ""
        '    strSQL = strSQL & ", cnt10 = " & Number10.Value & ""
        '    strSQL = strSQL & ", unit2 = " & Number12.Value & ""
        '    strSQL = strSQL & ", unit3 = " & Number13.Value & ""
        '    strSQL = strSQL & ", unit4 = " & Number14.Value & ""
        '    strSQL = strSQL & ", unit5 = " & Number15.Value & ""
        '    strSQL = strSQL & ", unit6 = " & Number16.Value & ""
        '    strSQL = strSQL & ", unit7 = " & Number17.Value & ""
        '    strSQL = strSQL & ", unit8 = " & Number18.Value & ""
        '    strSQL = strSQL & ", unit9 = " & Number19.Value & ""
        '    strSQL = strSQL & ", unit10 = " & Number10.Value & ""
        '    strSQL = strSQL & ", amnt2 = " & Number22.Value & ""
        '    strSQL = strSQL & ", amnt3 = " & Number23.Value & ""
        '    strSQL = strSQL & ", amnt4 = " & Number24.Value & ""
        '    strSQL = strSQL & ", amnt5 = " & Number25.Value & ""
        '    strSQL = strSQL & ", amnt6 = " & Number26.Value & ""
        '    strSQL = strSQL & ", amnt7 = " & Number27.Value & ""
        '    strSQL = strSQL & ", amnt8 = " & Number28.Value & ""
        '    strSQL = strSQL & ", amnt9 = " & Number29.Value & ""
        '    strSQL = strSQL & ", amnt10 = " & Number30.Value & ""
        '    strSQL = strSQL & ", tekiyou1 = '" & Edit01.Text & "'"
        '    strSQL = strSQL & ", tekiyou2 = '" & Edit02.Text & "'"
        '    strSQL = strSQL & ", tekiyou3 = '" & Edit03.Text & "'"
        '    strSQL = strSQL & ", tekiyou4 = '" & Edit04.Text & "'"
        '    strSQL = strSQL & ", tekiyou5 = '" & Edit05.Text & "'"
        '    strSQL = strSQL & ", tekiyou6 = '" & Edit06.Text & "'"
        '    strSQL = strSQL & ", tekiyou7 = '" & Edit07.Text & "'"
        '    strSQL = strSQL & ", tekiyou8 = '" & Edit08.Text & "'"
        '    strSQL = strSQL & ", tekiyou9 = '" & Edit09.Text & "'"
        '    strSQL = strSQL & ", tekiyou10 = '" & Edit10.Text & "'"
        '    strSQL = strSQL & ", memo = '" & Edit4.Text & "'"
        '    strSQL = strSQL & ", invc_empl_name = '" & Edit5.Text & "'"
        '    strSQL = strSQL & ", bank_code = " & CL002.Text & ""
        '    strSQL = strSQL & " WHERE (iｎvc_no = " & P_PRAM1 & ")"
        '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '    DB_OPEN("nMVAR")
        '    SqlCmd1.ExecuteNonQuery()
        '    DB_CLOSE()
        'End If

        ''********************
        ''** 印刷
        ''********************
        'WK_DsList1.Clear()
        'If P_F60_2 = Nothing Then   '拠点まとめ
        '    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_2m", cnsqlclient)
        '    SqlCmd1.CommandType = CommandType.StoredProcedure
        '    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
        '    Pram1.Value = P_F60_1

        'Else
        '    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_2", cnsqlclient)
        '    SqlCmd1.CommandType = CommandType.StoredProcedure
        '    Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
        '    Pram5.Value = P_F60_1
        'End If
        'DaList1.SelectCommand = SqlCmd1
        'SqlCmd1.CommandTimeout = 600
        'DB_OPEN("nMVAR")
        'DaList1.Fill(WK_DsList1, "WK_prt")
        'DB_CLOSE()

        'DtView2 = New DataView(WK_DsList1.Tables("WK_prt"), "", "", DataViewRowState.CurrentRows)

        'P_DsPRT.Clear()
        'strSQL = "SELECT " & P_PRAM1 & " AS invc_no"
        'strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("invc_zip"), 1, 3) & "-" & Mid(DtView2(0)("invc_zip"), 4, 4) & "' AS invc_zip"
        'strSQL = strSQL & ", '" & DtView2(0)("invc_adrs1") & System.Environment.NewLine & DtView2(0)("invc_adrs2") & "' AS invc_adrs"
        'strSQL = strSQL & ", '" & DtView2(0)("invc_name") & "' AS invc_name"

        'strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("brch_zip"), 1, 3) & "-" & Mid(DtView2(0)("brch_zip"), 4, 4) & "' AS brch_zip"
        'strSQL = strSQL & ", '" & DtView2(0)("brch_adrs1") & System.Environment.NewLine & DtView2(0)("brch_adrs2") & "' AS brch_adrs"
        'strSQL = strSQL & ", '" & DtView2(0)("brch_name") & "' AS brch_name"
        'strSQL = strSQL & ", 'TEL " & DtView2(0)("brch_tel") & "  FAX " & DtView2(0)("brch_fax") & "' AS brch_tel"

        'strSQL = strSQL & ", '" & DtView2(0)("bank_user") & "' AS bank_user"

        'If Not IsDBNull(DtView2(0)("bank_kbn")) Then
        '    If DtView2(0)("bank_kbn") = "普通預金" Then
        '        strSQL = strSQL & ", '" & DtView2(0)("bank_name") & "　" & DtView2(0)("bank_sub") & "　(普)　NO." & DtView2(0)("bank_acnt_no") & "' AS bank_name"
        '    Else
        '        strSQL = strSQL & ", '" & DtView2(0)("bank_name") & "　" & DtView2(0)("bank_sub") & "　(当)　NO." & DtView2(0)("bank_acnt_no") & "' AS bank_name"
        '    End If
        'End If

        'strSQL = strSQL & ", '" & DtView2(0)("dlvr_no") & "' AS dlvr_no"            '納品書番号
        'strSQL = strSQL & ", '" & DtView2(0)("etmt_no") & "' AS etmt_no"            '貴社見積番号
        'strSQL = strSQL & ", '" & DtView2(0)("article_name") & "' AS article_name"  '品名
        'strSQL = strSQL & ", '" & DtView2(0)("memo") & "' AS memo"                  'メモ
        'strSQL = strSQL & ", '" & DtView2(0)("invc_empl_name") & "' AS empl_name"        '請求担当

        'strSQL = strSQL & ", " & Number01.Value & " AS cnt1"                        '個数
        'strSQL = strSQL & ", " & DtView2(0)("cnt2") & " AS cnt2"
        'strSQL = strSQL & ", " & DtView2(0)("cnt3") & " AS cnt3"
        'strSQL = strSQL & ", " & DtView2(0)("cnt4") & " AS cnt4"
        'strSQL = strSQL & ", " & DtView2(0)("cnt5") & " AS cnt5"
        'strSQL = strSQL & ", " & DtView2(0)("cnt6") & " AS cnt6"
        'strSQL = strSQL & ", " & DtView2(0)("cnt7") & " AS cnt7"
        'strSQL = strSQL & ", " & DtView2(0)("cnt8") & " AS cnt8"
        'strSQL = strSQL & ", " & DtView2(0)("cnt9") & " AS cnt9"
        'strSQL = strSQL & ", " & DtView2(0)("cnt10") & " AS cnt10"
        'strSQL = strSQL & ", " & DtView2(0)("unit2") & " AS unit2"                  '単価
        'strSQL = strSQL & ", " & DtView2(0)("unit3") & " AS unit3"
        'strSQL = strSQL & ", " & DtView2(0)("unit4") & " AS unit4"
        'strSQL = strSQL & ", " & DtView2(0)("unit5") & " AS unit5"
        'strSQL = strSQL & ", " & DtView2(0)("unit6") & " AS unit6"
        'strSQL = strSQL & ", " & DtView2(0)("unit7") & " AS unit7"
        'strSQL = strSQL & ", " & DtView2(0)("unit8") & " AS unit8"
        'strSQL = strSQL & ", " & DtView2(0)("unit9") & " AS unit9"
        'strSQL = strSQL & ", " & DtView2(0)("unit10") & " AS unit10"
        'If DtView2(0)("amnt1") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt1"), "##,##0") & "' AS amnt1"               '金額
        'Else
        '    strSQL = strSQL & ", '' AS amnt1"
        'End If
        'amt_sum = DtView2(0)("amnt1")

        'If DtView2(0)("amnt2") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt2"), "##,##0") & "' AS amnt2"
        'Else
        '    strSQL = strSQL & ", '' AS amnt2"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt2")
        'If DtView2(0)("amnt3") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt3"), "##,##0") & "' AS amnt3"
        'Else
        '    strSQL = strSQL & ", '' AS amnt3"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt3")
        'If DtView2(0)("amnt4") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt4"), "##,##0") & "' AS amnt4"
        'Else
        '    strSQL = strSQL & ", '' AS amnt4"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt4")
        'If DtView2(0)("amnt5") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt5"), "##,##0") & "' AS amnt5"
        'Else
        '    strSQL = strSQL & ", '' AS amnt5"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt5")
        'If DtView2(0)("amnt6") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt6"), "##,##0") & "' AS amnt6"
        'Else
        '    strSQL = strSQL & ", '' AS amnt6"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt6")
        'If DtView2(0)("amnt7") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt7"), "##,##0") & "' AS amnt7"
        'Else
        '    strSQL = strSQL & ", '' AS amnt7"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt7")
        'If DtView2(0)("amnt8") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt8"), "##,##0") & "' AS amnt8"
        'Else
        '    strSQL = strSQL & ", '' AS amnt8"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt8")
        'If DtView2(0)("amnt9") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt9"), "##,##0") & "' AS amnt9"
        'Else
        '    strSQL = strSQL & ", '' AS amnt9"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt9")
        'If DtView2(0)("amnt10") <> 0 Then
        '    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt10"), "##,##0") & "' AS amnt10"
        'Else
        '    strSQL = strSQL & ", '' AS amnt10"
        'End If
        'amt_sum = amt_sum + DtView2(0)("amnt10")

        'strSQL = strSQL & ", " & amt_sum & " AS sttl"
        'strSQL = strSQL & ", " & RoundDOWN(amt_sum * 0.08, 0) & " AS tax"
        'strSQL = strSQL & ", " & amt_sum + RoundDOWN(amt_sum * 0.08, 0) & " AS gttl"

        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou1") & "' AS tekiyou1"              '摘要
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou2") & "' AS tekiyou2"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou3") & "' AS tekiyou3"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou4") & "' AS tekiyou4"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou5") & "' AS tekiyou5"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou6") & "' AS tekiyou6"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou7") & "' AS tekiyou7"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou8") & "' AS tekiyou8"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou9") & "' AS tekiyou9"
        'strSQL = strSQL & ", '" & DtView2(0)("tekiyou10") & "' AS tekiyou10"

        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(P_DsPRT, "prt")

        ''請求書
        'P_PView = "ivc"

        'Dim Print_View As New Print_View
        'Print_View.ShowDialog()

        ''請求明細
        'P_DsPRT.Clear()
        'strSQL = "SELECT T20_INVC_MTR.iｎvc_no, T20_INVC_MTR.invc_code, M08_STORE.name AS invc_name, T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no, T01_REP_MTR.store_repr_no, T01_REP_MTR.vndr_code, M05_VNDR.name AS vndr_name, T01_REP_MTR.user_name, T01_REP_MTR.sals_no, T21_INVC_SUB.invc_amnt, M08_STORE.invc_dtl_ptn, T20_INVC_MTR.invc_date, T20_INVC_MTR.rcpt_brch_code, M03_BRCH.name AS rcpt_brch_name, T01_REP_MTR.store_code, M08_STORE_1.name AS store_name, T01_REP_MTR.kjo_brch_code, M03_BRCH_1.name AS kjo_brch_name"
        'strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
        'strSQL = strSQL & " T21_INVC_SUB ON T20_INVC_MTR.iｎvc_no = T21_INVC_SUB.iｎvc_no AND"
        'strSQL = strSQL & " T20_INVC_MTR.rcpt_brch_code = T21_INVC_SUB.brch_code INNER JOIN"
        'strSQL = strSQL & " T01_REP_MTR ON T21_INVC_SUB.rcpt_no = T01_REP_MTR.rcpt_no INNER JOIN"
        'strSQL = strSQL & " M05_VNDR ON T01_REP_MTR.vndr_code = M05_VNDR.vndr_code INNER JOIN"
        'strSQL = strSQL & " M08_STORE ON T20_INVC_MTR.invc_code = M08_STORE.store_code INNER JOIN"
        'strSQL = strSQL & " M08_STORE AS M08_STORE_1 ON T01_REP_MTR.store_code = M08_STORE_1.store_code INNER JOIN"
        'strSQL = strSQL & " M03_BRCH ON T20_INVC_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
        'strSQL = strSQL & " M03_BRCH AS M03_BRCH_1 ON T01_REP_MTR.kjo_brch_code = M03_BRCH_1.brch_code"
        'strSQL = strSQL & " WHERE (T20_INVC_MTR.iｎvc_no = " & P_F60_1 & ")"
        'Select Case P_F60_10
        '    Case Is = "02"  '汎用2
        '        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
        '    Case Is = "03"  'ジョーシンサービス
        '        strSQL = strSQL & " ORDER BY T01_REP_MTR.vndr_code, T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
        '    Case Is = "04"  'ケーズデンキ
        '        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
        '    Case Is = "05"  'デオデオ
        '        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
        '    Case Is = "06"  'ベスト
        '        strSQL = strSQL & " ORDER BY T01_REP_MTR.store_code, T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
        '    Case Is = "07"  'ヨドバシカメラ
        '        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
        '    Case Else       '汎用
        '        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
        'End Select
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'SqlCmd1.CommandTimeout = 600
        'DB_OPEN("nMVAR")
        'r = DaList1.Fill(P_DsPRT, "prt")
        'DB_CLOSE()

        'If r <> 0 Then
        '    '請求明細
        '    P_PView = "DTL"

        '    Dim Print_View2 As New Print_View
        '    Print_View2.ShowDialog()
        'End If

        '    Else

    End Sub

End Module
