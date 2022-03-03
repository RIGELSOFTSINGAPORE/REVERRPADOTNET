Imports GrapeCity.Win.Input

Public Class F90_Form01_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, r As Integer
    Dim crt_date As Date

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        'Me.Furigana = Me.Edit02.Ime

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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents CheckBox01 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.CheckBox01 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 24)
        Me.Label6.TabIndex = 177
        Me.Label6.Text = "�J�i"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 24)
        Me.Label7.TabIndex = 176
        Me.Label7.Text = "��w��"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit03
        '
        Me.Edit03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(100, 80)
        Me.Edit03.MaxLength = 50
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(400, 24)
        Me.Edit03.TabIndex = 2
        Me.Edit03.Text = "Edit03"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(100, 48)
        Me.Edit02.MaxLength = 50
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(400, 24)
        Me.Edit02.TabIndex = 1
        Me.Edit02.Text = "Edit02"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit01
        '
        Me.Edit01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.Format = "9"
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(100, 16)
        Me.Edit01.MaxLength = 7
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(104, 24)
        Me.Edit01.TabIndex = 0
        Me.Edit01.Text = "01"
        Me.Edit01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "�R�[�h"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "�X�V"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(428, 172)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 5
        Me.Button99.Text = "����"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 144)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(484, 20)
        Me.msg.TabIndex = 1348
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox01
        '
        Me.CheckBox01.Location = New System.Drawing.Point(20, 112)
        Me.CheckBox01.Name = "CheckBox01"
        Me.CheckBox01.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox01.Size = New System.Drawing.Size(96, 24)
        Me.CheckBox01.TabIndex = 3
        Me.CheckBox01.Text = "�폜"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 24)
        Me.Label1.TabIndex = 1350
        Me.Label1.Text = "�o�^���F"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'F90_Form01_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(518, 207)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox01)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F90_Form01_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "��w�}�X�^"
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub F90_Form01_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** ��������
        Call dsp_set()  '** ��ʃZ�b�g
    End Sub

    '********************************************************************
    '** ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing

    End Sub

    '********************************************************************
    '** ��ʃZ�b�g
    '********************************************************************
    Sub dsp_set()

        If P_PRAM1 = Nothing Then '�V�K
            Button1.Text = "�o�^"
            Edit01.Enabled = True

            Edit01.Text = Nothing
            Edit02.Text = Nothing
            Edit03.Text = Nothing
            CheckBox01.Checked = False

        Else                    '�X�V
            Button1.Text = "�X�V"
            Edit01.Enabled = False

            DsList1.Clear()
            strSQL = "SELECT * FROM M01_univ WHERE (univ_code = " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "M01_univ")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M01_univ"), "", "", DataViewRowState.CurrentRows)
            Edit01.Text = DtView1(0)("univ_code")
            Edit02.Text = DtView1(0)("univ_name")
            If Not IsDBNull(DtView1(0)("univ_name_kana")) Then Edit03.Text = DtView1(0)("univ_name_kana") Else Edit03.Text = Nothing
            If Not IsDBNull(DtView1(0)("reg_date")) Then Label1.Text = Label1.Text & DtView1(0)("reg_date")
            If DtView1(0)("delt_flg") = "True" Then CheckBox01.Checked = True Else CheckBox01.Checked = False
        End If

    End Sub

    '********************************************************************
    '**  �ӂ肪�Ȏ����擾
    '********************************************************************
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' �擾�����ӂ肪�Ȃ�\�����܂��B
    '    If Edit02.ReadOnly = False Then
    '        Edit03.Text += e.ReadString
    '    End If
    'End Sub

    '******************************************************************
    '** ���ڃ`�F�b�N
    '******************************************************************
    Sub F_CHK()
        Err_F = "0"

        Call CK_Edit01() '����
        If msg.Text <> Nothing Then Err_F = "1" : Edit01.Focus() : Exit Sub

        Call CK_Edit02() '��w��
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        Call CK_Edit03() '�J�i
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

    End Sub
    Sub CK_Edit01() '����
        msg.Text = Nothing

        If P_PRAM1 = Nothing Then '�V�K
            Edit01.Text = Trim(Edit01.Text)
            If Edit01.Text = Nothing Then
                msg.Text = "���ނ̓��͂�����܂���B"
                Edit01.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DsList1.Clear()
                strSQL = "SELECT * FROM M01_univ WHERE (univ_code = " & Edit01.Text & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nQGCare")
                r = DaList1.Fill(DsList1, "M01_univ")
                DB_CLOSE()
                If r <> 0 Then
                    msg.Text = "���̺͂��ނ͓o�^�ς݂ł��B"
                    Edit01.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            Edit01.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Sub CK_Edit02() '��w��
        msg.Text = Nothing
        Edit02.Text = Trim(Edit02.Text)
        If Edit02.Text = Nothing Then
            msg.Text = "��w���̓��͂�����܂���B"
            Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DsList1.Clear()
            strSQL = "SELECT * FROM M01_univ"
            strSQL += " WHERE (univ_name = '" & Edit02.Text & "')"
            If P_PRAM1 <> Nothing Then strSQL += " AND (univ_code <> " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(DsList1, "M01_univ")
            DB_CLOSE()
            If r <> 0 Then
                msg.Text = "���͂̑�w���͓o�^�ς݂ł��B"
                Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit03() '�J�i
        msg.Text = Nothing
        Edit03.Text = Trim(Edit03.Text)
        If Edit03.Text = Nothing Then
            'msg.Text = "�J�i�̓��͂�����܂���B"
            'Edit03.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            DsList1.Clear()
            strSQL = "SELECT * FROM M01_univ"
            strSQL += " WHERE (univ_name = '" & Edit03.Text & "')"
            If P_PRAM1 <> Nothing Then strSQL += " AND (univ_code <> " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(DsList1, "M01_univ")
            DB_CLOSE()
            If r <> 0 Then
                msg.Text = "���͂̃J�i�͓o�^�ς݂ł��B"
                Edit03.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        Call CK_Edit01() '����
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CK_Edit02() '��w��
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CK_Edit03() '�J�i
    End Sub

    '******************************************************************
    '** �X�V
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_CHK()    '** ���ڃ`�F�b�N
        If Err_F = "0" Then

            DB_OPEN("nQGCare")
            If P_PRAM1 = Nothing Then   '�V�K
                crt_date = Now.Date
                P_PRAM1 = Edit01.Text

                strSQL = "INSERT INTO M01_univ"
                strSQL += " (univ_code, univ_name, univ_name_kana, reg_date, delt_flg)"
                strSQL += " VALUES (" & Edit01.Text & ""
                strSQL += ", '" & Edit02.Text & "'"
                strSQL += ", '" & Edit03.Text & "'"
                strSQL += ", CONVERT(DATETIME, '" & crt_date & "', 102)"
                If CheckBox01.Checked = True Then strSQL += ", 1)" Else strSQL += ", 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                MessageBox.Show("�o�^���܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else                        '�X�V
                strSQL = "UPDATE M01_univ"
                strSQL += " SET univ_name = '" & Edit02.Text & "'"
                strSQL += ", univ_name_kana = '" & Edit03.Text & "'"
                If CheckBox01.Checked = True Then strSQL += ", delt_flg = 1" Else strSQL += ", delt_flg = 0"
                strSQL += " WHERE (univ_code = " & P_PRAM1 & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                MessageBox.Show("�X�V���܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            DB_CLOSE()

            P_RTN = "1"
            DsList1.Clear()
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ����
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_RTN = "0"
        DsList1.Clear()
        Close()
    End Sub
End Class
