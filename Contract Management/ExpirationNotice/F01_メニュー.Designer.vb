<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F01_メニュー
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F01_メニュー))
        Me.マスター入力 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'マスター入力
        '
        Me.マスター入力.AllowDrop = True
        Me.マスター入力.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.マスター入力.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.マスター入力.Location = New System.Drawing.Point(267, 87)
        Me.マスター入力.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.マスター入力.Name = "マスター入力"
        Me.マスター入力.Size = New System.Drawing.Size(269, 73)
        Me.マスター入力.TabIndex = 0
        Me.マスター入力.Text = "マスター入力"
        Me.マスター入力.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.AllowDrop = True
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(267, 176)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(269, 73)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "満了レポート"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.AllowDrop = True
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(267, 347)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(269, 73)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "検索"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.AllowDrop = True
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button3.Location = New System.Drawing.Point(12, 419)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 38)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "管理"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(628, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "マスター・データを入力"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(628, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(229, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "終了予定日が近い契約書の"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(628, 364)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "契約書の情報を検索"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(627, 232)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "レポートを出力"
        '
        'Button4
        '
        Me.Button4.AllowDrop = True
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Button4.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(267, 261)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(269, 73)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "調査用"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'F01_メニュー
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1053, 501)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.マスター入力)
        Me.Font = New System.Drawing.Font("Meiryo UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "F01_メニュー"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F01_メニュー"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents マスター入力 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
End Class
