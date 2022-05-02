<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F90_管理者
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Submit = New System.Windows.Forms.Button()
        Me.Remarks = New System.Windows.Forms.TextBox()
        Me.Name = New System.Windows.Forms.TextBox()
        Me.loginname = New System.Windows.Forms.TextBox()
        Me.Idtxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Winログイン名 = New System.Windows.Forms.Label()
        Me.ID = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(829, 56)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "F90_管理者"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Submit)
        Me.Panel2.Controls.Add(Me.Remarks)
        Me.Panel2.Controls.Add(Me.Name)
        Me.Panel2.Controls.Add(Me.loginname)
        Me.Panel2.Controls.Add(Me.Idtxt)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Winログイン名)
        Me.Panel2.Controls.Add(Me.ID)
        Me.Panel2.Location = New System.Drawing.Point(173, 83)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(439, 334)
        Me.Panel2.TabIndex = 1
        '
        'Submit
        '
        Me.Submit.Location = New System.Drawing.Point(333, 289)
        Me.Submit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Submit.Name = "Submit"
        Me.Submit.Size = New System.Drawing.Size(75, 35)
        Me.Submit.TabIndex = 8
        Me.Submit.Text = "Submit"
        Me.Submit.UseVisualStyleBackColor = True
        '
        'Remarks
        '
        Me.Remarks.Location = New System.Drawing.Point(116, 163)
        Me.Remarks.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Remarks.Multiline = True
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(293, 121)
        Me.Remarks.TabIndex = 7
        '
        'Name
        '
        Me.Name.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Name.Location = New System.Drawing.Point(116, 114)
        Me.Name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name.Multiline = True
        Me.Name.Name = "Name"
        Me.Name.Size = New System.Drawing.Size(293, 33)
        Me.Name.TabIndex = 6
        '
        'loginname
        '
        Me.loginname.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.loginname.Location = New System.Drawing.Point(116, 66)
        Me.loginname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.loginname.Multiline = True
        Me.loginname.Name = "loginname"
        Me.loginname.Size = New System.Drawing.Size(293, 33)
        Me.loginname.TabIndex = 5
        '
        'Idtxt
        '
        Me.Idtxt.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Idtxt.Location = New System.Drawing.Point(116, 17)
        Me.Idtxt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Idtxt.Multiline = True
        Me.Idtxt.Name = "Idtxt"
        Me.Idtxt.Size = New System.Drawing.Size(293, 33)
        Me.Idtxt.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(64, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 14)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "備考"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "名前"
        '
        'Winログイン名
        '
        Me.Winログイン名.AutoSize = True
        Me.Winログイン名.Location = New System.Drawing.Point(13, 66)
        Me.Winログイン名.Name = "Winログイン名"
        Me.Winログイン名.Size = New System.Drawing.Size(71, 14)
        Me.Winログイン名.TabIndex = 1
        Me.Winログイン名.Text = "Winログイン名"
        '
        'ID
        '
        Me.ID.AutoSize = True
        Me.ID.Location = New System.Drawing.Point(79, 19)
        Me.ID.Name = "ID"
        Me.ID.Size = New System.Drawing.Size(19, 14)
        Me.ID.TabIndex = 0
        Me.ID.Text = "ID"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 450)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(792, 215)
        Me.DataGridView1.TabIndex = 2
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'F90_管理者
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(809, 683)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        'Me.Name = "F90_管理者"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Submit As Button
    Friend WithEvents Remarks As TextBox
    Friend WithEvents Name As TextBox
    Friend WithEvents loginname As TextBox
    Friend WithEvents Idtxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Winログイン名 As Label
    Friend WithEvents ID As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
