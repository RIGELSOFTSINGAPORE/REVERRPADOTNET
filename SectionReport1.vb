Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport1
    Dim WK_DtView1 As DataView
    Dim i As Integer
    Dim WK_sum1, WK_sum2 As Decimal
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        hed02.Text = Format(Now(), "yyyy”NMMŒŽdd“ú")
    End Sub

    Private Sub ReportFooter1_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format
        WK_DtView1 = New DataView(P_DsPrint.Tables("Wrn_ivc"), "kbn_No1='" & TextBox46.Text & "'", "", DataViewRowState.CurrentRows)

        TextBox43.Text = WK_DtView1.Count
        WK_sum1 = 0
        WK_sum2 = 0

        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_sum1 = WK_sum1 + WK_DtView1(i)("¿‹Šz")
                WK_sum2 = WK_sum2 + WK_DtView1(i)("TAX")
            Next
        End If
        TextBox44.Text = "\" & Format(WK_sum1, "#,##0")
        TextBox45.Text = "\" & Format(WK_sum2, "#,##0")
    End Sub

    Private Sub GroupHeader2_AfterPrint(sender As Object, e As EventArgs) Handles GroupHeader2.AfterPrint
        TextBox38.Text = TextBox42.Text
        TextBox39.Text = TextBox47.Text
        TextBox40.Text = TextBox48.Text
        TextBox41.Text = TextBox49.Text
    End Sub

    Private Sub PageFooter_BeforePrint(sender As Object, e As EventArgs) Handles PageFooter.BeforePrint
        If CInt(TextBox32.Text) > CInt(TextBox33.Text) Then
            TextBox32.Text = TextBox33.Text
        End If
    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As EventArgs) Handles Detail.BeforePrint
        If TextBox50.Text = "True" Then TextBox21.Text = "S" Else TextBox21.Text = Nothing
    End Sub

    Private Sub GroupHeader1_BeforePrint(sender As Object, e As EventArgs) Handles GroupHeader1.BeforePrint
        ' GroupHeader1.AddBookmark(Me.Fields("kbn_No1").Value.ToString())
    End Sub

    Private Sub GroupHeader2_BeforePrint(sender As Object, e As EventArgs) Handles GroupHeader2.BeforePrint
        'GroupHeader2.AddBookmark(Me.Fields("kbn_No1").Value.ToString() + "\" + Me.Fields("kbn_No").Value.ToString())
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As EventArgs) Handles GroupHeader1.Format

    End Sub

    Private Sub SectionReport1_DataInitialize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DataInitialize
        ' Me.Fields.Add("kbn_No1")
    End Sub
End Class
