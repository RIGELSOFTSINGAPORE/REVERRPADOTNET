Public Class F50_Form13
    Inherits System.Windows.Forms.Form
    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DsGRD As New DataSet
    Dim DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL As String
    Dim i, j, k As Integer

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
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F50_Form13))
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 616)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(960, 24)
        Me.msg.TabIndex = 1277
        Me.msg.Text = "msg"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "�X�V"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 648)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "�߂�"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "�f�[�^�捞"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(136, 64)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(48, 20)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.Text = "HP"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(24, 64)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(92, 20)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Apple/iOS"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(236, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "�捞�݊J�n"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(24, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(472, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(496, 32)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(48, 24)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "�Q��"
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(16, 124)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(972, 480)
        Me.DataGridEx1.TabIndex = 1279
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M40_PART"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "���i�ԍ�"
        Me.DataGridTextBoxColumn1.MappingName = "part_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "���i��"
        Me.DataGridTextBoxColumn2.MappingName = "part_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 250
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "##,##0"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "���承�i"
        Me.DataGridTextBoxColumn4.MappingName = "stc_amnt"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 90
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "##,##0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "�������i"
        Me.DataGridTextBoxColumn5.MappingName = "exc_amnt"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 90
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Labor Tier"
        Me.DataGridTextBoxColumn6.MappingName = "labor_tier"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "��֕��i�ԍ�"
        Me.DataGridTextBoxColumn7.MappingName = "sub_part_code"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 90
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "���i��"
        Me.DataGridTextBoxColumn3.MappingName = "part_dtl"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 240
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(116, 648)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 32)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "�N���A"
        '
        'F50_Form13
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F50_Form13"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���i�f�[�^�捞"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F50_Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        ACES()      '**  �����`�F�b�N
        inz_dsp()   '**  �������
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN = "0"
        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  �����`�F�b�N
    '********************************************************************
    Sub ACES()

        SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = P_ACES_brch_code
        Pram2.Value = P_ACES_post_code
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='513'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "2"
                Button1.Enabled = False
            Case Is = "3"
                Button1.Enabled = True
            Case Is = "4"
                Button1.Enabled = True
        End Select
    End Sub

    '********************************************************************
    '**  �������
    '********************************************************************
    Sub inz_dsp()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False

        DsGRD.Clear()
        strSQL = "SELECT * FROM M40_PART WHERE (part_code IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsGRD, "M40_PART")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsGRD.Tables("M40_PART")
        DataGridEx1.DataSource = tbl
    End Sub

    '********************************************************************
    '**  �Q��
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        msg.Text = Nothing

        With OpenFileDialog1
            .CheckFileExists = True     '�t�@�C�������݂��邩�m�F
            .RestoreDirectory = True    '�f�B���N�g���̕���
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "Excel ̧��(*.xls)|*.xls|���ׂẴt�@�C��(*.*)|*.*"
            .FilterIndex = 1            'Filter�v���p�e�B��2�ڂ�\��
            '�_�C�A���O�{�b�N�X��\�����A�m�J��]���N���b�N�����ꍇ
            If .ShowDialog = DialogResult.OK Then
                TextBox1.Text = .FileName
            End If
        End With
    End Sub

    '********************************************************************
    '**  �捞�݊J�n
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error GoTo err_prc
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing

        If Trim(TextBox1.Text) = Nothing Then
            msg.Text = "�捞�t�@�C�����w�肵�Ă��������B"
        Else
            If System.IO.File.Exists(TextBox1.Text) = False Then
                msg.Text = TextBox1.Text & " �͑��݂��܂���B"
            Else
                Button1.Enabled = False
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button98.Enabled = False

                ' �i�s�󋵃_�C�A���O�̏���������
                waitDlg = New WaitDialog        ' �i�s�󋵃_�C�A���O
                waitDlg.Owner = Me              ' �_�C�A���O�̃I�[�i�[��ݒ肷��
                waitDlg.MainMsg = Nothing       ' �����̊T�v��\��
                waitDlg.ProgressMax = 0         ' �S�̂̏���������ݒ�
                waitDlg.ProgressMin = 0         ' ���������̍ŏ��l��ݒ�i0������J�n�j
                waitDlg.ProgressStep = 1        ' �������ƂɃ��[�^��i�߂邩��ݒ�
                waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                waitDlg.Show()                  ' �i�s�󋵃_�C�A���O��\������

                waitDlg.MainMsg = "���i�ް��捞������"      ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMsg = ""                    ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMax = 0                     ' �S�̂̏���������ݒ�
                waitDlg.ProgressValue = 0                   ' �ŏ��̌�����ݒ�
                Application.DoEvents()                      ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim s As String
                Dim fnm As String = Trim(TextBox1.Text)

                Dim exl As Object
                exl = CreateObject("Excel.Application")
                exl.Application.Visible = False
                exl.Application.Workbooks.Open(FileName:=fnm)

                Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
                Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
                Dim xlBook As Excel.Workbook = xlBooks.Add
                Dim xlSheets As Excel.Sheets = DirectCast(xlBook.Worksheets, Excel.Sheets)
                Dim xlCells As Excel.Range
                Dim xlSheet As Excel.Worksheet = DirectCast(xlSheets(1), Excel.Worksheet)
                Dim xlRange As Excel.Range = xlSheet.Rows

                j = 0
                For k = 2 To 65536
                    xlRange = exl.Cells(k, 1) : s = xlRange.Value : If s = "" Then Exit For
                    j = k
                Next
                If j = 0 Then
                    msg.Text = "�Ώۃf�[�^������܂���B"
                    Button1.Enabled = False
                    Button2.Enabled = True
                    Button3.Enabled = True
                    Button4.Enabled = False
                    Button98.Enabled = True
                Else
                    waitDlg.MainMsg = "���i�ް��捞��"          ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                    waitDlg.ProgressMax = j - 1                 ' �S�̂̏���������ݒ�

                    For k = 2 To j
                        waitDlg.ProgressMsg = Fix((k - 1) * 100 / (j - 1)) & "%�@" & "�i" & Format((k - 1), "##,##0") & " / " & Format((j - 1), "##,##0") & " ���j"
                        waitDlg.Text = "���s���E�E�E" & Fix((k - 1) * 100 / (j - 1)) & "%�@"
                        Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                        waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                        xlRange = exl.Cells(k, 1) : s = xlRange.Value : If s = "" Then Exit For

                        dttable = DsGRD.Tables("M40_PART")
                        dtRow = dttable.NewRow

                        If RadioButton1.Checked = True Then 'Apple
                            xlRange = exl.Cells(k, 2) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_code") = s Else dtRow("part_code") = ""
                            xlRange = exl.Cells(k, 3) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_name") = s.Replace(Chr(39), " ") Else dtRow("part_name") = ""
                            xlRange = exl.Cells(k, 1) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_dtl") = s.Replace(Chr(39), " ") Else dtRow("part_dtl") = ""
                            xlRange = exl.Cells(k, 7) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("stc_amnt") = s Else dtRow("stc_amnt") = 0
                            xlRange = exl.Cells(k, 8) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("exc_amnt") = s Else dtRow("exc_amnt") = 0
                            xlRange = exl.Cells(k, 5) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("labor_tier") = s.Replace(Chr(39), " ") Else dtRow("labor_tier") = ""
                            xlRange = exl.Cells(k, 10) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("sub_part_code") = s.Replace(Chr(39), " ") Else dtRow("sub_part_code") = ""
                        Else               'HP
                            xlRange = exl.Cells(k, 1) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_code") = s Else dtRow("part_code") = ""
                            xlRange = exl.Cells(k, 2) : s = xlRange.Value : If Trim(s) <> Nothing Then dtRow("part_name") = s.Replace(Chr(39), " ") Else dtRow("part_name") = ""
                            dtRow("part_dtl") = ""
                            xlRange = exl.Cells(k, 3) : s = xlRange.Value : If IsNumeric(Trim(s)) = True Then dtRow("stc_amnt") = s Else dtRow("stc_amnt") = 0
                            xlRange = exl.Cells(k, 4) : s = xlRange.Value : If IsNumeric(Trim(s)) = True Then dtRow("exc_amnt") = s Else dtRow("exc_amnt") = 0
                            dtRow("labor_tier") = ""
                            dtRow("sub_part_code") = ""
                        End If
                        dttable.Rows.Add(dtRow)
                    Next

                    Button1.Enabled = True
                    Button2.Enabled = False
                    Button3.Enabled = False
                    Button4.Enabled = True
                    Button98.Enabled = True
                End If
                waitDlg.Close()                 ' �i�s�󋵃_�C�A���O�����

                exl.Application.DisplayAlerts = False
                exl.Application.Quit()
            End If
        End If
        Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub

err_prc:
        If Err.Number = 5 Then
            msg.Text = "�t�@�C���̓��e�i���ڂ܂��͕��я����j������Ă��܂��B"
        Else
            msg.Text = Err.Number & ":" & Err.Description
        End If
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        Button98.Enabled = True
        waitDlg.Close()                 ' �i�s�󋵃_�C�A���O�����
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.GotFocus
        RadioButton1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub RadioButton2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.GotFocus
        RadioButton2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub RadioButton1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.LostFocus
        RadioButton1.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub RadioButton2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.LostFocus
        RadioButton2.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  �X�V
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        DtView1 = New DataView(DsGRD.Tables("M40_PART"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button98.Enabled = False

            ' �i�s�󋵃_�C�A���O�̏���������
            waitDlg = New WaitDialog        ' �i�s�󋵃_�C�A���O
            waitDlg.Owner = Me              ' �_�C�A���O�̃I�[�i�[��ݒ肷��
            waitDlg.MainMsg = Nothing       ' �����̊T�v��\��
            waitDlg.ProgressMax = 0         ' �S�̂̏���������ݒ�
            waitDlg.ProgressMin = 0         ' ���������̍ŏ��l��ݒ�i0������J�n�j
            waitDlg.ProgressStep = 1        ' �������ƂɃ��[�^��i�߂邩��ݒ�
            waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
            waitDlg.Show()                  ' �i�s�󋵃_�C�A���O��\������

            waitDlg.MainMsg = "���i�ް��X�V������"      ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMsg = ""                    ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = DtView1.Count         ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0                   ' �ŏ��̌�����ݒ�
            Application.DoEvents()                      ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            DB_OPEN("nMVAR")
            strSQL = "DELETE FROM M40_PART"
            If RadioButton1.Checked = True Then 'Apple
                strSQL += " WHERE vndr_code = '01' OR  vndr_code = '20'"
            Else
                strSQL += " WHERE vndr_code = '03'"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            waitDlg.MainMsg = "���i�ް��X�V��"          ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@" & "�i" & Format((i + 1), "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%�@"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strSQL = "INSERT INTO M40_PART"
                strSQL += " (vndr_code, part_code, part_name, part_dtl, stc_amnt, exc_amnt, labor_tier, sub_part_code)"
                If RadioButton1.Checked = True Then 'Apple/iOS
                    strSQL += " VALUES ('01'"
                Else
                    strSQL += " VALUES ('03'"
                End If
                strSQL += ", '" & DtView1(i)("part_code") & "'"
                strSQL += ", '" & Trim(DtView1(i)("part_name")) & "'"
                strSQL += ", '" & Trim(DtView1(i)("part_dtl")) & "'"
                strSQL += ", " & DtView1(i)("stc_amnt")
                strSQL += ", " & DtView1(i)("exc_amnt")
                strSQL += ", '" & DtView1(i)("labor_tier") & "'"
                strSQL += ", '" & DtView1(i)("sub_part_code") & "'"
                strSQL += ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                If RadioButton1.Checked = True Then 'Apple/iOS
                    strSQL = "INSERT INTO M40_PART"
                    strSQL += " (vndr_code, part_code, part_name, part_dtl, stc_amnt, exc_amnt, labor_tier, sub_part_code)"
                    strSQL += " VALUES ('20'"
                    strSQL += ", '" & DtView1(i)("part_code") & "'"
                    strSQL += ", '" & Trim(DtView1(i)("part_name")) & "'"
                    strSQL += ", '" & Trim(DtView1(i)("part_dtl")) & "'"
                    strSQL += ", " & DtView1(i)("stc_amnt")
                    strSQL += ", " & DtView1(i)("exc_amnt")
                    strSQL += ", '" & DtView1(i)("labor_tier") & "'"
                    strSQL += ", '" & DtView1(i)("sub_part_code") & "'"
                    strSQL += ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If

            Next
            DB_CLOSE()
            waitDlg.Close()                 ' �i�s�󋵃_�C�A���O�����
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = True
            Button98.Enabled = True
        End If
        msg.Text = "�X�V���܂����B"
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �N���A
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        msg.Text = Nothing
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        DsGRD.Clear()
    End Sub

    '********************************************************************
    '**  �߂�
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsGRD.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
