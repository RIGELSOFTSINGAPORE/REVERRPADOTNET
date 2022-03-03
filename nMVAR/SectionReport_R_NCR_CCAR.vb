Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_NCR_CCAR
    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        TextBox01.Text = Format(Now(), "yy")
        TextBox02.Text = Format(Now(), "MM")
        TextBox03.Text = Format(Now(), "dd")

        '•”•i
        TextBox51.Text = Nothing : TextBox55.Text = Nothing : TextBox59.Text = Nothing
        TextBox52.Text = Nothing : TextBox56.Text = Nothing : TextBox60.Text = Nothing
        TextBox53.Text = Nothing : TextBox57.Text = Nothing : TextBox61.Text = Nothing
        TextBox54.Text = Nothing : TextBox58.Text = Nothing : TextBox62.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox51.Text = DtView1(i)("part_name")
                        TextBox55.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox59.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox52.Text = DtView1(i)("part_name")
                        TextBox56.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox60.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox53.Text = DtView1(i)("part_name")
                        TextBox57.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox61.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox54.Text = DtView1(i)("part_name")
                        TextBox58.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox62.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox54.Text = "‚»‚Ì‘¼•”•i"
                    TextBox58.Text = WK_cnt
                    TextBox62.Text = Format(WK_amnt, "##,##0")
                End If
            Next
        End If

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        TextBox14.Text = Format(CInt(TextBox13.Text) + CInt(TextBox33.Text) + CInt(TextBox27.Text) + CInt(TextBox28.Text), "##,##0")
        TextBox30.Text = Format(CInt(TextBox14.Text) + CInt(TextBox29.Text), "##,##0")
        TextBox31.Text = Format(CInt(TextBox30.Text), "##,##0")
    End Sub
End Class
