﻿Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Sagyou_Report_jyoshin_apple_EU
    Inherits SectionReport
    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        TextBox1.Text = Format(Now.Date, "yyyy年MM月dd日")

        '申告内容
        TextBox19.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox19.Text = DtView1(i)("cmnt")
                Else
                    TextBox19.Text = TextBox19.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '修理内容
        TextBox6.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox6.Text = DtView1(i)("cmnt")
                Else
                    TextBox6.Text = TextBox6.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox7.Text = Nothing : TextBox18.Text = Nothing : TextBox26.Text = Nothing : TextBox32.Text = Nothing
        TextBox8.Text = Nothing : TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox33.Text = Nothing
        TextBox10.Text = Nothing : TextBox24.Text = Nothing : TextBox28.Text = Nothing : TextBox34.Text = Nothing
        TextBox17.Text = Nothing : TextBox25.Text = Nothing : TextBox31.Text = Nothing : TextBox37.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox7.Text = DtView1(i)("part_code")
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox32.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 1
                        TextBox8.Text = DtView1(i)("part_code")
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox27.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox33.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 2
                        TextBox10.Text = DtView1(i)("part_code")
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox34.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Else
                        TextBox17.Text = DtView1(i)("part_code")
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox37.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("eu_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox17.Text = "その他部品"
                    TextBox25.Text = Nothing
                    TextBox31.Text = WK_cnt
                    TextBox37.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If

        '部品番号印字
        If PRT_PRAM4 = "True" Then
            Shape.Visible = False
        Else
            Shape.Visible = True
        End If

        '保障期間印字
        If PRT_PRAM5 = "True" Then
            Label25.Visible = True
            Label26.Visible = True
        Else
            Label25.Visible = False
            Label26.Visible = False
        End If
    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox19.Text) <> Nothing Then
                TextBox19.Text = TextBox19.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox19.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox49.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox49.Text
            Else
                TextBox6.Text = TextBox49.Text
            End If
        End If

        If fix1.Text <> "0" Then         '定額の場合非表示
            TextBox26.Text = Nothing : TextBox32.Text = Nothing
            TextBox27.Text = Nothing : TextBox33.Text = Nothing
            TextBox28.Text = Nothing : TextBox34.Text = Nothing
            TextBox31.Text = Nothing : TextBox37.Text = Nothing
            Label15.Visible = False : Label16.Visible = False : TextBox38.Visible = False : TextBox39.Visible = False
        End If

        TextBox39.Text = "\" & Format(CInt(TextBox50.Text) + CInt(TextBox51.Text) + CInt(TextBox52.Text), "##,##0")
        TextBox42.Text = "\" & Format(CInt(TextBox40.Text) + CInt(TextBox41.Text), "##,##0")
        TextBox40.Text = "¥" & TextBox40.Text
        TextBox41.Text = "¥" & TextBox41.Text

        Label25.Text = "修理後保証は交換部品に対して適用されます。修理保証期間は修理完了日から" & TextBox100.Text & "日間となっております。"
    End Sub
End Class
