Public Class F40_Form14
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData As String
    Dim i, j, r, seq As Integer
    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer
    Dim WK_str, WK_str2, Br_rcpt_no As String

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form14))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Date2 = New GrapeCity.Win.Input.Interop.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(228, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 1872
        Me.Label2.Text = "�`"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(124, 28)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(104, 24)
        Me.Date1.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.TabIndex = 1865
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.Value = Nothing
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(252, 28)
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(104, 24)
        Me.Date2.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.TabIndex = 1866
        Me.Date2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date2.Value = Nothing
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(28, 28)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 24)
        Me.Label35.TabIndex = 1871
        Me.Label35.Text = "�͈͎w��"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(288, 88)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1869
        Me.Button98.Text = "�߂�"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(28, 68)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(328, 16)
        Me.msg.TabIndex = 1870
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1868
        Me.Button1.Text = "CSV"
        '
        'F40_Form14
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(376, 123)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form14"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OBIA�pCSV�쐬"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F40_Form06_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Date1.Text = Format(Now.Date, "yyyy/MM/") & "01"
        Date2.Text = Format(Now.Date, "yyyy/MM/dd")
        msg.Text = Nothing
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        '�͈͎w��(FROM)
        If Date1.Number = 0 Then
            msg.Text = "�͈͎w�����͂��Ă��������B"
            Err_F = "1" : Date1.Focus() : Exit Sub
        End If

        '�͈͎w��(TO)
        If Date2.Number = 0 Then
            msg.Text = "�͈͎w�����͂��Ă��������B"
            Err_F = "1" : Date2.Focus() : Exit Sub
        End If

        'FROM > TO
        If Date1.Number > Date2.Number Then
            msg.Text = "�͈͎w�肪�Ԉ���Ă��܂��B"
            Err_F = "1" : Date2.Focus() : Exit Sub
        End If

        'DataTable�쐬()
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_14", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = Date1.Text
        Pram2.Value = DateAdd(DateInterval.Day, 1, CDate(Date2.Text))
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN(ini)
        r = DaList1.Fill(DsList1, "WK_Print01")
        DB_CLOSE()

        If r = 0 Then
            msg.Text = "�Ώۃf�[�^������܂���B"
            Err_F = "1" : Date1.Focus() : Exit Sub
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
            sfd.FileName = "OBIC�pdata" & Format(CDate(Date1.Text), "yyyyMMdd") & "_" & Format(CDate(Date2.Text), "yyyyMMdd") & ".CSV" '�͂��߂̃t�@�C�������w�肷��
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
                strData = "�`�[�ԍ�,�s�ԍ�,�v��QG�R�[�h,�v��QG,��t��ʃR�[�h,��t���,���׋敪�R�[�h,���׋敪��,�O���[�v�R�[�h,�O���[�v��,�掟�X�R�[�h"
                ' strData += ",�掟�X��,�̎Г`��,������R�[�h,�����於,���q�l��,���̓�,�C��������,�����,�������t,���ϓ��t,�񓚎�M��,���i������"
                strData += ",�掟�X��,�̎Г`��,������R�[�h,�����於,���q�l��,��t�N����,�C��������,�����,�������t,���ϓ��t,�񓚎�M��,���i������" 'CR against changes 07/04/2021
                strData += ",���i��̓�,���Ϗ����z,�Ј��R�[�h,�C���S���Җ�,���[�J�[�R�[�h,���[�J�[��,���f��,�@��,�����ԍ�,�ۏ؏��,�ۏ؏��,���i�ԍ�"
                strData += ",���i��,���i����,���i�R�X�g,���i�v��z,���iEU�z,���i��,APSE,�Z�p��,���̑�,����,���v,�����,���v,�a���,�̎Ѓ��x�[�g"
                strData += ",���ȕ��S��,QG-Care�ۏ͈ؔ̓R�[�h,QG-Care�ۏ͈ؔ�,�C�����,��t�p�f,�[���~���R,�l�o�`�ԍ�,�l�o�`�ԍ��i���x�[�g�j,�ԓ`����t�ԍ�"
                strData += ",�I���W�i�����[�J�[�R�[�h,�\���Ǐ�,�C�����e,QG-Care�ԍ�,Note,�����R�����g,Mobile���,���W�ԍ�,�o�^QG,iMVAR�Ǘ��ԍ�"
                strData += ",��t�R�����g,SB/IMEI�ԍ�,SB/�VIMEI�ԍ�,������ʃR�[�h,�������"
                swFile.WriteLine(strData)

                DtView1 = New DataView(DsList1.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    If Br_rcpt_no = DtView1(i)("rcpt_no") Then
                        seq = seq + 1
                    Else
                        Br_rcpt_no = DtView1(i)("rcpt_no")
                        seq = 1
                    End If

                    strData = Chr(34) & DtView1(i)("rcpt_no") & Chr(34)                             '�`�[�ԍ�
                    strData += "," & Chr(34) & seq & Chr(34)                                        '�s�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("kjo_brch_code") & Chr(34)                '�v��QG�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("kjo_brch_name") & Chr(34)                '�v��QG
                    strData += "," & Chr(34) & DtView1(i)("rcpt_cls") & Chr(34)                     '��t��ʃR�[�h
                    strData += "," & Chr(34) & DtView1(i)("rcpt_name") & Chr(34)                    '��t���
                    strData += "," & Chr(34) & DtView1(i)("arvl_cls") & Chr(34)                     '���׋敪�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("arvl_name") & Chr(34)                    '���׋敪��
                    strData += "," & Chr(34) & DtView1(i)("grup_code") & Chr(34)                    '�O���[�v�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("grup_name") & Chr(34)                    '�O���[�v��
                    strData += "," & Chr(34) & DtView1(i)("store_code") & Chr(34)                   '�掟�X�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("store_name") & Chr(34)                   '�掟�X��
                    strData += "," & Chr(34) & DtView1(i)("store_repr_no") & Chr(34)                '�̎Г`��
                    strData += "," & Chr(34) & DtView1(i)("invc_code") & Chr(34)                    '������R�[�h
                    strData += "," & Chr(34) & DtView1(i)("invc_name") & Chr(34)                    '�����於
                    strData += "," & Chr(34) & DQM_Cng(DtView1(i)("user_name")) & Chr(34)           '���q�l��
                    strData += "," & Chr(34) & DtView1(i)("acdt_date") & Chr(34)                    '���̓�
                    strData += "," & Chr(34) & DtView1(i)("comp_date") & Chr(34)                    '�C��������
                    strData += "," & Chr(34) & DtView1(i)("sals_date") & Chr(34)                    '�����
                    strData += "," & Chr(34) & DtView1(i)("clct_date") & Chr(34)                    '�������t
                    strData += "," & Chr(34) & DtView1(i)("etmt_date") & Chr(34)                    '���ϓ��t
                    strData += "," & Chr(34) & DtView1(i)("rsrv_cacl_date") & Chr(34)               '�񓚎�M��
                    strData += "," & Chr(34) & DtView1(i)("part_ordr_date") & Chr(34)               '���i������
                    strData += "," & Chr(34) & DtView1(i)("part_rcpt_date") & Chr(34)               '���i��̓�
                    WK_AMT = 0
                    If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                    If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                    strData += "," & Chr(34) & WK_AMT & Chr(34)                                     '���Ϗ����z
                    strData += "," & Chr(34) & DtView1(i)("repr_empl_code") & Chr(34)               '�Ј��R�[�h
                    strData += "," & Chr(34) & DtView1(i)("repr_empl_name") & Chr(34)               '�C���S���Җ�
                    strData += "," & Chr(34) & DtView1(i)("vndr_code") & Chr(34)                    '���[�J�[�R�[�h
                    strData += "," & Chr(34) & DtView1(i)("vndr_name") & Chr(34)                    '���[�J�[��
                    WK_str = New_Line_Cng(DtView1(i)("model_1"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '���f��
                    WK_str = New_Line_Cng(DtView1(i)("model_2"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '�@��
                    WK_str = New_Line_Cng(DtView1(i)("s_n"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '�����ԍ�
                    strData += "," & Chr(34) & DtView1(i)("rpar_cls") & Chr(34)                     '�ۏ؏��
                    strData += "," & Chr(34) & DtView1(i)("rpar_name") & Chr(34)                    '�ۏ؏��
                    If Not IsDBNull(DtView1(i)("part_code")) Then
                        WK_str = New_Line_Cng(DtView1(i)("part_code"))
                        strData += "," & Chr(34) & WK_str & Chr(34)                                 '���i�ԍ�
                        WK_str = New_Line_Cng(DtView1(i)("part_name"))
                        strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '���i��
                        strData += "," & Chr(34) & DtView1(i)("use_qty") & Chr(34)                  '���i����
                        strData += "," & Chr(34) & DtView1(i)("cost_chrg") & Chr(34)                '���i�R�X�g
                        strData += "," & Chr(34) & DtView1(i)("shop_chrg") & Chr(34)                '���i�v��z
                        strData += "," & Chr(34) & DtView1(i)("eu_chrg") & Chr(34)                  '���iEU�z
                    Else
                        strData += "," & Chr(34) & Chr(34)                                          '���i�ԍ�
                        strData += "," & Chr(34) & Chr(34)                                          '���i��
                        strData += "," & Chr(34) & "0" & Chr(34)                                    '���i����
                        strData += "," & Chr(34) & "0" & Chr(34)                                    '���i�R�X�g
                        strData += "," & Chr(34) & "0" & Chr(34)                                    '���i�v��z
                        strData += "," & Chr(34) & "0" & Chr(34)                                    '���iEU�z
                    End If
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_part_chrg") & Chr(34)          '���i��
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_apes") & Chr(34)               'APSE
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_tech_chrg") & Chr(34)          '�Z�p��
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_fee") & Chr(34)                '���̑�
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_pstg") & Chr(34)               '����
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
                    strData += "," & Chr(34) & DtView1(i)("recv_amnt") & Chr(34)                    '�a���
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

                    WK_str = Nothing : WK_str2 = Nothing
                    If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                        WK_DsList1.Clear()
                        strSQL = "SELECT T01_member.wrn_range, V_M02_HSY.cls_code_name AS HSY_name"
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
                            If Not IsDBNull(WK_DtView1(0)("wrn_range")) Then WK_str = Trim(WK_DtView1(0)("wrn_range"))
                            If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str2 = Trim(WK_DtView1(0)("HSY_name"))
                        End If
                    End If
                    strData += "," & Chr(34) & WK_str & Chr(34)                                     'QG-Care�ۏ͈ؔ̓R�[�h
                    strData += "," & Chr(34) & WK_str2 & Chr(34)                                    'QG-Care�ۏ͈ؔ�

                    strData += "," & Chr(34) & DtView1(i)("rpar_comp_name") & Chr(34)               '�C�����
                    strData += "," & Chr(34) & DtView1(i)("rcpt_brch_name") & Chr(34)               '��t�p�f
                    If Not IsDBNull(DtView1(i)("zero_name")) Then
                        WK_str = DtView1(i)("zero_name")
                        strData += "," & Chr(34) & WK_str & Chr(34)                                 '\0���R
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
                    strData += "," & DtView1(i)("qg_care_no")                                       'QG-Care�ԍ�
                    If IsDBNull(DtView1(i)("note_kbn2")) Then
                        strData += "," & Chr(34) & Chr(34)                                          'Note
                    Else
                        If DtView1(i)("note_kbn2") = "01" Then
                            strData += "," & Chr(34) & "1" & Chr(34)
                        Else
                            strData += "," & Chr(34) & Chr(34)
                        End If
                    End If
                    If Not IsDBNull(DtView1(i)("comp_comn")) Then
                        WK_str = New_Line_Cng(DtView1(i)("comp_comn"))
                        strData += "," & Chr(34) & WK_str & Chr(34)                                 '�����R�����g
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                    strData += "," & Chr(34) & DtView1(i)("defe_name") & Chr(34)                    'Mobile��ʁiCLS�F035�j
                    strData += "," & Chr(34) & DtView1(i)("reference_no") & Chr(34)                 '���W�ԍ�
                    If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then
                        strData += "," & Chr(34) & Mid(DtView1(i)("imv_rcpt_no"), 1, 2) & Chr(34)   '�o�^QG
                        strData += "," & Chr(34) & DtView1(i)("imv_rcpt_no") & Chr(34)              'iMVAR�Ǘ��ԍ�
                    Else
                        strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                    End If
                    WK_str = New_Line_Cng(DtView1(i)("rcpt_comn"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '��t�R�����g
                    strData += "," & Chr(34) & DtView1(i)("sb_imei_old") & Chr(34)                  'SB/IMEI�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("sb_imei_new") & Chr(34)                  'SB/�VIMEI�ԍ�
                    strData += "," & Chr(34) & DtView1(i)("payment_type") & Chr(34)                 '������ʃR�[�h
                    strData += "," & Chr(34) & DtView1(i)("payment_type_name") & Chr(34)            '�������

                    strData = Replace(strData, System.Environment.NewLine, " ")
                    strData = Replace(strData, vbCrLf, " ")
                    strData = Replace(strData, vbCr, " ")
                    strData = Replace(strData, vbLf, " ")
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
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
