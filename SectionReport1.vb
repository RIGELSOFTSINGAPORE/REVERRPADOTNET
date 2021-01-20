Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport1
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextBox9.Text = Format(Now(), "yyyy”NMMŒŽdd“ú")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Trim(TextBox8.Text) = Nothing Then
            TextBox7.Text = Nothing
        Else
            TextBox7.Text = Format(CDate(Mid(TextBox8.Text, 1, 4) & "/" & Mid(TextBox8.Text, 5, 2) & "/" & Mid(TextBox8.Text, 7, 2)), "yyyy.MM.dd")
        End If
    End Sub
End Class
