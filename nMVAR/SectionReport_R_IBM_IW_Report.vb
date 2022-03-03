Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_IBM_IW_Report
    Inherits SectionReport
    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()

        MyBase.New()
        InitializeComponent()

        'åÃè·ì‡óe
        TextBox30.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox30.Text = DtView1(i)("cmnt")
                Else
                    TextBox30.Text = TextBox30.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'èCóùì‡óe
        TextBox7.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox7.Text = DtView1(i)("cmnt")
                Else
                    TextBox7.Text = TextBox7.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'ïîïi
        TextBox28.Text = Nothing : TextBox33.Text = Nothing
        TextBox31.Text = Nothing : TextBox34.Text = Nothing
        TextBox32.Text = Nothing : TextBox35.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox28.Text = DtView1(i)("part_code")
                        TextBox33.Text = DtView1(i)("part_name")
                    Case Is = 1
                        TextBox31.Text = DtView1(i)("part_code")
                        TextBox34.Text = DtView1(i)("part_name")
                    Case Is = 2
                        TextBox32.Text = DtView1(i)("part_code")
                        TextBox35.Text = DtView1(i)("part_name")
                    Case Else
                End Select
            Next
        End If

    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox30.Text) <> Nothing Then
                TextBox30.Text = TextBox30.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox30.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox7.Text) <> Nothing Then
                TextBox7.Text = TextBox7.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox7.Text = TextBox48.Text
            End If
        End If
    End Sub
End Class
