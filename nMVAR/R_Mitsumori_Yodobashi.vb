Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Mitsumori_Yodobashi
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        'èCóùì‡óe
        TextBox2.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox2.Text = DtView1(i)("cmnt")
                Else
                    TextBox2.Text = TextBox2.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'å©êœì‡óe
        TextBox5.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox5.Text = DtView1(i)("cmnt")
                Else
                    TextBox5.Text = TextBox5.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'ïîïi
        TextBox6.Text = Nothing : TextBox8.Text = Nothing
        TextBox10.Text = Nothing : TextBox25.Text = Nothing
        TextBox26.Text = Nothing : TextBox28.Text = Nothing
        TextBox31.Text = Nothing : TextBox33.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox6.Text = DtView1(i)("part_name")
                        TextBox8.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 1
                        TextBox10.Text = DtView1(i)("part_name")
                        TextBox25.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Is = 2
                        TextBox26.Text = DtView1(i)("part_name")
                        TextBox28.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                    Case Else
                        TextBox31.Text = DtView1(i)("part_name")
                        TextBox33.Text = "\" & Format(DtView1(i)("eu_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("eu_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox31.Text = "ÇªÇÃëºïîïi"
                    TextBox33.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Label52 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label53 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label54 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label55 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line76 As DataDynamics.ActiveReports.Line = Nothing
	Private Line82 As DataDynamics.ActiveReports.Line = Nothing
	Private Label56 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
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
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Line33 As DataDynamics.ActiveReports.Line = Nothing
	Private Line35 As DataDynamics.ActiveReports.Line = Nothing
	Private Line36 As DataDynamics.ActiveReports.Line = Nothing
	Private Line37 As DataDynamics.ActiveReports.Line = Nothing
	Private Line39 As DataDynamics.ActiveReports.Line = Nothing
	Private Line40 As DataDynamics.ActiveReports.Line = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Line41 As DataDynamics.ActiveReports.Line = Nothing
	Private Line42 As DataDynamics.ActiveReports.Line = Nothing
	Private Line44 As DataDynamics.ActiveReports.Line = Nothing
	Private Line48 As DataDynamics.ActiveReports.Line = Nothing
	Private Line49 As DataDynamics.ActiveReports.Line = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line50 As DataDynamics.ActiveReports.Line = Nothing
	Private Line51 As DataDynamics.ActiveReports.Line = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Line34 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Line46 As DataDynamics.ActiveReports.Line = Nothing
	Private Line47 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line52 As DataDynamics.ActiveReports.Line = Nothing
	Private Line53 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private xTextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private note_kbn As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private fix1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private vndr_code As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line81 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Mitsumori_Yodobashi.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox5 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label5 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label4 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.TextBox9 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.TextBox16 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Line)
		Me.Label = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Line6 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Line)
		Me.Label19 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label49 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label50 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.Line12 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Line)
		Me.Label51 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label52 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.TextBox23 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.Label53 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.TextBox29 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.Label54 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.TextBox30 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.Label14 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.TextBox17 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.TextBox)
		Me.Label55 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.TextBox19 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.TextBox)
		Me.Line13 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Line)
		Me.Line76 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Line)
		Me.Line82 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Line)
		Me.Label56 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.Label9 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Label)
		Me.TextBox10 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.TextBox)
		Me.Label11 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.TextBox36 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.TextBox)
		Me.Label12 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.TextBox41 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.Label16 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Label)
		Me.TextBox43 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.TextBox)
		Me.Label17 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.TextBox44 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.TextBox)
		Me.Label18 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Label)
		Me.Line20 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Line)
		Me.Line21 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Line)
		Me.Line22 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Line)
		Me.Line23 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Line)
		Me.Line24 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Line)
		Me.Line25 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Line)
		Me.Line26 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Line)
		Me.Line27 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Line)
		Me.Line28 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Line)
		Me.Line29 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Line)
		Me.Line30 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Line)
		Me.Line31 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Line)
		Me.Line32 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Line)
		Me.Label22 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Label)
		Me.Label30 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.Label)
		Me.Line33 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Line)
		Me.Line35 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Line)
		Me.Line36 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.Line)
		Me.Line37 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.Line)
		Me.Line39 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.Line)
		Me.Line40 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.Line)
		Me.Label31 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.Label)
		Me.Line19 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Line)
		Me.Line41 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.Line)
		Me.Line42 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.Line)
		Me.Line44 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.Line)
		Me.Line48 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.Line)
		Me.Line49 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.Line)
		Me.Label10 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.TextBox)
		Me.Label25 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.Label)
		Me.TextBox12 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.TextBox)
		Me.Line50 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.Line)
		Me.Line51 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.Line)
		Me.Label32 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.Label)
		Me.Label34 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.Label)
		Me.Line34 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.Line)
		Me.Line46 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.Line)
		Me.Line47 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.Line)
		Me.TextBox20 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(118),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(119),DataDynamics.ActiveReports.TextBox)
		Me.Line52 = CType(Me.Detail.Controls(120),DataDynamics.ActiveReports.Line)
		Me.Line53 = CType(Me.Detail.Controls(121),DataDynamics.ActiveReports.Line)
		Me.TextBox47 = CType(Me.Detail.Controls(122),DataDynamics.ActiveReports.TextBox)
		Me.TextBox48 = CType(Me.Detail.Controls(123),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox14 = CType(Me.Detail.Controls(124),DataDynamics.ActiveReports.TextBox)
		Me.xTextBox21 = CType(Me.Detail.Controls(125),DataDynamics.ActiveReports.TextBox)
		Me.note_kbn = CType(Me.Detail.Controls(126),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(127),DataDynamics.ActiveReports.TextBox)
		Me.fix1 = CType(Me.Detail.Controls(128),DataDynamics.ActiveReports.TextBox)
		Me.vndr_code = CType(Me.Detail.Controls(129),DataDynamics.ActiveReports.TextBox)
		Me.Line81 = CType(Me.Detail.Controls(130),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(131),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(132),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(133),DataDynamics.ActiveReports.Line)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox2.Text) <> Nothing Then
                TextBox2.Text = TextBox2.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox2.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox5.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox27.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox27.Text
            Else
                TextBox5.Text = TextBox27.Text
            End If
        End If

        'If note_kbn.Text = "01" Then   'íËäzÇÃèÍçáîÒï\é¶
        If fix1.Text <> "0" And vndr_code.Text <> "02" Then       'íËäzÇÃèÍçáîÒï\é¶
            TextBox8.Text = Nothing
            TextBox25.Text = Nothing
            TextBox28.Text = Nothing
            TextBox33.Text = Nothing
            Label11.Visible = False : Label12.Visible = False : TextBox36.Visible = False : TextBox41.Visible = False
        End If

        'TextBox43.Text = "\" & Format(CInt(TextBox36.Text) + CInt(TextBox41.Text) + CInt(TextBox14.Text) + CInt(TextBox21.Text), "##,##0")
        TextBox44.Text = "\" & Format(CInt(TextBox43.Text) + CInt(TextBox45.Text), "##,##0")
        TextBox18.Text = "\" & Format(CInt(TextBox44.Text), "##,##0")
    End Sub
End Class
