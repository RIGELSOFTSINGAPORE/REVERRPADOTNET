Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList0 As New DataSet
    Dim DsList1, WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strFile, filename As String

    Dim strSQL, Err_F, WK_str, mt_str As String
    Dim i, r, r2, r3 As Integer
    Dim imp_date As Date

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
        Me.ClientSize = New System.Drawing.Size(292, 53)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("QA_inport_START", "", System.Diagnostics.EventLogEntryType.Information)
        Call inz()      '** 初期処理
        Call ds_set()   '** データセット
        Call FTP_DL()   '** CSVデータダウンロード

        '60秒間（60000ミリ秒）停止する
        System.Threading.Thread.Sleep(60000)

        If System.IO.Directory.Exists(dl_fldr) = True Then
            DB_OPEN()
            For Each strFile In System.IO.Directory.GetFiles(dl_fldr, "*.csv")
                imp_date = Format(Now, "yyyy/MM/dd HH:mm") & ":00"
                filename = strFile.Substring(strFile.LastIndexOf("\") + 1)

                'CSVファイルの名前
                Dim csvFileName As String = filename '"test.csv"

                '接続文字列
                'Dim conString As String
                Dim conString As String =
               "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" _
               + dl_fldr + ";Extended Properties=""text;HDR=Yes;FMT=Delimited"""
                'DB_OPEN()
                'Dim conString As String = cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source & ";persist security info=False;initial catalog=" & catalog
                Dim con As New System.Data.OleDb.OleDbConnection(conString)

                Dim commText As String = "SELECT * FROM [" + csvFileName + "]"
                'Dim commText As String = "Select * from QA01_import"
                Dim da As New System.Data.OleDb.OleDbDataAdapter(commText, con)
                'Dim da As New System.Data.SqlClient.SqlDataAdapter(commText, cnsqlclient)
                'DataTableに格納する
                Dim dt As New DataTable

                da.Fill(dt)

                Dim colCount As Integer = dt.Columns.Count
                Dim lastColIndex As Integer = colCount - 1
                Dim csv(40) As String

                'レコードを書き込む
                Dim row As DataRow
                For Each row In dt.Rows
                    For i = 0 To colCount - 1
                        csv(i) = row(i).ToString()  'フィールドの取得
                        If i = 40 Then Exit For
                    Next
                    strSQL = "INSERT INTO QA01_import"
                    strSQL += " (kbn, qac_no, stts, user_name, user_kana, zip, adrs1, adrs2, adrs3, tel, tel2, tehai_date"
                    strSQL += ", maker_name, model_name, ship_date, trouble_reason, trouble_symptom, remark, auto_shinkou"
                    strSQL += ", daibiki, gss_rcpt_no, repr_post, repr_maker_name, trouble_point, parts_name, parts_amnt"
                    strSQL += ", etmt_amnt, tech_amnt, maker_fee, pstg, daibiki_fee, cxl_amnt, ttl_amnt, haso_date"
                    strSQL += ", haiso_den_no, gss_remark, comp_plan_date, disposal_date, import_date)"
                    strSQL += " VALUES (N'" & csv(0) & "'"    'kbn
                    If csv(1) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(1) & "'" 'qac_no
                    If csv(2) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(2) & "'" 'stts
                    If csv(3) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(3) & "'" 'user_name
                    If csv(4) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(4) & "'" 'user_kana
                    If csv(5) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(5) & "'" 'zip
                    'If csv(5) = Nothing Then
                    '    strSQL += ", NULL"
                    'Else
                    '    If IsNumeric(csv(5)) = True Then
                    '        strSQL += ", N'" & Format(CInt(csv(5)), "0000000") & "'" 'zip
                    '    Else
                    '        strSQL += ", N'" & csv(5) & "'" 'zip
                    '    End If
                    'End If
                    If csv(6) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(6) & "'" 'adrs1
                    If csv(7) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(7) & "'" 'adrs2
                    If csv(8) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(8) & "'" 'adrs3
                    If csv(9) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(9) & "'" 'tel
                    'If csv(9) = Nothing Then
                    '    strSQL += ", NULL"
                    'Else
                    '    strSQL += ", N'0" & csv(9) & "'" 'tel
                    'End If
                    If csv(10) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(10) & "'" 'te2
                    'If csv(10) = Nothing Then
                    '    strSQL += ", NULL"
                    'Else
                    '    strSQL += ", N'0" & csv(10) & "'" 'tel2
                    'End If
                    If csv(11) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(11) & "'" 'tehai_date
                    If csv(12) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(12) & "'" 'maker_name
                    If csv(13) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(13) & "'" 'model_name
                    If csv(14) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(14) & "'" 'ship_date
                    If csv(15) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(15) & "'" 'trouble_reason
                    If csv(16) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(16) & "'" 'trouble_symptom
                    If csv(17) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(17) & "'" 'remark
                    If csv(18) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(18) & "" 'auto_shinkou
                    If csv(19) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(19) & "" 'daibiki
                    If csv(20) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(20) & "'" 'gss_rcpt_no
                    If csv(21) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(21) & "" 'repr_post
                    If csv(22) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(22) & "'" 'repr_maker_name
                    If csv(23) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(23) & "'" 'trouble_point
                    If csv(24) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(24) & "'" 'parts_name
                    If csv(25) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(25) & "" 'parts_amnt
                    If csv(26) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(26) & "" 'etmt_amnt
                    If csv(27) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(27) & "" 'tech_amnt
                    If csv(28) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(28) & "" 'maker_fee
                    If csv(39) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(29) & "" 'pstg
                    If csv(30) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(30) & "" 'daibiki_fee
                    If csv(31) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(31) & "" 'cxl_amnt
                    If csv(32) = Nothing Then strSQL += ", NULL" Else strSQL += ", " & csv(32) & "" 'ttl_amnt
                    If csv(33) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(33) & "'" 'haso_date
                    If csv(34) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(34) & "'" 'haiso_den_no
                    If csv(35) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(35) & "'" 'gss_remark
                    If csv(36) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(36) & "'" 'comp_plan_date
                    If csv(37) = Nothing Then strSQL += ", NULL" Else strSQL += ", N'" & csv(37) & "'" 'disposal_date
                    strSQL += ", CONVERT(DATETIME, '" & imp_date & "', 102)"    'import_date
                    strSQL += ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                Next

                'ﾌｧｲﾙ移動
                System.IO.File.Move(dl_fldr & "\" & csvFileName, log_fldr & "\" & csvFileName)

                DsList1.Clear()
                strSQL = "SELECT QA01_import.* FROM QA01_import WHERE (upd_flg = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                r = DaList1.Fill(DsList1, "QA01_import")
                If r <> 0 Then
                    DtView1 = New DataView(DsList1.Tables("QA01_import"), "", "", DataViewRowState.CurrentRows)
                    For i = 0 To DtView1.Count - 1
                        QA02_upd()
                    Next

                    '処理済フラグ=ON
                    strSQL = "UPDATE QA01_import SET upd_flg = 1 WHERE (upd_flg = 0)"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()

                End If
            Next

            DB_CLOSE()
        End If
        System.Diagnostics.EventLog.WriteEntry("QA_inport_END", "", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

    '******************************************************************
    '** 初期処理
    '******************************************************************
    Sub inz()
        Call DB_INIT()
        Err_F = "0"
    End Sub

    '******************************************************************
    '** データセット
    '******************************************************************
    Sub ds_set()
        DsList0.Clear()

        strSQL = "SELECT * FROM QA_ftp_ini"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList0, "QA_ftp_ini")
        DB_CLOSE()
        DtView1 = New DataView(DsList0.Tables("QA_ftp_ini"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            dl_fldr = DtView1(0)("dl_fldr")
            If System.IO.Directory.Exists(dl_fldr) = False Then       '受信フォルダ　無ければ作成する
                System.IO.Directory.CreateDirectory(dl_fldr)
            End If

            log_fldr = DtView1(0)("log_fldr")
            If System.IO.Directory.Exists(log_fldr) = False Then       '受信フォルダ　無ければ作成する
                System.IO.Directory.CreateDirectory(log_fldr)
            End If
        Else
            Err_F = "1" : Exit Sub
        End If

    End Sub

    Sub QA02_upd()
        WK_DsList1.Clear()
        strSQL = "SELECT QA02_data.qac_no, V_cls_052.cls_code_name AS stts_name"
        strSQL += " FROM QA02_data INNER JOIN"
        strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
        strSQL += " WHERE (QA02_data.qac_no = N'" & DtView1(i)("qac_no") & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        r2 = DaList1.Fill(WK_DsList1, "QA02_data")

        If r2 = 0 Then  '登録
            strSQL = "INSERT INTO QA02_data"
            strSQL += " (id, kbn, qac_no, stts, user_name, user_kana, zip, adrs1, adrs2, adrs3, tel, tel2, tehai_date, maker_name"
            strSQL += ", model_name, ship_date, trouble_reason, trouble_symptom, remark, auto_shinkou, daibiki)"
            strSQL += " VALUES (" & DtView1(i)("id")     'id
            strSQL += ", N'" & DtView1(i)("kbn") & "'"    'kbn
            If Not IsDBNull(DtView1(i)("qac_no")) Then strSQL += ", N'" & DtView1(i)("qac_no") & "'" Else strSQL += ", NULL'" 'qac_no
            strSQL += ", N'20'"    'stts（入荷待ち）
            If Not IsDBNull(DtView1(i)("user_name")) Then strSQL += ", N'" & DtView1(i)("user_name") & "'" Else strSQL += ", NULL" 'user_name
            If Not IsDBNull(DtView1(i)("user_kana")) Then strSQL += ", N'" & DtView1(i)("user_kana") & "'" Else strSQL += ", NULL" 'user_kana
            If Not IsDBNull(DtView1(i)("zip")) Then strSQL += ", N'" & DtView1(i)("zip") & "'" Else strSQL += ", NULL" 'zip
            If Not IsDBNull(DtView1(i)("adrs1")) Then strSQL += ", N'" & DtView1(i)("adrs1") & "'" Else strSQL += ", NULL" 'adrs1
            If Not IsDBNull(DtView1(i)("adrs2")) Then strSQL += ", N'" & DtView1(i)("adrs2") & "'" Else strSQL += ", NULL" 'adrs2
            If Not IsDBNull(DtView1(i)("adrs3")) Then strSQL += ", N'" & DtView1(i)("adrs3") & "'" Else strSQL += ", NULL" 'adrs3
            If Not IsDBNull(DtView1(i)("tel")) Then strSQL += ", N'" & DtView1(i)("tel") & "'" Else strSQL += ", NULL" 'tel
            If Not IsDBNull(DtView1(i)("tel2")) Then strSQL += ", N'" & DtView1(i)("tel2") & "'" Else strSQL += ", NULL" 'tel2
            If Not IsDBNull(DtView1(i)("tehai_date")) Then strSQL += ", N'" & DtView1(i)("tehai_date") & "'" Else strSQL += ", NULL" 'tehai_date
            If Not IsDBNull(DtView1(i)("maker_name")) Then strSQL += ", N'" & DtView1(i)("maker_name") & "'" Else strSQL += ", NULL" 'maker_name
            If Not IsDBNull(DtView1(i)("model_name")) Then strSQL += ", N'" & DtView1(i)("model_name") & "'" Else strSQL += ", NULL" 'model_name
            If Not IsDBNull(DtView1(i)("ship_date")) Then strSQL += ", N'" & DtView1(i)("ship_date") & "'" Else strSQL += ", NULL" 'ship_date
            If Not IsDBNull(DtView1(i)("trouble_reason")) Then strSQL += ", N'" & DtView1(i)("trouble_reason") & "'" Else strSQL += ", NULL" 'trouble_reason
            If Not IsDBNull(DtView1(i)("trouble_symptom")) Then strSQL += ", N'" & DtView1(i)("trouble_symptom") & "'" Else strSQL += ", NULL" 'trouble_symptom
            If Not IsDBNull(DtView1(i)("remark")) Then strSQL += ", N'" & DtView1(i)("remark") & "'" Else strSQL += ", NULL" 'remark
            If Not IsDBNull(DtView1(i)("auto_shinkou")) Then
                If IsNumeric(DtView1(i)("auto_shinkou")) = True Then
                    strSQL += ", " & DtView1(i)("auto_shinkou")
                Else
                    strSQL += ", 0" 'auto_shinkou
                End If
            Else
                strSQL += ", 0" 'auto_shinkou
            End If
            If Not IsDBNull(DtView1(i)("daibiki")) Then
                If IsNumeric(DtView1(i)("daibiki")) = True Then
                    strSQL += ", " & DtView1(i)("daibiki")
                Else
                    strSQL += ", 0" 'daibiki
                End If
            Else
                strSQL += ", 0" 'daibiki
            End If
            strSQL += ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        Else            '更新
            WK_DtView1 = New DataView(WK_DsList1.Tables("QA02_data"), "", "", DataViewRowState.CurrentRows)
            Dim bfr_stts_name As String = WK_DtView1(0)("stts_name")

            strSQL = "UPDATE QA02_data"
            strSQL += " SET kbn = N'" & DtView1(i)("kbn") & "'"
            If DtView1(i)("stts") = "10" Then
                strSQL += ", stts = N'20'"
            Else
                strSQL += ", stts = N'" & DtView1(i)("stts") & "'"
            End If
            If Not IsDBNull(DtView1(i)("user_name")) Then strSQL += ", user_name = N'" & DtView1(i)("user_name") & "'"
            If Not IsDBNull(DtView1(i)("user_kana")) Then strSQL += ", user_kana = N'" & DtView1(i)("user_kana") & "'"
            If Not IsDBNull(DtView1(i)("zip")) Then strSQL += ", zip = N'" & DtView1(i)("zip") & "'"
            If Not IsDBNull(DtView1(i)("adrs1")) Then strSQL += ", adrs1 = N'" & DtView1(i)("adrs1") & "'"
            If Not IsDBNull(DtView1(i)("adrs2")) Then strSQL += ", adrs2 = N'" & DtView1(i)("adrs2") & "'"
            If Not IsDBNull(DtView1(i)("adrs3")) Then strSQL += ", adrs3 = N'" & DtView1(i)("adrs3") & "'"
            If Not IsDBNull(DtView1(i)("tel")) Then strSQL += ", tel = N'" & DtView1(i)("tel") & "'"
            If Not IsDBNull(DtView1(i)("tel2")) Then strSQL += ", tel2 = N'" & DtView1(i)("tel2") & "'"
            If Not IsDBNull(DtView1(i)("tehai_date")) Then strSQL += ", tehai_date = N'" & DtView1(i)("tehai_date") & "'"
            If Not IsDBNull(DtView1(i)("maker_name")) Then strSQL += ", maker_name = N'" & DtView1(i)("maker_name") & "'"
            If Not IsDBNull(DtView1(i)("model_name")) Then strSQL += ", model_name = N'" & DtView1(i)("model_name") & "'"
            If Not IsDBNull(DtView1(i)("ship_date")) Then strSQL += ", ship_date = N'" & DtView1(i)("ship_date") & "'"
            If Not IsDBNull(DtView1(i)("trouble_reason")) Then strSQL += ", trouble_reason = N'" & DtView1(i)("trouble_reason") & "'"
            If Not IsDBNull(DtView1(i)("trouble_symptom")) Then strSQL += ", trouble_symptom = N'" & DtView1(i)("trouble_symptom") & "'"
            If Not IsDBNull(DtView1(i)("remark")) Then strSQL += ", remark = N'" & DtView1(i)("remark") & "'"
            If Not IsDBNull(DtView1(i)("auto_shinkou")) Then
                If IsNumeric(DtView1(i)("auto_shinkou")) = True Then
                    strSQL += ", auto_shinkou = " & DtView1(i)("auto_shinkou")
                Else
                    strSQL += ", auto_shinkou = 0"
                End If
            Else
                strSQL += ", auto_shinkou = 0"
            End If
            If Not IsDBNull(DtView1(i)("daibiki")) Then
                If IsNumeric(DtView1(i)("daibiki")) = True Then
                    strSQL += ", daibiki = " & DtView1(i)("daibiki")
                Else
                    strSQL += ", daibiki = 0"
                End If
            Else
                strSQL += ", daibiki = 0"
            End If
            strSQL += ", snd_flg = 0"
            strSQL += " WHERE (qac_no = N'" & DtView1(i)("qac_no") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            '1秒間（1000ミリ秒）停止する
            System.Threading.Thread.Sleep(1000)

            'ステータス受信を変更履歴に登録
            strSQL = "INSERT INTO L01_HSTY"
            strSQL += " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
            strSQL += " SELECT distinct '" & Now & "' AS upd_date"
            strSQL += ", - 99 AS upd_empl_code"
            strSQL += ", QA02_data.gss_rcpt_no AS rcpt_no"
            strSQL += ", 'QACステータス' AS chge_item"
            strSQL += ", '" & bfr_stts_name & "' AS befr"
            strSQL += ", V_cls_052.cls_code_name AS aftr"
            strSQL += " FROM QA02_data INNER JOIN"
            strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
            strSQL += " WHERE (QA02_data.qac_no = N'" & DtView1(i)("qac_no") & "')"
            strSQL += " AND (QA02_data.gss_rcpt_no IS NOT NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()

            '破棄依頼と修理キャンセルの時、備考を完了コメントにセット
            WK_str = Nothing
            mt_str = Nothing
            Select Case DtView1(i)("stts")
                Case Is = "120", "150", "151"
                    If Not IsDBNull(DtView1(i)("remark")) Then
                        WK_DsList2.Clear()
                        strSQL = "SELECT T01_REP_MTR.rcpt_no, T01_REP_MTR.comp_comn FROM T01_REP_MTR INNER JOIN QA02_data ON T01_REP_MTR.rcpt_no = QA02_data.gss_rcpt_no WHERE (QA02_data.qac_no = N'" & DtView1(i)("qac_no") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        r3 = DaList1.Fill(WK_DsList2, "T01_REP_MTR")
                        If r3 <> 0 Then
                            WK_DtView1 = New DataView(WK_DsList2.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
                            If IsDBNull(WK_DtView1(0)("comp_comn")) Then
                                WK_str = DtView1(i)("remark")
                                mt_str = Nothing
                            Else
                                mt_str = Trim(WK_DtView1(0)("comp_comn"))
                                WK_str = Trim(WK_DtView1(0)("comp_comn"))
                                Dim scn As Integer = WK_str.IndexOf(DtView1(i)("remark"))

                                Select Case scn
                                    Case Is >= 0 '同じコメントあり
                                    Case Else   '同じコメントなし（追記）
                                        WK_str += vbCrLf & DtView1(i)("remark")
                                End Select
                            End If

                            If mt_str <> WK_str Then
                                WK_str = MidB(WK_str, 1, 500)
                                strSQL = "UPDATE T01_REP_MTR"
                                strSQL += " SET comp_comn = '" & WK_str & "'"
                                strSQL += " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()

                                '変更履歴
                                strSQL = "INSERT INTO L01_HSTY"
                                strSQL += " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
                                strSQL += " VALUES (CONVERT(DATETIME, '" & Now & "', 102)"
                                strSQL += ", -99"
                                strSQL += ", '" & WK_DtView1(0)("rcpt_no") & "'"
                                strSQL += ", '完了コメント'"
                                strSQL += ", '" & mt_str & "'"
                                strSQL += ", '" & WK_str & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.CommandTimeout = 600
                                SqlCmd1.ExecuteNonQuery()
                            End If

                        End If
                    End If
            End Select
        End If
    End Sub

End Class
