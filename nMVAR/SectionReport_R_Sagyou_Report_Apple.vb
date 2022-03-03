Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Sagyou_Report_Apple
    Inherits SectionReport
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet

    Dim DtView1, WK_DtView1 As DataView
    Dim strSQL As String
    Dim i, r, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        TextBox1.Text = "発行日 " & Format(Now.Date, "yyyy 年 MM 月 dd 日")

        '修理内容
        TextBox18.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox18.Text = DtView1(i)("cmnt")
                Else
                    TextBox18.Text += vbCrLf & DtView1(i)("cmnt")
                End If
            Next
        End If

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

        If TextBox2.Text = Nothing Then '御社伝票番号なしの時非表示
            Label1.Visible = False
        End If

        If TextBox57.Text = Nothing Then
            TextBox6.Text = TextBox56.Text
        Else
            TextBox6.Text = TextBox56.Text & "(" & TextBox57.Text & ")"
        End If

        'TextBox8.Text = StrConv(Trim(TextBox58.Text.Replace(vbCrLf, "")), VbStrConv.Narrow) & " " & StrConv(Trim(TextBox59.Text), VbStrConv.Narrow) # ram 2020-12-10
        TextBox8.Text = Trim(TextBox58.Text.Replace(vbCrLf, "")) & " " & Trim(TextBox59.Text)
        TextBox9.Text = "TEL " & TextBox60.Text & "　FAX " & TextBox61.Text

        Dim wk_tel As String = Nothing
        DsList1.Clear()
        strSQL = "SELECT print_tel, print_fax FROM M08_STORE WHERE (store_code = '" & TextBox78.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M08_STORE")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            If Not IsDBNull(DtView1(0)("print_tel")) Then
                If Trim(DtView1(0)("print_tel")) <> "" Then
                    wk_tel += "TEL " & Trim(DtView1(0)("print_tel"))
                End If
            End If
            If Not IsDBNull(DtView1(0)("print_fax")) Then
                If Trim(DtView1(0)("print_fax")) <> "" Then
                    wk_tel += "　FAX " & Trim(DtView1(0)("print_fax"))
                End If
            End If
        End If
        If wk_tel <> Nothing Then
            TextBox9.Text = wk_tel
        End If

        If TextBox78.Text = "0020" Then '一般
            TextBox12.Text = TextBox63.Text & "　様"
        Else
            TextBox12.Text = Trim(TextBox77.Text) & " / " & Trim(TextBox63.Text) & "　様"
            TextBox12.Text = TextBox12.Text.Replace(vbCrLf, "")
        End If

        If Trim(TextBox64.Text) <> Nothing Then
            If Trim(TextBox18.Text) <> Nothing Then
                TextBox18.Text += vbCrLf & TextBox64.Text
            Else
                TextBox18.Text = TextBox64.Text
            End If
        End If

        TextBox16.Text = Nothing
        If Trim(TextBox74.Text) <> "refused@apple.com" Then
            TextBox16.Text = Trim(TextBox74.Text)
        End If

        TextBox19.Text = "修理区分：" & TextBox65.Text & "　　修理番号：" & TextBox66.Text
        If TextBox80.Text = "True" Then
            TextBox79.Text = "配送修理"
        Else
            TextBox79.Text = "店内修理"
        End If

        '部品
        TextBox21.Text = Nothing : TextBox26.Text = Nothing : TextBox31.Text = Nothing : TextBox36.Text = Nothing : TextBox41.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox32.Text = Nothing : TextBox37.Text = Nothing : TextBox42.Text = Nothing
        TextBox23.Text = Nothing : TextBox28.Text = Nothing : TextBox33.Text = Nothing : TextBox38.Text = Nothing : TextBox43.Text = Nothing
        TextBox24.Text = Nothing : TextBox29.Text = Nothing : TextBox34.Text = Nothing : TextBox39.Text = Nothing : TextBox44.Text = Nothing
        TextBox25.Text = Nothing : TextBox30.Text = Nothing : TextBox35.Text = Nothing : TextBox40.Text = Nothing : TextBox45.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        WK_cnt = 0 : WK_amnt = 0
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("exp_flg")) Then DtView1(i)("exp_flg") = "False"
                Select Case i
                    Case Is = 0
                        TextBox21.Text = DtView1(i)("part_code")
                        TextBox26.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox31.Text = DtView1(i)("s_n")
                        TextBox36.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox41.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox41.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_code")
                        TextBox27.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox32.Text = DtView1(i)("s_n")
                        TextBox37.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox42.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox42.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 2
                        TextBox23.Text = DtView1(i)("part_code")
                        TextBox28.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox33.Text = DtView1(i)("s_n")
                        TextBox38.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox43.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox43.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 3
                        TextBox24.Text = DtView1(i)("part_code")
                        TextBox29.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox34.Text = DtView1(i)("s_n")
                        TextBox39.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox44.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox44.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Else
                        TextBox25.Text = DtView1(i)("part_code")
                        TextBox30.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox35.Text = DtView1(i)("s_n")
                        TextBox40.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            ' TextBox45.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")  'Ram
                            TextBox45.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            'ram
                            ' TextBox45.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                            TextBox45.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")

                        End If
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + CInt(TextBox45.Text)
                End Select

                If DtView1.Count > 5 Then
                    TextBox25.Text = "その他部品"
                    TextBox30.Text = Nothing
                    TextBox35.Text = Nothing
                    TextBox40.Text = WK_cnt
                    TextBox45.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If

        'prabu uncomment 2022-01-05
        If TextBox72.Text = "01" Then
            TextBox46.Text = "\" & Format(CInt(TextBox76.Text), "##,##0")
        Else
            TextBox46.Text = "\" & Format(CInt(TextBox41.Text) + CInt(TextBox42.Text) + CInt(TextBox43.Text) + CInt(TextBox44.Text) + WK_amnt, "##,##0")
        End If

        TextBox47.Text = "\" & Format(CInt(TextBox10.Text) + CInt(TextBox62.Text) + CInt(TextBox69.Text), "##,##0")
        TextBox48.Text = "\" & Format(CInt(TextBox46.Text.Replace("\", "")) + CInt(TextBox47.Text.Replace("\", "")), "##,##0")

        If TextBox72.Text = "01" Then
            'TextBox49.Text = "なし"
            TextBox50.Text = "\0"
            TextBox51.Text = "\" & Format(CInt(TextBox73.Text), "##,##0")
        Else
            'TextBox49.Text = "あり"
            TextBox50.Text = "\" & Format(CInt(TextBox48.Text) * -1, "##,##0")
            TextBox51.Text = "\0"
        End If

        TextBox49.Text = "\" & Format(CInt(TextBox81.Text), "##,##0")

        TextBox52.Text = "\" & Format(CInt(TextBox48.Text.Replace("\", "")) + CInt(TextBox50.Text.Replace("\", "")) + CInt(TextBox51.Text.Replace("\", "")) + CInt(TextBox49.Text.Replace("\", "")), "##,##0")

        TextBox20.Text = Nothing
        If IsDate(TextBox.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " ご申告の症状を検証いたしました。"
        End If
        If IsDate(TextBox70.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox70.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " 製品の修理を実施いたしました。"
        End If
        If IsDate(TextBox71.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox71.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " お預かりした製品の修理に関して、ご連絡いたしました。"
        End If
        If TextBox67.Text <> Nothing Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += TextBox67.Text
        End If

        TextBox53.Text = "修理後保証は交換部品に対して適用されます。修理後保証期間は修理完了から" & Trim(TextBox68.Text) & "日です。"
        TextBox53.Text += vbCrLf & "※修理保証は機器障害にのみ適用され、筐体の損傷やお客様過失による故障などには適用されません。"
        TextBox53.Text += vbCrLf & "尚、修理/交換した部品または製品は、新品、または性能と信頼性の両面に於いて新品同様です。"

        If TextBox78.Text = "0020" Then '一般
            TextBox54.Text = "万一、故障が発生しました際には、当報告書をご持参の上、再修理をお申し込みください。"
            TextBox54.Text += vbCrLf & "修理完了日より2週間以内のお客様は、優先受付対応させて頂きますのでお申し付け下さい。"
            TextBox54.Text += vbCrLf & "製品の破損や傷、液体損傷などは修理後保証・優先受付の対象外です。"
        Else
            TextBox54.Text = "万一、故障が発生しました際には、当報告書をご持参の上、再修理をお申し込みください。"
            TextBox54.Text += vbCrLf & "製品の破損や傷、液体損傷などは修理後保証の対象外となります。"
        End If

        TextBox55.Text = "個人情報の収集、利用、提供及び登録に関して、以下のように取り扱います。"
        TextBox55.Text += vbCrLf & "①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用されません。"
        TextBox55.Text += vbCrLf & "②お客様情報の詳細（名前や電話番号）は、Apple社によって提供または使用される場合がございます。"
        TextBox55.Text += vbCrLf & "③上記の場合を除き、修理業務で知りえたお客様の個人情報は、第三者に漏えい、開示いたしません。"

    End Sub
    Function part_amt_get(ByVal vndr_code As String, ByVal part_code As String, ByVal rcpt_no As String, ByVal qty As Integer, ByVal ibm_flg As String) As Integer
        Dim cost As Integer = 0
        Dim EU_rate As Decimal = 0
        Dim GSS_rate As Decimal = 0
        Dim GSS_amnt As Integer = 0
        Dim store_code As String = Nothing
        Dim grup_code As String = Nothing
        Dim GSS_kijo As Integer = 0
        Dim part_amnt As Integer = 0
        Dim own_flg As String = "0"
        Dim note_kbn As String = Nothing
        DsList1.Clear()

        'コスト
        strSQL = "SELECT stc_amnt, exc_amnt"
        strSQL += " FROM M40_PART"
        strSQL += " WHERE (vndr_code = '" & vndr_code & "')"
        strSQL += " AND (part_code = '" & part_code & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "M40_PART")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("M40_PART"), "", "", DataViewRowState.CurrentRows)
            If IsDBNull(WK_DtView1(0)("exc_amnt")) Then WK_DtView1(0)("exc_amnt") = 0
            If IsDBNull(WK_DtView1(0)("stc_amnt")) Then WK_DtView1(0)("stc_amnt") = 0
            If CInt(WK_DtView1(0)("exc_amnt")) <> 0 Then
                cost = WK_DtView1(0)("exc_amnt")
            Else
                If CInt(WK_DtView1(0)("stc_amnt")) <> 0 Then
                    cost = WK_DtView1(0)("stc_amnt")
                End If
            End If
        End If

        'EU掛率
        strSQL = "SELECT T01_REP_MTR.rcpt_no, T01_REP_MTR.part_rate2, T01_REP_MTR.store_code, M08_STORE.grup_code, M06_RPAR_COMP.own_flg, T01_REP_MTR.note_kbn"
        strSQL += " FROM T01_REP_MTR INNER JOIN"
        strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
        strSQL += " M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView1(0)("part_rate2")) Then EU_rate = WK_DtView1(0)("part_rate2")
            If Not IsDBNull(WK_DtView1(0)("store_code")) Then store_code = WK_DtView1(0)("store_code")
            If Not IsDBNull(WK_DtView1(0)("grup_code")) Then grup_code = WK_DtView1(0)("grup_code")
            If Not IsDBNull(WK_DtView1(0)("own_flg")) Then own_flg = WK_DtView1(0)("own_flg")
            If Not IsDBNull(WK_DtView1(0)("note_kbn")) Then note_kbn = WK_DtView1(0)("note_kbn")
        End If

        '計上掛率
        strSQL = "SELECT part_rate, part_amnt"
        strSQL += " FROM M31_PART_RATE"
        strSQL += " WHERE (delt_flg = 0)"
        strSQL += " AND (vndr_code = '" & vndr_code & "')"
        strSQL += " AND (store_code = '" & store_code & "')"
        strSQL += " AND (note_kbn = '" & note_kbn & "')"
        If own_flg = "True" Then
            strSQL += " AND (own_rpat_kbn = '01')"
        Else
            strSQL += " AND (own_rpat_kbn = '02')"
        End If
        strSQL += " AND (strt_amnt <= " & cost & ")"
        strSQL += " AND (end_amnt >= " & cost & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "M31_PART_RATE")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView1(0)("part_rate")) Then GSS_rate = WK_DtView1(0)("part_rate")
            If Not IsDBNull(WK_DtView1(0)("part_amnt")) Then GSS_amnt = WK_DtView1(0)("part_amnt")
        End If

        If own_flg = "True" Then
            GSS_kijo = RoundUP(cost * GSS_rate * qty + GSS_amnt, -2)
        Else
            GSS_kijo = RoundUP(cost * GSS_rate * qty, -2)
            If (vndr_code = "01" Or vndr_code = "06") And note_kbn = "01" Then    'Apple定額
            Else
                If GSS_amnt <> 0 Then
                    If cost * qty >= 5000 Then
                        GSS_kijo = RoundUP(cost * GSS_rate * qty + GSS_amnt, -2)
                    End If
                End If
                If ibm_flg = "True" Then
                    GSS_kijo += 3000
                End If
            End If
        End If

        If grup_code = "18" Or grup_code = "52" Then  'BIC
            part_amnt = RoundUP(GSS_kijo * EU_rate, 0)
        Else
            part_amnt = RoundUP(GSS_kijo * EU_rate, -2)
        End If

        Return part_amnt
    End Function
End Class
