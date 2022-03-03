Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_Apple
    Inherits SectionReport
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet

    Dim DtView1 As DataView
    Dim strSQL As String
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '修理内容
        TextBox16.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox16.Text = DtView1(i)("cmnt")
                Else
                    TextBox16.Text += vbCrLf & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox17.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox17.Text = DtView1(i)("cmnt")
                Else
                    TextBox17.Text += vbCrLf & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox18.Text = Nothing : TextBox25.Text = Nothing : TextBox32.Text = Nothing : TextBox39.Text = Nothing
        TextBox19.Text = Nothing : TextBox26.Text = Nothing : TextBox33.Text = Nothing : TextBox40.Text = Nothing
        TextBox20.Text = Nothing : TextBox27.Text = Nothing : TextBox34.Text = Nothing : TextBox41.Text = Nothing
        TextBox21.Text = Nothing : TextBox28.Text = Nothing : TextBox35.Text = Nothing : TextBox42.Text = Nothing
        TextBox22.Text = Nothing : TextBox29.Text = Nothing : TextBox36.Text = Nothing : TextBox43.Text = Nothing
        'TextBox23.Text = Nothing : TextBox30.Text = Nothing : TextBox37.Text = Nothing : TextBox44.Text = Nothing
        'TextBox24.Text = Nothing : TextBox31.Text = Nothing : TextBox38.Text = Nothing : TextBox45.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox25.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox32.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox39.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox19.Text = DtView1(i)("part_name")
                        TextBox26.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox33.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox40.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox20.Text = DtView1(i)("part_name")
                        TextBox27.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox34.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox41.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 3
                        TextBox21.Text = DtView1(i)("part_name")
                        TextBox28.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox35.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox42.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        'Case Is = 4
                        '    TextBox22.Text = DtView1(i)("part_name")
                        '    TextBox29.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        '    TextBox36.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        '    TextBox43.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        'Case Is = 5
                        '    TextBox23.Text = DtView1(i)("part_name")
                        '    TextBox30.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        '    TextBox37.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        '    TextBox44.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox29.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox36.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox43.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 7 Then
                    TextBox22.Text = "その他部品"
                    TextBox29.Text = Nothing
                    TextBox36.Text = Nothing
                    TextBox43.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If arvl_cls_abbr.Text = "販社" Then '販社
            TextBox1.Text = store_name.Text '販社名
        Else
            TextBox1.Text = Nothing
        End If
        TextBox2.Text = TextBox60.Text & "　様"

        TextBox3.Text = Nothing 'E-mail
        If Trim(TextBox63.Text) <> "refused@apple.com" Then
            TextBox3.Text = Trim(TextBox63.Text)
        End If

        TextBox9.Text = StrConv(Trim(TextBox61.Text.Replace(vbCrLf, "")), VbStrConv.Narrow) & " " & StrConv(Trim(TextBox62.Text), VbStrConv.Narrow)
        TextBox10.Text = "TEL " & TextBox56.Text & "　FAX " & TextBox57.Text
        fax.Text = TextBox57.Text

        Dim wk_tel As String = Nothing
        DsList1.Clear()
        strSQL = "SELECT print_tel, print_fax FROM M08_STORE WHERE (store_code = '" & store_code.Text & "')"
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
                    fax.Text = Trim(DtView1(0)("print_fax"))
                End If
            End If
        End If
        If wk_tel <> Nothing Then
            TextBox10.Text = wk_tel
        End If

        TextBox14.Text = "発行から" & TextBox101.Text & "日"

        If Trim(TextBox16_d.Text) <> Nothing Then
            If Trim(TextBox16.Text) <> Nothing Then
                TextBox16.Text += vbCrLf & TextBox16_d.Text
            Else
                TextBox16.Text = TextBox16_d.Text
            End If
        End If

        If Trim(TextBox17_d.Text) <> Nothing Then
            If Trim(TextBox17.Text) <> Nothing Then
                TextBox17.Text += vbCrLf & TextBox17_d.Text
            Else
                TextBox17.Text = TextBox17_d.Text
            End If
        End If

        If Trim(TextBox17_d2.Text) <> Nothing Then
            If Trim(TextBox17.Text) <> Nothing Then
                TextBox17.Text += vbCrLf & TextBox17_d2.Text
            Else
                TextBox17.Text = TextBox17_d2.Text
            End If
        End If

        TextBox52.Text = "\" & Format(CInt(TextBox47.Text) + CInt(TextBox48.Text) + CInt(TextBox49.Text) + CInt(TextBox50.Text) + CInt(TextBox51.Text), "##,##0")

        Label29.Text = "\" & Format(RoundDOWN(CInt(TextBox46.Text) * (1 + CInt(TextBox59.Text) / 100), 0), "##,##0") & " ご請求させていただきます。"

        TextBox54.Text = "見積内容に記載された部品、価格は予告なく変更する場合があります。"
        TextBox54.Text += vbCrLf & "修理交換された旧部品は、弊社またはApple所有とさせていただきます。"
        TextBox54.Text += vbCrLf & "修理後保証は交換部品に対して適用されます。修理後保証期間は修理完了から" & StrConv(TextBox100.Text, VbStrConv.Wide) & "日です。"
        TextBox54.Text += vbCrLf & "※修理保証は機器障害にのみ適用され、筐体の破損やお客様過失による故障などには適用されません。"
        TextBox54.Text += vbCrLf & "プログラム、データ、ソフトウェア等の損傷や喪失については、弊社の過失の有無を問わず"
        TextBox54.Text += vbCrLf & "いかなる場合も弊社はその責任を負わないものとします。"


        TextBox54.Text += vbCrLf & "個人情報の収集、利用、提供及び登録に関して、以下の3点に同意するものとします。"
        TextBox54.Text += vbCrLf & "①修理業務を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理目的以外には使用されません。"
        TextBox54.Text += vbCrLf & "②お客様情報の詳細（名前や電話番号）はApple社によって提供または使用される場合があります。"
        TextBox54.Text += vbCrLf & "③上記の場合を除き、修理業務で知りえたお客様情報は、第三者に漏洩、開示いたしません。"

        TextBox55.Text = "見積有効期限内（" & TextBox.Text & "）までにご回答いただけない場合は、製品を返却させていただきます。"
        TextBox55.Text += vbCrLf & "下記に回答およびご署名いただき、FAX（" & fax.Text & "）にて返信をお願いいたします。"

        If Trim(TextBox7.Text) = Nothing Then
            Label9.Visible = False
        End If
    End Sub
End Class
