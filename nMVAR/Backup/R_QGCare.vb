Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_QGCare
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
        InitializeReport()
        TextBox.Text = Format(Now, "yyyy/MM/dd")
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
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
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
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
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_QGCare.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox14 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label14 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Line)
		Me.Label13 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
	End Sub

	#End Region
End Class
