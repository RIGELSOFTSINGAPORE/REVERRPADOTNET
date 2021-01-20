Public Class Form3
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsCMB As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F As String

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
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Button97 As System.Windows.Forms.Button
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form3))
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button97 = New System.Windows.Forms.Button
        Me.Label66 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.DarkBlue
        Me.Label68.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label68.Location = New System.Drawing.Point(16, 216)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(104, 24)
        Me.Label68.TabIndex = 1085
        Me.Label68.Text = "連絡事項"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.DarkBlue
        Me.Label67.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label67.Location = New System.Drawing.Point(16, 128)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(104, 24)
        Me.Label67.TabIndex = 1084
        Me.Label67.Text = "修理内容"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(120, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 24)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Button97
        '
        Me.Button97.BackColor = System.Drawing.Color.Silver
        Me.Button97.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button97.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Button97.Location = New System.Drawing.Point(352, 304)
        Me.Button97.Name = "Button97"
        Me.Button97.Size = New System.Drawing.Size(104, 32)
        Me.Button97.TabIndex = 4
        Me.Button97.Text = "戻る"
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.DarkBlue
        Me.Label66.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label66.Location = New System.Drawing.Point(16, 16)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(104, 24)
        Me.Label66.TabIndex = 1082
        Me.Label66.Text = "故障状況"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox3
        '
        Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox3.Location = New System.Drawing.Point(120, 216)
        Me.TextBox3.MaxLength = 256
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(336, 80)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = "TextBox3"
        '
        'TextBox2
        '
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox2.Location = New System.Drawing.Point(120, 128)
        Me.TextBox2.MaxLength = 256
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(336, 80)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "TextBox2"
        '
        'TextBox1
        '
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox1.Location = New System.Drawing.Point(120, 40)
        Me.TextBox1.MaxLength = 256
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(336, 80)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.ClientSize = New System.Drawing.Size(470, 347)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Button97)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label67)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "故障状況入力"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '** 起動時
    '**********************************
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        CmbSet()

        If P_trbl_code <> Nothing Then
            ComboBox1.SelectedValue = P_trbl_code
        Else
            ComboBox1.Text = Nothing
        End If
        TextBox1.Text = P_trbl_memo
        TextBox2.Text = P_rpar_mome
        TextBox3.Text = P_Remarks

    End Sub

    '**********************************
    '** ComboBox
    '**********************************
    Sub CmbSet()
        DB_OPEN("best_wrn")

        '故障状況
        strSQL = "SELECT CLS_CODE, RTRIM(CLS_CODE) + ' : ' + RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME"
        strSQL +=  " FROM CLS_CODE"
        strSQL +=  " WHERE (CLS_NO = '009')"
        strSQL +=  " ORDER BY CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_009")

        ComboBox1.DataSource = DsCMB.Tables("CLS_CODE_009")
        ComboBox1.DisplayMember = "CLS_CODE_NAME"
        ComboBox1.ValueMember = "CLS_CODE"

        DB_CLOSE()
    End Sub

    Sub DspChk3()
        Err_F = "0"

        '故障状況チェック
        If Trim(ComboBox1.Text) <> Nothing Then
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_009"), "CLS_CODE='" & ComboBox1.SelectedValue & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MsgBox("故障状況エラー", MsgBoxStyle.Critical, "Error")
                ComboBox1.Focus()
                Err_F = "1" : Exit Sub
            End If
        End If

    End Sub

    Private Sub Button97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button97.Click
        DspChk3()
        If Err_F = "0" Then
            P_trbl_code = ComboBox1.SelectedValue
            P_trbl_memo = Trim(TextBox1.Text)
            P_rpar_mome = Trim(TextBox2.Text)
            P_Remarks = Trim(TextBox3.Text)

            DsCMB.Clear()
            Close()
        End If
    End Sub
End Class
