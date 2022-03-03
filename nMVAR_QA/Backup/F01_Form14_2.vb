Public Class F01_Form14_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, ERR_F, ANS, re_dsp As String
    Dim i, r As Integer

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.FunctionKey
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label0 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label002 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label004 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label005 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label006 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label007 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form14_2))
        Me.Label8 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Label7 = New System.Windows.Forms.Label
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.f12 = New System.Windows.Forms.Button
        Me.Label0 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.FunctionKey1 = New GrapeCity.Win.Input.FunctionKey
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label001 = New GrapeCity.Win.Input.Edit
        Me.Label002 = New GrapeCity.Win.Input.Edit
        Me.Label003 = New GrapeCity.Win.Input.Edit
        Me.Label004 = New GrapeCity.Win.Input.Edit
        Me.Label005 = New GrapeCity.Win.Input.Edit
        Me.Label006 = New GrapeCity.Win.Input.Edit
        Me.Label007 = New GrapeCity.Win.Input.Edit
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label007, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(16, 352)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 32)
        Me.Label8.TabIndex = 1861
        Me.Label8.Text = "配送伝票番号"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.AllowSpace = False
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Edit001.Format = "9A#"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(136, 352)
        Me.Edit001.MaxLength = 50
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(208, 32)
        Me.Edit001.TabIndex = 2
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 316)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 32)
        Me.Label7.TabIndex = 1863
        Me.Label7.Text = "出荷日"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(136, 316)
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(112, 32)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date001.Value = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 32)
        Me.Label1.TabIndex = 1865
        Me.Label1.Text = "受付番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 32)
        Me.Label2.TabIndex = 1867
        Me.Label2.Text = "お客様名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 32)
        Me.Label3.TabIndex = 1870
        Me.Label3.Text = "メーカー"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 32)
        Me.Label4.TabIndex = 1868
        Me.Label4.Text = "機種"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 32)
        Me.Label6.TabIndex = 1869
        Me.Label6.Text = "修理拠点"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 32)
        Me.Label5.TabIndex = 1876
        Me.Label5.Text = "S/N"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(16, 428)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "登録"
        '
        'f12
        '
        Me.f12.BackColor = System.Drawing.SystemColors.Control
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.f12.Location = New System.Drawing.Point(460, 428)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(68, 24)
        Me.f12.TabIndex = 4
        Me.f12.Text = "戻る"
        '
        'Label0
        '
        Me.Label0.BackColor = System.Drawing.Color.Navy
        Me.Label0.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label0.ForeColor = System.Drawing.Color.White
        Me.Label0.Location = New System.Drawing.Point(192, 8)
        Me.Label0.Name = "Label0"
        Me.Label0.Size = New System.Drawing.Size(204, 36)
        Me.Label0.TabIndex = 1880
        Me.Label0.Text = "出荷処理"
        Me.Label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 392)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(512, 24)
        Me.msg.TabIndex = 1881
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FunctionKey1
        '
        Me.FunctionKey1.ActiveKeySet = "Default"
        Me.FunctionKey1.Location = New System.Drawing.Point(0, 459)
        Me.FunctionKey1.Name = "FunctionKey1"
        Me.FunctionKey1.Size = New System.Drawing.Size(558, 0)
        Me.FunctionKey1.TabIndex = 1882
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(16, 280)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 32)
        Me.Label10.TabIndex = 1883
        Me.Label10.Text = "代引金額"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label001
        '
        Me.Label001.AllowSpace = False
        Me.Label001.BackColor = System.Drawing.SystemColors.Control
        Me.Label001.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label001.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label001.HighlightText = True
        Me.Label001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Label001.LengthAsByte = True
        Me.Label001.Location = New System.Drawing.Point(144, 64)
        Me.Label001.MaxLength = 50
        Me.Label001.Name = "Label001"
        Me.Label001.ReadOnly = True
        Me.Label001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label001.Size = New System.Drawing.Size(392, 32)
        Me.Label001.TabIndex = 1885
        Me.Label001.TabStop = False
        Me.Label001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label002
        '
        Me.Label002.AllowSpace = False
        Me.Label002.BackColor = System.Drawing.SystemColors.Control
        Me.Label002.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label002.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label002.HighlightText = True
        Me.Label002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Label002.LengthAsByte = True
        Me.Label002.Location = New System.Drawing.Point(144, 100)
        Me.Label002.MaxLength = 50
        Me.Label002.Name = "Label002"
        Me.Label002.ReadOnly = True
        Me.Label002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label002.Size = New System.Drawing.Size(392, 32)
        Me.Label002.TabIndex = 1886
        Me.Label002.TabStop = False
        Me.Label002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label003
        '
        Me.Label003.AllowSpace = False
        Me.Label003.BackColor = System.Drawing.SystemColors.Control
        Me.Label003.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label003.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label003.HighlightText = True
        Me.Label003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Label003.LengthAsByte = True
        Me.Label003.Location = New System.Drawing.Point(144, 136)
        Me.Label003.MaxLength = 50
        Me.Label003.Name = "Label003"
        Me.Label003.ReadOnly = True
        Me.Label003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label003.Size = New System.Drawing.Size(392, 32)
        Me.Label003.TabIndex = 1887
        Me.Label003.TabStop = False
        Me.Label003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label004
        '
        Me.Label004.AllowSpace = False
        Me.Label004.BackColor = System.Drawing.SystemColors.Control
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label004.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label004.HighlightText = True
        Me.Label004.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Label004.LengthAsByte = True
        Me.Label004.Location = New System.Drawing.Point(144, 172)
        Me.Label004.MaxLength = 50
        Me.Label004.Name = "Label004"
        Me.Label004.ReadOnly = True
        Me.Label004.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label004.Size = New System.Drawing.Size(392, 32)
        Me.Label004.TabIndex = 1888
        Me.Label004.TabStop = False
        Me.Label004.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label005
        '
        Me.Label005.AllowSpace = False
        Me.Label005.BackColor = System.Drawing.SystemColors.Control
        Me.Label005.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label005.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label005.HighlightText = True
        Me.Label005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Label005.LengthAsByte = True
        Me.Label005.Location = New System.Drawing.Point(144, 208)
        Me.Label005.MaxLength = 50
        Me.Label005.Name = "Label005"
        Me.Label005.ReadOnly = True
        Me.Label005.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label005.Size = New System.Drawing.Size(392, 32)
        Me.Label005.TabIndex = 1889
        Me.Label005.TabStop = False
        Me.Label005.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label006
        '
        Me.Label006.AllowSpace = False
        Me.Label006.BackColor = System.Drawing.SystemColors.Control
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label006.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label006.HighlightText = True
        Me.Label006.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Label006.LengthAsByte = True
        Me.Label006.Location = New System.Drawing.Point(144, 244)
        Me.Label006.MaxLength = 50
        Me.Label006.Name = "Label006"
        Me.Label006.ReadOnly = True
        Me.Label006.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label006.Size = New System.Drawing.Size(392, 32)
        Me.Label006.TabIndex = 1890
        Me.Label006.TabStop = False
        Me.Label006.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label007
        '
        Me.Label007.AllowSpace = False
        Me.Label007.BackColor = System.Drawing.SystemColors.Control
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Label007.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label007.HighlightText = True
        Me.Label007.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Label007.LengthAsByte = True
        Me.Label007.Location = New System.Drawing.Point(144, 280)
        Me.Label007.MaxLength = 50
        Me.Label007.Name = "Label007"
        Me.Label007.ReadOnly = True
        Me.Label007.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Label007.Size = New System.Drawing.Size(392, 32)
        Me.Label007.TabIndex = 0
        Me.Label007.TabStop = False
        Me.Label007.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(252, 320)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(280, 24)
        Me.Label9.TabIndex = 1891
        Me.Label9.Text = "Label9"
        Me.Label9.Visible = False
        '
        'F01_Form14_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(558, 459)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label007)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Label003)
        Me.Controls.Add(Me.Label002)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label0)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Edit001)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form14_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "出荷処理"
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label007, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F01_Form14_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()   '**  初期処理
        dsp_set() '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub dsp_set()
        Label001.Text = P_F01_PRAM1

        DsList1.Clear()
        strSQL = "SELECT T01_REP_MTR.user_name, M05_VNDR.name AS vndr_name, T01_REP_MTR.model_1, T01_REP_MTR.s_n, M06_RPAR_COMP.name AS rpar_comp_name, QA02_data.daibiki, T01_REP_MTR.comp_comn"
        strSQL += " FROM T01_REP_MTR INNER JOIN"
        strSQL += " M05_VNDR ON T01_REP_MTR.vndr_code = M05_VNDR.vndr_code INNER JOIN"
        strSQL += " M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code INNER JOIN"
        strSQL += " QA02_data ON T01_REP_MTR.rcpt_no = QA02_data.gss_rcpt_no"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & Label001.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
        If Not IsDBNull(DtView1(0)("user_name")) Then Label002.Text = DtView1(0)("user_name") Else Label002.Text = Nothing
        If Not IsDBNull(DtView1(0)("vndr_name")) Then Label003.Text = DtView1(0)("vndr_name") Else Label003.Text = Nothing
        If Not IsDBNull(DtView1(0)("model_1")) Then Label004.Text = DtView1(0)("model_1") Else Label004.Text = Nothing
        If Not IsDBNull(DtView1(0)("s_n")) Then Label005.Text = DtView1(0)("s_n") Else Label005.Text = Nothing
        If Not IsDBNull(DtView1(0)("rpar_comp_name")) Then Label006.Text = DtView1(0)("rpar_comp_name") Else Label006.Text = Nothing
        If Not IsDBNull(DtView1(0)("daibiki")) Then Label007.Text = Format(DtView1(0)("daibiki"), "##,##0") Else Label007.Text = "0"
        If Not IsDBNull(DtView1(0)("comp_comn")) Then Label9.Text = Trim(DtView1(0)("comp_comn")) Else Label9.Text = Nothing

    End Sub

    Sub F_chk()
        msg.Text = Nothing
        Date001.BackColor = System.Drawing.SystemColors.Window
        Edit001.BackColor = System.Drawing.SystemColors.Window
        ERR_F = "0"

        '出荷日
        If Date001.Number = 0 Then
            Date001.BackColor = System.Drawing.Color.Red
            msg.Text = "出荷日が入力されていません。"
            ERR_F = "1"
            Exit Sub
        Else
            If Date001.Text > Now.Date Then
                Date001.BackColor = System.Drawing.Color.Red
                msg.Text = "未来日付は入力できません。"
                ERR_F = "1"
                Exit Sub
            End If
        End If

        '配送伝票番号
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "配送伝票番号が入力されていません。"
            ERR_F = "1"
            Exit Sub
        End If
    End Sub

    '********************************************************************
    '**  登録ボタン
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        F_chk()
        If ERR_F = "0" Then
            DB_OPEN("nMVAR")

            WK_DsList1.Clear()
            strSQL = "SELECT V_cls_052.cls_code_name AS stts_name"
            strSQL += " FROM QA02_data INNER JOIN"
            strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
            strSQL += " WHERE (QA02_data.gss_rcpt_no = N'" & Label001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(WK_DsList1, "QA02_data")
            DtView1 = New DataView(WK_DsList1.Tables("QA02_data"), "", "", DataViewRowState.CurrentRows)

            Dim bfr_tsst_name As String = DtView1(0)("stts_name")

            strSQL = "SELECT cls_code_name AS stts_name FROM V_cls_052 WHERE (cls_code = '110')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(WK_DsList1, "V_cls_052")
            DtView1 = New DataView(WK_DsList1.Tables("V_cls_052"), "", "", DataViewRowState.CurrentRows)
            Dim afr_tsst_name As String = DtView1(0)("stts_name")

            strSQL = "UPDATE QA02_data"
            strSQL += " SET stts = N'110'"
            strSQL += ", haso_date = N'" & Format(CDate(Date001.Text), "yyyyMMdd") & "'"
            strSQL += ", haiso_den_no = N'" & Edit001.Text & "'"
            strSQL += ", snd_flg = 1"
            strSQL += " WHERE (gss_rcpt_no = N'" & Label001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            '出荷情報反映
            If Label9.Text <> Nothing Then
                Label9.Text += vbCrLf
            End If
            Label9.Text += "伝票No:" & Edit001.Text
            Label9.Text += vbCrLf
            Label9.Text += "代引額:￥" & Label007.Text & "（税込）"

            strSQL = "UPDATE T01_REP_MTR"
            strSQL += " SET comp_comn = '" & Label9.Text & "'"
            strSQL += ", ship_date = CONVERT(DATETIME, '" & Date001.Text & " " & Format(Now, "HH:mm:ss") & "', 102)"
            strSQL += " WHERE (rcpt_no = '" & Label001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            P_HSTY_DATE = Now
            afr_tsst_name += "（伝票No:" & Edit001.Text & " 代引額:￥" & Label007.Text & "（税込））"
            add_hsty(Label001.Text, "QACステータス", bfr_tsst_name, afr_tsst_name)

            Call QA_started_flg_ON(Label001.Text)    'Q&A 着手済フラグ更新

            P_RTN = "1"
            Me.Close()
        End If
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        P_RTN = "0"
        Me.Close()
    End Sub

    '********************************************************************
    '**  ファンクションキー
    '********************************************************************
    Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

        e.Handled = True        'ファンクションキーに割り付けられた設定を無効にします。
        Select Case e.KeyIndex  'ファンクションキーが押下された場合の処理を行います。
            Case 0  'F1
            Case 1  'F2
            Case 2  'F3
            Case 3  'F4
            Case 4  'F5
            Case 5  'F6
            Case 6  'F7
            Case 7  'F8
            Case 8  'F9
            Case 9  'F10
            Case 10 'F11
            Case 11 'F12
                f12_Click(sender, e)
        End Select
    End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub Date001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.GotFocus
        Date001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Date001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.LostFocus
        Date001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
