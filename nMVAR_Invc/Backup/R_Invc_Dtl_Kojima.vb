Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Invc_Dtl_Kojima
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As DataDynamics.ActiveReports.ReportHeader = Nothing
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
    Private WithEvents ReportFooter As DataDynamics.ActiveReports.ReportFooter = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
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
	Private TextBox1D As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2D As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR_Invc.R_Invc_Dtl_Kojima.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.Label1 = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.PageHeader.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.PageHeader.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label19 = CType(Me.PageHeader.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.PageHeader.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.PageHeader.Controls(21),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.PageHeader.Controls(22),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.PageHeader.Controls(23),DataDynamics.ActiveReports.Label)
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
		Me.TextBox11 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1D = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2D = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.ReportFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
	End Sub

	#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        TextBox.Text = CInt(TextBox.Text) + 1

        TextBox3.Text = DateDiff(DateInterval.Day, CDate(TextBox1D.Text), CDate(TextBox2D.Text))

        TextBox11.Text = Format(CInt(TextBox9.Text) + CInt(TextBox10.Text), "#,##0")

        TextBox12.Text = Format(CInt(TextBox12.Text) + CInt(TextBox9.Text), "#,##0")
        TextBox13.Text = Format(CInt(TextBox13.Text) - 1000, "#,##0")
        TextBox14.Text = Format(CInt(TextBox14.Text) + CInt(TextBox11.Text), "#,##0")
    End Sub
End Class
