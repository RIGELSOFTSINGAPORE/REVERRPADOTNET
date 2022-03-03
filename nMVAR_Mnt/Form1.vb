Public Class Form1
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
    Friend WithEvents DataGridEx1 As nMVAR_Mnt.DataGridEx
    Friend WithEvents Combo1 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents DataGridEx2 As nMVAR_Mnt.DataGridEx
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGridEx1 = New nMVAR_Mnt.DataGridEx
        Me.Combo1 = New GrapeCity.Win.Input.Interop.Combo
        Me.DataGridEx2 = New nMVAR_Mnt.DataGridEx
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(28, 20)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.TabIndex = 0
        '
        'Combo1
        '
        Me.Combo1.Location = New System.Drawing.Point(28, 108)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo1.Size = New System.Drawing.Size(132, 16)
        Me.Combo1.TabIndex = 1
        Me.Combo1.Value = "Combo1"
        '
        'DataGridEx2
        '
        Me.DataGridEx2.DataMember = ""
        Me.DataGridEx2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx2.Location = New System.Drawing.Point(188, 148)
        Me.DataGridEx2.Name = "DataGridEx2"
        Me.DataGridEx2.Size = New System.Drawing.Size(72, 56)
        Me.DataGridEx2.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.DataGridEx2)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
