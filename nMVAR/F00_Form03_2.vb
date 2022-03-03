Public Class F00_Form03_2
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label03 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label01 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.Label03 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(80, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "買取"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(208, 116)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 32)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "交換"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(64, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 28)
        Me.Label11.TabIndex = 1739
        Me.Label11.Text = "買取価格"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(188, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 28)
        Me.Label1.TabIndex = 1741
        Me.Label1.Text = "交換価格"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label01
        '
        Me.Label01.Location = New System.Drawing.Point(64, 84)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(100, 24)
        Me.Label01.TabIndex = 1742
        Me.Label01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label02
        '
        Me.Label02.Location = New System.Drawing.Point(188, 84)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(100, 24)
        Me.Label02.TabIndex = 1743
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label03
        '
        Me.Label03.Location = New System.Drawing.Point(16, 12)
        Me.Label03.Name = "Label03"
        Me.Label03.Size = New System.Drawing.Size(328, 40)
        Me.Label03.TabIndex = 1744
        '
        'F00_Form03_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(354, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label03)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F00_Form03_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "選択"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub F00_Form03_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label01.Text = Format(CInt(P1_F00_Form03_2), "##,##0")
        Label02.Text = Format(CInt(P2_F00_Form03_2), "##,##0")
        Label03.Text = P3_F00_Form03_2
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        P1_F00_Form03_2 = Label01.Text
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        P1_F00_Form03_2 = Label02.Text
        Close()
    End Sub
End Class
