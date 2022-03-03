Imports GrapeCity.Win.Input

Public Class F50_Form07_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, DsCMB3, DsCMB4, DsCMB5, DsCMB6, DsCMB7 As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView
    Dim WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, Err_F, CSR_POS As String
    Dim i, r, chg_itm As Integer
    Dim M_CLS As String = "M08"
    Dim WK_str, WK_str2 As String

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.Furigana = Me.Edit001.Ime

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
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton101 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton102 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Mask
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridEx2 As nMVAR.DataGridEx
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents CL004 As System.Windows.Forms.Label
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Combo004 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Edit008 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit007 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit008_N As System.Windows.Forms.Label
    Friend WithEvents Edit007_N As System.Windows.Forms.Label
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents RadioButton031 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton032 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton023 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton021 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton022 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton011 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton012 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton013 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton041 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton042 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton092 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton093 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton091 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton051 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton052 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton071 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton072 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton061 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton062 As System.Windows.Forms.RadioButton
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Edit
    Friend WithEvents CheckBox002 As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label009 As System.Windows.Forms.Label
    Friend WithEvents Label008 As System.Windows.Forms.Label
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Label003 As System.Windows.Forms.Label
    Friend WithEvents Label002 As System.Windows.Forms.Label
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents Number004 As GrapeCity.Win.Input.Number
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Number006 As GrapeCity.Win.Input.Number
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Number005 As GrapeCity.Win.Input.Number
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button_S1 As System.Windows.Forms.Button
    Friend WithEvents Button_S2 As System.Windows.Forms.Button
    Friend WithEvents CheckBox003 As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Combo005 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CL005 As System.Windows.Forms.Label
    Friend WithEvents CheckBox004 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox005 As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Edit012 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit011 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Label012 As System.Windows.Forms.Label
    Friend WithEvents Button_S5 As System.Windows.Forms.Button
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CL006 As System.Windows.Forms.Label
    Friend WithEvents Combo007 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CL007 As System.Windows.Forms.Label
    Friend WithEvents Edit013 As GrapeCity.Win.Input.Edit
    Friend WithEvents Mask2 As GrapeCity.Win.Input.Mask
    Friend WithEvents Button_S6 As System.Windows.Forms.Button
    Friend WithEvents Edit015 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit014 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label02_2 As System.Windows.Forms.Label
    Friend WithEvents Label013 As System.Windows.Forms.Label
    Friend WithEvents Label014 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label26 = New System.Windows.Forms.Label
        Me.RadioButton092 = New System.Windows.Forms.RadioButton
        Me.RadioButton093 = New System.Windows.Forms.RadioButton
        Me.RadioButton091 = New System.Windows.Forms.RadioButton
        Me.Label41 = New System.Windows.Forms.Label
        Me.Edit008 = New GrapeCity.Win.Input.Edit
        Me.Edit008_N = New System.Windows.Forms.Label
        Me.Edit007 = New GrapeCity.Win.Input.Edit
        Me.Edit007_N = New System.Windows.Forms.Label
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Edit009 = New GrapeCity.Win.Input.Edit
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Panel16 = New System.Windows.Forms.Panel
        Me.RadioButton031 = New System.Windows.Forms.RadioButton
        Me.RadioButton032 = New System.Windows.Forms.RadioButton
        Me.Panel13 = New System.Windows.Forms.Panel
        Me.RadioButton023 = New System.Windows.Forms.RadioButton
        Me.RadioButton021 = New System.Windows.Forms.RadioButton
        Me.RadioButton022 = New System.Windows.Forms.RadioButton
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.RadioButton101 = New System.Windows.Forms.RadioButton
        Me.RadioButton102 = New System.Windows.Forms.RadioButton
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.RadioButton051 = New System.Windows.Forms.RadioButton
        Me.RadioButton052 = New System.Windows.Forms.RadioButton
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.Edit006 = New GrapeCity.Win.Input.Edit
        Me.Edit005 = New GrapeCity.Win.Input.Edit
        Me.Edit004 = New GrapeCity.Win.Input.Edit
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Mask1 = New GrapeCity.Win.Input.Mask
        Me.Edit002 = New GrapeCity.Win.Input.Edit
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label009 = New System.Windows.Forms.Label
        Me.Label01 = New System.Windows.Forms.Label
        Me.Label008 = New System.Windows.Forms.Label
        Me.Label007 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label003 = New System.Windows.Forms.Label
        Me.Label002 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButton011 = New System.Windows.Forms.RadioButton
        Me.RadioButton012 = New System.Windows.Forms.RadioButton
        Me.RadioButton013 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.RadioButton041 = New System.Windows.Forms.RadioButton
        Me.RadioButton042 = New System.Windows.Forms.RadioButton
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.RadioButton071 = New System.Windows.Forms.RadioButton
        Me.RadioButton072 = New System.Windows.Forms.RadioButton
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.RadioButton061 = New System.Windows.Forms.RadioButton
        Me.RadioButton062 = New System.Windows.Forms.RadioButton
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridEx2 = New nMVAR.DataGridEx
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Edit010 = New GrapeCity.Win.Input.Edit
        Me.Label010 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Combo004 = New GrapeCity.Win.Input.Combo
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.CL003 = New System.Windows.Forms.Label
        Me.CL004 = New System.Windows.Forms.Label
        Me.Edit000 = New GrapeCity.Win.Input.Edit
        Me.CheckBox002 = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label02_2 = New System.Windows.Forms.Label
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Label2 = New System.Windows.Forms.Label
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.Label3 = New System.Windows.Forms.Label
        Me.Number004 = New GrapeCity.Win.Input.Number
        Me.Label5 = New System.Windows.Forms.Label
        Me.Number006 = New GrapeCity.Win.Input.Number
        Me.Label6 = New System.Windows.Forms.Label
        Me.Number005 = New GrapeCity.Win.Input.Number
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button_S1 = New System.Windows.Forms.Button
        Me.Button_S2 = New System.Windows.Forms.Button
        Me.CheckBox003 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Combo005 = New GrapeCity.Win.Input.Combo
        Me.Label10 = New System.Windows.Forms.Label
        Me.CL005 = New System.Windows.Forms.Label
        Me.CheckBox004 = New System.Windows.Forms.CheckBox
        Me.CheckBox005 = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Edit012 = New GrapeCity.Win.Input.Edit
        Me.Edit011 = New GrapeCity.Win.Input.Edit
        Me.Label012 = New System.Windows.Forms.Label
        Me.Label011 = New System.Windows.Forms.Label
        Me.Button_S5 = New System.Windows.Forms.Button
        Me.Combo006 = New GrapeCity.Win.Input.Combo
        Me.Label14 = New System.Windows.Forms.Label
        Me.CL006 = New System.Windows.Forms.Label
        Me.Combo007 = New GrapeCity.Win.Input.Combo
        Me.Label15 = New System.Windows.Forms.Label
        Me.CL007 = New System.Windows.Forms.Label
        Me.Edit013 = New GrapeCity.Win.Input.Edit
        Me.Label013 = New System.Windows.Forms.Label
        Me.Button_S6 = New System.Windows.Forms.Button
        Me.Edit015 = New GrapeCity.Win.Input.Edit
        Me.Edit014 = New GrapeCity.Win.Input.Edit
        Me.Mask2 = New GrapeCity.Win.Input.Mask
        Me.Label014 = New System.Windows.Forms.Label
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(16, 208)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(108, 20)
        Me.Label26.TabIndex = 1134
        Me.Label26.Text = "報告書用修理会社"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton092
        '
        Me.RadioButton092.Checked = True
        Me.RadioButton092.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton092.Name = "RadioButton092"
        Me.RadioButton092.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton092.TabIndex = 1
        Me.RadioButton092.TabStop = True
        Me.RadioButton092.Text = "通常"
        '
        'RadioButton093
        '
        Me.RadioButton093.Location = New System.Drawing.Point(132, 0)
        Me.RadioButton093.Name = "RadioButton093"
        Me.RadioButton093.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton093.TabIndex = 2
        Me.RadioButton093.Text = "ﾁｪｰﾝ"
        '
        'RadioButton091
        '
        Me.RadioButton091.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton091.Name = "RadioButton091"
        Me.RadioButton091.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton091.TabIndex = 0
        Me.RadioButton091.Text = "しない"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Navy
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(328, 348)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(108, 20)
        Me.Label41.TabIndex = 1113
        Me.Label41.Text = "納品書パターン"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit008
        '
        Me.Edit008.AllowSpace = False
        Me.Edit008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit008.Format = "9"
        Me.Edit008.HighlightText = True
        Me.Edit008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit008.LengthAsByte = True
        Me.Edit008.Location = New System.Drawing.Point(124, 136)
        Me.Edit008.MaxLength = 4
        Me.Edit008.Name = "Edit008"
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(52, 20)
        Me.Edit008.TabIndex = 11
        Me.Edit008.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit008.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit008_N
        '
        Me.Edit008_N.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit008_N.Location = New System.Drawing.Point(208, 140)
        Me.Edit008_N.Name = "Edit008_N"
        Me.Edit008_N.Size = New System.Drawing.Size(224, 16)
        Me.Edit008_N.TabIndex = 1097
        Me.Edit008_N.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit007
        '
        Me.Edit007.AllowSpace = False
        Me.Edit007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit007.Format = "9"
        Me.Edit007.HighlightText = True
        Me.Edit007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit007.LengthAsByte = True
        Me.Edit007.Location = New System.Drawing.Point(124, 112)
        Me.Edit007.MaxLength = 4
        Me.Edit007.Name = "Edit007"
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(52, 20)
        Me.Edit007.TabIndex = 10
        Me.Edit007.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit007_N
        '
        Me.Edit007_N.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit007_N.Location = New System.Drawing.Point(208, 116)
        Me.Edit007_N.Name = "Edit007_N"
        Me.Edit007_N.Size = New System.Drawing.Size(224, 16)
        Me.Edit007_N.TabIndex = 1096
        Me.Edit007_N.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date001
        '
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("HH:mm", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("HH:mm", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(308, 184)
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(40, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 15
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date001.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2006, 7, 14, 0, 0, 24, 0))
        Me.Date001.Visible = False
        '
        'Edit009
        '
        Me.Edit009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit009.HighlightText = True
        Me.Edit009.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit009.LengthAsByte = True
        Me.Edit009.Location = New System.Drawing.Point(124, 160)
        Me.Edit009.MaxLength = 10
        Me.Edit009.Name = "Edit009"
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(88, 20)
        Me.Edit009.TabIndex = 12
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(128, 492)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(32, 20)
        Me.CheckBox001.TabIndex = 45
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.RadioButton031)
        Me.Panel16.Controls.Add(Me.RadioButton032)
        Me.Panel16.Location = New System.Drawing.Point(720, 276)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(128, 20)
        Me.Panel16.TabIndex = 29
        '
        'RadioButton031
        '
        Me.RadioButton031.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton031.Name = "RadioButton031"
        Me.RadioButton031.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton031.TabIndex = 0
        Me.RadioButton031.Text = "しない"
        '
        'RadioButton032
        '
        Me.RadioButton032.Checked = True
        Me.RadioButton032.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton032.Name = "RadioButton032"
        Me.RadioButton032.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton032.TabIndex = 1
        Me.RadioButton032.TabStop = True
        Me.RadioButton032.Text = "する"
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.RadioButton023)
        Me.Panel13.Controls.Add(Me.RadioButton021)
        Me.Panel13.Controls.Add(Me.RadioButton022)
        Me.Panel13.Location = New System.Drawing.Point(124, 276)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(196, 20)
        Me.Panel13.TabIndex = 27
        '
        'RadioButton023
        '
        Me.RadioButton023.Location = New System.Drawing.Point(132, 0)
        Me.RadioButton023.Name = "RadioButton023"
        Me.RadioButton023.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton023.TabIndex = 2
        Me.RadioButton023.Text = "TEL"
        '
        'RadioButton021
        '
        Me.RadioButton021.Checked = True
        Me.RadioButton021.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton021.Name = "RadioButton021"
        Me.RadioButton021.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton021.TabIndex = 0
        Me.RadioButton021.TabStop = True
        Me.RadioButton021.Text = "印刷"
        '
        'RadioButton022
        '
        Me.RadioButton022.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton022.Name = "RadioButton022"
        Me.RadioButton022.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton022.TabIndex = 1
        Me.RadioButton022.Text = "FAX"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.RadioButton101)
        Me.Panel10.Controls.Add(Me.RadioButton102)
        Me.Panel10.Location = New System.Drawing.Point(124, 372)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(136, 20)
        Me.Panel10.TabIndex = 38
        '
        'RadioButton101
        '
        Me.RadioButton101.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton101.Name = "RadioButton101"
        Me.RadioButton101.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton101.TabIndex = 0
        Me.RadioButton101.Text = "しない"
        '
        'RadioButton102
        '
        Me.RadioButton102.Checked = True
        Me.RadioButton102.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton102.Name = "RadioButton102"
        Me.RadioButton102.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton102.TabIndex = 1
        Me.RadioButton102.TabStop = True
        Me.RadioButton102.Text = "印刷"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.RadioButton051)
        Me.Panel8.Controls.Add(Me.RadioButton052)
        Me.Panel8.Location = New System.Drawing.Point(720, 300)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(128, 20)
        Me.Panel8.TabIndex = 32
        '
        'RadioButton051
        '
        Me.RadioButton051.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton051.Name = "RadioButton051"
        Me.RadioButton051.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton051.TabIndex = 0
        Me.RadioButton051.Text = "しない"
        '
        'RadioButton052
        '
        Me.RadioButton052.Checked = True
        Me.RadioButton052.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton052.Name = "RadioButton052"
        Me.RadioButton052.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton052.TabIndex = 1
        Me.RadioButton052.TabStop = True
        Me.RadioButton052.Text = "する"
        '
        'Number001
        '
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#0", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Format = New GrapeCity.Win.Input.NumberFormat("#0", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(308, 160)
        Me.Number001.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(40, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 14
        Me.Number001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = Nothing
        '
        'Edit006
        '
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.Format = "9#"
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(852, 88)
        Me.Edit006.MaxLength = 14
        Me.Edit006.Name = "Edit006"
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(116, 20)
        Me.Edit006.TabIndex = 9
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit005
        '
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.Format = "9#"
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(852, 68)
        Me.Edit005.MaxLength = 14
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(116, 20)
        Me.Edit005.TabIndex = 8
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit004
        '
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(532, 88)
        Me.Edit004.MaxLength = 40
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(228, 20)
        Me.Edit004.TabIndex = 7
        Me.Edit004.Text = "ああああああああああああああああああああ"
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit003
        '
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(532, 68)
        Me.Edit003.MaxLength = 40
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(228, 20)
        Me.Edit003.TabIndex = 6
        Me.Edit003.Text = "ああああああああああああああああああああ"
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Mask1
        '
        Me.Mask1.Format = New GrapeCity.Win.Input.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(452, 68)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(76, 20)
        Me.Mask1.TabIndex = 5
        Me.Mask1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Mask1.Value = ""
        '
        'Edit002
        '
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(124, 88)
        Me.Edit002.MaxLength = 20
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(228, 20)
        Me.Edit002.TabIndex = 4
        Me.Edit002.Text = "ｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱｱ"
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit001
        '
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(124, 68)
        Me.Edit001.MaxLength = 40
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(228, 20)
        Me.Edit001.TabIndex = 3
        Me.Edit001.Text = "ああああああああああああああああああああ"
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(900, 16)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(80, 20)
        Me.Label001.TabIndex = 1094
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(16, 492)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(108, 20)
        Me.Label52.TabIndex = 1092
        Me.Label52.Text = "削除フラグ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(812, 16)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 20)
        Me.Label51.TabIndex = 1091
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label009
        '
        Me.Label009.BackColor = System.Drawing.Color.Navy
        Me.Label009.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label009.ForeColor = System.Drawing.Color.White
        Me.Label009.Location = New System.Drawing.Point(16, 160)
        Me.Label009.Name = "Label009"
        Me.Label009.Size = New System.Drawing.Size(108, 20)
        Me.Label009.TabIndex = 1089
        Me.Label009.Text = "店舗コード"
        Me.Label009.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.Navy
        Me.Label01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label01.ForeColor = System.Drawing.Color.White
        Me.Label01.Location = New System.Drawing.Point(216, 184)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(92, 20)
        Me.Label01.TabIndex = 1088
        Me.Label01.Text = "FAX送信時刻"
        Me.Label01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label01.Visible = False
        '
        'Label008
        '
        Me.Label008.BackColor = System.Drawing.Color.Navy
        Me.Label008.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label008.ForeColor = System.Drawing.Color.White
        Me.Label008.Location = New System.Drawing.Point(16, 136)
        Me.Label008.Name = "Label008"
        Me.Label008.Size = New System.Drawing.Size(108, 20)
        Me.Label008.TabIndex = 1084
        Me.Label008.Text = "請求先"
        Me.Label008.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(16, 112)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(108, 20)
        Me.Label007.TabIndex = 1083
        Me.Label007.Text = "納入先"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(596, 276)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(124, 20)
        Me.Label35.TabIndex = 1079
        Me.Label35.Text = "見積書部品代出力"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(16, 276)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(108, 20)
        Me.Label30.TabIndex = 1078
        Me.Label30.Text = "見積書発行"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(16, 348)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(108, 20)
        Me.Label25.TabIndex = 1075
        Me.Label25.Text = "納品書発行"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(16, 372)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 20)
        Me.Label24.TabIndex = 1074
        Me.Label24.Text = "請求書発行"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(596, 300)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 20)
        Me.Label22.TabIndex = 1072
        Me.Label22.Text = "修理票部品代出力"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Navy
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(596, 324)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 20)
        Me.Label21.TabIndex = 1070
        Me.Label21.Text = "修理票送料以下出力"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(328, 324)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 20)
        Me.Label20.TabIndex = 1069
        Me.Label20.Text = "修理票金額出力"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(16, 300)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 20)
        Me.Label19.TabIndex = 1068
        Me.Label19.Text = "修理票発行"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(16, 420)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 20)
        Me.Label17.TabIndex = 1066
        Me.Label17.Text = "修理票保証期間"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.Navy
        Me.Label02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label02.ForeColor = System.Drawing.Color.White
        Me.Label02.Location = New System.Drawing.Point(216, 160)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(92, 20)
        Me.Label02.TabIndex = 1061
        Me.Label02.Text = "締日"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(436, 208)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 20)
        Me.Label9.TabIndex = 1060
        Me.Label9.Text = "消費税計算区分"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label006
        '
        Me.Label006.BackColor = System.Drawing.Color.Navy
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.ForeColor = System.Drawing.Color.White
        Me.Label006.Location = New System.Drawing.Point(764, 88)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(96, 20)
        Me.Label006.TabIndex = 1058
        Me.Label006.Text = "ＦＡＸ"
        Me.Label006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label005
        '
        Me.Label005.BackColor = System.Drawing.Color.Navy
        Me.Label005.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label005.ForeColor = System.Drawing.Color.White
        Me.Label005.Location = New System.Drawing.Point(764, 68)
        Me.Label005.Name = "Label005"
        Me.Label005.Size = New System.Drawing.Size(96, 20)
        Me.Label005.TabIndex = 1057
        Me.Label005.Text = "電話番号"
        Me.Label005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BackColor = System.Drawing.Color.Navy
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.ForeColor = System.Drawing.Color.White
        Me.Label004.Location = New System.Drawing.Point(356, 68)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(96, 20)
        Me.Label004.TabIndex = 1056
        Me.Label004.Text = "住所"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 20)
        Me.Label4.TabIndex = 1055
        Me.Label4.Text = "ｸﾞﾙｰﾌﾟ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label003
        '
        Me.Label003.BackColor = System.Drawing.Color.Navy
        Me.Label003.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label003.ForeColor = System.Drawing.Color.White
        Me.Label003.Location = New System.Drawing.Point(16, 88)
        Me.Label003.Name = "Label003"
        Me.Label003.Size = New System.Drawing.Size(108, 20)
        Me.Label003.TabIndex = 1054
        Me.Label003.Text = "（ｶﾅ）"
        Me.Label003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label002
        '
        Me.Label002.BackColor = System.Drawing.Color.Navy
        Me.Label002.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label002.ForeColor = System.Drawing.Color.White
        Me.Label002.Location = New System.Drawing.Point(16, 68)
        Me.Label002.Name = "Label002"
        Me.Label002.Size = New System.Drawing.Size(108, 20)
        Me.Label002.TabIndex = 1052
        Me.Label002.Text = "販社名（漢字）"
        Me.Label002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton011)
        Me.Panel2.Controls.Add(Me.RadioButton012)
        Me.Panel2.Controls.Add(Me.RadioButton013)
        Me.Panel2.Location = New System.Drawing.Point(532, 208)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(228, 20)
        Me.Panel2.TabIndex = 22
        '
        'RadioButton011
        '
        Me.RadioButton011.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton011.Name = "RadioButton011"
        Me.RadioButton011.Size = New System.Drawing.Size(72, 20)
        Me.RadioButton011.TabIndex = 0
        Me.RadioButton011.Text = "四捨五入"
        '
        'RadioButton012
        '
        Me.RadioButton012.Checked = True
        Me.RadioButton012.Location = New System.Drawing.Point(84, 0)
        Me.RadioButton012.Name = "RadioButton012"
        Me.RadioButton012.Size = New System.Drawing.Size(64, 20)
        Me.RadioButton012.TabIndex = 1
        Me.RadioButton012.TabStop = True
        Me.RadioButton012.Text = "切捨て"
        '
        'RadioButton013
        '
        Me.RadioButton013.Location = New System.Drawing.Point(156, 0)
        Me.RadioButton013.Name = "RadioButton013"
        Me.RadioButton013.Size = New System.Drawing.Size(64, 20)
        Me.RadioButton013.TabIndex = 2
        Me.RadioButton013.Text = "切上げ"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 1053
        Me.Label1.Text = "販社ｺｰﾄﾞ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.RadioButton041)
        Me.Panel5.Controls.Add(Me.RadioButton042)
        Me.Panel5.Location = New System.Drawing.Point(124, 300)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(196, 20)
        Me.Panel5.TabIndex = 30
        '
        'RadioButton041
        '
        Me.RadioButton041.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton041.Name = "RadioButton041"
        Me.RadioButton041.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton041.TabIndex = 0
        Me.RadioButton041.Text = "しない"
        '
        'RadioButton042
        '
        Me.RadioButton042.Checked = True
        Me.RadioButton042.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton042.Name = "RadioButton042"
        Me.RadioButton042.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton042.TabIndex = 1
        Me.RadioButton042.TabStop = True
        Me.RadioButton042.Text = "する"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.RadioButton071)
        Me.Panel6.Controls.Add(Me.RadioButton072)
        Me.Panel6.Location = New System.Drawing.Point(436, 324)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(156, 20)
        Me.Panel6.TabIndex = 33
        '
        'RadioButton071
        '
        Me.RadioButton071.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton071.Name = "RadioButton071"
        Me.RadioButton071.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton071.TabIndex = 0
        Me.RadioButton071.Text = "しない"
        '
        'RadioButton072
        '
        Me.RadioButton072.Checked = True
        Me.RadioButton072.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton072.Name = "RadioButton072"
        Me.RadioButton072.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton072.TabIndex = 1
        Me.RadioButton072.TabStop = True
        Me.RadioButton072.Text = "する"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.RadioButton061)
        Me.Panel7.Controls.Add(Me.RadioButton062)
        Me.Panel7.Location = New System.Drawing.Point(720, 324)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(128, 20)
        Me.Panel7.TabIndex = 34
        '
        'RadioButton061
        '
        Me.RadioButton061.Location = New System.Drawing.Point(4, 0)
        Me.RadioButton061.Name = "RadioButton061"
        Me.RadioButton061.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton061.TabIndex = 0
        Me.RadioButton061.Text = "しない"
        '
        'RadioButton062
        '
        Me.RadioButton062.Checked = True
        Me.RadioButton062.Location = New System.Drawing.Point(68, 0)
        Me.RadioButton062.Name = "RadioButton062"
        Me.RadioButton062.Size = New System.Drawing.Size(56, 20)
        Me.RadioButton062.TabIndex = 1
        Me.RadioButton062.TabStop = True
        Me.RadioButton062.Text = "する"
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.RadioButton091)
        Me.Panel11.Controls.Add(Me.RadioButton092)
        Me.Panel11.Controls.Add(Me.RadioButton093)
        Me.Panel11.Location = New System.Drawing.Point(124, 348)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(196, 20)
        Me.Panel11.TabIndex = 35
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(824, 656)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 24)
        Me.Button80.TabIndex = 49
        Me.Button80.Text = "履歴"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(908, 656)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 50
        Me.Button98.Text = "戻る"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 632)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(960, 20)
        Me.msg.TabIndex = 1230
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(924, 252)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(56, 20)
        Me.CL002.TabIndex = 1234
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(924, 228)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(56, 20)
        Me.CL001.TabIndex = 1233
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(124, 44)
        Me.Combo001.MaxDropDownItems = 45
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(228, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo002.Location = New System.Drawing.Point(124, 208)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(312, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 21
        Me.Combo002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo002.Value = "Combo002"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 656)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "更新"
        '
        'DataGridEx2
        '
        Me.DataGridEx2.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGridEx2.CaptionText = "部品掛率"
        Me.DataGridEx2.DataMember = ""
        Me.DataGridEx2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx2.Location = New System.Drawing.Point(620, 396)
        Me.DataGridEx2.Name = "DataGridEx2"
        Me.DataGridEx2.ReadOnly = True
        Me.DataGridEx2.Size = New System.Drawing.Size(352, 236)
        Me.DataGridEx2.TabIndex = 47
        Me.DataGridEx2.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DataGridEx2
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "M31_PART_RATE"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "ﾒｰｶｰｺｰﾄﾞ"
        Me.DataGridTextBoxColumn4.MappingName = "vndr_code"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 70
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "メーカー名"
        Me.DataGridTextBoxColumn5.MappingName = "name"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 150
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "設定済"
        Me.DataGridTextBoxColumn6.MappingName = "sumi"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 60
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGridEx1.CaptionText = "技術料"
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(264, 396)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(352, 236)
        Me.DataGridEx1.TabIndex = 46
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M30_TECH_AMNT"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "ﾒｰｶｰｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.MappingName = "vndr_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 70
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "メーカー名"
        Me.DataGridTextBoxColumn2.MappingName = "name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "設定済"
        Me.DataGridTextBoxColumn3.MappingName = "sumi"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 60
        '
        'Edit010
        '
        Me.Edit010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(124, 184)
        Me.Edit010.MaxLength = 7
        Me.Edit010.Name = "Edit010"
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(88, 20)
        Me.Edit010.TabIndex = 13
        Me.Edit010.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label010
        '
        Me.Label010.BackColor = System.Drawing.Color.Navy
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.ForeColor = System.Drawing.Color.White
        Me.Label010.Location = New System.Drawing.Point(16, 184)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(108, 20)
        Me.Label010.TabIndex = 1239
        Me.Label010.Text = "取引先コード"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(328, 276)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 20)
        Me.Label11.TabIndex = 1241
        Me.Label11.Text = "見積書パターン"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo004
        '
        Me.Combo004.AutoSelect = True
        Me.Combo004.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo004.Location = New System.Drawing.Point(436, 348)
        Me.Combo004.MaxDropDownItems = 20
        Me.Combo004.Name = "Combo004"
        Me.Combo004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo004.Size = New System.Drawing.Size(156, 20)
        Me.Combo004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo004.TabIndex = 36
        Me.Combo004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo004.Value = "Combo004"
        '
        'Combo003
        '
        Me.Combo003.AutoSelect = True
        Me.Combo003.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo003.Location = New System.Drawing.Point(436, 276)
        Me.Combo003.MaxDropDownItems = 20
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(156, 20)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 28
        Me.Combo003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo003.Value = "Combo003"
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(924, 276)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(56, 20)
        Me.CL003.TabIndex = 1245
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'CL004
        '
        Me.CL004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL004.Location = New System.Drawing.Point(924, 300)
        Me.CL004.Name = "CL004"
        Me.CL004.Size = New System.Drawing.Size(56, 20)
        Me.CL004.TabIndex = 1244
        Me.CL004.Text = "CL004"
        Me.CL004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL004.Visible = False
        '
        'Edit000
        '
        Me.Edit000.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit000.Enabled = False
        Me.Edit000.Format = "9"
        Me.Edit000.HighlightText = True
        Me.Edit000.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit000.LengthAsByte = True
        Me.Edit000.Location = New System.Drawing.Point(124, 16)
        Me.Edit000.MaxLength = 4
        Me.Edit000.Name = "Edit000"
        Me.Edit000.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit000.Size = New System.Drawing.Size(52, 20)
        Me.Edit000.TabIndex = 0
        Me.Edit000.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit000.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'CheckBox002
        '
        Me.CheckBox002.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox002.Location = New System.Drawing.Point(456, 44)
        Me.CheckBox002.Name = "CheckBox002"
        Me.CheckBox002.Size = New System.Drawing.Size(32, 20)
        Me.CheckBox002.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(356, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 20)
        Me.Label12.TabIndex = 1248
        Me.Label12.Text = "一般"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label02_2
        '
        Me.Label02_2.Location = New System.Drawing.Point(352, 164)
        Me.Label02_2.Name = "Label02_2"
        Me.Label02_2.Size = New System.Drawing.Size(128, 16)
        Me.Label02_2.TabIndex = 1249
        Me.Label02_2.Text = "（月末は99 不規則は0）"
        Me.Label02_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number002
        '
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number002.Format = New GrapeCity.Win.Input.NumberFormat("###", "", "", "-", "", "", "")
        Me.Number002.HighlightText = True
        Me.Number002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number002.Location = New System.Drawing.Point(124, 420)
        Me.Number002.MaxValue = New Decimal(New Integer() {365, 0, 0, 0})
        Me.Number002.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(40, 20)
        Me.Number002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 42
        Me.Number002.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = Nothing
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(168, 424)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 1251
        Me.Label2.Text = "日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Number003
        '
        Me.Number003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number003.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number003.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number003.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number003.HighlightText = True
        Me.Number003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number003.Location = New System.Drawing.Point(124, 232)
        Me.Number003.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.Number003.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number003.Name = "Number003"
        Me.Number003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number003.Size = New System.Drawing.Size(60, 20)
        Me.Number003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.TabIndex = 23
        Me.Number003.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number003.Value = Nothing
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 20)
        Me.Label3.TabIndex = 1253
        Me.Label3.Text = "技術料掛率"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number004
        '
        Me.Number004.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number004.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number004.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number004.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number004.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number004.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number004.HighlightText = True
        Me.Number004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number004.Location = New System.Drawing.Point(124, 252)
        Me.Number004.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.Number004.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number004.Name = "Number004"
        Me.Number004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number004.Size = New System.Drawing.Size(60, 20)
        Me.Number004.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number004.TabIndex = 24
        Me.Number004.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Number004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number004.Value = Nothing
        Me.Number004.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 1255
        Me.Label5.Text = "部品代掛率"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'Number006
        '
        Me.Number006.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number006.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number006.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number006.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number006.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number006.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number006.HighlightText = True
        Me.Number006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number006.Location = New System.Drawing.Point(288, 252)
        Me.Number006.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.Number006.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number006.Name = "Number006"
        Me.Number006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number006.Size = New System.Drawing.Size(60, 20)
        Me.Number006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number006.TabIndex = 26
        Me.Number006.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Number006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number006.Value = Nothing
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(192, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 20)
        Me.Label6.TabIndex = 1259
        Me.Label6.Text = "部品代マージン率"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number005
        '
        Me.Number005.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number005.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number005.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number005.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number005.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number005.Format = New GrapeCity.Win.Input.NumberFormat("0.00000", "", "", "-", "", "", "")
        Me.Number005.HighlightText = True
        Me.Number005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number005.Location = New System.Drawing.Point(288, 232)
        Me.Number005.MaxValue = New Decimal(New Integer() {999999, 0, 0, 327680})
        Me.Number005.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number005.Name = "Number005"
        Me.Number005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number005.Size = New System.Drawing.Size(60, 20)
        Me.Number005.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number005.TabIndex = 25
        Me.Number005.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Number005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number005.Value = Nothing
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(192, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 20)
        Me.Label7.TabIndex = 1258
        Me.Label7.Text = "技術料マージン率"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_S1
        '
        Me.Button_S1.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S1.Location = New System.Drawing.Point(176, 112)
        Me.Button_S1.Name = "Button_S1"
        Me.Button_S1.Size = New System.Drawing.Size(28, 20)
        Me.Button_S1.TabIndex = 1260
        Me.Button_S1.TabStop = False
        Me.Button_S1.Text = "？"
        '
        'Button_S2
        '
        Me.Button_S2.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S2.Location = New System.Drawing.Point(176, 136)
        Me.Button_S2.Name = "Button_S2"
        Me.Button_S2.Size = New System.Drawing.Size(28, 20)
        Me.Button_S2.TabIndex = 1261
        Me.Button_S2.TabStop = False
        Me.Button_S2.Text = "？"
        '
        'CheckBox003
        '
        Me.CheckBox003.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox003.Location = New System.Drawing.Point(724, 348)
        Me.CheckBox003.Name = "CheckBox003"
        Me.CheckBox003.Size = New System.Drawing.Size(32, 20)
        Me.CheckBox003.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(596, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 20)
        Me.Label8.TabIndex = 1263
        Me.Label8.Text = "ＣＣＡＲ印刷"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo005
        '
        Me.Combo005.AutoSelect = True
        Me.Combo005.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo005.Location = New System.Drawing.Point(436, 300)
        Me.Combo005.MaxDropDownItems = 20
        Me.Combo005.Name = "Combo005"
        Me.Combo005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo005.Size = New System.Drawing.Size(156, 20)
        Me.Combo005.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo005.TabIndex = 31
        Me.Combo005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo005.Value = "Combo005"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(328, 300)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 20)
        Me.Label10.TabIndex = 1265
        Me.Label10.Text = "修理票パターン"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL005
        '
        Me.CL005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL005.Location = New System.Drawing.Point(924, 324)
        Me.CL005.Name = "CL005"
        Me.CL005.Size = New System.Drawing.Size(56, 20)
        Me.CL005.TabIndex = 1266
        Me.CL005.Text = "CL005"
        Me.CL005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL005.Visible = False
        '
        'CheckBox004
        '
        Me.CheckBox004.Location = New System.Drawing.Point(356, 16)
        Me.CheckBox004.Name = "CheckBox004"
        Me.CheckBox004.Size = New System.Drawing.Size(216, 24)
        Me.CheckBox004.TabIndex = 1272
        Me.CheckBox004.TabStop = False
        Me.CheckBox004.Text = "グループ全てに反映する"
        '
        'CheckBox005
        '
        Me.CheckBox005.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox005.Location = New System.Drawing.Point(128, 396)
        Me.CheckBox005.Name = "CheckBox005"
        Me.CheckBox005.Size = New System.Drawing.Size(32, 20)
        Me.CheckBox005.TabIndex = 41
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 396)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 20)
        Me.Label13.TabIndex = 1274
        Me.Label13.Text = "Web Data 作成"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit012
        '
        Me.Edit012.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit012.Format = "9#"
        Me.Edit012.HighlightText = True
        Me.Edit012.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit012.LengthAsByte = True
        Me.Edit012.Location = New System.Drawing.Point(124, 468)
        Me.Edit012.MaxLength = 14
        Me.Edit012.Name = "Edit012"
        Me.Edit012.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit012.Size = New System.Drawing.Size(116, 20)
        Me.Edit012.TabIndex = 44
        Me.Edit012.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit011
        '
        Me.Edit011.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit011.Format = "9#"
        Me.Edit011.HighlightText = True
        Me.Edit011.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit011.LengthAsByte = True
        Me.Edit011.Location = New System.Drawing.Point(124, 444)
        Me.Edit011.MaxLength = 14
        Me.Edit011.Name = "Edit011"
        Me.Edit011.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit011.Size = New System.Drawing.Size(116, 20)
        Me.Edit011.TabIndex = 43
        Me.Edit011.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label012
        '
        Me.Label012.BackColor = System.Drawing.Color.Navy
        Me.Label012.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label012.ForeColor = System.Drawing.Color.White
        Me.Label012.Location = New System.Drawing.Point(16, 468)
        Me.Label012.Name = "Label012"
        Me.Label012.Size = New System.Drawing.Size(108, 20)
        Me.Label012.TabIndex = 1278
        Me.Label012.Text = "ｻﾎﾟｰﾄ専用FAX"
        Me.Label012.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label011
        '
        Me.Label011.BackColor = System.Drawing.Color.Navy
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.ForeColor = System.Drawing.Color.White
        Me.Label011.Location = New System.Drawing.Point(16, 444)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(108, 20)
        Me.Label011.TabIndex = 1277
        Me.Label011.Text = "ｻﾎﾟｰﾄ専用TEL"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_S5
        '
        Me.Button_S5.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S5.Location = New System.Drawing.Point(460, 88)
        Me.Button_S5.Name = "Button_S5"
        Me.Button_S5.Size = New System.Drawing.Size(64, 20)
        Me.Button_S5.TabIndex = 6
        Me.Button_S5.Text = "〒→住所"
        '
        'Combo006
        '
        Me.Combo006.AutoSelect = True
        Me.Combo006.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo006.Location = New System.Drawing.Point(436, 372)
        Me.Combo006.MaxDropDownItems = 20
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(156, 20)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 39
        Me.Combo006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo006.Value = "Combo006"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(328, 372)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 20)
        Me.Label14.TabIndex = 1280
        Me.Label14.Text = "請求書パターン"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL006
        '
        Me.CL006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL006.Location = New System.Drawing.Point(924, 348)
        Me.CL006.Name = "CL006"
        Me.CL006.Size = New System.Drawing.Size(56, 20)
        Me.CL006.TabIndex = 1281
        Me.CL006.Text = "CL006"
        Me.CL006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL006.Visible = False
        '
        'Combo007
        '
        Me.Combo007.AutoSelect = True
        Me.Combo007.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo007.Location = New System.Drawing.Point(720, 372)
        Me.Combo007.MaxDropDownItems = 20
        Me.Combo007.Name = "Combo007"
        Me.Combo007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo007.Size = New System.Drawing.Size(156, 20)
        Me.Combo007.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo007.TabIndex = 40
        Me.Combo007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo007.Value = "Combo007"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(596, 372)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 1283
        Me.Label15.Text = "請求明細表パターン"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL007
        '
        Me.CL007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL007.Location = New System.Drawing.Point(924, 372)
        Me.CL007.Name = "CL007"
        Me.CL007.Size = New System.Drawing.Size(56, 20)
        Me.CL007.TabIndex = 1284
        Me.CL007.Text = "CL007"
        Me.CL007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL007.Visible = False
        '
        'Edit013
        '
        Me.Edit013.BackColor = System.Drawing.Color.White
        Me.Edit013.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit013.HighlightText = True
        Me.Edit013.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit013.LengthAsByte = True
        Me.Edit013.Location = New System.Drawing.Point(628, 112)
        Me.Edit013.MaxLength = 40
        Me.Edit013.Name = "Edit013"
        Me.Edit013.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit013.Size = New System.Drawing.Size(260, 20)
        Me.Edit013.TabIndex = 16
        Me.Edit013.Text = "ああああああああああああああああああああ"
        Me.Edit013.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label013
        '
        Me.Label013.BackColor = System.Drawing.Color.Navy
        Me.Label013.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label013.ForeColor = System.Drawing.Color.White
        Me.Label013.Location = New System.Drawing.Point(532, 112)
        Me.Label013.Name = "Label013"
        Me.Label013.Size = New System.Drawing.Size(96, 20)
        Me.Label013.TabIndex = 1286
        Me.Label013.Text = "請求先名"
        Me.Label013.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_S6
        '
        Me.Button_S6.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S6.Location = New System.Drawing.Point(708, 136)
        Me.Button_S6.Name = "Button_S6"
        Me.Button_S6.Size = New System.Drawing.Size(96, 20)
        Me.Button_S6.TabIndex = 18
        Me.Button_S6.Text = "〒→住所"
        '
        'Edit015
        '
        Me.Edit015.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit015.HighlightText = True
        Me.Edit015.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit015.LengthAsByte = True
        Me.Edit015.Location = New System.Drawing.Point(628, 184)
        Me.Edit015.MaxLength = 40
        Me.Edit015.Name = "Edit015"
        Me.Edit015.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit015.Size = New System.Drawing.Size(340, 20)
        Me.Edit015.TabIndex = 20
        Me.Edit015.Text = "ああああああああああああああああああああ"
        Me.Edit015.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit014
        '
        Me.Edit014.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit014.HighlightText = True
        Me.Edit014.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit014.LengthAsByte = True
        Me.Edit014.Location = New System.Drawing.Point(628, 160)
        Me.Edit014.MaxLength = 40
        Me.Edit014.Name = "Edit014"
        Me.Edit014.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit014.Size = New System.Drawing.Size(340, 20)
        Me.Edit014.TabIndex = 19
        Me.Edit014.Text = "ああああああああああああああああああああ"
        Me.Edit014.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Mask2
        '
        Me.Mask2.Format = New GrapeCity.Win.Input.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask2.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Mask2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask2.Location = New System.Drawing.Point(628, 136)
        Me.Mask2.Name = "Mask2"
        Me.Mask2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Mask2.Size = New System.Drawing.Size(108, 20)
        Me.Mask2.TabIndex = 17
        Me.Mask2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Mask2.Value = ""
        '
        'Label014
        '
        Me.Label014.BackColor = System.Drawing.Color.Navy
        Me.Label014.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label014.ForeColor = System.Drawing.Color.White
        Me.Label014.Location = New System.Drawing.Point(532, 136)
        Me.Label014.Name = "Label014"
        Me.Label014.Size = New System.Drawing.Size(96, 68)
        Me.Label014.TabIndex = 1291
        Me.Label014.Text = "請求先住所"
        Me.Label014.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F50_Form07_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(990, 688)
        Me.Controls.Add(Me.Button_S6)
        Me.Controls.Add(Me.Edit015)
        Me.Controls.Add(Me.Edit014)
        Me.Controls.Add(Me.Mask2)
        Me.Controls.Add(Me.Label014)
        Me.Controls.Add(Me.Label013)
        Me.Controls.Add(Me.Edit013)
        Me.Controls.Add(Me.CL007)
        Me.Controls.Add(Me.Combo007)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CL006)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button_S5)
        Me.Controls.Add(Me.Edit012)
        Me.Controls.Add(Me.Edit011)
        Me.Controls.Add(Me.Label012)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.CheckBox005)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CheckBox004)
        Me.Controls.Add(Me.CL005)
        Me.Controls.Add(Me.Combo005)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CheckBox003)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button_S2)
        Me.Controls.Add(Me.Button_S1)
        Me.Controls.Add(Me.Number006)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Number005)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Number004)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.Label02_2)
        Me.Controls.Add(Me.CheckBox002)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Edit000)
        Me.Controls.Add(Me.CL003)
        Me.Controls.Add(Me.CL004)
        Me.Controls.Add(Me.Combo003)
        Me.Controls.Add(Me.Combo004)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Edit010)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.DataGridEx2)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Edit008)
        Me.Controls.Add(Me.Edit008_N)
        Me.Controls.Add(Me.Edit007)
        Me.Controls.Add(Me.Edit007_N)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Edit009)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Edit006)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Mask1)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label009)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.Label008)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel11)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form07_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "販社マスタ"
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit012, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit011, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit013, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit015, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit014, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form06_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        CmbSet()    '**  コンボボックスセット
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN = "0"
        msg.Text = Nothing
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='507'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "2"
                CheckBox001.Enabled = False
                Button1.Enabled = False
            Case Is = "3"
                CheckBox001.Enabled = False
                Button1.Enabled = True
            Case Is = "4"
                CheckBox001.Enabled = True
                Button1.Enabled = True
        End Select
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("nMVAR")

        'グループ
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '006') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_006")

        Combo001.DataSource = DsCMB.Tables("CLS_CODE_006")
        Combo001.DisplayMember = "cls_code_name"
        Combo001.ValueMember = "cls_code"

        '代行修理会社
        strSQL = "SELECT sub_code, sub_code + ':' + name AS name"
        strSQL +=  " FROM M09_SUB_OWN"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M09_SUB_OWN")

        Combo002.DataSource = DsCMB.Tables("M09_SUB_OWN")
        Combo002.DisplayMember = "name"
        Combo002.ValueMember = "sub_code"

        DsCMB7.Clear()
        '請求明細表パターン
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '032') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB7, "CLS_CODE_032")

        Combo007.DataSource = DsCMB7.Tables("CLS_CODE_032")
        Combo007.DisplayMember = "cls_code_name"
        Combo007.ValueMember = "cls_code"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        If P_PRAM8 = Nothing Then   '新規
            Button1.Text = "登録"
            Button80.Enabled = False
            Combo001.Text = Nothing
            Combo002.Text = Nothing
            Combo003.Text = Nothing
            Combo004.Text = Nothing
            Combo005.Text = Nothing
            Combo006.Text = Nothing
            Combo007.Text = Nothing
            Edit000.Text = Nothing : Edit000.Enabled = True
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
            Edit014.Text = Nothing
            Edit015.Text = Nothing
            Mask1.Text = Nothing
            Mask2.Text = Nothing
            Date001.Text = Nothing
            Number001.Value = 0
            Number002.Value = 0
            Number003.Value = 0
            Number004.Value = 0
            Number005.Value = 0
            Number006.Value = 0

            CheckBox001.Checked = False
            CheckBox002.Checked = False
            CheckBox003.Checked = False
            CheckBox004.Checked = False : CheckBox004.Visible = False
            CheckBox005.Checked = False
            Label001.Text = Nothing
            Edit007_N.Text = Nothing
            Edit008_N.Text = Nothing

        Else                        '修正
            Button1.Text = "更新"
            Button80.Enabled = True
            DsList1.Clear()

            SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE_2", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
            Pram1.Value = P_PRAM8
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "M08_STORE")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

            End If
            Edit000.Text = DtView1(0)("store_code") : Edit000.Enabled = False
            CL001.Text = DtView1(0)("grup_code")
            Combo001.Text = DtView1(0)("grup_name")
            CL002.Text = DtView1(0)("sub_code")
            Combo002.Text = DtView1(0)("sub_name")
            CL003.Text = DtView1(0)("price_rprt_ptn")
            If Not IsDBNull(DtView1(0)("price_rprt_ptn_name")) Then Combo003.Text = DtView1(0)("price_rprt_ptn_name")
            If Not IsDBNull(DtView1(0)("rpr_rprt_ptn")) Then CL005.Text = DtView1(0)("rpr_rprt_ptn")
            If Not IsDBNull(DtView1(0)("rpr_rprt_ptn_name")) Then Combo005.Text = DtView1(0)("rpr_rprt_ptn_name")
            Edit001.Text = DtView1(0)("name")
            Edit002.Text = DtView1(0)("name_kana")
            If Not IsDBNull(DtView1(0)("zip")) Then Mask1.Value = DtView1(0)("zip") Else Mask1.Text = Nothing
            Edit003.Text = DtView1(0)("adrs1")
            Edit004.Text = DtView1(0)("adrs2")
            Edit005.Text = DtView1(0)("tel")
            Edit006.Text = DtView1(0)("fax")
            Edit007.Text = DtView1(0)("dlvr_code")
            Edit008.Text = DtView1(0)("invc_code")
            Edit009.Text = DtView1(0)("cust_code")
            Edit010.Text = DtView1(0)("client_code")
            If Not IsDBNull(DtView1(0)("print_tel")) Then Edit011.Text = DtView1(0)("print_tel") Else Edit011.Text = Nothing
            If Not IsDBNull(DtView1(0)("print_fax")) Then Edit012.Text = DtView1(0)("print_fax") Else Edit012.Text = Nothing
            If Not IsDBNull(DtView1(0)("invc_prt_name")) Then Edit013.Text = DtView1(0)("invc_prt_name") Else Edit013.Text = Nothing
            If Not IsDBNull(DtView1(0)("invc_zip")) Then Mask2.Value = DtView1(0)("invc_zip") Else Mask2.Text = Nothing
            If Not IsDBNull(DtView1(0)("invc_adrs1")) Then Edit014.Text = DtView1(0)("invc_adrs1") Else Edit014.Text = Nothing
            If Not IsDBNull(DtView1(0)("invc_adrs2")) Then Edit015.Text = DtView1(0)("invc_adrs2") Else Edit015.Text = Nothing
            If Not IsDBNull(DtView1(0)("fax_snd_time")) Then
                Dim WK As String = DtView1(0)("fax_snd_time")
                If Len(WK) = 10 Then
                    Date001.Text = "00:00"
                Else
                    Date001.Text = Mid(DtView1(0)("fax_snd_time"), 12, 5)
                End If
            Else
                Date001.Text = Nothing
            End If
            Number001.Value = DtView1(0)("cls_date")
            Number003.Value = DtView1(0)("tech_rate")
            Number004.Value = DtView1(0)("part_rate")
            Number005.Value = DtView1(0)("tech_mrgn_rate")
            Number006.Value = DtView1(0)("part_mrgn_rate")

            Edit007_N.Text = DtView1(0)("dlvr_name")
            Edit008_N.Text = DtView1(0)("invc_name")

            Select Case DtView1(0)("calc_cls")
                Case Is = "0"
                    RadioButton011.Checked = True
                Case Is = "1"
                    RadioButton012.Checked = True
                Case Is = "2"
                    RadioButton013.Checked = True
            End Select
            Select Case DtView1(0)("price_rprt_cls")
                Case Is = "0"
                    RadioButton021.Checked = True
                Case Is = "1"
                    RadioButton022.Checked = True
                Case Is = "2"
                    RadioButton023.Checked = True
            End Select
            If DtView1(0)("price_rprt_part_flg") = "0" Then RadioButton031.Checked = True Else RadioButton032.Checked = True
            If DtView1(0)("rpr_rprt_flg") = "0" Then RadioButton041.Checked = True Else RadioButton042.Checked = True
            If DtView1(0)("rpr_rprt_part_flg") = "0" Then RadioButton051.Checked = True Else RadioButton052.Checked = True
            If DtView1(0)("rpr_rprt_dvl_flg") = "0" Then RadioButton061.Checked = True Else RadioButton062.Checked = True
            If DtView1(0)("rpr_rprt_amnt_flg") = "0" Then RadioButton071.Checked = True Else RadioButton072.Checked = True
            Select Case DtView1(0)("dlvr_rprt_cls")
                Case Is = "0"
                    RadioButton091.Checked = True
                    Combo004.Text = Nothing
                Case Is = "1"
                    RadioButton092.Checked = True
                    If Not IsDBNull(DtView1(0)("dlvr_rprt_ptn_name")) Then Combo004.Text = DtView1(0)("dlvr_rprt_ptn_name")
                Case Is = "2"
                    RadioButton093.Checked = True
                    If Not IsDBNull(DtView1(0)("dlvr_rprt_ptn_name2")) Then Combo004.Text = DtView1(0)("dlvr_rprt_ptn_name2")
            End Select
            CL004.Text = DtView1(0)("dlvr_rprt_ptn")

            If DtView1(0)("invc_rprt_flg") = "0" Then
                RadioButton101.Checked = True
                Combo006.Text = Nothing
                Combo007.Text = Nothing
            Else
                RadioButton102.Checked = True
                If Not IsDBNull(DtView1(0)("invc_rprt_ptn_name")) Then Combo006.Text = DtView1(0)("invc_rprt_ptn_name")
                If Not IsDBNull(DtView1(0)("invc_dtl_ptn_name")) Then Combo007.Text = DtView1(0)("invc_dtl_ptn_name") Else Combo007.Text = Nothing
            End If
            Number002.Value = DtView1(0)("wrn_period")

            If DtView1(0)("idvd_flg") = "1" Then
                CheckBox002.Checked = True
            Else
                CheckBox002.Checked = False
            End If
            If DtView1(0)("ccar_flg") = "1" Then
                CheckBox003.Checked = True
            Else
                CheckBox003.Checked = False
            End If
            If DtView1(0)("web_flg") = "1" Then
                CheckBox005.Checked = True
            Else
                CheckBox005.Checked = False
            End If
            If DtView1(0)("delt_flg") = "1" Then
                CheckBox001.Checked = True
            Else
                CheckBox001.Checked = False
            End If

            Label001.Text = DtView1(0)("reg_date")
        End If

        '技術料マスタ
        SqlCmd1 = New SqlClient.SqlCommand("sp_M30_TECH_AMNT_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
        If P_PRAM8 = Nothing Then   '新規
            Pram2.Value = ""
        Else
            Pram2.Value = P_PRAM8
        End If
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M30_TECH_AMNT")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M30_TECH_AMNT")
        DataGridEx1.DataSource = tbl

        DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "", "", DataViewRowState.CurrentRows)
        If DtView2.Count <> 0 Then
            For i = 0 To DtView2.Count - 1
                If IsDBNull(DtView2(i)("sumi")) Then
                    DtView2(i)("sumi") = ""
                Else
                    DtView2(i)("sumi") = "済"
                End If
            Next
        End If

        '部品掛率マスタ
        SqlCmd1 = New SqlClient.SqlCommand("sp_M31_PART_RATE_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M31_PART_RATE")
        DB_CLOSE()

        Dim tbl2 As New DataTable
        tbl2 = DsList1.Tables("M31_PART_RATE")
        DataGridEx2.DataSource = tbl2

        DtView3 = New DataView(DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
        If DtView3.Count <> 0 Then
            For i = 0 To DtView3.Count - 1

                WK_DsList1.Clear()
                strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM8 & "') AND (vndr_code = '" & DtView3(i)("vndr_code") & "') AND (strt_amnt = 1))"
                strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    DtView3(i)("sumi") = "済"
                Else
                    DtView3(i)("sumi") = ""
                End If
            Next
        End If
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGridEx1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　エンター
    '********************************************************************
    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView2.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    If P_PRAM8 = Nothing Then   '新規
                        Dim ANS As String
                        ANS = MessageBox.Show("販社マスタの登録を行います。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        If ANS = "1" Then   'OK
                            F_Check()   '**  項目チェック
                            If Err_F = "0" Then
                                Add_STORE()
                                Cursor = System.Windows.Forms.Cursors.WaitCursor
                                P_PRAM2 = Edit000.Text
                                P_PRAM3 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                                Dim F50_Form50 As New F50_Form50
                                F50_Form50.ShowDialog()
                                If P_RTN2 = "1" Then '**  画面セット
                                    WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "vndr_code ='" & P_PRAM3 & "'", "", DataViewRowState.CurrentRows)
                                    If WK_DtView2.Count <> 0 Then
                                        WK_DtView2(0)("sumi") = "済"
                                    End If
                                End If
                                Cursor = System.Windows.Forms.Cursors.Default
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        Cursor = System.Windows.Forms.Cursors.WaitCursor
                        P_PRAM2 = Edit000.Text
                        P_PRAM3 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                        Dim F50_Form50 As New F50_Form50
                        F50_Form50.ShowDialog()
                        If P_RTN2 = "1" Then '**  画面セット
                            WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "vndr_code ='" & P_PRAM3 & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView2.Count <> 0 Then
                                WK_DtView2(0)("sumi") = "済"
                            End If
                        End If
                        Cursor = System.Windows.Forms.Cursors.Default
                    End If
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                If P_PRAM8 = Nothing Then   '新規
                    Dim ANS As String
                    ANS = MessageBox.Show("販社マスタの登録を行います。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If ANS = "1" Then   'OK
                        F_Check()   '**  項目チェック
                        If Err_F = "0" Then
                            Add_STORE()
                            Cursor = System.Windows.Forms.Cursors.WaitCursor
                            P_PRAM2 = Edit000.Text
                            P_PRAM3 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                            Dim F50_Form50 As New F50_Form50
                            F50_Form50.ShowDialog()
                            If P_RTN2 = "1" Then '**  画面セット
                                WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "vndr_code ='" & P_PRAM3 & "'", "", DataViewRowState.CurrentRows)
                                If WK_DtView2.Count <> 0 Then
                                    WK_DtView2(0)("sumi") = "済"
                                End If
                            End If
                            Cursor = System.Windows.Forms.Cursors.Default
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    P_PRAM2 = Edit000.Text
                    P_PRAM3 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                    Dim F50_Form50 As New F50_Form50
                    F50_Form50.ShowDialog()
                    If P_RTN2 = "1" Then '**  画面セット
                        WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "vndr_code ='" & P_PRAM3 & "'", "", DataViewRowState.CurrentRows)
                        If WK_DtView2.Count <> 0 Then
                            WK_DtView2(0)("sumi") = "済"
                        End If
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGridEx2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx2.Paint
        If DataGridEx2.CurrentRowIndex >= 0 Then
            DataGridEx2.Select(DataGridEx2.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　エンター
    '********************************************************************
    Private Sub DataGridEx2_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx2.CmdKeyEvent
        If DataGridEx2.CurrentRowIndex <= DtView3.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    If P_PRAM8 = Nothing Then   '新規
                        Dim ANS As String
                        ANS = MessageBox.Show("販社マスタの登録を行います。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        If ANS = "1" Then   'OK
                            F_Check()   '**  項目チェック
                            If Err_F = "0" Then
                                Add_STORE()
                                Cursor = System.Windows.Forms.Cursors.WaitCursor
                                P_PRAM2 = Edit000.Text
                                P_PRAM3 = DataGridEx2(DataGridEx2.CurrentRowIndex, 0)
                                Dim F50_Form51 As New F50_Form51
                                F50_Form51.ShowDialog()
                                If P_RTN2 = "1" Then '**  画面セット
                                    WK_DsList1.Clear()
                                    strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                                    strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                                    strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                                    strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                                    strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                                    strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                                    strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                                    strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    DaList1.SelectCommand = SqlCmd1
                                    DB_OPEN("nMVAR")
                                    SqlCmd1.CommandTimeout = 600
                                    DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                                    DB_CLOSE()

                                    WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                                    If WK_DtView1.Count = 0 Then
                                        DataGridEx2(DataGridEx2.CurrentRowIndex, 2) = "済"
                                    End If
                                End If
                                Cursor = System.Windows.Forms.Cursors.Default
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        Cursor = System.Windows.Forms.Cursors.WaitCursor
                        P_PRAM2 = Edit000.Text
                        P_PRAM3 = DataGridEx2(DataGridEx2.CurrentRowIndex, 0)
                        Dim F50_Form51 As New F50_Form51
                        F50_Form51.ShowDialog()
                        If P_RTN2 = "1" Then '**  画面セット
                            WK_DsList1.Clear()
                            strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                            strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                            strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                            strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                            strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                            strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                            strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                            strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("nMVAR")
                            SqlCmd1.CommandTimeout = 600
                            DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                            DB_CLOSE()

                            WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count = 0 Then
                                DataGridEx2(DataGridEx2.CurrentRowIndex, 2) = "済"
                            End If
                        End If
                        Cursor = System.Windows.Forms.Cursors.Default
                    End If
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGridEx2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx2.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                If P_PRAM8 = Nothing Then   '新規
                    Dim ANS As String
                    ANS = MessageBox.Show("販社マスタの登録を行います。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If ANS = "1" Then   'OK
                        F_Check()   '**  項目チェック
                        If Err_F = "0" Then
                            Add_STORE()
                            Cursor = System.Windows.Forms.Cursors.WaitCursor
                            P_PRAM2 = Edit000.Text
                            P_PRAM3 = DataGridEx2(DataGridEx2.CurrentRowIndex, 0)
                            Dim F50_Form51 As New F50_Form51
                            F50_Form51.ShowDialog()
                            If P_RTN2 = "1" Then '**  画面セット
                                WK_DsList1.Clear()
                                strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                                strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                                strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                                strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                                strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                                strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                                strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                                strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("nMVAR")
                                SqlCmd1.CommandTimeout = 600
                                DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                                DB_CLOSE()

                                WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                                If WK_DtView1.Count = 0 Then
                                    DataGridEx2(DataGridEx2.CurrentRowIndex, 2) = "済"
                                End If
                            End If
                            Cursor = System.Windows.Forms.Cursors.Default
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    P_PRAM2 = Edit000.Text
                    P_PRAM3 = DataGridEx2(DataGridEx2.CurrentRowIndex, 0)
                    Dim F50_Form51 As New F50_Form51
                    F50_Form51.ShowDialog()
                    If P_RTN2 = "1" Then '**  画面セット
                        WK_DsList1.Clear()
                        strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                        strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                        strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                        strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                        strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                        strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                        strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                        strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                        DB_CLOSE()

                        WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count = 0 Then
                            DataGridEx2(DataGridEx2.CurrentRowIndex, 2) = "済"
                        End If
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Combo001()   'ｸﾞﾙｰﾌﾟ
        msg.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            Combo001.BackColor = System.Drawing.Color.Red
            msg.Text = "ｸﾞﾙｰﾌﾟが入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_006"), "cls_code_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当するｸﾞﾙｰﾌﾟがありません。"
                Exit Sub
            Else
                CL001.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit000()   '販社コード
        msg.Text = Nothing
        If P_PRAM8 = Nothing Then   '新規
            Edit000.Text = Trim(Edit000.Text)
            If Edit000.Text = Nothing Then
                Edit000.BackColor = System.Drawing.Color.Red
                msg.Text = "販社コードが入力されていません。"
                Exit Sub
            Else
                If Len(Edit000.Text) <> 4 Then
                    Edit000.BackColor = System.Drawing.Color.Red
                    msg.Text = "販社コードは4桁です。"
                    Exit Sub
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT store_code FROM M08_STORE WHERE (store_code = '" & Edit000.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    r = DaList1.Fill(WK_DsList1, "M08_STORE")
                    DB_CLOSE()
                    If r <> 0 Then
                        Edit000.BackColor = System.Drawing.Color.Red
                        msg.Text = "販社コードは既に登録されています。"
                        Exit Sub
                    End If
                End If
            End If
        End If
        Edit000.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit001()   '販社名（漢字）
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "販社名（漢字）が入力されていません。"
            Exit Sub
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit002()   '販社名（カナ）
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "販社名（カナ）が入力されていません。"
            Exit Sub
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Mask1()     '郵便番号
        msg.Text = Nothing

        If Mask1.Visible = True Then
            If Mask1.Value = Nothing Then
            Else
                If Len(Mask1.Value) <> 7 Then
                    Mask1.BackColor = System.Drawing.Color.Red
                    msg.Text = "郵便番号は7桁入力してください。"
                    Exit Sub
                End If
            End If
        Else
            Mask1.Value = Nothing
        End If
        Mask1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit003()   '住所1
        msg.Text = Nothing

        If Edit003.Visible = True Then
            Edit003.Text = Trim(Edit003.Text)
        Else
            Edit003.Text = Nothing
        End If
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit004()   '住所2
        msg.Text = Nothing

        If Edit004.Visible = True Then
            Edit004.Text = Trim(Edit004.Text)
        Else
            Edit004.Text = Nothing
        End If
        Edit004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit005()   'TEL
        msg.Text = Nothing

        If Edit005.Visible = True Then
            Edit005.Text = Trim(Edit005.Text)
        Else
            Edit005.Text = Nothing
        End If
        Edit005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit006()   'FAX
        msg.Text = Nothing

        If Edit006.Visible = True Then
            Edit006.Text = Trim(Edit006.Text)
            If RadioButton022.Checked = True Then
                If Edit006.Text = Nothing Then
                    Edit006.BackColor = System.Drawing.Color.Red
                    msg.Text = "見積書がFAX送信の場合、FAX番号を入力してください。"
                    Exit Sub
                End If
            End If
        Else
            Edit006.Text = Nothing
        End If
        Edit006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit007()   '納入先
        msg.Text = Nothing

        If Edit007.Visible = True Then
            Edit007_N.Text = Nothing
            Edit007.Text = Trim(Edit007.Text)
            If Edit007.Text = Nothing Then
                'Edit007.BackColor = System.Drawing.Color.Red
                'msg.Text = "納入先が入力されていません。"
                'Exit Sub
            Else
                If Edit007.Text = Edit000.Text Then
                    Edit007_N.Text = Edit001.Text
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT M08_STORE.store_code, M08_STORE.name, M08_STORE.dlvr_rprt_cls, M08_STORE.dlvr_rprt_ptn"
                    strSQL +=  ", V_cls_015.cls_code_name AS dlvr_rprt_name, V_cls_021.cls_code_name AS dlvr_rprt_name_c"
                    strSQL +=  ", M08_STORE.dlvr_code"
                    strSQL +=  " FROM M08_STORE LEFT OUTER JOIN"
                    strSQL +=  " V_cls_021 ON M08_STORE.dlvr_rprt_ptn = V_cls_021.cls_code LEFT OUTER JOIN"
                    strSQL +=  " V_cls_015 ON M08_STORE.dlvr_rprt_ptn = V_cls_015.cls_code"
                    strSQL +=  " WHERE (M08_STORE.store_code = '" & Edit007.Text & "')"
                    strSQL +=  " AND (M08_STORE.delt_flg = 0)"
                    If CheckBox002.Checked = True Then
                        strSQL +=  " AND (M08_STORE.idvd_flg = 1)"
                    Else
                        strSQL +=  " AND (M08_STORE.idvd_flg = 0)"
                    End If
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(WK_DsList1, "M08_STORE")
                    DB_CLOSE()

                    WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count = 0 Then
                        Edit007.BackColor = System.Drawing.Color.Red
                        msg.Text = "該当する納入先がありません。"
                        Exit Sub
                    Else
                        Edit007_N.Text = WK_DtView1(0)("name")
                        If WK_DtView1(0)("store_code") <> WK_DtView1(0)("dlvr_code") Then
                            Edit007.BackColor = System.Drawing.Color.Red
                            msg.Text = "該当する納入先が別の納品先を指定しています。"
                            Exit Sub
                        Else
                            Select Case WK_DtView1(0)("dlvr_rprt_cls")
                                Case Is = "0"
                                    RadioButton091.Checked = True
                                    Combo004.Text = Nothing
                                Case Is = "1"
                                    RadioButton092.Checked = True
                                    Combo004.Text = WK_DtView1(0)("dlvr_rprt_ptn") & ":" & WK_DtView1(0)("dlvr_rprt_name")
                                Case Is = "2"
                                    RadioButton093.Checked = True
                                    Combo004.Text = WK_DtView1(0)("dlvr_rprt_ptn") & ":" & WK_DtView1(0)("dlvr_rprt_name_c")
                            End Select
                            CL004.Text = WK_DtView1(0)("dlvr_rprt_ptn")
                        End If
                    End If
                End If
            End If
        Else
            Edit007.Text = Nothing
            Edit007_N.Text = Nothing
        End If
        Edit007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit008()   '請求先
        msg.Text = Nothing

        If Edit008.Visible = True Then
            Edit008_N.Text = Nothing
            Edit008.Text = Trim(Edit008.Text)
            If Edit008.Text = Nothing Then
                'Edit008.BackColor = System.Drawing.Color.Red
                'msg.Text = "請求先が入力されていません。"
                'Exit Sub
            Else
                If Edit008.Text = Edit000.Text Then
                    Edit008_N.Text = Edit001.Text
                Else
                    WK_DsList1.Clear()
                    strSQL = "SELECT M08_STORE.store_code, M08_STORE.name, M08_STORE.cls_date, M08_STORE.invc_rprt_flg"
                    strSQL +=  ", M08_STORE.invc_rprt_ptn, M08_STORE.invc_dtl_ptn, V_cls_030.cls_code_name AS invc_rprt_name"
                    strSQL +=  ", V_cls_032.cls_code_name AS invc_dtl_name, M08_STORE.invc_code"
                    strSQL +=  " FROM M08_STORE LEFT OUTER JOIN"
                    strSQL +=  " V_cls_032 ON M08_STORE.invc_dtl_ptn = V_cls_032.cls_code LEFT OUTER JOIN"
                    strSQL +=  " V_cls_030 ON M08_STORE.invc_rprt_ptn = V_cls_030.cls_code"
                    strSQL +=  " WHERE (M08_STORE.store_code = '" & Edit008.Text & "')"
                    strSQL +=  " AND (M08_STORE.delt_flg = 0)"
                    If CheckBox002.Checked = True Then
                        strSQL +=  " AND (M08_STORE.idvd_flg = 1)"
                    Else
                        strSQL +=  " AND (M08_STORE.idvd_flg = 0)"
                    End If
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(WK_DsList1, "M08_STORE")
                    DB_CLOSE()

                    WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count = 0 Then
                        Edit008.BackColor = System.Drawing.Color.Red
                        msg.Text = "該当する請求先がありません。"
                        Exit Sub
                    Else
                        Edit008_N.Text = WK_DtView1(0)("name")
                        If WK_DtView1(0)("store_code") <> WK_DtView1(0)("invc_code") Then
                            Edit008.BackColor = System.Drawing.Color.Red
                            msg.Text = "該当する請求先が別の請求先を指定しています。"
                            Exit Sub
                        Else
                            Number001.Value = WK_DtView1(0)("cls_date")
                            If WK_DtView1(0)("invc_rprt_flg") = "True" Then
                                RadioButton102.Checked = True
                            Else
                                RadioButton101.Checked = True
                            End If
                            CL006.Text = WK_DtView1(0)("invc_rprt_ptn")
                            Combo006.Text = WK_DtView1(0)("invc_rprt_ptn") & ":" & WK_DtView1(0)("invc_rprt_name")
                            If Not IsDBNull(WK_DtView1(0)("invc_dtl_ptn")) Then CL007.Text = WK_DtView1(0)("invc_dtl_ptn") Else CL007.Text = Nothing
                            If Not IsDBNull(WK_DtView1(0)("invc_dtl_name")) Then Combo007.Text = WK_DtView1(0)("invc_dtl_ptn") & ":" & WK_DtView1(0)("invc_dtl_name") Else Combo007.Text = Nothing
                        End If
                    End If
                End If
            End If
        Else
            Edit008.Text = Nothing
            Edit008_N.Text = Nothing
        End If
        Edit008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit009()   '店舗コード
        msg.Text = Nothing

        If Edit009.Visible = True Then
            Edit009.Text = Trim(Edit009.Text)
        Else
            Edit009.Text = Nothing
        End If
        Edit009.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit010()   '取引先コード
        msg.Text = Nothing

        If Edit010.Visible = True Then
            Edit010.Text = Trim(Edit010.Text)
        Else
            Edit010.Text = Nothing
        End If
        Edit010.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit013()   '請求先名
        msg.Text = Nothing

        If Edit013.Visible = True Then
            Edit013.Text = Trim(Edit013.Text)
            'If Edit013.Text = Nothing Then
            '    Edit013.BackColor = System.Drawing.Color.Red
            '    msg.Text = "請求先名が入力されていません。"
            '    Exit Sub
            'End If
        Else
            Edit013.Text = Nothing
        End If
        Edit013.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Mask2()     '請求先郵便番号
        msg.Text = Nothing

        If Mask2.Visible = True Then
            If Mask2.Value = Nothing Then
            Else
                If Len(Mask2.Value) <> 7 Then
                    Mask2.BackColor = System.Drawing.Color.Red
                    msg.Text = "請求先郵便番号は7桁入力してください。"
                    Exit Sub
                End If
            End If
        Else
            Mask2.Value = Nothing
        End If
        Mask2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit014()   '請求先住所1
        msg.Text = Nothing

        If Edit014.Visible = True Then
            Edit014.Text = Trim(Edit014.Text)
        Else
            Edit014.Text = Nothing
        End If
        Edit014.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit015()   '請求先住所2
        msg.Text = Nothing

        If Edit015.Visible = True Then
            Edit015.Text = Trim(Edit015.Text)
        Else
            Edit015.Text = Nothing
        End If
        Edit015.BackColor = System.Drawing.SystemColors.Window
    End Sub
    'Sub CHK_Edit011()   'ｻﾎﾟｰﾄ専用TEL
    '    msg.Text = Nothing
    '    Edit011.Text = Trim(Edit011.Text)
    '    Edit011.BackColor = System.Drawing.SystemColors.Window
    'End Sub
    'Sub CHK_Edit012()   'ｻﾎﾟｰﾄ専用FAX
    '    msg.Text = Nothing
    '    Edit012.Text = Trim(Edit011.Text)
    '    Edit012.BackColor = System.Drawing.SystemColors.Window
    'End Sub
    Sub CHK_Date001()   'FAX送信時刻
        msg.Text = Nothing
        If Date001.Visible = True Then
            If Date001.Number = 0 Then
                Date001.BackColor = System.Drawing.Color.Red
                msg.Text = "FAX送信時刻が入力されていません。"
                Exit Sub
            End If
        Else
            Date001.Number = 0
        End If
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Number001() '締日
        msg.Text = Nothing

        If Number001.Visible = True Then
            'If Number001.Value = 0 Then
            '    Number001.BackColor = System.Drawing.Color.Red
            '    msg.Text = "締切日が入力されていません。"
            '    Exit Sub
            'End If
            If Number001.Value > 30 And Number001.Value <> 99 Then
                Number001.BackColor = System.Drawing.Color.Red
                msg.Text = "締切日の入力が違います。"
                Exit Sub
            End If
        Else
            Number001.Value = 0
        End If
        Number001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo002()   '報告書用修理会社
        msg.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            Combo002.BackColor = System.Drawing.Color.Red
            msg.Text = "報告書用修理会社社が入力されていません。"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("M09_SUB_OWN"), "name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する報告書用修理会社がありません。"
                Exit Sub
            Else
                CL002.Text = DtView1(0)("sub_code")
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo003()   '見積書パターン
        msg.Text = Nothing

        If RadioButton023.Checked = False Then
            Combo003.Text = Trim(Combo003.Text)
            If Combo003.Text = Nothing Then
                Combo003.BackColor = System.Drawing.Color.Red
                msg.Text = "見積書パターンが入力されていません。"
                Exit Sub
            Else
                DtView1 = New DataView(DsCMB3.Tables("CLS_CODE_014"), "cls_code_name = '" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    Combo003.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当する見積書パターンがありません。"
                    Exit Sub
                Else
                    CL003.Text = DtView1(0)("cls_code")
                End If
            End If
        End If
        Combo003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo004()   '納品書パターン
        msg.Text = Nothing

        If RadioButton091.Checked = False Then
            Combo004.Text = Trim(Combo004.Text)
            If Combo004.Text = Nothing Then
                Combo004.BackColor = System.Drawing.Color.Red
                msg.Text = "納品書パターンが入力されていません。"
                Exit Sub
            Else
                'If RadioButton092.Checked = True Then
                DtView1 = New DataView(DsCMB4.Tables("CLS_CODE_015"), "cls_code_name = '" & Combo004.Text & "'", "", DataViewRowState.CurrentRows)
                'Else
                '    DtView1 = New DataView(DsCMB4.Tables("CLS_CODE_021"), "cls_code_name = '" & Combo004.Text & "'", "", DataViewRowState.CurrentRows)
                'End If
                If DtView1.Count = 0 Then
                    Combo004.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当する納品書パターンがありません。"
                    Exit Sub
                Else
                    CL004.Text = DtView1(0)("cls_code")
                End If
            End If
        End If
        Combo004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo005()   '修理票パターン
        msg.Text = Nothing

        If RadioButton041.Checked = False Then
            Combo005.Text = Trim(Combo005.Text)
            If Combo005.Text = Nothing Then
                Combo005.BackColor = System.Drawing.Color.Red
                msg.Text = "修理票パターンが入力されていません。"
                Exit Sub
            Else
                DtView1 = New DataView(DsCMB5.Tables("CLS_CODE_024"), "cls_code_name = '" & Combo005.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    Combo005.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当する修理票パターンがありません。"
                    Exit Sub
                Else
                    CL005.Text = DtView1(0)("cls_code")
                End If
            End If
        End If
        Combo005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo006()   '請求書パターン
        msg.Text = Nothing

        If RadioButton101.Checked = False Then
            Combo006.Text = Trim(Combo006.Text)
            If Combo006.Text = Nothing Then
                Combo006.BackColor = System.Drawing.Color.Red
                msg.Text = "請求書パターンが入力されていません。"
                Exit Sub
            Else
                DtView1 = New DataView(DsCMB6.Tables("CLS_CODE_030"), "cls_code_name = '" & Combo006.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    Combo006.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当する請求書パターンがありません。"
                    Exit Sub
                Else
                    CL006.Text = DtView1(0)("cls_code")
                End If
            End If
        End If
        Combo006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo007()   '請求明細表パターン
        msg.Text = Nothing

        If RadioButton101.Checked = False Then
            Combo007.Text = Trim(Combo007.Text)
            If Combo007.Text = Nothing Then
                Combo007.BackColor = System.Drawing.Color.Red
                msg.Text = "請求明細表パターンが入力されていません。"
                Exit Sub
            Else
                DtView1 = New DataView(DsCMB7.Tables("CLS_CODE_032"), "cls_code_name = '" & Combo007.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count = 0 Then
                    Combo007.BackColor = System.Drawing.Color.Red
                    msg.Text = "該当する請求明細表パターンがありません。"
                    Exit Sub
                Else
                    CL007.Text = DtView1(0)("cls_code")
                End If
            End If
        End If
        Combo007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        CHK_Edit000()   '販社コード
        If msg.Text <> Nothing Then Err_F = "1" : Edit000.Focus() : Exit Sub

        CHK_Combo001()   'ｸﾞﾙｰﾌﾟ
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Edit001()   '販社名（漢字）
        If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub

        CHK_Edit002()   '販社名（カナ）
        If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub

        CHK_Mask1()     '郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask1.Focus() : Exit Sub

        CHK_Edit003()   '住所1
        If msg.Text <> Nothing Then Err_F = "1" : Edit003.Focus() : Exit Sub

        CHK_Edit004()   '住所2
        If msg.Text <> Nothing Then Err_F = "1" : Edit004.Focus() : Exit Sub

        CHK_Edit005()   'TEL
        If msg.Text <> Nothing Then Err_F = "1" : Edit005.Focus() : Exit Sub

        CHK_Edit006()   'FAX
        If msg.Text <> Nothing Then Err_F = "1" : Edit006.Focus() : Exit Sub

        CHK_Edit007()   '納入先
        If msg.Text <> Nothing Then Err_F = "1" : Edit007.Focus() : Exit Sub

        CHK_Edit008()   '請求先
        If msg.Text <> Nothing Then Err_F = "1" : Edit008.Focus() : Exit Sub

        CHK_Edit009()   '店舗コード
        If msg.Text <> Nothing Then Err_F = "1" : Edit009.Focus() : Exit Sub

        CHK_Edit010()   '取引先コード
        If msg.Text <> Nothing Then Err_F = "1" : Edit010.Focus() : Exit Sub

        CHK_Edit013()   '請求先名
        If msg.Text <> Nothing Then Err_F = "1" : Edit013.Focus() : Exit Sub

        CHK_Mask2()     '請求先郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask2.Focus() : Exit Sub

        CHK_Edit014()   '請求先住所1
        If msg.Text <> Nothing Then Err_F = "1" : Edit014.Focus() : Exit Sub

        CHK_Edit015()   '請求先住所2
        If msg.Text <> Nothing Then Err_F = "1" : Edit015.Focus() : Exit Sub

        CHK_Date001()   'FAX送信時刻
        If msg.Text <> Nothing Then Err_F = "1" : Date001.Focus() : Exit Sub

        CHK_Number001() '締日
        If msg.Text <> Nothing Then Err_F = "1" : Number001.Focus() : Exit Sub

        CHK_Combo002()  '報告書用修理会社
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Combo003()  '見積書パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo003.Focus() : Exit Sub

        CHK_Combo004()  '納品書パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo004.Focus() : Exit Sub

        CHK_Combo005()  '修理票パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo005.Focus() : Exit Sub

        CHK_Combo006()  '請求書パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo006.Focus() : Exit Sub

        CHK_Combo007()  '請求明細表パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo007.Focus() : Exit Sub
    End Sub
    Sub F_Check2()
        Err_F = "0"

        CHK_Combo001()   'ｸﾞﾙｰﾌﾟ
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Edit008()   '請求先
        If msg.Text <> Nothing Then Err_F = "1" : Edit008.Focus() : Exit Sub

        CHK_Edit013()   '請求先名
        If msg.Text <> Nothing Then Err_F = "1" : Edit013.Focus() : Exit Sub

        CHK_Mask2()     '請求先郵便番号
        If msg.Text <> Nothing Then Err_F = "1" : Mask2.Focus() : Exit Sub

        CHK_Edit014()   '請求先住所1
        If msg.Text <> Nothing Then Err_F = "1" : Edit014.Focus() : Exit Sub

        CHK_Edit015()   '請求先住所2
        If msg.Text <> Nothing Then Err_F = "1" : Edit015.Focus() : Exit Sub

        CHK_Edit010()   '取引先コード
        If msg.Text <> Nothing Then Err_F = "1" : Edit010.Focus() : Exit Sub

        CHK_Number001() '締日
        If msg.Text <> Nothing Then Err_F = "1" : Number001.Focus() : Exit Sub

        CHK_Combo002()  '報告書用修理会社
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Combo003()  '見積書パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo003.Focus() : Exit Sub

        CHK_Combo004()  '納品書パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo004.Focus() : Exit Sub

        CHK_Combo005()  '修理票パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo005.Focus() : Exit Sub

        CHK_Combo006()  '請求書パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo006.Focus() : Exit Sub

        CHK_Combo007()  '請求明細表パターン
        If msg.Text <> Nothing Then Err_F = "1" : Combo007.Focus() : Exit Sub
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.GotFocus
        CheckBox002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox003.GotFocus
        CheckBox003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox004.GotFocus
        CheckBox004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox005.GotFocus
        CheckBox005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Edit000_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.GotFocus
        Edit000.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.GotFocus
        Edit002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Edit003.SelectionStart = Len(Edit003.Text)
    End Sub
    Private Sub Edit004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.GotFocus
        Edit004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.GotFocus
        Edit005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub Mask1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.GotFocus
        Mask1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Mask2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask2.GotFocus
        Mask2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001.GotFocus
        Number001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.GotFocus
        Number002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number003.GotFocus
        Number003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number004.GotFocus
        Number004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number005.GotFocus
        Number005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number006.GotFocus
        Number006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton011_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton011.GotFocus
        RadioButton011.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton012_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton012.GotFocus
        RadioButton012.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton013_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton013.GotFocus
        RadioButton013.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton021_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton021.GotFocus
        RadioButton021.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton022_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton022.GotFocus
        RadioButton022.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton023_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton023.GotFocus
        RadioButton023.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton031_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton031.GotFocus
        RadioButton031.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton032_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton032.GotFocus
        RadioButton032.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton041_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton041.GotFocus
        RadioButton041.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton042_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton042.GotFocus
        RadioButton042.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton051_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton051.GotFocus
        RadioButton051.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton052_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton052.GotFocus
        RadioButton052.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton061_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton061.GotFocus
        RadioButton061.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton062_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton062.GotFocus
        RadioButton062.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton071_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton071.GotFocus
        RadioButton071.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton072_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton072.GotFocus
        RadioButton072.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton091_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton091.GotFocus
        RadioButton091.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton092_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton092.GotFocus
        RadioButton092.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton093_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton093.GotFocus
        RadioButton093.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton101_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton101.GotFocus
        RadioButton101.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton102_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton102.GotFocus
        RadioButton102.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        CheckBox001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.LostFocus
        CheckBox002.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox003.LostFocus
        CheckBox003.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox004.LostFocus
        CheckBox004.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox005.LostFocus
        CheckBox005.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   'ｸﾞﾙｰﾌﾟ
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()   '報告書用修理会社
    End Sub
    Private Sub Combo003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.LostFocus
        CHK_Combo003()   '見積書パターン
    End Sub
    Private Sub Combo004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo004.LostFocus
        CHK_Combo004()   '納品書パターン
    End Sub
    Private Sub Combo005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo005.LostFocus
        CHK_Combo005()   '修理票パターン
    End Sub
    Private Sub Combo006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo006.LostFocus
        CHK_Combo006()   '請求書パターン
    End Sub
    Private Sub Combo007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo007.LostFocus
        CHK_Combo007()   '請求明細表パターン
    End Sub
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        CHK_Date001()   'FAX送信時刻
    End Sub
    Private Sub Edit000_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit000.LostFocus
        CHK_Edit000()   '販社コード
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '販社名（漢字）
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        CHK_Edit002()   '販社名（カナ）
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        CHK_Edit003()   '住所1
    End Sub
    Private Sub Edit004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.LostFocus
        CHK_Edit004()   '住所2
    End Sub
    Private Sub Edit005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.LostFocus
        CHK_Edit005()   'TEL
    End Sub
    Private Sub Edit006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.LostFocus
        CHK_Edit006()   'FAX
    End Sub
    Private Sub Edit007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.LostFocus
        CHK_Edit007()   '納入先
    End Sub
    Private Sub Edit008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.LostFocus
        CHK_Edit008()   '請求先
    End Sub
    Private Sub Edit009_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit009.LostFocus
        CHK_Edit009()   '店舗コード
    End Sub
    Private Sub Edit010_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit010.LostFocus
        CHK_Edit010()   '取引先コード
    End Sub
    Private Sub Edit011_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit011.LostFocus
        Edit011.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit012.LostFocus
        Edit012.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit013_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit013.LostFocus
        CHK_Edit013()   '請求先名
    End Sub
    Private Sub Edit014_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit014.LostFocus
        CHK_Edit014()   '請求先住所1
    End Sub
    Private Sub Edit015_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit015.LostFocus
        CHK_Edit015()   '請求先住所2
    End Sub
    Private Sub Mask1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.LostFocus
        CHK_Mask1()     '郵便番号
    End Sub
    Private Sub Mask2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask2.LostFocus
        CHK_Mask2()     '請求先郵便番号
    End Sub
    Private Sub Number001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number001.LostFocus
        CHK_Number001() '締日
    End Sub
    Private Sub Number002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number002.LostFocus
        Number002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number003.LostFocus
        Number003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number004.LostFocus
        Number004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number005.LostFocus
        Number005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number006.LostFocus
        Number006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub RadioButton011_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton011.LostFocus
        RadioButton011.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton012_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton012.LostFocus
        RadioButton012.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton013_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton013.LostFocus
        RadioButton013.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton021_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton021.LostFocus
        RadioButton021.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton022_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton022.LostFocus
        RadioButton022.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton023_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton023.LostFocus
        RadioButton023.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton031_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton031.LostFocus
        RadioButton031.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton032_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton032.LostFocus
        RadioButton032.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton041_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton041.LostFocus
        RadioButton041.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton042_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton042.LostFocus
        RadioButton042.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton051_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton051.LostFocus
        RadioButton051.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton052_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton052.LostFocus
        RadioButton052.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton061_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton061.LostFocus
        RadioButton061.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton062_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton062.LostFocus
        RadioButton062.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton071_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton071.LostFocus
        RadioButton071.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton072_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton072.LostFocus
        RadioButton072.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton091_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton091.LostFocus
        RadioButton091.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton092_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton092.LostFocus
        RadioButton092.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton093_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton093.LostFocus
        RadioButton093.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton101_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton101.LostFocus
        RadioButton101.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton102_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton102.LostFocus
        RadioButton102.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Sub GRP_UPD_ON()
        Edit001.Enabled = False : Edit002.Enabled = False : Edit003.Enabled = False : Edit004.Enabled = False : Edit005.Enabled = False
        Edit006.Enabled = False : Edit007.Enabled = False : Edit009.Enabled = False
        Edit011.Enabled = False : Edit012.Enabled = False
        CheckBox001.Enabled = False : CheckBox002.Enabled = False
        Mask1.Enabled = False
        Button_S1.Enabled = False : Button_S5.Enabled = False
        Number002.Enabled = False
        Date001.Enabled = False
        Panel2.Enabled = False

    End Sub
    Sub GRP_UPD_OFF()
        Edit001.Enabled = True : Edit002.Enabled = True : Edit003.Enabled = True : Edit004.Enabled = True : Edit005.Enabled = True
        Edit006.Enabled = True : Edit007.Enabled = True : Edit009.Enabled = True
        Edit011.Enabled = True : Edit012.Enabled = True
        CheckBox001.Enabled = True : CheckBox002.Enabled = True
        Mask1.Enabled = True
        Button_S1.Enabled = True : Button_S5.Enabled = True
        Number002.Enabled = True
        Date001.Enabled = True
        Panel2.Enabled = True

    End Sub

    '********************************************************************
    '**  CheckedChanged
    '********************************************************************
    Private Sub CheckBox004_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox004.CheckedChanged
        If CheckBox004.Checked = True Then
            GRP_UPD_ON()
        Else
            GRP_UPD_OFF()
        End If
    End Sub
    Private Sub CheckBox002_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.CheckedChanged
        If CheckBox002.Checked = True Then
            Label004.Visible = False : Mask1.Visible = False : Edit003.Visible = False : Edit004.Visible = False
            Label005.Visible = False : Edit005.Visible = False
            Label006.Visible = False : Edit006.Visible = False
            Label007.Visible = False : Edit007.Visible = False : Edit007_N.Visible = False
            Label008.Visible = False : Edit008.Visible = False : Edit008_N.Visible = False
            Label009.Visible = False : Edit009.Visible = False
            Label010.Visible = False : Edit010.Visible = False
            Label011.Visible = False : Edit011.Visible = False
            Label012.Visible = False : Edit012.Visible = False
            Label013.Visible = False : Edit013.Visible = False
            Label014.Visible = False : Mask2.Visible = False : Edit014.Visible = False : Edit015.Visible = False
            Label02.Visible = False : Number001.Visible = False : Label02_2.Visible = False
            RadioButton022.Visible = False
            If RadioButton022.Checked = True Then RadioButton021.Checked = True
            Button_S1.Visible = False : Button_S2.Visible = False : Button_S5.Visible = False : Button_S6.Visible = False
        Else
            Label004.Visible = True : Mask1.Visible = True : Edit003.Visible = True : Edit004.Visible = True
            Label005.Visible = True : Edit005.Visible = True
            Label006.Visible = True : Edit006.Visible = True
            Label007.Visible = True : Edit007.Visible = True : Edit007_N.Visible = True
            Label008.Visible = True : Edit008.Visible = True : Edit008_N.Visible = True
            Label009.Visible = True : Edit009.Visible = True
            Label010.Visible = True : Edit010.Visible = True
            Label011.Visible = True : Edit011.Visible = True
            Label012.Visible = True : Edit012.Visible = True
            Label013.Visible = True : Edit013.Visible = True
            Label014.Visible = True : Mask2.Visible = True : Edit014.Visible = True : Edit015.Visible = True
            Label02.Visible = True : Number001.Visible = True : Label02_2.Visible = True
            RadioButton022.Visible = True
            Button_S1.Visible = True : Button_S2.Visible = True : Button_S5.Visible = True : Button_S6.Visible = True
        End If
    End Sub
    Private Sub RadioButton021_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton021.CheckedChanged
        cmb03_reset()
    End Sub
    Private Sub RadioButton022_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton022.CheckedChanged
        If RadioButton022.Checked = True Then
            Label01.Visible = True : Date001.Visible = True
        Else
            Label01.Visible = False : Date001.Visible = False
        End If
        cmb03_reset()
    End Sub
    Private Sub RadioButton023_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton023.CheckedChanged
        cmb05_reset()
    End Sub
    Private Sub RadioButton041_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton041.CheckedChanged
        cmb05_reset()
    End Sub
    Private Sub RadioButton042_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton042.CheckedChanged
        cmb05_reset()
    End Sub
    Private Sub RadioButton091_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton091.CheckedChanged
        cmb04_reset()
    End Sub
    Private Sub RadioButton092_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton092.CheckedChanged
        cmb04_reset()
    End Sub
    Private Sub RadioButton093_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton093.CheckedChanged
        cmb04_reset()
    End Sub

    Private Sub RadioButton101_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton101.CheckedChanged
        cmb06_reset()
        cmb07_reset()
    End Sub

    Private Sub RadioButton102_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton102.CheckedChanged
        cmb06_reset()
        cmb07_reset()
    End Sub

    Sub cmb03_reset()
        If RadioButton023.Checked = True Then
            Label11.Visible = False : Combo003.Visible = False : Combo003.Text = Nothing : CL003.Text = Nothing
            Label35.Visible = False : Panel16.Visible = False
        Else
            DsCMB3.Clear()
            Label11.Visible = True : Combo003.Visible = True
            Label35.Visible = True : Panel16.Visible = True
            '見積書パターン
            strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
            strSQL +=  " FROM M21_CLS_CODE"
            strSQL +=  " WHERE (cls_no = '014') AND (delt_flg = 0)"
            strSQL +=  " ORDER BY dsp_seq, cls_code"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsCMB3, "CLS_CODE_014")
            DB_CLOSE()
            Combo003.DataSource = DsCMB3.Tables("CLS_CODE_014")
            Combo003.DisplayMember = "cls_code_name"
            Combo003.ValueMember = "cls_code"
        End If
    End Sub

    Sub cmb04_reset()
        If RadioButton091.Checked = True Then
            Label41.Visible = False : Combo004.Visible = False : Combo004.Text = Nothing : CL004.Text = Nothing
        Else
            DsCMB4.Clear()
            DB_OPEN("nMVAR")
            Label41.Visible = True : Combo004.Visible = True
            If RadioButton092.Checked = True Then
                '納品書パターン
                strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
                strSQL +=  " FROM M21_CLS_CODE"
                strSQL +=  " WHERE (cls_no = '015') AND (delt_flg = 0)"
                strSQL +=  " ORDER BY dsp_seq, cls_code"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsCMB4, "CLS_CODE_015")
            Else
                '納品書パターン
                strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
                strSQL +=  " FROM M21_CLS_CODE"
                strSQL +=  " WHERE (cls_no = '021') AND (delt_flg = 0)"
                strSQL +=  " ORDER BY dsp_seq, cls_code"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsCMB4, "CLS_CODE_015")
            End If
            DB_CLOSE()
            Combo004.DataSource = DsCMB4.Tables("CLS_CODE_015")
            Combo004.DisplayMember = "cls_code_name"
            Combo004.ValueMember = "cls_code"
        End If
    End Sub

    Sub cmb05_reset()
        If RadioButton041.Checked = True Then
            Label10.Visible = False : Combo005.Visible = False : Combo005.Text = Nothing : CL005.Text = Nothing
            Label20.Visible = False : Panel6.Visible = False
            Label21.Visible = False : Panel7.Visible = False
            Label22.Visible = False : Panel8.Visible = False
        Else
            DsCMB5.Clear()
            Label10.Visible = True : Combo005.Visible = True
            Label20.Visible = True : Panel6.Visible = True
            Label21.Visible = True : Panel7.Visible = True
            Label22.Visible = True : Panel8.Visible = True
            '修理票パターン
            strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
            strSQL +=  " FROM M21_CLS_CODE"
            strSQL +=  " WHERE (cls_no = '024') AND (delt_flg = 0)"
            strSQL +=  " ORDER BY dsp_seq, cls_code"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsCMB5, "CLS_CODE_024")
            DB_CLOSE()
            Combo005.DataSource = DsCMB5.Tables("CLS_CODE_024")
            Combo005.DisplayMember = "cls_code_name"
            Combo005.ValueMember = "cls_code"
        End If
    End Sub

    Sub cmb06_reset()
        If RadioButton101.Checked = True Then
            Label14.Visible = False : Combo006.Visible = False : Combo006.Text = Nothing : CL006.Text = Nothing
        Else
            DsCMB6.Clear()
            DB_OPEN("nMVAR")
            Label14.Visible = True : Combo006.Visible = True
            '請求書パターン
            strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
            strSQL +=  " FROM M21_CLS_CODE"
            strSQL +=  " WHERE (cls_no = '030') AND (delt_flg = 0)"
            strSQL +=  " ORDER BY dsp_seq, cls_code"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsCMB6, "CLS_CODE_030")
            DB_CLOSE()
            Combo006.DataSource = DsCMB6.Tables("CLS_CODE_030")
            Combo006.DisplayMember = "cls_code_name"
            Combo006.ValueMember = "cls_code"
        End If
    End Sub

    Sub cmb07_reset()
        If RadioButton101.Checked = True Then
            Label15.Visible = False : Combo007.Visible = False : Combo007.Text = Nothing : CL007.Text = Nothing
        Else
            DsCMB7.Clear()
            DB_OPEN("nMVAR")
            Label15.Visible = True : Combo007.Visible = True
            '請求明細表パターン
            strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
            strSQL +=  " FROM M21_CLS_CODE"
            strSQL +=  " WHERE (cls_no = '032') AND (delt_flg = 0)"
            strSQL +=  " ORDER BY dsp_seq, cls_code"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsCMB7, "CLS_CODE_032")
            DB_CLOSE()
            Combo007.DataSource = DsCMB7.Tables("CLS_CODE_032")
            Combo007.DisplayMember = "cls_code_name"
            Combo007.ValueMember = "cls_code"
        End If
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.ResultStringEventArgs) Handles Furigana.ResultString
        ' 取得したふりがなを表示します。
        Edit002.Text += e.ReadString
    End Sub

    '********************************************************************
    '**  変更履歴
    '********************************************************************
    Sub CHG_HSTY()
        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)

        If Combo001.Text <> DtView1(0)("grup_name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "ｸﾞﾙｰﾌﾟ", DtView1(0)("grup_name"), Combo001.Text)
        End If

        If DtView1(0)("idvd_flg") = "1" Then
            If CheckBox002.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "一般", "対象", "対象外")
            End If
        Else
            If CheckBox002.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "一般", "対象外", "対象")
            End If
        End If

        If Edit001.Text <> DtView1(0)("name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "販社名（漢字）", DtView1(0)("name"), Edit001.Text)
        End If

        If Edit002.Text <> DtView1(0)("name_kana") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "販社名（カナ）", DtView1(0)("name_kana"), Edit002.Text)
        End If

        If Not IsDBNull(DtView1(0)("zip")) Then WK_str = Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) Else WK_str = Nothing
        If WK_str = "-" Then WK_str = Nothing
        If Mask1.Value <> Nothing Then WK_str2 = Mid(Mask1.Text, 3, 8) Else WK_str2 = Nothing
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "郵便番号", WK_str, WK_str2)
        End If

        If Edit003.Text <> DtView1(0)("adrs1") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "住所1", DtView1(0)("adrs1"), Edit003.Text)
        End If

        If Edit004.Text <> DtView1(0)("adrs2") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "住所2", DtView1(0)("adrs2"), Edit004.Text)
        End If

        If Edit005.Text <> DtView1(0)("tel") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "電話番号", DtView1(0)("tel"), Edit005.Text)
        End If

        If Edit006.Text <> DtView1(0)("fax") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "ＦＡＸ", DtView1(0)("fax"), Edit006.Text)
        End If

        If Edit007.Text = Nothing Then
            Edit007.Text = Edit000.Text
            Edit007_N.Text = Edit001.Text
        End If
        If Edit007_N.Text <> DtView1(0)("dlvr_name") Or Edit007.Text <> DtView1(0)("dlvr_code") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "納品先", DtView1(0)("dlvr_code") & ":" & DtView1(0)("dlvr_name"), Edit007.Text & ":" & Edit007_N.Text)
        End If

        If Edit008.Text = Nothing Then
            Edit008.Text = Edit000.Text
            Edit008_N.Text = Edit001.Text
        End If
        If Edit008_N.Text <> DtView1(0)("invc_name") Or Edit008.Text <> DtView1(0)("invc_code") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求先", DtView1(0)("invc_code") & ":" & DtView1(0)("invc_name"), Edit008.Text & ":" & Edit008_N.Text)
        End If

        If Not IsDBNull(DtView1(0)("invc_prt_name")) Then WK_str = DtView1(0)("invc_prt_name") Else WK_str = Nothing
        If Edit013.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求先名", WK_str, Edit013.Text)
        End If

        If Not IsDBNull(DtView1(0)("invc_zip")) Then WK_str = Mid(DtView1(0)("invc_zip"), 1, 3) & "-" & Mid(DtView1(0)("invc_zip"), 4, 4) Else WK_str = Nothing
        If WK_str = "-" Then WK_str = Nothing
        If Mask2.Value <> Nothing Then WK_str2 = Mid(Mask2.Text, 3, 8) Else WK_str2 = Nothing
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求先郵便番号", WK_str, WK_str2)
        End If

        If Not IsDBNull(DtView1(0)("invc_adrs1")) Then WK_str = DtView1(0)("invc_adrs1") Else WK_str = Nothing
        If Edit014.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求先住所1", WK_str, Edit014.Text)
        End If

        If Not IsDBNull(DtView1(0)("invc_adrs2")) Then WK_str = DtView1(0)("invc_adrs2") Else WK_str = Nothing
        If Edit015.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求先住所2", WK_str, Edit015.Text)
        End If

        If Edit009.Text <> DtView1(0)("cust_code") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "店舗コード", DtView1(0)("cust_code"), Edit009.Text)
        End If

        If Edit010.Text <> DtView1(0)("client_code") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "取引先コード", DtView1(0)("client_code"), Edit010.Text)
        End If

        If Not IsDBNull(DtView1(0)("fax_snd_time")) Then
            Dim WK As String = DtView1(0)("fax_snd_time")
            If Len(WK) = 10 Then
                WK_str = "00:00"
            Else
                WK_str = Mid(DtView1(0)("fax_snd_time"), 12, 5)
            End If
        Else
            WK_str = "__:__"
        End If
        If Date001.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "FAX送信時刻", WK_str, Date001.Text)
        End If

        If Number001.Value <> DtView1(0)("cls_date") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "締日", DtView1(0)("cls_date"), Number001.Value)
        End If

        If Number003.Value <> DtView1(0)("tech_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "技術料掛率", DtView1(0)("tech_rate"), Number003.Value)
        End If

        If Number004.Value <> DtView1(0)("part_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "部品代掛率", DtView1(0)("part_rate"), Number004.Value)
        End If

        If Number005.Value <> DtView1(0)("tech_mrgn_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "技術料マージン率", DtView1(0)("tech_mrgn_rate"), Number005.Value)
        End If

        If Number006.Value <> DtView1(0)("part_mrgn_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "部品代マージン率", DtView1(0)("part_mrgn_rate"), Number006.Value)
        End If

        If Combo002.Text <> DtView1(0)("sub_name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "報告書用修理会社", DtView1(0)("sub_name"), Combo002.Text)
        End If

        Select Case DtView1(0)("calc_cls")
            Case Is = "0"
                WK_str2 = RadioButton011.Text
            Case Is = "1"
                WK_str2 = RadioButton012.Text
            Case Is = "2"
                WK_str2 = RadioButton013.Text
        End Select
        If RadioButton011.Checked = True Then WK_str = RadioButton011.Text
        If RadioButton012.Checked = True Then WK_str = RadioButton012.Text
        If RadioButton013.Checked = True Then WK_str = RadioButton013.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "消費税計算区分", WK_str2, WK_str)
        End If

        Select Case DtView1(0)("price_rprt_cls")
            Case Is = "0"
                WK_str2 = RadioButton021.Text
            Case Is = "1"
                WK_str2 = RadioButton022.Text
            Case Is = "2"
                WK_str2 = RadioButton023.Text
        End Select
        If RadioButton021.Checked = True Then WK_str = RadioButton021.Text
        If RadioButton022.Checked = True Then WK_str = RadioButton022.Text
        If RadioButton023.Checked = True Then WK_str = RadioButton023.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "見積書発行", WK_str2, WK_str)
        End If

        If Not IsDBNull(DtView1(0)("price_rprt_ptn_name")) Then WK_str = DtView1(0)("price_rprt_ptn_name") Else WK_str = Nothing
        If Combo003.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "見積書パターン", WK_str, Combo003.Text)
        End If

        If DtView1(0)("price_rprt_part_flg") = "0" Then WK_str2 = RadioButton031.Text Else WK_str2 = RadioButton032.Text
        If RadioButton031.Checked = True Then WK_str = RadioButton031.Text Else WK_str = RadioButton032.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "見積書部品代出力", WK_str2, WK_str)
        End If

        If DtView1(0)("rpr_rprt_flg") = "0" Then WK_str2 = RadioButton041.Text Else WK_str2 = RadioButton042.Text
        If RadioButton041.Checked = True Then WK_str = RadioButton041.Text Else WK_str = RadioButton042.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "修理票発行", WK_str2, WK_str)
        End If

        If Not IsDBNull(DtView1(0)("rpr_rprt_ptn_name")) Then WK_str = DtView1(0)("rpr_rprt_ptn_name") Else WK_str = Nothing
        If Combo005.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "修理票パターン", WK_str, Combo005.Text)
        End If

        If DtView1(0)("rpr_rprt_part_flg") = "0" Then WK_str2 = RadioButton051.Text Else WK_str2 = RadioButton052.Text
        If RadioButton051.Checked = True Then WK_str = RadioButton051.Text Else WK_str = RadioButton052.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "修理票部品代出力", WK_str2, WK_str)
        End If

        If DtView1(0)("rpr_rprt_dvl_flg") = "0" Then WK_str2 = RadioButton061.Text Else WK_str2 = RadioButton062.Text
        If RadioButton061.Checked = True Then WK_str = RadioButton061.Text Else WK_str = RadioButton062.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "修理票送料以下出力", WK_str2, WK_str)
        End If

        If DtView1(0)("rpr_rprt_amnt_flg") = "0" Then WK_str2 = RadioButton071.Text Else WK_str2 = RadioButton072.Text
        If RadioButton071.Checked = True Then WK_str = RadioButton071.Text Else WK_str = RadioButton072.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "修理票金額出力", WK_str2, WK_str)
        End If

        Select Case DtView1(0)("dlvr_rprt_cls")
            Case Is = "0"
                WK_str2 = RadioButton091.Text
            Case Is = "1"
                WK_str2 = RadioButton092.Text
            Case Is = "2"
                WK_str2 = RadioButton093.Text
        End Select
        If RadioButton091.Checked = True Then WK_str = RadioButton091.Text
        If RadioButton092.Checked = True Then WK_str = RadioButton092.Text
        If RadioButton093.Checked = True Then WK_str = RadioButton093.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "納品書発行", WK_str2, WK_str)
        End If

        Select Case DtView1(0)("dlvr_rprt_cls")
            Case Is = "0"
                WK_str = Nothing
            Case Is = "1"
                If Not IsDBNull(DtView1(0)("dlvr_rprt_ptn_name")) Then WK_str = DtView1(0)("dlvr_rprt_ptn_name") Else WK_str = Nothing
            Case Is = "2"
                If Not IsDBNull(DtView1(0)("dlvr_rprt_ptn_name2")) Then WK_str = DtView1(0)("dlvr_rprt_ptn_name2") Else WK_str = Nothing
        End Select
        If Combo004.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "納品書パターン", WK_str, Combo004.Text)
        End If

        If DtView1(0)("invc_rprt_flg") = "0" Then WK_str2 = RadioButton101.Text Else WK_str2 = RadioButton102.Text
        If RadioButton101.Checked = True Then WK_str = RadioButton101.Text Else WK_str = RadioButton102.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求書発行", WK_str2, WK_str)
        End If

        If Not IsDBNull(DtView1(0)("invc_rprt_ptn_name")) Then WK_str = DtView1(0)("invc_rprt_ptn_name") Else WK_str = Nothing
        If Combo006.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求書パターン", WK_str, Combo006.Text)
        End If

        If Not IsDBNull(DtView1(0)("invc_dtl_ptn_name")) Then WK_str = DtView1(0)("invc_dtl_ptn_name") Else WK_str = Nothing
        If Combo007.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "請求明細表パターン", WK_str, Combo007.Text)
        End If

        If Number002.Value <> DtView1(0)("wrn_period") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "修理票保証期間", DtView1(0)("wrn_period"), Number002.Value)
        End If

        If DtView1(0)("ccar_flg") = "1" Then
            If CheckBox003.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "ＣＣＡＲ印刷", "対象", "対象外")
            End If
        Else
            If CheckBox003.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "ＣＣＡＲ印刷", "対象外", "対象")
            End If
        End If

        If DtView1(0)("web_flg") = "1" Then
            If CheckBox005.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "Web Data 作成", "対象", "対象外")
            End If
        Else
            If CheckBox005.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "Web Data 作成", "対象外", "対象")
            End If
        End If

        If Not IsDBNull(DtView1(0)("print_tel")) Then WK_str = DtView1(0)("print_tel") Else WK_str = Nothing
        If Edit011.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "ｻﾎﾟｰﾄ専用TEL", WK_str, Edit011.Text)
        End If

        If Not IsDBNull(DtView1(0)("print_fax")) Then WK_str = DtView1(0)("print_fax") Else WK_str = Nothing
        If Edit012.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "ｻﾎﾟｰﾄ専用FAX", WK_str, Edit012.Text)
        End If

        If DtView1(0)("delt_flg") = "1" Then
            If CheckBox001.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "削除フラグ", "削除", "")
            End If
        Else
            If CheckBox001.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit000.Text, "削除フラグ", "", "削除")
            End If
        End If
    End Sub
    Sub CHG_HSTY2()

        If Edit008.Text = Nothing Then
            Edit008.Text = Edit000.Text
            Edit008_N.Text = Edit001.Text
        End If
        If Edit008_N.Text <> WK_DtView1(i)("invc_name") Or Edit008.Text <> WK_DtView1(i)("invc_code") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先", WK_DtView1(i)("invc_code") & ":" & WK_DtView1(i)("invc_name"), Edit008.Text & ":" & Edit008_N.Text)
        End If

        If Edit010.Text <> WK_DtView1(i)("client_code") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "取引先コード", WK_DtView1(i)("client_code"), Edit010.Text)
        End If

        If Number001.Value <> WK_DtView1(i)("cls_date") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "締日", WK_DtView1(i)("cls_date"), Number001.Value)
        End If

        If Not IsDBNull(WK_DtView1(i)("invc_prt_name")) Then WK_str = WK_DtView1(i)("invc_prt_name") Else WK_str = Nothing
        If Edit013.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先名", WK_str, Edit013.Text)
        End If

        If Not IsDBNull(WK_DtView1(i)("invc_prt_name")) Then WK_str = WK_DtView1(i)("invc_prt_name") Else WK_str = Nothing
        If Edit013.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先名", WK_str, Edit013.Text)
        End If

        If Not IsDBNull(WK_DtView1(i)("invc_zip")) Then WK_str = Mid(WK_DtView1(i)("invc_zip"), 1, 3) & "-" & Mid(WK_DtView1(i)("invc_zip"), 4, 4) Else WK_str = Nothing
        If WK_str = "-" Then WK_str = Nothing
        If Mask2.Value <> Nothing Then WK_str2 = Mid(Mask2.Text, 3, 8) Else WK_str2 = Nothing
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先郵便番号", WK_str, WK_str2)
        End If

        If Not IsDBNull(WK_DtView1(i)("invc_adrs1")) Then WK_str = WK_DtView1(i)("invc_adrs1") Else WK_str = Nothing
        If Edit014.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先住所1", WK_str, Edit014.Text)
        End If

        If Not IsDBNull(WK_DtView1(i)("invc_adrs2")) Then WK_str = WK_DtView1(i)("invc_adrs2") Else WK_str = Nothing
        If Edit015.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先住所2", WK_str, Edit015.Text)
        End If

        If Number003.Value <> WK_DtView1(i)("tech_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "技術料掛率", WK_DtView1(i)("tech_rate"), Number003.Value)
        End If

        If Number004.Value <> WK_DtView1(i)("part_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "部品代掛率", WK_DtView1(i)("part_rate"), Number004.Value)
        End If

        If Number005.Value <> WK_DtView1(i)("tech_mrgn_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "技術料マージン率", WK_DtView1(i)("tech_mrgn_rate"), Number005.Value)
        End If

        If Number006.Value <> WK_DtView1(i)("part_mrgn_rate") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "部品代マージン率", WK_DtView1(i)("part_mrgn_rate"), Number006.Value)
        End If

        If Combo002.Text <> WK_DtView1(i)("sub_name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "報告書用修理会社", WK_DtView1(i)("sub_name"), Combo002.Text)
        End If

        Select Case WK_DtView1(i)("price_rprt_cls")
            Case Is = "0"
                WK_str2 = RadioButton021.Text
            Case Is = "1"
                WK_str2 = RadioButton022.Text
            Case Is = "2"
                WK_str2 = RadioButton023.Text
        End Select
        If RadioButton021.Checked = True Then WK_str = RadioButton021.Text
        If RadioButton022.Checked = True Then WK_str = RadioButton022.Text
        If RadioButton023.Checked = True Then WK_str = RadioButton023.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "見積書発行", WK_str2, WK_str)
        End If

        If Not IsDBNull(WK_DtView1(i)("price_rprt_ptn_name")) Then WK_str = WK_DtView1(i)("price_rprt_ptn_name") Else WK_str = Nothing
        If Combo003.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "見積書パターン", WK_str, Combo003.Text)
        End If

        If WK_DtView1(i)("price_rprt_part_flg") = "0" Then WK_str2 = RadioButton031.Text Else WK_str2 = RadioButton032.Text
        If RadioButton031.Checked = True Then WK_str = RadioButton031.Text Else WK_str = RadioButton032.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "見積書部品代出力", WK_str2, WK_str)
        End If

        If WK_DtView1(i)("rpr_rprt_flg") = "0" Then WK_str2 = RadioButton041.Text Else WK_str2 = RadioButton042.Text
        If RadioButton041.Checked = True Then WK_str = RadioButton041.Text Else WK_str = RadioButton042.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "修理票発行", WK_str2, WK_str)
        End If

        If Not IsDBNull(WK_DtView1(i)("rpr_rprt_ptn_name")) Then WK_str = WK_DtView1(i)("rpr_rprt_ptn_name") Else WK_str = Nothing
        If Combo005.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "修理票パターン", WK_str, Combo005.Text)
        End If

        If WK_DtView1(i)("rpr_rprt_part_flg") = "0" Then WK_str2 = RadioButton051.Text Else WK_str2 = RadioButton052.Text
        If RadioButton051.Checked = True Then WK_str = RadioButton051.Text Else WK_str = RadioButton052.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "修理票部品代出力", WK_str2, WK_str)
        End If

        If WK_DtView1(i)("rpr_rprt_dvl_flg") = "0" Then WK_str2 = RadioButton061.Text Else WK_str2 = RadioButton062.Text
        If RadioButton061.Checked = True Then WK_str = RadioButton061.Text Else WK_str = RadioButton062.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "修理票送料以下出力", WK_str2, WK_str)
        End If

        If WK_DtView1(i)("rpr_rprt_amnt_flg") = "0" Then WK_str2 = RadioButton071.Text Else WK_str2 = RadioButton072.Text
        If RadioButton071.Checked = True Then WK_str = RadioButton071.Text Else WK_str = RadioButton072.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "修理票金額出力", WK_str2, WK_str)
        End If

        Select Case WK_DtView1(i)("dlvr_rprt_cls")
            Case Is = "0"
                WK_str2 = RadioButton091.Text
            Case Is = "1"
                WK_str2 = RadioButton092.Text
            Case Is = "2"
                WK_str2 = RadioButton093.Text
        End Select
        If RadioButton091.Checked = True Then WK_str = RadioButton091.Text
        If RadioButton092.Checked = True Then WK_str = RadioButton092.Text
        If RadioButton093.Checked = True Then WK_str = RadioButton093.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "納品書発行", WK_str2, WK_str)
        End If

        Select Case WK_DtView1(i)("dlvr_rprt_cls")
            Case Is = "0"
                WK_str = Nothing
            Case Is = "1"
                If Not IsDBNull(WK_DtView1(i)("dlvr_rprt_ptn_name")) Then WK_str = WK_DtView1(i)("dlvr_rprt_ptn_name") Else WK_str = Nothing
            Case Is = "2"
                If Not IsDBNull(WK_DtView1(i)("dlvr_rprt_ptn_name2")) Then WK_str = WK_DtView1(i)("dlvr_rprt_ptn_name2") Else WK_str = Nothing
        End Select
        If Combo004.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "納品書パターン", WK_str, Combo004.Text)
        End If

        If WK_DtView1(i)("invc_rprt_flg") = "0" Then WK_str2 = RadioButton101.Text Else WK_str2 = RadioButton102.Text
        If RadioButton101.Checked = True Then WK_str = RadioButton101.Text Else WK_str = RadioButton102.Text
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求書発行", WK_str2, WK_str)
        End If

        If Not IsDBNull(WK_DtView1(i)("invc_rprt_ptn_name")) Then WK_str = WK_DtView1(i)("invc_rprt_ptn_name") Else WK_str = Nothing
        If Combo006.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求書パターン", WK_str, Combo006.Text)
        End If

        If Not IsDBNull(WK_DtView1(i)("invc_dtl_ptn_name")) Then WK_str = WK_DtView1(i)("invc_dtl_ptn_name") Else WK_str = Nothing
        If Combo007.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求明細表パターン", WK_str, Combo007.Text)
        End If

        If WK_DtView1(i)("ccar_flg") = "1" Then
            If CheckBox003.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "ＣＣＡＲ印刷", "対象", "対象外")
            End If
        Else
            If CheckBox003.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "ＣＣＡＲ印刷", "対象外", "対象")
            End If
        End If

        If WK_DtView1(i)("web_flg") = "1" Then
            If CheckBox005.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "Web Data 作成", "対象", "対象外")
            End If
        Else
            If CheckBox005.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "Web Data 作成", "対象外", "対象")
            End If
        End If
    End Sub

    '********************************************************************
    '**  検索
    '********************************************************************
    Private Sub Button_S1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S1.Click
        '販社
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Edit007.Text
        If CheckBox002.Checked = True Then
            P_PRAM2 = "一般"
        Else
            P_PRAM2 = Nothing
        End If
        Dim F00_Form02 As New F00_Form02
        F00_Form02.ShowDialog()
        If P_RTN = "1" Then
            Edit007.Text = P_PRAM1
            Edit007_N.Text = P_PRAM2
            Edit007.Focus()
            Edit007.BackColor = System.Drawing.SystemColors.Window
        Else
            Edit007.Focus()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Button_S2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S2.Click
        '販社
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Edit008.Text
        If CheckBox002.Checked = True Then
            P_PRAM2 = "一般"
        Else
            P_PRAM2 = Nothing
        End If
        Dim F00_Form02 As New F00_Form02
        F00_Form02.ShowDialog()
        If P_RTN = "1" Then
            Edit008.Text = P_PRAM1
            Edit008_N.Text = P_PRAM2
            Edit008.Focus()
            Edit008.BackColor = System.Drawing.SystemColors.Window
        Else
            Edit008.Focus()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_HSTY_DATE = Now

        If CheckBox004.Checked = True Then  'グループ更新
            F_Check2()
            If Err_F = "0" Then

                WK_DsList1.Clear()
                strSQL = "SELECT M08_STORE.*, M08_STORE_1.name AS invc_name, M08_STORE.sub_code + ':' + M09_SUB_OWN.name AS sub_name"
                strSQL +=  ", M08_STORE.price_rprt_ptn + ':' + V_cls_014.cls_code_name AS price_rprt_ptn_name"
                strSQL +=  ", M08_STORE.rpr_rprt_ptn + ':' + V_cls_024.cls_code_name AS rpr_rprt_ptn_name"
                strSQL +=  ", M08_STORE.dlvr_rprt_ptn + ':' + V_cls_015.cls_code_name AS dlvr_rprt_ptn_name"
                strSQL +=  ", M08_STORE.dlvr_rprt_ptn + ':' + V_cls_021.cls_code_name AS dlvr_rprt_ptn_name2"
                strSQL +=  ", M08_STORE.invc_rprt_ptn + ':' + V_cls_030.cls_code_name AS invc_rprt_ptn_name"
                strSQL +=  ", M08_STORE.invc_dtl_ptn + ':' + V_cls_032.cls_code_name AS invc_dtl_ptn_name"
                strSQL +=  " FROM M08_STORE INNER JOIN"
                strSQL +=  " M08_STORE AS M08_STORE_1 ON M08_STORE.invc_code = M08_STORE_1.store_code LEFT OUTER JOIN"
                strSQL +=  " V_cls_030 ON M08_STORE.invc_rprt_ptn = V_cls_030.cls_code LEFT OUTER JOIN"
                strSQL +=  " V_cls_032 ON M08_STORE.invc_dtl_ptn = V_cls_032.cls_code LEFT OUTER JOIN"
                strSQL +=  " V_cls_024 ON M08_STORE.rpr_rprt_ptn = V_cls_024.cls_code LEFT OUTER JOIN"
                strSQL +=  " V_cls_014 ON M08_STORE.price_rprt_ptn = V_cls_014.cls_code LEFT OUTER JOIN"
                strSQL +=  " M09_SUB_OWN ON M08_STORE.sub_code = M09_SUB_OWN.sub_code LEFT OUTER JOIN"
                strSQL +=  " V_cls_015 ON M08_STORE.dlvr_rprt_ptn = V_cls_015.cls_code LEFT OUTER JOIN"
                strSQL +=  " V_cls_021 ON M08_STORE.dlvr_rprt_ptn = V_cls_021.cls_code"
                'strSQL = "SELECT M08_STORE.*, M08_STORE.sub_code + ':' + M09_SUB_OWN.name AS sub_name"
                'strSQL +=  ", M08_STORE.price_rprt_ptn + ':' + V_cls_014.cls_code_name AS price_rprt_ptn_name"
                'strSQL +=  ", M08_STORE.rpr_rprt_ptn + ':' + V_cls_024.cls_code_name AS rpr_rprt_ptn_name"
                'strSQL +=  ", M08_STORE.dlvr_rprt_ptn + ':' + V_cls_015.cls_code_name AS dlvr_rprt_ptn_name"
                'strSQL +=  ", M08_STORE.dlvr_rprt_ptn + ':' + V_cls_021.cls_code_name AS dlvr_rprt_ptn_name2"
                'strSQL +=  " FROM M08_STORE LEFT OUTER JOIN"
                'strSQL +=  " V_cls_024 ON M08_STORE.rpr_rprt_ptn = V_cls_024.cls_code LEFT OUTER JOIN"
                'strSQL +=  " V_cls_014 ON M08_STORE.price_rprt_ptn = V_cls_014.cls_code LEFT OUTER JOIN"
                'strSQL +=  " M09_SUB_OWN ON M08_STORE.sub_code = M09_SUB_OWN.sub_code LEFT OUTER JOIN"
                'strSQL +=  " V_cls_015 ON M08_STORE.dlvr_rprt_ptn = V_cls_015.cls_code LEFT OUTER JOIN"
                'strSQL +=  " V_cls_021 ON M08_STORE.dlvr_rprt_ptn = V_cls_021.cls_code"
                strSQL +=  " WHERE (M08_STORE.grup_code = '" & CL001.Text & "')"
                strSQL +=  " AND (M08_STORE.delt_flg = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "M08_STORE")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    For i = 0 To WK_DtView1.Count - 1
                        chg_itm = 0
                        CHG_HSTY2()  '**  変更履歴
                        If chg_itm <> 0 Then
                            '販社マスタ
                            strSQL = "UPDATE M08_STORE"
                            strSQL +=  " SET sub_code = '" & CL002.Text & "'"
                            If Edit008.Text <> Nothing Then strSQL +=  ", invc_code = '" & Edit008.Text & "'" Else strSQL +=  ", invc_code = '" & Edit000.Text & "'"
                            strSQL +=  ", client_code = '" & Edit010.Text & "'"
                            strSQL +=  ", invc_prt_name = '" & Edit013.Text & "'"
                            strSQL +=  ", invc_zip = '" & Mask2.Value & "'"
                            strSQL +=  ", invc_adrs1 = '" & Edit014.Text & "'"
                            strSQL +=  ", invc_adrs2 = '" & Edit015.Text & "'"
                            strSQL +=  ", cls_date = " & Number001.Value
                            strSQL +=  ", tech_rate = " & Number003.Value
                            strSQL +=  ", part_rate = " & Number004.Value
                            strSQL +=  ", tech_mrgn_rate = " & Number005.Value
                            strSQL +=  ", part_mrgn_rate = " & Number006.Value
                            If RadioButton021.Checked = True Then strSQL +=  ", price_rprt_cls = '0'"
                            If RadioButton022.Checked = True Then strSQL +=  ", price_rprt_cls = '1'"
                            If RadioButton023.Checked = True Then strSQL +=  ", price_rprt_cls = '2'"
                            strSQL +=  ", price_rprt_ptn = '" & CL003.Text & "'"
                            If RadioButton031.Checked = True Then strSQL +=  ", price_rprt_part_flg = 0" Else strSQL +=  ", price_rprt_part_flg = 1"
                            If RadioButton041.Checked = True Then strSQL +=  ", rpr_rprt_flg = 0" Else strSQL +=  ", rpr_rprt_flg = 1"
                            strSQL +=  ", rpr_rprt_ptn = '" & CL005.Text & "'"
                            If RadioButton071.Checked = True Then strSQL +=  ", rpr_rprt_amnt_flg = 0" Else strSQL +=  ", rpr_rprt_amnt_flg = 1"
                            If RadioButton061.Checked = True Then strSQL +=  ", rpr_rprt_dvl_flg = 0" Else strSQL +=  ", rpr_rprt_dvl_flg = 1"
                            If RadioButton051.Checked = True Then strSQL +=  ", rpr_rprt_part_flg = 0" Else strSQL +=  ", rpr_rprt_part_flg = 1"
                            If RadioButton091.Checked = True Then strSQL +=  ", dlvr_rprt_cls = '0'"
                            If RadioButton092.Checked = True Then strSQL +=  ", dlvr_rprt_cls = '1'"
                            If RadioButton093.Checked = True Then strSQL +=  ", dlvr_rprt_cls = '2'"
                            strSQL +=  ", dlvr_rprt_ptn = '" & CL004.Text & "'"
                            If RadioButton101.Checked = True Then strSQL +=  ", invc_rprt_flg = 0" Else strSQL +=  ", invc_rprt_flg = 1"
                            strSQL +=  ", invc_rprt_ptn = '" & CL006.Text & "'"
                            strSQL +=  ", invc_dtl_ptn = '" & CL007.Text & "'"
                            If CheckBox003.Checked = True Then strSQL +=  ", ccar_flg = 1" Else strSQL +=  ", ccar_flg = 0"
                            If CheckBox005.Checked = True Then strSQL +=  ", web_flg = 1" Else strSQL +=  ", web_flg = 0"
                            'strSQL +=  ", invc_prt_name = '" & Edit013.Text & "'"
                            strSQL +=  " WHERE (store_code = '" & WK_DtView1(i)("store_code") & "')"
                            DB_OPEN("nMVAR")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()
                        End If
                    Next
                End If

                '不整合チェック




                msg.Text = "更新しました。"
                DspSet()    '**  画面セット
                P_RTN = "1"
            End If
        Else
            F_Check()   '**  項目チェック
            If Err_F = "0" Then
                If P_PRAM8 = Nothing Then   '新規
                    Add_STORE()
                    msg.Text = "登録しました。"
                Else                        '修正

                    chg_itm = 0
                    CHG_HSTY()  '**  変更履歴
                    If chg_itm <> 0 Then
                        '販社マスタ
                        strSQL = "UPDATE M08_STORE"
                        strSQL +=  " SET grup_code = '" & CL001.Text & "'"
                        strSQL +=  ", name = '" & Edit001.Text & "'"
                        strSQL +=  ", name_kana = '" & Edit002.Text & "'"
                        strSQL +=  ", zip = '" & Mask1.Value & "'"
                        strSQL +=  ", adrs1 = '" & Edit003.Text & "'"
                        strSQL +=  ", adrs2 = '" & Edit004.Text & "'"
                        strSQL +=  ", tel = '" & Edit005.Text & "'"
                        strSQL +=  ", fax = '" & Edit006.Text & "'"
                        strSQL +=  ", invc_prt_name = '" & Edit013.Text & "'"
                        strSQL +=  ", invc_zip = '" & Mask2.Value & "'"
                        strSQL +=  ", invc_adrs1 = '" & Edit014.Text & "'"
                        strSQL +=  ", invc_adrs2 = '" & Edit015.Text & "'"
                        If CheckBox002.Checked = True Then strSQL +=  ", idvd_flg = 1" Else strSQL +=  ", idvd_flg = 0"
                        If RadioButton011.Checked = True Then strSQL +=  ", calc_cls = '0'"
                        If RadioButton012.Checked = True Then strSQL +=  ", calc_cls = '1'"
                        If RadioButton013.Checked = True Then strSQL +=  ", calc_cls = '2'"
                        strSQL +=  ", cls_date = " & Number001.Value
                        strSQL +=  ", wrn_period = " & Number002.Value
                        If Edit007.Text <> Nothing Then strSQL +=  ", dlvr_code = '" & Edit007.Text & "'" Else strSQL +=  ", dlvr_code = '" & Edit000.Text & "'"
                        If Edit008.Text <> Nothing Then strSQL +=  ", invc_code = '" & Edit008.Text & "'" Else strSQL +=  ", invc_code = '" & Edit000.Text & "'"
                        If Date001.Text <> "__:__" Then strSQL +=  ", fax_snd_time = '1900/01/01 " & Date001.Text & ":00'" Else strSQL +=  ", fax_snd_time = NULL"
                        strSQL +=  ", cust_code = '" & Edit009.Text & "'"
                        strSQL +=  ", client_code = '" & Edit010.Text & "'"
                        strSQL +=  ", tech_rate = " & Number003.Value
                        strSQL +=  ", part_rate = " & Number004.Value
                        strSQL +=  ", tech_mrgn_rate = " & Number005.Value
                        strSQL +=  ", part_mrgn_rate = " & Number006.Value
                        If RadioButton021.Checked = True Then strSQL +=  ", price_rprt_cls = '0'"
                        If RadioButton022.Checked = True Then strSQL +=  ", price_rprt_cls = '1'"
                        If RadioButton023.Checked = True Then strSQL +=  ", price_rprt_cls = '2'"
                        strSQL +=  ", price_rprt_ptn = '" & CL003.Text & "'"
                        If RadioButton031.Checked = True Then strSQL +=  ", price_rprt_part_flg = 0" Else strSQL +=  ", price_rprt_part_flg = 1"
                        If RadioButton041.Checked = True Then strSQL +=  ", rpr_rprt_flg = 0" Else strSQL +=  ", rpr_rprt_flg = 1"
                        strSQL +=  ", rpr_rprt_ptn = '" & CL005.Text & "'"
                        If RadioButton071.Checked = True Then strSQL +=  ", rpr_rprt_amnt_flg = 0" Else strSQL +=  ", rpr_rprt_amnt_flg = 1"
                        If RadioButton061.Checked = True Then strSQL +=  ", rpr_rprt_dvl_flg = 0" Else strSQL +=  ", rpr_rprt_dvl_flg = 1"
                        If RadioButton051.Checked = True Then strSQL +=  ", rpr_rprt_part_flg = 0" Else strSQL +=  ", rpr_rprt_part_flg = 1"
                        If RadioButton091.Checked = True Then strSQL +=  ", dlvr_rprt_cls = '0'"
                        If RadioButton092.Checked = True Then strSQL +=  ", dlvr_rprt_cls = '1'"
                        If RadioButton093.Checked = True Then strSQL +=  ", dlvr_rprt_cls = '2'"
                        strSQL +=  ", dlvr_rprt_ptn = '" & CL004.Text & "'"
                        If RadioButton101.Checked = True Then strSQL +=  ", invc_rprt_flg = 0" Else strSQL +=  ", invc_rprt_flg = 1"
                        strSQL +=  ", invc_rprt_ptn = '" & CL006.Text & "'"
                        strSQL +=  ", invc_dtl_ptn = '" & CL007.Text & "'"
                        strSQL +=  ", sub_code = '" & CL002.Text & "'"
                        If CheckBox003.Checked = True Then strSQL +=  ", ccar_flg = 1" Else strSQL +=  ", ccar_flg = 0"
                        If CheckBox005.Checked = True Then strSQL +=  ", web_flg = 1" Else strSQL +=  ", web_flg = 0"
                        strSQL +=  ", print_tel = '" & Edit011.Text & "'"
                        strSQL +=  ", print_fax = '" & Edit012.Text & "'"
                        'strSQL +=  ", invc_prt_name = '" & Edit013.Text & "'"
                        If CheckBox001.Checked = True Then strSQL +=  ", delt_flg = 1" Else strSQL +=  ", delt_flg = 0"
                        strSQL +=  " WHERE (store_code = '" & P_PRAM8 & "')"
                        DB_OPEN("nMVAR")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        '納品先ならば、子供を更新
                        WK_DsList1.Clear()
                        strSQL = "SELECT M08_STORE.store_code, M08_STORE.dlvr_code, M08_STORE.dlvr_rprt_cls"
                        strSQL +=  ", M08_STORE.dlvr_rprt_ptn, V_cls_015.cls_code_name AS dlvr_rprt_name"
                        strSQL +=  ", V_cls_021.cls_code_name AS dlvr_rprt_name_c"
                        strSQL +=  " FROM M08_STORE LEFT OUTER JOIN"
                        strSQL +=  " V_cls_015 ON M08_STORE.dlvr_rprt_ptn = V_cls_015.cls_code LEFT OUTER JOIN"
                        strSQL +=  " V_cls_021 ON M08_STORE.dlvr_rprt_ptn = V_cls_021.cls_code"
                        strSQL +=  " WHERE (M08_STORE.dlvr_code = '" & Edit000.Text & "')"
                        strSQL +=  " AND (M08_STORE.store_code <> '" & Edit000.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(WK_DsList1, "M08_STORE")
                        DB_CLOSE()

                        WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count <> 0 Then
                            For i = 0 To WK_DtView1.Count - 1

                                strSQL = "UPDATE M08_STORE"
                                If RadioButton091.Checked = True Then strSQL +=  " SET dlvr_rprt_cls = '0'"
                                If RadioButton092.Checked = True Then strSQL +=  " SET dlvr_rprt_cls = '1'"
                                If RadioButton093.Checked = True Then strSQL +=  " SET dlvr_rprt_cls = '2'"
                                strSQL +=  ", dlvr_rprt_ptn = '" & CL004.Text & "'"
                                strSQL +=  " WHERE (store_code = '" & WK_DtView1(i)("store_code") & "')"
                                DB_OPEN("nMVAR")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                '履歴
                                Select Case WK_DtView1(i)("dlvr_rprt_cls")
                                    Case Is = "0"
                                        WK_str2 = RadioButton091.Text
                                    Case Is = "1"
                                        WK_str2 = RadioButton092.Text
                                    Case Is = "2"
                                        WK_str2 = RadioButton093.Text
                                End Select
                                If RadioButton091.Checked = True Then WK_str = RadioButton091.Text
                                If RadioButton092.Checked = True Then WK_str = RadioButton092.Text
                                If RadioButton093.Checked = True Then WK_str = RadioButton093.Text
                                If WK_str2 <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "納品書発行", WK_str2, WK_str)
                                End If

                                Select Case WK_DtView1(i)("dlvr_rprt_cls")
                                    Case Is = "0"
                                        WK_str = Nothing
                                    Case Is = "1"
                                        If Not IsDBNull(WK_DtView1(i)("dlvr_rprt_name")) Then WK_str = WK_DtView1(i)("dlvr_rprt_cls") & ":" & WK_DtView1(i)("dlvr_rprt_name") Else WK_str = Nothing
                                    Case Is = "2"
                                        If Not IsDBNull(WK_DtView1(i)("dlvr_rprt_name_c")) Then WK_str = WK_DtView1(i)("dlvr_rprt_cls") & ":" & WK_DtView1(i)("dlvr_rprt_name_c") Else WK_str = Nothing
                                End Select
                                If Combo004.Text <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "納品書パターン", WK_str, Combo004.Text)
                                End If

                            Next
                        End If

                        '請求先ならば、子供を更新
                        WK_DsList1.Clear()
                        strSQL = "SELECT M08_STORE.store_code, M08_STORE.invc_code, M08_STORE.cls_date, M08_STORE.invc_rprt_flg"
                        strSQL +=  ", M08_STORE.invc_rprt_ptn, M08_STORE.invc_dtl_ptn, M08_STORE.invc_prt_name"
                        strSQL +=  ", M08_STORE.invc_zip, M08_STORE.invc_adrs1, M08_STORE.invc_adrs2"
                        strSQL +=  ", V_cls_030.cls_code_name AS invc_rprt_name, V_cls_032.cls_code_name AS invc_dtl_name"
                        strSQL +=  " FROM M08_STORE LEFT OUTER JOIN"
                        strSQL +=  " V_cls_032 ON M08_STORE.invc_dtl_ptn = V_cls_032.cls_code LEFT OUTER JOIN"
                        strSQL +=  " V_cls_030 ON M08_STORE.invc_rprt_ptn = V_cls_030.cls_code"
                        strSQL +=  " WHERE (M08_STORE.invc_code = '" & Edit000.Text & "')"
                        strSQL +=  " AND (M08_STORE.store_code <> '" & Edit000.Text & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(WK_DsList1, "M08_STORE")
                        DB_CLOSE()

                        WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count <> 0 Then
                            For i = 0 To WK_DtView1.Count - 1

                                strSQL = "UPDATE M08_STORE"
                                strSQL +=  " SET cls_date = " & Number001.Value & ""
                                If RadioButton101.Checked = True Then strSQL +=  ", invc_rprt_flg = 0" Else strSQL +=  ", invc_rprt_flg = 1"
                                strSQL +=  ", invc_rprt_ptn = '" & CL006.Text & "'"
                                strSQL +=  ", invc_dtl_ptn = '" & CL007.Text & "'"
                                strSQL +=  ", invc_prt_name = '" & Edit013.Text & "'"
                                strSQL +=  ", invc_zip = '" & Mask2.Value & "'"
                                strSQL +=  ", invc_adrs1 = '" & Edit014.Text & "'"
                                strSQL +=  ", invc_adrs2 = '" & Edit015.Text & "'"
                                strSQL +=  " WHERE (store_code = '" & WK_DtView1(i)("store_code") & "')"
                                DB_OPEN("nMVAR")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                '履歴
                                If Number001.Value <> WK_DtView1(i)("cls_date") Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "締日", WK_DtView1(i)("cls_date"), Number001.Value)
                                End If

                                If WK_DtView1(i)("invc_rprt_flg") = "0" Then WK_str2 = RadioButton101.Text Else WK_str2 = RadioButton102.Text
                                If RadioButton101.Checked = True Then WK_str = RadioButton101.Text Else WK_str = RadioButton102.Text
                                If WK_str2 <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求書発行", WK_str2, WK_str)
                                End If

                                If Not IsDBNull(WK_DtView1(i)("invc_rprt_name")) Then WK_str = WK_DtView1(i)("invc_rprt_ptn") & ":" & WK_DtView1(i)("invc_rprt_name") Else WK_str = Nothing
                                If Combo006.Text <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求書パターン", WK_str, Combo006.Text)
                                End If

                                If Not IsDBNull(WK_DtView1(i)("invc_dtl_name")) Then WK_str = WK_DtView1(i)("invc_dtl_ptn") & ":" & WK_DtView1(i)("invc_dtl_name") Else WK_str = Nothing
                                If Combo007.Text <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求明細表パターン", WK_str, Combo007.Text)
                                End If

                                If Not IsDBNull(WK_DtView1(i)("invc_prt_name")) Then WK_str = WK_DtView1(i)("invc_prt_name") Else WK_str = Nothing
                                If Edit013.Text <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先名", WK_str, Edit013.Text)
                                End If

                                If Not IsDBNull(WK_DtView1(i)("invc_zip")) Then WK_str = Mid(WK_DtView1(i)("invc_zip"), 1, 3) & "-" & Mid(WK_DtView1(i)("invc_zip"), 4, 4) Else WK_str = Nothing
                                If WK_str = "-" Then WK_str = Nothing
                                If Mask2.Value <> Nothing Then WK_str2 = Mid(Mask2.Text, 3, 8) Else WK_str2 = Nothing
                                If WK_str2 <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先郵便番号", WK_str, WK_str2)
                                End If

                                If Not IsDBNull(WK_DtView1(i)("invc_adrs1")) Then WK_str = WK_DtView1(i)("invc_adrs1") Else WK_str = Nothing
                                If Edit014.Text <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先住所1", WK_str, Edit014.Text)
                                End If

                                If Not IsDBNull(WK_DtView1(i)("invc_adrs2")) Then WK_str = WK_DtView1(i)("invc_adrs2") Else WK_str = Nothing
                                If Edit015.Text <> WK_str Then
                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, WK_DtView1(i)("store_code"), "請求先住所2", WK_str, Edit015.Text)
                                End If

                            Next
                        End If

                    End If

                    If chg_itm = 0 Then
                        msg.Text = "変更箇所がありません。"
                    Else
                        msg.Text = "更新しました。"
                        DspSet()    '**  画面セット
                    End If
                    P_RTN = "1"
                End If
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub Add_STORE()
        P_HSTY_DATE = Now
        Label001.Text = Now.Date

        ''販社コード取得
        'WK_DsList1.Clear()
        'strSQL = "SELECT MAX(store_code) AS max_store_code FROM M08_STORE"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(WK_DsList1, "M08_STORE")
        'WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        'If Not IsDBNull(WK_DtView1(0)("max_store_code")) Then
        '    Dim WK_str As String = WK_DtView1(0)("max_store_code") + 1
        '    Edit000.Text = WK_str.PadLeft(4, "0")
        'Else
        '    Edit000.Text = "0001"
        'End If

        '販社マスタ
        strSQL = "INSERT INTO M08_STORE"
        strSQL +=  " (store_code, grup_code, name, name_kana, zip, adrs1, adrs2, tel, fax"
        strSQL +=  ", invc_prt_name, invc_zip, invc_adrs1, invc_adrs2, idvd_flg, calc_cls, cls_date"
        strSQL +=  ", wrn_period, dlvr_code, invc_code, fax_snd_time, cust_code, client_code, tech_rate, part_rate"
        strSQL +=  ", tech_mrgn_rate, part_mrgn_rate, price_rprt_cls, price_rprt_ptn, price_rprt_part_flg, rpr_rprt_flg"
        strSQL +=  ", rpr_rprt_ptn, rpr_rprt_amnt_flg, rpr_rprt_dvl_flg, rpr_rprt_part_flg, dlvr_rprt_cls, dlvr_rprt_ptn"
        strSQL +=  ", invc_rprt_flg, invc_rprt_ptn, invc_dtl_ptn, sub_code, ccar_flg, web_flg, print_tel, print_fax"
        strSQL +=  ", reg_date, delt_flg)"

        strSQL +=  " VALUES ('" & Edit000.Text & "'"
        strSQL +=  ", '" & CL001.Text & "'"
        strSQL +=  ", '" & Edit001.Text & "'"
        strSQL +=  ", '" & Edit002.Text & "'"
        strSQL +=  ", '" & Mask1.Value & "'"
        strSQL +=  ", '" & Edit003.Text & "'"
        strSQL +=  ", '" & Edit004.Text & "'"
        strSQL +=  ", '" & Edit005.Text & "'"
        strSQL +=  ", '" & Edit006.Text & "'"
        strSQL +=  ", '" & Edit013.Text & "'"
        strSQL +=  ", '" & Mask2.Value & "'"
        strSQL +=  ", '" & Edit014.Text & "'"
        strSQL +=  ", '" & Edit015.Text & "'"
        If CheckBox002.Checked = True Then strSQL +=  ", 1" Else strSQL +=  ", 0"
        If RadioButton011.Checked = True Then strSQL +=  ", '0'"
        If RadioButton012.Checked = True Then strSQL +=  ", '1'"
        If RadioButton013.Checked = True Then strSQL +=  ", '2'"
        strSQL +=  ", " & Number001.Value
        strSQL +=  ", " & Number002.Value
        If Edit007.Text <> Nothing Then strSQL +=  ", '" & Edit007.Text & "'" Else strSQL +=  ", '" & Edit000.Text & "'"
        If Edit008.Text <> Nothing Then strSQL +=  ", '" & Edit008.Text & "'" Else strSQL +=  ", '" & Edit000.Text & "'"
        If Date001.Text <> "__:__" Then strSQL +=  ", '1900/01/01 " & Date001.Text & ":00'" Else strSQL +=  ", NULL"
        strSQL +=  ", '" & Edit009.Text & "'"
        strSQL +=  ", '" & Edit010.Text & "'"
        strSQL +=  ", " & Number003.Value
        strSQL +=  ", " & Number004.Value
        strSQL +=  ", " & Number005.Value
        strSQL +=  ", " & Number006.Value
        If RadioButton021.Checked = True Then strSQL +=  ", '0'"
        If RadioButton022.Checked = True Then strSQL +=  ", '1'"
        If RadioButton023.Checked = True Then strSQL +=  ", '2'"
        strSQL +=  ", '" & CL003.Text & "'"
        If RadioButton031.Checked = True Then strSQL +=  ", 0" Else strSQL +=  ", 1"
        If RadioButton041.Checked = True Then strSQL +=  ", 0" Else strSQL +=  ", 1"
        strSQL +=  ", '" & CL005.Text & "'"
        If RadioButton071.Checked = True Then strSQL +=  ", 0" Else strSQL +=  ", 1"
        If RadioButton061.Checked = True Then strSQL +=  ", 0" Else strSQL +=  ", 1"
        If RadioButton051.Checked = True Then strSQL +=  ", 0" Else strSQL +=  ", 1"
        If RadioButton091.Checked = True Then strSQL +=  ", '0'"
        If RadioButton092.Checked = True Then strSQL +=  ", '1'"
        If RadioButton093.Checked = True Then strSQL +=  ", '2'"
        strSQL +=  ", '" & CL004.Text & "'"
        If RadioButton101.Checked = True Then strSQL +=  ", 0" Else strSQL +=  ", 1"
        strSQL +=  ", '" & CL006.Text & "'"
        strSQL +=  ", '" & CL007.Text & "'"
        strSQL +=  ", '" & CL002.Text & "'"
        If CheckBox003.Checked = True Then strSQL +=  ", 1" Else strSQL +=  ", 0"
        If CheckBox005.Checked = True Then strSQL +=  ", 1" Else strSQL +=  ", 0"
        strSQL +=  ", '" & Edit011.Text & "'"
        strSQL +=  ", '" & Edit012.Text & "'"
        'strSQL +=  ", '" & Edit013.Text & "'"
        strSQL +=  ", '" & CDate(Label001.Text) & "'"
        If CheckBox001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
        strSQL += ")"
        DB_OPEN("nMVAR")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        add_MTR_hsty(M_CLS, Edit000.Text, "新規登録", "", "")

        P_RTN = "1"
        P_PRAM8 = Edit000.Text
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  履歴
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '変更履歴
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L02_MTR_HSTY", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 3)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 20)
        Pram3.Value = M_CLS
        Pram4.Value = P_PRAM8
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button_S5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S5.Click
        '郵便番号->住所
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList1.Clear()
        strSQL = "SELECT adrs FROM M15_ZIP"
        strSQL +=  " WHERE (zip = '" & Mask1.Value & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(P_DsList1, "M15_ZIP")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                msg.Text = "該当郵便番号なし"
                Mask1.Focus()
            Case Is = 1
                WK_DtView1 = New DataView(P_DsList1.Tables("M15_ZIP"), "", "", DataViewRowState.CurrentRows)
                Edit003.Text = Trim(WK_DtView1(0)("adrs"))
                Edit003.Focus()
            Case Else
                Dim F00_Form15 As New F00_Form15
                F00_Form15.ShowDialog()

                If P_RTN <> Nothing Then Edit003.Text = P_RTN : Edit003.Focus()
        End Select

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button_S6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S6.Click
        '郵便番号->住所
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList1.Clear()
        strSQL = "SELECT adrs FROM M15_ZIP"
        strSQL +=  " WHERE (zip = '" & Mask2.Value & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(P_DsList1, "M15_ZIP")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                msg.Text = "該当郵便番号なし"
                Mask2.Focus()
            Case Is = 1
                WK_DtView1 = New DataView(P_DsList1.Tables("M15_ZIP"), "", "", DataViewRowState.CurrentRows)
                Edit014.Text = Trim(WK_DtView1(0)("adrs"))
                Edit014.Focus()
            Case Else
                Dim F00_Form15 As New F00_Form15
                F00_Form15.ShowDialog()

                If P_RTN <> Nothing Then Edit014.Text = P_RTN : Edit014.Focus()
        End Select

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsCMB.Clear() : DsCMB3.Clear() : DsCMB4.Clear() : DsCMB5.Clear()
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
