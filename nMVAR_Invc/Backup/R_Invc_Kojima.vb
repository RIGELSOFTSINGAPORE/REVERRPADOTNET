Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Invc_Kojima
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()
        TextBox1.Text = Format(P_HSTY_DATE, "yyyy年MM月dd日")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox01 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox02 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox03 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox04 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox05 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox06 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox07 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox08 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox09 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
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
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Label35 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line26 As DataDynamics.ActiveReports.Line = Nothing
	Private Line25 As DataDynamics.ActiveReports.Line = Nothing
	Private Line24 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line27 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line28 As DataDynamics.ActiveReports.Line = Nothing
	Private Line29 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Line30 As DataDynamics.ActiveReports.Line = Nothing
	Private Line31 As DataDynamics.ActiveReports.Line = Nothing
	Private Line32 As DataDynamics.ActiveReports.Line = Nothing
	Private Line33 As DataDynamics.ActiveReports.Line = Nothing
	Private Line34 As DataDynamics.ActiveReports.Line = Nothing
	Private Line35 As DataDynamics.ActiveReports.Line = Nothing
	Private Line36 As DataDynamics.ActiveReports.Line = Nothing
	Private Line20 As DataDynamics.ActiveReports.Line = Nothing
	Private Line21 As DataDynamics.ActiveReports.Line = Nothing
	Private Line22 As DataDynamics.ActiveReports.Line = Nothing
	Private Line23 As DataDynamics.ActiveReports.Line = Nothing
	Private Line37 As DataDynamics.ActiveReports.Line = Nothing
	Private Line38 As DataDynamics.ActiveReports.Line = Nothing
	Private Line39 As DataDynamics.ActiveReports.Line = Nothing
	Private Line40 As DataDynamics.ActiveReports.Line = Nothing
	Private Line41 As DataDynamics.ActiveReports.Line = Nothing
	Private Line42 As DataDynamics.ActiveReports.Line = Nothing
	Private Line43 As DataDynamics.ActiveReports.Line = Nothing
	Private Line44 As DataDynamics.ActiveReports.Line = Nothing
	Private Line45 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR_Invc.R_Invc_Kojima.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox14 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.Label3 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.TextBox01 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.TextBox02 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.TextBox03 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.TextBox04 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.TextBox05 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.TextBox06 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.TextBox07 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.TextBox08 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.TextBox09 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.Line10 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Line)
		Me.Label6 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Line14 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Line)
		Me.Line = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Line)
		Me.Label = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Label19 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Label)
		Me.Label30 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.Label31 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Label)
		Me.Label32 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Label)
		Me.Label34 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.Label35 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Line3 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Line)
		Me.Line26 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Line)
		Me.Line25 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Line)
		Me.Line24 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.Line)
		Me.Line27 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.Line)
		Me.Line28 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.Line)
		Me.Line29 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.Line)
		Me.Line30 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Line)
		Me.Line31 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.Line)
		Me.Line32 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.Line)
		Me.Line33 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.Line)
		Me.Line34 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.Line)
		Me.Line35 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.Line)
		Me.Line36 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.Line)
		Me.Line23 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.Line)
		Me.Line37 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.Line)
		Me.Line38 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.Line)
		Me.Line39 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.Line)
		Me.Line40 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.Line)
		Me.Line41 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.Line)
		Me.Line42 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.Line)
		Me.Line43 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.Line)
		Me.Line44 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.Line)
		Me.Line45 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Line)
		Me.TextBox9 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        TextBox2.Text = Format(CDate(TextBox9.Text), "yyyy年MM月分請求書")
    End Sub
End Class
