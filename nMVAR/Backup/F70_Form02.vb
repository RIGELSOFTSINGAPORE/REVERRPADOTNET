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

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
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
        Me.Text = "印刷中"

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F70_Form02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '消費税率
        Wk_TAX = tax_rate_get(Now) '消費税率取得
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0
        If Wk_TAX = "10" Then
            WK_mnsk = "4546"
        Else
            WK_mnsk = "4630"
        End If

        Select Case PRT_PRAM1
            Case Is = "Print_R_NEVA"                '**  ネバ伝 (R_NEVA)
                P4_F00_Form07_2 = 0
                Print_R_NEVA(PRT_PRAM2)

            Case Is = "Print_R_chain"               '**  チェーンストア伝票 (R_chain)
                P4_F00_Form07_2 = 0
                Print_R_chain(PRT_PRAM2)

            Case Is = "Print_R_Haiso"               '**  送り状 (R_Haiso)
                Print_R_Haiso(PRT_PRAM2, PRT_PRAM3)

            Case Is = "Print_R_NCR_CCAR"            '**  ＣＣＡＲ (R_NCR_CCAR)
                Print_R_NCR_CCAR(PRT_PRAM2)

                'Case Is = "Print_R_IBM_IW_Report"       '**  IBM保証報告書 (R_IBM_IW_Report)

                'Case Is = "Print_R_HP_Exc_TAG"          '**  Hp TAG印刷 (R_HP_Exc_TAG)

        End Select
        DsList1.Clear()
        P_DsPRT.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  ネバ伝 (R_NEVA)
    '********************************************************************
    Public Function Print_R_NEVA(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
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

                If P_DtView1(i)("grup_code") = "18" Or P_DtView1(i)("grup_code") = "52" Then   '販社グループが'18','52'なら計上を印字
                    P_DtView1(i)("comp_eu_ttl") = P_DtView1(i)("comp_shop_ttl")
                    P_DtView1(i)("comp_eu_part_chrg") = P_DtView1(i)("comp_shop_part_chrg")
                    P_DtView1(i)("comp_eu_tech_chrg") = P_DtView1(i)("comp_shop_tech_chrg")
                End If

                If P_DtView1(i)("rpar_cls") <> "01" Then   '有償以外
                    P_DtView1(i)("comp_cost_ttl") = 0
                    P_DtView1(i)("comp_shop_ttl") = 0
                    P_DtView1(i)("comp_eu_ttl") = 0
                    P_DtView1(i)("comp_eu_part_chrg") = 0
                    P_DtView1(i)("comp_eu_tech_chrg") = 0
                End If

                dttable = P_DsPRT.Tables("Print01")
                dtRow = dttable.NewRow
                Select Case P_DtView1(0)("dlvr_rprt_ptn") '印刷パターン

                    Case Is = "01"  'ビックカメラ
                        dtRow("Expr01") = "株式会社ソフマップ"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = Nothing
                        dtRow("Expr07") = WK_str & " " & DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = Nothing
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = P_DtView1(i)("vndr_name") & " 修理品"
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("rcpt_no")
                        If Not IsDBNull(P_DtView1(i)("store_accp_date")) Then
                            dtRow("Expr18") = "販社様受付日    " & Format(P_DtView1(i)("store_accp_date"), "yyyy年MM月dd日")
                        Else
                            dtRow("Expr18") = "販社様受付日    "
                        End If
                        dtRow("Expr19") = P_DtView1(i)("user_name") & " 様分"

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "02"  '石丸
                        dtRow("Expr01") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = Nothing
                        dtRow("Expr07") = WK_str & " " & DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr11") = Nothing
                        dtRow("Expr12") = P_DtView1(i)("vndr_name")
                        dtRow("Expr13") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("rcpt_no")
                        dtRow("Expr18") = P_DtView1(i)("model_1")
                        dtRow("Expr19") = Nothing

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "03"  'ミドリ電化
                        dtRow("Expr01") = "株式会社ミドリ電化"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
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
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "04"  'ヤマダ電機
                        dtRow("Expr01") = "株式会社ヤマダ電機"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
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
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = P_DtView1(i)("rpar_cls_name")
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "05"  'ＭＲＣ
                        dtRow("Expr01") = Nothing
                        dtRow("Expr02") = P_DtView1(i)("cust_code")
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr11") = Nothing
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("vndr_name")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "06"  'ケーズデンキ
                        dtRow("Expr01") = "ケーズデンキ"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "07"  'ベスト電器
                        dtRow("Expr01") = "株式会社 ベストサービス"
                        dtRow("Expr02") = P_DtView1(i)("cust_code")
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr11") = "18-52"
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = P_DtView1(i)("cust_code")
                        dtRow("Expr16") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "08"  'ニューテック
                        dtRow("Expr01") = "有限会社ニューテック"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = "マツヤデンキ"
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "09"  'ジョーシン大阪
                        dtRow("Expr01") = Nothing
                        dtRow("Expr02") = "6503"
                        dtRow("Expr03") = "修理センター"
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "10"  'ジョーシン埼玉
                        dtRow("Expr01") = "ジョーシンサービス株式会社"
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = "ジョーシンサービス㈱" & System.Environment.NewLine & "埼玉カスタマーセンター"
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = P_DtView1(i)("vndr_name")
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = Nothing
                        dtRow("Expr13") = P_DtView1(i)("model_1")
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = "管理番号 " & P_DtView1(i)("rcpt_no") '& "    Ref# "

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "11"  'エイデン
                        dtRow("Expr01") = "株式会社コムネット"
                        dtRow("Expr02") = "9396"
                        dtRow("Expr03") = "ＥＴＲＣ　様"
                        dtRow("Expr04") = "CC0000823773"
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = WK_str
                        dtRow("Expr07") = DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
                        dtRow("Expr09") = "TEL : " & DtView1(0)("tel") & " FAX : " & DtView1(0)("fax")

                        dtRow("Expr10") = Nothing
                        dtRow("Expr11") = P_DtView1(i)("store_repr_no")
                        dtRow("Expr12") = P_DtView1(i)("vndr_name") & " " & P_DtView1(i)("model_1") & " 修理代"
                        dtRow("Expr13") = P_DtView1(i)("user_name") & " 様分"
                        dtRow("Expr14") = P_DtView1(i)("comp_eu_ttl")
                        dtRow("Expr15") = Nothing
                        dtRow("Expr16") = Nothing
                        dtRow("Expr17") = P_DtView1(i)("rcpt_no")
                        dtRow("Expr18") = Nothing
                        dtRow("Expr19") = Nothing

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                    Case Is = "12"  'デオデオ
                        dtRow("Expr01") = P_DtView1(i)("client_code")

                        '取引先
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

                    Case Is = "13"  'コジマ
                        Ans = MessageBox.Show("新しいデザインで印刷しますか？" & System.Environment.NewLine & "古いデザインの場合は「いいえ」", "選択", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If Ans = "6" Then
                            dtRow("Expr01") = P_DtView1(i)("store_repr_no")
                            dtRow("Expr02") = P_DtView1(i)("cust_code")
                            dtRow("Expr03") = P_DtView1(i)("dlvr_name") & "　御中"

                            '取引先
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
                            WK_str = WK_str.Replace("株式会社", "㈱")
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
                            ''受付内容データ
                            'SqlCmd1 = New SqlClient.SqlCommand("sp_R_Azukari_Sheet_3", cnsqlclient)
                            'SqlCmd1.CommandType = CommandType.StoredProcedure
                            'Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            'Pram3.Value = rcpt_no
                            'DaList1.SelectCommand = SqlCmd1
                            'DaList1.Fill(P_DsPRT, "Print03")

                            '見積内容データ
                            SqlCmd1 = New SqlClient.SqlCommand("sp_R_Mitsumori_2", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram4.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print04")

                            '部品データ
                            SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram5.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print05")

                            '修理内容データ
                            SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_2", cnsqlclient)
                            SqlCmd1.CommandType = CommandType.StoredProcedure
                            Dim Pram6 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                            Pram6.Value = rcpt_no
                            DaList1.SelectCommand = SqlCmd1
                            DaList1.Fill(P_DsPRT, "Print06")

                            dtRow("Expr01") = P_DtView1(i)("dlvr_name")
                            dtRow("Expr02") = P_DtView1(i)("cust_code")
                            dtRow("Expr03") = P_DtView1(i)("client_code")

                            '取引先
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
                            WK_str = WK_str.Replace("株式会社", "㈱")
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

                    Case Else  '通常
                        dtRow("Expr01") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr02") = Nothing
                        dtRow("Expr03") = P_DtView1(i)("dlvr_name")
                        dtRow("Expr04") = P_DtView1(i)("client_code")
                        dtRow("Expr05") = Nothing

                        '取引先
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
                        WK_str = WK_str.Replace("株式会社", "㈱")
                        dtRow("Expr06") = Nothing
                        dtRow("Expr07") = WK_str & " " & DtView1(0)("brch_name")
                        dtRow("Expr08") = "〒" & Mid(DtView1(0)("zip"), 1, 3) & "-" & Mid(DtView1(0)("zip"), 4, 4) & " " & DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")
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
                        dtRow("Expr19") = P_DtView1(i)("user_name") & " 様分"

                        P4_F00_Form07_2 = P_DtView1(i)("comp_eu_ttl")

                End Select
                dttable.Rows.Add(dtRow)
            Next
        End If

        P_HSTY_DATE = Now
        '印刷日付
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

        printer = PRT_GET("02")   '**  プリンタ名取得

        Select Case P_DtView1(0)("dlvr_rprt_ptn") '印刷パターン
            Case Is = "12"  'デオデオ
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
                    rpt.Document.Name = "ネバ伝 デオデオ"
                    rpt.Document.Print(False, False, False)
                End If
            Case Is = "13"  'コジマ
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
                        rpt.Document.Name = "ネバ伝 newコジマ"
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
                        rpt.Document.Name = "ネバ伝 コジマ"
                        rpt.Document.Print(False, False, False)
                    End If
                End If
            Case Else   '通常 
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
                    rpt.Document.Name = "ネバ伝" & P_DtView1(0)("dlvr_rprt_ptn")
                    rpt.Document.Print(False, False, False)
                End If
        End Select

        add_hsty(rcpt_no, "ネバ伝印刷", "", "")

        P1_F00_Form07_2 = "10"  'ネバ伝枚数

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  チェーンストア伝票 (R_CSTD)
    '********************************************************************
    Public Function Print_R_chain(ByVal rcpt_no)
        On Error GoTo err

        Dim out_seq(12) As String   '印刷配置別
        Dim aka As String = "0"
        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()

        'メインデータ
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

            Select Case P_DtView1(0)("grup_code")   '販社グループ
                Case Is = "02", "89", "90", "96"                    'この販社グループはリベートあり
                    Select Case P_DtView1(0)("rpar_cls")    '修理種別
                        Case Is = "02"      '①メーカー保証
                            If P_DtView1(0)("own_flg") = "1" And P_DtView1(0)("comp_shop_ttl") <> 0 And P_DtView1(0)("vndr_code") <> "01" Then '自社修理
                                out_seq(8) = "1"
                                P1_F00_Form07_2 = "00"  'ネバ伝枚数
                            Else
                                P1_F00_Form07_2 = "00"  'ネバ伝枚数
                            End If
                        Case Else           '有償
                            Select Case P_DtView1(0)("rcpt_cls")    '受付種別
                                Case Is = "02"  'QG-Care
                                    If P_DtView1(0)("grup_code") = "90" Then  '②
                                        If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '限度オーバー
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '動産扱い
                                                out_seq(1) = "1"
                                                out_seq(4) = "1"
                                                P1_F00_Form07_2 = "11"  'ネバ伝枚数
                                            Else                                            '通常故障
                                                out_seq(1) = "1"
                                                out_seq(5) = "1"
                                                P1_F00_Form07_2 = "11"  'ネバ伝枚数
                                            End If
                                        Else                                                                                                    '限度内
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '動産扱い
                                                out_seq(1) = "1"
                                                out_seq(3) = "1"
                                                P1_F00_Form07_2 = "11"  'ネバ伝枚数
                                            Else                                            '通常故障
                                                out_seq(1) = "1"
                                                P1_F00_Form07_2 = "01"  'ネバ伝枚数
                                            End If
                                        End If
                                    Else
                                        If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '限度オーバー
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '動産扱い
                                                out_seq(4) = "1"
                                                P1_F00_Form07_2 = "10"  'ネバ伝枚数
                                            Else                                            '通常故障
                                                out_seq(5) = "1"
                                                P1_F00_Form07_2 = "10"  'ネバ伝枚数
                                            End If
                                        Else                                                                                                    '限度内
                                            If P_DtView1(0)("menseki_amnt") <> 0 Then       '動産扱い
                                                out_seq(3) = "1"
                                                P1_F00_Form07_2 = "10"  'ネバ伝枚数
                                            Else
                                                P1_F00_Form07_2 = "00"  'ネバ伝枚数
                                            End If
                                        End If

                                    End If
                                Case Is = "03"  '延長保証
                                    Select Case P_DtView1(0)("grup_code")    '販社グループ
                                        Case Is = "02", "90"
                                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '限度オーバー
                                                out_seq(1) = "1"
                                                out_seq(5) = "1"
                                                P1_F00_Form07_2 = "11"  'ネバ伝枚数
                                            Else
                                                out_seq(1) = "1"
                                                P1_F00_Form07_2 = "01"  'ネバ伝枚数
                                            End If
                                        Case Else
                                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") Then   '限度オーバー
                                                out_seq(9) = "1"
                                                P1_F00_Form07_2 = "10"  'ネバ伝枚数
                                            Else
                                                out_seq(1) = "1"
                                                P1_F00_Form07_2 = "01"  'ネバ伝枚数
                                            End If
                                    End Select
                                Case Else       'その他
                                    If P_DtView1(0)("grup_code") = "89" Then
                                        out_seq(9) = "1"
                                        P1_F00_Form07_2 = "10"  'ネバ伝枚数
                                    Else
                                        If P_DtView1(0)("vndr_code") = "01" And P_DtView1(0)("note_kbn") = "01" Then 'Apple Note
                                            out_seq(9) = "1"
                                            P1_F00_Form07_2 = "10"  'ネバ伝枚数
                                        Else
                                            out_seq(6) = "1"
                                            P1_F00_Form07_2 = "10"  'ネバ伝枚数
                                        End If
                                    End If
                            End Select
                    End Select

                Case Is = "88"                                      '富士通保険
                    If P_DtView1(0)("rcpt_cls") = "10" Then
                        If exp_part(rcpt_no) = "2" Then     '消耗品なし
                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") - RoundDOWN(P_exp_amt * Wk_TAX_1, 0) Then '限度オーバー
                                out_seq(10) = "1"           '消耗品なしでオーバー
                            Else
                                out_seq(9) = "1"            '消耗品なしで限度内
                            End If
                        Else                                '消耗品あり
                            If P_DtView1(0)("wrn_limt_amnt") < P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax") - RoundDOWN(P_exp_amt * Wk_TAX_1, 0) Then '限度オーバー
                                out_seq(11) = "1"           '消耗品ありでオーバー
                            Else
                                out_seq(12) = "1"           '消耗品ありで限度内
                            End If
                        End If
                    Else
                        out_seq(9) = "1"
                    End If
                    P1_F00_Form07_2 = "10"  'ネバ伝枚数

                Case Else
                    out_seq(9) = "1"
                    P1_F00_Form07_2 = "10"  'ネバ伝枚数
            End Select

            Dim WK_str1, WK_str2 As String
            If P_DtView1(0)("own_flg") = "True" Then WK_str1 = "True" Else WK_str1 = "False"
            rebate_idvd_Get(P_DtView1(0)("store_code"), P_DtView1(0)("rpar_cls"), P_DtView1(0)("rcpt_cls"), RoundDOWN(P_DtView1(0)("wrn_limt_amnt") / Wk_TAX_1, 0), P_DtView1(0)("menseki_amnt"), P_DtView1(0)("comp_shop_ttl") + P_DtView1(0)("comp_shop_tax"), P_DtView1(0)("comp_shop_ttl"), WK_str1, P_DtView1(0)("vndr_code"), P_DtView1(0)("note_kbn"))
            If P_chn_F = "1" Then
                P_idvd = P_DtView1(0)("comp_shop_ttl")
            End If

            printer = PRT_GET("03")   '**  プリンタ名取得

            Select Case P_DtView1(0)("dlvr_rprt_ptn") '印刷パターン
                Case Is = "01"  '全国生協 神戸事業連合
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '納品先名
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '納品先コード
                    dtRow("client_code") = P_DtView1(0)("client_code")  '取引先コード
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '店舗コード

                    '取引先
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
                    WK_str = WK_str.Replace("株式会社", "㈱")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")          'QGマネージャー
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                         '会社名
                    dtRow("brch_name") = DtView1(0)("brch_name")                        'QG名
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")     'QG住所
                    dtRow("tel") = DtView1(0)("tel")                                    'QG電話
                    dtRow("fax") = DtView1(0)("fax")                                    'QGファックス
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")  '受付日
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")  '完成日

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")                      'メーカー
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")              '修理区分
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                          '受付番号
                    dtRow("user_name") = P_DtView1(0)("user_name")                      'お客様名
                    dtRow("model_1") = P_DtView1(0)("model_1")                          '機種

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                   '受付種別
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　ｱｶﾃﾞﾐｯｸ"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　動産保証"
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
                                dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
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
                            dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")                  '金額
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            WK_DtView1(0)("Expr01") = "神戸事業連合"
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")            '納品先名
                            WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")            '店舗コード
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")          '取引先コード
                            WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")       'QGマネージャー
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")            '会社名
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")            'QG名
                            WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")                 'QG住所
                            WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")                  'QG電話
                            WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")                  'QGファックス
                            WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")            '受付日
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")            '完成日
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                      '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"                'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                      '機種
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"     '受付種別
                                    Else
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　動産保証　取扱手数料分"    '受付種別
                                    End If
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                  '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"            'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                  '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　動産保証　自己負担分"      '受付種別
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("user_name") & " 様分）" 'メーカー、お客様名
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = "QG-Care ｱｶﾃﾞﾐｯｸ"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") & " " & WK_DtView1(0)("rcpt_no")     '受付番号
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = "免責額"
                                    WK_DtView1(0)("Expr29") = "限度超過額"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"    'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"        '受付種別
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"    'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"        '受付種別
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                  '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"            'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                  '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"     '受付種別
                                    WK_DtView1(0)("Expr27") = dtRow("Expr02")
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"    'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"        '受付種別
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"    'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"        '受付種別
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"    'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"        '受付種別
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                          '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"    'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                          '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"        '受付種別
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
                                rpt.Document.Name = "チェーンストア伝票 全国生協 神戸事業連合" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Is = "02"  '単協(阪大)
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '納品先名
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '納品先コード
                    dtRow("client_code") = P_DtView1(0)("client_code")  '取引先コード
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '店舗コード

                    '取引先
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
                    WK_str = WK_str.Replace("株式会社", "㈱")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")  'QGマネージャー
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                             '会社名
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG名
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")         'QG住所
                    dtRow("tel") = DtView1(0)("tel")                                        'QG電話
                    dtRow("fax") = DtView1(0)("fax")                                        'QGファックス
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")      '受付日
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '完成日

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '受付番号
                    dtRow("user_name") = P_DtView1(0)("user_name")                          'お客様名
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '機種

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                       '受付種別
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　ｱｶﾃﾞﾐｯｸ"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　動産保証"
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
                                dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
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
                            dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")              '金額
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            WK_DtView1(0)("Expr01") = Nothing
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '納品先名
                            WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")        '店舗コード
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '取引先コード
                            WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")   'QGマネージャー
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '会社名
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG名
                            WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")             'QG住所
                            WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")              'QG電話
                            WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")              'QGファックス
                            WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")        '受付日
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '完成日
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                      '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"                'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                      '機種
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"     '受付種別
                                    Else
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　動産保証　取扱手数料分"    '受付種別
                                    End If
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　動産保証　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("user_name") & " 様分）" 'メーカー、お客様名
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = "QG-Care ｱｶﾃﾞﾐｯｸ"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") & " " & WK_DtView1(0)("rcpt_no")                          '受付番号
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = "免責額"
                                    WK_DtView1(0)("Expr29") = "限度超過額"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                              '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & P_DtView1(0)("user_name") & "　様分）"         'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                              '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                rpt.Document.Name = "チェーンストア伝票 単協(阪大)" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Is = "03"  '全国生協(阪大)
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '納品先名
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '納品先コード
                    dtRow("client_code") = P_DtView1(0)("client_code")  '取引先コード
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '店舗コード

                    '取引先
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
                    WK_str = WK_str.Replace("株式会社", "㈱")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")              'QGマネージャー
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                             '会社名
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG名
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")         'QG住所
                    dtRow("tel") = DtView1(0)("tel")                                        'QG電話
                    dtRow("fax") = DtView1(0)("fax")                                        'QGファックス
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")      '受付日
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '完成日

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '受付番号
                    dtRow("user_name") = P_DtView1(0)("user_name")                          'お客様名
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '機種

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                       '受付種別
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　ｱｶﾃﾞﾐｯｸ"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　動産保証"
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
                                dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
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
                            dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")              '金額
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            'WK_DtView1(0)("Expr01") = WK_DtView1(0)("seikyo")           '大学名
                            WK_DtView1(0)("Expr01") = WK_DtView1(0)("dlvr_name")        '納品先名
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '納品先名
                            WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")        '店舗コード
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '取引先コード
                            WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")   'QGマネージャー
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '会社名
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG名
                            WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")             'QG住所
                            WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")              'QG電話
                            WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")              'QGファックス
                            WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")        '受付日
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '完成日
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                                      '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"                'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                                      '機種
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"     '受付種別
                                    Else
                                        WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　動産保証　取扱手数料分"    '受付種別
                                    End If
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　動産保証　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("user_name") & " 様分）" 'メーカー、お客様名
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = "QG-Care ｱｶﾃﾞﾐｯｸ"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") & " " & WK_DtView1(0)("rcpt_no")     '受付番号
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = "免責額"
                                    WK_DtView1(0)("Expr29") = "限度超過額"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = Nothing
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr24") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr26") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                rpt.Document.Name = "チェーンストア伝票 全国生協(阪大)" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Is = "04"  '京都事業連合
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")          '納品先名
                    dtRow("client_code") = P_DtView1(0)("client_code")      '取引先コード

                    '取引先
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
                    WK_str = WK_str.Replace("株式会社", "㈱")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    dtRow("comp_name") = WK_str                                             '会社名
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG名
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '完成日

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")                          'メーカー
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")                  '修理区分
                    dtRow("user_name") = P_DtView1(0)("user_name")                          'お客様名
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '機種
                    dtRow("s_n") = P_DtView1(0)("s_n")                                      's/n
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '受付番号

                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_eu_ttl")                    '金額
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        If out_seq(i) = "1" Then
                            WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                            WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '納品先名
                            WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '取引先コード
                            WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '会社名
                            WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG名
                            WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '完成日
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
                                    End If

                                Case Is = 3
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & WK_mnsk
                                    Else
                                        WK_DtView1(0)("Expr31") = "\-" & WK_mnsk
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 4
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & RoundUP((P_DtView1(0)("comp_eu_ttl") + P_DtView1(0)("comp_eu_tax") - P_DtView1(0)("wrn_limt_amnt")) / Wk_TAX_1, 0) + CInt(WK_mnsk)
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & (RoundUP((P_DtView1(0)("comp_eu_ttl") + P_DtView1(0)("comp_eu_tax") - P_DtView1(0)("wrn_limt_amnt")) / Wk_TAX_1, 0) + CInt(WK_mnsk)) * -1
                                    End If

                                Case Is = 5
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 6
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 8
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
                                    End If

                                Case Is = 9
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 10
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 11
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd
                                    Else
                                        WK_DtView1(0)("Expr31") = "\" & P_idvd * -1
                                    End If

                                    P4_F00_Form07_2 = WK_DtView1(0)("Expr31")

                                Case Is = 12
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " " & WK_DtView1(0)("rpar_cls_name") 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr23") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("s_n")                               's/n
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("rcpt_no")                           '受付番号
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
                                rpt.Document.Name = "チェーンストア伝票 京都事業連合" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

                Case Else       '通常
                    P_DsPRT.Tables("Print02").Clear()
                    dttable = P_DsPRT.Tables("Print02")
                    dtRow = dttable.NewRow

                    dtRow("dlvr_name") = P_DtView1(0)("dlvr_name")      '納品先名
                    dtRow("dlvr_CODE") = P_DtView1(0)("dlvr_CODE")      '納品先コード
                    dtRow("client_code") = P_DtView1(0)("client_code")  '取引先コード
                    dtRow("cust_code") = P_DtView1(0)("cust_code")      '店舗コード

                    '取引先
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
                    WK_str = WK_str.Replace("株式会社", "㈱")
                    WK_str = StrConv(WK_str, VbStrConv.Narrow)
                    If Not IsDBNull(DtView1(0)("mngr_empl_name")) Then
                        dtRow("mngr_empl_name") = DtView1(0)("mngr_empl_name")              'QGマネージャー
                    Else
                        dtRow("mngr_empl_name") = Nothing
                    End If
                    dtRow("comp_name") = WK_str                                             '会社名
                    dtRow("brch_name") = DtView1(0)("brch_name")                            'QG名
                    dtRow("adrs") = DtView1(0)("adrs1") & " " & DtView1(0)("adrs2")         'QG住所
                    dtRow("tel") = DtView1(0)("tel")                                        'QG電話
                    dtRow("fax") = DtView1(0)("fax")                                        'QGファックス
                    dtRow("accp_date") = Format(P_DtView1(0)("accp_date"), "yy/MM/dd")      '受付日
                    dtRow("comp_date") = Format(P_DtView1(0)("comp_date"), "yy/MM/dd")      '完成日

                    dtRow("vndr_name") = P_DtView1(0)("vndr_name")                          'メーカー
                    dtRow("rpar_cls_name") = P_DtView1(0)("rpar_cls_name")                  '修理区分
                    dtRow("rcpt_no") = P_DtView1(0)("rcpt_no")                              '受付番号
                    dtRow("user_name") = P_DtView1(0)("user_name")                          'お客様名
                    dtRow("model_1") = P_DtView1(0)("model_1")                              '機種

                    dtRow("HSY_name") = P_DtView1(0)("rcpt_cls_name")                       '受付種別
                    If P_DtView1(0)("rcpt_cls_name_abbr") = "QGNo" Then
                        If Not IsDBNull(P_DtView1(0)("menseki_amnt")) Then
                            If P_DtView1(0)("menseki_amnt") <> 0 Then
                                'If P_DtView1(0)("grup_code") = "90" Then
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　ｱｶﾃﾞﾐｯｸ"
                                'Else
                                '    dtRow("HSY_name") = dtRow("HSY_name") & "　動産保証"
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
                                dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
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
                            dtRow("HSY_name") = dtRow("HSY_name") & "　" & DtView1(0)("wrn_range_name")
                        End If
                    End If
                    dtRow("comp_shop_ttl") = P_DtView1(0)("comp_shop_ttl")          '金額
                    dttable.Rows.Add(dtRow)

                    For i = 1 To 12
                        WK_DtView1 = New DataView(P_DsPRT.Tables("Print02"), "", "", DataViewRowState.CurrentRows)
                        'WK_DtView1(0)("Expr01") = WK_DtView1(0)("seikyo")           '大学名
                        WK_DtView1(0)("Expr01") = WK_DtView1(0)("dlvr_name")        '納品先名
                        WK_DtView1(0)("Expr02") = WK_DtView1(0)("dlvr_name")        '納品先名
                        WK_DtView1(0)("Expr03") = WK_DtView1(0)("cust_code")        '店舗コード
                        WK_DtView1(0)("Expr04") = WK_DtView1(0)("client_code")      '取引先コード
                        WK_DtView1(0)("Expr05") = WK_DtView1(0)("mngr_empl_name")   'QGマネージャー
                        WK_DtView1(0)("Expr06") = WK_DtView1(0)("comp_name")        '会社名
                        WK_DtView1(0)("Expr07") = WK_DtView1(0)("brch_name")        'QG名
                        WK_DtView1(0)("Expr08") = WK_DtView1(0)("adrs")             'QG住所
                        WK_DtView1(0)("Expr09") = WK_DtView1(0)("tel")              'QG電話
                        WK_DtView1(0)("Expr10") = WK_DtView1(0)("fax")              'QGファックス
                        WK_DtView1(0)("Expr11") = WK_DtView1(0)("accp_date")        '受付日
                        WK_DtView1(0)("Expr12") = WK_DtView1(0)("comp_date")        '完成日
                        If out_seq(i) = "1" Then
                            Select Case i
                                Case Is = 1
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                                      '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"                'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                                      '機種
                                    If P_DtView1(0)("grup_code") = "90" Then
                                        WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"     '受付種別
                                    Else
                                        WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　動産保証　取扱手数料分"    '受付種別
                                    End If
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　動産保証　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("user_name") & " 様分）" 'メーカー、お客様名
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "QG-Care ｱｶﾃﾞﾐｯｸ"
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1") '& " " & WK_DtView1(0)("rcpt_no")     '受付番号
                                    WK_DtView1(0)("Expr25") = Nothing
                                    WK_DtView1(0)("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = "免責額"
                                    WK_DtView1(0)("Expr29") = "限度超過額"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　ｱｶﾃﾞﾐｯｸ　取扱手数料分"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    If aka = "0" Then
                                        WK_DtView1(0)("Expr31") = "▲" & P_rebate
                                    Else
                                        WK_DtView1(0)("Expr31") = "　" & P_rebate
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　自己負担分"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") '& "　消耗品"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　消耗品"
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
                                    WK_DtView1(0)("Expr21") = WK_DtView1(0)("vndr_name") & " 修理品（" & WK_DtView1(0)("rpar_cls_name") & "）" 'メーカー、修理区分
                                    WK_DtView1(0)("Expr22") = WK_DtView1(0)("rcpt_no")                           '受付番号
                                    WK_DtView1(0)("Expr23") = "（" & WK_DtView1(0)("user_name") & "　様分）"     'お客様名
                                    WK_DtView1(0)("Expr24") = WK_DtView1(0)("model_1")                           '機種
                                    WK_DtView1(0)("Expr25") = WK_DtView1(0)("HSY_name") & "　消耗品"
                                    dtRow("Expr26") = Nothing
                                    WK_DtView1(0)("Expr27") = Nothing
                                    WK_DtView1(0)("Expr28") = Nothing
                                    WK_DtView1(0)("Expr29") = Nothing
                                    WK_DtView1(0)("Expr31") = Nothing
                                    WK_DtView1(0)("Expr31_2") = Nothing
                                    WK_DtView1(0)("Expr31_3") = Nothing
                                    If aka = "0" Then
                                        If exp_part(rcpt_no) = "1" Then     '消耗品のみ
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
                                rpt.Document.Name = "チェーンストア伝票" & i
                                rpt.Document.Print(False, False, False)
                            End If

                            'Dim F00_Form07_2 As New F00_Form07_2
                            'F00_Form07_2.ShowDialog()

                        End If
                    Next

            End Select

            P_HSTY_DATE = Now
            DB_OPEN("nMVAR")
            '印刷日付
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

            add_hsty(rcpt_no, "チェーンストア伝票印刷", "", "")
        End If

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    '********************************************************************
    '**  送り状 (R_Haiso)
    '********************************************************************
    Public Function Print_R_Haiso(ByVal rcpt_no, ByVal prt_ptn)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Haiso_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")
        DB_CLOSE()
        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)

        printer = PRT_GET("04")   '**  プリンタ名取得

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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
                    rpt.Document.Name = "送り状"
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
    '**  ＣＣＡＲ (R_NCR_CCAR)
    '********************************************************************
    Public Function Print_R_NCR_CCAR(ByVal rcpt_no)
        On Error GoTo err

        printer = Nothing
        DsList1.Clear()
        P_DsPRT.Clear()
        DB_OPEN("nMVAR")

        'メインデータ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_NCR_CCAR", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram1.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print01")

        P_DtView1 = New DataView(P_DsPRT.Tables("Print01"), "", "", DataViewRowState.CurrentRows)
        P_DtView1(0)("adrs1") = P_DtView1(0)("adrs1") & " " & P_DtView1(0)("adrs2")

        '部品データ
        SqlCmd1 = New SqlClient.SqlCommand("sp_R_Sagyou_3", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
        Pram5.Value = rcpt_no
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(P_DsPRT, "Print05")

        P_HSTY_DATE = Now
        '印刷日付
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

        printer = PRT_GET("05")   '**  プリンタ名取得

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
            rpt.Document.Name = "ＣＣＡＲ"
            rpt.Document.Print(False, False, False)
        End If

        add_hsty(rcpt_no, "ＣＣＡＲ印刷", "", "")

        Exit Function
err:
        If Err.Number = 5 Then
        Else
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function
End Class                        