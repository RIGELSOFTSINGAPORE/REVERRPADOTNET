Public Class F50_Form18_3
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

    Dim strSQL, filename As String
    Dim i, j, k, prc_cnt As Integer

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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F50_Form18_3))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(14, 160)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(566, 448)
        Me.DataGridEx1.TabIndex = 1285
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M15_ZIP"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "�X�֔ԍ�"
        Me.DataGridTextBoxColumn2.MappingName = "zip"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 80
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "�s���{��"
        Me.DataGridTextBoxColumn4.MappingName = "ken_code"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "�Z��"
        Me.DataGridTextBoxColumn5.MappingName = "adrs"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 330
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(114, 643)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 32)
        Me.Button4.TabIndex = 1282
        Me.Button4.Text = "�N���A"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 97)
        Me.GroupBox1.TabIndex = 1280
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "�f�[�^�捞"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(28, 60)
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
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 616)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(562, 24)
        Me.msg.TabIndex = 1284
        Me.msg.Text = "msg"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(14, 643)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1281
        Me.Button1.Text = "�X�V"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(508, 644)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 1283
        Me.Button98.Text = "�߂�"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.Location = New System.Drawing.Point(124, 24)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(456, 16)
        Me.LinkLabel1.TabIndex = 1286
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://www.post.japanpost.jp/zipcode/dl/kogaki/lzh/ken_all.lzh"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 24)
        Me.Label6.TabIndex = 1307
        Me.Label6.Text = "�f�[�^�_�E�����[�h"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F50_Form18_3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(598, 686)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.DataGridEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F50_Form18_3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�X�֔ԍ��f�[�^�捞"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F50_Form18_3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='518'", "", DataViewRowState.CurrentRows)
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
        strSQL = "SELECT * FROM M15_ZIP WHERE (id = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsGRD, "M15_ZIP_clr")
        DB_CLOSE()

        'Dim tbl As New DataTable
        'tbl = DsGRD.Tables("M15_ZIP")
        'DataGridEx1.DataSource = tbl
    End Sub

    '********************************************************************
    '**  web
    '********************************************************************
    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.post.japanpost.jp/zipcode/dl/kogaki/lzh/ken_all.lzh")
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
            .Filter = "CSV ̧��(*.xls)|*.CSV"
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
                DB_OPEN("nMVAR")
                Button1.Enabled = False
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button98.Enabled = False

                DsGRD.Clear()
                strSQL = "SELECT * FROM M15_ZIP WHERE (id = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsGRD, "M15_ZIP")

                filename = TextBox1.Text
                Dim srFile As New System.IO.StreamReader(filename, System.Text.Encoding.Default)
                Dim strLine As String = srFile.ReadLine()

                Dim WK_str, str(5) As String

                While Not strLine Is Nothing
                    If RTrim(strLine) = Nothing Then GoTo p1

                    WK_str = strLine
                    str(1) = Mid(WK_str, 1, 2) '�s���{��CD
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(2) = Mid(WK_str, 2, 7) '�X�֔ԍ�
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(3) = Mid(WK_str, 2, WK_str.IndexOf(",") - 2) '�Z��1
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(4) = Mid(WK_str, 2, WK_str.IndexOf(",") - 2) '�Z��2
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(5) = Mid(WK_str, 2, WK_str.IndexOf(",") - 2) '�Z��3

                    dttable = DsGRD.Tables("M15_ZIP")
                    dtRow = dttable.NewRow
                    dtRow("zip") = str(2)
                    dtRow("ken_code") = str(1)
                    dtRow("adrs") = str(3) & str(4) & str(5)
                    dttable.Rows.Add(dtRow)
p1:
                    strLine = srFile.ReadLine()
                End While

                srFile.Close()  '�t�@�C������� 

                Dim tbl As New DataTable
                tbl = DsGRD.Tables("M15_ZIP")
                DataGridEx1.DataSource = tbl

                DB_CLOSE()
                msg.Text = "�捞�����I"
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = True
                Button98.Enabled = True
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
        Button4.Enabled = True
        Button98.Enabled = True
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  �X�V
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing
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
        waitDlg.MainMsg = "�X�֔ԍ��ް��X�V������"      ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
        waitDlg.Show()                  ' �i�s�󋵃_�C�A���O��\������

        DB_OPEN("nMVAR")

        '����̓f�[�^�쐬
        strSQL = "SELECT * FROM M15_ZIP WHERE (reg_date IS NOT NULL) AND (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsGRD, "M15_ZIP")

        '�����f�[�^�폜
        strSQL = "DELETE FROM M15_ZIP"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        '�I�[�g�i���o�[���Z�b�g
        strSQL = "DBCC CHECKIDENT (M15_ZIP ,RESEED ,0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        DtView1 = New DataView(DsGRD.Tables("M15_ZIP"), "", "ken_code, zip", DataViewRowState.CurrentRows)

        waitDlg.MainMsg = "�X�֔ԍ��ް��X�V��"          ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
        waitDlg.ProgressMsg = ""                    ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
        waitDlg.ProgressMax = DtView1.Count         ' �S�̂̏���������ݒ�
        waitDlg.ProgressValue = 0                   ' �ŏ��̌�����ݒ�
        Application.DoEvents()                      ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

        '�f�[�^�ǉ�
        For i = 0 To DtView1.Count - 1
            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@" & "�i" & Format((i + 1), "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
            waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%�@"
            Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
            waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

            strSQL = "INSERT INTO M15_ZIP (zip, ken_code, adrs, reg_date, delt_flg)"
            strSQL +=  " SELECT '" & DtView1(i)("zip") & "' AS zip"
            strSQL +=  ", '" & DtView1(i)("ken_code") & "' AS ken_code"
            strSQL +=  ", '" & MidB(DtView1(i)("adrs"), 1, 100) & "' AS adrs"
            If Not IsDBNull(DtView1(i)("reg_date")) Then
                strSQL +=  ", '" & DtView1(i)("reg_date") & "' AS reg_date"
            Else
                strSQL +=  ", NULL"
            End If
            strSQL +=  ", 0"

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        Next
        DB_CLOSE()
        waitDlg.Close()                 ' �i�s�󋵃_�C�A���O�����
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button98.Enabled = True
        msg.Text = "�X�V���܂����B"
        P_RTN = "1"
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
        DsGRD.Tables("M15_ZIP").Clear()

        Dim tbl As New DataTable
        tbl = DsGRD.Tables("M15_ZIP_clr")
        DataGridEx1.DataSource = tbl
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
