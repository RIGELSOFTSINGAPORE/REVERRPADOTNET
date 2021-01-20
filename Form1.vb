Imports System.Threading
Imports System.Globalization

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private objMutex As System.Threading.Mutex

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsExp As New DataSet
    Dim DtView1 As DataView
    Dim reader As SqlClient.SqlDataReader

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim From_date, To_date As Date
    Dim strSQL, Err_F, ptn_F, inz_F As String
    Dim i, j As Integer
    Dim errcnt As Boolean
    Dim errcntmsg As String
    Friend WithEvents テキスト17 As TextBox
    Friend WithEvents テキスト10 As TextBox
    Friend WithEvents テキスト13 As TextBox
    Friend WithEvents ラベル14 As Label
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
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button99 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.テキスト17 = New System.Windows.Forms.TextBox()
        Me.テキスト10 = New System.Windows.Forms.TextBox()
        Me.テキスト13 = New System.Windows.Forms.TextBox()
        Me.ラベル14 = New System.Windows.Forms.Label()
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
        Me.Button99.Location = New System.Drawing.Point(358, 144)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(110, 32)
        Me.Button99.TabIndex = 3
        Me.Button99.Text = "終了"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(130, 149)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(110, 32)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "集計"
        '
        'テキスト17
        '
        Me.テキスト17.Location = New System.Drawing.Point(621, 173)
        Me.テキスト17.Name = "テキスト17"
        Me.テキスト17.ReadOnly = True
        Me.テキスト17.Size = New System.Drawing.Size(118, 26)
        Me.テキスト17.TabIndex = 113
        Me.テキスト17.Tag = ""
        Me.テキスト17.Visible = False
        '
        'テキスト10
        '
        Me.テキスト10.Location = New System.Drawing.Point(358, 102)
        Me.テキスト10.Name = "テキスト10"
        Me.テキスト10.ReadOnly = True
        Me.テキスト10.Size = New System.Drawing.Size(110, 26)
        Me.テキスト10.TabIndex = 110
        Me.テキスト10.Visible = False
        '
        'テキスト13
        '
        Me.テキスト13.Location = New System.Drawing.Point(150, 106)
        Me.テキスト13.Name = "テキスト13"
        Me.テキスト13.Size = New System.Drawing.Size(71, 26)
        Me.テキスト13.TabIndex = 107
        Me.テキスト13.Text = "C"
        '
        'ラベル14
        '
        Me.ラベル14.AutoSize = True
        Me.ラベル14.Location = New System.Drawing.Point(49, 108)
        Me.ラベル14.Name = "ラベル14"
        Me.ラベル14.Size = New System.Drawing.Size(117, 19)
        Me.ラベル14.TabIndex = 106
        Me.ラベル14.Text = "出力先ﾄﾞﾗｲﾌﾞ"
        Me.ラベル14.Visible = False
        '
        'テキスト25
        '
        Me.テキスト25.Location = New System.Drawing.Point(621, 78)
        Me.テキスト25.Name = "テキスト25"
        Me.テキスト25.ReadOnly = True
        Me.テキスト25.Size = New System.Drawing.Size(118, 26)
        Me.テキスト25.TabIndex = 105
        Me.テキスト25.Visible = False
        '
        'テキスト3
        '
        Me.テキスト3.Font = New System.Drawing.Font("MS PGothic", 14.0!)
        Me.テキスト3.Location = New System.Drawing.Point(328, 76)
        Me.テキスト3.MaxLength = 10
        Me.テキスト3.Name = "テキスト3"
        Me.テキスト3.Size = New System.Drawing.Size(124, 26)
        Me.テキスト3.TabIndex = 1
        Me.テキスト3.Text = "ラベル4"
        '
        'ラベル4
        '
        Me.ラベル4.AutoSize = True
        Me.ラベル4.Font = New System.Drawing.Font("MS PGothic", 14.0!)
        Me.ラベル4.Location = New System.Drawing.Point(282, 78)
        Me.ラベル4.Name = "ラベル4"
        Me.ラベル4.Size = New System.Drawing.Size(28, 19)
        Me.ラベル4.TabIndex = 103
        Me.ラベル4.Text = "～"
        '
        'テキスト1
        '
        Me.テキスト1.Font = New System.Drawing.Font("MS PGothic", 14.0!)
        Me.テキスト1.Location = New System.Drawing.Point(131, 76)
        Me.テキスト1.MaxLength = 10
        Me.テキスト1.Name = "テキスト1"
        Me.テキスト1.Size = New System.Drawing.Size(124, 26)
        Me.テキスト1.TabIndex = 0
        Me.テキスト1.Text = "ラベル2"
        '
        'ラベル2
        '
        Me.ラベル2.AutoSize = True
        Me.ラベル2.Font = New System.Drawing.Font("MS PGothic", 14.0!)
        Me.ラベル2.Location = New System.Drawing.Point(65, 82)
        Me.ラベル2.Name = "ラベル2"
        Me.ラベル2.Size = New System.Drawing.Size(66, 19)
        Me.ラベル2.TabIndex = 101
        Me.ラベル2.Text = "処理日"
        '
        'テキスト19
        '
        Me.テキスト19.Location = New System.Drawing.Point(99, 38)
        Me.テキスト19.Name = "テキスト19"
        Me.テキスト19.ReadOnly = True
        Me.テキスト19.Size = New System.Drawing.Size(156, 26)
        Me.テキスト19.TabIndex = 116
        Me.テキスト19.Visible = False
        '
        'テキスト21
        '
        Me.テキスト21.Location = New System.Drawing.Point(444, 38)
        Me.テキスト21.Name = "テキスト21"
        Me.テキスト21.ReadOnly = True
        Me.テキスト21.Size = New System.Drawing.Size(127, 26)
        Me.テキスト21.TabIndex = 117
        Me.テキスト21.Visible = False
        '
        'date_from
        '
        Me.date_from.Location = New System.Drawing.Point(504, 102)
        Me.date_from.Name = "date_from"
        Me.date_from.ReadOnly = True
        Me.date_from.Size = New System.Drawing.Size(95, 26)
        Me.date_from.TabIndex = 118
        Me.date_from.Tag = ""
        Me.date_from.Visible = False
        '
        'date_to
        '
        Me.date_to.Location = New System.Drawing.Point(621, 130)
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
        Me.ClientSize = New System.Drawing.Size(518, 221)
        Me.Controls.Add(Me.date_to)
        Me.Controls.Add(Me.date_from)
        Me.Controls.Add(Me.テキスト21)
        Me.Controls.Add(Me.テキスト19)
        Me.Controls.Add(Me.テキスト17)
        Me.Controls.Add(Me.テキスト10)
        Me.Controls.Add(Me.テキスト13)
        Me.Controls.Add(Me.ラベル14)
        Me.Controls.Add(Me.テキスト25)
        Me.Controls.Add(Me.テキスト3)
        Me.Controls.Add(Me.ラベル4)
        Me.Controls.Add(Me.テキスト1)
        Me.Controls.Add(Me.ラベル2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS PGothic", 14.0!)
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
        テキスト13.Text = "E"
        objMutex = New System.Threading.Mutex(False, "Bic_Report_soukatsu")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        Call DB_INIT()

        If Mid(Now, 9, 2) <= "15" Then

            From_date = Mid(DateAdd("m", -1, Now), 1, 8) & "01"         'From

            ' Forms![フォーム1]![テキスト1] = From_date
            テキスト1.Text = From_date
            To_date = DateAdd("m", 1, From_date)
            To_date = DateAdd("d", -1, To_date)                         'To

            テキスト3.Text = To_date
            テキスト17.Text = To_date
            'Forms![フォーム1]![テキスト3] = To_date                     'To

            'Forms![フォーム1]![テキスト17] = To_date                    '
        Else
            From_date = Mid(Now, 1, 8) & "01"                           'From
            'Forms![フォーム1]![テキスト1] = From_date
            テキスト1.Text = Mid(Now, 1, 8) & "01"
            To_date = Mid(Now, 1, 8) & "15"                             'To


            'Forms![フォーム1]![テキスト3] = To_date                     'To

            'Forms![フォーム1]![テキスト17] = DateAdd("d", -1, From_date)    '

            テキスト3.Text = To_date
            テキスト17.Text = DateAdd("d", -1, From_date)
        End If

        'Forms![フォーム1]![テキスト19] = "CYOKI." & Mid(From_date, 3, 2) & Mid(From_date, 6, 2) & Mid(From_date, 9, 2)  'From
        'Forms![フォーム1]![テキスト21] = "CYOKI." & Mid(To_date, 3, 2) & Mid(To_date, 6, 2) & Mid(To_date, 9, 2)        'To
        テキスト19.Text = "CYOKI." & Mid(From_date, 3, 2) & Mid(From_date, 6, 2) & Mid(From_date, 9, 2)  'From
        テキスト21.Text = "CYOKI." & Mid(To_date, 3, 2) & Mid(To_date, 6, 2) & Mid(To_date, 9, 2)        'To


        'テキスト1_LostFocus
        'テキスト3_LostFocus
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

        'テキスト1_LostFocus(sender, e)
        'テキスト3_LostFocus(sender, e)
    End Sub




    Sub XLS_OUT()
        'エクセル出力
        waitDlg.MainMsg = "ショップマスター"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("bicdb")
        'r = DaList1.Fill(DsExp)
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$

        filename = テキスト13.Text & ":\BIC集計\k_店別請求書_" & テキスト25.Text & ".xls"




        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If
        Try
            ' Read in nonexistent file.
            FileCopy("C:\Client\エクセル雛形\k_店別請求書_雛形.xls", filename)
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try



        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "kojima"
        xlSheet = xlSheets.Item(1)  'Sheet1

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        With xlApp
            With .Worksheets(1)

                Dim rw As Integer
                rw = 3
                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
                    'waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                    If DtView1(i)("SHOP_CODE") = "0" Then

                        .Cells(1, 1) = DtView1(i)("SHOP_NAME")

                    Else
                        rw += 1
                        .Cells(rw, 1) = DtView1(i)("SHOP_NAME")
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




        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()

        Try
            xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
        Catch ex As System.Exception
            Exit Sub
        End Try


        Me.Enabled = True

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

    '新規登録ボタン




    'データ出力ボタン
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'waitDlg = New WaitDialog        ' 進行状況ダイアログ
        'waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        'waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        'waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        'waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        'waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        'waitDlg.ProgressValue = 0       ' 最初の件数を設定
        'Me.Enabled = False              ' オーナーのフォームを無効にする
        'waitDlg.Show()                  ' 進行状況ダイアログを表示する

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




        'Call XLS_OUT()
        If (Not System.IO.Directory.Exists("C:\BIC集計")) Then
            System.IO.Directory.CreateDirectory("C:\BIC集計")
        End If


        'waitDlg.Close()                 ' 進行状況ダイアログを閉じる

        Call コマンド0Main()

        If errcnt = True Then
            MsgBox(errcntmsg)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        'Exit Sub
        'Exit Sub
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



        Call WK_crt_bic()


        waitDlg.Close()                 ' 進行状況ダイアログを閉じる


        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する



        Call WK_crt_bic_2()


        waitDlg.Close()                 ' 進行状況ダイアログを閉じる

        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する



        Call WK_crt_kojima()


        waitDlg.Close()                 ' 進行状況ダイアログを閉じる

        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する


        Call SHOP_crt_bic()

        waitDlg.Close()                 ' 進行状況ダイアログを閉じる


        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する



        '        '***************
        '        '店別請求書出力
        '        '***************

        Call SHOP_crt_bic_2()




        waitDlg.Close()                 ' 進行状況ダイアログを閉じる

        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        Me.Enabled = False              ' オーナーのフォームを無効にする
        waitDlg.Show()                  ' 進行状況ダイアログを表示する


        '        '***************
        '        '店別請求書出力
        '        '***************

        Call SHOP_crt_kojima()





        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Me.Activate()                   ' いったんオーナーをアクティブにする
        Me.Enabled = True               ' オーナーのフォームを有効にする

        'If (System.IO.Directory.Exists("C:\BIC集計")) Then

        '    Try
        '        Thread.Sleep(2000)


        '        System.IO.Directory.Delete("C:\BIC集計", recursive:=True)
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '        Exit Sub
        '    End Try
        'End If

        MsgBox("出力しました。", , "")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '終了ボタン
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
    End Sub
    'Private Sub テキスト3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles テキスト3.LostFocus
    '    'Forms![フォーム1]![date_to] = Mid([Forms]![フォーム1]![テキスト3], 1, 4) & Mid([Forms]![フォーム1]![テキスト3], 6, 2) & Mid([Forms]![フォーム1]![テキスト3], 9, 2)
    '    'To_date = [Forms]![フォーム1]![テキスト3]
    '    'Forms![フォーム1]![テキスト21] = "CYOKI." & Mid(To_date, 3, 2) & Mid(To_date, 6, 2) & Mid(To_date, 9, 2)        'To
    '    't10_set()
    '    dformat = "yyyy/MM/dd"
    '    If DateTime.TryParseExact(テキスト3.Text, dformat, New CultureInfo("en-US"), DateTimeStyles.None, dateval) Then

    '    Else
    '        Me.Activate()                   ' いったんオーナーをアクティブにする
    '        Me.Enabled = True               ' オーナーのフォームを有効にする
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        MessageBox.Show("有効な日付を入力してください")
    '        テキスト3.Focus()
    '        Exit Sub
    '    End If
    '    date_to.Text = Mid(テキスト3.Text, 1, 4) & Mid(テキスト3.Text, 6, 2) & Mid(テキスト3.Text, 9, 2)
    '    To_date = テキスト3.Text
    '    テキスト21.Text = "CYOKI." & Mid(To_date, 3, 2) & Mid(To_date, 6, 2) & Mid(To_date, 9, 2)        'To
    '    t10_set()
    'End Sub
    'Private Sub テキスト1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles テキスト1.LostFocus
    '    'If Forms![フォーム1]![テキスト1] = Null Or Forms![フォーム1]![テキスト1] = "" Then
    '    'Else
    '    '    Forms![フォーム1]![date_from] = Mid([Forms]![フォーム1]![テキスト1], 1, 4) & Mid([Forms]![フォーム1]![テキスト1], 6, 2) & Mid([Forms]![フォーム1]![テキスト1], 9, 2)
    '    '    WK_date = DateAdd("m", -5, Forms![フォーム1]![テキスト1])
    '    '    If WK_date < "2007/05/20" Then
    '    '        Forms![フォーム1]![テキスト10] = "2007/05/20"
    '    '    Else
    '    '        Forms![フォーム1]![テキスト10] = "2007/05/20"
    '    '    End If
    '    '    From_date = [Forms]![フォーム1]![テキスト1]
    '    '    Forms![フォーム1]![テキスト19] = "CYOKI." & Mid(From_date, 3, 2) & Mid(From_date, 6, 2) & Mid(From_date, 9, 2)  'From
    '    'End If
    '    dformat = "yyyy/MM/dd"
    '    If DateTime.TryParseExact(テキスト1.Text, dformat, New CultureInfo("en-US"), DateTimeStyles.None, dateval) Then

    '    Else
    '        Me.Activate()                   ' いったんオーナーをアクティブにする
    '        Me.Enabled = True               ' オーナーのフォームを有効にする
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        MessageBox.Show("有効な日付を入力してください")
    '        テキスト1.Focus()
    '        Exit Sub
    '    End If

    '    Dim WK_date As DateTime

    '    If テキスト1.Text = Nothing Or テキスト1.Text = "" Then
    '    Else
    '        date_from.Text = Mid(テキスト1.Text, 1, 4) & Mid(テキスト1.Text, 6, 2) & Mid(テキスト1.Text, 9, 2)
    '        WK_date = DateAdd("m", -5, テキスト1.Text)
    '        If WK_date < "2007/05/20" Then
    '            テキスト10.Text = "2007/05/20"
    '        Else
    '            テキスト10.Text = "2007/05/20"
    '        End If
    '        From_date = テキスト1.Text
    '        テキスト19.Text = "CYOKI." & Mid(From_date, 3, 2) & Mid(From_date, 6, 2) & Mid(From_date, 9, 2)  'From
    '    End If

    '    t10_set()
    'End Sub
    Sub t10_set()

        'If Format(Forms![フォーム1]![テキスト1], "dd") = "01" _
        '    And Format(DateAdd("d", 1, Forms![フォーム1]![テキスト3]), "dd") = "01" Then
        '    Forms![フォーム1]![テキスト25] = Mid(Forms![フォーム1]![date_from], 1, 6)
        'Else
        '    Forms![フォーム1]![テキスト25] = Forms![フォーム1]![date_from] & "_" & Mid(Forms![フォーム1]![date_to], 7, 8)
        'End If
        'If DateTime.TryParseExact(テキスト1.Text, dformat, New CultureInfo("en-US"), DateTimeStyles.None, dateval) Then

        'Else
        '    Me.Activate()                   ' いったんオーナーをアクティブにする
        '    Me.Enabled = True               ' オーナーのフォームを有効にする
        '    Me.Cursor = System.Windows.Forms.Cursors.Default
        '    MessageBox.Show("テキスト1 無効な日付")
        '    Exit Sub
        'End If

        'If DateTime.TryParseExact(テキスト3.Text, dformat, New CultureInfo("en-US"), DateTimeStyles.None, dateval) Then

        'Else
        '    Me.Activate()                   ' いったんオーナーをアクティブにする
        '    Me.Enabled = True               ' オーナーのフォームを有効にする
        '    Me.Cursor = System.Windows.Forms.Cursors.Default
        '    MessageBox.Show("テキスト3 無効な日付")
        '    Exit Sub
        'End If

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
        DB_OPEN("bicdb")
        'strSQL = "ALTER INDEX ALL ON txt_data DISABLE;DELETE FROM txt_data;"
        'strSQL = "ALTER INDEX ALL ON txt_data DISABLE; DELETE FROM txt_data Where substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " ;"
        'strSQL = "DELETE FROM txt_data Where substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " ;"
        strSQL = "DELETE FROM txt_data"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("bicdb")
        strSQL = "DBCC CHECKIDENT('txt_data', RESEED, 0);"
        'strSQL = "TRUNCATE TABLE Dbo_WRN_DATA"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("bicdb")
        SqlCmd1 = New SqlClient.SqlCommand("Q_01_txt_data_all", cnsqlclient)
        SqlCmd1.Parameters.Add("@start_date", テキスト19.Text.Substring(6, 6))
        SqlCmd1.Parameters.Add("@end_date", テキスト21.Text.Substring(6, 6))
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("bicdb")
        strSQL = "DELETE FROM txt_data WHERE (txt_data.WRN_DATE)>" & date_to.Text
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()


        'Dim msg As String
        errcntmsg = "店舗マスタ未登録　店舗コード:"
        DB_OPEN("bicdb")
        SqlCmd1 = New SqlClient.SqlCommand("Q_02_shop_err", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        'SqlCmd1.ExecuteReader()
        SqlCmd1.CommandTimeout = 10000
        reader = SqlCmd1.ExecuteReader()
        While reader.Read()
            errcnt = True
            'MsgBox(reader.Item(0))
            errcntmsg += reader.Item("SHOP_CODE") & " "
        End While
        reader.Close()
        DB_CLOSE()

        If errcnt = True Then
            Exit Sub
        End If
        'Exit Sub

        'Cursor = Cursors.Default

        'DB_OPEN("bicdb")
        'SqlCmd1 = New SqlClient.SqlCommand("Q_Dbo_WRN_DATA", cnsqlclient)
        'SqlCmd1.CommandType = CommandType.StoredProcedure
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        'begin comment 2020-12-18

        DB_OPEN("bicdb")
        strSQL = "DELETE FROM Dbo_WRN_DATA;"
        'strSQL = "TRUNCATE TABLE Dbo_WRN_DATA"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()


        DB_OPEN("bicdb")
        SqlCmd1 = New SqlClient.SqlCommand("Q_04_WRN_DATA", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()


        DB_OPEN("bicdb") 'Execution Timeout Expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.'
        strSQL = "UPDATE Dbo_WRN_DATA SET Dbo_WRN_DATA.SALE_STS = '00'"
        strSQL = strSQL & " WHERE (((Dbo_WRN_DATA.SALE_STS)='09')"
        strSQL = strSQL & " AND ((Dbo_WRN_DATA.CXL_DATE) > '" & テキスト17.Text & "'))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        DB_OPEN("bicdb") 'Execution Timeout Expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.'
        strSQL = " update txt_data set Ex = '1' where txtdata_ID in "
        strSQL = strSQL & " ( "
        strSQL = strSQL & " select txtdata_ID from txt_data where wrn_no in "
        strSQL = strSQL & " ( "
        strSQL = strSQL & " select wrn_no from txt_data "
        strSQL = strSQL & " where SALE_STS = '09' "
        strSQL = strSQL & " group by wrn_no having count(*) > 1 "
        strSQL = strSQL & " ) "
        strSQL = strSQL & " and SALE_STS = '09' and txtdata_ID not in "
        strSQL = strSQL & " ( "
        strSQL = strSQL & " select max(txtdata_ID) from txt_data where wrn_no in "
        strSQL = strSQL & " ( "
        strSQL = strSQL & " select wrn_no from txt_data "
        strSQL = strSQL & " where SALE_STS = '09' "
        strSQL = strSQL & " group by wrn_no having count(*) > 1 "
        strSQL = strSQL & " ) "
        strSQL = strSQL & " and SALE_STS = '09' group by wrn_no "
        strSQL = strSQL & " ) "
        strSQL = strSQL & " ) "
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        'end comment 2020-12-18
        'DB_OPEN("bicdb")
        'strSQL = "DELETE FROM [txt_data_TEMP];"
        ''strSQL = "TRUNCATE TABLE Dbo_WRN_DATA"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        'DB_OPEN("bicdb")
        'strSQL = "DBCC CHECKIDENT('txt_data_TEMP', RESEED, 0);"
        ''strSQL = "TRUNCATE TABLE Dbo_WRN_DATA"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        'DB_OPEN("bicdb")
        'strSQL = "insert into txt_data_TEMP "
        'strSQL = strSQL & " select * "
        'strSQL = strSQL & " from txt_data where WRN_NO in ( "
        'strSQL = strSQL & " select wrn_no from txt_data where SALE_STS = '09' "
        'strSQL = strSQL & " group by wrn_no having count(*) > 1 ) and SALE_STS = '09' "
        ''strSQL = "TRUNCATE TABLE Dbo_WRN_DATA"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        'DB_OPEN("bicdb")
        'strSQL = "update txt_data_TEMP set Ex= '1' where WRN_NO_PKID not in "
        'strSQL = strSQL & " (SELECT MAX(WRN_NO_PKID) WRN_NO_PKID FROM txt_data_TEMP GROUP BY WRN_NO ) "
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        'DB_OPEN("bicdb")
        'strSQL = "delete from txt_data where SALE_STS = '09' and WRN_NO in ( "
        'strSQL = strSQL & " select WRN_NO from txt_data_TEMP ) "
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        'DB_OPEN("bicdb")
        'strSQL = "insert into txt_data "
        'strSQL = strSQL & " select WRN_NO,SHOP_CODE,ITEM_CODE,MODEL,CAT_CODE,CAT_NAME,MKR_CODE,MKR_NAME, "
        'strSQL = strSQL & " PRICE,WRN_PRICE,WRN_PRD,SALE_STS,CRT_DATE,CLS_MNTH,PNT_NO,CUST_NAME,ZIP1, "
        'strSQL = strSQL & " ZIP2,ADRS1,ADRS2,SEX,BRTH_DATE,TEL_NO,CNT_NO,EX,IMPT_FILE,BK_KBN,WRN_DATE "
        'strSQL = strSQL & " From txt_data_TEMP "
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        ''DB_OPEN("bicdb")
        ''strSQL = "update txt_data set EX = '1' where WRN_NO in "
        '''strSQL = strSQL & " (select WRN_NO from txt_data where SALE_STS = '09' and substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " group by WRN_NO "
        ''strSQL = strSQL & " (select WRN_NO from txt_data where SALE_STS = '09' group by WRN_NO "
        ''strSQL = strSQL & " having count(WRN_NO) > 1) "
        ''strSQL = strSQL & " And  SALE_STS = '09' "
        ''SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        ''SqlCmd1.CommandTimeout = 10000
        ''SqlCmd1.ExecuteNonQuery()
        '''Where substring(txt_data_all.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data_all.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " ;"
        ''DB_CLOSE()


    End Sub
    Sub WK_crt_bic()

        DB_OPEN("bicdb")
        strSQL = "DELETE FROM WK_OUT_00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = " INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='00')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= "isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='00') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= "isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And "
        strSQL &= "(txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= "And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= "isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='00') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= "isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= "isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.SALE_STS='09') "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM WK_OUT_03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= "isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='03')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= "isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='03') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='03') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.SALE_STS='09') "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM WK_OUT_05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='05')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        ' strSQL &= " GROUP BY 1"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='05') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='05') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.SALE_STS='09') "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM WK_OUT_10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='10')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM WK_OUT_10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='10')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' Or "
        strSQL &= " (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' Or "
        strSQL &= " (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 1"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' Or "
        strSQL &= " (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 2"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 3"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 4"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 5"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE)  NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 6"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()


        DB_CLOSE()


        DB_OPEN("bicdb")
        '合算
        'DoCmd.OpenQuery "Q_99_合算", , acEdit
        SqlCmd1 = New SqlClient.SqlCommand("Q_99_合算", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.総合件数 = 0 WHERE (((WK_OUT.総合件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.総合件数 = 0 WHERE (((WK_OUT.総合件数) Is Null))"
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.総合金額 = 0 WHERE (((WK_OUT.総合金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.総合金額 = 0 WHERE (((WK_OUT.総合金額) Is Null))"
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期3年件数 = 0 WHERE (((WK_OUT.長期3年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期3年件数 = 0 WHERE (((WK_OUT.長期3年件数) Is Null))"
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期3年金額 = 0 WHERE (((WK_OUT.長期3年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期3年金額 = 0 WHERE (((WK_OUT.長期3年金額) Is Null))"
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期5年件数 = 0 WHERE (((WK_OUT.長期5年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期5年件数 = 0 WHERE (((WK_OUT.長期5年件数) Is Null))"

        strSQL = "UPDATE WK_OUT SET WK_OUT.長期5年金額 = 0 WHERE (((WK_OUT.長期5年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期5年金額 = 0 WHERE (((WK_OUT.長期5年金額) Is Null))"

        strSQL = "UPDATE WK_OUT SET WK_OUT.長期10年件数 = 0 WHERE (((WK_OUT.長期10年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期10年件数 = 0 WHERE (((WK_OUT.長期10年件数) Is Null))"

        strSQL = "UPDATE WK_OUT SET WK_OUT.長期10年金額 = 0 WHERE (((WK_OUT.長期10年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期10年金額 = 0 WHERE (((WK_OUT.長期10年金額) Is Null))"
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.住設10年件数 = 0 WHERE (((WK_OUT.住設10年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.住設10年件数 = 0 WHERE (((WK_OUT.住設10年件数) Is Null))"

        strSQL = "UPDATE WK_OUT SET WK_OUT.住設10年金額 = 0 WHERE (((WK_OUT.住設10年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.住設10年金額 = 0 WHERE (((WK_OUT.住設10年金額) Is Null))"

        'タイトル
        strSQL = "INSERT INTO WK_OUT ( P_SEQ, 項目名 )"
        strSQL &= " SELECT 0 AS P_SEQ"
        strSQL &= ", '" & テキスト1.Text & "～" & テキスト3.Text & "' AS 項目名"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        waitDlg.MainMsg = "ビックカメラ総括表を出力しています。"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1

        'DB_OPEN("bicdb")
        'r = DaList1.Fill(DsExp)
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$

        filename = テキスト13.Text & ":\BIC集計\b_総括表_" & テキスト25.Text & ".xls"
        'FileCopy "C:\Client\エクセル雛形\b_総括表_雛形.xls", filename



        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If


        Try
            ' Read in nonexistent file.
            FileCopy("C:\Client\エクセル雛形\b_総括表_雛形.xls", filename)
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try

        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "biccamera"
        xlSheet = xlSheets.Item(1)  'Sheet1

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        With xlApp
            With .Worksheets(1)

                Dim rw As Integer

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
                    'waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                    If DtView1(i)("P_SEQ") = "0" Then
                        rw = 1
                        .Cells(rw, 1) = DtView1(i)("項目名")

                    Else
                        Select Case DtView1(i)("P_SEQ")
                            Case Is = "1"
                                rw = 6
                            Case Is = "2"
                                rw = 8
                            Case Is = "3"
                                rw = 9
                            Case Is = "4"
                                rw = 10
                            Case Is = "5"
                                rw = 11
                            Case Is = "6"
                                rw = 12
                        End Select
                        'xlSheet.Cells(rw, 1) = DtView1(i)("項目名")
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




        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()

        SaveFileDialog1.FileName = "b_総括表_" & テキスト25.Text & ".xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            'xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try



        Me.Enabled = True

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



    Sub WK_crt_bic_2()

        '総合補償
        'DoCmd.Echo True, "総合補償　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_00"
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM WK_OUT_00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " Select 1 As P_SEQ, Count(txt_data.WRN_NO) As WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='00')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL strSQL
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='00') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL strSQL

        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='00') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE) <>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"

        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '長期保証3年
        'DoCmd.Echo True, "長期保証3年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_03"
        strSQL = "DELETE FROM WK_OUT_03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='03')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='03') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data On Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE) <>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='03') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(Convert(numeric(18, 0), txt_data.PRICE)), 0) As PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA On txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        '長期保証5年
        'DoCmd.Echo True, "長期保証5年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_05"
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM WK_OUT_05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='05')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"


        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='05') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='05') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '長期保証10年
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_10"
        strSQL = "DELETE FROM WK_OUT_10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='10')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")

        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " AND (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '住設保証10年(【部門コード】 が　253091、255010、255011、253090、253062、255160 )
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_10_2"
        strSQL = "DELETE FROM WK_OUT_10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='10')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '    DoCmd.OpenQuery "Q_99_合算", , acEdit
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.総合件数 = 0 WHERE (((WK_OUT.総合件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.総合金額 = 0 WHERE (((WK_OUT.総合金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期3年件数 = 0 WHERE (((WK_OUT.長期3年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期3年金額 = 0 WHERE (((WK_OUT.長期3年金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期5年件数 = 0 WHERE (((WK_OUT.長期5年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期5年金額 = 0 WHERE (((WK_OUT.長期5年金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期10年件数 = 0 WHERE (((WK_OUT.長期10年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期10年金額 = 0 WHERE (((WK_OUT.長期10年金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.住設10年件数 = 0 WHERE (((WK_OUT.住設10年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.住設10年金額 = 0 WHERE (((WK_OUT.住設10年金額) Is Null))"
        '合算
        'DoCmd.OpenQuery "Q_99_合算", , acEdit

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_合算", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.総合件数 = 0 WHERE (((WK_OUT.総合件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.総合金額 = 0 WHERE (((WK_OUT.総合金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期3年件数 = 0 WHERE (((WK_OUT.長期3年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期3年金額 = 0 WHERE (((WK_OUT.長期3年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期5年件数 = 0 WHERE (((WK_OUT.長期5年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期5年金額 = 0 WHERE (((WK_OUT.長期5年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期10年件数 = 0 WHERE (((WK_OUT.長期10年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期10年金額 = 0 WHERE (((WK_OUT.長期10年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.住設10年件数 = 0 WHERE (((WK_OUT.住設10年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.住設10年金額 = 0 WHERE (((WK_OUT.住設10年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'タイトル
        strSQL = "INSERT INTO WK_OUT ( P_SEQ, 項目名 )"
        strSQL &= " SELECT 0 AS P_SEQ"
        strSQL &= ", '" & テキスト1.Text & "～" & テキスト3.Text & "' AS 項目名"
        'DoCmd.RunSQL strSQL
        DB_CLOSE()
        DB_OPEN("bicdb")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'エクスポート
        '    DoCmd.Echo True, "エクスポート中"
        '    DoCmd.TransferText acExportDelim, "エクスポート定義", "Q_99_集計", Forms![フォーム1]![テキスト13] & ":\BIC集計\AirBic総括表_" & Forms![フォーム1]![date_from] & "_" & Mid(Forms![フォーム1]![date_to], 7, 2) & ".CSV", True, ""

        waitDlg.MainMsg = "ビックカメラ総括表を出力しています。"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        'DB_OPEN("bicdb")
        'r = DaList1.Fill(DsExp)
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$

        filename = テキスト13.Text & ":\BIC集計\ab_総括表_" & テキスト25.Text & ".xls"
        'FileCopy "C:\Client\エクセル雛形\b_総括表_雛形.xls", filename



        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If


        Try
            ' Read in nonexistent file.
            FileCopy("C:\Client\エクセル雛形\b_総括表_雛形.xls", filename)
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try
        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "biccamera"
        xlSheet = xlSheets.Item(1)  'Sheet1

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        With xlApp
            With .Worksheets(1)

                Dim rw As Integer

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
                    'waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                    If DtView1(i)("P_SEQ") = "0" Then
                        rw = 1
                        .Cells(rw, 1) = DtView1(i)("項目名")

                    Else
                        Select Case DtView1(i)("P_SEQ")
                            Case Is = "1"
                                rw = 6
                            Case Is = "2"
                                rw = 8
                            Case Is = "3"
                                rw = 9
                            Case Is = "4"
                                rw = 10
                            Case Is = "5"
                                rw = 11
                            Case Is = "6"
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




        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()


        SaveFileDialog1.FileName = "ab_総括表_" & テキスト25.Text & ".xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Try
            'xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try


        Me.Enabled = True

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
    '   コジマ総括表
    '---------------------------------------------------------------------------------------
    Sub WK_crt_kojima()

        DB_OPEN("bicdb")
        '総合補償
        'DoCmd.Echo True, "総合補償　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_00"
        strSQL = "DELETE FROM WK_OUT_00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='00')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='00') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='00') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "INSERT INTO WK_OUT_00 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='00') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '長期保証3年
        'DoCmd.Echo True, "長期保証3年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_03"
        strSQL = "DELETE FROM WK_OUT_03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='03')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='03') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='03') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_03 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='03') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '長期保証5年
        'DoCmd.Echo True, "長期保証5年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_05"
        strSQL = "DELETE FROM WK_OUT_05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='05')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='05') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='05') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_05 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='05') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '長期保証10年
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_10"
        strSQL = "DELETE FROM WK_OUT_10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='10')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_10 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '住設保証10年(【部門コード】 が　253091、255010、255011、253090、253062、255160 )
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM WK_OUT_10_2"
        strSQL = "DELETE FROM WK_OUT_10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 1 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (txt_data.SALE_STS='00') AND (txt_data.WRN_PRD='10')"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 1"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 2 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 2"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_13_00_同月重複ACC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 3 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE >= '" & テキスト10.Text & "')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE <= '" & テキスト17.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 3"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_14_00_前月以前のC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 4 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.SALE_STS='09') AND (txt_data.WRN_PRD='10') AND (txt_data.EX Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 4"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_15_00_前月以前重複ACC
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 5 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM Dbo_WRN_DATA INNER JOIN txt_data ON Dbo_WRN_DATA.WRN_NO = txt_data.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.EX='1')"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE < '" & テキスト10.Text & "')"
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 5"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '⑦対応するＡがないＣ
        strSQL = "INSERT INTO WK_OUT_10_2 ( P_SEQ, 件数, 購入金額 )"
        strSQL &= " SELECT 6 AS P_SEQ, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data LEFT JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (txt_data.WRN_PRD='10') AND (txt_data.SALE_STS='09') "
        strSQL &= " And (Dbo_WRN_DATA.WRN_NO Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        'strSQL &= " GROUP BY 6"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        '合算
        '    DoCmd.OpenQuery "Q_99_合算", , acEdit
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.総合件数 = 0 WHERE (((WK_OUT.総合件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.総合金額 = 0 WHERE (((WK_OUT.総合金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期3年件数 = 0 WHERE (((WK_OUT.長期3年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期3年金額 = 0 WHERE (((WK_OUT.長期3年金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期5年件数 = 0 WHERE (((WK_OUT.長期5年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期5年金額 = 0 WHERE (((WK_OUT.長期5年金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期10年件数 = 0 WHERE (((WK_OUT.長期10年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.長期10年金額 = 0 WHERE (((WK_OUT.長期10年金額) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.住設10年件数 = 0 WHERE (((WK_OUT.住設10年件数) Is Null))"
        'DoCmd.RunSQL "UPDATE WK_OUT SET WK_OUT.住設10年金額 = 0 WHERE (((WK_OUT.住設10年金額) Is Null))"

        'DoCmd.OpenQuery "Q_99_合算", , acEdit

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_合算", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        strSQL = "UPDATE WK_OUT SET WK_OUT.総合件数 = 0 WHERE (((WK_OUT.総合件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.総合金額 = 0 WHERE (((WK_OUT.総合金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期3年件数 = 0 WHERE (((WK_OUT.長期3年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期3年金額 = 0 WHERE (((WK_OUT.長期3年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期5年件数 = 0 WHERE (((WK_OUT.長期5年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期5年金額 = 0 WHERE (((WK_OUT.長期5年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期10年件数 = 0 WHERE (((WK_OUT.長期10年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.長期10年金額 = 0 WHERE (((WK_OUT.長期10年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.住設10年件数 = 0 WHERE (((WK_OUT.住設10年件数) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE WK_OUT SET WK_OUT.住設10年金額 = 0 WHERE (((WK_OUT.住設10年金額) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'タイトル
        strSQL = "INSERT INTO WK_OUT ( P_SEQ, 項目名 )"
        strSQL &= " SELECT 0 AS P_SEQ"
        strSQL &= ", '" & テキスト1.Text & "～" & テキスト3.Text & "' AS 項目名"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        'DB_OPEN("bicdb")
        waitDlg.MainMsg = "ビックカメラ総括表を出力しています。"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        DB_OPEN("bicdb")
        'r = DaList1.Fill(DsExp)
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$

        filename = テキスト13.Text & ":\BIC集計\k_総括表_" & テキスト25.Text & ".xls"




        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If


        Try
            ' Read in nonexistent file.
            FileCopy("C:\Client\エクセル雛形\k_総括表_雛形.xls", filename)
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try

        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "kojima"
        xlSheet = xlSheets.Item(1)  'Sheet1

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        With xlApp
            With .Worksheets(1)

                Dim rw As Integer

                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
                    'waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                    If DtView1(i)("P_SEQ") = "0" Then
                        rw = 1
                        .Cells(rw, 1) = DtView1(i)("項目名")

                    Else
                        Select Case DtView1(i)("P_SEQ")
                            Case Is = "1"
                                rw = 6
                            Case Is = "2"
                                rw = 8
                            Case Is = "3"
                                rw = 9
                            Case Is = "4"
                                rw = 10
                            Case Is = "5"
                                rw = 11
                            Case Is = "6"
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




        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()


        SaveFileDialog1.FileName = "k_総括表_" & テキスト25.Text & ".xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub

        Try
            'xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try


        Me.Enabled = True

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

    '---------------------------------------------------------------------------------------
    '   ビック店舗別総括表出力
    '---------------------------------------------------------------------------------------
    Sub SHOP_crt_bic()

        '店舗マスタ

        '作業用テーブルクリア
        'DoCmd.RunSQL "DELETE * FROM SHOP"
        'DB_OPEN("bicdb")
        'strSQL = "DELETE FROM SHOP"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()
        'DB_OPEN("bicdb")
        ''作業用店舗テーブルに対象店舗データ登録
        'strSQL = "If EXISTS(SELECT * FROM sys.objects "
        'strSQL &= " WHERE object_id = OBJECT_ID(N'[dbo].[SHOP]') "
        'strSQL &= " And type in (N'U')) "
        'strSQL &= " DROP TABLE [dbo].[SHOP] "
        'strSQL &= "SELECT dbo_SHOP.SHOP_CODE, dbo_SHOP.SHOP_NAME, dbo_SHOP.bk_kbn INTO SHOP FROM dbo_SHOP"
        'strSQL &= " WHERE (dbo_SHOP.bk_kbn ='1')"
        'strSQL &= " AND (convert(int,dbo_SHOP.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        ''DoCmd.RunSQL strSQL
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()
        DB_OPEN("bicdb")
        '    strSQL = "INSERT INTO SHOP ( SHOP_CODE, SHOP_NAME, bk_kbn )"
        '    strSQL = strSQL & " SELECT txt_data.SHOP_CODE, txt_data.SHOP_CODE, '1'"
        '    strSQL = strSQL & " FROM txt_data LEFT JOIN SHOP ON txt_data.SHOP_CODE = SHOP.SHOP_CODE"
        '    strSQL = strSQL & " WHERE (((SHOP.SHOP_CODE) Is Null))"
        '    '** コジマ店舗以外をbic店舗として条件文追加
        '    strSQL = strSQL & " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 500 AND 799)"
        '    strSQL = strSQL & " GROUP BY txt_data.SHOP_CODE, txt_data.SHOP_CODE"
        '    DoCmd.RunSQL strSQL

        '総合補償
        'DoCmd.Echo True, "総合補償　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A00"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C00"

        strSQL = "DELETE FROM SHOP_OUT_A00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM SHOP_OUT_C00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A00 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='00'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C00 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='00') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '長期保証3年
        'DoCmd.Echo True, "長期保証3年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A03"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C03"

        strSQL = "DELETE FROM SHOP_OUT_A03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM SHOP_OUT_C03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A03 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='03'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C03 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='03') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '長期保証5年
        'DoCmd.Echo True, "長期保証5年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A05"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C05"

        strSQL = "DELETE FROM SHOP_OUT_A05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM SHOP_OUT_C05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A05 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='05'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C05 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='05') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '長期保証10年
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A10"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C10"


        strSQL = "DELETE FROM SHOP_OUT_A10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM SHOP_OUT_C10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A10 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='10'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE) <>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C10 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='10') AND ((txt_data.EX) Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        '住設保証10年(【部門コード】 が　253091、255010、255011、253090、253062、255160 )
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A10_2"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C10_2"

        strSQL = "DELETE FROM SHOP_OUT_A10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "DELETE FROM SHOP_OUT_C10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A10_2 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='10'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C10_2 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='10') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '合算
        '    DoCmd.OpenQuery "Q_99_合算2", , acEdit
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A00 = 0 WHERE (((SHOP_OUT.件数A00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A00 = 0 WHERE (((SHOP_OUT.購入金額A00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C00 = 0 WHERE (((SHOP_OUT.件数C00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C00 = 0 WHERE (((SHOP_OUT.購入金額C00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A03 = 0 WHERE (((SHOP_OUT.件数A03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A03 = 0 WHERE (((SHOP_OUT.購入金額A03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C03 = 0 WHERE (((SHOP_OUT.件数C03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C03 = 0 WHERE (((SHOP_OUT.購入金額C03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A05 = 0 WHERE (((SHOP_OUT.件数A05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A05 = 0 WHERE (((SHOP_OUT.購入金額A05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C05 = 0 WHERE (((SHOP_OUT.件数C05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C05 = 0 WHERE (((SHOP_OUT.購入金額C05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A10 = 0 WHERE (((SHOP_OUT.件数A10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10 = 0 WHERE (((SHOP_OUT.購入金額A10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C10 = 0 WHERE (((SHOP_OUT.件数C10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10 = 0 WHERE (((SHOP_OUT.購入金額C10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A10_2 = 0 WHERE (((SHOP_OUT.件数A10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10_2 = 0 WHERE (((SHOP_OUT.購入金額A10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C10_2 = 0 WHERE (((SHOP_OUT.件数C10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10_2 = 0 WHERE (((SHOP_OUT.購入金額C10_2) Is Null))"


        'DoCmd.OpenQuery "Q_99_合算2", , acEdit
        DB_CLOSE()
        DB_OPEN("bicdb")
        SqlCmd1 = New SqlClient.SqlCommand("Q_99_合算2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A00 = 0 WHERE (((SHOP_OUT.件数A00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A00 = 0 WHERE (((SHOP_OUT.購入金額A00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C00 = 0 WHERE (((SHOP_OUT.件数C00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C00 = 0 WHERE (((SHOP_OUT.購入金額C00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A03 = 0 WHERE (((SHOP_OUT.件数A03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A03 = 0 WHERE (((SHOP_OUT.購入金額A03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C03 = 0 WHERE (((SHOP_OUT.件数C03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C03 = 0 WHERE (((SHOP_OUT.購入金額C03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A05 = 0 WHERE (((SHOP_OUT.件数A05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A05 = 0 WHERE (((SHOP_OUT.購入金額A05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C05 = 0 WHERE (((SHOP_OUT.件数C05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C05 = 0 WHERE (((SHOP_OUT.購入金額C05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A10 = 0 WHERE (((SHOP_OUT.件数A10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10 = 0 WHERE (((SHOP_OUT.購入金額A10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C10 = 0 WHERE (((SHOP_OUT.件数C10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10 = 0 WHERE (((SHOP_OUT.購入金額C10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A10_2 = 0 WHERE (((SHOP_OUT.件数A10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10_2 = 0 WHERE (((SHOP_OUT.購入金額A10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C10_2 = 0 WHERE (((SHOP_OUT.件数C10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10_2 = 0 WHERE (((SHOP_OUT.購入金額C10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'タイトル
        strSQL = "INSERT INTO SHOP_OUT ( SHOP_CODE, SHOP_NAME )"
        strSQL &= " SELECT '0' AS SHOP_CODE"
        strSQL &= ", '" & テキスト1.Text & "～" & テキスト3.Text & "' AS SHOP_NAME"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        waitDlg.MainMsg = "ビックカメラ総括表を出力しています。"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        'DB_OPEN("bicdb")
        'r = DaList1.Fill(DsExp)
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$

        filename = テキスト13.Text & ":\BIC集計\b_店別請求書_" & テキスト25.Text & ".xls"




        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If


        Try
            ' Read in nonexistent file.
            FileCopy("C:\Client\エクセル雛形\b_店別請求書_雛形.xls", filename)
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try
        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "biccamera"
        xlSheet = xlSheets.Item(1)  'Sheet1

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        With xlApp
            With .Worksheets(1)

                Dim rw As Integer
                rw = 3
                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
                    'waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                    If DtView1(i)("SHOP_CODE") = "0" Then

                        .Cells(1, 1) = DtView1(i)("SHOP_NAME")

                    Else
                        rw += 1
                        '.Cells(rw, 1) = DtView1(i)("SHOP_NAME") 'VJ 2020-12-18
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




        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()

        SaveFileDialog1.FileName = "b_店別請求書_" & テキスト25.Text & ".xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub

        Try
            'xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try


        Me.Enabled = True

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

    '---------------------------------------------------------------------------------------
    '   ビック店舗別総括表出力（Air Bic）
    '---------------------------------------------------------------------------------------
    Sub SHOP_crt_bic_2()

        '店舗マスタ

        '作業用テーブルクリア
        'DoCmd.RunSQL "DELETE * FROM SHOP"

        'DB_OPEN("bicdb")
        'strSQL = "DELETE FROM SHOP"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()
        'DB_OPEN("bicdb")
        ''作業用店舗テーブルに対象店舗データ登録
        'strSQL = "If EXISTS(SELECT * FROM sys.objects "
        'strSQL &= " WHERE object_id = OBJECT_ID(N'[dbo].[SHOP]') "
        'strSQL &= " And type in (N'U')) "
        'strSQL &= " DROP TABLE [dbo].[SHOP] "
        'strSQL &= "SELECT dbo_SHOP.SHOP_CODE, dbo_SHOP.SHOP_NAME, dbo_SHOP.bk_kbn INTO SHOP FROM dbo_SHOP"
        'strSQL &= " WHERE (dbo_SHOP.bk_kbn ='1')"
        'strSQL &= " AND (convert(int,dbo_SHOP.SHOP_CODE) BETWEEN 403 AND 409)"

        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        ''SqlCmd1.ExecuteReader()
        ''DB_CLOSE()
        ''DB_OPEN("bicdb")

        'reader = SqlCmd1.ExecuteReader()
        'While reader.Read()
        '    MsgBox(reader.Item(0))

        'End While
        'reader.Close()
        ''DoCmd.RunSQL strSQL
        'DB_CLOSE()
        DB_OPEN("bicdb")
        '    strSQL = "INSERT INTO SHOP ( SHOP_CODE, SHOP_NAME, bk_kbn )"
        '    strSQL = strSQL & " SELECT txt_data.SHOP_CODE, txt_data.SHOP_CODE, '1'"
        '    strSQL = strSQL & " FROM txt_data LEFT JOIN SHOP ON txt_data.SHOP_CODE = SHOP.SHOP_CODE"
        '    strSQL = strSQL & " WHERE (((SHOP.SHOP_CODE) Is Null))"
        '    '** コジマ店舗以外をbic店舗として条件文追加
        '    strSQL = strSQL & " AND (convert(int,txt_data.SHOP_CODE) NOT BETWEEN 500 AND 799)"
        '    strSQL = strSQL & " GROUP BY txt_data.SHOP_CODE, txt_data.SHOP_CODE"
        '    DoCmd.RunSQL strSQL

        '総合補償
        'DoCmd.Echo True, "総合補償　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A00"

        strSQL = "DELETE FROM SHOP_OUT_A00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C00"

        strSQL = "DELETE FROM SHOP_OUT_C00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A00 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='00'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C00 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='00') AND ((txt_data.EX) Is Null)"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " AND (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '長期保証3年
        'DoCmd.Echo True, "長期保証3年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A03"
        strSQL = "DELETE FROM SHOP_OUT_A03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C03"

        strSQL = "DELETE FROM SHOP_OUT_C03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A03 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='03'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C03 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='03') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        '長期保証5年
        'DoCmd.Echo True, "長期保証5年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A05"

        strSQL = "DELETE FROM SHOP_OUT_A05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C05"

        strSQL = "DELETE FROM SHOP_OUT_C05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A05 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='05'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '   strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C05 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='05') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '長期保証10年
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A10"

        strSQL = "DELETE FROM SHOP_OUT_A10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C10"

        strSQL = "DELETE FROM SHOP_OUT_C10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A10 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='10'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C10 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='10') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        '住設保証10年(【部門コード】 が　253091、255010、255011、253090、253062、255160 )
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A10_2"

        strSQL = "DELETE FROM SHOP_OUT_A10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C10_2"

        strSQL = "DELETE FROM SHOP_OUT_C10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A10_2 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='10'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C10_2 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='10') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='1')"
        strSQL &= " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 403 AND 409)"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '合算
        '    DoCmd.OpenQuery "Q_99_合算2", , acEdit
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A00 = 0 WHERE (((SHOP_OUT.件数A00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A00 = 0 WHERE (((SHOP_OUT.購入金額A00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C00 = 0 WHERE (((SHOP_OUT.件数C00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C00 = 0 WHERE (((SHOP_OUT.購入金額C00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A03 = 0 WHERE (((SHOP_OUT.件数A03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A03 = 0 WHERE (((SHOP_OUT.購入金額A03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C03 = 0 WHERE (((SHOP_OUT.件数C03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C03 = 0 WHERE (((SHOP_OUT.購入金額C03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A05 = 0 WHERE (((SHOP_OUT.件数A05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A05 = 0 WHERE (((SHOP_OUT.購入金額A05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C05 = 0 WHERE (((SHOP_OUT.件数C05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C05 = 0 WHERE (((SHOP_OUT.購入金額C05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A10 = 0 WHERE (((SHOP_OUT.件数A10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10 = 0 WHERE (((SHOP_OUT.購入金額A10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C10 = 0 WHERE (((SHOP_OUT.件数C10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10 = 0 WHERE (((SHOP_OUT.購入金額C10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A10_2 = 0 WHERE (((SHOP_OUT.件数A10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10_2 = 0 WHERE (((SHOP_OUT.購入金額A10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C10_2 = 0 WHERE (((SHOP_OUT.件数C10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10_2 = 0 WHERE (((SHOP_OUT.購入金額C10_2) Is Null))"

        'DoCmd.OpenQuery "Q_99_合算2", , acEdit

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_合算2_1", cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A00 = 0 WHERE (((SHOP_OUT.件数A00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A00 = 0 WHERE (((SHOP_OUT.購入金額A00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C00 = 0 WHERE (((SHOP_OUT.件数C00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C00 = 0 WHERE (((SHOP_OUT.購入金額C00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A03 = 0 WHERE (((SHOP_OUT.件数A03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A03 = 0 WHERE (((SHOP_OUT.購入金額A03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C03 = 0 WHERE (((SHOP_OUT.件数C03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C03 = 0 WHERE (((SHOP_OUT.購入金額C03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A05 = 0 WHERE (((SHOP_OUT.件数A05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A05 = 0 WHERE (((SHOP_OUT.購入金額A05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C05 = 0 WHERE (((SHOP_OUT.件数C05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C05 = 0 WHERE (((SHOP_OUT.購入金額C05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A10 = 0 WHERE (((SHOP_OUT.件数A10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10 = 0 WHERE (((SHOP_OUT.購入金額A10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C10 = 0 WHERE (((SHOP_OUT.件数C10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10 = 0 WHERE (((SHOP_OUT.購入金額C10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A10_2 = 0 WHERE (((SHOP_OUT.件数A10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10_2 = 0 WHERE (((SHOP_OUT.購入金額A10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C10_2 = 0 WHERE (((SHOP_OUT.件数C10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10_2 = 0 WHERE (((SHOP_OUT.購入金額C10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'タイトル
        strSQL = "INSERT INTO SHOP_OUT ( SHOP_CODE, SHOP_NAME )"
        strSQL &= " SELECT '0' AS SHOP_CODE"
        strSQL &= ", '" & テキスト1.Text & "～" & テキスト3.Text & "' AS SHOP_NAME"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL strSQL


        'エクスポート
        '    DoCmd.Echo True, "エクスポート中"
        '    DoCmd.TransferText acExportDelim, "エクスポート定義2", "Q_99_集計2", Forms![フォーム1]![テキスト13] & ":\BIC集計\AirBic店別請求書_" & Forms![フォーム1]![date_from] & "_" & Mid(Forms![フォーム1]![date_to], 7, 2) & ".CSV", True, ""

        'エクセル出力
        waitDlg.MainMsg = "ビックカメラ総括表を出力しています。"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        'DB_OPEN("bicdb")
        'r = DaList1.Fill(DsExp)
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$

        filename = テキスト13.Text & ":\BIC集計\ab_店別請求書_" & テキスト25.Text & ".xls"




        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If
        Try
            ' Read in nonexistent file.
            FileCopy("C:\Client\エクセル雛形\b_店別請求書_雛形.xls", filename)
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try



        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "biccamera"
        xlSheet = xlSheets.Item(1)  'Sheet1

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        With xlApp
            With .Worksheets(1)

                Dim rw As Integer
                rw = 3
                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
                    'waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                    If DtView1(i)("SHOP_CODE") = "0" Then

                        .Cells(1, 1) = DtView1(i)("SHOP_NAME")

                    Else
                        rw += 1
                        '.Cells(rw, 1) = DtView1(i)("SHOP_NAME") VJ 2020-12-18
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




        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()

        SaveFileDialog1.FileName = "ab_店別請求書_" & テキスト25.Text & ".xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub

        Try
            'xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try


        Me.Enabled = True

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
    '---------------------------------------------------------------------------------------
    '   コジマ店舗別総括表出力
    '---------------------------------------------------------------------------------------
    Sub SHOP_crt_kojima()

        '店舗マスタ

        'DB_OPEN("bicdb")
        ''作業用テーブルクリア
        ''DoCmd.RunSQL "DELETE * FROM SHOP"
        'strSQL = "DELETE FROM SHOP"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()
        'DB_OPEN("bicdb")
        'strSQL = "If EXISTS(SELECT * FROM sys.objects "
        'strSQL &= " WHERE object_id = OBJECT_ID(N'[dbo].[SHOP]') "
        'strSQL &= " And type in (N'U')) "
        'strSQL &= " DROP TABLE [dbo].[SHOP] "
        'strSQL &= "SELECT dbo_SHOP.SHOP_CODE, dbo_SHOP.SHOP_NAME, dbo_SHOP.bk_kbn INTO SHOP FROM dbo_SHOP"
        'strSQL &= " WHERE (dbo_SHOP.bk_kbn ='2')"
        ''    strSQL = strSQL & " WHERE (convert(int,dbo_SHOP.SHOP_CODE) BETWEEN 500 AND 799)"
        ''DoCmd.RunSQL strSQL

        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 10000
        ''SqlCmd1.ExecuteReader()


        'reader = SqlCmd1.ExecuteReader()
        'While reader.Read()
        '    MsgBox(reader.Item(0))

        'End While
        'reader.Close()
        'DB_CLOSE()
        DB_OPEN("bicdb")
        '    strSQL = "INSERT INTO SHOP ( SHOP_CODE, SHOP_NAME, bk_kbn )"
        '    strSQL = strSQL & " SELECT txt_data.SHOP_CODE, txt_data.SHOP_CODE, '2'"
        '    strSQL = strSQL & " FROM txt_data LEFT JOIN SHOP ON txt_data.SHOP_CODE = SHOP.SHOP_CODE"
        '    strSQL = strSQL & " WHERE (((SHOP.SHOP_CODE) Is Null))"
        '     '** コジマ店舗を条件文追加
        '    strSQL = strSQL & " AND (convert(int,txt_data.SHOP_CODE) BETWEEN 500 AND 799)"
        '    strSQL = strSQL & " GROUP BY txt_data.SHOP_CODE, txt_data.SHOP_CODE"
        '    DoCmd.RunSQL strSQL

        '総合補償
        'DoCmd.Echo True, "総合補償　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A00"
        strSQL = "DELETE FROM SHOP_OUT_A00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        strSQL = "DELETE FROM SHOP_OUT_C00"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C00"
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A00 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='00'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C00 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='00') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '長期保証3年
        'DoCmd.Echo True, "長期保証3年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A03"
        strSQL = "DELETE FROM SHOP_OUT_A03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C03"
        strSQL = "DELETE FROM SHOP_OUT_C03"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A03 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='03'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C03 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='03') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")


        '長期保証5年
        'DoCmd.Echo True, "長期保証5年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A05"
        strSQL = "DELETE FROM SHOP_OUT_A05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        strSQL = "DELETE FROM SHOP_OUT_C05"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C05"
        DB_CLOSE()
        DB_OPEN("bicdb")

        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A05 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='05'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()

        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C05 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='05') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        '    strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '長期保証10年
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A10"
        strSQL = "DELETE FROM SHOP_OUT_A10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C10"
        strSQL = "DELETE FROM SHOP_OUT_C10"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A10 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='10'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C10 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='10') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)<>'253091' And (txt_data.CAT_CODE)<>'255010' "
        strSQL &= " And (txt_data.CAT_CODE)<>'255011' And (txt_data.CAT_CODE)<>'253090' "
        strSQL &= " And (txt_data.CAT_CODE)<>'253062' And (txt_data.CAT_CODE)<>'255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '住設保証10年(【部門コード】 が　253091、255010、255011、253090、253062、255160 )
        'DoCmd.Echo True, "長期保証10年　抽出中"
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_A10_2"
        strSQL = "DELETE FROM SHOP_OUT_A10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'DoCmd.RunSQL "DELETE * FROM SHOP_OUT_C10_2"
        strSQL = "DELETE FROM SHOP_OUT_C10_2"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_11_00_全Aデータ
        strSQL = "INSERT INTO SHOP_OUT_A10_2 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data"
        strSQL &= " WHERE (((txt_data.SALE_STS)='00') AND ((txt_data.WRN_PRD)='10'))"
        'strSQL &= " AND substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " and substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " AND ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        'Q_12_00_同月内Cデータ
        strSQL = "INSERT INTO SHOP_OUT_C10_2 ( SHOP_CODE, 件数, 購入金額 )"
        strSQL &= " SELECT txt_data.SHOP_CODE, Count(txt_data.WRN_NO) AS WRN_NOのカウント, "
        strSQL &= " isnull(Sum(convert(numeric(18,0),txt_data.PRICE)),0) AS PRICEの合計"
        strSQL &= " FROM txt_data INNER JOIN Dbo_WRN_DATA ON txt_data.WRN_NO = Dbo_WRN_DATA.WRN_NO"
        strSQL &= " WHERE (((txt_data.SALE_STS)='09') AND ((txt_data.WRN_PRD)='10') "
        strSQL &= " And ((txt_data.EX) Is Null)"
        'strSQL &= " And substring(txt_data.IMPT_FILE,7,12) >= " & テキスト19.Text.Substring(6, 6) & " And substring(txt_data.IMPT_FILE,7,12) <=  " & テキスト21.Text.Substring(6, 6) & " "
        strSQL &= " And ((Dbo_WRN_DATA.WRN_DATE) >= '" & テキスト10.Text & "'"
        strSQL &= " And (Dbo_WRN_DATA.WRN_DATE) <= '" & テキスト17.Text & "'))"
        strSQL &= " And ((txt_data.bk_kbn)='2')"
        strSQL &= " AND ((txt_data.CAT_CODE)='253091' Or (txt_data.CAT_CODE)='255010' "
        strSQL &= " Or (txt_data.CAT_CODE)='255011' Or (txt_data.CAT_CODE)='253090' "
        strSQL &= " Or (txt_data.CAT_CODE)='253062' Or (txt_data.CAT_CODE)='255160')"
        strSQL &= " GROUP BY txt_data.SHOP_CODE"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        '合算
        '    DoCmd.OpenQuery "Q_99_合算2", , acEdit
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A00 = 0 WHERE (((SHOP_OUT.件数A00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A00 = 0 WHERE (((SHOP_OUT.購入金額A00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C00 = 0 WHERE (((SHOP_OUT.件数C00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C00 = 0 WHERE (((SHOP_OUT.購入金額C00) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A03 = 0 WHERE (((SHOP_OUT.件数A03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A03 = 0 WHERE (((SHOP_OUT.購入金額A03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C03 = 0 WHERE (((SHOP_OUT.件数C03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C03 = 0 WHERE (((SHOP_OUT.購入金額C03) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A05 = 0 WHERE (((SHOP_OUT.件数A05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A05 = 0 WHERE (((SHOP_OUT.購入金額A05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C05 = 0 WHERE (((SHOP_OUT.件数C05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C05 = 0 WHERE (((SHOP_OUT.購入金額C05) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A10 = 0 WHERE (((SHOP_OUT.件数A10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10 = 0 WHERE (((SHOP_OUT.購入金額A10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C10 = 0 WHERE (((SHOP_OUT.件数C10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10 = 0 WHERE (((SHOP_OUT.購入金額C10) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数A10_2 = 0 WHERE (((SHOP_OUT.件数A10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10_2 = 0 WHERE (((SHOP_OUT.購入金額A10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.件数C10_2 = 0 WHERE (((SHOP_OUT.件数C10_2) Is Null))"
        'DoCmd.RunSQL "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10_2 = 0 WHERE (((SHOP_OUT.購入金額C10_2) Is Null))"

        'DoCmd.OpenQuery "Q_99_合算2", , acEdit
        SqlCmd1 = New SqlClient.SqlCommand("Q_99_合算2_3", cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.CommandType = CommandType.StoredProcedure
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A00 = 0 WHERE (((SHOP_OUT.件数A00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A00 = 0 WHERE (((SHOP_OUT.購入金額A00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C00 = 0 WHERE (((SHOP_OUT.件数C00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C00 = 0 WHERE (((SHOP_OUT.購入金額C00) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A03 = 0 WHERE (((SHOP_OUT.件数A03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A03 = 0 WHERE (((SHOP_OUT.購入金額A03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C03 = 0 WHERE (((SHOP_OUT.件数C03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C03 = 0 WHERE (((SHOP_OUT.購入金額C03) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A05 = 0 WHERE (((SHOP_OUT.件数A05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A05 = 0 WHERE (((SHOP_OUT.購入金額A05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C05 = 0 WHERE (((SHOP_OUT.件数C05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C05 = 0 WHERE (((SHOP_OUT.購入金額C05) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A10 = 0 WHERE (((SHOP_OUT.件数A10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10 = 0 WHERE (((SHOP_OUT.購入金額A10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C10 = 0 WHERE (((SHOP_OUT.件数C10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10 = 0 WHERE (((SHOP_OUT.購入金額C10) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数A10_2 = 0 WHERE (((SHOP_OUT.件数A10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額A10_2 = 0 WHERE (((SHOP_OUT.購入金額A10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.件数C10_2 = 0 WHERE (((SHOP_OUT.件数C10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")
        strSQL = "UPDATE SHOP_OUT SET SHOP_OUT.購入金額C10_2 = 0 WHERE (((SHOP_OUT.購入金額C10_2) Is Null))"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        DB_OPEN("bicdb")

        'タイトル
        strSQL = "INSERT INTO SHOP_OUT ( SHOP_CODE, SHOP_NAME )"
        strSQL &= " SELECT '0' AS SHOP_CODE"
        strSQL &= ", '" & テキスト1.Text & "～" & テキスト3.Text & "' AS SHOP_NAME"
        'DoCmd.RunSQL strSQL
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 10000
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()
        'DB_OPEN("bicdb")
        'エクセル出力
        waitDlg.MainMsg = "ビックカメラ総括表を出力しています。"              ' 進行状況ダイアログのメーターを設定 Need to change based on report
        waitDlg.ProgressMsg = "データ出力準備中"    ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        DsExp.Clear()

        SqlCmd1 = New SqlClient.SqlCommand("Q_99_集計2", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 10000
        DB_OPEN("bicdb")
        'r = DaList1.Fill(DsExp)
        DaList1.Fill(DsExp)
        DB_CLOSE()

        Dim filename$

        filename = テキスト13.Text & ":\BIC集計\k_店別請求書_" & テキスト25.Text & ".xls"




        If System.IO.File.Exists(filename) = True Then

            System.IO.File.Delete(filename)
            'MessageBox.Show("File Deleted")

        End If
        Try
            ' Read in nonexistent file.
            FileCopy("C:\Client\エクセル雛形\k_店別請求書_雛形.xls", filename)
        Catch ex As Exception
            ' Write error.
            'Console.WriteLine(ex)
            MessageBox.Show("ソースファイルまたは宛先が見つかりません")
            Exit Sub

        End Try



        DtView1 = New DataView(DsExp.Tables(0), "", "", DataViewRowState.CurrentRows)

        waitDlg.ProgressMsg = "XLS出力実行中"           ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                          ' メッセージ処理を促して表示を更新する

        Dim xlApp As Excel.Application = DirectCast(CreateObject("Excel.Application"), Excel.Application)
        Dim xlBooks As Excel.Workbooks = xlApp.Workbooks
        Dim xlBook As Excel.Workbook = xlBooks.Open(filename)
        Dim xlSheets As Excel.Sheets = xlBook.Worksheets
        Dim xlSheet As Excel.Worksheet = xlSheets.Item(1)
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        'xlBook.Password = "kojima"
        xlSheet = xlSheets.Item(1)  'Sheet1

        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        With xlApp
            With .Worksheets(1)

                Dim rw As Integer
                rw = 3
                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & (i + 1) & "/" & DtView1.Count & " 件）"
                    'waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
                    If DtView1(i)("SHOP_CODE") = "0" Then

                        .Cells(1, 1) = DtView1(i)("SHOP_NAME")

                    Else
                        rw += 1
                        '.Cells(rw, 1) = DtView1(i)("SHOP_NAME") VJ 2020-12-18
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




        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める


        Me.Activate()
        waitDlg.Close()

        SaveFileDialog1.FileName = "k_店別請求書_" & テキスト25.Text & ".xls"
        SaveFileDialog1.Filter = "Excelファイル|*.xls"
        SaveFileDialog1.OverwritePrompt = False
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub

        Try
            'xlBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal)
            xlBook.SaveAs(SaveFileDialog1.FileName)
        Catch ex As System.Exception
            Exit Sub
        End Try


        Me.Enabled = True

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
