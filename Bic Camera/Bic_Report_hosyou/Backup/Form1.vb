Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsExport As New DataSet
    Dim DtView1 As DataView

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Dim strSQL, inz_F As String
    Dim r, i As Integer

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit2 As GrapeCity.Win.Input.Edit
    Friend WithEvents Edit3 As GrapeCity.Win.Input.Edit
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Edit2 = New GrapeCity.Win.Input.Edit
        Me.Edit3 = New GrapeCity.Win.Input.Edit
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 80)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(840, 392)
        Me.DataGrid1.TabIndex = 5
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Cat_mtr"
        Me.DataGridTableStyle1.ReadOnly = True
        Me.DataGridTableStyle1.RowHeaderWidth = 10
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "�啪��"
        Me.DataGridTextBoxColumn1.MappingName = "cd1"
        Me.DataGridTextBoxColumn1.Width = 60
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "������"
        Me.DataGridTextBoxColumn2.MappingName = "cd2"
        Me.DataGridTextBoxColumn2.Width = 60
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "������"
        Me.DataGridTextBoxColumn3.MappingName = "cd3"
        Me.DataGridTextBoxColumn3.Width = 60
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "�i�햼(��)"
        Me.DataGridTextBoxColumn4.MappingName = "�i�햼(��)"
        Me.DataGridTextBoxColumn4.Width = 150
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "�i�햼(����)"
        Me.DataGridTextBoxColumn5.MappingName = "�i�햼(����)"
        Me.DataGridTextBoxColumn5.Width = 200
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "�ۏؑΏ�"
        Me.DataGridTextBoxColumn6.MappingName = "avlbty"
        Me.DataGridTextBoxColumn6.Width = 80
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "�ۏ؊���"
        Me.DataGridTextBoxColumn7.MappingName = "wrn_prod"
        Me.DataGridTextBoxColumn7.Width = 80
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "��ٰ��"
        Me.DataGridTextBoxColumn8.MappingName = "GRP"
        Me.DataGridTextBoxColumn8.Width = 80
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Button99.Location = New System.Drawing.Point(736, 488)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 8
        Me.Button99.Text = "�I��"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(16, 488)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "�V�K�o�^"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(608, 488)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "�f�[�^�o��"
        '
        'Edit1
        '
        Me.Edit1.AllowSpace = False
        Me.Edit1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit1.Format = "9#"
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit1.Location = New System.Drawing.Point(48, 48)
        Me.Edit1.MaxLength = 4
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(60, 25)
        Me.Edit1.TabIndex = 0
        Me.Edit1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        '
        'Edit2
        '
        Me.Edit2.AllowSpace = False
        Me.Edit2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit2.Format = "9#"
        Me.Edit2.HighlightText = True
        Me.Edit2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit2.Location = New System.Drawing.Point(112, 48)
        Me.Edit2.MaxLength = 2
        Me.Edit2.Name = "Edit2"
        Me.Edit2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit2.Size = New System.Drawing.Size(60, 25)
        Me.Edit2.TabIndex = 1
        Me.Edit2.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        '
        'Edit3
        '
        Me.Edit3.AllowSpace = False
        Me.Edit3.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit3.Format = "9#"
        Me.Edit3.HighlightText = True
        Me.Edit3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Edit3.Location = New System.Drawing.Point(168, 48)
        Me.Edit3.MaxLength = 2
        Me.Edit3.Name = "Edit3"
        Me.Edit3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit3.Size = New System.Drawing.Size(60, 25)
        Me.Edit3.TabIndex = 2
        Me.Edit3.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        '
        'CheckBox1
        '
        Me.CheckBox1.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(584, 48)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 16)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "�Ώ�"
        '
        'CheckBox2
        '
        Me.CheckBox2.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(584, 64)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(88, 16)
        Me.CheckBox2.TabIndex = 4
        Me.CheckBox2.Text = "�ΏۊO"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(272, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 24)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(192, 16)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(72, 24)
        Me.RadioButton2.TabIndex = 104
        Me.RadioButton2.Text = "���}�_"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(120, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 24)
        Me.RadioButton1.TabIndex = 103
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "�x�X�g"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "�V�X�e���敪"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(858, 527)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Edit3)
        Me.Controls.Add(Me.Edit2)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�i��Ͻ�����ݽ"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_mnt_cat")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("���łɋN�����Ă��܂�", "���s����")
            Application.Exit()
        End If
        Call DB_INIT()

        RadioButton1.Checked = True
        Label2.Text = "B"

        inz_F = "1"
        Call DspSet1()

    End Sub

    Sub DspSet1()
        P_DsList1.Clear()

        '�i��}�X�^
        'strSQL = "SELECT cd1, cd2, cd3, [�i�햼(��)], [�i�햼(����)], avlbty, cd12, wrn_prod, GRP, crt_date"
        strSQL = "SELECT Cat_mtr.*"
        strSQL = strSQL & " FROM dbo.Cat_mtr"
        strSQL = strSQL & " WHERE (BY_cls = '" & Label2.Text & "')"
        If Trim(Edit1.Text) <> Nothing Then strSQL = strSQL & " AND (cd1 = '" & Edit1.Text & "')"
        If Trim(Edit2.Text) <> Nothing Then strSQL = strSQL & " AND (cd2 = '" & Edit2.Text & "')"
        If Trim(Edit3.Text) <> Nothing Then strSQL = strSQL & " AND (cd3 = '" & Edit3.Text & "')"

        If CheckBox1.Checked = True And CheckBox2.Checked = True Then
        Else
            If CheckBox1.Checked = False And CheckBox2.Checked = False Then
            Else
                If CheckBox1.Checked = True Then
                    strSQL = strSQL & " AND (avlbty = '�Ώ�')"
                Else
                    strSQL = strSQL & " AND (avlbty is NULL)"
                End If
            End If
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(P_DsList1, "Cat_mtr")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = P_DsList1.Tables("Cat_mtr")
        DataGrid1.DataSource = tbl

    End Sub

    Private Sub Edit1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.TextChanged
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Len(Trim(Edit1.Text)) = 2 Or Len(Trim(Edit1.Text)) = 4 Or Trim(Edit1.Text) = Nothing Then
            Call DspSet1()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Edit2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit2.TextChanged
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Len(Trim(Edit2.Text)) = 2 Or Trim(Edit2.Text) = Nothing Then
            Call DspSet1()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Edit3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit3.TextChanged
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Len(Trim(Edit3.Text)) = 2 Or Trim(Edit3.Text) = Nothing Then
            Call DspSet1()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call DspSet1()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call DspSet1()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then

                P_BY_cls = Label2.Text
                P_cd1 = DataGrid1(hitinfo.Row, 0)
                P_cd2 = DataGrid1(hitinfo.Row, 1)
                P_cd3 = DataGrid1(hitinfo.Row, 2)

                Dim frmform2 As New Form2
                frmform2.ShowDialog()

                If P_Rtn = "1" Then
                    Call DspSet1()
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '�V�K�o�^�{�^��
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_BY_cls = Label2.Text
        P_cd1 = Nothing
        P_cd2 = Nothing
        P_cd3 = Nothing

        Dim frmform2 As New Form2
        frmform2.ShowDialog()

        If P_Rtn = "1" Then
            Call DspSet1()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '�f�[�^�o�̓{�^��
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' �i�s�󋵃_�C�A���O�̏���������
        waitDlg = New WaitDialog        ' �i�s�󋵃_�C�A���O
        waitDlg.Owner = Me              ' �_�C�A���O�̃I�[�i�[��ݒ肷��
        waitDlg.MainMsg = Nothing       ' �����̊T�v��\��
        waitDlg.ProgressMax = 0         ' �S�̂̏���������ݒ�
        waitDlg.ProgressMin = 0         ' ���������̍ŏ��l��ݒ�i0������J�n�j
        waitDlg.ProgressStep = 1        ' �������ƂɃ��[�^��i�߂邩��ݒ�
        waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
        Me.Enabled = False              ' �I�[�i�[�̃t�H�[���𖳌��ɂ���
        waitDlg.Show()                  ' �i�s�󋵃_�C�A���O��\������

        waitDlg.MainMsg = "�i��}�X�^"              ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
        waitDlg.ProgressMsg = "�f�[�^�o�͏�����"    ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
        Application.DoEvents()                      ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
        waitDlg.ProgressValue = 0                   ' �ŏ��̌�����ݒ�

        DsExport.Clear()
        strSQL = "SELECT * FROM Cat_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DB_OPEN("best_wrn")
        r = DaList1.Fill(DsExport, "CSV")
        DB_CLOSE()

        If r = 0 Then
            MessageBox.Show("�Y������f�[�^������܂���", "�G�N�X�|�[�g", MessageBoxButtons.OK)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        waitDlg.ProgressMsg = "CSV�o�͎��s��"           ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
        Application.DoEvents()                          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

        'DtView1 = New DataView(DsExport.Tables("CSV"), "avlbty is Null", "", DataViewRowState.CurrentRows)
        'For i = 0 To DtView1.Count - 1
        '    DtView1(i)("GRP") = "�ΏۊO"
        'Next

        '�t�@�C���ɏo��
        Dim sw As System.IO.StreamWriter  'StreamWriter�I�u�W�F�N�g
        Dim sbuf As String                '�t�@�C���ɏo�͂���f�[�^

        sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
        sbuf = "�V�X�e���敪,�啪�ރR�[�h,�����ރR�[�h,�����ރR�[�h,�i�햼(��),�i�햼(����),�ۏؑΏ�,�ۏ؊���,��ٰ��,�o�^��"
        sw.WriteLine(sbuf)

        DtView1 = New DataView(DsExport.Tables("CSV"), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMax = DtView1.Count         ' �S�̂̏���������ݒ�
        waitDlg.ProgressValue = 0                   ' �ŏ��̌�����ݒ�

        For i = 0 To DtView1.Count - 1

            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & (i + 1) & "/" & DtView1.Count & " ���j"
            waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%�@"

            Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
            waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

            sbuf = Chr(34) & DtView1(i)("BY_cls") & Chr(34)
            sbuf += "," & Chr(34) & Trim(DtView1(i)("cd1")) & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("cd2") & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("cd3") & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("�i�햼(��)") & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("�i�햼(����)") & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("avlbty") & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("wrn_prod") & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("GRP") & Chr(34)
            sbuf += "," & Chr(34) & DtView1(i)("crt_date") & Chr(34)
            sw.WriteLine(sbuf)
        Next
        sw.Close()

        Me.Activate()                   ' ��������I�[�i�[���A�N�e�B�u�ɂ���
        waitDlg.Close()                 ' �i�s�󋵃_�C�A���O�����
        Me.Enabled = True               ' �I�[�i�[�̃t�H�[����L���ɂ���

        '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
        SaveFileDialog1.FileName = "�i��_" & Format(Now.Date, "yyyyMMdd") & ".csv"
        SaveFileDialog1.Filter = "CSV�t�@�C��|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("�A�v���P�[�V�����G���[", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        MsgBox("�o�͂��܂���", , "")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '�I���{�^��
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Label2.Text = "B"
        If inz_F = "1" Then DspSet1()
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Label2.Text = "Y"
        If inz_F = "1" Then DspSet1()
    End Sub
End Class
