Public Class Form2
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim waitDlg As WaitDialog

    Dim strSQL, Err_F, CX_F, dir As String
    Dim i, j, K, r As Integer

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
    Friend WithEvents Date3 As GrapeCity.Win.Input.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Date
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
        Me.Date3 = New GrapeCity.Win.Input.Date
        Me.Date2 = New GrapeCity.Win.Input.Date
        Me.Label21 = New System.Windows.Forms.Label
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Date3
        '
        Me.Date3.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date3.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date3.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date3.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date3.Location = New System.Drawing.Point(196, 16)
        Me.Date3.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2030, 12, 31, 23, 59, 59, 0))
        Me.Date3.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date3.Name = "Date3"
        Me.Date3.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date3.Size = New System.Drawing.Size(80, 24)
        Me.Date3.TabIndex = 1358
        Me.Date3.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date3.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date3.Value = Nothing
        Me.Date3.Visible = False
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM", "", "")
        Me.Date2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date2.Location = New System.Drawing.Point(112, 16)
        Me.Date2.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2030, 12, 31, 23, 59, 59, 0))
        Me.Date2.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(80, 24)
        Me.Date2.TabIndex = 1356
        Me.Date2.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date2.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date2.Value = Nothing
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(8, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 24)
        Me.Label21.TabIndex = 1357
        Me.Label21.Text = "�v��N��"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(288, 176)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(68, 28)
        Me.Button9.TabIndex = 1360
        Me.Button9.Text = "�߁@��"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(20, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 40)
        Me.Button1.TabIndex = 1359
        Me.Button1.Text = "�����\(Excel)"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(4, 136)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(368, 36)
        Me.msg.TabIndex = 1361
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(208, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 40)
        Me.Button2.TabIndex = 1362
        Me.Button2.Text = "�o�^�����m�F"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(386, 207)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Date3)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label21)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�����\"
        CType(Me.Date3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '************************************************
    '** �N����
    '************************************************
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Date3.Text = Now.Date() : Date2.Text = Mid(Date3.Text, 1, 7)
        dir = System.IO.Directory.GetCurrentDirectory
        msg.Text = Nothing
    End Sub

    '************************************************
    '** �����\(Excel)
    '************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_chk()
        If Err_F = "0" Then

            '==================  �N�����̏���  ===================  
            Dim xlApp As New Excel.Application
            Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
            '�����̃t�@�C�����J���ꍇ
            Dim xlFilePath As String = dir & "\���낪�˂⑍���\.xls"
            Dim xlBook As Excel.Workbook = xlBooks.Open(xlFilePath)
            Dim xlSheets As Excel.Sheets = xlBook.Worksheets
            Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
            xlApp.Visible = False

            '*****************************
            '** �����\�V�[�g
            '*****************************
            '==================  �f�[�^�̓��͏���  ==================  
            xlSheet = xlSheets.Item(1)  'Sheet1
            Dim xlRange As Excel.Range
            Dim strDat(999, 9) As Object
            xlRange = xlSheet.Range("A1:I1000")     '�f�[�^�̓��̓Z���͈�
            Dim xlCells As Excel.Range
            Dim xlRange_2 As Excel.Range

            Me.Enabled = False                      ' �I�[�i�[�̃t�H�[���𖳌��ɂ���

            waitDlg = New WaitDialog                ' �i�s�󋵃_�C�A���O
            waitDlg.Owner = Me                      ' �_�C�A���O�̃I�[�i�[��ݒ肷��
            waitDlg.MainMsg = "���낪�˂⑍���\"    ' �����̊T�v��\��
            waitDlg.ProgressMsg = "�f�[�^���o��"    ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = 0                 ' �S�̂̏���������ݒ�
            waitDlg.ProgressMin = 0                 ' ���������̍ŏ��l��ݒ�i0������J�n�j
            waitDlg.ProgressStep = 1                ' �������ƂɃ��[�^��i�߂邩��ݒ�
            waitDlg.ProgressValue = 0               ' �ŏ��̌�����ݒ�
            waitDlg.Show()                          ' �i�s�󋵃_�C�A���O��\������
            Application.DoEvents()                  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            DsList1.Clear()
            strSQL = "SELECT WRN_DATA.SHOP_CODE, SHOP.SHOP_NAME, M_category.CAT_NAME, COUNT(*) AS cnt"
            strSQL += ", SUM(WRN_DATA.PRICE) AS sum_PRICE, SUM(WRN_DATA.WRN_PRICE) AS sum_WRN_PRICE"
            strSQL += ", SUM(M_category.tesuryo) AS sum_tesuryo, SUM(WRN_DATA.WRN_PRICE - M_category.tesuryo) AS sum_ivc"
            strSQL += ", SUM(M_category.jimu) AS sum_jimu"
            strSQL += " FROM WRN_DATA INNER JOIN"
            strSQL += " SHOP ON WRN_DATA.SHOP_CODE = SHOP.SHOP_CODE INNER JOIN"
            strSQL += " M_category ON WRN_DATA.bunrui = M_category.CAT_CODE"
            strSQL += " WHERE (WRN_DATA.close_date = CONVERT(DATETIME, '" & Date2.Text & "/01', 102)) AND (WRN_DATA.delt_flg = 0)"
            strSQL += " GROUP BY WRN_DATA.SHOP_CODE, SHOP.SHOP_NAME, M_category.CAT_NAME"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            r = DaList1.Fill(DsList1, "WRN_DATA")
            DB_CLOSE()

            If r = 0 Then
                msg.Text = "�Y������f�[�^������܂���"
                Date2.Focus()
                GoTo proc_end
            End If

            strSQL = "SELECT M_category.CAT_NAME, COUNT(*) AS cnt, SUM(WRN_DATA.PRICE) AS sum_PRICE"
            strSQL += ", SUM(WRN_DATA.WRN_PRICE) AS sum_WRN_PRICE, SUM(M_category.tesuryo) AS sum_tesuryo"
            strSQL += ", SUM(WRN_DATA.WRN_PRICE - M_category.tesuryo) AS sum_ivc, SUM(M_category.jimu) AS sum_jimu"
            strSQL += " FROM WRN_DATA INNER JOIN"
            strSQL += " M_category ON WRN_DATA.bunrui = M_category.CAT_CODE"
            strSQL += " WHERE (WRN_DATA.close_date = CONVERT(DATETIME, '" & Date2.Text & "/01', 102)) AND (WRN_DATA.delt_flg = 0)"
            strSQL += " GROUP BY M_category.CAT_NAME"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "WRN_DATA2")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)
            waitDlg.MainMsg = "Excel�쐬���i�����\�j"   ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = DtView1.Count         ' �S�̂̏���������ݒ�
            Application.DoEvents()                      ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            j = 0
            strDat(j, 0) = "���낪�˂�l  �����ۏؑ����\"
            strDat(j, 7) = Mid(Date2.Text, 1, 4) & "�N" & Mid(Date2.Text, 6, 2) & "���󒍕�"

            j += 1
            strDat(j, 0) = "�X�܃R�[�h"
            strDat(j, 1) = "�X�ܖ�"
            strDat(j, 2) = "���i����"
            strDat(j, 3) = "����"
            strDat(j, 4) = "���i���i"
            strDat(j, 5) = "�ۏؗ�"
            strDat(j, 6) = "�̔��萔��"
            strDat(j, 7) = "�������z"
            strDat(j, 8) = "�����萔��"

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                j += 1
                strDat(j, 0) = DtView1(i)("SHOP_CODE")
                strDat(j, 1) = DtView1(i)("SHOP_NAME")
                strDat(j, 2) = DtView1(i)("CAT_NAME")
                strDat(j, 3) = DtView1(i)("cnt")
                strDat(j, 4) = DtView1(i)("sum_PRICE")
                strDat(j, 5) = DtView1(i)("sum_WRN_PRICE")
                strDat(j, 6) = DtView1(i)("sum_tesuryo")
                strDat(j, 7) = DtView1(i)("sum_ivc")
                strDat(j, 8) = DtView1(i)("sum_jimu")
            Next

            j += 1
            strDat(j, 2) = "���v"
            strDat(j, 3) = "=SUM(D3" & ":D" & j & ")"
            strDat(j, 4) = "=SUM(E3" & ":E" & j & ")"
            strDat(j, 5) = "=SUM(F3" & ":F" & j & ")"
            strDat(j, 6) = "=SUM(G3" & ":G" & j & ")"
            strDat(j, 7) = "=SUM(H3" & ":H" & j & ")"
            strDat(j, 8) = "=SUM(I3" & ":I" & j & ")"

            xlCells = xlSheet.Cells
            xlRange_2 = xlCells(j + 1, 4) : xlRange_2.Interior.Color = RGB(0, 255, 255)
            xlRange_2 = xlCells(j + 1, 5) : xlRange_2.Interior.Color = RGB(0, 255, 255)
            xlRange_2 = xlCells(j + 1, 6) : xlRange_2.Interior.Color = RGB(0, 255, 255)
            xlRange_2 = xlCells(j + 1, 7) : xlRange_2.Interior.Color = RGB(0, 255, 255)
            xlRange_2 = xlCells(j + 1, 8) : xlRange_2.Interior.Color = RGB(0, 255, 255)
            xlRange_2 = xlCells(j + 1, 9) : xlRange_2.Interior.Color = RGB(0, 255, 255)

            DtView1 = New DataView(DsList1.Tables("WRN_DATA2"), "", "", DataViewRowState.CurrentRows)
            waitDlg.MainMsg = "Excel�쐬���i�����\�S�X�܁j" ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = DtView1.Count             ' �S�̂̏���������ݒ�
            Application.DoEvents()                          ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            j += 1 : K = j + 2

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                j += 1
                If i = 0 Then strDat(j, 1) = "�S�X�܌v"
                strDat(j, 2) = DtView1(i)("CAT_NAME")
                strDat(j, 3) = DtView1(i)("cnt")
                strDat(j, 4) = DtView1(i)("sum_PRICE")
                strDat(j, 5) = DtView1(i)("sum_WRN_PRICE")
                strDat(j, 6) = DtView1(i)("sum_tesuryo")
                strDat(j, 7) = DtView1(i)("sum_ivc")
                strDat(j, 8) = DtView1(i)("sum_jimu")

                Select Case i
                    Case Is = 0
                        With xlSheet.Range("B" & j + 1 & ":B" & j + 1)
                            .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1          '�Z���̏㑤�̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1         '�Z���̍����̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1        '�Z���̉E���̌r��
                        End With
                        With xlSheet.Range("C" & j + 1 & ":I" & j + 1)
                            .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1          '�Z���̏㑤�̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1         '�Z���̍����̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1        '�Z���̉E���̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1       '�Z���̉����̌r��
                            .Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1   '�����Z����I�����Ă���ꍇ�A��Ԃ̌r��
                        End With
                    Case Else
                        With xlSheet.Range("B" & j + 1 & ":B" & j + 1)
                            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1         '�Z���̍����̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1        '�Z���̉E���̌r��
                        End With
                        With xlSheet.Range("C" & j + 1 & ":I" & j + 1)
                            .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 1          '�Z���̏㑤�̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1         '�Z���̍����̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1        '�Z���̉E���̌r��
                            .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1       '�Z���̉����̌r��
                            .Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1   '�����Z����I�����Ă���ꍇ�A��Ԃ̌r��
                        End With
                End Select
            Next

            j += 1
            strDat(j, 3) = "=SUM(D" & K & ":D" & j & ")"
            strDat(j, 4) = "=SUM(E" & K & ":E" & j & ")"
            strDat(j, 5) = "=SUM(F" & K & ":F" & j & ")"
            strDat(j, 6) = "=SUM(G" & K & ":G" & j & ")"
            strDat(j, 7) = "=SUM(H" & K & ":H" & j & ")"
            strDat(j, 8) = "=SUM(I" & K & ":I" & j & ")"
            With xlSheet.Range("B" & j + 1 & ":B" & j + 1)
                .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 9          '�Z���̏㑤�̌r��
                .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1         '�Z���̍����̌r��
                .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1        '�Z���̉E���̌r��
                .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1       '�Z���̉����̌r��
            End With
            With xlSheet.Range("C" & j + 1 & ":I" & j + 1)
                .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = 9          '�Z���̏㑤�̌r��
                .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 1         '�Z���̍����̌r��
                .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1        '�Z���̉E���̌r��
                .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = 1       '�Z���̉����̌r��
                .Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1   '�����Z����I�����Ă���ꍇ�A��Ԃ̌r��
            End With

            xlRange.Value = strDat        '�Z���փf�[�^�̓���
            MRComObject(xlRange)           'xlRange �̉��

            '*****************************
            '** ���׃V�[�g
            '*****************************
            '==================  �f�[�^�̓��͏���  ==================  
            xlSheet = xlSheets.Item(2)  'Sheet2
            Dim xlRange2 As Excel.Range
            Dim strDat2(999, 13) As Object
            xlRange2 = xlSheet.Range("A2:N10000")    '�f�[�^�̓��̓Z���͈�
            Dim xlCells2 As Excel.Range
            Dim xlRange2_2 As Excel.Range

            strSQL = "SELECT WRN_DATA.WRN_NO, SHOP.SHOP_NAME, WRN_DATA.WRN_DATE, WRN_DATA.CUST_NAME"
            strSQL += ", M_maker.MKR_NAME, WRN_DATA.CAT_NAME, M_category.CAT_NAME AS bunrui_name"
            strSQL += ", WRN_DATA.MODEL, WRN_DATA.PRICE, WRN_DATA.WRN_PRICE, WRN_DATA.WRN_PRD, WRN_DATA.biko"
            strSQL += " FROM M_maker INNER JOIN"
            strSQL += " WRN_DATA INNER JOIN"
            strSQL += " SHOP ON WRN_DATA.SHOP_CODE = SHOP.SHOP_CODE ON"
            strSQL += " M_maker.MKR_CODE = WRN_DATA.MKR_CODE INNER JOIN"
            strSQL += " M_category ON WRN_DATA.bunrui = M_category.CAT_CODE"
            strSQL += " WHERE (WRN_DATA.close_date = CONVERT(DATETIME, '" & Date2.Text & "/01', 102)) AND (WRN_DATA.delt_flg = 0)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "WRN_DATA3")
            DB_CLOSE()

            DtView1 = New DataView(DsList1.Tables("WRN_DATA3"), "", "", DataViewRowState.CurrentRows)
            waitDlg.MainMsg = "Excel�쐬���i���ׁj" ' �i�s�󋵃_�C�A���O�̃��[�^�[��ݒ�
            waitDlg.ProgressMax = DtView1.Count     ' �S�̂̏���������ݒ�
            Application.DoEvents()                  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����

            j = -1
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%�@�i" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " ���j"
                Application.DoEvents()  ' ���b�Z�[�W�����𑣂��ĕ\�����X�V����
                waitDlg.PerformStep()   ' �����J�E���g��1�X�e�b�v�i�߂�

                j += 1
                strDat2(j, 0) = i + 1
                strDat2(j, 1) = Mid(DtView1(i)("WRN_NO"), 1, 2) & "-" & Mid(DtView1(i)("WRN_NO"), 3, 9)
                strDat2(j, 2) = DtView1(i)("SHOP_NAME")
                strDat2(j, 3) = DtView1(i)("WRN_DATE")
                strDat2(j, 4) = DtView1(i)("CUST_NAME")
                strDat2(j, 5) = DtView1(i)("bunrui_name")
                strDat2(j, 6) = DtView1(i)("MKR_NAME")
                strDat2(j, 7) = DtView1(i)("CAT_NAME")
                strDat2(j, 8) = DtView1(i)("MODEL")
                strDat2(j, 9) = "1"
                strDat2(j, 10) = DtView1(i)("PRICE")
                strDat2(j, 11) = DtView1(i)("WRN_PRICE")
                strDat2(j, 12) = DtView1(i)("WRN_PRD")
                strDat2(j, 13) = DtView1(i)("biko")
            Next

            xlRange2.Value = strDat2        '�Z���փf�[�^�̓���
            MRComObject(xlRange2)           'xlRange �̉��

            '�m���O��t���ĕۑ��n�_�C�A���O�{�b�N�X��\��
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "���낪�˂⑍���\" & Mid(Date2.Text, 1, 4) & Mid(Date2.Text, 6, 2) & ".xls"
            SaveFileDialog1.Filter = "Excel�t�@�C��|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                xlBook.SaveAs(SaveFileDialog1.FileName)
                CX_F = "0"
            Else
                CX_F = "1"
            End If

            '==================  �I������  =====================  
            MRComObject(xlSheet)            'xlSheet �̉��
            MRComObject(xlSheets)           'xlSheets �̉��
            xlBook.Close(False)             'xlBook �����
            MRComObject(xlBook)             'xlBook �̉��
            MRComObject(xlBooks)            'xlBooks �̉��
            xlApp.Quit()                    'Excel����� 
            MRComObject(xlApp)              'xlApp �����

            If CX_F = "0" Then
                MessageBox.Show(SaveFileDialog1.FileName & " �ɏo�͂��܂����B", "�m�F", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

proc_end:
            Me.Activate()       ' ��������I�[�i�[���A�N�e�B�u�ɂ���
            waitDlg.Close()     ' �i�s�󋵃_�C�A���O�����
            Me.Enabled = True

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
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

    Sub F_chk()
        Err_F = "0"
        msg.Text = Nothing

        If Date2.Number = 0 Then
            Err_F = "1"
            msg.Text = "�v��N������͂��Ă��������B"
            Date2.Focus()
        End If
    End Sub

    '************************************************
    '** �o�^�����m�F
    '************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_chk()
        If Err_F = "0" Then

            Dim n, l As Integer

            DsList1.Clear()
            strSQL = "SELECT SUBSTRING(WRN_NO, 1, 9) AS wrn9"
            strSQL += " FROM WRN_DATA"
            strSQL += " WHERE (close_date = CONVERT(DATETIME, '" & Date2.Text & "/01', 102))"
            strSQL += " AND (delt_flg = 0)"
            strSQL += " GROUP BY SUBSTRING(WRN_NO, 1, 9)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            n = DaList1.Fill(DsList1, "n")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("n"), "", "", DataViewRowState.CurrentRows)

            strSQL = "SELECT COUNT(*) AS cnt FROM WRN_DATA"
            strSQL += " WHERE (close_date = CONVERT(DATETIME, '" & Date2.Text & "/01', 102))"
            strSQL += " AND (delt_flg = 0)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN()
            DaList1.Fill(DsList1, "l")
            DB_CLOSE()
            DtView1 = New DataView(DsList1.Tables("l"), "", "", DataViewRowState.CurrentRows)
            l = DtView1(0)("cnt")

            MessageBox.Show("���ݓo�^����Ă��錏���͉��L�̒ʂ�ł��B" & vbCrLf & vbCrLf & n & "��   " & l & "�s", "�o�^�����m�F", MessageBoxButtons.OK)

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '************************************************
    '** �߂�
    '************************************************
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub
End Class
