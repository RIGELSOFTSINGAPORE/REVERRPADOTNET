Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strData, WKstr As String
    Dim i, r As Integer
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
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Diagnostics.EventLog.WriteEntry("nQGCare OBIC START", "オービック用データを出力を開始します。", System.Diagnostics.EventLogEntryType.Information)
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

        System.Diagnostics.EventLog.WriteEntry("nQGCare OBIC END", "オービック用データを出力を終了します。", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub

    '******************************************************************
    '** データセット
    '******************************************************************
    Sub ds_set()
        WK_DsList1.Clear()
        strSQL = "SELECT cls_code_name FROM M02_cls WHERE (cls = 'OBC')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(WK_DsList1, "cls_OBC")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("cls_OBC"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then strFile = Trim(WK_DtView1(0)("cls_code_name")) & "\" & Trim(WK_DtView1(1)("cls_code_name"))
            If Not IsDBNull(WK_DtView1(0)("cls_code_name")) Then dl_fldr = Trim(WK_DtView1(0)("cls_code_name"))
            log_fldr = dl_fldr & "\log"
        End If
    End Sub

    '******************************************************************
    '** CSV出力
    '******************************************************************
    Sub csv_out()
        fr_date = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM") & "/01"
        to_date = DateAdd(DateInterval.Month, 1, fr_date)
        'fr_date = "2019/04/01"
        'to_date = "2019/04/10"

        DsList1.Clear()
        strSQL = "SELECT T01_member.code, T01_member.user_name, T01_member.use_name_kana, T01_member.zip, T01_member.adrs1"
        strSQL += ", T01_member.adrs2, T01_member.tel, M01_univ.univ_name, T01_member.dpmt_name, T01_member.sbjt_name"
        strSQL += ", T01_member.makr_code, M05_VNDR.name AS makr_name, T01_member.modl_name, T01_member.s_no"
        strSQL += ", T01_member.prch_amnt, V_M02_HSK.cls_code_name AS wrn_tem_name, T01_member.makr_wrn_stat"
        strSQL += ", V_M02_HSY.cls_code_name AS wrn_range_name, M04_shop.shop_name, T01_member.wrn_fee"
        strSQL += ", T01_member.Part_date, T01_member.reg_date, M04_shop.ittpan, T02_clct.clct_date"
        strSQL += ", M04_shop.shop_shop_code, M04_shop.ivc_old_flg, T01_member.wrn_range"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " M05_VNDR ON T01_member.makr_code = M05_VNDR.vndr_code LEFT OUTER JOIN"
        strSQL += " T02_clct ON T01_member.code = T02_clct.code LEFT OUTER JOIN"
        strSQL += " V_M02_HSY ON T01_member.wrn_range = V_M02_HSY.cls_code LEFT OUTER JOIN"
        strSQL += " V_M02_HSK ON T01_member.wrn_tem = V_M02_HSK.cls_code"
        strSQL += " WHERE (T01_member.delt_flg = 0)"
        strSQL += " AND (M04_shop.ittpan = 0)"
        strSQL += " AND (T01_member.wrn_range <> 7)"
        strSQL += " AND (T01_member.wrn_range <> 10)"
        strSQL += " AND (T01_member.reg_date >= CONVERT(DATETIME, '" & fr_date & "', 102))"
        strSQL += " AND (T01_member.reg_date < CONVERT(DATETIME, '" & to_date & "', 102))"
        'strSQL += " AND (T02_clct.clct_date >= CONVERT(DATETIME, '" & fr_date & "', 102))"
        'strSQL += " AND (T02_clct.clct_date <= CONVERT(DATETIME, '" & to_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T01_member")
        DB_CLOSE()

        If r <> 0 Then

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "加入番号,氏名,氏名カナ,郵便番号,住所１,住所２,電話番号,大学名,学部名,学科名"
            strData = strData & ",メーカーコード,メーカー名,モデル名,S/N,購入金額,保証期間,メーカー保証開始"
            strData = strData & ",保証範囲コード,保証範囲名,販売店,保険料,加入日,登録日付,Coop,店舗コード,請求方式,税込組価,保証開始日"
            swFile.WriteLine(strData)

            Cursor = System.Windows.Forms.Cursors.WaitCursor
            DtView1 = New DataView(DsList1.Tables("T01_member"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                strData = DtView1(i)("code")                            '加入番号
                If Not IsDBNull(DtView1(i)("user_name")) Then WKstr = Replace(DtView1(i)("user_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '氏名
                If Not IsDBNull(DtView1(i)("use_name_kana")) Then WKstr = Replace(DtView1(i)("use_name_kana"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '氏名カナ
                strData = strData & "," & DtView1(i)("zip")             '郵便番号
                If Not IsDBNull(DtView1(i)("adrs1")) Then WKstr = Replace(DtView1(i)("adrs1"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '住所１
                If Not IsDBNull(DtView1(i)("adrs2")) Then WKstr = Replace(DtView1(i)("adrs2"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '住所２
                If Not IsDBNull(DtView1(i)("tel")) Then WKstr = Replace(DtView1(i)("tel"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '電話番号
                If Not IsDBNull(DtView1(i)("univ_name")) Then WKstr = Replace(DtView1(i)("univ_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '大学名
                If Not IsDBNull(DtView1(i)("dpmt_name")) Then WKstr = Replace(DtView1(i)("dpmt_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '学部名
                If Not IsDBNull(DtView1(i)("sbjt_name")) Then WKstr = Replace(DtView1(i)("sbjt_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '学科名
                If Not IsDBNull(DtView1(i)("makr_code")) Then WKstr = Replace(DtView1(i)("makr_code"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         'メーカーコード
                If Not IsDBNull(DtView1(i)("makr_name")) Then WKstr = Replace(DtView1(i)("makr_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         'メーカー名
                If Not IsDBNull(DtView1(i)("modl_name")) Then WKstr = Replace(DtView1(i)("modl_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         'モデル名
                If Not IsDBNull(DtView1(i)("s_no")) Then WKstr = Replace(DtView1(i)("s_no"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         'S/N
                strData = strData & "," & DtView1(i)("prch_amnt")       '購入金額
                strData = strData & "," & DtView1(i)("wrn_tem_name")    '保証期間
                strData = strData & "," & DtView1(i)("makr_wrn_stat")   'メーカー保証開始
                strData = strData & "," & DtView1(i)("wrn_range")       '保証範囲コード
                strData = strData & "," & DtView1(i)("wrn_range_name")  '保証範囲名
                If Not IsDBNull(DtView1(i)("shop_name")) Then WKstr = Replace(DtView1(i)("shop_name"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '販売店
                strData = strData & "," & DtView1(i)("wrn_fee")         '保険料
                strData = strData & "," & DtView1(i)("Part_date")       '加入日
                strData = strData & "," & DtView1(i)("reg_date")        '登録日付
                If Not IsDBNull(DtView1(i)("ittpan")) Then
                    If DtView1(i)("ittpan") = "False" Then
                        strData = strData & ",Y"                        'Coop
                    Else
                        strData = strData & ",N"
                    End If
                Else
                    strData = strData & ","
                End If
                If Not IsDBNull(DtView1(i)("shop_shop_code")) Then WKstr = Replace(DtView1(i)("shop_shop_code"), ",", " ") Else WKstr = ""
                strData = strData & "," & WKstr                         '店舗コード
                If DtView1(i)("ivc_old_flg") = "False" Then
                    strData = strData & ",0"                            '請求方式
                Else
                    strData = strData & ",1"
                End If
                strData = strData & "," & DtView1(i)("wrn_fee") * 1.1   '税込組価
                strData = strData & "," & DtView1(i)("makr_wrn_stat")   '保証開始日

                strData = Replace(strData, System.Environment.NewLine, "")
                strData = Replace(strData, vbCrLf, "")
                strData = Replace(strData, vbCr, "")
                strData = Replace(strData, vbLf, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          'ファイルを閉じる
            'System.Diagnostics.EventLog.WriteEntry("nQGCare OBIC " & r & "件", "オービック用データを出力しました。" & fr_date & "～" & DateAdd(DateInterval.Day, -1, to_date), System.Diagnostics.EventLogEntryType.Information)
        End If

    End Sub
End Class
