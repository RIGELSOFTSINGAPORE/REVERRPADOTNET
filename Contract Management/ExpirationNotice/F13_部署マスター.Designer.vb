<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F13_部署マスター
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
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Ok = New System.Windows.Forms.Button()
        Me.remarks = New System.Windows.Forms.TextBox()
        Me.Managementdepartment = New System.Windows.Forms.TextBox()
        Me.Departmentnumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Newlbl)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(801, 61)
        Me.Panel1.TabIndex = 0
        '
        'Newlbl
        '
        Me.Newlbl.AutoSize = True
        Me.Newlbl.Location = New System.Drawing.Point(524, 12)
        Me.Newlbl.Name = "Newlbl"
        Me.Newlbl.Size = New System.Drawing.Size(55, 14)
        Me.Newlbl.TabIndex = 1
        Me.Newlbl.Text = " （新規）"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "部署マスター入力画面"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Cancel)
        Me.Panel2.Controls.Add(Me.Ok)
        Me.Panel2.Controls.Add(Me.remarks)
        Me.Panel2.Controls.Add(Me.Managementdepartment)
        Me.Panel2.Controls.Add(Me.Departmentnumber)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(1, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(688, 346)
        Me.Panel2.TabIndex = 1
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(482, 268)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 38)
        Me.Cancel.TabIndex = 7
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Ok
        '
        Me.Ok.Location = New System.Drawing.Point(372, 268)
        Me.Ok.Name = "Ok"
        Me.Ok.Size = New System.Drawing.Size(75, 38)
        Me.Ok.TabIndex = 6
        Me.Ok.Text = "登録"
        Me.Ok.UseVisualStyleBackColor = True
        '
        'remarks
        '
        Me.remarks.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.remarks.Location = New System.Drawing.Point(196, 193)
        Me.remarks.Multiline = True
        Me.remarks.Name = "remarks"
        Me.remarks.Size = New System.Drawing.Size(307, 33)
        Me.remarks.TabIndex = 5
        '
        'Managementdepartment
        '
        Me.Managementdepartment.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Managementdepartment.Location = New System.Drawing.Point(196, 141)
        Me.Managementdepartment.Multiline = True
        Me.Managementdepartment.Name = "Managementdepartment"
        Me.Managementdepartment.Size = New System.Drawing.Size(307, 35)
        Me.Managementdepartment.TabIndex = 4
        '
        'Departmentnumber
        '
        Me.Departmentnumber.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Departmentnumber.Location = New System.Drawing.Point(196, 83)
        Me.Departmentnumber.Multiline = True
        Me.Departmentnumber.Name = "Departmentnumber"
        Me.Departmentnumber.Size = New System.Drawing.Size(307, 34)
        Me.Departmentnumber.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(125, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "備考"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "管理部署"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "部署番号"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'F13_部署マスター
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(691, 399)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Name = "F13_部署マスター"
        Me.Text = "F13_部署マスター"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Cancel As Button
    Friend WithEvents Ok As Button
    Friend WithEvents remarks As TextBox
    Friend WithEvents Managementdepartment As TextBox
    Friend WithEvents Departmentnumber As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Newlbl As Label
End Class
