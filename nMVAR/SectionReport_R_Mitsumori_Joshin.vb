Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_Joshin

    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '修理内容
        TextBox62.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox62.Text = DtView1(i)("cmnt")
                Else
                    TextBox62.Text = TextBox62.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox63.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox63.Text = DtView1(i)("cmnt")
                Else
                    TextBox63.Text = TextBox63.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox32.Text = Nothing : TextBox57.Text = Nothing
        TextBox35.Text = Nothing : TextBox4.Text = Nothing
        TextBox37.Text = Nothing : TextBox11.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox32.Text = DtView1(i)("part_name")
                        TextBox57.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox35.Text = DtView1(i)("part_name")
                        TextBox4.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox37.Text = DtView1(i)("part_name")
                        TextBox11.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 3 Then
                    TextBox37.Text = "その他部品"
                    TextBox11.Text = Format(WK_amnt, "##,##0")
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
            If Trim(TextBox62.Text) <> Nothing Then
                TextBox62.Text = TextBox62.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox62.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox63.Text) <> Nothing Then
                TextBox63.Text = TextBox63.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox63.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox27.Text) <> Nothing Then
            If Trim(TextBox63.Text) <> Nothing Then
                TextBox63.Text = TextBox63.Text & System.Environment.NewLine & TextBox27.Text
            Else
                TextBox63.Text = TextBox27.Text
            End If
        End If

        'TextBox61.Text = Format(CInt(TextBox12.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text) + CInt(TextBox5.Text), "##,##0")

    End Sub
End Class
