Public Class F50_Form10_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DtView1, cls_DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, chg_itm As Integer
    Dim M_CLS As String = "M10"
    Dim WK_str, WK_str2 As String

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
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.msg = New System.Windows.Forms.Label
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 208)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(800, 24)
        Me.msg.TabIndex = 1290
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(664, 240)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 32)
        Me.Button80.TabIndex = 1280
        Me.Button80.Text = "����"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1279
        Me.Button1.Text = "�X�V"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(744, 240)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 1281
        Me.Button98.Text = "�߂�"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(584, 24)
        Me.Label1.TabIndex = 1289
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Edit1
        '
        Me.Edit1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit1.Format = "9"
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(112, 48)
        Me.Edit1.MaxLength = 2
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(56, 24)
        Me.Edit1.TabIndex = 1274
        Me.Edit1.Text = "1"
        Me.Edit1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 88)
        Me.Label6.TabIndex = 1288
        Me.Label6.Text = "�R�����g"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 24)
        Me.Label7.TabIndex = 1287
        Me.Label7.Text = "���ĺ���"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(112, 80)
        Me.Edit001.MaxLength = 200
        Me.Edit001.Multiline = True
        Me.Edit001.Name = "Edit001"
        Me.Edit001.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit001.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(720, 88)
        Me.Edit001.TabIndex = 1275
        Me.Edit001.Text = "��������������������"
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Top
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(112, 176)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 24)
        Me.CheckBox001.TabIndex = 1278
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(720, 16)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1285
        Me.Label001.Text = "Label002"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(16, 176)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 24)
        Me.Label52.TabIndex = 1284
        Me.Label52.Text = "�폜�t���O"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(632, 16)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1283
        Me.Label51.Text = "�o�^��"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F50_Form10_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(850, 284)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form10_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�R�����g�}�X�^"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F50_Form10_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        ACES()      '**  �����`�F�b�N
        DspSet()    '**  ��ʃZ�b�g
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='510'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "2"
                CheckBox001.Enabled = False
                Button1.Enabled = False
            Case Is = "3"
                CheckBox001.Enabled = False
                Button1.Enabled = True
            Case Is = "4"
                CheckBox001.Enabled = True
                Button1.Enabled = True
        End Select
    End Sub

    '********************************************************************
    '**  ��ʃZ�b�g
    '********************************************************************
    Sub DspSet()
        DsList1.Clear()

        strSQL = "SELECT cls_code, cls_code + ':' + cls_name AS cls_name"
        strSQL +=  " FROM M10_CMNT"
        strSQL +=  " WHERE (cls_code = '" & P_PRAM1 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M10_CMNT_1")
        DB_CLOSE()

        cls_DtView1 = New DataView(DsList1.Tables("M10_CMNT_1"), "", "", DataViewRowState.CurrentRows)
        If cls_DtView1.Count <> 0 Then
            Label1.Text = Trim(cls_DtView1(0)("cls_name"))
        End If

        If P_PRAM2 = Nothing Then   '�V�K
            Button1.Text = "�o�^"
            Button80.Enabled = False
            Edit1.Enabled = True
            Edit1.Text = Nothing
            Edit001.Text = Nothing
            CheckBox001.Checked = False
            Label001.Text = Nothing

        Else                        '�C��
            Button1.Text = "�X�V"
            Button80.Enabled = True
            Edit1.Enabled = False

            'CLS_CODE
            strSQL = "SELECT * FROM M10_CMNT"
            strSQL +=  " WHERE (cls_code = '" & P_PRAM1 & "')"
            strSQL +=  " AND (cmnt_code = '" & P_PRAM2 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(DsList1, "M10_CMNT")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M10_CMNT"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                Edit1.Text = P_PRAM2
                Edit001.Text = DtView1(0)("cmnt")
                If DtView1(0)("delt_flg") = "1" Then
                    CheckBox001.Checked = True
                Else
                    CheckBox001.Checked = False
                End If
                Label001.Text = DtView1(0)("reg_date")
            End If
        End If
    End Sub

    '********************************************************************
    '**  ���ڃ`�F�b�N
    '********************************************************************
    Sub CHK_Edit1()   '�R�����g�R�[�h
        msg.Text = Nothing

        Edit1.Text = Trim(Edit1.Text)
        If Edit1.Text = Nothing Then
            Edit1.BackColor = System.Drawing.Color.Red
            msg.Text = "�R�����g�R�[�h�����͂���Ă��܂���B"
            Exit Sub
        Else
            If Len(Trim(Edit1.Text)) <> 2 Then
                Edit1.BackColor = System.Drawing.Color.Red
                msg.Text = "�R�����g�R�[�h��2���œ��͂��Ă��������B"
                Exit Sub
            End If

            WK_DsList1.Clear()
            strSQL = "SELECT * FROM M10_CMNT"
            strSQL +=  " WHERE (cls_code = '" & P_PRAM1 & "')"
            strSQL +=  " AND (cmnt_code = '" & Trim(Edit1.Text) & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "M10_CMNT")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("M10_CMNT"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                Edit1.BackColor = System.Drawing.Color.Red
                msg.Text = "�R�����g�R�[�h�����ɓo�^����Ă��܂��B"
                Exit Sub
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Edit001()   '�R�����g
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "�R�����g�����͂���Ă��܂���B"
            Exit Sub
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        If P_PRAM2 = Nothing Then   '�V�K
            CHK_Edit1() '�R�����g�R�[�h
            If msg.Text <> Nothing Then Err_F = "1" : Edit1.Focus() : Exit Sub
        End If

        CHK_Edit001() '�R�����g
        If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.GotFocus
        Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        CHK_Edit1()     '�R�����g�R�[�h
    End Sub
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '�R�����g
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        CheckBox001.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '**  �ύX����
    '********************************************************************
    Sub CHG_HSTY()
        DtView1 = New DataView(DsList1.Tables("M10_CMNT"), "", "", DataViewRowState.CurrentRows)

        If Edit001.Text <> DtView1(0)("cmnt") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, P_PRAM1 & Edit1.Text, "�R�����g", DtView1(0)("cmnt"), Edit001.Text)
        End If

        If DtView1(0)("delt_flg") = "1" Then
            If CheckBox001.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, P_PRAM1 & Edit1.Text, "�폜�t���O", "�폜", "")
            End If
        Else
            If CheckBox001.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, P_PRAM1 & Edit1.Text, "�폜�t���O", "", "�폜")
            End If
        End If

    End Sub

    '********************************************************************
    '**  �X�V
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        chg_itm = 0
        P_HSTY_DATE = Now
        F_Check()   '**  ���ڃ`�F�b�N
        If Err_F = "0" Then
            If P_PRAM2 = Nothing Then   '�V�K
                Label001.Text = Now.Date

                strSQL = "INSERT INTO M10_CMNT"
                strSQL +=  " (cls_code, cmnt_code, cmnt, cls_name, reg_date, delt_flg)"
                strSQL +=  " VALUES ('" & P_PRAM1 & "'"
                strSQL +=  ", '" & Edit1.Text & "'"
                strSQL +=  ", '" & Trim(Edit001.Text) & "'"
                strSQL +=  ", '" & Mid(Trim(Label1.Text), 4, 40) & "'"
                strSQL +=  ", '" & CDate(Label001.Text) & "'"
                If CheckBox001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
                strSQL += ")"
                DB_OPEN("nMVAR")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                add_MTR_hsty(M_CLS, P_PRAM1 & Edit1.Text, "�V�K�o�^", "", "")
                msg.Text = "�o�^���܂����B"
                P_RTN = "1"
                P_PRAM2 = Edit1.Text
                DspSet()    '**  ��ʃZ�b�g
            Else                        '�C��

                CHG_HSTY()  '**  �ύX����
                If chg_itm <> 0 Then
                    strSQL = "UPDATE M10_CMNT"
                    strSQL +=  " SET cmnt = '" & Trim(Edit001.Text) & "'"
                    If CheckBox001.Checked = True Then strSQL +=  ", delt_flg = 1" Else strSQL +=  ", delt_flg = 0"
                    strSQL +=  " WHERE (cls_code = '" & P_PRAM1 & "')"
                    strSQL +=  " AND (cmnt_code = '" & P_PRAM2 & "')"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If

                If chg_itm = 0 Then
                    msg.Text = "�ύX�ӏ�������܂���B"
                Else
                    msg.Text = "�X�V���܂����B"
                    DspSet()    '**  ��ʃZ�b�g
                End If
                P_RTN = "1"
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ����
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '�ύX����
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L02_MTR_HSTY", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 3)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 20)
        Pram3.Value = M_CLS
        Pram4.Value = P_PRAM1 & Trim(Edit1.Text)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  �߂�
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsCMB.Clear()
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
