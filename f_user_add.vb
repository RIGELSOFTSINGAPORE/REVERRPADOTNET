Public Class f_user_add
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(88, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Submit"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(200, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 32)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Close"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox1.Location = New System.Drawing.Point(120, 32)
        Me.TextBox1.MaxLength = 5
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(120, 96)
        Me.TextBox2.MaxLength = 20
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(224, 26)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(120, 128)
        Me.TextBox3.MaxLength = 20
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TextBox3.Size = New System.Drawing.Size(224, 26)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.Text = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "(確認入力)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(248, 32)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 24)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "管理者"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.On
        Me.TextBox4.Location = New System.Drawing.Point(120, 64)
        Me.TextBox4.MaxLength = 25
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(224, 26)
        Me.TextBox4.TabIndex = 3
        Me.TextBox4.Text = ""
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "User Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'f_user_add
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(384, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "f_user_add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ユーザー追加"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim daItem = New SqlClient.SqlDataAdapter
        Dim dsItem As New DataSet
        Dim r As Integer

        'SqlSelectCommand
        Dim SqlSelectCommand As New SqlClient.SqlCommand
        SqlSelectCommand.CommandText = "SELECT EMPL_CODE FROM EMPL WHERE EMPL_CODE = '" & TextBox1.Text & "'"
        SqlSelectCommand.CommandType = CommandType.Text
        SqlSelectCommand.Connection = cnsqlclient
        daItem.SelectCommand = SqlSelectCommand

        DB_OPEN()
        r = daItem.Fill(dsItem, "CNT")
        DB_CLOSE()

        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
            MsgBox("UserID、パスワードは入力必須項目です。", MsgBoxStyle.Critical, "ユーザー追加")
        Else
            If r <> 0 Then
                MsgBox("このUserIDは既に登録されています。", MsgBoxStyle.Critical, "ユーザー追加")
                TextBox1.Focus()
            Else
                If TextBox2.Text = TextBox3.Text Then
                    Dim SqlUpdateCommand As New SqlClient.SqlCommand
                    If CheckBox1.Checked = False Then
                        SqlUpdateCommand.CommandText = "INSERT INTO EMPL(EMPL_CODE, EMPL_NAME, PSWD) VALUES( '" & TextBox1.Text & "', '" & TextBox4.Text & "', '" & TextBox2.Text & "')"
                    Else
                        SqlUpdateCommand.CommandText = "INSERT INTO EMPL(EMPL_CODE, EMPL_NAME, PSWD, EMPL_CLS) VALUES( '" & TextBox1.Text & "', '" & TextBox4.Text & "', '" & TextBox2.Text & "', '1')"
                    End If
                    SqlUpdateCommand.CommandType = CommandType.Text
                    SqlUpdateCommand.Connection = cnsqlclient
                    DB_OPEN()
                    SqlUpdateCommand.ExecuteNonQuery()
                    DB_CLOSE()
                    MsgBox("ユーザーは追加されました。", MsgBoxStyle.Information, "ユーザー追加")
                Else
                        MsgBox("パスワードを確認してください。", MsgBoxStyle.Critical, "ユーザー追加")
                        TextBox2.Text = Nothing
                        TextBox3.Text = Nothing
                        TextBox2.Focus()
                End If
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Dim f_menu As New f_menu
        f_menu.ShowDialog()
    End Sub

End Class
