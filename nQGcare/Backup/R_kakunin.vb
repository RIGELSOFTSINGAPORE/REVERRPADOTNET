Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_kakunin
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
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
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Picture As DataDynamics.ActiveReports.Picture = Nothing
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
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox53 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox54 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox74 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox56 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox76 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nQGCare.R_kakunin.rpx")
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.Label = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Line)
		Me.Picture = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Picture)
		Me.Line3 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Line)
		Me.Label12 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Line17 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Line)
		Me.TextBox1 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.TextBox32 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.TextBox)
		Me.TextBox52 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.TextBox)
		Me.TextBox43 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.TextBox)
		Me.TextBox53 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.Line18 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Line)
		Me.Label13 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.TextBox24 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.TextBox)
		Me.TextBox44 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.TextBox)
		Me.TextBox54 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.TextBox74 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.TextBox)
		Me.TextBox55 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.TextBox)
		Me.TextBox46 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.TextBox)
		Me.TextBox56 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.TextBox76 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.TextBox)
	End Sub

	#End Region
End Class
