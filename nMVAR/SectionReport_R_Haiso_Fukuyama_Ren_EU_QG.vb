Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Haiso_Fukuyama_Ren_EU_QG

    Inherits SectionReport
    Public Sub New()

        InitializeComponent()

        TextBox01.Text = Format(Now(), "yy")
        TextBox02.Text = Format(Now(), "MM")
        TextBox03.Text = Format(Now(), "dd")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs)

    End Sub
End Class
