Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList0 As New DataSet
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2 As DataView

    Dim strFile, filename As String

    Dim strSQL, strDATA(31), Err_F, Err_code, WK_str, Main_skp, WK_cont_flg, WK_aka_kuro, WK_dsp, WK_fee_kbn As String
    Dim i, j, r, pos, len, WK_seq, WK_wrn_prod As Integer
    Dim imp_date, close_date As Date

    Dim pgm As String
    Dim OK_cnt, NG_cnt As Integer

    Dim waitDlg As WaitDialog

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Timers.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Timers.Timer
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button01 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(160, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "インポート"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.SynchronizingObject = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 48)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "取込み"
        '
        'msg
        '
        Me.msg.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(24, 196)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(620, 32)
        Me.msg.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(528, 144)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 44)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "終　了"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(20, 76)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(540, 31)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = ""
        '
        'Button01
        '
        Me.Button01.BackColor = System.Drawing.SystemColors.Control
        Me.Button01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button01.Location = New System.Drawing.Point(564, 76)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(80, 36)
        Me.Button01.TabIndex = 6
        Me.Button01.Text = "参照"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(11, 24)
        Me.ClientSize = New System.Drawing.Size(674, 251)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button01)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Homac インポート"
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call ds_set()   '** データセット
    End Sub

    '******************************************************************
    '** 初期処理
    '******************************************************************
    Sub inz()
        Call DB_INIT()
        close_date = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM") & "/01"
    End Sub

    '******************************************************************
    '** データセット
    '******************************************************************
    Sub ds_set()
        DsList0.Clear()
        DB_OPEN()

        '店舗マスタ
        strSQL = "SELECT shop_code FROM Shop_mtr WHERE (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList0, "Shop_mtr")

        ''メーカーマスタ
        'strSQL = "SELECT vdr_code FROM vdr_mtr WHERE (delt_flg = 0)"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(DsList0, "vdr_mtr")

        ''部門マスタ
        'strSQL = "SELECT section_code FROM section_mtr WHERE (delt_flg = 0)"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(DsList0, "section_mtr")

        ''ラインマスタ
        'strSQL = "SELECT section_code, line_code FROM line_mtr WHERE (delt_flg = 0)"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(DsList0, "line_mtr")

        ''クラスマスタ
        'strSQL = "SELECT * FROM cls_mtr WHERE (delt_flg = 0)"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(DsList0, "cls_mtr")

        ''サブクラスマスタ
        'strSQL = "SELECT section_code, line_code, cls_code, sub_cls_code FROM sub_cls_mtr WHERE (delt_flg = 0)"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(DsList0, "sub_cls_mtr")

        '料金表区分
        'strSQL = "SELECT * FROM fee_mtr WHERE (fee_kbn <> 'B')"
        strSQL = "SELECT * FROM fee_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList0, "fee_mtr")

        '例外
        strSQL = "SELECT * FROM Exception"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList0, "Exception")

        DB_CLOSE()
    End Sub

    '*********************************************************************************
    '**  参照
    '*********************************************************************************
    Private Sub Button01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button01.Click
        With OpenFileDialog1
            .CheckFileExists = True     'ファイルが存在するか確認
            .RestoreDirectory = True    'ディレクトリの復元
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "datファイル(*.dat)|*.dat|テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*"
            .FilterIndex = 2            'Filterプロパティの2つ目を表示
            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                TextBox1.Text = .FileName
            End If
        End With
    End Sub

    '******************************************************************
    '** 取込み
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        OK_cnt = 0
        NG_cnt = 0

        strFile = TextBox1.Text

        imp_date = Format(Now, "yyyy/MM/dd HH:mm") & ":00"
        filename = strFile.Substring(strFile.LastIndexOf("\") + 1)

        Call File_chk()
        If Err_F = "0" Then

            Me.Enabled = False                      ' オーナーのフォームを無効にする
            waitDlg = New WaitDialog                ' 進行状況ダイアログ
            waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = "保証データ取込"      ' 処理の概要を表示
            waitDlg.ProgressMsg = ""                ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0               ' 最初の件数を設定
            waitDlg.Show()                          ' 進行状況ダイアログを表示する
            Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

            DB_OPEN()

            Dim srFile0 As New System.IO.StreamReader(strFile, System.Text.Encoding.Default)
            Dim strLine0 As String = srFile0.ReadLine()
            Dim LineCount As Integer
            While (srFile0.Peek() >= 0)
                srFile0.ReadLine()
                LineCount += 1
            End While

            waitDlg.ProgressMsg = "取込中"
            waitDlg.ProgressMax = LineCount             ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            Dim srFile As New System.IO.StreamReader(strFile, System.Text.Encoding.Default)
            Dim strLine As String = srFile.ReadLine()
            While Not strLine Is Nothing
                waitDlg.PerformStep()                   ' 処理カウントを1ステップ進める

                strLine = strLine.Replace("'", " ")

                strSQL = "INSERT INTO txt_all"
                strSQL = strSQL & " (txt_data, imp_date, file_name, new_txt)"
                strSQL = strSQL & " VALUES ('" & strLine & "'"
                strSQL = strSQL & ", CONVERT(DATETIME, '" & imp_date & "', 102)"
                strSQL = strSQL & ", '" & filename & "'"
                strSQL = strSQL & ", '1')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                strLine = srFile.ReadLine()
            End While
            srFile.Close()

            DsList1.Clear()
            strSQL = "SELECT * FROM txt_all"
            strSQL = strSQL & " WHERE (file_name = '" & filename & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "txt_all")
            DtView1 = New DataView(DsList1.Tables("txt_all"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                waitDlg.ProgressMsg = "項目チェック中"
                waitDlg.ProgressValue = 0                   ' 最初の件数を設定
                waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
                Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1
                    waitDlg.PerformStep()                   ' 処理カウントを1ステップ進める

                    Call F_slct()               '** 項目分割
                    Call F_chk()                '** 項目チェック
                    If Err_F = "0" Then
                        OK_cnt += 1
                        Call wrn_data_add()     '** wrn_data 登録
                    Else
                        NG_cnt += 1
                        Call err_add()          '** エラー登録
                    End If
                Next
            End If

            DB_CLOSE()
            Me.Activate()
            Me.Enabled = True                      ' オーナーのフォームを有効にする
            waitDlg.Close()
            msg.Text = "取込み完了" & " (OK: " & OK_cnt & "件 ｴﾗｰ: " & NG_cnt & "件)"

        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub File_chk()
        Err_F = "0"

        TextBox1.Text = Trim(TextBox1.Text)
        If TextBox1.Text = Nothing Then
            MsgBox("取込ファイルを指定してください。", 16, "Error")    '× 1=ＯＫ
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

        If System.IO.File.Exists(TextBox1.Text) = False Then
            MsgBox("該当するファイルがありません。", 16, "Error")    '× 1=ＯＫ
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT TOP (1) file_name FROM txt_all WHERE (file_name = '" & filename & "')", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 3600
        r = DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        If r <> 0 Then
            MsgBox("指定のファイル名は既に取り込み済みです。", 16, "Error")    '× 1=ＯＫ
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '******************************************************************
    '** 項目分割
    '******************************************************************
    Sub F_slct()

        WK_str = DtView1(i)("txt_data")
        pos = 1 : len = 15 : strDATA(1) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 2 : strDATA(2) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(3) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(4) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 11 : strDATA(5) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(6) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(7) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 11 : strDATA(8) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 7 : strDATA(9) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 80 : strDATA(10) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 80 : strDATA(11) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 80 : strDATA(12) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 2 : strDATA(13) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 10 : strDATA(14) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 40 : strDATA(15) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(16) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(17) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(18) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 3 : strDATA(19) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 1
        pos = pos + len : len = 13 : strDATA(20) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 9 : strDATA(21) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 30 : strDATA(22) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 30 : strDATA(23) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 13 : strDATA(24) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 8 : strDATA(25) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 2 : strDATA(26) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 6 : strDATA(27) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 4 : strDATA(28) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 10 : strDATA(29) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 60 : strDATA(30) = Trim(MidB(WK_str, pos, len))
        pos = pos + len : len = 8 : strDATA(31) = Trim(MidB(WK_str, pos, len))

    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"
        Err_code = Nothing
        Main_skp = "0"

        '伝票No.
        If strDATA(1) = Nothing Then
            Err_F = "1" : Err_code = "011" : Exit Sub
        Else
            If LenB(strDATA(1)) <> 15 Then
                Err_F = "1" : Err_code = "012" : Exit Sub
            Else
                WK_DsList1.Clear()
                strSQL = "SELECT * FROM WRN_MAIN"
                strSQL = strSQL & " WHERE (wrn_no = '" & strDATA(1) & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(WK_DsList1, "WRN_MAIN")
                WK_DtView1 = New DataView(WK_DsList1.Tables("WRN_MAIN"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    Main_skp = "1"
                    If strDATA(3) <> Trim(WK_DtView1(0)("user_name_KANA")) _
                        Or strDATA(4) <> Trim(WK_DtView1(0)("user_name")) _
                        Or strDATA(5) <> Trim(WK_DtView1(0)("user_tel_no")) _
                        Or strDATA(6) <> Trim(WK_DtView1(0)("appl_name_KANA")) _
                        Or strDATA(7) <> Trim(WK_DtView1(0)("appl_name")) _
                        Or strDATA(8) <> Trim(WK_DtView1(0)("appl_tel_no")) _
                        Or strDATA(9) <> Trim(WK_DtView1(0)("zip")) _
                        Or strDATA(10) <> Trim(WK_DtView1(0)("adrs1")) _
                        Or strDATA(11) <> Trim(WK_DtView1(0)("adrs2")) _
                        Or strDATA(12) <> Trim(WK_DtView1(0)("adrs3")) _
                        Or strDATA(13) <> Trim(WK_DtView1(0)("floor")) _
                        Or strDATA(14) <> Trim(WK_DtView1(0)("room_name")) _
                        Or strDATA(15) <> Trim(WK_DtView1(0)("livi_togr")) Then
                        Err_F = "1" : Err_code = "013" : Exit Sub
                    End If
                End If
            End If
        End If

        '行No.
        If strDATA(2) = Nothing Then
            Err_F = "1" : Err_code = "021" : Exit Sub
        Else
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM WRN_SUB"
            strSQL = strSQL & " WHERE (wrn_no = '" & strDATA(1) & "')"
            strSQL = strSQL & " AND (line_no = '" & strDATA(2) & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(WK_DsList1, "WRN_SUB")
            WK_DtView1 = New DataView(WK_DsList1.Tables("WRN_SUB"), "close_date = '" & close_date & "'", "seq DESC", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                WK_seq = 1
            Else
                WK_seq = WK_DtView1(0)("seq") + 1
            End If
        End If

        'ご使用者（カナ）
        If strDATA(3) = Nothing Then
            Err_F = "1" : Err_code = "031" : Exit Sub
        End If

        'ご使用者（漢字）
        If strDATA(4) = Nothing Then
            Err_F = "1" : Err_code = "041" : Exit Sub
        End If

        'ご使用者電話番号
        If strDATA(5) = Nothing Then
            Err_F = "1" : Err_code = "051" : Exit Sub
        End If

        'お申込者（カナ）
        'お申込者（漢字）
        'お申込者電話番号

        '郵便番号
        If strDATA(9) = Nothing Then
        Else
            If LenB(strDATA(9)) <> 7 Then
                Err_F = "1" : Err_code = "092" : Exit Sub
            End If
        End If

        '住所
        '丁目
        '建物名
        '階上
        '部屋名
        '同居先

        '店舗コード
        If strDATA(29) = Nothing Then ' VJ 2021/04/02 
            Err_F = "1" : Err_code = "281" : Exit Sub
        Else
            WK_DtView1 = New DataView(DsList0.Tables("Shop_mtr"), "shop_code = '" & strDATA(29) & "'", "", DataViewRowState.CurrentRows) ' VJ 2021/04/02 
            If WK_DtView1.Count = 0 Then
                Err_F = "1" : Err_code = "282" : Exit Sub
            End If
        End If

        '受付者名
        'If strDATA(30) = Nothing Then
        '    Err_F = "1" : Err_code = "301" : Exit Sub
        'End If

        'データ入力日
        If strDATA(31) = Nothing Then
            Err_F = "1" : Err_code = "311" : Exit Sub
        Else
            WK_str = Mid(strDATA(31), 1, 4) & "/" & Mid(strDATA(31), 5, 2) & "/" & Mid(strDATA(31), 7, 2)
            If IsDate(WK_str) = False Then
                Err_F = "1" : Err_code = "312" : Exit Sub
            Else
                If WK_str < "1753/01/01" Or WK_str > "2079/06/06" Then
                    Err_F = "1" : Err_code = "313" : Exit Sub
                End If
            End If
        End If

        '商品コード
        'If strDATA(20) = Nothing Then
        '    Err_F = "1" : Err_code = "201" : Exit Sub
        'End If

        '商品名
        If strDATA(22) = Nothing Then
            Err_F = "1" : Err_code = "221" : Exit Sub
        End If

        '規格
        If strDATA(23) = Nothing Then
            Err_F = "1" : Err_code = "231" : Exit Sub
        End If

        'メーカーコード
        'If strDATA(21) = Nothing Then
        '    Err_F = "1" : Err_code = "211" : Exit Sub
        'Else
        '    WK_DtView1 = New DataView(DsList0.Tables("vdr_mtr"), "vdr_code = '" & strDATA(21) & "'", "", DataViewRowState.CurrentRows)
        '    If WK_DtView1.Count = 0 Then
        '        Err_F = "1" : Err_code = "212" : Exit Sub
        '    End If
        'End If

        '部門コード
        'If strDATA(16) = Nothing Then
        '    Err_F = "1" : Err_code = "161" : Exit Sub
        'Else
        '    WK_DtView1 = New DataView(DsList0.Tables("section_mtr"), "section_code = '" & strDATA(16) & "'", "", DataViewRowState.CurrentRows)
        '    If WK_DtView1.Count = 0 Then
        '        Err_F = "1" : Err_code = "162" : Exit Sub
        '    End If
        'End If

        'ラインコード
        'If strDATA(17) = Nothing Then
        '    Err_F = "1" : Err_code = "171" : Exit Sub
        'Else
        '    WK_DtView1 = New DataView(DsList0.Tables("line_mtr"), "section_code = '" & strDATA(16) & "' AND line_code = '" & strDATA(17) & "'", "", DataViewRowState.CurrentRows)
        '    If WK_DtView1.Count = 0 Then
        '        Err_F = "1" : Err_code = "172" : Exit Sub
        '    End If
        'End If

        'クラスコード
        'If strDATA(18) = Nothing Then
        '    Err_F = "1" : Err_code = "181" : Exit Sub
        'Else
        '    WK_DtView1 = New DataView(DsList0.Tables("cls_mtr"), "section_code = '" & strDATA(16) & "' AND line_code = '" & strDATA(17) & "' AND cls_code = '" & strDATA(18) & "'", "", DataViewRowState.CurrentRows)
        '    If WK_DtView1.Count = 0 Then
        '        Err_F = "1" : Err_code = "182" : Exit Sub
        '    Else
        '        If IsDBNull(WK_DtView1(0)("fee_kbn")) Then
        '            Err_F = "1" : Err_code = "183" : Exit Sub
        '        Else
        '            '例外
        '            WK_DtView2 = New DataView(DsList0.Tables("Exception"), "item_code = '" & strDATA(20) & "'", "", DataViewRowState.CurrentRows)
        '            If WK_DtView2.Count = 0 Then
        '                WK_fee_kbn = WK_DtView1(0)("fee_kbn")
        '            Else
        '                WK_fee_kbn = WK_DtView2(0)("fee_kbn")   '例外
        '                strDATA(26) = WK_DtView2(0)("wrn_prod")
        '            End If
        '        End If
        '    End If
        'End If

        'サブクラスコード
        'If strDATA(19) = Nothing Then
        '    Err_F = "1" : Err_code = "191" : Exit Sub
        'Else
        '    WK_DtView1 = New DataView(DsList0.Tables("sub_cls_mtr"), "section_code = '" & strDATA(16) & "' AND line_code = '" & strDATA(17) & "' AND cls_code = '" & strDATA(18) & "' AND sub_cls_code = '" & strDATA(19) & "'", "", DataViewRowState.CurrentRows)
        '    If WK_DtView1.Count = 0 Then
        '        Err_F = "1" : Err_code = "192" : Exit Sub
        '    End If
        'End If

        '料金区分
        If strDATA(28) = Nothing Then 'VJ 2021/04/02
            Err_F = "1" : Err_code = "291" : Exit Sub
        Else
            WK_DtView1 = New DataView(DsList0.Tables("fee_mtr"), "fee_kbn = '" & Trim(strDATA(28)) & "'", "", DataViewRowState.CurrentRows) 'VJ 2021/04/02
            If WK_DtView1.Count = 0 Then
                Err_F = "1" : Err_code = "183" : Exit Sub
            Else
                WK_fee_kbn = Trim(strDATA(28)) 'VJ 2021/04/02
            End If
        End If

        '税込本体価格
        If strDATA(24) = Nothing Then
            Err_F = "1" : Err_code = "241" : Exit Sub
        Else
            If IsNumeric(strDATA(24)) = False Then
                Err_F = "1" : Err_code = "242" : Exit Sub
            Else
                If strDATA(24) >= 0 Then
                    WK_cont_flg = "A"
                    WK_aka_kuro = "0"
                Else
                    WK_cont_flg = "C"
                    WK_aka_kuro = "1"
                End If
            End If
        End If

        '保証開始日
        If strDATA(25) = Nothing Then
            Err_F = "1" : Err_code = "251" : Exit Sub
        Else
            WK_str = Mid(strDATA(25), 1, 4) & "/" & Mid(strDATA(25), 5, 2) & "/" & Mid(strDATA(25), 7, 2)
            If IsDate(WK_str) = False Then
                Err_F = "1" : Err_code = "252" : Exit Sub
            Else
                If WK_str < "1753/01/01" Or WK_str > "2079/06/06" Then
                    Err_F = "1" : Err_code = "253" : Exit Sub
                End If
            End If
        End If

        '保証年数
        If strDATA(26) = Nothing Then
            Err_F = "1" : Err_code = "261" : Exit Sub
        Else
            If IsNumeric(strDATA(26)) = False Then
                Err_F = "1" : Err_code = "262" : Exit Sub
            Else
                WK_DtView1 = New DataView(DsList0.Tables("fee_mtr"), "fee_kbn = '" & WK_fee_kbn & "'", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count = 0 Then
                    Err_F = "1" : Err_code = "183" : Exit Sub
                Else
                    WK_wrn_prod = WK_DtView1(0)("wrn_prod")
                    If CInt(strDATA(26)) <> WK_wrn_prod Then
                        Err_F = "1" : Err_code = "263" : Exit Sub
                    End If
                End If
            End If
        End If

        '税込保証料
        'VJ 2021/04/02 
        'fee_kbn is A,B,C and D prch_price * 5.5
        'fee_kbn is E and F prch_price * 7
        'fee_kbn is G,H and I prch_price * 7
        ' calculate new Wrn_fee start
        'If WK_fee_kbn = "A" Or WK_fee_kbn = "B" Or WK_fee_kbn = "C" Or WK_fee_kbn = "D" Then
        '    strDATA(27) = Math.Round(strDATA(24) * 5.5 / 100, 0, MidpointRounding.AwayFromZero)
        'ElseIf WK_fee_kbn = "E" Or WK_fee_kbn = "F" Then
        '    strDATA(27) = Math.Round(strDATA(24) * 7 / 100, 0, MidpointRounding.AwayFromZero)
        'ElseIf WK_fee_kbn = "G" Or WK_fee_kbn = "H" Or WK_fee_kbn = "I" Then
        '    strDATA(27) = Math.Round(strDATA(24) * 10 / 100, 0, MidpointRounding.AwayFromZero)
        'End If
        ' calculate new Wrn_fee end

        If strDATA(27) = Nothing Then
            Err_F = "1" : Err_code = "271" : Exit Sub
        Else
            If IsNumeric(strDATA(27)) = False Then
                Err_F = "1" : Err_code = "272" : Exit Sub
            End If
            Select Case WK_fee_kbn
                Case = "A", "B", "C", "D"
                    If CInt(strDATA(27)) <> Math.Floor(strDATA(24) * 5.5 / 100) Then
                        Err_F = "1" : Err_code = "273" : Exit Sub
                    End If
                Case = "E", "F"
                    If CInt(strDATA(27)) <> 15400 Then
                        Err_F = "1" : Err_code = "273" : Exit Sub
                    End If
                Case = "G"
                    If CInt(strDATA(27)) <> 9240 Then
                        Err_F = "1" : Err_code = "273" : Exit Sub
                    End If
                Case = "H"
                    If CInt(strDATA(27)) <> 29480 Then
                        Err_F = "1" : Err_code = "273" : Exit Sub
                    End If
                Case = "I"
                    If CInt(strDATA(27)) <> 11880 Then
                        Err_F = "1" : Err_code = "273" : Exit Sub
                    End If
            End Select
        End If

        '赤データなら元黒も赤黒フラグ：ON
        WK_dsp = "1"
        If strDATA(24) < 0 Then
            WK_DtView1 = New DataView(WK_DsList1.Tables("WRN_SUB"), "dlt_f = 0 AND aka_kuro = 0 AND prch_price =" & CInt(strDATA(24)) * -1, "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then
                Err_F = "1" : Err_code = "501" : Exit Sub
            Else
                strSQL = "UPDATE WRN_SUB"
                strSQL = strSQL & " SET aka_kuro = 1"
                strSQL = strSQL & ", cont_flg = 'C'"
                If WK_DtView1(0)("close_date") = close_date Then
                    strSQL = strSQL & ", dsp_f = 0"
                    WK_dsp = "0"
                End If
                strSQL = strSQL & " WHERE (wrn_no = '" & WK_DtView1(0)("wrn_no") & "')"
                strSQL = strSQL & " AND (close_date = CONVERT(DATETIME, '" & WK_DtView1(0)("close_date") & "', 102))"
                strSQL = strSQL & " AND (line_no = '" & WK_DtView1(0)("line_no") & "')"
                strSQL = strSQL & " AND (seq = " & WK_DtView1(0)("seq") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            End If
        End If

    End Sub

    '******************************************************************
    '** wrn_data 登録
    '******************************************************************
    Sub wrn_data_add()

        If Main_skp = "0" Then
            strSQL = "INSERT INTO WRN_MAIN"
            strSQL = strSQL & " (wrn_no, user_name_KANA, user_name, user_tel_no, appl_name_KANA, appl_name"
            strSQL = strSQL & ", appl_tel_no, zip, adrs1, adrs2, adrs3, floor, room_name, livi_togr"
            strSQL = strSQL & ", shop_code, rcpt_empl_code, rcpt_empl_name, input_date, new_txt)"
            strSQL = strSQL & " VALUES  ('" & strDATA(1) & "'"
            strSQL = strSQL & ", '" & strDATA(3) & "'"
            strSQL = strSQL & ", '" & strDATA(4) & "'"
            strSQL = strSQL & ", '" & strDATA(5) & "'"
            strSQL = strSQL & ", '" & strDATA(6) & "'"
            strSQL = strSQL & ", '" & strDATA(7) & "'"
            strSQL = strSQL & ", '" & strDATA(8) & "'"
            strSQL = strSQL & ", '" & strDATA(9) & "'"
            strSQL = strSQL & ", '" & strDATA(10) & "'"
            strSQL = strSQL & ", '" & strDATA(11) & "'"
            strSQL = strSQL & ", '" & strDATA(12) & "'"
            strSQL = strSQL & ", '" & strDATA(13) & "'"
            strSQL = strSQL & ", '" & strDATA(14) & "'"
            strSQL = strSQL & ", '" & strDATA(15) & "'"
            strSQL = strSQL & ", '" & strDATA(29) & "'" '' VJ 2021/04/02 
            strSQL = strSQL & ", ''"
            strSQL = strSQL & ", '" & strDATA(30) & "'"
            strSQL = strSQL & ", CONVERT(DATETIME, '" & strDATA(31) & "', 102)"
            strSQL = strSQL & ", '1'"
            strSQL = strSQL & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            SqlCmd1.ExecuteNonQuery()
        End If

        strSQL = "INSERT INTO WRN_SUB"
        strSQL = strSQL & " (wrn_no, close_date, line_no, seq, item_code, vdr_code, section_code, line_code"
        strSQL = strSQL & ", cls_code, sub_cls_code, item_name, standard_name, prch_price, wrn_date, wrn_prod"
        strSQL = strSQL & ", wrn_fee, fee_kbn, cont_flg, add_date, dlt_f, aka_kuro, dsp_f, txt_all_id)"
        strSQL = strSQL & " VALUES  ('" & strDATA(1) & "'"
        strSQL = strSQL & ", CONVERT(DATETIME, '" & close_date & "', 102)"
        strSQL = strSQL & ", '" & strDATA(2) & "'"
        strSQL = strSQL & ", " & WK_seq
        strSQL = strSQL & ", '" & strDATA(20) & "'"
        strSQL = strSQL & ", '" & strDATA(21) & "'"
        strSQL = strSQL & ", '" & strDATA(16) & "'"
        strSQL = strSQL & ", '" & strDATA(17) & "'"
        strSQL = strSQL & ", '" & strDATA(18) & "'"
        strSQL = strSQL & ", '" & strDATA(19) & "'"
        strSQL = strSQL & ", '" & strDATA(22) & "'"
        strSQL = strSQL & ", '" & strDATA(23) & "'"
        strSQL = strSQL & ", " & strDATA(24) & ""
        strSQL = strSQL & ", CONVERT(DATETIME, '" & strDATA(25) & "', 102)"
        strSQL = strSQL & ", " & strDATA(26) & ""
        strSQL = strSQL & ", " & strDATA(27) & ""
        strSQL = strSQL & ", '" & WK_fee_kbn & "'"
        strSQL = strSQL & ", '" & WK_cont_flg & "'"
        strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("imp_date") & "', 102)"
        strSQL = strSQL & ", 0"
        strSQL = strSQL & ", " & WK_aka_kuro
        strSQL = strSQL & ", " & WK_dsp
        strSQL = strSQL & ", " & DtView1(i)("id") & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

    End Sub

    '******************************************************************
    '** エラー登録
    '******************************************************************
    Sub err_add()

        strSQL = "INSERT INTO err"
        strSQL = strSQL & " (txt_all_id, err_code, fin_f, wrn_no, line_no, delt_flg, close_date)"
        strSQL = strSQL & " VALUES (" & DtView1(i)("id") & ""
        strSQL = strSQL & ", '" & Err_code & "'"
        strSQL = strSQL & ", 0"
        strSQL = strSQL & ", '" & strDATA(1) & "'"
        strSQL = strSQL & ", '" & strDATA(2) & "'"
        strSQL = strSQL & ", 0"
        strSQL = strSQL & ", CONVERT(DATETIME, '" & close_date & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

    End Sub

    '******************************************************************
    '** 終了
    '******************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class
