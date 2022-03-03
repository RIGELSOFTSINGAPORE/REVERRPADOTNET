Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Inquiry_Free_Inq
    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        TextBox1.Text = Format(Now.Date, "yyyyîNMMåéddì˙")

        'èCóùì‡óe
        TextBox12.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox12.Text = DtView1(i)("cmnt")
                Else
                    TextBox12.Text = TextBox12.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox12.Text) <> Nothing Then
                TextBox12.Text = TextBox12.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox12.Text = TextBox47.Text
            End If
        End If
    End Sub
End Class
