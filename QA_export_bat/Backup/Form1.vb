Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL, Err_F, strDATA As String
    Dim strcurdir As String
    Dim i As Integer

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
        Me.ClientSize = New System.Drawing.Size(292, 53)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("QA_export_START", "", System.Diagnostics.EventLogEntryType.Information)
        Call inz()      '** 初期処理
        Call ds_set()  '** データセット
        DsList1.Clear()

        Call stts_20()  '** 20:入荷待ちデータ抽出
        Call stts_30()  '** 30:入荷あり（申請書なし）データ抽出
        Call stts_40()  '** 40:受付データ抽出
        Call stts_60()  '** 60:見積もり結果データ抽出
        Call stts_80()  '** 80:修理不可データ抽出
        Call stts_90()  '** 90:修理完了データ抽出
        Call stts_110() '** 110:出荷データ抽出
        Call stts_130() '** 130:破棄完了データ抽出

        Call csv_out()  '** CSV出力

        '60秒間（60000ミリ秒）停止する
        System.Threading.Thread.Sleep(60000)

        Call FTP_up()   '** CSVデータアップロード

        '60秒間（60000ミリ秒）停止する
        System.Threading.Thread.Sleep(60000)

        'ﾌｧｲﾙ移動
        For Each strFile In System.IO.Directory.GetFiles(dl_fldr, "*.csv")
            filename = strFile.Substring(strFile.LastIndexOf("\") + 1)
            Dim csvFileName As String = filename '"test.csv"
            System.IO.File.Move(dl_fldr & "\" & csvFileName, log_fldr & "\" & csvFileName)
        Next

        System.Diagnostics.EventLog.WriteEntry("QA_export_END", "", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

    '******************************************************************
    '** 初期処理
    '******************************************************************
    Sub inz()
        Call DB_INIT()
        strcurdir = System.IO.Directory.GetCurrentDirectory                                 '実行フォルダー
        Err_F = "0"
    End Sub

    '******************************************************************
    '** データセット
    '******************************************************************
    Sub ds_set()
        DsList1.Clear()

        strSQL = "SELECT * FROM QA_ftp_ini"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "QA_ftp_ini")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("QA_ftp_ini"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            dl_fldr = DtView1(0)("dl_fldr_SND")
            If System.IO.Directory.Exists(dl_fldr) = False Then       '送信フォルダ　無ければ作成する
                System.IO.Directory.CreateDirectory(dl_fldr)
            End If

            log_fldr = DtView1(0)("log_fldr_SND")
            If System.IO.Directory.Exists(log_fldr) = False Then       '送信フォルダ　無ければ作成する
                System.IO.Directory.CreateDirectory(log_fldr)
            End If
        Else
            'msg.Text = "ＦＴＰ設定ファイル未設定"
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '******************************************************************
    '** 20:入荷待ちデータ抽出
    '******************************************************************
    Sub stts_20()
        If Format(Now, "HH") = "17" Then
            DB_OPEN()

            strSQL = "SELECT QA02_data.*"
            strSQL += " FROM QA02_data"
            strSQL += " WHERE (snd_flg = 1)"
            strSQL += " AND (stts = N'20')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "Qsnd_csv")

            DB_CLOSE()
        End If
    End Sub

    '******************************************************************
    '** 30:入荷あり（申請書なし）データ抽出
    '******************************************************************
    Sub stts_30()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'30')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 40:受付データ抽出
    '******************************************************************
    Sub stts_40()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'40')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 60:見積もり結果データ抽出
    '******************************************************************
    Sub stts_60()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'60')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 80:修理不可データ抽出
    '******************************************************************
    Sub stts_80()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'80')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 90:修理完了データ抽出
    '******************************************************************
    Sub stts_90()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'90')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 110:出荷データ抽出
    '******************************************************************
    Sub stts_110()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'110')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** 130:破棄完了データ抽出
    '******************************************************************
    Sub stts_130()
        DB_OPEN()

        strSQL = "SELECT QA02_data.*"
        strSQL += " FROM QA02_data"
        strSQL += " WHERE (snd_flg = 1)"
        strSQL += " AND (stts = N'130')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "Qsnd_csv")

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** CSV出力
    '******************************************************************
    Sub csv_out()
        DB_OPEN()
        DtView1 = New DataView(DsList1.Tables("Qsnd_csv"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim swFile As New System.IO.StreamWriter(dl_fldr & "\DP001A_" & Format(Now, "yyyyMMddHHmm") & ".csv", False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strDATA = Chr(34) & "案件区分" & Chr(34) & "," & Chr(34) & "QAC管理番号" & Chr(34) & "," & Chr(34) & "進行ステータス"
            strDATA += Chr(34) & "," & Chr(34) & "お客様氏名" & Chr(34) & "," & Chr(34) & "お客様氏名カナ"
            strDATA += Chr(34) & "," & Chr(34) & "郵便番号" & Chr(34) & "," & Chr(34) & "住所1" & Chr(34) & "," & Chr(34) & "住所2"
            strDATA += Chr(34) & "," & Chr(34) & "住所3" & Chr(34) & "," & Chr(34) & "電話番号_自宅"
            strDATA += Chr(34) & "," & Chr(34) & "電話番号_携帯" & Chr(34) & "," & Chr(34) & "修理手配日"
            strDATA += Chr(34) & "," & Chr(34) & "メーカー名" & Chr(34) & "," & Chr(34) & "機種名"
            strDATA += Chr(34) & "," & Chr(34) & "製品出荷日" & Chr(34) & "," & Chr(34) & "故障事由"
            strDATA += Chr(34) & "," & Chr(34) & "故障症状" & Chr(34) & "," & Chr(34) & "備考" & Chr(34) & "," & Chr(34) & "自動進行"
            strDATA += Chr(34) & "," & Chr(34) & "代引金額" & Chr(34) & "," & Chr(34) & "GSS伝票番号"
            strDATA += Chr(34) & "," & Chr(34) & "修理区分" & Chr(34) & "," & Chr(34) & "メーカー名"
            strDATA += Chr(34) & "," & Chr(34) & "故障個所" & Chr(34) & "," & Chr(34) & "部品名" & Chr(34) & "," & Chr(34) & "部品価格"
            strDATA += Chr(34) & "," & Chr(34) & "見積料" & Chr(34) & "," & Chr(34) & "技術料" & Chr(34) & "," & Chr(34) & "メーカ取次手数料"
            strDATA += Chr(34) & "," & Chr(34) & "送料" & Chr(34) & "," & Chr(34) & "代引手数料" & Chr(34) & "," & Chr(34) & "キャンセル料"
            strDATA += Chr(34) & "," & Chr(34) & "合計額" & Chr(34) & "," & Chr(34) & "発送日" & Chr(34) & "," & Chr(34) & "配送伝票番号"
            strDATA += Chr(34) & "," & Chr(34) & "GSS備考" & Chr(34) & "," & Chr(34) & "修理完了予定日"
            strDATA += Chr(34) & "," & Chr(34) & "廃棄日" & Chr(34)
            swFile.WriteLine(strDATA)

            For i = 0 To DtView1.Count - 1
                strDATA = Chr(34) & DtView1(i)("kbn") & Chr(34)                     '案件区分
                strDATA += "," & Chr(34) & DtView1(i)("qac_no") & Chr(34)           'QAC管理番号
                strDATA += "," & Chr(34) & DtView1(i)("stts") & Chr(34)             '進行ステータス
                strDATA += "," & Chr(34) & DtView1(i)("user_name") & Chr(34)        'お客様指名
                strDATA += "," & Chr(34) & DtView1(i)("user_kana") & Chr(34)        'お客様指名カナ
                strDATA += "," & Chr(34) & DtView1(i)("zip") & Chr(34)              '郵便番号
                strDATA += "," & Chr(34) & DtView1(i)("adrs1") & Chr(34)            '住所1
                strDATA += "," & Chr(34) & DtView1(i)("adrs2") & Chr(34)            '住所2
                strDATA += "," & Chr(34) & DtView1(i)("adrs3") & Chr(34)            '住所3
                strDATA += "," & Chr(34) & DtView1(i)("tel") & Chr(34)              '電話番号（自宅）
                strDATA += "," & Chr(34) & DtView1(i)("tel2") & Chr(34)             '電話番号（携帯）
                strDATA += "," & Chr(34) & DtView1(i)("tehai_date") & Chr(34)       '修理手配日
                strDATA += "," & Chr(34) & DtView1(i)("maker_name") & Chr(34)       'メーカー名
                strDATA += "," & Chr(34) & DtView1(i)("model_name") & Chr(34)       '機種名
                strDATA += "," & Chr(34) & DtView1(i)("ship_date") & Chr(34)        '製品出荷日
                strDATA += "," & Chr(34) & DtView1(i)("trouble_reason") & Chr(34)   '故障事由
                strDATA += "," & Chr(34) & DtView1(i)("trouble_symptom") & Chr(34)  '故障症状
                strDATA += "," & Chr(34) & DtView1(i)("remark") & Chr(34)           '備考
                strDATA += "," & Chr(34) & DtView1(i)("auto_shinkou") & Chr(34)     '自動進行
                strDATA += "," & Chr(34) & DtView1(i)("daibiki") & Chr(34)          '代引金額
                strDATA += "," & Chr(34) & DtView1(i)("gss_rcpt_no") & Chr(34)      'GSS伝票番号
                strDATA += "," & Chr(34) & DtView1(i)("repr_post") & Chr(34)        '修理区分（1:自社 2:他社）
                strDATA += "," & Chr(34) & DtView1(i)("repr_maker_name") & Chr(34)  '修理メーカー名
                strDATA += "," & Chr(34) & DtView1(i)("trouble_point") & Chr(34)    '故障個所
                strDATA += "," & Chr(34) & DtView1(i)("parts_name") & Chr(34)       '部品名
                strDATA += "," & Chr(34) & DtView1(i)("parts_amnt") & Chr(34)       '部品価格
                strDATA += "," & Chr(34) & DtView1(i)("etmt_amnt") & Chr(34)        '見積料
                strDATA += "," & Chr(34) & DtView1(i)("tech_amnt") & Chr(34)        '技術料
                strDATA += "," & Chr(34) & DtView1(i)("maker_fee") & Chr(34)        'メーカー取次手数料
                strDATA += "," & Chr(34) & DtView1(i)("pstg") & Chr(34)             '送料
                strDATA += "," & Chr(34) & DtView1(i)("daibiki_fee") & Chr(34)      '代引手数料
                strDATA += "," & Chr(34) & DtView1(i)("cxl_amnt") & Chr(34)         'キャンセル料
                strDATA += "," & Chr(34) & DtView1(i)("ttl_amnt") & Chr(34)         '合計額
                strDATA += "," & Chr(34) & DtView1(i)("haso_date") & Chr(34)        '発送日
                strDATA += "," & Chr(34) & DtView1(i)("haiso_den_no") & Chr(34)     '配送伝票番号
                strDATA += "," & Chr(34) & DtView1(i)("gss_remark") & Chr(34)       'GSS備考
                strDATA += "," & Chr(34) & DtView1(i)("comp_plan_date") & Chr(34)   '修理完了予定日
                strDATA += "," & Chr(34) & DtView1(i)("disposal_date") & Chr(34)    '廃棄日
                swFile.WriteLine(strDATA)

                If DtView1(i)("stts") <> "20" Then    '入荷待ち以外は送信フラグOFF
                    strSQL = "UPDATE QA02_data SET snd_flg = 0 WHERE (id = " & DtView1(i)("id") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                End If
            Next
            swFile.Close()          'ファイルを閉じる
        End If
        DB_CLOSE()
    End Sub

End Class
