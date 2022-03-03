Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Sagyou_Report_BIC_EU_NU
    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_amnt2, WK_amnt3, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '修理内容
        TextBox12.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox12.Text = DtView1(i)("cmnt")
                Else
                    TextBox12.Text = TextBox12.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '修理内容
        TextBox.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox.Text = DtView1(i)("cmnt")
                Else
                    TextBox.Text = TextBox.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox18.Text = Nothing : TextBox26.Text = Nothing : TextBox7.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox8.Text = Nothing
        TextBox24.Text = Nothing : TextBox28.Text = Nothing : TextBox10.Text = Nothing
        TextBox25.Text = Nothing : TextBox31.Text = Nothing : TextBox11.Text = Nothing
        TextBox39.Text = Nothing : TextBox41.Text = Nothing : TextBox46.Text = Nothing
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
                        TextBox8.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox10.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 3
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox11.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox39.Text = DtView1(i)("part_name")
                        TextBox41.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox46.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 5 Then
                    TextBox39.Text = "その他部品"
                    TextBox41.Text = WK_cnt
                    TextBox46.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If

        '保障期間印字
        If PRT_PRAM5 = "True" Then
            Label22.Visible = True
            Label23.Visible = True
        Else
            Label22.Visible = False
            Label23.Visible = False
        End If
    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        TextBox7.Text = "\" & Format(CInt(TextBox7.Text), "##,##0")

        If Trim(TextBox67.Text) <> Nothing Then
            If Trim(TextBox12.Text) <> Nothing Then
                TextBox12.Text = TextBox12.Text & System.Environment.NewLine & TextBox67.Text
            Else
                TextBox12.Text = TextBox67.Text
            End If
        End If

        If Trim(TextBox69.Text) <> Nothing Then
            If Trim(TextBox.Text) <> Nothing Then
                TextBox.Text = TextBox.Text & System.Environment.NewLine & TextBox69.Text
            Else
                TextBox.Text = TextBox69.Text
            End If
        End If

        If fix1.Text <> "0" Then         '定額の場合非表示
            TextBox26.Text = Nothing : TextBox7.Text = Nothing
            TextBox27.Text = Nothing : TextBox8.Text = Nothing
            TextBox28.Text = Nothing : TextBox10.Text = Nothing
            TextBox31.Text = Nothing : TextBox11.Text = Nothing
            TextBox41.Text = Nothing : TextBox46.Text = Nothing
            'Label31.Visible = False : Label32.Visible = False : TextBox14.Visible = False : TextBox15.Visible = False : TextBox23.Visible = False : TextBox30.Visible = False
        End If


        If vndr_code.Text = "01" Then
            TextBox61.Text = "\" & Format(CInt(TextBox57.Text) + CInt(TextBox59.Text) + CInt(TextBox40.Text), "##,##0")
        Else
            Label9.Visible = False : TextBox40.Visible = False
            TextBox61.Text = "\" & Format(CInt(TextBox57.Text) + CInt(TextBox59.Text), "##,##0")
        End If

        TextBox57.Text = "¥" & TextBox57.Text
        TextBox59.Text = "¥" & TextBox59.Text
        TextBox40.Text = "¥" & TextBox40.Text


        Label23.Text = TextBox100.Text & "日です。"

        Select Case vndr_code.Text
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                Label27.Text = "個人情報の収集、利用、提供及び登録に関して、以下のように取扱い致します。"
                Label27.Text += vbCrLf & "①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用されません。"
                Label27.Text += vbCrLf & "②お客様情報の詳細（名前や連絡先番号など）は、Apple社によって提供または使用される場合が ございます。"
                Label27.Text += vbCrLf & "③上記の場合は除き、修理業務で知り得たお客様の個人情報は、第三者に漏洩、開示致しません。"
            Case Else
                Label27.Text = "＊個人情報の収集・利用・提供及び登録に関して、以下のように取り扱います。"
                Label27.Text += vbCrLf & "　①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用しません。"
                Label27.Text += vbCrLf & "　②上記の場合を除き、修理業務で知り得たお客様の個人情報は第三者に漏洩・開示しません。"
        End Select
    End Sub
End Class
