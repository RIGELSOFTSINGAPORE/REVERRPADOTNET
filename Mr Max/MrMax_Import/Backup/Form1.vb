Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   '�i�s�󋵃t�H�[���N���X 

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3, WK_DtView1 As DataView

    Dim strSQL, strSQL2, Err_F, CX_F As String
    Dim i, j, k, p, r, r1, r2, n, cnt, arr As Long
    Dim qty As Integer

    Dim filename, strData, dir As String
    Dim max_date As Date
    Dim ans As String
    Dim WK_str As String

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button02 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button02 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button01 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button98)
        Me.GroupBox1.Controls.Add(Me.Button02)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button01)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(628, 104)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "�f�[�^�捞"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.ForeColor = System.Drawing.Color.Black
        Me.Button98.Location = New System.Drawing.Point(480, 64)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(64, 32)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "�߂�"
        '
        'Button02
        '
        Me.Button02.BackColor = System.Drawing.SystemColors.Control
        Me.Button02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button02.ForeColor = System.Drawing.Color.Black
        Me.Button02.Location = New System.Drawing.Point(24, 64)
        Me.Button02.Name = "Button02"
        Me.Button02.Size = New System.Drawing.Size(160, 32)
        Me.Button02.TabIndex = 2
        Me.Button02.Text = "�捞�݊J�n"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(24, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(540, 23)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Button01
        '
        Me.Button01.BackColor = System.Drawing.SystemColors.Control
        Me.Button01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button01.Location = New System.Drawing.Point(568, 32)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(48, 24)
        Me.Button01.TabIndex = 1
        Me.Button01.Text = "�Q��"
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(524, 472)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 12
        Me.Button99.Text = "�I ��"
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(96, 12)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(72, 24)
        Me.Date1.TabIndex = 0
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2010, 2, 8, 12, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "�����N��"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(48, 164)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "�G���[���X�g(CSV)"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(196, 164)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 44)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "�@�l���X�g(CSV)"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(48, 252)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(140, 44)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "�@�l�I��"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(196, 252)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(140, 44)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "�G���[�C��"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(196, 304)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(140, 44)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "�G���[�C���@�@�@�@(�ڷޭװ)"
        Me.Button5.Visible = False
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(48, 372)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(140, 44)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "�����\(XLS)"
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(344, 252)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(140, 44)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "�G���[�C���@�@�@�@(�����)"
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Location = New System.Drawing.Point(48, 304)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(140, 44)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "5009:�y�V���O"
        Me.Button8.Visible = False
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(48, 456)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(140, 44)
        Me.Button9.TabIndex = 11
        Me.Button9.Text = "�o�^"
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(492, 252)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(140, 44)
        Me.Button10.TabIndex = 8
        Me.Button10.Text = "�@��o�^"
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(344, 164)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(140, 44)
        Me.Button11.TabIndex = 122
        Me.Button11.Text = "OK ���X�g(CSV)"
        '
        'Button12
        '
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(640, 252)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(140, 44)
        Me.Button12.TabIndex = 9
        Me.Button12.Text = "�ۏؓo�^"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(798, 515)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MrMax"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()
        dir = System.IO.Directory.GetCurrentDirectory
        inz()   '**  ��������

        'MsgBox("�i��}�X�^�����đΏۊO�̕i����G���[�ɂ��鏈�����������̂Ō��ʊm�F����B")
    End Sub

    '*********************************************************************************
    '**  ��������
    '*********************************************************************************
    Sub inz()

        '�����N���Z�b�g
        WK_DsList1.Clear()
        'SqlCmd1 = New SqlClient.SqlCommand("SELECT MAX(������) AS MAX������ FROM [02_����f�[�^]", cnsqlclient)
        SqlCmd1 = New SqlClient.SqlCommand("SELECT MAX(������) AS MAX������ FROM [01_�捞�f�[�^]", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("sals"), "", "", DataViewRowState.CurrentRows)
        If Not IsDBNull(WK_DtView1(0)("MAX������")) Then
            max_date = WK_DtView1(0)("MAX������")
            Date1.Text = Format(DateAdd(DateInterval.Month, 1, max_date), "yyyy/MM")
        Else
            Date1.Text = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM")
        End If
    End Sub


    '*********************************************************************************
    '**  �Q��
    '*********************************************************************************
    Private Sub Button01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button01.Click
        With OpenFileDialog1
            .CheckFileExists = True     '�t�@�C�������݂��邩�m�F
            .RestoreDirectory = True    '�f�B���N�g���̕���
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = _
            "�G�N�Z���t�@�C��(*.xls)|*.xls"
            .FilterIndex = 2            'Filter�v���p�e�B��2�ڂ�\��
            '�_�C�A���O�{�b�N�X��\�����A�m�J��]���N���b�N�����ꍇ
            If .ShowDialog = DialogResult.OK Then
                TextBox1.Text = .FileName
            End If
        End With
    End Sub

    '*********************************************************************************
    '**  �捞
    '*********************************************************************************
    Private Sub Button02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button02.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()
        'Err_F = "0"
        If Err_F = "0" Then
            System.Diagnostics.EventLog.WriteEntry("MrMAX Import START ", "�C���|�[�g�J�n", System.Diagnostics.EventLogEntryType.Information)

            '�i�s�󋵃_�C�A���O�̏���������()
            waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�f�[�^���C���|�[�g���Ă��܂��B"
            Application.DoEvents()          '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            Call xls_import()   '�G�N�Z���C���|�[�g
            Call bunkatu()      '��������
            Call rb_chk()       '�ԍ��ƍ�
            Call rb_chk2()      '�ԃf�[�^�̂݃`�F�b�N
            Call wrn_chk()      '�ۏ؃f�[�^�ƍ�(PB�ȊO)
            Call PB_chk1()      'PB�f�[�^�ƍ�_�ϓ�
            Call PB_chk2()      'PB�f�[�^�ƍ�_�Œ�
            Call AC_Mach()      '�G�A�R���}�b�`���O
            Call CAT_Mach()     '�i��G���[�R�[�h_�t�^
            Call wrn_fee_Mach() '�ۏؗ��G���[�R�[�h_�t�^
            Call low_prc()      '�����z�G���[
            Call err_F_upd()    '�G���[�t���O=Null��0�ɍX�V
            Call cat_err()      '�i��G���[
            Call rakuten()      '�y�V���O


            inz()   '**  ��������
            System.Diagnostics.EventLog.WriteEntry("MrMAX Import END ", "�C���|�[�g����", System.Diagnostics.EventLogEntryType.Information)
            MsgBox("��荞�݊���")
            waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub F_chk()
        Err_F = "0"

        If Date1.Number = 0 Then
            MsgBox("�����N���͓��͕K�{�ł��B", 16, "Error")    '�~ 1=�n�j
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If
        P_DATE = Date1.Text & "/01'"

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT ������ FROM [02_����f�[�^] WHERE (������ = CONVERT(DATETIME, '" & P_DATE & "', 102))", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("sals"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            MsgBox("�����N���͊��ɏ����ς݂ł��B", 16, "Error")    '�~ 1=�n�j
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If

        TextBox1.Text = Trim(TextBox1.Text)
        If TextBox1.Text = Nothing Then
            MsgBox("�捞�f�[�^�͓��͕K�{�ł��B", 16, "Error")    '�~ 1=�n�j
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

        If System.IO.File.Exists(TextBox1.Text) = False Then
            MsgBox("�Y������t�@�C��������܂���B", 16, "Error")    '�~ 1=�n�j
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    Sub F_chk2()
        Err_F = "0"

        If Date1.Number = 0 Then
            MsgBox("�����N���͓��͕K�{�ł��B", 16, "Error")    '�~ 1=�n�j
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If
        P_DATE = Date1.Text & "/01'"

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT ������ FROM [02_����f�[�^] WHERE (������ = CONVERT(DATETIME, '" & P_DATE & "', 102))", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("sals"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            MsgBox("�����N���͖��捞�݂ł��B", 16, "Error")    '�~ 1=�n�j
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    Private Sub xls_import() '�G�N�Z���C���|�[�g
        Dim fnm As String
        Dim rec(36) As String
        Dim exl As Object
        Dim xlRange As Excel.Range

        fnm = TextBox1.Text

        exl = CreateObject("Excel.Application")
        exl.Application.Visible = False
        exl.Application.Workbooks.Open(filename:=fnm)

        Dim a1, a2 As String

        For j = 2 To 65536
            xlRange = exl.cells(j, 1)
            a1 = xlRange.Value
            a2 = xlRange.Value
            If xlRange.Value = "" Then Exit For
        Next
        cnt = j - 2
        waitDlg.ProgressMax = cnt         ' �S�̂̏���������ݒ�

        DB_OPEN()
        For j = 2 To 65536
            xlRange = exl.cells(j, 1)
            If xlRange.Value = "" Then Exit For

            waitDlg.ProgressMsg = Fix((j - 1) * 100 / cnt) & "%�@�i" & Format(j - 1, "##,##0") & " / " & Format(cnt, "##,##0") & " ���j"
            Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
            waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

            Array.Clear(rec, Nothing, rec.Length)
            For i = 1 To 36
                xlRange = exl.cells(j, i)
                rec(i) = xlRange.Value
            Next

            '2014/05/12 �ŋ敪�Ή� start
            '�ŋ敪��"1"�i�O�Łj�̏ꍇ�A������
            If rec(32) = "1" Then
                rec(32) = "5"       '�ŋ敪����łɕύX
                '�ō����z�ɕύX
                rec(30) = GetTaxPrice(rec(30), rec(2))      '�}�X�^�P��
                rec(31) = GetTaxPrice(rec(31), rec(2))      '�P��
                rec(35) = GetTaxPrice(rec(35), rec(2))      '�l���z
                rec(36) = GetTaxPrice(rec(36), rec(2))      '�P��2
            End If
            '2014/05/12 �ŋ敪�Ή� end

            strSQL = "INSERT INTO [01_�捞�f�[�^]"
            strSQL += " (�`�[NO, ���s��, �z���X����, ��ʔ��|�敪, ����, TEL1, TEL2, �X�֔ԍ�, �Z��1, �Z��2"
            strSQL += ", �Z��3, �Z��4, �Z��5, �̔��Һ���, ������, �폜�׸�, �s�ԍ�, �s�敪, ���i����, �i����"
            strSQL += ", �^�Զ�, �װ, ����, ڼ��, �i������, �^�Ԋ���, ���޺���, �i����, ���㐔, Ͻ��P��"
            strSQL += ", �P��, �ŋ敪, �l�������敪, ������, �l���z, �P��2, ������)"
            strSQL += " SELECT '" & rec(1) & "' AS Expr1"       '�`�[No.
            strSQL += ", '" & rec(2) & "' AS Expr2"     '���s��
            strSQL += ", " & rec(3) & " AS Expr3"       '�z���X�R�[�h
            strSQL += ", '" & rec(4) & "' AS Expr4"     '��ʔ��|�敪
            strSQL += ", '" & rec(5) & "' AS Expr5"     '����
            strSQL += ", '" & rec(6) & "' AS Expr6"     'TEL1
            strSQL += ", '" & rec(7) & "' AS Expr7"     'TEL2
            strSQL += ", '" & rec(8) & "' AS Expr8"     '�X�֔ԍ�
            strSQL += ", '" & rec(9) & "' AS Expr9"     '�Z��1
            strSQL += ", '" & rec(10) & "' AS Expr10"       '�Z��2
            strSQL += ", '" & rec(11) & "' AS Expr11"       '�Z��3
            strSQL += ", '" & rec(12) & "' AS Expr12"       '�Z��4
            strSQL += ", '" & rec(13) & "' AS Expr13"       '�Z��5
            strSQL += ", '" & rec(14) & "' AS Expr14"       '�̔��҃R�[�h
            strSQL += ", '" & rec(15) & "' AS Expr15"       '������
            strSQL += ", '" & rec(16) & "' AS Expr16"       '�폜�t���O
            strSQL += ", " & rec(17) & " AS Expr17"     '�s�ԍ�
            strSQL += ", '" & rec(18) & "' AS Expr18"       '�s�敪

            WK_str = Trim(rec(19))
            If rec(27) = "30" Or rec(27) = "91" Then
                WK_str = WK_str.PadLeft(13, "0")
            End If
            strSQL += ", '" & WK_str & "' AS Expr19"        '���i�R�[�h

            strSQL += ", '" & rec(20) & "' AS Expr20"       '�i���J�i
            strSQL += ", '" & rec(21) & "' AS Expr21"       '�^�ԃJ�i
            strSQL += ", '" & rec(22) & "' AS Expr22"       '�J���[
            strSQL += ", '" & rec(23) & "' AS Expr23"       '�T�C�Y
            strSQL += ", '" & rec(24) & "' AS Expr24"       '���V�[�g
            strSQL += ", '" & rec(25) & "' AS Expr25"       '�i������
            strSQL += ", '" & rec(26) & "' AS Expr26"       '�^�Ԋ���
            strSQL += ", '" & rec(27) & "' AS Expr27"       '���ރR�[�h
            strSQL += ", '" & rec(28) & "' AS Expr28"       '�i��R�[�h
            strSQL += ", " & rec(29) & " AS Expr29"     '���㐔
            strSQL += ", " & rec(30) & " AS Expr30"     '�}�X�^�P��
            strSQL += ", " & rec(31) & " AS Expr31"     '�P��
            strSQL += ", '" & rec(32) & "' AS Expr32"       '�ŋ敪
            strSQL += ", '" & rec(33) & "' AS Expr33"       '�l�������敪
            strSQL += ", " & rec(34) & " AS Expr34"     '������
            strSQL += ", " & rec(35) & " AS Expr35"     '�l���z
            strSQL += ", " & rec(36) & " AS Expr36"     '�P��2
            strSQL += ", '" & P_DATE & "' AS Expr37"    '������
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        Next
        DB_CLOSE()

        exl.Application.DisplayAlerts = False
        exl.Application.Quit()
    End Sub

    Private Sub bunkatu() '��������
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_import01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "imp")
        DtView1 = New DataView(DsList1.Tables("imp"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ' �i�s�󋵃_�C�A���O�̏���������
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�f�[�^�𕪉����Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                If DtView1(i)("���㐔") < 0 Then qty = DtView1(i)("���㐔") * -1 Else qty = DtView1(i)("���㐔")
                For j = 1 To qty

                    strSQL = "INSERT INTO [02_����f�[�^]"
                    strSQL += " (�`�[NO, ���s��, [�z���X����], ��ʔ��|�敪, ����, TEL1, TEL2, �X�֔ԍ�, �Z��1, �Z��2"
                    strSQL += ", �Z��3, �Z��4, �Z��5, [�̔��Һ���], ������, [�폜�׸�], �s�ԍ�, �s�敪, [���i����], [�i����]"
                    strSQL += ", [�^�Զ�], [�װ], [����], [ڼ��], �i������, �^�Ԋ���, [���޺���], [�i����], ���㐔, [Ͻ��P��]"
                    strSQL += ", �P��, �ŋ敪, �l�������敪, ������, �l���z, �P��2, ������, ������2, ��������, ������SEQ"
                    strSQL += ", �ԍ�SEQ, sprice, WSEQ1, WSEQ2, �@�l, dlt_f, wrn_add_f)"
                    WK_str = Trim(DtView1(i)("�`�[NO")) : WK_str = WK_str.PadLeft(12, "0")
                    strSQL += " SELECT '" & WK_str & "' AS Expr1"
                    strSQL += ", '" & DtView1(i)("���s��") & "' AS Expr2"
                    WK_str = Trim(DtView1(i)("�z���X����")) : WK_str = WK_str.PadLeft(4, "0")
                    strSQL += ", '" & WK_str & "' AS Expr3"
                    strSQL += ", '" & DtView1(i)("��ʔ��|�敪") & "' AS Expr4"
                    strSQL += ", '" & DtView1(i)("����") & "' AS Expr5"
                    strSQL += ", '" & DtView1(i)("TEL1") & "' AS Expr6"
                    strSQL += ", '" & DtView1(i)("TEL2") & "' AS Expr7"
                    strSQL += ", '" & DtView1(i)("�X�֔ԍ�") & "' AS Expr8"
                    strSQL += ", '" & DtView1(i)("�Z��1") & "' AS Expr9"
                    strSQL += ", '" & DtView1(i)("�Z��2") & "' AS Expr10"
                    strSQL += ", '" & DtView1(i)("�Z��3") & "' AS Expr11"
                    strSQL += ", '" & DtView1(i)("�Z��4") & "' AS Expr12"
                    strSQL += ", '" & DtView1(i)("�Z��5") & "' AS Expr13"
                    strSQL += ", '" & DtView1(i)("�̔��Һ���") & "' AS Expr14"
                    strSQL += ", '" & DtView1(i)("������") & "' AS Expr15"
                    strSQL += ", '" & DtView1(i)("�폜�׸�") & "' AS Expr16"
                    strSQL += ", " & DtView1(i)("�s�ԍ�") & " AS Expr17"
                    strSQL += ", '" & DtView1(i)("�s�敪") & "' AS Expr18"
                    WK_str = Trim(DtView1(i)("���i����")).PadLeft(13, "0")
                    strSQL += ", '" & WK_str & "' AS Expr19"
                    strSQL += ", '" & DtView1(i)("�i����") & "' AS Expr20"
                    strSQL += ", '" & DtView1(i)("�^�Զ�") & "' AS Expr21"
                    strSQL += ", '" & DtView1(i)("�װ") & "' AS Expr22"
                    strSQL += ", '" & DtView1(i)("����") & "' AS Expr23"
                    strSQL += ", '" & DtView1(i)("ڼ��") & "' AS Expr24"
                    strSQL += ", '" & DtView1(i)("�i������") & "' AS Expr25"
                    strSQL += ", '" & DtView1(i)("�^�Ԋ���") & "' AS Expr26"
                    strSQL += ", '" & DtView1(i)("���޺���") & "' AS Expr27"
                    strSQL += ", '" & DtView1(i)("�i����") & "' AS Expr28"
                    strSQL += ", " & DtView1(i)("���㐔") & " AS Expr29"
                    strSQL += ", " & DtView1(i)("Ͻ��P��") & " AS Expr30"
                    strSQL += ", " & DtView1(i)("�P��") & " AS Expr31"
                    strSQL += ", '" & DtView1(i)("�ŋ敪") & "' AS Expr32"
                    strSQL += ", '" & DtView1(i)("�l�������敪") & "' AS Expr33"
                    strSQL += ", " & DtView1(i)("������") & " AS Expr34"
                    strSQL += ", " & DtView1(i)("�l���z") & " AS Expr35"
                    strSQL += ", " & DtView1(i)("�P��2") & " AS Expr36"
                    strSQL += ", '" & DtView1(i)("������") & "' AS Expr19_2"
                    strSQL += ", '" & DtView1(i)("������") & "' AS Expr19_3"
                    If DtView1(i)("���㐔") > 0 Then                         'QTY
                        strSQL += ", 1 AS Expr38"     '��������
                    Else
                        strSQL += ", -1 AS Expr38"
                    End If

                    Dim IntSEQ As Integer
                    Select Case j
                        Case Is = 1
                            strSQL += ", 0 AS Expr39" '������SEQ
                        Case Is = 2
                            WK_DsList1.Clear()
                            SqlCmd1 = New SqlClient.SqlCommand("SELECT * FROM V_MAX_SEQ", cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            SqlCmd1.CommandTimeout = 3600
                            DaList1.Fill(WK_DsList1, "MAX_SEQ")
                            WK_DtView1 = New DataView(WK_DsList1.Tables("MAX_SEQ"), "", "", DataViewRowState.CurrentRows)
                            IntSEQ = WK_DtView1(0)("MAX_SEQ")
                            strSQL += ", " & IntSEQ & " AS Expr39"
                        Case Is > 2
                            strSQL += ", " & IntSEQ & " AS Expr39"
                    End Select
                    strSQL += ", 0 AS Expr40"
                    strSQL += ", 0 AS Expr41"
                    strSQL += ", 0 AS Expr42"
                    strSQL += ", 0 AS Expr43"
                    strSQL += ", 0 AS Expr44"
                    strSQL += ", 0 AS Expr45"
                    strSQL += ", 0 AS Expr46"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                Next j
            Next i

            'MsgBox("��������")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()
    End Sub

    Private Sub rb_chk() '�ԍ��ƍ�
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_rb_chk", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "rb_chk")
        DtView1 = New DataView(DsList1.Tables("rb_chk"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�ԍ��ƍ����Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                '�`�[�ԍ�,���i�R�[�h,�P��2����v���� qty = 1�̃f�[�^������
                WK_DsList1.Clear()
                strSQL = "SELECT SEQ FROM [02_����f�[�^]"
                strSQL += " WHERE (�ԍ�SEQ = 0)"
                strSQL += " AND (�������� = N'1')"
                strSQL += " AND (������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (�`�[NO = '" & DtView1(i)("�`�[NO") & "')"
                strSQL += " AND ([���i����] = '" & DtView1(i)("���i����") & "')"
                strSQL += " AND (�P��2 = " & DtView1(i)("�P��2") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "rb_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("rb_chk2"), "", "SEQ", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then

                    strSQL = "UPDATE [02_����f�[�^]"
                    strSQL += " SET �ԍ�SEQ = " & DtView1(i)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    strSQL = "UPDATE [02_����f�[�^]"
                    strSQL += " SET �ԍ�SEQ = " & WK_DtView1(0)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                End If
            Next i

            'MsgBox("�ԍ��ƍ�����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()

    End Sub

    Private Sub rb_chk2()   '�ԃf�[�^�̂݃`�F�b�N
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_04", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_04")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ''�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�ԃf�[�^�̂݃`�F�b�N���Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strSQL = "UPDATE [02_����f�[�^]"
                strSQL += " SET ERR_F = '3'"
                strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next i

            'MsgBox("�ԃf�[�^�̂݃`�F�b�N����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()
    End Sub

    Private Sub wrn_chk() '�ۏ؃f�[�^�ƍ�
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_wrn_chk", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "wrn_chk")
        DtView1 = New DataView(DsList1.Tables("wrn_chk"), "", "SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�ۏ؃f�[�^�ƍ����Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                '�`�[�ԍ��Ƌ��z����v���锄��f�[�^������
                WK_DsList1.Clear()
                strSQL = "SELECT [02_����f�[�^].SEQ, [02_����f�[�^].�P��2"
                strSQL += " FROM [02_����f�[�^] INNER JOIN"
                strSQL += " M08_KBN_CAT ON"
                strSQL += " [02_����f�[�^].[�i����] = M08_KBN_CAT.CAT_CODE LEFT OUTER JOIN"
                strSQL += " [M07_PB_ϯ�ݸ�] ON"
                strSQL += " [02_����f�[�^].�^�Զ� = [M07_PB_ϯ�ݸ�].�^�Զ�"
                strSQL += " WHERE ([02_����f�[�^].�`�[NO = '" & DtView1(i)("�`�[NO") & "')"
                strSQL += " AND ([02_����f�[�^].�ԍ�SEQ = 0)"
                strSQL += " AND ([02_����f�[�^].�������� = " & DtView1(i)("��������") & ")"
                strSQL += " AND ([02_����f�[�^].������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (M08_KBN_CAT.KBN_CODE = '" & DtView1(i)("KBN_CODE") & "')"
                strSQL += " AND ([02_����f�[�^].[���޺���] <> '30')"
                strSQL += " AND ([02_����f�[�^].[���޺���] <> '91')"
                strSQL += " AND ([02_����f�[�^].WSEQ1 = 0)"
                strSQL += " AND ([02_����f�[�^].�P��2 * 0.05 - " & DtView1(i)("�P��2") & " <= 1)"
                strSQL += " AND ([02_����f�[�^].�P��2 * 0.05 - " & DtView1(i)("�P��2") & " >= - 1)"
                strSQL += " AND ([M07_PB_ϯ�ݸ�].�Œ� IS NULL OR [M07_PB_ϯ�ݸ�].�Œ� = '0')"
                'strSQL = "SELECT [02_����f�[�^].SEQ, [02_����f�[�^].�P��2"
                'strSQL += " FROM [02_����f�[�^] INNER JOIN"
                'strSQL += " M08_KBN_CAT ON"
                'strSQL += " [02_����f�[�^].[�i����] =  M08_KBN_CAT.CAT_CODE"
                'strSQL += " WHERE ([02_����f�[�^].�`�[NO = '" & DtView1(i)("�`�[NO") & "')"
                'strSQL += " AND ([02_����f�[�^].�ԍ�SEQ = 0)"
                'strSQL += " AND ([02_����f�[�^].�������� = " & DtView1(i)("��������") & ")"
                'strSQL += " AND ([02_����f�[�^].�P��2 * 0.05 - " & DtView1(i)("�P��2") & " <= 1 AND [02_����f�[�^].�P��2 * 0.05 - " & DtView1(i)("�P��2") & " >= - 1)"
                'strSQL += " AND ([02_����f�[�^].������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                'strSQL += " AND (M08_KBN_CAT.KBN_CODE = '" & DtView1(i)("KBN_CODE") & "')"
                'strSQL += " AND ([02_����f�[�^].[���޺���] <> '30')"
                'strSQL += " AND ([02_����f�[�^].[���޺���] <> '91')"
                'strSQL += " AND ([02_����f�[�^].WSEQ1 = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("wrn_chk2"), "", "SEQ", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    For j = 0 To WK_DtView1.Count - 1

                        '��v��������f�[�^��wSEQ1�ɕۏ؃f�[�^��SEQ���L����ۏ؃f�[�^��wSEQ1�ɔ���f�[�^��SEQ��P��2���L��
                        strSQL = "UPDATE [02_����f�[�^]"
                        strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                        strSQL += " WHERE (SEQ = " & WK_DtView1(j)("SEQ") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                        strSQL = "UPDATE [02_����f�[�^]"
                        strSQL += " SET wSEQ1 = " & WK_DtView1(j)("SEQ") & ""
                        strSQL += ", sprice = " & WK_DtView1(j)("�P��2") & ""
                        strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                        Exit For
                    Next j
                End If
            Next i

            'MsgBox("�ۏ؃f�[�^�ƍ�����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()
    End Sub

    Private Sub PB_chk1() 'PB�f�[�^�ƍ�_�ϓ�
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_wrn_chk_PB_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "wrn_chk")
        DtView1 = New DataView(DsList1.Tables("wrn_chk"), "", "SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "PB�i�ϓ��j�ۏ؃f�[�^�ƍ����Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                '�`�[�ԍ�����v����ۏ؃f�[�^������
                WK_DsList1.Clear()
                strSQL = "SELECT �`�[NO, [���i����], �i����, �^�Զ�, [���޺���], �P��2, SEQ, �ԍ�SEQ, sprice, WSEQ1"
                strSQL += " FROM [02_����f�[�^]"
                strSQL += " WHERE (������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (ERR_F IS NULL)"
                strSQL += " AND ([���i����] = '0400000069814' OR [���i����] = '0400000091419')"
                strSQL += " AND (�`�[NO = '" & DtView1(i)("�`�[NO") & "')"
                strSQL += " AND (�ԍ�SEQ = 0)"
                strSQL += " AND (WSEQ1 = 0)"
                strSQL += " AND ([���޺���] = '30' OR [���޺���] = '91')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("wrn_chk2"), "", "SEQ", DataViewRowState.CurrentRows)

                If WK_DtView1.Count <> 0 Then

                    '��v��������f�[�^��wSEQ1�ɕۏ؃f�[�^��SEQ���L����ۏ؃f�[�^��wSEQ1�ɔ���f�[�^��SEQ��P��2���L��
                    strSQL = "UPDATE [02_����f�[�^]"
                    strSQL += " SET wSEQ1 = " & WK_DtView1(0)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    strSQL = "UPDATE [02_����f�[�^]"
                    strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    strSQL += ", �P��2 = " & DtView1(i)("�ۏؗ�") & ""
                    strSQL += ", sprice = " & DtView1(i)("�P��2") & ""
                    strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                End If
            Next i

            'MsgBox("�ۏ؃f�[�^�ƍ�����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()
    End Sub

    Private Sub PB_chk2() 'PB�f�[�^�ƍ�_�Œ�
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_wrn_chk_PB_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "wrn_chk")
        DtView1 = New DataView(DsList1.Tables("wrn_chk"), "", "SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "PB�i�Œ�j�ۏ؃f�[�^�ƍ����Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                '�`�[�ԍ��Ə��i���ނ���v����ۏ؃f�[�^������
                WK_DsList1.Clear()
                strSQL = "SELECT �`�[NO, [���i����], �i����, �^�Զ�, [���޺���], �P��2, SEQ, �ԍ�SEQ, sprice, WSEQ1"
                strSQL += " FROM [02_����f�[�^]"
                strSQL += " WHERE (������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (ERR_F IS NULL)"
                strSQL += " AND ([���i����] = '0400000069814' OR [���i����] = '0400000091419')"
                strSQL += " AND (�`�[NO = '" & DtView1(i)("�`�[NO") & "')"
                strSQL += " AND (�ԍ�SEQ = 0)"
                strSQL += " AND (WSEQ1 = 0)"
                strSQL += " AND ([���޺���] = '30' OR [���޺���] = '91')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("wrn_chk2"), "", "SEQ", DataViewRowState.CurrentRows)

                If WK_DtView1.Count <> 0 Then

                    Dim a1, a2, a3 As String
                    a1 = DtView1(i)("PB�P��2")

                    '��v��������f�[�^��wSEQ1�ɕۏ؃f�[�^��SEQ���L����ۏ؃f�[�^��wSEQ1�ɔ���f�[�^��SEQ��P��2���L��
                    strSQL = "UPDATE [02_����f�[�^]"
                    strSQL += " SET wSEQ1 = " & WK_DtView1(0)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    If DtView1(i)("PB�P��2") = 0 Then
                        strSQL = "UPDATE [02_����f�[�^]"
                        strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                        strSQL += ", �P��2 = " & DtView1(i)("�ۏؗ�") & ""
                        strSQL += ", sprice = " & DtView1(i)("�P��") & ""
                        strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    Else
                        If DtView1(i)("���s��") >= "20110310" Then
                            strSQL = "UPDATE [02_����f�[�^]"
                            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                            strSQL += ", �P��2 = " & DtView1(i)("PB�ۏؗ�2") & ""
                            strSQL += ", sprice = " & DtView1(i)("PB�P��2") & ""
                            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                        Else
                            strSQL = "UPDATE [02_����f�[�^]"
                            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                            strSQL += ", �P��2 = " & DtView1(i)("�ۏؗ�") & ""
                            strSQL += ", sprice = " & DtView1(i)("�P��") & ""
                            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                        End If
                    End If

                    ''�C���M�����[����
                    ''�uLE-M22D210 W/B�v��2011/03/10�ȍ~�͕ۏؗ���1339�~
                    'Select Case DtView1(i)("�^�Զ�")
                    '    Case Is = "LE-M22D210", "LE-M22D210 B", "LE-M22D210 W"
                    '        If DtView1(i)("���s��") >= "20110310" Then
                    '            strSQL = "UPDATE [02_����f�[�^]"
                    '            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    '            strSQL += ", �P��2 = 1339"
                    '            strSQL += ", sprice = 26780"
                    '            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    '            SqlCmd1.ExecuteNonQuery()
                    '        Else
                    '            strSQL = "UPDATE [02_����f�[�^]"
                    '            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    '            strSQL += ", �P��2 = " & DtView1(i)("�ۏؗ�") & ""
                    '            strSQL += ", sprice = " & DtView1(i)("�P��") & ""
                    '            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    '            SqlCmd1.ExecuteNonQuery()
                    '        End If
                    '    Case Else
                    '        strSQL = "UPDATE [02_����f�[�^]"
                    '        strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    '        strSQL += ", �P��2 = " & DtView1(i)("�ۏؗ�") & ""
                    '        strSQL += ", sprice = " & DtView1(i)("�P��") & ""
                    '        strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    '        SqlCmd1.ExecuteNonQuery()
                    'End Select
                End If
            Next i

            'MsgBox("�ۏ؃f�[�^�ƍ�����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()
    End Sub

    Private Sub AC_Mach()   '�G�A�R���}�b�`���O
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r1 = DaList1.Fill(DsList1, "err_chk_01")
        If r1 <> 0 Then

            ''�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�G�A�R���}�b�`���O���Ă��܂��B"
            waitDlg.ProgressMax = r1        ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()          '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            DtView1 = New DataView(DsList1.Tables("err_chk_01"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()      ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()       ' �����J�E���g��1�X�e�b�v�i�߂�

                DsList2.Clear()
                SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_01_2", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
                Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 14)
                Pram2.Value = P_DATE
                Pram3.Value = DtView1(i)("�`�[NO")
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                r2 = DaList1.Fill(DsList2, "err_chk_01_2")

                If r2 <> 0 Then
                    DtView2 = New DataView(DsList2.Tables("err_chk_01_2"), "", "", DataViewRowState.CurrentRows)
                    For j = 0 To DtView2.Count - 1
                        If DtView2(j)("flg") = "0" Then

                            For k = j + 1 To DtView2.Count - 1
                                If DtView2(k)("flg") = "0" Then

                                    If (DtView2(j)("�P��2") + DtView2(k)("�P��2")) * 0.05 - DtView1(i)("�P��2") <= 1 _
                                        And (DtView2(j)("�P��2") + DtView2(k)("�P��2")) * 0.05 - DtView1(i)("�P��2") >= -1 Then

                                        strSQL = "UPDATE [02_����f�[�^]"
                                        strSQL += " SET sprice = " & DtView2(j)("�P��2") + DtView2(k)("�P��2") & ""
                                        strSQL += ", WSEQ1 = " & DtView2(j)("SEQ") & ""
                                        strSQL += ", WSEQ2 = " & DtView2(k)("SEQ") & ""
                                        strSQL += ", ERR_F = '0'"
                                        strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()

                                        strSQL = "UPDATE [02_����f�[�^]"
                                        strSQL += " SET"
                                        strSQL += " WSEQ1 = " & DtView1(i)("SEQ")
                                        strSQL += " WHERE (SEQ = " & DtView2(j)("SEQ") & ")"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()

                                        strSQL = "UPDATE [02_����f�[�^]"
                                        strSQL += " SET"
                                        strSQL += " WSEQ2 = " & DtView1(i)("SEQ")
                                        strSQL += " WHERE (SEQ = " & DtView2(k)("SEQ") & ")"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()

                                        GoTo ex_for
                                    End If
                                    DtView2(k)("flg") = "1"
                                End If
                            Next
                            DtView2(j)("flg") = "1"
                        End If
                    Next
ex_for:
                End If
            Next i

            'MsgBox("�G�A�R���}�b�`���O����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()
    End Sub

    Private Sub CAT_Mach()   '�i��G���[�R�[�h_�t�^
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_02", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_02")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_02"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ''�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�i��G���[�R�[�h_�t�^���Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strSQL = "UPDATE [02_����f�[�^]"
                strSQL += " SET ERR_F = '1'"
                strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next i

            'MsgBox("�i��G���[�R�[�h_�t�^����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()

    End Sub

    Private Sub wrn_fee_Mach()   '�ۏؗ��G���[�R�[�h_�t�^
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_03", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_03")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ''�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            waitDlg.MainMsg = "�ۏؗ��G���[�R�[�h_�t�^���Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strSQL = "UPDATE [02_����f�[�^]"
                strSQL += " SET ERR_F = '2'"
                strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next i

            'MsgBox("�ۏؗ��G���[�R�[�h_�t�^����")
            'waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
            'Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
        End If
        DB_CLOSE()
    End Sub

    Private Sub low_prc()       '���z��������
        DB_OPEN()

        '�ۏؗ�<525 �G���[
        strSQL = "UPDATE [02_����f�[�^]"
        strSQL += " SET ERR_F = '1'"
        'strSQL += " WHERE (������ = CONVERT(DATETIME, " & P_DATE & ", 102))"

        '*** 2014/02/06 ���t�p�����[�^�ɃV���O���N�H�[�e�[�V������ǉ�
        strSQL += " WHERE (������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
        strSQL += " AND (���޺��� = '91' OR ���޺��� = '30')"
        strSQL += " AND (�P��2 < 525)"
        strSQL += " AND (dlt_f = 0)"
        strSQL += " AND (ERR_F = '0' OR ERR_F IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        ''�w�����i<10500 �G���[
        'strSQL = "UPDATE [02_����f�[�^]"
        'strSQL += " SET ERR_F = '1'"
        'strSQL += " FROM [02_����f�[�^] INNER JOIN"
        'strSQL += " M_category ON [02_����f�[�^].�i���� = M_category.CAT_CODE"
        'strSQL += " WHERE ([02_����f�[�^].������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
        'strSQL += " AND ([02_����f�[�^].�P��2 < 10500)"
        'strSQL += " AND ([02_����f�[�^].dlt_f = 0)"
        'strSQL += " AND ([02_����f�[�^].ERR_F = '0' OR [02_����f�[�^].ERR_F IS NULL)"
        'strSQL += " AND (M_category.CAT_CODE IS NOT NULL)"
        'strSQL += " AND ([02_����f�[�^].���޺��� <> '30') AND ([02_����f�[�^].���޺��� <> '91') AND ([02_����f�[�^].���޺��� <> '7')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
    End Sub

    Private Sub err_F_upd()     '�G���[�t���O=Null��0�ɍX�V
        DB_OPEN()
        strSQL = "UPDATE [02_����f�[�^]"
        strSQL += " SET ERR_F = '0'"
        strSQL += " WHERE (ERR_F IS NULL) OR (ERR_F = '')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub

    Private Sub cat_err()      '�i��G���[
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_05", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_05")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            waitDlg.MainMsg = "�i��̃`�F�b�N���Ă��܂��B"
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           '�ŏ��̌�����ݒ�
            Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            Dim wk_err As String
            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                wk_err = "0"
                If IsDBNull(DtView1(i)("avlbty")) = True Then
                    wk_err = "1"
                Else
                    If DtView1(i)("avlbty") = "false" Then
                        wk_err = "1"
                    End If
                End If

                If wk_err = "1" Then
                    'strSQL = "UPDATE [02_����f�[�^]"
                    'strSQL += " SET ERR_F = '4'"
                    'strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    'SqlCmd1.ExecuteNonQuery()

                    If DtView1(i)("WSEQ1") <> "0" Then
                        strSQL = "UPDATE [02_����f�[�^]"
                        strSQL += " SET ERR_F = '4'"
                        strSQL += " WHERE (SEQ = " & DtView1(i)("WSEQ1") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If

                    If DtView1(i)("WSEQ2") <> "0" Then
                        strSQL = "UPDATE [02_����f�[�^]"
                        strSQL += " SET ERR_F = '4'"
                        strSQL += " WHERE (SEQ = " & DtView1(i)("WSEQ2") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If
                End If
            Next i

        End If
        DB_CLOSE()
    End Sub

    Private Sub rakuten()       '�y�V���O
        DB_OPEN()
        strSQL = "UPDATE [02_����f�[�^]"
        strSQL += " SET dlt_f = 1"
        strSQL += " WHERE (�z���X���� = '5009')"
        strSQL += " AND (dlt_f = 0)"
        strSQL += " AND (������2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub
    '*********************************************************************************
    '**  �߂�
    '*********************************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        If Date1.Text <> Format(max_date, "yyyy/MM") Then
            MsgBox("�Ō�̎�荞�݈ȊO�͖߂��܂���B")
            Date1.Focus()
            Exit Sub
        End If

        ans = MsgBox(Date1.Text & " �̃f�[�^���폜���܂��B", MsgBoxStyle.OKCancel)
        If ans = "2" Then Exit Sub 'Cancel

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()

        strSQL = "DELETE FROM [01_�捞�f�[�^]"
        strSQL += " WHERE (������ = CONVERT(DATETIME, '" & Date1.Text & "/01', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DELETE FROM [02_����f�[�^]"
        strSQL += " WHERE (������ = CONVERT(DATETIME, '" & Date1.Text & "/01', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()

        inz()   '**  ��������
        MsgBox("��荞�݊���")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  �I��
    '*********************************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub

    '*********************************************************************************
    '**  �G���[���X�g(CSV)
    '*********************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()
        P_DATE = Date1.Text & "/01'"

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_list", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_list")
        DtView1 = New DataView(DsList1.Tables("sp_err_list"), "", "�`�[NO, SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "�G���[�`�F�b�N���X�g_" & Format(P_DATE, "yyyyMM") & ".CSV"     '�͂��߂̃t�@�C�������w�肷��
            sfd.Filter = "CSV�t�@�C��(*.CSV)|*.CSV"                 '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
            sfd.FilterIndex = 2                                     '[�t�@�C���̎��]�ł͂��߂� �u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
            sfd.Title = "�ۑ���̃t�@�C����I�����Ă�������"        '�^�C�g����ݒ肷��
            sfd.RestoreDirectory = True                             '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���

            '���ɑ��݂���t�@�C�������w�肵���Ƃ��x������
            '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.OverwritePrompt = True

            '���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
            '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.CheckPathExists = True

            If sfd.ShowDialog() = DialogResult.OK Then     '�_�C�A���O��\������
                filename = sfd.FileName   'OK�{�^�����N���b�N���ꂽ�Ƃ�

                '�i�s�󋵃_�C�A���O�̏���������()
                waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
                waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
                waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
                waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
                waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
                waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
                Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
                waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
                waitDlg.MainMsg = "�G���[���X�g�o�͒�"
                waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
                Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim swFile As New System.IO.StreamWriter(filename, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

                '�f�[�^����������
                strData = "�`�[NO,���s��,�z���X�R�[�h,��ʔ��|�敪,����,TEL1,TEL2,�X�֔ԍ�,�Z��1,�Z��2,�Z��3,�Z��4,�Z��5"
                strData = strData & ",�̔��҃R�[�h,������,�폜�t���O,�s�ԍ�,�s�敪,���i�R�[�h,�i���J�i,�^�ԃJ�i,�J���[,�T�C�Y"
                strData = strData & ",���V�[�g,�i������,�^�Ԋ���,���ރR�[�h,�i��R�[�h,���㐔,�}�X�^�P��,�P��,�ŋ敪,�l�������敪"
                strData = strData & ",������,�l���z,�P��2,qty,SEQ,SEQ1,rbSEQ,sprice,wSEQ,wSEQ2,err,biz,�������@"
                swFile.WriteLine(strData)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = DtView1(i)("�`�[NO")
                    strData = strData & "," & DtView1(i)("���s��")
                    strData = strData & "," & DtView1(i)("�z���X����")
                    strData = strData & "," & DtView1(i)("��ʔ��|�敪")
                    strData = strData & "," & DtView1(i)("����")
                    strData = strData & "," & DtView1(i)("TEL1")
                    strData = strData & "," & DtView1(i)("TEL2")
                    strData = strData & "," & DtView1(i)("�X�֔ԍ�")
                    strData = strData & "," & DtView1(i)("�Z��1")
                    strData = strData & "," & DtView1(i)("�Z��2")
                    strData = strData & "," & DtView1(i)("�Z��3")
                    strData = strData & "," & DtView1(i)("�Z��4")
                    strData = strData & "," & DtView1(i)("�Z��5")
                    strData = strData & "," & DtView1(i)("�̔��Һ���")
                    strData = strData & "," & DtView1(i)("������")
                    strData = strData & "," & DtView1(i)("�폜�׸�")
                    strData = strData & "," & DtView1(i)("�s�ԍ�")
                    strData = strData & "," & DtView1(i)("�s�敪")
                    strData = strData & "," & DtView1(i)("���i����")
                    strData = strData & "," & DtView1(i)("�i����")
                    strData = strData & "," & DtView1(i)("�^�Զ�")
                    strData = strData & "," & DtView1(i)("�װ")
                    strData = strData & "," & DtView1(i)("����")
                    strData = strData & "," & DtView1(i)("ڼ��")
                    strData = strData & "," & DtView1(i)("�i������")
                    strData = strData & "," & DtView1(i)("�^�Ԋ���")
                    strData = strData & "," & DtView1(i)("���޺���")
                    strData = strData & "," & DtView1(i)("�i����")
                    strData = strData & "," & DtView1(i)("���㐔")
                    strData = strData & "," & DtView1(i)("Ͻ��P��")
                    strData = strData & "," & DtView1(i)("�P��")
                    strData = strData & "," & DtView1(i)("�ŋ敪")
                    strData = strData & "," & DtView1(i)("�l�������敪")
                    strData = strData & "," & DtView1(i)("������")
                    strData = strData & "," & DtView1(i)("�l���z")
                    strData = strData & "," & DtView1(i)("�P��2")
                    strData = strData & "," & DtView1(i)("��������")
                    strData = strData & "," & DtView1(i)("SEQ")
                    strData = strData & "," & DtView1(i)("������SEQ")
                    strData = strData & "," & DtView1(i)("�ԍ�SEQ")
                    strData = strData & "," & DtView1(i)("sprice")
                    strData = strData & "," & DtView1(i)("WSEQ1")
                    strData = strData & "," & DtView1(i)("WSEQ2")
                    strData = strData & "," & DtView1(i)("ERR_F")
                    strData = strData & "," & DtView1(i)("�@�l")
                    swFile.WriteLine(strData)

                Next i

                swFile.Close()          '�t�@�C�������
                MsgBox("�G���[���X�g�o�͊���")
                waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
            End If
        End If
        DB_CLOSE()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  OK ���X�g(CSV)
    '*********************************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()
        P_DATE = Date1.Text & "/01'"

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_ok_list", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 7200
        DaList1.Fill(DsList1, "sp_err_list")
        DtView1 = New DataView(DsList1.Tables("sp_err_list"), "", "�`�[NO, SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "�n�j���X�g_" & Format(P_DATE, "yyyyMM") & ".CSV"     '�͂��߂̃t�@�C�������w�肷��
            sfd.Filter = "CSV�t�@�C��(*.CSV)|*.CSV"                 '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
            sfd.FilterIndex = 2                                     '[�t�@�C���̎��]�ł͂��߂� �u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
            sfd.Title = "�ۑ���̃t�@�C����I�����Ă�������"        '�^�C�g����ݒ肷��
            sfd.RestoreDirectory = True                             '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���

            '���ɑ��݂���t�@�C�������w�肵���Ƃ��x������
            '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.OverwritePrompt = True

            '���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
            '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.CheckPathExists = True

            If sfd.ShowDialog() = DialogResult.OK Then     '�_�C�A���O��\������
                filename = sfd.FileName   'OK�{�^�����N���b�N���ꂽ�Ƃ�

                '�i�s�󋵃_�C�A���O�̏���������()
                waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
                waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
                waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
                waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
                waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
                waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
                Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
                waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
                waitDlg.MainMsg = "�n�j���X�g�o�͒�"
                waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
                Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim swFile As New System.IO.StreamWriter(filename, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

                '�f�[�^����������
                strData = "�`�[NO,���s��,�z���X�R�[�h,��ʔ��|�敪,����,TEL1,TEL2,�X�֔ԍ�,�Z��1,�Z��2,�Z��3,�Z��4,�Z��5"
                strData = strData & ",�̔��҃R�[�h,������,�폜�t���O,�s�ԍ�,�s�敪,���i�R�[�h,�i���J�i,�^�ԃJ�i,�J���[,�T�C�Y"
                strData = strData & ",���V�[�g,�i������,�^�Ԋ���,���ރR�[�h,�i��R�[�h,���㐔,�}�X�^�P��,�P��,�ŋ敪,�l�������敪"
                strData = strData & ",������,�l���z,�P��2,qty,SEQ,SEQ1,rbSEQ,sprice,wSEQ,wSEQ2,err,biz,�������@"
                swFile.WriteLine(strData)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = DtView1(i)("�`�[NO")
                    strData = strData & "," & DtView1(i)("���s��")
                    strData = strData & "," & DtView1(i)("�z���X����")
                    strData = strData & "," & DtView1(i)("��ʔ��|�敪")
                    strData = strData & "," & DtView1(i)("����")
                    strData = strData & "," & DtView1(i)("TEL1")
                    strData = strData & "," & DtView1(i)("TEL2")
                    strData = strData & "," & DtView1(i)("�X�֔ԍ�")
                    strData = strData & "," & DtView1(i)("�Z��1")
                    strData = strData & "," & DtView1(i)("�Z��2")
                    strData = strData & "," & DtView1(i)("�Z��3")
                    strData = strData & "," & DtView1(i)("�Z��4")
                    strData = strData & "," & DtView1(i)("�Z��5")
                    strData = strData & "," & DtView1(i)("�̔��Һ���")
                    strData = strData & "," & DtView1(i)("������")
                    strData = strData & "," & DtView1(i)("�폜�׸�")
                    strData = strData & "," & DtView1(i)("�s�ԍ�")
                    strData = strData & "," & DtView1(i)("�s�敪")
                    strData = strData & "," & DtView1(i)("���i����")
                    strData = strData & "," & DtView1(i)("�i����")
                    strData = strData & "," & DtView1(i)("�^�Զ�")
                    strData = strData & "," & DtView1(i)("�װ")
                    strData = strData & "," & DtView1(i)("����")
                    strData = strData & "," & DtView1(i)("ڼ��")
                    strData = strData & "," & DtView1(i)("�i������")
                    strData = strData & "," & DtView1(i)("�^�Ԋ���")
                    strData = strData & "," & DtView1(i)("���޺���")
                    strData = strData & "," & DtView1(i)("�i����")
                    strData = strData & "," & DtView1(i)("���㐔")
                    strData = strData & "," & DtView1(i)("Ͻ��P��")
                    strData = strData & "," & DtView1(i)("�P��")
                    strData = strData & "," & DtView1(i)("�ŋ敪")
                    strData = strData & "," & DtView1(i)("�l�������敪")
                    strData = strData & "," & DtView1(i)("������")
                    strData = strData & "," & DtView1(i)("�l���z")
                    strData = strData & "," & DtView1(i)("�P��2")
                    strData = strData & "," & DtView1(i)("��������")
                    strData = strData & "," & DtView1(i)("SEQ")
                    strData = strData & "," & DtView1(i)("������SEQ")
                    strData = strData & "," & DtView1(i)("�ԍ�SEQ")
                    strData = strData & "," & DtView1(i)("sprice")
                    strData = strData & "," & DtView1(i)("WSEQ1")
                    strData = strData & "," & DtView1(i)("WSEQ2")
                    strData = strData & "," & DtView1(i)("ERR_F")
                    strData = strData & "," & DtView1(i)("�@�l")
                    swFile.WriteLine(strData)

                Next i

                swFile.Close()          '�t�@�C�������
                MsgBox("�n�j���X�g�o�͊���")
                waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
            End If
        End If
        DB_CLOSE()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  �@�l���X�g(CSV)
    '*********************************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()
        P_DATE = Date1.Text & "/01'"

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_biz_list", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_biz_list")
        DtView1 = New DataView(DsList1.Tables("sp_biz_list"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "�@�l�`�F�b�N���X�g_" & Format(P_DATE, "yyyyMM") & ".CSV"    '�͂��߂̃t�@�C�������w�肷��
            sfd.Filter = "CSV�t�@�C��(*.CSV)|*.CSV"                 '[�t�@�C���̎��]�ɕ\�������I�������w�肷��
            sfd.FilterIndex = 2                                     '[�t�@�C���̎��]�ł͂��߂� �u���ׂẴt�@�C���v���I������Ă���悤�ɂ���
            sfd.Title = "�ۑ���̃t�@�C����I�����Ă�������"        '�^�C�g����ݒ肷��
            sfd.RestoreDirectory = True                             '�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���

            '���ɑ��݂���t�@�C�������w�肵���Ƃ��x������
            '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.OverwritePrompt = True

            '���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
            '�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.CheckPathExists = True

            If sfd.ShowDialog() = DialogResult.OK Then     '�_�C�A���O��\������
                filename = sfd.FileName   'OK�{�^�����N���b�N���ꂽ�Ƃ�

                '�i�s�󋵃_�C�A���O�̏���������()
                waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
                waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
                waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
                waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
                waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
                waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
                Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
                waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
                waitDlg.MainMsg = "�@�l���X�g�o�͒�"
                waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
                Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim swFile As New System.IO.StreamWriter(filename, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

                '�f�[�^����������
                strData = "�@�l=1,�`�[NO,���s��,�z���X�R�[�h,��ʔ��|�敪,����,TEL1,TEL2,�X�֔ԍ�,�Z��1,�Z��2,�Z��3,�Z��4,�Z��5"
                strData = strData & ",�̔��҃R�[�h,������,�폜�t���O,�s�ԍ�,�s�敪,���i�R�[�h,�i���J�i,�^�ԃJ�i,�J���[,�T�C�Y"
                strData = strData & ",���V�[�g,�i������,�^�Ԋ���,���ރR�[�h,�i��R�[�h,���㐔,�}�X�^�P��,�P��,�ŋ敪,�l�������敪"
                strData = strData & ",������,�l���z,�P��2,qty,SEQ,SEQ1,rbSEQ,sprice,wSEQ,wSEQ2,err,biz"
                swFile.WriteLine(strData)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = ""
                    strData = strData & "," & DtView1(i)("�`�[NO")
                    strData = strData & "," & DtView1(i)("���s��")
                    strData = strData & "," & DtView1(i)("�z���X����")
                    strData = strData & "," & DtView1(i)("��ʔ��|�敪")
                    strData = strData & "," & DtView1(i)("����")
                    strData = strData & "," & DtView1(i)("TEL1")
                    strData = strData & "," & DtView1(i)("TEL2")
                    strData = strData & "," & DtView1(i)("�X�֔ԍ�")
                    strData = strData & "," & DtView1(i)("�Z��1")
                    strData = strData & "," & DtView1(i)("�Z��2")
                    strData = strData & "," & DtView1(i)("�Z��3")
                    strData = strData & "," & DtView1(i)("�Z��4")
                    strData = strData & "," & DtView1(i)("�Z��5")
                    strData = strData & "," & DtView1(i)("�̔��Һ���")
                    strData = strData & "," & DtView1(i)("������")
                    strData = strData & "," & DtView1(i)("�폜�׸�")
                    strData = strData & "," & DtView1(i)("�s�ԍ�")
                    strData = strData & "," & DtView1(i)("�s�敪")
                    strData = strData & "," & DtView1(i)("���i����")
                    strData = strData & "," & DtView1(i)("�i����")
                    strData = strData & "," & DtView1(i)("�^�Զ�")
                    strData = strData & "," & DtView1(i)("�װ")
                    strData = strData & "," & DtView1(i)("����")
                    strData = strData & "," & DtView1(i)("ڼ��")
                    strData = strData & "," & DtView1(i)("�i������")
                    strData = strData & "," & DtView1(i)("�^�Ԋ���")
                    strData = strData & "," & DtView1(i)("���޺���")
                    strData = strData & "," & DtView1(i)("�i����")
                    strData = strData & "," & DtView1(i)("���㐔")
                    strData = strData & "," & DtView1(i)("Ͻ��P��")
                    strData = strData & "," & DtView1(i)("�P��")
                    strData = strData & "," & DtView1(i)("�ŋ敪")
                    strData = strData & "," & DtView1(i)("�l�������敪")
                    strData = strData & "," & DtView1(i)("������")
                    strData = strData & "," & DtView1(i)("�l���z")
                    strData = strData & "," & DtView1(i)("�P��2")
                    strData = strData & "," & DtView1(i)("��������")
                    strData = strData & "," & DtView1(i)("SEQ")
                    strData = strData & "," & DtView1(i)("������SEQ")
                    strData = strData & "," & DtView1(i)("�ԍ�SEQ")
                    strData = strData & "," & DtView1(i)("sprice")
                    strData = strData & "," & DtView1(i)("WSEQ1")
                    strData = strData & "," & DtView1(i)("WSEQ2")
                    strData = strData & "," & DtView1(i)("ERR_F")
                    strData = strData & "," & DtView1(i)("�@�l")
                    swFile.WriteLine(strData)

                Next i

                swFile.Close()          '�t�@�C�������
                MsgBox("�@�l���X�g�o�͊���")
                waitDlg.Close()                 '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True               '�I�[�i�[�̃t�H�[����L���ɂ���
            End If
        End If
        DB_CLOSE()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  �@�l�I��
    '*********************************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        F_chk2()
        If Err_F = "0" Then
            Dim Form2 As New Form2
            Form2.ShowDialog()
        End If
    End Sub

    '*********************************************************************************
    '**  �G���[�C��
    '*********************************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        F_chk2()
        If Err_F = "0" Then
            P_PRAM = "�ʏ�"
            Dim Form3 As New Form3
            Form3.ShowDialog()
        End If
    End Sub

    ''*********************************************************************************
    ''**  �G���[�C��(�ڷޭװ)
    ''*********************************************************************************
    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    F_chk2()
    '    If Err_F = "0" Then
    '        P_PRAM = "�ڷޭװ"
    '        Dim Form3 As New Form3
    '        Form3.ShowDialog()
    '    End If
    'End Sub

    '*********************************************************************************
    '**  �G���[�C��(�����)
    '*********************************************************************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Form4 As New Form4
        Form4.ShowDialog()
    End Sub

    '*********************************************************************************
    '**  �@��o�^
    '*********************************************************************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        F_chk2()
        If Err_F = "0" Then
            Dim Form5 As New Form5
            Form5.ShowDialog()
        End If
    End Sub

    '*********************************************************************************
    '**  �ۏؓo�^
    '*********************************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        F_chk2()
        If Err_F = "0" Then
            Dim Form6 As New Form6
            Form6.ShowDialog()
        End If
    End Sub

    ''*********************************************************************************
    ''**  �y�V���O
    ''*********************************************************************************
    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
    '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '    F_chk2()
    '    If Err_F = "0" Then

    '        strSQL = "UPDATE [02_����f�[�^]"
    '        strSQL += " SET dlt_f = 1"
    '        strSQL += " WHERE (�z���X���� = 5009)"
    '        strSQL += " AND (dlt_f = 0)"
    '        strSQL += " AND (������2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
    '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '        DB_OPEN()
    '        SqlCmd1.ExecuteNonQuery()
    '        DB_CLOSE()

    '        MsgBox("�y�V���O����")
    '    End If
    '    Me.Cursor = System.Windows.Forms.Cursors.Default
    'End Sub

    '*********************************************************************************
    '**  �����\�o��
    '*********************************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        On Error GoTo err_prc
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim BR_Key As String

        F_chk2()
        If Err_F = "0" Then
            DB_OPEN()

            '�W�v�敪�N���A
            strSQL = "UPDATE [02_����f�[�^] SET �W�v�敪 = NULL WHERE (�W�v�敪 IS NOT NULL) AND (������2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '�W�v�敪(biz)
            strSQL = "UPDATE [02_����f�[�^]"
            strSQL += " SET �W�v�敪 = 'biz'"
            strSQL += " WHERE (�W�v�敪 IS NULL)"
            strSQL += " AND (������ = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            strSQL += " AND ((���޺��� = '30') OR (���޺��� = '91'))"
            strSQL += " AND (�@�l = 1)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '�W�v�敪(rb)
            strSQL = "UPDATE [02_����f�[�^]"
            strSQL += " SET �W�v�敪 = 'rb'"
            strSQL += " WHERE (�W�v�敪 IS NULL)"
            strSQL += " AND (������2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            strSQL += " AND ((���޺��� = '30') OR (���޺��� = '91'))"
            strSQL += " AND (�ԍ�SEQ <> 0)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '�W�v�敪(err)
            strSQL = "UPDATE [02_����f�[�^]"
            strSQL += " SET �W�v�敪 = 'err'"
            strSQL += " WHERE (�W�v�敪 IS NULL)"
            strSQL += " AND (������2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            strSQL += " AND ((���޺��� = '30') OR (���޺��� = '91'))"
            strSQL += " AND (ERR_F <> '0')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '==================  �N�����̏���  ===================  
            Dim xlApp As New Excel.Application
            Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
            '�����̃t�@�C�����J���ꍇ
            Dim xlFilePath As String = dir & "\�����\.xls"
            Dim xlBook As Excel.Workbook = xlBooks.Open(xlFilePath)
            Dim xlSheets As Excel.Sheets = xlBook.Worksheets
            Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
            xlApp.Visible = False

            '*****************************
            '** Max�������؃V�[�g
            '*****************************
            '==============
            ' 2015/07/08�@�������؃V�[�g�͋Ɩ��㖢�g�p
            ' �i��ǉ����ɃG���[���������邽�߃R�����g�A�E�g
            '==============

            '==================  �f�[�^�̓��͏���  ==================  
            'xlSheet = xlSheets.Item(1)  'Sheet1
            'Dim xlRange As Excel.Range
            'Dim strDat(18, 7) As Object
            'xlRange = xlSheet.Range("C4:I21")    '�f�[�^�̓��̓Z���͈�

            'DsList1.Clear()
            'SqlCmd1 = New SqlClient.SqlCommand("sp_glist_cnt", cnsqlclient)
            'SqlCmd1.CommandType = CommandType.StoredProcedure
            'Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            'Pram1.Value = P_DATE
            'DaList1.SelectCommand = SqlCmd1
            'SqlCmd1.CommandTimeout = 3600
            'DaList1.Fill(DsList1, "sp_glist_cnt")
            'DtView1 = New DataView(DsList1.Tables("sp_glist_cnt"), "", "", DataViewRowState.CurrentRows)
            'If DtView1.Count <> 0 Then

            '�i�s�󋵃_�C�A���O�̏���������()
            'waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
            'waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
            'waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
            'waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
            'waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
            'waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
            'Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            'waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
            'waitDlg.MainMsg = "�������ؒ��o��"
            'waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            'Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

            'BR_Key = DtView1(0)("cls_code_name")
            'p = 0

            'For i = 0 To DtView1.Count - 1
            'If IsDBNull(DtView1(i)("��M����")) = True Then DtView1(i)("��M����") = 0
            'If IsDBNull(DtView1(i)("��������")) = True Then DtView1(i)("��������") = 0
            'If IsDBNull(DtView1(i)("�ړ�����1")) = True Then DtView1(i)("�ړ�����1") = 0
            'If IsDBNull(DtView1(i)("�ړ�����2")) = True Then DtView1(i)("�ړ�����2") = 0
            'If IsDBNull(DtView1(i)("�ԍ�����")) = True Then DtView1(i)("�ԍ�����") = 0
            'If IsDBNull(DtView1(i)("err����")) = True Then DtView1(i)("err����") = 0
            'If IsDBNull(DtView1(i)("err��������")) = True Then DtView1(i)("err��������") = 0
            'DtView1(i)("�ړ�����1") = DtView1(i)("�ړ�����1") - DtView1(i)("�ړ�����2")

            'waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
            'Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
            'waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

            'If BR_Key <> DtView1(i)("cls_code_name") Then
            'j = i + p
            'strDat(j, 0) = "=SUM(C" & j + 3 & ":C" & j + 2 & ")"
            'strDat(j, 1) = "=SUM(D" & j + 3 & ":D" & j + 2 & ")"
            'strDat(j, 2) = "=SUM(E" & j + 3 & ":E" & j + 2 & ")"
            'strDat(j, 3) = "=D" & j + 4 & "+E" & j + 4
            'strDat(j, 4) = "=SUM(G" & j + 3 & ":G" & j + 2 & ")"
            'strDat(j, 5) = "=SUM(H" & j + 3 & ":H" & j + 2 & ")"
            'strDat(j, 6) = "=SUM(I" & j + 3 & ":I" & j + 2 & ")"
            'strDat(j, 7) = "=F" & j + 4 & "-G" & j + 4 & "-H" & j + 4 & "+I" & j + 4

            'BR_Key = DtView1(i)("cls_code_name")
            'p = p + 2
            'End If

            'j = i + p
            'strDat(j, 0) = DtView1(i)("��M����")
            'strDat(j, 1) = DtView1(i)("��������")
            'strDat(j, 2) = DtView1(i)("�ړ�����1")
            'strDat(j, 3) = "=D" & j + 4 & "+E" & j + 4
            'strDat(j, 4) = DtView1(i)("�ԍ�����")
            'strDat(j, 5) = DtView1(i)("err����")
            'strDat(j, 6) = DtView1(i)("err��������")
            'strDat(j, 7) = "=F" & j + 4 & "-G" & j + 4 & "-H" & j + 4 & "+I" & j + 4

            'Next
            'j = i + p
            'strDat(j, 0) = "=SUM(C" & j + 3 & ":C" & j + 2 & ")"
            'strDat(j, 1) = "=SUM(D" & j + 3 & ":D" & j + 2 & ")"
            'strDat(j, 2) = "=SUM(E" & j + 3 & ":E" & j + 2 & ")"
            'strDat(j, 3) = "=D" & j + 4 & "+E" & j + 4
            'strDat(j, 4) = "=SUM(G" & j + 3 & ":G" & j + 2 & ")"
            'strDat(j, 5) = "=SUM(H" & j + 3 & ":H" & j + 2 & ")"
            'strDat(j, 6) = "=SUM(I" & j + 3 & ":I" & j + 2 & ")"
            'strDat(j, 7) = "=F" & j + 4 & "-G" & j + 4 & "-H" & j + 4 & "+I" & j + 4
            'End If
            'xlRange.Value = strDat          '�Z���փf�[�^�̓���
            'MRComObject(xlRange)            'xlRange �̉��

            '*****************************
            '** �����\
            '*****************************
            '==================  �f�[�^�̓��͏���  ==================  
            xlSheet = xlSheets.Item(2)  'Sheet2
            Dim xlRange2 As Excel.Range
            Dim strDat2(999, 9) As Object
            xlRange2 = xlSheet.Range("A2:I1000")    '�f�[�^�̓��̓Z���͈�
            Dim xlCells2 As Excel.Range
            Dim xlRange2_2 As Excel.Range

            strSQL = "DELETE W01_�����\"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_glist_W", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram2.Value = P_DATE
            SqlCmd1.CommandTimeout = 1800
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE  W01_�����\ SET �l���Osprice = [02_����f�[�^].�P��2"
            strSQL += " FROM  W01_�����\ INNER JOIN"
            strSQL += " [02_����f�[�^] ON W01_�����\.SEQ = [02_����f�[�^].WSEQ1 INNER JOIN"
            strSQL += " V_PB�Œ� ON [02_����f�[�^].�^�Զ� = V_PB�Œ�.�^�Զ�"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE W01_�����\ SET �l���Osprice = ���i���i WHERE (�l���Osprice IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_glist", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(DsList1, "sp_glist_glist")
            DtView1 = New DataView(DsList1.Tables("sp_glist_glist"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                '�i�s�󋵃_�C�A���O�̏���������()
                waitDlg = New WaitDialog        '�i�s�󋵃_�C�A���O
                waitDlg.Owner = Me              '�_�C�A���O�̃I�[�i�[��ݒ肷��
                waitDlg.ProgressMax = 0         '�S�̂̏���������ݒ�
                waitDlg.ProgressMin = 0         '���������̍ŏ��l��ݒ�i0������J�n�j
                waitDlg.ProgressStep = 1        '�������ƂɃ��[�^��i�߂邩��ݒ�
                waitDlg.ProgressValue = 0       '�ŏ��̌�����ݒ�
                Me.Enabled = False              '�I�[�i�[�̃t�H�[���𖳌��ɂ���
                waitDlg.Show()                  '�i�s�󋵃_�C�A���O��\������
                waitDlg.MainMsg = "�����\���o��"
                waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
                Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    j = i
                    strDat2(j, 0) = DtView1(i)("�X�܃R�[�h")
                    strDat2(j, 1) = DtView1(i)("�X�ܖ�")
                    strDat2(j, 2) = DtView1(i)("���i��")
                    strDat2(j, 3) = DtView1(i)("����")
                    strDat2(j, 4) = DtView1(i)("���i���i")
                    strDat2(j, 5) = DtView1(i)("�ۏؗ�")
                    strDat2(j, 6) = DtView1(i)("�̔��萔��")
                    strDat2(j, 7) = DtView1(i)("RD��育�����z")
                    strDat2(j, 8) = DtView1(i)("�����ϑ���")
                Next
                j = j + 1
                strDat2(j, 3) = "=SUM(D2:D" & i + 1 & ")"
                strDat2(j, 4) = "=SUM(E2:E" & i + 1 & ")"
                strDat2(j, 5) = "=SUM(F2:F" & i + 1 & ")"
                strDat2(j, 6) = "=SUM(G2:G" & i + 1 & ")"
                strDat2(j, 7) = "=SUM(H2:H" & i + 1 & ")"
                strDat2(j, 8) = "=SUM(I2:I" & i + 1 & ")"

                j = j + 2
                xlCells2 = xlSheet.Cells
                xlRange2_2 = xlCells2(j, 4) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 5) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 6) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 7) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 8) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 9) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
            End If
            xlRange2.Value = strDat2            '�Z���փf�[�^�̓���
            MRComObject(xlRange2)               'xlRange �̉��
            MRComObject(xlRange2_2)             'xlRange �̉��

            '*****************************
            '** ����
            '*****************************
            '==================  �f�[�^�̓��͏���  ==================  
            xlSheet = xlSheets.Item(3)  'Sheet3
            Dim xlRange3 As Excel.Range
            Dim strDat3(49999, 43) As Object
            xlRange3 = xlSheet.Range("A2:AR50000")    '�f�[�^�̓��̓Z���͈�

            strSQL = "DELETE W02_����"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_dtl_W", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram3.Value = P_DATE
            SqlCmd1.CommandTimeout = 1800
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE W02_���� SET �l���Osprice = [02_����f�[�^].�P��2"
            strSQL += " FROM V_PB�Œ� INNER JOIN"
            strSQL += " [02_����f�[�^] ON V_PB�Œ�.�^�Զ� = [02_����f�[�^].�^�Զ� INNER JOIN"
            strSQL += " W02_���� ON [02_����f�[�^].SEQ = W02_����.WSEQ1"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE W02_���� SET �l���Osprice = sprice WHERE (�l���Osprice IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_dtl", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(DsList1, "sp_glist_dtl")
            DtView1 = New DataView(DsList1.Tables("sp_glist_dtl"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                waitDlg.MainMsg = "���ג��o��"
                waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
                Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    j = i
                    strDat3(j, 0) = DtView1(i)("�`�[NO")
                    strDat3(j, 1) = DtView1(i)("���s��")
                    strDat3(j, 2) = DtView1(i)("�z���X����")
                    strDat3(j, 3) = DtView1(i)("��ʔ��|�敪")
                    strDat3(j, 4) = DtView1(i)("����")
                    strDat3(j, 5) = DtView1(i)("TEL1")
                    strDat3(j, 6) = DtView1(i)("TEL2")
                    strDat3(j, 7) = DtView1(i)("�X�֔ԍ�")
                    strDat3(j, 8) = DtView1(i)("�Z��1")
                    strDat3(j, 9) = DtView1(i)("�Z��2")
                    strDat3(j, 10) = DtView1(i)("�Z��3")
                    strDat3(j, 11) = DtView1(i)("�Z��4")
                    strDat3(j, 12) = DtView1(i)("�Z��5")
                    strDat3(j, 13) = DtView1(i)("�̔��Һ���")
                    strDat3(j, 14) = DtView1(i)("������")
                    strDat3(j, 15) = DtView1(i)("�폜�׸�")
                    strDat3(j, 16) = DtView1(i)("�s�ԍ�")
                    strDat3(j, 17) = DtView1(i)("�s�敪")
                    strDat3(j, 18) = DtView1(i)("���i����")
                    strDat3(j, 19) = DtView1(i)("�i����")
                    strDat3(j, 20) = DtView1(i)("�^�Զ�")
                    strDat3(j, 21) = DtView1(i)("�װ")
                    strDat3(j, 22) = DtView1(i)("����")
                    strDat3(j, 23) = DtView1(i)("ڼ��")
                    strDat3(j, 24) = DtView1(i)("�i������")
                    strDat3(j, 25) = DtView1(i)("�^�Ԋ���")
                    strDat3(j, 26) = DtView1(i)("���޺���")
                    strDat3(j, 27) = DtView1(i)("�i����")
                    strDat3(j, 28) = DtView1(i)("���㐔")
                    strDat3(j, 29) = DtView1(i)("Ͻ��P��")
                    strDat3(j, 30) = DtView1(i)("�P��")
                    strDat3(j, 31) = DtView1(i)("�ŋ敪")
                    strDat3(j, 32) = DtView1(i)("�l�������敪")
                    strDat3(j, 33) = DtView1(i)("������")
                    strDat3(j, 34) = DtView1(i)("�l���z")
                    strDat3(j, 35) = DtView1(i)("�P��2")
                    strDat3(j, 36) = DtView1(i)("��������")
                    strDat3(j, 37) = DtView1(i)("SEQ")
                    strDat3(j, 38) = DtView1(i)("�l���Osprice")
                    strDat3(j, 39) = DtView1(i)("�̔��萔��")
                    strDat3(j, 40) = DtView1(i)("RD��育�����z")
                    strDat3(j, 41) = DtView1(i)("�����ϑ���")
                    strDat3(j, 42) = DtView1(i)("�^��1")
                    strDat3(j, 43) = DtView1(i)("�^��2")
                Next
            End If
            xlRange3.Value = strDat3            '�Z���փf�[�^�̓���
            MRComObject(xlRange3)               'xlRange �̉��

            '*****************************
            '** �G���[�ۗ�
            '*****************************
            '==================  �f�[�^�̓��͏���  ==================  
            xlSheet = xlSheets.Item(4)  'Sheet4
            Dim xlRange4 As Excel.Range
            Dim strDat4(9999, 44) As Object
            xlRange4 = xlSheet.Range("A2:AS1000")    '�f�[�^�̓��̓Z���͈�

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_err", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram4.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 1800
            DaList1.Fill(DsList1, "sp_glist_err")
            DtView1 = New DataView(DsList1.Tables("sp_glist_err"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                waitDlg.MainMsg = "�G���[�ۗ����o��"
                waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
                Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    j = i
                    strDat4(j, 0) = DtView1(i)("�`�[NO")
                    strDat4(j, 1) = DtView1(i)("���s��")
                    strDat4(j, 2) = DtView1(i)("�z���X����")
                    strDat4(j, 3) = DtView1(i)("��ʔ��|�敪")
                    strDat4(j, 4) = DtView1(i)("����")
                    strDat4(j, 5) = DtView1(i)("TEL1")
                    strDat4(j, 6) = DtView1(i)("TEL2")
                    strDat4(j, 7) = DtView1(i)("�X�֔ԍ�")
                    strDat4(j, 8) = DtView1(i)("�Z��1")
                    strDat4(j, 9) = DtView1(i)("�Z��2")
                    strDat4(j, 10) = DtView1(i)("�Z��3")
                    strDat4(j, 11) = DtView1(i)("�Z��4")
                    strDat4(j, 12) = DtView1(i)("�Z��5")
                    strDat4(j, 13) = DtView1(i)("�̔��Һ���")
                    strDat4(j, 14) = DtView1(i)("������")
                    strDat4(j, 15) = DtView1(i)("�폜�׸�")
                    strDat4(j, 16) = DtView1(i)("�s�ԍ�")
                    strDat4(j, 17) = DtView1(i)("�s�敪")
                    strDat4(j, 18) = DtView1(i)("���i����")
                    strDat4(j, 19) = DtView1(i)("�i����")
                    strDat4(j, 20) = DtView1(i)("�^�Զ�")
                    strDat4(j, 21) = DtView1(i)("�װ")
                    strDat4(j, 22) = DtView1(i)("����")
                    strDat4(j, 23) = DtView1(i)("ڼ��")
                    strDat4(j, 24) = DtView1(i)("�i������")
                    strDat4(j, 25) = DtView1(i)("�^�Ԋ���")
                    strDat4(j, 26) = DtView1(i)("���޺���")
                    strDat4(j, 27) = DtView1(i)("�i����")
                    strDat4(j, 28) = DtView1(i)("���㐔")
                    strDat4(j, 29) = DtView1(i)("Ͻ��P��")
                    strDat4(j, 30) = DtView1(i)("�P��")
                    strDat4(j, 31) = DtView1(i)("�ŋ敪")
                    strDat4(j, 32) = DtView1(i)("�l�������敪")
                    strDat4(j, 33) = DtView1(i)("������")
                    strDat4(j, 34) = DtView1(i)("�l���z")
                    strDat4(j, 35) = DtView1(i)("�P��2")
                    strDat4(j, 36) = DtView1(i)("��������")
                    strDat4(j, 37) = DtView1(i)("SEQ")
                    strDat4(j, 38) = DtView1(i)("������SEQ")
                    strDat4(j, 39) = DtView1(i)("�ԍ�SEQ")
                    strDat4(j, 40) = DtView1(i)("sprice")
                    strDat4(j, 41) = DtView1(i)("WSEQ1")
                    strDat4(j, 42) = DtView1(i)("WSEQ2")
                    strDat4(j, 43) = DtView1(i)("ERR_F")
                    If DtView1(i)("�@�l") = "True" Then strDat4(j, 44) = "1"
                Next
            End If
            xlRange4.Value = strDat4            '�Z���փf�[�^�̓���
            MRComObject(xlRange4)               'xlRange �̉��

            '*****************************
            '** �@�l�ۗ�
            '*****************************
            '==================  �f�[�^�̓��͏���  ==================  
            xlSheet = xlSheets.Item(5)  'Sheet5
            Dim xlRange5 As Excel.Range
            Dim strDat5(999, 44) As Object
            xlRange5 = xlSheet.Range("A2:AS1000")    '�f�[�^�̓��̓Z���͈�

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_biz", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram5.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 1800
            DaList1.Fill(DsList1, "sp_glist_biz")
            DtView1 = New DataView(DsList1.Tables("sp_glist_biz"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                waitDlg.MainMsg = "�@�l�ۗ����o��"
                waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
                Application.DoEvents()              '���b�Z�[�W�����𑣂��ĕ\�����X�V����

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    j = i
                    strDat5(j, 0) = DtView1(i)("�`�[NO")
                    strDat5(j, 1) = DtView1(i)("���s��")
                    strDat5(j, 2) = DtView1(i)("�z���X����")
                    strDat5(j, 3) = DtView1(i)("��ʔ��|�敪")
                    strDat5(j, 4) = DtView1(i)("����")
                    strDat5(j, 5) = DtView1(i)("TEL1")
                    strDat5(j, 6) = DtView1(i)("TEL2")
                    strDat5(j, 7) = DtView1(i)("�X�֔ԍ�")
                    strDat5(j, 8) = DtView1(i)("�Z��1")
                    strDat5(j, 9) = DtView1(i)("�Z��2")
                    strDat5(j, 10) = DtView1(i)("�Z��3")
                    strDat5(j, 11) = DtView1(i)("�Z��4")
                    strDat5(j, 12) = DtView1(i)("�Z��5")
                    strDat5(j, 13) = DtView1(i)("�̔��Һ���")
                    strDat5(j, 14) = DtView1(i)("������")
                    strDat5(j, 15) = DtView1(i)("�폜�׸�")
                    strDat5(j, 16) = DtView1(i)("�s�ԍ�")
                    strDat5(j, 17) = DtView1(i)("�s�敪")
                    strDat5(j, 18) = DtView1(i)("���i����")
                    strDat5(j, 19) = DtView1(i)("�i����")
                    strDat5(j, 20) = DtView1(i)("�^�Զ�")
                    strDat5(j, 21) = DtView1(i)("�װ")
                    strDat5(j, 22) = DtView1(i)("����")
                    strDat5(j, 23) = DtView1(i)("ڼ��")
                    strDat5(j, 24) = DtView1(i)("�i������")
                    strDat5(j, 25) = DtView1(i)("�^�Ԋ���")
                    strDat5(j, 26) = DtView1(i)("���޺���")
                    strDat5(j, 27) = DtView1(i)("�i����")
                    strDat5(j, 28) = DtView1(i)("���㐔")
                    strDat5(j, 29) = DtView1(i)("Ͻ��P��")
                    strDat5(j, 30) = DtView1(i)("�P��")
                    strDat5(j, 31) = DtView1(i)("�ŋ敪")
                    strDat5(j, 32) = DtView1(i)("�l�������敪")
                    strDat5(j, 33) = DtView1(i)("������")
                    strDat5(j, 34) = DtView1(i)("�l���z")
                    strDat5(j, 35) = DtView1(i)("�P��2")
                    strDat5(j, 36) = DtView1(i)("��������")
                    strDat5(j, 37) = DtView1(i)("SEQ")
                    strDat5(j, 38) = DtView1(i)("������SEQ")
                    strDat5(j, 39) = DtView1(i)("�ԍ�SEQ")
                    strDat5(j, 40) = DtView1(i)("sprice")
                    strDat5(j, 41) = DtView1(i)("WSEQ1")
                    strDat5(j, 42) = DtView1(i)("WSEQ2")
                    strDat5(j, 43) = DtView1(i)("ERR_F")
                    If DtView1(i)("�@�l") = "True" Then strDat5(j, 44) = "1"
                Next
            End If
            xlRange5.Value = strDat5            '�Z���փf�[�^�̓���
            MRComObject(xlRange5)               'xlRange �̉��


            '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "MrMAX�����\" & Format(P_DATE, "yyyyMM") & ".xls"
            SaveFileDialog1.Filter = "Excel�t�@�C��|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                xlBook.SaveAs(SaveFileDialog1.FileName)
                CX_F = "0"
            Else
                CX_F = "1"
            End If

            '==================  �I������  =====================  
            MRComObject(xlSheet)            'xlSheet �̉��
            MRComObject(xlSheets)           'xlSheets �̉��
            xlBook.Close(False)             'xlBook �����
            MRComObject(xlBook)             'xlBook �̉��
            MRComObject(xlBooks)            'xlBooks �̉��
            xlApp.Quit()                    'Excel����� 
            MRComObject(xlApp)              'xlApp �����

            If CX_F = "0" Then
                MessageBox.Show(SaveFileDialog1.FileName & " �ɏo�͂��܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Activate()                   ' ��������I�[�i�[���A�N�e�B�u�ɂ���
            waitDlg.Close()                 ' �i�s�󋵃_�C�A���O�����
            Me.Enabled = True

            DB_CLOSE()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
err_prc:
        If Err.Number = 50290 Then
            MessageBox.Show("�G�N�Z���o�͒��ɑ��̃G�N�Z���t�@�C�����J�����͏o���܂���B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show(Err.Number & ":" & Err.Description, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        Me.Activate()                   ' ��������I�[�i�[���A�N�e�B�u�ɂ���
        waitDlg.Close()                 ' �i�s�󋵃_�C�A���O�����
        Me.Enabled = True
        DB_CLOSE()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel �I���������̃v���V�[�W��
        Try
            '�񋟂��ꂽ�����^�C���Ăяo���\���b�p�[�̎Q�ƃJ�E���g���f�N�������g���܂�
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub

    '*********************************************************************************
    '**  �{�ԃf�[�^�֓o�^
    '*********************************************************************************
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim i, r1, r2, r3, r4, seq As Integer
        Dim WK_key, WK_str As String
        Dim WK_adrs, WK_adrs1, WK_adrs2 As String

        'ans = MessageBox.Show("�{�ԃf�[�^�֓o�^���܂��B", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        'If ans = "2" Then Exit Sub '������

        DB_OPEN()

        ' �i�s�󋵃_�C�A���O�̏���������
        waitDlg = New WaitDialog        ' �i�s�󋵃_�C�A���O
        waitDlg.Owner = Me              ' �_�C�A���O�̃I�[�i�[��ݒ肷��
        waitDlg.MainMsg = "�ް����o��"  ' �����̊T�v��\��
        waitDlg.ProgressMax = 0         ' �S�̂̏���������ݒ�
        waitDlg.ProgressMin = 0         ' ���������̍ŏ��l��ݒ�i0������J�n�j
        waitDlg.ProgressStep = 1        ' �������ƂɃ��[�^��i�߂邩��ݒ�
        waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
        Me.Enabled = False              ' �I�[�i�[�̃t�H�[���𖳌��ɂ���
        waitDlg.Show()                  ' �i�s�󋵃_�C�A���O��\������

        'WSEQ1�ƃ}�b�`
        DsList1.Clear()
        strSQL = "SELECT V_Wrn_N30.���s��, V_Wrn_N30.�`�[NO, V_Wrn_N30.�s�ԍ�, V_Wrn_N30.[�z���X����], V_Wrn_N30.[���i����]"
        strSQL += ", V_Wrn_N30.�^�Զ�, V_Wrn_N30.[�i����], M08_KBN_CAT.ITEM_NAME AS �i�햼, V_Wrn_N30.�i������"
        strSQL += ", V_Wrn_N30.�P��2 AS PRICE, V_Wrn_E30.�P��2 AS WRN_PRICE, '05' AS WRN_PRD, '00' AS SALE_STS"
        strSQL += ", V_Wrn_N30.����, V_Wrn_N30.�X�֔ԍ�, V_Wrn_N30.�Z��1, V_Wrn_N30.�Z��2, V_Wrn_N30.�Z��3"
        strSQL += ", V_Wrn_N30.�Z��4, V_Wrn_N30.�Z��5, V_Wrn_N30.TEL1, V_Wrn_N30.TEL2, V_Wrn_N30.SEQ"
        strSQL += ", V_Wrn_E30.SEQ AS SEQ2, V_Wrn_N30.������2"
        strSQL += " FROM V_Wrn_N30 INNER JOIN"
        strSQL += " V_Wrn_E30 ON V_Wrn_N30.WSEQ1 = V_Wrn_E30.SEQ LEFT OUTER JOIN"
        strSQL += " M08_KBN_CAT ON V_Wrn_N30.�i���� = M08_KBN_CAT.CAT_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r1 = DaList1.Fill(DsList1, "Wrn_add")

        'WSEQ2�ƃ}�b�`
        strSQL = "SELECT V_Wrn_N30.���s��, V_Wrn_N30.�`�[NO, V_Wrn_N30.�s�ԍ�, V_Wrn_N30.[�z���X����], V_Wrn_N30.[���i����]"
        strSQL += ", V_Wrn_N30.�^�Զ�, V_Wrn_N30.[�i����], M08_KBN_CAT.ITEM_NAME AS �i�햼, V_Wrn_N30.�i������"
        strSQL += ", V_Wrn_N30.�P��2 AS PRICE, V_Wrn_E30.�P��2 AS WRN_PRICE, '05' AS WRN_PRD, '00' AS SALE_STS"
        strSQL += ", V_Wrn_N30.����, V_Wrn_N30.�X�֔ԍ�, V_Wrn_N30.�Z��1, V_Wrn_N30.�Z��2, V_Wrn_N30.�Z��3"
        strSQL += ", V_Wrn_N30.�Z��4, V_Wrn_N30.�Z��5, V_Wrn_N30.TEL1, V_Wrn_N30.TEL2, V_Wrn_N30.SEQ"
        strSQL += ", V_Wrn_E30.SEQ AS SEQ2, V_Wrn_N30.������2"
        strSQL += " FROM V_Wrn_N30 INNER JOIN"
        strSQL += " V_Wrn_E30 ON V_Wrn_N30.WSEQ2 = V_Wrn_E30.SEQ LEFT OUTER JOIN"
        strSQL += " M08_KBN_CAT ON V_Wrn_N30.�i���� = M08_KBN_CAT.CAT_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r2 = DaList1.Fill(DsList1, "Wrn_add")
        DB_CLOSE()

        If r1 = 0 And r2 = 0 Then
            MsgBox("�o�^����f�[�^���L��܂���B")
        Else

            ans = MessageBox.Show("�ۏ؃f�[�^�F " & Format(r1, "##,##0") & "��" & vbCrLf & "�@��f�[�^�F " & Format(r1 + r2, "##,##0") & "��" & vbCrLf & vbCrLf & "�{�ԃf�[�^�֓o�^���܂��B", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            If ans = "2" Then '������
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            DtView1 = New DataView(DsList1.Tables("Wrn_add"), "", "�`�[NO, �s�ԍ�", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "�ް��o�^��"      ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = DtView1.Count ' �S�̂̏���������ݒ�
            waitDlg.ProgressValue = 0           ' �ŏ��̌�����ݒ�
            Application.DoEvents()              ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            DB_OPEN()
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                seq = 1
re:
                WK_key = Trim(DtView1(i)("�`�[NO")) & Format(CInt(DtView1(i)("�s�ԍ�")), "00") & Format(seq, "00")
                WK_key = WK_key.PadLeft(17, "0")

                WK_DsList1.Clear()
                strSQL = "SELECT WRN_NO FROM WRN_DATA WHERE (WRN_NO = '" & WK_key & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                r3 = DaList1.Fill(WK_DsList1, "Wrn_data")
                If r3 <> 0 Then
                    seq = seq + 1
                    GoTo re
                Else

                    strSQL = "INSERT INTO WRN_DATA"
                    strSQL += " (WRN_DATE, WRN_NO, SHOP_CODE, ITEM_CODE, MODEL, CAT_CODE, CAT_NAME, MKR_NAME, PRICE"
                    strSQL += ", WRN_PRICE, WRN_PRD, SALE_STS, CRT_DATE, CUST_NAME, ZIP1, ZIP2, ADRS1, ADRS2, TEL_NO, CNT_NO)"
                    strSQL += " VALUES ('" & Mid(DtView1(i)("���s��"), 1, 4) & "/" & Mid(DtView1(i)("���s��"), 5, 2) & "/" & Mid(DtView1(i)("���s��"), 7, 2) & "'"
                    strSQL += ", '" & WK_key & "'"
                    WK_str = Trim(DtView1(i)("�z���X����")) : WK_str = WK_str.PadLeft(4, "0")
                    strSQL += ", '" & WK_str & "'"
                    strSQL += ", '" & DtView1(i)("���i����") & "'"
                    strSQL += ", '" & DtView1(i)("�^�Զ�") & "'"
                    strSQL += ", '" & DtView1(i)("�i����") & "'"
                    If Not IsDBNull(DtView1(i)("�i�햼")) Then
                        strSQL += ", '" & DtView1(i)("�i�햼") & "'"
                    Else
                        strSQL += ", NULL"
                    End If
                    strSQL += ", '" & DtView1(i)("�i������") & "'"
                    strSQL += ", " & DtView1(i)("PRICE") & ""
                    strSQL += ", " & DtView1(i)("WRN_PRICE") & ""
                    strSQL += ", '" & DtView1(i)("WRN_PRD") & "'"
                    strSQL += ", '" & DtView1(i)("SALE_STS") & "'"
                    strSQL += ", '" & DtView1(i)("������2") & "'"
                    strSQL += ", '" & DtView1(i)("����") & "'"
                    If Not IsDBNull(DtView1(i)("�X�֔ԍ�")) Then
                        strSQL += ", '" & Mid(DtView1(i)("�X�֔ԍ�"), 1, 3) & "'"
                        strSQL += ", '" & Mid(DtView1(i)("�X�֔ԍ�"), 4, 4) & "'"
                    Else
                        strSQL += ", NULL"
                        strSQL += ", NULL"
                    End If

                    If IsDBNull(DtView1(i)("�Z��1")) Then DtView1(i)("�Z��1") = ""
                    If IsDBNull(DtView1(i)("�Z��2")) Then DtView1(i)("�Z��2") = ""
                    If IsDBNull(DtView1(i)("�Z��3")) Then DtView1(i)("�Z��3") = ""
                    If IsDBNull(DtView1(i)("�Z��4")) Then DtView1(i)("�Z��4") = ""
                    If IsDBNull(DtView1(i)("�Z��5")) Then DtView1(i)("�Z��5") = ""
                    WK_adrs = Trim(DtView1(i)("�Z��1")) & Trim(DtView1(i)("�Z��2")) & Trim(DtView1(i)("�Z��3")) & Trim(DtView1(i)("�Z��4"))
                    If LenB(WK_adrs) <= 60 Then
                        WK_adrs1 = WK_adrs
                        WK_adrs2 = MidB(Trim(DtView1(i)("�Z��5")), 1, 60)
                    Else
                        WK_adrs1 = MidB(WK_adrs, 1, 60)
                        WK_adrs2 = MidB(Trim(MidB(WK_adrs, 61, 60)) & Trim(DtView1(i)("�Z��5")), 1, 60)
                    End If
                    strSQL += ", '" & WK_adrs1 & "'"
                    strSQL += ", '" & WK_adrs2 & "'"
                    strSQL += ", '" & DtView1(i)("TEL1") & "'"
                    strSQL += ", '" & DtView1(i)("TEL2") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    '�σt���OON

                    strSQL = "UPDATE [02_����f�[�^] SET wrn_add_f = 1 WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    strSQL = "UPDATE [02_����f�[�^] SET wrn_add_f = 1 WHERE (SEQ = " & DtView1(i)("SEQ2") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                End If
            Next
            MsgBox("�o�^����")
        End If

        waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
        Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���

        DB_CLOSE()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
