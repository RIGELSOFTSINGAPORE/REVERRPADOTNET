Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  
    Dim strSQL As String
    Dim i As Integer

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
        Me.Text = "店舗マスタ"

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

        waitDlg.MainMsg = "店舗マスタ"              ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = "データ削除中"        ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        strSQL = "DELETE FROM shop_mtr"
        DB_OPEN("s5")
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()
        DB_CLOSE()

        waitDlg.ProgressMsg = "データ抽出中"        ' 進行状況ダイアログのメーターを設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        strSQL = "SELECT BY_cls, shop_code, [店舗名(漢字)] FROM Shop_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("best_wrn")
        DaList1.Fill(DsList1, "Shop_mtr")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Shop_mtr"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            waitDlg.ProgressMax = DtView1.Count     ' 全体の処理件数を設定
            For i = 0 To DtView1.Count - 1
                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　" & "（" & i + 1 & " / " & DtView1.Count & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strSQL = "INSERT INTO shop_mtr (BY_cls, shop_code, shop_name)"
                strSQL += " VALUES ('" & DtView1(i)("BY_cls") & "'"
                strSQL += ", '" & DtView1(i)("shop_code") & "'"
                strSQL += ", '" & DtView1(i)("店舗名(漢字)") & "')"
                DB_OPEN("s5")
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            Next
        End If

        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        System.Diagnostics.EventLog.WriteEntry("BEST web shop END " & DtView1.Count & " 件", "データコピーを完了しました。", System.Diagnostics.EventLogEntryType.Information)
        Application.Exit()
    End Sub
End Class
