Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sagyou_Report_Kojima_0
    Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox1.Text = Format(Now.Date, "yyyyîNMMåéddì˙")

        'èCóùì‡óe
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

        'èCóùì‡óe
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

        'ïîïi
        TextBox18.Text = Nothing : TextBox26.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing
        TextBox24.Text = Nothing : TextBox28.Text = Nothing
        TextBox25.Text = Nothing : TextBox31.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox27.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Is = 2
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                    Case Else
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox25.Text = "ÇªÇÃëºïîïi"
                    TextBox31.Text = WK_cnt
                End If
            Next
        End If

        'ï€è·ä˙ä‘àÛéö
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
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label53 As DataDynamics.ActiveReports.Label = Nothing
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
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox44 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line23 As DataDynamics.ActiveReports.Line = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line24 As DataDynamics.ActiveReports.Line = Nothing
	Private Picture As DataDynamics.ActiveReports.Picture = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox49 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox100 As DataDynamics.ActiveReports.TextBox = Nothing
	Private fix1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private note_kbn As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line68 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Sagyou_Report_Kojima_0.rpx")
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
		Me.Label10 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Line6 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.Line)
		Me.TextBox14 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Line10 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Line)
		Me.Label8 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label51 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Line11 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Line)
		Me.TextBox30 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.Label53 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.TextBox15 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.Label5 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.Label56 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label57 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label58 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.Label59 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.Label60 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.TextBox2 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.Label61 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label62 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label63 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Line)
		Me.Label3 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.TextBox18 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.TextBox)
		Me.Line9 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Line)
		Me.Label21 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.TextBox43 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.TextBox)
		Me.TextBox44 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.TextBox)
		Me.Line23 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Line)
		Me.Label25 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Label)
		Me.Label30 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Label)
		Me.TextBox29 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.TextBox)
		Me.TextBox46 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.TextBox)
		Me.Line24 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Line)
		Me.Picture = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Picture)
		Me.TextBox7 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.TextBox)
		Me.TextBox49 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.TextBox)
		Me.TextBox100 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.TextBox)
		Me.fix1 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.TextBox)
		Me.note_kbn = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.TextBox)
		Me.Line68 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Line)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        '±ØÃﬂŸÇÃéûï\é¶
        If TextBox10.Text = "01" Then
            Picture.Visible = True
            TextBox7.Visible = True
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

        If fix1.Text <> "0" Then         'íËäzÇÃèÍçáîÒï\é¶
            TextBox26.Text = Nothing
            TextBox27.Text = Nothing
            TextBox28.Text = Nothing
            TextBox31.Text = Nothing
        End If

        Label25.Text = "èCóùå„ï€èÿÇÕåä∑ïîïiÇ…ëŒÇµÇƒìKópÇ≥ÇÍÇ‹Ç∑ÅBèCóùï€èÿä˙ä‘ÇÕèCóùäÆóπì˙Ç©ÇÁ" & StrConv(TextBox100.Text, VbStrConv.Wide) & "ì˙ä‘Ç∆Ç»Ç¡ÇƒÇ®ÇËÇ‹Ç∑ÅB"
    End Sub
End Class
