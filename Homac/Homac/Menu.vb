Public Class Menu
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim intprocid As Integer
    Dim strSQL As String
    Dim r As Integer

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Menu))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 48)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 44)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "����"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(204, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(160, 44)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "�G���[�C��"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(384, 60)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(160, 44)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "���|�[�g"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(384, 128)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(160, 44)
        Me.Button99.TabIndex = 5
        Me.Button99.Text = "�I��"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(204, 128)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(160, 44)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "�}�X�^�����e"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(24, 128)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(160, 44)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "�f�[�^�C��"
        '
        'Menu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(566, 195)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DB_INIT()
        strcurdir = System.IO.Directory.GetCurrentDirectory                                         '���s�t�H���_�[

        DsList1.Clear()
        strSQL = "SELECT MAX(close_date) AS close_date FROM WRN_SUB"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(DsList1, "WRN_SUB")
        DB_CLOSE()

        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("WRN_SUB"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(DtView1(0)("close_date")) Then
                P_close_date = DtView1(0)("close_date")
            Else
                P_close_date = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM") & "/01"
            End If
        End If

    End Sub

    '******************************************************************
    '** ����
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            intprocid = Shell(strcurdir & "\Homac_search.exe", AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("�N���ł��܂���ł���", "�G���[�ʒm")
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** �G���[�C��
    '******************************************************************C:\SharedDocs\program\Homac\Homac\F05_Form03.vb
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F00_Form02 As New F00_Form02
        F00_Form02.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ���|�[�g
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Menu03 As New Menu03
        Menu03.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** �f�[�^�C��
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim F00_Form04 As New F00_Form04
        F00_Form04.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** �}�X�^�����e
    '******************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Menu05 As New Menu05
        Menu05.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** �I��
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub
End Class
