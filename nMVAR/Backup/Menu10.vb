Public Class Menu10
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, Dsinfo As New DataSet
    Dim DtView1 As DataView

    Dim r, i As Integer

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button02 As System.Windows.Forms.Button
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents Button03 As System.Windows.Forms.Button
    Friend WithEvents Button04 As System.Windows.Forms.Button
    Friend WithEvents Button06 As System.Windows.Forms.Button
    Friend WithEvents Button07 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button51 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button52 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button53 As System.Windows.Forms.Button
    Friend WithEvents Button54 As System.Windows.Forms.Button
    Friend WithEvents Button81 As System.Windows.Forms.Button
    Friend WithEvents Button82 As System.Windows.Forms.Button
    Friend WithEvents Button83 As System.Windows.Forms.Button
    Friend WithEvents Button84 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Edit11 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit31 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit21 As GrapeCity.Win.Input.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Menu10))
        Me.Button02 = New System.Windows.Forms.Button
        Me.Button01 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button07 = New System.Windows.Forms.Button
        Me.Button06 = New System.Windows.Forms.Button
        Me.Button04 = New System.Windows.Forms.Button
        Me.Button03 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button27 = New System.Windows.Forms.Button
        Me.Button22 = New System.Windows.Forms.Button
        Me.Button21 = New System.Windows.Forms.Button
        Me.Button24 = New System.Windows.Forms.Button
        Me.Button26 = New System.Windows.Forms.Button
        Me.Button23 = New System.Windows.Forms.Button
        Me.Button51 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button52 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button54 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button53 = New System.Windows.Forms.Button
        Me.Button81 = New System.Windows.Forms.Button
        Me.Button82 = New System.Windows.Forms.Button
        Me.Button83 = New System.Windows.Forms.Button
        Me.Button84 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Edit11 = New GrapeCity.Win.Input.Edit
        Me.Edit31 = New GrapeCity.Win.Input.Edit
        Me.Edit21 = New GrapeCity.Win.Input.Edit
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button02
        '
        Me.Button02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button02.Enabled = False
        Me.Button02.Location = New System.Drawing.Point(20, 88)
        Me.Button02.Name = "Button02"
        Me.Button02.Size = New System.Drawing.Size(120, 48)
        Me.Button02.TabIndex = 1
        Me.Button02.Text = "受付修正"
        '
        'Button01
        '
        Me.Button01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button01.Enabled = False
        Me.Button01.Location = New System.Drawing.Point(20, 32)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(120, 48)
        Me.Button01.TabIndex = 0
        Me.Button01.Text = "新規受付"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button07)
        Me.GroupBox1.Controls.Add(Me.Button06)
        Me.GroupBox1.Controls.Add(Me.Button04)
        Me.GroupBox1.Controls.Add(Me.Button03)
        Me.GroupBox1.Controls.Add(Me.Button02)
        Me.GroupBox1.Controls.Add(Me.Button01)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 268)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "受付"
        '
        'Button07
        '
        Me.Button07.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button07.Location = New System.Drawing.Point(20, 344)
        Me.Button07.Name = "Button07"
        Me.Button07.Size = New System.Drawing.Size(120, 44)
        Me.Button07.TabIndex = 26
        Me.Button07.Visible = False
        '
        'Button06
        '
        Me.Button06.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button06.Location = New System.Drawing.Point(20, 292)
        Me.Button06.Name = "Button06"
        Me.Button06.Size = New System.Drawing.Size(120, 44)
        Me.Button06.TabIndex = 25
        Me.Button06.Visible = False
        '
        'Button04
        '
        Me.Button04.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button04.Enabled = False
        Me.Button04.Location = New System.Drawing.Point(20, 200)
        Me.Button04.Name = "Button04"
        Me.Button04.Size = New System.Drawing.Size(120, 48)
        Me.Button04.TabIndex = 3
        Me.Button04.Visible = False
        '
        'Button03
        '
        Me.Button03.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button03.Enabled = False
        Me.Button03.Location = New System.Drawing.Point(20, 144)
        Me.Button03.Name = "Button03"
        Me.Button03.Size = New System.Drawing.Size(120, 48)
        Me.Button03.TabIndex = 2
        Me.Button03.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button17)
        Me.GroupBox2.Controls.Add(Me.Button12)
        Me.GroupBox2.Controls.Add(Me.Button11)
        Me.GroupBox2.Controls.Add(Me.Button14)
        Me.GroupBox2.Controls.Add(Me.Button16)
        Me.GroupBox2.Controls.Add(Me.Button13)
        Me.GroupBox2.Location = New System.Drawing.Point(184, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 268)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "見積"
        '
        'Button17
        '
        Me.Button17.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button17.Location = New System.Drawing.Point(20, 344)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(120, 44)
        Me.Button17.TabIndex = 33
        Me.Button17.Visible = False
        '
        'Button12
        '
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Enabled = False
        Me.Button12.Location = New System.Drawing.Point(20, 144)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(120, 48)
        Me.Button12.TabIndex = 1
        Me.Button12.Text = "見積書印刷"
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Enabled = False
        Me.Button11.Location = New System.Drawing.Point(20, 32)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(120, 48)
        Me.Button11.TabIndex = 0
        Me.Button11.Text = "見積入力"
        '
        'Button14
        '
        Me.Button14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button14.Enabled = False
        Me.Button14.Location = New System.Drawing.Point(20, 200)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(120, 48)
        Me.Button14.TabIndex = 3
        Me.Button14.Visible = False
        '
        'Button16
        '
        Me.Button16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button16.Location = New System.Drawing.Point(20, 292)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(120, 44)
        Me.Button16.TabIndex = 32
        Me.Button16.Visible = False
        '
        'Button13
        '
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Enabled = False
        Me.Button13.Location = New System.Drawing.Point(20, 88)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(120, 48)
        Me.Button13.TabIndex = 2
        Me.Button13.Text = "続行・返却"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button27)
        Me.GroupBox3.Controls.Add(Me.Button22)
        Me.GroupBox3.Controls.Add(Me.Button21)
        Me.GroupBox3.Controls.Add(Me.Button24)
        Me.GroupBox3.Controls.Add(Me.Button26)
        Me.GroupBox3.Controls.Add(Me.Button23)
        Me.GroupBox3.Location = New System.Drawing.Point(352, 36)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 268)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "完了"
        '
        'Button27
        '
        Me.Button27.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button27.Location = New System.Drawing.Point(20, 344)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(120, 44)
        Me.Button27.TabIndex = 40
        Me.Button27.Visible = False
        '
        'Button22
        '
        Me.Button22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button22.Location = New System.Drawing.Point(20, 88)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(120, 48)
        Me.Button22.TabIndex = 1
        Me.Button22.Text = "IBM/Hｐ報告書"
        '
        'Button21
        '
        Me.Button21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button21.Enabled = False
        Me.Button21.Location = New System.Drawing.Point(20, 32)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(120, 48)
        Me.Button21.TabIndex = 0
        Me.Button21.Text = "完了入力"
        '
        'Button24
        '
        Me.Button24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button24.Enabled = False
        Me.Button24.Location = New System.Drawing.Point(20, 200)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(120, 48)
        Me.Button24.TabIndex = 3
        Me.Button24.Visible = False
        '
        'Button26
        '
        Me.Button26.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button26.Location = New System.Drawing.Point(20, 292)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(120, 44)
        Me.Button26.TabIndex = 39
        Me.Button26.Visible = False
        '
        'Button23
        '
        Me.Button23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button23.Location = New System.Drawing.Point(20, 144)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(120, 48)
        Me.Button23.TabIndex = 2
        Me.Button23.Text = "完了済修正"
        '
        'Button51
        '
        Me.Button51.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button51.Location = New System.Drawing.Point(20, 32)
        Me.Button51.Name = "Button51"
        Me.Button51.Size = New System.Drawing.Size(120, 48)
        Me.Button51.TabIndex = 0
        Me.Button51.Text = "ﾌﾟﾘﾝﾀ設定"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(696, 260)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(120, 44)
        Me.Button98.TabIndex = 4
        Me.Button98.Text = "戻る"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(648, 20)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button52
        '
        Me.Button52.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button52.Enabled = False
        Me.Button52.Location = New System.Drawing.Point(20, 88)
        Me.Button52.Name = "Button52"
        Me.Button52.Size = New System.Drawing.Size(120, 48)
        Me.Button52.TabIndex = 1
        Me.Button52.Text = "排他解除"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button54)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Button51)
        Me.GroupBox4.Controls.Add(Me.Button52)
        Me.GroupBox4.Controls.Add(Me.Button53)
        Me.GroupBox4.Location = New System.Drawing.Point(520, 36)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(160, 268)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "設定"
        '
        'Button54
        '
        Me.Button54.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button54.Enabled = False
        Me.Button54.Location = New System.Drawing.Point(20, 200)
        Me.Button54.Name = "Button54"
        Me.Button54.Size = New System.Drawing.Size(120, 48)
        Me.Button54.TabIndex = 3
        Me.Button54.Visible = False
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(20, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 44)
        Me.Button1.TabIndex = 40
        Me.Button1.Visible = False
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(20, 292)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(120, 44)
        Me.Button5.TabIndex = 39
        Me.Button5.Visible = False
        '
        'Button53
        '
        Me.Button53.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button53.Enabled = False
        Me.Button53.Location = New System.Drawing.Point(20, 144)
        Me.Button53.Name = "Button53"
        Me.Button53.Size = New System.Drawing.Size(120, 48)
        Me.Button53.TabIndex = 2
        Me.Button53.Visible = False
        '
        'Button81
        '
        Me.Button81.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button81.Location = New System.Drawing.Point(696, 68)
        Me.Button81.Name = "Button81"
        Me.Button81.Size = New System.Drawing.Size(120, 48)
        Me.Button81.TabIndex = 41
        Me.Button81.Text = "TSSメニュー"
        '
        'Button82
        '
        Me.Button82.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button82.Location = New System.Drawing.Point(696, 124)
        Me.Button82.Name = "Button82"
        Me.Button82.Size = New System.Drawing.Size(120, 48)
        Me.Button82.TabIndex = 44
        Me.Button82.Text = "旧MVARからデータ取込み"
        '
        'Button83
        '
        Me.Button83.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button83.Location = New System.Drawing.Point(696, 180)
        Me.Button83.Name = "Button83"
        Me.Button83.Size = New System.Drawing.Size(120, 48)
        Me.Button83.TabIndex = 45
        Me.Button83.Text = "Q&&Aメニュー"
        '
        'Button84
        '
        Me.Button84.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button84.Location = New System.Drawing.Point(696, 12)
        Me.Button84.Name = "Button84"
        Me.Button84.Size = New System.Drawing.Size(120, 48)
        Me.Button84.TabIndex = 40
        Me.Button84.Text = "情報入力"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(716, 28)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "技術/販社情報"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(732, 312)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 28)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "更新日"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(732, 340)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 84)
        Me.Label12.TabIndex = 49
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Window
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(732, 424)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 84)
        Me.Label22.TabIndex = 51
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Window
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(732, 508)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(84, 84)
        Me.Label32.TabIndex = 53
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit11
        '
        Me.Edit11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Edit11.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit11.HighlightText = True
        Me.Edit11.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit11.LengthAsByte = True
        Me.Edit11.Location = New System.Drawing.Point(16, 340)
        Me.Edit11.MaxLength = 800
        Me.Edit11.Multiline = True
        Me.Edit11.Name = "Edit11"
        Me.Edit11.ReadOnly = True
        Me.Edit11.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit11.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit11.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit11.Size = New System.Drawing.Size(716, 84)
        Me.Edit11.TabIndex = 54
        Me.Edit11.TabStop = False
        '
        'Edit31
        '
        Me.Edit31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Edit31.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit31.HighlightText = True
        Me.Edit31.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit31.LengthAsByte = True
        Me.Edit31.Location = New System.Drawing.Point(16, 508)
        Me.Edit31.MaxLength = 800
        Me.Edit31.Multiline = True
        Me.Edit31.Name = "Edit31"
        Me.Edit31.ReadOnly = True
        Me.Edit31.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit31.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit31.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit31.Size = New System.Drawing.Size(716, 84)
        Me.Edit31.TabIndex = 55
        Me.Edit31.TabStop = False
        '
        'Edit21
        '
        Me.Edit21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Edit21.DisabledForeColor = System.Drawing.Color.Black
        Me.Edit21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit21.HighlightText = True
        Me.Edit21.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit21.LengthAsByte = True
        Me.Edit21.Location = New System.Drawing.Point(16, 424)
        Me.Edit21.MaxLength = 800
        Me.Edit21.Multiline = True
        Me.Edit21.Name = "Edit21"
        Me.Edit21.ReadOnly = True
        Me.Edit21.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit21.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit21.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit21.Size = New System.Drawing.Size(716, 84)
        Me.Edit21.TabIndex = 56
        Me.Edit21.TabStop = False
        '
        'Menu10
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 18)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.ClientSize = New System.Drawing.Size(830, 607)
        Me.Controls.Add(Me.Edit21)
        Me.Controls.Add(Me.Edit31)
        Me.Controls.Add(Me.Edit11)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button84)
        Me.Controls.Add(Me.Button83)
        Me.Controls.Add(Me.Button82)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button81)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Menu10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修理業務メニュー"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Edit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Menu10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()   '**  初期処理
        ACES()  '**  権限チェック
        DspSet()
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Label1.Text = P_EMPL_NAME & " / " & P_EMPL_BRCH_name
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

        '新規受付
        Button01.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='101'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button01.Enabled = True
            End Select
        End If

        '受付修正
        Button02.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='102'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button02.Enabled = True
            End Select
        End If

        '見積入力
        Button11.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='111'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button11.Enabled = True
            End Select
        End If

        '見積書印刷
        Button12.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='112'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button12.Enabled = True
            End Select
        End If

        '進行・返却
        Button13.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='113'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button13.Enabled = True
            End Select
        End If

        '完了入力
        Button21.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='121'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button21.Enabled = True
            End Select
        End If

        'IBM/Hｐ報告書
        Button22.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='122'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button22.Enabled = True
            End Select
        End If

        '完了済修正
        Button23.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='123'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button23.Enabled = True
            End Select
        End If

        ''ﾌﾟﾘﾝﾀ設定
        'Button51.Enabled = False
        'DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='151'", "", DataViewRowState.CurrentRows)
        'If DtView1.Count <> 0 Then
        '    Select Case DtView1(0)("access_cls")
        '        Case Is = "2", "3", "4"
        Button51.Enabled = True
        '    End Select
        'End If

        '排他解除
        Button52.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='152'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button52.Enabled = True
            End Select
        End If

        'ＴＳＳメニュー
        Button81.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='181'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button81.Enabled = True
            End Select
        End If

        '旧MVARからデータ取込み
        Button82.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='182'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button82.Enabled = True
            End Select
        End If

        'Ｑ＆Ａメニュー
        Button83.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='183'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button83.Enabled = True
            End Select
        End If

        '情報入力
        Button84.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='184'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button84.Enabled = True
            End Select
        End If

    End Sub

    '********************************************************************
    '**  新規受付
    '********************************************************************
    Private Sub Button01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button01.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form01 As New F10_Form01
        F10_Form01.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  受付修正
    '********************************************************************
    Private Sub Button02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button02.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form02 As New F10_Form02
        F10_Form02.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  見積入力
    '********************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form11 As New F10_Form11
        F10_Form11.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  見積書印刷
    '********************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form12 As New F10_Form12
        F10_Form12.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  続行・返却
    '********************************************************************
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form13 As New F10_Form13
        F10_Form13.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  完了入力
    '********************************************************************
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form21 As New F10_Form21
        F10_Form21.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  IBM/Hｐの報告書
    '********************************************************************
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Me.Hide()
        Dim F10_Form22 As New F10_Form22
        F10_Form22.ShowDialog()
        'Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  完了済修正
    '********************************************************************
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_Mnt.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ﾌﾟﾘﾝﾀ設定
    '********************************************************************
    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form51 As New F10_Form51
        F10_Form51.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  排他解除
    '********************************************************************
    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form52 As New F10_Form52
        F10_Form52.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ＴＳＳメニュー
    '********************************************************************
    Private Sub Button81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button81.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_TSS.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  旧MVARからデータ取込み
    '********************************************************************
    Private Sub Button82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button82.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_Ai.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  Ｑ＆Ａメニュー
    '********************************************************************
    Private Sub Button83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button83.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_QA.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  情報入力
    '********************************************************************
    Private Sub Button84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button84.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F10_Form84 As New F10_Form84
        F10_Form84.ShowDialog()
        Me.Show()
        DspSet()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  技術情報セット
    '********************************************************************
    Sub DspSet()
        Dsinfo.Clear()

        '情報
        SqlCmd1 = New SqlClient.SqlCommand("SELECT TOP (3) add_date, info FROM M60_info ORDER BY add_date DESC", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        r = DaList1.Fill(Dsinfo, "M60_info")
        DB_CLOSE()

        If r <> 0 Then
            DtView1 = New DataView(Dsinfo.Tables("M60_info"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                Select Case i
                    Case Is = 0
                        Edit11.Text = DtView1(i)("info")
                        Label12.Text = Format(CDate(DtView1(i)("add_date")), "yyyy/M/d")
                    Case Is = 1
                        Edit21.Text = DtView1(i)("info")
                        Label22.Text = Format(CDate(DtView1(i)("add_date")), "yyyy/M/d")
                    Case Is = 2
                        Edit31.Text = DtView1(i)("info")
                        Label32.Text = Format(CDate(DtView1(i)("add_date")), "yyyy/M/d")
                End Select
            Next
        End If

    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        Close()
    End Sub
End Class