Module Module_Dim
    Public P_EMPL_NO As Integer             'LogIn User情報
    Public P_EMPL, P_EMPL_NAME As String    'LogIn User情報

    Public P_DsList1 As New DataSet
    Public P_DsPRT As New DataSet
    Public P_DtView1 As DataView

    Public P_proc_y As Integer
    Public P_proc_y1 As String

    Public P_PRAM1, P_PRAM2, P_PRAM3, P_PRAM4, P_PRAM5, P_PRAM6, P_PRAM7 As String
    Public P_RTN As String

    Public P_SC1, P_SC2, P_SC3, P_SC4, P_SC5, P_SC6 As String  '検索条件
    Public PRT_PRAM1, PRT_PRAM2, PRT_PRAM3, PRT_PRAM4, PRT_PRAM5, PRT_PRAM6, PRT_PRAM7 As String

    Public P_mojibake As String
    Public P_uppr_mrgn, P_left_mrgn As Decimal
    Public P_PC_NAME As String  'ローカルＰＣ名
    Public P_PC_NAME2 As String

    Public iPad As String   '検索画面用

    Public cmnt As String   '取り込みコメント

End Module
