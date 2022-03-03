Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_Invc_Ks_SectionReport
    Inherits SectionReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        TextBox1.Text = Format(P_HSTY_DATE, "yyyy”NMMŒdd“ú ì¬")

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub
End Class
