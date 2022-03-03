Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Inquiry_Siriaru_Inq
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()

        TextBox1.Text = Format(Now.Date, "yyyy年MM月dd日")

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private RichTextBox As DataDynamics.ActiveReports.RichTextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Shape As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape1 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape2 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape3 As DataDynamics.ActiveReports.Shape = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Shape4 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape5 As DataDynamics.ActiveReports.Shape = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Label35 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Label37 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Private Label40 As DataDynamics.ActiveReports.Label = Nothing
	Private Label41 As DataDynamics.ActiveReports.Label = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Label39 As DataDynamics.ActiveReports.Label = Nothing
	Private Label42 As DataDynamics.ActiveReports.Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Inquiry_Siriaru_Inq.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.RichTextBox = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.RichTextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox9 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.TextBox21 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label49 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label50 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.TextBox13 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.Label51 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Line)
		Me.Label9 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.Label11 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.TextBox8 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.Label14 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.Label16 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.TextBox16 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.TextBox)
		Me.Label17 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.Shape = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Shape)
		Me.Shape1 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Shape)
		Me.Shape2 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Shape)
		Me.Shape3 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Shape)
		Me.Label22 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Label)
		Me.Line5 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Line)
		Me.Label3 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.Line2 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Line)
		Me.Shape4 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Shape)
		Me.Shape5 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Shape)
		Me.Label2 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Label)
		Me.Label30 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Label)
		Me.Label31 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Label)
		Me.Label32 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Label)
		Me.Label34 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Label35 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Label)
		Me.Label37 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Label)
		Me.Label40 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Label)
		Me.Label41 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Label)
		Me.Line4 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Line)
		Me.Label39 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Label)
		Me.Label42 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Label)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        Label26.Text = " 　御預かりいたしました修理機S/N：" & Label38.Text & " と同梱物S/N：" & Label40.Text

    End Sub
End Class
