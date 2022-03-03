Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Sagyou_Report_BicGSS
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt, WK_cnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox1.Text = "日付 " & Format(Now.Date, "yyyy年MM月dd日")

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

        '見積内容
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
        TextBox18.Text = Nothing : TextBox26.Text = Nothing : TextBox7.Text = Nothing
        TextBox22.Text = Nothing : TextBox27.Text = Nothing : TextBox8.Text = Nothing
        TextBox24.Text = Nothing : TextBox28.Text = Nothing : TextBox9.Text = Nothing
        TextBox25.Text = Nothing : TextBox31.Text = Nothing : TextBox10.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox26.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox7.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox27.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox8.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox24.Text = DtView1(i)("part_name")
                        TextBox28.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox9.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox25.Text = DtView1(i)("part_name")
                        TextBox31.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox10.Text = Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_cnt = WK_cnt + DtView1(i)("use_qty")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 4 Then
                    TextBox25.Text = "その他部品"
                    TextBox31.Text = WK_cnt
                    TextBox10.Text = Format(WK_amnt, "##,##0")
                End If
            Next
        End If
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
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
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Label52 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox23 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label53 As DataDynamics.ActiveReports.Label = Nothing
	Private Label54 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
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
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
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
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox45 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line23 As DataDynamics.ActiveReports.Line = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox38 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox39 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox49 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox50 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private note_kbn As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox71 As DataDynamics.ActiveReports.TextBox = Nothing
	Private fix1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private Line68 As DataDynamics.ActiveReports.Line = Nothing
	Private rcpt_no As DataDynamics.ActiveReports.TextBox = Nothing
	Private orgnl_vndr_code As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox53 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox54 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private vndr_code As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Sagyou_Report_BicGSS.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox1 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Label13 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Label)
		Me.TextBox20 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Line)
		Me.Label = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Line6 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Line)
		Me.TextBox14 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Line10 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Line)
		Me.Label8 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.TextBox3 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.Label19 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.TextBox13 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.Label51 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Line11 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Line)
		Me.Label52 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Label)
		Me.TextBox23 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.TextBox30 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.Label53 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.Label54 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.TextBox35 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.Label5 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Label56 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label57 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.Label58 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.TextBox11 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.TextBox = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.Label59 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label60 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.TextBox2 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.TextBox)
		Me.Label61 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Label62 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.Label63 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.TextBox)
		Me.Label9 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.TextBox6 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.Line2 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Line)
		Me.Label3 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.TextBox18 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.Label21 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.TextBox43 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.TextBox)
		Me.TextBox45 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.TextBox)
		Me.Line23 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Line)
		Me.Label29 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Label)
		Me.TextBox29 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.TextBox)
		Me.Label4 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.TextBox32 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.Label2 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Line8 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Line)
		Me.TextBox7 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.TextBox)
		Me.Label12 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Label)
		Me.TextBox38 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.TextBox)
		Me.TextBox39 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.TextBox)
		Me.TextBox40 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.Label)
		Me.Line9 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.Line)
		Me.Line15 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.Line)
		Me.TextBox47 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.TextBox)
		Me.TextBox48 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.TextBox)
		Me.TextBox49 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.TextBox)
		Me.TextBox50 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.TextBox)
		Me.TextBox52 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.TextBox)
		Me.note_kbn = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.TextBox)
		Me.TextBox71 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.TextBox)
		Me.fix1 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.TextBox)
		Me.Line14 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.Line)
		Me.Line68 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.Line)
		Me.rcpt_no = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.TextBox)
		Me.orgnl_vndr_code = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.TextBox)
		Me.Label20 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.Label)
		Me.TextBox12 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.TextBox)
		Me.Label31 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.Label)
		Me.TextBox53 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.TextBox)
		Me.Label32 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.Label)
		Me.TextBox54 = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.TextBox)
		Me.Label33 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Label)
		Me.TextBox55 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.TextBox)
		Me.vndr_code = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        Select Case vndr_code.Text
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                If Mid(orgnl_vndr_code.Text, 1, 1) = "G" Or Len(Trim(orgnl_vndr_code.Text)) = 10 Then
                    TextBox21.Text = rcpt_no.Text & " (" & orgnl_vndr_code.Text & ")"
                Else
                    TextBox21.Text = rcpt_no.Text
                End If

                Label29.Text = "個人情報の収集、利用、提供及び登録に関して、以下のように取扱い致します。"
                Label29.Text += vbCrLf & "①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用されません。"
                Label29.Text += vbCrLf & "②お客様情報の詳細（名前や連絡先番号など）は、Apple社によって提供または使用される場合が ございます。"
                Label29.Text += vbCrLf & "③上記の場合は除き、修理業務で知り得たお客様の個人情報は、第三者に漏洩、開示致しません。"
            Case Else
                TextBox21.Text = rcpt_no.Text
                TextBox17.Visible = False
                Label20.Visible = False : TextBox12.Visible = False
                Label31.Visible = False : TextBox53.Visible = False
                Label32.Visible = False : TextBox54.Visible = False

                Label29.Text = "＊個人情報の収集・利用・提供及び登録に関して、以下のように取り扱います。"
                Label29.Text += vbCrLf & "　①修理作業を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理以外の目的には使用しません。"
                Label29.Text += vbCrLf & "　②上記の場合を除き、修理業務で知り得たお客様の個人情報は第三者に漏洩・開示しません。"
        End Select

        If Trim(TextBox47.Text) <> Nothing Then
            If Trim(TextBox19.Text) <> Nothing Then
                TextBox19.Text = TextBox19.Text & System.Environment.NewLine & TextBox47.Text
            Else
                TextBox19.Text = TextBox47.Text
            End If
        End If

        If Trim(TextBox48.Text) <> Nothing Then
            If Trim(TextBox5.Text) <> Nothing Then
                TextBox5.Text = TextBox5.Text & System.Environment.NewLine & TextBox48.Text
            Else
                TextBox5.Text = TextBox48.Text
            End If
        End If

        If Trim(TextBox49.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox49.Text
            Else
                TextBox6.Text = TextBox49.Text
            End If
        End If

        If Trim(TextBox71.Text) <> Nothing Then
            If Trim(TextBox6.Text) <> Nothing Then
                TextBox6.Text = TextBox6.Text & System.Environment.NewLine & TextBox71.Text
            Else
                TextBox6.Text = TextBox71.Text
            End If
        End If

        If fix1.Text <> "0" Then         '定額の場合非表示
            TextBox26.Text = Nothing : TextBox7.Text = Nothing
            TextBox27.Text = Nothing : TextBox8.Text = Nothing
            TextBox28.Text = Nothing : TextBox9.Text = Nothing
            TextBox31.Text = Nothing : TextBox10.Text = Nothing
            Label12.Visible = False : Label15.Visible = False : TextBox38.Visible = False : TextBox39.Visible = False
        End If

        TextBox39.Text = "\" & Format(CInt(TextBox50.Text) + CInt(TextBox51.Text) + CInt(TextBox52.Text), "##,##0")
        TextBox42.Text = "\" & Format(CInt(TextBox40.Text) + CInt(TextBox41.Text), "##,##0")

    End Sub
End Class
