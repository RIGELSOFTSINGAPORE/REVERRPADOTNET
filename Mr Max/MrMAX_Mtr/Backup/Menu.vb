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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents Button02 As System.Windows.Forms.Button
    Friend WithEvents Button03 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button04 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button01 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button02 = New System.Windows.Forms.Button
        Me.Button03 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button04 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button01
        '
        Me.Button01.Location = New System.Drawing.Point(20, 20)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(136, 36)
        Me.Button01.TabIndex = 0
        Me.Button01.Text = "���[�U�["
        '
        'Button99
        '
        Me.Button99.Location = New System.Drawing.Point(180, 176)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(136, 36)
        Me.Button99.TabIndex = 5
        Me.Button99.Text = "�I�@��"
        '
        'Button02
        '
        Me.Button02.Location = New System.Drawing.Point(20, 72)
        Me.Button02.Name = "Button02"
        Me.Button02.Size = New System.Drawing.Size(136, 36)
        Me.Button02.TabIndex = 1
        Me.Button02.Text = "�X�@��"
        '
        'Button03
        '
        Me.Button03.Location = New System.Drawing.Point(20, 124)
        Me.Button03.Name = "Button03"
        Me.Button03.Size = New System.Drawing.Size(136, 36)
        Me.Button03.TabIndex = 2
        Me.Button03.Text = "��@��"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(180, 20)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(136, 36)
        Me.Button10.TabIndex = 4
        Me.Button10.Text = "�ð����F�ɕύX"
        '
        'Button04
        '
        Me.Button04.Location = New System.Drawing.Point(20, 176)
        Me.Button04.Name = "Button04"
        Me.Button04.Size = New System.Drawing.Size(136, 36)
        Me.Button04.TabIndex = 3
        Me.Button04.Text = "���i�ú�ذ"
        '
        'Menu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(338, 227)
        Me.Controls.Add(Me.Button04)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button03)
        Me.Controls.Add(Me.Button02)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MrMax �Ǘ����j���["
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo TAG_Err
        If DB_INIT() = "1" Then Application.Exit() : Exit Sub

        Exit Sub
TAG_Err:
        MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Application.Exit()
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
    '**  �ð����F�ɕύX
    '********************************************************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim f_STS As New f_STS
        f_STS.Show()
        Me.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �I��
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub
End Class
