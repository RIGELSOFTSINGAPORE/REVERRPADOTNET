Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sals_Empl_Report
    Inherits ActiveReport

    Dim WK_sum1, WK_sum2, WK_sum3, Page, No As Integer
    Dim WK_sumG2, WK_sumG3 As Integer

	Public Sub New()
	MyBase.New()
        InitializeReport()
        TextBox17.Text = P_PRAM1
        TextBox16.Text = Format(Now, "yyyy”NMMŒŽdd“ú")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As DataDynamics.ActiveReports.ReportHeader = Nothing
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
    Private WithEvents ReportFooter As DataDynamics.ActiveReports.ReportFooter = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox106 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox111 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox112 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox211 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox212 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR_Report.R_Sals_Empl_Report.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.GroupHeader1 = CType(Me.Sections("GroupHeader1"),DataDynamics.ActiveReports.GroupHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.GroupFooter1 = CType(Me.Sections("GroupFooter1"),DataDynamics.ActiveReports.GroupFooter)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.Label = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.TextBox17 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.Label10 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Line)
		Me.TextBox = CType(Me.GroupHeader1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Line)
		Me.TextBox106 = CType(Me.GroupFooter1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox111 = CType(Me.GroupFooter1.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox112 = CType(Me.GroupFooter1.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Line1 = CType(Me.PageFooter.Controls(3),DataDynamics.ActiveReports.Line)
		Me.TextBox211 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox212 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        WK_sum1 = WK_sum1 + TextBox6.Text
        WK_sum2 = WK_sum2 + TextBox11.Text
        WK_sum3 = WK_sum3 + TextBox12.Text

        No = No + 1
        TextBox15.Text = No
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        TextBox106.Text = Format(Round(WK_sum1 / No, 1), "##0.0")
        TextBox111.Text = Format(WK_sum2, "###,###,##0")
        TextBox112.Text = Format(WK_sum3, "###,###,##0")

        WK_sumG2 = WK_sumG2 + WK_sum2
        WK_sumG3 = WK_sumG3 + WK_sum3

        WK_sum1 = 0
        WK_sum2 = 0
        WK_sum3 = 0
        No = 0
    End Sub

    Private Sub ReportFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.Format
        TextBox211.Text = Format(WK_sumG2, "###,###,##0")
        TextBox212.Text = Format(WK_sumG3, "###,###,##0")
    End Sub

    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format
        Page = Page + 1
        TextBox19.Text = Page & " / "
    End Sub
End Class
