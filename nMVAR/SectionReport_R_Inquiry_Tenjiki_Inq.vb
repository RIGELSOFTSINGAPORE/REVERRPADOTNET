Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Inquiry_Tenjiki_Inq
    Inherits SectionReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        TextBox1.Text = Format(Now.Date, "yyyy”NMMŒŽdd“ú")

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub
End Class
