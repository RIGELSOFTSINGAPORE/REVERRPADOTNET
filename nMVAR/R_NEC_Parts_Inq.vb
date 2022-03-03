Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_NEC_Parts_Inq
Inherits ActiveReport

    Dim DtView1 As DataView
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        TextBox32.Text = Format(P_HSTY_DATE, "yyyy/MM/dd")

        'àÀóäé“èÓïÒ
        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            TextBox50.Text = DtView1(0)("brch_name")
            TextBox51.Text = DtView1(0)("comp_name")
            TextBox52.Text = DtView1(0)("name")
            TextBox53.Text = DtView1(0)("adrs1")
            TextBox54.Text = DtView1(0)("adrs2")
            TextBox55.Text = DtView1(0)("tel")
            TextBox56.Text = DtView1(0)("fax")
        Else
            TextBox50.Text = Nothing
            TextBox51.Text = Nothing
            TextBox52.Text = Nothing
            TextBox53.Text = Nothing
            TextBox54.Text = Nothing
            TextBox55.Text = Nothing
            TextBox56.Text = Nothing
        End If

        'èCóùì‡óe
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox20.Text = DtView1(i)("cmnt")
                Else
                    TextBox20.Text = TextBox20.Text & System.Environment.NewLine & DtView1(i)("cmnt")
                End If
            Next
        End If

        'ïîïi
        TextBox61.Text = Nothing : TextBox71.Text = Nothing : TextBox81.Text = Nothing
        TextBox62.Text = Nothing : TextBox72.Text = Nothing : TextBox82.Text = Nothing
        TextBox63.Text = Nothing : TextBox73.Text = Nothing : TextBox83.Text = Nothing
        TextBox64.Text = Nothing : TextBox74.Text = Nothing : TextBox84.Text = Nothing
        TextBox65.Text = Nothing : TextBox75.Text = Nothing : TextBox85.Text = Nothing
        DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Dim pos As Integer
            pos = (P_page - 1) * 5
            For i = pos To DtView1.Count - 1
                Select Case i
                    Case Is = pos + 0
                        TextBox61.Text = DtView1(i)("part_code")
                        TextBox71.Text = DtView1(i)("part_name")
                        TextBox81.Text = DtView1(i)("use_qty")
                    Case Is = pos + 1
                        TextBox62.Text = DtView1(i)("part_code")
                        TextBox72.Text = DtView1(i)("part_name")
                        TextBox82.Text = DtView1(i)("use_qty")
                    Case Is = pos + 2
                        TextBox63.Text = DtView1(i)("part_code")
                        TextBox73.Text = DtView1(i)("part_name")
                        TextBox83.Text = DtView1(i)("use_qty")
                    Case Is = pos + 3
                        TextBox64.Text = DtView1(i)("part_code")
                        TextBox74.Text = DtView1(i)("part_name")
                        TextBox84.Text = DtView1(i)("use_qty")
                    Case Is = pos + 4
                        TextBox65.Text = DtView1(i)("part_code")
                        TextBox75.Text = DtView1(i)("part_name")
                        TextBox85.Text = DtView1(i)("use_qty")
                    Case Else
                        Exit For
                End Select
            Next
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox53 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox54 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox50 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox56 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Private Label39 As DataDynamics.ActiveReports.Label = Nothing
	Private Label40 As DataDynamics.ActiveReports.Label = Nothing
	Private Label41 As DataDynamics.ActiveReports.Label = Nothing
	Private Label42 As DataDynamics.ActiveReports.Label = Nothing
	Private Label43 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox71 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox72 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox73 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox74 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox75 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox61 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox62 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox63 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox64 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox65 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox81 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox82 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox83 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox84 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox85 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line15 As DataDynamics.ActiveReports.Line = Nothing
	Private Line16 As DataDynamics.ActiveReports.Line = Nothing
	Private Line17 As DataDynamics.ActiveReports.Line = Nothing
	Private Line18 As DataDynamics.ActiveReports.Line = Nothing
	Private Line19 As DataDynamics.ActiveReports.Line = Nothing
	Private Line26 As DataDynamics.ActiveReports.Line = Nothing
	Private Line27 As DataDynamics.ActiveReports.Line = Nothing
	Private Line28 As DataDynamics.ActiveReports.Line = Nothing
	Private Line29 As DataDynamics.ActiveReports.Line = Nothing
	Private Line31 As DataDynamics.ActiveReports.Line = Nothing
	Private Label45 As DataDynamics.ActiveReports.Label = Nothing
	Private Label46 As DataDynamics.ActiveReports.Label = Nothing
	Private Line35 As DataDynamics.ActiveReports.Line = Nothing
	Private Line20 As DataDynamics.ActiveReports.Line = Nothing
	Private Line36 As DataDynamics.ActiveReports.Line = Nothing
	Private Line37 As DataDynamics.ActiveReports.Line = Nothing
	Private Line38 As DataDynamics.ActiveReports.Line = Nothing
	Private Line39 As DataDynamics.ActiveReports.Line = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line4 As DataDynamics.ActiveReports.Line = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line5 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private Line14 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox100 As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_NEC_Parts_Inq.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label51 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.TextBox5 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Label8 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label19 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.TextBox53 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TextBox54 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.TextBox50 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.TextBox56 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.Label22 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.TextBox52 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Label34 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label39 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label40 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label41 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Label42 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Label)
		Me.Label43 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Label)
		Me.TextBox71 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.TextBox72 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.TextBox73 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.TextBox74 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.TextBox75 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.TextBox61 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.TextBox62 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.TextBox63 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.TextBox)
		Me.TextBox64 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.TextBox)
		Me.TextBox65 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.TextBox)
		Me.TextBox81 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.TextBox82 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.TextBox83 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.TextBox84 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.TextBox85 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.TextBox)
		Me.Line15 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Line)
		Me.Line16 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Line)
		Me.Line17 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Line)
		Me.Line18 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Line)
		Me.Line19 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Line)
		Me.Line26 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Line)
		Me.Line27 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Line)
		Me.Line28 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Line)
		Me.Line29 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Line)
		Me.Line31 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Line)
		Me.Label45 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label46 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Line35 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Line)
		Me.Line20 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Line)
		Me.Line36 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Line)
		Me.Line37 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Line)
		Me.Line38 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Line)
		Me.Line39 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Line)
		Me.Label = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Label)
		Me.TextBox32 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.Label5 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.TextBox55 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.TextBox)
		Me.Line = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Line)
		Me.Label6 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Label)
		Me.TextBox34 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Label)
		Me.TextBox4 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.TextBox)
		Me.Label7 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.TextBox)
		Me.Label21 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Label)
		Me.TextBox20 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.TextBox)
		Me.Line1 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Line)
		Me.Label26 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.Label)
		Me.Line6 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.Line)
		Me.Label27 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.Label)
		Me.Line9 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.Line)
		Me.Line14 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.Line)
		Me.TextBox100 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Trim(TextBox100.Text) <> Nothing Then TextBox20.Text = TextBox20.Text & System.Environment.NewLine & TextBox100.Text
    End Sub
End Class
