Public Class F60_Form01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, DtView2, DtView3, WK_DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, WK_str, WK_str2, strFile, strData, ANS, Err_F As String
    Dim i, j, r, WK_sum1, WK_sum2 As Integer
    Dim WK_sum, amt_sum As Long
    Dim WK_sum_err As String

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Number01 As GrapeCity.Win.Input.Number
    Friend WithEvents Number02 As GrapeCity.Win.Input.Number
    Friend WithEvents Number03 As GrapeCity.Win.Input.Number
    Friend WithEvents Number04 As GrapeCity.Win.Input.Number
    Friend WithEvents Number05 As GrapeCity.Win.Input.Number
    Friend WithEvents Number06 As GrapeCity.Win.Input.Number
    Friend WithEvents Number07 As GrapeCity.Win.Input.Number
    Friend WithEvents Number08 As GrapeCity.Win.Input.Number
    Friend WithEvents Number09 As GrapeCity.Win.Input.Number
    Friend WithEvents Number10 As GrapeCity.Win.Input.Number
    Friend WithEvents Number11 As GrapeCity.Win.Input.Number
    Friend WithEvents Number12 As GrapeCity.Win.Input.Number
    Friend WithEvents Number13 As GrapeCity.Win.Input.Number
    Friend WithEvents Number14 As GrapeCity.Win.Input.Number
    Friend WithEvents Number15 As GrapeCity.Win.Input.Number
    Friend WithEvents Number16 As GrapeCity.Win.Input.Number
    Friend WithEvents Number17 As GrapeCity.Win.Input.Number
    Friend WithEvents Number18 As GrapeCity.Win.Input.Number
    Friend WithEvents Number19 As GrapeCity.Win.Input.Number
    Friend WithEvents Number20 As GrapeCity.Win.Input.Number
    Friend WithEvents Number21 As GrapeCity.Win.Input.Number
    Friend WithEvents Number22 As GrapeCity.Win.Input.Number
    Friend WithEvents Number23 As GrapeCity.Win.Input.Number
    Friend WithEvents Number24 As GrapeCity.Win.Input.Number
    Friend WithEvents Number25 As GrapeCity.Win.Input.Number
    Friend WithEvents Number26 As GrapeCity.Win.Input.Number
    Friend WithEvents Number27 As GrapeCity.Win.Input.Number
    Friend WithEvents Number28 As GrapeCity.Win.Input.Number
    Friend WithEvents Number29 As GrapeCity.Win.Input.Number
    Friend WithEvents Number30 As GrapeCity.Win.Input.Number
    Friend WithEvents Edit0 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit10 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit09 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Edit
    Friend WithEvents Number1 As GrapeCity.Win.Input.Number
    Friend WithEvents Number2 As GrapeCity.Win.Input.Number
    Friend WithEvents Number3 As GrapeCity.Win.Input.Number
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F60_Form01))
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Edit0 = New GrapeCity.Win.Input.Edit
        Me.Number01 = New GrapeCity.Win.Input.Number
        Me.Number02 = New GrapeCity.Win.Input.Number
        Me.Number03 = New GrapeCity.Win.Input.Number
        Me.Number04 = New GrapeCity.Win.Input.Number
        Me.Number05 = New GrapeCity.Win.Input.Number
        Me.Number06 = New GrapeCity.Win.Input.Number
        Me.Number07 = New GrapeCity.Win.Input.Number
        Me.Number08 = New GrapeCity.Win.Input.Number
        Me.Number09 = New GrapeCity.Win.Input.Number
        Me.Number10 = New GrapeCity.Win.Input.Number
        Me.Number11 = New GrapeCity.Win.Input.Number
        Me.Number12 = New GrapeCity.Win.Input.Number
        Me.Number13 = New GrapeCity.Win.Input.Number
        Me.Number14 = New GrapeCity.Win.Input.Number
        Me.Number15 = New GrapeCity.Win.Input.Number
        Me.Number16 = New GrapeCity.Win.Input.Number
        Me.Number17 = New GrapeCity.Win.Input.Number
        Me.Number18 = New GrapeCity.Win.Input.Number
        Me.Number19 = New GrapeCity.Win.Input.Number
        Me.Number20 = New GrapeCity.Win.Input.Number
        Me.Number21 = New GrapeCity.Win.Input.Number
        Me.Number22 = New GrapeCity.Win.Input.Number
        Me.Number23 = New GrapeCity.Win.Input.Number
        Me.Number24 = New GrapeCity.Win.Input.Number
        Me.Number25 = New GrapeCity.Win.Input.Number
        Me.Number26 = New GrapeCity.Win.Input.Number
        Me.Number27 = New GrapeCity.Win.Input.Number
        Me.Number28 = New GrapeCity.Win.Input.Number
        Me.Number29 = New GrapeCity.Win.Input.Number
        Me.Number30 = New GrapeCity.Win.Input.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Edit01 = New GrapeCity.Win.Input.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Edit
        Me.Edit03 = New GrapeCity.Win.Input.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Edit
        Me.Edit05 = New GrapeCity.Win.Input.Edit
        Me.Edit10 = New GrapeCity.Win.Input.Edit
        Me.Edit09 = New GrapeCity.Win.Input.Edit
        Me.Edit08 = New GrapeCity.Win.Input.Edit
        Me.Edit07 = New GrapeCity.Win.Input.Edit
        Me.Edit06 = New GrapeCity.Win.Input.Edit
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Edit2 = New GrapeCity.Win.Input.Edit
        Me.Edit3 = New GrapeCity.Win.Input.Edit
        Me.Number1 = New GrapeCity.Win.Input.Number
        Me.Number2 = New GrapeCity.Win.Input.Number
        Me.Number3 = New GrapeCity.Win.Input.Number
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Edit4 = New GrapeCity.Win.Input.Edit
        Me.Label26 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.CL002 = New System.Windows.Forms.Label
        Me.Edit5 = New GrapeCity.Win.Input.Edit
        CType(Me.Edit0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(652, 668)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 51
        Me.Button98.Text = "戻る"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(552, 668)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 24)
        Me.Button5.TabIndex = 50
        Me.Button5.Text = "印刷"
        '
        'Edit0
        '
        Me.Edit0.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit0.LengthAsByte = True
        Me.Edit0.Location = New System.Drawing.Point(16, 252)
        Me.Edit0.MaxLength = 200
        Me.Edit0.Multiline = True
        Me.Edit0.Name = "Edit0"
        Me.Edit0.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit0.Size = New System.Drawing.Size(324, 276)
        Me.Edit0.TabIndex = 3
        '
        'Number01
        '
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number01.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number01.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number01.Location = New System.Drawing.Point(344, 256)
        Me.Number01.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number01.Name = "Number01"
        Me.Number01.ReadOnly = True
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(60, 20)
        Me.Number01.TabIndex = 4
        Me.Number01.TabStop = False
        Me.Number01.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number02
        '
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number02.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number02.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number02.Location = New System.Drawing.Point(344, 284)
        Me.Number02.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(60, 20)
        Me.Number02.TabIndex = 8
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number03
        '
        Me.Number03.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number03.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number03.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number03.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number03.Location = New System.Drawing.Point(344, 312)
        Me.Number03.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number03.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number03.Name = "Number03"
        Me.Number03.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number03.Size = New System.Drawing.Size(60, 20)
        Me.Number03.TabIndex = 12
        Me.Number03.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number04
        '
        Me.Number04.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number04.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number04.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number04.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number04.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number04.Location = New System.Drawing.Point(344, 340)
        Me.Number04.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number04.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number04.Name = "Number04"
        Me.Number04.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number04.Size = New System.Drawing.Size(60, 20)
        Me.Number04.TabIndex = 16
        Me.Number04.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number05
        '
        Me.Number05.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number05.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number05.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number05.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number05.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number05.Location = New System.Drawing.Point(344, 368)
        Me.Number05.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number05.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number05.Name = "Number05"
        Me.Number05.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number05.Size = New System.Drawing.Size(60, 20)
        Me.Number05.TabIndex = 20
        Me.Number05.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number06
        '
        Me.Number06.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number06.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number06.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number06.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number06.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number06.Location = New System.Drawing.Point(344, 396)
        Me.Number06.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number06.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number06.Name = "Number06"
        Me.Number06.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number06.Size = New System.Drawing.Size(60, 20)
        Me.Number06.TabIndex = 24
        Me.Number06.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number07
        '
        Me.Number07.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number07.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number07.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number07.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number07.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number07.Location = New System.Drawing.Point(344, 424)
        Me.Number07.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number07.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number07.Name = "Number07"
        Me.Number07.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number07.Size = New System.Drawing.Size(60, 20)
        Me.Number07.TabIndex = 28
        Me.Number07.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number08
        '
        Me.Number08.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number08.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number08.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number08.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number08.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number08.Location = New System.Drawing.Point(344, 452)
        Me.Number08.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number08.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number08.Name = "Number08"
        Me.Number08.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number08.Size = New System.Drawing.Size(60, 20)
        Me.Number08.TabIndex = 32
        Me.Number08.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number09
        '
        Me.Number09.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number09.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number09.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number09.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number09.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number09.Location = New System.Drawing.Point(344, 480)
        Me.Number09.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number09.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number09.Name = "Number09"
        Me.Number09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number09.Size = New System.Drawing.Size(60, 20)
        Me.Number09.TabIndex = 36
        Me.Number09.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number10
        '
        Me.Number10.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number10.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number10.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number10.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number10.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number10.Location = New System.Drawing.Point(344, 508)
        Me.Number10.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number10.MinValue = New Decimal(New Integer() {999, 0, 0, -2147483648})
        Me.Number10.Name = "Number10"
        Me.Number10.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number10.Size = New System.Drawing.Size(60, 20)
        Me.Number10.TabIndex = 40
        Me.Number10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number11
        '
        Me.Number11.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number11.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number11.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number11.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number11.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number11.Location = New System.Drawing.Point(408, 256)
        Me.Number11.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number11.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number11.Name = "Number11"
        Me.Number11.ReadOnly = True
        Me.Number11.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number11.Size = New System.Drawing.Size(84, 20)
        Me.Number11.TabIndex = 5
        Me.Number11.TabStop = False
        Me.Number11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number12
        '
        Me.Number12.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number12.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number12.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number12.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number12.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number12.Location = New System.Drawing.Point(408, 284)
        Me.Number12.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number12.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number12.Name = "Number12"
        Me.Number12.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number12.Size = New System.Drawing.Size(84, 20)
        Me.Number12.TabIndex = 9
        Me.Number12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number13
        '
        Me.Number13.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number13.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number13.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number13.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number13.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number13.Location = New System.Drawing.Point(408, 312)
        Me.Number13.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number13.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number13.Name = "Number13"
        Me.Number13.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number13.Size = New System.Drawing.Size(84, 20)
        Me.Number13.TabIndex = 13
        Me.Number13.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number14
        '
        Me.Number14.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number14.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number14.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number14.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number14.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number14.Location = New System.Drawing.Point(408, 340)
        Me.Number14.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number14.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number14.Name = "Number14"
        Me.Number14.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number14.Size = New System.Drawing.Size(84, 20)
        Me.Number14.TabIndex = 17
        Me.Number14.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number15
        '
        Me.Number15.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number15.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number15.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number15.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number15.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number15.Location = New System.Drawing.Point(408, 368)
        Me.Number15.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number15.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number15.Name = "Number15"
        Me.Number15.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number15.Size = New System.Drawing.Size(84, 20)
        Me.Number15.TabIndex = 21
        Me.Number15.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number16
        '
        Me.Number16.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number16.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number16.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number16.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number16.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number16.Location = New System.Drawing.Point(408, 396)
        Me.Number16.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number16.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number16.Name = "Number16"
        Me.Number16.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number16.Size = New System.Drawing.Size(84, 20)
        Me.Number16.TabIndex = 25
        Me.Number16.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number17
        '
        Me.Number17.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number17.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number17.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number17.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number17.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number17.Location = New System.Drawing.Point(408, 424)
        Me.Number17.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number17.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number17.Name = "Number17"
        Me.Number17.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number17.Size = New System.Drawing.Size(84, 20)
        Me.Number17.TabIndex = 29
        Me.Number17.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number18
        '
        Me.Number18.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number18.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number18.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number18.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number18.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number18.Location = New System.Drawing.Point(408, 452)
        Me.Number18.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number18.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number18.Name = "Number18"
        Me.Number18.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number18.Size = New System.Drawing.Size(84, 20)
        Me.Number18.TabIndex = 33
        Me.Number18.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number19
        '
        Me.Number19.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number19.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number19.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number19.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number19.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number19.Location = New System.Drawing.Point(408, 480)
        Me.Number19.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number19.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number19.Name = "Number19"
        Me.Number19.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number19.Size = New System.Drawing.Size(84, 20)
        Me.Number19.TabIndex = 37
        Me.Number19.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number20
        '
        Me.Number20.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number20.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number20.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number20.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number20.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number20.Location = New System.Drawing.Point(408, 508)
        Me.Number20.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number20.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number20.Name = "Number20"
        Me.Number20.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number20.Size = New System.Drawing.Size(84, 20)
        Me.Number20.TabIndex = 41
        Me.Number20.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number21
        '
        Me.Number21.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number21.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number21.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number21.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number21.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number21.Location = New System.Drawing.Point(496, 256)
        Me.Number21.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number21.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number21.Name = "Number21"
        Me.Number21.ReadOnly = True
        Me.Number21.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number21.Size = New System.Drawing.Size(92, 20)
        Me.Number21.TabIndex = 6
        Me.Number21.TabStop = False
        Me.Number21.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number22
        '
        Me.Number22.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number22.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number22.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number22.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number22.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number22.Location = New System.Drawing.Point(496, 284)
        Me.Number22.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number22.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number22.Name = "Number22"
        Me.Number22.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number22.Size = New System.Drawing.Size(92, 20)
        Me.Number22.TabIndex = 10
        Me.Number22.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number23
        '
        Me.Number23.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number23.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number23.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number23.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number23.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number23.Location = New System.Drawing.Point(496, 312)
        Me.Number23.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number23.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number23.Name = "Number23"
        Me.Number23.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number23.Size = New System.Drawing.Size(92, 20)
        Me.Number23.TabIndex = 14
        Me.Number23.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number24
        '
        Me.Number24.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number24.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number24.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number24.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number24.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number24.Location = New System.Drawing.Point(496, 340)
        Me.Number24.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number24.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number24.Name = "Number24"
        Me.Number24.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number24.Size = New System.Drawing.Size(92, 20)
        Me.Number24.TabIndex = 18
        Me.Number24.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number25
        '
        Me.Number25.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number25.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number25.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number25.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number25.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number25.Location = New System.Drawing.Point(496, 368)
        Me.Number25.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number25.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number25.Name = "Number25"
        Me.Number25.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number25.Size = New System.Drawing.Size(92, 20)
        Me.Number25.TabIndex = 22
        Me.Number25.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number26
        '
        Me.Number26.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number26.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number26.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number26.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number26.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number26.Location = New System.Drawing.Point(496, 396)
        Me.Number26.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number26.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number26.Name = "Number26"
        Me.Number26.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number26.Size = New System.Drawing.Size(92, 20)
        Me.Number26.TabIndex = 26
        Me.Number26.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number27
        '
        Me.Number27.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number27.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number27.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number27.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number27.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number27.Location = New System.Drawing.Point(496, 424)
        Me.Number27.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number27.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number27.Name = "Number27"
        Me.Number27.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number27.Size = New System.Drawing.Size(92, 20)
        Me.Number27.TabIndex = 30
        Me.Number27.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number28
        '
        Me.Number28.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number28.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number28.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number28.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number28.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number28.Location = New System.Drawing.Point(496, 452)
        Me.Number28.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number28.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number28.Name = "Number28"
        Me.Number28.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number28.Size = New System.Drawing.Size(92, 20)
        Me.Number28.TabIndex = 34
        Me.Number28.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number29
        '
        Me.Number29.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number29.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number29.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number29.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number29.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number29.Location = New System.Drawing.Point(496, 480)
        Me.Number29.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number29.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number29.Name = "Number29"
        Me.Number29.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number29.Size = New System.Drawing.Size(92, 20)
        Me.Number29.TabIndex = 38
        Me.Number29.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number30
        '
        Me.Number30.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number30.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number30.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number30.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number30.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number30.Location = New System.Drawing.Point(496, 508)
        Me.Number30.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number30.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number30.Name = "Number30"
        Me.Number30.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number30.Size = New System.Drawing.Size(92, 20)
        Me.Number30.TabIndex = 42
        Me.Number30.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 20)
        Me.Label1.TabIndex = 1769
        Me.Label1.Text = "品　　名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(344, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 20)
        Me.Label2.TabIndex = 1770
        Me.Label2.Text = "数量"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(408, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 1771
        Me.Label3.Text = "単価"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(496, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 1772
        Me.Label4.Text = "金　額"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(592, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 20)
        Me.Label5.TabIndex = 1773
        Me.Label5.Text = "摘　要"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(96, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(388, 20)
        Me.Label6.TabIndex = 1774
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 1775
        Me.Label7.Text = "郵便番号"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(16, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 1776
        Me.Label8.Text = "御住所"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(16, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 1777
        Me.Label9.Text = "御社名"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(96, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(388, 32)
        Me.Label11.TabIndex = 1779
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(96, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(388, 36)
        Me.Label12.TabIndex = 1780
        '
        'Edit01
        '
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(592, 256)
        Me.Edit01.MaxLength = 30
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(136, 20)
        Me.Edit01.TabIndex = 7
        '
        'Edit02
        '
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(592, 284)
        Me.Edit02.MaxLength = 30
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(136, 20)
        Me.Edit02.TabIndex = 11
        '
        'Edit03
        '
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(592, 312)
        Me.Edit03.MaxLength = 30
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(136, 20)
        Me.Edit03.TabIndex = 15
        '
        'Edit04
        '
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(592, 340)
        Me.Edit04.MaxLength = 30
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(136, 20)
        Me.Edit04.TabIndex = 19
        '
        'Edit05
        '
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(592, 368)
        Me.Edit05.MaxLength = 30
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(136, 20)
        Me.Edit05.TabIndex = 23
        '
        'Edit10
        '
        Me.Edit10.LengthAsByte = True
        Me.Edit10.Location = New System.Drawing.Point(592, 508)
        Me.Edit10.MaxLength = 30
        Me.Edit10.Name = "Edit10"
        Me.Edit10.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit10.Size = New System.Drawing.Size(136, 20)
        Me.Edit10.TabIndex = 43
        '
        'Edit09
        '
        Me.Edit09.LengthAsByte = True
        Me.Edit09.Location = New System.Drawing.Point(592, 480)
        Me.Edit09.MaxLength = 30
        Me.Edit09.Name = "Edit09"
        Me.Edit09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit09.Size = New System.Drawing.Size(136, 20)
        Me.Edit09.TabIndex = 39
        '
        'Edit08
        '
        Me.Edit08.LengthAsByte = True
        Me.Edit08.Location = New System.Drawing.Point(592, 452)
        Me.Edit08.MaxLength = 30
        Me.Edit08.Name = "Edit08"
        Me.Edit08.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit08.Size = New System.Drawing.Size(136, 20)
        Me.Edit08.TabIndex = 35
        '
        'Edit07
        '
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(592, 424)
        Me.Edit07.MaxLength = 30
        Me.Edit07.Name = "Edit07"
        Me.Edit07.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit07.Size = New System.Drawing.Size(136, 20)
        Me.Edit07.TabIndex = 31
        '
        'Edit06
        '
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(592, 396)
        Me.Edit06.MaxLength = 30
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(136, 20)
        Me.Edit06.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(492, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 20)
        Me.Label10.TabIndex = 1793
        Me.Label10.Text = "貴社見積番号"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(492, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 20)
        Me.Label13.TabIndex = 1792
        Me.Label13.Text = "納品書番号"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(492, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 20)
        Me.Label14.TabIndex = 1791
        Me.Label14.Text = "請求書番号"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.Location = New System.Drawing.Point(584, 24)
        Me.Edit1.Name = "Edit1"
        Me.Edit1.ReadOnly = True
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(144, 20)
        Me.Edit1.TabIndex = 0
        Me.Edit1.TabStop = False
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit2
        '
        Me.Edit2.LengthAsByte = True
        Me.Edit2.Location = New System.Drawing.Point(584, 52)
        Me.Edit2.MaxLength = 20
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(144, 20)
        Me.Edit2.TabIndex = 1
        Me.Edit2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit3
        '
        Me.Edit3.LengthAsByte = True
        Me.Edit3.Location = New System.Drawing.Point(584, 80)
        Me.Edit3.MaxLength = 20
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(144, 20)
        Me.Edit3.TabIndex = 2
        Me.Edit3.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number1.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number1.Location = New System.Drawing.Point(496, 536)
        Me.Number1.MaxValue = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.Number1.Name = "Number1"
        Me.Number1.ReadOnly = True
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(92, 20)
        Me.Number1.TabIndex = 44
        Me.Number1.TabStop = False
        Me.Number1.Value = Nothing
        '
        'Number2
        '
        Me.Number2.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number2.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number2.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number2.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number2.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number2.Location = New System.Drawing.Point(496, 564)
        Me.Number2.MaxValue = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Number2.MinValue = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.Number2.Name = "Number2"
        Me.Number2.ReadOnly = True
        Me.Number2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number2.Size = New System.Drawing.Size(92, 20)
        Me.Number2.TabIndex = 45
        Me.Number2.TabStop = False
        Me.Number2.Value = Nothing
        '
        'Number3
        '
        Me.Number3.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number3.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number3.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number3.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number3.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number3.Location = New System.Drawing.Point(496, 592)
        Me.Number3.MaxValue = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Number3.MinValue = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.Number3.Name = "Number3"
        Me.Number3.ReadOnly = True
        Me.Number3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number3.Size = New System.Drawing.Size(92, 20)
        Me.Number3.TabIndex = 46
        Me.Number3.TabStop = False
        Me.Number3.Value = Nothing
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(412, 592)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 20)
        Me.Label15.TabIndex = 1802
        Me.Label15.Text = "合　計"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Navy
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(412, 564)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 20)
        Me.Label16.TabIndex = 1801
        Me.Label16.Text = "消費税"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(412, 536)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 20)
        Me.Label17.TabIndex = 1800
        Me.Label17.Text = "小　計"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(308, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(420, 20)
        Me.Label18.TabIndex = 1805
        Me.Label18.Text = "Label18"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(308, 156)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(420, 32)
        Me.Label19.TabIndex = 1804
        Me.Label19.Text = "Label19"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(308, 188)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(420, 20)
        Me.Label20.TabIndex = 1803
        Me.Label20.Text = "Label20"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(308, 208)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(420, 20)
        Me.Label21.TabIndex = 1806
        Me.Label21.Text = "Label21"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit4
        '
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit4.LengthAsByte = True
        Me.Edit4.Location = New System.Drawing.Point(16, 536)
        Me.Edit4.MaxLength = 200
        Me.Edit4.Multiline = True
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit4.Size = New System.Drawing.Size(388, 76)
        Me.Edit4.TabIndex = 47
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(16, 620)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 20)
        Me.Label26.TabIndex = 1812
        Me.Label26.Text = "口座"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 676)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(520, 16)
        Me.msg.TabIndex = 1813
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(16, 644)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 20)
        Me.Label24.TabIndex = 1815
        Me.Label24.Text = "担当"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(308, 116)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(420, 20)
        Me.Label25.TabIndex = 1818
        Me.Label25.Text = "Label25"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Combo002.Location = New System.Drawing.Point(64, 620)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(660, 20)
        Me.Combo002.TabIndex = 48
        Me.Combo002.Value = "Combo002"
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(672, 604)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(52, 16)
        Me.CL002.TabIndex = 1820
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'Edit5
        '
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit5.LengthAsByte = True
        Me.Edit5.Location = New System.Drawing.Point(64, 644)
        Me.Edit5.MaxLength = 20
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(144, 20)
        Me.Edit5.TabIndex = 49
        Me.Edit5.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'F60_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(742, 700)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Number3)
        Me.Controls.Add(Me.Number2)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Edit10)
        Me.Controls.Add(Me.Edit09)
        Me.Controls.Add(Me.Edit08)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Number21)
        Me.Controls.Add(Me.Number22)
        Me.Controls.Add(Me.Number23)
        Me.Controls.Add(Me.Number24)
        Me.Controls.Add(Me.Number25)
        Me.Controls.Add(Me.Number26)
        Me.Controls.Add(Me.Number27)
        Me.Controls.Add(Me.Number28)
        Me.Controls.Add(Me.Number29)
        Me.Controls.Add(Me.Number30)
        Me.Controls.Add(Me.Number11)
        Me.Controls.Add(Me.Number12)
        Me.Controls.Add(Me.Number13)
        Me.Controls.Add(Me.Number14)
        Me.Controls.Add(Me.Number15)
        Me.Controls.Add(Me.Number16)
        Me.Controls.Add(Me.Number17)
        Me.Controls.Add(Me.Number18)
        Me.Controls.Add(Me.Number19)
        Me.Controls.Add(Me.Number20)
        Me.Controls.Add(Me.Number10)
        Me.Controls.Add(Me.Number09)
        Me.Controls.Add(Me.Number08)
        Me.Controls.Add(Me.Number07)
        Me.Controls.Add(Me.Number06)
        Me.Controls.Add(Me.Number05)
        Me.Controls.Add(Me.Number04)
        Me.Controls.Add(Me.Number03)
        Me.Controls.Add(Me.Number02)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.Edit0)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F60_Form01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求書入力"
        CType(Me.Edit0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F60_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '**  コンボボックスセット
        dsp_set()   '**  画面セット
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

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()

        '銀行
        strSQL = "SELECT M13_BANK_INFO.*, M03_BRCH.name AS brch_name"
        strSQL = strSQL & " FROM M13_BANK_INFO LEFT OUTER JOIN M03_BRCH ON M13_BANK_INFO.brch_code = M03_BRCH.brch_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "WK_M13_BANK_INFO")
        DB_CLOSE()

        strSQL = "SELECT '' AS bank_code, '' AS bank_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M13_BANK_INFO")
        DsCMB.Tables("M13_BANK_INFO").Clear()

        WK_DtView1 = New DataView(DsCMB.Tables("WK_M13_BANK_INFO"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                dttable = DsCMB.Tables("M13_BANK_INFO")
                dtRow = dttable.NewRow
                dtRow("bank_code") = WK_DtView1(i)("bank_code")
                dtRow("bank_name") = PadRightB(WK_DtView1(i)("bank_user"), 27)
                dtRow("bank_name") = dtRow("bank_name") & PadRightB(WK_DtView1(i)("bank_name"), 18)
                dtRow("bank_name") = dtRow("bank_name") & PadRightB(WK_DtView1(i)("bank_sub"), 12)
                If WK_DtView1(i)("bank_kbn") = "普通預金" Then
                    dtRow("bank_name") = dtRow("bank_name") & "(普)"
                Else
                    dtRow("bank_name") = dtRow("bank_name") & "(当)"
                End If
                dtRow("bank_name") = dtRow("bank_name") & " No." & WK_DtView1(i)("bank_acnt_no")
                dtRow("bank_name") = dtRow("bank_name") & " " & WK_DtView1(i)("brch_name")
                dttable.Rows.Add(dtRow)
            Next
        End If

        Combo002.DataSource = DsCMB.Tables("M13_BANK_INFO")
        Combo002.DisplayMember = "bank_name"
        Combo002.ValueMember = "bank_code"

        CL002.Text = "0"
        Combo002.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub dsp_set()
        If P_F60_0 = "S" Then
            '********************
            '** 販社請求
            '********************
            DsList1.Clear()
            If P_F60_1 = "0" Then   '新規
                If P_F60_2 = Nothing Then   '拠点まとめ
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_1m", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
                    Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 20)
                    Pram1.Value = P_F60_3
                    Pram2.Value = P_F60_4
                    Pram3.Value = P_EMPL_NAME

                Else
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_1", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
                    Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.DateTime)
                    Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p4", SqlDbType.Char, 20)
                    Pram1.Value = P_F60_3
                    Pram2.Value = P_F60_2
                    Pram3.Value = P_F60_4
                    Pram4.Value = P_EMPL_NAME
                End If

            Else                '再印刷
                If P_F60_2 = Nothing Then   '拠点まとめ
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_2m", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram1.Value = P_F60_1
                Else
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_2", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram1.Value = P_F60_1
                End If
            End If

            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "sp_F60_01")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("sp_F60_01"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                P_F60_9 = DtView1(0)("invc_rprt_ptn") '印刷パターン
                If Not IsDBNull(DtView1(0)("invc_dtl_ptn")) Then P_F60_10 = DtView1(0)("invc_dtl_ptn") Else P_F60_10 = "01" '印刷パターン

                strSQL = "SELECT idvd_flg FROM M08_STORE WHERE (store_code = '" & DtView1(0)("invc_code") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(DsList1, "idvd_flg")
                DB_CLOSE()
                DtView2 = New DataView(DsList1.Tables("idvd_flg"), "", "", DataViewRowState.CurrentRows)
                If DtView2.Count <> 0 Then P_idvd_flg = DtView2(0)("idvd_flg") Else P_idvd_flg = "False" '御中/様

                Select Case P_F60_9
                    Case Is = "02"  'Laox
                        Label6.Text = "〒105-0014"
                        Label11.Text = "東京都港区芝2-7-17 住友芝公園ビル15階"
                        Label12.Text = "ラオックス株式会社" & "　御中"

                        Label25.Text = Nothing
                        Label18.Text = "〒150-0031"
                        Label19.Text = "東京都渋谷区桜丘町3-4"
                        Label20.Text = "グローバルソリューションサービス株式会社"
                        Label21.Text = "TEL　03-574-0961"

                    Case Else       '通常
                        If Not IsDBNull(DtView1(0)("invc_zip")) Then Label6.Text = "〒" & Mid(DtView1(0)("invc_zip"), 1, 3) & "-" & Mid(DtView1(0)("invc_zip"), 4, 4) Else Label6.Text = Nothing
                        If Not IsDBNull(DtView1(0)("invc_adrs1")) Then Label11.Text = DtView1(0)("invc_adrs1") Else Label11.Text = Nothing
                        If Not IsDBNull(DtView1(0)("invc_adrs2")) Then Label11.Text = Label11.Text & System.Environment.NewLine & DtView1(0)("invc_adrs2")
                        If P_idvd_flg = "True" Then
                            If Not IsDBNull(DtView1(0)("invc_name")) Then Label12.Text = DtView1(0)("invc_name") & "　様" Else Label12.Text = Nothing
                        Else
                            If Not IsDBNull(DtView1(0)("invc_name")) Then Label12.Text = DtView1(0)("invc_name") & "　御中" Else Label12.Text = Nothing
                        End If

                        Label25.Text = "グローバルソリューションサービス株式会社"
                        If Not IsDBNull(DtView1(0)("brch_zip")) Then Label18.Text = "〒" & Mid(DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(DtView1(0)("brch_zip"), 4, 4) Else Label18.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_adrs1")) Then Label19.Text = DtView1(0)("brch_adrs1") Else Label19.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_adrs2")) Then Label19.Text = Label19.Text & "  " & DtView1(0)("brch_adrs2")
                        If Not IsDBNull(DtView1(0)("brch_name")) Then Label20.Text = DtView1(0)("brch_name") Else Label20.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_tel")) Then Label21.Text = "TEL " & DtView1(0)("brch_tel") Else Label21.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_fax")) Then Label21.Text = Label21.Text & "  FAX " & DtView1(0)("brch_fax")

                End Select

                Number01.Value = DtView1(0)("cnt")
                Number21.Value = DtView1(0)("amnt1")

                If Not IsDBNull(DtView1(0)("bank_code")) Then CL002.Text = DtView1(0)("bank_code") Else CL002.Text = "0"
                WK_DtView1 = New DataView(DsCMB.Tables("M13_BANK_INFO"), "bank_code =" & CL002.Text, "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Combo002.Text = WK_DtView1(0)("bank_name")
                Else
                    Combo002.Text = Nothing
                End If

                If P_F60_9 = "02" Then  'ラオックス
                    Edit2.Text = Nothing : Label13.Visible = False : Edit2.Visible = False
                    Edit3.Text = Nothing : Label10.Visible = False : Edit3.Visible = False
                End If

                Edit5.Text = Nothing : Label24.Visible = False : Edit5.Visible = False

                If P_F60_1 <> "0" Then   '再印刷
                    Edit1.Text = P_F60_1
                    If P_F60_9 = "02" Then
                        Edit2.Text = Nothing : Label13.Visible = False : Edit2.Visible = False
                        Edit3.Text = Nothing : Label10.Visible = False : Edit3.Visible = False
                    Else
                        If Not IsDBNull(DtView1(0)("dlvr_no")) Then Edit2.Text = DtView1(0)("dlvr_no") Else Edit2.Text = Nothing
                        If Not IsDBNull(DtView1(0)("etmt_no")) Then Edit3.Text = DtView1(0)("etmt_no") Else Edit3.Text = Nothing
                    End If

                    If Not IsDBNull(DtView1(0)("article_name")) Then Edit0.Text = DtView1(0)("article_name") Else Edit0.Text = Nothing
                    If Not IsDBNull(DtView1(0)("memo")) Then Edit4.Text = DtView1(0)("memo") Else Edit4.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou1")) Then Edit01.Text = DtView1(0)("tekiyou1") Else Edit01.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou2")) Then Edit02.Text = DtView1(0)("tekiyou2") Else Edit02.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou3")) Then Edit03.Text = DtView1(0)("tekiyou3") Else Edit03.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou4")) Then Edit04.Text = DtView1(0)("tekiyou4") Else Edit04.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou5")) Then Edit05.Text = DtView1(0)("tekiyou5") Else Edit05.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou6")) Then Edit06.Text = DtView1(0)("tekiyou6") Else Edit06.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou7")) Then Edit07.Text = DtView1(0)("tekiyou7") Else Edit07.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou8")) Then Edit08.Text = DtView1(0)("tekiyou8") Else Edit08.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou9")) Then Edit09.Text = DtView1(0)("tekiyou9") Else Edit09.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou10")) Then Edit10.Text = DtView1(0)("tekiyou10") Else Edit10.Text = Nothing
                    If Not IsDBNull(DtView1(0)("cnt2")) Then Number02.Value = DtView1(0)("cnt2") Else Number02.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt3")) Then Number03.Value = DtView1(0)("cnt3") Else Number03.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt4")) Then Number04.Value = DtView1(0)("cnt4") Else Number04.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt5")) Then Number05.Value = DtView1(0)("cnt5") Else Number05.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt6")) Then Number06.Value = DtView1(0)("cnt6") Else Number06.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt7")) Then Number07.Value = DtView1(0)("cnt7") Else Number07.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt8")) Then Number08.Value = DtView1(0)("cnt8") Else Number08.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt9")) Then Number09.Value = DtView1(0)("cnt9") Else Number09.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt10")) Then Number10.Value = DtView1(0)("cnt10") Else Number10.Value = 0
                    If Not IsDBNull(DtView1(0)("unit2")) Then Number12.Value = DtView1(0)("unit2") Else Number12.Value = 0
                    If Not IsDBNull(DtView1(0)("unit3")) Then Number13.Value = DtView1(0)("unit3") Else Number13.Value = 0
                    If Not IsDBNull(DtView1(0)("unit4")) Then Number14.Value = DtView1(0)("unit4") Else Number14.Value = 0
                    If Not IsDBNull(DtView1(0)("unit5")) Then Number15.Value = DtView1(0)("unit5") Else Number15.Value = 0
                    If Not IsDBNull(DtView1(0)("unit6")) Then Number16.Value = DtView1(0)("unit6") Else Number16.Value = 0
                    If Not IsDBNull(DtView1(0)("unit7")) Then Number17.Value = DtView1(0)("unit7") Else Number17.Value = 0
                    If Not IsDBNull(DtView1(0)("unit8")) Then Number18.Value = DtView1(0)("unit8") Else Number18.Value = 0
                    If Not IsDBNull(DtView1(0)("unit9")) Then Number19.Value = DtView1(0)("unit9") Else Number19.Value = 0
                    If Not IsDBNull(DtView1(0)("unit10")) Then Number20.Value = DtView1(0)("unit10") Else Number20.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt2")) Then Number22.Value = DtView1(0)("amnt2") Else Number22.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt3")) Then Number23.Value = DtView1(0)("amnt3") Else Number23.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt4")) Then Number24.Value = DtView1(0)("amnt4") Else Number24.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt5")) Then Number25.Value = DtView1(0)("amnt5") Else Number25.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt6")) Then Number26.Value = DtView1(0)("amnt6") Else Number26.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt7")) Then Number27.Value = DtView1(0)("amnt7") Else Number27.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt8")) Then Number28.Value = DtView1(0)("amnt8") Else Number28.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt9")) Then Number29.Value = DtView1(0)("amnt9") Else Number29.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt10")) Then Number30.Value = DtView1(0)("amnt10") Else Number30.Value = 0
                End If
            End If

        Else
            '********************
            '** メーカー請求
            '********************
            DsList1.Clear()
            If P_F60_1 = "0" Then   '新規
                If P_F60_2 = Nothing Then   '拠点まとめ
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_3m", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
                    Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 20)
                    Pram1.Value = P_F60_3
                    Pram2.Value = P_F60_4
                    Pram3.Value = P_EMPL_NAME

                Else
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_3", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
                    Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.DateTime)
                    Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p4", SqlDbType.Char, 20)
                    Pram1.Value = P_F60_3
                    Pram2.Value = P_F60_2
                    Pram3.Value = P_F60_4
                    Pram4.Value = P_EMPL_NAME
                End If
            Else                '再印刷
                If P_F60_2 = Nothing Then   '拠点まとめ
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_4m", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram1.Value = P_F60_1

                Else
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_4", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram1.Value = P_F60_1
                End If
            End If

            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "sp_F60_01")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("sp_F60_01"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                If Not IsDBNull(DtView1(0)("invc_rprt_ptn")) Then P_F60_9 = DtView1(0)("invc_rprt_ptn") Else P_F60_9 = "01" '印刷パターン
                If Not IsDBNull(DtView1(0)("invc_dtl_ptn")) Then P_F60_10 = DtView1(0)("invc_dtl_ptn") Else P_F60_10 = "01" '印刷パターン

                Select Case P_F60_9
                    Case Is = "03"  'Pana
                        Label6.Text = "〒224-0053"
                        Label11.Text = "神奈川県横浜市都筑区池辺町4458"
                        Label12.Text = "パナソニックシステムソリューションズジャパン株式会社" & "　御中"

                        Label25.Text = Nothing
                        Label18.Text = "〒141-0031"
                        Label19.Text = "東京都品川区西五反田７-２２-１７"
                        Label20.Text = "グローバルソリューションサービス株式会社"
                        Label21.Text = "TEL　03-5740-0196  FAX　03-5719-6148"

                    Case Else       '通常
                        If Not IsDBNull(DtView1(0)("invc_zip")) Then Label6.Text = "〒" & Mid(DtView1(0)("invc_zip"), 1, 3) & "-" & Mid(DtView1(0)("invc_zip"), 4, 4) Else Label6.Text = Nothing
                        If Not IsDBNull(DtView1(0)("invc_adrs1")) Then Label11.Text = DtView1(0)("invc_adrs1") Else Label11.Text = Nothing
                        If Not IsDBNull(DtView1(0)("invc_adrs2")) Then Label11.Text = Label11.Text & System.Environment.NewLine & DtView1(0)("invc_adrs2")
                        If Not IsDBNull(DtView1(0)("invc_name")) Then Label12.Text = DtView1(0)("invc_name") & "　御中" Else Label12.Text = Nothing

                        Label25.Text = "グローバルソリューションサービス株式会社"
                        If Not IsDBNull(DtView1(0)("brch_zip")) Then Label18.Text = "〒" & Mid(DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(DtView1(0)("brch_zip"), 4, 4) Else Label18.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_adrs1")) Then Label19.Text = DtView1(0)("brch_adrs1") Else Label19.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_adrs2")) Then Label19.Text = Label19.Text & "  " & DtView1(0)("brch_adrs2")
                        If Not IsDBNull(DtView1(0)("brch_name")) Then Label20.Text = DtView1(0)("brch_name") Else Label20.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_tel")) Then Label21.Text = "TEL " & DtView1(0)("brch_tel") Else Label21.Text = Nothing
                        If Not IsDBNull(DtView1(0)("brch_fax")) Then Label21.Text = Label21.Text & "  FAX " & DtView1(0)("brch_fax")

                End Select

                Number01.Value = DtView1(0)("cnt")
                Number21.Value = DtView1(0)("amnt1")

                If Not IsDBNull(DtView1(0)("bank_code")) Then CL002.Text = DtView1(0)("bank_code") Else CL002.Text = "0"
                WK_DtView1 = New DataView(DsCMB.Tables("M13_BANK_INFO"), "bank_code =" & CL002.Text, "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Combo002.Text = WK_DtView1(0)("bank_name")
                Else
                    Combo002.Text = Nothing
                End If
                If P_F60_9 = "03" Then  'pana
                    Label24.Visible = True : Edit5.Visible = True
                    If Not IsDBNull(DtView1(0)("invc_empl_name")) Then Edit5.Text = DtView1(0)("invc_empl_name") Else Edit5.Text = Nothing
                Else
                    Edit5.Text = Nothing : Label24.Visible = False : Edit5.Visible = False
                End If

                If P_F60_1 <> "0" Then   '再印刷
                    Edit1.Text = P_F60_1
                    If Not IsDBNull(DtView1(0)("dlvr_no")) Then Edit2.Text = DtView1(0)("dlvr_no") Else Edit2.Text = Nothing
                    If Not IsDBNull(DtView1(0)("etmt_no")) Then Edit3.Text = DtView1(0)("etmt_no") Else Edit3.Text = Nothing

                    If Not IsDBNull(DtView1(0)("article_name")) Then Edit0.Text = DtView1(0)("article_name") Else Edit0.Text = Nothing
                    If Not IsDBNull(DtView1(0)("memo")) Then Edit4.Text = DtView1(0)("memo") Else Edit4.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou1")) Then Edit01.Text = DtView1(0)("tekiyou1") Else Edit01.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou2")) Then Edit02.Text = DtView1(0)("tekiyou2") Else Edit02.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou3")) Then Edit03.Text = DtView1(0)("tekiyou3") Else Edit03.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou4")) Then Edit04.Text = DtView1(0)("tekiyou4") Else Edit04.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou5")) Then Edit05.Text = DtView1(0)("tekiyou5") Else Edit05.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou6")) Then Edit06.Text = DtView1(0)("tekiyou6") Else Edit06.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou7")) Then Edit07.Text = DtView1(0)("tekiyou7") Else Edit07.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou8")) Then Edit08.Text = DtView1(0)("tekiyou8") Else Edit08.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou9")) Then Edit09.Text = DtView1(0)("tekiyou9") Else Edit09.Text = Nothing
                    If Not IsDBNull(DtView1(0)("tekiyou10")) Then Edit10.Text = DtView1(0)("tekiyou10") Else Edit10.Text = Nothing
                    If Not IsDBNull(DtView1(0)("cnt2")) Then Number02.Value = DtView1(0)("cnt2") Else Number02.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt3")) Then Number03.Value = DtView1(0)("cnt3") Else Number03.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt4")) Then Number04.Value = DtView1(0)("cnt4") Else Number04.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt5")) Then Number05.Value = DtView1(0)("cnt5") Else Number05.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt6")) Then Number06.Value = DtView1(0)("cnt6") Else Number06.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt7")) Then Number07.Value = DtView1(0)("cnt7") Else Number07.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt8")) Then Number08.Value = DtView1(0)("cnt8") Else Number08.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt9")) Then Number09.Value = DtView1(0)("cnt9") Else Number09.Value = 0
                    If Not IsDBNull(DtView1(0)("cnt10")) Then Number10.Value = DtView1(0)("cnt10") Else Number10.Value = 0
                    If Not IsDBNull(DtView1(0)("unit2")) Then Number12.Value = DtView1(0)("unit2") Else Number12.Value = 0
                    If Not IsDBNull(DtView1(0)("unit3")) Then Number13.Value = DtView1(0)("unit3") Else Number13.Value = 0
                    If Not IsDBNull(DtView1(0)("unit4")) Then Number14.Value = DtView1(0)("unit4") Else Number14.Value = 0
                    If Not IsDBNull(DtView1(0)("unit5")) Then Number15.Value = DtView1(0)("unit5") Else Number15.Value = 0
                    If Not IsDBNull(DtView1(0)("unit6")) Then Number16.Value = DtView1(0)("unit6") Else Number16.Value = 0
                    If Not IsDBNull(DtView1(0)("unit7")) Then Number17.Value = DtView1(0)("unit7") Else Number17.Value = 0
                    If Not IsDBNull(DtView1(0)("unit8")) Then Number18.Value = DtView1(0)("unit8") Else Number18.Value = 0
                    If Not IsDBNull(DtView1(0)("unit9")) Then Number19.Value = DtView1(0)("unit9") Else Number19.Value = 0
                    If Not IsDBNull(DtView1(0)("unit10")) Then Number20.Value = DtView1(0)("unit10") Else Number20.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt2")) Then Number22.Value = DtView1(0)("amnt2") Else Number22.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt3")) Then Number23.Value = DtView1(0)("amnt3") Else Number23.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt4")) Then Number24.Value = DtView1(0)("amnt4") Else Number24.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt5")) Then Number25.Value = DtView1(0)("amnt5") Else Number25.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt6")) Then Number26.Value = DtView1(0)("amnt6") Else Number26.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt7")) Then Number27.Value = DtView1(0)("amnt7") Else Number27.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt8")) Then Number28.Value = DtView1(0)("amnt8") Else Number28.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt9")) Then Number29.Value = DtView1(0)("amnt9") Else Number29.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt10")) Then Number30.Value = DtView1(0)("amnt10") Else Number30.Value = 0
                End If
            End If
        End If
    End Sub

    Sub F_chk()
        Err_F = "0"
        msg.Text = Nothing

        '銀行
        If Trim(Combo002.Text) = Nothing Then
            msg.Text = "銀行口座の入力がありません。"
            Err_F = "1"
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M13_BANK_INFO"), "bank_name ='" & Trim(Combo002.Text) & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                CL002.Text = WK_DtView1(0)("bank_code")
            Else
                msg.Text = "銀行口座が違います。"
                Err_F = "1"
                CL002.Text = Nothing
            End If
        End If

        '担当
        If Edit5.Visible = True Then
            If Trim(Edit5.Text) = Nothing Then
                msg.Text = "担当の入力がありません。"
                Err_F = "1"
            End If
        End If

    End Sub

    '********************************************************************
    '**  印刷
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_HSTY_DATE = Now

        F_chk()
        If Err_F = "0" Then
            If P_F60_0 = "S" Then
                '********************
                '** 販社請求
                '********************
                If P_F60_1 = "0" Then   '新規
                    P_PRAM1 = Count_Get2()
                    Edit1.Text = P_PRAM1
                    P_F60_1 = P_PRAM1

                    DtView2 = New DataView(P_DsList1.Tables("scan"), "invc_code ='" & P_F60_3 & "' AND invc_no = 0", "", DataViewRowState.CurrentRows)
                    For i = 0 To DtView2.Count - 1
                        '請求データ作成
                        strSQL = "INSERT INTO T20_INVC_MTR"
                        strSQL = strSQL & " (iｎvc_no, rcpt_brch_code, cls, invc_code, invc_date, bf_amnt, amnt1, tax, ttl_amnt"
                        strSQL = strSQL & ", invc_amnt, cnt, tax_rate, dlvr_no, etmt_no, article_name"
                        strSQL = strSQL & ", cnt2, cnt3, cnt4, cnt5, cnt6, cnt7, cnt8, cnt9, cnt10"
                        strSQL = strSQL & ", unit2, unit3, unit4, unit5, unit6, unit7, unit8, unit9, unit10"
                        strSQL = strSQL & ", amnt2, amnt3, amnt4, amnt5, amnt6, amnt7, amnt8, amnt9, amnt10"
                        strSQL = strSQL & ", tekiyou1, tekiyou2, tekiyou3, tekiyou4, tekiyou5, tekiyou6, tekiyou7, tekiyou8, tekiyou9, tekiyou10"
                        strSQL = strSQL & ", memo, invc_empl_name, bank_code)"
                        strSQL = strSQL & " VALUES (" & P_PRAM1 & ""
                        strSQL = strSQL & ", '" & DtView2(i)("rcpt_brch_code") & "'"
                        strSQL = strSQL & ", '1'"
                        strSQL = strSQL & ", '" & P_F60_3 & "'"
                        strSQL = strSQL & ", CONVERT(DATETIME, '" & P_F60_4 & "', 102)"
                        strSQL = strSQL & ", 0"
                        strSQL = strSQL & ", " & DtView2(i)("amnt1")
                        strSQL = strSQL & ", " & DtView2(i)("tax")
                        strSQL = strSQL & ", " & DtView2(i)("ttl_amnt")
                        strSQL = strSQL & ", " & DtView2(i)("invc_amnt")
                        strSQL = strSQL & ", " & DtView2(i)("cnt")
                        strSQL = strSQL & ", " & DtView2(i)("tax_rate")
                        strSQL = strSQL & ", '" & Edit2.Text & "'"
                        strSQL = strSQL & ", '" & Edit3.Text & "'"
                        strSQL = strSQL & ", '" & Edit0.Text & "'"
                        strSQL = strSQL & ", " & Number02.Value & ""
                        strSQL = strSQL & ", " & Number03.Value & ""
                        strSQL = strSQL & ", " & Number04.Value & ""
                        strSQL = strSQL & ", " & Number05.Value & ""
                        strSQL = strSQL & ", " & Number06.Value & ""
                        strSQL = strSQL & ", " & Number07.Value & ""
                        strSQL = strSQL & ", " & Number08.Value & ""
                        strSQL = strSQL & ", " & Number09.Value & ""
                        strSQL = strSQL & ", " & Number10.Value & ""
                        strSQL = strSQL & ", " & Number12.Value & ""
                        strSQL = strSQL & ", " & Number13.Value & ""
                        strSQL = strSQL & ", " & Number14.Value & ""
                        strSQL = strSQL & ", " & Number15.Value & ""
                        strSQL = strSQL & ", " & Number16.Value & ""
                        strSQL = strSQL & ", " & Number17.Value & ""
                        strSQL = strSQL & ", " & Number18.Value & ""
                        strSQL = strSQL & ", " & Number19.Value & ""
                        strSQL = strSQL & ", " & Number20.Value & ""
                        strSQL = strSQL & ", " & Number22.Value & ""
                        strSQL = strSQL & ", " & Number23.Value & ""
                        strSQL = strSQL & ", " & Number24.Value & ""
                        strSQL = strSQL & ", " & Number25.Value & ""
                        strSQL = strSQL & ", " & Number26.Value & ""
                        strSQL = strSQL & ", " & Number27.Value & ""
                        strSQL = strSQL & ", " & Number28.Value & ""
                        strSQL = strSQL & ", " & Number29.Value & ""
                        strSQL = strSQL & ", " & Number30.Value & ""
                        strSQL = strSQL & ", '" & Edit01.Text & "'"
                        strSQL = strSQL & ", '" & Edit02.Text & "'"
                        strSQL = strSQL & ", '" & Edit03.Text & "'"
                        strSQL = strSQL & ", '" & Edit04.Text & "'"
                        strSQL = strSQL & ", '" & Edit05.Text & "'"
                        strSQL = strSQL & ", '" & Edit06.Text & "'"
                        strSQL = strSQL & ", '" & Edit07.Text & "'"
                        strSQL = strSQL & ", '" & Edit08.Text & "'"
                        strSQL = strSQL & ", '" & Edit09.Text & "'"
                        strSQL = strSQL & ", '" & Edit10.Text & "'"
                        strSQL = strSQL & ", '" & Edit4.Text & "'"
                        strSQL = strSQL & ", '" & Edit5.Text & "'"
                        strSQL = strSQL & ", " & CL002.Text & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        WK_DsList1.Clear()
                        SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_6", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
                        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 2)
                        Pram1.Value = P_F60_3
                        Pram2.Value = P_F60_4
                        Pram3.Value = DtView2(i)("rcpt_brch_code")
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        DaList1.Fill(WK_DsList1, "Print01")
                        DB_CLOSE()

                        DtView3 = New DataView(WK_DsList1.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
                        For j = 0 To DtView3.Count - 1
                            DB_OPEN("nMVAR")
                            '請求詳細データ作成
                            strSQL = "INSERT INTO T21_INVC_SUB"
                            strSQL = strSQL & " (iｎvc_no, brch_code, rcpt_no, invc_amnt, cxl_flg, fin_flg)"
                            strSQL = strSQL & " VALUES (" & P_PRAM1 & ""
                            strSQL = strSQL & ", '" & DtView3(j)("rcpt_brch_code") & "'"
                            strSQL = strSQL & ", '" & DtView3(j)("rcpt_no") & "'"
                            strSQL = strSQL & ", " & DtView3(j)("sals_amnt") & ""
                            strSQL = strSQL & ", 0, 0)"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()

                            '受付テーブルに請求日更新
                            strSQL = "UPDATE T01_REP_MTR"
                            strSQL = strSQL & " SET rqst_date = '" & P_F60_4 & "'"
                            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()

                            '売上データ請求済フラグON
                            strSQL = "UPDATE T10_SALS"
                            strSQL = strSQL & " SET invc_flg = 1"
                            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                            strSQL = strSQL & " AND (cls = '1')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()

                            '印刷履歴テーブル更新
                            strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(DsList1, "T06_PRNT_DATE")
                            DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
                            If DtView1.Count = 0 Then
                                strSQL = "INSERT INTO T06_PRNT_DATE"
                                strSQL = strSQL & " (rcpt_no, IVC)"
                                strSQL = strSQL & " VALUES ('" & DtView3(j)("rcpt_no") & "'"
                                strSQL = strSQL & ", '" & P_HSTY_DATE & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()
                            Else
                                If IsDBNull(DtView1(0)("IVC")) Then
                                    strSQL = "UPDATE T06_PRNT_DATE"
                                    strSQL = strSQL & " SET IVC = '" & P_HSTY_DATE & "'"
                                    strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.ExecuteNonQuery()
                                End If
                            End If
                            DB_CLOSE()

                            '変更履歴更新
                            WK_str = P_F60_4
                            add_hsty(DtView3(j)("rcpt_no"), "請求日", "", WK_str)

                        Next
                    Next

                Else                        '再印刷
                    P_PRAM1 = P_F60_1

                    '請求データ更新
                    strSQL = "UPDATE T20_INVC_MTR"
                    strSQL = strSQL & " SET dlvr_no = '" & Edit2.Text & "'"
                    strSQL = strSQL & ", etmt_no = '" & Edit3.Text & "'"
                    strSQL = strSQL & ", article_name = '" & Edit0.Text & "'"
                    strSQL = strSQL & ", cnt2 = " & Number02.Value & ""
                    strSQL = strSQL & ", cnt3 = " & Number03.Value & ""
                    strSQL = strSQL & ", cnt4 = " & Number04.Value & ""
                    strSQL = strSQL & ", cnt5 = " & Number05.Value & ""
                    strSQL = strSQL & ", cnt6 = " & Number06.Value & ""
                    strSQL = strSQL & ", cnt7 = " & Number07.Value & ""
                    strSQL = strSQL & ", cnt8 = " & Number08.Value & ""
                    strSQL = strSQL & ", cnt9 = " & Number09.Value & ""
                    strSQL = strSQL & ", cnt10 = " & Number10.Value & ""
                    strSQL = strSQL & ", unit2 = " & Number12.Value & ""
                    strSQL = strSQL & ", unit3 = " & Number13.Value & ""
                    strSQL = strSQL & ", unit4 = " & Number14.Value & ""
                    strSQL = strSQL & ", unit5 = " & Number15.Value & ""
                    strSQL = strSQL & ", unit6 = " & Number16.Value & ""
                    strSQL = strSQL & ", unit7 = " & Number17.Value & ""
                    strSQL = strSQL & ", unit8 = " & Number18.Value & ""
                    strSQL = strSQL & ", unit9 = " & Number19.Value & ""
                    strSQL = strSQL & ", unit10 = " & Number20.Value & ""
                    strSQL = strSQL & ", amnt2 = " & Number22.Value & ""
                    strSQL = strSQL & ", amnt3 = " & Number23.Value & ""
                    strSQL = strSQL & ", amnt4 = " & Number24.Value & ""
                    strSQL = strSQL & ", amnt5 = " & Number25.Value & ""
                    strSQL = strSQL & ", amnt6 = " & Number26.Value & ""
                    strSQL = strSQL & ", amnt7 = " & Number27.Value & ""
                    strSQL = strSQL & ", amnt8 = " & Number28.Value & ""
                    strSQL = strSQL & ", amnt9 = " & Number29.Value & ""
                    strSQL = strSQL & ", amnt10 = " & Number30.Value & ""
                    strSQL = strSQL & ", tekiyou1 = '" & Edit01.Text & "'"
                    strSQL = strSQL & ", tekiyou2 = '" & Edit02.Text & "'"
                    strSQL = strSQL & ", tekiyou3 = '" & Edit03.Text & "'"
                    strSQL = strSQL & ", tekiyou4 = '" & Edit04.Text & "'"
                    strSQL = strSQL & ", tekiyou5 = '" & Edit05.Text & "'"
                    strSQL = strSQL & ", tekiyou6 = '" & Edit06.Text & "'"
                    strSQL = strSQL & ", tekiyou7 = '" & Edit07.Text & "'"
                    strSQL = strSQL & ", tekiyou8 = '" & Edit08.Text & "'"
                    strSQL = strSQL & ", tekiyou9 = '" & Edit09.Text & "'"
                    strSQL = strSQL & ", tekiyou10 = '" & Edit10.Text & "'"
                    strSQL = strSQL & ", memo = '" & Edit4.Text & "'"
                    strSQL = strSQL & ", invc_empl_name = '" & Edit5.Text & "'"
                    strSQL = strSQL & ", bank_code = " & CL002.Text & ""
                    strSQL = strSQL & " WHERE (iｎvc_no = " & P_PRAM1 & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nMVAR")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If

                '********************
                '** 印刷
                '********************
                WK_DsList1.Clear()
                If P_F60_2 = Nothing Then   '拠点まとめ
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_2m", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram1.Value = P_F60_1

                Else
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_2", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram5.Value = P_F60_1
                End If
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "WK_prt")
                DB_CLOSE()

                DtView2 = New DataView(WK_DsList1.Tables("WK_prt"), "", "", DataViewRowState.CurrentRows)

                P_DsPRT.Clear()
                strSQL = "SELECT " & P_PRAM1 & " AS invc_no"
                strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("invc_zip"), 1, 3) & "-" & Mid(DtView2(0)("invc_zip"), 4, 4) & "' AS invc_zip"
                strSQL = strSQL & ", '" & DtView2(0)("invc_adrs1") & System.Environment.NewLine & DtView2(0)("invc_adrs2") & "' AS invc_adrs"

                If P_idvd_flg = "True" Then
                    strSQL = strSQL & ", '" & DtView2(0)("invc_name") & "　様' AS invc_name"
                Else
                    strSQL = strSQL & ", '" & DtView2(0)("invc_name") & "　御中' AS invc_name"
                End If

                strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("brch_zip"), 1, 3) & "-" & Mid(DtView2(0)("brch_zip"), 4, 4) & "' AS brch_zip"
                strSQL = strSQL & ", '" & DtView2(0)("brch_adrs1") & System.Environment.NewLine & DtView2(0)("brch_adrs2") & "' AS brch_adrs"
                strSQL = strSQL & ", '" & DtView2(0)("brch_name") & "' AS brch_name"
                strSQL = strSQL & ", 'TEL " & DtView2(0)("brch_tel") & "  FAX " & DtView2(0)("brch_fax") & "' AS brch_tel"

                strSQL = strSQL & ", '" & DtView2(0)("bank_user") & "' AS bank_user"

                If Not IsDBNull(DtView2(0)("bank_kbn")) Then
                    If DtView2(0)("bank_kbn") = "普通預金" Then
                        strSQL = strSQL & ", '" & DtView2(0)("bank_name") & "　" & DtView2(0)("bank_sub") & "　(普)　NO." & DtView2(0)("bank_acnt_no") & "' AS bank_name"
                    Else
                        strSQL = strSQL & ", '" & DtView2(0)("bank_name") & "　" & DtView2(0)("bank_sub") & "　(当)　NO." & DtView2(0)("bank_acnt_no") & "' AS bank_name"
                    End If
                End If

                strSQL = strSQL & ", '" & DtView2(0)("dlvr_no") & "' AS dlvr_no"            '納品書番号
                strSQL = strSQL & ", '" & DtView2(0)("etmt_no") & "' AS etmt_no"            '貴社見積番号
                strSQL = strSQL & ", '" & DtView2(0)("article_name") & "' AS article_name"  '品名
                strSQL = strSQL & ", '" & DtView2(0)("memo") & "' AS memo"                  'メモ
                strSQL = strSQL & ", '" & DtView2(0)("invc_empl_name") & "' AS empl_name"        '請求担当

                strSQL = strSQL & ", " & Number01.Value & " AS cnt1"                        '個数
                strSQL = strSQL & ", " & DtView2(0)("cnt2") & " AS cnt2"
                strSQL = strSQL & ", " & DtView2(0)("cnt3") & " AS cnt3"
                strSQL = strSQL & ", " & DtView2(0)("cnt4") & " AS cnt4"
                strSQL = strSQL & ", " & DtView2(0)("cnt5") & " AS cnt5"
                strSQL = strSQL & ", " & DtView2(0)("cnt6") & " AS cnt6"
                strSQL = strSQL & ", " & DtView2(0)("cnt7") & " AS cnt7"
                strSQL = strSQL & ", " & DtView2(0)("cnt8") & " AS cnt8"
                strSQL = strSQL & ", " & DtView2(0)("cnt9") & " AS cnt9"
                strSQL = strSQL & ", " & DtView2(0)("cnt10") & " AS cnt10"
                strSQL = strSQL & ", " & DtView2(0)("unit2") & " AS unit2"                  '単価
                strSQL = strSQL & ", " & DtView2(0)("unit3") & " AS unit3"
                strSQL = strSQL & ", " & DtView2(0)("unit4") & " AS unit4"
                strSQL = strSQL & ", " & DtView2(0)("unit5") & " AS unit5"
                strSQL = strSQL & ", " & DtView2(0)("unit6") & " AS unit6"
                strSQL = strSQL & ", " & DtView2(0)("unit7") & " AS unit7"
                strSQL = strSQL & ", " & DtView2(0)("unit8") & " AS unit8"
                strSQL = strSQL & ", " & DtView2(0)("unit9") & " AS unit9"
                strSQL = strSQL & ", " & DtView2(0)("unit10") & " AS unit10"
                If DtView2(0)("amnt1") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt1"), "##,##0") & "' AS amnt1"               '金額
                Else
                    strSQL = strSQL & ", '' AS amnt1"
                End If
                amt_sum = DtView2(0)("amnt1")

                If DtView2(0)("amnt2") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt2"), "##,##0") & "' AS amnt2"
                Else
                    strSQL = strSQL & ", '' AS amnt2"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt2")
                If DtView2(0)("amnt3") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt3"), "##,##0") & "' AS amnt3"
                Else
                    strSQL = strSQL & ", '' AS amnt3"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt3")
                If DtView2(0)("amnt4") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt4"), "##,##0") & "' AS amnt4"
                Else
                    strSQL = strSQL & ", '' AS amnt4"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt4")
                If DtView2(0)("amnt5") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt5"), "##,##0") & "' AS amnt5"
                Else
                    strSQL = strSQL & ", '' AS amnt5"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt5")
                If DtView2(0)("amnt6") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt6"), "##,##0") & "' AS amnt6"
                Else
                    strSQL = strSQL & ", '' AS amnt6"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt6")
                If DtView2(0)("amnt7") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt7"), "##,##0") & "' AS amnt7"
                Else
                    strSQL = strSQL & ", '' AS amnt7"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt7")
                If DtView2(0)("amnt8") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt8"), "##,##0") & "' AS amnt8"
                Else
                    strSQL = strSQL & ", '' AS amnt8"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt8")
                If DtView2(0)("amnt9") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt9"), "##,##0") & "' AS amnt9"
                Else
                    strSQL = strSQL & ", '' AS amnt9"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt9")
                If DtView2(0)("amnt10") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt10"), "##,##0") & "' AS amnt10"
                Else
                    strSQL = strSQL & ", '' AS amnt10"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt10")

                strSQL = strSQL & ", " & amt_sum & " AS sttl"
                strSQL = strSQL & ", " & RoundDOWN(amt_sum * 0.1, 0) & " AS tax"
                strSQL = strSQL & ", " & amt_sum + RoundDOWN(amt_sum * 0.1, 0) & " AS gttl"

                strSQL = strSQL & ", '" & DtView2(0)("tekiyou1") & "' AS tekiyou1"              '摘要
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou2") & "' AS tekiyou2"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou3") & "' AS tekiyou3"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou4") & "' AS tekiyou4"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou5") & "' AS tekiyou5"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou6") & "' AS tekiyou6"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou7") & "' AS tekiyou7"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou8") & "' AS tekiyou8"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou9") & "' AS tekiyou9"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou10") & "' AS tekiyou10"

                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(P_DsPRT, "prt")

                '請求書
                P_PView = "ivc"

                Dim Print_View As New Print_View
                Print_View.ShowDialog()

                '請求明細
                P_DsPRT.Clear()
                strSQL = "SELECT T20_INVC_MTR.iｎvc_no, T20_INVC_MTR.invc_code, M08_STORE.name AS invc_name, T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no, T01_REP_MTR.store_repr_no, T01_REP_MTR.vndr_code, M05_VNDR.name AS vndr_name, T01_REP_MTR.user_name, T01_REP_MTR.sals_no, T21_INVC_SUB.invc_amnt, M08_STORE.invc_dtl_ptn, T20_INVC_MTR.invc_date, T20_INVC_MTR.rcpt_brch_code, M03_BRCH.name AS rcpt_brch_name, T01_REP_MTR.store_code, M08_STORE_1.name AS store_name, T01_REP_MTR.kjo_brch_code, M03_BRCH_1.name AS kjo_brch_name, T01_REP_MTR.accp_date, M08_STORE.cls_date, T01_REP_MTR.model_1"
                strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
                strSQL = strSQL & " T21_INVC_SUB ON T20_INVC_MTR.iｎvc_no = T21_INVC_SUB.iｎvc_no AND"
                strSQL = strSQL & " T20_INVC_MTR.rcpt_brch_code = T21_INVC_SUB.brch_code INNER JOIN"
                strSQL = strSQL & " T01_REP_MTR ON T21_INVC_SUB.rcpt_no = T01_REP_MTR.rcpt_no INNER JOIN"
                strSQL = strSQL & " M05_VNDR ON T01_REP_MTR.vndr_code = M05_VNDR.vndr_code INNER JOIN"
                strSQL = strSQL & " M08_STORE ON T20_INVC_MTR.invc_code = M08_STORE.store_code INNER JOIN"
                strSQL = strSQL & " M08_STORE AS M08_STORE_1 ON T01_REP_MTR.store_code = M08_STORE_1.store_code INNER JOIN"
                strSQL = strSQL & " M03_BRCH ON T20_INVC_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
                strSQL = strSQL & " M03_BRCH AS M03_BRCH_1 ON T01_REP_MTR.kjo_brch_code = M03_BRCH_1.brch_code"
                strSQL = strSQL & " WHERE (T20_INVC_MTR.iｎvc_no = " & P_F60_1 & ")"
                Select Case P_F60_10
                    Case Is = "02"  '汎用2
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    Case Is = "03"  'ジョーシンサービス
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.vndr_code, T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    Case Is = "04"  'ケーズデンキ
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    Case Is = "05"  'デオデオ
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    Case Is = "06"  'ベスト
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.store_code, T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    Case Is = "07"  'ヨドバシカメラ
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    Case Is = "08"  'コジマ
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    Case Else       '汎用
                        strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                End Select
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                r = DaList1.Fill(P_DsPRT, "prt")
                DB_CLOSE()

                If r <> 0 Then
                    '請求明細
                    P_PView = "DTL"

                    Dim Print_View2 As New Print_View
                    Print_View2.ShowDialog()
                End If

            Else
                '********************
                '** メーカー請求
                '********************
                If P_F60_1 = "0" Then   '新規
                    P_PRAM1 = Count_Get2()
                    Edit1.Text = P_PRAM1
                    P_F60_1 = P_PRAM1

                    DtView2 = New DataView(P_DsList1.Tables("scan"), "vndr_code ='" & P_F60_3 & "' AND invc_no = 0", "", DataViewRowState.CurrentRows)
                    For i = 0 To DtView2.Count - 1
                        '請求データ作成
                        strSQL = "INSERT INTO T20_INVC_MTR"
                        strSQL = strSQL & " (iｎvc_no, rcpt_brch_code, cls, vndr_code, invc_date, bf_amnt, amnt1, tax, ttl_amnt, invc_amnt"
                        strSQL = strSQL & ", cnt, tax_rate, dlvr_no, etmt_no, article_name"
                        strSQL = strSQL & ", cnt2, cnt3, cnt4, cnt5, cnt6, cnt7, cnt8, cnt9, cnt10"
                        strSQL = strSQL & ", unit2, unit3, unit4, unit5, unit6, unit7, unit8, unit9, unit10"
                        strSQL = strSQL & ", amnt2, amnt3, amnt4, amnt5, amnt6, amnt7, amnt8, amnt9, amnt10"
                        strSQL = strSQL & ", tekiyou1, tekiyou2, tekiyou3, tekiyou4, tekiyou5, tekiyou6, tekiyou7, tekiyou8, tekiyou9, tekiyou10"
                        strSQL = strSQL & ", memo, invc_empl_name, bank_code)"
                        strSQL = strSQL & " VALUES (" & P_PRAM1 & ""
                        strSQL = strSQL & ", '" & DtView2(i)("rcpt_brch_code") & "'"
                        strSQL = strSQL & ", '3'"
                        strSQL = strSQL & ", '" & P_F60_3 & "'"
                        strSQL = strSQL & ", CONVERT(DATETIME, '" & P_F60_4 & "', 102)"
                        strSQL = strSQL & ", " & DtView2(i)("bf_amnt")
                        strSQL = strSQL & ", " & DtView2(i)("amnt1")
                        strSQL = strSQL & ", " & DtView2(i)("tax")
                        strSQL = strSQL & ", " & DtView2(i)("ttl_amnt")
                        strSQL = strSQL & ", " & DtView2(i)("invc_amnt")
                        strSQL = strSQL & ", " & DtView2(i)("cnt")
                        strSQL = strSQL & ", " & DtView2(i)("tax_rate")
                        strSQL = strSQL & ", '" & Edit2.Text & "'"
                        strSQL = strSQL & ", '" & Edit3.Text & "'"
                        strSQL = strSQL & ", '" & Edit0.Text & "'"
                        strSQL = strSQL & ", " & Number02.Value & ""
                        strSQL = strSQL & ", " & Number03.Value & ""
                        strSQL = strSQL & ", " & Number04.Value & ""
                        strSQL = strSQL & ", " & Number05.Value & ""
                        strSQL = strSQL & ", " & Number06.Value & ""
                        strSQL = strSQL & ", " & Number07.Value & ""
                        strSQL = strSQL & ", " & Number08.Value & ""
                        strSQL = strSQL & ", " & Number09.Value & ""
                        strSQL = strSQL & ", " & Number10.Value & ""
                        strSQL = strSQL & ", " & Number12.Value & ""
                        strSQL = strSQL & ", " & Number13.Value & ""
                        strSQL = strSQL & ", " & Number14.Value & ""
                        strSQL = strSQL & ", " & Number15.Value & ""
                        strSQL = strSQL & ", " & Number16.Value & ""
                        strSQL = strSQL & ", " & Number17.Value & ""
                        strSQL = strSQL & ", " & Number18.Value & ""
                        strSQL = strSQL & ", " & Number19.Value & ""
                        strSQL = strSQL & ", " & Number20.Value & ""
                        strSQL = strSQL & ", " & Number22.Value & ""
                        strSQL = strSQL & ", " & Number23.Value & ""
                        strSQL = strSQL & ", " & Number24.Value & ""
                        strSQL = strSQL & ", " & Number25.Value & ""
                        strSQL = strSQL & ", " & Number26.Value & ""
                        strSQL = strSQL & ", " & Number27.Value & ""
                        strSQL = strSQL & ", " & Number28.Value & ""
                        strSQL = strSQL & ", " & Number29.Value & ""
                        strSQL = strSQL & ", " & Number30.Value & ""
                        strSQL = strSQL & ", '" & Edit01.Text & "'"
                        strSQL = strSQL & ", '" & Edit02.Text & "'"
                        strSQL = strSQL & ", '" & Edit03.Text & "'"
                        strSQL = strSQL & ", '" & Edit04.Text & "'"
                        strSQL = strSQL & ", '" & Edit05.Text & "'"
                        strSQL = strSQL & ", '" & Edit06.Text & "'"
                        strSQL = strSQL & ", '" & Edit07.Text & "'"
                        strSQL = strSQL & ", '" & Edit08.Text & "'"
                        strSQL = strSQL & ", '" & Edit09.Text & "'"
                        strSQL = strSQL & ", '" & Edit10.Text & "'"
                        strSQL = strSQL & ", '" & Edit4.Text & "'"
                        strSQL = strSQL & ", '" & Edit5.Text & "'"
                        strSQL = strSQL & ", " & CL002.Text & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        WK_DsList1.Clear()
                        SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_7", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
                        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 2)
                        Pram1.Value = P_F60_3
                        Pram2.Value = P_F60_4
                        Pram3.Value = DtView2(i)("rcpt_brch_code")
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        DaList1.Fill(WK_DsList1, "Print01")
                        DB_CLOSE()

                        DtView3 = New DataView(WK_DsList1.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
                        For j = 0 To DtView3.Count - 1
                            DB_OPEN("nMVAR")
                            '請求詳細データ作成
                            strSQL = "INSERT INTO T21_INVC_SUB"
                            strSQL = strSQL & " (iｎvc_no, brch_code, rcpt_no, invc_amnt, cxl_flg, fin_flg)"
                            strSQL = strSQL & " VALUES (" & P_PRAM1 & ""
                            strSQL = strSQL & ", '" & DtView3(j)("rcpt_brch_code") & "'"
                            strSQL = strSQL & ", '" & DtView3(j)("rcpt_no") & "'"
                            strSQL = strSQL & ", " & DtView3(j)("sals_amnt") & ""
                            strSQL = strSQL & ", 0, 0)"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()

                            '受付テーブルに請求日更新
                            strSQL = "UPDATE T01_REP_MTR"
                            strSQL = strSQL & " SET rqst_date = '" & P_F60_4 & "'"
                            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()

                            '売上データ請求済フラグON
                            strSQL = "UPDATE T10_SALS"
                            strSQL = strSQL & " SET invc_flg = 1"
                            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                            strSQL = strSQL & " AND (cls = '3')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()

                            '印刷履歴テーブル更新
                            strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(DsList1, "T06_PRNT_DATE")
                            DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
                            If DtView1.Count = 0 Then
                                strSQL = "INSERT INTO T06_PRNT_DATE"
                                strSQL = strSQL & " (rcpt_no, IVC)"
                                strSQL = strSQL & " VALUES ('" & DtView3(j)("rcpt_no") & "'"
                                strSQL = strSQL & ", '" & P_HSTY_DATE & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()
                            Else
                                If IsDBNull(DtView1(0)("IVC")) Then
                                    strSQL = "UPDATE T06_PRNT_DATE"
                                    strSQL = strSQL & " SET IVC = '" & P_HSTY_DATE & "'"
                                    strSQL = strSQL & " WHERE (rcpt_no = '" & DtView3(j)("rcpt_no") & "')"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.ExecuteNonQuery()
                                End If
                            End If
                            DB_CLOSE()

                            '変更履歴更新
                            WK_str = P_F60_6
                            add_hsty(DtView3(j)("rcpt_no"), "請求日", "", WK_str)

                        Next
                    Next
                Else                        '再印刷
                    P_PRAM1 = P_F60_1

                    '請求データ更新
                    strSQL = "UPDATE T20_INVC_MTR"
                    strSQL = strSQL & " SET dlvr_no = '" & Edit2.Text & "'"
                    strSQL = strSQL & ", etmt_no = '" & Edit3.Text & "'"
                    strSQL = strSQL & ", article_name = '" & Edit0.Text & "'"
                    strSQL = strSQL & ", cnt2 = " & Number02.Value & ""
                    strSQL = strSQL & ", cnt3 = " & Number03.Value & ""
                    strSQL = strSQL & ", cnt4 = " & Number04.Value & ""
                    strSQL = strSQL & ", cnt5 = " & Number05.Value & ""
                    strSQL = strSQL & ", cnt6 = " & Number06.Value & ""
                    strSQL = strSQL & ", cnt7 = " & Number07.Value & ""
                    strSQL = strSQL & ", cnt8 = " & Number08.Value & ""
                    strSQL = strSQL & ", cnt9 = " & Number09.Value & ""
                    strSQL = strSQL & ", cnt10 = " & Number10.Value & ""
                    strSQL = strSQL & ", unit2 = " & Number12.Value & ""
                    strSQL = strSQL & ", unit3 = " & Number13.Value & ""
                    strSQL = strSQL & ", unit4 = " & Number14.Value & ""
                    strSQL = strSQL & ", unit5 = " & Number15.Value & ""
                    strSQL = strSQL & ", unit6 = " & Number16.Value & ""
                    strSQL = strSQL & ", unit7 = " & Number17.Value & ""
                    strSQL = strSQL & ", unit8 = " & Number18.Value & ""
                    strSQL = strSQL & ", unit9 = " & Number19.Value & ""
                    strSQL = strSQL & ", unit10 = " & Number10.Value & ""
                    strSQL = strSQL & ", amnt2 = " & Number22.Value & ""
                    strSQL = strSQL & ", amnt3 = " & Number23.Value & ""
                    strSQL = strSQL & ", amnt4 = " & Number24.Value & ""
                    strSQL = strSQL & ", amnt5 = " & Number25.Value & ""
                    strSQL = strSQL & ", amnt6 = " & Number26.Value & ""
                    strSQL = strSQL & ", amnt7 = " & Number27.Value & ""
                    strSQL = strSQL & ", amnt8 = " & Number28.Value & ""
                    strSQL = strSQL & ", amnt9 = " & Number29.Value & ""
                    strSQL = strSQL & ", amnt10 = " & Number30.Value & ""
                    strSQL = strSQL & ", tekiyou1 = '" & Edit01.Text & "'"
                    strSQL = strSQL & ", tekiyou2 = '" & Edit02.Text & "'"
                    strSQL = strSQL & ", tekiyou3 = '" & Edit03.Text & "'"
                    strSQL = strSQL & ", tekiyou4 = '" & Edit04.Text & "'"
                    strSQL = strSQL & ", tekiyou5 = '" & Edit05.Text & "'"
                    strSQL = strSQL & ", tekiyou6 = '" & Edit06.Text & "'"
                    strSQL = strSQL & ", tekiyou7 = '" & Edit07.Text & "'"
                    strSQL = strSQL & ", tekiyou8 = '" & Edit08.Text & "'"
                    strSQL = strSQL & ", tekiyou9 = '" & Edit09.Text & "'"
                    strSQL = strSQL & ", tekiyou10 = '" & Edit10.Text & "'"
                    strSQL = strSQL & ", memo = '" & Edit4.Text & "'"
                    strSQL = strSQL & ", invc_empl_name = '" & Edit5.Text & "'"
                    strSQL = strSQL & ", bank_code = " & CL002.Text & ""
                    strSQL = strSQL & " WHERE (invc_no = " & P_PRAM1 & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DB_OPEN("nMVAR")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If

                '********************
                '** 印刷
                '********************
                WK_DsList1.Clear()
                If P_F60_2 = Nothing Then   '拠点まとめ
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_5m", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram5.Value = P_F60_1
                Else
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_01_5", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
                    Pram5.Value = P_F60_1
                End If
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "WK_prt")
                DB_CLOSE()

                DtView2 = New DataView(WK_DsList1.Tables("WK_prt"), "", "", DataViewRowState.CurrentRows)

                P_DsPRT.Clear()
                strSQL = "SELECT " & P_PRAM1 & " AS invc_no"
                If Not IsDBNull(DtView2(0)("zip")) Then
                    strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("zip"), 1, 3) & "-" & Mid(DtView2(0)("zip"), 4, 4) & "' AS invc_zip"
                Else
                    strSQL = strSQL & ", '〒' AS invc_zip"
                End If
                strSQL = strSQL & ", '" & DtView2(0)("adrs1") & System.Environment.NewLine & DtView2(0)("adrs2") & "' AS invc_adrs"
                strSQL = strSQL & ", '" & DtView2(0)("invc_name") & "　御中' AS invc_name"
                strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("brch_zip"), 1, 3) & "-" & Mid(DtView2(0)("brch_zip"), 4, 4) & "' AS brch_zip"
                strSQL = strSQL & ", '" & DtView2(0)("brch_adrs1") & System.Environment.NewLine & DtView2(0)("brch_adrs2") & "' AS brch_adrs"
                strSQL = strSQL & ", '" & DtView2(0)("brch_name") & "' AS brch_name"
                strSQL = strSQL & ", 'TEL " & DtView2(0)("brch_tel") & "  FAX " & DtView2(0)("brch_fax") & "' AS brch_tel"

                strSQL = strSQL & ", '" & DtView2(0)("bank_user") & "' AS bank_user"

                If Not IsDBNull(DtView2(0)("bank_kbn")) Then
                    If DtView2(0)("bank_kbn") = "普通預金" Then
                        strSQL = strSQL & ", '" & DtView2(0)("bank_name") & "　" & DtView2(0)("bank_sub") & "　(普)　NO." & DtView2(0)("bank_acnt_no") & "' AS bank_name"
                    Else
                        strSQL = strSQL & ", '" & DtView2(0)("bank_name") & "　" & DtView2(0)("bank_sub") & "　(当)　NO." & DtView2(0)("bank_acnt_no") & "' AS bank_name"
                    End If
                End If

                strSQL = strSQL & ", '" & DtView2(0)("dlvr_no") & "' AS dlvr_no"            '納品書番号
                strSQL = strSQL & ", '" & DtView2(0)("etmt_no") & "' AS etmt_no"            '貴社見積番号
                strSQL = strSQL & ", '" & DtView2(0)("article_name") & "' AS article_name"  '品名
                strSQL = strSQL & ", '" & DtView2(0)("memo") & "' AS memo"                  'メモ
                strSQL = strSQL & ", '" & DtView2(0)("invc_empl_name") & "' AS empl_name"        '請求担当

                strSQL = strSQL & ", " & Number01.Value & " AS cnt1"                        '個数
                strSQL = strSQL & ", " & DtView2(0)("cnt2") & " AS cnt2"
                strSQL = strSQL & ", " & DtView2(0)("cnt3") & " AS cnt3"
                strSQL = strSQL & ", " & DtView2(0)("cnt4") & " AS cnt4"
                strSQL = strSQL & ", " & DtView2(0)("cnt5") & " AS cnt5"
                strSQL = strSQL & ", " & DtView2(0)("cnt6") & " AS cnt6"
                strSQL = strSQL & ", " & DtView2(0)("cnt7") & " AS cnt7"
                strSQL = strSQL & ", " & DtView2(0)("cnt8") & " AS cnt8"
                strSQL = strSQL & ", " & DtView2(0)("cnt9") & " AS cnt9"
                strSQL = strSQL & ", " & DtView2(0)("cnt10") & " AS cnt10"
                strSQL = strSQL & ", " & DtView2(0)("unit2") & " AS unit2"                  '単価
                strSQL = strSQL & ", " & DtView2(0)("unit3") & " AS unit3"
                strSQL = strSQL & ", " & DtView2(0)("unit4") & " AS unit4"
                strSQL = strSQL & ", " & DtView2(0)("unit5") & " AS unit5"
                strSQL = strSQL & ", " & DtView2(0)("unit6") & " AS unit6"
                strSQL = strSQL & ", " & DtView2(0)("unit7") & " AS unit7"
                strSQL = strSQL & ", " & DtView2(0)("unit8") & " AS unit8"
                strSQL = strSQL & ", " & DtView2(0)("unit9") & " AS unit9"
                strSQL = strSQL & ", " & DtView2(0)("unit10") & " AS unit10"
                If DtView2(0)("amnt1") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt1"), "##,##0") & "' AS amnt1"               '金額
                Else
                    strSQL = strSQL & ", '' AS amnt1"
                End If
                amt_sum = DtView2(0)("amnt1")

                If DtView2(0)("amnt2") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt2"), "##,##0") & "' AS amnt2"
                Else
                    strSQL = strSQL & ", '' AS amnt2"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt2")
                If DtView2(0)("amnt3") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt3"), "##,##0") & "' AS amnt3"
                Else
                    strSQL = strSQL & ", '' AS amnt3"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt3")
                If DtView2(0)("amnt4") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt4"), "##,##0") & "' AS amnt4"
                Else
                    strSQL = strSQL & ", '' AS amnt4"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt4")
                If DtView2(0)("amnt5") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt5"), "##,##0") & "' AS amnt5"
                Else
                    strSQL = strSQL & ", '' AS amnt5"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt5")
                If DtView2(0)("amnt6") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt6"), "##,##0") & "' AS amnt6"
                Else
                    strSQL = strSQL & ", '' AS amnt6"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt6")
                If DtView2(0)("amnt7") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt7"), "##,##0") & "' AS amnt7"
                Else
                    strSQL = strSQL & ", '' AS amnt7"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt7")
                If DtView2(0)("amnt8") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt8"), "##,##0") & "' AS amnt8"
                Else
                    strSQL = strSQL & ", '' AS amnt8"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt8")
                If DtView2(0)("amnt9") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt9"), "##,##0") & "' AS amnt9"
                Else
                    strSQL = strSQL & ", '' AS amnt9"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt9")
                If DtView2(0)("amnt10") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt10"), "##,##0") & "' AS amnt10"
                Else
                    strSQL = strSQL & ", '' AS amnt10"
                End If
                amt_sum = amt_sum + DtView2(0)("amnt10")

                strSQL = strSQL & ", " & amt_sum & " AS sttl"
                strSQL = strSQL & ", " & RoundDOWN(amt_sum * 0.1, 0) & " AS tax"
                strSQL = strSQL & ", " & amt_sum + RoundDOWN(amt_sum * 0.1, 0) & " AS gttl"

                strSQL = strSQL & ", '" & DtView2(0)("tekiyou1") & "' AS tekiyou1"              '摘要
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou2") & "' AS tekiyou2"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou3") & "' AS tekiyou3"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou4") & "' AS tekiyou4"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou5") & "' AS tekiyou5"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou6") & "' AS tekiyou6"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou7") & "' AS tekiyou7"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou8") & "' AS tekiyou8"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou9") & "' AS tekiyou9"
                strSQL = strSQL & ", '" & DtView2(0)("tekiyou10") & "' AS tekiyou10"

                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(P_DsPRT, "prt")

                '請求書
                P_PView = "ivc"

                Dim Print_View As New Print_View
                Print_View.ShowDialog()

                '請求明細
                If P_F60_10 = "00" Then
                Else
                    P_DsPRT.Clear()
                    strSQL = "SELECT T20_INVC_MTR.iｎvc_no, T20_INVC_MTR.vndr_code AS invc_code, M05_VNDR.name_invc AS invc_name, T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no, T01_REP_MTR.store_repr_no, T20_INVC_MTR.vndr_code, M05_VNDR.name AS vndr_name, T01_REP_MTR.user_name, T01_REP_MTR.sals_no, T21_INVC_SUB.invc_amnt, M08_STORE.invc_dtl_ptn, T20_INVC_MTR.invc_date, T20_INVC_MTR.rcpt_brch_code, M03_BRCH.name AS rcpt_brch_name, T01_REP_MTR.store_code, M08_STORE_1.name AS store_name, T01_REP_MTR.kjo_brch_code, M03_BRCH_1.name AS kjo_brch_name, T01_REP_MTR.accp_date"
                    strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
                    strSQL = strSQL & " T21_INVC_SUB ON T20_INVC_MTR.iｎvc_no = T21_INVC_SUB.iｎvc_no AND"
                    strSQL = strSQL & " T20_INVC_MTR.rcpt_brch_code = T21_INVC_SUB.brch_code INNER JOIN"
                    strSQL = strSQL & " T01_REP_MTR ON T21_INVC_SUB.rcpt_no = T01_REP_MTR.rcpt_no INNER JOIN"
                    strSQL = strSQL & " M05_VNDR ON T20_INVC_MTR.vndr_code = M05_VNDR.vndr_code INNER JOIN"
                    strSQL = strSQL & " M08_STORE AS M08_STORE_1 ON T01_REP_MTR.store_code = M08_STORE_1.store_code INNER JOIN"
                    strSQL = strSQL & " M08_STORE ON M08_STORE_1.invc_code = M08_STORE.store_code INNER JOIN"
                    strSQL = strSQL & " M03_BRCH ON T20_INVC_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
                    strSQL = strSQL & " M03_BRCH AS M03_BRCH_1 ON T01_REP_MTR.kjo_brch_code = M03_BRCH_1.brch_code"
                    strSQL = strSQL & " WHERE (T20_INVC_MTR.iｎvc_no = " & P_F60_1 & ")"
                    strSQL = strSQL & " ORDER BY T01_REP_MTR.comp_date, T21_INVC_SUB.rcpt_no"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN("nMVAR")
                    r = DaList1.Fill(P_DsPRT, "prt")
                    DB_CLOSE()

                    If r <> 0 Then
                        '請求明細
                        P_PView = "DTL"

                        Dim Print_View2 As New Print_View
                        Print_View2.ShowDialog()
                    End If
                End If

            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit0_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit0.GotFocus
        Edit0.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit2.GotFocus
        Edit2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.GotFocus
        Edit3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit4.GotFocus
        Edit4.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit5.GotFocus
        Edit5.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number02_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.GotFocus
        Number02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number03_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03.GotFocus
        Number03.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number04_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04.GotFocus
        Number04.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number05_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05.GotFocus
        Number05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number06_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number06.GotFocus
        Number06.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number07_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number07.GotFocus
        Number07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number08_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number08.GotFocus
        Number08.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number09_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number09.GotFocus
        Number09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number10.GotFocus
        Number10.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number12.GotFocus
        Number12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number13_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number13.GotFocus
        Number13.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number14_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number14.GotFocus
        Number14.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number15_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number15.GotFocus
        Number15.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number16_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number16.GotFocus
        Number16.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number17_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number17.GotFocus
        Number17.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number18_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number18.GotFocus
        Number18.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number19_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number19.GotFocus
        Number19.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number20_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number20.GotFocus
        Number20.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number22_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number22.GotFocus
        Number22.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number23_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number23.GotFocus
        Number23.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number24_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number24.GotFocus
        Number24.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number25_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number25.GotFocus
        Number25.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number26_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number26.GotFocus
        Number26.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number27_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number27.GotFocus
        Number27.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number28_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number28.GotFocus
        Number28.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number29_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number29.GotFocus
        Number29.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number30_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number30.GotFocus
        Number30.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.GotFocus
        Edit01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit02_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.GotFocus
        Edit02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit03_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.GotFocus
        Edit03.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit04_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.GotFocus
        Edit04.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit05_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.GotFocus
        Edit05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit06_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.GotFocus
        Edit06.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit07_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit07.GotFocus
        Edit07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit08_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit08.GotFocus
        Edit08.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit09_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit09.GotFocus
        Edit09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit10.GotFocus
        Edit10.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.GotFocus
        Combo002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit0.LostFocus
        Edit0.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit2.LostFocus
        Edit2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.LostFocus
        Edit3.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit4.LostFocus
        Edit4.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit5.LostFocus
        Edit5.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.LostFocus
        Number02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03.LostFocus
        Number03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04.LostFocus
        Number04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05.LostFocus
        Number05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number06.LostFocus
        Number06.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number07.LostFocus
        Number07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number08.LostFocus
        Number08.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number09.LostFocus
        Number09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number10.LostFocus
        Number10.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number12.LostFocus
        Number12.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number13_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number13.LostFocus
        Number13.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number14_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number14.LostFocus
        Number14.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number15_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number15.LostFocus
        Number15.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number16_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number16.LostFocus
        Number16.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number17_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number17.LostFocus
        Number17.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number18_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number18.LostFocus
        Number18.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number19_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number19.LostFocus
        Number19.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number20_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number20.LostFocus
        Number20.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number22_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number22.LostFocus
        Number22.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number23_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number23.LostFocus
        Number23.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number24_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number24.LostFocus
        Number24.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number25_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number25.LostFocus
        Number25.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number26_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number26.LostFocus
        Number26.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number27_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number27.LostFocus
        Number27.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number28_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number28.LostFocus
        Number28.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number29_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number29.LostFocus
        Number29.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number30_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number30.LostFocus
        Number30.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        Edit01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Edit04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Edit05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.LostFocus
        Edit06.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit07.LostFocus
        Edit07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit08_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit08.LostFocus
        Edit08.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit09.LostFocus
        Edit09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit10.LostFocus
        Edit10.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    'Private Sub Number02_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.TextChanged
    '    If Number02.Value > 999 Or Number02.Value < -999 Then Number02.Value = RoundDOWN(Number02.Value / 10, 0)
    '    If Number02.Value * Number12.Value <= 999999999 And Number02.Value * Number12.Value >= -999999999 Then
    '        Number22.Value = Number02.Value * Number12.Value
    '    Else
    '        Number02.Value = RoundDOWN(Number02.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number03_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03.TextChanged
    '    If Number03.Value > 999 Or Number03.Value < -999 Then Number03.Value = RoundDOWN(Number03.Value / 10, 0)
    '    If Number03.Value * Number13.Value <= 999999999 And Number03.Value * Number13.Value >= -999999999 Then
    '        Number23.Value = Number03.Value * Number13.Value
    '    Else
    '        Number03.Value = RoundDOWN(Number03.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number04_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04.TextChanged
    '    If Number04.Value > 999 Or Number04.Value < -999 Then Number04.Value = RoundDOWN(Number04.Value / 10, 0)
    '    If Number04.Value * Number14.Value <= 999999999 And Number04.Value * Number14.Value >= -999999999 Then
    '        Number24.Value = Number04.Value * Number14.Value
    '    Else
    '        Number04.Value = RoundDOWN(Number04.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number05_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05.TextChanged
    '    If Number05.Value > 999 Or Number05.Value < -999 Then Number05.Value = RoundDOWN(Number05.Value / 10, 0)
    '    If Number05.Value * Number15.Value <= 999999999 And Number05.Value * Number15.Value >= -999999999 Then
    '        Number25.Value = Number05.Value * Number15.Value
    '    Else
    '        Number05.Value = RoundDOWN(Number05.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number06_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number06.TextChanged
    '    If Number06.Value > 999 Or Number06.Value < -999 Then Number06.Value = RoundDOWN(Number06.Value / 10, 0)
    '    If Number06.Value * Number16.Value <= 999999999 And Number06.Value * Number16.Value >= -999999999 Then
    '        Number26.Value = Number06.Value * Number16.Value
    '    Else
    '        Number06.Value = RoundDOWN(Number06.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number07_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number07.TextChanged
    '    If Number07.Value > 999 Or Number07.Value < -999 Then Number07.Value = RoundDOWN(Number07.Value / 10, 0)
    '    If Number07.Value * Number17.Value <= 999999999 And Number07.Value * Number17.Value >= -999999999 Then
    '        Number27.Value = Number07.Value * Number17.Value
    '    Else
    '        Number07.Value = RoundDOWN(Number07.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number08_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number08.TextChanged
    '    If Number08.Value > 999 Or Number08.Value < -999 Then Number08.Value = RoundDOWN(Number08.Value / 10, 0)
    '    If Number08.Value * Number18.Value <= 999999999 And Number08.Value * Number18.Value >= -999999999 Then
    '        Number28.Value = Number08.Value * Number18.Value
    '    Else
    '        Number08.Value = RoundDOWN(Number08.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number09_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number09.TextChanged
    '    If Number09.Value > 999 Or Number09.Value < -999 Then Number09.Value = RoundDOWN(Number09.Value / 10, 0)
    '    If Number09.Value * Number19.Value <= 999999999 And Number09.Value * Number19.Value >= -999999999 Then
    '        Number29.Value = Number09.Value * Number19.Value
    '    Else
    '        Number09.Value = RoundDOWN(Number09.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number10.TextChanged
    '    If Number10.Value > 999 Or Number10.Value < -999 Then Number10.Value = RoundDOWN(Number10.Value / 10, 0)
    '    If Number10.Value * Number20.Value <= 999999999 And Number10.Value * Number20.Value >= -999999999 Then
    '        Number30.Value = Number10.Value * Number20.Value
    '    Else
    '        Number10.Value = RoundDOWN(Number10.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number12.TextChanged
    '    If Number12.Value > 9999999 Or Number12.Value < -9999999 Then Number12.Value = RoundDOWN(Number12.Value / 10, 0)
    '    If Number02.Value * Number12.Value <= 999999999 And Number02.Value * Number12.Value >= -999999999 Then
    '        Number22.Value = Number02.Value * Number12.Value
    '    Else
    '        Number12.Value = RoundDOWN(Number12.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number13.TextChanged
    '    If Number13.Value > 9999999 Or Number13.Value < -9999999 Then Number13.Value = RoundDOWN(Number13.Value / 10, 0)
    '    If Number03.Value * Number13.Value <= 999999999 And Number03.Value * Number13.Value >= -999999999 Then
    '        Number23.Value = Number03.Value * Number13.Value
    '    Else
    '        Number13.Value = RoundDOWN(Number13.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number14.TextChanged
    '    If Number14.Value > 9999999 Or Number14.Value < -9999999 Then Number14.Value = RoundDOWN(Number14.Value / 10, 0)
    '    If Number04.Value * Number14.Value <= 999999999 And Number04.Value * Number14.Value >= -999999999 Then
    '        Number24.Value = Number04.Value * Number14.Value
    '    Else
    '        Number14.Value = RoundDOWN(Number14.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number15.TextChanged
    '    If Number15.Value > 9999999 Or Number15.Value < -9999999 Then Number15.Value = RoundDOWN(Number15.Value / 10, 0)
    '    If Number05.Value * Number15.Value <= 999999999 And Number05.Value * Number15.Value >= -999999999 Then
    '        Number25.Value = Number05.Value * Number15.Value
    '    Else
    '        Number15.Value = RoundDOWN(Number15.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number16.TextChanged
    '    If Number16.Value > 9999999 Or Number16.Value < -9999999 Then Number16.Value = RoundDOWN(Number16.Value / 10, 0)
    '    If Number06.Value * Number16.Value <= 999999999 And Number06.Value * Number16.Value >= -999999999 Then
    '        Number26.Value = Number06.Value * Number16.Value
    '    Else
    '        Number16.Value = RoundDOWN(Number16.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number17.TextChanged
    '    If Number17.Value > 9999999 Or Number17.Value < -9999999 Then Number17.Value = RoundDOWN(Number17.Value / 10, 0)
    '    If Number07.Value * Number17.Value <= 999999999 And Number07.Value * Number17.Value >= -999999999 Then
    '        Number27.Value = Number07.Value * Number17.Value
    '    Else
    '        Number17.Value = RoundDOWN(Number17.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number18_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number18.TextChanged
    '    If Number18.Value > 9999999 Or Number18.Value < -9999999 Then Number18.Value = RoundDOWN(Number18.Value / 10, 0)
    '    If Number08.Value * Number18.Value <= 999999999 And Number08.Value * Number18.Value >= -999999999 Then
    '        Number28.Value = Number08.Value * Number18.Value
    '    Else
    '        Number18.Value = RoundDOWN(Number18.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number19.TextChanged
    '    If Number19.Value > 9999999 Or Number19.Value < -9999999 Then Number19.Value = RoundDOWN(Number19.Value / 10, 0)
    '    If Number09.Value * Number19.Value <= 999999999 And Number09.Value * Number19.Value >= -999999999 Then
    '        Number29.Value = Number09.Value * Number19.Value
    '    Else
    '        Number19.Value = RoundDOWN(Number19.Value / 10, 0)
    '    End If
    'End Sub
    'Private Sub Number20_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number20.TextChanged
    '    If Number20.Value > 9999999 Or Number20.Value < -9999999 Then Number20.Value = RoundDOWN(Number20.Value / 10, 0)
    '    If Number10.Value * Number20.Value <= 999999999 And Number10.Value * Number20.Value >= -999999999 Then
    '        Number30.Value = Number10.Value * Number20.Value
    '    Else
    '        Number20.Value = RoundDOWN(Number20.Value / 10, 0)
    '    End If
    'End Sub
    Private Sub Number21_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number21.TextChanged
        If Number21.Value > 999999999 Or Number21.Value < -999999999 Then Number21.Value = RoundDOWN(Number21.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number21.Value = 0
    End Sub
    Private Sub Number22_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number22.TextChanged
        If Number21.Value > 999999999 Or Number21.Value < -999999999 Then Number21.Value = RoundDOWN(Number21.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number22.Value = 0
    End Sub
    Private Sub Number23_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number23.TextChanged
        If Number23.Value > 999999999 Or Number23.Value < -999999999 Then Number23.Value = RoundDOWN(Number23.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number23.Value = 0
    End Sub
    Private Sub Number24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number24.TextChanged
        If Number24.Value > 999999999 Or Number24.Value < -999999999 Then Number24.Value = RoundDOWN(Number24.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number24.Value = 0
    End Sub
    Private Sub Number25_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number25.TextChanged
        If Number25.Value > 999999999 Or Number25.Value < -999999999 Then Number25.Value = RoundDOWN(Number25.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number25.Value = 0
    End Sub
    Private Sub Number26_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number26.TextChanged
        If Number26.Value > 999999999 Or Number26.Value < -999999999 Then Number26.Value = RoundDOWN(Number26.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number26.Value = 0
    End Sub
    Private Sub Number27_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number27.TextChanged
        If Number27.Value > 999999999 Or Number27.Value < -999999999 Then Number27.Value = RoundDOWN(Number27.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number27.Value = 0
    End Sub
    Private Sub Number28_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number28.TextChanged
        If Number28.Value > 999999999 Or Number28.Value < -999999999 Then Number28.Value = RoundDOWN(Number28.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number28.Value = 0
    End Sub
    Private Sub Number29_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number29.TextChanged
        If Number29.Value > 999999999 Or Number29.Value < -999999999 Then Number29.Value = RoundDOWN(Number29.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number29.Value = 0
    End Sub
    Private Sub Number30_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number30.TextChanged
        If Number30.Value > 999999999 Or Number30.Value < -999999999 Then Number30.Value = RoundDOWN(Number30.Value / 10, 0)
        sum()
        If WK_sum_err = "1" Then Number30.Value = 0
    End Sub
    Sub sum()
        WK_sum = Number21.Value + Number22.Value + Number23.Value + Number24.Value + Number25.Value + Number26.Value + Number27.Value + Number28.Value + Number29.Value + Number30.Value
        If WK_sum <= 9999999999 And WK_sum >= -9999999999 Then
            WK_sum_err = "0"
            Number1.Value = WK_sum
        Else
            WK_sum_err = "1"
        End If
    End Sub
    Private Sub Number1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.TextChanged
        Number2.Value = RoundDOWN(Number1.Value * 0.1, 0)
        Number3.Value = Number1.Value + Number2.Value
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
End Class
