Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_Kanyu_ipadSectionReport
    Dim WK_prt_date As Date
    Dim WK_str As String
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP", True)
        Culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
        WK_prt_date = Now.Date
        prt_date.Text = "�T�[�r�X�ؔ��s���@�F" & WK_prt_date.ToString("yyyy�NM��d��")

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

    End Sub
End Class
