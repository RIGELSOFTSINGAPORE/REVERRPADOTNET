Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ActiveReport2
Inherits ActiveReport

    Dim Page As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()
        hed02.Text = Format(Now, "yyyy”NMMŒŽdd“ú")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As DataDynamics.ActiveReports.ReportHeader = Nothing
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
    Private WithEvents ReportFooter As DataDynamics.ActiveReports.ReportFooter = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private hed02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "Best_info_Report6.ActiveReport2.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.Label = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Line)
		Me.Label6 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Line)
		Me.hed02 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.Line)
		Me.TextBox19 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Label12 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox12 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.ReportFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Line3 = CType(Me.ReportFooter.Controls(3),DataDynamics.ActiveReports.Line)
	End Sub

#End Region

    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format
        Page = Page + 1
        TextBox19.Text = Page & " / "
    End Sub

End Class
