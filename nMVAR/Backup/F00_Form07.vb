Public Class F00_Form07
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DsList1 As New DataSet
    Dim WK_DtView1 As DataView

    Dim strSQL, Err_F As String
    Dim i, en, Line_No, seq As Integer
    Dim WK_PRT As String
    Dim WK_str, WK_str2 As String

    Dim Wk_TAX As Integer
    Dim Wk_TAX_1, Wk_TAX_0 As Decimal

    Private chkBox(3, 1) As CheckBox
    Private label(3, 1) As label
    Private cmbBo(3, 1) As GrapeCity.Win.Input.Combo

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
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents okuri As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.msg = New System.Windows.Forms.Label
        Me.okuri = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(20, 184)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(84, 32)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "���"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(316, 184)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(80, 32)
        Me.Button98.TabIndex = 2
        Me.Button98.Text = "�߂�"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(20, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 128)
        Me.Panel1.TabIndex = 0
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 156)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(376, 24)
        Me.msg.TabIndex = 1346
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'okuri
        '
        Me.okuri.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.okuri.Location = New System.Drawing.Point(272, 8)
        Me.okuri.Name = "okuri"
        Me.okuri.Size = New System.Drawing.Size(48, 20)
        Me.okuri.TabIndex = 1799
        Me.okuri.Text = "okuri"
        Me.okuri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.okuri.Visible = False
        '
        'F00_Form07
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(418, 224)
        Me.ControlBox = False
        Me.Controls.Add(Me.okuri)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F00_Form07"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�������"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F00_Form07_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg.Text = Nothing
        DsSET()

        '����ŗ�
        Wk_TAX = tax_rate_get(Now) '����ŗ��擾
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0

        If P_PRAM3 = "0" Then sals_ADD()

        '�@�l�o�`
        Line_No = 0
        WK_PRT = Nothing

        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("dlvr_rprt_cls")
                Case Is = "1"
                    WK_PRT = "�l�o�`"
                Case Is = "2"
                    DtView2 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                    If DtView2(0)("rcpt_cls") = "02" And DtView2(0)("comp_shop_ttl") = 0 Then
                        WK_PRT = Nothing
                    Else
                        WK_PRT = "�`�F�[���X�g�A�`�["
                    End If
                Case Else
            End Select
        End If

        If Fuji_neva(P_PRAM1) = "0" Then
            WK_PRT = Nothing
        End If

        If WK_PRT <> Nothing Then
            '�Ώ�
            en = 1
            chkBox(Line_No, en) = New CheckBox
            chkBox(Line_No, en).Location = New System.Drawing.Point(4, 24 * Line_No)
            chkBox(Line_No, en).Size = New System.Drawing.Size(36, 24)
            chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
            chkBox(Line_No, en).Text = Nothing
            DtView2 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            If Not IsDBNull(DtView2(0)("sals_no")) Then
                chkBox(Line_No, en).Checked = False
                chkBox(Line_No, en).Enabled = False
            Else
                chkBox(Line_No, en).Checked = True
            End If
            chkBox(Line_No, en).Tag = Line_No
            Panel1.Controls.Add(chkBox(Line_No, en))
            AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
            AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

            '�����
            en = 1
            label(Line_No, en) = New Label
            label(Line_No, en).Location = New System.Drawing.Point(40, 24 * Line_No)
            label(Line_No, en).Size = New System.Drawing.Size(180, 24)
            label(Line_No, en).TextAlign = ContentAlignment.MiddleLeft
            label(Line_No, en).Text = WK_PRT
            Panel1.Controls.Add(label(Line_No, en))

            '����p�^�[��
            en = 0
            label(Line_No, en) = New Label
            label(Line_No, en).Location = New System.Drawing.Point(220, 24 * Line_No)
            label(Line_No, en).Size = New System.Drawing.Size(30, 24)
            label(Line_No, en).Text = DtView1(0)("dlvr_rprt_ptn")
            label(Line_No, en).Visible = False
            Panel1.Controls.Add(label(Line_No, en))
        Else
            '�Ώ�
            en = 1
            chkBox(Line_No, en) = New CheckBox
            chkBox(Line_No, en).Location = New System.Drawing.Point(4, 24 * Line_No)
            chkBox(Line_No, en).Size = New System.Drawing.Size(36, 24)
            chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
            chkBox(Line_No, en).Text = Nothing
            chkBox(Line_No, en).Checked = False
            chkBox(Line_No, en).Visible = False
            Panel1.Controls.Add(chkBox(Line_No, en))

            P_PRAM3 = Nothing
            'sals_ADD()
        End If

        '�A�����
        Line_No = 1
        '�Ώ�
        en = 1
        chkBox(Line_No, en) = New CheckBox
        chkBox(Line_No, en).Location = New System.Drawing.Point(4, 24 * Line_No)
        chkBox(Line_No, en).Size = New System.Drawing.Size(36, 24)
        chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
        chkBox(Line_No, en).Text = Nothing
        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("arvl_cls")
            Case Is = "03", "04"    '���׎���}��
                chkBox(Line_No, en).Checked = True
            Case Else
                chkBox(Line_No, en).Checked = False
        End Select
        chkBox(Line_No, en).Tag = Line_No
        Panel1.Controls.Add(chkBox(Line_No, en))
        AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
        AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

        '�����
        en = 1
        cmbBo(Line_No, en) = New GrapeCity.Win.Input.Combo
        cmbBo(Line_No, en).Location = New System.Drawing.Point(40, 24 * Line_No)
        cmbBo(Line_No, en).Size = New System.Drawing.Size(300, 24)
        cmbBo(Line_No, en).MaxDropDownItems = 20
        cmbBo(Line_No, en).AutoSelect = True
        cmbBo(Line_No, en).HighlightText = GrapeCity.Win.Input.HighlightText.Field
        cmbBo(Line_No, en).Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        cmbBo(Line_No, en).DataSource = DsCMB.Tables("CLS_CODE_020")
        cmbBo(Line_No, en).DisplayMember = "cls_code_name"
        cmbBo(Line_No, en).ValueMember = "cls_code"
        cmbBo(Line_No, en).Tag = Line_No
        Panel1.Controls.Add(cmbBo(Line_No, en))
        AddHandler cmbBo(Line_No, en).GotFocus, AddressOf cmb1_GotFocus
        AddHandler cmbBo(Line_No, en).LostFocus, AddressOf cmb1_LostFocus

        '�B�b�b�`�q
        Line_No = 2
        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '�Ώ�
            en = 1
            chkBox(Line_No, en) = New CheckBox
            chkBox(Line_No, en).Location = New System.Drawing.Point(4, 24 * Line_No)
            chkBox(Line_No, en).Size = New System.Drawing.Size(36, 24)
            chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
            chkBox(Line_No, en).Text = Nothing
            If DtView1(0)("ccar_flg") = "1" Then
                chkBox(Line_No, en).Checked = True
            Else
                chkBox(Line_No, en).Checked = False
            End If
            chkBox(Line_No, en).Tag = Line_No
            Panel1.Controls.Add(chkBox(Line_No, en))
            AddHandler chkBox(Line_No, en).GotFocus, AddressOf CHK_GotFocus
            AddHandler chkBox(Line_No, en).LostFocus, AddressOf CHK_LostFocus

            '�b�b�`�q
            en = 1
            label(Line_No, en) = New Label
            label(Line_No, en).Location = New System.Drawing.Point(40, 24 * Line_No)
            label(Line_No, en).Size = New System.Drawing.Size(180, 24)
            label(Line_No, en).TextAlign = ContentAlignment.MiddleLeft
            label(Line_No, en).Text = "�b�b�`�q"
            Panel1.Controls.Add(label(Line_No, en))

            ''�Ώ�
            'en = 1
            'chkBox(Line_No, en) = New CheckBox
            'chkBox(Line_No, en).Location = New System.Drawing.Point(4, 24 * Line_No)
            'chkBox(Line_No, en).Size = New System.Drawing.Size(36, 24)
            'chkBox(Line_No, en).CheckAlign = ContentAlignment.MiddleCenter
            'chkBox(Line_No, en).Text = Nothing
            'chkBox(Line_No, en).Checked = False
            'chkBox(Line_No, en).Visible = False
            'Panel1.Controls.Add(chkBox(Line_No, en))
        End If

    End Sub

    Sub DsSET()
        DsList1.Clear()
        DB_OPEN("nMVAR")

        strSQL = "SELECT T01_REP_MTR.*, M06_RPAR_COMP.own_flg"
        strSQL += " FROM T01_REP_MTR LEFT OUTER JOIN M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & P_PRAM1 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T01_REP_MTR")

        strSQL = "SELECT * FROM M08_STORE WHERE (store_code = '" & P_PRAM2 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "M08_STORE")

        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, cls_code_name_abbr"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '020') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_020")

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  ���ڃ`�F�b�N
    '********************************************************************
    Sub CHK_cmnt1() '�����
        msg.Text = Nothing

        cmbBo(1, 1).Text = Trim(cmbBo(1, 1).Text)
        If cmbBo(1, 1).Text = Nothing Then
            If chkBox(1, 1).Checked = True Then
                cmbBo(1, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "������I�����Ă��������B"
                Exit Sub
            End If
        Else
            DtView1 = New DataView(DsCMB.Tables("CLS_CODE_020"), "cls_code_name ='" & cmbBo(1, 1).Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                cmbBo(1, 1).BackColor = System.Drawing.Color.Red
                msg.Text = "�Y�����鑗��󂪂���܂���B"
                Exit Sub
            Else
                okuri.Text = DtView1(0)("cls_code")
            End If
        End If
        cmbBo(1, 1).BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub F_Check()
        Err_F = "0"

        CHK_cmnt1()   '�����
        If msg.Text <> Nothing Then Err_F = "1" : cmbBo(1, 1).Focus() : Exit Sub

        '�̏���e
        seq = 0
        For i = 0 To Line_No
            If chkBox(i, 1).Checked = True Then
                seq = seq + 1
            End If
        Next

        If seq = 0 Then
            chkBox(0, 1).BackColor = System.Drawing.Color.Red
            msg.Text = "����Ώۂ�����܂���B"
            Err_F = "1" : chkBox(0, 1).Focus() : Exit Sub
        End If

    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub CHK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CHK As CheckBox
        CHK = DirectCast(sender, CheckBox)
        chkBox(CHK.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub cmb1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        cmbBo(cmb.Tag, 1).BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub CHK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Lin As CheckBox
        Lin = DirectCast(sender, CheckBox)
        chkBox(Lin.Tag, 1).BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub cmb1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmb As GrapeCity.Win.Input.Combo
        cmb = DirectCast(sender, GrapeCity.Win.Input.Combo)
        CHK_cmnt1()  '�����
    End Sub

    '********************************************************************
    '**  ���
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()   '**  ���ڃ`�F�b�N
        If Err_F = "0" Then

            '�@�l�o�`
            P_PRAM3 = Nothing
            If chkBox(0, 1).Checked = True Then
                P_PRAM3 = "neva"
                If WK_PRT = "�l�o�`" Then
                    PRT_PRAM1 = "Print_R_NEVA" '�l�o�`���
                    PRT_PRAM2 = P_PRAM1
                    PRT_PRAM3 = label(0, 0).Text
                    Dim F70_Form02 As New F70_Form02
                    F70_Form02.ShowDialog()
                Else
                    PRT_PRAM1 = "Print_R_chain" '�`�F�[���`�[���
                    PRT_PRAM2 = P_PRAM1
                    PRT_PRAM3 = label(0, 0).Text
                    Dim F70_Form02 As New F70_Form02
                    F70_Form02.ShowDialog()
                End If
            End If

            '�A�����
            If chkBox(1, 1).Checked = True Then
                PRT_PRAM1 = "Print_R_Haiso" '�������
                PRT_PRAM2 = P_PRAM1
                PRT_PRAM3 = okuri.Text
                Dim F70_Form02 As New F70_Form02
                F70_Form02.ShowDialog()
            End If

            '�B�b�b�`�q
            If chkBox(2, 1).Checked = True Then
                PRT_PRAM1 = "Print_R_NCR_CCAR" '�b�b�`�q���
                PRT_PRAM2 = P_PRAM1
                Dim F70_Form02 As New F70_Form02
                F70_Form02.ShowDialog()
            End If

            If chkBox(0, 1).Checked = True Then
                Dim F00_Form07_2 As New F00_Form07_2
                F00_Form07_2.ShowDialog()

                If P_RTN = "1" Then
                    '�@�l�o�`
                    If chkBox(0, 1).Checked = True Then
                        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

                        If IsDBNull(DtView1(0)("sals_no")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("sals_no")
                        If P2_F00_Form07_2 <> WK_str2 Then
                            add_hsty(P_PRAM1, "�l�o�`�ԍ�", WK_str2, P2_F00_Form07_2)
                        End If

                        If IsDBNull(DtView1(0)("sals_no2")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("sals_no2")
                        If P3_F00_Form07_2 <> WK_str2 Then
                            add_hsty(P_PRAM1, "�l�o�`�ԍ�(��ްėp)", WK_str2, P3_F00_Form07_2)
                        End If

                        WK_str = Now.Date
                        If IsDBNull(DtView1(0)("sals_date")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("sals_date")
                        If WK_str <> WK_str2 Then
                            add_hsty(P_PRAM1, "�����", WK_str2, WK_str)
                        End If

                        WK_str = Now.Date
                        If IsDBNull(DtView1(0)("ship_date")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("ship_date")
                        If WK_str <> WK_str2 Then
                            add_hsty(P_PRAM1, "�o�ד�", WK_str2, WK_str)
                        End If

                        strSQL = "UPDATE T01_REP_MTR"
                        strSQL += " SET sals_date = '" & Now.Date & "'"
                        strSQL += ", sals_no = '" & P2_F00_Form07_2 & "'"
                        strSQL += ", sals_no2 = '" & P3_F00_Form07_2 & "'"
                        strSQL += ", neva_amnt = " & P4_F00_Form07_2
                        strSQL += ", ship_date = '" & Now.Date & "'"
                        strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                    Else
                        strSQL = "UPDATE T01_REP_MTR"
                        strSQL += " SET sals_date = '" & Now.Date & "'"
                        strSQL += ", neva_amnt = " & P4_F00_Form07_2
                        strSQL += ", ship_date = '" & Now.Date & "'"
                        strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()
                    End If

                    ''�A�����
                    'If chkBox(1, 1).Checked = True Then

                    'End If

                    ''�B�b�b�`�q
                    'If chkBox(2, 1).Checked = True Then

                    'End If

                End If
            End If
            Button98_Click(sender, e)

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub sals_ADD()
        Dim sals_F(5) As String '������f�[�^�L��t���O
        Dim amnt(5) As Integer  '�敪�i1:�̎� 2:�ی���� 3:���[�J�[ 4:��� 5:�x�m�ʕی��j

        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
        DtView2 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

        Select Case DtView2(0)("rpar_cls")
            Case Is = "02"      '���[�J�[�ۏ�
                If DtView2(0)("rcpt_cls") = "10" Then
                    If DtView2(0)("acdt_stts") = "03" Or DtView2(0)("acdt_stts") = "04" Then    '03:�j���E04:���G��
                        If exp_part(P_PRAM1) <> "2" Then  '���Օi����
                            i = 3 : sals_F(i) = "1" : amnt(i) = 4500
                            i = 5 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_tech_chrg") + P_Nexp_amt
                            i = 1 : sals_F(i) = "1" : amnt(i) = P_exp_amt
                        Else
                            i = 3 : sals_F(i) = "1" : amnt(i) = 4500
                            i = 5 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_tech_chrg") + P_Nexp_amt
                            i = 1 : sals_F(i) = "1" : amnt(i) = 0
                        End If
                    Else
                        If exp_part(P_PRAM1) <> "2" Then  '���Օi����
                            i = 3 : sals_F(i) = "1" : amnt(i) = 4500
                            i = 5 : sals_F(i) = "1" : amnt(i) = 0
                            i = 1 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_tech_chrg") + P_exp_amt
                        Else
                            i = 3 : sals_F(i) = "1" : amnt(i) = 4500
                            i = 5 : sals_F(i) = "1" : amnt(i) = 0
                            i = 1 : sals_F(i) = "1" : amnt(i) = 0
                        End If
                    End If
                Else
                    i = 3
                    sals_F(i) = "1"
                    amnt(i) = DtView2(0)("comp_shop_ttl")
                End If

            Case Is = "01"      '�L��
                If DtView1(0)("idvd_flg") = "True" Then   '���
                    i = 4
                    sals_F(i) = "1"
                    amnt(i) = DtView2(0)("comp_shop_ttl")
                Else
                    Select Case DtView2(0)("rcpt_cls")  '��t���
                        Case Is = "02"  'QG-Care
                            i = 2
                            sals_F(i) = "1"
                            amnt(i) = DtView2(0)("comp_shop_ttl")

                        Case Is = "03"  '�ۏ؏C��
                            i = 1
                            sals_F(i) = "1"
                            amnt(i) = DtView2(0)("comp_shop_ttl")

                        Case Is = "10"  '�x�m�ʕی�
                            If DtView2(0)("acdt_stts") = "01" Or DtView2(0)("acdt_stts") = "03" Or DtView2(0)("acdt_stts") = "04" Then    '01:�̏�E03:�j���E04:���G��
                                Select Case exp_part(P_PRAM1)
                                    Case Is = "1"   '���Օi�̂�
                                        i = 3 : sals_F(i) = "1" : amnt(i) = 0
                                        i = 5 : sals_F(i) = "1" : amnt(i) = 0
                                        i = 1 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_tech_chrg") + P_exp_amt

                                    Case Is = "2"   '���Օi�Ȃ�
                                        If RoundDOWN(DtView2(0)("wrn_limt_amnt") / Wk_TAX_1, 0) < DtView2(0)("comp_shop_ttl") - P_exp_amt Then '���x�I�[�o�[
                                            i = 3 : sals_F(i) = "1" : amnt(i) = 0
                                            i = 5 : sals_F(i) = "1" : amnt(i) = RoundDOWN(DtView2(0)("wrn_limt_amnt") / Wk_TAX_1, 0)
                                            i = 1 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_ttl") - RoundDOWN(DtView2(0)("wrn_limt_amnt") / Wk_TAX_1, 0)
                                        Else
                                            i = 3 : sals_F(i) = "1" : amnt(i) = 0
                                            i = 5 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_tech_chrg") + P_Nexp_amt
                                            i = 1 : sals_F(i) = "1" : amnt(i) = 0
                                        End If

                                    Case Is = "3"   '���Օi����
                                        If RoundDOWN(DtView2(0)("wrn_limt_amnt") / Wk_TAX_1, 0) < DtView2(0)("comp_shop_ttl") - P_exp_amt Then '���x�I�[�o�[
                                            i = 3 : sals_F(i) = "1" : amnt(i) = 0
                                            i = 5 : sals_F(i) = "1" : amnt(i) = RoundDOWN(DtView2(0)("wrn_limt_amnt") / Wk_TAX_1, 0)
                                            i = 1 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_ttl") - RoundDOWN(DtView2(0)("wrn_limt_amnt") / Wk_TAX_1, 0)
                                        Else
                                            i = 3 : sals_F(i) = "1" : amnt(i) = 0
                                            i = 5 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_tech_chrg") + P_Nexp_amt
                                            i = 1 : sals_F(i) = "1" : amnt(i) = P_exp_amt
                                        End If
                                End Select
                            Else

                                If exp_part(P_PRAM1) <> "2" Then  '���Օi����
                                    i = 3 : sals_F(i) = "1" : amnt(i) = 0
                                    i = 5 : sals_F(i) = "1" : amnt(i) = 0
                                    i = 1 : sals_F(i) = "1" : amnt(i) = DtView2(0)("comp_shop_tech_chrg") + P_exp_amt
                                Else
                                    i = 3 : sals_F(i) = "1" : amnt(i) = 0
                                    i = 5 : sals_F(i) = "1" : amnt(i) = 0
                                    i = 1 : sals_F(i) = "1" : amnt(i) = 0
                                End If
                            End If

                        Case Else       '�L���C��
                            i = 1
                            sals_F(i) = "1"

                            Select Case DtView1(0)("grup_code")
                                Case Is = "92", "93", "94", "95"
                                    amnt(i) = DtView2(0)("comp_shop_ttl")
                                Case Else
                                    If DtView2(0)("vndr_code") = "20" Then  'iOS
                                        amnt(i) = DtView2(0)("comp_shop_ttl")
                                    Else
                                        If DtView2(0)("vndr_code") = "01" And DtView2(0)("note_kbn2") = "01" Then 'Apple Note
                                            amnt(i) = DtView2(0)("comp_shop_ttl")
                                        Else

                                            If DtView1(0)("dlvr_rprt_cls") = "2" Then   '�`�F�[���X�g�A
                                                If DtView2(0)("comp_shop_ttl") < 35000 Then
                                                    amnt(i) = DtView2(0)("comp_shop_ttl") - Round(DtView2(0)("comp_shop_ttl") * 0.13, 0)
                                                Else
                                                    amnt(i) = DtView2(0)("comp_shop_ttl") - 4550
                                                End If
                                            Else
                                                amnt(i) = DtView2(0)("comp_shop_ttl")
                                            End If
                                        End If
                                    End If
                            End Select
                    End Select
                End If

        End Select

        DB_OPEN("nMVAR")
        'For i = 1 To 3
        '    If (i = 1 And amnt(i) = 0) Or (i = 3 And amnt(i) = 0) Then  '�̎Ђƃ��[�J�[������0������
        '    Else
        '    End If
        'Next

        strSQL = "DELETE T10_SALS"
        strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        For i = 1 To 5
            If sals_F(i) = "1" Then

                'WK_DsList1.Clear()
                'strSQL = "SELECT * FROM T10_SALS"
                'strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                'strSQL += " AND (cls = '" & i & "')"
                'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                'DaList1.SelectCommand = SqlCmd1
                'DaList1.Fill(WK_DsList1, "T10_SALS")
                'WK_DtView1 = New DataView(WK_DsList1.Tables("T10_SALS"), "", "", DataViewRowState.CurrentRows)

                Select Case i
                    Case Is = 1, 3 '�̎ЁA���[�J�[
                        If amnt(i) = 0 Then
                            'If WK_DtView1.Count = 0 Then    '�������Ȃ�
                            'Else                            '�폜
                            '    strSQL = "DELETE T10_SALS"
                            '    strSQL += " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                            '    strSQL += " AND (cls = '" & WK_DtView1(0)("cls") & "')"
                            '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            '    SqlCmd1.ExecuteNonQuery()
                            'End If
                        Else
                            strSQL = "INSERT INTO T10_SALS"
                            strSQL += " ( rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2, invc_flg)"
                            strSQL += " VALUES ('" & P_PRAM1 & "'"
                            strSQL += ", '" & i & "'"
                            strSQL += ", " & amnt(i)
                            strSQL += ", " & RoundDOWN(amnt(i) * Wk_TAX_0, 0)
                            strSQL += ", 0"
                            strSQL += ", 0"
                            strSQL += ", 0)"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                        End If

                    Case Is = 2 '�ی����
                        strSQL = "INSERT INTO T10_SALS"
                        strSQL += " ( rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2, invc_flg)"
                        strSQL += " VALUES ('" & P_PRAM1 & "'"
                        strSQL += ", '" & i & "'"
                        strSQL += ", " & amnt(i)
                        strSQL += ", " & RoundDOWN(amnt(i) * Wk_TAX_0, 0)
                        strSQL += ", 0"
                        strSQL += ", 0"
                        strSQL += ", 0)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                    Case Is = 5  '�x�m�ʕی�
                        If amnt(i) <> 0 Then
                            strSQL = "INSERT INTO T10_SALS"
                            strSQL += " ( rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2, invc_flg)"
                            strSQL += " VALUES ('" & P_PRAM1 & "'"
                            strSQL += ", '" & i & "'"
                            strSQL += ", " & amnt(i)
                            strSQL += ", " & RoundDOWN(amnt(i) * Wk_TAX_0, 0)
                            strSQL += ", 0"
                            strSQL += ", 0"
                            strSQL += ", 0)"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                        End If

                    Case Is = 4 '���
                        strSQL = "INSERT INTO T10_SALS"
                        strSQL += " ( rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2, invc_flg)"
                        strSQL += " VALUES ('" & P_PRAM1 & "'"
                        strSQL += ", '" & i & "'"
                        strSQL += ", " & amnt(i)
                        strSQL += ", " & RoundDOWN(amnt(i) * Wk_TAX_0, 0)
                        strSQL += ", 0"
                        strSQL += ", 0"
                        strSQL += ", 1)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                        '�����ڍ׃f�[�^�쐬
                        strSQL = "SELECT * FROM T21_INVC_SUB"
                        strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                        strSQL += " AND (i��vc_no = 0)"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(WK_DsList1, "T21_INVC_SUB")
                        WK_DtView1 = New DataView(WK_DsList1.Tables("T21_INVC_SUB"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count = 0 Then    '�ǉ�
                            strSQL = "INSERT INTO T21_INVC_SUB"
                            strSQL += " (i��vc_no, brch_code, rcpt_no, invc_amnt, cxl_flg, fin_flg)"
                            strSQL += " VALUES (0"
                            strSQL += ", '" & DtView2(0)("kjo_brch_code") & "'"
                            strSQL += ", '" & P_PRAM1 & "'"
                            strSQL += ", " & amnt(i) & ""
                            strSQL += ", 0, 0)"
                        Else
                            strSQL = "UPDATE T21_INVC_SUB"
                            strSQL += " SET invc_amnt = " & amnt(i) & ""
                            strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                            strSQL += " AND (i��vc_no = 0)"
                        End If
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                        '������
                        strSQL = "UPDATE T01_REP_MTR"
                        strSQL += " SET rqst_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                        strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                        DB_CLOSE()
                        Call QA_started_flg_ON(P_PRAM1)    'Q&A ����σt���O�X�V
                        DB_OPEN("nMVAR")

                End Select
            End If
        Next
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  �߂�
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub
End Class