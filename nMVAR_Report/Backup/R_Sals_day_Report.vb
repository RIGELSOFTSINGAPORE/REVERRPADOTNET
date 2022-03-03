Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sals_day_Report
Inherits ActiveReport

    Dim Page As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()
        TextBox17.Text = P_PRAM1
        TextBox18.Text = Now
        TextBox21.Text = Format(Now, "yyyy”NMMŒŽdd“ú")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As DataDynamics.ActiveReports.ReportHeader = Nothing
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
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
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
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
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox37 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR_Report.R_Sals_day_Report.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
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
		Me.Label10 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.TextBox17 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Line)
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
		Me.TextBox12 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Line1 = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.Line)
		Me.TextBox21 = CType(Me.PageFooter.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.ReportFooter.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.ReportFooter.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.ReportFooter.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.ReportFooter.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.ReportFooter.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox29 = CType(Me.ReportFooter.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox30 = CType(Me.ReportFooter.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.ReportFooter.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox32 = CType(Me.ReportFooter.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.ReportFooter.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.ReportFooter.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.ReportFooter.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.ReportFooter.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox37 = CType(Me.ReportFooter.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.ReportFooter.Controls(16),DataDynamics.ActiveReports.Line)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        TextBox30.Text = CInt(TextBox30.Text) + CInt(TextBox9.Text)
        TextBox22.Text = CInt(TextBox22.Text) + CInt(TextBox1.Text)
        TextBox31.Text = CInt(TextBox31.Text) + CInt(TextBox10.Text)
        TextBox23.Text = CInt(TextBox23.Text) + CInt(TextBox2.Text)
        TextBox32.Text = CInt(TextBox32.Text) + CInt(TextBox11.Text)
        TextBox24.Text = CInt(TextBox24.Text) + CInt(TextBox3.Text)
        TextBox33.Text = CInt(TextBox33.Text) + CInt(TextBox12.Text)
        TextBox25.Text = CInt(TextBox25.Text) + CInt(TextBox4.Text)
        TextBox34.Text = CInt(TextBox34.Text) + CInt(TextBox13.Text)
        TextBox26.Text = CInt(TextBox26.Text) + CInt(TextBox5.Text)
        TextBox35.Text = CInt(TextBox35.Text) + CInt(TextBox14.Text)
        TextBox27.Text = CInt(TextBox27.Text) + CInt(TextBox6.Text)
        TextBox36.Text = CInt(TextBox36.Text) + CInt(TextBox15.Text)
        TextBox28.Text = CInt(TextBox28.Text) + CInt(TextBox7.Text)
        TextBox37.Text = CInt(TextBox37.Text) + CInt(TextBox16.Text)
        TextBox29.Text = CInt(TextBox29.Text) + CInt(TextBox8.Text)

    End Sub

    Private Sub ReportFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.Format

        TextBox22.Text = "\" & Format(CInt(TextBox22.Text), "##,##0")
        TextBox23.Text = "\" & Format(CInt(TextBox23.Text), "##,##0")
        TextBox24.Text = "\" & Format(CInt(TextBox24.Text), "##,##0")
        TextBox25.Text = "\" & Format(CInt(TextBox25.Text), "##,##0")
        TextBox26.Text = "\" & Format(CInt(TextBox26.Text), "##,##0")
        TextBox27.Text = "\" & Format(CInt(TextBox27.Text), "##,##0")
        TextBox28.Text = "\" & Format(CInt(TextBox28.Text), "##,##0")
        TextBox29.Text = "\" & Format(CInt(TextBox29.Text), "##,##0")

    End Sub

    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format
        Page = Page + 1
        TextBox19.Text = Page & " / "
    End Sub
End Class
