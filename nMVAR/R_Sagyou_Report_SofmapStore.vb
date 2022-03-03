Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sagyou_Report_SofmapStore
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_amnt2, WK_amnt3, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        'èCóùì‡óe
        TextBox12.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox12.Text = DtView1(i)("cmnt")
                Else
                    TextBox12.Text = TextBox12.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'èCóùì‡óe
        TextBox.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox.Text = DtView1(i)("cmnt")
                Else
                    TextBox.Text = TextBox.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'ïîïi
        TextBox18.Text = Nothing : TextBox26.Text = Nothing : TextBox7.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox8.Text = Nothing
        TextBox24.Text = Nothing : TextBox28.Text = Nothing : TextBox10.Text = Nothing
        TextBox25.Text = Nothing : TextBox31.Text = Nothing : TextBox11.Text = Nothing
        TextBox39.Text = Nothing : TextBox41.Text = Nothing : TextBox46.Text = Nothing
        TextBox40.Text = Nothing : TextBox42.Text = Nothing : TextBox47.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox7.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox27.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox8.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox10.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 3
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox11.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 4
                        TextBox39.Text = DtView1(i)("part_name")
                        TextBox41.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox46.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox40.Text = DtView1(i)("part_name")
                        TextBox42.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox47.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 6 Then
                    TextBox40.Text = "ÇªÇÃëºïîïi"
                    TextBox42.Text = WK_cnt
                    TextBox47.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If

        'ï€è·ä˙ä‘àÛéö
        If PRT_PRAM5 = "True" Then
            Label22.Visible = True
            Label23.Visible = True
        Else
            Label22.Visible = False
            Label23.Visible = False
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox38 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Barcode As DataDynamics.ActiveReports.Barcode = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox37 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Label35 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox39 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label37 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox49 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox50 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line20 As DataDynamics.ActiveReports.Line = Nothing
	Private Line22 As DataDynamics.ActiveReports.Line = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox54 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label39 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox56 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox57 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label40 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox58 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox59 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label41 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox60 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox61 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Line23 As DataDynamics.ActiveReports.Line = Nothing
	Private Line24 As DataDynamics.ActiveReports.Line = Nothing
	Private Line25 As DataDynamics.ActiveReports.Line = Nothing
	Private Line26 As DataDynamics.ActiveReports.Line = Nothing
	Private Line27 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line21 As DataDynamics.ActiveReports.Line = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox63 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox64 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label42 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox65 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label43 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox66 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line28 As DataDynamics.ActiveReports.Line = Nothing
	Private Line30 As DataDynamics.ActiveReports.Line = Nothing
	Private Line31 As DataDynamics.ActiveReports.Line = Nothing
	Private Line32 As DataDynamics.ActiveReports.Line = Nothing
	Private Line33 As DataDynamics.ActiveReports.Line = Nothing
	Private Line34 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox100 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox67 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox69 As DataDynamics.ActiveReports.TextBox = Nothing
	Private note_kbn As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox71 As DataDynamics.ActiveReports.TextBox = Nothing
	Private fix1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private vndr_code As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox62 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line29 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Sagyou_Report_SofmapStore.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox38 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label12 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.TextBox21 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.Line1 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Line)
		Me.Label = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.TextBox12 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Label50 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Label)
		Me.TextBox13 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.Label51 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.TextBox18 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.Label27 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Barcode = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Barcode)
		Me.TextBox2 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.Line13 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Line)
		Me.Label7 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.Label9 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.TextBox29 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.Line11 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Line)
		Me.Label16 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Label)
		Me.TextBox32 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.TextBox)
		Me.Label17 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.TextBox33 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.TextBox)
		Me.Label4 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.TextBox34 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.TextBox37 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.Label18 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.TextBox)
		Me.Label2 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.TextBox)
		Me.Label10 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Label)
		Me.Label31 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Label)
		Me.Label32 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.Label34 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.Label35 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.TextBox14 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.TextBox30 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.TextBox)
		Me.Line3 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Line)
		Me.TextBox39 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.TextBox)
		Me.TextBox40 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.TextBox)
		Me.Line17 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Line)
		Me.TextBox46 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.TextBox)
		Me.Label37 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Label)
		Me.TextBox48 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.TextBox)
		Me.TextBox49 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.TextBox)
		Me.TextBox50 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.TextBox)
		Me.Line20 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Line)
		Me.Label26 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.Label)
		Me.TextBox54 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.TextBox)
		Me.TextBox55 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.TextBox)
		Me.Label39 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.Label)
		Me.TextBox56 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.TextBox)
		Me.TextBox57 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.TextBox)
		Me.Label40 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.Label)
		Me.TextBox58 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.TextBox)
		Me.TextBox59 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.TextBox)
		Me.Label41 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.Label)
		Me.TextBox60 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.TextBox)
		Me.TextBox61 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Line)
		Me.Label21 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.Label)
		Me.Line16 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.Line)
		Me.Line23 = CType(Me.Detail.Controls(118),DataDynamics.ActiveReports.Line)
		Me.Line24 = CType(Me.Detail.Controls(119),DataDynamics.ActiveReports.Line)
		Me.Line25 = CType(Me.Detail.Controls(120),DataDynamics.ActiveReports.Line)
		Me.Line26 = CType(Me.Detail.Controls(121),DataDynamics.ActiveReports.Line)
		Me.Line27 = CType(Me.Detail.Controls(122),DataDynamics.ActiveReports.Line)
		Me.TextBox43 = CType(Me.Detail.Controls(123),DataDynamics.ActiveReports.TextBox)
		Me.Line21 = CType(Me.Detail.Controls(124),DataDynamics.ActiveReports.Line)
		Me.Label22 = CType(Me.Detail.Controls(125),DataDynamics.ActiveReports.Label)
		Me.TextBox44 = CType(Me.Detail.Controls(126),DataDynamics.ActiveReports.TextBox)
		Me.Label23 = CType(Me.Detail.Controls(127),DataDynamics.ActiveReports.Label)
		Me.TextBox45 = CType(Me.Detail.Controls(128),DataDynamics.ActiveReports.TextBox)
		Me.TextBox63 = CType(Me.Detail.Controls(129),DataDynamics.ActiveReports.TextBox)
		Me.Label24 = CType(Me.Detail.Controls(130),DataDynamics.ActiveReports.Label)
		Me.TextBox64 = CType(Me.Detail.Controls(131),DataDynamics.ActiveReports.TextBox)
		Me.Label42 = CType(Me.Detail.Controls(132),DataDynamics.ActiveReports.Label)
		Me.TextBox65 = CType(Me.Detail.Controls(133),DataDynamics.ActiveReports.TextBox)
		Me.Label43 = CType(Me.Detail.Controls(134),DataDynamics.ActiveReports.Label)
		Me.TextBox66 = CType(Me.Detail.Controls(135),DataDynamics.ActiveReports.TextBox)
		Me.Line18 = CType(Me.Detail.Controls(136),DataDynamics.ActiveReports.Line)
		Me.Line28 = CType(Me.Detail.Controls(137),DataDynamics.ActiveReports.Line)
		Me.Line30 = CType(Me.Detail.Controls(138),DataDynamics.ActiveReports.Line)
		Me.Line31 = CType(Me.Detail.Controls(139),DataDynamics.ActiveReports.Line)
		Me.Line32 = CType(Me.Detail.Controls(140),DataDynamics.ActiveReports.Line)
		Me.Line33 = CType(Me.Detail.Controls(141),DataDynamics.ActiveReports.Line)
		Me.Line34 = CType(Me.Detail.Controls(142),DataDynamics.ActiveReports.Line)
		Me.TextBox100 = CType(Me.Detail.Controls(143),DataDynamics.ActiveReports.TextBox)
		Me.TextBox67 = CType(Me.Detail.Controls(144),DataDynamics.ActiveReports.TextBox)
		Me.TextBox69 = CType(Me.Detail.Controls(145),DataDynamics.ActiveReports.TextBox)
		Me.note_kbn = CType(Me.Detail.Controls(146),DataDynamics.ActiveReports.TextBox)
		Me.TextBox71 = CType(Me.Detail.Controls(147),DataDynamics.ActiveReports.TextBox)
		Me.fix1 = CType(Me.Detail.Controls(148),DataDynamics.ActiveReports.TextBox)
		Me.vndr_code = CType(Me.Detail.Controls(149),DataDynamics.ActiveReports.TextBox)
		Me.TextBox62 = CType(Me.Detail.Controls(150),DataDynamics.ActiveReports.TextBox)
		Me.Line29 = CType(Me.Detail.Controls(151),DataDynamics.ActiveReports.Line)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        TextBox7.Text = "\" & Format(CInt(TextBox7.Text), "##,##0")

        If Trim(TextBox67.Text) <> Nothing Then
            If Trim(TextBox12.Text) <> Nothing Then
                TextBox12.Text = TextBox12.Text & System.Environment.NewLine & TextBox67.Text
            Else
                TextBox12.Text = TextBox67.Text
            End If
        End If

        If Trim(TextBox69.Text) <> Nothing Then
            If Trim(TextBox.Text) <> Nothing Then
                TextBox.Text = TextBox.Text & System.Environment.NewLine & TextBox69.Text
            Else
                TextBox.Text = TextBox69.Text
            End If
        End If

        If fix1.Text <> "0" Then         'íËäzÇÃèÍçáîÒï\é¶
            TextBox26.Text = Nothing : TextBox7.Text = Nothing
            TextBox27.Text = Nothing : TextBox8.Text = Nothing
            TextBox28.Text = Nothing : TextBox10.Text = Nothing
            TextBox31.Text = Nothing : TextBox11.Text = Nothing
            TextBox41.Text = Nothing : TextBox46.Text = Nothing
            TextBox42.Text = Nothing : TextBox47.Text = Nothing
            'Label31.Visible = False : Label32.Visible = False : TextBox14.Visible = False : TextBox15.Visible = False : TextBox23.Visible = False : TextBox30.Visible = False
        End If

        If vndr_code.Text = "01" Then
            TextBox60.Text = "\" & Format(CInt(TextBox56.Text) + CInt(TextBox58.Text) + CInt(TextBox19.Text), "##,##0")
            TextBox61.Text = "\" & Format(CInt(TextBox57.Text) + CInt(TextBox59.Text) + CInt(TextBox38.Text), "##,##0")
        Else
            Label12.Visible = False : TextBox19.Visible = False : TextBox38.Visible = False
            TextBox60.Text = "\" & Format(CInt(TextBox56.Text) + CInt(TextBox58.Text), "##,##0")
            TextBox61.Text = "\" & Format(CInt(TextBox57.Text) + CInt(TextBox59.Text), "##,##0")
        End If

        'TextBox14.Text = "\" & Format(CInt(TextBox14.Text), "##,##0") : TextBox23.Text = "\" & Format(CInt(TextBox23.Text), "##,##0")
        'TextBox15.Text = "\" & Format(CInt(TextBox15.Text), "##,##0") : TextBox30.Text = "\" & Format(CInt(TextBox30.Text), "##,##0")
        'TextBox20.Text = "\" & Format(CInt(TextBox20.Text), "##,##0") : TextBox35.Text = "\" & Format(CInt(TextBox35.Text), "##,##0")
        'TextBox17.Text = "\" & Format(CInt(TextBox17.Text), "##,##0") : TextBox36.Text = "\" & Format(CInt(TextBox36.Text), "##,##0")

        'TextBox58.Text = "\" & Format(CInt(TextBox58.Text), "##,##0") : TextBox59.Text = "\" & Format(CInt(TextBox59.Text), "##,##0")
        'TextBox60.Text = "\" & Format(CInt(TextBox60.Text), "##,##0") : TextBox61.Text = "\" & Format(CInt(TextBox61.Text), "##,##0")

        Label23.Text = StrConv(TextBox100.Text, VbStrConv.Wide) & "ì˙Ç≈Ç∑ÅB"
    End Sub
End Class
