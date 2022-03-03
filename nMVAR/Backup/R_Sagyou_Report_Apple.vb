Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sagyou_Report_Apple
    Inherits ActiveReport
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet

    Dim DtView1, WK_DtView1 As DataView
    Dim strSQL As String
    Dim i, r, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox1.Text = "発行日 " & Format(Now.Date, "yyyy 年 MM 月 dd 日")

        '修理内容
        TextBox18.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox18.Text = DtView1(i)("cmnt")
                Else
                    TextBox18.Text += vbCrLf & DtView1(i)("cmnt")
                End If
            Next
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
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
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
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
	Private TextBox38 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox39 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox49 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox50 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox53 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox54 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox56 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox57 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox58 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox59 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox60 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox61 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox63 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox64 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox65 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox66 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox67 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox68 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox62 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox69 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
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
	Private Line30 As DataDynamics.ActiveReports.Line = Nothing
	Private Line31 As DataDynamics.ActiveReports.Line = Nothing
	Private Line32 As DataDynamics.ActiveReports.Line = Nothing
	Private Line33 As DataDynamics.ActiveReports.Line = Nothing
	Private Line34 As DataDynamics.ActiveReports.Line = Nothing
	Private Line35 As DataDynamics.ActiveReports.Line = Nothing
	Private Line36 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox70 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox71 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox72 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox73 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox74 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox75 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox76 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox77 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox78 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox79 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox80 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox81 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Sagyou_Report_Apple.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.TextBox2 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label19 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Line8 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Line)
		Me.TextBox13 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.TextBox)
		Me.TextBox29 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.TextBox)
		Me.TextBox30 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.TextBox32 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.TextBox)
		Me.TextBox37 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.TextBox)
		Me.TextBox38 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.TextBox)
		Me.TextBox39 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.TextBox)
		Me.TextBox40 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.TextBox43 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.TextBox)
		Me.TextBox44 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.TextBox46 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.TextBox)
		Me.TextBox48 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.TextBox)
		Me.TextBox49 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.TextBox)
		Me.TextBox50 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.TextBox)
		Me.TextBox52 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.TextBox)
		Me.TextBox53 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.TextBox)
		Me.TextBox54 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.TextBox)
		Me.TextBox55 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.TextBox)
		Me.Label26 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Label)
		Me.TextBox56 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.TextBox)
		Me.TextBox57 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.TextBox)
		Me.TextBox58 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.TextBox)
		Me.TextBox59 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.TextBox)
		Me.TextBox60 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.TextBox)
		Me.TextBox61 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.TextBox)
		Me.TextBox63 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.TextBox)
		Me.TextBox64 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.TextBox)
		Me.TextBox65 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.TextBox)
		Me.TextBox66 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.TextBox)
		Me.TextBox67 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.TextBox)
		Me.TextBox68 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.TextBox)
		Me.TextBox62 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.TextBox)
		Me.TextBox69 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(118),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(119),DataDynamics.ActiveReports.Line)
		Me.Line23 = CType(Me.Detail.Controls(120),DataDynamics.ActiveReports.Line)
		Me.Line24 = CType(Me.Detail.Controls(121),DataDynamics.ActiveReports.Line)
		Me.Line25 = CType(Me.Detail.Controls(122),DataDynamics.ActiveReports.Line)
		Me.Line26 = CType(Me.Detail.Controls(123),DataDynamics.ActiveReports.Line)
		Me.Line27 = CType(Me.Detail.Controls(124),DataDynamics.ActiveReports.Line)
		Me.Line28 = CType(Me.Detail.Controls(125),DataDynamics.ActiveReports.Line)
		Me.Line29 = CType(Me.Detail.Controls(126),DataDynamics.ActiveReports.Line)
		Me.Line30 = CType(Me.Detail.Controls(127),DataDynamics.ActiveReports.Line)
		Me.Line31 = CType(Me.Detail.Controls(128),DataDynamics.ActiveReports.Line)
		Me.Line32 = CType(Me.Detail.Controls(129),DataDynamics.ActiveReports.Line)
		Me.Line33 = CType(Me.Detail.Controls(130),DataDynamics.ActiveReports.Line)
		Me.Line34 = CType(Me.Detail.Controls(131),DataDynamics.ActiveReports.Line)
		Me.Line35 = CType(Me.Detail.Controls(132),DataDynamics.ActiveReports.Line)
		Me.Line36 = CType(Me.Detail.Controls(133),DataDynamics.ActiveReports.Line)
		Me.TextBox = CType(Me.Detail.Controls(134),DataDynamics.ActiveReports.TextBox)
		Me.TextBox70 = CType(Me.Detail.Controls(135),DataDynamics.ActiveReports.TextBox)
		Me.TextBox71 = CType(Me.Detail.Controls(136),DataDynamics.ActiveReports.TextBox)
		Me.TextBox72 = CType(Me.Detail.Controls(137),DataDynamics.ActiveReports.TextBox)
		Me.TextBox73 = CType(Me.Detail.Controls(138),DataDynamics.ActiveReports.TextBox)
		Me.TextBox74 = CType(Me.Detail.Controls(139),DataDynamics.ActiveReports.TextBox)
		Me.TextBox75 = CType(Me.Detail.Controls(140),DataDynamics.ActiveReports.TextBox)
		Me.TextBox76 = CType(Me.Detail.Controls(141),DataDynamics.ActiveReports.TextBox)
		Me.TextBox77 = CType(Me.Detail.Controls(142),DataDynamics.ActiveReports.TextBox)
		Me.TextBox78 = CType(Me.Detail.Controls(143),DataDynamics.ActiveReports.TextBox)
		Me.TextBox79 = CType(Me.Detail.Controls(144),DataDynamics.ActiveReports.TextBox)
		Me.TextBox80 = CType(Me.Detail.Controls(145),DataDynamics.ActiveReports.TextBox)
		Me.TextBox81 = CType(Me.Detail.Controls(146),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(147),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        If TextBox2.Text = Nothing Then '御社伝票番号なしの時非表示
            Label1.Visible = False
        End If

        If TextBox57.Text = Nothing Then
            TextBox6.Text = TextBox56.Text
        Else
            TextBox6.Text = TextBox56.Text & "(" & TextBox57.Text & ")"
        End If

        TextBox8.Text = StrConv(Trim(TextBox58.Text.Replace(vbCrLf, "")), VbStrConv.Narrow) & " " & StrConv(Trim(TextBox59.Text), VbStrConv.Narrow)
        TextBox9.Text = "TEL " & TextBox60.Text & "　FAX " & TextBox61.Text

        Dim wk_tel As String = Nothing
        DsList1.Clear()
        strSQL = "SELECT print_tel, print_fax FROM M08_STORE WHERE (store_code = '" & TextBox78.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M08_STORE")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            If Not IsDBNull(DtView1(0)("print_tel")) Then
                If Trim(DtView1(0)("print_tel")) <> "" Then
                    wk_tel += "TEL " & Trim(DtView1(0)("print_tel"))
                End If
            End If
            If Not IsDBNull(DtView1(0)("print_fax")) Then
                If Trim(DtView1(0)("print_fax")) <> "" Then
                    wk_tel += "　FAX " & Trim(DtView1(0)("print_fax"))
                End If
            End If
        End If
        If wk_tel <> Nothing Then
            TextBox9.Text = wk_tel
        End If

        If TextBox78.Text = "0020" Then '一般
            TextBox12.Text = TextBox63.Text & "　様"
        Else
            TextBox12.Text = Trim(TextBox77.Text) & " / " & Trim(TextBox63.Text) & "　様"
            TextBox12.Text = TextBox12.Text.Replace(vbCrLf, "")
        End If

        If Trim(TextBox64.Text) <> Nothing Then
            If Trim(TextBox18.Text) <> Nothing Then
                TextBox18.Text += vbCrLf & TextBox64.Text
            Else
                TextBox18.Text = TextBox64.Text
            End If
        End If

        TextBox16.Text = Nothing
        If Trim(TextBox74.Text) <> "refused@apple.com" Then
            TextBox16.Text = Trim(TextBox74.Text)
        End If

        TextBox19.Text = "修理区分：" & TextBox65.Text & "　　修理番号：" & TextBox66.Text
        If TextBox80.Text = "True" Then
            TextBox79.Text = "配送修理"
        Else
            TextBox79.Text = "店内修理"
        End If

        '部品
        TextBox21.Text = Nothing : TextBox26.Text = Nothing : TextBox31.Text = Nothing : TextBox36.Text = Nothing : TextBox41.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox32.Text = Nothing : TextBox37.Text = Nothing : TextBox42.Text = Nothing
        TextBox23.Text = Nothing : TextBox28.Text = Nothing : TextBox33.Text = Nothing : TextBox38.Text = Nothing : TextBox43.Text = Nothing
        TextBox24.Text = Nothing : TextBox29.Text = Nothing : TextBox34.Text = Nothing : TextBox39.Text = Nothing : TextBox44.Text = Nothing
        TextBox25.Text = Nothing : TextBox30.Text = Nothing : TextBox35.Text = Nothing : TextBox40.Text = Nothing : TextBox45.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        WK_cnt = 0 : WK_amnt = 0
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("exp_flg")) Then DtView1(i)("exp_flg") = "False"
                Select Case i
                    Case Is = 0
                        TextBox21.Text = DtView1(i)("part_code")
                        TextBox26.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox31.Text = DtView1(i)("s_n")
                        TextBox36.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox41.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox41.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_code")
                        TextBox27.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox32.Text = DtView1(i)("s_n")
                        TextBox37.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox42.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox42.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 2
                        TextBox23.Text = DtView1(i)("part_code")
                        TextBox28.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox33.Text = DtView1(i)("s_n")
                        TextBox38.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox43.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox43.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Is = 3
                        TextBox24.Text = DtView1(i)("part_code")
                        TextBox29.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox34.Text = DtView1(i)("s_n")
                        TextBox39.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox44.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox44.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                    Case Else
                        TextBox25.Text = DtView1(i)("part_code")
                        TextBox30.Text = DtView1(i)("part_name")
                        If Not IsDBNull(DtView1(i)("s_n")) Then TextBox35.Text = DtView1(i)("s_n")
                        TextBox40.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        If TextBox72.Text = "01" Then
                            TextBox45.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        Else
                            TextBox45.Text = "\" & Format(part_amt_get(TextBox75.Text, DtView1(i)("part_code"), DtView1(i)("rcpt_no"), DtView1(i)("use_qty"), DtView1(i)("ibm_flg")), "##,##0")
                        End If
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + CInt(TextBox45.Text)
                End Select

                If DtView1.Count > 5 Then
                    TextBox25.Text = "その他部品"
                    TextBox30.Text = Nothing
                    TextBox35.Text = Nothing
                    TextBox40.Text = WK_cnt
                    TextBox45.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If

        'If TextBox72.Text = "01" Then
        '    TextBox46.Text = "\" & Format(CInt(TextBox76.Text), "##,##0")
        'Else
        TextBox46.Text = "\" & Format(CInt(TextBox41.Text) + CInt(TextBox42.Text) + CInt(TextBox43.Text) + CInt(TextBox44.Text) + WK_amnt, "##,##0")
        'End If

        TextBox47.Text = "\" & Format(CInt(TextBox10.Text) + CInt(TextBox62.Text) + CInt(TextBox69.Text), "##,##0")
        TextBox48.Text = "\" & Format(CInt(TextBox46.Text) + CInt(TextBox47.Text), "##,##0")

        If TextBox72.Text = "01" Then
            'TextBox49.Text = "なし"
            TextBox50.Text = "\0"
            TextBox51.Text = "\" & Format(CInt(TextBox73.Text), "##,##0")
        Else
            'TextBox49.Text = "あり"
            TextBox50.Text = "\" & Format(CInt(TextBox48.Text) * -1, "##,##0")
            TextBox51.Text = "\0"
        End If

        TextBox49.Text = "\" & Format(CInt(TextBox81.Text), "##,##0")

        TextBox52.Text = "\" & Format(CInt(TextBox48.Text) + CInt(TextBox50.Text) + CInt(TextBox51.Text) + CInt(TextBox49.Text), "##,##0")

        TextBox20.Text = Nothing
        If IsDate(TextBox.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " ご申告の症状を検証いたしました。"
        End If
        If IsDate(TextBox70.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox70.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " 製品の修理を実施いたしました。"
        End If
        If IsDate(TextBox71.Text) = True Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += Format(CDate(TextBox71.Text), "yyyy/MM/dd HH:mm")
            TextBox20.Text += " お預かりした製品の修理に関して、ご連絡いたしました。"
        End If
        If TextBox67.Text <> Nothing Then
            If TextBox20.Text <> Nothing Then TextBox20.Text += vbCrLf
            TextBox20.Text += TextBox67.Text
        End If

        TextBox53.Text = "修理後保証は交換部品に対して適用されます。修理後保証期間は修理完了から" & StrConv(TextBox68.Text, VbStrConv.Wide) & "日です。"
        TextBox53.Text += vbCrLf & "※修理保証は機器障害にのみ適用され、筐体の損傷やお客様過失による故障などには適用されません。"
        TextBox53.Text += vbCrLf & "尚、修理/交換した部品または製品は、新品、または性能と信頼性の両面に於いて新品同様です。"

        If TextBox78.Text = "0020" Then '一般
            TextBox54.Text = "万一、故障が発生しました際には、当報告書をご持参の上、再修理をお申し込みください。"
            TextBox54.Text += vbCrLf & "修理完了日より2週間以内のお客様は、優先受付対応させて頂きますのでお申し付け下さい。"
            TextBox54.Text += vbCrLf & "製品の破損や傷、液体損傷などは修理後保証・優先受付の対象外です。"
        Else
            TextBox54.Text = "万一、故障が発生しました際には、当報告書をご持参の上、再修理をお申し込みください。"
            TextBox54.Text += vbCrLf & "製品の破損や傷、液体損傷などは修理後保証の対象外となります。"
        End If

        TextBox55.Text = "個人情報の収集、利用、提供及び登録に関して、以下のように取り扱います。"
        TextBox55.Text += vbCrLf & "①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用されません。"
        TextBox55.Text += vbCrLf & "②お客様情報の詳細（名前や電話番号）は、Apple社によって提供または使用される場合がございます。"
        TextBox55.Text += vbCrLf & "③上記の場合を除き、修理業務で知りえたお客様の個人情報は、第三者に漏えい、開示いたしません。"

    End Sub

    Function part_amt_get(ByVal vndr_code As String, ByVal part_code As String, ByVal rcpt_no As String, ByVal qty As Integer, ByVal ibm_flg As String) As Integer
        Dim cost As Integer = 0
        Dim EU_rate As Decimal = 0
        Dim GSS_rate As Decimal = 0
        Dim GSS_amnt As Integer = 0
        Dim store_code As String = Nothing
        Dim grup_code As String = Nothing
        Dim GSS_kijo As Integer = 0
        Dim part_amnt As Integer = 0
        Dim own_flg As String = "0"
        Dim note_kbn As String = Nothing
        DsList1.Clear()

        'コスト
        strSQL = "SELECT stc_amnt, exc_amnt"
        strSQL += " FROM M40_PART"
        strSQL += " WHERE (vndr_code = '" & vndr_code & "')"
        strSQL += " AND (part_code = '" & part_code & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "M40_PART")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("M40_PART"), "", "", DataViewRowState.CurrentRows)
            If IsDBNull(WK_DtView1(0)("exc_amnt")) Then WK_DtView1(0)("exc_amnt") = 0
            If IsDBNull(WK_DtView1(0)("stc_amnt")) Then WK_DtView1(0)("stc_amnt") = 0
            If CInt(WK_DtView1(0)("exc_amnt")) <> 0 Then
                cost = WK_DtView1(0)("exc_amnt")
            Else
                If CInt(WK_DtView1(0)("stc_amnt")) <> 0 Then
                    cost = WK_DtView1(0)("stc_amnt")
                End If
            End If
        End If

        'EU掛率
        strSQL = "SELECT T01_REP_MTR.rcpt_no, T01_REP_MTR.part_rate2, T01_REP_MTR.store_code, M08_STORE.grup_code, M06_RPAR_COMP.own_flg, T01_REP_MTR.note_kbn"
        strSQL += " FROM T01_REP_MTR INNER JOIN"
        strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
        strSQL += " M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView1(0)("part_rate2")) Then EU_rate = WK_DtView1(0)("part_rate2")
            If Not IsDBNull(WK_DtView1(0)("store_code")) Then store_code = WK_DtView1(0)("store_code")
            If Not IsDBNull(WK_DtView1(0)("grup_code")) Then grup_code = WK_DtView1(0)("grup_code")
            If Not IsDBNull(WK_DtView1(0)("own_flg")) Then own_flg = WK_DtView1(0)("own_flg")
            If Not IsDBNull(WK_DtView1(0)("note_kbn")) Then note_kbn = WK_DtView1(0)("note_kbn")
        End If

        '計上掛率
        strSQL = "SELECT part_rate, part_amnt"
        strSQL += " FROM M31_PART_RATE"
        strSQL += " WHERE (delt_flg = 0)"
        strSQL += " AND (vndr_code = '" & vndr_code & "')"
        strSQL += " AND (store_code = '" & store_code & "')"
        strSQL += " AND (note_kbn = '" & note_kbn & "')"
        If own_flg = "True" Then
            strSQL += " AND (own_rpat_kbn = '01')"
        Else
            strSQL += " AND (own_rpat_kbn = '02')"
        End If
        strSQL += " AND (strt_amnt <= " & cost & ")"
        strSQL += " AND (end_amnt >= " & cost & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "M31_PART_RATE")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView1(0)("part_rate")) Then GSS_rate = WK_DtView1(0)("part_rate")
            If Not IsDBNull(WK_DtView1(0)("part_amnt")) Then GSS_amnt = WK_DtView1(0)("part_amnt")
        End If

        If own_flg = "True" Then
            GSS_kijo = RoundUP(cost * GSS_rate * qty + GSS_amnt, -2)
        Else
            GSS_kijo = RoundUP(cost * GSS_rate * qty, -2)
            If (vndr_code = "01" Or vndr_code = "06") And note_kbn = "01" Then    'Apple定額
            Else
                If GSS_amnt <> 0 Then
                    If cost * qty >= 5000 Then
                        GSS_kijo = RoundUP(cost * GSS_rate * qty + GSS_amnt, -2)
                    End If
                End If
                If ibm_flg = "True" Then
                    GSS_kijo += 3000
                End If
            End If
        End If

        If grup_code = "18" Or grup_code = "52" Then  'BIC
            part_amnt = RoundUP(GSS_kijo * EU_rate, 0)
        Else
            part_amnt = RoundUP(GSS_kijo * EU_rate, -2)
        End If

        Return part_amnt
    End Function
End Class
