Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Inquiry_Siriaru_Inq
    Inherits SectionReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        TextBox1.Text = Format(Now.Date, "yyyy年MM月dd日")

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        Label26.Text = " 　御預かりいたしました修理機S/N：" & Label38.Text & " と同梱物S/N：" & Label40.Text

    End Sub
End Class
