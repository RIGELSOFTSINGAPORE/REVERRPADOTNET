Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Mitsumori_Normal_Teigaku
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        '修理内容
        TextBox43.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox43.Text = DtView1(i)("cmnt")
                Else
                    TextBox43.Text = TextBox43.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox44.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox44.Text = DtView1(i)("cmnt")
                Else
                    TextBox44.Text = TextBox44.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox30.Text = Nothing
        TextBox40.Text = Nothing
        TextBox42.Text = Nothing
        TextBox41.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox30.Text = DtView1(i)("part_name")
                    Case Is = 1
                        TextBox40.Text = DtView1(i)("part_name")
                    Case Is = 2
                        TextBox42.Text = DtView1(i)("part_name")
                    Case Else
                        TextBox41.Text = DtView1(i)("part_name")
                End Select

                If DtView1.Count > 4 Then
                    TextBox41.Text = "その他部品"
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
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label55 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox62 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox63 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Label35 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Label37 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label39 As DataDynamics.ActiveReports.Label = Nothing
	Private Label40 As DataDynamics.ActiveReports.Label = Nothing
	Private Label41 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label42 As DataDynamics.ActiveReports.Label = Nothing
	Private Label43 As DataDynamics.ActiveReports.Label = Nothing
	Private Label44 As DataDynamics.ActiveReports.Label = Nothing
	Private Label45 As DataDynamics.ActiveReports.Label = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Label48 As DataDynamics.ActiveReports.Label = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label52 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label54 As DataDynamics.ActiveReports.Label = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label53 As DataDynamics.ActiveReports.Label = Nothing
	Private Label56 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label57 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Label58 As DataDynamics.ActiveReports.Label = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label59 As DataDynamics.ActiveReports.Label = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox101 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox100 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox24 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label61 As DataDynamics.ActiveReports.Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Mitsumori_Normal_Teigaku.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label9 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox10 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox22 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.Label14 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.Label55 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.TextBox55 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.Label17 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.TextBox62 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Label)
		Me.TextBox63 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Label12 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.Label30 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.Label31 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label32 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.Label34 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label35 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.Label37 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.TextBox2 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.TextBox)
		Me.Label39 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label40 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label41 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.TextBox)
		Me.Label42 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.Label43 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Label)
		Me.Label44 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Label)
		Me.Label45 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Line)
		Me.Label48 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label49 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Label52 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.TextBox9 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.TextBox)
		Me.Label54 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.Line7 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Line)
		Me.Label1 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.Label3 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.TextBox12 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.TextBox)
		Me.Label6 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.TextBox)
		Me.Label8 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Label)
		Me.TextBox17 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.TextBox)
		Me.Label10 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.TextBox18 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.Label11 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.TextBox19 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Label)
		Me.TextBox20 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Label)
		Me.TextBox21 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Label)
		Me.Line8 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Line)
		Me.Label5 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.TextBox)
		Me.Line10 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Line)
		Me.TextBox30 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.TextBox)
		Me.Label51 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Label)
		Me.TextBox40 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.TextBox)
		Me.Label53 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.Label)
		Me.Label56 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.Label)
		Me.TextBox43 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.TextBox)
		Me.Label57 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.Label)
		Me.TextBox44 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.TextBox)
		Me.Line11 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.Line)
		Me.Label58 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.Label)
		Me.Line15 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.Line)
		Me.TextBox46 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.TextBox)
		Me.Label59 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.Label)
		Me.Line16 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.Line)
		Me.TextBox101 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.TextBox)
		Me.TextBox48 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.TextBox)
		Me.TextBox100 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(118),DataDynamics.ActiveReports.TextBox)
		Me.Label16 = CType(Me.Detail.Controls(119),DataDynamics.ActiveReports.Label)
		Me.Label61 = CType(Me.Detail.Controls(120),DataDynamics.ActiveReports.Label)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox43.Text) <> Nothing Then
                TextBox43.Text = TextBox43.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox43.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox44.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox28.Text) <> Nothing Then
            If Trim(TextBox44.Text) <> Nothing Then
                TextBox44.Text = TextBox44.Text & System.Environment.NewLine & TextBox28.Text
            Else
                TextBox44.Text = TextBox28.Text
            End If
        End If

        'TextBox6.Text = Format(CInt(TextBox25.Text) + CInt(TextBox24.Text) + CInt(TextBox8.Text) + CInt(TextBox7.Text), "##,##0")
        TextBox63.Text = "\" & Format(CInt(TextBox6.Text) + CInt(TextBox62.Text), "##,##0")

        Label4.Text = "見積有効期間： 見積後" & StrConv(TextBox101.Text, VbStrConv.Wide) & "日間"
        Label21.Text = "・ 交換部品の保証期間は、修理完了日より" & StrConv(TextBox100.Text, VbStrConv.Wide) & "日間です。"
        TextBox4.Text = "\" & Format(RoundDOWN(CInt(TextBox26.Text) * (1 + CInt(TextBox27.Text) / 100), 0), "##,##0")
    End Sub
End Class
