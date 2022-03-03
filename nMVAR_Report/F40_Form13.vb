Public Class F40_Form13
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, strFile, strData, RE_F As String
    Dim i, j, r As Integer
    Dim WK_AMT, WK_AMT2, WK_AMT3, WK_AMT4, WK_AMT5 As Integer
    Dim WK_str As String
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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Interop.Combo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form13))
        Me.Button98 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Interop.Combo
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(108, 68)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1776
        Me.Button98.Text = "戻る"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 44)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(192, 16)
        Me.msg.TabIndex = 1777
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(20, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 1775
        Me.Button1.Text = "CSV"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Navy
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(8, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 24)
        Me.Label35.TabIndex = 1774
        Me.Label35.Text = "抽出日"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 1778
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Combo001
        '
        Me.Combo001.Location = New System.Drawing.Point(104, 8)
        Me.Combo001.MaxDropDownItems = 12
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(92, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Interop.Spin(0, 1, True, False, GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1780
        Me.Combo001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'F40_Form13
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(214, 104)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label35)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form13"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "仕掛CSV作成（月末処理）"
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '**  コンボボックスセット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        '今日が月末？
        If Format(DateAdd(DateInterval.Day, 1, Now.Date), "dd") = "01" Then
            Label1.Text = Now.Date
        Else
            Label1.Text = DateAdd(DateInterval.Day, -1, CDate(Format(Now.Date, "yyyy/MM/") & "01"))
        End If

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN(ini)

        '抽出日
        strSQL = "SELECT '' AS date, output_date FROM L05_CSV GROUP BY output_date ORDER BY output_date DESC"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "L05_CSV")
        DtView1 = New DataView(DsCMB.Tables("L05_CSV"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                DtView1(i)("date") = Format(DtView1(i)("output_date"), "yyyy/MM")
            Next
        End If

        Combo001.DataSource = DsCMB.Tables("L05_CSV")
        Combo001.DisplayMember = "date"
        Combo001.ValueMember = "date"

        DB_CLOSE()
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        '抽出日
        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text = Nothing Then
            msg.Text = "抽出年月を選択してください。"
            Err_F = "1" : Combo001.Focus() : Exit Sub
        End If

        WK_DtView1 = New DataView(DsCMB.Tables("L05_CSV"), "date = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            msg.Text = "抽出年月の対象データがありません。"
            Err_F = "1" : Combo001.Focus() : Exit Sub
        Else
            Label1.Text = WK_DtView1(0)("output_date")
        End If

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_F40_07_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram2.Value = Label1.Text
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN(ini)
        DaList1.Fill(DsList1, "WK_Print02")
        DB_CLOSE()

    End Sub

    '********************************************************************
    '**  CSV
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_Check()
        If Err_F = "0" Then
            re_csv()
        End If
        DsList1.Clear()
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub re_csv()

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "仕掛" & Format(CDate(Label1.Text), "yyyyMMdd") & ".CSV"  'はじめのファイル名を指定する
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
            strData += ",販社伝番,請求先コード,請求先名,お客様名,受付年月日,修理完了日,売上日,入金日付,見積日付"
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
            strData += ",申告症状,修理内容,QG-Care番号,Note,完了コメント"
            strData += ",Mobile種別,レジ番号,登録QG,iMVAR管理番号,SB/IMEI番号,SB/新IMEI番号"
            swFile.WriteLine(strData)

            DtView1 = New DataView(DsList1.Tables("WK_Print02"), "", "rcpt_no", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = Chr(34) & DtView1(i)("rcpt_no") & Chr(34)                         '伝票番号
                strData += "," & Chr(34) & DtView1(i)("kjo_brch_name") & Chr(34)   '計上QG
                strData += "," & Chr(34) & DtView1(i)("rcpt_name") & Chr(34)       '受付種別
                strData += "," & Chr(34) & DtView1(i)("arvl_cls") & Chr(34)        '入荷区分コード
                strData += "," & Chr(34) & DtView1(i)("arvl_name") & Chr(34)       '入荷区分名
                strData += "," & Chr(34) & DtView1(i)("grup_code") & Chr(34)       'グループコード
                strData += "," & Chr(34) & DtView1(i)("grup_name") & Chr(34)       'グループ名
                strData += "," & Chr(34) & DtView1(i)("store_code") & Chr(34)      '取次店コード
                strData += "," & Chr(34) & DtView1(i)("store_name") & Chr(34)      '取次店名
                strData += "," & Chr(34) & DtView1(i)("store_repr_no") & Chr(34)   '販社伝番
                strData += "," & Chr(34) & DtView1(i)("invc_code") & Chr(34)       '請求先コード
                strData += "," & Chr(34) & DtView1(i)("invc_name") & Chr(34)       '請求先名
                strData += "," & Chr(34) & DQM_Cng(DtView1(i)("user_name")) & Chr(34)       'お客様名
                strData += "," & Chr(34) & DtView1(i)("accp_date") & Chr(34)       '受付年月日
                strData += "," & Chr(34) & DtView1(i)("comp_date") & Chr(34)       '修理完了日
                strData += "," & Chr(34) & DtView1(i)("sals_date") & Chr(34)       '売上日
                strData += "," & Chr(34) & DtView1(i)("clct_date") & Chr(34)       '入金日付
                strData += "," & Chr(34) & DtView1(i)("etmt_date") & Chr(34)       '見積日付
                strData += "," & Chr(34) & DtView1(i)("rsrv_cacl_date") & Chr(34)  '回答受信日
                strData += "," & Chr(34) & DtView1(i)("part_ordr_date") & Chr(34)  '部品発注日
                strData += "," & Chr(34) & DtView1(i)("part_rcpt_date") & Chr(34)  '部品受領日
                strData += "," & Chr(34) & DtView1(i)("etmt_shop_Gttl") & Chr(34)  '見積書金額
                strData += "," & Chr(34) & DtView1(i)("repr_empl_code") & Chr(34)  '社員コード
                strData += "," & Chr(34) & DtView1(i)("repr_empl_name") & Chr(34)  '修理担当者名
                strData += "," & Chr(34) & DtView1(i)("vndr_code") & Chr(34)       'メーカーコード
                strData += "," & Chr(34) & DtView1(i)("vndr_name") & Chr(34)       'メーカー名
                WK_str = New_Line_Cng(DtView1(i)("model_1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)         'モデル
                WK_str = New_Line_Cng(DtView1(i)("model_2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)         '機種
                WK_str = New_Line_Cng(DtView1(i)("s_n"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)             '製造番号
                strData += "," & Chr(34) & DtView1(i)("rpar_cls") & Chr(34)        '保証情報
                strData += "," & Chr(34) & DtView1(i)("rpar_name") & Chr(34)       '保証情報名

                WK_str = New_Line_Cng(DtView1(i)("part_code1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty1") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg1") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg1") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg1") & Chr(34)        'EU額

                WK_str = New_Line_Cng(DtView1(i)("part_code2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty2") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg2") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg2") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg2") & Chr(34)        'EU額

                WK_str = New_Line_Cng(DtView1(i)("part_code3"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name3"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty3") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg3") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg3") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg3") & Chr(34)        'EU額

                WK_str = New_Line_Cng(DtView1(i)("part_code4"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name4"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty4") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg4") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg4") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg4") & Chr(34)        'EU額

                WK_str = New_Line_Cng(DtView1(i)("part_code5"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name5"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty5") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg5") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg5") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg5") & Chr(34)        'EU額

                WK_str = New_Line_Cng(DtView1(i)("part_code6"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name6"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty6") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg6") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg6") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg6") & Chr(34)        'EU額

                WK_str = New_Line_Cng(DtView1(i)("part_code7"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name7"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty7") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg7") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg7") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg7") & Chr(34)        'EU額

                WK_str = New_Line_Cng(DtView1(i)("part_code8"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品番号
                WK_str = New_Line_Cng(DtView1(i)("part_name8"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)      '部品名
                strData += "," & Chr(34) & DtView1(i)("use_qty8") & Chr(34)        '数量
                strData += "," & Chr(34) & DtView1(i)("cost_chrg8") & Chr(34)      'コスト
                strData += "," & Chr(34) & DtView1(i)("shop_chrg8") & Chr(34)      '計上額
                strData += "," & Chr(34) & DtView1(i)("eu_chrg8") & Chr(34)        'EU額

                strData += "," & Chr(34) & DtView1(i)("comp_shop_part_chrg") & Chr(34)         '部品代
                strData += "," & Chr(34) & DtView1(i)("comp_shop_apes") & Chr(34)              'APSE
                strData += "," & Chr(34) & DtView1(i)("comp_shop_tech_chrg") & Chr(34)         '技術料
                strData += "," & Chr(34) & DtView1(i)("comp_shop_fee") & Chr(34)               'その他
                strData += "," & Chr(34) & DtView1(i)("comp_shop_pstg") & Chr(34)              '送料
                strData += "," & Chr(34) & DtView1(i)("comp_shop_ttl") & Chr(34)               '小計
                strData += "," & Chr(34) & DtView1(i)("comp_shop_tax") & Chr(34)               '消費税
                strData += "," & Chr(34) & DtView1(i)("comp_shop_Gttl") & Chr(34)              '合計
                strData += "," & Chr(34) & DtView1(i)("rebate") & Chr(34)                      '販社リベート
                strData += "," & Chr(34) & DtView1(i)("sals_amnt") & Chr(34)                   '自己負担金

                strData += "," & Chr(34) & DtView1(i)("HSY_name") & Chr(34)                    'QG-Care保証範囲
                strData += "," & Chr(34) & DtView1(i)("rpar_comp_name") & Chr(34)              '修理会社
                strData += "," & Chr(34) & DtView1(i)("rcpt_brch_name") & Chr(34)              '受付ＱＧ
                If Not IsDBNull(DtView1(i)("zero_name")) Then
                    WK_str = DtView1(i)("zero_name")
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '\0理由
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("sals_no") & Chr(34)                     'ネバ伝番号
                strData += "," & Chr(34) & DtView1(i)("sals_no2") & Chr(34)                    'ネバ伝番号（リベート）
                strData += "," & Chr(34) & DtView1(i)("rcpt_no_aka") & Chr(34)                 '赤伝受付番号
                strData += "," & Chr(34) & DtView1(i)("orgnl_vndr_code") & Chr(34)             'オリジナルメーカーコード
                If Not IsDBNull(DtView1(i)("user_trbl")) Then
                    WK_str = New_Line_Cng(DtView1(i)("user_trbl"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '申告症状
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_meas"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '修理内容
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("qg_care_no") & Chr(34)                  'QG-Care番号
                If IsDBNull(DtView1(i)("note_kbn2")) Then
                    strData += "," & Chr(34) & Chr(34)                                         'Note
                Else
                    If DtView1(i)("note_kbn2") = "01" Then
                        strData += "," & Chr(34) & "1" & Chr(34)
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    WK_str = New_Line_Cng(DtView1(i)("comp_comn"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                                '完了コメント
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("defe_name") & Chr(34)                   'Mobile種別（CLS：035）
                strData += "," & Chr(34) & DtView1(i)("reference_no") & Chr(34)                'レジ番号
                If Not IsDBNull(DtView1(i)("imv_rcpt_no")) Then
                    strData += "," & Chr(34) & Mid(DtView1(i)("imv_rcpt_no"), 1, 2) & Chr(34)  '登録QG
                    strData += "," & Chr(34) & DtView1(i)("imv_rcpt_no") & Chr(34)              'iMVAR管理番号
                Else
                    strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(i)("sb_imei_old") & Chr(34)                 'SB/IMEI番号
                strData += "," & Chr(34) & DtView1(i)("sb_imei_new") & Chr(34)                 'SB/新IMEI番号
                'strData += ",END"

                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          'ファイルを閉じる
            MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            waitDlg.Close()         '進行状況ダイアログを閉じる
            Me.Enabled = True       'オーナーのフォームを無効にする
        End If

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
