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
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.MSG = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MSG
        '
        Me.MSG.ForeColor = System.Drawing.Color.Red
        Me.MSG.Location = New System.Drawing.Point(16, 224)
        Me.MSG.Name = "MSG"
        Me.MSG.Size = New System.Drawing.Size(664, 24)
        Me.MSG.TabIndex = 981
        Me.MSG.Text = "MSG"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 248)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 982
        Me.Button1.Text = "更新"

        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(576, 248)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 983
        Me.Button98.Text = "戻る"
        'Me.Button98.Text = "Return"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 984
        Me.Label2.Text = "メーカーコード"

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
        Me.Edit1.Location = New System.Drawing.Point(144, 48)
        Me.Edit1.MaxLength = 5
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(48, 25)
        Me.Edit1.TabIndex = 10
        Me.Edit1.Text = "9999"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(16, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 24)
        Me.Label1.TabIndex = 985
        Me.Label1.Text = "メーカー名（ｶﾅ）"

        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(16, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 24)
        Me.Label3.TabIndex = 986
        Me.Label3.Text = "メーカー名（漢字）"

        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.AutoSize = False
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.TextBox1.Location = New System.Drawing.Point(152, 96)
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
        Me.TextBox2.Location = New System.Drawing.Point(152, 128)
        Me.TextBox2.MaxLength = 30
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(352, 24)
        Me.TextBox2.TabIndex = 50
        Me.TextBox2.Text = "TextBox2"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label19.Location = New System.Drawing.Point(272, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 24)
        Me.Label19.TabIndex = 1008
        Me.Label19.Text = "Label19"
        Me.Label19.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(152, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 24)
        Me.Label16.TabIndex = 1007
        Me.Label16.Text = "Label16"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(16, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 24)
        Me.Label18.TabIndex = 1006
        Me.Label18.Text = "システム区分"

        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(690, 295)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
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
        Me.Text = "ﾒｰｶｰﾏｽﾀﾒﾝﾃﾅﾝｽ"

        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MSG.Text = Nothing
        Edit1.Text = P_vdr_code
        Label19.Text = P_BY_cls
        If P_BY_cls = "B" Then Label16.Text = "ベスト" Else Label16.Text = "ヤマダ"
        Call DspSet()
    End Sub

    Sub DspSet()
        If P_vdr_code = Nothing Then   '登録
            Button1.Text = "登録"
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
        Else                            '修正
            Edit1.Enabled = False
            DtView1 = New DataView(P_DsList1.Tables("vdr_mtr"), "vdr_code='" & Edit1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                TextBox1.Text = Trim(DtView1(0)("vdr_kana"))
                TextBox2.Text = Trim(DtView1(0)("vdr_name"))
            End If
        End If
    End Sub

    '入力後
    Private Sub Edit1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.Leave
        MSG.Text = Nothing
        Call Edit1_chk()
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        MSG.Text = Nothing
        Call TextBox1_chk()
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        MSG.Text = Nothing
        Call TextBox2_chk()
    End Sub

    Sub Edit1_chk()
        If Trim(Edit1.Text) = Nothing Then
            MSG.Text = "メーカーコードは入力必須です。"
            Err_F = "1"
        Else
            'DtView1 = New DataView(P_DsList1.Tables("vdr_mtr"), "BY_cls ='" & Label19.Text & "' AND vdr_code='" & Edit1.Text & "'", "", DataViewRowState.CurrentRows)
            DtView1 = New DataView(P_DsList1.Tables("vdr_mtr"), " vdr_code='" & Edit1.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                MSG.Text = "メーカーコードは既に登録されています。"
                Err_F = "1"
            End If
        End If
    End Sub

    Sub TextBox1_chk()
        If Trim(TextBox1.Text) = Nothing Then
            MSG.Text = "メーカー名（ｶﾅ）は入力必須です。"
            'MSG.Text = "The manufacturer name (Kana) is required to be entered."
            Err_F = "1"
        End If
    End Sub

    Sub TextBox2_chk()
        If Trim(TextBox2.Text) = Nothing Then
            MSG.Text = "メーカー名（漢字）は入力必須です。"
            'MSG.Text = "The manufacturer name (kanji) is required."
            Err_F = "1"
        End If
    End Sub

    Sub F_Check()
        Err_F = "0"
        If P_vdr_code = Nothing Then   '登録
            Call Edit1_chk()
            If Err_F = "1" Then Edit1.Focus() : Exit Sub
        End If
        Call TextBox1_chk()
        If Err_F = "1" Then TextBox1.Focus() : Exit Sub
        Call TextBox2_chk()
        If Err_F = "1" Then TextBox2.Focus() : Exit Sub
    End Sub

    '更新ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_Check()
        If Err_F = "1" Then
            Beep()
        Else
            If P_vdr_code = Nothing Then   '登録
                strSQL = "INSERT INTO vdr_mtr"
                strSQL = strSQL & " (BY_cls, vdr_code, vdr_kana, vdr_name)"
                'strSQL = strSQL & " ( vdr_code, vdr_kana, vdr_name)"
                strSQL = strSQL & " VALUES ('" & Label19.Text & "'"
                'strSQL = strSQL & " VALUES ('" & Edit1.Text & "'"
                strSQL = strSQL & ", '" & Edit1.Text & "'"
                strSQL = strSQL & ", N'" & TextBox1.Text & "'"
                strSQL = strSQL & ", N'" & TextBox2.Text & "')"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                MsgBox("登録しました", , "")
                'MsgBox("Has registered", , "")

            Else                            '修正
                strSQL = "UPDATE vdr_mtr"
                strSQL = strSQL & " SET vdr_kana = N'" & TextBox1.Text & "'"
                strSQL = strSQL & ", vdr_name = N'" & TextBox2.Text & "'"
                strSQL = strSQL & " WHERE (BY_cls = '" & Label19.Text & "')"
                strSQL = strSQL & " and (vdr_code = '" & Edit1.Text & "')"
                DB_OPEN("best_wrn")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                MsgBox("修正しました", , "")
                'MsgBox("Fixed", , "")
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
