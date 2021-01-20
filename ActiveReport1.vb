Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ActiveReport1

    Inherits ActiveReport
    Public FM As Print1
    Public Sub New()
        MyBase.New()
        InitializeReport()
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As DataDynamics.ActiveReports.PageHeader = Nothing
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
    Private WithEvents PageFooter As DataDynamics.ActiveReports.PageFooter = Nothing
	Private Shape3 As DataDynamics.ActiveReports.Shape = Nothing
	Private Line1 As DataDynamics.ActiveReports.Line = Nothing
	Private Shape23 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape18 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape17 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape16 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape15 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape14 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape11 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape10 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape7 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape6 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape5 As DataDynamics.ActiveReports.Shape = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private TextBox32 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label48 As DataDynamics.ActiveReports.Label = Nothing
	Private Label47 As DataDynamics.ActiveReports.Label = Nothing
	Private Label46 As DataDynamics.ActiveReports.Label = Nothing
	Private Label45 As DataDynamics.ActiveReports.Label = Nothing
	Private Label44 As DataDynamics.ActiveReports.Label = Nothing
	Private Label43 As DataDynamics.ActiveReports.Label = Nothing
	Private Label42 As DataDynamics.ActiveReports.Label = Nothing
	Private Label41 As DataDynamics.ActiveReports.Label = Nothing
	Private Label40 As DataDynamics.ActiveReports.Label = Nothing
	Private Label39 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Private Label37 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Label35 As DataDynamics.ActiveReports.Label = Nothing
	Private Label34 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private Label32 As DataDynamics.ActiveReports.Label = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Shape2 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape8 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape9 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape12 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape13 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape19 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape20 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape21 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape28 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape22 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape24 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape25 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape27 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape26 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape4 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape1 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape As DataDynamics.ActiveReports.Shape = Nothing
	Private TextBox2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox3 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Barcode1 As DataDynamics.ActiveReports.Barcode = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox28 As DataDynamics.ActiveReports.TextBox = Nothing
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
	Private TextBox29 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox30 As DataDynamics.ActiveReports.TextBox = Nothing
	Private TextBox31 As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private Label51 As DataDynamics.ActiveReports.Label = Nothing
	Private Label52 As DataDynamics.ActiveReports.Label = Nothing
	Private Label53 As DataDynamics.ActiveReports.Label = Nothing
	Private TextBox As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label54 As DataDynamics.ActiveReports.Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "WRNDB.ActiveReport1.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Shape3 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Shape)
		Me.Line1 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Line)
		Me.Shape23 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Shape)
		Me.Shape18 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Shape)
		Me.Shape17 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Shape)
		Me.Shape16 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Shape)
		Me.Shape15 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Shape)
		Me.Shape14 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Shape)
		Me.Shape11 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Shape)
		Me.Shape10 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Shape)
		Me.Shape7 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Shape)
		Me.Shape6 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.Shape)
		Me.Shape5 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.Shape)
		Me.Line = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.Line)
		Me.TextBox32 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Label49 = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label48 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label47 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label46 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label45 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label44 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Label43 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.Label)
		Me.Label42 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.Label)
		Me.Label41 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.Label)
		Me.Label40 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.Label)
		Me.Label39 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.Label37 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label35 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label34 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label32 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.Label31 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.Label30 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Label)
		Me.Label19 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Label)
		Me.Shape2 = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Shape)
		Me.Shape8 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Shape)
		Me.Shape9 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Shape)
		Me.Shape12 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Shape)
		Me.Shape13 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Shape)
		Me.Shape19 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Shape)
		Me.Shape20 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Shape)
		Me.Shape21 = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.Shape)
		Me.Shape28 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Shape)
		Me.Shape22 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Shape)
		Me.Shape24 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Shape)
		Me.Shape25 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Shape)
		Me.Shape27 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Shape)
		Me.Shape26 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Shape)
		Me.Shape4 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Shape)
		Me.Shape1 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Shape)
		Me.Shape = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Shape)
		Me.TextBox2 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.TextBox)
		Me.TextBox3 = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.TextBox)
		Me.Barcode1 = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.Barcode)
		Me.Label3 = CType(Me.Detail.Controls(81),DataDynamics.ActiveReports.Label)
		Me.TextBox1 = CType(Me.Detail.Controls(82),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(83),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(84),DataDynamics.ActiveReports.Label)
		Me.TextBox28 = CType(Me.Detail.Controls(85),DataDynamics.ActiveReports.TextBox)
		Me.TextBox4 = CType(Me.Detail.Controls(86),DataDynamics.ActiveReports.TextBox)
		Me.TextBox5 = CType(Me.Detail.Controls(87),DataDynamics.ActiveReports.TextBox)
		Me.TextBox6 = CType(Me.Detail.Controls(88),DataDynamics.ActiveReports.TextBox)
		Me.TextBox7 = CType(Me.Detail.Controls(89),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(90),DataDynamics.ActiveReports.TextBox)
		Me.TextBox9 = CType(Me.Detail.Controls(91),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(92),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(93),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(94),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(95),DataDynamics.ActiveReports.TextBox)
		Me.TextBox14 = CType(Me.Detail.Controls(96),DataDynamics.ActiveReports.TextBox)
		Me.TextBox15 = CType(Me.Detail.Controls(97),DataDynamics.ActiveReports.TextBox)
		Me.TextBox16 = CType(Me.Detail.Controls(98),DataDynamics.ActiveReports.TextBox)
		Me.TextBox17 = CType(Me.Detail.Controls(99),DataDynamics.ActiveReports.TextBox)
		Me.TextBox18 = CType(Me.Detail.Controls(100),DataDynamics.ActiveReports.TextBox)
		Me.TextBox19 = CType(Me.Detail.Controls(101),DataDynamics.ActiveReports.TextBox)
		Me.TextBox20 = CType(Me.Detail.Controls(102),DataDynamics.ActiveReports.TextBox)
		Me.TextBox21 = CType(Me.Detail.Controls(103),DataDynamics.ActiveReports.TextBox)
		Me.TextBox22 = CType(Me.Detail.Controls(104),DataDynamics.ActiveReports.TextBox)
		Me.TextBox23 = CType(Me.Detail.Controls(105),DataDynamics.ActiveReports.TextBox)
		Me.TextBox24 = CType(Me.Detail.Controls(106),DataDynamics.ActiveReports.TextBox)
		Me.TextBox25 = CType(Me.Detail.Controls(107),DataDynamics.ActiveReports.TextBox)
		Me.TextBox26 = CType(Me.Detail.Controls(108),DataDynamics.ActiveReports.TextBox)
		Me.TextBox27 = CType(Me.Detail.Controls(109),DataDynamics.ActiveReports.TextBox)
		Me.TextBox29 = CType(Me.Detail.Controls(110),DataDynamics.ActiveReports.TextBox)
		Me.TextBox30 = CType(Me.Detail.Controls(111),DataDynamics.ActiveReports.TextBox)
		Me.TextBox31 = CType(Me.Detail.Controls(112),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(113),DataDynamics.ActiveReports.Label)
		Me.Label50 = CType(Me.Detail.Controls(114),DataDynamics.ActiveReports.Label)
		Me.Label51 = CType(Me.Detail.Controls(115),DataDynamics.ActiveReports.Label)
		Me.Label52 = CType(Me.Detail.Controls(116),DataDynamics.ActiveReports.Label)
		Me.Label53 = CType(Me.Detail.Controls(117),DataDynamics.ActiveReports.Label)
		Me.TextBox = CType(Me.Detail.Controls(118),DataDynamics.ActiveReports.TextBox)
		Me.Label54 = CType(Me.Detail.Controls(119),DataDynamics.ActiveReports.Label)
	End Sub

