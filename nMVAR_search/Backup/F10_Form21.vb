Public Class F10_Form21
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, DsCMB2, WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, DtView2, DtView3, WK_DtView1, WK_DtView2, WK_DtView3 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F, CSR_POS, CHG_F, ANS As String
    Dim i, r, en, Line_No, Line_No2, Line_No3, Line_No4, chg_itm, seq, WK_cnt, WK_tax As Integer
    Dim WK_str, WK_str2 As String
    Dim WK_int, WK_int2 As Integer

    'ïtëÆïi
    Private chkBox(99, 1) As CheckBox
    Private nbrBox(99, 1) As GrapeCity.Win.Input.Number
    Private edit(99, 2) As GrapeCity.Win.Input.Edit

    'åÃè·ì‡óe
    Private cmbBo_2(99, 1) As GrapeCity.Win.Input.Combo
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
    Friend WithEvents Panel_äÆóπ As System.Windows.Forms.Panel
    Friend WithEvents Label16_1 As System.Windows.Forms.Label
    Friend WithEvents Label15_1 As System.Windows.Forms.Label
    Friend WithEvents Label34_1 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Date013 As GrapeCity.Win.Input.Date
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
    Friend WithEvents Edit901 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit902 As GrapeCity.Win.Input.Edit
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
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label_K01 As System.Windows.Forms.Label
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Combo
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents Date_U003 As GrapeCity.Win.Input.Date
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Edit013 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo_K002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label_K02 As System.Windows.Forms.Label
    Friend WithEvents CL004 As System.Windows.Forms.Label
    Friend WithEvents CK_own_flg As System.Windows.Forms.CheckBox
    Friend WithEvents ZH As System.Windows.Forms.Label
    Friend WithEvents Button_K001 As System.Windows.Forms.Button
    Friend WithEvents CLU001 As System.Windows.Forms.Label
    Friend WithEvents Number001_nTax As GrapeCity.Win.Input.Number
    Friend WithEvents CheckBox_U002 As System.Windows.Forms.CheckBox
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Combo
    Friend WithEvents CheckBox_M001 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_K001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Combo_K003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Button97 As System.Windows.Forms.Button
    Friend WithEvents Date015 As GrapeCity.Win.Input.Date
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Date016 As GrapeCity.Win.Input.Date
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Date017 As GrapeCity.Win.Input.Date
    Friend WithEvents Label65 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F10_Form21))
        Me.Panel_éÛït = New System.Windows.Forms.Panel
        Me.CheckBox_U002 = New System.Windows.Forms.CheckBox
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
        Me.CheckBox_M001 = New System.Windows.Forms.CheckBox
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
        Me.Label12_1 = New System.Windows.Forms.Label
        Me.Label13_1 = New System.Windows.Forms.Label
        Me.Label14_1 = New System.Windows.Forms.Label
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
        Me.Edit_M001 = New GrapeCity.Win.Input.Edit
        Me.Label_M01 = New System.Windows.Forms.Label
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button0 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Panel_äÆóπ = New System.Windows.Forms.Panel
        Me.Label50 = New System.Windows.Forms.Label
        Me.Combo_K003 = New GrapeCity.Win.Input.Combo
        Me.CheckBox_K001 = New System.Windows.Forms.CheckBox
        Me.Button_K001 = New System.Windows.Forms.Button
        Me.Label_K02 = New System.Windows.Forms.Label
        Me.Combo_K002 = New GrapeCity.Win.Input.Combo
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
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Date013 = New GrapeCity.Win.Input.Date
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
        Me.Edit901 = New GrapeCity.Win.Input.Edit
        Me.Edit902 = New GrapeCity.Win.Input.Edit
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Number
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
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label28 = New System.Windows.Forms.Label
        Me.Edit013 = New GrapeCity.Win.Input.Edit
        Me.CL004 = New System.Windows.Forms.Label
        Me.CK_own_flg = New System.Windows.Forms.CheckBox
        Me.ZH = New System.Windows.Forms.Label
        Me.CLU001 = New System.Windows.Forms.Label
        Me.Number001_nTax = New GrapeCity.Win.Input.Number
        Me.Combo006 = New GrapeCity.Win.Input.Combo
        Me.Button97 = New System.Windows.Forms.Button
        Me.Date015 = New GrapeCity.Win.Input.Date
        Me.Label63 = New System.Windows.Forms.Label
        Me.Date016 = New GrapeCity.Win.Input.Date
        Me.Label64 = New System.Windows.Forms.Label
        Me.Date017 = New GrapeCity.Win.Input.Date
        Me.Label65 = New System.Windows.Forms.Label
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
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_äÆóπ.SuspendLayout()
        CType(Me.Combo_K003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_K002, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date016, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date017, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_éÛït
        '
        Me.Panel_éÛït.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_éÛït.Controls.Add(Me.CheckBox_U002)
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
        Me.Panel_éÛït.TabIndex = 25
        '
        'CheckBox_U002
        '
        Me.CheckBox_U002.AutoCheck = False
        Me.CheckBox_U002.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U002.Location = New System.Drawing.Point(948, 32)
        Me.CheckBox_U002.Name = "CheckBox_U002"
        Me.CheckBox_U002.Size = New System.Drawing.Size(28, 16)
        Me.CheckBox_U002.TabIndex = 1847
        Me.CheckBox_U002.TabStop = False
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
        Me.Date_U002.BackColor = System.Drawing.SystemColors.Control
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
        Me.Date_U002.TabIndex = 1513
        Me.Date_U002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Combo_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_U001.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U001.TabIndex = 1257
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
        Me.Edit_U004.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U004.LengthAsByte = True
        Me.Edit_U004.Location = New System.Drawing.Point(460, 220)
        Me.Edit_U004.Multiline = True
        Me.Edit_U004.Name = "Edit_U004"
        Me.Edit_U004.ReadOnly = True
        Me.Edit_U004.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
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
        Me.Combo_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_U002.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
        Me.Edit_U002.Name = "Edit_U002"
        Me.Edit_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U002.Size = New System.Drawing.Size(292, 20)
        Me.Edit_U002.TabIndex = 1259
        Me.Edit_U002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit_U005.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U005.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
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
        Me.Edit_U003.Name = "Edit_U003"
        Me.Edit_U003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U003.Size = New System.Drawing.Size(208, 20)
        Me.Edit_U003.TabIndex = 1260
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
        Me.Edit_U001.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U001.Enabled = False
        Me.Edit_U001.Format = "9#aA"
        Me.Edit_U001.HighlightText = True
        Me.Edit_U001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U001.LengthAsByte = True
        Me.Edit_U001.Location = New System.Drawing.Point(460, 4)
        Me.Edit_U001.Name = "Edit_U001"
        Me.Edit_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U001.Size = New System.Drawing.Size(208, 20)
        Me.Edit_U001.TabIndex = 1258
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
        Me.Label19_1.Location = New System.Drawing.Point(756, 4)
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
        Me.Date_U001.TabIndex = 1256
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
        Me.Date_U003.BackColor = System.Drawing.SystemColors.Control
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
        Me.Date_U003.TabIndex = 1831
        Me.Date_U003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U003.Value = Nothing
        '
        'Panel_å©êœ
        '
        Me.Panel_å©êœ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_å©êœ.Controls.Add(Me.CheckBox_M001)
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
        Me.Panel_å©êœ.Controls.Add(Me.Label12_1)
        Me.Panel_å©êœ.Controls.Add(Me.Label13_1)
        Me.Panel_å©êœ.Controls.Add(Me.Label14_1)
        Me.Panel_å©êœ.Controls.Add(Me.Combo_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M02)
        Me.Panel_å©êœ.Controls.Add(Me.Label33_1)
        Me.Panel_å©êœ.Controls.Add(Me.DataGrid_M1)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M04)
        Me.Panel_å©êœ.Controls.Add(Me.Combo_M003)
        Me.Panel_å©êœ.Controls.Add(Me.Edit_M001)
        Me.Panel_å©êœ.Controls.Add(Me.Label_M01)
        Me.Panel_å©êœ.Location = New System.Drawing.Point(10, 264)
        Me.Panel_å©êœ.Name = "Panel_å©êœ"
        Me.Panel_å©êœ.Size = New System.Drawing.Size(986, 372)
        Me.Panel_å©êœ.TabIndex = 26
        '
        'CheckBox_M001
        '
        Me.CheckBox_M001.AutoCheck = False
        Me.CheckBox_M001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox_M001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_M001.Location = New System.Drawing.Point(340, 304)
        Me.CheckBox_M001.Name = "CheckBox_M001"
        Me.CheckBox_M001.Size = New System.Drawing.Size(48, 52)
        Me.CheckBox_M001.TabIndex = 1855
        Me.CheckBox_M001.TabStop = False
        Me.CheckBox_M001.Text = "é©ìÆåvéZâèú"
        '
        'Number016
        '
        Me.Number016.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number015.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number025.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number024.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number017.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number040.Location = New System.Drawing.Point(868, 300)
        Me.Number040.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number040.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number040.Name = "Number040"
        Me.Number040.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number040.Size = New System.Drawing.Size(104, 20)
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
        Me.Number032.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number012.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number031.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number022.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number011.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number014.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number021.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number033.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number037.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number036.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number035.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number034.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number023.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number013.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number027.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number038.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number028.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number018.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number026.BackColor = System.Drawing.SystemColors.Control
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
        Me.Edit_M004.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
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
        Me.Edit_M003.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M003.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
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
        Me.Edit_M002.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M002.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M002.Size = New System.Drawing.Size(488, 60)
        Me.Edit_M002.TabIndex = 923
        Me.Edit_M002.TabStop = False
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
        Me.Combo_M001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_M001.Size = New System.Drawing.Size(200, 20)
        Me.Combo_M001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
        Me.Combo_M003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_M003.Size = New System.Drawing.Size(132, 20)
        Me.Combo_M003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_M003.TabIndex = 1503
        Me.Combo_M003.Value = "Combo_M003"
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
        Me.Edit_M001.Name = "Edit_M001"
        Me.Edit_M001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M001.Size = New System.Drawing.Size(200, 20)
        Me.Edit_M001.TabIndex = 910
        Me.Edit_M001.TabStop = False
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
        'Button80
        '
        Me.Button80.BackColor = System.Drawing.SystemColors.Control
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Enabled = False
        Me.Button80.Location = New System.Drawing.Point(816, 660)
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
        Me.Button98.Location = New System.Drawing.Point(916, 660)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1030
        Me.Button98.Text = "ñﬂÇÈ"
        '
        'Panel_äÆóπ
        '
        Me.Panel_äÆóπ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_äÆóπ.Controls.Add(Me.Label50)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K003)
        Me.Panel_äÆóπ.Controls.Add(Me.CheckBox_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.Button_K001)
        Me.Panel_äÆóπ.Controls.Add(Me.Label_K02)
        Me.Panel_äÆóπ.Controls.Add(Me.Combo_K002)
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
        Me.Panel_äÆóπ.Location = New System.Drawing.Point(10, 264)
        Me.Panel_äÆóπ.Name = "Panel_äÆóπ"
        Me.Panel_äÆóπ.Size = New System.Drawing.Size(986, 372)
        Me.Panel_äÆóπ.TabIndex = 5
        Me.Panel_äÆóπ.TabStop = True
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Navy
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(864, 280)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(108, 20)
        Me.Label50.TabIndex = 1864
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
        Me.Combo_K003.TabIndex = 1863
        Me.Combo_K003.Value = "Combo_K003"
        '
        'CheckBox_K001
        '
        Me.CheckBox_K001.AutoCheck = False
        Me.CheckBox_K001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox_K001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_K001.Location = New System.Drawing.Point(340, 304)
        Me.CheckBox_K001.Name = "CheckBox_K001"
        Me.CheckBox_K001.Size = New System.Drawing.Size(48, 52)
        Me.CheckBox_K001.TabIndex = 1858
        Me.CheckBox_K001.TabStop = False
        Me.CheckBox_K001.Text = "é©ìÆåvéZâèú"
        '
        'Button_K001
        '
        Me.Button_K001.BackColor = System.Drawing.SystemColors.Control
        Me.Button_K001.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_K001.Enabled = False
        Me.Button_K001.Location = New System.Drawing.Point(904, 8)
        Me.Button_K001.Name = "Button_K001"
        Me.Button_K001.Size = New System.Drawing.Size(72, 20)
        Me.Button_K001.TabIndex = 1857
        Me.Button_K001.TabStop = False
        Me.Button_K001.Text = "ïîïiì¸óÕ"
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
        Me.Combo_K002.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_K002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_K002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_K002.Enabled = False
        Me.Combo_K002.Location = New System.Drawing.Point(408, 4)
        Me.Combo_K002.MaxDropDownItems = 20
        Me.Combo_K002.Name = "Combo_K002"
        Me.Combo_K002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_K002.Size = New System.Drawing.Size(168, 20)
        Me.Combo_K002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K002.TabIndex = 15
        Me.Combo_K002.Value = "Combo_K002"
        '
        'Number116
        '
        Me.Number116.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number116.TabIndex = 1736
        Me.Number116.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number116.Value = Nothing
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
        Me.Number115.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number115.TabIndex = 1735
        Me.Number115.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number115.Value = Nothing
        '
        'Number125
        '
        Me.Number125.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number125.TabIndex = 1742
        Me.Number125.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number125.Value = Nothing
        '
        'Number124
        '
        Me.Number124.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number124.TabIndex = 1741
        Me.Number124.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number124.Value = Nothing
        '
        'Number117
        '
        Me.Number117.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number117.TabIndex = 1737
        Me.Number117.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number117.Value = Nothing
        '
        'Number132
        '
        Me.Number132.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number132.TabIndex = 70
        Me.Number132.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number132.Value = Nothing
        '
        'Number112
        '
        Me.Number112.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number112.TabIndex = 1732
        Me.Number112.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number112.Value = Nothing
        '
        'Number131
        '
        Me.Number131.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number131.TabIndex = 60
        Me.Number131.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number131.Value = Nothing
        '
        'Number122
        '
        Me.Number122.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number122.TabIndex = 1739
        Me.Number122.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number122.Value = Nothing
        '
        'Number111
        '
        Me.Number111.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number111.TabIndex = 1731
        Me.Number111.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number111.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        '
        'Number114
        '
        Me.Number114.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number114.TabIndex = 1734
        Me.Number114.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number114.Value = Nothing
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
        Me.Number121.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number121.TabIndex = 1738
        Me.Number121.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number121.Value = Nothing
        '
        'Number133
        '
        Me.Number133.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number133.TabIndex = 80
        Me.Number133.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number133.Value = Nothing
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
        Me.Number137.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number137.TabIndex = 1751
        Me.Number137.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number137.Value = Nothing
        '
        'Number136
        '
        Me.Number136.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number136.TabIndex = 1750
        Me.Number136.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number136.Value = Nothing
        '
        'Number135
        '
        Me.Number135.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number135.TabIndex = 100
        Me.Number135.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number135.Value = Nothing
        '
        'Number134
        '
        Me.Number134.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number134.TabIndex = 90
        Me.Number134.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number134.Value = Nothing
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
        Me.Number123.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number123.TabIndex = 1740
        Me.Number123.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number123.Value = Nothing
        '
        'Number113
        '
        Me.Number113.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number113.TabIndex = 1733
        Me.Number113.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number113.Value = Nothing
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
        Me.Number127.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number127.TabIndex = 1744
        Me.Number127.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number127.Value = Nothing
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
        Me.Number138.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number138.TabIndex = 1766
        Me.Number138.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number138.Value = Nothing
        '
        'Number128
        '
        Me.Number128.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number128.TabIndex = 1765
        Me.Number128.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number128.Value = Nothing
        '
        'Number118
        '
        Me.Number118.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number118.TabIndex = 1764
        Me.Number118.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number118.Value = Nothing
        '
        'Number126
        '
        Me.Number126.BackColor = System.Drawing.SystemColors.Control
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
        Me.Number126.TabIndex = 1743
        Me.Number126.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number126.Value = Nothing
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
        Me.Combo_K001.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_K001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_K001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_K001.Enabled = False
        Me.Combo_K001.Location = New System.Drawing.Point(88, 4)
        Me.Combo_K001.MaxDropDownItems = 20
        Me.Combo_K001.Name = "Combo_K001"
        Me.Combo_K001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_K001.Size = New System.Drawing.Size(192, 20)
        Me.Combo_K001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_K001.TabIndex = 10
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
        Me.Panel_K1.TabIndex = 20
        '
        'Edit_K002
        '
        Me.Edit_K002.AcceptsReturn = True
        Me.Edit_K002.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_K002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit_K002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_K002.LengthAsByte = True
        Me.Edit_K002.Location = New System.Drawing.Point(88, 192)
        Me.Edit_K002.Multiline = True
        Me.Edit_K002.Name = "Edit_K002"
        Me.Edit_K002.ReadOnly = True
        Me.Edit_K002.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_K002.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_K002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_K002.Size = New System.Drawing.Size(460, 76)
        Me.Edit_K002.TabIndex = 40
        '
        'Edit_K001
        '
        Me.Edit_K001.AcceptsReturn = True
        Me.Edit_K001.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_K001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit_K001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_K001.LengthAsByte = True
        Me.Edit_K001.Location = New System.Drawing.Point(88, 132)
        Me.Edit_K001.Multiline = True
        Me.Edit_K001.Name = "Edit_K001"
        Me.Edit_K001.ReadOnly = True
        Me.Edit_K001.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_K001.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_K001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_K001.Size = New System.Drawing.Size(488, 60)
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
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(64, 244)
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
        Me.Button13.Location = New System.Drawing.Point(112, 244)
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
        Me.Button11.Location = New System.Drawing.Point(16, 244)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(48, 20)
        Me.Button11.TabIndex = 22
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
        Me.Date013.BackColor = System.Drawing.SystemColors.Control
        Me.Date013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date013.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date013.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date013.Enabled = False
        Me.Date013.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date013.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date013.Location = New System.Drawing.Point(904, 228)
        Me.Date013.Name = "Date013"
        Me.Date013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date013.Size = New System.Drawing.Size(88, 20)
        Me.Date013.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date013.TabIndex = 1369
        Me.Date013.TabStop = False
        Me.Date013.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date013.Value = Nothing
        '
        'Date011
        '
        Me.Date011.BackColor = System.Drawing.SystemColors.Control
        Me.Date011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date011.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date011.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date011.Enabled = False
        Me.Date011.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date011.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date011.Location = New System.Drawing.Point(904, 188)
        Me.Date011.Name = "Date011"
        Me.Date011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date011.Size = New System.Drawing.Size(112, 20)
        Me.Date011.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date011.TabIndex = 1366
        Me.Date011.TabStop = False
        Me.Date011.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Date007.BackColor = System.Drawing.SystemColors.Control
        Me.Date007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date007.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date007.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date007.Enabled = False
        Me.Date007.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date007.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date007.Location = New System.Drawing.Point(904, 88)
        Me.Date007.Name = "Date007"
        Me.Date007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date007.Size = New System.Drawing.Size(88, 20)
        Me.Date007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date007.TabIndex = 1364
        Me.Date007.TabStop = False
        Me.Date007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date007.Value = Nothing
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Navy
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(824, 108)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(80, 20)
        Me.Label44.TabIndex = 1363
        Me.Label44.Text = "ïîïiéÛóÃì˙"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date006
        '
        Me.Date006.BackColor = System.Drawing.SystemColors.Control
        Me.Date006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date006.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date006.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date006.Enabled = False
        Me.Date006.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date006.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date006.Location = New System.Drawing.Point(904, 68)
        Me.Date006.Name = "Date006"
        Me.Date006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date006.Size = New System.Drawing.Size(88, 20)
        Me.Date006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date006.TabIndex = 1362
        Me.Date006.TabStop = False
        Me.Date006.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date006.Value = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(824, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 20)
        Me.Label14.TabIndex = 1361
        Me.Label14.Text = "ïîïiî≠íçì˙"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date012
        '
        Me.Date012.BackColor = System.Drawing.SystemColors.Control
        Me.Date012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date012.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date012.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date012.Enabled = False
        Me.Date012.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date012.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date012.Location = New System.Drawing.Point(904, 208)
        Me.Date012.Name = "Date012"
        Me.Date012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date012.Size = New System.Drawing.Size(112, 20)
        Me.Date012.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date012.TabIndex = 1360
        Me.Date012.TabStop = False
        Me.Date012.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date012.Value = Nothing
        '
        'Date010
        '
        Me.Date010.BackColor = System.Drawing.SystemColors.Control
        Me.Date010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date010.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date010.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date010.Enabled = False
        Me.Date010.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date010.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date010.Location = New System.Drawing.Point(904, 168)
        Me.Date010.Name = "Date010"
        Me.Date010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date010.Size = New System.Drawing.Size(112, 20)
        Me.Date010.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date010.TabIndex = 1359
        Me.Date010.TabStop = False
        Me.Date010.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date010.Value = Nothing
        '
        'Date008
        '
        Me.Date008.BackColor = System.Drawing.SystemColors.Control
        Me.Date008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date008.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date008.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date008.Enabled = False
        Me.Date008.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date008.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date008.Location = New System.Drawing.Point(904, 108)
        Me.Date008.Name = "Date008"
        Me.Date008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date008.Size = New System.Drawing.Size(88, 20)
        Me.Date008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date008.TabIndex = 1357
        Me.Date008.TabStop = False
        Me.Date008.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date008.Value = Nothing
        '
        'Date004
        '
        Me.Date004.BackColor = System.Drawing.SystemColors.Control
        Me.Date004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date004.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date004.Enabled = False
        Me.Date004.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date004.Location = New System.Drawing.Point(904, 48)
        Me.Date004.Name = "Date004"
        Me.Date004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date004.Size = New System.Drawing.Size(88, 20)
        Me.Date004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date004.TabIndex = 57
        Me.Date004.TabStop = False
        Me.Date004.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date004.Value = Nothing
        '
        'Date003
        '
        Me.Date003.BackColor = System.Drawing.SystemColors.Control
        Me.Date003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date003.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date003.Enabled = False
        Me.Date003.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date003.Location = New System.Drawing.Point(904, 8)
        Me.Date003.Name = "Date003"
        Me.Date003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date003.Size = New System.Drawing.Size(112, 20)
        Me.Date003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date003.TabIndex = 56
        Me.Date003.TabStop = False
        Me.Date003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Label41.Location = New System.Drawing.Point(824, 248)
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
        Me.Edit010.Enabled = False
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(520, 192)
        Me.Edit010.Name = "Edit010"
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(300, 20)
        Me.Edit010.TabIndex = 15
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
        Me.Edit009.Name = "Edit009"
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(300, 20)
        Me.Edit009.TabIndex = 14
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
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(76, 20)
        Me.Mask1.TabIndex = 13
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
        Me.Edit901.TabIndex = 1412
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
        Me.Edit902.TabIndex = 1411
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
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(184, 20)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(196, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
        Me.Combo001.BackColor = System.Drawing.SystemColors.Control
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Enabled = False
        Me.Combo001.Location = New System.Drawing.Point(96, 32)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
        Me.Combo004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo004.Size = New System.Drawing.Size(164, 20)
        Me.Combo004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo004.TabIndex = 19
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
        Me.Edit006.BackColor = System.Drawing.SystemColors.Control
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Enabled = False
        Me.Edit006.Format = "KAa"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(96, 172)
        Me.Edit006.Name = "Edit006"
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(196, 20)
        Me.Edit006.TabIndex = 10
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
        Me.Edit008.Name = "Edit008"
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(112, 20)
        Me.Edit008.TabIndex = 12
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
        Me.Edit007.Name = "Edit007"
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(112, 20)
        Me.Edit007.TabIndex = 11
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
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(196, 20)
        Me.Edit005.TabIndex = 9
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
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(112, 20)
        Me.Edit004.TabIndex = 8
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
        Me.Edit002.BackColor = System.Drawing.SystemColors.Control
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.Enabled = False
        Me.Edit002.Format = "9"
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(96, 104)
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(48, 20)
        Me.Edit002.TabIndex = 7
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
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(48, 20)
        Me.Edit001.TabIndex = 5
        Me.Edit001.Text = "9999"
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(112, 20)
        Me.Edit003.TabIndex = 6
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit011.Name = "Edit011"
        Me.Edit011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit011.Size = New System.Drawing.Size(92, 20)
        Me.Edit011.TabIndex = 1425
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
        Me.Edit012.BackColor = System.Drawing.SystemColors.Control
        Me.Edit012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit012.Enabled = False
        Me.Edit012.Format = "9A#"
        Me.Edit012.HighlightText = True
        Me.Edit012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit012.LengthAsByte = True
        Me.Edit012.Location = New System.Drawing.Point(568, 216)
        Me.Edit012.Name = "Edit012"
        Me.Edit012.ReadOnly = True
        Me.Edit012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit012.Size = New System.Drawing.Size(116, 20)
        Me.Edit012.TabIndex = 1795
        Me.Edit012.TabStop = False
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
        Me.Number002.TabIndex = 1802
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
        Me.Number001.Location = New System.Drawing.Point(776, 16)
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
        'Date001
        '
        Me.Date001.BackColor = System.Drawing.SystemColors.Control
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
        Me.Date001.TabIndex = 1823
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
        Me.Combo005.TabIndex = 1829
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
        Me.Number003.TabIndex = 1827
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
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(400, 660)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(72, 24)
        Me.Button7.TabIndex = 1836
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
        Me.Edit013.Name = "Edit013"
        Me.Edit013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit013.Size = New System.Drawing.Size(284, 20)
        Me.Edit013.TabIndex = 1837
        Me.Edit013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'CL004
        '
        Me.CL004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL004.Location = New System.Drawing.Point(444, 248)
        Me.CL004.Name = "CL004"
        Me.CL004.Size = New System.Drawing.Size(52, 16)
        Me.CL004.TabIndex = 1860
        Me.CL004.Text = "CL004"
        Me.CL004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL004.Visible = False
        '
        'CK_own_flg
        '
        Me.CK_own_flg.AutoCheck = False
        Me.CK_own_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CK_own_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CK_own_flg.Location = New System.Drawing.Point(568, 244)
        Me.CK_own_flg.Name = "CK_own_flg"
        Me.CK_own_flg.Size = New System.Drawing.Size(84, 16)
        Me.CK_own_flg.TabIndex = 1854
        Me.CK_own_flg.TabStop = False
        Me.CK_own_flg.Text = "CK_own_flg"
        Me.CK_own_flg.Visible = False
        '
        'ZH
        '
        Me.ZH.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.ZH.Location = New System.Drawing.Point(616, 664)
        Me.ZH.Name = "ZH"
        Me.ZH.Size = New System.Drawing.Size(48, 16)
        Me.ZH.TabIndex = 1843
        Me.ZH.Text = "ZH"
        Me.ZH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ZH.Visible = False
        '
        'CLU001
        '
        Me.CLU001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU001.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CLU001.Location = New System.Drawing.Point(516, 240)
        Me.CLU001.Name = "CLU001"
        Me.CLU001.Size = New System.Drawing.Size(48, 16)
        Me.CLU001.TabIndex = 1846
        Me.CLU001.Text = "CLU001"
        Me.CLU001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU001.Visible = False
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
        Me.Number001_nTax.Location = New System.Drawing.Point(732, 36)
        Me.Number001_nTax.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001_nTax.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001_nTax.Name = "Number001_nTax"
        Me.Number001_nTax.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001_nTax.Size = New System.Drawing.Size(52, 20)
        Me.Number001_nTax.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001_nTax.TabIndex = 1861
        Me.Number001_nTax.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001_nTax.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Combo006
        '
        Me.Combo006.BackColor = System.Drawing.SystemColors.Control
        Me.Combo006.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo006.Enabled = False
        Me.Combo006.Location = New System.Drawing.Point(904, 248)
        Me.Combo006.MaxDropDownItems = 2
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(88, 20)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 1862
        Me.Combo006.TabStop = False
        Me.Combo006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo006.Value = ""
        '
        'Button97
        '
        Me.Button97.BackColor = System.Drawing.SystemColors.Control
        Me.Button97.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button97.Location = New System.Drawing.Point(736, 660)
        Me.Button97.Name = "Button97"
        Me.Button97.Size = New System.Drawing.Size(68, 24)
        Me.Button97.TabIndex = 1020
        Me.Button97.Text = "S/Nóöó"
        Me.Button97.Visible = False
        '
        'Date015
        '
        Me.Date015.BackColor = System.Drawing.SystemColors.Control
        Me.Date015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date015.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date015.Enabled = False
        Me.Date015.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date015.Location = New System.Drawing.Point(904, 28)
        Me.Date015.Name = "Date015"
        Me.Date015.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date015.Size = New System.Drawing.Size(112, 20)
        Me.Date015.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date015.TabIndex = 1898
        Me.Date015.TabStop = False
        Me.Date015.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Label63.TabIndex = 1899
        Me.Label63.Text = "êfífì˙"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date016
        '
        Me.Date016.BackColor = System.Drawing.SystemColors.Control
        Me.Date016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date016.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date016.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date016.Enabled = False
        Me.Date016.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date016.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date016.Location = New System.Drawing.Point(904, 128)
        Me.Date016.Name = "Date016"
        Me.Date016.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date016.Size = New System.Drawing.Size(112, 20)
        Me.Date016.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date016.TabIndex = 1901
        Me.Date016.TabStop = False
        Me.Date016.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Label64.TabIndex = 1900
        Me.Label64.Text = "èCóùì˙"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date017
        '
        Me.Date017.BackColor = System.Drawing.SystemColors.Control
        Me.Date017.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date017.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date017.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date017.Enabled = False
        Me.Date017.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date017.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date017.Location = New System.Drawing.Point(904, 148)
        Me.Date017.Name = "Date017"
        Me.Date017.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date017.Size = New System.Drawing.Size(112, 20)
        Me.Date017.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date017.TabIndex = 1902
        Me.Date017.TabStop = False
        Me.Date017.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Label65.TabIndex = 1903
        Me.Label65.Text = "äÆóπòAóçì˙"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F10_Form21
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1030, 688)
        Me.Controls.Add(Me.Date017)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Date016)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Date015)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.Button97)
        Me.Controls.Add(Me.Panel_äÆóπ)
        Me.Controls.Add(Me.Panel_å©êœ)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.Panel_éÛït)
        Me.Controls.Add(Me.Number001_nTax)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Edit013)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Combo005)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Number002)
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
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.CLU001)
        Me.Controls.Add(Me.ZH)
        Me.Controls.Add(Me.CL004)
        Me.Controls.Add(Me.CK_own_flg)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F10_Form21"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "è∆âÔ"
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
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_äÆóπ.ResumeLayout(False)
        CType(Me.Combo_K003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_K002, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date016, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date017, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  ãNìÆéû
    '********************************************************************
    Private Sub F10_Form21_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()
        inz()       '**  èâä˙èàóù
        inz_dsp()   '**  èâä˙âÊñ ÉZÉbÉg
    End Sub

    '********************************************************************
    '**  èâä˙èàóù
    '********************************************************************
    Sub inz()
        'Å~ï¬Ç∂ÇÈÇégópïsâ¬
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  èâä˙âÊñ 
    '********************************************************************
    Sub inz_dsp()

        'ã§í 
        msg.Text = Nothing
        Button0.Enabled = True
        Button2.Enabled = False
        Button7.Enabled = False
        Button80.Enabled = False

        Edit000.Text = Nothing  'éÛïtî‘çÜ
        Edit000.ReadOnly = False : Edit000.TabStop = True : Edit000.BackColor = System.Drawing.SystemColors.Window

        Combo001.Text = Nothing : Combo002.Text = Nothing : Combo003.Text = Nothing : Combo004.Text = Nothing : Combo005.Text = Nothing
        Combo006.Text = Nothing
        Edit901.Text = Nothing : Edit902.Text = Nothing
        Date003.Text = Nothing : Date004.Text = Nothing : Date006.Text = Nothing : Date007.Text = Nothing
        Date008.Text = Nothing : Date010.Text = Nothing : Date011.Text = Nothing : Date012.Text = Nothing
        Date013.Text = Nothing : Edit001.Text = Nothing : Edit002.Text = Nothing : Edit003.Text = Nothing
        Edit004.Text = Nothing : Edit005.Text = Nothing : Edit006.Text = Nothing : Edit007.Text = Nothing
        Edit008.Text = Nothing : Edit009.Text = Nothing : Edit010.Text = Nothing : Edit011.Text = Nothing
        Edit012.Text = Nothing : Edit013.Text = Nothing
        Mask1.Text = Nothing

        Number001.Value = 0 : Number001_nTax.Value = 0 : Number002.Value = 0 : Number003.Value = 0
        Label5.Text = Nothing

        Label21.Visible = True : Edit011.Visible = True : Label5.Visible = True
        Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
        Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
        Label001.Visible = True : Label002.Visible = True : Label003.Visible = True : Label004.Visible = True : Label005.Visible = True : Label006.Visible = True : Label007.Visible = True
        Edit001.Visible = True : Edit002.Visible = True : Edit003.Visible = True : Edit004.Visible = True : Date001.Visible = True

        Label001.Text = Nothing : Label002.Text = Nothing

        'éÛït
        Date_U001.Text = Nothing : Date_U002.Text = Nothing : Date_U003.Text = Nothing
        Combo_U001.Text = Nothing : Combo_U002.Text = Nothing
        Edit_U001.Text = Nothing : Edit_U002.Text = Nothing : Edit_U003.Text = Nothing : Edit_U004.Text = Nothing : Edit_U005.Text = Nothing
        CheckBox_U001.Checked = False
        CheckBox_U002.Checked = False
        Panel_U1.Controls.Clear()
        Panel_U2.Controls.Clear()

        'å©êœ
        Edit_M001.Text = Nothing : Edit_M002.Text = Nothing : Edit_M003.Text = Nothing : Edit_M004.Text = Nothing : Combo_M001.Text = Nothing
        Combo_M003.Text = Nothing
        CheckBox_M001.Checked = False
        Number011.Value = 0 : Number012.Value = 0 : Number013.Value = 0 : Number014.Value = 0 : Number015.Value = 0 : Number016.Value = 0 : Number017.Value = 0 : Number018.Value = 0
        Number021.Value = 0 : Number022.Value = 0 : Number023.Value = 0 : Number024.Value = 0 : Number025.Value = 0 : Number026.Value = 0 : Number027.Value = 0 : Number028.Value = 0
        Number031.Value = 0 : Number032.Value = 0 : Number033.Value = 0 : Number034.Value = 0 : Number035.Value = 0 : Number036.Value = 0 : Number037.Value = 0 : Number038.Value = 0
        Number040.Value = 0

        Panel_M1.Controls.Clear()
        P_DsList1.Clear()
        DsList1.Clear()

        'äÆóπ
        Combo_K001.Text = Nothing : Combo_K002.Text = Nothing : Combo_K003.Text = Nothing
        Edit_K001.Text = Nothing : Edit_K002.Text = Nothing
        CheckBox_K001.Checked = False
        Number111.Value = 0 : Number112.Value = 0 : Number113.Value = 0 : Number114.Value = 0 : Number115.Value = 0 : Number116.Value = 0 : Number117.Value = 0 : Number118.Value = 0
        Number121.Value = 0 : Number122.Value = 0 : Number123.Value = 0 : Number124.Value = 0 : Number125.Value = 0 : Number126.Value = 0 : Number127.Value = 0 : Number128.Value = 0
        Number131.Value = 0 : Number132.Value = 0 : Number133.Value = 0 : Number134.Value = 0 : Number135.Value = 0 : Number136.Value = 0 : Number137.Value = 0 : Number138.Value = 0

        Button_M001.Enabled = False
        Button_K001.Enabled = False
        Panel_K1.Controls.Clear()

        Edit000.Focus()
    End Sub

    '********************************************************************
    '**  éÛïtî‘çÜEnter
    '********************************************************************
    Private Sub Edit000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Edit000.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button13_Click(sender, e)
            rep_scan()  '** èCóùèÓïÒÇfÇdÇs
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

        WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "seq", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                WK_DtView1(i)("ID_NO") = i
            Next
        End If

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

        WK_DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "", "seq", DataViewRowState.CurrentRows)
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
            Button2.Enabled = True
            Button7.Enabled = True
            Button80.Enabled = True

            Edit000.ReadOnly = True : Edit000.TabStop = False : Edit000.BackColor = System.Drawing.SystemColors.Control
            Edit901.Text = DtView1(0)("rcpt_ent_empl_name")
            Edit902.Text = DtView1(0)("rcpt_brch_name")

            Date003.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView1(0)("accp_date"))

            Combo001.Text = DtView1(0)("rcpt_name")
            If DtView1(0)("cls_code_name_abbr") = "QGNo" Then
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
            Else
                Label21.Visible = False : Edit011.Visible = False : Label5.Visible = False : Edit011.Text = Nothing 'QG No
                Label10.Visible = False : Number001_nTax.Visible = False : Label16.Visible = False
                Label15.Visible = False : Number003.Visible = False : Label17.Visible = False
                Label5.Text = Nothing
            End If

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
            If Not IsDBNull(DtView1(0)("store_code")) Then Edit001.Text = DtView1(0)("store_code") Else Edit001.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_name")) Then Label001.Text = DtView1(0)("store_name") Else Label001.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_code")) Then Edit002.Text = DtView1(0)("dlvr_code") Else Edit002.Text = Nothing
            If Not IsDBNull(DtView1(0)("dlvr_name")) Then Label002.Text = DtView1(0)("dlvr_name") Else Label002.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_prsn")) Then Edit003.Text = DtView1(0)("store_prsn") Else Edit003.Text = Nothing
            If Not IsDBNull(DtView1(0)("store_repr_no")) Then Edit004.Text = DtView1(0)("store_repr_no") Else Edit004.Text = Nothing
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
            Combo_U002.Text = DtView1(0)("rpar_comp_name")
            If DtView1(0)("own_flg") = "1" Then CK_own_flg.Checked = True Else CK_own_flg.Checked = False

            Edit_U001.Text = DtView1(0)("model_2")
            Edit_U002.Text = DtView1(0)("model_1")
            Edit_U003.Text = DtView1(0)("s_n")
            Edit_U004.Text = DtView1(0)("user_trbl")
            Edit_U005.Text = DtView1(0)("rcpt_comn")

            If DtView1(0)("note_kbn") = "01" Then CheckBox_U001.Checked = True Else CheckBox_U001.Checked = False

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
                    If Trim(WK_DtView2(Line_No)("item_unit")) = Nothing Then
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
            If Not IsDBNull(DtView2(0)("etmt_date")) Then Date004.Text = DtView2(0)("etmt_date")

            If Not IsDBNull(DtView2(0)("etmt_empl_name")) Then Combo_M001.Text = DtView2(0)("etmt_empl_name") Else Combo_M001.Text = Nothing
            If Not IsDBNull(DtView2(0)("tier_name")) Then Combo_M003.Text = DtView2(0)("tier_name") Else Combo_M003.Text = Nothing
            If CK_own_flg.Checked = True Then    'é©é–èCóù
                Edit_M001.Visible = False : Label_M01.Visible = False

                'Combo_M003.Visible = True : Label_M04.Visible = True
            Else
                Edit_M001.Visible = True : Label_M01.Visible = True

                'Combo_M003.Visible = False : Label_M04.Visible = False
                If Not IsDBNull(DtView2(0)("vndr_repr_no")) Then Edit_M001.Text = DtView2(0)("vndr_repr_no") Else Edit_M001.Text = Nothing
            End If

            If Not IsDBNull(DtView2(0)("etmt_meas")) Then Edit_M002.Text = DtView2(0)("etmt_meas") Else Edit_M002.Text = Nothing
            If Not IsDBNull(DtView2(0)("etmt_comn")) Then Edit_M003.Text = DtView2(0)("etmt_comn") Else Edit_M003.Text = Nothing

            If Not IsDBNull(DtView2(0)("rsrv_cacl_comn")) Then Edit_M004.Text = DtView2(0)("rsrv_cacl_comn") Else Edit_M004.Text = Nothing

            If Not IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then Number031.Value = DtView2(0)("etmt_cost_tech_chrg") Else Number031.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_part_chrg")) Then Number033.Value = DtView2(0)("etmt_cost_part_chrg") Else Number033.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_fee")) Then Number034.Value = DtView2(0)("etmt_cost_fee") Else Number034.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_pstg")) Then Number035.Value = DtView2(0)("etmt_cost_pstg") Else Number035.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_tax")) Then Number037.Value = DtView2(0)("etmt_cost_tax") Else Number037.Value = 0
            Number036.Value = Number031.Value + Number033.Value + Number034.Value + Number035.Value
            Number038.Value = Number036.Value + Number037.Value
            If Not IsDBNull(DtView2(0)("etmt_cost_cxl")) Then Number040.Value = DtView2(0)("etmt_cost_cxl") Else Number040.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_apes")) Then Number032.Value = DtView2(0)("etmt_cost_apes") Else Number032.Value = 0
            'If CK_own_flg.Checked = False Then Number032.Value = 0

            If Not IsDBNull(DtView2(0)("etmt_shop_tech_chrg")) Then Number011.Value = DtView2(0)("etmt_shop_tech_chrg") Else Number011.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_apes")) Then Number012.Value = DtView2(0)("etmt_shop_apes") Else Number012.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_part_chrg")) Then Number013.Value = DtView2(0)("etmt_shop_part_chrg") Else Number013.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_fee")) Then Number014.Value = DtView2(0)("etmt_shop_fee") Else Number014.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_pstg")) Then Number015.Value = DtView2(0)("etmt_shop_pstg") Else Number015.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_shop_tax")) Then Number017.Value = DtView2(0)("etmt_shop_tax") Else Number017.Value = 0
            Number016.Value = Number011.Value + Number013.Value + Number014.Value + Number015.Value
            Number018.Value = Number016.Value + Number017.Value

            If Not IsDBNull(DtView2(0)("etmt_eu_tech_chrg")) Then Number021.Value = DtView2(0)("etmt_eu_tech_chrg") Else Number021.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_apes")) Then Number022.Value = DtView2(0)("etmt_eu_apes") Else Number022.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_part_chrg")) Then Number023.Value = DtView2(0)("etmt_eu_part_chrg") Else Number023.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_fee")) Then Number024.Value = DtView2(0)("etmt_eu_fee") Else Number024.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_pstg")) Then Number025.Value = DtView2(0)("etmt_eu_pstg") Else Number025.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_eu_tax")) Then Number027.Value = DtView2(0)("etmt_eu_tax") Else Number027.Value = 0
            Number026.Value = Number021.Value + Number023.Value + Number024.Value + Number025.Value
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
            'If CK_own_flg.Checked = True Then    'é©é–èCóù
            '    Combo_K001.Visible = True : Label_K01.Visible = True
            'Else
            '    Combo_K001.Visible = False : Label_K01.Visible = False
            'End If
            Select Case CL004.Text
                Case Is = "02", "04"   'ÉÅÅ[ÉJÅ[ï€èÿÅAÇªÇÃëºï€èÿ
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
                Combo006.DropDown.Visible = GrapeCity.Win.Input.Visibility.ShowAlways
            Else
                Combo006.DropDown.Visible = GrapeCity.Win.Input.Visibility.NotShown
            End If

            If Not IsDBNull(DtView3(0)("part_ordr_date")) Then Date007.Text = DtView3(0)("part_ordr_date")
            If Not IsDBNull(DtView3(0)("part_rcpt_date")) Then Date008.Text = DtView3(0)("part_rcpt_date")
            If Not IsDBNull(DtView3(0)("comp_date")) Then Date010.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("comp_date"))
            If Not IsDBNull(DtView3(0)("sals_date")) Then Date011.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("sals_date"))
            If Not IsDBNull(DtView3(0)("ship_date")) Then Date012.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("ship_date"))
            If Not IsDBNull(DtView3(0)("rqst_date")) Then Date013.Text = DtView3(0)("rqst_date")

            If Not IsDBNull(DtView3(0)("sindan_date")) Then Date015.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("sindan_date"))
            If Not IsDBNull(DtView3(0)("rep_date")) Then Date016.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("rep_date")) ' Date016.Text = DtView3(0)("rep_date")
            If Not IsDBNull(DtView3(0)("renraku_date")) Then Date017.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView3(0)("renraku_date")) ' Date017.Text = DtView3(0)("renraku_date")


            If Not IsDBNull(DtView3(0)("repr_empl_name")) Then Combo_K001.Text = DtView3(0)("repr_empl_name") Else Combo_K001.Text = Nothing
            If Not IsDBNull(DtView3(0)("select_case")) Then Combo_K002.Text = DtView3(0)("select_case") Else Combo_K002.Text = Nothing
            If Not IsDBNull(DtView3(0)("kjo_brch_name")) Then Combo_K003.Text = DtView3(0)("kjo_brch_name") Else Combo_K003.Text = Nothing

            If Not IsDBNull(DtView3(0)("comp_meas")) Then Edit_K001.Text = DtView3(0)("comp_meas")
            If Not IsDBNull(DtView3(0)("comp_comn")) Then Edit_K002.Text = DtView3(0)("comp_comn")

            If IsDBNull(DtView3(0)("comp_cost_tech_chrg")) And ZH.Text = "H" Then
                Number131.Value = Number040.Value
                Number133.Value = 0
                Number113.Value = 0
                Number123.Value = 0
            Else
                If Not IsDBNull(DtView3(0)("comp_cost_tech_chrg")) Then Number131.Value = DtView3(0)("comp_cost_tech_chrg") Else Number131.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_apes")) Then Number132.Value = DtView3(0)("comp_cost_apes") Else Number132.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_part_chrg")) Then Number133.Value = DtView3(0)("comp_cost_part_chrg") Else Number133.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_fee")) Then Number134.Value = DtView3(0)("comp_cost_fee") Else Number134.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_pstg")) Then Number135.Value = DtView3(0)("comp_cost_pstg") Else Number135.Value = 0
                If Not IsDBNull(DtView3(0)("comp_cost_tax")) Then Number137.Value = DtView3(0)("comp_cost_tax") Else Number137.Value = 0
                If CK_own_flg.Checked = False Then Number132.Value = 0
                Number136.Value = Number131.Value + Number132.Value + Number133.Value + Number134.Value + Number135.Value
                Number138.Value = Number136.Value + Number137.Value

                If Not IsDBNull(DtView3(0)("comp_shop_tech_chrg")) Then Number111.Value = DtView3(0)("comp_shop_tech_chrg") Else Number111.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_apes")) Then Number112.Value = DtView3(0)("comp_shop_apes") Else Number112.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_part_chrg")) Then Number113.Value = DtView3(0)("comp_shop_part_chrg") Else Number113.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_fee")) Then Number114.Value = DtView3(0)("comp_shop_fee") Else Number114.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_pstg")) Then Number115.Value = DtView3(0)("comp_shop_pstg") Else Number115.Value = 0
                If Not IsDBNull(DtView3(0)("comp_shop_tax")) Then Number117.Value = DtView3(0)("comp_shop_tax") Else Number117.Value = 0
                Number116.Value = Number111.Value + Number112.Value + Number113.Value + Number114.Value + Number115.Value
                Number118.Value = Number116.Value + Number117.Value

                If Not IsDBNull(DtView3(0)("comp_eu_tech_chrg")) Then Number121.Value = DtView3(0)("comp_eu_tech_chrg") Else Number121.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_apes")) Then Number122.Value = DtView3(0)("comp_eu_apes") Else Number122.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_part_chrg")) Then Number123.Value = DtView3(0)("comp_eu_part_chrg") Else Number123.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_fee")) Then Number124.Value = DtView3(0)("comp_eu_fee") Else Number124.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_pstg")) Then Number125.Value = DtView3(0)("comp_eu_pstg") Else Number125.Value = 0
                If Not IsDBNull(DtView3(0)("comp_eu_tax")) Then Number127.Value = DtView3(0)("comp_eu_tax") Else Number127.Value = 0
                Number126.Value = Number121.Value + Number122.Value + Number123.Value + Number124.Value + Number125.Value
                Number128.Value = Number126.Value + Number127.Value
            End If

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
                    add_line_4()    'äÆóπì‡óe
                Next
            End If

            'ïîïi
            Dim tbl2 As New DataTable
            tbl2 = P_DsList1.Tables("T04_REP_PART_2")
            DataGrid_K1.DataSource = tbl2

            WK_DtView2 = New DataView(P_DsList1.Tables("T04_REP_PART_2"), "", "", DataViewRowState.CurrentRows)

            If WK_DtView2.Count <> 0 Then
                If Combo_K001.Visible = True Then
                    Combo_K001.Focus()
                Else
                    If Combo_K002.Visible = True Then
                        Combo_K002.Focus()
                    Else
                        cmbBo_4(0, 1).Focus()
                    End If
                End If
            End If

            Button_M001.Enabled = True
            Button_K001.Enabled = True

            's/nïœçXóöó
            Button97.Visible = False
            If Edit011.Text <> Nothing Then
                P_Ds_sn.Clear()
                strSQL = "SELECT * FROM T06_sno WHERE (code = '" & Edit011.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("QGCare")
                r = DaList1.Fill(P_Ds_sn, "T06_sno")
                DB_CLOSE()
                If r <> 0 Then
                    Button97.Visible = True
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
    Sub add_line_3()
        DB_OPEN("nMVAR")
        Line_No3 = Line_No3 + 1

        'å©êœì‡óe
        en = 1
        cmbBo_3(Line_No3, en) = New GrapeCity.Win.Input.Combo
        cmbBo_3(Line_No3, en).Location = New System.Drawing.Point(1, 20 * Line_No3)
        cmbBo_3(Line_No3, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
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
    Sub add_line_4()
        DB_OPEN("nMVAR")
        Line_No4 = Line_No4 + 1

        'èCóùì‡óe
        en = 1
        cmbBo_4(Line_No4, en) = New GrapeCity.Win.Input.Combo
        cmbBo_4(Line_No4, en).Location = New System.Drawing.Point(1, 20 * Line_No4 + label_4(0, 0).Location.Y)
        cmbBo_4(Line_No4, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo_4(Line_No4, en).Size = New System.Drawing.Size(465, 20)
        cmbBo_4(Line_No4, en).Enabled = False
        cmbBo_4(Line_No4, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        Panel_K1.Controls.Add(cmbBo_4(Line_No4, en))
        If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
            cmbBo_4(Line_No4, en).Text = WK_DtView1(i)("cmnt_name1")
        Else
            cmbBo_4(Line_No4, en).Text = Nothing
        End If

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
    '**  îÒï\é¶ÇÃçÄñ⁄ÇÕÉNÉäÉAÇ∑ÇÈ
    '********************************************************************
    Sub NoDsp_Null()
        If Combo_K001.Visible = False Then Combo_K001.Text = Nothing
        If Combo_K002.Visible = False Then Combo_K002.Text = Nothing
    End Sub

    '********************************************************************
    '**  ÉNÉäÉA
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        inz_dsp()   '**  èâä˙âÊñ ÉZÉbÉg
    End Sub

    '********************************************************************
    '**  ñ‚çáÇπ
    '********************************************************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Edit000.Text

        Dim F00_Form10 As New F00_Form10
        F00_Form10.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** ïîïiì¸óÕ
    '********************************************************************
    Private Sub Button_M001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_M001.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM2 = "1"
        P1_F00_Form03 = CLU001.Text

        Dim F00_Form03 As New F00_Form03
        F00_Form03.ShowDialog()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button_K001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_K001.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM2 = "2"
        P1_F00_Form03 = CLU001.Text

        Dim F00_Form03 As New F00_Form03
        F00_Form03.ShowDialog()

        Cursor = System.Windows.Forms.Cursors.Default
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
        Application.Exit()
    End Sub
End Class
