Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
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
    Friend WithEvents MSG As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit4 As GrapeCity.Win.Input.Edit
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.MSG = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Edit2 = New GrapeCity.Win.Input.Edit
        Me.Edit3 = New GrapeCity.Win.Input.Edit
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Edit4 = New GrapeCity.Win.Input.Edit
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MSG
        '
        Me.MSG.ForeColor = System.Drawing.Color.Red
        Me.MSG.Location = New System.Drawing.Point(16, 312)
        Me.MSG.Name = "MSG"
        Me.MSG.Size = New System.Drawing.Size(664, 24)
        Me.MSG.TabIndex = 981
        Me.MSG.Text = "MSG"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 982
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(576, 336)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 983
        Me.Button98.Text = "戻る"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 72)
        Me.Label2.TabIndex = 984
        Me.Label2.Text = "品種コード"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.AllowSpace = False
        Me.Edit1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit1.Format = "9#"
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit1.Location = New System.Drawing.Point(224, 48)
        Me.Edit1.MaxLength = 4
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(48, 25)
        Me.Edit1.TabIndex = 10
        Me.Edit1.Text = "99"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(16, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 985
        Me.Label1.Text = "品種名（ｶﾅ）"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(16, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 24)
        Me.Label3.TabIndex = 986
        Me.Label3.Text = "品種名（漢字）"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label5.Location = New System.Drawing.Point(16, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 24)
        Me.Label5.TabIndex = 988
        Me.Label5.Text = "保証対象"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.AutoSize = False
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.TextBox1.Location = New System.Drawing.Point(144, 136)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(352, 24)
        Me.TextBox1.TabIndex = 40
        Me.TextBox1.Text = "TextBox1"
        '
        'TextBox2
        '
        Me.TextBox2.AutoSize = False
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TextBox2.Location = New System.Drawing.Point(144, 168)
        Me.TextBox2.MaxLength = 30
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(352, 24)
        Me.TextBox2.TabIndex = 50
        Me.TextBox2.Text = "TextBox2"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Location = New System.Drawing.Point(200, 200)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 24)
        Me.Label17.TabIndex = 1001
        Me.Label17.Text = "Label17"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(160, 200)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(40, 24)
        Me.CheckBox1.TabIndex = 60
        '
        'Edit2
        '
        Me.Edit2.AllowSpace = False
        Me.Edit2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit2.Format = "9#"
        Me.Edit2.HighlightText = True
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit2.Location = New System.Drawing.Point(224, 72)
        Me.Edit2.MaxLength = 2
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(32, 25)
        Me.Edit2.TabIndex = 20
        Me.Edit2.Text = "99"
        '
        'Edit3
        '
        Me.Edit3.AllowSpace = False
        Me.Edit3.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit3.Format = "9#"
        Me.Edit3.HighlightText = True
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit3.Location = New System.Drawing.Point(224, 96)
        Me.Edit3.MaxLength = 2
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(32, 25)
        Me.Edit3.TabIndex = 30
        Me.Edit3.Text = "99"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label4.Location = New System.Drawing.Point(152, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 24)
        Me.Label4.TabIndex = 1003
        Me.Label4.Text = "大分類"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label6.Location = New System.Drawing.Point(152, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 24)
        Me.Label6.TabIndex = 1004
        Me.Label6.Text = "中分類"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkBlue
        Me.Label7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label7.Location = New System.Drawing.Point(152, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 24)
        Me.Label7.TabIndex = 1005
        Me.Label7.Text = "小分類"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkBlue
        Me.Label8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label8.Location = New System.Drawing.Point(16, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 24)
        Me.Label8.TabIndex = 1007
        Me.Label8.Text = "保証期間"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit4
        '
        Me.Edit4.AllowSpace = False
        Me.Edit4.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit4.Format = "9#"
        Me.Edit4.HighlightText = True
        Me.Edit4.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit4.Location = New System.Drawing.Point(144, 232)
        Me.Edit4.MaxLength = 3
        Me.Edit4.Name = "Edit4"
        Me.Edit4.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit4.Size = New System.Drawing.Size(32, 25)
        Me.Edit4.TabIndex = 70
        Me.Edit4.Text = "99"
        Me.Edit4.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Right
        '
        'TextBox3
        '
        Me.TextBox3.AutoSize = False
        Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox3.Location = New System.Drawing.Point(144, 272)
        Me.TextBox3.MaxLength = 1
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(32, 24)
        Me.TextBox3.TabIndex = 80
        Me.TextBox3.Text = "TextBox3"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkBlue
        Me.Label9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label9.Location = New System.Drawing.Point(16, 272)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 24)
        Me.Label9.TabIndex = 1009
        Me.Label9.Text = "グループ"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(576, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 24)
        Me.Label10.TabIndex = 1011
        Me.Label10.Text = "Label10"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label11.Location = New System.Drawing.Point(496, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 24)
        Me.Label11.TabIndex = 1010
        Me.Label11.Text = "登録日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label19.Location = New System.Drawing.Point(272, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 24)
        Me.Label19.TabIndex = 1014
        Me.Label19.Text = "Label19"
        Me.Label19.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(144, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 24)
        Me.Label16.TabIndex = 1013
        Me.Label16.Text = "Label16"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(16, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 24)
        Me.Label18.TabIndex = 1012
        Me.Label18.Text = "システム区分"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(690, 375)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Edit4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MSG)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "品種ﾏｽﾀﾒﾝﾃﾅﾝｽ"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MSG.Text = Nothing
        Edit1.Text = P_cd1
        Edit2.Text = P_cd2
        Edit3.Text = P_cd3
        Label19.Text = P_BY_cls
        If P_BY_cls = "B" Then Label16.Text = "ベスト" Else Label16.Text = "ヤマダ"
        Call DspSet()

    End Sub

    Sub DspSet()
        If P_cd1 = Nothing Then   '登録
            Button1.Text = "登録"
            Label10.Text = Nothing
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            CheckBox1.Checked = False
            Label17.Text = Nothing
            Edit4.Text = "0"
            TextBox3.Text = Nothing
        Else                            '修正
            Edit1.Enabled = False
            Edit2.Enabled = False
            Edit3.Enabled = False
            DtView1 = New DataView(P_DsList1.Tables("Cat_mtr"), "cd1='" & Edit1.Text & "' AND cd2='" & Edit2.Text & "' AND cd3='" & Edit3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Label10.Text = DtView1(0)("crt_date")
                TextBox1.Text = Trim(DtView1(0)("品種名(ｶﾅ)"))
                TextBox2.Text = Trim(DtView1(0)("品種名(漢字)"))
                If IsDBNull(DtView1(0)("avlbty")) Then
                    CheckBox1.Checked = False
                    Label17.Text = Nothing
                Else
                    CheckBox1.Checked = True
                    Label17.Text = "対象"
                End If
                Edit4.Text = DtView1(0)("wrn_prod")
                If Not IsDBNull(DtView1(0)("GRP")) Then
                    TextBox3.Text = DtView1(0)("GRP")
                Else
                    TextBox3.Text = Nothing
                End If
            End If
        End If
    End Sub

    '入力後
    Private Sub Edit1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.Leave
        MSG.Text = Nothing
        Call Edit1_chk()
    End Sub

    Private Sub Edit2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit2.Leave
        MSG.Text = Nothing
        Call Edit2_chk()
    End Sub

    Private Sub Edit3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.Leave
        MSG.Text = Nothing
        Call Edit3_chk()
    End Sub

    Private Sub Edit4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit4.Leave
        MSG.Text = Nothing
        Call Edit4_chk()
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        MSG.Text = Nothing
        Call TextBox1_chk()
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        MSG.Text = Nothing
        Call TextBox2_chk()
    End Sub

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Leave
        MSG.Text = Nothing
        Call TextBox3_chk()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            Label17.Text = Nothing
            'Edit4.Text = "0"
            'TextBox3.Text = Nothing
        Else
            Label17.Text = "対象"
        End If
    End Sub

    Sub Edit1_chk()
        If Trim(Edit1.Text) = Nothing Then
            MSG.Text = "品種コードは入力必須です。"
            Err_F = "1"
        Else
            DtView1 = New DataView(P_DsList1.Tables("Cat_mtr"), "BY_cls ='" & Label19.Text & "' AND cd1='" & Edit1.Text & "' AND cd2='" & Edit2.Text & "' AND cd3='" & Edit3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                MSG.Text = "品種コードは既に登録されています。"
                Err_F = "1"
            End If
        End If
    End Sub

    Sub Edit2_chk()
        If Trim(Edit2.Text) = Nothing Then
            MSG.Text = "品種コードは入力必須です。"
            Err_F = "1"
        Else
            DtView1 = New DataView(P_DsList1.Tables("Cat_mtr"), "BY_cls ='" & Label19.Text & "' AND cd1='" & Edit1.Text & "' AND cd2='" & Edit2.Text & "' AND cd3='" & Edit3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                MSG.Text = "品種コードは既に登録されています。"
                Err_F = "1"
            End If
        End If
    End Sub

    Sub Edit3_chk()
        If Trim(Edit3.Text) = Nothing Then
            MSG.Text = "品種コードは入力必須です。"
            Err_F = "1"
        Else
            DtView1 = New DataView(P_DsList1.Tables("Cat_mtr"), "BY_cls ='" & Label19.Text & "' AND cd1='" & Edit1.Text & "' AND cd2='" & Edit2.Text & "' AND cd3='" & Edit3.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                MSG.Text = "品種コードは既に登録されています。"
                Err_F = "1"
            End If
        End If
    End Sub

    Sub Edit4_chk()
        If CheckBox1.Checked = True Then
            If Edit4.Text = Nothing Then
                MSG.Text = "保証期間は入力必須です。"
                Err_F = "1"
            Else
                If Edit4.Text = "36" Or Edit4.Text = "60" Or Edit4.Text = "120" Then
                Else
                    MSG.Text = "保証期間は'36','60','120'のいずれかで入力してください。"
                    Err_F = "1"
                End If
            End If
            'Else
            '    Edit4.Text = "0"
        End If
    End Sub

    Sub key_chk()
        If Edit3.Text <> "00" Then
            DtView1 = New DataView(P_DsList1.Tables("Cat_mtr"), "cd1='" & Edit1.Text & "' AND cd2='" & Edit2.Text & "' AND cd3='00'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                MSG.Text = "小分類='00'の登録がありません。"
                Err_F = "1"
            End If
        End If
    End Sub

    Sub TextBox1_chk()
        If Trim(TextBox1.Text) = Nothing Then
            MSG.Text = "品種名（ｶﾅ）は入力必須です。"
            Err_F = "1"
        End If
    End Sub

    Sub TextBox2_chk()
        If Trim(TextBox2.Text) = Nothing Then
            MSG.Text = "品種名（漢字）は入力必須です。"
            Err_F = "1"
        End If
    End Sub

    Sub TextBox3_chk()
        TextBox3.Text = TextBox3.Text.ToUpper
        If CheckBox1.Checked = True Then
            If TextBox3.Text = Nothing Then
                MSG.Text = "グループは入力必須です。"
                Err_F = "1"
            Else
                If TextBox3.Text = "A" Or TextBox3.Text = "B" Or TextBox3.Text = "C" Then
                Else
                    MSG.Text = "グループは'A','B','C'のいずれかで入力してください。"
                    Err_F = "1"
                End If
            End If
            'Else
            '    TextBox3.Text = Nothing
        End If
    End Sub

    Sub F_Check()
        Err_F = "0"
        If P_cd1 = Nothing Then   '登録
            Call Edit1_chk()
            If Err_F = "1" Then Edit1.Focus() : Exit Sub
            Call Edit2_chk()
            If Err_F = "1" Then Edit2.Focus() : Exit Sub
            Call Edit3_chk()
            If Err_F = "1" Then Edit3.Focus() : Exit Sub
            Call key_chk()
            If Err_F = "1" Then Edit3.Focus() : Exit Sub
        End If
        Call TextBox1_chk()
        If Err_F = "1" Then TextBox1.Focus() : Exit Sub
        Call TextBox2_chk()
        If Err_F = "1" Then TextBox2.Focus() : Exit Sub
        Call Edit4_chk()
        If Err_F = "1" Then Edit4.Focus() : Exit Sub
        Call TextBox3_chk()
        If Err_F = "1" Then TextBox3.Focus() : Exit Sub
    End Sub

    '更新ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_Check()
        If Err_F = "1" Then
            Beep()
        Else
            If P_cd1 = Nothing Then   '登録
                Label10.Text = Now.Date
                strSQL = "INSERT INTO Cat_mtr"
                strSQL = strSQL & " (BY_cls, cd1, cd2, cd3, [品種名(ｶﾅ)], [品種名(漢字)], avlbty, cd12, wrn_prod, GRP, crt_date)"
                strSQL = strSQL & " VALUES ('" & Label19.Text & "'"
                strSQL = strSQL & ", '" & Edit1.Text & "'"
                strSQL = strSQL & ", '" & Edit2.Text & "'"
                strSQL = strSQL & ", '" & Edit3.Text & "'"
                strSQL = strSQL & ", N'" & TextBox1.Text & "'"
                strSQL = strSQL & ", N'" & TextBox2.Text & "'"
                If CheckBox1.Checked = True Then
                    strSQL = strSQL & ", N'対象'"
                Else
                    strSQL = strSQL & ", NULL"
                End If
                strSQL = strSQL & ", '" & Edit1.Text & Edit2.Text & "'"
                strSQL = strSQL & ", '" & Edit4.Text & "'"
                If TextBox3.Text = Nothing Then
                    strSQL = strSQL & ", NULL"
                Else
                    strSQL = strSQL & ", '" & TextBox3.Text & "'"
                End If
                strSQL = strSQL & ", '" & Now.Date & "')"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                MsgBox("登録しました", , "")
            Else                            '修正
                strSQL = "UPDATE Cat_mtr"
                strSQL = strSQL & " SET [品種名(ｶﾅ)] = N'" & TextBox1.Text & "'"
                strSQL = strSQL & ", [品種名(漢字)] = N'" & TextBox2.Text & "'"
                If CheckBox1.Checked = True Then
                    strSQL = strSQL & ", avlbty = N'対象'"
                Else
                    strSQL = strSQL & ", avlbty = NULL"
                End If
                strSQL = strSQL & ", wrn_prod = '" & Edit4.Text & "'"
                If TextBox3.Text = Nothing Then
                    strSQL = strSQL & ", GRP = NULL"
                Else
                    strSQL = strSQL & ", GRP = '" & TextBox3.Text & "'"
                End If
                strSQL = strSQL & " WHERE (BY_cls = '" & Label19.Text & "')"
                strSQL = strSQL & " AND (cd1 = '" & Edit1.Text & "')"
                strSQL = strSQL & " AND (cd2 = '" & Edit2.Text & "')"
                strSQL = strSQL & " AND (cd3 = '" & Edit3.Text & "')"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                MsgBox("修正しました", , "")
            End If
            P_Rtn = "1"
            Me.Close()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '戻るボタン
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_Rtn = "0"
        Me.Close()
    End Sub
End Class
