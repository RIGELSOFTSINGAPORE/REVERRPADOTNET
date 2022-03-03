Public Class F40_Form04
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strFile, strData As String
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
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        '
        'F40_Form04
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(115, 6)
        Me.ControlBox = False
        Me.Name = "F40_Form04"
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Web�p�f�[�^�쐬"

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F40_Form04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_web_exp", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = DateAdd(DateInterval.Month, -3, Now)
        Pram2.Value = DateAdd(DateInterval.Day, -10, Now)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN(ini)
        r = DaList1.Fill(DsList1, "csv")
        DB_CLOSE()

        If r = 0 Then
            MessageBox.Show("�Ώۃf�[�^������܂���B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "WebData.CSV"                            '�͂��߂̃t�@�C�������w�肷��
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
                strData = "�̎Г`��,�`�[�ԍ�,��t�N����,MAKERN,���i��,���i�ԍ�,���ϓ��t,�C��������,�X�e�[�^�X,�R�����g,����R�[�h"
                swFile.WriteLine(strData)

                DtView1 = New DataView(DsList1.Tables("csv"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = DtView1(i)("store_repr_no")               '�̎Г`��
                    strData += "," & DtView1(i)("rcpt_no")     '�`�[�ԍ�
                    strData += "," & DtView1(i)("accp_date")   '��t�N����
                    strData += "," & DtView1(i)("vndr_name")   '���[�J�[
                    strData += "," & DtView1(i)("model_1")     '���i��
                    strData += "," & DtView1(i)("model_2")     '���i�ԍ�
                    strData += "," & DtView1(i)("etmt_date")   '���ϓ��t
                    strData += "," & DtView1(i)("comp_date")   '�C��������
                    If IsDBNull(DtView1(i)("comp_date")) Then
                        If IsDBNull(DtView1(i)("etmt_date")) Then
                            strData += ",1"                    '�X�e�[�^�X
                        Else
                            strData += ",2"                    '�X�e�[�^�X
                        End If
                    Else
                        strData += ",5"                        '�X�e�[�^�X
                    End If
                    If DtView1(i)("rcpt_cls") = "01" Then
                        strData += ",�L:"                      '�R�����g
                    Else
                        strData += ",��:"                      '�R�����g
                    End If
                    If Not IsDBNull(DtView1(i)("comp_date")) Then
                        strData += "����"                      '�R�����g
                    Else
                        If Not IsDBNull(DtView1(i)("etmt_date")) Then
                            strData += "����"                  '�R�����g
                        Else
                            strData += "����"                  '�R�����g
                        End If
                    End If
                    strData += "," & DtView1(i)("grup_code")   '����R�[�h
                    swFile.WriteLine(strData)
                Next

                swFile.Close()          '�t�@�C�������
                MessageBox.Show("�o�͂��܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
            End If
        End If

        DsList1.Clear()
        Close()
    End Sub
End Class
