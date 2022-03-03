Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_NEVA_DEODEO
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        'èoâ◊ì˙
        TextBox.Text = Format(Now(), "yy")
        TextBox2.Text = Format(Now(), "MM")
        TextBox4.Text = Format(Now(), "dd")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

    End Sub
End Class
