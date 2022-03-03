Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class SectionReport_R_NEVA_Kojima
    Inherits SectionReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        '出荷日
        TextBox01.Text = Format(Now(), "yy")
        TextBox02.Text = Format(Now(), "MM")
        TextBox03.Text = Format(Now(), "dd")

        '修理内容
        TextBox51.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox51.Text = DtView1(i)("cmnt")
                Else
                    TextBox51.Text = TextBox51.Text & System.Environment.NewLine & DtView1(i)("cmnt")
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

    End Sub

    Private Sub PageHeader_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Trim(Expr14.Text) <> Nothing Then
            If Trim(TextBox51.Text) <> Nothing Then
                TextBox51.Text = TextBox51.Text & System.Environment.NewLine & Expr14.Text
            Else
                TextBox51.Text = Expr14.Text
            End If
        End If

        If Trim(Expr09.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & Expr09.Text
            Else
                TextBox6.Text = Expr09.Text
            End If
        End If

        '部品
        TextBox21.Text = Nothing : TextBox31.Text = Nothing
        TextBox22.Text = Nothing : TextBox32.Text = Nothing
        TextBox23.Text = Nothing : TextBox33.Text = Nothing
        TextBox24.Text = Nothing : TextBox34.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox21.Text = DtView1(i)("part_name")
                        If Expr20.Text <> "01" Then TextBox31.Text = DtView1(i)("eu_chrg")
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_name")
                        If Expr20.Text <> "01" Then TextBox32.Text = DtView1(i)("eu_chrg")
                    Case Is = 2
                        TextBox23.Text = DtView1(i)("part_name")
                        If Expr20.Text <> "01" Then TextBox33.Text = DtView1(i)("eu_chrg")
                    Case Else
                        TextBox24.Text = DtView1(i)("part_name")
                        If Expr20.Text <> "01" Then TextBox34.Text = DtView1(i)("eu_chrg")
                        WK_amnt = WK_amnt + DtView1(i)("eu_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox24.Text = "その他部品"
                    If Expr20.Text <> "01" Then TextBox34.Text = WK_amnt
                End If
            Next
        End If
    End Sub
End Class
