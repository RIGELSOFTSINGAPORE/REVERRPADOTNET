'Imports System.Threading
Imports System.Globalization

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2, DsExp As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim reader As SqlClient.SqlDataReader

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim From_date, To_date As Date
    Dim strSQL, Err_F, ptn_F, inz_F As String
    Dim i, j, r As Integer
    Dim errcnt As Boolean
    Dim errcntmsg As String
    Friend WithEvents テキスト17 As TextBox
    Friend WithEvents テキスト10 As TextBox
    Friend WithEvents テキスト25 As TextBox
    Friend WithEvents テキスト3 As TextBox
    Friend WithEvents ラベル4 As Label
    Friend WithEvents テキスト1 As TextBox
    Friend WithEvents テキスト19 As TextBox
    Friend WithEvents テキスト21 As TextBox
    Friend WithEvents date_from As TextBox
    Friend WithEvents date_to As TextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ラベル2 As Label
    Dim dformat As String

    Dim dateval As DateTime


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
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.テキスト17 = New System.Windows.Forms.TextBox()
        Me.テキスト10 = New System.Windows.Forms.TextBox()
        Me.テキスト25 = New System.Windows.Forms.TextBox()
        Me.テキスト3 = New System.Windows.Forms.TextBox()
        Me.ラベル4 = New System.Windows.Forms.Label()
        Me.テキスト1 = New System.Windows.Forms.TextBox()
        Me.ラベル2 = New System.Windows.Forms.Label()
        Me.テキスト19 = New System.Windows.Forms.TextBox()
        Me.テキスト21 = New System.Windows.Forms.TextBox()
        Me.date_from = New System.Windows.Forms.TextBox()
        Me.date_to = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button99.Location = New System.Drawing.Point(308, 107)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(110, 32)
        Me.Button99.TabIndex = 3
        Me.Button99.Text = "終了"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(80, 112)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "集計"
        '
        'テキスト17
        '
        Me.テキスト17.Location = New System.Drawing.Point(385, 25)
        Me.テキスト17.Name = "テキスト17"
        Me.テキスト17.ReadOnly = True
        Me.テキスト17.Size = New System.Drawing.Size(118, 26)
        Me.テキスト17.TabIndex = 113
        Me.テキスト17.Tag = ""
        Me.テキスト17.Visible = False
        '
        'テキスト10
        '
        Me.テキスト10.Location = New System.Drawing.Point(9, 25)
        Me.テキスト10.Name = "テキスト10"
        Me.テキスト10.ReadOnly = True
        Me.テキスト10.Size = New System.Drawing.Size(110, 26)
        Me.テキスト10.TabIndex = 110
        Me.テキスト10.Visible = False
        '
        'テキスト25
        '
        Me.テキスト25.Location = New System.Drawing.Point(334, 2)
        Me.テキスト25.Name = "テキスト25"
        Me.テキスト25.ReadOnly = True
        Me.テキスト25.Size = New System.Drawing.Size(118, 26)
        Me.テキスト25.TabIndex = 105
        Me.テキスト25.Visible = False
        '
        'テキスト3
        '
        Me.テキスト3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.0!)
        Me.テキスト3.Location = New System.Drawing.Point(313, 57)
        Me.テキスト3.MaxLength = 10
        Me.テキスト3.Name = "テキスト3"
        Me.テキスト3.Size = New System.Drawing.Size(124, 26)
        Me.テキスト3.TabIndex = 1
        Me.テキスト3.Text = "ラベル4"
        '
        'ラベル4
        '
        Me.ラベル4.AutoSize = True
        Me.ラベル4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.0!)
        Me.ラベル4.Location = New System.Drawing.Point(267, 59)
        Me.ラベル4.Name = "ラベル4"
        Me.ラベル4.Size = New System.Drawing.Size(28, 19)
        Me.ラベル4.TabIndex = 103
        Me.ラベル4.Text = "～"
        '
        'テキスト1
        '
        Me.テキスト1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.0!)
        Me.テキスト1.Location = New System.Drawing.Point(116, 57)
        Me.テキスト1.MaxLength = 10
        Me.テキスト1.Name = "テキスト1"
        Me.テキスト1.Size = New System.Drawing.Size(124, 26)
        Me.テキスト1.TabIndex = 0
        Me.テキスト1.Text = "ラベル2"
        '
        'ラベル2
        '
        Me.ラベル2.AutoSize = True
        Me.ラベル2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.0!)
        Me.ラベル2.Location = New System.Drawing.Point(50, 63)
        Me.ラベル2.Name = "ラベル2"
        Me.ラベル2.Size = New System.Drawing.Size(66, 19)
        Me.ラベル2.TabIndex = 101
        Me.ラベル2.Text = "処理日"
        '
        'テキスト19
        '
        Me.テキスト19.Location = New System.Drawing.Point(12, 2)
        Me.テキスト19.Name = "テキスト19"
        Me.テキスト19.ReadOnly = True
        Me.テキスト19.Size = New System.Drawing.Size(156, 26)
        Me.テキスト19.TabIndex = 116
        Me.テキスト19.Visible = False
        '
        'テキスト21
        '
        Me.テキスト21.Location = New System.Drawing.Point(192, 2)
        Me.テキスト21.Name = "テキスト21"
        Me.テキスト21.ReadOnly = True
        Me.テキスト21.Size = New System.Drawing.Size(127, 26)
        Me.テキスト21.TabIndex = 117
        Me.テキスト21.Visible = False
        '
        'date_from
        '
        Me.date_from.Location = New System.Drawing.Point(145, 25)
        Me.date_from.Name = "date_from"
        Me.date_from.ReadOnly = True
        Me.date_from.Size = New System.Drawing.Size(95, 26)
        Me.date_from.TabIndex = 118
        Me.date_from.Tag = ""
        Me.date_from.Visible = False
        '
        'date_to
        '
        Me.date_to.Location = New System.Drawing.Point(261, 25)
        Me.date_to.Name = "date_to"
        Me.date_to.ReadOnly = True
        Me.date_to.Size = New System.Drawing.Size(118, 26)
        Me.date_to.TabIndex = 119
        Me.date_to.Tag = ""
        Me.date_to.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(9, 19)
        Me.ClientSize = New System.Drawing.Size(515, 181)
        Me.Controls.Add(Me.date_to)
        Me.Controls.Add(Me.date_from)
        Me.Controls.Add(Me.テキスト21)
        Me.Controls.Add(Me.テキスト19)
        Me.Controls.Add(Me.テキスト17)
        Me.Controls.Add(Me.テキスト10)
        Me.Controls.Add(Me.テキスト25)
        Me.Controls.Add(Me.テキスト3)
        Me.Controls.Add(Me.ラベル4)
        Me.Controls.Add(Me.テキスト1)
        Me.Controls.Add(Me.ラベル2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ﾋﾞｯｸｶﾒﾗ総括表"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "Bic_Report_soukatsu")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        Call DB_INIT()

        If Mid(Now, 9, 2) <= "15" Then

            From_date = Mid(DateAdd("m", -1, Now), 1, 8) & "01"         'From

            テキスト1.Text = From_date
            To_date = DateAdd("m", 1, From_date)
            To_date = DateAdd("d", -1, To_date)                         'To

            テキスト3.Text = To_date
            テキスト17.Text = To_date

        Else
            From_date = Mid(Now, 1, 8) & "01"                           'From
            テキスト1.Text = Mid(Now, 1, 8) & "01"
            To_date = Mid(Now, 1, 8) & "15"                             'To

            テキスト3.Text = To_date
            テキスト17.Text = DateAdd("d", -1, From_date)
        End If

        テキスト19.Text = "CYOKI." & Mid(From_date, 3, 2) & Mid(From_date, 6, 2) & Mid(From_date, 9, 2)  'From
        テキスト21.Text = "CYOKI." & Mid(To_date, 3, 2) & Mid(To_date, 6, 2) & Mid(To_date, 9, 2)        'To

        Dim WK_date As DateTime
        If テキスト1.Text = Nothing Or テキスト1.Text = "" Then
        Else
            date_from.Text = Mid(テキスト1.Text, 1, 4) & Mid(テキスト1.Text, 6, 2) & Mid(テキスト1.Text, 9, 2)
            WK_date = DateAdd("m", -5, テキスト1.Text)
            If WK_date < "2007/05/20" Then
                テキスト10.Text = "2007/05/20"
            Else
                テキスト10.Text = "2007/05/20"
            End If
            From_date = テキスト1.Text
            テキスト19.Text = "CYOKI." & Mid(From_date, 3, 2) & Mid(From_date, 6, 2) & Mid(From_date, 9, 2)  'From
        End If

        t10_set()

        date_to.Text = Mid(テキスト3.Text, 1, 4) & Mid(テキスト3.Text, 6, 2) & Mid(テキスト3.Text, 9, 2)
        To_date = テキスト3.Text
        テキスト21.Text = "CYOKI." & Mid(To_date, 3, 2) & Mid(To_date, 6, 2) & Mid(To_date, 9, 2)        'To
        t10_set()

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

    'データ出力ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 5         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        waitDlg.MainMsg = "対象データ抽出中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = Nothing
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        dformat = "yyyy/MM/dd"
        errcnt = False
        If DateTime.TryParseExact(テキスト1.Text, dformat, New CultureInfo("en-US"), DateTimeStyles.None, dateval) Then
            Dim WK_date As DateTime

            If テキスト1.Text = Nothing Or テキスト1.Text = "" Then
            Else
                date_from.Text = Mid(テキスト1.Text, 1, 4) & Mid(テキスト1.Text, 6, 2) & Mid(テキスト1.Text, 9, 2)
                WK_date = DateAdd("m", -5, テキスト1.Text)
                If WK_date < "2007/05/20" Then
                    テキスト10.Text = "2007/05/20"
                Else
                    テキスト10.Text = "2007/05/20"
                End If
                From_date = テキスト1.Text
                テキスト19.Text = "CYOKI." & Mid(From_date, 3, 2) & Mid(From_date, 6, 2) & Mid(From_date, 9, 2)  'From
            End If
        Else
            Me.Activate()                   ' いったんオーナーをアクティブにする
            Me.Enabled = True               ' オーナーのフォームを有効にする
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("有効な日付を入力してください")
            テキスト1.Focus()
            Exit Sub
        End If


        If DateTime.TryParseExact(テキスト3.Text, dformat, New CultureInfo("en-US"), DateTimeStyles.None, dateval) Then
            date_to.Text = Mid(テキスト3.Text, 1, 4) & Mid(テキスト3.Text, 6, 2) & Mid(テキスト3.Text, 9, 2)
            To_date = テキスト3.Text
            テキスト21.Text = "CYOKI." & Mid(To_date, 3, 2) & Mid(To_date, 6, 2) & Mid(To_date, 9, 2)        'To
        Else
            Me.Activate()                   ' いったんオーナーをアクティブにする
            Me.Enabled = True               ' オーナーのフォームを有効にする
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("有効な日付を入力してください")
            テキスト3.Focus()
            Exit Sub
        End If

        If Format(CDate(テキスト1.Text), "YYYY/MM/DD") > Format(CDate(テキスト3.Text), "YYYY/MM/DD") Then
            MessageBox.Show("日付から日付までが無効です")
            テキスト3.Focus()
            Exit Sub
        End If
        t10_set()

        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")

        For Each Process As Process In xlp
            If Process.MainWindowTitle = "" Then
                Process.Kill()
            End If
        Next

        If (Not System.IO.Directory.Exists("C:\BIC集計")) Then
            System.IO.Directory.CreateDirectory("C:\BIC集計")
        End If

        If (Not System.IO.Directory.Exists("C:\temp")) Then
            System.IO.Directory.CreateDirectory("C:\temp")
        End If

        Call コマンド0Main()

        If errcnt = True Then
            MsgBox(errcntmsg)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        '***************
        '総括表出力
        '***************
        Call soukatu("1")   'ビックカメラ
        Call soukatu("2")   'コジマ
        Call soukatu("3")   'エアービック

        '***************
        '店別請求書出力
        '***************
        Call SHOP("1")   'ビックカメラ
        Call SHOP("2")   'コジマ
        Call SHOP("3")   'エアービック

        waitDlg.Close()
        Me.Activate()                   ' いったんオーナーをアクティブにする
        Me.Enabled = True               ' オーナーのフォームを有効にする

        MsgBox("出力しました。", , "")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '終了ボタン
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub
    Sub t10_set()

        If Format(Convert.ToDateTime(テキスト1.Text), "dd") = "01" _
       And Format(DateAdd("d", 1, Convert.ToDateTime(テキスト3.Text)), "dd") = "01" Then
            テキスト25.Text = Mid(date_from.Text, 1, 6)
        Else
            テキスト25.Text = date_from.Text & "_" & Mid(date_to.Text, 7, 8)
        End If
    End Sub

    Sub コマンド0Main()
        strSQL = ""
        errcnt = False

        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

        '************
        'txt_data
        '************
        DB_OPEN("bicdb_WK")
        strSQL = "DELETE FROM txt_data"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DBCC CHECKIDENT (txt_data ,RESEED ,0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("bicdb")
        DsList1.Clear()
        strSQL = "SELECT txt_data_all.*, SHOP.bk_kbn, SHOP.airbic"
        strSQL += " FROM txt_data_all INNER JOIN"
        strSQL += " SHOP ON txt_data_all.SHOP_CODE = SHOP.SHOP_CODE"
        strSQL += " WHERE (txt_data_all.IMPT_FILE >= '" & テキスト19.Text & "'"
        strSQL += " AND txt_data_all.IMPT_FILE <= '" & テキスト21.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "txt_data_all")
        DB_CLOSE()
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("txt_data_all"), "", "", DataViewRowState.CurrentRows)
            DB_OPEN("bicdb_WK")
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO txt_data"
                strSQL += " (WRN_DATE, WRN_NO, SHOP_CODE, ITEM_CODE, MODEL, CAT_CODE, CAT_NAME, MKR_CODE, MKR_NAME, PRICE, WRN_PRICE, WRN_PRD, SALE_STS, CRT_DATE, CLS_MNTH, PNT_NO, CUST_NAME, ZIP1, ZIP2, ADRS1, ADRS2, SEX, BRTH_DATE, TEL_NO, CNT_NO, IMPT_FILE, BK_KBN)"
                strSQL += " VALUES ('" & DtView1(i)("WRN_DATE") & "'"   'WRN_DATE
                strSQL += ", '" & DtView1(i)("WRN_NO") & "'"            'WRN_NO
                strSQL += ", '" & DtView1(i)("SHOP_CODE") & "'"         'SHOP_CODE
                strSQL += ", '" & DtView1(i)("ITEM_CODE") & "'"         'ITEM_CODE
                strSQL += ", '" & DtView1(i)("MODEL") & "'"             'MODEL
                strSQL += ", '" & DtView1(i)("CAT_CODE") & "'"          'CAT_CODE
                strSQL += ", '" & DtView1(i)("CAT_NAME") & "'"          'CAT_NAME
                strSQL += ", '" & DtView1(i)("MKR_CODE") & "'"          'MKR_CODE
                strSQL += ", '" & DtView1(i)("MKR_NAME") & "'"          'MKR_NAME
                strSQL += ", '" & DtView1(i)("PRICE") & "'"             'PRICE
                strSQL += ", '" & DtView1(i)("WRN_PRICE") & "'"         'WRN_PRICE
                strSQL += ", '" & DtView1(i)("WRN_PRD") & "'"           'WRN_PRD
                strSQL += ", '" & DtView1(i)("SALE_STS") & "'"          'SALE_STS
                strSQL += ", '" & DtView1(i)("CRT_DATE") & "'"          'CRT_DATE
                strSQL += ", '" & DtView1(i)("CLS_MNTH") & "'"          'CLS_MNTH
                strSQL += ", '" & DtView1(i)("PNT_NO") & "'"            'PNT_NO
                strSQL += ", '" & DtView1(i)("CUST_NAME") & "'"         'CUST_NAME
                strSQL += ", '" & DtView1(i)("ZIP1") & "'"              'ZIP1
                strSQL += ", '" & DtView1(i)("ZIP2") & "'"              'ZIP2
                strSQL += ", '" & DtView1(i)("ADRS1") & "'"             'ADRS1
                strSQL += ", '" & DtView1(i)("ADRS2") & "'"             'ADRS2
                strSQL += ", '" & DtView1(i)("SEX") & "'"               'SEX
                strSQL += ", '" & DtView1(i)("BRTH_DATE") & "'"         'BRTH_DATE
                strSQL += ", '" & DtView1(i)("TEL_NO") & "'"            'TEL_NO
                strSQL += ", '" & DtView1(i)("CNT_NO") & "'"            'CNT_NO
                strSQL += ", '" & DtView1(i)("IMPT_FILE") & "'"         'IMPT_FILE
                If DtView1(i)("airbic") = "0" Then
                    strSQL += ", '" & DtView1(i)("BK_KBN") & "'"        'BK_KBN
                Else
                    strSQL += ", '3'"                                   'BK_KBN(airbic)
                End If
                strSQL += ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
            DB_CLOSE()
        End If

        DB_OPEN("bicdb_WK")
        strSQL = "DELETE FROM txt_data WHERE (WRN_DATE > '" & date_to.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

        '************
        'WRN_DATA
        '************
        DB_OPEN("bicdb_WK")
        strSQL = "DELETE FROM WRN_DATA"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("bicdb_WK")
        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_Q_04_WRN_DATA", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "WRN_DATA")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("WRN_DATA"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO WRN_DATA"
                strSQL += " (WRN_DATE, WRN_NO, SHOP_CODE, ITEM_CODE, MODEL, CAT_CODE, CAT_NAME, MKR_CODE, MKR_NAME, PRICE, WRN_PRICE, WRN_PRD, SALE_STS, CRT_DATE, CLS_MNTH, PNT_NO, CUST_NAME_KANA, CUST_NAME, ZIP1, ZIP2, ADRS1, ADRS2, SEX, BRTH_DATE, TEL_NO, CNT_NO, MODEL_UPD_RSN, CXL_DATE, wrn_end)"
                If Not IsDBNull(DtView1(i)("WRN_DATE")) Then
                    strSQL += " VALUES (CONVERT(DATETIME, '" & DtView1(i)("WRN_DATE") & "', 102)"   'WRN_DATE
                Else
                    strSQL += " VALUES (NULL"                                                       'WRN_DATE
                End If
                strSQL += ", '" & DtView1(i)("WRN_NO") & "'"                                        'WRN_NO
                strSQL += ", '" & DtView1(i)("SHOP_CODE") & "'"                                     'SHOP_CODE
                strSQL += ", '" & DtView1(i)("ITEM_CODE") & "'"                                     'ITEM_CODE
                strSQL += ", '" & DtView1(i)("MODEL") & "'"                                         'MODEL
                strSQL += ", '" & DtView1(i)("CAT_CODE") & "'"                                      'CAT_CODE
                strSQL += ", '" & DtView1(i)("CAT_NAME") & "'"                                      'CAT_NAME
                strSQL += ", '" & DtView1(i)("MKR_CODE") & "'"                                      'MKR_CODE
                strSQL += ", '" & DtView1(i)("MKR_NAME") & "'"                                      'MKR_NAME
                strSQL += ", " & DtView1(i)("PRICE") & ""                                           'PRICE
                strSQL += ", " & DtView1(i)("WRN_PRICE") & ""                                       'WRN_PRICE
                strSQL += ", '" & DtView1(i)("WRN_PRD") & "'"                                       'WRN_PRD
                strSQL += ", '" & DtView1(i)("SALE_STS") & "'"                                      'SALE_STS
                If Not IsDBNull(DtView1(i)("CRT_DATE")) Then
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("CRT_DATE") & "', 102)"          'CRT_DATE
                Else
                    strSQL += ", NULL"                                                              'CRT_DATE
                End If
                If Not IsDBNull(DtView1(i)("CLS_MNTH")) Then
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("CLS_MNTH") & "', 102)"          'CLS_MNTH
                Else
                    strSQL += ", NULL"                                                              'CLS_MNTH
                End If
                strSQL += ", '" & DtView1(i)("PNT_NO") & "'"                                        'PNT_NO
                strSQL += ", '" & DtView1(i)("CUST_NAME_KANA") & "'"                                'CUST_NAME_KANA
                strSQL += ", '" & DtView1(i)("CUST_NAME") & "'"                                     'CUST_NAME
                strSQL += ", '" & DtView1(i)("ZIP1") & "'"                                          'ZIP1
                strSQL += ", '" & DtView1(i)("ZIP2") & "'"                                          'ZIP2
                strSQL += ", '" & DtView1(i)("ADRS1") & "'"                                         'ADRS1
                strSQL += ", '" & DtView1(i)("ADRS2") & "'"                                         'ADRS2
                strSQL += ", '" & DtView1(i)("SEX") & "'"                                           'SEX
                If Not IsDBNull(DtView1(i)("BRTH_DATE")) Then
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("BRTH_DATE") & "', 102)"         'BRTH_DATE
                Else
                    strSQL += ", NULL"                                                              'BRTH_DATE
                End If
                strSQL += ", '" & DtView1(i)("TEL_NO") & "'"                                        'TEL_NO
                strSQL += ", '" & DtView1(i)("CNT_NO") & "'"                                        'CNT_NO
                strSQL += ", '" & DtView1(i)("MODEL_UPD_RSN") & "'"                                 'MODEL_UPD_RSN
                If Not IsDBNull(DtView1(i)("CXL_DATE")) Then
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("CXL_DATE") & "', 102)"          'CXL_DATE
                Else
                    strSQL += ", NULL"                                                              'CXL_DATE
                End If
                If Not IsDBNull(DtView1(i)("wrn_end")) Then
                    strSQL += ", CONVERT(DATETIME, '" & DtView1(i)("wrn_end") & "', 102)"           'wrn_end
                Else
                    strSQL += ", NULL"                                                              'wrn_end
                End If
                strSQL += ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If
        DB_CLOSE()

        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

        '************
        '処理日以降のキャンセルを戻す
        '************
        DB_OPEN("bicdb_WK")
        strSQL = "UPDATE WRN_DATA"
        strSQL += " SET SALE_STS = '00'"
        strSQL += " WHERE (SALE_STS = '09')"
        strSQL += " AND (CXL_DATE > CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

        '************
        'C重複をSET
        '************
        DB_OPEN("bicdb_WK")
        strSQL = "DELETE FROM WK"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        strSQL = "INSERT INTO WK (WRN_NO, cnt)"
        strSQL += " SELECT WRN_NO, COUNT(*) AS cnt"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (SALE_STS = '09')"
        strSQL += " GROUP BY WRN_NO"
        strSQL += " HAVING (COUNT(*) > 1)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DsList1.Clear()
        strSQL = "SELECT WK.* FROM WK"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "WK")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("WK"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                Dim WK_int As Integer = DtView1(i)("cnt")
                DsList2.Clear()
                strSQL = "SELECT txtdata_ID"
                strSQL += " FROM txt_data"
                strSQL += " WHERE (WRN_NO = '" & DtView1(i)("WRN_NO") & "') AND (SALE_STS = '09')"
                strSQL += " ORDER BY IMPT_FILE, txtdata_ID"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                SqlCmd1.CommandTimeout = 600
                DaList1.Fill(DsList2, "txt_data")
                DtView2 = New DataView(DsList2.Tables("txt_data"), "", "", DataViewRowState.CurrentRows)
                For j = 0 To WK_int - 2
                    strSQL = "UPDATE txt_data"
                    strSQL += " SET EX = '1'"
                    strSQL += "WHERE (txtdata_ID = '" & DtView2(j)("txtdata_ID") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                Next
            Next
        End If
        DB_CLOSE()

        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

    End Sub

    '*********************
    '総括表出力
    '*********************
    Sub soukatu(BKA_kbn As String)

        Select Case BKA_kbn
            Case = "1"
                waitDlg.MainMsg = "ビックカメラ総括表作成中"    ' 進行状況ダイアログのメーターを設定 Need to change based on report
            Case = "2"
                waitDlg.MainMsg = "コジマ総括表作成中"           ' 進行状況ダイアログのメーターを設定 Need to change based on report
            Case = "3"
                waitDlg.MainMsg = "エアービック総括表作成中"    ' 進行状況ダイアログのメーターを設定 Need to change based on report
        End Select
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Application.DoEvents()                                  ' メッセージ処理を促して表示を更新する

        DB_OPEN("bicdb_WK")

        '*********************
        '総合補償
        '*********************
        strSQL = "DELETE FROM WK_OUT_00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        '①全Ａデータ
        DsList1.Clear()
        strSQL = "SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '00') AND (SALE_STS = '00')"
        strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " GROUP BY BK_KBN"
        strSQL += " HAVING (BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "11_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("11_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (1, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (1, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '③０７年５月２０日以降のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '00') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "12_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("12_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (2, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (2, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '④５月２０日以降の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD='00')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "13_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("13_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (3, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (3, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑤０７年５月１９日以前のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '00') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "14_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("14_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (4, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (4, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑥５月１９日以前の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '00')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "15_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("15_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (5, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (5, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '総合補償 ⑦対応するＡがないＣ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data LEFT JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '00') AND (txt_data.SALE_STS = '09') AND (WRN_DATA.WRN_NO Is Null)"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "16_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("16_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (6, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_00 (P_SEQ, 件数, 購入金額) VALUES (6, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '*********************
        '長期保証（3年）
        '*********************
        strSQL = "DELETE FROM WK_OUT_03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        '①全Ａデータ
        DsList1.Clear()
        strSQL = "SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '03') AND (SALE_STS = '00')"
        strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " GROUP BY BK_KBN"
        strSQL += " HAVING (BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "11_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("11_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (1, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (1, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '③０７年５月２０日以降のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '03') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "12_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("12_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (2, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (2, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '④０７年５月２０日以降の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD='03')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "13_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("13_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (3, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (3, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑤０７年５月１９日以前のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '03') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "14_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("14_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (4, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (4, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑥０７年５月１９日以前の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '03')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "15_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("15_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (5, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (5, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑦対応するＡがないＣ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data LEFT JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '03') AND (txt_data.SALE_STS = '09') AND (WRN_DATA.WRN_NO Is Null)"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "16_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("16_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (6, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_03 (P_SEQ, 件数, 購入金額) VALUES (6, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '*********************
        '長期保証（5年）
        '*********************
        strSQL = "DELETE FROM WK_OUT_05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        '①全Ａデータ
        DsList1.Clear()
        strSQL = "SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '05') AND (SALE_STS = '00')"
        'strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " GROUP BY BK_KBN"
        strSQL += " HAVING (BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "11_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("11_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (1, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (1, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '③０７年５月２０日以降のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '05') AND (txt_data.SALE_STS = '09')"
        'strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "12_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("12_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (2, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (2, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '④０７年５月２０日以降の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD='05')"
        'strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "13_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("13_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (3, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (3, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑤０７年５月１９日以前のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '05') AND (txt_data.SALE_STS = '09')"
        'strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "14_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("14_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (4, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (4, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑥０７年５月１９日以前の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '05')"
        'strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "15_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("15_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (5, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (5, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑦対応するＡがないＣ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data LEFT JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '05') AND (txt_data.SALE_STS = '09') AND (WRN_DATA.WRN_NO Is Null)"
        'strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "16_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("16_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (6, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_05 (P_SEQ, 件数, 購入金額) VALUES (6, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '*********************
        '長期保証（10年）
        '*********************
        strSQL = "DELETE FROM WK_OUT_10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        '①全Ａデータ
        DsList1.Clear()
        strSQL = "SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '10') AND (SALE_STS = '00')"
        strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " GROUP BY BK_KBN"
        strSQL += " HAVING (BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "11_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("11_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (1, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (1, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '③０７年５月２０日以降のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "12_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("12_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (2, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (2, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '④０７年５月２０日以降の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD='10')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "13_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("13_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (3, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (3, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑤０７年５月１９日以前のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "14_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("14_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (4, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (4, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑥０７年５月１９日以前の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "15_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("15_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (5, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (5, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑦対応するＡがないＣ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data LEFT JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09') AND (WRN_DATA.WRN_NO Is Null)"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "16_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("16_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (6, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10 (P_SEQ, 件数, 購入金額) VALUES (6, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '*********************
        '住設長期（10年）
        '*********************
        strSQL = "DELETE FROM WK_OUT_10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        '①全Ａデータ
        DsList1.Clear()
        strSQL = "SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '10') AND (SALE_STS = '00')"
        strSQL += " AND ((CAT_CODE = '253091') OR (CAT_CODE = '255010') OR (CAT_CODE = '255011') OR (CAT_CODE = '253090') OR (CAT_CODE = '253062') OR (CAT_CODE = '255160'))"
        strSQL += " GROUP BY BK_KBN"
        strSQL += " HAVING (BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "11_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("11_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (1, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (1, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '③０７年５月２０日以降のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND ((txt_data.CAT_CODE = '253091') OR (txt_data.CAT_CODE = '255010') OR (txt_data.CAT_CODE = '255011') OR (txt_data.CAT_CODE = '253090') OR (txt_data.CAT_CODE = '253062') OR (txt_data.CAT_CODE = '255160'))"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "12_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("12_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (2, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (2, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '④０７年５月２０日以降の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD='10')"
        strSQL += " AND ((txt_data.CAT_CODE = '253091') OR (txt_data.CAT_CODE = '255010') OR (txt_data.CAT_CODE = '255011') OR (txt_data.CAT_CODE = '253090') OR (txt_data.CAT_CODE = '253062') OR (txt_data.CAT_CODE = '255160'))"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "13_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("13_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (3, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (3, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑤０７年５月１９日以前のＣデータ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND ((txt_data.CAT_CODE = '253091') OR (txt_data.CAT_CODE = '255010') OR (txt_data.CAT_CODE = '255011') OR (txt_data.CAT_CODE = '253090') OR (txt_data.CAT_CODE = '253062') OR (txt_data.CAT_CODE = '255160'))"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "14_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("14_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (4, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (4, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑥０７年５月１９日以前の重複Ｃデータ（ACC）
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10')"
        strSQL += " AND ((txt_data.CAT_CODE = '253091') OR (txt_data.CAT_CODE = '255010') OR (txt_data.CAT_CODE = '255011') OR (txt_data.CAT_CODE = '253090') OR (txt_data.CAT_CODE = '253062') OR (txt_data.CAT_CODE = '255160'))"
        strSQL += " AND (txt_data.EX='1')"
        strSQL += " AND (WRN_DATA.WRN_DATE < CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "15_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("15_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (5, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (5, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '⑦対応するＡがないＣ
        DsList1.Clear()
        strSQL = " SELECT COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data LEFT JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09') AND (WRN_DATA.WRN_NO Is Null)"
        strSQL += " AND ((txt_data.CAT_CODE = '253091') OR (txt_data.CAT_CODE = '255010') OR (txt_data.CAT_CODE = '255011') OR (txt_data.CAT_CODE = '253090') OR (txt_data.CAT_CODE = '253062') OR (txt_data.CAT_CODE = '255160'))"
        strSQL += " GROUP BY txt_data.BK_KBN"
        strSQL += " HAVING (txt_data.BK_KBN = '" & BKA_kbn & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "16_00")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("16_00"), "", "", DataViewRowState.CurrentRows)
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (6, " & DtView1(0)("cnt") & ", " & DtView1(0)("PRICE") & ")"
        Else
            strSQL = "INSERT INTO WK_OUT_10_2 (P_SEQ, 件数, 購入金額) VALUES (6, 0, 0)"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '*********************
        ''合算
        '*********************
        SqlCmd1 = New SqlClient.SqlCommand("sp_Q_99_合算", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        strSQL = "INSERT INTO WK_OUT (P_SEQ, 項目名) VALUES (0, '" & テキスト1.Text & "～" & テキスト3.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '*********************
        ''エクセル出力
        '*********************

        DsExp.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$
        filename = "c:\temp\temp.xls"

        'Select Case BKA_kbn
        '    Case = "1"
        '        filename = テキスト13.Text & ":\BIC集計\b_総括表_" & テキスト25.Text & ".xls"
        '    Case = "2"
        '        filename = テキスト13.Text & ":\BIC集計\k_総括表_" & テキスト25.Text & ".xls"
        '    Case = "3"
        '        filename = テキスト13.Text & ":\BIC集計\ab_総括表_" & テキスト25.Text & ".xls"
        'End Select

        'FileCopy "C:\Client\エクセル雛形\b_総括表_雛形.xls", filename

        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If

        Try
            ' Read in nonexistent file.

            Select Case BKA_kbn
                Case = "1", "3"
                    FileCopy("C:\Client\エクセル雛形\b_総括表_雛形.xls", filename)
                Case = "2"
                    FileCopy("C:\Client\エクセル雛形\k_総括表_雛形.xls", filename)
            End Select
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try

        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "biccamera"
        xlSheet = xlSheets.Item(1)  'Sheet1

        With xlApp
            With .Worksheets(1)

                Dim rw As Integer

                For i = 0 To DtView1.Count - 1
                    If DtView1(i)("P_SEQ") = 0 Then
                        rw = 1
                        .Cells(rw, 1) = DtView1(i)("項目名")
                    Else
                        Select Case DtView1(i)("P_SEQ")
                            Case Is = 1
                                rw = 6
                            Case Is = 2
                                rw = 8
                            Case Is = 3
                                rw = 9
                            Case Is = 4
                                rw = 10
                            Case Is = 5
                                rw = 11
                            Case Is = 6
                                rw = 12
                        End Select
                        .Cells(rw, 2) = DtView1(i)("総合件数")
                        .Cells(rw, 3) = DtView1(i)("総合金額")
                        .Cells(rw, 6) = DtView1(i)("長期3年件数")
                        .Cells(rw, 7) = DtView1(i)("長期3年金額")
                        .Cells(rw, 8) = DtView1(i)("長期5年件数")
                        .Cells(rw, 9) = DtView1(i)("長期5年金額")
                        .Cells(rw, 10) = DtView1(i)("長期10年件数")
                        .Cells(rw, 11) = DtView1(i)("長期10年金額")
                        .Cells(rw, 12) = DtView1(i)("住設10年件数")
                        .Cells(rw, 13) = DtView1(i)("住設10年金額")
                    End If
                Next
            End With
        End With

        Select Case BKA_kbn
            Case = "1"
                SaveFileDialog1.FileName = "b_総括表_" & テキスト25.Text & ".xls"
            Case = "2"
                SaveFileDialog1.FileName = "k_総括表_" & テキスト25.Text & ".xls"
            Case = "3"
                SaveFileDialog1.FileName = "ab_総括表_" & テキスト25.Text & ".xls"
        End Select
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = True
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try

        ' 終了処理　
        'MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)              'xlApp を開放

    End Sub

    '---------------------------------------------------------------------------------------
    '   店舗別総括表出力
    '---------------------------------------------------------------------------------------
    Sub SHOP(BKA_kbn As String)

        Select Case BKA_kbn
            Case = "1"
                waitDlg.MainMsg = "ビックカメラ店別請求書作成中"    ' 進行状況ダイアログのメーターを設定 Need to change based on report
            Case = "2"
                waitDlg.MainMsg = "コジマ店別請求書作成中"           ' 進行状況ダイアログのメーターを設定 Need to change based on report
            Case = "3"
                waitDlg.MainMsg = "エアービック店別請求書作成中"    ' 進行状況ダイアログのメーターを設定 Need to change based on report
        End Select
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Application.DoEvents()                                  ' メッセージ処理を促して表示を更新する

        '店舗マスタ
        DB_OPEN("bicdb_WK")
        strSQL = "DELETE FROM SHOP"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("bicdb")
        DsList1.Clear()
        Select Case BKA_kbn
            Case = "1"
                strSQL = "SELECT SHOP_CODE, SHOP_NAME FROM SHOP WHERE (bk_kbn = '1') AND (airbic = 0)"
            Case = "2"
                strSQL = "SELECT SHOP_CODE, SHOP_NAME FROM SHOP WHERE (bk_kbn = '2') AND (airbic = 0)"
            Case = "3"
                strSQL = "SELECT SHOP_CODE, SHOP_NAME FROM SHOP WHERE (airbic = 1)"
        End Select
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "SHOP")
        DB_CLOSE()
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("SHOP"), "", "", DataViewRowState.CurrentRows)
            DB_OPEN("bicdb_WK")
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP"
                strSQL += " (SHOP_CODE, SHOP_NAME)"
                strSQL += " VALUES ('" & DtView1(i)("SHOP_CODE") & "'"  'SHOP_CODE
                strSQL += ", '" & DtView1(i)("SHOP_NAME") & "'"         'SHOP_NAME
                strSQL += ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
            DB_CLOSE()
        End If

        DB_OPEN("bicdb_WK")

        strSQL = "DELETE FROM SHOP_OUT_A00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DELETE FROM SHOP_OUT_C00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        '総合補償Aデータ
        DsList1.Clear()
        strSQL = "SELECT SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '00') AND (SALE_STS = '00')"
        strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " AND (BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "00A")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("00A"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_A00 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        '総合補償Cデータ
        DsList1.Clear()
        strSQL = "SELECT txt_data.SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '00') AND (txt_data.SALE_STS = '09')"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " AND (txt_data.BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY txt_data.SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "00C")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("00C"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_C00 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        strSQL = "DELETE FROM SHOP_OUT_A03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DELETE FROM SHOP_OUT_C03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        '長期保証3年Aデータ
        DsList1.Clear()
        strSQL = "SELECT SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '03') AND (SALE_STS = '00')"
        strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " AND (BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "03A")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("03A"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_A03 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        '長期保証3年Cデータ
        DsList1.Clear()
        strSQL = "SELECT txt_data.SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '03') AND (txt_data.SALE_STS = '09') AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY txt_data.SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "03C")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("03C"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_C03 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        strSQL = "DELETE FROM SHOP_OUT_A05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DELETE FROM SHOP_OUT_C05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        '長期保証5年Aデータ
        DsList1.Clear()
        strSQL = "SELECT SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '05') AND (SALE_STS = '00')"
        'strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " AND (BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "05A")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("05A"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_A05 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        '長期保証5年Cデータ
        DsList1.Clear()
        strSQL = "SELECT txt_data.SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '05') AND (txt_data.SALE_STS = '09') AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        'strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY txt_data.SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "05C")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("05C"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_C05 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        strSQL = "DELETE FROM SHOP_OUT_A10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DELETE FROM SHOP_OUT_C10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        '長期保証10年Aデータ
        DsList1.Clear()
        strSQL = "SELECT SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '10') AND (SALE_STS = '00')"
        strSQL += " AND (CAT_CODE <> '253091') AND (CAT_CODE <> '255010') AND (CAT_CODE <> '255011') AND (CAT_CODE <> '253090') AND (CAT_CODE <> '253062') AND (CAT_CODE <> '255160')"
        strSQL += " AND (BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "10A")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("10A"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_A10 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        '長期保証10年Cデータ
        DsList1.Clear()
        strSQL = "SELECT txt_data.SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09') AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " AND (txt_data.CAT_CODE <> '253091') AND (txt_data.CAT_CODE <> '255010') AND (txt_data.CAT_CODE <> '255011') AND (txt_data.CAT_CODE <> '253090') AND (txt_data.CAT_CODE <> '253062') AND (txt_data.CAT_CODE <> '255160')"
        strSQL += " AND (txt_data.BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY txt_data.SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "10C")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("10C"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_C10 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        strSQL = "DELETE FROM SHOP_OUT_A10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        strSQL = "DELETE FROM SHOP_OUT_C10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        '住設保証10年Aデータ
        DsList1.Clear()
        strSQL = "SELECT SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, PRICE)) AS PRICE"
        strSQL += " FROM txt_data"
        strSQL += " WHERE (WRN_PRD = '10') AND (SALE_STS = '00')"
        strSQL += " AND ((CAT_CODE = '253091') OR (CAT_CODE = '255010') OR (CAT_CODE = '255011') OR (CAT_CODE = '253090') OR (CAT_CODE = '253062') OR (CAT_CODE = '255160'))"
        strSQL += " AND (BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "10A_2")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("10A_2"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_A10_2 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        '住設保証10年Cデータ
        DsList1.Clear()
        strSQL = "SELECT txt_data.SHOP_CODE, COUNT(*) AS cnt, SUM(CONVERT(decimal, txt_data.PRICE)) AS PRICE"
        strSQL += " FROM txt_data INNER JOIN"
        strSQL += " WRN_DATA ON txt_data.WRN_NO = WRN_DATA.WRN_NO"
        strSQL += " WHERE (txt_data.WRN_PRD = '10') AND (txt_data.SALE_STS = '09') AND (txt_data.EX IS NULL)"
        strSQL += " AND (WRN_DATA.WRN_DATE >= CONVERT(DATETIME, '" & テキスト10.Text & "', 102))"
        strSQL += " AND (WRN_DATA.WRN_DATE <= CONVERT(DATETIME, '" & テキスト17.Text & "', 102))"
        strSQL += " AND ((txt_data.CAT_CODE = '253091') OR (txt_data.CAT_CODE = '255010') OR (txt_data.CAT_CODE = '255011') OR (txt_data.CAT_CODE = '253090') OR (txt_data.CAT_CODE = '253062') OR (txt_data.CAT_CODE = '255160'))"
        strSQL += " AND (txt_data.BK_KBN = '" & BKA_kbn & "')"
        strSQL += " GROUP BY txt_data.SHOP_CODE"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "10C_2")
        If r <> 0 Then
            DtView1 = New DataView(DsList1.Tables("10C_2"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                strSQL = "INSERT INTO SHOP_OUT_C10_2 (SHOP_CODE, 件数, 購入金額) VALUES ('" & DtView1(i)("SHOP_CODE") & "', " & DtView1(i)("cnt") & ", " & DtView1(i)("PRICE") & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        '*********************
        ''合算
        '*********************
        SqlCmd1 = New SqlClient.SqlCommand("sp_Q_99_合算2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        strSQL = "INSERT INTO SHOP_OUT (SHOP_CODE, SHOP_NAME) VALUES ('0', '" & テキスト1.Text & "～" & テキスト3.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 600
        SqlCmd1.ExecuteNonQuery()

        '*********************
        ''エクセル出力
        '*********************

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$
        filename = "c:\temp\temp.xls"

        If System.IO.File.Exists(filename) = True Then
            System.IO.File.Delete(filename)
        End If

        Try
            Select Case BKA_kbn
                Case = "1", "3"
                    FileCopy("C:\Client\エクセル雛形\b_店別請求書_雛形.xls", filename)
                Case = "2"
                    FileCopy("C:\Client\エクセル雛形\k_店別請求書_雛形.xls", filename)
            End Select
        Catch ex As Exception
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try
        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "biccamera"
        xlSheet = xlSheets.Item(1)  'Sheet1

        With xlApp
            With .Worksheets(1)

                Dim rw As Integer
                rw = 3
                For i = 0 To DtView1.Count - 1
                    If DtView1(i)("SHOP_CODE") = "0" Then
                        .Cells(1, 1) = DtView1(i)("SHOP_NAME")
                    Else
                        rw += 1
                        .Cells(rw, 1) = "=CONCAT(""" & DtView1(i)("SHOP_NAME") & """)"
                        .Cells(rw, 2) = DtView1(i)("総合件数")
                        .Cells(rw, 3) = DtView1(i)("総合金額")
                        .Cells(rw, 6) = DtView1(i)("長期3年件数")
                        .Cells(rw, 7) = DtView1(i)("長期3年金額")
                        .Cells(rw, 8) = DtView1(i)("長期5年件数")
                        .Cells(rw, 9) = DtView1(i)("長期5年金額")
                        .Cells(rw, 10) = DtView1(i)("長期10年件数")
                        .Cells(rw, 11) = DtView1(i)("長期10年金額")
                        .Cells(rw, 12) = DtView1(i)("住設10年件数")
                        .Cells(rw, 13) = DtView1(i)("住設10年金額")
                    End If

                Next
                rw = rw + 2
                .Rows(rw & ":300").Delete()
                .Range("A1").Select
            End With
        End With

        Select Case BKA_kbn
            Case = "1"
                SaveFileDialog1.FileName = "b_店別請求書_" & テキスト25.Text & ".xls"
            Case = "2"
                SaveFileDialog1.FileName = "k_店別請求書_" & テキスト25.Text & ".xls"
            Case = "3"
                SaveFileDialog1.FileName = "ab_店別請求書_" & テキスト25.Text & ".xls"
        End Select
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = True
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try

        ' 終了処理　
        'MRComObject(xlRange)            'xlRange の開放
        MRComObject(xlSheet)            'xlSheet の開放
        MRComObject(xlSheets)           'xlSheets の開放
        xlBook.Close(False)             'xlBook を閉じる
        MRComObject(xlBook)             'xlBook の開放
        MRComObject(xlBooks)            'xlBooks の開放
        xlApp.Quit()                    'Excelを閉じる    
        MRComObject(xlApp)

    End Sub
End Class
