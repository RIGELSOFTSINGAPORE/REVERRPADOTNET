Public Class F90_Form15
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData, WKstr As String
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
    Friend WithEvents Date04 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Date03 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Date01 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Date04 = New GrapeCity.Win.Input.Interop.Date
        Me.msg = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Interop.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Date03 = New GrapeCity.Win.Input.Interop.Date
        Me.Button99 = New System.Windows.Forms.Button
        Me.Date01 = New GrapeCity.Win.Input.Interop.Date
        Me.Label5 = New System.Windows.Forms.Label
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Date04
        '
        Me.Date04.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date04.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date04.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date04.Location = New System.Drawing.Point(224, 40)
        Me.Date04.Name = "Date04"
        Me.Date04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date04.Size = New System.Drawing.Size(104, 24)
        Me.Date04.TabIndex = 1496
        Me.Date04.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date04.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 108)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(316, 20)
        Me.msg.TabIndex = 1501
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(84, 140)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 28)
        Me.Button3.TabIndex = 1497
        Me.Button3.Text = "CSV�o��"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(196, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 24)
        Me.Label3.TabIndex = 1500
        Me.Label3.Text = "�`"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(224, 12)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 1494
        Me.Date02.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 1499
        Me.Label1.Text = "�o�^��"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(196, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 1503
        Me.Label2.Text = "�`"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 24)
        Me.Label4.TabIndex = 1502
        Me.Label4.Text = "������"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date03
        '
        Me.Date03.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date03.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date03.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date03.Location = New System.Drawing.Point(88, 40)
        Me.Date03.Name = "Date03"
        Me.Date03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date03.Size = New System.Drawing.Size(104, 24)
        Me.Date03.TabIndex = 1495
        Me.Date03.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date03.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(236, 140)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 1498
        Me.Button99.Text = "����"
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(88, 12)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1493
        Me.Date01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 24)
        Me.Label5.TabIndex = 1504
        Me.Label5.Text = "Coop"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(168, 72)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton2.TabIndex = 1506
        Me.RadioButton2.Text = "N�̂�"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(96, 72)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton1.TabIndex = 1505
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "�S��"
        '
        'F90_Form15
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(374, 183)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Date03)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Date04)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F90_Form15"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OBIC�p�o��"
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub F90_Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** ��������
    End Sub

    '********************************************************************
    '** ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date01.Text = Nothing
        Date02.Text = Nothing
        Date03.Text = Nothing
        Date04.Text = Nothing
        'Date01.Text = Format(DateAdd(DateInterval.Day, -1, Now.Date), "yyyy/MM") & "/01"
        'Date02.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date01.Text)))

        msg.Text = Nothing

    End Sub

    '******************************************************************
    '** ���ڃ`�F�b�N
    '******************************************************************
    Sub F_chk()
        Err_F = "0"
        msg.Text = Nothing

        If Date01.Number = 0 _
        And Date02.Number = 0 _
        And Date03.Number = 0 _
        And Date04.Number = 0 Then
            msg.Text = "�����̓��͂�����܂���B"
            Err_F = "1" : Date01.Focus() : Exit Sub
        End If

        DsList1.Clear()
        strSQL = "SELECT T01_member.code, T01_member.user_name, T01_member.use_name_kana, T01_member.zip, T01_member.adrs1"
        strSQL += ", T01_member.adrs2, T01_member.tel, M01_univ.univ_name, T01_member.dpmt_name, T01_member.sbjt_name"
        strSQL += ", T01_member.makr_code, M05_VNDR.name AS makr_name, T01_member.modl_name, T01_member.s_no"
        strSQL += ", T01_member.prch_amnt, V_M02_HSK.cls_code_name AS wrn_tem_name, T01_member.makr_wrn_stat"
        strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name, M04_shop.shop_name, T01_member.wrn_fee"
        strSQL += ", T01_member.Part_date, T01_member.reg_date, M04_shop.ittpan, T02_clct.clct_date"
        strSQL += ", M04_shop.shop_shop_code, M04_shop.ivc_old_flg, T01_member.wrn_range"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
        strSQL += " T02_clct ON T01_member.code = T02_clct.code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code"
        strSQL += " WHERE (T01_member.delt_flg = 0)"
        If RadioButton2.Checked = True Then
            strSQL += " AND (M04_shop.ittpan = 1)"
        End If
        strSQL += " AND (T01_member.wrn_range <> 7)"
        strSQL += " AND (T01_member.wrn_range <> 10)"
        If Date01.Number <> 0 Then strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
        If Date02.Number <> 0 Then strSQL += " AND (T01_member.reg_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
        If Date03.Number <> 0 Then strSQL += " AND (T02_clct.clct_date >= CONVERT(DATETIME, '" & Date03.Text & "', 102))"
        If Date04.Number <> 0 Then strSQL += " AND (T02_clct.clct_date <= CONVERT(DATETIME, '" & Date04.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T01_member")
        DB_CLOSE()

        If r = 0 Then
            msg.Text = "�Ώۃf�[�^������܂���B"
            Err_F = "1" : Date01.Focus() : Exit Sub
        End If

    End Sub

    '******************************************************************
    '** CSV�o��
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** ���ڃ`�F�b�N
        If Err_F = "0" Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "OBIC�p�����f�[�^" & Format(Now, "yyyyMMddHHmmss") & ".CSV" '�͂��߂̃t�@�C�������w�肷��
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

                waitDlg.MainMsg = "�f�[�^�o�͒�" ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMsg = ""        ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMax = r         ' �S�̂̏���������ݒ�
                waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

                '�f�[�^����������
                strData = "�����ԍ�,����,�����J�i,�X�֔ԍ�,�Z���P,�Z���Q,�d�b�ԍ�,��w��,�w����,�w�Ȗ�"
                strData = strData & ",���[�J�[�R�[�h,���[�J�[��,���f����,S/N,�w�����z,�ۏ؊���,���[�J�[�ۏ؊J�n"
                strData = strData & ",�ۏ͈ؔ̓R�[�h,�ۏ͈͖ؔ�,�̔��X,�ی���,������,�o�^���t,Coop,�X�܃R�[�h,��������,�ō��g��,�ۏ؊J�n��"
                swFile.WriteLine(strData)

                Cursor = System.Windows.Forms.Cursors.WaitCursor
                DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = DtView1(i)("code")                            '�����ԍ�
                    If Not IsDBNull(DtView1(i)("user_name")) Then WKstr = Replace(DtView1(i)("user_name"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '����
                    If Not IsDBNull(DtView1(i)("use_name_kana")) Then WKstr = Replace(DtView1(i)("use_name_kana"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�����J�i
                    strData = strData & "," & DtView1(i)("zip")             '�X�֔ԍ�
                    If Not IsDBNull(DtView1(i)("adrs1")) Then WKstr = Replace(DtView1(i)("adrs1"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�Z���P
                    If Not IsDBNull(DtView1(i)("adrs2")) Then WKstr = Replace(DtView1(i)("adrs2"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�Z���Q
                    If Not IsDBNull(DtView1(i)("tel")) Then WKstr = Replace(DtView1(i)("tel"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�d�b�ԍ�
                    If Not IsDBNull(DtView1(i)("univ_name")) Then WKstr = Replace(DtView1(i)("univ_name"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '��w��
                    If Not IsDBNull(DtView1(i)("dpmt_name")) Then WKstr = Replace(DtView1(i)("dpmt_name"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�w����
                    If Not IsDBNull(DtView1(i)("sbjt_name")) Then WKstr = Replace(DtView1(i)("sbjt_name"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�w�Ȗ�
                    If Not IsDBNull(DtView1(i)("makr_code")) Then WKstr = Replace(DtView1(i)("makr_code"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '���[�J�[�R�[�h
                    If Not IsDBNull(DtView1(i)("makr_name")) Then WKstr = Replace(DtView1(i)("makr_name"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '���[�J�[��
                    If Not IsDBNull(DtView1(i)("modl_name")) Then WKstr = Replace(DtView1(i)("modl_name"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '���f����
                    If Not IsDBNull(DtView1(i)("s_no")) Then WKstr = Replace(DtView1(i)("s_no"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         'S/N
                    strData = strData & "," & DtView1(i)("prch_amnt")       '�w�����z
                    strData = strData & "," & DtView1(i)("wrn_tem_name")    '�ۏ؊���
                    strData = strData & "," & DtView1(i)("makr_wrn_stat")   '���[�J�[�ۏ؊J�n
                    strData = strData & "," & DtView1(i)("wrn_range")       '�ۏ͈ؔ̓R�[�h
                    strData = strData & "," & DtView1(i)("wrn_range_name")  '�ۏ͈͖ؔ�
                    If Not IsDBNull(DtView1(i)("shop_name")) Then WKstr = Replace(DtView1(i)("shop_name"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�̔��X
                    strData = strData & "," & DtView1(i)("wrn_fee")         '�ی���
                    strData = strData & "," & DtView1(i)("Part_date")       '������
                    strData = strData & "," & DtView1(i)("reg_date")        '�o�^���t
                    If Not IsDBNull(DtView1(i)("ittpan")) Then
                        If DtView1(i)("ittpan") = "False" Then
                            strData = strData & ",Y"                        'Coop
                        Else
                            strData = strData & ",N"
                        End If
                    Else
                        strData = strData & ","
                    End If
                    If Not IsDBNull(DtView1(i)("shop_shop_code")) Then WKstr = Replace(DtView1(i)("shop_shop_code"), ",", " ") Else WKstr = ""
                    strData = strData & "," & WKstr                         '�X�܃R�[�h
                    If DtView1(i)("ivc_old_flg") = "False" Then
                        strData = strData & ",0"                            '��������
                    Else
                        strData = strData & ",1"
                    End If
                    strData = strData & "," & DtView1(i)("wrn_fee") * 1.1   '�ō��g��
                    strData = strData & "," & DtView1(i)("makr_wrn_stat")   '�ۏ؊J�n��

                    strData = Replace(strData, System.Environment.NewLine, "")
                    strData = Replace(strData, vbCrLf, "")
                    strData = Replace(strData, vbCr, "")
                    strData = Replace(strData, vbLf, "")
                    swFile.WriteLine(strData)

                Next
                swFile.Close()          '�t�@�C�������
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
                MessageBox.Show("CSV�o�͂��܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ����
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        Close()
    End Sub
End Class
