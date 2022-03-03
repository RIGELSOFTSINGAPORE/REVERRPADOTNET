Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_QGCare
    Inherits SectionReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        TextBox.Text = Format(Now, "yyyy/MM/dd")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

    End Sub
End Class
