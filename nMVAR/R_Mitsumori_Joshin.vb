Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Mitsumori_Joshin
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        '修理内容
        TextBox62.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox62.Text = DtView1(i)("cmnt")
                Else
                    TextBox62.Text = TextBox62.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox63.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox63.Text = DtView1(i)("cmnt")
                Else
                    TextBox63.Text = TextBox63.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox32.Text = Nothing : TextBox57.Text = Nothing
        TextBox35.Text = Nothing : TextBox4.Text = Nothing
        TextBox37.Text = Nothing : TextBox11.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox32.Text = DtView1(i)("part_name")
                        TextBox57.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox35.Text = DtView1(i)("part_name")
                        TextBox4.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox37.Text = DtView1(i)("part_name")
                        TextBox11.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 3 Then
                    TextBox37.Text = "その他部品"
                    TextBox11.Text = Format(WK_amnt, "##,##0")
                End If
            Next
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label55 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox37 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox57 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox61 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox62 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox63 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private Label46 As DataDynamics.ActiveReports.Label = Nothing
	Private Label47 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label48 As DataDynamics.ActiveReports.Label = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label52 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label53 As DataDynamics.ActiveReports.Label = Nothing
	Private Label54 As DataDynamics.ActiveReports.Label = Nothing
	Private Label56 As DataDynamics.ActiveReports.Label = Nothing
	Private Label57 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label58 As DataDynamics.ActiveReports.Label = Nothing
	Private Label59 As DataDynamics.ActiveReports.Label = Nothing
	Private Label60 As DataDynamics.ActiveReports.Label = Nothing
	Private Label61 As DataDynamics.ActiveReports.Label = Nothing
	Private Label62 As DataDynamics.ActiveReports.Label = Nothing
	Private Label63 As DataDynamics.ActiveReports.Label = Nothing
	Private Label64 As DataDynamics.ActiveReports.Label = Nothing
	Private Label65 As DataDynamics.ActiveReports.Label = Nothing
	Private Label66 As DataDynamics.ActiveReports.Label = Nothing
	Private Label67 As DataDynamics.ActiveReports.Label = Nothing
	Private Label68 As DataDynamics.ActiveReports.Label = Nothing
	Private Label69 As DataDynamics.ActiveReports.Label = Nothing
	Private Label70 As DataDynamics.ActiveReports.Label = Nothing
	Private Label71 As DataDynamics.ActiveReports.Label = Nothing
	Private Label72 As DataDynamics.ActiveReports.Label = Nothing
	Private Label73 As DataDynamics.ActiveReports.Label = Nothing
	Private Label74 As DataDynamics.ActiveReports.Label = Nothing
	Private Label75 As DataDynamics.ActiveReports.Label = Nothing
	Private Label76 As DataDynamics.ActiveReports.Label = Nothing
	Private Label77 As DataDynamics.ActiveReports.Label = Nothing
	Private Label78 As DataDynamics.ActiveReports.Label = Nothing
	Private Label79 As DataDynamics.ActiveReports.Label = Nothing
	Private Label80 As DataDynamics.ActiveReports.Label = Nothing
	Private Label81 As DataDynamics.ActiveReports.Label = Nothing
	Private Label82 As DataDynamics.ActiveReports.Label = Nothing
	Private Label83 As DataDynamics.ActiveReports.Label = Nothing
	Private Label84 As DataDynamics.ActiveReports.Label = Nothing
	Private Label85 As DataDynamics.ActiveReports.Label = Nothing
	Private Label86 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label87 As DataDynamics.ActiveReports.Label = Nothing
	Private Label88 As DataDynamics.ActiveReports.Label = Nothing
	Private Label89 As DataDynamics.ActiveReports.Label = Nothing
	Private Label90 As DataDynamics.ActiveReports.Label = Nothing
	Private Label91 As DataDynamics.ActiveReports.Label = Nothing
	Private Label92 As DataDynamics.ActiveReports.Label = Nothing
	Private Label93 As DataDynamics.ActiveReports.Label = Nothing
	Private Label94 As DataDynamics.ActiveReports.Label = Nothing
	Private Label95 As DataDynamics.ActiveReports.Label = Nothing
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
	Private Line30 As DataDynamics.ActiveReports.Line = Nothing
	Private Line31 As DataDynamics.ActiveReports.Line = Nothing
	Private Line32 As DataDynamics.ActiveReports.Line = Nothing
	Private Line33 As DataDynamics.ActiveReports.Line = Nothing
	Private Line34 As DataDynamics.ActiveReports.Line = Nothing
	Private Line35 As DataDynamics.ActiveReports.Line = Nothing
	Private Line36 As DataDynamics.ActiveReports.Line = Nothing
	Private Line37 As DataDynamics.ActiveReports.Line = Nothing
	Private Line38 As DataDynamics.ActiveReports.Line = Nothing
	Private Line39 As DataDynamics.ActiveReports.Line = Nothing
	Private Line40 As DataDynamics.ActiveReports.Line = Nothing
	Private Line41 As DataDynamics.ActiveReports.Line = Nothing
	Private Line42 As DataDynamics.ActiveReports.Line = Nothing
	Private Line43 As DataDynamics.ActiveReports.Line = Nothing
	Private Line44 As DataDynamics.ActiveReports.Line = Nothing
	Private Line45 As DataDynamics.ActiveReports.Line = Nothing
	Private Line48 As DataDynamics.ActiveReports.Line = Nothing
	Private Line49 As DataDynamics.ActiveReports.Line = Nothing
	Private Line51 As DataDynamics.ActiveReports.Line = Nothing
	Private Line52 As DataDynamics.ActiveReports.Line = Nothing
	Private Line53 As DataDynamics.ActiveReports.Line = Nothing
	Private Line54 As DataDynamics.ActiveReports.Line = Nothing
	Private Label96 As DataDynamics.ActiveReports.Label = Nothing
	Private Line46 As DataDynamics.ActiveReports.Line = Nothing
	Private Line47 As DataDynamics.ActiveReports.Line = Nothing
	Private Line50 As DataDynamics.ActiveReports.Line = Nothing
	Private Line55 As DataDynamics.ActiveReports.Line = Nothing
	Private Line56 As DataDynamics.ActiveReports.Line = Nothing
	Private Line57 As DataDynamics.ActiveReports.Line = Nothing
	Private Line58 As DataDynamics.ActiveReports.Line = Nothing
	Private Line59 As DataDynamics.ActiveReports.Line = Nothing
	Private Line60 As DataDynamics.ActiveReports.Line = Nothing
	Private Line61 As DataDynamics.ActiveReports.Line = Nothing
	Private Line62 As DataDynamics.ActiveReports.Line = Nothing
	Private Line63 As DataDynamics.ActiveReports.Line = Nothing
	Private Line64 As DataDynamics.ActiveReports.Line = Nothing
	Private Line65 As DataDynamics.ActiveReports.Line = Nothing
	Private Line66 As DataDynamics.ActiveReports.Line = Nothing
	Private Line67 As DataDynamics.ActiveReports.Line = Nothing
	Private Line68 As DataDynamics.ActiveReports.Line = Nothing
	Private Line69 As DataDynamics.ActiveReports.Line = Nothing
	Private Line70 As DataDynamics.ActiveReports.Line = Nothing
	Private Line71 As DataDynamics.ActiveReports.Line = Nothing
	Private Line72 As DataDynamics.ActiveReports.Line = Nothing
	Private Line73 As DataDynamics.ActiveReports.Line = Nothing
	Private Line74 As DataDynamics.ActiveReports.Line = Nothing
	Private Line75 As DataDynamics.ActiveReports.Line = Nothing
	Private Line76 As DataDynamics.ActiveReports.Line = Nothing
	Private Line77 As DataDynamics.ActiveReports.Line = Nothing
	Private Line78 As DataDynamics.ActiveReports.Line = Nothing
	Private Line79 As DataDynamics.ActiveReports.Line = Nothing
	Private Line80 As DataDynamics.ActiveReports.Line = Nothing
	Private Line81 As DataDynamics.ActiveReports.Line = Nothing
	Private Line82 As DataDynamics.ActiveReports.Line = Nothing
	Private Label97 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Mitsumori_Joshin.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label9 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox10 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox22 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Label14 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.Label4 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.TextBox23 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.Label55 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.TextBox32 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox37 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.TextBox55 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.TextBox57 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.Label10 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.TextBox61 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.TextBox62 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.TextBox63 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.Label12 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label46 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.Label47 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.Label48 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label49 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Label50 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label51 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.TextBox8 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.Label52 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.TextBox9 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.Label53 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.Label54 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label56 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label57 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label58 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Label59 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.Label60 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.Label61 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.Label62 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.Label63 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.Label64 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Label)
		Me.Label65 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Label)
		Me.Label66 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.Label67 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.Label68 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.Label69 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Label)
		Me.Label70 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.Label71 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Label)
		Me.Label72 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Label)
		Me.Label73 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Label)
		Me.Label74 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.Label75 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Label)
		Me.Label76 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Label77 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Label)
		Me.Label78 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Label)
		Me.Label79 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Label)
		Me.Label80 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Label)
		Me.Label81 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Label)
		Me.Label82 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Label)
		Me.Label83 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Label)
		Me.Label84 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Label)
		Me.Label85 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Label)
		Me.Label86 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Label)
		Me.TextBox13 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.TextBox)
		Me.Label87 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Label)
		Me.Label88 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Label)
		Me.Label89 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Label)
		Me.Label90 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.Label)
		Me.Label91 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Label)
		Me.Label92 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Label)
		Me.Label93 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.Label)
		Me.Label94 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.Label)
		Me.Label95 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.Label)
		Me.Line7 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.Line)
		Me.Line23 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.Line)
		Me.Line24 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.Line)
		Me.Line25 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.Line)
		Me.Line26 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.Line)
		Me.Line27 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.Line)
		Me.Line28 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Line)
		Me.Line29 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.Line)
		Me.Line30 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.Line)
		Me.Line31 = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.Line)
		Me.Line32 = CType(Me.Detail.Controls(118),DataDynamics.ActiveReports.Line)
		Me.Line33 = CType(Me.Detail.Controls(119),DataDynamics.ActiveReports.Line)
		Me.Line34 = CType(Me.Detail.Controls(120),DataDynamics.ActiveReports.Line)
		Me.Line35 = CType(Me.Detail.Controls(121),DataDynamics.ActiveReports.Line)
		Me.Line36 = CType(Me.Detail.Controls(122),DataDynamics.ActiveReports.Line)
		Me.Line37 = CType(Me.Detail.Controls(123),DataDynamics.ActiveReports.Line)
		Me.Line38 = CType(Me.Detail.Controls(124),DataDynamics.ActiveReports.Line)
		Me.Line39 = CType(Me.Detail.Controls(125),DataDynamics.ActiveReports.Line)
		Me.Line40 = CType(Me.Detail.Controls(126),DataDynamics.ActiveReports.Line)
		Me.Line41 = CType(Me.Detail.Controls(127),DataDynamics.ActiveReports.Line)
		Me.Line42 = CType(Me.Detail.Controls(128),DataDynamics.ActiveReports.Line)
		Me.Line43 = CType(Me.Detail.Controls(129),DataDynamics.ActiveReports.Line)
		Me.Line44 = CType(Me.Detail.Controls(130),DataDynamics.ActiveReports.Line)
		Me.Line45 = CType(Me.Detail.Controls(131),DataDynamics.ActiveReports.Line)
		Me.Line48 = CType(Me.Detail.Controls(132),DataDynamics.ActiveReports.Line)
		Me.Line49 = CType(Me.Detail.Controls(133),DataDynamics.ActiveReports.Line)
		Me.Line51 = CType(Me.Detail.Controls(134),DataDynamics.ActiveReports.Line)
		Me.Line52 = CType(Me.Detail.Controls(135),DataDynamics.ActiveReports.Line)
		Me.Line53 = CType(Me.Detail.Controls(136),DataDynamics.ActiveReports.Line)
		Me.Line54 = CType(Me.Detail.Controls(137),DataDynamics.ActiveReports.Line)
		Me.Label96 = CType(Me.Detail.Controls(138),DataDynamics.ActiveReports.Label)
		Me.Line46 = CType(Me.Detail.Controls(139),DataDynamics.ActiveReports.Line)
		Me.Line47 = CType(Me.Detail.Controls(140),DataDynamics.ActiveReports.Line)
		Me.Line50 = CType(Me.Detail.Controls(141),DataDynamics.ActiveReports.Line)
		Me.Line55 = CType(Me.Detail.Controls(142),DataDynamics.ActiveReports.Line)
		Me.Line56 = CType(Me.Detail.Controls(143),DataDynamics.ActiveReports.Line)
		Me.Line57 = CType(Me.Detail.Controls(144),DataDynamics.ActiveReports.Line)
		Me.Line58 = CType(Me.Detail.Controls(145),DataDynamics.ActiveReports.Line)
		Me.Line59 = CType(Me.Detail.Controls(146),DataDynamics.ActiveReports.Line)
		Me.Line60 = CType(Me.Detail.Controls(147),DataDynamics.ActiveReports.Line)
		Me.Line61 = CType(Me.Detail.Controls(148),DataDynamics.ActiveReports.Line)
		Me.Line62 = CType(Me.Detail.Controls(149),DataDynamics.ActiveReports.Line)
		Me.Line63 = CType(Me.Detail.Controls(150),DataDynamics.ActiveReports.Line)
		Me.Line64 = CType(Me.Detail.Controls(151),DataDynamics.ActiveReports.Line)
		Me.Line65 = CType(Me.Detail.Controls(152),DataDynamics.ActiveReports.Line)
		Me.Line66 = CType(Me.Detail.Controls(153),DataDynamics.ActiveReports.Line)
		Me.Line67 = CType(Me.Detail.Controls(154),DataDynamics.ActiveReports.Line)
		Me.Line68 = CType(Me.Detail.Controls(155),DataDynamics.ActiveReports.Line)
		Me.Line69 = CType(Me.Detail.Controls(156),DataDynamics.ActiveReports.Line)
		Me.Line70 = CType(Me.Detail.Controls(157),DataDynamics.ActiveReports.Line)
		Me.Line71 = CType(Me.Detail.Controls(158),DataDynamics.ActiveReports.Line)
		Me.Line72 = CType(Me.Detail.Controls(159),DataDynamics.ActiveReports.Line)
		Me.Line73 = CType(Me.Detail.Controls(160),DataDynamics.ActiveReports.Line)
		Me.Line74 = CType(Me.Detail.Controls(161),DataDynamics.ActiveReports.Line)
		Me.Line75 = CType(Me.Detail.Controls(162),DataDynamics.ActiveReports.Line)
		Me.Line76 = CType(Me.Detail.Controls(163),DataDynamics.ActiveReports.Line)
		Me.Line77 = CType(Me.Detail.Controls(164),DataDynamics.ActiveReports.Line)
		Me.Line78 = CType(Me.Detail.Controls(165),DataDynamics.ActiveReports.Line)
		Me.Line79 = CType(Me.Detail.Controls(166),DataDynamics.ActiveReports.Line)
		Me.Line80 = CType(Me.Detail.Controls(167),DataDynamics.ActiveReports.Line)
		Me.Line81 = CType(Me.Detail.Controls(168),DataDynamics.ActiveReports.Line)
		Me.Line82 = CType(Me.Detail.Controls(169),DataDynamics.ActiveReports.Line)
		Me.Label97 = CType(Me.Detail.Controls(170),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(171),DataDynamics.ActiveReports.Label)
		Me.TextBox47 = CType(Me.Detail.Controls(172),DataDynamics.ActiveReports.TextBox)
		Me.TextBox48 = CType(Me.Detail.Controls(173),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox2 = CType(Me.Detail.Controls(174),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox3 = CType(Me.Detail.Controls(175),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox5 = CType(Me.Detail.Controls(176),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(177),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox62.Text) <> Nothing Then
                TextBox62.Text = TextBox62.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox62.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox63.Text) <> Nothing Then
                TextBox63.Text = TextBox63.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox63.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox27.Text) <> Nothing Then
            If Trim(TextBox63.Text) <> Nothing Then
                TextBox63.Text = TextBox63.Text & System.Environment.NewLine & TextBox27.Text
            Else
                TextBox63.Text = TextBox27.Text
            End If
        End If

        'TextBox61.Text = Format(CInt(TextBox12.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text) + CInt(TextBox5.Text), "##,##0")
    End Sub

End Class
