Public Class F01_Form16
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, strWH, inz_f, strFile, strData As String
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
    Friend WithEvents DataGridEx1 As nMVAR_QA.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.FunctionKey
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form16))
        Me.DataGridEx1 = New nMVAR_QA.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.f12 = New System.Windows.Forms.Button
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FunctionKey1 = New GrapeCity.Win.Input.FunctionKey
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 46)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(988, 636)
        Me.DataGridEx1.TabIndex = 1252
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "QA02_data"
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "ステータス"
        Me.DataGridTextBoxColumn2.MappingName = "stts_name"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 99
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "受付番号"
        Me.DataGridTextBoxColumn1.MappingName = "gss_rcpt_no"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "QAC番号"
        Me.DataGridTextBoxColumn5.MappingName = "qac_no"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 150
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "お客様指名"
        Me.DataGridTextBoxColumn6.MappingName = "user_name"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 150
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "メーカー名"
        Me.DataGridTextBoxColumn7.MappingName = "maker_name"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 150
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "機種名"
        Me.DataGridTextBoxColumn11.MappingName = "model_name"
        Me.DataGridTextBoxColumn11.NullText = ""
        Me.DataGridTextBoxColumn11.Width = 200
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "##,##0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "自動進行"
        Me.DataGridTextBoxColumn3.MappingName = "auto_shinkou"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(896, 6)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 30
        Me.f12.Text = "F12:閉じる"
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(40, 0)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 16)
        Me.CL001.TabIndex = 1257
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo001.Items.AddRange(New GrapeCity.Win.Input.ComboItem() {New GrapeCity.Win.Input.ComboItem(0, Nothing, "未着手", Nothing, "0", System.Drawing.Color.Transparent, True, System.Drawing.Color.Empty, "未着手", True), New GrapeCity.Win.Input.ComboItem(0, Nothing, "全て", Nothing, "1", System.Drawing.Color.Transparent, True, System.Drawing.Color.Empty, "全て", True)})
        Me.Combo001.Location = New System.Drawing.Point(92, 16)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(196, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 10
        Me.Combo001.Value = "Combo001"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 24)
        Me.Label5.TabIndex = 1256
        Me.Label5.Text = "ステータス"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 1255
        Me.Label1.Text = "一覧表表示"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FunctionKey1
        '
        Me.FunctionKey1.ActiveKeySet = "Default"
        Me.FunctionKey1.Location = New System.Drawing.Point(0, 686)
        Me.FunctionKey1.Name = "FunctionKey1"
        Me.FunctionKey1.Size = New System.Drawing.Size(1000, 0)
        Me.FunctionKey1.TabIndex = 1254
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(772, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "CSV書出"
        '
        'F01_Form16
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(1000, 686)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FunctionKey1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form16"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "一覧表表示"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F01_Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()
        'CmbSet()
        Combo001.Text = "未着手"
        CL001.Text = "0"

        'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ設定
        sql()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("QA02_data")
        DataGridEx1.DataSource = tbl
        inz_f = "0"
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)
    End Sub

    ''********************************************************************
    ''**  コンボボックスセット
    ''********************************************************************
    'Sub CmbSet()

    '    'ステータス
    '    strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name, dsp_seq"
    '    strSQL += " FROM M21_CLS_CODE"
    '    strSQL += " WHERE (cls_no = '052') AND (delt_flg = 0)"
    '    strSQL += " UNION"
    '    strSQL += " SELECT '00' AS cls_code, '全て' AS cls_code_name, 0 AS dsp_seq"
    '    strSQL += " ORDER BY dsp_seq, cls_code"
    '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '    DaList1.SelectCommand = SqlCmd1
    '    SqlCmd1.CommandTimeout = 600
    '    DB_OPEN("nMVAR")
    '    DaList1.Fill(DsCMB, "CLS_CODE_052")
    '    DB_CLOSE()

    '    Combo001.DataSource = DsCMB.Tables("CLS_CODE_052")
    '    Combo001.DisplayMember = "cls_code_name"
    '    Combo001.ValueMember = "cls_code"

    '    Combo001.Text = "全て"
    '    CL001.Text = "00"

    '    '全てを選択した時のWHERE文
    '    strWH = Nothing
    '    DtView1 = New DataView(DsCMB.Tables("CLS_CODE_052"), "cls_code <>'00'", "", DataViewRowState.CurrentRows)
    '    If DtView1.Count <> 0 Then
    '        For i = 0 To DtView1.Count - 1
    '            If i = 0 Then
    '                strWH = " WHERE (QA02_data.stts = N'" & DtView1(i)("cls_code") & "')"
    '            Else
    '                strWH += " OR (QA02_data.stts = N'" & DtView1(i)("cls_code") & "')"
    '            End If
    '        Next
    '    End If
    'End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    'Private Sub DataGridEx1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
    '    If DataGridEx1.CurrentRowIndex >= 0 Then
    '        DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
    '    End If
    'End Sub

    '********************************************************************
    '**  ステータス　変更
    '********************************************************************
    Private Sub Combo001_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo001.SelectedIndexChanged
        CL001.Text = Combo001.SelectedIndex
        sql()
    End Sub

    '********************************************************************
    '**  データ抽出
    '********************************************************************
    Sub sql()
        DsList1.Clear()

        strSQL = "SELECT QA02_data.stts, V_cls_052.cls_code_name AS stts_name, QA02_data.qac_no, QA02_data.gss_rcpt_no, QA02_data.user_name, QA02_data.maker_name, QA02_data.model_name, QA02_data.auto_shinkou"
        'strSQL += " FROM QA02_data INNER JOIN"
        'strSQL += " T01_REP_MTR ON QA02_data.gss_rcpt_no = T01_REP_MTR.rcpt_no LEFT OUTER JOIN"
        'strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
        strSQL += " FROM QA02_data LEFT OUTER JOIN"
        strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code"
        strSQL += " WHERE (QA02_data.gss_rcpt_no IS NOT NULL)"
        If CL001.Text = "0" Then    '未着手
            'strSQL += " WHERE (T01_REP_MTR.sindan_date IS NULL) AND (T01_REP_MTR.etmt_date IS NULL)"        '診断日、見積日
            'strSQL += " AND (T01_REP_MTR.rsrv_cacl_date IS NULL) AND (T01_REP_MTR.part_ordr_date IS NULL)"  '保留解除日、部品発注日
            'strSQL += " AND (T01_REP_MTR.part_rcpt_date IS NULL) AND (T01_REP_MTR.rep_date IS NULL)"        '部品受領日、修理日
            'strSQL += " AND (T01_REP_MTR.renraku_date IS NULL) AND (T01_REP_MTR.comp_date IS NULL)"         '連絡日、完了日
            'strSQL += " AND (T01_REP_MTR.sals_date IS NULL) AND (T01_REP_MTR.ship_date IS NULL)"            '売上日、出荷日
            'strSQL += " AND (T01_REP_MTR.rqst_date IS NULL)"                                                '請求日
            strSQL += " AND (QA02_data.started_flg = 0)"
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "QA02_data")
        DB_CLOSE()

        If r = 0 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    '********************************************************************
    '**  CSV書出
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "QAC一覧" & Format(CDate(Now), "yyyyMMdd") & ".CSV"  'はじめのファイル名を指定する
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
            strData = "ステータス,受付番号,受付種別,入荷区分コード,入荷区分名,グループコード,グループ名,取次店コード,取次店名"
            strData += ",販社伝番,お客様名,受付年月日,修理完了日,売上日,出荷日,見積日付,回答受信日,部品発注日,部品受領日"
            strData += ",見積書金額,社員コード,修理担当者名,メーカーコード,メーカー名,モデル,機種,製造番号,保証情報,保証情報名"
            strData += ",部品番号1,部品名1,数量1,コスト1,計上額1,EU額1,部品番号2,部品名2,数量2,コスト2,計上額2,EU額2"
            strData += ",部品番号3,部品名3,数量3,コスト3,計上額3,EU額3,部品番号4,部品名4,数量4,コスト4,計上額4,EU額4"
            strData += ",部品番号5,部品名5,数量5,コスト5,計上額5,EU額5,部品番号6,部品名6,数量6,コスト6,計上額6,EU額6"
            strData += ",部品番号7,部品名7,数量7,コスト7,計上額7,EU額7,部品番号8,部品名8,数量8,コスト8,計上額8,EU額8"
            strData += ",部品代,APSE,技術料,その他,送料,小計,消費税,合計,自己負担金,修理会社,受付ＱＧ,\0理由"
            strData += ",オリジナルメーカーコード,申告症状,修理内容,Note,完了コメント,登録QG"
            swFile.WriteLine(strData)

            WK_DtView1 = New DataView(DsList1.Tables("QA02_data"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To WK_DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / WK_DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(WK_DtView1.Count, "##,##0") & " 件）"
                waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / WK_DtView1.Count) & "%"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                WK_DsList1.Clear()
                strSQL = "SELECT V_cls_052.cls_code_name AS stts_name, T01_REP_MTR.rcpt_no, V_cls_007.cls_code_name AS rcpt_cls_name"
                strSQL += ", T01_REP_MTR.arvl_cls, V_cls_018.cls_code_name AS arvl_cls_name, M08_STORE.grup_code"
                strSQL += ", V_cls_006.cls_code_name AS grup_name, T01_REP_MTR.store_code, M08_STORE.name AS store_name"
                strSQL += ", T01_REP_MTR.store_repr_no, T01_REP_MTR.user_name, T01_REP_MTR.accp_date, T01_REP_MTR.comp_date"
                strSQL += ", T01_REP_MTR.sals_date, T01_REP_MTR.ship_date, T01_REP_MTR.etmt_date, T01_REP_MTR.rsrv_cacl_date"
                strSQL += ", T01_REP_MTR.part_ordr_date, T01_REP_MTR.part_rcpt_date, T01_REP_MTR.etmt_shop_ttl"
                strSQL += ", T01_REP_MTR.etmt_shop_tax, T01_REP_MTR.repr_empl_code, M01_EMPL.name AS repr_empl_name"
                strSQL += ", T01_REP_MTR.vndr_code, M05_VNDR.name AS vndr_name, T01_REP_MTR.model_1, T01_REP_MTR.model_2"
                strSQL += ", T01_REP_MTR.s_n, T01_REP_MTR.rpar_cls, V_cls_001.cls_code_name AS rpar_cls_name"
                strSQL += ", T01_REP_MTR.comp_shop_part_chrg, T01_REP_MTR.comp_shop_apes, T01_REP_MTR.comp_shop_tech_chrg"
                strSQL += ", T01_REP_MTR.comp_shop_fee, T01_REP_MTR.comp_shop_pstg, T01_REP_MTR.comp_shop_ttl"
                strSQL += ", T01_REP_MTR.comp_shop_tax, T01_REP_MTR.aka_flg, T01_REP_MTR.idvd_chrg AS sals_amnt"
                strSQL += ", M06_RPAR_COMP.name AS rpar_comp_name, M03_BRCH.name AS rcpt_brch_name, T01_REP_MTR.zero_name"
                strSQL += ", T01_REP_MTR.orgnl_vndr_code, T01_REP_MTR.user_trbl, T01_REP_MTR.comp_meas, T01_REP_MTR.note_kbn2"
                strSQL += ", T01_REP_MTR.comp_comn, T01_REP_MTR.imv_rcpt_no"
                strSQL += " FROM QA02_data INNER JOIN"
                strSQL += " V_cls_052 ON QA02_data.stts = V_cls_052.cls_code INNER JOIN"
                strSQL += " T01_REP_MTR ON QA02_data.gss_rcpt_no = T01_REP_MTR.rcpt_no INNER JOIN"
                strSQL += " V_cls_007 ON T01_REP_MTR.rcpt_cls = V_cls_007.cls_code INNER JOIN"
                strSQL += " V_cls_018 ON T01_REP_MTR.arvl_cls = V_cls_018.cls_code INNER JOIN"
                strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
                strSQL += " V_cls_006 ON M08_STORE.grup_code = V_cls_006.cls_code INNER JOIN"
                strSQL += " M05_VNDR ON T01_REP_MTR.vndr_code = M05_VNDR.vndr_code INNER JOIN"
                strSQL += " V_cls_001 ON T01_REP_MTR.rpar_cls = V_cls_001.cls_code INNER JOIN"
                strSQL += " M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code INNER JOIN"
                strSQL += " M03_BRCH ON T01_REP_MTR.rcpt_brch_code = M03_BRCH.brch_code LEFT OUTER JOIN"
                strSQL += " M01_EMPL ON T01_REP_MTR.repr_empl_code = M01_EMPL.empl_code"
                strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & WK_DtView1(i)("gss_rcpt_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList1, "csv")
                DB_CLOSE()
                DtView1 = New DataView(WK_DsList1.Tables("csv"), "", "", DataViewRowState.CurrentRows)

                strData = Chr(34) & DtView1(0)("stts_name") & Chr(34)               'ステータス
                strData += "," & Chr(34) & DtView1(0)("rcpt_no") & Chr(34)          '受付番号
                strData += "," & Chr(34) & DtView1(0)("rcpt_cls_name") & Chr(34)    '受付種別
                strData += "," & Chr(34) & DtView1(0)("arvl_cls") & Chr(34)         '入荷区分コード
                strData += "," & Chr(34) & DtView1(0)("arvl_cls_name") & Chr(34)    '入荷区分名
                strData += "," & Chr(34) & DtView1(0)("grup_code") & Chr(34)          'グループコード
                strData += "," & Chr(34) & DtView1(0)("grup_name") & Chr(34)          'グループ名
                strData += "," & Chr(34) & DtView1(0)("store_code") & Chr(34)          '取次店コード
                strData += "," & Chr(34) & DtView1(0)("store_name") & Chr(34)          '取次店名
                strData += "," & Chr(34) & DtView1(0)("store_repr_no") & Chr(34)          '販社伝番
                strData += "," & Chr(34) & DQM_Cng(DtView1(0)("user_name")) & Chr(34)          'お客様名
                strData += "," & Chr(34) & DtView1(0)("accp_date") & Chr(34)          '受付年月日
                strData += "," & Chr(34) & DtView1(0)("comp_date") & Chr(34)          '修理完了日
                strData += "," & Chr(34) & DtView1(0)("sals_date") & Chr(34)          '売上日
                strData += "," & Chr(34) & DtView1(0)("ship_date") & Chr(34)          '出荷日
                strData += "," & Chr(34) & DtView1(0)("etmt_date") & Chr(34)          '見積日付
                strData += "," & Chr(34) & DtView1(0)("rsrv_cacl_date") & Chr(34)          '回答受信日
                strData += "," & Chr(34) & DtView1(0)("part_ordr_date") & Chr(34)          '部品発注日
                strData += "," & Chr(34) & DtView1(0)("part_rcpt_date") & Chr(34)          '部品受領日
                WK_AMT = 0
                If Not IsDBNull(DtView1(0)("etmt_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(0)("etmt_shop_ttl")
                If Not IsDBNull(DtView1(0)("etmt_shop_tax")) Then WK_AMT = WK_AMT + DtView1(0)("etmt_shop_tax")
                strData += "," & Chr(34) & WK_AMT & Chr(34)          '見積書金額
                strData += "," & Chr(34) & DtView1(0)("repr_empl_code") & Chr(34)          '社員コード
                strData += "," & Chr(34) & DtView1(0)("repr_empl_name") & Chr(34)          '修理担当者名
                strData += "," & Chr(34) & DtView1(0)("vndr_code") & Chr(34)          'メーカーコード
                strData += "," & Chr(34) & DtView1(0)("vndr_name") & Chr(34)          'メーカー名
                WK_str = New_Line_Cng(DtView1(0)("model_1"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                   'モデル
                WK_str = New_Line_Cng(DtView1(0)("model_2"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                   '機種
                WK_str = New_Line_Cng(DtView1(0)("s_n"))
                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                   '製造番号
                strData += "," & Chr(34) & DtView1(0)("rpar_cls") & Chr(34)          '保証情報
                strData += "," & Chr(34) & DtView1(0)("rpar_cls_name") & Chr(34)          '保証情報名

                '部品情報
                WK_AMT2 = 0 : WK_AMT3 = 0 : WK_AMT4 = 0 : WK_AMT5 = 0
                WK_DsList2.Clear()
                SqlCmd1 = New SqlClient.SqlCommand("sp_F40_05_2", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 9)
                Pram1.Value = DtView1(0)("rcpt_no")
                DaList1.SelectCommand = SqlCmd1
                DB_OPEN("nMVAR")
                DaList1.Fill(WK_DsList2, "T04_REP_PART")
                DB_CLOSE()
                WK_DtView2 = New DataView(WK_DsList2.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView2.Count <> 0 Then
                    For j = 0 To WK_DtView2.Count - 1
                        Select Case j
                            Case Is < 7
                                WK_str = New_Line_Cng(WK_DtView2(j)("part_code"))
                                strData += "," & Chr(34) & WK_str & Chr(34)                            '部品番号
                                WK_str = New_Line_Cng(WK_DtView2(j)("part_name"))
                                strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                   '部品名
                                strData += "," & Chr(34) & WK_DtView2(j)("use_qty") & Chr(34)          '数量
                                strData += "," & Chr(34) & WK_DtView2(j)("cost_chrg") & Chr(34)        'コスト
                                strData += "," & Chr(34) & WK_DtView2(j)("shop_chrg") & Chr(34)        '計上額
                                strData += "," & Chr(34) & WK_DtView2(j)("eu_chrg") & Chr(34)          'EU額

                            Case Is = 7
                                If WK_DtView2.Count = 8 Then
                                    WK_str = New_Line_Cng(WK_DtView2(j)("part_code"))
                                    strData += "," & Chr(34) & WK_str & Chr(34)                        '部品番号
                                    WK_str = New_Line_Cng(WK_DtView2(j)("part_name"))
                                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)               '部品名
                                    strData += "," & Chr(34) & WK_DtView2(j)("use_qty") & Chr(34)      '数量
                                    strData += "," & Chr(34) & WK_DtView2(j)("cost_chrg") & Chr(34)    'コスト
                                    strData += "," & Chr(34) & WK_DtView2(j)("shop_chrg") & Chr(34)    '計上額
                                    strData += "," & Chr(34) & WK_DtView2(j)("eu_chrg") & Chr(34)      'EU額
                                Else
                                    WK_AMT2 = WK_AMT2 + WK_DtView2(j)("use_qty")
                                    WK_AMT3 = WK_AMT3 + WK_DtView2(j)("cost_chrg") * WK_DtView2(j)("use_qty")
                                    WK_AMT4 = WK_AMT4 + WK_DtView2(j)("shop_chrg")
                                    WK_AMT5 = WK_AMT5 + WK_DtView2(j)("eu_chrg")
                                End If

                            Case Else
                                WK_AMT2 = WK_AMT2 + WK_DtView2(j)("use_qty")
                                WK_AMT3 = WK_AMT3 + WK_DtView2(j)("cost_chrg")
                                WK_AMT4 = WK_AMT4 + WK_DtView2(j)("shop_chrg")
                                WK_AMT5 = WK_AMT5 + WK_DtView2(j)("eu_chrg")

                        End Select
                    Next
                End If
                Select Case WK_DtView2.Count
                    Case Is < 8
                        For j = 1 To 8 - WK_DtView2.Count
                            strData += "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34)
                        Next
                    Case Is = 8
                    Case Else
                        strData += "," & Chr(34) & Chr(34)                                     '部品番号
                        strData += "," & Chr(34) & "その他部品" & Chr(34)                      '部品名
                        strData += "," & Chr(34) & WK_AMT2 & Chr(34)                           '数量
                        strData += "," & Chr(34) & WK_AMT3 & Chr(34)                           'コスト
                        strData += "," & Chr(34) & WK_AMT4 & Chr(34)                           '計上額
                        strData += "," & Chr(34) & WK_AMT5 & Chr(34)                           'EU額
                End Select

                strData += "," & Chr(34) & DtView1(0)("comp_shop_part_chrg") & Chr(34)         '部品代
                strData += "," & Chr(34) & DtView1(0)("comp_shop_apes") & Chr(34)              'APSE
                strData += "," & Chr(34) & DtView1(0)("comp_shop_tech_chrg") & Chr(34)         '技術料
                strData += "," & Chr(34) & DtView1(0)("comp_shop_fee") & Chr(34)               'その他
                strData += "," & Chr(34) & DtView1(0)("comp_shop_pstg") & Chr(34)              '送料
                WK_AMT = 0
                If Not IsDBNull(DtView1(0)("comp_shop_ttl")) Then WK_AMT = WK_AMT + DtView1(0)("comp_shop_ttl")
                strData += "," & Chr(34) & WK_AMT & Chr(34)                                    '小計
                If Not IsDBNull(DtView1(0)("comp_shop_tax")) Then
                    strData += "," & Chr(34) & DtView1(0)("comp_shop_tax") & Chr(34)           '消費税
                    strData += "," & Chr(34) & WK_AMT + DtView1(0)("comp_shop_tax") & Chr(34)  '合計
                Else
                    strData += "," & Chr(34) & "0" & Chr(34)                                   '消費税
                    strData += "," & Chr(34) & WK_AMT & Chr(34)                                '合計
                End If
                If IsDBNull(DtView1(0)("aka_flg")) Then
                    strData += "," & Chr(34) & DtView1(0)("sals_amnt") & Chr(34)               '自己負担金
                Else
                    If DtView1(0)("aka_flg") = "True" Then
                        strData += "," & Chr(34) & "0" & Chr(34)
                    Else
                        strData += "," & Chr(34) & DtView1(0)("sals_amnt") & Chr(34)
                    End If
                End If
                strData += "," & Chr(34) & DtView1(0)("rpar_comp_name") & Chr(34)              '修理会社
                strData += "," & Chr(34) & DtView1(0)("rcpt_brch_name") & Chr(34)              '受付ＱＧ
                If Not IsDBNull(DtView1(0)("zero_name")) Then
                    WK_str = DtView1(0)("zero_name")
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                       '\0理由
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                strData += "," & Chr(34) & DtView1(0)("orgnl_vndr_code") & Chr(34)             'オリジナルメーカーコード
                If Not IsDBNull(DtView1(0)("user_trbl")) Then
                    WK_str = New_Line_Cng(DtView1(0)("user_trbl"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                       '申告症状
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(0)("comp_meas")) Then
                    WK_str = New_Line_Cng(DtView1(0)("comp_meas"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                       '修理内容
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                If IsDBNull(DtView1(0)("note_kbn2")) Then
                    strData += "," & Chr(34) & Chr(34)                                         'Note
                Else
                    If DtView1(0)("note_kbn2") = "01" Then
                        strData += "," & Chr(34) & "1" & Chr(34)
                    Else
                        strData += "," & Chr(34) & Chr(34)
                    End If
                End If
                If Not IsDBNull(DtView1(0)("comp_comn")) Then
                    WK_str = New_Line_Cng(DtView1(0)("comp_comn"))
                    strData += "," & Chr(34) & DQM_Cng(WK_str) & Chr(34)                       '完了コメント
                Else
                    strData += "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(0)("imv_rcpt_no")) Then
                    strData += "," & Chr(34) & Mid(DtView1(0)("imv_rcpt_no"), 1, 2) & Chr(34)  '登録QG
                Else
                    strData += "," & Chr(34)
                End If

                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          'ファイルを閉じる
            MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            waitDlg.Close()         '進行状況ダイアログを閉じる
            Me.Enabled = True       'オーナーのフォームを無効にする
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        WK_DsList2.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  ファンクションキー
    '********************************************************************
    Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

        e.Handled = True        'ファンクションキーに割り付けられた設定を無効にします。
        Select Case e.KeyIndex  'ファンクションキーが押下された場合の処理を行います。
            Case 0  'F1
            Case 1  'F2
            Case 2  'F3
            Case 3  'F4
            Case 4  'F5
            Case 5  'F6
            Case 6  'F7
            Case 7  'F8
            Case 8  'F9
            Case 9  'F10
            Case 10 'F11
            Case 11 'F12
                f12_Click(sender, e)
        End Select
    End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub Combo001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.GotFocus
        Combo001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Combo001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
