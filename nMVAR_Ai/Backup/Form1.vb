Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2, WK_DsList3 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim date_now As Date

    Dim strSQL, Err_F, WK_str, WK_str2, apse_f, strFile, strData As String
    Dim csv(256), dir, Fname, fullname As String
    Dim i, j, r, r2, pos, apse_r, WK_apse, cnt, ttl_cnt As Integer

    Dim WK_rcpt_no, WK_T1 As String
    Dim CG_rcpt_ent_empl_code, CG_repr_empl_code, CG_rcpt_brch_code, CG_arvl_cls As String
    Dim CG_vndr_code, CG_repr_brch_code, CG_defe_cls As String

    Dim sum_cost_part, sum_cost_tax, sum_cost_ttl As Integer
    Dim sum_shop_part, sum_shop_tax, sum_shop_ttl As Integer
    Dim sum_eu_part, sum_eu_tax, sum_eu_ttl As Integer
    Dim WK_tech_chrg, WK_fee As Integer

    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer

    Public P_EMPL_NO As Integer   'LogIn User情報
    Public P_EMPL As String   'LogIn User情報

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
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.f01 = New System.Windows.Forms.Button
        Me.f12 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Location = New System.Drawing.Point(20, 16)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 1
        Me.f01.Text = "取込み"
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(132, 16)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 3
        Me.f12.Text = "閉じる"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(250, 75)
        Me.ControlBox = False
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.f01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "旧MVARからデータ取込み"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DB_INIT()
        inz()   '**  初期処理
        If Err_F = "1" Then Application.Exit() : Exit Sub
        Call ds_set()
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Err_F = "0"
        P_EMPL = System.Environment.UserName
        If P_EMPL = "otsuki" Then P_EMPL = "administrator" '大槻テスト用

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SP_Login_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.VarChar, 20)
        Pram1.Value = P_EMPL
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M01_EMPL")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("M01_EMPL"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            Err_F = "1"
            MessageBox.Show("ユーザーが登録されていません。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DtView1(0)("delt_flg") = "1" Then
                Err_F = "1"
                MessageBox.Show("ユーザー登録が無効です。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                P_EMPL_NO = DtView1(0)("empl_code")
            End If
        End If
    End Sub

    Sub ds_set()
        DsList1.Clear()
        DB_OPEN("nMVAR")

        strSQL = "SELECT seq, vndr_code, select_case, tech_amnt"
        strSQL = strSQL & " FROM M14_VNDR_SUB"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "M14_VNDR_SUB")

        strSQL = "SELECT * FROM M21_CLS_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "CLS_CODE")

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  取込みボタン
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click

        With OpenFileDialog1
            .CheckFileExists = True     'ファイルが存在するか確認
            .RestoreDirectory = True    'ディレクトリの復元
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "CSV ﾌｧｲﾙ(*.csv)|*.csv"
            .FilterIndex = 0
            .InitialDirectory = "\\tsclient\c\nMVAR"

            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor

                date_now = Now
                fullname = .FileName
                dir = Mid(fullname, 1, fullname.LastIndexOf("\") + 1)
                Fname = fullname.Substring(fullname.LastIndexOf("\") + 1)

                ' 進行状況ダイアログの初期化処理
                waitDlg = New WaitDialog        ' 進行状況ダイアログ
                waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
                waitDlg.MainMsg = Nothing       ' 処理の概要を表示
                waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
                waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       ' 最初の件数を設定
                Me.Enabled = False              ' オーナーのフォームを無効にする
                waitDlg.Show()                  ' 進行状況ダイアログを表示する

                waitDlg.MainMsg = "取込み中"   ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMax = r         ' 全体の処理件数を設定
                waitDlg.ProgressValue = 0       ' 最初の件数を設定
                Application.DoEvents()          ' メッセージ処理を促して表示を更新する

                Dim csvDir As String = dir              'CSVファイルのあるフォルダ
                Dim csvFileName As String = Fname       'CSVファイルの名前

                '接続文字列
                Dim conString As String = _
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" _
                    + csvDir + ";Extended Properties=""text;HDR=No;FMT=Delimited"""
                Dim con As New System.Data.OleDb.OleDbConnection(conString)

                Dim commText As String = "SELECT * FROM [" + csvFileName + "]"
                Dim da As New System.Data.OleDb.OleDbDataAdapter(commText, con)

                'DataTableに格納する
                Dim dt As New DataTable
                da.Fill(dt)
                Dim colCount As Integer = dt.Columns.Count
                Dim row As DataRow

                ttl_cnt = dt.Rows.Count()
                If ttl_cnt > 1 Then

                    ttl_cnt = ttl_cnt - 1
                    waitDlg.MainMsg = "登録中"      ' 進行状況ダイアログのメーターを設定
                    waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
                    waitDlg.ProgressMax = r         ' 全体の処理件数を設定
                    waitDlg.ProgressValue = 0       ' 最初の件数を設定
                    Application.DoEvents()          ' メッセージ処理を促して表示を更新する
                    cnt = 0
                    For Each row In dt.Rows
                        If cnt <> 0 Then

                            For i = 0 To colCount - 1
                                Dim field As String = row(i).ToString()
                                csv(i + 1) = field
                            Next i

                            waitDlg.ProgressMsg = Fix((cnt) * 100 / ttl_cnt) & "%　（" & Format(cnt, "##,##0") & " / " & Format(ttl_cnt, "##,##0") & " 件）"
                            waitDlg.Text = "実行中・・・" & Fix((cnt) * 100 / ttl_cnt) & "%"
                            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                            DB_OPEN("nMVAR")

                            'メーカーコード変換
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '043' AND cls_code_name = '" & csv(234) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_vndr_code = WK_DtView1(0)("cls_code_name_abbr")                          'メーカーコード
                            Else
                                CG_vndr_code = ""
                            End If

                            '担当者コード変換
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '044' AND cls_code_name = '" & csv(51) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_rcpt_ent_empl_code = WK_DtView1(0)("cls_code_name_abbr")                 '担当者コード
                            Else
                                CG_rcpt_ent_empl_code = "0"
                            End If

                            '部署コード変換
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '045' AND cls_code_name = '" & csv(1) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_rcpt_brch_code = WK_DtView1(0)("cls_code_name_abbr")                     '部署コード
                            Else
                                CG_rcpt_brch_code = ""
                            End If

                            '入荷区分変換
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '046' AND cls_code_name = '" & csv(6) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_arvl_cls = WK_DtView1(0)("cls_code_name_abbr")                           '入荷区分
                            Else
                                CG_arvl_cls = ""
                            End If

                            '修理拠点コード変換
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '047' AND cls_code_name = '" & csv(1) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_repr_brch_code = WK_DtView1(0)("cls_code_name_abbr")                     '修理拠点コード
                            Else
                                CG_repr_brch_code = ""
                            End If

                            'Mobile種別変換
                            WK_DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "cls_no = '048' AND cls_code_name = '" & csv(229) & "'", "", DataViewRowState.CurrentRows)
                            If WK_DtView1.Count <> 0 Then
                                CG_defe_cls = WK_DtView1(0)("cls_code_name_abbr")                           'Mobile種別
                            Else
                                CG_defe_cls = ""
                            End If

                            WK_DsList1.Clear()
                            strSQL = "SELECT *"
                            strSQL = strSQL & " FROM T01_REP_MTR"
                            strSQL = strSQL & " WHERE (imv_rcpt_no = '" & CG_rcpt_brch_code & csv(2) & "')" '伝票番号
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            SqlCmd1.CommandTimeout = 600
                            r = DaList1.Fill(WK_DsList1, "T01_REP_MTR")

                            DB_CLOSE()

                            If r = 0 Then   '新規登録

                                'メーカーマスタから受付番号上2桁取得
                                strSQL = "SELECT rcpt_up2 FROM M05_VNDR"
                                strSQL = strSQL & " WHERE (vndr_code = '" & CG_vndr_code & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                DB_OPEN("nMVAR")
                                DaList1.Fill(WK_DsList1, "M05_VNDR")
                                DB_CLOSE()
                                WK_DtView2 = New DataView(WK_DsList1.Tables("M05_VNDR"), "", "", DataViewRowState.CurrentRows)
                                If WK_DtView2.Count <> 0 Then
                                    '受付番号採番
                                    WK_T1 = WK_DtView2(0)("rcpt_up2")
                                    WK_rcpt_no = Count_Get(WK_T1)
                                End If

                                strSQL = "INSERT INTO T01_REP_MTR"
                                strSQL = strSQL & " (rcpt_no, rcpt_ent_empl_code, rcpt_brch_code, rcpt_cls, qg_care_no, arvl_cls, arvl_empl"
                                strSQL = strSQL & ", store_code, store_prsn, store_repr_no, store_accp_date, store_wrn_info, store_tech_rate"
                                strSQL = strSQL & ", store_tech_mrgn_rate, store_part_mrgn_rate, user_name, user_name_kana, zip, adrs1, adrs2"
                                strSQL = strSQL & ", tel1, tel2, rpar_cls, prch_date, vndr_wrn_date, vndr_wrn_date_chk, vndr_code, model_1"
                                strSQL = strSQL & ", model_2, note_kbn, note_kbn2, s_n, rpar_comp_code, user_trbl, rcpt_comn, orgnl_vndr_code"
                                strSQL = strSQL & ", wrn_limt_amnt, menseki_amnt, acdt_stts, acdt_date, recv_amnt, tech_rate1, fix1, tech_rate2"
                                strSQL = strSQL & ", part_rate2, etmt_ent_empl_code, etmt_brch_code, etmt_empl_code, tier, vndr_repr_no"
                                strSQL = strSQL & ", etmt_meas, etmt_comn, rsrv_cacl_comn, etmt_cost_tech_chrg, etmt_cost_apes"
                                strSQL = strSQL & ", etmt_cost_part_chrg, etmt_cost_fee, etmt_cost_pstg, etmt_cost_tax, etmt_cost_cxl"
                                strSQL = strSQL & ", etmt_cost_ttl, etmt_shop_tech_chrg, etmt_shop_apes, etmt_shop_part_chrg, etmt_shop_fee"
                                strSQL = strSQL & ", etmt_shop_pstg, etmt_shop_tax, etmt_shop_cxl, etmt_shop_ttl, etmt_eu_tech_chrg"
                                strSQL = strSQL & ", etmt_eu_apes, etmt_eu_part_chrg, etmt_eu_fee, etmt_eu_pstg, etmt_eu_tax, etmt_eu_cxl"
                                strSQL = strSQL & ", etmt_eu_ttl, zh_code, etmt_sum_flg, fin_ent_empl_code, repr_empl_code, repr_brch_code"
                                strSQL = strSQL & ", comp_meas, m_tech_seq, comp_comn, comp_cost_tech_chrg, comp_cost_apes, comp_cost_part_chrg"
                                strSQL = strSQL & ", comp_cost_fee, comp_cost_pstg, comp_cost_tax, comp_cost_cxl, comp_cost_ttl"
                                strSQL = strSQL & ", comp_shop_tech_chrg, comp_shop_apes, comp_shop_part_chrg, comp_shop_fee, comp_shop_pstg"
                                strSQL = strSQL & ", comp_shop_tax, comp_shop_cxl, comp_shop_ttl, comp_eu_tech_chrg, comp_eu_apes"
                                strSQL = strSQL & ", comp_eu_part_chrg, comp_eu_fee, comp_eu_pstg, comp_eu_tax, comp_eu_cxl, comp_eu_ttl"
                                strSQL = strSQL & ", comp_sum_flg, zero_code, zero_name, re_rpar_date, rebate, kjo_brch_code, rcpt_no_aka"
                                strSQL = strSQL & ", rcpt_no_kuro, aka_flg, rpt_ex_flg, accp_date, etmt_date, rsrv_cacl_date, part_ordr_date"
                                strSQL = strSQL & ", part_rcpt_date, comp_date, sals_date, sals_no, sals_no2, ship_date, rqst_date, tax_rate"
                                strSQL = strSQL & ", wrn_period, idvd_chrg, neva_chek_flg, neva_amnt, defe_cls, reference_no, imv_rcpt_no)"

                                strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"               '受付番号
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '受付入力者コード
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"   '受付部署コード
                                If csv(234) = "3" Then
                                    strSQL = strSQL & ", '11'"                                  '受付種別(CLS:007)
                                Else
                                    strSQL = strSQL & ", '01'"
                                End If
                                strSQL = strSQL & ", ''"                                        'QG Care№
                                strSQL = strSQL & ", '" & MidB(CG_arvl_cls, 1, 2) & "'"         '入荷区分(CLS:018)
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '入荷担当
                                strSQL = strSQL & ", '0020'"                                    '販社コード
                                strSQL = strSQL & ", ''"                                        '販社担当者
                                strSQL = strSQL & ", ''"                                        '販社修理番号
                                strSQL = strSQL & ", NULL"                                      '販社受付日
                                strSQL = strSQL & ", ''"                                        '販社延長情報
                                strSQL = strSQL & ", 0"                                         '販社技術料掛率
                                strSQL = strSQL & ", 0"                                         '販社技術料マージン率
                                strSQL = strSQL & ", 0"                                         '販社部品代マージン率
                                strSQL = strSQL & ", '" & MidB(csv(12), 1, 30) & "'"            'ユーザー名
                                strSQL = strSQL & ", '" & MidB(csv(13), 1, 15) & "'"            'ユーザー名カナ
                                strSQL = strSQL & ", '" & MidB(csv(16), 1, 7) & "'"             '郵便番号
                                strSQL = strSQL & ", '" & MidB(csv(17), 1, 40) & "'"            '住所1
                                strSQL = strSQL & ", '" & MidB(csv(18) & csv(19), 1, 40) & "'"  '住所2
                                strSQL = strSQL & ", '" & MidB(csv(14), 1, 14) & "'"            'ユーザー電話番号1
                                strSQL = strSQL & ", ''"                                        'ユーザー電話番号2
                                If csv(220) = "1" Then
                                    strSQL = strSQL & ", '02'"                                  '修理種別(CLS:001)
                                    apse_f = "1"
                                Else
                                    strSQL = strSQL & ", '01'"
                                    apse_f = "0"
                                End If
                                If IsDate(csv(65)) = True Then
                                    strSQL = strSQL & ", '" & csv(65) & "'"                     '購入日
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      'メーカー保証開始日
                                strSQL = strSQL & ", 0"                                         'リペアエクステンションフラグ
                                strSQL = strSQL & ", '" & MidB(CG_vndr_code, 1, 2) & "'"        'メーカーコード
                                If CG_vndr_code = "01" Or CG_vndr_code = "20" Then
                                    apse_f = apse_f & "1"
                                Else
                                    apse_f = apse_f & "0"
                                End If
                                strSQL = strSQL & ", '" & MidB(csv(58), 1, 50) & "'"            '機種名
                                strSQL = strSQL & ", '" & MidB(csv(59), 1, 50) & "'"            'モデル
                                strSQL = strSQL & ", ''"                                        'ノートPC区分(CLS:011) Appleの時は定額、掛率
                                strSQL = strSQL & ", ''"                                        'ノートPC区分(CLS:011)
                                strSQL = strSQL & ", '" & MidB(csv(61), 1, 25) & "'"            'S/N
                                strSQL = strSQL & ", '" & MidB(CG_repr_brch_code, 1, 2) & "'"   '修理会社コード
                                strSQL = strSQL & ", '" & MidB(csv(78), 1, 500) & "'"           '故障内容
                                strSQL = strSQL & ", '" & MidB(csv(222), 1, 200) & "'"          '受付コメント
                                strSQL = strSQL & ", '" & MidB(csv(11), 1, 50) & "'"            'ｵﾘｼﾞﾅﾙﾒｰｶｰｺｰﾄﾞ
                                strSQL = strSQL & ", 0"                                         '保証限度額
                                strSQL = strSQL & ", 0"                                         '免責額
                                strSQL = strSQL & ", '01'"                                      '事故状況コード(CLS:022)
                                strSQL = strSQL & ", NULL"                                      '事故日
                                strSQL = strSQL & ", " & CInt(csv(201))                         '預かり金
                                strSQL = strSQL & ", 0"                                         '販社技術料掛率
                                strSQL = strSQL & ", 0"                                         '定額
                                strSQL = strSQL & ", 0"                                         'EU技術料掛率
                                strSQL = strSQL & ", 0"                                         'EU部品掛率
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '見積入力者コード
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"   '見積部署コード
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '見積者コード
                                strSQL = strSQL & ", ''"                                        '目安Tier(CLS:013)
                                strSQL = strSQL & ", ''"                                        'メーカー修理番号
                                strSQL = strSQL & ", '" & MidB(csv(241), 1, 300) & "'"          '見積内容
                                strSQL = strSQL & ", ''"                                        '見積コメント
                                strSQL = strSQL & ", ''"                                        '保留解除連絡

                                If csv(39) <> Nothing Then  '見積データ
                                    If csv(220) = "1" Then  '入金種別コード
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If

                                    strSQL = strSQL & ", 0"                                         '見積コスト技術料
                                    strSQL = strSQL & ", 0"                                         '見積コストAPES
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", " & sum_cost_part                          '見積コスト部品代
                                    strSQL = strSQL & ", 0"                                         '見積コストその他
                                    strSQL = strSQL & ", 0"                                         '見積コスト送料
                                    sum_cost_ttl = sum_cost_part
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_cost_tax                           '見積コスト消費税
                                    strSQL = strSQL & ", 0"                                         '見積コストキャンセル料
                                    strSQL = strSQL & ", " & sum_cost_ttl                           '見積コスト小計

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '見積計上技術料
                                    strSQL = strSQL & ", 0"                                         '見積計上APES
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_shop_part                          '見積計上部品代
                                    strSQL = strSQL & ", " & WK_fee                                 '見積計上その他
                                    strSQL = strSQL & ", 0"                                         '見積計上送料
                                    sum_shop_ttl = sum_shop_part + WK_fee + WK_tech_chrg
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_shop_tax                           '見積計上消費税
                                    strSQL = strSQL & ", 0"                                         '見積計上キャンセル料
                                    strSQL = strSQL & ", " & sum_shop_ttl                           '見積計上小計

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '見積EU技術料
                                    strSQL = strSQL & ", 0"                                         '見積EUAPES
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_eu_part                            '見積EU部品代
                                    strSQL = strSQL & ", " & WK_fee                                 '見積EUその他
                                    strSQL = strSQL & ", 0"                                         '見積EU送料
                                    sum_eu_ttl = sum_eu_part + WK_fee + WK_tech_chrg
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_eu_tax                             '見積EU消費税
                                    strSQL = strSQL & ", 0"                                         '見積EUキャンセル料
                                    strSQL = strSQL & ", " & sum_eu_ttl                             '見積EU小計
                                Else
                                    strSQL = strSQL & ", 0"                                         '見積コスト技術料
                                    strSQL = strSQL & ", 0"                                         '見積コストAPES
                                    strSQL = strSQL & ", 0"                                         '見積コスト部品代
                                    strSQL = strSQL & ", 0"                                         '見積コストその他
                                    strSQL = strSQL & ", 0"                                         '見積コスト送料
                                    strSQL = strSQL & ", 0"                                         '見積コスト消費税
                                    strSQL = strSQL & ", 0"                                         '見積コストキャンセル料
                                    strSQL = strSQL & ", 0"                                         '見積コスト小計

                                    strSQL = strSQL & ", 0"                                         '見積計上技術料
                                    strSQL = strSQL & ", 0"                                         '見積計上APES
                                    strSQL = strSQL & ", 0"                                         '見積計上部品代
                                    strSQL = strSQL & ", 0"                                         '見積計上その他
                                    strSQL = strSQL & ", 0"                                         '見積計上送料
                                    strSQL = strSQL & ", 0"                                         '見積計上消費税
                                    strSQL = strSQL & ", 0"                                         '見積計上キャンセル料
                                    strSQL = strSQL & ", 0"                                         '見積計上小計

                                    strSQL = strSQL & ", 0"                                         '見積EU技術料
                                    strSQL = strSQL & ", 0"                                         '見積EUAPES
                                    strSQL = strSQL & ", 0"                                         '見積EU部品代
                                    strSQL = strSQL & ", 0"                                         '見積EUその他
                                    strSQL = strSQL & ", 0"                                         '見積EU送料
                                    strSQL = strSQL & ", 0"                                         '見積EU消費税
                                    strSQL = strSQL & ", 0"                                         '見積EUキャンセル料
                                    strSQL = strSQL & ", 0"                                         '見積EU小計
                                End If

                                strSQL = strSQL & ", ''"                                        '続行返却ｺｰﾄﾞ（Z:続行 H:返却）
                                strSQL = strSQL & ", 0"                                         '見積自動計算しないフラグ
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '完了入力者コード
                                strSQL = strSQL & ", " & CG_rcpt_ent_empl_code                  '修理者コード
                                strSQL = strSQL & ", '" & MidB(CG_repr_brch_code, 1, 2) & "'"   '修理部署コード
                                strSQL = strSQL & ", '" & MidB(csv(83) & csv(84), 1, 1000) & "'" '完了内容

                                If csv(22) <> Nothing Then  '完了データ
                                    If csv(220) = "1" Then
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If

                                    WK_DtView2 = New DataView(DsList1.Tables("M14_VNDR_SUB"), "vndr_code = '" & CG_vndr_code & "' AND tech_amnt = " & WK_tech_chrg, "", DataViewRowState.CurrentRows)
                                    If WK_DtView2.Count <> 0 Then
                                        strSQL = strSQL & ", 0" & WK_DtView2(0)("seq")              'メーカー保証技術料SEQ
                                    Else
                                        strSQL = strSQL & ", 0"
                                    End If
                                    strSQL = strSQL & ", '" & MidB(csv(223), 1, 200) & "'"          '完了コメント

                                    strSQL = strSQL & ", 0"                                         '完了コスト技術料
                                    strSQL = strSQL & ", 0"                                         '完了コストAPES
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", " & sum_cost_part                          '完了コスト部品代
                                    strSQL = strSQL & ", 0"                                         '完了コストその他
                                    strSQL = strSQL & ", 0"                                         '完了コスト送料
                                    sum_cost_ttl = sum_cost_part
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_cost_tax                           '完了コスト消費税
                                    strSQL = strSQL & ", 0"                                         '完了コストキャンセル料
                                    strSQL = strSQL & ", " & sum_cost_ttl                           '完了コスト小計

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '完了計上技術料
                                    WK_apse = 0
                                    'If apse_f = "11" Then
                                    '    If IsDate(csv(22)) = True Then
                                    '        apse_r = APSE_GET(CG_repr_brch_code, csv(22))
                                    '        If apse_r <> 0 Then
                                    '            WK_apse = WK_tech_chrg * (apse_r - 100) / 100
                                    '        End If
                                    '    End If
                                    'End If
                                    strSQL = strSQL & ", " & WK_apse                                '完了計上APES
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_shop_part                          '完了計上部品代
                                    strSQL = strSQL & ", " & WK_fee                                 '完了計上その他
                                    strSQL = strSQL & ", 0"                                         '完了計上送料
                                    sum_shop_ttl = sum_shop_part + WK_fee + WK_tech_chrg + WK_apse
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_shop_tax                           '完了計上消費税
                                    strSQL = strSQL & ", 0"                                         '完了計上キャンセル料
                                    strSQL = strSQL & ", " & sum_shop_ttl                           '完了計上小計

                                    strSQL = strSQL & ", " & WK_tech_chrg                           '完了EU技術料
                                    strSQL = strSQL & ", 0"                                         '完了EUAPES
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", " & sum_eu_part                            '完了EU部品代
                                    strSQL = strSQL & ", " & WK_fee                                 '完了EUその他
                                    strSQL = strSQL & ", 0"                                         '完了EU送料
                                    sum_eu_ttl = sum_eu_part + WK_fee + WK_tech_chrg
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", " & sum_eu_tax                             '完了EU消費税
                                    strSQL = strSQL & ", 0"                                         '完了EUキャンセル料
                                    strSQL = strSQL & ", " & sum_eu_ttl                             '完了EU小計
                                Else
                                    strSQL = strSQL & ", 0"                                         'メーカー保証技術料SEQ
                                    strSQL = strSQL & ", '" & MidB(csv(2), 1, 200) & "'"            '完了コメント

                                    strSQL = strSQL & ", 0"                                         '完了コスト技術料
                                    strSQL = strSQL & ", 0"                                         '完了コストAPES
                                    strSQL = strSQL & ", 0"                                         '完了コスト部品代
                                    strSQL = strSQL & ", 0"                                         '完了コストその他
                                    strSQL = strSQL & ", 0"                                         '完了コスト送料
                                    strSQL = strSQL & ", 0"                                         '完了コスト消費税
                                    strSQL = strSQL & ", 0"                                         '完了コストキャンセル料
                                    strSQL = strSQL & ", 0"                                         '完了コスト小計

                                    strSQL = strSQL & ", 0"                                         '完了計上技術料
                                    strSQL = strSQL & ", 0"                                         '完了計上APES
                                    strSQL = strSQL & ", 0"                                         '完了計上部品代
                                    strSQL = strSQL & ", 0"                                         '完了計上その他
                                    strSQL = strSQL & ", 0"                                         '完了計上送料
                                    strSQL = strSQL & ", 0"                                         '完了計上消費税
                                    strSQL = strSQL & ", 0"                                         '完了計上キャンセル料
                                    strSQL = strSQL & ", 0"                                         '完了計上小計

                                    strSQL = strSQL & ", 0"                                         '完了EU技術料
                                    strSQL = strSQL & ", 0"                                         '完了EUAPES
                                    strSQL = strSQL & ", 0"                                         '完了EU部品代
                                    strSQL = strSQL & ", 0"                                         '完了EUその他
                                    strSQL = strSQL & ", 0"                                         '完了EU送料
                                    strSQL = strSQL & ", 0"                                         '完了EU消費税
                                    strSQL = strSQL & ", 0"                                         '完了EUキャンセル料
                                    strSQL = strSQL & ", 0"                                         '完了EU小計
                                End If

                                strSQL = strSQL & ", 0"                                         '完了自動計算しないフラグ
                                strSQL = strSQL & ", ''"                                        '￥０理由コード
                                strSQL = strSQL & ", '" & MidB(csv(233), 1, 33) & "'"           '￥０理由
                                strSQL = strSQL & ", NULL"                                      '再修理有効期限日
                                strSQL = strSQL & ", 0"                                         'リベート料
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"   '計上部署コード
                                strSQL = strSQL & ", NULL"                                      '受付番号_赤
                                strSQL = strSQL & ", NULL"                                      '受付番号_黒
                                strSQL = strSQL & ", 0"                                         '赤伝ありﾌﾗｸﾞ
                                strSQL = strSQL & ", 0"                                         '集計除外ﾌﾗｸﾞ
                                If IsDate(csv(21)) = True Then
                                    strSQL = strSQL & ", '" & csv(21) & "'"                     '受付日
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                If IsDate(csv(39)) = True Then
                                    strSQL = strSQL & ", '" & csv(39) & "'"                     '見積日
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      '保留解除日
                                strSQL = strSQL & ", NULL"                                      '部品発注日
                                strSQL = strSQL & ", NULL"                                      '部品受領日
                                If IsDate(csv(22)) = True Then
                                    strSQL = strSQL & ", '" & csv(22) & "'"                     '完成日
                                    strSQL = strSQL & ", '" & csv(22) & "'"                     '売上日
                                Else
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      'ネバ伝番号
                                strSQL = strSQL & ", NULL"                                      'ネバ伝番号（リベート）
                                If IsDate(csv(22)) = True Then
                                    strSQL = strSQL & ", '" & csv(22) & "'"                     '出荷日
                                Else
                                    strSQL = strSQL & ", NULL"
                                End If
                                strSQL = strSQL & ", NULL"                                      '請求日
                                strSQL = strSQL & ", 5"                                         '消費税率
                                strSQL = strSQL & ", 0"                                         '修理票保証期間（日）
                                strSQL = strSQL & ", 0"                                         '自己負担金
                                strSQL = strSQL & ", 0"                                         'ネバ伝検収済ﾌﾗｸﾞ（QG）
                                strSQL = strSQL & ", 0"                                         'ネバ伝金額
                                strSQL = strSQL & ", '" & CG_defe_cls & "'"                     '不良種別(CLS:035)
                                strSQL = strSQL & ", '" & MidB(csv(243), 1, 10) & "'"           'レジ番号
                                strSQL = strSQL & ", '" & MidB(CG_rcpt_brch_code, 1, 2) & csv(2) & "')" 'iMVAR管理番号
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DB_OPEN("nMVAR")
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                '使用部品
                                If csv(39) <> Nothing Then  '見積データ
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then
                                            strSQL = "INSERT INTO T04_REP_PART"
                                            strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                            strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                            strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"           '受付番号
                                            strSQL = strSQL & ", '1'"                                   '区分（1:見積 2:完了）
                                            strSQL = strSQL & ", " & j                                  'SEQ
                                            strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"       '部品コード
                                            strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"  '部品名
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 '部品単価
                                            strSQL = strSQL & ", " & CInt(csv(pos + 2))                 '使用数
                                            strSQL = strSQL & ", 0"                                     '在庫使用フラグ
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 'コスト
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'GSS計上
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'EU価
                                            strSQL = strSQL & ", ''"                                    '発注番号
                                            strSQL = strSQL & ", ''"                                    '発受注番
                                            strSQL = strSQL & ", 0"                                     'IBM緊急フラグ
                                            strSQL = strSQL & ", 0)"                                    '消耗品フラグ
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DB_OPEN("nMVAR")
                                            SqlCmd1.ExecuteNonQuery()
                                            DB_CLOSE()
                                        End If
                                    Next
                                End If

                                If csv(22) <> Nothing Then  '完了データ
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then
                                            strSQL = "INSERT INTO T04_REP_PART"
                                            strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                            strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                            strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"           '受付番号
                                            strSQL = strSQL & ", '2'"                                   '区分（1:見積 2:完了）
                                            strSQL = strSQL & ", " & j                                  'SEQ
                                            strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"       '部品コード
                                            strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"  '部品名
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 '部品単価
                                            strSQL = strSQL & ", " & CInt(csv(pos + 2))                 '使用数
                                            strSQL = strSQL & ", 0"                                     '在庫使用フラグ
                                            strSQL = strSQL & ", " & CInt(csv(pos + 6))                 'コスト
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'GSS計上
                                            strSQL = strSQL & ", " & CInt(csv(pos + 3))                 'EU価
                                            strSQL = strSQL & ", ''"                                    '発注番号
                                            strSQL = strSQL & ", ''"                                    '発受注番
                                            strSQL = strSQL & ", 0"                                     'IBM緊急フラグ
                                            strSQL = strSQL & ", 0)"                                    '消耗品フラグ
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DB_OPEN("nMVAR")
                                            SqlCmd1.ExecuteNonQuery()
                                            DB_CLOSE()
                                        End If
                                    Next
                                End If

                                '売上
                                DB_OPEN("nMVAR")
                                If IsDate(csv(22)) = True Then
                                    strSQL = "INSERT INTO T10_SALS"
                                    strSQL = strSQL & " (rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2"
                                    strSQL = strSQL & ", neva_chek_date, neva_chek_date2, neva_chek_list, invc_cls_date, invc_flg)"
                                    strSQL = strSQL & " VALUES ('" & WK_rcpt_no & "'"
                                    strSQL = strSQL & ", '4'"
                                    strSQL = strSQL & ", " & sum_eu_ttl
                                    strSQL = strSQL & ", " & sum_eu_tax
                                    strSQL = strSQL & ", 0"
                                    strSQL = strSQL & ", 0"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", NULL"
                                    strSQL = strSQL & ", 0)"
                                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                    SqlCmd1.ExecuteNonQuery()
                                End If

                                'CSV更新
                                strSQL = "INSERT INTO T50_AI_CSV (imp_date, seq, rcpt_no)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & date_now & "', 102)"
                                strSQL = strSQL & ", 1"
                                strSQL = strSQL & ", '" & WK_rcpt_no & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()

                                '履歴更新
                                strSQL = "INSERT INTO L01_HSTY"
                                strSQL = strSQL & " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & Now & "', 102)"
                                strSQL = strSQL & ", " & P_EMPL_NO
                                strSQL = strSQL & ", '" & WK_rcpt_no & "'"
                                strSQL = strSQL & ", 'Ai取込み'"
                                strSQL = strSQL & ", ''"
                                strSQL = strSQL & ", '')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()


                            Else            '更新
                                WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

                                strSQL = "UPDATE T01_REP_MTR"
                                strSQL = strSQL & " SET rcpt_ent_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", rcpt_brch_code = '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"
                                If csv(234) = "3" Then
                                    strSQL = strSQL & ", rcpt_cls = '11'"
                                Else
                                    strSQL = strSQL & ", rcpt_cls = '01'"
                                End If
                                strSQL = strSQL & ", arvl_cls = '" & MidB(CG_arvl_cls, 1, 2) & "'"
                                strSQL = strSQL & ", arvl_empl = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", user_name = '" & MidB(csv(12), 1, 30) & "'"
                                strSQL = strSQL & ", user_name_kana = '" & MidB(csv(13), 1, 15) & "'"
                                strSQL = strSQL & ", zip = '" & MidB(csv(16), 1, 7) & "'"
                                strSQL = strSQL & ", adrs1 = '" & MidB(csv(17), 1, 40) & "'"
                                strSQL = strSQL & ", adrs2 = '" & MidB(csv(18) & csv(19), 1, 40) & "'"
                                strSQL = strSQL & ", tel1 = '" & MidB(csv(14), 1, 14) & "'"
                                If csv(220) = "1" Then
                                    strSQL = strSQL & ", rpar_cls = '02'"
                                    apse_f = "1"
                                Else
                                    strSQL = strSQL & ", rpar_cls = '01'"
                                    apse_f = "0"
                                End If
                                If IsDate(csv(65)) = True Then
                                    strSQL = strSQL & ", prch_date = CONVERT(DATETIME, '" & csv(65) & "', 102)"
                                Else
                                    strSQL = strSQL & ", prch_date = NULL"
                                End If
                                strSQL = strSQL & ", vndr_code = '" & MidB(CG_vndr_code, 1, 2) & "'"
                                If CG_vndr_code = "01" Or CG_vndr_code = "20" Then
                                    apse_f = apse_f & "1"
                                Else
                                    apse_f = apse_f & "0"
                                End If
                                strSQL = strSQL & ", model_1 = '" & MidB(csv(58), 1, 50) & "'"
                                strSQL = strSQL & ", model_2 = '" & MidB(csv(59), 1, 50) & "'"
                                strSQL = strSQL & ", s_n = '" & MidB(csv(61), 1, 25) & "'"
                                strSQL = strSQL & ", rpar_comp_code = '" & MidB(CG_repr_brch_code, 1, 2) & "'"
                                strSQL = strSQL & ", user_trbl = '" & MidB(csv(78), 1, 200) & "'"
                                strSQL = strSQL & ", rcpt_comn = '" & MidB(csv(222), 1, 200) & "'"
                                strSQL = strSQL & ", orgnl_vndr_code = '" & MidB(csv(11), 1, 50) & "'"
                                strSQL = strSQL & ", acdt_stts = '01'"
                                strSQL = strSQL & ", recv_amnt = '" & CInt(csv(201)) & "'"
                                strSQL = strSQL & ", etmt_ent_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", etmt_brch_code = '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"
                                strSQL = strSQL & ", etmt_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", etmt_meas = '" & MidB(csv(241), 1, 300) & "'"

                                If csv(39) <> Nothing Then  '見積データ
                                    If csv(220) = "1" Then  '入金種別コード
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If

                                    'strSQL = strSQL & ", etmt_cost_tech_chrg = " & WK_DtView1(0)("etmt_cost_tech_chrg")
                                    'strSQL = strSQL & ", etmt_cost_apes = " & WK_DtView1(0)("etmt_cost_apes")
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", etmt_cost_part_chrg = " & sum_cost_part
                                    'strSQL = strSQL & ", etmt_cost_fee = " & WK_DtView1(0)("etmt_cost_fee")
                                    'strSQL = strSQL & ", etmt_cost_pstg = " & WK_DtView1(0)("etmt_cost_pstg")
                                    sum_cost_ttl = WK_DtView1(0)("comp_cost_tech_chrg") + WK_DtView1(0)("etmt_cost_apes") + sum_cost_part + WK_DtView1(0)("etmt_cost_fee") + WK_DtView1(0)("etmt_cost_pstg")
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", etmt_cost_tax = " & sum_cost_tax
                                    'strSQL = strSQL & ", etmt_cost_cxl = " & WK_DtView1(0)("etmt_cost_cxl")
                                    strSQL = strSQL & ", etmt_cost_ttl = " & sum_cost_ttl

                                    strSQL = strSQL & ", etmt_shop_tech_chrg = " & WK_tech_chrg
                                    'strSQL = strSQL & ", etmt_shop_apes = " & WK_DtView1(0)("etmt_shop_apes")
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", etmt_shop_part_chrg = " & sum_shop_part
                                    strSQL = strSQL & ", etmt_shop_fee = " & WK_fee
                                    'strSQL = strSQL & ", etmt_shop_pstg = " & WK_DtView1(0)("etmt_shop_pstg")
                                    sum_shop_ttl = WK_tech_chrg + WK_DtView1(0)("etmt_shop_apes") + sum_shop_part + WK_fee + WK_DtView1(0)("etmt_shop_pstg")
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", etmt_shop_tax = " & sum_shop_tax
                                    'strSQL = strSQL & ", etmt_shop_cxl = " & WK_DtView1(0)("etmt_shop_cxl")
                                    strSQL = strSQL & ", etmt_shop_ttl = " & sum_shop_ttl

                                    strSQL = strSQL & ", etmt_eu_tech_chrg = " & WK_tech_chrg
                                    'strSQL = strSQL & ", etmt_eu_apes = " & WK_DtView1(0)("etmt_eu_apes")
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", etmt_eu_part_chrg = " & sum_eu_part
                                    strSQL = strSQL & ", etmt_eu_fee = " & WK_fee
                                    'strSQL = strSQL & ", etmt_eu_pstg = " & WK_DtView1(0)("etmt_eu_pstg")
                                    sum_eu_ttl = WK_tech_chrg + WK_DtView1(0)("etmt_eu_apes") + sum_eu_part + WK_fee + WK_DtView1(0)("etmt_eu_pstg")
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", etmt_eu_tax = " & sum_eu_tax
                                    'strSQL = strSQL & ", etmt_eu_cxl = " & WK_DtView1(0)("etmt_eu_cxl")
                                    strSQL = strSQL & ", etmt_eu_ttl = " & sum_eu_ttl
                                End If

                                strSQL = strSQL & ", fin_ent_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", repr_empl_code = " & CG_rcpt_ent_empl_code
                                strSQL = strSQL & ", repr_brch_code = '" & MidB(CG_repr_brch_code, 1, 2) & "'"
                                strSQL = strSQL & ", comp_meas = '" & MidB(csv(83) & csv(84), 1, 1000) & "'"
                                strSQL = strSQL & ", comp_comn = '" & MidB(csv(223), 1, 200) & "'"

                                If csv(22) <> Nothing Then  '完了データ
                                    If csv(220) = "1" Then  '入金種別コード
                                        WK_tech_chrg = CInt(csv(192))
                                        WK_fee = CInt(csv(208))
                                    Else
                                        WK_tech_chrg = CInt(csv(191))
                                        WK_fee = CInt(csv(207))
                                    End If
                                    'strSQL = strSQL & ", comp_cost_tech_chrg = " & WK_DtView1(0)("comp_cost_tech_chrg")
                                    'strSQL = strSQL & ", comp_cost_apes = " & WK_DtView1(0)("comp_cost_apes")
                                    sum_cost_part = CInt(csv(92)) + CInt(csv(105)) + CInt(csv(118)) + CInt(csv(131))
                                    strSQL = strSQL & ", comp_cost_part_chrg = " & sum_cost_part
                                    'strSQL = strSQL & ", comp_cost_fee = " & WK_DtView1(0)("comp_cost_fee")
                                    'strSQL = strSQL & ", comp_cost_pstg = " & WK_DtView1(0)("comp_cost_pstg")
                                    sum_cost_ttl = WK_DtView1(0)("comp_cost_tech_chrg") + WK_DtView1(0)("comp_cost_apes") + sum_cost_part + WK_DtView1(0)("comp_cost_fee") + WK_DtView1(0)("comp_cost_pstg")
                                    sum_cost_tax = RoundDOWN(sum_cost_ttl * 0.08, 0)
                                    strSQL = strSQL & ", comp_cost_tax = " & sum_cost_tax
                                    'strSQL = strSQL & ", comp_cost_cxl = " & WK_DtView1(0)("comp_cost_cxl")
                                    strSQL = strSQL & ", comp_cost_ttl = " & sum_cost_ttl

                                    strSQL = strSQL & ", comp_shop_tech_chrg = " & WK_tech_chrg
                                    WK_apse = 0
                                    'If apse_f = "11" Then
                                    '    If IsDate(csv(22)) = True Then
                                    '        apse_r = APSE_GET(CG_repr_brch_code, csv(22))
                                    '        If apse_r <> 0 Then
                                    '            WK_apse = WK_tech_chrg * (apse_r - 100) / 100
                                    '        End If
                                    '    End If
                                    'End If
                                    strSQL = strSQL & ", comp_shop_apes = " & WK_apse
                                    sum_shop_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", comp_shop_part_chrg = " & sum_shop_part
                                    strSQL = strSQL & ", comp_shop_fee = " & WK_fee
                                    'strSQL = strSQL & ", comp_shop_pstg = " & WK_DtView1(0)("comp_shop_pstg")
                                    sum_shop_ttl = WK_tech_chrg + WK_apse + sum_shop_part + WK_fee + WK_DtView1(0)("comp_shop_pstg")
                                    sum_shop_tax = RoundDOWN(sum_shop_ttl * 0.08, 0)
                                    strSQL = strSQL & ", comp_shop_tax = " & sum_shop_tax
                                    'strSQL = strSQL & ", comp_shop_cxl = " & WK_DtView1(0)("comp_shop_cxl")
                                    strSQL = strSQL & ", comp_shop_ttl = " & sum_shop_ttl

                                    strSQL = strSQL & ", comp_eu_tech_chrg = " & WK_tech_chrg
                                    'strSQL = strSQL & ", comp_eu_apes = " & WK_DtView1(0)("comp_eu_apes")
                                    sum_eu_part = CInt(csv(89)) + CInt(csv(102)) + CInt(csv(115)) + CInt(csv(128))
                                    strSQL = strSQL & ", comp_eu_part_chrg = " & sum_eu_part
                                    strSQL = strSQL & ", comp_eu_fee = " & WK_fee
                                    'strSQL = strSQL & ", comp_eu_pstg = " & WK_DtView1(0)("comp_eu_pstg")
                                    sum_eu_ttl = WK_tech_chrg + WK_DtView1(0)("comp_eu_apes") + sum_eu_part + WK_fee + WK_DtView1(0)("comp_eu_pstg")
                                    sum_eu_tax = RoundDOWN(sum_eu_ttl * 0.08, 0)
                                    strSQL = strSQL & ", comp_eu_tax = " & sum_eu_tax
                                    'strSQL = strSQL & ", comp_eu_cxl = " & WK_DtView1(0)("comp_eu_cxl")
                                    strSQL = strSQL & ", comp_eu_ttl = " & sum_eu_ttl
                                End If

                                strSQL = strSQL & ", zero_name = '" & MidB(csv(233), 1, 33) & "'"
                                strSQL = strSQL & ", kjo_brch_code = '" & MidB(CG_rcpt_brch_code, 1, 2) & "'"
                                If IsDate(csv(21)) = True Then
                                    strSQL = strSQL & ", accp_date = CONVERT(DATETIME, '" & csv(21) & "', 102)"
                                Else
                                    strSQL = strSQL & ", accp_date = NULL"
                                End If
                                If IsDate(csv(39)) = True Then
                                    strSQL = strSQL & ", etmt_date = CONVERT(DATETIME, '" & csv(39) & "', 102)"
                                Else
                                    strSQL = strSQL & ", etmt_date = NULL"
                                End If
                                If IsDate(csv(22)) = True Then
                                    strSQL = strSQL & ", comp_date = CONVERT(DATETIME, '" & csv(22) & "', 102)"
                                    strSQL = strSQL & ", sals_date = CONVERT(DATETIME, '" & csv(22) & "', 102)"
                                    strSQL = strSQL & ", ship_date = CONVERT(DATETIME, '" & csv(22) & "', 102)"
                                Else
                                    strSQL = strSQL & ", comp_date = NULL"
                                    strSQL = strSQL & ", sals_date = NULL"
                                    strSQL = strSQL & ", ship_date = NULL"
                                End If
                                strSQL = strSQL & ", defe_cls = '" & MidB(CG_defe_cls, 1, 2) & "'"
                                strSQL = strSQL & ", reference_no = '" & MidB(csv(243), 1, 10) & "'"
                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DB_OPEN("nMVAR")
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                                '使用部品
                                If csv(39) <> Nothing Then  '見積データ
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '1')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()

                                            If r2 = 0 Then
                                                strSQL = "INSERT INTO T04_REP_PART"
                                                strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                                strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                                strSQL = strSQL & " VALUES ('" & WK_DtView1(0)("rcpt_no") & "'" '受付番号
                                                strSQL = strSQL & ", '1'"                                       '区分（1:見積 2:完了）
                                                strSQL = strSQL & ", " & j                                      'SEQ
                                                strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"           '部品コード
                                                strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"      '部品名
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     '部品単価
                                                strSQL = strSQL & ", " & CInt(csv(pos + 2))                     '使用数
                                                strSQL = strSQL & ", 0"                                         '在庫使用フラグ
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     'コスト
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'GSS計上
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'EU価
                                                strSQL = strSQL & ", ''"                                        '発注番号
                                                strSQL = strSQL & ", ''"                                        '発受注番
                                                strSQL = strSQL & ", 0"                                         'IBM緊急フラグ
                                                strSQL = strSQL & ", 0)"                                        '消耗品フラグ
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            Else
                                                'upfate
                                                strSQL = "UPDATE T04_REP_PART"
                                                strSQL = strSQL & " SET part_code = '" & MidB(csv(pos), 1, 20) & "'"
                                                strSQL = strSQL & ", part_name = '" & MidB(csv(pos + 1), 1, 100) & "'"
                                                strSQL = strSQL & ", part_amnt = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", use_qty = " & CInt(csv(pos + 2))
                                                strSQL = strSQL & ", cost_chrg = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", shop_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & ", eu_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '1')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        Else

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '1')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()
                                            If r2 <> 0 Then
                                                'delete
                                                strSQL = "DELETE FROM T04_REP_PART"
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '1')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        End If
                                    Next
                                End If
                                If csv(22) <> Nothing Then  '完了データ
                                    For j = 1 To 4
                                        Select Case j
                                            Case Is = 1
                                                pos = 86
                                            Case Is = 2
                                                pos = 99
                                            Case Is = 3
                                                pos = 112
                                            Case Is = 4
                                                pos = 125
                                        End Select
                                        If csv(pos) <> Nothing Then

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '2')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()

                                            If r2 = 0 Then
                                                strSQL = "INSERT INTO T04_REP_PART"
                                                strSQL = strSQL & " (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg"
                                                strSQL = strSQL & ", cost_chrg, shop_chrg, eu_chrg, ordr_no, ordr_no2, ibm_flg,exp_flg)"
                                                strSQL = strSQL & " VALUES ('" & WK_DtView1(0)("rcpt_no") & "'" '受付番号
                                                strSQL = strSQL & ", '2'"                                       '区分（1:見積 2:完了）
                                                strSQL = strSQL & ", " & j                                      'SEQ
                                                strSQL = strSQL & ", '" & MidB(csv(pos), 1, 20) & "'"           '部品コード
                                                strSQL = strSQL & ", '" & MidB(csv(pos + 1), 1, 100) & "'"      '部品名
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     '部品単価
                                                strSQL = strSQL & ", " & CInt(csv(pos + 2))                     '使用数
                                                strSQL = strSQL & ", 0"                                         '在庫使用フラグ
                                                strSQL = strSQL & ", " & CInt(csv(pos + 6))                     'コスト
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'GSS計上
                                                strSQL = strSQL & ", " & CInt(csv(pos + 3))                     'EU価
                                                strSQL = strSQL & ", ''"                                        '発注番号
                                                strSQL = strSQL & ", ''"                                        '発受注番
                                                strSQL = strSQL & ", 0"                                         'IBM緊急フラグ
                                                strSQL = strSQL & ", 0)"                                        '消耗品フラグ
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            Else
                                                'upfate
                                                strSQL = "UPDATE T04_REP_PART"
                                                strSQL = strSQL & " SET part_code = '" & MidB(csv(pos), 1, 20) & "'"
                                                strSQL = strSQL & ", part_name = '" & MidB(csv(pos + 1), 1, 100) & "'"
                                                strSQL = strSQL & ", part_amnt = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", use_qty = " & CInt(csv(pos + 2))
                                                strSQL = strSQL & ", cost_chrg = " & CInt(csv(pos + 6))
                                                strSQL = strSQL & ", shop_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & ", eu_chrg = " & CInt(csv(pos + 3))
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '2')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        Else

                                            WK_DsList2.Clear()
                                            strSQL = "SELECT rcpt_no, kbn, seq"
                                            strSQL = strSQL & " FROM T04_REP_PART"
                                            strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                            strSQL = strSQL & " AND (kbn = '2')"
                                            strSQL = strSQL & " AND (seq = " & j & ")"
                                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                            DaList1.SelectCommand = SqlCmd1
                                            DB_OPEN("nMVAR")
                                            r2 = DaList1.Fill(WK_DsList2, "T04_REP_PART")
                                            DB_CLOSE()
                                            If r2 <> 0 Then
                                                'delete
                                                strSQL = "DELETE FROM T04_REP_PART"
                                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                                strSQL = strSQL & " AND (kbn = '2')"
                                                strSQL = strSQL & " AND (seq = " & j & ")"
                                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                                DB_OPEN("nMVAR")
                                                SqlCmd1.ExecuteNonQuery()
                                                DB_CLOSE()
                                            End If
                                        End If
                                    Next
                                End If

                                '売上
                                DB_OPEN("nMVAR")
                                WK_DsList2.Clear()
                                strSQL = "SELECT rcpt_no, cls"
                                strSQL = strSQL & " FROM T10_SALS"
                                strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                strSQL = strSQL & " AND (cls = '4')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                DaList1.SelectCommand = SqlCmd1
                                r2 = DaList1.Fill(WK_DsList2, "T10_SALS")

                                If IsDate(csv(22)) = True Then
                                    If r2 = 0 Then
                                        strSQL = "INSERT INTO T10_SALS"
                                        strSQL = strSQL & " (rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2"
                                        strSQL = strSQL & ", neva_chek_date, neva_chek_date2, neva_chek_list, invc_cls_date, invc_flg)"
                                        strSQL = strSQL & " VALUES ('" & WK_DtView1(0)("rcpt_no") & "'"
                                        strSQL = strSQL & ", '4'"
                                        strSQL = strSQL & ", " & sum_eu_ttl
                                        strSQL = strSQL & ", " & sum_eu_tax
                                        strSQL = strSQL & ", 0"
                                        strSQL = strSQL & ", 0"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", NULL"
                                        strSQL = strSQL & ", 0)"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()
                                    Else
                                        'upfate
                                        strSQL = "UPDATE T10_SALS"
                                        strSQL = strSQL & " SET sals_amnt = " & sum_eu_ttl
                                        strSQL = strSQL & ", sals_tax = " & sum_eu_tax
                                        strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                        strSQL = strSQL & " AND (cls = '4')"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()
                                    End If
                                Else
                                    If r2 <> 0 Then
                                        'delete
                                        strSQL = "DELETE FROM T10_SALS"
                                        strSQL = strSQL & " WHERE (rcpt_no = '" & WK_DtView1(0)("rcpt_no") & "')"
                                        strSQL = strSQL & " AND (cls = '4')"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()
                                    End If
                                End If

                                'CSV更新
                                strSQL = "INSERT INTO T50_AI_CSV (imp_date, seq, rcpt_no)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & date_now & "', 102)"
                                strSQL = strSQL & ", 1"
                                strSQL = strSQL & ", '" & WK_DtView1(0)("rcpt_no") & "')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()

                                '履歴更新
                                strSQL = "INSERT INTO L01_HSTY"
                                strSQL = strSQL & " (upd_date, upd_empl_code, rcpt_no, chge_item, befr, aftr)"
                                strSQL = strSQL & " VALUES (CONVERT(DATETIME, '" & Now & "', 102)"
                                strSQL = strSQL & ", " & P_EMPL_NO
                                strSQL = strSQL & ", '" & WK_DtView1(0)("rcpt_no") & "'"
                                strSQL = strSQL & ", 'Ai取込み修正'"
                                strSQL = strSQL & ", ''"
                                strSQL = strSQL & ", '')"
                                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                SqlCmd1.ExecuteNonQuery()
                                DB_CLOSE()

                            End If
                        End If
                        cnt = cnt + 1
                    Next row
                End If
                waitDlg.Close()         '進行状況ダイアログを閉じる
                Me.Enabled = True       'オーナーのフォームを無効にする

                Call CSV_output()   'CSV出力

                MessageBox.Show("取込完了", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        End With
    End Sub

    Sub CSV_output()    'CSV出力

        WK_DsList3.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_Ai_CSV", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = Format(date_now, "yyyy/MM/dd HH:mm:ss")
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(WK_DsList3, "WK_Print01")
        DB_CLOSE()

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "Ai取込み明細" & Format(Now, "yyyyMMddHHmmss") & ".CSV" 'はじめのファイル名を指定する
        sfd.Filter = "CSVファイル(*.CSV)|*.CSV"                 '[ファイルの種類]に表示される選択肢を指定する
        sfd.FilterIndex = 2                                     '[ファイルの種類]ではじめに 「すべてのファイル」が選択されているようにする
        sfd.Title = "保存先のファイルを選択してください"        'タイトルを設定する
        sfd.RestoreDirectory = True                             'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする

        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True

        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then     'ダイアログを表示する
            strFile = sfd.FileName   'OKボタンがクリックされたとき

            ' 進行状況ダイアログの初期化処理
            waitDlg = New WaitDialog        ' 進行状況ダイアログ
            waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = Nothing       ' 処理の概要を表示
            waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0       ' 最初の件数を設定
            Me.Enabled = False              ' オーナーのフォームを無効にする
            waitDlg.Show()                  ' 進行状況ダイアログを表示する

            waitDlg.MainMsg = "CSV出力中"   ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = r         ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0       ' 最初の件数を設定
            Application.DoEvents()          ' メッセージ処理を促して表示を更新する

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "伝票番号,計上QG,受付種別,入荷区分コード,入荷区分名,グループコード,グループ名,取次店コード,取次店名"
            strData = strData & ",販社伝番,請求先コード,請求先名,お客様名,受付年月日,修理完了日,売上日,入金日付,見積日付"
            strData = strData & ",回答受信日,部品発注日,部品受領日"
            strData = strData & ",見積書金額,社員コード,修理担当者名,メーカーコード,メーカー名,モデル,機種,製造番号,保証情報,保証情報名"
            strData = strData & ",部品番号1,部品名1,数量1,コスト1,計上額1,EU額1"
            strData = strData & ",部品番号2,部品名2,数量2,コスト2,計上額2,EU額2"
            strData = strData & ",部品番号3,部品名3,数量3,コスト3,計上額3,EU額3"
            strData = strData & ",部品番号4,部品名4,数量4,コスト4,計上額4,EU額4"
            strData = strData & ",部品番号5,部品名5,数量5,コスト5,計上額5,EU額5"
            strData = strData & ",部品番号6,部品名6,数量6,コスト6,計上額6,EU額6"
            strData = strData & ",部品番号7,部品名7,数量7,コスト7,計上額7,EU額7"
            strData = strData & ",部品番号8,部品名8,数量8,コスト8,計上額8,EU額8"
            strData = strData & ",部品代,APSE,技術料,その他,送料,小計,消費税,合計,販社リベート,自己負担金,QG-Care保証範囲"
            strData = strData & ",修理会社,受付ＱＧ,\0理由,ネバ伝番号,ネバ伝番号（リベート）,赤伝元受付番号,オリジナルメーカーコード"
            strData = strData & ",申告症状,修理内容,QG-Care番号,Note,完了コメント,Mobile種別,レジ番号,登録QG,iMVAR管理番号,受付コメント"
            swFile.WriteLine(strData)

            DtView1 = New DataView(WK_DsList3.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = DtView1(i)("rcpt_no")                         '伝票番号
                strData = strData & "," & DtView1(i)("kjo_brch_name")   '計上QG
                strData = strData & "," & DtView1(i)("rcpt_name")       '受付種別
                strData = strData & "," & DtView1(i)("arvl_cls")        '入荷区分コード
                strData = strData & "," & DtView1(i)("arvl_name")       '入荷区分名
                strData = strData & "," & DtView1(i)("grup_code")       'グループコード
                strData = strData & "," & DtView1(i)("grup_name")       'グループ名
                strData = strData & "," & DtView1(i)("store_code")      '取次店コード
                strData = strData & "," & DtView1(i)("store_name")      '取次店名
                strData = strData & "," & DtView1(i)("store_repr_no")   '販社伝番
                strData = strData & "," & DtView1(i)("invc_code")       '請求先コード
                strData = strData & "," & DtView1(i)("invc_name")       '請求先名
                strData = strData & "," & DtView1(i)("user_name")       'お客様名
                strData = strData & "," & DtView1(i)("accp_date")       '受付年月日
                strData = strData & "," & DtView1(i)("comp_date")       '修理完了日
                strData = strData & "," & DtView1(i)("sals_date")       '売上日
                strData = strData & "," & DtView1(i)("clct_date")       '入金日付
                strData = strData & "," & DtView1(i)("etmt_date")       '見積日付
                strData = strData & "," & DtView1(i)("rsrv_cacl_date")  '回答受信日
                strData = strData & "," & DtView1(i)("part_ordr_date")  '部品発注日
                strData = strData & "," & DtView1(i)("part_rcpt_date")  '部品受領日
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                strData = strData & "," & WK_AMT                        '見積書金額
                strData = strData & "," & DtView1(i)("repr_empl_code")  '社員コード
                strData = strData & "," & DtView1(i)("repr_empl_name")  '修理担当者名
                strData = strData & "," & DtView1(i)("vndr_code")       'メーカーコード
                strData = strData & "," & DtView1(i)("vndr_name")       'メーカー名
                WK_str = New_Line_Cng(comma_Cng(DtView1(i)("model_1")))
                'WK_str = Replace(DtView1(i)("model_1"), ",", " ")
                strData = strData & "," & WK_str                        'モデル
                WK_str = New_Line_Cng(comma_Cng(DtView1(i)("model_2")))
                strData = strData & "," & WK_str                        '機種
                WK_str = New_Line_Cng(comma_Cng(DtView1(i)("s_n")))
                strData = strData & "," & WK_str                        '製造番号
                strData = strData & "," & DtView1(i)("rpar_cls")        '保証情報
                strData = strData & "," & DtView1(i)("rpar_name")       '保証情報名

                '部品情報
                WK_AMT2 = 0 : WK_AMT3 = 0 : WK_AMT4 = 0 : WK_AMT5 = 0
                WK_DsList1.Clear()
                SqlCmd1 = New SqlClient.SqlCommand("sp_F40_05_2", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                Pram2.Value = DtView1(i)("rcpt_no")
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "T04_REP_PART")
                DB_CLOSE()
                WK_DtView1 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    For j = 0 To WK_DtView1.Count - 1
                        Select Case j
                            Case Is < 7
                                WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_code")))
                                strData = strData & "," & WK_str                                    '部品番号
                                WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_name")))
                                strData = strData & "," & WK_str                                    '部品名
                                strData = strData & "," & WK_DtView1(j)("use_qty")                  '数量
                                strData = strData & "," & WK_DtView1(j)("cost_chrg")                'コスト
                                strData = strData & "," & WK_DtView1(j)("shop_chrg")                '計上額
                                strData = strData & "," & WK_DtView1(j)("eu_chrg")                  'EU額

                            Case Is = 7
                                If WK_DtView1.Count = 8 Then
                                    WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_code")))
                                    strData = strData & "," & WK_str                                '部品番号
                                    WK_str = New_Line_Cng(comma_Cng(WK_DtView1(j)("part_name")))
                                    strData = strData & "," & WK_str                                '部品名
                                    strData = strData & "," & WK_DtView1(j)("use_qty")              '数量
                                    strData = strData & "," & WK_DtView1(j)("cost_chrg")            'コスト
                                    strData = strData & "," & WK_DtView1(j)("shop_chrg")            '計上額
                                    strData = strData & "," & WK_DtView1(j)("eu_chrg")              'EU額
                                Else
                                    WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                    WK_AMT3 = WK_AMT3 + WK_DtView1(j)("part_amnt") * WK_DtView1(j)("use_qty")
                                    WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                    WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")
                                End If

                            Case Else
                                WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                WK_AMT3 = WK_AMT3 + WK_DtView1(j)("cost_chrg")
                                WK_AMT4 = WK_AMT4 + WK_DtView1(j)("shop_chrg")
                                WK_AMT5 = WK_AMT5 + WK_DtView1(j)("eu_chrg")

                        End Select
                    Next
                End If

                Select Case WK_DtView1.Count
                    Case Is < 8
                        For j = 1 To 8 - WK_DtView1.Count
                            strData = strData & ",,,,,,"
                        Next
                    Case Is = 8
                    Case Else
                        strData = strData & ","             '部品番号
                        strData = strData & ",その他部品"   '部品名
                        strData = strData & "," & WK_AMT2   '数量
                        strData = strData & "," & WK_AMT3   'コスト
                        strData = strData & "," & WK_AMT4   '計上額
                        strData = strData & "," & WK_AMT5   'EU額
                End Select

                strData = strData & "," & DtView1(i)("comp_shop_part_chrg")     '部品代
                strData = strData & "," & DtView1(i)("comp_shop_apes")          'APSE
                strData = strData & "," & DtView1(i)("comp_shop_tech_chrg")     '技術料
                strData = strData & "," & DtView1(i)("comp_shop_fee")           'その他
                strData = strData & "," & DtView1(i)("comp_shop_pstg")          '送料
                WK_AMT = 0
                If Not IsDBNull(DtView1(i)("comp_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("comp_shop_ttl")
                strData = strData & "," & WK_AMT                                '小計
                If Not IsDBNull(DtView1(i)("comp_shop_tax")) Then
                    strData = strData & "," & DtView1(i)("comp_shop_tax")           '消費税
                    strData = strData & "," & WK_AMT + DtView1(i)("comp_shop_tax")  '合計
                Else
                    strData = strData & ",0"                                        '消費税
                    strData = strData & "," & WK_AMT                                '合計
                End If
                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData = strData & "," & DtView1(i)("rebate")                  '販社リベート
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData = strData & ",0"
                    Else
                        strData = strData & "," & DtView1(i)("rebate")
                    End If
                End If

                If IsDBNull(DtView1(i)("aka_flg")) Then
                    strData = strData & "," & DtView1(i)("sals_amnt")                   '自己負担金
                Else
                    If DtView1(i)("aka_flg") = "True" Then
                        strData = strData & ",0"
                    Else
                        strData = strData & "," & DtView1(i)("sals_amnt")
                    End If
                End If

                WK_str = Nothing
                If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                    WK_DsList1.Clear()
                    strSQL = "SELECT HSY.HSY_name"
                    strSQL = strSQL & " FROM T01_加入者 LEFT OUTER JOIN"
                    strSQL = strSQL & " (SELECT [コード] AS HSY_code, 名称 AS HSY_name FROM [M_テーブル] WHERE (識別 = N'HSY')) HSY ON"
                    strSQL = strSQL & " T01_加入者.保証範囲 = HSY.HSY_code"
                    strSQL = strSQL & " WHERE (T01_加入者.加入番号 = N'" & DtView1(i)("qg_care_no") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("QGCare")
                    DaList1.Fill(WK_DsList1, "T01_加入者")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T01_加入者"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str = Trim(WK_DtView1(0)("HSY_name"))
                    End If
                End If
                strData = strData & "," & WK_str                                    'QG-Care保証範囲
                strData = strData & "," & DtView1(i)("rpar_comp_name")              '修理会社
                strData = strData & "," & DtView1(i)("rcpt_brch_name")              '受付ＱＧ
                If Not IsDBNull(DtView1(i)("zero_name")) Then
                    WK_str = DtView1(i)("zero_name") : WK_str = Replace(WK_str, ",", "，")
                    strData = strData & "," & WK_str                                '\0理由
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("sals_no")                     'ネバ伝番号
                strData = strData & "," & DtView1(i)("sals_no2")                    'ネバ伝番号（リベート）
                strData = strData & "," & DtView1(i)("rcpt_no_aka")                 '赤伝受付番号
                strData = strData & "," & DtView1(i)("orgnl_vndr_code")             'オリジナルメーカーコード
                If Not IsDBNull(DtView1(i)("user_trbl")) Then
                    WK_str = New_Line_Cng(DtView1(i)("user_trbl")) : WK_str = Replace(WK_str, ",", "，")
                    strData = strData & "," & WK_str                                '申告症状
                Else
                    strData = strData & ","
                End If
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_meas")) : WK_str = Replace(WK_str, ",", "，")
                    strData = strData & "," & WK_str                                '修理内容
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("qg_care_no")                  'QG-Care番号
                If IsDBNull(DtView1(i)("note_kbn2")) Then
                    strData = strData & ","                                         'Note
                Else
                    If DtView1(i)("note_kbn2") = "01" Then
                        strData = strData & ",1"
                    Else
                        strData = strData & ","
                    End If
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_comn")) : WK_str = Replace(WK_str, ",", "，")
                    strData = strData & "," & WK_str                                    '完了コメント
                Else
                    strData = strData & ","
                End If
                strData = strData & "," & DtView1(i)("defe_name")                       'Mobile種別（CLS：035）
                strData = strData & "," & DtView1(i)("reference_no")                    'レジ番号
                If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then
                    strData = strData & "," & Mid(DtView1(i)("imv_rcpt_no"), 1, 2)      '登録QG
                    strData = strData & "," & Mid(DtView1(i)("imv_rcpt_no"), 3, 7)      'iMVAR管理番号
                Else
                    strData = strData & ",,"
                End If
                WK_str = New_Line_Cng(DtView1(i)("rcpt_comn")) : WK_str = Replace(WK_str, ",", "，")
                strData = strData & "," & WK_str                                        '受付コメント

                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)
            Next
            swFile.Close()          'ファイルを閉じる
            waitDlg.Close()         '進行状況ダイアログを閉じる
            Me.Enabled = True       'オーナーのフォームを無効にする
        End If

    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        Application.Exit()
    End Sub
End Class
