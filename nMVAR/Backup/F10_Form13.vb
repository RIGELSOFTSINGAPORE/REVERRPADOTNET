Public Class F10_Form13
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, Err_F, CSR_POS, CHG_F, ANS As String
    Dim i, r, en, Line_No, Line_No2, Line_No3, chg_itm, seq, WK_cnt As Integer
    Dim cmb_reset As String
    Dim WK_str, WK_str2 As String
    Dim WK_int, WK_int2 As Integer
    Dim WK_H_comn As String = "見積キャンセルの為未修理返却いたします"

    '付属品
    Private chkBox(99, 1) As CheckBox
    Private nbrBox(99, 1) As GrapeCity.Win.Input.Number
    Private edit(99, 2) As GrapeCity.Win.Input.Edit

    '故障内容
    Private cmbBo_2(99, 1) As GrapeCity.Win.Input.Combo
    Dim WK_DsCMB As New DataSet

    '見積内容
    Private cmbBo_3(99, 1) As GrapeCity.Win.Input.Combo
    Private label_3(99, 2) As Label
    Private cmbBo_3_MOTO(99, 1) As GrapeCity.Win.Input.Combo
    Dim WK_DsCMB3 As New DataSet

    Dim Wk_TAX As Integer
    Dim Wk_TAX_1, Wk_TAX_0 As Decimal

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents Panel_見積 As System.Windows.Forms.Panel
    Friend WithEvents Combo_M003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label_M04 As System.Windows.Forms.Label
    Friend WithEvents Button_M001 As System.Windows.Forms.Button
    Friend WithEvents Panel_M1 As System.Windows.Forms.Panel
    Friend WithEvents Edit_M003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_M002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label12_1 As System.Windows.Forms.Label
    Friend WithEvents Label13_1 As System.Windows.Forms.Label
    Friend WithEvents Combo_M001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label_M02 As System.Windows.Forms.Label
    Friend WithEvents Label33_1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid_M1 As System.Windows.Forms.DataGrid
    Friend WithEvents Edit_M001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label_M01 As System.Windows.Forms.Label
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
    Friend WithEvents Edit012 As GrapeCity.Win.Input.Edit
    Friend WithEvents Panel_受付 As System.Windows.Forms.Panel
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button0 As System.Windows.Forms.Button
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Date006 As GrapeCity.Win.Input.Date
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents ZH As System.Windows.Forms.Label
    Friend WithEvents Edit_M004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label14_1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date_U002 As GrapeCity.Win.Input.Date
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Combo
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Date_U003 As GrapeCity.Win.Input.Date
    Friend WithEvents comp_comn As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Edit013 As GrapeCity.Win.Input.Edit
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Number001_nTax As GrapeCity.Win.Input.Number
    Friend WithEvents Number039 As GrapeCity.Win.Input.Number
    Friend WithEvents Number029 As GrapeCity.Win.Input.Number
    Friend WithEvents Number019 As GrapeCity.Win.Input.Number
    Friend WithEvents CheckBox_U002 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_U003 As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Combo
    Friend WithEvents Date007 As GrapeCity.Win.Input.Date
    Friend WithEvents Label016 As System.Windows.Forms.Label
    Friend WithEvents Label015 As System.Windows.Forms.Label
    Friend WithEvents Date008 As GrapeCity.Win.Input.Date
    Friend WithEvents Label017 As System.Windows.Forms.Label
    Friend WithEvents CK_own_flg As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cntact2 As System.Windows.Forms.Label
    Friend WithEvents cntact1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Edit015 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit014 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_U006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents CkBox01_N As System.Windows.Forms.CheckBox
    Friend WithEvents CkBox01_Y As System.Windows.Forms.CheckBox
    Friend WithEvents Button97 As System.Windows.Forms.Button
    Friend WithEvents Date015 As GrapeCity.Win.Input.Date
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel_見積 = New System.Windows.Forms.Panel
        Me.Number039 = New GrapeCity.Win.Input.Number
        Me.Number029 = New GrapeCity.Win.Input.Number
        Me.Number019 = New GrapeCity.Win.Input.Number
        Me.comp_comn = New System.Windows.Forms.Label
        Me.Edit_M004 = New GrapeCity.Win.Input.Edit
        Me.Label14_1 = New System.Windows.Forms.Label
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
        Me.Edit_M001 = New GrapeCity.Win.Input.Edit
        Me.Label_M01 = New System.Windows.Forms.Label
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
        Me.Number040 = New GrapeCity.Win.Input.Number
        Me.Edit012 = New GrapeCity.Win.Input.Edit
        Me.Panel_受付 = New System.Windows.Forms.Panel
        Me.Edit_U006 = New GrapeCity.Win.Input.Edit
        Me.Label31 = New System.Windows.Forms.Label
        Me.CheckBox_U003 = New System.Windows.Forms.CheckBox
        Me.CheckBox_U002 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date_U002 = New GrapeCity.Win.Input.Date
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
        Me.CheckBox_U001 = New System.Windows.Forms.CheckBox
        Me.Label19_1 = New System.Windows.Forms.Label
        Me.Date_U001 = New GrapeCity.Win.Input.Date
        Me.Date_U003 = New GrapeCity.Win.Input.Date
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Edit010 = New GrapeCity.Win.Input.Edit
        Me.Edit009 = New GrapeCity.Win.Input.Edit
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button0 = New System.Windows.Forms.Button
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
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Date006 = New GrapeCity.Win.Input.Date
        Me.Label37 = New System.Windows.Forms.Label
        Me.ZH = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label002 = New GrapeCity.Win.Input.Edit
        Me.Label001 = New GrapeCity.Win.Input.Edit
        Me.Label25 = New System.Windows.Forms.Label
        Me.Combo005 = New GrapeCity.Win.Input.Combo
        Me.Label15 = New System.Windows.Forms.Label
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.Label10 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Edit013 = New GrapeCity.Win.Input.Edit
        Me.Button3 = New System.Windows.Forms.Button
        Me.Number001_nTax = New GrapeCity.Win.Input.Number
        Me.Label23 = New System.Windows.Forms.Label
        Me.Combo006 = New GrapeCity.Win.Input.Combo
        Me.Date007 = New GrapeCity.Win.Input.Date
        Me.Label016 = New System.Windows.Forms.Label
        Me.Label015 = New System.Windows.Forms.Label
        Me.Date008 = New GrapeCity.Win.Input.Date
        Me.Label017 = New System.Windows.Forms.Label
        Me.CK_own_flg = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cntact2 = New System.Windows.Forms.Label
        Me.cntact1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Button9 = New System.Windows.Forms.Button
        Me.Label29 = New System.Windows.Forms.Label
        Me.Edit015 = New GrapeCity.Win.Input.Edit
        Me.Label30 = New System.Windows.Forms.Label
        Me.Edit014 = New GrapeCity.Win.Input.Edit
        Me.Label32 = New System.Windows.Forms.Label
        Me.CkBox01_N = New System.Windows.Forms.CheckBox
        Me.CkBox01_Y = New System.Windows.Forms.CheckBox
        Me.Button97 = New System.Windows.Forms.Button
        Me.Date015 = New GrapeCity.Win.Input.Date
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Panel_見積.SuspendLayout()
        CType(Me.Number039, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Number040, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_受付.SuspendLayout()
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
        CType(Me.Date006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_見積
        '
        Me.Panel_見積.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_見積.Controls.Add(Me.Number039)
        Me.Panel_見積.Controls.Add(Me.Number029)
        Me.Panel_見積.Controls.Add(Me.Number019)
        Me.Panel_見積.Controls.Add(Me.comp_comn)
        Me.Panel_見積.Controls.Add(Me.Edit_M004)
        Me.Panel_見積.Controls.Add(Me.Label14_1)
        Me.Panel_見積.Controls.Add(Me.Combo_M003)
        Me.Panel_見積.Controls.Add(Me.Label_M04)
        Me.Panel_見積.Controls.Add(Me.Button_M001)
        Me.Panel_見積.Controls.Add(Me.Panel_M1)
        Me.Panel_見積.Controls.Add(Me.Edit_M003)
        Me.Panel_見積.Controls.Add(Me.Edit_M002)
        Me.Panel_見積.Controls.Add(Me.Label12_1)
        Me.Panel_見積.Controls.Add(Me.Label13_1)
        Me.Panel_見積.Controls.Add(Me.Combo_M001)
        Me.Panel_見積.Controls.Add(Me.Label_M02)
        Me.Panel_見積.Controls.Add(Me.Label33_1)
        Me.Panel_見積.Controls.Add(Me.DataGrid_M1)
        Me.Panel_見積.Controls.Add(Me.Edit_M001)
        Me.Panel_見積.Controls.Add(Me.Label_M01)
        Me.Panel_見積.Controls.Add(Me.Number016)
        Me.Panel_見積.Controls.Add(Me.Label133)
        Me.Panel_見積.Controls.Add(Me.Label132)
        Me.Panel_見積.Controls.Add(Me.Number015)
        Me.Panel_見積.Controls.Add(Me.Number025)
        Me.Panel_見積.Controls.Add(Me.Number024)
        Me.Panel_見積.Controls.Add(Me.Number017)
        Me.Panel_見積.Controls.Add(Me.Label11)
        Me.Panel_見積.Controls.Add(Me.Number032)
        Me.Panel_見積.Controls.Add(Me.Number012)
        Me.Panel_見積.Controls.Add(Me.Number031)
        Me.Panel_見積.Controls.Add(Me.Number022)
        Me.Panel_見積.Controls.Add(Me.Number011)
        Me.Panel_見積.Controls.Add(Me.Number014)
        Me.Panel_見積.Controls.Add(Me.Label131)
        Me.Panel_見積.Controls.Add(Me.Label130)
        Me.Panel_見積.Controls.Add(Me.Label129)
        Me.Panel_見積.Controls.Add(Me.Label128)
        Me.Panel_見積.Controls.Add(Me.Number021)
        Me.Panel_見積.Controls.Add(Me.Number033)
        Me.Panel_見積.Controls.Add(Me.Label22_1)
        Me.Panel_見積.Controls.Add(Me.Label23_1)
        Me.Panel_見積.Controls.Add(Me.Number037)
        Me.Panel_見積.Controls.Add(Me.Number036)
        Me.Panel_見積.Controls.Add(Me.Number035)
        Me.Panel_見積.Controls.Add(Me.Number034)
        Me.Panel_見積.Controls.Add(Me.Label191)
        Me.Panel_見積.Controls.Add(Me.Number023)
        Me.Panel_見積.Controls.Add(Me.Number013)
        Me.Panel_見積.Controls.Add(Me.Label138)
        Me.Panel_見積.Controls.Add(Me.Number027)
        Me.Panel_見積.Controls.Add(Me.Label1)
        Me.Panel_見積.Controls.Add(Me.Number038)
        Me.Panel_見積.Controls.Add(Me.Number028)
        Me.Panel_見積.Controls.Add(Me.Number018)
        Me.Panel_見積.Controls.Add(Me.Number026)
        Me.Panel_見積.Location = New System.Drawing.Point(10, 264)
        Me.Panel_見積.Name = "Panel_見積"
        Me.Panel_見積.Size = New System.Drawing.Size(986, 372)
        Me.Panel_見積.TabIndex = 2
        Me.Panel_見積.TabStop = True
        '
        'Number039
        '
        Me.Number039.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number039.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number039.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number039.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number039.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number039.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number039.TabIndex = 1815
        Me.Number039.TabStop = False
        Me.Number039.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number039.Value = New Decimal(New Integer() {39, 0, 0, 0})
        Me.Number039.Visible = False
        '
        'Number029
        '
        Me.Number029.BackColor = System.Drawing.SystemColors.Control
        Me.Number029.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number029.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number029.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number029.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number029.TabIndex = 1814
        Me.Number029.TabStop = False
        Me.Number029.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number029.Value = New Decimal(New Integer() {29, 0, 0, 0})
        '
        'Number019
        '
        Me.Number019.BackColor = System.Drawing.SystemColors.Control
        Me.Number019.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number019.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number019.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number019.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number019.TabIndex = 1813
        Me.Number019.TabStop = False
        Me.Number019.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number019.Value = New Decimal(New Integer() {19, 0, 0, 0})
        '
        'comp_comn
        '
        Me.comp_comn.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.comp_comn.Location = New System.Drawing.Point(356, 232)
        Me.comp_comn.Name = "comp_comn"
        Me.comp_comn.Size = New System.Drawing.Size(228, 44)
        Me.comp_comn.TabIndex = 1812
        Me.comp_comn.Text = "comp_comn"
        Me.comp_comn.Visible = False
        '
        'Edit_M004
        '
        Me.Edit_M004.AcceptsReturn = True
        Me.Edit_M004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_M004.LengthAsByte = True
        Me.Edit_M004.Location = New System.Drawing.Point(88, 268)
        Me.Edit_M004.MaxLength = 200
        Me.Edit_M004.Multiline = True
        Me.Edit_M004.Name = "Edit_M004"
        Me.Edit_M004.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_M004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_M004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M004.Size = New System.Drawing.Size(280, 92)
        Me.Edit_M004.TabIndex = 0
        '
        'Label14_1
        '
        Me.Label14_1.BackColor = System.Drawing.Color.Navy
        Me.Label14_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14_1.ForeColor = System.Drawing.Color.White
        Me.Label14_1.Location = New System.Drawing.Point(4, 268)
        Me.Label14_1.Name = "Label14_1"
        Me.Label14_1.Size = New System.Drawing.Size(84, 92)
        Me.Label14_1.TabIndex = 1731
        Me.Label14_1.Text = "解除連絡"
        Me.Label14_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Combo_M003.TabIndex = 35
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
        Me.Label_M04.Text = "難易度"
        Me.Label_M04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_M001
        '
        Me.Button_M001.BackColor = System.Drawing.SystemColors.Control
        Me.Button_M001.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_M001.Enabled = False
        Me.Button_M001.Location = New System.Drawing.Point(904, 8)
        Me.Button_M001.Name = "Button_M001"
        Me.Button_M001.Size = New System.Drawing.Size(72, 20)
        Me.Button_M001.TabIndex = 70
        Me.Button_M001.Text = "部品入力"
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
        Me.Edit_M003.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_M003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M003.HighlightText = True
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
        Me.Edit_M003.TabIndex = 60
        Me.Edit_M003.TabStop = False
        '
        'Edit_M002
        '
        Me.Edit_M002.AcceptsReturn = True
        Me.Edit_M002.BackColor = System.Drawing.SystemColors.Control
        Me.Edit_M002.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_M002.HighlightText = True
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
        Me.Edit_M002.TabIndex = 50
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
        Me.Label12_1.Text = "見積内容"
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
        Me.Label13_1.Text = "コメント"
        Me.Label13_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo_M001
        '
        Me.Combo_M001.BackColor = System.Drawing.SystemColors.Control
        Me.Combo_M001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_M001.Enabled = False
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
        Me.Label_M02.Text = "見積担当"
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
        Me.Label33_1.Text = "見積部品"
        Me.Label33_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGrid_M1
        '
        Me.DataGrid_M1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrid_M1.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.DataGrid_M1.CaptionFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid_M1.CaptionForeColor = System.Drawing.Color.Black
        Me.DataGrid_M1.CaptionText = "見積部品"
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
        Me.DataGridTextBoxColumn1.HeaderText = "部品番号"
        Me.DataGridTextBoxColumn1.MappingName = "part_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 120
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "部品名"
        Me.DataGridTextBoxColumn2.MappingName = "part_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 135
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "##,##0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "単価"
        Me.DataGridTextBoxColumn3.MappingName = "part_amnt"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 40
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "数量"
        Me.DataGridTextBoxColumn4.MappingName = "use_qty"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 40
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
        Me.Edit_M001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_M001.Size = New System.Drawing.Size(200, 20)
        Me.Edit_M001.TabIndex = 30
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
        Me.Label_M01.Text = "メーカー修理№"
        Me.Label_M01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number016
        '
        Me.Number016.BackColor = System.Drawing.SystemColors.Control
        Me.Number016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number016.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number016.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number016.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Label133.TabIndex = 1565
        Me.Label133.Text = "コスト"
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
        Me.Label132.Text = "計上額"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number015
        '
        Me.Number015.BackColor = System.Drawing.SystemColors.Control
        Me.Number015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number015.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number015.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number015.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number015.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number015.Value = Nothing
        '
        'Number025
        '
        Me.Number025.BackColor = System.Drawing.SystemColors.Control
        Me.Number025.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number025.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number025.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number025.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number025.TabIndex = 1542
        Me.Number025.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number025.Value = Nothing
        '
        'Number024
        '
        Me.Number024.BackColor = System.Drawing.SystemColors.Control
        Me.Number024.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number024.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number024.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number024.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number024.TabIndex = 1541
        Me.Number024.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number024.Value = Nothing
        '
        'Number017
        '
        Me.Number017.BackColor = System.Drawing.SystemColors.Control
        Me.Number017.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number017.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number017.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number017.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number017.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number017.Value = Nothing
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
        Me.Label11.Text = "診断料（キャンセル）"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number032
        '
        Me.Number032.BackColor = System.Drawing.SystemColors.Control
        Me.Number032.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number032.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number032.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number032.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number032.TabIndex = 1546
        Me.Number032.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number032.Value = Nothing
        '
        'Number012
        '
        Me.Number012.BackColor = System.Drawing.SystemColors.Control
        Me.Number012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number012.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number012.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number012.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number012.Value = Nothing
        '
        'Number031
        '
        Me.Number031.BackColor = System.Drawing.SystemColors.Control
        Me.Number031.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number031.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number031.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number031.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number031.TabIndex = 1545
        Me.Number031.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number031.Value = Nothing
        '
        'Number022
        '
        Me.Number022.BackColor = System.Drawing.SystemColors.Control
        Me.Number022.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number022.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number022.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number022.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number022.TabIndex = 1539
        Me.Number022.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number022.Value = Nothing
        '
        'Number011
        '
        Me.Number011.BackColor = System.Drawing.SystemColors.Control
        Me.Number011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number011.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number011.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number011.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number011.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number011.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        '
        'Number014
        '
        Me.Number014.BackColor = System.Drawing.SystemColors.Control
        Me.Number014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number014.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number014.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number014.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Label131.TabIndex = 1563
        Me.Label131.Text = "合　計"
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
        Me.Label130.Text = "消費税"
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
        Me.Label129.Text = "送　料"
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
        Me.Label128.Text = "その他"
        Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number021
        '
        Me.Number021.BackColor = System.Drawing.SystemColors.Control
        Me.Number021.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number021.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number021.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number021.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number021.TabIndex = 1538
        Me.Number021.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number021.Value = Nothing
        '
        'Number033
        '
        Me.Number033.BackColor = System.Drawing.SystemColors.Control
        Me.Number033.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number033.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number033.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number033.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number033.TabIndex = 1547
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
        Me.Label22_1.TabIndex = 1571
        Me.Label22_1.Text = "技術"
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
        Me.Label23_1.Text = "部品"
        Me.Label23_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number037
        '
        Me.Number037.BackColor = System.Drawing.SystemColors.Control
        Me.Number037.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number037.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number037.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number037.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number037.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number037.Value = Nothing
        '
        'Number036
        '
        Me.Number036.BackColor = System.Drawing.SystemColors.Control
        Me.Number036.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number036.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number036.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number036.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number036.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number036.Value = Nothing
        '
        'Number035
        '
        Me.Number035.BackColor = System.Drawing.SystemColors.Control
        Me.Number035.DisabledForeColor = System.Drawing.Color.Black
        Me.Number035.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number035.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number035.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number035.TabIndex = 1549
        Me.Number035.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number035.Value = Nothing
        '
        'Number034
        '
        Me.Number034.BackColor = System.Drawing.SystemColors.Control
        Me.Number034.DisabledForeColor = System.Drawing.Color.Black
        Me.Number034.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number034.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number034.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number034.TabIndex = 1548
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
        Me.Label191.TabIndex = 1568
        Me.Label191.Text = "EU価格"
        Me.Label191.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number023
        '
        Me.Number023.BackColor = System.Drawing.SystemColors.Control
        Me.Number023.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number023.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number023.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number023.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number023.TabIndex = 1540
        Me.Number023.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number023.Value = Nothing
        '
        'Number013
        '
        Me.Number013.BackColor = System.Drawing.SystemColors.Control
        Me.Number013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number013.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number013.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number013.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Label138.TabIndex = 1566
        Me.Label138.Text = "小計"
        Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number027
        '
        Me.Number027.BackColor = System.Drawing.SystemColors.Control
        Me.Number027.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number027.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number027.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number027.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Label1.TabIndex = 1730
        Me.Label1.Text = "AP SE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number038
        '
        Me.Number038.BackColor = System.Drawing.SystemColors.Control
        Me.Number038.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number038.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number038.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number038.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number038.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number038.Value = Nothing
        '
        'Number028
        '
        Me.Number028.BackColor = System.Drawing.SystemColors.Control
        Me.Number028.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number028.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number028.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number028.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number028.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number028.Value = Nothing
        '
        'Number018
        '
        Me.Number018.BackColor = System.Drawing.SystemColors.Control
        Me.Number018.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number018.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number018.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number018.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number018.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number018.Value = Nothing
        '
        'Number026
        '
        Me.Number026.BackColor = System.Drawing.SystemColors.Control
        Me.Number026.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number026.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number026.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number026.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number026.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number026.Value = Nothing
        '
        'Number040
        '
        Me.Number040.BackColor = System.Drawing.SystemColors.Control
        Me.Number040.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number040.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number040.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number040.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number040.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number040.Enabled = False
        Me.Number040.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number040.HighlightText = True
        Me.Number040.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number040.Location = New System.Drawing.Point(196, 660)
        Me.Number040.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number040.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number040.Name = "Number040"
        Me.Number040.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number040.Size = New System.Drawing.Size(104, 20)
        Me.Number040.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number040.TabIndex = 1627
        Me.Number040.TabStop = False
        Me.Number040.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number040.Value = Nothing
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
        Me.Edit012.MaxLength = 50
        Me.Edit012.Name = "Edit012"
        Me.Edit012.ReadOnly = True
        Me.Edit012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit012.Size = New System.Drawing.Size(116, 20)
        Me.Edit012.TabIndex = 1793
        Me.Edit012.TabStop = False
        Me.Edit012.Text = "9999"
        Me.Edit012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Panel_受付
        '
        Me.Panel_受付.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_受付.Controls.Add(Me.Edit_U006)
        Me.Panel_受付.Controls.Add(Me.Label31)
        Me.Panel_受付.Controls.Add(Me.CheckBox_U003)
        Me.Panel_受付.Controls.Add(Me.CheckBox_U002)
        Me.Panel_受付.Controls.Add(Me.Label3)
        Me.Panel_受付.Controls.Add(Me.Date_U002)
        Me.Panel_受付.Controls.Add(Me.Label6)
        Me.Panel_受付.Controls.Add(Me.Combo_U001)
        Me.Panel_受付.Controls.Add(Me.Label11_1)
        Me.Panel_受付.Controls.Add(Me.Edit_U004)
        Me.Panel_受付.Controls.Add(Me.Combo_U002)
        Me.Panel_受付.Controls.Add(Me.Panel_U2)
        Me.Panel_受付.Controls.Add(Me.Edit_U002)
        Me.Panel_受付.Controls.Add(Me.Edit_U005)
        Me.Panel_受付.Controls.Add(Me.Edit_U003)
        Me.Panel_受付.Controls.Add(Me.Label04_1)
        Me.Panel_受付.Controls.Add(Me.Label09_1)
        Me.Panel_受付.Controls.Add(Me.Label10_1)
        Me.Panel_受付.Controls.Add(Me.Label05_1)
        Me.Panel_受付.Controls.Add(Me.Label07_1)
        Me.Panel_受付.Controls.Add(Me.Edit_U001)
        Me.Panel_受付.Controls.Add(Me.Label8)
        Me.Panel_受付.Controls.Add(Me.Panel_U1)
        Me.Panel_受付.Controls.Add(Me.CheckBox_U001)
        Me.Panel_受付.Controls.Add(Me.Label19_1)
        Me.Panel_受付.Controls.Add(Me.Date_U001)
        Me.Panel_受付.Controls.Add(Me.Date_U003)
        Me.Panel_受付.Controls.Add(Me.Label14)
        Me.Panel_受付.Location = New System.Drawing.Point(10, 264)
        Me.Panel_受付.Name = "Panel_受付"
        Me.Panel_受付.Size = New System.Drawing.Size(986, 372)
        Me.Panel_受付.TabIndex = 1756
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
        Me.Edit_U006.Size = New System.Drawing.Size(208, 20)
        Me.Edit_U006.TabIndex = 1815
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
        Me.Label31.TabIndex = 1816
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
        Me.CheckBox_U003.Text = "Ｎｏｔｅ"
        '
        'CheckBox_U002
        '
        Me.CheckBox_U002.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U002.Location = New System.Drawing.Point(948, 32)
        Me.CheckBox_U002.Name = "CheckBox_U002"
        Me.CheckBox_U002.Size = New System.Drawing.Size(28, 16)
        Me.CheckBox_U002.TabIndex = 1814
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(756, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 1427
        Me.Label3.Text = "ﾒｰｶｰ保証開始日"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label6.Text = "メーカー"
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
        'Label11_1
        '
        Me.Label11_1.BackColor = System.Drawing.Color.Navy
        Me.Label11_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11_1.ForeColor = System.Drawing.Color.White
        Me.Label11_1.Location = New System.Drawing.Point(380, 284)
        Me.Label11_1.Name = "Label11_1"
        Me.Label11_1.Size = New System.Drawing.Size(80, 76)
        Me.Label11_1.TabIndex = 1269
        Me.Label11_1.Text = "コメント"
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
        Me.Panel_U2.Location = New System.Drawing.Point(460, 76)
        Me.Panel_U2.Name = "Panel_U2"
        Me.Panel_U2.Size = New System.Drawing.Size(520, 144)
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
        Me.Edit_U003.Size = New System.Drawing.Size(208, 20)
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
        Me.Label04_1.Text = "機種"
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
        Me.Label09_1.Text = "付属品"
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
        Me.Label10_1.Text = "故障内容"
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
        Me.Label07_1.Text = "修理拠点"
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
        Me.Edit_U001.ReadOnly = True
        Me.Edit_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U001.Size = New System.Drawing.Size(208, 20)
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
        Me.Label8.Text = "モデル"
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
        Me.CheckBox_U001.Text = "定額修理"
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
        Me.Label19_1.Text = "購入日"
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
        Me.Date_U001.ReadOnly = True
        Me.Date_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U001.Size = New System.Drawing.Size(88, 20)
        Me.Date_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U001.TabIndex = 10
        Me.Date_U001.TabStop = False
        Me.Date_U001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U001.Value = Nothing
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
        Me.Date_U003.TabIndex = 1812
        Me.Date_U003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U003.Value = Nothing
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(756, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 1813
        Me.Label14.Text = "事故日"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(460, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 1794
        Me.Label2.Text = "ｵﾘｼﾞﾅﾙﾒｰｶｰｺｰﾄﾞ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 1784
        Me.Label4.Text = "ｶﾅ"
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
        Me.Edit010.MaxLength = 400
        Me.Edit010.Name = "Edit010"
        Me.Edit010.ReadOnly = True
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(300, 20)
        Me.Edit010.TabIndex = 1755
        Me.Edit010.TabStop = False
        Me.Edit010.Text = "ああああああああああああああああああああ"
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
        Me.Edit009.TabIndex = 1754
        Me.Edit009.TabStop = False
        Me.Edit009.Text = "ああああああああああああああああああああ"
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(16, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 1787
        Me.Label9.Text = "受付番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(472, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 20)
        Me.Label5.TabIndex = 1786
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Button0.Text = "？"
        '
        'Mask1
        '
        Me.Mask1.BackColor = System.Drawing.SystemColors.Control
        Me.Mask1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask1.Enabled = False
        Me.Mask1.Format = New GrapeCity.Win.Input.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(520, 152)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.ReadOnly = True
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(76, 20)
        Me.Mask1.TabIndex = 1753
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
        Me.Label013.TabIndex = 1777
        Me.Label013.Text = "住所"
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
        Me.Edit901.TabIndex = 1776
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
        Me.Edit902.TabIndex = 1775
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
        Me.Label20.TabIndex = 1773
        Me.Label20.Text = "入荷担当"
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
        Me.Combo003.TabIndex = 1744
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
        Me.Label18.TabIndex = 1772
        Me.Label18.Text = "入荷区分"
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
        Me.Combo002.TabIndex = 1743
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
        Me.Label7.TabIndex = 1771
        Me.Label7.Text = "受付種別"
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
        Me.Label21.TabIndex = 1785
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
        Me.Edit011.TabIndex = 1742
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
        Me.Combo001.TabIndex = 1741
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
        Me.Label014.TabIndex = 1770
        Me.Label014.Text = "修理種別"
        Me.Label014.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo004
        '
        Me.Combo004.BackColor = System.Drawing.SystemColors.Control
        Me.Combo004.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo004.Enabled = False
        Me.Combo004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo004.Location = New System.Drawing.Point(96, 216)
        Me.Combo004.MaxDropDownItems = 20
        Me.Combo004.Name = "Combo004"
        Me.Combo004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo004.Size = New System.Drawing.Size(164, 20)
        Me.Combo004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo004.TabIndex = 1730
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
        Me.Label13.TabIndex = 1764
        Me.Label13.Text = "受付担当者"
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
        Me.Label012.TabIndex = 1769
        Me.Label012.Text = "電話番号2"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Date004.TabIndex = 1729
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
        Me.Date003.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date003.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date003.Name = "Date003"
        Me.Date003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date003.Size = New System.Drawing.Size(112, 20)
        Me.Date003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date003.TabIndex = 1757
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
        Me.Edit006.TabIndex = 1750
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
        Me.Edit008.TabIndex = 1752
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
        Me.Edit007.TabIndex = 1751
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
        Me.Edit005.TabIndex = 1749
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
        Me.Label011.TabIndex = 1762
        Me.Label011.Text = "電話番号1"
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
        Me.Label010.TabIndex = 1761
        Me.Label010.Text = "お客様名"
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
        Me.Label36.TabIndex = 1766
        Me.Label36.Text = "見積日"
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
        Me.Label35.TabIndex = 1765
        Me.Label35.Text = "受付日"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 640)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(864, 16)
        Me.msg.TabIndex = 1774
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
        Me.Edit004.TabIndex = 1748
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
        Me.Label006.TabIndex = 1760
        Me.Label006.Text = "販社修理番号"
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
        Me.Label005.TabIndex = 1759
        Me.Label005.Text = "納入先"
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
        Me.Label003.TabIndex = 1758
        Me.Label003.Text = "販社"
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
        Me.Label004.TabIndex = 1763
        Me.Label004.Text = "販社担当者"
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
        Me.Edit002.TabIndex = 1747
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
        Me.Edit001.TabIndex = 1745
        Me.Edit001.TabStop = False
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
        Me.Edit003.ReadOnly = True
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(112, 20)
        Me.Edit003.TabIndex = 1746
        Me.Edit003.TabStop = False
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(336, 660)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 1734
        Me.Button6.TabStop = False
        Me.Button6.Text = "続行"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(116, 660)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 1733
        Me.Button2.TabStop = False
        Me.Button2.Text = "クリア"
        '
        'Button80
        '
        Me.Button80.BackColor = System.Drawing.SystemColors.Control
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Enabled = False
        Me.Button80.Location = New System.Drawing.Point(816, 660)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(72, 24)
        Me.Button80.TabIndex = 1735
        Me.Button80.TabStop = False
        Me.Button80.Text = "履歴"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 660)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1736
        Me.Button98.Text = "戻る"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(64, 244)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(48, 20)
        Me.Button12.TabIndex = 1738
        Me.Button12.TabStop = False
        Me.Button12.Text = "見積"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(16, 244)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(48, 20)
        Me.Button11.TabIndex = 1737
        Me.Button11.TabStop = False
        Me.Button11.Text = "受付"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Enabled = False
        Me.Button7.Location = New System.Drawing.Point(436, 660)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(72, 24)
        Me.Button7.TabIndex = 1796
        Me.Button7.TabStop = False
        Me.Button7.Text = "返却"
        '
        'Date006
        '
        Me.Date006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date006.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date006.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date006.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date006.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date006.Location = New System.Drawing.Point(904, 68)
        Me.Date006.Name = "Date006"
        Me.Date006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date006.Size = New System.Drawing.Size(88, 20)
        Me.Date006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date006.TabIndex = 1798
        Me.Date006.TabStop = False
        Me.Date006.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date006.Value = Nothing
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Navy
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(824, 68)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(80, 20)
        Me.Label37.TabIndex = 1797
        Me.Label37.Text = "回答受信日"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ZH
        '
        Me.ZH.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.ZH.Location = New System.Drawing.Point(516, 664)
        Me.ZH.Name = "ZH"
        Me.ZH.Size = New System.Drawing.Size(40, 16)
        Me.ZH.TabIndex = 1799
        Me.ZH.Text = "ZH"
        Me.ZH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ZH.Visible = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(688, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 20)
        Me.Label12.TabIndex = 1801
        Me.Label12.Text = "預かり金"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number002
        '
        Me.Number002.BackColor = System.Drawing.SystemColors.Control
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number002.TabIndex = 1800
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = New Decimal(New Integer() {0, 0, 0, 0})
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
        Me.Date001.Location = New System.Drawing.Point(732, 80)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(88, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1802
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
        Me.Label007.TabIndex = 1803
        Me.Label007.Text = "販社受付日"
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
        Me.Label002.TabIndex = 1805
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
        Me.Label001.TabIndex = 1804
        Me.Label001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(264, 216)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 20)
        Me.Label25.TabIndex = 1811
        Me.Label25.Text = "事故状況"
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
        Me.Combo005.TabIndex = 1810
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
        Me.Label15.TabIndex = 1809
        Me.Label15.Text = "免責"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number003
        '
        Me.Number003.BackColor = System.Drawing.SystemColors.Control
        Me.Number003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number003.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number003.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.Number003.TabIndex = 1808
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number003.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(652, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 1807
        Me.Label10.Text = "保証限度額"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number001
        '
        Me.Number001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Number001.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Enabled = False
        Me.Number001.Format = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(780, 16)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(52, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1806
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(784, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 1812
        Me.Label16.Text = "（税抜）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(784, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 16)
        Me.Label17.TabIndex = 1813
        Me.Label17.Text = "（税込）"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(452, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 20)
        Me.Label22.TabIndex = 1815
        Me.Label22.Text = "販社延長情報"
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
        Me.Edit013.TabIndex = 1814
        Me.Edit013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(652, 660)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1842
        Me.Button3.TabStop = False
        Me.Button3.Text = "別No照会"
        '
        'Number001_nTax
        '
        Me.Number001_nTax.BackColor = System.Drawing.SystemColors.Control
        Me.Number001_nTax.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001_nTax.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number001_nTax.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001_nTax.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Navy
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(120, 240)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 20)
        Me.Label23.TabIndex = 1854
        Me.Label23.Text = "Mobile種別"
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
        Me.Combo006.TabIndex = 1853
        Me.Combo006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo006.Value = "Combo006"
        '
        'Date007
        '
        Me.Date007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date007.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date007.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date007.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date007.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date007.Location = New System.Drawing.Point(904, 88)
        Me.Date007.Name = "Date007"
        Me.Date007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date007.Size = New System.Drawing.Size(88, 20)
        Me.Date007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date007.TabIndex = 1869
        Me.Date007.TabStop = False
        Me.Date007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
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
        Me.Label016.TabIndex = 1868
        Me.Label016.Text = "部品受領日"
        Me.Label016.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label015
        '
        Me.Label015.BackColor = System.Drawing.Color.Navy
        Me.Label015.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label015.ForeColor = System.Drawing.Color.White
        Me.Label015.Location = New System.Drawing.Point(824, 88)
        Me.Label015.Name = "Label015"
        Me.Label015.Size = New System.Drawing.Size(80, 20)
        Me.Label015.TabIndex = 1867
        Me.Label015.Text = "部品発注日"
        Me.Label015.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date008
        '
        Me.Date008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date008.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date008.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date008.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date008.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date008.Location = New System.Drawing.Point(904, 108)
        Me.Date008.Name = "Date008"
        Me.Date008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date008.Size = New System.Drawing.Size(88, 20)
        Me.Date008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date008.TabIndex = 1866
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
        Me.Label017.TabIndex = 1865
        Me.Label017.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CK_own_flg
        '
        Me.CK_own_flg.AutoCheck = False
        Me.CK_own_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CK_own_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CK_own_flg.Location = New System.Drawing.Point(884, 232)
        Me.CK_own_flg.Name = "CK_own_flg"
        Me.CK_own_flg.Size = New System.Drawing.Size(84, 16)
        Me.CK_own_flg.TabIndex = 1870
        Me.CK_own_flg.TabStop = False
        Me.CK_own_flg.Text = "CK_own_flg"
        Me.CK_own_flg.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoCheck = False
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox1.Location = New System.Drawing.Point(428, 132)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(16, 16)
        Me.CheckBox1.TabIndex = 1884
        Me.CheckBox1.TabStop = False
        '
        'cntact2
        '
        Me.cntact2.BackColor = System.Drawing.SystemColors.Control
        Me.cntact2.Location = New System.Drawing.Point(268, 132)
        Me.cntact2.Name = "cntact2"
        Me.cntact2.Size = New System.Drawing.Size(104, 16)
        Me.cntact2.TabIndex = 1883
        Me.cntact2.Text = "cntact2"
        Me.cntact2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cntact1
        '
        Me.cntact1.BackColor = System.Drawing.SystemColors.Control
        Me.cntact1.Location = New System.Drawing.Point(96, 132)
        Me.cntact1.Name = "cntact1"
        Me.cntact1.Size = New System.Drawing.Size(100, 16)
        Me.cntact1.TabIndex = 1882
        Me.cntact1.Text = "cntact1"
        Me.cntact1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(372, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 20)
        Me.Label19.TabIndex = 1881
        Me.Label19.Text = "ｺﾝﾀｸﾄ完了"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label44.TabIndex = 1880
        Me.Label44.Text = "ｺﾝﾀｸﾄ担当"
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
        Me.Label55.TabIndex = 1879
        Me.Label55.Text = "最終ｺﾝﾀｸﾄ日時"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(568, 660)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(72, 24)
        Me.Button9.TabIndex = 1885
        Me.Button9.TabStop = False
        Me.Button9.Text = "ｺﾝﾀｸﾄﾛｸﾞ"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(536, 240)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 20)
        Me.Label29.TabIndex = 1889
        Me.Label29.Text = "iMV番号"
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
        Me.Edit015.TabIndex = 1887
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
        Me.Label30.TabIndex = 1888
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
        Me.Edit014.TabIndex = 1886
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
        Me.Label32.TabIndex = 1891
        Me.Label32.Text = "過失"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CkBox01_N
        '
        Me.CkBox01_N.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_N.Location = New System.Drawing.Point(780, 108)
        Me.CkBox01_N.Name = "CkBox01_N"
        Me.CkBox01_N.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_N.TabIndex = 1893
        Me.CkBox01_N.Text = "無"
        '
        'CkBox01_Y
        '
        Me.CkBox01_Y.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_Y.Location = New System.Drawing.Point(740, 108)
        Me.CkBox01_Y.Name = "CkBox01_Y"
        Me.CkBox01_Y.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_Y.TabIndex = 1892
        Me.CkBox01_Y.Text = "有"
        '
        'Button97
        '
        Me.Button97.BackColor = System.Drawing.SystemColors.Control
        Me.Button97.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button97.Location = New System.Drawing.Point(736, 660)
        Me.Button97.Name = "Button97"
        Me.Button97.Size = New System.Drawing.Size(68, 24)
        Me.Button97.TabIndex = 1735
        Me.Button97.Text = "S/N履歴"
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
        Me.Date015.TabIndex = 1894
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
        Me.Label34.TabIndex = 1895
        Me.Label34.Text = "診断日"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Location = New System.Drawing.Point(716, 240)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 16)
        Me.Label24.TabIndex = 1896
        Me.Label24.Text = "AC+請求額（税込）"
        '
        'F10_Form13
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1022, 688)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Date015)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Button97)
        Me.Controls.Add(Me.CkBox01_N)
        Me.Controls.Add(Me.CkBox01_Y)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Panel_見積)
        Me.Controls.Add(Me.Panel_受付)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Edit015)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Edit014)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cntact2)
        Me.Controls.Add(Me.cntact1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.CK_own_flg)
        Me.Controls.Add(Me.Date007)
        Me.Controls.Add(Me.Label016)
        Me.Controls.Add(Me.Label015)
        Me.Controls.Add(Me.Date008)
        Me.Controls.Add(Me.Label017)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.Number001_nTax)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Edit013)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Combo005)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.ZH)
        Me.Controls.Add(Me.Date006)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Edit012)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Edit010)
        Me.Controls.Add(Me.Edit009)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button0)
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
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Number040)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F10_Form13"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "続行・返却"
        Me.Panel_見積.ResumeLayout(False)
        CType(Me.Number039, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number029, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number019, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_M003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_M001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid_M1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_M001, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Number040, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_受付.ResumeLayout(False)
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
        CType(Me.Date006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).EndInit()
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
    '**  起動時
    '********************************************************************
    Private Sub F10_Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        Inz_Dsp()   '**  初期画面セット
        Button12_Click(sender, e)

        If P_DBG = "True" Then 'デバック表示
            ZH.Visible = True
            Number039.Visible = True
            CK_own_flg.Visible = True
        End If

    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        '消費税率
        Wk_TAX = tax_rate_get(Now) '消費税率取得
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0

        'strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '008')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'DaList1.Fill(DsList1, "tax")
        'DB_CLOSE()
        'DtView1 = New DataView(DsList1.Tables("tax"), "", "", DataViewRowState.CurrentRows)
        'WK_tax = DtView1(0)("cls_code_name")
    End Sub

    Sub tax(ByVal p_date)
        '消費税率
        Wk_TAX = tax_rate_get(p_date) '消費税率取得
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0
    End Sub

    '********************************************************************
    '**  権限チェック
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='113'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button6.Enabled = False
                    Button7.Enabled = False
                Case Is = "3"
                    Button6.Enabled = True
                    Button7.Enabled = True
                Case Is = "4"
                    Button6.Enabled = True
                    Button7.Enabled = True
            End Select
        Else
            Button6.Enabled = False
            Button7.Enabled = False
        End If
    End Sub

    '********************************************************************
    '**  初期画面セット
    '********************************************************************
    Sub Inz_Dsp()
        msg.Text = Nothing

        Button0.Enabled = True
        Button2.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button9.Enabled = False
        Button80.Enabled = False
        Button97.Visible = False
        Edit000.Text = Nothing  '受付番号
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
        Date001.Text = Nothing
        Date003.Text = Nothing
        Date004.Text = Nothing
        Date006.Enabled = False : Date006.Text = Nothing : Date006.BackColor = System.Drawing.SystemColors.Window
        Date007.Enabled = False : Date007.Text = Nothing : Date007.BackColor = System.Drawing.SystemColors.Window
        Date008.Enabled = False : Date008.Text = Nothing : Date008.BackColor = System.Drawing.SystemColors.Window
        Date015.Text = Nothing
        Combo001.Text = Nothing
        Combo002.Text = Nothing
        Combo003.Text = Nothing
        Combo004.Text = Nothing
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
        Edit012.Text = Nothing
        Edit013.Text = Nothing
        Mask1.Text = Nothing
        Edit014.Text = Nothing
        Edit015.Text = Nothing
        CkBox01_Y.Checked = False
        CkBox01_N.Checked = False

        Date_U001.Text = Nothing
        Date_U002.Text = Nothing
        Date_U003.Text = Nothing
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
        Panel_U1.Controls.Clear()
        Panel_U2.Controls.Clear()

        Edit_M001.Text = Nothing
        Edit_M002.Text = Nothing
        Edit_M003.Text = Nothing
        Edit_M004.Enabled = False : Edit_M004.Text = Nothing : Edit_M004.BackColor = System.Drawing.SystemColors.Window
        Combo_M001.Text = Nothing
        Combo_M003.Text = Nothing
        Number001.Value = 0 : Number001_nTax.Value = 0
        Number002.Value = 0
        Number003.Value = 0
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

        cntact1.Text = Nothing
        cntact2.Text = Nothing
        CheckBox1.Enabled = False : CheckBox1.Checked = False

        Edit000.Focus()
    End Sub

    '********************************************************************
    '**  受付番号Enter
    '********************************************************************
    Private Sub Edit000_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Edit000.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button12_Click(sender, e)
            rep_scan()  '** 修理情報ＧＥＴ
        End If
    End Sub

    '********************************************************************
    '** 修理情報ＧＥＴ(SQL)
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

        SqlCmd1 = New SqlClient.SqlCommand("sp_T01_REP_MTR_M", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram2.Value = Edit000.Text
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "T01_REP_MTR_M")

        '部品
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
    '** 修理情報ＧＥＴ
    '********************************************************************
    Sub rep_scan()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Edit000.BackColor = System.Drawing.SystemColors.Window
        msg.Text = Nothing

        Edit000.Text = Trim(Edit000.Text)
        rep_sql()   '** 修理情報ＧＥＴ(SQL)

        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Edit000.BackColor = System.Drawing.Color.Red
            msg.Text = "該当する受付番号がありません。"
        Else
            Button0.Enabled = False
            Button2.Enabled = True
            Button6.Enabled = False
            Button7.Enabled = False
            Button9.Enabled = True
            If Not IsDBNull(DtView1(0)("haita_empl_code")) Then
                MessageBox.Show(DtView1(0)("haita_empl_name") & "さんが " & DtView1(0)("haita_use_date") & " から、編集中です。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                If IsDBNull(DtView1(0)("stts")) Then WK_str = Nothing Else WK_str = DtView1(0)("stts")
                If WK_str = "45" Then
                    MessageBox.Show("Q&Aステータス45:受付保留のため、参照のみ", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    If IsDBNull(DtView1(0)("brch_code")) Then DtView1(0)("brch_code") = ""
                    If P_EMPL_BRCH <> DtView1(0)("rcpt_brch_code") _
                        And P_EMPL_BRCH <> DtView1(0)("brch_code") _
                        And P_full <> "True" Then
                        If P_tokubetu = "1" Then
                            ANS = MessageBox.Show("他部署修理ですが、更新を可能にしますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            If ANS = "6" Then  'はい
                                HAITA_ON(Edit000.Text)  'HAITA_ON
                                Button6.Enabled = True
                                Button7.Enabled = True
                            End If
                        Else
                            MessageBox.Show("他部署修理のため、参照のみ", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    Else
                        If Not IsDBNull(DtView1(0)("comp_date")) Then
                            If P_tokubetu = "1" Then
                                ANS = MessageBox.Show("既に完成していますが、更新を可能にしますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                If ANS = "6" Then  'はい
                                    HAITA_ON(Edit000.Text)  'HAITA_ON
                                    Button6.Enabled = True
                                    Button7.Enabled = True
                                End If
                            Else
                                MessageBox.Show("完了しているため、参照のみ", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        Else
                            If IsDBNull(DtView1(0)("etmt_date")) Then
                                MessageBox.Show("見積がされていません", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                HAITA_ON(Edit000.Text)  'HAITA_ON
                                Button7.Enabled = True
                            Else
                                HAITA_ON(Edit000.Text)  'HAITA_ON
                                Button6.Enabled = True
                                Button7.Enabled = True
                            End If
                        End If
                    End If
                End If
            End If

            Edit000.ReadOnly = True : Edit000.TabStop = False : Edit000.BackColor = System.Drawing.SystemColors.Control
            Button80.Enabled = True
            Edit901.Text = DtView1(0)("rcpt_ent_empl_name")
            If Not IsDBNull(DtView1(0)("rcpt_brch_name")) Then Edit902.Text = DtView1(0)("rcpt_brch_name")

            If Not IsDBNull(DtView1(0)("store_accp_date")) Then Date001.Text = DtView1(0)("store_accp_date") Else Date001.Text = Nothing
            If Not IsDBNull(DtView1(0)("accp_date")) Then Date003.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView1(0)("accp_date")) ' Date003.Text = DtView1(0)("accp_date") Else Date003.Text = Nothing
            Date007.Enabled = True
            If Not IsDBNull(DtView1(0)("part_ordr_date")) Then Date007.Text = DtView1(0)("part_ordr_date")
            If Date007.Number = 0 Then
                Date007.BackColor = System.Drawing.Color.Red
                msg.Text = Label015.Text & "に日付が入っていません。確認願います。"
            End If
            Date008.Enabled = True
            If Not IsDBNull(DtView1(0)("part_rcpt_date")) Then Date008.Text = DtView1(0)("part_rcpt_date")
            If Date003.Number <> 0 Then
                Label017.Text = "経過日数：" & DateDiff(DateInterval.Day, CDate(Date003.Text).Date, Now.Date)
            Else
                Label017.Text = "経過日数："
            End If
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
                    Label5.Text = "生協富士通保険"
                Case Else
                    Label21.Visible = False : Edit011.Visible = False : Label5.Visible = False : Edit011.Text = Nothing 'QG No
                    Label10.Visible = False : Number001_nTax.Visible = False : Label16.Visible = False
                    Label15.Visible = False : Number003.Visible = False : Label17.Visible = False
                    Label5.Text = Nothing
            End Select

            Combo002.Text = DtView1(0)("arvl_name")
            If DtView1(0)("cls_code_name_abbr2") = "一般" Then
                '販社非表示
                Label004.Visible = False : Label006.Visible = False : Label007.Visible = False
                Edit003.Visible = False : Edit004.Visible = False : Date001.Visible = False
            Else                                    '販社
                '販社表示
                Label004.Visible = True : Label006.Visible = True : Label007.Visible = True
                Edit003.Visible = True : Edit004.Visible = True : Date001.Visible = True
            End If

            Combo003.Text = DtView1(0)("arvl_empl_name")
            'Cmb1()  '修理種別
            Combo004.Text = DtView1(0)("rpar_cls_name")
            If Not IsDBNull(DtView1(0)("acdt_name")) Then Combo005.Text = DtView1(0)("acdt_name") Else Combo005.Text = Nothing
            If Not IsDBNull(DtView1(0)("defe_name")) Then Combo006.Text = DtView1(0)("defe_name") Else Combo006.Text = Nothing
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
            If Not IsDBNull(DtView1(0)("reference_no")) Then Edit014.Text = DtView1(0)("reference_no") Else Edit014.Text = Nothing
            If Not IsDBNull(DtView1(0)("imv_rcpt_no")) Then Edit015.Text = DtView1(0)("imv_rcpt_no") Else Edit015.Text = Nothing
            Mask1.Value = DtView1(0)("zip")
            If Not IsDBNull(DtView1(0)("wrn_limt_amnt")) Then Number001.Value = DtView1(0)("wrn_limt_amnt") Else Number001.Value = 0
            Number001_nTax.Value = RoundDOWN(Number001.Value / Wk_TAX_1, 0)
            If Not IsDBNull(DtView1(0)("recv_amnt")) Then Number002.Value = DtView1(0)("recv_amnt") Else Number002.Value = 0
            If Not IsDBNull(DtView1(0)("menseki_amnt")) Then Number003.Value = DtView1(0)("menseki_amnt") Else Number003.Value = 0

            '受付情報 **********************************

            If Not IsDBNull(DtView1(0)("prch_date")) Then Date_U001.Text = DtView1(0)("prch_date") Else Date_U001.Text = Nothing
            If Not IsDBNull(DtView1(0)("vndr_wrn_date")) Then Date_U002.Text = DtView1(0)("vndr_wrn_date") Else Date_U002.Text = Nothing
            If Not IsDBNull(DtView1(0)("acdt_date")) Then Date_U003.Text = DtView1(0)("acdt_date") Else Date_U003.Text = Nothing
            If IsDBNull(DtView1(0)("vndr_wrn_date_chk")) Then DtView1(0)("vndr_wrn_date_chk") = "False"
            If DtView1(0)("vndr_wrn_date_chk") = "1" Then
                CheckBox_U002.Checked = True
            Else
                CheckBox_U002.Checked = False
            End If

            Combo_U001.Text = DtView1(0)("vndr_name")
            If DtView1(0)("vndr_code") = "01" Then
                CheckBox_U001.Text = "定額修理"
                CheckBox_U003.Visible = True
            Else
                CheckBox_U001.Text = "Ｎｏｔｅ"
                CheckBox_U003.Visible = False
            End If
            If Not IsDBNull(DtView1(0)("rpar_comp_name")) Then
                Combo_U002.Text = DtView1(0)("rpar_comp_name")
            End If

            If Not IsDBNull(DtView1(0)("own_flg")) Then
                If DtView1(0)("own_flg") = "1" Then CK_own_flg.Checked = True Else CK_own_flg.Checked = False
            Else
                CK_own_flg.Checked = False
            End If
            If CK_own_flg.Checked = True Then
                Label015.Text = "部品発注日"
                Label016.Text = "部品受領日"
            Else
                Label015.Text = "ﾒｰｶｰ発送日"
                Label016.Text = "ﾒｰｶｰ戻日"
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

            '付属品
            strSQL = "SELECT item_name, amnt, item_unit FROM T02_ATCH_ITEM WHERE (rcpt_no = '" & Edit000.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "T02_ATCH_ITEM")
            DB_CLOSE()

            DtView2 = New DataView(DsList1.Tables("T02_ATCH_ITEM"), "", "", DataViewRowState.CurrentRows)
            Line_No = 0
            Panel_U1.Controls.Clear()

            If DtView2.Count <> 0 Then
                For Line_No = 0 To DtView2.Count - 1

                    '対象
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

                    '付属品
                    en = 1
                    edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(30, 20 * Line_No)
                    edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    edit(Line_No, en).Size = New System.Drawing.Size(150, 20)
                    edit(Line_No, en).Enabled = False
                    edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    edit(Line_No, en).Text = DtView2(Line_No)("item_name")
                    edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
                    Panel_U1.Controls.Add(edit(Line_No, en))

                    '数量
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
                    nbrBox(Line_No, en).Value = DtView2(Line_No)("amnt")
                    If Trim(DtView2(Line_No)("item_unit")) = Nothing And DtView2(Line_No)("amnt") = 0 Then
                        nbrBox(Line_No, en).Visible = False
                    End If
                    Panel_U1.Controls.Add(nbrBox(Line_No, en))

                    '単位
                    en = 2
                    edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                    edit(Line_No, en).Location = New System.Drawing.Point(210, 20 * Line_No)
                    edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                    edit(Line_No, en).Size = New System.Drawing.Size(50, 20)
                    edit(Line_No, en).Enabled = False
                    edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                    edit(Line_No, en).Text = DtView2(Line_No)("item_unit")
                    edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
                    If Trim(DtView2(Line_No)("item_unit")) = Nothing Then
                        edit(Line_No, en).Visible = False
                    End If
                    Panel_U1.Controls.Add(edit(Line_No, en))

                Next
            End If

            '故障内容
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
                    add_line_2()    '故障内容
                Next
            End If

            '見積情報 **********************************
            DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

            If Not IsDBNull(DtView2(0)("sindan_date")) Then
                'Date015.Text = DtView2(0)("sindan_date")
                Date015.Text = String.Format("{0:yyyy/MM/dd HH:mm}", DtView1(0)("sindan_date")) '
            End If
            If Not IsDBNull(DtView2(0)("etmt_date")) Then
                Date004.Text = DtView2(0)("etmt_date")
                tax(String.Format("{0:yyyy/MM/dd}", CDate(Date004.Text)))
            End If

            If Not IsDBNull(DtView2(0)("etmt_empl_name")) Then Combo_M001.Text = DtView2(0)("etmt_empl_name") Else Combo_M001.Text = Nothing
            If Not IsDBNull(DtView2(0)("tier_name")) Then Combo_M003.Text = DtView2(0)("tier_name") Else Combo_M003.Text = Nothing
            If Not IsDBNull(DtView1(0)("own_flg")) Then
                If DtView1(0)("own_flg") = "1" Then    '自社修理
                    Edit_M001.Visible = False : Label_M01.Visible = False
                    'Combo_M001.Visible = True : Label_M02.Visible = True
                    'Combo_M003.Visible = True : Label_M04.Visible = True
                Else
                    Edit_M001.Visible = True : Label_M01.Visible = True
                    'Combo_M001.Visible = False : Label_M02.Visible = False
                    'Combo_M003.Visible = False : Label_M04.Visible = False
                    If Not IsDBNull(DtView2(0)("vndr_repr_no")) Then Edit_M001.Text = DtView2(0)("vndr_repr_no") Else Edit_M001.Text = Nothing
                End If
            Else
                Edit_M001.Visible = True : Label_M01.Visible = True
                If Not IsDBNull(DtView2(0)("vndr_repr_no")) Then Edit_M001.Text = DtView2(0)("vndr_repr_no") Else Edit_M001.Text = Nothing
            End If

            If Not IsDBNull(DtView2(0)("etmt_meas")) Then Edit_M002.Text = DtView2(0)("etmt_meas") Else Edit_M002.Text = Nothing
            If Not IsDBNull(DtView2(0)("etmt_comn")) Then Edit_M003.Text = DtView2(0)("etmt_comn") Else Edit_M003.Text = Nothing
            Edit_M004.Enabled = True
            If Not IsDBNull(DtView2(0)("rsrv_cacl_comn")) Then Edit_M004.Text = DtView2(0)("rsrv_cacl_comn") Else Edit_M004.Text = Nothing

            If Not IsDBNull(DtView2(0)("etmt_cost_tech_chrg")) Then Number031.Value = DtView2(0)("etmt_cost_tech_chrg") Else Number031.Value = 0
            If Not IsDBNull(DtView2(0)("etmt_cost_apes")) Then Number032.Value = DtView2(0)("etmt_cost_apes") Else Number032.Value = 0
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
            If Not IsDBNull(DtView2(0)("comp_comn")) Then comp_comn.Text = DtView2(0)("comp_comn") Else comp_comn.Text = Nothing

            '見積内容
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
            WK_DsCMB3.Clear()

            '基準点
            label_3(0, 0) = New Label
            label_3(0, 0).Location = New System.Drawing.Point(0, 0)
            label_3(0, 0).Size = New System.Drawing.Size(0, 0)
            label_3(0, 0).Text = Nothing
            Panel_M1.Controls.Add(label_3(0, 0))

            WK_DtView1 = New DataView(DsList1.Tables("T03_REP_CMNT_2"), "", "seq", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                For i = 0 To WK_DtView1.Count - 1
                    add_line_3("1")    '見積内容
                Next
            End If

            '部品
            Dim tbl As New DataTable
            tbl = P_DsList1.Tables("T04_REP_PART")
            DataGrid_M1.DataSource = tbl

            '続行返却情報 **********************************
            Date006.Enabled = True
            If Not IsDBNull(DtView2(0)("rsrv_cacl_date")) Then
                Date006.Text = DtView2(0)("rsrv_cacl_date")
                'Else
                '    Date006.Text = Now.Date
            End If
            If Not IsDBNull(DtView2(0)("zh_code")) Then ZH.Text = DtView2(0)("zh_code") Else ZH.Text = Nothing
            Edit_M004.Focus()

            Call CONTACT_GET(Edit000.Text)
            cntact1.Text = P1_CONTACT
            cntact2.Text = P2_CONTACT
            CheckBox1.Enabled = True
            If P3_CONTACT = "True" Then CheckBox1.Checked = True Else CheckBox1.Checked = False

            's/n変更履歴
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

    '故障内容
    Sub add_line_2()
        DB_OPEN("nMVAR")
        Line_No2 = Line_No2 + 1

        '故障内容
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

    '見積内容
    Sub add_line_3(ByVal flg)
        DB_OPEN("nMVAR")
        Line_No3 = Line_No3 + 1

        '見積内容
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
        cmbBo_3(Line_No3, en).DisplayMember = "cmnt"
        cmbBo_3(Line_No3, en).ValueMember = "cmnt_code"
        cmbBo_3(Line_No3, en).Tag = Line_No3
        cmbBo_3(Line_No3, en).Enabled = False
        cmbBo_3(Line_No3, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        Panel_M1.Controls.Add(cmbBo_3(Line_No3, en))
        If flg = "1" Then
            If Not IsDBNull(WK_DtView1(i)("cmnt_name1")) Then
                cmbBo_3(Line_No3, en).Text = WK_DtView1(i)("cmnt_name1")
            Else
                cmbBo_3(Line_No3, en).Text = Nothing
            End If
        Else
            cmbBo_3(Line_No3, en).Text = Nothing
        End If

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** ？受付番号検索
    '********************************************************************
    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form04 As New F00_Form04
        F00_Form04.ShowDialog()

        If P_RTN = "1" Then
            Button12_Click(sender, e)
            Edit000.Text = P_PRAM1
            rep_scan()  '** 修理情報ＧＥＴ
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '** 受付画面
    '********************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Panel_受付.Visible = True
        Panel_見積.Visible = False
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '** 見積画面
    '********************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Panel_受付.Visible = False
        Panel_見積.Visible = True
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Date006()   '回答受信日
        msg.Text = Nothing
        If Date006.Number = 0 Then
            Date006.BackColor = System.Drawing.Color.Red
            msg.Text = "回答受信日を入力してください。"
            Exit Sub
        End If

        If Date003.Text > Date006.Text & " 23:59:59" Then         '受付日>回答受信日
            Date006.BackColor = System.Drawing.Color.Red
            msg.Text = "受付日＞回答受信日の入力はできません。"
            Exit Sub
        End If

        If Date004.Number <> 0 Then
            If Date004.Text > Date006.Text Then     '見積日>回答受信日
                Date006.BackColor = System.Drawing.Color.Red
                msg.Text = "見積日＞回答受信日の入力はできません。"
                Exit Sub
            End If
        End If

        If Date006.Text > Now.Date Then             '回答受信日>now
            Date006.BackColor = System.Drawing.Color.Red
            msg.Text = "回答受信日に本日以降の入力はできません。"
            Exit Sub
        End If

        Date006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date007()   '部品発注日
        msg.Text = Nothing
        If Date007.Number = 0 Then
            Date007.BackColor = System.Drawing.Color.Red
            msg.Text = Label015.Text & "に日付が入っていません。確認願います。"
            Exit Sub
        End If
        Date007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date008()   '部品受領日
        msg.Text = Nothing

        Date008.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        CHK_Date006()   '回答受信日
        If msg.Text <> Nothing Then Err_F = "1" : Date006.Focus() : Exit Sub
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit000_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.GotFocus
        If Edit000.ReadOnly = False Then
            Edit000.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        End If
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
    Private Sub Edit_M004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M004.GotFocus
        Edit_M004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit000_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.LostFocus
        If Edit000.ReadOnly = False Then
            Edit000.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Private Sub Date006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date006.LostFocus
        CHK_Date006()       '回答受信日
    End Sub
    Private Sub Date007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.LostFocus
        CHK_Date007()   '部品発注日
    End Sub
    Private Sub Date008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.LostFocus
        CHK_Date008()   '部品受領日
    End Sub
    Private Sub Edit_M004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_M004.LostFocus
        Edit_M004.Text = Trim(Edit_M004.Text)
        Edit_M004.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  変更箇所チェック
    '********************************************************************
    Sub CHG_CHK()
        CHG_F = "0"
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

        WK_str = Trim(Edit_M004.Text)
        If IsDBNull(DtView2(0)("rsrv_cacl_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("rsrv_cacl_comn")
        If WK_str <> WK_str2 Then
            CHG_F = "1" : Exit Sub '解除連絡
        End If

        If Date006.Number = 0 Then WK_str = Nothing Else WK_str = Date006.Text
        If IsDBNull(DtView2(0)("rsrv_cacl_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("rsrv_cacl_date")
        If WK_str <> WK_str2 Then
            CHG_F = "1" : Exit Sub '見積受信日
        End If

        If Date007.Number = 0 Then WK_str = Nothing Else WK_str = Date007.Text
        If IsDBNull(DtView2(0)("part_ordr_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("part_ordr_date")
        If WK_str <> WK_str2 Then
            CHG_F = "1" : Exit Sub '部品発注日
        End If

        If Date008.Number = 0 Then WK_str = Nothing Else WK_str = Date008.Text
        If IsDBNull(DtView2(0)("part_rcpt_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("part_rcpt_date")
        If WK_str <> WK_str2 Then
            CHG_F = "1" : Exit Sub '部品受領日
        End If

        If ZH.Text = Nothing Then WK_str = Nothing Else If ZH.Text = "Z" Then WK_str = "続行" Else WK_str = "返却"
        If IsDBNull(DtView2(0)("zh_code")) Then WK_str2 = Nothing Else If DtView2(0)("zh_code") = "Z" Then WK_str2 = "続行" Else WK_str2 = "返却"
        If WK_str <> WK_str2 Then
            CHG_F = "1" : Exit Sub '続行/返却
        End If

    End Sub

    '********************************************************************
    '**  変更履歴
    '********************************************************************
    Sub CHG_HSTY()
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR_M"), "", "", DataViewRowState.CurrentRows)

        If IsDBNull(DtView2(0)("rsrv_cacl_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("rsrv_cacl_comn")
        If Edit_M004.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "解除連絡", WK_str2, Edit_M004.Text)
        End If

        If Date006.Number = 0 Then WK_str = Nothing Else WK_str = Date006.Text
        If IsDBNull(DtView2(0)("rsrv_cacl_date")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("rsrv_cacl_date")
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "見積受信日", WK_str2, WK_str)
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

        If ZH.Text = "Z" Then WK_str = "続行" Else WK_str = "返却"
        If IsDBNull(DtView2(0)("zh_code")) Then WK_str2 = Nothing Else If DtView2(0)("zh_code") = "Z" Then WK_str2 = "続行" Else WK_str2 = "返却"
        If WK_str <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "続行/返却", WK_str2, WK_str)
        End If

        If IsDBNull(DtView2(0)("comp_comn")) Then WK_str2 = Nothing Else WK_str2 = DtView2(0)("comp_comn")
        If comp_comn.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_hsty(Edit000.Text, "修理コメント", WK_str2, comp_comn.Text)
        End If

    End Sub

    '********************************************************************
    '**  クリア
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CHG_CHK()   '**  変更箇所チェック
        If CHG_F = "1" Then
            ANS = MessageBox.Show("変更箇所があります。クリアしますか。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            If ANS = "2" Then Exit Sub 'いいえ
        End If
        HAITA_OFF(Edit000.Text)  'HAITA_OFF
        Inz_Dsp()   '**  初期画面セット
    End Sub

    '********************************************************************
    '**  続行
    '********************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ZH.Text = "Z"
        upd()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  返却
    '********************************************************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ZH.Text = "H"

        If comp_comn.Text = Nothing Then
            comp_comn.Text = WK_H_comn
        Else
            If comp_comn.Text.LastIndexOf(WK_H_comn) = -1 Then
                comp_comn.Text = Trim(comp_comn.Text) & System.Environment.NewLine & WK_H_comn
            End If
        End If
        upd()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub upd()
        chg_itm = 0
        P_HSTY_DATE = Now
        F_Check()   '**  項目チェック
        If Err_F = "0" Then

            If Date007.Number = 0 Then
                ANS = MessageBox.Show(Label015.Text & "に日付が入っていません。" & System.Environment.NewLine & "更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then Exit Sub 'いいえ
            End If

            CHG_HSTY()  '**  変更履歴

            If chg_itm <> 0 Then
                strSQL = "UPDATE T01_REP_MTR"
                strSQL += " SET zh_code = '" & ZH.Text & "'"
                strSQL += ", rsrv_cacl_comn = '" & Edit_M004.Text & "'"
                strSQL += ", rsrv_cacl_date = '" & Date006.Text & "'"
                If Date007.Number <> 0 Then strSQL += ", part_ordr_date = '" & Date007.Text & "'" Else strSQL += ", part_ordr_date = NULL"
                If Date008.Number <> 0 Then strSQL += ", part_rcpt_date = '" & Date008.Text & "'" Else strSQL += ", part_rcpt_date = NULL"
                strSQL += ", comp_comn = '" & comp_comn.Text & "'"
                strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Call QA_started_flg_ON(Edit000.Text)    'Q&A 着手済フラグ更新

                Button6.Enabled = False
                Button7.Enabled = False

                rep_sql()   '** 修理情報ＧＥＴ(SQL)
                msg.Text = "更新しました。"
                HAITA_OFF(Edit000.Text)  'HAITA_OFF
            Else
                msg.Text = "変更箇所がありません。"
            End If
        End If
    End Sub

    '********************************************************************
    '**  コンタクトログ
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
    '**  別No照会
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_search.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  s/n 履歴
    '********************************************************************
    Private Sub Button97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button97.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim F00_Form17 As New F00_Form17
        F00_Form17.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  履歴
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '変更履歴
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
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        If Button7.Enabled = True Then
            CHG_CHK()   '**  変更箇所チェック
            If CHG_F = "1" Then
                ANS = MessageBox.Show("変更箇所があります。終了しますか。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then Exit Sub 'いいえ
            End If
            HAITA_OFF(Edit000.Text)  'HAITA_OFF
        End If
        WK_DsList1.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class