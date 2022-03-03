Public Class F00_Form03
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim WK_DsList1 As New DataSet
    Dim WK_DtView1, WK_DtView2 As DataView

    Dim DtView1, DtView2 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F, tbl_name As String
    Dim i, en, Line_No1 As Integer
    Dim WK_SEQ, WK_ID As Integer

    '���i
    Private label(99, 1) As Label
    Private edit(99, 4) As GrapeCity.Win.Input.Interop.Edit
    Private nbrBox(99, 5) As GrapeCity.Win.Input.Interop.Number
    Private chkBox(99, 2) As CheckBox

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.msg = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 388)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(980, 20)
        Me.msg.TabIndex = 1235
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(920, 416)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 28)
        Me.Button98.TabIndex = 30
        Me.Button98.Text = "�߂�"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(16, 416)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 28)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "����"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(10, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(982, 336)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(916, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 32)
        Me.Label13.TabIndex = 1771
        Me.Label13.Text = "�݌Ɏg�p"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(760, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 32)
        Me.Label8.TabIndex = 1770
        Me.Label8.Text = "���󒍔�"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(652, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 32)
        Me.Label7.TabIndex = 1769
        Me.Label7.Text = "�����ԍ�"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(588, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 32)
        Me.Label6.TabIndex = 1768
        Me.Label6.Text = "EU��"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(524, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 32)
        Me.Label5.TabIndex = 1767
        Me.Label5.Text = "GSS    �v��"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(868, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 32)
        Me.Label4.TabIndex = 1766
        Me.Label4.Text = "IBM �ً}"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(480, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 32)
        Me.Label3.TabIndex = 1765
        Me.Label3.Text = "����"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(416, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 32)
        Me.Label2.TabIndex = 1764
        Me.Label2.Text = "�P��"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(188, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 32)
        Me.Label1.TabIndex = 1763
        Me.Label1.Text = "���i��"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 32)
        Me.Label9.TabIndex = 1762
        Me.Label9.Text = "���i�ԍ�"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F00_Form03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 452)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form03"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���i����"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F00_Form03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  ��������
        DspSet()    '** ��ʃZ�b�g
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()
        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        If P2_F00_Form03 = "1" Then   '����
            tbl_name = "T04_REP_PART"

            WK_DsList1.Clear()
            strSQL = "SELECT part_amnt_q_ptn FROM M05_VNDR WHERE (vndr_code = '" & P1_F00_Form03 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "M05_VNDR")
            DB_CLOSE()
            DtView1 = New DataView(WK_DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                If Not IsDBNull(DtView1(0)("part_amnt_q_ptn")) Then
                End If
            End If
        Else                        '����
            tbl_name = "T04_REP_PART_2"
        End If

        msg.Text = Nothing
        P_RTN = "0"
    End Sub

    '********************************************************************
    '**  ��ʃZ�b�g
    '********************************************************************
    Sub DspSet()

        '��_
        label(0, 0) = New Label
        label(0, 0).Location = New System.Drawing.Point(0, 0)
        label(0, 0).Size = New System.Drawing.Size(0, 0)
        label(0, 0).Text = Nothing
        Panel1.Controls.Add(label(0, 0))

        DtView1 = New DataView(P_DsList1.Tables(tbl_name), "", "seq", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For Line_No1 = 0 To DtView1.Count - 1
                add_line("1")    '�g�p���i
            Next
            Line_No1 = Line_No1 - 1
        Else
            Line_No1 = -1
        End If
        add_line("0")    '�g�p���i
    End Sub

    '���ϓ��e
    Sub add_line(ByVal flg)
        If flg = "0" Then Line_No1 = Line_No1 + 1

        '���i�R�[�h
        en = 1
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(0, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(176, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 20
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            edit(Line_No1, en).Text = DtView1(Line_No1)("part_code")
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit1_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit1_LostFocus

        '���i��
        en = 2
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(176, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(228, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 100
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            edit(Line_No1, en).Text = DtView1(Line_No1)("part_name")
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit2_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit2_LostFocus

        '�P��
        en = 1
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(404, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(64, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("part_amnt")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox1_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox1_LostFocus

        '����
        en = 2
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("#0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(468, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {99, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(44, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("use_qty")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox2_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox2_LostFocus

        'GSS�v��
        en = 4
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(512, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(64, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("shop_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("shop_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox4_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox4_LostFocus

        'EU��
        en = 5
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "Null")
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).ImeMode = ImeMode.Off
        nbrBox(Line_No1, en).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("###,###,##0", "", "", "-", "", "", "")
        nbrBox(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(576, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        nbrBox(Line_No1, en).MinValue = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(64, 25)
        nbrBox(Line_No1, en).HighlightText = True
        nbrBox(Line_No1, en).TabIndex = Line_No1
        nbrBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("eu_chrg")) Then
                nbrBox(Line_No1, en).Value = DtView1(Line_No1)("eu_chrg")
            Else
                nbrBox(Line_No1, en).Value = 0
            End If
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))
        AddHandler nbrBox(Line_No1, en).GotFocus, AddressOf nbrBox5_GotFocus
        AddHandler nbrBox(Line_No1, en).LostFocus, AddressOf nbrBox5_LostFocus

        '�����ԍ�
        en = 3
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(640, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(108, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 15
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("ordr_no")) Then
                edit(Line_No1, en).Text = DtView1(Line_No1)("ordr_no")
            Else
                edit(Line_No1, en).Text = Nothing
            End If
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit3_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit3_LostFocus

        '���󒍔�
        en = 4
        edit(Line_No1, en) = New GrapeCity.Win.Input.Interop.Edit
        edit(Line_No1, en).Location = New System.Drawing.Point(748, 25 * Line_No1 + label(0, 0).Location.Y)
        edit(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        edit(Line_No1, en).Size = New System.Drawing.Size(108, 25)
        edit(Line_No1, en).LengthAsByte = True
        edit(Line_No1, en).MaxLength = 15
        edit(Line_No1, en).DisabledForeColor = System.Drawing.SystemColors.WindowText
        edit(Line_No1, en).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        edit(Line_No1, en).HighlightText = True
        edit(Line_No1, en).TabIndex = Line_No1
        edit(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("ordr_no2")) Then
                edit(Line_No1, en).Text = DtView1(Line_No1)("ordr_no2")
            Else
                edit(Line_No1, en).Text = Nothing
            End If
        Else
            edit(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(edit(Line_No1, en))
        AddHandler edit(Line_No1, en).GotFocus, AddressOf edit4_GotFocus
        AddHandler edit(Line_No1, en).LostFocus, AddressOf edit4_LostFocus

        'IBM�ً}
        en = 2
        chkBox(Line_No1, en) = New CheckBox
        chkBox(Line_No1, en).Location = New System.Drawing.Point(856, 25 * Line_No1)
        chkBox(Line_No1, en).Size = New System.Drawing.Size(48, 25)
        chkBox(Line_No1, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No1, en).Text = Nothing
        chkBox(Line_No1, en).TabIndex = Line_No1
        chkBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("ibm_flg")) Then
                If DtView1(Line_No1)("ibm_flg") = "True" Then
                    chkBox(Line_No1, en).Checked = True
                Else
                    chkBox(Line_No1, en).Checked = False
                End If
            Else
                chkBox(Line_No1, en).Checked = False
            End If
        Else
            chkBox(Line_No1, en).Checked = False
        End If
        Panel1.Controls.Add(chkBox(Line_No1, en))
        AddHandler chkBox(Line_No1, en).GotFocus, AddressOf CHK2_GotFocus
        AddHandler chkBox(Line_No1, en).LostFocus, AddressOf CHK2_LostFocus

        '�݌Ɏg�p
        en = 1
        chkBox(Line_No1, en) = New CheckBox
        chkBox(Line_No1, en).Location = New System.Drawing.Point(904, 25 * Line_No1)
        chkBox(Line_No1, en).Size = New System.Drawing.Size(48, 25)
        chkBox(Line_No1, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No1, en).Text = Nothing
        chkBox(Line_No1, en).TabIndex = Line_No1
        chkBox(Line_No1, en).Tag = Line_No1
        If flg = "1" Then
            If Not IsDBNull(DtView1(Line_No1)("zaiko_flg")) Then
                If DtView1(Line_No1)("zaiko_flg") = "True" Then
                    chkBox(Line_No1, en).Checked = True
                Else
                    chkBox(Line_No1, en).Checked = False
                End If
            Else
                chkBox(Line_No1, en).Checked = False
            End If
        Else
            chkBox(Line_No1, en).Checked = False
        End If
        If P2_F00_Form03 = "1" Then   '����
            chkBox(Line_No1, en).Visible = False
        Else
            chkBox(Line_No1, en).Visible = True
        End If
        Panel1.Controls.Add(chkBox(Line_No1, en))
        AddHandler chkBox(Line_No1, en).GotFocus, AddressOf CHK_GotFocus
        AddHandler chkBox(Line_No1, en).LostFocus, AddressOf CHK_LostFocus

        'ID
        en = 3
        nbrBox(Line_No1, en) = New GrapeCity.Win.Input.Interop.Number
        nbrBox(Line_No1, en).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).EditMode = GrapeCity.Win.Input.Interop.EditMode.Overwrite
        nbrBox(Line_No1, en).Location = New System.Drawing.Point(952, 25 * Line_No1 + label(0, 0).Location.Y)
        nbrBox(Line_No1, en).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        nbrBox(Line_No1, en).Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        nbrBox(Line_No1, en).Size = New System.Drawing.Size(25, 25)
        nbrBox(Line_No1, en).Visible = False
        If flg = "1" Then
            nbrBox(Line_No1, en).Value = DtView1(Line_No1)("ID_NO")
        Else
            nbrBox(Line_No1, en).Value = 0
        End If
        Panel1.Controls.Add(nbrBox(Line_No1, en))

        'SEQ
        en = 1
        label(Line_No1, en) = New Label
        label(Line_No1, en).Location = New System.Drawing.Point(977, 25 * Line_No1 + label(0, 0).Location.Y)
        label(Line_No1, en).Size = New System.Drawing.Size(25, 25)
        label(Line_No1, en).Visible = False
        If flg = "1" Then
            label(Line_No1, en).Text = DtView1(Line_No1)("seq")
        Else
            label(Line_No1, en).Text = Nothing
        End If
        Panel1.Controls.Add(label(Line_No1, en))

    End Sub

    '********************************************************************
    '**  ���ڃ`�F�b�N
    '********************************************************************
    Sub CHK_edit1(ByVal seq As Integer, ByVal flg As String) '���i�R�[�h
        msg.Text = Nothing

        edit(seq, 1).Text = Trim(edit(seq, 1).Text)
        'If edit(seq, 1).Text <> Nothing _
        '    Or edit(seq, 2).Text <> Nothing _
        '    Or nbrBox(seq, 1).Value <> 0 _
        '    Or nbrBox(seq, 2).Value <> 0 Then
        '    If edit(seq, 1).Text = Nothing Then
        '        edit(seq, 1).BackColor = System.Drawing.Color.Red
        '        msg.Text = "���i�R�[�h�̓��͂�����܂���B"
        '        Exit Sub
        '    End If
        'End If
        If edit(seq, 1).Text <> Nothing Then
            WK_DsList1.Clear()
            strSQL = "SELECT part_code, part_name, stc_amnt, exc_amnt"
            strSQL = strSQL & " FROM M40_PART"
            strSQL = strSQL & " WHERE (vndr_code = '" & P1_F00_Form03 & "')"
            strSQL = strSQL & " GROUP BY part_code, part_name, stc_amnt, exc_amnt"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(WK_DsList1, "M40_PART")
            WK_DtView1 = New DataView(WK_DsList1.Tables("M40_PART"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count <> 0 Then
                WK_DtView1 = New DataView(WK_DsList1.Tables("M40_PART"), "part_code = '" & edit(seq, 1).Text & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    edit(seq, 2).Text = WK_DtView1(0)("part_name")

                    If P5_F00_Form03 <> "02" Then  '���[�J�[�ۏ؈ȊO
                        If flg = "1" Then
                            If WK_DtView1(0)("stc_amnt") <> 0 Then
                                If WK_DtView1(0)("exc_amnt") <> 0 Then
                                Else
                                    nbrBox(seq, 1).Value = WK_DtView1(0)("stc_amnt")
                                End If
                            Else
                                If WK_DtView1(0)("exc_amnt") <> 0 Then
                                    nbrBox(seq, 1).Value = WK_DtView1(0)("exc_amnt")
                                End If
                            End If
                        End If
                    End If
                    'Else
                    '    edit(seq, 2).Text = Nothing
                    '    edit(seq, 1).BackColor = System.Drawing.Color.Red
                    '    msg.Text = "���i�R�[�h���}�X�^�ɂ���܂���B"
                    '    Exit Sub
                End If
            End If
        End If
        edit(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_edit2(ByVal seq As Integer) '���i��
        msg.Text = Nothing

        edit(seq, 2).Text = Trim(edit(seq, 2).Text)
        If edit(seq, 1).Text <> Nothing _
            Or edit(seq, 2).Text <> Nothing _
            Or nbrBox(seq, 1).Value <> 0 _
            Or nbrBox(seq, 2).Value <> 0 Then
            If edit(seq, 2).Text = Nothing Then
                edit(seq, 2).BackColor = System.Drawing.Color.Red
                msg.Text = "���i���̓��͂�����܂���B"
                Exit Sub
            End If
        End If
        edit(seq, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_edit3(ByVal seq As Integer) '�����ԍ�
        msg.Text = Nothing

        edit(seq, 3).Text = Trim(edit(seq, 3).Text)
        'If edit(seq, 1).Text <> Nothing _
        '    Or edit(seq, 2).Text <> Nothing _
        '    Or nbrBox(seq, 1).Value <> 0 _
        '    Or nbrBox(seq, 2).Value <> 0 Then
        '    If edit(seq, 3).Text = Nothing Then
        '        edit(seq, 3).BackColor = System.Drawing.Color.Red
        '        msg.Text = "�����ԍ��̓��͂�����܂���B"
        '        Exit Sub
        '    End If
        'End If
        edit(seq, 3).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_edit4(ByVal seq As Integer) '���󒍔�
        msg.Text = Nothing

        edit(seq, 4).Text = Trim(edit(seq, 4).Text)
        'If edit(seq, 1).Text <> Nothing _
        '    Or edit(seq, 2).Text <> Nothing _
        '    Or nbrBox(seq, 1).Value <> 0 _
        '    Or nbrBox(seq, 2).Value <> 0 Then
        '    If edit(seq, 4).Text = Nothing Then
        '        edit(seq, 4).BackColor = System.Drawing.Color.Red
        '        msg.Text = "���󒍔Ԃ̓��͂�����܂���B"
        '        Exit Sub
        '    End If
        'End If
        edit(seq, 4).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox1(ByVal seq As Integer) '�P��
        msg.Text = Nothing

        'If edit(seq, 1).Text <> Nothing _
        '  Or edit(seq, 2).Text <> Nothing _
        '  Or nbrBox(seq, 1).Value <> 0 _
        '  Or nbrBox(seq, 2).Value <> 0 Then
        '    If nbrBox(seq, 1).Value = 0 Then
        '        nbrBox(seq, 1).BackColor = System.Drawing.Color.Red
        '        msg.Text = "�P���̓��͂�����܂���B"
        '        Exit Sub
        '    End If
        'End If
        nbrBox(seq, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox2(ByVal seq As Integer) '����
        msg.Text = Nothing

        If edit(seq, 1).Text <> Nothing _
           Or edit(seq, 2).Text <> Nothing _
           Or nbrBox(seq, 1).Value <> 0 _
           Or nbrBox(seq, 2).Value <> 0 Then
            If nbrBox(seq, 2).Value = 0 Then
                nbrBox(seq, 2).BackColor = System.Drawing.Color.Red
                msg.Text = "���ʂ̓��͂�����܂���B"
                Exit Sub
            End If
        End If
        nbrBox(seq, 2).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox4(ByVal seq As Integer) 'GSS�v��
        msg.Text = Nothing

        'If edit(seq, 1).Text <> Nothing _
        '  Or edit(seq, 2).Text <> Nothing _
        '  Or nbrBox(seq, 1).Value <> 0 _
        '  Or nbrBox(seq, 2).Value <> 0 Then
        '    If nbrBox(seq, 3).Value = 0 Then
        '        nbrBox(seq, 3).BackColor = System.Drawing.Color.Red
        '        msg.Text = "GSS�v��̓��͂�����܂���B"
        '        Exit Sub
        '    End If
        'End If
        nbrBox(seq, 4).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CHK_nbrBox5(ByVal seq As Integer) 'EU��
        msg.Text = Nothing

        'If edit(seq, 1).Text <> Nothing _
        '  Or edit(seq, 2).Text <> Nothing _
        '  Or nbrBox(seq, 1).Value <> 0 _
        '  Or nbrBox(seq, 2).Value <> 0 Then
        '    If nbrBox(seq, 4).Value = 0 Then
        '        nbrBox(seq, 4).BackColor = System.Drawing.Color.Red
        '        msg.Text = "EU���̓��͂�����܂���B"
        '        Exit Sub
        '    End If
        'End If
        nbrBox(seq, 5).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        For i = 0 To Line_No1

            CHK_edit1(i, "0") '���i�R�[�h
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 1).Focus() : Exit Sub

            CHK_edit2(i) '���i��
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 2).Focus() : Exit Sub

            CHK_nbrBox1(i) '�P��
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 1).Focus() : Exit Sub

            CHK_nbrBox2(i) '����
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 2).Focus() : Exit Sub

            CHK_nbrBox4(i) 'GSS�v��
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 4).Focus() : Exit Sub

            CHK_nbrBox5(i) 'EU��
            If msg.Text <> Nothing Then Err_F = "1" : nbrBox(i, 5).Focus() : Exit Sub

            CHK_edit3(i) '�����ԍ�
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 3).Focus() : Exit Sub

            CHK_edit4(i) '���󒍔�
            If msg.Text <> Nothing Then Err_F = "1" : edit(i, 4).Focus() : Exit Sub

        Next
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 3).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub edit4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        edit(Lin.Tag, 4).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 4).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub nbrBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        nbrBox(nbr.Tag, 5).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 2).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub CHK_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub edit1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit1(Lin.Tag, "1") '���i�R�[�h
    End Sub
    Private Sub edit2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit2(Lin.Tag) '���i��
    End Sub
    Private Sub edit3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit3(Lin.Tag) '�����ԍ�
    End Sub
    Private Sub edit4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Lin As GrapeCity.Win.Input.Interop.Edit
        Lin = DirectCast(sender, GrapeCity.Win.Input.Interop.Edit)
        CHK_edit4(Lin.Tag) '���󒍔�
        If P2_F00_Form03 = "1" Then   '����
            If Line_No1 = Lin.Tag Then
                If edit(Lin.Tag, 1).Text <> Nothing Then
                    add_line("0")    '�g�p���i
                    edit(Lin.Tag + 1, 1).Focus()
                End If
            End If
        End If
    End Sub
    Private Sub nbrBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox1(nbr.Tag) '�P��
    End Sub
    Private Sub nbrBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox2(nbr.Tag) '����
    End Sub
    Private Sub nbrBox4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox4(nbr.Tag) '�P��
    End Sub
    Private Sub nbrBox5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr As GrapeCity.Win.Input.Interop.Number
        nbr = DirectCast(sender, GrapeCity.Win.Input.Interop.Number)
        CHK_nbrBox5(nbr.Tag) '����
    End Sub
    Private Sub CHK2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 2).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CHK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        If P2_F00_Form03 = "2" Then   '����
            If Line_No1 = Lin.Tag Then
                If nbrBox(Lin.Tag, 2).Value <> 0 Then
                    add_line("0")    '�g�p���i
                    edit(Lin.Tag + 1, 1).Focus()
                End If
            End If
        End If
        chkBox(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Control
    End Sub

    '********************************************************************
    '** ����
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  ���ڃ`�F�b�N
        If Err_F = "0" Then
            upd()   'DS�X�V

            WK_DsList1.Clear()
            P_RTN = "1"
            Close()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub upd()   'DS�X�V
        For i = 0 To Line_No1

            If label(i, 1).Text = Nothing Then
                If nbrBox(i, 2).Value <> 0 Then
                    '�ǉ�
                    DtView2 = New DataView(P_DsList1.Tables(tbl_name), "", "seq DESC", DataViewRowState.CurrentRows)
                    If DtView2.Count = 0 Then
                        WK_SEQ = 1
                    Else
                        WK_SEQ = DtView2(0)("seq") + 1
                    End If
                    DtView2 = New DataView(P_DsList1.Tables(tbl_name), "", "ID_NO DESC", DataViewRowState.CurrentRows)
                    If DtView2.Count = 0 Then
                        WK_ID = 0
                    Else
                        WK_ID = DtView2(0)("ID_NO") + 1
                    End If

                    dttable = P_DsList1.Tables(tbl_name)
                    dtRow = dttable.NewRow
                    dtRow("part_code") = edit(i, 1).Text
                    dtRow("part_name") = edit(i, 2).Text
                    dtRow("part_amnt") = nbrBox(i, 1).Value
                    dtRow("use_qty") = nbrBox(i, 2).Value
                    dtRow("zaiko_flg") = chkBox(i, 1).Checked
                    dtRow("shop_chrg") = nbrBox(i, 4).Value
                    dtRow("eu_chrg") = nbrBox(i, 5).Value
                    dtRow("ordr_no") = edit(i, 3).Text
                    dtRow("ordr_no2") = edit(i, 4).Text
                    dtRow("ibm_flg") = chkBox(i, 2).Checked
                    dtRow("seq") = WK_SEQ
                    dtRow("ID_NO") = WK_ID
                    dttable.Rows.Add(dtRow)

                End If
            Else
                If nbrBox(i, 2).Value <> 0 Then
                    '�ύX
                    DtView2 = New DataView(P_DsList1.Tables(tbl_name), "seq =" & label(i, 1).Text, "", DataViewRowState.CurrentRows)
                    DtView2(0)("part_code") = edit(i, 1).Text
                    DtView2(0)("part_name") = edit(i, 2).Text
                    DtView2(0)("part_amnt") = nbrBox(i, 1).Value
                    DtView2(0)("use_qty") = nbrBox(i, 2).Value
                    DtView2(0)("zaiko_flg") = chkBox(i, 1).Checked
                    DtView2(0)("shop_chrg") = nbrBox(i, 4).Value
                    DtView2(0)("eu_chrg") = nbrBox(i, 5).Value
                    DtView2(0)("ordr_no") = edit(i, 3).Text
                    DtView2(0)("ordr_no2") = edit(i, 4).Text
                    DtView2(0)("ibm_flg") = chkBox(i, 2).Checked
                Else
                    '�폜
                    Dim myDataTable As DataTable
                    Dim myDataRowCollection As DataRowCollection
                    Dim myDataRow As DataRow
                    myDataTable = P_DsList1.Tables(tbl_name)
                    myDataRowCollection = myDataTable.Rows                      '�e�[�u���̍s�S�Ă��擾
                    myDataRow = myDataRowCollection.Item(nbrBox(i, 3).Value)    '�Ώۂ̍s���擾�@�C���f�b�N�X��0����
                    myDataRow.Delete()                                          '���@�s��RowState �� Added �̏ꍇ�́A�s���e�[�u������폜����܂��B
                    myDataRow = Nothing
                    myDataRowCollection = Nothing
                    myDataTable = Nothing
                End If
            End If

        Next
    End Sub

    '********************************************************************
    '**  �߂�
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
