Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex
    Dim drItem As SqlClient.SqlDataReader
    Dim SqlCmd1 As New SqlClient.SqlCommand
    Dim DaList1 As New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2, DsExport As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2, WK_DtView3 As DataView

    Dim waitDlg As WaitDialog

    Dim strSQL, Err_F As String
    Dim filename, filename2 As String
    Dim strData(50), WK_strLine, WK_upd, WK_str As String
    Dim i, j, k, r, pos, len, WK_int(4) As Integer

    Dim div1, div2, div3, div4 As Decimal
    Dim mod1, mod2, mod3, mod4 As Decimal

    Dim BR_ordr_no As String
    Dim BR_wrn_fee As Integer

    Dim Line As Integer
    Dim BR_Shop, BR_Shop_name, BR_shop_cls As String
    Dim daburi As String
    Dim poc_date2 As String
    Dim kake As Integer

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Date2 As GrapeCity.Win.Input.Date
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button99 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label01 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button26 = New System.Windows.Forms.Button
        Me.Button25 = New System.Windows.Forms.Button
        Me.Button27 = New System.Windows.Forms.Button
        Me.Date2 = New GrapeCity.Win.Input.Date
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 23)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Safety5 Management Center"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Blue
        Me.Label3.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(288, 32)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "�I�[���d���p�v���O����"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button99.Location = New System.Drawing.Point(232, 344)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 4
        Me.Button99.Text = "�I ��"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.SystemColors.Control
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.Black
        Me.Button10.Location = New System.Drawing.Point(132, 36)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(160, 32)
        Me.Button10.TabIndex = 1
        Me.Button10.Text = "���ߏ���"
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(20, 52)
        Me.Date1.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 0, 0, 0, 0))
        Me.Date1.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(1990, 1, 1, 0, 0, 0, 0))
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(92, 24)
        Me.Date1.TabIndex = 0
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2008, 12, 18, 17, 22, 2, 0))
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 23)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "�����N��"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Date1)
        Me.GroupBox2.Controls.Add(Me.Button10)
        Me.GroupBox2.Controls.Add(Me.Label01)
        Me.GroupBox2.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 300)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(332, 32)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "���ߏ���"
        Me.GroupBox2.Visible = False
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label01.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label01.Location = New System.Drawing.Point(20, 76)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(92, 20)
        Me.Label01.TabIndex = 135
        Me.Label01.Text = "Label01"
        Me.Label01.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button26)
        Me.GroupBox3.Controls.Add(Me.Button25)
        Me.GroupBox3.Controls.Add(Me.Button27)
        Me.GroupBox3.Controls.Add(Me.Date2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label02)
        Me.GroupBox3.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 92)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(332, 204)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "�W�v"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(132, 156)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(160, 32)
        Me.Button4.TabIndex = 139
        Me.Button4.Text = "�����҃f�[�^�o��"
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.SystemColors.Control
        Me.Button26.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button26.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.ForeColor = System.Drawing.Color.Black
        Me.Button26.Location = New System.Drawing.Point(132, 76)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(160, 32)
        Me.Button26.TabIndex = 5
        Me.Button26.Text = "�������׏o��(CSV)"
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.SystemColors.Control
        Me.Button25.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button25.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.ForeColor = System.Drawing.Color.Black
        Me.Button25.Location = New System.Drawing.Point(132, 36)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(160, 32)
        Me.Button25.TabIndex = 4
        Me.Button25.Text = "�����\�o��(Excel)"
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.SystemColors.Control
        Me.Button27.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button27.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.ForeColor = System.Drawing.Color.Black
        Me.Button27.Location = New System.Drawing.Point(132, 116)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(160, 32)
        Me.Button27.TabIndex = 6
        Me.Button27.Text = "���������׏o��"
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date2.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM", "", "")
        Me.Date2.Location = New System.Drawing.Point(20, 52)
        Me.Date2.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 0, 0, 0, 0))
        Me.Date2.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(1990, 1, 1, 0, 0, 0, 0))
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(96, 24)
        Me.Date2.TabIndex = 0
        Me.Date2.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date2.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2007, 9, 18, 17, 22, 2, 0))
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.Location = New System.Drawing.Point(20, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 23)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "�����N��"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label02.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label02.Location = New System.Drawing.Point(20, 76)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(96, 20)
        Me.Label02.TabIndex = 133
        Me.Label02.Text = "Label02"
        Me.Label02.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label5.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 20)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "Label5"
        Me.Label5.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(366, 383)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�I�[���d��"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '**  �N����
    '**********************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_report_all8")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("���łɋN�����Ă��܂�", "���s����")
            Application.Exit()
        End If
        DB_INIT()
        init()
    End Sub

    Sub init()
        WK_DsList1.Clear()
        strSQL = "SELECT MAX(close_date) AS close_date_max, MAX(cxl_close_date) AS cxl_close_date_max FROM All8_Wrn_sub"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "close_date_max")
        DB_CLOSE()

        WK_DtView1 = New DataView(WK_DsList1.Tables("close_date_max"), "", "", DataViewRowState.CurrentRows)
        If Not IsDBNull(WK_DtView1(0)("close_date_max")) Then
            If WK_DtView1(0)("close_date_max") > WK_DtView1(0)("cxl_close_date_max") Then
                Date1.Text = Mid(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 2, CDate(Mid(WK_DtView1(0)("close_date_max"), 1, 7) & "/01"))), 1, 7)
                Date2.Text = Mid(WK_DtView1(0)("close_date_max"), 1, 7)
            Else
                Date1.Text = Mid(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 2, CDate(Mid(WK_DtView1(0)("cxl_close_date_max"), 1, 7) & "/01"))), 1, 7)
                Date2.Text = Mid(WK_DtView1(0)("cxl_close_date_max"), 1, 7)
            End If
            poc_date2 = Date1.Text
        Else
            Date1.Text = Mid(Now.Date, 1, 7)
            Date2.Text = Mid(Now.Date, 1, 7)
            poc_date2 = Now.Date
        End If
    End Sub

    '**********************************
    '**  ���ߏ���
    '**********************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        WK_DsList1.Clear()
        strSQL = "SELECT close_date"
        strSQL += " FROM All8_Wrn_sub"
        strSQL += " WHERE (close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
        DB_CLOSE()

        WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            MessageBox.Show("���ɒ��ߏ����ς݂ł��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else

            WK_DsList1.Clear()
            strSQL = "SELECT close_date"
            strSQL += " FROM All8_Wrn_sub"
            strSQL += " WHERE (close_date IS NULL) AND (All8_Wrn_sub.fin_date IS NOT NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(WK_DsList1, "All8_Wrn_sub")
            DB_CLOSE()

            WK_DtView1 = New DataView(WK_DsList1.Tables("All8_Wrn_sub"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                MessageBox.Show("�Ώۃf�[�^������܂���B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                strSQL = "UPDATE All8_Wrn_sub"
                strSQL += " SET close_date = '" & Label01.Text & "'"
                strSQL += ", close_cont_flg = cont_flg"
                strSQL += " WHERE (close_date IS NULL) AND (All8_Wrn_sub.fin_date IS NOT NULL)"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                Label02.Text = Label01.Text
                Label5.Text = DateAdd(DateInterval.Day, 1, CDate(Label02.Text))
                Date2.Text = Date1.Text
                poc_date2 = Format(DateAdd(DateInterval.Day, 1, CDate(Label01.Text)), "yyyy/MM")

                MessageBox.Show("�I��", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '**  �����\�o��(Excel)
    '**  10�N�ۏ�
    '**********************************
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim Dtl(10), sum(5, 10), sum2(2, 10) As Long '���v,�敪�v,ڷޭװ�X

        Dim sw As System.IO.StreamWriter  'StreamWriter�I�u�W�F�N�g
        Dim i As Integer                  '�J�E���^
        Dim sbuf As String                '�t�@�C���ɏo�͂���f�[�^

        Me.Enabled = False                      ' �I�[�i�[�̃t�H�[���𖳌��ɂ���

        waitDlg = New WaitDialog                ' �i�s�󋵃_�C�A���O
        waitDlg.Owner = Me                      ' �_�C�A���O�̃I�[�i�[��ݒ肷��
        waitDlg.MainMsg = "�����\"              ' �����̊T�v��\��
        waitDlg.ProgressMsg = "�f�[�^���o��"    ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
        waitDlg.ProgressMax = 0                 ' �S�̂̏���������ݒ�
        waitDlg.ProgressMin = 0                 ' ���������̍ŏ��l��ݒ�i0������J�n�j
        waitDlg.ProgressStep = 1                ' �������ƂɃ��[�^��i�߂邩��ݒ�
        waitDlg.ProgressValue = 0               ' �ŏ��̌�����ݒ�
        waitDlg.Show()                          ' �i�s�󋵃_�C�A���O��\������
        Application.DoEvents()                  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

        DsExport.Clear()

        strSQL = "SELECT Shop_mtr.[�X�ܖ�(��)] AS shop_name, Shop_mtr.���GRP AS comp_grp, All8_Wrn_mtr.*, All8_Wrn_sub.*, Shop_mtr.���ޖ� AS shop_cls, Shop_mtr.����CD, 'A' AS stts"
        strSQL += " FROM All8_Wrn_mtr INNER JOIN"
        strSQL += " All8_Wrn_sub ON All8_Wrn_mtr.ordr_no = All8_Wrn_sub.ordr_no INNER JOIN"
        strSQL += " Shop_mtr ON All8_Wrn_mtr.shop_code = Shop_mtr.shop_code AND All8_Wrn_mtr.BY_cls = Shop_mtr.BY_cls"
        If poc_date2 = Date2.Text Then    '���ߑO
            strSQL += " WHERE (All8_Wrn_sub.cont_flg = 'A')"
            strSQL += " AND (All8_Wrn_sub.wrn_fee_tax <> 0)"
            strSQL += " AND (All8_Wrn_sub.fin_date < CONVERT(DATETIME, '" & Label5.Text & "', 102))"
            strSQL += " AND (All8_Wrn_sub.close_date IS NULL)"
            'strSQL += " AND (All8_Wrn_sub.fin_date IS NOT NULL)"
            'strSQL += " AND (All8_Wrn_sub.wrn_prod = 120)"   '10�N�ۏ�
        Else
            strSQL += " WHERE (All8_Wrn_sub.close_cont_flg = 'A')"
            strSQL += " AND (All8_Wrn_sub.wrn_fee_tax <> 0)"
            strSQL += " AND (All8_Wrn_sub.close_date = CONVERT(DATETIME, '" & Label02.Text & "', 102))"
            'strSQL += " AND (All8_Wrn_sub.fin_date IS NOT NULL)"
            'strSQL += " AND (All8_Wrn_sub.wrn_prod = 120)"   '10�N�ۏ�
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        r = DaList1.Fill(DsExport, "XLS")
        DB_CLOSE()

        If poc_date2 = Date2.Text Then    '���ߑO
        Else
            '�L�����Z����
            strSQL = "SELECT Shop_mtr.[�X�ܖ�(��)] AS shop_name, Shop_mtr.���GRP AS comp_grp, All8_Wrn_mtr.ordr_no, All8_Wrn_mtr.cust_no,"
            strSQL += " All8_Wrn_mtr.cust_fname, All8_Wrn_mtr.cust_lname, All8_Wrn_mtr.city_name, All8_Wrn_mtr.pref_code, All8_Wrn_mtr.zip_code,"
            strSQL += " All8_Wrn_mtr.srch_phn, All8_Wrn_mtr.disp_phn, All8_Wrn_mtr.shop_code, All8_Wrn_mtr.target_ym, All8_Wrn_mtr.ordr_no_aka,"
            strSQL += " All8_Wrn_mtr.ordr_no_moto, All8_Wrn_mtr.op_date, All8_Wrn_mtr.snd_date, All8_Wrn_mtr.adrs1, All8_Wrn_mtr.adrs2,"
            strSQL += " All8_Wrn_mtr.BY_cls, All8_Wrn_sub.ordr_no AS Expr1, All8_Wrn_sub.line_no, All8_Wrn_sub.seq, All8_Wrn_sub.cont_flg,"
            strSQL += " All8_Wrn_sub.item_cat_code, All8_Wrn_sub.bend_code, All8_Wrn_sub.pos_code, All8_Wrn_sub.model_name,"
            strSQL += " All8_Wrn_sub.prch_unit, All8_Wrn_sub.prch_price * - 1 AS prch_price, All8_Wrn_sub.prch_price_tax * - 1 AS prch_price_tax,"
            strSQL += " All8_Wrn_sub.wrn_fee * - 1 AS wrn_fee, All8_Wrn_sub.wrn_fee_tax * - 1 AS wrn_fee_tax,"
            strSQL += " All8_Wrn_sub.wrn_fee_ORG * - 1 AS wrn_fee_ORG, All8_Wrn_sub.wrn_fee_tax_ORG * - 1 AS wrn_fee_tax_ORG, All8_Wrn_sub.prvd_cls,"
            strSQL += " All8_Wrn_sub.prch_date, All8_Wrn_sub.fin_date, All8_Wrn_sub.wrn_prod, All8_Wrn_sub.cxl_shop_code, All8_Wrn_sub.cxl_date,"
            strSQL += " All8_Wrn_sub.close_date, All8_Wrn_sub.cxl_close_date, All8_Wrn_sub.close_cont_flg, All8_Wrn_sub.txt_ID, All8_Wrn_sub.kbn_cd,"
            strSQL += " All8_Wrn_sub.rcv_flg, All8_Wrn_sub.item_cat_code1, All8_Wrn_sub.item_cat_code1_name, All8_Wrn_sub.item_cat_code2,"
            strSQL += " All8_Wrn_sub.item_cat_code2_name, All8_Wrn_sub.item_cat_code3, All8_Wrn_sub.item_cat_code3_name, All8_Wrn_sub.data_seq,"
            strSQL += " All8_Wrn_sub.wrn_item_code, All8_Wrn_sub.wrn_item_name, All8_Wrn_sub.BY_cls AS Expr2, Shop_mtr.���ޖ� AS shop_cls,"
            strSQL += " Shop_mtr.����CD, 'C' AS stts"
            strSQL += " FROM All8_Wrn_mtr INNER JOIN"
            strSQL += " All8_Wrn_sub ON All8_Wrn_mtr.ordr_no = All8_Wrn_sub.ordr_no INNER JOIN"
            strSQL += " Shop_mtr ON All8_Wrn_mtr.shop_code = Shop_mtr.shop_code AND All8_Wrn_mtr.BY_cls = Shop_mtr.BY_cls"
            strSQL += " WHERE (All8_Wrn_sub.cxl_close_date = CONVERT(DATETIME, '" & Label02.Text & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(DsExport, "XLS")
            DB_CLOSE()
        End If

        If r = 0 Then
            Me.Activate()
            waitDlg.Close()
            Me.Enabled = True
            MessageBox.Show("�Y������f�[�^������܂���", "�G�N�X�|�[�g", MessageBoxButtons.OK)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        Else

            waitDlg.MainMsg = "Excel�쐬���i�X�ܖ��j"   ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = r                     ' �S�̂̏���������ݒ�
            Application.DoEvents()                      ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object

            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add

            Line = 1
            oSheet = oBook.Worksheets(1)
            oSheet.Range("A1").Value = "�X�܃R�[�h"
            oSheet.Range("B1").Value = "�X�ܖ�"
            oSheet.Range("C1").Value = "�X�܋敪"
            oSheet.Range("D1").Value = "�̔��ۏؗ�(�Ŕ�)"
            oSheet.Range("E1").Value = "�����"
            oSheet.Range("F1").Value = "�̔��ۏؗ�(�ō�)"
            oSheet.Range("G1").Value = "�̔��萔��(�Ŕ�)"
            oSheet.Range("H1").Value = "�����"
            oSheet.Range("I1").Value = "�̔��萔��(�ō�)"
            oSheet.Range("J1").Value = "�x���z(�ō�)"
            oSheet.Range("K1").Value = "�����ϑ���(�ō�)"
            oSheet.Range("L1").Value = "�����z(�ō�)"
            oSheet.Range("M1").Value = "����"
            oSheet.Range("A1:M1").Interior.Color = RGB(0, 255, 255)

            DtView1 = New DataView(DsExport.Tables("XLS"), "", "shop_code", DataViewRowState.CurrentRows)
            BR_Shop = DtView1(0)("shop_code")
            BR_Shop_name = Trim(DtView1(0)("shop_name"))
            BR_shop_cls = Trim(DtView1(0)("shop_cls"))
            For i = 0 To DtView1.Count - 1

                If DtView1(i)("stts") = "A" Then
                    kake = 1
                Else
                    kake = -1
                End If

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                If DtView1(i)("shop_code") <> BR_Shop Then
                    Line = Line + 1
                    oSheet.Range("A" & Line).Value = Chr(39) & BR_Shop.ToString         '�X�܃R�[�h
                    oSheet.Range("B" & Line).Value = BR_Shop_name.ToString              '�X�ܖ�
                    oSheet.Range("C" & Line).Value = BR_shop_cls.ToString               '�X�܋敪
                    oSheet.Range("D" & Line).Value = Format(Dtl(1), "##0,00").ToString  '�̔��ۏؗ�(�Ŕ�)
                    oSheet.Range("E" & Line).Value = Format(Dtl(2), "##0,00").ToString  '�����
                    oSheet.Range("F" & Line).Value = Format(Dtl(3), "##0,00").ToString  '�̔��ۏؗ�(�ō�)
                    oSheet.Range("G" & Line).Value = Format(Dtl(4), "##0,00").ToString  '�̔��萔��(�Ŕ�)
                    oSheet.Range("H" & Line).Value = Format(Dtl(5), "##0,00").ToString  '�����
                    oSheet.Range("I" & Line).Value = Format(Dtl(6), "##0,00").ToString  '�̔��萔��(�ō�)
                    oSheet.Range("J" & Line).Value = Format(Dtl(7), "##0,00").ToString  '�x���z(�ō�)
                    oSheet.Range("K" & Line).Value = Format(Dtl(8), "##0,00").ToString  '�����ϑ���(�Ŕ�)
                    oSheet.Range("L" & Line).Value = Format(Dtl(9), "##0,00").ToString  '�����z(�Ŕ�)
                    oSheet.Range("M" & Line).Value = Format(Dtl(10), "##0,00").ToString '����
                    oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"

                    For j = 1 To 10
                        Dtl(j) = 0    '�X�܌v�N���A
                    Next
                    BR_Shop = DtView1(i)("shop_code")
                    BR_Shop_name = Trim(DtView1(i)("shop_name"))
                    BR_shop_cls = Trim(DtView1(i)("shop_cls"))
                End If

                Dtl(1) = Dtl(1) + DtView1(i)("wrn_fee")
                Dtl(2) = Dtl(2) + (DtView1(i)("wrn_fee_tax") - DtView1(i)("wrn_fee"))
                Dtl(3) = Dtl(3) + DtView1(i)("wrn_fee_tax")
                Select Case DtView1(i)("kbn_cd")
                    Case Is = "0311"
                        Dtl(4) = Dtl(4) + 2610 * kake
                        Dtl(5) = Dtl(5) + 208 * kake
                        Dtl(6) = Dtl(6) + 2818 * kake
                        Dtl(7) = Dtl(7) + 6361 * kake
                        Dtl(8) = Dtl(8) + 1286 * kake
                        Dtl(9) = Dtl(9) + 5075 * kake
                    Case Is = "0321"
                        Dtl(4) = Dtl(4) + 3070 * kake
                        Dtl(5) = Dtl(5) + 245 * kake
                        Dtl(6) = Dtl(6) + 3315 * kake
                        Dtl(7) = Dtl(7) + 7484 * kake
                        Dtl(8) = Dtl(8) + 1928 * kake
                        Dtl(9) = Dtl(9) + 5556 * kake
                    Case Is = "0331"
                        Dtl(4) = Dtl(4) + 7982 * kake
                        Dtl(5) = Dtl(5) + 638 * kake
                        Dtl(6) = Dtl(6) + 8620 * kake
                        Dtl(7) = Dtl(7) + 19459 * kake
                        Dtl(8) = Dtl(8) + 1928 * kake
                        Dtl(9) = Dtl(9) + 17531 * kake
                    Case Is = "0318"
                        Dtl(4) = Dtl(4) + 1996 * kake
                        Dtl(5) = Dtl(5) + 159 * kake
                        Dtl(6) = Dtl(6) + 2155 * kake
                        Dtl(7) = Dtl(7) + 4864 * kake
                        Dtl(8) = Dtl(8) + 1286 * kake
                        Dtl(9) = Dtl(9) + 3578 * kake
                    Case Is = "0338"
                        Dtl(4) = Dtl(4) + 4298 * kake
                        Dtl(5) = Dtl(5) + 343 * kake
                        Dtl(6) = Dtl(6) + 4641 * kake
                        Dtl(7) = Dtl(7) + 10478 * kake
                        Dtl(8) = Dtl(8) + 1928 * kake
                        Dtl(9) = Dtl(9) + 8550 * kake
                End Select
                Dtl(10) = Dtl(10) + 1

                Select Case DtView1(i)("kbn_cd")
                    Case Is = "0311"
                        sum(1, 1) = sum(1, 1) + DtView1(i)("wrn_fee")
                        sum(1, 2) = sum(1, 2) + (DtView1(i)("wrn_fee_tax") - DtView1(i)("wrn_fee"))
                        sum(1, 3) = sum(1, 3) + DtView1(i)("wrn_fee_tax")
                        sum(1, 4) = sum(1, 4) + 2610 * kake
                        sum(1, 5) = sum(1, 5) + 208 * kake
                        sum(1, 6) = sum(1, 6) + 2818 * kake
                        sum(1, 7) = sum(1, 7) + 6361 * kake
                        sum(1, 8) = sum(1, 8) + 1286 * kake
                        sum(1, 9) = sum(1, 9) + 5075 * kake
                        sum(1, 10) = sum(1, 10) + 1
                    Case Is = "0321"
                        sum(2, 1) = sum(2, 1) + DtView1(i)("wrn_fee")
                        sum(2, 2) = sum(2, 2) + (DtView1(i)("wrn_fee_tax") - DtView1(i)("wrn_fee"))
                        sum(2, 3) = sum(2, 3) + DtView1(i)("wrn_fee_tax")
                        sum(2, 4) = sum(2, 4) + 3070 * kake
                        sum(2, 5) = sum(2, 5) + 245 * kake
                        sum(2, 6) = sum(2, 6) + 3315 * kake
                        sum(2, 7) = sum(2, 7) + 7484 * kake
                        sum(2, 8) = sum(2, 8) + 1928 * kake
                        sum(2, 9) = sum(2, 9) + 5556 * kake
                        sum(2, 10) = sum(2, 10) + 1
                    Case Is = "0331"
                        sum(3, 1) = sum(3, 1) + DtView1(i)("wrn_fee")
                        sum(3, 2) = sum(3, 2) + (DtView1(i)("wrn_fee_tax") - DtView1(i)("wrn_fee"))
                        sum(3, 3) = sum(3, 3) + DtView1(i)("wrn_fee_tax")
                        sum(3, 4) = sum(3, 4) + 7982 * kake
                        sum(3, 5) = sum(3, 5) + 638 * kake
                        sum(3, 6) = sum(3, 6) + 8620 * kake
                        sum(3, 7) = sum(3, 7) + 19459 * kake
                        sum(3, 8) = sum(3, 8) + 1928 * kake
                        sum(3, 9) = sum(3, 9) + 17531 * kake
                        sum(3, 10) = sum(3, 10) + 1
                    Case Is = "0318"
                        sum(4, 1) = sum(4, 1) + DtView1(i)("wrn_fee")
                        sum(4, 2) = sum(4, 2) + (DtView1(i)("wrn_fee_tax") - DtView1(i)("wrn_fee"))
                        sum(4, 3) = sum(4, 3) + DtView1(i)("wrn_fee_tax")
                        sum(4, 4) = sum(4, 4) + 1996 * kake
                        sum(4, 5) = sum(4, 5) + 159 * kake
                        sum(4, 6) = sum(4, 6) + 2155 * kake
                        sum(4, 7) = sum(4, 7) + 4864 * kake
                        sum(4, 8) = sum(4, 8) + 1286 * kake
                        sum(4, 9) = sum(4, 9) + 3578 * kake
                        sum(4, 10) = sum(4, 10) + 1
                    Case Is = "0338"
                        sum(5, 1) = sum(5, 1) + DtView1(i)("wrn_fee")
                        sum(5, 2) = sum(5, 2) + (DtView1(i)("wrn_fee_tax") - DtView1(i)("wrn_fee"))
                        sum(5, 3) = sum(5, 3) + DtView1(i)("wrn_fee_tax")
                        sum(5, 4) = sum(5, 4) + 4298 * kake
                        sum(5, 5) = sum(5, 5) + 343 * kake
                        sum(5, 6) = sum(5, 6) + 4641 * kake
                        sum(5, 7) = sum(5, 7) + 10478 * kake
                        sum(5, 8) = sum(5, 8) + 1928 * kake
                        sum(5, 9) = sum(5, 9) + 8550 * kake
                        sum(5, 10) = sum(5, 10) + 1
                End Select

                If DtView1(i)("����CD") = "1" Then
                    k = 1
                Else
                    k = 2
                End If
                sum2(k, 1) = sum2(k, 1) + DtView1(i)("wrn_fee")
                sum2(k, 2) = sum2(k, 2) + (DtView1(i)("wrn_fee_tax") - DtView1(i)("wrn_fee"))
                sum2(k, 3) = sum2(k, 3) + DtView1(i)("wrn_fee_tax")
                Select Case DtView1(i)("kbn_cd")
                    Case Is = "0311"
                        sum2(k, 4) = sum2(k, 4) + 2610 * kake
                        sum2(k, 5) = sum2(k, 5) + 208 * kake
                        sum2(k, 6) = sum2(k, 6) + 2818 * kake
                        sum2(k, 7) = sum2(k, 7) + 6361 * kake
                        sum2(k, 8) = sum2(k, 8) + 1286 * kake
                        sum2(k, 9) = sum2(k, 9) + 5075 * kake
                    Case Is = "0321"
                        sum2(k, 4) = sum2(k, 4) + 3070 * kake
                        sum2(k, 5) = sum2(k, 5) + 245 * kake
                        sum2(k, 6) = sum2(k, 6) + 3315 * kake
                        sum2(k, 7) = sum2(k, 7) + 7484 * kake
                        sum2(k, 8) = sum2(k, 8) + 1928 * kake
                        sum2(k, 9) = sum2(k, 9) + 5556 * kake
                    Case Is = "0331"
                        sum2(k, 4) = sum2(k, 4) + 7982 * kake
                        sum2(k, 5) = sum2(k, 5) + 638 * kake
                        sum2(k, 6) = sum2(k, 6) + 8620 * kake
                        sum2(k, 7) = sum2(k, 7) + 19459 * kake
                        sum2(k, 8) = sum2(k, 8) + 1928 * kake
                        sum2(k, 9) = sum2(k, 9) + 17531 * kake
                    Case Is = "0318"
                        sum2(k, 4) = sum2(k, 4) + 1996 * kake
                        sum2(k, 5) = sum2(k, 5) + 159 * kake
                        sum2(k, 6) = sum2(k, 6) + 2155 * kake
                        sum2(k, 7) = sum2(k, 7) + 4864 * kake
                        sum2(k, 8) = sum2(k, 8) + 1286 * kake
                        sum2(k, 9) = sum2(k, 9) + 3578 * kake
                    Case Is = "0338"
                        sum2(k, 4) = sum2(k, 4) + 4298 * kake
                        sum2(k, 5) = sum2(k, 5) + 343 * kake
                        sum2(k, 6) = sum2(k, 6) + 4641 * kake
                        sum2(k, 7) = sum2(k, 7) + 10478 * kake
                        sum2(k, 8) = sum2(k, 8) + 1928 * kake
                        sum2(k, 9) = sum2(k, 9) + 8550 * kake
                End Select
                sum2(k, 10) = sum2(k, 10) + 1

            Next

            Line = Line + 1
            oSheet.Range("A" & Line).Value = Chr(39) & BR_Shop.ToString         '�X�܃R�[�h
            oSheet.Range("B" & Line).Value = BR_Shop_name.ToString              '�X�ܖ�
            oSheet.Range("C" & Line).Value = BR_shop_cls.ToString               '�X�܋敪
            oSheet.Range("D" & Line).Value = Format(Dtl(1), "##0,00").ToString  '�̔��ۏؗ�(�Ŕ�)
            oSheet.Range("E" & Line).Value = Format(Dtl(2), "##0,00").ToString  '�����
            oSheet.Range("F" & Line).Value = Format(Dtl(3), "##0,00").ToString  '�̔��ۏؗ�(�ō�)
            oSheet.Range("G" & Line).Value = Format(Dtl(4), "##0,00").ToString  '�̔��萔��(�Ŕ�)
            oSheet.Range("H" & Line).Value = Format(Dtl(5), "##0,00").ToString  '�����
            oSheet.Range("I" & Line).Value = Format(Dtl(6), "##0,00").ToString  '�̔��萔��(�ō�)
            oSheet.Range("J" & Line).Value = Format(Dtl(7), "##0,00").ToString  '�x���z(�ō�)
            oSheet.Range("K" & Line).Value = Format(Dtl(8), "##0,00").ToString  '�����ϑ���(�Ŕ�)
            oSheet.Range("L" & Line).Value = Format(Dtl(9), "##0,00").ToString  '�����z(�Ŕ�)
            oSheet.Range("M" & Line).Value = Format(Dtl(10), "##0,00").ToString '����
            oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"

            '�����v�o��
            Line = Line + 1
            oSheet.Range("D" & Line).Value = "=SUM(D2:D" & Line - 1 & ")"   '�̔��ۏؗ�(�Ŕ�)
            oSheet.Range("E" & Line).Value = "=SUM(E2:E" & Line - 1 & ")"   '�����
            oSheet.Range("F" & Line).Value = "=SUM(F2:F" & Line - 1 & ")"   '�̔��ۏؗ�(�ō�)
            oSheet.Range("G" & Line).Value = "=SUM(G2:G" & Line - 1 & ")"   '�̔��萔��(�Ŕ�)
            oSheet.Range("H" & Line).Value = "=SUM(H2:H" & Line - 1 & ")"   '�����
            oSheet.Range("I" & Line).Value = "=SUM(I2:I" & Line - 1 & ")"   '�̔��萔��(�ō�)
            oSheet.Range("J" & Line).Value = "=SUM(J2:J" & Line - 1 & ")"   '�x���z(�ō�)
            oSheet.Range("K" & Line).Value = "=SUM(K2:K" & Line - 1 & ")"   '�����ϑ���(�Ŕ�)
            oSheet.Range("L" & Line).Value = "=SUM(L2:L" & Line - 1 & ")"   '�����z(�Ŕ�)
            oSheet.Range("M" & Line).Value = "=SUM(M2:M" & Line - 1 & ")"   '����
            oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"

            '�敪�v(����@��O)
            Line = Line + 1
            For i = 1 To 3
                Line = Line + 1
                Select Case i
                    Case Is = 1
                        WK_str = "�h�g�N�b�L���O�q�[�^�["
                        oSheet.Range("B" & Line).Value = "������@��O��"
                    Case Is = 2
                        WK_str = "�d�C������"
                    Case Is = 3
                        WK_str = "�G�R�L���[�g"
                End Select
                oSheet.Range("C" & Line).Value = WK_str.ToString
                oSheet.Range("D" & Line).Value = Format(sum(i, 1), "##0,00").ToString   '�̔��ۏؗ�(�Ŕ�)
                oSheet.Range("E" & Line).Value = Format(sum(i, 2), "##0,00").ToString   '�����
                oSheet.Range("F" & Line).Value = Format(sum(i, 3), "##0,00").ToString   '�̔��ۏؗ�(�ō�)
                oSheet.Range("G" & Line).Value = Format(sum(i, 4), "##0,00").ToString   '�̔��萔��(�Ŕ�)
                oSheet.Range("H" & Line).Value = Format(sum(i, 5), "##0,00").ToString   '�����
                oSheet.Range("I" & Line).Value = Format(sum(i, 6), "##0,00").ToString   '�̔��萔��(�ō�)
                oSheet.Range("J" & Line).Value = Format(sum(i, 7), "##0,00").ToString   '�x���z(�ō�)
                oSheet.Range("K" & Line).Value = Format(sum(i, 8), "##0,00").ToString   '�����ϑ���(�Ŕ�)
                oSheet.Range("L" & Line).Value = Format(sum(i, 9), "##0,00").ToString   '�����z(�Ŕ�)
                oSheet.Range("M" & Line).Value = Format(sum(i, 10), "##0,00").ToString  '����
                oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"
            Next

            '�����v�o��
            Line = Line + 1
            WK_str = "�v"
            oSheet.Range("C" & Line).Value = WK_str.ToString
            oSheet.Range("D" & Line).Value = "=SUM(D" & Line - 3 & ":D" & Line - 1 & ")"    '�̔��ۏؗ�(�Ŕ�)
            oSheet.Range("E" & Line).Value = "=SUM(E" & Line - 3 & ":E" & Line - 1 & ")"    '�����
            oSheet.Range("F" & Line).Value = "=SUM(F" & Line - 3 & ":F" & Line - 1 & ")"    '�̔��ۏؗ�(�ō�)
            oSheet.Range("G" & Line).Value = "=SUM(G" & Line - 3 & ":G" & Line - 1 & ")"    '�̔��萔��(�Ŕ�)
            oSheet.Range("H" & Line).Value = "=SUM(H" & Line - 3 & ":H" & Line - 1 & ")"    '�����
            oSheet.Range("I" & Line).Value = "=SUM(I" & Line - 3 & ":I" & Line - 1 & ")"    '�̔��萔��(�ō�)
            oSheet.Range("J" & Line).Value = "=SUM(J" & Line - 3 & ":J" & Line - 1 & ")"    '�x���z(�ō�)
            oSheet.Range("K" & Line).Value = "=SUM(K" & Line - 3 & ":K" & Line - 1 & ")"    '�����ϑ���(�Ŕ�)
            oSheet.Range("L" & Line).Value = "=SUM(L" & Line - 3 & ":L" & Line - 1 & ")"    '�����z(�Ŕ�)
            oSheet.Range("M" & Line).Value = "=SUM(M" & Line - 3 & ":M" & Line - 1 & ")"    '����
            oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"

            '�敪�v(����@��)
            Line = Line + 1
            For i = 4 To 5
                Line = Line + 1
                Select Case i
                    Case Is = 4
                        WK_str = "�h�g�N�b�L���O�q�[�^�["
                        oSheet.Range("B" & Line).Value = "������@�큄"
                    Case Is = 5
                        WK_str = "�G�R�L���[�g"
                End Select
                oSheet.Range("C" & Line).Value = WK_str.ToString
                oSheet.Range("D" & Line).Value = Format(sum(i, 1), "##0,00").ToString   '�̔��ۏؗ�(�Ŕ�)
                oSheet.Range("E" & Line).Value = Format(sum(i, 2), "##0,00").ToString   '�����
                oSheet.Range("F" & Line).Value = Format(sum(i, 3), "##0,00").ToString   '�̔��ۏؗ�(�ō�)
                oSheet.Range("G" & Line).Value = Format(sum(i, 4), "##0,00").ToString   '�̔��萔��(�Ŕ�)
                oSheet.Range("H" & Line).Value = Format(sum(i, 5), "##0,00").ToString   '�����
                oSheet.Range("I" & Line).Value = Format(sum(i, 6), "##0,00").ToString   '�̔��萔��(�ō�)
                oSheet.Range("J" & Line).Value = Format(sum(i, 7), "##0,00").ToString   '�x���z(�ō�)
                oSheet.Range("K" & Line).Value = Format(sum(i, 8), "##0,00").ToString   '�����ϑ���(�Ŕ�)
                oSheet.Range("L" & Line).Value = Format(sum(i, 9), "##0,00").ToString   '�����z(�Ŕ�)
                oSheet.Range("M" & Line).Value = Format(sum(i, 10), "##0,00").ToString  '����
                oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"
            Next

            '�����v�o��
            Line = Line + 1
            WK_str = "�v"
            oSheet.Range("C" & Line).Value = WK_str.ToString
            oSheet.Range("D" & Line).Value = "=SUM(D" & Line - 2 & ":D" & Line - 1 & ")"    '�̔��ۏؗ�(�Ŕ�)
            oSheet.Range("E" & Line).Value = "=SUM(E" & Line - 2 & ":E" & Line - 1 & ")"    '�����
            oSheet.Range("F" & Line).Value = "=SUM(F" & Line - 2 & ":F" & Line - 1 & ")"    '�̔��ۏؗ�(�ō�)
            oSheet.Range("G" & Line).Value = "=SUM(G" & Line - 2 & ":G" & Line - 1 & ")"    '�̔��萔��(�Ŕ�)
            oSheet.Range("H" & Line).Value = "=SUM(H" & Line - 2 & ":H" & Line - 1 & ")"    '�����
            oSheet.Range("I" & Line).Value = "=SUM(I" & Line - 2 & ":I" & Line - 1 & ")"    '�̔��萔��(�ō�)
            oSheet.Range("J" & Line).Value = "=SUM(J" & Line - 2 & ":J" & Line - 1 & ")"    '�x���z(�ō�)
            oSheet.Range("K" & Line).Value = "=SUM(K" & Line - 2 & ":K" & Line - 1 & ")"    '�����ϑ���(�Ŕ�)
            oSheet.Range("L" & Line).Value = "=SUM(L" & Line - 2 & ":L" & Line - 1 & ")"    '�����z(�Ŕ�)
            oSheet.Range("M" & Line).Value = "=SUM(M" & Line - 2 & ":M" & Line - 1 & ")"    '����
            oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"

            'ڷޭ�דX�v
            Line = Line + 1
            For i = 1 To 2
                Line = Line + 1
                Select Case i
                    Case Is = 1
                        WK_str = "ڷޭװ�X"
                    Case Is = 2
                        WK_str = "ڷޭװ�X�ȊO"
                End Select
                oSheet.Range("C" & Line).Value = WK_str.ToString
                oSheet.Range("D" & Line).Value = Format(sum2(i, 1), "##0,00").ToString  '�̔��ۏؗ�(�Ŕ�)
                oSheet.Range("E" & Line).Value = Format(sum2(i, 2), "##0,00").ToString  '�����
                oSheet.Range("F" & Line).Value = Format(sum2(i, 3), "##0,00").ToString  '�̔��ۏؗ�(�ō�)
                oSheet.Range("G" & Line).Value = Format(sum2(i, 4), "##0,00").ToString  '�̔��萔��(�Ŕ�)
                oSheet.Range("H" & Line).Value = Format(sum2(i, 5), "##0,00").ToString  '�����
                oSheet.Range("I" & Line).Value = Format(sum2(i, 6), "##0,00").ToString  '�̔��萔��(�ō�)
                oSheet.Range("J" & Line).Value = Format(sum2(i, 7), "##0,00").ToString  '�x���z(�ō�)
                oSheet.Range("K" & Line).Value = Format(sum2(i, 8), "##0,00").ToString  '�����ϑ���(�Ŕ�)
                oSheet.Range("L" & Line).Value = Format(sum2(i, 9), "##0,00").ToString  '�����z(�Ŕ�)
                oSheet.Range("M" & Line).Value = Format(sum2(i, 10), "##0,00").ToString '����
                oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"
            Next

            '�����v�o��
            Line = Line + 1
            WK_str = "�v"
            oSheet.Range("C" & Line).Value = WK_str.ToString
            oSheet.Range("D" & Line).Value = "=SUM(D" & Line - 2 & ":D" & Line - 1 & ")"    '�̔��ۏؗ�(�Ŕ�)
            oSheet.Range("E" & Line).Value = "=SUM(E" & Line - 2 & ":E" & Line - 1 & ")"    '�����
            oSheet.Range("F" & Line).Value = "=SUM(F" & Line - 2 & ":F" & Line - 1 & ")"    '�̔��ۏؗ�(�ō�)
            oSheet.Range("G" & Line).Value = "=SUM(G" & Line - 2 & ":G" & Line - 1 & ")"    '�̔��萔��(�Ŕ�)
            oSheet.Range("H" & Line).Value = "=SUM(H" & Line - 2 & ":H" & Line - 1 & ")"    '�����
            oSheet.Range("I" & Line).Value = "=SUM(I" & Line - 2 & ":I" & Line - 1 & ")"    '�̔��萔��(�ō�)
            oSheet.Range("J" & Line).Value = "=SUM(J" & Line - 2 & ":J" & Line - 1 & ")"    '�x���z(�ō�)
            oSheet.Range("K" & Line).Value = "=SUM(K" & Line - 2 & ":K" & Line - 1 & ")"    '�����ϑ���(�Ŕ�)
            oSheet.Range("L" & Line).Value = "=SUM(L" & Line - 2 & ":L" & Line - 1 & ")"    '�����z(�Ŕ�)
            oSheet.Range("M" & Line).Value = "=SUM(M" & Line - 2 & ":M" & Line - 1 & ")"    '����
            oSheet.Range("D" & Line & ":M" & Line).Font.Name = "Arial"

            Me.Activate()
            waitDlg.Close()

            oSheet.Range("A1:M" & Line).EntireColumn.AutoFit()   '�Z�����i�񕝁j�̎�������

            '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
            SaveFileDialog1.FileName = "�I�[���d�������\" & Format(CDate(Label02.Text), "yyyyMM") & ".xls"
            SaveFileDialog1.Filter = "Excel�t�@�C��|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
            Try
                oBook.SaveAs(SaveFileDialog1.FileName)
            Catch ex As System.Exception
                GoTo end_prc2
            End Try
end_prc:

            ' �I�������@
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
            GC.Collect()

        End If
end_prc2:
        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '**  �������׏o��(CSV)
    '**  10�N�ۏ�
    '**********************************
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sw As System.IO.StreamWriter  'StreamWriter�I�u�W�F�N�g
        Dim i As Integer                  '�J�E���^
        Dim sbuf As String                '�t�@�C���ɏo�͂���f�[�^

        DsExport.Clear()
        strSQL = "SELECT All8_Wrn_mtr.*, All8_Wrn_sub.*, Shop_mtr.[�X�ܖ�(��)] AS shop_name"
        strSQL += " FROM All8_Wrn_mtr INNER JOIN"
        strSQL += " All8_Wrn_sub ON All8_Wrn_mtr.ordr_no = All8_Wrn_sub.ordr_no INNER JOIN"
        strSQL += " Shop_mtr ON All8_Wrn_mtr.shop_code = Shop_mtr.shop_code AND All8_Wrn_mtr.BY_cls = Shop_mtr.BY_cls"
        If poc_date2 = Date2.Text Then    '���ߑO
            strSQL += " WHERE (All8_Wrn_sub.cont_flg = 'A')"
            strSQL += " AND (All8_Wrn_sub.close_date IS NULL)"
            strSQL += " AND (All8_Wrn_sub.fin_date < CONVERT(DATETIME, '" & Label5.Text & "', 102))"
            strSQL += " AND (All8_Wrn_sub.wrn_prod = 120)"   '10�N�ۏ�
        Else
            strSQL += " WHERE (All8_Wrn_sub.close_cont_flg = 'A')"
            strSQL += " AND (All8_Wrn_sub.close_date = CONVERT(DATETIME, '" & Label02.Text & "', 102))"
            'strSQL += " AND (All8_Wrn_sub.fin_date IS NOT NULL)"
            'strSQL += " AND (All8_Wrn_sub.wrn_prod = 120)"   '10�N�ۏ�
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DB_OPEN()
        r = DaList1.Fill(DsExport, "CSV")
        DB_CLOSE()

        If r = 0 Then
            MessageBox.Show("�Y������f�[�^������܂���", "�G�N�X�|�[�g", MessageBoxButtons.OK)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '�t�@�C���ɏo��
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsExport.Tables("CSV"), "", "ordr_no,line_no", DataViewRowState.CurrentRows)

            waitDlg = New WaitDialog
            waitDlg.Owner = Me
            waitDlg.ProgressMax = DtView1.Count - 1
            waitDlg.ProgressMin = 0
            waitDlg.ProgressStep = 1
            waitDlg.ProgressValue = 0
            Me.Enabled = False
            waitDlg.Show()
            waitDlg.MainMsg = "CSV�f�[�^���o�͂��Ă��܂��B"

            'sbuf = "�X�܃R�[�h,�X�ܖ�,�ۏؔԍ�,�s�ԍ�,�w�����i,�ۏؗ�,�ی���,�����萔��,�\����,�X�e�[�^�X,������,�敪,�i��"
            'sw.WriteLine(sbuf)

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressValue = i
                Application.DoEvents()

                sbuf = DtView1(i)("shop_code")                                                  '�X�܃R�[�h
                sbuf = sbuf & "," & Chr(34) & DtView1(i)("shop_name") & Chr(34)                 '�X�ܖ�
                sbuf = sbuf & "," & Chr(34) & DtView1(i)("ordr_no") & Chr(34)                   '�ۏؔԍ�
                sbuf = sbuf & "," & Chr(34) & DtView1(i)("line_no") & Chr(34)                   '�s�ԍ�
                sbuf = sbuf & "," & DtView1(i)("prch_price")                                    '�w�����i(�l:�ŕʁA�@�l:�ō�)
                sbuf = sbuf & "," & DtView1(i)("wrn_fee")                                       '�ۏؗ��i�Ŕ��j

                If DtView1(i)("wrn_fee") <> 0 Then
                    '�ی���
                    Select Case DtView1(i)("kbn_cd")
                        Case Is = "0311"
                            sbuf = sbuf & ", 7143"
                        Case Is = "0321"
                            sbuf = sbuf & ", 9524"
                        Case Is = "0331"
                            sbuf = sbuf & ", 22858"
                        Case Else
                            sbuf = sbuf & ", 0"
                    End Select

                    '�����萔���i�Ŕ��j
                    Select Case DtView1(i)("kbn_cd")
                        Case Is = "0311"
                            sbuf = sbuf & ", 1191"
                        Case Is = "0321"
                            sbuf = sbuf & ", 1786"
                        Case Is = "0331"
                            sbuf = sbuf & ", 1786"
                        Case Else
                            sbuf = sbuf & ", 0"
                    End Select
                Else
                    sbuf = sbuf & ", 0, 0"
                End If

                sbuf = sbuf & "," & DtView1(i)("prch_date")                                     '�\����
                sbuf = sbuf & "," & Chr(34) & DtView1(i)("close_cont_flg") & Chr(34)            '�X�e�[�^�X
                sbuf = sbuf & ", " & DtView1(i)("close_date")                                   '������
                sbuf = sbuf & "," & Chr(34) & "" & DtView1(i)("kbn_cd") & "" & Chr(34)          '�敪
                sbuf = sbuf & "," & Chr(34) & Mid(DtView1(i)("item_cat_code"), 1, 4) & Chr(34)  '�i��

                sw.WriteLine(sbuf)
            Next
        End If
        sw.Close()

        Me.Activate()
        waitDlg.Close()

        '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
        SaveFileDialog1.FileName = "�I�[���d����������" & Format(CDate(Label02.Text), "yyyyMM") & ".csv"
        SaveFileDialog1.Filter = "CSV�t�@�C��|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("�A�v���P�[�V�����G���[", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '**  ���������׏o��
    '**  10�N�ۏ�
    '**********************************
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sw As System.IO.StreamWriter  'StreamWriter�I�u�W�F�N�g
        Dim i As Integer                  '�J�E���^
        Dim sbuf As String                '�t�@�C���ɏo�͂���f�[�^

        DsExport.Clear()
        strSQL = "SELECT All8_Wrn_mtr.*, All8_Wrn_sub.*, Shop_mtr.[�X�ܖ�(����)] AS shop_name, vdr_mtr.vdr_name"
        strSQL += " FROM All8_Wrn_sub INNER JOIN"
        strSQL += " All8_Wrn_mtr ON All8_Wrn_sub.ordr_no = All8_Wrn_mtr.ordr_no INNER JOIN"
        strSQL += " vdr_mtr ON All8_Wrn_sub.BY_cls = vdr_mtr.BY_cls AND All8_Wrn_sub.bend_code = vdr_mtr.vdr_code INNER JOIN"
        strSQL += " Shop_mtr ON All8_Wrn_mtr.BY_cls = Shop_mtr.BY_cls AND All8_Wrn_mtr.shop_code = Shop_mtr.shop_code"
        strSQL += " WHERE (All8_Wrn_sub.fin_date IS NULL)"
        strSQL += " AND (All8_Wrn_sub.wrn_prod = 120)"   '10�N�ۏ�
        strSQL += " AND (All8_Wrn_sub.cont_flg = 'A')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DB_OPEN()
        r = DaList1.Fill(DsExport, "CSV")
        DB_CLOSE()

        If r = 0 Then
            MessageBox.Show("�Y������f�[�^������܂���", "�G�N�X�|�[�g", MessageBoxButtons.OK)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '�t�@�C���ɏo��
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsExport.Tables("CSV"), "", "", DataViewRowState.CurrentRows)

            waitDlg = New WaitDialog
            waitDlg.Owner = Me
            waitDlg.ProgressMax = DtView1.Count - 1
            waitDlg.ProgressMin = 0
            waitDlg.ProgressStep = 1
            waitDlg.ProgressValue = 0
            Me.Enabled = False
            waitDlg.Show()
            waitDlg.MainMsg = "TXT�f�[�^���o�͂��Ă��܂��B"

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressValue = i
                Application.DoEvents()

                sbuf = DtView1(i)("ordr_no")
                sbuf += "," & DtView1(i)("prch_date")
                sbuf += "," & DtView1(i)("fin_date")
                sbuf += "," & DtView1(i)("cxl_date")
                sbuf += "," & DtView1(i)("ordr_no_moto")
                sbuf += "," & DtView1(i)("ordr_no_aka")
                sbuf += "," & DtView1(i)("cust_no")
                sbuf += "," & DtView1(i)("cust_lname")
                sbuf += "," & DtView1(i)("zip_code")
                sbuf += "," & DtView1(i)("adrs1")
                sbuf += "," & DtView1(i)("adrs2")
                sbuf += "," & DtView1(i)("srch_phn")
                sbuf += "," & DtView1(i)("line_no")
                sbuf += "," & DtView1(i)("item_cat_code1")
                sbuf += "," & DtView1(i)("item_cat_code1_name")
                sbuf += "," & DtView1(i)("item_cat_code2")
                sbuf += "," & DtView1(i)("item_cat_code2_name")
                sbuf += "," & DtView1(i)("item_cat_code3")
                sbuf += "," & DtView1(i)("item_cat_code3_name")
                sbuf += "," & DtView1(i)("bend_code")
                sbuf += "," & DtView1(i)("vdr_name")
                sbuf += "," & DtView1(i)("pos_code")
                sbuf += "," & DtView1(i)("model_name")
                sbuf += "," & DtView1(i)("prch_price")
                sbuf += "," & DtView1(i)("prch_price_tax")
                sbuf += "," & DtView1(i)("prch_unit")
                sbuf += "," & DtView1(i)("shop_code")
                sbuf += "," & DtView1(i)("shop_name")
                sbuf += "," & DtView1(i)("op_date")
                sbuf += "," & DtView1(i)("close_cont_flg")
                sbuf += "," & DtView1(i)("wrn_item_code")
                sbuf += "," & DtView1(i)("wrn_item_name")
                sbuf += "," & DtView1(i)("wrn_fee")
                sbuf += "," & DtView1(i)("wrn_prod")
                sbuf += "," & DtView1(i)("kbn_cd")
                sw.WriteLine(sbuf)
            Next
        End If
        sw.Close()

        Me.Activate()
        waitDlg.Close()

        '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
        SaveFileDialog1.FileName = "�I�[���d������������" & Format(CDate(Label02.Text), "yyyyMM") & ".csv"
        SaveFileDialog1.Filter = "txt�t�@�C��|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("�A�v���P�[�V�����G���[", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '**  �����f�[�^�o��
    '**  10�N�ۏ�
    '**********************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sw As System.IO.StreamWriter  'StreamWriter�I�u�W�F�N�g
        Dim i As Integer                  '�J�E���^
        Dim sbuf As String                '�t�@�C���ɏo�͂���f�[�^

        DsExport.Clear()
        strSQL = "SELECT All8_Wrn_mtr.shop_code, Shop_mtr.[�X�ܖ�(��)] AS shop_name"
        strSQL += ", All8_Wrn_mtr.cust_lname + ' ' + All8_Wrn_mtr.cust_fname AS cust_name"
        strSQL += ", All8_Wrn_mtr.zip_code, All8_Wrn_mtr.adrs1, All8_Wrn_mtr.adrs2"
        strSQL += ", All8_Wrn_mtr.srch_phn, All8_Wrn_mtr.ordr_no, All8_Wrn_sub.line_no"
        strSQL += ", All8_Wrn_sub.close_date, All8_Wrn_sub.prch_price, All8_Wrn_sub.prch_date"
        strSQL += ", All8_Wrn_sub.wrn_prod, vdr_mtr.vdr_kana, All8_Wrn_sub.model_name"
        strSQL += ", All8_Wrn_sub.pos_code, All8_Wrn_sub.cont_flg, All8_Wrn_sub.item_cat_code"
        strSQL += ", All8_Wrn_mtr.cust_no, All8_Wrn_sub.kbn_cd, All8_Wrn_sub.close_cont_flg"
        strSQL += " FROM All8_Wrn_mtr INNER JOIN"
        strSQL += " All8_Wrn_sub ON All8_Wrn_mtr.ordr_no = All8_Wrn_sub.ordr_no LEFT OUTER JOIN"
        strSQL += " vdr_mtr ON All8_Wrn_sub.BY_cls = vdr_mtr.BY_cls AND"
        strSQL += " All8_Wrn_sub.bend_code = vdr_mtr.vdr_code LEFT OUTER JOIN"
        strSQL += " Shop_mtr ON All8_Wrn_mtr.BY_cls = Shop_mtr.BY_cls AND All8_Wrn_mtr.shop_code = Shop_mtr.shop_code"
        If poc_date2 = Date2.Text Then    '���ߑO
            strSQL += " WHERE (All8_Wrn_sub.cont_flg = 'A')"
            strSQL += " AND (All8_Wrn_sub.close_date IS NULL)"
            strSQL += " AND (All8_Wrn_sub.fin_date < CONVERT(DATETIME, '" & Label5.Text & "', 102))"
        Else
            strSQL += " WHERE (All8_Wrn_sub.close_cont_flg = 'A')"
            strSQL += " AND (All8_Wrn_sub.close_date = CONVERT(DATETIME, '" & Label02.Text & "', 102))"
        End If
        strSQL += " AND (All8_Wrn_sub.wrn_prod = 120)"   '10�N�ۏ�
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DB_OPEN()
        r = DaList1.Fill(DsExport, "CSV")
        DB_CLOSE()

        If r = 0 Then
            MessageBox.Show("�Y������f�[�^������܂���", "�G�N�X�|�[�g", MessageBoxButtons.OK)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '�t�@�C���ɏo��
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsExport.Tables("CSV"), "", "ordr_no,line_no", DataViewRowState.CurrentRows)

            waitDlg = New WaitDialog
            waitDlg.Owner = Me
            waitDlg.ProgressMax = DtView1.Count - 1
            waitDlg.ProgressMin = 0
            waitDlg.ProgressStep = 1
            waitDlg.ProgressValue = 0
            Me.Enabled = False
            waitDlg.Show()
            waitDlg.MainMsg = "CSV�f�[�^���o�͂��Ă��܂��B"

            'sbuf = "�X�܃R�[�h,�X�ܖ�,�ڋq��,�X�֔ԍ�,�Z���P,�Z���Q,�d�b�ԍ�,CID,�ۏؔԍ�,�s�ԍ�,�w����,�w�����i,�ۏ؊J�n��,������,���[�J�[��,�^��,POS�ԍ�,��,�i��,�ی�����,�f�[�^�敪,�ڋq�ԍ�,�\��"
            'sw.WriteLine(sbuf)

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressValue = i
                Application.DoEvents()
                sbuf = DtView1(i)("shop_code") & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("shop_name") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("cust_name") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("zip_code") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("adrs1") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("adrs2") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("srch_phn") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & "110" & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("ordr_no") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("line_no") & Chr(34) & ","
                sbuf = sbuf & DtView1(i)("prch_date") & ","
                sbuf = sbuf & DtView1(i)("prch_price") & ","
                sbuf = sbuf & DtView1(i)("prch_date") & ","
                sbuf = sbuf & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, DtView1(i)("wrn_prod"), DtView1(i)("prch_date"))) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("vdr_kana") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("model_name") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("pos_code") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & DtView1(i)("close_cont_flg") & Chr(34) & ","
                sbuf = sbuf & Chr(34) & Mid(DtView1(i)("item_cat_code"), 1, 4) & Chr(34) & ","
                sbuf = sbuf & "2.6,"
                sbuf = sbuf & Chr(34) & DtView1(i)("kbn_cd") & Chr(34) & ","
                If Label02.Text > "2012/09/01" Then
                    sbuf = sbuf & Chr(34) & DtView1(i)("cust_no") & Chr(34) & ","
                End If
                sw.WriteLine(sbuf)
            Next
        End If
        sw.Close()

        Me.Activate()
        waitDlg.Close()

        '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
        'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
        SaveFileDialog1.FileName = "�I�[���d�������҃f�[�^" & Format(CDate(Label02.Text), "yyyyMM") & ".csv"
        SaveFileDialog1.Filter = "CSV�t�@�C��|*.csv"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
            Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
        Else
            If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
            ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                MessageBox.Show("�A�v���P�[�V�����G���[", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '**  TextChanged
    '**********************************
    Private Sub Date1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.TextChanged
        If Date1.Number <> 0 Then
            Label01.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date1.Text & "/01")))
        End If
    End Sub
    Private Sub Date2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date2.TextChanged
        If Date2.Number <> 0 Then
            Label02.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date2.Text & "/01")))
            Label5.Text = DateAdd(DateInterval.Day, 1, CDate(Label02.Text))
        End If
    End Sub

    '**********************************
    '**  �I��
    '**********************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel �I���������̃v���V�[�W��
        Try
            '�񋟂��ꂽ�����^�C���Ăяo���\���b�p�[�̎Q�ƃJ�E���g���f�N�������g���܂�
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        objMutex.Close()
        Application.Exit()
    End Sub
End Class
