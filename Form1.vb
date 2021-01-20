Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim strSQL As String
    Dim i, k, cnt As Integer
    Dim WK_MODEL As String
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
        Me.ClientSize = New System.Drawing.Size(104, 19)
        Me.ControlBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.Text = "旧加入データ"

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

        waitDlg.MainMsg = "加入データ"              ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ削除中"        ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        strSQL = "DELETE FROM wrn_data"
        DB_OPEN("s5")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 3600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        cnt = 0
        'For k = -6 To 0
        k = -6
        waitDlg.MainMsg = "旧加入データ " & DateAdd(DateInterval.Year, k, str_date)  ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ抽出中"        ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定

        '旧
        DsList1.Clear()
        strSQL = "SELECT wrn_data.ordr_no, wrn_data.line_no, wrn_data.model_name, wrn_data_corp.corp_flg, wrn_data.prch_date"
        strSQL = strSQL & " FROM wrn_data LEFT OUTER JOIN wrn_data_corp ON wrn_data.ordr_no = wrn_data_corp.ordr_no"
        strSQL = strSQL & " WHERE (wrn_data.prch_date >= CONVERT(DATETIME, '" & DateAdd(DateInterval.Year, k, str_date) & "', 102))"
        'strSQL = strSQL & " AND wrn_data.prch_date < CONVERT(DATETIME, '" & DateAdd(DateInterval.Year, k + 1, str_date) & "', 102))"
        strSQL = strSQL & " AND (wrn_data.cont_flg = 'A')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn_data2")
        SqlCmd1.CommandTimeout = 7200
        DaList1.Fill(DsList1, "wrn_data")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("wrn_data"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            waitDlg.ProgressMax = DtView1.Count     ' 全体の処理件数を設定
            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　" & "（" & i + 1 & " / " & DtView1.Count & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                WK_MODEL = Trim(DtView1(i)("model_name"))
                WK_MODEL = WK_MODEL.Replace("'", " ")

                strSQL = "INSERT INTO wrn_data (ordr_no, line, seq, model, corp_flg, prch_date, wrn_prod, BY_cls)"
                strSQL = strSQL & " VALUES ('" & DtView1(i)("ordr_no") & "'"
                strSQL = strSQL & ", '" & DtView1(i)("line_no") & "'"
                strSQL = strSQL & ", 0"
                strSQL = strSQL & ", '" & Trim(WK_MODEL) & "'"
                If Not IsDBNull(DtView1(i)("corp_flg")) Then
                    strSQL = strSQL & ", '" & DtView1(i)("corp_flg") & "'"
                Else
                    strSQL = strSQL & ", '0'"
                End If
                strSQL = strSQL & ", '" & DtView1(i)("prch_date") & "'"
                strSQL = strSQL & ", '60', 'B')"
                DB_OPEN("s5")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                cnt = cnt + 1
            Next
        End If
        'Next

        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        System.Diagnostics.EventLog.WriteEntry("BEST web wrn2 END " & cnt & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub
End Class
