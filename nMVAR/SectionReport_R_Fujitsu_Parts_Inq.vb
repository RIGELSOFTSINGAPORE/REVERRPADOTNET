Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_Fujitsu_Parts_Inq
    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Label5.Text = Format(P_HSTY_DATE, "GSS発行日　　　　　yyyy年　MM月　dd日")
        TextBox32.Text = Format(P_HSTY_DATE, "yyyy/MM/dd")

        '依頼者情報
        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            TextBox50.Text = DtView1(0)("brch_name")
            TextBox51.Text = DtView1(0)("comp_name")
            TextBox51_2.Text = DtView1(0)("comp_name")
            TextBox52.Text = DtView1(0)("name")
            TextBox53.Text = DtView1(0)("adrs1")
            TextBox54.Text = DtView1(0)("adrs2")
            TextBox55.Text = DtView1(0)("tel")
            TextBox56.Text = DtView1(0)("fax")
        Else
            TextBox50.Text = Nothing
            TextBox51.Text = Nothing
            TextBox51_2.Text = Nothing
            TextBox52.Text = Nothing
            TextBox53.Text = Nothing
            TextBox54.Text = Nothing
            TextBox55.Text = Nothing
            TextBox56.Text = Nothing
        End If

        '部品
        TextBox61.Text = Nothing : TextBox71.Text = Nothing : TextBox81.Text = Nothing
        TextBox62.Text = Nothing : TextBox72.Text = Nothing : TextBox82.Text = Nothing
        TextBox63.Text = Nothing : TextBox73.Text = Nothing : TextBox83.Text = Nothing
        TextBox64.Text = Nothing : TextBox74.Text = Nothing : TextBox84.Text = Nothing
        TextBox65.Text = Nothing : TextBox75.Text = Nothing : TextBox85.Text = Nothing
        DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Dim pos As Integer
            pos = (P_page - 1) * 5
            For i = pos To DtView1.Count - 1
                Select Case i
                    Case Is = pos + 0
                        TextBox61.Text = DtView1(i)("part_code")
                        TextBox71.Text = DtView1(i)("part_name")
                        TextBox81.Text = DtView1(i)("use_qty")
                    Case Is = pos + 1
                        TextBox62.Text = DtView1(i)("part_code")
                        TextBox72.Text = DtView1(i)("part_name")
                        TextBox82.Text = DtView1(i)("use_qty")
                    Case Is = pos + 2
                        TextBox63.Text = DtView1(i)("part_code")
                        TextBox73.Text = DtView1(i)("part_name")
                        TextBox83.Text = DtView1(i)("use_qty")
                    Case Is = pos + 3
                        TextBox64.Text = DtView1(i)("part_code")
                        TextBox74.Text = DtView1(i)("part_name")
                        TextBox84.Text = DtView1(i)("use_qty")
                    Case Is = pos + 4
                        TextBox65.Text = DtView1(i)("part_code")
                        TextBox75.Text = DtView1(i)("part_name")
                        TextBox85.Text = DtView1(i)("use_qty")
                    Case Else
                        Exit For
                End Select
            Next
        End If
    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs) Handles PageFooter.Format

    End Sub
End Class
