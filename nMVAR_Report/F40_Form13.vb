Public Class F40_Form13
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData, RE_F As String
    Dim i, j, r As Integer
    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer
    Dim WK_str As String
    Dim part_C1(7), part_C2(7) As String
    Dim part_C3(7), part_C4(7), part_C5(7), part_C6(7) As String
    Dim wk_C(8) As String

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
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Interop.Combo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form13))
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Interop.Combo
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(108, 68)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1776
        Me.Button98.Text = "�߂�"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 44)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(192, 16)
        Me.msg.TabIndex = 1777
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(20, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1775
        Me.Button1.Text = "CSV"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(8, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 24)
        Me.Label35.TabIndex = 1774
        Me.Label35.Text = "���o��"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 1778
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Combo001
        '
        Me.Combo001.Location = New System.Drawing.Point(104, 8)
        Me.Combo001.MaxDropDownItems = 12
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(92, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1780
        Me.Combo001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'F40_Form13
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(214, 104)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label35)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form13"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�d�|CSV�쐬�i���������j"
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F40_Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        CmbSet()    '**  �R���{�{�b�N�X�Z�b�g
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        '�����������H
        If Format(DateAdd(DateInterval.Day, 1, Now.Date), "dd") = "01" Then
            Label1.Text = Now.Date
        Else
            Label1.Text = DateAdd(DateInterval.Day, -1, CDate(Format(Now.Date, "yyyy/MM/") & "01"))
        End If

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  �R���{�{�b�N�X�Z�b�g
    '********************************************************************
    Sub CmbSet()
        DB_OPEN(ini)

        '���o��
        strSQL = "SELECT '' AS date, output_date FROM L05_CSV GROUP BY output_date ORDER BY output_date DESC"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "L05_CSV")
        DtView1 = New DataView(DsCMB.Tables("L05_CSV"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                DtView1(i)("date") = Format(DtView1(i)("output_date"), "yyyy/MM")
            Next
        End If

        Combo001.DataSource = DsCMB.Tables("L05_CSV")
        Combo001.DisplayMember = "date"
        Combo001.ValueMember = "date"

        DB_CLOSE()
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        '���o��
        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            msg.Text = "���o�N����I�����Ă��������B"
            Err_F = "1" : Combo001.Focus() : Exit Sub
        End If

        WK_DtView1 = New DataView(DsCMB.Tables("L05_CSV"), "date = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            msg.Text = "���o�N���̑Ώۃf�[�^������܂���B"
            Err_F = "1" : Combo001.Focus() : Exit Sub
        Else
            Label1.Text = WK_DtView1(0)("output_date")
        End If

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_07_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram2.Value = Label1.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN(ini)
        DaList1.Fill(DsList1, "WK_Print02")
        DB_CLOSE()

    End Sub

    '********************************************************************
    '**  CSV
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            re_csv()
        End If
        DsList1.Clear()
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub re_csv()

        Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
        sfd.FileName = "�d�|" & Format(CDate(Label1.Text), "yyyyMMdd") & ".CSV"  '�͂��߂̃t�@�C�������w�肷��
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
            strData += ",�̎Г`��,������R�[�h,�����於,���q�l��,��t�N����,�C��������,�����,�������t,���ϓ��t"
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
            strData += ",�\���Ǐ�,�C�����e,QG-Care�ԍ�,Note,�����R�����g"
            strData += ",Mobile���,���W�ԍ�,�o�^QG,iMVAR�Ǘ��ԍ�,SB/IMEI�ԍ�,SB/�VIMEI�ԍ�"
            swFile.WriteLine(strData)

            DtView1 = New DataView(DsList1.Tables("WK_Print02"), "", "rcpt_no", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                strData = Chr(34) & DtView1(i)("rcpt_no") & Chr(34)                         '�`�[�ԍ�
                strData += "," & Chr(34) & DtView1(i)("kjo_brch_name") & Chr(34)   '�v��QG
                strData += "," & Chr(34) & DtView1(i)("rcpt_name") & Chr(34)       '��t���
                strData += "," & Chr(34) & DtView1(i)("arvl_cls") & Chr(34)        '���׋敪�R�[�h
                strData += "," & Chr(34) & DtView1(i)("arvl_name") & Chr(34)       '���׋敪��
                strData += "," & Chr(34) & DtView1(i)("grup_code") & Chr(34)       '�O���[�v�R�[�h
                strData += "," & Chr(34) & DtView1(i)("grup_name") & Chr(34)       '�O���[�v��
                strData += "," & Chr(34) & DtView1(i)("store_code") & Chr(34)      '�掟�X�R�[�h
                strData += "," & Chr(34) & DtView1(i)("store_name") & Chr(34)      '�掟�X��
                strData += "," & Chr(34) & DtView1(i)("store_repr_no") & Chr(34)   '�̎Г`��
                strData += "," & Chr(34) & DtView1(i)("invc_code") & Chr(34)       '������R�[�h
                strData += "," & Chr(34) & DtView1(i)("invc_name") & Chr(34)       '�����於
                strData += "," & Chr(34) & DQM_Cng(DtView1(i)("user_name")) & Chr(34)       '���q�l��
                strData += "," & Chr(34) & DtView1(i)("accp_date") & Chr(34)       '��t�N����
                strData += "," & Chr(34) & DtView1(i)("comp_date") & Chr(34)       '�C��������
                strData += "," & Chr(34) & DtView1(i)("sals_date") & Chr(34)       '�����
                strData += "," & Chr(34) & DtView1(i)("clct_date") & Chr(34)       '�������t
                strData += "," & Chr(34) & DtView1(i)("etmt_date") & Chr(34)       '���ϓ��t
                strData += "," & Chr(34) & DtView1(i)("rsrv_cacl_date") & Chr(34)  '�񓚎�M��
                strData += "," & Chr(34) & DtView1(i)("part_ordr_date") & Chr(34)  '���i������
                strData += "," & Chr(34) & DtView1(i)("part_rcpt_date") & Chr(34)  '���i��̓�
                strData += "," & Chr(34) & DtView1(i)("etmt_shop_Gttl") & Chr(34)  '���Ϗ����z
                strData += "," & Chr(34) & DtView1(i)("repr_empl_code") & Chr(34)  '�Ј��R�[�h
                strData += "," & Chr(34) & DtView1(i)("repr_empl_name") & Chr(34)  '�C���S���Җ�
                strData += "," & Chr(34) & DtView1(i)("vndr_code") & Chr(34)       '���[�J�[�R�[�h
                strData += "," & Chr(34) & DtView1(i)("vndr_name") & Chr(34)       '���[�J�[��
                WK_str = New_Line_Cng(DtView1(i)("model_1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)         '���f��
                WK_str = New_Line_Cng(DtView1(i)("model_2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)         '�@��
                WK_str = New_Line_Cng(DtView1(i)("s_n"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)             '�����ԍ�
                strData += "," & Chr(34) & DtView1(i)("rpar_cls") & Chr(34)        '�ۏ؏��
                strData += "," & Chr(34) & DtView1(i)("rpar_name") & Chr(34)       '�ۏ؏��

                WK_str = New_Line_Cng(DtView1(i)("part_code1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty1") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg1") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg1") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg1") & Chr(34)        'EU�z

                WK_str = New_Line_Cng(DtView1(i)("part_code2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty2") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg2") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg2") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg2") & Chr(34)        'EU�z

                WK_str = New_Line_Cng(DtView1(i)("part_code3"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name3"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty3") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg3") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg3") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg3") & Chr(34)        'EU�z

                WK_str = New_Line_Cng(DtView1(i)("part_code4"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name4"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty4") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg4") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg4") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg4") & Chr(34)        'EU�z

                WK_str = New_Line_Cng(DtView1(i)("part_code5"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name5"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty5") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg5") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg5") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg5") & Chr(34)        'EU�z

                WK_str = New_Line_Cng(DtView1(i)("part_code6"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name6"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty6") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg6") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg6") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg6") & Chr(34)        'EU�z

                WK_str = New_Line_Cng(DtView1(i)("part_code7"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name7"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty7") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg7") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg7") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg7") & Chr(34)        'EU�z

                WK_str = New_Line_Cng(DtView1(i)("part_code8"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i�ԍ�
                WK_str = New_Line_Cng(DtView1(i)("part_name8"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '���i��
                strData += "," & Chr(34) & DtView1(i)("use_qty8") & Chr(34)        '����
                strData += "," & Chr(34) & DtView1(i)("cost_chrg8") & Chr(34)      '�R�X�g
                strData += "," & Chr(34) & DtView1(i)("shop_chrg8") & Chr(34)      '�v��z
                strData += "," & Chr(34) & DtView1(i)("eu_chrg8") & Chr(34)        'EU�z

                strData += "," & Chr(34) & DtView1(i)("comp_shop_part_chrg") & Chr(34)         '���i��
                strData += "," & Chr(34) & DtView1(i)("comp_shop_apes") & Chr(34)              'APSE
                strData += "," & Chr(34) & DtView1(i)("comp_shop_tech_chrg") & Chr(34)         '�Z�p��
                strData += "," & Chr(34) & DtView1(i)("comp_shop_fee") & Chr(34)               '���̑�
                strData += "," & Chr(34) & DtView1(i)("comp_shop_pstg") & Chr(34)              '����
                strData += "," & Chr(34) & DtView1(i)("comp_shop_ttl") & Chr(34)               '���v
                strData += "," & Chr(34) & DtView1(i)("comp_shop_tax") & Chr(34)               '�����
                strData += "," & Chr(34) & DtView1(i)("comp_shop_Gttl") & Chr(34)              '���v
                strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)                      '�̎Ѓ��x�[�g
                strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)                   '���ȕ��S��

                strData += "," & Chr(34) & DtView1(i)("HSY_name") & Chr(34)                    'QG-Care�ۏ͈ؔ�
                strData += "," & Chr(34) & DtView1(i)("rpar_comp_name") & Chr(34)              '�C�����
                strData += "," & Chr(34) & DtView1(i)("rcpt_brch_name") & Chr(34)              '��t�p�f
                If Not IsDBNull(DtView1(i)("zero_name")) Then
                    WK_str = DtView1(i)("zero_name")
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '\0���R
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("sals_no") & Chr(34)                     '�l�o�`�ԍ�
                strData += "," & Chr(34) & DtView1(i)("sals_no2") & Chr(34)                    '�l�o�`�ԍ��i���x�[�g�j
                strData += "," & Chr(34) & DtView1(i)("rcpt_no_aka") & Chr(34)                 '�ԓ`��t�ԍ�
                strData += "," & Chr(34) & DtView1(i)("orgnl_vndr_code") & Chr(34)             '�I���W�i�����[�J�[�R�[�h
                If Not IsDBNull(DtView1(i)("user_trbl")) Then
                    WK_str = New_Line_Cng(DtView1(i)("user_trbl"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '�\���Ǐ�
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_meas"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '�C�����e
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("qg_care_no") & Chr(34)                  'QG-Care�ԍ�
                If IsDBNull(DtView1(i)("note_kbn2")) Then
                    strData += "," & Chr(34) & Chr(34)                                         'Note
                Else
                    If DtView1(i)("note_kbn2") = "01" Then
                        strData += "," & Chr(34) & "1" & Chr(34)
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_comn"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '�����R�����g
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("defe_name") & Chr(34)                   'Mobile��ʁiCLS�F035�j
                strData += "," & Chr(34) & DtView1(i)("reference_no") & Chr(34)                '���W�ԍ�
                If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then
                    strData += "," & Chr(34) & Mid(DtView1(i)("imv_rcpt_no"), 1, 2) & Chr(34)  '�o�^QG
                    strData += "," & Chr(34) & DtView1(i)("imv_rcpt_no") & Chr(34)              'iMVAR�Ǘ��ԍ�
                Else
                    strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("sb_imei_old") & Chr(34)                 'SB/IMEI�ԍ�
                strData += "," & Chr(34) & DtView1(i)("sb_imei_new") & Chr(34)                 'SB/�VIMEI�ԍ�
                'strData += ",END"

                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          '�t�@�C�������
            MessageBox.Show("�o�͂��܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
            Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
        End If

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
