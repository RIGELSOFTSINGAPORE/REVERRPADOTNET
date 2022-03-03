Public Class F60_Form03
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
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Number
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F60_Form03))
        Me.Edit5 = New GrapeCity.Win.Input.Edit
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Number1 = New GrapeCity.Win.Input.Number
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
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
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuspendLayout()
        '
        'Edit5
        '
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit5.LengthAsByte = True
        Me.Edit5.Location = New System.Drawing.Point(468, 172)
        Me.Edit5.MaxLength = 20
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(104, 20)
        Me.Edit5.TabIndex = 11
        Me.Edit5.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(476, 44)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(360, 20)
        Me.Label25.TabIndex = 1897
        Me.Label25.Text = "Label25"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(376, 172)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(96, 20)
        Me.Label24.TabIndex = 1896
        Me.Label24.Text = "担当"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(76, 468)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(520, 16)
        Me.msg.TabIndex = 1895
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,##0", "", "", "-", "", "", "0")
        Me.Number1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.Format = New GrapeCity.Win.Input.NumberFormat("#,##0", "", "", "-", "", "", "")
        Me.Number1.Location = New System.Drawing.Point(28, 16)
        Me.Number1.MaxValue = New Decimal(New Integer() {12, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(32, 20)
        Me.Number1.TabIndex = 0
        Me.Number1.Value = Nothing
        '
        'Edit1
        '
        Me.Edit1.Location = New System.Drawing.Point(680, 12)
        Me.Edit1.Name = "Edit1"
        Me.Edit1.ReadOnly = True
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(144, 20)
        Me.Edit1.TabIndex = 1821
        Me.Edit1.TabStop = False
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(72, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 20)
        Me.Label10.TabIndex = 1886
        Me.Label10.Text = "②当月入金金額"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(72, 184)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(172, 20)
        Me.Label13.TabIndex = 1885
        Me.Label13.Text = "①前月残高金額"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(588, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 20)
        Me.Label14.TabIndex = 1884
        Me.Label14.Text = "請求書番号"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(120, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(716, 20)
        Me.Label12.TabIndex = 1883
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(120, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(716, 20)
        Me.Label11.TabIndex = 1882
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(24, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 20)
        Me.Label9.TabIndex = 1881
        Me.Label9.Text = "お取引先名称"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(24, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 20)
        Me.Label8.TabIndex = 1880
        Me.Label8.Text = "お取引先住所"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 20)
        Me.Label7.TabIndex = 1879
        Me.Label7.Text = "お取引先コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(120, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(716, 20)
        Me.Label6.TabIndex = 1878
        '
        'Number01
        '
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number01.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number01.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number01.Location = New System.Drawing.Point(248, 184)
        Me.Number01.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number01.Name = "Number01"
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(92, 20)
        Me.Number01.TabIndex = 1
        Me.Number01.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number02
        '
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number02.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number02.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number02.Location = New System.Drawing.Point(248, 212)
        Me.Number02.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(92, 20)
        Me.Number02.TabIndex = 2
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number03
        '
        Me.Number03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number03.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number03.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number03.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number03.Enabled = False
        Me.Number03.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number03.Location = New System.Drawing.Point(248, 240)
        Me.Number03.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number03.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number03.Name = "Number03"
        Me.Number03.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number03.Size = New System.Drawing.Size(92, 20)
        Me.Number03.TabIndex = 3
        Me.Number03.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number04
        '
        Me.Number04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number04.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number04.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number04.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number04.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number04.Enabled = False
        Me.Number04.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number04.Location = New System.Drawing.Point(248, 268)
        Me.Number04.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number04.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number04.Name = "Number04"
        Me.Number04.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number04.Size = New System.Drawing.Size(92, 20)
        Me.Number04.TabIndex = 4
        Me.Number04.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number05
        '
        Me.Number05.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number05.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number05.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number05.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number05.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number05.Location = New System.Drawing.Point(248, 296)
        Me.Number05.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number05.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number05.Name = "Number05"
        Me.Number05.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number05.Size = New System.Drawing.Size(92, 20)
        Me.Number05.TabIndex = 5
        Me.Number05.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number06
        '
        Me.Number06.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number06.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number06.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number06.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number06.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number06.Location = New System.Drawing.Point(248, 324)
        Me.Number06.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number06.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number06.Name = "Number06"
        Me.Number06.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number06.Size = New System.Drawing.Size(92, 20)
        Me.Number06.TabIndex = 6
        Me.Number06.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number07
        '
        Me.Number07.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number07.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number07.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number07.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number07.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number07.Location = New System.Drawing.Point(248, 352)
        Me.Number07.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number07.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number07.Name = "Number07"
        Me.Number07.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number07.Size = New System.Drawing.Size(92, 20)
        Me.Number07.TabIndex = 7
        Me.Number07.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number08
        '
        Me.Number08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number08.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number08.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number08.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number08.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number08.Enabled = False
        Me.Number08.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number08.Location = New System.Drawing.Point(248, 380)
        Me.Number08.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number08.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number08.Name = "Number08"
        Me.Number08.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number08.Size = New System.Drawing.Size(92, 20)
        Me.Number08.TabIndex = 8
        Me.Number08.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number09
        '
        Me.Number09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number09.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number09.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number09.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number09.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number09.Enabled = False
        Me.Number09.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number09.Location = New System.Drawing.Point(248, 408)
        Me.Number09.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number09.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number09.Name = "Number09"
        Me.Number09.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number09.Size = New System.Drawing.Size(92, 20)
        Me.Number09.TabIndex = 9
        Me.Number09.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number10
        '
        Me.Number10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number10.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "0")
        Me.Number10.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number10.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number10.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number10.Enabled = False
        Me.Number10.Format = New GrapeCity.Win.Input.NumberFormat("###,###,###,##0", "", "", "-", "", "", "")
        Me.Number10.Location = New System.Drawing.Point(248, 436)
        Me.Number10.MaxValue = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.Number10.MinValue = New Decimal(New Integer() {1215752191, 23, 0, -2147483648})
        Me.Number10.Name = "Number10"
        Me.Number10.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number10.Size = New System.Drawing.Size(92, 20)
        Me.Number10.TabIndex = 10
        Me.Number10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(620, 460)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 24)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "印刷"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(720, 460)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 13
        Me.Button98.Text = "戻る"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(188, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(360, 28)
        Me.Label22.TabIndex = 1899
        Me.Label22.Text = "ケーズホールディングス　専用請求書"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(60, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 16)
        Me.Label23.TabIndex = 1900
        Me.Label23.Text = "月切"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(472, 220)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(364, 20)
        Me.Label18.TabIndex = 1906
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(472, 196)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(364, 20)
        Me.Label19.TabIndex = 1905
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(376, 220)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(92, 20)
        Me.Label20.TabIndex = 1904
        Me.Label20.Text = "FAX番号"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Navy
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(376, 196)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(92, 20)
        Me.Label21.TabIndex = 1903
        Me.Label21.Text = "電話番号"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Navy
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(376, 148)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(92, 20)
        Me.Label27.TabIndex = 1902
        Me.Label27.Text = "請求書作成者"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(472, 148)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(364, 20)
        Me.Label28.TabIndex = 1901
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(72, 268)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(172, 20)
        Me.Label29.TabIndex = 1908
        Me.Label29.Text = "④当月仕入金額"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(72, 240)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(172, 20)
        Me.Label30.TabIndex = 1907
        Me.Label30.Text = "③差引残高金額（①-②）"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Navy
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(72, 296)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(172, 20)
        Me.Label31.TabIndex = 1909
        Me.Label31.Text = "⑤当月返品金額"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(72, 436)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(172, 20)
        Me.Label32.TabIndex = 1914
        Me.Label32.Text = "⑩合計金額（③＋⑧＋⑨）"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Navy
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(72, 408)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(172, 20)
        Me.Label33.TabIndex = 1913
        Me.Label33.Text = "⑨消費税額（⑧×税率）"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Navy
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(72, 380)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(172, 20)
        Me.Label34.TabIndex = 1912
        Me.Label34.Text = "⑧小計金額（④-⑤-⑥-⑦）"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(72, 352)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(172, 20)
        Me.Label35.TabIndex = 1911
        Me.Label35.Text = "⑦当月交換手数料"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Navy
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(72, 324)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(172, 20)
        Me.Label36.TabIndex = 1910
        Me.Label36.Text = "⑥当月拡売金額"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F60_Form03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(842, 496)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Number01)
        Me.Controls.Add(Me.Number02)
        Me.Controls.Add(Me.Number03)
        Me.Controls.Add(Me.Number04)
        Me.Controls.Add(Me.Number05)
        Me.Controls.Add(Me.Number06)
        Me.Controls.Add(Me.Number07)
        Me.Controls.Add(Me.Number08)
        Me.Controls.Add(Me.Number09)
        Me.Controls.Add(Me.Number10)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F60_Form03"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求書入力"
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F60_Form03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
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
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_02_2m", cnsqlclient)
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

                Number1.Value = DatePart(DateInterval.Month, CDate(P_F60_4))
                If Not IsDBNull(DtView1(0)("invc_name")) Then Label25.Text = DtView1(0)("invc_name") & "　御中" Else Label25.Text = Nothing

                If Not IsDBNull(DtView1(0)("client_code")) Then Label6.Text = DtView1(0)("client_code") Else Label6.Text = Nothing
                If Not IsDBNull(DtView1(0)("brch_zip")) Then Label11.Text = "〒" & Mid(DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(DtView1(0)("brch_zip"), 4, 4) Else Label11.Text = Nothing
                If Not IsDBNull(DtView1(0)("brch_adrs1")) Then Label11.Text = Label11.Text & " " & DtView1(0)("brch_adrs1")
                'If Not IsDBNull(DtView1(0)("brch_adrs2")) Then Label11.Text = Label11.Text & " " & DtView1(0)("brch_adrs2")
                If Not IsDBNull(DtView1(0)("brch_name")) Then Label12.Text = DtView1(0)("brch_name") Else Label12.Text = Nothing

                If Not IsDBNull(DtView1(0)("brch_name")) Then Label28.Text = DtView1(0)("brch_name") Else Label28.Text = Nothing
                If Not IsDBNull(DtView1(0)("invc_empl_name")) Then Edit5.Text = DtView1(0)("invc_empl_name") Else Edit5.Text = Nothing
                If Not IsDBNull(DtView1(0)("brch_tel")) Then Label19.Text = DtView1(0)("brch_tel") Else Label19.Text = Nothing
                If Not IsDBNull(DtView1(0)("brch_fax")) Then Label18.Text = DtView1(0)("brch_fax") Else Label18.Text = Nothing
                Number04.Value = DtView1(0)("amnt1")

                If P_F60_1 <> "0" Then   '再印刷
                    Edit1.Text = P_F60_1

                    If Not IsDBNull(DtView1(0)("B_amnt01")) Then Number01.Value = DtView1(0)("B_amnt01") Else Number01.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt02")) Then Number02.Value = DtView1(0)("B_amnt02") Else Number02.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt03")) Then Number03.Value = DtView1(0)("B_amnt03") Else Number03.Value = 0
                    If Not IsDBNull(DtView1(0)("amnt1")) Then Number04.Value = DtView1(0)("amnt1") Else Number04.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt05")) Then Number05.Value = DtView1(0)("B_amnt05") Else Number05.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt06")) Then Number06.Value = DtView1(0)("B_amnt06") Else Number06.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt07")) Then Number07.Value = DtView1(0)("B_amnt07") Else Number07.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt08")) Then Number08.Value = DtView1(0)("B_amnt08") Else Number08.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt09")) Then Number09.Value = DtView1(0)("B_amnt09") Else Number09.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt10")) Then Number10.Value = DtView1(0)("B_amnt10") Else Number10.Value = 0
                End If
            End If

        Else
            '********************
            '** メーカー請求
            '********************
            'なし
        End If
    End Sub

    Sub F_chk()
        Err_F = "0"
        msg.Text = Nothing

        '月
        If Number1.Value = 0 Then
            msg.Text = "月の入力がありません。"
            Err_F = "1"
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
                        strSQL = strSQL & ", invc_amnt, cnt, tax_rate, invc_empl_name, B_amnt01, B_amnt02, B_amnt03, B_amnt04"
                        strSQL = strSQL & ", B_amnt05, B_amnt06, B_amnt07, B_amnt08, B_amnt09, B_amnt10, B_amnt11)"
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
                        strSQL = strSQL & ", '" & Trim(Edit5.Text) & "'"
                        strSQL = strSQL & ", " & Number01.Value & ""
                        strSQL = strSQL & ", " & Number02.Value & ""
                        strSQL = strSQL & ", " & Number03.Value & ""
                        strSQL = strSQL & ", " & Number04.Value & ""
                        strSQL = strSQL & ", " & Number05.Value & ""
                        strSQL = strSQL & ", " & Number06.Value & ""
                        strSQL = strSQL & ", " & Number07.Value & ""
                        strSQL = strSQL & ", " & Number08.Value & ""
                        strSQL = strSQL & ", " & Number09.Value & ""
                        strSQL = strSQL & ", " & Number10.Value & ""
                        strSQL = strSQL & ", " & Number1.Value & ")"
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
                    strSQL = strSQL & " SET B_amnt01 = " & Number01.Value & ""
                    strSQL = strSQL & ", B_amnt02 = " & Number02.Value & ""
                    strSQL = strSQL & ", B_amnt03 = " & Number03.Value & ""
                    strSQL = strSQL & ", B_amnt04 = " & Number04.Value & ""
                    strSQL = strSQL & ", B_amnt05 = " & Number05.Value & ""
                    strSQL = strSQL & ", B_amnt06 = " & Number06.Value & ""
                    strSQL = strSQL & ", B_amnt07 = " & Number07.Value & ""
                    strSQL = strSQL & ", B_amnt08 = " & Number08.Value & ""
                    strSQL = strSQL & ", B_amnt09 = " & Number09.Value & ""
                    strSQL = strSQL & ", B_amnt10 = " & Number10.Value & ""
                    strSQL = strSQL & ", B_amnt11 = " & Number1.Value & ""
                    strSQL = strSQL & ", invc_empl_name = '" & Edit5.Text & "'"
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
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F60_02_2m", cnsqlclient)
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
                strSQL = strSQL & ", " & DtView2(0)("B_amnt11") & " AS tuki"                    '月
                strSQL = strSQL & ", '" & DtView2(0)("invc_name") & "　御中' AS invc_name"      '請求先
                strSQL = strSQL & ", '" & DtView2(0)("client_code") & "' AS client_code"        'お取引先コード
                strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("brch_zip"), 1, 3) & "-" & Mid(DtView2(0)("brch_zip"), 4, 4) & "' AS brch_zip"   'お取引先住所
                strSQL = strSQL & ", '" & DtView2(0)("brch_adrs1") & "' AS brch_adrs"           'お取引先住所
                strSQL = strSQL & ", '" & DtView2(0)("brch_name") & "' AS brch_name"
                strSQL = strSQL & ", '" & DtView2(0)("brch_tel") & "' AS brch_tel"
                strSQL = strSQL & ", '" & DtView2(0)("brch_fax") & "' AS brch_fax"
                strSQL = strSQL & ", '" & DtView2(0)("invc_empl_name") & "' AS empl_name"       '請求担当

                If DtView2(0)("B_amnt01") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt01"), "##,##0") & "' AS amnt1"     '金額
                Else
                    strSQL = strSQL & ", '' AS amnt1"
                End If
                If DtView2(0)("B_amnt02") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt02"), "##,##0") & "' AS amnt2"
                Else
                    strSQL = strSQL & ", '' AS amnt2"
                End If
                If DtView2(0)("B_amnt03") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt03"), "##,##0") & "' AS amnt3"
                Else
                    strSQL = strSQL & ", '' AS amnt3"
                End If
                If DtView2(0)("B_amnt04") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt04"), "##,##0") & "' AS amnt4"
                Else
                    strSQL = strSQL & ", '' AS amnt4"
                End If
                If DtView2(0)("B_amnt05") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt05"), "##,##0") & "' AS amnt5"
                Else
                    strSQL = strSQL & ", '' AS amnt5"
                End If
                If DtView2(0)("B_amnt06") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt06"), "##,##0") & "' AS amnt6"
                Else
                    strSQL = strSQL & ", '' AS amnt6"
                End If
                If DtView2(0)("B_amnt07") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt07"), "##,##0") & "' AS amnt7"
                Else
                    strSQL = strSQL & ", '' AS amnt7"
                End If
                If DtView2(0)("B_amnt08") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt08"), "##,##0") & "' AS amnt8"
                Else
                    strSQL = strSQL & ", '' AS amnt8"
                End If
                If DtView2(0)("B_amnt09") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt09"), "##,##0") & "' AS amnt9"
                Else
                    strSQL = strSQL & ", '' AS amnt9"
                End If
                If DtView2(0)("B_amnt10") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt10"), "##,##0") & "' AS amnt10"
                Else
                    strSQL = strSQL & ", '' AS amnt10"
                End If
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
                'なし
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit5.GotFocus
        Edit5.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.GotFocus
        Number1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Number01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.GotFocus
        Number01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit5.LostFocus
        Edit5.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.LostFocus
        Number1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Number01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.LostFocus
        Number01.BackColor = System.Drawing.SystemColors.Window
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

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Number01_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.TextChanged
        Number03_sum()
    End Sub
    Private Sub Number02_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.TextChanged
        Number03_sum()
    End Sub
    Private Sub Number03_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03.TextChanged
        Number10_sum()
    End Sub
    Private Sub Number04_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04.TextChanged
        Number08_sum()
    End Sub
    Private Sub Number05_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05.TextChanged
        Number08_sum()
    End Sub
    Private Sub Number06_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number06.TextChanged
        Number08_sum()
    End Sub
    Private Sub Number07_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number07.TextChanged
        Number08_sum()
    End Sub
    Private Sub Number08_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number08.TextChanged
        Number09_sum()
    End Sub
    Private Sub Number09_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number09.TextChanged
        Number10_sum()
    End Sub

    Sub Number03_sum()
        Number03.Value = Number01.Value - Number02.Value
    End Sub
    Sub Number08_sum()
        Number08.Value = Number04.Value - Number05.Value - Number06.Value - Number07.Value
    End Sub
    Sub Number09_sum()
        Number09.Value = RoundDOWN(Number08.Value * 0.1, 0)
    End Sub
    Sub Number10_sum()
        Number10.Value = Number03.Value + Number08.Value + Number09.Value
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
