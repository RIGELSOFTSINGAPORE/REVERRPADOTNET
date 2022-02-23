Public Class F00_Form02_4
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F, strDATA(31), WK_str, ans, Main_skp As String
    Dim i, r, pos, len As Integer

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
    Friend WithEvents Mask09 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Edit30 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit29 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit15 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit14 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit13 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit12 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit11 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit10 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Edit28 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form02_4))
        Me.Mask09 = New GrapeCity.Win.Input.Interop.Mask
        Me.Edit30 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit29 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit15 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit14 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit13 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit12 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit11 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit10 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit08 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Edit28 = New GrapeCity.Win.Input.Interop.Edit
        Me.msg = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Mask09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit28, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Mask09
        '
        Me.Mask09.Format = New GrapeCity.Win.Input.Interop.MaskFormat("〒 \D{3}-\D{4}", "", "")
        Me.Mask09.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Mask09.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask09.Location = New System.Drawing.Point(160, 264)
        Me.Mask09.Name = "Mask09"
        Me.Mask09.ReadOnly = True
        Me.Mask09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Mask09.Size = New System.Drawing.Size(100, 24)
        Me.Mask09.TabIndex = 53
        Me.Mask09.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask09.Value = "0900006"
        '
        'Edit30
        '
        Me.Edit30.HighlightText = True
        Me.Edit30.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit30.LengthAsByte = True
        Me.Edit30.Location = New System.Drawing.Point(160, 488)
        Me.Edit30.MaxLength = 60
        Me.Edit30.Name = "Edit30"
        Me.Edit30.ReadOnly = True
        Me.Edit30.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit30.Size = New System.Drawing.Size(328, 24)
        Me.Edit30.TabIndex = 67
        Me.Edit30.Text = "Edit30"
        Me.Edit30.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit29
        '
        Me.Edit29.HighlightText = True
        Me.Edit29.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit29.LengthAsByte = True
        Me.Edit29.Location = New System.Drawing.Point(316, 564)
        Me.Edit29.MaxLength = 10
        Me.Edit29.Name = "Edit29"
        Me.Edit29.ReadOnly = True
        Me.Edit29.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit29.Size = New System.Drawing.Size(120, 24)
        Me.Edit29.TabIndex = 66
        Me.Edit29.Text = "Edit29"
        Me.Edit29.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Edit29.Visible = False
        '
        'Edit15
        '
        Me.Edit15.HighlightText = True
        Me.Edit15.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit15.LengthAsByte = True
        Me.Edit15.Location = New System.Drawing.Point(160, 432)
        Me.Edit15.MaxLength = 40
        Me.Edit15.Name = "Edit15"
        Me.Edit15.ReadOnly = True
        Me.Edit15.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit15.Size = New System.Drawing.Size(328, 24)
        Me.Edit15.TabIndex = 61
        Me.Edit15.Text = "Edit15"
        Me.Edit15.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit14
        '
        Me.Edit14.HighlightText = True
        Me.Edit14.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit14.LengthAsByte = True
        Me.Edit14.Location = New System.Drawing.Point(160, 404)
        Me.Edit14.MaxLength = 10
        Me.Edit14.Name = "Edit14"
        Me.Edit14.ReadOnly = True
        Me.Edit14.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit14.Size = New System.Drawing.Size(100, 24)
        Me.Edit14.TabIndex = 60
        Me.Edit14.Text = "Edit14"
        Me.Edit14.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit13
        '
        Me.Edit13.HighlightText = True
        Me.Edit13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit13.LengthAsByte = True
        Me.Edit13.Location = New System.Drawing.Point(160, 376)
        Me.Edit13.MaxLength = 2
        Me.Edit13.Name = "Edit13"
        Me.Edit13.ReadOnly = True
        Me.Edit13.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit13.Size = New System.Drawing.Size(32, 24)
        Me.Edit13.TabIndex = 59
        Me.Edit13.Text = "Ed"
        Me.Edit13.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit12
        '
        Me.Edit12.HighlightText = True
        Me.Edit12.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit12.LengthAsByte = True
        Me.Edit12.Location = New System.Drawing.Point(160, 348)
        Me.Edit12.MaxLength = 80
        Me.Edit12.Name = "Edit12"
        Me.Edit12.ReadOnly = True
        Me.Edit12.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit12.Size = New System.Drawing.Size(328, 24)
        Me.Edit12.TabIndex = 58
        Me.Edit12.Text = "Edit12"
        Me.Edit12.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit11
        '
        Me.Edit11.HighlightText = True
        Me.Edit11.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit11.LengthAsByte = True
        Me.Edit11.Location = New System.Drawing.Point(160, 320)
        Me.Edit11.MaxLength = 80
        Me.Edit11.Name = "Edit11"
        Me.Edit11.ReadOnly = True
        Me.Edit11.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit11.Size = New System.Drawing.Size(328, 24)
        Me.Edit11.TabIndex = 57
        Me.Edit11.Text = "Edit11"
        Me.Edit11.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit10
        '
        Me.Edit10.HighlightText = True
        Me.Edit10.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit10.LengthAsByte = True
        Me.Edit10.Location = New System.Drawing.Point(160, 292)
        Me.Edit10.MaxLength = 80
        Me.Edit10.Name = "Edit10"
        Me.Edit10.ReadOnly = True
        Me.Edit10.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit10.Size = New System.Drawing.Size(328, 24)
        Me.Edit10.TabIndex = 55
        Me.Edit10.Text = "Edit10"
        Me.Edit10.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit08
        '
        Me.Edit08.AllowSpace = False
        Me.Edit08.Format = "9"
        Me.Edit08.HighlightText = True
        Me.Edit08.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit08.LengthAsByte = True
        Me.Edit08.Location = New System.Drawing.Point(160, 236)
        Me.Edit08.MaxLength = 11
        Me.Edit08.Name = "Edit08"
        Me.Edit08.ReadOnly = True
        Me.Edit08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit08.Size = New System.Drawing.Size(100, 24)
        Me.Edit08.TabIndex = 51
        Me.Edit08.Text = "08"
        Me.Edit08.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit07
        '
        Me.Edit07.AllowSpace = False
        Me.Edit07.HighlightText = True
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(160, 208)
        Me.Edit07.MaxLength = 40
        Me.Edit07.Name = "Edit07"
        Me.Edit07.ReadOnly = True
        Me.Edit07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit07.Size = New System.Drawing.Size(328, 24)
        Me.Edit07.TabIndex = 48
        Me.Edit07.Text = "Edit07"
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit06
        '
        Me.Edit06.AllowSpace = False
        Me.Edit06.HighlightText = True
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(160, 180)
        Me.Edit06.MaxLength = 40
        Me.Edit06.Name = "Edit06"
        Me.Edit06.ReadOnly = True
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(328, 24)
        Me.Edit06.TabIndex = 46
        Me.Edit06.Text = "Edit06"
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit05
        '
        Me.Edit05.AllowSpace = False
        Me.Edit05.Format = "9"
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(160, 152)
        Me.Edit05.MaxLength = 11
        Me.Edit05.Name = "Edit05"
        Me.Edit05.ReadOnly = True
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(100, 24)
        Me.Edit05.TabIndex = 44
        Me.Edit05.Text = "12345678901"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.AllowSpace = False
        Me.Edit04.HighlightText = True
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(160, 124)
        Me.Edit04.MaxLength = 40
        Me.Edit04.Name = "Edit04"
        Me.Edit04.ReadOnly = True
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(328, 24)
        Me.Edit04.TabIndex = 43
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit03
        '
        Me.Edit03.AllowSpace = False
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(160, 96)
        Me.Edit03.MaxLength = 40
        Me.Edit03.Name = "Edit03"
        Me.Edit03.ReadOnly = True
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(328, 24)
        Me.Edit03.TabIndex = 42
        Me.Edit03.Text = "1234567890123456789012345678901234567890"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Navy
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(16, 460)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(144, 24)
        Me.Label28.TabIndex = 73
        Me.Label28.Text = "店舗"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Navy
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(172, 564)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(144, 24)
        Me.Label29.TabIndex = 72
        Me.Label29.Text = "受付者社員コード"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label29.Visible = False
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Navy
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(16, 488)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(144, 24)
        Me.Label30.TabIndex = 71
        Me.Label30.Text = "受付者名"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(16, 292)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 24)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "住所"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(16, 320)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 24)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "丁目"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(16, 348)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 24)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "建物名"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 376)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 24)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "階上"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 404)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(144, 24)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "部屋名"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(16, 432)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 24)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "同居先"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(16, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 24)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "郵便番号"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(16, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 24)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "お申込者電話番号"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 24)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "お申込者（漢字）"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 24)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "お申込者（カナ）"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 24)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "ご使用者電話番号"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 24)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "ご使用者（漢字）"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 24)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "ご使用者（カナ）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(160, 524)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 28)
        Me.Button2.TabIndex = 76
        Me.Button2.Text = "入力データ優先"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 524)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 28)
        Me.Button1.TabIndex = 75
        Me.Button1.Text = "元データ優先"
        '
        'Edit28
        '
        Me.Edit28.DisabledForeColor = System.Drawing.Color.Red
        Me.Edit28.Location = New System.Drawing.Point(160, 460)
        Me.Edit28.Name = "Edit28"
        Me.Edit28.ReadOnly = True
        Me.Edit28.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit28.Size = New System.Drawing.Size(328, 24)
        Me.Edit28.TabIndex = 77
        Me.Edit28.Text = "Edit28"
        Me.Edit28.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 8)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(472, 44)
        Me.msg.TabIndex = 1184
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(472, 24)
        Me.Label1.TabIndex = 1185
        Me.Label1.Text = "元データ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F00_Form02_4
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(506, 587)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Edit28)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Mask09)
        Me.Controls.Add(Me.Edit30)
        Me.Controls.Add(Me.Edit29)
        Me.Controls.Add(Me.Edit15)
        Me.Controls.Add(Me.Edit14)
        Me.Controls.Add(Me.Edit13)
        Me.Controls.Add(Me.Edit12)
        Me.Controls.Add(Me.Edit11)
        Me.Controls.Add(Me.Edit10)
        Me.Controls.Add(Me.Edit08)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F00_Form02_4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "顧客情報アンマッチ"
        CType(Me.Mask09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit28, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form02_4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call dsp_set()  '** 画面セット
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = "顧客情報の元データと今回のデータが一致していません。どちらのデータを優先しますか？"
    End Sub

    '******************************************************************
    '** 画面セット
    '******************************************************************
    Sub dsp_set()
        DB_OPEN()

        DsList1.Clear()
        strSQL = "SELECT WRN_MAIN.*, Shop_mtr.shop_name"
        strSQL = strSQL & " FROM WRN_MAIN INNER JOIN"
        strSQL = strSQL & " Shop_mtr ON WRN_MAIN.shop_code = Shop_mtr.shop_code"
        strSQL = strSQL & " WHERE (WRN_MAIN.wrn_no = '" & P_PRAM2 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(DsList1, "WRN_MAIN")

        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("WRN_MAIN"), "", "", DataViewRowState.CurrentRows)
            Edit03.Text = DtView1(0)("user_name_KANA")
            Edit04.Text = DtView1(0)("user_name")
            Edit05.Text = DtView1(0)("user_tel_no")
            Edit06.Text = DtView1(0)("appl_name_KANA")
            Edit07.Text = DtView1(0)("appl_name")
            Edit08.Text = DtView1(0)("appl_tel_no")
            Mask09.Value = DtView1(0)("zip")
            Edit10.Text = DtView1(0)("adrs1")
            Edit11.Text = DtView1(0)("adrs2")
            Edit12.Text = DtView1(0)("adrs3")
            Edit13.Text = DtView1(0)("floor")
            Edit14.Text = DtView1(0)("room_name")
            Edit15.Text = DtView1(0)("livi_togr")
            Edit28.Text = DtView1(0)("shop_code") & ":" & DtView1(0)("shop_name")
            'Edit29.Text = DtView1(0)("rcpt_empl_code")
            Edit30.Text = DtView1(0)("rcpt_empl_name")
        End If

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** 元データ優先
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DsList1.Clear()
        P_MOTO = "1"
        Close()
    End Sub

    '********************************************************************
    '** 入力データ優先
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DsList1.Clear()
        P_MOTO = "2"
        Close()
    End Sub
End Class
