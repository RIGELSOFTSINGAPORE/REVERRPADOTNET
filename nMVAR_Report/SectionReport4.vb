Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport4
    Inherits SectionReport
    Dim date1, date2, date3 As Date
    Dim int1, int2 As Integer
    Dim WK_sum1, WK_sum2, WK_sum3, WK_sum4, WK_sum5, WK_sum6, WK_sum7, WK_sum8, WK_sum9, WK_sum10 As Decimal
    Dim WK_sumG1, WK_sumG2, WK_sumG3, WK_sumG4, WK_sumG5, WK_sumG6, WK_sumG7, WK_sumG8, WK_sumG9, WK_sumG10 As Decimal

    Public Sub New()

        InitializeComponent()

        date1 = CDate(P_PRAM1 & "/01")                                                  'äJén
        TextBox05.Text = Format(date1, "yyyyîNMMåéìx")

    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        WK_sum1 = WK_sum1 + TextBox12.Text
        WK_sum2 = WK_sum2 + TextBox13.Text
        WK_sum3 = WK_sum3 + TextBox14.Text
        WK_sum4 = WK_sum4 + TextBox15.Text
        WK_sum5 = WK_sum5 + TextBox16.Text
        WK_sum6 = WK_sum6 + TextBox17.Text
        WK_sum7 = WK_sum7 + TextBox18.Text
        WK_sum8 = WK_sum8 + TextBox19.Text
        WK_sum9 = WK_sum9 + TextBox40.Text
        WK_sum10 = WK_sum10 + TextBox41.Text
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        TextBox22.Text = Format(WK_sum1, "##,##0")
        TextBox23.Text = Format(WK_sum2, "##,##0")
        TextBox24.Text = Format(WK_sum3, "##,##0")
        TextBox25.Text = Format(WK_sum4, "##,##0")
        TextBox26.Text = Format(WK_sum5, "##,##0")
        TextBox27.Text = Format(WK_sum6, "##,##0")
        TextBox28.Text = Format(WK_sum7, "##,##0")
        TextBox29.Text = Format(WK_sum8, "##,##0")
        TextBox50.Text = Format(WK_sum9, "##,##0")
        TextBox51.Text = Format(WK_sum10, "##,##0")

        WK_sumG1 = WK_sumG1 + WK_sum1
        WK_sumG2 = WK_sumG2 + WK_sum2
        WK_sumG3 = WK_sumG3 + WK_sum3
        WK_sumG4 = WK_sumG4 + WK_sum4
        WK_sumG5 = WK_sumG5 + WK_sum5
        WK_sumG6 = WK_sumG6 + WK_sum6
        WK_sumG7 = WK_sumG7 + WK_sum7
        WK_sumG8 = WK_sumG8 + WK_sum8
        WK_sumG9 = WK_sumG9 + WK_sum9
        WK_sumG10 = WK_sumG10 + WK_sum10

        WK_sum1 = 0 : WK_sum2 = 0 : WK_sum3 = 0 : WK_sum4 = 0 : WK_sum5 = 0 : WK_sum6 = 0 : WK_sum7 = 0 : WK_sum8 = 0 : WK_sum9 = 0 : WK_sum10 = 0
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format
        TextBox31.Text = "ÇeÇpÇfëçåv"
        TextBox32.Text = Format(WK_sumG1, "##,##0")
        TextBox33.Text = Format(WK_sumG2, "##,##0")
        TextBox34.Text = Format(WK_sumG3, "##,##0")
        TextBox35.Text = Format(WK_sumG4, "##,##0")
        TextBox36.Text = Format(WK_sumG5, "##,##0")
        TextBox37.Text = Format(WK_sumG6, "##,##0")
        TextBox38.Text = Format(WK_sumG7, "##,##0")
        TextBox39.Text = Format(WK_sumG8, "##,##0")
        TextBox60.Text = Format(WK_sumG9, "##,##0")
        TextBox61.Text = Format(WK_sumG10, "##,##0")
    End Sub
End Class
