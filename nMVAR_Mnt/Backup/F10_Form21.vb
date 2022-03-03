Public Class F10_Form21
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB0, DsCMB1, DsCMB2, WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, DtView2, DtView3, WK_DtView1, WK_DtView2, WK_DtView3 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F, CSR_POS, CHG_F, ANS, inz_F As String
    Dim i, en, Line_No, Line_No2, Line_No3, Line_No4, chg_itm, seq, WK_cnt, WK_tax As Integer
    Dim WK_str, WK_str2 As String
    Dim WK_int, WK_int2 As Integer
    Dim Irregular_F As String = "0"
    Dim cmb_reset As String

    'ïtëÆïi
    Private chkBox(99, 1) As CheckBox
    Private label(99, 2) As Label
    Private nbrBox(99, 1) As GrapeCity.Win.Input.Number
    Private edit(99, 2) As GrapeCity.Win.Input.Edit
    Private nbrBox_MOTO(99, 1) As GrapeCity.Win.Input.Number
    Private edit_MOTO(99, 2) As GrapeCity.Win.Input.Edit

    'åÃè·ì‡óe
    Private cmbBo_2(99, 1) As GrapeCity.Win.Input.Combo
    Private label_2(99, 2) As label
    Dim WK_DsCMB As New DataSet

    'å©êœì‡óe
    Private cmbBo_3(99, 1) As GrapeCity.Win.Input.Combo
    Private label_3(99, 2) As Label
    Private cmbBo_3_MOTO(99, 1) As GrapeCity.Win.Input.Combo
    Dim WK_DsCMB3 As New DataSet

    'äÆóπì‡óe
    Private cmbBo_4(99, 1) As GrapeCity.Win.Input.Combo
    Private label_4(99, 2) As Label
    Dim WK_DsCMB4 As New DataSet

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
    Friend WithEvents Date013 As GrapeCity.Win.Input.Date
    Friend WithEvents Edit903 As GrapeCity.Win.Input.Edit
    Friend WithEvents Date011 As GrapeCity.Win.Input.Date
    Friend WithEvents Date007 As GrapeCity.Win.Input.Date
    Friend WithEvents Date006 As GrapeCity.Win.Input.Date
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Date012 As GrapeCity.Win.Input.Date
    Friend WithEvents Date010 As GrapeCity.Win.Input.Date
    Friend WithEvents Date008 As GrapeCity.Win.Input.Date
    Friend WithEvents Date004 As GrapeCity.Win.Input.Date
    Friend WithEvents Date003 As GrapeCity.Win.Input.Date
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Edit
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Mask
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label014 As System.Windows.Forms.Label
    Friend WithEvents Combo004 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit007 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
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
    Friend WithEvents Combo_U001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Edit_U004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo_U002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Panel_U2 As System.Windows.Forms.Panel
    Friend WithEvents Edit_U002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_U005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_U003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Date_U001 As GrapeCity.Win.Input.Date
    Friend WithEvents Edit_U001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Panel_U1 As System.Windows.Forms.Panel
    Friend WithEvents Button_M001 As System.Windows.Forms.Button
    Friend WithEvents Panel_M1 As System.Windows.Forms.Panel
    Friend WithEvents Edit_M004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_M003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_M002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_M001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo_M001 As GrapeCity.Win.Input.Combo
    Friend WithEvents DataGrid_M1 As System.Windows.Forms.DataGrid
    Friend WithEvents Panel_K1 As System.Windows.Forms.Panel
    Friend WithEvents Edit_K002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_K001 As GrapeCity.Win.Input.Edit
    Friend WithEvents DataGrid_K1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button_K001 As System.Windows.Forms.Button
    Friend WithEvents Combo_K001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Edit008 As GrapeCity.Win.Input.Edit
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents CheckBox_U001 As System.Windows.Forms.CheckBox
    Friend WithEvents Edit011 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label_M02 As System.Windows.Forms.Label
    Friend WithEvents Label_M01 As System.Windows.Forms.Label
    Friend WithEvents Combo_M003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label_M04 As System.Windows.Forms.Label
    Friend WithEvents Edit012 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Number016 As GrapeCity.Win.Input.Number
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Number015 As GrapeCity.Win.Input.Number
    Friend WithEvents Number025 As GrapeCity.Win.Input.Number
    Friend WithEvents Number024 As GrapeCity.Win.Input.Number
    Friend WithEvents Number017 As GrapeCity.Win.Input.Number
    Friend WithEvents Number040 As GrapeCity.Win.Input.Number
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Number032 As GrapeCity.Win.Input.Number
    Friend WithEvents Number012 As GrapeCity.Win.Input.Number
    Friend WithEvents Number031 As GrapeCity.Win.Input.Number
    Friend WithEvents Number022 As GrapeCity.Win.Input.Number
    Friend WithEvents Number011 As GrapeCity.Win.Input.Number
    Friend WithEvents Number014 As GrapeCity.Win.Input.Number
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Number021 As GrapeCity.Win.Input.Number
    Friend WithEvents Number033 As GrapeCity.Win.Input.Number
    Friend WithEvents Label22_1 As System.Windows.Forms.Label
    Friend WithEvents Label23_1 As System.Windows.Forms.Label
    Friend WithEvents Number037 As GrapeCity.Win.Input.Number
    Friend WithEvents Number036 As GrapeCity.Win.Input.Number
    Friend WithEvents Number035 As GrapeCity.Win.Input.Number
    Friend WithEvents Number034 As GrapeCity.Win.Input.Number
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents Number023 As GrapeCity.Win.Input.Number
    Friend WithEvents Number013 As GrapeCity.Win.Input.Number
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Number027 As GrapeCity.Win.Input.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Number038 As GrapeCity.Win.Input.Number
    Friend WithEvents Number028 As GrapeCity.Win.Input.Number
    Friend WithEvents Number018 As GrapeCity.Win.Input.Number
    Friend WithEvents Number026 As GrapeCity.Win.Input.Number
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
    Friend WithEvents Date_U002 As GrapeCity.Win.Input.Date
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Number111 As GrapeCity.Win.Input.Number
    Friend WithEvents Number116 As GrapeCity.Win.Input.Number
    Friend WithEvents Number115 As GrapeCity.Win.Input.Number
    Friend WithEvents Number125 As GrapeCity.Win.Input.Number
    Friend WithEvents Number124 As GrapeCity.Win.Input.Number
    Friend WithEvents Number117 As GrapeCity.Win.Input.Number
    Friend WithEvents Number132 As GrapeCity.Win.Input.Number
    Friend WithEvents Number112 As GrapeCity.Win.Input.Number
    Friend WithEvents Number131 As GrapeCity.Win.Input.Number
    Friend WithEvents Number122 As GrapeCity.Win.Input.Number
    Friend WithEvents Number114 As GrapeCity.Win.Input.Number
    Friend WithEvents Number121 As GrapeCity.Win.Input.Number
    Friend WithEvents Number133 As GrapeCity.Win.Input.Number
    Friend WithEvents Number137 As GrapeCity.Win.Input.Number
    Friend WithEvents Number136 As GrapeCity.Win.Input.Number
    Friend WithEvents Number135 As GrapeCity.Win.Input.Number
    Friend WithEvents Number134 As GrapeCity.Win.Input.Number
    Friend WithEvents Number123 As GrapeCity.Win.Input.Number
    Friend WithEvents Number113 As GrapeCity.Win.Input.Number
    Friend WithEvents Number127 As GrapeCity.Win.Input.Number
    Friend WithEvents Number138 As GrapeCity.Win.Input.Number
    Friend WithEvents Number128 As GrapeCity.Win.Input.Number
    Friend WithEvents Number118 As GrapeCity.Win.Input.Number
    Friend WithEvents Number126 As GrapeCity.Win.Input.Number
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents Ck_atri_flg As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CLU001 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CLK001 As System.Windows.Forms.Label
    Friend WithEvents Label_K01 As System.Windows.Forms.Label
    Friend WithEvents CK_own_flg As System.Windows.Forms.CheckBox
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Combo
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents Date_U003 As GrapeCity.Win.Input.Date
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents zero_code As System.Windows.Forms.Label
    Friend WithEvents zero_name As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents NumberN009 As GrapeCity.Win.Input.Number
    Friend WithEvents kengen As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Combo1 As GrapeCity.Win.Input.Combo
    Friend WithEvents Number1 As GrapeCity.Win.Input.Number
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Edit013 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo_K002 As GrapeCity.Win.Input.Combo
    Friend WithEvents CLK002 As System.Windows.Forms.Label
    Friend WithEvents CL004 As System.Windows.Forms.Label
    Friend WithEvents Label_K02 As System.Windows.Forms.Label
    Friend WithEvents GRP As System.Windows.Forms.Label
    Friend WithEvents CLU002 As System.Windows.Forms.Label
    Friend WithEvents Number001_nTax As GrapeCity.Win.Input.Number
    Friend WithEvents Number039 As GrapeCity.Win.Input.Number
    Friend WithEvents Number029 As GrapeCity.Win.Input.Number
    Friend WithEvents Number019 As GrapeCity.Win.Input.Number
    Friend WithEvents CLK001_BRH As System.Windows.Forms.Label
    Friend WithEvents CHG As System.Windows.Forms.Label
    Friend WithEvents rebate As GrapeCity.Win.Input.Number
    Friend WithEvents CLK003 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Combo_K003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents EDIT904 As GrapeCity.Win.Input.Edit
    Friend WithEvents CL005 As System.Windows.Forms.Label
    Friend WithEvents CL002_2 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_U002 As System.Windows.Forms.CheckBox
    Friend WithEvents CLM003 As System.Windows.Forms.Label
    Friend WithEvents CLM001 As System.Windows.Forms.Label
    Friend WithEvents apse As System.Windows.Forms.Label
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo007 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL006 As System.Windows.Forms.Label
    Friend WithEvents CL007 As System.Windows.Forms.Label
    Friend WithEvents Combo_K003_moto As System.Windows.Forms.Label
    Friend WithEvents NumberN008 As GrapeCity.Win.Input.Number
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F10_Form21))
        Me.Panel_éÛït = New System.Windows.Forms.Panel
        Me.CheckBox_U002 = New System.Windows.Forms.CheckBox
        Me.CLU001 = New System.Windows.Forms.Label
        Me.CLU002 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Date_U002 = New GrapeCity.Win.Input.Date
        Me.CheckBox_U001 = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Combo_U001 = New GrapeCity.Win.Input.Combo
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
        Me.Edit_U001 = New GrapeCity.Win.Input.Edit
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel_U1 = New System.Windows.Forms.Panel
        Me.pos = New System.Windows.Forms.Label
        Me.Label19_1 = New System.Windows.Forms.Label
        Me.Date_U001 = New GrapeCity.Win.Input.Date
        Me.Label33 = New System.Windows.Forms.Label
        Me.Date_U003 = New GrapeCity.Win.Input.Date
        Me.Panel_å©êœ = New System.Windows.Forms.Panel
        Me.CLM003 = New System.Windows.Forms.Label
        Me.CLM001 = New System.Windows.Forms.Label
        Me.Number039 = New GrapeCity.Win.Input.Number
        Me.Number029 = New GrapeCity.Win.Input.Number
        Me.Number019 = New GrapeCity.Win.Input.Number
        Me.Number016 = New GrapeCity.Win.Input.Number
        Me.Label133 = New System.Windows.Forms.Label
        Me.Label132 = New System.Windows.Forms.Label
        Me.Number015 = New GrapeCity.Win.Input.Number
        Me.Number025 = New GrapeCity.Win.Input.Number
        Me.Number024 = New GrapeCity.Win.Input.Number
        Me.Number017 = New GrapeCity.Win.Input.Number
        Me.Number040 = New GrapeCity.Win.Input.Number
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
        Me.Button_M001 = New System.Windows.Forms.Button
        Me.Panel_M1 = New System.Windows.Forms.Panel
        Me.Edit_M004 = New GrapeCity.Win.Input.Edit
        Me.Edit_M003 = New GrapeCity.Win.Input.Edit
        Me.Edit_M002 = New GrapeCity.Win.Input.Edit
        Me.Edit_M001 = New GrapeCity.Win.Input.Edit
        Me.Label12_1 = New System.Windows.Forms.Label
        Me.Label13_1 = New System.Windows.Forms.Label
        Me.Label14_1 = New System.Windows.Forms.Label
        Me.Label_M01 = New System.Windows.Forms.Label
        Me.Combo_M001 = New GrapeCity.Win.Input.Combo
        Me.Label_M02 = New System.Windows.Forms.Label
        Me.Label33_1 = New System.Windows.Forms.Label
        Me.DataGrid_M1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label_M04 = New System.Windows.Forms.Label
        Me.Combo_M003 = New GrapeCity.Win.Input.Combo
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button0 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel_äÆóπ = New System.Windows.Forms.Panel
        Me.Combo_K003_moto = New System.Windows.Forms.Label
        Me.apse = New System.Windows.Forms.Label
        Me.CLK003 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Combo_K003 = New GrapeCity.Win.Input.Combo
        Me.CLK002 = New System.Windows.Forms.Label
        Me.CLK001 = New System.Windows.Forms.Label
        Me.rebate = New GrapeCity.Win.Input.Number
        Me.Label_K02 = New System.Windows.Forms.Label
        Me.Combo_K002 = New GrapeCity.Win.Input.Combo
        Me.Number1 = New GrapeCity.Win.Input.Number
        Me.Label19 = New System.Windows.Forms.Label
        Me.Combo1 = New GrapeCity.Win.Input.Combo
        Me.zero_name = New System.Windows.Forms.Label
        Me.Number116 = New GrapeCity.Win.Input.Number
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Number115 = New GrapeCity.Win.Input.Number
        Me.Number125 = New GrapeCity.Win.Input.Number
        Me.Number124 = New GrapeCity.Win.Input.Number
        Me.Number117 = New GrapeCity.Win.Input.Number
        Me.Number132 = New GrapeCity.Win.Input.Number
        Me.Number112 = New GrapeCity.Win.Input.Number
        Me.Number131 = New GrapeCity.Win.Input.Number
        Me.Number122 = New GrapeCity.Win.Input.Number
        Me.Number111 = New GrapeCity.Win.Input.Number
        Me.Number114 = New GrapeCity.Win.Input.Number
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Number121 = New GrapeCity.Win.Input.Number
        Me.Number133 = New GrapeCity.Win.Input.Number
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Number137 = New GrapeCity.Win.Input.Number
        Me.Number136 = New GrapeCity.Win.Input.Number
        Me.Number135 = New GrapeCity.Win.Input.Number
        Me.Number134 = New GrapeCity.Win.Input.Number
        Me.Label29 = New System.Windows.Forms.Label
        Me.Number123 = New GrapeCity.Win.Input.Number
        Me.Number113 = New GrapeCity.Win.Input.Number
        Me.Label30 = New System.Windows.Forms.Label
        Me.Number127 = New GrapeCity.Win.Input.Number
        Me.Label31 = New System.Windows.Forms.Label
        Me.Number138 = New GrapeCity.Win.Input.Number
        Me.Number128 = New GrapeCity.Win.Input.Number
        Me.Number118 = New GrapeCity.Win.Input.Number
        Me.Number126 = New GrapeCity.Win.Input.Number
        Me.Label_K01 = New System.Windows.Forms.Label
        Me.Combo_K001 = New GrapeCity.Win.Input.Combo
        Me.Panel_K1 = New System.Windows.Forms.Panel
        Me.Edit_K002 = New GrapeCity.Win.Input.Edit
        Me.Edit_K001 = New GrapeCity.Win.Input.Edit
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
        Me.zero_code = New System.Windows.Forms.Label
        Me.CLK001_BRH = New System.Windows.Forms.Label
        Me.NumberN008 = New GrapeCity.Win.Input.Number
        Me.CHG = New System.Windows.Forms.Label
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Date013 = New GrapeCity.Win.Input.Date
        Me.Edit903 = New GrapeCity.Win.Input.Edit
        Me.Date011 = New GrapeCity.Win.Input.Date
        Me.Label45 = New System.Windows.Forms.Label
        Me.Date007 = New GrapeCity.Win.Input.Date
        Me.Label44 = New System.Windows.Forms.Label
        Me.Date006 = New GrapeCity.Win.Input.Date
        Me.Label14 = New System.Windows.Forms.Label
        Me.Date012 = New GrapeCity.Win.Input.Date
        Me.Date010 = New GrapeCity.Win.Input.Date
        Me.Date008 = New GrapeCity.Win.Input.Date
        Me.Date004 = New GrapeCity.Win.Input.Date
        Me.Date003 = New GrapeCity.Win.Input.Date
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Edit010 = New GrapeCity.Win.Input.Edit
        Me.Edit009 = New GrapeCity.Win.Input.Edit
        Me.Mask1 = New GrapeCity.Win.Input.Mask
        Me.Label013 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Edit000 = New GrapeCity.Win.Input.Edit
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label014 = New System.Windows.Forms.Label
        Me.Combo004 = New GrapeCity.Win.Input.Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label012 = New System.Windows.Forms.Label
        Me.Edit006 = New GrapeCity.Win.Input.Edit
        Me.Edit008 = New GrapeCity.Win.Input.Edit
        Me.Edit007 = New GrapeCity.Win.Input.Edit
        Me.Edit005 = New GrapeCity.Win.Input.Edit
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Edit004 = New GrapeCity.Win.Input.Edit
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Edit002 = New GrapeCity.Win.Input.Edit
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Edit011 = New GrapeCity.Win.Input.Edit
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Edit012 = New GrapeCity.Win.Input.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.calc_cls = New System.Windows.Forms.Label
        Me.tax_rate = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.Ck_atri_flg = New System.Windows.Forms.CheckBox
        Me.CK_own_flg = New System.Windows.Forms.CheckBox
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label002 = New GrapeCity.Win.Input.Edit
        Me.Label001 = New GrapeCity.Win.Input.Edit
        Me.Label46 = New System.Windows.Forms.Label
        Me.Combo005 = New GrapeCity.Win.Input.Combo
        Me.Label15 = New System.Windows.Forms.Label
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.NumberN009 = New GrapeCity.Win.Input.Number
        Me.kengen = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Edit013 = New GrapeCity.Win.Input.Edit
        Me.CL004 = New System.Windows.Forms.Label
        Me.GRP = New System.Windows.Forms.Label
        Me.Number001_nTax = New GrapeCity.Win.Input.Number
        Me.EDIT904 = New GrapeCity.Win.Input.Edit
        Me.Label34 = New System.Windows.Forms.Label
        Me.CL005 = New System.Windows.Forms.Label
        Me.CL002_2 = New System.Windows.Forms.Label
        Me.CL003 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.CL006 = New System.Windows.Forms.Label
        Me.Combo006 = New GrapeCity.Win.Input.Combo
        Me.CL007 = New System.Windows.Forms.Label
        Me.Combo007 = New GrapeCity.Win.Input.Combo
        Me.Panel_éÛït.SuspendLayout()
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
        CType(Me.Combo_K003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rebate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_K002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit903, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.EDIT904, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_éÛït
        '
        Me.Panel_éÛït.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U002)
        Me.Panel_éÛït.Controls.Add(Me.CLU001)
        Me.Panel_éÛït.Controls.Add(Me.CLU002)
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
        Me.Panel_éÛït.Location = New System.Drawing.Point(10, 264)
        Me.Panel_éÛït.Name = "Panel_éÛït"
        Me.Panel_éÛït.Size = New System.Drawing.Size(986, 372)
        Me.Panel_éÛït.TabIndex = 39
        '
        'CheckBox_U002
        '
        Me.CheckBox_U002.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U002.Location = New System.Drawing.Point(948, 28)
        Me.CheckBox_U002.Name = "CheckBox_U002"
        Me.CheckBox_U002.Size = New System.Drawing.Size(28, 16)
        Me.CheckBox_U002.TabIndex = 8
        '
        'CLU001
        '
        Me.CLU001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU001.Location = New System.Drawing.Point(304, 8)
        Me.CLU001.Name = "CLU001"
        Me.CLU001.Size = New System.Drawing.Size(48, 16)
        Me.CLU001.TabIndex = 1813
        Me.CLU001.Text = "CLU001"
        Me.CLU001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU001.Visible = False
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
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(756, 28)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(100, 20)
        Me.Label32.TabIndex = 1514
        Me.Label32.Text = "“∞∂∞ï€èÿäJénì˙"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U002
        '
        Me.Date_U002.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U002.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U002.Enabled = False
        Me.Date_U002.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U002.Location = New System.Drawing.Point(856, 28)
        Me.Date_U002.Name = "Date_U002"
        Me.Date_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U002.Size = New System.Drawing.Size(88, 20)
        Me.Date_U002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U002.TabIndex = 7
        Me.Date_U002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U002.Value = Nothing
        '
        'CheckBox_U001
        '
        Me.CheckBox_U001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U001.Location = New System.Drawing.Point(676, 8)
        Me.CheckBox_U001.Name = "CheckBox_U001"
        Me.CheckBox_U001.Size = New System.Drawing.Size(76, 16)
        Me.CheckBox_U001.TabIndex = 5
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
        Me.Combo_U001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_U001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_U001.Enabled = False
        Me.Combo_U001.Location = New System.Drawing.Point(84, 4)
        Me.Combo_U001.MaxDropDownItems = 20
        Me.Combo_U001.Name = "Combo_U001"
        Me.Combo_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_U001.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U001.TabIndex = 0
        Me.Combo_U001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit_U004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U004.LengthAsByte = True
        Me.Edit_U004.Location = New System.Drawing.Point(460, 220)
        Me.Edit_U004.Multiline = True
        Me.Edit_U004.Name = "Edit_U004"
        Me.Edit_U004.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U004.Size = New System.Drawing.Size(520, 64)
        Me.Edit_U004.TabIndex = 12
        '
        'Combo_U002
        '
        Me.Combo_U002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_U002.Enabled = False
        Me.Combo_U002.Location = New System.Drawing.Point(84, 52)
        Me.Combo_U002.MaxDropDownItems = 35
        Me.Combo_U002.Name = "Combo_U002"
        Me.Combo_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_U002.Size = New System.Drawing.Size(296, 20)
        Me.Combo_U002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U002.TabIndex = 4
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
        Me.Panel_U2.TabIndex = 11
        Me.Panel_U2.TabStop = True
        '
        'Edit_U002
        '
        Me.Edit_U002.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U002.Enabled = False
        Me.Edit_U002.HighlightText = True
        Me.Edit_U002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U002.LengthAsByte = True
        Me.Edit_U002.Location = New System.Drawing.Point(84, 28)
        Me.Edit_U002.MaxLength = 50
        Me.Edit_U002.Name = "Edit_U002"
        Me.Edit_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U002.Size = New System.Drawing.Size(292, 20)
        Me.Edit_U002.TabIndex = 2
        Me.Edit_U002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit_U005
        '
        Me.Edit_U005.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U005.LengthAsByte = True
        Me.Edit_U005.Location = New System.Drawing.Point(460, 284)
        Me.Edit_U005.Multiline = True
        Me.Edit_U005.Name = "Edit_U005"
        Me.Edit_U005.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U005.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U005.Size = New System.Drawing.Size(492, 76)
        Me.Edit_U005.TabIndex = 13
        '
        'Edit_U003
        '
        Me.Edit_U003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U003.Enabled = False
        Me.Edit_U003.Format = "9#aA"
        Me.Edit_U003.HighlightText = True
        Me.Edit_U003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U003.LengthAsByte = True
        Me.Edit_U003.Location = New System.Drawing.Point(460, 28)
        Me.Edit_U003.MaxLength = 25
        Me.Edit_U003.Name = "Edit_U003"
        Me.Edit_U003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U003.Size = New System.Drawing.Size(208, 20)
        Me.Edit_U003.TabIndex = 3
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
        Me.Label07_1.Text = "èCóùâÔé–"
        Me.Label07_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit_U001
        '
        Me.Edit_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U001.Enabled = False
        Me.Edit_U001.HighlightText = True
        Me.Edit_U001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U001.LengthAsByte = True
        Me.Edit_U001.Location = New System.Drawing.Point(460, 4)
        Me.Edit_U001.MaxLength = 50
        Me.Edit_U001.Name = "Edit_U001"
        Me.Edit_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U001.Size = New System.Drawing.Size(208, 20)
        Me.Edit_U001.TabIndex = 1
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
        Me.Panel_U1.TabIndex = 10
        Me.Panel_U1.TabStop = True
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
        Me.Label19_1.Location = New System.Drawing.Point(756, 4)
        Me.Label19_1.Name = "Label19_1"
        Me.Label19_1.Size = New System.Drawing.Size(100, 20)
        Me.Label19_1.TabIndex = 1272
        Me.Label19_1.Text = "çwì¸ì˙"
        Me.Label19_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U001
        '
        Me.Date_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U001.Enabled = False
        Me.Date_U001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U001.Location = New System.Drawing.Point(856, 4)
        Me.Date_U001.Name = "Date_U001"
        Me.Date_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U001.Size = New System.Drawing.Size(88, 20)
        Me.Date_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U001.TabIndex = 6
        Me.Date_U001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U001.Value = Nothing
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Navy
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(756, 52)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(100, 20)
        Me.Label33.TabIndex = 1832
        Me.Label33.Text = "éñåÃì˙"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U003
        '
        Me.Date_U003.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U003.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U003.Enabled = False
        Me.Date_U003.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U003.Location = New System.Drawing.Point(856, 52)
        Me.Date_U003.Name = "Date_U003"
        Me.Date_U003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U003.Size = New System.Drawing.Size(88, 20)
        Me.Date_U003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U003.TabIndex = 9
        Me.Date_U003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U003.Value = Nothing
        '
        'Panel_å©êœ
        '
        Me.Panel_å©êœ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_å©êœ.Controls.Add(Me.CLM003)
        Me.Panel_å©êœ.Controls.Add(Me.CLM001)
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
        Me.Panel_å©êœ.Location = New System.Drawing.Point(10, 264)
        Me.Panel_å©êœ.Name = "Panel_å©êœ"
        Me.Panel_å©êœ.Size = New System.Drawing.Size(986, 372)
        Me.Panel_å©êœ.TabIndex = 39
        '
        'CLM003
        '
        Me.CLM003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLM003.Location = New System.Drawing.Point(444, 8)
        Me.CLM003.Name = "CLM003"
        Me.CLM003.Size = New System.Drawing.Size(48, 16)
        Me.CLM003.TabIndex = 1874
        Me.CLM003.Text = "CLM003"
        Me.CLM003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLM003.Visible = False
        '
        'CLM001
        '
        Me.CLM001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLM001.Location = New System.Drawing.Point(216, 4)
        Me.CLM001.Name = "CLM001"
        Me.CLM001.Size = New System.Drawing.Size(48, 16)
        Me.CLM001.TabIndex = 1873
        Me.CLM001.Text = "CLM001"
        Me.CLM001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLM001.Visible = False
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
        Me.Number039.TabIndex = 1818
        Me.Number039.TabStop = False
        Me.Number039.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number039.Value = New Decimal(New Integer() {39, 0, 0, 0})
        Me.Number039.Visible = False
        '
        'Number029
        '
        Me.Number029.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number029.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number029.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number029.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number029.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number029.Enabled = False
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
        Me.Number029.TabIndex = 1817
        Me.Number029.TabStop = False
        Me.Number029.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number029.Value = New Decimal(New Integer() {29, 0, 0, 0})
        Me.Number029.Visible = False
        '
        'Number019
        '
        Me.Number019.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number019.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number019.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number019.Enabled = False
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
        Me.Number019.TabIndex = 1816
        Me.Number019.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number019.Value = New Decimal(New Integer() {19, 0, 0, 0})
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
        Me.Number016.TabIndex = 1736
        Me.Number016.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number015.TabIndex = 1735
        Me.Number015.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number015.Value = Nothing
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
        Me.Number025.TabIndex = 1742
        Me.Number025.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number025.Value = Nothing
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
        Me.Number024.TabIndex = 1741
        Me.Number024.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number024.Value = Nothing
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
        Me.Number017.TabIndex = 1737
        Me.Number017.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number017.Value = Nothing
        '
        'Number040
        '
        Me.Number040.BackColor = System.Drawing.SystemColors.Control
        Me.Number040.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number040.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number040.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number040.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number040.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number040.Enabled = False
        Me.Number040.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number040.HighlightText = True
        Me.Number040.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number040.Location = New System.Drawing.Point(364, 276)
        Me.Number040.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number040.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number040.Name = "Number040"
        Me.Number040.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number040.Size = New System.Drawing.Size(80, 20)
        Me.Number040.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number040.TabIndex = 1762
        Me.Number040.TabStop = False
        Me.Number040.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number032.TabIndex = 1746
        Me.Number032.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number032.Value = Nothing
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
        Me.Number012.TabIndex = 1732
        Me.Number012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number012.Value = Nothing
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
        Me.Number031.TabIndex = 1745
        Me.Number031.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number031.Value = Nothing
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
        Me.Number022.TabIndex = 1739
        Me.Number022.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number022.Value = Nothing
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
        Me.Number011.TabIndex = 1731
        Me.Number011.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number011.Value = New Decimal(New Integer() {999999, 0, 0, 0})
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
        Me.Number014.TabIndex = 1734
        Me.Number014.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number021.TabIndex = 1738
        Me.Number021.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number021.Value = Nothing
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
        Me.Number033.TabIndex = 1747
        Me.Number033.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number037.TabIndex = 1751
        Me.Number037.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number037.Value = Nothing
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
        Me.Number036.TabIndex = 1750
        Me.Number036.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number036.Value = Nothing
        '
        'Number035
        '
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
        Me.Number035.TabIndex = 1749
        Me.Number035.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number035.Value = Nothing
        '
        'Number034
        '
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
        Me.Number034.TabIndex = 1748
        Me.Number034.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number023.TabIndex = 1740
        Me.Number023.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number023.Value = Nothing
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
        Me.Number013.TabIndex = 1733
        Me.Number013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number027.TabIndex = 1744
        Me.Number027.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number038.TabIndex = 1766
        Me.Number038.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number038.Value = Nothing
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
        Me.Number028.TabIndex = 1765
        Me.Number028.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number028.Value = Nothing
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
        Me.Number018.TabIndex = 1764
        Me.Number018.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number018.Value = Nothing
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
        Me.Number026.TabIndex = 1743
        Me.Number026.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Button_M001.TabIndex = 8
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
        Me.Panel_M1.TabIndex = 3
        Me.Panel_M1.TabStop = True
        '
        'Edit_M004
        '
        Me.Edit_M004.AcceptsReturn = True
        Me.Edit_M004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M004.LengthAsByte = True
        Me.Edit_M004.Location = New System.Drawing.Point(88, 268)
        Me.Edit_M004.Multiline = True
        Me.Edit_M004.Name = "Edit_M004"
        Me.Edit_M004.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M004.Size = New System.Drawing.Size(280, 92)
        Me.Edit_M004.TabIndex = 6
        '
        'Edit_M003
        '
        Me.Edit_M003.AcceptsReturn = True
        Me.Edit_M003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M003.LengthAsByte = True
        Me.Edit_M003.Location = New System.Drawing.Point(88, 192)
        Me.Edit_M003.Multiline = True
        Me.Edit_M003.Name = "Edit_M003"
        Me.Edit_M003.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M003.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M003.Size = New System.Drawing.Size(460, 76)
        Me.Edit_M003.TabIndex = 5
        '
        'Edit_M002
        '
        Me.Edit_M002.AcceptsReturn = True
        Me.Edit_M002.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M002.LengthAsByte = True
        Me.Edit_M002.Location = New System.Drawing.Point(88, 132)
        Me.Edit_M002.Multiline = True
        Me.Edit_M002.Name = "Edit_M002"
        Me.Edit_M002.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M002.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M002.Size = New System.Drawing.Size(488, 60)
        Me.Edit_M002.TabIndex = 4
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
        Me.Edit_M001.Size = New System.Drawing.Size(200, 20)
        Me.Edit_M001.TabIndex = 2
        Me.Edit_M001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Combo_M001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_M001.Location = New System.Drawing.Point(88, 4)
        Me.Combo_M001.MaxDropDownItems = 40
        Me.Combo_M001.Name = "Combo_M001"
        Me.Combo_M001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_M001.Size = New System.Drawing.Size(200, 20)
        Me.Combo_M001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_M001.TabIndex = 0
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
        Me.DataGrid_M1.TabIndex = 7
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
        Me.Combo_M003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_M003.Location = New System.Drawing.Point(380, 4)
        Me.Combo_M003.MaxDropDownItems = 40
        Me.Combo_M003.Name = "Combo_M003"
        Me.Combo_M003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_M003.Size = New System.Drawing.Size(132, 20)
        Me.Combo_M003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_M003.TabIndex = 1
        Me.Combo_M003.Value = "Combo_M003"
        '
        'Button80
        '
        Me.Button80.BackColor = System.Drawing.SystemColors.Control
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Enabled = False
        Me.Button80.Location = New System.Drawing.Point(816, 660)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(72, 24)
        Me.Button80.TabIndex = 1020
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
        Me.Button98.Location = New System.Drawing.Point(916, 660)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1030
        Me.Button98.Text = "ñﬂÇÈ"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 660)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1000
        Me.Button1.Text = "çXêV"
        '
        'Panel_äÆóπ
        '
        Me.Panel_äÆóπ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K003_moto)
        Me.Panel_äÆóπ.Controls.Add(Me.apse)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK003)
        Me.Panel_äÆóπ.Controls.Add(Me.Label50)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K003)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK002)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK001)
        Me.Panel_äÆóπ.Controls.Add(Me.rebate)
        Me.Panel_äÆóπ.Controls.Add(Me.Label_K02)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K002)
        Me.Panel_äÆóπ.Controls.Add(Me.Number1)
        Me.Panel_äÆóπ.Controls.Add(Me.Label19)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo1)
        Me.Panel_äÆóπ.Controls.Add(Me.zero_name)
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
        Me.Panel_äÆóπ.Controls.Add(Me.Panel_K1)
        Me.Panel_äÆóπ.Controls.Add(Me.Edit_K002)
        Me.Panel_äÆóπ.Controls.Add(Me.Edit_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.Label16_1)
        Me.Panel_äÆóπ.Controls.Add(Me.Label15_1)
        Me.Panel_äÆóπ.Controls.Add(Me.Label34_1)
        Me.Panel_äÆóπ.Controls.Add(Me.DataGrid_K1)
        Me.Panel_äÆóπ.Controls.Add(Me.Button_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.zero_code)
        Me.Panel_äÆóπ.Controls.Add(Me.CLK001_BRH)
        Me.Panel_äÆóπ.Controls.Add(Me.NumberN008)
        Me.Panel_äÆóπ.Location = New System.Drawing.Point(10, 264)
        Me.Panel_äÆóπ.Name = "Panel_äÆóπ"
        Me.Panel_äÆóπ.Size = New System.Drawing.Size(986, 372)
        Me.Panel_äÆóπ.TabIndex = 39
        Me.Panel_äÆóπ.TabStop = True
        '
        'Combo_K003_moto
        '
        Me.Combo_K003_moto.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Combo_K003_moto.Location = New System.Drawing.Point(932, 336)
        Me.Combo_K003_moto.Name = "Combo_K003_moto"
        Me.Combo_K003_moto.Size = New System.Drawing.Size(48, 16)
        Me.Combo_K003_moto.TabIndex = 1868
        Me.Combo_K003_moto.Text = "Combo_K003_moto"
        Me.Combo_K003_moto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Combo_K003_moto.Visible = False
        '
        'apse
        '
        Me.apse.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.apse.Location = New System.Drawing.Point(64, 348)
        Me.apse.Name = "apse"
        Me.apse.Size = New System.Drawing.Size(40, 16)
        Me.apse.TabIndex = 1867
        Me.apse.Text = "apse"
        Me.apse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.apse.Visible = False
        '
        'CLK003
        '
        Me.CLK003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK003.Location = New System.Drawing.Point(924, 320)
        Me.CLK003.Name = "CLK003"
        Me.CLK003.Size = New System.Drawing.Size(48, 16)
        Me.CLK003.TabIndex = 1866
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
        Me.Label50.TabIndex = 1865
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
        Me.Combo_K003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_K003.Size = New System.Drawing.Size(108, 20)
        Me.Combo_K003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K003.TabIndex = 1864
        Me.Combo_K003.Value = "Combo_K003"
        '
        'CLK002
        '
        Me.CLK002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK002.Location = New System.Drawing.Point(504, 8)
        Me.CLK002.Name = "CLK002"
        Me.CLK002.Size = New System.Drawing.Size(48, 16)
        Me.CLK002.TabIndex = 1839
        Me.CLK002.Text = "CLK002"
        Me.CLK002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLK002.Visible = False
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
        'rebate
        '
        Me.rebate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.rebate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rebate.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.rebate.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.rebate.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.rebate.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.rebate.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rebate.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.rebate.Enabled = False
        Me.rebate.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.rebate.HighlightText = True
        Me.rebate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.rebate.Location = New System.Drawing.Point(8, 348)
        Me.rebate.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.rebate.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.rebate.Name = "rebate"
        Me.rebate.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.rebate.Size = New System.Drawing.Size(48, 16)
        Me.rebate.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.rebate.TabIndex = 1851
        Me.rebate.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.rebate.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.rebate.Visible = False
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
        Me.Combo_K002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_K002.Size = New System.Drawing.Size(168, 20)
        Me.Combo_K002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K002.TabIndex = 1
        Me.Combo_K002.Value = "Combo_K002"
        '
        'Number1
        '
        Me.Number1.DisabledForeColor = System.Drawing.Color.Black
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number1.Enabled = False
        Me.Number1.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number1.HighlightText = True
        Me.Number1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number1.Location = New System.Drawing.Point(920, 340)
        Me.Number1.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(12, 20)
        Me.Number1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.TabIndex = 1835
        Me.Number1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Label19.Size = New System.Drawing.Size(56, 20)
        Me.Label19.TabIndex = 1834
        Me.Label19.Text = "ì¸ã‡éÌï "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label19.Visible = False
        '
        'Combo1
        '
        Me.Combo1.AutoSelect = True
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(864, 340)
        Me.Combo1.MaxDropDownItems = 20
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo1.Size = New System.Drawing.Size(56, 20)
        Me.Combo1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo1.TabIndex = 110
        Me.Combo1.Value = "Combo_K002"
        Me.Combo1.Visible = False
        '
        'zero_name
        '
        Me.zero_name.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.zero_name.Location = New System.Drawing.Point(60, 280)
        Me.zero_name.Name = "zero_name"
        Me.zero_name.Size = New System.Drawing.Size(196, 16)
        Me.zero_name.TabIndex = 1832
        Me.zero_name.Text = "zero_name"
        Me.zero_name.Visible = False
        '
        'Number116
        '
        Me.Number116.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number116.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number116.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number116.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number116.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number116.Enabled = False
        Me.Number116.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number116.HighlightText = True
        Me.Number116.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number116.Location = New System.Drawing.Point(704, 300)
        Me.Number116.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number116.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number116.Name = "Number116"
        Me.Number116.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number116.Size = New System.Drawing.Size(52, 20)
        Me.Number116.TabIndex = 12
        Me.Number116.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number115.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number115.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number115.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number115.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number115.Enabled = False
        Me.Number115.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number115.HighlightText = True
        Me.Number115.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number115.Location = New System.Drawing.Point(652, 300)
        Me.Number115.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number115.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number115.Name = "Number115"
        Me.Number115.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number115.Size = New System.Drawing.Size(52, 20)
        Me.Number115.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number115.TabIndex = 11
        Me.Number115.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number115.Value = New Decimal(New Integer() {115, 0, 0, 0})
        '
        'Number125
        '
        Me.Number125.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number125.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number125.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number125.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number125.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number125.Enabled = False
        Me.Number125.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number125.HighlightText = True
        Me.Number125.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number125.Location = New System.Drawing.Point(652, 320)
        Me.Number125.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number125.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number125.Name = "Number125"
        Me.Number125.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number125.Size = New System.Drawing.Size(52, 20)
        Me.Number125.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number125.TabIndex = 19
        Me.Number125.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number125.Value = New Decimal(New Integer() {125, 0, 0, 0})
        '
        'Number124
        '
        Me.Number124.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number124.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number124.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number124.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number124.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number124.Enabled = False
        Me.Number124.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number124.HighlightText = True
        Me.Number124.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number124.Location = New System.Drawing.Point(600, 320)
        Me.Number124.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number124.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number124.Name = "Number124"
        Me.Number124.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number124.Size = New System.Drawing.Size(52, 20)
        Me.Number124.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number124.TabIndex = 18
        Me.Number124.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number124.Value = New Decimal(New Integer() {124, 0, 0, 0})
        '
        'Number117
        '
        Me.Number117.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number117.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number117.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number117.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number117.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number117.Enabled = False
        Me.Number117.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number117.HighlightText = True
        Me.Number117.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number117.Location = New System.Drawing.Point(756, 300)
        Me.Number117.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number117.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number117.Name = "Number117"
        Me.Number117.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number117.Size = New System.Drawing.Size(52, 20)
        Me.Number117.TabIndex = 13
        Me.Number117.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number117.Value = New Decimal(New Integer() {117, 0, 0, 0})
        '
        'Number132
        '
        Me.Number132.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number132.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number132.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number132.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number132.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number132.Enabled = False
        Me.Number132.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number132.HighlightText = True
        Me.Number132.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number132.Location = New System.Drawing.Point(496, 340)
        Me.Number132.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number132.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number132.Name = "Number132"
        Me.Number132.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number132.Size = New System.Drawing.Size(52, 20)
        Me.Number132.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number132.TabIndex = 24
        Me.Number132.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number132.Value = New Decimal(New Integer() {132, 0, 0, 0})
        '
        'Number112
        '
        Me.Number112.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number112.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number112.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number112.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number112.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number112.Enabled = False
        Me.Number112.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number112.HighlightText = True
        Me.Number112.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number112.Location = New System.Drawing.Point(496, 300)
        Me.Number112.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number112.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number112.Name = "Number112"
        Me.Number112.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number112.Size = New System.Drawing.Size(52, 20)
        Me.Number112.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number112.TabIndex = 8
        Me.Number112.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number112.Value = New Decimal(New Integer() {112, 0, 0, 0})
        '
        'Number131
        '
        Me.Number131.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number131.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number131.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number131.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number131.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number131.Enabled = False
        Me.Number131.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number131.HighlightText = True
        Me.Number131.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number131.Location = New System.Drawing.Point(444, 340)
        Me.Number131.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number131.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number131.Name = "Number131"
        Me.Number131.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number131.Size = New System.Drawing.Size(52, 20)
        Me.Number131.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number131.TabIndex = 23
        Me.Number131.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number131.Value = New Decimal(New Integer() {131, 0, 0, 0})
        '
        'Number122
        '
        Me.Number122.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number122.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number122.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number122.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number122.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number122.Enabled = False
        Me.Number122.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number122.HighlightText = True
        Me.Number122.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number122.Location = New System.Drawing.Point(496, 320)
        Me.Number122.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number122.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number122.Name = "Number122"
        Me.Number122.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number122.Size = New System.Drawing.Size(52, 20)
        Me.Number122.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number122.TabIndex = 16
        Me.Number122.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number122.Value = New Decimal(New Integer() {122, 0, 0, 0})
        '
        'Number111
        '
        Me.Number111.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number111.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number111.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number111.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number111.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number111.Enabled = False
        Me.Number111.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number111.HighlightText = True
        Me.Number111.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number111.Location = New System.Drawing.Point(444, 300)
        Me.Number111.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number111.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number111.Name = "Number111"
        Me.Number111.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number111.Size = New System.Drawing.Size(52, 20)
        Me.Number111.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number111.TabIndex = 7
        Me.Number111.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number111.Value = New Decimal(New Integer() {111, 0, 0, 0})
        '
        'Number114
        '
        Me.Number114.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number114.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number114.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number114.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number114.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number114.Enabled = False
        Me.Number114.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number114.HighlightText = True
        Me.Number114.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number114.Location = New System.Drawing.Point(600, 300)
        Me.Number114.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number114.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number114.Name = "Number114"
        Me.Number114.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number114.Size = New System.Drawing.Size(52, 20)
        Me.Number114.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number114.TabIndex = 10
        Me.Number114.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number121.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number121.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number121.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number121.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number121.Enabled = False
        Me.Number121.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number121.HighlightText = True
        Me.Number121.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number121.Location = New System.Drawing.Point(444, 320)
        Me.Number121.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number121.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number121.Name = "Number121"
        Me.Number121.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number121.Size = New System.Drawing.Size(52, 20)
        Me.Number121.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number121.TabIndex = 15
        Me.Number121.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number121.Value = New Decimal(New Integer() {121, 0, 0, 0})
        '
        'Number133
        '
        Me.Number133.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number133.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number133.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number133.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number133.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number133.Enabled = False
        Me.Number133.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number133.HighlightText = True
        Me.Number133.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number133.Location = New System.Drawing.Point(548, 340)
        Me.Number133.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number133.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number133.Name = "Number133"
        Me.Number133.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number133.Size = New System.Drawing.Size(52, 20)
        Me.Number133.TabIndex = 25
        Me.Number133.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number137.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number137.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number137.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number137.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number137.Enabled = False
        Me.Number137.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number137.HighlightText = True
        Me.Number137.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number137.Location = New System.Drawing.Point(756, 340)
        Me.Number137.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number137.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number137.Name = "Number137"
        Me.Number137.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number137.Size = New System.Drawing.Size(52, 20)
        Me.Number137.TabIndex = 29
        Me.Number137.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number137.Value = New Decimal(New Integer() {137, 0, 0, 0})
        '
        'Number136
        '
        Me.Number136.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number136.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number136.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number136.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number136.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number136.Enabled = False
        Me.Number136.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number136.HighlightText = True
        Me.Number136.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number136.Location = New System.Drawing.Point(704, 340)
        Me.Number136.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number136.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number136.Name = "Number136"
        Me.Number136.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number136.Size = New System.Drawing.Size(52, 20)
        Me.Number136.TabIndex = 28
        Me.Number136.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number136.Value = New Decimal(New Integer() {136, 0, 0, 0})
        '
        'Number135
        '
        Me.Number135.DisabledForeColor = System.Drawing.Color.Black
        Me.Number135.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number135.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number135.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number135.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number135.Enabled = False
        Me.Number135.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number135.HighlightText = True
        Me.Number135.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number135.Location = New System.Drawing.Point(652, 340)
        Me.Number135.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number135.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number135.Name = "Number135"
        Me.Number135.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number135.Size = New System.Drawing.Size(52, 20)
        Me.Number135.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number135.TabIndex = 27
        Me.Number135.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number135.Value = New Decimal(New Integer() {135, 0, 0, 0})
        '
        'Number134
        '
        Me.Number134.DisabledForeColor = System.Drawing.Color.Black
        Me.Number134.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number134.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number134.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number134.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number134.Enabled = False
        Me.Number134.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number134.HighlightText = True
        Me.Number134.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number134.Location = New System.Drawing.Point(600, 340)
        Me.Number134.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number134.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number134.Name = "Number134"
        Me.Number134.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number134.Size = New System.Drawing.Size(52, 20)
        Me.Number134.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number134.TabIndex = 26
        Me.Number134.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number123.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number123.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number123.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number123.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number123.Enabled = False
        Me.Number123.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number123.HighlightText = True
        Me.Number123.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number123.Location = New System.Drawing.Point(548, 320)
        Me.Number123.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number123.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number123.Name = "Number123"
        Me.Number123.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number123.Size = New System.Drawing.Size(52, 20)
        Me.Number123.TabIndex = 17
        Me.Number123.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number123.Value = New Decimal(New Integer() {123, 0, 0, 0})
        '
        'Number113
        '
        Me.Number113.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number113.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number113.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number113.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number113.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number113.Enabled = False
        Me.Number113.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number113.HighlightText = True
        Me.Number113.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number113.Location = New System.Drawing.Point(548, 300)
        Me.Number113.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number113.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number113.Name = "Number113"
        Me.Number113.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number113.Size = New System.Drawing.Size(52, 20)
        Me.Number113.TabIndex = 9
        Me.Number113.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number127.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number127.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number127.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number127.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number127.Enabled = False
        Me.Number127.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number127.HighlightText = True
        Me.Number127.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number127.Location = New System.Drawing.Point(756, 320)
        Me.Number127.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number127.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number127.Name = "Number127"
        Me.Number127.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number127.Size = New System.Drawing.Size(52, 20)
        Me.Number127.TabIndex = 21
        Me.Number127.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number138.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number138.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number138.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number138.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number138.Enabled = False
        Me.Number138.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number138.HighlightText = True
        Me.Number138.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number138.Location = New System.Drawing.Point(808, 340)
        Me.Number138.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number138.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number138.Name = "Number138"
        Me.Number138.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number138.Size = New System.Drawing.Size(52, 20)
        Me.Number138.TabIndex = 30
        Me.Number138.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number138.Value = New Decimal(New Integer() {138, 0, 0, 0})
        '
        'Number128
        '
        Me.Number128.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number128.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number128.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number128.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number128.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number128.Enabled = False
        Me.Number128.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number128.HighlightText = True
        Me.Number128.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number128.Location = New System.Drawing.Point(808, 320)
        Me.Number128.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number128.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number128.Name = "Number128"
        Me.Number128.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number128.Size = New System.Drawing.Size(52, 20)
        Me.Number128.TabIndex = 22
        Me.Number128.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number128.Value = New Decimal(New Integer() {128, 0, 0, 0})
        '
        'Number118
        '
        Me.Number118.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number118.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number118.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number118.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number118.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number118.Enabled = False
        Me.Number118.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number118.HighlightText = True
        Me.Number118.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number118.Location = New System.Drawing.Point(808, 300)
        Me.Number118.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number118.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number118.Name = "Number118"
        Me.Number118.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number118.Size = New System.Drawing.Size(52, 20)
        Me.Number118.TabIndex = 14
        Me.Number118.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number118.Value = New Decimal(New Integer() {118, 0, 0, 0})
        '
        'Number126
        '
        Me.Number126.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number126.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number126.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number126.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number126.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number126.Enabled = False
        Me.Number126.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number126.HighlightText = True
        Me.Number126.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number126.Location = New System.Drawing.Point(704, 320)
        Me.Number126.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number126.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number126.Name = "Number126"
        Me.Number126.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number126.Size = New System.Drawing.Size(52, 20)
        Me.Number126.TabIndex = 20
        Me.Number126.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Combo_K001.ListBoxStyle = GrapeCity.Win.Input.ListBoxStyle.TextWithDescription
        Me.Combo_K001.Location = New System.Drawing.Point(88, 4)
        Me.Combo_K001.MaxDropDownItems = 20
        Me.Combo_K001.Name = "Combo_K001"
        Me.Combo_K001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_K001.Size = New System.Drawing.Size(192, 20)
        Me.Combo_K001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K001.TabIndex = 0
        Me.Combo_K001.Value = "Combo_K001"
        '
        'Panel_K1
        '
        Me.Panel_K1.AutoScroll = True
        Me.Panel_K1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_K1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_K1.Location = New System.Drawing.Point(88, 28)
        Me.Panel_K1.Name = "Panel_K1"
        Me.Panel_K1.Size = New System.Drawing.Size(488, 104)
        Me.Panel_K1.TabIndex = 2
        Me.Panel_K1.TabStop = True
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
        Me.Edit_K002.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_K002.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_K002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_K002.Size = New System.Drawing.Size(460, 76)
        Me.Edit_K002.TabIndex = 4
        '
        'Edit_K001
        '
        Me.Edit_K001.AcceptsReturn = True
        Me.Edit_K001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit_K001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_K001.LengthAsByte = True
        Me.Edit_K001.Location = New System.Drawing.Point(88, 132)
        Me.Edit_K001.MaxLength = 200
        Me.Edit_K001.Multiline = True
        Me.Edit_K001.Name = "Edit_K001"
        Me.Edit_K001.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_K001.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_K001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_K001.Size = New System.Drawing.Size(488, 60)
        Me.Edit_K001.TabIndex = 3
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
        Me.Label15_1.Text = "èCóùì‡óe"
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
        Me.DataGrid_K1.TabIndex = 5
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
        Me.Button_K001.Location = New System.Drawing.Point(904, 8)
        Me.Button_K001.Name = "Button_K001"
        Me.Button_K001.Size = New System.Drawing.Size(72, 20)
        Me.Button_K001.TabIndex = 6
        Me.Button_K001.Text = "ïîïiì¸óÕ"
        '
        'zero_code
        '
        Me.zero_code.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.zero_code.Location = New System.Drawing.Point(8, 280)
        Me.zero_code.Name = "zero_code"
        Me.zero_code.Size = New System.Drawing.Size(48, 16)
        Me.zero_code.TabIndex = 1831
        Me.zero_code.Text = "zero_code"
        Me.zero_code.Visible = False
        '
        'CLK001_BRH
        '
        Me.CLK001_BRH.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLK001_BRH.Location = New System.Drawing.Point(592, 8)
        Me.CLK001_BRH.Name = "CLK001_BRH"
        Me.CLK001_BRH.Size = New System.Drawing.Size(80, 16)
        Me.CLK001_BRH.TabIndex = 1849
        Me.CLK001_BRH.Text = "CLK001_BRH"
        Me.CLK001_BRH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLK001_BRH.Visible = False
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
        Me.NumberN008.Location = New System.Drawing.Point(120, 348)
        Me.NumberN008.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN008.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN008.Name = "NumberN008"
        Me.NumberN008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN008.Size = New System.Drawing.Size(48, 16)
        Me.NumberN008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008.TabIndex = 1876
        Me.NumberN008.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN008.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN008.Value = Nothing
        Me.NumberN008.Visible = False
        '
        'CHG
        '
        Me.CHG.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CHG.Location = New System.Drawing.Point(196, 660)
        Me.CHG.Name = "CHG"
        Me.CHG.Size = New System.Drawing.Size(608, 24)
        Me.CHG.TabIndex = 1838
        Me.CHG.Text = "CHG"
        Me.CHG.Visible = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(64, 244)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(48, 20)
        Me.Button12.TabIndex = 37
        Me.Button12.TabStop = False
        Me.Button12.Text = "å©êœ"
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Location = New System.Drawing.Point(112, 244)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(48, 20)
        Me.Button13.TabIndex = 38
        Me.Button13.TabStop = False
        Me.Button13.Text = "äÆóπ"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(16, 244)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(48, 20)
        Me.Button11.TabIndex = 36
        Me.Button11.TabStop = False
        Me.Button11.Text = "éÛït"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 640)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(880, 16)
        Me.msg.TabIndex = 1345
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date013
        '
        Me.Date013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date013.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date013.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date013.Enabled = False
        Me.Date013.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date013.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date013.Location = New System.Drawing.Point(904, 204)
        Me.Date013.Name = "Date013"
        Me.Date013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date013.Size = New System.Drawing.Size(88, 20)
        Me.Date013.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date013.TabIndex = 35
        Me.Date013.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date013.Value = Nothing
        '
        'Edit903
        '
        Me.Edit903.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit903.Format = "9A"
        Me.Edit903.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit903.LengthAsByte = True
        Me.Edit903.Location = New System.Drawing.Point(904, 128)
        Me.Edit903.MaxLength = 9
        Me.Edit903.Name = "Edit903"
        Me.Edit903.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit903.Size = New System.Drawing.Size(88, 20)
        Me.Edit903.TabIndex = 31
        Me.Edit903.Text = "EDIT903"
        Me.Edit903.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit903.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Date011
        '
        Me.Date011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date011.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date011.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date011.Enabled = False
        Me.Date011.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date011.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date011.Location = New System.Drawing.Point(904, 164)
        Me.Date011.Name = "Date011"
        Me.Date011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date011.Size = New System.Drawing.Size(88, 20)
        Me.Date011.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date011.TabIndex = 33
        Me.Date011.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date011.Value = Nothing
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Navy
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(824, 184)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(80, 20)
        Me.Label45.TabIndex = 1365
        Me.Label45.Text = "èoâ◊ì˙"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date007
        '
        Me.Date007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date007.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date007.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date007.Enabled = False
        Me.Date007.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date007.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date007.Location = New System.Drawing.Point(904, 68)
        Me.Date007.Name = "Date007"
        Me.Date007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date007.Size = New System.Drawing.Size(88, 20)
        Me.Date007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date007.TabIndex = 28
        Me.Date007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date007.Value = Nothing
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Navy
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(824, 88)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(80, 20)
        Me.Label44.TabIndex = 1363
        Me.Label44.Text = "ïîïiéÛóÃì˙"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date006
        '
        Me.Date006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date006.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date006.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date006.Enabled = False
        Me.Date006.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date006.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date006.Location = New System.Drawing.Point(904, 48)
        Me.Date006.Name = "Date006"
        Me.Date006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date006.Size = New System.Drawing.Size(88, 20)
        Me.Date006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date006.TabIndex = 27
        Me.Date006.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date006.Value = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(824, 68)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 20)
        Me.Label14.TabIndex = 1361
        Me.Label14.Text = "ïîïiî≠íçì˙"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date012
        '
        Me.Date012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date012.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date012.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date012.Enabled = False
        Me.Date012.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date012.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date012.Location = New System.Drawing.Point(904, 184)
        Me.Date012.Name = "Date012"
        Me.Date012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date012.Size = New System.Drawing.Size(88, 20)
        Me.Date012.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date012.TabIndex = 34
        Me.Date012.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date012.Value = Nothing
        '
        'Date010
        '
        Me.Date010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date010.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date010.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date010.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date010.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date010.Location = New System.Drawing.Point(904, 108)
        Me.Date010.Name = "Date010"
        Me.Date010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date010.Size = New System.Drawing.Size(88, 20)
        Me.Date010.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date010.TabIndex = 30
        Me.Date010.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date010.Value = Nothing
        '
        'Date008
        '
        Me.Date008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date008.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date008.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date008.Enabled = False
        Me.Date008.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date008.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date008.Location = New System.Drawing.Point(904, 88)
        Me.Date008.Name = "Date008"
        Me.Date008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date008.Size = New System.Drawing.Size(88, 20)
        Me.Date008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date008.TabIndex = 29
        Me.Date008.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date008.Value = Nothing
        '
        'Date004
        '
        Me.Date004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date004.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date004.Enabled = False
        Me.Date004.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date004.Location = New System.Drawing.Point(904, 28)
        Me.Date004.Name = "Date004"
        Me.Date004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date004.Size = New System.Drawing.Size(88, 20)
        Me.Date004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date004.TabIndex = 26
        Me.Date004.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date004.Value = Nothing
        '
        'Date003
        '
        Me.Date003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date003.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date003.Enabled = False
        Me.Date003.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date003.Location = New System.Drawing.Point(904, 8)
        Me.Date003.Name = "Date003"
        Me.Date003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date003.Size = New System.Drawing.Size(88, 20)
        Me.Date003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date003.TabIndex = 25
        Me.Date003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date003.Value = Nothing
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Navy
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(824, 204)
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
        Me.Label41.Location = New System.Drawing.Point(824, 128)
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
        Me.Label40.Location = New System.Drawing.Point(824, 164)
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
        Me.Label36.Location = New System.Drawing.Point(824, 28)
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
        Me.Label37.Location = New System.Drawing.Point(824, 48)
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
        Me.Label39.Location = New System.Drawing.Point(824, 108)
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
        Me.Edit010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit010.Enabled = False
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(520, 192)
        Me.Edit010.MaxLength = 40
        Me.Edit010.Name = "Edit010"
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(300, 20)
        Me.Edit010.TabIndex = 20
        Me.Edit010.Text = "Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†"
        Me.Edit010.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit009
        '
        Me.Edit009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit009.Enabled = False
        Me.Edit009.HighlightText = True
        Me.Edit009.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit009.LengthAsByte = True
        Me.Edit009.Location = New System.Drawing.Point(520, 172)
        Me.Edit009.MaxLength = 40
        Me.Edit009.Name = "Edit009"
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(300, 20)
        Me.Edit009.TabIndex = 19
        Me.Edit009.Text = "Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†Ç†"
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Mask1
        '
        Me.Mask1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask1.Enabled = False
        Me.Mask1.Format = New GrapeCity.Win.Input.MaskFormat("Åß \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(520, 152)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(76, 20)
        Me.Mask1.TabIndex = 18
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
        Me.Label013.TabIndex = 1413
        Me.Label013.Text = "èZèä"
        Me.Label013.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Combo003.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo003.Enabled = False
        Me.Combo003.Location = New System.Drawing.Point(376, 56)
        Me.Combo003.MaxDropDownItems = 20
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(184, 20)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 5
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
        Me.Combo002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo002.Enabled = False
        Me.Combo002.Location = New System.Drawing.Point(96, 56)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(196, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 4
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
        Me.Edit000.TabIndex = 0
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
        Me.Label7.TabIndex = 1407
        Me.Label7.Text = "éÛïtéÌï "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Enabled = False
        Me.Combo001.Location = New System.Drawing.Point(96, 32)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 2
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
        Me.Combo004.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo004.Enabled = False
        Me.Combo004.Location = New System.Drawing.Point(96, 216)
        Me.Combo004.MaxDropDownItems = 20
        Me.Combo004.Name = "Combo004"
        Me.Combo004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo004.Size = New System.Drawing.Size(164, 20)
        Me.Combo004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo004.TabIndex = 21
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
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Enabled = False
        Me.Edit006.Format = "KAa"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(96, 172)
        Me.Edit006.MaxLength = 15
        Me.Edit006.Name = "Edit006"
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(196, 20)
        Me.Edit006.TabIndex = 15
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit008
        '
        Me.Edit008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit008.Enabled = False
        Me.Edit008.Format = "9#"
        Me.Edit008.HighlightText = True
        Me.Edit008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit008.LengthAsByte = True
        Me.Edit008.Location = New System.Drawing.Point(376, 172)
        Me.Edit008.MaxLength = 14
        Me.Edit008.Name = "Edit008"
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(112, 20)
        Me.Edit008.TabIndex = 17
        Me.Edit008.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit007
        '
        Me.Edit007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit007.Enabled = False
        Me.Edit007.Format = "9#"
        Me.Edit007.HighlightText = True
        Me.Edit007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit007.LengthAsByte = True
        Me.Edit007.Location = New System.Drawing.Point(376, 152)
        Me.Edit007.MaxLength = 14
        Me.Edit007.Name = "Edit007"
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(112, 20)
        Me.Edit007.TabIndex = 16
        Me.Edit007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit005
        '
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.Enabled = False
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(96, 152)
        Me.Edit005.MaxLength = 30
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(196, 20)
        Me.Edit005.TabIndex = 14
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
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.Enabled = False
        Me.Edit004.Format = "9#aA"
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(536, 104)
        Me.Edit004.MaxLength = 25
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(112, 20)
        Me.Edit004.TabIndex = 11
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
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.Enabled = False
        Me.Edit002.Format = "9"
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(96, 104)
        Me.Edit002.MaxLength = 4
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(48, 20)
        Me.Edit002.TabIndex = 10
        Me.Edit002.Text = "9999"
        Me.Edit002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit001
        '
        Me.Edit001.AllowSpace = False
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Enabled = False
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(96, 80)
        Me.Edit001.MaxLength = 4
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(48, 20)
        Me.Edit001.TabIndex = 8
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
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(112, 20)
        Me.Edit003.TabIndex = 9
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit011
        '
        Me.Edit011.AllowSpace = False
        Me.Edit011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit011.Enabled = False
        Me.Edit011.Format = "9A#"
        Me.Edit011.HighlightText = True
        Me.Edit011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit011.LengthAsByte = True
        Me.Edit011.Location = New System.Drawing.Point(376, 32)
        Me.Edit011.MaxLength = 10
        Me.Edit011.Name = "Edit011"
        Me.Edit011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit011.Size = New System.Drawing.Size(92, 20)
        Me.Edit011.TabIndex = 3
        Me.Edit011.Text = "9999"
        Me.Edit011.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit012.Enabled = False
        Me.Edit012.Format = "9A#"
        Me.Edit012.HighlightText = True
        Me.Edit012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit012.LengthAsByte = True
        Me.Edit012.Location = New System.Drawing.Point(568, 216)
        Me.Edit012.MaxLength = 15
        Me.Edit012.Name = "Edit012"
        Me.Edit012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit012.Size = New System.Drawing.Size(116, 20)
        Me.Edit012.TabIndex = 23
        Me.Edit012.Text = "9999"
        Me.Edit012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.calc_cls.Location = New System.Drawing.Point(952, 636)
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
        Me.tax_rate.Location = New System.Drawing.Point(908, 636)
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
        Me.Number002.TabIndex = 24
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(116, 660)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 1010
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
        Me.Number001.Location = New System.Drawing.Point(772, 12)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(52, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1808
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Visible = False
        '
        'Ck_atri_flg
        '
        Me.Ck_atri_flg.AutoCheck = False
        Me.Ck_atri_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Ck_atri_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Ck_atri_flg.Location = New System.Drawing.Point(908, 244)
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
        Me.CK_own_flg.Location = New System.Drawing.Point(816, 244)
        Me.CK_own_flg.Name = "CK_own_flg"
        Me.CK_own_flg.Size = New System.Drawing.Size(84, 16)
        Me.CK_own_flg.TabIndex = 1821
        Me.CK_own_flg.TabStop = False
        Me.CK_own_flg.Text = "CK_own_flg"
        Me.CK_own_flg.Visible = False
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Enabled = False
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(732, 104)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(88, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 12
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(652, 104)
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
        Me.Label002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label002.Size = New System.Drawing.Size(296, 20)
        Me.Label002.TabIndex = 1826
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
        Me.Label001.TabIndex = 1825
        Me.Label001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Combo005.TabIndex = 22
        Me.Combo005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Number003.TabIndex = 7
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.NumberN009.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN009.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN009.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN009.DropDownCalculator.Font = New System.Drawing.Font("ÇlÇr ÇoÉSÉVÉbÉN", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN009.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN009.Enabled = False
        Me.NumberN009.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.NumberN009.HighlightText = True
        Me.NumberN009.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN009.Location = New System.Drawing.Point(632, 96)
        Me.NumberN009.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NumberN009.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN009.Name = "NumberN009"
        Me.NumberN009.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN009.Size = New System.Drawing.Size(48, 16)
        Me.NumberN009.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN009.TabIndex = 1833
        Me.NumberN009.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN009.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NumberN009.Visible = False
        '
        'kengen
        '
        Me.kengen.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.kengen.Location = New System.Drawing.Point(212, 8)
        Me.kengen.Name = "kengen"
        Me.kengen.Size = New System.Drawing.Size(52, 16)
        Me.kengen.TabIndex = 1835
        Me.kengen.Text = "kengen"
        Me.kengen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.kengen.Visible = False
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
        Me.Edit013.TabIndex = 13
        Me.Edit013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'CL004
        '
        Me.CL004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL004.Location = New System.Drawing.Point(184, 204)
        Me.CL004.Name = "CL004"
        Me.CL004.Size = New System.Drawing.Size(52, 16)
        Me.CL004.TabIndex = 1840
        Me.CL004.Text = "CL004"
        Me.CL004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL004.Visible = False
        '
        'GRP
        '
        Me.GRP.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.GRP.Location = New System.Drawing.Point(36, 128)
        Me.GRP.Name = "GRP"
        Me.GRP.Size = New System.Drawing.Size(52, 16)
        Me.GRP.TabIndex = 1844
        Me.GRP.Text = "GRP"
        Me.GRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GRP.Visible = False
        '
        'Number001_nTax
        '
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
        Me.Number001_nTax.TabIndex = 6
        Me.Number001_nTax.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001_nTax.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'EDIT904
        '
        Me.EDIT904.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.EDIT904.Format = "9A"
        Me.EDIT904.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.EDIT904.LengthAsByte = True
        Me.EDIT904.Location = New System.Drawing.Point(904, 148)
        Me.EDIT904.MaxLength = 9
        Me.EDIT904.Name = "EDIT904"
        Me.EDIT904.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.EDIT904.Size = New System.Drawing.Size(88, 20)
        Me.EDIT904.TabIndex = 32
        Me.EDIT904.Text = "EDIT904"
        Me.EDIT904.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.EDIT904.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Navy
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(824, 148)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(80, 20)
        Me.Label34.TabIndex = 1846
        Me.Label34.Text = "ÉlÉoì`î‘çÜ2"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL005
        '
        Me.CL005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL005.Location = New System.Drawing.Point(388, 200)
        Me.CL005.Name = "CL005"
        Me.CL005.Size = New System.Drawing.Size(52, 16)
        Me.CL005.TabIndex = 1872
        Me.CL005.Text = "CL005"
        Me.CL005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL005.Visible = False
        '
        'CL002_2
        '
        Me.CL002_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002_2.Location = New System.Drawing.Point(100, 128)
        Me.CL002_2.Name = "CL002_2"
        Me.CL002_2.Size = New System.Drawing.Size(52, 16)
        Me.CL002_2.TabIndex = 1871
        Me.CL002_2.Text = "CL002_2"
        Me.CL002_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002_2.Visible = False
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(560, 56)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(52, 16)
        Me.CL003.TabIndex = 1869
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(220, 56)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1868
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(220, 36)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1867
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'CL006
        '
        Me.CL006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL006.Location = New System.Drawing.Point(584, 0)
        Me.CL006.Name = "CL006"
        Me.CL006.Size = New System.Drawing.Size(52, 16)
        Me.CL006.TabIndex = 1875
        Me.CL006.Text = "CL006"
        Me.CL006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL006.Visible = False
        '
        'Combo006
        '
        Me.Combo006.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo006.Enabled = False
        Me.Combo006.Location = New System.Drawing.Point(536, 8)
        Me.Combo006.MaxDropDownItems = 20
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(116, 20)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 0
        Me.Combo006.Value = "Combo006"
        '
        'CL007
        '
        Me.CL007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL007.Location = New System.Drawing.Point(696, 0)
        Me.CL007.Name = "CL007"
        Me.CL007.Size = New System.Drawing.Size(48, 16)
        Me.CL007.TabIndex = 1869
        Me.CL007.Text = "CL007"
        Me.CL007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL007.Visible = False
        '
        'Combo007
        '
        Me.Combo007.AutoSelect = True
        Me.Combo007.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo007.Enabled = False
        Me.Combo007.Location = New System.Drawing.Point(652, 8)
        Me.Combo007.MaxDropDownItems = 20
        Me.Combo007.Name = "Combo007"
        Me.Combo007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo007.Size = New System.Drawing.Size(108, 20)
        Me.Combo007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo007.TabIndex = 1
        Me.Combo007.Value = "Combo007"
        '
        'F10_Form21
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Panel_äÆóπ)
        Me.Controls.Add(Me.Panel_å©êœ)
        Me.Controls.Add(Me.Panel_éÛït)
        Me.Controls.Add(Me.CL006)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.CL002_2)
        Me.Controls.Add(Me.CL005)
        Me.Controls.Add(Me.CL003)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.EDIT904)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Number001_nTax)
        Me.Controls.Add(Me.GRP)
        Me.Controls.Add(Me.CL004)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Edit013)
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
        Me.Controls.Add(Me.Edit903)
        Me.Controls.Add(Me.Date011)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Date007)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Date006)
        Me.Controls.Add(Me.Label14)
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
        Me.Controls.Add(Me.CL007)
        Me.Controls.Add(Me.Combo007)
        Me.Controls.Add(Me.CHG)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F10_Form21"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "èCóùÉfÅ[É^èCê≥"
        Me.Panel_éÛït.ResumeLayout(False)
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
        CType(Me.Combo_K003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rebate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_K002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit903, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.EDIT904, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  ãNìÆéû
    '********************************************************************
    Private Sub F10_Form21_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DB_INIT() = "1" Then Application.Exit() : Exit Sub
        inz()       '**  èâä˙èàóù
        If Err_F = "1" Then Application.Exit() : Exit Sub
        ACES()      '**  å†å¿É`ÉFÉbÉN
        inz_dsp()   '**  èâä˙âÊñ ÉZÉbÉg
        Button13_Click(sender, e)

        If P_DBG = "True" Then 'ÉfÉoÉbÉNï\é¶
            Number029.Visible = True : Number039.Visible = True

            kengen.Visible = True
            GRP.Visible = True
            Number001.Visible = True
            CL001.Visible = True : CL002.Visible = True : CL003.Visible = True : CL004.Visible = True : CL005.Visible = True
            CL002_2.Visible = True

            CLU001.Visible = True
            CLU002.Visible = True
            CK_own_flg.Visible = True
            Ck_atri_flg.Visible = True

            CLM001.Visible = True
            CLM003.Visible = True

            CLK001.Visible = True
            CLK001_BRH.Visible = True
            CLK002.Visible = True

            zero_code.Visible = True
            zero_name.Visible = True
            CHG.Visible = True
        End If

        inz_F = "1"
    End Sub

    '********************************************************************
    '**  èâä˙èàóù
    '********************************************************************
    Sub inz()
        'Å~ï¬Ç∂ÇÈÇégópïsâ¬
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        strcurdir = System.IO.Directory.GetCurrentDirectory                                                 'é¿çsÉtÉHÉãÉ_Å[

        Err_F = "0"
        P_EMPL = System.Environment.UserName
        If P_EMPL = "otsuki" Then P_EMPL = "administrator" 'ëÂíŒÉeÉXÉgóp

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_Login_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 20)
        Pram1.Value = P_EMPL
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Err_F = "1"
            MessageBox.Show("ÉÜÅ[ÉUÅ[Ç™ìoò^Ç≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DtView1(0)("delt_flg") = "1" Then
                Err_F = "1"
                MessageBox.Show("ÉÜÅ[ÉUÅ[ìoò^Ç™ñ≥å¯Ç≈Ç∑ÅB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                P_EMPL_NO = DtView1(0)("empl_code")
                P_EMPL_NAME = Trim(DtView1(0)("name"))

                If P_EMPL_BRCH <> Nothing Then
                    SqlCmd1 = New SqlClient.SqlCommand("SP_Login_02", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
                    Pram2.Value = P_EMPL_BRCH
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    SqlCmd1.CommandTimeout = 600
                    DaList1.Fill(DsList1, "BRCH")
                    DB_CLOSE()
                    DtView2 = New DataView(DsList1.Tables("BRCH"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        P_EMPL_BRCH_name = Trim(DtView2(0)("brch_name"))
                        P_full = DtView2(0)("full_cntl")
                        P_comp_code = DtView2(0)("comp_code")
                        P_area_code = DtView2(0)("area_code")
                    End If
                Else
                    P_EMPL_BRCH = Trim(DtView1(0)("brch_code"))
                    P_EMPL_BRCH_name = Trim(DtView1(0)("brch_name"))
                    P_full = DtView1(0)("full_cntl")
                    P_comp_code = DtView1(0)("comp_code")
                    P_area_code = DtView1(0)("area_code")
                End If
                P_ACES_brch_code = P_EMPL_BRCH
                P_ACES_post_code = Trim(DtView1(0)("post_code"))

                If Not IsDBNull(DtView1(0)("rpar_comp_code")) Then P_rpar_comp_code = DtView1(0)("rpar_comp_code") Else P_rpar_comp_code = Nothing

                If Not IsDBNull(DtView1(0)("admin_flg")) Then P_DBG = DtView1(0)("admin_flg") Else P_DBG = "False"
            End If
        End If

        msg.Text = Nothing
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='999'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            kengen.Text = DtView1(0)("access_cls")
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button1.Enabled = False
                Case Is = "3"
                    Button1.Enabled = True
                Case Is = "4"
                    Button1.Enabled = True
            End Select
        Else
            MessageBox.Show("å†å¿Ç™Ç†ÇËÇ‹ÇπÇÒÅB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End If
    End Sub

    '********************************************************************
    '**  ÉRÉìÉ{É{ÉbÉNÉXÉZÉbÉg
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")
        DsCMB0.Clear()

        'éÛïtíSìñ
        strSQL = "SELECT empl_code, name FROM M01_EMPL ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "M01_EMPL_006")

        Combo006.DataSource = DsCMB0.Tables("M01_EMPL_006")
        Combo006.DisplayMember = "name"
        Combo006.ValueMember = "empl_code"

        'éÛïtãíì_
        strSQL = "SELECT brch_code, brch_code + ':' + name AS brch_name"
        strSQL = strSQL & " FROM M03_BRCH"
        'strSQL = strSQL & " ORDER BYÅ@dsp_seq, brch_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "M03_BRCH_007")

        Combo007.DataSource = DsCMB0.Tables("M03_BRCH_007")
        Combo007.DisplayMember = "brch_name"
        Combo007.ValueMember = "brch_code"

        'éÛïtéÌï 
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '007') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "CLS_CODE_007")

        Combo001.DataSource = DsCMB0.Tables("CLS_CODE_007")
        Combo001.DisplayMember = "cls_code_name"
        Combo001.ValueMember = "cls_code"

        'ì¸â◊ãÊï™
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '018') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "CLS_CODE_018")

        Combo002.DataSource = DsCMB0.Tables("CLS_CODE_018")
        Combo002.DisplayMember = "cls_code_name"
        Combo002.ValueMember = "cls_code"

        'ì¸â◊íSìñ
        strSQL = "SELECT empl_code, name FROM ("
        strSQL = strSQL & " SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (delt_flg = 0) AND (brch_code = '" & P_EMPL_BRCH & "')"
        strSQL = strSQL & " UNION"
        strSQL = strSQL & " SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (empl_code = " & P_EMPL_NO & ")"
        strSQL = strSQL & " UNION"
        strSQL = strSQL & " SELECT T01_REP_MTR.arvl_empl AS empl_code, M01_EMPL.name, M01_EMPL.name_kana"
        strSQL = strSQL & " FROM T01_REP_MTR INNER JOIN M01_EMPL ON T01_REP_MTR.arvl_empl = M01_EMPL.empl_code"
        strSQL = strSQL & " WHERE (T01_REP_MTR.rcpt_no = '" & Edit000.Text & "')"
        strSQL = strSQL & ") M01_EMPL ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "M01_EMPL_003")

        Combo003.DataSource = DsCMB0.Tables("M01_EMPL_003")
        Combo003.DisplayMember = "name"
        Combo003.ValueMember = "empl_code"

        'èCóùéÌï 
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '001') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "CLS_CODE_001")

        Combo004.DataSource = DsCMB0.Tables("CLS_CODE_001")
        Combo004.DisplayMember = "cls_code_name"
        Combo004.ValueMember = "cls_code"

        'éñåÃèÛãµ
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '022') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "CLS_CODE_022")

        Combo005.DataSource = DsCMB0.Tables("CLS_CODE_022")
        Combo005.DisplayMember = "cls_code_name"
        Combo005.ValueMember = "cls_code"

        'èCóùïîèê
        strSQL = "SELECT rpar_comp_code, rpar_comp_code + ':' + name AS name"
        strSQL = strSQL & " FROM M06_RPAR_COMP"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        strSQL = strSQL & " AND (delt_flg = 1)" 'èâä˙ÇÕëŒè€Ç»Çµ
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "M06_RPAR_COMP")

        Combo_U002.DataSource = DsCMB0.Tables("M06_RPAR_COMP")
        Combo_U002.DisplayMember = "name"
        Combo_U002.ValueMember = "rpar_comp_code"

        'ÉÅÅ[ÉJÅ[
        strSQL = "SELECT vndr_code, vndr_code + ':' + name AS name, rcpt_up2, qg_vndr_link"
        strSQL = strSQL & " FROM M05_VNDR"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "M05_VNDR")

        Combo_U001.DataSource = DsCMB0.Tables("M05_VNDR")
        Combo_U001.DisplayMember = "name"
        Combo_U001.ValueMember = "vndr_code"

        'å©êœíSìñ
        strSQL = "SELECT empl_code, name FROM ("
        strSQL = strSQL & " SELECT empl_code, name, name_kana"
        strSQL = strSQL & " FROM M01_EMPL"
        strSQL = strSQL & " WHERE (delt_flg = 0) AND (brch_code = '" & P_EMPL_BRCH & "')"
        strSQL = strSQL & " UNION"
        strSQL = strSQL & " SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (empl_code = " & P_EMPL_NO & ")"
        strSQL = strSQL & " UNION"
        strSQL = strSQL & " SELECT T01_REP_MTR.repr_empl_code AS empl_code, M01_EMPL.name, M01_EMPL.name_kana"
        strSQL = strSQL & " FROM T01_REP_MTR INNER JOIN M01_EMPL ON T01_REP_MTR.repr_empl_code = M01_EMPL.empl_code"
        strSQL = strSQL & " WHERE (T01_REP_MTR.rcpt_no = '" & Edit000.Text & "')"
        strSQL = strSQL & ") M01_EMPL ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "M01_EMPL_M001")

        Combo_M001.DataSource = DsCMB0.Tables("M01_EMPL_M001")
        Combo_M001.DisplayMember = "name"
        Combo_M001.ValueMember = "empl_code"

        'ìÔà’ìx
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL = strSQL & " FROM M21_CLS_CODE"
        strSQL = strSQL & " WHERE (cls_no = '013') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "CLS_CODE_013")

        Combo_M003.DataSource = DsCMB0.Tables("CLS_CODE_013")
        Combo_M003.DisplayMember = "cls_code_name"
        Combo_M003.ValueMember = "cls_code"

        'åvè„ÇpÇf
        strSQL = "SELECT brch_code, brch_code + ':' + name AS brch_name"
        strSQL = strSQL & " FROM M03_BRCH"
        strSQL = strSQL & " WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB0, "M03_BRCH")

        Combo_K003.DataSource = DsCMB0.Tables("M03_BRCH")
        Combo_K003.DisplayMember = "brch_name"
        Combo_K003.ValueMember = "brch_code"

        DB_CLOSE()
    End Sub
    Sub Cmb3()      'èCóùíSìñ

        If CK_own_flg.Checked = True Then    'é©é–èCóù

            strSQL = "SELECT M01_EMPL_00.empl_code, M01_EMPL_00.name, M01_EMPL_00.brch_code, M06_RPAR_COMP.name AS brch_name"
            strSQL = strSQL & " FROM (SELECT M01_EMPL_1.empl_code, M01_EMPL_1.name, M01_EMPL_1.name_kana, M06_RPAR_COMP_1.rpar_comp_code AS brch_code"
            strSQL = strSQL & " FROM M03_BRCH AS M03_BRCH_1"
            strSQL = strSQL & " INNER JOIN M01_EMPL AS M01_EMPL_1 ON M03_BRCH_1.brch_code = M01_EMPL_1.brch_code"
            strSQL = strSQL & " INNER JOIN M06_RPAR_COMP AS M06_RPAR_COMP_1 ON M03_BRCH_1.brch_code = M06_RPAR_COMP_1.brch_code"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " INNER JOIN M02_ATRI AS M02_ATRI_1 ON M01_EMPL_1.empl_code = M02_ATRI_1.empl_code"
            End If
            strSQL = strSQL & " WHERE (M06_RPAR_COMP_1.rpar_comp_code = '" & DtView1(0)("rpar_comp_code") & "')"
            strSQL = strSQL & " AND (M01_EMPL_1.role_code = '02')"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " AND (M02_ATRI_1.vndr_code = '" & CLU001.Text & "')"
            End If

            strSQL = strSQL & " UNION"
            strSQL = strSQL & " SELECT M01_EMPL_2.empl_code, M01_EMPL_2.name, M01_EMPL_2.name_kana, '" & P_rpar_comp_code & "' AS brch_code"
            strSQL = strSQL & " FROM M01_EMPL AS M01_EMPL_2"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " LEFT OUTER JOIN M02_ATRI AS M02_ATRI_2 ON M01_EMPL_2.empl_code = M02_ATRI_2.empl_code"
            End If
            strSQL = strSQL & " WHERE (M01_EMPL_2.empl_code = " & P_EMPL_NO & ")"
            strSQL = strSQL & " AND (M01_EMPL_2.role_code = '02')"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " AND (M02_ATRI_2.vndr_code = '" & CLU001.Text & "')"
            End If

            strSQL = strSQL & " UNION"
            strSQL = strSQL & " SELECT T01_REP_MTR_3.repr_empl_code AS empl_code, M01_EMPL_3.name, M01_EMPL_3.name_kana, T01_REP_MTR_3.repr_brch_code AS brch_code"
            strSQL = strSQL & " FROM M01_EMPL AS M01_EMPL_3"
            strSQL = strSQL & " INNER JOIN T01_REP_MTR AS T01_REP_MTR_3 ON M01_EMPL_3.empl_code = T01_REP_MTR_3.repr_empl_code"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " LEFT OUTER JOIN M02_ATRI AS M02_ATRI_3 ON M01_EMPL_3.empl_code = M02_ATRI_3.empl_code"
            End If
            strSQL = strSQL & " WHERE (T01_REP_MTR_3.rcpt_no = '" & Edit000.Text & "')"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " AND (M02_ATRI_3.vndr_code = '" & CLU001.Text & "')"
            End If
            strSQL = strSQL & ") AS M01_EMPL_00 INNER JOIN"
            strSQL = strSQL & " M06_RPAR_COMP ON M01_EMPL_00.brch_code = M06_RPAR_COMP.rpar_comp_code"
            strSQL = strSQL & " ORDER BY M01_EMPL_00.name_kana"
        Else
            strSQL = "SELECT M01_EMPL_00.empl_code, M01_EMPL_00.name, M01_EMPL_00.brch_code, M06_RPAR_COMP.name AS brch_name"
            strSQL = strSQL & " FROM (SELECT M01_EMPL_1.empl_code, M01_EMPL_1.name, M01_EMPL_1.name_kana, M06_RPAR_COMP.rpar_comp_code AS brch_code"
            strSQL = strSQL & " FROM M01_EMPL AS M01_EMPL_1 INNER JOIN M06_RPAR_COMP ON M01_EMPL_1.brch_code = M06_RPAR_COMP.brch_code"
            strSQL = strSQL & " WHERE (M01_EMPL_1.delt_flg = 0) AND (M01_EMPL_1.empl_code <> " & P_EMPL_NO & ")"

            strSQL = strSQL & " UNION"
            strSQL = strSQL & " SELECT M01_EMPL_2.empl_code, M01_EMPL_2.name, M01_EMPL_2.name_kana, '" & P_rpar_comp_code & "' AS brch_code"
            strSQL = strSQL & " FROM M01_EMPL AS M01_EMPL_2"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " INNER JOIN M02_ATRI AS M02_ATRI_2 ON M01_EMPL_2.empl_code = M02_ATRI_2.empl_code"
            End If
            strSQL = strSQL & " WHERE (M01_EMPL_2.empl_code = " & P_EMPL_NO & ")"
            strSQL = strSQL & " AND (M01_EMPL_2.role_code = '02')"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " AND (M02_ATRI_2.vndr_code = '" & CLU001.Text & "')"
            End If

            strSQL = strSQL & " UNION"
            strSQL = strSQL & " SELECT T01_REP_MTR_3.repr_empl_code AS empl_code, M01_EMPL_3.name, M01_EMPL_3.name_kana, T01_REP_MTR_3.repr_brch_code AS brch_code"
            strSQL = strSQL & " FROM T01_REP_MTR AS T01_REP_MTR_3"
            strSQL = strSQL & " INNER JOIN M01_EMPL AS M01_EMPL_3 ON T01_REP_MTR_3.repr_empl_code = M01_EMPL_3.empl_code"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " LEFT OUTER JOIN M02_ATRI AS M02_ATRI_3 ON M01_EMPL_3.empl_code = M02_ATRI_3.empl_code"
            End If
            strSQL = strSQL & " WHERE (T01_REP_MTR_3.rcpt_no = '" & Edit000.Text & "')"
            If Ck_atri_flg.Checked = True Then
                strSQL = strSQL & " AND (M02_ATRI_3.vndr_code = '" & CLU001.Text & "')"
            End If
            strSQL = strSQL & ") AS M01_EMPL_00 INNER JOIN"
            strSQL = strSQL & " M06_RPAR_COMP ON M01_EMPL_00.brch_code = M06_RPAR_COMP.rpar_comp_code"
            strSQL = strSQL & " ORDER BY M01_EMPL_00.name_kana"
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB0, "M01_EMPL_K001")
        DB_CLOSE()
        Combo_K001.DataSource = DsCMB0.Tables("M01_EMPL_K001")
        Combo_K001.DisplayMember = "name"
        Combo_K001.DescriptionMember = "brch_name"
        Combo_K001.ValueMember = "empl_code"

    End Sub
    Sub Cmb4()      'ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóø

        DsCMB2.Clear()
        strSQL = "SELECT seq, select_case, tech_amnt"
        strSQL = strSQL & " FROM dbo.M14_VNDR_SUB"
        strSQL = strSQL & " WHERE (vndr_code = '" & CLU001.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB2, "M14_VNDR_SUB")
        DB_CLOSE()
        Combo_K002.DataSource = DsCMB2.Tables("M14_VNDR_SUB")
        Combo_K002.DisplayMember = "select_case"
        Combo_K002.ValueMember = "seq"

    End Sub

    '********************************************************************
    '**  èâä˙âÊñ 
    '********************************************************************
    Sub inz_dsp()
        msg.Text = Nothing
        Number001.Value = 0 : Number001_nTax.Value = 0 : Number002.Value = 0 : Number003.Value = 0

        Button0.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button80.Enabled = False
        Edit000.Text = Nothing  'éÛïtî‘çÜ
        Edit000.ReadOnly = False : Edit000.TabStop = True : Edit000.BackColor = System.Drawing.SystemColors.Window

        Label5.Text = Nothing

        Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True
        Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
        Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
        Label001.Visible = True : Label002.Visible = True : Label003.Visible = True : Label004.Visible = True : Label005.Visible = True : Label006.Visible = True : Label007.Visible = True
        Edit001.Visible = True : Edit002.Visible = True : Edit003.Visible = True : Edit004.Visible = True : Date001.Visible = True
        NumberN008.Value = 0

        Label001.Text = Nothing : Label002.Text = Nothing
        Edit903.Enabled = False : Edit903.Text = Nothing : Edit903.BackColor = System.Drawing.SystemColors.Window
        EDIT904.Enabled = False : EDIT904.Text = Nothing : EDIT904.BackColor = System.Drawing.SystemColors.Window
        Date001.Enabled = False : Date001.Text = Nothing : Date001.BackColor = System.Drawing.SystemColors.Window
        Date003.Enabled = False : Date003.Text = Nothing : Date003.BackColor = System.Drawing.SystemColors.Window
        Date004.Enabled = False : Date004.Text = Nothing : Date004.BackColor = System.Drawing.SystemColors.Window
        Date006.Enabled = False : Date006.Text = Nothing : Date006.BackColor = System.Drawing.SystemColors.Window
        Date007.Enabled = False : Date007.Text = Nothing : Date007.BackColor = System.Drawing.SystemColors.Window
        Date008.Enabled = False : Date008.Text = Nothing : Date008.BackColor = System.Drawing.SystemColors.Window
        Date010.Enabled = False : Date010.Text = Nothing : Date010.BackColor = System.Drawing.SystemColors.Window
        Date011.Enabled = False : Date011.Text = Nothing : Date011.BackColor = System.Drawing.SystemColors.Window
        Date012.Enabled = False : Date012.Text = Nothing : Date012.BackColor = System.Drawing.SystemColors.Window
        Date013.Enabled = False : Date013.Text = Nothing : Date013.BackColor = System.Drawing.SystemColors.Window
        Combo001.Enabled = False : Combo001.Text = Nothing : Combo001.BackColor = System.Drawing.SystemColors.Window
        Combo002.Enabled = False : Combo002.Text = Nothing : Combo002.BackColor = System.Drawing.SystemColors.Window
        Combo003.Enabled = False : Combo003.Text = Nothing : Combo003.BackColor = System.Drawing.SystemColors.Window
        Combo004.Enabled = False : Combo004.Text = Nothing : Combo004.BackColor = System.Drawing.SystemColors.Window
        Combo005.Enabled = False : Combo005.Text = Nothing : Combo005.BackColor = System.Drawing.SystemColors.Window
        Combo006.Enabled = False : Combo006.Text = Nothing : Combo006.BackColor = System.Drawing.SystemColors.Window
        Combo007.Enabled = False : Combo007.Text = Nothing : Combo007.BackColor = System.Drawing.SystemColors.Window
        Edit001.Enabled = False : Edit001.Text = Nothing : Edit001.BackColor = System.Drawing.SystemColors.Window
        Edit002.Enabled = False : Edit002.Text = Nothing : Edit002.BackColor = System.Drawing.SystemColors.Window
        Edit003.Enabled = False : Edit003.Text = Nothing : Edit003.BackColor = System.Drawing.SystemColors.Window
        Edit004.Enabled = False : Edit004.Text = Nothing : Edit004.BackColor = System.Drawing.SystemColors.Window
        Edit005.Enabled = False : Edit005.Text = Nothing : Edit005.BackColor = System.Drawing.SystemColors.Window
        Edit006.Enabled = False : Edit006.Text = Nothing : Edit006.BackColor = System.Drawing.SystemColors.Window
        Edit007.Enabled = False : Edit007.Text = Nothing : Edit007.BackColor = System.Drawing.SystemColors.Window
        Edit008.Enabled = False : Edit008.Text = Nothing : Edit008.BackColor = System.Drawing.SystemColors.Window
        Edit009.Enabled = False : Edit009.Text = Nothing : Edit009.BackColor = System.Drawing.SystemColors.Window
        Edit010.Enabled = False : Edit010.Text = Nothing : Edit010.BackColor = System.Drawing.SystemColors.Window
        Edit011.Enabled = False : Edit011.Text = Nothing : Edit011.BackColor = System.Drawing.SystemColors.Window
        Edit012.Enabled = False : Edit012.Text = Nothing : Edit012.BackColor = System.Drawing.SystemColors.Window
        Edit013.Enabled = False : Edit013.Text = Nothing : Edit013.BackColor = System.Drawing.SystemColors.Window
        Mask1.Enabled = False : Mask1.Text = Nothing : Mask1.BackColor = System.Drawing.SystemColors.Window
        Number001_nTax.Enabled = False : Number001_nTax.Value = 0 : Number001_nTax.BackColor = System.Drawing.SystemColors.Window
        Number002.Enabled = False : Number002.Value = 0 : Number002.BackColor = System.Drawing.SystemColors.Window
        Number003.Enabled = False : Number003.Value = 0 : Number003.BackColor = System.Drawing.SystemColors.Window

        'éÛït
        Date_U001.Enabled = False : Date_U001.Text = Nothing : Date_U001.BackColor = System.Drawing.SystemColors.Window
        Date_U002.Enabled = False : Date_U002.Text = Nothing : Date_U002.BackColor = System.Drawing.SystemColors.Window
        Date_U003.Enabled = False : Date_U003.Text = Nothing : Date_U003.BackColor = System.Drawing.SystemColors.Window
        Combo_U001.Enabled = False : Combo_U001.Text = Nothing : Combo_U001.BackColor = System.Drawing.SystemColors.Window
        Combo_U002.Enabled = False : Combo_U002.Text = Nothing : Combo_U002.BackColor = System.Drawing.SystemColors.Window
        Edit_U001.Enabled = False : Edit_U001.Text = Nothing : Edit_U001.BackColor = System.Drawing.SystemColors.Window
        Edit_U002.Enabled = False : Edit_U002.Text = Nothing : Edit_U002.BackColor = System.Drawing.SystemColors.Window
        Edit_U003.Enabled = False : Edit_U003.Text = Nothing : Edit_U003.BackColor = System.Drawing.SystemColors.Window
        Edit_U004.Enabled = False : Edit_U004.Text = Nothing : Edit_U004.BackColor = System.Drawing.SystemColors.Window
        Edit_U005.Enabled = False : Edit_U005.Text = Nothing : Edit_U005.BackColor = System.Drawing.SystemColors.Window
        CheckBox_U001.Enabled = False : CheckBox_U001.Checked = False : CheckBox_U001.BackColor = System.Drawing.SystemColors.Control
        CheckBox_U002.Enabled = False : CheckBox_U002.Checked = False : CheckBox_U002.BackColor = System.Drawing.SystemColors.Control
        Panel_U1.Controls.Clear()
        Panel_U2.Controls.Clear()

        'å©êœ
        Combo_M001.Enabled = False : Combo_M001.Text = Nothing : Combo_M001.BackColor = System.Drawing.SystemColors.Window
        Combo_M003.Enabled = False : Combo_M003.Text = Nothing : Combo_M003.BackColor = System.Drawing.SystemColors.Window
        Edit_M001.Enabled = False : Edit_M001.Text = Nothing : Edit_M001.BackColor = System.Drawing.SystemColors.Window
        Edit_M002.Enabled = False : Edit_M002.Text = Nothing : Edit_M002.BackColor = System.Drawing.SystemColors.Window
        Edit_M003.Enabled = False : Edit_M003.Text = Nothing : Edit_M003.BackColor = System.Drawing.SystemColors.Window
        Edit_M004.Enabled = False : Edit_M004.Text = Nothing : Edit_M004.BackColor = System.Drawing.SystemColors.Window

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
        Number029.Value = 0
        Number039.Value = 0
        Button_M001.Enabled = False

        Panel_M1.Controls.Clear()
        P_DsList1.Clear()
        DsList1.Clear()

        'äÆóπ
        Combo004.Enabled = False : Combo004.Text = Nothing : Combo004.BackColor = System.Drawing.SystemColors.Window
        Combo005.Enabled = False : Combo005.Text = Nothing : Combo005.BackColor = System.Drawing.SystemColors.Window
        Combo_K001.Enabled = False : Combo_K001.Text = Nothing : Combo_K001.BackColor = System.Drawing.SystemColors.Window
        Combo_K002.Enabled = False : Combo_K002.Text = Nothing : Combo_K002.BackColor = System.Drawing.SystemColors.Window
        Combo_K003.Enabled = False : Combo_K003.Text = Nothing : Combo_K003.BackColor = System.Drawing.SystemColors.Window
        Edit_K001.Enabled = False : Edit_K001.Text = Nothing : Edit_K001.BackColor = System.Drawing.SystemColors.Window
        Edit_K002.Enabled = False : Edit_K002.Text = Nothing : Edit_K002.BackColor = System.Drawing.SystemColors.Window

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
        Button_K001.Enabled = False

        Panel_K1.Controls.Clear()

        Edit000.Focus()
    End Sub

    '********************************************************************
    '**  ì¸óÕâÊñ 
    '********************************************************************
    Sub ent_dsp()

        Button0.Enabled = False
        Button2.Enabled = True

        Combo001.Enabled = True : Combo002.Enabled = True : Combo003.Enabled = True : Combo004.Enabled = True : Combo005.Enabled = True
        Combo006.Enabled = True : Combo007.Enabled = True
        Number001_nTax.Enabled = True : Number002.Enabled = True : Number003.Enabled = True
        Edit001.Enabled = True : Edit003.Enabled = True : Edit004.Enabled = True : Edit005.Enabled = True : Edit006.Enabled = True
        Edit007.Enabled = True : Edit008.Enabled = True : Edit009.Enabled = True : Edit010.Enabled = True : Edit011.Enabled = True
        Edit012.Enabled = True : Edit013.Enabled = True
        Date001.Enabled = True : Date003.Enabled = True : Date004.Enabled = True : Date006.Enabled = True : Date007.Enabled = True
        Date008.Enabled = True : Date010.Enabled = True : Date011.Enabled = True : Date012.Enabled = True : Date013.Enabled = True
        Mask1.Enabled = True

        'éÛït
        Combo_U001.Enabled = True : Combo_U002.Enabled = True
        Edit_U001.Enabled = True : Edit_U002.Enabled = True : Edit_U003.Enabled = True : Edit_U004.Enabled = True : Edit_U005.Enabled = True
        CheckBox_U001.Enabled = True : CheckBox_U002.Enabled = True
        Date_U001.Enabled = True : Date_U002.Enabled = True : Date_U003.Enabled = True

        'å©êœ
        Combo_M001.Enabled = True : Combo_M003.Enabled = True
        Edit_M001.Enabled = True : Edit_M002.Enabled = True : Edit_M003.Enabled = True : Edit_M004.Enabled = True
        Number011.Enabled = True : Number012.Enabled = True : Number013.Enabled = True : Number014.Enabled = True : Number015.Enabled = True
        Number021.Enabled = True : Number023.Enabled = True : Number024.Enabled = True : Number025.Enabled = True
        Number031.Enabled = True : Number033.Enabled = True : Number034.Enabled = True : Number035.Enabled = True
        Number019.Enabled = True
        Number040.Enabled = True
        Button_M001.Enabled = True

        'äÆóπ
        Combo_K001.Enabled = True : Combo_K002.Enabled = True : Combo_K003.Enabled = True
        Number111.Enabled = True : Number112.Enabled = True : Number113.Enabled = True : Number114.Enabled = True : Number115.Enabled = True
        Number121.Enabled = True : Number123.Enabled = True : Number124.Enabled = True : Number125.Enabled = True
        Number131.Enabled = True : Number133.Enabled = True : Number134.Enabled = True : Number135.Enabled = True
        Button_K001.Enabled = True

    End Sub

    '********************************************************************
    '**  éÛïtî‘çÜEnter
    '********************************************************************
    Private Sub Edit000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Edit000.KeyDown
        If e.KeyCode = Keys.Enter Then
            inz_F = "0"
            rep_scan()  '** èCóùèÓïÒÇfÇdÇs
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

        'åÃè·ì‡óe
        strSQL = "SELECT T03_REP_CMNT.rcpt_no, T03_REP_CMNT.kbn, T03_REP_CMNT.seq, T03_REP_CMNT.cls_code1"
        strSQL = strSQL & ", T03_REP_CMNT.cmnt_code1, T03_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
        strSQL = strSQL & " FROM T03_REP_CMNT LEFT OUTER JOIN"
        strSQL = strSQL & " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
        strSQL = strSQL & " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
        strSQL = strSQL & " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
        strSQL = strSQL & " AND (T03_REP_CMNT.kbn = '1')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T03_REP_CMNT")

        'å©êœì‡óe
        strSQL = "SELECT T03_REP_CMNT.rcpt_no, T03_REP_CMNT.kbn, T03_REP_CMNT.seq, T03_REP_CMNT.cls_code1"
        strSQL = strSQL & ", T03_REP_CMNT.cmnt_code1, T03_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
        strSQL = strSQL & " FROM T03_REP_CMNT LEFT OUTER JOIN"
        strSQL = strSQL & " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
        strSQL = strSQL & " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
        strSQL = strSQL & " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
        strSQL = strSQL & " AND (T03_REP_CMNT.kbn = '2')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T03_REP_CMNT_2")

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

        'äÆóπì‡óe
        strSQL = "SELECT T03_REP_CMNT.rcpt_no, T03_REP_CMNT.kbn, T03_REP_CMNT.seq, T03_REP_CMNT.cls_code1"
        strSQL = strSQL & ", T03_REP_CMNT.cmnt_code1, T03_REP_CMNT.cmnt_code1 + ':' + M10_CMNT.cmnt AS cmnt_name1"
        strSQL = strSQL & " FROM T03_REP_CMNT LEFT OUTER JOIN"
        strSQL = strSQL & " M10_CMNT ON T03_REP_CMNT.cls_code1 = M10_CMNT.cls_code AND"
        strSQL = strSQL & " T03_REP_CMNT.cmnt_code1 = M10_CMNT.cmnt_code"
        strSQL = strSQL & " WHERE (T03_REP_CMNT.rcpt_no = '" & Edit000.Text & "')"
        strSQL = strSQL & " AND (T03_REP_CMNT.kbn = '3')"
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
            ent_dsp()   'ì¸óÕÉÇÅ[Éh
            If Not IsDBNull(DtView1(0)("haita_empl_code")) Then
                MessageBox.Show(DtView1(0)("haita_empl_name") & "Ç≥ÇÒÇ™ " & DtView1(0)("haita_use_date") & " Ç©ÇÁÅAï“èWíÜÇ≈Ç∑ÅB", "ämîF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                If kengen.Text >= "3" Then
                    HAITA_ON(Edit000.Text)  'HAITA_ON
                    Button1.Enabled = True
                End If
            End If
            CmbSet()    '**  ÉRÉìÉ{É{ÉbÉNÉXÉZÉbÉg

            Edit000.ReadOnly = True : Edit000.TabStop = False : Edit000.BackColor = System.Drawing.SystemColors.Control
            Button80.Enabled = True
            Combo006.Text = DtView1(0)("rcpt_ent_empl_name") : CL006.Text = DtView1(0)("rcpt_ent_empl_code")
            Combo007.Text = DtView1(0)("rcpt_brch_code") & ":" & DtView1(0)("rcpt_brch_name") : CL007.Text = DtView1(0)("rcpt_brch_code")

            Date003.Text = DtView1(0)("accp_date")

            Combo001.Text = DtView1(0)("rcpt_name") : CL001.Text = DtView1(0)("rcpt_cls")
            If DtView1(0)("cls_code_name_abbr") = "QGNo" Then
                Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True 'QG No
                Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
                Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
                Edit011.Text = DtView1(0)("qg_care_no")

                WK_DsList1.Clear()
                strSQL = "SELECT *"
                strSQL = strSQL & " FROM T01_â¡ì¸é“ LEFT OUTER JOIN"
                strSQL = strSQL & " (SELECT [ÉRÅ[Éh] AS HSY_code, ñºèÃ AS HSY_name FROM [M_ÉeÅ[ÉuÉã] WHERE (éØï  = N'HSY')) HSY ON"
                strSQL = strSQL & " T01_â¡ì¸é“.ï€èÿîÕàÕ = HSY.HSY_code"
                strSQL = strSQL & " WHERE (T01_â¡ì¸é“.â¡ì¸î‘çÜ = '" & Edit011.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("QGCare")
                DaList1.Fill(WK_DsList1, "T01_â¡ì¸é“")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_â¡ì¸é“"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then Label5.Text = WK_DtView1(0)("HSY_name")
                End If
            Else
                Label21.Visible = False : Edit011.Visible = False : Label5.Visible = False : Edit011.Text = Nothing 'QG No
                Label10.Visible = False : Number001_nTax.Visible = False : Label16.Visible = False
                Label15.Visible = False : Number003.Visible = False : Label17.Visible = False
                Label5.Text = Nothing
            End If
            NumberN009.Value = DtView1(0)("wrn_period")

            Combo002.Text = DtView1(0)("arvl_name") : CL002.Text = DtView1(0)("arvl_cls") : CL002_2.Text = DtView1(0)("cls_code_name_abbr2")
            If DtView1(0)("cls_code_name_abbr2") = "àÍî " Then
                'îÃé–îÒï\é¶
                Label004.Visible = False : Label006.Visible = False : Label007.Visible = False
                Edit003.Visible = False : Edit004.Visible = False : Date001.Visible = False
            Else                                    'îÃé–
                'îÃé–ï\é¶
                Label004.Visible = True : Label006.Visible = True : Label007.Visible = True
                Edit003.Visible = True : Edit004.Visible = True : Date001.Visible = True
            End If

            Combo003.Text = DtView1(0)("arvl_empl_name") : CL003.Text = DtView1(0)("arvl_empl")
            'Cmb1()  'èCóùéÌï 
            Combo004.Text = DtView1(0)("rpar_cls_name") : CL004.Text = DtView1(0)("rpar_cls")
            If Not IsDBNull(DtView1(0)("acdt_name")) Then Combo005.Text = DtView1(0)("acdt_name") Else Combo005.Text = Nothing
            If Not IsDBNull(DtView1(0)("acdt_stts")) Then CL005.Text = DtView1(0)("acdt_stts") Else CL005.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_code")) Then Edit001.Text = DtView1(0)("store_code") Else Edit001.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_name")) Then Label001.Text = DtView1(0)("store_name") Else Label001.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_code")) Then Edit002.Text = DtView1(0)("dlvr_code") Else Edit002.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_name")) Then Label002.Text = DtView1(0)("dlvr_name") Else Label002.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_prsn")) Then Edit003.Text = DtView1(0)("store_prsn") Else Edit003.Text = Nothing

            If Not IsDBNull(DtView1(0)("grup_code")) Then GRP.Text = DtView1(0)("grup_code") Else GRP.Text = Nothing

            If Not IsDBNull(DtView1(0)("store_accp_date")) Then Date001.Text = DtView1(0)("store_accp_date") Else Date001.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_repr_no")) Then Edit004.Text = DtView1(0)("store_repr_no") Else Edit004.Text = Nothing
            If Not IsDBNull(DtView1(0)("part_rate2")) Then NumberN008.Value = DtView1(0)("part_rate2") Else NumberN008.Value = 0
            Edit005.Text = DtView1(0)("user_name")
            Edit006.Text = DtView1(0)("user_name_kana")
            Edit007.Text = DtView1(0)("tel1")
            Edit008.Text = DtView1(0)("tel2")

            Edit009.Text = DtView1(0)("adrs1")
            Edit010.Text = DtView1(0)("adrs2")
            Edit012.Text = DtView1(0)("orgnl_vndr_code")
            If Not IsDBNull(DtView1(0)("store_wrn_info")) Then Edit013.Text = DtView1(0)("store_wrn_info") Else Edit013.Text = Nothing
            Mask1.Value = DtView1(0)("zip")
            If Not IsDBNull(DtView1(0)("wrn_limt_amnt")) Then Number001.Value = DtView1(0)("wrn_limt_amnt") Else Number001.Value = 0
            Number001_nTax.Value = RoundDOWN(Number001.Value / 1.08, 0)
            If Not IsDBNull(DtView1(0)("recv_amnt")) Then Number002.Value = DtView1(0)("recv_amnt") Else Number002.Value = 0
            If Not IsDBNull(DtView1(0)("menseki_amnt")) Then Number003.Value = DtView1(0)("menseki_amnt") Else Number003.Value = 0

            'éÛïtèÓïÒ **********************************
            B11()
            If Not IsDBNull(DtView1(0)("prch_date")) Then Date_U001.Text = DtView1(0)("prch_date") Else Date_U001.Text = Nothing
            If Not IsDBNull(DtView1(0)("vndr_wrn_date")) Then Date_U002.Text = DtView1(0)("vndr_wrn_date") Else Date_U002.Text = Nothing
            If Not IsDBNull(DtView1(0)("acdt_date")) Then Date_U003.Text = DtView1(0)("acdt_date") Else Date_U003.Text = Nothing
            If DtView1(0)("vndr_wrn_date_chk") = "1" Then
                CheckBox_U002.Checked = True
            Else
                CheckBox_U002.Checked = False
            End If

            Combo_U001.Text = DtView1(0)("vndr_name") : CLU001.Text = DtView1(0)("vndr_code")
            If CLU001.Text = "01" Then
                CheckBox_U001.Text = "íËäzèCóù"
            Else
                CheckBox_U001.Text = "ÇmÇèÇîÇÖ"
            End If
            rpar_comp()
            Combo_U002.Text = DtView1(0)("rpar_comp_name") : CLU002.Text = DtView1(0)("rpar_comp_code")

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

            If DtView1(0)("note_kbn") = "01" Then CheckBox_U001.Checked = True Else CheckBox_U001.Checked = False
            If DtView1(0)("atri_flg") = "1" Then Ck_atri_flg.Checked = True Else Ck_atri_flg.Checked = False
            If DtView1(0)("own_flg") = "1" Then CK_own_flg.Checked = True Else CK_own_flg.Checked = False

            'ïtëÆïi
            strSQL = "SELECT item_code, item_name, item_unit"
            strSQL = strSQL & " FROM M12_ATCH_ITEM"
            strSQL = strSQL & " WHERE (delt_flg = 0) AND (item_name <> '')"
            strSQL = strSQL & " ORDER BY dsp_seq, item_code"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "M12_ATCH_ITEM")

            strSQL = "SELECT * FROM T02_ATCH_ITEM WHERE (rcpt_no = '" & Edit000.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "T02_ATCH_ITEM")
            DB_CLOSE()

            WK_DtView2 = New DataView(DsList1.Tables("M12_ATCH_ITEM"), "", "", DataViewRowState.CurrentRows)
            Line_No = 0
            Panel_U1.Controls.Clear()

            'äÓèÄì_
            en = 0
            label(Line_No, en) = New Label
            label(Line_No, en).Location = New System.Drawing.Point(0, 0)
            label(Line_No, en).Size = New System.Drawing.Size(0, 0)
            label(Line_No, en).Text = Nothing
            Panel_U1.Controls.Add(label(Line_No, en))

            If WK_DtView2.Count <> 0 Then
                For Line_No = 0 To WK_DtView2.Count - 1

                    WK_cnt = 0
                    If Not IsDBNull(WK_DtView2(Line_No)("item_code")) Then
                        WK_DtView1 = New DataView(DsList1.Tables("T02_ATCH_ITEM"), "item_code = " & WK_DtView2(Line_No)("item_code"), "", DataViewRowState.CurrentRows)
                        WK_cnt = WK_DtView1.Count
                    End If

                    'ëŒè€
                    en = 1
                    chkBox(Line_No, en) = New CheckBox
                    chkBox(Line_No, en).Location = New System.Drawing.Point(5, 20 * Line_No + label(0, 0).Location.Y)
                    chkBox(Line_No, en).Size = New System.Drawing.Size(25, 20)
                    chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                    chkBox(Line_No, en).Text = Nothing
                    If WK_cnt = 0 Then
                        chkBox(Line_No, en).Checked = False
                    Else
                        chkBox(Line_No, en).Checked = True
                    End If
                    chkBox(Line_No, en).Tag = Line_No
                    Panel_U1.Controls.Add(chkBox(Line_No, en))
                    AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
                    AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

                    'ïtëÆïi
                    en = 1
                    edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(30, 20 * Line_No + label(0, 0).Location.Y)
                    edit(Line_No, en).LengthAsByte = True
                    edit(Line_No, en).MaxLength = 30
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
                    nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0", "", "", "-", "", "", "")
                    nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                    nbrBox(Line_No, en).HighlightText = True
                    nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("0", "", "", "-", "", "", "")
                    nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 20 * Line_No + label(0, 0).Location.Y)
                    nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9, 0, 0, 0})
                    nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
                    nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                    nbrBox(Line_No, en).Size = New System.Drawing.Size(30, 20)
                    If WK_cnt = 0 Then
                        nbrBox(Line_No, en).Value = 0
                    Else
                        nbrBox(Line_No, en).Value = WK_DtView1(0)("amnt")
                    End If
                    If Trim(WK_DtView2(Line_No)("item_unit")) = Nothing Then
                        nbrBox(Line_No, en).Visible = False
                    End If
                    nbrBox(Line_No, en).Tag = Line_No
                    Panel_U1.Controls.Add(nbrBox(Line_No, en))
                    AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY_GotFocus
                    AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY_LostFocus

                    'íPà 
                    en = 2
                    edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(210, 20 * Line_No + label(0, 0).Location.Y)
                    edit(Line_No, en).LengthAsByte = True
                    edit(Line_No, en).MaxLength = 10
                    edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    edit(Line_No, en).Size = New System.Drawing.Size(50, 20)
                    edit(Line_No, en).Enabled = False
                    edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    edit(Line_No, en).Text = WK_DtView2(Line_No)("item_unit")
                    edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
                    Panel_U1.Controls.Add(edit(Line_No, en))

                    'ïtëÆïiÉRÅ[Éh
                    en = 1
                    label(Line_No, en) = New Label
                    label(Line_No, en).Location = New System.Drawing.Point(260, 20 * Line_No + label(0, 0).Location.Y)
                    label(Line_No, en).Size = New System.Drawing.Size(0, 20)
                    label(Line_No, en).Text = WK_DtView2(Line_No)("item_code")
                    Panel_U1.Controls.Add(label(Line_No, en))

                    'SEQ
                    en = 2
                    label(Line_No, en) = New Label
                    label(Line_No, en).Location = New System.Drawing.Point(260, 20 * Line_No + label(0, 0).Location.Y)
                    label(Line_No, en).Size = New System.Drawing.Size(10, 20)
                    label(Line_No, en).Visible = False
                    If WK_cnt <> 0 Then label(Line_No, en).Text = WK_DtView1(0)("seq") Else label(Line_No, en).Text = Nothing
                    Panel_U1.Controls.Add(label(Line_No, en))

                    'ïtëÆïi
                    en = 1
                    edit_MOTO(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit_MOTO(Line_No, en).Location = New System.Drawing.Point(270, 20 * Line_No + label(0, 0).Location.Y)
                    edit_MOTO(Line_No, en).Size = New System.Drawing.Size(50, 20)
                    edit_MOTO(Line_No, en).Enabled = False
                    edit_MOTO(Line_No, en).Visible = False
                    edit_MOTO(Line_No, en).Text = WK_DtView2(Line_No)("item_name")
                    Panel_U1.Controls.Add(edit_MOTO(Line_No, en))

                    'êîó 
                    en = 1
                    nbrBox_MOTO(Line_No, en) = New GrapeCity.Win.Input.Number
                    nbrBox_MOTO(Line_No, en).Location = New System.Drawing.Point(320, 20 * Line_No + label(0, 0).Location.Y)
                    nbrBox_MOTO(Line_No, en).Size = New System.Drawing.Size(30, 20)
                    nbrBox_MOTO(Line_No, en).Enabled = False
                    nbrBox_MOTO(Line_No, en).Visible = False
                    If WK_cnt = 0 Then
                        nbrBox_MOTO(Line_No, en).Value = 0
                    Else
                        nbrBox_MOTO(Line_No, en).Value = WK_DtView1(0)("amnt")
                    End If
                    Panel_U1.Controls.Add(nbrBox_MOTO(Line_No, en))

                    'íPà 
                    en = 2
                    edit_MOTO(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit_MOTO(Line_No, en).Location = New System.Drawing.Point(350, 20 * Line_No + label(0, 0).Location.Y)
                    edit_MOTO(Line_No, en).Size = New System.Drawing.Size(50, 20)
                    edit_MOTO(Line_No, en).Enabled = False
                    edit_MOTO(Line_No, en).Visible = False
                    edit_MOTO(Line_No, en).Text = WK_DtView2(Line_No)("item_unit")
                    Panel_U1.Controls.Add(edit_MOTO(Line_No, en))

                Next
            End If
            Line_No = Line_No - 1
            WK_DtView1 = New DataView(DsList1.Tables("T02_ATCH_ITEM"), "item_code IS NULL", "seq", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    add_line("1")      'ïtëÆïiÉtÉäÅ[ì¸óÕ
                Next
            End If
            add_line("0")      'ïtëÆïiÉtÉäÅ[ì¸óÕ


            'åÃè·ì‡óe
            Line_No2 = -1
            Panel_U2.Controls.Clear()
            WK_DsCMB.Clear()

            'äÓèÄì_
            label_2(0, 0) = New Label
            label_2(0, 0).Location = New System.Drawing.Point(0, 0)
            label_2(0, 0).Size = New System.Drawing.Size(0, 0)
            label_2(0, 0).Text = Nothing
            Panel_U2.Controls.Add(label_2(0, 0))

            WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    add_line_2("1")    'åÃè·ì‡óe
                Next
            End If
            add_line_2("0")    'åÃè·ì‡óe

            'å©êœèÓïÒ **********************************
            B12()
            If Not IsDBNull(DtView2(0)("etmt_date")) Then Date004.Text = DtView2(0)("etmt_date")

            If Not IsDBNull(DtView2(0)("etmt_empl_name")) Then Combo_M001.Text = DtView2(0)("etmt_empl_name") Else Combo_M001.Text = Nothing
            If Not IsDBNull(DtView2(0)("tier_name")) Then Combo_M003.Text = DtView2(0)("tier_name") Else Combo_M003.Text = Nothing
            If CK_own_flg.Checked = True Then    'é©é–èCóù
                Edit_M001.Visible = False : Label_M01.Visible = False
            Else
                Edit_M001.Visible = True : Label_M01.Visible = True
                If Not IsDBNull(DtView2(0)("vndr_repr_no")) Then Edit_M001.Text = DtView2(0)("vndr_repr_no") Else Edit_M001.Text = Nothing
            End If

            If Not IsDBNull(DtView2(0)("etmt_meas")) Then Edit_M002.Text = DtView2(0)("etmt_meas") Else Edit_M002.Text = Nothing
            If Not IsDBNull(DtView2(0)("etmt_comn")) Then Edit_M003.Text = DtView2(0)("etmt_comn") Else Edit_M003.Text = Nothing

            If Not IsDBNull(DtView2(0)("tax_rate")) Then tax_rate.Text = DtView2(0)("tax_rate") Else tax_rate.Text = WK_tax
            If Not IsDBNull(DtView1(0)("calc_cls")) Then calc_cls.Text = DtView1(0)("calc_cls") Else calc_cls.Text = "1"

            Edit_M004.Enabled = True
            If Not IsDBNull(DtView2(0)("rsrv_cacl_comn")) Then Edit_M004.Text = DtView2(0)("rsrv_cacl_comn") Else Edit_M004.Text = Nothing

            If Not IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then Number031.Value = DtView2(0)("etmt_cost_tech_chrg") Else Number031.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_part_chrg")) Then Number033.Value = DtView2(0)("etmt_cost_part_chrg") Else Number033.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_fee")) Then Number034.Value = DtView2(0)("etmt_cost_fee") Else Number034.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_pstg")) Then Number035.Value = DtView2(0)("etmt_cost_pstg") Else Number035.Value = 0
            Number036.Value = Number031.Value + Number033.Value + Number034.Value + Number035.Value
            If Not IsDBNull(DtView2(0)("etmt_cost_tax")) Then Number037.Value = DtView2(0)("etmt_cost_tax") Else Number037.Value = 0
            Number038.Value = Number036.Value + Number037.Value
            If Not IsDBNull(DtView2(0)("etmt_shop_cxl")) Then Number019.Value = DtView2(0)("etmt_shop_cxl") Else Number019.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_cxl")) Then Number029.Value = DtView2(0)("etmt_eu_cxl") Else Number029.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_cxl")) Then Number039.Value = DtView2(0)("etmt_cost_cxl") Else Number039.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_apes")) Then Number032.Value = DtView2(0)("etmt_cost_apes") Else Number032.Value = 0

            If Not IsDBNull(DtView2(0)("etmt_shop_tech_chrg")) Then Number011.Value = DtView2(0)("etmt_shop_tech_chrg") Else Number011.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_apes")) Then Number012.Value = DtView2(0)("etmt_shop_apes") Else Number012.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_part_chrg")) Then Number013.Value = DtView2(0)("etmt_shop_part_chrg") Else Number013.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_fee")) Then Number014.Value = DtView2(0)("etmt_shop_fee") Else Number014.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_pstg")) Then Number015.Value = DtView2(0)("etmt_shop_pstg") Else Number015.Value = 0
            Number016.Value = Number011.Value + Number013.Value + Number014.Value + Number015.Value
            If Not IsDBNull(DtView2(0)("etmt_shop_tax")) Then Number017.Value = DtView2(0)("etmt_shop_tax") Else Number017.Value = 0
            Number018.Value = Number016.Value + Number017.Value

            If Not IsDBNull(DtView2(0)("etmt_eu_tech_chrg")) Then Number021.Value = DtView2(0)("etmt_eu_tech_chrg") Else Number021.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_apes")) Then Number022.Value = DtView2(0)("etmt_eu_apes") Else Number022.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_part_chrg")) Then Number023.Value = DtView2(0)("etmt_eu_part_chrg") Else Number023.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_fee")) Then Number024.Value = DtView2(0)("etmt_eu_fee") Else Number024.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_pstg")) Then Number025.Value = DtView2(0)("etmt_eu_pstg") Else Number025.Value = 0
            Number026.Value = Number021.Value + Number023.Value + Number024.Value + Number025.Value
            If Not IsDBNull(DtView2(0)("etmt_eu_tax")) Then Number027.Value = DtView2(0)("etmt_eu_tax") Else Number027.Value = 0
            Number028.Value = Number026.Value + Number027.Value

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

            'ë±çsï‘ãpèÓïÒ **********************************
            If Not IsDBNull(DtView2(0)("rsrv_cacl_date")) Then Date006.Text = DtView2(0)("rsrv_cacl_date")

            'äÆóπèÓïÒ **********************************
            B13()
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

            If Not IsDBNull(DtView3(0)("part_ordr_date")) Then Date007.Text = DtView3(0)("part_ordr_date")
            Date007.Enabled = True
            If Not IsDBNull(DtView3(0)("part_rcpt_date")) Then Date008.Text = DtView3(0)("part_rcpt_date")
            Date008.Enabled = True
            If Not IsDBNull(DtView3(0)("comp_date")) Then Date010.Text = DtView3(0)("comp_date")
            Date010.Enabled = True
            If Not IsDBNull(DtView3(0)("sals_date")) Then Date011.Text = DtView3(0)("sals_date")
            Date011.Enabled = True
            If Not IsDBNull(DtView3(0)("ship_date")) Then Date012.Text = DtView3(0)("ship_date")
            Date012.Enabled = True
            If Not IsDBNull(DtView3(0)("rqst_date")) Then Date013.Text = DtView3(0)("rqst_date")
            Edit903.Enabled = True
            If Not IsDBNull(DtView3(0)("sals_no")) Then Edit903.Text = DtView3(0)("sals_no")
            EDIT904.Enabled = True
            If Not IsDBNull(DtView3(0)("sals_no2")) Then EDIT904.Text = DtView3(0)("sals_no2")

            Combo_K001.Enabled = True
            If Not IsDBNull(DtView3(0)("repr_empl_name")) Then Combo_K001.Text = DtView3(0)("repr_empl_name") Else Combo_K001.Text = Nothing
            If Not IsDBNull(DtView3(0)("repr_empl_code")) Then CLK001.Text = DtView3(0)("repr_empl_code") Else CLK001.Text = Nothing
            If Not IsDBNull(DtView3(0)("repr_brch_code")) Then CLK001_BRH.Text = DtView3(0)("repr_brch_code") Else CLK001_BRH.Text = Nothing

            Combo_K002.Enabled = True
            If Not IsDBNull(DtView3(0)("select_case")) Then Combo_K002.Text = DtView3(0)("select_case") Else Combo_K002.Text = Nothing

            Combo_K003.Enabled = True
            If Not IsDBNull(DtView3(0)("kjo_brch_code")) Then
                CLK003.Text = DtView3(0)("kjo_brch_code")
                Combo_K003.Text = DtView3(0)("kjo_brch_name")
            Else
                If CK_own_flg.Checked = True Then   'é©é–èCóù
                    CLK003.Text = DtView1(0)("brch_code")
                Else
                    CLK003.Text = DtView1(0)("rcpt_brch_code")
                End If
                WK_DtView1 = New DataView(DsCMB0.Tables("M03_BRCH"), "brch_code = '" & CLK003.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Combo_K003.Text = WK_DtView1(0)("brch_name")
                End If
            End If
            Combo_K003_moto.Text = Combo_K003.Text

            Edit_K001.Enabled = True
            If Not IsDBNull(DtView3(0)("comp_meas")) Then Edit_K001.Text = DtView3(0)("comp_meas")
            Edit_K002.Enabled = True
            If Not IsDBNull(DtView3(0)("comp_comn")) Then Edit_K002.Text = DtView3(0)("comp_comn")

            If P_ACES_post_code >= "02" Then Number111.Enabled = True
            If P_ACES_post_code >= "02" Then Number113.Enabled = True
            Number114.Enabled = True
            Number115.Enabled = True
            If P_ACES_post_code >= "02" Then Number121.Enabled = True
            If P_ACES_post_code >= "02" Then Number123.Enabled = True
            Number124.Enabled = True
            Number125.Enabled = True
            If P_ACES_post_code >= "02" Then Number131.Enabled = True
            If P_ACES_post_code >= "02" Then Number133.Enabled = True
            Number134.Enabled = True
            Number135.Enabled = True

            If Not IsDBNull(DtView3(0)("comp_cost_tech_chrg")) Then Number131.Value = DtView3(0)("comp_cost_tech_chrg") Else Number131.Value = 0
            If Not IsDBNull(DtView3(0)("comp_cost_apes")) Then Number132.Value = DtView3(0)("comp_cost_apes") Else Number132.Value = 0
            If Not IsDBNull(DtView3(0)("comp_cost_part_chrg")) Then Number133.Value = DtView3(0)("comp_cost_part_chrg") Else Number133.Value = 0
            If Not IsDBNull(DtView3(0)("comp_cost_fee")) Then Number134.Value = DtView3(0)("comp_cost_fee") Else Number134.Value = 0
            If Not IsDBNull(DtView3(0)("comp_cost_pstg")) Then Number135.Value = DtView3(0)("comp_cost_pstg") Else Number135.Value = 0
            If Not IsDBNull(DtView3(0)("comp_cost_tax")) Then Number137.Value = DtView3(0)("comp_cost_tax") Else Number137.Value = 0
            If CK_own_flg.Checked = False Then Number132.Value = 0
            Number136.Value = Number131.Value + Number133.Value + Number134.Value + Number135.Value
            Number138.Value = Number136.Value + Number137.Value

            If Not IsDBNull(DtView3(0)("comp_shop_tech_chrg")) Then Number111.Value = DtView3(0)("comp_shop_tech_chrg") Else Number111.Value = 0
            If Not IsDBNull(DtView3(0)("comp_shop_apes")) Then Number112.Value = DtView3(0)("comp_shop_apes") Else Number112.Value = 0
            If Not IsDBNull(DtView3(0)("comp_shop_part_chrg")) Then Number113.Value = DtView3(0)("comp_shop_part_chrg") Else Number113.Value = 0
            If Not IsDBNull(DtView3(0)("comp_shop_fee")) Then Number114.Value = DtView3(0)("comp_shop_fee") Else Number114.Value = 0
            If Not IsDBNull(DtView3(0)("comp_shop_pstg")) Then Number115.Value = DtView3(0)("comp_shop_pstg") Else Number115.Value = 0
            If Not IsDBNull(DtView3(0)("comp_shop_tax")) Then Number117.Value = DtView3(0)("comp_shop_tax") Else Number117.Value = 0
            Number116.Value = Number111.Value + Number113.Value + Number114.Value + Number115.Value
            Number118.Value = Number116.Value + Number117.Value

            If Not IsDBNull(DtView3(0)("comp_eu_tech_chrg")) Then Number121.Value = DtView3(0)("comp_eu_tech_chrg") Else Number121.Value = 0
            If Not IsDBNull(DtView3(0)("comp_eu_apes")) Then Number122.Value = DtView3(0)("comp_eu_apes") Else Number122.Value = 0
            If Not IsDBNull(DtView3(0)("comp_eu_part_chrg")) Then Number123.Value = DtView3(0)("comp_eu_part_chrg") Else Number123.Value = 0
            If Not IsDBNull(DtView3(0)("comp_eu_fee")) Then Number124.Value = DtView3(0)("comp_eu_fee") Else Number124.Value = 0
            If Not IsDBNull(DtView3(0)("comp_eu_pstg")) Then Number125.Value = DtView3(0)("comp_eu_pstg") Else Number125.Value = 0
            If Not IsDBNull(DtView3(0)("comp_eu_tax")) Then Number127.Value = DtView3(0)("comp_eu_tax") Else Number127.Value = 0
            Number126.Value = Number121.Value + Number123.Value + Number124.Value + Number125.Value
            Number128.Value = Number126.Value + Number127.Value

            If Not IsDBNull(DtView3(0)("zero_code")) Then zero_code.Text = DtView3(0)("zero_code")
            If Not IsDBNull(DtView3(0)("zero_name")) Then zero_name.Text = DtView3(0)("zero_name")

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

            Combo006.Focus()

            Irregular() 'ÉCÉåÉMÉÖÉâÅ[èàóù
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub add_line(ByVal flg)
        Line_No = Line_No + 1

        'ëŒè€
        en = 1
        chkBox(Line_No, en) = New CheckBox
        chkBox(Line_No, en).Location = New System.Drawing.Point(5, 20 * Line_No + label(0, 0).Location.Y)
        chkBox(Line_No, en).Size = New System.Drawing.Size(25, 20)
        chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No, en).Text = Nothing
        If flg = "1" Then
            chkBox(Line_No, en).Checked = True
        Else
            chkBox(Line_No, en).Checked = False
        End If
        chkBox(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(chkBox(Line_No, en))
        AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
        AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

        'ïtëÆïi
        en = 1
        edit(Line_No, en) = New GrapeCity.Win.Input.Edit
        edit(Line_No, en).Location = New System.Drawing.Point(30, 20 * Line_No + label(0, 0).Location.Y)
        edit(Line_No, en).LengthAsByte = True
        edit(Line_No, en).MaxLength = 30
        edit(Line_No, en).LengthAsByte = True
        edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, en).Size = New System.Drawing.Size(150, 20)
        edit(Line_No, en).ImeMode = ImeMode.Hiragana
        edit(Line_No, en).HighlightText = True
        If flg = "1" Then
            edit(Line_No, en).Text = WK_DtView1(i)("item_name")
        Else
            edit(Line_No, en).Text = Nothing
        End If
        edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(edit(Line_No, en))
        AddHandler edit(Line_No, en).GotFocus, AddressOf edit1_GotFocus
        AddHandler edit(Line_No, en).LostFocus, AddressOf edit1_LostFocus

        'êîó 
        en = 1
        nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
        nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
        nbrBox(Line_No, en).HighlightText = True
        nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 20 * Line_No + label(0, 0).Location.Y)
        nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9, 0, 0, 0})
        nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).Size = New System.Drawing.Size(30, 20)
        If flg = "1" Then
            nbrBox(Line_No, en).Value = WK_DtView1(i)("amnt")
        Else
            nbrBox(Line_No, en).Value = 0
        End If
        nbrBox(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(nbrBox(Line_No, en))
        AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY_GotFocus
        AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY_LostFocus

        'íPà 
        en = 2
        edit(Line_No, en) = New GrapeCity.Win.Input.Edit
        edit(Line_No, en).Location = New System.Drawing.Point(210, 20 * Line_No + label(0, 0).Location.Y)
        edit(Line_No, en).LengthAsByte = True
        edit(Line_No, en).MaxLength = 10
        edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, en).Size = New System.Drawing.Size(50, 20)
        edit(Line_No, en).ImeMode = ImeMode.Hiragana
        edit(Line_No, en).Enabled = False
        If flg = "1" Then
            edit(Line_No, en).Text = WK_DtView1(i)("item_unit")
        Else
            edit(Line_No, en).Text = Nothing
        End If
        edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(edit(Line_No, en))

        'ïtëÆïiÉRÅ[Éh
        en = 1
        label(Line_No, en) = New Label
        label(Line_No, en).Location = New System.Drawing.Point(260, 20 * Line_No + label(0, 0).Location.Y)
        label(Line_No, en).Size = New System.Drawing.Size(0, 20)
        label(Line_No, en).Text = Nothing
        Panel_U1.Controls.Add(label(Line_No, en))

        'SEQ
        en = 2
        label(Line_No, en) = New Label
        label(Line_No, en).Location = New System.Drawing.Point(260, 20 * Line_No + label(0, 0).Location.Y)
        label(Line_No, en).Size = New System.Drawing.Size(10, 20)
        label(Line_No, en).Visible = False
        If flg = "1" Then label(Line_No, en).Text = WK_DtView1(i)("seq") Else label(Line_No, en).Text = Nothing
        Panel_U1.Controls.Add(label(Line_No, en))

        'ïtëÆïi
        en = 1
        edit_MOTO(Line_No, en) = New GrapeCity.Win.Input.Edit
        edit_MOTO(Line_No, en).Location = New System.Drawing.Point(270, 20 * Line_No + label(0, 0).Location.Y)
        edit_MOTO(Line_No, en).Size = New System.Drawing.Size(50, 20)
        edit_MOTO(Line_No, en).Enabled = False
        edit_MOTO(Line_No, en).Visible = False
        If flg = "1" Then
            edit_MOTO(Line_No, en).Text = WK_DtView1(i)("item_name")
        Else
            edit_MOTO(Line_No, en).Text = Nothing
        End If
        Panel_U1.Controls.Add(edit_MOTO(Line_No, en))

        'êîó 
        en = 1
        nbrBox_MOTO(Line_No, en) = New GrapeCity.Win.Input.Number
        nbrBox_MOTO(Line_No, en).Location = New System.Drawing.Point(320, 20 * Line_No + label(0, 0).Location.Y)
        nbrBox_MOTO(Line_No, en).Size = New System.Drawing.Size(30, 20)
        nbrBox_MOTO(Line_No, en).Enabled = False
        nbrBox_MOTO(Line_No, en).Visible = False
        If flg = "1" Then
            nbrBox_MOTO(Line_No, en).Value = WK_DtView1(i)("amnt")
        Else
            nbrBox_MOTO(Line_No, en).Value = 0
        End If
        Panel_U1.Controls.Add(nbrBox_MOTO(Line_No, en))

        'íPà 
        en = 2
        edit_MOTO(Line_No, en) = New GrapeCity.Win.Input.Edit
        edit_MOTO(Line_No, en).Location = New System.Drawing.Point(350, 20 * Line_No + label(0, 0).Location.Y)
        edit_MOTO(Line_No, en).Size = New System.Drawing.Size(50, 20)
        edit_MOTO(Line_No, en).Enabled = False
        edit_MOTO(Line_No, en).Visible = False
        If flg = "1" Then
            edit_MOTO(Line_No, en).Text = WK_DtView1(i)("item_unit")
        Else
            edit_MOTO(Line_No, en).Text = Nothing
        End If
        Panel_U1.Controls.Add(edit_MOTO(Line_No, en))

    End Sub

    'åÃè·ì‡óe
    Sub add_line_2(ByVal flg)
        DB_OPEN("nMVAR")
        Line_No2 = Line_No2 + 1

        'åÃè·ì‡óe
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL = strSQL & " FROM M10_CMNT"
        strSQL = strSQL & " WHERE (cls_code = '01') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY cmnt_code + ':' + cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsCMB, "M10_CMNT_1" & Line_No2)

        en = 1
        cmbBo_2(Line_No2, en) = New GrapeCity.Win.Input.Combo
        cmbBo_2(Line_No2, en).Location = New System.Drawing.Point(1, 20 * Line_No2 + label_2(0, 0).Location.Y)
        cmbBo_2(Line_No2, en).MaxDropDownItems = 30
        cmbBo_2(Line_No2, en).HighlightText = GrapeCity.Win.Input.HighlightText.Field
        cmbBo_2(Line_No2, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_2(Line_No2, en).Size = New System.Drawing.Size(498, 20)
        cmbBo_2(Line_No2, en).DataSource = WK_DsCMB.Tables("M10_CMNT_1" & Line_No2)
        cmbBo_2(Line_No2, en).AutoSelect = True
        cmbBo_2(Line_No2, en).DisplayMember = "cmnt"
        cmbBo_2(Line_No2, en).ValueMember = "cmnt_code"
        cmbBo_2(Line_No2, en).Tag = Line_No2
        Panel_U2.Controls.Add(cmbBo_2(Line_No2, en))
        AddHandler cmbBo_2(Line_No2, en).GotFocus, AddressOf cmb1_GotFocus
        AddHandler cmbBo_2(Line_No2, en).LostFocus, AddressOf cmb1_LostFocus
        cmbBo_2(Line_No2, en).Text = Nothing
        If flg = "1" Then
            If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
                cmbBo_2(Line_No2, en).Text = WK_DtView1(i)("cmnt_name1")
            End If
        End If

        'åÃè·ì‡óe∫∞ƒﬁ
        en = 1
        label_2(Line_No2, en) = New Label
        If flg = "1" Then
            If Not IsDBNull(WK_DtView1(i)("cmnt_code1")) Then
                label_2(Line_No2, en).Text = WK_DtView1(i)("cmnt_code1")
            Else
                label_2(Line_No2, en).Text = Nothing
            End If
        Else
            label_2(Line_No2, en).Text = Nothing
        End If
        label_2(Line_No2, en).Location = New System.Drawing.Point(500, 20 * Line_No2 + label_2(0, 0).Location.Y)
        label_2(Line_No2, en).Size = New System.Drawing.Size(50, 20)
        label_2(Line_No2, en).Visible = False
        Panel_U2.Controls.Add(label_2(Line_No2, en))

        'SEQ
        en = 2
        label_2(Line_No2, en) = New Label
        If flg = "1" Then
            label_2(Line_No2, en).Text = WK_DtView1(i)("seq")
        Else
            label_2(Line_No2, en).Text = Nothing
        End If
        label_2(Line_No2, en).Location = New System.Drawing.Point(550, 20 * Line_No2 + label_2(0, 0).Location.Y)
        label_2(Line_No2, en).Size = New System.Drawing.Size(50, 20)
        label_2(Line_No2, en).Visible = False
        Panel_U2.Controls.Add(label_2(Line_No2, en))

        DB_CLOSE()
    End Sub
    Sub add_line_3(ByVal flg)
        DB_OPEN("nMVAR")
        Line_No3 = Line_No3 + 1

        'å©êœì‡óe
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL = strSQL & " FROM M10_CMNT"
        strSQL = strSQL & " WHERE (cls_code = '11') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY cmnt_code + ':' + cmnt"
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
    ''å©êœì‡óe
    'Sub add_line_3()
    '    DB_OPEN("nMVAR")
    '    Line_No3 = Line_No3 + 1

    '    'å©êœì‡óe
    '    en = 1
    '    cmbBo_3(Line_No3, en) = New GrapeCity.Win.Input.Combo
    '    cmbBo_3(Line_No3, en).Location = New System.Drawing.Point(1, 20 * Line_No3)
    '    cmbBo_3(Line_No3, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
    '    cmbBo_3(Line_No3, en).Size = New System.Drawing.Size(465, 20)
    '    cmbBo_3(Line_No3, en).Enabled = False
    '    cmbBo_3(Line_No3, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
    '    Panel_M1.Controls.Add(cmbBo_3(Line_No3, en))
    '    If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
    '        cmbBo_3(Line_No3, en).Text = WK_DtView1(i)("cmnt_name1")
    '    Else
    '        cmbBo_3(Line_No3, en).Text = Nothing
    '    End If

    '    DB_CLOSE()
    'End Sub

    'èCóùì‡óe
    Sub add_line_4(ByVal flg)
        DB_OPEN("nMVAR")
        Line_No4 = Line_No4 + 1

        'èCóùì‡óe
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL = strSQL & " FROM M10_CMNT"
        strSQL = strSQL & " WHERE (cls_code = '21') AND (delt_flg = 0)"
        strSQL = strSQL & " ORDER BY cmnt_code + ':' + cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsCMB4, "M10_CMNT_4" & Line_No4)

        en = 1
        cmbBo_4(Line_No4, en) = New GrapeCity.Win.Input.Combo
        cmbBo_4(Line_No4, en).Location = New System.Drawing.Point(1, 20 * Line_No4 + label_4(0, 0).Location.Y)
        cmbBo_4(Line_No4, en).MaxDropDownItems = 30
        cmbBo_4(Line_No4, en).HighlightText = GrapeCity.Win.Input.HighlightText.Field
        cmbBo_4(Line_No4, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** éÛïtâÊñ 
    '********************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        B11()
    End Sub
    Sub B11()
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
        B12()
    End Sub
    Sub B12()
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
        B13()
    End Sub
    Sub B13()
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
                    WK_amt3 = WK_amt3 + WK_DtView3(i)("part_amnt") * WK_DtView3(i)("use_qty")
                    WK_amt1 = WK_amt1 + WK_DtView3(i)("shop_chrg")
                    WK_amt2 = WK_amt2 + WK_DtView3(i)("eu_chrg")
                Next
            End If
            Number033.Value = WK_amt3
            Number013.Value = WK_amt1
            Number023.Value = WK_amt2

        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

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
                    WK_amt3 = WK_amt3 + WK_DtView3(i)("part_amnt") * WK_DtView3(i)("use_qty")
                    WK_amt1 = WK_amt1 + WK_DtView3(i)("shop_chrg")
                    WK_amt2 = WK_amt2 + WK_DtView3(i)("eu_chrg")
                Next
            End If
            Number133.Value = WK_amt3
            Number113.Value = WK_amt1
            Number123.Value = WK_amt2
        End If

        'If P_RTN = "1" Then
        '    Number133.Value = 0
        '    WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "", "seq", DataViewRowState.CurrentRows)
        '    If WK_DtView1.Count <> 0 Then
        '        For i = 0 To WK_DtView1.Count - 1
        '            Number133.Value = Number133.Value + WK_DtView1(i)("part_amnt") * WK_DtView1(i)("use_qty")
        '        Next
        '    End If
        'End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  çÄñ⁄É`ÉFÉbÉN
    '********************************************************************
    Sub CHK_Combo006()   'éÛïtíSìñ
        msg.Text = Nothing

        Combo006.Text = Trim(Combo006.Text)
        If Combo006.Text = Nothing Then
            Combo006.BackColor = System.Drawing.Color.Red
            msg.Text = "éÛïtíSìñÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB0.Tables("M01_EMPL_006"), "name = '" & Combo006.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo006.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈéÛïtíSìñÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL006.Text = DtView1(0)("empl_code")
            End If
        End If
        Combo006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo007()   'éÛïtãíì_
        msg.Text = Nothing

        Combo007.Text = Trim(Combo007.Text)
        If Combo007.Text = Nothing Then
            Combo007.BackColor = System.Drawing.Color.Red
            msg.Text = "éÛïtãíì_Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB0.Tables("M03_BRCH_007"), "brch_name = '" & Combo007.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo007.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈãíì_Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL003.Text = WK_DtView1(0)("brch_code")
            End If
        End If
        Combo007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo001()   'éÛïtéÌï 
        msg.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            Combo001.BackColor = System.Drawing.Color.Red
            msg.Text = "éÛïtéÌï Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB0.Tables("CLS_CODE_007"), "cls_code_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈéÛïtéÌï Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL001.Text = DtView1(0)("cls_code")
                If DtView1(0)("cls_code_name_abbr") = "QGNo" Then
                    Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True 'QG No
                    Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
                    Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
                Else
                    Label21.Visible = False : Edit011.Visible = False : Label5.Visible = False 'QG No
                    Label10.Visible = False : Number001_nTax.Visible = False : Label16.Visible = False
                    Label15.Visible = False : Number003.Visible = False : Label17.Visible = False
                End If
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit011()   'QG Care No
        msg.Text = Nothing
        Edit011.BackColor = System.Drawing.SystemColors.Window

        If Edit011.Visible = True Then
            Edit011.Text = Trim(Edit011.Text)
            If Edit011.Text = Nothing Then
                Edit011.BackColor = System.Drawing.Color.Red
                msg.Text = "QG Care NoÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            Else
                '******************
                'QG ÉfÅ[É^åüçı
                '******************
                'ë∂ç›¡™Ø∏
                WK_DsList1.Clear()
                strSQL = "SELECT *"
                strSQL = strSQL & " FROM T01_â¡ì¸é“ LEFT OUTER JOIN"
                strSQL = strSQL & " (SELECT [ÉRÅ[Éh] AS HSY_code, ñºèÃ AS HSY_name FROM [M_ÉeÅ[ÉuÉã] WHERE (éØï  = N'HSY')) HSY ON"
                strSQL = strSQL & " T01_â¡ì¸é“.ï€èÿîÕàÕ = HSY.HSY_code"
                strSQL = strSQL & " WHERE (T01_â¡ì¸é“.â¡ì¸î‘çÜ = '" & Edit011.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("QGCare")
                DaList1.Fill(WK_DsList1, "T01_â¡ì¸é“")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_â¡ì¸é“"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Edit011.BackColor = System.Drawing.Color.Red
                    msg.Text = "â¡ì¸ÉfÅ[É^Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                    GoTo tab
                End If
            End If
        End If
tab:
    End Sub
    Sub CHK_Combo002()   'ì¸â◊ãÊï™
        msg.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            Combo002.BackColor = System.Drawing.Color.Red
            msg.Text = "ì¸â◊ãÊï™Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB0.Tables("CLS_CODE_018"), "cls_code_name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈì¸â◊ãÊï™Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL002.Text = DtView1(0)("cls_code")
                CL002_2.Text = DtView1(0)("cls_code_name_abbr")
                If DtView1(0)("cls_code_name_abbr") = "àÍî " Then
                    'îÃé–îÒï\é¶
                    Label004.Visible = False : Edit003.Visible = False : Edit003.Text = Nothing
                    Label006.Text = "ÉOÉãÅ[Évî‘çÜ"
                    Label007.Visible = False : Date001.Visible = False : Date001.Text = Nothing
                    If Edit001.Text = Nothing Then
                        WK_DsList1.Clear()
                        strSQL = "SELECT store_code FROM M08_STORE WHERE (delt_flg = 0) AND (idvd_flg = 1)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        DaList1.Fill(WK_DsList1, "M08_STORE")
                        DB_CLOSE()
                        WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count <> 0 Then
                            Edit001.Text = WK_DtView1(0)("store_code")
                            CHK_Edit001()   'îÃé–
                        End If
                    End If
                Else                                    'îÃé–
                    'îÃé–ï\é¶
                    Label004.Visible = True : Edit003.Visible = True
                    Label006.Text = "îÃé–èCóùî‘çÜ"
                    Label007.Visible = True : Date001.Visible = True
                End If
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo003()   'ì¸â◊íSìñ
        msg.Text = Nothing

        Combo003.Text = Trim(Combo003.Text)
        If Combo003.Text = Nothing Then
            Combo003.BackColor = System.Drawing.Color.Red
            msg.Text = "ì¸â◊íSìñÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB0.Tables("M01_EMPL_003"), "name = '" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo003.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈì¸â◊íSìñÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL003.Text = DtView1(0)("empl_code")
            End If
        End If
        Combo003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit001()   'îÃé–
        msg.Text = Nothing
        Label001.Text = Nothing
        Edit002.Text = Nothing
        Label002.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "îÃé–Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT M08_STORE.store_code, M08_STORE.name, M08_STORE.dlvr_code, M08_STORE_1.name AS dlvr_name"
            strSQL = strSQL & ", M08_STORE.tech_rate, M08_STORE.tech_mrgn_rate, M08_STORE.part_mrgn_rate"
            strSQL = strSQL & " FROM M08_STORE LEFT OUTER JOIN"
            strSQL = strSQL & " M08_STORE M08_STORE_1 ON"
            strSQL = strSQL & " M08_STORE.dlvr_code = M08_STORE_1.store_code"
            strSQL = strSQL & " WHERE (M08_STORE.store_code = '" & Edit001.Text & "')"
            strSQL = strSQL & " AND (M08_STORE.delt_flg = 0)"
            If CL002_2.Text = "àÍî " Then
                strSQL = strSQL & " AND (M08_STORE.idvd_flg = 1)"
            Else
                strSQL = strSQL & " AND (M08_STORE.idvd_flg = 0)"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "M08_STORE")
            DB_CLOSE()

            WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈîÃé–Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                Label001.Text = WK_DtView1(0)("name")
                Edit002.Text = WK_DtView1(0)("dlvr_code")
                Label002.Text = WK_DtView1(0)("dlvr_name")
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit003()   'îÃé–íSìñé“
        msg.Text = Nothing

        If Edit003.Visible = True Then
            Edit003.Text = Trim(Edit003.Text)
        Else
            Edit003.Text = Nothing
        End If
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit004()   'îÃé–èCóùî‘çÜÅiÉOÉãÅ[Évî‘çÜÅj
        msg.Text = Nothing
        Edit004.BackColor = System.Drawing.SystemColors.Window

        Edit004.Text = Trim(Edit004.Text)
        If Edit004.Text <> Nothing Then
            If CL002_2.Text = "àÍî " Then
                If Edit000.Text = Edit004.Text Then GoTo tab
                WK_DsList1.Clear()
                strSQL = "SELECT * FROM T01_REP_MTR"
                strSQL = strSQL & " WHERE (store_repr_no = rcpt_no)"
                strSQL = strSQL & " AND (rcpt_no = '" & Edit004.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Edit004.BackColor = System.Drawing.Color.Red
                    msg.Text = "äYìñÇ∑ÇÈÉOÉãÅ[Évî‘çÜÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                    GoTo tab
                End If
            End If
        Else
            If CL002_2.Text = "àÍî " Then
                Edit004.Text = Edit000.Text
            End If
        End If
tab:
    End Sub
    Sub CHK_Date001()   'îÃé–éÛïtì˙
        msg.Text = Nothing

        If Date001.Visible = True Then
            If Date001.Number = 0 Then
                If Number001.Value <> 0 Or CL004.Text > "01" Then
                    Date001.BackColor = System.Drawing.Color.Red
                    msg.Text = "îÃé–éÛïtì˙Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            Else
                If Date001.Text > Date003.Text Then
                    Date001.BackColor = System.Drawing.Color.Red
                    msg.Text = "îÃé–éÛïtì˙ÅÑéÛïtì˙ÉGÉâÅ[ÅB"
                    Exit Sub
                End If
            End If
        Else
            Date001.Text = Nothing
        End If
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit005()   'Ç®ãqólñº
        msg.Text = Nothing

        Edit005.Text = Trim(Edit005.Text)
        If Edit005.Text = Nothing Then
            Edit005.BackColor = System.Drawing.Color.Red
            msg.Text = "Ç®ãqólñºÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        End If
        If Edit005.ReadOnly = False Then
            Edit005.BackColor = System.Drawing.SystemColors.Window
        Else
            Edit005.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
    Sub CHK_Mask1()     'óXï÷î‘çÜ
        msg.Text = Nothing

        If Mask1.Value = Nothing Then
        Else
            If Len(Mask1.Value) <> 7 Then
                Mask1.BackColor = System.Drawing.Color.Red
                msg.Text = "óXï÷î‘çÜÇÕ7åÖì¸óÕÇµÇƒÇ≠ÇæÇ≥Ç¢ÅB"
                Exit Sub
            End If
        End If
        Mask1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo004()   'èCóùéÌï 
        msg.Text = Nothing

        Combo004.Text = Trim(Combo004.Text)
        If Combo004.Text = Nothing Then
            Combo004.BackColor = System.Drawing.Color.Red
            msg.Text = "èCóùéÌï Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB0.Tables("CLS_CODE_001"), "cls_code_name = '" & Combo004.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo004.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈèCóùéÌï Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL004.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo005()   'éñåÃèÛãµ
        msg.Text = Nothing
        CL005.Text = Nothing
        Number003.Value = 0

        Combo005.Text = Trim(Combo005.Text)
        If Combo005.Text = Nothing Then
            If Edit011.Visible = True Then
                Combo005.BackColor = System.Drawing.Color.Red
                msg.Text = "éñåÃèÛãµÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        Else
            DtView1 = New DataView(DsCMB0.Tables("CLS_CODE_022"), "cls_code_name = '" & Combo005.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo005.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈéñåÃèÛãµÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CL005.Text = DtView1(0)("cls_code")
                Number003.Value = DtView1(0)("cls_code_name_abbr")
            End If
        End If
        Combo005.BackColor = System.Drawing.SystemColors.Window
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
    Sub CHK_Combo_U001()   'ÉÅÅ[ÉJÅ[
        msg.Text = Nothing
        cmb_reset = "0"

        Combo_U001.Text = Trim(Combo_U001.Text)
        If Combo_U001.Text = Nothing Then
            Combo_U001.BackColor = System.Drawing.Color.Red
            msg.Text = "ÉÅÅ[ÉJÅ[Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB0.Tables("M05_VNDR"), "name = '" & Combo_U001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo_U001.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈÉÅÅ[ÉJÅ[Ç™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                If CLU001.Text <> DtView1(0)("vndr_code") Then
                    cmb_reset = "1"
                    CLU001.Text = DtView1(0)("vndr_code")
                    If CLU001.Text = "01" Then
                        CheckBox_U001.Text = "íËäzèCóù"
                    Else
                        CheckBox_U001.Text = "ÇmÇèÇîÇÖ"
                    End If
                End If
            End If
        End If
        Combo_U001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U001()   'ÉÇÉfÉã
        msg.Text = Nothing

        Edit_U001.Text = Trim(Edit_U001.Text)
        If Edit_U001.Text = Nothing Then
            Edit_U001.BackColor = System.Drawing.Color.Red
            msg.Text = "ÉÇÉfÉãÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        End If
        Edit_U001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U002()   'ã@éÌ
        msg.Text = Nothing

        Edit_U002.Text = Trim(Edit_U002.Text)
        If Edit_U002.Text = Nothing Then
            Edit_U002.BackColor = System.Drawing.Color.Red
            msg.Text = "ã@éÌÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        End If
        Edit_U002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U003()   'S/N
        msg.Text = Nothing
        Edit_U003.BackColor = System.Drawing.SystemColors.Window

        Edit_U003.Text = Trim(Edit_U003.Text)
        If Edit_U003.Text = Nothing Then
            Edit_U003.BackColor = System.Drawing.Color.Red
            msg.Text = "S/NÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
        End If
    End Sub
    Sub CHK_Combo_U002()   'èCóùïîèê
        msg.Text = Nothing

        Combo_U002.Text = Trim(Combo_U002.Text)
        If Combo_U002.Text = Nothing Then
            Combo_U002.BackColor = System.Drawing.Color.Red
            msg.Text = "èCóùïîèêÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB0.Tables("M06_RPAR_COMP"), "name = '" & Combo_U002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo_U002.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈèCóùïîèêÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLU002.Text = DtView1(0)("rpar_comp_code")
            End If
        End If
        Combo_U002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date_U001()   'çwì¸ì˙
        msg.Text = Nothing

        If Date_U001.Number = 0 Then
            'Date_U001.BackColor = System.Drawing.Color.Red
            'msg.Text = "çwì¸ì˙ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            'Exit Sub
        Else
            Select Case Date_U001.Text
                Case Is > Now.Date  'ñ¢óàì˙ït
                    Date_U001.BackColor = System.Drawing.Color.Red
                    msg.Text = "çwì¸ì˙Ç…ñ¢óàì˙ïtÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
            End Select
        End If
        Date_U001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date_U002()   'ÉÅÅ[ÉJÅ[ï€èÿäJénì˙
        msg.Text = Nothing

        If Date_U002.Number = 0 Then
            If CL004.Text = "02" Then
                If CheckBox_U002.Checked = False Then
                    Date_U002.BackColor = System.Drawing.Color.Red
                    msg.Text = "ÉÅÅ[ÉJÅ[ï€èÿäJénì˙Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If
        Else
            Select Case Date_U002.Text
                Case Is > Now.Date  'ñ¢óàì˙ït
                    Date_U002.BackColor = System.Drawing.Color.Red
                    msg.Text = "ÉÅÅ[ÉJÅ[ï€èÿäJénì˙Ç…ñ¢óàì˙ïtÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
            End Select
        End If
        Date_U002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date_U003()   'éñåÃì˙
        msg.Text = Nothing

        If Date_U003.Number = 0 Then
            If Edit011.Visible = True Then 'Or CL004.Text > "01" Then
                Date_U003.BackColor = System.Drawing.Color.Red
                msg.Text = "éñåÃì˙Ç™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        Else
            Select Case Date_U003.Text
                Case Is > Now.Date  'ñ¢óàì˙ït
                    Date_U003.BackColor = System.Drawing.Color.Red
                    msg.Text = "éñåÃì˙Ç…ñ¢óàì˙ïtÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                    Exit Sub
            End Select

            If Number001.Value <> 0 And Date001.Number <> 0 Then
                If Date001.Visible = True Then
                    If DateAdd(DateInterval.Month, 2, CDate(Date_U003.Text)) <= Date001.Text Then
                        Date_U003.BackColor = System.Drawing.Color.Red
                        msg.Text = "îÃé–éÛïtì˙ÇÊÇË2Éñåéà»è„ëOÇÃéñåÃì˙ÇÕéÛïtÇ≈Ç´Ç‹ÇπÇÒÅB"
                        Exit Sub
                    End If
                Else
                    If DateAdd(DateInterval.Month, 2, CDate(Date_U003.Text)) <= Date003.Text Then
                        Date_U003.BackColor = System.Drawing.Color.Red
                        msg.Text = "éÛïtì˙ÇÊÇË2Éñåéà»è„ëOÇÃéñåÃì˙ÇÕéÛïtÇ≈Ç´Ç‹ÇπÇÒÅB"
                        Exit Sub
                    End If
                End If
            End If

        End If
        Date_U003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_fuzoku_name(ByVal seq As Integer) 'ïtëÆïiñº
        msg.Text = Nothing

        edit(seq, 1).Text = Trim(edit(seq, 1).Text)
        If chkBox(seq, 1).Checked = True Then
            If edit(seq, 1).Text = Nothing Then
                edit(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "ïtëÆïiñºÇÃì¸óÕÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            End If
        Else
            If edit(seq, 1).Text <> Nothing Then
                edit(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "ëŒè€Ç…Ç»Ç¡ÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        edit(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_fuzoku_QTY(ByVal seq As Integer) 'ïtëÆêîó 
        msg.Text = Nothing

        If Trim(edit(seq, 2).Text) <> Nothing Then   'íPà 
            If chkBox(seq, 1).Checked = True Then
                If nbrBox(seq, 1).Value = 0 Then
                    nbrBox(seq, 1).BackColor = System.Drawing.Color.Red
                    msg.Text = "êîó ÇÃì¸óÕÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                    Exit Sub
                End If
            Else
                If nbrBox(seq, 1).Value <> 0 Then
                    nbrBox(seq, 1).BackColor = System.Drawing.Color.Red
                    msg.Text = "ëŒè€Ç…Ç»Ç¡ÇƒÇ¢Ç‹ÇπÇÒÅB"
                    Exit Sub
                End If
            End If
        End If
        nbrBox(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_cmnt1(ByVal seq As Integer) 'åÃè·â”èä
        msg.Text = Nothing

        cmbBo_2(seq, 1).Text = Trim(cmbBo_2(seq, 1).Text)
        If cmbBo_2(seq, 1).Text = Nothing Then
        Else
            WK_DtView1 = New DataView(WK_DsCMB.Tables("M10_CMNT_1" & seq), "cmnt ='" & cmbBo_2(seq, 1).Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                cmbBo_2(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈåÃè·ì‡óeÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                label_2(seq, 1).Text = WK_DtView1(0)("cmnt_code")
            End If
        End If
        cmbBo_2(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U004()   'åÃè·ì‡óe
        msg.Text = Nothing

        Edit_U004.Text = Trim(Edit_U004.Text)
        If Edit_U004.Text = Nothing Then
            'Edit_U004.BackColor = System.Drawing.Color.Red
            'msg.Text = "åÃè·ì‡óeÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_U004.Text)
            If P_Line > 9 Then
                Edit_U004.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_U004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U005()   'åÃè·ÉRÉÅÉìÉg
        msg.Text = Nothing

        Edit_U005.Text = Trim(Edit_U005.Text)
        If Edit_U005.Text = Nothing Then
            'Edit_U005.BackColor = System.Drawing.Color.Red
            'msg.Text = "åÃè·ÉRÉÅÉìÉgÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_U005.Text)
            If P_Line > 9 Then
                Edit_U005.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_U005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_M001()   'å©êœíSìñ
        msg.Text = Nothing

        Combo_M001.Text = Trim(Combo_M001.Text)
        If Combo_M001.Text = Nothing Then
            Combo_M001.BackColor = System.Drawing.Color.Red
            msg.Text = "å©êœíSìñÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB0.Tables("M01_EMPL_M001"), "name = '" & Combo_M001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo_M001.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈå©êœíSìñÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLM001.Text = WK_DtView1(0)("empl_code")
            End If
        End If
        Combo_M001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_M003()   'ìÔà’ìx
        msg.Text = Nothing

        If Combo_M003.Visible = True Then
            Combo_M003.Text = Trim(Combo_M003.Text)
            If Combo_M003.Text = Nothing Then
                Combo_M003.BackColor = System.Drawing.Color.Red
                msg.Text = "ìÔà’ìxÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
                Exit Sub
            Else
                WK_DtView1 = New DataView(DsCMB0.Tables("CLS_CODE_013"), "cls_code_name = '" & Combo_M003.Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Combo_M003.BackColor = System.Drawing.Color.Red
                    msg.Text = "äYìñÇ∑ÇÈìÔà’ìxÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                    Exit Sub
                Else
                    CLM003.Text = WK_DtView1(0)("cls_code")
                End If
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
    Sub CHK_Combo_K001()   'èCóùíSìñ
        msg.Text = Nothing
        CLK001.Text = Nothing
        CLK001_BRH.Text = Nothing

        Combo_K001.Text = Trim(Combo_K001.Text)
        If Combo_K001.Text = Nothing Then
            Combo_K001.BackColor = System.Drawing.Color.Red
            msg.Text = "èCóùíSìñÇ™ì¸óÕÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB0.Tables("M01_EMPL_K001"), "name = '" & Combo_K001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo_K001.BackColor = System.Drawing.Color.Red
                msg.Text = "äYìñÇ∑ÇÈèCóùíSìñÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
                Exit Sub
            Else
                CLK001.Text = WK_DtView1(0)("empl_code")
                If Not IsDBNull(WK_DtView1(0)("brch_code")) Then CLK001_BRH.Text = WK_DtView1(0)("brch_code")
            End If
        End If
        Combo_K001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_K002()   'ÉÅÅ[ÉJÅ[ï€èÿ ãZèpóø
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
                    Number131.Value = WK_DtView1(0)("tech_amnt")
                End If
            End If
        End If
        Combo_K002.BackColor = System.Drawing.SystemColors.Window
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
            If P_Line > 9 Then
                Edit_K001.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
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
            If P_Line > 9 Then
                Edit_K002.BackColor = System.Drawing.Color.Red
                msg.Text = "ÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
                Exit Sub
            End If
        End If
        Edit_K002.BackColor = System.Drawing.SystemColors.Window
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
            WK_DtView1 = New DataView(DsCMB0.Tables("M03_BRCH"), "brch_name = '" & Combo_K003.Text & "'", "", DataViewRowState.CurrentRows)
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

    Sub F_Check()
        Err_F = "0"

        CHK_Combo006()   'éÛïtíSìñ
        If msg.Text <> Nothing Then Err_F = "1" : Combo006.Focus() : Exit Sub

        CHK_Combo007()   'éÛïtãíì_
        If msg.Text <> Nothing Then Err_F = "1" : Combo007.Focus() : Exit Sub

        CHK_Combo001()   'éÛïtéÌï 
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Edit011()   'QG Care No
        If msg.Text <> Nothing Then Err_F = "1" : Edit011.Focus() : Exit Sub

        CHK_Combo002()   'ì¸â◊ãÊï™
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Combo003()   'ì¸â◊íSìñ
        If msg.Text <> Nothing Then Err_F = "1" : Combo003.Focus() : Exit Sub

        CHK_Edit001()   'îÃé–
        If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub

        CHK_Edit003()   'îÃé–íSìñé“
        If msg.Text <> Nothing Then Err_F = "1" : Edit003.Focus() : Exit Sub

        CHK_Edit004()   'îÃé–èCóùî‘çÜÅiÉOÉãÅ[Évî‘çÜÅj
        If msg.Text <> Nothing Then Err_F = "1" : Edit004.Focus() : Exit Sub

        CHK_Date001()   'îÃé–éÛïtì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date001.Focus() : Exit Sub

        CHK_Edit005()   'Ç®ãqólñº
        If msg.Text <> Nothing Then Err_F = "1" : Edit005.Focus() : Exit Sub

        CHK_Mask1()     'óXï÷î‘çÜ
        If msg.Text <> Nothing Then Err_F = "1" : Mask1.Focus() : Exit Sub

        CHK_Combo004()   'èCóùéÌï 
        If msg.Text <> Nothing Then Err_F = "1" : Combo004.Focus() : Exit Sub

        CHK_Combo005()   'éñåÃèÛãµ
        If msg.Text <> Nothing Then Err_F = "1" : Combo005.Focus() : Exit Sub

        CHK_Edit012()   'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        If msg.Text <> Nothing Then Err_F = "1" : Edit012.Focus() : Exit Sub

        CHK_Combo_U001()   'ÉÅÅ[ÉJÅ[
        If msg.Text <> Nothing Then Err_F = "1" : Combo_U001.Focus() : Exit Sub

        CHK_Edit_U001()   'ÉÇÉfÉã
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U001.Focus() : Exit Sub

        CHK_Edit_U002()   'ã@éÌ
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U002.Focus() : Exit Sub

        CHK_Edit_U003()   'S/N
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U003.Focus() : Exit Sub

        CHK_Combo_U002()   'èCóùïîèê
        If msg.Text <> Nothing Then Err_F = "1" : Combo_U002.Focus() : Exit Sub

        CHK_Date_U001()   'çwì¸ì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date_U001.Focus() : Exit Sub

        CHK_Date_U002()   'ÉÅÅ[ÉJÅ[ï€èÿäJénì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date_U002.Focus() : Exit Sub

        CHK_Date_U003()   'éñåÃì˙
        If msg.Text <> Nothing Then Err_F = "1" : Date_U003.Focus() : Exit Sub

        'ïtëÆïi
        For i = 0 To Line_No
            If label(i, 1).Text <> Nothing Then

                If edit(i, 2).Text <> Nothing Then
                    CHK_fuzoku_QTY(i)   'ïtëÆêîó 
                    If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 1).Focus() : Exit Sub
                End If

            Else            'Ãÿ∞ì¸óÕ

                CHK_fuzoku_name(i)  'ïtëÆïiñº
                If msg.Text <> Nothing Then Err_F = "1" : edit(i, 1).Focus() : Exit Sub

                CHK_fuzoku_QTY(i)   'ïtëÆêîó 
                If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 1).Focus() : Exit Sub
            End If
        Next

        'åÃè·ì‡óe
        seq = 0
        For i = 0 To Line_No2

            CHK_cmnt1(i) 'åÃè·ì‡óe
            If msg.Text <> Nothing Then Err_F = "1" : cmbBo_2(i, 1).Focus() : Exit Sub

            If cmbBo_2(i, 1).Text <> Nothing Then
                seq = seq + 1
            End If
        Next

        CHK_Edit_U004()   'åÃè·ì‡óe
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U004.Focus() : Exit Sub

        CHK_Edit_U005()   'åÃè·ÉRÉÅÉìÉg
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U005.Focus() : Exit Sub

        CHK_Combo_M001()   'å©êœíSìñ
        If msg.Text <> Nothing Then Err_F = "1" : Combo_M001.Focus() : Exit Sub

        CHK_Combo_M003()   'ìÔà’ìx
        If msg.Text <> Nothing Then Err_F = "1" : Combo_M003.Focus() : Exit Sub

        CHK_Edit_M001()   'ÉÅÅ[ÉJÅ[èCóùî‘çÜ
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

        CHK_Combo_K001()    'èCóùíSìñ
        If msg.Text <> Nothing Then Err_F = "1" : Combo_K001.Focus() : Exit Sub

        CHK_Combo_K002()    'ÉÅÅ[ÉJÅ[ï€èÿãZèpóø
        If msg.Text <> Nothing Then Err_F = "1" : Combo_K002.Focus() : Exit Sub

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

        If seq > 9 Then
            Edit_K001.BackColor = System.Drawing.Color.Red
            msg.Text = "èCóùì‡óeÇÃëIëçÄñ⁄Ç∆ÉtÉäÅ[ì¸óÕÇ≈çáåvÇXçsà»è„ÇÃì¸óÕÇÕÇ≈Ç´Ç‹ÇπÇÒÅB"
            Err_F = "1" : Edit_K001.Focus() : Exit Sub
        End If

        CHK_Number112() 'APSE
        If msg.Text <> Nothing Then Err_F = "1" : Number112.Focus() : Exit Sub

        CHK_Combo_K003() 'åvè„QG
        If msg.Text <> Nothing Then Err_F = "1" : Combo_K003.Focus() : Exit Sub

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
    '**  èCóùïîèêÇrÇdÇs
    '********************************************************************
    Sub rpar_comp()
        DsCMB0.Tables("M06_RPAR_COMP").Clear()
        strSQL = "SELECT M07_RPAR_COMP_SCAN.rpar_comp_code, M07_RPAR_COMP_SCAN.rpar_comp_code + ':' + M06_RPAR_COMP.name AS name"
        strSQL = strSQL & " FROM M07_RPAR_COMP_SCAN INNER JOIN"
        strSQL = strSQL & " M06_RPAR_COMP ON"
        strSQL = strSQL & " M07_RPAR_COMP_SCAN.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code LEFT"
        strSQL = strSQL & " OUTER JOIN"
        strSQL = strSQL & " M03_BRCH ON M06_RPAR_COMP.brch_code = M03_BRCH.brch_code"
        strSQL = strSQL & " WHERE (M06_RPAR_COMP.delt_flg = 0)"
        strSQL = strSQL & " AND (M07_RPAR_COMP_SCAN.vndr_code = '" & CLU001.Text & "')"
        strSQL = strSQL & " AND (M07_RPAR_COMP_SCAN.area_code = '" & P_area_code & "')"
        strSQL = strSQL & " AND (M03_BRCH.comp_code = '" & P_comp_code & "' OR M03_BRCH.comp_code IS NULL)"
        strSQL = strSQL & " ORDER BY M06_RPAR_COMP.own_flg DESC, M06_RPAR_COMP.name_kana, M06_RPAR_COMP.rpar_comp_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB0, "M06_RPAR_COMP")
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  îÒï\é¶ÇÃçÄñ⁄ÇÕÉNÉäÉAÇ∑ÇÈ
    '********************************************************************
    Sub NoDsp_Null()
        'If Combo_K001.Visible = False Then Combo_K001.Text = Nothing
        'If Combo_K001.Visible = False Then CLK001.Text = Nothing
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
    Private Sub Edit001_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.GotFocus
        Edit004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.GotFocus
        If Edit005.ReadOnly = False Then
            Edit005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        End If
    End Sub
    Private Sub Edit006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.GotFocus
        Edit006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.GotFocus
        Edit007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit008_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.GotFocus
        Edit008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit009_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit009.GotFocus
        Edit009.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit010_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit010.GotFocus
        Edit010.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit011_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit011.GotFocus
        Edit011.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit012_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.GotFocus
        Edit012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit013_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit013.GotFocus
        Edit013.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
        Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.GotFocus
        Combo002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.GotFocus
        Combo003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo004.GotFocus
        Combo004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo005.GotFocus
        Combo005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo006.GotFocus
        Combo006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo007.GotFocus
        Combo007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.GotFocus
        Date001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date003.GotFocus
        Date003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date004.GotFocus
        Date004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Date013_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date013.GotFocus
        Date013.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number001_nTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001_nTax.GotFocus
        Number001_nTax.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.GotFocus
        Number002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number003.GotFocus
        Number003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Mask1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mask1.GotFocus
        Mask1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit903_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit903.GotFocus
        Edit903.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit904_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EDIT904.GotFocus
        EDIT904.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        CHK_Edit003()   'îÃé–íSìñé“
    End Sub
    Private Sub Edit004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.LostFocus
        CHK_Edit004()   'îÃé–èCóùî‘çÜÅiÉOÉãÅ[Évî‘çÜÅj
    End Sub
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        CHK_Date001()   'îÃé–éÛïtì˙
    End Sub
    Private Sub Edit013_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit013.LostFocus
        Edit013.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub CheckBox_U001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U001.GotFocus
        CheckBox_U001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox_U002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U002.GotFocus
        CheckBox_U002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_U001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_U001.GotFocus
        Combo_U001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_U002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_U002.GotFocus
        Combo_U002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date_U001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U001.GotFocus
        Date_U001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date_U002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U002.GotFocus
        Date_U002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date_U003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U003.GotFocus
        Date_U003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_U001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U001.GotFocus
        Edit_U001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_U002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U002.GotFocus
        Edit_U002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_U003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U003.GotFocus
        Edit_U003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_U004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U004.GotFocus
        Edit_U004.ImeMode = ImeMode.Hiragana
        Edit_U004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_U005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U005.GotFocus
        Edit_U005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Edit)
        edit(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub QTY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Number
        Lin = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub cmb1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        cmbBo_2(cmb.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Edit_M004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M004.GotFocus
        Edit_M004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Combo_K001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K001.GotFocus
        Combo_K001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_K002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K002.GotFocus
        Combo_K002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub cmb4_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        cmbBo_4(cmb.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_K001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K001.GotFocus
        Edit_K001.ImeMode = ImeMode.Hiragana
        Edit_K001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit_K002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_K002.GotFocus
        Edit_K002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Number133_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number133.GotFocus
        Number133.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number134_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number134.GotFocus
        Number134.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number135_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number135.GotFocus
        Number135.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo_K003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K003.GotFocus
        Combo_K003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit000_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.LostFocus
        If Edit000.ReadOnly = False Then
            Edit000.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Private Sub Combo001_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   'éÛïtéÌï 
    End Sub
    Private Sub Edit011_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit011.LostFocus
        CHK_Edit011()   'QG Care No
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()   'ì¸â◊ãÊï™
    End Sub
    Private Sub Combo003_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo003.LostFocus
        CHK_Combo003()   'ì¸â◊íSìñ
    End Sub
    Private Sub Combo006_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo006.LostFocus
        CHK_Combo006()   'éÛïtíSìñ
    End Sub
    Private Sub Combo007_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo007.LostFocus
        CHK_Combo007()   'éÛïtãíì_
    End Sub
    Private Sub Number001_nTax_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001_nTax.LostFocus
        Number001_nTax.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number003.LostFocus
        Number003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   'îÃé–
    End Sub
    Private Sub Edit005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.LostFocus
        CHK_Edit005()   'Ç®ãqólñº
    End Sub
    Private Sub Edit006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.LostFocus
        Edit006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.LostFocus
        Edit007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.LostFocus
        Edit008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Mask1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mask1.LostFocus
        CHK_Mask1()     'óXï÷î‘çÜ
    End Sub
    Private Sub Edit009_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit009.LostFocus
        Edit009.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit010_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit010.LostFocus
        Edit010.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo004_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo004.LostFocus
        CHK_Combo004()   'èCóùéÌï 
    End Sub
    Private Sub Combo005_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo005.LostFocus
        CHK_Combo005()   'éñåÃèÛãµ
    End Sub
    Private Sub Edit012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.LostFocus
        Edit012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.LostFocus
        Number002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub Combo_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_U001.LostFocus
        CHK_Combo_U001()  'ÉÅÅ[ÉJÅ[
        If cmb_reset = "1" Then
            If msg.Text = Nothing Then
                rpar_comp() '**  èCóùïîèêÇrÇdÇs
            End If
        End If
    End Sub
    Private Sub Edit_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U001.LostFocus
        CHK_Edit_U001()   'ÉÇÉfÉã
    End Sub
    Private Sub Edit_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U002.LostFocus
        CHK_Edit_U002()   'ã@éÌ
    End Sub
    Private Sub Edit_U003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U003.LostFocus
        CHK_Edit_U003()   'S/N
    End Sub
    Private Sub Combo_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_U002.LostFocus
        CHK_Combo_U002()  'èCóùïîèê
    End Sub
    Private Sub CheckBox_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U001.LostFocus
        CheckBox_U001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Date_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U001.LostFocus
        CHK_Date_U001() 'çwì¸ì˙
    End Sub
    Private Sub Date_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U002.LostFocus
        CHK_Date_U002() 'ÉÅÅ[ÉJÅ[ï€èÿäJénì˙
    End Sub
    Private Sub CheckBox_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U002.LostFocus
        CheckBox_U002.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Date_U003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U003.LostFocus
        CHK_Date_U003() 'éñåÃì˙
    End Sub
    Private Sub Edit_U004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U004.LostFocus
        CHK_Edit_U004()   'èCóùì‡óe
    End Sub
    Private Sub Edit_U005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U005.LostFocus
        CHK_Edit_U005()   'èCóùÉRÉÅÉìÉg
    End Sub
    Private Sub CHK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub edit1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Edit)
        CHK_fuzoku_name(Lin.Tag) 'ïtëÆïiñº
    End Sub
    Private Sub QTY_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Number
        Lin = DirectCast(sender, GrapeCity.Win.Input.Number)
        CHK_fuzoku_QTY(Lin.Tag) 'ïtëÆïiêîó 
        If chkBox(Lin.Tag, 1).Checked = True Then
            If Lin.Tag = Line_No Then
                add_line("0")
                If Lin.Tag <> Line_No Then
                    chkBox(Line_No, 1).Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cmb1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        CHK_cmnt1(cmb.Tag)  'åÃè·ì‡óe
        If Line_No2 = cmb.Tag Then
            If Line_No2 < 8 Then
                If cmbBo_2(cmb.Tag, 1).Text <> Nothing Then
                    add_line_2("0")    'åÃè·ì‡óe
                    cmbBo_2(cmb.Tag + 1, 1).Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Combo_M001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_M001.LostFocus
        CHK_Combo_M001()    'å©êœíSìñ
    End Sub
    Private Sub Combo_M003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_M003.LostFocus
        CHK_Combo_M003()    'ìÔà’ìx
    End Sub
    Private Sub Edit_M001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M001.LostFocus
        CHK_Edit_M001()     'ÉÅÅ[ÉJÅ[èCóùî‘çÜ
        Irregular() 'ÉCÉåÉMÉÖÉâÅ[èàóù
    End Sub
    Private Sub Edit_M002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M002.LostFocus
        CHK_Edit_M002()     'å©êœì‡óe
    End Sub
    Private Sub Edit_M003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M003.LostFocus
        CHK_Edit_M003()     'å©êœÉRÉÅÉìÉg
    End Sub
    Private Sub Edit_M004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M004.LostFocus
        Edit_M004.Text = Trim(Edit_M004.Text)
        Edit_M004.BackColor = System.Drawing.SystemColors.Window
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
    Private Sub Combo_K001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K001.LostFocus
        CHK_Combo_K001()    'èCóùíSìñ
    End Sub
    Private Sub Combo_K002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K002.LostFocus
        CHK_Combo_K002()    'èCóùíSìñ
    End Sub
    Private Sub cmb4_1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        CHK_cmnt4(cmb.Tag)  'èCóùì‡óe
        If Line_No4 = cmb.Tag Then
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
    Private Sub Number111_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number111.LostFocus
        Number111.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number112_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number112.LostFocus
        Number112.BackColor = System.Drawing.SystemColors.Window
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
    Private Sub Number133_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number133.LostFocus
        Number133.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number134_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number134.LostFocus
        Number134.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number135_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number135.LostFocus
        Number135.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo_K003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_K003.LostFocus
        CHK_Combo_K003() 'åvè„QG
    End Sub
    Private Sub Date003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date003.LostFocus
        Date003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date004.LostFocus
        Date004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date006.LostFocus
        Date006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.LostFocus
        msg.Text = Nothing
        Date007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.LostFocus
        msg.Text = Nothing
        Date008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date010_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date010.LostFocus
        msg.Text = Nothing
        Date010.BackColor = System.Drawing.SystemColors.Window

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
        msg.Text = Nothing
        Date011.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date012.LostFocus
        msg.Text = Nothing
        Date012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Date013_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date013.LostFocus
        Date013.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit903_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit903.LostFocus
        Edit903.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit904_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EDIT904.LostFocus
        EDIT904.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Number011_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number011.TextChanged
        sum1_base()
    End Sub
    Private Sub Number012_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number012.TextChanged
        sum1_base()
        Number032.Value = Number012.Value
    End Sub
    Private Sub Number013_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number013.TextChanged
        sum1_base()
    End Sub
    Private Sub Number014_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number014.TextChanged
        sum1_base()
    End Sub
    Private Sub Number015_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number015.TextChanged
        sum1_base()
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
    End Sub
    Private Sub Number032_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number032.TextChanged
        sum3_base()
    End Sub
    Private Sub Number033_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number033.TextChanged
        sum3_base()
    End Sub
    Private Sub Number034_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number034.TextChanged
        sum3_base()
    End Sub
    Private Sub Number035_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number035.TextChanged
        sum3_base()
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
    Private Sub Number111_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number111.TextChanged
        sum1_base_K()
    End Sub
    Private Sub Number112_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number112.TextChanged
        sum1_base()
        Number132.Value = Number112.Value
    End Sub
    Private Sub Number113_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number113.TextChanged
        sum1_base_K()
    End Sub
    Private Sub Number114_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number114.TextChanged
        sum1_base_K()
    End Sub
    Private Sub Number115_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number115.TextChanged
        sum1_base_K()
    End Sub
    Private Sub Number121_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number121.TextChanged
        sum2_base_K()
    End Sub
    Private Sub Number123_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number123.TextChanged
        sum2_base_K()
    End Sub
    Private Sub Number124_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number124.TextChanged
        sum2_base_K()
    End Sub
    Private Sub Number125_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number125.TextChanged
        sum2_base_K()
    End Sub
    Private Sub Number131_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number131.TextChanged
        sum3_base_K()
    End Sub
    Private Sub Number132_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number132.TextChanged
        sum3_base_K()
    End Sub
    Private Sub Number133_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number133.TextChanged
        sum3_base_K()
    End Sub
    Private Sub Number134_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number134.TextChanged
        sum3_base_K()
    End Sub
    Private Sub Number135_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number135.TextChanged
        sum3_base_K()
    End Sub
    Sub sum1_base_K()
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
    Sub sum2_base_K()
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
    Sub sum3_base_K()
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

    '********************************************************************
    '**  ïœçXâ”èäÉ`ÉFÉbÉN
    '********************************************************************
    Sub CHG_CHK()
        CHG_F = "0"
        CHG.Text = Nothing
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)
        DtView3 = New DataView(DsList1.Tables("T01_REP_MTR_K"), "", "", DataViewRowState.CurrentRows)
        '***********
        '** äÓñ{èÓïÒ
        '***********
        If Date003.Text <> DtView1(0)("accp_date") Then
            CHG.Text = "éÛïtì˙ÅF" & DtView1(0)("accp_date") & " Å® " & Date003.Text
            CHG_F = "1" : Exit Sub 'éÛïtì˙
        End If

        If Date004.Number = 0 Then WK_str = Nothing Else WK_str = Date004.Text
        If IsDBNull(DtView2(0)("etmt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "å©êœì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'å©êœì˙
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
            CHG.Text = "ïîïiî≠íçì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ïîïiî≠íçì˙
        End If

        If Date008.Number = 0 Then WK_str = Nothing Else WK_str = Date008.Text
        If IsDBNull(DtView3(0)("part_rcpt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("part_rcpt_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "ïîïiéÛóÃì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ïîïiéÛóÃì˙
        End If

        If Date010.Number = 0 Then WK_str = Nothing Else WK_str = Date010.Text
        If IsDBNull(DtView3(0)("comp_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "äÆóπì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'äÆóπì˙
        End If

        If IsDBNull(DtView3(0)("sals_no")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("sals_no")
        If Edit903.Text <> WK_str2 Then
            CHG.Text = "ÉlÉoì`î‘çÜÅF" & DtView3(0)("sals_no") & " Å® " & Edit903.Text
            CHG_F = "1" : Exit Sub 'ÉlÉoì`î‘çÜ
        End If

        If IsDBNull(DtView3(0)("sals_no2")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("sals_no2")
        If EDIT904.Text <> WK_str2 Then
            CHG.Text = "ÉlÉoì`î‘çÜ2ÅF" & DtView3(0)("sals_no2") & " Å® " & EDIT904.Text
            CHG_F = "1" : Exit Sub 'ÉlÉoì`î‘çÜ2
        End If

        If Date011.Number = 0 Then WK_str = Nothing Else WK_str = Date011.Text
        If IsDBNull(DtView3(0)("sals_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("sals_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "îÑè„ì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'îÑè„ì˙
        End If

        If Date012.Number = 0 Then WK_str = Nothing Else WK_str = Date012.Text
        If IsDBNull(DtView3(0)("ship_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("ship_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "èoâ◊ì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'èoâ◊ì˙
        End If

        If Date013.Number = 0 Then WK_str = Nothing Else WK_str = Date013.Text
        If IsDBNull(DtView3(0)("rqst_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("rqst_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "êøãÅì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'êøãÅì˙
        End If

        If Combo006.Text <> DtView1(0)("rcpt_ent_empl_name") Then
            CHG.Text = "éÛïtíSìñÅF" & DtView1(0)("rcpt_ent_empl_name") & " Å® " & Combo006.Text
            CHG_F = "1" : Exit Sub 'éÛïtíSìñ
        End If

        If Combo007.Text <> DtView1(0)("rcpt_brch_code") & ":" & DtView1(0)("rcpt_brch_name") Then
            CHG.Text = "éÛïtãíì_ÅF" & DtView1(0)("rcpt_brch_code") & ":" & DtView1(0)("rcpt_brch_name") & " Å® " & Combo007.Text
            CHG_F = "1" : Exit Sub 'éÛïtãíì_
        End If

        If Combo001.Text <> DtView1(0)("rcpt_name") Then
            CHG.Text = "éÛïtéÌï ÅF" & DtView1(0)("rcpt_name") & " Å® " & Combo001.Text
            CHG_F = "1" : Exit Sub 'éÛïtéÌï 
        End If

        If Edit011.Text <> DtView1(0)("qg_care_no") Then
            CHG.Text = "QG Care NoÅF" & DtView1(0)("qg_care_no") & " Å® " & Edit011.Text
            CHG_F = "1" : Exit Sub 'QG Care No
        End If

        If Combo002.Text <> DtView1(0)("arvl_name") Then
            CHG.Text = "ì¸â◊ãÊï™ÅF" & DtView1(0)("arvl_name") & " Å® " & Combo002.Text
            CHG_F = "1" : Exit Sub 'ì¸â◊ãÊï™
        End If

        If Combo003.Text <> DtView1(0)("arvl_empl_name") Then
            CHG.Text = "ì¸â◊íSìñÅF" & DtView1(0)("arvl_empl_name") & " Å® " & Combo003.Text
            CHG_F = "1" : Exit Sub 'ì¸â◊íSìñ
        End If

        If IsDBNull(DtView1(0)("wrn_limt_amnt")) Then WK_int2 = 0 Else WK_int2 = DtView1(0)("wrn_limt_amnt")
        If Number001_nTax.Value <> WK_int2 Then
            CHG.Text = "ï€èÿå¿ìxäzÅF" & WK_int2 & " Å® " & Number001_nTax.Value
            CHG_F = "1" : Exit Sub 'ï€èÿå¿ìxäz
        End If

        If IsDBNull(DtView1(0)("menseki_amnt")) Then WK_int2 = 0 Else WK_int2 = DtView1(0)("menseki_amnt")
        If Number003.Value <> WK_int2 Then
            CHG.Text = "ñ∆ê”ÅF" & WK_int2 & " Å® " & Number003.Value
            CHG_F = "1" : Exit Sub 'ñ∆ê”
        End If

        If Label001.Visible = False Then WK_str = Nothing Else WK_str = Label001.Text
        If IsDBNull(DtView1(0)("store_name")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("store_name")
        If WK_str <> WK_str2 Then
            CHG.Text = "îÃé–ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'îÃé–
        End If

        If Edit003.Visible = False Then WK_str = Nothing Else WK_str = Edit003.Text
        WK_str2 = DtView1(0)("store_prsn")
        If WK_str <> WK_str2 Then
            CHG.Text = "îÃé–íSìñé“ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'îÃé–íSìñé“
        End If

        If Edit004.Visible = False Then WK_str = Nothing Else WK_str = Edit004.Text
        WK_str2 = DtView1(0)("store_repr_no")
        If WK_str <> WK_str2 Then
            CHG.Text = "îÃé–èCóùî‘çÜÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'îÃé–èCóùî‘çÜ
        End If

        If Edit005.Text <> DtView1(0)("user_name") Then
            CHG.Text = "Ç®ãqólñºÅF" & DtView1(0)("user_name") & " Å® " & Edit005.Text
            CHG_F = "1" : Exit Sub 'Ç®ãqólñº
        End If

        If Edit006.Text <> DtView1(0)("user_name_kana") Then
            CHG.Text = "ÅiÉJÉiÅjÅF" & DtView1(0)("user_name_kana") & " Å® " & Edit006.Text
            CHG_F = "1" : Exit Sub 'ÅiÉJÉiÅj
        End If

        If Edit007.Text <> DtView1(0)("tel1") Then
            CHG.Text = "ìdòbî‘çÜ1ÅF" & DtView1(0)("tel1") & " Å® " & Edit007.Text
            CHG_F = "1" : Exit Sub 'ìdòbî‘çÜ1
        End If

        If Edit008.Text <> DtView1(0)("tel2") Then
            CHG.Text = "ìdòbî‘çÜ2ÅF" & DtView1(0)("tel2") & " Å® " & Edit008.Text
            CHG_F = "1" : Exit Sub 'ìdòbî‘çÜ2
        End If
        If Not IsDBNull(DtView1(0)("zip")) Then WK_str = Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) Else WK_str = Nothing
        If WK_str = "-" Then WK_str = Nothing
        If Mask1.Value <> Nothing Then WK_str2 = Mid(Mask1.Text, 3, 8) Else WK_str2 = Nothing
        If WK_str2 <> WK_str Then
            CHG.Text = "óXï÷î‘çÜÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'óXï÷î‘çÜ
        End If

        If Edit009.Text <> DtView1(0)("adrs1") Then
            CHG.Text = "èZèä1ÅF" & DtView1(0)("adrs1") & " Å® " & Edit009.Text
            CHG_F = "1" : Exit Sub 'èZèä1
        End If

        If Edit010.Text <> DtView1(0)("adrs2") Then
            CHG.Text = "èZèä2ÅF" & DtView1(0)("adrs2") & " Å® " & Edit010.Text
            CHG_F = "1" : Exit Sub 'èZèä2
        End If

        If Combo004.Text <> DtView1(0)("rpar_cls_name") Then
            CHG.Text = "èCóùéÌï ÅF" & DtView1(0)("rpar_cls_name") & " Å® " & Combo004.Text
            CHG_F = "1" : Exit Sub 'èCóùéÌï 
        End If

        If IsDBNull(DtView1(0)("acdt_name")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("acdt_name")
        If Combo005.Text <> WK_str2 Then
            CHG.Text = "éñåÃèÛãµÅF" & WK_str2 & " Å® " & Combo005.Text
            CHG_F = "1" : Exit Sub 'éñåÃèÛãµ
        End If

        If Edit012.Text <> DtView1(0)("orgnl_vndr_code") Then
            CHG.Text = "µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁÅF" & DtView1(0)("orgnl_vndr_code") & " Å® " & Edit012.Text
            CHG_F = "1" : Exit Sub 'µÿºﬁ≈Ÿ“∞∂∞∫∞ƒﬁ
        End If

        If Number002.Value <> DtView1(0)("recv_amnt") Then
            CHG.Text = "óaÇ©ÇËã‡ÅF" & DtView1(0)("recv_amnt") & " Å® " & Number002.Value
            CHG_F = "1" : Exit Sub 'óaÇ©ÇËã‡
        End If

        '***********
        '** éÛïtè⁄ç◊
        '***********
        If Combo_U001.Text <> DtView1(0)("vndr_name") Then
            CHG.Text = "ÉÅÅ[ÉJÅ[ÅF" & DtView1(0)("vndr_name") & " Å® " & Combo_U001.Text
            CHG_F = "1" : Exit Sub 'ÉÅÅ[ÉJÅ[
        End If

        If Edit_U001.Text <> DtView1(0)("model_2") Then
            CHG.Text = "ÉÇÉfÉãÅF" & DtView1(0)("model_2") & " Å® " & Edit_U001.Text
            CHG_F = "1" : Exit Sub 'ÉÇÉfÉã
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

        If Edit_U002.Text <> DtView1(0)("model_1") Then
            CHG.Text = "ã@éÌÅF" & DtView1(0)("model_1") & " Å® " & Edit_U002.Text
            CHG_F = "1" : Exit Sub 'ã@éÌ
        End If

        If Edit_U003.Text <> DtView1(0)("s_n") Then
            CHG.Text = "ÇrÅ^ÇmÅF" & DtView1(0)("s_n") & " Å® " & Edit_U003.Text
            CHG_F = "1" : Exit Sub 'ÇrÅ^Çm
        End If

        If Combo_U002.Text <> DtView1(0)("rpar_comp_name") Then
            CHG.Text = "èCóùïîèêÅF" & DtView1(0)("rpar_comp_name") & " Å® " & Combo_U002.Text
            CHG_F = "1" : Exit Sub 'èCóùïîèê
        End If

        If Date_U001.Number = 0 Then WK_str = Nothing Else WK_str = Date_U001.Text
        If IsDBNull(DtView1(0)("prch_date")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("prch_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "çwì¸ì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'çwì¸ì˙
        End If

        If Date_U002.Number = 0 Then WK_str = Nothing Else WK_str = Date_U002.Text
        If IsDBNull(DtView1(0)("vndr_wrn_date")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("vndr_wrn_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "ÉÅÅ[ÉJÅ[ï€èÿäJénì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ÉÅÅ[ÉJÅ[ï€èÿäJénì˙
        End If

        If CheckBox_U002.Checked = True Then WK_str = "ëŒè€" Else WK_str = "ëŒè€äO"
        If DtView1(0)("vndr_wrn_date_chk") = "True" Then WK_str2 = "ëŒè€" Else WK_str2 = "ëŒè€äO"
        If WK_str <> WK_str2 Then
            CHG.Text = "ÉäÉyÉAÉGÉNÉXÉeÉìÉVÉáÉìÉtÉâÉOÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ÉäÉyÉAÉGÉNÉXÉeÉìÉVÉáÉìÉtÉâÉO
        End If

        If Date_U003.Number = 0 Then WK_str = Nothing Else WK_str = Date_U003.Text
        If IsDBNull(DtView1(0)("acdt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("acdt_date")
        If WK_str <> WK_str2 Then
            CHG.Text = "éñåÃì˙ÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'éñåÃì˙
        End If

        'ïtëÆïi
        For i = 0 To Line_No
            'í«â¡
            If chkBox(i, 1).Checked = True _
                And label(i, 2).Text = Nothing Then
                CHG.Text = "ïtëÆïiÅFí«â¡"
                CHG_F = "1" : Exit Sub 'ïtëÆïi
            End If
            'ïœçX
            If chkBox(i, 1).Checked = True _
                And label(i, 2).Text <> Nothing Then
                If edit(i, 1).Text <> edit_MOTO(i, 1).Text _
                    Or nbrBox(i, 1).Text <> nbrBox_MOTO(i, 1).Text _
                    Or edit(i, 2).Text <> edit_MOTO(i, 2).Text Then
                    CHG.Text = "ïtëÆïiÅFïœçX"
                    CHG_F = "1" : Exit Sub 'ïtëÆïi
                End If
            End If
            'çÌèú
            If chkBox(i, 1).Checked = False _
                And label(i, 2).Text <> Nothing Then
                CHG.Text = "ïtëÆïiÅFçÌèú"
                CHG_F = "1" : Exit Sub 'ïtëÆïi
            End If
        Next

        'åÃè·ì‡óe
        For i = 0 To Line_No2
            If label_2(i, 2).Text = Nothing Then
                If cmbBo_2(i, 1).Text <> Nothing Then
                    'í«â¡
                    CHG.Text = "åÃè·ì‡óeÅFí«â¡"
                    CHG_F = "1" : Exit Sub 'åÃè·ì‡óe
                End If
            Else
                WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT"), "seq = " & label_2(i, 2).Text, "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If cmbBo_2(i, 1).Text <> Nothing Then
                        If cmbBo_2(i, 1).Text <> WK_DtView1(0)("cmnt_name1") Then
                            'ïœçX
                            CHG.Text = "åÃè·ì‡óeÅFïœçX"
                            CHG_F = "1" : Exit Sub 'åÃè·ì‡óe
                        End If
                    Else
                        'çÌèú
                        CHG.Text = "åÃè·ì‡óeÅFçÌèú"
                        CHG_F = "1" : Exit Sub 'åÃè·ì‡óe
                    End If
                End If
            End If
        Next

        If Edit_U004.Text <> DtView1(0)("user_trbl") Then
            CHG.Text = "åÃè·â”èäÅF" & DtView1(0)("user_trbl") & " Å® " & Edit_U004.Text
            CHG_F = "1" : Exit Sub 'åÃè·â”èä
        End If

        If Edit_U005.Text <> DtView1(0)("rcpt_comn") Then
            CHG.Text = "éÛïtÉRÉÅÉìÉgÅF" & DtView1(0)("rcpt_comn") & " Å® " & Edit_U005.Text
            CHG_F = "1" : Exit Sub 'éÛïtÉRÉÅÉìÉg
        End If

        '***********
        '** å©êœè⁄ç◊
        '***********
        WK_str = Combo_M001.Text
        If IsDBNull(DtView2(0)("etmt_empl_name")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_empl_name")
        If WK_str <> WK_str2 Then
            CHG.Text = "å©êœíSìñÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'å©êœíSìñ
        End If

        WK_str = Combo_M003.Text
        If IsDBNull(DtView2(0)("tier_name")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("tier_name")
        If WK_str <> WK_str2 Then
            CHG.Text = "ìÔà’ìxÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ìÔà’ìx
        End If

        WK_str = Edit_M001.Text
        If IsDBNull(DtView2(0)("vndr_repr_no")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("vndr_repr_no")
        If WK_str <> WK_str2 Then
            CHG.Text = "ÉÅÅ[ÉJÅ[èCóùî‘çÜÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'ÉÅÅ[ÉJÅ[èCóùî‘çÜ
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

        If IsDBNull(DtView2(0)("etmt_meas")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_meas")
        If Edit_M002.Text <> WK_str2 Then
            CHG.Text = "å©êœì‡óeÅF" & WK_str2 & " Å® " & Edit_M002.Text
            CHG_F = "1" : Exit Sub 'å©êœì‡óe
        End If

        If IsDBNull(DtView2(0)("etmt_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("etmt_comn")
        If Edit_M003.Text <> WK_str2 Then
            CHG.Text = "å©êœÉRÉÅÉìÉgÅF" & WK_str2 & " Å® " & Edit_M003.Text
            CHG_F = "1" : Exit Sub 'å©êœÉRÉÅÉìÉg
        End If

        If IsDBNull(DtView2(0)("rsrv_cacl_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("rsrv_cacl_comn")
        If Edit_M004.Text <> WK_str2 Then
            CHG.Text = "âèúòAóçÅF" & WK_str2 & " Å® " & Edit_M004.Text
            CHG_F = "1" : Exit Sub 'âèúòAóç
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
                    If WK_DtView1(0)("part_code") <> WK_DtView2(0)("part_code") _
                        Or WK_DtView1(0)("part_name") <> WK_DtView2(0)("part_name") _
                        Or WK_DtView1(0)("part_amnt") <> WK_DtView2(0)("part_amnt") _
                        Or WK_DtView1(0)("use_qty") <> WK_DtView2(0)("use_qty") Then
                        'ïœçX
                        CHG.Text = "å©êœïîïiÅFïœçX"
                        CHG_F = "1" : Exit Sub 'å©êœïîïi
                    End If
                End If
            End If
        Next

        '***********
        '** äÆê¨è⁄ç◊
        '***********
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

        If IsDBNull(DtView3(0)("comp_shop_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_tech_chrg")
        If Number111.Value <> WK_int2 Then
            CHG.Text = "äÆóπåvè„ãZèpóøÅF" & WK_int2 & " Å® " & Number111.Value
            CHG_F = "1" : Exit Sub 'äÆóπåvè„ãZèpóø
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
            CHG.Text = "APESÅF" & WK_int2 & " Å® " & Number132.Value
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

        If IsDBNull(DtView3(0)("comp_cost_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_tax")
        If Number137.Value <> WK_int2 Then
            CHG.Text = "äÆóπÉRÉXÉgè¡îÔê≈ÅF" & WK_int2 & " Å® " & Number137.Value
            CHG_F = "1" : Exit Sub 'äÆóπÉRÉXÉgè¡îÔê≈
        End If

        WK_str = Combo_K003.Text
        WK_str2 = Combo_K003_moto.Text
        If WK_str <> WK_str2 Then
            CHG.Text = "åvè„QGÅF" & WK_str2 & " Å® " & WK_str
            CHG_F = "1" : Exit Sub 'åvè„QG
        End If

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
                    If WK_DtView1(0)("part_code") <> WK_DtView2(0)("part_code") _
                        Or WK_DtView1(0)("part_name") <> WK_DtView2(0)("part_name") _
                        Or WK_DtView1(0)("part_amnt") <> WK_DtView2(0)("part_amnt") _
                        Or WK_DtView1(0)("use_qty") <> WK_DtView2(0)("use_qty") Then
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

        If Date007.Number = 0 Then WK_str = Nothing Else WK_str = Date007.Text
        If IsDBNull(DtView3(0)("part_ordr_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("part_ordr_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ïîïiî≠íçì˙", WK_str2, WK_str)
        End If

        If Date008.Number = 0 Then WK_str = Nothing Else WK_str = Date008.Text
        If IsDBNull(DtView3(0)("part_rcpt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("part_rcpt_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "ïîïiéÛóÃì˙", WK_str2, WK_str)
        End If

        If Date010.Number = 0 Then WK_str = Nothing Else WK_str = Date010.Text
        If IsDBNull(DtView3(0)("comp_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπì˙", WK_str2, WK_str)
        End If

        If Date011.Number = 0 Then WK_str = Nothing Else WK_str = Date011.Text
        If IsDBNull(DtView3(0)("sals_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("sals_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "îÑè„ì˙", WK_str2, WK_str)
        End If

        If Date012.Number = 0 Then WK_str = Nothing Else WK_str = Date012.Text
        If IsDBNull(DtView3(0)("ship_date")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("ship_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èoâ◊ì˙", WK_str2, WK_str)
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

        If IsDBNull(DtView3(0)("comp_meas")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_meas")
        If Edit_K001.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe", WK_str2, Edit_K001.Text)
        End If

        If IsDBNull(DtView3(0)("comp_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView3(0)("comp_comn")
        If Edit_K002.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùÉRÉÅÉìÉg", WK_str2, Edit_K002.Text)
        End If

        If IsDBNull(DtView3(0)("comp_cost_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_tech_chrg")
        If Number131.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgãZèpóø", WK_int2, Number131.Value)
        End If

        If IsDBNull(DtView3(0)("comp_cost_apes")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_apes")
        If Number132.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÇ`ÇoÇdÇr", WK_int2, Number132.Value)
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

        If IsDBNull(DtView3(0)("comp_cost_tax")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_cost_tax")
        If Number137.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπÉRÉXÉgè¡îÔê≈", WK_int2, Number137.Value)
        End If

        If IsDBNull(DtView3(0)("comp_shop_tech_chrg")) Then WK_int2 = 0 Else WK_int2 = DtView3(0)("comp_shop_tech_chrg")
        If Number111.Value <> WK_int2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπåvè„ãZèpóø", WK_int2, Number111.Value)
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
            NoDsp_Null()

            CHG_HSTY()  '**  ïœçXóöó

            If chg_itm <> 0 Then
                ''éÛït
                'strSQL = "UPDATE T01_REP_MTR"
                'strSQL = strSQL & " SET fin_ent_empl_code = " & P_EMPL_NO
                ''If Combo_K001.Visible = True And CLK001.Text <> Nothing Then
                'strSQL = strSQL & ", repr_empl_code = " & CLK001.Text
                ''Else
                ''    strSQL = strSQL & ", repr_empl_code = NULL"
                ''End If
                'strSQL = strSQL & ", repr_brch_code = '" & CLK001_BRH.Text & "'"
                'If Combo_K002.Visible = True Then
                '    strSQL = strSQL & ", m_tech_seq = " & CLK002.Text
                'Else
                '    strSQL = strSQL & ", m_tech_seq = NULL"
                'End If
                'strSQL = strSQL & ", comp_meas = '" & Edit_K001.Text & "'"
                'strSQL = strSQL & ", comp_comn = '" & Edit_K002.Text & "'"
                'strSQL = strSQL & ", comp_cost_tech_chrg = " & Number131.Value
                'strSQL = strSQL & ", comp_cost_apes = " & Number132.Value
                'strSQL = strSQL & ", comp_cost_part_chrg = " & Number133.Value
                'strSQL = strSQL & ", comp_cost_fee = " & Number134.Value
                'strSQL = strSQL & ", comp_cost_pstg = " & Number135.Value
                'strSQL = strSQL & ", comp_cost_tax = " & Number137.Value

                'strSQL = strSQL & ", comp_shop_tech_chrg = " & Number111.Value
                'strSQL = strSQL & ", comp_shop_apes = " & Number112.Value
                'strSQL = strSQL & ", comp_shop_part_chrg = " & Number113.Value
                'strSQL = strSQL & ", comp_shop_fee = " & Number114.Value
                'strSQL = strSQL & ", comp_shop_pstg = " & Number115.Value
                'strSQL = strSQL & ", comp_shop_tax = " & Number117.Value

                'strSQL = strSQL & ", comp_eu_tech_chrg = " & Number121.Value
                'strSQL = strSQL & ", comp_eu_apes = " & Number122.Value
                'strSQL = strSQL & ", comp_eu_part_chrg = " & Number123.Value
                'strSQL = strSQL & ", comp_eu_fee = " & Number124.Value
                'strSQL = strSQL & ", comp_eu_pstg = " & Number125.Value
                'strSQL = strSQL & ", comp_eu_tax = " & Number127.Value

                'If Date007.Number <> 0 Then strSQL = strSQL & ", part_ordr_date = '" & Date007.Text & "'" Else strSQL = strSQL & ", part_ordr_date = NULL"
                'If Date008.Number <> 0 Then strSQL = strSQL & ", part_rcpt_date = '" & Date008.Text & "'" Else strSQL = strSQL & ", part_rcpt_date = NULL"
                'If Date010.Number <> 0 Then strSQL = strSQL & ", comp_date = '" & Date010.Text & "'" Else strSQL = strSQL & ", comp_date = NULL"
                'If Date011.Number <> 0 Then strSQL = strSQL & ", sals_date = '" & Date011.Text & "'" Else strSQL = strSQL & ", sals_date = NULL"
                'If Date012.Number <> 0 Then strSQL = strSQL & ", ship_date = '" & Date012.Text & "'" Else strSQL = strSQL & ", ship_date = NULL"
                'strSQL = strSQL & ", zero_code = '" & zero_code.Text & "'"
                'strSQL = strSQL & ", zero_name = '" & zero_name.Text & "'"
                'If Date010.Number <> 0 Then
                '    strSQL = strSQL & ", re_rpar_date = '" & DateAdd(DateInterval.Day, NumberN009.Value, CDate(Date010.Text)) & "'"
                'Else
                '    strSQL = strSQL & ", re_rpar_date = NULL"
                'End If

                'strSQL = strSQL & " WHERE (rcpt_no = '" & Edit000.Text & "')"
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'SqlCmd1.CommandTimeout = 600
                'DB_OPEN("nMVAR")
                'SqlCmd1.ExecuteNonQuery()
                'DB_CLOSE()

                ''QG Care èCóùã‡äzó›åv
                'If Edit011.Text <> Nothing Then
                '    WK_DsList1.Clear()
                '    strSQL = "SELECT * FROM L03_QG_AMNT_LOG"
                '    strSQL = strSQL & " WHERE (qg_care_no = '" & Edit011.Text & "')"
                '    strSQL = strSQL & " AND (rcpt_no = '" & Edit000.Text & "')"
                '    strSQL = strSQL & " AND (from_date <= CONVERT(DATETIME, '" & Date_U003.Text & "', 102))"
                '    strSQL = strSQL & " AND (to_date >= CONVERT(DATETIME, '" & Date_U003.Text & "', 102))"
                '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '    DaList1.SelectCommand = SqlCmd1
                '    DB_OPEN("nMVAR")
                '    DaList1.Fill(WK_DsList1, "L03_QG_AMNT_LOG")
                '    DB_CLOSE()
                '    WK_DtView1 = New DataView(WK_DsList1.Tables("L03_QG_AMNT_LOG"), "", "", DataViewRowState.CurrentRows)
                '    If WK_DtView1.Count = 0 Then
                '        SqlCmd1 = New SqlClient.SqlCommand("SELECT â¡ì¸î‘çÜ, â¡ì¸ì˙ FROM T01_â¡ì¸é“ WHERE (â¡ì¸î‘çÜ = '" & Edit011.Text & "')", cnsqlclient)
                '        DaList1.SelectCommand = SqlCmd1
                '        DB_OPEN("QGCare")
                '        DaList1.Fill(WK_DsList1, "T01")
                '        DB_CLOSE()
                '        WK_DtView2 = New DataView(WK_DsList1.Tables("T01"), "", "", DataViewRowState.CurrentRows)

                '        'âΩîNñ⁄Ç©ãÅÇﬂÇÈ
                '        Dim WK_date1, WK_date2 As Date
                '        For i = 1 To 10
                '            If DateAdd(DateInterval.Year, i, CDate(WK_DtView2(0)("â¡ì¸ì˙"))) > CDate(Date_U003.Text) Then
                '                WK_date1 = DateAdd(DateInterval.Year, i - 1, CDate(WK_DtView2(0)("â¡ì¸ì˙")))
                '                WK_date2 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, i, CDate(WK_DtView2(0)("â¡ì¸ì˙"))))
                '                Exit For
                '            End If
                '        Next

                '        strSQL = "INSERT INTO L03_QG_AMNT_LOG"
                '        strSQL = strSQL & " (qg_care_no, rcpt_no, from_date, to_date, repr_chrg)"
                '        strSQL = strSQL & " VALUES ('" & Edit011.Text & "'"
                '        strSQL = strSQL & ", '" & Edit000.Text & "'"
                '        strSQL = strSQL & ", CONVERT(DATETIME, '" & WK_date1 & "', 102)"
                '        strSQL = strSQL & ", CONVERT(DATETIME, '" & WK_date2 & "', 102)"
                '        strSQL = strSQL & ", " & Number128.Value & ")"
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.CommandTimeout = 600
                '        DB_OPEN("nMVAR")
                '        SqlCmd1.ExecuteNonQuery()
                '        DB_CLOSE()
                '    Else
                '        strSQL = "UPDATE L03_QG_AMNT_LOG"
                '        strSQL = strSQL & " SET repr_chrg = repr_chrg + " & Number128.Value
                '        strSQL = strSQL & " WHERE (qg_care_no = '" & Edit011.Text & "')"
                '        strSQL = strSQL & " AND (rcpt_no = '" & Edit000.Text & "')"
                '        strSQL = strSQL & " AND (from_date <= CONVERT(DATETIME, '" & Date_U003.Text & "', 102))"
                '        strSQL = strSQL & " AND (to_date >= CONVERT(DATETIME, '" & Date_U003.Text & "', 102))"
                '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                '        SqlCmd1.CommandTimeout = 600
                '        DB_OPEN("nMVAR")
                '        SqlCmd1.ExecuteNonQuery()
                '        DB_CLOSE()
                '    End If
                'End If
            End If

            ''èCóùì‡óe
            'WK_DsList1.Clear()
            'strSQL = "SELECT MAX(seq) AS max_seq FROM T03_REP_CMNT WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '3')"
            'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            'DaList1.SelectCommand = SqlCmd1
            'DB_OPEN("nMVAR")
            'DaList1.Fill(WK_DsList1, "T02_ATCH_ITEM")
            'DB_CLOSE()
            'WK_DtView1 = New DataView(WK_DsList1.Tables("T02_ATCH_ITEM"), "", "", DataViewRowState.CurrentRows)
            'If WK_DtView1.Count = 0 Then
            '    seq = 0
            'Else
            '    If Not IsDBNull(WK_DtView1(0)("max_seq")) Then
            '        seq = WK_DtView1(0)("max_seq")
            '    Else
            '        seq = 0
            '    End If
            'End If

            '            For i = 0 To Line_No4
            '                If label_4(i, 2).Text = Nothing Then
            '                    If cmbBo_4(i, 1).Text <> Nothing Then
            '                        'í«â¡
            '                        seq = seq + 1

            '                        strSQL = "INSERT INTO T03_REP_CMNT"
            '                        strSQL = strSQL & " (rcpt_no, kbn, seq, cls_code1, cmnt_code1)"
            '                        strSQL = strSQL & " VALUES ('" & Edit000.Text & "'"
            '                        strSQL = strSQL & ", '3'"
            '                        strSQL = strSQL & ", " & seq
            '                        strSQL = strSQL & ", '21'"
            '                        strSQL = strSQL & ", '" & label_4(i, 1).Text & "')"
            '                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            '                        SqlCmd1.CommandTimeout = 600
            '                        DB_OPEN("nMVAR")
            '                        SqlCmd1.ExecuteNonQuery()
            '                        DB_CLOSE()

            '                        WK_str = cmbBo_4(i, 1).Text
            '                        chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe" & seq, "", WK_str)

            '                        label_4(i, 2).Text = seq
            '                        GoTo skp2
            '                    End If
            '                Else
            '                    WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_3"), "seq = " & label_4(i, 2).Text, "", DataViewRowState.CurrentRows)
            '                    If WK_DtView1.Count <> 0 Then
            '                        If cmbBo_4(i, 1).Text <> Nothing Then
            '                            If cmbBo_4(i, 1).Text <> WK_DtView1(0)("cmnt_name1") Then
            '                                'ïœçX
            '                                strSQL = "UPDATE T03_REP_CMNT"
            '                                strSQL = strSQL & " SET cmnt_code1 = '" & label_4(i, 1).Text & "'"
            '                                strSQL = strSQL & " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '3') AND (seq = " & label_4(i, 2).Text & ")"
            '                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            '                                SqlCmd1.CommandTimeout = 600
            '                                DB_OPEN("nMVAR")
            '                                SqlCmd1.ExecuteNonQuery()
            '                                DB_CLOSE()

            '                                WK_str = cmbBo_4(i, 1).Text
            '                                WK_str2 = WK_DtView1(0)("cmnt_name1")
            '                                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe" & label_4(i, 2).Text, WK_str2, WK_str)

            '                                GoTo skp2
            '                            End If
            '                        Else
            '                            'çÌèú
            '                            strSQL = "DELETE FROM T03_REP_CMNT"
            '                            strSQL = strSQL & " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '3') AND (seq = " & label_4(i, 2).Text & ")"
            '                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            '                            SqlCmd1.CommandTimeout = 600
            '                            DB_OPEN("nMVAR")
            '                            SqlCmd1.ExecuteNonQuery()
            '                            DB_CLOSE()

            '                            WK_str2 = WK_DtView1(0)("cmnt_name1")
            '                            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "èCóùì‡óe" & label_4(i, 2).Text, WK_str2, "")

            '                            label_4(i, 2).Text = Nothing
            '                            GoTo skp2
            '                        End If
            '                    End If
            '                End If
            'skp2:
            '            Next

            ''ïîïi
            'For i = 0 To 1000
            '    WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)
            '    WK_DtView2 = New DataView(DsList1.Tables("T04_REP_PART_MOTO_2"), "ID_NO = " & i, "", DataViewRowState.CurrentRows)

            '    If WK_DtView1.Count = 0 Then
            '        If WK_DtView2.Count = 0 Then
            '            Exit For
            '        Else
            '            'çÌèú
            '            strSQL = "DELETE FROM T04_REP_PART"
            '            strSQL = strSQL & " WHERE (rcpt_no = '" & Edit000.Text & "') AND (kbn = '2') AND (seq = " & WK_DtView2(0)("seq") & ")"
            '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            '            SqlCmd1.CommandTimeout = 600
            '            DB_OPEN("nMVAR")
            '            SqlCmd1.ExecuteNonQuery()
            '            DB_CLOSE()

            '            WK_str2 = WK_DtView2(0)("part_code") & " / " & WK_DtView2(0)("part_name") & " / " & Format(WK_DtView2(0)("part_amnt"), "##,##0") & " / " & WK_DtView2(0)("use_qty") & " / " & WK_DtView2(0)("shop_chrg") & " / " & WK_DtView2(0)("eu_chrg") & " / " & WK_DtView2(0)("ordr_no") & " / " & WK_DtView2(0)("ordr_no2")
            '            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπïîïi" & i, WK_str2, "")
            '        End If
            '    Else
            '        If WK_DtView2.Count = 0 Then
            '            'í«â¡
            '            strSQL = "INSERT INTO T04_REP_PART"
            '            strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg, shop_chrg, eu_chrg, ordr_no, ordr_no2)"
            '            strSQL = strSQL & " VALUES ('" & Edit000.Text & "'"
            '            strSQL = strSQL & ", '2'"
            '            strSQL = strSQL & ", " & WK_DtView1(0)("seq")
            '            strSQL = strSQL & ", '" & WK_DtView1(0)("part_code") & "'"
            '            strSQL = strSQL & ", '" & WK_DtView1(0)("part_name") & "'"
            '            strSQL = strSQL & ", " & WK_DtView1(0)("part_amnt") & ""
            '            strSQL = strSQL & ", " & WK_DtView1(0)("use_qty") & ""
            '            If WK_DtView1(0)("zaiko_flg") = "True" Then strSQL = strSQL & ", 1" Else strSQL = strSQL & ", 0"
            '            strSQL = strSQL & ", " & WK_DtView1(0)("shop_chrg") & ""
            '            strSQL = strSQL & ", " & WK_DtView1(0)("eu_chrg") & ""
            '            strSQL = strSQL & ", '" & WK_DtView1(0)("ordr_no") & "'"
            '            strSQL = strSQL & ", '" & WK_DtView1(0)("ordr_no2") & "')"
            '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            '            SqlCmd1.CommandTimeout = 600
            '            DB_OPEN("nMVAR")
            '            SqlCmd1.ExecuteNonQuery()
            '            DB_CLOSE()

            '            WK_str = WK_DtView1(0)("part_code") & " / " & WK_DtView1(0)("part_name") & " / " & Format(WK_DtView1(0)("part_amnt"), "##,##0") & " / " & WK_DtView1(0)("use_qty") & " / " & WK_DtView1(0)("shop_chrg") & " / " & WK_DtView1(0)("eu_chrg") & " / " & WK_DtView1(0)("ordr_no") & " / " & WK_DtView1(0)("ordr_no2")
            '            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπïîïi" & i, "", WK_str)
            '        Else
            '            If WK_DtView1(0)("part_code") <> WK_DtView2(0)("part_code") _
            '                Or WK_DtView1(0)("part_name") <> WK_DtView2(0)("part_name") _
            '                Or WK_DtView1(0)("part_amnt") <> WK_DtView2(0)("part_amnt") _
            '                Or WK_DtView1(0)("use_qty") <> WK_DtView2(0)("use_qty") _
            '                Or WK_DtView1(0)("shop_chrg") <> WK_DtView2(0)("shop_chrg") _
            '                Or WK_DtView1(0)("eu_chrg") <> WK_DtView2(0)("eu_chrg") _
            '                Or WK_DtView1(0)("ordr_no") <> WK_DtView2(0)("ordr_no") _
            '                Or WK_DtView1(0)("ordr_no2") <> WK_DtView2(0)("ordr_no2") _
            '                Or WK_DtView1(0)("zaiko_flg") <> WK_DtView2(0)("zaiko_flg") Then

            '                'ïœçX
            '                strSQL = "UPDATE T04_REP_PART"
            '                strSQL = strSQL & " SET part_code = '" & WK_DtView1(0)("part_code") & "'"
            '                strSQL = strSQL & ", part_name = '" & WK_DtView1(0)("part_name") & "'"
            '                strSQL = strSQL & ", part_amnt = " & WK_DtView1(0)("part_amnt") & ""
            '                strSQL = strSQL & ", use_qty = " & WK_DtView1(0)("use_qty") & ""
            '                strSQL = strSQL & ", shop_chrg = " & WK_DtView1(0)("shop_chrg") & ""
            '                strSQL = strSQL & ", eu_chrg = " & WK_DtView1(0)("eu_chrg") & ""
            '                strSQL = strSQL & ", ordr_no = '" & WK_DtView1(0)("ordr_no") & "'"
            '                strSQL = strSQL & ", ordr_no2 = '" & WK_DtView1(0)("ordr_no2") & "'"
            '                If WK_DtView1(0)("zaiko_flg") = "True" Then strSQL = strSQL & ", zaiko_flg = 1" Else strSQL = strSQL & ", zaiko_flg = 0"
            '                strSQL = strSQL & " WHERE (rcpt_no = '" & Edit000.Text & "')"
            '                strSQL = strSQL & " AND (kbn = '2')"
            '                strSQL = strSQL & " AND (seq = " & WK_DtView1(0)("seq") & ")"
            '                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            '                SqlCmd1.CommandTimeout = 600
            '                DB_OPEN("nMVAR")
            '                SqlCmd1.ExecuteNonQuery()
            '                DB_CLOSE()

            '                WK_str = WK_DtView1(0)("part_code") & " / " & WK_DtView1(0)("part_name") & " / " & Format(WK_DtView1(0)("part_amnt"), "##,##0") & " / " & WK_DtView1(0)("use_qty") & " / " & WK_DtView1(0)("shop_chrg") & " / " & WK_DtView1(0)("eu_chrg") & " / " & WK_DtView1(0)("ordr_no") & " / " & WK_DtView1(0)("ordr_no2") & " / " & WK_DtView1(0)("zaiko_flg")
            '                WK_str2 = WK_DtView2(0)("part_code") & " / " & WK_DtView2(0)("part_name") & " / " & Format(WK_DtView2(0)("part_amnt"), "##,##0") & " / " & WK_DtView2(0)("use_qty") & " / " & WK_DtView2(0)("shop_chrg") & " / " & WK_DtView2(0)("eu_chrg") & " / " & WK_DtView2(0)("ordr_no") & " / " & WK_DtView2(0)("ordr_no2") & " / " & WK_DtView2(0)("zaiko_flg")
            '                chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "äÆóπïîïi" & i, WK_str2, WK_str)
            '            End If
            '        End If
            '    End If
            'Next

            If chg_itm = 0 Then
                msg.Text = "ïœçXâ”èäÇ™Ç†ÇËÇ‹ÇπÇÒÅB"
            Else

                'rep_sql()   '** èCóùèÓïÒÇfÇdÇs(SQL)
                msg.Text = "çXêVÇµÇ‹ÇµÇΩÅB"

            End If
        End If
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
        HAITA_OFF(Edit000.Text)  'HAITA_OFF
        inz_dsp()   '**  èâä˙âÊñ ÉZÉbÉg
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
        DsCMB1.Clear()
        Close()
    End Sub
End Class
