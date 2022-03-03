Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_HP_Exc_TAG
    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '故障内容
        '故障内容
        TextBox20.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox20.Text = DtView1(i)("cmnt")
                Else
                    TextBox20.Text = TextBox20.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '修理内容
        TextBox5.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox5.Text = DtView1(i)("cmnt")
                Else
                    TextBox5.Text = TextBox5.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox6.Text = Nothing : TextBox10.Text = Nothing : TextBox24.Text = Nothing : TextBox27.Text = Nothing : TextBox32.Text = Nothing : TextBox36.Text = Nothing
        TextBox7.Text = Nothing : TextBox18.Text = Nothing : TextBox25.Text = Nothing : TextBox28.Text = Nothing : TextBox33.Text = Nothing : TextBox37.Text = Nothing
        TextBox8.Text = Nothing : TextBox19.Text = Nothing : TextBox26.Text = Nothing : TextBox31.Text = Nothing : TextBox34.Text = Nothing : TextBox38.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox10.Text = DtView1(i)("part_code")
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox36.Text = Format(DtView1(i)("shop_chrg") * DtView1(i)("use_qty"), "##,##0")
                    Case Is = 1
                        TextBox18.Text = DtView1(i)("part_code")
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox37.Text = Format(DtView1(i)("shop_chrg") * DtView1(i)("use_qty"), "##,##0")
                    Case Is = 2
                        TextBox19.Text = DtView1(i)("part_code")
                        TextBox26.Text = DtView1(i)("part_name")
                        TextBox38.Text = Format(DtView1(i)("shop_chrg") * DtView1(i)("use_qty"), "##,##0")
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
        If Trim(TextBox53.Text) <> Nothing Then
            If Trim(TextBox20.Text) <> Nothing Then
                TextBox20.Text = TextBox20.Text & System.Environment.NewLine & TextBox53.Text
            Else
                TextBox20.Text = TextBox53.Text
            End If
        End If

        If Trim(TextBox54.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox54.Text
            Else
                TextBox5.Text = TextBox54.Text
            End If
        End If

        TextBox42.Text = 0
        TextBox43.Text = Format(CInt(TextBox55.Text) + CInt(TextBox56.Text), "##,##0")
        TextBox44.Text = Format(CInt(TextBox39.Text) + CInt(TextBox41.Text) + CInt(TextBox42.Text) + CInt(TextBox43.Text), "##,##0")
        TextBox46.Text = Format(CInt(TextBox44.Text) + CInt(TextBox45.Text), "##,##0")
    End Sub
End Class
