Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strData As String
    Dim i, j, r, r2, seq As Integer
    Dim WK_AMT As Integer
    Dim WK_str, WK_str2, Br_rcpt_no As String
    Dim fr_date, to_date As Date

    Dim strFile, filename As String

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
        Me.ClientSize = New System.Drawing.Size(240, 117)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC START", "オービック用データを出力を開始します。", System.Diagnostics.EventLogEntryType.Information)
        If DB_INIT() = "1" Then Application.Exit() : Exit Sub

        Call ds_set()  '** データセット
        Call csv_out()  '** CSV出力

        '60秒間（60000ミリ秒）停止する
        System.Threading.Thread.Sleep(60000)

        Call FTP_up()   '** CSVデータアップロード

        '60秒間（60000ミリ秒）停止する
        System.Threading.Thread.Sleep(60000)

        'ﾌｧｲﾙ移動
        For Each strFile In System.IO.Directory.GetFiles(dl_fldr, "*.csv")
            filename = strFile.Substring(strFile.LastIndexOf("\") + 1).ToUpper
            Dim csvFileName As String = filename.ToUpper
            Dim WK_date As String = Format(Now, "yyyyMMddhhmm") & ".csv"
            Dim logFileName As String = filename.Replace(".CSV", WK_date)
            System.IO.File.Move(dl_fldr & "\" & csvFileName, log_fldr & "\" & logFileName)
        Next

        System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC END", "オービック用データを出力を終了します。", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

    '******************************************************************
    '** データセット
    '******************************************************************
    Sub ds_set()
        WK_DsList1.Clear()
        strSQL = "SELECT cls_code_name, cls_code_name_abbr FROM V_cls_053"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "cls_053")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("cls_053"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then strFile = Trim(WK_DtView1(0)("cls_code_name")) & "\" & Trim(WK_DtView1(0)("cls_code_name_abbr"))
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then dl_fldr = Trim(WK_DtView1(0)("cls_code_name"))
            log_fldr = dl_fldr & "\log"
        End If
    End Sub

    '******************************************************************
    '** CSV出力
    '******************************************************************
    Sub csv_out()
        '実行時間が深夜0時の前後で抽出条件が変わる
        Dim WK_HH As String = Format(Now, "HH")
        fr_date = Format(Now.Date, "yyyy/MM" & "/01")
        If WK_HH < "12" Then
            to_date = Now.Date
        Else
            to_date = DateAdd(DateInterval.Day, 1, Now.Date)
        End If

        'fr_date = "2020/01/08"
        'to_date = "2020/01/09"

        'DataTable作成()
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_15", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = fr_date
        Pram2.Value = to_date
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "WK_Print01")
        DB_CLOSE()

        If r <> 0 Then

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "伝票番号,行番号,計上QGコード,計上QG,受付種別コード,受付種別,入荷区分コード,入荷区分名,グループコード,グループ名,取次店コード"
            strData += ",取次店名,販社伝番,請求先コード,請求先名,お客様名,事故日,修理完了日,売上日,入金日付,見積日付,回答受信日,部品発注日"
            strData += ",部品受領日,見積書金額,社員コード,修理担当者名,メーカーコード,メーカー名,モデル,機種,製造番号,保証情報,保証情報名,部品番号"
            strData += ",部品名,部品数量,部品コスト,部品計上額,部品EU額,部品代,APSE,技術料,その他,送料,小計,消費税,合計,預り金,販社リベート"
            strData += ",自己負担金,QG-Care保証範囲コード,QG-Care保証範囲,修理会社,受付ＱＧ,ゼロ円理由,ネバ伝番号,ネバ伝番号（リベート）,赤伝元受付番号"
            strData += ",オリジナルメーカーコード,申告症状,修理内容,QG-Care番号,Note,完了コメント,Mobile種別,レジ番号,登録QG,iMVAR管理番号"
            strData += ",受付コメント,SB/IMEI番号,SB/新IMEI番号,入金種別コード,入金種別"
            swFile.WriteLine(strData)

            DtView1 = New DataView(DsList1.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                If Br_rcpt_no = DtView1(i)("rcpt_no") Then
                    seq = seq + 1
                Else
                    Br_rcpt_no = DtView1(i)("rcpt_no")
                    seq = 1
                End If

                strData = Chr(34) & DtView1(i)("rcpt_no") & Chr(34)                             '伝票番号
                strData += "," & Chr(34) & seq & Chr(34)                                        '行番号
                strData += "," & Chr(34) & DtView1(i)("kjo_brch_code") & Chr(34)                '計上QGコード
                strData += "," & Chr(34) & DtView1(i)("kjo_brch_name") & Chr(34)                '計上QG
                strData += "," & Chr(34) & DtView1(i)("rcpt_cls") & Chr(34)                     '受付種別コード
                strData += "," & Chr(34) & DtView1(i)("rcpt_name") & Chr(34)                    '受付種別
                strData += "," & Chr(34) & DtView1(i)("arvl_cls") & Chr(34)                     '入荷区分コード
                strData += "," & Chr(34) & DtView1(i)("arvl_name") & Chr(34)                    '入荷区分名
                strData += "," & Chr(34) & DtView1(i)("grup_code") & Chr(34)                    'グループコード
                strData += "," & Chr(34) & DtView1(i)("grup_name") & Chr(34)                    'グループ名
                strData += "," & Chr(34) & DtView1(i)("store_code") & Chr(34)                   '取次店コード
                strData += "," & Chr(34) & DtView1(i)("store_name") & Chr(34)                   '取次店名
                strData += "," & Chr(34) & DtView1(i)("store_repr_no") & Chr(34)                '販社伝番
                strData += "," & Chr(34) & DtView1(i)("invc_code") & Chr(34)                    '請求先コード
                strData += "," & Chr(34) & DtView1(i)("invc_name") & Chr(34)                    '請求先名
                strData += "," & Chr(34) & DQM_Cng(DtView1(i)("user_name")) & Chr(34)           'お客様名
                strData += "," & Chr(34) & DtView1(i)("accp_date") & Chr(34)                    '事故日//Edited by ram acdt_date to accp_date
                strData += "," & Chr(34) & DtView1(i)("comp_date") & Chr(34)                    '修理完了日
                strData += "," & Chr(34) & DtView1(i)("sals_date") & Chr(34)                    '売上日
                strData += "," & Chr(34) & DtView1(i)("clct_date") & Chr(34)                    '入金日付
                strData += "," & Chr(34) & DtView1(i)("etmt_date") & Chr(34)                    '見積日付
                strData += "," & Chr(34) & DtView1(i)("rsrv_cacl_date") & Chr(34)               '回答受信日
                strData += "," & Chr(34) & DtView1(i)("part_ordr_date") & Chr(34)               '部品発注日
                strData += "," & Chr(34) & DtView1(i)("part_rcpt_date") & Chr(34)               '部品受領日
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                strData += "," & Chr(34) & WK_AMT & Chr(34)                                     '見積書金額
                strData += "," & Chr(34) & DtView1(i)("repr_empl_code") & Chr(34)               '社員コード
                strData += "," & Chr(34) & DtView1(i)("repr_empl_name") & Chr(34)               '修理担当者名
                strData += "," & Chr(34) & DtView1(i)("vndr_code") & Chr(34)                    'メーカーコード
                strData += "," & Chr(34) & DtView1(i)("vndr_name") & Chr(34)                    'メーカー名
                WK_str = New_Line_Cng(DtView1(i)("model_1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            'モデル
                WK_str = New_Line_Cng(DtView1(i)("model_2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '機種
                WK_str = New_Line_Cng(DtView1(i)("s_n"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '製造番号
                strData += "," & Chr(34) & DtView1(i)("rpar_cls") & Chr(34)                     '保証情報
                strData += "," & Chr(34) & DtView1(i)("rpar_name") & Chr(34)                    '保証情報名
                If Not IsDBNull(DtView1(i)("part_code")) Then
                    WK_str = New_Line_Cng(DtView1(i)("part_code"))
                    strData += "," & Chr(34) & WK_str & Chr(34)                                 '部品番号
                    WK_str = New_Line_Cng(DtView1(i)("part_name"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '部品名
                    strData += "," & Chr(34) & DtView1(i)("use_qty") & Chr(34)                  '部品数量
                    strData += "," & Chr(34) & DtView1(i)("cost_chrg") & Chr(34)                '部品コスト
                    strData += "," & Chr(34) & DtView1(i)("shop_chrg") & Chr(34)                '部品計上額
                    strData += "," & Chr(34) & DtView1(i)("eu_chrg") & Chr(34)                  '部品EU額
                Else
                    strData += "," & Chr(34) & Chr(34)                                          '部品番号
                    strData += "," & Chr(34) & Chr(34)                                          '部品名
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '部品数量
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '部品コスト
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '部品計上額
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '部品EU額
                End If
                strData += "," & Chr(34) & DtView1(i)("comp_shop_part_chrg") & Chr(34)          '部品代
                strData += "," & Chr(34) & DtView1(i)("comp_shop_apes") & Chr(34)               'APSE
                strData += "," & Chr(34) & DtView1(i)("comp_shop_tech_chrg") & Chr(34)          '技術料
                strData += "," & Chr(34) & DtView1(i)("comp_shop_fee") & Chr(34)                'その他
                strData += "," & Chr(34) & DtView1(i)("comp_shop_pstg") & Chr(34)               '送料
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("comp_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("comp_shop_ttl")
                strData += "," & Chr(34) & WK_AMT & Chr(34)                                     '小計
                If Not IsDBNull(DtView1(i)("comp_shop_tax")) Then
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_tax") & Chr(34)            '消費税
                    strData += "," & Chr(34) & WK_AMT + DtView1(i)("comp_shop_tax") & Chr(34)   '合計
                Else
                    strData += "," & Chr(34) & "0" & Chr(34)                                    '消費税
                    strData += "," & Chr(34) & WK_AMT & Chr(34)                                 '合計
                End If
                strData += "," & Chr(34) & DtView1(i)("recv_amnt") & Chr(34)                    '預り金
                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)                   '販社リベート
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData += "," & Chr(34) & "0" & Chr(34)
                    Else
                        strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)
                    End If
                End If
                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)                '自己負担金
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData += "," & Chr(34) & "0" & Chr(34)
                    Else
                        strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)
                    End If
                End If

                WK_str = Nothing : WK_str2 = Nothing
                If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                    WK_DsList1.Clear()
                    strSQL = "SELECT T01_member.wrn_range, V_M02_HSY.cls_code_name AS HSY_name"
                    strSQL += " FROM T01_member INNER JOIN"
                    strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code"
                    strSQL += " WHERE (T01_member.code = '" & DtView1(i)("qg_care_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("QGCare")
                    DaList1.Fill(WK_DsList1, "T01_member")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        If Not IsDBNull(WK_DtView1(0)("wrn_range")) Then WK_str = Trim(WK_DtView1(0)("wrn_range"))
                        If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str2 = Trim(WK_DtView1(0)("HSY_name"))
                    End If
                End If
                strData += "," & Chr(34) & WK_str & Chr(34)                                     'QG-Care保証範囲コード
                strData += "," & Chr(34) & WK_str2 & Chr(34)                                    'QG-Care保証範囲

                strData += "," & Chr(34) & DtView1(i)("rpar_comp_name") & Chr(34)               '修理会社
                strData += "," & Chr(34) & DtView1(i)("rcpt_brch_name") & Chr(34)               '受付ＱＧ
                If Not IsDBNull(DtView1(i)("zero_name")) Then
                    WK_str = DtView1(i)("zero_name")
                    strData += "," & Chr(34) & WK_str & Chr(34)                                 '\0理由
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("sals_no") & Chr(34)                      'ネバ伝番号
                strData += "," & Chr(34) & DtView1(i)("sals_no2") & Chr(34)                     'ネバ伝番号（リベート）
                strData += "," & Chr(34) & DtView1(i)("rcpt_no_aka") & Chr(34)                  '赤伝受付番号
                strData += "," & Chr(34) & DtView1(i)("orgnl_vndr_code") & Chr(34)              'オリジナルメーカーコード
                If Not IsDBNull(DtView1(i)("user_trbl")) Then
                    WK_str = New_Line_Cng(DtView1(i)("user_trbl"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '申告症状
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_meas"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '修理内容
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & DtView1(i)("qg_care_no")                                       'QG-Care番号
                If IsDBNull(DtView1(i)("note_kbn2")) Then
                    strData += "," & Chr(34) & Chr(34)                                          'Note
                Else
                    If DtView1(i)("note_kbn2") = "01" Then
                        strData += "," & Chr(34) & "1" & Chr(34)
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_comn"))
                    strData += "," & Chr(34) & WK_str & Chr(34)                                 '完了コメント
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("defe_name") & Chr(34)                    'Mobile種別（CLS：035）
                strData += "," & Chr(34) & DtView1(i)("reference_no") & Chr(34)                 'レジ番号
                If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then
                    strData += "," & Chr(34) & Mid(DtView1(i)("imv_rcpt_no"), 1, 2) & Chr(34)   '登録QG
                    strData += "," & Chr(34) & DtView1(i)("imv_rcpt_no") & Chr(34)              'iMVAR管理番号
                Else
                    strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                End If
                WK_str = New_Line_Cng(DtView1(i)("rcpt_comn"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                            '受付コメント
                strData += "," & Chr(34) & DtView1(i)("sb_imei_old") & Chr(34)                  'SB/IMEI番号
                strData += "," & Chr(34) & DtView1(i)("sb_imei_new") & Chr(34)                  'SB/新IMEI番号
                strData += "," & Chr(34) & DtView1(i)("payment_type") & Chr(34)                 '入金種別コード
                strData += "," & Chr(34) & DtView1(i)("payment_type_name") & Chr(34)            '入金種別

                strData = Replace(strData, System.Environment.NewLine, " ")
                strData = Replace(strData, vbCrLf, " ")
                strData = Replace(strData, vbCr, " ")
                strData = Replace(strData, vbLf, " ")
                swFile.WriteLine(strData)
            Next
            swFile.Close()          'ファイルを閉じる
            'System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC " & r & "件", "オービック用データを出力しました。" & fr_date & "～" & DateAdd(DateInterval.Day, -1, to_date), System.Diagnostics.EventLogEntryType.Information)

            DB_OPEN("nMVAR")

            '送信済記録
            For i = 0 To DtView1.Count - 1
                WK_DsList1.Clear()
                strSQL = "SELECT rcpt_no FROM T_OBIC_SND WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                r2 = DaList1.Fill(WK_DsList1, "T_OBIC_SND")
                If r2 = 0 Then
                    strSQL = "INSERT INTO T_OBIC_SND"
                    strSQL += " (rcpt_no, snd_date)"
                    strSQL += " VALUES ('" & DtView1(i)("rcpt_no") & "'"
                    strSQL += ", CONVERT(DATETIME, '" & Now & "', 102))"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If
            Next
            DB_CLOSE()
            'System.Diagnostics.EventLog.WriteEntry("nMVAR OBIC UPD", "オービック用データを送信済更新", System.Diagnostics.EventLogEntryType.Information)

        End If
        DsList1.Clear()
        WK_DsList1.Clear()

    End Sub
End Class
