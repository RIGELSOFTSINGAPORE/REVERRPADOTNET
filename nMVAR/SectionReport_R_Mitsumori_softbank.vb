Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_softbank
    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '修理内容
        TextBox43.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox43.Text = DtView1(i)("cmnt")
                Else
                    TextBox43.Text = TextBox43.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox44.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox44.Text = DtView1(i)("cmnt")
                Else
                    TextBox44.Text = TextBox44.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox30.Text = Nothing : TextBox36.Text = Nothing : TextBox31.Text = Nothing : TextBox29.Text = Nothing
        TextBox40.Text = Nothing : TextBox37.Text = Nothing : TextBox32.Text = Nothing : TextBox28.Text = Nothing
        TextBox42.Text = Nothing : TextBox39.Text = Nothing : TextBox35.Text = Nothing : TextBox27.Text = Nothing
        TextBox41.Text = Nothing : TextBox38.Text = Nothing : TextBox34.Text = Nothing : TextBox26.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox30.Text = DtView1(i)("part_name")
                        TextBox36.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox29.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox40.Text = DtView1(i)("part_name")
                        TextBox37.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox32.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox28.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox42.Text = DtView1(i)("part_name")
                        TextBox39.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox35.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox27.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox41.Text = DtView1(i)("part_name")
                        TextBox38.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox34.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox26.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox41.Text = "その他部品"
                    TextBox38.Text = Nothing
                    TextBox34.Text = Nothing
                    TextBox26.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If
    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If TextBox18.Text = "True" Then
            TextBox17.Text = "過失：有"
        Else
            TextBox17.Text = "過失：無"
        End If

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox43.Text) <> Nothing Then
                TextBox43.Text = TextBox43.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox43.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox44.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox52.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox52.Text
            Else
                TextBox44.Text = TextBox52.Text
            End If
        End If

        If fix1.Text <> "0" And vndr_code.Text <> "02" Then       '定額の場合非表示
            TextBox36.Text = Nothing : TextBox31.Text = Nothing : TextBox29.Text = Nothing
            TextBox37.Text = Nothing : TextBox32.Text = Nothing : TextBox28.Text = Nothing
            TextBox39.Text = Nothing : TextBox35.Text = Nothing : TextBox27.Text = Nothing
            TextBox38.Text = Nothing : TextBox34.Text = Nothing : TextBox26.Text = Nothing
            Label46.Visible = False : Label24.Visible = False : TextBox24.Visible = False : TextBox25.Visible = False
        End If

        TextBox63.Text = "\" & Format(CInt(TextBox6.Text.Replace("¥", "")) + CInt(TextBox62.Text.Replace("¥", "")), "##,##0")

        Label4.Text = "見積有効期間： 見積後" & Trim(TextBox101.Text) & "日間"
        Label21.Text = "・ 交換部品の保証期間は、修理完了日より" & Trim(TextBox100.Text) & "日間です。"
        TextBox49.Text = "\" & Format(RoundDOWN(CInt(TextBox50.Text) * (1 + CInt(TextBox51.Text) / 100), 0), "##,##0")

    End Sub
End Class
