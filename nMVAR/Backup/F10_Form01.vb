Imports GrapeCity.Win.Input

Public Class F10_Form01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, DsCnld, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2, WK_DtView3 As DataView

    Dim strSQL, Err_F, Err_CX, ANS As String
    Dim i, r, en, Line_No, Line_No2, chg_itm, seq As Integer
    Dim cmb_reset As String
    Dim Wk_TAX As Integer
    Dim Wk_TAX_1, Wk_TAX_0 As Decimal

    Dim Date_From, Date_To As Date

    Dim WK_ios As String

    '付属品
    Private chkBox(99, 1) As CheckBox
    Private label(99, 2) As label
    Private nbrBox(99, 1) As GrapeCity.Win.Input.Number
    Private edit(99, 2) As GrapeCity.Win.Input.Edit

    '故障内容
    Private cmbBo_2(99, 2) As GrapeCity.Win.Input.Combo
    Private label_2(99, 2) As label
    Dim WK_DsCMB As New DataSet

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.Furigana = Me.Edit005.Ime

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Edit902 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit901 As GrapeCity.Win.Input.Edit
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Mask
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit008 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit007 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo004 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents CL004 As System.Windows.Forms.Label
    Friend WithEvents Date003 As GrapeCity.Win.Input.Date
    Friend WithEvents CLU001 As System.Windows.Forms.Label
    Friend WithEvents Label014 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents Edit011 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_U001 As System.Windows.Forms.CheckBox
    Friend WithEvents T2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents brk01 As System.Windows.Forms.Label
    Friend WithEvents CLU002 As System.Windows.Forms.Label
    Friend WithEvents CL002_2 As System.Windows.Forms.Label
    Friend WithEvents Button_S2 As System.Windows.Forms.Button
    Friend WithEvents Button_S3 As System.Windows.Forms.Button
    Friend WithEvents Edit012 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_S4 As System.Windows.Forms.Button
    Friend WithEvents brk02 As System.Windows.Forms.Label
    Friend WithEvents brk03 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Date_U002 As GrapeCity.Win.Input.Date
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Date_U003 As GrapeCity.Win.Input.Date
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NumberN007 As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN003 As GrapeCity.Win.Input.Number
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents NumberN008 As GrapeCity.Win.Input.Number
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL005 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents brk07 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Edit013 As GrapeCity.Win.Input.Edit
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents prch_amnt As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Number001_nTax As GrapeCity.Win.Input.Number
    Friend WithEvents CheckBox_U002 As System.Windows.Forms.CheckBox
    Friend WithEvents GRP As System.Windows.Forms.Label
    Friend WithEvents Button_S5 As System.Windows.Forms.Button
    Friend WithEvents CheckBox_U003 As System.Windows.Forms.CheckBox
    Friend WithEvents Wrn_Y As System.Windows.Forms.Label
    Friend WithEvents end_date As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL006 As System.Windows.Forms.Label
    Friend WithEvents Date007 As GrapeCity.Win.Input.Date
    Friend WithEvents Date008 As GrapeCity.Win.Input.Date
    Friend WithEvents Label016 As System.Windows.Forms.Label
    Friend WithEvents Label015 As System.Windows.Forms.Label
    Friend WithEvents CK_own_flg As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Edit014 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit015 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit_U006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Date_U004 As GrapeCity.Win.Input.Date
    Friend WithEvents CkBox01_Y As System.Windows.Forms.CheckBox
    Friend WithEvents CkBox01_N As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Button97 As System.Windows.Forms.Button
    Friend WithEvents sn_n As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Edit016 As GrapeCity.Win.Input.Edit
    Friend WithEvents Date015 As GrapeCity.Win.Input.Date
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label014 = New System.Windows.Forms.Label
        Me.Combo004 = New GrapeCity.Win.Input.Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Label012 = New System.Windows.Forms.Label
        Me.Date003 = New GrapeCity.Win.Input.Date
        Me.Edit006 = New GrapeCity.Win.Input.Edit
        Me.Edit008 = New GrapeCity.Win.Input.Edit
        Me.Edit007 = New GrapeCity.Win.Input.Edit
        Me.Edit005 = New GrapeCity.Win.Input.Edit
        Me.Edit004 = New GrapeCity.Win.Input.Edit
        Me.Label011 = New System.Windows.Forms.Label
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Edit000 = New GrapeCity.Win.Input.Edit
        Me.Label18 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Label20 = New System.Windows.Forms.Label
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.msg = New System.Windows.Forms.Label
        Me.Edit902 = New GrapeCity.Win.Input.Edit
        Me.Edit901 = New GrapeCity.Win.Input.Edit
        Me.Edit010 = New GrapeCity.Win.Input.Edit
        Me.Edit009 = New GrapeCity.Win.Input.Edit
        Me.Mask1 = New GrapeCity.Win.Input.Mask
        Me.Label013 = New System.Windows.Forms.Label
        Me.Edit002 = New GrapeCity.Win.Input.Edit
        Me.CL001 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL003 = New System.Windows.Forms.Label
        Me.CL004 = New System.Windows.Forms.Label
        Me.CLU002 = New System.Windows.Forms.Label
        Me.CLU001 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel_受付 = New System.Windows.Forms.Panel
        Me.Label27 = New System.Windows.Forms.Label
        Me.Date_U004 = New GrapeCity.Win.Input.Date
        Me.Edit_U006 = New GrapeCity.Win.Input.Edit
        Me.Label25 = New System.Windows.Forms.Label
        Me.CheckBox_U003 = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Date_U003 = New GrapeCity.Win.Input.Date
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
        Me.Button_S4 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Date_U002 = New GrapeCity.Win.Input.Date
        Me.Label19_1 = New System.Windows.Forms.Label
        Me.Date_U001 = New GrapeCity.Win.Input.Date
        Me.CheckBox_U002 = New System.Windows.Forms.CheckBox
        Me.brk02 = New System.Windows.Forms.Label
        Me.Edit011 = New GrapeCity.Win.Input.Edit
        Me.Label21 = New System.Windows.Forms.Label
        Me.T2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.brk01 = New System.Windows.Forms.Label
        Me.CL002_2 = New System.Windows.Forms.Label
        Me.Button_S2 = New System.Windows.Forms.Button
        Me.Button_S3 = New System.Windows.Forms.Button
        Me.Edit012 = New GrapeCity.Win.Input.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.brk03 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.Label11 = New System.Windows.Forms.Label
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.NumberN008 = New GrapeCity.Win.Input.Number
        Me.NumberN007 = New GrapeCity.Win.Input.Number
        Me.NumberN003 = New GrapeCity.Win.Input.Number
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label001 = New GrapeCity.Win.Input.Edit
        Me.Label002 = New GrapeCity.Win.Input.Edit
        Me.Label15 = New System.Windows.Forms.Label
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.Label14 = New System.Windows.Forms.Label
        Me.Combo005 = New GrapeCity.Win.Input.Combo
        Me.CL005 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.brk07 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Edit013 = New GrapeCity.Win.Input.Edit
        Me.Button3 = New System.Windows.Forms.Button
        Me.prch_amnt = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Number001_nTax = New GrapeCity.Win.Input.Number
        Me.GRP = New System.Windows.Forms.Label
        Me.Button_S5 = New System.Windows.Forms.Button
        Me.Wrn_Y = New System.Windows.Forms.Label
        Me.end_date = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Combo006 = New GrapeCity.Win.Input.Combo
        Me.CL006 = New System.Windows.Forms.Label
        Me.Date007 = New GrapeCity.Win.Input.Date
        Me.Label016 = New System.Windows.Forms.Label
        Me.Label015 = New System.Windows.Forms.Label
        Me.Date008 = New GrapeCity.Win.Input.Date
        Me.CK_own_flg = New System.Windows.Forms.CheckBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Edit014 = New GrapeCity.Win.Input.Edit
        Me.Label24 = New System.Windows.Forms.Label
        Me.Edit015 = New GrapeCity.Win.Input.Edit
        Me.Label26 = New System.Windows.Forms.Label
        Me.CkBox01_Y = New System.Windows.Forms.CheckBox
        Me.CkBox01_N = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Button97 = New System.Windows.Forms.Button
        Me.sn_n = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Edit016 = New GrapeCity.Win.Input.Edit
        Me.Date015 = New GrapeCity.Win.Input.Date
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit902, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit901, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_受付.SuspendLayout()
        CType(Me.Date_U004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_U003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo_U002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_U1.SuspendLayout()
        CType(Me.Date_U002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_U001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberN003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit016, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 660)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 270
        Me.Button98.Text = "戻る"
        '
        'Label014
        '
        Me.Label014.BackColor = System.Drawing.Color.Navy
        Me.Label014.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label014.ForeColor = System.Drawing.Color.White
        Me.Label014.Location = New System.Drawing.Point(16, 216)
        Me.Label014.Name = "Label014"
        Me.Label014.Size = New System.Drawing.Size(80, 20)
        Me.Label014.TabIndex = 1109
        Me.Label014.Text = "修理種別"
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
        Me.Combo004.TabIndex = 200
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
        Me.Label13.TabIndex = 1019
        Me.Label13.Text = "受付担当者"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BackColor = System.Drawing.Color.Navy
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.ForeColor = System.Drawing.Color.White
        Me.Label004.Location = New System.Drawing.Point(452, 80)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(84, 20)
        Me.Label004.TabIndex = 1016
        Me.Label004.Text = "販社担当者"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.AllowSpace = False
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(96, 80)
        Me.Edit001.MaxLength = 4
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(48, 20)
        Me.Edit001.TabIndex = 60
        Me.Edit001.Text = "9999"
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit003
        '
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(536, 80)
        Me.Edit003.MaxLength = 20
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(112, 20)
        Me.Edit003.TabIndex = 70
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label012
        '
        Me.Label012.BackColor = System.Drawing.Color.Navy
        Me.Label012.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label012.ForeColor = System.Drawing.Color.White
        Me.Label012.Location = New System.Drawing.Point(16, 172)
        Me.Label012.Name = "Label012"
        Me.Label012.Size = New System.Drawing.Size(80, 20)
        Me.Label012.TabIndex = 1043
        Me.Label012.Text = "電話番号2"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date003
        '
        Me.Date003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date003.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date003.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date003.Location = New System.Drawing.Point(904, 4)
        Me.Date003.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date003.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date003.Name = "Date003"
        Me.Date003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date003.Size = New System.Drawing.Size(112, 20)
        Me.Date003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date003.TabIndex = 27
        Me.Date003.TabStop = False
        Me.Date003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date003.Value = Nothing
        '
        'Edit006
        '
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Format = "KAa"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(292, 172)
        Me.Edit006.MaxLength = 15
        Me.Edit006.Name = "Edit006"
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(196, 20)
        Me.Edit006.TabIndex = 130
        Me.Edit006.TabStop = False
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit008
        '
        Me.Edit008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit008.Format = "9#"
        Me.Edit008.HighlightText = True
        Me.Edit008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit008.LengthAsByte = True
        Me.Edit008.Location = New System.Drawing.Point(96, 172)
        Me.Edit008.MaxLength = 14
        Me.Edit008.Name = "Edit008"
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(112, 20)
        Me.Edit008.TabIndex = 110
        Me.Edit008.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit007
        '
        Me.Edit007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit007.Format = "9#"
        Me.Edit007.HighlightText = True
        Me.Edit007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit007.LengthAsByte = True
        Me.Edit007.Location = New System.Drawing.Point(96, 152)
        Me.Edit007.MaxLength = 14
        Me.Edit007.Name = "Edit007"
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(112, 20)
        Me.Edit007.TabIndex = 100
        Me.Edit007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit005
        '
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(292, 152)
        Me.Edit005.MaxLength = 30
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(196, 20)
        Me.Edit005.TabIndex = 120
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit004
        '
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.Format = "9#aA@"
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(536, 104)
        Me.Edit004.MaxLength = 25
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(112, 20)
        Me.Edit004.TabIndex = 90
        Me.Edit004.Text = "1234567890123456789012345"
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label011
        '
        Me.Label011.BackColor = System.Drawing.Color.Navy
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.ForeColor = System.Drawing.Color.White
        Me.Label011.Location = New System.Drawing.Point(16, 152)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(80, 20)
        Me.Label011.TabIndex = 1015
        Me.Label011.Text = "電話番号1"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label010
        '
        Me.Label010.BackColor = System.Drawing.Color.Navy
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.ForeColor = System.Drawing.Color.White
        Me.Label010.Location = New System.Drawing.Point(212, 152)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(80, 20)
        Me.Label010.TabIndex = 1014
        Me.Label010.Text = "お客様名"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label006
        '
        Me.Label006.BackColor = System.Drawing.Color.Navy
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.ForeColor = System.Drawing.Color.White
        Me.Label006.Location = New System.Drawing.Point(452, 104)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(84, 20)
        Me.Label006.TabIndex = 1013
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
        Me.Label005.TabIndex = 1011
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
        Me.Label003.TabIndex = 1009
        Me.Label003.Text = "販社"
        Me.Label003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 1006
        Me.Label1.Text = "受付番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(824, 4)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 20)
        Me.Label35.TabIndex = 1021
        Me.Label35.Text = "受付日"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 660)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 250
        Me.Button1.Text = "更新"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 1144
        Me.Label7.Text = "受付種別"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo001.Location = New System.Drawing.Point(96, 32)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 10
        Me.Combo001.Value = "Combo001"
        '
        'Edit000
        '
        Me.Edit000.BackColor = System.Drawing.SystemColors.Control
        Me.Edit000.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit000.Format = "A9"
        Me.Edit000.HighlightText = True
        Me.Edit000.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit000.LengthAsByte = True
        Me.Edit000.Location = New System.Drawing.Point(96, 8)
        Me.Edit000.MaxLength = 9
        Me.Edit000.Name = "Edit000"
        Me.Edit000.ReadOnly = True
        Me.Edit000.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit000.Size = New System.Drawing.Size(68, 20)
        Me.Edit000.TabIndex = 0
        Me.Edit000.TabStop = False
        Me.Edit000.Text = "AS1234567"
        Me.Edit000.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit000.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Navy
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(16, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 20)
        Me.Label18.TabIndex = 1147
        Me.Label18.Text = "入荷区分"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo002.Location = New System.Drawing.Point(96, 56)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(196, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 40
        Me.Combo002.Value = "Combo002"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(296, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 20)
        Me.Label20.TabIndex = 1149
        Me.Label20.Text = "入荷担当"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo003
        '
        Me.Combo003.AutoSelect = True
        Me.Combo003.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo003.Location = New System.Drawing.Point(376, 56)
        Me.Combo003.MaxDropDownItems = 20
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(184, 20)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 50
        Me.Combo003.Value = "Combo003"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 640)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(976, 16)
        Me.msg.TabIndex = 1231
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Edit902.TabIndex = 1232
        Me.Edit902.TabStop = False
        Me.Edit902.Text = "Edit902"
        Me.Edit902.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        Me.Edit902.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Edit901.TabIndex = 1234
        Me.Edit901.TabStop = False
        Me.Edit901.Text = "EDIT901"
        Me.Edit901.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Left
        Me.Edit901.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit010
        '
        Me.Edit010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(520, 192)
        Me.Edit010.MaxLength = 400
        Me.Edit010.Name = "Edit010"
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(300, 20)
        Me.Edit010.TabIndex = 160
        Me.Edit010.Text = "ああああああああああああああああああああ"
        Me.Edit010.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit009
        '
        Me.Edit009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit009.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit009.LengthAsByte = True
        Me.Edit009.Location = New System.Drawing.Point(520, 172)
        Me.Edit009.MaxLength = 60
        Me.Edit009.Name = "Edit009"
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(300, 20)
        Me.Edit009.TabIndex = 150
        Me.Edit009.Text = "ああああああああああああああああああああ"
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Mask1
        '
        Me.Mask1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask1.Format = New GrapeCity.Win.Input.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(520, 152)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(76, 20)
        Me.Mask1.TabIndex = 140
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
        Me.Label013.TabIndex = 1238
        Me.Label013.Text = "住所"
        Me.Label013.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit002
        '
        Me.Edit002.AllowSpace = False
        Me.Edit002.BackColor = System.Drawing.SystemColors.Control
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
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
        Me.Edit002.TabIndex = 80
        Me.Edit002.TabStop = False
        Me.Edit002.Text = "9999"
        Me.Edit002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(944, 104)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1249
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(944, 124)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1250
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(944, 144)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(52, 16)
        Me.CL003.TabIndex = 1251
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'CL004
        '
        Me.CL004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL004.Location = New System.Drawing.Point(944, 164)
        Me.CL004.Name = "CL004"
        Me.CL004.Size = New System.Drawing.Size(52, 16)
        Me.CL004.TabIndex = 1252
        Me.CL004.Text = "CL004"
        Me.CL004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL004.Visible = False
        '
        'CLU002
        '
        Me.CLU002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU002.Location = New System.Drawing.Point(944, 244)
        Me.CLU002.Name = "CLU002"
        Me.CLU002.Size = New System.Drawing.Size(52, 16)
        Me.CLU002.TabIndex = 1253
        Me.CLU002.Text = "CLU002"
        Me.CLU002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU002.Visible = False
        '
        'CLU001
        '
        Me.CLU001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CLU001.Location = New System.Drawing.Point(944, 224)
        Me.CLU001.Name = "CLU001"
        Me.CLU001.Size = New System.Drawing.Size(52, 16)
        Me.CLU001.TabIndex = 1256
        Me.CLU001.Text = "CLU001"
        Me.CLU001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLU001.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(212, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 1259
        Me.Label4.Text = "ｶﾅ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel_受付
        '
        Me.Panel_受付.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_受付.Controls.Add(Me.Label27)
        Me.Panel_受付.Controls.Add(Me.Date_U004)
        Me.Panel_受付.Controls.Add(Me.Edit_U006)
        Me.Panel_受付.Controls.Add(Me.Label25)
        Me.Panel_受付.Controls.Add(Me.CheckBox_U003)
        Me.Panel_受付.Controls.Add(Me.Label12)
        Me.Panel_受付.Controls.Add(Me.Date_U003)
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
        Me.Panel_受付.Controls.Add(Me.Button_S4)
        Me.Panel_受付.Controls.Add(Me.Label9)
        Me.Panel_受付.Controls.Add(Me.Date_U002)
        Me.Panel_受付.Controls.Add(Me.Label19_1)
        Me.Panel_受付.Controls.Add(Me.Date_U001)
        Me.Panel_受付.Controls.Add(Me.CheckBox_U002)
        Me.Panel_受付.Location = New System.Drawing.Point(10, 264)
        Me.Panel_受付.Name = "Panel_受付"
        Me.Panel_受付.Size = New System.Drawing.Size(986, 372)
        Me.Panel_受付.TabIndex = 230
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label27.Location = New System.Drawing.Point(840, 52)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(20, 20)
        Me.Label27.TabIndex = 1431
        Me.Label27.Text = "～"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U004
        '
        Me.Date_U004.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U004.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U004.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U004.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U004.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U004.Location = New System.Drawing.Point(864, 52)
        Me.Date_U004.Name = "Date_U004"
        Me.Date_U004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U004.Size = New System.Drawing.Size(88, 20)
        Me.Date_U004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U004.TabIndex = 68
        Me.Date_U004.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U004.Value = Nothing
        '
        'Edit_U006
        '
        Me.Edit_U006.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U006.Format = "9#aA"
        Me.Edit_U006.HighlightText = True
        Me.Edit_U006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U006.LengthAsByte = True
        Me.Edit_U006.Location = New System.Drawing.Point(460, 52)
        Me.Edit_U006.MaxLength = 15
        Me.Edit_U006.Name = "Edit_U006"
        Me.Edit_U006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U006.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U006.TabIndex = 71
        Me.Edit_U006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(380, 52)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(80, 20)
        Me.Label25.TabIndex = 1429
        Me.Label25.Text = "SB/IMEI"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(764, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 1427
        Me.Label12.Text = "事故日"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U003
        '
        Me.Date_U003.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U003.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U003.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U003.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U003.Location = New System.Drawing.Point(864, 28)
        Me.Date_U003.Name = "Date_U003"
        Me.Date_U003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U003.Size = New System.Drawing.Size(88, 20)
        Me.Date_U003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U003.TabIndex = 65
        Me.Date_U003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U003.Value = Nothing
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
        Me.Combo_U001.AutoSelect = True
        Me.Combo_U001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo_U001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo_U001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo_U001.Location = New System.Drawing.Point(84, 4)
        Me.Combo_U001.MaxDropDownItems = 20
        Me.Combo_U001.Name = "Combo_U001"
        Me.Combo_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo_U001.Size = New System.Drawing.Size(292, 20)
        Me.Combo_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo_U001.TabIndex = 10
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
        Me.Edit_U004.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U004.HighlightText = True
        Me.Edit_U004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U004.LengthAsByte = True
        Me.Edit_U004.Location = New System.Drawing.Point(460, 220)
        Me.Edit_U004.MaxLength = 200
        Me.Edit_U004.Multiline = True
        Me.Edit_U004.Name = "Edit_U004"
        Me.Edit_U004.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U004.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U004.Size = New System.Drawing.Size(520, 64)
        Me.Edit_U004.TabIndex = 100
        '
        'Combo_U002
        '
        Me.Combo_U002.AutoSelect = True
        Me.Combo_U002.DisabledForeColor = System.Drawing.SystemColors.WindowText
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
        Me.Edit_U002.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U002.HighlightText = True
        Me.Edit_U002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U002.LengthAsByte = True
        Me.Edit_U002.Location = New System.Drawing.Point(84, 28)
        Me.Edit_U002.MaxLength = 50
        Me.Edit_U002.Name = "Edit_U002"
        Me.Edit_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U002.Size = New System.Drawing.Size(292, 20)
        Me.Edit_U002.TabIndex = 40
        Me.Edit_U002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit_U005
        '
        Me.Edit_U005.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U005.HighlightText = True
        Me.Edit_U005.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit_U005.LengthAsByte = True
        Me.Edit_U005.Location = New System.Drawing.Point(460, 284)
        Me.Edit_U005.MaxLength = 200
        Me.Edit_U005.Multiline = True
        Me.Edit_U005.Name = "Edit_U005"
        Me.Edit_U005.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit_U005.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit_U005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U005.Size = New System.Drawing.Size(492, 76)
        Me.Edit_U005.TabIndex = 110
        '
        'Edit_U003
        '
        Me.Edit_U003.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U003.Format = "9#aA"
        Me.Edit_U003.HighlightText = True
        Me.Edit_U003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U003.LengthAsByte = True
        Me.Edit_U003.Location = New System.Drawing.Point(460, 28)
        Me.Edit_U003.MaxLength = 25
        Me.Edit_U003.Name = "Edit_U003"
        Me.Edit_U003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U003.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U003.TabIndex = 50
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
        Me.Edit_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit_U001.HighlightText = True
        Me.Edit_U001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit_U001.LengthAsByte = True
        Me.Edit_U001.Location = New System.Drawing.Point(460, 4)
        Me.Edit_U001.MaxLength = 50
        Me.Edit_U001.Name = "Edit_U001"
        Me.Edit_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit_U001.Size = New System.Drawing.Size(212, 20)
        Me.Edit_U001.TabIndex = 20
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
        Me.CheckBox_U001.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U001.Location = New System.Drawing.Point(676, 8)
        Me.CheckBox_U001.Name = "CheckBox_U001"
        Me.CheckBox_U001.Size = New System.Drawing.Size(76, 16)
        Me.CheckBox_U001.TabIndex = 30
        Me.CheckBox_U001.Text = "定額修理"
        '
        'Button_S4
        '
        Me.Button_S4.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S4.Location = New System.Drawing.Point(952, 288)
        Me.Button_S4.Name = "Button_S4"
        Me.Button_S4.Size = New System.Drawing.Size(28, 20)
        Me.Button_S4.TabIndex = 1423
        Me.Button_S4.TabStop = False
        Me.Button_S4.Text = "？"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(680, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 20)
        Me.Label9.TabIndex = 1425
        Me.Label9.Text = "ﾒｰｶｰ保証"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U002
        '
        Me.Date_U002.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U002.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U002.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U002.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U002.Location = New System.Drawing.Point(752, 52)
        Me.Date_U002.Name = "Date_U002"
        Me.Date_U002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U002.Size = New System.Drawing.Size(88, 20)
        Me.Date_U002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U002.TabIndex = 67
        Me.Date_U002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U002.Value = Nothing
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
        Me.Label19_1.Text = "購入日"
        Me.Label19_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date_U001
        '
        Me.Date_U001.DisabledForeColor = System.Drawing.Color.Black
        Me.Date_U001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date_U001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_U001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date_U001.Location = New System.Drawing.Point(864, 4)
        Me.Date_U001.Name = "Date_U001"
        Me.Date_U001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date_U001.Size = New System.Drawing.Size(88, 20)
        Me.Date_U001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_U001.TabIndex = 60
        Me.Date_U001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date_U001.Value = Nothing
        '
        'CheckBox_U002
        '
        Me.CheckBox_U002.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox_U002.Location = New System.Drawing.Point(956, 56)
        Me.CheckBox_U002.Name = "CheckBox_U002"
        Me.CheckBox_U002.Size = New System.Drawing.Size(20, 16)
        Me.CheckBox_U002.TabIndex = 69
        '
        'brk02
        '
        Me.brk02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.brk02.Location = New System.Drawing.Point(864, 220)
        Me.brk02.Name = "brk02"
        Me.brk02.Size = New System.Drawing.Size(48, 16)
        Me.brk02.TabIndex = 1423
        Me.brk02.Text = "brk02"
        Me.brk02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.brk02.Visible = False
        '
        'Edit011
        '
        Me.Edit011.AllowSpace = False
        Me.Edit011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit011.Format = "9A#"
        Me.Edit011.HighlightText = True
        Me.Edit011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit011.LengthAsByte = True
        Me.Edit011.Location = New System.Drawing.Point(376, 32)
        Me.Edit011.MaxLength = 10
        Me.Edit011.Name = "Edit011"
        Me.Edit011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit011.Size = New System.Drawing.Size(92, 20)
        Me.Edit011.TabIndex = 30
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
        Me.Label21.TabIndex = 1412
        Me.Label21.Text = "QG Care No"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'T2
        '
        Me.T2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.T2.Location = New System.Drawing.Point(168, 8)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(40, 16)
        Me.T2.TabIndex = 1413
        Me.T2.Text = "T2"
        Me.T2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.T2.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(500, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 20)
        Me.Label5.TabIndex = 1416
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'brk01
        '
        Me.brk01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.brk01.Location = New System.Drawing.Point(352, 16)
        Me.brk01.Name = "brk01"
        Me.brk01.Size = New System.Drawing.Size(92, 16)
        Me.brk01.TabIndex = 1417
        Me.brk01.Text = "brk01"
        Me.brk01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.brk01.Visible = False
        '
        'CL002_2
        '
        Me.CL002_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002_2.Location = New System.Drawing.Point(892, 124)
        Me.CL002_2.Name = "CL002_2"
        Me.CL002_2.Size = New System.Drawing.Size(52, 16)
        Me.CL002_2.TabIndex = 1418
        Me.CL002_2.Text = "CL002_2"
        Me.CL002_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002_2.Visible = False
        '
        'Button_S2
        '
        Me.Button_S2.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S2.Location = New System.Drawing.Point(468, 32)
        Me.Button_S2.Name = "Button_S2"
        Me.Button_S2.Size = New System.Drawing.Size(28, 20)
        Me.Button_S2.TabIndex = 35
        Me.Button_S2.TabStop = False
        Me.Button_S2.Text = "？"
        '
        'Button_S3
        '
        Me.Button_S3.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S3.Location = New System.Drawing.Point(144, 80)
        Me.Button_S3.Name = "Button_S3"
        Me.Button_S3.Size = New System.Drawing.Size(28, 20)
        Me.Button_S3.TabIndex = 65
        Me.Button_S3.TabStop = False
        Me.Button_S3.Text = "？"
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
        Me.Edit012.TabIndex = 210
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
        Me.Label2.TabIndex = 1422
        Me.Label2.Text = "ｵﾘｼﾞﾅﾙﾒｰｶｰｺｰﾄﾞ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'brk03
        '
        Me.brk03.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.brk03.Location = New System.Drawing.Point(828, 84)
        Me.brk03.Name = "brk03"
        Me.brk03.Size = New System.Drawing.Size(88, 16)
        Me.brk03.TabIndex = 1423
        Me.brk03.Text = "brk03"
        Me.brk03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.brk03.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label3.Location = New System.Drawing.Point(292, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 16)
        Me.Label3.TabIndex = 1424
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(652, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 1735
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
        Me.Number001.Location = New System.Drawing.Point(772, 8)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(52, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1734
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(688, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 20)
        Me.Label11.TabIndex = 1737
        Me.Label11.Text = "預かり金"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number002
        '
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
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
        Me.Number002.TabIndex = 215
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'NumberN008
        '
        Me.NumberN008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN008.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN008.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN008.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN008.Enabled = False
        Me.NumberN008.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN008.HighlightText = True
        Me.NumberN008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN008.Location = New System.Drawing.Point(556, 672)
        Me.NumberN008.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN008.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN008.Name = "NumberN008"
        Me.NumberN008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN008.Size = New System.Drawing.Size(64, 16)
        Me.NumberN008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN008.TabIndex = 1753
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
        Me.NumberN007.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN007.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN007.Enabled = False
        Me.NumberN007.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN007.HighlightText = True
        Me.NumberN007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN007.Location = New System.Drawing.Point(484, 672)
        Me.NumberN007.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN007.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN007.Name = "NumberN007"
        Me.NumberN007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN007.Size = New System.Drawing.Size(64, 16)
        Me.NumberN007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN007.TabIndex = 1752
        Me.NumberN007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN007.Value = Nothing
        Me.NumberN007.Visible = False
        '
        'NumberN003
        '
        Me.NumberN003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN003.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NumberN003.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.NumberN003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberN003.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN003.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN003.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NumberN003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.NumberN003.Enabled = False
        Me.NumberN003.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.NumberN003.HighlightText = True
        Me.NumberN003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.NumberN003.Location = New System.Drawing.Point(484, 656)
        Me.NumberN003.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.NumberN003.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumberN003.Name = "NumberN003"
        Me.NumberN003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.NumberN003.Size = New System.Drawing.Size(64, 16)
        Me.NumberN003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.NumberN003.TabIndex = 1751
        Me.NumberN003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.NumberN003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.NumberN003.Value = Nothing
        Me.NumberN003.Visible = False
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(732, 80)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(88, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 75
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
        Me.Label007.TabIndex = 1755
        Me.Label007.Text = "販社受付日"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label001.Location = New System.Drawing.Point(172, 80)
        Me.Label001.MaxLength = 40
        Me.Label001.Name = "Label001"
        Me.Label001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label001.Size = New System.Drawing.Size(276, 20)
        Me.Label001.TabIndex = 1756
        Me.Label001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
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
        Me.Label002.Location = New System.Drawing.Point(172, 104)
        Me.Label002.MaxLength = 40
        Me.Label002.Name = "Label002"
        Me.Label002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label002.Size = New System.Drawing.Size(276, 20)
        Me.Label002.TabIndex = 1757
        Me.Label002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(652, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 20)
        Me.Label15.TabIndex = 1761
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
        Me.Number003.TabIndex = 1760
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number003.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(264, 216)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 1763
        Me.Label14.Text = "事故状況"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo005
        '
        Me.Combo005.AutoSelect = True
        Me.Combo005.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo005.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo005.Location = New System.Drawing.Point(348, 216)
        Me.Combo005.MaxDropDownItems = 20
        Me.Combo005.Name = "Combo005"
        Me.Combo005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo005.Size = New System.Drawing.Size(108, 20)
        Me.Combo005.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo005.TabIndex = 205
        Me.Combo005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo005.Value = "Combo005"
        '
        'CL005
        '
        Me.CL005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL005.Location = New System.Drawing.Point(944, 184)
        Me.CL005.Name = "CL005"
        Me.CL005.Size = New System.Drawing.Size(52, 16)
        Me.CL005.TabIndex = 1764
        Me.CL005.Text = "CL005"
        Me.CL005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL005.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(784, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 1765
        Me.Label16.Text = "（税抜）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(784, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 16)
        Me.Label17.TabIndex = 1766
        Me.Label17.Text = "（税込）"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'brk07
        '
        Me.brk07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.brk07.Location = New System.Drawing.Point(96, 140)
        Me.brk07.Name = "brk07"
        Me.brk07.Size = New System.Drawing.Size(112, 16)
        Me.brk07.TabIndex = 1767
        Me.brk07.Text = "brk07"
        Me.brk07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.brk07.Visible = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(452, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 20)
        Me.Label19.TabIndex = 1769
        Me.Label19.Text = "販社延長情報"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit013
        '
        Me.Edit013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit013.HighlightText = True
        Me.Edit013.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit013.LengthAsByte = True
        Me.Edit013.Location = New System.Drawing.Point(536, 128)
        Me.Edit013.MaxLength = 30
        Me.Edit013.Name = "Edit013"
        Me.Edit013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit013.Size = New System.Drawing.Size(284, 20)
        Me.Edit013.TabIndex = 97
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
        'prch_amnt
        '
        Me.prch_amnt.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.prch_amnt.Location = New System.Drawing.Point(924, 84)
        Me.prch_amnt.Name = "prch_amnt"
        Me.prch_amnt.Size = New System.Drawing.Size(72, 16)
        Me.prch_amnt.TabIndex = 1843
        Me.prch_amnt.Text = "prch_amnt"
        Me.prch_amnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.prch_amnt.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(252, 660)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 24)
        Me.Button4.TabIndex = 260
        Me.Button4.Text = "ケア情報"
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
        Me.Number001_nTax.TabIndex = 1844
        Me.Number001_nTax.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001_nTax.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'GRP
        '
        Me.GRP.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.GRP.Location = New System.Drawing.Point(40, 128)
        Me.GRP.Name = "GRP"
        Me.GRP.Size = New System.Drawing.Size(52, 16)
        Me.GRP.TabIndex = 1845
        Me.GRP.Text = "GRP"
        Me.GRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GRP.Visible = False
        '
        'Button_S5
        '
        Me.Button_S5.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S5.Location = New System.Drawing.Point(600, 152)
        Me.Button_S5.Name = "Button_S5"
        Me.Button_S5.Size = New System.Drawing.Size(64, 20)
        Me.Button_S5.TabIndex = 145
        Me.Button_S5.Text = "〒→住所"
        '
        'Wrn_Y
        '
        Me.Wrn_Y.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Wrn_Y.Location = New System.Drawing.Point(564, 56)
        Me.Wrn_Y.Name = "Wrn_Y"
        Me.Wrn_Y.Size = New System.Drawing.Size(20, 16)
        Me.Wrn_Y.TabIndex = 1846
        Me.Wrn_Y.Text = "0"
        Me.Wrn_Y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Wrn_Y.Visible = False
        '
        'end_date
        '
        Me.end_date.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.end_date.Location = New System.Drawing.Point(584, 56)
        Me.end_date.Name = "end_date"
        Me.end_date.Size = New System.Drawing.Size(68, 16)
        Me.end_date.TabIndex = 1847
        Me.end_date.Text = "end_date"
        Me.end_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.end_date.Visible = False
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(16, 240)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 20)
        Me.Label22.TabIndex = 1849
        Me.Label22.Text = "Mobile種別"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo006
        '
        Me.Combo006.AutoSelect = True
        Me.Combo006.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo006.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo006.Location = New System.Drawing.Point(96, 240)
        Me.Combo006.MaxDropDownItems = 20
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(164, 20)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 216
        Me.Combo006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo006.Value = "Combo006"
        '
        'CL006
        '
        Me.CL006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL006.Location = New System.Drawing.Point(944, 204)
        Me.CL006.Name = "CL006"
        Me.CL006.Size = New System.Drawing.Size(52, 16)
        Me.CL006.TabIndex = 1850
        Me.CL006.Text = "CL006"
        Me.CL006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL006.Visible = False
        '
        'Date007
        '
        Me.Date007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date007.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date007.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date007.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date007.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date007.Location = New System.Drawing.Point(904, 44)
        Me.Date007.Name = "Date007"
        Me.Date007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date007.Size = New System.Drawing.Size(88, 20)
        Me.Date007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date007.TabIndex = 1854
        Me.Date007.TabStop = False
        Me.Date007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date007.Value = Nothing
        '
        'Label016
        '
        Me.Label016.BackColor = System.Drawing.Color.Navy
        Me.Label016.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label016.ForeColor = System.Drawing.Color.White
        Me.Label016.Location = New System.Drawing.Point(824, 64)
        Me.Label016.Name = "Label016"
        Me.Label016.Size = New System.Drawing.Size(80, 20)
        Me.Label016.TabIndex = 1853
        Me.Label016.Text = "部品受領日"
        Me.Label016.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label015
        '
        Me.Label015.BackColor = System.Drawing.Color.Navy
        Me.Label015.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label015.ForeColor = System.Drawing.Color.White
        Me.Label015.Location = New System.Drawing.Point(824, 44)
        Me.Label015.Name = "Label015"
        Me.Label015.Size = New System.Drawing.Size(80, 20)
        Me.Label015.TabIndex = 1852
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
        Me.Date008.Location = New System.Drawing.Point(904, 64)
        Me.Date008.Name = "Date008"
        Me.Date008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date008.Size = New System.Drawing.Size(88, 20)
        Me.Date008.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date008.TabIndex = 1851
        Me.Date008.TabStop = False
        Me.Date008.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date008.Value = Nothing
        '
        'CK_own_flg
        '
        Me.CK_own_flg.AutoCheck = False
        Me.CK_own_flg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CK_own_flg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CK_own_flg.Location = New System.Drawing.Point(844, 240)
        Me.CK_own_flg.Name = "CK_own_flg"
        Me.CK_own_flg.Size = New System.Drawing.Size(84, 16)
        Me.CK_own_flg.TabIndex = 1855
        Me.CK_own_flg.TabStop = False
        Me.CK_own_flg.Text = "CK_own_flg"
        Me.CK_own_flg.Visible = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Navy
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(264, 240)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 20)
        Me.Label23.TabIndex = 1857
        Me.Label23.Text = "Ref."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit014
        '
        Me.Edit014.AllowSpace = False
        Me.Edit014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit014.Format = "9A#"
        Me.Edit014.HighlightText = True
        Me.Edit014.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit014.LengthAsByte = True
        Me.Edit014.Location = New System.Drawing.Point(348, 240)
        Me.Edit014.MaxLength = 10
        Me.Edit014.Name = "Edit014"
        Me.Edit014.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit014.Size = New System.Drawing.Size(108, 20)
        Me.Edit014.TabIndex = 217
        Me.Edit014.Text = "9999"
        Me.Edit014.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(460, 240)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 20)
        Me.Label24.TabIndex = 1859
        Me.Label24.Text = "iMV番号"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit015
        '
        Me.Edit015.AllowSpace = False
        Me.Edit015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit015.Format = "9A#"
        Me.Edit015.HighlightText = True
        Me.Edit015.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit015.LengthAsByte = True
        Me.Edit015.Location = New System.Drawing.Point(568, 240)
        Me.Edit015.MaxLength = 9
        Me.Edit015.Name = "Edit015"
        Me.Edit015.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit015.Size = New System.Drawing.Size(116, 20)
        Me.Edit015.TabIndex = 218
        Me.Edit015.Text = "9999"
        Me.Edit015.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(652, 104)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 20)
        Me.Label26.TabIndex = 1860
        Me.Label26.Text = "過失"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CkBox01_Y
        '
        Me.CkBox01_Y.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_Y.Location = New System.Drawing.Point(740, 108)
        Me.CkBox01_Y.Name = "CkBox01_Y"
        Me.CkBox01_Y.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_Y.TabIndex = 95
        Me.CkBox01_Y.Text = "有"
        '
        'CkBox01_N
        '
        Me.CkBox01_N.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CkBox01_N.Location = New System.Drawing.Point(780, 108)
        Me.CkBox01_N.Name = "CkBox01_N"
        Me.CkBox01_N.Size = New System.Drawing.Size(32, 16)
        Me.CkBox01_N.TabIndex = 96
        Me.CkBox01_N.Text = "無"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoCheck = False
        Me.CheckBox2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CheckBox2.Location = New System.Drawing.Point(848, 144)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(88, 16)
        Me.CheckBox2.TabIndex = 1861
        Me.CheckBox2.TabStop = False
        Me.CheckBox2.Text = "富士通免責"
        Me.CheckBox2.Visible = False
        '
        'Button97
        '
        Me.Button97.BackColor = System.Drawing.SystemColors.Control
        Me.Button97.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button97.Location = New System.Drawing.Point(736, 660)
        Me.Button97.Name = "Button97"
        Me.Button97.Size = New System.Drawing.Size(68, 24)
        Me.Button97.TabIndex = 269
        Me.Button97.Text = "S/N履歴"
        Me.Button97.Visible = False
        '
        'sn_n
        '
        Me.sn_n.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.sn_n.Location = New System.Drawing.Point(812, 668)
        Me.sn_n.Name = "sn_n"
        Me.sn_n.Size = New System.Drawing.Size(48, 16)
        Me.sn_n.TabIndex = 1862
        Me.sn_n.Text = "sn_n"
        Me.sn_n.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.sn_n.Visible = False
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Navy
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(16, 192)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 20)
        Me.Label28.TabIndex = 1864
        Me.Label28.Text = "email"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit016
        '
        Me.Edit016.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit016.HighlightText = True
        Me.Edit016.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit016.LengthAsByte = True
        Me.Edit016.Location = New System.Drawing.Point(96, 192)
        Me.Edit016.MaxLength = 50
        Me.Edit016.Name = "Edit016"
        Me.Edit016.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit016.Size = New System.Drawing.Size(392, 20)
        Me.Edit016.TabIndex = 131
        Me.Edit016.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Date015
        '
        Me.Date015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date015.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date015.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd HH:mm", "", "")
        Me.Date015.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date015.Location = New System.Drawing.Point(904, 24)
        Me.Date015.Name = "Date015"
        Me.Date015.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date015.Size = New System.Drawing.Size(112, 20)
        Me.Date015.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date015.TabIndex = 1893
        Me.Date015.TabStop = False
        Me.Date015.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date015.Value = Nothing
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Navy
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(824, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(80, 20)
        Me.Label34.TabIndex = 1894
        Me.Label34.Text = "診断日"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Location = New System.Drawing.Point(700, 240)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(116, 16)
        Me.Label29.TabIndex = 1895
        Me.Label29.Text = "AC+請求額（税込）"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(344, 660)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 261
        Me.Button2.Text = "複製"
        '
        'F10_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1022, 688)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Date015)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Edit016)
        Me.Controls.Add(Me.sn_n)
        Me.Controls.Add(Me.Button97)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CkBox01_N)
        Me.Controls.Add(Me.CkBox01_Y)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Edit015)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Edit014)
        Me.Controls.Add(Me.Date007)
        Me.Controls.Add(Me.Label016)
        Me.Controls.Add(Me.Label015)
        Me.Controls.Add(Me.Date008)
        Me.Controls.Add(Me.CL006)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.end_date)
        Me.Controls.Add(Me.Wrn_Y)
        Me.Controls.Add(Me.Button_S5)
        Me.Controls.Add(Me.GRP)
        Me.Controls.Add(Me.brk03)
        Me.Controls.Add(Me.Number001_nTax)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.prch_amnt)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Edit013)
        Me.Controls.Add(Me.brk07)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CL005)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Combo005)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.NumberN008)
        Me.Controls.Add(Me.NumberN007)
        Me.Controls.Add(Me.NumberN003)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Edit012)
        Me.Controls.Add(Me.Button_S3)
        Me.Controls.Add(Me.Button_S2)
        Me.Controls.Add(Me.CL002_2)
        Me.Controls.Add(Me.brk01)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.Edit011)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Panel_受付)
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
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label014)
        Me.Controls.Add(Me.Combo004)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label012)
        Me.Controls.Add(Me.Date003)
        Me.Controls.Add(Me.Edit006)
        Me.Controls.Add(Me.Edit008)
        Me.Controls.Add(Me.Edit007)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.CK_own_flg)
        Me.Controls.Add(Me.brk02)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F10_Form01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "受付入力"
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit902, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit901, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_受付.ResumeLayout(False)
        CType(Me.Date_U004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_U003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_U001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo_U002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit_U001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_U1.ResumeLayout(False)
        CType(Me.Date_U002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_U001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberN003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001_nTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit016, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date015, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F10_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        DsSet()     '**  データセット
        CmbSet()    '**  コンボボックスセット
        DspSet()    '**  画面セット

        If P_DBG = "True" Then 'デバック表示
            NumberN003.Visible = True : NumberN007.Visible = True : NumberN008.Visible = True
            Number001.Visible = True
            prch_amnt.Visible = True
            brk01.Visible = True
            brk02.Visible = True
            brk03.Visible = True
            brk07.Visible = True
            Label3.Visible = True
            CL001.Visible = True
            CL002.Visible = True : CL002_2.Visible = True
            CL003.Visible = True
            CL004.Visible = True
            CL005.Visible = True
            CL006.Visible = True
            CLU001.Visible = True
            CLU002.Visible = True
            T2.Visible = True
            GRP.Visible = True
            Wrn_Y.Visible = True
            end_date.Visible = True
            CK_own_flg.Visible = True
            CheckBox2.Visible = True
            sn_n.Visible = True
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

        msg.Text = Nothing
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
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='101'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button1.Enabled = False
                Case Is = "3"
                    Button1.Enabled = True
                Case Is = "4"
                    Button1.Enabled = True
            End Select
        Else
            Button1.Enabled = False
        End If
    End Sub

    '********************************************************************
    '**  データセット
    '********************************************************************
    Sub DsSet()

        'WK_DsList1.Clear()
        'strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '008') AND (delt_flg = 0)"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'SqlCmd1.CommandTimeout = 600
        'DaList1.Fill(WK_DsList1, "CLS_CODE_008")
        'WK_DtView1 = New DataView(WK_DsList1.Tables("CLS_CODE_008"), "", "", DataViewRowState.CurrentRows)
        'If WK_DtView1.Count <> 0 Then
        '    Wk_TAX = WK_DtView1(0)("cls_code_name")
        'Else
        '    Wk_TAX = 5
        'End If

        'カレンダー
        Date_From = DateAdd(DateInterval.Month, -1, Now)
        Date_To = DateAdd(DateInterval.Month, 1, Now)
        DsCnld.Clear()
        strSQL = "SELECT * FROM M22_CLND"
        strSQL += " WHERE (hldy_flg = 0)"
        strSQL += " AND (clnd_date >= CONVERT(DATETIME, '" & Date_From & "', 102)"
        strSQL += " AND clnd_date <= CONVERT(DATETIME, '" & Date_To & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCnld, "M22_CLND")
        DB_CLOSE()
        Date_From = "2009/01/01"
        WK_DtView1 = New DataView(DsCnld.Tables("M22_CLND"), "clnd_date > '" & Now.Date & "'", "clnd_date", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            Date_To = WK_DtView1(0)("clnd_date")
        End If

    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        '受付種別
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '007') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "CLS_CODE_007")

        Combo001.DataSource = DsCMB.Tables("CLS_CODE_007")
        Combo001.DisplayMember = "cls_code_name"
        Combo001.ValueMember = "cls_code"

        '入荷区分
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '018') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "CLS_CODE_018")

        Combo002.DataSource = DsCMB.Tables("CLS_CODE_018")
        Combo002.DisplayMember = "cls_code_name"
        Combo002.ValueMember = "cls_code"

        '入荷担当
        strSQL = "SELECT empl_code, name"
        strSQL += " FROM (SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (delt_flg = 0) AND (brch_code = '" & P_EMPL_BRCH & "')"
        strSQL += " UNION"
        strSQL += " SELECT empl_code, name, name_kana FROM M01_EMPL WHERE (empl_code = " & P_EMPL_NO & ")) M01_EMPL"
        strSQL += " ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "M01_EMPL")

        Combo003.DataSource = DsCMB.Tables("M01_EMPL")
        Combo003.DisplayMember = "name"
        Combo003.ValueMember = "empl_code"
        Combo003.Text = Nothing : CL003.Text = Nothing

        '修理種別
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '001') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "CLS_CODE_001")

        Combo004.DataSource = DsCMB.Tables("CLS_CODE_001")
        Combo004.DisplayMember = "cls_code_name"
        Combo004.ValueMember = "cls_code"

        '事故状況
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '022') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "CLS_CODE_022")

        Combo005.DataSource = DsCMB.Tables("CLS_CODE_022")
        Combo005.DisplayMember = "cls_code_name"
        Combo005.ValueMember = "cls_code"

        'Mobile種別
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '035') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "CLS_CODE_035")

        Combo006.DataSource = DsCMB.Tables("CLS_CODE_035")
        Combo006.DisplayMember = "cls_code_name"
        Combo006.ValueMember = "cls_code"

        '修理部署
        strSQL = "SELECT rpar_comp_code, rpar_comp_code + ':' + name AS name"
        strSQL += " FROM M06_RPAR_COMP"
        strSQL += " WHERE (delt_flg = 0)"
        strSQL += " AND (delt_flg = 1)" '初期は対象なし
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "M06_RPAR_COMP")

        Combo_U002.DataSource = DsCMB.Tables("M06_RPAR_COMP")
        Combo_U002.DisplayMember = "name"
        Combo_U002.ValueMember = "rpar_comp_code"

        'メーカー
        strSQL = "SELECT vndr_code, vndr_code + ':' + name AS name, rcpt_up2, qg_vndr_link"
        strSQL += " FROM M05_VNDR"
        strSQL += " WHERE (delt_flg = 0)"
        strSQL += " ORDER BY name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB, "M05_VNDR")

        Combo_U001.DataSource = DsCMB.Tables("M05_VNDR")
        Combo_U001.DisplayMember = "name"
        Combo_U001.ValueMember = "vndr_code"

        WK_DtView1 = New DataView(DsCMB.Tables("M05_VNDR"), "vndr_code = '20'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            WK_ios = WK_DtView1(0)("name")
        Else
            WK_ios = ""
        End If

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()

        Button1.Text = "登録"
        Button97.Visible = False : sn_n.Text = "0"
        Combo001.Focus()
        msg.Text = Nothing

        Edit000.Text = Nothing  '受付番号
        Edit901.Text = P_EMPL_NAME
        Edit902.Text = P_EMPL_BRCH_name
        'Date003.Text = Now.Date
        Date003.Text = String.Format("{0:yyyy/MM/dd HH:mm}", Now)
        tax(String.Format("{0:yyyy/MM/dd}", CDate(Date003.Text)))
        Date007.Text = Nothing
        Date008.Text = Nothing
        Date015.Text = Nothing
        Label5.Text = Nothing
        Edit001.Text = Nothing : Edit002.Text = Nothing : Edit003.Text = Nothing : Edit004.Text = Nothing : Edit005.Text = Nothing
        Edit006.Text = Nothing : Edit007.Text = Nothing : Edit008.Text = Nothing : Edit009.Text = Nothing : Edit010.Text = Nothing
        Edit011.Text = Nothing : Edit012.Text = Nothing : Edit013.Text = Nothing : Edit014.Text = Nothing : Edit015.Text = Nothing
        Edit016.Text = Nothing
        prch_amnt.Text = "0"
        Edit_U001.Text = Nothing : Edit_U002.Text = Nothing : Edit_U003.Text = Nothing : Edit_U004.Text = Nothing : Edit_U005.Text = Nothing : Edit_U006.Text = Nothing
        Date_U001.Text = Nothing : Date_U002.Text = Nothing : Date_U003.Text = Nothing : Date_U004.Text = Nothing
        Combo001.Text = Nothing : Combo002.Text = Nothing : Combo004.Text = Nothing : Combo005.Text = Nothing : Combo006.Text = Nothing
        'Combo003.Text = Nothing : CL003.Text = Nothing
        CL001.Text = Nothing : CL002.Text = Nothing : CL002_2.Text = Nothing : CL004.Text = Nothing : CL005.Text = Nothing : CL006.Text = Nothing
        brk01.Text = Nothing : brk02.Text = Nothing : brk03.Text = Nothing : brk07.Text = Nothing

        Combo_U001.Text = Nothing : Combo_U002.Text = Nothing
        CLU001.Text = Nothing : CLU002.Text = Nothing
        Mask1.Text = Nothing
        CkBox01_Y.Checked = False : CkBox01_N.Checked = False
        CheckBox_U001.Checked = False
        CheckBox_U002.Checked = False
        CheckBox_U003.Checked = False
        Label001.Text = Nothing : Label002.Text = Nothing
        Number001.Value = 0 : Number001_nTax.Value = 0 : Number002.Value = 0
        CheckBox2.Checked = False

        DsList1.Clear()
        strSQL = "SELECT item_code, item_name, item_unit"
        strSQL += " FROM M12_ATCH_ITEM"
        strSQL += " WHERE (delt_flg = 0) AND (item_name <> '')"
        strSQL += " ORDER BY dsp_seq, item_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M12_ATCH_ITEM")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("M12_ATCH_ITEM"), "", "", DataViewRowState.CurrentRows)
        Line_No = 0
        Panel_U1.Controls.Clear()

        '基準点
        en = 0
        label(Line_No, en) = New Label
        label(Line_No, en).Location = New System.Drawing.Point(0, 0)
        label(Line_No, en).Size = New System.Drawing.Size(0, 0)
        label(Line_No, en).Text = Nothing
        Panel_U1.Controls.Add(label(Line_No, en))

        If DtView1.Count <> 0 Then
            For Line_No = 0 To DtView1.Count - 1

                '対象
                en = 1
                chkBox(Line_No, en) = New CheckBox
                chkBox(Line_No, en).Location = New System.Drawing.Point(5, 20 * Line_No + label(0, 0).Location.Y)
                chkBox(Line_No, en).Size = New System.Drawing.Size(25, 20)
                chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                chkBox(Line_No, en).Text = Nothing
                chkBox(Line_No, en).Checked = False
                chkBox(Line_No, en).Tag = Line_No
                Panel_U1.Controls.Add(chkBox(Line_No, en))
                AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
                AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

                '付属品
                en = 1
                edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                edit(Line_No, en).Location = New System.Drawing.Point(30, 20 * Line_No + label(0, 0).Location.Y)
                edit(Line_No, en).LengthAsByte = True
                edit(Line_No, en).MaxLength = 30
                edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                edit(Line_No, en).Size = New System.Drawing.Size(150, 20)
                edit(Line_No, en).Enabled = False
                edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                edit(Line_No, en).Text = DtView1(Line_No)("item_name")
                edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
                Panel_U1.Controls.Add(edit(Line_No, en))

                '数量
                en = 1
                nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
                nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
                nbrBox(Line_No, en).HighlightText = True
                nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###0", "", "", "-", "", "", "")
                nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 20 * Line_No + label(0, 0).Location.Y)
                nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
                nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
                nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
                nbrBox(Line_No, en).Size = New System.Drawing.Size(30, 20)
                If Trim(DtView1(Line_No)("item_unit")) = Nothing Then
                    nbrBox(Line_No, en).Visible = False
                End If
                nbrBox(Line_No, en).Value = 0
                nbrBox(Line_No, en).Tag = Line_No
                Panel_U1.Controls.Add(nbrBox(Line_No, en))
                AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY_GotFocus
                AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY_LostFocus

                '単位
                en = 2
                edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                edit(Line_No, en).Location = New System.Drawing.Point(210, 20 * Line_No + label(0, 0).Location.Y)
                edit(Line_No, en).LengthAsByte = True
                edit(Line_No, en).MaxLength = 10
                edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                edit(Line_No, en).Size = New System.Drawing.Size(50, 20)
                edit(Line_No, en).Enabled = False
                edit(Line_No, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
                edit(Line_No, en).Text = DtView1(Line_No)("item_unit")
                edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
                Panel_U1.Controls.Add(edit(Line_No, en))

                '付属品コード
                en = 1
                label(Line_No, en) = New Label
                label(Line_No, en).Location = New System.Drawing.Point(260, 20 * Line_No + label(0, 0).Location.Y)
                label(Line_No, en).Size = New System.Drawing.Size(0, 20)
                label(Line_No, en).Text = DtView1(Line_No)("item_code")
                Panel_U1.Controls.Add(label(Line_No, en))

            Next
        End If
        Line_No = Line_No - 1
        add_line()      '付属品フリー入力

        Line_No2 = -1
        Panel_U2.Controls.Clear()

        '基準点
        label_2(0, 0) = New Label
        label_2(0, 0).Location = New System.Drawing.Point(0, 0)
        label_2(0, 0).Size = New System.Drawing.Size(0, 0)
        label_2(0, 0).Text = Nothing
        Panel_U2.Controls.Add(label_2(0, 0))
        add_line_2()    '故障内容
    End Sub

    '付属品フリー入力
    Sub add_line()
        Line_No = Line_No + 1

        '対象
        en = 1
        chkBox(Line_No, en) = New CheckBox
        chkBox(Line_No, en).Location = New System.Drawing.Point(5, 20 * Line_No + label(0, 0).Location.Y)
        chkBox(Line_No, en).Size = New System.Drawing.Size(25, 20)
        chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No, en).Text = Nothing
        chkBox(Line_No, en).Checked = False
        chkBox(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(chkBox(Line_No, en))
        AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
        AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

        '付属品
        en = 1
        edit(Line_No, en) = New GrapeCity.Win.Input.Edit
        edit(Line_No, en).Location = New System.Drawing.Point(30, 20 * Line_No + label(0, 0).Location.Y)
        edit(Line_No, en).LengthAsByte = True
        edit(Line_No, en).MaxLength = 30
        edit(Line_No, en).LengthAsByte = True
        edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, en).Size = New System.Drawing.Size(150, 20)
        edit(Line_No, en).ImeMode = ImeMode.Hiragana
        edit(Line_No, en).Text = Nothing
        edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(edit(Line_No, en))
        AddHandler edit(Line_No, en).GotFocus, AddressOf edit1_GotFocus
        AddHandler edit(Line_No, en).LostFocus, AddressOf edit1_LostFocus

        '数量
        en = 1
        nbrBox(Line_No, en) = New GrapeCity.Win.Input.Number
        nbrBox(Line_No, en).DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).EditMode = GrapeCity.Win.Input.EditMode.Overwrite
        nbrBox(Line_No, en).HighlightText = True
        nbrBox(Line_No, en).Format = New GrapeCity.Win.Input.NumberFormat("###0", "", "", "-", "", "", "")
        nbrBox(Line_No, en).Location = New System.Drawing.Point(180, 20 * Line_No + label(0, 0).Location.Y)
        nbrBox(Line_No, en).MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        nbrBox(Line_No, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        nbrBox(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No, en).Size = New System.Drawing.Size(30, 20)
        nbrBox(Line_No, en).Value = 0
        nbrBox(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(nbrBox(Line_No, en))
        AddHandler nbrBox(Line_No, en).GotFocus, AddressOf QTY_GotFocus
        AddHandler nbrBox(Line_No, en).LostFocus, AddressOf QTY_LostFocus

        '単位
        en = 2
        edit(Line_No, en) = New GrapeCity.Win.Input.Edit
        edit(Line_No, en).LengthAsByte = True
        edit(Line_No, en).Location = New System.Drawing.Point(210, 20 * Line_No + label(0, 0).Location.Y)
        edit(Line_No, en).MaxLength = 10
        edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        edit(Line_No, en).Enabled = False
        edit(Line_No, en).Size = New System.Drawing.Size(50, 20)
        edit(Line_No, en).ImeMode = ImeMode.Hiragana
        edit(Line_No, en).Text = Nothing
        edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        edit(Line_No, en).Tag = Line_No
        Panel_U1.Controls.Add(edit(Line_No, en))

        '付属品コード
        en = 1
        label(Line_No, en) = New Label
        label(Line_No, en).Location = New System.Drawing.Point(260, 20 * Line_No + label(0, 0).Location.Y)
        label(Line_No, en).Size = New System.Drawing.Size(0, 20)
        label(Line_No, en).Text = Nothing
        Panel_U1.Controls.Add(label(Line_No, en))
    End Sub

    '故障内容
    Sub add_line_2()
        Line_No2 = Line_No2 + 1

        '故障内容
        strSQL = "SELECT cmnt_code, cmnt_code + ':' + cmnt AS cmnt"
        strSQL += " FROM M10_CMNT"
        strSQL += " WHERE (cls_code = '01') AND (delt_flg = 0)"
        strSQL += " ORDER BY cmnt_code + ':' + cmnt"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsCMB, "M10_CMNT_1" & Line_No2)
        DB_CLOSE()

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

        '故障内容ｺｰﾄﾞ
        en = 1
        label_2(Line_No2, en) = New Label
        label_2(Line_No2, en).Text = Nothing
        label_2(Line_No2, en).Location = New System.Drawing.Point(478, 20 * Line_No2 + label_2(0, 0).Location.Y)
        label_2(Line_No2, en).Size = New System.Drawing.Size(0, 20)
        Panel_U2.Controls.Add(label_2(Line_No2, en))

    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Date003()   '受付日
        msg.Text = Nothing
        Err_CX = "0"

        If Date003.Number = 0 Then
            Date003.BackColor = System.Drawing.Color.Red
            msg.Text = "受付日が入力されていません。"
            Exit Sub
        End If
        If Date003.Text < Date_From Or Date003.Text > Date_To & " 23:59:59" Then
            Date003.BackColor = System.Drawing.Color.Red
            msg.Text = "受付日には 2009/01/01から本日より1営業日後の範囲で入力してください。"
            Exit Sub
        End If
        If Date001.Number <> 0 Then
            If Date001.Text > Date003.Text Then
                Date003.BackColor = System.Drawing.Color.Red
                msg.Text = "販社受付日＞受付日エラー。"
                Exit Sub
            End If
        End If
        If Number001.Value <> 0 Then
            If Date_U003.Number <> 0 Then
                If DateAdd(DateInterval.Month, 2, CDate(Date_U003.Text)) <= Date003.Text Then
                    Date003.BackColor = System.Drawing.Color.Red
                    msg.Text = "事故日より2ヶ月以上後の受付日です。"
                    Err_CX = "1"
                    Exit Sub
                End If
            End If
        End If
        tax(String.Format("{0:yyyy/MM/dd}", Date003.Text))
        Date003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date015()   '診断日
        msg.Text = Nothing
        Err_CX = "0"
        Select Case CLU001.Text
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                If Date015.Number = 0 Then Date015.Text = Date003.Text
                Date015.Enabled = True
                Date015.BackColor = System.Drawing.SystemColors.Window
            Case Else
        End Select
        Date015.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date007()   '部品発注日
        msg.Text = Nothing
        Err_CX = "0"

        Date007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date008()   '部品受領日
        msg.Text = Nothing
        Err_CX = "0"

        Date008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo001()   '受付種別
        msg.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            Combo001.BackColor = System.Drawing.Color.Red
            msg.Text = "受付種別が入力されていません。"
            CL001.Text = Nothing
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_007"), "cls_code_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する受付種別がありません。"
                CL001.Text = Nothing
                Exit Sub
            Else
                Button97.Visible = False : sn_n.Text = "0"
                If CL001.Text <> DtView1(0)("cls_code") Then Edit011.Text = Nothing : Label5.Text = Nothing
                CL001.Text = DtView1(0)("cls_code")
                Select Case DtView1(0)("cls_code_name_abbr")
                    Case Is = "QGNo"
                        Label21.Text = "QG Care No"
                        Label21.Visible = True : Edit011.Visible = True : Button_S2.Visible = True : Label5.Visible = True 'QG No
                        Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
                        Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
                        Edit005.ReadOnly = True : Edit005.TabStop = False : Edit005.BackColor = System.Drawing.SystemColors.Control
                        Button4.Enabled = True
                    Case Is = "CoopFujitsu Insu"
                        Label21.Text = "Fujitsu No"
                        Label21.Visible = True : Edit011.Visible = True : Button_S2.Visible = True : Label5.Visible = True 'Fujitsu No
                        Label10.Visible = True : Number001_nTax.Visible = True : Label16.Visible = True
                        Label15.Visible = True : Number003.Visible = True : Label17.Visible = True
                        Edit005.ReadOnly = True : Edit005.TabStop = False : Edit005.BackColor = System.Drawing.SystemColors.Control
                        Button4.Enabled = False
                    Case Else
                        Label21.Visible = False : Edit011.Visible = False : Button_S2.Visible = False : Label5.Visible = False 'QG No
                        Label10.Visible = False : Number001_nTax.Visible = False : Label16.Visible = False
                        Label15.Visible = False : Number003.Visible = False : Label17.Visible = False
                        Edit005.ReadOnly = False : Edit005.TabStop = True : Edit005.BackColor = System.Drawing.SystemColors.Window
                        Button4.Enabled = False
                End Select
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit011()   'QG Care No
        msg.Text = Nothing
        Edit011.BackColor = System.Drawing.SystemColors.Window

        If Label21.Text = "QG Care No" Then
            QG_Care()
        Else
            Fujitsu()
        End If
    End Sub
    Sub QG_Care()
        Button97.Visible = False : sn_n.Text = "0"
        If Edit011.Visible = True Then
            Edit011.Text = Trim(Edit011.Text)
            If Edit011.Text = Nothing Then
                Edit011.BackColor = System.Drawing.Color.Red
                msg.Text = "QG Care Noが入力されていません。"
                GoTo tab
            Else
                '******************
                'QG データ検索
                '******************
                '存在ﾁｪｯｸ
                WK_DsList1.Clear()
                strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                strSQL += " FROM T01_member LEFT OUTER JOIN"
                strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                strSQL += " WHERE (T01_member.code = '" & Edit011.Text & "')"
                strSQL += "  AND (T01_member.delt_flg = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("QGCare")
                DaList1.Fill(WK_DsList1, "T01_member")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Edit011.BackColor = System.Drawing.Color.Red
                    msg.Text = "加入データがありません。"
                    GoTo tab
                Else
                    If Not IsDBNull(WK_DtView1(0)("wrn_range_name")) Then Label5.Text = WK_DtView1(0)("wrn_range_name") Else Label5.Text = Nothing
                    If brk01.Text <> Edit011.Text Then

                        If Not IsDBNull(WK_DtView1(0)("wrn_tem")) Then Wrn_Y.Text = WK_DtView1(0)("wrn_tem") Else Wrn_Y.Text = "0"
                        If Not IsDBNull(WK_DtView1(0)("user_name")) Then Edit005.Text = New_Line_Cng(WK_DtView1(0)("user_name")) Else Edit005.Text = Nothing
                        Label3.Text = Edit005.Text
                        If Not IsDBNull(WK_DtView1(0)("use_name_kana")) Then Edit006.Text = New_Line_Cng(WK_DtView1(0)("use_name_kana")) Else Edit006.Text = Nothing
                        If Not IsDBNull(WK_DtView1(0)("tel")) Then Edit007.Text = New_Line_Cng(WK_DtView1(0)("tel")) Else Edit007.Text = Nothing
                        If Not IsDBNull(WK_DtView1(0)("zip")) Then
                            Dim WK_str As String = StrConv(WK_DtView1(0)("zip"), VbStrConv.Narrow)
                            WK_str = WK_str.Replace("‐", "")
                            Mask1.Value = WK_str.Replace("-", "")
                        Else
                            Mask1.Text = Nothing    '郵便番号
                        End If
                        If Not IsDBNull(WK_DtView1(0)("adrs1")) Then Edit009.Text = New_Line_Cng(WK_DtView1(0)("adrs1")) Else Edit009.Text = Nothing
                        If Not IsDBNull(WK_DtView1(0)("adrs2")) Then Edit010.Text = New_Line_Cng(WK_DtView1(0)("adrs2")) Else Edit010.Text = Nothing

                        If Not IsDBNull(WK_DtView1(0)("makr_wrn_stat")) Then Date_U002.Text = WK_DtView1(0)("makr_wrn_stat") Else Date_U002.Text = Nothing
                        end_date.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, CInt(Wrn_Y.Text), CDate(Date_U002.Text)))

                        If CL001.Text = "12" Then WK_DtView1(0)("makr_code") = "20"

                        Combo_U001.Text = Nothing
                        If Not IsDBNull(WK_DtView1(0)("makr_code")) Then
                            WK_DtView2 = New DataView(DsCMB.Tables("M05_VNDR"), "vndr_code = " & WK_DtView1(0)("makr_code"), "", DataViewRowState.CurrentRows)
                            If WK_DtView2.Count <> 0 Then
                                Combo_U001.Text = WK_DtView2(0)("name")
                                CLU001.Text = WK_DtView2(0)("vndr_code")
                                T2.Text = WK_DtView2(0)("rcpt_up2")
                                rpar_comp() '**  修理部署ＳＥＴ
                            End If
                        End If
                        CheckBox_U001.Checked = False : CheckBox_U003.Checked = False
                        'If Not IsDBNull(WK_DtView1(0)("PC分類コード")) Then
                        '    If WK_DtView1(0)("PC分類コード") = "1" Then CheckBox_U001.Checked = True : CheckBox_U003.Checked = True
                        'End If
                        If CL001.Text = "12" Then
                            If Not IsDBNull(WK_DtView1(0)("modl_name")) Then Edit_U002.Text = New_Line_Cng(WK_DtView1(0)("modl_name")) Else Edit_U002.Text = Nothing

                            CL006.Text = "05"
                            WK_DtView2 = New DataView(DsCMB.Tables("CLS_CODE_035"), "cls_code = '" & CL006.Text & "'", "", DataViewRowState.CurrentRows)
                            Combo006.Text = WK_DtView2(0)("cls_code_name")
                        Else
                            If Not IsDBNull(WK_DtView1(0)("modl_name")) Then Edit_U001.Text = New_Line_Cng(WK_DtView1(0)("modl_name")) Else Edit_U001.Text = Nothing
                        End If
                        If Edit_U003.Text = Nothing Then
                            If Not IsDBNull(WK_DtView1(0)("s_no")) Then Edit_U003.Text = New_Line_Cng(WK_DtView1(0)("s_no")) Else Edit_U003.Text = Nothing
                        End If
                        If Not IsDBNull(WK_DtView1(0)("prch_amnt")) Then prch_amnt.Text = WK_DtView1(0)("prch_amnt") Else prch_amnt.Text = 0
                    End If
                    If IsDBNull(WK_DtView1(0)("wrn_range")) Then
                        Edit011.BackColor = System.Drawing.Color.Red
                        msg.Text = "保証範囲が違います。"
                        GoTo tab
                    Else
                        Select Case CL001.Text
                            Case Is = "02"  'QGCare
                                If WK_DtView1(0)("wrn_range") = "7" Then    '延長保証
                                    Edit011.BackColor = System.Drawing.Color.Red
                                    msg.Text = "保証範囲が違います。"
                                    GoTo tab
                                End If
                            Case Is = "12"  'QGCare iPad
                                If WK_DtView1(0)("wrn_range") <> "10" Then  'QG-Care iPad
                                    Edit011.BackColor = System.Drawing.Color.Red
                                    msg.Text = "保証範囲が違います。"
                                    GoTo tab
                                End If
                            Case Else       '延長保証
                                If WK_DtView1(0)("wrn_range") <> "7" Then
                                    Edit011.BackColor = System.Drawing.Color.Red
                                    msg.Text = "保証範囲が違います。"
                                    GoTo tab
                                End If
                        End Select
                    End If
                End If

                's/n変更履歴
                Button97.Visible = False : sn_n.Text = "0"
                If Edit011.Text <> Nothing Then
                    P_Ds_sn.Clear()
                    strSQL = "SELECT * FROM T06_sno WHERE (code = '" & Edit011.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN("QGCare")
                    r = DaList1.Fill(P_Ds_sn, "T06_sno")
                    DB_CLOSE()
                    If r <> 0 Then
                        Button97.Visible = True : sn_n.Text = r
                    End If
                End If

            End If
        End If
