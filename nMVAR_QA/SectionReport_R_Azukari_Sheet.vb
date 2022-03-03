Imports System
Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Azukari_Sheet
    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'ïtëÆïi
        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        Label003.Text = Label003.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label103.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 1
                        Label004.Text = Label004.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label104.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 2
                        Label005.Text = Label005.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label105.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 3
                        Label006.Text = Label006.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label106.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 4
                        Label009.Text = Label009.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label109.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 5
                        Label010.Text = Label010.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label110.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 6
                        Label011.Text = Label011.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label111.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 7
                        Label012.Text = Label012.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label112.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 8
                        Label015.Text = Label015.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label115.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 9
                        Label016.Text = Label016.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label116.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 10
                        Label017.Text = Label017.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label117.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 11
                        Label018.Text = Label018.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label118.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 12
                        Label021.Text = Label021.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label121.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 13
                        Label022.Text = Label022.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label122.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 14
                        Label023.Text = Label023.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label123.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 15
                        Label024.Text = Label024.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label124.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 16
                        Label027.Text = Label027.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label127.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 17
                        Label028.Text = Label028.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label128.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 18
                        Label029.Text = Label029.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label129.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                    Case Is = 19
                        Label030.Text = Label030.Text & DtView1(i)("item_name")
                        If DtView1(i)("amnt") <> 0 Then Label130.Text = DtView1(i)("amnt") & DtView1(i)("item_unit")
                End Select
            Next
        End If

        'èCóùì‡óe
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox15.Text = DtView1(i)("cmnt")
                Else
                    TextBox15.Text = TextBox15.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Trim(TextBox24.Text) <> Nothing Then TextBox15.Text = TextBox15.Text & System.Environment.NewLine & TextBox24.Text
        If Trim(TextBox26.Text) <> Nothing Then TextBox15.Text = TextBox15.Text & System.Environment.NewLine & TextBox26.Text
    End Sub
End Class
