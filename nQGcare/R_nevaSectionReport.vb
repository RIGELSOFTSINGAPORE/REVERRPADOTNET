Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_nevaSectionReport
    Inherits SectionReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        TextBox05.Text = P_EMPL_NAME
        TextBox08.Text = "¸ÞÛ°ÊÞÙ¿Ø­°¼®Ý»°ËÞ½Š”Ž®‰ïŽÐ"
        TextBox11.Text = Format(Now, "yyMMdd")
        TextBox12.Text = Format(Now, "yyMMdd")
    End Sub
End Class
