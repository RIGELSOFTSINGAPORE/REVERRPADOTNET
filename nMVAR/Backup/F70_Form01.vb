Public Class F70_Form01
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, printer, WK_str As String
    Dim i As Integer

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
    Friend WithEvents PdfExport1 As DataDynamics.ActiveReports.Export.Pdf.PdfExport
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PdfExport1 = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
        '
        'F70_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(166, 8)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F70_Form01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�����"

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F70_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case PRT_PRAM1
            Case Is = "Print_R_Azukari_Sheet"       '**  ���a����V�[�g (R_Azukari_Sheet)
                Print_R_Azukari_Sheet(PRT_PRAM2)

            Case Is = "Print_R_Mitsumori"           '**  �����Ϗ� (R_Mitsumori)
                Print_R_Mitsumori(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_NEC_Parts_Inq"       '**  NEC���i���i�⍇���[ (R_NEC_Parts_Inq)
                Print_R_NEC_Parts_Inq(PRT_PRAM2)

            Case Is = "Print_R_Fujitsu_Parts_Inq"   '**  Fujitsu���i���i�⍇���[ (R_Fujitsu_Parts_Inq)
                Print_R_Fujitsu_Parts_Inq(PRT_PRAM2)

            Case Is = "Print_R_Sagyou_Report"       '**  ��ƕ񍐏� (R_Sagyou_Report)
                Print_R_Sagyou_Report(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_Inquiry"             '**  �e�`�w���t���� (R_Inquiry)
                Print_R_Inquiry(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_QGCare"              '**  �P�A����� (R_QGCare)
                Print_R_QGCare(PRT_PRAM2, PRT_PRAM3)

        End Select
        DsList1.Clear()
        P_DsPRT.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  ���a����V�[�g (R_Azukari_Sheet)
    '********************************************************************
    Public Function Print_R_Azukari_Sheet(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        P_DtView1(0)("accp_date2") = Format(CDate(P_DtView1(0)("accp_date")).Date, "M��dd��")
        If Not IsDBNull(P_DtView1(0)("store_accp_date")) Then
            P_DtView1(0)("store_accp_date2") = Format(CDate(P_DtView1(0)("store_accp_date")).Date, "M��dd��")
        End If

        If P_DtView1(0)("idvd_flg") = "1" Then
            P_DtView1(0)("store_name") = Nothing
        End If

        '�t���i�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram2.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print02")

        '��t���e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        P_HSTY_DATE = Now
        '������t
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Azukari_Sheet)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Azukari_Sheet")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Azukari_Sheet = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  �v�����^���擾

        Dim rpt As New R_Azukari_Sheet
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "���a����V�[�g"
            rpt.Document.Print(False, False, False)
        End If

        'PdfExport1.Export(rpt.Document, "C:\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")

        add_hsty(rcpt_no, "���a����V�[�g���", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  �����Ϗ� (R_Mitsumori)
    '********************************************************************
    Public Function Print_R_Mitsumori(ByVal rcpt_no, ByVal ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        Dim myCI As New System.Globalization.CultureInfo("ja-JP", True)
        myCI.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar
        If P_DtView1(0)("sub_code") = "00" Then P_DtView1(0)("sub_own_name") = P_DtView1(0)("cls_code_name")
        P_DtView1(0)("brch_zip") = "��" & Mid(P_DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(P_DtView1(0)("brch_zip"), 4, 4)

        If P_DtView1(0)("idvd_flg") = "1" Then P_DtView1(0)("store_repr_no") = ""
        'If P_DtView1(0)("note_kbn") = "01" Then P_DtView1(0)("etmt_shop_part_chrg") = 0
        'If P_DtView1(0)("note_kbn") = "01" Then P_DtView1(0)("etmt_shop_tech_chrg") = 0

        P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy�NMM��dd��")
        strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '019')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "cls019")
        DtView1 = New DataView(DsList1.Tables("cls019"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            P_DtView1(0)("etmt_lmit_period") = DtView1(0)("cls_code_name")
            P_DtView1(0)("etmt_lmit_date") = DateAdd(DateInterval.Day, DtView1(0)("cls_code_name"), P_DtView1(0)("etmt_date"))
            P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy�NMM��dd��")
            P_DtView1(0)("accp_date2") = CDate(P_DtView1(0)("accp_date")).ToString("yyyy�NMM��dd��")
        End If
        Select Case ptn
            Case Is = "01", "11"    '�r�b�N�J����
            Case Is = "02"          '�W���[�V��
                P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy�NMM��dd��")
                P_DtView1(0)("etmt_lmit_date") = DateAdd(DateInterval.Day, 7, P_DtView1(0)("etmt_date")).ToString("yyyy�NMM��dd��")
                P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy�NMM��dd��")
                P_DtView1(0)("accp_date2") = CDate(P_DtView1(0)("accp_date")).ToString("yyyy�NMM��dd��")
            Case Is = "03"          '�\�t�}�b�v
            Case Is = "04"          '���h�o�V�J����
            Case Is = "05"          '��w����
                P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy�NMM��dd��")

                strSQL = "SELECT cls_code_name FROM M21_CLS_CODE WHERE (cls_no = '019')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsList1, "cls019")
                DtView1 = New DataView(DsList1.Tables("cls019"), "", "", DataViewRowState.CurrentRows)
                If DtView1.Count <> 0 Then
                    P_DtView1(0)("etmt_lmit_period") = DtView1(0)("cls_code_name")
                    P_DtView1(0)("etmt_lmit_date") = DateAdd(DateInterval.Day, DtView1(0)("cls_code_name"), P_DtView1(0)("etmt_date"))
                    P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy�NMM��dd��")
                End If
            Case Is = "06"          '�\�t�}�b�vOLC
            Case Is = "07"          '���s���ƘA��
                P_DtView1(0)("etmt_date2") = CDate(P_DtView1(0)("etmt_date")).ToString("yyyy�NMM��dd��")
                P_DtView1(0)("etmt_lmit_date2") = CDate(P_DtView1(0)("etmt_lmit_date")).ToString("yyyy�NMM��dd��")
                P_DtView1(0)("accp_date2") = CDate(P_DtView1(0)("accp_date")).ToString("yyyy�NMM��dd��")
            Case Is = "13"          '�R�W�}
            Case Else       '�ʏ�
        End Select

        '��t���e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '���ϓ��e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram4.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print04")

        '���i�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print05")

        P_HSTY_DATE = Now
        '������t
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Mitsumori)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Mitsumori")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Mitsumori = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  �v�����^���擾

        P_rcpt_cls = P_DtView1(0)("rcpt_cls")

        Dim sel As String = Nothing
        'If P_DtView1(0)("arvl_cls") = "01" Then    '�����i��ʁj
        Select Case P_DtView1(0)("vndr_code")
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                sel = "Apple"
            Case Else
        End Select
        'End If

        Select Case ptn
            Case Is = "01"  '�r�b�N�J����
                Dim rpt As New R_Mitsumori_BICCamera
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����Ϗ�_�r�b�N�J����"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                End If

            Case Is = "02"  '�W���[�V��
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Joshin
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_�W���[�V��"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                End If

            Case Is = "03"  '�\�t�}�b�v
                Dim rpt As New R_Mitsumori_SOFMAP
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����Ϗ�_�\�t�}�b�v"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                End If

            Case Is = "04"  '���h�o�V�J����
                Dim rpt As New R_Mitsumori_Yodobashi
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����Ϗ�_���h�o�V�J����"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                End If

            Case Is = "05"  '��w����
                Select Case P_DtView1(0)("rcpt_cls")
                    Case Is = "02"  'QG-Care
                        If P_DtView1(0)("menseki_amnt") = 0 And P_DtView1(0)("wrn_limt_amnt") >= P_DtView1(0)("etmt_shop_ttl") + P_DtView1(0)("etmt_shop_tax") Then
                            Dim rpt As New R_Mitsumori_Seikyo_QGCARE
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�����Ϗ�_��w����_QGCare"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                            End If
                        Else
                            Dim rpt As New R_Mitsumori_Seikyo_Menseki5k
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�����Ϗ�_��w����_�Ɛ�"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                            End If
                        End If
                    Case Is = "03", "10" '�����ۏ�(QG-Care)'����Fujitsu�ی�
                        If P_DtView1(0)("menseki_amnt") <> 0 Or P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("etmt_shop_ttl") + P_DtView1(0)("etmt_shop_tax") Then    '�Ɛӂ��� or �x�m�ʕی� or ���x��
                            Dim rpt As New R_Mitsumori_Seikyo_Menseki5k
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�����Ϗ�_��w����_�Ɛ�"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                            End If
                        Else
                            Dim rpt As New R_Mitsumori_Seikyo_Normal
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print01"
                            rpt.Run(False)
                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�����Ϗ�_��w����_�ʏ�"
                                rpt.Document.Print(False, False, False)
                                add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                            End If
                        End If
                    Case Else
                        Dim rpt As New R_Mitsumori_Seikyo_Normal
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "Print01"
                        rpt.Run(False)
                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "�����Ϗ�_��w����_�ʏ�"
                            rpt.Document.Print(False, False, False)
                            add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                        End If
                End Select

            Case Is = "06"  '�\�t�}�b�vOLC
                Dim rpt As New R_Mitsumori_SOFMAP_OLC
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����Ϗ�_�\�t�}�b�vOLC"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                End If

            Case Is = "07"  '���s���ƘA��
                Dim rpt As New R_Mitsumori_kyotorengo
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����Ϗ�_���s���ƘA��"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                End If

            Case Is = "08"  '�ʏ�i�̎Ёj
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Normal_Hansya
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_�ʏ�_�̎�"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                End If

            Case Is = "09"  '�ʏ�i��z�j
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Normal_Teigaku
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_�ʏ�_��z"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                End If

            Case Is = "10"  '�G�C�f��
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Eiden
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_�G�C�f��"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                End If

            Case Is = "11"  '�r�b�N�J�����iTSS�j
                Dim rpt As New R_Mitsumori_BICMK
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����Ϗ�_�r�b�N�J����(TSS)"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                End If

                Dim rpt2 As New R_Mitsumori_BicEU
                rpt2.DataSource = P_DsPRT
                rpt2.DataMember = "Print01"
                rpt2.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    rpt2.Document.Name = "�����Ϗ�_�r�b�N�J����(TSS)2"
                    rpt2.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt2.Document.Name & "���", "", "")
                End If

            Case Is = "12"  '�r�b�N�J�����i���~�c�j
                Dim rpt As New R_Mitsumori_Bic_EU_NU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����Ϗ�_�r�b�N�J����(���~�c)"
                    rpt.Document.Print(False, False, False)
                    add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                End If

            Case Is = "13"  '�R�W�}
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_kojima
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_�R�W�}"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                End If

            Case Is = "14"  '�\�t�g�o���N
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_softbank
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_�\�t�g�o���N"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                End If

            Case Else       '�ʏ�
                'Dim sel As String = Nothing
                'If P_DtView1(0)("arvl_cls") = "01" Then    '�����i��ʁj
                '    Select Case P_DtView1(0)("vndr_code")
                '        Case Is = "01", "20", "21", "22", "23", "24", "25"
                '            sel = "Apple"
                '        Case Else
                '    End Select
                'End If
                If sel = "Apple" Then
                    Select Case P_DtView1(0)("price_rprt_ptn")
                        Case Is = "05", "07"
                            sel = Nothing
                    End Select
                End If
                If sel = "Apple" Then
                    Dim rpt As New R_Mitsumori_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_APPLE"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                Else
                    Dim rpt As New R_Mitsumori_Normal
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�����Ϗ�_�ʏ�"
                        rpt.Document.Print(False, False, False)
                        add_hsty(rcpt_no, rpt.Document.Name & "���", "", "")
                    End If
                End If
        End Select

        add_hsty(rcpt_no, "�����Ϗ����", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  NEC���i���i�⍇���[ (R_NEC_Parts_Inq)
    '********************************************************************
    Public Function Print_R_NEC_Parts_Inq(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '�˗��ҏ��
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 9)
        Pram2.Value = P_EMPL_NO
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print02")

        '��t���e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '���i�f�[�^
        DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        Dim page As Integer
        page = RoundUP(DtView1.Count / 5, 0)

        P_HSTY_DATE = Now
        '������t
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Part_amnt_Q)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Part_amnt_Q")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Part_amnt_Q = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  �v�����^���擾

        For i = 1 To page
            P_page = i
            Dim rpt As New R_NEC_Parts_Inq
            rpt.DataSource = P_DsPRT
            rpt.DataMember = "Print01"
            rpt.Run(False)
            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                End If
                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Else
                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                rpt.Document.Name = "NEC���i���i�⍇���["
                rpt.Document.Print(False, False, False)
            End If
        Next

        add_hsty(rcpt_no, "���i���i�⍇���[���", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  Fujitsu���i���i�⍇���[ (R_Fujitsu_Parts_Inq)
    '********************************************************************
    Public Function Print_R_Fujitsu_Parts_Inq(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        '�˗��ҏ��
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Parts_Inq_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int, 9)
        Pram2.Value = P_EMPL_NO
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print02")

        '���i�f�[�^
        DtView1 = New DataView(P_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
        Dim page As Integer
        page = RoundUP(DtView1.Count / 5, 0)

        P_HSTY_DATE = Now
        '������t
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Part_amnt_Q)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Part_amnt_Q")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Part_amnt_Q = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  �v�����^���擾

        For i = 1 To page
            P_page = i
            Dim rpt As New R_Fujitsu_Parts_Inq
            rpt.DataSource = P_DsPRT
            rpt.DataMember = "Print01"
            rpt.Run(False)
            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                End If
                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
            Else
                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                rpt.Document.Name = "Fujitsu���i���i�⍇���["
                rpt.Document.Print(False, False, False)
            End If
        Next

        add_hsty(rcpt_no, "���i���i�⍇���[���", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  ��ƕ񍐏� (R_Sagyou_Report)
    '********************************************************************
    Public Function Print_R_Sagyou_Report(ByVal rcpt_no, ByVal ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        Dim myCI As New System.Globalization.CultureInfo("ja-JP", True)
        myCI.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar

        WK_str = P_DtView1(0)("cls_code_name")
        WK_str = WK_str.Replace("�������", "��")
        P_DtView1(0)("cls_code_name") = WK_str

        WK_str = P_DtView1(0)("sub_own_name")
        WK_str = WK_str.Replace("�������", "��")
        P_DtView1(0)("sub_own_name") = WK_str

        If P_DtView1(0)("sub_code") = "00" Then P_DtView1(0)("sub_own_name") = P_DtView1(0)("cls_code_name")
        P_DtView1(0)("brch_zip") = Mid(P_DtView1(0)("brch_zip"), 1, 3) & "-" & Mid(P_DtView1(0)("brch_zip"), 4, 4)

        If P_DtView1(0)("idvd_flg") = "1" Then P_DtView1(0)("store_repr_no") = ""
        'P_DtView1(0)("adrs1") = P_DtView1(0)("adrs1") & " " & P_DtView1(0)("adrs2")

        'If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
        '    P_DtView1(0)("comp_shop_tech_chrg") = 0
        '    P_DtView1(0)("comp_shop_part_chrg") = 0
        '    P_DtView1(0)("comp_shop_fee") = 0
        '    P_DtView1(0)("comp_shop_pstg") = 0
        '    P_DtView1(0)("comp_shop_ttl") = 0
        '    P_DtView1(0)("comp_shop_tax") = 0
        '    P_DtView1(0)("comp_eu_tech_chrg") = 0
        '    P_DtView1(0)("comp_eu_part_chrg") = 0
        '    P_DtView1(0)("comp_eu_fee") = 0
        '    P_DtView1(0)("comp_eu_pstg") = 0
        '    P_DtView1(0)("comp_eu_ttl") = 0
        '    P_DtView1(0)("comp_eu_tax") = 0
        'End If

        '��t���e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram3.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")

        '���ϓ��e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram4.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print04")

        '�C�����e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram6 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram6.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print06")

        '���i�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print05")

        DtView1 = New DataView(P_DsPRT.Tables("Print05"), "", "", DataViewRowState.CurrentRows)

        If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
            If DtView1.Count <> 0 Then
                For i = 0 To DtView1.Count - 1
                    DtView1(i)("shop_chrg") = 0
                    DtView1(i)("eu_chrg") = 0
                Next
            End If
        End If

        P_HSTY_DATE = Now
        '������t
        strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "T06_PRNT_DATE")
        DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            strSQL = "INSERT INTO T06_PRNT_DATE"
            strSQL += " (rcpt_no, Sagyou)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("Sagyou")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET Sagyou = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("01")   '**  �v�����^���擾

        'P_rcpt_cls = P_DtView1(0)("rcpt_cls")
        P_grup = P_DtView1(0)("grup_code")

        Dim sel As String = Nothing
        'Select Case P_DtView1(0)("grup_code")   '�̎ЃO���[�v
        '    Case Is = "02", "90", "91", "92"
        Select Case P_DtView1(0)("vndr_code")   '���[�J�[
            Case Is = "01", "20", "21", "22", "23", "24", "25"
                sel = "Apple"
            Case Else
        End Select
        '    Case Else
        'End Select

        Select Case ptn
            Case Is = "01"  '�r�b�N�J���� EU
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_Bic_EU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "��ƕ񍐏�_�r�b�N�J����_EU"
                    rpt.Document.Print(False, False, False)
                End If

                Dim rpt2 As New R_Sagyou_Report_BicGSS
                rpt2.DataSource = P_DsPRT
                rpt2.DataMember = "Print01"
                rpt2.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    rpt2.Document.Name = "��ƕ񍐏�_�r�b�N�J����_GSS"
                    rpt2.Document.Print(False, False, False)
                End If

            Case Is = "02"  'Ks
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_KS_EU
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_�P�[�Y�f���L"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "03"  '��w����
                'Dim sel As String = Nothing
                'Select Case P_DtView1(0)("grup_code")   '�̎ЃO���[�v
                '    Case Is = "02", "90", "91", "92"
                '        Select Case P_DtView1(0)("vndr_code")   '���[�J�[
                '            Case Is = "01", "20", "21", "22", "23", "24", "25"
                '                sel = "Apple"
                '            Case Else
                '        End Select
                '    Case Else
                'End Select
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt As New R_Sagyou_Report_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_Seikyo_EU
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_��w����_QGCare"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "04"  '�\�t�}�b�v
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_SofmapStore
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "��ƕ񍐏�_�\�t�}�b�v"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "05"  '���h�o�V�J����
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_Yodobashi_EU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "��ƕ񍐏�_���h�o�V�J����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "06"  '�\�t�}�b�vOLC
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_SofmapOLC
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "��ƕ񍐏�_�\�t�}�b�vOLC"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "07"  '���s���ƘA��
                'Dim sel As String = Nothing
                'Select Case P_DtView1(0)("grup_code")   '�̎ЃO���[�v
                '    Case Is = "02", "90", "91", "92"
                '        Select Case P_DtView1(0)("vndr_code")   '���[�J�[
                '            Case Is = "01", "20", "21", "22", "23", "24", "25"
                '                sel = "Apple"
                '            Case Else
                '        End Select
                '    Case Else
                'End Select
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt As New R_Sagyou_Report_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_kyotoseikyo
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_���s���ƘA��"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "08"  '�ʏ�i��z�j
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_Normal_Teigaku
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_�ʏ�_��z"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "09"  '�r�b�N�J���� EU(TSS)
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_BIC_EU_NMK
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "��ƕ񍐏�_�r�b�N�J����_EU(TSS)"
                    rpt.Document.Print(False, False, False)
                End If

                Dim rpt2 As New R_Sagyou_Report_BIC_NMK
                rpt2.DataSource = P_DsPRT
                rpt2.DataMember = "Print01"
                rpt2.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    rpt2.Document.Name = "��ƕ񍐏�_�r�b�N�J����(TSS)"
                    rpt2.Document.Print(False, False, False)
                End If

            Case Is = "10"  '�ʏ�i��z�j
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_EU_syanasi
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_EU_�Ж��Ȃ�"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "11"  '�r�b�N�J���� EU(���~�c)
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                Dim rpt As New R_Sagyou_Report_BIC_EU_NU
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "��ƕ񍐏�_�r�b�N�J����_EU(���~�c)"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "12"  '�R�W�}
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_Kojima
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_�R�W�}"
                        rpt.Document.Print(False, False, False)
                    End If

                    Dim rpt2 As New R_Sagyou_Report_Kojima_0
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_�R�W�}_0"
                        rpt2.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "13"  '�h�X�p��
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    P_zero = "0"
                    Dim rpt As New R_Sagyou_Report_DosPara
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_�h�X�p��"
                        rpt.Document.Print(False, False, False)
                    End If

                    P_zero = "1"
                    Dim rpt2 As New R_Sagyou_Report_DosPara
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_�h�X�p��_0"
                        rpt2.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "14"  '�W���[�V��
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_jyoshin_apple_EU
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_�W���[�V��"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "15"  '�\�t�g�o���N
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_softbank
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_�\�t�g�o���N"
                        rpt.Document.Print(False, False, False)
                    End If
                End If

            Case Is = "16"  'QAC
                If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(0)("comp_shop_tech_chrg") = 0
                    P_DtView1(0)("comp_shop_part_chrg") = 0
                    P_DtView1(0)("comp_shop_fee") = 0
                    P_DtView1(0)("comp_shop_pstg") = 0
                    P_DtView1(0)("comp_shop_ttl") = 0
                    P_DtView1(0)("comp_shop_tax") = 0
                    P_DtView1(0)("comp_eu_tech_chrg") = 0
                    P_DtView1(0)("comp_eu_part_chrg") = 0
                    P_DtView1(0)("comp_eu_fee") = 0
                    P_DtView1(0)("comp_eu_pstg") = 0
                    P_DtView1(0)("comp_eu_ttl") = 0
                    P_DtView1(0)("comp_eu_tax") = 0
                End If
                If sel = "Apple" Then
                    Dim rpt2 As New R_Sagyou_Report_Apple
                    rpt2.DataSource = P_DsPRT
                    rpt2.DataMember = "Print01"
                    rpt2.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                        rpt2.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt2.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_Sagyou_Report_QAC
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_QAC"
                        rpt.Document.Print(False, False, False)
                    End If

                    'Dim rpt2 As New R_Sagyou_Report_Normal
                    'rpt2.DataSource = P_DsPRT
                    'rpt2.DataMember = "Print01"
                    'rpt2.Run(False)
                    'If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    '    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                    '        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    '    End If
                    '    PdfExport1.Export(rpt2.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    'Else
                    '    If PRT_CHK(printer) = "1" Then rpt2.Document.Printer.PrinterName = printer
                    '    rpt2.Document.Name = "��ƕ񍐏�_�ʏ�"
                    '    rpt2.Document.Print(False, False, False)
                    'End If
                End If

            Case Else       '�ʏ�
                'sel = Nothing
                'If P_DtView1(0)("arvl_cls") = "01" Then    '�����i��ʁj
                '    Select Case P_DtView1(0)("vndr_code")
                '        Case Is = "01", "20", "21", "22", "23", "24", "25"
                '            sel = "Apple"
                '        Case Else
                '    End Select
                'End If
                If sel = "Apple" Then
                    Dim rpt As New R_Sagyou_Report_Apple
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.Run(False)
                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "��ƕ񍐏�_APPLE"
                        rpt.Document.Print(False, False, False)
                    End If
                Else
                    sel = Nothing
                    Select Case P_DtView1(0)("grup_code")   '�̎ЃO���[�v
                        Case Is = "02", "90", "91", "92"
                            Select Case P_DtView1(0)("vndr_code")   '���[�J�[
                                Case Is = "01", "20", "21", "22", "23", "24", "25"
                                    sel = "Apple"
                                Case Else
                            End Select
                        Case Else
                    End Select
                    If sel = "Apple" Then
                        Dim rpt As New R_Sagyou_Report_Apple
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "Print01"
                        rpt.Run(False)
                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "��ƕ񍐏�_APPLE"
                            rpt.Document.Print(False, False, False)
                        End If
                    Else
                        If P_DtView1(0)("rpar_cls") <> "01" Then   '�L���ȊO
                            P_DtView1(0)("comp_shop_tech_chrg") = 0
                            P_DtView1(0)("comp_shop_part_chrg") = 0
                            P_DtView1(0)("comp_shop_fee") = 0
                            P_DtView1(0)("comp_shop_pstg") = 0
                            P_DtView1(0)("comp_shop_ttl") = 0
                            P_DtView1(0)("comp_shop_tax") = 0
                            P_DtView1(0)("comp_eu_tech_chrg") = 0
                            P_DtView1(0)("comp_eu_part_chrg") = 0
                            P_DtView1(0)("comp_eu_fee") = 0
                            P_DtView1(0)("comp_eu_pstg") = 0
                            P_DtView1(0)("comp_eu_ttl") = 0
                            P_DtView1(0)("comp_eu_tax") = 0
                        End If
                        Dim rpt As New R_Sagyou_Report_Normal
                        rpt.DataSource = P_DsPRT
                        rpt.DataMember = "Print01"
                        rpt.Run(False)
                        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                            End If
                            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                        Else
                            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                            rpt.Document.Name = "��ƕ񍐏�_�ʏ�"
                            rpt.Document.Print(False, False, False)
                        End If
                    End If
                End If
        End Select

        ''QG Care �̏ꍇ�ʏ�����
        'If P_DtView1(0)("qg_care_no") <> Nothing Then
        '    Dim rpt As New R_Sagyou_Report_Normal  '�ʏ�
        '    rpt.DataSource = P_DsPRT
        '    rpt.DataMember = "Print01"
        '    rpt.Run(False)
        '    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
        '        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
        '            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
        '        End If
        '        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
        '    Else
        '        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
        '        rpt.Document.Name = "��ƕ񍐏�_�ʏ�"
        '        rpt.Document.Print(False, False, False)
        '    End If
        'End If

        add_hsty(rcpt_no, "��ƕ񍐏����", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  �e�`�w���t���� (R_Inquiry)
    '********************************************************************
    Public Function Print_R_Inquiry(ByVal Key_no, ByVal ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Inquiry", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Int)
        Pram1.Value = Key_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)

        '��t���e�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram4.Value = P_DtView1(0)("rcpt_no")
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print03")
        DB_CLOSE()

        WK_str = P_DtView1(0)("comp_name")
        WK_str = WK_str.Replace("�������", "��")
        P_DtView1(0)("comp_name") = WK_str

        printer = PRT_GET("01")   '**  �v�����^���擾

        Select Case ptn
            Case Is = "01"  '�W��
                Dim rpt As New R_Inquiry_Free_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "02"  '�p�X���[�h�m�F
                Dim rpt As New R_Inquiry_Password
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "03"  '�f�[�^�����m�F
                Dim rpt As New R_Inquiry_Data
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "04"  '�Ǐ�Č����Ȃ�
                Dim rpt As New R_Inquiry_NTF
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "05"  '�ۏ؏��L�ژR��
                Dim rpt As New R_Inquiry_hosyomore_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "06"  '�W���@
                Dim rpt As New R_Inquiry_Tenjiki_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "07"  '�V���A���ԍ�����
                Dim rpt As New R_Inquiry_Siriaru_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "08"  '����������
                Dim rpt As New R_Inquiry_Doukonbutu_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "09"  '�I���@��
                Dim rpt As New R_Inquiry_EOS_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "10"  'Apple��z�C��
                Dim rpt As New R_Inquiry_Apple_teigaku_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "11"  '�Y�t��
                Dim rpt As New R_Inquiry_Tenpusyo_Inq
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "12"  '�f�[�^���J�o���[
                Dim rpt As New R_Inquiry_DataRcvy1
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "FAX���t��"
                    rpt.Document.Print(False, False, False)
                End If

        End Select

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  �P�A����� (R_QGCare)
    '********************************************************************
    Public Function Print_R_QGCare(ByVal qg_care_no, ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        P_HSTY_DATE = Now
        P_RTN = "0"

        ''���[�J�[
        'DsList0.Clear()
        'strSQL = "SELECT vndr_code, name FROM M05_VNDR"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'DaList1.Fill(DsList0, "M05_VNDR")
        'DB_CLOSE()

        '���C���f�[�^
        strSQL = "SELECT T01_member.code AS �����ԍ�, T01_member.user_name AS ����, T01_member.tel AS �d�b�ԍ�"
        strSQL += ", V_M02_HSY.cls_code_name AS �ۏ͈ؔ�, T01_member.Part_date AS ������"
        strSQL += ", T01_member.makr_wrn_stat AS ���[�J�[�ۏ؊J�n, M01_univ.univ_name AS ��w��"
        strSQL += ", T01_member.prch_amnt AS PC�w�����z, T01_member.wrn_tem AS �ۏ؊���"
        strSQL += ", V_M02_HSK.cls_code_name AS �ۏ؊��Ԗ�, T01_member.modl_name AS PC���f����"
        strSQL += ", T01_member.s_no AS �V���A���ԍ�, T01_member.makr_code, M05_VNDR.name AS ���[�J�[��"
        strSQL += ", '�ۏ؊��ԓ�' AS �ۏ؉�, M04_shop.shop_name AS �̔��X��, T01_member.memo"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code LEFT OUTER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
        strSQL += " WHERE (T01_member.code = N'" & qg_care_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("QGCare")
        DaList1.Fill(P_DsPRT, "Print01")
        DB_CLOSE()

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        If P_DtView1.Count = 0 Then Exit Function

        'For i = 0 To P_DtView1.Count - 1
        '    DtView1 = New DataView(DsList0.Tables("M05_VNDR"), "vndr_code ='" & P_DtView1(i)("makr_code") & "'", "", DataViewRowState.CurrentRows)
        '    If DtView1.Count <> 0 Then
        '        P_DtView1(i)("���[�J�[��") = DtView1(0)("name")
        '    End If
        'Next

        If DateAdd(DateInterval.Year, P_DtView1(0)("�ۏ؊���"), P_DtView1(0)("������")) < P_HSTY_DATE Then
            P_DtView1(0)("�ۏ؉�") = Nothing
        End If
        If Not IsDBNull(P_DtView1(0)("memo")) Then
            P_DtView1(0)("memo") = P_DtView1(0)("memo").Replace(System.Environment.NewLine, "")
        Else
            P_DtView1(0)("memo") = ""
        End If

        printer = PRT_GET("01")   '**  �v�����^���擾

        Dim rpt As New R_QGCare
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.Run(False)

        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "�P�A���"
            rpt.Document.Print(False, False, False)
        End If

        add_hsty(rcpt_no, "�P�A�����", qg_care_no, "")
        P_RTN = "1"

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function
End Class
