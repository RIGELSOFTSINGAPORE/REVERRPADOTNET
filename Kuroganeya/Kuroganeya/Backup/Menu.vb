Public Class Menu
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button04 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button03 As System.Windows.Forms.Button
    Friend WithEvents Button02 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button05 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Menu))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button04 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button03 = New System.Windows.Forms.Button
        Me.Button02 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button01 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button05 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "�����f�[�^�o�^"
        '
        'Button04
        '
        Me.Button04.Location = New System.Drawing.Point(28, 84)
        Me.Button04.Name = "Button04"
        Me.Button04.Size = New System.Drawing.Size(136, 40)
        Me.Button04.TabIndex = 9
        Me.Button04.Text = "���i�ú�ذ"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(348, 80)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(136, 40)
        Me.Button10.TabIndex = 10
        Me.Button10.Text = "�ð����F�ɕύX"
        '
        'Button03
        '
        Me.Button03.Location = New System.Drawing.Point(348, 32)
        Me.Button03.Name = "Button03"
        Me.Button03.Size = New System.Drawing.Size(136, 40)
        Me.Button03.TabIndex = 8
        Me.Button03.Text = "��@��"
        '
        'Button02
        '
        Me.Button02.Location = New System.Drawing.Point(188, 32)
        Me.Button02.Name = "Button02"
        Me.Button02.Size = New System.Drawing.Size(136, 40)
        Me.Button02.TabIndex = 7
        Me.Button02.Text = "�X�@��"
        '
        'Button99
        '
        Me.Button99.Location = New System.Drawing.Point(360, 308)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(136, 40)
        Me.Button99.TabIndex = 11
        Me.Button99.Text = "�I�@��"
        '
        'Button01
        '
        Me.Button01.Location = New System.Drawing.Point(28, 32)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(136, 40)
        Me.Button01.TabIndex = 6
        Me.Button01.Text = "���[�U�["
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-12, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(556, 68)
        Me.PictureBox1.TabIndex = 105
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button05)
        Me.GroupBox1.Controls.Add(Me.Button01)
        Me.GroupBox1.Controls.Add(Me.Button02)
        Me.GroupBox1.Controls.Add(Me.Button04)
        Me.GroupBox1.Controls.Add(Me.Button03)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 136)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "�}�X�^�����e"
        '
        'Button05
        '
        Me.Button05.Location = New System.Drawing.Point(188, 80)
        Me.Button05.Name = "Button05"
        Me.Button05.Size = New System.Drawing.Size(136, 40)
        Me.Button05.TabIndex = 11
        Me.Button05.Text = "���[�J�["
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(204, 88)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 40)
        Me.Button2.TabIndex = 107
        Me.Button2.Text = "�����\"
        '
        'Menu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(542, 367)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���C�����j���["
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '************************************************
    '** �N����
    '************************************************
    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()
    End Sub

    '************************************************
    '** �����f�[�^�o�^
    '************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Form1 As New Form1
        Form1.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '************************************************
    '** �����\
    '************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Form2 As New Form2
        Form2.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ���[�U�[
    '********************************************************************
    Private Sub Button01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button01.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Form01 As New Form01
        Form01.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �X��
    '********************************************************************
    Private Sub Button02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button02.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Form02 As New Form02
        Form02.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �敪
    '********************************************************************
    Private Sub Button03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button03.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Form03 As New Form03
        Form03.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ���i�ú�ذ
    '********************************************************************
    Private Sub Button04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button04.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Form04 As New Form04
        Form04.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ���[�J�[
    '********************************************************************
    Private Sub Button05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button05.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Form05 As New Form05
        Form05.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �ð����F�ɕύX
    '********************************************************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_STS As New f_STS
        f_STS.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '************************************************
    '** �I��
    '************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub
End Class
