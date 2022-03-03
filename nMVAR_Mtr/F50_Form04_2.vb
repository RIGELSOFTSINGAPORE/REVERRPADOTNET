Imports GrapeCity.Win.Input.Interop

Public Class F50_Form04_2
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''�i�s�󋵃t�H�[���N���X  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    'Friend WithEvents Furigana As New ImeHandler

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView
    Dim WK_DtView1, WK_DtView2, WK_DtView3 As DataView

    Dim strSQL, strFile, strData, Err_F As String
    Dim i, chg_itm, r As Integer
    Dim M_CLS As String = "M05"
    Dim WK_str, WK_str2 As String

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        'Me.Furigana = Me.Edit002.Ime

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox002 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit002 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents CheckBox001 As System.Windows.Forms.CheckBox
    Friend WithEvents Label001 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit004 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents DataGridEx2 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Edit005 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents CheckBox003 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents CL001_name As System.Windows.Forms.Label
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button_S5 As System.Windows.Forms.Button
    Friend WithEvents Mask1 As GrapeCity.Win.Input.Interop.Mask
    Friend WithEvents Label006 As System.Windows.Forms.Label
    Friend WithEvents Label005 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Edit009 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit008 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit007 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit006 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Edit010 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents CL007 As System.Windows.Forms.Label
    Friend WithEvents Combo007 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CL006 As System.Windows.Forms.Label
    Friend WithEvents Combo006 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.msg = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Edit003 = New GrapeCity.Win.Input.Interop.Edit
        Me.CheckBox002 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Edit004 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit002 = New GrapeCity.Win.Input.Interop.Edit
        Me.CheckBox001 = New System.Windows.Forms.CheckBox
        Me.Label001 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridEx2 = New nMVAR.DataGridEx
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.Edit005 = New GrapeCity.Win.Input.Interop.Edit
        Me.CheckBox003 = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Interop.Combo
        Me.CL001 = New System.Windows.Forms.Label
        Me.CL001_name = New System.Windows.Forms.Label
        Me.Combo002 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label8 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button_S5 = New System.Windows.Forms.Button
        Me.Edit009 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit008 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit007 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit006 = New GrapeCity.Win.Input.Interop.Edit
        Me.Mask1 = New GrapeCity.Win.Input.Interop.Mask
        Me.Label006 = New System.Windows.Forms.Label
        Me.Label005 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Edit010 = New GrapeCity.Win.Input.Interop.Edit
        Me.CL007 = New System.Windows.Forms.Label
        Me.Combo007 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label15 = New System.Windows.Forms.Label
        Me.CL006 = New System.Windows.Forms.Label
        Me.Combo006 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 620)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(964, 20)
        Me.msg.TabIndex = 1210
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 1207
        Me.Label4.Text = "�p��"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit003
        '
        Me.Edit003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.Format = "A#9a"
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(116, 56)
        Me.Edit003.MaxLength = 50
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(444, 20)
        Me.Edit003.TabIndex = 2
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'CheckBox002
        '
        Me.CheckBox002.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox002.Location = New System.Drawing.Point(736, 152)
        Me.CheckBox002.Name = "CheckBox002"
        Me.CheckBox002.Size = New System.Drawing.Size(48, 20)
        Me.CheckBox002.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(572, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 20)
        Me.Label2.TabIndex = 1206
        Me.Label2.Text = "�F��"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(824, 648)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 32)
        Me.Button80.TabIndex = 22
        Me.Button80.Text = "����"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(12, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "�X�V"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(20, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 20)
        Me.Label9.TabIndex = 1203
        Me.Label9.Text = "�J�i"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit004
        '
        Me.Edit004.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit004.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit004.Format = "KA#a"
        Me.Edit004.HighlightText = True
        Me.Edit004.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit004.LengthAsByte = True
        Me.Edit004.Location = New System.Drawing.Point(116, 80)
        Me.Edit004.MaxLength = 50
        Me.Edit004.Name = "Edit004"
        Me.Edit004.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit004.Size = New System.Drawing.Size(444, 20)
        Me.Edit004.TabIndex = 3
        Me.Edit004.Text = "��������������������"
        Me.Edit004.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(20, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 20)
        Me.Label6.TabIndex = 1202
        Me.Label6.Text = "���[�J�[��"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Navy
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(20, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 20)
        Me.Label11.TabIndex = 1201
        Me.Label11.Text = "Ұ������"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.Format = "9"
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(116, 8)
        Me.Edit001.MaxLength = 2
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(32, 20)
        Me.Edit001.TabIndex = 0
        Me.Edit001.Text = "00"
        Me.Edit001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit002
        '
        Me.Edit002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit002.HighlightText = True
        Me.Edit002.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit002.LengthAsByte = True
        Me.Edit002.Location = New System.Drawing.Point(116, 32)
        Me.Edit002.MaxLength = 50
        Me.Edit002.Name = "Edit002"
        Me.Edit002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit002.Size = New System.Drawing.Size(444, 20)
        Me.Edit002.TabIndex = 1
        Me.Edit002.Text = "��������������������"
        Me.Edit002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'CheckBox001
        '
        Me.CheckBox001.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox001.Location = New System.Drawing.Point(736, 176)
        Me.CheckBox001.Name = "CheckBox001"
        Me.CheckBox001.Size = New System.Drawing.Size(48, 20)
        Me.CheckBox001.TabIndex = 18
        '
        'Label001
        '
        Me.Label001.Location = New System.Drawing.Point(872, 12)
        Me.Label001.Name = "Label001"
        Me.Label001.Size = New System.Drawing.Size(104, 24)
        Me.Label001.TabIndex = 1199
        Me.Label001.Text = "Label001"
        Me.Label001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Navy
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(572, 176)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(160, 20)
        Me.Label52.TabIndex = 1198
        Me.Label52.Text = "�폜�t���O"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Navy
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(784, 12)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 24)
        Me.Label51.TabIndex = 1197
        Me.Label51.Text = "�o�^��"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(908, 648)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 23
        Me.Button98.Text = "�߂�"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(792, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 20)
        Me.Label1.TabIndex = 1211
        Me.Label1.Text = "�i�C���҂ɔF�肪�K�v�j"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGridEx1.CaptionText = "�Z�p��"
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(24, 248)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(464, 364)
        Me.DataGridEx1.TabIndex = 19
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M30_TECH_AMNT"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "��ٰ��"
        Me.DataGridTextBoxColumn1.MappingName = "grup_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 60
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "�̎к���"
        Me.DataGridTextBoxColumn2.MappingName = "store_code"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 80
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "�̎Ж�"
        Me.DataGridTextBoxColumn3.MappingName = "name"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 200
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "�ݒ��"
        Me.DataGridTextBoxColumn4.MappingName = "sumi"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 65
        '
        'DataGridEx2
        '
        Me.DataGridEx2.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGridEx2.CaptionText = "���i�|��"
        Me.DataGridEx2.DataMember = ""
        Me.DataGridEx2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.DataGridEx2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx2.Location = New System.Drawing.Point(500, 248)
        Me.DataGridEx2.Name = "DataGridEx2"
        Me.DataGridEx2.ReadOnly = True
        Me.DataGridEx2.Size = New System.Drawing.Size(464, 364)
        Me.DataGridEx2.TabIndex = 20
        Me.DataGridEx2.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DataGridEx2
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "M31_PART_RATE"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "��ٰ��"
        Me.DataGridTextBoxColumn5.MappingName = "grup_code"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 60
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "�̎к���"
        Me.DataGridTextBoxColumn6.MappingName = "store_code"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 80
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "�̎Ж�"
        Me.DataGridTextBoxColumn7.MappingName = "name"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 200
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "�ݒ��"
        Me.DataGridTextBoxColumn8.MappingName = "sumi"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 65
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(572, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 20)
        Me.Label3.TabIndex = 1215
        Me.Label3.Text = "��t�ԍ���2��"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit005
        '
        Me.Edit005.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit005.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit005.Format = "A"
        Me.Edit005.HighlightText = True
        Me.Edit005.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit005.LengthAsByte = True
        Me.Edit005.Location = New System.Drawing.Point(732, 56)
        Me.Edit005.MaxLength = 2
        Me.Edit005.Name = "Edit005"
        Me.Edit005.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit005.Size = New System.Drawing.Size(32, 20)
        Me.Edit005.TabIndex = 13
        Me.Edit005.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Edit005.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'CheckBox003
        '
        Me.CheckBox003.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox003.Location = New System.Drawing.Point(732, 80)
        Me.CheckBox003.Name = "CheckBox003"
        Me.CheckBox003.Size = New System.Drawing.Size(48, 20)
        Me.CheckBox003.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(572, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 1217
        Me.Label5.Text = "NCR����"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(572, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 20)
        Me.Label7.TabIndex = 1218
        Me.Label7.Text = "QG Care��Ұ��"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label7.Visible = False
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Location = New System.Drawing.Point(732, 104)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(164, 20)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 15
        Me.Combo001.Value = "Combo001"
        Me.Combo001.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(896, 104)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(60, 16)
        Me.CL001.TabIndex = 1250
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'CL001_name
        '
        Me.CL001_name.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001_name.Location = New System.Drawing.Point(788, 88)
        Me.CL001_name.Name = "CL001_name"
        Me.CL001_name.Size = New System.Drawing.Size(168, 16)
        Me.CL001_name.TabIndex = 1251
        Me.CL001_name.Text = "CL001_name"
        Me.CL001_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001_name.Visible = False
        '
        'Combo002
        '
        Me.Combo002.AutoSelect = True
        'Me.Combo002.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
        Me.Combo002.Location = New System.Drawing.Point(732, 128)
        Me.Combo002.MaxDropDownItems = 20
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(164, 20)
        Me.Combo002.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo002.TabIndex = 16
        Me.Combo002.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo002.Value = "Combo002"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(572, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 20)
        Me.Label8.TabIndex = 1253
        Me.Label8.Text = "���i���i�⍇���[�p�^�[��"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(896, 128)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(60, 16)
        Me.CL002.TabIndex = 1254
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(456, 648)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(160, 32)
        Me.Button5.TabIndex = 1255
        Me.Button5.Text = "�Z�p��CSV�o��"
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(624, 648)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(160, 32)
        Me.Button6.TabIndex = 1256
        Me.Button6.Text = "���i�|��CSV�o��"
        '
        'Button_S5
        '
        Me.Button_S5.BackColor = System.Drawing.SystemColors.Control
        Me.Button_S5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_S5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_S5.Location = New System.Drawing.Point(208, 128)
        Me.Button_S5.Name = "Button_S5"
        Me.Button_S5.Size = New System.Drawing.Size(64, 20)
        Me.Button_S5.TabIndex = 6
        Me.Button_S5.Text = "�����Z��"
        '
        'Edit009
        '
        Me.Edit009.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit009.Format = "9#"
        Me.Edit009.HighlightText = True
        Me.Edit009.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit009.LengthAsByte = True
        Me.Edit009.Location = New System.Drawing.Point(404, 200)
        Me.Edit009.MaxLength = 14
        Me.Edit009.Name = "Edit009"
        Me.Edit009.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit009.Size = New System.Drawing.Size(156, 20)
        Me.Edit009.TabIndex = 10
        Me.Edit009.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit008
        '
        Me.Edit008.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit008.Format = "9#"
        Me.Edit008.HighlightText = True
        Me.Edit008.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit008.LengthAsByte = True
        Me.Edit008.Location = New System.Drawing.Point(116, 200)
        Me.Edit008.MaxLength = 14
        Me.Edit008.Name = "Edit008"
        Me.Edit008.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit008.Size = New System.Drawing.Size(156, 20)
        Me.Edit008.TabIndex = 9
        Me.Edit008.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit007
        '
        Me.Edit007.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit007.HighlightText = True
        Me.Edit007.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit007.LengthAsByte = True
        Me.Edit007.Location = New System.Drawing.Point(116, 176)
        Me.Edit007.MaxLength = 40
        Me.Edit007.Name = "Edit007"
        Me.Edit007.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit007.Size = New System.Drawing.Size(444, 20)
        Me.Edit007.TabIndex = 8
        Me.Edit007.Text = "����������������������������������������"
        Me.Edit007.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit006
        '
        Me.Edit006.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit006.HighlightText = True
        Me.Edit006.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit006.LengthAsByte = True
        Me.Edit006.Location = New System.Drawing.Point(116, 152)
        Me.Edit006.MaxLength = 40
        Me.Edit006.Name = "Edit006"
        Me.Edit006.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit006.Size = New System.Drawing.Size(444, 20)
        Me.Edit006.TabIndex = 7
        Me.Edit006.Text = "����������������������������������������"
        Me.Edit006.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Mask1
        '
        Me.Mask1.Format = New GrapeCity.Win.Input.Interop.MaskFormat("�� \D{3}-\D{4}", "", "")
        Me.Mask1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Mask1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Mask1.Location = New System.Drawing.Point(116, 128)
        Me.Mask1.Name = "Mask1"
        Me.Mask1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Mask1.Size = New System.Drawing.Size(88, 20)
        Me.Mask1.TabIndex = 5
        Me.Mask1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Mask1.Value = ""
        '
        'Label006
        '
        Me.Label006.BackColor = System.Drawing.Color.Navy
        Me.Label006.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label006.ForeColor = System.Drawing.Color.White
        Me.Label006.Location = New System.Drawing.Point(280, 200)
        Me.Label006.Name = "Label006"
        Me.Label006.Size = New System.Drawing.Size(124, 20)
        Me.Label006.TabIndex = 1265
        Me.Label006.Text = "�e�`�w"
        Me.Label006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label005
        '
        Me.Label005.BackColor = System.Drawing.Color.Navy
        Me.Label005.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label005.ForeColor = System.Drawing.Color.White
        Me.Label005.Location = New System.Drawing.Point(20, 200)
        Me.Label005.Name = "Label005"
        Me.Label005.Size = New System.Drawing.Size(96, 20)
        Me.Label005.TabIndex = 1264
        Me.Label005.Text = "�d�b�ԍ�"
        Me.Label005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BackColor = System.Drawing.Color.Navy
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.ForeColor = System.Drawing.Color.White
        Me.Label004.Location = New System.Drawing.Point(20, 128)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(96, 68)
        Me.Label004.TabIndex = 1263
        Me.Label004.Text = "������Z��"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(20, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 20)
        Me.Label10.TabIndex = 1267
        Me.Label10.Text = "������"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit010
        '
        Me.Edit010.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Edit010.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit010.HighlightText = True
        Me.Edit010.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit010.LengthAsByte = True
        Me.Edit010.Location = New System.Drawing.Point(116, 104)
        Me.Edit010.MaxLength = 50
        Me.Edit010.Name = "Edit010"
        Me.Edit010.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit010.Size = New System.Drawing.Size(444, 20)
        Me.Edit010.TabIndex = 4
        Me.Edit010.Text = "��������������������"
        Me.Edit010.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'CL007
        '
        Me.CL007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL007.Location = New System.Drawing.Point(628, 224)
        Me.CL007.Name = "CL007"
        Me.CL007.Size = New System.Drawing.Size(56, 16)
        Me.CL007.TabIndex = 1290
        Me.CL007.Text = "CL007"
        Me.CL007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL007.Visible = False
        '
        'Combo007
        '
        Me.Combo007.AutoSelect = True
        'Me.Combo007.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
        Me.Combo007.Location = New System.Drawing.Point(404, 224)
        Me.Combo007.MaxDropDownItems = 20
        Me.Combo007.Name = "Combo007"
        Me.Combo007.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo007.Size = New System.Drawing.Size(156, 20)
        Me.Combo007.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo007.TabIndex = 12
        Me.Combo007.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo007.Value = "Combo007"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Navy
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(280, 224)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 1289
        Me.Label15.Text = "�������ו\�p�^�[��"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL006
        '
        Me.CL006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL006.Location = New System.Drawing.Point(564, 224)
        Me.CL006.Name = "CL006"
        Me.CL006.Size = New System.Drawing.Size(56, 16)
        Me.CL006.TabIndex = 1288
        Me.CL006.Text = "CL006"
        Me.CL006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL006.Visible = False
        '
        'Combo006
        '
        Me.Combo006.AutoSelect = True
        'Me.Combo006.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.Field
        Me.Combo006.Location = New System.Drawing.Point(116, 224)
        Me.Combo006.MaxDropDownItems = 20
        Me.Combo006.Name = "Combo006"
        Me.Combo006.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo006.Size = New System.Drawing.Size(156, 20)
        Me.Combo006.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo006.TabIndex = 11
        Me.Combo006.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo006.Value = "Combo006"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(20, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 20)
        Me.Label14.TabIndex = 1287
        Me.Label14.Text = "�������p�^�[��"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F50_Form04_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(990, 688)
        Me.Controls.Add(Me.CL007)
        Me.Controls.Add(Me.Combo007)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CL006)
        Me.Controls.Add(Me.Combo006)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Edit010)
        Me.Controls.Add(Me.Button_S5)
        Me.Controls.Add(Me.Edit009)
        Me.Controls.Add(Me.Edit008)
        Me.Controls.Add(Me.Edit007)
        Me.Controls.Add(Me.Edit006)
        Me.Controls.Add(Me.Mask1)
        Me.Controls.Add(Me.Label006)
        Me.Controls.Add(Me.Label005)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CL001_name)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CheckBox003)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Edit005)
        Me.Controls.Add(Me.DataGridEx2)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.CheckBox002)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Edit004)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Edit002)
        Me.Controls.Add(Me.CheckBox001)
        Me.Controls.Add(Me.Label001)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form04_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���[�J�[�}�X�^"
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit004, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit005, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit009, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit008, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit006, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit010, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo007, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo006, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F50_Form04_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        ACES()      '**  �����`�F�b�N
        CmbSet()    '**  �R���{�{�b�N�X�Z�b�g
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='504'", "", DataViewRowState.CurrentRows)
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
    '**  �R���{�{�b�N�X�Z�b�g
    '********************************************************************
    Sub CmbSet()
        'DB_OPEN("QGCare")

        ''QG�̃��[�J�[
        'strSQL = "SELECT ���[�J�[ AS vndr_code, ���[�J�[�� AS vndr_name FROM M_���[�J�[ ORDER BY vndr_code"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(DsCMB, "QG_VNDR")

        'Combo001.DataSource = DsCMB.Tables("QG_VNDR")
        'Combo001.DisplayMember = "vndr_name"
        'Combo001.ValueMember = "vndr_code"

        'DB_CLOSE()
        DB_OPEN("nMVAR")

        '���Ϗ��p�^�[��
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '016') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_016")

        Combo002.DataSource = DsCMB.Tables("CLS_CODE_016")
        Combo002.DisplayMember = "cls_code_name"
        Combo002.ValueMember = "cls_code"

        '�������p�^�[��
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '033') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_033")

        Combo006.DataSource = DsCMB.Tables("CLS_CODE_033")
        Combo006.DisplayMember = "cls_code_name"
        Combo006.ValueMember = "cls_code"

        '�������ו\�p�^�[��
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '034') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_034")

        Combo007.DataSource = DsCMB.Tables("CLS_CODE_034")
        Combo007.DisplayMember = "cls_code_name"
        Combo007.ValueMember = "cls_code"

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  ��ʃZ�b�g
    '********************************************************************
    Sub DspSet()
        If P_PRAM1 = Nothing Then   '�V�K
            Button1.Text = "�o�^"
            Button80.Enabled = False
            Edit001.Text = Nothing
            Edit002.Text = Nothing
            Edit003.Text = Nothing
            Edit004.Text = Nothing
            Edit005.Text = Nothing
            Edit006.Text = Nothing
            Edit007.Text = Nothing
            Edit008.Text = Nothing
            Edit009.Text = Nothing
            Edit010.Text = Nothing
            'Combo001.Text = Nothing
            Combo002.Text = Nothing
            Combo006.Text = Nothing
            Combo007.Text = Nothing
            Mask1.Text = Nothing

            CheckBox001.Checked = False
            CheckBox002.Checked = False
            CheckBox003.Checked = False
            Label001.Text = Nothing

        Else                        '�C��
            Button1.Text = "�X�V"
            Button80.Enabled = True
            Edit001.Enabled = False
            DsList1.Clear()

            SqlCmd1 = New SqlClient.SqlCommand("sp_M05_VNDR_2", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
            Pram1.Value = P_PRAM1
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "M05_VNDR")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)

            Edit001.Text = DtView1(0)("vndr_code")
            Edit002.Text = DtView1(0)("name")
            Edit003.Text = DtView1(0)("name_en")
            Edit004.Text = DtView1(0)("name_kana")
            Edit005.Text = DtView1(0)("rcpt_up2")

            If Not IsDBNull(DtView1(0)("zip")) Then Mask1.Value = DtView1(0)("zip") Else Mask1.Text = Nothing
            If Not IsDBNull(DtView1(0)("adrs1")) Then Edit006.Text = DtView1(0)("adrs1") Else Edit006.Text = Nothing
            If Not IsDBNull(DtView1(0)("adrs2")) Then Edit007.Text = DtView1(0)("adrs2") Else Edit007.Text = Nothing
            If Not IsDBNull(DtView1(0)("tel")) Then Edit008.Text = DtView1(0)("tel") Else Edit008.Text = Nothing
            If Not IsDBNull(DtView1(0)("fax")) Then Edit009.Text = DtView1(0)("fax") Else Edit009.Text = Nothing
            If Not IsDBNull(DtView1(0)("name_invc")) Then Edit010.Text = DtView1(0)("name_invc") Else Edit010.Text = Nothing

            If DtView1(0)("atri_flg") = "1" Then
                CheckBox002.Checked = True
            Else
                CheckBox002.Checked = False
            End If
            If DtView1(0)("ncr_flg") = "1" Then
                CheckBox003.Checked = True
            Else
                CheckBox003.Checked = False
            End If
            If DtView1(0)("delt_flg") = "1" Then
                CheckBox001.Checked = True
            Else
                CheckBox001.Checked = False
            End If

            'If Not IsDBNull(DtView1(0)("qg_vndr_link")) Then
            '    WK_DtView1 = New DataView(DsCMB.Tables("QG_VNDR"), "vndr_code = " & DtView1(0)("qg_vndr_link"), "", DataViewRowState.CurrentRows)
            '    Combo001.Text = WK_DtView1(0)("vndr_name")
            '    CL001.Text = DtView1(0)("qg_vndr_link")
            '    CL001_name.Text = WK_DtView1(0)("vndr_name")
            'Else
            '    Combo001.Text = Nothing
            '    CL001.Text = Nothing
            '    CL001_name.Text = Nothing
            'End If

            If Not IsDBNull(DtView1(0)("part_amnt_q_ptn_name")) Then Combo002.Text = DtView1(0)("part_amnt_q_ptn_name") Else Combo002.Text = Nothing
            If Not IsDBNull(DtView1(0)("part_amnt_q_ptn")) Then CL002.Text = DtView1(0)("part_amnt_q_ptn") Else CL002.Text = Nothing

            If Not IsDBNull(DtView1(0)("invc_rprt_ptn_name")) Then Combo006.Text = DtView1(0)("invc_rprt_ptn_name") Else Combo006.Text = Nothing
            If Not IsDBNull(DtView1(0)("invc_rprt_ptn")) Then CL006.Text = DtView1(0)("invc_rprt_ptn") Else CL006.Text = Nothing

            If Not IsDBNull(DtView1(0)("invc_dtl_ptn_name")) Then Combo007.Text = DtView1(0)("invc_dtl_ptn_name") Else Combo007.Text = Nothing
            If Not IsDBNull(DtView1(0)("invc_dtl_ptn")) Then CL007.Text = DtView1(0)("invc_dtl_ptn") Else CL007.Text = Nothing

            Label001.Text = DtView1(0)("reg_date")
        End If

        '�Z�p���}�X�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_M30_TECH_AMNT", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        If P_PRAM1 = Nothing Then   '�V�K
            Pram2.Value = ""
        Else
            Pram2.Value = P_PRAM1
        End If
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M30_TECH_AMNT")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M30_TECH_AMNT")
        DataGridEx1.DataSource = tbl

        DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "", "", DataViewRowState.CurrentRows)
        If DtView2.Count <> 0 Then
            For i = 0 To DtView2.Count - 1
                If IsDBNull(DtView2(i)("sumi")) Then
                    DtView2(i)("sumi") = ""
                Else
                    DtView2(i)("sumi") = "��"
                End If
            Next
        End If

        '���i�|���}�X�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_M31_PART_RATE", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M31_PART_RATE")
        DB_CLOSE()

        Dim tbl2 As New DataTable
        tbl2 = DsList1.Tables("M31_PART_RATE")
        DataGridEx2.DataSource = tbl2

        DtView3 = New DataView(DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
        If DtView3.Count <> 0 Then
            For i = 0 To DtView3.Count - 1

                WK_DsList1.Clear()
                strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & DtView3(i)("store_code") & "') AND (vndr_code = '" & P_PRAM1 & "') AND (strt_amnt = 1))"
                strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    DtView3(i)("sumi") = "��"
                Else
                    DtView3(i)("sumi") = ""
                End If
            Next
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�F
    '********************************************************************
    Private Sub DataGridEx1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�G���^�[
    '********************************************************************
    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView2.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    If P_PRAM1 = Nothing Then   '�V�K
                        Dim ANS As String
                        ANS = MessageBox.Show("���[�J�[�}�X�^�̓o�^���s���܂��B", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        If ANS = "1" Then   'OK
                            F_Check()   '**  ���ڃ`�F�b�N
                            If Err_F = "0" Then
                                Add_VNDR()
                                Cursor = System.Windows.Forms.Cursors.WaitCursor
                                P_PRAM2 = DataGridEx1(DataGridEx1.CurrentRowIndex, 1)
                                P_PRAM3 = Edit001.Text
                                Dim F50_Form50 As New F50_Form50
                                F50_Form50.ShowDialog()
                                If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                                    WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "store_code ='" & P_PRAM2 & "'", "", DataViewRowState.CurrentRows)
                                    If WK_DtView2.Count <> 0 Then
                                        WK_DtView2(0)("sumi") = "��"
                                    End If
                                End If
                                Cursor = System.Windows.Forms.Cursors.Default
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        Cursor = System.Windows.Forms.Cursors.WaitCursor
                        P_PRAM2 = DataGridEx1(DataGridEx1.CurrentRowIndex, 1)
                        P_PRAM3 = Edit001.Text
                        Dim F50_Form50 As New F50_Form50
                        F50_Form50.ShowDialog()
                        If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                            WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "store_code ='" & P_PRAM2 & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView2.Count <> 0 Then
                                WK_DtView2(0)("sumi") = "��"
                            End If
                        End If
                        Cursor = System.Windows.Forms.Cursors.Default
                    End If
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�N���b�N
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                If P_PRAM1 = Nothing Then   '�V�K
                    Dim ANS As String
                    ANS = MessageBox.Show("���[�J�[�}�X�^�̓o�^���s���܂��B", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If ANS = "1" Then   'OK
                        F_Check()   '**  ���ڃ`�F�b�N
                        If Err_F = "0" Then
                            Add_VNDR()
                            Cursor = System.Windows.Forms.Cursors.WaitCursor
                            P_PRAM2 = DataGridEx1(DataGridEx1.CurrentRowIndex, 1)
                            P_PRAM3 = Edit001.Text
                            Dim F50_Form50 As New F50_Form50
                            F50_Form50.ShowDialog()
                            If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                                WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "store_code ='" & P_PRAM2 & "'", "", DataViewRowState.CurrentRows)
                                If WK_DtView2.Count <> 0 Then
                                    WK_DtView2(0)("sumi") = "��"
                                End If
                            End If
                            Cursor = System.Windows.Forms.Cursors.Default
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    P_PRAM2 = DataGridEx1(DataGridEx1.CurrentRowIndex, 1)
                    P_PRAM3 = Edit001.Text
                    Dim F50_Form50 As New F50_Form50
                    F50_Form50.ShowDialog()
                    If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                        WK_DtView2 = New DataView(DsList1.Tables("M30_TECH_AMNT"), "store_code ='" & P_PRAM2 & "'", "", DataViewRowState.CurrentRows)
                        If WK_DtView2.Count <> 0 Then
                            WK_DtView2(0)("sumi") = "��"
                        End If
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�F
    '********************************************************************
    Private Sub DataGridEx2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx2.Paint
        If DataGridEx2.CurrentRowIndex >= 0 Then
            DataGridEx2.Select(DataGridEx2.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�G���^�[
    '********************************************************************
    Private Sub DataGridEx2_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx2.CmdKeyEvent
        If DataGridEx2.CurrentRowIndex <= DtView3.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    If P_PRAM1 = Nothing Then   '�V�K
                        Dim ANS As String
                        ANS = MessageBox.Show("���[�J�[�}�X�^�̓o�^���s���܂��B", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        If ANS = "1" Then   'OK
                            F_Check()   '**  ���ڃ`�F�b�N
                            If Err_F = "0" Then
                                Add_VNDR()
                                Cursor = System.Windows.Forms.Cursors.WaitCursor
                                P_PRAM2 = DataGridEx2(DataGridEx2.CurrentRowIndex, 1)
                                P_PRAM3 = Edit001.Text
                                Dim F50_Form51 As New F50_Form51
                                F50_Form51.ShowDialog()
                                If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                                    WK_DsList1.Clear()
                                    strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                                    strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                                    strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                                    strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                                    strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                                    strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                                    strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                                    strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    DaList1.SelectCommand = SqlCmd1
                                    DB_OPEN("nMVAR")
                                    SqlCmd1.CommandTimeout = 600
                                    DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                                    DB_CLOSE()

                                    WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                                    If WK_DtView1.Count = 0 Then
                                        DataGridEx2(DataGridEx2.CurrentRowIndex, 3) = "��"
                                    End If
                                End If
                                Cursor = System.Windows.Forms.Cursors.Default
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        Cursor = System.Windows.Forms.Cursors.WaitCursor
                        P_PRAM2 = DataGridEx2(DataGridEx2.CurrentRowIndex, 1)
                        P_PRAM3 = Edit001.Text
                        Dim F50_Form51 As New F50_Form51
                        F50_Form51.ShowDialog()
                        If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                            WK_DsList1.Clear()
                            strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                            strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                            strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                            strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                            strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                            strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                            strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                            strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("nMVAR")
                            SqlCmd1.CommandTimeout = 600
                            DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                            DB_CLOSE()

                            WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count = 0 Then
                                DataGridEx2(DataGridEx2.CurrentRowIndex, 3) = "��"
                            End If
                        End If
                        Cursor = System.Windows.Forms.Cursors.Default
                    End If
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�N���b�N
    '********************************************************************
    Private Sub DataGridEx2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx2.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                If P_PRAM1 = Nothing Then   '�V�K
                    Dim ANS As String
                    ANS = MessageBox.Show("���[�J�[�}�X�^�̓o�^���s���܂��B", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If ANS = "1" Then   'OK
                        F_Check()   '**  ���ڃ`�F�b�N
                        If Err_F = "0" Then
                            Add_VNDR()
                            Cursor = System.Windows.Forms.Cursors.WaitCursor
                            P_PRAM2 = DataGridEx2(DataGridEx2.CurrentRowIndex, 1)
                            P_PRAM3 = Edit001.Text
                            Dim F50_Form51 As New F50_Form51
                            F50_Form51.ShowDialog()
                            If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                                WK_DsList1.Clear()
                                strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                                strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                                strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                                strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                                strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                                strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                                strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                                strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("nMVAR")
                                SqlCmd1.CommandTimeout = 600
                                DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                                DB_CLOSE()

                                WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                                If WK_DtView1.Count = 0 Then
                                    DataGridEx2(DataGridEx2.CurrentRowIndex, 3) = "��"
                                End If
                            End If
                            Cursor = System.Windows.Forms.Cursors.Default
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    P_PRAM2 = DataGridEx2(DataGridEx2.CurrentRowIndex, 1)
                    P_PRAM3 = Edit001.Text
                    Dim F50_Form51 As New F50_Form51
                    F50_Form51.ShowDialog()
                    If P_RTN2 = "1" Then '**  ��ʃZ�b�g
                        WK_DsList1.Clear()
                        strSQL = "SELECT main.*, M31_PART_RATE.store_code AS sumi"
                        strSQL +=  " FROM (SELECT cls011.cls_code AS pc_cls, cls011.cls_code_name AS pc_cls_name"
                        strSQL +=  ", cls012.cls_code AS own_cls, cls012.cls_code_name AS own_cls_name"
                        strSQL +=  " FROM (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '011') AND (delt_flg = 0)) cls011 CROSS JOIN"
                        strSQL +=  " (SELECT cls_code, cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '012') AND (delt_flg = 0)) cls012) main LEFT OUTER JOIN"
                        strSQL +=  " (SELECT * FROM M31_PART_RATE WHERE (store_code = '" & P_PRAM2 & "') AND (vndr_code = '" & P_PRAM3 & "') AND (strt_amnt = 1))"
                        strSQL +=  " M31_PART_RATE ON main.pc_cls = M31_PART_RATE.note_kbn AND main.own_cls = M31_PART_RATE.own_rpat_kbn"
                        strSQL +=  " WHERE (M31_PART_RATE.store_code IS NULL)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(WK_DsList1, "M31_PART_RATE")
                        DB_CLOSE()

                        WK_DtView1 = New DataView(WK_DsList1.Tables("M31_PART_RATE"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count = 0 Then
                            DataGridEx2(DataGridEx2.CurrentRowIndex, 3) = "��"
                        End If
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  ���ڃ`�F�b�N
    '********************************************************************
    Sub CHK_Edit001()   '���[�J�[�R�[�h
        msg.Text = Nothing

        Edit001.Text = Trim(Edit001.Text)
        If Edit001.Text = Nothing Then
            Edit001.BackColor = System.Drawing.Color.Red
            msg.Text = "���[�J�[�R�[�h�����͂���Ă��܂���B"
            Exit Sub
        Else
            If Len(Edit001.Text) <> 2 Then
                Edit001.BackColor = System.Drawing.Color.Red
                msg.Text = "���[�J�[�R�[�h��2���œ��͂��Ă��������B"
                Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT vndr_code"
                strSQL +=  " FROM M05_VNDR"
                strSQL +=  " WHERE (vndr_code = '" & Edit001.Text & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "M05_VNDR")
                DB_CLOSE()

                WK_DtView1 = New DataView(WK_DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Edit001.BackColor = System.Drawing.Color.Red
                    msg.Text = "���[�J�[�R�[�h�����ɓo�^����Ă��܂��B"
                    Exit Sub
                End If
            End If
        End If
        Edit001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit002()   '���O
        msg.Text = Nothing

        Edit002.Text = Trim(Edit002.Text)
        If Edit002.Text = Nothing Then
            Edit002.BackColor = System.Drawing.Color.Red
            msg.Text = "���O�����͂���Ă��܂���B"
            Exit Sub
        End If
        Edit002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit003()   '�p��
        msg.Text = Nothing

        Edit003.Text = Trim(Edit003.Text)
        If Edit003.Text = Nothing Then
            Edit003.BackColor = System.Drawing.Color.Red
            msg.Text = "�p�������͂���Ă��܂���B"
            Exit Sub
        End If
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit004()   '�J�i
        msg.Text = Nothing

        Edit004.Text = Trim(Edit004.Text)
        If Edit004.Text = Nothing Then
            Edit004.BackColor = System.Drawing.Color.Red
            msg.Text = "�J�i�����͂���Ă��܂���B"
            Exit Sub
        End If
        Edit004.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit010()   '������
        msg.Text = Nothing

        Edit010.Text = Trim(Edit010.Text)
        If Edit010.Text = Nothing Then
            Edit010.BackColor = System.Drawing.Color.Red
            msg.Text = "�����������͂���Ă��܂���B"
            Exit Sub
        End If
        Edit010.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit005()   '��t�ԍ���2��
        msg.Text = Nothing

        Edit005.Text = Trim(Edit005.Text)
        If Edit005.Text = Nothing Then
            Edit005.BackColor = System.Drawing.Color.Red
            msg.Text = "��t�ԍ���2�������͂���Ă��܂���B"
            Exit Sub
        Else
            If Len(Edit005.Text) <> 2 Then
                Edit005.BackColor = System.Drawing.Color.Red
                msg.Text = "��t�ԍ���2����2���œ��͂��Ă��������B"
                Exit Sub
            Else
                'WK_DsList1.Clear()
                'strSQL = "SELECT vndr_code"
                'strSQL +=  " FROM M05_VNDR"
                'strSQL +=  " WHERE (rcpt_up2 = '" & Edit005.Text & "')"
                'If P_PRAM1 <> Nothing Then   '�ύX
                '    strSQL +=  " AND (vndr_code <> '" & Edit001.Text & "')"
                'End If
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'DaList1.SelectCommand = SqlCmd1
                'DB_OPEN("nMVAR")
                'SqlCmd1.CommandTimeout = 600
                'DaList1.Fill(WK_DsList1, "M05_VNDR")
                'DB_CLOSE()

                'WK_DtView1 = New DataView(WK_DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)
                'If WK_DtView1.Count <> 0 Then
                '    Edit005.BackColor = System.Drawing.Color.Red
                '    msg.Text = "��t�ԍ���2�������ɓo�^����Ă��܂��B"
                '    Exit Sub
                'End If
            End If
        End If
        Edit005.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit006()   '�Z��1
        msg.Text = Nothing

        Edit006.Text = Trim(Edit006.Text)
        If Edit006.Text = Nothing Then
            Edit006.BackColor = System.Drawing.Color.Red
            msg.Text = "�Z��1�����͂���Ă��܂���B"
            Exit Sub
        End If
        Edit006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit007()   '�Z��2
        msg.Text = Nothing

        Edit007.Text = Trim(Edit007.Text)
        'If Edit007.Text = Nothing Then
        '    Edit007.BackColor = System.Drawing.Color.Red
        '    msg.Text = "�Z��2�����͂���Ă��܂���B"
        '    Exit Sub
        'End If
        Edit007.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit008()   '�d�b�ԍ�
        msg.Text = Nothing

        Edit008.Text = Trim(Edit008.Text)
        'If Edit008.Text = Nothing Then
        '    Edit008.BackColor = System.Drawing.Color.Red
        '    msg.Text = "�d�b�ԍ������͂���Ă��܂���B"
        '    Exit Sub
        'End If
        Edit008.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Edit009()   'fax
        msg.Text = Nothing

        Edit009.Text = Trim(Edit009.Text)
        'If Edit009.Text = Nothing Then
        '    Edit009.BackColor = System.Drawing.Color.Red
        '    msg.Text = "FAX�����͂���Ă��܂���B"
        '    Exit Sub
        'End If
        Edit009.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Mask1()     '�X�֔ԍ�
        msg.Text = Nothing

        If Mask1.Visible = True Then
            If Mask1.Value = Nothing Then
            Else
                If Len(Mask1.Value) <> 7 Then
                    Mask1.BackColor = System.Drawing.Color.Red
                    msg.Text = "�X�֔ԍ���7�����͂��Ă��������B"
                    Exit Sub
                End If
            End If
        Else
            Mask1.Value = Nothing
        End If
        Mask1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    'Sub CHK_Combo001()   'QG Care��Ұ��
    '    msg.Text = Nothing
    '    CL001.Text = Nothing

    '    Combo001.Text = Trim(Combo001.Text)
    '    If Combo001.Text = Nothing Then
    '        'Combo001.BackColor = System.Drawing.Color.Red
    '        'msg.Text = "QG Care��Ұ�����ނ����͂���Ă��܂���B"
    '        'Exit Sub
    '    Else
    '        DtView1 = New DataView(DsCMB.Tables("QG_VNDR"), "vndr_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
    '        If DtView1.Count = 0 Then
    '            Combo001.BackColor = System.Drawing.Color.Red
    '            msg.Text = "�Y������QG Care��Ұ��������܂���B"
    '            Exit Sub
    '        Else
    '            CL001.Text = DtView1(0)("vndr_code")
    '        End If
    '    End If
    '    Combo001.BackColor = System.Drawing.SystemColors.Window
    'End Sub
    Sub CHK_Combo002()   '���i���i�⍇���[�p�^�[��
        msg.Text = Nothing
        CL002.Text = Nothing

        Combo002.Text = Trim(Combo002.Text)
        If Combo002.Text = Nothing Then
            'Combo002.BackColor = System.Drawing.Color.Red
            'msg.Text = "���i���i�⍇���[�p�^�[�������͂���Ă��܂���B"
            'Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_016"), "cls_code_name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo002.BackColor = System.Drawing.Color.Red
                msg.Text = "�Y�����镔�i���i�⍇���[�p�^�[��������܂���B"
                Exit Sub
            Else
                CL002.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo002.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo006()   '�������p�^�[��
        msg.Text = Nothing

        Combo006.Text = Trim(Combo006.Text)
        If Combo006.Text = Nothing Then
            Combo006.BackColor = System.Drawing.Color.Red
            msg.Text = "�������p�^�[�������͂���Ă��܂���B"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_033"), "cls_code_name = '" & Combo006.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo006.BackColor = System.Drawing.Color.Red
                msg.Text = "�Y�����鐿�����p�^�[��������܂���B"
                Exit Sub
            Else
                CL006.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo006.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_Combo007()   '�������ו\�p�^�[��
        msg.Text = Nothing

        Combo007.Text = Trim(Combo007.Text)
        If Combo007.Text = Nothing Then
            Combo007.BackColor = System.Drawing.Color.Red
            msg.Text = "�������ו\�p�^�[�������͂���Ă��܂���B"
            Exit Sub
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_034"), "cls_code_name = '" & Combo007.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo007.BackColor = System.Drawing.Color.Red
                msg.Text = "�Y�����鐿�����ו\�p�^�[��������܂���B"
                Exit Sub
            Else
                CL007.Text = DtView1(0)("cls_code")
            End If
        End If
        Combo007.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub F_Check()
        Err_F = "0"

        If P_PRAM1 = Nothing Then   '�V�K
            CHK_Edit001() '���[�J�[�R�[�h
            If msg.Text <> Nothing Then Err_F = "1" : Edit001.Focus() : Exit Sub
        End If

        CHK_Edit002() '���O
        If msg.Text <> Nothing Then Err_F = "1" : Edit002.Focus() : Exit Sub

        CHK_Edit003() '�p��
        If msg.Text <> Nothing Then Err_F = "1" : Edit003.Focus() : Exit Sub

        CHK_Edit004() '�J�i
        If msg.Text <> Nothing Then Err_F = "1" : Edit004.Focus() : Exit Sub

        CHK_Edit010() '������
        If msg.Text <> Nothing Then Err_F = "1" : Edit010.Focus() : Exit Sub

        CHK_Edit005()   '��t�ԍ���2��
        If msg.Text <> Nothing Then Err_F = "1" : Edit005.Focus() : Exit Sub

        CHK_Mask1()     '�X�֔ԍ�
        If msg.Text <> Nothing Then Err_F = "1" : Mask1.Focus() : Exit Sub

        CHK_Edit006()   '�Z��1
        If msg.Text <> Nothing Then Err_F = "1" : Edit006.Focus() : Exit Sub

        CHK_Edit007()   '�Z��2
        If msg.Text <> Nothing Then Err_F = "1" : Edit007.Focus() : Exit Sub

        CHK_Edit008()   '�d�b�ԍ�
        If msg.Text <> Nothing Then Err_F = "1" : Edit008.Focus() : Exit Sub

        CHK_Edit009()   'FAX
        If msg.Text <> Nothing Then Err_F = "1" : Edit009.Focus() : Exit Sub

        'CHK_Combo001()   'QG Care��Ұ������
        'If msg.Text <> Nothing Then Err_F = "1" : Combo001.Focus() : Exit Sub

        CHK_Combo002()   '���i���i�⍇���[�p�^�[��
        If msg.Text <> Nothing Then Err_F = "1" : Combo002.Focus() : Exit Sub

        CHK_Combo006()  '�������p�^�[��
        If msg.Text <> Nothing Then Err_F = "1" : Combo006.Focus() : Exit Sub

        CHK_Combo007()  '�������ו\�p�^�[��
        If msg.Text <> Nothing Then Err_F = "1" : Combo007.Focus() : Exit Sub
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.GotFocus
        Edit002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit004_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.GotFocus
        Edit004.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit005_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.GotFocus
        Edit005.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.GotFocus
        Edit006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.GotFocus
        Edit007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit008_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.GotFocus
        Edit008.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit009_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit009.GotFocus
        Edit009.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit010_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit010.GotFocus
        Edit010.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    'Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
    '    Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    'End Sub
    Private Sub Combo002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.GotFocus
        Combo002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo006_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo006.GotFocus
        Combo006.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Combo007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo007.GotFocus
        Combo007.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.GotFocus
        CheckBox001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox002_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.GotFocus
        CheckBox002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CheckBox003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox003.GotFocus
        CheckBox003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Mask1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.GotFocus
        Mask1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        CHK_Edit001()   '���[�J�[�R�[�h
    End Sub
    Private Sub Edit002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit002.LostFocus
        CHK_Edit002()   '���O
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        CHK_Edit003()   '�p��
    End Sub
    Private Sub Edit004_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit004.LostFocus
        CHK_Edit004()   '�J�i
    End Sub
    Private Sub Edit005_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit005.LostFocus
        CHK_Edit005()   '��t�ԍ���2��
    End Sub
    Private Sub Edit006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit006.LostFocus
        CHK_Edit006()   '�Z��1
    End Sub
    Private Sub Edit007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit007.LostFocus
        CHK_Edit007()   '�Z��2
    End Sub
    Private Sub Edit008_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit008.LostFocus
        CHK_Edit008()   '�d�b�ԍ�
    End Sub
    Private Sub Edit009_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit009.LostFocus
        CHK_Edit009()   'FAX
    End Sub
    Private Sub Edit010_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit010.LostFocus
        CHK_Edit010()   '������
    End Sub
    'Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
    '    CHK_Combo001()   'QG Care��Ұ��
    'End Sub
    Private Sub Combo002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.LostFocus
        CHK_Combo002()   '���i���i�⍇���[�p�^�[��
    End Sub
    Private Sub Combo006_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo006.LostFocus
        CHK_Combo006()   '�������p�^�[��
    End Sub
    Private Sub Combo007_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo007.LostFocus
        CHK_Combo007()   '�������ו\�p�^�[��
    End Sub
    Private Sub CheckBox001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox001.LostFocus
        CheckBox001.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox002_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox002.LostFocus
        CheckBox002.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox003.LostFocus
        CheckBox003.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Mask1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mask1.LostFocus
        CHK_Mask1()   '�X�֔ԍ�
    End Sub

    '********************************************************************
    '**  �ӂ肪�Ȏ����擾
    '********************************************************************
    'Private Sub Furigana_ResultString(ByVal sender As Object, ByVal e As GrapeCity.Win.Input.Interop.ResultStringEventArgs) Handles Furigana.ResultString
    '    ' �擾�����ӂ肪�Ȃ�\�����܂��B
    '    Edit004.Text += e.ReadString
    'End Sub

    '********************************************************************
    '**  �ύX����
    '********************************************************************
    Sub CHG_HSTY()
        DtView1 = New DataView(DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)

        If Edit002.Text <> DtView1(0)("name") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "���[�J�[��", DtView1(0)("name"), Edit002.Text)
        End If

        If Edit003.Text <> DtView1(0)("name_en") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�p��", DtView1(0)("name_en"), Edit003.Text)
        End If

        If Edit004.Text <> DtView1(0)("name_kana") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�J�i", DtView1(0)("name_kana"), Edit004.Text)
        End If

        If Not IsDBNull(DtView1(0)("name_invc")) Then WK_str2 = DtView1(0)("name_invc") Else WK_str2 = Nothing
        If Edit010.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "������", WK_str2, Edit010.Text)
        End If

        If Edit005.Text <> DtView1(0)("rcpt_up2") Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "��t�ԍ���2��", DtView1(0)("rcpt_up2"), Edit005.Text)
        End If

        If Not IsDBNull(DtView1(0)("zip")) Then WK_str = Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) Else WK_str = Nothing
        If WK_str = "-" Then WK_str = Nothing
        If Mask1.Value <> Nothing Then WK_str2 = Mid(Mask1.Text, 3, 8) Else WK_str2 = Nothing
        If WK_str2 <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�X�֔ԍ�", WK_str, WK_str2)
        End If

        If Not IsDBNull(DtView1(0)("adrs1")) Then WK_str2 = DtView1(0)("adrs1") Else WK_str2 = Nothing
        If Edit006.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�Z��1", WK_str2, Edit006.Text)
        End If

        If Not IsDBNull(DtView1(0)("adrs2")) Then WK_str2 = DtView1(0)("adrs2") Else WK_str2 = Nothing
        If Edit007.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�Z��2", WK_str2, Edit007.Text)
        End If

        If Not IsDBNull(DtView1(0)("tel")) Then WK_str2 = DtView1(0)("tel") Else WK_str2 = Nothing
        If Edit008.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�d�b�ԍ�", WK_str2, Edit008.Text)
        End If

        If Not IsDBNull(DtView1(0)("fax")) Then WK_str2 = DtView1(0)("fax") Else WK_str2 = Nothing
        If Edit009.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "FAX", WK_str2, Edit009.Text)
        End If

        If DtView1(0)("atri_flg") = "1" Then
            If CheckBox002.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�F��", "�Ώ�", "�ΏۊO")
            End If
        Else
            If CheckBox002.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�F��", "�ΏۊO", "�Ώ�")
            End If
        End If

        If DtView1(0)("ncr_flg") = "1" Then
            If CheckBox003.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "NCR����", "�Ώ�", "�ΏۊO")
            End If
        Else
            If CheckBox003.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "NCR����", "�ΏۊO", "�Ώ�")
            End If
        End If

        'If Combo001.Text <> CL001_name.Text Then
        '    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "QG Care��Ұ��", CL001_name.Text, Combo001.Text)
        'End If

        If Not IsDBNull(DtView1(0)("part_amnt_q_ptn_name")) Then WK_str2 = DtView1(0)("part_amnt_q_ptn_name") Else WK_str2 = Nothing
        If Combo002.Text <> WK_str2 Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "���i���i�⍇���[�p�^�[��", WK_str2, Combo002.Text)
        End If

        If Not IsDBNull(DtView1(0)("invc_rprt_ptn_name")) Then WK_str = DtView1(0)("invc_rprt_ptn_name") Else WK_str = Nothing
        If Combo006.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�������p�^�[��", WK_str, Combo006.Text)
        End If

        If Not IsDBNull(DtView1(0)("invc_dtl_ptn_name")) Then WK_str = DtView1(0)("invc_dtl_ptn_name") Else WK_str = Nothing
        If Combo007.Text <> WK_str Then
            chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�������ו\�p�^�[��", WK_str, Combo007.Text)
        End If

        If DtView1(0)("delt_flg") = "1" Then
            If CheckBox001.Checked = False Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�폜�t���O", "�폜", "")
            End If
        Else
            If CheckBox001.Checked = True Then
                chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Edit001.Text, "�폜�t���O", "", "�폜")
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
            If P_PRAM1 = Nothing Then   '�V�K
                Add_VNDR()
                qg_VNDR()
                msg.Text = "�o�^���܂����B"
                P_RTN = "1"
                P_PRAM1 = Edit001.Text
                DspSet()    '**  ��ʃZ�b�g
            Else                        '�C��

                CHG_HSTY()  '**  �ύX����
                If chg_itm <> 0 Then
                    '���[�J�[�}�X�^
                    strSQL = "UPDATE M05_VNDR"
                    strSQL +=  " SET name = '" & Edit002.Text & "'"
                    strSQL +=  ", name_en = '" & Edit003.Text & "'"
                    strSQL +=  ", name_kana = '" & Edit004.Text & "'"
                    strSQL +=  ", name_invc = '" & Edit010.Text & "'"
                    strSQL +=  ", rcpt_up2 = '" & Edit005.Text & "'"
                    strSQL +=  ", zip = '" & Mask1.Value & "'"
                    strSQL +=  ", adrs1 = '" & Edit006.Text & "'"
                    strSQL +=  ", adrs2 = '" & Edit007.Text & "'"
                    strSQL +=  ", tel = '" & Edit008.Text & "'"
                    strSQL +=  ", fax = '" & Edit009.Text & "'"
                    strSQL +=  ", invc_rprt_ptn = '" & CL006.Text & "'"
                    strSQL +=  ", invc_dtl_ptn = '" & CL007.Text & "'"
                    'If CL001.Text <> Nothing Then strSQL +=  ", qg_vndr_link = " & CL001.Text Else strSQL +=  ", qg_vndr_link = NULL"
                    If CL002.Text <> Nothing Then strSQL +=  ", part_amnt_q_ptn = '" & CL002.Text & "'" Else strSQL +=  ", part_amnt_q_ptn = NULL"
                    If CheckBox002.Checked = True Then strSQL +=  ", atri_flg = 1" Else strSQL +=  ", atri_flg = 0"
                    If CheckBox003.Checked = True Then strSQL +=  ", ncr_flg = 1" Else strSQL +=  ", ncr_flg = 0"
                    If CheckBox001.Checked = True Then strSQL +=  ", delt_flg = 1" Else strSQL +=  ", delt_flg = 0"
                    strSQL +=  " WHERE (vndr_code = '" & P_PRAM1 & "')"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()

                    qg_VNDR()
                End If

                If chg_itm = 0 Then
                    msg.Text = "�ύX�ӏ�������܂���B"
                Else
                    msg.Text = "�X�V���܂����B"
                    DspSet()    '**  ��ʃZ�b�g
                End If
                P_RTN = "1"
            End If
            'Button98_Click(sender, e)
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub Add_VNDR()
        Label001.Text = Now.Date

        '���[�J�[�}�X�^
        strSQL = "INSERT INTO M05_VNDR"
        'strSQL +=  " (vndr_code, name, name_en, name_kana, name_invc, zip, adrs1, adrs2, tel, fax, invc_rprt_ptn, invc_dtl_ptn, atri_flg, ncr_flg, rcpt_up2, qg_vndr_link, part_amnt_q_ptn, reg_date, delt_flg)"
        strSQL +=  " (vndr_code, name, name_en, name_kana, name_invc, zip, adrs1, adrs2, tel, fax, invc_rprt_ptn, invc_dtl_ptn, atri_flg, ncr_flg, rcpt_up2, part_amnt_q_ptn, reg_date, delt_flg)"
        strSQL +=  " VALUES ('" & Edit001.Text & "'"
        strSQL +=  ", '" & Edit002.Text & "'"
        strSQL +=  ", '" & Edit003.Text & "'"
        strSQL +=  ", '" & Edit004.Text & "'"
        strSQL +=  ", '" & Edit010.Text & "'"
        strSQL +=  ", '" & Mask1.Value & "'"
        strSQL +=  ", '" & Edit006.Text & "'"
        strSQL +=  ", '" & Edit007.Text & "'"
        strSQL +=  ", '" & Edit008.Text & "'"
        strSQL +=  ", '" & Edit009.Text & "'"
        strSQL +=  ", '" & CL006.Text & "'"
        strSQL +=  ", '" & CL007.Text & "'"
        If CheckBox002.Checked = True Then strSQL +=  ", 1" Else strSQL +=  ", 0"
        If CheckBox003.Checked = True Then strSQL +=  ", 1" Else strSQL +=  ", 0"
        strSQL +=  ", '" & Edit005.Text & "'"
        'If CL001.Text <> Nothing Then strSQL +=  ", " & CL001.Text Else strSQL +=  ", NULL"
        If CL002.Text <> Nothing Then strSQL +=  ", '" & CL002.Text & "'" Else strSQL +=  ", NULL"
        strSQL +=  ", '" & CDate(Label001.Text) & "'"
        If CheckBox001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
        strSQL += ")"
        DB_OPEN("nMVAR")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        add_MTR_hsty(M_CLS, Edit001.Text, "�V�K�o�^", "", "")
    End Sub

    Sub qg_VNDR()
        DB_OPEN("QGCare")

        'QG�̃��[�J�[
        WK_DsList1.Clear()
        strSQL = "SELECT * FROM M05_VNDR WHERE (vndr_code = '" & Edit001.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(WK_DsList1, "QG_VNDR")

        If r = 0 Then
            strSQL = "INSERT INTO M05_VNDR"
            strSQL +=  " (vndr_code, name, delt_flg)"
            strSQL +=  " VALUES ('" & Edit001.Text & "'"
            strSQL +=  ", '" & Edit002.Text & "'"
            If CheckBox001.Checked = True Then strSQL += ", 1" Else strSQL += ", 0"
            strSQL += ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        Else
            strSQL = "UPDATE M05_VNDR"
            strSQL +=  " SET name = '" & Edit002.Text & "'"
            If CheckBox001.Checked = True Then strSQL +=  ", delt_flg = 1" Else strSQL +=  ", delt_flg = 0"
            strSQL +=  " WHERE (vndr_code = '" & Edit001.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

        End If

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  �Z�p��CSV�o��
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'DataTable�쐬()
        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F50_04_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Pram1.Value = Edit001.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "CSV")
        DB_CLOSE()

        WK_DtView1 = New DataView(WK_DsList1.Tables("CSV"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "�Z�p���}�X�^.CSV"                       '�͂��߂̃t�@�C�������w�肷��
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
                waitDlg.ProgressMax = WK_DtView1.Count  ' �S�̂̏���������ݒ�
                waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

                '�f�[�^����������
                strData = "���[�J�[��,�̎Ж���,QG Care,���,�C�����,��Փx,�Z�p����"
                strData = strData & ",�L�����Z����(�v��),�L�����Z����(����),��z1,��z2,�폜�t���O"
                swFile.WriteLine(strData)

                For i = 0 To WK_DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / WK_DtView1.Count) & "%�@�i" & i + 1 & " / " & WK_DtView1.Count & " ���j"
                    waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / WK_DtView1.Count) & "%"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = WK_DtView1(i)("vndr_name")
                    strData = strData & "," & WK_DtView1(i)("store_name")
                    strData = strData & "," & WK_DtView1(i)("qgcare_name")
                    If WK_DtView1(i)("vndr_code") = "01" Then
                        strData = strData & "," & WK_DtView1(i)("note_name2")
                    Else
                        strData = strData & "," & WK_DtView1(i)("note_name")
                    End If
                    strData = strData & "," & WK_DtView1(i)("own_rpat_name")
                    strData = strData & "," & WK_DtView1(i)("tier_name")
                    strData = strData & "," & WK_DtView1(i)("tech_amnt")
                    strData = strData & "," & WK_DtView1(i)("cxl_amnt")
                    strData = strData & "," & WK_DtView1(i)("cxl_amnt2")
                    strData = strData & "," & WK_DtView1(i)("fix_amnt")
                    strData = strData & "," & WK_DtView1(i)("fix_amnt2")
                    If WK_DtView1(i)("delt_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"

                    swFile.WriteLine(strData)
                Next
                swFile.Close()          '�t�@�C�������
                MessageBox.Show("�o�͂��܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            End If
        End If
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ���i�|��CSV�o��
    '********************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'DataTable�쐬()
        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F50_04_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Pram1.Value = Edit001.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "CSV")
        DB_CLOSE()

        WK_DtView1 = New DataView(WK_DsList1.Tables("CSV"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialog�N���X�̃C���X�^���X���쐬
            sfd.FileName = "���i�|���}�X�^.CSV"                     '�͂��߂̃t�@�C�������w�肷��
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
                waitDlg.ProgressMax = WK_DtView1.Count  ' �S�̂̏���������ݒ�
                waitDlg.ProgressValue = 0       ' �ŏ��̌�����ݒ�
                Application.DoEvents()          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

                Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     '�t�@�C���̖����Ɉړ�����

                '�f�[�^����������
                strData = "���[�J�[��,�̎Ж���,���,�C�����,���z�J�n,���z�I��,���v��,�����z,�폜�t���O"
                swFile.WriteLine(strData)

                For i = 0 To WK_DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / WK_DtView1.Count) & "%�@�i" & i + 1 & " / " & WK_DtView1.Count & " ���j"
                    waitDlg.Text = "���s���E�E�E" & Fix((i + 1) * 100 / WK_DtView1.Count) & "%"
                    Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                    waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                    strData = WK_DtView1(i)("vndr_name")
                    strData = strData & "," & WK_DtView1(i)("store_name")
                    If WK_DtView1(i)("vndr_code") = "01" Then
                        strData = strData & "," & WK_DtView1(i)("note_name2")
                    Else
                        strData = strData & "," & WK_DtView1(i)("note_name")
                    End If
                    strData = strData & "," & WK_DtView1(i)("own_rpat_name")
                    strData = strData & "," & WK_DtView1(i)("strt_amnt")
                    strData = strData & "," & WK_DtView1(i)("end_amnt")
                    strData = strData & "," & WK_DtView1(i)("part_rate")
                    strData = strData & "," & WK_DtView1(i)("part_amnt")
                    If WK_DtView1(i)("delt_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"

                    swFile.WriteLine(strData)
                Next
                swFile.Close()          '�t�@�C�������
                MessageBox.Show("�o�͂��܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                waitDlg.Close()         '�i�s�󋵃_�C�A���O�����
                Me.Enabled = True       '�I�[�i�[�̃t�H�[���𖳌��ɂ���
            End If
        End If
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
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
        Pram4.Value = P_PRAM1
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button_S5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_S5.Click
        '�X�֔ԍ�->�Z��
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_DsList1.Clear()
        strSQL = "SELECT adrs FROM M15_ZIP"
        strSQL +=  " WHERE (zip = '" & Mask1.Value & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(P_DsList1, "M15_ZIP")
        DB_CLOSE()

        Select Case r
            Case Is = 0
                msg.Text = "�Y���X�֔ԍ��Ȃ�"
                Mask1.Focus()
            Case Is = 1
                WK_DtView1 = New DataView(P_DsList1.Tables("M15_ZIP"), "", "", DataViewRowState.CurrentRows)
                Edit006.Text = Trim(WK_DtView1(0)("adrs"))
                Edit006.Focus()
            Case Else
                Dim F00_Form15 As New F00_Form15
                F00_Form15.ShowDialog()

                If P_RTN <> Nothing Then Edit006.Text = P_RTN : Edit006.Focus()
        End Select

        Cursor = System.Windows.Forms.Cursors.Default
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
