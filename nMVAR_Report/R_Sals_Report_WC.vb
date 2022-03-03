Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sals_Report_WC
Inherits ActiveReport

    Dim date1, date2, date3 As Date
    Dim int1, int2 As Integer
    Dim WK_sum1, WK_sum2, WK_sum3, WK_sum4, WK_sum5, WK_sum6, WK_sum7, WK_sum8, WK_sum9, WK_sum10 As Decimal
    Dim WK_sumG1, WK_sumG2, WK_sumG3, WK_sumG4, WK_sumG5, WK_sumG6, WK_sumG7, WK_sumG8, WK_sumG9, WK_sumG10 As Decimal

    Public Sub New()
        MyBase.New()
        InitializeReport()

        date1 = CDate(P_PRAM1 & "/01")                                                  'äJén
        TextBox05.Text = Format(date1, "yyyyîNMMåéìx")

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
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox05 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox50 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox37 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox38 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox39 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox60 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox61 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR_Report.R_Sals_Report_WC.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.GroupHeader1 = CType(Me.Sections("GroupHeader1"),DataDynamics.ActiveReports.GroupHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.GroupFooter1 = CType(Me.Sections("GroupFooter1"),DataDynamics.ActiveReports.GroupFooter)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.Label = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.TextBox05 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.Label12 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.PageHeader.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.PageHeader.Controls(18),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox40 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.GroupFooter1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.GroupFooter1.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.GroupFooter1.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.GroupFooter1.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.GroupFooter1.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.GroupFooter1.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.GroupFooter1.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.GroupFooter1.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox29 = CType(Me.GroupFooter1.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox50 = CType(Me.GroupFooter1.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.GroupFooter1.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox32 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.ReportFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.ReportFooter.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.ReportFooter.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.ReportFooter.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox37 = CType(Me.ReportFooter.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox38 = CType(Me.ReportFooter.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox39 = CType(Me.ReportFooter.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox60 = CType(Me.ReportFooter.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox61 = CType(Me.ReportFooter.Controls(10),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        WK_sum1 = WK_sum1 + TextBox12.Text
        WK_sum2 = WK_sum2 + TextBox13.Text
        WK_sum3 = WK_sum3 + TextBox14.Text
        WK_sum4 = WK_sum4 + TextBox15.Text
        WK_sum5 = WK_sum5 + TextBox16.Text
        WK_sum6 = WK_sum6 + TextBox17.Text
        WK_sum7 = WK_sum7 + TextBox18.Text
        WK_sum8 = WK_sum8 + TextBox19.Text
        WK_sum9 = WK_sum9 + TextBox40.Text
        WK_sum10 = WK_sum10 + TextBox41.Text
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        TextBox22.Text = Format(WK_sum1, "##,##0")
        TextBox23.Text = Format(WK_sum2, "##,##0")
        TextBox24.Text = Format(WK_sum3, "##,##0")
        TextBox25.Text = Format(WK_sum4, "##,##0")
        TextBox26.Text = Format(WK_sum5, "##,##0")
        TextBox27.Text = Format(WK_sum6, "##,##0")
        TextBox28.Text = Format(WK_sum7, "##,##0")
        TextBox29.Text = Format(WK_sum8, "##,##0")
        TextBox50.Text = Format(WK_sum9, "##,##0")
        TextBox51.Text = Format(WK_sum10, "##,##0")

        WK_sumG1 = WK_sumG1 + WK_sum1
        WK_sumG2 = WK_sumG2 + WK_sum2
        WK_sumG3 = WK_sumG3 + WK_sum3
        WK_sumG4 = WK_sumG4 + WK_sum4
        WK_sumG5 = WK_sumG5 + WK_sum5
        WK_sumG6 = WK_sumG6 + WK_sum6
        WK_sumG7 = WK_sumG7 + WK_sum7
        WK_sumG8 = WK_sumG8 + WK_sum8
        WK_sumG9 = WK_sumG9 + WK_sum9
        WK_sumG10 = WK_sumG10 + WK_sum10

        WK_sum1 = 0 : WK_sum2 = 0 : WK_sum3 = 0 : WK_sum4 = 0 : WK_sum5 = 0 : WK_sum6 = 0 : WK_sum7 = 0 : WK_sum8 = 0 : WK_sum9 = 0 : WK_sum10 = 0
    End Sub

    Private Sub ReportFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.Format
        TextBox31.Text = "ÇeÇpÇfëçåv"
        TextBox32.Text = Format(WK_sumG1, "##,##0")
        TextBox33.Text = Format(WK_sumG2, "##,##0")
        TextBox34.Text = Format(WK_sumG3, "##,##0")
        TextBox35.Text = Format(WK_sumG4, "##,##0")
        TextBox36.Text = Format(WK_sumG5, "##,##0")
        TextBox37.Text = Format(WK_sumG6, "##,##0")
        TextBox38.Text = Format(WK_sumG7, "##,##0")
        TextBox39.Text = Format(WK_sumG8, "##,##0")
        TextBox60.Text = Format(WK_sumG9, "##,##0")
        TextBox61.Text = Format(WK_sumG10, "##,##0")
    End Sub
End Class