tab:
        brk01.Text = Edit011.Text
    End Sub
    Sub Fujitsu()
        If Edit011.Visible = True Then
            Edit011.Text = Trim(Edit011.Text)
            If Edit011.Text = Nothing Then
                Edit011.BackColor = System.Drawing.Color.Red
                msg.Text = "Fujitsu Noが入力されていません。"
                GoTo tab
            Else
                '******************
                'Fujitsu データ検索
                '******************
                '存在ﾁｪｯｸ
                WK_DsList1.Clear()
                strSQL = "SELECT T01_wrn_date.*, M01_insurance_co_decision.start_date, M01_insurance_co_decision.end_date, M01_insurance_co_decision.wrn_prod"
                strSQL += " FROM T01_wrn_date INNER JOIN M01_insurance_co_decision ON T01_wrn_date.Securities_no = M01_insurance_co_decision.Securities_no"
                strSQL += " WHERE (T01_wrn_date.wrn_id = '" & Edit011.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("Fujitsu")
                DaList1.Fill(WK_DsList1, "T01_wrn_date")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_wrn_date"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Edit011.BackColor = System.Drawing.Color.Red
                    msg.Text = "加入データがありません。"
                    GoTo tab
                Else
                    Label5.Text = "生協富士通保険"
                    If WK_DtView1(0)("menseki_flg") = "1" Then CheckBox2.Checked = True Else CheckBox2.Checked = False
                    If brk01.Text <> Edit011.Text Then

                        If Not IsDBNull(WK_DtView1(0)("wrn_prod")) Then Wrn_Y.Text = WK_DtView1(0)("wrn_prod") Else Wrn_Y.Text = "0"
                        If Not IsDBNull(WK_DtView1(0)("name")) Then Edit005.Text = New_Line_Cng(WK_DtView1(0)("name")) Else Edit005.Text = Nothing
                        Label3.Text = Edit005.Text
                        If Not IsDBNull(WK_DtView1(0)("name_kana")) Then Edit006.Text = New_Line_Cng(WK_DtView1(0)("name_kana")) Else Edit006.Text = Nothing
                        Edit007.Text = Nothing  '電話番号
                        Mask1.Text = Nothing    '郵便番号
                        Edit009.Text = Nothing  '住所１
                        Edit010.Text = Nothing  '住所２

                        If Not IsDBNull(WK_DtView1(0)("start_date")) Then Date_U002.Text = WK_DtView1(0)("start_date") Else Date_U002.Text = Nothing
                        If Not IsDBNull(WK_DtView1(0)("end_date")) Then end_date.Text = WK_DtView1(0)("end_date") Else end_date.Text = Nothing
                        Combo_U001.Text = Nothing
                        WK_DtView2 = New DataView(DsCMB.Tables("M05_VNDR"), "vndr_code = '13'", "", DataViewRowState.CurrentRows)
                        If WK_DtView2.Count <> 0 Then
                            Combo_U001.Text = WK_DtView2(0)("name")
                            CLU001.Text = WK_DtView2(0)("vndr_code")
                            T2.Text = WK_DtView2(0)("rcpt_up2")
                            rpar_comp() '**  修理部署ＳＥＴ
                        End If

                        CheckBox_U001.Checked = False : CheckBox_U003.Checked = False
                        If Not IsDBNull(WK_DtView1(0)("model_name")) Then Edit_U001.Text = New_Line_Cng(WK_DtView1(0)("model_name")) Else Edit_U001.Text = Nothing
                        If Not IsDBNull(WK_DtView1(0)("s_n")) Then Edit_U003.Text = New_Line_Cng(WK_DtView1(0)("s_n")) Else Edit_U003.Text = Nothing
                        If Not IsDBNull(WK_DtView1(0)("prch_price")) Then prch_amnt.Text = WK_DtView1(0)("prch_price") Else prch_amnt.Text = 0
                        If Not IsDBNull(WK_DtView1(0)("prch_price")) Then Number001.Value = WK_DtView1(0)("prch_price") Else Number001.Value = 0
                        Number001_nTax.Value = RoundDOWN(Number001.Value / Wk_TAX_1, 0)
                        'If CheckBox2.Checked = True Then Number003.Value = 5000 Else Number003.Value = 0
                    End If
                End If
            End If
        End If
