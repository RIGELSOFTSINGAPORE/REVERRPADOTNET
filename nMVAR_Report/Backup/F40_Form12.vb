Public Class F40_Form12
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData As String
    Dim i, j, r As Integer
    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer
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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form12))
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label007 = New System.Windows.Forms.Label
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(116, 68)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1762
        Me.Button98.Text = "�߂�"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 44)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(192, 16)
        Me.msg.TabIndex = 1764
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1761
        Me.Button1.Text = "CSV"
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyy/MM", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyy/MM", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(108, 16)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(72, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1760
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(28, 16)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(80, 20)
        Me.Label007.TabIndex = 1763
        Me.Label007.Text = "�Ώ۔N��"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F40_Form12
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(218, 100)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�ԓ`��������CSV�쐬"
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F40_Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date001.Text = Format(Now.Date, "yyyy/MM")
        msg.Text = Nothing
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        '�Ώ۔N��
        If Date001.Number = 0 Then
            msg.Text = "�Ώ۔N������͂��Ă��������B"
            Err_F = "1" : Date001.Focus() : Exit Sub
        End If

        'DataTable�쐬()
        DB_OPEN(ini)
        P_DsPRT.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_12", cnsqlclient)        '�ԓ`��
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = Date001.Text & "/01"
        Pram2.Value = DateAdd(DateInterval.Month, 1, CDate(Date001.Text & "/01"))
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(P_DsPRT, "WK_Print01")

        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_12_2", cnsqlclient)      '�ԓ`�̌�
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram3.Value = Date001.Text & "/01"
        Pram4.Value = DateAdd(DateInterval.Month, 1, CDate(Date001.Text & "/01"))
        DaList1.SelectCommand = SqlCmd1
        r = r + DaList1.Fill(P_DsPRT, "WK_Print01")
        DB_CLOSE()

        If r = 0 Then
            msg.Text = "�Ώۃf�[�^������܂���B"
            Err_F = "1" : Date001.Focus() : Exit Sub
        End If
    End Sub

    '********************************************************************
    '**  CSV
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "�ԓ`����" & Mid(Date001.Text, 1, 4) & Mid(Date001.Text, 6, 2) & ".CSV" '�͂��߂̃t�@�C�������w�肷��
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
                strFile = sfd.FileName   'OK�{�^�����N���b�N���ꂽ�Ƃ�

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

                waitDlg.MainMsg = "CSV�o�͒�"   ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMsg = ""        ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMax = r         ' �S�̂̏���������ݒ�
                waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

                '�f�[�^����������
                strData = "�`�[�ԍ�,�v��QG,��t���,���׋敪�R�[�h,���׋敪��,�O���[�v�R�[�h,�O���[�v��,�掟�X�R�[�h,�掟�X��"
                strData += ",�̎Г`��,������R�[�h,�����於,���q�l��,��t�N����,�C��������,�������t,���ϓ��t"
                strData += ",�񓚎�M��,���i������,���i��̓�"
                strData += ",���Ϗ����z,�Ј��R�[�h,�C���S���Җ�,���[�J�[�R�[�h,���[�J�[��,���f��,�@��,�����ԍ�,�ۏ؏��,�ۏ؏��"
                strData += ",���i�ԍ�1,���i��1,����1,�R�X�g1,�v��z1,EU�z1"
                strData += ",���i�ԍ�2,���i��2,����2,�R�X�g2,�v��z2,EU�z2"
                strData += ",���i�ԍ�3,���i��3,����3,�R�X�g3,�v��z3,EU�z3"
                strData += ",���i�ԍ�4,���i��4,����4,�R�X�g4,�v��z4,EU�z4"
                strData += ",���i�ԍ�5,���i��5,����5,�R�X�g5,�v��z5,EU�z5"
                strData += ",���i�ԍ�6,���i��6,����6,�R�X�g6,�v��z6,EU�z6"
                strData += ",���i�ԍ�7,���i��7,����7,�R�X�g7,�v��z7,EU�z7"
                strData += ",���i�ԍ�8,���i��8,����8,�R�X�g8,�v��z8,EU�z8"
                strData += ",���i��,APSE,�Z�p��,���̑�,����,���v,�����,���v,�̎Ѓ��x�[�g,���ȕ��S��,QG-Care�ۏ͈ؔ�"
                strData += ",�C�����,��t�p�f,\0���R,�l�o�`�ԍ�,�l�o�`�ԍ��i���x�[�g�j,�ԓ`����t�ԍ�,�I���W�i�����[�J�[�R�[�h"
                strData += ",�\���Ǐ�,�C�����e,QG-Care�ԍ�,SB/IMEI�ԍ�,SB/�VIMEI�ԍ�"
                swFile.WriteLine(strData)

                DtView1 = New DataView(P_DsPRT.Tables("WK_Print01"), "", "sort, comp_shop_ttl DESC", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = Chr(34) & DtView1(i)("rcpt_no") & Chr(34)                     '�`�[�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("kjo_brch_name") & Chr(34)        '�v��QG
                    strData += "," & Chr(34) & DtView1(i)("rcpt_name") & Chr(34)            '��t���
                    strData += "," & Chr(34) & DtView1(i)("arvl_cls") & Chr(34)             '���׋敪�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("arvl_name") & Chr(34)            '���׋敪��
                    strData += "," & Chr(34) & DtView1(i)("grup_code") & Chr(34)            '�O���[�v�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("grup_name") & Chr(34)            '�O���[�v��
                    strData += "," & Chr(34) & DtView1(i)("store_code") & Chr(34)           '�掟�X�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("store_name") & Chr(34)           '�掟�X��
                    strData += "," & Chr(34) & DtView1(i)("store_repr_no") & Chr(34)        '�̎Г`��
                    strData += "," & Chr(34) & DtView1(i)("invc_code") & Chr(34)            '������R�[�h
                    strData += "," & Chr(34) & DtView1(i)("invc_name") & Chr(34)            '�����於
                    strData += "," & Chr(34) & DQM_Cng(DtView1(i)("user_name")) & Chr(34)   '���q�l��
                    strData += "," & Chr(34) & DtView1(i)("accp_date") & Chr(34)            '��t�N����
                    strData += "," & Chr(34) & DtView1(i)("comp_date") & Chr(34)            '�C��������
                    strData += "," & Chr(34) & DtView1(i)("clct_date") & Chr(34)            '�������t
                    strData += "," & Chr(34) & DtView1(i)("etmt_date") & Chr(34)            '���ϓ��t
                    strData += "," & Chr(34) & DtView1(i)("rsrv_cacl_date") & Chr(34)       '�񓚎�M��
                    strData += "," & Chr(34) & DtView1(i)("part_ordr_date") & Chr(34)       '���i������
                    strData += "," & Chr(34) & DtView1(i)("part_rcpt_date") & Chr(34)       '���i��̓�
                    WK_AMT = 0
                    If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                    If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                    strData += "," & Chr(34) & WK_AMT & Chr(34)                             '���Ϗ����z
                    strData += "," & Chr(34) & DtView1(i)("repr_empl_code") & Chr(34)       '�Ј��R�[�h
                    strData += "," & Chr(34) & DtView1(i)("repr_empl_name") & Chr(34)       '�C���S���Җ�
                    strData += "," & Chr(34) & DtView1(i)("vndr_code") & Chr(34)            '���[�J�[�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("vndr_name") & Chr(34)            '���[�J�[��
                    WK_str = New_Line_Cng(DtView1(i)("model_1"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                    '���f��
                    WK_str = New_Line_Cng(DtView1(i)("model_2"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                    '�@��
                    WK_str = New_Line_Cng(DtView1(i)("s_n"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                    '�����ԍ�
                    strData += "," & Chr(34) & DtView1(i)("rpar_cls") & Chr(34)             '�ۏ؏��
                    strData += "," & Chr(34) & DtView1(i)("rpar_name") & Chr(34)            '�ۏ؏��

                    '���i���
                    WK_DsList1.Clear()
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F40_05_2", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram1.Value = DtView1(i)("rcpt_no")
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN(ini)
                    DaList1.Fill(WK_DsList1, "T04_REP_PART")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        For j = 0 To WK_DtView1.Count - 1
                            Select Case j
                                Case Is < 7
                                    WK_str = New_Line_Cng(WK_DtView1(j)("part_code"))
                                    strData += "," & Chr(34) & WK_str & Chr(34)                         '���i�ԍ�
                                    WK_str = New_Line_Cng(WK_DtView1(j)("part_name"))
                                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                '���i��
                                    strData += "," & Chr(34) & WK_DtView1(j)("use_qty") & Chr(34)       '����
                                    strData += "," & Chr(34) & WK_DtView1(j)("cost_chrg") & Chr(34)     '�R�X�g
                                    strData += "," & Chr(34) & WK_DtView1(j)("shop_chrg") & Chr(34)     '�v��z
                                    strData += "," & Chr(34) & WK_DtView1(j)("eu_chrg") & Chr(34)       'EU�z

                                Case Is = 7
                                    If WK_DtView1.Count = 8 Then
                                        WK_str = New_Line_Cng(WK_DtView1(j)("part_code"))
                                        strData += "," & Chr(34) & WK_str & Chr(34)                     '���i�ԍ�
                                        WK_str = New_Line_Cng(WK_DtView1(j)("part_name"))
                                        strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)            '���i��
                                        strData += "," & Chr(34) & WK_DtView1(j)("use_qty") & Chr(34)   '����
                                        strData += "," & Chr(34) & WK_DtView1(j)("cost_chrg") & Chr(34) '�R�X�g
                                        strData += "," & Chr(34) & WK_DtView1(j)("shop_chrg") & Chr(34) '�v��z
                                        strData += "," & Chr(34) & WK_DtView1(j)("eu_chrg") & Chr(34)   'EU�z
                                    Else
                                        WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                        WK_AMT3 = WK_AMT3 + WK_DtView1(j)("cost_chrg")
                                        WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                        WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")
                                    End If

                                Case Else
                                    WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                    WK_AMT3 = WK_AMT3 + WK_DtView1(j)("cost_chrg")
                                    WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                    WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")

                            End Select
                        Next
                    End If

                    Select Case WK_DtView1.Count
                        Case Is < 8
                            For j = 1 To 8 - WK_DtView1.Count
                                strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                            Next
                        Case Is = 8
                        Case Else
                            strData += "," & Chr(34) & Chr(34)                  '���i�ԍ�
                            strData += "," & Chr(34) & "���̑����i" & Chr(34)   '���i��
                            strData += "," & Chr(34) & WK_AMT2 & Chr(34)        '����
                            strData += "," & Chr(34) & WK_AMT3 & Chr(34)        '�R�X�g
                            strData += "," & Chr(34) & WK_AMT4 & Chr(34)        '�v��z
                            strData += "," & Chr(34) & WK_AMT5 & Chr(34)        'EU�z
                    End Select

                    strData += "," & Chr(34) & DtView1(i)("comp_shop_part_chrg") & Chr(34)     '���i��
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_apes") & Chr(34)          'APSE
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_tech_chrg") & Chr(34)     '�Z�p��
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_fee") & Chr(34)           '���̑�
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_pstg") & Chr(34)          '����
                    WK_AMT = 0
                    If Not IsDBNull(DtView1(i)("comp_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("comp_shop_ttl")
                    strData += "," & Chr(34) & WK_AMT & Chr(34)                                     '���v
                    If Not IsDBNull(DtView1(i)("comp_shop_tax")) Then
                        strData += "," & Chr(34) & DtView1(i)("comp_shop_tax") & Chr(34)            '�����
                        strData += "," & Chr(34) & WK_AMT + DtView1(i)("comp_shop_tax") & Chr(34)   '���v
                    Else
                        strData += "," & Chr(34) & "0" & Chr(34)                                    '�����
                        strData += "," & Chr(34) & WK_AMT & Chr(34)                                 '���v
                    End If
                    If IsDBNull(DtView1(i)("aka_flg")) Then
                        strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)                   '�̎Ѓ��x�[�g
                    Else
                        If DtView1(i)("aka_flg") = "True" Then
                            strData += "," & Chr(34) & "0" & Chr(34)
                        Else
                            strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)
                        End If
                    End If

                    If IsDBNull(DtView1(i)("aka_flg")) Then
                        strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)                '���ȕ��S��
                    Else
                        If DtView1(i)("aka_flg") = "True" Then
                            strData += "," & Chr(34) & "0" & Chr(34)
                        Else
                            strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)
                        End If
                    End If

                    WK_str = Nothing
                    If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                        WK_DsList1.Clear()
                        strSQL = "SELECT V_M02_HSY.cls_code_name AS HSY_name"
                        strSQL += " FROM T01_member INNER JOIN"
                        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                        strSQL += " WHERE (T01_member.code = '" & DtView1(i)("qg_care_no") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("QGCare")
                        DaList1.Fill(WK_DsList1, "T01_member")
                        DB_CLOSE()
                        WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count <> 0 Then
                            If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str = Trim(WK_DtView1(0)("HSY_name"))
                        End If
                    End If
                    strData += "," & Chr(34) & WK_str & Chr(34)                                     'QG-Care�ۏ͈ؔ�
                    strData += "," & Chr(34) & DtView1(i)("rpar_comp_name") & Chr(34)               '�C�����
                    strData += "," & Chr(34) & DtView1(i)("rcpt_brch_name") & Chr(34)               '��t�p�f
                    If Not IsDBNull(DtView1(i)("zero_name")) Then
                        WK_str = DtView1(i)("zero_name")
                        strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '\0���R
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                    strData += "," & Chr(34) & DtView1(i)("sals_no") & Chr(34)                      '�l�o�`�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("sals_no2") & Chr(34)                     '�l�o�`�ԍ��i���x�[�g�j
                    strData += "," & Chr(34) & DtView1(i)("rcpt_no_aka") & Chr(34)                  '�ԓ`��t�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("orgnl_vndr_code") & Chr(34)              '�I���W�i�����[�J�[�R�[�h
                    If Not IsDBNull(DtView1(i)("user_trbl")) Then
                        WK_str = New_Line_Cng(DtView1(i)("user_trbl"))
                        strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '�\���Ǐ�
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                    If Not IsDBNull(DtView1(i)("comp_meas")) Then
                        WK_str = New_Line_Cng(DtView1(i)("comp_meas"))
                        strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '�C�����e
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                    strData += "," & Chr(34) & DtView1(i)("qg_care_no") & Chr(34)                   'QG-Care�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("sb_imei_old") & Chr(34)                  'SB/IMEI�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("sb_imei_new") & Chr(34)                  'SB/�VIMEI�ԍ�
                    'strData += ",END"

                    strData = Replace(strData, System.Environment.NewLine, "")
                    swFile.WriteLine(strData)
                Next
                swFile.Close()          '�t�@�C�������
                MessageBox.Show("�o�͂��܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            End If
        End If
        DsList1.Clear()
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �߂�
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        Close()
    End Sub
End Class
