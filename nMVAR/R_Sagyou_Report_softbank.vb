Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sagyou_Report_softbank
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox1.Text = Format(Now.Date, "yyyy年MM月dd日")

        '修理内容
        TextBox19.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox19.Text = DtView1(i)("cmnt")
                Else
                    TextBox19.Text = TextBox19.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '修理内容
        TextBox6.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print06"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox6.Text = DtView1(i)("cmnt")
                Else
                    TextBox6.Text = TextBox6.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox7.Text = Nothing : TextBox18.Text = Nothing : TextBox26.Text = Nothing : TextBox32.Text = Nothing
        TextBox8.Text = Nothing : TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox33.Text = Nothing
        TextBox10.Text = Nothing : TextBox24.Text = Nothing : TextBox28.Text = Nothing : TextBox34.Text = Nothing
        TextBox17.Text = Nothing : TextBox25.Text = Nothing : TextBox31.Text = Nothing : TextBox37.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("exp_flg")) Then DtView1(i)("exp_flg") = "False"
                Select Case i
                    Case Is = 0
                        TextBox7.Text = DtView1(i)("part_code")
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox32.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        If DtView1(i)("exp_flg") = "True" Then Label01.Visible = True : Label6.Visible = True
                    Case Is = 1
                        TextBox8.Text = DtView1(i)("part_code")
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox27.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox33.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        If DtView1(i)("exp_flg") = "True" Then Label02.Visible = True : Label6.Visible = True
                    Case Is = 2
                        TextBox10.Text = DtView1(i)("part_code")
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox34.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        If DtView1(i)("exp_flg") = "True" Then Label03.Visible = True : Label6.Visible = True
                    Case Else
                        TextBox17.Text = DtView1(i)("part_code")
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox37.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        If DtView1(i)("exp_flg") = "True" Then Label04.Visible = True : Label6.Visible = True
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox17.Text = "その他部品"
                    TextBox25.Text = Nothing
                    TextBox31.Text = WK_cnt
                    TextBox37.Text = "\" & Format(WK_amnt, "##,##0")
                    Label04.Visible = False
                End If
            Next
        End If

        '部品番号印字
        If PRT_PRAM4 = "True" Then
            Shape.Visible = False
        Else
            Shape.Visible = True
        End If

        '保障期間印字
        If PRT_PRAM5 = "True" Then
            Label25.Visible = True
            Label26.Visible = True
        Else
            Label25.Visible = False
            Label26.Visible = False
        End If
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Label52 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label56 As DataDynamics.ActiveReports.Label = Nothing
	Private Label57 As DataDynamics.ActiveReports.Label = Nothing
	Private Label58 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label59 As DataDynamics.ActiveReports.Label = Nothing
	Private Label60 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label61 As DataDynamics.ActiveReports.Label = Nothing
	Private Label62 As DataDynamics.ActiveReports.Label = Nothing
	Private Label63 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox49 As DataDynamics.ActiveReports.TextBox = Nothing
	Private vndr_code As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Line68 As DataDynamics.ActiveReports.Line = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox37 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox38 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox39 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Line20 As DataDynamics.ActiveReports.Line = Nothing
	Private Line21 As DataDynamics.ActiveReports.Line = Nothing
	Private Line22 As DataDynamics.ActiveReports.Line = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line23 As DataDynamics.ActiveReports.Line = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Line24 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox50 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private note_kbn As DataDynamics.ActiveReports.TextBox = Nothing
	Private fix1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Shape As DataDynamics.ActiveReports.Shape = Nothing
	Private Label01 As DataDynamics.ActiveReports.Label = Nothing
	Private Label02 As DataDynamics.ActiveReports.Label = Nothing
	Private Label03 As DataDynamics.ActiveReports.Label = Nothing
	Private Label04 As DataDynamics.ActiveReports.Label = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox100 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Barcode3 As DataDynamics.ActiveReports.Barcode = Nothing
	Private Barcode2 As DataDynamics.ActiveReports.Barcode = Nothing
	Private Barcode1 As DataDynamics.ActiveReports.Barcode = Nothing
	Private Barcode As DataDynamics.ActiveReports.Barcode = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Sagyou_Report_softbank.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.TextBox20 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Line)
		Me.Label = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Line6 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Line)
		Me.Label8 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label49 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.TextBox12 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.Label50 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.TextBox13 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.Label51 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Label)
		Me.Line11 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Line)
		Me.Label52 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.Label5 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label56 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label57 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label58 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.Label59 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.Label60 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.TextBox2 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.TextBox)
		Me.Label61 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label62 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label63 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Line)
		Me.Label30 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.TextBox29 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.TextBox)
		Me.TextBox46 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.TextBox49 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.vndr_code = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Line68 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Line)
		Me.Label3 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.TextBox)
		Me.TextBox32 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.TextBox)
		Me.TextBox37 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.TextBox)
		Me.TextBox38 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.TextBox)
		Me.TextBox39 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.TextBox)
		Me.TextBox40 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Label)
		Me.Line8 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Line)
		Me.Label21 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.Label)
		Me.TextBox43 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.TextBox)
		Me.TextBox44 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.TextBox)
		Me.Line23 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.Line)
		Me.Label25 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.Label)
		Me.Line24 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.Line)
		Me.TextBox50 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.TextBox)
		Me.TextBox52 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.TextBox)
		Me.note_kbn = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.TextBox)
		Me.fix1 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.TextBox)
		Me.Shape = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.Shape)
		Me.Label01 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.Label)
		Me.Label02 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Label)
		Me.Label03 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.Label)
		Me.Label04 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.Label)
		Me.Line13 = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.Line)
		Me.TextBox100 = CType(Me.Detail.Controls(118),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(119),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(120),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(121),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(122),DataDynamics.ActiveReports.TextBox)
		Me.TextBox30 = CType(Me.Detail.Controls(123),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.Detail.Controls(124),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(125),DataDynamics.ActiveReports.TextBox)
		Me.Barcode3 = CType(Me.Detail.Controls(126),DataDynamics.ActiveReports.Barcode)
		Me.Barcode2 = CType(Me.Detail.Controls(127),DataDynamics.ActiveReports.Barcode)
		Me.Barcode1 = CType(Me.Detail.Controls(128),DataDynamics.ActiveReports.Barcode)
		Me.Barcode = CType(Me.Detail.Controls(129),DataDynamics.ActiveReports.Barcode)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        TextBox45.Text = TextBox2.Text & " " & TextBox23.Text

        '過失有無
        If TextBox35.Text = "True" Then
            TextBox30.Text = "過失：有"
        Else
            TextBox30.Text = "過失：無"
        End If

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox19.Text) <> Nothing Then
                TextBox19.Text = TextBox19.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox19.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox49.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox49.Text
            Else
                TextBox6.Text = TextBox49.Text
            End If
        End If

        'If fix1.Text <> "0" Then         '定額の場合非表示
        If fix1.Text <> "0" And vndr_code.Text <> "02" Then       '定額の場合非表示
            TextBox26.Text = Nothing : TextBox32.Text = Nothing
            TextBox27.Text = Nothing : TextBox33.Text = Nothing
            TextBox28.Text = Nothing : TextBox34.Text = Nothing
            TextBox31.Text = Nothing : TextBox37.Text = Nothing
            Label15.Visible = False : Label16.Visible = False : TextBox38.Visible = False : TextBox39.Visible = False
        End If

        TextBox39.Text = "\" & Format(CInt(TextBox50.Text) + CInt(TextBox51.Text) + CInt(TextBox52.Text), "##,##0")
        TextBox42.Text = "\" & Format(CInt(TextBox40.Text) + CInt(TextBox41.Text), "##,##0")
        'Barcode.Text = "*" & TextBox21.Text & "*"
        Barcode1.Text = "a" & TextBox36.Text & "a"
        Barcode2.Text = "a" & TextBox5.Text & "a"
        Barcode3.Text = "a" & CInt(TextBox40.Text) & "a"

        Label25.Text = "修理後保証は交換部品に対して適用されます。修理保証期間は修理完了日から" & StrConv(TextBox100.Text, VbStrConv.Wide) & "日間となっております。"
    End Sub
End Class
