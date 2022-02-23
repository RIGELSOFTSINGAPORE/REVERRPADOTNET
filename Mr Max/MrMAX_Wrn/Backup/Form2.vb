Public Class Form2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, MSG_DsList1 As New DataSet
    Dim Ds_search, Ds_Q As New DataSet
    Dim DtView1, DtView2, WK_DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F As String
    Dim i, en, line_no, line_no2, date_i As Integer
    Dim WK_Date As Date

    Private label(9999, 1) As label

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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit5 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit6 As GrapeCity.Win.Input.Edit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button95 As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComboBox10 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ComboBox11 As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ComboBox12 As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button95 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Edit3 = New GrapeCity.Win.Input.Edit
        Me.Edit4 = New GrapeCity.Win.Input.Edit
        Me.Edit5 = New GrapeCity.Win.Input.Edit
        Me.Edit6 = New GrapeCity.Win.Input.Edit
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.ComboBox7 = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.ComboBox8 = New System.Windows.Forms.ComboBox
        Me.ComboBox9 = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ComboBox10 = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.ComboBox11 = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.ComboBox12 = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.Edit2 = New GrapeCity.Win.Input.Edit
        Me.Label19 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(704, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 23)
        Me.Label9.TabIndex = 196
        Me.Label9.Text = "受付番号検索"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(760, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 22)
        Me.Label8.TabIndex = 195
        Me.Label8.Text = "label8"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'RadioButton2
        '
        Me.RadioButton2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(408, 80)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "対応中"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(288, 80)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "新規受付"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 22)
        Me.Label1.TabIndex = 185
        Me.Label1.Text = "Label1"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(288, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 184
        Me.Label6.Text = "保証番号"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(288, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 23)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "電話番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(288, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "氏名（漢字）"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(816, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 30)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "検  索"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button99.Location = New System.Drawing.Point(820, 508)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(96, 30)
        Me.Button99.TabIndex = 220
        Me.Button99.Text = "終　了"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(944, 30)
        Me.Label10.TabIndex = 197
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(716, 452)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 30)
        Me.Button3.TabIndex = 200
        Me.Button3.Text = "登　録"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(464, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(264, 28)
        Me.Label11.TabIndex = 198
        Me.Label11.Text = "MrMax 安心5年保証"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label12.Location = New System.Drawing.Point(256, 228)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(664, 3)
        Me.Label12.TabIndex = 199
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Location = New System.Drawing.Point(256, 496)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(664, 3)
        Me.Label13.TabIndex = 200
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(468, 240)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 28)
        Me.Label14.TabIndex = 205
        Me.Label14.Text = "その他の問合せ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton3
        '
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(8, 8)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(48, 24)
        Me.RadioButton3.TabIndex = 91
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "男"
        '
        'RadioButton4
        '
        Me.RadioButton4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(64, 8)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(40, 24)
        Me.RadioButton4.TabIndex = 92
        Me.RadioButton4.Text = "女"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton4)
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Location = New System.Drawing.Point(372, 304)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(152, 28)
        Me.Panel2.TabIndex = 90
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(260, 280)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 23)
        Me.Label18.TabIndex = 212
        Me.Label18.Text = "相手先"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(364, 280)
        Me.ComboBox1.MaxDropDownItems = 12
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox1.TabIndex = 80
        '
        'Button95
        '
        Me.Button95.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button95.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button95.Location = New System.Drawing.Point(716, 508)
        Me.Button95.Name = "Button95"
        Me.Button95.Size = New System.Drawing.Size(96, 30)
        Me.Button95.TabIndex = 210
        Me.Button95.Text = "クリア"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(288, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 23)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "氏名（ｶﾅ）"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.Format = "9"
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.Location = New System.Drawing.Point(392, 112)
        Me.Edit1.MaxLength = 20
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(192, 23)
        Me.Edit1.TabIndex = 30
        Me.Edit1.Text = "1"
        '
        'Edit3
        '
        Me.Edit3.HighlightText = True
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit3.Location = New System.Drawing.Point(392, 140)
        Me.Edit3.MaxLength = 30
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(192, 23)
        Me.Edit3.TabIndex = 50
        Me.Edit3.Text = "Edit3"
        '
        'Edit4
        '
        Me.Edit4.HighlightText = True
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit4.Location = New System.Drawing.Point(392, 168)
        Me.Edit4.MaxLength = 30
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit4.Size = New System.Drawing.Size(192, 23)
        Me.Edit4.TabIndex = 60
        Me.Edit4.Text = "Edit4"
        '
        'Edit5
        '
        Me.Edit5.Format = "9"
        Me.Edit5.HighlightText = True
        Me.Edit5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit5.Location = New System.Drawing.Point(392, 196)
        Me.Edit5.MaxLength = 20
        Me.Edit5.Name = "Edit5"
        Me.Edit5.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit5.Size = New System.Drawing.Size(192, 23)
        Me.Edit5.TabIndex = 65
        Me.Edit5.Text = "5"
        '
        'Edit6
        '
        Me.Edit6.Format = "9A"
        Me.Edit6.HighlightText = True
        Me.Edit6.Location = New System.Drawing.Point(808, 112)
        Me.Edit6.MaxLength = 10
        Me.Edit6.Name = "Edit6"
        Me.Edit6.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit6.Size = New System.Drawing.Size(104, 23)
        Me.Edit6.TabIndex = 50
        Me.Edit6.Text = "6"
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(364, 336)
        Me.ComboBox2.MaxDropDownItems = 12
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox2.TabIndex = 100
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(260, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 991
        Me.Label7.Text = "年齢層"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(260, 308)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 23)
        Me.Label15.TabIndex = 993
        Me.Label15.Text = "性　別"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(364, 364)
        Me.ComboBox3.MaxDropDownItems = 12
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox3.TabIndex = 110
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(260, 364)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 23)
        Me.Label16.TabIndex = 994
        Me.Label16.Text = "地　域"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(364, 392)
        Me.ComboBox4.MaxDropDownItems = 26
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(240, 23)
        Me.ComboBox4.TabIndex = 120
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(260, 392)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 23)
        Me.Label17.TabIndex = 996
        Me.Label17.Text = "商品ｶﾃｺﾞﾘｰ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox6
        '
        Me.ComboBox6.Location = New System.Drawing.Point(364, 420)
        Me.ComboBox6.MaxDropDownItems = 26
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(240, 23)
        Me.ComboBox6.TabIndex = 140
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(260, 420)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 23)
        Me.Label20.TabIndex = 1000
        Me.Label20.Text = "購入店舗"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox7
        '
        Me.ComboBox7.Location = New System.Drawing.Point(664, 280)
        Me.ComboBox7.MaxDropDownItems = 12
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(64, 23)
        Me.ComboBox7.TabIndex = 150
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(560, 280)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 23)
        Me.Label21.TabIndex = 1002
        Me.Label21.Text = "購入後　年"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox8
        '
        Me.ComboBox8.Location = New System.Drawing.Point(840, 280)
        Me.ComboBox8.MaxDropDownItems = 12
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(64, 23)
        Me.ComboBox8.TabIndex = 160
        '
        'ComboBox9
        '
        Me.ComboBox9.Location = New System.Drawing.Point(744, 336)
        Me.ComboBox9.MaxDropDownItems = 12
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(192, 23)
        Me.ComboBox9.TabIndex = 170
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(640, 336)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 23)
        Me.Label23.TabIndex = 1006
        Me.Label23.Text = "不具合系"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox10
        '
        Me.ComboBox10.Location = New System.Drawing.Point(744, 364)
        Me.ComboBox10.MaxDropDownItems = 12
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(192, 23)
        Me.ComboBox10.TabIndex = 180
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(640, 364)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 23)
        Me.Label22.TabIndex = 1008
        Me.Label22.Text = "意見・要望系"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(736, 280)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 23)
        Me.Label24.TabIndex = 1010
        Me.Label24.Text = "　　　　　 月"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox11
        '
        Me.ComboBox11.Location = New System.Drawing.Point(712, 392)
        Me.ComboBox11.MaxDropDownItems = 12
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(224, 23)
        Me.ComboBox11.TabIndex = 190
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(608, 392)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 23)
        Me.Label25.TabIndex = 1011
        Me.Label25.Text = "対応結果１"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(608, 308)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(136, 23)
        Me.Label26.TabIndex = 1013
        Me.Label26.Text = "コール内容"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox12
        '
        Me.ComboBox12.Location = New System.Drawing.Point(712, 420)
        Me.ComboBox12.MaxDropDownItems = 12
        Me.ComboBox12.Name = "ComboBox12"
        Me.ComboBox12.Size = New System.Drawing.Size(224, 23)
        Me.ComboBox12.TabIndex = 195
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(608, 420)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(104, 23)
        Me.Label27.TabIndex = 1015
        Me.Label27.Text = "対応結果２"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.ForeColor = System.Drawing.Color.Red
        Me.Panel3.Location = New System.Drawing.Point(4, 504)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(701, 36)
        Me.Panel3.TabIndex = 1017
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 468)
        Me.Panel1.TabIndex = 1018
        '
        'RadioButton5
        '
        Me.RadioButton5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton5.Location = New System.Drawing.Point(528, 80)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.TabIndex = 1019
        Me.RadioButton5.Text = "完了分"
        '
        'Edit2
        '
        Me.Edit2.HighlightText = True
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit2.LengthAsByte = True
        Me.Edit2.Location = New System.Drawing.Point(364, 448)
        Me.Edit2.MaxLength = 1000
        Me.Edit2.Multiline = True
        Me.Edit2.Name = "Edit2"
        Me.Edit2.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(340, 44)
        Me.Edit2.TabIndex = 145
        Me.Edit2.Text = "Edit2"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(260, 448)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 44)
        Me.Label19.TabIndex = 1023
        Me.Label19.Text = "問合せ内容"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(820, 452)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 30)
        Me.Button2.TabIndex = 1024
        Me.Button2.Text = "検　索"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(760, 184)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(152, 30)
        Me.Button4.TabIndex = 1025
        Me.Button4.Text = "修理受付№検索"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(938, 547)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ComboBox12)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.ComboBox11)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.ComboBox10)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ComboBox9)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit6)
        Me.Controls.Add(Me.Edit5)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button95)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label10)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MrMax 安心5年保証"
        Me.Panel2.ResumeLayout(False)
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
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

        Label1.Text = "受付担当者: " & pName
        Label8.Text = Format(Now(), "yyyy年MM月dd日")

        Call CmbSet_int()
        Call CmbSet()
        Call Panel_Set()
        Call dsp_clear()
    End Sub

    Sub CmbSet_int()
        DB_OPEN()
        P_DsCMB.Clear()

        '受付店舗
        strSQL = "SELECT SHOP_CODE, SHOP_CODE + ' : ' + SHOP_NAME AS SHOP_NAME"
        strSQL = strSQL & " FROM SHOP"
        strSQL = strSQL & " WHERE delt_flg = 0"
        strSQL = strSQL & " ORDER BY SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "SHOP")
        DaList1.Fill(P_DsCMB, "SHOP2")

        '部門
        strSQL = "SELECT CAT_CODE, CAT_CODE + ' : ' + RTRIM(CAT_NAME) AS CAT_NAME"
        strSQL = strSQL & " FROM M_category"
        strSQL = strSQL & " ORDER BY CAT_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "M_category")
        DaList1.Fill(P_DsCMB, "M_category2")

        'ステイタス
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '001' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "STS_CLS")

        '修理依頼先
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '002' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CLS_002")

        '相手先属性
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '003' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CUST_CLS")

        '問合せ区分
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '004' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "ICDT_CLS")

        '回答区分
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '005' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "STS_RPLY")

        '年齢層
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '014' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "AGE_CLS")

        '地域
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '015' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "AREA_CLS")

        '年
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '016' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "YEAR_CLS")

        '月
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '017' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "MONTHS_CLS")

        '不具合
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '018' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CALL1_CLS")

        '意見
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '019' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "CALL2_CLS")

        '結果１
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '020' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "RPLY_CLS1")

        '結果２
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME"
        strSQL = strSQL & " FROM CLS_CODE"
        strSQL = strSQL & " WHERE CLS_NO = '021' AND delt_flg = 0"
        strSQL = strSQL & " ORDER BY DSP_SEQ, CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsCMB, "RPLY_CLS2")

        DB_CLOSE()
    End Sub

    Sub CmbSet()

        '相手先属性
        ComboBox1.DataSource = P_DsCMB.Tables("CUST_CLS")
        ComboBox1.DisplayMember = "NAME"
        ComboBox1.ValueMember = "CLS_CODE"
        ComboBox1.Text = Nothing

        '年齢層
        ComboBox2.DataSource = P_DsCMB.Tables("AGE_CLS")
        ComboBox2.DisplayMember = "NAME"
        ComboBox2.ValueMember = "CLS_CODE"
        ComboBox2.Text = Nothing

        '地域
        ComboBox3.DataSource = P_DsCMB.Tables("AREA_CLS")
        ComboBox3.DisplayMember = "NAME"
        ComboBox3.ValueMember = "CLS_CODE"
        ComboBox3.Text = Nothing

        '部門
        ComboBox4.DataSource = P_DsCMB.Tables("M_category2")
        ComboBox4.DisplayMember = "CAT_NAME"
        ComboBox4.ValueMember = "CAT_CODE"
        ComboBox4.Text = Nothing

        '店舗
        ComboBox6.DataSource = P_DsCMB.Tables("SHOP2")
        ComboBox6.DisplayMember = "SHOP_NAME"
        ComboBox6.ValueMember = "SHOP_CODE"
        ComboBox6.Text = Nothing

        '年
        ComboBox7.DataSource = P_DsCMB.Tables("YEAR_CLS")
        ComboBox7.DisplayMember = "NAME"
        ComboBox7.ValueMember = "CLS_CODE"
        ComboBox7.Text = Nothing

        '月
        ComboBox8.DataSource = P_DsCMB.Tables("MONTHS_CLS")
        ComboBox8.DisplayMember = "NAME"
        ComboBox8.ValueMember = "CLS_CODE"
        ComboBox8.Text = Nothing

        '不具合
        ComboBox9.DataSource = P_DsCMB.Tables("CALL1_CLS")
        ComboBox9.DisplayMember = "NAME"
        ComboBox9.ValueMember = "CLS_CODE"
        ComboBox9.Text = Nothing

        '意見
        ComboBox10.DataSource = P_DsCMB.Tables("CALL2_CLS")
        ComboBox10.DisplayMember = "NAME"
        ComboBox10.ValueMember = "CLS_CODE"
        ComboBox10.Text = Nothing

        '結果１
        ComboBox11.DataSource = P_DsCMB.Tables("RPLY_CLS1")
        ComboBox11.DisplayMember = "NAME"
        ComboBox11.ValueMember = "CLS_CODE"
        ComboBox11.Text = Nothing

        '結果２
        ComboBox12.DataSource = P_DsCMB.Tables("RPLY_CLS2")
        ComboBox12.DisplayMember = "NAME"
        ComboBox12.ValueMember = "CLS_CODE"
        ComboBox12.Text = Nothing

    End Sub

    '画面クリア
    Private Sub dsp_clear()
        RadioButton1.Checked = True
        Edit1.Text = Nothing
        Edit2.Text = Nothing
        Edit3.Text = Nothing
        Edit4.Text = Nothing
        Edit5.Text = Nothing
        Edit6.Text = Nothing
        Edit6.Enabled = False
        Edit6.BackColor = System.Drawing.Color.LightGray

        RadioButton3.Checked = True
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox6.Text = Nothing
        ComboBox7.Text = Nothing
        ComboBox8.Text = Nothing
        ComboBox9.Text = Nothing
        ComboBox10.Text = Nothing
        ComboBox11.Text = Nothing
        ComboBox12.Text = Nothing

        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox6.Text = Nothing
        ComboBox7.Text = Nothing
        ComboBox8.Text = Nothing
        ComboBox9.Text = Nothing
        ComboBox10.Text = Nothing
        ComboBox11.Text = Nothing
        ComboBox12.Text = Nothing
        Button3.Enabled = True

        Edit1.Focus()
    End Sub

    '入力後
    'パネルクリック（未完了分）
    Private Sub Label_upd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        pPROC = "r1"
        Dim lbl As Label
        lbl = DirectCast(sender, Label)
        Edit6.Text = label(lbl.Tag, 1).Text
        Call no_search()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'パネルクリック（完了分）
    Private Sub Label_upd_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        pPROC = "r1"
        Dim lbl As Label
        lbl = DirectCast(sender, Label)
        Edit6.Text = label(lbl.Tag, 1).Text
        Call no_search()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    'パネルクリック（完了分）
    Private Sub Label_upd_Click5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim lbl As Label
        lbl = DirectCast(sender, Label)
        Edit6.Text = label(lbl.Tag, 1).Text

        Ds_Q.Clear()
        strSQL = "SELECT INQUIRY_DATA.*"
        strSQL = strSQL & " FROM INQUIRY_DATA"
        strSQL = strSQL & " WHERE (Q_NO = '" & label(lbl.Tag, 1).Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(Ds_Q, "INQUIRY_DATA")
        DB_CLOSE()
        DtView1 = New DataView(Ds_Q.Tables("INQUIRY_DATA"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            ComboBox1.SelectedValue = DtView1(0)("CUST_CLS")
            If DtView1(0)("SEX") = "1" Then
                RadioButton3.Checked = True
            Else
                RadioButton4.Checked = True
            End If
            If Not IsDBNull(DtView1(0)("AGE_CLS")) Then
                ComboBox2.SelectedValue = DtView1(0)("AGE_CLS")
            Else
                ComboBox2.Text = Nothing
                ComboBox2.Text = Nothing
            End If
            If Not IsDBNull(DtView1(0)("AREA_CLS")) Then
                ComboBox3.SelectedValue = DtView1(0)("AREA_CLS")
            Else
                ComboBox3.Text = Nothing
                ComboBox3.Text = Nothing
            End If
            If Not IsDBNull(DtView1(0)("CAT_CODE")) Then
                ComboBox4.SelectedValue = DtView1(0)("CAT_CODE")
            Else
                ComboBox4.Text = Nothing
                ComboBox4.Text = Nothing
            End If
            If Not IsDBNull(DtView1(0)("SHOP_CODE")) Then
                ComboBox6.SelectedValue = DtView1(0)("SHOP_CODE")
            Else
                ComboBox6.Text = Nothing
                ComboBox6.Text = Nothing
            End If
            If Not IsDBNull(DtView1(0)("YEAR_CLS")) Then
                ComboBox7.SelectedValue = DtView1(0)("YEAR_CLS")
            Else
                ComboBox7.Text = Nothing
                ComboBox7.Text = Nothing
            End If
            If Not IsDBNull(DtView1(0)("MONTHS_CLS")) Then
                ComboBox8.SelectedValue = DtView1(0)("MONTHS_CLS")
            Else
                ComboBox8.Text = Nothing
                ComboBox8.Text = Nothing
            End If
            If Not IsDBNull(DtView1(0)("CALL1_CLS")) Then
                ComboBox9.SelectedValue = DtView1(0)("CALL1_CLS")
            Else
                ComboBox9.Text = Nothing
                ComboBox9.Text = Nothing
            End If
            If Not IsDBNull(DtView1(0)("CALL2_CLS")) Then
                ComboBox10.SelectedValue = DtView1(0)("CALL2_CLS")
            Else
                ComboBox10.Text = Nothing
                ComboBox10.Text = Nothing
            End If
            ComboBox11.SelectedValue = DtView1(0)("RPLY_CLS1")
            ComboBox12.SelectedValue = DtView1(0)("RPLY_CLS2")
            Edit2.Text = DtView1(0)("ASKING")

            Button3.Enabled = False
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        Edit6.Enabled = False
        Edit6.BackColor = System.Drawing.Color.LightGray
    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        Edit6.Enabled = True
        Edit6.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click
        Edit6.Enabled = True
        Edit6.BackColor = System.Drawing.Color.White
    End Sub

    '*************************************************
    '** 加入検索
    '*************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Call Err_Chk()
        If Err_F = "0" Then
            If RadioButton1.Checked = True Then     '新規受付
                pPROC = "n1"
                Call new_search()       '新規受付検索
            Else
                pPROC = "r1"
                If RadioButton2.Checked = True Then '対応中
                    If Trim(Edit6.Text) <> Nothing Then
                        Call no_search()    '受付番号検索
                    Else
                        Call regd_search()  '対応中検索
                    End If
                Else                                '完了分
                    If Trim(Edit6.Text) <> Nothing Then
                        Call no_search()    '受付番号検索
                    Else
                        Call regd_search2()  '完了分検索
                    End If
                End If
            End If
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub Err_Chk()
        Err_F = "0"

        '未入力
        If RadioButton1.Checked = True Then     '新規受付
            If Trim(Edit1.Text) = Nothing And Trim(Edit3.Text) = Nothing And Trim(Edit4.Text) = Nothing And Trim(Edit5.Text) = Nothing Then
                MsgBox("検索項目を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                Edit1.Focus()
                Err_F = "1" : Exit Sub
            End If
        Else                                    '対応中、完了分
            If Trim(Edit1.Text) = Nothing And Trim(Edit3.Text) = Nothing And Trim(Edit4.Text) = Nothing And Trim(Edit5.Text) = Nothing And Trim(Edit6.Text) = Nothing Then
                MsgBox("検索項目を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                Edit6.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

    End Sub

    '*************************************************
    '** 新規受付検索
    '*************************************************
    Private Sub new_search()
        pWrn_no = Nothing
        pIcdt_no = Nothing
        pREPAIR_CODE = Nothing
        pPROC_DATE = Nothing

        Ds_search.Clear()
        strSQL = "SELECT WRN_DATA.*, 'A' AS STS_NAME FROM WRN_DATA"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & " WRN_DATE > '1900/01/01'"
        If Edit1.Text <> Nothing Then strSQL = strSQL & " AND (WRN_NO LIKE '" & Edit1.Text & "%')"
        If Edit3.Text <> Nothing Then strSQL = strSQL & " AND (CUST_NAME_KANA LIKE '" & Edit3.Text & "%')"
        If Edit4.Text <> Nothing Then strSQL = strSQL & " AND (CUST_NAME LIKE '" & Edit4.Text & "%')"
        If Edit5.Text <> Nothing Then strSQL = strSQL & " AND (TEL_NO LIKE '" & Edit5.Text & "%')"
        If Trim(Edit5.Text) <> Nothing Then
            strSQL = strSQL & " OR WRN_DATE > '1900/01/01'"
            If Edit1.Text <> Nothing Then strSQL = strSQL & " AND (WRN_NO LIKE '" & Edit1.Text & "%')"
            If Edit3.Text <> Nothing Then strSQL = strSQL & " AND (CUST_NAME_KANA LIKE '" & Edit3.Text & "%')"
            If Edit4.Text <> Nothing Then strSQL = strSQL & " AND (CUST_NAME LIKE '" & Edit4.Text & "%')"
            If Edit5.Text <> Nothing Then strSQL = strSQL & " AND (CNT_NO LIKE '" & Edit5.Text & "%')"
        End If
        strSQL = strSQL & " ORDER BY CUST_NAME"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        Try
            DaList1.Fill(Ds_search, "WRN_DATA")
            DB_CLOSE()
        Catch ex As Exception
            DB_CLOSE()
            MessageBox.Show(ex.Message, "Error")
            Exit Sub
        End Try

        DtView1 = New DataView(Ds_search.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)
        Select Case DtView1.Count
            Case Is = 0
                MsgBox("該当するデータはありません。", MsgBoxStyle.Information, "Warranty System")
            Case Is = 1
                pWrn_no = DtView1(0)("WRN_NO")
                Ds_search.Clear()

                Dim frmform3 As New Form3
                frmform3.ShowDialog()

                Call Panel_Set()
            Case Is <= 300
                WK_DtView1 = New DataView(Ds_search.Tables("WRN_DATA"), "SALE_STS <> '00'", "", DataViewRowState.CurrentRows)
                For i = 0 To WK_DtView1.Count - 1
                    If WK_DtView1(i)("SALE_STS") = "05" Then
                        WK_DtView1(i)("STS_NAME") = "F"
                    Else
                        WK_DtView1(i)("STS_NAME") = "C"
                    End If
                Next
                DtTbl0 = Ds_search.Tables("WRN_DATA")

                Dim frmform2_S As New Form2_S
                frmform2_S.ShowDialog()

                Call Panel_Set()
                Ds_search.Clear()
            Case Else
                MsgBox("該当するデータが300件を超えています。" & vbCrLf & "検索条件を変更してください。", MsgBoxStyle.Exclamation, "Warranty System")
        End Select

    End Sub

    '*************************************************
    '** 受付番号検索
    '*************************************************
    Private Sub no_search()
        Dim frmform3 As New Form3
        pWrn_no = Nothing
        pIcdt_no = Nothing
        pREPAIR_CODE = Nothing
        pPROC_DATE = Nothing

        Ds_search.Clear()
        strSQL = "SELECT WRN_NO, STATUS, FIN_FLAG"
        strSQL = strSQL & " FROM ICDT_DATA"
        strSQL = strSQL & " WHERE (ICDT_NO = '" & Edit6.Text & "')"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(Ds_search, "ICDT_DATA")
        DB_CLOSE()

        DtView1 = New DataView(Ds_search.Tables("ICDT_DATA"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            If DtView1(0)("STATUS") = "004" Or DtView1(0)("FIN_FLAG") = "1" Then
                MsgBox("このインシデントは「対応済み」です。" & vbCrLf & "読み取り専用で開きます。", MsgBoxStyle.Information, "Warranty System")
                pWrn_no = DtView1(0)("WRN_NO")
                pIcdt_no = Edit6.Text
                Ds_search.Clear()
                frmform3.ShowDialog()
                Call Panel_Set()
            Else
                pWrn_no = DtView1(0)("WRN_NO")
                pIcdt_no = Edit6.Text
                Ds_search.Clear()
                frmform3.ShowDialog()
                Call Panel_Set()
            End If
        Else
            MsgBox("該当するデータはありません。", MsgBoxStyle.Information, "Warranty System")
        End If

    End Sub

    '*************************************************
    '** 対応中検索
    '*************************************************
    Private Sub regd_search()
        pWrn_no = Nothing
        pIcdt_no = Nothing
        pREPAIR_CODE = Nothing
        pPROC_DATE = Nothing

        Ds_search.Clear()
        strSQL = "SELECT ICDT_DATA.ICDT_NO, WRN_DATA.*, 'A' AS STS_NAME"
        strSQL = strSQL & " FROM ICDT_DATA RIGHT OUTER JOIN WRN_DATA ON ICDT_DATA.WRN_NO = WRN_DATA.WRN_NO"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & " (ICDT_DATA.STATUS <> '004')"
        If Edit1.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.WRN_NO LIKE '" & Edit1.Text & "%')"
        If Edit3.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME_KANA LIKE '" & Edit3.Text & "%')"
        If Edit4.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME LIKE '" & Edit4.Text & "%')"
        If Edit5.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.TEL_NO LIKE '" & Edit5.Text & "%')"
        If Trim(Edit5.Text) <> Nothing Then
            strSQL = strSQL & " OR (ICDT_DATA.STATUS <> '004')"
            If Edit1.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.WRN_NO LIKE '" & Edit1.Text & "%')"
            If Edit3.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME_KANA LIKE '" & Edit3.Text & "%')"
            If Edit4.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME LIKE '" & Edit4.Text & "%')"
            If Edit5.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CNT_NO LIKE '" & Edit5.Text & "%')"
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(Ds_search, "WRN_DATA")
        DB_CLOSE()
        DtView1 = New DataView(Ds_search.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)

        Select Case DtView1.Count
            Case Is = 0
                MsgBox("該当するデータはありません。", MsgBoxStyle.Information, "Warranty System")
            Case Is = 1
                pWrn_no = DtView1(0)("WRN_NO")
                pIcdt_no = DtView1(0)("ICDT_NO")
                Ds_search.Clear()
                Dim frmform3 As New Form3
                frmform3.ShowDialog()
                Call Panel_Set()
            Case Else
                WK_DtView1 = New DataView(Ds_search.Tables("WRN_DATA"), "SALE_STS <> '00'", "", DataViewRowState.CurrentRows)
                For i = 0 To WK_DtView1.Count - 1
                    If WK_DtView1(i)("SALE_STS") = "05" Then
                        WK_DtView1(i)("STS_NAME") = "F"
                    Else
                        WK_DtView1(i)("STS_NAME") = "C"
                    End If
                Next
                DtTbl0 = Ds_search.Tables("WRN_DATA")
                Dim frmform2_S As New Form2_S
                frmform2_S.ShowDialog()
                Call Panel_Set()
                Ds_search.Clear()
        End Select

    End Sub

    '*************************************************
    '** 完了分検索
    '*************************************************
    Private Sub regd_search2()
        pWrn_no = Nothing
        pIcdt_no = Nothing
        pREPAIR_CODE = Nothing
        pPROC_DATE = Nothing

        Ds_search.Clear()
        strSQL = "SELECT ICDT_DATA.ICDT_NO, WRN_DATA.*, 'A' AS STS_NAME"
        strSQL = strSQL & " FROM ICDT_DATA RIGHT OUTER JOIN WRN_DATA ON ICDT_DATA.WRN_NO = WRN_DATA.WRN_NO"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & " (ICDT_DATA.STATUS = '004')"
        If Edit1.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.WRN_NO LIKE '" & Edit1.Text & "%')"
        If Edit3.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME_KANA LIKE '" & Edit3.Text & "%')"
        If Edit4.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME LIKE '" & Edit4.Text & "%')"
        If Edit5.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.TEL_NO LIKE '" & Edit5.Text & "%')"
        If Trim(Edit5.Text) <> Nothing Then
            strSQL = strSQL & " OR (ICDT_DATA.STATUS = '004')"
            If Edit1.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.WRN_NO LIKE '" & Edit1.Text & "%')"
            If Edit3.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME_KANA LIKE '" & Edit3.Text & "%')"
            If Edit4.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CUST_NAME LIKE '" & Edit4.Text & "%')"
            If Edit5.Text <> Nothing Then strSQL = strSQL & " AND (WRN_DATA.CNT_NO LIKE '" & Edit5.Text & "%')"
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(Ds_search, "WRN_DATA")
        DB_CLOSE()
        DtView1 = New DataView(Ds_search.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)

        Select Case DtView1.Count
            Case Is = 0
                MsgBox("該当するデータはありません。", MsgBoxStyle.Information, "Warranty System")
            Case Is = 1
                pWrn_no = DtView1(0)("WRN_NO")
                pIcdt_no = DtView1(0)("ICDT_NO")
                Ds_search.Clear()
                Dim frmform3 As New Form3
                frmform3.ShowDialog()
                Call Panel_Set()
            Case Else
                WK_DtView1 = New DataView(Ds_search.Tables("WRN_DATA"), "SALE_STS <> '00'", "", DataViewRowState.CurrentRows)
                For i = 0 To WK_DtView1.Count - 1
                    If WK_DtView1(i)("SALE_STS") = "05" Then
                        WK_DtView1(i)("STS_NAME") = "F"
                    Else
                        WK_DtView1(i)("STS_NAME") = "C"
                    End If
                Next
                DtTbl0 = Ds_search.Tables("WRN_DATA")
                Dim frmform2_S2 As New Form2_S2
                frmform2_S2.ShowDialog()
                Call Panel_Set()
                Ds_search.Clear()
        End Select

    End Sub

    '*********************************************************************************
    '*** その他の問合せ
    '*********************************************************************************

    '登録ボタン
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Call Err_Chk2()
        If Err_F = "0" Then
            'Count_Get
            Dim Q_NO As String = Count_Get()

            'INQUIRY_DATA
            strSQL = "INSERT INTO INQUIRY_DATA"
            strSQL = strSQL & " (Q_NO, Q_DATE, CUST_CLS, SEX, AGE_CLS, AREA_CLS, CAT_CODE"
            strSQL = strSQL & ", SHOP_CODE, YEAR_CLS, MONTHS_CLS, CALL1_CLS, CALL2_CLS"
            strSQL = strSQL & ", RPLY_CLS1, RPLY_CLS2, EMPL_CODE, ASKING)"
            strSQL = strSQL & " VALUES ('" & Q_NO & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & Now & "', 102)"
            strSQL = strSQL & ", '" & ComboBox1.SelectedValue & "'"
            If RadioButton3.Checked = True Then
                strSQL = strSQL & ", '1'"
            Else
                strSQL = strSQL & ", '2'"
            End If
            If Trim(ComboBox2.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox2.SelectedValue & "'"
            End If
            If Trim(ComboBox3.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox3.SelectedValue & "'"
            End If
            If Trim(ComboBox4.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox4.SelectedValue & "'"
            End If
            If Trim(ComboBox6.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox6.SelectedValue & "'"
            End If
            If Trim(ComboBox7.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox7.SelectedValue & "'"
            End If
            If Trim(ComboBox8.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox8.SelectedValue & "'"
            End If
            If Trim(ComboBox9.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox9.SelectedValue & "'"
            End If
            If Trim(ComboBox10.Text) = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", '" & ComboBox10.SelectedValue & "'"
            End If
            strSQL = strSQL & ", '" & ComboBox11.SelectedValue & "'"
            strSQL = strSQL & ", '" & ComboBox12.SelectedValue & "'"
            strSQL = strSQL & ", '" & pEmpl_code & "'"
            strSQL = strSQL & ", '" & Edit2.Text & "')"
            DB_OPEN()
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Call Panel_Set()
            MsgBox("受付番号:" & Q_NO & "で登録しました。", MsgBoxStyle.OKOnly, "Warranty System")
            Call dsp_clear()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub Err_Chk2()
        Err_F = "0"

        '相手先属性
        If Trim(ComboBox1.Text) = Nothing Then
            MsgBox("相手先を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox1.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("CUST_CLS"), "NAME='" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する相手先がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox1.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox1.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '年齢層
        If Trim(ComboBox2.Text) = Nothing Then
            'MsgBox("年齢層を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox2.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("AGE_CLS"), "NAME='" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する年齢層がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox2.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox2.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '地域
        If Trim(ComboBox3.Text) = Nothing Then
            'MsgBox("地域を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox3.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("AREA_CLS"), "NAME='" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する地域がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox3.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '商品ｶﾃｺﾞﾘｰ
        If Trim(ComboBox4.Text) = Nothing Then
            'MsgBox("商品ｶﾃｺﾞﾘｰを入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox4.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("M_category2"), "CAT_NAME='" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する商品ｶﾃｺﾞﾘｰがありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox4.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox4.SelectedValue = DtView1(0)("CAT_CODE")
            End If
        End If

        '購入店舗
        If Trim(ComboBox6.Text) = Nothing Then
            'MsgBox("購入店舗を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox6.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("SHOP2"), "SHOP_NAME='" & ComboBox6.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する購入店舗がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox6.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox6.SelectedValue = DtView1(0)("SHOP_CODE")
            End If
        End If

        '問合せ内容
        Edit2.Text = Trim(Edit2.Text)

        '購入後　年
        If Trim(ComboBox7.Text) = Nothing Then
            'MsgBox("購入後　年を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox7.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("YEAR_CLS"), "NAME='" & ComboBox7.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する購入後　年がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox7.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox7.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '購入後　月
        If Trim(ComboBox8.Text) = Nothing Then
            'MsgBox("購入後　月を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            'ComboBox8.Focus()
            'Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("MONTHS_CLS"), "NAME='" & ComboBox8.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する購入後　月がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox8.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox8.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        'コール内容
        If Trim(ComboBox9.Text) = Nothing Then
            If Trim(ComboBox10.Text) = Nothing Then
                MsgBox("コール内容を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox9.Focus()
                Err_F = "1" : Exit Sub
            Else
                '意見・要望系
                If Trim(ComboBox10.Text) = Nothing Then
                    'MsgBox("意見・要望系を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                    'ComboBox10.Focus()
                    'Err_F = "1" : Exit Sub
                Else
                    DtView1 = New DataView(P_DsCMB.Tables("CALL2_CLS"), "NAME='" & ComboBox10.Text & "'", "", DataViewRowState.CurrentRows)
                    If DtView1.Count = 0 Then
                        MsgBox("該当する意見・要望系がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                        ComboBox10.Focus()
                        Err_F = "1" : Exit Sub
                    Else
                        ComboBox10.SelectedValue = DtView1(0)("CLS_CODE")
                    End If
                End If
            End If
        Else
            If Trim(ComboBox10.Text) = Nothing Then
                '不具合系
                If Trim(ComboBox9.Text) = Nothing Then
                    'MsgBox("不具合系を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
                    'ComboBox9.Focus()
                    'Err_F = "1" : Exit Sub
                Else
                    DtView1 = New DataView(P_DsCMB.Tables("CALL1_CLS"), "NAME='" & ComboBox9.Text & "'", "", DataViewRowState.CurrentRows)
                    If DtView1.Count = 0 Then
                        MsgBox("該当する不具合系がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                        ComboBox9.Focus()
                        Err_F = "1" : Exit Sub
                    Else
                        ComboBox9.SelectedValue = DtView1(0)("CLS_CODE")
                    End If
                End If
            Else
                MsgBox("コール内容は不具合系か意見・要望系の一方しか入力できません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox9.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

        '対応結果１
        If Trim(ComboBox11.Text) = Nothing Then
            MsgBox("対応結果１を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox11.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("RPLY_CLS1"), "NAME='" & ComboBox11.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する対応結果１がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox11.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox11.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

        '対応結果２
        If Trim(ComboBox12.Text) = Nothing Then
            MsgBox("対応結果２を入力してください。", MsgBoxStyle.Exclamation, "Warranty System")
            ComboBox12.Focus()
            Err_F = "1" : Exit Sub
        Else
            DtView1 = New DataView(P_DsCMB.Tables("RPLY_CLS2"), "NAME='" & ComboBox12.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("該当する対応結果２がありません。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox12.Focus()
                Err_F = "1" : Exit Sub
            Else
                ComboBox12.SelectedValue = DtView1(0)("CLS_CODE")
            End If
        End If

    End Sub

    '*************************************************
    '** パネルセット
    '*************************************************
    Private Sub Panel_Set()
        Panel1.Controls.Clear()
        DsList1.Clear()

        '延長保証
        line_no = 0
        en = 0
        label(line_no, en) = New Label
        label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        label(line_no, en).Location = New System.Drawing.Point(10, 22 * line_no + 20)
        label(line_no, en).Size = New System.Drawing.Size(200, 22)
        label(line_no, en).Text = "延長保証"
        Panel1.Controls.Add(label(line_no, en))

        '未完了分
        line_no = line_no + 1
        en = 0
        label(line_no, en) = New Label
        label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        label(line_no, en).ForeColor = Drawing.Color.Red
        label(line_no, en).Location = New System.Drawing.Point(10, 22 * line_no + 20)
        label(line_no, en).Size = New System.Drawing.Size(200, 22)
        label(line_no, en).Text = "未完了インシデント"
        Panel1.Controls.Add(label(line_no, en))

        strSQL = "SELECT ICDT_DATA.WRN_NO, WRN_DATA.CUST_NAME, ICDT_DATA.STATUS, MIN(ICDT_DTL.RCV_DATE) AS MIN_DATE, ICDT_DATA.ICDT_NO, ICDT_DATA.EMPL_CODE"
        strSQL = strSQL & " FROM ICDT_DATA LEFT OUTER JOIN WRN_DATA ON ICDT_DATA.WRN_NO = WRN_DATA.WRN_NO LEFT OUTER JOIN ICDT_DTL ON ICDT_DATA.ICDT_NO = ICDT_DTL.ICDT_NO"
        strSQL = strSQL & " GROUP BY ICDT_DATA.WRN_NO, ICDT_DATA.STATUS, ICDT_DATA.FIN_FLAG, ICDT_DATA.ICDT_NO, ICDT_DATA.EMPL_CODE, WRN_DATA.CUST_NAME"
        strSQL = strSQL & " HAVING (ICDT_DATA.STATUS <> '004') AND (ICDT_DATA.FIN_FLAG <> '1')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ICDT_DATA")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("ICDT_DATA"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                line_no = line_no + 1
                en = 0
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Cursor = System.Windows.Forms.Cursors.Hand
                label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
                label(line_no, en).Size = New System.Drawing.Size(200, 20)
                label(line_no, en).Text = DtView1(i)("ICDT_NO") & " - " & DtView1(i)("CUST_NAME")
                label(line_no, en).Tag = line_no
                Panel1.Controls.Add(label(line_no, en))
                AddHandler label(line_no, en).Click, AddressOf Label_upd_Click

                en = 1
                label(line_no, en) = New Label
                label(line_no, en).Text = DtView1(i)("ICDT_NO")
            Next
            line_no = line_no + 1
            en = 0
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
            label(line_no, en).Size = New System.Drawing.Size(200, 22)
            label(line_no, en).Text = "未完了 " & DtView1.Count & " 件"
            Panel1.Controls.Add(label(line_no, en))
        Else
            line_no = line_no + 1
            en = 0
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
            label(line_no, en).Size = New System.Drawing.Size(200, 22)
            label(line_no, en).Text = "ありません"
            Panel1.Controls.Add(label(line_no, en))
        End If

        '完了
        line_no = line_no + 1
        en = 0
        label(line_no, en) = New Label
        label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        label(line_no, en).ForeColor = Drawing.Color.Blue
        label(line_no, en).Location = New System.Drawing.Point(10, 22 * line_no + 20)
        label(line_no, en).Size = New System.Drawing.Size(200, 22)
        label(line_no, en).Text = "本日完了インシデント"
        label(line_no, en).Tag = 0
        Panel1.Controls.Add(label(line_no, en))

        strSQL = "SELECT ICDT_DATA.ICDT_NO, ICDT_DATA.WRN_NO, WRN_DATA.CUST_NAME, MAX(ICDT_DTL.RCV_DATE) AS MAX_DATE"
        strSQL = strSQL & " FROM ICDT_DATA LEFT OUTER JOIN WRN_DATA ON ICDT_DATA.WRN_NO = WRN_DATA.WRN_NO LEFT OUTER JOIN ICDT_DTL ON ICDT_DATA.ICDT_NO = ICDT_DTL.ICDT_NO"
        strSQL = strSQL & " WHERE (ICDT_DTL.RCV_DATE >= CONVERT(DATETIME, '" & Now.Date & "', 102) AND ICDT_DTL.RCV_DATE < CONVERT(DATETIME, '" & DateAdd(DateInterval.Day, 1, Now.Date) & "', 102))"
        strSQL = strSQL & " GROUP BY ICDT_DATA.ICDT_NO, ICDT_DATA.WRN_NO, ICDT_DATA.STATUS, ICDT_DATA.FIN_FLAG, ICDT_DATA.EMPL_CODE, WRN_DATA.CUST_NAME"
        strSQL = strSQL & " HAVING (ICDT_DATA.STATUS = '004' OR ICDT_DATA.FIN_FLAG = '1')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ICDT_DATA2")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("ICDT_DATA2"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                line_no = line_no + 1
                en = 0
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Cursor = System.Windows.Forms.Cursors.Hand
                label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
                label(line_no, en).Size = New System.Drawing.Size(200, 20)
                label(line_no, en).Text = DtView1(i)("ICDT_NO") & " - " & DtView1(i)("CUST_NAME")
                label(line_no, en).Tag = line_no
                Panel1.Controls.Add(label(line_no, en))
                AddHandler label(line_no, en).Click, AddressOf Label_upd_Click2

                en = 1
                label(line_no, en) = New Label
                label(line_no, en).Text = DtView1(i)("ICDT_NO")
            Next
            line_no = line_no + 1
            en = 0
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
            label(line_no, en).Size = New System.Drawing.Size(200, 22)
            label(line_no, en).Text = "本日完了 " & DtView1.Count & " 件"
            Panel1.Controls.Add(label(line_no, en))
        Else
            line_no = line_no + 1
            en = 0
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
            label(line_no, en).Size = New System.Drawing.Size(200, 22)
            label(line_no, en).Text = "ありません"
            Panel1.Controls.Add(label(line_no, en))
        End If

        line_no = line_no + 1

        'その他の問合せ
        line_no = line_no + 1
        en = 0
        label(line_no, en) = New Label
        label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        label(line_no, en).Location = New System.Drawing.Point(10, 22 * line_no + 20)
        label(line_no, en).Size = New System.Drawing.Size(200, 22)
        label(line_no, en).Text = "その他の問合せ"
        Panel1.Controls.Add(label(line_no, en))

        line_no = line_no + 1
        en = 0
        label(line_no, en) = New Label
        label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        label(line_no, en).ForeColor = Drawing.Color.Blue
        label(line_no, en).Location = New System.Drawing.Point(10, 22 * line_no + 20)
        label(line_no, en).Size = New System.Drawing.Size(200, 22)
        label(line_no, en).Text = "本日完了インシデント"
        label(line_no, en).Tag = 0
        Panel1.Controls.Add(label(line_no, en))

        strSQL = "SELECT INQUIRY_DATA.*"
        strSQL = strSQL & " FROM INQUIRY_DATA"
        strSQL = strSQL & " WHERE (YEAR(Q_DATE) = " & Year(Now) & ")"
        strSQL = strSQL & " AND (MONTH(Q_DATE) = " & Month(Now) & ")"
        strSQL = strSQL & " AND (DAY(Q_DATE) = " & Format(Now, "dd") & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "INQUIRY_DATA")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("INQUIRY_DATA"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                line_no = line_no + 1
                en = 0
                label(line_no, en) = New Label
                label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                label(line_no, en).Cursor = System.Windows.Forms.Cursors.Hand
                label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
                label(line_no, en).Size = New System.Drawing.Size(200, 20)
                label(line_no, en).Text = Trim(DtView1(i)("Q_NO")) & " - " & Format(DtView1(i)("Q_DATE"), "hh:mm")
                label(line_no, en).Tag = line_no
                Panel1.Controls.Add(label(line_no, en))
                AddHandler label(line_no, en).Click, AddressOf Label_upd_Click5

                en = 1
                label(line_no, en) = New Label
                label(line_no, en).Text = DtView1(i)("Q_NO")
            Next
            line_no = line_no + 1
            en = 0
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
            label(line_no, en).Size = New System.Drawing.Size(200, 22)
            label(line_no, en).Text = "本日完了 " & DtView1.Count & " 件"
            Panel1.Controls.Add(label(line_no, en))
        Else
            line_no = line_no + 1
            en = 0
            label(line_no, en) = New Label
            label(line_no, en).Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            label(line_no, en).Location = New System.Drawing.Point(15, 22 * line_no + 20)
            label(line_no, en).Size = New System.Drawing.Size(200, 22)
            label(line_no, en).Text = "ありません"
            Panel1.Controls.Add(label(line_no, en))
        End If

    End Sub

    '*************************************************
    '** その他問合せ検索
    '*************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\MrMAX_INQUIRY.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*************************************************
    '** 修理受付№検索
    '*************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\MrMAX_REP.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*************************************************
    '** クリア
    '*************************************************
    Private Sub Button95_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button95.Click
        Call dsp_clear()
    End Sub

    '*************************************************
    '** 終了
    '*************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub
End Class
