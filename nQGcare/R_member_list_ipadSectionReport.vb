Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_member_list_ipadSectionReport
    Inherits SectionReport

    Dim WK_int1, WK_int2, WK_int3 As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        date_now.Text = Now.Date

    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format
        TextBox2.Text = TextBox17.Text
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub



    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        WK_int1 = TextBox15.Text
        WK_int2 = TextBox16.Text
        WK_int3 = RoundDOWN(WK_int2 / WK_int1, 0)
        GF1.Text = "店舗計" & "( " & Format(WK_int1, "##,##0") & "件、　保証料単価:" & Format(WK_int3, "##,##0") & "円、　保証金額:" & Format(WK_int2, "##,##0") & "円)"

    End Sub

    Private Sub GroupFooter2_Format(sender As Object, e As EventArgs) Handles GroupFooter2.Format
        WK_int1 = TextBox12.Text
        WK_int2 = TextBox14.Text
        WK_int3 = RoundDOWN(WK_int2 / WK_int1, 0)
        GF2.Text = TextBox10.Text & "( " & Format(WK_int1, "##,##0") & "件、　保証料単価:" & Format(WK_int3, "##,##0") & "円、　保証金額:" & Format(WK_int2, "##,##0") & "円)"

    End Sub
End Class
