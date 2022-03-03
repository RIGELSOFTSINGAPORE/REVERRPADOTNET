Public Class F10_Form11
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2, WK_DsList3, WK_DsList4 As New DataSet
    Dim DtView1, DtView2, WK_DtView1, WK_DtView2, WK_DtView3, WK_DtView4, WK_DtView5, WK_DtView6 As DataView
    Dim DsCMB1, DsCMB2, DsCMB3, DsCMB4 As New DataSet
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F, CSR_POS, CHG_F, ANS As String
    Dim i, r, en, Line_No, Line_No2, Line_No3, chg_itm, seq, WK_seq, WK_cnt, j As Integer
    Dim cmb_reset As String
    Dim WK_str, WK_str2 As String
    Dim WK_int, WK_int2 As Integer
    Dim inz_F As String = "0"
    Dim Irregular_F As String = "0"
    Dim TSS_F, QA_F As String

    Dim amnt(6) As Integer  'é©ìÆåvéZÇÃíl
    Dim rate1, rate2 As Decimal

    'ïtëÆïi
    Private chkBox(99, 1) As CheckBox
    Private nbrBox(99, 1) As GrapeCity.Win.Input.Number
    Private edit(99, 2) As GrapeCity.Win.Input.Edit

    'åÃè·ì‡óe
    Private cmbBo_2(99, 1) As GrapeCity.Win.Input.Combo
    Dim WK_DsCMB As New DataSet

    'å©êœì‡óe
    Private cmbBo_3(99, 1) As GrapeCity.Win.Input.Combo
    Private label_3(99, 2) As label
    Dim WK_DsCMB3 As New DataSet

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
    Friend WithEvents Panel_å©êœ As System.Windows.Forms.Panel
    Friend WithEvents Button_M001 As System.Windows.Forms.Button
    Friend WithEvents Panel_M1 As System.Windows.Forms.Panel
    Friend WithEvents Edit_M003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_M002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_M001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label12_1 As System.Windows.Forms.Label
    Friend WithEvents Label13_1 As System.Windows.Forms.Label
    Friend WithEvents Combo_M001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label33_1 As System.Windows.Forms.Label
    Friend WithEvents DataGrid_M1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Number032 As GrapeCity.Win.Input.Number
    Friend WithEvents Number012 As GrapeCity.Win.Input.Number
    Friend WithEvents Number031 As GrapeCity.Win.Input.Number
    Friend WithEvents Number022 As GrapeCity.Win.Input.Number
    Friend WithEvents Number011 As GrapeCity.Win.Input.Number
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Number021 As GrapeCity.Win.Input.Number
    Friend WithEvents Number033 As GrapeCity.Win.Input.Number
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label22_1 As System.Windows.Forms.Label
    Friend WithEvents Label23_1 As System.Windows.Forms.Label
    Friend WithEvents calc_cls As System.Windows.Forms.Label
    Friend WithEvents Number023 As GrapeCity.Win.Input.Number
    Friend WithEvents Number013 As GrapeCity.Win.Input.Number
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents Panel_éÛït As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Combo_U001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label19_1 As System.Windows.Forms.Label
    Friend WithEvents Label11_1 As System.Windows.Forms.Label
    Friend WithEvents Edit_U004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo_U002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Panel_U2 As System.Windows.Forms.Panel
    Friend WithEvents Edit_U002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_U005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_U003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label04_1 As System.Windows.Forms.Label
    Friend WithEvents Label09_1 As System.Windows.Forms.Label
    Friend WithEvents Label10_1 As System.Windows.Forms.Label
    Friend WithEvents Label05_1 As System.Windows.Forms.Label
    Friend WithEvents Label07_1 As System.Windows.Forms.Label
    Friend WithEvents Date_U001 As GrapeCity.Win.Input.Date
    Friend WithEvents Edit_U001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel_U1 As System.Windows.Forms.Panel
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents CheckBox_U001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CLU001 As System.Windows.Forms.Label
    Friend WithEvents CL004 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Edit
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Mask
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Edit901 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit902 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Edit011 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label014 As System.Windows.Forms.Label
    Friend WithEvents Combo004 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Date004 As GrapeCity.Win.Input.Date
    Friend WithEvents Date003 As GrapeCity.Win.Input.Date
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit008 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit007 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Number014 As GrapeCity.Win.Input.Number
    Friend WithEvents Number037 As GrapeCity.Win.Input.Number
    Friend WithEvents Number036 As GrapeCity.Win.Input.Number
    Friend WithEvents Number035 As GrapeCity.Win.Input.Number
    Friend WithEvents Number034 As GrapeCity.Win.Input.Number
    Friend WithEvents Number027 As GrapeCity.Win.Input.Number
    Friend WithEvents Number026 As GrapeCity.Win.Input.Number
    Friend WithEvents Number016 As GrapeCity.Win.Input.Number
    Friend WithEvents Number015 As GrapeCity.Win.Input.Number
    Friend WithEvents Number025 As GrapeCity.Win.Input.Number
    Friend WithEvents Number024 As GrapeCity.Win.Input.Number
    Friend WithEvents Number017 As GrapeCity.Win.Input.Number
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents Label_M01 As System.Windows.Forms.Label
    Friend WithEvents Label_M02 As System.Windows.Forms.Label
    Friend WithEvents CLU002 As System.Windows.Forms.Label
    Friend WithEvents CLM001 As System.Windows.Forms.Label
    Friend WithEvents tax_rate As System.Windows.Forms.Label
    Friend WithEvents Combo_M003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label_M04 As System.Windows.Forms.Label
    Friend WithEvents CLM003 As System.Windows.Forms.Label
    Friend WithEvents Ck_atri_flg As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Edit012 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Number038 As GrapeCity.Win.Input.Number
    Friend WithEvents Number028 As GrapeCity.Win.Input.Number
    Friend WithEvents Number018 As GrapeCity.Win.Input.Number
    Friend WithEvents Button_S2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date_U002 As GrapeCity.Win.Input.Date
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents apse As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CK_own_flg As System.Windows.Forms.CheckBox
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label001 As GrapeCity.Win.Input.Edit
    Friend WithEvents NumberN003 As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN007 As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN004 As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN008 As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN005 As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN006 As GrapeCity.Win.Input.Number
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Date_U003 As GrapeCity.Win.Input.Date
    Friend WithEvents CL005 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents kengen As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Edit013 As GrapeCity.Win.Input.Edit
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GRP As System.Windows.Forms.Label
    Friend WithEvents NumberN008_Bk As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN007_Bk As GrapeCity.Win.Input.Number
    Friend WithEvents Number001_nTax As GrapeCity.Win.Input.Number
    Friend WithEvents Number019 As GrapeCity.Win.Input.Number
    Friend WithEvents Number029 As GrapeCity.Win.Input.Number
    Friend WithEvents Number039 As GrapeCity.Win.Input.Number
    Friend WithEvents CHG As System.Windows.Forms.Label
    Friend WithEvents CheckBox_M001 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_U002 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_U003 As System.Windows.Forms.CheckBox
    Friend WithEvents CL006 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Combo
    Friend WithEvents Date007 As GrapeCity.Win.Input.Date
    Friend WithEvents Label016 As System.Windows.Forms.Label
    Friend WithEvents Label015 As System.Windows.Forms.Label
    Friend WithEvents Date008 As GrapeCity.Win.Input.Date
    Friend WithEvents Label017 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cntact2 As System.Windows.Forms.Label
    Friend WithEvents cntact1 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Edit015 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit014 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_U006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Date_U004 As GrapeCity.Win.Input.Date
    Friend WithEvents CkBox01_N As System.Windows.Forms.CheckBox
    Friend WithEvents CkBox01_Y As System.Windows.Forms.CheckBox
    Friend WithEvents SBM As System.Windows.Forms.Label
    Friend WithEvents Button97 As System.Windows.Forms.Button
    Friend WithEvents sn_n As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Date015 As GrapeCity.Win.Input.Date
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2_moto As System.Windows.Forms.CheckBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel_å©êœ = New System.Windows.Forms.Panel
        Me.CheckBox2_moto = New System.Windows.Forms.CheckBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.CHG = New System.Windows.Forms.Label
        Me.Number039 = New GrapeCity.Win.Input.Number
        Me.Number029 = New GrapeCity.Win.Input.Number
        Me.Number019 = New GrapeCity.Win.Input.Number
        Me.Combo_M003 = New GrapeCity.Win.Input.Combo
        Me.Label_M04 = New System.Windows.Forms.Label
        Me.Button_M001 = New System.Windows.Forms.Button
        Me.Panel_M1 = New System.Windows.Forms.Panel
        Me.Edit_M003 = New GrapeCity.Win.Input.Edit
        Me.Edit_M002 = New GrapeCity.Win.Input.Edit
        Me.Label12_1 = New System.Windows.Forms.Label
        Me.Label13_1 = New System.Windows.Forms.Label
        Me.Combo_M001 = New GrapeCity.Win.Input.Combo
        Me.Label_M02 = New System.Windows.Forms.Label
        Me.Label33_1 = New System.Windows.Forms.Label
        Me.DataGrid_M1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button_S2 = New System.Windows.Forms.Button
        Me.Number016 = New GrapeCity.Win.Input.Number
        Me.Label133 = New System.Windows.Forms.Label
        Me.Label132 = New System.Windows.Forms.Label
        Me.Number015 = New GrapeCity.Win.Input.Number
        Me.Number025 = New GrapeCity.Win.Input.Number
        Me.Number024 = New GrapeCity.Win.Input.Number
        Me.Number017 = New GrapeCity.Win.Input.Number
        Me.Label11 = New System.Windows.Forms.Label
        Me.Number032 = New GrapeCity.Win.Input.Number
        Me.Number012 = New GrapeCity.Win.Input.Number
        Me.Number031 = New GrapeCity.Win.Input.Number
        Me.Number022 = New GrapeCity.Win.Input.Number
        Me.Number011 = New GrapeCity.Win.Input.Number
        Me.Number014 = New GrapeCity.Win.Input.Number
        Me.Label131 = New System.Windows.Forms.Label
        Me.Label130 = New System.Windows.Forms.Label
        Me.Label129 = New System.Windows.Forms.Label
        Me.Label128 = New System.Windows.Forms.Label
        Me.Number021 = New GrapeCity.Win.Input.Number
        Me.Number033 = New GrapeCity.Win.Input.Number
        Me.Label22_1 = New System.Windows.Forms.Label
        Me.Label23_1 = New System.Windows.Forms.Label
        Me.Number037 = New GrapeCity.Win.Input.Number
        Me.Number036 = New GrapeCity.Win.Input.Number
        Me.Number035 = New GrapeCity.Win.Input.Number
        Me.Number034 = New GrapeCity.Win.Input.Number
        Me.Label191 = New System.Windows.Forms.Label
        Me.Number023 = New GrapeCity.Win.Input.Number
        Me.Number013 = New GrapeCity.Win.Input.Number
        Me.Label138 = New System.Windows.Forms.Label
        Me.Number027 = New GrapeCity.Win.Input.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Number038 = New GrapeCity.Win.Input.Number
        Me.Number028 = New GrapeCity.Win.Input.Number
        Me.Number018 = New GrapeCity.Win.Input.Number
        Me.Number026 = New GrapeCity.Win.Input.Number
        Me.Edit_M001 = New GrapeCity.Win.Input.Edit
        Me.Label_M01 = New System.Windows.Forms.Label
        Me.CheckBox_M001 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.calc_cls = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button0 = New System.Windows.Forms.Button
        Me.Panel_éÛït = New System.Windows.Forms.Panel
        Me.Label33 = New System.Windows.Forms.Label
        Me.Date_U004 = New GrapeCity.Win.Input.Date
        Me.Edit_U006 = New GrapeCity.Win.Input.Edit
        Me.Label31 = New System.Windows.Forms.Label
        Me.CheckBox_U003 = New System.Windows.Forms.CheckBox
        Me.CheckBox_U002 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date_U002 = New GrapeCity.Win.Input.Date
        Me.Label6 = New System.Windows.Forms.Label
        Me.Combo_U001 = New GrapeCity.Win.Input.Combo
        Me.Label19_1 = New System.Windows.Forms.Label
        Me.Label11_1 = New System.Windows.Forms.Label
        Me.Edit_U004 = New GrapeCity.Win.Input.Edit
        Me.Combo_U002 = New GrapeCity.Win.Input.Combo
        Me.Panel_U2 = New System.Windows.Forms.Panel
        Me.Edit_U002 = New GrapeCity.Win.Input.Edit
        Me.Edit_U005 = New GrapeCity.Win.Input.Edit
        Me.Edit_U003 = New GrapeCity.Win.Input.Edit
        Me.Label04_1 = New System.Windows.Forms.Label
        Me.Label09_1 = New System.Windows.Forms.Label
        Me.Label10_1 = New System.Windows.Forms.Label
        Me.Label05_1 = New System.Windows.Forms.Label
        Me.Label07_1 = New System.Windows.Forms.Label
        Me.Date_U001 = New GrapeCity.Win.Input.Date
        Me.Edit_U001 = New GrapeCity.Win.Input.Edit
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel_U1 = New System.Windows.Forms.Panel
        Me.pos = New System.Windows.Forms.Label
        Me.CheckBox_U001 = New System.Windows.Forms.CheckBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Date_U003 = New GrapeCity.Win.Input.Date
        Me.Ck_atri_flg = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CLU001 = New System.Windows.Forms.Label
        Me.CLU002 = New System.Windows.Forms.Label
        Me.CL004 = New System.Windows.Forms.Label
        Me.CL003 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.Edit010 = New GrapeCity.Win.Input.Edit
        Me.Edit009 = New GrapeCity.Win.Input.Edit
        Me.Mask1 = New GrapeCity.Win.Input.Mask
        Me.Label013 = New System.Windows.Forms.Label
        Me.Edit901 = New GrapeCity.Win.Input.Edit
        Me.Edit902 = New GrapeCity.Win.Input.Edit
        Me.Label20 = New System.Windows.Forms.Label
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Edit000 = New GrapeCity.Win.Input.Edit
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Edit011 = New GrapeCity.Win.Input.Edit
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label014 = New System.Windows.Forms.Label
        Me.Combo004 = New GrapeCity.Win.Input.Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label012 = New System.Windows.Forms.Label
        Me.Date004 = New GrapeCity.Win.Input.Date
        Me.Date003 = New GrapeCity.Win.Input.Date
        Me.Edit006 = New GrapeCity.Win.Input.Edit
        Me.Edit008 = New GrapeCity.Win.Input.Edit
        Me.Edit007 = New GrapeCity.Win.Input.Edit
        Me.Edit005 = New GrapeCity.Win.Input.Edit
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Edit004 = New GrapeCity.Win.Input.Edit
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Edit002 = New GrapeCity.Win.Input.Edit
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Label9 = New System.Windows.Forms.Label
        Me.CLM001 = New System.Windows.Forms.Label
        Me.tax_rate = New System.Windows.Forms.Label
        Me.CLM003 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Edit012 = New GrapeCity.Win.Input.Edit
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.Label10 = New System.Windows.Forms.Label
        Me.apse = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.NumberN004 = New GrapeCity.Win.Input.Number
        Me.NumberN003 = New GrapeCity.Win.Input.Number
        Me.NumberN005 = New GrapeCity.Win.Input.Number
        Me.NumberN006 = New GrapeCity.Win.Input.Number
        Me.NumberN008 = New GrapeCity.Win.Input.Number
        Me.NumberN007 = New GrapeCity.Win.Input.Number
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.CK_own_flg = New System.Windows.Forms.CheckBox
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label002 = New GrapeCity.Win.Input.Edit
        Me.Label001 = New GrapeCity.Win.Input.Edit
        Me.Label15 = New System.Windows.Forms.Label
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.Label25 = New System.Windows.Forms.Label
        Me.Combo005 = New GrapeCity.Win.Input.Combo
        Me.CL005 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.kengen = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.Edit013 = New GrapeCity.Win.Input.Edit
        Me.Button3 = New System.Windows.Forms.Button
        Me.GRP = New System.Windows.Forms.Label
        Me.NumberN008_Bk = New GrapeCity.Win.Input.Number
        Me.NumberN007_Bk = New GrapeCity.Win.Input.Number
        Me.Number001_nTax = New GrapeCity.Win.Input.Number
        Me.CL006 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Combo006 = New GrapeCity.Win.Input.Combo
        Me.Date007 = New GrapeCity.Win.Input.Date
        Me.Label016 = New System.Windows.Forms.Label
        Me.Label015 = New System.Windows.Forms.Label
        Me.Date008 = New GrapeCity.Win.Input.Date
        Me.Label017 = New System.Windows.Forms.Label
        Me.Button9 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cntact2 = New System.Windows.Forms.Label
        Me.cntact1 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Edit015 = New GrapeCity.Win.Input.Edit
        Me.Label30 = New System.Windows.Forms.Label
        Me.Edit014 = New GrapeCity.Win.Input.Edit
        Me.Label32 = New System.Windows.Forms.Label
        Me.CkBox01_N = New System.Windows.Forms.CheckBox
        Me.CkBox01_Y = New System.Windows.Forms.CheckBox
        Me.SBM = New System.Windows.Forms.Label
        Me.Button97 = New System.Windows.Forms.Button
        Me.sn_n = New System.Windows.Forms.Label
        Me.Date015 = New GrapeCity.Win.Input.Date
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Panel_å©êœ.SuspendLayout()
        CType(Me.Number039, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number016, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number025, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number024, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number017, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Date_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_U1.SuspendLayout()
        CType(Me.Date_U003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit901, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit902, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN008_Bk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN007_Bk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_å©êœ
        '
        Me.Panel_å©êœ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_å©êœ.Controls.Add(Me.CheckBox2_moto)
        Me.Panel_å©êœ.Controls.Add(Me.Label37)
        Me.Panel_å©êœ.Controls.Add(Me.CHG)
        Me.Panel_å©êœ.Controls.Add(Me.Number039)
        Me.Panel_å©êœ.Controls.Add(Me.Number029)
        Me.Panel_å©êœ.Controls.Add(Me.Number019)
        Me.Panel_å©êœ.Controls.Add(Me.Combo_M003)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M04)
        Me.Panel_å©êœ.Controls.Add(Me.Button_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Panel_M1)
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M003)
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M002)
        Me.Panel_å©êœ.Controls.Add(Me.Label12_1)
        Me.Panel_å©êœ.Controls.Add(Me.Label13_1)
        Me.Panel_å©êœ.Controls.Add(Me.Combo_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M02)
        Me.Panel_å©êœ.Controls.Add(Me.Label33_1)
        Me.Panel_å©êœ.Controls.Add(Me.DataGrid_M1)
        Me.Panel_å©êœ.Controls.Add(Me.Button_S2)
        Me.Panel_å©êœ.Controls.Add(Me.Number016)
        Me.Panel_å©êœ.Controls.Add(Me.Label133)
        Me.Panel_å©êœ.Controls.Add(Me.Label132)
        Me.Panel_å©êœ.Controls.Add(Me.Number015)
        Me.Panel_å©êœ.Controls.Add(Me.Number025)
        Me.Panel_å©êœ.Controls.Add(Me.Number024)
        Me.Panel_å©êœ.Controls.Add(Me.Number017)
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
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M01)
        Me.Panel_å©êœ.Controls.Add(Me.CheckBox_M001)
        Me.Panel_å©êœ.Controls.Add(Me.CheckBox2)
        Me.Panel_å©êœ.Location = New System.Drawing.Point(10, 264)
        Me.Panel_å©êœ.Name = "Panel_å©êœ"
        Me.Panel_å©êœ.Size = New System.Drawing.Size(986, 372)
        Me.Panel_å©êœ.TabIndex = 30
        Me.Panel_å©êœ.TabStop = True
        '
        'CheckBox2_moto
        '
        Me.CheckBox2_moto.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.CheckBox2_moto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox2_moto.Location = New System.Drawing.Point(864, 8)
        Me.CheckBox2_moto.Name = "CheckBox2_moto"
        Me.CheckBox2_moto.Size = New System.Drawing.Size(20, 16)
        Me.CheckBox2_moto.TabIndex = 1894
        Me.CheckBox2_moto.Visible = False
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Navy
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(784, 4)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(56, 20)
        Me.Label37.TabIndex = 1850
        Me.Label37.Text = "èCóùïsâ¬"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CHG
        '
        Me.CHG.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CHG.Location = New System.Drawing.Point(8, 280)
        Me.CHG.Name = "CHG"
        Me.CHG.Size = New System.Drawing.Size(432, 16)
        Me.CHG.TabIndex = 1839
        Me.CHG.Text = "CHG"
        Me.CHG.Visible = False
        '
        'Number039
        '
        Me.Number039.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number039.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number039.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number039.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number039.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number039.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number039.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number039.Enabled = False
        Me.Number039.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number039.HighlightText = True
        Me.Number039.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number039.Location = New System.Drawing.Point(868, 340)
        Me.Number039.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number039.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number039.Name = "Number039"
        Me.Number039.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number039.Size = New System.Drawing.Size(104, 20)
        Me.Number039.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number039.TabIndex = 1734
        Me.Number039.TabStop = False
        Me.Number039.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number039.Value = New Decimal(New Integer() {39, 0, 0, 0})
        Me.Number039.Visible = False
        '
        'Number029
        '
        Me.Number029.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number029.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number029.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number029.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.HighlightText = True
        Me.Number029.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number029.Location = New System.Drawing.Point(868, 320)
        Me.Number029.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number029.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number029.Name = "Number029"
        Me.Number029.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number029.Size = New System.Drawing.Size(104, 20)
        Me.Number029.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.TabIndex = 1733
        Me.Number029.TabStop = False
        Me.Number029.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number029.Value = New Decimal(New Integer() {29, 0, 0, 0})
        '
        'Number019
        '
        Me.Number019.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number019.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number019.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number019.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.HighlightText = True
        Me.Number019.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number019.Location = New System.Drawing.Point(868, 300)
        Me.Number019.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number019.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number019.Name = "Number019"
        Me.Number019.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number019.Size = New System.Drawing.Size(104, 20)
        Me.Number019.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.TabIndex = 1732
        Me.Number019.TabStop = False
        Me.Number019.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number019.Value = New Decimal(New Integer() {19, 0, 0, 0})
        '
        'Combo_M003
        '
        Me.Combo_M003.AutoSelect = True
        Me.Combo_M003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_M003.Location = New System.Drawing.Point(380, 4)
        Me.Combo_M003.MaxDropDownItems = 40
        Me.Combo_M003.Name = "Combo_M003"
        Me.Combo_M003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_M003.Size = New System.Drawing.Size(132, 20)
        Me.Combo_M003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_M003.TabIndex = 30
        Me.Combo_M003.Value = "Combo_M003"
        '
        'Label_M04
        '
        Me.Label_M04.BackColor = System.Drawing.Color.Navy
        Me.Label_M04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_M04.ForeColor = System.Drawing.Color.White
        Me.Label_M04.Location = New System.Drawing.Point(296, 4)
        Me.Label_M04.Name = "Label_M04"
        Me.Label_M04.Size = New System.Drawing.Size(84, 20)
        Me.Label_M04.TabIndex = 961
        Me.Label_M04.Text = "ìÔà’ìx"
        Me.Label_M04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_M001
        '
        Me.Button_M001.BackColor = System.Drawing.SystemColors.Control
        Me.Button_M001.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_M001.Location = New System.Drawing.Point(904, 8)
        Me.Button_M001.Name = "Button_M001"
        Me.Button_M001.Size = New System.Drawing.Size(72, 20)
        Me.Button_M001.TabIndex = 70
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
        Me.Panel_M1.TabIndex = 40
        Me.Panel_M1.TabStop = True
        '
        'Edit_M003
        '
        Me.Edit_M003.AcceptsReturn = True
        Me.Edit_M003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M003.HighlightText = True
        Me.Edit_M003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M003.LengthAsByte = True
        Me.Edit_M003.Location = New System.Drawing.Point(88, 192)
        Me.Edit_M003.MaxLength = 200
        Me.Edit_M003.Multiline = True
        Me.Edit_M003.Name = "Edit_M003"
        Me.Edit_M003.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M003.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M003.Size = New System.Drawing.Size(460, 76)
        Me.Edit_M003.TabIndex = 60
        '
        'Edit_M002
        '
        Me.Edit_M002.AcceptsReturn = True
        Me.Edit_M002.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M002.HighlightText = True
        Me.Edit_M002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M002.LengthAsByte = True
        Me.Edit_M002.Location = New System.Drawing.Point(88, 132)
        Me.Edit_M002.MaxLength = 1000
        Me.Edit_M002.Multiline = True
        Me.Edit_M002.Name = "Edit_M002"
        Me.Edit_M002.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M002.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M002.Size = New System.Drawing.Size(488, 60)
        Me.Edit_M002.TabIndex = 50
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
        'Combo_M001
        '
        Me.Combo_M001.AutoSelect = True
        Me.Combo_M001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_M001.Location = New System.Drawing.Point(88, 4)
        Me.Combo_M001.MaxDropDownItems = 40
        Me.Combo_M001.Name = "Combo_M001"
        Me.Combo_M001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_M001.Size = New System.Drawing.Size(200, 20)
        Me.Combo_M001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_M001.TabIndex = 20
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
        Me.DataGrid_M1.TabIndex = 80
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
        Me.DataGridTextBoxColumn3.ReadOnly = True
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
        'Button_S2
        '
        Me.Button_S2.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S2.Location = New System.Drawing.Point(548, 196)
        Me.Button_S2.Name = "Button_S2"
        Me.Button_S2.Size = New System.Drawing.Size(28, 20)
        Me.Button_S2.TabIndex = 1731
        Me.Button_S2.TabStop = False
        Me.Button_S2.Text = "ÅH"
        '
        'Number016
        '
        Me.Number016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number016.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number016.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number016.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number016.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number016.Enabled = False
        Me.Number016.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number016.HighlightText = True
        Me.Number016.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number016.Location = New System.Drawing.Point(704, 300)
        Me.Number016.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number016.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number016.Name = "Number016"
        Me.Number016.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number016.Size = New System.Drawing.Size(52, 20)
        Me.Number016.TabIndex = 260
        Me.Number016.TabStop = False
        Me.Number016.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number016.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.Color.Navy
        Me.Label133.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label133.ForeColor = System.Drawing.Color.White
        Me.Label133.Location = New System.Drawing.Point(392, 340)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(52, 20)
        Me.Label133.TabIndex = 1565
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
        Me.Label132.TabIndex = 1564
        Me.Label132.Text = "åvè„äz"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number015
        '
        Me.Number015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number015.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number015.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number015.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number015.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number015.Enabled = False
        Me.Number015.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number015.HighlightText = True
        Me.Number015.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number015.Location = New System.Drawing.Point(652, 300)
        Me.Number015.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number015.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number015.Name = "Number015"
        Me.Number015.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number015.Size = New System.Drawing.Size(52, 20)
        Me.Number015.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number015.TabIndex = 250
        Me.Number015.TabStop = False
        Me.Number015.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number015.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Number025
        '
        Me.Number025.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number025.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number025.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number025.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number025.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number025.Enabled = False
        Me.Number025.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number025.HighlightText = True
        Me.Number025.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number025.Location = New System.Drawing.Point(652, 320)
        Me.Number025.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number025.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number025.Name = "Number025"
        Me.Number025.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number025.Size = New System.Drawing.Size(52, 20)
        Me.Number025.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number025.TabIndex = 300
        Me.Number025.TabStop = False
        Me.Number025.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number025.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Number024
        '
        Me.Number024.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number024.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number024.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number024.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number024.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number024.Enabled = False
        Me.Number024.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number024.HighlightText = True
        Me.Number024.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number024.Location = New System.Drawing.Point(600, 320)
        Me.Number024.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number024.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number024.Name = "Number024"
        Me.Number024.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number024.Size = New System.Drawing.Size(52, 20)
        Me.Number024.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number024.TabIndex = 290
        Me.Number024.TabStop = False
        Me.Number024.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number024.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'Number017
        '
        Me.Number017.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number017.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number017.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number017.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number017.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number017.Enabled = False
        Me.Number017.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number017.HighlightText = True
        Me.Number017.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number017.Location = New System.Drawing.Point(756, 300)
        Me.Number017.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number017.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number017.Name = "Number017"
        Me.Number017.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number017.Size = New System.Drawing.Size(52, 20)
        Me.Number017.TabIndex = 270
        Me.Number017.TabStop = False
        Me.Number017.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number017.Value = New Decimal(New Integer() {17, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(868, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 20)
        Me.Label11.TabIndex = 1628
        Me.Label11.Text = "êfífóøÅiÉLÉÉÉìÉZÉãÅj"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number032
        '
        Me.Number032.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number032.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number032.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number032.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number032.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number032.Enabled = False
        Me.Number032.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number032.HighlightText = True
        Me.Number032.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number032.Location = New System.Drawing.Point(496, 340)
        Me.Number032.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number032.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number032.Name = "Number032"
        Me.Number032.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number032.Size = New System.Drawing.Size(52, 20)
        Me.Number032.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number032.TabIndex = 320
        Me.Number032.TabStop = False
        Me.Number032.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number032.Value = New Decimal(New Integer() {32, 0, 0, 0})
        '
        'Number012
        '
        Me.Number012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number012.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number012.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number012.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number012.Enabled = False
        Me.Number012.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number012.HighlightText = True
        Me.Number012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number012.Location = New System.Drawing.Point(496, 300)
        Me.Number012.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number012.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number012.Name = "Number012"
        Me.Number012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number012.Size = New System.Drawing.Size(52, 20)
        Me.Number012.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.TabIndex = 210
        Me.Number012.TabStop = False
        Me.Number012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number012.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Number031
        '
        Me.Number031.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number031.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number031.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number031.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number031.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number031.Enabled = False
        Me.Number031.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number031.HighlightText = True
        Me.Number031.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number031.Location = New System.Drawing.Point(444, 340)
        Me.Number031.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number031.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number031.Name = "Number031"
        Me.Number031.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number031.Size = New System.Drawing.Size(52, 20)
        Me.Number031.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number031.TabIndex = 310
        Me.Number031.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number031.Value = New Decimal(New Integer() {31, 0, 0, 0})
        '
        'Number022
        '
        Me.Number022.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number022.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number022.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number022.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number022.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number022.Enabled = False
        Me.Number022.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number022.HighlightText = True
        Me.Number022.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number022.Location = New System.Drawing.Point(496, 320)
        Me.Number022.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number022.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number022.Name = "Number022"
        Me.Number022.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number022.Size = New System.Drawing.Size(52, 20)
        Me.Number022.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number022.TabIndex = 270
        Me.Number022.TabStop = False
        Me.Number022.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number022.Value = New Decimal(New Integer() {22, 0, 0, 0})
        '
        'Number011
        '
        Me.Number011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number011.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number011.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number011.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number011.Enabled = False
        Me.Number011.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number011.HighlightText = True
        Me.Number011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number011.Location = New System.Drawing.Point(444, 300)
        Me.Number011.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number011.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number011.Name = "Number011"
        Me.Number011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number011.Size = New System.Drawing.Size(52, 20)
        Me.Number011.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.TabIndex = 200
        Me.Number011.TabStop = False
        Me.Number011.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number011.Value = New Decimal(New Integer() {11, 0, 0, 0})
        '
        'Number014
        '
        Me.Number014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number014.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number014.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number014.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number014.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number014.Enabled = False
        Me.Number014.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number014.HighlightText = True
        Me.Number014.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number014.Location = New System.Drawing.Point(600, 300)
        Me.Number014.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number014.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number014.Name = "Number014"
        Me.Number014.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number014.Size = New System.Drawing.Size(52, 20)
        Me.Number014.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number014.TabIndex = 240
        Me.Number014.TabStop = False
        Me.Number014.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number014.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.Color.Navy
        Me.Label131.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label131.ForeColor = System.Drawing.Color.White
        Me.Label131.Location = New System.Drawing.Point(808, 280)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(52, 20)
        Me.Label131.TabIndex = 1563
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
        Me.Label130.TabIndex = 1562
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
        Me.Label129.TabIndex = 1561
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
        Me.Label128.TabIndex = 1560
        Me.Label128.Text = "ÇªÇÃëº"
        Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number021
        '
        Me.Number021.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number021.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number021.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number021.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number021.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number021.Enabled = False
        Me.Number021.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number021.HighlightText = True
        Me.Number021.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number021.Location = New System.Drawing.Point(444, 320)
        Me.Number021.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number021.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number021.Name = "Number021"
        Me.Number021.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number021.Size = New System.Drawing.Size(52, 20)
        Me.Number021.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number021.TabIndex = 260
        Me.Number021.TabStop = False
        Me.Number021.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number021.Value = New Decimal(New Integer() {21, 0, 0, 0})
        '
        'Number033
        '
        Me.Number033.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number033.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number033.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number033.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number033.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number033.Enabled = False
        Me.Number033.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number033.HighlightText = True
        Me.Number033.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number033.Location = New System.Drawing.Point(548, 340)
        Me.Number033.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number033.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number033.Name = "Number033"
        Me.Number033.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number033.Size = New System.Drawing.Size(52, 20)
        Me.Number033.TabIndex = 330
        Me.Number033.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number033.Value = New Decimal(New Integer() {33, 0, 0, 0})
        '
        'Label22_1
        '
        Me.Label22_1.BackColor = System.Drawing.Color.Navy
        Me.Label22_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22_1.ForeColor = System.Drawing.Color.White
        Me.Label22_1.Location = New System.Drawing.Point(444, 280)
        Me.Label22_1.Name = "Label22_1"
        Me.Label22_1.Size = New System.Drawing.Size(52, 20)
        Me.Label22_1.TabIndex = 1571
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
        Me.Label23_1.TabIndex = 1572
        Me.Label23_1.Text = "ïîïi"
        Me.Label23_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number037
        '
        Me.Number037.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number037.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number037.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number037.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number037.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number037.Enabled = False
        Me.Number037.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number037.HighlightText = True
        Me.Number037.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number037.Location = New System.Drawing.Point(756, 340)
        Me.Number037.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number037.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number037.Name = "Number037"
        Me.Number037.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number037.Size = New System.Drawing.Size(52, 20)
        Me.Number037.TabIndex = 1551
        Me.Number037.TabStop = False
        Me.Number037.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number037.Value = New Decimal(New Integer() {37, 0, 0, 0})
        '
        'Number036
        '
        Me.Number036.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number036.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number036.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number036.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number036.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number036.Enabled = False
        Me.Number036.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number036.HighlightText = True
        Me.Number036.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number036.Location = New System.Drawing.Point(704, 340)
        Me.Number036.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number036.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number036.Name = "Number036"
        Me.Number036.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number036.Size = New System.Drawing.Size(52, 20)
        Me.Number036.TabIndex = 1550
        Me.Number036.TabStop = False
        Me.Number036.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number036.Value = New Decimal(New Integer() {36, 0, 0, 0})
        '
        'Number035
        '
        Me.Number035.BackColor = System.Drawing.Color.White
        Me.Number035.DisabledForeColor = System.Drawing.Color.Black
        Me.Number035.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number035.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number035.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number035.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number035.Enabled = False
        Me.Number035.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number035.HighlightText = True
        Me.Number035.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number035.Location = New System.Drawing.Point(652, 340)
        Me.Number035.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number035.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number035.Name = "Number035"
        Me.Number035.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number035.Size = New System.Drawing.Size(52, 20)
        Me.Number035.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number035.TabIndex = 350
        Me.Number035.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number035.Value = New Decimal(New Integer() {35, 0, 0, 0})
        '
        'Number034
        '
        Me.Number034.BackColor = System.Drawing.Color.White
        Me.Number034.DisabledForeColor = System.Drawing.Color.Black
        Me.Number034.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number034.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number034.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number034.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number034.Enabled = False
        Me.Number034.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number034.HighlightText = True
        Me.Number034.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number034.Location = New System.Drawing.Point(600, 340)
        Me.Number034.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number034.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number034.Name = "Number034"
        Me.Number034.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number034.Size = New System.Drawing.Size(52, 20)
        Me.Number034.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number034.TabIndex = 340
        Me.Number034.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number034.Value = New Decimal(New Integer() {34, 0, 0, 0})
        '
        'Label191
        '
        Me.Label191.BackColor = System.Drawing.Color.Navy
        Me.Label191.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label191.ForeColor = System.Drawing.Color.White
        Me.Label191.Location = New System.Drawing.Point(392, 320)
        Me.Label191.Name = "Label191"
        Me.Label191.Size = New System.Drawing.Size(52, 20)
        Me.Label191.TabIndex = 1568
        Me.Label191.Text = "EUâøäi"
        Me.Label191.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number023
        '
        Me.Number023.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number023.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number023.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number023.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number023.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number023.Enabled = False
        Me.Number023.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number023.HighlightText = True
        Me.Number023.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number023.Location = New System.Drawing.Point(548, 320)
        Me.Number023.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number023.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number023.Name = "Number023"
        Me.Number023.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number023.Size = New System.Drawing.Size(52, 20)
        Me.Number023.TabIndex = 280
        Me.Number023.TabStop = False
        Me.Number023.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number023.Value = New Decimal(New Integer() {23, 0, 0, 0})
        '
        'Number013
        '
        Me.Number013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number013.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number013.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number013.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number013.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number013.Enabled = False
        Me.Number013.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number013.HighlightText = True
        Me.Number013.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number013.Location = New System.Drawing.Point(548, 300)
        Me.Number013.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number013.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number013.Name = "Number013"
        Me.Number013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number013.Size = New System.Drawing.Size(52, 20)
        Me.Number013.TabIndex = 220
        Me.Number013.TabStop = False
        Me.Number013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number013.Value = New Decimal(New Integer() {13, 0, 0, 0})
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.Color.Navy
        Me.Label138.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label138.ForeColor = System.Drawing.Color.White
        Me.Label138.Location = New System.Drawing.Point(704, 280)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(52, 20)
        Me.Label138.TabIndex = 1566
        Me.Label138.Text = "è¨åv"
        Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number027
        '
        Me.Number027.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number027.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number027.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number027.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number027.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number027.Enabled = False
        Me.Number027.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number027.HighlightText = True
        Me.Number027.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number027.Location = New System.Drawing.Point(756, 320)
        Me.Number027.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number027.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number027.Name = "Number027"
        Me.Number027.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number027.Size = New System.Drawing.Size(52, 20)
        Me.Number027.TabIndex = 1544
        Me.Number027.TabStop = False
        Me.Number027.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number027.Value = New Decimal(New Integer() {27, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(496, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 1730
        Me.Label1.Text = "AP SE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number038
        '
        Me.Number038.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number038.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number038.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number038.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number038.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number038.Enabled = False
        Me.Number038.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number038.HighlightText = True
        Me.Number038.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number038.Location = New System.Drawing.Point(808, 340)
        Me.Number038.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number038.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number038.Name = "Number038"
        Me.Number038.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number038.Size = New System.Drawing.Size(52, 20)
        Me.Number038.TabIndex = 1729
        Me.Number038.TabStop = False
        Me.Number038.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number038.Value = New Decimal(New Integer() {38, 0, 0, 0})
        '
        'Number028
        '
        Me.Number028.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number028.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number028.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number028.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number028.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number028.Enabled = False
        Me.Number028.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number028.HighlightText = True
        Me.Number028.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number028.Location = New System.Drawing.Point(808, 320)
        Me.Number028.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number028.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number028.Name = "Number028"
        Me.Number028.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number028.Size = New System.Drawing.Size(52, 20)
        Me.Number028.TabIndex = 1728
        Me.Number028.TabStop = False
        Me.Number028.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number028.Value = New Decimal(New Integer() {28, 0, 0, 0})
        '
        'Number018
        '
        Me.Number018.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number018.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number018.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number018.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number018.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number018.Enabled = False
        Me.Number018.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number018.HighlightText = True
        Me.Number018.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number018.Location = New System.Drawing.Point(808, 300)
        Me.Number018.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number018.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number018.Name = "Number018"
        Me.Number018.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number018.Size = New System.Drawing.Size(52, 20)
        Me.Number018.TabIndex = 1727
        Me.Number018.TabStop = False
        Me.Number018.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number018.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'Number026
        '
        Me.Number026.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number026.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number026.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number026.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number026.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number026.Enabled = False
        Me.Number026.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number026.HighlightText = True
        Me.Number026.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number026.Location = New System.Drawing.Point(704, 320)
        Me.Number026.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number026.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number026.Name = "Number026"
        Me.Number026.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number026.Size = New System.Drawing.Size(52, 20)
        Me.Number026.TabIndex = 1543
        Me.Number026.TabStop = False
        Me.Number026.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number026.Value = New Decimal(New Integer() {26, 0, 0, 0})
        '
        'Edit_M001
        '
        Me.Edit_M001.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M001.HighlightText = True
        Me.Edit_M001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_M001.LengthAsByte = True
        Me.Edit_M001.Location = New System.Drawing.Point(604, 4)
        Me.Edit_M001.MaxLength = 20
        Me.Edit_M001.Name = "Edit_M001"
        Me.Edit_M001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M001.Size = New System.Drawing.Size(172, 20)
        Me.Edit_M001.TabIndex = 35
        Me.Edit_M001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        'CheckBox_M001
        '
        Me.CheckBox_M001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox_M001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_M001.Location = New System.Drawing.Point(340, 304)
        Me.CheckBox_M001.Name = "CheckBox_M001"
        Me.CheckBox_M001.Size = New System.Drawing.Size(48, 52)
        Me.CheckBox_M001.TabIndex = 1849
        Me.CheckBox_M001.TabStop = False
        Me.CheckBox_M001.Text = "é©ìÆåvéZâèú"
        '
        'CheckBox2
        '
        Me.CheckBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox2.Location = New System.Drawing.Point(844, 8)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(20, 16)
        Me.CheckBox2.TabIndex = 1893
        '
        'Button80
        '
        Me.Button80.BackColor = System.Drawing.SystemColors.Control
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Enabled = False
        Me.Button80.Location = New System.Drawing.Point(844, 660)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(72, 24)
        Me.Button80.TabIndex = 340
        Me.Button80.TabStop = False
        Me.Button80.Text = "óöó"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(928, 660)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 350
        Me.Button98.Text = "ñﬂÇÈ"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 660)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 290
        Me.Button1.Text = "çXêV"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(64, 244)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(48, 20)
        Me.Button12.TabIndex = 1525
        Me.Button12.TabStop = False
        Me.Button12.Text = "å©êœ"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(16, 244)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(48, 20)
        Me.Button11.TabIndex = 1524
        Me.Button11.TabStop = False
        Me.Button11.Text = "éÛït"
        '
        'calc_cls
        '
        Me.calc_cls.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.calc_cls.Location = New System.Drawing.Point(952, 636)
        Me.calc_cls.Name = "calc_cls"
        Me.calc_cls.Size = New System.Drawing.Size(40, 16)
        Me.calc_cls.TabIndex = 1567
        Me.calc_cls.Text = "1"
        Me.calc_cls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.calc_cls.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(196, 660)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 320
        Me.Button5.TabStop = False
        Me.Button5.Text = "å©êœèë"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(92, 660)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 300
        Me.Button2.TabStop = False
        Me.Button2.Text = "ÉNÉäÉA"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(472, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 20)
        Me.Label5.TabIndex = 1718
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button0
        '
        Me.Button0.BackColor = System.Drawing.SystemColors.Control
        Me.Button0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button0.Location = New System.Drawing.Point(168, 8)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(28, 20)
        Me.Button0.TabIndex = 1637
        Me.Button0.TabStop = False
        Me.Button0.Text = "ÅH"
        '
        'Panel_éÛït
        '
        Me.Panel_éÛït.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_éÛït.Controls.Add(Me.Label33)
        Me.Panel_éÛït.Controls.Add(Me.Date_U004)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U006)
        Me.Panel_éÛït.Controls.Add(Me.Label31)
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U003)
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U002)
        Me.Panel_éÛït.Controls.Add(Me.Label3)
        Me.Panel_éÛït.Controls.Add(Me.Date_U002)
        Me.Panel_éÛït.Controls.Add(Me.Label6)
        Me.Panel_éÛït.Controls.Add(Me.Combo_U001)
        Me.Panel_éÛït.Controls.Add(Me.Label19_1)
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
        Me.Panel_éÛït.Controls.Add(Me.Date_U001)
        Me.Panel_éÛït.Controls.Add(Me.Edit_U001)
        Me.Panel_éÛït.Controls.Add(Me.Label8)
        Me.Panel_éÛït.Controls.Add(Me.Panel_U1)
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U001)
        Me.Panel_éÛït.Controls.Add(Me.Label19)
        Me.Panel_éÛït.Controls.Add(Me.Date_U003)
        Me.Panel_éÛït.Location = New System.Drawing.Point(10, 264)
        Me.Panel_éÛït.Name = "Panel_éÛït"
        Me.Panel_éÛït.Size = New System.Drawing.Size(986, 372)
        Me.Panel_éÛït.TabIndex = 1660
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label33.Location = New System.Drawing.Point(840, 52)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(20, 20)
        Me.Label33.TabIndex = 1774
        Me.Label33.Text = "Å`"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U004
        '
        Me.Date_U004.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U004.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U004.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U004.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U004.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U004.Enabled = False
        Me.Date_U004.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U004.Location = New System.Drawing.Point(864, 52)
        Me.Date_U004.Name = "Date_U004"
        Me.Date_U004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U004.Size = New System.Drawing.Size(88, 20)
        Me.Date_U004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U004.TabIndex = 1773
        Me.Date_U004.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Edit_U006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U006.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U006.TabIndex = 1771
        Me.Edit_U006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Navy
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(380, 52)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(80, 20)
        Me.Label31.TabIndex = 1772
        Me.Label31.Text = "SB/IMEI"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.CheckBox_U002.TabIndex = 1770
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(680, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.TabIndex = 1427
        Me.Label3.Text = "“∞∂∞ï€èÿ"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U002
        '
        Me.Date_U002.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U002.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U002.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U002.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U002.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U002.Enabled = False
        Me.Date_U002.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U002.Location = New System.Drawing.Point(752, 52)
        Me.Date_U002.Name = "Date_U002"
        Me.Date_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U002.Size = New System.Drawing.Size(88, 20)
        Me.Date_U002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U002.TabIndex = 1426
        Me.Date_U002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U002.Value = Nothing
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
        Me.Combo_U001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo_U001.Location = New System.Drawing.Point(84, 4)
        Me.Combo_U001.MaxDropDownItems = 20
        Me.Combo_U001.Name = "Combo_U001"
        Me.Combo_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_U001.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U001.TabIndex = 20
        Me.Combo_U001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo_U001.Value = "Combo_U001"
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
        Me.Edit_U004.MaxLength = 200
        Me.Edit_U004.Multiline = True
        Me.Edit_U004.Name = "Edit_U004"
        Me.Edit_U004.ReadOnly = True
        Me.Edit_U004.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U004.Size = New System.Drawing.Size(520, 64)
        Me.Edit_U004.TabIndex = 100
        Me.Edit_U004.TabStop = False
        '
        'Combo_U002
        '
        Me.Combo_U002.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_U002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_U002.Enabled = False
        Me.Combo_U002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo_U002.Location = New System.Drawing.Point(84, 52)
        Me.Combo_U002.MaxDropDownItems = 35
        Me.Combo_U002.Name = "Combo_U002"
        Me.Combo_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_U002.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U002.TabIndex = 70
        Me.Combo_U002.Value = "Combo_U002"
        '
        'Panel_U2
        '
        Me.Panel_U2.AutoScroll = True
        Me.Panel_U2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_U2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_U2.Location = New System.Drawing.Point(460, 80)
        Me.Panel_U2.Name = "Panel_U2"
        Me.Panel_U2.Size = New System.Drawing.Size(520, 140)
        Me.Panel_U2.TabIndex = 90
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
        Me.Edit_U002.ReadOnly = True
        Me.Edit_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U002.Size = New System.Drawing.Size(292, 20)
        Me.Edit_U002.TabIndex = 50
        Me.Edit_U002.TabStop = False
        Me.Edit_U002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit_U005
        '
        Me.Edit_U005.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U005.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U005.LengthAsByte = True
        Me.Edit_U005.Location = New System.Drawing.Point(460, 284)
        Me.Edit_U005.MaxLength = 200
        Me.Edit_U005.Multiline = True
        Me.Edit_U005.Name = "Edit_U005"
        Me.Edit_U005.ReadOnly = True
        Me.Edit_U005.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U005.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U005.Size = New System.Drawing.Size(492, 76)
        Me.Edit_U005.TabIndex = 110
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
        Me.Edit_U003.ReadOnly = True
        Me.Edit_U003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U003.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U003.TabIndex = 60
        Me.Edit_U003.TabStop = False
        Me.Edit_U003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Label07_1.Text = "èCóùãíì_"
        Me.Label07_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U001
        '
        Me.Date_U001.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U001.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U001.Enabled = False
        Me.Date_U001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U001.Location = New System.Drawing.Point(864, 4)
        Me.Date_U001.Name = "Date_U001"
        Me.Date_U001.ReadOnly = True
        Me.Date_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U001.Size = New System.Drawing.Size(88, 20)
        Me.Date_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U001.TabIndex = 10
        Me.Date_U001.TabStop = False
        Me.Date_U001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U001.Value = Nothing
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
        Me.Edit_U001.ReadOnly = True
        Me.Edit_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U001.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U001.TabIndex = 30
        Me.Edit_U001.TabStop = False
        Me.Edit_U001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Panel_U1.TabIndex = 80
        '
        'pos
        '
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(0, 0)
        Me.pos.TabIndex = 0
        '
        'CheckBox_U001
        '
        Me.CheckBox_U001.AutoCheck = False
        Me.CheckBox_U001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U001.Location = New System.Drawing.Point(676, 8)
        Me.CheckBox_U001.Name = "CheckBox_U001"
        Me.CheckBox_U001.Size = New System.Drawing.Size(76, 16)
        Me.CheckBox_U001.TabIndex = 40
        Me.CheckBox_U001.TabStop = False
        Me.CheckBox_U001.Text = "íËäzèCóù"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(764, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 20)
        Me.Label19.TabIndex = 1769
        Me.Label19.Text = "éñåÃì˙"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U003
        '
        Me.Date_U003.BackColor = System.Drawing.SystemColors.Control
        Me.Date_U003.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U003.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U003.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date_U003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U003.Enabled = False
        Me.Date_U003.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U003.Location = New System.Drawing.Point(864, 28)
        Me.Date_U003.Name = "Date_U003"
        Me.Date_U003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U003.Size = New System.Drawing.Size(88, 20)
        Me.Date_U003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U003.TabIndex = 1768
        Me.Date_U003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U003.Value = Nothing
        '
        'Ck_atri_flg
        '
        Me.Ck_atri_flg.AutoCheck = False
        Me.Ck_atri_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Ck_atri_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Ck_atri_flg.Location = New System.Drawing.Point(916, 248)
        Me.Ck_atri_flg.Name = "Ck_atri_flg"
        Me.Ck_atri_flg.Size = New System.Drawing.Size(84, 16)
        Me.Ck_atri_flg.TabIndex = 1725
        Me.Ck_atri_flg.TabStop = False
        Me.Ck_atri_flg.Text = "Ck_atri_flg"
        Me.Ck_atri_flg.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 1714
        Me.Label4.Text = "∂≈"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLU001
        '
        Me.CLU001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU001.Location = New System.Drawing.Point(916, 136)
        Me.CLU001.Name = "CLU001"
        Me.CLU001.Size = New System.Drawing.Size(52, 16)
        Me.CLU001.TabIndex = 1712
        Me.CLU001.Text = "CLU001"
        Me.CLU001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU001.Visible = False
        '
        'CLU002
        '
        Me.CLU002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU002.Location = New System.Drawing.Point(916, 156)
        Me.CLU002.Name = "CLU002"
        Me.CLU002.Size = New System.Drawing.Size(52, 16)
        Me.CLU002.TabIndex = 1711
        Me.CLU002.Text = "CLU002"
        Me.CLU002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU002.Visible = False
        '
        'CL004
        '
        Me.CL004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL004.Location = New System.Drawing.Point(856, 196)
        Me.CL004.Name = "CL004"
        Me.CL004.Size = New System.Drawing.Size(52, 16)
        Me.CL004.TabIndex = 1710
        Me.CL004.Text = "CL004"
        Me.CL004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL004.Visible = False
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(856, 176)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(52, 16)
        Me.CL003.TabIndex = 1709
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(856, 156)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1708
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(856, 136)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1707
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Edit010
        '
        Me.Edit010.BackColor = System.Drawing.SystemColors.Control
        Me.Edit010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit010.Enabled = False
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(520, 192)
        Me.Edit010.MaxLength = 400
        Me.Edit010.Name = "Edit010"
        Me.Edit010.ReadOnly = True
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(300, 20)
        Me.Edit010.TabIndex = 1653
        Me.Edit010.TabStop = False
        Me.Edit010.Text = "Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†"
        Me.Edit010.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit009
        '
        Me.Edit009.BackColor = System.Drawing.SystemColors.Control
        Me.Edit009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit009.Enabled = False
        Me.Edit009.HighlightText = True
        Me.Edit009.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit009.LengthAsByte = True
        Me.Edit009.Location = New System.Drawing.Point(520, 172)
        Me.Edit009.MaxLength = 60
        Me.Edit009.Name = "Edit009"
        Me.Edit009.ReadOnly = True
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(300, 20)
        Me.Edit009.TabIndex = 1652
        Me.Edit009.TabStop = False
        Me.Edit009.Text = "Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†"
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Mask1
        '
        Me.Mask1.BackColor = System.Drawing.SystemColors.Control
        Me.Mask1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask1.Enabled = False
        Me.Mask1.Format = New GrapeCity.Win.Input.MaskFormat("Åß \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(520, 152)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.ReadOnly = True
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(76, 20)
        Me.Mask1.TabIndex = 1651
        Me.Mask1.TabStop = False
        Me.Mask1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Label013.TabIndex = 1706
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
        Me.Edit901.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit901.Size = New System.Drawing.Size(92, 20)
        Me.Edit901.TabIndex = 1705
        Me.Edit901.TabStop = False
        Me.Edit901.Text = "EDIT901"
        Me.Edit901.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        Me.Edit901.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit902.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit902.Size = New System.Drawing.Size(156, 20)
        Me.Edit902.TabIndex = 1703
        Me.Edit902.TabStop = False
        Me.Edit902.Text = "Edit902"
        Me.Edit902.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        Me.Edit902.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(296, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 20)
        Me.Label20.TabIndex = 1701
        Me.Label20.Text = "ì¸â◊íSìñ"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo003
        '
        Me.Combo003.BackColor = System.Drawing.SystemColors.Control
        Me.Combo003.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo003.Enabled = False
        Me.Combo003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo003.Location = New System.Drawing.Point(376, 56)
        Me.Combo003.MaxDropDownItems = 20
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(184, 20)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 1642
        Me.Combo003.TabStop = False
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
        Me.Label18.TabIndex = 1700
        Me.Label18.Text = "ì¸â◊ãÊï™"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo002
        '
        Me.Combo002.BackColor = System.Drawing.SystemColors.Control
        Me.Combo002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo002.Enabled = False
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo002.Location = New System.Drawing.Point(96, 56)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(196, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 1641
        Me.Combo002.TabStop = False
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
        Me.Edit000.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit000.Size = New System.Drawing.Size(68, 20)
        Me.Edit000.TabIndex = 10
        Me.Edit000.Text = "AS1234567"
        Me.Edit000.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit000.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 1699
        Me.Label7.Text = "éÛïtéÌï "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Navy
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(296, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 20)
        Me.Label21.TabIndex = 1716
        Me.Label21.Text = "QG Care No"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Edit011.ReadOnly = True
        Me.Edit011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit011.Size = New System.Drawing.Size(92, 20)
        Me.Edit011.TabIndex = 1640
        Me.Edit011.TabStop = False
        Me.Edit011.Text = "9999"
        Me.Edit011.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Combo001
        '
        Me.Combo001.BackColor = System.Drawing.SystemColors.Control
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Enabled = False
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo001.Location = New System.Drawing.Point(96, 32)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1638
        Me.Combo001.TabStop = False
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
        Me.Label014.TabIndex = 1695
        Me.Label014.Text = "èCóùéÌï "
        Me.Label014.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo004
        '
        Me.Combo004.AutoSelect = True
        Me.Combo004.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo004.Location = New System.Drawing.Point(96, 216)
        Me.Combo004.MaxDropDownItems = 20
        Me.Combo004.Name = "Combo004"
        Me.Combo004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo004.Size = New System.Drawing.Size(164, 20)
        Me.Combo004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo004.TabIndex = 15
        Me.Combo004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Label13.TabIndex = 1682
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
        Me.Label012.TabIndex = 1694
        Me.Label012.Text = "ìdòbî‘çÜ2"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date004
        '
        Me.Date004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date004.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date004.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date004.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date004.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date004.Location = New System.Drawing.Point(904, 48)
        Me.Date004.Name = "Date004"
        Me.Date004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date004.Size = New System.Drawing.Size(88, 20)
        Me.Date004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date004.TabIndex = 15
        Me.Date004.TabStop = False
        Me.Date004.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date004.Value = Nothing
        '
        'Date003
        '
        Me.Date003.BackColor = System.Drawing.SystemColors.Control
        Me.Date003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date003.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date003.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date003.Enabled = False
        Me.Date003.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date003.Location = New System.Drawing.Point(904, 8)
        Me.Date003.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date003.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date003.Name = "Date003"
        Me.Date003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date003.Size = New System.Drawing.Size(112, 20)
        Me.Date003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date003.TabIndex = 1662
        Me.Date003.TabStop = False
        Me.Date003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date003.Value = Nothing
        '
        'Edit006
        '
        Me.Edit006.BackColor = System.Drawing.SystemColors.Control
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Enabled = False
        Me.Edit006.Format = "KAa"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(96, 172)
        Me.Edit006.MaxLength = 15
        Me.Edit006.Name = "Edit006"
        Me.Edit006.ReadOnly = True
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(196, 20)
        Me.Edit006.TabIndex = 1648
        Me.Edit006.TabStop = False
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit008
        '
        Me.Edit008.BackColor = System.Drawing.SystemColors.Control
        Me.Edit008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit008.Enabled = False
        Me.Edit008.Format = "9#"
        Me.Edit008.HighlightText = True
        Me.Edit008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit008.LengthAsByte = True
        Me.Edit008.Location = New System.Drawing.Point(376, 172)
        Me.Edit008.MaxLength = 14
        Me.Edit008.Name = "Edit008"
        Me.Edit008.ReadOnly = True
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(112, 20)
        Me.Edit008.TabIndex = 1650
        Me.Edit008.TabStop = False
        Me.Edit008.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit007
        '
        Me.Edit007.BackColor = System.Drawing.SystemColors.Control
        Me.Edit007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit007.Enabled = False
        Me.Edit007.Format = "9#"
        Me.Edit007.HighlightText = True
        Me.Edit007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit007.LengthAsByte = True
        Me.Edit007.Location = New System.Drawing.Point(376, 152)
        Me.Edit007.MaxLength = 14
        Me.Edit007.Name = "Edit007"
        Me.Edit007.ReadOnly = True
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(112, 20)
        Me.Edit007.TabIndex = 1649
        Me.Edit007.TabStop = False
        Me.Edit007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit005
        '
        Me.Edit005.BackColor = System.Drawing.SystemColors.Control
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.Enabled = False
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(96, 152)
        Me.Edit005.MaxLength = 30
        Me.Edit005.Name = "Edit005"
        Me.Edit005.ReadOnly = True
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(196, 20)
        Me.Edit005.TabIndex = 1647
        Me.Edit005.TabStop = False
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label011
        '
        Me.Label011.BackColor = System.Drawing.Color.Navy
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.ForeColor = System.Drawing.Color.White
        Me.Label011.Location = New System.Drawing.Point(296, 152)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(80, 20)
        Me.Label011.TabIndex = 1678
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
        Me.Label010.TabIndex = 1677
        Me.Label010.Text = "Ç®ãqólñº"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Navy
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(824, 48)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 20)
        Me.Label36.TabIndex = 1685
        Me.Label36.Text = "å©êœì˙"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(824, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 20)
        Me.Label35.TabIndex = 1684
        Me.Label35.Text = "éÛïtì˙"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 640)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(864, 16)
        Me.msg.TabIndex = 1702
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit004
        '
        Me.Edit004.BackColor = System.Drawing.SystemColors.Control
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.Enabled = False
        Me.Edit004.Format = "9#aA@"
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(536, 104)
        Me.Edit004.MaxLength = 25
        Me.Edit004.Name = "Edit004"
        Me.Edit004.ReadOnly = True
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(112, 20)
        Me.Edit004.TabIndex = 1646
        Me.Edit004.TabStop = False
        Me.Edit004.Text = "1234567890123456789012345"
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label006
        '
        Me.Label006.BackColor = System.Drawing.Color.Navy
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.ForeColor = System.Drawing.Color.White
        Me.Label006.Location = New System.Drawing.Point(452, 104)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(84, 20)
        Me.Label006.TabIndex = 1676
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
        Me.Label005.TabIndex = 1675
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
        Me.Label003.TabIndex = 1674
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
        Me.Label004.TabIndex = 1679
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
        Me.Edit002.ReadOnly = True
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(48, 20)
        Me.Edit002.TabIndex = 1645
        Me.Edit002.TabStop = False
        Me.Edit002.Text = "9999"
        Me.Edit002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit001.ReadOnly = True
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(48, 20)
        Me.Edit001.TabIndex = 1643
        Me.Edit001.TabStop = False
        Me.Edit001.Text = "9999"
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit003
        '
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.Enabled = False
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(536, 80)
        Me.Edit003.MaxLength = 20
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(112, 20)
        Me.Edit003.TabIndex = 1644
        Me.Edit003.TabStop = False
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(16, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 1720
        Me.Label9.Text = "éÛïtî‘çÜ"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLM001
        '
        Me.CLM001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLM001.Location = New System.Drawing.Point(920, 196)
        Me.CLM001.Name = "CLM001"
        Me.CLM001.Size = New System.Drawing.Size(48, 16)
        Me.CLM001.TabIndex = 1722
        Me.CLM001.Text = "CLM001"
        Me.CLM001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLM001.Visible = False
        '
        'tax_rate
        '
        Me.tax_rate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.tax_rate.Location = New System.Drawing.Point(908, 636)
        Me.tax_rate.Name = "tax_rate"
        Me.tax_rate.Size = New System.Drawing.Size(40, 16)
        Me.tax_rate.TabIndex = 1723
        Me.tax_rate.Text = "1"
        Me.tax_rate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tax_rate.Visible = False
        '
        'CLM003
        '
        Me.CLM003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLM003.Location = New System.Drawing.Point(920, 216)
        Me.CLM003.Name = "CLM003"
        Me.CLM003.Size = New System.Drawing.Size(48, 16)
        Me.CLM003.TabIndex = 1724
        Me.CLM003.Text = "CLM003"
        Me.CLM003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLM003.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(460, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 1726
        Me.Label2.Text = "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Edit012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit012.Size = New System.Drawing.Size(116, 20)
        Me.Edit012.TabIndex = 16
        Me.Edit012.Text = "9999"
        Me.Edit012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Number001
        '
        Me.Number001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Number001.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Enabled = False
        Me.Number001.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(804, 132)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(52, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1732
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(652, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 1733
        Me.Label10.Text = "ï€èÿå¿ìxäz"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'apse
        '
        Me.apse.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.apse.Location = New System.Drawing.Point(404, 656)
        Me.apse.Name = "apse"
        Me.apse.Size = New System.Drawing.Size(40, 16)
        Me.apse.TabIndex = 1734
        Me.apse.Text = "apse"
        Me.apse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.apse.Visible = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(688, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 20)
        Me.Label12.TabIndex = 1741
        Me.Label12.Text = "óaÇ©ÇËã‡"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number002
        '
        Me.Number002.BackColor = System.Drawing.SystemColors.Control
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number002.Enabled = False
        Me.Number002.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number002.HighlightText = True
        Me.Number002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number002.Location = New System.Drawing.Point(768, 216)
        Me.Number002.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number002.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(52, 20)
        Me.Number002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 1740
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'NumberN004
        '
        Me.NumberN004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN004.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN004.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN004.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN004.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN004.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN004.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN004.Enabled = False
        Me.NumberN004.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN004.HighlightText = True
        Me.NumberN004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN004.Location = New System.Drawing.Point(348, 672)
        Me.NumberN004.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN004.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN004.Name = "NumberN004"
        Me.NumberN004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN004.Size = New System.Drawing.Size(48, 16)
        Me.NumberN004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN004.TabIndex = 1747
        Me.NumberN004.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN004.Value = Nothing
        Me.NumberN004.Visible = False
        '
        'NumberN003
        '
        Me.NumberN003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN003.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN003.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN003.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN003.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN003.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN003.Enabled = False
        Me.NumberN003.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN003.HighlightText = True
        Me.NumberN003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN003.Location = New System.Drawing.Point(352, 656)
        Me.NumberN003.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN003.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN003.Name = "NumberN003"
        Me.NumberN003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN003.Size = New System.Drawing.Size(48, 16)
        Me.NumberN003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN003.TabIndex = 1746
        Me.NumberN003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN003.Value = Nothing
        Me.NumberN003.Visible = False
        '
        'NumberN005
        '
        Me.NumberN005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN005.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN005.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN005.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN005.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN005.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN005.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN005.Enabled = False
        Me.NumberN005.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN005.HighlightText = True
        Me.NumberN005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN005.Location = New System.Drawing.Point(456, 656)
        Me.NumberN005.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NumberN005.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN005.Name = "NumberN005"
        Me.NumberN005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN005.Size = New System.Drawing.Size(40, 16)
        Me.NumberN005.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN005.TabIndex = 1732
        Me.NumberN005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN005.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumberN005.Visible = False
        '
        'NumberN006
        '
        Me.NumberN006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN006.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN006.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN006.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN006.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN006.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN006.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN006.Enabled = False
        Me.NumberN006.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN006.HighlightText = True
        Me.NumberN006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN006.Location = New System.Drawing.Point(500, 656)
        Me.NumberN006.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NumberN006.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN006.Name = "NumberN006"
        Me.NumberN006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN006.Size = New System.Drawing.Size(40, 16)
        Me.NumberN006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN006.TabIndex = 1748
        Me.NumberN006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN006.Value = New Decimal(New Integer() {6, 0, 0, 0})
        Me.NumberN006.Visible = False
        '
        'NumberN008
        '
        Me.NumberN008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN008.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN008.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN008.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN008.Enabled = False
        Me.NumberN008.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008.HighlightText = True
        Me.NumberN008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN008.Location = New System.Drawing.Point(452, 672)
        Me.NumberN008.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN008.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN008.Name = "NumberN008"
        Me.NumberN008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN008.Size = New System.Drawing.Size(48, 16)
        Me.NumberN008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008.TabIndex = 1750
        Me.NumberN008.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN008.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN008.Value = Nothing
        Me.NumberN008.Visible = False
        '
        'NumberN007
        '
        Me.NumberN007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN007.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN007.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN007.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN007.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN007.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN007.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN007.Enabled = False
        Me.NumberN007.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN007.HighlightText = True
        Me.NumberN007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN007.Location = New System.Drawing.Point(400, 672)
        Me.NumberN007.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN007.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN007.Name = "NumberN007"
        Me.NumberN007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN007.Size = New System.Drawing.Size(48, 16)
        Me.NumberN007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN007.TabIndex = 1749
        Me.NumberN007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN007.Value = Nothing
        Me.NumberN007.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label14.Location = New System.Drawing.Point(720, 640)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 1751
        Me.Label14.Text = "Ãﬂ◊Ω"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Visible = False
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label24.Location = New System.Drawing.Point(772, 640)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 16)
        Me.Label24.TabIndex = 1752
        Me.Label24.Text = "å≈íË"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label24.Visible = False
        '
        'CK_own_flg
        '
        Me.CK_own_flg.AutoCheck = False
        Me.CK_own_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CK_own_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CK_own_flg.Location = New System.Drawing.Point(912, 232)
        Me.CK_own_flg.Name = "CK_own_flg"
        Me.CK_own_flg.Size = New System.Drawing.Size(84, 16)
        Me.CK_own_flg.TabIndex = 1753
        Me.CK_own_flg.TabStop = False
        Me.CK_own_flg.Text = "CK_own_flg"
        Me.CK_own_flg.Visible = False
        '
        'Date001
        '
        Me.Date001.BackColor = System.Drawing.SystemColors.Control
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date001.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date001.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Enabled = False
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(732, 80)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(88, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1756
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Label007.TabIndex = 1757
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
        Me.Label002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label002.Size = New System.Drawing.Size(296, 20)
        Me.Label002.TabIndex = 1759
        Me.Label002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Label001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label001.Size = New System.Drawing.Size(296, 20)
        Me.Label001.TabIndex = 1758
        Me.Label001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(652, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 20)
        Me.Label15.TabIndex = 1765
        Me.Label15.Text = "ñ∆ê”"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number003
        '
        Me.Number003.BackColor = System.Drawing.SystemColors.Control
        Me.Number003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number003.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number003.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number003.Enabled = False
        Me.Number003.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number003.HighlightText = True
        Me.Number003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number003.Location = New System.Drawing.Point(732, 56)
        Me.Number003.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number003.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number003.Name = "Number003"
        Me.Number003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number003.Size = New System.Drawing.Size(52, 20)
        Me.Number003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.TabIndex = 1764
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number003.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(264, 216)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 20)
        Me.Label25.TabIndex = 1767
        Me.Label25.Text = "éñåÃèÛãµ"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo005
        '
        Me.Combo005.BackColor = System.Drawing.SystemColors.Control
        Me.Combo005.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo005.Enabled = False
        Me.Combo005.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo005.Location = New System.Drawing.Point(348, 216)
        Me.Combo005.MaxDropDownItems = 20
        Me.Combo005.Name = "Combo005"
        Me.Combo005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo005.Size = New System.Drawing.Size(108, 20)
        Me.Combo005.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo005.TabIndex = 1766
        Me.Combo005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo005.Value = "Combo005"
        '
        'CL005
        '
        Me.CL005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL005.Location = New System.Drawing.Point(856, 216)
        Me.CL005.Name = "CL005"
        Me.CL005.Size = New System.Drawing.Size(52, 16)
        Me.CL005.TabIndex = 1768
        Me.CL005.Text = "CL005"
        Me.CL005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL005.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(784, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 1769
        Me.Label16.Text = "Åiê≈î≤Åj"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(784, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 16)
        Me.Label17.TabIndex = 1770
        Me.Label17.Text = "Åiê≈çûÅj"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kengen
        '
        Me.kengen.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.kengen.Location = New System.Drawing.Point(388, 0)
        Me.kengen.Name = "kengen"
        Me.kengen.Size = New System.Drawing.Size(52, 16)
        Me.kengen.TabIndex = 1771
        Me.kengen.Text = "kengen"
        Me.kengen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.kengen.Visible = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(276, 660)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 1772
        Me.Button6.TabStop = False
        Me.Button6.Text = "ñ‚çáÇπ"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(452, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 20)
        Me.Label22.TabIndex = 1778
        Me.Label22.Text = "îÃé–âÑí∑èÓïÒ"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Edit013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit013.Size = New System.Drawing.Size(284, 20)
        Me.Edit013.TabIndex = 1777
        Me.Edit013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(600, 660)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1842
        Me.Button3.TabStop = False
        Me.Button3.Text = "ï Noè∆âÔ"
        '
        'GRP
        '
        Me.GRP.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.GRP.Location = New System.Drawing.Point(396, 108)
        Me.GRP.Name = "GRP"
        Me.GRP.Size = New System.Drawing.Size(52, 16)
        Me.GRP.TabIndex = 1843
        Me.GRP.Text = "GRP"
        Me.GRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GRP.Visible = False
        '
        'NumberN008_Bk
        '
        Me.NumberN008_Bk.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008_Bk.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008_Bk.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN008_Bk.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008_Bk.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008_Bk.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN008_Bk.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN008_Bk.Enabled = False
        Me.NumberN008_Bk.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008_Bk.HighlightText = True
        Me.NumberN008_Bk.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN008_Bk.Location = New System.Drawing.Point(860, 248)
        Me.NumberN008_Bk.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN008_Bk.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN008_Bk.Name = "NumberN008_Bk"
        Me.NumberN008_Bk.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN008_Bk.Size = New System.Drawing.Size(52, 16)
        Me.NumberN008_Bk.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008_Bk.TabIndex = 1845
        Me.NumberN008_Bk.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN008_Bk.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN008_Bk.Value = Nothing
        Me.NumberN008_Bk.Visible = False
        '
        'NumberN007_Bk
        '
        Me.NumberN007_Bk.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN007_Bk.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN007_Bk.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN007_Bk.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN007_Bk.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN007_Bk.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN007_Bk.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN007_Bk.Enabled = False
        Me.NumberN007_Bk.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN007_Bk.HighlightText = True
        Me.NumberN007_Bk.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN007_Bk.Location = New System.Drawing.Point(808, 248)
        Me.NumberN007_Bk.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN007_Bk.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN007_Bk.Name = "NumberN007_Bk"
        Me.NumberN007_Bk.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN007_Bk.Size = New System.Drawing.Size(52, 16)
        Me.NumberN007_Bk.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN007_Bk.TabIndex = 1844
        Me.NumberN007_Bk.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN007_Bk.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN007_Bk.Value = Nothing
        Me.NumberN007_Bk.Visible = False
        '
        'Number001_nTax
        '
        Me.Number001_nTax.BackColor = System.Drawing.SystemColors.Control
        Me.Number001_nTax.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001_nTax.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001_nTax.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001_nTax.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001_nTax.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001_nTax.Enabled = False
        Me.Number001_nTax.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001_nTax.HighlightText = True
        Me.Number001_nTax.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001_nTax.Location = New System.Drawing.Point(732, 32)
        Me.Number001_nTax.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001_nTax.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001_nTax.Name = "Number001_nTax"
        Me.Number001_nTax.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001_nTax.Size = New System.Drawing.Size(52, 20)
        Me.Number001_nTax.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001_nTax.TabIndex = 1848
        Me.Number001_nTax.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001_nTax.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'CL006
        '
        Me.CL006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL006.Location = New System.Drawing.Point(856, 232)
        Me.CL006.Name = "CL006"
        Me.CL006.Size = New System.Drawing.Size(52, 16)
        Me.CL006.TabIndex = 1853
        Me.CL006.Text = "CL006"
        Me.CL006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL006.Visible = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Navy
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(120, 240)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 20)
        Me.Label23.TabIndex = 1852
        Me.Label23.Text = "MobileéÌï "
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo006
        '
        Me.Combo006.BackColor = System.Drawing.SystemColors.Control
        Me.Combo006.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo006.Enabled = False
        Me.Combo006.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo006.Location = New System.Drawing.Point(204, 240)
        Me.Combo006.MaxDropDownItems = 20
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(164, 20)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 1851
        Me.Combo006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo006.Value = "Combo006"
        '
        'Date007
        '
        Me.Date007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date007.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date007.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date007.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date007.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date007.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date007.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date007.Location = New System.Drawing.Point(904, 68)
        Me.Date007.Name = "Date007"
        Me.Date007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date007.Size = New System.Drawing.Size(88, 20)
        Me.Date007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date007.TabIndex = 1864
        Me.Date007.TabStop = False
        Me.Date007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date007.Value = Nothing
        '
        'Label016
        '
        Me.Label016.BackColor = System.Drawing.Color.Navy
        Me.Label016.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label016.ForeColor = System.Drawing.Color.White
        Me.Label016.Location = New System.Drawing.Point(824, 88)
        Me.Label016.Name = "Label016"
        Me.Label016.Size = New System.Drawing.Size(80, 20)
        Me.Label016.TabIndex = 1863
        Me.Label016.Text = "ïîïiéÛóÃì˙"
        Me.Label016.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label015
        '
        Me.Label015.BackColor = System.Drawing.Color.Navy
        Me.Label015.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label015.ForeColor = System.Drawing.Color.White
        Me.Label015.Location = New System.Drawing.Point(824, 68)
        Me.Label015.Name = "Label015"
        Me.Label015.Size = New System.Drawing.Size(80, 20)
        Me.Label015.TabIndex = 1862
        Me.Label015.Text = "ïîïiî≠íçì˙"
        Me.Label015.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date008
        '
        Me.Date008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date008.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date008.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date008.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date008.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date008.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date008.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date008.Location = New System.Drawing.Point(904, 88)
        Me.Date008.Name = "Date008"
        Me.Date008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date008.Size = New System.Drawing.Size(88, 20)
        Me.Date008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date008.TabIndex = 1861
        Me.Date008.TabStop = False
        Me.Date008.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date008.Value = Nothing
        '
        'Label017
        '
        Me.Label017.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label017.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label017.ForeColor = System.Drawing.Color.Green
        Me.Label017.Location = New System.Drawing.Point(204, 4)
        Me.Label017.Name = "Label017"
        Me.Label017.Size = New System.Drawing.Size(132, 24)
        Me.Label017.TabIndex = 1860
        Me.Label017.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(516, 660)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(72, 24)
        Me.Button9.TabIndex = 1865
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
        Me.CheckBox1.TabIndex = 1873
        Me.CheckBox1.TabStop = False
        '
        'cntact2
        '
        Me.cntact2.BackColor = System.Drawing.SystemColors.Control
        Me.cntact2.Location = New System.Drawing.Point(268, 132)
        Me.cntact2.Name = "cntact2"
        Me.cntact2.Size = New System.Drawing.Size(104, 16)
        Me.cntact2.TabIndex = 1872
        Me.cntact2.Text = "cntact2"
        Me.cntact2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cntact1
        '
        Me.cntact1.BackColor = System.Drawing.SystemColors.Control
        Me.cntact1.Location = New System.Drawing.Point(96, 132)
        Me.cntact1.Name = "cntact1"
        Me.cntact1.Size = New System.Drawing.Size(100, 16)
        Me.cntact1.TabIndex = 1871
        Me.cntact1.Text = "cntact1"
        Me.cntact1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(372, 128)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 20)
        Me.Label26.TabIndex = 1870
        Me.Label26.Text = "∫›¿∏ƒäÆóπ"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Navy
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(200, 128)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 20)
        Me.Label27.TabIndex = 1869
        Me.Label27.Text = "∫›¿∏ƒíSìñ"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Navy
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(16, 128)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 20)
        Me.Label28.TabIndex = 1868
        Me.Label28.Text = "ç≈èI∫›¿∏ƒì˙éû"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(536, 240)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 20)
        Me.Label29.TabIndex = 1877
        Me.Label29.Text = "iMVî‘çÜ"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Edit015.Location = New System.Drawing.Point(644, 240)
        Me.Edit015.MaxLength = 9
        Me.Edit015.Name = "Edit015"
        Me.Edit015.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit015.Size = New System.Drawing.Size(72, 20)
        Me.Edit015.TabIndex = 1875
        Me.Edit015.Text = "9999"
        Me.Edit015.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(376, 240)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(84, 20)
        Me.Label30.TabIndex = 1876
        Me.Label30.Text = "Ref."
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Edit014.Location = New System.Drawing.Point(460, 240)
        Me.Edit014.MaxLength = 10
        Me.Edit014.Name = "Edit014"
        Me.Edit014.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit014.Size = New System.Drawing.Size(72, 20)
        Me.Edit014.TabIndex = 1874
        Me.Edit014.Text = "9999"
        Me.Edit014.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(652, 104)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 20)
        Me.Label32.TabIndex = 1879
        Me.Label32.Text = "âﬂé∏"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CkBox01_N
        '
        Me.CkBox01_N.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_N.Location = New System.Drawing.Point(780, 108)
        Me.CkBox01_N.Name = "CkBox01_N"
        Me.CkBox01_N.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_N.TabIndex = 1881
        Me.CkBox01_N.Text = "ñ≥"
        '
        'CkBox01_Y
        '
        Me.CkBox01_Y.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_Y.Location = New System.Drawing.Point(740, 108)
        Me.CkBox01_Y.Name = "CkBox01_Y"
        Me.CkBox01_Y.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_Y.TabIndex = 1880
        Me.CkBox01_Y.Text = "óL"
        '
        'SBM
        '
        Me.SBM.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.SBM.Location = New System.Drawing.Point(164, 664)
        Me.SBM.Name = "SBM"
        Me.SBM.Size = New System.Drawing.Size(32, 16)
        Me.SBM.TabIndex = 1887
        Me.SBM.Text = "SBM"
        Me.SBM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SBM.Visible = False
        '
        'Button97
        '
        Me.Button97.BackColor = System.Drawing.SystemColors.Control
        Me.Button97.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button97.Location = New System.Drawing.Point(764, 660)
        Me.Button97.Name = "Button97"
        Me.Button97.Size = New System.Drawing.Size(68, 24)
        Me.Button97.TabIndex = 339
        Me.Button97.Text = "S/Nóöó"
        Me.Button97.Visible = False
        '
        'sn_n
        '
        Me.sn_n.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.sn_n.Location = New System.Drawing.Point(840, 640)
        Me.sn_n.Name = "sn_n"
        Me.sn_n.Size = New System.Drawing.Size(48, 16)
        Me.sn_n.TabIndex = 1890
        Me.sn_n.Text = "sn_n"
        Me.sn_n.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.sn_n.Visible = False
        '
        'Date015
        '
        Me.Date015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date015.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.DropDownCalendar.FocusDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date015.DropDownCalendar.SelectedDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2019, 9, 18, 0, 0, 0, 0))
        Me.Date015.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date015.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date015.Location = New System.Drawing.Point(904, 28)
        Me.Date015.Name = "Date015"
        Me.Date015.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date015.Size = New System.Drawing.Size(112, 20)
        Me.Date015.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date015.TabIndex = 15
        Me.Date015.TabStop = False
        Me.Date015.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date015.Value = Nothing
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Navy
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(824, 28)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(80, 20)
        Me.Label34.TabIndex = 1892
        Me.Label34.Text = "êfífì˙"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Location = New System.Drawing.Point(720, 240)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(108, 16)
        Me.Label38.TabIndex = 1896
        Me.Label38.Text = "AC+êøãÅäzÅiê≈çûÅj"
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.SystemColors.Control
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.Location = New System.Drawing.Point(684, 660)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(68, 24)
        Me.Button14.TabIndex = 1843
        Me.Button14.Text = "ï€ë∂"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(956, 632)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 1897
        Me.Button4.Text = "WK"
        Me.Button4.Visible = False
        '
        'F10_Form11
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1026, 688)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Date015)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.sn_n)
        Me.Controls.Add(Me.Button97)
        Me.Controls.Add(Me.SBM)
        Me.Controls.Add(Me.CkBox01_N)
        Me.Controls.Add(Me.CkBox01_Y)
        Me.Controls.Add(Me.Panel_å©êœ)
        Me.Controls.Add(Me.Panel_éÛït)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Edit015)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Edit014)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cntact2)
        Me.Controls.Add(Me.cntact1)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Date007)
        Me.Controls.Add(Me.Label016)
        Me.Controls.Add(Me.Label015)
        Me.Controls.Add(Me.Date008)
        Me.Controls.Add(Me.Label017)
        Me.Controls.Add(Me.CL006)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.Number001_nTax)
        Me.Controls.Add(Me.NumberN008_Bk)
        Me.Controls.Add(Me.NumberN007_Bk)
        Me.Controls.Add(Me.GRP)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Edit013)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.kengen)
        Me.Controls.Add(Me.CL005)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Combo005)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.CK_own_flg)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.NumberN008)
        Me.Controls.Add(Me.NumberN007)
        Me.Controls.Add(Me.NumberN006)
        Me.Controls.Add(Me.NumberN004)
        Me.Controls.Add(Me.NumberN003)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.apse)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Edit012)
        Me.Controls.Add(Me.CLM003)
        Me.Controls.Add(Me.CLM001)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button0)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CLU001)
        Me.Controls.Add(Me.CLU002)
        Me.Controls.Add(Me.CL004)
        Me.Controls.Add(Me.CL003)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.CL001)
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
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Edit011)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label014)
        Me.Controls.Add(Me.Combo004)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label012)
        Me.Controls.Add(Me.Date004)
        Me.Controls.Add(Me.Date003)
        Me.Controls.Add(Me.Edit006)
        Me.Controls.Add(Me.Edit008)
        Me.Controls.Add(Me.Edit007)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Ck_atri_flg)
        Me.Controls.Add(Me.calc_cls)
        Me.Controls.Add(Me.tax_rate)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.NumberN005)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.msg)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F10_Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "å©êœì¸óÕ"
        Me.Panel_å©êœ.ResumeLayout(False)
        CType(Me.Number039, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number016, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number025, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number024, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number017, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Date_U001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_U1.ResumeLayout(False)
        CType(Me.Date_U003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit901, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit902, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN008_Bk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN007_Bk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  ãNìÆéû
    '********************************************************************
    Private Sub F10_Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  èâä˙èàóù
        ACES()      '**  å†å¿É`ÉFÉbÉN
        Inz_Dsp()   '**  èâä˙âÊñ ÉZÉbÉg
        Button12_Click(sender, e)

        If P_DBG = "True" Then 'ÉfÉoÉbÉNï\é¶
            'NumberN004.Visible = True : NumberN005.Visible = True
            NumberN003.Visible = True : NumberN006.Visible = True
            NumberN007.Visible = True : NumberN008.Visible = True
            apse.Visible = True : Label24.Visible = True ': Label14.Visible = True
            Number039.Visible = True

            kengen.Visible = True
            GRP.Visible = True
            Number001.Visible = True
            CL001.Visible = True
            CL002.Visible = True
            CL003.Visible = True
            CL004.Visible = True
            CL005.Visible = True
            CL006.Visible = True
            CLU001.Visible = True
            CLU002.Visible = True
            CLM001.Visible = True
            CLM003.Visible = True
            NumberN007_Bk.Visible = True
            NumberN008_Bk.Visible = True
            CK_own_flg.Visible = True
            Ck_atri_flg.Visible = True
            CHG.Visible = True
            SBM.Visible = True
            sn_n.Visible = True
        End If

    End Sub

    '********************************************************************
    '**  èâä˙èàóù
    '********************************************************************
    Sub inz()
        'Å~ï¬Ç∂ÇÈÇégópïsâ¬
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        'strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '008')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'DaList1.Fill(DsList1, "tax")
        'DB_CLOSE()
        'DtView1 = New DataView(DsList1.Tables("tax"), "", "", DataViewRowState.CurrentRows)
        'WK_tax = DtView1(0)("cls_code_name")

        'è¡îÔê≈ó¶
        Wk_TAX = tax_rate_get(Now) 'è¡îÔê≈ó¶éÊìæ
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0

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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='111'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            kengen.Text = DtView1(0)("access_cls")
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button1.Enabled = False : Button14.Enabled = False
                Case Is = "3"
                    Button1.Enabled = True : Button14.Enabled = True
                Case Is = "4"
                    Button1.Enabled = True : Button14.Enabled = True
            End Select
        Else
            kengen.Text = Nothing
            Button1.Enabled = False : Button14.Enabled = False
        End If
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='994'", "", DataViewRowState.CurrentRows) 'äÆóπìñì˙èCê≥â¬
        If DtView1.Count <> 0 Then
            SBM.Text = DtView1(0)("access_cls")
        Else
            SBM.Text = Nothing
        End If
    End Sub

    '********************************************************************
    '**  ÉRÉìÉ{É{ÉbÉNÉXÉZÉbÉg
    '********************************************************************
    Sub CmbSet()
        Cmb1()  'èCóùéÌï 
        Cmb2()  'å©êœíSìñ
        Cmb4()  'ìÔà’ìx
    End Sub
    Sub Cmb1()      'èCóùéÌï 
        DsCMB1.Clear()
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '001') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB1, "CLS_CODE_001")
        DB_CLOSE()
        Combo004.DataSource = DsCMB1.Tables("CLS_CODE_001")
        Combo004.DisplayMember = "cls_code_name"
        Combo004.ValueMember = "cls_code"
    End Sub
    Sub Cmb2()      'å©êœíSìñ
        DsCMB2.Clear()
        strSQL = "SELECT empl_code, name FROM ("
        strSQL += " SELECT empl_code, name, name_kana"
        strSQL += " FROM M01_EMPL"
        strSQL += " WHERE (delt_flg = 0) AND (brch_code = '" & P_EMPL_BRCH & "')"
        strSQL += " UNION"
        strSQL += " SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (empl_code = " & P_EMPL_NO & ")"
        strSQL += " UNION"
        strSQL += " SELECT T01_REP_MTR.repr_empl_code AS empl_code, M01_EMPL.name, M01_EMPL.name_kana"
        strSQL += " FROM T01_REP_MTR INNER JOIN M01_EMPL ON T01_REP_MTR.repr_empl_code = M01_EMPL.empl_code"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & Edit000.Text & "')"
        strSQL += ") M01_EMPL ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB2, "M01_EMPL")
        DB_CLOSE()
        Combo_M001.DataSource = DsCMB2.Tables("M01_EMPL")
        Combo_M001.DisplayMember = "name"
        Combo_M001.ValueMember = "empl_code"
    End Sub
    Sub Cmb4()      'ìÔà’ìx
        DsCMB4.Clear()
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '013') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB4, "CLS_CODE_013")
        DB_CLOSE()
        Combo_M003.DataSource = DsCMB4.Tables("CLS_CODE_013")
        Combo_M003.DisplayMember = "cls_code_name"
        Combo_M003.ValueMember = "cls_code"
    End Sub

    '********************************************************************
    '**  èâä˙âÊñ ÉZÉbÉg
    '********************************************************************
    Sub Inz_Dsp()
        P_PRT_F = "0"   'ïîïiâøäiñ‚çáÇπï[àÛç¸ÉtÉâÉO
        msg.Text = Nothing
        Number001.Value = 0 : Number001_nTax.Value = 0 : Number002.Value = 0 : Number003.Value = 0
        NumberN003.Value = 0 : NumberN004.Value = 0 : NumberN005.Value = 0
        NumberN006.Value = 0 : NumberN007.Value = 0 : NumberN008.Value = 0 : NumberN007_Bk.Value = 0 : NumberN008_Bk.Value = 0

        apse.Text = 0

        Button0.Enabled = True
        Button1.Enabled = False : Button14.Enabled = False
        Button2.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button9.Enabled = False
        Button80.Enabled = False
        Button97.Visible = False : sn_n.Text = "0"
        Button_S2.Enabled = False
        Edit000.Text = Nothing  'éÛïtî‘çÜ
        Edit000.ReadOnly = False : Edit000.TabStop = True : Edit000.BackColor = System.Drawing.SystemColors.Window

        Label5.Text = Nothing
        Label017.Text = Nothing

        Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True
        Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
        Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
        Label001.Visible = True : Label002.Visible = True : Label003.Visible = True : Label004.Visible = True : Label005.Visible = True : Label006.Visible = True : Label007.Visible = True
        Edit001.Visible = True : Edit002.Visible = True : Edit003.Visible = True : Edit004.Visible = True : Date001.Visible = True
        Edit003.Enabled = False

        Label001.Text = Nothing : Label002.Text = Nothing : Label002.BackColor = System.Drawing.SystemColors.Window
        Edit901.Text = Nothing
        Edit902.Text = Nothing
        Date001.Text = Nothing
        Date003.Enabled = False : Date003.Text = Nothing : Date003.BackColor = System.Drawing.SystemColors.Window
        Date004.Enabled = False : Date004.Text = Nothing : Date004.BackColor = System.Drawing.SystemColors.Window
        Date007.Enabled = False : Date007.Text = Nothing : Date007.BackColor = System.Drawing.SystemColors.Window
        Date008.Enabled = False : Date008.Text = Nothing : Date008.BackColor = System.Drawing.SystemColors.Window
        Date015.Enabled = False : Date015.Text = Nothing : Date015.BackColor = System.Drawing.SystemColors.Window
        Combo001.Text = Nothing
        Combo002.Text = Nothing
        Combo003.Text = Nothing
        Combo004.Enabled = False : Combo004.Text = Nothing : Combo004.BackColor = System.Drawing.SystemColors.Window
        Combo005.Text = Nothing
        Combo006.Text = Nothing
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
        Edit013.Text = Nothing
        Mask1.Text = Nothing
        Edit014.Text = Nothing
        Edit015.Text = Nothing
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
        CheckBox_U001.Checked = False : CheckBox_U001.AutoCheck = False
        CheckBox_U002.Checked = False : CheckBox_U002.AutoCheck = False
        CheckBox_U003.Checked = False : CheckBox_U003.AutoCheck = False
        CheckBox_M001.Checked = False : CheckBox_M001.AutoCheck = False
        Panel_U1.Controls.Clear()
        Panel_U2.Controls.Clear()

        Edit_M001.Enabled = False : Edit_M001.Text = Nothing : Edit_M001.BackColor = System.Drawing.SystemColors.Window
        Edit_M002.Enabled = False : Edit_M002.Text = Nothing : Edit_M002.BackColor = System.Drawing.SystemColors.Window
        Edit_M003.Enabled = False : Edit_M003.Text = Nothing : Edit_M003.BackColor = System.Drawing.SystemColors.Window
        Combo_M001.Enabled = False : Combo_M001.Text = Nothing : Combo_M001.BackColor = System.Drawing.SystemColors.Window
        Combo_M003.Enabled = False : Combo_M003.Text = Nothing : Combo_M003.BackColor = System.Drawing.SystemColors.Window
        Number011.Enabled = False : Number011.Value = 0 : Number011.BackColor = System.Drawing.SystemColors.Window
        Number012.Enabled = False : Number012.Value = 0 : Number012.BackColor = System.Drawing.SystemColors.Window
        Number013.Enabled = False : Number013.Value = 0 : Number013.BackColor = System.Drawing.SystemColors.Window
        Number014.Enabled = False : Number014.Value = 0 : Number014.BackColor = System.Drawing.SystemColors.Window
        Number015.Enabled = False : Number015.Value = 0 : Number015.BackColor = System.Drawing.SystemColors.Window
        Number016.Enabled = False : Number016.Value = 0 : Number016.BackColor = System.Drawing.SystemColors.Window
        Number017.Enabled = False : Number017.Value = 0 : Number017.BackColor = System.Drawing.SystemColors.Window
        Number018.Enabled = False : Number018.Value = 0 : Number018.BackColor = System.Drawing.SystemColors.Window
        Number021.Enabled = False : Number021.Value = 0 : Number021.BackColor = System.Drawing.SystemColors.Window
        Number022.Enabled = False : Number022.Value = 0 : Number022.BackColor = System.Drawing.SystemColors.Window
        Number023.Enabled = False : Number023.Value = 0 : Number023.BackColor = System.Drawing.SystemColors.Window
        Number024.Enabled = False : Number024.Value = 0 : Number024.BackColor = System.Drawing.SystemColors.Window
        Number025.Enabled = False : Number025.Value = 0 : Number025.BackColor = System.Drawing.SystemColors.Window
        Number026.Enabled = False : Number026.Value = 0 : Number026.BackColor = System.Drawing.SystemColors.Window
        Number027.Enabled = False : Number027.Value = 0 : Number027.BackColor = System.Drawing.SystemColors.Window
        Number028.Enabled = False : Number028.Value = 0 : Number028.BackColor = System.Drawing.SystemColors.Window
        Number031.Enabled = False : Number031.Value = 0 : Number031.BackColor = System.Drawing.SystemColors.Window
        Number032.Enabled = False : Number032.Value = 0 : Number032.BackColor = System.Drawing.SystemColors.Window
        Number033.Enabled = False : Number033.Value = 0 : Number033.BackColor = System.Drawing.SystemColors.Window
        Number034.Enabled = False : Number034.Value = 0 : Number034.BackColor = System.Drawing.SystemColors.Window
        Number035.Enabled = False : Number035.Value = 0 : Number035.BackColor = System.Drawing.SystemColors.Window
        Number036.Enabled = False : Number036.Value = 0 : Number036.BackColor = System.Drawing.SystemColors.Window
        Number037.Enabled = False : Number037.Value = 0 : Number037.BackColor = System.Drawing.SystemColors.Window
        Number038.Enabled = False : Number038.Value = 0 : Number038.BackColor = System.Drawing.SystemColors.Window

        Number019.Enabled = False : Number019.Value = 0 : Number019.BackColor = System.Drawing.SystemColors.Window
        Number029.Enabled = False : Number029.Value = 0 : Number029.BackColor = System.Drawing.SystemColors.Window
        Number039.Value = 0

        Button_M001.Enabled = False
        Panel_M1.Controls.Clear()
        P_DsList1.Clear()
        DsList1.Clear()

        CHG.Text = Nothing

        cntact1.Text = Nothing
        cntact2.Text = Nothing
        CheckBox1.Enabled = False : CheckBox1.Checked = False

        QA_F = "0"
        Label37.Visible = False
        CheckBox2.Visible = False
        CheckBox2.Checked = False

        Edit000.Focus()
    End Sub

    '********************************************************************
    '**  éÛïtî‘çÜEnter
    '********************************************************************
    Private Sub Edit000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Edit000.KeyDown
        If e.KeyCode = Keys.Enter Then
            inz_F = "0"
            Button12_Click(sender, e)
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
        DaList1.Fill(DsList1, "T03_REP_CMNT_2")

        'ïîïi
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
        DaList1.Fill(DsList1, "T04_REP_PART_MOTO")

        WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "seq", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DtView1(i)("ID_NO") = i
            Next
        End If
        WK_DtView1 = New DataView(DsList1.Tables("T04_REP_PART_MOTO"), "", "seq", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DtView1(i)("ID_NO") = i
            Next
        End If

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** èCóùèÓïÒÇfÇdÇs
    '********************************************************************
    Sub rep_scan()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Edit000.BackColor = System.Drawing.SystemColors.Window
        msg.Text = Nothing

        Edit000.Text = Trim(Edit000.Text)
        rep_sql()   '** èCóùèÓïÒÇfÇdÇs(SQL)

        If DtView1.Count = 0 Then
            Edit000.BackColor = System.Drawing.Color.Red
            msg.Text = "äYìñÇ∑ÇÈéÛïtî‘çÜÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
        Else
            Button0.Enabled = False
            Button1.Enabled = False : Button14.Enabled = False
            Button2.Enabled = True
            Button_S2.Enabled = True
            Button6.Enabled = True
            Button9.Enabled = True
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
                        MessageBox.Show("ëºïîèêèCóùÇÃÇΩÇﬂÅAéQè∆ÇÃÇ›", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        If Not IsDBNull(DtView1(0)("comp_date")) Then
                            If DtView1(0)("grup_code") = "63" And SBM.Text >= "3" And CDate(DtView1(0)("comp_date")) = Now.Date Then
                                HAITA_ON(Edit000.Text)  'HAITA_ON
                                Button1.Enabled = True : Button14.Enabled = True
                            Else
                                If P_tokubetu = "1" Then
                                    ANS = MessageBox.Show("ä˘Ç…äÆê¨ÇµÇƒÇ¢Ç‹Ç∑Ç™ÅAçXêVÇâ¬î\Ç…ÇµÇ‹Ç∑Ç©ÅB", "ämîF", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    If ANS = "6" Then  'ÇÕÇ¢
                                        HAITA_ON(Edit000.Text)  'HAITA_ON
                                        Button1.Enabled = True : Button14.Enabled = True
                                    End If
                                Else
                                    MessageBox.Show("äÆóπÇµÇƒÇ¢ÇÈÇΩÇﬂÅAéQè∆ÇÃÇ›", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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

            Edit000.ReadOnly = True : Edit000.TabStop = False : Edit000.BackColor = System.Drawing.SystemColors.Control
            Button80.Enabled = True
            Edit901.Text = DtView1(0)("rcpt_ent_empl_name")
            If Not IsDBNull(DtView1(0)("rcpt_brch_name")) Then Edit902.Text = DtView1(0)("rcpt_brch_name")
            CL001.Text = DtView1(0)("rcpt_cls")
            CL002.Text = DtView1(0)("arvl_cls")
            CL003.Text = DtView1(0)("arvl_empl")
            CL004.Text = DtView1(0)("rpar_cls")
            If Not IsDBNull(DtView1(0)("acdt_stts")) Then CL005.Text = DtView1(0)("acdt_stts")
            If Not IsDBNull(DtView1(0)("defe_cls")) Then CL006.Text = DtView1(0)("defe_cls")
            CLU001.Text = DtView1(0)("vndr_code")
            If CLU001.Text = "01" Then
                CheckBox_U001.Text = "íËäzèCóù"
                CheckBox_U003.Visible = True
            Else
                CheckBox_U001.Text = "ÇmÇèÇîÇÖ"
                CheckBox_U003.Visible = False
            End If
            CheckBox_U001.AutoCheck = True
            CLU002.Text = DtView1(0)("rpar_comp_code")

            If Not IsDBNull(DtView1(0)("store_accp_date")) Then Date001.Text = DtView1(0)("store_accp_date") Else Date001.Text = Nothing
            If Not IsDBNull(DtView1(0)("accp_date")) Then Date003.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView1(0)("accp_date")) ' Date003.Text = DtView1(0)("accp_date") Else Date003.Text = Nothing
            Date007.Enabled = True
            If Not IsDBNull(DtView1(0)("part_ordr_date")) Then Date007.Text = DtView1(0)("part_ordr_date")
            Date008.Enabled = True
            If Not IsDBNull(DtView1(0)("part_rcpt_date")) Then Date008.Text = DtView1(0)("part_rcpt_date")
            If Date003.Number <> 0 Then
                Label017.Text = "åoâﬂì˙êîÅF" & DateDiff(DateInterval.Day, CDate(Date003.Text).Date, Now.Date)
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

            Combo001.Text = DtView1(0)("rcpt_name")
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
            Edit003.Enabled = True

            Combo003.Text = DtView1(0)("arvl_empl_name")
            Cmb1()  'èCóùéÌï 
            Combo004.Enabled = True : Combo004.Text = DtView1(0)("rpar_cls_name")
            If Not IsDBNull(DtView1(0)("acdt_name")) Then Combo005.Text = DtView1(0)("acdt_name")
            If Not IsDBNull(DtView1(0)("defe_name")) Then Combo006.Text = DtView1(0)("defe_name")
            If Not IsDBNull(DtView1(0)("store_code")) Then Edit001.Text = DtView1(0)("store_code") Else Edit001.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_name")) Then Label001.Text = DtView1(0)("store_name") Else Label001.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_code")) Then Edit002.Text = DtView1(0)("dlvr_code") Else Edit002.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_name")) Then Label002.Text = DtView1(0)("dlvr_name") Else Label002.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_prsn")) Then Edit003.Text = DtView1(0)("store_prsn") Else Edit003.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_prsn")) Then Edit003.Text = DtView1(0)("store_prsn") Else Edit003.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_repr_no")) Then Edit004.Text = DtView1(0)("store_repr_no") Else Edit004.Text = Nothing

            If Not IsDBNull(DtView1(0)("grup_code")) Then GRP.Text = DtView1(0)("grup_code") Else GRP.Text = Nothing

            Edit005.Text = DtView1(0)("user_name")
            Edit006.Text = DtView1(0)("user_name_kana")
            Edit007.Text = DtView1(0)("tel1")
            Edit008.Text = DtView1(0)("tel2")

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
            If Not IsDBNull(DtView1(0)("menseki_amnt")) Then Number003.Value = DtView1(0)("menseki_amnt") Else Number003.Value = 0

            'APSE
            If CLU001.Text = "01" _
                And CL004.Text = "02" _
                And Date003.Number <> 0 Then
                apse.Text = APSE_GET(CLU002.Text, Date003.Text)
            Else
                apse.Text = "0"
            End If

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

            Combo_U001.Text = DtView1(0)("vndr_name")
            'rpar_comp() '**  èCóùïîèêÇrÇdÇs
            If Not IsDBNull(DtView1(0)("rpar_comp_name")) Then
                Combo_U002.Text = DtView1(0)("rpar_comp_name")
            End If

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
            If DtView1(0)("atri_flg") = "True" Then Ck_atri_flg.Checked = True Else Ck_atri_flg.Checked = False

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
                    edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(30, 20 * Line_No)
                    edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    edit(Line_No, en).Size = New System.Drawing.Size(150, 20)
                    edit(Line_No, en).Enabled = False
                    edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    edit(Line_No, en).Text = WK_DtView2(Line_No)("item_name")
                    edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
                    Panel_U1.Controls.Add(edit(Line_No, en))

                    'êîó 
                    en = 1
                    nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                    nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###0", "", "", "-", "", "", "")
                    nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                    nbrBox(Line_No, en).Enabled = False
                    nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###0", "", "", "-", "", "", "")
                    nbrBox(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 20 * Line_No)
                    nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).Size = New System.Drawing.Size(30, 20)
                    nbrBox(Line_No, en).Value = WK_DtView2(Line_No)("amnt")
                    If Trim(WK_DtView2(Line_No)("item_unit")) = Nothing And WK_DtView2(Line_No)("amnt") = 0 Then
                        nbrBox(Line_No, en).Visible = False
                    End If
                    Panel_U1.Controls.Add(nbrBox(Line_No, en))

                    'íPà 
                    en = 2
                    edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(210, 20 * Line_No)
                    edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    edit(Line_No, en).Size = New System.Drawing.Size(50, 20)
                    edit(Line_No, en).Enabled = False
                    edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    edit(Line_No, en).Text = WK_DtView2(Line_No)("item_unit")
                    edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
            CheckBox_M001.AutoCheck = True
            If Not IsDBNull(DtView2(0)("etmt_empl_code")) Then CLM001.Text = DtView2(0)("etmt_empl_code") Else CLM001.Text = Nothing
            If Not IsDBNull(DtView2(0)("tier")) Then CLM003.Text = DtView2(0)("tier") Else CLM003.Text = Nothing

            If Not IsDBNull(DtView2(0)("tech_rate1")) Then NumberN003.Value = DtView2(0)("tech_rate1") Else NumberN003.Value = 0
            If Not IsDBNull(DtView2(0)("fix1")) Then NumberN006.Value = DtView2(0)("fix1") Else NumberN006.Value = 0
            If Not IsDBNull(DtView2(0)("tech_rate2")) Then NumberN007.Value = DtView2(0)("tech_rate2") Else NumberN007.Value = 0
            If Not IsDBNull(DtView2(0)("part_rate2")) Then NumberN008.Value = DtView2(0)("part_rate2") Else NumberN008.Value = 0
            NumberN007_Bk.Value = NumberN007.Value
            NumberN008_Bk.Value = NumberN008.Value

            Date015.Enabled = True
            If Not IsDBNull(DtView2(0)("sindan_date")) Then
                'Date015.Text = DtView2(0)("sindan_date")
                Date015.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView1(0)("sindan_date"))
            End If

            If Not IsDBNull(DtView2(0)("tax_rate")) Then tax_rate.Text = DtView2(0)("tax_rate") Else tax_rate.Text = Wk_TAX
            Date004.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_date")) Then
                Date004.Text = DtView2(0)("etmt_date")
                Button5.Enabled = True
                tax(String.Format("{0:yyyy/MM/dd}", CDate(Date004.Text)))
            Else
                Button5.Enabled = False
            End If

            Cmb2()  'å©êœíSìñ
            If Not IsDBNull(DtView2(0)("etmt_empl_name")) Then Combo_M001.Text = DtView2(0)("etmt_empl_name") Else Combo_M001.Text = Nothing
            Combo_M001.Enabled = True
            If Not IsDBNull(DtView2(0)("vndr_repr_no")) Then Edit_M001.Text = DtView2(0)("vndr_repr_no") Else Edit_M001.Text = Nothing

            If CK_own_flg.Checked = True Then    'é©é–èCóù
                Edit_M001.Visible = False : Label_M01.Visible = False
                'Cmb4()  'ìÔà’ìx
                'Combo_M003.Enabled = True : Label_M04.Visible = True
                'If Not IsDBNull(DtView2(0)("tier_name")) Then Combo_M003.Text = DtView2(0)("tier_name") Else Combo_M003.Text = Nothing
            Else
                Edit_M001.Visible = True : Edit_M001.Enabled = True : Label_M01.Visible = True
                'Label_M04.Visible = False
            End If
            Cmb4()  'ìÔà’ìx
            Combo_M003.Enabled = True : Label_M04.Visible = True
            If Not IsDBNull(DtView2(0)("tier_name")) Then Combo_M003.Text = DtView2(0)("tier_name") Else Combo_M003.Text = Nothing

            Edit_M002.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_meas")) Then Edit_M002.Text = DtView2(0)("etmt_meas") Else Edit_M002.Text = Nothing
            Edit_M003.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_comn")) Then Edit_M003.Text = DtView2(0)("etmt_comn") Else Edit_M003.Text = Nothing

            If Not IsDBNull(DtView1(0)("calc_cls")) Then calc_cls.Text = DtView1(0)("calc_cls") Else calc_cls.Text = "1"

            'If P_ACES_post_code >= "02" Then Number031.Enabled = True
            Number031.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then Number031.Value = DtView2(0)("etmt_cost_tech_chrg") Else Number031.Value = 0
            'If P_ACES_post_code >= "02" Then Number033.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_cost_apes")) Then Number032.Value = DtView2(0)("etmt_cost_apes") Else Number032.Value = 0
            If CK_own_flg.Checked = False Then Number032.Value = 0
            'Number032.Enabled = True
            Number033.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_cost_part_chrg")) Then Number033.Value = DtView2(0)("etmt_cost_part_chrg") Else Number033.Value = 0
            'If P_ACES_post_code >= "02" Then Number034.Enabled = True
            Number034.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_cost_fee")) Then Number034.Value = DtView2(0)("etmt_cost_fee") Else Number034.Value = 0
            'If P_ACES_post_code >= "02" Then Number035.Enabled = True
            Number035.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_cost_pstg")) Then Number035.Value = DtView2(0)("etmt_cost_pstg") Else Number035.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_ttl")) Then
                Number036.Value = DtView2(0)("etmt_cost_ttl")
            Else
                Number036.Value = Number031.Value + Number032.Value + Number033.Value + Number034.Value + Number035.Value
            End If
            'If P_ACES_post_code >= "02" Then Number036.Value = Number031.Value + Number033.Value + Number034.Value + Number035.Value
            If Not IsDBNull(DtView2(0)("etmt_cost_tax")) Then Number037.Value = DtView2(0)("etmt_cost_tax") Else Number037.Value = 0
            'If P_ACES_post_code >= "02" Then Number019.Enabled = True
            Number019.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_shop_cxl")) Then Number019.Value = DtView2(0)("etmt_shop_cxl") Else Number019.Value = 0
            Number029.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_eu_cxl")) Then Number029.Value = DtView2(0)("etmt_eu_cxl") Else Number029.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_cxl")) Then Number039.Value = DtView2(0)("etmt_cost_cxl") Else Number039.Value = 0

            If Not IsDBNull(DtView2(0)("etmt_shop_tech_chrg")) Then Number011.Value = DtView2(0)("etmt_shop_tech_chrg") Else Number011.Value = 0
            'If P_ACES_post_code >= "02" Then Number011.Enabled = True
            Number011.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_shop_apes")) Then Number012.Value = DtView2(0)("etmt_shop_apes") Else Number012.Value = 0
            If CK_own_flg.Checked = False Then Number012.Value = 0
            Number012.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_shop_part_chrg")) Then Number013.Value = DtView2(0)("etmt_shop_part_chrg") Else Number013.Value = 0
            'If P_ACES_post_code >= "02" Then Number013.Enabled = True
            Number013.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_shop_fee")) Then Number014.Value = DtView2(0)("etmt_shop_fee") Else Number014.Value = 0
            'If P_ACES_post_code >= "02" Then Number014.Enabled = True
            Number014.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_shop_pstg")) Then Number015.Value = DtView2(0)("etmt_shop_pstg") Else Number015.Value = 0
            'If P_ACES_post_code >= "02" Then Number015.Enabled = True
            Number015.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_shop_ttl")) Then
                Number016.Value = DtView2(0)("etmt_shop_ttl")
            Else
                Number016.Value = Number011.Value + Number012.Value + Number013.Value + Number014.Value + Number015.Value
            End If
            If Not IsDBNull(DtView2(0)("etmt_eu_tech_chrg")) Then Number021.Value = DtView2(0)("etmt_eu_tech_chrg") Else Number021.Value = 0
            'If P_ACES_post_code >= "02" Then Number021.Enabled = True
            Number021.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_eu_apes")) Then Number022.Value = DtView2(0)("etmt_eu_apes") Else Number022.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_part_chrg")) Then Number023.Value = DtView2(0)("etmt_eu_part_chrg") Else Number023.Value = 0
            'If P_ACES_post_code >= "02" Then Number023.Enabled = True
            Number023.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_eu_fee")) Then Number024.Value = DtView2(0)("etmt_eu_fee") Else Number024.Value = 0
            'If P_ACES_post_code >= "02" Then Number024.Enabled = True
            Number024.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_eu_pstg")) Then Number025.Value = DtView2(0)("etmt_eu_pstg") Else Number025.Value = 0
            'If P_ACES_post_code >= "02" Then Number025.Enabled = True
            Number025.Enabled = True
            If Not IsDBNull(DtView2(0)("etmt_eu_ttl")) Then
                Number026.Value = DtView2(0)("etmt_eu_ttl")
            Else
                Number026.Value = Number021.Value + Number023.Value + Number024.Value + Number025.Value
            End If

            Button_M001.Enabled = True

            'å©êœì‡óe
            Line_No3 = -1
            Panel_M1.Controls.Clear()
            WK_DsCMB3.Clear()

            'äÓèÄì_
            label_3(0, 0) = New Label
            label_3(0, 0).Location = New System.Drawing.Point(0, 0)
            label_3(0, 0).Size = New System.Drawing.Size(0, 0)
            label_3(0, 0).Text = Nothing
            Panel_M1.Controls.Add(label_3(0, 0))

            WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_2"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    add_line_3("1")    'å©êœì‡óe
                Next
            End If
            add_line_3("0")    'å©êœì‡óe

            'ïîïi
            Dim tbl As New DataTable
            tbl = P_DsList1.Tables("T04_REP_PART")
            DataGrid_M1.DataSource = tbl

            Irregular() 'ÉCÉåÉMÉÖÉâÅ[èàóù

            Call CONTACT_GET(Edit000.Text)
            cntact1.Text = P1_CONTACT
            cntact2.Text = P2_CONTACT
            CheckBox1.Enabled = True
            If P3_CONTACT = "True" Then CheckBox1.Checked = True Else CheckBox1.Checked = False

            'Q&AèCóùïsâ¬É`ÉFÉbÉNï\é¶êßå‰
            Select Case QA_rep(Edit000.Text)
                Case Is = "0"
                    QA_F = "1"
                    Label37.Visible = True
                    CheckBox2.Visible = True
                    CheckBox2.Checked = False
                    CheckBox2_moto.Checked = False
                Case Is = "1"
                    QA_F = "1"
                    Label37.Visible = True
                    CheckBox2.Visible = True
                    CheckBox2.Checked = True
                    CheckBox2_moto.Checked = True
                Case Is = "9"
                    QA_F = "0"
                    Label37.Visible = False
                    CheckBox2.Visible = False
                    CheckBox2.Checked = False
                    CheckBox2_moto.Checked = False
            End Select

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

            Combo004.Focus()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'ÉCÉåÉMÉÖÉâÅ[èàóùÅisofmapÇ≈HPóLèûéÊéüÅj
    Sub Irregular()
        If GRP.Text = "19" _
           And CL004.Text = "01" _
           And CLU002.Text = "97" Then
            NumberN007.Value = 1
            NumberN008.Value = 1
            'If Number011.Value > 2000 Then
            '    Number021.Value = Number011.Value - 2000
            'Else
            '    Number021.Value = 0
            'End If
            Irregular_F = "1"
        Else
            NumberN007.Value = NumberN007_Bk.Value
            NumberN008.Value = NumberN008_Bk.Value
            Irregular_F = "0"
        End If
    End Sub

    'åÃè·ì‡óe
    Sub add_line_2()
        DB_OPEN("nMVAR")
        Line_No2 = Line_No2 + 1

        'åÃè·ì‡óe
        en = 1
        cmbBo_2(Line_No2, en) = New GrapeCity.Win.Input.Combo
        cmbBo_2(Line_No2, en).Location = New System.Drawing.Point(1, 20 * Line_No2)
        cmbBo_2(Line_No2, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
    Sub add_line_3(ByVal flg)
        DB_OPEN("nMVAR")
        Line_No3 = Line_No3 + 1

        'å©êœì‡óe
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL += " FROM M10_CMNT"
        strSQL += " WHERE (cls_code = '11') AND (delt_flg = 0)"
        strSQL += " ORDER BY cmnt_code + ':' + cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsCMB3, "M10_CMNT_3" & Line_No3)

        en = 1
        cmbBo_3(Line_No3, en) = New GrapeCity.Win.Input.Combo
        cmbBo_3(Line_No3, en).Location = New System.Drawing.Point(1, 20 * Line_No3 + label_3(0, 0).Location.Y)
        cmbBo_3(Line_No3, en).MaxDropDownItems = 30
        cmbBo_3(Line_No3, en).HighlightText = GrapeCity.Win.Input.HighlightText.Field
        cmbBo_3(Line_No3, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_3(Line_No3, en).Size = New System.Drawing.Size(465, 20)
        cmbBo_3(Line_No3, en).DataSource = WK_DsCMB3.Tables("M10_CMNT_3" & Line_No3)
        cmbBo_3(Line_No3, en).AutoSelect = True
        cmbBo_3(Line_No3, en).DisplayMember = "cmnt"
        cmbBo_3(Line_No3, en).ValueMember = "cmnt_code"
        cmbBo_3(Line_No3, en).Tag = Line_No3
        Panel_M1.Controls.Add(cmbBo_3(Line_No3, en))
        AddHandler cmbBo_3(Line_No3, en).GotFocus, AddressOf cmb3_1_GotFocus
        AddHandler cmbBo_3(Line_No3, en).LostFocus, AddressOf cmb3_1_LostFocus
        If flg = "1" Then
            If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
                cmbBo_3(Line_No3, en).Text = WK_DtView1(i)("cmnt_name1")
            Else
                cmbBo_3(Line_No3, en).Text = Nothing
            End If
        Else
            cmbBo_3(Line_No3, en).Text = Nothing
        End If

        'å©êœì‡óe∫∞ƒﬁ
        en = 1
        label_3(Line_No3, en) = New Label
        If flg = "1" Then
            If Not IsDBNull(WK_DtView1(i)("cmnt_code1")) Then
                label_3(Line_No3, en).Text = WK_DtView1(i)("cmnt_code1")
            Else
                label_3(Line_No3, en).Text = Nothing
            End If
        Else
            label_3(Line_No3, en).Text = Nothing
        End If
        label_3(Line_No3, en).Location = New System.Drawing.Point(500, 20 * Line_No3 + label_3(0, 0).Location.Y)
        label_3(Line_No3, en).Size = New System.Drawing.Size(50, 20)
        label_3(Line_No3, en).Visible = False
        Panel_M1.Controls.Add(label_3(Line_No3, en))

        'SEQ
        en = 2
        label_3(Line_No3, en) = New Label
        If flg = "1" Then
            label_3(Line_No3, en).Text = WK_DtView1(i)("seq")
        Else
            label_3(Line_No3, en).Text = Nothing
        End If
        label_3(Line_No3, en).Location = New System.Drawing.Point(600, 20 * Line_No3 + label_3(0, 0).Location.Y)
        label_3(Line_No3, en).Size = New System.Drawing.Size(50, 20)
        label_3(Line_No3, en).Visible = False
        Panel_M1.Controls.Add(label_3(Line_No3, en))

        DB_CLOSE()
    End Sub
    Sub add_line_3_2(ByVal Line_No3, ByVal cmnt_name1, ByVal cmnt_code1)
        DB_OPEN("nMVAR")

        'å©êœì‡óe
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL += " FROM M10_CMNT"
        strSQL += " WHERE (cls_code = '11') AND (delt_flg = 0)"
        strSQL += " ORDER BY cmnt_code + ':' + cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsCMB3, "M10_CMNT_3" & Line_No3)

        en = 1
        cmbBo_3(Line_No3, en) = New GrapeCity.Win.Input.Combo
        cmbBo_3(Line_No3, en).Location = New System.Drawing.Point(1, 20 * Line_No3 + label_3(0, 0).Location.Y)
        cmbBo_3(Line_No3, en).MaxDropDownItems = 30
        cmbBo_3(Line_No3, en).HighlightText = GrapeCity.Win.Input.HighlightText.Field
        cmbBo_3(Line_No3, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_3(Line_No3, en).Size = New System.Drawing.Size(465, 20)
        cmbBo_3(Line_No3, en).DataSource = WK_DsCMB3.Tables("M10_CMNT_3" & Line_No3)
        cmbBo_3(Line_No3, en).AutoSelect = True
        cmbBo_3(Line_No3, en).DisplayMember = "cmnt"
        cmbBo_3(Line_No3, en).ValueMember = "cmnt_code"
        cmbBo_3(Line_No3, en).Tag = Line_No3
        Panel_M1.Controls.Add(cmbBo_3(Line_No3, en))
        AddHandler cmbBo_3(Line_No3, en).GotFocus, AddressOf cmb3_1_GotFocus
        AddHandler cmbBo_3(Line_No3, en).LostFocus, AddressOf cmb3_1_LostFocus
        cmbBo_3(Line_No3, en).Text = cmnt_name1

        'å©êœì‡óe∫∞ƒﬁ
        en = 1
        label_3(Line_No3, en) = New Label
        label_3(Line_No3, en).Text = cmnt_code1
        label_3(Line_No3, en).Location = New System.Drawing.Point(500, 20 * Line_No3 + label_3(0, 0).Location.Y)
        label_3(Line_No3, en).Size = New System.Drawing.Size(50, 20)
        label_3(Line_No3, en).Visible = False
        Panel_M1.Controls.Add(label_3(Line_No3, en))

        'SEQ
        en = 2
        label_3(Line_No3, en) = New Label
        label_3(Line_No3, en).Text = Nothing
        label_3(Line_No3, en).Location = New System.Drawing.Point(600, 20 * Line_No3 + label_3(0, 0).Location.Y)
        label_3(Line_No3, en).Size = New System.Drawing.Size(50, 20)
        label_3(Line_No3, en).Visible = False
        Panel_M1.Controls.Add(label_3(Line_No3, en))

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
            Button12_Click(sender, e)
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
        'å©êœÉRÉÅÉìÉg
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = "12"  'å©êœÉRÉÅÉìÉg
        Dim F00_Form06 As New F00_Form06
        F00_Form06.ShowDialog()

        If P_RTN = "1" Then
            If Edit_M003.Text = Nothing Then
                Edit_M003.Text = P_PRAM1
            Else
                If Edit_M003.Text.LastIndexOf(P_PRAM1) = -1 Then
                    Edit_M003.Text = Trim(Edit_M003.Text) & System.Environment.NewLine & P_PRAM1
                End If
            End If
        End If
        Edit_M003.Focus()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  çÄñ⁄É`ÉFÉbÉN
    '********************************************************************
    Sub CHK_Date015()   'êfífì˙
        msg.Text = Nothing
        If P_PRT_F = "0" Then
            If Date015.Number = 0 Then Date015.Text = Format(Now, "yyyy/MM/dd HH:mm")
        End If

        If Date015.Number = 0 Then
        Else
            If Date003.Text > Date015.Text Then         'éÛïtì˙ÅÑêfífì˙
                Date015.BackColor = System.Drawing.Color.Red
                msg.Text = "éÛïtì˙ÅÑêfífì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            Else
                Select Case Date015.Text
                    Case Is < DateAdd(DateInterval.Year, -1, Now).Date '1îNà»è„âﬂãéì˙ït
                        Date015.BackColor = System.Drawing.Color.Red
                        msg.Text = "êfífì˙Ç…1îNà»è„à»ëOÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        Exit Sub
                    Case Is > Now.Date & " 23:59:59"  'ñ¢óàì˙ït
                        Date015.BackColor = System.Drawing.Color.Red
                        msg.Text = "êfífì˙Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        Exit Sub
                End Select
            End If
        End If
        Date015.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date004()   'å©êœì˙
        msg.Text = Nothing
        If P_PRT_F = "0" Then
            If Date004.Number = 0 Then Date004.Text = Now.Date
        End If

        If Date004.Number = 0 Then
        Else
            If Date003.Text > Date004.Text & " 23:59:59" Then         'éÛïtì˙ÅÑå©êœì˙
                Date004.BackColor = System.Drawing.Color.Red
                msg.Text = "éÛïtì˙ÅÑå©êœì˙ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            Else
                Select Case Date004.Text
                    Case Is < DateAdd(DateInterval.Year, -1, Now).Date '1îNà»è„âﬂãéì˙ït
                        Date004.BackColor = System.Drawing.Color.Red
                        msg.Text = "å©êœì˙Ç…1îNà»è„à»ëOÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        Exit Sub
                    Case Is > Now.Date & " 23:59:59"  'ñ¢óàì˙ït
                        Date004.BackColor = System.Drawing.Color.Red
                        msg.Text = "å©êœì˙Ç…ñ{ì˙à»ç~ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                        Exit Sub
                End Select
            End If
        End If
        tax(String.Format("{0:yyyy/MM/dd}", CDate(Date004.Text)))
        Date004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date007()   'ïîïiî≠íçì˙
        msg.Text = Nothing
        If Date007.Number = 0 Then
            Date007.BackColor = System.Drawing.Color.Red
            msg.Text = Label015.Text & "Ç…ì˙ïtÇ™ì¸Ç¡ÇƒÇ¢Ç‹ÇπÇÒÅBämîFäËÇ¢Ç‹Ç∑ÅB"
            Exit Sub
        End If
        Date007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date008()   'ïîïiéÛóÃì˙
        msg.Text = Nothing

        Date008.BackColor = System.Drawing.SystemColors.Window
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
    Sub CHK_Combo004()   'èCóùéÌï 
        msg.Text = Nothing
        CL004.Text = Nothing

        Combo004.Text = Trim(Combo004.Text)
        If Combo004.Text = Nothing Then
            Combo004.BackColor = System.Drawing.Color.Red
            msg.Text = "èCóùéÌï Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB1.Tables("CLS_CODE_001"), "cls_code_name = '" & Combo004.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo004.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈèCóùéÌï Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL004.Text = WK_DtView1(0)("cls_code")
                If CL004.Text = "02" Then
                    Combo004.BackColor = System.Drawing.Color.Red
                    msg.Text = "èCóùéÌï Ç™ÉÅÅ[ÉJÅ[ï€èÿÇÃèÍçáÅAå©êœÇÃïKóvÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                    Exit Sub
                Else
                    Irregular() 'ÉCÉåÉMÉÖÉâÅ[èàóù
                    Number012.Value = 0
                    If CL004.Text = "02" Then
                        If CK_own_flg.Checked = True Then   'é©é–èCóù

                            'APSE
                            If CLU001.Text = "01" _
                                And CL004.Text = "02" _
                                And Date003.Number <> 0 Then
                                apse.Text = APSE_GET(CLU002.Text, Date003.Text)
                            Else
                                apse.Text = "0"
                            End If
                            If CInt(apse.Text) <> 0 Then
                                Number012.Value = Number011.Value * (CInt(apse.Text) - 100) / 100
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Combo004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit012()   'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        msg.Text = Nothing
        Edit012.Text = Trim(Edit012.Text)

        'If CL004.Text = "02" Then   '“∞∂∞ï€èÿ
        '    If Edit012.Text = Nothing Then
        '        Edit012.BackColor = System.Drawing.Color.Red
        '        msg.Text = "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
        '        Exit Sub
        '    End If
        'End If
        Edit012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_M001()   'å©êœíSìñ
        msg.Text = Nothing
        CLM001.Text = Nothing

        'If Combo_M001.Visible = True Then
        Combo_M001.Text = Trim(Combo_M001.Text)
        If Combo_M001.Text = Nothing Then
            Combo_M001.BackColor = System.Drawing.Color.Red
            msg.Text = "å©êœíSìñÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB2.Tables("M01_EMPL"), "name = '" & Combo_M001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo_M001.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈå©êœíSìñÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLM001.Text = WK_DtView1(0)("empl_code")
            End If
        End If
        'End If
        Combo_M001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_M003()   'ìÔà’ìx
        msg.Text = Nothing
        CLM003.Text = Nothing

        Combo_M003.Text = Trim(Combo_M003.Text)
        If Combo_M003.Text = Nothing Then
            Combo_M003.BackColor = System.Drawing.Color.Red
            msg.Text = "ìÔà’ìxÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB4.Tables("CLS_CODE_013"), "cls_code_name = '" & Combo_M003.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo_M003.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈìÔà’ìxÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLM003.Text = WK_DtView1(0)("cls_code")
            End If
        End If
        Combo_M003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_M001()   'ÉÅÅ[ÉJÅ[èCóùî‘çÜ
        msg.Text = Nothing

        If Edit_M001.Visible = True Then
            Edit_M001.Text = Trim(Edit_M001.Text)
            If Edit_M001.Text = Nothing Then
                Edit_M001.BackColor = System.Drawing.Color.Red
                msg.Text = "ÉÅÅ[ÉJÅ[èCóùî‘çÜÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_M001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_cmnt3(ByVal seq As Integer) 'å©êœì‡óe
        msg.Text = Nothing

        cmbBo_3(seq, 1).Text = Trim(cmbBo_3(seq, 1).Text)
        If cmbBo_3(seq, 1).Text = Nothing Then
        Else
            WK_DtView1 = New DataView(WK_DsCMB3.Tables("M10_CMNT_3" & seq), "cmnt ='" & cmbBo_3(seq, 1).Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                cmbBo_3(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈå©êœì‡óeÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                label_3(seq, 1).Text = WK_DtView1(0)("cmnt_code")
            End If
        End If
        cmbBo_3(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_M002()   'å©êœì‡óe
        msg.Text = Nothing

        Edit_M002.Text = Trim(Edit_M002.Text)
        If Edit_M002.Text = Nothing Then
            'Edit_M002.BackColor = System.Drawing.Color.Red
            'msg.Text = "å©êœì‡óeÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_M002.Text)
            If P_Line > 9 Then
                Edit_M002.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_M002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_M003()   'å©êœÉRÉÅÉìÉg
        msg.Text = Nothing

        Edit_M003.Text = Trim(Edit_M003.Text)
        If Edit_M003.Text = Nothing Then
            'Edit_M003.BackColor = System.Drawing.Color.Red
            'msg.Text = "å©êœÉRÉÅÉìÉgÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_M003.Text)
            If P_Line > 9 Then
                Edit_M003.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_M003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        'ÉmÅ[ÉgãÊï™
        If CLU001.Text <> "01" Then
            CheckBox_U003.Checked = CheckBox_U001.Checked
        End If

        CHK_Date015()       'êfífì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date015.Focus() : Exit Sub

        CHK_Date004()       'å©êœì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date004.Focus() : Exit Sub

        CHK_CkBox01()   'âﬂé∏
        If msg.Text <> Nothing Then Err_F = "1" : CkBox01_Y.Focus() : Exit Sub

        CHK_Combo004()      'èCóùéÌï 
        If msg.Text <> Nothing Then Err_F = "1" : Combo004.Focus() : Exit Sub

        CHK_Edit012()   'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        If msg.Text <> Nothing Then Err_F = "1" : Edit012.Focus() : Exit Sub

        CHK_Combo_M001()    'å©êœíSìñ
        If msg.Text <> Nothing Then Err_F = "1" : Combo_M001.Focus() : Exit Sub

        CHK_Combo_M003()   'ìÔà’ìx
        If msg.Text <> Nothing Then Err_F = "1" : Combo_M003.Focus() : Exit Sub

        CHK_Edit_M001()     'ÉÅÅ[ÉJÅ[èCóùî‘çÜ
        If msg.Text <> Nothing Then Err_F = "1" : Edit_M001.Focus() : Exit Sub

        'å©êœì‡óe
        seq = 0
        For i = 0 To Line_No3

            CHK_cmnt3(i) 'å©êœì‡óe
            If msg.Text <> Nothing Then Err_F = "1" : cmbBo_3(i, 1).Focus() : Exit Sub

            If cmbBo_3(i, 1).Text <> Nothing Then
                seq = seq + 1
            End If
        Next

        CHK_Edit_M002()   'å©êœì‡óe
        If msg.Text <> Nothing Then Err_F = "1" : Edit_M002.Focus() : Exit Sub
        seq = seq + P_Line

        CHK_Edit_M003()   'å©êœÉRÉÅÉìÉg
        If msg.Text <> Nothing Then Err_F = "1" : Edit_M003.Focus() : Exit Sub
        seq = seq + P_Line

        If seq > 9 Then
            Edit_M002.BackColor = System.Drawing.Color.Red
            msg.Text = "å©êœì‡óeÇÃëIëçÄñ⁄Ç∆ÉtÉäÅ[ì¸óÕÇ≈çáåvÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
            Err_F = "1" : Edit_M002.Focus() : Exit Sub
        End If

    End Sub

    '********************************************************************
    '**  îÒï\é¶ÇÃçÄñ⁄ÇÕÉNÉäÉAÇ∑ÇÈ
    '********************************************************************
    Sub NoDsp_Null()
        If Edit_M001.Visible = False Then Edit_M001.Text = Nothing
        'If Combo_M001.Visible = False Then Combo_M001.Text = Nothing
        'If Combo_M001.Visible = False Then CLM001.Text = Nothing
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit000_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.GotFocus
        If Edit000.ReadOnly = False Then
            Edit000.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        End If
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit012_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.GotFocus
        Edit012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date004.GotFocus
        Date004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.GotFocus
        Date007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date008_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.GotFocus
        Date008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo004.GotFocus
        Combo004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date015GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date015.GotFocus
        Date015.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_M001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_M001.GotFocus
        Combo_M001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_M003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_M003.GotFocus
        Combo_M003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_M001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M001.GotFocus
        Edit_M001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_M002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M002.GotFocus
        Edit_M002.ImeMode = ImeMode.Hiragana
        Edit_M002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_M003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M003.GotFocus
        Edit_M003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub cmb3_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        cmbBo_3(cmb.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number011_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number011.GotFocus
        Number011.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number012_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number012.GotFocus
        Number012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number013_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number013.GotFocus
        Number013.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number014_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number014.GotFocus
        Number014.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number015_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number015.GotFocus
        Number015.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number021_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number021.GotFocus
        Number021.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number023_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number023.GotFocus
        Number023.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number024_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number024.GotFocus
        Number024.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number025_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number025.GotFocus
        Number025.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number031_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number031.GotFocus
        Number031.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number032_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number032.GotFocus
        Number032.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number033_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number033.GotFocus
        Number033.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number034_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number034.GotFocus
        Number034.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number035_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number035.GotFocus
        Number035.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number019_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number019.GotFocus
        Number019.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number029_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number029.GotFocus
        Number029.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CkBox01_Y_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_Y.GotFocus
        CkBox01_Y.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CkBox01_N_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_N.GotFocus
        CkBox01_N.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox_U001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U001.GotFocus
        CheckBox_U001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox_M001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_M001.GotFocus
        CheckBox_M001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit000_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.LostFocus
        If Edit000.ReadOnly = False Then
            Edit000.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.LostFocus
        CHK_Edit012()   'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
    End Sub
    Private Sub Date004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date004.LostFocus
        CHK_Date004()       'å©êœì˙
    End Sub
    Private Sub Date007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.LostFocus
        CHK_Date007()   'ïîïiî≠íçì˙
    End Sub
    Private Sub Date008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.LostFocus
        CHK_Date008()   'ïîïiéÛóÃì˙
    End Sub
    Private Sub Date015_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date015.LostFocus
        CHK_Date015()       'êfífì˙
    End Sub
    Private Sub Combo004_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo004.LostFocus
        CHK_Combo004()      'èCóùéÌï 
    End Sub
    Private Sub Combo_M001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_M001.LostFocus
        CHK_Combo_M001()    'å©êœíSìñ
    End Sub
    Private Sub Combo_M003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_M003.LostFocus
        CHK_Combo_M003()    'ìÔà’ìx
        auto_etmt() 'å©êœéZèo
    End Sub
    Private Sub Edit_M001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M001.LostFocus
        CHK_Edit_M001()     'ÉÅÅ[ÉJÅ[èCóùî‘çÜ
        auto_etmt() 'å©êœéZèo
        Irregular() 'ÉCÉåÉMÉÖÉâÅ[èàóù
    End Sub
    Private Sub Edit_M002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M002.LostFocus
        CHK_Edit_M002()     'å©êœì‡óe
    End Sub
    Private Sub Edit_M003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M003.LostFocus
        CHK_Edit_M003()     'å©êœÉRÉÅÉìÉg
    End Sub
    Private Sub Number011_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number011.LostFocus
        Number011.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number012.LostFocus
        Number012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number013_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number013.LostFocus
        Number013.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number014_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number014.LostFocus
        Number014.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number015_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number015.LostFocus
        Number015.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number021_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number021.LostFocus
        Number021.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number023_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number023.LostFocus
        Number023.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number024_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number024.LostFocus
        Number024.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number025_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number025.LostFocus
        Number025.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number031_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number031.LostFocus
        Number031.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number032_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number032.LostFocus
        Number032.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number033_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number033.LostFocus
        Number033.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number034_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number034.LostFocus
        Number034.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number035_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number035.LostFocus
        Number035.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number019_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number019.LostFocus
        Number019.BackColor = System.Drawing.SystemColors.Window
        Number039.Value = Number019.Value
    End Sub
    Private Sub Number029_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number029.LostFocus
        Number029.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub cmb3_1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        CHK_cmnt3(cmb.Tag)  'èCóùì‡óe
        If Line_No3 = cmb.Tag Then
            If Line_No3 < 8 Then
                If cmbBo_3(cmb.Tag, 1).Text <> Nothing Then
                    add_line_3("0")    'èCóùì‡óe
                    cmbBo_3(cmb.Tag + 1, 1).Focus()
                End If
            End If
        End If
    End Sub
    Private Sub CkBox01_Y_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_Y.LostFocus
        CkBox01_Y.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CkBox01_N_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_N.LostFocus
        CkBox01_N.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U001.LostFocus
        CheckBox_U001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox_M001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_M001.LostFocus
        CheckBox_M001.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub CheckBox_U001_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U001.CheckedChanged
        auto_etmt() 'å©êœéZèo
    End Sub
    Private Sub Number011_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number011.TextChanged
        sum1_apse()
        sum1_base()
        sum1()
    End Sub
    Private Sub Number012_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number012.TextChanged
        sum1_base()
        Number032.Value = Number012.Value
        sum1()
    End Sub
    Private Sub Number013_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number013.TextChanged
        sum1_base()
        sum1()
    End Sub
    Private Sub Number014_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number014.TextChanged
        sum1_base()
        sum1()
    End Sub
    Private Sub Number015_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number015.TextChanged
        sum1_base()
        sum1()
    End Sub
    Private Sub Number021_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number021.TextChanged
        sum2_base()
    End Sub
    Private Sub Number023_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number023.TextChanged
        sum2_base()
    End Sub
    Private Sub Number024_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number024.TextChanged
        sum2_base()
    End Sub
    Private Sub Number025_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number025.TextChanged
        sum2_base()
    End Sub
    Private Sub Number031_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number031.TextChanged
        sum3_base()
        sum3()
    End Sub
    Private Sub Number032_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number032.TextChanged
        sum3_base()
    End Sub
    Private Sub Number033_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number033.TextChanged
        sum3_base()
        'sum3()
    End Sub
    Private Sub Number034_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number034.TextChanged
        sum3_base()
        sum3()
    End Sub
    Private Sub Number035_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number035.TextChanged
        sum3_base()
        sum3()
    End Sub
    Sub sum0()  'íËäzÅAìÔà’ìxÇ™ïœçXÇ…Ç»Ç¡ÇΩéûÇÃåvéZ
        If inz_F = "1" And CheckBox_M001.Checked = False Then
            If NumberN006.Value = 0 Then
                Dim WK_amt1, WK_amt2, WK_amt3 As Integer
                WK_DtView3 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "seq", DataViewRowState.CurrentRows)
                If WK_DtView3.Count <> 0 Then
                    For i = 0 To WK_DtView3.Count - 1
                        'part_rate_get(WK_DtView3(i)("shop_chrg"))
                        WK_amt1 = WK_amt1 + WK_DtView3(i)("shop_chrg")
                        WK_amt2 = WK_amt2 + WK_DtView3(i)("eu_chrg")
                        WK_amt3 = WK_amt3 + WK_DtView3(i)("cost_chrg")
                        'WK_amt3 = WK_amt3 + (WK_DtView3(i)("part_amnt") * WK_DtView3(i)("use_qty"))
                    Next
                End If
                Number013.Value = WK_amt1
                Number023.Value = WK_amt2
                Number033.Value = WK_amt3
            Else
                Number013.Value = NumberN006.Value - Number011.Value - Number014.Value - Number015.Value
            End If
        End If
    End Sub
    Sub sum1_base()
        Number016.Value = Number011.Value + Number012.Value + Number013.Value + Number014.Value + Number015.Value
        Select Case calc_cls.Text
            Case Is = "0"   'éléÃå‹ì¸
                Number017.Value = Round(Number016.Value * tax_rate.Text / 100, 0)
            Case Is = "1"   'êÿéÃÇƒ
                Number017.Value = RoundDOWN(Number016.Value * tax_rate.Text / 100, 0)
            Case Is = "2"   'êÿè„Ç∞
                Number017.Value = RoundUP(Number016.Value * tax_rate.Text / 100, 0)
        End Select
        Number018.Value = Number016.Value + Number017.Value
    End Sub
    Sub sum2_base()
        If GRP.Text = "92" Then 'ãûìséñã∆òAçá
            Number026.Value = RoundUP(RoundUP(Number016.Value / 0.95, -1) / 0.9, -1)
        Else
            Number026.Value = Number021.Value + Number022.Value + Number023.Value + Number024.Value + Number025.Value
        End If
        Select Case calc_cls.Text
            Case Is = "0"   'éléÃå‹ì¸
                Number027.Value = Round(Number026.Value * tax_rate.Text / 100, 0)
            Case Is = "1"   'êÿéÃÇƒ
                Number027.Value = RoundDOWN(Number026.Value * tax_rate.Text / 100, 0)
            Case Is = "2"   'êÿè„Ç∞
                Number027.Value = RoundUP(Number026.Value * tax_rate.Text / 100, 0)
        End Select
        Number028.Value = Number026.Value + Number027.Value
    End Sub
    Sub sum3_base()
        Number036.Value = Number031.Value + Number032.Value + Number033.Value + Number034.Value + Number035.Value
        Select Case calc_cls.Text
            Case Is = "0"   'éléÃå‹ì¸
                Number037.Value = Round(Number036.Value * tax_rate.Text / 100, 0)
            Case Is = "1"   'êÿéÃÇƒ
                Number037.Value = RoundDOWN(Number036.Value * tax_rate.Text / 100, 0)
            Case Is = "2"   'êÿè„Ç∞
                Number037.Value = RoundUP(Number036.Value * tax_rate.Text / 100, 0)
        End Select
        Number038.Value = Number036.Value + Number037.Value
    End Sub
    Sub sum1_apse()  'ãZèpóøÇ™ïœçXÇ…Ç»Ç¡ÇΩéûÇÃåvéZ
        Number012.Value = 0
        If CK_own_flg.Checked = True Then   'é©é–èCóù
            If CInt(apse.Text) <> 0 Then
                Number012.Value = Number011.Value * (CInt(apse.Text) - 100) / 100
            End If
        End If
    End Sub
    Sub sum1()  'åvè„äzÇ™ïœçXÇ…Ç»Ç¡ÇΩéûÇÃåvéZ
        If inz_F = "1" Then
            If NumberN006.Value <> 0 Then    'íËäz
                If CheckBox_M001.Checked = False Then
                    If CLU001.Text = "02" Then  'IBM≤⁄∑ﬁ≠◊∞èàóù
                        Number016.Value = NumberN006.Value + Number014.Value + Number015.Value
                        Number013.Value = Number016.Value - Number011.Value - Number012.Value - Number014.Value - Number015.Value

                        Number021.Value = Number011.Value * NumberN007.Value
                        Number023.Value = Number013.Value * NumberN008.Value
                        Number024.Value = Number014.Value
                        Number025.Value = Number015.Value
                    Else
                        Number016.Value = NumberN006.Value + Number014.Value + Number015.Value
                        Number013.Value = Number016.Value - Number011.Value - Number012.Value - Number014.Value - Number015.Value

                        Number021.Value = Number011.Value
                        Number023.Value = Number013.Value
                        Number024.Value = Number014.Value
                        Number025.Value = Number015.Value
                    End If
                End If
            Else
                Number021.Value = Number011.Value * NumberN007.Value
                Number022.Value = 0
                'ïîïiñàÇ…åvéZÇ∑ÇÈÇÃÇ≈Ç±Ç±Ç≈ÇÕåvéZÇµÇ»Ç¢
                'Number023.Value = Number013.Value * NumberN008.Value
                Number024.Value = Number014.Value
                Number025.Value = Number015.Value
            End If

            'ÉCÉåÉMÉÖÉâÅ[èàóù
            Select Case GRP.Text
                Case Is = "92" 'ãûìséñã∆òAçá
                    'ïîïiñàÇ…åvéZÇ∑ÇÈÇÃÇ≈Ç±Ç±Ç≈ÇÕåvéZÇµÇ»Ç¢
                    If NumberN006.Value = 0 Then    'íËäzà»äO
                        Number021.Value = RoundUP(RoundUP(Number011.Value / 0.95, -1) / 0.9, -1)
                        Number023.Value = RoundUP(RoundUP(Number013.Value / 0.95, -1) / 0.9, -1)
                    End If

                Case Is = "19" 'É\ÉtÉ}ÉbÉv
                    If NumberN006.Value = 0 Then    'íËäzà»äO
                        Number021.Value = RoundUP(Number011.Value * NumberN007.Value, -1)
                    End If
                    If CK_own_flg.Checked = False Then 'É\ÉtÉ}ÉbÉvÇ≈ëºé–èCóù
                        Number023.Value = Number013.Value - 2000
                    End If
            End Select
        End If
    End Sub
    Sub sum2()  'ÇdÇtäzÇ™ïœçXÇ…Ç»Ç¡ÇΩéûÇÃåvéZ
    End Sub
    Sub sum3()  'ÉRÉXÉgäzÇ™ïœçXÇ…Ç»Ç¡ÇΩéûÇÃåvéZ
        Number011.Value = Number031.Value * NumberN003.Value
        Number014.Value = Number034.Value
        Number015.Value = Number035.Value
    End Sub

    Sub part_rate_get(ByVal amnt As Integer)

        If CL004.Text = "01" Then 'óLèû
            P_PRAM4 = Irregular_F
            P_part_rate1 = NumberN008.Value
        Else                    'ñ≥èû
            Select Case CLU001.Text
                Case Is = "10"  'NEC
                    P_PRAM4 = "Z"
                    P_part_rate1 = 0
                Case Is = "13"  'Fujitsu
                    P_PRAM4 = "1"
                    P_part_rate1 = 1
                Case Else
                    P_PRAM4 = Irregular_F
                    P_part_rate1 = NumberN008.Value
            End Select
        End If

        Select Case P_PRAM4

            Case Is = "Z"   'NEC Zero
                rate1 = 0
                rate2 = 0

            Case Is = "1"  'ÉCÉåÉMÉÖÉâÅ[èàóùÅiÉ\ÉtÉ}ÉbÉvÇ≈HPóLèûèCóùéÊéüéûÅjÅAFujitsu 1
                rate1 = 1
                rate2 = 1

            Case Else
                rate1 = 0
                rate2 = 0

                WK_DsList3.Clear()
                strSQL = "SELECT M06_RPAR_COMP.own_flg, M31_PART_RATE.own_rpat_kbn, M31_PART_RATE.strt_amnt, M31_PART_RATE.end_amnt"
                strSQL += ", M31_PART_RATE.part_rate, M31_PART_RATE.part_amnt"
                strSQL += " FROM T01_REP_MTR INNER JOIN"
                strSQL += " M31_PART_RATE ON"
                strSQL += " T01_REP_MTR.store_code = M31_PART_RATE.store_code AND"
                strSQL += " T01_REP_MTR.vndr_code = M31_PART_RATE.vndr_code AND"
                strSQL += " T01_REP_MTR.note_kbn = M31_PART_RATE.note_kbn INNER JOIN"
                strSQL += " M06_RPAR_COMP ON"
                strSQL += " T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code"
                strSQL += " WHERE (M31_PART_RATE.delt_flg = 0)"
                strSQL += " AND (M06_RPAR_COMP.delt_flg = 0"
                strSQL += ") AND (T01_REP_MTR.rcpt_no = '" & P_PRAM3 & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList3, "M31_PART_RATE")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList3.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If Not IsDBNull(DtView1(0)("own_flg")) Then
                        If WK_DtView1(0)("own_flg") = "1" Then
                            WK_DtView2 = New DataView(WK_DsList3.Tables("M31_PART_RATE"), "own_rpat_kbn = '01' AND strt_amnt <= " & amnt & " AND end_amnt >= " & amnt, "", DataViewRowState.CurrentRows)
                        Else
                            WK_DtView2 = New DataView(WK_DsList3.Tables("M31_PART_RATE"), "own_rpat_kbn = '02' AND strt_amnt <= " & amnt & " AND end_amnt >= " & amnt, "", DataViewRowState.CurrentRows)
                        End If
                    Else
                        WK_DtView2 = New DataView(WK_DsList3.Tables("M31_PART_RATE"), "own_rpat_kbn = '02' AND strt_amnt <= " & amnt & " AND end_amnt >= " & amnt, "", DataViewRowState.CurrentRows)
                    End If

                    If WK_DtView2.Count <> 0 Then
                        rate1 = WK_DtView2(0)("part_rate")
                        rate2 = WK_DtView2(0)("part_amnt")
                    End If
                End If
        End Select
    End Sub

    '********************************************************************
    '** å©êœéZèo
    '********************************************************************
    Sub auto_etmt()
        'ãZèpóø
        WK_DsList1.Clear()
        strSQL = "SELECT * FROM M30_TECH_AMNT"
        strSQL += " WHERE (store_code = '" & Edit001.Text & "')"
        strSQL += " AND (vndr_code = '" & CLU001.Text & "')"
        If CL001.Text = "02" Or CL001.Text = "03" Then  'QG-Care
            strSQL += " AND (qgcare_kbn = '01')"
        Else
            strSQL += " AND (qgcare_kbn = '02')"
        End If
        If CheckBox_U001.Checked = True Then
            strSQL += " AND (note_kbn = '01')"
        Else
            strSQL += " AND (note_kbn = '02')"
        End If
        If CK_own_flg.Checked = True Then
            strSQL += " AND (own_rpat_kbn = '01')"
        Else
            strSQL += " AND (own_rpat_kbn = '02')"
        End If
        'If CK_own_flg.Checked = True Then    'é©é–èCóù
        strSQL += " AND (tier = '" & CLM003.Text & "')"
        'End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)

        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "M30_TECH_AMNT")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("M30_TECH_AMNT"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            NumberN006.Value = WK_DtView1(0)("fix_amnt")
            If WK_DtView1(0)("fix_amnt2") <> 0 Then
                'ã@éÌÇ…ÇÊÇËÇ«ÇøÇÁÇÃã‡äzÇégÇ§Ç©îªífÇ∑ÇÈ
                WK_DsList2.Clear()
                strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '025') AND (delt_flg = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList2, "CLS_CODE_025")
                DB_CLOSE()
                WK_DtView2 = New DataView(WK_DsList2.Tables("CLS_CODE_025"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView2.Count <> 0 Then
                    For i = 0 To WK_DtView2.Count - 1
                        WK_str = WK_DtView2(i)("cls_code_name")
                        If Edit_U002.Text.ToLower.IndexOf(WK_str.ToLower) <> -1 Then
                            NumberN006.Value = WK_DtView1(0)("fix_amnt2")
                            Exit For
                        End If
                    Next
                End If
            End If
            Number031.Value = WK_DtView1(0)("tech_amnt") : amnt(1) = Number031.Value
            Number019.Value = WK_DtView1(0)("cxl_amnt")
            Number029.Value = WK_DtView1(0)("cxl_amnt2")
            Number039.Value = WK_DtView1(0)("cxl_amnt")
            sum0()
        End If
    End Sub

    '********************************************************************
    '** éÛïtâÊñ 
    '********************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Panel_éÛït.Visible = True
        Panel_å©êœ.Visible = False
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '** å©êœâÊñ 
    '********************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Panel_éÛït.Visible = False
        Panel_å©êœ.Visible = True
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '** ïîïiì¸óÕ
    '********************************************************************
    Private Sub Button_M001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_M001.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P1_F00_Form03 = CLU001.Text
        P2_F00_Form03 = "1"
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
            WK_DtView3 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView3.Count <> 0 Then
                For i = 0 To WK_DtView3.Count - 1
                    'WK_amt3 = WK_amt3 + WK_DtView3(i)("part_amnt") * WK_DtView3(i)("use_qty")
                    WK_amt3 = WK_amt3 + WK_DtView3(i)("cost_chrg")
                    WK_amt1 = WK_amt1 + WK_DtView3(i)("shop_chrg")
                    WK_amt2 = WK_amt2 + WK_DtView3(i)("eu_chrg")
                Next
            End If
            Number033.Value = WK_amt3
            Number013.Value = WK_amt1
            Number023.Value = WK_amt2

            If NumberN006.Value <> 0 Then    'íËäz
                Number016.Value = NumberN006.Value
                Number013.Value = Number016.Value - Number011.Value - Number012.Value - Number014.Value - Number015.Value

                Number021.Value = Number011.Value
                'Number023.Value = Number013.Value
                Number024.Value = Number014.Value
                Number025.Value = Number015.Value
            Else
                Number021.Value = Number011.Value * NumberN007.Value
                Number022.Value = 0
                'ïîïiñàÇ…åvéZÇ∑ÇÈÇÃÇ≈Ç±Ç±Ç≈ÇÕåvéZÇµÇ»Ç¢
                'Number023.Value = Number013.Value * NumberN008.Value
                Number024.Value = Number014.Value
                Number025.Value = Number015.Value
            End If

            'ÉCÉåÉMÉÖÉâÅ[èàóù
            Select Case GRP.Text
                Case Is = "92" 'ãûìséñã∆òAçá
                    'ïîïiñàÇ…åvéZÇ∑ÇÈÇÃÇ≈Ç±Ç±Ç≈ÇÕåvéZÇµÇ»Ç¢
                    If NumberN006.Value = 0 Then    'íËäzà»äO
                        'Number021.Value = RoundUP(RoundUP(Number011.Value / 0.95, -1) / 0.9, -1)
                        Number023.Value = RoundUP(RoundUP(Number013.Value / 0.95, -1) / 0.9, -1)
                    End If

                Case Is = "19" 'É\ÉtÉ}ÉbÉv
                    'If NumberN006.Value = 0 Then    'íËäzà»äO
                    '    Number021.Value = RoundUP(Number011.Value * NumberN007.Value, -1)
                    'End If
                    If CK_own_flg.Checked = False Then 'É\ÉtÉ}ÉbÉvÇ≈ëºé–èCóù
                        Number023.Value = Number013.Value - 2000
                    End If
            End Select
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ïœçXâ”èäÉ`ÉFÉbÉN
    '********************************************************************
    Sub CHG_CHK()
        CHG_F = "0"
        CHG.Text = Nothing
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

        P_CHG.Clear()
        strSQL = "SELECT  chge_item, befr, aftr FROM L01_HSTY WHERE (chge_item IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_CHG, "CHG")

        WK_str = Trim(Edit003.Text)
        If IsDBNull(DtView1(0)("store_prsn")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("store_prsn")
        If WK_str <> WK_str2 Then
            'Ds_CHG("îÃé–íSìñé“", WK_str2, WK_str)
            CHG.Text = "îÃé–íSìñé“ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'îÃé–íSìñé“
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

        If Date015.Number = 0 Then WK_str = Nothing Else WK_str = Date015.Text
        If IsDBNull(DtView2(0)("sindan_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView2(0)("sindan_date"))
        If WK_str <> WK_str2 Then
            'Ds_CHG("êfífì˙", WK_str2, WK_str)
            CHG.Text = "êfífì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'êfífì˙
        End If

        If Date004.Number = 0 Then WK_str = Nothing Else WK_str = Date004.Text
        If IsDBNull(DtView2(0)("etmt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_date")
        If WK_str <> WK_str2 Then
            'Ds_CHG("å©êœì˙", WK_str2, WK_str)
            CHG.Text = "å©êœì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'å©êœì˙
        End If

        If Date007.Number = 0 Then WK_str = Nothing Else WK_str = Date007.Text
        If IsDBNull(DtView2(0)("part_ordr_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("part_ordr_date")
        If WK_str <> WK_str2 Then
            CHG.Text = Label015.Text & "ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ïîïiî≠íçì˙
        End If

        If Date008.Number = 0 Then WK_str = Nothing Else WK_str = Date008.Text
        If IsDBNull(DtView2(0)("part_rcpt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("part_rcpt_date")
        If WK_str <> WK_str2 Then
            CHG.Text = Label016.Text & "ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ïîïiéÛóÃì˙
        End If

        If Combo004.Text <> DtView1(0)("rpar_cls_name") Then
            'Ds_CHG("èCóùéÌï ", DtView1(0)("rpar_cls_name"), Combo004.Text)
            CHG.Text = "èCóùéÌï ÅF" & DtView1(0)("rpar_cls_name") & " Å® " & Combo004.Text
            CHG_F = "1" : Exit Sub 'èCóùéÌï 
        End If

        WK_str = Trim(Edit012.Text)
        If IsDBNull(DtView1(0)("orgnl_vndr_code")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("orgnl_vndr_code")
        If WK_str <> WK_str2 Then
            'Ds_CHG("µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ", WK_str2, WK_str)
            CHG.Text = "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        End If

        If DtView1(0)("note_kbn") = "01" Then
            If CheckBox_U001.Checked = False Then
                If CLU001.Text = "01" Then CHG.Text = "íËäzÅFëŒè€ Å® ëŒè€äO" Else CHG.Text = "ÉmÅ[ÉgPCÅFëŒè€ Å® ëŒè€äO"
                CHG_F = "1" : Exit Sub 'ÉmÅ[ÉgPC
            End If
        Else
            If CheckBox_U001.Checked = True Then
                If CLU001.Text = "01" Then CHG.Text = "íËäzÅFëŒè€äO Å® ëŒè€" Else CHG.Text = "ÉmÅ[ÉgPCÅFëŒè€äO Å® ëŒè€"
                CHG_F = "1" : Exit Sub 'ÉmÅ[ÉgPC
            End If
        End If

        If Not IsDBNull(DtView1(0)("note_kbn2")) Then
            If DtView1(0)("note_kbn2") = "01" Then
                If CheckBox_U003.Checked = False Then
                    CHG.Text = "ÇoÇbÅFÉmÅ[Ég Å® ÉfÉXÉNÉgÉbÉv"
                    CHG_F = "1" : Exit Sub 'ÉmÅ[ÉgPC
                End If
            Else
                If CheckBox_U003.Checked = True Then
                    CHG.Text = "ÇoÇbÅFÉfÉXÉNÉgÉbÉv Å® ÉmÅ[Ég"
                    CHG_F = "1" : Exit Sub 'ÉmÅ[ÉgPC
                End If
            End If
        Else
            If CheckBox_U003.Checked = False Then
                CHG.Text = "ÇoÇbÅF    Å® ÉfÉXÉNÉgÉbÉv"
                CHG_F = "1" : Exit Sub 'ÉmÅ[ÉgPC
            Else
                CHG.Text = "ÇoÇbÅF    Å® ÉmÅ[Ég"
                CHG_F = "1" : Exit Sub 'ÉmÅ[ÉgPC
            End If
        End If

        WK_str = Combo_M001.Text
        If IsDBNull(DtView2(0)("etmt_empl_name")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_empl_name")
        If WK_str <> WK_str2 Then
            'Ds_CHG("å©êœíSìñ", WK_str2, WK_str)
            CHG.Text = "å©êœíSìñÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'å©êœíSìñ
        End If

        WK_str = Combo_M003.Text
        If IsDBNull(DtView2(0)("tier_name")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("tier_name")
        If WK_str <> WK_str2 Then
            'Ds_CHG("ìÔà’ìx", WK_str2, WK_str)
            CHG.Text = "ìÔà’ìxÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ìÔà’ìx
        End If

        WK_str = Edit_M001.Text
        If IsDBNull(DtView2(0)("vndr_repr_no")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("vndr_repr_no")
        If WK_str <> WK_str2 Then
            'Ds_CHG("ÉÅÅ[ÉJÅ[èCóùî‘çÜ", WK_str2, WK_str)
            CHG.Text = "ÉÅÅ[ÉJÅ[èCóùî‘çÜÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ÉÅÅ[ÉJÅ[èCóùî‘çÜ
        End If

        If IsDBNull(DtView2(0)("etmt_meas")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_meas")
        If Edit_M002.Text <> WK_str2 Then
            'Ds_CHG("å©êœì‡óe", WK_str2, Edit_M002.Text)
            CHG.Text = "å©êœì‡óeÅF" & WK_str2 & " Å® " & Edit_M002.Text
            CHG_F = "1" : Exit Sub 'å©êœì‡óe
        End If

        If IsDBNull(DtView2(0)("etmt_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_comn")
        If Edit_M003.Text <> WK_str2 Then
            CHG.Text = "å©êœÉRÉÅÉìÉgÅF" & WK_str2 & " Å® " & Edit_M003.Text
            CHG_F = "1" : Exit Sub 'å©êœÉRÉÅÉìÉg
        End If

        If IsDBNull(DtView2(0)("etmt_sum_flg")) Then
            If CheckBox_M001.Checked = True Then
                CHG.Text = "å©êœé©ìÆåvéZâèúÅFëŒè€äO Å® ëŒè€"
                CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
            End If
        Else
            If DtView2(0)("etmt_sum_flg") = "0" Then
                If CheckBox_M001.Checked = True Then
                    CHG.Text = "å©êœé©ìÆåvéZâèúÅFëŒè€äO Å® ëŒè€"
                    CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
                End If
            Else
                If CheckBox_M001.Checked = False Then
                    CHG.Text = "å©êœé©ìÆåvéZâèúÅFëŒè€ Å® ëŒè€äO"
                    CHG_F = "1" : Exit Sub 'é©ìÆåvéZâèú
                End If
            End If
        End If

        If IsDBNull(DtView2(0)("etmt_shop_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_tech_chrg")
        If Number011.Value <> WK_int2 Then
            CHG.Text = "å©êœåvè„ãZèpóøÅF" & WK_int2 & " Å® " & Number011.Value
            CHG_F = "1" : Exit Sub 'å©êœåvè„ãZèpóø
        End If

        If IsDBNull(DtView2(0)("etmt_shop_apes")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_apes")
        If Number012.Value <> WK_int2 Then
            CHG.Text = "å©êœåvè„APESÅF" & WK_int2 & " Å® " & Number012.Value
            CHG_F = "1" : Exit Sub 'APES
        End If

        If IsDBNull(DtView2(0)("etmt_shop_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_part_chrg")
        If Number013.Value <> WK_int2 Then
            CHG.Text = "å©êœåvè„ïîïië„ÅF" & WK_int2 & " Å® " & Number013.Value
            CHG_F = "1" : Exit Sub 'å©êœåvè„ïîïië„
        End If

        If IsDBNull(DtView2(0)("etmt_shop_fee")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_fee")
        If Number014.Value <> WK_int2 Then
            CHG.Text = "å©êœåvè„éËêîóøÅF" & WK_int2 & " Å® " & Number014.Value
            CHG_F = "1" : Exit Sub 'å©êœåvè„éËêîóø
        End If

        If IsDBNull(DtView2(0)("etmt_shop_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_pstg")
        If Number015.Value <> WK_int2 Then
            CHG.Text = "å©êœåvè„ëóóøÅF" & WK_int2 & " Å® " & Number015.Value
            CHG_F = "1" : Exit Sub 'å©êœåvè„ëóóø
        End If

        If IsDBNull(DtView2(0)("etmt_shop_tax")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_tax")
        If Number017.Value <> WK_int2 Then
            CHG.Text = "å©êœåvè„è¡îÔê≈ÅF" & WK_int2 & " Å® " & Number017.Value
            CHG_F = "1" : Exit Sub 'å©êœåvè„è¡îÔê≈
        End If

        If IsDBNull(DtView2(0)("etmt_eu_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_tech_chrg")
        If Number021.Value <> WK_int2 Then
            CHG.Text = "å©êœEUãZèpóøÅF" & WK_int2 & " Å® " & Number021.Value
            CHG_F = "1" : Exit Sub 'å©êœEUãZèpóø
        End If

        If IsDBNull(DtView2(0)("etmt_eu_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_part_chrg")
        If Number023.Value <> WK_int2 Then
            CHG.Text = "å©êœEUïîïië„ÅF" & WK_int2 & " Å® " & Number023.Value
            CHG_F = "1" : Exit Sub 'å©êœEUïîïië„
        End If

        If IsDBNull(DtView2(0)("etmt_eu_fee")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_fee")
        If Number024.Value <> WK_int2 Then
            CHG.Text = "å©êœEUéËêîóøÅF" & WK_int2 & " Å® " & Number024.Value
            CHG_F = "1" : Exit Sub 'å©êœEUéËêîóø
        End If

        If IsDBNull(DtView2(0)("etmt_eu_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_pstg")
        If Number025.Value <> WK_int2 Then
            CHG.Text = "å©êœEUëóóøÅF" & WK_int2 & " Å® " & Number025.Value
            CHG_F = "1" : Exit Sub 'å©êœEUëóóø
        End If

        If IsDBNull(DtView2(0)("etmt_eu_tax")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_tax")
        If Number027.Value <> WK_int2 Then
            CHG.Text = "å©êœEUè¡îÔê≈ÅF" & WK_int2 & " Å® " & Number027.Value
            CHG_F = "1" : Exit Sub 'å©êœEUè¡îÔê≈
        End If

        If IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_tech_chrg")
        If Number031.Value <> WK_int2 Then
            CHG.Text = "å©êœÉRÉXÉgãZèpóøÅF" & WK_int2 & " Å® " & Number031.Value
            CHG_F = "1" : Exit Sub 'å©êœÉRÉXÉgãZèpóø
        End If

        If IsDBNull(DtView2(0)("etmt_cost_apes")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_apes")
        If Number032.Value <> WK_int2 Then
            CHG.Text = "å©êœÉRÉXÉgAPESÅF" & WK_int2 & " Å® " & Number032.Value
            CHG_F = "1" : Exit Sub 'APES
        End If

        If IsDBNull(DtView2(0)("etmt_cost_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_part_chrg")
        If Number033.Value <> WK_int2 Then
            CHG.Text = "å©êœÉRÉXÉgïîïië„ÅF" & WK_int2 & " Å® " & Number033.Value
            CHG_F = "1" : Exit Sub 'å©êœÉRÉXÉgïîïië„
        End If

        If IsDBNull(DtView2(0)("etmt_cost_fee")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_fee")
        If Number034.Value <> WK_int2 Then
            CHG.Text = "å©êœÉRÉXÉgéËêîóøÅF" & WK_int2 & " Å® " & Number034.Value
            CHG_F = "1" : Exit Sub 'å©êœÉRÉXÉgéËêîóø
        End If

        If IsDBNull(DtView2(0)("etmt_cost_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_pstg")
        If Number035.Value <> WK_int2 Then
            CHG.Text = "å©êœÉRÉXÉgëóóøÅF" & WK_int2 & " Å® " & Number035.Value
            CHG_F = "1" : Exit Sub 'å©êœÉRÉXÉgëóóø
        End If

        If IsDBNull(DtView2(0)("etmt_cost_tax")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_tax")
        If Number037.Value <> WK_int2 Then
            CHG.Text = "å©êœÉRÉXÉgè¡îÔê≈ÅF" & WK_int2 & " Å® " & Number037.Value
            CHG_F = "1" : Exit Sub 'å©êœÉRÉXÉgè¡îÔê≈
        End If

        If IsDBNull(DtView2(0)("etmt_shop_cxl")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_cxl")
        If Number019.Value <> WK_int2 Then
            CHG.Text = "å©êœêfífóøÅiÉLÉÉÉìÉZÉãÅjshopÅF" & WK_int2 & " Å® " & Number019.Value
            CHG_F = "1" : Exit Sub 'å©êœêfífóøÅiÉLÉÉÉìÉZÉãÅjshop
        End If

        If IsDBNull(DtView2(0)("etmt_eu_cxl")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_cxl")
        If Number029.Value <> WK_int2 Then
            CHG.Text = "å©êœêfífóøÅiÉLÉÉÉìÉZÉãÅjeuÅF" & WK_int2 & " Å® " & Number029.Value
            CHG_F = "1" : Exit Sub 'å©êœêfífóøÅiÉLÉÉÉìÉZÉãÅjeu
        End If

        'å©êœì‡óe
        For i = 0 To Line_No3
            If label_3(i, 2).Text = Nothing Then
                If cmbBo_3(i, 1).Text <> Nothing Then
                    'í«â¡
                    CHG.Text = "å©êœì‡óeÅFí«â¡"
                    CHG_F = "1" : Exit Sub 'å©êœì‡óe
                End If
            Else
                WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_2"), "seq = " & label_3(i, 2).Text, "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If cmbBo_3(i, 1).Text <> Nothing Then
                        If cmbBo_3(i, 1).Text <> WK_DtView1(0)("cmnt_name1") Then
                            'ïœçX
                            CHG.Text = "å©êœì‡óeÅFïœçX"
                            CHG_F = "1" : Exit Sub 'å©êœì‡óe
                        End If
                    Else
                        'çÌèú
                        CHG.Text = "å©êœì‡óeÅFçÌèú"
                        CHG_F = "1" : Exit Sub 'å©êœì‡óe
                    End If
                End If
            End If
        Next

        'å©êœïîïi
        For i = 0 To 1000
            WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)
            WK_DtView2 = New DataView(DsList1.Tables("T04_REP_PART_MOTO"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)

            If WK_DtView1.Count = 0 Then
                If WK_DtView2.Count = 0 Then
                    Exit For
                Else
                    'çÌèú
                    CHG.Text = "å©êœïîïiÅFçÌèú"
                    CHG_F = "1" : Exit Sub 'å©êœïîïi
                End If
            Else
                If WK_DtView2.Count = 0 Then
                    'í«â¡
                    CHG.Text = "å©êœïîïiÅFí«â¡"
                    CHG_F = "1" : Exit Sub 'å©êœïîïi
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
                        Or WK_DtView1(0)("cost_chrg") <> WK_DtView2(0)("cost_chrg") _
                        Or WK_DtView1(0)("shop_chrg") <> WK_DtView2(0)("shop_chrg") _
                        Or WK_DtView1(0)("eu_chrg") <> WK_DtView2(0)("eu_chrg") _
                        Or WK_DtView1(0)("ordr_no") <> WK_DtView2(0)("ordr_no") _
                        Or WK_DtView1(0)("ordr_no2") <> WK_DtView2(0)("ordr_no2") _
                        Or WK_DtView1(0)("ibm_flg") <> WK_DtView2(0)("ibm_flg") _
                        Or WK_DtView1(0)("exp_flg") <> WK_DtView2(0)("exp_flg") Then
                        'ïœçX
                        CHG.Text = "å©êœïîïiÅFïœçX"
                        CHG_F = "1" : Exit Sub 'å©êœïîïi
                    End If
                End If
            End If
        Next

    End Sub
    Sub Ds_CHG(ByVal str1, ByVal str2, ByVal str3)
        dttable = P_CHG.Tables("CHG")
        dtRow = dttable.NewRow
        dtRow("chge_item") = str1
        dtRow("befr") = str2
        dtRow("aftr") = str3
        dttable.Rows.Add(dtRow)
    End Sub
    '********************************************************************
    '**  ïœçXóöó
    '********************************************************************
    Sub CHG_HSTY()
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

        WK_str = Trim(Edit003.Text)
        If IsDBNull(DtView1(0)("store_prsn")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("store_prsn")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "îÃé–íSìñé“", WK_str2, WK_str)
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

        If Date015.Number = 0 Then WK_str = Nothing Else WK_str = Date015.Text
        If IsDBNull(DtView2(0)("sindan_date")) Then WK_str2 = Nothing Else WK_str2 = String.Format("{0:yyyy/MM/dd HH:mm}", DtView2(0)("sindan_date"))
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "êfífì˙", WK_str2, WK_str)
        End If

        If Date004.Number = 0 Then WK_str = Nothing Else WK_str = Date004.Text
        If IsDBNull(DtView2(0)("etmt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœì˙", WK_str2, WK_str)
        End If

        If Date007.Number = 0 Then WK_str = Nothing Else WK_str = Date007.Text
        If IsDBNull(DtView2(0)("part_ordr_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("part_ordr_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, Label015.Text, WK_str2, WK_str)
        End If

        If Date008.Number = 0 Then WK_str = Nothing Else WK_str = Date008.Text
        If IsDBNull(DtView2(0)("part_rcpt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("part_rcpt_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, Label016.Text, WK_str2, WK_str)
        End If

        If Combo004.Text <> DtView1(0)("rpar_cls_name") Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùéÌï ", DtView1(0)("rpar_cls_name"), Combo004.Text)
        End If

        WK_str = Trim(Edit012.Text)
        If IsDBNull(DtView1(0)("orgnl_vndr_code")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("orgnl_vndr_code")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ", WK_str2, WK_str)
        End If

        If DtView1(0)("note_kbn") = "01" Then
            If CheckBox_U001.Checked = False Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ÉmÅ[ÉgPC", "ëŒè€", "ëŒè€äO")
            End If
        Else
            If CheckBox_U001.Checked = True Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ÉmÅ[ÉgPC", "ëŒè€äO", "ëŒè€")
            End If
        End If

        If Not IsDBNull(DtView1(0)("note_kbn2")) Then
            If DtView1(0)("note_kbn2") = "01" Then
                If CheckBox_U003.Checked = False Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "PC", "ÉmÅ[Ég", "ÉfÉXÉNÉgÉbÉv")
                End If
            Else
                If CheckBox_U003.Checked = True Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "PC", "ÉfÉXÉNÉgÉbÉv", "ÉmÅ[Ég")
                End If
            End If
        Else
            If CheckBox_U003.Checked = False Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "PC", "", "ÉfÉXÉNÉgÉbÉv")
            Else
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "PC", "", "ÉmÅ[Ég")
            End If
        End If

        WK_str = Combo_M001.Text
        If IsDBNull(DtView2(0)("etmt_empl_name")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_empl_name")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœíSìñ", WK_str2, WK_str)
        End If

        WK_str = Combo_M003.Text
        If IsDBNull(DtView2(0)("tier_name")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("tier_name")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ìÔà’ìx", WK_str2, WK_str)
        End If

        If Edit_M001.Visible = True Then WK_str = Edit_M001.Text Else WK_str = Nothing
        If IsDBNull(DtView2(0)("vndr_repr_no")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("vndr_repr_no")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ÉÅÅ[ÉJÅ[èCóùî‘çÜ", WK_str2, WK_str)
        End If

        If CheckBox2_moto.Checked = True Then
            If CheckBox2.Checked = False Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùïsâ¬", "â¬", "ïsâ¬")
            End If
        Else
            If CheckBox2.Checked = True Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùïsâ¬", "ïsâ¬", "â¬")
            End If
        End If

        If IsDBNull(DtView2(0)("etmt_meas")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_meas")
        If Edit_M002.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœì‡óe", WK_str2, Edit_M002.Text)
        End If

        If IsDBNull(DtView2(0)("etmt_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_comn")
        If Edit_M003.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÉRÉÅÉìÉg", WK_str2, Edit_M003.Text)
        End If

        If IsDBNull(DtView2(0)("etmt_sum_flg")) Then
            If CheckBox_M001.Checked = True Then
                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœé©ìÆåvéZâèú", "ëŒè€äO", "ëŒè€")
            End If
        Else
            If DtView2(0)("etmt_sum_flg") = "0" Then
                If CheckBox_M001.Checked = True Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœé©ìÆåvéZâèú", "ëŒè€äO", "ëŒè€")
                End If
            Else
                If CheckBox_M001.Checked = False Then
                    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœé©ìÆåvéZâèú", "ëŒè€", "ëŒè€äO")
                End If
            End If
        End If

        If IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_tech_chrg")
        If Number031.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÉRÉXÉgãZèpóø", WK_int2, Number031.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_cost_apes")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_apes")
        If Number032.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÉRÉXÉgÇ`ÇoÇdÇr", WK_int2, Number032.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_cost_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_part_chrg")
        If Number033.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÉRÉXÉgïîïië„", WK_int2, Number033.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_cost_fee")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_fee")
        If Number034.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÉRÉXÉgÇªÇÃëº", WK_int2, Number034.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_cost_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_pstg")
        If Number035.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÉRÉXÉgëóóø", WK_int2, Number035.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_cost_tax")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_tax")
        If Number037.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÉRÉXÉgè¡îÔê≈", WK_int2, Number037.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_shop_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_tech_chrg")
        If Number011.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœåvè„ãZèpóø", WK_int2, Number011.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_shop_apes")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_apes")
        If Number012.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœåvè„Ç`ÇoÇdÇr", WK_int2, Number012.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_shop_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_part_chrg")
        If Number013.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœåvè„ïîïië„", WK_int2, Number013.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_shop_fee")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_fee")
        If Number014.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœåvè„ÇªÇÃëº", WK_int2, Number014.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_shop_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_pstg")
        If Number015.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœåvè„ëóóø", WK_int2, Number015.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_shop_tax")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_tax")
        If Number017.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœåvè„è¡îÔê≈", WK_int2, Number017.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_eu_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_tech_chrg")
        If Number021.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÇdÇtãZèpóø", WK_int2, Number021.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_eu_part_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_part_chrg")
        If Number023.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÇdÇtïîïië„", WK_int2, Number023.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_eu_fee")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_fee")
        If Number024.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÇdÇtÇªÇÃëº", WK_int2, Number024.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_eu_pstg")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_pstg")
        If Number025.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÇdÇtëóóø", WK_int2, Number025.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_eu_tax")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_tax")
        If Number027.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœÇdÇtè¡îÔê≈", WK_int2, Number027.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_shop_cxl")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_shop_cxl")
        If Number019.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœêfífóøÅiÉLÉÉÉìÉZÉãÅj", WK_int2, Number019.Value)
        End If

        If IsDBNull(DtView2(0)("etmt_eu_cxl")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_eu_cxl")
        If Number029.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "EUå©êœêfífóøÅiÉLÉÉÉìÉZÉãÅj", WK_int2, Number029.Value)
        End If

        'If IsDBNull(DtView2(0)("etmt_cost_cxl")) Then WK_int2 = 0 Else WK_int2 = DtView2(0)("etmt_cost_cxl")
        'If Number039.Value <> WK_int2 Then
        '    chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "∫Ωƒå©êœêfífóøÅiÉLÉÉÉìÉZÉãÅj", WK_int2, Number039.Value)
        'End If
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

            If Date007.Number = 0 Then
                ANS = MessageBox.Show(Label015.Text & "Ç…ì˙ïtÇ™ì¸Ç¡ÇƒÇ¢Ç‹ÇπÇÒÅB" & System.Environment.NewLine & "çXêVÇµÇ‹Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then GoTo end_tab 'Ç¢Ç¢Ç¶
            End If

            If CInt(sn_n.Text) >= 2 Then
                ANS = MessageBox.Show("ä˘Ç…2âÒåä∑ëŒâûçœÇ›Ç≈Ç∑ÅBämîFÇÇ®äËÇ¢ÇµÇ‹Ç∑ÅB" & System.Environment.NewLine & "çXêVÇµÇ‹Ç∑Ç©ÅH", "ämîF", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then GoTo end_tab 'Ç¢Ç¢Ç¶
            End If

            NoDsp_Null()
            CHG_HSTY()  '**  ïœçXóöó

            If chg_itm <> 0 Then
                'éÛït
                strSQL = "UPDATE T01_REP_MTR"
                strSQL += " SET rpar_cls = '" & CL004.Text & "'"
                strSQL += ", store_prsn = '" & Edit003.Text & "'"
                strSQL += ", orgnl_vndr_code = '" & Edit012.Text & "'"
                strSQL += ", etmt_ent_empl_code = " & P_EMPL_NO & ""
                strSQL += ", etmt_brch_code = '" & P_EMPL_BRCH & "'"
                strSQL += ", etmt_empl_code = " & CLM001.Text
                strSQL += ", tier = '" & CLM003.Text & "'"
                If CK_own_flg.Checked = True Then
                    strSQL += ", vndr_repr_no = ''"
                Else
                    strSQL += ", vndr_repr_no = '" & Edit_M001.Text & "'"
                End If
                If CheckBox_U001.Checked = True Then strSQL += ", note_kbn = '01'" Else strSQL += ", note_kbn = '02'"
                If CheckBox_U003.Checked = True Then strSQL += ", note_kbn2 = '01'" Else strSQL += ", note_kbn2 = '02'"
                strSQL += ", wrn_limt_amnt = " & Number001.Value
                strSQL += ", etmt_meas = '" & Edit_M002.Text & "'"
                strSQL += ", etmt_comn = '" & Edit_M003.Text & "'"
                strSQL += ", etmt_cost_tech_chrg = " & Number031.Value
                strSQL += ", etmt_cost_apes = " & Number032.Value
                strSQL += ", etmt_cost_part_chrg = " & Number033.Value
                strSQL += ", etmt_cost_fee = " & Number034.Value
                strSQL += ", etmt_cost_pstg = " & Number035.Value
                strSQL += ", etmt_cost_ttl = " & Number036.Value
                strSQL += ", etmt_cost_tax = " & Number037.Value

                strSQL += ", etmt_shop_tech_chrg = " & Number011.Value
                strSQL += ", etmt_shop_apes = " & Number012.Value
                strSQL += ", etmt_shop_part_chrg = " & Number013.Value
                strSQL += ", etmt_shop_fee = " & Number014.Value
                strSQL += ", etmt_shop_pstg = " & Number015.Value
                strSQL += ", etmt_shop_ttl = " & Number016.Value
                strSQL += ", etmt_shop_tax = " & Number017.Value

                strSQL += ", etmt_eu_tech_chrg = " & Number021.Value
                strSQL += ", etmt_eu_apes = " & Number022.Value
                strSQL += ", etmt_eu_part_chrg = " & Number023.Value
                strSQL += ", etmt_eu_fee = " & Number024.Value
                strSQL += ", etmt_eu_pstg = " & Number025.Value
                strSQL += ", etmt_eu_ttl = " & Number026.Value
                strSQL += ", etmt_eu_tax = " & Number027.Value

                strSQL += ", etmt_shop_cxl = " & Number019.Value
                strSQL += ", etmt_eu_cxl = " & Number029.Value
                strSQL += ", etmt_cost_cxl = " & Number039.Value
                strSQL += ", tech_rate1 = " & NumberN003.Value
                strSQL += ", fix1 = " & NumberN006.Value
                strSQL += ", tech_rate2 = " & NumberN007.Value
                strSQL += ", part_rate2 = " & NumberN008.Value
                If CheckBox_M001.Checked = True Then strSQL += ", etmt_sum_flg = '1'" Else strSQL += ", etmt_sum_flg = '0'"

                If Date004.Number <> 0 Then strSQL += ", etmt_date = '" & Date004.Text & "'" Else strSQL += ", etmt_date = NULL"
                If Date007.Number <> 0 Then strSQL += ", part_ordr_date = '" & Date007.Text & "'" Else strSQL += ", part_ordr_date = NULL"
                If Date008.Number <> 0 Then strSQL += ", part_rcpt_date = '" & Date008.Text & "'" Else strSQL += ", part_rcpt_date = NULL"
                If Date015.Number <> 0 Then strSQL += ", sindan_date = '" & Date015.Text & "'" Else strSQL += ", sindan_date = NULL"
                If CkBox01_Y.Checked = True Then
                    strSQL += ", kashitsu_flg = 1"
                Else
                    If CkBox01_N.Checked = True Then
                        strSQL += ", kashitsu_flg = 0"
                    Else
                        strSQL += ", kashitsu_flg = NULL"
                    End If
                End If
                strSQL += ", tax_rate = " & tax_rate.Text
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Call QA_started_flg_ON(Edit000.Text)    'Q&A íÖéËçœÉtÉâÉOçXêV

            End If

            'å©êœì‡óe
            WK_DsList1.Clear()
            strSQL = "SELECT MAX(seq) AS max_seq FROM T03_REP_CMNT WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2')"
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

            For i = 0 To Line_No3
                If label_3(i, 2).Text = Nothing Then
                    If cmbBo_3(i, 1).Text <> Nothing Then
                        'í«â¡
                        seq = seq + 1

                        strSQL = "INSERT INTO T03_REP_CMNT"
                        strSQL += " (rcpt_no, kbn, seq, cls_code1, cmnt_code1)"
                        strSQL += " VALUES ('" & Edit000.Text & "'"
                        strSQL += ", '2'"
                        strSQL += ", " & seq
                        strSQL += ", '11'"
                        strSQL += ", '" & label_3(i, 1).Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        WK_str = cmbBo_3(i, 1).Text
                        chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœì‡óe" & seq, "", WK_str)

                        label_3(i, 2).Text = seq
                        GoTo skp2
                    End If
                Else
                    WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_2"), "seq = " & label_3(i, 2).Text, "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        If cmbBo_3(i, 1).Text <> Nothing Then
                            If cmbBo_3(i, 1).Text <> WK_DtView1(0)("cmnt_name1") Then
                                'ïœçX
                                strSQL = "UPDATE T03_REP_CMNT"
                                strSQL += " SET cmnt_code1 = '" & label_3(i, 1).Text & "'"
                                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (seq = " & label_3(i, 2).Text & ")"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                DB_OPEN("nMVAR")
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                WK_str = cmbBo_3(i, 1).Text
                                WK_str2 = WK_DtView1(0)("cmnt_name1")
                                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœì‡óe" & label_3(i, 2).Text, WK_str2, WK_str)

                                GoTo skp2
                            End If
                        Else
                            'çÌèú
                            strSQL = "DELETE FROM T03_REP_CMNT"
                            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (seq = " & label_3(i, 2).Text & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            DB_OPEN("nMVAR")
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            WK_str2 = WK_DtView1(0)("cmnt_name1")
                            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœì‡óe" & label_3(i, 2).Text, WK_str2, "")

                            label_3(i, 2).Text = Nothing
                            GoTo skp2
                        End If
                    End If
                End If
skp2:
            Next

            'ïîïi
            For i = 0 To 1000
                WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)
                WK_DtView2 = New DataView(DsList1.Tables("T04_REP_PART_MOTO"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)

                If WK_DtView1.Count = 0 Then
                    If WK_DtView2.Count = 0 Then
                        Exit For
                    Else
                        'çÌèú
                        strSQL = "DELETE FROM T04_REP_PART"
                        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '1') AND (seq = " & WK_DtView2(0)("seq") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        WK_str2 = WK_DtView2(0)("part_code") & " / " & WK_DtView2(0)("part_name") & " / " & Format(WK_DtView2(0)("part_amnt"), "##,##0") & " / " & WK_DtView2(0)("use_qty") & " / " & WK_DtView2(0)("shop_chrg") & " / " & WK_DtView2(0)("eu_chrg") & " / " & WK_DtView2(0)("ordr_no") & " / " & WK_DtView2(0)("ordr_no2")
                        chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœïîïi" & i, WK_str2, "")
                    End If
                Else
                    If IsDBNull(WK_DtView1(0)("ibm_flg")) Then WK_DtView1(0)("ibm_flg") = "False"
                    If IsDBNull(WK_DtView1(0)("exp_flg")) Then WK_DtView1(0)("exp_flg") = "False"
                    If WK_DtView2.Count = 0 Then
                        'í«â¡
                        strSQL = "INSERT INTO T04_REP_PART"
                        strSQL += " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, s_n, ibm_flg, exp_flg)"
                        strSQL += " VALUES ('" & Edit000.Text & "'"
                        strSQL += ", '1'"
                        strSQL += ", " & WK_DtView1(0)("seq")
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

                        WK_str = WK_DtView1(0)("part_code") & " / " & WK_DtView1(0)("part_name") & " / " & Format(WK_DtView1(0)("part_amnt"), "##,##0") & " / " & WK_DtView1(0)("use_qty") & " / " & WK_DtView1(0)("shop_chrg") & " / " & WK_DtView1(0)("eu_chrg") & " / " & WK_DtView1(0)("ordr_no") & " / " & WK_DtView1(0)("ordr_no2") & " / " & WK_DtView1(0)("ibm_flg") & " / " & WK_DtView1(0)("exp_flg")
                        chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœïîïi" & i, "", WK_str)
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
                            Or WK_DtView1(0)("cost_chrg") <> WK_DtView2(0)("cost_chrg") _
                            Or WK_DtView1(0)("shop_chrg") <> WK_DtView2(0)("shop_chrg") _
                            Or WK_DtView1(0)("eu_chrg") <> WK_DtView2(0)("eu_chrg") _
                            Or WK_DtView1(0)("ordr_no") <> WK_DtView2(0)("ordr_no") _
                            Or WK_DtView1(0)("ordr_no2") <> WK_DtView2(0)("ordr_no2") _
                            Or WK_DtView1(0)("ibm_flg") <> WK_DtView2(0)("ibm_flg") _
                            Or WK_DtView1(0)("exp_flg") <> WK_DtView2(0)("exp_flg") Then

                            'ïœçX
                            strSQL = "UPDATE T04_REP_PART"
                            strSQL += " SET part_code = '" & WK_DtView1(0)("part_code") & "'"
                            strSQL += ", part_name = '" & WK_DtView1(0)("part_name") & "'"
                            strSQL += ", part_amnt = " & WK_DtView1(0)("part_amnt") & ""
                            strSQL += ", use_qty = " & WK_DtView1(0)("use_qty") & ""
                            strSQL += ", cost_chrg = " & WK_DtView1(0)("cost_chrg") & ""
                            strSQL += ", shop_chrg = " & WK_DtView1(0)("shop_chrg") & ""
                            strSQL += ", eu_chrg = " & WK_DtView1(0)("eu_chrg") & ""
                            strSQL += ", ordr_no = '" & WK_DtView1(0)("ordr_no") & "'"
                            strSQL += ", ordr_no2 = '" & WK_DtView1(0)("ordr_no2") & "'"
                            strSQL += ", s_n = '" & WK_DtView1(0)("s_n") & "'"
                            If WK_DtView1(0)("ibm_flg") = "True" Then strSQL += ", ibm_flg = 1" Else strSQL += ", ibm_flg = 0"
                            If WK_DtView1(0)("exp_flg") = "True" Then strSQL += ", exp_flg = 1" Else strSQL += ", exp_flg = 0"
                            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                            strSQL += " AND (kbn = '1')"
                            strSQL += " AND (seq = " & WK_DtView1(0)("seq") & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            DB_OPEN("nMVAR")
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            WK_str = WK_DtView1(0)("part_code") & " / " & WK_DtView1(0)("part_name") & " / " & Format(WK_DtView1(0)("part_amnt"), "##,##0") & " / " & WK_DtView1(0)("use_qty") & " / " & WK_DtView1(0)("shop_chrg") & " / " & WK_DtView1(0)("eu_chrg") & " / " & WK_DtView1(0)("ordr_no") & " / " & WK_DtView1(0)("ordr_no2") & " / " & WK_DtView1(0)("ibm_flg") & " / " & WK_DtView1(0)("exp_flg")
                            WK_str2 = WK_DtView2(0)("part_code") & " / " & WK_DtView2(0)("part_name") & " / " & Format(WK_DtView2(0)("part_amnt"), "##,##0") & " / " & WK_DtView2(0)("use_qty") & " / " & WK_DtView2(0)("shop_chrg") & " / " & WK_DtView2(0)("eu_chrg") & " / " & WK_DtView2(0)("ordr_no") & " / " & WK_DtView2(0)("ordr_no2") & " / " & WK_DtView2(0)("ibm_flg") & " / " & WK_DtView2(0)("exp_flg")
                            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "å©êœïîïi" & i, WK_str2, WK_str)
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
                strSQL = "SELECT T01_REP_MTR.tss_etmt_stts, V_TSS_REP_INF.id"
                strSQL += " FROM T01_REP_MTR LEFT OUTER JOIN"
                strSQL += " V_TSS_REP_INF ON T01_REP_MTR.rcpt_no = V_TSS_REP_INF.rcpt_no"
                strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & Edit000.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

                If IsDBNull(WK_DtView1(0)("tss_etmt_stts")) Then
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
                        strSQL += " SET tss_etmt_stts = '1'"
                        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                End If

                'Q&A
                If QA_F = "1" Then
                    Dim WK_trouble_point, WK_parts_name As String
                    Dim WK_ttl_amnt As Integer
                    DB_OPEN("nMVAR")
                    WK_DsList1.Clear()
                    'åÃè·å¬èäÅiå©êœì‡óeÅj
                    strSQL = "SELECT M10_CMNT.cmnt"
                    strSQL += " FROM T03_REP_CMNT INNER JOIN"
                    strSQL += " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
                    strSQL += " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
                    strSQL += " WHERE (T03_REP_CMNT.kbn = '2') AND (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    r = DaList1.Fill(WK_DsList1, "T03_REP_CMNT")
                    If r <> 0 Then
                        WK_DtView1 = New DataView(WK_DsList1.Tables("T03_REP_CMNT"), "", "", DataViewRowState.CurrentRows)
                        For i = 0 To WK_DtView1.Count - 1
                            If i <> 0 Then WK_trouble_point += vbCrLf
                            WK_trouble_point += WK_DtView1(i)("cmnt")
                        Next
                    End If
                    If WK_trouble_point <> Nothing Then WK_trouble_point += vbCrLf
                    WK_trouble_point += Edit_M002.Text
                    'ïîïiñºÅj
                    strSQL = "SELECT part_name"
                    strSQL += " FROM T04_REP_PART"
                    strSQL += " WHERE (kbn = '1') AND (rcpt_no = '" & Edit000.Text & "')"
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
                    strSQL = "SELECT V_cls_052.cls_code_name AS stts_name"
                    strSQL += " FROM QA02_data INNER JOIN"
                    strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
                    strSQL += " WHERE (gss_rcpt_no = N'" & Edit000.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    r = DaList1.Fill(WK_DsList1, "bfr_stts")
                    If r <> 0 Then
                        DtView1 = New DataView(WK_DsList1.Tables("bfr_stts"), "", "", DataViewRowState.CurrentRows)
                        Dim bfr_stts_name As String = DtView1(0)("stts_name")

                        strSQL = "UPDATE QA02_data"
                        If CheckBox2.Checked = False Then
                            strSQL += " SET stts = N'60'"
                            strSQL += ", rep_ng_flg = 0"
                        Else
                            strSQL += " SET stts = N'80'"
                            strSQL += ", rep_ng_flg = 1"
                        End If
                        Dim len As Integer = WK_trouble_point.Length
                        If len > 200 Then
                            WK_trouble_point = WK_trouble_point.Substring(0, 200)
                        End If
                        strSQL += ", trouble_point = N'" & WK_trouble_point & "'"  'åÃè·å¬èäÅiå©êœì‡óeÅj
                        strSQL += ", parts_name = N'" & WK_parts_name & "'"         'ïîïiñº
                        strSQL += ", parts_amnt = " & Number023.Value               '26ïîïiâøäiÅiEUïîïië„Åj
                        strSQL += ", etmt_amnt = 0"                                 '27å©êœóøÅiÅj
                        strSQL += ", tech_amnt = " & Number021.Value                '28ãZèpóøÅiEUãZèpÅj
                        strSQL += ", maker_fee = 0"                                 '29ÉÅÅ[ÉJÅ[éÊéüéËêîóøÅiÅj
                        strSQL += ", pstg = " & Number025.Value                     '30ëóóøÅiEUëóóøÅj
                        strSQL += ", daibiki_fee = 0"                               '31ë„à¯éËêîóøÅiÅj
                        strSQL += ", cxl_amnt = " & Number029.Value                 '32ÉLÉÉÉìÉZÉãóø(êfífóøÅiÉLÉÉÉìÉZÉãÅj)
                        WK_ttl_amnt = Number023.Value + 0 + Number021.Value + 0 + Number025.Value + 0 + Number029.Value
                        strSQL += ", ttl_amnt = " & WK_ttl_amnt                     'çáåväz
                        strSQL += ", snd_flg = 1"
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
                        DtView1 = New DataView(WK_DsList1.Tables("afr_stts"), "", "", DataViewRowState.CurrentRows)
                        Dim afr_stts_name As String = DtView1(0)("stts_name")
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
                Button5.Enabled = True

                If P_PRT_F = "1" Then
                    MessageBox.Show("ïîïiâøäiñ‚çáÇπíÜ", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    msg.Text = "çXêVÇµÇ‹ÇµÇΩÅB"
                Else
                    If CL004.Text = "01" Then   'óLèû

                        P_PRAM1 = Edit000.Text  'éÛïtî‘çÜ
                        P_PRAM2 = Edit001.Text  'îÃé–
                        Dim F00_Form12 As New F00_Form12
                        F00_Form12.ShowDialog()

                        If P_RTN = "1" Then
                            msg.Text = "Ç®å©êœèëÇàÛç¸ÇµÇ‹ÇµÇΩÅB"
                        Else
                            msg.Text = "çXêVÇµÇ‹ÇµÇΩÅB"
                        End If

                        'WK_DsList1.Clear()
                        'strSQL = "SELECT price_rprt_ptn FROM M08_STORE WHERE (store_code = '" & Edit001.Text & "')"
                        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        'DaList1.SelectCommand = SqlCmd1
                        'DB_OPEN("nMVAR")
                        'DaList1.Fill(WK_DsList1, "price_rprt_ptn")
                        'DB_CLOSE()
                        'WK_DtView1 = New DataView(WK_DsList1.Tables("price_rprt_ptn"), "", "", DataViewRowState.CurrentRows)
                        'If WK_DtView1.Count = 0 Then
                        '    PRT_PRAM1 = "Print_R_Mitsumori" 'Ç®å©êœèëàÛç¸
                        '    PRT_PRAM2 = Edit000.Text
                        '    PRT_PRAM3 = "00"
                        '    Dim F70_Form01 As New F70_Form01
                        '    F70_Form01.ShowDialog()

                        'Else
                        '    PRT_PRAM1 = "Print_R_Mitsumori" 'Ç®å©êœèëàÛç¸
                        '    PRT_PRAM2 = Edit000.Text
                        '    PRT_PRAM3 = WK_DtView1(0)("price_rprt_ptn")
                        '    Dim F70_Form01 As New F70_Form01
                        '    F70_Form01.ShowDialog()
                        'End If
                        'msg.Text = "Ç®å©êœèëÇàÛç¸ÇµÇ‹ÇµÇΩÅB"
                    Else
                        msg.Text = "çXêVÇµÇ‹ÇµÇΩÅB"
                    End If
                End If
            End If
        End If
end_tab:
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
        Inz_Dsp()   '**  èâä˙âÊñ ÉZÉbÉg
    End Sub

    '********************************************************************
    '**  Ç®å©êœèëàÛç¸
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CHG_CHK()   '**  ïœçXâ”èäÉ`ÉFÉbÉN
        If CHG_F = "1" Then
            msg.Text = "ïœçXâ”èäÇ™Ç†ÇËÇ‹Ç∑ÅBçXêVå„àÛç¸ÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB"
            Exit Sub
        End If

        P_PRAM1 = Edit000.Text  'éÛïtî‘çÜ
        P_PRAM2 = Edit001.Text  'îÃé–
        Dim F00_Form12 As New F00_Form12
        F00_Form12.ShowDialog()

        If P_RTN = "1" Then
            msg.Text = "Ç®å©êœèëÇàÛç¸ÇµÇ‹ÇµÇΩÅB"
        End If

        'WK_DsList1.Clear()
        'strSQL = "SELECT price_rprt_ptn FROM M08_STORE WHERE (store_code = '" & Edit001.Text & "')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'DaList1.Fill(WK_DsList1, "price_rprt_ptn")
        'DB_CLOSE()
        'WK_DtView1 = New DataView(WK_DsList1.Tables("price_rprt_ptn"), "", "", DataViewRowState.CurrentRows)
        'If WK_DtView1.Count = 0 Then
        '    PRT_PRAM1 = "Print_R_Mitsumori" 'Ç®å©êœèëàÛç¸
        '    PRT_PRAM2 = Edit000.Text
        '    PRT_PRAM3 = "00"
        '    Dim F70_Form01 As New F70_Form01
        '    F70_Form01.ShowDialog()
        'Else
        '    PRT_PRAM1 = "Print_R_Mitsumori" 'Ç®å©êœèëàÛç¸
        '    PRT_PRAM2 = Edit000.Text
        '    PRT_PRAM3 = WK_DtView1(0)("price_rprt_ptn")
        '    Dim F70_Form01 As New F70_Form01
        '    F70_Form01.ShowDialog()
        'End If
        'msg.Text = "Ç®å©êœèëÇàÛç¸ÇµÇ‹ÇµÇΩÅB"
    End Sub

    '********************************************************************
    '**  ñ‚çáÇπ
    '********************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
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
        DsCMB1.Clear() : DsCMB2.Clear() : DsCMB3.Clear() : DsCMB4.Clear()
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
            strSQL = "SELECT rcpt_no, mitumori_kanryou FROM T61_temp_REP_MTR WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'M')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(WK_DsList1, "T61_temp_REP_MTR")
            DB_CLOSE()

            If r = 0 Then
                strSQL = "INSERT INTO T61_temp_REP_MTR (rcpt_no, mitumori_kanryou, rpar_cls, store_prsn, orgnl_vndr_code, etmt_empl_code, tier, vndr_repr_no, note_kbn, note_kbn2, wrn_limt_amnt, etmt_meas, etmt_comn, etmt_cost_tech_chrg, etmt_cost_apes, etmt_cost_part_chrg, etmt_cost_fee, etmt_cost_pstg, etmt_cost_ttl, etmt_cost_tax, etmt_shop_tech_chrg, etmt_shop_apes, etmt_shop_part_chrg, etmt_shop_fee, etmt_shop_pstg, etmt_shop_ttl, etmt_shop_tax, etmt_eu_tech_chrg, etmt_eu_apes, etmt_eu_part_chrg, etmt_eu_fee, etmt_eu_pstg, etmt_eu_ttl, etmt_eu_tax, etmt_shop_cxl, etmt_eu_cxl, etmt_cost_cxl, tech_rate1, fix1, tech_rate2, part_rate2, etmt_sum_flg, etmt_date, part_ordr_date, part_rcpt_date, sindan_date, kashitsu_flg)"
                strSQL += " VALUES ('" & Edit000.Text & "'"    'rcpt_no
                strSQL += ", 'M'"    'mitumori_kanryou
                If CL004.Text <> "" Then
                    strSQL += ", '" & CL004.Text & "'"  'rpar_cls
                Else
                    strSQL += ", NULL"                  'rpar_cls
                End If
                strSQL += ", '" & Edit003.Text & "'"    'store_prsn
                strSQL += ", '" & Edit012.Text & "'"    'orgnl_vndr_code
                If CLM001.Text <> "" Then
                    strSQL += ", " & CLM001.Text        'etmt_empl_code
                Else
                    strSQL += ", NULL"                  'etmt_empl_code
                End If
                strSQL += ", '" & CLM003.Text & "'"     'tier
                If CK_own_flg.Checked = True Then
                    strSQL += ", ''"                        'vndr_repr_no
                Else
                    strSQL += ", '" & Edit_M001.Text & "'"    'vndr_repr_no
                End If
                If CheckBox_U001.Checked = True Then strSQL += ", '01'" Else strSQL += ", '02'" 'note_kbn
                If CheckBox_U003.Checked = True Then strSQL += ", '01'" Else strSQL += ", '02'" 'note_kbn2
                strSQL += ", " & Number001.Value    'wrn_limt_amnt
                strSQL += ", '" & Edit_M002.Text & "'"    'etmt_meas
                strSQL += ", '" & Edit_M003.Text & "'"    'etmt_comn
                strSQL += ", " & Number031.Value    'etmt_cost_tech_chrg
                strSQL += ", " & Number032.Value    'etmt_cost_apes
                strSQL += ", " & Number033.Value    'etmt_cost_part_chrg
                strSQL += ", " & Number034.Value    'etmt_cost_fee
                strSQL += ", " & Number035.Value    'etmt_cost_pstg
                strSQL += ", " & Number036.Value    'etmt_cost_ttl
                strSQL += ", " & Number037.Value    'etmt_cost_tax
                strSQL += ", " & Number011.Value    'etmt_shop_tech_chrg
                strSQL += ", " & Number012.Value    'etmt_shop_apes
                strSQL += ", " & Number013.Value    'etmt_shop_part_chrg
                strSQL += ", " & Number014.Value    'etmt_shop_fee
                strSQL += ", " & Number015.Value    'etmt_shop_pstg
                strSQL += ", " & Number016.Value    'etmt_shop_ttl
                strSQL += ", " & Number017.Value    'etmt_shop_tax
                strSQL += ", " & Number021.Value    'etmt_eu_tech_chrg
                strSQL += ", " & Number022.Value    'etmt_eu_apes
                strSQL += ", " & Number023.Value    'etmt_eu_part_chrg
                strSQL += ", " & Number024.Value    'etmt_eu_fee
                strSQL += ", " & Number025.Value    'etmt_eu_pstg
                strSQL += ", " & Number026.Value    'etmt_eu_ttl
                strSQL += ", " & Number027.Value    'etmt_eu_tax
                strSQL += ", " & Number019.Value    'etmt_shop_cxl
                strSQL += ", " & Number029.Value    'etmt_eu_cxl
                strSQL += ", " & Number039.Value    'etmt_cost_cxl
                strSQL += ", " & NumberN003.Value    'tech_rate1
                strSQL += ", " & NumberN006.Value    'fix1
                strSQL += ", " & NumberN007.Value    'tech_rate2
                strSQL += ", " & NumberN008.Value    'part_rate2
                If CheckBox_M001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" 'etmt_sum_flg
                If Date004.Number <> 0 Then strSQL += ", '" & Date004.Text & "'" Else strSQL += ", NULL" 'etmt_date
                If Date007.Number <> 0 Then strSQL += ", '" & Date007.Text & "'" Else strSQL += ", NULL" 'part_ordr_date
                If Date008.Number <> 0 Then strSQL += ", '" & Date008.Text & "'" Else strSQL += ", NULL" 'part_rcpt_date
                If Date015.Number <> 0 Then strSQL += ", '" & Date015.Text & "'" Else strSQL += ", NULL" 'sindan_date
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
                If CL004.Text <> "" Then
                    strSQL += " SET rpar_cls = '" & CL004.Text & "'"
                Else
                    strSQL += " SET rpar_cls = NULL"
                End If
                strSQL += ", store_prsn = '" & Edit003.Text & "'"
                strSQL += ", orgnl_vndr_code = '" & Edit012.Text & "'"
                If CLM001.Text <> "" Then
                    strSQL += ", etmt_empl_code = " & CLM001.Text
                Else
                    strSQL += ", etmt_empl_code = NULL"
                End If
                strSQL += ", tier = '" & CLM003.Text & "'"
                If CK_own_flg.Checked = True Then
                    strSQL += ", vndr_repr_no = ''"
                Else
                    strSQL += ", vndr_repr_no = '" & Edit_M001.Text & "'"
                End If
                If CheckBox_U001.Checked = True Then strSQL += ", note_kbn = '01'" Else strSQL += ", note_kbn = '02'"
                If CheckBox_U003.Checked = True Then strSQL += ", note_kbn2 = '01'" Else strSQL += ", note_kbn2 = '02'"
                strSQL += ", wrn_limt_amnt = " & Number001.Value
                strSQL += ", etmt_meas = '" & Edit_M002.Text & "'"
                strSQL += ", etmt_comn = '" & Edit_M003.Text & "'"
                strSQL += ", etmt_cost_tech_chrg = " & Number031.Value
                strSQL += ", etmt_cost_apes = " & Number032.Value
                strSQL += ", etmt_cost_part_chrg = " & Number033.Value
                strSQL += ", etmt_cost_fee = " & Number034.Value
                strSQL += ", etmt_cost_pstg = " & Number035.Value
                strSQL += ", etmt_cost_ttl = " & Number036.Value
                strSQL += ", etmt_cost_tax = " & Number037.Value

                strSQL += ", etmt_shop_tech_chrg = " & Number011.Value
                strSQL += ", etmt_shop_apes = " & Number012.Value
                strSQL += ", etmt_shop_part_chrg = " & Number013.Value
                strSQL += ", etmt_shop_fee = " & Number014.Value
                strSQL += ", etmt_shop_pstg = " & Number015.Value
                strSQL += ", etmt_shop_ttl = " & Number016.Value
                strSQL += ", etmt_shop_tax = " & Number017.Value

                strSQL += ", etmt_eu_tech_chrg = " & Number021.Value
                strSQL += ", etmt_eu_apes = " & Number022.Value
                strSQL += ", etmt_eu_part_chrg = " & Number023.Value
                strSQL += ", etmt_eu_fee = " & Number024.Value
                strSQL += ", etmt_eu_pstg = " & Number025.Value
                strSQL += ", etmt_eu_ttl = " & Number026.Value
                strSQL += ", etmt_eu_tax = " & Number027.Value

                strSQL += ", etmt_shop_cxl = " & Number019.Value
                strSQL += ", etmt_eu_cxl = " & Number029.Value
                strSQL += ", etmt_cost_cxl = " & Number039.Value
                strSQL += ", tech_rate1 = " & NumberN003.Value
                strSQL += ", fix1 = " & NumberN006.Value
                strSQL += ", tech_rate2 = " & NumberN007.Value
                strSQL += ", part_rate2 = " & NumberN008.Value
                If CheckBox_M001.Checked = True Then strSQL += ", etmt_sum_flg = '1'" Else strSQL += ", etmt_sum_flg = '0'"

                If Date004.Number <> 0 Then strSQL += ", etmt_date = '" & Date004.Text & "'" Else strSQL += ", etmt_date = NULL"
                If Date007.Number <> 0 Then strSQL += ", part_ordr_date = '" & Date007.Text & "'" Else strSQL += ", part_ordr_date = NULL"
                If Date008.Number <> 0 Then strSQL += ", part_rcpt_date = '" & Date008.Text & "'" Else strSQL += ", part_rcpt_date = NULL"
                If Date015.Number <> 0 Then strSQL += ", sindan_date = '" & Date015.Text & "'" Else strSQL += ", sindan_date = NULL"
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
                strSQL += " AND (mitumori_kanryou = 'M')"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()


            'å©êœì‡óe
            WK_DsList1.Clear()
            strSQL = "SELECT MAX(seq) AS max_seq FROM T03_REP_CMNT WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2')"
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
            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'M') "
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            For i = 0 To Line_No3
                If label_3(i, 2).Text = Nothing Then
                    seq = seq + 1
                    WK_seq = seq
                Else
                    WK_seq = label_3(i, 2).Text
                End If
                If cmbBo_3(i, 1).Text <> Nothing Then
                    'í«â¡

                    strSQL = "INSERT INTO T63_temp_REP_CMNT"
                    strSQL += " (rcpt_no, kbn, seq, mitumori_kanryou, cls_code1, cmnt_code1)"
                    strSQL += " VALUES ('" & Edit000.Text & "'"
                    strSQL += ", '2'"
                    strSQL += ", " & WK_seq
                    strSQL += ", 'M'"
                    strSQL += ", '11'"
                    strSQL += ", '" & label_3(i, 1).Text & "')"
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
            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '1') AND (mitumori_kanryou = 'M')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            For i = 0 To 1000
                WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)

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
                    strSQL += ", '1'"
                    strSQL += ", " & WK_DtView1(0)("seq")
                    strSQL += ", 'M'"
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
        SqlCmd1 = New SqlClient.SqlCommand("sp_T61_temp_REP_MTR_M", cnsqlclient)
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

            If Not IsDBNull(WK_DtView4(0)("rpar_cls")) Then CL004.Text = WK_DtView4(0)("rpar_cls") Else CL004.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("rpar_cls_name")) Then Combo004.Text = WK_DtView4(0)("rpar_cls_name") Else Combo004.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("store_prsn")) Then Edit003.Text = WK_DtView4(0)("store_prsn") Else Edit003.Text = Nothing
            Edit012.Text = WK_DtView4(0)("orgnl_vndr_code")
            If Not IsDBNull(WK_DtView4(0)("etmt_empl_code")) Then CLM001.Text = WK_DtView4(0)("etmt_empl_code") Else CLM001.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("etmt_empl_name")) Then Combo_M001.Text = WK_DtView4(0)("etmt_empl_name") Else Combo_M001.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("tier")) Then CLM003.Text = WK_DtView4(0)("tier") Else CLM003.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("tier_name")) Then Combo_M003.Text = WK_DtView4(0)("tier_name") Else Combo_M003.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("vndr_repr_no")) Then Edit_M001.Text = WK_DtView4(0)("vndr_repr_no") Else Edit_M001.Text = Nothing
            If WK_DtView4(0)("note_kbn") = "01" Then CheckBox_U001.Checked = True Else CheckBox_U001.Checked = False
            If Not IsDBNull(WK_DtView4(0)("note_kbn2")) Then
                If WK_DtView4(0)("note_kbn2") = "01" Then CheckBox_U003.Checked = True Else CheckBox_U003.Checked = False
            Else
                CheckBox_U003.Checked = False
            End If
            If Not IsDBNull(WK_DtView4(0)("wrn_limt_amnt")) Then Number001.Value = WK_DtView4(0)("wrn_limt_amnt") Else Number001.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_meas")) Then Edit_M002.Text = WK_DtView4(0)("etmt_meas") Else Edit_M002.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("etmt_comn")) Then Edit_M003.Text = WK_DtView4(0)("etmt_comn") Else Edit_M003.Text = Nothing
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_tech_chrg")) Then Number031.Value = WK_DtView4(0)("etmt_cost_tech_chrg") Else Number031.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_apes")) Then Number032.Value = WK_DtView4(0)("etmt_cost_apes") Else Number032.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_part_chrg")) Then Number033.Value = WK_DtView4(0)("etmt_cost_part_chrg") Else Number033.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_fee")) Then Number034.Value = WK_DtView4(0)("etmt_cost_fee") Else Number034.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_pstg")) Then Number035.Value = WK_DtView4(0)("etmt_cost_pstg") Else Number035.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_ttl")) Then
                Number036.Value = WK_DtView4(0)("etmt_cost_ttl")
            Else
                Number036.Value = Number031.Value + Number032.Value + Number033.Value + Number034.Value + Number035.Value
            End If
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_tax")) Then Number037.Value = WK_DtView4(0)("etmt_cost_tax") Else Number037.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_shop_tech_chrg")) Then Number011.Value = WK_DtView4(0)("etmt_shop_tech_chrg") Else Number011.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_shop_apes")) Then Number012.Value = WK_DtView4(0)("etmt_shop_apes") Else Number012.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_shop_part_chrg")) Then Number013.Value = WK_DtView4(0)("etmt_shop_part_chrg") Else Number013.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_shop_fee")) Then Number014.Value = WK_DtView4(0)("etmt_shop_fee") Else Number014.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_shop_pstg")) Then Number015.Value = WK_DtView4(0)("etmt_shop_pstg") Else Number015.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_shop_ttl")) Then
                Number016.Value = WK_DtView4(0)("etmt_shop_ttl")
            Else
                Number016.Value = Number011.Value + Number012.Value + Number013.Value + Number014.Value + Number015.Value
            End If
            If Not IsDBNull(WK_DtView4(0)("etmt_eu_tech_chrg")) Then Number021.Value = WK_DtView4(0)("etmt_eu_tech_chrg") Else Number021.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_eu_apes")) Then Number022.Value = WK_DtView4(0)("etmt_eu_apes") Else Number022.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_eu_part_chrg")) Then Number023.Value = WK_DtView4(0)("etmt_eu_part_chrg") Else Number023.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_eu_fee")) Then Number024.Value = WK_DtView4(0)("etmt_eu_fee") Else Number024.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_eu_pstg")) Then Number025.Value = WK_DtView4(0)("etmt_eu_pstg") Else Number025.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_eu_ttl")) Then
                Number026.Value = WK_DtView4(0)("etmt_eu_ttl")
            Else
                Number026.Value = Number021.Value + Number023.Value + Number024.Value + Number025.Value
            End If
            If Not IsDBNull(WK_DtView4(0)("etmt_shop_cxl")) Then Number019.Value = WK_DtView4(0)("etmt_shop_cxl") Else Number019.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_eu_cxl")) Then Number029.Value = WK_DtView4(0)("etmt_eu_cxl") Else Number029.Value = 0
            If Not IsDBNull(WK_DtView4(0)("etmt_cost_cxl")) Then Number039.Value = WK_DtView4(0)("etmt_cost_cxl") Else Number039.Value = 0
            If Not IsDBNull(WK_DtView4(0)("tech_rate1")) Then NumberN003.Value = WK_DtView4(0)("tech_rate1") Else NumberN003.Value = 0
            If Not IsDBNull(WK_DtView4(0)("fix1")) Then NumberN006.Value = WK_DtView4(0)("fix1") Else NumberN006.Value = 0
            If Not IsDBNull(WK_DtView4(0)("tech_rate2")) Then NumberN007.Value = WK_DtView4(0)("tech_rate2") Else NumberN007.Value = 0
            If Not IsDBNull(WK_DtView4(0)("part_rate2")) Then NumberN008.Value = WK_DtView4(0)("part_rate2") Else NumberN008.Value = 0
            If IsDBNull(WK_DtView4(0)("etmt_sum_flg")) Then
                CheckBox_M001.Checked = False
            Else
                If WK_DtView4(0)("etmt_sum_flg") = "False" Then
                    CheckBox_M001.Checked = False
                Else
                    CheckBox_M001.Checked = True
                End If
            End If
            If Not IsDBNull(WK_DtView4(0)("etmt_date")) Then
                Date004.Text = WK_DtView4(0)("etmt_date")
                Button5.Enabled = True
                tax(String.Format("{0:yyyy/MM/dd}", CDate(Date004.Text)))
            Else
                Button5.Enabled = False
            End If
            If Not IsDBNull(WK_DtView4(0)("part_ordr_date")) Then Date007.Text = WK_DtView4(0)("part_ordr_date")
            If Not IsDBNull(WK_DtView4(0)("part_rcpt_date")) Then Date008.Text = WK_DtView4(0)("part_rcpt_date")
            If Not IsDBNull(WK_DtView4(0)("sindan_date")) Then
                Date015.Text = String.Format("{0:yyyy/MM/dd HH:mm}", WK_DtView4(0)("sindan_date"))
            End If
            If Not IsDBNull(WK_DtView4(0)("kashitsu_flg")) Then
                If WK_DtView4(0)("kashitsu_flg") = "1" Then
                    CkBox01_Y.Checked = True
                Else
                    CkBox01_N.Checked = True
                End If
            End If
            If Not IsDBNull(WK_DtView4(0)("recv_amnt")) Then Number002.Value = WK_DtView4(0)("recv_amnt") Else Number002.Value = 0

            'å©êœì‡óe
            WK_DsList4.Clear()
            strSQL = "SELECT T03_REP_CMNT.seq"
            strSQL += " FROM T03_REP_CMNT LEFT OUTER JOIN"
            strSQL += " T63_temp_REP_CMNT ON T03_REP_CMNT.rcpt_no = T63_temp_REP_CMNT.rcpt_no AND "
            strSQL += " T03_REP_CMNT.kbn = T63_temp_REP_CMNT.kbn AND T03_REP_CMNT.seq = T63_temp_REP_CMNT.seq"
            strSQL += " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
            strSQL += " AND (T03_REP_CMNT.kbn = '2')"
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
            strSQL += " AND (T63_temp_REP_CMNT.kbn = '2')"
            strSQL += " AND (T63_temp_REP_CMNT.mitumori_kanryou = 'M')"
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
                            For i = 0 To Line_No3 - 1
                                If label_3(i, 2).Text = WK_DtView4(j)("seq") Then
                                    cmbBo_3(i, 1).Text = WK_DtView4(j)("cmnt_name1")
                                    label_3(i, 1).Text = WK_DtView4(j)("cmnt_code1")
                                End If
                            Next
                        End If
                    Else
                        If wk_line = 0 Then
                            If Line_No3 = 0 Then
                                wk_line = Line_No3
                                cmbBo_3(wk_line, 1).Text = WK_DtView4(j)("cmnt_name1")
                                label_3(wk_line, 1).Text = WK_DtView4(j)("cmnt_code1")
                                wk_line = wk_line + 1
                            Else
                                Line_No3 = Line_No3 + 1
                                wk_line = Line_No3
                                add_line_3_2(wk_line, WK_DtView4(j)("cmnt_name1"), WK_DtView4(j)("cmnt_code1"))  'å©êœì‡óe
                            End If
                        Else
                            Line_No3 = Line_No3 + 1
                            wk_line = Line_No3
                            add_line_3_2(wk_line, WK_DtView4(j)("cmnt_name1"), WK_DtView4(j)("cmnt_code1"))  'å©êœì‡óe
                        End If
                    End If
                Next
                If wk_line <> 0 Then
                    add_line_3("0")    'å©êœì‡óe
                End If
            End If

            'ïîïi
            WK_DsList4.Clear()
            strSQL = "SELECT seq"
            strSQL += " FROM T64_temp_REP_PART"
            strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '1') AND (mitumori_kanryou = 'M')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(WK_DsList4, "T64_temp_REP_PART")
            DB_CLOSE()
            If r <> 0 Then

                P_DsList1.Tables("T04_REP_PART").Clear()
                SqlCmd1 = New SqlClient.SqlCommand("sp_T64_temp_REP_PART", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 1)
                Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 1)
                Pram3.Value = Edit000.Text
                Pram4.Value = "1"
                Pram5.Value = "M"
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(P_DsList1, "T04_REP_PART")
                DB_CLOSE()

                strSQL = "SELECT seq"
                strSQL += " FROM T04_REP_PART"
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '1')"
                strSQL += " UNION"
                strSQL += " SELECT seq"
                strSQL += " FROM T64_temp_REP_PART"
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '1') AND (mitumori_kanryou = 'M')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList4, "SEQ")
                DB_CLOSE()
                WK_DtView4 = New DataView(WK_DsList4.Tables("SEQ"), "", "", DataViewRowState.CurrentRows)
                j = -1
                For i = 0 To WK_DtView4.Count - 1

                    WK_DtView5 = New DataView(P_DsList1.Tables("T04_REP_PART"), "SEQ=" & WK_DtView4(i)("SEQ"), "", DataViewRowState.CurrentRows)
                    If WK_DtView5.Count <> 0 Then
                        WK_DtView5(0)("ID_NO") = i
                        WK_DtView6 = New DataView(DsList1.Tables("T04_REP_PART_MOTO"), "SEQ=" & WK_DtView4(i)("SEQ"), "", DataViewRowState.CurrentRows)
                        If WK_DtView6.Count = 0 Then
                            WK_DtView5(0)("rcpt_no") = DBNull.Value
                            WK_DtView5(0)("kbn") = DBNull.Value
                        End If
                    End If

                Next

            End If

            Dim tbl As New DataTable
            tbl = P_DsList1.Tables("T04_REP_PART")
            DataGrid_M1.DataSource = tbl

        End If

    End Sub

    'àÍéûï€ë∂ÉNÉäÉA
    Sub temp_clr()

        'ÉRÉÅÉìÉg
        strSQL = "DELETE FROM T61_temp_REP_MTR"
        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'M') "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        'ÉRÉÅÉìÉg
        strSQL = "DELETE FROM T63_temp_REP_CMNT"
        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (mitumori_kanryou = 'M') "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        'ïîïi
        strSQL = "DELETE FROM T64_temp_REP_PART"
        strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '1') AND (mitumori_kanryou = 'M')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim F99_WK As New F99_WK
        F99_WK.ShowDialog()
    End Sub
End Class