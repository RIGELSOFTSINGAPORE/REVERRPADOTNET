Module Module_Check

    Public P_Ds1 As New DataSet

    Public P_01, P_02, P_03, P_04, P_05, P_06, P_07, P_08, P_09, P_10 As String
    Public P_11, P_12, P_13, P_14, P_15, P_16, P_17, P_18, P_19, P_20 As String
    Public P_21, P_22, P_23, P_24, P_25, P_26, P_27, P_28, P_29, P_30 As String
    Public P_31, P_32, P_33, P_34 As String

    Public P_05_date, P_21_date, P_22_date, P_31_date, P_close_date As Date
    Public P_Limit_money As Integer

    Public P_Err_CODE, P_Err_Msg1, P_Err_Msg2 As String

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim W_Da1 = New SqlClient.SqlDataAdapter
    Dim W_Ds1, W_Ds2, W_Ds4 As New DataSet
    Dim W_DV1, W_DV2, W_DV3 As DataView

    Dim strSQL, Err_F, New_Old As String
    Dim i As Integer

    Dim WK_ordr_no, WK_line_no, WK_insurance_code, WK_Securities_no As String
    Dim WK_seq As Integer
    Dim WK_kbn_No As String

    Public Function P_DsSet()
        P_Ds1.Clear()
        DB_OPEN("best_wrn")

        '証券番号
        strSQL = "SELECT insurance_co_decision.*"
        strSQL +=  " FROM insurance_co_decision"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        W_Da1.Fill(P_Ds1, "insurance_co_decision")

        '保険会社
        strSQL = "SELECT insurance_co_sub.*, insurance_co_mtr.insurance_name"
        strSQL +=  " FROM insurance_co_sub INNER JOIN"
        strSQL +=  " insurance_co_mtr ON"
        strSQL +=  " insurance_co_sub.insurance_code = insurance_co_mtr.insurance_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        W_Da1.Fill(P_Ds1, "insurance_co_sub")

        '店舗
        strSQL = "SELECT shop_code"
        strSQL +=  " FROM Shop_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        W_Da1.Fill(P_Ds1, "Shop_mtr")

        '品種
        strSQL = "SELECT Cat_mtr.*"
        strSQL +=  " FROM Cat_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        W_Da1.Fill(P_Ds1, "Cat_mtr")

        'メーカー
        strSQL = "SELECT vdr_mtr.*"
        strSQL +=  " FROM vdr_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        W_Da1.Fill(P_Ds1, "vdr_mtr")

        '区分
        strSQL = "SELECT CLS_CODE.*"
        strSQL +=  " FROM CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        W_Da1.Fill(P_Ds1, "CLS_CODE")

        DB_CLOSE()
    End Function

    Public Function P_Check_Proc()
        P_Err_CODE = Nothing
        P_Err_Msg1 = Nothing
        P_Err_Msg2 = Nothing

        Call CK01() '保証番号チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK02() '保証番号該当チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK03() '請求区分チェック
        If P_Err_CODE <> Nothing Then Exit Function

        'Call CK04() '請求番号チェック
        'If P_Err_CODE <> Nothing Then Exit Function

        Call CK05() '型式チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK06() '事故状況フラグチェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK07() '修理品製造番号チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK08() '保証番号重複チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK09() '保証番号、型式の該当チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK10() '顧客名チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK11() '保証番号、型式、顧客名（姓）の該当チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK12() '事故日チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call Scan() '対象機種の判別

        Call CK13() '契約状況チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK14() '全損チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK15() '保障期間チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK16() '該当保険会社チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK17() '全損フラグチェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK18() '承認番号チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK19() '事故場所チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK20() '項目有無フラグチェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK21() '修理品購入店チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK22() '修理受付店チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK23() '修理完了店チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK24() '伝票区分チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK25() '修理伝票番号チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK26() '電話番号チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK27() 'メーカーチェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK28() '品種チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK29() '修理受付日チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK30() '修理完了日チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK31() '日付相関チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK32() '出張料チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK33() '作業料チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK34() '部品料計チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK35() '値引き額チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK36() '請求除外金額チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call Limit_money()  '修理限度額計算

        Call CK37() '請求額チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK38() '見積額チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK39() '修理番号チェック
        If P_Err_CODE <> Nothing Then Exit Function

        Call CK40() '処理日チェック
        If P_Err_CODE <> Nothing Then Exit Function

    End Function

    Sub CK01()  '保証番号チェック
        If Trim(P_03) = Nothing Or Val(P_03) = 0 Then
            P_Err_CODE = "01"
            P_Err_Msg1 = "保証番号エラー"
            P_Err_Msg2 = "保証番号は入力必須です。"
        End If
    End Sub

    Sub CK02()  '保証番号該当チェック
        W_Ds1.Clear()
        strSQL = "SELECT Wrn_mtr.*"
        strSQL +=  " FROM Wrn_mtr"
        strSQL +=  " WHERE ordr_no = '" & P_03 & "'"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        W_Da1.Fill(W_Ds1, "Wrn_mtr")
        DB_CLOSE()
        W_DV1 = New DataView(W_Ds1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
        If W_DV1.Count = 0 Then
            strSQL = "SELECT Wrn_data.*"
            strSQL +=  " FROM Wrn_data"
            strSQL +=  " WHERE ordr_no = '" & P_03 & "'"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            W_Da1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            W_Da1.Fill(W_Ds1, "Wrn_data")
            DB_CLOSE()
            W_DV1 = New DataView(W_Ds1.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
            If W_DV1.Count = 0 Then
                P_Err_CODE = "02"
                P_Err_Msg1 = "保証番号該当なし"
                P_Err_Msg2 = "該当する保証番号がありません。"
            End If
        End If
    End Sub

    Sub CK03()  '請求区分チェック
        W_DV1 = New DataView(P_Ds1.Tables("CLS_CODE"), "CLS_NO='007' AND CLS_CODE='" & P_32 & "'", "", DataViewRowState.CurrentRows)
        If W_DV1.Count = 0 Then
            P_Err_CODE = "03"
            P_Err_Msg1 = "請求区分エラー"
            P_Err_Msg2 = "該当する請求区分がありません。"
        End If
    End Sub

    Sub CK04()  '請求番号チェック
        If Trim(P_02) = Nothing Or Val(P_02) = 0 Then
            P_Err_CODE = "04"
            P_Err_Msg1 = "請求番号エラー"
            P_Err_Msg2 = "請求番号は入力必須です。"
        End If
    End Sub

    Sub CK05()  '型式チェック
        If Trim(P_19) = Nothing Then
            P_Err_CODE = "05"
            P_Err_Msg1 = "型式エラー"
            P_Err_Msg2 = "型式は入力必須です。"
        End If
    End Sub

    Sub CK06()  '事故状況フラグチェック
        W_DV1 = New DataView(P_Ds1.Tables("CLS_CODE"), "CLS_NO='002' AND CLS_CODE='" & P_07 & "'", "", DataViewRowState.CurrentRows)
        If W_DV1.Count = 0 Then
            P_Err_CODE = "06"
            P_Err_Msg1 = "事故状況フラグエラー"
            P_Err_Msg2 = "該当する事故状況フラグがありません。"
        End If
    End Sub

    Sub CK07()  '修理品製造番号チェック
        Select Case P_07
            Case Is = "0", "4"
                If Trim(P_20) = Nothing Then
                    P_Err_CODE = "07"
                    P_Err_Msg1 = "修理品製造番号エラー"
                    P_Err_Msg2 = "延長修理と破損の場合、修理品製造番号は入力必須です。"
                End If
        End Select
    End Sub

    Sub CK08()  '保証番号重複チェック
        W_Ds1.Clear()
        strSQL = "SELECT Wrn_ivc.*"
        strSQL +=  " FROM Wrn_ivc"
        strSQL +=  " WHERE (ordr_no = '" & P_03 & "')"
        strSQL +=  " AND (FLD019 = '" & P_19 & "')"
        strSQL +=  " AND (FLD020 = '" & P_20 & "')"
        strSQL +=  " AND (close_date = CONVERT(DATETIME, '" & P_close_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        W_Da1.Fill(W_Ds1, "Wrn_ivc")
        DB_CLOSE()
        W_DV1 = New DataView(W_Ds1.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
        If P_32 = "1" Then  '請求
            If W_DV1.Count <> 0 Then
                P_Err_CODE = "08"
                P_Err_Msg1 = "同一締め内に保証番号重複エラー"
                P_Err_Msg2 = "同一締め内に保証番号が重複しています。"
            End If
        Else                '取消
            If W_DV1.Count = 0 Then
                P_Err_CODE = "09"
                P_Err_Msg1 = "同一締め内に取り消す保証番号なし"
                P_Err_Msg2 = "同一締め内に取り消す保証番号がありません。"
            End If
        End If
    End Sub

    Sub CK09()  '保証番号、型式の該当チェック
        W_Ds1.Clear()
        strSQL = "SELECT Wrn_sub.*"
        strSQL +=  " FROM Wrn_sub"
        strSQL +=  " WHERE (ordr_no = '" & P_03 & "')"
        strSQL +=  " AND (model_name = '" & P_19 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        W_Da1.Fill(W_Ds1, "Wrn_sub")
        DB_CLOSE()
        W_DV1 = New DataView(W_Ds1.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
        If W_DV1.Count = 0 Then
            strSQL = "SELECT Wrn_data.*"
            strSQL +=  " FROM Wrn_data"
            strSQL +=  " WHERE (ordr_no = '" & P_03 & "')"
            strSQL +=  " AND (model_name = '" & P_19 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            W_Da1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            W_Da1.Fill(W_Ds1, "Wrn_data")
            DB_CLOSE()
            W_DV1 = New DataView(W_Ds1.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
            If W_DV1.Count = 0 Then
                P_Err_CODE = "10"
                P_Err_Msg1 = "型式の該当なし"
                P_Err_Msg2 = "該当の保証番号に対する型式が見つかりません。"
            End If
        End If
    End Sub

    Sub CK10()  '顧客名チェック
        If Trim(P_15) = Nothing Then
            P_Err_CODE = "11"
            P_Err_Msg1 = "顧客名エラー"
            P_Err_Msg2 = "顧客名は入力必須です。"
        End If
    End Sub

    Sub CK11()  '保証番号、型式、顧客名（姓）の該当チェック
        Dim Lname As String
        Lname = Mid(P_15, 1, P_15.IndexOf(" "))   '姓名分割
        W_Ds2.Clear()
        strSQL = "SELECT Wrn_mtr.cust_lname, Wrn_sub.*"
        strSQL +=  " FROM Wrn_mtr INNER JOIN"
        strSQL +=  " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no"
        strSQL +=  " WHERE (Wrn_sub.ordr_no = '" & P_03 & "')"
        strSQL +=  " AND (Wrn_sub.model_name = '" & P_19 & "')"
        strSQL +=  " AND (Wrn_mtr.cust_lname = '" & Lname & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        W_Da1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        W_Da1.Fill(W_Ds2, "Wrn_sub")
        DB_CLOSE()
        W_DV2 = New DataView(W_Ds2.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)
        If W_DV2.Count = 0 Then
            strSQL = "SELECT Wrn_data.*"
            strSQL +=  " FROM Wrn_data"
            strSQL +=  " WHERE (ordr_no = '" & P_03 & "')"
            strSQL +=  " AND (model_name = '" & P_19 & "')"
            strSQL +=  " AND (cust_name LIKE '" & Lname & " %')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            W_Da1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            W_Da1.Fill(W_Ds2, "Wrn_data")
            DB_CLOSE()
            W_DV3 = New DataView(W_Ds2.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)
            If W_DV3.Count = 0 Then
                P_Err_CODE = "12"
                P_Err_Msg1 = "顧客名（姓）の該当なし"
                P_Err_Msg2 = "該当の保証番号と型式に対する顧客名（姓）が見つかりません。"
            Else
                New_Old = "O"
            End If
        Else
            New_Old = "N"
        End If
    End Sub

    Sub CK12()  '事故日チェック
        If P_05_date = Nothing Then
            If Trim(P_05) = Nothing Or Val(P_05) = 0 Then
                P_Err_CODE = "21"
                P_Err_Msg1 = "事故日エラー"
                P_Err_Msg2 = "事故日は入力必須です。"
                Exit Sub
            Else
                If IsDate(Mid(P_05, 1, 4), Mid(P_05, 5, 2), Mid(P_05, 7, 2)) = False Then
                    P_Err_CODE = "21"
                    P_Err_Msg1 = "事故日エラー"
                    P_Err_Msg2 = "事故日の入力に誤りがあります。"
                    Exit Sub
                Else
                    P_05_date = Mid(P_05, 1, 4) & "/" & Mid(P_05, 5, 2) & "/" & Mid(P_05, 7, 2)
                End If
            End If
        End If
        If P_05_date > Now.Date Then
            P_Err_CODE = "22"
            P_Err_Msg1 = "事故日エラー(未来日付)"
            P_Err_Msg2 = "事故日に未来日付は入力できません。"
        End If
    End Sub

    Sub Scan()  '対象機種の判別
        '必ずCK11の後に実行する
        Dim wk_f As String = "0"
        If New_Old = "N" Then
            If W_DV2.Count = 1 Then   '対象1台
                WK_ordr_no = W_DV2(0)("ordr_no")
                WK_line_no = W_DV2(0)("line_no")
                WK_seq = W_DV2(0)("seq")
            Else                        '対象複数
                For i = 0 To W_DV2.Count - 1
                    If W_DV2(i)("cont_flg") = "A" Then
                        If Not IsDBNull(W_DV2(i)("total_loss_flg")) Then
                            If W_DV2(i)("total_loss_flg") <> "1" Then
                                If DateAdd(DateInterval.Year, 5, W_DV2(i)("prch_date")) > P_05_date Then
                                    Select Case P_07
                                        Case Is = "0"   '故障
                                            If DateAdd(DateInterval.Year, -1, W_DV2(i)("prch_date")) <= P_05_date Then
                                                wk_f = "1"
                                                WK_ordr_no = W_DV2(i)("ordr_no")
                                                WK_line_no = W_DV2(i)("line_no")
                                                WK_seq = W_DV2(i)("seq")
                                                Exit For
                                            End If
                                        Case Is = "4"   '破損
                                            If DateAdd(DateInterval.Year, -1, W_DV2(i)("prch_date")) > P_05_date Then
                                                wk_f = "1"
                                                WK_ordr_no = W_DV2(i)("ordr_no")
                                                WK_line_no = W_DV2(i)("line_no")
                                                WK_seq = W_DV2(i)("seq")
                                                Exit For
                                            End If
                                    End Select
                                End If
                            End If
                        Else
                            If DateAdd(DateInterval.Year, 5, W_DV2(i)("prch_date")) > P_05_date Then
                                Select Case P_07
                                    Case Is = "0"   '故障
                                        If DateAdd(DateInterval.Year, -1, W_DV2(i)("prch_date")) <= P_05_date Then
                                            wk_f = "1"
                                            WK_ordr_no = W_DV2(i)("ordr_no")
                                            WK_line_no = W_DV2(i)("line_no")
                                            WK_seq = W_DV2(i)("seq")
                                            Exit For
                                        End If
                                    Case Is = "4"   '破損
                                        If DateAdd(DateInterval.Year, -1, W_DV2(i)("prch_date")) > P_05_date Then
                                            wk_f = "1"
                                            WK_ordr_no = W_DV2(i)("ordr_no")
                                            WK_line_no = W_DV2(i)("line_no")
                                            WK_seq = W_DV2(i)("seq")
                                            Exit For
                                        End If
                                End Select
                            End If
                        End If
                    End If
                Next
            End If

            If wk_f = "0" Then  'NG
                'NGの時は、1件目で処理
                WK_ordr_no = W_DV2(0)("ordr_no")
                WK_line_no = W_DV2(0)("line_no")
                WK_seq = W_DV2(0)("seq")
            End If

            W_Ds4.Clear()
            strSQL = "SELECT Wrn_sub.*"
            strSQL +=  " FROM Wrn_sub"
            strSQL +=  " WHERE (ordr_no = '" & WK_ordr_no & "')"
            strSQL +=  " AND (line_no = '" & WK_line_no & "')"
            strSQL +=  " AND (seq = " & WK_seq & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            W_Da1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            W_Da1.Fill(W_Ds4, "Wrn_sub")
            DB_CLOSE()
            W_DV1 = New DataView(W_Ds4.Tables("Wrn_sub"), "", "", DataViewRowState.CurrentRows)

        Else    'OLD
            WK_seq = 0
            If W_DV3.Count = 1 Then   '対象1台
                WK_ordr_no = W_DV3(0)("ordr_no")
                WK_line_no = W_DV3(0)("line_no")
            Else                        '対象複数
                For i = 0 To W_DV3.Count - 1
                    If W_DV3(i)("cont_flg") = "A" Then
                        If Not IsDBNull(W_DV3(i)("total_loss_flg")) Then
                            If W_DV3(i)("total_loss_flg") <> "1" Then
                                If DateAdd(DateInterval.Year, 5, W_DV3(i)("prch_date")) > P_05_date Then
                                    Select Case P_07
                                        Case Is = "0"   '故障
                                            If DateAdd(DateInterval.Year, -1, W_DV3(i)("prch_date")) <= P_05_date Then
                                                wk_f = "1"
                                                WK_ordr_no = W_DV3(i)("ordr_no")
                                                WK_line_no = W_DV3(i)("line_no")
                                                Exit For
                                            End If
                                        Case Is = "4"   '破損
                                            If DateAdd(DateInterval.Year, -1, W_DV3(i)("prch_date")) > P_05_date Then
                                                wk_f = "1"
                                                WK_ordr_no = W_DV3(i)("ordr_no")
                                                WK_line_no = W_DV3(i)("line_no")
                                                Exit For
                                            End If
                                    End Select
                                End If
                            End If
                        Else
                            If DateAdd(DateInterval.Year, 5, W_DV3(i)("prch_date")) > P_05_date Then
                                Select Case P_07
                                    Case Is = "0"   '故障
                                        If DateAdd(DateInterval.Year, -1, W_DV3(i)("prch_date")) <= P_05_date Then
                                            wk_f = "1"
                                            WK_ordr_no = W_DV3(i)("ordr_no")
                                            WK_line_no = W_DV3(i)("line_no")
                                            Exit For
                                        End If
                                    Case Is = "4"   '破損
                                        If DateAdd(DateInterval.Year, -1, W_DV3(i)("prch_date")) > P_05_date Then
                                            wk_f = "1"
                                            WK_ordr_no = W_DV3(i)("ordr_no")
                                            WK_line_no = W_DV3(i)("line_no")
                                            WK_seq = W_DV3(i)("seq")
                                            Exit For
                                        End If
                                End Select
                            End If
                        End If
                    End If
                Next
            End If

            If wk_f = "0" Then  'NG
                'NGの時は、1件目で処理
                WK_ordr_no = W_DV3(0)("ordr_no")
                WK_line_no = W_DV3(0)("line_no")
            End If

            W_Ds4.Clear()
            strSQL = "SELECT Wrn_data.*"
            strSQL +=  " FROM Wrn_data"
            strSQL +=  " WHERE (ordr_no = '" & WK_ordr_no & "')"
            strSQL +=  " AND (line_no = '" & WK_line_no & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            W_Da1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn_data2")
            W_Da1.Fill(W_Ds4, "Wrn_data")
            DB_CLOSE()
            W_DV1 = New DataView(W_Ds4.Tables("Wrn_data"), "", "", DataViewRowState.CurrentRows)

        End If
    End Sub

    Sub CK13()  '契約状況チェック
        If W_DV1(0)("cont_flg") = "C" Then
            P_Err_CODE = "30"
            P_Err_Msg1 = "契約状況=C"
            P_Err_Msg2 = "該当する加入データは契約状況=Cです。"
        End If
    End Sub

    Sub CK14()  '全損チェック
        If Not IsDBNull(W_DV1(0)("total_loss_flg")) Then
            If W_DV1(0)("total_loss_flg") = "1" Then
                P_Err_CODE = "31"
                P_Err_Msg1 = "全損のため契約満了"
                P_Err_Msg2 = "該当する加入データは全損のため契約満了です。"
            End If
        End If
    End Sub

    Sub CK15()  '保障期間チェック
        If DateAdd(DateInterval.Year, 5, W_DV1(0)("prch_date")) <= P_05_date Then
            P_Err_CODE = "32"
            P_Err_Msg1 = "5年間の保証期限切れ"
            P_Err_Msg2 = "該当する加入データは5年間の保証期限切れです。"
        End If

        Select Case P_07
            Case Is = "0"   '故障
                If DateAdd(DateInterval.Year, 1, W_DV1(0)("prch_date")) > P_05_date Then
                    P_Err_CODE = "33"
                    P_Err_Msg1 = "故障は2年目から対象"
                    P_Err_Msg2 = "延長修理は2年目から対象です。"
                End If
            Case Is = "4"   '破損
                If DateAdd(DateInterval.Year, 1, W_DV1(0)("prch_date")) <= P_05_date Then
                    P_Err_CODE = "34"
                    P_Err_Msg1 = "破損は1年目のみ対象"
                    P_Err_Msg2 = "破損は1年目のみ対象です。"
                End If
        End Select
    End Sub

    Sub CK16()  '該当保険会社チェック
        W_DV2 = New DataView(P_Ds1.Tables("insurance_co_sub"), "start_date <= '" & W_DV1(0)("prch_date") & "' AND end_date >= '" & W_DV1(0)("prch_date") & "' AND accident_flg = '" & P_07 & "'", "", DataViewRowState.CurrentRows)
        If W_DV2.Count = 0 Then
            P_Err_CODE = "35"
            P_Err_Msg1 = "該当する保険会社なし"
            P_Err_Msg2 = "該当する保険会社がありません。"
        Else
            WK_insurance_code = W_DV2(0)("insurance_code")
            W_DV2 = New DataView(P_Ds1.Tables("insurance_co_decision"), "start_date <= '" & W_DV1(0)("prch_date") & "' AND end_date >= '" & W_DV1(0)("prch_date") & "' AND insurance_code = '" & WK_insurance_code & "'", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(W_DV2(0)("Securities_no")) Then
                If W_DV2.Count <> 0 Then
                    WK_Securities_no = W_DV2(0)("Securities_no")
                    WK_kbn_No = W_DV2(0)("kbn_No")
                Else
                    WK_Securities_no = Nothing
                    WK_kbn_No = "0"
                End If
            Else
                WK_Securities_no = Nothing
                WK_kbn_No = "0"
            End If
        End If
    End Sub

    Sub CK17()  '全損フラグチェック
        W_DV2 = New DataView(P_Ds1.Tables("CLS_CODE"), "CLS_NO='004' AND CLS_CODE='" & P_09 & "'", "", DataViewRowState.CurrentRows)
        If W_DV2.Count = 0 Then
            P_Err_CODE = "36"
            P_Err_Msg1 = "全損フラグエラー"
            P_Err_Msg2 = "該当する全損フラグがありません。"
        End If
    End Sub

    Sub CK18()  '承認番号チェック
        If P_09 = "0" Then  '修理
            If CInt(P_28) > 100000 Then
                If Trim(P_04) = Nothing Or Val(P_04) = 0 Then
                    P_Err_CODE = "37"
                    P_Err_Msg1 = "承認番号エラー"
                    P_Err_Msg2 = "修理で10万円以上の場合、承認番号は入力必須です。"
                End If
            End If
        Else                '全損
            If CInt(P_28) > 50000 Then
                If Trim(P_04) = Nothing Or Val(P_04) = 0 Then
                    P_Err_CODE = "37"
                    P_Err_Msg1 = "承認番号エラー"
                    P_Err_Msg2 = "全損で5万円以上の場合、承認番号は入力必須です。"
                End If
            End If
        End If
    End Sub

    Sub CK19()  '事故場所チェック
        If Trim(P_06) = Nothing And Val(P_06) = 0 And P_07 = "0" Then    '延長保証の場合はnullでもOK
        Else
            W_DV2 = New DataView(P_Ds1.Tables("CLS_CODE"), "CLS_NO='001' AND CLS_CODE='" & P_06 & "'", "", DataViewRowState.CurrentRows)
            If W_DV2.Count = 0 Then
                P_Err_CODE = "38"
                P_Err_Msg1 = "事故場所エラー"
                P_Err_Msg2 = "延長保証の場合、事故場所は入力必須です。"
            End If
        End If
    End Sub

    Sub CK20()  '項目有無フラグチェック
        W_DV2 = New DataView(P_Ds1.Tables("CLS_CODE"), "CLS_NO='003' AND CLS_CODE='" & P_08 & "'", "", DataViewRowState.CurrentRows)
        If W_DV2.Count = 0 Then
            P_Err_CODE = "39"
            P_Err_Msg1 = "項目有無エラー"
            P_Err_Msg2 = "該当する項目有無がありません。"
        End If
    End Sub

    Sub CK21()  '修理品購入店チェック
        If Trim(P_10) = Nothing Or Val(P_10) = 0 Then
            If New_Old = "N" Then
                W_Ds1.Clear()
                strSQL = "SELECT shop_code"
                strSQL +=  " FROM Wrn_mtr"
                strSQL +=  " WHERE (ordr_no = '" & WK_ordr_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                W_Da1.SelectCommand = SqlCmd1
                DB_OPEN("best_wrn")
                W_Da1.Fill(W_Ds1, "Wrn_mtr")
                DB_CLOSE()
                W_DV2 = New DataView(W_Ds1.Tables("Wrn_mtr"), "", "", DataViewRowState.CurrentRows)
                If W_DV2.Count <> 0 Then
                    P_10 = W_DV2(0)("shop_code")
                Else
                    P_Err_CODE = "40"
                    P_Err_Msg1 = "修理品購入店コードなし"
                    P_Err_Msg2 = "修理品購入店コードは入力必須です。"
                End If
            Else
                P_10 = W_DV1(0)("shop_code")
            End If
        Else
            W_DV2 = New DataView(P_Ds1.Tables("Shop_mtr"), "shop_code = '" & P_10 & "'", "", DataViewRowState.CurrentRows)
            If W_DV2.Count = 0 Then
                P_Err_CODE = "41"
                P_Err_Msg1 = "修理品購入店舗該当なし"
                P_Err_Msg2 = "該当する修理品購入店舗がありません。"
            End If
        End If
    End Sub

    Sub CK22()  '修理受付店チェック
        If Trim(P_11) = Nothing Or Val(P_11) = 0 Then
            P_Err_CODE = "42"
            P_Err_Msg1 = "修理受付店コードなし"
            P_Err_Msg2 = "修理受付店コードは入力必須です。"
        Else
            W_DV2 = New DataView(P_Ds1.Tables("Shop_mtr"), "shop_code = '" & P_11 & "'", "", DataViewRowState.CurrentRows)
            If W_DV2.Count = 0 Then
                P_Err_CODE = "43"
                P_Err_Msg1 = "修理受付店舗該当なし"
                P_Err_Msg2 = "該当する修理受付店舗がありません。"
            End If
        End If
    End Sub

    Sub CK23()  '修理完了店チェック
        If Trim(P_12) = Nothing Or Val(P_12) = 0 Then
            P_Err_CODE = "44"
            P_Err_Msg1 = "修理完了店コードなし"
            P_Err_Msg2 = "修理完了店コードは入力必須です。"
        Else
            W_DV2 = New DataView(P_Ds1.Tables("Shop_mtr"), "shop_code = '" & P_12 & "'", "", DataViewRowState.CurrentRows)
            If W_DV2.Count = 0 Then
                P_Err_CODE = "45"
                P_Err_Msg1 = "修理完了店舗該当なし"
                P_Err_Msg2 = "該当する修理完了店舗がありません。"
            End If
        End If
    End Sub

    Sub CK24()  '伝票区分チェック
        W_DV2 = New DataView(P_Ds1.Tables("CLS_CODE"), "CLS_NO='005' AND CLS_CODE='" & P_13 & "'", "", DataViewRowState.CurrentRows)
        If W_DV2.Count = 0 Then
            P_Err_CODE = "46"
            P_Err_Msg1 = "伝票区分エラー"
            P_Err_Msg2 = "該当する伝票区分がありません。"
        End If
    End Sub

    Sub CK25()  '修理伝票番号チェック
        If Trim(P_14) = Nothing Or Val(P_14) = 0 Then
            P_Err_CODE = "47"
            P_Err_Msg1 = "修理伝票番号エラー"
            P_Err_Msg2 = "修理伝票番号は入力必須です。"
        End If
    End Sub

    Sub CK26()  '電話番号チェック
        If Trim(P_16) = Nothing Or Val(P_16) = 0 Then
            P_Err_CODE = "48"
            P_Err_Msg1 = "電話番号エラー"
            P_Err_Msg2 = "電話番号は入力必須です。"
        End If
    End Sub

    Sub CK27()  'メーカーチェック
        If Trim(P_17) = Nothing Or Val(P_17) = 0 Then
            P_Err_CODE = "49"
            P_Err_Msg1 = "メーカーエラー"
            P_Err_Msg2 = "メーカーは入力必須です。"
        Else
            W_DV2 = New DataView(P_Ds1.Tables("vdr_mtr"), "vdr_code = '" & P_17 & "'", "", DataViewRowState.CurrentRows)
            If W_DV2.Count = 0 Then
                P_Err_CODE = "50"
                P_Err_Msg1 = "メーカーコード該当なし"
                P_Err_Msg2 = "該当するメーカーがありません。"
            End If
        End If
    End Sub

    Sub CK28()  '品種チェック
        If Trim(P_18) = Nothing Or Val(P_18) = 0 Then
            P_Err_CODE = "51"
            P_Err_Msg1 = "品種コードエラー"
            P_Err_Msg2 = "品種コードは入力必須です。"
        Else
            W_DV2 = New DataView(P_Ds1.Tables("Cat_mtr"), "cd1 = '" & Mid(P_18, 1, 2) & "' AND cd2 = '" & Mid(P_18, 3, 2) & "'", "", DataViewRowState.CurrentRows)
            If W_DV2.Count = 0 Then
                P_Err_CODE = "52"
                P_Err_Msg1 = "品種コード該当なし"
                P_Err_Msg2 = "該当する品種コードがありません。"
            End If
        End If
    End Sub

    Sub CK29()  '修理受付日チェック
        If P_21_date = Nothing Then
            If Trim(P_21) = Nothing Or Val(P_21) = 0 Then
                P_Err_CODE = "53"
                P_Err_Msg1 = "修理受付日エラー"
                P_Err_Msg2 = "修理受付日は入力必須です。"
                Exit Sub
            Else
                If IsDate(Mid(P_21, 1, 4), Mid(P_21, 5, 2), Mid(P_21, 7, 2)) = False Then
                    P_Err_CODE = "53"
                    P_Err_Msg1 = "修理受付日エラー"
                    P_Err_Msg2 = "修理受付日の入力に誤りがあります。"
                    Exit Sub
                Else
                    P_21_date = Mid(P_21, 1, 4) & "/" & Mid(P_21, 5, 2) & "/" & Mid(P_21, 7, 2)
                End If
            End If
        End If
        If P_21_date > Now.Date Then
            P_Err_CODE = "54"
            P_Err_Msg1 = "修理受付日エラー(未来日付)"
            P_Err_Msg2 = "修理受付日に未来日付は入力できません。"
        End If
    End Sub

    Sub CK30()  '修理完了日チェック
        If P_22_date = Nothing Then
            If Trim(P_22) = Nothing Or Val(P_22) = 0 Then
                P_Err_CODE = "55"
                P_Err_Msg1 = "修理完了日エラー"
                P_Err_Msg2 = "修理完了日は入力必須です。"
                Exit Sub
            Else
                If IsDate(Mid(P_22, 1, 4), Mid(P_22, 5, 2), Mid(P_22, 7, 2)) = False Then
                    P_Err_CODE = "55"
                    P_Err_Msg1 = "修理完了日エラー"
                    P_Err_Msg2 = "修理完了日の入力に誤りがあります。"
                    Exit Sub
                Else
                    P_22_date = Mid(P_22, 1, 4) & "/" & Mid(P_22, 5, 2) & "/" & Mid(P_22, 7, 2)
                End If
            End If
        End If
        If P_22_date > Now.Date Then
            P_Err_CODE = "56"
            P_Err_Msg1 = "修理完了日エラー(未来日付)"
            P_Err_Msg2 = "修理完了日に未来日付は入力できません。"
        End If
    End Sub

    Sub CK31()  '日付相関チェック
        If P_05_date > P_21_date Then
            P_Err_CODE = "57"
            P_Err_Msg1 = "事故日＞修理受付日エラー"
            P_Err_Msg2 = "事故日＞修理受付日エラー"
        Else
            If P_05_date < W_DV1(0)("prch_date") Then
                P_Err_CODE = "58"
                P_Err_Msg1 = "事故日が購入日前エラー"
                P_Err_Msg2 = "事故日が購入日前エラー"
            Else
                If P_05_date > P_22_date Then
                    P_Err_CODE = "59"
                    P_Err_Msg1 = "事故日＞修理完了日エラー"
                    P_Err_Msg2 = "事故日＞修理完了日エラー"
                Else
                    If P_21_date > P_22_date Then
                        P_Err_CODE = "60"
                        P_Err_Msg1 = "修理受付日＞修理完了日エラー"
                        P_Err_Msg2 = "修理受付日＞修理完了日エラー"
                    End If
                End If
            End If
        End If
    End Sub

    Sub CK32()  '出張料チェック
        If numeric_check(P_23) = "NG" Then
            P_Err_CODE = "61"
            P_Err_Msg1 = "出張料エラー"
            P_Err_Msg2 = "出張料エラー"
        End If
    End Sub

    Sub CK33()  '作業料チェック
        If numeric_check(P_24) = "NG" Then
            P_Err_CODE = "62"
            P_Err_Msg1 = "作業料エラー"
            P_Err_Msg2 = "作業料エラー"
        End If
    End Sub

    Sub CK34()  '部品料計チェック
        If numeric_check(P_25) = "NG" Then
            P_Err_CODE = "63"
            P_Err_Msg1 = "部品料計エラー"
            P_Err_Msg2 = "部品料計エラー"
        End If
    End Sub

    Sub CK35()  '値引き額チェック
        If numeric_check(P_26) = "NG" Then
            P_Err_CODE = "64"
            P_Err_Msg1 = "値引き額エラー"
            P_Err_Msg2 = "値引き額エラー"
        End If
    End Sub

    Sub CK36()  '請求除外金額チェック
        If numeric_check(P_27) = "NG" Then
            P_Err_CODE = "65"
            P_Err_Msg1 = "請求除外金額エラー"
            P_Err_Msg2 = "請求除外金額エラー"
        End If
    End Sub

    Sub Limit_money()   '修理限度額計算
        If P_07 = "0" Then
            If WK_kbn_No >= "N11" And WK_kbn_No <= "N99" Then
                P_Limit_money = RoundDOWN(W_DV1(0)("prch_price") * 1.08, 0)
            Else
                P_Limit_money = RoundDOWN(W_DV1(0)("prch_price") * 0.8 * 1.08, 0)
            End If
        Else
            If DateAdd(DateInterval.Year, 1, W_DV1(0)("prch_date")) > P_05_date Then  '1年以下
                P_Limit_money = W_DV1(0)("prch_price")
            Else
                If DateAdd(DateInterval.Year, 2, W_DV1(0)("prch_date")) > P_05_date Then  '2年以下
                    P_Limit_money = RoundDOWN(W_DV1(0)("prch_price") * 0.8, 0)
                Else
                    If DateAdd(DateInterval.Year, 3, W_DV1(0)("prch_date")) > P_05_date Then  '3年以下
                        P_Limit_money = RoundDOWN(W_DV1(0)("prch_price") * 0.6, 0)
                    Else
                        If DateAdd(DateInterval.Year, 4, W_DV1(0)("prch_date")) > P_05_date Then  '4年以下
                            P_Limit_money = RoundDOWN(W_DV1(0)("prch_price") * 0.4, 0)
                        Else
                            If DateAdd(DateInterval.Year, 5, W_DV1(0)("prch_date")) > P_05_date Then  '5年以下
                                P_Limit_money = RoundDOWN(W_DV1(0)("prch_price") * 0.2, 0)
                            Else
                                P_Limit_money = 0
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Sub CK37()  '請求額チェック
        If numeric_check(P_28) = "NG" Then
            P_Err_CODE = "66"
            P_Err_Msg1 = "請求額エラー"
            P_Err_Msg2 = "請求額エラー"
        Else
            If CInt(P_28) <> CInt(P_23) + CInt(P_24) + CInt(P_25) - CInt(P_26) - CInt(P_27) Then
                P_Err_CODE = "67"
                P_Err_Msg1 = "請求額計算エラー"
                P_Err_Msg2 = "請求額計算エラー"
            Else
                If P_09 = "0" Then
                    If P_Limit_money < CInt(P_28) Then
                        P_Err_CODE = "71"
                        P_Err_Msg1 = "修理限度額エラー"
                        P_Err_Msg2 = "請求額が修理限度額を超えています。"
                    End If
                Else
                    If P_Limit_money < Fix(CInt(P_28) * 100 / 103) Then
                        P_Err_CODE = "71"
                        P_Err_Msg1 = "修理限度額エラー"
                        P_Err_Msg2 = "(請求額×100÷103)が修理限度額を超えています。"
                    End If
                End If
            End If
        End If
    End Sub

    Sub CK38()  '見積額チェック
        If numeric_check(P_29) = "NG" Then
            P_Err_CODE = "68"
            P_Err_Msg1 = "見積額エラー"
            P_Err_Msg2 = "見積額エラー"
        End If
    End Sub

    Sub CK39()  '修理番号チェック
        If Trim(P_30) = Nothing Or Val(P_30) = 0 Then
            P_Err_CODE = "72"
            P_Err_Msg1 = "修理番号エラー"
            P_Err_Msg2 = "修理番号は入力必須です。"
        End If
    End Sub

    Sub CK40()  '処理日チェック
        If P_31_date = Nothing Then
            If Trim(P_31) = Nothing Or Val(P_31) = 0 Then
                P_Err_CODE = "73"
                P_Err_Msg1 = "処理日エラー"
                P_Err_Msg2 = "処理日は入力必須です。"
                Exit Sub
            Else
                If IsDate(Mid(P_31, 1, 4), Mid(P_31, 5, 2), Mid(P_31, 7, 2)) = False Then
                    P_Err_CODE = "73"
                    P_Err_Msg1 = "処理日エラー"
                    P_Err_Msg2 = "処理日の入力に誤りがあります。"
                    Exit Sub
                Else
                    P_31_date = Mid(P_31, 1, 4) & "/" & Mid(P_31, 5, 2) & "/" & Mid(P_31, 7, 2)
                End If
            End If
        End If
        If P_31_date > Now.Date Then
            P_Err_CODE = "73"
            P_Err_Msg1 = "処理日エラー"
            P_Err_Msg2 = "処理日に未来日付は入力できません。"
        End If
    End Sub

    Sub CK41()  '掛種コードチェック
        W_DV2 = New DataView(P_Ds1.Tables("CLS_CODE"), "CLS_NO='008' AND CLS_CODE='" & P_33 & "'", "", DataViewRowState.CurrentRows)
        If W_DV2.Count = 0 Then
            P_Err_CODE = "74"
            P_Err_Msg1 = "掛種コードエラー"
            P_Err_Msg2 = "該当する掛種コードがありません。"
        End If
    End Sub

End Module
