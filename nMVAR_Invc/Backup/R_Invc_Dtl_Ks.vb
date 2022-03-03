Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Invc_Dtl_Ks
Inherits ActiveReport

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String
    Dim r As Integer
    Dim WK_C1, WK_C2 As String

    Public Sub New()
        MyBase.New()
        InitializeReport()
        TextBox1.Text = Format(Now, "yyyy年M月d日")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox03 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox04 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox05 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox06 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox07 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox08 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox09 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR_Invc.R_Invc_Dtl_Ks.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.TextBox13 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Label8 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.PageHeader.Controls(18),DataDynamics.ActiveReports.Line)
		Me.TextBox15 = CType(Me.PageHeader.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.TextBox01 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox02 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox03 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox04 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox05 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox06 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox07 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox08 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox09 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Line1 = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.Line)
	End Sub

#End Region

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        TextBox.Text = TextBox18.Text & " 御中"

        If TextBox15.Text = "0" Then    '締め不定期
            strSQL = "SELECT invc_date"
            strSQL = strSQL & " FROM T20_INVC_MTR"
            strSQL = strSQL & " WHERE (invc_code = '" & TextBox11.Text & "')"
            strSQL = strSQL & " AND (invc_date <> CONVERT(DATETIME, '" & TextBox13.Text & "', 102))"
            strSQL = strSQL & " AND (rcpt_brch_code = '" & TextBox14.Text & "')"
            strSQL = strSQL & " ORDER BY invc_date DESC"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(DsList1, "fr_date")
            DB_CLOSE()
            If r = 0 Then
                WK_C1 = Format(DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Month, -1, CDate(TextBox13.Text))), "yyyy年M月d日")    '1ヶ月前
            Else
                DtView1 = New DataView(DsList1.Tables("fr_date"), "", "", DataViewRowState.CurrentRows)
                WK_C1 = Format(DateAdd(DateInterval.Day, 1, CDate(DtView1(0)("invc_date"))), "yyyy年M月d日")
            End If
        Else
            WK_C1 = Format(DateAdd(DateInterval.Month, -1, DateAdd(DateInterval.Day, 1, CDate(TextBox13.Text))), "yyyy年M月d日")
        End If
        WK_C2 = Format(CDate(TextBox13.Text), "yyyy年M月d日")
        TextBox2.Text = "集計期間　　" & WK_C1 & "〜" & WK_C2
    End Sub

End Class
