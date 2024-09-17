<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F12_取引先マスター
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Newlbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Yomigana = New System.Windows.Forms.TextBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.CustomerName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EP_name = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.EP_name, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Newlbl)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(699, 44)
        Me.Panel1.TabIndex = 0
        '
        'Newlbl
        '
        Me.Newlbl.AutoSize = True
        Me.Newlbl.Location = New System.Drawing.Point(573, 8)
        Me.Newlbl.Name = "Newlbl"
        Me.Newlbl.Size = New System.Drawing.Size(55, 14)
        Me.Newlbl.TabIndex = 1
        Me.Newlbl.Text = " （新規）"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "取引先マスター入力画面"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Yomigana)
        Me.Panel2.Controls.Add(Me.Cancel)
        Me.Panel2.Controls.Add(Me.OK)
        Me.Panel2.Controls.Add(Me.CustomerName)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Panel2.Location = New System.Drawing.Point(1, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(699, 452)
        Me.Panel2.TabIndex = 1
        '
        'Yomigana
        '
        Me.Yomigana.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Yomigana.Location = New System.Drawing.Point(158, 121)
        Me.Yomigana.Multiline = True
        Me.Yomigana.Name = "Yomigana"
        Me.Yomigana.Size = New System.Drawing.Size(322, 34)
        Me.Yomigana.TabIndex = 8
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Cancel.Location = New System.Drawing.Point(423, 179)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(83, 33)
        Me.Cancel.TabIndex = 7
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.OK.Location = New System.Drawing.Point(334, 179)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(69, 33)
        Me.OK.TabIndex = 6
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'CustomerName
        '
        Me.CustomerName.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CustomerName.Location = New System.Drawing.Point(157, 58)
        Me.CustomerName.Multiline = True
        Me.CustomerName.Name = "CustomerName"
        Me.CustomerName.Size = New System.Drawing.Size(323, 31)
        Me.CustomerName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ヨミガナ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "取引先名"
        '
        'EP_name
        '
        Me.EP_name.ContainerControl = Me
        '
        'F12_取引先マスター
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(654, 329)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Name = "F12_取引先マスター"
        Me.Text = "F12_取引先マスター"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.EP_name, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Cancel As Button
    Friend WithEvents OK As Button
    Friend WithEvents CustomerName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Yomigana As TextBox
    Friend WithEvents EP_name As ErrorProvider
    Friend WithEvents Newlbl As Label
End Class
