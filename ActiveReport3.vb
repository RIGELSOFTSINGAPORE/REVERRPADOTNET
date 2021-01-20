Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ActiveReport3
    Inherits ActiveReport

    Dim Page As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()
        hed01.Text = Format(P_From_Date, "yyyyîNMåéèàóùï™")
        hed02.Text = Format(Now, "yyyyîNMMåéddì˙")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As DataDynamics.ActiveReports.ReportHeader = Nothing
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
    Private WithEvents ReportFooter As DataDynamics.ActiveReports.ReportFooter = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private hed01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private hed02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
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
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "Best_info_Report3.ActiveReport3.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.Label13 = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Label = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.hed01 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.hed02 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Line)
		Me.Label1 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Line)
		Me.TextBox = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.Line)
		Me.Label12 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.ReportFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.ReportFooter.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.ReportFooter.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.ReportFooter.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.ReportFooter.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.ReportFooter.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.ReportFooter.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.ReportFooter.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.ReportFooter.Controls(10),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format
        Page = Page + 1
        TextBox19.Text = Page & " / "
    End Sub

End Class
