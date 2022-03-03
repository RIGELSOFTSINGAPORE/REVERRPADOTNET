Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_HP_Parts_Order
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
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
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Line20 As DataDynamics.ActiveReports.Line = Nothing
	Private Line21 As DataDynamics.ActiveReports.Line = Nothing
	Private Line22 As DataDynamics.ActiveReports.Line = Nothing
	Private Line23 As DataDynamics.ActiveReports.Line = Nothing
	Private Line24 As DataDynamics.ActiveReports.Line = Nothing
	Private Line25 As DataDynamics.ActiveReports.Line = Nothing
	Private Line26 As DataDynamics.ActiveReports.Line = Nothing
	Private Line27 As DataDynamics.ActiveReports.Line = Nothing
	Private Line28 As DataDynamics.ActiveReports.Line = Nothing
	Private Line29 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_HP_Parts_Order.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label51 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.TextBox2 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.Label11 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.TextBox8 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.Label16 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.TextBox14 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.Label17 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.Label18 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Line)
		Me.Line23 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Line)
		Me.Line24 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Line)
		Me.Line25 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Line)
		Me.Line26 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Line)
		Me.Line27 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Line)
		Me.Line28 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Line)
		Me.Line29 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Line)
	End Sub

	#End Region
End Class
