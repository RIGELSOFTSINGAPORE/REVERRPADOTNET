Module Module_Dim
    Public P_DsList1, P_DsPRT, P_DsHsty, P_CHG As New DataSet
    Public P_DtView1 As DataView

    Public P_MY_DOC_PAS As String   'ﾏｲﾄﾞｷｭﾒﾝﾄ
    Public strcurdir As String      '実行フォルダー
    Public P_PGM_var As String      'exeの更新日
    Public P_strUser As String      'user.iniの場所

    Public P_EMPL_NO As Integer   'LogIn User情報
    Public P_EMPL, P_EMPL_NAME, P_EMPL_BRCH, P_EMPL_BRCH_name, P_full, P_rpar_comp_code, P_DBG As String   'LogIn User情報
    Public P_PC_NAME As String  'ローカルＰＣ名
    Public P_PC_NAME2 As String
    Public P_comp_code, P_area_code As String
    Public P_ACES_brch_code, P_ACES_post_code As String    '権限

    Public P_intprocid As Integer

    Public P1_F00_Form03, P2_F00_Form03, P3_F00_Form03, P4_F00_Form03, P5_F00_Form03 As String      'F00_Form03用パラメータ
    Public P6_F00_Form03, P7_F00_Form03, P8_F00_Form03 As String                                    'F00_Form03用パラメータ
    Public P1_F00_Form03_2, P2_F00_Form03_2, P3_F00_Form03_2 As String                                          'F00_Form03_2用パラメータ


    Public P_PRAM1, P_PRAM2, P_PRAM3, P_PRAM4, P_PRAM5, P_PRAM6, P_PRAM7 As String
    Public P_RTN, P_RTN2, P_RTN3 As String
    Public PRT_PRAM1, PRT_PRAM2, PRT_PRAM3, PRT_PRAM4, PRT_PRAM5, PRT_PRAM6, PRT_PRAM7 As String

    Public P_mojibake As String
    Public P_uppr_mrgn, P_left_mrgn As Decimal
    Public P_page As Integer            '印刷ページ用
    Public P_PRT_F As String            '部品価格問合せ票印刷フラグ

    Public P_HAITA As String
    Public P_HSTY_DATE As DateTime      '履歴更新日

    Public P_Line, P_Moji As Integer    '行数文字数チェック用

    Public P_part_rate1, P_part_rate2, P_part_pras, P_part_kotei As Decimal

End Module
