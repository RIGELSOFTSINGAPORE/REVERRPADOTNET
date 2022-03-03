Imports GrapeCity.Win.Input

Public Class F50_Form01_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, chg_itm As Integer
    Dim M_CLS As String = "M01"
    Dim M_CLS2 As String = "M02"

    '認定
    Private chkBox(99, 1) As CheckBox
    Private label(99, 3) As label
    Private edit(99, 2) As GrapeCity.Win.Input.Edit
    Dim en, Line_No As Integer

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.Furigana = Me.Edit002.Ime

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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Edit
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label000 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CheckBox002 As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Edit002 = New GrapeCity.Win.Input.Edit
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button80 = New System.Windows.Forms.Button
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.Label000 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CL001 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL003 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CheckBox002 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(724, 320)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 10
        Me.Button98.Text = "戻る"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(24, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 24)
        Me.Label6.TabIndex = 1135
        Me.Label6.Text = "名前"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(24, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 24)
        Me.Label11.TabIndex = 1133
        Me.Label11.Text = "ﾛｸﾞｲﾝID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(120, 40)
        Me.Edit001.MaxLength = 20
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(248, 24)
        Me.Edit001.TabIndex = 0
        Me.Edit001.Text = "Edit001"
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Edit002
        '
        Me.Edit002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(120, 80)
        Me.Edit002.MaxLength = 20
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(248, 24)
        Me.Edit002.TabIndex = 1
        Me.Edit002.Text = "Edit002"
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(24, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 1132
        Me.Label3.Text = "職位"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox001
        '
        Me.CheckBox001.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(120, 240)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 6
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(696, 8)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1131
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(24, 240)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 1130
        Me.Label52.Text = "削除フラグ"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(608, 8)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1129
        Me.Label51.Text = "登録日"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1127
        Me.Label1.Text = "会社/部署"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 24)
        Me.Label2.TabIndex = 1126
        Me.Label2.Text = "役割"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(24, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 24)
        Me.Label9.TabIndex = 1142
        Me.Label9.Text = "カナ"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit003
        '
        Me.Edit003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.Format = "KA#a"
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(120, 112)
        Me.Edit003.MaxLength = 20
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(248, 24)
        Me.Edit003.TabIndex = 2
        Me.Edit003.Text = "Edit003"
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 320)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "更新"
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(644, 320)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 32)
        Me.Button80.TabIndex = 9
        Me.Button80.Text = "履歴"
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        Me.Combo002.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo002.Location = New System.Drawing.Point(120, 176)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(248, 24)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 4
        Me.Combo002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo002.Value = "Combo2"
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(120, 144)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(248, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 3
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo1"
        '
        'Combo003
        '
        Me.Combo003.AutoSelect = True
        Me.Combo003.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo003.Location = New System.Drawing.Point(120, 208)
        Me.Combo003.MaxDropDownItems = 20
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(248, 24)
        Me.Combo003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo003.TabIndex = 5
        Me.Combo003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo003.Value = "Combo3"
        '
        'Label000
        '
        Me.Label000.Location = New System.Drawing.Point(28, 12)
        Me.Label000.Name = "Label000"
        Me.Label000.Size = New System.Drawing.Size(80, 24)
        Me.Label000.TabIndex = 1143
        Me.Label000.Text = "Label000"
        Me.Label000.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(532, 12)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1146
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(560, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1145
        Me.CheckBox1.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(372, 144)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(40, 24)
        Me.CL001.TabIndex = 1147
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(372, 176)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(40, 24)
        Me.CL002.TabIndex = 1148
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(372, 208)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(40, 24)
        Me.CL003.TabIndex = 1149
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(24, 288)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(776, 24)
        Me.msg.TabIndex = 1150
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(424, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 212)
        Me.Panel1.TabIndex = 7
        Me.Panel1.TabStop = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(424, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 24)
        Me.Label4.TabIndex = 1151
        Me.Label4.Text = "認定"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(476, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 24)
        Me.Label5.TabIndex = 1152
        Me.Label5.Text = "メーカー"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(676, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 24)
        Me.Label7.TabIndex = 1153
        Me.Label7.Text = "認定番号"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox002
        '
        Me.CheckBox002.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox002.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox002.Location = New System.Drawing.Point(316, 240)
        Me.CheckBox002.Name = "CheckBox002"
        Me.CheckBox002.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox002.TabIndex = 1154
        Me.CheckBox002.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(192, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 24)
        Me.Label8.TabIndex = 1155
        Me.Label8.Text = "system管理者"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F50_Form01_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(862, 364)
        Me.Controls.Add(Me.CheckBox002)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.CL003)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label000)
        Me.Controls.Add(Me.Combo003)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form01_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "社員マスタ"
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F05_Form01_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='501'", "", DataViewRowState.CurrentRows)
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

        '部署
        strSQL = "SELECT M03_BRCH.brch_code"
        strSQL +=  ", M03_BRCH.brch_code + ':' + cls002.cls_code_name_abbr + '/' + M03_BRCH.name AS name, M03_BRCH.comp_code"
        strSQL +=  " FROM M03_BRCH INNER JOIN"
        strSQL +=  " (SELECT cls_code, cls_code_name_abbr FROM M21_CLS_CODE WHERE (cls_no = '002')) cls002 ON"
        strSQL +=  " M03_BRCH.comp_code = cls002.cls_code COLLATE Japanese_CI_AS"
        strSQL +=  " WHERE (M03_BRCH.delt_flg = 0)"
        strSQL +=  " ORDER BY cls002.cls_code_name_abbr, M03_BRCH.name_kana"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M03_BRCH")

        Combo001.DataSource = DsCMB.Tables("M03_BRCH")
        Combo001.DisplayMember = "name"
        Combo001.ValueMember = "brch_code"

        '職位
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '004') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_004")

        Combo002.DataSource = DsCMB.Tables("CLS_CODE_004")
        Combo002.DisplayMember = "cls_code_name"
        Combo002.ValueMember = "cls_code"

        '役割
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '005') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_005")

        Combo003.DataSource = DsCMB.Tables("CLS_CODE_005")
        Combo003.DisplayMember = "cls_code_name"
        Combo003.ValueMember = "cls_code"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        If P_PRAM1 = Nothing Then   '新規
            Button1.Text = "登録"
            Button80.Enabled = False
            Label000.Text = Nothing
            Edit001.Text = Nothing
            Edit002.Text = Nothing
            Edit003.Text = Nothing

            Combo001.Text = Nothing
            Combo002.Text = Nothing
            Combo003.Text = Nothing

            CheckBox001.Checked = False
            CheckBox002.Checked = False
            Label001.Text = Nothing

        Else                        '修正
            Button1.Text = "更新"
            Button80.Enabled = True
            DsList1.Clear()

            '社員マスタ
            SqlCmd1 = New SqlClient.SqlCommand("sp_M01_EMPL_2", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 4)
            Pram1.Value = P_PRAM1
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "M01_EMPL")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)

            Label000.Text = DtView1(0)("empl_code")
            Edit001.Text = DtView1(0)("login_id")
            Edit002.Text = DtView1(0)("name")
            Edit003.Text = DtView1(0)("name_kana")

            Combo001.Text = DtView1(0)("brch_code") & ":" & DtView1(0)("comp_name") & "/" & DtView1(0)("brch_name")
            Combo002.Text = DtView1(0)("post_code") & ":" & DtView1(0)("post_name")
            Combo003.Text = DtView1(0)("role_code") & ":" & DtView1(0)("role_name")

            If DtView1(0)("delt_flg") = "1" Then
                CheckBox001.Checked = True
            Else
                CheckBox001.Checked = False
            End If
            If IsDBNull(DtView1(0)("admin_flg")) Then
                CheckBox002.Checked = False
            Else
                If DtView1(0)("admin_flg") = "1" Then
                    CheckBox002.Checked = True
                Else
                    CheckBox002.Checked = False
                End If
            End If
            Label001.Text = DtView1(0)("reg_date")
        End If

        '資格認定
        If P_PRAM1 = Nothing Then   '新規
            strSQL = "SELECT vndr_code, name, NULL AS delt_flg, delt_flg AS atri_F, '' AS atri_code"
            strSQL +=  " FROM M05_VNDR"
            strSQL +=  " WHERE (atri_flg = 1)"
            strSQL +=  " ORDER BY name_kana"
        Else
            strSQL = "SELECT M05_VNDR.vndr_code, M05_VNDR.name, empl.delt_flg, M05_VNDR.delt_flg AS atri_F, empl.atri_code"
            strSQL +=  " FROM M05_VNDR LEFT OUTER JOIN"
            strSQL +=  " (SELECT * FROM M02_ATRI WHERE (empl_code = " & P_PRAM1 & ")) empl ON"
            strSQL +=  " M05_VNDR.vndr_code = empl.vndr_code COLLATE Japanese_CI_AS"
            strSQL +=  " WHERE (M05_VNDR.atri_flg = 1)"
            strSQL +=  " ORDER BY M05_VNDR.name_kana"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M02_ATRI")
        DB_CLOSE()

        DtView2 = New DataView(DsList1.Tables("M02_ATRI"), "", "", DataViewRowState.CurrentRows)
        If DtView2.Count <> 0 Then
            For i = 0 To DtView2.Count - 1
                If IsDBNull(DtView2(i)("delt_flg")) Then
                    DtView2(i)("atri_F") = "False"
                Else
                    If DtView2(i)("delt_flg") = "0" Then
                        DtView2(i)("atri_F") = "True"
                    Else
                        DtView2(i)("atri_F") = "False"
                    End If
                End If
            Next
        End If

        DtView1 = New DataView(DsList1.Tables("M02_ATRI"), "", "", DataViewRowState.CurrentRows)
        Line_No = 0
        Panel1.Controls.Clear()

        '基準点
        en = 0
        label(Line_No, en) = New Label
        label(Line_No, en).Location = New System.Drawing.Point(0, 0)
        label(Line_No, en).Size = New System.Drawing.Size(0, 0)
        label(Line_No, en).Text = Nothing
        Panel1.Controls.Add(label(Line_No, en))

        If DtView1.Count <> 0 Then
            For Line_No = 0 To DtView1.Count - 1

                '対象
                en = 1
                chkBox(Line_No, en) = New CheckBox
                chkBox(Line_No, en).Location = New System.Drawing.Point(0, 24 * Line_No + label(0, 0).Location.Y)
                chkBox(Line_No, en).Size = New System.Drawing.Size(50, 24)
                chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
                chkBox(Line_No, en).Checked = DtView1(Line_No)("atri_F")
                chkBox(Line_No, en).Tag = Line_No
                Panel1.Controls.Add(chkBox(Line_No, en))
                AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
                AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

                'メーカー
                en = 1
                label(Line_No, en) = New Label
                label(Line_No, en).BorderStyle = BorderStyle.Fixed3D
                label(Line_No, en).Location = New System.Drawing.Point(50, 24 * Line_No + label(0, 0).Location.Y)
                label(Line_No, en).Size = New System.Drawing.Size(200, 24)
                label(Line_No, en).TextAlign = ContentAlignment.MiddleLeft
                label(Line_No, en).Text = DtView1(Line_No)("name")
                Panel1.Controls.Add(label(Line_No, en))

                '認定コード
                en = 1
                edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                edit(Line_No, en).Location = New System.Drawing.Point(250, 24 * Line_No + label(0, 0).Location.Y)
                edit(Line_No, en).Size = New System.Drawing.Size(148, 24)
                edit(Line_No, en).TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
                edit(Line_No, en).LengthAsByte = True
                edit(Line_No, en).MaxLength = 15
                edit(Line_No, en).Enabled = True
                If Not IsDBNull(DtView1(Line_No)("atri_code")) Then
                    edit(Line_No, en).Text = DtView1(Line_No)("atri_code")
                Else
                    edit(Line_No, en).Text = Nothing
                End If
                edit(Line_No, en).Tag = Line_No
                Panel1.Controls.Add(edit(Line_No, en))
                AddHandler edit(Line_No, en).GotFocus, AddressOf edit1_GotFocus
                AddHandler edit(Line_No, en).LostFocus, AddressOf edit1_LostFocus

                '削除
                en = 2
                label(Line_No, en) = New Label
                label(Line_No, en).Location = New System.Drawing.Point(350, 24 * Line_No + label(0, 0).Location.Y)
                label(Line_No, en).Size = New System.Drawing.Size(50, 24)
                If Not IsDBNull(DtView1(Line_No)("delt_flg")) Then
                    label(Line_No, en).Text = DtView1(Line_No)("delt_flg")
                Else
                    label(Line_No, en).Text = Nothing
                End If
                label(Line_No, en).Visible = False
                Panel1.Controls.Add(label(Line_No, en))

                'メーカーコード
                en = 3
                label(Line_No, en) = New Label
                label(Line_No, en).Location = New System.Drawing.Point(400, 24 * Line_No + label(0, 0).Location.Y)
                label(Line_No, en).Size = New System.Drawing.Size(30, 24)
                label(Line_No, en).Text = DtView1(Line_No)("vndr_code")
                label(Line_No, en).Visible = False
                Panel1.Controls.Add(label(Line_No, en))

                '元認定コード
                en = 2
                edit(Line_No, en) = New GrapeCity.Win.Input.Edit
                edit(Line_No, en).Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
                edit(Line_No, en).Location = New System.Drawing.Point(430, 24 * Line_No + label(0, 0).Location.Y)
                edit(Line_No, en).Size = New System.Drawing.Size(100, 24)
                edit(Line_No, en).Enabled = False
                If Not IsDBNull(DtView1(Line_No)("atri_code")) Then
                    edit(Line_No, en).Text = DtView1(Line_No)("atri_code")
                Else
                    edit(Line_No, en).Text = Nothing
                End If
                edit(Line_No, en).Visible = False
                Panel1.Controls.Add(edit(Line_No, en))

            Next
            Line_No = Line_No - 1
        End If
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Edit001()   'ログインＩＤ
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "ログインＩＤが入力されていません。"
            Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT empl_code, login_id"
            strSQL +=  " FROM M01_EMPL"
            strSQL +=  " WHERE (login_id = '" & Edit001.Text & "')"
            If P_PRAM1 <> Nothing Then strSQL +=  " AND (empl_code <> " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(WK_DsList1, "M01_EMPL")
            DB_CLOSE()

            WK_DtView1 = New DataView(WK_DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "ログインＩＤが既に登録されています。"
                Exit Sub
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit002()   '名前
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "名前が入力されていません。"
            Exit Sub
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit003()   'カナ
        msg.Text = Nothing

        Edit003.Text = Trim(Edit003.Text)
        If Edit003.Text = Nothing Then
            Edit003.BackColor = System.Drawing.Color.Red
            msg.Text = "カナが入力されていません。"
            Exit Sub
        End If
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Combo001()   '部署
        msg.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            Combo001.BackColor = System.Drawing.Color.Red
            msg.Text = "部署が入力されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "name ='" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する部署がありません。"
                Exit Sub
            Else
                CL001.Text = WK_DtView1(0)("brch_code")
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Combo002()   '職位
        msg.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            Combo002.BackColor = System.Drawing.Color.Red
            msg.Text = "職位が入力されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("CLS_CODE_004"), "cls_code_name ='" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する職位がありません。"
                Exit Sub
            Else
                CL002.Text = WK_DtView1(0)("cls_code")
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Combo003()   '役割
        msg.Text = Nothing

        Combo003.Text = Trim(Combo003.Text)
        If Combo003.Text = Nothing Then
            Combo003.BackColor = System.Drawing.Color.Red
            msg.Text = "役割が入力されていません。"
            Exit Sub
        Else
            WK_DtView1 = New DataView(DsCMB.Tables("CLS_CODE_005"), "cls_code_name ='" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Combo003.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する役割がありません。"
                Exit Sub
            Else
                CL003.Text = WK_DtView1(0)("cls_code")
            End If
        End If
        Combo003.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        CHK_Edit001() 'ログインＩＤ
        If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub

        CHK_Edit002() '名前
        If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub

        CHK_Edit003() 'カナ
        If msg.Text <> Nothing Then Err_F = "1" : Edit003.Focus() : Exit Sub

        CHK_Combo001() '部署
        If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Combo002() '職位
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Combo003() '役割
        If msg.Text <> Nothing Then Err_F = "1" : Combo003.Focus() : Exit Sub
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.GotFocus
        Edit002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.GotFocus
        CheckBox002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Edit)
        edit(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   'ログインＩＤ
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        CHK_Edit002()   '名前
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        CHK_Edit003()   'カナ
    End Sub
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   '部署
    End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()   '職位
    End Sub
    Private Sub Combo003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.LostFocus
        CHK_Combo003()   '役割
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        CheckBox001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.LostFocus
        CheckBox002.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CHK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub edit1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Edit)
        edit(Lin.Tag, 1).Text = Trim(edit(Lin.Tag, 1).Text)
        edit(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  ふりがな自動取得
    '********************************************************************
    Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.ResultStringEventArgs) Handles Furigana.ResultString
        ' 取得したふりがなを表示します。
        Edit003.Text += e.ReadString
    End Sub

    '********************************************************************
    '**  変更履歴
    '********************************************************************
    Sub CHG_HSTY()
        DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)

        If Edit001.Text <> DtView1(0)("login_id") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "ﾛｸﾞｲﾝID", DtView1(0)("login_id"), Edit001.Text)
        End If

        If Edit002.Text <> DtView1(0)("name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "名前", DtView1(0)("name"), Edit002.Text)
        End If

        If Edit003.Text <> DtView1(0)("name_kana") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "カナ", DtView1(0)("name_kana"), Edit003.Text)
        End If

        If Combo001.Text <> DtView1(0)("brch_code") & ":" & DtView1(0)("comp_name") & "/" & DtView1(0)("brch_name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "部署", DtView1(0)("brch_code") & ":" & DtView1(0)("comp_name") & "/" & DtView1(0)("brch_name"), Combo001.Text)
        End If

        If Combo002.Text <> DtView1(0)("post_code") & ":" & DtView1(0)("post_name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "職位", DtView1(0)("post_code") & ":" & DtView1(0)("post_name"), Combo002.Text)
        End If

        If Combo003.Text <> DtView1(0)("role_code") & ":" & DtView1(0)("role_name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "役割", DtView1(0)("role_code") & ":" & DtView1(0)("role_name"), Combo003.Text)
        End If

        If DtView1(0)("delt_flg") = "1" Then
            If CheckBox001.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "削除フラグ", "削除", "")
            End If
        Else
            If CheckBox001.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "削除フラグ", "", "削除")
            End If
        End If

        If IsDBNull(DtView1(0)("admin_flg")) Then DtView1(0)("admin_flg") = "False"
        If DtView1(0)("admin_flg") = "1" Then
            If CheckBox002.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "system管理者", "対象", "")
            End If
        Else
            If CheckBox002.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Label000.Text, "system管理者", "", "対象")
            End If
        End If
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        chg_itm = 0
        P_HSTY_DATE = Now
        F_Check()   '**  項目チェック
        If Err_F = "0" Then
            If P_PRAM1 = Nothing Then   '新規
                Label001.Text = Now.Date

                WK_DsList1.Clear()
                strSQL = "SELECT MAX(empl_code) AS [max] FROM M01_EMPL"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "M01_EMPL")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
                If Not IsDBNull(WK_DtView1(0)("max")) Then
                    Label000.Text = WK_DtView1(0)("max") + 1
                Else
                    Label000.Text = "1"
                End If

                '社員マスタ
                strSQL = "INSERT INTO M01_EMPL"
                strSQL +=  " (empl_code, login_id, name, name_kana, brch_code, post_code, role_code, admin_flg, reg_date, delt_flg)"
                strSQL +=  " VALUES (" & Label000.Text
                strSQL +=  ", '" & Edit001.Text & "'"
                strSQL +=  ", '" & Edit002.Text & "'"
                strSQL +=  ", '" & Edit003.Text & "'"
                strSQL +=  ", '" & CL001.Text & "'"
                strSQL +=  ", '" & CL002.Text & "'"
                strSQL +=  ", '" & CL003.Text & "'"
                If CheckBox002.Checked = True Then strSQL +=  ", 1" Else strSQL +=  ", 0"
                strSQL +=  ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ")"
                DB_OPEN("nMVAR")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                '資格認定マスタ
                For i = 0 To Line_No
                    If chkBox(i, 1).Checked = True Then
                        strSQL = "INSERT INTO M02_ATRI"
                        strSQL += " (empl_code, vndr_code, atri_code, reg_date, delt_flg)"
                        strSQL += " VALUES (" & Label000.Text
                        strSQL += ", '" & label(i, 3).Text & "'"
                        strSQL += ", '" & edit(i, 1).Text & "'"
                        strSQL += ", '" & CDate(Label001.Text) & "'"
                        strSQL += ", 0"
                        strSQL += ")"
                        DB_OPEN("nMVAR")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If
                Next

                add_MTR_hsty(M_CLS, Label000.Text, "新規登録", "", "")
                msg.Text = "登録しました。"
                P_RTN = "1"
                P_PRAM1 = Label000.Text
                DspSet()    '**  画面セット
            Else                        '修正

                CHG_HSTY()  '**  変更履歴
                If chg_itm <> 0 Then
                    '社員マスタ
                    strSQL = "UPDATE M01_EMPL"
                    strSQL +=  " SET login_id = '" & Edit001.Text & "'"
                    strSQL +=  ", name = '" & Edit002.Text & "'"
                    strSQL +=  ", name_kana = '" & Edit003.Text & "'"
                    strSQL +=  ", brch_code = '" & CL001.Text & "'"
                    strSQL +=  ", post_code = '" & CL002.Text & "'"
                    strSQL +=  ", role_code = '" & CL003.Text & "'"
                    If CheckBox002.Checked = True Then strSQL +=  ", admin_flg = 1" Else strSQL +=  ", admin_flg = 0"
                    If CheckBox001.Checked = True Then strSQL +=  ", delt_flg = 1" Else strSQL +=  ", delt_flg = 0"
                    strSQL +=  " WHERE (empl_code = " & P_PRAM1 & ")"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If

                '資格認定マスタ
                For i = 0 To Line_No
                    If chkBox(i, 1).Checked = True Then    '対象
                        If label(i, 2).Text = Nothing Then
                            'ins
                            strSQL = "INSERT INTO M02_ATRI"
                            strSQL +=  " (empl_code, vndr_code, atri_code, reg_date, delt_flg)"
                            strSQL +=  " VALUES (" & Label000.Text
                            strSQL +=  ", '" & label(i, 3).Text & "'"
                            strSQL +=  ", '" & edit(i, 1).Text & "'"
                            strSQL +=  ", '" & CDate(Label001.Text) & "'"
                            strSQL += ", 0"
                            strSQL += ")"
                            DB_OPEN("nMVAR")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS2, Label000.Text, "認定：" & label(i, 1).Text, "対象外：", "対象：" & edit(i, 1).Text)
                        Else
                            If label(i, 2).Text = "True" Then
                                'upd
                                strSQL = "UPDATE M02_ATRI"
                                strSQL +=  " SET delt_flg = 0"
                                strSQL +=  ", atri_code = '" & edit(i, 1).Text & "'"
                                strSQL +=  " WHERE (empl_code = " & P_PRAM1 & ")"
                                strSQL +=  " AND (vndr_code = '" & label(i, 3).Text & "')"
                                DB_OPEN("nMVAR")
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS2, Label000.Text, "認定：" & label(i, 1).Text, "対象外：" & edit(i, 2).Text, "対象：" & edit(i, 1).Text)
                            Else
                                If edit(i, 2).Text <> edit(i, 1).Text Then
                                    'upd
                                    strSQL = "UPDATE M02_ATRI"
                                    strSQL +=  " SET atri_code = '" & edit(i, 1).Text & "'"
                                    strSQL +=  " WHERE (empl_code = " & P_PRAM1 & ")"
                                    strSQL +=  " AND (vndr_code = '" & label(i, 3).Text & "')"
                                    DB_OPEN("nMVAR")
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.CommandTimeout = 600
                                    SqlCmd1.ExecuteNonQuery()
                                    DB_CLOSE()

                                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS2, Label000.Text, "認定：" & label(i, 1).Text, "対象：" & edit(i, 2).Text, "対象：" & edit(i, 1).Text)
                                End If
                            End If
                        End If
                    Else
                        If label(i, 2).Text = "False" Then
                            'del
                            strSQL = "UPDATE M02_ATRI"
                            strSQL +=  " SET delt_flg = 1"
                            strSQL +=  ", atri_code = '" & edit(i, 1).Text & "'"
                            strSQL +=  " WHERE (empl_code = " & P_PRAM1 & ")"
                            strSQL +=  " AND (vndr_code = '" & label(i, 3).Text & "')"
                            DB_OPEN("nMVAR")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()

                            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS2, Label000.Text, "認定：" & label(i, 1).Text, "対象：" & edit(i, 2).Text, "対象外：" & edit(i, 1).Text)
                        End If
                    End If
                Next

                If chg_itm = 0 Then
                    msg.Text = "変更箇所がありません。"
                Else
                    msg.Text = "更新しました。"
                    DspSet()    '**  画面セット
                End If
                P_RTN = "1"
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  履歴
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '変更履歴
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L02_MTR_HSTY_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 3)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 20)
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p3", SqlDbType.Char, 3)
        Pram3.Value = M_CLS
        Pram4.Value = P_PRAM1
        Pram5.Value = M_CLS2
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
        DsCMB.Clear()
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
