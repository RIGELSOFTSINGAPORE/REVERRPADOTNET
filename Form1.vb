Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim strSQL, WK_MSG As String
    Dim i, k, cnt As Integer
    Dim str_date As Date

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
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(104, 0)
        Me.ControlBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.Text = "新加入データ"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DB_INIT()

        str_date = Format(Now.Date, "yyyy/MM" & "/01")

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        'waitDlg.MainMsg = "加入データ"              ' 進行状況ダイアログのメーターを設定
        'waitDlg.ProgressMsg = "データ削除中"        ' 進行状況ダイアログのメーターを設定
        'Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        'strSQL = "DELETE FROM wrn_data"
        'DB_OPEN("s5")
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.CommandTimeout = 3600
        'SqlCmd1.ExecuteNonQuery()
        'DB_CLOSE()

        cnt = 0
        For k = -6 To -1
            If k = -1 Then
                WK_MSG = "新加入データ " & DateAdd(DateInterval.Year, k, str_date) & "～"
            Else
                WK_MSG = "新加入データ " & DateAdd(DateInterval.Year, k, str_date) & "～" & DateAdd(DateInterval.Year, k + 1, str_date)
            End If
            waitDlg.MainMsg = WK_MSG                    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = "データ抽出中"        ' 進行状況ダイアログのメーターを設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
            waitDlg.ProgressValue = 0                   ' 最初の件数を設定

            '新
            DsList1.Clear()
            strSQL = "SELECT ordr_no, line_no, seq, model_name, corp_flg, prch_date, wrn_prod, BY_cls"
            strSQL += " FROM Wrn_sub"
            strSQL += " WHERE (prch_date >= CONVERT(DATETIME, '" & DateAdd(DateInterval.Year, k, str_date) & "', 102)"
            If k = -1 Then
                strSQL += ")"
            Else
                strSQL += " AND prch_date < CONVERT(DATETIME, '" & DateAdd(DateInterval.Year, k + 1, str_date) & "', 102))"
            End If
            strSQL += " AND (cont_flg = 'A')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("best_wrn")
            SqlCmd1.CommandTimeout = 10800  '３時間待ってみる
            DaList1.Fill(DsList1, "wrn_data")
            DB_CLOSE()
            System.Diagnostics.EventLog.WriteEntry("BEST web QRY END " & Format(DateAdd(DateInterval.Year, k, str_date), "yyyy"), "　クエリー完", System.Diagnostics.EventLogEntryType.Information)

            DtView1 = New DataView(DsList1.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
            If DtView1.Count <> 0 Then
                waitDlg.ProgressMax = DtView1.Count     ' 全体の処理件数を設定
                For i = 0 To DtView1.Count - 1
                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　" & "（" & i + 1 & " / " & DtView1.Count & " 件）"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    strSQL = "INSERT INTO wrn_data (ordr_no, line, seq, model, corp_flg, prch_date, wrn_prod, BY_cls)"
                    strSQL += " VALUES ('" & DtView1(i)("ordr_no") & "'"
                    strSQL += ", '" & DtView1(i)("line_no") & "'"
                    strSQL += ", " & DtView1(i)("seq") & ""
                    strSQL += ", '" & Trim(DtView1(i)("model_name")) & "'"
                    strSQL += ", '" & DtView1(i)("corp_flg") & "'"
                    strSQL += ", '" & DtView1(i)("prch_date") & "'"
                    strSQL += ", '" & DtView1(i)("wrn_prod") & "'"
                    strSQL += ", '" & DtView1(i)("BY_cls") & "')"
                    DB_OPEN("s5")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                    cnt = cnt + 1
                Next
                System.Diagnostics.EventLog.WriteEntry("BEST web new wrn END " & Format(DateAdd(DateInterval.Year, k, str_date), "yyyy") & " " & DtView1.Count & " 件", WK_MSG & "　コピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)
            End If
        Next

        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        System.Diagnostics.EventLog.WriteEntry("BEST web new wrn END " & cnt & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub
End Class
