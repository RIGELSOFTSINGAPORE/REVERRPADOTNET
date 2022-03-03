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
        'prt_date.Text = "�؏����s���@�F�@" & WK_prt_date.ToString("ggyy�NM��d��", Culture)
        prt_date.Text = "�؏����s���@�F�@" & WK_prt_date

        Label15.Text = "QG-Care�́A�ΏۂƂȂ�p�\�R�����̏�Ȃǂœ����Ȃ��Ȃ����ꍇ�Ƀv���̋Z�p�҂��f�f���āA�C������T�[�r�X�ł��B"
        Label15.Text += System.Environment.NewLine
        Label15.Text += "�T�[�r�X���󂯂�ۂɂ́A�ȉ�����ї��ʂ��悭���ǂ݂��������B"



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

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Label.Text = "�{�؏��̓T�[�r�X�̓��e���L�ڂ������̂ł��̂ŁA��؂ɕۊǂ��Ă��������B"
        Else                                                                    '��ʁA�ʏ�
            Label.Text = "���q�l���w�����ꂽ���L�̑Ώ�PC�ɂ́A�ȉ��̃T�[�r�X�������ŕt�т���Ă��܂��B"
            Label.Text += System.Environment.NewLine
            Label.Text += "�{�؏��̓T�[�r�X�̓��e���L�ڂ������̂ł��̂ŁA��؂ɕۊǂ��Ă��������B"
        End If

        WK_str = Trim(shop_name.Text)
        WK_str = WK_str.Replace("�@", System.Environment.NewLine)
        WK_str = WK_str.Replace(" ", System.Environment.NewLine)
        If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then       '���
            Label45.Text = WK_str
            Label45.Text += System.Environment.NewLine & univ_name.Text
        Else
            Label45.Text = WK_str
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Label46.Visible = True      'GSS�R�[���Z���^�[
        Else
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '���
                Label46.Visible = True  'GSS�R�[���Z���^�[
            Else                                                                '�ʏ�
                Label46.Visible = False
            End If
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Label16.Text = "�ۏ͈͓ؔ��̏�Q�����������ꍇ��QG-Care��Q���k������"
            Label42.Text = "���d�b���������B"
        Else                                                                    '��ʁA�ʏ�
            Label16.Text = "�Ώ�PC�ɏ�Q�����������ꍇ�́A�܂�QG-Care�T�[�r�X����"
            Label42.Text = "�ɂ��d�b���������B"
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Label21.Text = "��"
            Label16.Text = "�ۏ͈͓ؔ��̏�Q�����������ꍇ��QG-Care��Q���k������"
            Label42.Text = "���d�b���������B"
        Else                                                                    '��ʁA�ʏ�
            Label21.Text = "�@"
            Label16.Text = "�Ώ�PC�ɏ�Q�����������ꍇ�́A�܂�QG-Care�T�[�r�X����"
            Label42.Text = "�ɂ��d�b���������B"
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Label22.Text = "��"
            Label19.Text = "�C����p�����x�z�܂ŕۏ�"
            Label47.Visible = True : Label48.Visible = True
            Shape5.Visible = False : Shape7.Visible = True
            Label24.Text = "�����N�ԕ⏞���x�z��1�N��15���~2�N��12���~3�N��10���~"
            Label24.Text += System.Environment.NewLine & "�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@4�N��6���~�i�ō��j��ۏ�"
            Label24.Text += System.Environment.NewLine & "�@�@�@�@�@�@���j��L���z�ƕۏؑΏۃp�\�R���w�����z��"
            Label24.Text += System.Environment.NewLine & "    �@�@�@�@�@�@�����ꂩ�Ⴂ���z���ۏ،��x�z�ƂȂ�܂��B"
            Label24.Text += System.Environment.NewLine & "��GSS�w��Ǝ҂ł̏C���݂̂ƂȂ�܂��B"
            Label25.Visible = False
        Else                                                                    '��ʁA�ʏ�
            Label22.Text = "�A"
            Label19.Text = "�ʏ�̏�̓��[�J�[�ۏ؂��󂯂��܂�"
            Label47.Visible = False : Label48.Visible = False
            Shape5.Visible = True : Shape7.Visible = False
            Label24.Text = "���ڍׂ�PC�ɓ�������Ă���ۏ؏����������������B"
            Label25.Visible = True
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Shape6.Visible = False : Label23.Visible = False : Label20.Visible = False
            Label43.Visible = False : Label27.Visible = False : Label44.Visible = False
            Label26.Visible = False : Label28.Visible = False : Label29.Visible = False
            Label30.Visible = False : Label31.Visible = False
        Else                                                                    '��ʁA�ʏ�
            Shape6.Visible = True : Label23.Visible = True : Label20.Visible = True
            Label43.Visible = True : Label27.Visible = True : Label44.Visible = True
            Label26.Visible = True : Label28.Visible = True : Label29.Visible = True
            Label30.Visible = True : Label31.Visible = True
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '���
                Label30.Text = "���w��̋Ǝ҂ł̏C���݂̂ƂȂ�܂��B"
            Else                                                                '�ʏ�
                Label30.Text = "����w�����A����w��̋Ǝ҂ł̏C���݂̂ƂȂ�܂��B"
            End If
        End If

        If wrn_range.Text = "2" Then
            Label26.Text = "�����N�ԕ⏞���x�z���ɂ��ẮA���ʂ����m�F���������B"
            Label28.Text = "���j������G��̏ꍇ�͕ۏ؊��Ԓ�1��ڂ͂T�C�O�O�O�~"
            Label29.Text = "�@2��ڈȍ~�͂P�O,�O�O�O�~�̎��ȕ��S���K�v�ł��B"
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Picture1.Visible = False : Picture2.Visible = False
            Picture3.Visible = True : Picture4.Visible = True
            Label33.Visible = True : Label41.Visible = False
            Label35.Visible = True
            Label49.Visible = False : Label50.Visible = False

            Label33.Text = "�~�Ώۃp�\�R���̌������m�F�o���Ȃ����Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~���΁A�n�k�Ȃǂ̎��R�ЊQ�ɂ�鑹�Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�����A�u�Y��A���\�A���̂ɂ�鑹�Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�����҂̌̈Ӌy�яd�ߎ��ɂ�鑹�Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~���H���l�H���A��������ъ��ɂ��K�J�r�ώ��ϐF"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~��p�A���p�A�g�p��̌��ɂ�萶�������Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�푈�A�����A�e���ɂ�鑹�Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~��K����̐��R��ɂ�鑹�Q�i����K�ւ̑��Q�����j"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�ۏ؊J�n���ɂ��łɔ������Ă������Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�\�t�g�E�F�A�̃C���X�g�[���ɂ�鑹�Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�p�\�R���̋@�\����юg�p�ɉe���̂Ȃ����Q�i�t����"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�@ �s�N�Z���������܂ށj"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�f�[�^�A�\�t�g�E�F�A�̏�������ё��Q�i�E�B���X�ɋN��"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "   ���鑹�Q���܂ށj"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~GSS�w��̋Ǝ҈ȊO�ŏC�����s�����ꍇ�̏C����p"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "   ����я��o��"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�C�O�Ŕ����������Q"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~�}�E�X�Ȃǂ̎��Ӌ@��ACD-ROM�Ȃǂ̋L���}��"
            Label33.Text += System.Environment.NewLine
            Label33.Text += "�~���Օi�i�P�[�u���A�o�b�e���[�Ȃǁj��AC�A�_�v�^�["

            Label35.Text = "* ���g���̃p�\�R������ꂽ��A�܂����d�b���������B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "  �������ŏC�������ꍇ��A�w��Ǝ҈ȊO�ŏC�������ꍇ��"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "  �ۏ؂̑ΏۂƂ͂Ȃ�܂���̂ŁA�����ӂ��������B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "* ���̃T�[�r�X�́A�T�[�r�X�؋L�ڂ̕��������󂯂邱�Ƃ��ł�"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "  �܂��B�܂��A���̃T�[�r�X�͏��n���邱�Ƃ��o���܂���B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "* �C���������ۏ؋��z�𒴂���ꍇ�A�܂��͌̏ᓙ�̌�����"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@���ʋL�ڂ̃T�[�r�X�K��ŕۏ؂̑ΏۂƂȂ�Ȃ��ꍇ�ɊY��"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@����ꍇ�́A�L���ł̏C���ƂȂ�܂��B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�ۏ؂��󂯂�ꍇ�́A�ȉ��ɂ����ӂ��������B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�@�f�[�^�͕K���o�b�N�A�b�v���Ƃ��Ă��������B����f�[�^��"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�@ �������Ă����Ђ͐ӔC�𕉂��܂���B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�A���Ўw��̎��̕񍐏��Ɏ��̏󋵂����L���̏�A����o"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�@ ���������B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�BPC�t���̃o�b�N�A�b�v�f�B�X�N�iOS�C���X�g�[���f�B�X�N�Ȃǁj"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�@ ����������ɂ���o���������B"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�C���[�J�[�ۏ؊��ԓ��̏ꍇ�́A���[�J�[�ۏ؏��i�ʁj���ꏏ"
            Label35.Text += System.Environment.NewLine
            Label35.Text += "�@�@ �ɂ���o���������B"

        Else
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '���
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
                Label33.Text += "�~���g���̃p�\�R������ꂽ��A�܂����d�b���������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@�������ŏC�������ꍇ��A�w��Ǝ҈ȊO�ŏC�������ꍇ��"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@�ۏ؂̑ΏۂƂ͂Ȃ�܂���̂ŁA�����ӂ��������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�~���̃T�[�r�X�́A�T�[�r�X�؋L�ڂ̕��������󂯂邱�Ƃ��ł�"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@�܂��B�܂��A���̃T�[�r�X�͏��n���邱�Ƃ��o���܂���B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�~�C���������N�ԕ⏞���x�z�𒴂���ꍇ�A�܂��͌̏ᓙ�̌���"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@�����ʋL�ڂ̃T�[�r�X�K��ŕ⏞�̑ΏۂƂȂ�Ȃ��ꍇ�ɊY��"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@����ꍇ�́A�L���ł̏C���ƂȂ�܂��B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@1. �f�[�^�͕K���o�b�N�A�b�v���Ƃ��Ă��������B����f�[�^��"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@�������Ă��O���[�o���\�����[�V�����T�[�r�X������Ђ͐�"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@�C�𕉂��܂���B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@2. �O���[�o���\�����[�V�����T�[�r�X������Ўw��̎��̕�"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@�����Ɏ��̏󋵂����L���̏�A����o���������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@3. PC�t���̃o�b�N�A�b�v�f�B�X�N�iOS�C���X�g�[���f�B�X�N�Ȃǁj"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@����������ɂ���o���������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@4. ���[�J�[�ۏ؊��ԓ��̏ꍇ�́A���[�J�[�ۏ؏��i�ʁj���ꏏ"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@�ɂ���o���������B"

                Label35.Text = System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += shop_name.Text & "�́A�{�T�[�r�X�Ɋւ��Ĉȉ��̗l�ɃT�[�r�X���ϑ����Ă��܂��B"
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += "1. �p�\�R���C���T�[�r�X�E���̑��T�[�r�X"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " �@�O���[�o���\�����[�V�����T�[�r�X�������"

                Label49.Text = "�B�ɂ��ẮA" & shop_name.Text
                Label49.Text = Label49.Text & "���p�\�R���w���҂̂��߂ɃA���A���c�΍ЊC��ی�������ЂƓ��Y�����ی��_������ ���Ă��܂��B"

            Else                                                                '�ʏ�
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
                Label33.Text += "* ���g���̃p�\�R������ꂽ��A�܂����d�b���������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �������ŏC�������ꍇ��A�w��Ǝ҈ȊO�ŏC�������ꍇ��"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �ۏ؂̑ΏۂƂ͂Ȃ�܂���̂ŁA�����ӂ��������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "* ���̃T�[�r�X�́A�T�[�r�X�؋L�ڂ̕��������󂯂邱�Ƃ��ł�"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �܂��B�܂��A���̃T�[�r�X�͏��n���邱�Ƃ��o���܂���B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "* �C���������N�ԕ⏞���x�z�𒴂���ꍇ�A�܂��͌̏ᓙ�̌���"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@�����ʋL�ڂ̃T�[�r�X�K��ŕ⏞�̑ΏۂƂȂ�Ȃ��ꍇ�ɊY��"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@����ꍇ�́A�L���ł̏C���ƂȂ�܂��B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@1. �f�[�^�͕K���o�b�N�A�b�v���Ƃ��Ă��������B����f�[�^��"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@�@ �������Ă��S����w�����A����i�ȉ��u��w�����A����v��"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@���܂��B�j�͐ӔC�𕉂��܂���B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@2. ��w�����A����w��̎��̕񍐏��Ɏ��̏󋵂����L���̏�"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@����o���������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@3. PC�t���̃o�b�N�A�b�v�f�B�X�N�iOS�C���X�g�[���f�B�X�N�Ȃǁj"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@����������ɂ���o���������B"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@4. ���[�J�[�ۏ؊��ԓ��̏ꍇ�́A���[�J�[�ۏ؏��i�ʁj���ꏏ"
                Label33.Text += System.Environment.NewLine
                Label33.Text += "�@ �@�ɂ���o���������B"

                Label35.Text = System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += System.Environment.NewLine
                Label35.Text += "�E�{�T�[�r�X�͑S����w���������g���A����i�ȉ��u��w�����A"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " ����v�Ƃ��܂��B�j���^�c����p�\�R�����S�T�|�[�g�T�[�r�X�ł��B"
                Label35.Text += System.Environment.NewLine
                Label35.Text += "�E��w�����A����́A�{�T�[�r�X�Ɋւ��Ĉȉ��̗l�ɃT�[�r�X"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " ���ϑ����Ă��܂��B"
                Label35.Text += System.Environment.NewLine
                Label35.Text += "1. �p�\�R���C���T�[�r�X�E���̑��T�[�r�X"
                Label35.Text += System.Environment.NewLine
                Label35.Text += " �@�O���[�o���\�����[�V�����T�[�r�X�������"
                Label35.Text += System.Environment.NewLine
                Label35.Text += "2. �B�ɂ��ẮA��w�����A����p�\�R���w���҂̂��߂�"
                Label35.Text += System.Environment.NewLine
                If wrn_range.Text = "2" Then
                    Label35.Text += "�@ ���������΍ЊC��ی�������ЂƓ��Y�����ی��_������"
                Else
                    Label35.Text += "�@ �A���A���c�΍ЊC��ی�������ЂƓ��Y�����ی��_������"
                End If
                Label35.Text += System.Environment.NewLine
                Label35.Text += "   ���Ă��܂��B"
            End If
        End If

        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Label36.Text = "�O���[�o���\�����[�V�����T�[�r�X�������"
            Label37.Text = "��141-0031"
            Label38.Text = "�����s�i��搼�ܔ��c7-22-17" & System.Environment.NewLine & "TOC�r����"
            Picture.Visible = True
            Picture5.Visible = True
        Else
            If Mid(code.Text, 1, 1) = "E" And Mid(code.Text, 4, 1) = "1" Then   '���
                Label36.Text = "�O���[�o���\�����[�V�����T�[�r�X�������"
                Label37.Text = "��141-0031"
                Label38.Text = "�����s�i��搼�ܔ��c7-22-17" & System.Environment.NewLine & "TOC�r����"
                Picture.Visible = True
                Picture5.Visible = True
            Else                                                                '�ʏ�
                Label36.Text = "�S����w���������g���A����"
                Label37.Text = "��166-8532"
                Label38.Text = "�����s������a�c3-30-22"
                Picture.Visible = False
                Picture5.Visible = False
            End If
        End If

    End Sub
End Class
