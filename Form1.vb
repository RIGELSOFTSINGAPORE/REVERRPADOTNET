Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim strcurdir As String      '実行フォルダー
    Dim intprocid As Integer

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
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.Maroon
        Me.Button99.Location = New System.Drawing.Point(512, 176)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(84, 40)
        Me.Button99.TabIndex = 9
        Me.Button99.Text = "終　了"
        Me.Button99.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(416, 120)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(180, 40)
        Me.Button9.TabIndex = 8
        Me.Button9.UseVisualStyleBackColor = False
        Me.Button9.Visible = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Location = New System.Drawing.Point(416, 68)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(180, 40)
        Me.Button8.TabIndex = 7
        Me.Button8.UseVisualStyleBackColor = False
        Me.Button8.Visible = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(416, 16)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(180, 40)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "レポートメニュー"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(16, 16)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(180, 40)
        Me.Button6.TabIndex = 0
        Me.Button6.Text = "加入登録／修正"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(216, 120)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(180, 40)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "加入確定データ出力(SB02)"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(216, 68)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(180, 40)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "締め処理 戻し"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(216, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(180, 40)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "締め処理"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(16, 120)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(180, 40)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "エラーデータ修正"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "加入データ取込み"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 16)
        Me.ClientSize = New System.Drawing.Size(614, 231)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS Gothic", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入メインメニュー"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**************************************************************************
    '**  起動時
    '**************************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz_dsp()   '**  初期画面
    End Sub

    '**************************************************************************
    '**  初期画面
    '**************************************************************************
    Sub inz_dsp()
        strcurdir = System.IO.Directory.GetCurrentDirectory                                         '実行フォルダー
        System.IO.Directory.SetCurrentDirectory(strcurdir)
    End Sub

    '**************************************************************************
    '** 加入データ取込み
    '**************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\best_yamada_import.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**************************************************************************
    '** エラーデータ修正
    '**************************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\best_err_mnt.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**************************************************************************
    '** 締め処理
    '**************************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\best_close.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**************************************************************************
    '** 締め処理　戻し
    '**************************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\best_close_return.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**************************************************************************
    '** 加入確定データ出力(SB02)
    '**************************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\best_exp_SB02.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**************************************************************************
    '** 加入登録／修正
    '**************************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\best_input.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**************************************************************************
    '** レポートメニュー
    '**************************************************************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\best_Report.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("起動できませんでした", "エラー通知")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**************************************************************************
    '** 終了
    '**************************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub
End Class
