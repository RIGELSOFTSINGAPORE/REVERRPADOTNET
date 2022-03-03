Imports System.Runtime.InteropServices

Public Class Menu00
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F As String
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button40 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button50 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button00 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Info As System.Windows.Forms.Label
    Friend WithEvents Ver As System.Windows.Forms.Label
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Button81 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Menu00))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button99 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button40 = New System.Windows.Forms.Button
        Me.Button30 = New System.Windows.Forms.Button
        Me.Button20 = New System.Windows.Forms.Button
        Me.Button50 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button00 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Info = New System.Windows.Forms.Label
        Me.Ver = New System.Windows.Forms.Label
        Me.Button80 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label01 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.Button81 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(88, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(524, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(32, 364)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(164, 48)
        Me.Button99.TabIndex = 5
        Me.Button99.Text = "�I��"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(348, 84)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "nMVAR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(236, 388)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(348, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Global Solution Services"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button40
        '
        Me.Button40.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button40.Location = New System.Drawing.Point(32, 236)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(164, 48)
        Me.Button40.TabIndex = 3
        Me.Button40.Text = "�W�@�v"
        '
        'Button30
        '
        Me.Button30.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button30.Location = New System.Drawing.Point(32, 172)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(164, 48)
        Me.Button30.TabIndex = 2
        Me.Button30.Text = "��������"
        '
        'Button20
        '
        Me.Button20.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button20.Location = New System.Drawing.Point(32, 108)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(164, 48)
        Me.Button20.TabIndex = 1
        Me.Button20.Text = "��������"
        '
        'Button50
        '
        Me.Button50.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button50.Location = New System.Drawing.Point(32, 300)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(164, 48)
        Me.Button50.TabIndex = 4
        Me.Button50.Text = "�}�X�^�E�����e�i���X"
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(32, 44)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(164, 48)
        Me.Button10.TabIndex = 0
        Me.Button10.Text = "�C���Ɩ�"
        '
        'Button00
        '
        Me.Button00.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button00.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button00.Location = New System.Drawing.Point(516, 32)
        Me.Button00.Name = "Button00"
        Me.Button00.Size = New System.Drawing.Size(96, 24)
        Me.Button00.TabIndex = 18
        Me.Button00.TabStop = False
        Me.Button00.Text = "�����ύX"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Info
        '
        Me.Info.Font = New System.Drawing.Font("�l�r ����", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Info.Location = New System.Drawing.Point(4, 416)
        Me.Info.Name = "Info"
        Me.Info.Size = New System.Drawing.Size(612, 20)
        Me.Info.TabIndex = 19
        Me.Info.Text = "���m�点�F"
        Me.Info.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Ver
        '
        Me.Ver.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ver.Location = New System.Drawing.Point(0, 4)
        Me.Ver.Name = "Ver"
        Me.Ver.Size = New System.Drawing.Size(80, 12)
        Me.Ver.TabIndex = 876
        Me.Ver.Text = "Ver 2.01"
        Me.Ver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button80.Location = New System.Drawing.Point(516, 64)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(96, 24)
        Me.Button80.TabIndex = 877
        Me.Button80.TabStop = False
        Me.Button80.Text = "�߽ܰ�ޕύX"
        Me.Button80.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 12)
        Me.Label5.TabIndex = 879
        Me.Label5.Text = "Label5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(236, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 112)
        Me.Label2.TabIndex = 880
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.Label6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(412, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 24)
        Me.Label6.TabIndex = 881
        Me.Label6.Text = "Back-Log�F"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(412, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 24)
        Me.Label7.TabIndex = 882
        Me.Label7.Text = "������@ �F"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.Label01.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label01.Location = New System.Drawing.Point(516, 112)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(48, 24)
        Me.Label01.TabIndex = 883
        Me.Label01.Text = "Label01"
        Me.Label01.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.Label02.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label02.ForeColor = System.Drawing.Color.Red
        Me.Label02.Location = New System.Drawing.Point(516, 136)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(48, 24)
        Me.Label02.TabIndex = 884
        Me.Label02.Text = "Label02"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button81
        '
        Me.Button81.BackColor = System.Drawing.Color.Blue
        Me.Button81.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button81.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button81.ForeColor = System.Drawing.Color.White
        Me.Button81.Location = New System.Drawing.Point(496, 168)
        Me.Button81.Name = "Button81"
        Me.Button81.Size = New System.Drawing.Size(68, 40)
        Me.Button81.TabIndex = 885
        Me.Button81.TabStop = False
        Me.Button81.Text = "�ŐV �@�@���X�V"
        '
        'Menu00
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.ClientSize = New System.Drawing.Size(618, 440)
        Me.Controls.Add(Me.Button81)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Ver)
        Me.Controls.Add(Me.Info)
        Me.Controls.Add(Me.Button00)
        Me.Controls.Add(Me.Button40)
        Me.Controls.Add(Me.Button30)
        Me.Controls.Add(Me.Button20)
        Me.Controls.Add(Me.Button50)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Menu00"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nMVAR"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo TAG_Err
        Info.Visible = False

        Call DB_INIT()
        inz()       '**  ��������
        If Err_F = "1" Then Application.Exit() : Exit Sub
        ACES()      '**  �����`�F�b�N
        pc_name()   '**  ���[�J���o�b���擾
        Label5.Text = System.Environment.MachineName
        If catalog(1) = "nMVAR_test" Then Label2.Text = "�e�X�g��"
        bk_log()    '**  �o�b�N���O�E������@�擾
        Exit Sub
TAG_Err:
        MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Application.Exit()
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        strcurdir = System.IO.Directory.GetCurrentDirectory                                         '���s�t�H���_�[
        P_PGM_var = Format(System.IO.File.GetLastWriteTime(strcurdir & "\nMVAR.exe"), "yyyyMMdd")   '�v���O�����o�[�W����
        Ver.Text = "Ver." & P_PGM_var

        Err_F = "0"
        P_EMPL = System.Environment.UserName
        'If P_EMPL = "otsuki" Then P_EMPL = "nhohno" '�e�X�g�p�i��삳��j
        'If P_EMPL = "otsuki" Then P_EMPL = "slkobaya" '�e�X�g�p�i���т���j
        'If P_EMPL = "otsuki" Then P_EMPL = "slmatsur" '�e�X�g�p�i���{�@������j
        'If P_EMPL = "otsuki" Then P_EMPL = "tknara" '�e�X�g�p�i�ޗǂ���j
        'If P_EMPL = "otsuki" Then P_EMPL = "mkkinosh" '�e�X�g�p�i�؉�����j
        'If P_EMPL = "otsuki" Then P_EMPL = "qhtakeu" '�e�X�g�p�i�|���@�q�F�j
        If P_EMPL = "otsuki" Then P_EMPL = "administrator" '��΃e�X�g�p

        '������ł��X�V�\�ȃ��[�U�[
        '���c��n�A�������q�A�|���q�F�A
        If P_EMPL = "administrator" _
            Or P_EMPL = "sbshimad" _
            Or P_EMPL = "ruriab" _
            Or P_EMPL = "qhtakeu" Then
            P_tokubetu = "1"
        Else
            P_tokubetu = "0"
        End If

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_Login_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 20)
        Pram1.Value = P_EMPL
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Err_F = "1"
            MessageBox.Show("���[�U�[���o�^����Ă��܂���B", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DtView1(0)("delt_flg") = "1" Then
                Err_F = "1"
                MessageBox.Show("���[�U�[�o�^�������ł��B", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                P_EMPL_NO = DtView1(0)("empl_code")
                P_EMPL_NAME = Trim(DtView1(0)("name"))
                P_EMPL_BRCH = Trim(DtView1(0)("brch_code"))
                P_EMPL_BRCH_name = Trim(DtView1(0)("brch_name"))
                P_full = DtView1(0)("full_cntl")
                P_comp_code = DtView1(0)("comp_code")
                P_area_code = DtView1(0)("area_code")

                P_ACES_brch_code = Trim(DtView1(0)("brch_code"))
                P_ACES_post_code = Trim(DtView1(0)("post_code"))

                If Not IsDBNull(DtView1(0)("rpar_comp_code")) Then P_rpar_comp_code = DtView1(0)("rpar_comp_code") Else P_rpar_comp_code = Nothing

                If Not IsDBNull(DtView1(0)("admin_flg")) Then P_DBG = DtView1(0)("admin_flg") Else P_DBG = "False"

                ''�����I��
                'Dim F00_Form01 As New F00_Form01
                'F00_Form01.ShowDialog()

                Label1.Text = P_EMPL_NAME & " / " & P_EMPL_BRCH_name
            End If
        End If
    End Sub

    '********************************************************************
    '**  ���[�J���o�b���擾
    '********************************************************************
    Sub pc_name()
        Dim serverName As String
        Dim clientInfo As New WTS_CLIENT_INFO
        ReDim clientInfo.Address(20)
        serverName = ""
        If GetSessions(serverName, clientInfo) = True Then
            If clientInfo.WTSClientName = "" Then
                P_PC_NAME = clientInfo.WTSDomainName
            Else
                P_PC_NAME = clientInfo.WTSClientName
            End If
            P_PC_NAME2 = clientInfo.WTSClientName
        End If
    End Sub

    '********************************************************************
    '**  �o�b�N���O�E������@�擾
    '********************************************************************
    Sub bk_log()
        WK_DsList1.Clear()
        DB_OPEN("nMVAR")

        '�o�b�N���O
        SqlCmd1 = New SqlClient.SqlCommand("sp_Menu00_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = Now.Date
        Pram2.Value = P_EMPL_BRCH
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(WK_DsList1, "bk_log")
        If r = 0 Then
            Label01.Text = "0"
        Else
            DtView1 = New DataView(WK_DsList1.Tables("bk_log"), "", "", DataViewRowState.CurrentRows)
            Label01.Text = DtView1(0)("cnt")
        End If

        '������
        SqlCmd1 = New SqlClient.SqlCommand("sp_Menu00_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram3.Value = Now.Date
        Pram4.Value = P_EMPL_BRCH
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(WK_DsList1, "bk_log2")
        If r = 0 Then
            Label02.Text = "0"
        Else
            DtView1 = New DataView(WK_DsList1.Tables("bk_log2"), "", "", DataViewRowState.CurrentRows)
            Label02.Text = DtView1(0)("cnt")
        End If

        DB_CLOSE()
    End Sub

    ''********************************************************************
    ''**  ���m�点�\��
    ''********************************************************************
    'Private intTextLeft As Integer
    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Dim g As Graphics = Info.CreateGraphics()
    '    Dim siz As SizeF = g.MeasureString(Info.Text, Info.Font)
    '    g.Clear(Info.BackColor)
    '    g.DrawString(Info.Text, Info.Font, New SolidBrush(Info.ForeColor), intTextLeft, 0)
    '    intTextLeft -= 1
    '    If intTextLeft < CInt(siz.Width) * -1 Then
    '        intTextLeft = Info.Width
    '    End If
    '    g.Dispose()
    'End Sub

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

        '�C���Ɩ�
        Button10.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='100'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button10.Enabled = True
            End Select
        End If

        '��������
        Button20.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='200'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button20.Enabled = True
            End Select
        End If

        '��������
        Button30.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='300'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button30.Enabled = True
            End Select
        End If

        '�W�@�v
        Button40.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='400'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button40.Enabled = True
            End Select
        End If

        '�}�X�^�E�����e�i���X
        Button50.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='500'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2", "3", "4"
                    Button50.Enabled = True
            End Select
        End If

    End Sub

    '********************************************************************
    '**  �����ύX
    '********************************************************************
    Private Sub Button00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button00.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form01 As New F00_Form01
        F00_Form01.ShowDialog()
        Label1.Text = P_EMPL_NAME & " / " & P_EMPL_BRCH_name
        bk_log()    '**  �o�b�N���O�E������@�擾
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �C���Ɩ����j���[
    '********************************************************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Hide()
        Dim Menu10 As New Menu10
        Menu10.ShowDialog()
        Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �������j���[
    '********************************************************************
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_Invc.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("�N���ł��܂���ł���", "�G���[�ʒm")
        End Try
        'Me.Hide()
        'Dim Menu20 As New Menu20
        'Menu20.ShowDialog()
        'Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �������j���[
    '********************************************************************
    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_Clct.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("�N���ł��܂���ł���", "�G���[�ʒm")
        End Try
        'Me.Hide()
        'Dim Menu30 As New Menu30
        'Menu30.ShowDialog()
        'Me.Show()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �W�v���j���[
    '********************************************************************
    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_Report.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("�N���ł��܂���ł���", "�G���[�ʒm")
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �}�X�^�E�����e�i���X���j���[
    '********************************************************************
    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.IO.Directory.SetCurrentDirectory(strcurdir)
        Try
            P_intprocid = Shell(strcurdir & "\nMVAR_Mtr.exe " & P_EMPL_BRCH, AppWinStyle.NormalFocus)
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("�N���ł��܂���ł���", "�G���[�ʒm")
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �p�X���[�h�ύX
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim F00_Form11 As New F00_Form11
        F00_Form11.ShowDialog()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �ŐV���X�V
    '********************************************************************
    Private Sub Button81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button81.Click
        bk_log()    '**  �o�b�N���O�E������@�擾
    End Sub

    '********************************************************************
    '**  �I���i���O�I�t�j
    '********************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click

        If P_PC_NAME2 = "" Or P_EMPL_NO = -1 Then  '���[�[�J���o�b�̎����O�I�t���Ȃ�(��΂�)
            Application.Exit()
        Else
            Dim psi As New System.Diagnostics.ProcessStartInfo
            psi.FileName = "shutdown.exe"
            '�R�}���h���C�����w��
            psi.Arguments = "-l"
            '�E�B���h�E��\�����Ȃ��悤�ɂ���i�������Ă��\�������j
            psi.CreateNoWindow = True
            '�N��
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
        End If

    End Sub


    Private Enum WTS_CONNECTSTATE_CLASS
        WTSActive
        WTSConnected
        WTSConnectQuery
        WTSShadow
        WTSDisconnected
        WTSIdle
        WTSListen
        WTSReset
        WTSDown
        WTSInit
    End Enum

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Private Structure WTS_SESSION_INFO
        Dim SessionID As Int64 'DWORD integer
        Dim pWinStationName As String ' integer LPTSTR - Pointer to a null-terminated string containing the name of the WinStation for this session
        Dim State As WTS_CONNECTSTATE_CLASS
    End Structure

    Friend Structure strSessionsInfo
        Dim SessionID As Integer
        Dim StationName As String
        Dim ConnectionState As String
    End Structure

    Private Enum WTS_INFO_CLASS
        WTSInitialProgram
        WTSApplicationName
        WTSWorkingDirectory
        WTSOEMId
        WTSSessionId
        WTSUserName
        WTSWinStationName
        WTSDomainName
        WTSConnectState
        WTSClientBuildNumber
        WTSClientName
        WTSClientDirectory
        WTSClientProductId
        WTSClientHardwareId
        WTSClientAddress
        WTSClientDisplay
        WTSClientProtocolType
        WTSIdleTime
        WTSLogonTime
        WTSIncomingBytes
        WTSOutgoingBytes
        WTSIncomingFrames
        WTSOutgoingFrames
    End Enum

    'Structure for TS Client IP Address
    <StructLayout(LayoutKind.Sequential)>
    Private Structure _WTS_CLIENT_ADDRESS
        Public AddressFamily As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=20)>
        Public Address As Byte()
    End Structure

    'Structure for TS Client Information
    Friend Structure WTS_CLIENT_INFO
        Public WTSStatus As Boolean
        Public WTSUserName As String
        Public WTSStationName As String
        Public WTSDomainName As String
        Public WTSClientName As String
        Public AddressFamily As Integer
        Public Address As Byte()
    End Structure

    'Function for TS Session Information excluding Client IP address
    Private Declare Function WTSQuerySessionInformation Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int64,
    ByVal SessionId As Int64, ByVal WTSInfoClass As Int64, <MarshalAs(UnmanagedType.LPWStr)> ByRef ppBuffer As String, ByRef pCount As Int64) As Boolean

    'Function for TS Client IP Address
    Private Declare Function WTSQuerySessionInformation2 Lib "WtsApi32.dll" Alias "WTSQuerySessionInformationW" (ByVal hServer As Int64,
      ByVal SessionId As Int32, ByVal WTSInfoClass As Int64, ByRef ppBuffer As IntPtr, ByRef pCount As Int64) As Boolean

    Private Declare Function GetCurrentProcessId Lib "Kernel32.dll" Alias "GetCurrentProcessId" () As Int64
    Private Declare Function ProcessIdToSessionId Lib "Kernel32.dll" Alias "ProcessIdToSessionId" (ByVal processID As Int64, ByRef sessionID As Int64) As Boolean
    Private Declare Function WTSGetActiveConsoleSessionId Lib "Kernel32.dll" Alias "WTSGetActiveConsoleSessionId" () As Int64

    <DllImport("wtsapi32.dll",
    bestfitmapping:=True,
    CallingConvention:=CallingConvention.StdCall,
    CharSet:=CharSet.Auto,
    EntryPoint:="WTSEnumerateSessions",
    setlasterror:=True,
    ThrowOnUnmappableChar:=True)>
    Private Shared Function WTSEnumerateSessions(
    ByVal hServer As IntPtr,
    <MarshalAs(UnmanagedType.U4)>
    ByVal Reserved As Int32,
    <MarshalAs(UnmanagedType.U4)>
    ByVal Vesrion As Int32,
    ByRef ppSessionInfo As IntPtr,
    <MarshalAs(UnmanagedType.U4)>
    ByRef pCount As Int32) As Int32
    End Function

    <DllImport("wtsapi32.dll")>
    Private Shared Sub WTSFreeMemory(ByVal pMemory As IntPtr)
    End Sub

    <DllImport("wtsapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function WTSOpenServer(ByVal pServerName As String) As IntPtr
    End Function

    <DllImport("wtsapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Sub WTSCloseServer(ByVal hServer As IntPtr)
    End Sub

    Friend Function GetSessions(ByVal ServerName As String, ByRef ClientInfo As WTS_CLIENT_INFO) As Boolean
        Dim ptrOpenedServer As IntPtr
        Try
            ptrOpenedServer = WTSOpenServer(ServerName)
            If ptrOpenedServer.ToInt64 = vbNull Then
                MessageBox.Show("Terminal Services not running on : " & ServerName)
                GetSessions = False
                Exit Function
            End If
            Dim FRetVal As Int64
            Dim ppSessionInfo As IntPtr = IntPtr.Zero
            Dim Count As Int64 = 0
            Try
                FRetVal = WTSEnumerateSessions(ptrOpenedServer, 0, 1, ppSessionInfo, Count)
                If FRetVal <> 0 Then
                    Dim sessionInfo() As WTS_SESSION_INFO = New WTS_SESSION_INFO(Count) {}
                    Dim i As Integer
                    Dim session_ptr As IntPtr
                    For i = 0 To Count - 1
                        'session_ptr = ppSessionInfo.ToInt32() + (i * Marshal.SizeOf(sessionInfo(i)))
                        sessionInfo(i) = CType(Marshal.PtrToStructure(session_ptr, GetType(WTS_SESSION_INFO)), WTS_SESSION_INFO)
                    Next
                    WTSFreeMemory(ppSessionInfo)
                    Dim tmpArr(sessionInfo.GetUpperBound(0)) As strSessionsInfo
                    For i = 0 To tmpArr.GetUpperBound(0)
                        tmpArr(i).SessionID = sessionInfo(i).SessionID
                        tmpArr(i).StationName = sessionInfo(i).pWinStationName
                        tmpArr(i).ConnectionState = GetConnectionState(sessionInfo(i).State)
                        'MessageBox.Show(tmpArr(i).StationName & "  " & tmpArr(i).SessionID & "  " & tmpArr(i).ConnectionState)
                    Next
                    ReDim sessionInfo(-1)
                Else
                    Throw New ApplicationException("No data retruned")
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message & vbCrLf & System.Runtime.InteropServices.Marshal.GetLastWin32Error)
            End Try
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        Finally
        End Try
        'Get ProcessID of TS Session that executed this TS Session
        Dim active_process As Int64 = GetCurrentProcessId()
        Dim active_session As Int64 = 0
        Dim success1 As Boolean = ProcessIdToSessionId(active_process, active_session)
        If success1 = False Then
            MessageBox.Show("Error: ProcessIdToSessionId")
        End If
        Dim returned As Integer
        Dim str As String = ""
        Dim success As Boolean = False
        ClientInfo.WTSStationName = ""
        ClientInfo.WTSClientName = ""
        ClientInfo.Address(2) = 0
        ClientInfo.Address(3) = 0
        ClientInfo.Address(4) = 0
        ClientInfo.Address(5) = 0

        'Get User Name of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSUserName, str, returned) = True Then
            ClientInfo.WTSUserName = str
        End If

        'Get StationName of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSWinStationName, str, returned) = True Then
            ClientInfo.WTSStationName = str
        End If

        'Get Domain Name of this TS session
        If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSDomainName, str, returned) = True Then
            ClientInfo.WTSDomainName = str
        End If

        'Skip client name and client address if this is a console session
        If ClientInfo.WTSStationName <> "Console" Then
            If WTSQuerySessionInformation(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSClientName, str, returned) = True Then
                ClientInfo.WTSClientName = str
            End If

            'Get client IP address
            Dim addr As IntPtr
            If WTSQuerySessionInformation2(ptrOpenedServer.ToInt64, active_session, WTS_INFO_CLASS.WTSClientAddress, addr, returned) = True Then
                Dim obj As New _WTS_CLIENT_ADDRESS
                obj = CType(Marshal.PtrToStructure(addr, obj.GetType()), _WTS_CLIENT_ADDRESS)
                ClientInfo.Address(2) = obj.Address(2)
                ClientInfo.Address(3) = obj.Address(3)
                ClientInfo.Address(4) = obj.Address(4)
                ClientInfo.Address(5) = obj.Address(5)
            End If
        End If
        WTSCloseServer(ptrOpenedServer)
        Return True
    End Function

    Private Function GetConnectionState(ByVal State As WTS_CONNECTSTATE_CLASS) As String
        Dim RetVal As String
        Select Case State
            Case WTS_CONNECTSTATE_CLASS.WTSActive
                RetVal = "Active"
            Case WTS_CONNECTSTATE_CLASS.WTSConnected
                RetVal = "Connected"
            Case WTS_CONNECTSTATE_CLASS.WTSConnectQuery
                RetVal = "Query"
            Case WTS_CONNECTSTATE_CLASS.WTSDisconnected
                RetVal = "Disconnected"
            Case WTS_CONNECTSTATE_CLASS.WTSDown
                RetVal = "Down"
            Case WTS_CONNECTSTATE_CLASS.WTSIdle
                RetVal = "Idle"
            Case WTS_CONNECTSTATE_CLASS.WTSInit
                RetVal = "Initializing."
            Case WTS_CONNECTSTATE_CLASS.WTSListen
                RetVal = "Listen"
            Case WTS_CONNECTSTATE_CLASS.WTSReset
                RetVal = "reset"
            Case WTS_CONNECTSTATE_CLASS.WTSShadow
                RetVal = "Shadowing"
            Case Else
                RetVal = "Unknown connect state"
        End Select
        Return RetVal
    End Function
End Class
