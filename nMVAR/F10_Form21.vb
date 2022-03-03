Public Class F10_Form21
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, DsCMB2, DsCMB3, DsCMB4, WK_DsList1, WK_DsList2, WK_DsList3, WK_DsList4 As New DataSet
    Dim DtView1, DtView2, DtView3, WK_DtView1, WK_DtView2, WK_DtView3, WK_DtView4, WK_DtView5, WK_DtView6 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F, CSR_POS, CHG_F, ANS, inz_F, prtct_F, TSS_F, QA_F As String
    Dim MSG_F, WK_MSG As String

    Dim i, j, r, en, Line_No, Line_No2, Line_No3, Line_No4, chg_itm, seq, WK_seq, WK_cnt As Integer
    Dim WK_str, WK_str2 As String
    Dim WK_int, WK_int2 As Integer
    Dim testint As Integer
    Dim Irregular_F As String = "0"

    'ïtëÆïi
    Private chkBox(99, 1) As CheckBox
    Private nbrBox(99, 1) As GrapeCity.Win.Input.Interop.Number
    Private edit(99, 2) As GrapeCity.Win.Input.Interop.Edit

    'åÃè·ì‡óe
    Private cmbBo_2(99, 1) As GrapeCity.Win.Input.Interop.Combo
    Dim WK_DsCMB As New DataSet

    'å©êœì‡óe
    Private cmbBo_3(99, 1) As GrapeCity.Win.Input.Interop.Combo
    Private label_3(99, 2) As Label
    Private cmbBo_3_MOTO(99, 1) As GrapeCity.Win.Input.Interop.Combo
    Dim WK_DsCMB3 As New DataSet

    'äÆóπì‡óe
    Private cmbBo_4(99, 1) As GrapeCity.Win.Input.Interop.Combo
    Private label_4(99, 2) As Label
    Dim WK_DsCMB4 As New DataSet

    Dim Wk_TAX As Integer
    Dim Wk_TAX_1, Wk_TAX_0 As Decimal

#Region " Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ê∂ê¨Ç≥ÇÍÇΩÉRÅ[Éh "

    Public Sub New()
        MyBase.New()

        ' Ç±ÇÃåƒÇ—èoÇµÇÕ Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ïKóvÇ≈Ç∑ÅB
        InitializeComponent()

        ' InitializeComponent() åƒÇ—èoÇµÇÃå„Ç…èâä˙âªÇí«â¡ÇµÇ‹Ç∑ÅB

    End Sub

    ' Form ÇÕÅAÉRÉìÉ|Å[ÉlÉìÉgàÍóóÇ…å„èàóùÇé¿çsÇ∑ÇÈÇΩÇﬂÇ… dispose ÇÉIÅ[ÉoÅ[ÉâÉCÉhÇµÇ‹Ç∑ÅB
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ïKóvÇ≈Ç∑ÅB
    Private components As System.ComponentModel.IContainer

    ' ÉÅÉÇ : à»â∫ÇÃÉvÉçÉVÅ[ÉWÉÉÇÕÅAWindows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ïKóvÇ≈Ç∑ÅB
    'Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇégÇ¡ÇƒïœçXÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB  
    ' ÉRÅ[Éh ÉGÉfÉBÉ^ÇégÇ¡ÇƒïœçXÇµÇ»Ç¢Ç≈Ç≠ÇæÇ≥Ç¢ÅB
    Friend WithEvents Panel_éÛït As System.Windows.Forms.Panel
    Friend WithEvents Panel_å©êœ As System.Windows.Forms.Panel
    Friend WithEvents Label12_1 As System.Windows.Forms.Label
    Friend WithEvents Label13_1 As System.Windows.Forms.Label
    Friend WithEvents Label14_1 As System.Windows.Forms.Label
    Friend WithEvents Label33_1 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel_äÆóπ As System.Windows.Forms.Panel
    Friend WithEvents Label16_1 As System.Windows.Forms.Label
    Friend WithEvents Label15_1 As System.Windows.Forms.Label
    Friend WithEvents Label34_1 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Date013 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date011 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date007 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date006 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date012 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date010 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date008 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date004 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date003 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Edit901 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit902 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label014 As System.Windows.Forms.Label
    Friend WithEvents Combo004 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit007 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19_1 As System.Windows.Forms.Label
    Friend WithEvents Label11_1 As System.Windows.Forms.Label
    Friend WithEvents Label04_1 As System.Windows.Forms.Label
    Friend WithEvents Label09_1 As System.Windows.Forms.Label
    Friend WithEvents Label10_1 As System.Windows.Forms.Label
    Friend WithEvents Label05_1 As System.Windows.Forms.Label
    Friend WithEvents Label07_1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Combo_U001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Edit_U004 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Combo_U002 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Panel_U2 As System.Windows.Forms.Panel
    Friend WithEvents Edit_U002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit_U005 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit_U003 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Date_U001 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Edit_U001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Panel_U1 As System.Windows.Forms.Panel
    Friend WithEvents Button_M001 As System.Windows.Forms.Button
    Friend WithEvents Panel_M1 As System.Windows.Forms.Panel
    Friend WithEvents Edit_M004 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit_M003 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit_M002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit_M001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Combo_M001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents DataGrid_M1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button_K002 As System.Windows.Forms.Button
    Friend WithEvents Panel_K1 As System.Windows.Forms.Panel
    Friend WithEvents Edit_K002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit_K001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents DataGrid_K1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button_K001 As System.Windows.Forms.Button
    Friend WithEvents Combo_K001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Edit008 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents CheckBox_U001 As System.Windows.Forms.CheckBox
    Friend WithEvents Edit011 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label_M02 As System.Windows.Forms.Label
    Friend WithEvents Label_M01 As System.Windows.Forms.Label
    Friend WithEvents Combo_M003 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label_M04 As System.Windows.Forms.Label
    Friend WithEvents Edit012 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Number016 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Number015 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number025 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number024 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number017 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number040 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Number032 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number012 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number031 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number022 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number011 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number014 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Number021 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number033 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label22_1 As System.Windows.Forms.Label
    Friend WithEvents Label23_1 As System.Windows.Forms.Label
    Friend WithEvents Number037 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number036 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number035 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number034 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents Number023 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number013 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Number027 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Number038 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number028 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number018 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number026 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents calc_cls As System.Windows.Forms.Label
    Friend WithEvents tax_rate As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Date_U002 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Number002 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number111 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number116 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number115 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number125 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number124 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number117 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number132 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number112 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number131 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number122 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number114 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number121 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number133 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number137 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number136 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number135 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number134 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number123 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number113 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number127 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number138 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number128 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number118 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number126 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents ZH As System.Windows.Forms.Label
    Friend WithEvents Number001 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Ck_atri_flg As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents apse As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CLU001 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button_S2 As System.Windows.Forms.Button
    Friend WithEvents CLK001 As System.Windows.Forms.Label
    Friend WithEvents Label_K01 As System.Windows.Forms.Label
    Friend WithEvents CK_own_flg As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Date001 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents NumberN003 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents NumberN007 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents NumberN004 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents NumberN008 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents NumberN005 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents NumberN006 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Number003 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Date_U003 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents zero_code As System.Windows.Forms.Label
    Friend WithEvents zero_name As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents NumberN009 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents kengen As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Edit013 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Combo_K002 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents CLK002 As System.Windows.Forms.Label
    Friend WithEvents CL004 As System.Windows.Forms.Label
    Friend WithEvents Label_K02 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GRP As System.Windows.Forms.Label
    Friend WithEvents CLU002 As System.Windows.Forms.Label
    Friend WithEvents Number001_nTax As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number039 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number029 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number019 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents CLK001_BRH As System.Windows.Forms.Label
    Friend WithEvents CHG As System.Windows.Forms.Label
    Friend WithEvents rebate As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents NumberN011 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents NumberN012 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents NumberN013 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CheckBox_M001 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_K001 As System.Windows.Forms.CheckBox
    Friend WithEvents idvd_chrg As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents idvd_flg As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Combo_K003 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents CLK003 As System.Windows.Forms.Label
    Friend WithEvents aka As System.Windows.Forms.Label
    Friend WithEvents CheckBox_U002 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_U003 As System.Windows.Forms.CheckBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents NumberN015 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Combo007 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Date014 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Number004 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label016 As System.Windows.Forms.Label
    Friend WithEvents Label015 As System.Windows.Forms.Label
    Friend WithEvents Label017 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cntact2 As System.Windows.Forms.Label
    Friend WithEvents cntact1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Edit015 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit014 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit903 As System.Windows.Forms.Label
    Friend WithEvents Edit_U006 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Edit_K003 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Date_U004 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents SBM As System.Windows.Forms.Label
    Friend WithEvents CkBox01_N As System.Windows.Forms.CheckBox
    Friend WithEvents CkBox01_Y As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Edit_K004 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button97 As System.Windows.Forms.Button
    Friend WithEvents sn_n As System.Windows.Forms.Label
    Friend WithEvents Date015 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Date016 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Date017 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Edit016 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Combo_K004 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents CLK004 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_K002 As System.Windows.Forms.CheckBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Button14 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel_éÛït = New System.Windows.Forms.Panel
        Me.Label61 = New System.Windows.Forms.Label
        Me.Date_U004 = New GrapeCity.Win.Input.Interop.Date
        Me.Edit_U006 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label58 = New System.Windows.Forms.Label
        Me.CheckBox_U003 = New System.Windows.Forms.CheckBox
        Me.CheckBox_U002 = New System.Windows.Forms.CheckBox
        Me.CLU002 = New System.Windows.Forms.Label
        Me.CLU001 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Date_U002 = New GrapeCity.Win.Input.Interop.Date
        Me.CheckBox_U001 = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Combo_U001 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label11_1 = New System.Windows.Forms.Label
        Me.Edit_U004 = New GrapeCity.Win.Input.Interop.Edit
        Me.Combo_U002 = New GrapeCity.Win.Input.Interop.Combo
        Me.Panel_U2 = New System.Windows.Forms.Panel
        Me.Edit_U002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit_U005 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit_U003 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label04_1 = New System.Windows.Forms.Label
        Me.Label09_1 = New System.Windows.Forms.Label
        Me.Label10_1 = New System.Windows.Forms.Label
        Me.Label05_1 = New System.Windows.Forms.Label
        Me.Label07_1 = New System.Windows.Forms.Label
        Me.Edit_U001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel_U1 = New System.Windows.Forms.Panel
        Me.pos = New System.Windows.Forms.Label
        Me.Label19_1 = New System.Windows.Forms.Label
        Me.Date_U001 = New GrapeCity.Win.Input.Interop.Date
        Me.Label33 = New System.Windows.Forms.Label
        Me.Date_U003 = New GrapeCity.Win.Input.Interop.Date
        Me.Panel_å©êœ = New System.Windows.Forms.Panel
        Me.Number039 = New GrapeCity.Win.Input.Interop.Number
        Me.Number029 = New GrapeCity.Win.Input.Interop.Number
        Me.Number019 = New GrapeCity.Win.Input.Interop.Number
        Me.Number016 = New GrapeCity.Win.Input.Interop.Number
        Me.Label133 = New System.Windows.Forms.Label
        Me.Label132 = New System.Windows.Forms.Label
        Me.Number015 = New GrapeCity.Win.Input.Interop.Number
        Me.Number025 = New GrapeCity.Win.Input.Interop.Number
        Me.Number024 = New GrapeCity.Win.Input.Interop.Number
        Me.Number017 = New GrapeCity.Win.Input.Interop.Number
        Me.Number040 = New GrapeCity.Win.Input.Interop.Number
        Me.Label11 = New System.Windows.Forms.Label
        Me.Number032 = New GrapeCity.Win.Input.Interop.Number
        Me.Number012 = New GrapeCity.Win.Input.Interop.Number
        Me.Number031 = New GrapeCity.Win.Input.Interop.Number
        Me.Number022 = New GrapeCity.Win.Input.Interop.Number
        Me.Number011 = New GrapeCity.Win.Input.Interop.Number
        Me.Number014 = New GrapeCity.Win.Input.Interop.Number
        Me.Label131 = New System.Windows.Forms.Label
        Me.Label130 = New System.Windows.Forms.Label
        Me.Label129 = New System.Windows.Forms.Label
        Me.Label128 = New System.Windows.Forms.Label
        Me.Number021 = New GrapeCity.Win.Input.Interop.Number
        Me.Number033 = New GrapeCity.Win.Input.Interop.Number
        Me.Label22_1 = New System.Windows.Forms.Label
        Me.Label23_1 = New System.Windows.Forms.Label
        Me.Number037 = New GrapeCity.Win.Input.Interop.Number
        Me.Number036 = New GrapeCity.Win.Input.Interop.Number
        Me.Number035 = New GrapeCity.Win.Input.Interop.Number
        Me.Number034 = New GrapeCity.Win.Input.Interop.Number
        Me.Label191 = New System.Windows.Forms.Label
        Me.Number023 = New GrapeCity.Win.Input.Interop.Number
        Me.Number013 = New GrapeCity.Win.Input.Interop.Number
        Me.Label138 = New System.Windows.Forms.Label
        Me.Number027 = New GrapeCity.Win.Input.Interop.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Number038 = New GrapeCity.Win.Input.Interop.Number
        Me.Number028 = New GrapeCity.Win.Input.Interop.Number
        Me.Number018 = New GrapeCity.Win.Input.Interop.Number
        Me.Number026 = New GrapeCity.Win.Input.Interop.Number
        Me.Button_M001 = New System.Windows.Forms.Button
        Me.Panel_M1 = New System.Windows.Forms.Panel
        Me.Edit_M004 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit_M003 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit_M002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit_M001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label12_1 = New System.Windows.Forms.Label
        Me.Label13_1 = New System.Windows.Forms.Label
        Me.Label14_1 = New System.Windows.Forms.Label
        Me.Label_M01 = New System.Windows.Forms.Label
        Me.Combo_M001 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label_M02 = New System.Windows.Forms.Label
        Me.Label33_1 = New System.Windows.Forms.Label
        Me.DataGrid_M1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label_M04 = New System.Windows.Forms.Label
        Me.Combo_M003 = New GrapeCity.Win.Input.Interop.Combo
        Me.CheckBox_M001 = New System.Windows.Forms.CheckBox
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button0 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel_äÆóπ = New System.Windows.Forms.Panel
        Me.CLK004 = New System.Windows.Forms.Label
        Me.Edit_K004 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label62 = New System.Windows.Forms.Label
        Me.CLK001_BRH = New System.Windows.Forms.Label
        Me.Edit_K003 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label59 = New System.Windows.Forms.Label
        Me.CLK001 = New System.Windows.Forms.Label
        Me.CLK002 = New System.Windows.Forms.Label
        Me.CLK003 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Combo_K003 = New GrapeCity.Win.Input.Interop.Combo
        Me.CheckBox_K001 = New System.Windows.Forms.CheckBox
        Me.Label_K02 = New System.Windows.Forms.Label
        Me.Combo_K002 = New GrapeCity.Win.Input.Interop.Combo
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.Label19 = New System.Windows.Forms.Label
        Me.Combo_K004 = New GrapeCity.Win.Input.Interop.Combo
        Me.Button_S2 = New System.Windows.Forms.Button
        Me.Number116 = New GrapeCity.Win.Input.Interop.Number
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Number115 = New GrapeCity.Win.Input.Interop.Number
        Me.Number125 = New GrapeCity.Win.Input.Interop.Number
        Me.Number124 = New GrapeCity.Win.Input.Interop.Number
        Me.Number117 = New GrapeCity.Win.Input.Interop.Number
        Me.Number132 = New GrapeCity.Win.Input.Interop.Number
        Me.Number112 = New GrapeCity.Win.Input.Interop.Number
        Me.Number131 = New GrapeCity.Win.Input.Interop.Number
        Me.Number122 = New GrapeCity.Win.Input.Interop.Number
        Me.Number111 = New GrapeCity.Win.Input.Interop.Number
        Me.Number114 = New GrapeCity.Win.Input.Interop.Number
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Number121 = New GrapeCity.Win.Input.Interop.Number
        Me.Number133 = New GrapeCity.Win.Input.Interop.Number
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Number137 = New GrapeCity.Win.Input.Interop.Number
        Me.Number136 = New GrapeCity.Win.Input.Interop.Number
        Me.Number135 = New GrapeCity.Win.Input.Interop.Number
        Me.Number134 = New GrapeCity.Win.Input.Interop.Number
        Me.Label29 = New System.Windows.Forms.Label
        Me.Number123 = New GrapeCity.Win.Input.Interop.Number
        Me.Number113 = New GrapeCity.Win.Input.Interop.Number
        Me.Label30 = New System.Windows.Forms.Label
        Me.Number127 = New GrapeCity.Win.Input.Interop.Number
        Me.Label31 = New System.Windows.Forms.Label
        Me.Number138 = New GrapeCity.Win.Input.Interop.Number
        Me.Number128 = New GrapeCity.Win.Input.Interop.Number
        Me.Number118 = New GrapeCity.Win.Input.Interop.Number
        Me.Number126 = New GrapeCity.Win.Input.Interop.Number
        Me.Label_K01 = New System.Windows.Forms.Label
        Me.Combo_K001 = New GrapeCity.Win.Input.Interop.Combo
        Me.Button_K002 = New System.Windows.Forms.Button
        Me.Panel_K1 = New System.Windows.Forms.Panel
        Me.Edit_K002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit_K001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label16_1 = New System.Windows.Forms.Label
        Me.Label15_1 = New System.Windows.Forms.Label
        Me.Label34_1 = New System.Windows.Forms.Label
        Me.DataGrid_K1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button_K001 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NumberN013 = New GrapeCity.Win.Input.Interop.Number
        Me.NumberN012 = New GrapeCity.Win.Input.Interop.Number
        Me.NumberN011 = New GrapeCity.Win.Input.Interop.Number
        Me.Label51 = New System.Windows.Forms.Label
        Me.NumberN015 = New GrapeCity.Win.Input.Interop.Number
        Me.rebate = New GrapeCity.Win.Input.Interop.Number
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.idvd_chrg = New GrapeCity.Win.Input.Interop.Number
        Me.CHG = New System.Windows.Forms.Label
        Me.zero_name = New System.Windows.Forms.Label
        Me.zero_code = New System.Windows.Forms.Label
        Me.NumberN004 = New GrapeCity.Win.Input.Interop.Number
        Me.NumberN003 = New GrapeCity.Win.Input.Interop.Number
        Me.NumberN005 = New GrapeCity.Win.Input.Interop.Number
        Me.ZH = New System.Windows.Forms.Label
        Me.apse = New System.Windows.Forms.Label
        Me.NumberN008 = New GrapeCity.Win.Input.Interop.Number
        Me.NumberN007 = New GrapeCity.Win.Input.Interop.Number
        Me.NumberN006 = New GrapeCity.Win.Input.Interop.Number
        Me.CheckBox_K002 = New System.Windows.Forms.CheckBox
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Date013 = New GrapeCity.Win.Input.Interop.Date
        Me.Date011 = New GrapeCity.Win.Input.Interop.Date
        Me.Label45 = New System.Windows.Forms.Label
        Me.Date007 = New GrapeCity.Win.Input.Interop.Date
        Me.Label016 = New System.Windows.Forms.Label
        Me.Date006 = New GrapeCity.Win.Input.Interop.Date
        Me.Label015 = New System.Windows.Forms.Label
        Me.Date012 = New GrapeCity.Win.Input.Interop.Date
        Me.Date010 = New GrapeCity.Win.Input.Interop.Date
        Me.Date008 = New GrapeCity.Win.Input.Interop.Date
        Me.Date004 = New GrapeCity.Win.Input.Interop.Date
        Me.Date003 = New GrapeCity.Win.Input.Interop.Date
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Edit010 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit009 = New GrapeCity.Win.Input.Interop.Edit
        Me.Mask1 = New GrapeCity.Win.Input.Interop.Mask
        Me.Label013 = New System.Windows.Forms.Label
        Me.Edit901 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit902 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label20 = New System.Windows.Forms.Label
        Me.Combo003 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Interop.Combo
        Me.Edit000 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label014 = New System.Windows.Forms.Label
        Me.Combo004 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label012 = New System.Windows.Forms.Label
        Me.Edit006 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit008 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit007 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit005 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Edit004 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Edit002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit003 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit011 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Edit012 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.calc_cls = New System.Windows.Forms.Label
        Me.tax_rate = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Number002 = New GrapeCity.Win.Input.Interop.Number
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Interop.Number
        Me.Ck_atri_flg = New System.Windows.Forms.CheckBox
        Me.CK_own_flg = New System.Windows.Forms.CheckBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Date001 = New GrapeCity.Win.Input.Interop.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label002 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label46 = New System.Windows.Forms.Label
        Me.Combo005 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label15 = New System.Windows.Forms.Label
        Me.Number003 = New GrapeCity.Win.Input.Interop.Number
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.NumberN009 = New GrapeCity.Win.Input.Interop.Number
        Me.kengen = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label28 = New System.Windows.Forms.Label
        Me.Edit013 = New GrapeCity.Win.Input.Interop.Edit
        Me.CL004 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.GRP = New System.Windows.Forms.Label
        Me.Number001_nTax = New GrapeCity.Win.Input.Interop.Number
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo006 = New GrapeCity.Win.Input.Interop.Combo
        Me.Button8 = New System.Windows.Forms.Button
        Me.idvd_flg = New System.Windows.Forms.Label
        Me.aka = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Combo007 = New GrapeCity.Win.Input.Interop.Combo
        Me.Date014 = New GrapeCity.Win.Input.Interop.Date
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Number004 = New GrapeCity.Win.Input.Interop.Number
        Me.Label017 = New System.Windows.Forms.Label
        Me.Button9 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cntact2 = New System.Windows.Forms.Label
        Me.cntact1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Edit015 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label57 = New System.Windows.Forms.Label
        Me.Edit014 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit903 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.SBM = New System.Windows.Forms.Label
        Me.CkBox01_N = New System.Windows.Forms.CheckBox
        Me.CkBox01_Y = New System.Windows.Forms.CheckBox
        Me.Button97 = New System.Windows.Forms.Button
        Me.sn_n = New System.Windows.Forms.Label
        Me.Date015 = New GrapeCity.Win.Input.Interop.Date
        Me.Label63 = New System.Windows.Forms.Label
        Me.Date016 = New GrapeCity.Win.Input.Interop.Date
        Me.Label64 = New System.Windows.Forms.Label
        Me.Date017 = New GrapeCity.Win.Input.Interop.Date
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.Edit016 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label67 = New System.Windows.Forms.Label
        Me.Button14 = New System.Windows.Forms.Button
        Me.Panel_éÛït.SuspendLayout()
        CType(Me.Date_U004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_U002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_U002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_U1.SuspendLayout()
        CType(Me.Date_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_U003, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_å©êœ.SuspendLayout()
        CType(Me.Number039, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number016, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number025, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number024, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number017, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number040, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number032, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number031, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number022, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number021, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number033, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number037, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number036, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number035, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number034, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number023, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number027, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number038, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number028, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number018, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number026, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_äÆóπ.SuspendLayout()
        CType(Me.Edit_K004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_K003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_K003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_K002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_K004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number116, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number115, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number125, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number124, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number117, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number132, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number112, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number131, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number122, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number111, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number114, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number121, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number133, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number137, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number136, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number135, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number134, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number123, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number113, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number127, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number138, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number128, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number118, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number126, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_K001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_K002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_K001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid_K1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.NumberN013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rebate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.idvd_chrg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date010, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit901, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit902, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN009, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date016, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date017, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit016, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_éÛït
        '
        Me.Panel_éÛït.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_éÛït.Controls.Add(Me.Label61)
        Me.Panel_éÛït.Controls.Add(Me.Date_U004)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U006)
        Me.Panel_éÛït.Controls.Add(Me.Label58)
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U003)
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U002)
        Me.Panel_éÛït.Controls.Add(Me.CLU002)
        Me.Panel_éÛït.Controls.Add(Me.CLU001)
        Me.Panel_éÛït.Controls.Add(Me.Label32)
        Me.Panel_éÛït.Controls.Add(Me.Date_U002)
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U001)
        Me.Panel_éÛït.Controls.Add(Me.Label6)
        Me.Panel_éÛït.Controls.Add(Me.Combo_U001)
        Me.Panel_éÛït.Controls.Add(Me.Label11_1)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U004)
        Me.Panel_éÛït.Controls.Add(Me.Combo_U002)
        Me.Panel_éÛït.Controls.Add(Me.Panel_U2)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U002)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U005)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U003)
        Me.Panel_éÛït.Controls.Add(Me.Label04_1)
        Me.Panel_éÛït.Controls.Add(Me.Label09_1)
        Me.Panel_éÛït.Controls.Add(Me.Label10_1)
        Me.Panel_éÛït.Controls.Add(Me.Label05_1)
        Me.Panel_éÛït.Controls.Add(Me.Label07_1)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U001)
        Me.Panel_éÛït.Controls.Add(Me.Label8)
        Me.Panel_éÛït.Controls.Add(Me.Panel_U1)
        Me.Panel_éÛït.Controls.Add(Me.Label19_1)
        Me.Panel_éÛït.Controls.Add(Me.Date_U001)
        Me.Panel_éÛït.Controls.Add(Me.Label33)
        Me.Panel_éÛït.Controls.Add(Me.Date_U003)
        Me.Panel_éÛït.Location = New System.Drawing.Point(8, 288)
        Me.Panel_éÛït.Name = "Panel_éÛït"
        Me.Panel_éÛït.Size = New System.Drawing.Size(986, 372)
        Me.Panel_éÛït.TabIndex = 25
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.SystemColors.Control
        Me.Label61.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label61.Location = New System.Drawing.Point(840, 52)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(20, 20)
        Me.Label61.TabIndex = 1850
        Me.Label61.Text = "Å`"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U004
        '
        Me.Date_U004.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U004.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U004.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U004.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U004.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U004.Enabled = False
        Me.Date_U004.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U004.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date_U004.Location = New System.Drawing.Point(864, 52)
        Me.Date_U004.Name = "Date_U004"
        Me.Date_U004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date_U004.Size = New System.Drawing.Size(88, 20)
        Me.Date_U004.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U004.TabIndex = 1849
        Me.Date_U004.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_U004.Value = Nothing
        '
        'Edit_U006
        '
        Me.Edit_U006.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U006.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U006.Enabled = False
        Me.Edit_U006.Format = "9#aA"
        Me.Edit_U006.HighlightText = True
        Me.Edit_U006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U006.LengthAsByte = True
        Me.Edit_U006.Location = New System.Drawing.Point(460, 52)
        Me.Edit_U006.MaxLength = 15
        Me.Edit_U006.Name = "Edit_U006"
        Me.Edit_U006.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_U006.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U006.TabIndex = 1847
        Me.Edit_U006.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Navy
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.ForeColor = System.Drawing.Color.White
        Me.Label58.Location = New System.Drawing.Point(380, 52)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(80, 20)
        Me.Label58.TabIndex = 1848
        Me.Label58.Text = "SB/IMEI"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox_U003
        '
        Me.CheckBox_U003.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U003.Location = New System.Drawing.Point(676, 32)
        Me.CheckBox_U003.Name = "CheckBox_U003"
        Me.CheckBox_U003.Size = New System.Drawing.Size(76, 16)
        Me.CheckBox_U003.TabIndex = 55
        Me.CheckBox_U003.Text = "ÇmÇèÇîÇÖ"
        '
        'CheckBox_U002
        '
        Me.CheckBox_U002.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U002.Location = New System.Drawing.Point(956, 56)
        Me.CheckBox_U002.Name = "CheckBox_U002"
        Me.CheckBox_U002.Size = New System.Drawing.Size(20, 16)
        Me.CheckBox_U002.TabIndex = 1846
        '
        'CLU002
        '
        Me.CLU002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU002.Location = New System.Drawing.Point(304, 56)
        Me.CLU002.Name = "CLU002"
        Me.CLU002.Size = New System.Drawing.Size(52, 16)
        Me.CLU002.TabIndex = 1845
        Me.CLU002.Text = "CLU002"
        Me.CLU002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU002.Visible = False
        '
        'CLU001
        '
        Me.CLU001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU001.Location = New System.Drawing.Point(308, 8)
        Me.CLU001.Name = "CLU001"
        Me.CLU001.Size = New System.Drawing.Size(48, 16)
        Me.CLU001.TabIndex = 1813
        Me.CLU001.Text = "CLU001"
        Me.CLU001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU001.Visible = False
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(680, 52)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(72, 20)
        Me.Label32.TabIndex = 1514
        Me.Label32.Text = "“∞∂∞ï€èÿ"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U002
        '
        Me.Date_U002.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U002.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U002.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U002.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U002.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U002.Enabled = False
        Me.Date_U002.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date_U002.Location = New System.Drawing.Point(752, 52)
        Me.Date_U002.Name = "Date_U002"
        Me.Date_U002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date_U002.Size = New System.Drawing.Size(88, 20)
        Me.Date_U002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U002.TabIndex = 1513
        Me.Date_U002.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_U002.Value = Nothing
        '
        'CheckBox_U001
        '
        Me.CheckBox_U001.AutoCheck = False
        Me.CheckBox_U001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U001.Location = New System.Drawing.Point(676, 8)
        Me.CheckBox_U001.Name = "CheckBox_U001"
        Me.CheckBox_U001.Size = New System.Drawing.Size(76, 16)
        Me.CheckBox_U001.TabIndex = 1275
        Me.CheckBox_U001.TabStop = False
        Me.CheckBox_U001.Text = "íËäzèCóù"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(4, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 1274
        Me.Label6.Text = "ÉÅÅ[ÉJÅ["
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_U001
        '
        Me.Combo_U001.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_U001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_U001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_U001.Enabled = False
        Me.Combo_U001.Location = New System.Drawing.Point(84, 4)
        Me.Combo_U001.MaxDropDownItems = 20
        Me.Combo_U001.Name = "Combo_U001"
        Me.Combo_U001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_U001.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U001.TabIndex = 1257
        Me.Combo_U001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo_U001.Value = "Combo_U001"
        '
        'Label11_1
        '
        Me.Label11_1.BackColor = System.Drawing.Color.Navy
        Me.Label11_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11_1.ForeColor = System.Drawing.Color.White
        Me.Label11_1.Location = New System.Drawing.Point(380, 284)
        Me.Label11_1.Name = "Label11_1"
        Me.Label11_1.Size = New System.Drawing.Size(80, 76)
        Me.Label11_1.TabIndex = 1269
        Me.Label11_1.Text = "ÉRÉÅÉìÉg"
        Me.Label11_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit_U004
        '
        Me.Edit_U004.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U004.LengthAsByte = True
        Me.Edit_U004.Location = New System.Drawing.Point(460, 220)
        Me.Edit_U004.Multiline = True
        Me.Edit_U004.Name = "Edit_U004"
        Me.Edit_U004.ReadOnly = True
        Me.Edit_U004.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit_U004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_U004.Size = New System.Drawing.Size(520, 64)
        Me.Edit_U004.TabIndex = 1264
        Me.Edit_U004.TabStop = False
        '
        'Combo_U002
        '
        Me.Combo_U002.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_U002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_U002.Enabled = False
        Me.Combo_U002.Location = New System.Drawing.Point(84, 52)
        Me.Combo_U002.MaxDropDownItems = 35
        Me.Combo_U002.Name = "Combo_U002"
        Me.Combo_U002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_U002.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U002.TabIndex = 1261
        Me.Combo_U002.Value = "Combo_U002"
        '
        'Panel_U2
        '
        Me.Panel_U2.AutoScroll = True
        Me.Panel_U2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_U2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_U2.Location = New System.Drawing.Point(460, 76)
        Me.Panel_U2.Name = "Panel_U2"
        Me.Panel_U2.Size = New System.Drawing.Size(520, 144)
        Me.Panel_U2.TabIndex = 1263
        '
        'Edit_U002
        '
        Me.Edit_U002.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U002.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U002.Enabled = False
        Me.Edit_U002.HighlightText = True
        Me.Edit_U002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U002.LengthAsByte = True
        Me.Edit_U002.Location = New System.Drawing.Point(84, 28)
        Me.Edit_U002.MaxLength = 50
        Me.Edit_U002.Name = "Edit_U002"
        Me.Edit_U002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_U002.Size = New System.Drawing.Size(292, 20)
        Me.Edit_U002.TabIndex = 1259
        Me.Edit_U002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit_U005
        '
        Me.Edit_U005.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U005.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U005.LengthAsByte = True
        Me.Edit_U005.Location = New System.Drawing.Point(460, 284)
        Me.Edit_U005.Multiline = True
        Me.Edit_U005.Name = "Edit_U005"
        Me.Edit_U005.ReadOnly = True
        Me.Edit_U005.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit_U005.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U005.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_U005.Size = New System.Drawing.Size(492, 76)
        Me.Edit_U005.TabIndex = 1265
        Me.Edit_U005.TabStop = False
        '
        'Edit_U003
        '
        Me.Edit_U003.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U003.Enabled = False
        Me.Edit_U003.Format = "9#aA"
        Me.Edit_U003.HighlightText = True
        Me.Edit_U003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U003.LengthAsByte = True
        Me.Edit_U003.Location = New System.Drawing.Point(460, 28)
        Me.Edit_U003.MaxLength = 25
        Me.Edit_U003.Name = "Edit_U003"
        Me.Edit_U003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_U003.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U003.TabIndex = 1260
        Me.Edit_U003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label04_1
        '
        Me.Label04_1.BackColor = System.Drawing.Color.Navy
        Me.Label04_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label04_1.ForeColor = System.Drawing.Color.White
        Me.Label04_1.Location = New System.Drawing.Point(4, 28)
        Me.Label04_1.Name = "Label04_1"
        Me.Label04_1.Size = New System.Drawing.Size(80, 20)
        Me.Label04_1.TabIndex = 1266
        Me.Label04_1.Text = "ã@éÌ"
        Me.Label04_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label09_1
        '
        Me.Label09_1.BackColor = System.Drawing.Color.Navy
        Me.Label09_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label09_1.ForeColor = System.Drawing.Color.White
        Me.Label09_1.Location = New System.Drawing.Point(4, 76)
        Me.Label09_1.Name = "Label09_1"
        Me.Label09_1.Size = New System.Drawing.Size(80, 284)
        Me.Label09_1.TabIndex = 1267
        Me.Label09_1.Text = "ïtëÆïi"
        Me.Label09_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10_1
        '
        Me.Label10_1.BackColor = System.Drawing.Color.Navy
        Me.Label10_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10_1.ForeColor = System.Drawing.Color.White
        Me.Label10_1.Location = New System.Drawing.Point(380, 76)
        Me.Label10_1.Name = "Label10_1"
        Me.Label10_1.Size = New System.Drawing.Size(80, 208)
        Me.Label10_1.TabIndex = 1268
        Me.Label10_1.Text = "åÃè·ì‡óe"
        Me.Label10_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label05_1
        '
        Me.Label05_1.BackColor = System.Drawing.Color.Navy
        Me.Label05_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label05_1.ForeColor = System.Drawing.Color.White
        Me.Label05_1.Location = New System.Drawing.Point(380, 28)
        Me.Label05_1.Name = "Label05_1"
        Me.Label05_1.Size = New System.Drawing.Size(80, 20)
        Me.Label05_1.TabIndex = 1270
        Me.Label05_1.Text = "S/N"
        Me.Label05_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label07_1
        '
        Me.Label07_1.BackColor = System.Drawing.Color.Navy
        Me.Label07_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label07_1.ForeColor = System.Drawing.Color.White
        Me.Label07_1.Location = New System.Drawing.Point(4, 52)
        Me.Label07_1.Name = "Label07_1"
        Me.Label07_1.Size = New System.Drawing.Size(80, 20)
        Me.Label07_1.TabIndex = 1271
        Me.Label07_1.Text = "èCóùâÔé–"
        Me.Label07_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit_U001
        '
        Me.Edit_U001.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U001.Enabled = False
        Me.Edit_U001.HighlightText = True
        Me.Edit_U001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U001.LengthAsByte = True
        Me.Edit_U001.Location = New System.Drawing.Point(460, 4)
        Me.Edit_U001.MaxLength = 50
        Me.Edit_U001.Name = "Edit_U001"
        Me.Edit_U001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_U001.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U001.TabIndex = 1258
        Me.Edit_U001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(380, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 1273
        Me.Label8.Text = "ÉÇÉfÉã"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel_U1
        '
        Me.Panel_U1.AutoScroll = True
        Me.Panel_U1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_U1.Controls.Add(Me.pos)
        Me.Panel_U1.Location = New System.Drawing.Point(84, 76)
        Me.Panel_U1.Name = "Panel_U1"
        Me.Panel_U1.Size = New System.Drawing.Size(292, 284)
        Me.Panel_U1.TabIndex = 1262
        '
        'pos
        '
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(0, 0)
        Me.pos.TabIndex = 0
        '
        'Label19_1
        '
        Me.Label19_1.BackColor = System.Drawing.Color.Navy
        Me.Label19_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19_1.ForeColor = System.Drawing.Color.White
        Me.Label19_1.Location = New System.Drawing.Point(764, 4)
        Me.Label19_1.Name = "Label19_1"
        Me.Label19_1.Size = New System.Drawing.Size(100, 20)
        Me.Label19_1.TabIndex = 1272
        Me.Label19_1.Text = "çwì¸ì˙"
        Me.Label19_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U001
        '
        Me.Date_U001.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U001.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U001.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U001.Enabled = False
        Me.Date_U001.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date_U001.Location = New System.Drawing.Point(864, 4)
        Me.Date_U001.Name = "Date_U001"
        Me.Date_U001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date_U001.Size = New System.Drawing.Size(88, 20)
        Me.Date_U001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U001.TabIndex = 1256
        Me.Date_U001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_U001.Value = Nothing
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Navy
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(764, 28)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(100, 20)
        Me.Label33.TabIndex = 1832
        Me.Label33.Text = "éñåÃì˙"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U003
        '
        Me.Date_U003.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U003.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U003.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U003.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date_U003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U003.Enabled = False
        Me.Date_U003.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date_U003.Location = New System.Drawing.Point(864, 28)
        Me.Date_U003.Name = "Date_U003"
        Me.Date_U003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date_U003.Size = New System.Drawing.Size(88, 20)
        Me.Date_U003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U003.TabIndex = 1831
        Me.Date_U003.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_U003.Value = Nothing
        '
        'Panel_å©êœ
        '
        Me.Panel_å©êœ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_å©êœ.Controls.Add(Me.Number039)
        Me.Panel_å©êœ.Controls.Add(Me.Number029)
        Me.Panel_å©êœ.Controls.Add(Me.Number019)
        Me.Panel_å©êœ.Controls.Add(Me.Number016)
        Me.Panel_å©êœ.Controls.Add(Me.Label133)
        Me.Panel_å©êœ.Controls.Add(Me.Label132)
        Me.Panel_å©êœ.Controls.Add(Me.Number015)
        Me.Panel_å©êœ.Controls.Add(Me.Number025)
        Me.Panel_å©êœ.Controls.Add(Me.Number024)
        Me.Panel_å©êœ.Controls.Add(Me.Number017)
        Me.Panel_å©êœ.Controls.Add(Me.Number040)
        Me.Panel_å©êœ.Controls.Add(Me.Label11)
        Me.Panel_å©êœ.Controls.Add(Me.Number032)
        Me.Panel_å©êœ.Controls.Add(Me.Number012)
        Me.Panel_å©êœ.Controls.Add(Me.Number031)
        Me.Panel_å©êœ.Controls.Add(Me.Number022)
        Me.Panel_å©êœ.Controls.Add(Me.Number011)
        Me.Panel_å©êœ.Controls.Add(Me.Number014)
        Me.Panel_å©êœ.Controls.Add(Me.Label131)
        Me.Panel_å©êœ.Controls.Add(Me.Label130)
        Me.Panel_å©êœ.Controls.Add(Me.Label129)
        Me.Panel_å©êœ.Controls.Add(Me.Label128)
        Me.Panel_å©êœ.Controls.Add(Me.Number021)
        Me.Panel_å©êœ.Controls.Add(Me.Number033)
        Me.Panel_å©êœ.Controls.Add(Me.Label22_1)
        Me.Panel_å©êœ.Controls.Add(Me.Label23_1)
        Me.Panel_å©êœ.Controls.Add(Me.Number037)
        Me.Panel_å©êœ.Controls.Add(Me.Number036)
        Me.Panel_å©êœ.Controls.Add(Me.Number035)
        Me.Panel_å©êœ.Controls.Add(Me.Number034)
        Me.Panel_å©êœ.Controls.Add(Me.Label191)
        Me.Panel_å©êœ.Controls.Add(Me.Number023)
        Me.Panel_å©êœ.Controls.Add(Me.Number013)
        Me.Panel_å©êœ.Controls.Add(Me.Label138)
        Me.Panel_å©êœ.Controls.Add(Me.Number027)
        Me.Panel_å©êœ.Controls.Add(Me.Label1)
        Me.Panel_å©êœ.Controls.Add(Me.Number038)
        Me.Panel_å©êœ.Controls.Add(Me.Number028)
        Me.Panel_å©êœ.Controls.Add(Me.Number018)
        Me.Panel_å©êœ.Controls.Add(Me.Number026)
        Me.Panel_å©êœ.Controls.Add(Me.Button_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Panel_M1)
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M004)
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M003)
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M002)
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Label12_1)
        Me.Panel_å©êœ.Controls.Add(Me.Label13_1)
        Me.Panel_å©êœ.Controls.Add(Me.Label14_1)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M01)
        Me.Panel_å©êœ.Controls.Add(Me.Combo_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M02)
        Me.Panel_å©êœ.Controls.Add(Me.Label33_1)
        Me.Panel_å©êœ.Controls.Add(Me.DataGrid_M1)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M04)
        Me.Panel_å©êœ.Controls.Add(Me.Combo_M003)
        Me.Panel_å©êœ.Controls.Add(Me.CheckBox_M001)
        Me.Panel_å©êœ.Location = New System.Drawing.Point(8, 288)
        Me.Panel_å©êœ.Name = "Panel_å©êœ"
        Me.Panel_å©êœ.Size = New System.Drawing.Size(986, 372)
        Me.Panel_å©êœ.TabIndex = 26
        '
        'Number039
        '
        Me.Number039.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number039.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number039.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number039.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number039.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number039.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number039.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number039.Enabled = False
        Me.Number039.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number039.HighlightText = True
        Me.Number039.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number039.Location = New System.Drawing.Point(868, 340)
        Me.Number039.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number039.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number039.Name = "Number039"
        Me.Number039.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number039.Size = New System.Drawing.Size(104, 20)
        Me.Number039.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number039.TabIndex = 1818
        Me.Number039.TabStop = False
        Me.Number039.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number039.Value = New Decimal(New Integer() {39, 0, 0, 0})
        Me.Number039.Visible = False
        '
        'Number029
        '
        Me.Number029.BackColor = System.Drawing.SystemColors.Control
        Me.Number029.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number029.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number029.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number029.Enabled = False
        Me.Number029.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.HighlightText = True
        Me.Number029.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number029.Location = New System.Drawing.Point(868, 320)
        Me.Number029.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number029.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number029.Name = "Number029"
        Me.Number029.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number029.Size = New System.Drawing.Size(104, 20)
        Me.Number029.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.TabIndex = 1817
        Me.Number029.TabStop = False
        Me.Number029.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number029.Value = New Decimal(New Integer() {29, 0, 0, 0})
        '
        'Number019
        '
        Me.Number019.BackColor = System.Drawing.SystemColors.Control
        Me.Number019.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number019.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number019.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number019.Enabled = False
        Me.Number019.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.HighlightText = True
        Me.Number019.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number019.Location = New System.Drawing.Point(868, 300)
        Me.Number019.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number019.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number019.Name = "Number019"
        Me.Number019.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number019.Size = New System.Drawing.Size(104, 20)
        Me.Number019.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.TabIndex = 1816
        Me.Number019.TabStop = False
        Me.Number019.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number019.Value = New Decimal(New Integer() {19, 0, 0, 0})
        '
        'Number016
        '
        Me.Number016.BackColor = System.Drawing.SystemColors.Control
        Me.Number016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number016.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number016.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number016.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number016.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number016.Enabled = False
        Me.Number016.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number016.HighlightText = True
        Me.Number016.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number016.Location = New System.Drawing.Point(704, 300)
        Me.Number016.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number016.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number016.Name = "Number016"
        Me.Number016.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number016.Size = New System.Drawing.Size(52, 20)
        Me.Number016.TabIndex = 1736
        Me.Number016.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number016.Value = Nothing
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.Color.Navy
        Me.Label133.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label133.ForeColor = System.Drawing.Color.White
        Me.Label133.Location = New System.Drawing.Point(392, 340)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(52, 20)
        Me.Label133.TabIndex = 1757
        Me.Label133.Text = "ÉRÉXÉg"
        Me.Label133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.Navy
        Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label132.ForeColor = System.Drawing.Color.White
        Me.Label132.Location = New System.Drawing.Point(392, 300)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(52, 20)
        Me.Label132.TabIndex = 1756
        Me.Label132.Text = "åvè„äz"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number015
        '
        Me.Number015.BackColor = System.Drawing.SystemColors.Control
        Me.Number015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number015.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number015.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number015.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number015.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number015.Enabled = False
        Me.Number015.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number015.HighlightText = True
        Me.Number015.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number015.Location = New System.Drawing.Point(652, 300)
        Me.Number015.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number015.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number015.Name = "Number015"
        Me.Number015.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number015.Size = New System.Drawing.Size(52, 20)
        Me.Number015.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number015.TabIndex = 1735
        Me.Number015.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number015.Value = Nothing
        '
        'Number025
        '
        Me.Number025.BackColor = System.Drawing.SystemColors.Control
        Me.Number025.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number025.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number025.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number025.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number025.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number025.Enabled = False
        Me.Number025.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number025.HighlightText = True
        Me.Number025.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number025.Location = New System.Drawing.Point(652, 320)
        Me.Number025.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number025.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number025.Name = "Number025"
        Me.Number025.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number025.Size = New System.Drawing.Size(52, 20)
        Me.Number025.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number025.TabIndex = 1742
        Me.Number025.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number025.Value = Nothing
        '
        'Number024
        '
        Me.Number024.BackColor = System.Drawing.SystemColors.Control
        Me.Number024.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number024.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number024.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number024.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number024.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number024.Enabled = False
        Me.Number024.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number024.HighlightText = True
        Me.Number024.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number024.Location = New System.Drawing.Point(600, 320)
        Me.Number024.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number024.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number024.Name = "Number024"
        Me.Number024.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number024.Size = New System.Drawing.Size(52, 20)
        Me.Number024.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number024.TabIndex = 1741
        Me.Number024.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number024.Value = Nothing
        '
        'Number017
        '
        Me.Number017.BackColor = System.Drawing.SystemColors.Control
        Me.Number017.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number017.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number017.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number017.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number017.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number017.Enabled = False
        Me.Number017.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number017.HighlightText = True
        Me.Number017.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number017.Location = New System.Drawing.Point(756, 300)
        Me.Number017.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number017.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number017.Name = "Number017"
        Me.Number017.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number017.Size = New System.Drawing.Size(52, 20)
        Me.Number017.TabIndex = 1737
        Me.Number017.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number017.Value = Nothing
        '
        'Number040
        '
        Me.Number040.BackColor = System.Drawing.SystemColors.Control
        Me.Number040.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number040.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number040.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number040.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number040.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number040.Enabled = False
        Me.Number040.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number040.HighlightText = True
        Me.Number040.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number040.Location = New System.Drawing.Point(336, 276)
        Me.Number040.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number040.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number040.Name = "Number040"
        Me.Number040.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number040.Size = New System.Drawing.Size(104, 20)
        Me.Number040.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number040.TabIndex = 1762
        Me.Number040.TabStop = False
        Me.Number040.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number040.Value = Nothing
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(868, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 20)
        Me.Label11.TabIndex = 1763
        Me.Label11.Text = "êfífóøÅiÉLÉÉÉìÉZÉãÅj"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number032
        '
        Me.Number032.BackColor = System.Drawing.SystemColors.Control
        Me.Number032.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number032.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number032.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number032.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number032.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number032.Enabled = False
        Me.Number032.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number032.HighlightText = True
        Me.Number032.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number032.Location = New System.Drawing.Point(496, 340)
        Me.Number032.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number032.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number032.Name = "Number032"
        Me.Number032.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number032.Size = New System.Drawing.Size(52, 20)
        Me.Number032.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number032.TabIndex = 1746
        Me.Number032.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number032.Value = Nothing
        '
        'Number012
        '
        Me.Number012.BackColor = System.Drawing.SystemColors.Control
        Me.Number012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number012.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number012.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number012.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number012.Enabled = False
        Me.Number012.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number012.HighlightText = True
        Me.Number012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number012.Location = New System.Drawing.Point(496, 300)
        Me.Number012.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number012.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number012.Name = "Number012"
        Me.Number012.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number012.Size = New System.Drawing.Size(52, 20)
        Me.Number012.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.TabIndex = 1732
        Me.Number012.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number012.Value = Nothing
        '
        'Number031
        '
        Me.Number031.BackColor = System.Drawing.SystemColors.Control
        Me.Number031.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number031.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number031.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number031.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number031.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number031.Enabled = False
        Me.Number031.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number031.HighlightText = True
        Me.Number031.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number031.Location = New System.Drawing.Point(444, 340)
        Me.Number031.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number031.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number031.Name = "Number031"
        Me.Number031.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number031.Size = New System.Drawing.Size(52, 20)
        Me.Number031.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number031.TabIndex = 1745
        Me.Number031.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number031.Value = Nothing
        '
        'Number022
        '
        Me.Number022.BackColor = System.Drawing.SystemColors.Control
        Me.Number022.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number022.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number022.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number022.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number022.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number022.Enabled = False
        Me.Number022.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number022.HighlightText = True
        Me.Number022.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number022.Location = New System.Drawing.Point(496, 320)
        Me.Number022.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number022.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number022.Name = "Number022"
        Me.Number022.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number022.Size = New System.Drawing.Size(52, 20)
        Me.Number022.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number022.TabIndex = 1739
        Me.Number022.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number022.Value = Nothing
        '
        'Number011
        '
        Me.Number011.BackColor = System.Drawing.SystemColors.Control
        Me.Number011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number011.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number011.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number011.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number011.Enabled = False
        Me.Number011.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number011.HighlightText = True
        Me.Number011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number011.Location = New System.Drawing.Point(444, 300)
        Me.Number011.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number011.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number011.Name = "Number011"
        Me.Number011.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number011.Size = New System.Drawing.Size(52, 20)
        Me.Number011.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.TabIndex = 1731
        Me.Number011.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number011.Value = Nothing
        '
        'Number014
        '
        Me.Number014.BackColor = System.Drawing.SystemColors.Control
        Me.Number014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number014.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number014.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number014.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number014.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number014.Enabled = False
        Me.Number014.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number014.HighlightText = True
        Me.Number014.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number014.Location = New System.Drawing.Point(600, 300)
        Me.Number014.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number014.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number014.Name = "Number014"
        Me.Number014.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number014.Size = New System.Drawing.Size(52, 20)
        Me.Number014.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number014.TabIndex = 1734
        Me.Number014.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number014.Value = Nothing
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.Color.Navy
        Me.Label131.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label131.ForeColor = System.Drawing.Color.White
        Me.Label131.Location = New System.Drawing.Point(808, 280)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(52, 20)
        Me.Label131.TabIndex = 1755
        Me.Label131.Text = "çáÅ@åv"
        Me.Label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label130
        '
        Me.Label130.BackColor = System.Drawing.Color.Navy
        Me.Label130.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label130.ForeColor = System.Drawing.Color.White
        Me.Label130.Location = New System.Drawing.Point(756, 280)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(52, 20)
        Me.Label130.TabIndex = 1754
        Me.Label130.Text = "è¡îÔê≈"
        Me.Label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label129
        '
        Me.Label129.BackColor = System.Drawing.Color.Navy
        Me.Label129.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label129.ForeColor = System.Drawing.Color.White
        Me.Label129.Location = New System.Drawing.Point(652, 280)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(52, 20)
        Me.Label129.TabIndex = 1753
        Me.Label129.Text = "ëóÅ@óø"
        Me.Label129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label128
        '
        Me.Label128.BackColor = System.Drawing.Color.Navy
        Me.Label128.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label128.ForeColor = System.Drawing.Color.White
        Me.Label128.Location = New System.Drawing.Point(600, 280)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(52, 20)
        Me.Label128.TabIndex = 1752
        Me.Label128.Text = "ÇªÇÃëº"
        Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number021
        '
        Me.Number021.BackColor = System.Drawing.SystemColors.Control
        Me.Number021.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number021.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number021.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number021.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number021.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number021.Enabled = False
        Me.Number021.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number021.HighlightText = True
        Me.Number021.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number021.Location = New System.Drawing.Point(444, 320)
        Me.Number021.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number021.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number021.Name = "Number021"
        Me.Number021.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number021.Size = New System.Drawing.Size(52, 20)
        Me.Number021.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number021.TabIndex = 1738
        Me.Number021.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number021.Value = Nothing
        '
        'Number033
        '
        Me.Number033.BackColor = System.Drawing.SystemColors.Control
        Me.Number033.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number033.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number033.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number033.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number033.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number033.Enabled = False
        Me.Number033.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number033.HighlightText = True
        Me.Number033.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number033.Location = New System.Drawing.Point(548, 340)
        Me.Number033.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number033.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number033.Name = "Number033"
        Me.Number033.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number033.Size = New System.Drawing.Size(52, 20)
        Me.Number033.TabIndex = 1747
        Me.Number033.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number033.Value = Nothing
        '
        'Label22_1
        '
        Me.Label22_1.BackColor = System.Drawing.Color.Navy
        Me.Label22_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22_1.ForeColor = System.Drawing.Color.White
        Me.Label22_1.Location = New System.Drawing.Point(444, 280)
        Me.Label22_1.Name = "Label22_1"
        Me.Label22_1.Size = New System.Drawing.Size(52, 20)
        Me.Label22_1.TabIndex = 1760
        Me.Label22_1.Text = "ãZèp"
        Me.Label22_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23_1
        '
        Me.Label23_1.BackColor = System.Drawing.Color.Navy
        Me.Label23_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23_1.ForeColor = System.Drawing.Color.White
        Me.Label23_1.Location = New System.Drawing.Point(548, 280)
        Me.Label23_1.Name = "Label23_1"
        Me.Label23_1.Size = New System.Drawing.Size(52, 20)
        Me.Label23_1.TabIndex = 1761
        Me.Label23_1.Text = "ïîïi"
        Me.Label23_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number037
        '
        Me.Number037.BackColor = System.Drawing.SystemColors.Control
        Me.Number037.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number037.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number037.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number037.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number037.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number037.Enabled = False
        Me.Number037.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number037.HighlightText = True
        Me.Number037.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number037.Location = New System.Drawing.Point(756, 340)
        Me.Number037.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number037.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number037.Name = "Number037"
        Me.Number037.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number037.Size = New System.Drawing.Size(52, 20)
        Me.Number037.TabIndex = 1751
        Me.Number037.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number037.Value = Nothing
        '
        'Number036
        '
        Me.Number036.BackColor = System.Drawing.SystemColors.Control
        Me.Number036.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number036.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number036.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number036.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number036.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number036.Enabled = False
        Me.Number036.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number036.HighlightText = True
        Me.Number036.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number036.Location = New System.Drawing.Point(704, 340)
        Me.Number036.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number036.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number036.Name = "Number036"
        Me.Number036.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number036.Size = New System.Drawing.Size(52, 20)
        Me.Number036.TabIndex = 1750
        Me.Number036.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number036.Value = Nothing
        '
        'Number035
        '
        Me.Number035.BackColor = System.Drawing.SystemColors.Control
        Me.Number035.DisabledForeColor = System.Drawing.Color.Black
        Me.Number035.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number035.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number035.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number035.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number035.Enabled = False
        Me.Number035.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number035.HighlightText = True
        Me.Number035.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number035.Location = New System.Drawing.Point(652, 340)
        Me.Number035.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number035.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number035.Name = "Number035"
        Me.Number035.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number035.Size = New System.Drawing.Size(52, 20)
        Me.Number035.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number035.TabIndex = 1749
        Me.Number035.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number035.Value = Nothing
        '
        'Number034
        '
        Me.Number034.BackColor = System.Drawing.SystemColors.Control
        Me.Number034.DisabledForeColor = System.Drawing.Color.Black
        Me.Number034.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number034.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number034.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number034.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number034.Enabled = False
        Me.Number034.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number034.HighlightText = True
        Me.Number034.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number034.Location = New System.Drawing.Point(600, 340)
        Me.Number034.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number034.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number034.Name = "Number034"
        Me.Number034.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number034.Size = New System.Drawing.Size(52, 20)
        Me.Number034.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number034.TabIndex = 1748
        Me.Number034.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number034.Value = Nothing
        '
        'Label191
        '
        Me.Label191.BackColor = System.Drawing.Color.Navy
        Me.Label191.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label191.ForeColor = System.Drawing.Color.White
        Me.Label191.Location = New System.Drawing.Point(392, 320)
        Me.Label191.Name = "Label191"
        Me.Label191.Size = New System.Drawing.Size(52, 20)
        Me.Label191.TabIndex = 1759
        Me.Label191.Text = "EUâøäi"
        Me.Label191.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number023
        '
        Me.Number023.BackColor = System.Drawing.SystemColors.Control
        Me.Number023.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number023.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number023.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number023.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number023.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number023.Enabled = False
        Me.Number023.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number023.HighlightText = True
        Me.Number023.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number023.Location = New System.Drawing.Point(548, 320)
        Me.Number023.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number023.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number023.Name = "Number023"
        Me.Number023.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number023.Size = New System.Drawing.Size(52, 20)
        Me.Number023.TabIndex = 1740
        Me.Number023.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number023.Value = Nothing
        '
        'Number013
        '
        Me.Number013.BackColor = System.Drawing.SystemColors.Control
        Me.Number013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number013.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number013.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number013.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number013.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number013.Enabled = False
        Me.Number013.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number013.HighlightText = True
        Me.Number013.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number013.Location = New System.Drawing.Point(548, 300)
        Me.Number013.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number013.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number013.Name = "Number013"
        Me.Number013.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number013.Size = New System.Drawing.Size(52, 20)
        Me.Number013.TabIndex = 1733
        Me.Number013.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number013.Value = Nothing
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.Color.Navy
        Me.Label138.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label138.ForeColor = System.Drawing.Color.White
        Me.Label138.Location = New System.Drawing.Point(704, 280)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(52, 20)
        Me.Label138.TabIndex = 1758
        Me.Label138.Text = "è¨åv"
        Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number027
        '
        Me.Number027.BackColor = System.Drawing.SystemColors.Control
        Me.Number027.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number027.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number027.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number027.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number027.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number027.Enabled = False
        Me.Number027.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number027.HighlightText = True
        Me.Number027.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number027.Location = New System.Drawing.Point(756, 320)
        Me.Number027.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number027.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number027.Name = "Number027"
        Me.Number027.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number027.Size = New System.Drawing.Size(52, 20)
        Me.Number027.TabIndex = 1744
        Me.Number027.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number027.Value = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(496, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 1767
        Me.Label1.Text = "AP SE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number038
        '
        Me.Number038.BackColor = System.Drawing.SystemColors.Control
        Me.Number038.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number038.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number038.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number038.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number038.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number038.Enabled = False
        Me.Number038.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number038.HighlightText = True
        Me.Number038.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number038.Location = New System.Drawing.Point(808, 340)
        Me.Number038.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number038.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number038.Name = "Number038"
        Me.Number038.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number038.Size = New System.Drawing.Size(52, 20)
        Me.Number038.TabIndex = 1766
        Me.Number038.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number038.Value = Nothing
        '
        'Number028
        '
        Me.Number028.BackColor = System.Drawing.SystemColors.Control
        Me.Number028.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number028.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number028.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number028.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number028.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number028.Enabled = False
        Me.Number028.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number028.HighlightText = True
        Me.Number028.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number028.Location = New System.Drawing.Point(808, 320)
        Me.Number028.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number028.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number028.Name = "Number028"
        Me.Number028.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number028.Size = New System.Drawing.Size(52, 20)
        Me.Number028.TabIndex = 1765
        Me.Number028.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number028.Value = Nothing
        '
        'Number018
        '
        Me.Number018.BackColor = System.Drawing.SystemColors.Control
        Me.Number018.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number018.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number018.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number018.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number018.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number018.Enabled = False
        Me.Number018.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number018.HighlightText = True
        Me.Number018.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number018.Location = New System.Drawing.Point(808, 300)
        Me.Number018.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number018.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number018.Name = "Number018"
        Me.Number018.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number018.Size = New System.Drawing.Size(52, 20)
        Me.Number018.TabIndex = 1764
        Me.Number018.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number018.Value = Nothing
        '
        'Number026
        '
        Me.Number026.BackColor = System.Drawing.SystemColors.Control
        Me.Number026.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number026.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number026.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number026.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number026.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number026.Enabled = False
        Me.Number026.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number026.HighlightText = True
        Me.Number026.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number026.Location = New System.Drawing.Point(704, 320)
        Me.Number026.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number026.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number026.Name = "Number026"
        Me.Number026.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number026.Size = New System.Drawing.Size(52, 20)
        Me.Number026.TabIndex = 1743
        Me.Number026.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number026.Value = Nothing
        '
        'Button_M001
        '
        Me.Button_M001.BackColor = System.Drawing.SystemColors.Control
        Me.Button_M001.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_M001.Enabled = False
        Me.Button_M001.Location = New System.Drawing.Point(904, 8)
        Me.Button_M001.Name = "Button_M001"
        Me.Button_M001.Size = New System.Drawing.Size(72, 20)
        Me.Button_M001.TabIndex = 965
        Me.Button_M001.Text = "ïîïiì¸óÕ"
        '
        'Panel_M1
        '
        Me.Panel_M1.AutoScroll = True
        Me.Panel_M1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_M1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_M1.Location = New System.Drawing.Point(88, 28)
        Me.Panel_M1.Name = "Panel_M1"
        Me.Panel_M1.Size = New System.Drawing.Size(488, 104)
        Me.Panel_M1.TabIndex = 921
        '
        'Edit_M004
        '
        Me.Edit_M004.AcceptsReturn = True
        Me.Edit_M004.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_M004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M004.LengthAsByte = True
        Me.Edit_M004.Location = New System.Drawing.Point(88, 268)
        Me.Edit_M004.Multiline = True
        Me.Edit_M004.Name = "Edit_M004"
        Me.Edit_M004.ReadOnly = True
        Me.Edit_M004.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit_M004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_M004.Size = New System.Drawing.Size(248, 92)
        Me.Edit_M004.TabIndex = 928
        Me.Edit_M004.TabStop = False
        '
        'Edit_M003
        '
        Me.Edit_M003.AcceptsReturn = True
        Me.Edit_M003.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_M003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M003.LengthAsByte = True
        Me.Edit_M003.Location = New System.Drawing.Point(88, 192)
        Me.Edit_M003.Multiline = True
        Me.Edit_M003.Name = "Edit_M003"
        Me.Edit_M003.ReadOnly = True
        Me.Edit_M003.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit_M003.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_M003.Size = New System.Drawing.Size(460, 76)
        Me.Edit_M003.TabIndex = 927
        Me.Edit_M003.TabStop = False
        '
        'Edit_M002
        '
        Me.Edit_M002.AcceptsReturn = True
        Me.Edit_M002.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_M002.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M002.LengthAsByte = True
        Me.Edit_M002.Location = New System.Drawing.Point(88, 132)
        Me.Edit_M002.Multiline = True
        Me.Edit_M002.Name = "Edit_M002"
        Me.Edit_M002.ReadOnly = True
        Me.Edit_M002.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit_M002.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_M002.Size = New System.Drawing.Size(488, 60)
        Me.Edit_M002.TabIndex = 923
        Me.Edit_M002.TabStop = False
        '
        'Edit_M001
        '
        Me.Edit_M001.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_M001.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M001.Enabled = False
        Me.Edit_M001.HighlightText = True
        Me.Edit_M001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_M001.LengthAsByte = True
        Me.Edit_M001.Location = New System.Drawing.Point(604, 4)
        Me.Edit_M001.MaxLength = 20
        Me.Edit_M001.Name = "Edit_M001"
        Me.Edit_M001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_M001.Size = New System.Drawing.Size(200, 20)
        Me.Edit_M001.TabIndex = 910
        Me.Edit_M001.TabStop = False
        Me.Edit_M001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label12_1
        '
        Me.Label12_1.BackColor = System.Drawing.Color.Navy
        Me.Label12_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12_1.ForeColor = System.Drawing.Color.White
        Me.Label12_1.Location = New System.Drawing.Point(4, 28)
        Me.Label12_1.Name = "Label12_1"
        Me.Label12_1.Size = New System.Drawing.Size(84, 164)
        Me.Label12_1.TabIndex = 893
        Me.Label12_1.Text = "å©êœì‡óe"
        Me.Label12_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13_1
        '
        Me.Label13_1.BackColor = System.Drawing.Color.Navy
        Me.Label13_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13_1.ForeColor = System.Drawing.Color.White
        Me.Label13_1.Location = New System.Drawing.Point(4, 192)
        Me.Label13_1.Name = "Label13_1"
        Me.Label13_1.Size = New System.Drawing.Size(84, 76)
        Me.Label13_1.TabIndex = 895
        Me.Label13_1.Text = "ÉRÉÅÉìÉg"
        Me.Label13_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14_1
        '
        Me.Label14_1.BackColor = System.Drawing.Color.Navy
        Me.Label14_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14_1.ForeColor = System.Drawing.Color.White
        Me.Label14_1.Location = New System.Drawing.Point(4, 268)
        Me.Label14_1.Name = "Label14_1"
        Me.Label14_1.Size = New System.Drawing.Size(84, 92)
        Me.Label14_1.TabIndex = 896
        Me.Label14_1.Text = "âèúòAóç"
        Me.Label14_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_M01
        '
        Me.Label_M01.BackColor = System.Drawing.Color.Navy
        Me.Label_M01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_M01.ForeColor = System.Drawing.Color.White
        Me.Label_M01.Location = New System.Drawing.Point(520, 4)
        Me.Label_M01.Name = "Label_M01"
        Me.Label_M01.Size = New System.Drawing.Size(84, 20)
        Me.Label_M01.TabIndex = 901
        Me.Label_M01.Text = "ÉÅÅ[ÉJÅ[èCóùáÇ"
        Me.Label_M01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_M001
        '
        Me.Combo_M001.AutoDropDown = True
        Me.Combo_M001.AutoSelect = True
        Me.Combo_M001.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_M001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_M001.Enabled = False
        Me.Combo_M001.Location = New System.Drawing.Point(88, 4)
        Me.Combo_M001.MaxDropDownItems = 40
        Me.Combo_M001.Name = "Combo_M001"
        Me.Combo_M001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_M001.Size = New System.Drawing.Size(200, 20)
        Me.Combo_M001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_M001.TabIndex = 964
        Me.Combo_M001.TabStop = False
        Me.Combo_M001.Value = "Combo_M001"
        '
        'Label_M02
        '
        Me.Label_M02.BackColor = System.Drawing.Color.Navy
        Me.Label_M02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_M02.ForeColor = System.Drawing.Color.White
        Me.Label_M02.Location = New System.Drawing.Point(4, 4)
        Me.Label_M02.Name = "Label_M02"
        Me.Label_M02.Size = New System.Drawing.Size(84, 20)
        Me.Label_M02.TabIndex = 958
        Me.Label_M02.Text = "å©êœíSìñ"
        Me.Label_M02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33_1
        '
        Me.Label33_1.BackColor = System.Drawing.Color.Navy
        Me.Label33_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33_1.ForeColor = System.Drawing.Color.White
        Me.Label33_1.Location = New System.Drawing.Point(580, 28)
        Me.Label33_1.Name = "Label33_1"
        Me.Label33_1.Size = New System.Drawing.Size(24, 240)
        Me.Label33_1.TabIndex = 950
        Me.Label33_1.Text = "å©êœïîïi"
        Me.Label33_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGrid_M1
        '
        Me.DataGrid_M1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid_M1.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.DataGrid_M1.CaptionFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid_M1.CaptionForeColor = System.Drawing.Color.Black
        Me.DataGrid_M1.CaptionText = "å©êœïîïi"
        Me.DataGrid_M1.CaptionVisible = False
        Me.DataGrid_M1.DataMember = ""
        Me.DataGrid_M1.HeaderFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid_M1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid_M1.Location = New System.Drawing.Point(604, 28)
        Me.DataGrid_M1.Name = "DataGrid_M1"
        Me.DataGrid_M1.ReadOnly = True
        Me.DataGrid_M1.RowHeaderWidth = 0
        Me.DataGrid_M1.Size = New System.Drawing.Size(372, 240)
        Me.DataGrid_M1.TabIndex = 941
        Me.DataGrid_M1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid_M1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid_M1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T04_REP_PART"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "ïîïiî‘çÜ"
        Me.DataGridTextBoxColumn1.MappingName = "part_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 120
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "ïîïiñº"
        Me.DataGridTextBoxColumn2.MappingName = "part_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 135
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "##,##0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "íPâø"
        Me.DataGridTextBoxColumn3.MappingName = "part_amnt"
        Me.DataGridTextBoxColumn3.Width = 40
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "êîó "
        Me.DataGridTextBoxColumn4.MappingName = "use_qty"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 40
        '
        'Label_M04
        '
        Me.Label_M04.BackColor = System.Drawing.Color.Navy
        Me.Label_M04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_M04.ForeColor = System.Drawing.Color.White
        Me.Label_M04.Location = New System.Drawing.Point(296, 4)
        Me.Label_M04.Name = "Label_M04"
        Me.Label_M04.Size = New System.Drawing.Size(84, 20)
        Me.Label_M04.TabIndex = 1504
        Me.Label_M04.Text = "ìÔà’ìx"
        Me.Label_M04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_M003
        '
        Me.Combo_M003.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_M003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_M003.Enabled = False
        Me.Combo_M003.Location = New System.Drawing.Point(380, 4)
        Me.Combo_M003.MaxDropDownItems = 40
        Me.Combo_M003.Name = "Combo_M003"
        Me.Combo_M003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_M003.Size = New System.Drawing.Size(132, 20)
        Me.Combo_M003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_M003.TabIndex = 1503
        Me.Combo_M003.Value = "Combo_M003"
        '
        'CheckBox_M001
        '
        Me.CheckBox_M001.AutoCheck = False
        Me.CheckBox_M001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox_M001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_M001.Location = New System.Drawing.Point(340, 304)
        Me.CheckBox_M001.Name = "CheckBox_M001"
        Me.CheckBox_M001.Size = New System.Drawing.Size(48, 52)
        Me.CheckBox_M001.TabIndex = 1854
        Me.CheckBox_M001.TabStop = False
        Me.CheckBox_M001.Text = "é©ìÆåvéZâèú"
        '
        'Button80
        '
        Me.Button80.BackColor = System.Drawing.SystemColors.Control
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Enabled = False
        Me.Button80.Location = New System.Drawing.Point(840, 684)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(72, 24)
        Me.Button80.TabIndex = 1020
        Me.Button80.TabStop = False
        Me.Button80.Text = "óöó"
        '
        'Button0
        '
        Me.Button0.BackColor = System.Drawing.SystemColors.Control
        Me.Button0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button0.Location = New System.Drawing.Point(168, 8)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(28, 20)
        Me.Button0.TabIndex = 1
        Me.Button0.TabStop = False
        Me.Button0.Text = "ÅH"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(924, 684)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1030
        Me.Button98.Text = "ñﬂÇÈ"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 684)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1000
        Me.Button1.Text = "çXêV"
        '
        'Panel_äÆóπ
        '
        Me.Panel_äÆóπ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_äÆóπ.Controls.Add(Me.CLK004)
        Me.Panel_äÆóπ.Controls.Add(Me.Edit_K004)
        Me.Panel_äÆóπ.Controls.Add(Me.Label62)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK001_BRH)
        Me.Panel_äÆóπ.Controls.Add(Me.Edit_K003)
        Me.Panel_äÆóπ.Controls.Add(Me.Label59)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK001)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK002)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK003)
        Me.Panel_äÆóπ.Controls.Add(Me.Label50)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K003)
        Me.Panel_äÆóπ.Controls.Add(Me.CheckBox_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.Label_K02)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K002)
        Me.Panel_äÆóπ.Controls.Add(Me.Number1)
        Me.Panel_äÆóπ.Controls.Add(Me.Label19)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K004)
        Me.Panel_äÆóπ.Controls.Add(Me.Button_S2)
        Me.Panel_äÆóπ.Controls.Add(Me.Number116)
        Me.Panel_äÆóπ.Controls.Add(Me.Label3)
        Me.Panel_äÆóπ.Controls.Add(Me.Label12)
        Me.Panel_äÆóπ.Controls.Add(Me.Number115)
        Me.Panel_äÆóπ.Controls.Add(Me.Number125)
        Me.Panel_äÆóπ.Controls.Add(Me.Number124)
        Me.Panel_äÆóπ.Controls.Add(Me.Number117)
        Me.Panel_äÆóπ.Controls.Add(Me.Number132)
        Me.Panel_äÆóπ.Controls.Add(Me.Number112)
        Me.Panel_äÆóπ.Controls.Add(Me.Number131)
        Me.Panel_äÆóπ.Controls.Add(Me.Number122)
        Me.Panel_äÆóπ.Controls.Add(Me.Number111)
        Me.Panel_äÆóπ.Controls.Add(Me.Number114)
        Me.Panel_äÆóπ.Controls.Add(Me.Label22)
        Me.Panel_äÆóπ.Controls.Add(Me.Label23)
        Me.Panel_äÆóπ.Controls.Add(Me.Label24)
        Me.Panel_äÆóπ.Controls.Add(Me.Label25)
        Me.Panel_äÆóπ.Controls.Add(Me.Number121)
        Me.Panel_äÆóπ.Controls.Add(Me.Number133)
        Me.Panel_äÆóπ.Controls.Add(Me.Label26)
        Me.Panel_äÆóπ.Controls.Add(Me.Label27)
        Me.Panel_äÆóπ.Controls.Add(Me.Number137)
        Me.Panel_äÆóπ.Controls.Add(Me.Number136)
        Me.Panel_äÆóπ.Controls.Add(Me.Number135)
        Me.Panel_äÆóπ.Controls.Add(Me.Number134)
        Me.Panel_äÆóπ.Controls.Add(Me.Label29)
        Me.Panel_äÆóπ.Controls.Add(Me.Number123)
        Me.Panel_äÆóπ.Controls.Add(Me.Number113)
        Me.Panel_äÆóπ.Controls.Add(Me.Label30)
        Me.Panel_äÆóπ.Controls.Add(Me.Number127)
        Me.Panel_äÆóπ.Controls.Add(Me.Label31)
        Me.Panel_äÆóπ.Controls.Add(Me.Number138)
        Me.Panel_äÆóπ.Controls.Add(Me.Number128)
        Me.Panel_äÆóπ.Controls.Add(Me.Number118)
        Me.Panel_äÆóπ.Controls.Add(Me.Number126)
        Me.Panel_äÆóπ.Controls.Add(Me.Label_K01)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.Button_K002)
        Me.Panel_äÆóπ.Controls.Add(Me.Panel_K1)
        Me.Panel_äÆóπ.Controls.Add(Me.Edit_K002)
        Me.Panel_äÆóπ.Controls.Add(Me.Edit_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.Label16_1)
        Me.Panel_äÆóπ.Controls.Add(Me.Label15_1)
        Me.Panel_äÆóπ.Controls.Add(Me.Label34_1)
        Me.Panel_äÆóπ.Controls.Add(Me.DataGrid_K1)
        Me.Panel_äÆóπ.Controls.Add(Me.Button_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.Panel1)
        Me.Panel_äÆóπ.Controls.Add(Me.CheckBox_K002)
        Me.Panel_äÆóπ.Location = New System.Drawing.Point(8, 288)
        Me.Panel_äÆóπ.Name = "Panel_äÆóπ"
        Me.Panel_äÆóπ.Size = New System.Drawing.Size(986, 372)
        Me.Panel_äÆóπ.TabIndex = 5
        Me.Panel_äÆóπ.TabStop = True
        '
        'CLK004
        '
        Me.CLK004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK004.Location = New System.Drawing.Point(944, 320)
        Me.CLK004.Name = "CLK004"
        Me.CLK004.Size = New System.Drawing.Size(36, 16)
        Me.CLK004.TabIndex = 1870
        Me.CLK004.Text = "CLK004"
        Me.CLK004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLK004.Visible = False
        '
        'Edit_K004
        '
        Me.Edit_K004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_K004.Format = "9#aA"
        Me.Edit_K004.HighlightText = True
        Me.Edit_K004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_K004.LengthAsByte = True
        Me.Edit_K004.Location = New System.Drawing.Point(88, 272)
        Me.Edit_K004.MaxLength = 25
        Me.Edit_K004.Name = "Edit_K004"
        Me.Edit_K004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_K004.Size = New System.Drawing.Size(212, 20)
        Me.Edit_K004.TabIndex = 41
        Me.Edit_K004.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.Navy
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label62.ForeColor = System.Drawing.Color.White
        Me.Label62.Location = New System.Drawing.Point(4, 272)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(84, 20)
        Me.Label62.TabIndex = 1869
        Me.Label62.Text = "êVS/N"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLK001_BRH
        '
        Me.CLK001_BRH.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK001_BRH.Location = New System.Drawing.Point(528, 28)
        Me.CLK001_BRH.Name = "CLK001_BRH"
        Me.CLK001_BRH.Size = New System.Drawing.Size(80, 16)
        Me.CLK001_BRH.TabIndex = 1849
        Me.CLK001_BRH.Text = "CLK001_BRH"
        Me.CLK001_BRH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLK001_BRH.Visible = False
        '
        'Edit_K003
        '
        Me.Edit_K003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_K003.Format = "9#aA"
        Me.Edit_K003.HighlightText = True
        Me.Edit_K003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_K003.LengthAsByte = True
        Me.Edit_K003.Location = New System.Drawing.Point(664, 4)
        Me.Edit_K003.MaxLength = 15
        Me.Edit_K003.Name = "Edit_K003"
        Me.Edit_K003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_K003.Size = New System.Drawing.Size(132, 20)
        Me.Edit_K003.TabIndex = 17
        Me.Edit_K003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Navy
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label59.ForeColor = System.Drawing.Color.White
        Me.Label59.Location = New System.Drawing.Point(588, 4)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(76, 20)
        Me.Label59.TabIndex = 1867
        Me.Label59.Text = "SB/êVIMEI"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLK001
        '
        Me.CLK001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK001.Location = New System.Drawing.Point(212, 8)
        Me.CLK001.Name = "CLK001"
        Me.CLK001.Size = New System.Drawing.Size(48, 16)
        Me.CLK001.TabIndex = 1814
        Me.CLK001.Text = "CLK001"
        Me.CLK001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLK001.Visible = False
        '
        'CLK002
        '
        Me.CLK002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK002.Location = New System.Drawing.Point(508, 8)
        Me.CLK002.Name = "CLK002"
        Me.CLK002.Size = New System.Drawing.Size(48, 16)
        Me.CLK002.TabIndex = 1839
        Me.CLK002.Text = "CLK002"
        Me.CLK002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLK002.Visible = False
        '
        'CLK003
        '
        Me.CLK003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK003.Location = New System.Drawing.Point(944, 284)
        Me.CLK003.Name = "CLK003"
        Me.CLK003.Size = New System.Drawing.Size(36, 16)
        Me.CLK003.TabIndex = 1863
        Me.CLK003.Text = "CLK003"
        Me.CLK003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLK003.Visible = False
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Navy
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(864, 280)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(108, 20)
        Me.Label50.TabIndex = 1862
        Me.Label50.Text = "åvè„QG"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_K003
        '
        Me.Combo_K003.AutoSelect = True
        Me.Combo_K003.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_K003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_K003.Enabled = False
        Me.Combo_K003.Location = New System.Drawing.Point(864, 300)
        Me.Combo_K003.MaxDropDownItems = 20
        Me.Combo_K003.Name = "Combo_K003"
        Me.Combo_K003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_K003.Size = New System.Drawing.Size(108, 20)
        Me.Combo_K003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K003.TabIndex = 1861
        Me.Combo_K003.Value = "Combo_K003"
        '
        'CheckBox_K001
        '
        Me.CheckBox_K001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox_K001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_K001.Location = New System.Drawing.Point(340, 304)
        Me.CheckBox_K001.Name = "CheckBox_K001"
        Me.CheckBox_K001.Size = New System.Drawing.Size(48, 52)
        Me.CheckBox_K001.TabIndex = 1854
        Me.CheckBox_K001.TabStop = False
        Me.CheckBox_K001.Text = "é©ìÆåvéZâèú"
        '
        'Label_K02
        '
        Me.Label_K02.BackColor = System.Drawing.Color.Navy
        Me.Label_K02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_K02.ForeColor = System.Drawing.Color.White
        Me.Label_K02.Location = New System.Drawing.Point(288, 4)
        Me.Label_K02.Name = "Label_K02"
        Me.Label_K02.Size = New System.Drawing.Size(120, 20)
        Me.Label_K02.TabIndex = 1837
        Me.Label_K02.Text = "ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóø"
        Me.Label_K02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_K002
        '
        Me.Combo_K002.AutoSelect = True
        Me.Combo_K002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_K002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_K002.Location = New System.Drawing.Point(408, 4)
        Me.Combo_K002.MaxDropDownItems = 20
        Me.Combo_K002.Name = "Combo_K002"
        Me.Combo_K002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_K002.Size = New System.Drawing.Size(172, 20)
        Me.Combo_K002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K002.TabIndex = 15
        Me.Combo_K002.Value = "Combo_K002"
        '
        'Number1
        '
        Me.Number1.DisabledForeColor = System.Drawing.Color.Black
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number1.Enabled = False
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number1.HighlightText = True
        Me.Number1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number1.Location = New System.Drawing.Point(956, 272)
        Me.Number1.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(20, 20)
        Me.Number1.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.TabIndex = 1835
        Me.Number1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number1.Value = Nothing
        Me.Number1.Visible = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(864, 320)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 20)
        Me.Label19.TabIndex = 1834
        Me.Label19.Text = "ì¸ã‡éÌï "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_K004
        '
        Me.Combo_K004.AutoSelect = True
        Me.Combo_K004.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_K004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_K004.Location = New System.Drawing.Point(864, 340)
        Me.Combo_K004.MaxDropDownItems = 20
        Me.Combo_K004.Name = "Combo_K004"
        Me.Combo_K004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_K004.Size = New System.Drawing.Size(108, 20)
        Me.Combo_K004.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K004.TabIndex = 110
        Me.Combo_K004.Value = "Combo_K004"
        '
        'Button_S2
        '
        Me.Button_S2.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S2.Location = New System.Drawing.Point(548, 196)
        Me.Button_S2.Name = "Button_S2"
        Me.Button_S2.Size = New System.Drawing.Size(28, 20)
        Me.Button_S2.TabIndex = 50
        Me.Button_S2.TabStop = False
        Me.Button_S2.Text = "ÅH"
        '
        'Number116
        '
        Me.Number116.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number116.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number116.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number116.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number116.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number116.Enabled = False
        Me.Number116.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number116.HighlightText = True
        Me.Number116.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number116.Location = New System.Drawing.Point(704, 300)
        Me.Number116.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number116.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number116.Name = "Number116"
        Me.Number116.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number116.Size = New System.Drawing.Size(52, 20)
        Me.Number116.TabIndex = 1736
        Me.Number116.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number116.Value = New Decimal(New Integer() {116, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(392, 340)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 20)
        Me.Label3.TabIndex = 1757
        Me.Label3.Text = "ÉRÉXÉg"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(392, 300)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 20)
        Me.Label12.TabIndex = 1756
        Me.Label12.Text = "åvè„äz"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number115
        '
        Me.Number115.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number115.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number115.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number115.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number115.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number115.Enabled = False
        Me.Number115.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number115.HighlightText = True
        Me.Number115.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number115.Location = New System.Drawing.Point(652, 300)
        Me.Number115.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number115.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number115.Name = "Number115"
        Me.Number115.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number115.Size = New System.Drawing.Size(52, 20)
        Me.Number115.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number115.TabIndex = 1735
        Me.Number115.TabStop = False
        Me.Number115.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number115.Value = New Decimal(New Integer() {115, 0, 0, 0})
        '
        'Number125
        '
        Me.Number125.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number125.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number125.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number125.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number125.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number125.Enabled = False
        Me.Number125.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number125.HighlightText = True
        Me.Number125.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number125.Location = New System.Drawing.Point(652, 320)
        Me.Number125.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number125.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number125.Name = "Number125"
        Me.Number125.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number125.Size = New System.Drawing.Size(52, 20)
        Me.Number125.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number125.TabIndex = 1742
        Me.Number125.TabStop = False
        Me.Number125.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number125.Value = New Decimal(New Integer() {125, 0, 0, 0})
        '
        'Number124
        '
        Me.Number124.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number124.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number124.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number124.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number124.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number124.Enabled = False
        Me.Number124.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number124.HighlightText = True
        Me.Number124.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number124.Location = New System.Drawing.Point(600, 320)
        Me.Number124.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number124.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number124.Name = "Number124"
        Me.Number124.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number124.Size = New System.Drawing.Size(52, 20)
        Me.Number124.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number124.TabIndex = 1741
        Me.Number124.TabStop = False
        Me.Number124.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number124.Value = New Decimal(New Integer() {124, 0, 0, 0})
        '
        'Number117
        '
        Me.Number117.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number117.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number117.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number117.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number117.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number117.Enabled = False
        Me.Number117.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number117.HighlightText = True
        Me.Number117.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number117.Location = New System.Drawing.Point(756, 300)
        Me.Number117.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number117.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number117.Name = "Number117"
        Me.Number117.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number117.Size = New System.Drawing.Size(52, 20)
        Me.Number117.TabIndex = 1737
        Me.Number117.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number117.Value = New Decimal(New Integer() {117, 0, 0, 0})
        '
        'Number132
        '
        Me.Number132.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number132.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number132.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number132.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number132.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number132.Enabled = False
        Me.Number132.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number132.HighlightText = True
        Me.Number132.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number132.Location = New System.Drawing.Point(496, 340)
        Me.Number132.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number132.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number132.Name = "Number132"
        Me.Number132.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number132.Size = New System.Drawing.Size(52, 20)
        Me.Number132.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number132.TabIndex = 70
        Me.Number132.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number132.Value = New Decimal(New Integer() {132, 0, 0, 0})
        '
        'Number112
        '
        Me.Number112.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number112.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number112.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number112.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number112.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number112.Enabled = False
        Me.Number112.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number112.HighlightText = True
        Me.Number112.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number112.Location = New System.Drawing.Point(496, 300)
        Me.Number112.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number112.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number112.Name = "Number112"
        Me.Number112.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number112.Size = New System.Drawing.Size(52, 20)
        Me.Number112.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number112.TabIndex = 1732
        Me.Number112.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number112.Value = New Decimal(New Integer() {112, 0, 0, 0})
        '
        'Number131
        '
        Me.Number131.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number131.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number131.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number131.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number131.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number131.Enabled = False
        Me.Number131.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number131.HighlightText = True
        Me.Number131.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number131.Location = New System.Drawing.Point(444, 340)
        Me.Number131.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number131.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number131.Name = "Number131"
        Me.Number131.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number131.Size = New System.Drawing.Size(52, 20)
        Me.Number131.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number131.TabIndex = 60
        Me.Number131.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number131.Value = New Decimal(New Integer() {131, 0, 0, 0})
        '
        'Number122
        '
        Me.Number122.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number122.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number122.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number122.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number122.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number122.Enabled = False
        Me.Number122.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number122.HighlightText = True
        Me.Number122.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number122.Location = New System.Drawing.Point(496, 320)
        Me.Number122.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number122.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number122.Name = "Number122"
        Me.Number122.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number122.Size = New System.Drawing.Size(52, 20)
        Me.Number122.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number122.TabIndex = 1739
        Me.Number122.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number122.Value = New Decimal(New Integer() {122, 0, 0, 0})
        '
        'Number111
        '
        Me.Number111.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number111.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number111.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number111.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number111.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number111.Enabled = False
        Me.Number111.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number111.HighlightText = True
        Me.Number111.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number111.Location = New System.Drawing.Point(444, 300)
        Me.Number111.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number111.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number111.Name = "Number111"
        Me.Number111.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number111.Size = New System.Drawing.Size(52, 20)
        Me.Number111.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number111.TabIndex = 1731
        Me.Number111.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number111.Value = New Decimal(New Integer() {111, 0, 0, 0})
        '
        'Number114
        '
        Me.Number114.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number114.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number114.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number114.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number114.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number114.Enabled = False
        Me.Number114.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number114.HighlightText = True
        Me.Number114.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number114.Location = New System.Drawing.Point(600, 300)
        Me.Number114.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number114.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number114.Name = "Number114"
        Me.Number114.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number114.Size = New System.Drawing.Size(52, 20)
        Me.Number114.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number114.TabIndex = 1734
        Me.Number114.TabStop = False
        Me.Number114.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number114.Value = New Decimal(New Integer() {114, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(808, 280)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 20)
        Me.Label22.TabIndex = 1755
        Me.Label22.Text = "çáÅ@åv"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Navy
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(756, 280)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 20)
        Me.Label23.TabIndex = 1754
        Me.Label23.Text = "è¡îÔê≈"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(652, 280)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 20)
        Me.Label24.TabIndex = 1753
        Me.Label24.Text = "ëóÅ@óø"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(600, 280)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 20)
        Me.Label25.TabIndex = 1752
        Me.Label25.Text = "ÇªÇÃëº"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number121
        '
        Me.Number121.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number121.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number121.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number121.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number121.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number121.Enabled = False
        Me.Number121.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number121.HighlightText = True
        Me.Number121.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number121.Location = New System.Drawing.Point(444, 320)
        Me.Number121.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number121.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number121.Name = "Number121"
        Me.Number121.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number121.Size = New System.Drawing.Size(52, 20)
        Me.Number121.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number121.TabIndex = 1738
        Me.Number121.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number121.Value = New Decimal(New Integer() {121, 0, 0, 0})
        '
        'Number133
        '
        Me.Number133.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number133.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number133.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number133.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number133.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number133.Enabled = False
        Me.Number133.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number133.HighlightText = True
        Me.Number133.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number133.Location = New System.Drawing.Point(548, 340)
        Me.Number133.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number133.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number133.Name = "Number133"
        Me.Number133.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number133.Size = New System.Drawing.Size(52, 20)
        Me.Number133.TabIndex = 80
        Me.Number133.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number133.Value = New Decimal(New Integer() {133, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(444, 280)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 20)
        Me.Label26.TabIndex = 1760
        Me.Label26.Text = "ãZèp"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Navy
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(548, 280)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 20)
        Me.Label27.TabIndex = 1761
        Me.Label27.Text = "ïîïi"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number137
        '
        Me.Number137.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number137.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number137.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number137.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number137.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number137.Enabled = False
        Me.Number137.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number137.HighlightText = True
        Me.Number137.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number137.Location = New System.Drawing.Point(756, 340)
        Me.Number137.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number137.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number137.Name = "Number137"
        Me.Number137.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number137.Size = New System.Drawing.Size(52, 20)
        Me.Number137.TabIndex = 1751
        Me.Number137.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number137.Value = New Decimal(New Integer() {137, 0, 0, 0})
        '
        'Number136
        '
        Me.Number136.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number136.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number136.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number136.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number136.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number136.Enabled = False
        Me.Number136.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number136.HighlightText = True
        Me.Number136.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number136.Location = New System.Drawing.Point(704, 340)
        Me.Number136.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number136.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number136.Name = "Number136"
        Me.Number136.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number136.Size = New System.Drawing.Size(52, 20)
        Me.Number136.TabIndex = 1750
        Me.Number136.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number136.Value = New Decimal(New Integer() {136, 0, 0, 0})
        '
        'Number135
        '
        Me.Number135.DisabledForeColor = System.Drawing.Color.Black
        Me.Number135.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number135.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number135.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number135.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number135.Enabled = False
        Me.Number135.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number135.HighlightText = True
        Me.Number135.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number135.Location = New System.Drawing.Point(652, 340)
        Me.Number135.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number135.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number135.Name = "Number135"
        Me.Number135.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number135.Size = New System.Drawing.Size(52, 20)
        Me.Number135.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number135.TabIndex = 100
        Me.Number135.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number135.Value = New Decimal(New Integer() {135, 0, 0, 0})
        '
        'Number134
        '
        Me.Number134.DisabledForeColor = System.Drawing.Color.Black
        Me.Number134.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number134.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number134.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number134.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number134.Enabled = False
        Me.Number134.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number134.HighlightText = True
        Me.Number134.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number134.Location = New System.Drawing.Point(600, 340)
        Me.Number134.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number134.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number134.Name = "Number134"
        Me.Number134.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number134.Size = New System.Drawing.Size(52, 20)
        Me.Number134.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number134.TabIndex = 90
        Me.Number134.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number134.Value = New Decimal(New Integer() {134, 0, 0, 0})
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(392, 320)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(52, 20)
        Me.Label29.TabIndex = 1759
        Me.Label29.Text = "EUâøäi"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number123
        '
        Me.Number123.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number123.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number123.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number123.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number123.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number123.Enabled = False
        Me.Number123.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number123.HighlightText = True
        Me.Number123.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number123.Location = New System.Drawing.Point(548, 320)
        Me.Number123.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number123.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number123.Name = "Number123"
        Me.Number123.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number123.Size = New System.Drawing.Size(52, 20)
        Me.Number123.TabIndex = 1740
        Me.Number123.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number123.Value = New Decimal(New Integer() {123, 0, 0, 0})
        '
        'Number113
        '
        Me.Number113.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number113.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number113.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number113.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number113.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number113.Enabled = False
        Me.Number113.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number113.HighlightText = True
        Me.Number113.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number113.Location = New System.Drawing.Point(548, 300)
        Me.Number113.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number113.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number113.Name = "Number113"
        Me.Number113.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number113.Size = New System.Drawing.Size(52, 20)
        Me.Number113.TabIndex = 1733
        Me.Number113.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number113.Value = New Decimal(New Integer() {113, 0, 0, 0})
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(704, 280)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(52, 20)
        Me.Label30.TabIndex = 1758
        Me.Label30.Text = "è¨åv"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number127
        '
        Me.Number127.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number127.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number127.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number127.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number127.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number127.Enabled = False
        Me.Number127.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number127.HighlightText = True
        Me.Number127.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number127.Location = New System.Drawing.Point(756, 320)
        Me.Number127.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number127.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number127.Name = "Number127"
        Me.Number127.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number127.Size = New System.Drawing.Size(52, 20)
        Me.Number127.TabIndex = 1744
        Me.Number127.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number127.Value = New Decimal(New Integer() {127, 0, 0, 0})
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Navy
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(496, 280)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 20)
        Me.Label31.TabIndex = 1767
        Me.Label31.Text = "AP SE"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number138
        '
        Me.Number138.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number138.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number138.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number138.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number138.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number138.Enabled = False
        Me.Number138.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number138.HighlightText = True
        Me.Number138.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number138.Location = New System.Drawing.Point(808, 340)
        Me.Number138.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number138.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number138.Name = "Number138"
        Me.Number138.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number138.Size = New System.Drawing.Size(52, 20)
        Me.Number138.TabIndex = 1766
        Me.Number138.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number138.Value = New Decimal(New Integer() {138, 0, 0, 0})
        '
        'Number128
        '
        Me.Number128.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number128.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number128.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number128.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number128.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number128.Enabled = False
        Me.Number128.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number128.HighlightText = True
        Me.Number128.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number128.Location = New System.Drawing.Point(808, 320)
        Me.Number128.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number128.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number128.Name = "Number128"
        Me.Number128.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number128.Size = New System.Drawing.Size(52, 20)
        Me.Number128.TabIndex = 1765
        Me.Number128.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number128.Value = New Decimal(New Integer() {128, 0, 0, 0})
        '
        'Number118
        '
        Me.Number118.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number118.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number118.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number118.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number118.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number118.Enabled = False
        Me.Number118.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number118.HighlightText = True
        Me.Number118.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number118.Location = New System.Drawing.Point(808, 300)
        Me.Number118.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number118.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number118.Name = "Number118"
        Me.Number118.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number118.Size = New System.Drawing.Size(52, 20)
        Me.Number118.TabIndex = 1764
        Me.Number118.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number118.Value = New Decimal(New Integer() {118, 0, 0, 0})
        '
        'Number126
        '
        Me.Number126.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number126.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number126.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number126.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number126.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number126.Enabled = False
        Me.Number126.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number126.HighlightText = True
        Me.Number126.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number126.Location = New System.Drawing.Point(704, 320)
        Me.Number126.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number126.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number126.Name = "Number126"
        Me.Number126.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number126.Size = New System.Drawing.Size(52, 20)
        Me.Number126.TabIndex = 1743
        Me.Number126.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number126.Value = New Decimal(New Integer() {126, 0, 0, 0})
        '
        'Label_K01
        '
        Me.Label_K01.BackColor = System.Drawing.Color.Navy
        Me.Label_K01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_K01.ForeColor = System.Drawing.Color.White
        Me.Label_K01.Location = New System.Drawing.Point(4, 4)
        Me.Label_K01.Name = "Label_K01"
        Me.Label_K01.Size = New System.Drawing.Size(84, 20)
        Me.Label_K01.TabIndex = 1411
        Me.Label_K01.Text = "èCóùíSìñ"
        Me.Label_K01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_K001
        '
        Me.Combo_K001.AutoSelect = True
        Me.Combo_K001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_K001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_K001.DropDownWidth = 300
        Me.Combo_K001.ListBoxStyle = GrapeCity.Win.Input.Interop.ListBoxStyle.TextWithDescription
        Me.Combo_K001.Location = New System.Drawing.Point(88, 4)
        Me.Combo_K001.MaxDropDownItems = 20
        Me.Combo_K001.Name = "Combo_K001"
        Me.Combo_K001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo_K001.Size = New System.Drawing.Size(192, 20)
        Me.Combo_K001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K001.TabIndex = 10
        Me.Combo_K001.Value = "Combo_K001"
        '
        'Button_K002
        '
        Me.Button_K002.BackColor = System.Drawing.SystemColors.Control
        Me.Button_K002.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_K002.Location = New System.Drawing.Point(16, 40)
        Me.Button_K002.Name = "Button_K002"
        Me.Button_K002.Size = New System.Drawing.Size(64, 20)
        Me.Button_K002.TabIndex = 917
        Me.Button_K002.TabStop = False
        Me.Button_K002.Text = "å©êœï°é "
        '
        'Panel_K1
        '
        Me.Panel_K1.AutoScroll = True
        Me.Panel_K1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_K1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_K1.Location = New System.Drawing.Point(88, 28)
        Me.Panel_K1.Name = "Panel_K1"
        Me.Panel_K1.Size = New System.Drawing.Size(488, 80)
        Me.Panel_K1.TabIndex = 20
        '
        'Edit_K002
        '
        Me.Edit_K002.AcceptsReturn = True
        Me.Edit_K002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit_K002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_K002.LengthAsByte = True
        Me.Edit_K002.Location = New System.Drawing.Point(88, 192)
        Me.Edit_K002.MaxLength = 200
        Me.Edit_K002.Multiline = True
        Me.Edit_K002.Name = "Edit_K002"
        Me.Edit_K002.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit_K002.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_K002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_K002.Size = New System.Drawing.Size(460, 76)
        Me.Edit_K002.TabIndex = 40
        '
        'Edit_K001
        '
        Me.Edit_K001.AcceptsReturn = True
        Me.Edit_K001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit_K001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_K001.LengthAsByte = True
        Me.Edit_K001.Location = New System.Drawing.Point(88, 108)
        Me.Edit_K001.MaxLength = 1000
        Me.Edit_K001.Multiline = True
        Me.Edit_K001.Name = "Edit_K001"
        Me.Edit_K001.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit_K001.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_K001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit_K001.Size = New System.Drawing.Size(488, 84)
        Me.Edit_K001.TabIndex = 30
        '
        'Label16_1
        '
        Me.Label16_1.BackColor = System.Drawing.Color.Navy
        Me.Label16_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16_1.ForeColor = System.Drawing.Color.White
        Me.Label16_1.Location = New System.Drawing.Point(4, 192)
        Me.Label16_1.Name = "Label16_1"
        Me.Label16_1.Size = New System.Drawing.Size(84, 76)
        Me.Label16_1.TabIndex = 898
        Me.Label16_1.Text = "ÉRÉÅÉìÉg"
        Me.Label16_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15_1
        '
        Me.Label15_1.BackColor = System.Drawing.Color.Navy
        Me.Label15_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15_1.ForeColor = System.Drawing.Color.White
        Me.Label15_1.Location = New System.Drawing.Point(4, 28)
        Me.Label15_1.Name = "Label15_1"
        Me.Label15_1.Size = New System.Drawing.Size(84, 164)
        Me.Label15_1.TabIndex = 897
        Me.Label15_1.Text = "åüèÿåãâ       ãyÇ—              èCóùì‡óe"
        Me.Label15_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34_1
        '
        Me.Label34_1.BackColor = System.Drawing.Color.Navy
        Me.Label34_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34_1.ForeColor = System.Drawing.Color.White
        Me.Label34_1.Location = New System.Drawing.Point(580, 28)
        Me.Label34_1.Name = "Label34_1"
        Me.Label34_1.Size = New System.Drawing.Size(24, 240)
        Me.Label34_1.TabIndex = 951
        Me.Label34_1.Text = "äÆóπïîïi"
        Me.Label34_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGrid_K1
        '
        Me.DataGrid_K1.BackColor = System.Drawing.SystemColors.Control
        Me.DataGrid_K1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid_K1.CaptionBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.DataGrid_K1.CaptionFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid_K1.CaptionForeColor = System.Drawing.Color.Black
        Me.DataGrid_K1.CaptionText = "äÆê¨ïîïi"
        Me.DataGrid_K1.CaptionVisible = False
        Me.DataGrid_K1.DataMember = ""
        Me.DataGrid_K1.HeaderFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid_K1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid_K1.Location = New System.Drawing.Point(604, 28)
        Me.DataGrid_K1.Name = "DataGrid_K1"
        Me.DataGrid_K1.ReadOnly = True
        Me.DataGrid_K1.RowHeaderWidth = 0
        Me.DataGrid_K1.Size = New System.Drawing.Size(372, 240)
        Me.DataGrid_K1.TabIndex = 942
        Me.DataGrid_K1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        Me.DataGrid_K1.TabStop = False
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DataGrid_K1
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "T04_REP_PART_2"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "ïîïiî‘çÜ"
        Me.DataGridTextBoxColumn5.MappingName = "part_code"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 120
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "ïîïiñº"
        Me.DataGridTextBoxColumn6.MappingName = "part_name"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 135
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "íPâø"
        Me.DataGridTextBoxColumn7.MappingName = "part_amnt"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 40
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "êîó "
        Me.DataGridTextBoxColumn8.MappingName = "use_qty"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 40
        '
        'Button_K001
        '
        Me.Button_K001.BackColor = System.Drawing.SystemColors.Control
        Me.Button_K001.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_K001.Location = New System.Drawing.Point(912, 8)
        Me.Button_K001.Name = "Button_K001"
        Me.Button_K001.Size = New System.Drawing.Size(64, 20)
        Me.Button_K001.TabIndex = 925
        Me.Button_K001.TabStop = False
        Me.Button_K001.Text = "ïîïiì¸óÕ"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.NumberN013)
        Me.Panel1.Controls.Add(Me.NumberN012)
        Me.Panel1.Controls.Add(Me.NumberN011)
        Me.Panel1.Controls.Add(Me.Label51)
        Me.Panel1.Controls.Add(Me.NumberN015)
        Me.Panel1.Controls.Add(Me.rebate)
        Me.Panel1.Controls.Add(Me.Label49)
        Me.Panel1.Controls.Add(Me.Label48)
        Me.Panel1.Controls.Add(Me.Label47)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.idvd_chrg)
        Me.Panel1.Controls.Add(Me.CHG)
        Me.Panel1.Controls.Add(Me.zero_name)
        Me.Panel1.Controls.Add(Me.zero_code)
        Me.Panel1.Controls.Add(Me.NumberN004)
        Me.Panel1.Controls.Add(Me.NumberN003)
        Me.Panel1.Controls.Add(Me.NumberN005)
        Me.Panel1.Controls.Add(Me.ZH)
        Me.Panel1.Controls.Add(Me.apse)
        Me.Panel1.Controls.Add(Me.NumberN008)
        Me.Panel1.Controls.Add(Me.NumberN007)
        Me.Panel1.Controls.Add(Me.NumberN006)
        Me.Panel1.Location = New System.Drawing.Point(4, 316)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 40)
        Me.Panel1.TabIndex = 1868
        '
        'NumberN013
        '
        Me.NumberN013.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN013.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN013.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN013.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN013.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN013.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN013.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN013.Enabled = False
        Me.NumberN013.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN013.HighlightText = True
        Me.NumberN013.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN013.Location = New System.Drawing.Point(216, 16)
        Me.NumberN013.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumberN013.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.NumberN013.Name = "NumberN013"
        Me.NumberN013.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN013.Size = New System.Drawing.Size(48, 16)
        Me.NumberN013.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN013.TabIndex = 1853
        Me.NumberN013.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN013.Value = Nothing
        Me.NumberN013.Visible = False
        '
        'NumberN012
        '
        Me.NumberN012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN012.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN012.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN012.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN012.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN012.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN012.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN012.Enabled = False
        Me.NumberN012.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN012.HighlightText = True
        Me.NumberN012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN012.Location = New System.Drawing.Point(164, 16)
        Me.NumberN012.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumberN012.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.NumberN012.Name = "NumberN012"
        Me.NumberN012.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN012.Size = New System.Drawing.Size(48, 16)
        Me.NumberN012.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN012.TabIndex = 1852
        Me.NumberN012.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN012.Value = Nothing
        Me.NumberN012.Visible = False
        '
        'NumberN011
        '
        Me.NumberN011.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN011.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN011.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN011.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN011.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN011.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN011.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN011.Enabled = False
        Me.NumberN011.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN011.HighlightText = True
        Me.NumberN011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN011.Location = New System.Drawing.Point(112, 16)
        Me.NumberN011.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumberN011.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.NumberN011.Name = "NumberN011"
        Me.NumberN011.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN011.Size = New System.Drawing.Size(48, 16)
        Me.NumberN011.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN011.TabIndex = 1851
        Me.NumberN011.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN011.Value = Nothing
        Me.NumberN011.Visible = False
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label51.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(268, 4)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(48, 16)
        Me.Label51.TabIndex = 1865
        Me.Label51.Text = "Fujitsuï€"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label51.Visible = False
        '
        'NumberN015
        '
        Me.NumberN015.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN015.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN015.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN015.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN015.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN015.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN015.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN015.Enabled = False
        Me.NumberN015.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN015.HighlightText = True
        Me.NumberN015.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN015.Location = New System.Drawing.Point(268, 16)
        Me.NumberN015.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumberN015.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.NumberN015.Name = "NumberN015"
        Me.NumberN015.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN015.Size = New System.Drawing.Size(48, 16)
        Me.NumberN015.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN015.TabIndex = 1864
        Me.NumberN015.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN015.Value = Nothing
        Me.NumberN015.Visible = False
        '
        'rebate
        '
        Me.rebate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.rebate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rebate.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.rebate.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.rebate.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.rebate.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.rebate.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rebate.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.rebate.Enabled = False
        Me.rebate.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.rebate.HighlightText = True
        Me.rebate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.rebate.Location = New System.Drawing.Point(8, 16)
        Me.rebate.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.rebate.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.rebate.Name = "rebate"
        Me.rebate.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.rebate.Size = New System.Drawing.Size(48, 16)
        Me.rebate.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.rebate.TabIndex = 1850
        Me.rebate.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.rebate.Value = Nothing
        Me.rebate.Visible = False
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label49.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(216, 4)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(48, 16)
        Me.Label49.TabIndex = 1860
        Me.Label49.Text = "“∞∂∞"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label49.Visible = False
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label48.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(164, 4)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(48, 16)
        Me.Label48.TabIndex = 1859
        Me.Label48.Text = "ï€åØâÔé–"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label48.Visible = False
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label47.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(112, 4)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(48, 16)
        Me.Label47.TabIndex = 1858
        Me.Label47.Text = "îÃé–"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label47.Visible = False
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label38.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(60, 4)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(48, 16)
        Me.Label38.TabIndex = 1857
        Me.Label38.Text = "é©å»ïâíS"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label38.Visible = False
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label34.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(8, 4)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(48, 16)
        Me.Label34.TabIndex = 1856
        Me.Label34.Text = "ÿÕﬁ∞ƒ"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label34.Visible = False
        '
        'idvd_chrg
        '
        Me.idvd_chrg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.idvd_chrg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.idvd_chrg.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.idvd_chrg.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.idvd_chrg.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.idvd_chrg.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.idvd_chrg.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.idvd_chrg.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.idvd_chrg.Enabled = False
        Me.idvd_chrg.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.idvd_chrg.HighlightText = True
        Me.idvd_chrg.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.idvd_chrg.Location = New System.Drawing.Point(60, 16)
        Me.idvd_chrg.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.idvd_chrg.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.idvd_chrg.Name = "idvd_chrg"
        Me.idvd_chrg.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.idvd_chrg.Size = New System.Drawing.Size(48, 16)
        Me.idvd_chrg.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.idvd_chrg.TabIndex = 1855
        Me.idvd_chrg.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.idvd_chrg.Value = Nothing
        Me.idvd_chrg.Visible = False
        '
        'CHG
        '
        Me.CHG.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CHG.Location = New System.Drawing.Point(320, 20)
        Me.CHG.Name = "CHG"
        Me.CHG.Size = New System.Drawing.Size(272, 16)
        Me.CHG.TabIndex = 1838
        Me.CHG.Text = "CHG"
        Me.CHG.Visible = False
        '
        'zero_name
        '
        Me.zero_name.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.zero_name.Location = New System.Drawing.Point(372, 4)
        Me.zero_name.Name = "zero_name"
        Me.zero_name.Size = New System.Drawing.Size(104, 16)
        Me.zero_name.TabIndex = 1832
        Me.zero_name.Text = "zero_name"
        Me.zero_name.Visible = False
        '
        'zero_code
        '
        Me.zero_code.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.zero_code.Location = New System.Drawing.Point(320, 4)
        Me.zero_code.Name = "zero_code"
        Me.zero_code.Size = New System.Drawing.Size(48, 16)
        Me.zero_code.TabIndex = 1831
        Me.zero_code.Text = "zero_code"
        Me.zero_code.Visible = False
        '
        'NumberN004
        '
        Me.NumberN004.BackColor = System.Drawing.Color.LightGray
        Me.NumberN004.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN004.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN004.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.000", "", "", "-", "", "", "")
        Me.NumberN004.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN004.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN004.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN004.Enabled = False
        Me.NumberN004.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.000", "", "", "-", "", "", "")
        Me.NumberN004.HighlightText = True
        Me.NumberN004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN004.Location = New System.Drawing.Point(596, 4)
        Me.NumberN004.MaxValue = New Decimal(New Integer() {9999, 0, 0, 196608})
        Me.NumberN004.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN004.Name = "NumberN004"
        Me.NumberN004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN004.Size = New System.Drawing.Size(40, 16)
        Me.NumberN004.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN004.TabIndex = 1817
        Me.NumberN004.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.NumberN004.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN004.Value = Nothing
        Me.NumberN004.Visible = False
        '
        'NumberN003
        '
        Me.NumberN003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN003.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN003.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN003.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN003.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN003.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN003.Enabled = False
        Me.NumberN003.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN003.HighlightText = True
        Me.NumberN003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN003.Location = New System.Drawing.Point(644, 4)
        Me.NumberN003.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN003.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN003.Name = "NumberN003"
        Me.NumberN003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN003.Size = New System.Drawing.Size(48, 16)
        Me.NumberN003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN003.TabIndex = 1816
        Me.NumberN003.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.NumberN003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN003.Value = Nothing
        Me.NumberN003.Visible = False
        '
        'NumberN005
        '
        Me.NumberN005.BackColor = System.Drawing.Color.LightGray
        Me.NumberN005.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN005.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN005.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN005.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN005.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN005.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN005.Enabled = False
        Me.NumberN005.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN005.HighlightText = True
        Me.NumberN005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN005.Location = New System.Drawing.Point(596, 20)
        Me.NumberN005.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumberN005.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN005.Name = "NumberN005"
        Me.NumberN005.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN005.Size = New System.Drawing.Size(40, 16)
        Me.NumberN005.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN005.TabIndex = 1815
        Me.NumberN005.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN005.Value = Nothing
        Me.NumberN005.Visible = False
        '
        'ZH
        '
        Me.ZH.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.ZH.Location = New System.Drawing.Point(796, 20)
        Me.ZH.Name = "ZH"
        Me.ZH.Size = New System.Drawing.Size(40, 16)
        Me.ZH.TabIndex = 1807
        Me.ZH.Text = "ZH"
        Me.ZH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ZH.Visible = False
        '
        'apse
        '
        Me.apse.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.apse.Location = New System.Drawing.Point(696, 4)
        Me.apse.Name = "apse"
        Me.apse.Size = New System.Drawing.Size(40, 16)
        Me.apse.TabIndex = 1812
        Me.apse.Text = "apse"
        Me.apse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.apse.Visible = False
        '
        'NumberN008
        '
        Me.NumberN008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN008.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN008.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN008.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN008.Enabled = False
        Me.NumberN008.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008.HighlightText = True
        Me.NumberN008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN008.Location = New System.Drawing.Point(744, 20)
        Me.NumberN008.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN008.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN008.Name = "NumberN008"
        Me.NumberN008.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN008.Size = New System.Drawing.Size(48, 16)
        Me.NumberN008.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008.TabIndex = 1820
        Me.NumberN008.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.NumberN008.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN008.Value = Nothing
        Me.NumberN008.Visible = False
        '
        'NumberN007
        '
        Me.NumberN007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN007.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN007.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN007.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN007.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN007.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN007.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN007.Enabled = False
        Me.NumberN007.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN007.HighlightText = True
        Me.NumberN007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN007.Location = New System.Drawing.Point(644, 20)
        Me.NumberN007.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN007.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN007.Name = "NumberN007"
        Me.NumberN007.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN007.Size = New System.Drawing.Size(48, 16)
        Me.NumberN007.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN007.TabIndex = 1819
        Me.NumberN007.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.NumberN007.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN007.Value = Nothing
        Me.NumberN007.Visible = False
        '
        'NumberN006
        '
        Me.NumberN006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN006.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN006.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN006.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN006.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN006.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN006.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN006.Enabled = False
        Me.NumberN006.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.NumberN006.HighlightText = True
        Me.NumberN006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN006.Location = New System.Drawing.Point(796, 4)
        Me.NumberN006.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumberN006.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN006.Name = "NumberN006"
        Me.NumberN006.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN006.Size = New System.Drawing.Size(40, 16)
        Me.NumberN006.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN006.TabIndex = 1818
        Me.NumberN006.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN006.Value = Nothing
        Me.NumberN006.Visible = False
        '
        'CheckBox_K002
        '
        Me.CheckBox_K002.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_K002.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_K002.Location = New System.Drawing.Point(16, 300)
        Me.CheckBox_K002.Name = "CheckBox_K002"
        Me.CheckBox_K002.Size = New System.Drawing.Size(184, 16)
        Me.CheckBox_K002.TabIndex = 1904
        Me.CheckBox_K002.Text = "AppleîzëóèCóùÅiP&&DÅj"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(64, 268)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(48, 20)
        Me.Button12.TabIndex = 23
        Me.Button12.TabStop = False
        Me.Button12.Text = "å©êœ"
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Location = New System.Drawing.Point(112, 268)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(48, 20)
        Me.Button13.TabIndex = 24
        Me.Button13.TabStop = False
        Me.Button13.Text = "äÆóπ"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(16, 268)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(48, 20)
        Me.Button11.TabIndex = 22
        Me.Button11.TabStop = False
        Me.Button11.Text = "éÛït"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 664)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(880, 16)
        Me.msg.TabIndex = 1345
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date013
        '
        Me.Date013.BackColor = System.Drawing.SystemColors.Control
        Me.Date013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date013.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date013.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date013.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date013.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date013.Enabled = False
        Me.Date013.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date013.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date013.Location = New System.Drawing.Point(904, 228)
        Me.Date013.Name = "Date013"
        Me.Date013.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date013.Size = New System.Drawing.Size(88, 20)
        Me.Date013.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date013.TabIndex = 1369
        Me.Date013.TabStop = False
        Me.Date013.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date013.Value = Nothing
        '
        'Date011
        '
        Me.Date011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date011.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date011.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date011.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date011.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date011.Enabled = False
        Me.Date011.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date011.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date011.Location = New System.Drawing.Point(904, 188)
        Me.Date011.Name = "Date011"
        Me.Date011.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date011.Size = New System.Drawing.Size(112, 20)
        Me.Date011.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date011.TabIndex = 1366
        Me.Date011.TabStop = False
        Me.Date011.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date011.Value = Nothing
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Navy
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(824, 208)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(80, 20)
        Me.Label45.TabIndex = 1365
        Me.Label45.Text = "èoâ◊ì˙"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date007
        '
        Me.Date007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date007.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date007.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date007.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date007.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date007.Enabled = False
        Me.Date007.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date007.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date007.Location = New System.Drawing.Point(904, 88)
        Me.Date007.Name = "Date007"
        Me.Date007.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date007.Size = New System.Drawing.Size(88, 20)
        Me.Date007.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date007.TabIndex = 1364
        Me.Date007.TabStop = False
        Me.Date007.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date007.Value = Nothing
        '
        'Label016
        '
        Me.Label016.BackColor = System.Drawing.Color.Navy
        Me.Label016.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label016.ForeColor = System.Drawing.Color.White
        Me.Label016.Location = New System.Drawing.Point(824, 108)
        Me.Label016.Name = "Label016"
        Me.Label016.Size = New System.Drawing.Size(80, 20)
        Me.Label016.TabIndex = 1363
        Me.Label016.Text = "ïîïiéÛóÃì˙"
        Me.Label016.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date006
        '
        Me.Date006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date006.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date006.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date006.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date006.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date006.Enabled = False
        Me.Date006.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date006.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date006.Location = New System.Drawing.Point(904, 68)
        Me.Date006.Name = "Date006"
        Me.Date006.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date006.Size = New System.Drawing.Size(88, 20)
        Me.Date006.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date006.TabIndex = 1362
        Me.Date006.TabStop = False
        Me.Date006.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date006.Value = Nothing
        '
        'Label015
        '
        Me.Label015.BackColor = System.Drawing.Color.Navy
        Me.Label015.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label015.ForeColor = System.Drawing.Color.White
        Me.Label015.Location = New System.Drawing.Point(824, 88)
        Me.Label015.Name = "Label015"
        Me.Label015.Size = New System.Drawing.Size(80, 20)
        Me.Label015.TabIndex = 1361
        Me.Label015.Text = "ïîïiî≠íçì˙"
        Me.Label015.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date012
        '
        Me.Date012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date012.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date012.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date012.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date012.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date012.Enabled = False
        Me.Date012.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date012.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date012.Location = New System.Drawing.Point(904, 208)
        Me.Date012.Name = "Date012"
        Me.Date012.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date012.Size = New System.Drawing.Size(112, 20)
        Me.Date012.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date012.TabIndex = 1360
        Me.Date012.TabStop = False
        Me.Date012.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date012.Value = Nothing
        '
        'Date010
        '
        Me.Date010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date010.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date010.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date010.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date010.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date010.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date010.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date010.Location = New System.Drawing.Point(904, 168)
        Me.Date010.Name = "Date010"
        Me.Date010.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date010.Size = New System.Drawing.Size(112, 20)
        Me.Date010.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date010.TabIndex = 1359
        Me.Date010.TabStop = False
        Me.Date010.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date010.Value = Nothing
        '
        'Date008
        '
        Me.Date008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date008.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date008.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date008.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date008.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date008.Enabled = False
        Me.Date008.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date008.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date008.Location = New System.Drawing.Point(904, 108)
        Me.Date008.Name = "Date008"
        Me.Date008.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date008.Size = New System.Drawing.Size(88, 20)
        Me.Date008.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date008.TabIndex = 1357
        Me.Date008.TabStop = False
        Me.Date008.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date008.Value = Nothing
        '
        'Date004
        '
        Me.Date004.BackColor = System.Drawing.SystemColors.Control
        Me.Date004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date004.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date004.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date004.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date004.Enabled = False
        Me.Date004.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date004.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date004.Location = New System.Drawing.Point(904, 48)
        Me.Date004.Name = "Date004"
        Me.Date004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date004.Size = New System.Drawing.Size(88, 20)
        Me.Date004.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date004.TabIndex = 57
        Me.Date004.TabStop = False
        Me.Date004.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date004.Value = Nothing
        '
        'Date003
        '
        Me.Date003.BackColor = System.Drawing.SystemColors.Control
        Me.Date003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date003.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date003.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date003.Enabled = False
        Me.Date003.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date003.Location = New System.Drawing.Point(904, 8)
        Me.Date003.Name = "Date003"
        Me.Date003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date003.Size = New System.Drawing.Size(112, 20)
        Me.Date003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date003.TabIndex = 56
        Me.Date003.TabStop = False
        Me.Date003.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date003.Value = Nothing
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Navy
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(824, 228)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(80, 20)
        Me.Label42.TabIndex = 1353
        Me.Label42.Text = "êøãÅì˙"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Navy
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(652, 268)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(80, 20)
        Me.Label41.TabIndex = 1352
        Me.Label41.Text = "ÉlÉoì`î‘çÜ"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Navy
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(824, 188)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(80, 20)
        Me.Label40.TabIndex = 1351
        Me.Label40.Text = "îÑè„ì˙"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Navy
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(824, 48)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 20)
        Me.Label36.TabIndex = 1347
        Me.Label36.Text = "å©êœì˙"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Navy
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(824, 68)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(80, 20)
        Me.Label37.TabIndex = 1348
        Me.Label37.Text = "âÒìöéÛêMì˙"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(824, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 20)
        Me.Label35.TabIndex = 1346
        Me.Label35.Text = "éÛïtì˙"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Navy
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(824, 168)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(80, 20)
        Me.Label39.TabIndex = 1350
        Me.Label39.Text = "äÆóπì˙"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 1420
        Me.Label4.Text = "∂≈"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit010
        '
        Me.Edit010.BackColor = System.Drawing.SystemColors.Control
        Me.Edit010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(520, 192)
        Me.Edit010.MaxLength = 400
        Me.Edit010.Name = "Edit010"
        Me.Edit010.ReadOnly = True
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(300, 20)
        Me.Edit010.TabIndex = 15
        Me.Edit010.TabStop = False
        Me.Edit010.Text = "Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†"
        Me.Edit010.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit009
        '
        Me.Edit009.BackColor = System.Drawing.SystemColors.Control
        Me.Edit009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit009.HighlightText = True
        Me.Edit009.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit009.LengthAsByte = True
        Me.Edit009.Location = New System.Drawing.Point(520, 172)
        Me.Edit009.MaxLength = 60
        Me.Edit009.Name = "Edit009"
        Me.Edit009.ReadOnly = True
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(300, 20)
        Me.Edit009.TabIndex = 14
        Me.Edit009.TabStop = False
        Me.Edit009.Text = "Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†"
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Mask1
        '
        Me.Mask1.BackColor = System.Drawing.SystemColors.Control
        Me.Mask1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask1.Format = New GrapeCity.Win.Input.Interop.MaskFormat("Åß \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(520, 152)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.ReadOnly = True
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(76, 20)
        Me.Mask1.TabIndex = 13
        Me.Mask1.TabStop = False
        Me.Mask1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask1.Value = ""
        '
        'Label013
        '
        Me.Label013.BackColor = System.Drawing.Color.Navy
        Me.Label013.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label013.ForeColor = System.Drawing.Color.White
        Me.Label013.Location = New System.Drawing.Point(492, 152)
        Me.Label013.Name = "Label013"
        Me.Label013.Size = New System.Drawing.Size(28, 60)
        Me.Label013.TabIndex = 1413
        Me.Label013.Text = "èZèä"
        Me.Label013.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit901
        '
        Me.Edit901.BackColor = System.Drawing.SystemColors.Control
        Me.Edit901.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit901.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit901.LengthAsByte = True
        Me.Edit901.Location = New System.Drawing.Point(536, 8)
        Me.Edit901.Name = "Edit901"
        Me.Edit901.ReadOnly = True
        Me.Edit901.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit901.Size = New System.Drawing.Size(92, 20)
        Me.Edit901.TabIndex = 1412
        Me.Edit901.TabStop = False
        Me.Edit901.Text = "EDIT901"
        Me.Edit901.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit901.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit902
        '
        Me.Edit902.BackColor = System.Drawing.SystemColors.Control
        Me.Edit902.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit902.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit902.LengthAsByte = True
        Me.Edit902.Location = New System.Drawing.Point(628, 8)
        Me.Edit902.Name = "Edit902"
        Me.Edit902.ReadOnly = True
        Me.Edit902.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit902.Size = New System.Drawing.Size(156, 20)
        Me.Edit902.TabIndex = 1411
        Me.Edit902.TabStop = False
        Me.Edit902.Text = "Edit902"
        Me.Edit902.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.Edit902.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(296, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 20)
        Me.Label20.TabIndex = 1409
        Me.Label20.Text = "ì¸â◊íSìñ"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo003
        '
        Me.Combo003.BackColor = System.Drawing.SystemColors.Control
        Me.Combo003.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo003.Enabled = False
        Me.Combo003.Location = New System.Drawing.Point(376, 56)
        Me.Combo003.MaxDropDownItems = 20
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(184, 20)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 4
        Me.Combo003.Value = "Combo003"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Navy
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(16, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 20)
        Me.Label18.TabIndex = 1408
        Me.Label18.Text = "ì¸â◊ãÊï™"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo002
        '
        Me.Combo002.BackColor = System.Drawing.SystemColors.Control
        Me.Combo002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo002.Enabled = False
        Me.Combo002.Location = New System.Drawing.Point(96, 56)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(196, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 3
        Me.Combo002.Value = "Combo002"
        '
        'Edit000
        '
        Me.Edit000.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit000.Format = "A9"
        Me.Edit000.HighlightText = True
        Me.Edit000.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit000.LengthAsByte = True
        Me.Edit000.Location = New System.Drawing.Point(96, 8)
        Me.Edit000.MaxLength = 9
        Me.Edit000.Name = "Edit000"
        Me.Edit000.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit000.Size = New System.Drawing.Size(68, 20)
        Me.Edit000.TabIndex = 0
        Me.Edit000.Text = "AS1234567"
        Me.Edit000.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit000.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 1407
        Me.Label7.Text = "éÛïtéÌï "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.BackColor = System.Drawing.SystemColors.Control
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Enabled = False
        Me.Combo001.Location = New System.Drawing.Point(96, 32)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1
        Me.Combo001.Value = "Combo001"
        '
        'Label014
        '
        Me.Label014.BackColor = System.Drawing.Color.Navy
        Me.Label014.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label014.ForeColor = System.Drawing.Color.White
        Me.Label014.Location = New System.Drawing.Point(16, 216)
        Me.Label014.Name = "Label014"
        Me.Label014.Size = New System.Drawing.Size(80, 20)
        Me.Label014.TabIndex = 1406
        Me.Label014.Text = "èCóùéÌï "
        Me.Label014.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo004
        '
        Me.Combo004.BackColor = System.Drawing.SystemColors.Control
        Me.Combo004.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo004.Enabled = False
        Me.Combo004.Location = New System.Drawing.Point(96, 216)
        Me.Combo004.MaxDropDownItems = 20
        Me.Combo004.Name = "Combo004"
        Me.Combo004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo004.Size = New System.Drawing.Size(164, 20)
        Me.Combo004.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo004.TabIndex = 19
        Me.Combo004.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo004.Value = "Combo004"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(452, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 1401
        Me.Label13.Text = "éÛïtíSìñé“"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label012
        '
        Me.Label012.BackColor = System.Drawing.Color.Navy
        Me.Label012.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label012.ForeColor = System.Drawing.Color.White
        Me.Label012.Location = New System.Drawing.Point(296, 172)
        Me.Label012.Name = "Label012"
        Me.Label012.Size = New System.Drawing.Size(80, 20)
        Me.Label012.TabIndex = 1405
        Me.Label012.Text = "ìdòbî‘çÜ2"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit006
        '
        Me.Edit006.BackColor = System.Drawing.SystemColors.Control
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Format = "KAa"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(96, 172)
        Me.Edit006.MaxLength = 15
        Me.Edit006.Name = "Edit006"
        Me.Edit006.ReadOnly = True
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(196, 20)
        Me.Edit006.TabIndex = 10
        Me.Edit006.TabStop = False
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit008
        '
        Me.Edit008.BackColor = System.Drawing.SystemColors.Control
        Me.Edit008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit008.Format = "9#"
        Me.Edit008.HighlightText = True
        Me.Edit008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit008.LengthAsByte = True
        Me.Edit008.Location = New System.Drawing.Point(376, 172)
        Me.Edit008.MaxLength = 14
        Me.Edit008.Name = "Edit008"
        Me.Edit008.ReadOnly = True
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(112, 20)
        Me.Edit008.TabIndex = 12
        Me.Edit008.TabStop = False
        Me.Edit008.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit007
        '
        Me.Edit007.BackColor = System.Drawing.SystemColors.Control
        Me.Edit007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit007.Format = "9#"
        Me.Edit007.HighlightText = True
        Me.Edit007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit007.LengthAsByte = True
        Me.Edit007.Location = New System.Drawing.Point(376, 152)
        Me.Edit007.MaxLength = 14
        Me.Edit007.Name = "Edit007"
        Me.Edit007.ReadOnly = True
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(112, 20)
        Me.Edit007.TabIndex = 11
        Me.Edit007.TabStop = False
        Me.Edit007.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit005
        '
        Me.Edit005.BackColor = System.Drawing.SystemColors.Control
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(96, 152)
        Me.Edit005.MaxLength = 30
        Me.Edit005.Name = "Edit005"
        Me.Edit005.ReadOnly = True
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(196, 20)
        Me.Edit005.TabIndex = 9
        Me.Edit005.TabStop = False
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label011
        '
        Me.Label011.BackColor = System.Drawing.Color.Navy
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.ForeColor = System.Drawing.Color.White
        Me.Label011.Location = New System.Drawing.Point(296, 152)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(80, 20)
        Me.Label011.TabIndex = 1397
        Me.Label011.Text = "ìdòbî‘çÜ1"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label010
        '
        Me.Label010.BackColor = System.Drawing.Color.Navy
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.ForeColor = System.Drawing.Color.White
        Me.Label010.Location = New System.Drawing.Point(16, 152)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(80, 20)
        Me.Label010.TabIndex = 1396
        Me.Label010.Text = "Ç®ãqólñº"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Navy
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(16, 8)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(80, 20)
        Me.Label43.TabIndex = 1392
        Me.Label43.Text = "éÛïtî‘çÜ"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit004
        '
        Me.Edit004.BackColor = System.Drawing.SystemColors.Control
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.Enabled = False
        Me.Edit004.Format = "9#aA"
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(536, 104)
        Me.Edit004.MaxLength = 25
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(112, 20)
        Me.Edit004.TabIndex = 8
        Me.Edit004.Text = "1234567890123456789012345"
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label006
        '
        Me.Label006.BackColor = System.Drawing.Color.Navy
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.ForeColor = System.Drawing.Color.White
        Me.Label006.Location = New System.Drawing.Point(452, 104)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(84, 20)
        Me.Label006.TabIndex = 1395
        Me.Label006.Text = "îÃé–èCóùî‘çÜ"
        Me.Label006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label005
        '
        Me.Label005.BackColor = System.Drawing.Color.Navy
        Me.Label005.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label005.ForeColor = System.Drawing.Color.White
        Me.Label005.Location = New System.Drawing.Point(16, 104)
        Me.Label005.Name = "Label005"
        Me.Label005.Size = New System.Drawing.Size(80, 20)
        Me.Label005.TabIndex = 1394
        Me.Label005.Text = "î[ì¸êÊ"
        Me.Label005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label003
        '
        Me.Label003.BackColor = System.Drawing.Color.Navy
        Me.Label003.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label003.ForeColor = System.Drawing.Color.White
        Me.Label003.Location = New System.Drawing.Point(16, 80)
        Me.Label003.Name = "Label003"
        Me.Label003.Size = New System.Drawing.Size(80, 20)
        Me.Label003.TabIndex = 1393
        Me.Label003.Text = "îÃé–"
        Me.Label003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BackColor = System.Drawing.Color.Navy
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.ForeColor = System.Drawing.Color.White
        Me.Label004.Location = New System.Drawing.Point(452, 80)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(84, 20)
        Me.Label004.TabIndex = 1398
        Me.Label004.Text = "îÃé–íSìñé“"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit002
        '
        Me.Edit002.AllowSpace = False
        Me.Edit002.BackColor = System.Drawing.SystemColors.Control
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.Enabled = False
        Me.Edit002.Format = "9"
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(96, 104)
        Me.Edit002.MaxLength = 4
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(48, 20)
        Me.Edit002.TabIndex = 7
        Me.Edit002.Text = "9999"
        Me.Edit002.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit001
        '
        Me.Edit001.AllowSpace = False
        Me.Edit001.BackColor = System.Drawing.SystemColors.Control
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Enabled = False
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(96, 80)
        Me.Edit001.MaxLength = 4
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(48, 20)
        Me.Edit001.TabIndex = 5
        Me.Edit001.Text = "9999"
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit003
        '
        Me.Edit003.BackColor = System.Drawing.SystemColors.Control
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.Enabled = False
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(536, 80)
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(112, 20)
        Me.Edit003.TabIndex = 6
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit011
        '
        Me.Edit011.AllowSpace = False
        Me.Edit011.BackColor = System.Drawing.SystemColors.Control
        Me.Edit011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit011.Enabled = False
        Me.Edit011.Format = "9A#"
        Me.Edit011.HighlightText = True
        Me.Edit011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit011.LengthAsByte = True
        Me.Edit011.Location = New System.Drawing.Point(376, 32)
        Me.Edit011.MaxLength = 10
        Me.Edit011.Name = "Edit011"
        Me.Edit011.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit011.Size = New System.Drawing.Size(92, 20)
        Me.Edit011.TabIndex = 1425
        Me.Edit011.Text = "9999"
        Me.Edit011.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Navy
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(296, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 20)
        Me.Label21.TabIndex = 1426
        Me.Label21.Text = "QG Care No"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(472, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 20)
        Me.Label5.TabIndex = 1502
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit012
        '
        Me.Edit012.AllowSpace = False
        Me.Edit012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit012.Format = "9A#"
        Me.Edit012.HighlightText = True
        Me.Edit012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit012.LengthAsByte = True
        Me.Edit012.Location = New System.Drawing.Point(568, 216)
        Me.Edit012.MaxLength = 50
        Me.Edit012.Name = "Edit012"
        Me.Edit012.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit012.Size = New System.Drawing.Size(116, 20)
        Me.Edit012.TabIndex = 4
        Me.Edit012.Text = "9999"
        Me.Edit012.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(460, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 1796
        Me.Label2.Text = "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'calc_cls
        '
        Me.calc_cls.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.calc_cls.Location = New System.Drawing.Point(952, 660)
        Me.calc_cls.Name = "calc_cls"
        Me.calc_cls.Size = New System.Drawing.Size(40, 20)
        Me.calc_cls.TabIndex = 1797
        Me.calc_cls.Text = "1"
        Me.calc_cls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.calc_cls.Visible = False
        '
        'tax_rate
        '
        Me.tax_rate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.tax_rate.Location = New System.Drawing.Point(908, 660)
        Me.tax_rate.Name = "tax_rate"
        Me.tax_rate.Size = New System.Drawing.Size(40, 20)
        Me.tax_rate.TabIndex = 1798
        Me.tax_rate.Text = "1"
        Me.tax_rate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tax_rate.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(688, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 1803
        Me.Label9.Text = "óaÇ©ÇËã‡"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number002
        '
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number002.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number002.HighlightText = True
        Me.Number002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number002.Location = New System.Drawing.Point(768, 216)
        Me.Number002.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number002.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(52, 20)
        Me.Number002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 5
        Me.Number002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number002.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(92, 684)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 1010
        Me.Button2.TabStop = False
        Me.Button2.Text = "ÉNÉäÉA"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(652, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 1809
        Me.Label10.Text = "ï€èÿå¿ìxäz"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number001
        '
        Me.Number001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Number001.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Enabled = False
        Me.Number001.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(772, 12)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(52, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1808
        Me.Number001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number001.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Visible = False
        '
        'Ck_atri_flg
        '
        Me.Ck_atri_flg.AutoCheck = False
        Me.Ck_atri_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Ck_atri_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Ck_atri_flg.Location = New System.Drawing.Point(256, 268)
        Me.Ck_atri_flg.Name = "Ck_atri_flg"
        Me.Ck_atri_flg.Size = New System.Drawing.Size(84, 16)
        Me.Ck_atri_flg.TabIndex = 1811
        Me.Ck_atri_flg.TabStop = False
        Me.Ck_atri_flg.Text = "Ck_atri_flg"
        Me.Ck_atri_flg.Visible = False
        '
        'CK_own_flg
        '
        Me.CK_own_flg.AutoCheck = False
        Me.CK_own_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CK_own_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CK_own_flg.Location = New System.Drawing.Point(168, 268)
        Me.CK_own_flg.Name = "CK_own_flg"
        Me.CK_own_flg.Size = New System.Drawing.Size(84, 16)
        Me.CK_own_flg.TabIndex = 1821
        Me.CK_own_flg.TabStop = False
        Me.CK_own_flg.Text = "CK_own_flg"
        Me.CK_own_flg.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(172, 684)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(76, 24)
        Me.Button5.TabIndex = 1020
        Me.Button5.TabStop = False
        Me.Button5.Text = "çÏã∆ïÒçêèë"
        '
        'Date001
        '
        Me.Date001.BackColor = System.Drawing.SystemColors.Control
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date001.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date001.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Enabled = False
        Me.Date001.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(732, 80)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(88, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1823
        Me.Date001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(652, 80)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(80, 20)
        Me.Label007.TabIndex = 1824
        Me.Label007.Text = "îÃé–éÛïtì˙"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label002
        '
        Me.Label002.BackColor = System.Drawing.SystemColors.Control
        Me.Label002.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label002.Enabled = False
        Me.Label002.HighlightText = True
        Me.Label002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Label002.LengthAsByte = True
        Me.Label002.Location = New System.Drawing.Point(152, 104)
        Me.Label002.MaxLength = 40
        Me.Label002.Name = "Label002"
        Me.Label002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Label002.Size = New System.Drawing.Size(296, 20)
        Me.Label002.TabIndex = 1826
        Me.Label002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label001
        '
        Me.Label001.BackColor = System.Drawing.SystemColors.Control
        Me.Label001.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label001.Enabled = False
        Me.Label001.HighlightText = True
        Me.Label001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Label001.LengthAsByte = True
        Me.Label001.Location = New System.Drawing.Point(152, 80)
        Me.Label001.MaxLength = 40
        Me.Label001.Name = "Label001"
        Me.Label001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Label001.Size = New System.Drawing.Size(296, 20)
        Me.Label001.TabIndex = 1825
        Me.Label001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Navy
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(264, 216)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(84, 20)
        Me.Label46.TabIndex = 1830
        Me.Label46.Text = "éñåÃèÛãµ"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo005
        '
        Me.Combo005.BackColor = System.Drawing.SystemColors.Control
        Me.Combo005.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo005.Enabled = False
        Me.Combo005.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Combo005.Location = New System.Drawing.Point(348, 216)
        Me.Combo005.MaxDropDownItems = 20
        Me.Combo005.Name = "Combo005"
        Me.Combo005.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo005.Size = New System.Drawing.Size(108, 20)
        Me.Combo005.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo005.TabIndex = 1829
        Me.Combo005.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo005.Value = "Combo005"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(652, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 20)
        Me.Label15.TabIndex = 1828
        Me.Label15.Text = "ñ∆ê”"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number003
        '
        Me.Number003.BackColor = System.Drawing.SystemColors.Control
        Me.Number003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number003.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number003.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number003.Enabled = False
        Me.Number003.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number003.HighlightText = True
        Me.Number003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number003.Location = New System.Drawing.Point(732, 56)
        Me.Number003.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number003.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number003.Name = "Number003"
        Me.Number003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number003.Size = New System.Drawing.Size(52, 20)
        Me.Number003.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.TabIndex = 1827
        Me.Number003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number003.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(784, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 1831
        Me.Label16.Text = "Åiê≈î≤Åj"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(784, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 16)
        Me.Label17.TabIndex = 1832
        Me.Label17.Text = "Åiê≈çûÅj"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumberN009
        '
        Me.NumberN009.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN009.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN009.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN009.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN009.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN009.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN009.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN009.Enabled = False
        Me.NumberN009.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN009.HighlightText = True
        Me.NumberN009.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN009.Location = New System.Drawing.Point(600, 60)
        Me.NumberN009.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NumberN009.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN009.Name = "NumberN009"
        Me.NumberN009.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.NumberN009.Size = New System.Drawing.Size(48, 16)
        Me.NumberN009.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN009.TabIndex = 1833
        Me.NumberN009.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.NumberN009.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NumberN009.Visible = False
        '
        'kengen
        '
        Me.kengen.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.kengen.Location = New System.Drawing.Point(396, 4)
        Me.kengen.Name = "kengen"
        Me.kengen.Size = New System.Drawing.Size(52, 16)
        Me.kengen.TabIndex = 1835
        Me.kengen.Text = "kengen"
        Me.kengen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.kengen.Visible = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(260, 684)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 1030
        Me.Button6.TabStop = False
        Me.Button6.Text = "î[ïièë"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(344, 684)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(72, 24)
        Me.Button7.TabIndex = 1040
        Me.Button7.TabStop = False
        Me.Button7.Text = "ñ‚çáÇπ"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Navy
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(452, 128)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(84, 20)
        Me.Label28.TabIndex = 1838
        Me.Label28.Text = "îÃé–âÑí∑èÓïÒ"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit013
        '
        Me.Edit013.BackColor = System.Drawing.SystemColors.Control
        Me.Edit013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit013.Enabled = False
        Me.Edit013.HighlightText = True
        Me.Edit013.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit013.LengthAsByte = True
        Me.Edit013.Location = New System.Drawing.Point(536, 128)
        Me.Edit013.MaxLength = 30
        Me.Edit013.Name = "Edit013"
        Me.Edit013.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit013.Size = New System.Drawing.Size(284, 20)
        Me.Edit013.TabIndex = 1837
        Me.Edit013.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'CL004
        '
        Me.CL004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL004.Location = New System.Drawing.Point(188, 220)
        Me.CL004.Name = "CL004"
        Me.CL004.Size = New System.Drawing.Size(52, 16)
        Me.CL004.TabIndex = 1840
        Me.CL004.Text = "CL004"
        Me.CL004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL004.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(596, 684)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1070
        Me.Button3.TabStop = False
        Me.Button3.Text = "ï Noè∆âÔ"
        '
        'GRP
        '
        Me.GRP.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.GRP.Location = New System.Drawing.Point(400, 104)
        Me.GRP.Name = "GRP"
        Me.GRP.Size = New System.Drawing.Size(52, 16)
        Me.GRP.TabIndex = 1844
        Me.GRP.Text = "GRP"
        Me.GRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GRP.Visible = False
        '
        'Number001_nTax
        '
        Me.Number001_nTax.BackColor = System.Drawing.SystemColors.Control
        Me.Number001_nTax.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001_nTax.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number001_nTax.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001_nTax.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001_nTax.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001_nTax.Enabled = False
        Me.Number001_nTax.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number001_nTax.HighlightText = True
        Me.Number001_nTax.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001_nTax.Location = New System.Drawing.Point(732, 32)
        Me.Number001_nTax.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001_nTax.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001_nTax.Name = "Number001_nTax"
        Me.Number001_nTax.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number001_nTax.Size = New System.Drawing.Size(52, 20)
        Me.Number001_nTax.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001_nTax.TabIndex = 1848
        Me.Number001_nTax.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number001_nTax.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(220, 36)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1850
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo006
        '
        Me.Combo006.BackColor = System.Drawing.SystemColors.Control
        Me.Combo006.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo006.Location = New System.Drawing.Point(732, 268)
        Me.Combo006.MaxDropDownItems = 2
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(88, 20)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 1360
        Me.Combo006.TabStop = False
        Me.Combo006.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo006.Value = ""
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Location = New System.Drawing.Point(428, 684)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(72, 24)
        Me.Button8.TabIndex = 1050
        Me.Button8.TabStop = False
        Me.Button8.Text = "ê‘ì`ì¸óÕ"
        '
        'idvd_flg
        '
        Me.idvd_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.idvd_flg.Location = New System.Drawing.Point(344, 104)
        Me.idvd_flg.Name = "idvd_flg"
        Me.idvd_flg.Size = New System.Drawing.Size(52, 16)
        Me.idvd_flg.TabIndex = 1853
        Me.idvd_flg.Text = "idvd_flg"
        Me.idvd_flg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.idvd_flg.Visible = False
        '
        'aka
        '
        Me.aka.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.aka.Location = New System.Drawing.Point(868, 664)
        Me.aka.Name = "aka"
        Me.aka.Size = New System.Drawing.Size(24, 16)
        Me.aka.TabIndex = 1864
        Me.aka.Text = "aka"
        Me.aka.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.aka.Visible = False
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(168, 240)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(84, 20)
        Me.Label52.TabIndex = 1866
        Me.Label52.Text = "MobileéÌï "
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo007
        '
        Me.Combo007.BackColor = System.Drawing.SystemColors.Control
        Me.Combo007.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo007.Enabled = False
        Me.Combo007.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Combo007.Location = New System.Drawing.Point(252, 240)
        Me.Combo007.MaxDropDownItems = 20
        Me.Combo007.Name = "Combo007"
        Me.Combo007.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo007.Size = New System.Drawing.Size(164, 20)
        Me.Combo007.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo007.TabIndex = 1865
        Me.Combo007.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo007.Value = "Combo007"
        '
        'Date014
        '
        Me.Date014.BackColor = System.Drawing.SystemColors.Control
        Me.Date014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date014.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date014.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date014.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date014.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date014.Enabled = False
        Me.Date014.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date014.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date014.Location = New System.Drawing.Point(904, 248)
        Me.Date014.Name = "Date014"
        Me.Date014.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date014.Size = New System.Drawing.Size(88, 20)
        Me.Date014.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date014.TabIndex = 1868
        Me.Date014.TabStop = False
        Me.Date014.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date014.Value = Nothing
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Navy
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label53.ForeColor = System.Drawing.Color.White
        Me.Label53.Location = New System.Drawing.Point(824, 248)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(80, 20)
        Me.Label53.TabIndex = 1867
        Me.Label53.Text = "ì¸ã‡ì˙"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Navy
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label54.ForeColor = System.Drawing.Color.White
        Me.Label54.Location = New System.Drawing.Point(824, 268)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(80, 20)
        Me.Label54.TabIndex = 1870
        Me.Label54.Text = "ñ¢ì¸ã‡äz"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number004
        '
        Me.Number004.BackColor = System.Drawing.SystemColors.Control
        Me.Number004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number004.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number004.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number004.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number004.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number004.Enabled = False
        Me.Number004.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number004.HighlightText = True
        Me.Number004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number004.Location = New System.Drawing.Point(904, 268)
        Me.Number004.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number004.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number004.Name = "Number004"
        Me.Number004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number004.Size = New System.Drawing.Size(88, 20)
        Me.Number004.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number004.TabIndex = 1869
        Me.Number004.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number004.Value = Nothing
        '
        'Label017
        '
        Me.Label017.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label017.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label017.ForeColor = System.Drawing.Color.Green
        Me.Label017.Location = New System.Drawing.Point(204, 4)
        Me.Label017.Name = "Label017"
        Me.Label017.Size = New System.Drawing.Size(132, 24)
        Me.Label017.TabIndex = 1871
        Me.Label017.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(512, 684)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(72, 24)
        Me.Button9.TabIndex = 1060
        Me.Button9.TabStop = False
        Me.Button9.Text = "∫›¿∏ƒ€∏ﬁ"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoCheck = False
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox1.Location = New System.Drawing.Point(428, 132)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(16, 16)
        Me.CheckBox1.TabIndex = 1878
        Me.CheckBox1.TabStop = False
        '
        'cntact2
        '
        Me.cntact2.BackColor = System.Drawing.SystemColors.Control
        Me.cntact2.Location = New System.Drawing.Point(268, 132)
        Me.cntact2.Name = "cntact2"
        Me.cntact2.Size = New System.Drawing.Size(104, 16)
        Me.cntact2.TabIndex = 1877
        Me.cntact2.Text = "cntact2"
        Me.cntact2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cntact1
        '
        Me.cntact1.BackColor = System.Drawing.SystemColors.Control
        Me.cntact1.Location = New System.Drawing.Point(96, 132)
        Me.cntact1.Name = "cntact1"
        Me.cntact1.Size = New System.Drawing.Size(100, 16)
        Me.cntact1.TabIndex = 1876
        Me.cntact1.Text = "cntact1"
        Me.cntact1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(372, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 20)
        Me.Label14.TabIndex = 1875
        Me.Label14.Text = "∫›¿∏ƒäÆóπ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Navy
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(200, 128)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(64, 20)
        Me.Label44.TabIndex = 1874
        Me.Label44.Text = "∫›¿∏ƒíSìñ"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Navy
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label55.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(16, 128)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(80, 20)
        Me.Label55.TabIndex = 1873
        Me.Label55.Text = "ç≈èI∫›¿∏ƒì˙éû"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Navy
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label56.ForeColor = System.Drawing.Color.White
        Me.Label56.Location = New System.Drawing.Point(580, 240)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(108, 20)
        Me.Label56.TabIndex = 1882
        Me.Label56.Text = "iMVî‘çÜ"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit015
        '
        Me.Edit015.AllowSpace = False
        Me.Edit015.BackColor = System.Drawing.Color.Silver
        Me.Edit015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit015.Enabled = False
        Me.Edit015.HighlightText = True
        Me.Edit015.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit015.LengthAsByte = True
        Me.Edit015.Location = New System.Drawing.Point(688, 240)
        Me.Edit015.MaxLength = 9
        Me.Edit015.Name = "Edit015"
        Me.Edit015.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit015.Size = New System.Drawing.Size(80, 20)
        Me.Edit015.TabIndex = 1880
        Me.Edit015.Text = "9999"
        Me.Edit015.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Navy
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label57.ForeColor = System.Drawing.Color.White
        Me.Label57.Location = New System.Drawing.Point(420, 240)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(84, 20)
        Me.Label57.TabIndex = 1881
        Me.Label57.Text = "Ref."
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit014
        '
        Me.Edit014.AllowSpace = False
        Me.Edit014.BackColor = System.Drawing.Color.Silver
        Me.Edit014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit014.Enabled = False
        Me.Edit014.HighlightText = True
        Me.Edit014.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit014.LengthAsByte = True
        Me.Edit014.Location = New System.Drawing.Point(504, 240)
        Me.Edit014.MaxLength = 10
        Me.Edit014.Name = "Edit014"
        Me.Edit014.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit014.Size = New System.Drawing.Size(72, 20)
        Me.Edit014.TabIndex = 1879
        Me.Edit014.Text = "9999"
        Me.Edit014.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit903
        '
        Me.Edit903.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Edit903.Location = New System.Drawing.Point(772, -4)
        Me.Edit903.Name = "Edit903"
        Me.Edit903.Size = New System.Drawing.Size(52, 16)
        Me.Edit903.TabIndex = 1883
        Me.Edit903.Text = "Edit903"
        Me.Edit903.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Edit903.Visible = False
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.Navy
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.ForeColor = System.Drawing.Color.White
        Me.Label60.Location = New System.Drawing.Point(652, 104)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(80, 20)
        Me.Label60.TabIndex = 1885
        Me.Label60.Text = "âﬂé∏"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SBM
        '
        Me.SBM.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.SBM.Location = New System.Drawing.Point(820, 664)
        Me.SBM.Name = "SBM"
        Me.SBM.Size = New System.Drawing.Size(32, 16)
        Me.SBM.TabIndex = 1886
        Me.SBM.Text = "SBM"
        Me.SBM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SBM.Visible = False
        '
        'CkBox01_N
        '
        Me.CkBox01_N.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_N.Location = New System.Drawing.Point(780, 108)
        Me.CkBox01_N.Name = "CkBox01_N"
        Me.CkBox01_N.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_N.TabIndex = 1888
        Me.CkBox01_N.Text = "ñ≥"
        '
        'CkBox01_Y
        '
        Me.CkBox01_Y.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_Y.Location = New System.Drawing.Point(740, 108)
        Me.CkBox01_Y.Name = "CkBox01_Y"
        Me.CkBox01_Y.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_Y.TabIndex = 1887
        Me.CkBox01_Y.Text = "óL"
        '
        'Button97
        '
        Me.Button97.BackColor = System.Drawing.SystemColors.Control
        Me.Button97.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button97.Location = New System.Drawing.Point(760, 684)
        Me.Button97.Name = "Button97"
        Me.Button97.Size = New System.Drawing.Size(68, 24)
        Me.Button97.TabIndex = 1080
        Me.Button97.Text = "S/Nóöó"
        Me.Button97.Visible = False
        '
        'sn_n
        '
        Me.sn_n.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.sn_n.Location = New System.Drawing.Point(760, 664)
        Me.sn_n.Name = "sn_n"
        Me.sn_n.Size = New System.Drawing.Size(48, 16)
        Me.sn_n.TabIndex = 1891
        Me.sn_n.Text = "sn_n"
        Me.sn_n.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.sn_n.Visible = False
        '
        'Date015
        '
        Me.Date015.BackColor = System.Drawing.SystemColors.Control
        Me.Date015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date015.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date015.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date015.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date015.Enabled = False
        Me.Date015.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date015.Location = New System.Drawing.Point(904, 28)
        Me.Date015.Name = "Date015"
        Me.Date015.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date015.Size = New System.Drawing.Size(112, 20)
        Me.Date015.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date015.TabIndex = 1896
        Me.Date015.TabStop = False
        Me.Date015.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date015.Value = Nothing
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Navy
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label63.ForeColor = System.Drawing.Color.White
        Me.Label63.Location = New System.Drawing.Point(824, 28)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(80, 20)
        Me.Label63.TabIndex = 1897
        Me.Label63.Text = "êfífì˙"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date016
        '
        Me.Date016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date016.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date016.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date016.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date016.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date016.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date016.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date016.Location = New System.Drawing.Point(904, 128)
        Me.Date016.Name = "Date016"
        Me.Date016.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date016.Size = New System.Drawing.Size(112, 20)
        Me.Date016.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date016.TabIndex = 1899
        Me.Date016.TabStop = False
        Me.Date016.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date016.Value = Nothing
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Navy
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label64.ForeColor = System.Drawing.Color.White
        Me.Label64.Location = New System.Drawing.Point(824, 128)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(80, 20)
        Me.Label64.TabIndex = 1898
        Me.Label64.Text = "èCóùì˙"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date017
        '
        Me.Date017.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date017.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date017.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date017.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2019, 9, 5, 0, 0, 0, 0))
        Me.Date017.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date017.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date017.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date017.Location = New System.Drawing.Point(904, 148)
        Me.Date017.Name = "Date017"
        Me.Date017.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date017.Size = New System.Drawing.Size(112, 20)
        Me.Date017.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date017.TabIndex = 1900
        Me.Date017.TabStop = False
        Me.Date017.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date017.Value = Nothing
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.Navy
        Me.Label65.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label65.ForeColor = System.Drawing.Color.White
        Me.Label65.Location = New System.Drawing.Point(824, 148)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(80, 20)
        Me.Label65.TabIndex = 1901
        Me.Label65.Text = "äÆóπòAóçì˙"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.Navy
        Me.Label66.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label66.ForeColor = System.Drawing.Color.White
        Me.Label66.Location = New System.Drawing.Point(16, 192)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(80, 20)
        Me.Label66.TabIndex = 1903
        Me.Label66.Text = "email"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit016
        '
        Me.Edit016.BackColor = System.Drawing.SystemColors.Control
        Me.Edit016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit016.HighlightText = True
        Me.Edit016.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit016.LengthAsByte = True
        Me.Edit016.Location = New System.Drawing.Point(96, 192)
        Me.Edit016.MaxLength = 50
        Me.Edit016.Name = "Edit016"
        Me.Edit016.ReadOnly = True
        Me.Edit016.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit016.Size = New System.Drawing.Size(392, 20)
        Me.Edit016.TabIndex = 1902
        Me.Edit016.TabStop = False
        Me.Edit016.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(764, 236)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(60, 24)
        Me.Label67.TabIndex = 1904
        Me.Label67.Text = "AC+êøãÅäzÅiê≈çûÅj"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.SystemColors.Control
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.Location = New System.Drawing.Point(680, 684)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(68, 24)
        Me.Button14.TabIndex = 1071
        Me.Button14.Text = "ï€ë∂"
        '
        'F10_Form21
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1022, 715)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Edit016)
        Me.Controls.Add(Me.Date017)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Date016)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Number004)
        Me.Controls.Add(Me.Date015)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.sn_n)
        Me.Controls.Add(Me.SBM)
        Me.Controls.Add(Me.aka)
        Me.Controls.Add(Me.Button97)
        Me.Controls.Add(Me.CkBox01_N)
        Me.Controls.Add(Me.CkBox01_Y)
        Me.Controls.Add(Me.Panel_äÆóπ)
        Me.Controls.Add(Me.Panel_éÛït)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Edit903)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Edit015)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Edit014)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cntact2)
        Me.Controls.Add(Me.cntact1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label017)
        Me.Controls.Add(Me.Date014)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Combo007)
        Me.Controls.Add(Me.Panel_å©êœ)
        Me.Controls.Add(Me.idvd_flg)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Number001_nTax)
        Me.Controls.Add(Me.GRP)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CL004)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Edit013)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.kengen)
        Me.Controls.Add(Me.NumberN009)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Combo005)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.CK_own_flg)
        Me.Controls.Add(Me.Ck_atri_flg)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.calc_cls)
        Me.Controls.Add(Me.tax_rate)
        Me.Controls.Add(Me.Edit012)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Edit011)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Edit010)
        Me.Controls.Add(Me.Edit009)
        Me.Controls.Add(Me.Mask1)
        Me.Controls.Add(Me.Label013)
        Me.Controls.Add(Me.Edit901)
        Me.Controls.Add(Me.Edit902)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Combo003)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Edit000)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label014)
        Me.Controls.Add(Me.Combo004)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label012)
        Me.Controls.Add(Me.Edit006)
        Me.Controls.Add(Me.Edit008)
        Me.Controls.Add(Me.Edit007)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Date013)
        Me.Controls.Add(Me.Date011)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Date007)
        Me.Controls.Add(Me.Label016)
        Me.Controls.Add(Me.Date006)
        Me.Controls.Add(Me.Label015)
        Me.Controls.Add(Me.Date012)
        Me.Controls.Add(Me.Date010)
        Me.Controls.Add(Me.Date008)
        Me.Controls.Add(Me.Date004)
        Me.Controls.Add(Me.Date003)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button0)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label67)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F10_Form21"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "äÆóπì¸óÕ"
        Me.Panel_éÛït.ResumeLayout(False)
        CType(Me.Date_U004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_U002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_U001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_U002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_U1.ResumeLayout(False)
        CType(Me.Date_U001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_U003, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_å©êœ.ResumeLayout(False)
        CType(Me.Number039, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number016, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number025, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number024, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number017, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number040, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number032, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number031, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number022, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number014, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number021, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number033, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number037, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number036, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number035, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number034, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number023, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number027, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number038, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number028, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number018, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number026, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_äÆóπ.ResumeLayout(False)
        CType(Me.Edit_K004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_K003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_K003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_K002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_K004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number116, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number115, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number125, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number124, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number117, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number132, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number112, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number131, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number122, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number111, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number114, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number121, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number133, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number137, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number136, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number135, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number134, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number123, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number113, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number127, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number138, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number128, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number118, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number126, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_K001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_K002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_K001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid_K1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.NumberN013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rebate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.idvd_chrg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date010, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit901, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit902, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN009, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date014, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date016, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date017, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit016, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  ãNìÆéû
    '********************************************************************
    Private Sub F10_Form21_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()           '**  èâä˙èàóù
        ACES()          '**  å†å¿É`ÉFÉbÉN
        PRT_SET_CHK()   '**  ÉvÉäÉìÉ^É`ÉFÉbÉN
        Cmb1()          '**  åvè„QG
        Cmb5()          '**  ì¸ã‡éÌï 
        If Err_F = "0" Then
            inz_dsp()   '**  èâä˙âÊñ ÉZÉbÉg
            Button13_Click(sender, e)
        Else
            DsList1.Clear()
            Close()
        End If

        If P_DBG = "True" Then 'ÉfÉoÉbÉNï\é¶
            NumberN003.Visible = True : NumberN007.Visible = True
            NumberN006.Visible = True : NumberN008.Visible = True
            apse.Visible = True : ZH.Visible = True
            Number039.Visible = True

            kengen.Visible = True
            Edit903.Visible = True
            aka.Visible = True
            SBM.Visible = True
            GRP.Visible = True
            idvd_flg.Visible = True
            Number001.Visible = True
            CL001.Visible = True
            CL004.Visible = True
            CLU001.Visible = True
            CLU002.Visible = True
            CK_own_flg.Visible = True
            Ck_atri_flg.Visible = True

            CLK001.Visible = True
            CLK001_BRH.Visible = True
            CLK002.Visible = True
            CLK003.Visible = True
            CLK004.Visible = True

            zero_code.Visible = True
            zero_name.Visible = True
            CHG.Visible = True
            Label34.Visible = True : rebate.Visible = True
            Label38.Visible = True : idvd_chrg.Visible = True
            Label47.Visible = True : NumberN011.Visible = True
            Label48.Visible = True : NumberN012.Visible = True
            Label49.Visible = True : NumberN013.Visible = True
            Label51.Visible = True : NumberN015.Visible = True
            sn_n.Visible = True
        End If

    End Sub

    '********************************************************************
    '**  èâä˙èàóù
    '********************************************************************
    Sub inz()
        'Å~ï¬Ç∂ÇÈÇégópïsâ¬
        Date003.MaxDate = "9999/12/31 23:59:59"
        Date001.MaxDate = "9999/12/31 23:59:59"
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        'è¡îÔê≈ó¶
        Wk_TAX = tax_rate_get(Now) 'è¡îÔê≈ó¶éÊìæ
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0

        msg.Text = Nothing
        inz_F = "0"
    End Sub

    Sub tax(ByVal p_date)
        'è¡îÔê≈ó¶
        Wk_TAX = tax_rate_get(p_date) 'è¡îÔê≈ó¶éÊìæ
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0
        tax_rate.Text = Wk_TAX
        sum1_base()
        sum2_base()
        sum3_base()
    End Sub

    '********************************************************************
    '**  å†å¿É`ÉFÉbÉN
    '********************************************************************
    Sub ACES()

        SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = P_ACES_brch_code
        Pram2.Value = P_ACES_post_code
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='121'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            kengen.Text = DtView1(0)("access_cls")
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button1.Enabled = False : Button14.Enabled = False
                Case Is = "3"
                    Button1.Enabled = True : Button14.Enabled = False
                Case Is = "4"
                    Button1.Enabled = True : Button14.Enabled = True
            End Select
        Else
            kengen.Text = Nothing
            Button1.Enabled = False : Button14.Enabled = False
        End If
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='998'", "", DataViewRowState.CurrentRows) 'ê‘ì`
        If DtView1.Count <> 0 Then
            aka.Text = DtView1(0)("access_cls")
        Else
            aka.Text = Nothing
        End If
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='994'", "", DataViewRowState.CurrentRows) 'äÆóπìñì˙èCê≥â¬
        If DtView1.Count <> 0 Then
            SBM.Text = DtView1(0)("access_cls")
        Else
            SBM.Text = Nothing
        End If
    End Sub

    '********************************************************************
    '**  ÉvÉäÉìÉ^É`ÉFÉbÉN
    '********************************************************************
    Sub PRT_SET_CHK()
        Err_F = "0"

        'ÉvÉäÉìÉ^ê›íË
        strSQL = "SELECT * FROM M11_PRINTER WHERE (pc_name = '" & P_PC_NAME & "') AND (print_id >= '02')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "M11_PRINTER")

        DtView1 = New DataView(DsList1.Tables("M11_PRINTER"), "printer_name <> ''", "", DataViewRowState.CurrentRows)
        If DtView1.Count < 4 Then
            MessageBox.Show("àÛç¸Ç∑ÇÈÉvÉäÉìÉ^ÇÃéwíËÇ™Ç≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB", "ÉGÉâÅ[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Err_F = "1"
        End If
    End Sub

    '********************************************************************
    '**  ÉRÉìÉ{É{ÉbÉNÉXÉZÉbÉg
    '********************************************************************
    Sub Cmb1()      'åvè„QG

        DsCMB3.Clear()
        strSQL = "SELECT brch_code, brch_code + ':' + name AS brch_name"
        strSQL += " FROM M03_BRCH"
        strSQL += " WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB3, "M03_BRCH")
        DB_CLOSE()
        Combo_K003.DataSource = DsCMB3.Tables("M03_BRCH")
        Combo_K003.DisplayMember = "brch_name"
        Combo_K003.ValueMember = "brch_code"

    End Sub
    Sub Cmb3()      'èCóùíSìñ
        DsCMB.Clear()

        If CK_own_flg.Checked = True Then    'é©é–èCóù

            'strSQL += " UNION"
            'strSQL += " SELECT M01_EMPL_2.empl_code, M01_EMPL_2.name, M01_EMPL_2.name_kana, '" & P_rpar_comp_code & "' AS brch_code"
            'strSQL += " FROM M01_EMPL AS M01_EMPL_2"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " LEFT OUTER JOIN M02_ATRI AS M02_ATRI_2 ON M01_EMPL_2.empl_code = M02_ATRI_2.empl_code"
            'End If
            'strSQL += " WHERE (M01_EMPL_2.empl_code = " & P_EMPL_NO & ")"
            'strSQL += " AND (M01_EMPL_2.role_code = '02')"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " AND (M02_ATRI_2.vndr_code = '" & CLU001.Text & "')"
            'End If

            'strSQL += " UNION"
            'strSQL += " SELECT T01_REP_MTR_3.repr_empl_code AS empl_code, M01_EMPL_3.name, M01_EMPL_3.name_kana, T01_REP_MTR_3.repr_brch_code AS brch_code"
            'strSQL += " FROM M01_EMPL AS M01_EMPL_3"
            'strSQL += " INNER JOIN T01_REP_MTR AS T01_REP_MTR_3 ON M01_EMPL_3.empl_code = T01_REP_MTR_3.repr_empl_code"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " LEFT OUTER JOIN M02_ATRI AS M02_ATRI_3 ON M01_EMPL_3.empl_code = M02_ATRI_3.empl_code"
            'End If
            'strSQL += " WHERE (T01_REP_MTR_3.rcpt_no = '" & Edit000.Text & "')"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " AND (M02_ATRI_3.vndr_code = '" & CLU001.Text & "')"
            'End If

            strSQL = "SELECT M01_EMPL_00.empl_code, M01_EMPL_00.name, M01_EMPL_00.brch_code, M06_RPAR_COMP.name AS brch_name"
            strSQL += " FROM (SELECT M01_EMPL_1.empl_code, M01_EMPL_1.name, M01_EMPL_1.name_kana, M06_RPAR_COMP_1.rpar_comp_code AS brch_code"
            strSQL += " FROM M03_BRCH AS M03_BRCH_1"
            strSQL += " INNER JOIN M01_EMPL AS M01_EMPL_1 ON M03_BRCH_1.brch_code = M01_EMPL_1.brch_code"
            strSQL += " INNER JOIN M06_RPAR_COMP AS M06_RPAR_COMP_1 ON M03_BRCH_1.brch_code = M06_RPAR_COMP_1.brch_code"
            If Ck_atri_flg.Checked = True Then
                strSQL += " INNER JOIN M02_ATRI AS M02_ATRI_1 ON M01_EMPL_1.empl_code = M02_ATRI_1.empl_code"
            End If
            strSQL += " WHERE (M06_RPAR_COMP_1.rpar_comp_code = '" & DtView1(0)("rpar_comp_code") & "')"
            strSQL += " AND (M01_EMPL_1.role_code = '02')"
            strSQL += " AND (M01_EMPL_1.delt_flg = 0)"
            If Ck_atri_flg.Checked = True Then
                strSQL += " AND (M02_ATRI_1.delt_flg = 0)"
                strSQL += " AND (M02_ATRI_1.vndr_code = '" & CLU001.Text & "')"
            End If
            strSQL += ") AS M01_EMPL_00 INNER JOIN"
            strSQL += " M06_RPAR_COMP ON M01_EMPL_00.brch_code = M06_RPAR_COMP.rpar_comp_code"
            strSQL += " ORDER BY M01_EMPL_00.name_kana"
        Else
            'strSQL = "SELECT M01_EMPL_00.empl_code, M01_EMPL_00.name, M01_EMPL_00.brch_code, M06_RPAR_COMP.name AS brch_name"
            'strSQL += " FROM (SELECT M01_EMPL_1.empl_code, M01_EMPL_1.name, M01_EMPL_1.name_kana, M06_RPAR_COMP.rpar_comp_code AS brch_code"
            'strSQL += " FROM M01_EMPL AS M01_EMPL_1 INNER JOIN M06_RPAR_COMP ON M01_EMPL_1.brch_code = M06_RPAR_COMP.brch_code"
            'strSQL += " WHERE (M01_EMPL_1.delt_flg = 0) AND (M01_EMPL_1.empl_code <> " & P_EMPL_NO & ")  AND (dbo.M06_RPAR_COMP.rpar_comp_code = '" & P_EMPL_BRCH & "')"

            'strSQL += " UNION"
            'strSQL += " SELECT M01_EMPL_2.empl_code, M01_EMPL_2.name, M01_EMPL_2.name_kana, '" & P_rpar_comp_code & "' AS brch_code"
            'strSQL += " FROM M01_EMPL AS M01_EMPL_2"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " INNER JOIN M02_ATRI AS M02_ATRI_2 ON M01_EMPL_2.empl_code = M02_ATRI_2.empl_code"
            'End If
            'strSQL += " WHERE (M01_EMPL_2.empl_code = " & P_EMPL_NO & ")"
            'strSQL += " AND (M01_EMPL_2.role_code = '02')"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " AND (M02_ATRI_2.vndr_code = '" & CLU001.Text & "')"
            'End If

            'strSQL += " UNION"
            'strSQL += " SELECT T01_REP_MTR_3.repr_empl_code AS empl_code, M01_EMPL_3.name, M01_EMPL_3.name_kana, T01_REP_MTR_3.repr_brch_code AS brch_code"
            'strSQL += " FROM T01_REP_MTR AS T01_REP_MTR_3"
            'strSQL += " INNER JOIN M01_EMPL AS M01_EMPL_3 ON T01_REP_MTR_3.repr_empl_code = M01_EMPL_3.empl_code"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " LEFT OUTER JOIN M02_ATRI AS M02_ATRI_3 ON M01_EMPL_3.empl_code = M02_ATRI_3.empl_code"
            'End If
            'strSQL += " WHERE (T01_REP_MTR_3.rcpt_no = '" & Edit000.Text & "')"
            'If Ck_atri_flg.Checked = True Then
            '    strSQL += " AND (M02_ATRI_3.vndr_code = '" & CLU001.Text & "')"
            'End If
            'strSQL += ") AS M01_EMPL_00 INNER JOIN"
            'strSQL += " M06_RPAR_COMP ON M01_EMPL_00.brch_code = M06_RPAR_COMP.rpar_comp_code"
            'strSQL += " ORDER BY M01_EMPL_00.name_kana"

            'strSQL = "SELECT M01_EMPL_00.empl_code, M01_EMPL_00.name, M01_EMPL_00.brch_code, M06_RPAR_COMP_1.name AS brch_name"
            'strSQL += " FROM (SELECT M01_EMPL_1.empl_code, M01_EMPL_1.name, M01_EMPL_1.name_kana, M01_EMPL_1.brch_code"
            'strSQL += " FROM M01_EMPL AS M01_EMPL_1 INNER JOIN"
            'strSQL += " M06_RPAR_COMP ON M01_EMPL_1.brch_code = M06_RPAR_COMP.brch_code"
            'strSQL += " WHERE (M01_EMPL_1.delt_flg = 0)  AND (M01_EMPL_1.brch_code = '" & Edit903.Text & "')"
            'strSQL += " UNION"
            'strSQL += " SELECT T01_REP_MTR_3.repr_empl_code AS empl_code, M01_EMPL_3.name, M01_EMPL_3.name_kana, T01_REP_MTR_3.repr_brch_code AS brch_code"
            'strSQL += " FROM T01_REP_MTR AS T01_REP_MTR_3 INNER JOIN"
            'strSQL += " M01_EMPL AS M01_EMPL_3 ON T01_REP_MTR_3.repr_empl_code = M01_EMPL_3.empl_code"
            'strSQL += " WHERE (T01_REP_MTR_3.rcpt_no = '" & Edit000.Text & "')) AS M01_EMPL_00 INNER JOIN"
            'strSQL += " M06_RPAR_COMP AS M06_RPAR_COMP_1 ON M01_EMPL_00.brch_code = M06_RPAR_COMP_1.brch_code"
            'strSQL += " ORDER BY M01_EMPL_00.name_kana"

            strSQL = "SELECT M01_EMPL_00.empl_code, M01_EMPL_00.name, M01_EMPL_00.brch_code, M06_RPAR_COMP_1.name AS brch_name"
            strSQL += " FROM (SELECT M01_EMPL_1.empl_code, M01_EMPL_1.name, M01_EMPL_1.name_kana, M01_EMPL_1.brch_code"
            strSQL += " FROM M01_EMPL AS M01_EMPL_1 INNER JOIN"
            strSQL += " M06_RPAR_COMP ON M01_EMPL_1.brch_code = M06_RPAR_COMP.brch_code"
            strSQL += " WHERE (M01_EMPL_1.delt_flg = 0) AND (M01_EMPL_1.brch_code = '" & Edit903.Text & "') OR (M01_EMPL_1.delt_flg = 0) AND (M01_EMPL_1.empl_code = " & P_EMPL_NO & ")"
            strSQL += " UNION"
            strSQL += " SELECT T01_REP_MTR_3.repr_empl_code AS empl_code, M01_EMPL_3.name, M01_EMPL_3.name_kana, T01_REP_MTR_3.repr_brch_code AS brch_code"
            strSQL += " FROM T01_REP_MTR AS T01_REP_MTR_3 INNER JOIN"
            strSQL += " M01_EMPL AS M01_EMPL_3 ON T01_REP_MTR_3.repr_empl_code = M01_EMPL_3.empl_code"
            strSQL += " WHERE (T01_REP_MTR_3.rcpt_no = '" & Edit000.Text & "')) AS M01_EMPL_00 INNER JOIN"
            strSQL += " M06_RPAR_COMP AS M06_RPAR_COMP_1 ON M01_EMPL_00.brch_code = M06_RPAR_COMP_1.brch_code"
            strSQL += " ORDER BY M01_EMPL_00.name_kana"
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "M01_EMPL")

        'é©é–Ç≈é©ï™Çä‹ÇﬂÇÈ
        If CK_own_flg.Checked = True Then    'é©é–èCóù
            If DtView1(0)("brch_code") = P_EMPL_BRCH Then
                DtView1 = New DataView(DsCMB.Tables("M01_EMPL"), "empl_code = " & P_EMPL_NO, "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then   'é©ï™Ç™Ç¢Ç»Ç¢
                    If Ck_atri_flg.Checked = True Then  'îFíËÇ™ïKóvÇ»ÉÅÅ[ÉJÅ[
                        WK_DsList1.Clear()
                        strSQL = "SELECT M01_EMPL.empl_code"
                        strSQL += " FROM M01_EMPL INNER JOIN"
                        strSQL += " M02_ATRI ON M01_EMPL.empl_code = M02_ATRI.empl_code"
                        strSQL += " WHERE (M02_ATRI.delt_flg = 0)"
                        strSQL += " AND (M01_EMPL.empl_code = " & P_EMPL_NO & ")"
                        strSQL += " AND (M02_ATRI.vndr_code = '" & CLU001.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        r = DaList1.Fill(WK_DsList1, "M01_EMPL")
                        If r <> 0 Then
                            strSQL = "SELECT " & P_EMPL_NO & " AS empl_code"
                            strSQL += ", '" & P_EMPL_NAME & "' AS name"
                            strSQL += ", '" & P_EMPL_BRCH & "' AS brch_code"
                            strSQL += ", '" & P_EMPL_BRCH_name & "' AS brch_name"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(DsCMB, "M01_EMPL")
                        End If
                    Else
                        strSQL = "SELECT " & P_EMPL_NO & " AS empl_code"
                        strSQL += ", '" & P_EMPL_NAME & "' AS name"
                        strSQL += ", '" & P_EMPL_BRCH & "' AS brch_code"
                        strSQL += ", '" & P_EMPL_BRCH_name & "' AS brch_name"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(DsCMB, "M01_EMPL")
                    End If
                End If
            End If
        End If
        DB_CLOSE()

        Combo_K001.DataSource = DsCMB.Tables("M01_EMPL")
        Combo_K001.DisplayMember = "name"
        Combo_K001.DescriptionMember = "brch_name"
        Combo_K001.ValueMember = "empl_code"

    End Sub
    Sub Cmb4()      'ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóø

        DsCMB2.Clear()
        strSQL = "SELECT seq, select_case, tech_amnt"
        strSQL += " FROM M14_VNDR_SUB"
        strSQL += " WHERE (vndr_code = '" & CLU001.Text & "') AND (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB2, "M14_VNDR_SUB")
        DB_CLOSE()
        Combo_K002.DataSource = DsCMB2.Tables("M14_VNDR_SUB")
        Combo_K002.DisplayMember = "select_case"
        Combo_K002.ValueMember = "seq"

    End Sub
    Sub Cmb5()      'ì¸ã‡éÌï 

        DsCMB4.Clear()
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM V_cls_029"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB4, "cls_029")
        DB_CLOSE()
        Combo_K004.DataSource = DsCMB4.Tables("cls_029")
        Combo_K004.DisplayMember = "cls_code_name"
        Combo_K004.ValueMember = "cls_code"

    End Sub

    '********************************************************************
    '**  èâä˙âÊñ 
    '********************************************************************
    Sub inz_dsp()
        msg.Text = Nothing
        Number001.Value = 0 : Number001_nTax.Value = 0 : Number003.Value = 0 : Number004.Value = 0
        NumberN003.Value = 0 ': NumberN004.Value = 0 : NumberN005.Value = 0 
        NumberN006.Value = 0 : NumberN007.Value = 0 : NumberN008.Value = 0 : NumberN009.Value = 0
        NumberN011.Value = 0 : NumberN012.Value = 0 : NumberN013.Value = 0 : NumberN015.Value = 0

        apse.Text = 0

        Button0.Enabled = True
        Button1.Enabled = False : Button14.Enabled = False
        Button2.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button80.Enabled = False
        Button97.Visible = False : sn_n.Text = "0"
        Button_S2.Enabled = False
        Button14.Enabled = False
        Edit000.Text = Nothing  'éÛïtî‘çÜ
        Edit000.ReadOnly = False : Edit000.TabStop = True : Edit000.BackColor = System.Drawing.SystemColors.Window

        Label5.Text = Nothing
        Label017.Text = Nothing

        Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True
        Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
        Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
        Label001.Visible = True : Label002.Visible = True : Label003.Visible = True : Label004.Visible = True : Label005.Visible = True : Label006.Visible = True : Label007.Visible = True
        Edit001.Visible = True : Edit002.Visible = True : Edit003.Visible = True : Edit004.Visible = True : Date001.Visible = True

        Label001.Text = Nothing : Label002.Text = Nothing
        Edit901.Text = Nothing
        Edit902.Text = Nothing
        Edit903.Text = Nothing
        Date003.Text = Nothing
        Date004.Text = Nothing
        Date006.Enabled = False : Date006.Text = Nothing : Date006.BackColor = System.Drawing.SystemColors.Window
        Date007.Enabled = False : Date007.Text = Nothing : Date007.BackColor = System.Drawing.SystemColors.Window
        Date008.Enabled = False : Date008.Text = Nothing : Date008.BackColor = System.Drawing.SystemColors.Window
        Date010.Enabled = False : Date010.Text = Nothing : Date010.BackColor = System.Drawing.SystemColors.Window
        Date011.Enabled = False : Date011.Text = Nothing : Date011.BackColor = System.Drawing.SystemColors.Window
        Date012.Enabled = False : Date012.Text = Nothing : Date012.BackColor = System.Drawing.SystemColors.Window
        Date013.Text = Nothing : Date014.Text = Nothing
        Date015.Text = Nothing
        Date015.Enabled = False : Date015.Text = Nothing : Date015.BackColor = System.Drawing.SystemColors.Window
        Date016.Enabled = False : Date016.Text = Nothing : Date016.BackColor = System.Drawing.SystemColors.Window
        Date017.Enabled = False : Date017.Text = Nothing : Date017.BackColor = System.Drawing.SystemColors.Window
        Combo001.Text = Nothing
        Combo002.Text = Nothing
        Combo003.Text = Nothing
        Combo004.Text = Nothing
        Combo005.Text = Nothing
        Combo006.Enabled = False : Combo006.Text = Nothing
        Combo007.Text = Nothing
        Edit001.Text = Nothing
        Edit002.Text = Nothing
        Edit003.Text = Nothing
        Edit004.Text = Nothing
        Edit005.Text = Nothing
        Edit006.Text = Nothing
        Edit007.Text = Nothing
        Edit008.Text = Nothing
        Edit009.Text = Nothing
        Edit010.Text = Nothing
        Edit011.Text = Nothing
        Edit012.Enabled = False : Edit012.Text = Nothing : Edit012.BackColor = System.Drawing.SystemColors.Window
        Number002.Enabled = False : Number002.Value = 0 : Number002.BackColor = System.Drawing.SystemColors.Window
        Edit013.Text = Nothing
        Mask1.Text = Nothing
        Edit014.Text = Nothing
        Edit015.Text = Nothing
        Edit016.Text = Nothing
        CkBox01_Y.Enabled = False : CkBox01_Y.Checked = False : CkBox01_Y.BackColor = System.Drawing.SystemColors.Control
        CkBox01_N.Enabled = False : CkBox01_N.Checked = False : CkBox01_N.BackColor = System.Drawing.SystemColors.Control

        Date_U001.Text = Nothing
        Date_U002.Text = Nothing
        Date_U003.Text = Nothing
        Date_U004.Text = Nothing
        Combo_U001.Text = Nothing
        Combo_U002.Text = Nothing
        Edit_U001.Text = Nothing
        Edit_U002.Text = Nothing
        Edit_U003.Text = Nothing
        Edit_U004.Text = Nothing
        Edit_U005.Text = Nothing
        Edit_U006.Text = Nothing
        CheckBox_U001.Checked = False
        CheckBox_U002.Checked = False : CheckBox_U002.AutoCheck = False
        CheckBox_U003.Checked = False : CheckBox_U003.AutoCheck = False
        CheckBox_M001.Checked = False
        CheckBox_K001.Checked = False : CheckBox_K001.AutoCheck = False
        CheckBox_K002.Checked = False : CheckBox_K002.AutoCheck = False
        Panel_U1.Controls.Clear()
        Panel_U2.Controls.Clear()

        Edit_M001.Text = Nothing
        Edit_M002.Text = Nothing
        Edit_M003.Text = Nothing
        Edit_M004.Text = Nothing
        Combo_M001.Text = Nothing
        Combo_M003.Text = Nothing
        Number011.Value = 0
        Number012.Value = 0
        Number013.Value = 0
        Number014.Value = 0
        Number015.Value = 0
        Number016.Value = 0
        Number017.Value = 0
        Number018.Value = 0
        Number021.Value = 0
        Number022.Value = 0
        Number023.Value = 0
        Number024.Value = 0
        Number025.Value = 0
        Number026.Value = 0
        Number027.Value = 0
        Number028.Value = 0
        Number031.Value = 0
        Number032.Value = 0
        Number033.Value = 0
        Number034.Value = 0
        Number035.Value = 0
        Number036.Value = 0
        Number037.Value = 0
        Number038.Value = 0

        Number019.Value = 0
        Number029.Value = 0
        Number039.Value = 0

        Panel_M1.Controls.Clear()
        P_DsList1.Clear()
        DsList1.Clear()

        Combo_K001.Enabled = False : Combo_K001.Text = Nothing : Combo_K001.BackColor = System.Drawing.SystemColors.Window
        Combo_K002.Enabled = False : Combo_K002.Text = Nothing : Combo_K002.BackColor = System.Drawing.SystemColors.Window
        Combo_K003.Enabled = False : Combo_K003.Text = Nothing : Combo_K003.BackColor = System.Drawing.SystemColors.Window
        Combo_K004.Enabled = False : Combo_K004.Text = Nothing : Combo_K004.BackColor = System.Drawing.SystemColors.Window
        Edit_K001.Enabled = False : Edit_K001.Text = Nothing : Edit_K001.BackColor = System.Drawing.SystemColors.Window
        Edit_K002.Enabled = False : Edit_K002.Text = Nothing : Edit_K002.BackColor = System.Drawing.SystemColors.Window
        Edit_K003.Enabled = False : Edit_K003.Text = Nothing : Edit_K003.BackColor = System.Drawing.SystemColors.Window
        Edit_K004.Enabled = False : Edit_K004.Text = Nothing : Edit_K004.BackColor = System.Drawing.SystemColors.Window
        Number111.Enabled = False : Number111.Value = 0 : Number111.BackColor = System.Drawing.SystemColors.Window
        Number112.Enabled = False : Number112.Value = 0 : Number112.BackColor = System.Drawing.SystemColors.Window
        Number113.Enabled = False : Number113.Value = 0 : Number113.BackColor = System.Drawing.SystemColors.Window
        Number114.Enabled = False : Number114.Value = 0 : Number114.BackColor = System.Drawing.SystemColors.Window
        Number115.Enabled = False : Number115.Value = 0 : Number115.BackColor = System.Drawing.SystemColors.Window
        Number116.Enabled = False : Number116.Value = 0 : Number116.BackColor = System.Drawing.SystemColors.Window
        Number117.Enabled = False : Number117.Value = 0 : Number117.BackColor = System.Drawing.SystemColors.Window
        Number118.Enabled = False : Number118.Value = 0 : Number118.BackColor = System.Drawing.SystemColors.Window
        Number121.Enabled = False : Number121.Value = 0 : Number121.BackColor = System.Drawing.SystemColors.Window
        Number122.Enabled = False : Number122.Value = 0 : Number122.BackColor = System.Drawing.SystemColors.Window
        Number123.Enabled = False : Number123.Value = 0 : Number123.BackColor = System.Drawing.SystemColors.Window
        Number124.Enabled = False : Number124.Value = 0 : Number124.BackColor = System.Drawing.SystemColors.Window
        Number125.Enabled = False : Number125.Value = 0 : Number125.BackColor = System.Drawing.SystemColors.Window
        Number126.Enabled = False : Number126.Value = 0 : Number126.BackColor = System.Drawing.SystemColors.Window
        Number127.Enabled = False : Number127.Value = 0 : Number127.BackColor = System.Drawing.SystemColors.Window
        Number128.Enabled = False : Number128.Value = 0 : Number128.BackColor = System.Drawing.SystemColors.Window
        Number131.Enabled = False : Number131.Value = 0 : Number131.BackColor = System.Drawing.SystemColors.Window
        Number132.Enabled = False : Number132.Value = 0 : Number132.BackColor = System.Drawing.SystemColors.Window
        Number133.Enabled = False : Number133.Value = 0 : Number133.BackColor = System.Drawing.SystemColors.Window
        Number134.Enabled = False : Number134.Value = 0 : Number134.BackColor = System.Drawing.SystemColors.Window
        Number135.Enabled = False : Number135.Value = 0 : Number135.BackColor = System.Drawing.SystemColors.Window
        Number136.Enabled = False : Number136.Value = 0 : Number136.BackColor = System.Drawing.SystemColors.Window
        Number137.Enabled = False : Number137.Value = 0 : Number137.BackColor = System.Drawing.SystemColors.Window
        Number138.Enabled = False : Number138.Value = 0 : Number138.BackColor = System.Drawing.SystemColors.Window

        zero_code.Text = Nothing
        zero_name.Text = Nothing
        CHG.Text = Nothing
        rebate.Value = 0
        idvd_chrg.Value = 0

        Button_K001.Enabled = False
        Button_K002.Enabled = False
        Panel_K1.Controls.Clear()

        cntact1.Text = Nothing
        cntact2.Text = Nothing
        CheckBox1.Enabled = False : CheckBox1.Checked = False

        QA_F = "0"

        Edit000.Focus()
    End Sub

    '********************************************************************
    '**  éÛïtî‘çÜEnter
    '********************************************************************
    Private Sub Edit000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Edit000.KeyDown
        If e.KeyCode = Keys.Enter Then
            inz_F = "0"
            Button13_Click(sender, e)
            rep_scan()  '** èCóùèÓïÒÇfÇdÇs
            temp_set()
            inz_F = "1"
        End If
    End Sub

    '********************************************************************
    '** èCóùèÓïÒÇfÇdÇs(SQL)
    '********************************************************************
    Sub rep_sql()
        DB_OPEN("nMVAR")

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_T01_REP_MTR_U", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "T01_REP_MTR_U")
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)

        SqlCmd1 = New SqlClient.SqlCommand("sp_T01_REP_MTR_M", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram2.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "T01_REP_MTR_M")
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

        SqlCmd1 = New SqlClient.SqlCommand("sp_T01_REP_MTR_K", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "T01_REP_MTR_K")
        DtView3 = New DataView(DsList1.Tables("T01_REP_MTR_K"), "", "", DataViewRowState.CurrentRows)

        'ïîïi(å©êœ)
        P_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_T04_REP_PART", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 1)
        Pram3.Value = Edit000.Text
        Pram4.Value = "1"
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsList1, "T04_REP_PART")
        'DaList1.Fill(DsList1, "T04_REP_PART_MOTO")

        WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "seq", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DtView1(i)("ID_NO") = i
            Next
        End If
        'WK_DtView1 = New DataView(DsList1.Tables("T04_REP_PART_MOTO"), "", "seq", DataViewRowState.CurrentRows)
        'If WK_DtView1.Count <> 0 Then
        '    For i = 0 To WK_DtView1.Count - 1
        '        WK_DtView1(i)("ID_NO") = i
        '    Next
        'End If

        'äÆóπì‡óe
        strSQL = "SELECT T03_REP_CMNT.rcpt_no, T03_REP_CMNT.kbn, T03_REP_CMNT.seq, T03_REP_CMNT.cls_code1"
        strSQL += ", T03_REP_CMNT.cmnt_code1, T03_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
        strSQL += " FROM T03_REP_CMNT LEFT OUTER JOIN"
        strSQL += " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
        strSQL += " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
        strSQL += " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
        strSQL += " AND (T03_REP_CMNT.kbn = '3')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T03_REP_CMNT_3")

        'ïîïi(äÆê¨)
        SqlCmd1 = New SqlClient.SqlCommand("sp_T04_REP_PART", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram6 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Dim Pram7 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 1)
        Pram6.Value = Edit000.Text
        Pram7.Value = "2"
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsList1, "T04_REP_PART_2")
        DaList1.Fill(DsList1, "T04_REP_PART_MOTO_2")

        WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "", "seq", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DtView1(i)("ID_NO") = i
            Next
        End If
        WK_DtView1 = New DataView(DsList1.Tables("T04_REP_PART_MOTO_2"), "", "seq", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DtView1(i)("ID_NO") = i
            Next
        End If

        'êøãÅ
        strSQL = "SELECT * FROM T21_INVC_SUB WHERE (rcpt_no = '" & Edit000.Text & "') AND (cxl_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T21_INVC_SUB")

        'ì¸ã‡
        strSQL = "SELECT * FROM T30_CLCT WHERE (rcpt_no = '" & Edit000.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T30_CLCT")

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** èCóùèÓïÒÇfÇdÇs
    '********************************************************************
    Sub rep_scan()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Edit000.BackColor = System.Drawing.SystemColors.Window
        msg.Text = Nothing
        prtct_F = "0"

        Edit000.Text = Trim(Edit000.Text)
        rep_sql()   '** èCóùèÓïÒÇfÇdÇs(SQL)

        If DtView1.Count = 0 Then
            Edit000.BackColor = System.Drawing.Color.Red
            msg.Text = "äYìñÇ∑ÇÈéÛïtî‘çÜÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
        Else
            Button0.Enabled = False
            Button2.Enabled = True
            Button_S2.Enabled = True
            If Not IsDBNull(DtView1(0)("haita_empl_code")) Then
                MessageBox.Show(DtView1(0)("haita_empl_name") & "Ç≥ÇÒÇ™ " & DtView1(0)("haita_use_date") & " Ç©ÇÁÅAï“èWíÜÇ≈Ç∑ÅB", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                If IsDBNull(DtView1(0)("stts")) Then WK_str = Nothing Else WK_str = DtView1(0)("stts")
                If WK_str = "45" Then
                    MessageBox.Show("Q&AÉXÉeÅ[É^ÉX45:éÛïtï€óØÇÃÇΩÇﬂÅAéQè∆ÇÃÇ›", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    If IsDBNull(DtView1(0)("brch_code")) Then DtView1(0)("brch_code") = ""
                    If P_EMPL_BRCH <> DtView1(0)("rcpt_brch_code") _
                        And P_EMPL_BRCH <> DtView1(0)("brch_code") _
                        And P_full <> "True" Then
                        If P_tokubetu = "1" Then
                            ANS = MessageBox.Show("ëºïîèêèCóùÇ≈Ç∑Ç™ÅAçXêVÇâ¬î\Ç…ÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            If ANS = "6" Then  'ÇÕÇ¢
                                HAITA_ON(Edit000.Text)  'HAITA_ON
                                Button1.Enabled = True : Button14.Enabled = True
                            Else
                                prtct_F = "1"
                            End If
                        Else
                            MessageBox.Show("ëºïîèêèCóùÇÃÇΩÇﬂÅAéQè∆ÇÃÇ›", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            prtct_F = "1"
                        End If
                    Else
                        If Not IsDBNull(DtView1(0)("comp_date")) Then
                            If Format(DtView1(0)("comp_date"), "yyyyMM") = Format(Now.Date, "yyyyMM") Then

                                If DtView1(0)("grup_code") = "63" And SBM.Text >= "3" Then
                                    HAITA_ON(Edit000.Text)  'HAITA_ON
                                    Button1.Enabled = True : Button14.Enabled = True
                                Else
                                    If Not IsDBNull(DtView3(0)("sals_no")) Then
                                        If P_tokubetu = "1" Then
                                            ANS = MessageBox.Show("ÉlÉoì`î≠çsçœÇ›Ç≈Ç∑Ç™ÅAçXêVÇâ¬î\Ç…ÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            If ANS = "6" Then  'ÇÕÇ¢
                                                HAITA_ON(Edit000.Text)  'HAITA_ON
                                                Button1.Enabled = True : Button14.Enabled = True
                                            Else
                                                prtct_F = "1"
                                            End If
                                        Else
                                            MessageBox.Show("ÉlÉoì`î≠çsçœÇ›ÅBçXêVèoóàÇ‹ÇπÇÒ", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            prtct_F = "1"
                                        End If
                                    Else
                                        If Not IsDBNull(DtView3(0)("rqst_date")) Then
                                            If P_tokubetu = "1" Then
                                                ANS = MessageBox.Show("êøãÅèàóùçœÇ›Ç≈Ç∑Ç™ÅAçXêVÇâ¬î\Ç…ÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                If ANS = "6" Then  'ÇÕÇ¢
                                                    HAITA_ON(Edit000.Text)  'HAITA_ON
                                                    Button1.Enabled = True : Button14.Enabled = True
                                                Else
                                                    prtct_F = "1"
                                                End If
                                            Else
                                                MessageBox.Show("êøãÅèàóùçœÇ›Ç≈Ç∑ÅBçXêVèoóàÇ‹ÇπÇÒ", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                prtct_F = "1"
                                            End If
                                        Else
                                            If kengen.Text >= "3" Then
                                                HAITA_ON(Edit000.Text)  'HAITA_ON
                                                Button1.Enabled = True : Button14.Enabled = True
                                            Else
                                                If P_tokubetu = "1" Then
                                                    ANS = MessageBox.Show("ä˘Ç…äÆê¨ÇµÇƒÇ¢Ç‹Ç∑Ç™ÅAçXêVÇâ¬î\Ç…ÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                    If ANS = "6" Then  'ÇÕÇ¢
                                                        HAITA_ON(Edit000.Text)  'HAITA_ON
                                                        Button1.Enabled = True : Button14.Enabled = True
                                                    Else
                                                        prtct_F = "1"
                                                    End If
                                                Else
                                                    MessageBox.Show("äÆóπÇµÇƒÇ¢ÇÈÇΩÇﬂÅAéQè∆ÇÃÇ›", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                    prtct_F = "1"
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                If P_tokubetu = "1" Then
                                    ANS = MessageBox.Show("ä˘Ç…äÆê¨ÇµÇƒÇ¢Ç‹Ç∑Ç™ÅAçXêVÇâ¬î\Ç…ÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    If ANS = "6" Then  'ÇÕÇ¢
                                        HAITA_ON(Edit000.Text)  'HAITA_ON
                                        Button1.Enabled = True : Button14.Enabled = True
                                    Else
                                        prtct_F = "1"
                                    End If
                                Else
                                    MessageBox.Show("äÆóπÇµÇƒÇ¢ÇÈÇΩÇﬂÅAéQè∆ÇÃÇ›", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    prtct_F = "1"
                                End If
                            End If

                            Select Case aka.Text
                                Case Is = "2", "3", "4"
                                    If Not IsDBNull(DtView3(0)("rcpt_no_aka")) Then 'ê‘ì`
                                        If Trim(DtView3(0)("rcpt_no_aka")) = Nothing Then 'ê‘ì`
                                            Button8.Enabled = True
                                        Else
                                            Button8.Enabled = False
                                        End If
                                    Else
                                        Button8.Enabled = True
                                    End If
                                Case Else
                                    Button8.Enabled = False
                            End Select
                        Else
                            If IsDBNull(DtView1(0)("etmt_date")) Then
                                If DtView1(0)("rpar_cls") = "01" Then
                                    If ZH.Text = "Z" Then
                                        MessageBox.Show("å©êœÇ™Ç≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Else
                                        HAITA_ON(Edit000.Text)  'HAITA_ON
                                        Button1.Enabled = True : Button14.Enabled = True
                                    End If
                                Else
                                    If kengen.Text >= "3" Then
                                        HAITA_ON(Edit000.Text)  'HAITA_ON
                                        Button1.Enabled = True : Button14.Enabled = True
                                    End If
                                End If
                            Else
                                If kengen.Text >= "3" Then
                                    HAITA_ON(Edit000.Text)  'HAITA_ON
                                    Button1.Enabled = True : Button14.Enabled = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button9.Enabled = True

            Edit000.ReadOnly = True : Edit000.TabStop = False : Edit000.BackColor = System.Drawing.SystemColors.Control
            Button80.Enabled = True
            Edit901.Text = DtView1(0)("rcpt_ent_empl_name")
            If Not IsDBNull(DtView1(0)("rcpt_brch_name")) Then Edit902.Text = DtView1(0)("rcpt_brch_name")
            Edit903.Text = DtView1(0)("rcpt_brch_code")

            If Not IsDBNull(DtView1(0)("accp_date")) Then Date003.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView1(0)("accp_date")) ' Date003.Text = DtView1(0)("accp_date")

            If Not IsDBNull(DtView3(0)("comp_date")) Then
                Date010.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("comp_date")) ' Date010.Text = DtView3(0)("comp_date")
                tax(String.Format("{0:yyyy/MM/dd}", CDate(Date010.Text)))
            End If
            Date010.Enabled = True
            If Not IsDBNull(DtView3(0)("rep_date")) Then Date016.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("rep_date")) ' Date016.Text = DtView3(0)("rep_date")
            Date016.Enabled = True
            If Not IsDBNull(DtView3(0)("renraku_date")) Then Date017.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("renraku_date")) ' Date017.Text = DtView3(0)("renraku_date")
            Date017.Enabled = True
            If Not IsDBNull(DtView3(0)("sals_date")) Then Date011.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("sals_date"))
            Date011.Enabled = True
            If Not IsDBNull(DtView3(0)("ship_date")) Then Date012.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("ship_date"))
            Date012.Enabled = True
            If Not IsDBNull(DtView3(0)("rqst_date")) Then Date013.Text = String.Format("{0:yyyy/MM/dd}", DtView3(0)("rqst_date"))

            If Date003.Number <> 0 Then
                If Date010.Number = 0 Then
                    Label017.Text = "åoâﬂì˙êîÅF" & DateDiff(DateInterval.Day, CDate(Date003.Text).Date, Now.Date)
                Else
                    Label017.Text = "åoâﬂì˙êîÅF" & DateDiff(DateInterval.Day, CDate(Date003.Text), CDate(Date010.Text))
                End If
            Else
                Label017.Text = "åoâﬂì˙êîÅF"
            End If

            CkBox01_Y.Enabled = True
            CkBox01_N.Enabled = True
            If Not IsDBNull(DtView1(0)("kashitsu_flg")) Then
                If DtView1(0)("kashitsu_flg") = "1" Then
                    CkBox01_Y.Checked = True
                Else
                    CkBox01_N.Checked = True
                End If
            End If

            Combo001.Text = DtView1(0)("rcpt_name") : CL001.Text = DtView1(0)("rcpt_cls")
            Select Case DtView1(0)("cls_code_name_abbr")
                Case Is = "QGNo"
                    Label21.Text = "QG Care No"
                    Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True 'QG No
                    Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
                    Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
                    Edit011.Text = DtView1(0)("qg_care_no")

                    WK_DsList1.Clear()
                    strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                    strSQL += " FROM T01_member LEFT OUTER JOIN"
                    strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                    strSQL += " WHERE (T01_member.code = '" & Edit011.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("QGCare")
                    DaList1.Fill(WK_DsList1, "T01_member")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        If Not IsDBNull(WK_DtView1(0)("wrn_range_name")) Then Label5.Text = WK_DtView1(0)("wrn_range_name")
                    End If
                Case Is = "CoopFujitsu Insu"
                    Label21.Text = "Fujitsu No"
                    Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True 'Fujitsu No
                    Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
                    Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
                    Edit011.Text = DtView1(0)("qg_care_no")
                    Label5.Text = "ê∂ã¶ïxémí ï€åØ"
                Case Else
                    Label21.Visible = False : Edit011.Visible = False : Label5.Visible = False : Edit011.Text = Nothing 'QG No
                    Label10.Visible = False : Number001_nTax.Visible = False : Label16.Visible = False
                    Label15.Visible = False : Number003.Visible = False : Label17.Visible = False
                    Label5.Text = Nothing
            End Select
            NumberN009.Value = DtView1(0)("wrn_period")

            Combo002.Text = DtView1(0)("arvl_name")
            If DtView1(0)("cls_code_name_abbr2") = "àÍî " Then
                'îÃé–îÒï\é¶
                Label004.Visible = False : Label006.Visible = False : Label007.Visible = False
                Edit003.Visible = False : Edit004.Visible = False : Date001.Visible = False
            Else                                    'îÃé–
                'îÃé–ï\é¶
                Label004.Visible = True : Label006.Visible = True : Label007.Visible = True
                Edit003.Visible = True : Edit004.Visible = True : Date001.Visible = True
            End If

            Combo003.Text = DtView1(0)("arvl_empl_name")
            'Cmb1()  'èCóùéÌï 
            Combo004.Text = DtView1(0)("rpar_cls_name") : CL004.Text = DtView1(0)("rpar_cls")
            If Not IsDBNull(DtView1(0)("acdt_name")) Then Combo005.Text = DtView1(0)("acdt_name") Else Combo005.Text = Nothing
            If Not IsDBNull(DtView1(0)("defe_name")) Then Combo007.Text = DtView1(0)("defe_name") Else Combo007.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_code")) Then Edit001.Text = DtView1(0)("store_code") Else Edit001.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_name")) Then Label001.Text = DtView1(0)("store_name") Else Label001.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_code")) Then Edit002.Text = DtView1(0)("dlvr_code") Else Edit002.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_name")) Then Label002.Text = DtView1(0)("dlvr_name") Else Label002.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_prsn")) Then Edit003.Text = DtView1(0)("store_prsn") Else Edit003.Text = Nothing

            If Not IsDBNull(DtView1(0)("grup_code")) Then GRP.Text = DtView1(0)("grup_code") Else GRP.Text = Nothing
            If Not IsDBNull(DtView1(0)("idvd_flg")) Then idvd_flg.Text = DtView1(0)("idvd_flg") Else idvd_flg.Text = Nothing

            If Not IsDBNull(DtView1(0)("store_accp_date")) Then Date001.Text = DtView1(0)("store_accp_date") Else Date001.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_repr_no")) Then Edit004.Text = DtView1(0)("store_repr_no") Else Edit004.Text = Nothing
            If Not IsDBNull(DtView1(0)("tech_rate1")) Then NumberN003.Value = DtView1(0)("tech_rate1") Else NumberN003.Value = 0
            If Not IsDBNull(DtView1(0)("tech_rate2")) Then NumberN007.Value = DtView1(0)("tech_rate2") Else NumberN007.Value = 0
            If Not IsDBNull(DtView1(0)("part_rate2")) Then NumberN008.Value = DtView1(0)("part_rate2") Else NumberN008.Value = 0
            Edit005.Text = DtView1(0)("user_name")
            Edit006.Text = DtView1(0)("user_name_kana")
            Edit007.Text = DtView1(0)("tel1")
            Edit008.Text = DtView1(0)("tel2")
            If Not IsDBNull(DtView1(0)("email")) Then Edit016.Text = DtView1(0)("email") Else Edit016.Text = Nothing

            Edit009.Text = DtView1(0)("adrs1")
            Edit010.Text = DtView1(0)("adrs2")
            Edit012.Enabled = True : Edit012.Text = DtView1(0)("orgnl_vndr_code")
            If Not IsDBNull(DtView1(0)("store_wrn_info")) Then Edit013.Text = DtView1(0)("store_wrn_info") Else Edit013.Text = Nothing
            If Not IsDBNull(DtView1(0)("reference_no")) Then Edit014.Text = DtView1(0)("reference_no") Else Edit014.Text = Nothing
            If Not IsDBNull(DtView1(0)("imv_rcpt_no")) Then Edit015.Text = DtView1(0)("imv_rcpt_no") Else Edit015.Text = Nothing
            Mask1.Value = DtView1(0)("zip")
            If Not IsDBNull(DtView1(0)("wrn_limt_amnt")) Then Number001.Value = DtView1(0)("wrn_limt_amnt") Else Number001.Value = 0
            Number001_nTax.Value = RoundDOWN(Number001.Value / Wk_TAX_1, 0)
            If Not IsDBNull(DtView1(0)("recv_amnt")) Then Number002.Value = DtView1(0)("recv_amnt") Else Number002.Value = 0
            Number002.Enabled = True
            If Not IsDBNull(DtView1(0)("menseki_amnt")) Then Number003.Value = DtView1(0)("menseki_amnt") Else Number003.Value = 0

            'éÛïtèÓïÒ **********************************
            If Not IsDBNull(DtView1(0)("prch_date")) Then Date_U001.Text = DtView1(0)("prch_date") Else Date_U001.Text = Nothing
            If Not IsDBNull(DtView1(0)("vndr_wrn_date")) Then Date_U002.Text = DtView1(0)("vndr_wrn_date") Else Date_U002.Text = Nothing
            If Not IsDBNull(DtView1(0)("vndr_wrn_end_date")) Then Date_U004.Text = DtView1(0)("vndr_wrn_end_date") Else Date_U004.Text = Nothing
            If Not IsDBNull(DtView1(0)("acdt_date")) Then Date_U003.Text = DtView1(0)("acdt_date") Else Date_U003.Text = Nothing
            If IsDBNull(DtView1(0)("vndr_wrn_date_chk")) Then DtView1(0)("vndr_wrn_date_chk") = "False"
            If DtView1(0)("vndr_wrn_date_chk") = "1" Then
                CheckBox_U002.Checked = True
            Else
                CheckBox_U002.Checked = False
            End If

            Combo_U001.Text = DtView1(0)("vndr_name") : CLU001.Text = DtView1(0)("vndr_code")
            If CLU001.Text = "01" Then
                CheckBox_U001.Text = "íËäzèCóù"
                CheckBox_U003.Visible = True
            Else
                CheckBox_U001.Text = "ÇmÇèÇîÇÖ"
                CheckBox_U003.Visible = False
            End If
            CLU002.Text = DtView1(0)("rpar_comp_code")
            If Not IsDBNull(DtView1(0)("rpar_comp_name")) Then
                Combo_U002.Text = DtView1(0)("rpar_comp_name")
            End If

            'APSE
            If CLU001.Text = "01" _
                And CL004.Text = "02" _
                And Date010.Number <> 0 Then
                apse.Text = APSE_GET(CLU002.Text, Date010.Text)
            Else
                apse.Text = "0"
            End If

            Edit_U001.Text = DtView1(0)("model_2")
            Edit_U002.Text = DtView1(0)("model_1")
            Edit_U003.Text = DtView1(0)("s_n")
            Edit_U004.Text = DtView1(0)("user_trbl")
            Edit_U005.Text = DtView1(0)("rcpt_comn")
            If Not IsDBNull(DtView1(0)("sb_imei_old")) Then Edit_U006.Text = DtView1(0)("sb_imei_old") Else Edit_U006.Text = Nothing

            If DtView1(0)("note_kbn") = "01" Then CheckBox_U001.Checked = True Else CheckBox_U001.Checked = False
            If Not IsDBNull(DtView1(0)("note_kbn2")) Then
                If DtView1(0)("note_kbn2") = "01" Then CheckBox_U003.Checked = True Else CheckBox_U003.Checked = False
            Else
                CheckBox_U003.Checked = False
            End If
            If DtView1(0)("atri_flg") = "1" Then Ck_atri_flg.Checked = True Else Ck_atri_flg.Checked = False
            If Not IsDBNull(DtView1(0)("own_flg")) Then
                If DtView1(0)("own_flg") = "1" Then CK_own_flg.Checked = True Else CK_own_flg.Checked = False
            Else
                CK_own_flg.Checked = False
            End If
            If CK_own_flg.Checked = True Then
                Label015.Text = "ïîïiî≠íçì˙"
                Label016.Text = "ïîïiéÛóÃì˙"
            Else
                Label015.Text = "“∞∂∞î≠ëóì˙"
                Label016.Text = "“∞∂∞ñﬂì˙"
            End If

            If Not IsDBNull(DtView3(0)("part_ordr_date")) Then Date007.Text = DtView3(0)("part_ordr_date")
            Date007.Enabled = True
            'If CL004.Text = "01" Then   'óLèû
            If CK_own_flg.Checked = False Then  'ëºé–èCóù
                If Date007.Number <> 0 Then
                    Date007.Enabled = False
                End If
            End If
            'End If

            If Not IsDBNull(DtView3(0)("part_rcpt_date")) Then Date008.Text = Format(CDate(DtView3(0)("part_rcpt_date")), "yyyy/MM/dd")
            Date008.Enabled = True
            'If CL004.Text = "01" Then   'óLèû
            If CK_own_flg.Checked = False Then  'ëºé–èCóù
                If Date008.Number <> 0 Then
                    Date008.Enabled = False
                End If
            End If
            'End If

            'ïtëÆïi
            strSQL = "SELECT item_name, amnt, item_unit FROM T02_ATCH_ITEM WHERE (rcpt_no = '" & Edit000.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "T02_ATCH_ITEM")
            DB_CLOSE()

            WK_DtView2 = New DataView(DsList1.Tables("T02_ATCH_ITEM"), "", "", DataViewRowState.CurrentRows)
            Line_No = 0
            Panel_U1.Controls.Clear()

            If WK_DtView2.Count <> 0 Then
                For Line_No = 0 To WK_DtView2.Count - 1

                    'ëŒè€
                    en = 1
                    chkBox(Line_No, en) = New CheckBox
                    chkBox(Line_No, en).Location = New System.Drawing.Point(5, 20 * Line_No)
                    chkBox(Line_No, en).Size = New System.Drawing.Size(25, 20)
                    chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                    chkBox(Line_No, en).Text = Nothing
                    chkBox(Line_No, en).AutoCheck = False
                    chkBox(Line_No, en).TabStop = False
                    chkBox(Line_No, en).Checked = True
                    Panel_U1.Controls.Add(chkBox(Line_No, en))

                    'ïtëÆïi
                    en = 1
                    edit(Line_No, en) = New GrapeCity.Win.Input.Interop.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(30, 20 * Line_No)
                    edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
                    edit(Line_No, en).Size = New System.Drawing.Size(150, 20)
                    edit(Line_No, en).Enabled = False
                    edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    edit(Line_No, en).Text = WK_DtView2(Line_No)("item_name")
                    edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
                    Panel_U1.Controls.Add(edit(Line_No, en))

                    'êîó 
                    en = 1
                    nbrBox(Line_No, en) = New GrapeCity.Win.Input.Interop.Number
                    nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###0", "", "", "-", "", "", "")
                    nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
                    nbrBox(Line_No, en).Enabled = False
                    nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###0", "", "", "-", "", "", "")
                    nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 20 * Line_No)
                    nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
                    nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).Size = New System.Drawing.Size(30, 20)
                    nbrBox(Line_No, en).Value = WK_DtView2(Line_No)("amnt")
                    If Trim(WK_DtView2(Line_No)("item_unit")) = Nothing And WK_DtView2(Line_No)("amnt") = 0 Then
                        nbrBox(Line_No, en).Visible = False
                    End If
                    Panel_U1.Controls.Add(nbrBox(Line_No, en))

                    'íPà 
                    en = 2
                    edit(Line_No, en) = New GrapeCity.Win.Input.Interop.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(210, 20 * Line_No)
                    edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
                    edit(Line_No, en).Size = New System.Drawing.Size(50, 20)
                    edit(Line_No, en).Enabled = False
                    edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    edit(Line_No, en).Text = WK_DtView2(Line_No)("item_unit")
                    edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
                    If Trim(WK_DtView2(Line_No)("item_unit")) = Nothing Then
                        edit(Line_No, en).Visible = False
                    End If
                    Panel_U1.Controls.Add(edit(Line_No, en))

                Next
            End If

            'åÃè·ì‡óe
            strSQL = "SELECT T03_REP_CMNT.rcpt_no, T03_REP_CMNT.kbn, T03_REP_CMNT.seq, T03_REP_CMNT.cls_code1"
            strSQL += ", T03_REP_CMNT.cmnt_code1, T03_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
            strSQL += " FROM T03_REP_CMNT LEFT OUTER JOIN"
            strSQL += " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
            strSQL += " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
            strSQL += " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
            strSQL += " AND (T03_REP_CMNT.kbn = '1')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "T03_REP_CMNT")
            DB_CLOSE()

            Line_No2 = -1
            Panel_U2.Controls.Clear()

            WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    add_line_2()    'åÃè·ì‡óe
                Next
            End If

            'å©êœèÓïÒ **********************************
            If IsDBNull(DtView2(0)("etmt_sum_flg")) Then
                CheckBox_M001.Checked = False
            Else
                If DtView2(0)("etmt_sum_flg") = "False" Then
                    CheckBox_M001.Checked = False
                Else
                    CheckBox_M001.Checked = True
                End If
            End If
            If Not IsDBNull(DtView2(0)("sindan_date")) Then Date015.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView2(0)("sindan_date")) ' Date015.Text = DtView2(0)("sindan_date")
            Select Case CLU001.Text
                Case Is = "01", "20", "21", "22", "23", "24", "25"
                    'If Date015.Number = 0 Then Date015.Text = Date003.Text
                    Date015.Enabled = True
                    Date015.BackColor = System.Drawing.SystemColors.Window
                Case Else
            End Select

            If Not IsDBNull(DtView2(0)("etmt_date")) Then Date004.Text = DtView2(0)("etmt_date")

            If Not IsDBNull(DtView2(0)("fix1")) Then NumberN006.Value = DtView2(0)("fix1") Else NumberN006.Value = 0

            If Not IsDBNull(DtView2(0)("etmt_empl_name")) Then Combo_M001.Text = DtView2(0)("etmt_empl_name") Else Combo_M001.Text = Nothing
            If Not IsDBNull(DtView2(0)("tier_name")) Then Combo_M003.Text = DtView2(0)("tier_name") Else Combo_M003.Text = Nothing
            If CK_own_flg.Checked = True Then    'é©é–èCóù
                Edit_M001.Visible = False : Label_M01.Visible = False
                'Combo_M001.Visible = True : Label_M02.Visible = True
                'Combo_M003.Visible = True : Label_M04.Visible = True
            Else
                Edit_M001.Visible = True : Label_M01.Visible = True
                'Combo_M001.Visible = False : Label_M02.Visible = False
                'Combo_M003.Visible = False : Label_M04.Visible = False
                If Not IsDBNull(DtView2(0)("vndr_repr_no")) Then Edit_M001.Text = DtView2(0)("vndr_repr_no") Else Edit_M001.Text = Nothing
            End If

            If Not IsDBNull(DtView2(0)("etmt_meas")) Then Edit_M002.Text = DtView2(0)("etmt_meas") Else Edit_M002.Text = Nothing
            If Not IsDBNull(DtView2(0)("etmt_comn")) Then Edit_M003.Text = DtView2(0)("etmt_comn") Else Edit_M003.Text = Nothing

            If Not IsDBNull(DtView2(0)("tax_rate")) Then tax_rate.Text = DtView2(0)("tax_rate") Else tax_rate.Text = Wk_TAX
            If Not IsDBNull(DtView1(0)("calc_cls")) Then calc_cls.Text = DtView1(0)("calc_cls") Else calc_cls.Text = "1"

            Edit_M004.Enabled = True
            If Not IsDBNull(DtView2(0)("rsrv_cacl_comn")) Then Edit_M004.Text = DtView2(0)("rsrv_cacl_comn") Else Edit_M004.Text = Nothing

            If Not IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then Number031.Value = DtView2(0)("etmt_cost_tech_chrg") Else Number031.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_part_chrg")) Then Number033.Value = DtView2(0)("etmt_cost_part_chrg") Else Number033.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_fee")) Then Number034.Value = DtView2(0)("etmt_cost_fee") Else Number034.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_pstg")) Then Number035.Value = DtView2(0)("etmt_cost_pstg") Else Number035.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_ttl")) Then
                Number036.Value = DtView2(0)("etmt_cost_ttl")
            Else
                Number036.Value = Number031.Value + Number033.Value + Number034.Value + Number035.Value
            End If
            If Not IsDBNull(DtView2(0)("etmt_cost_tax")) Then Number037.Value = DtView2(0)("etmt_cost_tax") Else Number037.Value = 0
            Number038.Value = Number036.Value + Number037.Value
            If Not IsDBNull(DtView2(0)("etmt_shop_cxl")) Then Number019.Value = DtView2(0)("etmt_shop_cxl") Else Number019.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_cxl")) Then Number029.Value = DtView2(0)("etmt_eu_cxl") Else Number029.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_cxl")) Then Number039.Value = DtView2(0)("etmt_cost_cxl") Else Number039.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_apes")) Then Number032.Value = DtView2(0)("etmt_cost_apes") Else Number032.Value = 0
            'If CK_own_flg.Checked = False Then Number032.Value = 0

            If Not IsDBNull(DtView2(0)("etmt_shop_tech_chrg")) Then Number011.Value = DtView2(0)("etmt_shop_tech_chrg") Else Number011.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_apes")) Then Number012.Value = DtView2(0)("etmt_shop_apes") Else Number012.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_part_chrg")) Then Number013.Value = DtView2(0)("etmt_shop_part_chrg") Else Number013.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_fee")) Then Number014.Value = DtView2(0)("etmt_shop_fee") Else Number014.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_pstg")) Then Number015.Value = DtView2(0)("etmt_shop_pstg") Else Number015.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_ttl")) Then
                Number016.Value = DtView2(0)("etmt_shop_ttl")
            Else
                Number016.Value = Number011.Value + Number013.Value + Number014.Value + Number015.Value
            End If
            If Not IsDBNull(DtView2(0)("etmt_shop_tax")) Then Number017.Value = DtView2(0)("etmt_shop_tax") Else Number017.Value = 0
            Number018.Value = Number016.Value + Number017.Value

            If Not IsDBNull(DtView2(0)("etmt_eu_tech_chrg")) Then Number021.Value = DtView2(0)("etmt_eu_tech_chrg") Else Number021.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_apes")) Then Number022.Value = DtView2(0)("etmt_eu_apes") Else Number022.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_part_chrg")) Then Number023.Value = DtView2(0)("etmt_eu_part_chrg") Else Number023.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_fee")) Then Number024.Value = DtView2(0)("etmt_eu_fee") Else Number024.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_pstg")) Then Number025.Value = DtView2(0)("etmt_eu_pstg") Else Number025.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_ttl")) Then
                Number026.Value = DtView2(0)("etmt_eu_ttl")
            Else
                Number026.Value = Number021.Value + Number023.Value + Number024.Value + Number025.Value
            End If
            If Not IsDBNull(DtView2(0)("etmt_eu_tax")) Then Number027.Value = DtView2(0)("etmt_eu_tax") Else Number027.Value = 0
            Number028.Value = Number026.Value + Number027.Value

            'å©êœì‡óe
            strSQL = "SELECT T03_REP_CMNT.rcpt_no, T03_REP_CMNT.kbn, T03_REP_CMNT.seq, T03_REP_CMNT.cls_code1"
            strSQL += ", T03_REP_CMNT.cmnt_code1, T03_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
            strSQL += " FROM T03_REP_CMNT LEFT OUTER JOIN"
            strSQL += " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
            strSQL += " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
            strSQL += " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
            strSQL += " AND (T03_REP_CMNT.kbn = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "T03_REP_CMNT_2")
            DB_CLOSE()

            Line_No3 = -1
            Panel_M1.Controls.Clear()

            WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_2"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    add_line_3()    'å©êœì‡óe
                Next
            End If

            'ïîïi
            Dim tbl As New DataTable
            tbl = P_DsList1.Tables("T04_REP_PART")
            DataGrid_M1.DataSource = tbl

            'ë±çsï‘ãpèÓïÒ **********************************
            If Not IsDBNull(DtView2(0)("rsrv_cacl_date")) Then Date006.Text = DtView2(0)("rsrv_cacl_date")
            Date006.Enabled = True
            If Not IsDBNull(DtView2(0)("zh_code")) Then ZH.Text = DtView2(0)("zh_code") Else ZH.Text = Nothing

            'äÆóπèÓïÒ **********************************
            If IsDBNull(DtView3(0)("comp_sum_flg")) Then
                CheckBox_K001.Checked = False
            Else
                If DtView3(0)("comp_sum_flg") = "False" Then
                    CheckBox_K001.Checked = False
                Else
                    CheckBox_K001.Checked = True
                End If
            End If
            CheckBox_K001.AutoCheck = True
            If IsDBNull(DtView3(0)("apple_Dlvy_rep_flg")) Then
                CheckBox_K002.Checked = False
            Else
                If DtView3(0)("apple_Dlvy_rep_flg") = "False" Then
                    CheckBox_K002.Checked = False
                Else
                    CheckBox_K002.Checked = True
                End If
            End If
            CheckBox_K002.AutoCheck = True
            'If CK_own_flg.Checked = True Then    'é©é–èCóù
            Cmb3()  'èCóùíSìñ
            '    Combo_K001.Visible = True : Label_K01.Visible = True
            'Else
            '    Combo_K001.Visible = False : Label_K01.Visible = False
            'End If

            Select Case CL004.Text
                Case Is = "02", "04"   'ÉÅÅ[ÉJÅ[ï€èÿÅAÇªÇÃëºï€èÿ
                    Cmb4()  'ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóø
                    Combo_K002.Visible = True : Label_K02.Visible = True
                Case Else
                    Combo_K002.Visible = False : Label_K02.Visible = False
            End Select

            Dim WK_i As Integer = 0
            Combo006.Items.Clear()
            If Not IsDBNull(DtView3(0)("sals_no")) Then Combo006.Items.Add(DtView3(0)("sals_no")) : Combo006.Text = DtView3(0)("sals_no") : WK_i = 1
            If Not IsDBNull(DtView3(0)("sals_no2")) Then Combo006.Items.Add(DtView3(0)("sals_no2")) : WK_i = WK_i + 1
            Combo006.Enabled = True
            If WK_i > 1 Then
                Combo006.DropDown.Visible = GrapeCity.Win.Input.Interop.Visibility.ShowAlways
            Else
                Combo006.DropDown.Visible = GrapeCity.Win.Input.Interop.Visibility.NotShown
            End If

            Combo_K001.Enabled = True
            If Not IsDBNull(DtView3(0)("repr_empl_name")) Then Combo_K001.Text = DtView3(0)("repr_empl_name") Else Combo_K001.Text = Nothing
            If Not IsDBNull(DtView3(0)("repr_empl_code")) Then CLK001.Text = DtView3(0)("repr_empl_code") Else CLK001.Text = Nothing
            If Not IsDBNull(DtView3(0)("repr_brch_code")) Then CLK001_BRH.Text = DtView3(0)("repr_brch_code") Else CLK001_BRH.Text = Nothing

            Combo_K002.Enabled = True
            If Not IsDBNull(DtView3(0)("select_case")) Then Combo_K002.Text = DtView3(0)("select_case") Else Combo_K002.Text = Nothing

            Combo_K003.Enabled = True
            If Not IsDBNull(DtView3(0)("kjo_brch_code")) Then
                CLK003.Text = DtView3(0)("kjo_brch_code")
                If Not IsDBNull(DtView3(0)("kjo_brch_name")) Then Combo_K003.Text = DtView3(0)("kjo_brch_name")
            Else
                If CK_own_flg.Checked = True Then   'é©é–èCóù
                    'CLK003.Text = DtView1(0)("brch_code")
                    'prabu added 2021-04-08
                    If DtView1.Count <> 0 Then
                        CLK003.Text = DtView1(0)("brch_code")
                    End If
                Else
                    CLK003.Text = DtView1(0)("rcpt_brch_code")
                End If
                WK_DtView1 = New DataView(DsCMB3.Tables("M03_BRCH"), "brch_code = '" & CLK003.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Combo_K003.Text = WK_DtView1(0)("brch_name")
                End If
            End If

            Combo_K004.Enabled = True
            CLK004.Text = Nothing : Combo_K004.Text = Nothing
            If Not IsDBNull(DtView3(0)("payment_type")) Then
                CLK004.Text = DtView3(0)("payment_type")
                If Not IsDBNull(DtView3(0)("payment_type_name")) Then Combo_K004.Text = DtView3(0)("payment_type_name")
            End If

            Edit_K001.Enabled = True
            If Not IsDBNull(DtView3(0)("comp_meas")) Then Edit_K001.Text = DtView3(0)("comp_meas")
            Edit_K002.Enabled = True
            If Not IsDBNull(DtView3(0)("comp_comn")) Then Edit_K002.Text = DtView3(0)("comp_comn")
            Edit_K003.Enabled = True
            If Not IsDBNull(DtView3(0)("sb_imei_new")) Then Edit_K003.Text = DtView3(0)("sb_imei_new")
            Edit_K004.Text = Nothing
            If CL001.Text = "12" Then Edit_K004.Enabled = True Else Edit_K004.Enabled = False
            'If P_ACES_post_code >= "02" Then Number111.Enabled = True
            Number111.Enabled = True
            Number112.Enabled = True
            'If P_ACES_post_code >= "02" Then Number113.Enabled = True
            Number113.Enabled = True
            Number114.Enabled = True
            Number115.Enabled = True
            'If P_ACES_post_code >= "02" Then Number121.Enabled = True
            Number121.Enabled = True
            'If P_ACES_post_code >= "02" Then Number123.Enabled = True
            Number123.Enabled = True
            Number124.Enabled = True
            Number125.Enabled = True
            'If P_ACES_post_code >= "02" Then Number131.Enabled = True
            'Number131.Enabled = True
            'Number132.Enabled = True
            'If P_ACES_post_code >= "02" Then Number133.Enabled = True
            Number133.Enabled = True
            Number134.Enabled = True
            Number135.Enabled = True

            If IsDBNull(DtView3(0)("comp_cost_ttl")) And ZH.Text = "H" Then
                inz_F = "1"
                NumberN006.Value = 0
                Number131.Value = Number039.Value
                Number111.Value = Number019.Value
                Number121.Value = Number029.Value
                Number133.Value = 0
                Number113.Value = 0
                Number123.Value = 0
                inz_F = "0"
            Else
                If Not IsDBNull(DtView3(0)("comp_cost_tech_chrg")) Then Number131.Value = DtView3(0)("comp_cost_tech_chrg") Else Number131.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_apes")) Then Number132.Value = DtView3(0)("comp_cost_apes") Else Number132.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_part_chrg")) Then Number133.Value = DtView3(0)("comp_cost_part_chrg") Else Number133.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_fee")) Then Number134.Value = DtView3(0)("comp_cost_fee") Else Number134.Value = 0
                'If P_ACES_post_code >= "02" Then Number134.Enabled = True
                If Not IsDBNull(DtView3(0)("comp_cost_pstg")) Then Number135.Value = DtView3(0)("comp_cost_pstg") Else Number135.Value = 0
                'If P_ACES_post_code >= "02" Then Number135.Enabled = True
                If Not IsDBNull(DtView3(0)("comp_cost_tax")) Then Number137.Value = DtView3(0)("comp_cost_tax") Else Number137.Value = 0
                If CK_own_flg.Checked = False Then Number132.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_ttl")) Then
                    Number136.Value = DtView3(0)("comp_cost_ttl")
                Else
                    Number136.Value = Number131.Value + Number132.Value + Number133.Value + Number134.Value + Number135.Value
                End If
                Number138.Value = Number136.Value + Number137.Value

                If Not IsDBNull(DtView3(0)("comp_shop_tech_chrg")) Then Number111.Value = DtView3(0)("comp_shop_tech_chrg") Else Number111.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_apes")) Then Number112.Value = DtView3(0)("comp_shop_apes") Else Number112.Value = 0
                If CK_own_flg.Checked = False Then Number112.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_part_chrg")) Then Number113.Value = DtView3(0)("comp_shop_part_chrg") Else Number113.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_fee")) Then Number114.Value = DtView3(0)("comp_shop_fee") Else Number114.Value = 0
                'If P_ACES_post_code >= "02" Then Number114.Enabled = True
                If Not IsDBNull(DtView3(0)("comp_shop_pstg")) Then Number115.Value = DtView3(0)("comp_shop_pstg") Else Number115.Value = 0
                'If P_ACES_post_code >= "02" Then Number115.Enabled = True
                If Not IsDBNull(DtView3(0)("comp_shop_tax")) Then Number117.Value = DtView3(0)("comp_shop_tax") Else Number117.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_ttl")) Then
                    Number116.Value = DtView3(0)("comp_shop_ttl")
                Else
                    Number116.Value = Number111.Value + Number112.Value + Number113.Value + Number114.Value + Number115.Value
                End If
                Number118.Value = Number116.Value + Number117.Value

                If Not IsDBNull(DtView3(0)("comp_eu_tech_chrg")) Then Number121.Value = DtView3(0)("comp_eu_tech_chrg") Else Number121.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_apes")) Then Number122.Value = DtView3(0)("comp_eu_apes") Else Number122.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_part_chrg")) Then Number123.Value = DtView3(0)("comp_eu_part_chrg") Else Number123.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_fee")) Then Number124.Value = DtView3(0)("comp_eu_fee") Else Number124.Value = 0
                'If P_ACES_post_code >= "02" Then Number124.Enabled = True
                If Not IsDBNull(DtView3(0)("comp_eu_pstg")) Then Number125.Value = DtView3(0)("comp_eu_pstg") Else Number125.Value = 0
                'If P_ACES_post_code >= "02" Then Number125.Enabled = True
                If Not IsDBNull(DtView3(0)("comp_eu_tax")) Then Number127.Value = DtView3(0)("comp_eu_tax") Else Number127.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_ttl")) Then
                    Number126.Value = DtView3(0)("comp_eu_ttl")
                Else
                    Number126.Value = Number121.Value + Number123.Value + Number124.Value + Number125.Value
                End If
                Number128.Value = Number126.Value + Number127.Value
            End If

            If Not IsDBNull(DtView3(0)("zero_code")) Then zero_code.Text = DtView3(0)("zero_code")
            If Not IsDBNull(DtView3(0)("zero_name")) Then zero_name.Text = DtView3(0)("zero_name")
            If Not IsDBNull(DtView3(0)("rebate")) Then rebate.Value = DtView3(0)("rebate")
            If Not IsDBNull(DtView3(0)("idvd_chrg")) Then idvd_chrg.Value = DtView3(0)("idvd_chrg")
            If Not IsDBNull(DtView3(0)("sals_amnt1")) Then NumberN011.Value = DtView3(0)("sals_amnt1")
            If Not IsDBNull(DtView3(0)("sals_amnt2")) Then NumberN012.Value = DtView3(0)("sals_amnt2")
            If Not IsDBNull(DtView3(0)("sals_amnt3")) Then NumberN013.Value = DtView3(0)("sals_amnt3")
            If Not IsDBNull(DtView3(0)("sals_amnt5")) Then NumberN015.Value = DtView3(0)("sals_amnt5")

            'äÆóπì‡óe
            Line_No4 = -1
            Panel_K1.Controls.Clear()
            WK_DsCMB4.Clear()

            'äÓèÄì_
            label_4(0, 0) = New Label
            label_4(0, 0).Location = New System.Drawing.Point(0, 0)
            label_4(0, 0).Size = New System.Drawing.Size(0, 0)
            label_4(0, 0).Text = Nothing
            Panel_K1.Controls.Add(label_4(0, 0))

            WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_3"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    add_line_4("1")    'äÆóπì‡óe
                Next
            End If
            add_line_4("0")    'äÆóπì‡óe

            'ïîïi
            Dim tbl2 As New DataTable
            tbl2 = P_DsList1.Tables("T04_REP_PART_2")
            DataGrid_K1.DataSource = tbl2

            WK_DtView2 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "", "", DataViewRowState.CurrentRows)

            'If Combo_K001.Visible = True Then
            Combo_K001.Focus()
            'Else
            '    If Combo_K002.Visible = True Then
            '        Combo_K002.Focus()
            '    Else
            '        cmbBo_4(0, 1).Focus()
            '    End If
            'End If

            If ZH.Text <> "H" Then
                If WK_DtView1.Count = 0 Then
                    If WK_DtView2.Count = 0 Then
                        If Number038.Value <> 0 Or Number028.Value <> 0 Or Number018.Value <> 0 Then
                            Button_K002.Enabled = True
                        End If
                    End If
                End If
            End If
            Button_K001.Enabled = True

            'êøãÅ
            Dim WK_invc As Integer
            WK_DtView1 = New DataView(DsList1.Tables("T21_INVC_SUB"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    WK_invc = WK_invc + WK_DtView1(i)("invc_amnt")
                Next
            End If

            'ì¸ã‡
            Dim WK_clct As Integer
            WK_DtView1 = New DataView(DsList1.Tables("T30_CLCT"), "", "clct_date", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    Date014.Text = WK_DtView1(i)("clct_date")   'ì¸ã‡ì˙
                    WK_clct = WK_clct + WK_DtView1(i)("clct_amnt")
                Next
            End If
            Number004.Value = WK_invc - WK_clct

            Irregular() 'ÉCÉåÉMÉÖÉâÅ[èàóù

            Call CONTACT_GET(Edit000.Text)
            cntact1.Text = P1_CONTACT
            cntact2.Text = P2_CONTACT
            CheckBox1.Enabled = True
            If P3_CONTACT = "True" Then CheckBox1.Checked = True Else CheckBox1.Checked = False

            'Q&AèCóùïsâ¬É`ÉFÉbÉNï\é¶êßå‰
            QA_F = QA_data(Edit000.Text)

            's/nïœçXóöó
            Button97.Visible = False : sn_n.Text = "0"
            If Edit011.Text <> Nothing Then
                P_Ds_sn.Clear()
                strSQL = "SELECT * FROM T06_sno WHERE (code = '" & Edit011.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("QGCare")
                r = DaList1.Fill(P_Ds_sn, "T06_sno")
                DB_CLOSE()
                If r <> 0 Then
                    Button97.Visible = True : sn_n.Text = r
                End If
            End If

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'åÃè·ì‡óe
    Sub add_line_2()
        DB_OPEN("nMVAR")
        Line_No2 = Line_No2 + 1

        'åÃè·ì‡óe
        en = 1
        cmbBo_2(Line_No2, en) = New GrapeCity.Win.Input.Interop.Combo
        cmbBo_2(Line_No2, en).Location = New System.Drawing.Point(1, 20 * Line_No2)
        cmbBo_2(Line_No2, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_2(Line_No2, en).Size = New System.Drawing.Size(498, 20)
        cmbBo_2(Line_No2, en).Enabled = False
        cmbBo_2(Line_No2, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        Panel_U2.Controls.Add(cmbBo_2(Line_No2, en))
        If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
            cmbBo_2(Line_No2, en).Text = WK_DtView1(i)("cmnt_name1")
        Else
            cmbBo_2(Line_No2, en).Text = Nothing
        End If

        DB_CLOSE()
    End Sub

    'å©êœì‡óe
    Sub add_line_3()
        DB_OPEN("nMVAR")
        Line_No3 = Line_No3 + 1

        'å©êœì‡óe
        en = 1
        cmbBo_3(Line_No3, en) = New GrapeCity.Win.Input.Interop.Combo
        cmbBo_3(Line_No3, en).Location = New System.Drawing.Point(1, 20 * Line_No3)
        cmbBo_3(Line_No3, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_3(Line_No3, en).Size = New System.Drawing.Size(465, 20)
        cmbBo_3(Line_No3, en).Enabled = False
        cmbBo_3(Line_No3, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        Panel_M1.Controls.Add(cmbBo_3(Line_No3, en))
        If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
            cmbBo_3(Line_No3, en).Text = WK_DtView1(i)("cmnt_name1")
        Else
            cmbBo_3(Line_No3, en).Text = Nothing
        End If

        DB_CLOSE()
    End Sub

    'èCóùì‡óe
    Sub add_line_4(ByVal flg)
        DB_OPEN("nMVAR")
        Line_No4 = Line_No4 + 1

        'èCóùì‡óe
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL += " FROM M10_CMNT"
        strSQL += " WHERE (cls_code = '21') AND (delt_flg = 0)"
        strSQL += " ORDER BY cmnt_code + ':' + cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsCMB4, "M10_CMNT_4" & Line_No4)

        en = 1
        cmbBo_4(Line_No4, en) = New GrapeCity.Win.Input.Interop.Combo
        cmbBo_4(Line_No4, en).Location = New System.Drawing.Point(1, 20 * Line_No4 + label_4(0, 0).Location.Y)
        cmbBo_4(Line_No4, en).MaxDropDownItems = 30
        'cmbBo_4(Line_No4, en).HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
        cmbBo_4(Line_No4, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_4(Line_No4, en).Size = New System.Drawing.Size(465, 20)
        cmbBo_4(Line_No4, en).DataSource = WK_DsCMB4.Tables("M10_CMNT_4" & Line_No4)
        cmbBo_4(Line_No4, en).AutoSelect = True
        cmbBo_4(Line_No4, en).DisplayMember = "cmnt"
        cmbBo_4(Line_No4, en).ValueMember = "cmnt_code"
        cmbBo_4(Line_No4, en).Tag = Line_No4
        Panel_K1.Controls.Add(cmbBo_4(Line_No4, en))
        AddHandler cmbBo_4(Line_No4, en).GotFocus, AddressOf cmb4_1_GotFocus
        AddHandler cmbBo_4(Line_No4, en).LostFocus, AddressOf cmb4_1_LostFocus
        If flg = "1" Then
            If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
                cmbBo_4(Line_No4, en).Text = WK_DtView1(i)("cmnt_name1")
            Else
                cmbBo_4(Line_No4, en).Text = Nothing
            End If
        Else
            cmbBo_4(Line_No4, en).Text = Nothing
        End If

        'èCóùì‡óe∫∞ƒﬁ
        en = 1
        label_4(Line_No4, en) = New Label
        If flg = "1" Then
            If Not IsDBNull(WK_DtView1(i)("cmnt_code1")) Then
                label_4(Line_No4, en).Text = WK_DtView1(i)("cmnt_code1")
            Else
                label_4(Line_No4, en).Text = Nothing
            End If
        Else
            label_4(Line_No4, en).Text = Nothing
        End If
        label_4(Line_No4, en).Location = New System.Drawing.Point(500, 20 * Line_No4 + label_4(0, 0).Location.Y)
        label_4(Line_No4, en).Size = New System.Drawing.Size(50, 20)
        label_4(Line_No4, en).Visible = False
        Panel_K1.Controls.Add(label_4(Line_No4, en))

        'SEQ
        en = 2
        label_4(Line_No4, en) = New Label
        If flg = "1" Then
            label_4(Line_No4, en).Text = WK_DtView1(i)("seq")
        Else
            label_4(Line_No4, en).Text = Nothing
        End If
        label_4(Line_No4, en).Location = New System.Drawing.Point(600, 20 * Line_No4 + label_4(0, 0).Location.Y)
        label_4(Line_No4, en).Size = New System.Drawing.Size(50, 20)
        label_4(Line_No4, en).Visible = False
        Panel_K1.Controls.Add(label_4(Line_No4, en))

        DB_CLOSE()
    End Sub
    'èCóùì‡óe
    Sub add_line_4_2(ByVal Line_No4, ByVal cmnt_name1, ByVal cmnt_code1)
        DB_OPEN("nMVAR")

        'èCóùì‡óe
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL += " FROM M10_CMNT"
        strSQL += " WHERE (cls_code = '21') AND (delt_flg = 0)"
        strSQL += " ORDER BY cmnt_code + ':' + cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsCMB4, "M10_CMNT_4" & Line_No4)

        en = 1
        cmbBo_4(Line_No4, en) = New GrapeCity.Win.Input.Interop.Combo
        cmbBo_4(Line_No4, en).Location = New System.Drawing.Point(1, 20 * Line_No4 + label_4(0, 0).Location.Y)
        cmbBo_4(Line_No4, en).MaxDropDownItems = 30
        cmbBo_4(Line_No4, en).HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
        cmbBo_4(Line_No4, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_4(Line_No4, en).Size = New System.Drawing.Size(465, 20)
        cmbBo_4(Line_No4, en).DataSource = WK_DsCMB4.Tables("M10_CMNT_4" & Line_No4)
        cmbBo_4(Line_No4, en).AutoSelect = True
        cmbBo_4(Line_No4, en).DisplayMember = "cmnt"
        cmbBo_4(Line_No4, en).ValueMember = "cmnt_code"
        cmbBo_4(Line_No4, en).Tag = Line_No4
        Panel_K1.Controls.Add(cmbBo_4(Line_No4, en))
        AddHandler cmbBo_4(Line_No4, en).GotFocus, AddressOf cmb4_1_GotFocus
        AddHandler cmbBo_4(Line_No4, en).LostFocus, AddressOf cmb4_1_LostFocus
        cmbBo_4(Line_No4, en).Text = WK_DtView1(i)("cmnt_name1")

        'èCóùì‡óe∫∞ƒﬁ
        en = 1
        label_4(Line_No4, en) = New Label
        label_4(Line_No4, en).Text = cmnt_code1
        label_4(Line_No4, en).Location = New System.Drawing.Point(500, 20 * Line_No4 + label_4(0, 0).Location.Y)
        label_4(Line_No4, en).Size = New System.Drawing.Size(50, 20)
        label_4(Line_No4, en).Visible = False
        Panel_K1.Controls.Add(label_4(Line_No4, en))

        'SEQ
        en = 2
        label_4(Line_No4, en) = New Label
        label_4(Line_No4, en).Text = Nothing
        label_4(Line_No4, en).Location = New System.Drawing.Point(600, 20 * Line_No4 + label_4(0, 0).Location.Y)
        label_4(Line_No4, en).Size = New System.Drawing.Size(50, 20)
        label_4(Line_No4, en).Visible = False
        Panel_K1.Controls.Add(label_4(Line_No4, en))

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** ÅHéÛïtî‘çÜåüçı
    '********************************************************************
    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form04 As New F00_Form04
        F00_Form04.ShowDialog()

        If P_RTN = "1" Then
            Button13_Click(sender, e)
            Edit000.Text = P_PRAM1
            rep_scan()  '** èCóùèÓïÒÇfÇdÇs
            inz_F = "1"
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  åüçı
    '********************************************************************
    Private Sub Button_S2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S2.Click
        'èCóùÉRÉÅÉìÉg
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = "22"  'èCóùÉRÉÅÉìÉg
        Dim F00_Form06 As New F00_Form06
        F00_Form06.ShowDialog()

        If P_RTN = "1" Then
            If Edit_K002.Text = Nothing Then
                Edit_K002.Text = P_PRAM1
            Else
                If Edit_K002.Text.LastIndexOf(P_PRAM1) = -1 Then
                    Edit_K002.Text = Trim(Edit_K002.Text) & System.Environment.NewLine & P_PRAM1
                End If
            End If
        End If
        Edit_K002.Focus()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** éÛïtâÊñ 
    '********************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Panel_éÛït.Visible = True
        Panel_å©êœ.Visible = False
        Panel_äÆóπ.Visible = False
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button13.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '** å©êœâÊñ 
    '********************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Panel_éÛït.Visible = False
        Panel_å©êœ.Visible = True
        Panel_äÆóπ.Visible = False
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button13.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '** äÆóπâÊñ 
    '********************************************************************
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Panel_éÛït.Visible = False
        Panel_å©êœ.Visible = False
        Panel_äÆóπ.Visible = True
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button13.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '** ïîïiì¸óÕ
    '********************************************************************
    Private Sub Button_K001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_K001.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P1_F00_Form03 = CLU001.Text
        P2_F00_Form03 = "2"
        P3_F00_Form03 = Edit000.Text

        If CL004.Text = "01" Then 'óLèû
            P4_F00_Form03 = Irregular_F
            P_part_rate1 = NumberN008.Value
        Else                    'ñ≥èû
            Select Case CLU001.Text
                Case Is = "10"  'NEC
                    P4_F00_Form03 = "Z"
                    P_part_rate1 = 0
                Case Is = "13"  'Fujitsu
                    P4_F00_Form03 = "1"
                    P_part_rate1 = 1
                Case Else
                    P4_F00_Form03 = Irregular_F
                    P_part_rate1 = NumberN008.Value
            End Select
        End If
        P5_F00_Form03 = CL004.Text
        P6_F00_Form03 = GRP.Text
        P7_F00_Form03 = CheckBox_U001.Checked
        P8_F00_Form03 = CK_own_flg.Checked

        Dim F00_Form03 As New F00_Form03
        F00_Form03.ShowDialog()

        If P_RTN = "1" Then
            Dim WK_amt1, WK_amt2, WK_amt3 As Integer
            WK_DtView3 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView3.Count <> 0 Then
                For i = 0 To WK_DtView3.Count - 1
                    'WK_amt3 = WK_amt3 + WK_DtView3(i)("part_amnt") * WK_DtView3(i)("use_qty")
                    WK_amt3 = WK_amt3 + WK_DtView3(i)("cost_chrg")
                    WK_amt1 = WK_amt1 + WK_DtView3(i)("shop_chrg")
                    WK_amt2 = WK_amt2 + WK_DtView3(i)("eu_chrg")
                Next
            End If
            Number133.Value = WK_amt3
            Number113.Value = WK_amt1
            Number123.Value = WK_amt2
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  çÄñ⁄É`ÉFÉbÉN
    '********************************************************************
    Sub CHK_Edit012()   'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        msg.Text = Nothing
        Edit012.Text = Trim(Edit012.Text)

        If CL004.Text = "02" Then   '“∞∂∞ï€èÿ
            If Edit012.Text = Nothing Then
                Edit012.BackColor = System.Drawing.Color.Red
                msg.Text = "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date006()   'âÒìöéÛêMì˙
        msg.Text = Nothing

        If CL004.Text = "01" Then   'óLèû
            If Date004.Number <> 0 Then
                If Date006.Number = 0 Then
                    Date006.BackColor = System.Drawing.Color.Red
                    msg.Text = Label37.Text & "Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If
        End If

        Date006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date007()   'ïîïiî≠íçì˙
        msg.Text = Nothing : WK_MSG = Nothing

        If CK_own_flg.Checked = True Then   'é©é–èCóù
            WK_DtView2 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "zaiko_flg = 'False'", "", DataViewRowState.CurrentRows)
            If WK_DtView2.Count <> 0 Then   'î≠íçÇ†ÇË
                If Date007.Number = 0 Then
                    Date007.BackColor = System.Drawing.Color.Red
                    msg.Text = Label015.Text & "Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                    WK_MSG = msg.Text
                    Exit Sub
                End If

                'If Date003.Text > Date007.Text Then         'éÛïtì˙>ïîïiî≠íçì˙
                '    Date007.BackColor = System.Drawing.Color.Red
                '    msg.Text = "éÛïtì˙ÅÑïîïiî≠íçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                '    Exit Sub
                'End If

                'If Date004.Number <> 0 Then
                '    If Date004.Text > Date007.Text Then     'å©êœì˙>ïîïiî≠íçì˙
                '        Date007.BackColor = System.Drawing.Color.Red
                '        msg.Text = "å©êœì˙ÅÑïîïiî≠íçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                '        Exit Sub
                '    End If
                'End If

                'If Date006.Number <> 0 Then
                '    If Date006.Text > Date007.Text Then     'âÒìöéÛêMì˙>ïîïiî≠íçì˙
                '        Date007.BackColor = System.Drawing.Color.Red
                '        msg.Text = "âÒìöéÛêMì˙ÅÑïîïiî≠íçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                '        Exit Sub
                '    End If
                'End If

                Select Case Date007.Text
                    Case Is < DateAdd(DateInterval.Year, -1, Now).Date '1îNà»è„âﬂãéì˙ït
                        Date007.BackColor = System.Drawing.Color.Red
                        msg.Text = Label015.Text & "Ç…1îNà»è„à»ëOÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        WK_MSG = msg.Text
                        Exit Sub
                    Case Is > Now.Date  'ñ¢óàì˙ït
                        Date007.BackColor = System.Drawing.Color.Red
                        msg.Text = Label015.Text & "Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        WK_MSG = msg.Text
                        Exit Sub
                End Select

            Else                            'î≠íçÇ»Çµ
                If Date007.Number <> 0 Then
                    Date007.BackColor = System.Drawing.Color.Red
                    msg.Text = "î≠íçÇµÇΩïîïiÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                    WK_MSG = msg.Text
                    Exit Sub
                End If
            End If
        Else                                'ëºé–èCóù
            If Date007.Number = 0 Then
                Date007.BackColor = System.Drawing.Color.Red
                msg.Text = Label015.Text & "Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Date007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date008()   'ïîïiéÛóÃì˙
        msg.Text = Nothing : WK_MSG = Nothing

        If CK_own_flg.Checked = True Then   'é©é–èCóù
            WK_DtView2 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "zaiko_flg = 'False'", "", DataViewRowState.CurrentRows)
            If WK_DtView2.Count <> 0 Then   'î≠íçÇ†ÇË
                If Date008.Number = 0 Then
                    Date008.BackColor = System.Drawing.Color.Red
                    msg.Text = Label016.Text & "Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                    WK_MSG = msg.Text
                    Exit Sub
                End If

                'If Date003.Text > Date008.Text Then         'éÛïtì˙>ïîïiéÛóÃì˙
                '    Date008.BackColor = System.Drawing.Color.Red
                '    msg.Text = "éÛïtì˙ÅÑïîïiéÛóÃì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                '    Exit Sub
                'End If

                'If Date004.Number <> 0 Then
                '    If Date004.Text > Date008.Text Then     'å©êœì˙>ïîïiéÛóÃì˙
                '        Date008.BackColor = System.Drawing.Color.Red
                '        msg.Text = "å©êœì˙ÅÑïîïiéÛóÃì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                '        Exit Sub
                '    End If
                'End If

                'If Date006.Number <> 0 Then
                '    If Date006.Text > Date008.Text Then     'âÒìöéÛêMì˙>ïîïiéÛóÃì˙
                '        Date008.BackColor = System.Drawing.Color.Red
                '        msg.Text = "âÒìöéÛêMì˙ÅÑïîïiéÛóÃì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                '        Exit Sub
                '    End If
                'End If

                If Date007.Number <> 0 Then
                    If Date007.Text > Date008.Text Then     'ïîïiî≠íçì˙>ïîïiéÛóÃì˙
                        Date008.BackColor = System.Drawing.Color.Red
                        msg.Text = Label015.Text & "ÅÑ" & Label016.Text & "ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        WK_MSG = msg.Text
                        Exit Sub
                    End If
                End If

                Select Case Date008.Text
                    Case Is < DateAdd(DateInterval.Year, -1, Now).Date '1îNà»è„âﬂãéì˙ït
                        Date008.BackColor = System.Drawing.Color.Red
                        msg.Text = Label016.Text & "Ç…1îNà»è„à»ëOÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        WK_MSG = msg.Text
                        Exit Sub
                    Case Is > Now.Date  'ñ¢óàì˙ït
                        Date008.BackColor = System.Drawing.Color.Red
                        msg.Text = Label016.Text & "Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        WK_MSG = msg.Text
                        Exit Sub
                End Select

            Else                            'î≠íçÇ»Çµ
                If Date008.Number <> 0 Then
                    Date008.BackColor = System.Drawing.Color.Red
                    msg.Text = "î≠íçÇµÇΩïîïiÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                    WK_MSG = msg.Text
                    Exit Sub
                End If
            End If
        Else                                'ëºé–èCóù
            If Date008.Number = 0 Then
                Date008.BackColor = System.Drawing.Color.Red
                msg.Text = Label016.Text & "Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Date008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date016()   'èCóùì˙
        msg.Text = Nothing

        If Date016.Number = 0 Then
            'Date016.BackColor = System.Drawing.Color.Red
            'msg.Text = "èCóùì˙Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        End If

        If Date003.Text > Date016.Text Then         'éÛïtì˙>èCóùì˙
            Date016.BackColor = System.Drawing.Color.Red
            msg.Text = "éÛïtì˙ÅÑèCóùì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
            Exit Sub
        End If

        If Date004.Number <> 0 Then
            If Date004.Text > Date016.Text Then     'å©êœì˙>èCóùì˙
                Date016.BackColor = System.Drawing.Color.Red
                msg.Text = "å©êœì˙ÅÑèCóùì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date006.Number <> 0 Then
            If Date006.Text > Date016.Text Then     'âÒìöéÛêMì˙>èCóùì˙
                Date016.BackColor = System.Drawing.Color.Red
                msg.Text = "âÒìöéÛêMì˙ÅÑèCóùì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date007.Number <> 0 Then
            If Date007.Text > Date016.Text Then     'ïîïiî≠íçì˙>èCóùì˙
                Date016.BackColor = System.Drawing.Color.Red
                msg.Text = "ïîïiî≠íçì˙ÅÑèCóùì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date008.Number <> 0 Then
            If Date008.Text > Date016.Text Then     'ïîïiéÛóÃì˙>èCóùì˙
                Date016.BackColor = System.Drawing.Color.Red
                msg.Text = "ïîïiéÛóÃì˙ÅÑèCóùì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        Select Case Date016.Text
            Case Is < Mid(Now.Date, 1, 8) & "01" 'ìñåéà»ëO
                Date016.BackColor = System.Drawing.Color.Red
                msg.Text = "èCóùì˙ÇÕìñåéÇÃì¸óÕÇµÇ©Ç≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            Case Is > Now.Date & " 23:59:59"  'ñ¢óàì˙ït
                Date016.BackColor = System.Drawing.Color.Red
                msg.Text = "èCóùì˙Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
        End Select

        Date016.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date017()   'äÆóπòAóçì˙
        msg.Text = Nothing

        If Date017.Number = 0 Then
            'Date017.BackColor = System.Drawing.Color.Red
            'msg.Text = "äÆóπòAóçì˙Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        End If

        If Date003.Text > Date017.Text Then         'éÛïtì˙>äÆóπòAóçì˙
            Date017.BackColor = System.Drawing.Color.Red
            msg.Text = "éÛïtì˙ÅÑäÆóπòAóçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
            Exit Sub
        End If

        If Date004.Number <> 0 Then
            If Date004.Text > Date017.Text Then     'å©êœì˙>äÆóπòAóçì˙
                Date017.BackColor = System.Drawing.Color.Red
                msg.Text = "å©êœì˙ÅÑäÆóπòAóçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date006.Number <> 0 Then
            If Date006.Text > Date017.Text Then     'âÒìöéÛêMì˙>äÆóπòAóçì˙
                Date017.BackColor = System.Drawing.Color.Red
                msg.Text = "âÒìöéÛêMì˙ÅÑäÆóπòAóçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date007.Number <> 0 Then
            If Date007.Text > Date017.Text Then     'ïîïiî≠íçì˙>äÆóπòAóçì˙
                Date017.BackColor = System.Drawing.Color.Red
                msg.Text = "ïîïiî≠íçì˙ÅÑäÆóπòAóçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date008.Number <> 0 Then
            If Date008.Text > Date017.Text Then     'ïîïiéÛóÃì˙>äÆóπòAóçì˙
                Date017.BackColor = System.Drawing.Color.Red
                msg.Text = "ïîïiéÛóÃì˙ÅÑäÆóπòAóçì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        Select Case Date017.Text
            Case Is < Mid(Now.Date, 1, 8) & "01" 'ìñåéà»ëO
                Date017.BackColor = System.Drawing.Color.Red
                msg.Text = "äÆóπòAóçì˙ÇÕìñåéÇÃì¸óÕÇµÇ©Ç≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            Case Is > Now.Date & " 23:59:59"  'ñ¢óàì˙ït
                Date017.BackColor = System.Drawing.Color.Red
                msg.Text = "äÆóπòAóçì˙Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
        End Select

        Date017.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date010()   'äÆóπì˙
        msg.Text = Nothing

        If Date010.Number = 0 Then
            Date010.BackColor = System.Drawing.Color.Red
            msg.Text = "äÆóπì˙Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Label017.Text = "åoâﬂì˙êîÅF" & DateDiff(DateInterval.Day, CDate(Date003.Text), Now.Date)
            Exit Sub
        End If
        Label017.Text = "åoâﬂì˙êîÅF" & DateDiff(DateInterval.Day, CDate(Date003.Text), CDate(Date010.Text))

        If Date003.Text > Date010.Text Then         'éÛïtì˙>äÆóπì˙
            Date010.BackColor = System.Drawing.Color.Red
            msg.Text = "éÛïtì˙ÅÑäÆóπì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
            Exit Sub
        End If

        If Date004.Number <> 0 Then
            If Date004.Text > Date010.Text Then     'å©êœì˙>äÆóπì˙
                Date010.BackColor = System.Drawing.Color.Red
                msg.Text = "å©êœì˙ÅÑäÆóπì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date006.Number <> 0 Then
            If Date006.Text > Date010.Text Then     'âÒìöéÛêMì˙>äÆóπì˙
                Date010.BackColor = System.Drawing.Color.Red
                msg.Text = "âÒìöéÛêMì˙ÅÑäÆóπì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date007.Number <> 0 Then
            If Date007.Text > Date010.Text Then     'ïîïiî≠íçì˙>äÆóπì˙
                Date010.BackColor = System.Drawing.Color.Red
                msg.Text = "ïîïiî≠íçì˙ÅÑäÆóπì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        If Date008.Number <> 0 Then
            If Date008.Text > Date010.Text Then     'ïîïiéÛóÃì˙>äÆóπì˙
                Date010.BackColor = System.Drawing.Color.Red
                msg.Text = "ïîïiéÛóÃì˙ÅÑäÆóπì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If

        Select Case Date010.Text
            Case Is < Mid(Now.Date, 1, 8) & "01" 'ìñåéà»ëO
                Date010.BackColor = System.Drawing.Color.Red
                msg.Text = "äÆóπì˙ÇÕìñåéÇÃì¸óÕÇµÇ©Ç≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            Case Is > Now.Date & " 23:59:59"  'ñ¢óàì˙ït
                Date010.BackColor = System.Drawing.Color.Red
                msg.Text = "äÆóπì˙Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
        End Select

        tax(String.Format("{0:yyyy/MM/dd}", CDate(Date010.Text)))
        Date010.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date011()   'îÑè„ì˙
        msg.Text = Nothing

        If Date011.Number = 0 Then Date011.Text = Date010.Text ' Date011.Text = Date010.Text

        If Date011.Number = 0 Then
        Else

            If Date003.Text > Date011.Text Then         'éÛïtì˙>îÑè„ì˙
                Date011.BackColor = System.Drawing.Color.Red
                msg.Text = "éÛïtì˙ÅÑîÑè„ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If

            If Date004.Number <> 0 Then
                If Date004.Text > Date011.Text Then     'å©êœì˙>îÑè„ì˙
                    Date011.BackColor = System.Drawing.Color.Red
                    msg.Text = "å©êœì˙ÅÑîÑè„ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date006.Number <> 0 Then
                If Date006.Text > Date011.Text Then     'âÒìöéÛêMì˙>îÑè„ì˙
                    Date011.BackColor = System.Drawing.Color.Red
                    msg.Text = "âÒìöéÛêMì˙ÅÑîÑè„ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date007.Number <> 0 Then
                If Date007.Text > Date011.Text Then     'ïîïiî≠íçì˙>îÑè„ì˙
                    Date011.BackColor = System.Drawing.Color.Red
                    msg.Text = "ïîïiî≠íçì˙ÅÑîÑè„ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date008.Number <> 0 Then
                If Date008.Text > Date011.Text Then     'ïîïiéÛóÃì˙>îÑè„ì˙
                    Date011.BackColor = System.Drawing.Color.Red
                    msg.Text = "ïîïiéÛóÃì˙ÅÑîÑè„ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date010.Number <> 0 Then
                If Date010.Text > Date011.Text Then         'äÆóπì˙ÅÑîÑè„ì˙
                    Date011.BackColor = System.Drawing.Color.Red
                    msg.Text = "äÆóπì˙ÅÑîÑè„ì˙ì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            Select Case Date011.Text
                Case Is < DateAdd(DateInterval.Year, -1, Now).Date '1îNà»è„âﬂãéì˙ït
                    Date011.BackColor = System.Drawing.Color.Red
                    msg.Text = "îÑè„ì˙Ç…1îNà»è„à»ëOÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                Case Is > Now  'ñ¢óàì˙ït
                    Date011.BackColor = System.Drawing.Color.Red
                    msg.Text = "îÑè„ì˙Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
            End Select
        End If

        Date011.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date012()   'èoâ◊ì˙
        msg.Text = Nothing
        If Date012.Number = 0 Then Date012.Text = Date010.Text ' Date012.Text = Date010.Text

        If Date012.Number = 0 Then
        Else

            If Date003.Text > Date012.Text Then          'éÛïtì˙>èoâ◊ì˙
                Date012.BackColor = System.Drawing.Color.Red
                msg.Text = "éÛïtì˙ÅÑèoâ◊ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If

            If Date004.Number <> 0 Then
                If Date004.Text > Date012.Text Then     'å©êœì˙>èoâ◊ì˙
                    Date012.BackColor = System.Drawing.Color.Red
                    msg.Text = "å©êœì˙ÅÑèoâ◊ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date006.Number <> 0 Then
                If Date006.Text > Date012.Text Then     'âÒìöéÛêMì˙>èoâ◊ì˙
                    Date012.BackColor = System.Drawing.Color.Red
                    msg.Text = "âÒìöéÛêMì˙ÅÑèoâ◊ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date007.Number <> 0 Then
                If Date007.Text > Date012.Text Then     'ïîïiî≠íçì˙>èoâ◊ì˙
                    Date012.BackColor = System.Drawing.Color.Red
                    msg.Text = "ïîïiî≠íçì˙ÅÑèoâ◊ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date008.Number <> 0 Then
                If Date008.Text > Date012.Text Then     'ïîïiéÛóÃì˙>èoâ◊ì˙
                    Date012.BackColor = System.Drawing.Color.Red
                    msg.Text = "ïîïiéÛóÃì˙ÅÑèoâ◊ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            If Date010.Number <> 0 Then
                If Date010.Text > Date012.Text Then          'äÆóπì˙ÅÑèoâ◊ì˙
                    Date012.BackColor = System.Drawing.Color.Red
                    msg.Text = "äÆóπì˙ÅÑèoâ◊ì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If

            Select Case Date012.Text
                Case Is < DateAdd(DateInterval.Year, -1, Now).Date '1îNà»è„âﬂãéì˙ït
                    Date012.BackColor = System.Drawing.Color.Red
                    msg.Text = "èoâ◊ì˙Ç…1îNà»è„à»ëOÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
                Case Is > Now  'ñ¢óàì˙ït
                    Date012.BackColor = System.Drawing.Color.Red
                    msg.Text = "èoâ◊ì˙Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
            End Select
        End If

        Date012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_CkBox01()   'âﬂé∏
        msg.Text = Nothing

        If GRP.Text = "63" Then
            If CkBox01_Y.Checked = False And CkBox01_N.Checked = False Then
                CkBox01_Y.BackColor = System.Drawing.Color.Red
                msg.Text = "âﬂé∏ÇÃóLñ≥Ç™ëIëÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        CkBox01_Y.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Sub CHK_Combo_K001()   'èCóùíSìñ
        msg.Text = Nothing
        CLK001.Text = Nothing
        CLK001_BRH.Text = Nothing

        'If ZH.Text <> "H" Then
        'If Combo_K001.Visible = True Then
        Combo_K001.Text = Trim(Combo_K001.Text)
        If Combo_K001.Text = Nothing Then
            Combo_K001.BackColor = System.Drawing.Color.Red
            msg.Text = "èCóùíSìñÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M01_EMPL"), "name = '" & Combo_K001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo_K001.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈèCóùíSìñÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLK001.Text = WK_DtView1(0)("empl_code")
                If Not IsDBNull(WK_DtView1(0)("brch_code")) Then CLK001_BRH.Text = WK_DtView1(0)("brch_code")
            End If
        End If
        'End If
        'End If
        Combo_K001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_K002(ByVal N_set) 'ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóø
        msg.Text = Nothing

        If Combo_K002.Visible = True Then
            Combo_K002.Text = Trim(Combo_K002.Text)
            If Combo_K002.Text = Nothing Then
                Combo_K002.BackColor = System.Drawing.Color.Red
                msg.Text = "ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóøÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            Else
                WK_DtView1 = New DataView(DsCMB2.Tables("M14_VNDR_SUB"), "select_case = '" & Combo_K002.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Combo_K002.BackColor = System.Drawing.Color.Red
                    msg.Text = "äYìñÇ∑ÇÈÉÅÅ[ÉJÅ[ï€èÿ ãZèpóøÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                    Exit Sub
                Else
                    CLK002.Text = WK_DtView1(0)("seq")
                    If N_set = "1" Then Number131.Value = WK_DtView1(0)("tech_amnt")
                End If
            End If
        End If
        Combo_K002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Number112() 'APSE
        msg.Text = Nothing

        If Number112.Value = 0 Then
        Else
            If CInt(apse.Text) = 0 Then
                Number112.BackColor = System.Drawing.Color.Red
                msg.Text = "APSEÇ™ì¸óÕèoóàÇÈÇÃÇÕÅAAppleÇ≈“∞∂∞ï€èÿÅAé©é–èCóùÇÃéûÇÃÇ›Ç≈Ç∑ÅB"
                Exit Sub
            End If
        End If
        Number112.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_K003() 'åvè„QG
        msg.Text = Nothing

        Combo_K003.Text = Trim(Combo_K003.Text)
        If Combo_K003.Text = Nothing Then
            Combo_K003.BackColor = System.Drawing.Color.Red
            msg.Text = "åvè„QGÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB3.Tables("M03_BRCH"), "brch_name = '" & Combo_K003.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo_K003.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈQGÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLK003.Text = WK_DtView1(0)("brch_code")
            End If
        End If
        Combo_K003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_K004() 'ì¸ã‡éÌï 
        msg.Text = Nothing

        Combo_K004.Text = Trim(Combo_K004.Text)
        If Combo_K004.Text = Nothing Then
            Combo_K004.BackColor = System.Drawing.Color.Red
            msg.Text = "ì¸ã‡éÌï Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB4.Tables("cls_029"), "cls_code_name = '" & Combo_K004.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo_K004.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈQGÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLK004.Text = WK_DtView1(0)("cls_code")
            End If
        End If
        Combo_K004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_cmnt4(ByVal seq As Integer) 'èCóùì‡óe
        msg.Text = Nothing

        cmbBo_4(seq, 1).Text = Trim(cmbBo_4(seq, 1).Text)
        If cmbBo_4(seq, 1).Text = Nothing Then
        Else
            WK_DtView1 = New DataView(WK_DsCMB4.Tables("M10_CMNT_4" & seq), "cmnt ='" & cmbBo_4(seq, 1).Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                cmbBo_4(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈèCóùì‡óeÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                label_4(seq, 1).Text = WK_DtView1(0)("cmnt_code")
            End If
        End If
        cmbBo_4(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_K001()   'èCóùì‡óe
        msg.Text = Nothing

        Edit_K001.Text = Trim(Edit_K001.Text)
        If Edit_K001.Text = Nothing Then
            'Edit_K001.BackColor = System.Drawing.Color.Red
            'msg.Text = "èCóùì‡óeÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_K001.Text)
            If P_Line > 20 Then
                Edit_K001.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇQÇOçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_K001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_K002()   'èCóùÉRÉÅÉìÉg
        msg.Text = Nothing

        Edit_K002.Text = Trim(Edit_K002.Text)
        If Edit_K002.Text = Nothing Then
            'Edit_K002.BackColor = System.Drawing.Color.Red
            'msg.Text = "èCóùÉRÉÅÉìÉgÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_K002.Text)
            If P_Line > 20 Then
                Edit_K002.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇQÇOçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_K002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_K003()   'SB/IMEI
        msg.Text = Nothing

        Edit_K003.Text = Trim(Edit_K003.Text)
        If Edit001.Text = "9196" Then
            If Edit_K003.Text = Nothing Then
                Edit_K003.BackColor = System.Drawing.Color.Red
                msg.Text = "êVIMEIî‘çÜÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ"
                Exit Sub
            End If
        End If
        Edit_K003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_K003_2()   'SB/IMEI
        msg.Text = Nothing

        Edit_K003.Text = Trim(Edit_K003.Text)
        If GRP.Text = "63" Then   'É\ÉtÉgÉoÉìÉN
            If LenB(Edit_K003.Text) <> 15 Then
                Edit_K003.BackColor = System.Drawing.Color.Red
                msg.Text = "êVIMEIî‘çÜÇÕ15åÖÇ≈Ç∑"
                Exit Sub
            End If
        End If
        Edit_K003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_K004()   'êVs/n
        msg.Text = Nothing

        If Edit_K004.Enabled = True Then
            Edit_K004.Text = Trim(Edit_K004.Text)

            P_Ds_sn.Clear()
            strSQL = "SELECT T06_sno.* FROM T06_sno WHERE (code = '" & Edit011.Text & "') AND (s_no = '" & Edit_K004.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("QGCare")
            r = DaList1.Fill(P_Ds_sn, "T06_sno")
            DB_CLOSE()
            If r <> 0 Then
                Edit_K004.BackColor = System.Drawing.Color.Red
                msg.Text = "ä˘Ç…ìoò^çœÇ›Ç≈Ç∑ÅBS/Nî‘çÜÇçƒìxämîFÇ≠ÇæÇ≥Ç¢"
                Exit Sub
            End If
        End If
        Edit_K004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0" : MSG_F = "0"

        CHK_Edit012()   'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        If msg.Text <> Nothing Then Err_F = "1" : Edit012.Focus() : Exit Sub

        CHK_Date006()       'âÒìöéÛêMì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date006.Focus() : Exit Sub

        CHK_Date007()       'ïîïiî≠íçì˙
        If CK_own_flg.Checked = True Then
            If msg.Text <> Nothing Then MSG_F = "1"
        Else
            If msg.Text <> Nothing Then Err_F = "1" : Date007.Focus() : Exit Sub
        End If

        CHK_Date008()       'ïîïiéÛóÃì˙
        If CK_own_flg.Checked = True Then
            If msg.Text <> Nothing Then MSG_F = "1"
        Else
            If msg.Text <> Nothing Then Err_F = "1" : Date008.Focus() : Exit Sub
        End If

        CHK_Date016()       'èCóùì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date016.Focus() : Exit Sub

        CHK_Date017()       'äÆóπòAóçì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date017.Focus() : Exit Sub

        CHK_Date010()       'äÆóπì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date010.Focus() : Exit Sub

        CHK_Date011()       'îÑè„ì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date011.Focus() : Exit Sub

        CHK_Date012()       'èoâ◊ì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date012.Focus() : Exit Sub

        CHK_CkBox01()   'âﬂé∏
        If msg.Text <> Nothing Then Err_F = "1" : CkBox01_Y.Focus() : Exit Sub

        'CHK_Combo_K001()    'èCóùíSìñ
        'If msg.Text <> Nothing Then Err_F = "1" : Combo_K001.Focus() : Exit Sub

        CHK_Combo_K002("0") 'ÉÅÅ[ÉJÅ[ï€èÿãZèpóø
        If msg.Text <> Nothing Then Err_F = "1" : Combo_K002.Focus() : Exit Sub

        CHK_Edit_K003()     'êVIMEIî‘çÜ
        If msg.Text <> Nothing Then Err_F = "1" : Edit_K003.Focus() : Exit Sub

        CHK_Edit_K004()     'êVs/n
        If msg.Text <> Nothing Then Err_F = "1" : Edit_K004.Focus() : Exit Sub

        CHK_Number112() 'APSE
        If msg.Text <> Nothing Then Err_F = "1" : Number112.Focus() : Exit Sub

        CHK_Combo_K003()    'åvè„QG
        If msg.Text <> Nothing Then Err_F = "1" : Combo_K003.Focus() : Exit Sub

        'CHK_Combo_K004()    'ì¸ã‡éÌï 
        'If msg.Text <> Nothing Then Err_F = "1" : Combo_K004.Focus() : Exit Sub

        'å©êœì‡óe
        seq = 0
        For i = 0 To Line_No4

            CHK_cmnt4(i)    'èCóùì‡óe
            If msg.Text <> Nothing Then Err_F = "1" : cmbBo_4(i, 1).Focus() : Exit Sub

            If cmbBo_4(i, 1).Text <> Nothing Then
                seq = seq + 1
            End If
        Next

        CHK_Edit_K001()   'èCóùì‡óe
        If msg.Text <> Nothing Then Err_F = "1" : Edit_K001.Focus() : Exit Sub
        seq = seq + P_Line

        CHK_Edit_K002()   'èCóùÉRÉÅÉìÉg
        If msg.Text <> Nothing Then Err_F = "1" : Edit_K002.Focus() : Exit Sub
        seq = seq + P_Line

        If seq > 15 Then
            Edit_K001.BackColor = System.Drawing.Color.Red
            msg.Text = "èCóùì‡óeÇÃëIëçÄñ⁄Ç∆ÉtÉäÅ[ì¸óÕÇ≈çáåvÇPÇTçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
            Err_F = "1" : Edit_K001.Focus() : Exit Sub
        End If

    End Sub

    'ÉCÉåÉMÉÖÉâÅ[èàóùÅisofmapÇ≈HPóLèûéÊéüÅj
    Sub Irregular()
        If GRP.Text = "19" _
           And CL004.Text = "01" _
           And CLU002.Text = "97" Then
            Irregular_F = "1"
        Else
            Irregular_F = "0"
        End If
    End Sub

    '********************************************************************
    '**  îÒï\é¶ÇÃçÄñ⁄ÇÕÉNÉäÉAÇ∑ÇÈ
    '********************************************************************
    Sub NoDsp_Null()
        If Combo_K001.Visible = False Then Combo_K001.Text = Nothing
        If Combo_K001.Visible = False Then CLK001.Text = Nothing
        If Combo_K002.Visible = False Then Combo_K002.Text = Nothing
        If Combo_K002.Visible = False Then CLK002.Text = Nothing
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit000_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.GotFocus
        If Edit000.ReadOnly = False Then
            Edit000.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        End If
    End Sub
    Private Sub Edit012_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.GotFocus
        Edit012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.GotFocus
        Number002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_K001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K001.GotFocus
        Combo_K001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_K002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K002.GotFocus
        Combo_K002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_K003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K003.GotFocus
        Combo_K003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_K004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K004.GotFocus
        Combo_K004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub cmb4_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Interop.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Interop.Combo)
        cmbBo_4(cmb.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_K001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K001.GotFocus
        Edit_K001.ImeMode = ImeMode.Hiragana
        Edit_K001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_K002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K002.GotFocus
        Edit_K002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_K003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K003.GotFocus
        Edit_K003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_K004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K004.GotFocus
        Edit_K004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number111_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number111.GotFocus
        Number111.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number112_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number112.GotFocus
        Number112.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number113_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number113.GotFocus
        Number113.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number114_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number114.GotFocus
        Number114.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number115_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number115.GotFocus
        Number115.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number121_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number121.GotFocus
        Number121.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number123_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number123.GotFocus
        Number123.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number124_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number124.GotFocus
        Number124.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number125_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number125.GotFocus
        Number125.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number131_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number131.GotFocus
        Number131.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number132_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number132.GotFocus
        Number132.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number133_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number133.GotFocus
        Number133.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number134_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number134.GotFocus
        Number134.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number135_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number135.GotFocus
        Number135.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date006.GotFocus
        Date006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.GotFocus
        Date007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date008_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.GotFocus
        Date008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date010_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date010.GotFocus
        Date010.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date011_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date011.GotFocus
        Date011.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date012_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date012.GotFocus
        Date012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date016_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date016.GotFocus
        Date016.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date017_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date017.GotFocus
        Date017.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox_k001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_K001.GotFocus
        CheckBox_K001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox_k002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_K002.GotFocus
        CheckBox_K002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CkBox01_Y_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_Y.GotFocus
        CkBox01_Y.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CkBox01_N_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_N.GotFocus
        CkBox01_N.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit000_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.LostFocus
        If Edit000.ReadOnly = False Then
            Edit000.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Private Sub Edit012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.LostFocus
        CHK_Edit012()   'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
    End Sub
    Private Sub Number002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.LostFocus
        Number002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo_K001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K001.LostFocus
        CHK_Combo_K001()        'èCóùíSìñ
    End Sub
    Private Sub Combo_K002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K002.LostFocus
        CHK_Combo_K002("1")     'ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóø
    End Sub
    Private Sub Combo_K003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K003.LostFocus
        CHK_Combo_K003()        'åvè„QG
    End Sub
    Private Sub Combo_K004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K004.LostFocus
        CHK_Combo_K004()        'ì¸ã‡éÌï 
    End Sub
    Private Sub cmb4_1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Interop.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Interop.Combo)
        CHK_cmnt4(cmb.Tag)  'èCóùì‡óe
        If Line_No4 = cmb.Tag Then
            'comment prabu2021-04-08
            If Line_No4 < 8 Then
                If cmbBo_4(cmb.Tag, 1).Text <> Nothing Then
                    add_line_4("0")    'èCóùì‡óe
                    cmbBo_4(cmb.Tag + 1, 1).Focus()
                End If
            End If
        End If
    End Sub
    Private Sub Edit_K001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K001.LostFocus
        CHK_Edit_K001()     'äÆóπì‡óe
    End Sub
    Private Sub Edit_K002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K002.LostFocus
        CHK_Edit_K002()     'äÆóπÉRÉÅÉìÉg
    End Sub
    Private Sub Edit_K003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K003.LostFocus
        CHK_Edit_K003()     'SB/êVIMEI
        If msg.Text = Nothing Then CHK_Edit_K003_2() 'SB/êVIMEI
    End Sub
    Private Sub Edit_K004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K004.LostFocus
        CHK_Edit_K004()     'êVs/n
    End Sub
    Private Sub Number111_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number111.LostFocus
        Number111.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number112_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number112.LostFocus
        CHK_Number112()
    End Sub
    Private Sub Number113_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number113.LostFocus
        Number113.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number114_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number114.LostFocus
        Number114.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number115_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number115.LostFocus
        Number115.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number121_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number121.LostFocus
        Number121.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number123_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number123.LostFocus
        Number123.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number124_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number124.LostFocus
        Number124.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number125_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number125.LostFocus
        Number125.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number131_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number131.LostFocus
        Number131.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number132_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number132.LostFocus
        Number132.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number133_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number133.LostFocus
        Number133.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number134_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number134.LostFocus
        Number134.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number135_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number135.LostFocus
        Number135.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date006.LostFocus
        CHK_Date006()   'âÒìöéÛêMì˙
    End Sub
    Private Sub Date007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.LostFocus
        CHK_Date007()   'ïîïiî≠íçì˙
    End Sub
    Private Sub Date008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.LostFocus
        CHK_Date008()   'ïîïiéÛóÃì˙
    End Sub
    Private Sub Date010_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date010.LostFocus
        CHK_Date010()   'äÆóπì˙

        'APSE
        If CLU001.Text = "01" _
            And CL004.Text = "02" _
            And Date010.Number <> 0 Then
            apse.Text = APSE_GET(CLU002.Text, Date010.Text)
        Else
            apse.Text = "0"
        End If

        Number112.Value = 0
        If CK_own_flg.Checked = True Then   'é©é–èCóù
            If CInt(apse.Text) <> 0 Then
                Number112.Value = Number111.Value * (CInt(apse.Text) - 100) / 100
            End If
        End If
    End Sub
    Private Sub Date011_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date011.LostFocus
        CHK_Date011()   'îÑè„ì˙
    End Sub
    Private Sub Date012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date012.LostFocus
        CHK_Date012()   'èoâ◊ì˙
    End Sub
    Private Sub Date016_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date016.LostFocus
        CHK_Date016()   'èCóùì˙
    End Sub
    Private Sub Date017_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date017.LostFocus
        CHK_Date017()   'äÆóπòAóçì˙
    End Sub
    Private Sub CheckBox_k001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_K001.LostFocus
        CheckBox_K001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox_k002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_K002.LostFocus
        CheckBox_K002.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CkBox01_Y_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_Y.LostFocus
        CkBox01_Y.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CkBox01_N_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_N.LostFocus
        CkBox01_N.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Number111_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number111.TextChanged
        sum1_apse()
        sum1_base()
        sum1()
    End Sub
    Private Sub Number112_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number112.TextChanged
        sum1_base()
        Number132.Value = Number112.Value
        sum1()
    End Sub
    Private Sub Number113_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number113.TextChanged
        sum1_base()
        sum1()
    End Sub
    Private Sub Number114_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number114.TextChanged
        sum1_base()
        sum1()
    End Sub
    Private Sub Number115_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number115.TextChanged
        sum1_base()
        sum1()
    End Sub
    Private Sub Number116_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number116.TextChanged
        sum2_base()
    End Sub
    Private Sub Number118_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number118.TextChanged
        'ÉäÉxÅ[ÉgSET
        'é©å»ïâíSSET
        Dim WK_str1, WK_str2 As String
        If CK_own_flg.Checked = True Then WK_str1 = "True" Else WK_str1 = "False"
        If CLU001.Text = "01" Then
            If CheckBox_U003.Checked = True Then WK_str2 = "01" Else WK_str2 = "02"
        Else
            If CheckBox_U001.Checked = True Then WK_str2 = "01" Else WK_str2 = "02"
        End If
        If CL001.Text = "10" And GRP.Text = "88" Then   'ê∂ã¶Fujitsuï€åØÅAîÃé–∏ﬁŸ∞Ãﬂ=ê∂ã¶Fujitsuï€åØ
            rebate_idvd_Get2(Edit001.Text, CL004.Text, CL001.Text, Number001.Value, Number003.Value, Number118.Value, Number116.Value, WK_str1, CLU001.Text, WK_str2)
        Else
            rebate_idvd_Get(Edit001.Text, CL004.Text, CL001.Text, Number001_nTax.Value, Number003.Value, Number118.Value, Number116.Value, WK_str1, CLU001.Text, WK_str2)
        End If
        rebate.Value = P_rebate
        idvd_chrg.Value = P_idvd
    End Sub
    Private Sub Number121_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number121.TextChanged
        sum2_base()
    End Sub
    Private Sub Number123_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number123.TextChanged
        sum2_base()
    End Sub
    Private Sub Number124_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number124.TextChanged
        sum2_base()
    End Sub
    Private Sub Number125_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number125.TextChanged
        sum2_base()
    End Sub
    Private Sub Number131_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number131.TextChanged
        sum3_base()
        sum3()
    End Sub
    Private Sub Number132_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number132.TextChanged
        sum3_base()
    End Sub
    Private Sub Number133_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number133.TextChanged
        sum3_base()
        'sum3()
    End Sub
    Private Sub Number134_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number134.TextChanged
        sum3_base()
        sum3()
    End Sub
    Private Sub Number135_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number135.TextChanged
        sum3_base()
        sum3()
    End Sub
    Sub sum1_base()
        Number116.Value = Number111.Value + Number112.Value + Number113.Value + Number114.Value + Number115.Value
        Select Case calc_cls.Text
            Case Is = "0"   'éléÃå‹ì¸
                Number117.Value = Round(Number116.Value * tax_rate.Text / 100, 0)
            Case Is = "1"   'êÿéÃÇƒ
                Number117.Value = RoundDOWN(Number116.Value * tax_rate.Text / 100, 0)
            Case Is = "2"   'êÿè„Ç∞
                Number117.Value = RoundUP(Number116.Value * tax_rate.Text / 100, 0)
        End Select
        Number118.Value = Number116.Value + Number117.Value
    End Sub
    Sub sum2_base()
        If GRP.Text = "92" Then 'ãûìséñã∆òAçá
            Number126.Value = RoundUP(RoundUP(Number116.Value / 0.95, -1) / 0.9, -1)
        Else
            Number126.Value = Number121.Value + Number123.Value + Number124.Value + Number125.Value
        End If
        Select Case calc_cls.Text
            Case Is = "0"   'éléÃå‹ì¸
                Number127.Value = Round(Number126.Value * tax_rate.Text / 100, 0)
            Case Is = "1"   'êÿéÃÇƒ
                Number127.Value = RoundDOWN(Number126.Value * tax_rate.Text / 100, 0)
            Case Is = "2"   'êÿè„Ç∞
                Number127.Value = RoundUP(Number126.Value * tax_rate.Text / 100, 0)
        End Select
        Number128.Value = Number126.Value + Number127.Value
    End Sub
    Sub sum3_base()
        Number136.Value = Number131.Value + Number132.Value + Number133.Value + Number134.Value + Number135.Value
        Select Case calc_cls.Text
            Case Is = "0"   'éléÃå‹ì¸
                Number137.Value = Round(Number136.Value * tax_rate.Text / 100, 0)
            Case Is = "1"   'êÿéÃÇƒ
                Number137.Value = RoundDOWN(Number136.Value * tax_rate.Text / 100, 0)
            Case Is = "2"   'êÿè„Ç∞
                Number137.Value = RoundUP(Number136.Value * tax_rate.Text / 100, 0)
        End Select
        Number138.Value = Number136.Value + Number137.Value
    End Sub
    Sub sum1_apse()  'ãZèpóøÇ™ïœçXÇ…Ç»Ç¡ÇΩéûÇÃåvéZ
        Number112.Value = 0
        If CK_own_flg.Checked = True Then   'é©é–èCóù
            If CInt(apse.Text) <> 0 Then
                Number112.Value = Number111.Value * (CInt(apse.Text) - 100) / 100
            End If
        End If
    End Sub
    Sub sum1()  'åvè„äzÇ™ïœçXÇ…Ç»Ç¡ÇΩéûÇÃåvéZ
        If inz_F = "1" And prtct_F = "0" Then
            If NumberN006.Value <> 0 Then    'íËäz
                If CheckBox_K001.Checked = False Then
                    Number116.Value = NumberN006.Value + Number114.Value + Number115.Value
                    Number113.Value = Number116.Value - Number111.Value - Number112.Value - Number114.Value - Number115.Value

                    Number121.Value = Number111.Value
                    Number123.Value = Number113.Value
                    Number124.Value = Number114.Value
                    Number125.Value = Number115.Value
                End If
            Else
                Number121.Value = Number111.Value * NumberN007.Value
                Number122.Value = 0
                'ïîïiñàÇ…åvéZÇ∑ÇÈÇÃÇ≈Ç±Ç±Ç≈ÇÕåvéZÇµÇ»Ç¢
                'Number123.Value = Number113.Value * NumberN008.Value
                Number124.Value = Number114.Value
                Number125.Value = Number115.Value
            End If

            'ÉCÉåÉMÉÖÉâÅ[èàóù
            Select Case GRP.Text
                Case Is = "92" 'ãûìséñã∆òAçá
                    'ïîïiñàÇ…åvéZÇ∑ÇÈÇÃÇ≈Ç±Ç±Ç≈ÇÕåvéZÇµÇ»Ç¢
                    If NumberN006.Value = 0 Then    'íËäzà»äO
                        Number121.Value = RoundUP(RoundUP(Number111.Value / 0.95, -1) / 0.9, -1)
                        Number123.Value = RoundUP(RoundUP(Number113.Value / 0.95, -1) / 0.9, -1)
                    End If

                Case Is = "19" 'É\ÉtÉ}ÉbÉv
                    If NumberN006.Value = 0 Then    'íËäzà»äO
                        Number121.Value = RoundUP(Number111.Value * NumberN007.Value, -1)
                    End If
                    If CK_own_flg.Checked = False Then 'É\ÉtÉ}ÉbÉvÇ≈ëºé–èCóù
                        Number123.Value = Number113.Value - 2000
                    End If
            End Select

            If ZH.Text = "H" Or ZH.Text = Nothing Then
                Number121.Value = Number111.Value ' * NumberN007.Value
                Number123.Value = Number113.Value ' * NumberN008.Value
                Number124.Value = Number114.Value
                Number125.Value = Number115.Value
            End If
        End If
    End Sub
    Sub sum2()
    End Sub
    Sub sum3()
        If ZH.Text = "H" Or ZH.Text = Nothing Then
            Number111.Value = Number131.Value
            Number114.Value = Number134.Value
            Number115.Value = Number135.Value
        End If
    End Sub

    '********************************************************************
    '**  å©êœï°é 
    '********************************************************************
    Private Sub Button_K002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_K002.Click

        'èCóùì‡óe
        Panel_K1.Controls.Clear()
        Line_No4 = -1

        'äÓèÄì_
        label_4(0, 0) = New Label
        label_4(0, 0).Location = New System.Drawing.Point(0, 0)
        label_4(0, 0).Size = New System.Drawing.Size(0, 0)
        label_4(0, 0).Text = Nothing
        Panel_K1.Controls.Add(label_4(0, 0))

        WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_2"), "", "seq", DataViewRowState.CurrentRows)
        WK_DtView2 = New DataView(DsList1.Tables("T03_REP_CMNT_3"), "", "seq", DataViewRowState.CurrentRows)
        'prabu added 2021-04-16
        WK_DsCMB4.Tables.Clear()
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                DB_OPEN("nMVAR")
                Line_No4 = Line_No4 + 1

                'èCóùì‡óe
                strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
                strSQL += " FROM M10_CMNT"
                strSQL += " WHERE (cls_code = '21') AND (delt_flg = 0)"
                strSQL += " ORDER BY cmnt_code + ':' + cmnt"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsCMB4, "M10_CMNT_4" & Line_No4)

                en = 1
                cmbBo_4(Line_No4, en) = New GrapeCity.Win.Input.Interop.Combo
                cmbBo_4(Line_No4, en).Location = New System.Drawing.Point(1, 20 * Line_No4 + label_4(0, 0).Location.Y)
                cmbBo_4(Line_No4, en).MaxDropDownItems = 30
                'cmbBo_4(Line_No4, en).HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
                cmbBo_4(Line_No4, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                cmbBo_4(Line_No4, en).Size = New System.Drawing.Size(465, 20)
                cmbBo_4(Line_No4, en).DataSource = WK_DsCMB4.Tables("M10_CMNT_4" & Line_No4)
                cmbBo_4(Line_No4, en).DisplayMember = "cmnt"
                cmbBo_4(Line_No4, en).ValueMember = "cmnt_code"
                cmbBo_4(Line_No4, en).Tag = Line_No4
                Panel_K1.Controls.Add(cmbBo_4(Line_No4, en))
                AddHandler cmbBo_4(Line_No4, en).GotFocus, AddressOf cmb4_1_GotFocus
                AddHandler cmbBo_4(Line_No4, en).LostFocus, AddressOf cmb4_1_LostFocus

                WK_DtView3 = New DataView(WK_DsCMB4.Tables("M10_CMNT_4" & Line_No4), "cmnt_code = '" & WK_DtView1(i)("cmnt_code1") & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView3.Count <> 0 Then
                    cmbBo_4(Line_No4, en).Text = WK_DtView3(0)("cmnt")
                Else
                    cmbBo_4(Line_No4, en).Text = Nothing
                End If

                'èCóùì‡óe∫∞ƒﬁ
                en = 1
                label_4(Line_No4, en) = New Label
                If Not IsDBNull(WK_DtView1(i)("cmnt_code1")) Then
                    label_4(Line_No4, en).Text = WK_DtView1(i)("cmnt_code1")
                Else
                    label_4(Line_No4, en).Text = Nothing
                End If
                label_4(Line_No4, en).Location = New System.Drawing.Point(500, 20 * Line_No4 + label_4(0, 0).Location.Y)
                label_4(Line_No4, en).Size = New System.Drawing.Size(50, 20)
                label_4(Line_No4, en).Visible = False
                Panel_K1.Controls.Add(label_4(Line_No4, en))

                'SEQ
                en = 2
                label_4(Line_No4, en) = New Label
                label_4(Line_No4, en).Text = Nothing
                label_4(Line_No4, en).Location = New System.Drawing.Point(600, 20 * Line_No4 + label_4(0, 0).Location.Y)
                label_4(Line_No4, en).Size = New System.Drawing.Size(50, 20)
                label_4(Line_No4, en).Visible = False
                Panel_K1.Controls.Add(label_4(Line_No4, en))

                DB_CLOSE()
            Next
        Else
            add_line_4("0")
        End If

        'prabu added 2021-04-09
        'WK_DsCMB4.Tables.Clear()
        'add_line_4("0")    'äÆóπì‡óe

        'ïîïi
        P_DsList1.Tables("T04_REP_PART_2").Clear()
        WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                dttable = P_DsList1.Tables("T04_REP_PART_2")
                dtRow = dttable.NewRow
                dtRow("rcpt_no") = WK_DtView1(i)("rcpt_no")
                dtRow("kbn") = WK_DtView1(i)("kbn")
                dtRow("seq") = WK_DtView1(i)("seq")
                dtRow("part_code") = WK_DtView1(i)("part_code")
                dtRow("part_name") = WK_DtView1(i)("part_name")
                dtRow("part_amnt") = WK_DtView1(i)("part_amnt")
                dtRow("use_qty") = WK_DtView1(i)("use_qty")
                dtRow("cost_chrg") = WK_DtView1(i)("cost_chrg")
                'dtRow("cost_chrg") = WK_DtView1(i)("part_amnt") * WK_DtView1(i)("use_qty")
                dtRow("shop_chrg") = WK_DtView1(i)("shop_chrg")
                dtRow("eu_chrg") = WK_DtView1(i)("eu_chrg")
                dtRow("ordr_no") = WK_DtView1(i)("ordr_no")
                dtRow("ordr_no2") = WK_DtView1(i)("ordr_no2")
                dtRow("s_n") = WK_DtView1(i)("s_n")
                dtRow("zaiko_flg") = "False"
                dtRow("ibm_flg") = WK_DtView1(i)("ibm_flg")
                dtRow("exp_flg") = WK_DtView1(i)("exp_flg")
                dtRow("ID_NO") = WK_DtView1(i)("ID_NO")
                dttable.Rows.Add(dtRow)
            Next
        End If

        'é©ìÆåvéZâèú
        If CheckBox_M001.Checked = True Then
            CheckBox_K001.Checked = True
        Else
            CheckBox_K001.Checked = False
        End If

        'ã‡äz
        Number131.Value = Number031.Value
        If CK_own_flg.Checked = True _
            And CLU001.Text = "01" _
            And CL004.Text = "02" _
            And Date010.Number <> 0 Then 'é©é–èCóùÅAÉAÉbÉvÉãÅAÉÅÅ[ÉJÅ[ï€èÿÅAäÆóπì˙
            apse.Text = APSE_GET(CLU002.Text, Date010.Text)
        Else
            apse.Text = "0"
        End If
        If CInt(apse.Text) <> 0 Then
            Number112.Value = Number111.Value * (CInt(apse.Text) - 100) / 100
        End If
        'Number132.Value = Number032.Value
        Number133.Value = Number033.Value
        Number134.Value = Number034.Value
        Number135.Value = Number035.Value
        Number136.Value = Number036.Value
        Number111.Value = Number011.Value
        'Number112.Value = Number012.Value
        Number113.Value = Number013.Value
        Number114.Value = Number014.Value
        Number115.Value = Number015.Value
        Number116.Value = Number016.Value
        Number121.Value = Number021.Value
        Number123.Value = Number023.Value
        Number124.Value = Number024.Value
        Number125.Value = Number025.Value
        Number126.Value = Number026.Value

    End Sub

    '********************************************************************
    '**  ïœçXâ”èäÉ`ÉFÉbÉN
    '********************************************************************
    Sub CHG_CHK()
        CHG_F = "0"
        CHG.Text = Nothing
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)
        DtView3 = New DataView(DsList1.Tables("T01_REP_MTR_K"), "", "", DataViewRowState.CurrentRows)

        If Date015.Number = 0 Then WK_str = Nothing Else WK_str = Date015.Text
        If IsDBNull(DtView2(0)("sindan_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView2(0)("sindan_date")) 'DtView2(0)("sindan_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "êfífì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'êfífì˙
        End If

        If Date006.Number = 0 Then WK_str = Nothing Else WK_str = Date006.Text
        If IsDBNull(DtView2(0)("rsrv_cacl_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("rsrv_cacl_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "âÒìöéÛêMì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'âÒìöéÛêMì˙
        End If

        If Date007.Number = 0 Then WK_str = Nothing Else WK_str = Date007.Text
        If IsDBNull(DtView3(0)("part_ordr_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("part_ordr_date")
        If WK_str <> WK_str2 Then
            CHG.Text = Label015.Text & "ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ïîïiî≠íçì˙
        End If

        If Date008.Number = 0 Then WK_str = Nothing Else WK_str = Date008.Text
        If IsDBNull(DtView3(0)("part_rcpt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("part_rcpt_date")
        If WK_str <> WK_str2 Then
            CHG.Text = Label016.Text & "ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ïîïiéÛóÃì˙
        End If

        If Date016.Number = 0 Then WK_str = Nothing Else WK_str = Date016.Text
        If IsDBNull(DtView3(0)("rep_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("rep_date")) ' DtView3(0)("rep_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "èCóùì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'èCóùì˙
        End If

        If Date017.Number = 0 Then WK_str = Nothing Else WK_str = Date017.Text
        If IsDBNull(DtView3(0)("renraku_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("renraku_date")) ' DtView3(0)("renraku_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "äÆóπòAóçì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'äÆóπòAóçì˙
        End If

        If Date010.Number = 0 Then WK_str = Nothing Else WK_str = Date010.Text
        If IsDBNull(DtView3(0)("comp_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("comp_date")) ' DtView3(0)("comp_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "äÆóπì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'äÆóπì˙
        End If

        If Date011.Number = 0 Then WK_str = Nothing Else WK_str = Date011.Text
        If IsDBNull(DtView3(0)("sals_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("sals_date"))
        If WK_str <> WK_str2 Then
            CHG.Text = "îÑè„ì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'îÑè„ì˙
        End If

        If Date012.Number = 0 Then WK_str = Nothing Else WK_str = Date012.Text
        If IsDBNull(DtView3(0)("ship_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("ship_date"))
        If WK_str <> WK_str2 Then
            CHG.Text = "èoâ◊ì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'èoâ◊ì˙
        End If

        WK_str = Nothing
        If CkBox01_Y.Checked = True Then WK_str = "óL"
        If CkBox01_N.Checked = True Then WK_str = "ñ≥"
        If IsDBNull(DtView1(0)("kashitsu_flg")) Then
            WK_str2 = Nothing
        Else
            If DtView1(0)("kashitsu_flg") = "1" Then WK_str2 = "óL" Else WK_str2 = "ñ≥"
        End If
        If WK_str <> WK_str2 Then
            CHG.Text = "âﬂé∏ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'âﬂé∏
        End If

        WK_str = Trim(Edit012.Text)
        If IsDBNull(DtView1(0)("orgnl_vndr_code")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("orgnl_vndr_code")
        If WK_str <> WK_str2 Then
            'Ds_CHG("µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ", WK_str2, WK_str)
            CHG.Text = "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        End If

        If IsDBNull(DtView1(0)("recv_amnt")) Then WK_int2 = 0 Else WK_int2 = DtView1(0)("recv_amnt")
        If Number002.Value <> WK_int2 Then
            CHG.Text = "óaÇ©ÇËã‡ÅF" & WK_int2 & " Å® " & Number002.Value
            CHG_F = "1" : Exit Sub 'óaÇ©ÇËã‡
        End If

        WK_str = Combo_K001.Text
        If IsDBNull(DtView3(0)("repr_empl_name")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("repr_empl_name")
        If WK_str <> WK_str2 Then
            CHG.Text = "èCóùíSìñÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'èCóùíSìñ
        End If

        WK_str = Combo_K002.Text
        If IsDBNull(DtView3(0)("select_case")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("select_case")
        If WK_str <> WK_str2 Then
            CHG.Text = "ÉÅÅ[ÉJÅ[ï€èÿãZèpóøÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ÉÅÅ[ÉJÅ[ï€èÿãZèpóø
        End If

        If IsDBNull(DtView3(0)("sb_imei_new")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("sb_imei_new")
        If Edit_K003.Text <> WK_str2 Then
            CHG.Text = "SB/êVIMEIÅF" & WK_str2 & " Å® " & Edit_K003.Text
            CHG_F = "1" : Exit Sub 'SB/êVIMEI
        End If

        If Edit_K004.Text <> Nothing Then
            If Edit_K004.Text <> Edit_U003.Text Then
                CHG.Text = "S/NÅF" & Edit_U003.Text & " Å® " & Edit_K004.Text
                CHG_F = "1" : Exit Sub 'êVs/n
            End If
        End If

        WK_str = Combo_K003.Text
        If IsDBNull(DtView3(0)("kjo_brch_name")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("kjo_brch_name")
        If WK_str <> WK_str2 Then
            CHG.Text = "åvè„ÇpÇfÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'åvè„ÇpÇf
        End If

        WK_str = Combo_K004.Text
        If IsDBNull(DtView3(0)("payment_type_name")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("payment_type_name")
        If WK_str <> WK_str2 Then
            CHG.Text = "ì¸ã‡éÌï ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ì¸ã‡éÌï 
        End If

        If IsDBNull(DtView3(0)("comp_meas")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_meas")
        If Edit_K001.Text <> WK_str2 Then
            CHG.Text = "äÆóπì‡óeÅF" & WK_str2 & " Å® " & Edit_K001.Text
            CHG_F = "1" : Exit Sub 'äÆóπì‡óe
        End If

        If IsDBNull(DtView3(0)("comp_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_comn")
        If Edit_K002.Text <> WK_str2 Then
            CHG.Text = "äÆóπÉRÉÅÉìÉgÅF" & WK_str2 & " Å® " & Edit_K002.Text
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉÅÉìÉg
        End If

        If IsDBNull(DtView3(0)("comp_sum_flg")) Then
            If CheckBox_K001.Checked = True Then
                CHG.Text = "äÆóπé©ìÆåvéZâèúÅFëŒè€äO Å® ëŒè€"
                CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
            End If
        Else
            If DtView3(0)("comp_sum_flg") = "0" Then
                If CheckBox_K001.Checked = True Then
                    CHG.Text = "äÆóπé©ìÆåvéZâèúÅFëŒè€äO Å® ëŒè€"
                    CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
                End If
            Else
                If CheckBox_K001.Checked = False Then
                    CHG.Text = "äÆóπé©ìÆåvéZâèúÅFëŒè€ Å® ëŒè€äO"
                    CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
                End If
            End If
        End If

        If IsDBNull(DtView3(0)("apple_Dlvy_rep_flg")) Then
            If CheckBox_K002.Checked = True Then
                CHG.Text = "AppleîzëóèCóùÅiP&DÅjÅFìXì‡èCóù Å® îzëóèCóù"
                CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
            End If
        Else
            If DtView3(0)("apple_Dlvy_rep_flg") = "0" Then
                If CheckBox_K002.Checked = True Then
                    CHG.Text = "AppleîzëóèCóùÅiP&DÅjÅFìXì‡èCóù Å® îzëóèCóù"
                    CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
                End If
            Else
                If CheckBox_K002.Checked = False Then
                    CHG.Text = "AppleîzëóèCóùÅiP&DÅjÅFîzëóèCóù Å® ìXì‡èCóù"
                    CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
                End If
            End If
        End If

        If IsDBNull(DtView3(0)("comp_shop_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_tech_chrg")
        If Number111.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„ãZèpóøÅF" & WK_int2 & " Å® " & Number111.Value
            CHG_F = "1" : Exit Sub 'äÆóπåvè„ãZèpóø
        End If

        If IsDBNull(DtView3(0)("comp_shop_apes")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_apes")
        If Number112.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„APESÅF" & WK_int2 & " Å® " & Number112.Value
            CHG_F = "1" : Exit Sub 'APES
        End If

        If IsDBNull(DtView3(0)("comp_shop_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_part_chrg")
        If Number113.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„ïîïië„ÅF" & WK_int2 & " Å® " & Number113.Value
            CHG_F = "1" : Exit Sub 'äÆóπåvè„ïîïië„
        End If

        If IsDBNull(DtView3(0)("comp_shop_fee")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_fee")
        If Number114.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„éËêîóøÅF" & WK_int2 & " Å® " & Number114.Value
            CHG_F = "1" : Exit Sub 'äÆóπåvè„éËêîóø
        End If

        If IsDBNull(DtView3(0)("comp_shop_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_pstg")
        If Number115.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„ëóóøÅF" & WK_int2 & " Å® " & Number115.Value
            CHG_F = "1" : Exit Sub 'äÆóπåvè„ëóóø
        End If

        If IsDBNull(DtView3(0)("comp_shop_ttl")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_ttl")
        If Number116.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„è¨åvÅF" & WK_int2 & " Å® " & Number116.Value
            CHG_F = "1" : Exit Sub 'äÆóπåvè„è¨åv
        End If

        If IsDBNull(DtView3(0)("comp_shop_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_tax")
        If Number117.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„è¡îÔê≈ÅF" & WK_int2 & " Å® " & Number117.Value
            CHG_F = "1" : Exit Sub 'äÆóπåvè„è¡îÔê≈
        End If

        If IsDBNull(DtView3(0)("comp_eu_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_tech_chrg")
        If Number121.Value <> WK_int2 Then
            CHG.Text = "äÆóπEUãZèpóøÅF" & WK_int2 & " Å® " & Number121.Value
            CHG_F = "1" : Exit Sub 'äÆóπEUãZèpóø
        End If

        If IsDBNull(DtView3(0)("comp_eu_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_part_chrg")
        If Number123.Value <> WK_int2 Then
            CHG.Text = "äÆóπEUïîïië„ÅF" & WK_int2 & " Å® " & Number123.Value
            CHG_F = "1" : Exit Sub 'äÆóπEUïîïië„
        End If

        If IsDBNull(DtView3(0)("comp_eu_fee")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_fee")
        If Number124.Value <> WK_int2 Then
            CHG.Text = "äÆóπEUéËêîóøÅF" & WK_int2 & " Å® " & Number124.Value
            CHG_F = "1" : Exit Sub 'äÆóπEUéËêîóø
        End If

        If IsDBNull(DtView3(0)("comp_eu_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_pstg")
        If Number125.Value <> WK_int2 Then
            CHG.Text = "äÆóπEUëóóøÅF" & WK_int2 & " Å® " & Number125.Value
            CHG_F = "1" : Exit Sub 'äÆóπEUëóóø
        End If

        If IsDBNull(DtView3(0)("comp_eu_ttl")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_ttl")
        If Number126.Value <> WK_int2 Then
            CHG.Text = "äÆóπEUè¨åvÅF" & WK_int2 & " Å® " & Number126.Value
            CHG_F = "1" : Exit Sub 'äÆóπEUè¨åv
        End If

        If IsDBNull(DtView3(0)("comp_eu_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_tax")
        If Number127.Value <> WK_int2 Then
            CHG.Text = "äÆóπEUè¡îÔê≈ÅF" & WK_int2 & " Å® " & Number127.Value
            CHG_F = "1" : Exit Sub 'äÆóπEUè¡îÔê≈
        End If

        If IsDBNull(DtView3(0)("comp_cost_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_tech_chrg")
        If Number131.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgãZèpóøÅF" & WK_int2 & " Å® " & Number131.Value
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉXÉgãZèpóø
        End If

        If IsDBNull(DtView3(0)("comp_cost_apes")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_apes")
        If Number132.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgAPESÅF" & WK_int2 & " Å® " & Number132.Value
            CHG_F = "1" : Exit Sub 'APES
        End If

        If IsDBNull(DtView3(0)("comp_cost_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_part_chrg")
        If Number133.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgïîïië„ÅF" & WK_int2 & " Å® " & Number133.Value
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉXÉgïîïië„
        End If

        If IsDBNull(DtView3(0)("comp_cost_fee")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_fee")
        If Number134.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgéËêîóøÅF" & WK_int2 & " Å® " & Number134.Value
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉXÉgéËêîóø
        End If

        If IsDBNull(DtView3(0)("comp_cost_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_pstg")
        If Number135.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgëóóøÅF" & WK_int2 & " Å® " & Number135.Value
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉXÉgëóóø
        End If

        If IsDBNull(DtView3(0)("comp_cost_ttl")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_ttl")
        If Number136.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgè¨åvÅF" & WK_int2 & " Å® " & Number136.Value
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉXÉgè¨åv
        End If

        If IsDBNull(DtView3(0)("comp_cost_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_tax")
        If Number137.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgè¡îÔê≈ÅF" & WK_int2 & " Å® " & Number137.Value
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉXÉgè¡îÔê≈
        End If


        'èCóùì‡óe
        For i = 0 To Line_No4
            If label_4(i, 2).Text = Nothing Then
                If cmbBo_4(i, 1).Text <> Nothing Then
                    'í«â¡
                    CHG.Text = "èCóùì‡óeÅFí«â¡"
                    CHG_F = "1" : Exit Sub 'èCóùì‡óe
                End If
            Else
                WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_3"), "seq = " & label_4(i, 2).Text, "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If cmbBo_4(i, 1).Text <> Nothing Then
                        If cmbBo_4(i, 1).Text <> WK_DtView1(0)("cmnt_name1") Then
                            'ïœçX
                            CHG.Text = "èCóùì‡óeÅF" & WK_DtView1(0)("cmnt_name1") & " Å® " & cmbBo_4(i, 1).Text
                            CHG_F = "1" : Exit Sub 'èCóùì‡óe
                        End If
                    Else
                        'çÌèú
                        CHG.Text = "èCóùì‡óeÅFçÌèú"
                        CHG_F = "1" : Exit Sub 'èCóùì‡óe
                    End If
                End If
            End If
        Next

        'äÆóπïîïi
        For i = 0 To 1000
            WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)
            WK_DtView2 = New DataView(DsList1.Tables("T04_REP_PART_MOTO_2"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)

            If WK_DtView1.Count = 0 Then
                If WK_DtView2.Count = 0 Then
                    Exit For
                Else
                    'çÌèú
                    CHG.Text = "äÆóπïîïiÅFçÌèú"
                    CHG_F = "1" : Exit Sub 'äÆóπïîïi
                End If
            Else
                If WK_DtView2.Count = 0 Then
                    'í«â¡
                    CHG.Text = "äÆóπïîïiÅFí«â¡"
                    CHG_F = "1" : Exit Sub 'äÆóπïîïi
                Else
                    If IsDBNull(WK_DtView1(0)("ibm_flg")) Then WK_DtView1(0)("ibm_flg") = "False"
                    If IsDBNull(WK_DtView2(0)("ibm_flg")) Then WK_DtView2(0)("ibm_flg") = "False"
                    If IsDBNull(WK_DtView1(0)("exp_flg")) Then WK_DtView1(0)("exp_flg") = "False"
                    If IsDBNull(WK_DtView2(0)("exp_flg")) Then WK_DtView2(0)("exp_flg") = "False"
                    If IsDBNull(WK_DtView1(0)("cost_chrg")) Then WK_DtView1(0)("cost_chrg") = 0
                    If IsDBNull(WK_DtView2(0)("cost_chrg")) Then WK_DtView2(0)("cost_chrg") = 0

                    If WK_DtView1(0)("part_code") <> WK_DtView2(0)("part_code") _
                        Or WK_DtView1(0)("part_name") <> WK_DtView2(0)("part_name") _
                        Or WK_DtView1(0)("part_amnt") <> WK_DtView2(0)("part_amnt") _
                        Or WK_DtView1(0)("use_qty") <> WK_DtView2(0)("use_qty") _
                        Or WK_DtView1(0)("zaiko_flg") <> WK_DtView2(0)("zaiko_flg") _
                        Or WK_DtView1(0)("cost_chrg") <> WK_DtView2(0)("cost_chrg") _
                        Or WK_DtView1(0)("shop_chrg") <> WK_DtView2(0)("shop_chrg") _
                        Or WK_DtView1(0)("eu_chrg") <> WK_DtView2(0)("eu_chrg") _
                        Or WK_DtView1(0)("ordr_no") <> WK_DtView2(0)("ordr_no") _
                        Or WK_DtView1(0)("ordr_no2") <> WK_DtView2(0)("ordr_no2") _
                        Or WK_DtView1(0)("ibm_flg") <> WK_DtView2(0)("ibm_flg") _
                        Or WK_DtView1(0)("exp_flg") <> WK_DtView2(0)("exp_flg") Then
                        'ïœçX
                        CHG.Text = "äÆóπïîïiÅFïœçX"
                        CHG_F = "1" : Exit Sub 'äÆóπïîïi
                    End If
                End If
            End If
        Next

    End Sub

    '********************************************************************
    '**  ïœçXóöó
    '********************************************************************
    Sub CHG_HSTY()
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)
        DtView3 = New DataView(DsList1.Tables("T01_REP_MTR_K"), "", "", DataViewRowState.CurrentRows)

        If Date015.Number = 0 Then WK_str = Nothing Else WK_str = Date015.Text
        If IsDBNull(DtView2(0)("sindan_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView2(0)("sindan_date"))
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "êfífì˙", WK_str2, WK_str)
        End If

        If Date006.Number = 0 Then WK_str = Nothing Else WK_str = Date006.Text
        If IsDBNull(DtView2(0)("rsrv_cacl_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("rsrv_cacl_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "âÒìöéÛêMì˙", WK_str2, WK_str)
        End If

        If Date007.Number = 0 Then WK_str = Nothing Else WK_str = Date007.Text
        If IsDBNull(DtView3(0)("part_ordr_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("part_ordr_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, Label015.Text, WK_str2, WK_str)
        End If

        If Date008.Number = 0 Then WK_str = Nothing Else WK_str = Date008.Text
        If IsDBNull(DtView3(0)("part_rcpt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("part_rcpt_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, Label016.Text, WK_str2, WK_str)
        End If

        If Date016.Number = 0 Then WK_str = Nothing Else WK_str = Date016.Text
        If IsDBNull(DtView3(0)("rep_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("rep_date"))
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì˙", WK_str2, WK_str)
        End If

        If Date017.Number = 0 Then WK_str = Nothing Else WK_str = Date017.Text
        If IsDBNull(DtView3(0)("renraku_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("renraku_date"))
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπòAóçì˙", WK_str2, WK_str)
        End If

        If Date010.Number = 0 Then WK_str = Nothing Else WK_str = Date010.Text
        If IsDBNull(DtView3(0)("comp_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("comp_date"))
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπì˙", WK_str2, WK_str)
        End If

        If Date011.Number = 0 Then WK_str = Nothing Else WK_str = Date011.Text
        If IsDBNull(DtView3(0)("sals_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("sals_date"))
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "îÑè„ì˙", WK_str2, WK_str)
        End If

        If Date012.Number = 0 Then WK_str = Nothing Else WK_str = Date012.Text
        If IsDBNull(DtView3(0)("ship_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("ship_date"))
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èoâ◊ì˙", WK_str2, WK_str)
        End If

        WK_str = Nothing
        If CkBox01_Y.Checked = True Then WK_str = "óL"
        If CkBox01_N.Checked = True Then WK_str = "ñ≥"
        If IsDBNull(DtView1(0)("kashitsu_flg")) Then
            WK_str2 = Nothing
        Else
            If DtView1(0)("kashitsu_flg") = "1" Then WK_str2 = "óL" Else WK_str2 = "ñ≥"
        End If
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "âﬂé∏", WK_str2, WK_str)
        End If

        WK_str = Trim(Edit012.Text)
        If IsDBNull(DtView1(0)("orgnl_vndr_code")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("orgnl_vndr_code")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ", WK_str2, WK_str)
        End If

        If IsDBNull(DtView1(0)("recv_amnt")) Then WK_int2 = 0 Else WK_int2 = DtView1(0)("recv_amnt")
        If Number002.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "óaÇ©ÇËã‡", WK_int2, Number002.Value)
        End If

        'If Combo_K001.Visible = True Then WK_str = Combo_K001.Text Else WK_str = Nothing
        WK_str = Combo_K001.Text
        If IsDBNull(DtView3(0)("repr_empl_name")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("repr_empl_name")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùíSìñ", WK_str2, WK_str)
        End If

        If Combo_K002.Visible = True Then WK_str = Combo_K002.Text Else WK_str = Nothing
        If IsDBNull(DtView3(0)("select_case")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("select_case")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ÉÅÅ[ÉJÅ[ï€èÿãZèpóø", WK_str2, WK_str)
        End If

        If IsDBNull(DtView3(0)("sb_imei_new")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("sb_imei_new")
        If Edit_K003.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "SB/êVIMEI", WK_str2, Edit_K003.Text)
        End If

        If Edit_K004.Text <> Nothing _
            And Edit_K004.Text <> Edit_U003.Text Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "S/N", Edit_U003.Text, Edit_K004.Text)
        End If

        WK_str = Combo_K003.Text
        If IsDBNull(DtView3(0)("kjo_brch_name")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("kjo_brch_name")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "åvè„ÇpÇf", WK_str2, WK_str)
        End If

        WK_str = Combo_K004.Text
        If IsDBNull(DtView3(0)("payment_type_name")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("payment_type_name")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ì¸ã‡éÌï ", WK_str2, WK_str)
        End If

        If IsDBNull(DtView3(0)("comp_meas")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_meas")
        If Edit_K001.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe", WK_str2, Edit_K001.Text)
        End If

        If IsDBNull(DtView3(0)("comp_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_comn")
        If Edit_K002.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùÉRÉÅÉìÉg", WK_str2, Edit_K002.Text)
        End If

        If IsDBNull(DtView3(0)("comp_sum_flg")) Then
            If CheckBox_K001.Checked = True Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπé©ìÆåvéZâèú", "ëŒè€äO", "ëŒè€")
            End If
        Else
            If DtView3(0)("comp_sum_flg") = "0" Then
                If CheckBox_K001.Checked = True Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπé©ìÆåvéZâèú", "ëŒè€äO", "ëŒè€")
                End If
            Else
                If CheckBox_K001.Checked = False Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπé©ìÆåvéZâèú", "ëŒè€", "ëŒè€äO")
                End If
            End If
        End If

        If IsDBNull(DtView3(0)("apple_Dlvy_rep_flg")) Then
            If CheckBox_K002.Checked = True Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "AppleîzëóèCóùÅiP&DÅj", "ìXì‡èCóù", "îzëóèCóù")
            End If
        Else
            If DtView3(0)("apple_Dlvy_rep_flg") = "0" Then
                If CheckBox_K002.Checked = True Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "AppleîzëóèCóùÅiP&DÅj", "ìXì‡èCóù", "îzëóèCóù")
                End If
            Else
                If CheckBox_K002.Checked = False Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "AppleîzëóèCóùÅiP&DÅj", "îzëóèCóù", "ìXì‡èCóù")
                End If
            End If
        End If

        If IsDBNull(DtView3(0)("comp_cost_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_tech_chrg")
        If Number131.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgãZèpóø", WK_int2, Number131.Value)
        End If

        If IsDBNull(DtView3(0)("comp_cost_apes")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_apes")
        If Number132.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgÇ`ÇoÇdÇr", WK_int2, Number132.Value)
        End If

        If IsDBNull(DtView3(0)("comp_cost_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_part_chrg")
        If Number133.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgïîïië„", WK_int2, Number133.Value)
        End If

        If IsDBNull(DtView3(0)("comp_cost_fee")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_fee")
        If Number134.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgÇªÇÃëº", WK_int2, Number134.Value)
        End If

        If IsDBNull(DtView3(0)("comp_cost_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_pstg")
        If Number135.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgëóóø", WK_int2, Number135.Value)
        End If

        If IsDBNull(DtView3(0)("comp_cost_ttl")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_ttl")
        If Number136.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgè¨åv", WK_int2, Number136.Value)
        End If

        If IsDBNull(DtView3(0)("comp_cost_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_tax")
        If Number137.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgè¡îÔê≈", WK_int2, Number137.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_tech_chrg")
        If Number111.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„ãZèpóø", WK_int2, Number111.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_apes")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_apes")
        If Number112.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„Ç`ÇoÇdÇr", WK_int2, Number112.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_part_chrg")
        If Number113.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„ïîïië„", WK_int2, Number113.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_fee")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_fee")
        If Number114.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„ÇªÇÃëº", WK_int2, Number114.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_pstg")
        If Number115.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„ëóóø", WK_int2, Number115.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_ttl")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_ttl")
        If Number116.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„è¨åv", WK_int2, Number116.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_tax")
        If Number117.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„è¡îÔê≈", WK_int2, Number117.Value)
        End If

        If IsDBNull(DtView3(0)("comp_eu_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_tech_chrg")
        If Number121.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÇdÇtãZèpóø", WK_int2, Number121.Value)
        End If

        If IsDBNull(DtView3(0)("comp_eu_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_part_chrg")
        If Number123.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÇdÇtïîïië„", WK_int2, Number123.Value)
        End If

        If IsDBNull(DtView3(0)("comp_eu_fee")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_fee")
        If Number124.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÇdÇtÇªÇÃëº", WK_int2, Number124.Value)
        End If

        If IsDBNull(DtView3(0)("comp_eu_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_pstg")
        If Number125.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÇdÇtëóóø", WK_int2, Number125.Value)
        End If

        If IsDBNull(DtView3(0)("comp_eu_ttl")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_ttl")
        If Number126.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÇdÇtè¨åv", WK_int2, Number126.Value)
        End If

        If IsDBNull(DtView3(0)("comp_eu_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_eu_tax")
        If Number127.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÇdÇtè¡îÔê≈", WK_int2, Number127.Value)
        End If

        'If IsDBNull(DtView3(0)("zero_code")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("zero_code")
        'If zero_code.Text <> WK_str2 Then
        '    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ÇOâ~óùóRÉRÅ[Éh", WK_str2, zero_code.Text)
        'End If

        If IsDBNull(DtView3(0)("zero_name")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("zero_name")
        If zero_name.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ÇOâ~óùóR", WK_str2, zero_name.Text)
        End If
    End Sub

    '********************************************************************
    '**  çXêV
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        chg_itm = 0
        P_HSTY_DATE = Now
        F_Check()   '**  çÄñ⁄É`ÉFÉbÉN
        If Err_F = "0" Then
            ' add 2021-03-30
            If Combo_K004.Text = Nothing Then
                Combo_K004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
                msg.Text = "ì¸ã‡éÌï Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                GoTo end_tb
            End If

            CHK_Edit_K003_2()   'êVSB/IMEI
            If msg.Text <> Nothing Then
                ANS = MessageBox.Show("êVIMEIî‘çÜÇ™15åÖÇ≈ÇÕÇ»Ç¢Ç≈Ç∑Ç™çXêVÇµÇ‹Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If ANS = "7" Then GoTo end_tb 'Ç¢Ç¢Ç¶
            End If

            CHK_Date007()       'ïîïiî≠íçì˙
            If CK_own_flg.Checked = True Then
                If WK_MSG <> Nothing Then
                    ANS = MessageBox.Show(WK_MSG & System.Environment.NewLine & "çXêVÇµÇ‹Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                    If ANS = "2" Then GoTo end_tb 'Ç¢Ç¢Ç¶
                End If
            End If

            CHK_Date008()       'ïîïiéÛóÃì˙
            If CK_own_flg.Checked = True Then
                If WK_MSG <> Nothing Then
                    ANS = MessageBox.Show(WK_MSG & System.Environment.NewLine & "çXêVÇµÇ‹Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                    If ANS = "2" Then GoTo end_tb 'Ç¢Ç¢Ç¶
                End If
            End If

            'If CK_own_flg.Checked = True Then
            '    If Date007.Number = 0 Then
            '        ANS = MessageBox.Show(Label015.Text & "Ç…ì˙ïtÇ™ì¸Ç¡ÇƒÇ¢Ç‹ÇπÇÒÅB" & System.Environment.NewLine & "çXêVÇµÇ‹Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            '        If ANS = "2" Then GoTo end_tb 'Ç¢Ç¢Ç¶
            '    End If
            'End If

            If CInt(sn_n.Text) >= 2 Then
                ANS = MessageBox.Show("ä˘Ç…2âÒåä∑ëŒâûçœÇ›Ç≈Ç∑ÅBämîFÇÇ®äËÇ¢ÇµÇ‹Ç∑ÅB" & System.Environment.NewLine & "çXêVÇµÇ‹Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then GoTo end_tb 'Ç¢Ç¢Ç¶
            End If

            If Edit_K004.Enabled = True Then
                If Edit_K004.Text = Nothing Then
                    ANS = MessageBox.Show("êVS/NÇ™ì¸Ç¡ÇƒÇ¢Ç‹ÇπÇÒÅBçXêVÇµÇƒÇÊÇÎÇµÇ¢Ç≈Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                    If ANS = "2" Then GoTo end_tb 'Ç¢Ç¢Ç¶
                End If
            End If

            Select Case CLU001.Text
                Case Is = "01", "20", "21", "22", "23", "24", "25"

                    If Date016.Number = 0 Then
                        ANS = MessageBox.Show("èCóùì˙Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅAÇ±ÇÃèCóùÇÕNTF Ç‹ÇΩÇÕÉLÉÉÉìÉZÉãÇ≈Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                        If ANS = "2" Then GoTo end_tb 'Ç¢Ç¢Ç¶
                    End If

                    If Date017.Number = 0 Then
                        ANS = MessageBox.Show("äÆóπòAóçì˙Ç™ãÛóìÇ≈Ç∑ÅAÇ®ãqólÇ…òAóçÇπÇ∏Ç…Ç≤ï‘ãpÇ≈ä‘à·Ç¢Ç†ÇËÇ‹ÇπÇÒÇ©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                        If ANS = "2" Then GoTo end_tb 'Ç¢Ç¢Ç¶
                    End If

                Case Else
            End Select

            NoDsp_Null()

            If Number116.Value = 0 Then
                P_PRAM1 = zero_code.Text
                P_PRAM2 = zero_name.Text

                Dim F00_Form09 As New F00_Form09    '0â~óùóR
                F00_Form09.ShowDialog()

                If P_RTN = "0" Then
                    Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If
                zero_code.Text = P_PRAM1
                zero_name.Text = P_PRAM2
            End If

            'ÉäÉxÅ[ÉgSET
            'é©å»ïâíSSET
            Dim WK_str1, WK_str2 As String
            If CK_own_flg.Checked = True Then WK_str1 = "True" Else WK_str1 = "False"
            If CLU001.Text = "01" Then
                If CheckBox_U003.Checked = True Then WK_str2 = "01" Else WK_str2 = "02"
            Else
                If CheckBox_U001.Checked = True Then WK_str2 = "01" Else WK_str2 = "02"
            End If
            If CL001.Text = "10" And GRP.Text = "88" Then
                rebate_idvd_Get2(Edit001.Text, CL004.Text, CL001.Text, Number001.Value, Number003.Value, Number118.Value, Number116.Value, WK_str1, CLU001.Text, WK_str2)
            Else
                rebate_idvd_Get(Edit001.Text, CL004.Text, CL001.Text, Number001_nTax.Value, Number003.Value, Number118.Value, Number116.Value, WK_str1, CLU001.Text, WK_str2)
            End If
            rebate.Value = P_rebate
            idvd_chrg.Value = P_idvd
            ''ÉäÉxÅ[ÉgSET
            'If CK_own_flg.Checked = True Then
            '    rebate.Value = rebate_Get(Edit001.Text, CL001.Text, Number118.Value, Number116.Value, "True")
            'Else
            '    rebate.Value = rebate_Get(Edit001.Text, CL001.Text, Number118.Value, Number116.Value, "False")
            'End If
            ''é©å»ïâíSSET
            'idvd_chrg.Value = 0
            'If Number118.Value <> 0 Then
            '    If CL001.Text = "02" Then
            '        idvd_chrg.Value = idvd_chrg_Get(Number001.Value, Number118.Value, Number003.Value)
            '    End If
            'End If

            CHG_HSTY()  '**  ïœçXóöó

            If chg_itm <> 0 Then
                'éÛït
                strSQL = "UPDATE T01_REP_MTR"
                strSQL += " SET fin_ent_empl_code = " & P_EMPL_NO
                strSQL += ", orgnl_vndr_code = '" & Edit012.Text & "'"
                strSQL += ", recv_amnt = " & Number002.Value
                'If Combo_K001.Visible = True And CLK001.Text <> Nothing Then
                strSQL += ", repr_empl_code = '" & CLK001.Text & "'"
                'Else
                '    strSQL += ", repr_empl_code = NULL"
                'End If
                strSQL += ", repr_brch_code = '" & CLK001_BRH.Text & "'"
                If Combo_K002.Visible = True Then
                    strSQL += ", m_tech_seq = " & CLK002.Text
                Else
                    strSQL += ", m_tech_seq = NULL"
                End If
                strSQL += ", comp_meas = '" & Edit_K001.Text & "'"
                strSQL += ", comp_comn = '" & Edit_K002.Text & "'"
                strSQL += ", comp_cost_tech_chrg = " & Number131.Value
                strSQL += ", comp_cost_apes = " & Number132.Value
                strSQL += ", comp_cost_part_chrg = " & Number133.Value
                strSQL += ", comp_cost_fee = " & Number134.Value
                strSQL += ", comp_cost_pstg = " & Number135.Value
                strSQL += ", comp_cost_ttl = " & Number136.Value
                strSQL += ", comp_cost_tax = " & Number137.Value

                strSQL += ", comp_shop_tech_chrg = " & Number111.Value
                strSQL += ", comp_shop_apes = " & Number112.Value
                strSQL += ", comp_shop_part_chrg = " & Number113.Value
                strSQL += ", comp_shop_fee = " & Number114.Value
                strSQL += ", comp_shop_pstg = " & Number115.Value
                strSQL += ", comp_shop_ttl = " & Number116.Value
                strSQL += ", comp_shop_tax = " & Number117.Value

                strSQL += ", comp_eu_tech_chrg = " & Number121.Value
                strSQL += ", comp_eu_apes = " & Number122.Value
                strSQL += ", comp_eu_part_chrg = " & Number123.Value
                strSQL += ", comp_eu_fee = " & Number124.Value
                strSQL += ", comp_eu_pstg = " & Number125.Value
                strSQL += ", comp_eu_ttl = " & Number126.Value
                strSQL += ", comp_eu_tax = " & Number127.Value

                strSQL += ", tech_rate1 = " & NumberN003.Value
                strSQL += ", fix1 = " & NumberN006.Value
                strSQL += ", tech_rate2 = " & NumberN007.Value
                strSQL += ", part_rate2 = " & NumberN008.Value

                If Date006.Number <> 0 Then strSQL += ", rsrv_cacl_date = '" & Date006.Text & "'" Else strSQL += ", rsrv_cacl_date = NULL"
                If Date007.Number <> 0 Then strSQL += ", part_ordr_date = '" & Date007.Text & "'" Else strSQL += ", part_ordr_date = NULL"
                If Date008.Number <> 0 Then strSQL += ", part_rcpt_date = '" & Date008.Text & "'" Else strSQL += ", part_rcpt_date = NULL"
                If Date010.Number <> 0 Then strSQL += ", comp_date = '" & Date010.Text & "'" Else strSQL += ", comp_date = NULL"
                If Date011.Number <> 0 Then strSQL += ", sals_date = '" & Date011.Text & "'" Else strSQL += ", sals_date = NULL"
                If Date012.Number <> 0 Then strSQL += ", ship_date = '" & Date012.Text & "'" Else strSQL += ", ship_date = NULL"
                If Date015.Number <> 0 Then strSQL += ", sindan_date = '" & Date015.Text & "'" Else strSQL += ", sindan_date = NULL"
                If Date016.Number <> 0 Then strSQL += ", rep_date = '" & Date016.Text & "'" Else strSQL += ", rep_date = NULL"
                If Date017.Number <> 0 Then strSQL += ", renraku_date = '" & Date017.Text & "'" Else strSQL += ", renraku_date = NULL"
                strSQL += ", zero_code = '" & zero_code.Text & "'"
                strSQL += ", zero_name = '" & zero_name.Text & "'"
                strSQL += ", rebate = " & rebate.Value & ""
                strSQL += ", idvd_chrg = " & idvd_chrg.Value & ""
                If Date010.Number <> 0 Then
                    strSQL += ", re_rpar_date = '" & DateAdd(DateInterval.Day, NumberN009.Value, CDate(Date010.Text)) & "'"
                Else
                    strSQL += ", re_rpar_date = NULL"
                End If
                If CheckBox_K001.Checked = True Then strSQL += ", comp_sum_flg = '1'" Else strSQL += ", comp_sum_flg = '0'"
                If CheckBox_K002.Checked = True Then strSQL += ", apple_Dlvy_rep_flg = '1'" Else strSQL += ", apple_Dlvy_rep_flg = '0'"
                strSQL += ", kjo_brch_code = '" & CLK003.Text & "'"
                strSQL += ", payment_type = '" & CLK004.Text & "'"
                strSQL += ", sb_imei_new = '" & Edit_K003.Text & "'"
                If CkBox01_Y.Checked = True Then
                    strSQL += ", kashitsu_flg = 1"
                Else
                    If CkBox01_N.Checked = True Then
                        strSQL += ", kashitsu_flg = 0"
                    Else
                        strSQL += ", kashitsu_flg = NULL"
                    End If
                End If
                'If Edit_K004.Text <> Nothing _
                '    And Edit_K004.Text <> Edit_U003.Text Then
                '    strSQL += ", s_n = '" & Edit_K004.Text & "'"
                'End If
                strSQL += ", tax_rate = " & tax_rate.Text
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Call QA_started_flg_ON(Edit000.Text)    'Q&A íÖéËçœÉtÉâÉOçXêV


                If Edit_K004.Text <> Nothing _
                    And Edit_K004.Text <> Edit_U003.Text Then
                    DB_OPEN("QGCare")
                    'strSQL = "UPDATE T01_member"
                    'strSQL += " SET s_no = '" & Edit_K004.Text & "'"
                    'strSQL += " WHERE (code = '" & Edit011.Text & "')"
                    'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    'SqlCmd1.CommandTimeout = 600
                    'SqlCmd1.ExecuteNonQuery()

                    strSQL = "INSERT INTO T06_sno"
                    strSQL += " (code, s_no)"
                    strSQL += " VALUES ('" & Edit011.Text & "'"
                    strSQL += ", '" & Edit_K004.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    'Edit_U003.Text = Edit_K004.Text
                    'Edit_K004.Text = Nothing
                End If

                'QG Care èCóùã‡äzó›åv
                If (CL001.Text = "02" Or CL001.Text = "03") And CL004.Text <> "02" Then
                    QG_HSTY(Edit011.Text, Edit000.Text, Date_U003.Text, Number118.Value)
                End If

            End If

            'èCóùì‡óe
            WK_DsList1.Clear()
            strSQL = "SELECT MAX(seq) AS max_seq FROM T03_REP_CMNT WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '3')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "T02_ATCH_ITEM")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("T02_ATCH_ITEM"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                seq = 0
            Else
                If Not IsDBNull(WK_DtView1(0)("max_seq")) Then
                    seq = WK_DtView1(0)("max_seq")
                Else
                    seq = 0
                End If
            End If

            For i = 0 To Line_No4
                If label_4(i, 2).Text = Nothing Then
                    If cmbBo_4(i, 1).Text <> Nothing Then
                        'í«â¡
                        seq = seq + 1

                        strSQL = "INSERT INTO T03_REP_CMNT"
                        strSQL += " (rcpt_no, kbn, seq, cls_code1, cmnt_code1)"
                        strSQL += " VALUES ('" & Edit000.Text & "'"
                        strSQL += ", '3'"
                        strSQL += ", " & seq
                        strSQL += ", '21'"
                        strSQL += ", '" & label_4(i, 1).Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        WK_str = cmbBo_4(i, 1).Text
                        chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe" & seq, "", WK_str)

                        label_4(i, 2).Text = seq
                        GoTo skp2
                    End If
                Else
                    WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_3"), "seq = " & label_4(i, 2).Text, "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        If cmbBo_4(i, 1).Text <> Nothing Then
                            If cmbBo_4(i, 1).Text <> WK_DtView1(0)("cmnt_name1") Then
                                'ïœçX
                                strSQL = "UPDATE T03_REP_CMNT"
                                strSQL += " SET cmnt_code1 = '" & label_4(i, 1).Text & "'"
                                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '3') AND (seq = " & label_4(i, 2).Text & ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                DB_OPEN("nMVAR")
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                WK_str = cmbBo_4(i, 1).Text
                                WK_str2 = WK_DtView1(0)("cmnt_name1")
                                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe" & label_4(i, 2).Text, WK_str2, WK_str)

                                GoTo skp2
                            End If
                        Else
                            'çÌèú
                            strSQL = "DELETE FROM T03_REP_CMNT"
                            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '3') AND (seq = " & label_4(i, 2).Text & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            DB_OPEN("nMVAR")
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            WK_str2 = WK_DtView1(0)("cmnt_name1")
                            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe" & label_4(i, 2).Text, WK_str2, "")

                            label_4(i, 2).Text = Nothing
                            GoTo skp2
                        End If
                    End If
                End If
skp2:
            Next

            'ïîïi
            For i = 0 To 1000
                WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)
                WK_DtView2 = New DataView(DsList1.Tables("T04_REP_PART_MOTO_2"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)

                If WK_DtView1.Count = 0 Then
                    If WK_DtView2.Count = 0 Then
                        Exit For
                    Else
                        'çÌèú
                        strSQL = "DELETE FROM T04_REP_PART"
                        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (seq = " & WK_DtView2(0)("seq") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        WK_str2 = WK_DtView2(0)("part_code") & " / " & WK_DtView2(0)("part_name") & " / " & Format(WK_DtView2(0)("part_amnt"), "##,##0") & " / " & WK_DtView2(0)("use_qty") & " / " & WK_DtView2(0)("shop_chrg") & " / " & WK_DtView2(0)("eu_chrg") & " / " & WK_DtView2(0)("ordr_no") & " / " & WK_DtView2(0)("ordr_no2")
                        chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπïîïi" & i, WK_str2, "")
                    End If
                Else
                    If IsDBNull(WK_DtView1(0)("ibm_flg")) Then WK_DtView1(0)("ibm_flg") = "False"
                    If IsDBNull(WK_DtView1(0)("exp_flg")) Then WK_DtView1(0)("exp_flg") = "False"
                    If WK_DtView2.Count = 0 Then
                        'í«â¡
                        strSQL = "INSERT INTO T04_REP_PART"
                        strSQL += " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg, cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, s_n, ibm_flg, exp_flg)"
                        strSQL += " VALUES ('" & Edit000.Text & "'"
                        strSQL += ", '2'"
                        strSQL += ", " & WK_DtView1(0)("seq")
                        strSQL += ", '" & WK_DtView1(0)("part_code") & "'"
                        strSQL += ", '" & WK_DtView1(0)("part_name") & "'"
                        strSQL += ", " & WK_DtView1(0)("part_amnt") & ""
                        strSQL += ", " & WK_DtView1(0)("use_qty") & ""
                        If WK_DtView1(0)("zaiko_flg") = "True" Then strSQL += ", 1" Else strSQL += ", 0"
                        strSQL += ", " & WK_DtView1(0)("cost_chrg") & ""
                        'strSQL += ", " & WK_DtView1(0)("part_amnt") * WK_DtView1(0)("use_qty") & ""
                        strSQL += ", " & WK_DtView1(0)("shop_chrg") & ""
                        strSQL += ", " & WK_DtView1(0)("eu_chrg") & ""
                        strSQL += ", '" & WK_DtView1(0)("ordr_no") & "'"
                        strSQL += ", '" & WK_DtView1(0)("ordr_no2") & "'"
                        strSQL += ", '" & WK_DtView1(0)("s_n") & "'"
                        If WK_DtView1(0)("ibm_flg") = "True" Then strSQL += ", 1" Else strSQL += ", 0"
                        If WK_DtView1(0)("exp_flg") = "True" Then strSQL += ", 1)" Else strSQL += ", 0)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        WK_str = WK_DtView1(0)("part_code") & " / " & WK_DtView1(0)("part_name") & " / " & Format(WK_DtView1(0)("part_amnt"), "##,##0") & " / " & WK_DtView1(0)("use_qty") & " / " & WK_DtView1(0)("shop_chrg") & " / " & WK_DtView1(0)("eu_chrg") & " / " & WK_DtView1(0)("ordr_no") & " / " & WK_DtView1(0)("ordr_no2") & " / " & WK_DtView1(0)("zaiko_flg") & " / " & WK_DtView1(0)("ibm_flg") & " / " & WK_DtView1(0)("exp_flg")
                        chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπïîïi" & i, "", WK_str)
                    Else
                        If IsDBNull(WK_DtView1(0)("ibm_flg")) Then WK_DtView1(0)("ibm_flg") = "False"
                        If IsDBNull(WK_DtView2(0)("ibm_flg")) Then WK_DtView2(0)("ibm_flg") = "False"
                        If IsDBNull(WK_DtView1(0)("exp_flg")) Then WK_DtView1(0)("exp_flg") = "False"
                        If IsDBNull(WK_DtView2(0)("exp_flg")) Then WK_DtView2(0)("exp_flg") = "False"
                        If IsDBNull(WK_DtView1(0)("cost_chrg")) Then WK_DtView1(0)("cost_chrg") = 0
                        If IsDBNull(WK_DtView2(0)("cost_chrg")) Then WK_DtView2(0)("cost_chrg") = 0

                        If WK_DtView1(0)("part_code") <> WK_DtView2(0)("part_code") _
                            Or WK_DtView1(0)("part_name") <> WK_DtView2(0)("part_name") _
                            Or WK_DtView1(0)("part_amnt") <> WK_DtView2(0)("part_amnt") _
                            Or WK_DtView1(0)("use_qty") <> WK_DtView2(0)("use_qty") _
                            Or WK_DtView1(0)("shop_chrg") <> WK_DtView2(0)("shop_chrg") _
                            Or WK_DtView1(0)("eu_chrg") <> WK_DtView2(0)("eu_chrg") _
                            Or WK_DtView1(0)("ordr_no") <> WK_DtView2(0)("ordr_no") _
                            Or WK_DtView1(0)("ordr_no2") <> WK_DtView2(0)("ordr_no2") _
                            Or WK_DtView1(0)("zaiko_flg") <> WK_DtView2(0)("zaiko_flg") _
                            Or WK_DtView1(0)("ibm_flg") <> WK_DtView2(0)("ibm_flg") _
                            Or WK_DtView1(0)("exp_flg") <> WK_DtView2(0)("exp_flg") Then

                            'ïœçX
                            strSQL = "UPDATE T04_REP_PART"
                            strSQL += " SET part_code = '" & WK_DtView1(0)("part_code") & "'"
                            strSQL += ", part_name = '" & WK_DtView1(0)("part_name") & "'"
                            strSQL += ", part_amnt = " & WK_DtView1(0)("part_amnt") & ""
                            strSQL += ", use_qty = " & WK_DtView1(0)("use_qty") & ""
                            strSQL += ", cost_chrg = " & WK_DtView1(0)("cost_chrg") & ""
                            'strSQL += ", cost_chrg = " & WK_DtView1(0)("part_amnt") * WK_DtView1(0)("use_qty") & ""
                            strSQL += ", shop_chrg = " & WK_DtView1(0)("shop_chrg") & ""
                            strSQL += ", eu_chrg = " & WK_DtView1(0)("eu_chrg") & ""
                            strSQL += ", ordr_no = '" & WK_DtView1(0)("ordr_no") & "'"
                            strSQL += ", ordr_no2 = '" & WK_DtView1(0)("ordr_no2") & "'"
                            strSQL += ", s_n = '" & WK_DtView1(0)("s_n") & "'"
                            If WK_DtView1(0)("zaiko_flg") = "True" Then strSQL += ", zaiko_flg = 1" Else strSQL += ", zaiko_flg = 0"
                            If WK_DtView1(0)("ibm_flg") = "True" Then strSQL += ", ibm_flg = 1" Else strSQL += ", ibm_flg = 0"
                            If WK_DtView1(0)("exp_flg") = "True" Then strSQL += ", exp_flg = 1" Else strSQL += ", exp_flg = 0"
                            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                            strSQL += " AND (kbn = '2')"
                            strSQL += " AND (seq = " & WK_DtView1(0)("seq") & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            DB_OPEN("nMVAR")
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            WK_str = WK_DtView1(0)("part_code") & " / " & WK_DtView1(0)("part_name") & " / " & Format(WK_DtView1(0)("part_amnt"), "##,##0") & " / " & WK_DtView1(0)("use_qty") & " / " & WK_DtView1(0)("shop_chrg") & " / " & WK_DtView1(0)("eu_chrg") & " / " & WK_DtView1(0)("ordr_no") & " / " & WK_DtView1(0)("ordr_no2") & " / " & WK_DtView1(0)("zaiko_flg") & " / " & WK_DtView1(0)("ibm_flg") & " / " & WK_DtView1(0)("exp_flg")
                            WK_str2 = WK_DtView2(0)("part_code") & " / " & WK_DtView2(0)("part_name") & " / " & Format(WK_DtView2(0)("part_amnt"), "##,##0") & " / " & WK_DtView2(0)("use_qty") & " / " & WK_DtView2(0)("shop_chrg") & " / " & WK_DtView2(0)("eu_chrg") & " / " & WK_DtView2(0)("ordr_no") & " / " & WK_DtView2(0)("ordr_no2") & " / " & WK_DtView2(0)("zaiko_flg") & " / " & WK_DtView2(0)("ibm_flg") & " / " & WK_DtView2(0)("exp_flg")
                            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπïîïi" & i, WK_str2, WK_str)
                        End If
                    End If
                End If
            Next

            If chg_itm = 0 Then
                msg.Text = "ïœçXâ”èäÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
            Else
                'TSS
                TSS_F = "0"
                WK_DsList1.Clear()
                strSQL = "SELECT T01_REP_MTR.tss_comp_stts, V_TSS_REP_INF.id"
                strSQL += " FROM T01_REP_MTR LEFT OUTER JOIN"
                strSQL += " V_TSS_REP_INF ON T01_REP_MTR.rcpt_no = V_TSS_REP_INF.rcpt_no"
                strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & Edit000.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

                If IsDBNull(WK_DtView1(0)("tss_comp_stts")) Then
                    If Not IsDBNull(WK_DtView1(0)("id")) Then
                        TSS_F = "1"
                    End If
                    Select Case GRP.Text
                        Case Is = "18"
                            If CL001.Text = "07" Then
                                TSS_F = "1"
                            End If
                        Case Is = "19"
                            TSS_F = "1"
                    End Select

                    If TSS_F = "1" Then
                        strSQL = "UPDATE T01_REP_MTR"
                        strSQL += " SET tss_comp_stts = '1'"
                        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                End If

                'QA

                If QA_F = "1" Then
                    Dim WK_parts_name As String
                    Dim WK_ttl_amnt As Integer
                    DB_OPEN("nMVAR")
                    WK_DsList1.Clear()
                    'ïîïiñº
                    strSQL = "SELECT part_name"
                    strSQL += " FROM T04_REP_PART"
                    strSQL += " WHERE (kbn = '2') AND (rcpt_no = '" & Edit000.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    r = DaList1.Fill(WK_DsList1, "T04_REP_PART")
                    If r <> 0 Then
                        WK_DtView1 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                        For i = 0 To WK_DtView1.Count - 1
                            If i <> 0 Then WK_parts_name += "|"
                            WK_parts_name += WK_DtView1(i)("part_name")
                        Next
                    End If

                    'ïœçXëOÉXÉeÅ[É^ÉX
                    Dim WK_stts As String = "150"    'ÉfÉtÉHÉãÉg150èCóùÉLÉÉÉìÉZÉã(ã@äÌï‘ãpó\íË)
                    'strSQL = "SELECT stts FROM QA02_data WHERE (gss_rcpt_no = N'" & Edit000.Text & "')"
                    strSQL = "SELECT QA02_data.stts, V_cls_052.cls_code_name AS stts_name"
                    strSQL += " FROM QA02_data INNER JOIN"
                    strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
                    strSQL += " WHERE (gss_rcpt_no = N'" & Edit000.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    r = DaList1.Fill(WK_DsList1, "bfr_stts")
                    If r <> 0 Then
                        WK_DtView1 = New DataView(WK_DsList1.Tables("bfr_stts"), "", "", DataViewRowState.CurrentRows)
                        WK_stts = WK_DtView1(0)("stts")
                        Dim bfr_stts_name As String = WK_DtView1(0)("stts_name")

                        strSQL = "UPDATE QA02_data"
                        strSQL += " SET snd_flg = 1"
                        If WK_stts = "150" Or WK_stts = "70" Then         '150èCóùÉLÉÉÉìÉZÉã(ã@äÌï‘ãpó\íË) Ç‹ÇΩÇÕ 70:èCóùàÀóä
                            strSQL += ", stts = N'90'"                           '90èoâ◊éwé¶ë“Çø
                        End If
                        If WK_stts = "151" Then         '151èCóùÉLÉÉÉìÉZÉãÅië„ë÷ïiíÒãüÅj
                            strSQL += ", stts = N'91'"                           '91îpä¸àÀóäë“Çø
                        End If
                        strSQL += ", parts_name = N'" & WK_parts_name & "'"         'ïîïiñº
                        strSQL += ", parts_amnt = " & Number123.Value               '26ïîïiâøäiÅiEUïîïië„Åj
                        strSQL += ", etmt_amnt = 0"                                 '27å©êœóøÅiÅj
                        strSQL += ", tech_amnt = " & Number121.Value                '28ãZèpóøÅiEUãZèpÅj
                        strSQL += ", maker_fee = 0"                                 '29ÉÅÅ[ÉJÅ[éÊéüéËêîóøÅiÅj
                        strSQL += ", pstg = " & Number125.Value                     '30ëóóøÅiEUëóóøÅj
                        strSQL += ", daibiki_fee = 0"                               '31ë„à¯éËêîóøÅiÅj
                        strSQL += ", cxl_amnt = 0"                                  '32ÉLÉÉÉìÉZÉãóø(êfífóøÅiÉLÉÉÉìÉZÉãÅj)
                        WK_ttl_amnt = Number123.Value + 0 + Number121.Value + 0 + Number125.Value + 0 + 0
                        strSQL += ", ttl_amnt = " & WK_ttl_amnt                     'çáåväz
                        strSQL += " WHERE (gss_rcpt_no = N'" & Edit000.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()

                        'ïœçXå„ÉXÉeÅ[É^ÉX
                        strSQL = "SELECT V_cls_052.cls_code_name AS stts_name"
                        strSQL += " FROM QA02_data INNER JOIN"
                        strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
                        strSQL += " WHERE (gss_rcpt_no = N'" & Edit000.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(WK_DsList1, "afr_stts")
                        WK_DtView1 = New DataView(WK_DsList1.Tables("afr_stts"), "", "", DataViewRowState.CurrentRows)
                        Dim afr_stts_name As String = WK_DtView1(0)("stts_name")
                        DB_CLOSE()

                        If bfr_stts_name <> afr_stts_name Then
                            add_hsty(Edit000.Text, "QACÉXÉeÅ[É^ÉX", bfr_stts_name, afr_stts_name)
                        End If
                    Else
                        DB_CLOSE()
                    End If
                End If

                temp_clr()  'àÍéûï€ë∂ÉNÉäÉA
                rep_sql()   '** èCóùèÓïÒÇfÇdÇs(SQL)
                msg.Text = "çXêVÇµÇ‹ÇµÇΩÅB"

                'çÏã∆ïÒçêèëàÛç¸
                P_PRAM1 = Edit000.Text  'éÛïtî‘çÜ
                P_PRAM2 = Edit001.Text  'îÃé–
                Dim F00_Form13 As New F00_Form13
                F00_Form13.ShowDialog()

                If P_RTN = "1" Then
                    msg.Text = "çÏã∆ïÒçêèëÇàÛç¸ÇµÇ‹ÇµÇΩÅB"
                End If

                'WK_DsList1.Clear()
                'strSQL = "SELECT rpr_rprt_ptn FROM M08_STORE WHERE (store_code = '" & Edit001.Text & "')"
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'DaList1.SelectCommand = SqlCmd1
                'DB_OPEN("nMVAR")
                'DaList1.Fill(WK_DsList1, "rpr_rprt_ptn")
                'DB_CLOSE()
                'WK_DtView1 = New DataView(WK_DsList1.Tables("rpr_rprt_ptn"), "", "", DataViewRowState.CurrentRows)
                'If WK_DtView1.Count = 0 Then
                '    PRT_PRAM1 = "Print_R_Sagyou_Report" 'çÏã∆ïÒçêèëàÛç¸
                '    PRT_PRAM2 = Edit000.Text
                '    PRT_PRAM3 = "00"
                '    Dim F70_Form01 As New F70_Form01
                '    F70_Form01.ShowDialog()
                'Else
                '    PRT_PRAM1 = "Print_R_Sagyou_Report" 'çÏã∆ïÒçêèëàÛç¸
                '    PRT_PRAM2 = Edit000.Text
                '    PRT_PRAM3 = WK_DtView1(0)("rpr_rprt_ptn")
                '    Dim F70_Form01 As New F70_Form01
                '    F70_Form01.ShowDialog()
                'End If

                '**  àÛç¸
                P_PRAM1 = Edit000.Text  'éÛïtî‘çÜ
                P_PRAM2 = Edit002.Text  'î[ì¸êÊ
                If Button1.Enabled = False Then P_PRAM3 = "1" Else P_PRAM3 = "0" 'ÉvÉçÉeÉNÉg

                Dim F00_Form07 As New F00_Form07
                F00_Form07.ShowDialog()

                'If P_RTN = "1" Then
                rep_sql()   '** èCóùèÓïÒÇfÇdÇs(SQL)
                Dim WK_i As Integer = 0
                Combo006.Items.Clear()
                If Not IsDBNull(DtView3(0)("sals_no")) Then Combo006.Items.Add(DtView3(0)("sals_no")) : Combo006.Text = DtView3(0)("sals_no") : WK_i = 1
                If Not IsDBNull(DtView3(0)("sals_no2")) Then Combo006.Items.Add(DtView3(0)("sals_no2")) : WK_i = WK_i + 1
                Combo006.Enabled = True
                If WK_i > 1 Then
                    Combo006.DropDown.Visible = GrapeCity.Win.Input.Interop.Visibility.ShowAlways
                Else
                    Combo006.DropDown.Visible = GrapeCity.Win.Input.Interop.Visibility.NotShown
                End If
                If Not IsDBNull(DtView3(0)("sals_date")) Then Date011.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("sals_date")) Else Date011.Text = Nothing
                If Not IsDBNull(DtView3(0)("ship_date")) Then Date012.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("ship_date")) Else Date012.Text = Nothing
                If Not IsDBNull(DtView3(0)("rqst_date")) Then Date013.Text = DtView3(0)("rqst_date") Else Date013.Text = Nothing
                If Not IsDBNull(DtView3(0)("rebate")) Then rebate.Value = DtView3(0)("rebate") Else rebate.Value = 0
                If Not IsDBNull(DtView3(0)("idvd_chrg")) Then idvd_chrg.Value = DtView3(0)("idvd_chrg") Else idvd_chrg.Value = 0
                If Not IsDBNull(DtView3(0)("sals_amnt1")) Then NumberN011.Value = DtView3(0)("sals_amnt1") Else NumberN011.Value = 0
                If Not IsDBNull(DtView3(0)("sals_amnt2")) Then NumberN012.Value = DtView3(0)("sals_amnt2") Else NumberN012.Value = 0
                If Not IsDBNull(DtView3(0)("sals_amnt3")) Then NumberN013.Value = DtView3(0)("sals_amnt3") Else NumberN013.Value = 0
                If Not IsDBNull(DtView3(0)("sals_amnt5")) Then NumberN015.Value = DtView3(0)("sals_amnt5") Else NumberN015.Value = 0
                'End If

                'If idvd_flg.Text = "True" _
                '    Or CL001.Text = "03" Then 'Then  'àÍî å¬êl or âÑí∑ï€èÿ
                '    'êøãÅçœÇ›Ç…Ç∑ÇÈ



                'End If

            End If
        End If
end_tb:
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ÉNÉäÉA
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CHG_CHK()   '**  ïœçXâ”èäÉ`ÉFÉbÉN
        If CHG_F = "1" Then
            ANS = MessageBox.Show("ïœçXâ”èäÇ™Ç†ÇËÇ‹Ç∑ÅBÉNÉäÉAÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            If ANS = "2" Then Exit Sub 'Ç¢Ç¢Ç¶
        End If
        inz_F = "0"
        HAITA_OFF(Edit000.Text)  'HAITA_OFF
        inz_dsp()   '**  èâä˙âÊñ ÉZÉbÉg
    End Sub

    '********************************************************************
    '**  àÛç¸ÅiçÏã∆ïÒçêèëÅj
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CHG_CHK()   '**  ïœçXâ”èäÉ`ÉFÉbÉN
        If CHG_F = "1" Then
            msg.Text = "ïœçXâ”èäÇ™Ç†ÇËÇ‹Ç∑ÅBçXêVå„àÛç¸ÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB"
            Exit Sub
        End If

        P_PRAM1 = Edit000.Text  'éÛïtî‘çÜ
        P_PRAM2 = Edit001.Text  'îÃé–
        Dim F00_Form13 As New F00_Form13
        F00_Form13.ShowDialog()

        If P_RTN = "1" Then
            msg.Text = "çÏã∆ïÒçêèëÇàÛç¸ÇµÇ‹ÇµÇΩÅB"
        End If

        'WK_DsList1.Clear()
        'strSQL = "SELECT rpr_rprt_ptn FROM M08_STORE WHERE (store_code = '" & Edit001.Text & "')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'DaList1.Fill(WK_DsList1, "rpr_rprt_ptn")
        'DB_CLOSE()
        'WK_DtView1 = New DataView(WK_DsList1.Tables("rpr_rprt_ptn"), "", "", DataViewRowState.CurrentRows)
        'If WK_DtView1.Count = 0 Then
        '    PRT_PRAM1 = "Print_R_Sagyou_Report" 'çÏã∆ïÒçêèë
        '    PRT_PRAM2 = Edit000.Text
        '    PRT_PRAM3 = "00"
        '    Dim F70_Form01 As New F70_Form01
        '    F70_Form01.ShowDialog()
        'Else
        '    PRT_PRAM1 = "Print_R_Sagyou_Report" 'çÏã∆ïÒçêèë
        '    PRT_PRAM2 = Edit000.Text
        '    PRT_PRAM3 = WK_DtView1(0)("rpr_rprt_ptn")
        '    Dim F70_Form01 As New F70_Form01
        '    F70_Form01.ShowDialog()
        'End If
    End Sub

    '********************************************************************
    '**  àÛç¸Åiî[ïièëÅAëóÇËèÛÅAÇbÇbÇ`ÇqÅj
    '********************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        CHG_CHK()   '**  ïœçXâ”èäÉ`ÉFÉbÉN
        If CHG_F = "1" Then
            msg.Text = "ïœçXâ”èäÇ™Ç†ÇËÇ‹Ç∑ÅBçXêVå„àÛç¸ÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB"
            Exit Sub
        End If

        P_PRAM1 = Edit000.Text  'éÛïtî‘çÜ
        P_PRAM2 = Edit002.Text  'î[ì¸êÊ
        If Button1.Enabled = False Then P_PRAM3 = "1" Else P_PRAM3 = "0" 'ÉvÉçÉeÉNÉg
        P_RTN = "0"

        Dim F00_Form07 As New F00_Form07
        F00_Form07.ShowDialog()

        'If P_RTN <> "0" Then
        rep_sql()   '** èCóùèÓïÒÇfÇdÇs(SQL)
        Dim WK_i As Integer = 0
        Combo006.Items.Clear()
        If Not IsDBNull(DtView3(0)("sals_no")) Then Combo006.Items.Add(DtView3(0)("sals_no")) : Combo006.Text = DtView3(0)("sals_no") : WK_i = 1
        If Not IsDBNull(DtView3(0)("sals_no2")) Then Combo006.Items.Add(DtView3(0)("sals_no2")) : WK_i = WK_i + 1
        Combo006.Enabled = True
        If WK_i > 1 Then
            Combo006.DropDown.Visible = GrapeCity.Win.Input.Interop.Visibility.ShowAlways
        Else
            Combo006.DropDown.Visible = GrapeCity.Win.Input.Interop.Visibility.NotShown
        End If
        If Not IsDBNull(DtView3(0)("sals_date")) Then Date011.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("sals_date")) Else Date011.Text = Nothing
        If Not IsDBNull(DtView3(0)("ship_date")) Then Date012.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("ship_date")) Else Date012.Text = Nothing
        If Not IsDBNull(DtView3(0)("rqst_date")) Then Date013.Text = DtView3(0)("rqst_date") Else Date013.Text = Nothing
        If Not IsDBNull(DtView3(0)("rebate")) Then rebate.Value = DtView3(0)("rebate") Else rebate.Value = 0
        If Not IsDBNull(DtView3(0)("idvd_chrg")) Then idvd_chrg.Value = DtView3(0)("idvd_chrg") Else idvd_chrg.Value = 0
        If Not IsDBNull(DtView3(0)("sals_amnt1")) Then NumberN011.Value = DtView3(0)("sals_amnt1") Else NumberN011.Value = 0
        If Not IsDBNull(DtView3(0)("sals_amnt2")) Then NumberN012.Value = DtView3(0)("sals_amnt2") Else NumberN012.Value = 0
        If Not IsDBNull(DtView3(0)("sals_amnt3")) Then NumberN013.Value = DtView3(0)("sals_amnt3") Else NumberN013.Value = 0
        If Not IsDBNull(DtView3(0)("sals_amnt5")) Then NumberN015.Value = DtView3(0)("sals_amnt5") Else NumberN015.Value = 0
        'End If
    End Sub

    '********************************************************************
    '**  ñ‚çáÇπ
    '********************************************************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Edit000.Text

        Dim F00_Form10 As New F00_Form10
        F00_Form10.ShowDialog()

        Call CONTACT_GET(Edit000.Text)
        cntact1.Text = P1_CONTACT
        cntact2.Text = P2_CONTACT
        If P3_CONTACT = "True" Then CheckBox1.Checked = True Else CheckBox1.Checked = False

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ê‘ì`ì¸óÕ
    '********************************************************************
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Edit000.Text
        P_PRAM2 = GRP.Text
        P_PRAM3 = CL001.Text

        Dim F00_Form14 As New F00_Form14
        F00_Form14.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ÉRÉìÉ^ÉNÉgÉçÉO
    '********************************************************************
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Edit000.Text

        Dim F00_Form16 As New F00_Form16
        F00_Form16.ShowDialog()

        Call CONTACT_GET(Edit000.Text)
        cntact1.Text = P1_CONTACT
        cntact2.Text = P2_CONTACT
        If P3_CONTACT = "True" Then CheckBox1.Checked = True Else CheckBox1.Checked = False

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ï Noè∆âÔ
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_search.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("ãNìÆÇ≈Ç´Ç‹ÇπÇÒÇ≈ÇµÇΩ", "ÉGÉâÅ[í ím")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  s/n óöó
    '********************************************************************
    Private Sub Button97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button97.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim F00_Form17 As New F00_Form17
        F00_Form17.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  óöó
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'ïœçXóöó
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L01_HSTY", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ñﬂÇÈ
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        If Button1.Enabled = True Then
            CHG_CHK()   '**  ïœçXâ”èäÉ`ÉFÉbÉN
            If CHG_F = "1" Then
                ANS = MessageBox.Show("ïœçXâ”èäÇ™Ç†ÇËÇ‹Ç∑ÅBèIóπÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then Exit Sub 'Ç¢Ç¢Ç¶
            End If
            HAITA_OFF(Edit000.Text)  'HAITA_OFF
        End If
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB.Clear()
        P_Ds_sn.Clear()
        Close()
    End Sub

    Private Sub CkBox01_Y_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_Y.CheckedChanged
        If CkBox01_Y.Checked = True Then
            CkBox01_N.Checked = False
            'Else
            '    CkBox01_N.Checked = True
        End If
    End Sub

    Private Sub CkBox01_N_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_N.CheckedChanged
        If CkBox01_N.Checked = True Then
            CkBox01_Y.Checked = False
            'Else
            '    CkBox01_Y.Checked = True
        End If
    End Sub

    Private Sub Date016_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date016.TextChanged
        If inz_F = "1" Then
            If Date016.Number <> 0 Then
                If Format(CDate(Date016.Text), "HH:mm") = "00:00" Then
                    Date016.Text = Format(CDate(Date016.Text), "yyyy/MM/dd") & " " & Format(Now, "HH:mm")
                End If
            End If
        End If
    End Sub

    Private Sub Date017_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date017.TextChanged
        If inz_F = "1" Then
            If Date017.Number <> 0 Then
                If Format(CDate(Date017.Text), "HH:mm") = "00:00" Then
                    Date017.Text = Format(CDate(Date017.Text), "yyyy/MM/dd") & " " & Format(Now, "HH:mm")
                End If
            End If
        End If
    End Sub

    Private Sub Date010_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date010.TextChanged
        If inz_F = "1" Then
            If Date010.Number <> 0 Then
                If Format(CDate(Date010.Text), "HH:mm") = "00:00" Then
                    Date010.Text = Format(CDate(Date010.Text), "yyyy/MM/dd") & " " & Format(Now, "HH:mm")
                End If
            End If
        End If
    End Sub

    Private Sub Date011_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date011.TextChanged
        If inz_F = "1" Then
            If Date011.Number <> 0 Then
                If Format(CDate(Date011.Text), "HH:mm") = "00:00" Then
                    Date011.Text = Format(CDate(Date011.Text), "yyyy/MM/dd") & " " & Format(Now, "HH:mm")
                End If
            End If
        End If
    End Sub

    Private Sub Date012_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date012.TextChanged
        If inz_F = "1" Then
            If Date012.Number <> 0 Then
                If Format(CDate(Date012.Text), "HH:mm") = "00:00" Then
                    Date012.Text = Format(CDate(Date012.Text), "yyyy/MM/dd") & " " & Format(Now, "HH:mm")
                End If
            End If
        End If
    End Sub

    '********************************************************************
    '**  àÍéûï€ë∂
    '********************************************************************
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        ANS = MessageBox.Show("àÍéûï€ë∂ÇçsÇ¢Ç‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        If ANS = "1" Then  'OK
            NoDsp_Null()

            'éÛït
            WK_DsList1.Clear()
            strSQL = "SELECT rcpt_no, mitumori_kanryou FROM T61_temp_REP_MTR WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'K')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(WK_DsList1, "T61_temp_REP_MTR")
            DB_CLOSE()

            If r = 0 Then
                strSQL = "INSERT INTO T61_temp_REP_MTR (rcpt_no, mitumori_kanryou, fin_ent_empl_code, orgnl_vndr_code, recv_amnt, repr_empl_code, repr_brch_code, m_tech_seq, comp_meas, comp_comn, comp_cost_tech_chrg, comp_cost_apes, comp_cost_part_chrg, comp_cost_fee, comp_cost_pstg, comp_cost_ttl, comp_cost_tax, comp_shop_tech_chrg, comp_shop_apes, comp_shop_part_chrg, comp_shop_fee, comp_shop_pstg, comp_shop_ttl, comp_shop_tax, comp_eu_tech_chrg, comp_eu_apes, comp_eu_part_chrg, comp_eu_fee, comp_eu_pstg, comp_eu_ttl, comp_eu_tax, tech_rate1, fix1, tech_rate2, part_rate2, rsrv_cacl_date, part_ordr_date, part_rcpt_date, comp_date, sals_date, ship_date, sindan_date, rep_date, renraku_date, zero_code, zero_name, rebate, idvd_chrg, re_rpar_date, comp_sum_flg, apple_Dlvy_rep_flg, kjo_brch_code, payment_type, sb_imei_new, kashitsu_flg)"
                strSQL += " VALUES ('" & Edit000.Text & "'"    'rcpt_no
                strSQL += ", 'K'"    'mitumori_kanryou
                strSQL += ", " & P_EMPL_NO    'fin_ent_empl_code
                strSQL += ", '" & Edit012.Text & "'"    'orgnl_vndr_code
                strSQL += ", " & Number002.Value    'recv_amnt
                If CLK001.Text <> "" Then strSQL += ", " & CLK001.Text Else strSQL += ", NULL" 'repr_empl_code
                strSQL += ", '" & CLK001_BRH.Text & "'"    'repr_brch_code
                If Combo_K002.Visible = True Then strSQL += ", " & CLK002.Text Else strSQL += ", NULL" 'm_tech_seq
                strSQL += ", '" & Edit_K001.Text & "'"    'comp_meas
                strSQL += ", '" & Edit_K002.Text & "'"    'comp_comn
                strSQL += ", " & Number131.Value    'comp_cost_tech_chrg
                strSQL += ", " & Number132.Value    'comp_cost_apes
                strSQL += ", " & Number133.Value    'comp_cost_part_chrg
                strSQL += ", " & Number134.Value    'comp_cost_fee"
                strSQL += ", " & Number135.Value    'comp_cost_pstg
                strSQL += ", " & Number136.Value    'comp_cost_ttl
                strSQL += ", " & Number137.Value    'comp_cost_tax
                strSQL += ", " & Number111.Value    'comp_shop_tech_chrg
                strSQL += ", " & Number112.Value    'comp_shop_apes
                strSQL += ", " & Number113.Value    'comp_shop_part_chrg
                strSQL += ", " & Number114.Value    'comp_shop_fee
                strSQL += ", " & Number115.Value    'comp_shop_pstg
                strSQL += ", " & Number116.Value    'comp_shop_ttl
                strSQL += ", " & Number117.Value    'comp_shop_tax
                strSQL += ", " & Number121.Value    'comp_eu_tech_chrg
                strSQL += ", " & Number122.Value    'comp_eu_apes
                strSQL += ", " & Number123.Value    'comp_eu_part_chrg
                strSQL += ", " & Number124.Value    'comp_eu_fee
                strSQL += ", " & Number125.Value    'comp_eu_pstg
                strSQL += ", " & Number126.Value    'comp_eu_ttl
                strSQL += ", " & Number127.Value    'comp_eu_tax
                strSQL += ", " & NumberN003.Value    'tech_rate1
                strSQL += ", " & NumberN006.Value    'fix1
                strSQL += ", " & NumberN007.Value    'tech_rate2
                strSQL += ", " & NumberN008.Value    'part_rate2
                If Date006.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date006.Text & "', 102)" Else strSQL += ", NULL" 'rsrv_cacl_date
                If Date007.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date007.Text & "', 102)" Else strSQL += ", NULL" 'part_ordr_date
                If Date008.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date008.Text & "', 102)" Else strSQL += ", NULL" 'part_rcpt_date
                If Date010.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date010.Text & "', 102)" Else strSQL += ", NULL" 'comp_date
                If Date011.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date011.Text & "', 102)" Else strSQL += ", NULL" 'sals_date
                If Date012.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date012.Text & "', 102)" Else strSQL += ", NULL" 'ship_date
                If Date015.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date015.Text & "', 102)" Else strSQL += ", NULL" 'sindan_date
                If Date016.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date016.Text & "', 102)" Else strSQL += ", NULL" 'rep_date
                If Date017.Number <> 0 Then strSQL += ", CONVERT(DATETIME, '" & Date017.Text & "', 102)" Else strSQL += ", NULL" 'renraku_date
                strSQL += ", '" & zero_code.Text & "'"    'zero_code
                strSQL += ", '" & zero_name.Text & "'"    'zero_name
                strSQL += ", " & rebate.Value    'rebate
                strSQL += ", " & idvd_chrg.Value    'idvd_chrg
                If Date010.Number <> 0 Then strSQL += ", '" & DateAdd(DateInterval.Day, NumberN009.Value, CDate(Date010.Text)) & "'" Else strSQL += ", NULL" 're_rpar_date
                If CheckBox_K001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" 'comp_sum_flg
                If CheckBox_K002.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" 'apple_Dlvy_rep_flg
                strSQL += ", '" & CLK003.Text & "'"    'kjo_brch_code
                strSQL += ", '" & CLK004.Text & "'"    'payment_type
                strSQL += ", '" & Edit_K003.Text & "'"    'sb_imei_new
                If CkBox01_Y.Checked = True Then
                    strSQL += ", 1"    'kashitsu_flg
                Else
                    If CkBox01_N.Checked = True Then
                        strSQL += ", 0"    'kashitsu_flg
                    Else
                        strSQL += ", NULL"    'kashitsu_flg
                    End If
                End If
                strSQL += ")"
            Else
                strSQL = "UPDATE T61_temp_REP_MTR"
                strSQL += " SET fin_ent_empl_code = " & P_EMPL_NO
                strSQL += ", orgnl_vndr_code = '" & Edit012.Text & "'"
                strSQL += ", recv_amnt = " & Number002.Value
                If CLK001.Text <> "" Then strSQL += ", repr_empl_code = " & CLK001.Text Else strSQL += ", repr_empl_code = NULL"
                strSQL += ", repr_brch_code = '" & CLK001_BRH.Text & "'"
                If Combo_K002.Visible = True Then strSQL += ", m_tech_seq = " & CLK002.Text Else strSQL += ", m_tech_seq = NULL"
                strSQL += ", comp_meas = '" & Edit_K001.Text & "'"
                strSQL += ", comp_comn = '" & Edit_K002.Text & "'"
                strSQL += ", comp_cost_tech_chrg = " & Number131.Value
                strSQL += ", comp_cost_apes = " & Number132.Value
                strSQL += ", comp_cost_part_chrg = " & Number133.Value
                strSQL += ", comp_cost_fee = " & Number134.Value
                strSQL += ", comp_cost_pstg = " & Number135.Value
                strSQL += ", comp_cost_ttl = " & Number136.Value
                strSQL += ", comp_cost_tax = " & Number137.Value

                strSQL += ", comp_shop_tech_chrg = " & Number111.Value
                strSQL += ", comp_shop_apes = " & Number112.Value
                strSQL += ", comp_shop_part_chrg = " & Number113.Value
                strSQL += ", comp_shop_fee = " & Number114.Value
                strSQL += ", comp_shop_pstg = " & Number115.Value
                strSQL += ", comp_shop_ttl = " & Number116.Value
                strSQL += ", comp_shop_tax = " & Number117.Value

                strSQL += ", comp_eu_tech_chrg = " & Number121.Value
                strSQL += ", comp_eu_apes = " & Number122.Value
                strSQL += ", comp_eu_part_chrg = " & Number123.Value
                strSQL += ", comp_eu_fee = " & Number124.Value
                strSQL += ", comp_eu_pstg = " & Number125.Value
                strSQL += ", comp_eu_ttl = " & Number126.Value
                strSQL += ", comp_eu_tax = " & Number127.Value

                strSQL += ", tech_rate1 = " & NumberN003.Value
                strSQL += ", fix1 = " & NumberN006.Value
                strSQL += ", tech_rate2 = " & NumberN007.Value
                strSQL += ", part_rate2 = " & NumberN008.Value

                If Date006.Number <> 0 Then strSQL += ", rsrv_cacl_date = '" & Date006.Text & "'" Else strSQL += ", rsrv_cacl_date = NULL"
                If Date007.Number <> 0 Then strSQL += ", part_ordr_date = '" & Date007.Text & "'" Else strSQL += ", part_ordr_date = NULL"
                If Date008.Number <> 0 Then strSQL += ", part_rcpt_date = '" & Date008.Text & "'" Else strSQL += ", part_rcpt_date = NULL"
                If Date010.Number <> 0 Then strSQL += ", comp_date = '" & Date010.Text & "'" Else strSQL += ", comp_date = NULL"
                If Date011.Number <> 0 Then strSQL += ", sals_date = '" & Date011.Text & "'" Else strSQL += ", sals_date = NULL"
                If Date012.Number <> 0 Then strSQL += ", ship_date = '" & Date012.Text & "'" Else strSQL += ", ship_date = NULL"
                If Date015.Number <> 0 Then strSQL += ", sindan_date = '" & Date015.Text & "'" Else strSQL += ", sindan_date = NULL"
                If Date016.Number <> 0 Then strSQL += ", rep_date = '" & Date016.Text & "'" Else strSQL += ", rep_date = NULL"
                If Date017.Number <> 0 Then strSQL += ", renraku_date = '" & Date017.Text & "'" Else strSQL += ", renraku_date = NULL"
                strSQL += ", zero_code = '" & zero_code.Text & "'"
                strSQL += ", zero_name = '" & zero_name.Text & "'"
                strSQL += ", rebate = " & rebate.Value & ""
                strSQL += ", idvd_chrg = " & idvd_chrg.Value & ""
                If Date010.Number <> 0 Then
                    strSQL += ", re_rpar_date = '" & DateAdd(DateInterval.Day, NumberN009.Value, CDate(Date010.Text)) & "'"
                Else
                    strSQL += ", re_rpar_date = NULL"
                End If
                If CheckBox_K001.Checked = True Then strSQL += ", comp_sum_flg = '1'" Else strSQL += ", comp_sum_flg = '0'"
                If CheckBox_K002.Checked = True Then strSQL += ", apple_Dlvy_rep_flg = '1'" Else strSQL += ", apple_Dlvy_rep_flg = '0'"
                strSQL += ", kjo_brch_code = '" & CLK003.Text & "'"
                strSQL += ", payment_type = '" & CLK004.Text & "'"
                strSQL += ", sb_imei_new = '" & Edit_K003.Text & "'"
                If CkBox01_Y.Checked = True Then
                    strSQL += ", kashitsu_flg = 1"
                Else
                    If CkBox01_N.Checked = True Then
                        strSQL += ", kashitsu_flg = 0"
                    Else
                        strSQL += ", kashitsu_flg = NULL"
                    End If
                End If
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                strSQL += " AND (mitumori_kanryou = 'K')"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()


            'èCóùì‡óe
            WK_DsList1.Clear()
            strSQL = "SELECT MAX(seq) AS max_seq FROM T03_REP_CMNT WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '3')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "T02_ATCH_ITEM")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("T02_ATCH_ITEM"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                seq = 0
            Else
                If Not IsDBNull(WK_DtView1(0)("max_seq")) Then
                    seq = WK_DtView1(0)("max_seq")
                Else
                    seq = 0
                End If
            End If

            'çÌèú
            strSQL = "DELETE FROM T63_temp_REP_CMNT"
            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'K') "
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            For i = 0 To Line_No4
                If label_4(i, 2).Text = Nothing Then
                    seq = seq + 1
                    WK_seq = seq
                Else
                    WK_seq = label_4(i, 2).Text
                End If
                If cmbBo_4(i, 1).Text <> Nothing Then
                    'í«â¡

                    strSQL = "INSERT INTO T63_temp_REP_CMNT"
                    strSQL += " (rcpt_no, kbn, seq, mitumori_kanryou, cls_code1, cmnt_code1)"
                    strSQL += " VALUES ('" & Edit000.Text & "'"
                    strSQL += ", '3'"
                    strSQL += ", " & WK_seq
                    strSQL += ", 'K'"
                    strSQL += ", '21'"
                    strSQL += ", '" & label_4(i, 1).Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN("nMVAR")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                End If
            Next

            'ïîïi
            'çÌèú
            strSQL = "DELETE FROM T64_temp_REP_PART"
            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (mitumori_kanryou = 'K')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            For i = 0 To 1000
                WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)

                If WK_DtView1.Count = 0 Then
                    If WK_DtView2.Count = 0 Then
                        Exit For
                    End If
                Else
                    If IsDBNull(WK_DtView1(0)("ibm_flg")) Then WK_DtView1(0)("ibm_flg") = "False"
                    If IsDBNull(WK_DtView1(0)("exp_flg")) Then WK_DtView1(0)("exp_flg") = "False"
                    'í«â¡
                    strSQL = "INSERT INTO T64_temp_REP_PART"
                    strSQL += " (rcpt_no, kbn, seq, mitumori_kanryou, part_code, part_name, part_amnt, use_qty, cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, s_n, ibm_flg, exp_flg)"
                    strSQL += " VALUES ('" & Edit000.Text & "'"
                    strSQL += ", '2'"
                    strSQL += ", " & WK_DtView1(0)("seq")
                    strSQL += ", 'K'"
                    strSQL += ", '" & WK_DtView1(0)("part_code") & "'"
                    strSQL += ", '" & WK_DtView1(0)("part_name") & "'"
                    strSQL += ", " & WK_DtView1(0)("part_amnt") & ""
                    strSQL += ", " & WK_DtView1(0)("use_qty") & ""
                    strSQL += ", " & WK_DtView1(0)("cost_chrg") & ""
                    strSQL += ", " & WK_DtView1(0)("shop_chrg") & ""
                    strSQL += ", " & WK_DtView1(0)("eu_chrg") & ""
                    strSQL += ", '" & WK_DtView1(0)("ordr_no") & "'"
                    strSQL += ", '" & WK_DtView1(0)("ordr_no2") & "'"
                    strSQL += ", '" & WK_DtView1(0)("s_n") & "'"
                    If WK_DtView1(0)("ibm_flg") = "True" Then strSQL += ", 1" Else strSQL += ", 0"
                    If WK_DtView1(0)("exp_flg") = "True" Then strSQL += ", 1)" Else strSQL += ", 0)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN("nMVAR")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                End If
            Next

            msg.Text = "àÍéûï€ë∂ÇµÇ‹ÇµÇΩÅB"
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub temp_set()

        WK_DsList4.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_T61_temp_REP_MTR_K", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram2.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        r = DaList1.Fill(WK_DsList4, "T61_temp_REP_MTR_M")
        DB_CLOSE()
        WK_DtView4 = New DataView(WK_DsList4.Tables("T61_temp_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

        If r <> 0 Then

            Edit012.Text = WK_DtView4(0)("orgnl_vndr_code")
            If Not IsDBNull(WK_DtView4(0)("recv_amnt")) Then Number002.Value = WK_DtView4(0)("recv_amnt") Else Number002.Value = 0
            If Not IsDBNull(WK_DtView4(0)("repr_empl_code")) Then CLK001.Text = WK_DtView4(0)("repr_empl_code") Else CLK001.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("repr_empl_name")) Then Combo_K001.Text = WK_DtView4(0)("repr_empl_name") Else Combo_K001.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("repr_brch_code")) Then CLK001_BRH.Text = WK_DtView4(0)("repr_brch_code") Else CLK001_BRH.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("m_tech_seq")) Then CLK002.Text = WK_DtView4(0)("m_tech_seq") Else CLK002.Text = Nothing
            If Not IsDBNull(DtView3(0)("select_case")) Then Combo_K002.Text = DtView3(0)("select_case") Else Combo_K002.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("comp_meas")) Then Edit_K001.Text = WK_DtView4(0)("comp_meas") Else Edit_K001.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("comp_comn")) Then Edit_K002.Text = WK_DtView4(0)("comp_comn") Else Edit_K002.Text = Nothing

            If Not IsDBNull(WK_DtView4(0)("comp_cost_tech_chrg")) Then Number131.Value = WK_DtView4(0)("comp_cost_tech_chrg") Else Number131.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_cost_apes")) Then Number132.Value = WK_DtView4(0)("comp_cost_apes") Else Number132.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_cost_part_chrg")) Then Number133.Value = WK_DtView4(0)("comp_cost_part_chrg") Else Number133.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_cost_fee")) Then Number134.Value = WK_DtView4(0)("comp_cost_fee") Else Number134.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_cost_pstg")) Then Number135.Value = WK_DtView4(0)("comp_cost_pstg") Else Number135.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_cost_tax")) Then Number137.Value = WK_DtView4(0)("comp_cost_tax") Else Number137.Value = 0
            If CK_own_flg.Checked = False Then Number132.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_cost_ttl")) Then
                Number136.Value = WK_DtView4(0)("comp_cost_ttl")
            Else
                Number136.Value = Number131.Value + Number132.Value + Number133.Value + Number134.Value + Number135.Value
            End If
            Number138.Value = Number136.Value + Number137.Value

            If Not IsDBNull(WK_DtView4(0)("comp_shop_tech_chrg")) Then Number111.Value = WK_DtView4(0)("comp_shop_tech_chrg") Else Number111.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_shop_apes")) Then Number112.Value = WK_DtView4(0)("comp_shop_apes") Else Number112.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_shop_part_chrg")) Then Number113.Value = WK_DtView4(0)("comp_shop_part_chrg") Else Number113.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_shop_fee")) Then Number114.Value = WK_DtView4(0)("comp_shop_fee") Else Number114.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_shop_pstg")) Then Number115.Value = WK_DtView4(0)("comp_shop_pstg") Else Number115.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_shop_tax")) Then Number117.Value = WK_DtView4(0)("comp_shop_tax") Else Number117.Value = 0
            If CK_own_flg.Checked = False Then Number112.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_shop_ttl")) Then
                Number116.Value = WK_DtView4(0)("comp_shop_ttl")
            Else
                Number116.Value = Number111.Value + Number112.Value + Number113.Value + Number114.Value + Number115.Value
            End If
            Number118.Value = Number116.Value + Number117.Value

            If Not IsDBNull(WK_DtView4(0)("comp_eu_tech_chrg")) Then Number121.Value = WK_DtView4(0)("comp_eu_tech_chrg") Else Number121.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_eu_apes")) Then Number122.Value = WK_DtView4(0)("comp_eu_apes") Else Number122.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_eu_part_chrg")) Then Number123.Value = WK_DtView4(0)("comp_eu_part_chrg") Else Number123.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_eu_fee")) Then Number124.Value = WK_DtView4(0)("comp_eu_fee") Else Number124.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_eu_pstg")) Then Number125.Value = WK_DtView4(0)("comp_eu_pstg") Else Number125.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_eu_tax")) Then Number127.Value = WK_DtView4(0)("comp_eu_tax") Else Number127.Value = 0
            If Not IsDBNull(WK_DtView4(0)("comp_eu_ttl")) Then
                Number126.Value = WK_DtView4(0)("comp_eu_ttl")
            Else
                Number126.Value = Number121.Value + Number123.Value + Number124.Value + Number125.Value
            End If
            Number128.Value = Number126.Value + Number127.Value

            If Not IsDBNull(WK_DtView4(0)("tech_rate1")) Then NumberN003.Value = WK_DtView4(0)("tech_rate1") Else NumberN003.Value = 0
            If Not IsDBNull(WK_DtView4(0)("tech_rate2")) Then NumberN007.Value = WK_DtView4(0)("tech_rate2") Else NumberN007.Value = 0
            If Not IsDBNull(WK_DtView4(0)("part_rate2")) Then NumberN008.Value = WK_DtView4(0)("part_rate2") Else NumberN008.Value = 0
            If Not IsDBNull(WK_DtView4(0)("fix1")) Then NumberN006.Value = WK_DtView4(0)("fix1") Else NumberN006.Value = 0

            If Not IsDBNull(WK_DtView4(0)("rsrv_cacl_date")) Then Date006.Text = WK_DtView4(0)("rsrv_cacl_date")
            If Not IsDBNull(WK_DtView4(0)("part_ordr_date")) Then Date007.Text = WK_DtView4(0)("part_ordr_date")
            If Not IsDBNull(WK_DtView4(0)("part_rcpt_date")) Then Date008.Text = Format(CDate(WK_DtView4(0)("part_rcpt_date")), "yyyy/MM/dd")
            If Not IsDBNull(WK_DtView4(0)("comp_date")) Then Date010.Text = String.Format("{0:yyyy/MM/dd HH:mm}", WK_DtView4(0)("comp_date"))
            If Not IsDBNull(WK_DtView4(0)("sals_date")) Then Date011.Text = String.Format("{0:yyyy/MM/dd HH:mm}", WK_DtView4(0)("sals_date"))
            If Not IsDBNull(WK_DtView4(0)("ship_date")) Then Date012.Text = String.Format("{0:yyyy/MM/dd HH:mm}", WK_DtView4(0)("ship_date"))
            If Not IsDBNull(WK_DtView4(0)("sindan_date")) Then Date015.Text = String.Format("{0:yyyy/MM/dd HH:mm}", WK_DtView4(0)("sindan_date"))
            If Not IsDBNull(WK_DtView4(0)("rep_date")) Then Date016.Text = String.Format("{0:yyyy/MM/dd HH:mm}", WK_DtView4(0)("rep_date"))
            If Not IsDBNull(WK_DtView4(0)("renraku_date")) Then Date017.Text = String.Format("{0:yyyy/MM/dd HH:mm}", WK_DtView4(0)("renraku_date"))

            If Not IsDBNull(WK_DtView4(0)("zero_code")) Then zero_code.Text = WK_DtView4(0)("zero_code")
            If Not IsDBNull(WK_DtView4(0)("zero_name")) Then zero_name.Text = WK_DtView4(0)("zero_name")
            If Not IsDBNull(WK_DtView4(0)("rebate")) Then rebate.Value = WK_DtView4(0)("rebate")
            If Not IsDBNull(WK_DtView4(0)("idvd_chrg")) Then idvd_chrg.Value = WK_DtView4(0)("idvd_chrg")

            If Not IsDBNull(WK_DtView4(0)("sals_amnt1")) Then NumberN011.Value = WK_DtView4(0)("sals_amnt1")
            If Not IsDBNull(WK_DtView4(0)("sals_amnt2")) Then NumberN012.Value = WK_DtView4(0)("sals_amnt2")
            If Not IsDBNull(WK_DtView4(0)("sals_amnt3")) Then NumberN013.Value = WK_DtView4(0)("sals_amnt3")
            If Not IsDBNull(WK_DtView4(0)("sals_amnt5")) Then NumberN015.Value = WK_DtView4(0)("sals_amnt5")

            If IsDBNull(WK_DtView4(0)("comp_sum_flg")) Then
                CheckBox_K001.Checked = False
            Else
                If WK_DtView4(0)("comp_sum_flg") = "False" Then
                    CheckBox_K001.Checked = False
                Else
                    CheckBox_K001.Checked = True
                End If
            End If
            If IsDBNull(WK_DtView4(0)("apple_Dlvy_rep_flg")) Then
                CheckBox_K002.Checked = False
            Else
                If WK_DtView4(0)("apple_Dlvy_rep_flg") = "False" Then
                    CheckBox_K002.Checked = False
                Else
                    CheckBox_K002.Checked = True
                End If
            End If

            If Not IsDBNull(WK_DtView4(0)("kjo_brch_code")) Then
                CLK003.Text = WK_DtView4(0)("kjo_brch_code")
                If Not IsDBNull(WK_DtView4(0)("kjo_brch_name")) Then Combo_K003.Text = WK_DtView4(0)("kjo_brch_name")
            Else
                'comment prabu 2021-04-09
                'If CK_own_flg.Checked = True Then   'é©é–èCóù
                '    CLK003.Text = WK_DtView4(0)("brch_code")
                'Else
                '    CLK003.Text = WK_DtView4(0)("rcpt_brch_code")
                'End If
                WK_DtView1 = New DataView(DsCMB3.Tables("M03_BRCH"), "brch_code = '" & CLK003.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Combo_K003.Text = WK_DtView1(0)("brch_name")
                End If
                'prabu Add 2021-04-09
                If CK_own_flg.Checked = True Then   'é©é–èCóù
                    CLK003.Text = WK_DtView1(0)("brch_code")
                Else
                    CLK003.Text = WK_DtView4(0)("rcpt_brch_code")
                End If
                'end prabu
            End If

            If Not IsDBNull(WK_DtView4(0)("payment_type")) Then
                CLK004.Text = WK_DtView4(0)("payment_type")
                If Not IsDBNull(WK_DtView4(0)("payment_type_name")) Then Combo_K004.Text = WK_DtView4(0)("payment_type_name")
            End If

            If Not IsDBNull(WK_DtView4(0)("sb_imei_new")) Then Edit_K003.Text = WK_DtView4(0)("sb_imei_new")
            If Not IsDBNull(WK_DtView4(0)("kashitsu_flg")) Then
                If WK_DtView4(0)("kashitsu_flg") = "1" Then
                    CkBox01_Y.Checked = True
                Else
                    CkBox01_N.Checked = True
                End If
            End If


            'èCóùì‡óe
            WK_DsList4.Clear()
            strSQL = "SELECT T03_REP_CMNT.seq"
            strSQL += " FROM T03_REP_CMNT LEFT OUTER JOIN"
            strSQL += " T63_temp_REP_CMNT ON T03_REP_CMNT.rcpt_no = T63_temp_REP_CMNT.rcpt_no AND "
            strSQL += " T03_REP_CMNT.kbn = T63_temp_REP_CMNT.kbn AND T03_REP_CMNT.seq = T63_temp_REP_CMNT.seq"
            strSQL += " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
            strSQL += " AND (T03_REP_CMNT.kbn = '3')"
            strSQL += " AND (T63_temp_REP_CMNT.rcpt_no IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(WK_DsList4, "T03_REP_CMNT_CLR")
            DB_CLOSE()
            If r > 0 Then
                WK_DtView4 = New DataView(WK_DsList4.Tables("T03_REP_CMNT_CLR"), "", "", DataViewRowState.CurrentRows)
                For j = 0 To WK_DtView4.Count - 1
                    For i = 0 To Line_No3 - 1
                        If label_3(i, 2).Text = WK_DtView4(j)("seq") Then
                            cmbBo_3(i, 1).Text = Nothing
                        End If
                    Next
                Next
            End If

            Dim wk_line As Integer = 0

            strSQL = "SELECT T63_temp_REP_CMNT.seq, T63_temp_REP_CMNT.cls_code1, T63_temp_REP_CMNT.cmnt_code1"
            strSQL += ", T63_temp_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
            strSQL += ", T03_REP_CMNT.cls_code1 AS cls_code2, T03_REP_CMNT.cmnt_code1 AS cmnt_code2"
            strSQL += " FROM T63_temp_REP_CMNT LEFT OUTER JOIN"
            strSQL += " T03_REP_CMNT ON T63_temp_REP_CMNT.rcpt_no = T03_REP_CMNT.rcpt_no AND"
            strSQL += " T63_temp_REP_CMNT.kbn = T03_REP_CMNT.kbn AND T63_temp_REP_CMNT.seq = T03_REP_CMNT.seq LEFT OUTER JOIN"
            strSQL += " M10_CMNT ON T63_temp_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND "
            strSQL += " T63_temp_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
            strSQL += " WHERE (T63_temp_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
            strSQL += " AND (T63_temp_REP_CMNT.kbn = '3')"
            strSQL += " AND (T63_temp_REP_CMNT.mitumori_kanryou = 'K')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(WK_DsList4, "T63_temp_REP_CMNT")
            DB_CLOSE()
            If r > 0 Then
                WK_DtView4 = New DataView(WK_DsList4.Tables("T63_temp_REP_CMNT"), "", "", DataViewRowState.CurrentRows)
                For j = 0 To WK_DtView4.Count - 1
                    If Not IsDBNull(WK_DtView4(j)("cmnt_code2")) Then
                        If WK_DtView4(j)("cmnt_code1") <> WK_DtView4(j)("cmnt_code2") Then
                            For i = 0 To Line_No4 - 1
                                If label_4(i, 2).Text = WK_DtView4(j)("seq") Then
                                    cmbBo_4(i, 1).Text = WK_DtView4(j)("cmnt_name1")
                                    label_4(i, 1).Text = WK_DtView4(j)("cmnt_code1")
                                End If
                            Next
                        End If
                    Else
                        If wk_line = 0 Then
                            If Line_No4 = 0 Then
                                wk_line = Line_No4
                                cmbBo_4(wk_line, 1).Text = WK_DtView4(j)("cmnt_name1")
                                label_4(wk_line, 1).Text = WK_DtView4(j)("cmnt_code1")
                                wk_line = wk_line + 1
                            Else
                                Line_No4 = Line_No4 + 1
                                wk_line = Line_No4
                                add_line_4_2(wk_line, WK_DtView4(j)("cmnt_name1"), WK_DtView4(j)("cmnt_code1"))  'èCóùì‡óe
                            End If
                        Else
                            Line_No4 = Line_No4 + 1
                            wk_line = Line_No4
                            add_line_4_2(wk_line, WK_DtView4(j)("cmnt_name1"), WK_DtView4(j)("cmnt_code1"))  'èCóùì‡óe
                        End If
                    End If
                Next
                If wk_line <> 0 Then
                    add_line_4("0")    'å©êœì‡óe
                End If
            End If

            'ïîïi
            WK_DsList4.Clear()
            strSQL = "SELECT seq"
            strSQL += " FROM T64_temp_REP_PART"
            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (mitumori_kanryou = 'K')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(WK_DsList4, "T64_temp_REP_PART")
            DB_CLOSE()
            If r <> 0 Then

                P_DsList1.Tables("T04_REP_PART_2").Clear()
                SqlCmd1 = New SqlClient.SqlCommand("sp_T64_temp_REP_PART", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 1)
                Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 1)
                Pram3.Value = Edit000.Text
                Pram4.Value = "2"
                Pram5.Value = "K"
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(P_DsList1, "T04_REP_PART_2")
                DB_CLOSE()

                strSQL = "SELECT seq"
                strSQL += " FROM T04_REP_PART"
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2')"
                strSQL += " UNION"
                strSQL += " SELECT seq"
                strSQL += " FROM T64_temp_REP_PART"
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (mitumori_kanryou = 'K')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList4, "SEQ")
                DB_CLOSE()
                WK_DtView4 = New DataView(WK_DsList4.Tables("SEQ"), "", "", DataViewRowState.CurrentRows)
                j = -1
                For i = 0 To WK_DtView4.Count - 1

                    WK_DtView5 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "SEQ=" & WK_DtView4(i)("SEQ"), "", DataViewRowState.CurrentRows)
                    If WK_DtView5.Count <> 0 Then
                        WK_DtView5(0)("ID_NO") = i
                        WK_DtView6 = New DataView(DsList1.Tables("T04_REP_PART_MOTO_2"), "SEQ=" & WK_DtView4(i)("SEQ"), "", DataViewRowState.CurrentRows)
                        If WK_DtView6.Count = 0 Then
                            WK_DtView5(0)("rcpt_no") = DBNull.Value
                            WK_DtView5(0)("kbn") = DBNull.Value
                        End If
                    End If

                Next

            End If

            Dim tbl2 As New DataTable
            tbl2 = P_DsList1.Tables("T04_REP_PART_2")
            DataGrid_K1.DataSource = tbl2

        End If

    End Sub

    'àÍéûï€ë∂ÉNÉäÉA
    Sub temp_clr()

        'ÉRÉÅÉìÉg
        strSQL = "DELETE FROM T61_temp_REP_MTR"
        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'K') "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        'ÉRÉÅÉìÉg
        strSQL = "DELETE FROM T63_temp_REP_CMNT"
        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'K') "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        'ïîïi
        strSQL = "DELETE FROM T64_temp_REP_PART"
        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (mitumori_kanryou = 'K')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

End Class