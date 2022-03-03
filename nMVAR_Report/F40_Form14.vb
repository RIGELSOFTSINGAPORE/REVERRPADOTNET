Public Class F40_Form14
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData As String
    Dim i, j, r, seq As Integer
    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer
    Dim WK_str, WK_str2, Br_rcpt_no As String

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form14))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Date2 = New GrapeCity.Win.Input.Interop.Date
        Me.Label35 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(228, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 1872
        Me.Label2.Text = "～"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(124, 28)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(104, 24)
        Me.Date1.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.TabIndex = 1865
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.Value = Nothing
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date2.Location = New System.Drawing.Point(252, 28)
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(104, 24)
        Me.Date2.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, True, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, False, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.TabIndex = 1866
        Me.Date2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date2.Value = Nothing
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(28, 28)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 24)
        Me.Label35.TabIndex = 1871
        Me.Label35.Text = "範囲指定"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(288, 88)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1869
        Me.Button98.Text = "戻る"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(28, 68)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(328, 16)
        Me.msg.TabIndex = 1870
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1868
        Me.Button1.Text = "CSV"
        '
        'F40_Form14
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(376, 123)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form14"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OBIA用CSV作成"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form06_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date1.Text = Format(Now.Date, "yyyy/MM/") & "01"
        Date2.Text = Format(Now.Date, "yyyy/MM/dd")
        msg.Text = Nothing
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        '範囲指定(FROM)
        If Date1.Number = 0 Then
            msg.Text = "範囲指定を入力してください。"
            Err_F = "1" : Date1.Focus() : Exit Sub
        End If

        '範囲指定(TO)
        If Date2.Number = 0 Then
            msg.Text = "範囲指定を入力してください。"
            Err_F = "1" : Date2.Focus() : Exit Sub
        End If

        'FROM > TO
        If Date1.Number > Date2.Number Then
            msg.Text = "範囲指定が間違っています。"
            Err_F = "1" : Date2.Focus() : Exit Sub
        End If

        'DataTable作成()
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_14", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = Date1.Text
        Pram2.Value = DateAdd(DateInterval.Day, 1, CDate(Date2.Text))
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN(ini)
        r = DaList1.Fill(DsList1, "WK_Print01")
        DB_CLOSE()

        If r = 0 Then
            msg.Text = "対象データがありません。"
            Err_F = "1" : Date1.Focus() : Exit Sub
        End If
    End Sub

    '********************************************************************
    '**  CSV
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "OBIC用data" & Format(CDate(Date1.Text), "yyyyMMdd") & "_" & Format(CDate(Date2.Text), "yyyyMMdd") & ".CSV" 'はじめのファイル名を指定する
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
                strData = "伝票番号,行番号,計上QGコード,計上QG,受付種別コード,受付種別,入荷区分コード,入荷区分名,グループコード,グループ名,取次店コード"
                ' strData += ",取次店名,販社伝番,請求先コード,請求先名,お客様名,事故日,修理完了日,売上日,入金日付,見積日付,回答受信日,部品発注日"
                strData += ",取次店名,販社伝番,請求先コード,請求先名,お客様名,受付年月日,修理完了日,売上日,入金日付,見積日付,回答受信日,部品発注日" 'CR against changes 07/04/2021
                strData += ",部品受領日,見積書金額,社員コード,修理担当者名,メーカーコード,メーカー名,モデル,機種,製造番号,保証情報,保証情報名,部品番号"
                strData += ",部品名,部品数量,部品コスト,部品計上額,部品EU額,部品代,APSE,技術料,その他,送料,小計,消費税,合計,預り金,販社リベート"
                strData += ",自己負担金,QG-Care保証範囲コード,QG-Care保証範囲,修理会社,受付ＱＧ,ゼロ円理由,ネバ伝番号,ネバ伝番号（リベート）,赤伝元受付番号"
                strData += ",オリジナルメーカーコード,申告症状,修理内容,QG-Care番号,Note,完了コメント,Mobile種別,レジ番号,登録QG,iMVAR管理番号"
                strData += ",受付コメント,SB/IMEI番号,SB/新IMEI番号,入金種別コード,入金種別"
                swFile.WriteLine(strData)

                DtView1 = New DataView(DsList1.Tables("WK_Print01"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

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
                    strData += "," & Chr(34) & DtView1(i)("acdt_date") & Chr(34)                    '事故日
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
                MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                waitDlg.Close()         '進行状況ダイアログを閉じる
                Me.Enabled = True       'オーナーのフォームを無効にする
            End If
        End If
        DsList1.Clear()
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub
End Class
