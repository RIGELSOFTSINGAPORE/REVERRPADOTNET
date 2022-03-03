Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Mitsumori_Apple
    Inherits ActiveReport
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet

    Dim DtView1 As DataView
    Dim strSQL As String
    Dim i, WK_amnt As Integer

    Public Sub New()
        MyBase.New()
        InitializeReport()

        '修理内容
        TextBox16.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox16.Text = DtView1(i)("cmnt")
                Else
                    TextBox16.Text += vbCrLf & DtView1(i)("cmnt")
                End If
            Next
        End If

        '見積内容
        TextBox17.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If i = 0 Then
                    TextBox17.Text = DtView1(i)("cmnt")
                Else
                    TextBox17.Text += vbCrLf & DtView1(i)("cmnt")
                End If
            Next
        End If

        '部品
        TextBox18.Text = Nothing : TextBox25.Text = Nothing : TextBox32.Text = Nothing : TextBox39.Text = Nothing
        TextBox19.Text = Nothing : TextBox26.Text = Nothing : TextBox33.Text = Nothing : TextBox40.Text = Nothing
        TextBox20.Text = Nothing : TextBox27.Text = Nothing : TextBox34.Text = Nothing : TextBox41.Text = Nothing
        TextBox21.Text = Nothing : TextBox28.Text = Nothing : TextBox35.Text = Nothing : TextBox42.Text = Nothing
        TextBox22.Text = Nothing : TextBox29.Text = Nothing : TextBox36.Text = Nothing : TextBox43.Text = Nothing
        'TextBox23.Text = Nothing : TextBox30.Text = Nothing : TextBox37.Text = Nothing : TextBox44.Text = Nothing
        'TextBox24.Text = Nothing : TextBox31.Text = Nothing : TextBox38.Text = Nothing : TextBox45.Text = Nothing
        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        TextBox18.Text = DtView1(i)("part_name")
                        TextBox25.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox32.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox39.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 1
                        TextBox19.Text = DtView1(i)("part_name")
                        TextBox26.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox33.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox40.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 2
                        TextBox20.Text = DtView1(i)("part_name")
                        TextBox27.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox34.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox41.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Is = 3
                        TextBox21.Text = DtView1(i)("part_name")
                        TextBox28.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox35.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox42.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        'Case Is = 4
                        '    TextBox22.Text = DtView1(i)("part_name")
                        '    TextBox29.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        '    TextBox36.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        '    TextBox43.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        'Case Is = 5
                        '    TextBox23.Text = DtView1(i)("part_name")
                        '    TextBox30.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        '    TextBox37.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        '    TextBox44.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                    Case Else
                        TextBox22.Text = DtView1(i)("part_name")
                        TextBox29.Text = "\" & Format(DtView1(i)("shop_chrg") / DtView1(i)("use_qty"), "##,##0")
                        TextBox36.Text = Format(DtView1(i)("use_qty"), "##,##0")
                        TextBox43.Text = "\" & Format(DtView1(i)("shop_chrg"), "##,##0")
                        WK_amnt = WK_amnt + DtView1(i)("shop_chrg")
                End Select

                If DtView1.Count > 7 Then
                    TextBox22.Text = "その他部品"
                    TextBox29.Text = Nothing
                    TextBox36.Text = Nothing
                    TextBox43.Text = "\" & Format(WK_amnt, "##,##0")
                End If
            Next
        End If
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private TextBox54 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox58 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox4 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox5 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox6 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox7 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox8 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox9 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox10 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox11 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox12 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox13 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox14 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox15 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox16 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox18 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox19 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox20 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox21 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox22 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox25 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox26 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox27 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox33 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox34 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox35 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox36 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox39 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox40 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox41 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox42 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox43 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox47 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox48 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox49 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox50 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox51 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox52 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox55 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Line2 As DataDynamics.ActiveReports.Line = Nothing
	Private Line3 As DataDynamics.ActiveReports.Line = Nothing
	Private Line6 As DataDynamics.ActiveReports.Line = Nothing
	Private Line7 As DataDynamics.ActiveReports.Line = Nothing
	Private Line8 As DataDynamics.ActiveReports.Line = Nothing
	Private Line9 As DataDynamics.ActiveReports.Line = Nothing
	Private Line10 As DataDynamics.ActiveReports.Line = Nothing
	Private Line11 As DataDynamics.ActiveReports.Line = Nothing
	Private Line12 As DataDynamics.ActiveReports.Line = Nothing
	Private Line13 As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox101 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox16_d As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17_d As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox17_d2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox100 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox56 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox57 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox46 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox59 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox60 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox61 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox62 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox63 As DataDynamics.ActiveReports.TextBox = Nothing
	Private store_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private arvl_cls_abbr As DataDynamics.ActiveReports.TextBox = Nothing
	Private store_code As DataDynamics.ActiveReports.TextBox = Nothing
	Private fax As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nMVAR.R_Mitsumori_Apple.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.TextBox54 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Label)
		Me.TextBox58 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.TextBox2 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.Label10 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.TextBox16 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.Label15 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.TextBox19 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.TextBox)
		Me.TextBox28 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.TextBox)
		Me.TextBox29 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.TextBox)
		Me.TextBox32 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.TextBox)
		Me.TextBox33 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.TextBox34 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.TextBox35 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.TextBox)
		Me.TextBox36 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.TextBox)
		Me.TextBox39 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.TextBox)
		Me.TextBox40 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.TextBox)
		Me.TextBox41 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.TextBox)
		Me.TextBox42 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.TextBox)
		Me.TextBox43 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.TextBox47 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.TextBox)
		Me.TextBox48 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.TextBox)
		Me.TextBox49 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.TextBox)
		Me.TextBox50 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.TextBox51 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.TextBox)
		Me.Label18 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.Label19 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Label)
		Me.TextBox52 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.Label23 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.TextBox55 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.Label25 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Line)
		Me.Line1 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.Line)
		Me.Line10 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.Line)
		Me.Line12 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.Line)
		Me.Line13 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.Line)
		Me.TextBox101 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16_d = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17_d = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17_d2 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.TextBox)
		Me.TextBox100 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.TextBox)
		Me.TextBox56 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.TextBox)
		Me.TextBox57 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.TextBox)
		Me.Label29 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.Label)
		Me.TextBox46 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.TextBox)
		Me.TextBox59 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.TextBox)
		Me.TextBox60 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.TextBox)
		Me.TextBox61 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.TextBox)
		Me.TextBox62 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.TextBox)
		Me.TextBox63 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.TextBox)
		Me.store_name = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.TextBox)
		Me.arvl_cls_abbr = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.TextBox)
		Me.store_code = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.TextBox)
		Me.fax = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        If arvl_cls_abbr.Text = "販社" Then '販社
            TextBox1.Text = store_name.Text '販社名
        Else
            TextBox1.Text = Nothing
        End If
        TextBox2.Text = TextBox60.Text & "　様"

        TextBox3.Text = Nothing 'E-mail
        If Trim(TextBox63.Text) <> "refused@apple.com" Then
            TextBox3.Text = Trim(TextBox63.Text)
        End If

		'TextBox9.Text = StrConv(Trim(TextBox61.Text.Replace(vbCrLf, "")), VbStrConv.Narrow) & " " & StrConv(Trim(TextBox62.Text), VbStrConv.Narrow) # ram 2020-12-10
		TextBox9.Text = Trim(TextBox61.Text.Replace(vbCrLf, "")) & " " & Trim(TextBox62.Text)
		TextBox10.Text = "TEL " & TextBox56.Text & "　FAX " & TextBox57.Text
        fax.Text = TextBox57.Text

        Dim wk_tel As String = Nothing
        DsList1.Clear()
        strSQL = "SELECT print_tel, print_fax FROM M08_STORE WHERE (store_code = '" & store_code.Text & "')"
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
                    fax.Text = Trim(DtView1(0)("print_fax"))
                End If
            End If
        End If
        If wk_tel <> Nothing Then
            TextBox10.Text = wk_tel
        End If

        TextBox14.Text = "発行から" & TextBox101.Text & "日"

        If Trim(TextBox16_d.Text) <> Nothing Then
            If Trim(TextBox16.Text) <> Nothing Then
                TextBox16.Text += vbCrLf & TextBox16_d.Text
            Else
                TextBox16.Text = TextBox16_d.Text
            End If
        End If

        If Trim(TextBox17_d.Text) <> Nothing Then
            If Trim(TextBox17.Text) <> Nothing Then
                TextBox17.Text += vbCrLf & TextBox17_d.Text
            Else
                TextBox17.Text = TextBox17_d.Text
            End If
        End If

        If Trim(TextBox17_d2.Text) <> Nothing Then
            If Trim(TextBox17.Text) <> Nothing Then
                TextBox17.Text += vbCrLf & TextBox17_d2.Text
            Else
                TextBox17.Text = TextBox17_d2.Text
            End If
        End If

        TextBox52.Text = "\" & Format(CInt(TextBox47.Text) + CInt(TextBox48.Text) + CInt(TextBox49.Text) + CInt(TextBox50.Text) + CInt(TextBox51.Text), "##,##0")

        Label29.Text = "\" & Format(RoundDOWN(CInt(TextBox46.Text) * (1 + CInt(TextBox59.Text) / 100), 0), "##,##0") & " ご請求させていただきます。"

        TextBox54.Text = "見積内容に記載された部品、価格は予告なく変更する場合があります。"
        TextBox54.Text += vbCrLf & "修理交換された旧部品は、弊社またはApple所有とさせていただきます。"
        TextBox54.Text += vbCrLf & "修理後保証は交換部品に対して適用されます。修理後保証期間は修理完了から" & StrConv(TextBox100.Text, VbStrConv.Wide) & "日です。"
        TextBox54.Text += vbCrLf & "※修理保証は機器障害にのみ適用され、筐体の破損やお客様過失による故障などには適用されません。"
        TextBox54.Text += vbCrLf & "プログラム、データ、ソフトウェア等の損傷や喪失については、弊社の過失の有無を問わず"
        TextBox54.Text += vbCrLf & "いかなる場合も弊社はその責任を負わないものとします。"


        TextBox54.Text += vbCrLf & "個人情報の収集、利用、提供及び登録に関して、以下の3点に同意するものとします。"
        TextBox54.Text += vbCrLf & "①修理業務を弊社から第三者に委託する場合は、お客様情報を必要な範囲で開示しますが、修理目的以外には使用されません。"
        TextBox54.Text += vbCrLf & "②お客様情報の詳細（名前や電話番号）はApple社によって提供または使用される場合があります。"
        TextBox54.Text += vbCrLf & "③上記の場合を除き、修理業務で知りえたお客様情報は、第三者に漏洩、開示いたしません。"

        TextBox55.Text = "見積有効期限内（" & TextBox.Text & "）までにご回答いただけない場合は、製品を返却させていただきます。"
        TextBox55.Text += vbCrLf & "下記に回答およびご署名いただき、FAX（" & fax.Text & "）にて返信をお願いいたします。"

        If Trim(TextBox7.Text) = Nothing Then
            Label9.Visible = False
        End If

    End Sub
End Class
