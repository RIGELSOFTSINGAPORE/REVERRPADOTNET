Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    ' Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    'Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
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
