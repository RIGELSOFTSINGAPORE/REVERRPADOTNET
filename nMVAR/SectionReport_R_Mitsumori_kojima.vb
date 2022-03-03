Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Mitsumori_kojima

    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '修理内容
        TextBox2.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox2.Text = DtView1(i)("cmnt")
                Else
                    TextBox2.Text = TextBox2.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox5.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
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
        TextBox6.Text = Nothing : TextBox8.Text = Nothing
        TextBox10.Text = Nothing : TextBox25.Text = Nothing
        TextBox26.Text = Nothing : TextBox28.Text = Nothing
        TextBox31.Text = Nothing : TextBox33.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox6.Text = DtView1(i)("part_name")
                        TextBox8.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 1
                        TextBox10.Text = DtView1(i)("part_name")
                        TextBox25.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 2
                        TextBox26.Text = DtView1(i)("part_name")
                        TextBox28.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Else
                        TextBox31.Text = DtView1(i)("part_name")
                        TextBox33.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("eu_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox31.Text = "その他部品"
                    TextBox33.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format

        'ｱｯﾌﾟﾙの時表示
        If vndr_code.Text = "01" Then
            Picture.Visible = True
            Label21.Visible = True
        End If

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox2.Text) <> Nothing Then
                TextBox2.Text = TextBox2.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox2.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox5.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox27.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox27.Text
            Else
                TextBox5.Text = TextBox27.Text
            End If
        End If

        If fix1.Text <> "0" And vndr_code.Text <> "02" Then       '定額の場合非表示
            TextBox8.Text = Nothing
            TextBox25.Text = Nothing
            TextBox28.Text = Nothing
            TextBox33.Text = Nothing
            Label11.Visible = False : Label12.Visible = False : TextBox36.Visible = False : TextBox41.Visible = False
        End If

        TextBox44.Text = "\" & Format(CInt(TextBox43.Text.Replace("¥", "")) + CInt(TextBox45.Text.Replace("¥", "")), "##,##0")
        TextBox18.Text = "\" & Format(CInt(TextBox44.Text.Replace("\", "")), "##,##0")

    End Sub
End Class
