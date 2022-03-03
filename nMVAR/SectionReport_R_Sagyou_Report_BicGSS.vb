Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Sagyou_Report_BicGSS
    Inherits SectionReport
    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        TextBox1.Text = "日付 " & Format(Now.Date, "yyyy年MM月dd日")

        '修理内容
        TextBox19.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox19.Text = DtView1(i)("cmnt")
                Else
                    TextBox19.Text = TextBox19.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox5.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox5.Text = DtView1(i)("cmnt")
                Else
                    TextBox5.Text = TextBox5.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '修理内容
        TextBox6.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox6.Text = DtView1(i)("cmnt")
                Else
                    TextBox6.Text = TextBox6.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox18.Text = Nothing : TextBox26.Text = Nothing : TextBox7.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox8.Text = Nothing
        TextBox24.Text = Nothing : TextBox28.Text = Nothing : TextBox9.Text = Nothing
        TextBox25.Text = Nothing : TextBox31.Text = Nothing : TextBox10.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox7.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox27.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox8.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox9.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox10.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox25.Text = "その他部品"
                    TextBox31.Text = WK_cnt
                    TextBox10.Text = Format(WK_amnt, "##,##0")
                End If
            Next
        End If
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Select Case vndr_code.Text
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                If Mid(orgnl_vndr_code.Text, 1, 1) = "G" Or Len(Trim(orgnl_vndr_code.Text)) = 10 Then
                    TextBox21.Text = rcpt_no.Text & " (" & orgnl_vndr_code.Text & ")"
                Else
                    TextBox21.Text = rcpt_no.Text
                End If

                Label29.Text = "個人情報の収集、利用、提供及び登録に関して、以下のように取扱い致します。"
                Label29.Text += vbCrLf & "①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用されません。"
                Label29.Text += vbCrLf & "②お客様情報の詳細（名前や連絡先番号など）は、Apple社によって提供または使用される場合が ございます。"
                Label29.Text += vbCrLf & "③上記の場合は除き、修理業務で知り得たお客様の個人情報は、第三者に漏洩、開示致しません。"
            Case Else
                TextBox21.Text = rcpt_no.Text
                TextBox17.Visible = False
                Label20.Visible = False : TextBox12.Visible = False
                Label31.Visible = False : TextBox53.Visible = False
                Label32.Visible = False : TextBox54.Visible = False

                Label29.Text = "＊個人情報の収集・利用・提供及び登録に関して、以下のように取り扱います。"
                Label29.Text += vbCrLf & "　①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用しません。"
                Label29.Text += vbCrLf & "　②上記の場合を除き、修理業務で知り得たお客様の個人情報は第三者に漏洩・開示しません。"
        End Select

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox19.Text) <> Nothing Then
                TextBox19.Text = TextBox19.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox19.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox5.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox49.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox49.Text
            Else
                TextBox6.Text = TextBox49.Text
            End If
        End If

        If Trim(TextBox71.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox71.Text
            Else
                TextBox6.Text = TextBox71.Text
            End If
        End If

        If fix1.Text <> "0" Then         '定額の場合非表示
            TextBox26.Text = Nothing : TextBox7.Text = Nothing
            TextBox27.Text = Nothing : TextBox8.Text = Nothing
            TextBox28.Text = Nothing : TextBox9.Text = Nothing
            TextBox31.Text = Nothing : TextBox10.Text = Nothing
            Label12.Visible = False : Label15.Visible = False : TextBox38.Visible = False : TextBox39.Visible = False
        End If

        TextBox39.Text = "\" & Format(CInt(TextBox50.Text) + CInt(TextBox51.Text) + CInt(TextBox52.Text), "##,##0")
        TextBox42.Text = "\" & Format(CInt(TextBox40.Text) + CInt(TextBox41.Text), "##,##0")

        TextBox40.Text = "¥" & TextBox40.Text
        TextBox41.Text = "¥" & TextBox41.Text

    End Sub

End Class