#End Region

    Dim i As Integer = 0

    Private Sub ActiveReport1_FetchData(ByVal sender As Object, ByVal sArgs As DataDynamics.ActiveReports.ActiveReport.FetchEventArgs) Handles MyBase.FetchData
        On Error GoTo err

        If i > P_DtView1.Count - 1 Then
            sArgs.EOF = True
            Exit Sub
        End If

        If P_DtView1(i)("LEAVE") = "1" Then     'à¯éÊ
            TextBox1.Text = "ïüéRí â^äîéÆâÔé–Å@éså¥éxìX å‰íÜ"
            TextBox2.Text = "ÉrÉbÉNí∑ä˙ï€èÿ / à¯éÊèCóùéÛïtï[Åyírë‹ï™Åz"
            Label1.Visible = False
            Label2.Visible = False
            Label35.Visible = False
            TextBox30.Visible = False
            Shape23.Visible = False
            Label36.Visible = False
            Label37.Visible = False
            Label38.Visible = False
            Label39.Visible = False
            Label40.Visible = False
            Label41.Visible = False
            Label42.Visible = False
            Label43.Visible = False
            Label.Visible = True
            Label50.Visible = True
            Label51.Visible = True
            Label52.Visible = True
            Label53.Visible = True
            Label54.Visible = True
        Else                                    'èoí£
            TextBox1.Text = RTrim(P_DtView1(i)("MKR_NAME")) & " å‰íÜ èCóùéÛïtÇ≤íSìñé“à∂Çƒ"
            TextBox2.Text = "ÉrÉbÉNí∑ä˙ï€èÿ / èoí£èCóùéÊéüèëÅyírë‹ï™Åz"
            Label1.Visible = True
            Label2.Visible = True
            Label35.Visible = True
            TextBox30.Visible = True
            Shape23.Visible = True
            Label36.Visible = True
            Label37.Visible = True
            Label38.Visible = True
            Label39.Visible = True
            Label40.Visible = True
            Label41.Visible = True
            Label42.Visible = True
            Label43.Visible = True
            Label.Visible = False
            Label50.Visible = False
            Label51.Visible = False
            Label52.Visible = False
            Label53.Visible = False
            Label54.Visible = False
        End If
        Barcode1.Text = P_DtView1(i)("REPAIR_CODE_BCD")
        TextBox3.Text = P_DtView1(i)("REPAIR_CODE_BCD")
        TextBox4.Text = P_DtView1(i)("REPAIR_CODE")
        TextBox5.Text = P_DtView1(i)("REPAIR_DATE")
        TextBox6.Text = P_DtView1(i)("WRN_NO")
        TextBox7.Text = P_DtView1(i)("CUST_NAME_KANA")
        TextBox8.Text = P_DtView1(i)("CUST_NAME")
        TextBox9.Text = P_DtView1(i)("TEL_NO")
        TextBox10.Text = P_DtView1(i)("CNT_NO")
        TextBox11.Text = P_DtView1(i)("CALL_TIME")
        TextBox12.Text = P_DtView1(i)("ZIP")
        TextBox13.Text = P_DtView1(i)("ADRS1")
        TextBox14.Text = P_DtView1(i)("ADRS2")
        TextBox15.Text = P_DtView1(i)("HOPE_DATE1") & " (" & Mid(WeekdayName(Weekday(P_DtView1(i)("HOPE_DATE1"))), 1, 1) & ")"
        TextBox16.Text = P_DtView1(i)("TIME1")
        If Not IsDBNull(P_DtView1(i)("HOPE_DATE2")) Then
            TextBox17.Text = P_DtView1(i)("HOPE_DATE2") & " (" & Mid(WeekdayName(Weekday(P_DtView1(i)("HOPE_DATE2"))), 1, 1) & ")"
        Else
            TextBox17.Text = Nothing
        End If
        If Not IsDBNull(P_DtView1(i)("TIME2")) Then
            TextBox18.Text = P_DtView1(i)("TIME2")
        Else
            TextBox18.Text = Nothing
        End If
        TextBox19.Text = P_DtView1(i)("MKR_NAME")
        TextBox20.Text = P_DtView1(i)("CAT_NAME")
        TextBox21.Text = P_DtView1(i)("MODEL")
        TextBox22.Text = P_DtView1(i)("WRN_DATE")
        TextBox23.Text = P_DtView1(i)("WRN_PERIOD")
        TextBox24.Text = "Åè" & Format(CInt(P_DtView1(i)("PRICE")), "##,##0")
        If P_DtView1(i)("MAX_PRICE") = "None" Then
            TextBox25.Text = P_DtView1(i)("MAX_PRICE")
        Else
            TextBox25.Text = "Åè" & Format(CInt(P_DtView1(i)("MAX_PRICE")), "##,##0")
        End If
        TextBox26.Text = P_DtView1(i)("SHOP")
        TextBox27.Text = P_DtView1(i)("SYMPTOM")
        TextBox28.Text = P_DtView1(i)("CUSTODY")
        If P_DtView1(i)("BOX") = "1" Then     'ç´ïÔî†
            TextBox29.Text = "óv"
        Else
            TextBox29.Text = "-"
        End If
        TextBox30.Text = "-"
        TextBox31.Text = P_DtView1(i)("DEMAND")
        TextBox32.Text = P_DtView1(i)("EMPL_NAME")
        Dim now_date As Date
        now_date = Now
        TextBox.Text = Format(now_date, "yyyy/M/d h:m")
        If Format(now_date, "tt") = "åﬂëO" Then
            TextBox.Text = TextBox.Text & " AM"
        Else
            TextBox.Text = TextBox.Text & " PM"
        End If

        sArgs.EOF = False
        i += 1
        Exit Sub

err:
        MessageBox.Show(Err.Description, "Error")
    End Sub

End Class
