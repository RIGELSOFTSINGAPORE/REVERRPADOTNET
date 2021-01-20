Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document


Public Class SectionReport2
    Dim WK_DtView1 As DataView
    Dim i As Integer
    Dim WK_sum1, WK_sum2 As Decimal
    Public Sub New()
        InitializeComponent()
        hed02.Text = Format(Now(), "yyyy”NMMŒŽdd“ú")
    End Sub
    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs) Handles ReportFooter1.Format

    End Sub
    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        WK_DtView1 = New DataView(P_DsPrint.Tables("Wrn_ivc"), "kbn_No1='" & TextBox52.Text & "'", "", DataViewRowState.CurrentRows)

        TextBox49.Text = WK_DtView1.Count
        WK_sum1 = 0
        WK_sum2 = 0

        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_sum1 = WK_sum1 + WK_DtView1(i)("¿‹Šz")
                WK_sum2 = WK_sum2 + WK_DtView1(i)("TAX")
            Next
        End If
        TextBox50.Text = "\" & Format(WK_sum1, "#,##0")
        TextBox51.Text = "\" & Format(WK_sum2, "#,##0")
    End Sub

    Private Sub GroupHeader2_AfterPrint(sender As Object, e As EventArgs) Handles GroupHeader2.AfterPrint
        TextBox53.Text = TextBox55.Text
        TextBox54.Text = TextBox56.Text
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format

    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As EventArgs) Handles Detail.BeforePrint
        If TextBox58.Text = "True" Then TextBox59.Text = "S" Else TextBox59.Text = Nothing
    End Sub

    Private Sub SectionReport2_DataInitialize(sender As Object, e As EventArgs) Handles Me.DataInitialize

    End Sub

    Private Sub PageFooter_BeforePrint(sender As Object, e As EventArgs) Handles PageFooter.BeforePrint
        If CInt(TextBox47.Text) > CInt(TextBox48.Text) Then
            TextBox47.Text = TextBox48.Text
        End If
    End Sub
End Class
