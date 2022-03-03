Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_Eiden

    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()


        'å©êœì‡óe
        TextBox.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox.Text = DtView1(i)("cmnt")
                Else
                    TextBox.Text = TextBox.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox.Text) <> Nothing Then
                TextBox.Text = TextBox.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox27.Text) <> Nothing Then
            If Trim(TextBox.Text) <> Nothing Then
                TextBox.Text = TextBox.Text & System.Environment.NewLine & TextBox27.Text
            Else
                TextBox.Text = TextBox27.Text
            End If
        End If

        'TextBox4.Text = "\" & Format(CInt(TextBox36.Text) + CInt(TextBox41.Text) + CInt(TextBox21.Text) + CInt(TextBox13.Text), "##,##0")

    End Sub
End Class
