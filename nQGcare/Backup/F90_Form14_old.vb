Public Class F90_Form14_old
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

    Dim strSQL, Err_F, inz_F, strFile, strData As String
    Dim i, r As Integer
    Dim Line As Integer = 1     '�s
    Dim BR_date As String

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Date
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date00 As GrapeCity.Win.Input.Date
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Date
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date00 = New GrapeCity.Win.Input.Date
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date00, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(180, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 24)
        Me.Label3.TabIndex = 1475
        Me.Label3.Text = "�`"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(204, 44)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 2
        Me.Date02.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 1474
        Me.Label1.Text = "�\����"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(76, 44)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1
        Me.Date01.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(72, 112)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 28)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "�G�N�Z���o��"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(224, 112)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 4
        Me.Button99.Text = "����"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 80)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(316, 20)
        Me.msg.TabIndex = 1478
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 24)
        Me.Label2.TabIndex = 1480
        Me.Label2.Text = "�N��"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date00
        '
        Me.Date00.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date00.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date00.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date00.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM", "", "")
        Me.Date00.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date00.Location = New System.Drawing.Point(76, 8)
        Me.Date00.Name = "Date00"
        Me.Date00.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date00.Size = New System.Drawing.Size(80, 24)
        Me.Date00.TabIndex = 0
        Me.Date00.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date00.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date00.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'F90_Form14_old
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(346, 151)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date00)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F90_Form14_old"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�G�N�Z���o��"
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date00, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub F90_Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** ��������
        Call DsSet()    '** �f�[�^�Z�b�g
    End Sub

    '********************************************************************
    '** ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date00.Text = Format(DateAdd(DateInterval.Day, -1, Now.Date), "yyyy/MM")
        BR_date = Date00.Text
        Date01.Text = Date00.Text & "/01"
        Date02.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date01.Text)))
        msg.Text = Nothing

    End Sub

    '********************************************************************
    '** �f�[�^�Z�b�g
    '********************************************************************
    Sub DsSet()
        WK_DsList1.Clear()

        '���[�J�[
        strSQL = "SELECT vndr_code, name FROM M05_VNDR"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "M05_VNDR")
        DB_CLOSE()

    End Sub

    '******************************************************************
    '** ���ڃ`�F�b�N
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        Call CK_Date01()    '�\����(From)
        If msg.Text <> Nothing Then Err_F = "1" : Date01.Focus() : Exit Sub

        Call CK_Date02()    '�\����(To)
        If msg.Text <> Nothing Then Err_F = "1" : Date02.Focus() : Exit Sub

    End Sub
    Sub CK_Date00()     '�N��
        msg.Text = Nothing
        If BR_date <> Date00.Text Then

            If Date00.Number = 0 Then
                'msg.Text = "�N���̓��͂�����܂���B"
                'Date00.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                Date01.Text = Date00.Text & "/01"
                Date02.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date01.Text)))
                Date01.BackColor = System.Drawing.SystemColors.Window
                Date02.BackColor = System.Drawing.SystemColors.Window
            End If
            BR_date = Date00.Text
            'Date00.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Sub CK_Date01()     '�\����(From)
        msg.Text = Nothing

        If Date01.Number = 0 Then
            msg.Text = "�\����(From)�̓��͂�����܂���B"
            Date01.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Date01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date02()     '�\����(To)
        msg.Text = Nothing

        If Date02.Number = 0 Then
            msg.Text = "�\����(To)�̓��͂�����܂���B"
            Date02.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Date01.Number <> 0 Then
                If Date01.Number > Date02.Number Then
                    msg.Text = "�\�����͈͎̔w�肪����������܂���B"
                    Date02.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If

        End If
        Date02.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Date00_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date00.LostFocus
        Call CK_Date00()    '�N��
    End Sub
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        Call CK_Date01()    '�\����(From)
    End Sub
    Private Sub Date02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date02.LostFocus
        Call CK_Date02()    '�\����(To)
    End Sub

    '******************************************************************
    '** �G�N�Z���o��
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** ���ڃ`�F�b�N
        If Err_F = "0" Then

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_XLS", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
            Pram1.Value = Date01.Text
            Pram2.Value = Date02.Text
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(DsList1, "XLS")
            DB_CLOSE()

            If r = 0 Then
                msg.Text = "�Ώۃf�[�^������܂���B"
            Else

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

                waitDlg.MainMsg = "�f�[�^���o��" ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMsg = ""        ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
                waitDlg.ProgressMax = r         ' �S�̂̏���������ݒ�
                waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim oExcel As Object
                Dim oBook As Object
                Dim oSheet As Object

                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add

                Line = 1
                oSheet = oBook.Worksheets(1)
                oSheet.Range("A1").Value = "�����ԍ�"
                oSheet.Range("B1").Value = "����"
                oSheet.Range("C1").Value = "�����J�i"
                oSheet.Range("D1").Value = "�X�֔ԍ�"
                oSheet.Range("E1").Value = "�Z���P"
                oSheet.Range("F1").Value = "�Z���Q"
                oSheet.Range("G1").Value = "�d�b�ԍ�"
                oSheet.Range("H1").Value = "��w��"
                oSheet.Range("I1").Value = "�w����"
                oSheet.Range("J1").Value = "�w�Ȗ�"
                oSheet.Range("K1").Value = "���[�J�["
                oSheet.Range("L1").Value = "���f����"
                oSheet.Range("M1").Value = "S/N"
                oSheet.Range("N1").Value = "�w�����z"
                oSheet.Range("O1").Value = "�ۏ؊���"
                oSheet.Range("P1").Value = "���[�J�[�ۏ؊J�n"
                oSheet.Range("Q1").Value = "�ۏ͈ؔ�"
                oSheet.Range("R1").Value = "�戵�X"
                oSheet.Range("S1").Value = "�����Ґ������z"
                oSheet.Range("T1").Value = "�̔���"
                oSheet.Range("U1").Value = "������"
                oSheet.Range("V1").Value = "�����؈��"
                oSheet.Range("W1").Value = "�����؈�����t"
                oSheet.Range("X1").Value = "�o�^���t"
                oSheet.Range("A1:X1").Interior.Color = RGB(0, 255, 255)

                DtView1 = New DataView(DsList1.Tables("XLS"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                    waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    Line = Line + 1
                    oSheet.Range("A" & Line).Value = DtView1(i)("code")             '�X�܉����ԍ��h
                    oSheet.Range("B" & Line).Value = DtView1(i)("user_name")        '����
                    oSheet.Range("C" & Line).Value = DtView1(i)("use_name_kana")    '�����J�i
                    oSheet.Range("D" & Line).Value = DtView1(i)("zip")              '�X�֔ԍ�
                    oSheet.Range("E" & Line).Value = DtView1(i)("adrs1")            '�Z���P
                    oSheet.Range("F" & Line).Value = DtView1(i)("adrs2")            '�Z���Q
                    'oSheet.Range("G" & Line).NumberFormatLocal = "@"
                    oSheet.Range("G" & Line).Value = DtView1(i)("tel")              '�d�b�ԍ�
                    oSheet.Range("H" & Line).Value = DtView1(i)("univ_name")        '��w��
                    oSheet.Range("I" & Line).Value = DtView1(i)("dpmt_name")        '�w����
                    oSheet.Range("J" & Line).Value = DtView1(i)("sbjt_name")        '�w�Ȗ�
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M05_VNDR"), "vndr_code = '" & DtView1(i)("makr_code") & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        oSheet.Range("K" & Line).Value = WK_DtView1(0)("name")      '���[�J�[
                    Else
                        oSheet.Range("K" & Line).Value = DtView1(i)("makr_name")    '���[�J�[
                    End If
                    oSheet.Range("L" & Line).Value = DtView1(i)("modl_name")        '���f����
                    oSheet.Range("M" & Line).Value = DtView1(i)("s_no")             'S/N
                    oSheet.Range("N" & Line).Value = DtView1(i)("prch_amnt")        '�w�����z
                    oSheet.Range("O" & Line).Value = DtView1(i)("wrn_tem_name")     '�ۏ؊���
                    oSheet.Range("P" & Line).Value = DtView1(i)("makr_wrn_stat")    '���[�J�[�ۏ؊J�n
                    oSheet.Range("Q" & Line).Value = DtView1(i)("wrn_range_name")   '�ۏ͈ؔ�
                    oSheet.Range("R" & Line).Value = DtView1(i)("shop_name")        '�戵�X
                    oSheet.Range("S" & Line).Value = DtView1(i)("wrn_fee")          '�����Ґ������z
                    oSheet.Range("T" & Line).Value = DtView1(i)("sale_pson")        '�̔���
                    oSheet.Range("U" & Line).Value = DtView1(i)("Part_date")        '������
                    oSheet.Range("V" & Line).Value = DtView1(i)("Part_prt")         '�����؈��
                    oSheet.Range("W" & Line).Value = DtView1(i)("Part_prt_date")    '�����؈�����t
                    oSheet.Range("X" & Line).Value = DtView1(i)("reg_date")         '�o�^���t
                Next

                oSheet.Range("N2:N" & Line).NumberFormatLocal = "#,##0_ "
                oSheet.Range("S2:S" & Line).NumberFormatLocal = "#,##0_ "
                oSheet.Range("A1:X" & Line).EntireColumn.AutoFit()   '�Z�����i�񕝁j�̎�������

                '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
                SaveFileDialog1.FileName = "QG_Care.xls"
                SaveFileDialog1.Filter = "Excel�t�@�C��|*.xls"
                SaveFileDialog1.OverwritePrompt = False
                If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
                Try
                    oBook.SaveAs(SaveFileDialog1.FileName)
                Catch ex As System.Exception
                    GoTo end_prc
                End Try
end_prc:
                ' �I�������@
                oSheet = Nothing
                oBook = Nothing
                oExcel.Quit()
                oExcel = Nothing
                GC.Collect()

                MessageBox.Show("�G�N�Z���o�͂��܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
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

