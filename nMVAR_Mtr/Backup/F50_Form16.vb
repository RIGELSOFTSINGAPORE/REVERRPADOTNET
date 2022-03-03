Public Class F50_Form16
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL As String

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F50_Form16))
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGrid1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.Button98 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "�V�K"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "seq"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Ұ������"
        Me.DataGridTextBoxColumn2.MappingName = "vndr_code"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 90
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Ұ����"
        Me.DataGridTextBoxColumn3.MappingName = "vndr_name"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 200
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "����"
        Me.DataGridTextBoxColumn4.MappingName = "select_case"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 200
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "##,##0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "�Z�p��"
        Me.DataGridTextBoxColumn5.MappingName = "tech_amnt"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 90
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(20, 4)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(964, 636)
        Me.DataGrid1.TabIndex = 3
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridBoolColumn1})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "M14_VNDR_SUB"
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "�폜"
        Me.DataGridBoolColumn1.MappingName = "delt_flg"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.ReadOnly = True
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 50
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(912, 648)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 5
        Me.Button98.Text = "�߂�"
        '
        'F50_Form16
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form16"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ұ���ۏ؋Z�p��"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F05_Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Button1.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='516'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "3", "4"
                Button1.Enabled = True
        End Select
    End Sub

    '********************************************************************
    '**  ��ʃZ�b�g
    '********************************************************************
    Sub DspSet()
        DsList1.Clear()

        'Ұ���ۏ؋Z�p��
        SqlCmd1 = New SqlClient.SqlCommand("sp_M14_VNDR_SUB", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M14_VNDR_SUB")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M14_VNDR_SUB")
        DataGrid1.DataSource = tbl

        DtView1 = New DataView(DsList1.Tables("M14_VNDR_SUB"), "", "", DataViewRowState.CurrentRows)
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�F
    '********************************************************************
    Private Sub DataGrid1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
        If DataGrid1.CurrentRowIndex >= 0 Then
            DataGrid1.Select(DataGrid1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  �f�[�^�O���b�h�@�G���^�[
    '********************************************************************
    Private Sub DataGrid1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGrid1.CmdKeyEvent
        If DataGrid1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    P_PRAM1 = DataGrid1(DataGrid1.CurrentRowIndex, 0)
                    Dim F50_Form16_2 As New F50_Form16_2
                    F50_Form16_2.ShowDialog()

                    If P_RTN = "1" Then '**  ��ʃZ�b�g
                        WK_DsList1.Clear()
                        SqlCmd1 = New SqlClient.SqlCommand("sp_M14_VNDR_SUB_2", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 4)
                        Pram1.Value = P_PRAM1
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(WK_DsList1, "M14_VNDR_SUB")
                        DB_CLOSE()
                        WK_DtView1 = New DataView(WK_DsList1.Tables("M14_VNDR_SUB"), "", "", DataViewRowState.CurrentRows)

                        DtView1 = New DataView(DsList1.Tables("M14_VNDR_SUB"), "seq = " & P_PRAM1, "", DataViewRowState.CurrentRows)
                        DtView1(0)("vndr_code") = WK_DtView1(0)("vndr_code")
                        DtView1(0)("vndr_name") = WK_DtView1(0)("vndr_name")
                        DtView1(0)("select_case") = WK_DtView1(0)("select_case")
                        DtView1(0)("tech_amnt") = WK_DtView1(0)("tech_amnt")
                        DtView1(0)("delt_flg") = WK_DtView1(0)("delt_flg")
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
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
    Private Sub DataGrid1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                P_PRAM1 = DataGrid1(DataGrid1.CurrentRowIndex, 0)
                Dim F50_Form16_2 As New F50_Form16_2
                F50_Form16_2.ShowDialog()

                If P_RTN = "1" Then '**  ��ʃZ�b�g
                    WK_DsList1.Clear()
                    SqlCmd1 = New SqlClient.SqlCommand("sp_M14_VNDR_SUB_2", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 4)
                    Pram1.Value = P_PRAM1
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    SqlCmd1.CommandTimeout = 600
                    DaList1.Fill(WK_DsList1, "M14_VNDR_SUB")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M14_VNDR_SUB"), "", "", DataViewRowState.CurrentRows)

                    If WK_DtView1.Count <> 0 Then
                    End If

                    DtView1 = New DataView(DsList1.Tables("M14_VNDR_SUB"), "seq = " & P_PRAM1, "", DataViewRowState.CurrentRows)
                    DtView1(0)("vndr_code") = WK_DtView1(0)("vndr_code")
                    DtView1(0)("vndr_name") = WK_DtView1(0)("vndr_name")
                    DtView1(0)("select_case") = WK_DtView1(0)("select_case")
                    DtView1(0)("tech_amnt") = WK_DtView1(0)("tech_amnt")
                    DtView1(0)("delt_flg") = WK_DtView1(0)("delt_flg")
                End If
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  �V�K
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM1 = Nothing
        Dim F50_Form16_2 As New F50_Form16_2
        F50_Form16_2.ShowDialog()
        If P_RTN = "1" Then DspSet() '**  ��ʃZ�b�g
        Cursor = System.Windows.Forms.Cursors.Default
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
