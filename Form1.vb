Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2 As New DataSet
    Dim DtView1, DtView2 As DataView

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim strSQL As String
    Dim i, j, k, cnt As Integer

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
        Me.Text = "修理データ"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DB_INIT()

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        waitDlg.MainMsg = "修理データ"              ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ削除中"        ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        strSQL = "DELETE FROM ivc_data"
        DB_OPEN("s5")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.CommandTimeout = 3600
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        cnt = 0
        For k = 0 To 9
            waitDlg.MainMsg = "修理データ 保証番号の上1桁目 " & k    ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = "データ抽出中"                    ' 進行状況ダイアログのメーターを設定
            Application.DoEvents()                                  ' メッセージ処理を促して表示を更新する
            waitDlg.ProgressValue = 0                               ' 最初の件数を設定

            DsList1.Clear()
            strSQL = "SELECT * FROM wrn_data WHERE (ordr_no LIKE '" & k & "%')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("s5")
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

                    DsList2.Clear()
                    strSQL = "SELECT ordr_no, line_no, seq, FLD020, close_date, FLD028, FLD012"
                    strSQL = strSQL & " FROM Wrn_ivc"
                    strSQL = strSQL & " WHERE (FLD032 = N'1')"
                    strSQL = strSQL & " AND (ordr_no = '" & DtView1(i)("ordr_no") & "')"
                    strSQL = strSQL & " AND (line_no = '" & DtView1(i)("line") & "')"
                    strSQL = strSQL & " AND (seq = '" & DtView1(i)("seq") & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("best_wrn")
                    SqlCmd1.CommandTimeout = 3600
                    DaList1.Fill(DsList2, "Wrn_ivc")
                    DB_CLOSE()

                    DtView2 = New DataView(DsList2.Tables("Wrn_ivc"), "", "", DataViewRowState.CurrentRows)
                    If DtView2.Count <> 0 Then
                        For j = 0 To DtView2.Count - 1
                            strSQL = "INSERT INTO ivc_data (ordr_no, line, seq, ser_no, close_date, price, fin_shop_code, BY_cls)"
                            strSQL = strSQL & " VALUES ('" & DtView2(j)("ordr_no") & "'"
                            strSQL = strSQL & ", '" & DtView2(j)("line_no") & "'"
                            strSQL = strSQL & ", " & DtView2(j)("seq") & ""
                            If Not IsDBNull(DtView2(j)("FLD020")) Then strSQL = strSQL & ", '" & DtView2(j)("FLD020") & "'" Else strSQL = strSQL & ", NULL"
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView2(j)("close_date") & "', 102)"
                            strSQL = strSQL & ", " & DtView2(j)("FLD028") & ""
                            strSQL = strSQL & ", '" & DtView2(j)("FLD012") & "'"
                            strSQL = strSQL & ", '" & DtView1(i)("BY_cls") & "')"
                            DB_OPEN("s5")
                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.ExecuteNonQuery()
                            DB_CLOSE()
                            cnt = cnt + 1
                        Next
                    End If
                Next
            End If
        Next

        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        System.Diagnostics.EventLog.WriteEntry("BEST web ivc END " & cnt & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub
End Class
