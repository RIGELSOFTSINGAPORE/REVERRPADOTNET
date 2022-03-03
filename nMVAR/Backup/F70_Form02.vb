Public Class F70_Form02
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, Err_F, printer, WK_str, Ans As String
    Dim i As Integer

    Dim Wk_TAX As Integer
    Dim Wk_TAX_1, Wk_TAX_0 As Decimal
    Dim WK_mnsk As String

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
        'F70_Form02
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(94, 16)
        Me.ControlBox = False
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F70_Form02"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�����"

    End Sub

#End Region

    '********************************************************************
    '**  �N����
    '********************************************************************
    Private Sub F70_Form02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '����ŗ�
        Wk_TAX = tax_rate_get(Now) '����ŗ��擾
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0
        If Wk_TAX = "10" Then
            WK_mnsk = "4546"
        Else
            WK_mnsk = "4630"
        End If

        Select Case PRT_PRAM1
            Case Is = "Print_R_NEVA"                '**  �l�o�` (R_NEVA)
                P4_F00_Form07_2 = 0
                Print_R_NEVA(PRT_PRAM2)

            Case Is = "Print_R_chain"               '**  �`�F�[���X�g�A�`�[ (R_chain)
                P4_F00_Form07_2 = 0
                Print_R_chain(PRT_PRAM2)

            Case Is = "Print_R_Haiso"               '**  ����� (R_Haiso)
                Print_R_Haiso(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_NCR_CCAR"            '**  �b�b�`�q (R_NCR_CCAR)
                Print_R_NCR_CCAR(PRT_PRAM2)

                'Case Is = "Print_R_IBM_IW_Report"       '**  IBM�ۏؕ񍐏� (R_IBM_IW_Report)

                'Case Is = "Print_R_HP_Exc_TAG"          '**  Hp TAG��� (R_HP_Exc_TAG)

        End Select
        DsList1.Clear()
        P_DsPRT.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  �l�o�` (R_NEVA)
    '********************************************************************
    Public Function Print_R_NEVA(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_NEVA_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "WK_Print01")
        P_DtView1 = New DataView(P_DsPRT.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)

        strSQL = "SELECT '' AS Expr01, '' AS Expr02, '' AS Expr03, '' AS Expr04, '' AS Expr05, '' AS Expr06"
        strSQL += ", '' AS Expr07, '' AS Expr08, '' AS Expr09, '' AS Expr10, '' AS Expr11, '' AS Expr12"
        strSQL += ", '' AS Expr13, '' AS Expr14, '' AS Expr15, '' AS Expr16, '' AS Expr17, '' AS Expr18"
        strSQL += ", '' AS Expr19, '' AS Expr20"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")
        P_DsPRT.Tables("Print01").Clear()

        If P_DtView1.Count <> 0 Then
            For i = 0 To P_DtView1.Count - 1

                If P_DtView1(i)("grup_code") = "18" Or P_DtView1(i)("grup_code") = "52" Then   '�̎ЃO���[�v��'18','52'�Ȃ�v�����
                    P_DtView1(i)("comp_eu_ttl") = P_DtView1(i)("comp_shop_ttl")
                    P_DtView1(i)("comp_eu_part_chrg") = P_DtView1(i)("comp_shop_part_chrg")
                    P_DtView1(i)("comp_eu_tech_chrg") = P_DtView1(i)("comp_shop_tech_chrg")
                End If

                If P_DtView1(i)("rpar_cls") <> "01" Then   '�L���ȊO
                    P_DtView1(i)("comp_cost_ttl") = 0
                    P_DtView1(i)("comp_shop_ttl") = 0
                    P_DtView1(i)("comp_eu_ttl") = 0
                    P_DtView1(i)("comp_eu_part_chrg") = 0
                    P_DtView1(i)("comp_eu_tech_chrg") = 0
                End If

                dttable = P_DsPRT.Tables("Print01")
                dtRow = dttable.NewRow
                Select Case P_DtView1(0)("dlvr_rprt_ptn") '����p�^�[��

                    Case Is = "01"  '�r�b�N�J����
                        dtRow("Expr01") = "������Ѓ\�t�}�b�v"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = Nothing
                        dtRow("Expr07") = WK_str & " " & DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = Nothing
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = P_DtView1(i)("vndr_name") & " �C���i"
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("rcpt_no")
                        If Not IsDBNull(P_DtView1(i)("store_accp_date")) Then
                            dtRow("Expr18") = "�̎Зl��t��    " & Format(P_DtView1(i)("store_accp_date"), "yyyy�NMM��dd��")
                        Else
                            dtRow("Expr18") = "�̎Зl��t��    "
                        End If
                        dtRow("Expr19") = P_DtView1(i)("user_name") & " �l��"

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "02"  '�Ί�
                        dtRow("Expr01") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = Nothing
                        dtRow("Expr07") = WK_str & " " & DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr11") = Nothing
                        dtRow("Expr12") = P_DtView1(i)("vndr_name")
                        dtRow("Expr13") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("rcpt_no")
                        dtRow("Expr18") = P_DtView1(i)("model_1")
                        dtRow("Expr19") = Nothing

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "03"  '�~�h���d��
                        dtRow("Expr01") = "������Ѓ~�h���d��"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "04"  '���}�_�d�@
                        dtRow("Expr01") = "������Ѓ��}�_�d�@"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = Nothing
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = Nothing
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = P_DtView1(i)("rpar_cls_name")
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "05"  '�l�q�b
                        dtRow("Expr01") = Nothing
                        dtRow("Expr02") = P_DtView1(i)("cust_code")
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr11") = Nothing
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("vndr_name")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "06"  '�P�[�Y�f���L
                        dtRow("Expr01") = "�P�[�Y�f���L"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "07"  '�x�X�g�d��
                        dtRow("Expr01") = "������� �x�X�g�T�[�r�X"
                        dtRow("Expr02") = P_DtView1(i)("cust_code")
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr11") = "18-52"
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = P_DtView1(i)("cust_code")
                        dtRow("Expr16") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "08"  '�j���[�e�b�N
                        dtRow("Expr01") = "�L����Ѓj���[�e�b�N"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = "�}�c���f���L"
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "09"  '�W���[�V�����
                        dtRow("Expr01") = Nothing
                        dtRow("Expr02") = "6503"
                        dtRow("Expr03") = "�C���Z���^�["
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "10"  '�W���[�V�����
                        dtRow("Expr01") = "�W���[�V���T�[�r�X�������"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = "�W���[�V���T�[�r�X��" & System.Environment.NewLine & "��ʃJ�X�^�}�[�Z���^�["
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "�Ǘ��ԍ� " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "11"  '�G�C�f��
                        dtRow("Expr01") = "������ЃR���l�b�g"
                        dtRow("Expr02") = "9396"
                        dtRow("Expr03") = "�d�s�q�b�@�l"
                        dtRow("Expr04") = "CC0000823773"
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = Nothing
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = P_DtView1(i)("vndr_name") & " " & P_DtView1(i)("model_1") & " �C����"
                        dtRow("Expr13") = P_DtView1(i)("user_name") & " �l��"
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("rcpt_no")
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = Nothing

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "12"  '�f�I�f�I
                        dtRow("Expr01") = P_DtView1(i)("client_code")

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If DtView1.Count <> 0 Then dtRow("Expr02") = DtView1(0)("brch_name") Else dtRow("Expr02") = Nothing

                        dtRow("Expr03") = P_DtView1(i)("cust_code")
                        dtRow("Expr04") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr05") = P_DtView1(i)("rcpt_no")
                        dtRow("Expr06") = P_DtView1(i)("vndr_name")
                        dtRow("Expr07") = P_DtView1(i)("model_1")
                        dtRow("Expr08") = P_DtView1(i)("s_n")
                        dtRow("Expr09") = P_DtView1(i)("comp_eu_ttl")

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "13"  '�R�W�}
                        Ans = MessageBox.Show("�V�����f�U�C���ň�����܂����H" & System.Environment.NewLine & "�Â��f�U�C���̏ꍇ�́u�������v", "�I��", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If Ans = "6" Then
                            dtRow("Expr01") = P_DtView1(i)("store_repr_no")
                            dtRow("Expr02") = P_DtView1(i)("cust_code")
                            dtRow("Expr03") = P_DtView1(i)("dlvr_name") & "�@�䒆"

                            '�����
                            SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram2.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print02")
                            DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            If P_DtView1(0)("sub_code") = "00" Then
                                WK_str = DtView1(0)("comp_name")
                            Else
                                WK_str = P_DtView1(0)("sub_name")
                            End If
                            WK_str = WK_str.Replace("�������", "��")
                            dtRow("Expr04") = WK_str
                            dtRow("Expr05") = DtView1(0)("brch_name")
                            dtRow("Expr06") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                            dtRow("Expr07") = DtView1(0)("tel")
                            dtRow("Expr08") = DtView1(0)("fax")

                            dtRow("Expr09") = P_DtView1(i)("vndr_name")
                            dtRow("Expr10") = P_DtView1(i)("model_1")
                            dtRow("Expr11") = P_DtView1(i)("comp_eu_ttl")
                            dtRow("Expr12") = P_DtView1(i)("user_name")
                            dtRow("Expr13") = P_DtView1(i)("rcpt_no")
                        Else
                            ''��t���e�f�[�^
                            'SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
                            'SqlCmd1.CommandType = CommandType.StoredProcedure
                            'Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            'Pram3.Value = rcpt_no
                            'DaList1.SelectCommand = SqlCmd1
                            'DaList1.Fill(P_DsPRT, "Print03")

                            '���ϓ��e�f�[�^
                            SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_2", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram4.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print04")

                            '���i�f�[�^
                            SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram5.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print05")

                            '�C�����e�f�[�^
                            SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_2", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram6 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram6.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print06")

                            dtRow("Expr01") = P_DtView1(i)("dlvr_name")
                            dtRow("Expr02") = P_DtView1(i)("cust_code")
                            dtRow("Expr03") = P_DtView1(i)("client_code")

                            '�����
                            SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram2.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print02")
                            DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            If P_DtView1(0)("sub_code") = "00" Then
                                WK_str = DtView1(0)("comp_name")
                            Else
                                WK_str = P_DtView1(0)("sub_name")
                            End If
                            WK_str = WK_str.Replace("�������", "��")
                            dtRow("Expr04") = WK_str
                            dtRow("Expr05") = DtView1(0)("brch_name")
                            dtRow("Expr06") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                            dtRow("Expr07") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                            dtRow("Expr08") = P_DtView1(i)("vndr_name")
                            dtRow("Expr09") = P_DtView1(i)("comp_meas")
                            dtRow("Expr10") = P_DtView1(i)("repr_empl_name")
                            dtRow("Expr11") = P_DtView1(i)("comp_eu_part_chrg")
                            dtRow("Expr12") = P_DtView1(i)("comp_eu_tech_chrg")
                            dtRow("Expr13") = P_DtView1(i)("comp_eu_ttl")
                            dtRow("Expr14") = P_DtView1(i)("etmt_meas")
                            dtRow("Expr15") = P_DtView1(i)("rcpt_no")
                            dtRow("Expr20") = P_DtView1(i)("note_kbn")
                        End If

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Else  '�ʏ�
                        dtRow("Expr01") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '�����
                        SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram2.Value = rcpt_no
                        DaList1.SelectCommand = SqlCmd1
                        DaList1.Fill(P_DsPRT, "Print02")
                        DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        If P_DtView1(0)("sub_code") = "00" Then
                            WK_str = DtView1(0)("comp_name")
                        Else
                            WK_str = P_DtView1(0)("sub_name")
                        End If
                        WK_str = WK_str.Replace("�������", "��")
                        dtRow("Expr06") = Nothing
                        dtRow("Expr07") = WK_str & " " & DtView1(0)("brch_name")
                        dtRow("Expr08") = "��" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr11") = P_DtView1(i)("vndr_name")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("rcpt_no")
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = P_DtView1(i)("user_name") & " �l��"

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                End Select
                dttable.Rows.Add(dtRow)
            Next
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
            strSQL += " (rcpt_no, NEVA)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("NEVA")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET NEVA = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("02")   '**  �v�����^���擾

        Select Case P_DtView1(0)("dlvr_rprt_ptn") '����p�^�[��
            Case Is = "12"  '�f�I�f�I
                Dim rpt As New R_NEVA_DEODEO
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�l�o�` �f�I�f�I"
                    rpt.Document.Print(False, False, False)
                End If
            Case Is = "13"  '�R�W�}
                If Ans = "6" Then
                    Dim rpt As New R_NEVA_New_kojima
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.PageSettings.Margins.Top = P_uppr_mrgn
                    rpt.PageSettings.Margins.Left = P_left_mrgn
                    rpt.Run(False)

                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�l�o�` new�R�W�}"
                        rpt.Document.Print(False, False, False)
                    End If
                Else
                    Dim rpt As New R_NEVA_Kojima
                    rpt.DataSource = P_DsPRT
                    rpt.DataMember = "Print01"
                    rpt.PageSettings.Margins.Top = P_uppr_mrgn
                    rpt.PageSettings.Margins.Left = P_left_mrgn
                    rpt.Run(False)

                    If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                        If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                            System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                        End If
                        PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                    Else
                        If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                        rpt.Document.Name = "�l�o�` �R�W�}"
                        rpt.Document.Print(False, False, False)
                    End If
                End If
            Case Else   '�ʏ� 
                Dim rpt As New R_NEVA
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)

                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�l�o�`" & P_DtView1(0)("dlvr_rprt_ptn")
                    rpt.Document.Print(False, False, False)
                End If
        End Select

        add_hsty(rcpt_no, "�l�o�`���", "", "")

        P1_F00_Form07_2 = "10"  '�l�o�`����

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  �`�F�[���X�g�A�`�[ (R_CSTD)
    '********************************************************************
    Public Function Print_R_chain(ByVal rcpt_no)
        On Error GoTo err

        Dim out_seq(12) As String   '����z�u��
        Dim aka As String = "0"
        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_NEVA_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(P_DsPRT, "WK_Print02")
        DB_CLOSE()
        P_DtView1 = New DataView(P_DsPRT.Tables("WK_Print02"), "", "", DataViewRowState.CurrentRows)

        If P_DtView1.Count <> 0 Then

            If P_DtView1(0)("comp_shop_ttl") < 0 Then
                aka = "1"
                P_DtView1(0)("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl") * -1
                P_DtView1(0)("comp_shop_tax") = P_DtView1(0)("comp_shop_tax") * -1
            End If

            strSQL = "SELECT '' AS seikyo, '' AS dlvr_name, '' AS dlvr_CODE, '' AS client_code, '' AS comp_name, '' AS mngr_empl_name"
            strSQL += ", '' AS brch_name, '' AS adrs, '' AS tel, '' AS fax, '' AS accp_date, '' AS comp_date"
            strSQL += ", '' AS vndr_name, '' AS rpar_cls_name, '' AS rcpt_no, '' AS user_name, '' AS model_1, '' AS s_n"
            strSQL += ", '' AS comp_shop_ttl, '' AS HSY_name, '' AS cust_code"
            strSQL += ", '' AS Expr01, '' AS Expr02, '' AS Expr03, '' AS Expr04, '' AS Expr05"
            strSQL += ", '' AS Expr06, '' AS Expr07, '' AS Expr08, '' AS Expr09, '' AS Expr10"
            strSQL += ", '' AS Expr11, '' AS Expr12"
            strSQL += ", '' AS Expr21, '' AS Expr22, '' AS Expr23, '' AS Expr24, '' AS Expr25"
            strSQL += ", '' AS Expr26, '' AS Expr27, '' AS Expr28, '' AS Expr29"
            strSQL += ", '' AS Expr31, '' AS Expr32, '' AS Expr33, '' AS Expr34, '' AS Expr35"
            strSQL += ", '' AS Expr36, '' AS Expr37, '' AS Expr38"
            strSQL += ", '' AS Expr31_2, '' AS Expr31_3, '' AS Expr31_4"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(P_DsPRT, "Print02")

            Select Case P_DtView1(0)("grup_code")   '�̎ЃO���[�v
                Case Is = "02", "89", "90", "96"                    '���̔̎ЃO���[�v�̓��x�[�g����
                    Select Case P_DtView1(0)("rpar_cls")    '�C�����
                        Case Is = "02"      '�@���[�J�[�ۏ�
                            If P_DtView1(0)("own_flg") = "1" And P_DtView1(0)("comp_shop_ttl") <> 0 And P_DtView1(0)("vndr_code") <> "01" Then '���ЏC��
                                out_seq(8) = "1"
                                P1_F00_Form07_2 = "00"  '�l�o�`����
                            Else
                                P1_F00_Form07_2 = "00"  '�l�o�`����
                            End If
                        Case Else           '�L��
                            Select Case P_DtView1(0)("rcpt_cls")    '��t���
                                Case Is = "02"  'QG-Care
                                    If P_DtView1(0)("grup_code") = "90" Then  '�A
                                        If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '���x�I�[�o�[
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '���Y����
                                                out_seq(1) = "1"
                                                out_seq(4) = "1"
                                                P1_F00_Form07_2 = "11"  '�l�o�`����
                                            Else                                            '�ʏ�̏�
                                                out_seq(1) = "1"
                                                out_seq(5) = "1"
                                                P1_F00_Form07_2 = "11"  '�l�o�`����
                                            End If
                                        Else                                                                                                    '���x��
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '���Y����
                                                out_seq(1) = "1"
                                                out_seq(3) = "1"
                                                P1_F00_Form07_2 = "11"  '�l�o�`����
                                            Else                                            '�ʏ�̏�
                                                out_seq(1) = "1"
                                                P1_F00_Form07_2 = "01"  '�l�o�`����
                                            End If
                                        End If
                                    Else
                                        If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '���x�I�[�o�[
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '���Y����
                                                out_seq(4) = "1"
                                                P1_F00_Form07_2 = "10"  '�l�o�`����
                                            Else                                            '�ʏ�̏�
                                                out_seq(5) = "1"
                                                P1_F00_Form07_2 = "10"  '�l�o�`����
                                            End If
                                        Else                                                                                                    '���x��
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '���Y����
                                                out_seq(3) = "1"
                                                P1_F00_Form07_2 = "10"  '�l�o�`����
                                            Else
                                                P1_F00_Form07_2 = "00"  '�l�o�`����
                                            End If
                                        End If

                                    End If
                                Case Is = "03"  '�����ۏ�
                                    Select Case P_DtView1(0)("grup_code")    '�̎ЃO���[�v
                                        Case Is = "02", "90"
                                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '���x�I�[�o�[
                                                out_seq(1) = "1"
                                                out_seq(5) = "1"
                                                P1_F00_Form07_2 = "11"  '�l�o�`����
                                            Else
                                                out_seq(1) = "1"
                                                P1_F00_Form07_2 = "01"  '�l�o�`����
                                            End If
                                        Case Else
                                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '���x�I�[�o�[
                                                out_seq(9) = "1"
                                                P1_F00_Form07_2 = "10"  '�l�o�`����
                                            Else
                                                out_seq(1) = "1"
                                                P1_F00_Form07_2 = "01"  '�l�o�`����
                                            End If
                                    End Select
                                Case Else       '���̑�
                                    If P_DtView1(0)("grup_code") = "89" Then
                                        out_seq(9) = "1"
                                        P1_F00_Form07_2 = "10"  '�l�o�`����
                                    Else
                                        If P_DtView1(0)("vndr_code") = "01" And P_DtView1(0)("note_kbn") = "01" Then 'Apple Note
                                            out_seq(9) = "1"
                                            P1_F00_Form07_2 = "10"  '�l�o�`����
                                        Else
                                            out_seq(6) = "1"
                                            P1_F00_Form07_2 = "10"  '�l�o�`����
                                        End If
                                    End If
                            End Select
                    End Select

                Case Is = "88"                                      '�x�m�ʕی�
                    If P_DtView1(0)("rcpt_cls") = "10" Then
                        If exp_part(rcpt_no) = "2" Then     '���Օi�Ȃ�
                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") - RoundDOWN(P_exp_amt * Wk_TAX_1, 0) Then '���x�I�[�o�[
                                out_seq(10) = "1"           '���Օi�Ȃ��ŃI�[�o�[
                            Else
                                out_seq(9) = "1"            '���Օi�Ȃ��Ō��x��
                            End If
                        Else                                '���Օi����
                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") - RoundDOWN(P_exp_amt * Wk_TAX_1, 0) Then '���x�I�[�o�[
                                out_seq(11) = "1"           '���Օi����ŃI�[�o�[
                            Else
                                out_seq(12) = "1"           '���Օi����Ō��x��
                            End If
                        End If
                    Else
                        out_seq(9) = "1"
                    End If
                    P1_F00_Form07_2 = "10"  '�l�o�`����

                Case Else
                    out_seq(9) = "1"
                    P1_F00_Form07_2 = "10"  '�l�o�`����
            End Select

            Dim WK_str1, WK_str2 As String
            If P_DtView1(0)("own_flg") = "True" Then WK_str1 = "True" Else WK_str1 = "False"
            rebate_idvd_Get(P_DtView1(0)("store_code"), P_DtView1(0)("rpar_cls"), P_DtView1(0)("rcpt_cls"), RoundDOWN(P_DtView1(0)("wrn_limt_amnt") / Wk_TAX_1, 0), P_DtView1(0)("menseki_amnt"), P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax"), P_DtView1(0)("comp_shop_ttl"), WK_str1, P_DtView1(0)("vndr_code"), P_DtView1(0)("note_kbn"))
            If P_chn_F = "1" Then
                P_idvd = P_DtView1(0)("comp_shop_ttl")
            End If

            printer = PRT_GET("03")   '**  �v�����^���擾

            Select Case P_DtView1(0)("dlvr_rprt_ptn") '����p�^�[��
                Case Is = "01"  '�S������ �_�ˎ��ƘA��
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '�[�i�於
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '�[�i��R�[�h
                    dtRow("client_code") = P_DtView1(0)("client_code")  '�����R�[�h
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '�X�܃R�[�h

                    '�����
                    SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram2.Value = rcpt_no
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(P_DsPRT, "Print04")
                    DB_CLOSE()
                    DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
                    If P_DtView1(0)("sub_code") = "00" Then
                        WK_str = DtView1(0)("comp_name")
                    Else
                        WK_str = P_DtView1(0)("sub_name")
                    End If
                    WK_str = WK_str.Replace("�������", "��")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")          'QG�}�l�[�W���[
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                         '��Ж�
                    dtRow("brch_name") = DtView1(0)("brch_name")                        'QG��
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")     'QG�Z��
                    dtRow("tel") = DtView1(0)("tel")                                    'QG�d�b
                    dtRow("fax") = DtView1(0)("fax")                                    'QG�t�@�b�N�X
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")  '��t��
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")  '������

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")                      '���[�J�[
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")              '�C���敪
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                          '��t�ԍ�
                    dtRow("user_name") = P_DtView1(0)("user_name")                      '���q�l��
                    dtRow("model_1") = P_DtView1(0)("model_1")                          '�@��

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                   '��t���
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@����Я�"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@���Y�ۏ�"
                                'End If
                            Else
                                WK_DsList1.Clear()
                                strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                                strSQL += " FROM T01_member LEFT OUTER JOIN"
                                strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                                strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("QGCare")
                                DaList1.Fill(WK_DsList1, "T01_member")
                                DB_CLOSE()
                                DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                                dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                            End If
                        Else
                            WK_DsList1.Clear()
                            strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                            strSQL += " FROM T01_member LEFT OUTER JOIN"
                            strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                            strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("QGCare")
                            DaList1.Fill(WK_DsList1, "T01_member")
                            DB_CLOSE()
                            DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                            dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")                  '���z
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            WK_DtView1(0)("Expr01") = "�_�ˎ��ƘA��"
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")            '�[�i�於
                            WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")            '�X�܃R�[�h
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")          '�����R�[�h
                            WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")       'QG�}�l�[�W���[
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")            '��Ж�
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")            'QG��
                            WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")                 'QG�Z��
                            WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")                  'QG�d�b
                            WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")                  'QG�t�@�b�N�X
                            WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")            '��t��
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")            '������
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                      '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"                '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                      '�@��
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"     '��t���
                                    Else
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@�戵�萔����"    '��t���
                                    End If
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing
                                Case Is = 3
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                  '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"            '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                  '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@���ȕ��S��"      '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & WK_mnsk
                                    Else
                                        WK_DtView1(0)("Expr31") = "\-" & WK_mnsk
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 4
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("user_name") & " �l���j" '���[�J�[�A���q�l��
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = "QG-Care ����Я�"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") & " " & WK_DtView1(0)("rcpt_no")     '��t�ԍ�
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = "�Ɛӊz"
                                    WK_DtView1(0)("Expr29") = "���x���ߊz"
                                    WK_DtView1(0)("Expr31") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31_2") = "\" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & P_idvd
                                        WK_DtView1(0)("Expr33") = "\" & P_idvd - CInt(WK_mnsk)
                                    Else
                                        WK_DtView1(0)("Expr31_2") = "\-" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & P_idvd * -1
                                        WK_DtView1(0)("Expr33") = "\" & (P_idvd - CInt(WK_mnsk)) * -1
                                    End If
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr34") = Nothing
                                    WK_DtView1(0)("Expr35") = "1"
                                    WK_DtView1(0)("Expr36") = "1"
                                    WK_DtView1(0)("Expr37") = "2"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 5
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"    '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"        '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 6
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"    '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"        '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 8
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                  '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"            '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                  '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"     '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                Case Is = 9
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"    '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"        '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 10
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"    '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"        '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 11
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"    '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"        '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 12
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"    '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"        '��t���
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                            End Select
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)

                            Dim rpt As New R_CSTD_Normal
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print02"
                            rpt.PageSettings.Margins.Top = P_uppr_mrgn
                            rpt.PageSettings.Margins.Left = P_left_mrgn
                            rpt.Run(False)

                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�`�F�[���X�g�A�`�[ �S������ �_�ˎ��ƘA��" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Is = "02"  '�P��(���)
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '�[�i�於
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '�[�i��R�[�h
                    dtRow("client_code") = P_DtView1(0)("client_code")  '�����R�[�h
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '�X�܃R�[�h

                    '�����
                    SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram2.Value = rcpt_no
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(P_DsPRT, "Print04")
                    DB_CLOSE()
                    DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
                    If P_DtView1(0)("sub_code") = "00" Then
                        WK_str = DtView1(0)("comp_name")
                    Else
                        WK_str = P_DtView1(0)("sub_name")
                    End If
                    WK_str = WK_str.Replace("�������", "��")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")  'QG�}�l�[�W���[
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                             '��Ж�
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG��
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")         'QG�Z��
                    dtRow("tel") = DtView1(0)("tel")                                        'QG�d�b
                    dtRow("fax") = DtView1(0)("fax")                                        'QG�t�@�b�N�X
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")      '��t��
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '������

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '��t�ԍ�
                    dtRow("user_name") = P_DtView1(0)("user_name")                          '���q�l��
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '�@��

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                       '��t���
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@����Я�"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@���Y�ۏ�"
                                'End If
                            Else
                                WK_DsList1.Clear()
                                strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                                strSQL += " FROM T01_member LEFT OUTER JOIN"
                                strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                                strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("QGCare")
                                DaList1.Fill(WK_DsList1, "T01_member")
                                DB_CLOSE()
                                DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                                dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                            End If
                        Else
                            WK_DsList1.Clear()
                            strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                            strSQL += " FROM T01_member LEFT OUTER JOIN"
                            strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                            strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("QGCare")
                            DaList1.Fill(WK_DsList1, "T01_member")
                            DB_CLOSE()
                            DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                            dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")              '���z
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            WK_DtView1(0)("Expr01") = Nothing
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '�[�i�於
                            WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")        '�X�܃R�[�h
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '�����R�[�h
                            WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")   'QG�}�l�[�W���[
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '��Ж�
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG��
                            WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")             'QG�Z��
                            WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")              'QG�d�b
                            WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")              'QG�t�@�b�N�X
                            WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")        '��t��
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '������
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                      '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"                '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                      '�@��
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"     '��t���
                                    Else
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@�戵�萔����"    '��t���
                                    End If
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                Case Is = 3
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & WK_mnsk
                                    Else
                                        WK_DtView1(0)("Expr31") = "\-" & WK_mnsk
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 4
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("user_name") & " �l���j" '���[�J�[�A���q�l��
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = "QG-Care ����Я�"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") & " " & WK_DtView1(0)("rcpt_no")                          '��t�ԍ�
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = "�Ɛӊz"
                                    WK_DtView1(0)("Expr29") = "���x���ߊz"
                                    WK_DtView1(0)("Expr31") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31_2") = "\" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & P_idvd
                                        WK_DtView1(0)("Expr33") = "\" & P_idvd - CInt(WK_mnsk)
                                    Else
                                        WK_DtView1(0)("Expr31_2") = "\-" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & P_idvd * -1
                                        WK_DtView1(0)("Expr33") = "\" & (P_idvd - CInt(WK_mnsk)) * -1
                                    End If
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr34") = Nothing
                                    WK_DtView1(0)("Expr35") = "1"
                                    WK_DtView1(0)("Expr36") = "1"
                                    WK_DtView1(0)("Expr37") = "2"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 5
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 6
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 8
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                              '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & P_DtView1(0)("user_name") & "�@�l���j"         '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                              '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                Case Is = 9
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 10
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 11
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 12
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                            End Select
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)

                            Dim rpt As New R_CSTD_Normal
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print02"
                            rpt.PageSettings.Margins.Top = P_uppr_mrgn
                            rpt.PageSettings.Margins.Left = P_left_mrgn
                            rpt.Run(False)

                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�`�F�[���X�g�A�`�[ �P��(���)" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Is = "03"  '�S������(���)
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '�[�i�於
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '�[�i��R�[�h
                    dtRow("client_code") = P_DtView1(0)("client_code")  '�����R�[�h
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '�X�܃R�[�h

                    '�����
                    SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram2.Value = rcpt_no
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(P_DsPRT, "Print04")
                    DB_CLOSE()
                    DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
                    If P_DtView1(0)("sub_code") = "00" Then
                        WK_str = DtView1(0)("comp_name")
                    Else
                        WK_str = P_DtView1(0)("sub_name")
                    End If
                    WK_str = WK_str.Replace("�������", "��")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")              'QG�}�l�[�W���[
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                             '��Ж�
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG��
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")         'QG�Z��
                    dtRow("tel") = DtView1(0)("tel")                                        'QG�d�b
                    dtRow("fax") = DtView1(0)("fax")                                        'QG�t�@�b�N�X
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")      '��t��
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '������

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '��t�ԍ�
                    dtRow("user_name") = P_DtView1(0)("user_name")                          '���q�l��
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '�@��

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                       '��t���
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@����Я�"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@���Y�ۏ�"
                                'End If
                            Else
                                WK_DsList1.Clear()
                                strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                                strSQL += " FROM T01_member LEFT OUTER JOIN"
                                strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                                strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("QGCare")
                                DaList1.Fill(WK_DsList1, "T01_member")
                                DB_CLOSE()
                                DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                                dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                            End If
                        Else
                            WK_DsList1.Clear()
                            strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                            strSQL += " FROM T01_member LEFT OUTER JOIN"
                            strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                            strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("QGCare")
                            DaList1.Fill(WK_DsList1, "T01_member")
                            DB_CLOSE()
                            DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                            dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")              '���z
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            'WK_DtView1(0)("Expr01") = WK_DtView1(0)("seikyo")           '��w��
                            WK_DtView1(0)("Expr01") = WK_DtView1(0)("dlvr_name")        '�[�i�於
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '�[�i�於
                            WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")        '�X�܃R�[�h
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '�����R�[�h
                            WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")   'QG�}�l�[�W���[
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '��Ж�
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG��
                            WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")             'QG�Z��
                            WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")              'QG�d�b
                            WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")              'QG�t�@�b�N�X
                            WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")        '��t��
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '������
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                      '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"                '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                      '�@��
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"     '��t���
                                    Else
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@�戵�萔����"    '��t���
                                    End If
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                Case Is = 3
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & WK_mnsk
                                    Else
                                        WK_DtView1(0)("Expr31") = "\-" & WK_mnsk
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 4
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("user_name") & " �l���j" '���[�J�[�A���q�l��
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = "QG-Care ����Я�"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") & " " & WK_DtView1(0)("rcpt_no")     '��t�ԍ�
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = "�Ɛӊz"
                                    WK_DtView1(0)("Expr29") = "���x���ߊz"
                                    WK_DtView1(0)("Expr31") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31_2") = "\" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & P_idvd
                                        WK_DtView1(0)("Expr33") = "\" & P_idvd - CInt(WK_mnsk)
                                    Else
                                        WK_DtView1(0)("Expr31_2") = "\-" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & P_idvd * -1
                                        WK_DtView1(0)("Expr33") = "\" & (P_idvd - CInt(WK_mnsk)) * -1
                                    End If
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr34") = Nothing
                                    WK_DtView1(0)("Expr35") = "1"
                                    WK_DtView1(0)("Expr36") = "1"
                                    WK_DtView1(0)("Expr37") = "2"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 5
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 6
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 8
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                Case Is = 9
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 10
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 11
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 12
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr24") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                            End Select
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)

                            Dim rpt As New R_CSTD_Normal
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print02"
                            rpt.PageSettings.Margins.Top = P_uppr_mrgn
                            rpt.PageSettings.Margins.Left = P_left_mrgn
                            rpt.Run(False)

                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�`�F�[���X�g�A�`�[ �S������(���)" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Is = "04"  '���s���ƘA��
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")          '�[�i�於
                    dtRow("client_code") = P_DtView1(0)("client_code")      '�����R�[�h

                    '�����
                    SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram2.Value = rcpt_no
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(P_DsPRT, "Print04")
                    DB_CLOSE()
                    DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
                    If P_DtView1(0)("sub_code") = "00" Then
                        WK_str = DtView1(0)("comp_name")
                    Else
                        WK_str = P_DtView1(0)("sub_name")
                    End If
                    WK_str = WK_str.Replace("�������", "��")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    dtRow("comp_name") = WK_str                                             '��Ж�
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG��
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '������

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")                          '���[�J�[
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")                  '�C���敪
                    dtRow("user_name") = P_DtView1(0)("user_name")                          '���q�l��
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '�@��
                    dtRow("s_n") = P_DtView1(0)("s_n")                                      's/n
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '��t�ԍ�

                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_eu_ttl")                    '���z
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '�[�i�於
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '�����R�[�h
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '��Ж�
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG��
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '������
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If

                                Case Is = 3
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & WK_mnsk
                                    Else
                                        WK_DtView1(0)("Expr31") = "\-" & WK_mnsk
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 4
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & RoundUP((P_DtView1(0)("comp_eu_ttl") + P_DtView1(0)("comp_eu_tax") - P_DtView1(0)("wrn_limt_amnt")) / Wk_TAX_1, 0) + CInt(WK_mnsk)
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & (RoundUP((P_DtView1(0)("comp_eu_ttl") + P_DtView1(0)("comp_eu_tax") - P_DtView1(0)("wrn_limt_amnt")) / Wk_TAX_1, 0) + CInt(WK_mnsk)) * -1
                                    End If

                                Case Is = 5
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 6
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 8
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If

                                Case Is = 9
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 10
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 11
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 12
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                            End Select
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)

                            Dim rpt As New R_CSTD_Tankyo_KyotoJiren
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print02"
                            rpt.PageSettings.Margins.Top = P_uppr_mrgn
                            rpt.PageSettings.Margins.Left = P_left_mrgn
                            rpt.Run(False)

                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�`�F�[���X�g�A�`�[ ���s���ƘA��" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Else       '�ʏ�
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '�[�i�於
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '�[�i��R�[�h
                    dtRow("client_code") = P_DtView1(0)("client_code")  '�����R�[�h
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '�X�܃R�[�h

                    '�����
                    SqlCmd1 = New SqlClient.SqlCommand("sp_GET_brch", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram2.Value = rcpt_no
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    DaList1.Fill(P_DsPRT, "Print04")
                    DB_CLOSE()
                    DtView1 = New DataView(P_DsPRT.Tables("Print04"), "", "", DataViewRowState.CurrentRows)
                    If P_DtView1(0)("sub_code") = "00" Then
                        WK_str = DtView1(0)("comp_name")
                    Else
                        WK_str = P_DtView1(0)("sub_name")
                    End If
                    WK_str = WK_str.Replace("�������", "��")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")              'QG�}�l�[�W���[
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                             '��Ж�
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG��
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")         'QG�Z��
                    dtRow("tel") = DtView1(0)("tel")                                        'QG�d�b
                    dtRow("fax") = DtView1(0)("fax")                                        'QG�t�@�b�N�X
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")      '��t��
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '������

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")                          '���[�J�[
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")                  '�C���敪
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '��t�ԍ�
                    dtRow("user_name") = P_DtView1(0)("user_name")                          '���q�l��
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '�@��

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                       '��t���
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@����Я�"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "�@���Y�ۏ�"
                                'End If
                            Else
                                WK_DsList1.Clear()
                                strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                                strSQL += " FROM T01_member LEFT OUTER JOIN"
                                strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                                strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("QGCare")
                                DaList1.Fill(WK_DsList1, "T01_member")
                                DB_CLOSE()
                                DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                                dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                            End If
                        Else
                            WK_DsList1.Clear()
                            strSQL = "SELECT T01_member.*, V_M02_HSY.cls_code_name AS wrn_range_name"
                            strSQL += " FROM T01_member LEFT OUTER JOIN"
                            strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                            strSQL += " WHERE (T01_member.code = '" & P_DtView1(0)("qg_care_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("QGCare")
                            DaList1.Fill(WK_DsList1, "T01_member")
                            DB_CLOSE()
                            DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                            dtRow("HSY_name") = dtRow("HSY_name") & "�@" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")          '���z
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        'WK_DtView1(0)("Expr01") = WK_DtView1(0)("seikyo")           '��w��
                        WK_DtView1(0)("Expr01") = WK_DtView1(0)("dlvr_name")        '�[�i�於
                        WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '�[�i�於
                        WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")        '�X�܃R�[�h
                        WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '�����R�[�h
                        WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")   'QG�}�l�[�W���[
                        WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '��Ж�
                        WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG��
                        WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")             'QG�Z��
                        WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")              'QG�d�b
                        WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")              'QG�t�@�b�N�X
                        WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")        '��t��
                        WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '������
                        If out_seq(i) = "1" Then
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                                      '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"                '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                                      '�@��
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"     '��t���
                                    Else
                                        WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@�戵�萔����"    '��t���
                                    End If
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                Case Is = 3
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@���Y�ۏ؁@���ȕ��S��"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & WK_mnsk
                                    Else
                                        WK_DtView1(0)("Expr31") = "\-" & WK_mnsk
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 4
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("user_name") & " �l���j" '���[�J�[�A���q�l��
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "QG-Care ����Я�"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") '& " " & WK_DtView1(0)("rcpt_no")     '��t�ԍ�
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = "�Ɛӊz"
                                    WK_DtView1(0)("Expr29") = "���x���ߊz"
                                    WK_DtView1(0)("Expr31") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31_2") = "\" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & P_idvd - CInt(WK_mnsk)
                                        WK_DtView1(0)("Expr33") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31_2") = "\-" & WK_mnsk
                                        WK_DtView1(0)("Expr31_3") = "\" & (P_idvd - CInt(WK_mnsk)) * -1
                                        WK_DtView1(0)("Expr33") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr34") = Nothing
                                    WK_DtView1(0)("Expr35") = "1"
                                    WK_DtView1(0)("Expr36") = "1"
                                    WK_DtView1(0)("Expr37") = "2"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 5
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 6
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 8
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@����Я��@�戵�萔����"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "��" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "�@" & P_rebate
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                Case Is = 9
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@���ȕ��S��"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 10
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") '& "�@���Օi"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_DtView1(0)("comp_shop_ttl") - RoundDOWN(P_DtView1(0)("wrn_limt_amnt") / Wk_TAX_1, 0)
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr31_4") = Nothing
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = Nothing

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 11
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@���Օi"
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_DtView1(0)("comp_shop_ttl") - (RoundDOWN(P_DtView1(0)("wrn_limt_amnt") / Wk_TAX_1, 0)) - P_exp_amt
                                        WK_DtView1(0)("Expr31_4") = "\" & P_exp_amt
                                        WK_DtView1(0)("Expr33") = "\" & P_DtView1(0)("comp_shop_ttl") - (RoundDOWN(P_DtView1(0)("wrn_limt_amnt") / Wk_TAX_1, 0)) - P_exp_amt + P_exp_amt
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                        WK_DtView1(0)("Expr31_4") = Nothing
                                        WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31")
                                    End If
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    WK_DtView1(0)("Expr34") = "1"
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "2"
                                    WK_DtView1(0)("Expr38") = "1"

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                                Case Is = 12
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " �C���i�i" & WK_DtView1(0)("rpar_cls_name") & "�j" '���[�J�[�A�C���敪
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '��t�ԍ�
                                    WK_DtView1(0)("Expr23") = "�i" & WK_DtView1(0)("user_name") & "�@�l���j"     '���q�l��
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '�@��
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "�@���Օi"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    WK_DtView1(0)("Expr31") = Nothing
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    If aka = "0" Then
                                        If exp_part(rcpt_no) = "1" Then     '���Օi�̂�
                                            WK_DtView1(0)("Expr31_4") = "\" & P_exp_amt + P_DtView1(0)("comp_shop_tech_chrg")
                                        Else
                                            WK_DtView1(0)("Expr31_4") = "\" & P_exp_amt
                                        End If
                                    Else
                                        WK_DtView1(0)("Expr31_4") = Nothing
                                    End If
                                    WK_DtView1(0)("Expr33") = WK_DtView1(0)("Expr31_4")
                                    WK_DtView1(0)("Expr34") = Nothing
                                    WK_DtView1(0)("Expr35") = Nothing
                                    WK_DtView1(0)("Expr36") = Nothing
                                    WK_DtView1(0)("Expr37") = "1"
                                    WK_DtView1(0)("Expr38") = "1"

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr33")

                            End Select
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)

                            Dim rpt As New R_CSTD_Normal
                            rpt.DataSource = P_DsPRT
                            rpt.DataMember = "Print02"
                            rpt.PageSettings.Margins.Top = P_uppr_mrgn
                            rpt.PageSettings.Margins.Left = P_left_mrgn
                            rpt.Run(False)

                            If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                                If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                                    System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                                End If
                                PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                            Else
                                If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                                rpt.Document.Name = "�`�F�[���X�g�A�`�[" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

            End Select

            P_HSTY_DATE = Now
            DB_OPEN("nMVAR")
            '������t
            strSQL = "SELECT * FROM T06_PRNT_DATE WHERE (rcpt_no = '" & rcpt_no & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "T06_PRNT_DATE")
            DtView1 = New DataView(DsList1.Tables("T06_PRNT_DATE"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                strSQL = "INSERT INTO T06_PRNT_DATE"
                strSQL += " (rcpt_no, NEVA)"
                strSQL += " VALUES ('" & rcpt_no & "'"
                strSQL += ", '" & P_HSTY_DATE & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Else
                If IsDBNull(DtView1(0)("NEVA")) Then
                    strSQL = "UPDATE T06_PRNT_DATE"
                    strSQL += " SET NEVA = '" & P_HSTY_DATE & "'"
                    strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If
            End If
            DB_CLOSE()

            add_hsty(rcpt_no, "�`�F�[���X�g�A�`�[���", "", "")
        End If

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  ����� (R_Haiso)
    '********************************************************************
    Public Function Print_R_Haiso(ByVal rcpt_no, ByVal prt_ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Haiso_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")
        DB_CLOSE()
        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)

        printer = PRT_GET("04")   '**  �v�����^���擾

        Select Case prt_ptn
            Case Is = "01"
                Dim rpt As New R_Haiso_Meitetu_Ren_EU_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "02"
                Dim rpt As New R_Haiso_Meitetu_Ren_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "03"
                Dim rpt As New R_Haiso_Meitetu_Ren_Hansya_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "04"
                Dim rpt As New R_Haiso_Meitetu_Ren_Hansya_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "05"
                Dim rpt As New R_Haiso_Sagawa_GwNote
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "06"
                Dim rpt As New R_Haiso_Seibu_Tan_EU_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "07"
                Dim rpt As New R_Haiso_Seibu_Tan_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "08"
                Dim rpt As New R_Haiso_Seibu_Tan_Hansya_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "09"
                Dim rpt As New R_Haiso_Seibu_Tan_Hansya_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "10"
                Dim rpt As New R_Haiso_SuperPerikan_Ren_EU_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "11"
                Dim rpt As New R_Haiso_SuperPerikan_Ren_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "12"
                Dim rpt As New R_Haiso_SuperPerikan_Ren_Hansya_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "13"
                Dim rpt As New R_Haiso_SuperPerikan_Ren_Hansya_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "14"
                Dim rpt As New R_Haiso_SuperPerikan_Tan_EU_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "15"
                Dim rpt As New R_Haiso_SuperPerikan_Tan_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "16"
                Dim rpt As New R_Haiso_SuperPerikan_Tan_Hansya_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "17"
                Dim rpt As New R_Haiso_SuperPerikan_Tan_Hansya_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "18"
                Dim rpt As New R_Haiso_ToToshiba_Seibu_Ren
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "19"
                Dim rpt As New R_Haiso_Yamato_Ren_EU_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "20"
                Dim rpt As New R_Haiso_Yamato_Ren_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "21"
                Dim rpt As New R_Haiso_Yamato_Ren_Hansya_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "22"
                Dim rpt As New R_Haiso_Yamato_Ren_Hansya_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "23"
                Dim rpt As New R_Haiso_Fukuyama_Ren_EU_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "24"
                Dim rpt As New R_Haiso_Fukuyama_Ren_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "25"
                Dim rpt As New R_Haiso_Fukuyama_Ren_Hansya_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "26"
                Dim rpt As New R_Haiso_Fukuyama_Ren_Hansya_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "27"
                Dim rpt As New R_Haiso_Nittsu_Ren_EU_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "28"
                Dim rpt As New R_Haiso_Nittsu_Ren_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "29"
                Dim rpt As New R_Haiso_Nittsu_Ren_Hansya_QG
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "30"
                Dim rpt As New R_Haiso_Nittsu_Ren_Hansya_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
                    rpt.Document.Print(False, False, False)
                End If

            Case Is = "31"
                Dim rpt As New R_Haiso_Yamato_DOS_EU_QGX
                rpt.DataSource = P_DsPRT
                rpt.DataMember = "Print01"
                rpt.PageSettings.Margins.Top = P_uppr_mrgn
                rpt.PageSettings.Margins.Left = P_left_mrgn
                rpt.Run(False)
                If P_mojibake = "True" And P_PC_NAME2 <> "" Then
                    If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                        System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
                    End If
                    PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
                Else
                    If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
                    rpt.Document.Name = "�����"
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
    '**  �b�b�`�q (R_NCR_CCAR)
    '********************************************************************
    Public Function Print_R_NCR_CCAR(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        '���C���f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_NCR_CCAR", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        P_DtView1(0)("adrs1") = P_DtView1(0)("adrs1") & " " & P_DtView1(0)("adrs2")

        '���i�f�[�^
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
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
            strSQL += " (rcpt_no, CCAR)"
            strSQL += " VALUES ('" & rcpt_no & "'"
            strSQL += ", '" & P_HSTY_DATE & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else
            If IsDBNull(DtView1(0)("CCAR")) Then
                strSQL = "UPDATE T06_PRNT_DATE"
                strSQL += " SET CCAR = '" & P_HSTY_DATE & "'"
                strSQL += " WHERE (rcpt_no = '" & rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If
        DB_CLOSE()

        printer = PRT_GET("05")   '**  �v�����^���擾

        Dim rpt As New R_NCR_CCAR
        rpt.DataSource = P_DsPRT
        rpt.DataMember = "Print01"
        rpt.PageSettings.Margins.Top = P_uppr_mrgn
        rpt.PageSettings.Margins.Left = P_left_mrgn
        rpt.Run(False)
        If P_mojibake = "True" And P_PC_NAME2 <> "" Then
            If System.IO.Directory.Exists("\\tsclient\C\nmvarpdf") = False Then
                System.IO.Directory.CreateDirectory("\\tsclient\C\nmvarpdf")
            End If
            PdfExport1.Export(rpt.Document, "\\tsclient\C\nmvarpdf\" & Format(Now, "yyyyMMddHHmmss") & printer & ".pdf")
        Else
            If PRT_CHK(printer) = "1" Then rpt.Document.Printer.PrinterName = printer
            rpt.Document.Name = "�b�b�`�q"
            rpt.Document.Print(False, False, False)
        End If

        add_hsty(rcpt_no, "�b�b�`�q���", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function
End Class                        