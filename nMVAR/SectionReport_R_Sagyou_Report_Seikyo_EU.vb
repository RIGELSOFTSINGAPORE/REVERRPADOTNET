Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Sagyou_Report_Seikyo_EU
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
        TextBox7.Text = Nothing : TextBox18.Text = Nothing : TextBox26.Text = Nothing
        TextBox8.Text = Nothing : TextBox22.Text = Nothing : TextBox27.Text = Nothing
        TextBox10.Text = Nothing : TextBox24.Text = Nothing : TextBox28.Text = Nothing
        TextBox17.Text = Nothing : TextBox25.Text = Nothing : TextBox31.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox7.Text = DtView1(i)("part_code")
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Is = 1
                        TextBox8.Text = DtView1(i)("part_code")
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox27.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Is = 2
                        TextBox10.Text = DtView1(i)("part_code")
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Else
                        TextBox17.Text = DtView1(i)("part_code")
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                End Select

                If DtView1.Count > 4 Then
                    TextBox17.Text = "その他部品"
                    TextBox25.Text = Nothing
                    TextBox31.Text = WK_cnt
                End If
            Next
        End If

        '部品番号印字
        If PRT_PRAM4 = "True" Then
            Shape.Visible = False
        Else
            Shape.Visible = True
        End If

        '保障期間印字
        If PRT_PRAM5 = "True" Then
            Label25.Visible = True
        Else
            Label25.Visible = False
        End If

        '富士通保険
        If P_grup = "88" Then
            Label12.Visible = False '延長保証情報
            TextBox32.Visible = False
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
                TextBox5.Visible = False
                Label7.Visible = False : TextBox48.Visible = False
                Label6.Visible = False : TextBox53.Visible = False
                Label32.Visible = False : TextBox54.Visible = False

                Label29.Text = "＊個人情報の収集・利用・提供及び登録に関して、以下のように取り扱います。"
                Label29.Text += vbCrLf & "　①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用しません。"
                Label29.Text += vbCrLf & "　②上記の場合を除き、修理業務で知り得たお客様の個人情報は第三者に漏洩・開示しません。"
        End Select

        ''イレギュラー処理（2010/04までは限度額残高を表示しない）
        'If TextBox50.Text < "2010/04/01" Then
        Label4.Visible = False
        Label24.Visible = False
        Label31.Visible = False
        TextBox37.Visible = False
        Line6.Visible = False
        Line14.Visible = False
        Line23.Visible = False
        'End If

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox19.Text) <> Nothing Then
                TextBox19.Text = TextBox19.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox19.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox49.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox49.Text
            Else
                TextBox6.Text = TextBox49.Text
            End If
        End If

        Select Case Mid(TextBox42.Text, 1, 1)
            Case Is = "A", "E"
                Dim wk_lmt As Integer
                wk_lmt = CInt(TextBox41.Text) - (CInt(TextBox51.Text) + CInt(TextBox62.Text))
                If wk_lmt > 0 Then
                    TextBox37.Text = "\" & Format(wk_lmt, "##,##0")
                Else
                    TextBox37.Text = "\0"
                End If
            Case Else
                TextBox37.Text = "\" & Format(CInt(TextBox41.Text), "##,##0")
        End Select

        Label25.Text = "修理後保証は交換部品に対して適用されます。修理後保証期間は修理完了日から" & TextBox100.Text & "日 でございます。"
        Label25.Text += vbCrLf & "※修理後保証は機能障害のみに対して適用され、筐体の損傷やお客様過失による故障などには適用され ません。"
        Label25.Text += vbCrLf & "尚、修理/交換した部品または製品は、新品、または性能と信頼性の両面に置いて新品同様でございます。"
    End Sub
End Class
