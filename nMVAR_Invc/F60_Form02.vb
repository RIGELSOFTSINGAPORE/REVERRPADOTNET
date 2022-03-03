Public Class F60_Form02
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
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Number21 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number22 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number23 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number24 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number11 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number12 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number13 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number14 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number15 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number16 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number17 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number18 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number19 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number20 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number10 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number09 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number08 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number07 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number06 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number05 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number04 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number03 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number02 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Number01 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Number00 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Interop.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F60_Form02))
        Me.Label24 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Edit3 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit2 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Number21 = New GrapeCity.Win.Input.Interop.Number
        Me.Number22 = New GrapeCity.Win.Input.Interop.Number
        Me.Number23 = New GrapeCity.Win.Input.Interop.Number
        Me.Number24 = New GrapeCity.Win.Input.Interop.Number
        Me.Number11 = New GrapeCity.Win.Input.Interop.Number
        Me.Number12 = New GrapeCity.Win.Input.Interop.Number
        Me.Number13 = New GrapeCity.Win.Input.Interop.Number
        Me.Number14 = New GrapeCity.Win.Input.Interop.Number
        Me.Number15 = New GrapeCity.Win.Input.Interop.Number
        Me.Number16 = New GrapeCity.Win.Input.Interop.Number
        Me.Number17 = New GrapeCity.Win.Input.Interop.Number
        Me.Number18 = New GrapeCity.Win.Input.Interop.Number
        Me.Number19 = New GrapeCity.Win.Input.Interop.Number
        Me.Number20 = New GrapeCity.Win.Input.Interop.Number
        Me.Number10 = New GrapeCity.Win.Input.Interop.Number
        Me.Number09 = New GrapeCity.Win.Input.Interop.Number
        Me.Number08 = New GrapeCity.Win.Input.Interop.Number
        Me.Number07 = New GrapeCity.Win.Input.Interop.Number
        Me.Number06 = New GrapeCity.Win.Input.Interop.Number
        Me.Number05 = New GrapeCity.Win.Input.Interop.Number
        Me.Number04 = New GrapeCity.Win.Input.Interop.Number
        Me.Number03 = New GrapeCity.Win.Input.Interop.Number
        Me.Number02 = New GrapeCity.Win.Input.Interop.Number
        Me.Number01 = New GrapeCity.Win.Input.Interop.Number
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Edit5 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Number00 = New GrapeCity.Win.Input.Interop.Number
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number24, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Navy
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(12, 80)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 20)
        Me.Label24.TabIndex = 1897
        Me.Label24.Text = "担　　当"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(292, 704)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(440, 16)
        Me.msg.TabIndex = 1896
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit3
        '
        Me.Edit3.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit3.Enabled = False
        Me.Edit3.LengthAsByte = True
        Me.Edit3.Location = New System.Drawing.Point(152, 700)
        Me.Edit3.MaxLength = 20
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(132, 20)
        Me.Edit3.TabIndex = 26
        Me.Edit3.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit2
        '
        Me.Edit2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit2.Enabled = False
        Me.Edit2.Location = New System.Drawing.Point(152, 680)
        Me.Edit2.Name = "Edit2"
        Me.Edit2.ReadOnly = True
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(132, 20)
        Me.Edit2.TabIndex = 25
        Me.Edit2.TabStop = False
        Me.Edit2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(56, 680)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 20)
        Me.Label13.TabIndex = 1886
        Me.Label13.Text = "振込"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(152, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 20)
        Me.Label14.TabIndex = 1885
        Me.Label14.Text = "当　月　分"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(172, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(544, 16)
        Me.Label12.TabIndex = 1884
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(172, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(544, 16)
        Me.Label11.TabIndex = 1883
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 1882
        Me.Label9.Text = "電話番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 1881
        Me.Label8.Text = "住　　所"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 1880
        Me.Label7.Text = "仕入先名"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(112, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(256, 16)
        Me.Label6.TabIndex = 1879
        '
        'Number21
        '
        Me.Number21.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number21.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "0")
        Me.Number21.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number21.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number21.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number21.Enabled = False
        Me.Number21.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number21.Location = New System.Drawing.Point(152, 592)
        Me.Number21.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number21.MinValue = New Decimal(New Integer() {1410065407, 2, 0, -2147483648})
        Me.Number21.Name = "Number21"
        Me.Number21.ReadOnly = True
        Me.Number21.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number21.Size = New System.Drawing.Size(132, 20)
        Me.Number21.TabIndex = 21
        Me.Number21.TabStop = False
        Me.Number21.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number22
        '
        Me.Number22.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number22.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "0")
        Me.Number22.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number22.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number22.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number22.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number22.Location = New System.Drawing.Point(152, 612)
        Me.Number22.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number22.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number22.Name = "Number22"
        Me.Number22.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number22.Size = New System.Drawing.Size(132, 20)
        Me.Number22.TabIndex = 22
        Me.Number22.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number23
        '
        Me.Number23.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number23.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "0")
        Me.Number23.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number23.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number23.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number23.Enabled = False
        Me.Number23.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number23.Location = New System.Drawing.Point(152, 632)
        Me.Number23.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number23.MinValue = New Decimal(New Integer() {1410065407, 2, 0, -2147483648})
        Me.Number23.Name = "Number23"
        Me.Number23.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number23.Size = New System.Drawing.Size(132, 20)
        Me.Number23.TabIndex = 23
        Me.Number23.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number24
        '
        Me.Number24.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number24.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "0")
        Me.Number24.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number24.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number24.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number24.Enabled = False
        Me.Number24.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number24.Location = New System.Drawing.Point(152, 652)
        Me.Number24.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number24.MinValue = New Decimal(New Integer() {1410065407, 2, 0, -2147483648})
        Me.Number24.Name = "Number24"
        Me.Number24.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number24.Size = New System.Drawing.Size(132, 20)
        Me.Number24.TabIndex = 24
        Me.Number24.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number11
        '
        Me.Number11.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number11.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number11.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number11.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number11.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number11.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number11.Location = New System.Drawing.Point(152, 384)
        Me.Number11.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number11.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number11.Name = "Number11"
        Me.Number11.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number11.Size = New System.Drawing.Size(132, 20)
        Me.Number11.TabIndex = 11
        Me.Number11.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number12
        '
        Me.Number12.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number12.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number12.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number12.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number12.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number12.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number12.Location = New System.Drawing.Point(152, 404)
        Me.Number12.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number12.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number12.Name = "Number12"
        Me.Number12.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number12.Size = New System.Drawing.Size(132, 20)
        Me.Number12.TabIndex = 12
        Me.Number12.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number13
        '
        Me.Number13.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number13.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number13.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number13.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number13.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number13.Enabled = False
        Me.Number13.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number13.Location = New System.Drawing.Point(152, 424)
        Me.Number13.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number13.MinValue = New Decimal(New Integer() {1410065407, 2, 0, -2147483648})
        Me.Number13.Name = "Number13"
        Me.Number13.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number13.Size = New System.Drawing.Size(132, 20)
        Me.Number13.TabIndex = 13
        Me.Number13.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number14
        '
        Me.Number14.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number14.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number14.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number14.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number14.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number14.Enabled = False
        Me.Number14.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number14.Location = New System.Drawing.Point(152, 444)
        Me.Number14.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number14.MinValue = New Decimal(New Integer() {1410065407, 2, 0, -2147483648})
        Me.Number14.Name = "Number14"
        Me.Number14.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number14.Size = New System.Drawing.Size(132, 20)
        Me.Number14.TabIndex = 14
        Me.Number14.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number15
        '
        Me.Number15.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number15.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number15.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number15.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number15.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number15.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number15.Location = New System.Drawing.Point(152, 472)
        Me.Number15.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number15.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number15.Name = "Number15"
        Me.Number15.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number15.Size = New System.Drawing.Size(132, 20)
        Me.Number15.TabIndex = 15
        Me.Number15.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number16
        '
        Me.Number16.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number16.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number16.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number16.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number16.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number16.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number16.Location = New System.Drawing.Point(152, 492)
        Me.Number16.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number16.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number16.Name = "Number16"
        Me.Number16.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number16.Size = New System.Drawing.Size(132, 20)
        Me.Number16.TabIndex = 16
        Me.Number16.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number17
        '
        Me.Number17.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number17.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number17.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number17.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number17.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number17.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number17.Location = New System.Drawing.Point(152, 512)
        Me.Number17.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number17.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number17.Name = "Number17"
        Me.Number17.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number17.Size = New System.Drawing.Size(132, 20)
        Me.Number17.TabIndex = 17
        Me.Number17.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number18
        '
        Me.Number18.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number18.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number18.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number18.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number18.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number18.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number18.Location = New System.Drawing.Point(152, 532)
        Me.Number18.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number18.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number18.Name = "Number18"
        Me.Number18.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number18.Size = New System.Drawing.Size(132, 20)
        Me.Number18.TabIndex = 18
        Me.Number18.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number19
        '
        Me.Number19.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number19.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number19.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number19.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number19.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number19.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number19.Location = New System.Drawing.Point(152, 552)
        Me.Number19.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number19.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number19.Name = "Number19"
        Me.Number19.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number19.Size = New System.Drawing.Size(132, 20)
        Me.Number19.TabIndex = 19
        Me.Number19.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number20
        '
        Me.Number20.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number20.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number20.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number20.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number20.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number20.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number20.Location = New System.Drawing.Point(152, 572)
        Me.Number20.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number20.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number20.Name = "Number20"
        Me.Number20.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number20.Size = New System.Drawing.Size(132, 20)
        Me.Number20.TabIndex = 20
        Me.Number20.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number10
        '
        Me.Number10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number10.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number10.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number10.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number10.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number10.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number10.Location = New System.Drawing.Point(152, 364)
        Me.Number10.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number10.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number10.Name = "Number10"
        Me.Number10.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number10.Size = New System.Drawing.Size(132, 20)
        Me.Number10.TabIndex = 10
        Me.Number10.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number09
        '
        Me.Number09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number09.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number09.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number09.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number09.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number09.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number09.Location = New System.Drawing.Point(152, 344)
        Me.Number09.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number09.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number09.Name = "Number09"
        Me.Number09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number09.Size = New System.Drawing.Size(132, 20)
        Me.Number09.TabIndex = 9
        Me.Number09.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number08
        '
        Me.Number08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number08.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number08.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number08.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number08.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number08.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number08.Location = New System.Drawing.Point(152, 324)
        Me.Number08.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number08.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number08.Name = "Number08"
        Me.Number08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number08.Size = New System.Drawing.Size(132, 20)
        Me.Number08.TabIndex = 8
        Me.Number08.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number07
        '
        Me.Number07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number07.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number07.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number07.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number07.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number07.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number07.Location = New System.Drawing.Point(152, 304)
        Me.Number07.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number07.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number07.Name = "Number07"
        Me.Number07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number07.Size = New System.Drawing.Size(132, 20)
        Me.Number07.TabIndex = 7
        Me.Number07.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number06
        '
        Me.Number06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number06.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number06.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number06.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number06.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number06.Enabled = False
        Me.Number06.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number06.Location = New System.Drawing.Point(152, 276)
        Me.Number06.MaxValue = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.Number06.MinValue = New Decimal(New Integer() {1410065407, 2, 0, -2147483648})
        Me.Number06.Name = "Number06"
        Me.Number06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number06.Size = New System.Drawing.Size(132, 20)
        Me.Number06.TabIndex = 6
        Me.Number06.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number05
        '
        Me.Number05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number05.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number05.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number05.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number05.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number05.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number05.Location = New System.Drawing.Point(152, 248)
        Me.Number05.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number05.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number05.Name = "Number05"
        Me.Number05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number05.Size = New System.Drawing.Size(132, 20)
        Me.Number05.TabIndex = 5
        Me.Number05.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number04
        '
        Me.Number04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number04.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number04.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number04.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number04.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number04.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number04.Location = New System.Drawing.Point(152, 228)
        Me.Number04.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number04.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number04.Name = "Number04"
        Me.Number04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number04.Size = New System.Drawing.Size(132, 20)
        Me.Number04.TabIndex = 4
        Me.Number04.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number03
        '
        Me.Number03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number03.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number03.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number03.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number03.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number03.Location = New System.Drawing.Point(152, 208)
        Me.Number03.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number03.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number03.Name = "Number03"
        Me.Number03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number03.Size = New System.Drawing.Size(132, 20)
        Me.Number03.TabIndex = 3
        Me.Number03.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number02
        '
        Me.Number02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number02.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number02.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number02.Location = New System.Drawing.Point(152, 188)
        Me.Number02.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(132, 20)
        Me.Number02.TabIndex = 2
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Number01
        '
        Me.Number01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number01.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number01.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number01.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number01.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number01.Enabled = False
        Me.Number01.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number01.Location = New System.Drawing.Point(152, 168)
        Me.Number01.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number01.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number01.Name = "Number01"
        Me.Number01.ReadOnly = True
        Me.Number01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number01.Size = New System.Drawing.Size(132, 20)
        Me.Number01.TabIndex = 1
        Me.Number01.TabStop = False
        Me.Number01.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(564, 664)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 24)
        Me.Button5.TabIndex = 27
        Me.Button5.Text = "印刷"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(664, 664)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 28
        Me.Button98.Text = "戻る"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Navy
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(32, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 20)
        Me.Label22.TabIndex = 1901
        Me.Label22.Text = "仕入先コード"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(172, 56)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(544, 16)
        Me.Label23.TabIndex = 1902
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(92, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 16)
        Me.Label18.TabIndex = 1904
        Me.Label18.Text = "〒141-0031"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Edit5)
        Me.Panel1.Location = New System.Drawing.Point(16, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 108)
        Me.Panel1.TabIndex = 0
        '
        'Edit5
        '
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit5.LengthAsByte = True
        Me.Edit5.Location = New System.Drawing.Point(168, 76)
        Me.Edit5.MaxLength = 20
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(144, 20)
        Me.Edit5.TabIndex = 0
        Me.Edit5.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Navy
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(20, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 20)
        Me.Label19.TabIndex = 1907
        Me.Label19.Text = "当月納品高（MT/FD)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Navy
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(20, 188)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(132, 20)
        Me.Label20.TabIndex = 1908
        Me.Label20.Text = "伝　票　請　求　分"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Navy
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(20, 208)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(132, 20)
        Me.Label21.TabIndex = 1909
        Me.Label21.Text = "前月アンマッチ分"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Navy
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(20, 276)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(132, 20)
        Me.Label25.TabIndex = 1910
        Me.Label25.Text = "納　　　品　　　高"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Navy
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(44, 304)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(108, 20)
        Me.Label28.TabIndex = 1911
        Me.Label28.Text = "差額リベート"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(44, 324)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 20)
        Me.Label29.TabIndex = 1912
        Me.Label29.Text = "単品リベート"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(44, 344)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(108, 20)
        Me.Label30.TabIndex = 1913
        Me.Label30.Text = "在庫補償"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Navy
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(44, 364)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(108, 20)
        Me.Label31.TabIndex = 1914
        Me.Label31.Text = "キャンペーンR"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Navy
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(44, 384)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(108, 20)
        Me.Label32.TabIndex = 1915
        Me.Label32.Text = "達成リベート"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Navy
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(44, 404)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(108, 20)
        Me.Label33.TabIndex = 1916
        Me.Label33.Text = "仕入控除（　％）"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Navy
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(20, 424)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(132, 20)
        Me.Label34.TabIndex = 1917
        Me.Label34.Text = "控　除　項　目　合　計"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(20, 444)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(132, 20)
        Me.Label35.TabIndex = 1918
        Me.Label35.Text = "仕　　　入　　　高"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Navy
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(44, 472)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(108, 20)
        Me.Label36.TabIndex = 1919
        Me.Label36.Text = "販促協賛金"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Navy
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(44, 492)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(108, 20)
        Me.Label37.TabIndex = 1920
        Me.Label37.Text = "オープン協賛金"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Navy
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(20, 304)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(24, 120)
        Me.Label38.TabIndex = 1921
        Me.Label38.Text = "控除項目"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Navy
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(44, 512)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 20)
        Me.Label39.TabIndex = 1922
        Me.Label39.Text = "サービス助成金"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Navy
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(44, 532)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(108, 20)
        Me.Label40.TabIndex = 1923
        Me.Label40.Text = "交換手数料"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Navy
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(44, 552)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(108, 20)
        Me.Label41.TabIndex = 1924
        Me.Label41.Text = "請求データ料"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Navy
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(20, 592)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(132, 20)
        Me.Label42.TabIndex = 1925
        Me.Label42.Text = "相　殺　項　目　合　計"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Navy
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(20, 472)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(24, 120)
        Me.Label43.TabIndex = 1926
        Me.Label43.Text = "相殺項目"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Navy
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(20, 228)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(132, 20)
        Me.Label44.TabIndex = 1927
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Navy
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(20, 248)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(132, 20)
        Me.Label45.TabIndex = 1928
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Navy
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(44, 572)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(108, 20)
        Me.Label46.TabIndex = 1929
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Navy
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(20, 612)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(132, 20)
        Me.Label47.TabIndex = 1930
        Me.Label47.Text = "振込手数料"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Navy
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(20, 632)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(132, 20)
        Me.Label48.TabIndex = 1931
        Me.Label48.Text = "税別当月請求金額"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Navy
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(20, 652)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(132, 20)
        Me.Label49.TabIndex = 1932
        Me.Label49.Text = "税込当月請求金額"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Navy
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(20, 680)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(36, 40)
        Me.Label26.TabIndex = 1933
        Me.Label26.Text = "支払条件"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Navy
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(56, 700)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(96, 20)
        Me.Label50.TabIndex = 1934
        Me.Label50.Text = "手形"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number00
        '
        Me.Number00.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Number00.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number00.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        Me.Number00.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number00.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Number00.DropDownCalculator.Size = New System.Drawing.Size(210, 186)
        Me.Number00.Enabled = False
        Me.Number00.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number00.Location = New System.Drawing.Point(100, 148)
        Me.Number00.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number00.MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Number00.Name = "Number00"
        Me.Number00.ReadOnly = True
        Me.Number00.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number00.Size = New System.Drawing.Size(52, 20)
        Me.Number00.TabIndex = 1935
        Me.Number00.TabStop = False
        Me.Number00.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number00.Visible = False
        '
        'Edit1
        '
        Me.Edit1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit1.Location = New System.Drawing.Point(596, 8)
        Me.Edit1.Name = "Edit1"
        Me.Edit1.ReadOnly = True
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(144, 20)
        Me.Edit1.TabIndex = 1936
        Me.Edit1.TabStop = False
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(504, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 1937
        Me.Label1.Text = "請求書番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F60_Form02
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.ClientSize = New System.Drawing.Size(750, 732)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Number00)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Number21)
        Me.Controls.Add(Me.Number22)
        Me.Controls.Add(Me.Number23)
        Me.Controls.Add(Me.Number24)
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
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F60_Form02"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請求書入力"
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number24, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Number10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F60_Form02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

                If Not IsDBNull(DtView1(0)("client_code")) Then Label6.Text = DtView1(0)("client_code") Else Label6.Text = Nothing

                Label11.Text = "グローバルソリューションサービス㈱"
                If Not IsDBNull(DtView1(0)("brch_zip")) Then Label18.Text = "〒" & Mid(DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(DtView1(0)("brch_zip"), 4, 4) Else Label18.Text = Nothing
                If Not IsDBNull(DtView1(0)("brch_adrs1")) Then Label12.Text = DtView1(0)("brch_adrs1") Else Label19.Text = Nothing
                If Not IsDBNull(DtView1(0)("brch_adrs2")) Then Label12.Text = Label12.Text & "  " & DtView1(0)("brch_adrs2")
                If Not IsDBNull(DtView1(0)("brch_tel")) Then Label23.Text = "TEL " & DtView1(0)("brch_tel") Else Label21.Text = Nothing
                If Not IsDBNull(DtView1(0)("brch_fax")) Then Label23.Text = Label23.Text & "  FAX " & DtView1(0)("brch_fax")

                Number00.Value = DtView1(0)("cnt")
                Number01.Value = DtView1(0)("amnt1")
                Number17.Value = Number00.Value * 3000
                Number19.Value = Number00.Value * 5

                If Not IsDBNull(DtView1(0)("invc_empl_name")) Then Edit5.Text = DtView1(0)("invc_empl_name") Else Edit5.Text = Nothing

                If P_F60_1 <> "0" Then   '再印刷
                    Edit1.Text = P_F60_1

                    If Not IsDBNull(DtView1(0)("B_amnt02")) Then Number02.Value = DtView1(0)("B_amnt02") Else Number02.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt03")) Then Number03.Value = DtView1(0)("B_amnt03") Else Number03.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt04")) Then Number04.Value = DtView1(0)("B_amnt04") Else Number04.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt05")) Then Number05.Value = DtView1(0)("B_amnt05") Else Number05.Value = 0
                    'If Not IsDBNull(DtView1(0)("B_amnt06")) Then Number06.Value = DtView1(0)("B_amnt06") Else Number06.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt07")) Then Number07.Value = DtView1(0)("B_amnt07") Else Number07.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt08")) Then Number08.Value = DtView1(0)("B_amnt08") Else Number08.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt09")) Then Number09.Value = DtView1(0)("B_amnt09") Else Number09.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt10")) Then Number10.Value = DtView1(0)("B_amnt10") Else Number10.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt11")) Then Number11.Value = DtView1(0)("B_amnt11") Else Number11.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt12")) Then Number12.Value = DtView1(0)("B_amnt12") Else Number12.Value = 0
                    'If Not IsDBNull(DtView1(0)("B_amnt13")) Then Number13.Value = DtView1(0)("B_amnt13") Else Number13.Value = 0
                    'If Not IsDBNull(DtView1(0)("B_amnt14")) Then Number14.Value = DtView1(0)("B_amnt14") Else Number14.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt15")) Then Number15.Value = DtView1(0)("B_amnt15") Else Number15.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt16")) Then Number16.Value = DtView1(0)("B_amnt16") Else Number16.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt17")) Then Number17.Value = DtView1(0)("B_amnt17") Else Number17.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt18")) Then Number18.Value = DtView1(0)("B_amnt18") Else Number18.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt19")) Then Number19.Value = DtView1(0)("B_amnt19") Else Number19.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt20")) Then Number20.Value = DtView1(0)("B_amnt20") Else Number20.Value = 0
                    'If Not IsDBNull(DtView1(0)("B_amnt21")) Then Number21.Value = DtView1(0)("B_amnt21") Else Number21.Value = 0
                    If Not IsDBNull(DtView1(0)("B_amnt22")) Then Number22.Value = DtView1(0)("B_amnt22") Else Number22.Value = 0
                    'If Not IsDBNull(DtView1(0)("B_amnt23")) Then Number23.Value = DtView1(0)("B_amnt23") Else Number23.Value = 0
                    'If Not IsDBNull(DtView1(0)("B_amnt24")) Then Number24.Value = DtView1(0)("B_amnt24") Else Number24.Value = 0
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
                        strSQL = strSQL & ", invc_amnt, cnt, tax_rate, invc_empl_name, B_amnt02, B_amnt03, B_amnt04, B_amnt05"
                        strSQL = strSQL & ", B_amnt06, B_amnt07, B_amnt08, B_amnt09, B_amnt10, B_amnt11, B_amnt12, B_amnt13"
                        strSQL = strSQL & ", B_amnt14, B_amnt15, B_amnt16, B_amnt17, B_amnt18, B_amnt19, B_amnt20, B_amnt21"
                        strSQL = strSQL & ", B_amnt22, B_amnt23, B_amnt24)"
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
                        strSQL = strSQL & ", " & Number02.Value & ""
                        strSQL = strSQL & ", " & Number03.Value & ""
                        strSQL = strSQL & ", " & Number04.Value & ""
                        strSQL = strSQL & ", " & Number05.Value & ""
                        strSQL = strSQL & ", " & Number06.Value & ""
                        strSQL = strSQL & ", " & Number07.Value & ""
                        strSQL = strSQL & ", " & Number08.Value & ""
                        strSQL = strSQL & ", " & Number09.Value & ""
                        strSQL = strSQL & ", " & Number10.Value & ""
                        strSQL = strSQL & ", " & Number11.Value & ""
                        strSQL = strSQL & ", " & Number12.Value & ""
                        strSQL = strSQL & ", " & Number13.Value & ""
                        strSQL = strSQL & ", " & Number14.Value & ""
                        strSQL = strSQL & ", " & Number15.Value & ""
                        strSQL = strSQL & ", " & Number16.Value & ""
                        strSQL = strSQL & ", " & Number17.Value & ""
                        strSQL = strSQL & ", " & Number18.Value & ""
                        strSQL = strSQL & ", " & Number19.Value & ""
                        strSQL = strSQL & ", " & Number20.Value & ""
                        strSQL = strSQL & ", " & Number21.Value & ""
                        strSQL = strSQL & ", " & Number22.Value & ""
                        strSQL = strSQL & ", " & Number23.Value & ""
                        strSQL = strSQL & ", " & Number24.Value & ")"
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
                    strSQL = strSQL & " SET B_amnt02 = " & Number02.Value & ""
                    strSQL = strSQL & ", B_amnt03 = " & Number03.Value & ""
                    strSQL = strSQL & ", B_amnt04 = " & Number04.Value & ""
                    strSQL = strSQL & ", B_amnt05 = " & Number05.Value & ""
                    strSQL = strSQL & ", B_amnt06 = " & Number06.Value & ""
                    strSQL = strSQL & ", B_amnt07 = " & Number07.Value & ""
                    strSQL = strSQL & ", B_amnt08 = " & Number08.Value & ""
                    strSQL = strSQL & ", B_amnt09 = " & Number09.Value & ""
                    strSQL = strSQL & ", B_amnt10 = " & Number10.Value & ""
                    strSQL = strSQL & ", B_amnt11 = " & Number11.Value & ""
                    strSQL = strSQL & ", B_amnt12 = " & Number12.Value & ""
                    strSQL = strSQL & ", B_amnt13 = " & Number13.Value & ""
                    strSQL = strSQL & ", B_amnt14 = " & Number14.Value & ""
                    strSQL = strSQL & ", B_amnt15 = " & Number15.Value & ""
                    strSQL = strSQL & ", B_amnt16 = " & Number16.Value & ""
                    strSQL = strSQL & ", B_amnt17 = " & Number17.Value & ""
                    strSQL = strSQL & ", B_amnt18 = " & Number18.Value & ""
                    strSQL = strSQL & ", B_amnt19 = " & Number19.Value & ""
                    strSQL = strSQL & ", B_amnt20 = " & Number20.Value & ""
                    strSQL = strSQL & ", B_amnt21 = " & Number21.Value & ""
                    strSQL = strSQL & ", B_amnt22 = " & Number22.Value & ""
                    strSQL = strSQL & ", B_amnt23 = " & Number23.Value & ""
                    strSQL = strSQL & ", B_amnt24 = " & Number24.Value & ""
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
                strSQL = strSQL & ", '" & "〒" & Mid(DtView2(0)("brch_zip"), 1, 3) & "-" & Mid(DtView2(0)("brch_zip"), 4, 4) & "' AS brch_zip"
                strSQL = strSQL & ", '" & DtView2(0)("brch_adrs1") & " " & DtView2(0)("brch_adrs2") & "' AS brch_adrs"
                strSQL = strSQL & ", '" & DtView2(0)("brch_name") & "' AS brch_name"
                strSQL = strSQL & ", 'TEL " & DtView2(0)("brch_tel") & "  FAX " & DtView2(0)("brch_fax") & "' AS brch_tel"

                strSQL = strSQL & ", '" & DtView2(0)("invc_empl_name") & "' AS empl_name"       '請求担当
                strSQL = strSQL & ", '" & DtView2(0)("invc_date") & "' AS invc_date"            '請求〆日
                strSQL = strSQL & ", '(" & DtView2(0)("client_code") & ")' AS client_code"        '仕入先コード

                If DtView2(0)("amnt1") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("amnt1"), "##,##0") & "' AS amnt1"     '金額
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
                If DtView2(0)("B_amnt11") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt11"), "##,##0") & "' AS amnt11"
                Else
                    strSQL = strSQL & ", '' AS amnt11"
                End If
                If DtView2(0)("B_amnt12") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt12"), "##,##0") & "' AS amnt12"
                Else
                    strSQL = strSQL & ", '' AS amnt12"
                End If
                If DtView2(0)("B_amnt13") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt13"), "##,##0") & "' AS amnt13"
                Else
                    strSQL = strSQL & ", '' AS amnt13"
                End If
                If DtView2(0)("B_amnt14") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt14"), "##,##0") & "' AS amnt14"
                Else
                    strSQL = strSQL & ", '' AS amnt14"
                End If
                If DtView2(0)("B_amnt15") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt15"), "##,##0") & "' AS amnt15"
                Else
                    strSQL = strSQL & ", '' AS amnt15"
                End If
                If DtView2(0)("B_amnt16") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt16"), "##,##0") & "' AS amnt16"
                Else
                    strSQL = strSQL & ", '' AS amnt16"
                End If
                If DtView2(0)("B_amnt17") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt17"), "##,##0") & "' AS amnt17"
                Else
                    strSQL = strSQL & ", '' AS amnt17"
                End If
                If DtView2(0)("B_amnt18") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt18"), "##,##0") & "' AS amnt18"
                Else
                    strSQL = strSQL & ", '' AS amnt18"
                End If
                If DtView2(0)("B_amnt19") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt19"), "##,##0") & "' AS amnt19"
                Else
                    strSQL = strSQL & ", '' AS amnt19"
                End If
                If DtView2(0)("B_amnt20") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt20"), "##,##0") & "' AS amnt20"
                Else
                    strSQL = strSQL & ", '' AS amnt20"
                End If
                If DtView2(0)("B_amnt21") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt21"), "##,##0") & "' AS amnt21"
                Else
                    strSQL = strSQL & ", '' AS amnt21"
                End If
                If DtView2(0)("B_amnt22") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt22"), "##,##0") & "' AS amnt22"
                Else
                    strSQL = strSQL & ", '' AS amnt22"
                End If
                If DtView2(0)("B_amnt23") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt23"), "##,##0") & "' AS amnt23"
                Else
                    strSQL = strSQL & ", '' AS amnt23"
                End If
                If DtView2(0)("B_amnt24") <> 0 Then
                    strSQL = strSQL & ", '\" & Format(DtView2(0)("B_amnt24"), "##,##0") & "' AS amnt24"
                Else
                    strSQL = strSQL & ", '' AS amnt24"
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
    Private Sub Edit1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit2.GotFocus
        Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit3.GotFocus
        Edit2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit5.GotFocus
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

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit2.LostFocus
        Edit1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit3.LostFocus
        Edit2.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit5.LostFocus
        Edit5.BackColor = System.Drawing.SystemColors.Window
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

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Number01_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number01.TextChanged
        Number06_sum()
    End Sub
    Private Sub Number02_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.TextChanged
        Number06_sum()
    End Sub
    Private Sub Number03_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number03.TextChanged
        Number06_sum()
    End Sub
    Private Sub Number04_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number04.TextChanged
        Number06_sum()
    End Sub
    Private Sub Number05_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number05.TextChanged
        Number06_sum()
    End Sub
    Private Sub Number06_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number06.TextChanged
        Number14_sum()
    End Sub
    Private Sub Number07_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number07.TextChanged
        Number13_sum()
    End Sub
    Private Sub Number08_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number08.TextChanged
        Number13_sum()
    End Sub
    Private Sub Number09_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number09.TextChanged
        Number13_sum()
    End Sub
    Private Sub Number10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number10.TextChanged
        Number13_sum()
    End Sub
    Private Sub Number11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number11.TextChanged
        Number13_sum()
    End Sub
    Private Sub Number12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number12.TextChanged
        Number13_sum()
    End Sub
    Private Sub Number13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number13.TextChanged
        Number14_sum()
    End Sub
    Private Sub Number14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number14.TextChanged
        Number23_sum()
    End Sub
    Private Sub Number15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number15.TextChanged
        Number21_sum()
    End Sub
    Private Sub Number16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number16.TextChanged
        Number21_sum()
    End Sub
    Private Sub Number17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number17.TextChanged
        Number21_sum()
    End Sub
    Private Sub Number18_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number18.TextChanged
        Number21_sum()
    End Sub
    Private Sub Number19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number19.TextChanged
        Number21_sum()
    End Sub
    Private Sub Number20_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number20.TextChanged
        Number21_sum()
    End Sub
    Private Sub Number21_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number21.TextChanged
        Number23_sum()
    End Sub
    Private Sub Number22_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number22.TextChanged
        Number23_sum()
    End Sub
    Private Sub Number23_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number23.TextChanged
        Number24_sum()
    End Sub

    Sub Number06_sum()
        Number06.Value = Number01.Value + Number02.Value + Number03.Value + Number04.Value + Number05.Value
    End Sub
    Sub Number13_sum()
        Number13.Value = Number07.Value + Number08.Value + Number09.Value + Number10.Value + Number11.Value + Number12.Value
    End Sub
    Sub Number14_sum()
        Number14.Value = Number06.Value - Number13.Value
    End Sub
    Sub Number21_sum()
        Number21.Value = Number15.Value + Number16.Value + Number17.Value + Number18.Value + Number19.Value + Number20.Value
    End Sub
    Sub Number23_sum()
        Number23.Value = Number14.Value - Number21.Value - Number22.Value
    End Sub
    Sub Number24_sum()
        Number24.Value = RoundDOWN(Number23.Value * 1.1, 0)
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
