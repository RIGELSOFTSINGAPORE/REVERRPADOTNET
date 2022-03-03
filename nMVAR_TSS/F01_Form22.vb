Public Class F01_Form22
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, WK_str As String
    Dim i, pos As Integer

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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.Interop.FunctionKey
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents f02 As System.Windows.Forms.Button
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridEx1 As nMVAR_TSS.DataGridEx
    Friend WithEvents DataGridTextBoxColumn33 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn34 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form22))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        ' Me.FunctionKey1 = New GrapeCity.Win.Input.Interop.FunctionKey
        Me.f12 = New System.Windows.Forms.Button
        Me.f02 = New System.Windows.Forms.Button
        Me.f01 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridEx1 = New nMVAR_TSS.DataGridEx
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn33 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn34 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "���ω񓚎�荞��"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FunctionKey1
        '
        'Me.FunctionKey1.ActiveKeySet = "Default"
        'Me.FunctionKey1.Location = New System.Drawing.Point(0, 654)
        'Me.FunctionKey1.Name = "FunctionKey1"
        'Me.FunctionKey1.Size = New System.Drawing.Size(986, 0)
        'Me.FunctionKey1.TabIndex = 19
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(884, 8)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 17
        Me.f12.Text = "F12:����"
        '
        'f02
        '
        Me.f02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f02.Enabled = False
        Me.f02.Location = New System.Drawing.Point(772, 8)
        Me.f02.Name = "f02"
        Me.f02.Size = New System.Drawing.Size(96, 32)
        Me.f02.TabIndex = 16
        Me.f02.Text = "F2:�o�^"
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Location = New System.Drawing.Point(660, 8)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 15
        Me.f01.Text = "F1:�捞��"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn33, Me.DataGridTextBoxColumn34, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "inpt"
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(972, 596)
        Me.DataGridEx1.TabIndex = 18
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "�敪"
        Me.DataGridTextBoxColumn1.MappingName = "F1"
        Me.DataGridTextBoxColumn1.Width = 40
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "ں��ދ敪"
        Me.DataGridTextBoxColumn2.MappingName = "F2"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "�ް����M��"
        Me.DataGridTextBoxColumn3.MappingName = "F3"
        Me.DataGridTextBoxColumn3.Width = 90
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "��Ôԍ�"
        Me.DataGridTextBoxColumn4.MappingName = "F4"
        Me.DataGridTextBoxColumn4.Width = 120
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "�C���Ǘ��ԍ�"
        Me.DataGridTextBoxColumn5.MappingName = "F5"
        Me.DataGridTextBoxColumn5.Width = 120
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "���ϋ敪"
        Me.DataGridTextBoxColumn6.MappingName = "F6"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "���v���z�i�ō��j"
        Me.DataGridTextBoxColumn7.MappingName = "F7"
        Me.DataGridTextBoxColumn7.Width = 120
        '
        'DataGridTextBoxColumn33
        '
        Me.DataGridTextBoxColumn33.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn33.Format = ""
        Me.DataGridTextBoxColumn33.FormatInfo = Nothing
        Me.DataGridTextBoxColumn33.HeaderText = "�񓚺���"
        Me.DataGridTextBoxColumn33.MappingName = "F8"
        Me.DataGridTextBoxColumn33.Width = 75
        '
        'DataGridTextBoxColumn34
        '
        Me.DataGridTextBoxColumn34.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn34.Format = ""
        Me.DataGridTextBoxColumn34.FormatInfo = Nothing
        Me.DataGridTextBoxColumn34.HeaderText = "���ω񓚓�"
        Me.DataGridTextBoxColumn34.MappingName = "F9"
        Me.DataGridTextBoxColumn34.Width = 90
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "���q�l��"
        Me.DataGridTextBoxColumn8.MappingName = "F10"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.Width = 120
        '
        'F01_Form22
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(986, 654)
        'Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.f02)
        Me.Controls.Add(Me.f01)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form22"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���ω񓚎�荞��"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F01_Form22_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()   '**  ��������
    End Sub

    '********************************************************************
    '**  ��������
    '********************************************************************
    Sub inz()

        '�~������g�p�s��
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        '�ް���د�ސݒ�
        DsList1.Clear()
        strSQL = "SELECT '' AS F1, '' AS F2, '' AS F3, '' AS F4, '' AS F5, '' AS F6, '' AS F7, '' AS F8, '' AS F9, '' AS F10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "inpt")
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("inpt")
        DataGridEx1.DataSource = tbl
        DsList1.Clear()

    End Sub

    '********************************************************************
    '**  �捞�݃{�^��
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click

        With OpenFileDialog1
            .CheckFileExists = True     '�t�@�C�������݂��邩�m�F
            .RestoreDirectory = True    '�f�B���N�g���̕���
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "CSV ̧��(*.csv)|*.csv"
            .FilterIndex = 0
            '�_�C�A���O�{�b�N�X��\�����A�m�J��]���N���b�N�����ꍇ
            If .ShowDialog = DialogResult.OK Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                Dim srFile As New System.IO.StreamReader(.FileName, System.Text.Encoding.Default)
                Dim strLine As String = srFile.ReadLine()
                DsList1.Clear()
                DB_OPEN("nMVAR")

                While Not strLine Is Nothing
                    WK_str = strLine

                    dttable = DsList1.Tables("inpt")
                    dtRow = dttable.NewRow

                    dtRow("F1") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F2") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F3") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F4") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F5") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F6") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F7") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F8") = Mid(WK_str, 2, WK_str.IndexOf(Chr(34) & "," & Chr(34)) - 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(Chr(34) & "," & Chr(34)) + 2)

                    dtRow("F9") = Mid(WK_str, 2, WK_str.LastIndexOf(Chr(34)) - 1)

                    WK_DsList1.Clear()
                    strSQL = "SELECT user_name FROM T01_REP_MTR"
                    strSQL = strSQL & " WHERE (rcpt_no = '" & dtRow("F5") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DaList1.Fill(WK_DsList1, "T01_REP_MTR")
                    DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                    If DtView1.Count <> 0 Then
                        dtRow("F10") = Trim(DtView1(0)("user_name"))
                    End If

                    dttable.Rows.Add(dtRow)

                    strLine = srFile.ReadLine()
                End While
                DB_CLOSE()

                f02.Enabled = True
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        End With

    End Sub

    '********************************************************************
    '**  �o�^�{�^��
    '********************************************************************
    Private Sub f02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f02.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DtView1 = New DataView(DsList1.Tables("inpt"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1

            strSQL = "INSERT INTO TSS_ETMT_ANS"
            strSQL = strSQL & " (cls, rcd_cls, snd_date, cust_repr_no, rcpt_no, etmt_cls, etmt_chrg, etmt_ans, etmt_ans_date)"
            strSQL = strSQL & " VALUES ('" & DtView1(i)("F1") & "'"
            strSQL = strSQL & ", '" & DtView1(i)("F2") & "'"
            If DtView1(i)("F3") = Nothing Then
                strSQL = strSQL & ", NULL"
            Else
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Mid(DtView1(i)("F3"), 1, 4) & "/" & Mid(DtView1(i)("F3"), 5, 2) & "/" & Mid(DtView1(i)("F3"), 7, 2) & "', 102)"
            End If
            strSQL = strSQL & ", '" & DtView1(i)("F4") & "'"

            strSQL = strSQL & ", '" & DtView1(i)("F5") & "'"
            strSQL = strSQL & ", " & DtView1(i)("F6") & ""
            strSQL = strSQL & ", " & DtView1(i)("F7") & ""
            strSQL = strSQL & ", '" & DtView1(i)("F8") & "'"
            If DtView1(i)("F9") = Nothing Then
                strSQL = strSQL & ", NULL)"
            Else
                strSQL = strSQL & ", CONVERT(DATETIME, '" & Mid(DtView1(i)("F9"), 1, 4) & "/" & Mid(DtView1(i)("F9"), 5, 2) & "/" & Mid(DtView1(i)("F9"), 7, 2) & "', 102))"
            End If
            DB_OPEN("nMVAR")
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

        Next

        MessageBox.Show("�o�^���܂����B", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        f02.Enabled = False
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  ����E�I���{�^��
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  �t�@���N�V�����L�[
    '********************************************************************
    'Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.Interop.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

    '    e.Handled = True        '�t�@���N�V�����L�[�Ɋ���t����ꂽ�ݒ�𖳌��ɂ��܂��B
    '    Select Case e.KeyIndex  '�t�@���N�V�����L�[���������ꂽ�ꍇ�̏������s���܂��B
    '        Case 0  'F1
    '            If f01.Enabled = True Then f01.Focus() : f01_Click(sender, e)
    '        Case 1  'F2
    '            If f02.Enabled = True Then f02.Focus() : f02_Click(sender, e)
    '        Case 2  'F3
    '        Case 3  'F4
    '        Case 4  'F5
    '        Case 5  'F6
    '        Case 6  'F7
    '        Case 7  'F8
    '        Case 8  'F9
    '        Case 9  'F10
    '        Case 10 'F11
    '        Case 11 'F12
    '            f12_Click(sender, e)
    '    End Select
    'End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub f01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.GotFocus
        f01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f02_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f02.GotFocus
        f02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub f01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.LostFocus
        f01.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f02.LostFocus
        f02.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
