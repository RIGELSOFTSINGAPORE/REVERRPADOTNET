Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_Invc_Normal_SectionReport
    Inherits SectionReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        TextBox1.Text = Format(P_HSTY_DATE, "yyyy”NMMŒŽdd“ú")
        TextBox5.Text = Format(P_close_DATE, "yyyy”NMMŒŽdd“ú")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub
End Class