tab:
        brk01.Text = Edit011.Text
    End Sub

    Sub CHK_Combo002()   '入荷区分
        msg.Text = Nothing
        CL002.Text = Nothing
        CL002_2.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            Combo002.BackColor = System.Drawing.Color.Red
            msg.Text = "入荷区分が入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_018"), "cls_code_name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する入荷区分がありません。"
                Exit Sub
            Else
                CL002.Text = DtView1(0)("cls_code")
                CL002_2.Text = DtView1(0)("cls_code_name_abbr")
                If DtView1(0)("cls_code_name_abbr") = "一般" Then
                    '販社非表示
                    Label004.Visible = False : Edit003.Visible = False : Edit003.Text = Nothing
                    Label006.Text = "グループ番号"
                    'Label006.Visible = False : Edit004.Visible = False
                    Label007.Visible = False : Date001.Visible = False : Date001.Text = Nothing
                    If Edit001.Text = Nothing Then
                        WK_DsList1.Clear()
                        strSQL = "SELECT store_code FROM M08_STORE WHERE (delt_flg = 0) AND (idvd_flg = 1)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        SqlCmd1.CommandTimeout = 600
                        DB_OPEN("nMVAR")
                        DaList1.Fill(WK_DsList1, "M08_STORE")
                        DB_CLOSE()
                        WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count <> 0 Then
                            Edit001.Text = WK_DtView1(0)("store_code")
                            CHK_Edit001()   '販社
                        End If
                    End If
                Else                                    '販社
                    '販社表示
                    Label004.Visible = True : Edit003.Visible = True
                    Label006.Text = "販社修理番号"
                    'Label006.Visible = True : Edit004.Visible = True
                    Label007.Visible = True : Date001.Visible = True
                End If
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo003()   '入荷担当
        msg.Text = Nothing
        CL003.Text = Nothing

        Combo003.Text = Trim(Combo003.Text)
        If Combo003.Text = Nothing Then
            Combo003.BackColor = System.Drawing.Color.Red
            msg.Text = "入荷担当が入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("M01_EMPL"), "name = '" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo003.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する入荷担当がありません。"
                Exit Sub
            Else
                CL003.Text = DtView1(0)("empl_code")
            End If
        End If
        Combo003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit001()   '販社
        msg.Text = Nothing
        Label001.Text = Nothing
        Edit002.Text = Nothing
        Label002.Text = Nothing
        NumberN003.Value = 0 : NumberN007.Value = 0 : NumberN008.Value = 0

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "販社が入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT M08_STORE.store_code, M08_STORE.name, M08_STORE.dlvr_code, M08_STORE_1.name AS dlvr_name"
            strSQL += ", M08_STORE.tech_rate, M08_STORE.tech_mrgn_rate, M08_STORE.part_mrgn_rate, M08_STORE.grup_code"
            strSQL += " FROM M08_STORE LEFT OUTER JOIN"
            strSQL += " M08_STORE M08_STORE_1 ON"
            strSQL += " M08_STORE.dlvr_code = M08_STORE_1.store_code"
            strSQL += " WHERE (M08_STORE.store_code = '" & Edit001.Text & "')"
            strSQL += " AND (M08_STORE.delt_flg = 0)"
            Select Case CL002_2.Text
                Case Is = "一般"
                    strSQL += " AND (M08_STORE.idvd_flg = 1)"
                Case Is = "販社"
                    strSQL += " AND (M08_STORE.idvd_flg = 0)"
                Case Else
            End Select
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "M08_STORE")
            DB_CLOSE()

            WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する販社がありません。"
                Exit Sub
            Else
                Label001.Text = WK_DtView1(0)("name")
                Edit002.Text = WK_DtView1(0)("dlvr_code")
                Label002.Text = WK_DtView1(0)("dlvr_name")
                NumberN003.Value = WK_DtView1(0)("tech_rate")
                NumberN007.Value = WK_DtView1(0)("tech_mrgn_rate")
                NumberN008.Value = WK_DtView1(0)("part_mrgn_rate")
                GRP.Text = WK_DtView1(0)("grup_code")
                If CL001.Text = "02" Or CL001.Text = "03" Then  'QG-Care,延長保証
                    If GRP.Text <> "89" And GRP.Text <> "90" Then
                        Edit001.BackColor = System.Drawing.Color.Red
                        msg.Text = "QG-Care,延長保証の時は販社グループ'89','90'以外は入力できません。"
                        Exit Sub
                    End If
                Else
                    If GRP.Text = "90" Then
                        Edit001.BackColor = System.Drawing.Color.Red
                        msg.Text = "QG-Care,延長保証以外の時は販社グループ'90'は入力できません。"
                        Exit Sub
                    End If
                End If
                '2013/08/21 イレギュラー処理↓↓↓↓↓
                Select Case Edit001.Text
                    Case Is = "3355"    'ソフトバンクテレコム（山形）
                        Edit007.Text = "0238882726"
                        Edit005.Text = "ソフトバンクテレコム㈱モバイル"
                        Edit006.Text = "ｿﾌﾄﾊﾞﾝｸﾃﾚｺﾑｶﾌﾞﾓ"
                        Mask1.Value = "9930035"
                        Edit009.Text = "山形県長井市時庭1960"
                        Edit010.Text = ""
                        Combo_U001.Text = WK_ios
                        CLU001.Text = "20"
                        'If Edit_U004.Text = Nothing Then
                        '    Edit_U004.Text = "リニューアル希望"
                        'Else
                        '    If Edit_U004.Text.IndexOf("リニューアル希望") = -1 Then
                        '        Edit_U004.Text += " リニューアル希望"
                        '    End If
                        'End If
                    Case Is = "9210"    'ソフトバンクテレコム（レンタル）
                        Edit007.Text = "0335277512"
                        Edit005.Text = "ソフトバンクテレコム㈱モバイル"
                        Edit006.Text = "ｿﾌﾄﾊﾞﾝｸﾃﾚｺﾑｶﾌﾞﾓ"
                        Mask1.Value = "1350064"
                        Edit009.Text = "東京都江東区青海3-4-19"
                        Edit010.Text = "青海流通センター1号棟3F"
                        Combo_U001.Text = WK_ios
                        CLU001.Text = "20"
                        'If Edit_U004.Text = Nothing Then
                        '    Edit_U004.Text = "リニューアル希望"
                        'Else
                        '    If Edit_U004.Text.IndexOf("リニューアル希望") = -1 Then
                        '        Edit_U004.Text += " リニューアル希望"
                        '    End If
                        'End If
                End Select
                '2013/08/21 イレギュラー処理↑↑↑↑↑
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit003()   '販社担当者
        msg.Text = Nothing

        If Edit003.Visible = True Then
            Edit003.Text = Trim(Edit003.Text)
        Else
            Edit003.Text = Nothing
        End If
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit004()   '販社修理番号（グループ番号）
        msg.Text = Nothing
        Edit004.BackColor = System.Drawing.SystemColors.Window

        Edit004.Text = Trim(Edit004.Text)
        If Edit004.Text <> Nothing Then
            If CL002_2.Text = "一般" Then
                WK_DsList1.Clear()
                strSQL = "SELECT * FROM T01_REP_MTR"
                strSQL += " WHERE (store_repr_no = rcpt_no)"
                strSQL += " AND (rcpt_no = '" & Edit004.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Edit004.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当するグループ番号がありません。"
                    GoTo tab
                Else
                    If Edit005.ReadOnly = True Then
                        If Label3.Text <> Nothing Then
                            If Label3.Text <> WK_DtView1(0)("user_name") Then
                                Edit004.BackColor = System.Drawing.Color.Red
                                msg.Text = "QG Care に登録されている氏名とグループ番号で検索した氏名が違います。"
                                GoTo tab
                            End If
                        End If
                    End If
                End If
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT T01_REP_MTR.*"
                strSQL += " FROM T01_REP_MTR INNER JOIN"
                strSQL += " (SELECT cls_code, cls_code_name_abbr FROM M21_CLS_CODE WHERE (cls_no = '018')) cls018 ON"
                strSQL += " T01_REP_MTR.arvl_cls = cls018.cls_code COLLATE Japanese_CI_AS"
                strSQL += " WHERE (cls018.cls_code_name_abbr <> '一般')"
                strSQL += " AND (T01_REP_MTR.store_code = '" & Edit001.Text & "')"
                strSQL += " AND (T01_REP_MTR.store_repr_no = '" & Edit004.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                Else
                    If Edit005.ReadOnly = True Then
                        If Label3.Text <> Nothing Then
                            If Label3.Text <> WK_DtView1(0)("user_name") Then
                                Edit004.BackColor = System.Drawing.Color.Red
                                msg.Text = "QG Care に登録されている氏名と販社修理番号で検索した氏名が違います。"
                                GoTo tab
                            End If
                        End If
                    End If
                End If

            End If
            If brk03.Text <> Edit004.Text Then
                If WK_DtView1.Count <> 0 Then
                    If Trim(Edit005.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("user_name")) Then Edit005.Text = WK_DtView1(0)("user_name") Else Edit005.Text = Nothing
                    End If
                    If Trim(Edit006.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("user_name_kana")) Then Edit006.Text = WK_DtView1(0)("user_name_kana") Else Edit006.Text = Nothing
                    End If
                    If Trim(Edit007.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("tel1")) Then Edit007.Text = WK_DtView1(0)("tel1") Else Edit007.Text = Nothing
                    End If
                    If Trim(Edit008.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("tel2")) Then Edit008.Text = WK_DtView1(0)("tel2") Else Edit008.Text = Nothing
                    End If
                    If Trim(Edit016.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("email")) Then Edit016.Text = WK_DtView1(0)("email") Else Edit016.Text = Nothing
                    End If
                    If Mask1.Text = "〒 ___-____" Then
                        If Not IsDBNull(WK_DtView1(0)("zip")) Then
                            Dim WK_str As String = WK_DtView1(0)("zip")
                            Mask1.Value = WK_str.Replace("-", "")
                        Else
                            Mask1.Value = 0
                        End If
                    End If
                    If Trim(Edit009.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("adrs1")) Then Edit009.Text = WK_DtView1(0)("adrs1") Else Edit009.Text = Nothing
                    End If
                    If Trim(Edit010.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("adrs2")) Then Edit010.Text = WK_DtView1(0)("adrs2") Else Edit010.Text = Nothing
                    End If
                End If
            End If
        End If
