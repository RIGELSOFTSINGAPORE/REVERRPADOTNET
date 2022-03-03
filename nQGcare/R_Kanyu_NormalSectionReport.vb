Imports GrapeCity.ActiveReports
Imports GrapeCity.ActiveReports.Document

Public Class R_Kanyu_NormalSectionReport
    Dim WK_prt_date As Date
    Dim WK_str As String

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP", True)
        Culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
        WK_prt_date = Now.Date
        'prt_date.Text = "�؏����s���@�F�@" & WK_prt_date.ToString("ggyy�NM��d��", Culture)
        prt_date.Text = "�؏����s���@�F�@" & WK_prt_date

        Label15.Text = "QG-Care�́A�ΏۂƂȂ�p�\�R�����̏�Ȃǂœ����Ȃ��Ȃ����ꍇ�Ƀv���̋Z�p�҂��f�f���āA�C������T�[�r�X�ł��B"
        Label15.Text += System.Environment.NewLine
        Label15.Text += "�T�[�r�X���󂯂�ۂɂ́A�ȉ�����ї��ʂ��悭���ǂ݂��������B"



    End Sub
    Private Sub PageHeader_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub PageFooter_Format(sender As Object, e As EventArgs)

    End Sub

    Private Sub Detail_Format(sender As Object, e As EventArgs) Handles Detail.Format
        If Mid(code.Text, 1, 1) = "A" And Mid(code.Text, 4, 1) = "3" Then       '�����ۏ�
            Label.Text = "�{�؏��̓T�[�r�X�̓��e���L�ڂ������̂ł��̂ŁA��؂ɕۊǂ��Ă��������B"
        Else                                                                    '��ʁA�ʏ�
            Label.Text = "���q�l���w�����ꂽ���L�̑Ώ�PC�ɂ́A�ȉ��̃T�[�r�X�������ŕt�т���Ă��܂��B"
            Label.Text += System.Environment.NewLine
            Label.Text += "�{�؏��̓T�[�r�X�̓��e���L�ڂ������̂ł��̂ŁA��؂ɕۊǂ��Ă��������B"
        End If

        WK_str = Trim(shop_name.Text)
        'WK_str = WK_str.Replace("�@", System.Environment.NewLine)  'Ram 2021-04-12
        'WK_str = WK_str.Replace(" ", System.Environment.NewLine)
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

                'prabu comment 2021-06-23
                'Label49.Text = "�B�ɂ��ẮA" & shop_name.Text
                'Label49.Text = Label49.Text & "���p�\�R���w���҂̂��߂ɃA���A���c�΍ЊC��ی�������ЂƓ��Y�����ی��_������ ���Ă��܂��B"
                'prabu added 2021-06-23
                Label49.Text = "�B�ɂ��ẮA" & shop_name.Text
                Label49.Text = Label49.Text & "���p�\�R���w���҂̂��߂�  �A���A���c�΍ЊC��ی��������/�O��Z�F�C�㊔����ЂƓ��Y�����ی��_���������Ă��܂��B"



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
                'prabu comment 2021-06-23
                'Label35.Text += "2. �B�ɂ��ẮA��w�����A����p�\�R���w���҂̂��߂�"
                'Label35.Text += System.Environment.NewLine
                'If wrn_range.Text = "2" Then
                '    Label35.Text += "�@ ���������΍ЊC��ی�������ЂƓ��Y�����ی��_������"
                'Else
                '    Label35.Text += "�@ �A���A���c�΍ЊC��ی�������ЂƓ��Y�����ی��_������"
                'End If
                'Label35.Text += System.Environment.NewLine
                'Label35.Text += "   ���Ă��܂��B"
                'prabu added 2021-06-23
                Label35.Text += "2. �B�ɂ��ẮA��w�����A����p�\�R���w���҂̂��߂�"
                Label35.Text += System.Environment.NewLine
                If wrn_range.Text = "2" Then
                    Label35.Text += "�@ ���������΍ЊC��ی�������ЂƓ��Y�����ی��_������"
                    Label35.Text += System.Environment.NewLine
                    Label35.Text += "   ���Ă��܂��B"
                Else
                    Label35.Text += "�@ �A���A���c�΍ЊC��ی��������/�O��Z�F�C�㊔����Ђ�"
                    Label35.Text += System.Environment.NewLine
                    Label35.Text += "   ���Y�����ی��_���������Ă��܂��B"
                End If
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
