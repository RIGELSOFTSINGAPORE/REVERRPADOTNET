Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_Invc_Kojima_SectionReport
    Inherits SectionReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        TextBox1.Text = Format(P_HSTY_DATE, "yyyy”NMMŒŽdd“ú")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        TextBox2.Text = TextBox9.Text
    End Sub
End Class
