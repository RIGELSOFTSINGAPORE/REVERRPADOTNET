Imports System
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport2
    Inherits SectionReport

    Dim WK_sum1, WK_sum2, WK_sum3, Page, No As Integer
    Dim WK_sumG2, WK_sumG3 As Integer
    Public Sub New()

        InitializeComponent()
        TextBox17.Text = P_PRAM1 'P_PRAM1
        TextBox16.Text = Format(Now, "yyyy”NMMŒŽdd“ú")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format
        Page = Page + 1
        TextBox19.Text = Page & " / "
    End Sub

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        WK_sum1 = WK_sum1 + TextBox6.Text
        WK_sum2 = WK_sum2 + TextBox11.Text
        WK_sum3 = WK_sum3 + TextBox12.Text

        No = No + 1
        TextBox15.Text = No
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        TextBox106.Text = Format(Round(WK_sum1 / No, 1), "##0.0")
        TextBox111.Text = Format(WK_sum2, "###,###,##0")
        TextBox112.Text = Format(WK_sum3, "###,###,##0")

        WK_sumG2 = WK_sumG2 + WK_sum2
        WK_sumG3 = WK_sumG3 + WK_sum3

        WK_sum1 = 0
        WK_sum2 = 0
        WK_sum3 = 0
        No = 0
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        TextBox211.Text = Format(WK_sumG2, "###,###,##0")
        TextBox212.Text = Format(WK_sumG3, "###,###,##0")
    End Sub
End Class
