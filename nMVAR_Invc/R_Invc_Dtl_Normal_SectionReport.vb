Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_Invc_Dtl_Normal_SectionReport
    Inherits SectionReport

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String
    Dim r As Integer
    Dim WK_C1, WK_C2 As String

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        TextBox1.Text = Format(Now, "yyyy年M月d日")
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format
        TextBox.Text = TextBox12.Text & " 御中"

        If TextBox15.Text = "0" Then    '締め不定期
            strSQL = "SELECT invc_date"
            strSQL = strSQL & " FROM T20_INVC_MTR"
            strSQL = strSQL & " WHERE (invc_code = '" & TextBox11.Text & "')"
            strSQL = strSQL & " AND (invc_date <> CONVERT(DATETIME, '" & TextBox13.Text & "', 102))"
            strSQL = strSQL & " AND (rcpt_brch_code = '" & TextBox14.Text & "')"
            strSQL = strSQL & " ORDER BY invc_date DESC"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(DsList1, "fr_date")
            DB_CLOSE()
            If r = 0 Then
                WK_C1 = Format(DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Month, -1, CDate(TextBox13.Text))), "yyyy年M月d日")    '1ヶ月前
            Else
                DtView1 = New DataView(DsList1.Tables("fr_date"), "", "", DataViewRowState.CurrentRows)
                WK_C1 = Format(DateAdd(DateInterval.Day, 1, CDate(DtView1(0)("invc_date"))), "yyyy年M月d日")
            End If
        Else
            WK_C1 = Format(DateAdd(DateInterval.Month, -1, DateAdd(DateInterval.Day, 1, CDate(TextBox13.Text))), "yyyy年M月d日")
        End If
        WK_C2 = Format(CDate(TextBox13.Text), "yyyy年M月d日")
        TextBox2.Text = "集計期間　　" & WK_C1 & "～" & WK_C2
    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format
        TextBox8.Text = "0"
    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        TextBox8.Text = CInt(TextBox8.Text) + CInt(TextBox07.Text)
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As EventArgs) Handles GroupFooter1.Format
        TextBox8.Text = "\" & Format(CInt(TextBox8.Text), "##,##0")
        TextBox9.Text = "\" & Format(RoundDOWN(CInt(TextBox8.Text) * 0.1, 0), "##,##0")
        TextBox10.Text = "\" & Format(CInt(TextBox8.Text) + CInt(TextBox9.Text), "##,##0")
    End Sub
End Class
