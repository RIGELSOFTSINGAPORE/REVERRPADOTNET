Public Class Form6
    Inherits System.Windows.Forms.Form

    Dim Dataadp1 As New SqlClient.SqlDataAdapter
    Dim Dataadp2 As New SqlClient.SqlDataAdapter
    Dim Dataadp3 As New SqlClient.SqlDataAdapter
    Dim Dataadp4 As New SqlClient.SqlDataAdapter
    Dim Dataadp5 As New SqlClient.SqlDataAdapter
    Dim Dataadp6 As New SqlClient.SqlDataAdapter
    Dim Dataadp7 As New SqlClient.SqlDataAdapter
    Dim Dataadp8 As New SqlClient.SqlDataAdapter
    Dim Dataadp9 As New SqlClient.SqlDataAdapter
    Dim Dataadp10 As New SqlClient.SqlDataAdapter
    Dim Dataadp11 As New SqlClient.SqlDataAdapter
    Dim Dataset1 As New DataSet
    Dim Dttbl1, Dttbl11 As DataTable
    Dim r, r2, get_no, upd_no As Integer
    Dim clm_flg, fst_empl_code, ID, fin_flg, upd_flg, head_ltr As String
    Dim s_date, e_date As Date

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

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
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label3_4 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label3_3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox3_4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3_3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label3_2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3_2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3_1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3_1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3_5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label3_4 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label3_3 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.ComboBox3_4 = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.ComboBox3_3 = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label3_2 = New System.Windows.Forms.Label
        Me.ComboBox3_2 = New System.Windows.Forms.ComboBox
        Me.ComboBox3_1 = New System.Windows.Forms.ComboBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3_1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3_5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.DimGray
        Me.Label46.Location = New System.Drawing.Point(77, 113)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(100, 16)
        Me.Label46.TabIndex = 241
        Me.Label46.Text = "氏名"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3_4
        '
        Me.Label3_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_4.ForeColor = System.Drawing.Color.Black
        Me.Label3_4.Location = New System.Drawing.Point(189, 113)
        Me.Label3_4.Name = "Label3_4"
        Me.Label3_4.Size = New System.Drawing.Size(192, 16)
        Me.Label3_4.TabIndex = 240
        Me.Label3_4.Text = "Label3_4"
        Me.Label3_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.DimGray
        Me.Label45.Location = New System.Drawing.Point(629, 81)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(80, 16)
        Me.Label45.TabIndex = 239
        Me.Label45.Text = "受付担当"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3_3
        '
        Me.Label3_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_3.ForeColor = System.Drawing.Color.Black
        Me.Label3_3.Location = New System.Drawing.Point(717, 81)
        Me.Label3_3.Name = "Label3_3"
        Me.Label3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3_3.Size = New System.Drawing.Size(144, 16)
        Me.Label3_3.TabIndex = 238
        Me.Label3_3.Text = "Label3_3"
        Me.Label3_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox2
        '
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(605, 145)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.TabIndex = 237
        Me.CheckBox2.Text = "対応済み"
        '
        'ComboBox3_4
        '
        Me.ComboBox3_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3_4.Location = New System.Drawing.Point(181, 377)
        Me.ComboBox3_4.Name = "ComboBox3_4"
        Me.ComboBox3_4.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox3_4.TabIndex = 224
        Me.ComboBox3_4.Text = "ComboBox3_4"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Blue
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(77, 377)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 24)
        Me.Label25.TabIndex = 236
        Me.Label25.Text = "回答区分"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox3_3
        '
        Me.ComboBox3_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3_3.Location = New System.Drawing.Point(445, 145)
        Me.ComboBox3_3.Name = "ComboBox3_3"
        Me.ComboBox3_3.Size = New System.Drawing.Size(144, 24)
        Me.ComboBox3_3.TabIndex = 226
        Me.ComboBox3_3.Text = "ComboBox3_3"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Blue
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(341, 145)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 23)
        Me.Label24.TabIndex = 235
        Me.Label24.Text = "ステイタス"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DimGray
        Me.Label23.Location = New System.Drawing.Point(389, 81)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 16)
        Me.Label23.TabIndex = 234
        Me.Label23.Text = "受付番号"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3_2
        '
        Me.Label3_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_2.ForeColor = System.Drawing.Color.Black
        Me.Label3_2.Location = New System.Drawing.Point(477, 81)
        Me.Label3_2.Name = "Label3_2"
        Me.Label3_2.Size = New System.Drawing.Size(96, 16)
        Me.Label3_2.TabIndex = 233
        Me.Label3_2.Text = "Label3_2"
        Me.Label3_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox3_2
        '
        Me.ComboBox3_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3_2.Location = New System.Drawing.Point(181, 177)
        Me.ComboBox3_2.Name = "ComboBox3_2"
        Me.ComboBox3_2.Size = New System.Drawing.Size(144, 24)
        Me.ComboBox3_2.TabIndex = 221
        Me.ComboBox3_2.Text = "ComboBox3_2"
        '
        'ComboBox3_1
        '
        Me.ComboBox3_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3_1.Location = New System.Drawing.Point(181, 145)
        Me.ComboBox3_1.Name = "ComboBox3_1"
        Me.ComboBox3_1.Size = New System.Drawing.Size(144, 24)
        Me.ComboBox3_1.TabIndex = 220
        Me.ComboBox3_1.Text = "ComboBox3_1"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox2.Location = New System.Drawing.Point(101, 409)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(632, 128)
        Me.TextBox2.TabIndex = 225
        Me.TextBox2.Text = "TextBox2"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Blue
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(77, 409)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 128)
        Me.Label22.TabIndex = 232
        Me.Label22.Text = "回答内容"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox1.Location = New System.Drawing.Point(101, 209)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(632, 128)
        Me.TextBox1.TabIndex = 223
        Me.TextBox1.Text = "TextBox1"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Blue
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(77, 209)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 128)
        Me.Label21.TabIndex = 231
        Me.Label21.Text = "問合せ内容"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(349, 185)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 16)
        Me.CheckBox1.TabIndex = 222
        Me.CheckBox1.Text = "クレーム"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Blue
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(77, 177)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 23)
        Me.Label20.TabIndex = 230
        Me.Label20.Text = "問合せ区分"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Blue
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(77, 145)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 23)
        Me.Label19.TabIndex = 229
        Me.Label19.Text = "問合者区分"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(77, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 16)
        Me.Label12.TabIndex = 228
        Me.Label12.Text = "受付開始時刻"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3_1
        '
        Me.Label3_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_1.ForeColor = System.Drawing.Color.Black
        Me.Label3_1.Location = New System.Drawing.Point(189, 81)
        Me.Label3_1.Name = "Label3_1"
        Me.Label3_1.Size = New System.Drawing.Size(192, 16)
        Me.Label3_1.TabIndex = 227
        Me.Label3_1.Text = "Label3_1"
        Me.Label3_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(824, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 30)
        Me.Button2.TabIndex = 243
        Me.Button2.TabStop = False
        Me.Button2.Text = "履歴表示"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(824, 520)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 30)
        Me.Button1.TabIndex = 242
        Me.Button1.Text = "Button1"
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(824, 584)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(96, 30)
        Me.Button11.TabIndex = 244
        Me.Button11.Text = "戻　る"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(8, 568)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(920, 3)
        Me.PictureBox1.TabIndex = 245
        Me.PictureBox1.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Blue
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(336, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 28)
        Me.Label14.TabIndex = 246
        Me.Label14.Text = "その他の問合せ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(405, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "電話番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3_5
        '
        Me.Label3_5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3_5.ForeColor = System.Drawing.Color.Black
        Me.Label3_5.Location = New System.Drawing.Point(477, 112)
        Me.Label3_5.Name = "Label3_5"
        Me.Label3_5.Size = New System.Drawing.Size(192, 16)
        Me.Label3_5.TabIndex = 247
        Me.Label3_5.Text = "Label3_5"
        Me.Label3_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form6
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(938, 619)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3_5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label3_4)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label3_3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.ComboBox3_4)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.ComboBox3_3)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label3_2)
        Me.Controls.Add(Me.ComboBox3_2)
        Me.Controls.Add(Me.ComboBox3_1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3_1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form6"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warranty System"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        If pMode = "r" Then
            Call dsp_tag3_r()
        ElseIf pMode = "f" Then
            Call dsp_tag3_f()
        ElseIf pMode = "x" Then
            Call dsp_tag3_x()
        Else
            Call dsp_tag3_n()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'TAG3
        If CheckBox1.Checked = True Then
            clm_flg = "1"
        Else
            clm_flg = "0"
        End If

        If CheckBox2.Checked = True And ComboBox3_3.SelectedValue <> "004" Then
            fin_flg = "1"
        ElseIf CheckBox2.Checked = True And ComboBox3_3.SelectedValue = "004" Then
            fin_flg = "0"
        ElseIf CheckBox2.Checked = False And ComboBox3_3.SelectedValue <> "004" Then
            fin_flg = "0"
        ElseIf CheckBox2.Checked = False And ComboBox3_3.SelectedValue = "004" Then
            fin_flg = "1"
        End If

        Dim SqlInsertCommand As New SqlClient.SqlCommand

        If pMode = "r" Or pMode = "f" Then

            If RTrim(Dttbl1.Rows(0)("EMPL_CODE")) <> pEmpl_code And ComboBox3_3.SelectedValue = "004" Then
                MsgBox("ステイタスを「対応済み」にする権限がありません。" & vbCrLf & "「対応済み」をチェックしてください。", MsgBoxStyle.Exclamation, "Warranty System")
                ComboBox3_3.SelectedValue = Dttbl1.Rows(0)("STATUS")
                Exit Sub
            Else
            End If

            If LenB(TextBox1.Text) > 500 Then
                MessageBox.Show("問合せ内容が500バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf LenB(TextBox2.Text) > 500 Then
                MessageBox.Show("回答内容が500バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim SqlUpdateCommand As New SqlClient.SqlCommand
            SqlUpdateCommand.CommandText = "UPDATE Q_DATA SET CLM_FLG = '" & clm_flg & "', FIN_FLAG = '" & fin_flg & "', CUST_CLS = '" & ComboBox3_1.SelectedValue & "', Q_CLS = '" & ComboBox3_2.SelectedValue & "', ASKING = '" & TextBox1.Text & "', STATUS = '" & ComboBox3_3.SelectedValue & "' WHERE Q_NO = '" & pq_no & "'"
            SqlUpdateCommand.CommandType = CommandType.Text
            SqlUpdateCommand.Connection = cnsqlclient

            SqlInsertCommand.CommandText = "INSERT INTO Q_DTL(Q_NO, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS) " & _
                                            "VALUES ('" & Label3_2.Text & "', '" & s_date & "', '" & TextBox2.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "')"
            SqlInsertCommand.CommandType = CommandType.Text
            SqlInsertCommand.Connection = cnsqlclient

            Try
                DB_OPEN()
                SqlUpdateCommand.ExecuteNonQuery()
                SqlInsertCommand.ExecuteNonQuery()
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try
            MsgBox("対応ログを追加しました。", MsgBoxStyle.OKOnly, "Warranty System")
            Button1.Enabled = False
        Else
            If LenB(TextBox1.Text) > 500 Then
                MessageBox.Show("問合せ内容が500バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf LenB(TextBox2.Text) > 500 Then
                MessageBox.Show("回答内容が500バイトを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim SqlSelectCommand As New SqlClient.SqlCommand
            SqlSelectCommand.CommandText = "SELECT CNT, H_LTR FROM CNT_MTR WHERE CNT_NO = '002'"
            SqlSelectCommand.CommandType = CommandType.Text
            SqlSelectCommand.Connection = cnsqlclient
            Dataadp5.SelectCommand = SqlSelectCommand

            Dim Dataset5 As New DataSet

            DB_OPEN()
            Dataadp5.Fill(Dataset5, "CNT_MTR")
            DB_CLOSE()

            Dim Dttbl5 As DataTable
            Dttbl5 = Dataset5.Tables("CNT_MTR")
            get_no = Dttbl5.Rows(0)("CNT")
            head_ltr = Dttbl5.Rows(0)("H_LTR")

            If 4 - LenB(get_no) = 0 Then
                pq_no = head_ltr & Trim(Str(get_no))
            ElseIf 4 - LenB(get_no) = 1 Then
                pq_no = head_ltr & "0" & Trim(Str(get_no))
            ElseIf 4 - LenB(get_no) = 2 Then
                pq_no = head_ltr & "00" & Trim(Str(get_no))
            ElseIf 4 - LenB(get_no) = 3 Then
                pq_no = head_ltr & "000" & Trim(Str(get_no))
            End If

            SqlInsertCommand.CommandText = "INSERT INTO Q_DATA(Q_NO, Q_MTR_NO, CLM_FLG, FIN_FLAG, CUST_CLS, Q_CLS, ASKING, STATUS, EMPL_CODE) " & _
                                            "VALUES ('" & pq_no & "', '" & get_qmtr_no & "', '" & clm_flg & "', '" & fin_flg & "', '" & ComboBox3_1.SelectedValue & "', '" & ComboBox3_2.SelectedValue & "', '" & TextBox1.Text & "', '" & ComboBox3_3.SelectedValue & "', '" & pEmpl_code & "')"
            SqlInsertCommand.CommandType = CommandType.Text
            SqlInsertCommand.Connection = cnsqlclient

            Dim SqlInsertCommand2 As New SqlClient.SqlCommand
            SqlInsertCommand2.CommandText = "INSERT INTO Q_DTL(Q_NO, RCV_DATE, RPLY, EMPL_CODE, RPLY_CLS, END_DATE, STATUS)  " & _
                                            "VALUES ('" & pq_no & "', '" & s_date & "', '" & TextBox2.Text & "', '" & pEmpl_code & "', '" & ComboBox3_4.SelectedValue & "', '" & Now() & "', '" & ComboBox3_3.SelectedValue & "')"
            SqlInsertCommand2.CommandType = CommandType.Text
            SqlInsertCommand2.Connection = cnsqlclient

            Dim SqlUpdateCommand As New SqlClient.SqlCommand
            If get_no = 9999 And Asc(head_ltr) = 90 Then
                MessageBox.Show("管理番号エラー：システム管理者にお問い合わせください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            ElseIf get_no = 9999 And Asc(head_ltr) < 90 Then
                upd_no = 1
                SqlUpdateCommand.CommandText = "UPDATE CNT_MTR SET CNT = " & upd_no & ", H_LTR = '" & Chr(Asc(head_ltr) + 1) & "' WHERE CNT_NO = '002'"
                SqlUpdateCommand.CommandType = CommandType.Text
                SqlUpdateCommand.Connection = cnsqlclient
            Else
                upd_no = get_no + 1
                SqlUpdateCommand.CommandText = "UPDATE CNT_MTR SET CNT = " & upd_no & " WHERE CNT_NO = '002'"
                SqlUpdateCommand.CommandType = CommandType.Text
                SqlUpdateCommand.Connection = cnsqlclient
            End If

            Try
                DB_OPEN()
                SqlInsertCommand.ExecuteNonQuery()
                SqlInsertCommand2.ExecuteNonQuery()
                SqlUpdateCommand.ExecuteNonQuery()
                DB_CLOSE()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message)
                DB_CLOSE()
            End Try
            MsgBox("受付番号:" & pq_no & "で登録しました。", MsgBoxStyle.OKOnly, "Warranty System")
            Button1.Enabled = False
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        '対応履歴表示
        dsp_mode = "q"
        Me.Cursor.Current = Cursors.WaitCursor
        Dim frmform4 As New Form4
        frmform4.ShowDialog()
        Me.Cursor.Current = Cursors.Default

    End Sub

    Private Sub dsp_tag3_r()

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = pq_no
        Button1.Text = "追  加"

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        SqlSelectCommand.CommandText = "SELECT Q_DATA.CLM_FLG, Q_DATA.STATUS, Q_DATA.FIN_FLAG, Q_DATA.CUST_CLS, Q_DATA.Q_CLS, Q_DATA.ASKING, Q_DATA.EMPL_CODE, EMPL.EMPL_NAME, Q_MASTER.CUST_NAME, Q_MASTER.TEL_NO FROM Q_MASTER RIGHT OUTER JOIN Q_DATA ON Q_MASTER.Q_MTR_NO = Q_DATA.Q_MTR_NO LEFT OUTER JOIN EMPL ON Q_DATA.EMPL_CODE = EMPL.EMPL_CODE WHERE Q_NO = '" & pq_no & "'"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        Dataadp1.SelectCommand = SqlSelectCommand

        Try
            DB_OPEN()
            Dataadp1.Fill(Dataset1, "Q_DATA")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            DB_CLOSE()
        End Try

        Dttbl1 = Dataset1.Tables("Q_DATA")

        If RTrim(Dttbl1.Rows(0)("EMPL_CODE")) <> pEmpl_code Then
            CheckBox2.Visible = True
        Else
            CheckBox2.Visible = False
        End If

        If Dttbl1.Rows(0)("FIN_FLAG").ToString = "1" And RTrim(Dttbl1.Rows(0)("EMPL_CODE")) <> pEmpl_code And Dttbl1.Rows(0)("STATUS") <> "004" Then
            MsgBox("このインシデントは完了しています。", MsgBoxStyle.Information, "Warranty System")
            Exit Sub
        ElseIf Dttbl1.Rows(0)("FIN_FLAG").ToString = "1" And RTrim(Dttbl1.Rows(0)("EMPL_CODE")) = pEmpl_code And Dttbl1.Rows(0)("STATUS") <> "004" Then
            MsgBox("このインシデントは他のスタッフにより完了されました。" & vbCrLf & "ステイタスを変更してください。", MsgBoxStyle.Information, "Warranty System")
        End If

        If Dttbl1.Rows(0)("CLM_FLG").ToString = "1" Then
            CheckBox1.Checked = True
        End If
        fst_empl_code = RTrim(Dttbl1.Rows(0)("EMPL_CODE"))
        Label3_3.Text = Dttbl1.Rows(0)("EMPL_NAME")
        Label3_4.Text = Dttbl1.Rows(0)("CUST_NAME").ToString
        Label3_5.Text = Dttbl1.Rows(0)("TEL_NO").ToString
        TextBox1.Text = RTrim(Dttbl1.Rows(0)("ASKING"))
        TextBox2.Text = Nothing


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '003'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp2.SelectCommand = SqlSelectCommand

        Dim Dataset2 As New DataSet

        DB_OPEN()
        Dataadp2.Fill(Dataset2, "CUST_CLS")
        DB_CLOSE()

        ComboBox3_1.DataSource = Dataset2
        ComboBox3_1.DisplayMember = "CUST_CLS.NAME"
        ComboBox3_1.ValueMember = "CUST_CLS.CLS_CODE"
        ComboBox3_1.SelectedValue = Dttbl1.Rows(0)("CUST_CLS")


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '004'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp3.SelectCommand = SqlSelectCommand

        Dim Dataset3 As New DataSet

        DB_OPEN()
        Dataadp3.Fill(Dataset3, "ICDT_CLS")
        DB_CLOSE()

        ComboBox3_2.DataSource = Dataset3
        ComboBox3_2.DisplayMember = "ICDT_CLS.NAME"
        ComboBox3_2.ValueMember = "ICDT_CLS.CLS_CODE"
        ComboBox3_2.SelectedValue = Dttbl1.Rows(0)("Q_CLS")


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '001'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp4.SelectCommand = SqlSelectCommand

        Dim Dataset4 As New DataSet

        DB_OPEN()
        Dataadp4.Fill(Dataset4, "STS_CLS")
        DB_CLOSE()

        ComboBox3_3.DataSource = Dataset4
        ComboBox3_3.DisplayMember = "STS_CLS.NAME"
        ComboBox3_3.ValueMember = "STS_CLS.CLS_CODE"
        ComboBox3_3.SelectedValue = Dttbl1.Rows(0)("STATUS")


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '005'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp7.SelectCommand = SqlSelectCommand

        Dim Dataset5 As New DataSet

        DB_OPEN()
        Dataadp7.Fill(Dataset5, "STS_RPLY")
        DB_CLOSE()

        ComboBox3_4.DataSource = Dataset5
        ComboBox3_4.DisplayMember = "STS_RPLY.NAME"
        ComboBox3_4.ValueMember = "STS_RPLY.CLS_CODE"

    End Sub

    Private Sub dsp_tag3_f()

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = pq_no
        Button1.Text = "完  了"

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        SqlSelectCommand.CommandText = "SELECT Q_DATA.CLM_FLG, Q_DATA.STATUS, Q_DATA.FIN_FLAG, Q_DATA.CUST_CLS, Q_DATA.Q_CLS, Q_DATA.ASKING, Q_DATA.EMPL_CODE, EMPL.EMPL_NAME, Q_MASTER.CUST_NAME, Q_MASTER.TEL_NO FROM Q_MASTER RIGHT OUTER JOIN Q_DATA ON Q_MASTER.Q_MTR_NO = Q_DATA.Q_MTR_NO LEFT OUTER JOIN EMPL ON Q_DATA.EMPL_CODE = EMPL.EMPL_CODE WHERE Q_NO = '" & pq_no & "'"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        Dataadp1.SelectCommand = SqlSelectCommand

        Try
            DB_OPEN()
            Dataadp1.Fill(Dataset1, "Q_DATA")
            DB_CLOSE()
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
            DB_CLOSE()
        End Try

        Dttbl1 = Dataset1.Tables("Q_DATA")

        MsgBox("このインシデントは他のスタッフにより完了されました。" & vbCrLf & "内容を確認後、ステイタスを変更してください。", MsgBoxStyle.Information, "Warranty System")

        If Dttbl1.Rows(0)("CLM_FLG").ToString = "1" Then
            CheckBox1.Checked = True
        End If
        fst_empl_code = RTrim(Dttbl1.Rows(0)("EMPL_CODE"))
        Label3_3.Text = Dttbl1.Rows(0)("EMPL_NAME")
        Label3_4.Text = Dttbl1.Rows(0)("CUST_NAME").ToString
        Label3_5.Text = Dttbl1.Rows(0)("TEL_NO").ToString
        TextBox1.Text = RTrim(Dttbl1.Rows(0)("ASKING"))
        TextBox2.Text = Nothing
        CheckBox2.Visible = False

        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '003'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp2.SelectCommand = SqlSelectCommand

        Dim Dataset2 As New DataSet

        DB_OPEN()
        Dataadp2.Fill(Dataset2, "CUST_CLS")
        DB_CLOSE()

        ComboBox3_1.DataSource = Dataset2
        ComboBox3_1.DisplayMember = "CUST_CLS.NAME"
        ComboBox3_1.ValueMember = "CUST_CLS.CLS_CODE"
        ComboBox3_1.SelectedValue = Dttbl1.Rows(0)("CUST_CLS")


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '004'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp3.SelectCommand = SqlSelectCommand

        Dim Dataset3 As New DataSet

        DB_OPEN()
        Dataadp3.Fill(Dataset3, "ICDT_CLS")
        DB_CLOSE()

        ComboBox3_2.DataSource = Dataset3
        ComboBox3_2.DisplayMember = "ICDT_CLS.NAME"
        ComboBox3_2.ValueMember = "ICDT_CLS.CLS_CODE"
        ComboBox3_2.SelectedValue = Dttbl1.Rows(0)("Q_CLS")


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '001'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp4.SelectCommand = SqlSelectCommand

        Dim Dataset4 As New DataSet

        DB_OPEN()
        Dataadp4.Fill(Dataset4, "STS_CLS")
        DB_CLOSE()

        ComboBox3_3.DataSource = Dataset4
        ComboBox3_3.DisplayMember = "STS_CLS.NAME"
        ComboBox3_3.ValueMember = "STS_CLS.CLS_CODE"
        ComboBox3_3.SelectedValue = "004"
        ComboBox3_3.Enabled = False

        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '005'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp7.SelectCommand = SqlSelectCommand

        Dim Dataset5 As New DataSet

        DB_OPEN()
        Dataadp7.Fill(Dataset5, "STS_RPLY")
        DB_CLOSE()

        ComboBox3_4.DataSource = Dataset5
        ComboBox3_4.DisplayMember = "STS_RPLY.NAME"
        ComboBox3_4.ValueMember = "STS_RPLY.CLS_CODE"

    End Sub

    Private Sub dsp_tag3_x()

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = pq_no
        Button1.Text = "完  了"
        Button1.Enabled = False

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        SqlSelectCommand.CommandText = "SELECT Q_DATA.CLM_FLG, Q_DATA.STATUS, Q_DATA.FIN_FLAG, Q_DATA.CUST_CLS, Q_DATA.Q_CLS, Q_DATA.ASKING, Q_DATA.EMPL_CODE, EMPL.EMPL_NAME, Q_MASTER.CUST_NAME, Q_MASTER.TEL_NO FROM Q_MASTER RIGHT OUTER JOIN Q_DATA ON Q_MASTER.Q_MTR_NO = Q_DATA.Q_MTR_NO LEFT OUTER JOIN EMPL ON Q_DATA.EMPL_CODE = EMPL.EMPL_CODE WHERE Q_NO = '" & pq_no & "'"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        Dataadp1.SelectCommand = SqlSelectCommand

        DB_OPEN()
        Dataadp1.Fill(Dataset1, "Q_DATA")
        DB_CLOSE()

        Dttbl1 = Dataset1.Tables("Q_DATA")

        If Dttbl1.Rows(0)("CLM_FLG").ToString = "1" Then
            CheckBox1.Checked = True
        End If
        CheckBox1.Enabled = False

        fst_empl_code = RTrim(Dttbl1.Rows(0)("EMPL_CODE"))
        Label3_3.Text = Dttbl1.Rows(0)("EMPL_NAME")
        Label3_4.Text = Dttbl1.Rows(0)("CUST_NAME").ToString
        Label3_5.Text = Dttbl1.Rows(0)("TEL_NO").ToString
        TextBox1.Text = RTrim(Dttbl1.Rows(0)("ASKING"))
        TextBox2.Text = Nothing
        CheckBox2.Visible = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False

        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '003'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp2.SelectCommand = SqlSelectCommand

        Dim Dataset2 As New DataSet

        DB_OPEN()
        Dataadp2.Fill(Dataset2, "CUST_CLS")
        DB_CLOSE()

        ComboBox3_1.DataSource = Dataset2
        ComboBox3_1.DisplayMember = "CUST_CLS.NAME"
        ComboBox3_1.ValueMember = "CUST_CLS.CLS_CODE"
        ComboBox3_1.SelectedValue = Dttbl1.Rows(0)("CUST_CLS")
        ComboBox3_1.Enabled = False

        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '004'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp3.SelectCommand = SqlSelectCommand

        Dim Dataset3 As New DataSet

        DB_OPEN()
        Dataadp3.Fill(Dataset3, "ICDT_CLS")
        DB_CLOSE()

        ComboBox3_2.DataSource = Dataset3
        ComboBox3_2.DisplayMember = "ICDT_CLS.NAME"
        ComboBox3_2.ValueMember = "ICDT_CLS.CLS_CODE"
        ComboBox3_2.SelectedValue = Dttbl1.Rows(0)("Q_CLS")
        ComboBox3_2.Enabled = False

        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '001'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp4.SelectCommand = SqlSelectCommand

        Dim Dataset4 As New DataSet

        DB_OPEN()
        Dataadp4.Fill(Dataset4, "STS_CLS")
        DB_CLOSE()

        ComboBox3_3.DataSource = Dataset4
        ComboBox3_3.DisplayMember = "STS_CLS.NAME"
        ComboBox3_3.ValueMember = "STS_CLS.CLS_CODE"
        ComboBox3_3.SelectedValue = "004"
        ComboBox3_3.Enabled = False

        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '005'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp7.SelectCommand = SqlSelectCommand

        Dim Dataset5 As New DataSet

        DB_OPEN()
        Dataadp7.Fill(Dataset5, "STS_RPLY")
        DB_CLOSE()

        ComboBox3_4.DataSource = Dataset5
        ComboBox3_4.DisplayMember = "STS_RPLY.NAME"
        ComboBox3_4.ValueMember = "STS_RPLY.CLS_CODE"
        ComboBox3_4.Enabled = False

    End Sub

    Private Sub dsp_tag3_n()

        Label3_1.Text = Format(Now(), "yyyy/MM/dd HH:mm")
        s_date = Now()
        Label3_2.Text = Nothing
        Label3_3.Text = Nothing
        Label3_4.Text = p_qName
        Label3_5.Text = p_qTel_no
        Button1.Text = "登  録"

        Dim SqlSelectCommand As New SqlClient.SqlCommand

        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        CheckBox1.Checked = False
        CheckBox2.Visible = False

        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '003'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp2.SelectCommand = SqlSelectCommand

        Dim Dataset2 As New DataSet

        DB_OPEN()
        Dataadp2.Fill(Dataset2, "CUST_CLS")
        DB_CLOSE()

        ComboBox3_1.DataSource = Dataset2
        ComboBox3_1.DisplayMember = "CUST_CLS.NAME"
        ComboBox3_1.ValueMember = "CUST_CLS.CLS_CODE"


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '004'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp3.SelectCommand = SqlSelectCommand

        Dim Dataset3 As New DataSet

        DB_OPEN()
        Dataadp3.Fill(Dataset3, "ICDT_CLS")
        DB_CLOSE()

        ComboBox3_2.DataSource = Dataset3
        ComboBox3_2.DisplayMember = "ICDT_CLS.NAME"
        ComboBox3_2.ValueMember = "ICDT_CLS.CLS_CODE"


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '001'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp4.SelectCommand = SqlSelectCommand

        Dim Dataset4 As New DataSet

        DB_OPEN()
        Dataadp4.Fill(Dataset4, "STS_CLS")
        DB_CLOSE()

        ComboBox3_3.DataSource = Dataset4
        ComboBox3_3.DisplayMember = "STS_CLS.NAME"
        ComboBox3_3.ValueMember = "STS_CLS.CLS_CODE"


        SqlSelectCommand = New SqlClient.SqlCommand("SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS NAME FROM CLS_CODE WHERE CLS_NO = '005'", cnsqlclient)
        SqlSelectCommand.CommandType = CommandType.Text
        Dataadp7.SelectCommand = SqlSelectCommand

        Dim Dataset5 As New DataSet

        DB_OPEN()
        Dataadp7.Fill(Dataset5, "STS_RPLY")
        DB_CLOSE()

        ComboBox3_4.DataSource = Dataset5
        ComboBox3_4.DisplayMember = "STS_RPLY.NAME"
        ComboBox3_4.ValueMember = "STS_RPLY.CLS_CODE"

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dataset1.Clear()
        Me.Close()
    End Sub
End Class
