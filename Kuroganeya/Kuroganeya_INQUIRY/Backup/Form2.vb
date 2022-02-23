Public Class Form2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim DtView1 As DataView

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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit6 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit7 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit8 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit9 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit10 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit11 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit12 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit13 As GrapeCity.Win.Input.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.Button99 = New System.Windows.Forms.Button
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Label104 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit3 = New GrapeCity.Win.Input.Edit
        Me.Edit4 = New GrapeCity.Win.Input.Edit
        Me.Edit5 = New GrapeCity.Win.Input.Edit
        Me.Edit6 = New GrapeCity.Win.Input.Edit
        Me.Edit7 = New GrapeCity.Win.Input.Edit
        Me.Edit8 = New GrapeCity.Win.Input.Edit
        Me.Edit9 = New GrapeCity.Win.Input.Edit
        Me.Edit2 = New GrapeCity.Win.Input.Edit
        Me.Edit10 = New GrapeCity.Win.Input.Edit
        Me.Edit11 = New GrapeCity.Win.Input.Edit
        Me.Edit12 = New GrapeCity.Win.Input.Edit
        Me.Edit13 = New GrapeCity.Win.Input.Edit
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Button99.Location = New System.Drawing.Point(712, 348)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(96, 30)
        Me.Button99.TabIndex = 14
        Me.Button99.Text = "閉じる"
        '
        'Date1
        '
        Me.Date1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Location = New System.Drawing.Point(144, 24)
        Me.Date1.Name = "Date1"
        Me.Date1.ReadOnly = True
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(152, 24)
        Me.Date1.TabIndex = 0
        Me.Date1.TabStop = False
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2010, 9, 10, 16, 36, 0, 0))
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.White
        Me.Label104.Location = New System.Drawing.Point(40, 24)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(104, 24)
        Me.Label104.TabIndex = 1086
        Me.Label104.Text = "問合せ日時"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(40, 236)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 100)
        Me.Label19.TabIndex = 1085
        Me.Label19.Text = "問合せ内容"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(420, 208)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(104, 23)
        Me.Label27.TabIndex = 1084
        Me.Label27.Text = "対応結果２"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(416, 96)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(136, 23)
        Me.Label26.TabIndex = 1083
        Me.Label26.Text = "コール内容"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(420, 180)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 23)
        Me.Label25.TabIndex = 1082
        Me.Label25.Text = "対応結果１"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(448, 152)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 23)
        Me.Label22.TabIndex = 1080
        Me.Label22.Text = "意見・要望系"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(448, 124)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 23)
        Me.Label23.TabIndex = 1079
        Me.Label23.Text = "不具合系"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(416, 68)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 23)
        Me.Label21.TabIndex = 1078
        Me.Label21.Text = "購入後"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(40, 208)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 23)
        Me.Label20.TabIndex = 1077
        Me.Label20.Text = "購入店舗"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(40, 180)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 23)
        Me.Label17.TabIndex = 1076
        Me.Label17.Text = "商　品"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(40, 152)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 23)
        Me.Label16.TabIndex = 1075
        Me.Label16.Text = "地　域"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(40, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 23)
        Me.Label15.TabIndex = 1074
        Me.Label15.Text = "性　別"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(40, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 1073
        Me.Label7.Text = "年齢層"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(40, 68)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 23)
        Me.Label18.TabIndex = 1072
        Me.Label18.Text = "相手先"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.Location = New System.Drawing.Point(420, 24)
        Me.Edit1.MaxLength = 1000
        Me.Edit1.Name = "Edit1"
        Me.Edit1.ReadOnly = True
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(256, 24)
        Me.Edit1.TabIndex = 1
        Me.Edit1.TabStop = False
        Me.Edit1.Text = "Edit1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(316, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 1088
        Me.Label1.Text = "対応者"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit3
        '
        Me.Edit3.HighlightText = True
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit3.Location = New System.Drawing.Point(144, 96)
        Me.Edit3.MaxLength = 1000
        Me.Edit3.Name = "Edit3"
        Me.Edit3.ReadOnly = True
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(256, 24)
        Me.Edit3.TabIndex = 3
        Me.Edit3.TabStop = False
        '
        'Edit4
        '
        Me.Edit4.HighlightText = True
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit4.Location = New System.Drawing.Point(144, 124)
        Me.Edit4.MaxLength = 1000
        Me.Edit4.Name = "Edit4"
        Me.Edit4.ReadOnly = True
        Me.Edit4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit4.Size = New System.Drawing.Size(256, 24)
        Me.Edit4.TabIndex = 4
        Me.Edit4.TabStop = False
        '
        'Edit5
        '
        Me.Edit5.HighlightText = True
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit5.Location = New System.Drawing.Point(144, 152)
        Me.Edit5.MaxLength = 1000
        Me.Edit5.Name = "Edit5"
        Me.Edit5.ReadOnly = True
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(256, 24)
        Me.Edit5.TabIndex = 5
        Me.Edit5.TabStop = False
        '
        'Edit6
        '
        Me.Edit6.HighlightText = True
        Me.Edit6.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit6.Location = New System.Drawing.Point(144, 180)
        Me.Edit6.MaxLength = 1000
        Me.Edit6.Name = "Edit6"
        Me.Edit6.ReadOnly = True
        Me.Edit6.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit6.Size = New System.Drawing.Size(256, 24)
        Me.Edit6.TabIndex = 6
        Me.Edit6.TabStop = False
        '
        'Edit7
        '
        Me.Edit7.HighlightText = True
        Me.Edit7.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit7.Location = New System.Drawing.Point(144, 208)
        Me.Edit7.MaxLength = 1000
        Me.Edit7.Name = "Edit7"
        Me.Edit7.ReadOnly = True
        Me.Edit7.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit7.Size = New System.Drawing.Size(256, 24)
        Me.Edit7.TabIndex = 7
        Me.Edit7.TabStop = False
        '
        'Edit8
        '
        Me.Edit8.HighlightText = True
        Me.Edit8.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit8.LengthAsByte = True
        Me.Edit8.Location = New System.Drawing.Point(144, 236)
        Me.Edit8.MaxLength = 1000
        Me.Edit8.Multiline = True
        Me.Edit8.Name = "Edit8"
        Me.Edit8.ReadOnly = True
        Me.Edit8.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Edit8.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit8.Size = New System.Drawing.Size(664, 100)
        Me.Edit8.TabIndex = 13
        Me.Edit8.TabStop = False
        '
        'Edit9
        '
        Me.Edit9.HighlightText = True
        Me.Edit9.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit9.Location = New System.Drawing.Point(520, 68)
        Me.Edit9.MaxLength = 1000
        Me.Edit9.Name = "Edit9"
        Me.Edit9.ReadOnly = True
        Me.Edit9.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit9.Size = New System.Drawing.Size(120, 24)
        Me.Edit9.TabIndex = 8
        Me.Edit9.TabStop = False
        '
        'Edit2
        '
        Me.Edit2.HighlightText = True
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit2.Location = New System.Drawing.Point(144, 68)
        Me.Edit2.MaxLength = 1000
        Me.Edit2.Name = "Edit2"
        Me.Edit2.ReadOnly = True
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(256, 24)
        Me.Edit2.TabIndex = 2
        Me.Edit2.TabStop = False
        '
        'Edit10
        '
        Me.Edit10.HighlightText = True
        Me.Edit10.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit10.Location = New System.Drawing.Point(552, 124)
        Me.Edit10.MaxLength = 1000
        Me.Edit10.Name = "Edit10"
        Me.Edit10.ReadOnly = True
        Me.Edit10.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit10.Size = New System.Drawing.Size(256, 24)
        Me.Edit10.TabIndex = 9
        Me.Edit10.TabStop = False
        '
        'Edit11
        '
        Me.Edit11.HighlightText = True
        Me.Edit11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit11.Location = New System.Drawing.Point(552, 152)
        Me.Edit11.MaxLength = 1000
        Me.Edit11.Name = "Edit11"
        Me.Edit11.ReadOnly = True
        Me.Edit11.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit11.Size = New System.Drawing.Size(256, 24)
        Me.Edit11.TabIndex = 10
        Me.Edit11.TabStop = False
        '
        'Edit12
        '
        Me.Edit12.HighlightText = True
        Me.Edit12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit12.Location = New System.Drawing.Point(524, 180)
        Me.Edit12.MaxLength = 1000
        Me.Edit12.Name = "Edit12"
        Me.Edit12.ReadOnly = True
        Me.Edit12.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit12.Size = New System.Drawing.Size(284, 24)
        Me.Edit12.TabIndex = 11
        Me.Edit12.TabStop = False
        '
        'Edit13
        '
        Me.Edit13.HighlightText = True
        Me.Edit13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit13.Location = New System.Drawing.Point(524, 208)
        Me.Edit13.MaxLength = 1000
        Me.Edit13.Name = "Edit13"
        Me.Edit13.ReadOnly = True
        Me.Edit13.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit13.Size = New System.Drawing.Size(284, 24)
        Me.Edit13.TabIndex = 12
        Me.Edit13.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(846, 391)
        Me.Controls.Add(Me.Edit13)
        Me.Controls.Add(Me.Edit12)
        Me.Controls.Add(Me.Edit11)
        Me.Controls.Add(Me.Edit10)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Edit9)
        Me.Controls.Add(Me.Edit8)
        Me.Controls.Add(Me.Edit7)
        Me.Controls.Add(Me.Edit6)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "その他問合せ"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*************************************************
    '** 起動時
    '*************************************************
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        DtView1 = New DataView(P_DsList1.Tables("scan"), "Q_NO = '" & P_Q_NO & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 1 Then
            Date1.Text = DtView1(0)("Q_DATE")
            Edit1.Text = DtView1(0)("EMPL_CODE") & ":" & Trim(DtView1(0)("EMPL_NAME"))
            Edit2.Text = Trim(DtView1(0)("CUST_CLS_name"))
            Edit3.Text = Trim(DtView1(0)("SEX_name"))
            If Not IsDBNull(DtView1(0)("AGE_CLS_name")) Then Edit4.Text = Trim(DtView1(0)("AGE_CLS_name"))
            If Not IsDBNull(DtView1(0)("AREA_CLS_name")) Then Edit5.Text = Trim(DtView1(0)("AREA_CLS_name"))
            If Not IsDBNull(DtView1(0)("CAT_NAME")) Then Edit6.Text = DtView1(0)("CAT_CODE") & ":" & Trim(DtView1(0)("CAT_NAME"))
            If Not IsDBNull(DtView1(0)("SHOP_NAME")) Then Edit7.Text = DtView1(0)("SHOP_CODE") & ":" & Trim(DtView1(0)("SHOP_NAME"))
            If Not IsDBNull(DtView1(0)("ASKING")) Then Edit8.Text = Trim(DtView1(0)("ASKING"))
            If Not IsDBNull(DtView1(0)("YEAR_CLS_name")) Then Edit9.Text = Trim(DtView1(0)("YEAR_CLS_name")) & "年"
            If Not IsDBNull(DtView1(0)("MONTHS_CLS_name")) Then Edit9.Text = Edit9.Text & Trim(DtView1(0)("MONTHS_CLS_name")) & "ヶ月"
            If Not IsDBNull(DtView1(0)("CALL1_CLS_name")) Then Edit10.Text = Trim(DtView1(0)("CALL1_CLS_name"))
            If Not IsDBNull(DtView1(0)("CALL2_CLS_name")) Then Edit11.Text = Trim(DtView1(0)("CALL2_CLS_name"))
            Edit12.Text = Trim(DtView1(0)("RPLY_CLS1_name"))
            Edit13.Text = Trim(DtView1(0)("RPLY_CLS2_name"))
        End If

    End Sub

    '*********************************************************
    '** 閉じる
    '*********************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Me.Close()
    End Sub
End Class
