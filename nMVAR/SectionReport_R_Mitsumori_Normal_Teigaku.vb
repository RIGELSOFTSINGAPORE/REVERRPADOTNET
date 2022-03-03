Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_Normal_Teigaku

    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '修理内容
        TextBox43.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox43.Text = DtView1(i)("cmnt")
                Else
                    TextBox43.Text = TextBox43.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox44.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox44.Text = DtView1(i)("cmnt")
                Else
                    TextBox44.Text = TextBox44.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox30.Text = Nothing
        TextBox40.Text = Nothing
        TextBox42.Text = Nothing
        TextBox41.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox30.Text = DtView1(i)("part_name")
                    Case Is = 1
                        TextBox40.Text = DtView1(i)("part_name")
                    Case Is = 2
                        TextBox42.Text = DtView1(i)("part_name")
                    Case Else
                        TextBox41.Text = DtView1(i)("part_name")
                End Select

                If DtView1.Count > 4 Then
                    TextBox41.Text = "その他部品"
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
            If Trim(TextBox43.Text) <> Nothing Then
                TextBox43.Text = TextBox43.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox43.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox44.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox28.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox28.Text
            Else
                TextBox44.Text = TextBox28.Text
            End If
        End If

        'TextBox6.Text = Format(CInt(TextBox25.Text) + CInt(TextBox24.Text) + CInt(TextBox8.Text) + CInt(TextBox7.Text), "##,##0")
        TextBox63.Text = "\" & Format(CInt(TextBox6.Text) + CInt(TextBox62.Text), "##,##0")

        'Label4.Text = "見積有効期間： 見積後" & StrConv(TextBox101.Text, VbStrConv.Wide) & "日間"
        Label4.Text = "見積有効期間： 見積後" & Trim(TextBox101.Text) & "日間"
        'Label21.Text = "・ 交換部品の保証期間は、修理完了日より" & StrConv(TextBox100.Text, VbStrConv.Wide) & "日間です。"
        Label21.Text = "・ 交換部品の保証期間は、修理完了日より" & (TextBox100.Text) & "日間です。"
        TextBox4.Text = "\" & Format(RoundDOWN(CInt(TextBox26.Text) * (1 + CInt(TextBox27.Text) / 100), 0), "##,##0")

    End Sub
End Class
