Public Class F90_Form14_old
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, inz_F, strFile, strData As String
    Dim i, r As Integer
    Dim Line As Integer = 1     '行
    Dim BR_date As String

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Date
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date00 As GrapeCity.Win.Input.Date
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Date
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Date00 = New GrapeCity.Win.Input.Date
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date00, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(180, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 24)
        Me.Label3.TabIndex = 1475
        Me.Label3.Text = "～"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(204, 44)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 2
        Me.Date02.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 1474
        Me.Label1.Text = "申込日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(76, 44)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1
        Me.Date01.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(72, 112)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 28)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "エクセル出力"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(224, 112)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 4
        Me.Button99.Text = "閉じる"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 80)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(316, 20)
        Me.msg.TabIndex = 1478
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 24)
        Me.Label2.TabIndex = 1480
        Me.Label2.Text = "年月"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date00
        '
        Me.Date00.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date00.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date00.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date00.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM", "", "")
        Me.Date00.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date00.Location = New System.Drawing.Point(76, 8)
        Me.Date00.Name = "Date00"
        Me.Date00.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date00.Size = New System.Drawing.Size(80, 24)
        Me.Date00.TabIndex = 0
        Me.Date00.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date00.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Date00.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'F90_Form14_old
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(346, 151)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date00)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "F90_Form14_old"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エクセル出力"
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date00, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F90_Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call DsSet()    '** データセット
    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date00.Text = Format(DateAdd(DateInterval.Day, -1, Now.Date), "yyyy/MM")
        BR_date = Date00.Text
        Date01.Text = Date00.Text & "/01"
        Date02.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date01.Text)))
        msg.Text = Nothing

    End Sub

    '********************************************************************
    '** データセット
    '********************************************************************
    Sub DsSet()
        WK_DsList1.Clear()

        'メーカー
        strSQL = "SELECT vndr_code, name FROM M05_VNDR"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "M05_VNDR")
        DB_CLOSE()

    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"

        Call CK_Date01()    '申込日(From)
        If msg.Text <> Nothing Then Err_F = "1" : Date01.Focus() : Exit Sub

        Call CK_Date02()    '申込日(To)
        If msg.Text <> Nothing Then Err_F = "1" : Date02.Focus() : Exit Sub

    End Sub
    Sub CK_Date00()     '年月
        msg.Text = Nothing
        If BR_date <> Date00.Text Then

            If Date00.Number = 0 Then
                'msg.Text = "年月の入力がありません。"
                'Date00.BackColor = System.Drawing.Color.Red : Exit Sub
            Else
                Date01.Text = Date00.Text & "/01"
                Date02.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date01.Text)))
                Date01.BackColor = System.Drawing.SystemColors.Window
                Date02.BackColor = System.Drawing.SystemColors.Window
            End If
            BR_date = Date00.Text
            'Date00.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Sub CK_Date01()     '申込日(From)
        msg.Text = Nothing

        If Date01.Number = 0 Then
            msg.Text = "申込日(From)の入力がありません。"
            Date01.BackColor = System.Drawing.Color.Red : Exit Sub
        End If
        Date01.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Sub CK_Date02()     '申込日(To)
        msg.Text = Nothing

        If Date02.Number = 0 Then
            msg.Text = "申込日(To)の入力がありません。"
            Date02.BackColor = System.Drawing.Color.Red : Exit Sub
        Else
            If Date01.Number <> 0 Then
                If Date01.Number > Date02.Number Then
                    msg.Text = "申込日の範囲指定が正しくありません。"
                    Date02.BackColor = System.Drawing.Color.Red : Exit Sub
                End If
            End If

        End If
        Date02.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Date00_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date00.LostFocus
        Call CK_Date00()    '年月
    End Sub
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        Call CK_Date01()    '申込日(From)
    End Sub
    Private Sub Date02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date02.LostFocus
        Call CK_Date02()    '申込日(To)
    End Sub

    '******************************************************************
    '** エクセル出力
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()    '** 項目チェック
        If Err_F = "0" Then

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_XLS", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.DateTime)
            Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.DateTime)
            Pram1.Value = Date01.Text
            Pram2.Value = Date02.Text
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            r = DaList1.Fill(DsList1, "XLS")
            DB_CLOSE()

            If r = 0 Then
                msg.Text = "対象データがありません。"
            Else

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

                waitDlg.MainMsg = "データ抽出中" ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMax = r         ' 全体の処理件数を設定
                waitDlg.ProgressValue = 0       ' 最初の件数を設定
                Application.DoEvents()          ' メッセージ処理を促して表示を更新する

                Dim oExcel As Object
                Dim oBook As Object
                Dim oSheet As Object

                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add

                Line = 1
                oSheet = oBook.Worksheets(1)
                oSheet.Range("A1").Value = "加入番号"
                oSheet.Range("B1").Value = "氏名"
                oSheet.Range("C1").Value = "氏名カナ"
                oSheet.Range("D1").Value = "郵便番号"
                oSheet.Range("E1").Value = "住所１"
                oSheet.Range("F1").Value = "住所２"
                oSheet.Range("G1").Value = "電話番号"
                oSheet.Range("H1").Value = "大学名"
                oSheet.Range("I1").Value = "学部名"
                oSheet.Range("J1").Value = "学科名"
                oSheet.Range("K1").Value = "メーカー"
                oSheet.Range("L1").Value = "モデル名"
                oSheet.Range("M1").Value = "S/N"
                oSheet.Range("N1").Value = "購入金額"
                oSheet.Range("O1").Value = "保証期間"
                oSheet.Range("P1").Value = "メーカー保証開始"
                oSheet.Range("Q1").Value = "保証範囲"
                oSheet.Range("R1").Value = "取扱店"
                oSheet.Range("S1").Value = "加入者請求金額"
                oSheet.Range("T1").Value = "販売員"
                oSheet.Range("U1").Value = "加入日"
                oSheet.Range("V1").Value = "加入証印刷"
                oSheet.Range("W1").Value = "加入証印刷日付"
                oSheet.Range("X1").Value = "登録日付"
                oSheet.Range("A1:X1").Interior.Color = RGB(0, 255, 255)

                DtView1 = New DataView(DsList1.Tables("XLS"), "", "", DataViewRowState.CurrentRows)
                For i = 0 To DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                    waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    Line = Line + 1
                    oSheet.Range("A" & Line).Value = DtView1(i)("code")             '店舗加入番号ド
                    oSheet.Range("B" & Line).Value = DtView1(i)("user_name")        '氏名
                    oSheet.Range("C" & Line).Value = DtView1(i)("use_name_kana")    '氏名カナ
                    oSheet.Range("D" & Line).Value = DtView1(i)("zip")              '郵便番号
                    oSheet.Range("E" & Line).Value = DtView1(i)("adrs1")            '住所１
                    oSheet.Range("F" & Line).Value = DtView1(i)("adrs2")            '住所２
                    'oSheet.Range("G" & Line).NumberFormatLocal = "@"
                    oSheet.Range("G" & Line).Value = DtView1(i)("tel")              '電話番号
                    oSheet.Range("H" & Line).Value = DtView1(i)("univ_name")        '大学名
                    oSheet.Range("I" & Line).Value = DtView1(i)("dpmt_name")        '学部名
                    oSheet.Range("J" & Line).Value = DtView1(i)("sbjt_name")        '学科名
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M05_VNDR"), "vndr_code = '" & DtView1(i)("makr_code") & "'", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then
                        oSheet.Range("K" & Line).Value = WK_DtView1(0)("name")      'メーカー
                    Else
                        oSheet.Range("K" & Line).Value = DtView1(i)("makr_name")    'メーカー
                    End If
                    oSheet.Range("L" & Line).Value = DtView1(i)("modl_name")        'モデル名
                    oSheet.Range("M" & Line).Value = DtView1(i)("s_no")             'S/N
                    oSheet.Range("N" & Line).Value = DtView1(i)("prch_amnt")        '購入金額
                    oSheet.Range("O" & Line).Value = DtView1(i)("wrn_tem_name")     '保証期間
                    oSheet.Range("P" & Line).Value = DtView1(i)("makr_wrn_stat")    'メーカー保証開始
                    oSheet.Range("Q" & Line).Value = DtView1(i)("wrn_range_name")   '保証範囲
                    oSheet.Range("R" & Line).Value = DtView1(i)("shop_name")        '取扱店
                    oSheet.Range("S" & Line).Value = DtView1(i)("wrn_fee")          '加入者請求金額
                    oSheet.Range("T" & Line).Value = DtView1(i)("sale_pson")        '販売員
                    oSheet.Range("U" & Line).Value = DtView1(i)("Part_date")        '加入日
                    oSheet.Range("V" & Line).Value = DtView1(i)("Part_prt")         '加入証印刷
                    oSheet.Range("W" & Line).Value = DtView1(i)("Part_prt_date")    '加入証印刷日付
                    oSheet.Range("X" & Line).Value = DtView1(i)("reg_date")         '登録日付
                Next

                oSheet.Range("N2:N" & Line).NumberFormatLocal = "#,##0_ "
                oSheet.Range("S2:S" & Line).NumberFormatLocal = "#,##0_ "
                oSheet.Range("A1:X" & Line).EntireColumn.AutoFit()   'セル幅（列幅）の自動調整

                '［名前を付けて保存］ダイアログボックスを表示
                SaveFileDialog1.FileName = "QG_Care.xls"
                SaveFileDialog1.Filter = "Excelファイル|*.xls"
                SaveFileDialog1.OverwritePrompt = False
                If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then GoTo end_prc
                Try
                    oBook.SaveAs(SaveFileDialog1.FileName)
                Catch ex As System.Exception
                    GoTo end_prc
                End Try
end_prc:
                ' 終了処理　
                oSheet = Nothing
                oBook = Nothing
                oExcel.Quit()
                oExcel = Nothing
                GC.Collect()

                MessageBox.Show("エクセル出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                waitDlg.Close()         '進行状況ダイアログを閉じる
                Me.Enabled = True       'オーナーのフォームを無効にする
            End If
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        Close()
    End Sub
End Class

