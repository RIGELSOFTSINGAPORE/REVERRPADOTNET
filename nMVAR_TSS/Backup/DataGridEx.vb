
Public Class DataGridEx
    Inherits System.Windows.Forms.DataGrid

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    'UserControl �̓R���|�[�l���g�ꗗ���������邽�߂� dispose ���I�[�o�[���C�h���܂��B
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Public Event CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean)

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean
        Select Case keyData
            Case Keys.Return, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Space, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Delete, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Right, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
            Case Keys.Left, Keys.Tab
                RaiseEvent CmdKeyEvent(keyData, blnCancel)
                If blnCancel Then
                    Return True
                End If
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
