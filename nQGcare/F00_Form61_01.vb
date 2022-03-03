Imports GrapeCity.Win.Input.Interop

Public Class F00_Form61_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DsCMB1, DsCMB2 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, strSQL2, Err_F, WK_str, WK_str2, WK_code, WK_code2, ANS, fin_f As String
    Dim i, r, WK_SUI, WK_sou, WK_wrn_tem, WK_fee_un, WK_fee_cp As Integer
    Dim WK_date As Date

    Dim S_Edit04, S_Edit05 As String

    Dim fr_date, to_date As Date
    Dim set_f As String = "0"

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        'Me.Furigana = Me.Edit04.Ime

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
    Friend WithEvents Number1 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents add_date As System.Windows.Forms.Label
    Friend WithEvents tax_rate As System.Windows.Forms.Label
    Friend WithEvents CheckBox07 As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Number04 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CheckBox06 As System.Windows.Forms.CheckBox
    Friend WithEvents br_cmb09 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Date04 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents ittpan As System.Windows.Forms.Label
    Friend WithEvents CheckBox04 As System.Windows.Forms.CheckBox
    Friend WithEvents br_cmb05 As System.Windows.Forms.Label
    Friend WithEvents cmb01 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents cmb05 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Date03 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents CheckBox03 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox01 As System.Windows.Forms.CheckBox
    Friend WithEvents Edit09 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Number03 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Number02 As GrapeCity.Win.Input.Interop.Number
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Edit08 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Combo06 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Combo05 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Combo03 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo02 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button_S1 As System.Windows.Forms.Button
    Friend WithEvents Edit03 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit02 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Mask01 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents cmb07 As System.Windows.Forms.Label
    Friend WithEvents Combo07 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents br_cmb07 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Number1 = New GrapeCity.Win.Input.Interop.Number
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.add_date = New System.Windows.Forms.Label
        Me.tax_rate = New System.Windows.Forms.Label
        Me.CheckBox07 = New System.Windows.Forms.CheckBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Number04 = New GrapeCity.Win.Input.Interop.Number
        Me.Label16 = New System.Windows.Forms.Label
        Me.CheckBox06 = New System.Windows.Forms.CheckBox
        Me.br_cmb09 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Date04 = New GrapeCity.Win.Input.Interop.Date
        Me.ittpan = New System.Windows.Forms.Label
        Me.CheckBox04 = New System.Windows.Forms.CheckBox
        Me.br_cmb05 = New System.Windows.Forms.Label
        Me.cmb01 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.cmb05 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Date03 = New GrapeCity.Win.Input.Interop.Date
        Me.CheckBox03 = New System.Windows.Forms.CheckBox
        Me.CheckBox01 = New System.Windows.Forms.CheckBox
        Me.Edit09 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label24 = New System.Windows.Forms.Label
        Me.Combo09 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Number03 = New GrapeCity.Win.Input.Interop.Number
        Me.Label22 = New System.Windows.Forms.Label
        Me.Number02 = New GrapeCity.Win.Input.Interop.Number
        Me.Label21 = New System.Windows.Forms.Label
        Me.Edit08 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Interop.Date
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label15 = New System.Windows.Forms.Label
        Me.Combo06 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label14 = New System.Windows.Forms.Label
        Me.Combo05 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Combo03 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo02 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Combo01 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label8 = New System.Windows.Forms.Label
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button_S1 = New System.Windows.Forms.Button
        Me.Edit03 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit02 = New GrapeCity.Win.Input.Interop.Edit
        Me.Mask01 = New GrapeCity.Win.Input.Interop.Mask
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Interop.Date
        Me.cmb07 = New System.Windows.Forms.Label
        Me.Combo07 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label17 = New System.Windows.Forms.Label
        Me.br_cmb07 = New System.Windows.Forms.Label
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Number1
        '
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####", "", "", "-", "", "", "")
        Me.Number1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(228, 207)
        Me.Number1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("####", "", "", "-", "", "", "")
        Me.Number1.Location = New System.Drawing.Point(60, 2)
        Me.Number1.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number1.Name = "Number1"
        Me.Number1.ReadOnly = True
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(64, 28)
        Me.Number1.TabIndex = 1513
        Me.Number1.TabStop = False
        Me.Number1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Number1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number1.Value = Nothing
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(128, 2)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 24)
        Me.Label25.TabIndex = 1514
        Me.Label25.Text = "�N�x"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(248, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(748, 32)
        Me.Label3.TabIndex = 1506
        Me.Label3.Text = "QG-Care  iPad�@�����\�� �G���[�C��"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 582)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(980, 20)
        Me.msg.TabIndex = 1498
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(120, 610)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 28)
        Me.Button4.TabIndex = 1474
        Me.Button4.Text = "�폜"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(16, 610)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 28)
        Me.Button3.TabIndex = 1473
        Me.Button3.Text = "�X�V"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(916, 610)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 1475
        Me.Button99.Text = "����"
        '
        'add_date
        '
        Me.add_date.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.add_date.Location = New System.Drawing.Point(308, 80)
        Me.add_date.Name = "add_date"
        Me.add_date.Size = New System.Drawing.Size(104, 16)
        Me.add_date.TabIndex = 1579
        Me.add_date.Text = "add_date"
        Me.add_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.add_date.Visible = False
        '
        'tax_rate
        '
        Me.tax_rate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.tax_rate.Location = New System.Drawing.Point(468, 64)
        Me.tax_rate.Name = "tax_rate"
        Me.tax_rate.Size = New System.Drawing.Size(52, 16)
        Me.tax_rate.TabIndex = 1578
        Me.tax_rate.Text = "tax_rate"
        Me.tax_rate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tax_rate.Visible = False
        '
        'CheckBox07
        '
        Me.CheckBox07.Location = New System.Drawing.Point(308, 56)
        Me.CheckBox07.Name = "CheckBox07"
        Me.CheckBox07.Size = New System.Drawing.Size(148, 24)
        Me.CheckBox07.TabIndex = 1518
        Me.CheckBox07.Text = "����Œǒ�����"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(196, 280)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton2.TabIndex = 1529
        Me.RadioButton2.Text = "�@�l"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(128, 280)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton1.TabIndex = 1528
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "��w"
        '
        'Number04
        '
        Me.Number04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number04.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number04.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number04.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number04.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number04.Enabled = False
        Me.Number04.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number04.HighlightText = True
        Me.Number04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number04.Location = New System.Drawing.Point(764, 176)
        Me.Number04.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number04.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number04.Name = "Number04"
        Me.Number04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number04.Size = New System.Drawing.Size(104, 24)
        Me.Number04.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number04.TabIndex = 1550
        Me.Number04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number04.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(700, 176)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 24)
        Me.Label16.TabIndex = 1577
        Me.Label16.Text = "����"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBox06
        '
        Me.CheckBox06.Location = New System.Drawing.Point(236, 484)
        Me.CheckBox06.Name = "CheckBox06"
        Me.CheckBox06.Size = New System.Drawing.Size(60, 24)
        Me.CheckBox06.TabIndex = 1543
        Me.CheckBox06.Text = "�蓮"
        '
        'br_cmb09
        '
        Me.br_cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb09.Location = New System.Drawing.Point(640, 84)
        Me.br_cmb09.Name = "br_cmb09"
        Me.br_cmb09.Size = New System.Drawing.Size(352, 16)
        Me.br_cmb09.TabIndex = 1576
        Me.br_cmb09.Text = "br_cmb09"
        Me.br_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb09.Visible = False
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(236, 420)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 24)
        Me.Label26.TabIndex = 1575
        Me.Label26.Text = "�I��"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date04
        '
        Me.Date04.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date04.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date04.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date04.Location = New System.Drawing.Point(296, 420)
        Me.Date04.Name = "Date04"
        Me.Date04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date04.Size = New System.Drawing.Size(104, 24)
        Me.Date04.TabIndex = 1539
        Me.Date04.TabStop = False
        Me.Date04.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date04.Value = Nothing
        '
        'ittpan
        '
        Me.ittpan.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.ittpan.Location = New System.Drawing.Point(484, 504)
        Me.ittpan.Name = "ittpan"
        Me.ittpan.Size = New System.Drawing.Size(52, 16)
        Me.ittpan.TabIndex = 1574
        Me.ittpan.Text = "False"
        Me.ittpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ittpan.Visible = False
        '
        'CheckBox04
        '
        Me.CheckBox04.Location = New System.Drawing.Point(868, 360)
        Me.CheckBox04.Name = "CheckBox04"
        Me.CheckBox04.Size = New System.Drawing.Size(120, 36)
        Me.CheckBox04.TabIndex = 1537
        Me.CheckBox04.Text = "�V���A���ԍ��A���҂�"
        '
        'br_cmb05
        '
        Me.br_cmb05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb05.Location = New System.Drawing.Point(640, 64)
        Me.br_cmb05.Name = "br_cmb05"
        Me.br_cmb05.Size = New System.Drawing.Size(120, 16)
        Me.br_cmb05.TabIndex = 1573
        Me.br_cmb05.Text = "br_cmb05"
        Me.br_cmb05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb05.Visible = False
        '
        'cmb01
        '
        Me.cmb01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb01.Location = New System.Drawing.Point(320, 272)
        Me.cmb01.Name = "cmb01"
        Me.cmb01.Size = New System.Drawing.Size(52, 16)
        Me.cmb01.TabIndex = 1572
        Me.cmb01.Text = "cmb01"
        Me.cmb01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb01.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(428, 508)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1571
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'cmb05
        '
        Me.cmb05.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb05.Location = New System.Drawing.Point(312, 340)
        Me.cmb05.Name = "cmb05"
        Me.cmb05.Size = New System.Drawing.Size(52, 16)
        Me.cmb05.TabIndex = 1570
        Me.cmb05.Text = "cmb05"
        Me.cmb05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb05.Visible = False
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.SystemColors.Window
        Me.Label02.Location = New System.Drawing.Point(488, 520)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(48, 24)
        Me.Label02.TabIndex = 1569
        Me.Label02.Text = "���"
        Me.Label02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 356)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 24)
        Me.Label5.TabIndex = 1568
        Me.Label5.Text = "�@��"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date03
        '
        Me.Date03.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date03.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date03.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date03.Location = New System.Drawing.Point(764, 144)
        Me.Date03.Name = "Date03"
        Me.Date03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date03.Size = New System.Drawing.Size(104, 24)
        Me.Date03.TabIndex = 1549
        Me.Date03.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date03.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'CheckBox03
        '
        Me.CheckBox03.Location = New System.Drawing.Point(700, 144)
        Me.CheckBox03.Name = "CheckBox03"
        Me.CheckBox03.Size = New System.Drawing.Size(60, 24)
        Me.CheckBox03.TabIndex = 1548
        Me.CheckBox03.Text = "�S��"
        '
        'CheckBox01
        '
        Me.CheckBox01.Location = New System.Drawing.Point(700, 116)
        Me.CheckBox01.Name = "CheckBox01"
        Me.CheckBox01.TabIndex = 1547
        Me.CheckBox01.Text = "�����ؖ߂�"
        '
        'Edit09
        '
        Me.Edit09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit09.HighlightText = True
        Me.Edit09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit09.LengthAsByte = True
        Me.Edit09.Location = New System.Drawing.Point(128, 552)
        Me.Edit09.MaxLength = 50
        Me.Edit09.Name = "Edit09"
        Me.Edit09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit09.Size = New System.Drawing.Size(352, 24)
        Me.Edit09.TabIndex = 1545
        Me.Edit09.Text = "Edit09"
        Me.Edit09.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(8, 552)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 24)
        Me.Label24.TabIndex = 1566
        Me.Label24.Text = "�̔���"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(128, 520)
        Me.Combo09.MaxDropDownItems = 35
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(356, 24)
        Me.Combo09.TabIndex = 1544
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(8, 520)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(116, 24)
        Me.Label23.TabIndex = 1565
        Me.Label23.Text = "�戵�X"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number03
        '
        Me.Number03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number03.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number03.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number03.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number03.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number03.HighlightText = True
        Me.Number03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number03.Location = New System.Drawing.Point(128, 480)
        Me.Number03.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number03.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number03.Name = "Number03"
        Me.Number03.ReadOnly = True
        Me.Number03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number03.Size = New System.Drawing.Size(104, 24)
        Me.Number03.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number03.TabIndex = 1541
        Me.Number03.TabStop = False
        Me.Number03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number03.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 484)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(116, 24)
        Me.Label22.TabIndex = 1564
        Me.Label22.Text = "(�ō�)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Number02
        '
        Me.Number02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number02.DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.DropDownCalculator.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number02.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number02.Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###", "", "", "-", "", "", "")
        Me.Number02.HighlightText = True
        Me.Number02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number02.Location = New System.Drawing.Point(128, 452)
        Me.Number02.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.Number02.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Number02.Name = "Number02"
        Me.Number02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Number02.Size = New System.Drawing.Size(104, 24)
        Me.Number02.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number02.TabIndex = 1540
        Me.Number02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Number02.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 452)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 24)
        Me.Label21.TabIndex = 1563
        Me.Label21.Text = "��������(�ŕ�)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit08
        '
        Me.Edit08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit08.HighlightText = True
        Me.Edit08.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit08.LengthAsByte = True
        Me.Edit08.Location = New System.Drawing.Point(588, 420)
        Me.Edit08.MaxLength = 300
        Me.Edit08.Multiline = True
        Me.Edit08.Name = "Edit08"
        Me.Edit08.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit08.Size = New System.Drawing.Size(404, 164)
        Me.Edit08.TabIndex = 1546
        Me.Edit08.Text = "Edit08"
        Me.Edit08.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Top
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(544, 420)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 164)
        Me.Label20.TabIndex = 1562
        Me.Label20.Text = "����"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(40, 420)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 24)
        Me.Label19.TabIndex = 1561
        Me.Label19.Text = "�ۏ؊J�n"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(128, 420)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 1538
        Me.Date02.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date02.Value = Nothing
        '
        'Edit07
        '
        Me.Edit07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit07.HighlightText = True
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(680, 356)
        Me.Edit07.MaxLength = 50
        Me.Edit07.Name = "Edit07"
        Me.Edit07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit07.Size = New System.Drawing.Size(176, 24)
        Me.Edit07.TabIndex = 1536
        Me.Edit07.Text = "Edit07"
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(680, 332)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(176, 24)
        Me.Label15.TabIndex = 1560
        Me.Label15.Text = "�V���A���ԍ�"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo06
        '
        Me.Combo06.AutoSelect = True
        Me.Combo06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Combo06.Location = New System.Drawing.Point(368, 356)
        Me.Combo06.MaxDropDownItems = 20
        Me.Combo06.Name = "Combo06"
        Me.Combo06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo06.Size = New System.Drawing.Size(308, 24)
        Me.Combo06.TabIndex = 1535
        Me.Combo06.Value = "Combo06"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(368, 332)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(308, 24)
        Me.Label14.TabIndex = 1559
        Me.Label14.Text = "���i��"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo05
        '
        Me.Combo05.AutoSelect = True
        Me.Combo05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Combo05.Location = New System.Drawing.Point(124, 356)
        Me.Combo05.MaxDropDownItems = 20
        Me.Combo05.Name = "Combo05"
        Me.Combo05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo05.Size = New System.Drawing.Size(240, 24)
        Me.Combo05.TabIndex = 1533
        Me.Combo05.Value = "Combo05"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(124, 332)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(240, 24)
        Me.Label13.TabIndex = 1558
        Me.Label13.Text = "���[�J�["
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo03
        '
        Me.Combo03.AutoSelect = True
        Me.Combo03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo03.Location = New System.Drawing.Point(752, 304)
        Me.Combo03.MaxDropDownItems = 20
        Me.Combo03.Name = "Combo03"
        Me.Combo03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo03.Size = New System.Drawing.Size(240, 24)
        Me.Combo03.TabIndex = 1532
        Me.Combo03.Value = "Combo03"
        '
        'Combo02
        '
        Me.Combo02.AutoSelect = True
        Me.Combo02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo02.Location = New System.Drawing.Point(440, 304)
        Me.Combo02.MaxDropDownItems = 20
        Me.Combo02.Name = "Combo02"
        Me.Combo02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo02.Size = New System.Drawing.Size(240, 24)
        Me.Combo02.TabIndex = 1531
        Me.Combo02.Value = "Combo02"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(684, 304)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 24)
        Me.Label11.TabIndex = 1557
        Me.Label11.Text = "�w��"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(372, 308)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 24)
        Me.Label10.TabIndex = 1556
        Me.Label10.Text = "�w��"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 24)
        Me.Label9.TabIndex = 1555
        Me.Label9.Text = "��w"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo01.Location = New System.Drawing.Point(124, 304)
        Me.Combo01.MaxDropDownItems = 20
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(240, 24)
        Me.Combo01.TabIndex = 1530
        Me.Combo01.Value = "Combo01"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 256)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 24)
        Me.Label8.TabIndex = 1554
        Me.Label8.Text = "�d�b�ԍ�"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit06
        '
        Me.Edit06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit06.Format = "9#"
        Me.Edit06.HighlightText = True
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(128, 256)
        Me.Edit06.MaxLength = 20
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(160, 24)
        Me.Edit06.TabIndex = 1527
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 24)
        Me.Label6.TabIndex = 1553
        Me.Label6.Text = "�J�i"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 24)
        Me.Label7.TabIndex = 1552
        Me.Label7.Text = "����"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit05
        '
        Me.Edit05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(128, 148)
        Me.Edit05.MaxLength = 25
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(548, 24)
        Me.Edit05.TabIndex = 1521
        Me.Edit05.Text = "Edit05"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(128, 120)
        Me.Edit04.MaxLength = 25
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(548, 24)
        Me.Edit04.TabIndex = 1519
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 72)
        Me.Label4.TabIndex = 1551
        Me.Label4.Text = "�Z��"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button_S1
        '
        Me.Button_S1.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S1.Location = New System.Drawing.Point(240, 176)
        Me.Button_S1.Name = "Button_S1"
        Me.Button_S1.Size = New System.Drawing.Size(64, 24)
        Me.Button_S1.TabIndex = 1524
        Me.Button_S1.Text = "�����Z��"
        '
        'Edit03
        '
        Me.Edit03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit03.HighlightText = True
        Me.Edit03.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit03.LengthAsByte = True
        Me.Edit03.Location = New System.Drawing.Point(128, 228)
        Me.Edit03.MaxLength = 100
        Me.Edit03.Name = "Edit03"
        Me.Edit03.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit03.Size = New System.Drawing.Size(548, 24)
        Me.Edit03.TabIndex = 1526
        Me.Edit03.Text = "Edit03"
        Me.Edit03.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit02
        '
        Me.Edit02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit02.LengthAsByte = True
        Me.Edit02.Location = New System.Drawing.Point(128, 204)
        Me.Edit02.MaxLength = 100
        Me.Edit02.Name = "Edit02"
        Me.Edit02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit02.Size = New System.Drawing.Size(548, 24)
        Me.Edit02.TabIndex = 1525
        Me.Edit02.Text = "Edit02"
        Me.Edit02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Mask01
        '
        Me.Mask01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Mask01.Format = New GrapeCity.Win.Input.Interop.MaskFormat("�� \D{3}-\D{4}", "", "")
        Me.Mask01.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Mask01.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask01.Location = New System.Drawing.Point(128, 176)
        Me.Mask01.Name = "Mask01"
        Me.Mask01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Mask01.Size = New System.Drawing.Size(104, 24)
        Me.Mask01.TabIndex = 1523
        Me.Mask01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask01.Value = ""
        '
        'Edit01
        '
        Me.Edit01.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Edit01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(128, 88)
        Me.Edit01.MaxLength = 10
        Me.Edit01.Name = "Edit01"
        Me.Edit01.ReadOnly = True
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(104, 24)
        Me.Edit01.TabIndex = 1517
        Me.Edit01.TabStop = False
        Me.Edit01.Text = "EDIT01"
        Me.Edit01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 24)
        Me.Label2.TabIndex = 1515
        Me.Label2.Text = "�����ԍ�"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 24)
        Me.Label12.TabIndex = 1534
        Me.Label12.Text = "�\����"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(128, 56)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1516
        Me.Date01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'cmb07
        '
        Me.cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb07.Location = New System.Drawing.Point(236, 388)
        Me.cmb07.Name = "cmb07"
        Me.cmb07.Size = New System.Drawing.Size(52, 16)
        Me.cmb07.TabIndex = 1582
        Me.cmb07.Text = "cmb07"
        Me.cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb07.Visible = False
        '
        'Combo07
        '
        Me.Combo07.AutoSelect = True
        Me.Combo07.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo07.Location = New System.Drawing.Point(128, 388)
        Me.Combo07.MaxDropDownItems = 20
        Me.Combo07.Name = "Combo07"
        Me.Combo07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo07.Size = New System.Drawing.Size(104, 24)
        Me.Combo07.TabIndex = 1580
        Me.Combo07.Value = "Combo07"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 388)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 24)
        Me.Label17.TabIndex = 1581
        Me.Label17.Text = "�ۏ؊���"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'br_cmb07
        '
        Me.br_cmb07.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb07.Location = New System.Drawing.Point(508, 88)
        Me.br_cmb07.Name = "br_cmb07"
        Me.br_cmb07.Size = New System.Drawing.Size(120, 16)
        Me.br_cmb07.TabIndex = 1583
        Me.br_cmb07.Text = "br_cmb07"
        Me.br_cmb07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb07.Visible = False
        '
        'F00_Form61_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1000, 641)
        Me.Controls.Add(Me.br_cmb07)
        Me.Controls.Add(Me.cmb07)
        Me.Controls.Add(Me.Combo07)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.add_date)
        Me.Controls.Add(Me.tax_rate)
        Me.Controls.Add(Me.CheckBox07)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Number04)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CheckBox06)
        Me.Controls.Add(Me.br_cmb09)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Date04)
        Me.Controls.Add(Me.ittpan)
        Me.Controls.Add(Me.CheckBox04)
        Me.Controls.Add(Me.br_cmb05)
        Me.Controls.Add(Me.cmb01)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.cmb05)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Date03)
        Me.Controls.Add(Me.CheckBox03)
        Me.Controls.Add(Me.CheckBox01)
        Me.Controls.Add(Me.Edit09)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Number03)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Number02)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Edit08)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Combo06)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Combo05)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Combo03)
        Me.Controls.Add(Me.Combo02)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button_S1)
        Me.Controls.Add(Me.Edit03)
        Me.Controls.Add(Me.Edit02)
        Me.Controls.Add(Me.Mask01)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form61_01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�捞�݃G���[�C��(iPad)"
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo07, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** �N����
    '******************************************************************
    Private Sub F00_Form21_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** ��������
        Call DsSet()    '** �f�[�^�Z�b�g
        Call CmbSet()   '** �R���{�{�b�N�X�Z�b�g
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

        DsList1.Clear()

        '����ŗ�
        WK_DsList1.Clear()
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Now.Date, 1, 4) & Mid(Now.Date, 6, 2) & Mid(Now.Date, 9, 2) & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(WK_DsList1, "cls_TAX")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
            tax_rate.Text = WK_DtView1(0)("cls_code_name")
        Else
            tax_rate.Text = 8
        End If

        'iPad�������i�ŕʁj��w��
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'IUN')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "cls_IUN")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_IUN"), "", "", DataViewRowState.CurrentRows)
            WK_fee_un = WK_DtView1(0)("cls_code_name")
        Else
            WK_fee_un = 0
        End If

        'iPad�������i�ŕʁj�@�l��
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'ICP')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "cls_ICP")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView1 = New DataView(DsList1.Tables("cls_ICP"), "", "", DataViewRowState.CurrentRows)
            WK_fee_cp = WK_DtView1(0)("cls_code_name")
        Else
            WK_fee_cp = 0
        End If

        cmb05.Text = Nothing
        msg.Text = Nothing

    End Sub

    '********************************************************************
    '** �f�[�^�Z�b�g
    '********************************************************************
    Sub DsSet()

        '�Ј�
        strSQL = "SELECT * FROM M01_EMPL"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

        '�ۏ؊���
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSK')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsList1, "cls_HSK")
        DB_CLOSE()

    End Sub

    '********************************************************************
    '** �R���{�{�b�N�X�Z�b�g
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        '��w
        strSQL = "SELECT univ_code, univ_name FROM M01_univ WHERE (delt_flg = 0) ORDER BY univ_name_kana, univ_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB1, "M01_univ")
        Combo01.DataSource = DsCMB1.Tables("M01_univ")
        Combo01.DisplayMember = "univ_name"
        Combo01.ValueMember = "univ_code"

        '�w��
        strSQL = "SELECT dpmt_name FROM T01_member WHERE (delt_flg = 0) GROUP BY dpmt_name HAVING (dpmt_name IS NOT NULL) ORDER BY dpmt_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB1, "dpmt_name")
        Combo02.DataSource = DsCMB1.Tables("dpmt_name")
        Combo02.DisplayMember = "dpmt_name"
        Combo02.ValueMember = "dpmt_name"

        '�w��
        strSQL = "SELECT sbjt_name FROM T01_member WHERE (delt_flg = 0) GROUP BY sbjt_name ORDER BY sbjt_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB1, "sbjt_name")
        Combo03.DataSource = DsCMB1.Tables("sbjt_name")
        Combo03.DisplayMember = "sbjt_name"
        Combo03.ValueMember = "sbjt_name"

        '�ۏ؊���
        strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'HSK') AND (cls_code = 3 OR cls_code = 4) ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB1, "cls_HSK")
        Combo07.DataSource = DsCMB1.Tables("cls_HSK")
        Combo07.DisplayMember = "cls_code_name"
        Combo07.ValueMember = "cls_code"

        '�̔��X
        strSQL = "SELECT shop_code, shop_name, ittpan FROM M04_shop WHERE (shop_code <> 0) AND (delt_flg = 0) ORDER BY shop_name_kana, shop_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB1, "M04_shop")
        Combo09.DataSource = DsCMB1.Tables("M04_shop")
        Combo09.DisplayMember = "shop_name"
        Combo09.ValueMember = "shop_code"

        DB_CLOSE()

        Call cmb_modl_name() '���i��

        DB_OPEN("nQGCare")

        '���[�J�[
        strSQL = "SELECT vndr_code, name FROM M05_VNDR WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB1, "M05_VNDR")
        Combo05.DataSource = DsCMB1.Tables("M05_VNDR")
        Combo05.DisplayMember = "name"
        Combo05.ValueMember = "vndr_code"

        DB_CLOSE()
    End Sub
    Sub cmb_modl_name()
        DsCMB2.Clear()
        DB_OPEN("nQGCare")

        '���i��
        strSQL = "SELECT modl_name FROM T01_member"
        strSQL += " WHERE (delt_flg = 0)"
        If cmb05.Text <> Nothing Then
            strSQL += " AND (makr_code = '" & cmb05.Text & "')"
        End If
        strSQL += " GROUP BY modl_name "
        strSQL += "HAVING (modl_name IS NOT NULL)"
        strSQL += " ORDER BY modl_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsCMB2, "modl_name")
        Combo06.DataSource = DsCMB2.Tables("modl_name")
        Combo06.DisplayMember = "modl_name"
        Combo06.ValueMember = "modl_name"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '** ��ʃZ�b�g
    '********************************************************************
    Sub dsp_set()

        SqlCmd1 = New SqlClient.SqlCommand("sp_E01_member_ipad_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 9)
        Pram1.Value = P_PRAM1
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nQGCare")
        DaList1.Fill(DsList1, "E01_member")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("E01_member"), "", "", DataViewRowState.CurrentRows)

        Number1.Value = DtView1(0)("nendo")
        If IsDate(DtView1(0)("Part_date")) = True Then
            Date01.Text = DtView1(0)("Part_date")
        Else
            Date01.Text = Nothing
        End If
        Call CK_Date01()    '�\����
        'imp_seq.Value = DtView1(0)("imp_seq")
        'imp_seq2.Value = DtView1(0)("imp_seq2")
        'imp_seq3.Value = DtView1(0)("imp_seq3")
        Edit01.Text = Nothing
        Edit04.Text = DtView1(0)("name")
        Edit05.Text = DtView1(0)("name_kana")
        WK_str = DtView1(0)("zip") : WK_str = WK_str.Replace("-", "") : Mask01.Value = WK_str
        Edit02.Text = DtView1(0)("adrs1")
        Edit03.Text = DtView1(0)("adrs2")
        Edit06.Text = DtView1(0)("tel")
        cmb01.Text = DtView1(0)("univ_code")
        If Not IsDBNull(DtView1(0)("univ_name2")) Then Combo01.Text = DtView1(0)("univ_name2") Else Combo01.Text = Nothing
        Combo02.Text = DtView1(0)("dpmt_name")
        Combo03.Text = DtView1(0)("sbjt_name")

        CheckBox01.Checked = False
        CheckBox03.Checked = False
        Date03.Text = Nothing
        Number04.Value = 0
        CheckBox04.Checked = False
        Number02.Value = DtView1(0)("wrn_fee")
        Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)

        Combo05.Text = DtView1(0)("vndr_name") : br_cmb05.Text = DtView1(0)("vndr_name")
        WK_DtView1 = New DataView(DsCMB1.Tables("M05_VNDR"), "name = '" & Combo05.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            cmb05.Text = WK_DtView1(0)("vndr_code")
        End If
        Combo06.Text = DtView1(0)("modl_name")
        Edit07.Text = DtView1(0)("s_no")
        If IsDate(DtView1(0)("makr_wrn_stat")) = True Then
            Date02.Text = DtView1(0)("makr_wrn_stat")
        Else
            Date02.Text = Nothing
        End If

        WK_DtView1 = New DataView(DsList1.Tables("cls_HSK"), "cls_code_name = '" & DtView1(0)("wrn_tem") & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            WK_wrn_tem = WK_DtView1(0)("cls_code")
            Date04.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, WK_wrn_tem, DtView1(0)("makr_wrn_stat")))
        End If

        If Not IsDBNull(DtView1(0)("wrn_tem_code")) Then cmb07.Text = DtView1(0)("wrn_tem_code") Else cmb07.Text = Nothing
        If Not IsDBNull(DtView1(0)("wrn_tem")) Then Combo07.Text = DtView1(0)("wrn_tem") Else Combo07.Text = Nothing
        br_cmb07.Text = Combo07.Text

        cmb09.Text = DtView1(0)("shop_code")
        If Not IsDBNull(DtView1(0)("shop_name")) Then Combo09.Text = DtView1(0)("shop_name") Else Combo09.Text = Nothing
        If Not IsDBNull(DtView1(0)("ittpan")) Then
            If DtView1(0)("ittpan") = "True" Then
                Label02.Visible = True
                ittpan.Text = "True"
            Else
                Label02.Visible = False
                ittpan.Text = "False"
            End If
        Else
            Label02.Visible = False
            ittpan.Text = "False"
        End If
        Edit09.Text = DtView1(0)("sale_pson")
        Edit08.Text = Nothing

        CheckBox04.Checked = False

        msg.Text = DtView1(0)("err_msg")

        If Not IsDBNull(DtView1(0)("fin_empl_code")) Then
            WK_DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "empl_code =" & DtView1(0)("fin_empl_code"), "", DataViewRowState.CurrentRows)
            If Not IsDBNull(DtView1(0)("fin_date")) Then
                msg.Text = "����" & WK_DtView1(0)("name") & "����" & DtView1(0)("fin_date") & "�ɏC���ς݂ł��B"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            If Not IsDBNull(DtView1(0)("del_date")) Then
                msg.Text = "����" & WK_DtView1(0)("name") & "����" & DtView1(0)("del_date") & "�ɍ폜�ς݂ł��B"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            fin_f = "1"
        Else
            Button3.Enabled = True
            Button4.Enabled = True
            fin_f = "0"
        End If
    End Sub

    '******************************************************************
    '** ���ڃ`�F�b�N
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        Call CK_Date01()    '�\����
        If msg.Text <> Nothing Then Err_F = "1" : Date01.Focus() : Exit Sub

        Call CK_Edit04()    '����
        If msg.Text <> Nothing Then Err_F = "1" : Edit04.Focus() : Exit Sub

        Call CK_Edit05()    '�J�i
        If msg.Text <> Nothing Then Err_F = "1" : Edit05.Focus() : Exit Sub

        Call CK_Mask01()    '�X�֔ԍ�
        If msg.Text <> Nothing Then Err_F = "1" : Mask01.Focus() : Exit Sub

        Call CK_Edit02()    '�Z��1
        If msg.Text <> Nothing Then Err_F = "1" : Edit02.Focus() : Exit Sub

        Call CK_Edit03()    '�Z��2
        If msg.Text <> Nothing Then Err_F = "1" : Edit03.Focus() : Exit Sub

        Call CK_Combo01()   '��w
        If msg.Text <> Nothing Then Err_F = "1" : Combo01.Focus() : Exit Sub

        Call CK_Combo05()   '���[�J�[
        If msg.Text <> Nothing Then Err_F = "1" : Combo05.Focus() : Exit Sub

        Call CK_Combo06()   '���i��
        If msg.Text <> Nothing Then Err_F = "1" : Combo06.Focus() : Exit Sub

        Call CK_CheckBox04() '�V���A���ԍ��A���҂�
        If msg.Text <> Nothing Then Err_F = "1" : CheckBox04.Focus() : Exit Sub

        Call CK_Combo07()   '�ۏ؊���
        If msg.Text <> Nothing Then Err_F = "1" : Combo07.Focus() : Exit Sub

        Call CK_Date02()    '�ۏ؊J�n
        If msg.Text <> Nothing Then Err_F = "1" : Date02.Focus() : Exit Sub

        Call CK_Date04()    '�I��
        If msg.Text <> Nothing Then Err_F = "1" : Date04.Focus() : Exit Sub

        Call CK_Combo09()   '�̔��X
        If msg.Text <> Nothing Then Err_F = "1" : Combo09.Focus() : Exit Sub

        Call CK_Edit09()    '�̔���
        If msg.Text <> Nothing Then Err_F = "1" : Edit09.Focus() : Exit Sub

        Call CK_Date03()    '����܂��͑S����
        If msg.Text <> Nothing Then Err_F = "1" : Date03.Focus() : Exit Sub

    End Sub
    Sub CK_Date01()     '�\����
        msg.Text = Nothing

        If Date01.Number = 0 Then
            msg.Text = "�\�����̓��͂�����܂���B"
            Date01.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Date01.Text < "2019/10/01" Then
                CheckBox07.Visible = True       '�ǒ�
                CheckBox07.Focus()
            Else
                CheckBox07.Visible = False
            End If
            '����ŗ�
            WK_DsList1.Clear()
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Date01.Number, 1, 8) & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_TAX")
            DB_CLOSE()
            If r <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
                tax_rate.Text = WK_DtView1(0)("cls_code_name")
            Else
                tax_rate.Text = 8
            End If
        End If
        Date01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit04()     '����(��)
        msg.Text = Nothing
        Edit04.Text = Trim(Edit04.Text)
        Edit04.Text = Replace(Edit04.Text, vbCrLf, "")

        If Edit04.Text = Nothing Then
            msg.Text = "����(��)�̓��͂�����܂���B"
            Edit04.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit05()     '�J�i(��)
        msg.Text = Nothing
        Edit05.Text = Trim(Edit05.Text)
        Edit05.Text = Replace(Edit05.Text, vbCrLf, "")

        Edit05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Mask01()     '�X�֔ԍ�
        msg.Text = Nothing

        If Mask01.Value = Nothing Then
        Else
            If Len(Mask01.Value) <> 7 Then
                msg.Text = "�X�֔ԍ���7�����͂��Ă��������B"
                Mask01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Mask01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit02()     '�Z��1
        msg.Text = Nothing
        Edit02.Text = Trim(Edit02.Text)
        Edit02.Text = Replace(Edit02.Text, vbCrLf, "")

        If Edit02.Text = Nothing Then
            msg.Text = "�Z���̓��͂�����܂���B"
            Edit02.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Edit02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit03()     '�Z��2
        msg.Text = Nothing
        Edit03.Text = Trim(Edit03.Text)
        Edit03.Text = Replace(Edit03.Text, vbCrLf, "")

        Edit03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo01()    '��w
        msg.Text = Nothing
        cmb01.Text = Nothing
        Combo01.Text = Trim(Combo01.Text)

        If Combo01.Text = Nothing Then
            If RadioButton1.Checked = True Then
                msg.Text = "��w�̓��͂�����܂���B"
                Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        Else
            DtView1 = New DataView(DsCMB1.Tables("M01_univ"), "univ_name ='" & Combo01.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                cmb01.Text = DtView1(0)("univ_code")
            Else
                If RadioButton1.Checked = True Then
                    msg.Text = "�Y���̑�w�͂���܂���B"
                Else
                    msg.Text = "�Y���̖@�l�͂���܂���B"
                End If
                Combo01.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        Combo01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo05()    '���[�J�[
        msg.Text = Nothing
        Combo05.Text = Trim(Combo05.Text)

        If Combo05.Text <> br_cmb05.Text Then
            cmb05.Text = Nothing
            If Combo05.Text = Nothing Then
                msg.Text = "���[�J�[�̓��͂�����܂���B"
                Combo05.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("M05_VNDR"), "name ='" & Combo05.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb05.Text = DtView1(0)("vndr_code")
                Else
                    msg.Text = "�Y���̃��[�J�[�͂���܂���B"
                    Combo05.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If

            Call cmb_modl_name() '���i��
            Combo06.Text = Nothing
            br_cmb05.Text = Combo05.Text
        End If
        Combo05.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo06()    '���i��
        msg.Text = Nothing
        Combo06.Text = Trim(Combo06.Text)

        If Combo06.Text = Nothing Then
            msg.Text = "���i���̓��͂�����܂���B"
            Combo06.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Combo06.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit07()     '�V���A���ԍ�
        msg.Text = Nothing
        Edit07.Text = Trim(Edit07.Text)

        If Edit07.Text <> Nothing Then
            CheckBox04.Checked = False
        End If
        CheckBox04.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Sub CK_CheckBox04() '�V���A���ԍ��A���҂�
        msg.Text = Nothing
        If Edit07.Text <> Nothing Then
            If CheckBox04.Checked = True Then
                msg.Text = "�V���A���ԍ��A���҂��̓V���A���ԍ��������͂̎��̂ݓ��͉�"
                CheckBox04.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        CheckBox04.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Sub CK_Combo07()    '�ۏ؊���
        msg.Text = Nothing
        Combo07.Text = Trim(Combo07.Text)

        If Combo07.Text <> br_cmb07.Text Then
            cmb07.Text = Nothing
            If Combo07.Text = Nothing Then
                msg.Text = "�ۏ؊��Ԃ̓��͂�����܂���B"
                Combo07.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("cls_HSK"), "cls_code_name ='" & Combo07.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb07.Text = DtView1(0)("cls_code")
                Else
                    msg.Text = "�Y���̕ۏ؊��Ԃ͂���܂���B"
                    Combo07.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            'If Inz_F = "0" Then Number02.Value = wrn_fee_Get(ittpan.Text, cmb05.Text, cmb07.Text, cmb08.Text, Number1.Value)
            If cmb07.Text <> Nothing And Date02.Number <> 0 Then
                Date04.Text = wrn_end_Get(cmb07.Text, Date02.Text)
            Else
                Date04.Text = Nothing
            End If

            br_cmb07.Text = Combo07.Text
        End If
        Combo07.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date02()     '�ۏ؊J�n
        msg.Text = Nothing

        If Date02.Number = 0 Then
            msg.Text = "�ۏ؊J�n�̓��͂�����܂���B"
            Date02.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Date02.Number > Date01.Number Then
                msg.Text = "�\������ɂȂ��Ă��܂��B"
                Date02.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
            If Date04.Number = 0 Then
                Date04.Text = wrn_end_Get("3", Date02.Text)
            End If
        End If

        cx_amt_get()
        Date02.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date04()     '�I��
        msg.Text = Nothing

        If Date04.Number = 0 Then
            msg.Text = "�I���̓��͂�����܂���B"
            Date04.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Date04.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Combo09()    '�̔��X
        msg.Text = Nothing
        Combo09.Text = Trim(Combo09.Text)

        If Combo09.Text <> br_cmb09.Text Then
            cmb09.Text = Nothing
            ittpan.Text = Nothing
            Label02.Visible = False

            If Combo09.Text = Nothing Then
                msg.Text = "�̔��X�̓��͂�����܂���B"
                Combo09.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                DtView1 = New DataView(DsCMB1.Tables("M04_shop"), "shop_name ='" & Combo09.Text & "'", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    cmb09.Text = DtView1(0)("shop_code")
                    If DtView1(0)("ittpan") = "True" Then
                        Label02.Visible = True
                        ittpan.Text = "True"
                    Else
                        ittpan.Text = "False"
                    End If
                Else
                    msg.Text = "�Y���̔̔��X�͂���܂���B"
                    Combo09.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If
            br_cmb09.Text = Combo09.Text
        End If
        Combo09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Edit09()     '�̔���
        msg.Text = Nothing
        Edit09.Text = Trim(Edit09.Text)
        Edit09.Text = Replace(Edit09.Text, vbCrLf, "")

        Edit09.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date03()     '����܂��͑S����
        msg.Text = Nothing
        If CheckBox03.Checked = True Then
            If Date03.Number = 0 Then
                msg.Text = "�S���̎��͓��t�̓��͂����Ă��������B"
                Date03.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        Else
            If Date03.Number <> 0 Then
                msg.Text = "�S���łȂ����͓��t�̓��͂͏o���܂���B"
                Date03.BackColor = System.Drawing.Color.Red : Exit Sub
            End If
        End If
        cx_amt_get()
        Date03.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_daburi()

        '�d���`�F�b�N�i��w���Ǝ����j
        WK_DsList1.Clear()
        strSQL = "SELECT univ_code, user_name"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " T05_iPad ON T01_member.code = T05_iPad.code"
        strSQL += " WHERE (univ_code = " & cmb01.Text & ")"
        strSQL += " AND (user_name = '" & Edit04.Text & "')"
        strSQL += " AND (nendo = " & P_proc_y & ") AND (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(WK_DsList1, "T01_member")
        DB_CLOSE()
        If r <> 0 Then
            msg.Text = "��w���Ǝ����Ŋ��ɓ��͍ς�"
            Edit04.BackColor = System.Drawing.Color.Red
            cmb01.BackColor = System.Drawing.Color.Red : Exit Sub
        End If

    End Sub
    Sub CK_fin()    '���ɏ�����
        WK_DsList1.Clear()
        strSQL = "SELECT id, fin_date, del_date, fin_empl_code"
        strSQL += " FROM E01_member_ipad"
        strSQL += " WHERE (id = " & P_PRAM1 & ")"
        strSQL += " AND (fin_empl_code IS NOT NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(WK_DsList1, "E01_member")
        DB_CLOSE()
        If r <> 0 Then
            WK_DtView2 = New DataView(WK_DsList1.Tables("E01_member"), "", "", DataViewRowState.CurrentRows)

            WK_DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "empl_code =" & WK_DtView2(0)("fin_empl_code"), "", DataViewRowState.CurrentRows)
            If Not IsDBNull(WK_DtView2(0)("fin_date")) Then
                msg.Text = "����" & WK_DtView1(0)("name") & "����" & WK_DtView2(0)("fin_date") & "�ɏC���ς݂ł��B"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            If Not IsDBNull(WK_DtView2(0)("del_date")) Then
                msg.Text = "����" & WK_DtView1(0)("name") & "����" & WK_DtView2(0)("del_date") & "�ɍ폜�ς݂ł��B"
                Button3.Enabled = False
                Button4.Enabled = False
            End If
            fin_f = "1"
        End If

    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        Call CK_Date01()    '�\����
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Call CK_Edit04()    '����
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Call CK_Edit05()    '�J�i
    End Sub
    Private Sub Mask01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask01.LostFocus
        Call CK_Mask01()    '�X�֔ԍ�
    End Sub
    Private Sub Edit02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit02.LostFocus
        Call CK_Edit02()    '�Z��1
    End Sub
    Private Sub Edit03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit03.LostFocus
        Call CK_Edit03()    '�Z��2
    End Sub
    Private Sub Combo01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.LostFocus
        Call CK_Combo01()   '��w
    End Sub
    Private Sub Combo05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo05.LostFocus
        Call CK_Combo05()   '���[�J�[
    End Sub
    Private Sub Combo06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo06.LostFocus
        Call CK_Combo06()   '���i��
    End Sub
    Private Sub Edit07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit07.LostFocus
        Call CK_Edit07()    '�V���A���ԍ�
    End Sub
    Private Sub Combo07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo07.LostFocus
        Call CK_Combo07()   '�ۏ؊���
        amn_set()
    End Sub
    Private Sub Date02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date02.LostFocus
        Call CK_Date02()   '�ۏ؊J�n
    End Sub
    Private Sub Date04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date04.LostFocus
        Call CK_Date04()   '�I��
    End Sub
    Private Sub Combo09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.LostFocus
        Call CK_Combo09()   '�̔��X
    End Sub
    Private Sub Edit09_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit09.LostFocus
        Call CK_Edit09()    '�̔���
    End Sub
    Private Sub Date03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date03.LostFocus
        Call CK_Date03()    '����܂��͑S����
    End Sub
    Private Sub CheckBox04_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox04.CheckedChanged
        Call CK_CheckBox04() '�V���A���ԍ��A���҂�
    End Sub

    '******************************************************************
    '** TextChanged
    '******************************************************************
    '��������(�ŕ�)
    Private Sub Number02_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number02.TextChanged
        Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)
    End Sub
    '�S���t���O
    Private Sub CheckBox03_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox03.CheckedChanged
        If CheckBox03.Checked = False Then
            Date03.Text = Nothing
            Number04.Value = 0
        End If
    End Sub
    Sub cx_amt_get()
        Number04.Value = 0
        If Date02.Number <> 0 And Date03.Number <> 0 Then   '�ۏ؊J�n�ƑS��������
            If Date02.Text <= Date03.Text Then    '�ۏ؊J�n�ƑS��������
                If DateAdd(DateInterval.Year, 1, CDate(Date02.Text)) > Date03.Text Then  '1�N��
                    If RadioButton1.Checked = True Then '��w
                        Number04.Value = 4100
                    Else                                '�@�l
                        Number04.Value = 4300
                    End If
                Else
                    If DateAdd(DateInterval.Year, 2, CDate(Date02.Text)) > Date03.Text Then  '2�N��
                        If RadioButton1.Checked = True Then '��w
                            Number04.Value = 2000
                        Else                                '�@�l
                            Number04.Value = 2100
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    '��w/�@�l
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If set_f = "0" Then
            Label9.Text = "��w"
            Label10.Text = "�w��"
            Number02.Value = 0
            amn_set()
            cx_amt_get()
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If set_f = "0" Then
            Label9.Text = "���"
            Label10.Text = "����"
            Number02.Value = 0
            amn_set()
            cx_amt_get()
        End If
    End Sub
    Sub amn_set()
        If RadioButton1.Checked = True Then '��w
            'iPad�������i�ŕʁj��w��
            WK_DsList1.Clear()
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'IUN') AND (cls_code = '" & cmb07.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_IUN")
            DB_CLOSE()
            If r <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("cls_IUN"), "", "", DataViewRowState.CurrentRows)
                Number02.Value = WK_DtView1(0)("cls_code_name")
            Else
                Number02.Value = 0
            End If
        Else                                '�@�l
            Number02.Value = WK_fee_cp
        End If
    End Sub
    '�蓮
    Private Sub CheckBox06_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox06.CheckedChanged
        If CheckBox06.Checked = True Then
            Number03.ReadOnly = False
            Number03.Focus()
        Else
            Number03.ReadOnly = True
            Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)
        End If
    End Sub

    '********************************************************************
    '**  �ӂ肪�Ȏ����擾
    '********************************************************************
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' �擾�����ӂ肪�Ȃ�\�����܂��B
    '    If Edit04.ReadOnly = False Then
    '        Edit05.Text += e.ReadString
    '    End If
    'End Sub

    '******************************************************************
    '** �����Z��
    '******************************************************************
    Private Sub Button_S1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S1.Click
        '�X�֔ԍ�->�Z��
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList1.Clear()
        strSQL = "SELECT adrs FROM M15_ZIP"
        strSQL += " WHERE (zip = '" & Mask01.Value & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(P_DsList1, "M15_ZIP")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                msg.Text = "�Y���X�֔ԍ��Ȃ�"
                Mask01.Focus()
            Case Is = 1
                WK_DtView1 = New DataView(P_DsList1.Tables("M15_ZIP"), "", "", DataViewRowState.CurrentRows)
                Edit02.Text = Trim(WK_DtView1(0)("adrs"))
                Edit02.Focus()
                Edit02.BackColor = System.Drawing.SystemColors.Window
            Case Else
                Dim F00_Form10_02 As New F00_Form10_02
                F00_Form10_02.ShowDialog()

                If P_RTN <> Nothing Then Edit02.Text = P_RTN : Edit02.Focus() : Edit02.BackColor = System.Drawing.SystemColors.Window
        End Select

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** �X�V
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** ���ڃ`�F�b�N
        If Err_F = "0" Then

            Call CK_daburi()    '�d���`�F�b�N�i��w���Ǝ����j
            If r <> 0 Then
                ANS = MessageBox.Show("��w���Ǝ����Ŋ��ɓ��͍ς݂ł���" & System.Environment.NewLine & "�o�^���Ă�낵���ł���", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If ANS = "2" Then Cursor = System.Windows.Forms.Cursors.Default : Exit Sub '������
            End If

            WK_code = Count_Get("G" & P_proc_y1 & "03") '�����ԍ�
            Edit01.Text = WK_code

            strSQL = "INSERT INTO T01_member"
            strSQL += " (code, user_name, user_name_search, use_name_kana, use_name_kana_search, zip, adrs1"
            strSQL += ", adrs2, tel, univ_code, dpmt_name, sbjt_name, makr_code, modl_name, s_no, prch_amnt"
            strSQL += ", wrn_tem, makr_wrn_stat, wrn_end, wrn_range, shop_code, sale_pson, Part_date, wrn_fee"
            strSQL += ", tax_rate, Part_prt, Part_prt_bak, tonan_flg, zenson_flg, tonan_date, suisen_flg"
            strSQL += ", memo, imp_seq, nendo, reg_date, delt_flg)"
            strSQL += " VALUES ('" & Edit01.Text & "'"                              '�����ԍ�
            strSQL += ", '" & Edit04.Text & "'"                 '����
            S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "�@", "")
            strSQL += ", '" & S_Edit04 & "'"                                        '�����p����
            strSQL += ", '" & Edit05.Text & "'"                  '�J�i
            S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "�@", "")
            strSQL += ", '" & S_Edit05 & "'"                                        '�����p�J�i
            strSQL += ", '" & Mask01.Value & "'"                                    '�X�֔ԍ�
            strSQL += ", '" & Edit02.Text & "'"                                     '�Z��1
            strSQL += ", '" & Edit03.Text & "'"                                     '�Z��2
            strSQL += ", '" & Edit06.Text & "'"                                     '�d�b�ԍ�
            If Combo01.Text <> Nothing Then
                strSQL += ", " & cmb01.Text                                         '��w
            Else
                strSQL += ", NULL"                                                  '��w
            End If
            strSQL += ", '" & Combo02.Text & "'"                                    '�w��
            strSQL += ", '" & Combo03.Text & "'"                                    '�w��
            strSQL += ", '" & cmb05.Text & "'"                                      '���[�J�[
            strSQL += ", '" & Combo06.Text & "'"                                    '���i��
            strSQL += ", '" & Edit07.Text & "'"                                     '�V���A����
            strSQL += ", 0"                                                         '�w�����i
            strSQL += ", '" & DateDiff("yyyy", Date02.Text, Date04.Text) & "'"      '�ۏ؊���
            strSQL += ", CONVERT(DATETIME, '" & Date02.Text & "', 102)"             '�ۏ؊J�n��
            strSQL += ", CONVERT(DATETIME, '" & Date04.Text & "', 102)"             '�I��
            strSQL += ", 10"                                                         '�ۏ͈ؔ�
            strSQL += ", " & cmb09.Text                                             '�̔��X
            strSQL += ", '" & Edit09.Text & "'"                                     '�̔���
            strSQL += ", CONVERT(DATETIME, '" & Date01.Text & "', 102)"             '�\����
            strSQL += ", " & Number02.Value                                         '��������(�ŕ�)
            strSQL += ", " & tax_rate.Text                                          '����ŗ�
            strSQL += ", 0"                                                         '�����؈��
            If CheckBox01.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '�����ؖ߂�
            strSQL += ", 0"                                                         '����
            If CheckBox03.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '�S��
            If Date03.Number <> 0 Then
                strSQL += ", CONVERT(DATETIME, '" & Date03.Text & "', 102)"         '�S����
            Else
                strSQL += ", NULL"
            End If
            strSQL += ", 0"                                                         '���E
            strSQL += ", '" & Edit08.Text & "'"                                     '����
            strSQL += ", 0"                                                         '�捞�݇�
            strSQL += ", " & P_proc_y                                               '�N�x
            strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"                '�o�^��
            strSQL += ", 0)"                                                        '�폜�׸�
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()

            '�V���A�����҂�
            If CheckBox04.Checked = True Then
                'T03_s_no_wait
                strSQL = "INSERT INTO T03_s_no_wait"
                strSQL += " (code, s_no_wait)"
                strSQL += " VALUES ('" & Edit01.Text & "'"              '�����ԍ�
                strSQL += ", 1)"                                        'S/N�A���҂�
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If

            'T05_iPad
            strSQL = "INSERT INTO T05_iPad"
            strSQL += " (code, user_name_sei, user_name_mei, use_name_kana_sei, use_name_kana_mei, wrn_fee_flg, cxl_amnt, corp_flg, add_flg, add_date)"
            strSQL += " VALUES ('" & Edit01.Text & "'"                                              '�����ԍ�
            strSQL += ", ''"                                                     '����(��)
            strSQL += ", ''"                                                 '����(��)
            strSQL += ", ''"                                                     '�J�i(��)
            strSQL += ", ''"                                                 '�J�i(��)
            If CheckBox06.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '�蓮
            strSQL += ", " & Number04.Value & ""                                                    '����
            If RadioButton2.Checked = True Then strSQL += ", 1" Else strSQL += ", 0" '�@�l
            If CheckBox07.Checked = True Then
                strSQL += ", 1"                                                                     '�ǒ�
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102))"                           '�ǒ���
            Else
                strSQL += ", 0"
                strSQL += ", NULL"
            End If
            strSQL += ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            strSQL = "UPDATE E01_member_ipad"
            strSQL += " SET fin_date = CONVERT(DATETIME, '" & Now & "', 102)"
            strSQL += ", fin_empl_code = " & P_EMPL_NO
            strSQL += " WHERE (id = " & P_PRAM1 & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DB_OPEN("nQGCare")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            P_RTN = "1"
            DsList1.Clear()

            MessageBox.Show("�����ԍ��F" & Edit01.Text & " �œo�^���܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** �폜
    '******************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Err_F = "0"

        Call CK_fin()       '���ɏ�����
        If msg.Text <> Nothing Then Err_F = "1" : Exit Sub

        ANS = MessageBox.Show("�폜���Ă�낵���ł���", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If ANS = "2" Then Exit Sub '������
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        strSQL = "UPDATE E01_member_ipad"
        strSQL += " SET del_date = CONVERT(DATETIME, '" & Now & "', 102)"
        strSQL += ", fin_empl_code = " & P_EMPL_NO
        strSQL += " WHERE (id = " & P_PRAM1 & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DB_OPEN("nQGCare")
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        P_RTN = "1"
        DsList1.Clear()
        MessageBox.Show("�폜���܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Close()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** ����
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        If fin_f = "1" Then
            P_RTN = "1"     '���ɏ�����
        Else
            P_RTN = "0"
        End If
        DsList1.Clear()
        Close()
    End Sub

    '******************************************************************
    '** �\�����ύX��
    '******************************************************************
    Private Sub Date01_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Date01.TextChanged
        If IsDate(Date01.Text) Then
            '����ŗ�
            WK_DsList1.Clear()
            strSQL = "SELECT cls_code, cls_code_name FROM M02_cls WHERE (cls = 'TAX') AND (cls_code <= " & Mid(Date01.Text, 1, 4) & Mid(Date01.Text, 6, 2) & Mid(Date01.Text, 9, 2) & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(WK_DsList1, "cls_TAX")
            DB_CLOSE()
            If r <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("cls_TAX"), "", "cls_code DESC", DataViewRowState.CurrentRows)
                tax_rate.Text = WK_DtView1(0)("cls_code_name")
            Else
                tax_rate.Text = 10
            End If
        Else
            tax_rate.Text = 10
        End If
        Number03.Value = Number02.Value + RoundDOWN(Number02.Value * tax_rate.Text / 100, 0)
    End Sub
End Class
