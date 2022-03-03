Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class R_Kanyu_Normal
    Inherits ActiveReport

    Dim WK_prt_date As Date
    Dim WK_str As String

    Public Sub New()
        MyBase.New()
        InitializeReport()

        Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP", True)
        Culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
        WK_prt_date = Now.Date
        'prt_date.Text = "証書発行日　：　" & WK_prt_date.ToString("ggyy年M月d日", Culture)
        prt_date.Text = "証書発行日　：　" & WK_prt_date

        Label15.Text = "QG-Careは、対象となるパソコンが故障などで動かなくなった場合にプロの技術者が診断して、修理するサービスです。"
        Label15.Text += System.Environment.NewLine
        Label15.Text += "サービスを受ける際には、以下および裏面をよくお読みください。"



    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As DataDynamics.ActiveReports.Detail = Nothing
	Private Label35 As DataDynamics.ActiveReports.Label = Nothing
	Private Label33 As DataDynamics.ActiveReports.Label = Nothing
	Private Picture1 As DataDynamics.ActiveReports.Picture = Nothing
	Private Picture2 As DataDynamics.ActiveReports.Picture = Nothing
	Private Shape7 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape3 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape2 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape1 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape5 As DataDynamics.ActiveReports.Shape = Nothing
	Private Shape4 As DataDynamics.ActiveReports.Shape = Nothing
	Private code As DataDynamics.ActiveReports.TextBox = Nothing
	Private zip As DataDynamics.ActiveReports.TextBox = Nothing
	Private adrs1 As DataDynamics.ActiveReports.TextBox = Nothing
	Private adrs2 As DataDynamics.ActiveReports.TextBox = Nothing
	Private user_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private tel As DataDynamics.ActiveReports.TextBox = Nothing
	Private shop_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private makr_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private modl_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private s_no As DataDynamics.ActiveReports.TextBox = Nothing
	Private prch_amnt As DataDynamics.ActiveReports.TextBox = Nothing
	Private wrn_tem_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private wrn_range_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private makr_wrn_stat As DataDynamics.ActiveReports.TextBox = Nothing
	Private prt_date As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label As DataDynamics.ActiveReports.Label = Nothing
	Private Label1 As DataDynamics.ActiveReports.Label = Nothing
	Private Label2 As DataDynamics.ActiveReports.Label = Nothing
	Private Label3 As DataDynamics.ActiveReports.Label = Nothing
	Private Label4 As DataDynamics.ActiveReports.Label = Nothing
	Private Label5 As DataDynamics.ActiveReports.Label = Nothing
	Private Label6 As DataDynamics.ActiveReports.Label = Nothing
	Private Label7 As DataDynamics.ActiveReports.Label = Nothing
	Private Label8 As DataDynamics.ActiveReports.Label = Nothing
	Private Label9 As DataDynamics.ActiveReports.Label = Nothing
	Private Label10 As DataDynamics.ActiveReports.Label = Nothing
	Private Label11 As DataDynamics.ActiveReports.Label = Nothing
	Private Label12 As DataDynamics.ActiveReports.Label = Nothing
	Private Label13 As DataDynamics.ActiveReports.Label = Nothing
	Private Label14 As DataDynamics.ActiveReports.Label = Nothing
	Private Label15 As DataDynamics.ActiveReports.Label = Nothing
	Private Label16 As DataDynamics.ActiveReports.Label = Nothing
	Private Label17 As DataDynamics.ActiveReports.Label = Nothing
	Private Label18 As DataDynamics.ActiveReports.Label = Nothing
	Private Label19 As DataDynamics.ActiveReports.Label = Nothing
	Private Label20 As DataDynamics.ActiveReports.Label = Nothing
	Private Label21 As DataDynamics.ActiveReports.Label = Nothing
	Private Label22 As DataDynamics.ActiveReports.Label = Nothing
	Private Label23 As DataDynamics.ActiveReports.Label = Nothing
	Private Label24 As DataDynamics.ActiveReports.Label = Nothing
	Private Label25 As DataDynamics.ActiveReports.Label = Nothing
	Private Label26 As DataDynamics.ActiveReports.Label = Nothing
	Private Label27 As DataDynamics.ActiveReports.Label = Nothing
	Private Label28 As DataDynamics.ActiveReports.Label = Nothing
	Private Label29 As DataDynamics.ActiveReports.Label = Nothing
	Private Label30 As DataDynamics.ActiveReports.Label = Nothing
	Private Label31 As DataDynamics.ActiveReports.Label = Nothing
	Private Label36 As DataDynamics.ActiveReports.Label = Nothing
	Private Label37 As DataDynamics.ActiveReports.Label = Nothing
	Private Label38 As DataDynamics.ActiveReports.Label = Nothing
	Private Line As DataDynamics.ActiveReports.Line = Nothing
	Private Label39 As DataDynamics.ActiveReports.Label = Nothing
	Private Label40 As DataDynamics.ActiveReports.Label = Nothing
	Private Label41 As DataDynamics.ActiveReports.Label = Nothing
	Private Label42 As DataDynamics.ActiveReports.Label = Nothing
	Private Label43 As DataDynamics.ActiveReports.Label = Nothing
	Private Label44 As DataDynamics.ActiveReports.Label = Nothing
	Private univ_name As DataDynamics.ActiveReports.TextBox = Nothing
	Private Label45 As DataDynamics.ActiveReports.Label = Nothing
	Private Label46 As DataDynamics.ActiveReports.Label = Nothing
	Private Label47 As DataDynamics.ActiveReports.Label = Nothing
	Private Label48 As DataDynamics.ActiveReports.Label = Nothing
	Private Label49 As DataDynamics.ActiveReports.Label = Nothing
	Private Label50 As DataDynamics.ActiveReports.Label = Nothing
	Private Picture4 As DataDynamics.ActiveReports.Picture = Nothing
	Private Picture3 As DataDynamics.ActiveReports.Picture = Nothing
	Private Shape6 As DataDynamics.ActiveReports.Shape = Nothing
	Private Picture5 As DataDynamics.ActiveReports.Picture = Nothing
	Private Picture As DataDynamics.ActiveReports.Picture = Nothing
	Private wrn_range As DataDynamics.ActiveReports.TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "nQGCare.R_Kanyu_Normal.rpx")
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.Label35 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Label33 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Picture1 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.Picture)
		Me.Picture2 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.Picture)
		Me.Shape7 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.Shape)
		Me.Shape = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.Shape)
		Me.Shape3 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.Shape)
		Me.Shape2 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.Shape)
		Me.Shape1 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.Shape)
		Me.Shape5 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.Shape)
		Me.Shape4 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.Shape)
		Me.code = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.zip = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.adrs1 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.adrs2 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.user_name = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.tel = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.TextBox)
		Me.shop_name = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.makr_name = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.modl_name = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.s_no = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.prch_amnt = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.wrn_tem_name = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.wrn_range_name = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.makr_wrn_stat = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.prt_date = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.Label = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.Detail.Controls(27),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.Detail.Controls(28),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.Detail.Controls(29),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.Detail.Controls(30),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.Detail.Controls(31),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.Detail.Controls(32),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.Detail.Controls(33),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.Detail.Controls(34),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.Detail.Controls(35),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.Detail.Controls(36),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.Detail.Controls(37),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.Detail.Controls(38),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.Detail.Controls(39),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.Detail.Controls(40),DataDynamics.ActiveReports.Label)
		Me.Label15 = CType(Me.Detail.Controls(41),DataDynamics.ActiveReports.Label)
		Me.Label16 = CType(Me.Detail.Controls(42),DataDynamics.ActiveReports.Label)
		Me.Label17 = CType(Me.Detail.Controls(43),DataDynamics.ActiveReports.Label)
		Me.Label18 = CType(Me.Detail.Controls(44),DataDynamics.ActiveReports.Label)
		Me.Label19 = CType(Me.Detail.Controls(45),DataDynamics.ActiveReports.Label)
		Me.Label20 = CType(Me.Detail.Controls(46),DataDynamics.ActiveReports.Label)
		Me.Label21 = CType(Me.Detail.Controls(47),DataDynamics.ActiveReports.Label)
		Me.Label22 = CType(Me.Detail.Controls(48),DataDynamics.ActiveReports.Label)
		Me.Label23 = CType(Me.Detail.Controls(49),DataDynamics.ActiveReports.Label)
		Me.Label24 = CType(Me.Detail.Controls(50),DataDynamics.ActiveReports.Label)
		Me.Label25 = CType(Me.Detail.Controls(51),DataDynamics.ActiveReports.Label)
		Me.Label26 = CType(Me.Detail.Controls(52),DataDynamics.ActiveReports.Label)
		Me.Label27 = CType(Me.Detail.Controls(53),DataDynamics.ActiveReports.Label)
		Me.Label28 = CType(Me.Detail.Controls(54),DataDynamics.ActiveReports.Label)
		Me.Label29 = CType(Me.Detail.Controls(55),DataDynamics.ActiveReports.Label)
		Me.Label30 = CType(Me.Detail.Controls(56),DataDynamics.ActiveReports.Label)
		Me.Label31 = CType(Me.Detail.Controls(57),DataDynamics.ActiveReports.Label)
		Me.Label36 = CType(Me.Detail.Controls(58),DataDynamics.ActiveReports.Label)
		Me.Label37 = CType(Me.Detail.Controls(59),DataDynamics.ActiveReports.Label)
		Me.Label38 = CType(Me.Detail.Controls(60),DataDynamics.ActiveReports.Label)
		Me.Line = CType(Me.Detail.Controls(61),DataDynamics.ActiveReports.Line)
		Me.Label39 = CType(Me.Detail.Controls(62),DataDynamics.ActiveReports.Label)
		Me.Label40 = CType(Me.Detail.Controls(63),DataDynamics.ActiveReports.Label)
		Me.Label41 = CType(Me.Detail.Controls(64),DataDynamics.ActiveReports.Label)
		Me.Label42 = CType(Me.Detail.Controls(65),DataDynamics.ActiveReports.Label)
		Me.Label43 = CType(Me.Detail.Controls(66),DataDynamics.ActiveReports.Label)
		Me.Label44 = CType(Me.Detail.Controls(67),DataDynamics.ActiveReports.Label)
		Me.univ_name = CType(Me.Detail.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.Label45 = CType(Me.Detail.Controls(69),DataDynamics.ActiveReports.Label)
		Me.Label46 = CType(Me.Detail.Controls(70),DataDynamics.ActiveReports.Label)
		Me.Label47 = CType(Me.Detail.Controls(71),DataDynamics.ActiveReports.Label)
		Me.Label48 = CType(Me.Detail.Controls(72),DataDynamics.ActiveReports.Label)
		Me.Label49 = CType(Me.Detail.Controls(73),DataDynamics.ActiveReports.Label)
		Me.Label50 = CType(Me.Detail.Controls(74),DataDynamics.ActiveReports.Label)
		Me.Picture4 = CType(Me.Detail.Controls(75),DataDynamics.ActiveReports.Picture)
		Me.Picture3 = CType(Me.Detail.Controls(76),DataDynamics.ActiveReports.Picture)
		Me.Shape6 = CType(Me.Detail.Controls(77),DataDynamics.ActiveReports.Shape)
		Me.Picture5 = CType(Me.Detail.Controls(78),DataDynamics.ActiveReports.Picture)
		Me.Picture = CType(Me.Detail.Controls(79),DataDynamics.ActiveReports.Picture)
		Me.wrn_range = CType(Me.Detail.Controls(80),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Label.Text = "本証書はサービスの内容を記載したものですので、大切に保管してください。"
        Else                                                                    '一般、通常
            Label.Text = "お客様が購入された下記の対象PCには、以下のサービスが無償で付帯されています。"
            Label.Text += System.Environment.NewLine
            Label.Text += "本証書はサービスの内容を記載したものですので、大切に保管してください。"
        End If

        WK_str = Trim(shop_name.Text)
        WK_str = WK_str.Replace("　", System.Environment.NewLine)
        WK_str = WK_str.Replace(" ", System.Environment.NewLine)
        If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then       '一般
            Label45.Text = WK_str
            Label45.Text += System.Environment.NewLine & univ_name.Text
        Else
            Label45.Text = WK_str
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Label46.Visible = True      'GSSコールセンター
        Else
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '一般
                Label46.Visible = True  'GSSコールセンター
            Else                                                                '通常
                Label46.Visible = False
            End If
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Label16.Text = "保証範囲内の障害が発生した場合はQG-Care障害相談窓口に"
            Label42.Text = "お電話ください。"
        Else                                                                    '一般、通常
            Label16.Text = "対象PCに障害が発生した場合は、まずQG-Careサービス窓口"
            Label42.Text = "にお電話ください。"
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Label21.Text = "★"
            Label16.Text = "保証範囲内の障害が発生した場合はQG-Care障害相談窓口に"
            Label42.Text = "お電話ください。"
        Else                                                                    '一般、通常
            Label21.Text = "①"
            Label16.Text = "対象PCに障害が発生した場合は、まずQG-Careサービス窓口"
            Label42.Text = "にお電話ください。"
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Label22.Text = "★"
            Label19.Text = "修理費用を限度額まで保証"
            Label47.Visible = True : Label48.Visible = True
            Shape5.Visible = False : Shape7.Visible = True
            Label24.Text = "※＜年間補償限度額＞1年目15万円2年目12万円3年目10万円"
            Label24.Text += System.Environment.NewLine & "　　　　　　　　　　　　　　　4年目6万円（税込）を保証"
            Label24.Text += System.Environment.NewLine & "　　　　　　注）上記金額と保証対象パソコン購入金額の"
            Label24.Text += System.Environment.NewLine & "    　　　　　　いずれか低い金額が保証限度額となります。"
            Label24.Text += System.Environment.NewLine & "※GSS指定業者での修理のみとなります。"
            Label25.Visible = False
        Else                                                                    '一般、通常
            Label22.Text = "②"
            Label19.Text = "通常故障はメーカー保証が受けられます"
            Label47.Visible = False : Label48.Visible = False
            Shape5.Visible = True : Shape7.Visible = False
            Label24.Text = "※詳細はPCに同梱されている保証書をご覧ください。"
            Label25.Visible = True
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Shape6.Visible = False : Label23.Visible = False : Label20.Visible = False
            Label43.Visible = False : Label27.Visible = False : Label44.Visible = False
            Label26.Visible = False : Label28.Visible = False : Label29.Visible = False
            Label30.Visible = False : Label31.Visible = False
        Else                                                                    '一般、通常
            Shape6.Visible = True : Label23.Visible = True : Label20.Visible = True
            Label43.Visible = True : Label27.Visible = True : Label44.Visible = True
            Label26.Visible = True : Label28.Visible = True : Label29.Visible = True
            Label30.Visible = True : Label31.Visible = True
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '一般
                Label30.Text = "※指定の業者での修理のみとなります。"
            Else                                                                '通常
                Label30.Text = "※大学生協連合会指定の業者での修理のみとなります。"
            End If
        End If

        If wrn_range.Text = "2" Then
            Label26.Text = "※＜年間補償限度額＞については、裏面をご確認ください。"
            Label28.Text = "※破損･水濡れの場合は保証期間中1回目は５，０００円"
            Label29.Text = "　2回目以降は１０,０００円の自己負担が必要です。"
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Picture1.Visible = False : Picture2.Visible = False
            Picture3.Visible = True : Picture4.Visible = True
            Label33.Visible = True : Label41.Visible = False
            Label35.Visible = True
            Label49.Visible = False : Label50.Visible = False

            Label33.Text = "×対象パソコンの現物が確認出来ない損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×噴火、地震などの自然災害による損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×紛失、置忘れ、詐欺、横領による損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×加入者の故意及び重過失による損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×虫食い鼠食い、性質および環境による錆カビ変質変色"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×誤用、乱用、使用上の誤りにより生じた損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×戦争、内乱、テロによる損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×上階からの水漏れによる損害（※上階への損害賠償）"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×保証開始時にすでに発生していた損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×ソフトウェアのインストールによる損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×パソコンの機能および使用に影響のない損害（液晶の"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "　 ピクセル抜けを含む）"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×データ、ソフトウェアの消失および損害（ウィルスに起因"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "   する損害を含む）"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×GSS指定の業者以外で修理を行った場合の修理費用"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "   および諸経費"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×海外で発生した損害"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×マウスなどの周辺機器、CD-ROMなどの記憶媒体"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "×消耗品（ケーブル、バッテリーなど）やACアダプター"

            Label35.Text = "* お使いのパソコンが壊れたら、まずお電話ください。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "  ご自分で修理した場合や、指定業者以外で修理した場合は"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "  保証の対象とはなりませんので、ご注意ください。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "* このサービスは、サービス証記載の方だけが受けることができ"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "  ます。また、このサービスは譲渡することが出来ません。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "* 修理料金が保証金額を超える場合、または故障等の原因が"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　裏面記載のサービス規約で保証の対象とならない場合に該当"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　する場合は、有償での修理となります。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += System.Environment.NewLine
            Label35.Text += "保証を受ける場合は、以下にご注意ください。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　①データは必ずバックアップをとってください。万一データが"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　　 損失しても当社は責任を負いません。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　②当社指定の事故報告書に事故状況をご記入の上、ご提出"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　　 ください。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　③PC付属のバックアップディスク（OSインストールディスクなど）"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　　 をいっしょにご提出ください。"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　④メーカー保証期間内の場合は、メーカー保証書（写）を一緒"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "　　 にご提出ください。"

        Else
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '一般
                Picture1.Visible = True : Picture2.Visible = True
                Picture3.Visible = False : Picture4.Visible = False
                Label33.Visible = True : Label41.Visible = True
                Label35.Visible = True
                Label49.Visible = True : Label50.Visible = True

                Label33.Text = System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += "×お使いのパソコンが壊れたら、まずお電話ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　ご自分で修理した場合や、指定業者以外で修理した場合は"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　保証の対象とはなりませんので、ご注意ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "×このサービスは、サービス証記載の方だけが受けることができ"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　ます。また、このサービスは譲渡することが出来ません。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "×修理料金が年間補償限度額を超える場合、または故障等の原因"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　が裏面記載のサービス規約で補償の対象とならない場合に該当"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　する場合は、有償での修理となります。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　1. データは必ずバックアップをとってください。万一データが"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　損失してもグローバルソリューションサービス株式会社は責"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　任を負いません。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　2. グローバルソリューションサービス株式会社指定の事故報"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　告書に事故状況をご記入の上、ご提出ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　3. PC付属のバックアップディスク（OSインストールディスクなど）"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　をいっしょにご提出ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　4. メーカー保証期間内の場合は、メーカー保証書（写）を一緒"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　にご提出ください。"

                Label35.Text = System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += shop_name.Text & "は、本サービスに関して以下の様にサービスを委託しています。"
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += "1. パソコン修理サービス・その他サービス"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " 　グローバルソリューションサービス株式会社"

                Label49.Text = "③については、" & shop_name.Text
                Label49.Text = Label49.Text & "がパソコン購入者のためにアリアンツ火災海上保険株式会社と動産総合保険契約を締結 しています。"

            Else                                                                '通常
                Picture1.Visible = True : Picture2.Visible = True
                Picture3.Visible = False : Picture4.Visible = False
                Label33.Visible = True : Label41.Visible = True
                Label35.Visible = True
                Label49.Visible = False : Label50.Visible = False

                Label33.Text = System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += "* お使いのパソコンが壊れたら、まずお電話ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 ご自分で修理した場合や、指定業者以外で修理した場合は"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 保証の対象とはなりませんので、ご注意ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "* このサービスは、サービス証記載の方だけが受けることができ"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 ます。また、このサービスは譲渡することが出来ません。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "* 修理料金が年間補償限度額を超える場合、または故障等の原因"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　が裏面記載のサービス規約で補償の対象とならない場合に該当"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　する場合は、有償での修理となります。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　1. データは必ずバックアップをとってください。万一データが"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　　 損失しても全国大学生協連合会（以下「大学生協連合会」と"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　します。）は責任を負いません。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　2. 大学生協連合会指定の事故報告書に事故状況をご記入の上"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　ご提出ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　3. PC付属のバックアップディスク（OSインストールディスクなど）"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　をいっしょにご提出ください。"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　4. メーカー保証期間内の場合は、メーカー保証書（写）を一緒"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "　 　にご提出ください。"

                Label35.Text = System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += "・本サービスは全国大学生活協同組合連合会（以下「大学生協連"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " 合会」とします。）が運営するパソコン安心サポートサービスです。"
                Label35.Text += System.Environment.NewLine
                Label35.Text += "・大学生協連合会は、本サービスに関して以下の様にサービス"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " を委託しています。"
                Label35.Text += System.Environment.NewLine
                Label35.Text += "1. パソコン修理サービス・その他サービス"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " 　グローバルソリューションサービス株式会社"
                Label35.Text += System.Environment.NewLine
                Label35.Text += "2. ③については、大学生協連合会がパソコン購入者のために"
                Label35.Text += System.Environment.NewLine
                If wrn_range.Text = "2" Then
                    Label35.Text += "　 東京日動火災海上保険株式会社と動産総合保険契約を締結"
                Else
                    Label35.Text += "　 アリアンツ火災海上保険株式会社と動産総合保険契約を締結"
                End If
                Label35.Text += System.Environment.NewLine
                Label35.Text += "   しています。"
            End If
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '延長保証
            Label36.Text = "グローバルソリューションサービス株式会社"
            Label37.Text = "〒141-0031"
            Label38.Text = "東京都品川区西五反田7-22-17" & System.Environment.NewLine & "TOCビル内"
            Picture.Visible = True
            Picture5.Visible = True
        Else
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '一般
                Label36.Text = "グローバルソリューションサービス株式会社"
                Label37.Text = "〒141-0031"
                Label38.Text = "東京都品川区西五反田7-22-17" & System.Environment.NewLine & "TOCビル内"
                Picture.Visible = True
                Picture5.Visible = True
            Else                                                                '通常
                Label36.Text = "全国大学生活協同組合連合会"
                Label37.Text = "〒166-8532"
                Label38.Text = "東京都杉並区和田3-30-22"
                Picture.Visible = False
                Picture5.Visible = False
            End If
        End If

    End Sub
End Class
