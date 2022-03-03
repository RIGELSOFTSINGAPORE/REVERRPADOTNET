Public Class F40_Form12
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData As String
    Dim i, j, r As Integer
    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer
    Dim WK_str As String

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Date001 As GrapeCity.Win.Input.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form12))
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Date001 = New GrapeCity.Win.Input.Date
        Me.Label007 = New System.Windows.Forms.Label
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(116, 68)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1762
        Me.Button98.Text = "戻る"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 44)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(192, 16)
        Me.msg.TabIndex = 1764
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(28, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1761
        Me.Button1.Text = "CSV"
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyy/MM", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.DateFormat("yyy/MM", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(108, 16)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(72, 20)
        Me.Date001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.TabIndex = 1760
        Me.Date001.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(28, 16)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(80, 20)
        Me.Label007.TabIndex = 1763
        Me.Label007.Text = "対象年月"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F40_Form12
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(218, 100)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "赤伝処理明細CSV作成"
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Date001.Text = Format(Now.Date, "yyyy/MM")
        msg.Text = Nothing
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        '対象年月
        If Date001.Number = 0 Then
            msg.Text = "対象年月を入力してください。"
            Err_F = "1" : Date001.Focus() : Exit Sub
        End If

        'DataTable作成()
        DB_OPEN(ini)
        P_DsPRT.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_12", cnsqlclient)        '赤伝分
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = Date001.Text & "/01"
        Pram2.Value = DateAdd(DateInterval.Month, 1, CDate(Date001.Text & "/01"))
        DaList1.SelectCommand = SqlCmd1
        r = DaList1.Fill(P_DsPRT, "WK_Print01")

        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_12_2", cnsqlclient)      '赤伝の元
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram3.Value = Date001.Text & "/01"
        Pram4.Value = DateAdd(DateInterval.Month, 1, CDate(Date001.Text & "/01"))
        DaList1.SelectCommand = SqlCmd1
        r = r + DaList1.Fill(P_DsPRT, "WK_Print01")
        DB_CLOSE()

        If r = 0 Then
            msg.Text = "対象データがありません。"
            Err_F = "1" : Date001.Focus() : Exit Sub
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
            sfd.FileName = "赤伝明細" & Mid(Date001.Text, 1, 4) & Mid(Date001.Text, 6, 2) & ".CSV" 'はじめのファイル名を指定する
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
                strData += ",販社伝番,請求先コード,請求先名,お客様名,受付年月日,修理完了日,入金日付,見積日付"
                strData += ",回答受信日,部品発注日,部品受領日"
                strData += ",見積書金額,社員コード,修理担当者名,メーカーコード,メーカー名,モデル,機種,製造番号,保証情報,保証情報名"
                strData += ",部品番号1,部品名1,数量1,コスト1,計上額1,EU額1"
                strData += ",部品番号2,部品名2,数量2,コスト2,計上額2,EU額2"
                strData += ",部品番号3,部品名3,数量3,コスト3,計上額3,EU額3"
                strData += ",部品番号4,部品名4,数量4,コスト4,計上額4,EU額4"
                strData += ",部品番号5,部品名5,数量5,コスト5,計上額5,EU額5"
                strData += ",部品番号6,部品名6,数量6,コスト6,計上額6,EU額6"
                strData += ",部品番号7,部品名7,数量7,コスト7,計上額7,EU額7"
                strData += ",部品番号8,部品名8,数量8,コスト8,計上額8,EU額8"
                strData += ",部品代,APSE,技術料,その他,送料,小計,消費税,合計,販社リベート,自己負担金,QG-Care保証範囲"
                strData += ",修理会社,受付ＱＧ,\0理由,ネバ伝番号,ネバ伝番号（リベート）,赤伝元受付番号,オリジナルメーカーコード"
                strData += ",申告症状,修理内容,QG-Care番号,SB/IMEI番号,SB/新IMEI番号"
                swFile.WriteLine(strData)

                DtView1 = New DataView(P_DsPRT.Tables("WK_Print01"), "", "sort, comp_shop_ttl DESC", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    strData = Chr(34) & DtView1(i)("rcpt_no") & Chr(34)                     '伝票番号
                    strData += "," & Chr(34) & DtView1(i)("kjo_brch_name") & Chr(34)        '計上QG
                    strData += "," & Chr(34) & DtView1(i)("rcpt_name") & Chr(34)            '受付種別
                    strData += "," & Chr(34) & DtView1(i)("arvl_cls") & Chr(34)             '入荷区分コード
                    strData += "," & Chr(34) & DtView1(i)("arvl_name") & Chr(34)            '入荷区分名
                    strData += "," & Chr(34) & DtView1(i)("grup_code") & Chr(34)            'グループコード
                    strData += "," & Chr(34) & DtView1(i)("grup_name") & Chr(34)            'グループ名
                    strData += "," & Chr(34) & DtView1(i)("store_code") & Chr(34)           '取次店コード
                    strData += "," & Chr(34) & DtView1(i)("store_name") & Chr(34)           '取次店名
                    strData += "," & Chr(34) & DtView1(i)("store_repr_no") & Chr(34)        '販社伝番
                    strData += "," & Chr(34) & DtView1(i)("invc_code") & Chr(34)            '請求先コード
                    strData += "," & Chr(34) & DtView1(i)("invc_name") & Chr(34)            '請求先名
                    strData += "," & Chr(34) & DQM_Cng(DtView1(i)("user_name")) & Chr(34)   'お客様名
                    strData += "," & Chr(34) & DtView1(i)("accp_date") & Chr(34)            '受付年月日
                    strData += "," & Chr(34) & DtView1(i)("comp_date") & Chr(34)            '修理完了日
                    strData += "," & Chr(34) & DtView1(i)("clct_date") & Chr(34)            '入金日付
                    strData += "," & Chr(34) & DtView1(i)("etmt_date") & Chr(34)            '見積日付
                    strData += "," & Chr(34) & DtView1(i)("rsrv_cacl_date") & Chr(34)       '回答受信日
                    strData += "," & Chr(34) & DtView1(i)("part_ordr_date") & Chr(34)       '部品発注日
                    strData += "," & Chr(34) & DtView1(i)("part_rcpt_date") & Chr(34)       '部品受領日
                    WK_AMT = 0
                    If Not IsDBNull(DtView1(i)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_ttl")
                    If Not IsDBNull(DtView1(i)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(i)("etmt_shop_tax")
                    strData += "," & Chr(34) & WK_AMT & Chr(34)                             '見積書金額
                    strData += "," & Chr(34) & DtView1(i)("repr_empl_code") & Chr(34)       '社員コード
                    strData += "," & Chr(34) & DtView1(i)("repr_empl_name") & Chr(34)       '修理担当者名
                    strData += "," & Chr(34) & DtView1(i)("vndr_code") & Chr(34)            'メーカーコード
                    strData += "," & Chr(34) & DtView1(i)("vndr_name") & Chr(34)            'メーカー名
                    WK_str = New_Line_Cng(DtView1(i)("model_1"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                    'モデル
                    WK_str = New_Line_Cng(DtView1(i)("model_2"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                    '機種
                    WK_str = New_Line_Cng(DtView1(i)("s_n"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                    '製造番号
                    strData += "," & Chr(34) & DtView1(i)("rpar_cls") & Chr(34)             '保証情報
                    strData += "," & Chr(34) & DtView1(i)("rpar_name") & Chr(34)            '保証情報名

                    '部品情報
                    WK_DsList1.Clear()
                    SqlCmd1 = New SqlClient.SqlCommand("sp_F40_05_2", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                    Pram1.Value = DtView1(i)("rcpt_no")
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN(ini)
                    DaList1.Fill(WK_DsList1, "T04_REP_PART")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        For j = 0 To WK_DtView1.Count - 1
                            Select Case j
                                Case Is < 7
                                    WK_str = New_Line_Cng(WK_DtView1(j)("part_code"))
                                    strData += "," & Chr(34) & WK_str & Chr(34)                         '部品番号
                                    WK_str = New_Line_Cng(WK_DtView1(j)("part_name"))
                                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                '部品名
                                    strData += "," & Chr(34) & WK_DtView1(j)("use_qty") & Chr(34)       '数量
                                    strData += "," & Chr(34) & WK_DtView1(j)("cost_chrg") & Chr(34)     'コスト
                                    strData += "," & Chr(34) & WK_DtView1(j)("shop_chrg") & Chr(34)     '計上額
                                    strData += "," & Chr(34) & WK_DtView1(j)("eu_chrg") & Chr(34)       'EU額

                                Case Is = 7
                                    If WK_DtView1.Count = 8 Then
                                        WK_str = New_Line_Cng(WK_DtView1(j)("part_code"))
                                        strData += "," & Chr(34) & WK_str & Chr(34)                     '部品番号
                                        WK_str = New_Line_Cng(WK_DtView1(j)("part_name"))
                                        strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)            '部品名
                                        strData += "," & Chr(34) & WK_DtView1(j)("use_qty") & Chr(34)   '数量
                                        strData += "," & Chr(34) & WK_DtView1(j)("cost_chrg") & Chr(34) 'コスト
                                        strData += "," & Chr(34) & WK_DtView1(j)("shop_chrg") & Chr(34) '計上額
                                        strData += "," & Chr(34) & WK_DtView1(j)("eu_chrg") & Chr(34)   'EU額
                                    Else
                                        WK_AMT2 = WK_AMT2 + WK_DtView1(j)("use_qty")
                                        WK_AMT3 = WK_AMT3 + WK_DtView1(j)("cost_chrg")
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
                                strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                            Next
                        Case Is = 8
                        Case Else
                            strData += "," & Chr(34) & Chr(34)                  '部品番号
                            strData += "," & Chr(34) & "その他部品" & Chr(34)   '部品名
                            strData += "," & Chr(34) & WK_AMT2 & Chr(34)        '数量
                            strData += "," & Chr(34) & WK_AMT3 & Chr(34)        'コスト
                            strData += "," & Chr(34) & WK_AMT4 & Chr(34)        '計上額
                            strData += "," & Chr(34) & WK_AMT5 & Chr(34)        'EU額
                    End Select

                    strData += "," & Chr(34) & DtView1(i)("comp_shop_part_chrg") & Chr(34)     '部品代
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_apes") & Chr(34)          'APSE
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_tech_chrg") & Chr(34)     '技術料
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_fee") & Chr(34)           'その他
                    strData += "," & Chr(34) & DtView1(i)("comp_shop_pstg") & Chr(34)          '送料
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

                    WK_str = Nothing
                    If Trim(DtView1(i)("qg_care_no")) <> Nothing Then
                        WK_DsList1.Clear()
                        strSQL = "SELECT V_M02_HSY.cls_code_name AS HSY_name"
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
                            If Not IsDBNull(WK_DtView1(0)("HSY_name")) Then WK_str = Trim(WK_DtView1(0)("HSY_name"))
                        End If
                    End If
                    strData += "," & Chr(34) & WK_str & Chr(34)                                     'QG-Care保証範囲
                    strData += "," & Chr(34) & DtView1(i)("rpar_comp_name") & Chr(34)               '修理会社
                    strData += "," & Chr(34) & DtView1(i)("rcpt_brch_name") & Chr(34)               '受付ＱＧ
                    If Not IsDBNull(DtView1(i)("zero_name")) Then
                        WK_str = DtView1(i)("zero_name")
                        strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                        '\0理由
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
                    strData += "," & Chr(34) & DtView1(i)("qg_care_no") & Chr(34)                   'QG-Care番号
                    strData += "," & Chr(34) & DtView1(i)("sb_imei_old") & Chr(34)                  'SB/IMEI番号
                    strData += "," & Chr(34) & DtView1(i)("sb_imei_new") & Chr(34)                  'SB/新IMEI番号
                    'strData += ",END"

                    strData = Replace(strData, System.Environment.NewLine, "")
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
        Close()
    End Sub
End Class
