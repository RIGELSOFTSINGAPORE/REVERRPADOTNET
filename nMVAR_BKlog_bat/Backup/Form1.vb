Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL As String
    Dim i, j, r1, r2 As Integer
    Dim WK_date As Date

    Dim WK_str As String
    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer

    Dim part_C1(7), part_C2(7) As String
    Dim part_C3(7), part_C4(7), part_C5(7), part_C6(7) As String
    Dim wk_C(8) As String

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(292, 45)
        Me.ControlBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("nMVAR BKlog START", "月末時点の仕掛データを保存します。", System.Diagnostics.EventLogEntryType.Information)
        DB_INIT()

        'WK_date = "2016/06/30"
        'GoTo skp

        '今日が月初？

        If Mid(Now.Date, 9, 2) = "01" Then
            WK_date = DateAdd(DateInterval.Day, -1, CDate(Mid(Now.Date, 1, 8) & "01")) '末日で処理
skp:
            DsList1.Clear()
            strSQL = "SELECT output_date"
            strSQL = strSQL & " FROM L05_CSV"
            strSQL = strSQL & " WHERE (output_date = CONVERT(DATETIME, '" & WK_date & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            r1 = DaList1.Fill(DsList1, "BAKlog_RE")
            DB_CLOSE()

            If r1 = 0 Then

                SqlCmd1 = New SqlClient.SqlCommand("sp_F40_07", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
                'Pram1.Value = WK_date
                Pram1.Value = DateAdd(DateInterval.Day, 1, CDate(WK_date))
                Pram2.Value = DateAdd(DateInterval.Day, 1, CDate(WK_date))
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                SqlCmd1.CommandTimeout = 600
                r2 = DaList1.Fill(DsList1, "BAKlog")
                DB_CLOSE()

                If r2 <> 0 Then

                    DtView1 = New DataView(DsList1.Tables("BAKlog"), "", "", DataViewRowState.CurrentRows)

                    For i = 0 To DtView1.Count - 1

                        Array.Clear(part_C1, Nothing, part_C1.Length)
                        Array.Clear(part_C2, Nothing, part_C2.Length)
                        Array.Clear(part_C3, Nothing, part_C3.Length)
                        Array.Clear(part_C4, Nothing, part_C4.Length)
                        Array.Clear(part_C5, Nothing, part_C5.Length)
                        Array.Clear(part_C6, Nothing, part_C6.Length)
                        Array.Clear(wk_C, Nothing, wk_C.Length)

                        WK_AMT = 0
                        If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                        If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                        wk_C(8) = WK_AMT

                        '部品情報
                        WK_DsList1.Clear()
                        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_05_2", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                        Pram3.Value = DtView1(i)("rcpt_no")
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(WK_DsList1, "T04_REP_PART")
                        DB_CLOSE()
                        WK_DtView1 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                        If WK_DtView1.Count <> 0 Then
                            For j = 0 To WK_DtView1.Count - 1
                                Select Case j
                                    Case Is < 7
                                        WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_code")))
                                        part_C1(j) = WK_str
                                        WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_name")))
                                        part_C2(j) = WK_str
                                        part_C3(j) = WK_DtView1(j)("use_qty")
                                        part_C4(j) = WK_DtView1(j)("part_amnt") * WK_DtView1(j)("use_qty")
                                        part_C5(j) = WK_DtView1(j)("shop_chrg")
                                        part_C6(j) = WK_DtView1(j)("eu_chrg")
                                    Case Is = 7
                                        If WK_DtView1.Count = 8 Then
                                            WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_code")))
                                            part_C1(j) = WK_str
                                            WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_name")))
                                            part_C2(j) = WK_str
                                            part_C3(j) = WK_DtView1(j)("use_qty")
                                            part_C4(j) = WK_DtView1(j)("part_amnt") * WK_DtView1(j)("use_qty")
                                            part_C5(j) = WK_DtView1(j)("shop_chrg")
                                            part_C6(j) = WK_DtView1(j)("eu_chrg")
                                        Else
                                            WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                            WK_AMT3 = WK_AMT3 + WK_DtView1(j)("part_amnt") * WK_DtView1(j)("use_qty")
                                            WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                            WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")
                                        End If

                                    Case Else
                                        WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                        WK_AMT3 = WK_AMT3 + WK_DtView1(j)("part_amnt") * WK_DtView1(j)("use_qty")
                                        WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                        WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")

                                End Select
                            Next
                        End If

                        Select Case WK_DtView1.Count
                            Case Is < 8
                            Case Is = 8
                            Case Else
                                part_C1(7) = Nothing
                                part_C2(7) = "その他部品"
                                part_C3(7) = WK_AMT2
                                part_C4(7) = WK_AMT3
                                part_C5(7) = WK_AMT4
                                part_C6(7) = WK_AMT5
                        End Select

                        WK_AMT = 0
                        If Not IsDBNull(DtView1(i)("comp_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("comp_shop_ttl")
                        wk_C(3) = WK_AMT
                        If Not IsDBNull(DtView1(i)("comp_shop_tax")) Then
                            wk_C(4) = DtView1(i)("comp_shop_tax")
                            wk_C(5) = WK_AMT + DtView1(i)("comp_shop_tax")
                        Else
                            wk_C(4) = "0"
                            wk_C(5) = WK_AMT
                        End If

                        WK_str = Nothing
                        If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                            WK_DsList1.Clear()
                            strSQL = "SELECT V_M02_HSY.cls_code_name AS HSY_name"
                            strSQL = strSQL & " FROM T01_member INNER JOIN"
                            strSQL = strSQL & " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                            strSQL = strSQL & " WHERE (T01_member.code = '" & DtView1(i)("qg_care_no") & "')"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            DB_OPEN("QGCare")
                            SqlCmd1.CommandTimeout = 600
                            DaList1.Fill(WK_DsList1, "T01_member")
                            DB_CLOSE()
                            WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str = Trim(WK_DtView1(0)("HSY_name"))
                            End If
                        End If
                        wk_C(0) = WK_str

                        If Not IsDBNull(DtView1(i)("user_trbl")) Then
                            wk_C(1) = New_Line_Cng(DtView1(i)("user_trbl"))
                        Else
                            wk_C(1) = Nothing
                        End If
                        If Not IsDBNull(DtView1(i)("comp_meas")) Then
                            wk_C(2) = New_Line_Cng(DtView1(i)("comp_meas"))
                        Else
                            wk_C(2) = Nothing
                        End If

                        '月末時点のデータを保存
                        strSQL = "INSERT INTO L05_CSV"
                        strSQL = strSQL & " (output_date, rcpt_no, kjo_brch_name, rcpt_name, arvl_cls, arvl_name, grup_code"
                        strSQL = strSQL & ", grup_name, store_code, store_name, store_repr_no, invc_code, invc_name, user_name"
                        strSQL = strSQL & ", accp_date, comp_date, sals_date, clct_date, etmt_date, rsrv_cacl_date, part_ordr_date, part_rcpt_date, etmt_shop_Gttl, repr_empl_code"
                        strSQL = strSQL & ", repr_empl_name, vndr_code, vndr_name, model_1, model_2, s_n, rpar_cls, rpar_name"
                        strSQL = strSQL & ", part_code1, part_name1, use_qty1, cost_chrg1, shop_chrg1, eu_chrg1, part_code2"
                        strSQL = strSQL & ", part_name2, use_qty2, cost_chrg2, shop_chrg2, eu_chrg2, part_code3, part_name3"
                        strSQL = strSQL & ", use_qty3, cost_chrg3, shop_chrg3, eu_chrg3, part_code4, part_name4, use_qty4"
                        strSQL = strSQL & ", cost_chrg4, shop_chrg4, eu_chrg4, part_code5, part_name5, use_qty5, cost_chrg5"
                        strSQL = strSQL & ", shop_chrg5, eu_chrg5, part_code6, part_name6, use_qty6, cost_chrg6, shop_chrg6"
                        strSQL = strSQL & ", eu_chrg6, part_code7, part_name7, use_qty7, cost_chrg7, shop_chrg7, eu_chrg7"
                        strSQL = strSQL & ", part_code8, part_name8, use_qty8, cost_chrg8, shop_chrg8, eu_chrg8"
                        strSQL = strSQL & ", comp_shop_part_chrg, comp_shop_apes, comp_shop_tech_chrg, comp_shop_fee"
                        strSQL = strSQL & ", comp_shop_pstg, comp_shop_ttl, comp_shop_tax, comp_shop_Gttl, rebate, sals_amnt"
                        strSQL = strSQL & ", HSY_name, rpar_comp_name, rcpt_brch_name, zero_name, sals_no, sals_no2"
                        strSQL = strSQL & ", rcpt_no_aka, orgnl_vndr_code, user_trbl, comp_meas, qg_care_no"
                        strSQL = strSQL & ", note_kbn2, comp_comn, defe_cls, defe_name, reference_no, imv_rcpt_no, sb_imei_old, sb_imei_new)"
                        strSQL = strSQL & " SELECT '" & WK_date & "' AS output_date"
                        strSQL = strSQL & ", '" & DtView1(i)("rcpt_no") & "' AS rcpt_no"
                        strSQL = strSQL & ", '" & DtView1(i)("kjo_brch_name") & "' AS kjo_brch_name"
                        strSQL = strSQL & ", '" & DtView1(i)("rcpt_name") & "' AS rcpt_name"
                        strSQL = strSQL & ", '" & DtView1(i)("arvl_cls") & "' AS arvl_cls"
                        strSQL = strSQL & ", '" & DtView1(i)("arvl_name") & "' AS arvl_name"
                        strSQL = strSQL & ", '" & DtView1(i)("grup_code") & "' AS grup_code"
                        strSQL = strSQL & ", '" & DtView1(i)("grup_name") & "' AS grup_name"
                        strSQL = strSQL & ", '" & DtView1(i)("store_code") & "' AS store_code"
                        strSQL = strSQL & ", '" & DtView1(i)("store_name") & "' AS store_name"
                        strSQL = strSQL & ", '" & DtView1(i)("store_repr_no") & "' AS store_repr_no"
                        strSQL = strSQL & ", '" & DtView1(i)("invc_code") & "' AS invc_code"
                        strSQL = strSQL & ", '" & DtView1(i)("invc_name") & "' AS invc_name"
                        strSQL = strSQL & ", '" & Replace(DtView1(i)("user_name"), "'", " ") & "' AS user_name"
                        strSQL = strSQL & ", '" & DtView1(i)("accp_date") & "' AS accp_date"
                        If Not IsDBNull(DtView1(i)("comp_date")) Then strSQL = strSQL & ", '" & DtView1(i)("comp_date") & "' AS comp_date" Else strSQL = strSQL & ", '' AS comp_date"
                        If Not IsDBNull(DtView1(i)("sals_date")) Then strSQL = strSQL & ", '" & DtView1(i)("sals_date") & "' AS sals_date" Else strSQL = strSQL & ", '' AS sals_date"
                        If Not IsDBNull(DtView1(i)("clct_date")) Then strSQL = strSQL & ", '" & DtView1(i)("clct_date") & "' AS clct_date" Else strSQL = strSQL & ", '' AS clct_date"
                        If Not IsDBNull(DtView1(i)("etmt_date")) Then strSQL = strSQL & ", '" & DtView1(i)("etmt_date") & "' AS etmt_date" Else strSQL = strSQL & ", '' AS etmt_date"
                        If Not IsDBNull(DtView1(i)("rsrv_cacl_date")) Then strSQL = strSQL & ", '" & DtView1(i)("rsrv_cacl_date") & "' AS rsrv_cacl_date" Else strSQL = strSQL & ", '' AS rsrv_cacl_date"
                        If Not IsDBNull(DtView1(i)("part_ordr_date")) Then strSQL = strSQL & ", '" & DtView1(i)("part_ordr_date") & "' AS part_ordr_date" Else strSQL = strSQL & ", '' AS part_ordr_date"
                        If Not IsDBNull(DtView1(i)("part_rcpt_date")) Then strSQL = strSQL & ", '" & DtView1(i)("part_rcpt_date") & "' AS part_rcpt_date" Else strSQL = strSQL & ", '' AS part_rcpt_date"
                        strSQL = strSQL & ", '" & wk_C(8) & "' AS etmt_shop_Gttl"
                        If Not IsDBNull(DtView1(i)("repr_empl_code")) Then strSQL = strSQL & ", " & DtView1(i)("repr_empl_code") & " AS repr_empl_code" Else strSQL = strSQL & ", '' AS repr_empl_code"
                        strSQL = strSQL & ", '" & DtView1(i)("repr_empl_name") & "' AS repr_empl_name"
                        strSQL = strSQL & ", '" & DtView1(i)("vndr_code") & "' AS vndr_code"
                        strSQL = strSQL & ", '" & DtView1(i)("vndr_name") & "' AS vndr_name"
                        strSQL = strSQL & ", '" & DtView1(i)("model_1") & "' AS model_1"
                        strSQL = strSQL & ", '" & DtView1(i)("model_2") & "' AS model_2"
                        strSQL = strSQL & ", '" & DtView1(i)("s_n") & "' AS s_n"
                        strSQL = strSQL & ", '" & DtView1(i)("rpar_cls") & "' AS rpar_cls"
                        strSQL = strSQL & ", '" & DtView1(i)("rpar_name") & "' AS rpar_name"
                        strSQL = strSQL & ", '" & part_C1(0) & "' AS part_code1"
                        strSQL = strSQL & ", '" & part_C2(0) & "' AS part_name1"
                        strSQL = strSQL & ", '" & part_C3(0) & "' AS use_qty1"
                        strSQL = strSQL & ", '" & part_C4(0) & "' AS cost_chrg1"
                        strSQL = strSQL & ", '" & part_C5(0) & "' AS shop_chrg1"
                        strSQL = strSQL & ", '" & part_C6(0) & "' AS eu_chrg1"
                        strSQL = strSQL & ", '" & part_C1(1) & "' AS part_code2"
                        strSQL = strSQL & ", '" & part_C2(1) & "' AS part_name2"
                        strSQL = strSQL & ", '" & part_C3(1) & "' AS use_qty2"
                        strSQL = strSQL & ", '" & part_C4(1) & "' AS cost_chrg2"
                        strSQL = strSQL & ", '" & part_C5(1) & "' AS shop_chrg2"
                        strSQL = strSQL & ", '" & part_C6(1) & "' AS eu_chrg2"
                        strSQL = strSQL & ", '" & part_C1(2) & "' AS part_code3"
                        strSQL = strSQL & ", '" & part_C2(2) & "' AS part_name3"
                        strSQL = strSQL & ", '" & part_C3(2) & "' AS use_qty3"
                        strSQL = strSQL & ", '" & part_C4(2) & "' AS cost_chrg3"
                        strSQL = strSQL & ", '" & part_C5(2) & "' AS shop_chrg3"
                        strSQL = strSQL & ", '" & part_C6(2) & "' AS eu_chrg3"
                        strSQL = strSQL & ", '" & part_C1(3) & "' AS part_code4"
                        strSQL = strSQL & ", '" & part_C2(3) & "' AS part_name4"
                        strSQL = strSQL & ", '" & part_C3(3) & "' AS use_qty4"
                        strSQL = strSQL & ", '" & part_C4(3) & "' AS cost_chrg4"
                        strSQL = strSQL & ", '" & part_C5(3) & "' AS shop_chrg4"
                        strSQL = strSQL & ", '" & part_C6(3) & "' AS eu_chrg4"
                        strSQL = strSQL & ", '" & part_C1(4) & "' AS part_code5"
                        strSQL = strSQL & ", '" & part_C2(4) & "' AS part_name5"
                        strSQL = strSQL & ", '" & part_C3(4) & "' AS use_qty5"
                        strSQL = strSQL & ", '" & part_C4(4) & "' AS cost_chrg5"
                        strSQL = strSQL & ", '" & part_C5(4) & "' AS shop_chrg5"
                        strSQL = strSQL & ", '" & part_C6(4) & "' AS eu_chrg5"
                        strSQL = strSQL & ", '" & part_C1(5) & "' AS part_code6"
                        strSQL = strSQL & ", '" & part_C2(5) & "' AS part_name6"
                        strSQL = strSQL & ", '" & part_C3(5) & "' AS use_qty6"
                        strSQL = strSQL & ", '" & part_C4(5) & "' AS cost_chrg6"
                        strSQL = strSQL & ", '" & part_C5(5) & "' AS shop_chrg6"
                        strSQL = strSQL & ", '" & part_C6(5) & "' AS eu_chrg6"
                        strSQL = strSQL & ", '" & part_C1(6) & "' AS part_code7"
                        strSQL = strSQL & ", '" & part_C2(6) & "' AS part_name7"
                        strSQL = strSQL & ", '" & part_C3(6) & "' AS use_qty7"
                        strSQL = strSQL & ", '" & part_C4(6) & "' AS cost_chrg7"
                        strSQL = strSQL & ", '" & part_C5(6) & "' AS shop_chrg7"
                        strSQL = strSQL & ", '" & part_C6(6) & "' AS eu_chrg7"
                        strSQL = strSQL & ", '" & part_C1(7) & "' AS part_code8"
                        strSQL = strSQL & ", '" & part_C2(7) & "' AS part_name8"
                        strSQL = strSQL & ", '" & part_C3(7) & "' AS use_qty8"
                        strSQL = strSQL & ", '" & part_C4(7) & "' AS cost_chrg8"
                        strSQL = strSQL & ", '" & part_C5(7) & "' AS shop_chrg8"
                        strSQL = strSQL & ", '" & part_C6(7) & "' AS eu_chrg8"
                        If Not IsDBNull(DtView1(i)("comp_shop_part_chrg")) Then strSQL = strSQL & ", '" & DtView1(i)("comp_shop_part_chrg") & "' AS comp_shop_part_chrg" Else strSQL = strSQL & ", '' AS comp_shop_part_chrg"
                        If Not IsDBNull(DtView1(i)("comp_shop_apes")) Then strSQL = strSQL & ", '" & DtView1(i)("comp_shop_apes") & "' AS comp_shop_apes" Else strSQL = strSQL & ", '' AS comp_shop_apes"
                        If Not IsDBNull(DtView1(i)("comp_shop_tech_chrg")) Then strSQL = strSQL & ", '" & DtView1(i)("comp_shop_tech_chrg") & "' AS comp_shop_tech_chrg" Else strSQL = strSQL & ", '' AS comp_shop_tech_chrg"
                        If Not IsDBNull(DtView1(i)("comp_shop_fee")) Then strSQL = strSQL & ", '" & DtView1(i)("comp_shop_fee") & "'AS comp_shop_fee" Else strSQL = strSQL & ", ''AS comp_shop_fee"
                        If Not IsDBNull(DtView1(i)("comp_shop_pstg")) Then strSQL = strSQL & ", '" & DtView1(i)("comp_shop_pstg") & "' AS comp_shop_pstg" Else strSQL = strSQL & ", '' AS comp_shop_pstg"
                        strSQL = strSQL & ", '" & wk_C(3) & "' AS comp_shop_ttl"
                        strSQL = strSQL & ", '" & wk_C(4) & "' AS comp_shop_tax"
                        strSQL = strSQL & ", '" & wk_C(5) & "' AS comp_shop_Gttl"
                        strSQL = strSQL & ", '" & wk_C(6) & "' AS rebate"
                        strSQL = strSQL & ", '" & wk_C(7) & "' AS sals_amnt"
                        strSQL = strSQL & ", '" & wk_C(0) & "' AS HSY_name"
                        strSQL = strSQL & ", '" & DtView1(i)("rpar_comp_name") & "' AS rpar_comp_name"
                        strSQL = strSQL & ", '" & DtView1(i)("rcpt_brch_name") & "' AS rcpt_brch_name"
                        strSQL = strSQL & ", '" & DtView1(i)("zero_name") & "' AS zero_name"
                        strSQL = strSQL & ", '" & DtView1(i)("sals_no") & "' AS sals_no"
                        strSQL = strSQL & ", '" & DtView1(i)("sals_no2") & "' AS sals_no2"
                        strSQL = strSQL & ", '" & DtView1(i)("rcpt_no_aka") & "' AS rcpt_no_aka"
                        strSQL = strSQL & ", '" & DtView1(i)("orgnl_vndr_code") & "' AS orgnl_vndr_code"
                        If wk_C(1) = Nothing Then
                            strSQL = strSQL & ", '" & wk_C(1) & "' AS user_trbl"
                        Else
                            strSQL = strSQL & ", '" & wk_C(1).Replace("'", " ") & "' AS user_trbl"
                        End If
                        If wk_C(2) = Nothing Then
                            strSQL = strSQL & ", '" & wk_C(2) & "' AS comp_meas"
                        Else
                            strSQL = strSQL & ", '" & wk_C(2).Replace("'", " ") & "' AS comp_meas"
                        End If
                        strSQL = strSQL & ", '" & DtView1(i)("qg_care_no") & "' AS qg_care_no"
                        If Not IsDBNull(DtView1(i)("note_kbn2")) Then strSQL = strSQL & ", '" & DtView1(i)("note_kbn2") & "' AS note_kbn2" Else strSQL = strSQL & ", '' AS note_kbn2"
                        If Not IsDBNull(DtView1(i)("comp_comn")) Then strSQL = strSQL & ", '" & Replace(DtView1(i)("comp_comn"), "'", "''") & "' AS comp_comn" Else strSQL = strSQL & ", '' AS comp_comn"
                        If Not IsDBNull(DtView1(i)("defe_cls")) Then strSQL = strSQL & ", '" & DtView1(i)("defe_cls") & "' AS defe_cls" Else strSQL = strSQL & ", '' AS defe_cls"
                        If Not IsDBNull(DtView1(i)("defe_name")) Then strSQL = strSQL & ", '" & DtView1(i)("defe_name") & "' AS defe_name" Else strSQL = strSQL & ", '' AS defe_name"
                        If Not IsDBNull(DtView1(i)("reference_no")) Then strSQL = strSQL & ", '" & DtView1(i)("reference_no") & "' AS reference_no" Else strSQL = strSQL & ", '' AS reference_no"
                        If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then strSQL = strSQL & ", '" & DtView1(i)("imv_rcpt_no") & "' AS imv_rcpt_no" Else strSQL = strSQL & ", '' AS imv_rcpt_no"
                        If Not IsDBNull(DtView1(i)("sb_imei_old")) Then strSQL = strSQL & ", '" & DtView1(i)("sb_imei_old") & "' AS sb_imei_old" Else strSQL = strSQL & ", '' AS sb_imei_old"
                        If Not IsDBNull(DtView1(i)("sb_imei_new")) Then strSQL = strSQL & ", '" & DtView1(i)("sb_imei_new") & "' AS sb_imei_new" Else strSQL = strSQL & ", '' AS sb_imei_new"
                        strSQL = strSQL.Replace(vbCrLf, "")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DB_OPEN("nMVAR")
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                    Next
                End If
            End If
            System.Diagnostics.EventLog.WriteEntry("nMVAR BKlog END", "月末時点の仕掛データを" & Format(r2, "##,##0") & "件、保存しました。", System.Diagnostics.EventLogEntryType.Information)
        End If

        Application.Exit()
    End Sub
End Class
