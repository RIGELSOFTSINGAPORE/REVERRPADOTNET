Public Class F01_Form15
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, ANS, re_dsp As String
    Dim i, r As Integer

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
    Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.FunctionKey
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridEx1 As nMVAR_QA.DataGridEx
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form15))
        Me.FunctionKey1 = New GrapeCity.Win.Input.FunctionKey
        Me.f12 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridEx1 = New nMVAR_QA.DataGridEx
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FunctionKey1
        '
        Me.FunctionKey1.ActiveKeySet = "Default"
        Me.FunctionKey1.Location = New System.Drawing.Point(0, 686)
        Me.FunctionKey1.Name = "FunctionKey1"
        Me.FunctionKey1.Size = New System.Drawing.Size(1000, 0)
        Me.FunctionKey1.TabIndex = 51
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(896, 5)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 50
        Me.f12.Text = "F12:����"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn11})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "QA02_data"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 45)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(988, 636)
        Me.DataGridEx1.TabIndex = 49
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "id"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "QAC�ԍ�"
        Me.DataGridTextBoxColumn2.MappingName = "qac_no"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "��t�ԍ�"
        Me.DataGridTextBoxColumn4.MappingName = "gss_rcpt_no"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "���q�l�w��"
        Me.DataGridTextBoxColumn3.MappingName = "user_name"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 150
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "���[�J�[��"
        Me.DataGridTextBoxColumn7.MappingName = "maker_name"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 150
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "�@�햼"
        Me.DataGridTextBoxColumn11.MappingName = "model_name"
        Me.DataGridTextBoxColumn11.Width = 200
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "�j���o�^"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F01_Form15
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1000, 686)
        Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form15"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�j���o�^"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F01_Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()   '**  ��������
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        '�ް���د�ސݒ�
        sql()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("QA02_data")
        DataGridEx1.DataSource = tbl
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�F
    '********************************************************************
    'Private Sub DataGridEx1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
    '    If DataGridEx1.CurrentRowIndex >= 0 Then
    '        DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
    '    End If
    'End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�G���^�[
    '********************************************************************
    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    Cursor = System.Windows.Forms.Cursors.WaitCursor

                    P_F01_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 1) 'gss_rcpt_no

                    Dim F01_Form15_2 As New F01_Form15_2
                    F01_Form15_2.ShowDialog()

                    If P_RTN = "1" Then  '**  ��ʃZ�b�g
                        sql()
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�N���b�N
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor

                P_F01_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 1) 'gss_rcpt_no

                Dim F01_Form15_2 As New F01_Form15_2
                F01_Form15_2.ShowDialog()

                If P_RTN = "1" Then  '**  ��ʃZ�b�g
                    sql()
                End If
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub sql()
        DsList1.Clear()
        strSQL = "SELECT stts, qac_no, gss_rcpt_no, user_name, maker_name, model_name"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (QA02_data.stts = N'120')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "QA02_data")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("QA02_data"), "", "", DataViewRowState.CurrentRows)

    End Sub

    '********************************************************************
    '**  ����E�I���{�^��
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  �t�@���N�V�����L�[
    '********************************************************************
    Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

        e.Handled = True        '�t�@���N�V�����L�[�Ɋ���t����ꂽ�ݒ�𖳌��ɂ��܂��B
        Select Case e.KeyIndex  '�t�@���N�V�����L�[���������ꂽ�ꍇ�̏������s���܂��B
            Case 0  'F1
            Case 1  'F2
            Case 2  'F3
            Case 3  'F4
            Case 4  'F5
            Case 5  'F6
            Case 6  'F7
            Case 7  'F8
            Case 8  'F9
            Case 9  'F10
            Case 10 'F11
            Case 11 'F12
                f12_Click(sender, e)
        End Select
    End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
