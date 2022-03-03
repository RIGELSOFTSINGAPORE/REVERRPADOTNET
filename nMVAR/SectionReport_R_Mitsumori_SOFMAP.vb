Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_SOFMAP

    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_amnt2 As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '修理内容
        TextBox2.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox2.Text = DtView1(i)("cmnt")
                Else
                    TextBox2.Text = TextBox2.Text & System.Environment.NewLine & DtView1(i)("cmnt")
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

        '部品
        TextBox6.Text = Nothing : TextBox7.Text = Nothing : TextBox8.Text = Nothing
        TextBox10.Text = Nothing : TextBox24.Text = Nothing : TextBox25.Text = Nothing
        TextBox26.Text = Nothing : TextBox27.Text = Nothing : TextBox28.Text = Nothing
        TextBox31.Text = Nothing : TextBox32.Text = Nothing : TextBox33.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox6.Text = DtView1(i)("part_name")
                        TextBox7.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                        TextBox8.Text = Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 1
                        TextBox10.Text = DtView1(i)("part_name")
                        TextBox24.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        TextBox25.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 2
                        TextBox26.Text = DtView1(i)("part_name")
                        TextBox27.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        TextBox28.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Else
                        TextBox31.Text = DtView1(i)("part_name")
                        TextBox32.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        TextBox33.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                        WK_amnt2 = WK_amnt2 + DtView1(i)("eu_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox31.Text = "その他部品"
                    TextBox32.Text = "\" & Format(WK_amnt, "##,##0")
                    TextBox33.Text = "\" & Format(WK_amnt2, "##,##0")
                End If
            Next
        End If
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

        TextBox7.Text = "\" & Format(CInt(TextBox7.Text), "##,##0")
        TextBox8.Text = "\" & Format(CInt(TextBox8.Text), "##,##0")

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox2.Text) <> Nothing Then
                TextBox2.Text = TextBox2.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox2.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox5.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox54.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox54.Text
            Else
                TextBox5.Text = TextBox54.Text
            End If
        End If

        'If note_kbn.Text = "01" Then   '定額の場合非表示
        If fix1.Text <> "0" And vndr_code.Text <> "02" Then       '定額の場合非表示
            TextBox7.Text = Nothing : TextBox8.Text = Nothing
            TextBox24.Text = Nothing : TextBox25.Text = Nothing
            TextBox27.Text = Nothing : TextBox28.Text = Nothing
            TextBox32.Text = Nothing : TextBox33.Text = Nothing
            Label11.Visible = False : Label12.Visible = False : TextBox35.Visible = False : TextBox36.Visible = False : TextBox37.Visible = False : TextBox41.Visible = False
        End If

        'TextBox42.Text = "\" & Format(CInt(TextBox35.Text) + CInt(TextBox37.Text) + CInt(TextBox40.Text) + CInt(TextBox49.Text), "##,##0")
        TextBox34.Text = Format(CInt(TextBox42.Text) + CInt(TextBox46.Text), "##,##0")

        'TextBox43.Text = "\" & Format(CInt(TextBox36.Text) + CInt(TextBox41.Text) + CInt(TextBox3.Text) + CInt(TextBox20.Text), "##,##0")
        TextBox44.Text = Format(CInt(TextBox43.Text) + CInt(TextBox45.Text), "##,##0")
        TextBox18.Text = "\" & Format(CInt(TextBox44.Text), "##,##0")

        TextBox34.Text = "¥" & TextBox34.Text
        TextBox43.Text = "¥" & TextBox43.Text
        TextBox44.Text = "¥" & TextBox44.Text
        TextBox45.Text = "¥" & TextBox45.Text
        TextBox42.Text = "¥" & TextBox42.Text
        TextBox46.Text = "¥" & TextBox46.Text

        Label21.Text = "★ 修理キャンセル時は診断/見積料    \" & Format(RoundDOWN(CInt(TextBox50.Text) * (1 + CInt(TextBox52.Text) / 100), 0), "##,##0") & "（消費税込）をご請求申し上げます ★"

    End Sub
End Class