tab:
        brk03.Text = Edit004.Text
    End Sub
    Sub CHK_CkBox01()   '過失
        msg.Text = Nothing

        'If GRP.Text = "63" Then
        '    If CkBox01_Y.Checked = False And CkBox01_N.Checked = False Then
        '        CkBox01_Y.BackColor = System.Drawing.Color.Red
        '        msg.Text = "過失の有無が選択されていません。"
        '        Exit Sub
        '    End If
        'End If
        CkBox01_Y.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Sub CHK_Date001()   '販社受付日
        msg.Text = Nothing
        Err_CX = "0"

        If Date001.Visible = True Then
            If Date001.Number = 0 Then
                If Number001.Value <> 0 Or CL004.Text > "01" Then
                    Date001.BackColor = System.Drawing.Color.Red
                    msg.Text = "販社受付日が入力されていません。"
                    Exit Sub
                End If
            Else
                If Date003.Number <> 0 Then
                    If Date001.Text > Date003.Text Then
                        Date001.BackColor = System.Drawing.Color.Red
                        msg.Text = "販社受付日＞受付日エラー。"
                        Exit Sub
                    End If
                End If
                If Number001.Value <> 0 Then
                    If Date_U003.Number <> 0 Then
                        If DateAdd(DateInterval.Month, 2, CDate(Date_U003.Text)) <= Date001.Text Then
                            Date001.BackColor = System.Drawing.Color.Red
                            msg.Text = "事故日より2ヶ月以上後の販社受付日は受付です。"
                            Err_CX = "1"
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Else
            Date001.Text = Nothing
        End If
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit007()   '電話番号1
        msg.Text = Nothing
        Edit007.BackColor = System.Drawing.SystemColors.Window

        Edit007.Text = Trim(Edit007.Text)
        If Edit007.Text <> Nothing Then
            If brk07.Text <> Edit007.Text Then
                WK_DsList1.Clear()
                strSQL = "SELECT user_name, user_name_kana, zip, adrs1, adrs2, tel2, email"
                strSQL += " FROM T01_REP_MTR"
                strSQL += " WHERE (tel1 = '" & Edit007.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    If Trim(Edit005.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("user_name")) Then Edit005.Text = WK_DtView1(0)("user_name") Else Edit005.Text = Nothing
                    End If
                    If Trim(Edit006.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("user_name_kana")) Then Edit006.Text = WK_DtView1(0)("user_name_kana") Else Edit006.Text = Nothing
                    End If
                    If Trim(Edit008.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("tel2")) Then Edit008.Text = WK_DtView1(0)("tel2") Else Edit008.Text = Nothing
                    End If
                    If Trim(Edit016.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("email")) Then Edit016.Text = WK_DtView1(0)("email") Else Edit016.Text = Nothing
                    End If
                    If Mask1.Text = "〒 ___-____" Then
                        If Not IsDBNull(WK_DtView1(0)("zip")) Then
                            Dim WK_str As String = WK_DtView1(0)("zip")
                            Mask1.Value = WK_str.Replace("-", "")
                        Else
                            Mask1.Value = 0
                        End If
                    End If
                    If Trim(Edit009.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("adrs1")) Then Edit009.Text = WK_DtView1(0)("adrs1") Else Edit009.Text = Nothing
                    End If
                    If Trim(Edit010.Text) = Nothing Then
                        If Not IsDBNull(WK_DtView1(0)("adrs2")) Then Edit010.Text = WK_DtView1(0)("adrs2") Else Edit010.Text = Nothing
                    End If
                End If
            End If
        End If
