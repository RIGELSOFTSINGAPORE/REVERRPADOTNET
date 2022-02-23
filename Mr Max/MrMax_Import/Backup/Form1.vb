Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   '進行状況フォームクラス 

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3, WK_DtView1 As DataView

    Dim strSQL, strSQL2, Err_F, CX_F As String
    Dim i, j, k, p, r, r1, r2, n, cnt, arr As Long
    Dim qty As Integer

    Dim filename, strData, dir As String
    Dim max_date As Date
    Dim ans As String
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button02 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button01 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button02 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button01 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button98)
        Me.GroupBox1.Controls.Add(Me.Button02)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button01)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(628, 104)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "データ取込"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.ForeColor = System.Drawing.Color.Black
        Me.Button98.Location = New System.Drawing.Point(480, 64)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(64, 32)
        Me.Button98.TabIndex = 3
        Me.Button98.Text = "戻し"
        '
        'Button02
        '
        Me.Button02.BackColor = System.Drawing.SystemColors.Control
        Me.Button02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button02.ForeColor = System.Drawing.Color.Black
        Me.Button02.Location = New System.Drawing.Point(24, 64)
        Me.Button02.Name = "Button02"
        Me.Button02.Size = New System.Drawing.Size(160, 32)
        Me.Button02.TabIndex = 2
        Me.Button02.Text = "取込み開始"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(24, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(540, 23)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Button01
        '
        Me.Button01.BackColor = System.Drawing.SystemColors.Control
        Me.Button01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button01.Location = New System.Drawing.Point(568, 32)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(48, 24)
        Me.Button01.TabIndex = 1
        Me.Button01.Text = "参照"
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(524, 472)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 12
        Me.Button99.Text = "終 了"
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(96, 12)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(72, 24)
        Me.Date1.TabIndex = 0
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2010, 2, 8, 12, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "処理年月"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(48, 164)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "エラーリスト(CSV)"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(196, 164)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 44)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "法人リスト(CSV)"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(48, 252)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(140, 44)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "法人選択"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(196, 252)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(140, 44)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "エラー修正"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(196, 304)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(140, 44)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "エラー修正　　　　(ｲﾚｷﾞｭﾗｰ)"
        Me.Button5.Visible = False
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(48, 372)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(140, 44)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "総括表(XLS)"
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(344, 252)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(140, 44)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "エラー修正　　　　(手入力)"
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Location = New System.Drawing.Point(48, 304)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(140, 44)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "5009:楽天除外"
        Me.Button8.Visible = False
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(48, 456)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(140, 44)
        Me.Button9.TabIndex = 11
        Me.Button9.Text = "登録"
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(492, 252)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(140, 44)
        Me.Button10.TabIndex = 8
        Me.Button10.Text = "機種登録"
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(344, 164)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(140, 44)
        Me.Button11.TabIndex = 122
        Me.Button11.Text = "OK リスト(CSV)"
        '
        'Button12
        '
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Location = New System.Drawing.Point(640, 252)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(140, 44)
        Me.Button12.TabIndex = 9
        Me.Button12.Text = "保証登録"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(798, 515)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MrMax"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DB_INIT()
        dir = System.IO.Directory.GetCurrentDirectory
        inz()   '**  初期処理

        'MsgBox("品種マスタを見て対象外の品種をエラーにする処理を加えたので結果確認する。")
    End Sub

    '*********************************************************************************
    '**  初期処理
    '*********************************************************************************
    Sub inz()

        '処理年月セット
        WK_DsList1.Clear()
        'SqlCmd1 = New SqlClient.SqlCommand("SELECT MAX(処理日) AS MAX処理日 FROM [02_売上データ]", cnsqlclient)
        SqlCmd1 = New SqlClient.SqlCommand("SELECT MAX(処理日) AS MAX処理日 FROM [01_取込データ]", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("sals"), "", "", DataViewRowState.CurrentRows)
        If Not IsDBNull(WK_DtView1(0)("MAX処理日")) Then
            max_date = WK_DtView1(0)("MAX処理日")
            Date1.Text = Format(DateAdd(DateInterval.Month, 1, max_date), "yyyy/MM")
        Else
            Date1.Text = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM")
        End If
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
            .Filter = _
            "エクセルファイル(*.xls)|*.xls"
            .FilterIndex = 2            'Filterプロパティの2つ目を表示
            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                TextBox1.Text = .FileName
            End If
        End With
    End Sub

    '*********************************************************************************
    '**  取込
    '*********************************************************************************
    Private Sub Button02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button02.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()
        'Err_F = "0"
        If Err_F = "0" Then
            System.Diagnostics.EventLog.WriteEntry("MrMAX Import START ", "インポート開始", System.Diagnostics.EventLogEntryType.Information)

            '進行状況ダイアログの初期化処理()
            waitDlg = New WaitDialog        '進行状況ダイアログ
            waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            waitDlg.ProgressMax = 0         '全体の処理件数を設定
            waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0       '最初の件数を設定
            Me.Enabled = False              'オーナーのフォームを無効にする
            waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "データをインポートしています。"
            Application.DoEvents()          'メッセージ処理を促して表示を更新する

            Call xls_import()   'エクセルインポート
            Call bunkatu()      '分割処理
            Call rb_chk()       '赤黒照合
            Call rb_chk2()      '赤データのみチェック
            Call wrn_chk()      '保証データ照合(PB以外)
            Call PB_chk1()      'PBデータ照合_変動
            Call PB_chk2()      'PBデータ照合_固定
            Call AC_Mach()      'エアコンマッチング
            Call CAT_Mach()     '品種エラーコード_付与
            Call wrn_fee_Mach() '保証料エラーコード_付与
            Call low_prc()      '小金額エラー
            Call err_F_upd()    'エラーフラグ=Nullを0に更新
            Call cat_err()      '品種エラー
            Call rakuten()      '楽天除外


            inz()   '**  初期処理
            System.Diagnostics.EventLog.WriteEntry("MrMAX Import END ", "インポート完了", System.Diagnostics.EventLogEntryType.Information)
            MsgBox("取り込み完了")
            waitDlg.Close()                 '進行状況ダイアログを閉じる
            Me.Enabled = True               'オーナーのフォームを有効にする
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub F_chk()
        Err_F = "0"

        If Date1.Number = 0 Then
            MsgBox("処理年月は入力必須です。", 16, "Error")    '× 1=ＯＫ
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If
        P_DATE = Date1.Text & "/01'"

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT 処理日 FROM [02_売上データ] WHERE (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("sals"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            MsgBox("処理年月は既に処理済みです。", 16, "Error")    '× 1=ＯＫ
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If

        TextBox1.Text = Trim(TextBox1.Text)
        If TextBox1.Text = Nothing Then
            MsgBox("取込データは入力必須です。", 16, "Error")    '× 1=ＯＫ
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

        If System.IO.File.Exists(TextBox1.Text) = False Then
            MsgBox("該当するファイルがありません。", 16, "Error")    '× 1=ＯＫ
            TextBox1.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    Sub F_chk2()
        Err_F = "0"

        If Date1.Number = 0 Then
            MsgBox("処理年月は入力必須です。", 16, "Error")    '× 1=ＯＫ
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If
        P_DATE = Date1.Text & "/01'"

        WK_DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("SELECT 処理日 FROM [02_売上データ] WHERE (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))", cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(WK_DsList1, "sals")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("sals"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count = 0 Then
            MsgBox("処理年月は未取込みです。", 16, "Error")    '× 1=ＯＫ
            Date1.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    Private Sub xls_import() 'エクセルインポート
        Dim fnm As String
        Dim rec(36) As String
        Dim exl As Object
        Dim xlRange As Excel.Range

        fnm = TextBox1.Text

        exl = CreateObject("Excel.Application")
        exl.Application.Visible = False
        exl.Application.Workbooks.Open(filename:=fnm)

        Dim a1, a2 As String

        For j = 2 To 65536
            xlRange = exl.cells(j, 1)
            a1 = xlRange.Value
            a2 = xlRange.Value
            If xlRange.Value = "" Then Exit For
        Next
        cnt = j - 2
        waitDlg.ProgressMax = cnt         ' 全体の処理件数を設定

        DB_OPEN()
        For j = 2 To 65536
            xlRange = exl.cells(j, 1)
            If xlRange.Value = "" Then Exit For

            waitDlg.ProgressMsg = Fix((j - 1) * 100 / cnt) & "%　（" & Format(j - 1, "##,##0") & " / " & Format(cnt, "##,##0") & " 件）"
            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            Array.Clear(rec, Nothing, rec.Length)
            For i = 1 To 36
                xlRange = exl.cells(j, i)
                rec(i) = xlRange.Value
            Next

            '2014/05/12 税区分対応 start
            '税区分が"1"（外税）の場合、発効日
            If rec(32) = "1" Then
                rec(32) = "5"       '税区分を内税に変更
                '税込金額に変更
                rec(30) = GetTaxPrice(rec(30), rec(2))      'マスタ単価
                rec(31) = GetTaxPrice(rec(31), rec(2))      '単価
                rec(35) = GetTaxPrice(rec(35), rec(2))      '値引額
                rec(36) = GetTaxPrice(rec(36), rec(2))      '単価2
            End If
            '2014/05/12 税区分対応 end

            strSQL = "INSERT INTO [01_取込データ]"
            strSQL += " (伝票NO, 発行日, 配送店ｺｰﾄﾞ, 一般売掛区分, 氏名, TEL1, TEL2, 郵便番号, 住所1, 住所2"
            strSQL += ", 住所3, 住所4, 住所5, 販売者ｺｰﾄﾞ, 完了日, 削除ﾌﾗｸﾞ, 行番号, 行区分, 商品ｺｰﾄﾞ, 品名ｶﾅ"
            strSQL += ", 型番ｶﾅ, ｶﾗｰ, ｻｲｽﾞ, ﾚｼｰﾄ, 品名漢字, 型番漢字, 分類ｺｰﾄﾞ, 品種ｺｰﾄﾞ, 売上数, ﾏｽﾀ単価"
            strSQL += ", 単価, 税区分, 値引割引区分, 割引率, 値引額, 単価2, 処理日)"
            strSQL += " SELECT '" & rec(1) & "' AS Expr1"       '伝票No.
            strSQL += ", '" & rec(2) & "' AS Expr2"     '発行日
            strSQL += ", " & rec(3) & " AS Expr3"       '配送店コード
            strSQL += ", '" & rec(4) & "' AS Expr4"     '一般売掛区分
            strSQL += ", '" & rec(5) & "' AS Expr5"     '氏名
            strSQL += ", '" & rec(6) & "' AS Expr6"     'TEL1
            strSQL += ", '" & rec(7) & "' AS Expr7"     'TEL2
            strSQL += ", '" & rec(8) & "' AS Expr8"     '郵便番号
            strSQL += ", '" & rec(9) & "' AS Expr9"     '住所1
            strSQL += ", '" & rec(10) & "' AS Expr10"       '住所2
            strSQL += ", '" & rec(11) & "' AS Expr11"       '住所3
            strSQL += ", '" & rec(12) & "' AS Expr12"       '住所4
            strSQL += ", '" & rec(13) & "' AS Expr13"       '住所5
            strSQL += ", '" & rec(14) & "' AS Expr14"       '販売者コード
            strSQL += ", '" & rec(15) & "' AS Expr15"       '完了日
            strSQL += ", '" & rec(16) & "' AS Expr16"       '削除フラグ
            strSQL += ", " & rec(17) & " AS Expr17"     '行番号
            strSQL += ", '" & rec(18) & "' AS Expr18"       '行区分

            WK_str = Trim(rec(19))
            If rec(27) = "30" Or rec(27) = "91" Then
                WK_str = WK_str.PadLeft(13, "0")
            End If
            strSQL += ", '" & WK_str & "' AS Expr19"        '商品コード

            strSQL += ", '" & rec(20) & "' AS Expr20"       '品名カナ
            strSQL += ", '" & rec(21) & "' AS Expr21"       '型番カナ
            strSQL += ", '" & rec(22) & "' AS Expr22"       'カラー
            strSQL += ", '" & rec(23) & "' AS Expr23"       'サイズ
            strSQL += ", '" & rec(24) & "' AS Expr24"       'レシート
            strSQL += ", '" & rec(25) & "' AS Expr25"       '品名漢字
            strSQL += ", '" & rec(26) & "' AS Expr26"       '型番漢字
            strSQL += ", '" & rec(27) & "' AS Expr27"       '分類コード
            strSQL += ", '" & rec(28) & "' AS Expr28"       '品種コード
            strSQL += ", " & rec(29) & " AS Expr29"     '売上数
            strSQL += ", " & rec(30) & " AS Expr30"     'マスタ単価
            strSQL += ", " & rec(31) & " AS Expr31"     '単価
            strSQL += ", '" & rec(32) & "' AS Expr32"       '税区分
            strSQL += ", '" & rec(33) & "' AS Expr33"       '値引割引区分
            strSQL += ", " & rec(34) & " AS Expr34"     '割引率
            strSQL += ", " & rec(35) & " AS Expr35"     '値引額
            strSQL += ", " & rec(36) & " AS Expr36"     '単価2
            strSQL += ", '" & P_DATE & "' AS Expr37"    '処理日
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        Next
        DB_CLOSE()

        exl.Application.DisplayAlerts = False
        exl.Application.Quit()
    End Sub

    Private Sub bunkatu() '分割処理
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_import01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "imp")
        DtView1 = New DataView(DsList1.Tables("imp"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ' 進行状況ダイアログの初期化処理
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "データを分解しています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                If DtView1(i)("売上数") < 0 Then qty = DtView1(i)("売上数") * -1 Else qty = DtView1(i)("売上数")
                For j = 1 To qty

                    strSQL = "INSERT INTO [02_売上データ]"
                    strSQL += " (伝票NO, 発行日, [配送店ｺｰﾄﾞ], 一般売掛区分, 氏名, TEL1, TEL2, 郵便番号, 住所1, 住所2"
                    strSQL += ", 住所3, 住所4, 住所5, [販売者ｺｰﾄﾞ], 完了日, [削除ﾌﾗｸﾞ], 行番号, 行区分, [商品ｺｰﾄﾞ], [品名ｶﾅ]"
                    strSQL += ", [型番ｶﾅ], [ｶﾗｰ], [ｻｲｽﾞ], [ﾚｼｰﾄ], 品名漢字, 型番漢字, [分類ｺｰﾄﾞ], [品種ｺｰﾄﾞ], 売上数, [ﾏｽﾀ単価]"
                    strSQL += ", 単価, 税区分, 値引割引区分, 割引率, 値引額, 単価2, 処理日, 処理日2, 分割数量, 分割元SEQ"
                    strSQL += ", 赤黒SEQ, sprice, WSEQ1, WSEQ2, 法人, dlt_f, wrn_add_f)"
                    WK_str = Trim(DtView1(i)("伝票NO")) : WK_str = WK_str.PadLeft(12, "0")
                    strSQL += " SELECT '" & WK_str & "' AS Expr1"
                    strSQL += ", '" & DtView1(i)("発行日") & "' AS Expr2"
                    WK_str = Trim(DtView1(i)("配送店ｺｰﾄﾞ")) : WK_str = WK_str.PadLeft(4, "0")
                    strSQL += ", '" & WK_str & "' AS Expr3"
                    strSQL += ", '" & DtView1(i)("一般売掛区分") & "' AS Expr4"
                    strSQL += ", '" & DtView1(i)("氏名") & "' AS Expr5"
                    strSQL += ", '" & DtView1(i)("TEL1") & "' AS Expr6"
                    strSQL += ", '" & DtView1(i)("TEL2") & "' AS Expr7"
                    strSQL += ", '" & DtView1(i)("郵便番号") & "' AS Expr8"
                    strSQL += ", '" & DtView1(i)("住所1") & "' AS Expr9"
                    strSQL += ", '" & DtView1(i)("住所2") & "' AS Expr10"
                    strSQL += ", '" & DtView1(i)("住所3") & "' AS Expr11"
                    strSQL += ", '" & DtView1(i)("住所4") & "' AS Expr12"
                    strSQL += ", '" & DtView1(i)("住所5") & "' AS Expr13"
                    strSQL += ", '" & DtView1(i)("販売者ｺｰﾄﾞ") & "' AS Expr14"
                    strSQL += ", '" & DtView1(i)("完了日") & "' AS Expr15"
                    strSQL += ", '" & DtView1(i)("削除ﾌﾗｸﾞ") & "' AS Expr16"
                    strSQL += ", " & DtView1(i)("行番号") & " AS Expr17"
                    strSQL += ", '" & DtView1(i)("行区分") & "' AS Expr18"
                    WK_str = Trim(DtView1(i)("商品ｺｰﾄﾞ")).PadLeft(13, "0")
                    strSQL += ", '" & WK_str & "' AS Expr19"
                    strSQL += ", '" & DtView1(i)("品名ｶﾅ") & "' AS Expr20"
                    strSQL += ", '" & DtView1(i)("型番ｶﾅ") & "' AS Expr21"
                    strSQL += ", '" & DtView1(i)("ｶﾗｰ") & "' AS Expr22"
                    strSQL += ", '" & DtView1(i)("ｻｲｽﾞ") & "' AS Expr23"
                    strSQL += ", '" & DtView1(i)("ﾚｼｰﾄ") & "' AS Expr24"
                    strSQL += ", '" & DtView1(i)("品名漢字") & "' AS Expr25"
                    strSQL += ", '" & DtView1(i)("型番漢字") & "' AS Expr26"
                    strSQL += ", '" & DtView1(i)("分類ｺｰﾄﾞ") & "' AS Expr27"
                    strSQL += ", '" & DtView1(i)("品種ｺｰﾄﾞ") & "' AS Expr28"
                    strSQL += ", " & DtView1(i)("売上数") & " AS Expr29"
                    strSQL += ", " & DtView1(i)("ﾏｽﾀ単価") & " AS Expr30"
                    strSQL += ", " & DtView1(i)("単価") & " AS Expr31"
                    strSQL += ", '" & DtView1(i)("税区分") & "' AS Expr32"
                    strSQL += ", '" & DtView1(i)("値引割引区分") & "' AS Expr33"
                    strSQL += ", " & DtView1(i)("割引率") & " AS Expr34"
                    strSQL += ", " & DtView1(i)("値引額") & " AS Expr35"
                    strSQL += ", " & DtView1(i)("単価2") & " AS Expr36"
                    strSQL += ", '" & DtView1(i)("処理日") & "' AS Expr19_2"
                    strSQL += ", '" & DtView1(i)("処理日") & "' AS Expr19_3"
                    If DtView1(i)("売上数") > 0 Then                         'QTY
                        strSQL += ", 1 AS Expr38"     '分割数量
                    Else
                        strSQL += ", -1 AS Expr38"
                    End If

                    Dim IntSEQ As Integer
                    Select Case j
                        Case Is = 1
                            strSQL += ", 0 AS Expr39" '分割元SEQ
                        Case Is = 2
                            WK_DsList1.Clear()
                            SqlCmd1 = New SqlClient.SqlCommand("SELECT * FROM V_MAX_SEQ", cnsqlclient)
                            DaList1.SelectCommand = SqlCmd1
                            SqlCmd1.CommandTimeout = 3600
                            DaList1.Fill(WK_DsList1, "MAX_SEQ")
                            WK_DtView1 = New DataView(WK_DsList1.Tables("MAX_SEQ"), "", "", DataViewRowState.CurrentRows)
                            IntSEQ = WK_DtView1(0)("MAX_SEQ")
                            strSQL += ", " & IntSEQ & " AS Expr39"
                        Case Is > 2
                            strSQL += ", " & IntSEQ & " AS Expr39"
                    End Select
                    strSQL += ", 0 AS Expr40"
                    strSQL += ", 0 AS Expr41"
                    strSQL += ", 0 AS Expr42"
                    strSQL += ", 0 AS Expr43"
                    strSQL += ", 0 AS Expr44"
                    strSQL += ", 0 AS Expr45"
                    strSQL += ", 0 AS Expr46"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                Next j
            Next i

            'MsgBox("分解完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()
    End Sub

    Private Sub rb_chk() '赤黒照合
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_rb_chk", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "rb_chk")
        DtView1 = New DataView(DsList1.Tables("rb_chk"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "赤黒照合しています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                '伝票番号,商品コード,単価2が一致する qty = 1のデータを検索
                WK_DsList1.Clear()
                strSQL = "SELECT SEQ FROM [02_売上データ]"
                strSQL += " WHERE (赤黒SEQ = 0)"
                strSQL += " AND (分割数量 = N'1')"
                strSQL += " AND (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (伝票NO = '" & DtView1(i)("伝票NO") & "')"
                strSQL += " AND ([商品ｺｰﾄﾞ] = '" & DtView1(i)("商品ｺｰﾄﾞ") & "')"
                strSQL += " AND (単価2 = " & DtView1(i)("単価2") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "rb_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("rb_chk2"), "", "SEQ", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then

                    strSQL = "UPDATE [02_売上データ]"
                    strSQL += " SET 赤黒SEQ = " & DtView1(i)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    strSQL = "UPDATE [02_売上データ]"
                    strSQL += " SET 赤黒SEQ = " & WK_DtView1(0)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                End If
            Next i

            'MsgBox("赤黒照合完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()

    End Sub

    Private Sub rb_chk2()   '赤データのみチェック
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_04", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_04")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_04"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ''進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "赤データのみチェックしています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strSQL = "UPDATE [02_売上データ]"
                strSQL += " SET ERR_F = '3'"
                strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next i

            'MsgBox("赤データのみチェック完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()
    End Sub

    Private Sub wrn_chk() '保証データ照合
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_wrn_chk", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "wrn_chk")
        DtView1 = New DataView(DsList1.Tables("wrn_chk"), "", "SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "保証データ照合しています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                '伝票番号と金額が一致する売上データを検索
                WK_DsList1.Clear()
                strSQL = "SELECT [02_売上データ].SEQ, [02_売上データ].単価2"
                strSQL += " FROM [02_売上データ] INNER JOIN"
                strSQL += " M08_KBN_CAT ON"
                strSQL += " [02_売上データ].[品種ｺｰﾄﾞ] = M08_KBN_CAT.CAT_CODE LEFT OUTER JOIN"
                strSQL += " [M07_PB_ﾏｯﾁﾝｸﾞ] ON"
                strSQL += " [02_売上データ].型番ｶﾅ = [M07_PB_ﾏｯﾁﾝｸﾞ].型番ｶﾅ"
                strSQL += " WHERE ([02_売上データ].伝票NO = '" & DtView1(i)("伝票NO") & "')"
                strSQL += " AND ([02_売上データ].赤黒SEQ = 0)"
                strSQL += " AND ([02_売上データ].分割数量 = " & DtView1(i)("分割数量") & ")"
                strSQL += " AND ([02_売上データ].処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (M08_KBN_CAT.KBN_CODE = '" & DtView1(i)("KBN_CODE") & "')"
                strSQL += " AND ([02_売上データ].[分類ｺｰﾄﾞ] <> '30')"
                strSQL += " AND ([02_売上データ].[分類ｺｰﾄﾞ] <> '91')"
                strSQL += " AND ([02_売上データ].WSEQ1 = 0)"
                strSQL += " AND ([02_売上データ].単価2 * 0.05 - " & DtView1(i)("単価2") & " <= 1)"
                strSQL += " AND ([02_売上データ].単価2 * 0.05 - " & DtView1(i)("単価2") & " >= - 1)"
                strSQL += " AND ([M07_PB_ﾏｯﾁﾝｸﾞ].固定 IS NULL OR [M07_PB_ﾏｯﾁﾝｸﾞ].固定 = '0')"
                'strSQL = "SELECT [02_売上データ].SEQ, [02_売上データ].単価2"
                'strSQL += " FROM [02_売上データ] INNER JOIN"
                'strSQL += " M08_KBN_CAT ON"
                'strSQL += " [02_売上データ].[品種ｺｰﾄﾞ] =  M08_KBN_CAT.CAT_CODE"
                'strSQL += " WHERE ([02_売上データ].伝票NO = '" & DtView1(i)("伝票NO") & "')"
                'strSQL += " AND ([02_売上データ].赤黒SEQ = 0)"
                'strSQL += " AND ([02_売上データ].分割数量 = " & DtView1(i)("分割数量") & ")"
                'strSQL += " AND ([02_売上データ].単価2 * 0.05 - " & DtView1(i)("単価2") & " <= 1 AND [02_売上データ].単価2 * 0.05 - " & DtView1(i)("単価2") & " >= - 1)"
                'strSQL += " AND ([02_売上データ].処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                'strSQL += " AND (M08_KBN_CAT.KBN_CODE = '" & DtView1(i)("KBN_CODE") & "')"
                'strSQL += " AND ([02_売上データ].[分類ｺｰﾄﾞ] <> '30')"
                'strSQL += " AND ([02_売上データ].[分類ｺｰﾄﾞ] <> '91')"
                'strSQL += " AND ([02_売上データ].WSEQ1 = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("wrn_chk2"), "", "SEQ", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then
                    For j = 0 To WK_DtView1.Count - 1

                        '一致した売上データのwSEQ1に保証データのSEQを記入､保証データのwSEQ1に売上データのSEQ､単価2を記入
                        strSQL = "UPDATE [02_売上データ]"
                        strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                        strSQL += " WHERE (SEQ = " & WK_DtView1(j)("SEQ") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                        strSQL = "UPDATE [02_売上データ]"
                        strSQL += " SET wSEQ1 = " & WK_DtView1(j)("SEQ") & ""
                        strSQL += ", sprice = " & WK_DtView1(j)("単価2") & ""
                        strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()

                        Exit For
                    Next j
                End If
            Next i

            'MsgBox("保証データ照合完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()
    End Sub

    Private Sub PB_chk1() 'PBデータ照合_変動
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_wrn_chk_PB_1", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "wrn_chk")
        DtView1 = New DataView(DsList1.Tables("wrn_chk"), "", "SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "PB（変動）保証データ照合しています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                '伝票番号が一致する保証データを検索
                WK_DsList1.Clear()
                strSQL = "SELECT 伝票NO, [商品ｺｰﾄﾞ], 品名ｶﾅ, 型番ｶﾅ, [分類ｺｰﾄﾞ], 単価2, SEQ, 赤黒SEQ, sprice, WSEQ1"
                strSQL += " FROM [02_売上データ]"
                strSQL += " WHERE (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (ERR_F IS NULL)"
                strSQL += " AND ([商品ｺｰﾄﾞ] = '0400000069814' OR [商品ｺｰﾄﾞ] = '0400000091419')"
                strSQL += " AND (伝票NO = '" & DtView1(i)("伝票NO") & "')"
                strSQL += " AND (赤黒SEQ = 0)"
                strSQL += " AND (WSEQ1 = 0)"
                strSQL += " AND ([分類ｺｰﾄﾞ] = '30' OR [分類ｺｰﾄﾞ] = '91')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("wrn_chk2"), "", "SEQ", DataViewRowState.CurrentRows)

                If WK_DtView1.Count <> 0 Then

                    '一致した売上データのwSEQ1に保証データのSEQを記入､保証データのwSEQ1に売上データのSEQ､単価2を記入
                    strSQL = "UPDATE [02_売上データ]"
                    strSQL += " SET wSEQ1 = " & WK_DtView1(0)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    strSQL = "UPDATE [02_売上データ]"
                    strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    strSQL += ", 単価2 = " & DtView1(i)("保証料") & ""
                    strSQL += ", sprice = " & DtView1(i)("単価2") & ""
                    strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                End If
            Next i

            'MsgBox("保証データ照合完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()
    End Sub

    Private Sub PB_chk2() 'PBデータ照合_固定
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_wrn_chk_PB_2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "wrn_chk")
        DtView1 = New DataView(DsList1.Tables("wrn_chk"), "", "SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            '進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "PB（固定）保証データ照合しています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                '伝票番号と商品ｺｰﾄﾞが一致する保証データを検索
                WK_DsList1.Clear()
                strSQL = "SELECT 伝票NO, [商品ｺｰﾄﾞ], 品名ｶﾅ, 型番ｶﾅ, [分類ｺｰﾄﾞ], 単価2, SEQ, 赤黒SEQ, sprice, WSEQ1"
                strSQL += " FROM [02_売上データ]"
                strSQL += " WHERE (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
                strSQL += " AND (ERR_F IS NULL)"
                strSQL += " AND ([商品ｺｰﾄﾞ] = '0400000069814' OR [商品ｺｰﾄﾞ] = '0400000091419')"
                strSQL += " AND (伝票NO = '" & DtView1(i)("伝票NO") & "')"
                strSQL += " AND (赤黒SEQ = 0)"
                strSQL += " AND (WSEQ1 = 0)"
                strSQL += " AND ([分類ｺｰﾄﾞ] = '30' OR [分類ｺｰﾄﾞ] = '91')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                DaList1.Fill(WK_DsList1, "wrn_chk2")
                WK_DtView1 = New DataView(WK_DsList1.Tables("wrn_chk2"), "", "SEQ", DataViewRowState.CurrentRows)

                If WK_DtView1.Count <> 0 Then

                    Dim a1, a2, a3 As String
                    a1 = DtView1(i)("PB単価2")

                    '一致した売上データのwSEQ1に保証データのSEQを記入､保証データのwSEQ1に売上データのSEQ､単価2を記入
                    strSQL = "UPDATE [02_売上データ]"
                    strSQL += " SET wSEQ1 = " & WK_DtView1(0)("SEQ") & ""
                    strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    If DtView1(i)("PB単価2") = 0 Then
                        strSQL = "UPDATE [02_売上データ]"
                        strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                        strSQL += ", 単価2 = " & DtView1(i)("保証料") & ""
                        strSQL += ", sprice = " & DtView1(i)("単価") & ""
                        strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    Else
                        If DtView1(i)("発行日") >= "20110310" Then
                            strSQL = "UPDATE [02_売上データ]"
                            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                            strSQL += ", 単価2 = " & DtView1(i)("PB保証料2") & ""
                            strSQL += ", sprice = " & DtView1(i)("PB単価2") & ""
                            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                        Else
                            strSQL = "UPDATE [02_売上データ]"
                            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                            strSQL += ", 単価2 = " & DtView1(i)("保証料") & ""
                            strSQL += ", sprice = " & DtView1(i)("単価") & ""
                            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                        End If
                    End If

                    ''イレギュラー処理
                    ''「LE-M22D210 W/B」で2011/03/10以降は保証料が1339円
                    'Select Case DtView1(i)("型番ｶﾅ")
                    '    Case Is = "LE-M22D210", "LE-M22D210 B", "LE-M22D210 W"
                    '        If DtView1(i)("発行日") >= "20110310" Then
                    '            strSQL = "UPDATE [02_売上データ]"
                    '            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    '            strSQL += ", 単価2 = 1339"
                    '            strSQL += ", sprice = 26780"
                    '            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    '            SqlCmd1.ExecuteNonQuery()
                    '        Else
                    '            strSQL = "UPDATE [02_売上データ]"
                    '            strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    '            strSQL += ", 単価2 = " & DtView1(i)("保証料") & ""
                    '            strSQL += ", sprice = " & DtView1(i)("単価") & ""
                    '            strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    '            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    '            SqlCmd1.ExecuteNonQuery()
                    '        End If
                    '    Case Else
                    '        strSQL = "UPDATE [02_売上データ]"
                    '        strSQL += " SET wSEQ1 = " & DtView1(i)("SEQ") & ""
                    '        strSQL += ", 単価2 = " & DtView1(i)("保証料") & ""
                    '        strSQL += ", sprice = " & DtView1(i)("単価") & ""
                    '        strSQL += " WHERE (SEQ = " & WK_DtView1(0)("SEQ") & ")"
                    '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    '        SqlCmd1.ExecuteNonQuery()
                    'End Select
                End If
            Next i

            'MsgBox("保証データ照合完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()
    End Sub

    Private Sub AC_Mach()   'エアコンマッチング
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_01", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r1 = DaList1.Fill(DsList1, "err_chk_01")
        If r1 <> 0 Then

            ''進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "エアコンマッチングしています。"
            waitDlg.ProgressMax = r1        ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()          'メッセージ処理を促して表示を更新する

            DtView1 = New DataView(DsList1.Tables("err_chk_01"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()      ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()       ' 処理カウントを1ステップ進める

                DsList2.Clear()
                SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_01_2", cnsqlclient)
                SqlCmd1.CommandType = CommandType.StoredProcedure
                Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
                Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 14)
                Pram2.Value = P_DATE
                Pram3.Value = DtView1(i)("伝票NO")
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                r2 = DaList1.Fill(DsList2, "err_chk_01_2")

                If r2 <> 0 Then
                    DtView2 = New DataView(DsList2.Tables("err_chk_01_2"), "", "", DataViewRowState.CurrentRows)
                    For j = 0 To DtView2.Count - 1
                        If DtView2(j)("flg") = "0" Then

                            For k = j + 1 To DtView2.Count - 1
                                If DtView2(k)("flg") = "0" Then

                                    If (DtView2(j)("単価2") + DtView2(k)("単価2")) * 0.05 - DtView1(i)("単価2") <= 1 _
                                        And (DtView2(j)("単価2") + DtView2(k)("単価2")) * 0.05 - DtView1(i)("単価2") >= -1 Then

                                        strSQL = "UPDATE [02_売上データ]"
                                        strSQL += " SET sprice = " & DtView2(j)("単価2") + DtView2(k)("単価2") & ""
                                        strSQL += ", WSEQ1 = " & DtView2(j)("SEQ") & ""
                                        strSQL += ", WSEQ2 = " & DtView2(k)("SEQ") & ""
                                        strSQL += ", ERR_F = '0'"
                                        strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()

                                        strSQL = "UPDATE [02_売上データ]"
                                        strSQL += " SET"
                                        strSQL += " WSEQ1 = " & DtView1(i)("SEQ")
                                        strSQL += " WHERE (SEQ = " & DtView2(j)("SEQ") & ")"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()

                                        strSQL = "UPDATE [02_売上データ]"
                                        strSQL += " SET"
                                        strSQL += " WSEQ2 = " & DtView1(i)("SEQ")
                                        strSQL += " WHERE (SEQ = " & DtView2(k)("SEQ") & ")"
                                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                                        SqlCmd1.ExecuteNonQuery()

                                        GoTo ex_for
                                    End If
                                    DtView2(k)("flg") = "1"
                                End If
                            Next
                            DtView2(j)("flg") = "1"
                        End If
                    Next
ex_for:
                End If
            Next i

            'MsgBox("エアコンマッチング完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()
    End Sub

    Private Sub CAT_Mach()   '品種エラーコード_付与
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_02", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_02")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_02"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ''進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "品種エラーコード_付与しています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strSQL = "UPDATE [02_売上データ]"
                strSQL += " SET ERR_F = '1'"
                strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next i

            'MsgBox("品種エラーコード_付与完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()

    End Sub

    Private Sub wrn_fee_Mach()   '保証料エラーコード_付与
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_03", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_03")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_03"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            ''進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            waitDlg.MainMsg = "保証料エラーコード_付与しています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strSQL = "UPDATE [02_売上データ]"
                strSQL += " SET ERR_F = '2'"
                strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next i

            'MsgBox("保証料エラーコード_付与完了")
            'waitDlg.Close()                 '進行状況ダイアログを閉じる
            'Me.Enabled = True               'オーナーのフォームを有効にする
        End If
        DB_CLOSE()
    End Sub

    Private Sub low_prc()       '金額が小さい
        DB_OPEN()

        '保証料<525 エラー
        strSQL = "UPDATE [02_売上データ]"
        strSQL += " SET ERR_F = '1'"
        'strSQL += " WHERE (処理日 = CONVERT(DATETIME, " & P_DATE & ", 102))"

        '*** 2014/02/06 日付パラメータにシングルクォーテーションを追加
        strSQL += " WHERE (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
        strSQL += " AND (分類ｺｰﾄﾞ = '91' OR 分類ｺｰﾄﾞ = '30')"
        strSQL += " AND (単価2 < 525)"
        strSQL += " AND (dlt_f = 0)"
        strSQL += " AND (ERR_F = '0' OR ERR_F IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        ''購入価格<10500 エラー
        'strSQL = "UPDATE [02_売上データ]"
        'strSQL += " SET ERR_F = '1'"
        'strSQL += " FROM [02_売上データ] INNER JOIN"
        'strSQL += " M_category ON [02_売上データ].品種ｺｰﾄﾞ = M_category.CAT_CODE"
        'strSQL += " WHERE ([02_売上データ].処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
        'strSQL += " AND ([02_売上データ].単価2 < 10500)"
        'strSQL += " AND ([02_売上データ].dlt_f = 0)"
        'strSQL += " AND ([02_売上データ].ERR_F = '0' OR [02_売上データ].ERR_F IS NULL)"
        'strSQL += " AND (M_category.CAT_CODE IS NOT NULL)"
        'strSQL += " AND ([02_売上データ].分類ｺｰﾄﾞ <> '30') AND ([02_売上データ].分類ｺｰﾄﾞ <> '91') AND ([02_売上データ].分類ｺｰﾄﾞ <> '7')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
    End Sub

    Private Sub err_F_upd()     'エラーフラグ=Nullを0に更新
        DB_OPEN()
        strSQL = "UPDATE [02_売上データ]"
        strSQL += " SET ERR_F = '0'"
        strSQL += " WHERE (ERR_F IS NULL) OR (ERR_F = '')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub

    Private Sub cat_err()      '品種エラー
        DB_OPEN()

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_chk_05", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_chk_05")
        DtView1 = New DataView(DsList1.Tables("sp_err_chk_05"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            waitDlg.MainMsg = "品種のチェックしています。"
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           '最初の件数を設定
            Application.DoEvents()              'メッセージ処理を促して表示を更新する

            Dim wk_err As String
            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                wk_err = "0"
                If IsDBNull(DtView1(i)("avlbty")) = True Then
                    wk_err = "1"
                Else
                    If DtView1(i)("avlbty") = "false" Then
                        wk_err = "1"
                    End If
                End If

                If wk_err = "1" Then
                    'strSQL = "UPDATE [02_売上データ]"
                    'strSQL += " SET ERR_F = '4'"
                    'strSQL += " WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    'SqlCmd1.ExecuteNonQuery()

                    If DtView1(i)("WSEQ1") <> "0" Then
                        strSQL = "UPDATE [02_売上データ]"
                        strSQL += " SET ERR_F = '4'"
                        strSQL += " WHERE (SEQ = " & DtView1(i)("WSEQ1") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If

                    If DtView1(i)("WSEQ2") <> "0" Then
                        strSQL = "UPDATE [02_売上データ]"
                        strSQL += " SET ERR_F = '4'"
                        strSQL += " WHERE (SEQ = " & DtView1(i)("WSEQ2") & ")"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If
                End If
            Next i

        End If
        DB_CLOSE()
    End Sub

    Private Sub rakuten()       '楽天除外
        DB_OPEN()
        strSQL = "UPDATE [02_売上データ]"
        strSQL += " SET dlt_f = 1"
        strSQL += " WHERE (配送店ｺｰﾄﾞ = '5009')"
        strSQL += " AND (dlt_f = 0)"
        strSQL += " AND (処理日2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
    End Sub
    '*********************************************************************************
    '**  戻し
    '*********************************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        If Date1.Text <> Format(max_date, "yyyy/MM") Then
            MsgBox("最後の取り込み以外は戻せません。")
            Date1.Focus()
            Exit Sub
        End If

        ans = MsgBox(Date1.Text & " のデータを削除します。", MsgBoxStyle.OKCancel)
        If ans = "2" Then Exit Sub 'Cancel

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()

        strSQL = "DELETE FROM [01_取込データ]"
        strSQL += " WHERE (処理日 = CONVERT(DATETIME, '" & Date1.Text & "/01', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DELETE FROM [02_売上データ]"
        strSQL += " WHERE (処理日 = CONVERT(DATETIME, '" & Date1.Text & "/01', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()

        inz()   '**  初期処理
        MsgBox("取り込み完了")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  終了
    '*********************************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        Application.Exit()
    End Sub

    '*********************************************************************************
    '**  エラーリスト(CSV)
    '*********************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()
        P_DATE = Date1.Text & "/01'"

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_err_list", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_err_list")
        DtView1 = New DataView(DsList1.Tables("sp_err_list"), "", "伝票NO, SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "エラーチェックリスト_" & Format(P_DATE, "yyyyMM") & ".CSV"     'はじめのファイル名を指定する
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
                filename = sfd.FileName   'OKボタンがクリックされたとき

                '進行状況ダイアログの初期化処理()
                waitDlg = New WaitDialog        '進行状況ダイアログ
                waitDlg.Owner = Me              'ダイアログのオーナーを設定する
                waitDlg.ProgressMax = 0         '全体の処理件数を設定
                waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       '最初の件数を設定
                Me.Enabled = False              'オーナーのフォームを無効にする
                waitDlg.Show()                  '進行状況ダイアログを表示する
                waitDlg.MainMsg = "エラーリスト出力中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                Dim swFile As New System.IO.StreamWriter(filename, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

                'データを書き込む
                strData = "伝票NO,発行日,配送店コード,一般売掛区分,氏名,TEL1,TEL2,郵便番号,住所1,住所2,住所3,住所4,住所5"
                strData = strData & ",販売者コード,完了日,削除フラグ,行番号,行区分,商品コード,品名カナ,型番カナ,カラー,サイズ"
                strData = strData & ",レシート,品名漢字,型番漢字,分類コード,品種コード,売上数,マスタ単価,単価,税区分,値引割引区分"
                strData = strData & ",割引率,値引額,単価2,qty,SEQ,SEQ1,rbSEQ,sprice,wSEQ,wSEQ2,err,biz,処理方法"
                swFile.WriteLine(strData)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    strData = DtView1(i)("伝票NO")
                    strData = strData & "," & DtView1(i)("発行日")
                    strData = strData & "," & DtView1(i)("配送店ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("一般売掛区分")
                    strData = strData & "," & DtView1(i)("氏名")
                    strData = strData & "," & DtView1(i)("TEL1")
                    strData = strData & "," & DtView1(i)("TEL2")
                    strData = strData & "," & DtView1(i)("郵便番号")
                    strData = strData & "," & DtView1(i)("住所1")
                    strData = strData & "," & DtView1(i)("住所2")
                    strData = strData & "," & DtView1(i)("住所3")
                    strData = strData & "," & DtView1(i)("住所4")
                    strData = strData & "," & DtView1(i)("住所5")
                    strData = strData & "," & DtView1(i)("販売者ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("完了日")
                    strData = strData & "," & DtView1(i)("削除ﾌﾗｸﾞ")
                    strData = strData & "," & DtView1(i)("行番号")
                    strData = strData & "," & DtView1(i)("行区分")
                    strData = strData & "," & DtView1(i)("商品ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("品名ｶﾅ")
                    strData = strData & "," & DtView1(i)("型番ｶﾅ")
                    strData = strData & "," & DtView1(i)("ｶﾗｰ")
                    strData = strData & "," & DtView1(i)("ｻｲｽﾞ")
                    strData = strData & "," & DtView1(i)("ﾚｼｰﾄ")
                    strData = strData & "," & DtView1(i)("品名漢字")
                    strData = strData & "," & DtView1(i)("型番漢字")
                    strData = strData & "," & DtView1(i)("分類ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("品種ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("売上数")
                    strData = strData & "," & DtView1(i)("ﾏｽﾀ単価")
                    strData = strData & "," & DtView1(i)("単価")
                    strData = strData & "," & DtView1(i)("税区分")
                    strData = strData & "," & DtView1(i)("値引割引区分")
                    strData = strData & "," & DtView1(i)("割引率")
                    strData = strData & "," & DtView1(i)("値引額")
                    strData = strData & "," & DtView1(i)("単価2")
                    strData = strData & "," & DtView1(i)("分割数量")
                    strData = strData & "," & DtView1(i)("SEQ")
                    strData = strData & "," & DtView1(i)("分割元SEQ")
                    strData = strData & "," & DtView1(i)("赤黒SEQ")
                    strData = strData & "," & DtView1(i)("sprice")
                    strData = strData & "," & DtView1(i)("WSEQ1")
                    strData = strData & "," & DtView1(i)("WSEQ2")
                    strData = strData & "," & DtView1(i)("ERR_F")
                    strData = strData & "," & DtView1(i)("法人")
                    swFile.WriteLine(strData)

                Next i

                swFile.Close()          'ファイルを閉じる
                MsgBox("エラーリスト出力完了")
                waitDlg.Close()                 '進行状況ダイアログを閉じる
                Me.Enabled = True               'オーナーのフォームを有効にする
            End If
        End If
        DB_CLOSE()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  OK リスト(CSV)
    '*********************************************************************************
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()
        P_DATE = Date1.Text & "/01'"

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_ok_list", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 7200
        DaList1.Fill(DsList1, "sp_err_list")
        DtView1 = New DataView(DsList1.Tables("sp_err_list"), "", "伝票NO, SEQ", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "ＯＫリスト_" & Format(P_DATE, "yyyyMM") & ".CSV"     'はじめのファイル名を指定する
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
                filename = sfd.FileName   'OKボタンがクリックされたとき

                '進行状況ダイアログの初期化処理()
                waitDlg = New WaitDialog        '進行状況ダイアログ
                waitDlg.Owner = Me              'ダイアログのオーナーを設定する
                waitDlg.ProgressMax = 0         '全体の処理件数を設定
                waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       '最初の件数を設定
                Me.Enabled = False              'オーナーのフォームを無効にする
                waitDlg.Show()                  '進行状況ダイアログを表示する
                waitDlg.MainMsg = "ＯＫリスト出力中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                Dim swFile As New System.IO.StreamWriter(filename, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

                'データを書き込む
                strData = "伝票NO,発行日,配送店コード,一般売掛区分,氏名,TEL1,TEL2,郵便番号,住所1,住所2,住所3,住所4,住所5"
                strData = strData & ",販売者コード,完了日,削除フラグ,行番号,行区分,商品コード,品名カナ,型番カナ,カラー,サイズ"
                strData = strData & ",レシート,品名漢字,型番漢字,分類コード,品種コード,売上数,マスタ単価,単価,税区分,値引割引区分"
                strData = strData & ",割引率,値引額,単価2,qty,SEQ,SEQ1,rbSEQ,sprice,wSEQ,wSEQ2,err,biz,処理方法"
                swFile.WriteLine(strData)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    strData = DtView1(i)("伝票NO")
                    strData = strData & "," & DtView1(i)("発行日")
                    strData = strData & "," & DtView1(i)("配送店ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("一般売掛区分")
                    strData = strData & "," & DtView1(i)("氏名")
                    strData = strData & "," & DtView1(i)("TEL1")
                    strData = strData & "," & DtView1(i)("TEL2")
                    strData = strData & "," & DtView1(i)("郵便番号")
                    strData = strData & "," & DtView1(i)("住所1")
                    strData = strData & "," & DtView1(i)("住所2")
                    strData = strData & "," & DtView1(i)("住所3")
                    strData = strData & "," & DtView1(i)("住所4")
                    strData = strData & "," & DtView1(i)("住所5")
                    strData = strData & "," & DtView1(i)("販売者ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("完了日")
                    strData = strData & "," & DtView1(i)("削除ﾌﾗｸﾞ")
                    strData = strData & "," & DtView1(i)("行番号")
                    strData = strData & "," & DtView1(i)("行区分")
                    strData = strData & "," & DtView1(i)("商品ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("品名ｶﾅ")
                    strData = strData & "," & DtView1(i)("型番ｶﾅ")
                    strData = strData & "," & DtView1(i)("ｶﾗｰ")
                    strData = strData & "," & DtView1(i)("ｻｲｽﾞ")
                    strData = strData & "," & DtView1(i)("ﾚｼｰﾄ")
                    strData = strData & "," & DtView1(i)("品名漢字")
                    strData = strData & "," & DtView1(i)("型番漢字")
                    strData = strData & "," & DtView1(i)("分類ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("品種ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("売上数")
                    strData = strData & "," & DtView1(i)("ﾏｽﾀ単価")
                    strData = strData & "," & DtView1(i)("単価")
                    strData = strData & "," & DtView1(i)("税区分")
                    strData = strData & "," & DtView1(i)("値引割引区分")
                    strData = strData & "," & DtView1(i)("割引率")
                    strData = strData & "," & DtView1(i)("値引額")
                    strData = strData & "," & DtView1(i)("単価2")
                    strData = strData & "," & DtView1(i)("分割数量")
                    strData = strData & "," & DtView1(i)("SEQ")
                    strData = strData & "," & DtView1(i)("分割元SEQ")
                    strData = strData & "," & DtView1(i)("赤黒SEQ")
                    strData = strData & "," & DtView1(i)("sprice")
                    strData = strData & "," & DtView1(i)("WSEQ1")
                    strData = strData & "," & DtView1(i)("WSEQ2")
                    strData = strData & "," & DtView1(i)("ERR_F")
                    strData = strData & "," & DtView1(i)("法人")
                    swFile.WriteLine(strData)

                Next i

                swFile.Close()          'ファイルを閉じる
                MsgBox("ＯＫリスト出力完了")
                waitDlg.Close()                 '進行状況ダイアログを閉じる
                Me.Enabled = True               'オーナーのフォームを有効にする
            End If
        End If
        DB_CLOSE()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  法人リスト(CSV)
    '*********************************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DB_OPEN()
        P_DATE = Date1.Text & "/01'"

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_biz_list", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Pram1.Value = P_DATE
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        DaList1.Fill(DsList1, "sp_biz_list")
        DtView1 = New DataView(DsList1.Tables("sp_biz_list"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "法人チェックリスト_" & Format(P_DATE, "yyyyMM") & ".CSV"    'はじめのファイル名を指定する
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
                filename = sfd.FileName   'OKボタンがクリックされたとき

                '進行状況ダイアログの初期化処理()
                waitDlg = New WaitDialog        '進行状況ダイアログ
                waitDlg.Owner = Me              'ダイアログのオーナーを設定する
                waitDlg.ProgressMax = 0         '全体の処理件数を設定
                waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       '最初の件数を設定
                Me.Enabled = False              'オーナーのフォームを無効にする
                waitDlg.Show()                  '進行状況ダイアログを表示する
                waitDlg.MainMsg = "法人リスト出力中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                Dim swFile As New System.IO.StreamWriter(filename, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

                'データを書き込む
                strData = "法人=1,伝票NO,発行日,配送店コード,一般売掛区分,氏名,TEL1,TEL2,郵便番号,住所1,住所2,住所3,住所4,住所5"
                strData = strData & ",販売者コード,完了日,削除フラグ,行番号,行区分,商品コード,品名カナ,型番カナ,カラー,サイズ"
                strData = strData & ",レシート,品名漢字,型番漢字,分類コード,品種コード,売上数,マスタ単価,単価,税区分,値引割引区分"
                strData = strData & ",割引率,値引額,単価2,qty,SEQ,SEQ1,rbSEQ,sprice,wSEQ,wSEQ2,err,biz"
                swFile.WriteLine(strData)

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    strData = ""
                    strData = strData & "," & DtView1(i)("伝票NO")
                    strData = strData & "," & DtView1(i)("発行日")
                    strData = strData & "," & DtView1(i)("配送店ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("一般売掛区分")
                    strData = strData & "," & DtView1(i)("氏名")
                    strData = strData & "," & DtView1(i)("TEL1")
                    strData = strData & "," & DtView1(i)("TEL2")
                    strData = strData & "," & DtView1(i)("郵便番号")
                    strData = strData & "," & DtView1(i)("住所1")
                    strData = strData & "," & DtView1(i)("住所2")
                    strData = strData & "," & DtView1(i)("住所3")
                    strData = strData & "," & DtView1(i)("住所4")
                    strData = strData & "," & DtView1(i)("住所5")
                    strData = strData & "," & DtView1(i)("販売者ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("完了日")
                    strData = strData & "," & DtView1(i)("削除ﾌﾗｸﾞ")
                    strData = strData & "," & DtView1(i)("行番号")
                    strData = strData & "," & DtView1(i)("行区分")
                    strData = strData & "," & DtView1(i)("商品ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("品名ｶﾅ")
                    strData = strData & "," & DtView1(i)("型番ｶﾅ")
                    strData = strData & "," & DtView1(i)("ｶﾗｰ")
                    strData = strData & "," & DtView1(i)("ｻｲｽﾞ")
                    strData = strData & "," & DtView1(i)("ﾚｼｰﾄ")
                    strData = strData & "," & DtView1(i)("品名漢字")
                    strData = strData & "," & DtView1(i)("型番漢字")
                    strData = strData & "," & DtView1(i)("分類ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("品種ｺｰﾄﾞ")
                    strData = strData & "," & DtView1(i)("売上数")
                    strData = strData & "," & DtView1(i)("ﾏｽﾀ単価")
                    strData = strData & "," & DtView1(i)("単価")
                    strData = strData & "," & DtView1(i)("税区分")
                    strData = strData & "," & DtView1(i)("値引割引区分")
                    strData = strData & "," & DtView1(i)("割引率")
                    strData = strData & "," & DtView1(i)("値引額")
                    strData = strData & "," & DtView1(i)("単価2")
                    strData = strData & "," & DtView1(i)("分割数量")
                    strData = strData & "," & DtView1(i)("SEQ")
                    strData = strData & "," & DtView1(i)("分割元SEQ")
                    strData = strData & "," & DtView1(i)("赤黒SEQ")
                    strData = strData & "," & DtView1(i)("sprice")
                    strData = strData & "," & DtView1(i)("WSEQ1")
                    strData = strData & "," & DtView1(i)("WSEQ2")
                    strData = strData & "," & DtView1(i)("ERR_F")
                    strData = strData & "," & DtView1(i)("法人")
                    swFile.WriteLine(strData)

                Next i

                swFile.Close()          'ファイルを閉じる
                MsgBox("法人リスト出力完了")
                waitDlg.Close()                 '進行状況ダイアログを閉じる
                Me.Enabled = True               'オーナーのフォームを有効にする
            End If
        End If
        DB_CLOSE()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '*********************************************************************************
    '**  法人選択
    '*********************************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        F_chk2()
        If Err_F = "0" Then
            Dim Form2 As New Form2
            Form2.ShowDialog()
        End If
    End Sub

    '*********************************************************************************
    '**  エラー修正
    '*********************************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        F_chk2()
        If Err_F = "0" Then
            P_PRAM = "通常"
            Dim Form3 As New Form3
            Form3.ShowDialog()
        End If
    End Sub

    ''*********************************************************************************
    ''**  エラー修正(ｲﾚｷﾞｭﾗｰ)
    ''*********************************************************************************
    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    F_chk2()
    '    If Err_F = "0" Then
    '        P_PRAM = "ｲﾚｷﾞｭﾗｰ"
    '        Dim Form3 As New Form3
    '        Form3.ShowDialog()
    '    End If
    'End Sub

    '*********************************************************************************
    '**  エラー修正(手入力)
    '*********************************************************************************
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Form4 As New Form4
        Form4.ShowDialog()
    End Sub

    '*********************************************************************************
    '**  機種登録
    '*********************************************************************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        F_chk2()
        If Err_F = "0" Then
            Dim Form5 As New Form5
            Form5.ShowDialog()
        End If
    End Sub

    '*********************************************************************************
    '**  保証登録
    '*********************************************************************************
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        F_chk2()
        If Err_F = "0" Then
            Dim Form6 As New Form6
            Form6.ShowDialog()
        End If
    End Sub

    ''*********************************************************************************
    ''**  楽天除外
    ''*********************************************************************************
    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
    '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '    F_chk2()
    '    If Err_F = "0" Then

    '        strSQL = "UPDATE [02_売上データ]"
    '        strSQL += " SET dlt_f = 1"
    '        strSQL += " WHERE (配送店ｺｰﾄﾞ = 5009)"
    '        strSQL += " AND (dlt_f = 0)"
    '        strSQL += " AND (処理日2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
    '        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
    '        DB_OPEN()
    '        SqlCmd1.ExecuteNonQuery()
    '        DB_CLOSE()

    '        MsgBox("楽天除外完了")
    '    End If
    '    Me.Cursor = System.Windows.Forms.Cursors.Default
    'End Sub

    '*********************************************************************************
    '**  総括表出力
    '*********************************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        On Error GoTo err_prc
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim BR_Key As String

        F_chk2()
        If Err_F = "0" Then
            DB_OPEN()

            '集計区分クリア
            strSQL = "UPDATE [02_売上データ] SET 集計区分 = NULL WHERE (集計区分 IS NOT NULL) AND (処理日2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '集計区分(biz)
            strSQL = "UPDATE [02_売上データ]"
            strSQL += " SET 集計区分 = 'biz'"
            strSQL += " WHERE (集計区分 IS NULL)"
            strSQL += " AND (処理日 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            strSQL += " AND ((分類ｺｰﾄﾞ = '30') OR (分類ｺｰﾄﾞ = '91'))"
            strSQL += " AND (法人 = 1)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '集計区分(rb)
            strSQL = "UPDATE [02_売上データ]"
            strSQL += " SET 集計区分 = 'rb'"
            strSQL += " WHERE (集計区分 IS NULL)"
            strSQL += " AND (処理日2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            strSQL += " AND ((分類ｺｰﾄﾞ = '30') OR (分類ｺｰﾄﾞ = '91'))"
            strSQL += " AND (赤黒SEQ <> 0)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '集計区分(err)
            strSQL = "UPDATE [02_売上データ]"
            strSQL += " SET 集計区分 = 'err'"
            strSQL += " WHERE (集計区分 IS NULL)"
            strSQL += " AND (処理日2 = CONVERT(DATETIME, '" & P_DATE & "', 102))"
            strSQL += " AND ((分類ｺｰﾄﾞ = '30') OR (分類ｺｰﾄﾞ = '91'))"
            strSQL += " AND (ERR_F <> '0')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            '==================  起動時の処理  ===================  
            Dim xlApp As New Excel.Application
            Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
            '既存のファイルを開く場合
            Dim xlFilePath As String = dir & "\総括表.xls"
            Dim xlBook As Excel.Workbook = xlBooks.Open(xlFilePath)
            Dim xlSheets As Excel.Sheets = xlBook.Worksheets
            Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
            xlApp.Visible = False

            '*****************************
            '** Max件数検証シート
            '*****************************
            '==============
            ' 2015/07/08　件数検証シートは業務上未使用
            ' 品種追加時にエラーが発生するためコメントアウト
            '==============

            '==================  データの入力処理  ==================  
            'xlSheet = xlSheets.Item(1)  'Sheet1
            'Dim xlRange As Excel.Range
            'Dim strDat(18, 7) As Object
            'xlRange = xlSheet.Range("C4:I21")    'データの入力セル範囲

            'DsList1.Clear()
            'SqlCmd1 = New SqlClient.SqlCommand("sp_glist_cnt", cnsqlclient)
            'SqlCmd1.CommandType = CommandType.StoredProcedure
            'Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            'Pram1.Value = P_DATE
            'DaList1.SelectCommand = SqlCmd1
            'SqlCmd1.CommandTimeout = 3600
            'DaList1.Fill(DsList1, "sp_glist_cnt")
            'DtView1 = New DataView(DsList1.Tables("sp_glist_cnt"), "", "", DataViewRowState.CurrentRows)
            'If DtView1.Count <> 0 Then

            '進行状況ダイアログの初期化処理()
            'waitDlg = New WaitDialog        '進行状況ダイアログ
            'waitDlg.Owner = Me              'ダイアログのオーナーを設定する
            'waitDlg.ProgressMax = 0         '全体の処理件数を設定
            'waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
            'waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
            'waitDlg.ProgressValue = 0       '最初の件数を設定
            'Me.Enabled = False              'オーナーのフォームを無効にする
            'waitDlg.Show()                  '進行状況ダイアログを表示する
            'waitDlg.MainMsg = "件数検証抽出中"
            'waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            'Application.DoEvents()              'メッセージ処理を促して表示を更新する

            'BR_Key = DtView1(0)("cls_code_name")
            'p = 0

            'For i = 0 To DtView1.Count - 1
            'If IsDBNull(DtView1(i)("受信件数")) = True Then DtView1(i)("受信件数") = 0
            'If IsDBNull(DtView1(i)("分解件数")) = True Then DtView1(i)("分解件数") = 0
            'If IsDBNull(DtView1(i)("移動件数1")) = True Then DtView1(i)("移動件数1") = 0
            'If IsDBNull(DtView1(i)("移動件数2")) = True Then DtView1(i)("移動件数2") = 0
            'If IsDBNull(DtView1(i)("赤黒件数")) = True Then DtView1(i)("赤黒件数") = 0
            'If IsDBNull(DtView1(i)("err件数")) = True Then DtView1(i)("err件数") = 0
            'If IsDBNull(DtView1(i)("err処理件数")) = True Then DtView1(i)("err処理件数") = 0
            'DtView1(i)("移動件数1") = DtView1(i)("移動件数1") - DtView1(i)("移動件数2")

            'waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
            'Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            'waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            'If BR_Key <> DtView1(i)("cls_code_name") Then
            'j = i + p
            'strDat(j, 0) = "=SUM(C" & j + 3 & ":C" & j + 2 & ")"
            'strDat(j, 1) = "=SUM(D" & j + 3 & ":D" & j + 2 & ")"
            'strDat(j, 2) = "=SUM(E" & j + 3 & ":E" & j + 2 & ")"
            'strDat(j, 3) = "=D" & j + 4 & "+E" & j + 4
            'strDat(j, 4) = "=SUM(G" & j + 3 & ":G" & j + 2 & ")"
            'strDat(j, 5) = "=SUM(H" & j + 3 & ":H" & j + 2 & ")"
            'strDat(j, 6) = "=SUM(I" & j + 3 & ":I" & j + 2 & ")"
            'strDat(j, 7) = "=F" & j + 4 & "-G" & j + 4 & "-H" & j + 4 & "+I" & j + 4

            'BR_Key = DtView1(i)("cls_code_name")
            'p = p + 2
            'End If

            'j = i + p
            'strDat(j, 0) = DtView1(i)("受信件数")
            'strDat(j, 1) = DtView1(i)("分解件数")
            'strDat(j, 2) = DtView1(i)("移動件数1")
            'strDat(j, 3) = "=D" & j + 4 & "+E" & j + 4
            'strDat(j, 4) = DtView1(i)("赤黒件数")
            'strDat(j, 5) = DtView1(i)("err件数")
            'strDat(j, 6) = DtView1(i)("err処理件数")
            'strDat(j, 7) = "=F" & j + 4 & "-G" & j + 4 & "-H" & j + 4 & "+I" & j + 4

            'Next
            'j = i + p
            'strDat(j, 0) = "=SUM(C" & j + 3 & ":C" & j + 2 & ")"
            'strDat(j, 1) = "=SUM(D" & j + 3 & ":D" & j + 2 & ")"
            'strDat(j, 2) = "=SUM(E" & j + 3 & ":E" & j + 2 & ")"
            'strDat(j, 3) = "=D" & j + 4 & "+E" & j + 4
            'strDat(j, 4) = "=SUM(G" & j + 3 & ":G" & j + 2 & ")"
            'strDat(j, 5) = "=SUM(H" & j + 3 & ":H" & j + 2 & ")"
            'strDat(j, 6) = "=SUM(I" & j + 3 & ":I" & j + 2 & ")"
            'strDat(j, 7) = "=F" & j + 4 & "-G" & j + 4 & "-H" & j + 4 & "+I" & j + 4
            'End If
            'xlRange.Value = strDat          'セルへデータの入力
            'MRComObject(xlRange)            'xlRange の解放

            '*****************************
            '** 総括表
            '*****************************
            '==================  データの入力処理  ==================  
            xlSheet = xlSheets.Item(2)  'Sheet2
            Dim xlRange2 As Excel.Range
            Dim strDat2(999, 9) As Object
            xlRange2 = xlSheet.Range("A2:I1000")    'データの入力セル範囲
            Dim xlCells2 As Excel.Range
            Dim xlRange2_2 As Excel.Range

            strSQL = "DELETE W01_総括表"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_glist_W", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram2.Value = P_DATE
            SqlCmd1.CommandTimeout = 1800
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE  W01_総括表 SET 値引前sprice = [02_売上データ].単価2"
            strSQL += " FROM  W01_総括表 INNER JOIN"
            strSQL += " [02_売上データ] ON W01_総括表.SEQ = [02_売上データ].WSEQ1 INNER JOIN"
            strSQL += " V_PB固定 ON [02_売上データ].型番ｶﾅ = V_PB固定.型番ｶﾅ"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE W01_総括表 SET 値引前sprice = 商品価格 WHERE (値引前sprice IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_glist", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(DsList1, "sp_glist_glist")
            DtView1 = New DataView(DsList1.Tables("sp_glist_glist"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                '進行状況ダイアログの初期化処理()
                waitDlg = New WaitDialog        '進行状況ダイアログ
                waitDlg.Owner = Me              'ダイアログのオーナーを設定する
                waitDlg.ProgressMax = 0         '全体の処理件数を設定
                waitDlg.ProgressMin = 0         '処理件数の最小値を設定（0件から開始）
                waitDlg.ProgressStep = 1        '何件ごとにメータを進めるかを設定
                waitDlg.ProgressValue = 0       '最初の件数を設定
                Me.Enabled = False              'オーナーのフォームを無効にする
                waitDlg.Show()                  '進行状況ダイアログを表示する
                waitDlg.MainMsg = "総括表抽出中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    j = i
                    strDat2(j, 0) = DtView1(i)("店舗コード")
                    strDat2(j, 1) = DtView1(i)("店舗名")
                    strDat2(j, 2) = DtView1(i)("商品名")
                    strDat2(j, 3) = DtView1(i)("件数")
                    strDat2(j, 4) = DtView1(i)("商品価格")
                    strDat2(j, 5) = DtView1(i)("保証料")
                    strDat2(j, 6) = DtView1(i)("販売手数料")
                    strDat2(j, 7) = DtView1(i)("RDよりご請求額")
                    strDat2(j, 8) = DtView1(i)("事務委託料")
                Next
                j = j + 1
                strDat2(j, 3) = "=SUM(D2:D" & i + 1 & ")"
                strDat2(j, 4) = "=SUM(E2:E" & i + 1 & ")"
                strDat2(j, 5) = "=SUM(F2:F" & i + 1 & ")"
                strDat2(j, 6) = "=SUM(G2:G" & i + 1 & ")"
                strDat2(j, 7) = "=SUM(H2:H" & i + 1 & ")"
                strDat2(j, 8) = "=SUM(I2:I" & i + 1 & ")"

                j = j + 2
                xlCells2 = xlSheet.Cells
                xlRange2_2 = xlCells2(j, 4) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 5) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 6) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 7) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 8) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
                xlRange2_2 = xlCells2(j, 9) : xlRange2_2.Interior.Color = RGB(0, 255, 255)
            End If
            xlRange2.Value = strDat2            'セルへデータの入力
            MRComObject(xlRange2)               'xlRange の解放
            MRComObject(xlRange2_2)             'xlRange の解放

            '*****************************
            '** 明細
            '*****************************
            '==================  データの入力処理  ==================  
            xlSheet = xlSheets.Item(3)  'Sheet3
            Dim xlRange3 As Excel.Range
            Dim strDat3(49999, 43) As Object
            xlRange3 = xlSheet.Range("A2:AR50000")    'データの入力セル範囲

            strSQL = "DELETE W02_明細"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_dtl_W", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram3.Value = P_DATE
            SqlCmd1.CommandTimeout = 1800
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE W02_明細 SET 値引前sprice = [02_売上データ].単価2"
            strSQL += " FROM V_PB固定 INNER JOIN"
            strSQL += " [02_売上データ] ON V_PB固定.型番ｶﾅ = [02_売上データ].型番ｶﾅ INNER JOIN"
            strSQL += " W02_明細 ON [02_売上データ].SEQ = W02_明細.WSEQ1"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            strSQL = "UPDATE W02_明細 SET 値引前sprice = sprice WHERE (値引前sprice IS NULL)"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_dtl", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 3600
            DaList1.Fill(DsList1, "sp_glist_dtl")
            DtView1 = New DataView(DsList1.Tables("sp_glist_dtl"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                waitDlg.MainMsg = "明細抽出中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    j = i
                    strDat3(j, 0) = DtView1(i)("伝票NO")
                    strDat3(j, 1) = DtView1(i)("発行日")
                    strDat3(j, 2) = DtView1(i)("配送店ｺｰﾄﾞ")
                    strDat3(j, 3) = DtView1(i)("一般売掛区分")
                    strDat3(j, 4) = DtView1(i)("氏名")
                    strDat3(j, 5) = DtView1(i)("TEL1")
                    strDat3(j, 6) = DtView1(i)("TEL2")
                    strDat3(j, 7) = DtView1(i)("郵便番号")
                    strDat3(j, 8) = DtView1(i)("住所1")
                    strDat3(j, 9) = DtView1(i)("住所2")
                    strDat3(j, 10) = DtView1(i)("住所3")
                    strDat3(j, 11) = DtView1(i)("住所4")
                    strDat3(j, 12) = DtView1(i)("住所5")
                    strDat3(j, 13) = DtView1(i)("販売者ｺｰﾄﾞ")
                    strDat3(j, 14) = DtView1(i)("完了日")
                    strDat3(j, 15) = DtView1(i)("削除ﾌﾗｸﾞ")
                    strDat3(j, 16) = DtView1(i)("行番号")
                    strDat3(j, 17) = DtView1(i)("行区分")
                    strDat3(j, 18) = DtView1(i)("商品ｺｰﾄﾞ")
                    strDat3(j, 19) = DtView1(i)("品名ｶﾅ")
                    strDat3(j, 20) = DtView1(i)("型番ｶﾅ")
                    strDat3(j, 21) = DtView1(i)("ｶﾗｰ")
                    strDat3(j, 22) = DtView1(i)("ｻｲｽﾞ")
                    strDat3(j, 23) = DtView1(i)("ﾚｼｰﾄ")
                    strDat3(j, 24) = DtView1(i)("品名漢字")
                    strDat3(j, 25) = DtView1(i)("型番漢字")
                    strDat3(j, 26) = DtView1(i)("分類ｺｰﾄﾞ")
                    strDat3(j, 27) = DtView1(i)("品種ｺｰﾄﾞ")
                    strDat3(j, 28) = DtView1(i)("売上数")
                    strDat3(j, 29) = DtView1(i)("ﾏｽﾀ単価")
                    strDat3(j, 30) = DtView1(i)("単価")
                    strDat3(j, 31) = DtView1(i)("税区分")
                    strDat3(j, 32) = DtView1(i)("値引割引区分")
                    strDat3(j, 33) = DtView1(i)("割引率")
                    strDat3(j, 34) = DtView1(i)("値引額")
                    strDat3(j, 35) = DtView1(i)("単価2")
                    strDat3(j, 36) = DtView1(i)("分割数量")
                    strDat3(j, 37) = DtView1(i)("SEQ")
                    strDat3(j, 38) = DtView1(i)("値引前sprice")
                    strDat3(j, 39) = DtView1(i)("販売手数料")
                    strDat3(j, 40) = DtView1(i)("RDよりご請求額")
                    strDat3(j, 41) = DtView1(i)("事務委託料")
                    strDat3(j, 42) = DtView1(i)("型番1")
                    strDat3(j, 43) = DtView1(i)("型番2")
                Next
            End If
            xlRange3.Value = strDat3            'セルへデータの入力
            MRComObject(xlRange3)               'xlRange の解放

            '*****************************
            '** エラー保留
            '*****************************
            '==================  データの入力処理  ==================  
            xlSheet = xlSheets.Item(4)  'Sheet4
            Dim xlRange4 As Excel.Range
            Dim strDat4(9999, 44) As Object
            xlRange4 = xlSheet.Range("A2:AS1000")    'データの入力セル範囲

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_err", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram4.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 1800
            DaList1.Fill(DsList1, "sp_glist_err")
            DtView1 = New DataView(DsList1.Tables("sp_glist_err"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                waitDlg.MainMsg = "エラー保留抽出中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    j = i
                    strDat4(j, 0) = DtView1(i)("伝票NO")
                    strDat4(j, 1) = DtView1(i)("発行日")
                    strDat4(j, 2) = DtView1(i)("配送店ｺｰﾄﾞ")
                    strDat4(j, 3) = DtView1(i)("一般売掛区分")
                    strDat4(j, 4) = DtView1(i)("氏名")
                    strDat4(j, 5) = DtView1(i)("TEL1")
                    strDat4(j, 6) = DtView1(i)("TEL2")
                    strDat4(j, 7) = DtView1(i)("郵便番号")
                    strDat4(j, 8) = DtView1(i)("住所1")
                    strDat4(j, 9) = DtView1(i)("住所2")
                    strDat4(j, 10) = DtView1(i)("住所3")
                    strDat4(j, 11) = DtView1(i)("住所4")
                    strDat4(j, 12) = DtView1(i)("住所5")
                    strDat4(j, 13) = DtView1(i)("販売者ｺｰﾄﾞ")
                    strDat4(j, 14) = DtView1(i)("完了日")
                    strDat4(j, 15) = DtView1(i)("削除ﾌﾗｸﾞ")
                    strDat4(j, 16) = DtView1(i)("行番号")
                    strDat4(j, 17) = DtView1(i)("行区分")
                    strDat4(j, 18) = DtView1(i)("商品ｺｰﾄﾞ")
                    strDat4(j, 19) = DtView1(i)("品名ｶﾅ")
                    strDat4(j, 20) = DtView1(i)("型番ｶﾅ")
                    strDat4(j, 21) = DtView1(i)("ｶﾗｰ")
                    strDat4(j, 22) = DtView1(i)("ｻｲｽﾞ")
                    strDat4(j, 23) = DtView1(i)("ﾚｼｰﾄ")
                    strDat4(j, 24) = DtView1(i)("品名漢字")
                    strDat4(j, 25) = DtView1(i)("型番漢字")
                    strDat4(j, 26) = DtView1(i)("分類ｺｰﾄﾞ")
                    strDat4(j, 27) = DtView1(i)("品種ｺｰﾄﾞ")
                    strDat4(j, 28) = DtView1(i)("売上数")
                    strDat4(j, 29) = DtView1(i)("ﾏｽﾀ単価")
                    strDat4(j, 30) = DtView1(i)("単価")
                    strDat4(j, 31) = DtView1(i)("税区分")
                    strDat4(j, 32) = DtView1(i)("値引割引区分")
                    strDat4(j, 33) = DtView1(i)("割引率")
                    strDat4(j, 34) = DtView1(i)("値引額")
                    strDat4(j, 35) = DtView1(i)("単価2")
                    strDat4(j, 36) = DtView1(i)("分割数量")
                    strDat4(j, 37) = DtView1(i)("SEQ")
                    strDat4(j, 38) = DtView1(i)("分割元SEQ")
                    strDat4(j, 39) = DtView1(i)("赤黒SEQ")
                    strDat4(j, 40) = DtView1(i)("sprice")
                    strDat4(j, 41) = DtView1(i)("WSEQ1")
                    strDat4(j, 42) = DtView1(i)("WSEQ2")
                    strDat4(j, 43) = DtView1(i)("ERR_F")
                    If DtView1(i)("法人") = "True" Then strDat4(j, 44) = "1"
                Next
            End If
            xlRange4.Value = strDat4            'セルへデータの入力
            MRComObject(xlRange4)               'xlRange の解放

            '*****************************
            '** 法人保留
            '*****************************
            '==================  データの入力処理  ==================  
            xlSheet = xlSheets.Item(5)  'Sheet5
            Dim xlRange5 As Excel.Range
            Dim strDat5(999, 44) As Object
            xlRange5 = xlSheet.Range("A2:AS1000")    'データの入力セル範囲

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_glist_biz", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram5 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Pram5.Value = P_DATE
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 1800
            DaList1.Fill(DsList1, "sp_glist_biz")
            DtView1 = New DataView(DsList1.Tables("sp_glist_biz"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then

                waitDlg.MainMsg = "法人保留抽出中"
                waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
                Application.DoEvents()              'メッセージ処理を促して表示を更新する

                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    j = i
                    strDat5(j, 0) = DtView1(i)("伝票NO")
                    strDat5(j, 1) = DtView1(i)("発行日")
                    strDat5(j, 2) = DtView1(i)("配送店ｺｰﾄﾞ")
                    strDat5(j, 3) = DtView1(i)("一般売掛区分")
                    strDat5(j, 4) = DtView1(i)("氏名")
                    strDat5(j, 5) = DtView1(i)("TEL1")
                    strDat5(j, 6) = DtView1(i)("TEL2")
                    strDat5(j, 7) = DtView1(i)("郵便番号")
                    strDat5(j, 8) = DtView1(i)("住所1")
                    strDat5(j, 9) = DtView1(i)("住所2")
                    strDat5(j, 10) = DtView1(i)("住所3")
                    strDat5(j, 11) = DtView1(i)("住所4")
                    strDat5(j, 12) = DtView1(i)("住所5")
                    strDat5(j, 13) = DtView1(i)("販売者ｺｰﾄﾞ")
                    strDat5(j, 14) = DtView1(i)("完了日")
                    strDat5(j, 15) = DtView1(i)("削除ﾌﾗｸﾞ")
                    strDat5(j, 16) = DtView1(i)("行番号")
                    strDat5(j, 17) = DtView1(i)("行区分")
                    strDat5(j, 18) = DtView1(i)("商品ｺｰﾄﾞ")
                    strDat5(j, 19) = DtView1(i)("品名ｶﾅ")
                    strDat5(j, 20) = DtView1(i)("型番ｶﾅ")
                    strDat5(j, 21) = DtView1(i)("ｶﾗｰ")
                    strDat5(j, 22) = DtView1(i)("ｻｲｽﾞ")
                    strDat5(j, 23) = DtView1(i)("ﾚｼｰﾄ")
                    strDat5(j, 24) = DtView1(i)("品名漢字")
                    strDat5(j, 25) = DtView1(i)("型番漢字")
                    strDat5(j, 26) = DtView1(i)("分類ｺｰﾄﾞ")
                    strDat5(j, 27) = DtView1(i)("品種ｺｰﾄﾞ")
                    strDat5(j, 28) = DtView1(i)("売上数")
                    strDat5(j, 29) = DtView1(i)("ﾏｽﾀ単価")
                    strDat5(j, 30) = DtView1(i)("単価")
                    strDat5(j, 31) = DtView1(i)("税区分")
                    strDat5(j, 32) = DtView1(i)("値引割引区分")
                    strDat5(j, 33) = DtView1(i)("割引率")
                    strDat5(j, 34) = DtView1(i)("値引額")
                    strDat5(j, 35) = DtView1(i)("単価2")
                    strDat5(j, 36) = DtView1(i)("分割数量")
                    strDat5(j, 37) = DtView1(i)("SEQ")
                    strDat5(j, 38) = DtView1(i)("分割元SEQ")
                    strDat5(j, 39) = DtView1(i)("赤黒SEQ")
                    strDat5(j, 40) = DtView1(i)("sprice")
                    strDat5(j, 41) = DtView1(i)("WSEQ1")
                    strDat5(j, 42) = DtView1(i)("WSEQ2")
                    strDat5(j, 43) = DtView1(i)("ERR_F")
                    If DtView1(i)("法人") = "True" Then strDat5(j, 44) = "1"
                Next
            End If
            xlRange5.Value = strDat5            'セルへデータの入力
            MRComObject(xlRange5)               'xlRange の解放


            '［名前を付けて保存］ダイアログボックスを表示
            'SaveFileDialog1.InitialDirectory = Application.StartupPath & "\.."
            SaveFileDialog1.FileName = "MrMAX総括表" & Format(P_DATE, "yyyyMM") & ".xls"
            SaveFileDialog1.Filter = "Excelファイル|*.xls"
            SaveFileDialog1.OverwritePrompt = False
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                xlBook.SaveAs(SaveFileDialog1.FileName)
                CX_F = "0"
            Else
                CX_F = "1"
            End If

            '==================  終了処理  =====================  
            MRComObject(xlSheet)            'xlSheet の解放
            MRComObject(xlSheets)           'xlSheets の解放
            xlBook.Close(False)             'xlBook を閉じる
            MRComObject(xlBook)             'xlBook の解放
            MRComObject(xlBooks)            'xlBooks の解放
            xlApp.Quit()                    'Excelを閉じる 
            MRComObject(xlApp)              'xlApp を解放

            If CX_F = "0" Then
                MessageBox.Show(SaveFileDialog1.FileName & " に出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Activate()                   ' いったんオーナーをアクティブにする
            waitDlg.Close()                 ' 進行状況ダイアログを閉じる
            Me.Enabled = True

            DB_CLOSE()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
err_prc:
        If Err.Number = 50290 Then
            MessageBox.Show("エクセル出力中に他のエクセルファイルを開く事は出来ません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show(Err.Number & ":" & Err.Description, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        Me.Activate()                   ' いったんオーナーをアクティブにする
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Enabled = True
        DB_CLOSE()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub MRComObject(ByVal objXl As Object)
        'Excel 終了処理時のプロシージャ
        Try
            '提供されたランタイム呼び出し可能ラッパーの参照カウントをデクリメントします
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objXl)
        Catch
        Finally
            objXl = Nothing
        End Try
    End Sub

    '*********************************************************************************
    '**  本番データへ登録
    '*********************************************************************************
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim i, r1, r2, r3, r4, seq As Integer
        Dim WK_key, WK_str As String
        Dim WK_adrs, WK_adrs1, WK_adrs2 As String

        'ans = MessageBox.Show("本番データへ登録します。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        'If ans = "2" Then Exit Sub 'いいえ

        DB_OPEN()

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = "ﾃﾞｰﾀ抽出中"  ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        'WSEQ1とマッチ
        DsList1.Clear()
        strSQL = "SELECT V_Wrn_N30.発行日, V_Wrn_N30.伝票NO, V_Wrn_N30.行番号, V_Wrn_N30.[配送店ｺｰﾄﾞ], V_Wrn_N30.[商品ｺｰﾄﾞ]"
        strSQL += ", V_Wrn_N30.型番ｶﾅ, V_Wrn_N30.[品種ｺｰﾄﾞ], M08_KBN_CAT.ITEM_NAME AS 品種名, V_Wrn_N30.品名漢字"
        strSQL += ", V_Wrn_N30.単価2 AS PRICE, V_Wrn_E30.単価2 AS WRN_PRICE, '05' AS WRN_PRD, '00' AS SALE_STS"
        strSQL += ", V_Wrn_N30.氏名, V_Wrn_N30.郵便番号, V_Wrn_N30.住所1, V_Wrn_N30.住所2, V_Wrn_N30.住所3"
        strSQL += ", V_Wrn_N30.住所4, V_Wrn_N30.住所5, V_Wrn_N30.TEL1, V_Wrn_N30.TEL2, V_Wrn_N30.SEQ"
        strSQL += ", V_Wrn_E30.SEQ AS SEQ2, V_Wrn_N30.処理日2"
        strSQL += " FROM V_Wrn_N30 INNER JOIN"
        strSQL += " V_Wrn_E30 ON V_Wrn_N30.WSEQ1 = V_Wrn_E30.SEQ LEFT OUTER JOIN"
        strSQL += " M08_KBN_CAT ON V_Wrn_N30.品種ｺｰﾄﾞ = M08_KBN_CAT.CAT_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r1 = DaList1.Fill(DsList1, "Wrn_add")

        'WSEQ2とマッチ
        strSQL = "SELECT V_Wrn_N30.発行日, V_Wrn_N30.伝票NO, V_Wrn_N30.行番号, V_Wrn_N30.[配送店ｺｰﾄﾞ], V_Wrn_N30.[商品ｺｰﾄﾞ]"
        strSQL += ", V_Wrn_N30.型番ｶﾅ, V_Wrn_N30.[品種ｺｰﾄﾞ], M08_KBN_CAT.ITEM_NAME AS 品種名, V_Wrn_N30.品名漢字"
        strSQL += ", V_Wrn_N30.単価2 AS PRICE, V_Wrn_E30.単価2 AS WRN_PRICE, '05' AS WRN_PRD, '00' AS SALE_STS"
        strSQL += ", V_Wrn_N30.氏名, V_Wrn_N30.郵便番号, V_Wrn_N30.住所1, V_Wrn_N30.住所2, V_Wrn_N30.住所3"
        strSQL += ", V_Wrn_N30.住所4, V_Wrn_N30.住所5, V_Wrn_N30.TEL1, V_Wrn_N30.TEL2, V_Wrn_N30.SEQ"
        strSQL += ", V_Wrn_E30.SEQ AS SEQ2, V_Wrn_N30.処理日2"
        strSQL += " FROM V_Wrn_N30 INNER JOIN"
        strSQL += " V_Wrn_E30 ON V_Wrn_N30.WSEQ2 = V_Wrn_E30.SEQ LEFT OUTER JOIN"
        strSQL += " M08_KBN_CAT ON V_Wrn_N30.品種ｺｰﾄﾞ = M08_KBN_CAT.CAT_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r2 = DaList1.Fill(DsList1, "Wrn_add")
        DB_CLOSE()

        If r1 = 0 And r2 = 0 Then
            MsgBox("登録するデータが有りません。")
        Else

            ans = MessageBox.Show("保証データ： " & Format(r1, "##,##0") & "件" & vbCrLf & "機種データ： " & Format(r1 + r2, "##,##0") & "件" & vbCrLf & vbCrLf & "本番データへ登録します。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            If ans = "2" Then 'いいえ
                waitDlg.Close()         '進行状況ダイアログを閉じる
                Me.Enabled = True       'オーナーのフォームを無効にする
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If

            DtView1 = New DataView(DsList1.Tables("Wrn_add"), "", "伝票NO, 行番号", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "ﾃﾞｰﾀ登録中"      ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           ' 最初の件数を設定
            Application.DoEvents()              ' メッセージ処理を促して表示を更新する

            DB_OPEN()
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                seq = 1
re:
                WK_key = Trim(DtView1(i)("伝票NO")) & Format(CInt(DtView1(i)("行番号")), "00") & Format(seq, "00")
                WK_key = WK_key.PadLeft(17, "0")

                WK_DsList1.Clear()
                strSQL = "SELECT WRN_NO FROM WRN_DATA WHERE (WRN_NO = '" & WK_key & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 3600
                r3 = DaList1.Fill(WK_DsList1, "Wrn_data")
                If r3 <> 0 Then
                    seq = seq + 1
                    GoTo re
                Else

                    strSQL = "INSERT INTO WRN_DATA"
                    strSQL += " (WRN_DATE, WRN_NO, SHOP_CODE, ITEM_CODE, MODEL, CAT_CODE, CAT_NAME, MKR_NAME, PRICE"
                    strSQL += ", WRN_PRICE, WRN_PRD, SALE_STS, CRT_DATE, CUST_NAME, ZIP1, ZIP2, ADRS1, ADRS2, TEL_NO, CNT_NO)"
                    strSQL += " VALUES ('" & Mid(DtView1(i)("発行日"), 1, 4) & "/" & Mid(DtView1(i)("発行日"), 5, 2) & "/" & Mid(DtView1(i)("発行日"), 7, 2) & "'"
                    strSQL += ", '" & WK_key & "'"
                    WK_str = Trim(DtView1(i)("配送店ｺｰﾄﾞ")) : WK_str = WK_str.PadLeft(4, "0")
                    strSQL += ", '" & WK_str & "'"
                    strSQL += ", '" & DtView1(i)("商品ｺｰﾄﾞ") & "'"
                    strSQL += ", '" & DtView1(i)("型番ｶﾅ") & "'"
                    strSQL += ", '" & DtView1(i)("品種ｺｰﾄﾞ") & "'"
                    If Not IsDBNull(DtView1(i)("品種名")) Then
                        strSQL += ", '" & DtView1(i)("品種名") & "'"
                    Else
                        strSQL += ", NULL"
                    End If
                    strSQL += ", '" & DtView1(i)("品名漢字") & "'"
                    strSQL += ", " & DtView1(i)("PRICE") & ""
                    strSQL += ", " & DtView1(i)("WRN_PRICE") & ""
                    strSQL += ", '" & DtView1(i)("WRN_PRD") & "'"
                    strSQL += ", '" & DtView1(i)("SALE_STS") & "'"
                    strSQL += ", '" & DtView1(i)("処理日2") & "'"
                    strSQL += ", '" & DtView1(i)("氏名") & "'"
                    If Not IsDBNull(DtView1(i)("郵便番号")) Then
                        strSQL += ", '" & Mid(DtView1(i)("郵便番号"), 1, 3) & "'"
                        strSQL += ", '" & Mid(DtView1(i)("郵便番号"), 4, 4) & "'"
                    Else
                        strSQL += ", NULL"
                        strSQL += ", NULL"
                    End If

                    If IsDBNull(DtView1(i)("住所1")) Then DtView1(i)("住所1") = ""
                    If IsDBNull(DtView1(i)("住所2")) Then DtView1(i)("住所2") = ""
                    If IsDBNull(DtView1(i)("住所3")) Then DtView1(i)("住所3") = ""
                    If IsDBNull(DtView1(i)("住所4")) Then DtView1(i)("住所4") = ""
                    If IsDBNull(DtView1(i)("住所5")) Then DtView1(i)("住所5") = ""
                    WK_adrs = Trim(DtView1(i)("住所1")) & Trim(DtView1(i)("住所2")) & Trim(DtView1(i)("住所3")) & Trim(DtView1(i)("住所4"))
                    If LenB(WK_adrs) <= 60 Then
                        WK_adrs1 = WK_adrs
                        WK_adrs2 = MidB(Trim(DtView1(i)("住所5")), 1, 60)
                    Else
                        WK_adrs1 = MidB(WK_adrs, 1, 60)
                        WK_adrs2 = MidB(Trim(MidB(WK_adrs, 61, 60)) & Trim(DtView1(i)("住所5")), 1, 60)
                    End If
                    strSQL += ", '" & WK_adrs1 & "'"
                    strSQL += ", '" & WK_adrs2 & "'"
                    strSQL += ", '" & DtView1(i)("TEL1") & "'"
                    strSQL += ", '" & DtView1(i)("TEL2") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    '済フラグON

                    strSQL = "UPDATE [02_売上データ] SET wrn_add_f = 1 WHERE (SEQ = " & DtView1(i)("SEQ") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    strSQL = "UPDATE [02_売上データ] SET wrn_add_f = 1 WHERE (SEQ = " & DtView1(i)("SEQ2") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                End If
            Next
            MsgBox("登録完了")
        End If

        waitDlg.Close()         '進行状況ダイアログを閉じる
        Me.Enabled = True       'オーナーのフォームを無効にする

        DB_CLOSE()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
