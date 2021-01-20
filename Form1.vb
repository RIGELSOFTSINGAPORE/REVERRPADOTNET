Public Class Form1
    Inherits System.Windows.Forms.Form

    Private objMutex As System.Threading.Mutex
    Dim waitDlg As WaitDialog

    Dim SqlCmd1 As New SqlClient.SqlCommand
    Dim DaList1 As New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2, DsExport As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2, WK_DtView3 As DataView

    Dim strSQL, Err_F, WK_str As String
    Dim i, j, r, r1, r2, WK_seq, WK_tax_rate As Integer
    Dim WK_date As Date
    Dim WK_ordr_no As String

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Date2 As GrapeCity.Win.Input.Interop.Date
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Date2 = New GrapeCity.Win.Input.Interop.Date
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 32)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "データ出力"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.Button99.Location = New System.Drawing.Point(200, 108)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(104, 32)
        Me.Button99.TabIndex = 101
        Me.Button99.Text = "終了"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(28, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 24)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "入金日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label6.Location = New System.Drawing.Point(248, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Label6"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(128, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 117
        Me.Label7.Text = "月処理分"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy.MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy.MM", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(28, 16)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(96, 24)
        Me.Date1.TabIndex = 120
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 6, 24, 11, 17, 5, 0))
        '
        'Date2
        '
        Me.Date2.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date2.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date2.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date2.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date2.Location = New System.Drawing.Point(104, 56)
        Me.Date2.Name = "Date2"
        Me.Date2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date2.Size = New System.Drawing.Size(96, 24)
        Me.Date2.TabIndex = 121
        Me.Date2.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2005, 8, 3, 16, 6, 55, 0))
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(358, 159)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入金データ出力(SB03)　Ver 2.0"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '起動時
    '**********************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_exp_SB03")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        DB_INIT()

        strSQL = "SELECT * FROM CLS_CODE WHERE (CLS_NO = '999')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3000
        DB_OPEN()
        DaList1.Fill(DsList1, "CLS_CODE")
        DB_CLOSE()
        DtView1 = New DataView(DsList1.Tables("CLS_CODE"), "CLS_CODE='0'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Label6.Text = Trim(DtView1(0)("CLS_CODE_NAME"))
            Date1.Text = Format(CDate(Label6.Text), "yyyy.MM")
        End If
        Date2.Text = Now.Date
    End Sub

    '**********************************
    'データ出力ボタン
    '**********************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        Dim i As Integer                  'カウンタ
        Dim sbuf As String                'ファイルに出力するデータ

        Me.Enabled = False                      ' オーナーのフォームを無効にする

        waitDlg = New WaitDialog                ' 進行状況ダイアログ
        waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = "入金データ"          ' 処理の概要を表示
        waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0               ' 最初の件数を設定
        waitDlg.Show()                          ' 進行状況ダイアログを表示する
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        DsExport.Clear()
        DB_OPEN()

        strSQL = "SELECT Wrn_ivc.close_date, Wrn_ivc.BY_cls, Wrn_ivc.FLD002, Wrn_ivc.FLD031, Wrn_ivc.ordr_no"
        strSQL += ", Wrn_ivc.FLD014, Wrn_ivc.entry_flg, Wrn_ivc.FLD028, Wrn_ivc.FLD030, Wrn_ivc.FLD032, Wrn_ivc.FLD015"
        strSQL += ", Wrn_ivc.buy_BY_cls, Wrn_ivc.FLD010, Wrn_ivc.ent_BY_cls, Wrn_ivc.FLD011, Wrn_ivc.fin_BY_cls"
        strSQL += ", Wrn_ivc.FLD012, Wrn_ivc.FLD033, Wrn_sub.prch_date, Wrn_sub.fin_date, Wrn_sub.item_cat_code1"
        strSQL += ", Wrn_sub.item_cat_code2, Wrn_sub.item_cat_code3, Wrn_sub_2.item_cat_code3 AS item_cat_code3_2"
        strSQL += ", Wrn_ivc.pos_code, Wrn_sub.pos_code AS pos_code2, Wrn_ivc.FLD020, Wrn_sub.corp_flg"
        strSQL += ", Wrn_sub.wrn_prod, Wrn_sub_2.wrn_prod2, Wrn_ivc.FLD007, Wrn_ivc.inp_seq"
        strSQL += ", '1' AS online, '2' AS stts, Wrn_ivc.FLD009, Wrn_ivc.FLD022"
        strSQL += " FROM Wrn_ivc LEFT OUTER JOIN"
        strSQL += " Wrn_sub_2 ON Wrn_ivc.ordr_no = Wrn_sub_2.ordr_no AND Wrn_ivc.line_no = Wrn_sub_2.line_no AND"
        strSQL += " Wrn_ivc.seq = Wrn_sub_2.seq LEFT OUTER JOIN"
        strSQL += " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND Wrn_ivc.line_no = Wrn_sub.line_no AND"
        strSQL += " Wrn_ivc.seq = Wrn_sub.seq"
        strSQL += " WHERE (Wrn_ivc.close_date = CONVERT(DATETIME, '" & Label6.Text & "', 102))"
        strSQL += " AND (Wrn_ivc.inp_seq IS NULL)"
        strSQL += " AND (Wrn_ivc.Cancel_flg = '0')"
        strSQL += " UNION"
        strSQL += " SELECT Wrn_ivc.close_date, Wrn_ivc.BY_cls, Wrn_ivc.FLD002, Wrn_ivc.FLD031, Wrn_ivc.ordr_no"
        strSQL += ", Wrn_ivc.FLD014, Wrn_ivc.entry_flg, Wrn_ivc.FLD028, Wrn_ivc.FLD030, Wrn_ivc.FLD032, Wrn_ivc.FLD015"
        strSQL += ", Wrn_ivc.buy_BY_cls, Wrn_ivc.FLD010, Wrn_ivc.ent_BY_cls, Wrn_ivc.FLD011, Wrn_ivc.fin_BY_cls"
        strSQL += ", Wrn_ivc.FLD012, Wrn_ivc.FLD033, Wrn_sub.prch_date, Wrn_sub.fin_date, Wrn_sub.item_cat_code1"
        strSQL += ", Wrn_sub.item_cat_code2, Wrn_sub.item_cat_code3, Wrn_sub_2.item_cat_code3 AS item_cat_code3_2"
        strSQL += ", Wrn_ivc.pos_code, Wrn_sub.pos_code AS pos_code2, Wrn_ivc.FLD020, Wrn_sub.corp_flg"
        strSQL += ", Wrn_sub.wrn_prod, Wrn_sub_2.wrn_prod2, Wrn_ivc.FLD007, Wrn_ivc.inp_seq"
        strSQL += ", '2' AS online, '2' AS stts, Wrn_ivc.FLD009, Wrn_ivc.FLD022"
        strSQL += " FROM Wrn_ivc LEFT OUTER JOIN"
        strSQL += " Wrn_sub_2 ON Wrn_ivc.ordr_no = Wrn_sub_2.ordr_no AND Wrn_ivc.line_no = Wrn_sub_2.line_no AND"
        strSQL += " Wrn_ivc.seq = Wrn_sub_2.seq LEFT OUTER JOIN"
        strSQL += " Wrn_sub ON Wrn_ivc.ordr_no = Wrn_sub.ordr_no AND Wrn_ivc.line_no = Wrn_sub.line_no AND"
        strSQL += " Wrn_ivc.seq = Wrn_sub.seq"
        strSQL += " WHERE (Wrn_ivc.close_date = CONVERT(DATETIME, '" & Label6.Text & "', 102))"
        strSQL += " AND (Wrn_ivc.inp_seq IS NOT NULL)"
        strSQL += " AND (Wrn_ivc.Cancel_flg = '0')"
        strSQL += " AND (Wrn_ivc.seq_sub = 1)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r1 = DaList1.Fill(DsExport, "CSV")
        DB_CLOSE()

        If r1 = 0 Then
            Me.Activate()
            waitDlg.Close()
            Me.Enabled = True
            MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        Else
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

            waitDlg.MainMsg = "データ出力中"            ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = r1                    ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            WK_seq = Count_Get("007", "SB03 SEQ")

            sbuf = "H"                                      '区分
            sbuf += ",SB03"                                 'データ種類
            sbuf += "," & Format(Now.Date, "yyyyMMdd")      '処理日
            sbuf += "," & r1                                '明細件数
            sbuf += "," & WK_seq                            '処理番号
            sw.WriteLine(sbuf)

            DtView1 = New DataView(DsExport.Tables("CSV"), "", "ordr_no", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                sbuf = "B"                                                      '区分
                sbuf += "," & DtView1(i)("BY_cls")                              'システム区分
                sbuf += "," & DtView1(i)("online")                              '請求方法区分
                sbuf += "," & DtView1(i)("FLD002")                              '請求番号
                sbuf += "," & Format(DtView1(i)("FLD031"), "yyyyMMdd")          '処理日
                sbuf += "," & i + 1                                             'データ連番
                WK_ordr_no = DtView1(i)("ordr_no")
                If DtView1(i)("BY_cls") = "B" Then
                    DtView1(i)("entry_flg") = ""
                    Select Case Len(Trim(DtView1(i)("ordr_no")))
                        Case Is = 13, 14
                            WK_str = Mid(Trim(DtView1(i)("ordr_no")), 13, 2)
                            If IsNumeric(WK_str) = True Then
                                DtView1(i)("entry_flg") = WK_str.PadLeft(2, "0")
                            End If
                            'DtView1(i)("ordr_no") = Mid(Trim(DtView1(i)("ordr_no")), 1, 12)
                            WK_ordr_no = Mid(Trim(DtView1(i)("ordr_no")), 1, 12)
                    End Select
                Else                    '"Y"
                    'DtView1(i)("ordr_no") = Mid(Trim(DtView1(i)("ordr_no")), 1, 13)
                    WK_ordr_no = Mid(Trim(DtView1(i)("ordr_no")), 1, 13)
                    If IsDBNull(DtView1(i)("entry_flg")) Then
                        If DtView1(i)("online") = "1" Then
                            DtView1(i)("entry_flg") = "00"
                        Else
                            DtView1(i)("entry_flg") = "01"
                        End If
                    End If
                End If
                'sbuf += "," & Trim(DtView1(i)("ordr_no")).PadLeft(13, "0")      '保証番号（伝票番号）
                sbuf += "," & Trim(WK_ordr_no).PadLeft(13, "0")                 '保証番号（伝票番号）
                sbuf += "," & DtView1(i)("FLD014").PadLeft(13, "0")             '修理伝票番号
                If Not IsDBNull(DtView1(i)("entry_flg")) Then
                    sbuf += "," & DtView1(i)("entry_flg")                       '手書き区分
                Else
                    sbuf += ","
                End If
                sbuf += "," & Format(CDate(Date2.Text), "yyyyMMdd")             '入金日
                sbuf += "," & DtView1(i)("FLD028")                              '入金額

                WK_tax_rate = Tax_rate_Get(CDate(DtView1(i)("FLD022")))        '消費税率GET '消費税10%対応　2019/10/18
                sbuf += "," & RoundDOWN(DtView1(i)("FLD028") * (WK_tax_rate / 100) / (1 + (WK_tax_rate / 100)), 0) '入金額の内訳として消費税額を設定
                sbuf += "," & WK_tax_rate                                       '消費税率
                sbuf += "," & DtView1(i)("FLD030").PadLeft(13, "0")             '修理番号
                sbuf += "," & DtView1(i)("FLD015")                              '顧客名
                sbuf += "," & DtView1(i)("buy_BY_cls")                          '修理購入店コード体系
                sbuf += "," & DtView1(i)("FLD010")                              '修理品購入店
                sbuf += "," & DtView1(i)("ent_BY_cls")                          '修理受付店コード体系
                sbuf += "," & DtView1(i)("FLD011")                              '修理受付店
                sbuf += "," & DtView1(i)("fin_BY_cls")                          '修理完了店コード体系
                sbuf += "," & DtView1(i)("FLD012")                              '修理完了店
                sbuf += "," & DtView1(i)("stts")                                'ステータス
                sbuf += ",1"                                                    '入金/返金ﾌﾗｸﾞ

                sbuf += "," & DtView1(i)("FLD033")                              '掛種コード
                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    sbuf += "," & Format(DtView1(i)("prch_date"), "yyyyMMdd")   '加入年月
                Else
                    sbuf += ","
                End If
                If Not IsDBNull(DtView1(i)("item_cat_code1")) Then
                    sbuf += "," & DtView1(i)("item_cat_code1").PadLeft(4, "0")  '大分類NO.
                Else
                    sbuf += ","
                End If
                If Not IsDBNull(DtView1(i)("item_cat_code2")) Then
                    sbuf += "," & DtView1(i)("item_cat_code2").PadLeft(2, "0")  '中分類NO.
                Else
                    sbuf += ","
                End If
                If DtView1(i)("BY_cls") = "Y" Then
                    sbuf += ",00"                                               '小分類NO.
                Else
                    If Not IsDBNull(DtView1(i)("item_cat_code3")) Then
                        sbuf += "," & DtView1(i)("item_cat_code3").PadLeft(2, "0")
                    Else
                        If Not IsDBNull(DtView1(i)("item_cat_code3_2")) Then
                            sbuf += "," & DtView1(i)("item_cat_code3_2").PadLeft(2, "0")
                        Else
                            sbuf += ","
                        End If
                    End If
                End If

                If Not IsDBNull(DtView1(i)("pos_code")) Then
                    If DtView1(i)("pos_code") <> Nothing Then
                        sbuf += "," & DtView1(i)("pos_code").PadLeft(10, "0")       '商品コード
                    Else
                        If Not IsDBNull(DtView1(i)("pos_code2")) Then
                            sbuf += "," & DtView1(i)("pos_code2").PadLeft(10, "0")
                        Else
                            sbuf += ","
                        End If
                    End If
                Else
                    If Not IsDBNull(DtView1(i)("pos_code2")) Then
                        sbuf += "," & DtView1(i)("pos_code2").PadLeft(10, "0")
                    Else
                        sbuf += ","
                    End If
                End If
                sbuf += "," & DtView1(i)("FLD020")                              '製造番号
                If Not IsDBNull(DtView1(i)("corp_flg")) Then
                    Select Case DtView1(i)("corp_flg")
                        Case Is = "0"   '個人
                            sbuf += ",0100"                                         '保証種類
                        Case Is = "1"   '法人
                            sbuf += ",0200"
                        Case Is = "2"   '企業保証
                            sbuf += ",0210"
                        Case Is = "4"   '無料
                            sbuf += ",0400"
                        Case Is = "5"   '10年無料
                            sbuf += ",0500"
                        Case Else
                            sbuf += ",0100"
                    End Select
                Else
                    sbuf += ","
                End If
                If Not IsDBNull(DtView1(i)("wrn_prod2")) Then
                    sbuf += "," & DtView1(i)("wrn_prod2").PadLeft(3, "0")       '保証月数
                Else
                    If Not IsDBNull(DtView1(i)("wrn_prod")) Then
                        sbuf += "," & DtView1(i)("wrn_prod").PadLeft(3, "0")
                    Else
                        sbuf += ","
                    End If
                End If
                sbuf += "," & DtView1(i)("FLD007")                              '事故状況フラグ
                sbuf += "," & DtView1(i)("FLD009")                              '全損フラグ
                sw.WriteLine(sbuf)
            Next

            sbuf = "E"                                      '区分
            sbuf += ",SB03"                                 'データ種類
            sbuf += "," & Format(Now.Date, "yyyyMMdd")      '処理日
            sbuf += "," & WK_seq                            '処理番号
            sw.WriteLine(sbuf)

            sw.Close()
            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            SaveFileDialog1.FileName = "SB03_" & Format(CDate(Label6.Text), "yyyyMM") & ".csv"
            SaveFileDialog1.Filter = "CSVファイル|*.csv"
            If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                Microsoft.VisualBasic.FileSystem.Kill(Application.StartupPath & "\temp")
            Else
                If System.IO.File.Exists(SaveFileDialog1.FileName) = False And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(SaveFileDialog1.FileName) And System.IO.File.Exists(Application.StartupPath & "\temp") Then
                    Microsoft.VisualBasic.FileSystem.Kill(SaveFileDialog1.FileName)
                    Microsoft.VisualBasic.FileSystem.Rename(Application.StartupPath & "\temp", SaveFileDialog1.FileName)
                ElseIf System.IO.File.Exists(Application.StartupPath & "\temp") = False Then
                    MessageBox.Show("アプリケーションエラー", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        End If

        Me.Enabled = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    '終了ボタン
    '**********************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        objMutex.Close()
        Application.Exit()
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

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        objMutex.Close()
        Application.Exit()
    End Sub

    Private Sub Date1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.LostFocus
        Label6.Text = Format(CDate(Date1.Text & ".20"), "yyyy/MM/dd")
    End Sub
End Class
