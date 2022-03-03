Public Class F40_Form04
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strFile, strData As String
    Dim i, r As Integer

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
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        '
        'F40_Form04
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(115, 6)
        Me.ControlBox = False
        Me.Name = "F40_Form04"
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Web用データ作成"

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DsList1.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_web_exp", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
        Pram1.Value = DateAdd(DateInterval.Month, -3, Now)
        Pram2.Value = DateAdd(DateInterval.Day, -10, Now)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN(ini)
        r = DaList1.Fill(DsList1, "csv")
        DB_CLOSE()

        If r = 0 Then
            MessageBox.Show("対象データがありません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "WebData.CSV"                            'はじめのファイル名を指定する
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
                strData = "販社伝番,伝票番号,受付年月日,MAKERN,製品名,製品番号,見積日付,修理完了日,ステータス,コメント,統一コード"
                swFile.WriteLine(strData)

                DtView1 = New DataView(DsList1.Tables("csv"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    strData = DtView1(i)("store_repr_no")               '販社伝番
                    strData += "," & DtView1(i)("rcpt_no")     '伝票番号
                    strData += "," & DtView1(i)("accp_date")   '受付年月日
                    strData += "," & DtView1(i)("vndr_name")   'メーカー
                    strData += "," & DtView1(i)("model_1")     '製品名
                    strData += "," & DtView1(i)("model_2")     '製品番号
                    strData += "," & DtView1(i)("etmt_date")   '見積日付
                    strData += "," & DtView1(i)("comp_date")   '修理完了日
                    If IsDBNull(DtView1(i)("comp_date")) Then
                        If IsDBNull(DtView1(i)("etmt_date")) Then
                            strData += ",1"                    'ステータス
                        Else
                            strData += ",2"                    'ステータス
                        End If
                    Else
                        strData += ",5"                        'ステータス
                    End If
                    If DtView1(i)("rcpt_cls") = "01" Then
                        strData += ",有:"                      'コメント
                    Else
                        strData += ",保:"                      'コメント
                    End If
                    If Not IsDBNull(DtView1(i)("comp_date")) Then
                        strData += "完了"                      'コメント
                    Else
                        If Not IsDBNull(DtView1(i)("etmt_date")) Then
                            strData += "見積"                  'コメント
                        Else
                            strData += "入荷"                  'コメント
                        End If
                    End If
                    strData += "," & DtView1(i)("grup_code")   '統一コード
                    swFile.WriteLine(strData)
                Next

                swFile.Close()          'ファイルを閉じる
                MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                waitDlg.Close()         '進行状況ダイアログを閉じる
            End If
        End If

        DsList1.Clear()
        Close()
    End Sub
End Class
