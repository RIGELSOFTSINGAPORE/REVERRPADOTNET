Module Module_Dim
    Public P_DsList1, P_DsPRT, P_DsHsty, P_CHG As New DataSet
    Public P_DtView1 As DataView

    Public P_MY_DOC_PAS As String   'ϲ�޷����
    Public strcurdir As String      '���s�t�H���_�[
    Public P_PGM_var As String      'exe�̍X�V��
    Public P_strUser As String      'user.ini�̏ꏊ

    Public P_EMPL_NO As Integer   'LogIn User���
    Public P_EMPL, P_EMPL_NAME, P_EMPL_BRCH, P_EMPL_BRCH_name, P_full, P_rpar_comp_code, P_DBG As String   'LogIn User���
    Public P_PC_NAME As String  '���[�J���o�b��
    Public P_PC_NAME2 As String
    Public P_comp_code, P_area_code As String
    Public P_ACES_brch_code, P_ACES_post_code As String    '����

    Public P_intprocid As Integer

    Public P1_F00_Form03, P2_F00_Form03, P3_F00_Form03, P4_F00_Form03, P5_F00_Form03 As String      'F00_Form03�p�p�����[�^
    Public P6_F00_Form03, P7_F00_Form03, P8_F00_Form03 As String                                    'F00_Form03�p�p�����[�^
    Public P1_F00_Form03_2, P2_F00_Form03_2, P3_F00_Form03_2 As String                                          'F00_Form03_2�p�p�����[�^


    Public P_PRAM1, P_PRAM2, P_PRAM3, P_PRAM4, P_PRAM5, P_PRAM6, P_PRAM7 As String
    Public P_RTN, P_RTN2, P_RTN3 As String
    Public PRT_PRAM1, PRT_PRAM2, PRT_PRAM3, PRT_PRAM4, PRT_PRAM5, PRT_PRAM6, PRT_PRAM7 As String

    Public P_mojibake As String
    Public P_uppr_mrgn, P_left_mrgn As Decimal
    Public P_page As Integer            '����y�[�W�p
    Public P_PRT_F As String            '���i���i�⍇���[����t���O

    Public P_HAITA As String
    Public P_HSTY_DATE As DateTime      '�����X�V��

    Public P_Line, P_Moji As Integer    '�s���������`�F�b�N�p

    Public P_part_rate1, P_part_rate2, P_part_pras, P_part_kotei As Decimal

End Module