tab:
        brk07.Text = Edit007.Text
    End Sub
    Sub CHK_Edit005()   'お客様名
        msg.Text = Nothing
        Edit005.Text = Trim(Edit005.Text).Replace(System.Environment.NewLine, "")

        Edit005.Text = Trim(Edit005.Text)
        If Edit005.Text = Nothing Then
            Edit005.BackColor = System.Drawing.Color.Red
            msg.Text = "お客様名が入力されていません。"
            Exit Sub
        End If
        If Edit005.ReadOnly = False Then
            Edit005.BackColor = System.Drawing.SystemColors.Window
        Else
            Edit005.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
    Sub CHK_Mask1()     '郵便番号
        msg.Text = Nothing

        If Mask1.Value = Nothing Then
        Else
            If Len(Mask1.Value) <> 7 Then
                Mask1.BackColor = System.Drawing.Color.Red
                msg.Text = "郵便番号は7桁入力してください。"
                Exit Sub
            End If
        End If
        Mask1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo004()   '修理種別
        msg.Text = Nothing
        CL004.Text = Nothing

        Combo004.Text = Trim(Combo004.Text)
        If Combo004.Text = Nothing Then
            Combo004.BackColor = System.Drawing.Color.Red
            msg.Text = "修理種別が入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_001"), "cls_code_name = '" & Combo004.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo004.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する修理種別がありません。"
                Exit Sub
            Else
                CL004.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo005()   '事故状況
        msg.Text = Nothing
        CL005.Text = Nothing
        Number003.Value = 0

        Combo005.Text = Trim(Combo005.Text)
        If Combo005.Text = Nothing Then
            If Edit011.Visible = True Then
                Combo005.BackColor = System.Drawing.Color.Red
                msg.Text = "事故状況が入力されていません。"
                Exit Sub
            End If
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_022"), "cls_code_name = '" & Combo005.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo005.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する事故状況がありません。"
                Exit Sub
            Else
                CL005.Text = DtView1(0)("cls_code")
                If Label21.Text = "QG Care No" Then
                    Number003.Value = DtView1(0)("cls_code_name_abbr")
                Else
                    If DtView1(0)("cls_code_name_abbr") <> "0" Then
                        If CheckBox2.Checked = True Then Number003.Value = 5000
                    End If
                End If
            End If
        End If
        Combo005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo006()   'Mobile種別
        msg.Text = Nothing
        CL006.Text = Nothing

        Combo006.Text = Trim(Combo006.Text)
        If Combo006.Text = Nothing Then
            'Combo006.BackColor = System.Drawing.Color.Red
            'msg.Text = "Mobile種別が入力されていません。"
            'Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_035"), "cls_code_name = '" & Combo006.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo006.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するMobile種別がありません。"
                Exit Sub
            Else
                CL006.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit012()   'ｵﾘｼﾞﾅﾙﾒｰｶｰｺｰﾄﾞ
        msg.Text = Nothing
        Edit012.Text = Trim(Edit012.Text)

        'If CL004.Text = "02" Then   'ﾒｰｶｰ保証
        '    If Edit012.Text = Nothing Then
        '        Edit012.BackColor = System.Drawing.Color.Red
        '        msg.Text = "ｵﾘｼﾞﾅﾙﾒｰｶｰｺｰﾄﾞが入力されていません。"
        '        Exit Sub
        '    End If
        'End If
        Edit012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit014()   'Ref.
        msg.Text = Nothing
        Edit014.Text = Trim(Edit014.Text)

        Edit014.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit015()   'iMV番号
        msg.Text = Nothing
        Edit015.Text = Trim(Edit015.Text)

        Edit015.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit016()   'email
        msg.Text = Nothing
        Edit016.Text = Trim(Edit016.Text)
        Select Case CLU001.Text
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                Edit016.Text = Trim(Edit016.Text)
                If Edit016.Text = Nothing Then
                    Edit016.BackColor = System.Drawing.Color.Red
                    msg.Text = "emailが入力されていません。"
                    Exit Sub
                End If
            Case Else
        End Select
        Edit016.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date_U001()   '購入日
        msg.Text = Nothing

        If Date_U001.Number = 0 Then
            'Date_U001.BackColor = System.Drawing.Color.Red
            'msg.Text = "購入日が入力されていません。"
            'Exit Sub
        Else
            Select Case Date_U001.Text
                Case Is > Now.Date  '未来日付
                    Date_U001.BackColor = System.Drawing.Color.Red
                    msg.Text = "購入日に未来日付の入力はできません。"
                    Exit Sub
            End Select
        End If
        Date_U001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date_U002()   'メーカー保証開始日
        msg.Text = Nothing

        If Date_U002.Number = 0 Then
            If CL004.Text = "02" Then
                If CheckBox_U002.Checked = False Then
                    Date_U002.BackColor = System.Drawing.Color.Red
                    msg.Text = "メーカー保証開始日が入力されていません。"
                    Exit Sub
                End If
            End If
        Else
            Select Case Date_U002.Text
                Case Is > Now.Date  '未来日付
                    Date_U002.BackColor = System.Drawing.Color.Red
                    msg.Text = "メーカー保証開始日に未来日付の入力はできません。"
                    Exit Sub
            End Select
            If Date_U003.Number <> 0 Then
                If DateAdd(DateInterval.Year, CInt(Wrn_Y.Text), CDate(Date_U002.Text)) <= Date_U003.Text And Edit011.Visible = True Then
                    Date_U003.BackColor = System.Drawing.Color.Red
                    msg.Text = "QG-Careの期限が切れています。"
                    Exit Sub
                End If
            End If
            If Label21.Text = "QG Care No" Then
                end_date.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, CInt(Wrn_Y.Text), CDate(Date_U002.Text)))
            End If
        End If
        Date_U002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date_U004()   'メーカー保証終了日
        msg.Text = Nothing

        If Date_U004.Number = 0 Then
            If CL004.Text = "02" Then
                If CheckBox_U002.Checked = False Then
                    Date_U004.BackColor = System.Drawing.Color.Red
                    msg.Text = "メーカー保証終了日が入力されていません。"
                    Exit Sub
                End If
            End If
        Else
            'Select Case Date_U004.Text
            '    Case Is > Now.Date  '未来日付
            '        Date_U004.BackColor = System.Drawing.Color.Red
            '        msg.Text = "メーカー保証終了日に未来日付の入力はできません。"
            '        Exit Sub
            'End Select
            'If Date_U003.Number <> 0 Then
            '    If DateAdd(DateInterval.Year, CInt(Wrn_Y.Text), CDate(Date_U002.Text)) <= Date_U003.Text And Edit011.Visible = True Then
            '        Date_U003.BackColor = System.Drawing.Color.Red
            '        msg.Text = "QG-Careの期限が切れています。"
            '        Exit Sub
            '    End If
            'End If
            'If Label21.Text = "QG Care No" Then
            '    end_date.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, CInt(Wrn_Y.Text), CDate(Date_U002.Text)))
            'End If
        End If
        Date_U004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Date_U003()   '事故日
        msg.Text = Nothing
        Err_CX = "0"

        If Date_U003.Number = 0 Then
            If Edit011.Visible = True Then 'Or CL004.Text > "01" Then
                Date_U003.BackColor = System.Drawing.Color.Red
                msg.Text = "事故日が入力されていません。"
                Exit Sub
            End If
        Else
            Select Case Date_U003.Text
                Case Is > Now.Date  '未来日付
                    Date_U003.BackColor = System.Drawing.Color.Red
                    msg.Text = "事故日に未来日付の入力はできません。"
                    Exit Sub
            End Select
            If Date_U002.Number <> 0 Then
                If CDate(end_date.Text) < Date_U003.Text And Edit011.Visible = True Then
                    Date_U003.BackColor = System.Drawing.Color.Red
                    msg.Text = "保険の期限が切れています。"
                    Exit Sub
                End If
            End If
            If Number001.Value <> 0 Then
                If Date001.Visible = True And Date001.Number <> 0 Then
                    If DateAdd(DateInterval.Month, 2, CDate(Date_U003.Text)) <= Date001.Text Then
                        Date_U003.BackColor = System.Drawing.Color.Red
                        msg.Text = "販社受付日より2ヶ月以上前の事故日は受付です。"
                        Err_CX = "1"
                        Exit Sub
                    End If
                Else
                    If Date003.Number <> 0 Then
                        If DateAdd(DateInterval.Month, 2, CDate(Date_U003.Text)) <= Date003.Text Then
                            Date_U003.BackColor = System.Drawing.Color.Red
                            msg.Text = "受付日より2ヶ月以上前の事故日は受付です。"
                            Err_CX = "1"
                            Exit Sub
                        End If
                    End If
                End If
            End If

        End If
        Date_U003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U001()   'モデル
        msg.Text = Nothing

        Edit_U001.Text = Trim(Edit_U001.Text)
        If Edit_U001.Text = Nothing Then
            Edit_U001.BackColor = System.Drawing.Color.Red
            msg.Text = "モデルが入力されていません。"
            Exit Sub
        Else
            If CLU001.Text = "01" Or CLU001.Text = "20" Then
                'M番
                WK_DsList1.Clear()
                strSQL = "SELECT model_1 FROM M43_AP_M_NO"
                strSQL += " WHERE (delt_flg = 0)"
                strSQL += " AND (model_2 = '" & Edit_U001.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "M43_AP_M_NO")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("M43_AP_M_NO"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Edit_U002.Text = WK_DtView1(0)("model_1")
                End If
            End If
        End If
        Edit_U001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U002()   '機種
        msg.Text = Nothing

        Edit_U002.Text = Trim(Edit_U002.Text)
        If Edit_U002.Text = Nothing Then
            Edit_U002.BackColor = System.Drawing.Color.Red
            msg.Text = "機種が入力されていません。"
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
            msg.Text = "S/Nが入力されていません。"
            GoTo tab
        Else
            If Edit_U003.Text <> brk02.Text Then
                re_rpar()   '再修理チェック
                'qg_srch()   'QG-Careデータ検索
            End If
        End If
tab:
        brk02.Text = Edit_U003.Text
    End Sub
    Sub CHK_Edit_U006()   'SB/IMEI
        msg.Text = Nothing
        Edit_U006.BackColor = System.Drawing.SystemColors.Window

        Edit_U006.Text = Trim(Edit_U006.Text)
        If GRP.Text = "63" Then   'ソフトバンク
            If Edit_U006.Text = Nothing Then
                Edit_U006.BackColor = System.Drawing.Color.Red
                msg.Text = "IMEI番号が入力されていません"
            End If
        End If
    End Sub
    Sub CHK_Edit_U006_2()   'SB/IMEI
        msg.Text = Nothing
        Edit_U006.BackColor = System.Drawing.SystemColors.Window

        Edit_U006.Text = Trim(Edit_U006.Text)
        If GRP.Text = "63" Then   'ソフトバンク
            If LenB(Edit_U006.Text) <> 15 Then
                Edit_U006.BackColor = System.Drawing.Color.Red
                msg.Text = "IMEI番号は15桁です"
            End If
        End If
    End Sub
    Sub CHK_Combo_U001()   'メーカー
        msg.Text = Nothing
        CLU001.Text = Nothing
        cmb_reset = "0"

        Combo_U001.Text = Trim(Combo_U001.Text)
        If Combo_U001.Text = Nothing Then
            Combo_U001.BackColor = System.Drawing.Color.Red
            msg.Text = "メーカーが入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("M05_VNDR"), "name = '" & Combo_U001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo_U001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するメーカーがありません。"
                Exit Sub
            Else
                If CLU001.Text <> DtView1(0)("vndr_code") Then
                    cmb_reset = "1"
                    CLU001.Text = DtView1(0)("vndr_code")
                    T2.Text = DtView1(0)("rcpt_up2")
                    re_rpar() '再修理チェック
                    If CLU001.Text = "01" Then
                        CheckBox_U001.Text = "定額修理"
                        CheckBox_U003.Visible = True
                    Else
                        CheckBox_U001.Text = "Ｎｏｔｅ"
                        CheckBox_U003.Visible = False
                    End If
                End If
            End If
        End If
        Combo_U001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo_U002()   '修理部署
        msg.Text = Nothing
        CLU002.Text = Nothing

        Combo_U002.Text = Trim(Combo_U002.Text)
        If Combo_U002.Text = Nothing Then
            Combo_U002.BackColor = System.Drawing.Color.Red
            msg.Text = "修理部署が入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("M06_RPAR_COMP"), "name = '" & Combo_U002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo_U002.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する修理部署がありません。"
                Exit Sub
            Else
                CLU002.Text = DtView1(0)("rpar_comp_code")
                If DtView1(0)("own_flg") = "1" Then CK_own_flg.Checked = True Else CK_own_flg.Checked = False
            End If
        End If
        Combo_U002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_fuzoku_name(ByVal seq As Integer) '付属品名
        msg.Text = Nothing

        edit(seq, 1).Text = Trim(edit(seq, 1).Text)
        If chkBox(seq, 1).Checked = True Then
            If edit(seq, 1).Text = Nothing Then
                edit(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "付属品名の入力がありません。"
                Exit Sub
            End If
        Else
            If edit(seq, 1).Text <> Nothing Then
                edit(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "対象になっていません。"
                Exit Sub
            End If
        End If
        edit(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_fuzoku_QTY(ByVal seq As Integer) '付属数量
        msg.Text = Nothing

        If Trim(edit(seq, 2).Text) <> Nothing Then   '単位
            If chkBox(seq, 1).Checked = True Then
                'If nbrBox(seq, 1).Value = 0 Then
                '    nbrBox(seq, 1).BackColor = System.Drawing.Color.Red
                '    msg.Text = "数量の入力がありません。"
                '    Exit Sub
                'End If
            Else
                If nbrBox(seq, 1).Value <> 0 Then
                    nbrBox(seq, 1).BackColor = System.Drawing.Color.Red
                    msg.Text = "対象になっていません。"
                    Exit Sub
                End If
            End If
        End If
        nbrBox(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_cmnt1(ByVal seq As Integer) '故障箇所
        msg.Text = Nothing

        cmbBo_2(seq, 1).Text = Trim(cmbBo_2(seq, 1).Text)
        If cmbBo_2(seq, 1).Text = Nothing Then
        Else
            WK_DtView1 = New DataView(WK_DsCMB.Tables("M10_CMNT_1" & seq), "cmnt ='" & cmbBo_2(seq, 1).Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                cmbBo_2(seq, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "該当する故障内容がありません。"
                Exit Sub
            Else
                label_2(seq, 1).Text = WK_DtView1(0)("cmnt_code")
            End If
        End If
        cmbBo_2(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U004()   '故障内容
        msg.Text = Nothing

        Edit_U004.Text = Trim(Edit_U004.Text)
        If Edit_U004.Text = Nothing Then
            'Edit_U004.BackColor = System.Drawing.Color.Red
            'msg.Text = "故障内容が入力されていません。"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_U004.Text)
            If P_Line > 9 Then
                Edit_U004.BackColor = System.Drawing.Color.Red
                msg.Text = "９行以上の入力はできません。"
                Exit Sub
            End If
        End If
        Edit_U004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit_U005()   '故障コメント
        msg.Text = Nothing

        Edit_U005.Text = Trim(Edit_U005.Text)
        If Edit_U005.Text = Nothing Then
            'Edit_U005.BackColor = System.Drawing.Color.Red
            'msg.Text = "故障コメントが入力されていません。"
            'Exit Sub
            P_Line = 0
        Else
            Line_Get(Edit_U005.Text)
            If P_Line > 9 Then
                Edit_U005.BackColor = System.Drawing.Color.Red
                msg.Text = "９行以上の入力はできません。"
                Exit Sub
            End If
        End If
        Edit_U005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub re_rpar() '再修理チェック
        If Combo_U001.Text <> Nothing Then
            If Edit_U003.Text <> Nothing Then

                WK_DsList1.Clear()
                strSQL = "SELECT rcpt_no, comp_date, re_rpar_date"
                strSQL += " FROM T01_REP_MTR"
                strSQL += " WHERE (vndr_code = '" & CLU001.Text & "') AND (s_n = '" & Edit_U003.Text & "')"
                strSQL += " AND (aka_flg = 0 OR aka_flg IS NULL)"
                strSQL += " ORDER BY  comp_date DESC"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                r = DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                DB_CLOSE()

                If r <> 0 Then
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "re_rpar_date DESC", DataViewRowState.CurrentRows)
                    Dim WK_rcpt_no, WK_comp_date As String
                    WK_rcpt_no = WK_DtView1(0)("rcpt_no")
                    If Not IsDBNull(WK_DtView1(0)("comp_date")) Then WK_comp_date = WK_DtView1(0)("comp_date")
                    If Not IsDBNull(WK_DtView1(0)("re_rpar_date")) Then
                        If Date001.Visible = True And Date001.Number <> 0 Then
                            If WK_DtView1(0)("re_rpar_date") >= Date001.Text Then
                                MessageBox.Show("再修理です。前回修理番号：" & WK_DtView1(0)("rcpt_no") & "  完了日：" & WK_DtView1(0)("comp_date"), "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            If WK_DtView1(0)("re_rpar_date") >= Date003.Text Then
                                MessageBox.Show("再修理です。前回修理番号：" & WK_DtView1(0)("rcpt_no") & "  完了日：" & WK_DtView1(0)("comp_date"), "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    End If
                    '経過日数に関係なくアラート
                    MessageBox.Show("過去に修理履歴があります 各自で履歴を調査願います。" & System.Environment.NewLine & "前回修理番号：" & WK_rcpt_no & "  完了日：" & WK_comp_date, "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub
    Sub qg_srch()   'QG-Careデータ検索
        If Edit_U003.Text <> Nothing Then
            WK_DsList1.Clear()
            strSQL = "SELECT T01_member.code, T01_member.wrn_range"
            strSQL += " FROM T01_member LEFT OUTER JOIN"
            strSQL += " T06_sno ON T01_member.code = T06_sno.code"
            strSQL += " WHERE (T01_member.s_no = '" & Edit_U003.Text & "')"
            strSQL += " AND (T01_member.delt_flg = 0)"
            strSQL += " OR (T06_sno.s_no = '" & Edit_U003.Text & "')"
            strSQL += " AND (T01_member.delt_flg = 0)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("QGCare")
            r = DaList1.Fill(WK_DsList1, "T01_member")
            DB_CLOSE()

            If r <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                Select Case WK_DtView1(0)("wrn_range")
                    Case Is = "10"
                        WK_DtView2 = New DataView(DsCMB.Tables("CLS_CODE_007"), "cls_code = '12'", "", DataViewRowState.CurrentRows)
                        Combo001.Text = WK_DtView2(0)("cls_code_name")
                    Case Is = "7"
                        WK_DtView2 = New DataView(DsCMB.Tables("CLS_CODE_007"), "cls_code = '07'", "", DataViewRowState.CurrentRows)
                        Combo001.Text = WK_DtView2(0)("cls_code_name")
                    Case Else
                        WK_DtView2 = New DataView(DsCMB.Tables("CLS_CODE_007"), "cls_code = '02'", "", DataViewRowState.CurrentRows)
                        Combo001.Text = WK_DtView2(0)("cls_code_name")
                End Select
                CHK_Combo001()  '受付種別
                Edit011.Text = WK_DtView1(0)("code")
                CHK_Edit011()   'QG Care No
            End If
        End If
    End Sub
    Sub CHK_Cor()   '受付種別と事故状況組み合わせチェック
        If CL001.Text = "03" Then   '延長保証
            If CL005.Text <> Nothing And CL005.Text <> "01" Then '故障以外
                Combo001.BackColor = System.Drawing.Color.Red
                Combo005.BackColor = System.Drawing.Color.Red
                msg.Text = "通常故障ではない場合、延長保証扱いにはできません。"
            End If
        End If
    End Sub
    Sub limt_set()
        Select Case Label21.Text
            Case Is = "QG Care No"
                If Date_U003.Number <> 0 And Edit011.Text <> Nothing And Combo005.Text <> Nothing Then
                    Number001.Value = Limit_Get(Edit011.Text, CL005.Text, Date_U003.Text, prch_amnt.Text)

                    If CL004.Text = "01" Then
                        DtView1 = New DataView(DsCMB.Tables("CLS_CODE_022"), "cls_code_name = '" & Combo005.Text & "'", "", DataViewRowState.CurrentRows)
                        If DtView1.Count <> 0 Then
                            Number003.Value = DtView1(0)("cls_code_name_abbr")
                        End If
                    Else
                        Number003.Value = 0
                    End If
                Else
                    Number001.Value = 0
                    Number003.Value = 0
                End If
                Number001_nTax.Value = RoundDOWN(Number001.Value / Wk_TAX_1, 0)
            Case Is = "Fujitsu No"
                Number003.Value = 0
                If CheckBox2.Checked = True Then
                    If Date_U003.Number <> 0 And Edit011.Text <> Nothing And Combo005.Text <> Nothing Then
                        If CL004.Text = "01" Then
                            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_022"), "cls_code_name = '" & Combo005.Text & "'", "", DataViewRowState.CurrentRows)
                            If DtView1.Count <> 0 Then
                                If DtView1(0)("cls_code_name_abbr") <> "0" Then
                                    Number003.Value = 5000
                                End If
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub
    Sub F_Check()
        Err_F = "0"

        CHK_Date003()   '受付日
        If msg.Text <> Nothing And Err_CX = "0" Then Err_F = "1" : Date003.Focus() : Exit Sub

        CHK_Date015()   '診断日
        If msg.Text <> Nothing And Err_CX = "0" Then Err_F = "1" : Date015.Focus() : Exit Sub

        CHK_Combo001()  '受付種別
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Edit011()   'QG Care No
        If msg.Text <> Nothing Then Err_F = "1" : Edit011.Focus() : Exit Sub

        CHK_Combo002()  '入荷区分
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Combo003()  '入荷担当
        If msg.Text <> Nothing Then Err_F = "1" : Combo003.Focus() : Exit Sub

        CHK_Edit001()   '販社
        If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub

        CHK_Edit003()   '販社担当者
        If msg.Text <> Nothing Then Err_F = "1" : Edit003.Focus() : Exit Sub

        CHK_Edit004()   '販社修理番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit004.Focus() : Exit Sub

        CHK_CkBox01()   '過失
        If msg.Text <> Nothing Then Err_F = "1" : CkBox01_Y.Focus() : Exit Sub

        CHK_Date001()   '販社受付日
        If msg.Text <> Nothing And Err_CX = "0" Then Err_F = "1" : Date001.Focus() : Exit Sub

        CHK_Edit005()   'お客様名
        If msg.Text <> Nothing Then Err_F = "1" : Edit005.Focus() : Exit Sub

        CHK_Edit016()   'email
        If msg.Text <> Nothing Then Err_F = "1" : Edit016.Focus() : Exit Sub

        CHK_Mask1()     '郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask1.Focus() : Exit Sub

        CHK_Combo004()  '修理種別
        If msg.Text <> Nothing Then Err_F = "1" : Combo004.Focus() : Exit Sub

        CHK_Edit012()   'ｵﾘｼﾞﾅﾙﾒｰｶｰｺｰﾄﾞ
        If msg.Text <> Nothing Then Err_F = "1" : Edit012.Focus() : Exit Sub

        CHK_Edit014()   'Ref.
        If msg.Text <> Nothing Then Err_F = "1" : Edit014.Focus() : Exit Sub

        CHK_Edit015()   'iMV番号
        If msg.Text <> Nothing Then Err_F = "1" : Edit015.Focus() : Exit Sub

        CHK_Combo005()  '事故状況
        If msg.Text <> Nothing Then Err_F = "1" : Combo005.Focus() : Exit Sub

        CHK_Cor()       '受付種別と事故状況組み合わせチェック
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Combo006()  'Mobile種別
        If msg.Text <> Nothing Then Err_F = "1" : Combo006.Focus() : Exit Sub

        CHK_Date_U001() '購入日
        If msg.Text <> Nothing Then Err_F = "1" : Date_U001.Focus() : Exit Sub

        CHK_Date_U002() 'メーカー保証開始日
        If msg.Text <> Nothing Then Err_F = "1" : Date_U002.Focus() : Exit Sub

        CHK_Date_U004() 'メーカー保証終了日
        If msg.Text <> Nothing Then Err_F = "1" : Date_U004.Focus() : Exit Sub

        CHK_Date_U003() '事故日
        If msg.Text <> Nothing And Err_CX = "0" Then Err_F = "1" : Date_U001.Focus() : Exit Sub

        CHK_Combo_U001()    'メーカー
        If msg.Text <> Nothing Then Err_F = "1" : Combo_U001.Focus() : Exit Sub

        CHK_Edit_U001()     'モデル
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U001.Focus() : Exit Sub

        CHK_Edit_U002()     '機種
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U002.Focus() : Exit Sub

        CHK_Edit_U003()     'S/N
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U003.Focus() : Exit Sub

        CHK_Combo_U002()    '修理部署
        If msg.Text <> Nothing Then Err_F = "1" : Combo_U002.Focus() : Exit Sub

        'ノート区分
        If CheckBox_U003.Visible = False Then
            CheckBox_U003.Checked = CheckBox_U001.Checked
        End If

        CHK_Edit_U006()     'SB/IMEI
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U006.Focus() : Exit Sub

        '付属品
        For i = 0 To Line_No
            If label(i, 1).Text <> Nothing Then

                If edit(i, 2).Text <> Nothing Then
                    CHK_fuzoku_QTY(i)   '付属数量
                    If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 1).Focus() : Exit Sub
                End If

            Else            'ﾌﾘｰ入力

                CHK_fuzoku_name(i)  '付属品名
                If msg.Text <> Nothing Then Err_F = "1" : edit(i, 1).Focus() : Exit Sub

                CHK_fuzoku_QTY(i)   '付属数量
                If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 1).Focus() : Exit Sub
            End If
        Next

        '故障内容
        seq = 0
        For i = 0 To Line_No2

            CHK_cmnt1(i) '故障内容
            If msg.Text <> Nothing Then Err_F = "1" : cmbBo_2(i, 1).Focus() : Exit Sub

            If cmbBo_2(i, 1).Text <> Nothing Then
                seq = seq + 1
            End If
        Next

        CHK_Edit_U004()   '故障内容
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U004.Focus() : Exit Sub
        seq = seq + P_Line

        CHK_Edit_U005()   '故障コメント
        If msg.Text <> Nothing Then Err_F = "1" : Edit_U005.Focus() : Exit Sub
        seq = seq + P_Line

        If seq > 9 Then
            Edit_U004.BackColor = System.Drawing.Color.Red
            msg.Text = "故障内容の選択項目とフリー入力で合計９行以上の入力はできません。"
            Err_F = "1" : Edit_U005.Focus() : Exit Sub
        End If

    End Sub

    '********************************************************************
    '**  非表示の項目はクリアする
    '********************************************************************
    Sub NoDsp_Null()
        If Edit011.Visible = False Then Edit011.Text = Nothing
        If Number001_nTax.Visible = False Then Number001.Value = 0 : Number001_nTax.Value = 0
        If Number003.Visible = False Then Number003.Value = 0
        If Edit003.Visible = False Then Edit003.Text = Nothing
        If Date001.Visible = False Then Date001.Text = Nothing
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
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
    Private Sub Edit009_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit009.GotFocus
        Edit009.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Edit009.SelectionStart = Len(Edit009.Text)
    End Sub
    Private Sub Edit010_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit010.GotFocus
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
    Private Sub Edit014_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit014.GotFocus
        Edit014.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit015_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit015.GotFocus
        Edit015.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit016_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit016.GotFocus
        Edit016.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.GotFocus
        Date001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date003.GotFocus
        Date003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.GotFocus
        Date007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date008_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.GotFocus
        Date008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date015_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date015.GotFocus
        Date015.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Mask1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.GotFocus
        Mask1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.GotFocus
        Number002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub CheckBox_U002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U002.GotFocus
        CheckBox_U002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox_U003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U003.GotFocus
        CheckBox_U003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Date_U004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U004.GotFocus
        Date_U004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Edit_U006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U006.GotFocus
        Edit_U006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub QTY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Number
        Lin = DirectCast(sender, GrapeCity.Win.Input.Number)
        nbrBox(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Edit)
        edit(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub cmb1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmb As Combo
        cmb = DirectCast(sender, Combo)
        cmbBo_2(cmb.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    'Private Sub Number001_nTax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001_nTax.GotFocus
    '    Number001_nTax.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    'End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        CHK_Date001()   '販社受付日
    End Sub
    Private Sub Date003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date003.LostFocus
        CHK_Date003()   '受付日
    End Sub
    Private Sub Date007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date007.LostFocus
        CHK_Date007()   '部品発注日
    End Sub
    Private Sub Date008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date008.LostFocus
        CHK_Date008()   '部品受領日
    End Sub
    Private Sub Date015_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date015.LostFocus
        CHK_Date015()   '診断日
    End Sub
    Private Sub Combo001_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()  '受付種別
        CHK_Cor()       '受付種別と事故状況組み合わせチェック
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()  '入荷区分
    End Sub
    Private Sub Combo003_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo003.LostFocus
        CHK_Combo003()   '入荷担当
    End Sub
    Private Sub Combo004_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo004.LostFocus
        CHK_Combo004()   '修理種別
        limt_set()
    End Sub
    Private Sub Combo005_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo005.LostFocus
        CHK_Combo005()   '事故状況
        CHK_Cor()       '受付種別と事故状況組み合わせチェック
        limt_set()
    End Sub
    Private Sub Combo006_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo006.LostFocus
        CHK_Combo006()   'Mobile種別
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '販社
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        CHK_Edit003()   '販社担当者
    End Sub
    Private Sub Edit004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.LostFocus
        CHK_Edit004()   '販社修理番号（グループ番号）
    End Sub
    Private Sub Edit005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.LostFocus
        CHK_Edit005()   'お客様名
    End Sub
    Private Sub Edit006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.LostFocus
        Edit006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.LostFocus
        CHK_Edit007()   '電話番号1
    End Sub
    Private Sub Edit008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.LostFocus
        Edit008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit009_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit009.LostFocus
        Edit009.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit010_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit010.LostFocus
        Edit010.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit011_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit011.LostFocus
        CHK_Edit011()   'QG Care No
        If CInt(sn_n.Text) >= 2 Then msg.Text = "既に2回交換対応済みです。確認をお願いします。"
        limt_set()
    End Sub
    Private Sub Edit012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.LostFocus
        CHK_Edit012()   'ｵﾘｼﾞﾅﾙﾒｰｶｰｺｰﾄﾞ
    End Sub
    Private Sub Edit013_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit013.LostFocus
        Edit013.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit014_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit014.LostFocus
        CHK_Edit014()   'Ref.
    End Sub
    Private Sub Edit015_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit015.LostFocus
        CHK_Edit015()   'iMV番号
    End Sub
    Private Sub Edit016_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit016.LostFocus
        CHK_Edit016()   'email
    End Sub
    Private Sub Mask1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.LostFocus
        CHK_Mask1()     '郵便番号
    End Sub
    Private Sub Number002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.LostFocus
        Number002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub CkBox01_Y_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_Y.LostFocus
        CkBox01_Y.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CkBox01_N_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_N.LostFocus
        CkBox01_N.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Date_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U001.LostFocus
        CHK_Date_U001() '購入日
    End Sub
    Private Sub Date_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U002.LostFocus
        CHK_Date_U002() 'メーカー保証開始日
    End Sub
    Private Sub Date_U003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U003.LostFocus
        CHK_Date_U003() '事故日
        limt_set()
    End Sub
    Private Sub Date_U004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date_U004.LostFocus
        CHK_Date_U004() 'メーカー保証終了日
    End Sub
    Private Sub CheckBox_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U001.LostFocus
        CheckBox_U001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U002.LostFocus
        CheckBox_U002.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox_U003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U003.LostFocus
        CheckBox_U003.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Combo_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_U001.LostFocus
        CHK_Combo_U001()  'メーカー
        If cmb_reset = "1" Then
            If msg.Text = Nothing Then
                rpar_comp() '**  修理部署ＳＥＴ
            End If
        End If
    End Sub
    Private Sub Edit_U001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U001.LostFocus
        CHK_Edit_U001()     'モデル
    End Sub
    Private Sub Edit_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U002.LostFocus
        CHK_Edit_U002()     '機種
    End Sub
    Private Sub Edit_U003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U003.LostFocus
        CHK_Edit_U003()     'S/N
        If CInt(sn_n.Text) >= 2 Then msg.Text = "既に2回交換対応済みです。確認をお願いします。"
    End Sub
    Private Sub Edit_U006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U006.LostFocus
        CHK_Edit_U006()   'SB/IMEI
        If msg.Text = Nothing Then CHK_Edit_U006_2() 'SB/IMEI
    End Sub
    Private Sub Combo_U002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_U002.LostFocus
        CHK_Combo_U002()    '修理部署
        If CK_own_flg.Checked = True Then
            Label015.Text = "部品発注日"
            Label016.Text = "部品受領日"
        Else
            Label015.Text = "ﾒｰｶｰ発送日"
            Label016.Text = "ﾒｰｶｰ戻日"
        End If
    End Sub
    Private Sub Edit_U004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U004.LostFocus
        CHK_Edit_U004()   '修理内容
    End Sub
    Private Sub Edit_U005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit_U005.LostFocus
        CHK_Edit_U005()   '修理コメント
    End Sub
    Private Sub CHK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub edit1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Edit)
        CHK_fuzoku_name(Lin.Tag) '付属品名
    End Sub
    Private Sub QTY_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Number
        Lin = DirectCast(sender, GrapeCity.Win.Input.Number)
        CHK_fuzoku_QTY(Lin.Tag) '付属品数量
        If chkBox(Lin.Tag, 1).Checked = True Then
            If Lin.Tag = Line_No Then
                add_line()
                If Lin.Tag <> Line_No Then
                    chkBox(Line_No, 1).Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cmb1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As Combo
        cmb = DirectCast(sender, Combo)
        CHK_cmnt1(cmb.Tag)  '故障内容
        If Line_No2 = cmb.Tag Then
            If Line_No2 < 8 Then
                If cmbBo_2(cmb.Tag, 1).Text <> Nothing Then
                    add_line_2()    '故障内容
                    cmbBo_2(cmb.Tag + 1, 1).Focus()
                End If
            End If
        End If
    End Sub

    '********************************************************************
    '**  修理部署ＳＥＴ
    '********************************************************************
    Sub rpar_comp()
        'WK_DsList1.Clear()
        DsCMB.Tables("M06_RPAR_COMP").Clear()
        strSQL = "SELECT M07_RPAR_COMP_SCAN.rpar_comp_code, M07_RPAR_COMP_SCAN.rpar_comp_code + ':' + M06_RPAR_COMP.name AS name, M06_RPAR_COMP.own_flg"
        strSQL += " FROM M07_RPAR_COMP_SCAN INNER JOIN"
        strSQL += " M06_RPAR_COMP ON"
        strSQL += " M07_RPAR_COMP_SCAN.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code LEFT"
        strSQL += " OUTER JOIN"
        strSQL += " M03_BRCH ON M06_RPAR_COMP.brch_code = M03_BRCH.brch_code"
        strSQL += " WHERE (M06_RPAR_COMP.delt_flg = 0)"
        strSQL += " AND (M07_RPAR_COMP_SCAN.vndr_code = '" & CLU001.Text & "')"
        strSQL += " AND (M07_RPAR_COMP_SCAN.area_code = '" & P_area_code & "')"
        strSQL += " AND (M03_BRCH.comp_code = '" & P_comp_code & "' OR M03_BRCH.comp_code IS NULL)"
        strSQL += " ORDER BY M06_RPAR_COMP.own_flg DESC, M06_RPAR_COMP.name_kana, M06_RPAR_COMP.rpar_comp_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "M06_RPAR_COMP")
        DB_CLOSE()

        WK_DtView3 = New DataView(DsCMB.Tables("M06_RPAR_COMP"), "rpar_comp_code ='" & CLU002.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView3.Count = 1 Then
            Combo_U002.Text = WK_DtView3(0)("name")
        Else
            Combo_U002.Text = Nothing : CLU002.Text = Nothing
        End If
    End Sub

    '********************************************************************
    '**  検索
    '********************************************************************
    Private Sub Button_S2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S2.Click
        'QG Care
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Label21.Text = "QG Care No" Then
            Dim F00_Form05 As New F00_Form05
            F00_Form05.ShowDialog()
        Else
            Dim F00_Form05_2 As New F00_Form05_2
            F00_Form05_2.ShowDialog()
        End If

        If P_RTN = "1" Then
            Edit011.Text = P_PRAM1
            CHK_Edit011()   'QG Care No
        End If
        Edit011.Focus()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button_S3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S3.Click
        '販社
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Edit001.Text
        P_PRAM2 = CL002_2.Text
        Dim F00_Form02 As New F00_Form02
        F00_Form02.ShowDialog()
        If P_RTN = "1" Then
            Edit001.Text = P_PRAM1
            Label001.Text = P_PRAM2
            Edit002.Text = P_PRAM3
            Label002.Text = P_PRAM4
            NumberN003.Value = P_PRAM5
            NumberN007.Value = P_PRAM6
            NumberN008.Value = P_PRAM7
            Edit001.Focus()
            Edit001.BackColor = System.Drawing.SystemColors.Window
        Else
            Edit001.Focus()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button_S4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S4.Click
        '受付コメント
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = "02"  '受付コメント
        Dim F00_Form06 As New F00_Form06
        F00_Form06.ShowDialog()

        If P_RTN = "1" Then
            If Edit_U005.Text = Nothing Then
                Edit_U005.Text = P_PRAM1
            Else
                If Edit_U005.Text.LastIndexOf(P_PRAM1) = -1 Then
                    Edit_U005.Text = Trim(Edit_U005.Text) & System.Environment.NewLine & P_PRAM1
                End If
            End If
        End If
        Edit_U005.Focus()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button_S5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S5.Click
        '郵便番号->住所
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList1.Clear()
        strSQL = "SELECT adrs FROM M15_ZIP"
        strSQL += " WHERE (zip = '" & Mask1.Value & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        r = DaList1.Fill(P_DsList1, "M15_ZIP")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                msg.Text = "該当郵便番号なし"
                Mask1.Focus()
            Case Is = 1
                WK_DtView1 = New DataView(P_DsList1.Tables("M15_ZIP"), "", "", DataViewRowState.CurrentRows)
                Edit009.Text = Trim(WK_DtView1(0)("adrs"))
                Edit009.Focus()
            Case Else
                Dim F00_Form15 As New F00_Form15
                F00_Form15.ShowDialog()

                If P_RTN <> Nothing Then Edit009.Text = P_RTN : Edit009.Focus()
        End Select

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  登録
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If Button1.Text = "登録" Then
            NoDsp_Null()

            chg_itm = 0
            P_HSTY_DATE = Now
            F_Check()   '**  項目チェック
            If Err_F = "0" Then

                CHK_Edit_U006_2()   'SB/IMEI
                If msg.Text <> Nothing Then
                    ANS = MessageBox.Show("IMEI番号が15桁ではないですが登録を行いますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If ANS = "7" Then   'いいえ
                        GoTo skp
                    End If
                End If

                If CInt(sn_n.Text) >= 2 Then
                    ANS = MessageBox.Show("既に2回交換対応済みです。確認をお願いします。" & System.Environment.NewLine & "登録しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                    If ANS = "2" Then GoTo skp 'いいえ
                End If

                Edit000.Text = Count_Get(T2.Text)
                DB_OPEN("nMVAR")

                '受付
                strSQL = "INSERT INTO T01_REP_MTR"
                strSQL += " (rcpt_no, rcpt_ent_empl_code, rcpt_brch_code, rcpt_cls, qg_care_no, wrn_limt_amnt, menseki_amnt"
                strSQL += ", acdt_stts, acdt_date, recv_amnt, arvl_cls, arvl_empl, store_code, store_prsn, store_repr_no, store_accp_date"
                strSQL += ", store_wrn_info, tech_rate1, tech_rate2, part_rate2, user_name, user_name_kana, zip, adrs1, adrs2"
                strSQL += ", tel1, tel2, email, rpar_cls, defe_cls, prch_date, vndr_wrn_date, vndr_wrn_end_date, vndr_wrn_date_chk, vndr_code, model_1, model_2"
                strSQL += ", note_kbn, note_kbn2, s_n, rpar_comp_code, user_trbl, rcpt_comn, orgnl_vndr_code, accp_date, sindan_date, part_ordr_date"
                strSQL += ", part_rcpt_date, tax_rate, aka_flg, rpt_ex_flg, reference_no, imv_rcpt_no, sb_imei_old, kashitsu_flg)"
                strSQL += " VALUES ('" & Edit000.Text & "'"
                strSQL += ", " & P_EMPL_NO
                strSQL += ", '" & P_EMPL_BRCH & "'"
                strSQL += ", '" & CL001.Text & "'"
                If Edit011.Visible = True Then  'QG Care
                    strSQL += ", '" & Edit011.Text & "'"
                    strSQL += ", " & Number001.Value
                    strSQL += ", " & Number003.Value
                Else
                    strSQL += ", ''"
                    strSQL += ", 0"
                    strSQL += ", 0"
                End If
                strSQL += ", '" & CL005.Text & "'"
                If Date_U003.Number <> 0 Then strSQL += ", '" & Date_U003.Text & "'" Else strSQL += ", NULL"
                strSQL += ", " & Number002.Value
                strSQL += ", '" & CL002.Text & "'"
                strSQL += ", " & CL003.Text
                strSQL += ", '" & Edit001.Text & "'"
                strSQL += ", '" & Edit003.Text & "'"
                If Edit004.Text = Nothing And CL002_2.Text = "一般" Then
                    Edit004.Text = Edit000.Text
                End If
                strSQL += ", '" & Edit004.Text & "'"
                If Date001.Number <> 0 Then strSQL += ", '" & Date001.Text & "'" Else strSQL += ", NULL"
                strSQL += ", '" & Edit013.Text & "'"
                strSQL += ", " & NumberN003.Value
                strSQL += ", " & NumberN007.Value
                strSQL += ", " & NumberN008.Value
                strSQL += ", '" & Edit005.Text & "'"
                strSQL += ", '" & Edit006.Text & "'"
                strSQL += ", '" & Mask1.Value & "'"
                strSQL += ", '" & Edit009.Text & "'"
                strSQL += ", '" & Edit010.Text & "'"
                strSQL += ", '" & Edit007.Text & "'"
                strSQL += ", '" & Edit008.Text & "'"
                strSQL += ", '" & Edit016.Text & "'"
                strSQL += ", '" & CL004.Text & "'"
                strSQL += ", '" & CL006.Text & "'"
                If Date_U001.Number <> 0 Then strSQL += ", '" & Date_U001.Text & "'" Else strSQL += ", NULL"
                If Date_U002.Number <> 0 Then strSQL += ", '" & Date_U002.Text & "'" Else strSQL += ", NULL"
                If Date_U004.Number <> 0 Then strSQL += ", '" & Date_U004.Text & "'" Else strSQL += ", NULL"
                If CheckBox_U002.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ", '" & CLU001.Text & "'"
                strSQL += ", '" & Edit_U002.Text & "'"
                strSQL += ", '" & Edit_U001.Text & "'"
                If CheckBox_U001.Checked = True Then strSQL += ", '01'" Else strSQL += ", '02'"
                If CheckBox_U003.Checked = True Then strSQL += ", '01'" Else strSQL += ", '02'"
                strSQL += ", '" & Edit_U003.Text & "'"
                strSQL += ", '" & CLU002.Text & "'"
                strSQL += ", '" & Edit_U004.Text & "'"
                strSQL += ", '" & Edit_U005.Text & "'"
                strSQL += ", '" & Edit012.Text & "'"
                If Date003.Number <> 0 Then strSQL += ", '" & Date003.Text & "'" Else strSQL += ", NULL"
                If Date015.Number <> 0 Then strSQL += ", '" & Date015.Text & "'" Else strSQL += ", NULL"
                If Date007.Number <> 0 Then strSQL += ", '" & Date007.Text & "'" Else strSQL += ", NULL"
                If Date008.Number <> 0 Then strSQL += ", '" & Date008.Text & "'" Else strSQL += ", NULL"
                strSQL += ", " & Wk_TAX & ""
                strSQL += ", 0, 0"
                strSQL += ", '" & Edit014.Text & "'"
                strSQL += ", '" & Edit015.Text & "'"
                strSQL += ", '" & Edit_U006.Text & "'"
                If CkBox01_Y.Checked = True Then
                    strSQL += ", 1)"
                Else
                    If CkBox01_N.Checked = True Then
                        strSQL += ", 0)"
                    Else
                        strSQL += ", NULL)"
                    End If
                End If

                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                DB_CLOSE()
                Call QA_started_flg_ON(Edit000.Text)    'Q&A 着手済フラグ更新
                DB_OPEN("nMVAR")

                '付属品
                seq = 0
                For i = 0 To Line_No
                    If chkBox(i, 1).Checked = True Then
                        seq = seq + 1

                        strSQL = "INSERT INTO T02_ATCH_ITEM"
                        strSQL += " (rcpt_no, seq, item_code, item_name, amnt, item_unit)"
                        strSQL += " VALUES ('" & Edit000.Text & "'"
                        strSQL += ", " & seq
                        If label(i, 1).Text <> Nothing Then strSQL += ", " & label(i, 1).Text Else strSQL += ", NULL"
                        strSQL += ", '" & edit(i, 1).Text & "'"
                        strSQL += ", " & nbrBox(i, 1).Value
                        strSQL += ", '" & edit(i, 2).Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                    End If
                Next

                'コメント
                seq = 0
                For i = 0 To Line_No2
                    If cmbBo_2(i, 1).Text <> Nothing Then
                        seq = seq + 1

                        strSQL = "INSERT INTO T03_REP_CMNT"
                        strSQL += " (rcpt_no, kbn, seq, cls_code1, cmnt_code1)"
                        strSQL += " VALUES ('" & Edit000.Text & "'"
                        strSQL += ", '1'"
                        strSQL += ", " & seq
                        strSQL += ", '01'"
                        strSQL += ", '" & label_2(i, 1).Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                    End If
                Next

                DB_CLOSE()
                add_hsty(Edit000.Text, "新規登録", "", "")

                PRT_PRAM1 = "Print_R_Azukari_Sheet" 'お預かりシート印刷
                PRT_PRAM2 = Edit000.Text
                Dim F70_Form01 As New F70_Form01
                F70_Form01.ShowDialog()

                msg.Text = "登録しました。"
                Button1.Text = "次の登録"
            End If
        Else    '次の登録
            DspSet()    '**  画面セット
        End If
skp:
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.ResultStringEventArgs) Handles Furigana.ResultString
        ' 取得したふりがなを表示します。
        If Edit005.ReadOnly = False Then
            Edit006.Text += e.ReadString
        End If
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
    '**  ケア情報印刷
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        PRT_PRAM1 = "Print_R_QGCare" 'ケア情報印刷
        PRT_PRAM2 = Edit011.Text
        PRT_PRAM3 = Edit000.Text
        Dim F70_Form01 As New F70_Form01
        F70_Form01.ShowDialog()

        If P_RTN = "1" Then msg.Text = "ケア情報を印刷しました"
    End Sub

    '********************************************************************
    '**  複製
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        PRT_PRAM1 = Nothing

        Dim F00_Form18 As New F00_Form18
        F00_Form18.ShowDialog()

        If PRT_PRAM1 <> Nothing Then
            Call DspSet()

            WK_DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_T01_REP_MTR_U", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
            Pram1.Value = PRT_PRAM1
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(WK_DsList1, "T01_REP_MTR_U")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR_U"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                If Not IsDBNull(WK_DtView1(0)("tel1")) Then Edit007.Text = WK_DtView1(0)("tel1") Else Edit007.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("tel2")) Then Edit008.Text = WK_DtView1(0)("tel2") Else Edit008.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("user_name")) Then Edit005.Text = WK_DtView1(0)("user_name") Else Edit005.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("user_name_kana")) Then Edit006.Text = WK_DtView1(0)("user_name_kana") Else Edit006.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("zip")) Then Mask1.Value = WK_DtView1(0)("zip") Else Mask1.Value = Nothing
                If Not IsDBNull(WK_DtView1(0)("adrs1")) Then Edit009.Text = WK_DtView1(0)("adrs1") Else Edit009.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("adrs2")) Then Edit010.Text = WK_DtView1(0)("adrs2") Else Edit010.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("email")) Then Edit016.Text = WK_DtView1(0)("email") Else Edit016.Text = Nothing

                If Not IsDBNull(WK_DtView1(0)("rpar_cls")) Then CL004.Text = WK_DtView1(0)("rpar_cls") Else CL004.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("rpar_cls_name")) Then Combo004.Text = WK_DtView1(0)("rpar_cls_name") Else Combo004.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("acdt_stts")) Then CL005.Text = WK_DtView1(0)("acdt_stts") Else CL005.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("acdt_name")) Then Combo005.Text = WK_DtView1(0)("acdt_name") Else Combo005.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("orgnl_vndr_code")) Then Edit012.Text = WK_DtView1(0)("orgnl_vndr_code") Else Edit012.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("recv_amnt")) Then Number002.Value = WK_DtView1(0)("recv_amnt") Else Number002.Value = 0
                If Not IsDBNull(WK_DtView1(0)("defe_cls")) Then CL006.Text = WK_DtView1(0)("defe_cls") Else CL006.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("defe_name")) Then Combo006.Text = WK_DtView1(0)("defe_name") Else Combo006.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("reference_no")) Then Edit014.Text = WK_DtView1(0)("reference_no") Else Edit014.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("imv_rcpt_no")) Then Edit015.Text = WK_DtView1(0)("imv_rcpt_no") Else Edit015.Text = Nothing

                If Not IsDBNull(WK_DtView1(0)("vndr_code")) Then CLU001.Text = WK_DtView1(0)("vndr_code") Else CLU001.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("vndr_name")) Then Combo_U001.Text = WK_DtView1(0)("vndr_name") Else Combo_U001.Text = Nothing

                If Not IsDBNull(WK_DtView1(0)("model_2")) Then Edit_U001.Text = WK_DtView1(0)("model_2") Else Edit_U001.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("model_1")) Then Edit_U002.Text = WK_DtView1(0)("model_1") Else Edit_U002.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("s_n")) Then Edit_U003.Text = WK_DtView1(0)("s_n") : brk02.Text = Edit_U003.Text Else Edit_U003.Text = Nothing : brk02.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("rpar_comp_code")) Then CLU002.Text = WK_DtView1(0)("rpar_comp_code") Else CLU002.Text = Nothing
                rpar_comp() '**  修理部署ＳＥＴ
                If Not IsDBNull(WK_DtView1(0)("rpar_comp_name")) Then Combo_U002.Text = WK_DtView1(0)("rpar_comp_name") Else Combo_U002.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("sb_imei_old")) Then Edit_U006.Text = WK_DtView1(0)("sb_imei_old") Else Edit_U006.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("vndr_wrn_date")) Then Date_U002.Text = WK_DtView1(0)("vndr_wrn_date") Else Date_U002.Text = Nothing
                If Not IsDBNull(WK_DtView1(0)("vndr_wrn_end_date")) Then Date_U004.Text = WK_DtView1(0)("vndr_wrn_end_date") Else Date_U004.Text = Nothing
                If WK_DtView1(0)("vndr_wrn_date_chk") = "1" Then CheckBox_U002.Checked = True Else CheckBox_U002.Checked = False
            End If
        End If

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
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub

    Private Sub CheckBox_U001_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_U001.CheckedChanged
        If CheckBox_U003.Visible = False Then
            CheckBox_U003.Checked = CheckBox_U001.Checked
        End If
    End Sub

    Private Sub CkBox01_Y_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_Y.CheckedChanged
        If CkBox01_Y.Checked = True Then
            CkBox01_N.Checked = False
        End If
    End Sub

    Private Sub CkBox01_N_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkBox01_N.CheckedChanged
        If CkBox01_N.Checked = True Then
            CkBox01_Y.Checked = False
        End If
    End Sub
End Class