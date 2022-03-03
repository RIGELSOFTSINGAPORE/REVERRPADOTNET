Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Sagyou_Report_SofmapStore
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
        TextBox40.Text = Nothing : TextBox42.Text = Nothing : TextBox47.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox7.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
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
                    Case Is = 4
                        TextBox39.Text = DtView1(i)("part_name")
                        TextBox41.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox46.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox40.Text = DtView1(i)("part_name")
                        TextBox42.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox47.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 6 Then
                    TextBox40.Text = "その他部品"
                    TextBox42.Text = WK_cnt
                    TextBox47.Text = "\" & Format(WK_amnt, "##,##0")
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
        'prabu comment 20220107
        'TextBox7.Text = "\" & Format(TextBox7.Text, "##,##0")

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
            TextBox42.Text = Nothing : TextBox47.Text = Nothing
            'Label31.Visible = False : Label32.Visible = False : TextBox14.Visible = False : TextBox15.Visible = False : TextBox23.Visible = False : TextBox30.Visible = False
        End If

        If vndr_code.Text = "01" Then
            TextBox60.Text = "\" & Format(CInt(TextBox56.Text) + CInt(TextBox58.Text) + CInt(TextBox19.Text), "##,##0")
            TextBox61.Text = "\" & Format(CInt(TextBox57.Text) + CInt(TextBox59.Text) + CInt(TextBox38.Text), "##,##0")
        Else
            Label12.Visible = False : TextBox19.Visible = False : TextBox38.Visible = False
            TextBox60.Text = "\" & Format(CInt(TextBox56.Text) + CInt(TextBox58.Text), "##,##0")
            TextBox61.Text = "\" & Format(CInt(TextBox57.Text) + CInt(TextBox59.Text), "##,##0")
        End If

        TextBox56.Text = "¥" & TextBox56.Text

        TextBox57.Text = "¥" & TextBox57.Text
        TextBox58.Text = "¥" & TextBox58.Text
        TextBox59.Text = "¥" & TextBox59.Text
        TextBox19.Text = "¥" & TextBox19.Text
        TextBox38.Text = "¥" & TextBox38.Text

        'TextBox14.Text = "\" & Format(CInt(TextBox14.Text), "##,##0") : TextBox23.Text = "\" & Format(CInt(TextBox23.Text), "##,##0")
        'TextBox15.Text = "\" & Format(CInt(TextBox15.Text), "##,##0") : TextBox30.Text = "\" & Format(CInt(TextBox30.Text), "##,##0")
        'TextBox20.Text = "\" & Format(CInt(TextBox20.Text), "##,##0") : TextBox35.Text = "\" & Format(CInt(TextBox35.Text), "##,##0")
        'TextBox17.Text = "\" & Format(CInt(TextBox17.Text), "##,##0") : TextBox36.Text = "\" & Format(CInt(TextBox36.Text), "##,##0")

        'TextBox58.Text = "\" & Format(CInt(TextBox58.Text), "##,##0") : TextBox59.Text = "\" & Format(CInt(TextBox59.Text), "##,##0")
        'TextBox60.Text = "\" & Format(CInt(TextBox60.Text), "##,##0") : TextBox61.Text = "\" & Format(CInt(TextBox61.Text), "##,##0")

        Label23.Text = TextBox100.Text & "日です。"
    End Sub
End Class
