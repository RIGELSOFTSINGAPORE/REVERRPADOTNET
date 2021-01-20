Public Class f_menu
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(80, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "件数確認"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button2.Location = New System.Drawing.Point(80, 80)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "パスワード変更"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Red
        Me.Button3.Location = New System.Drawing.Point(80, 288)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 32)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Quit"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button4.Location = New System.Drawing.Point(80, 128)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(136, 32)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "ユーザー追加"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button5.Location = New System.Drawing.Point(80, 176)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(136, 32)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "ｽﾃｰﾀｽをFに変更"
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button6.Location = New System.Drawing.Point(160, 256)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(136, 32)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "カウンター調整"
        Me.Button6.Visible = False
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button7.Location = New System.Drawing.Point(0, 256)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(136, 32)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "ｽﾃｰﾀス修正"
        Me.Button7.Visible = False
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button8.Location = New System.Drawing.Point(80, 224)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(136, 32)
        Me.Button8.TabIndex = 12
        Me.Button8.Text = "店舗マスタメンテ"
        '
        'f_menu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(296, 335)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "f_menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "管理メニュー"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub f_menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DB_INIT() = "1" Then Application.Exit() : Exit Sub
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_count As New f_count
        f_count.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_pwd_mod As New f_pwd_mod
        f_pwd_mod.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_user_add As New f_user_add
        f_user_add.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_STS As New f_STS
        f_STS.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_CNT_MTR As New f_CNT_MTR
        f_CNT_MTR.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_STS_rtn As New f_STS_rtn
        f_STS_rtn.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_shop As New f_shop
        f_shop.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
