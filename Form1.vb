Public Class Form1
    Inherits System.Windows.Forms.Form

    Private objMutex As System.Threading.Mutex
    Dim waitDlg As WaitDialog

    Dim SqlCmd1 As New SqlClient.SqlCommand
    Dim DaList1 As New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2, DsExport As New DataSet
    Dim DtView1, WK_DtView1, WK_DtView2, WK_DtView3 As DataView

    Dim strSQL, Err_F, WK_str As String
    Dim i, j, r, r1, r2, WK_seq As Integer
    Dim WK_date As Date

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Interop.Date
        Me.Button10 = New System.Windows.Forms.Button
        Me.Label01 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button99 = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(32, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 23)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "処理年月"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Date1.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(32, 88)
        Me.Date1.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2020, 12, 31, 0, 0, 0, 0))
        Me.Date1.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1990, 1, 1, 0, 0, 0, 0))
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(92, 24)
        Me.Date1.TabIndex = 136
        Me.Date1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date1.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2008, 12, 18, 17, 22, 2, 0))
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.SystemColors.Control
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.Black
        Me.Button10.Location = New System.Drawing.Point(188, 72)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(116, 32)
        Me.Button10.TabIndex = 137
        Me.Button10.Text = "CSV出力"
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Label01.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label01.Location = New System.Drawing.Point(32, 112)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(92, 20)
        Me.Label01.TabIndex = 139
        Me.Label01.Text = "Label01"
        Me.Label01.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(16, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 23)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Safety5 Management Center"
        '
        'Button99
        '
        Me.Button99.BackColor = System.Drawing.SystemColors.Control
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button99.Location = New System.Drawing.Point(188, 120)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(116, 32)
        Me.Button99.TabIndex = 141
        Me.Button99.Text = "終 了"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(346, 207)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Label01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入確定データ出力 Var 2.0"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**********************************
    '**  起動時
    '**********************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objMutex = New System.Threading.Mutex(False, "best_exp_SB02")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("すでに起動しています", "実行結果")
            Application.Exit()
        End If
        DB_INIT()
        init()
    End Sub

    Sub init()
        WK_DsList1.Clear()
        strSQL = "SELECT MAX(close_date) AS close_date_max FROM All8_Wrn_sub"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(WK_DsList1, "close_date_max")
        DB_CLOSE()

        WK_DtView1 = New DataView(WK_DsList1.Tables("close_date_max"), "", "", DataViewRowState.CurrentRows)
        If Not IsDBNull(WK_DtView1(0)("close_date_max")) Then
            Date1.Text = Mid(WK_DtView1(0)("close_date_max"), 1, 7)
        Else
            Date1.Text = Mid(Now.Date, 1, 7)
        End If
    End Sub

    '**********************************
    '**  CSV出力
    '**********************************
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sw As System.IO.StreamWriter  'StreamWriterオブジェクト
        Dim i As Integer                  'カウンタ
        Dim sbuf As String                'ファイルに出力するデータ

        Me.Enabled = False                      ' オーナーのフォームを無効にする

        waitDlg = New WaitDialog                ' 進行状況ダイアログ
        waitDlg.Owner = Me                      ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = "加入確定"            ' 処理の概要を表示
        waitDlg.ProgressMsg = "データ抽出中"    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = 0                 ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0                 ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1                ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0               ' 最初の件数を設定
        waitDlg.Show()                          ' 進行状況ダイアログを表示する
        Application.DoEvents()                  ' メッセージ処理を促して表示を更新する

        DsExport.Clear()
        DB_OPEN()
        'ALL
        strSQL = "SELECT All8_Wrn_mtr.BY_cls, All8_Wrn_mtr.ordr_no, All8_Wrn_sub.prch_date, All8_Wrn_sub.fin_date"
        strSQL += ", All8_Wrn_sub.cxl_date, All8_Wrn_mtr.ordr_no_moto, All8_Wrn_mtr.ordr_no_aka, All8_Wrn_mtr.cust_no"
        strSQL += ", All8_Wrn_mtr.cust_lname, All8_Wrn_mtr.zip_code, All8_Wrn_mtr.adrs1, All8_Wrn_mtr.adrs2"
        strSQL += ", All8_Wrn_mtr.srch_phn, All8_Wrn_sub.line_no, All8_Wrn_sub.item_cat_code1"
        strSQL += ", All8_Wrn_sub.item_cat_code1_name, All8_Wrn_sub.item_cat_code2, All8_Wrn_sub.item_cat_code2_name"
        strSQL += ", All8_Wrn_sub.item_cat_code3, All8_Wrn_sub.item_cat_code3_name, All8_Wrn_sub.bend_code"
        strSQL += ", vdr_mtr.vdr_kana, All8_Wrn_sub.pos_code, All8_Wrn_sub.model_name, All8_Wrn_sub.prch_price"
        strSQL += ", All8_Wrn_sub.prch_price_tax - All8_Wrn_sub.prch_price AS prch_tax, All8_Wrn_sub.prch_unit"
        strSQL += ", All8_Wrn_mtr.shop_code, Shop_mtr.[店舗名(漢字)] AS shop_name, All8_Wrn_mtr.op_date"
        strSQL += ", All8_Wrn_sub.wrn_item_code, All8_Wrn_sub.wrn_item_name, All8_Wrn_sub.wrn_fee"
        strSQL += ", All8_Wrn_sub.wrn_prod, All8_Wrn_sub.kbn_cd, All8_Wrn_sub.cont_flg, All8_Wrn_sub.close_date"
        strSQL += ", '0' AS entry_flg, All8_Wrn_sub.cxl_close_date, All8_Wrn_sub.close_cont_flg"
        strSQL += " FROM All8_Wrn_mtr INNER JOIN"
        strSQL += " All8_Wrn_sub ON All8_Wrn_mtr.ordr_no = All8_Wrn_sub.ordr_no LEFT OUTER JOIN"
        strSQL += " Shop_mtr ON All8_Wrn_mtr.BY_cls = Shop_mtr.BY_cls AND"
        strSQL += " All8_Wrn_mtr.shop_code = Shop_mtr.shop_code LEFT OUTER JOIN"
        strSQL += " vdr_mtr ON All8_Wrn_sub.BY_cls = vdr_mtr.BY_cls AND All8_Wrn_sub.bend_code = vdr_mtr.vdr_code"
        'strSQL += " WHERE (All8_Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"

        '臨時 2013/07/23
        strSQL += " WHERE (All8_Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        strSQL += " AND (All8_Wrn_sub.close_cont_flg = 'A')"
        strSQL += " OR (All8_Wrn_sub.cxl_close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        strSQL += " AND (All8_Wrn_sub.cont_flg = 'C')"

        ''2013/07/23修正（同月キャンセルを除外）
        'strSQL = "SELECT All8_Wrn_mtr.BY_cls, All8_Wrn_mtr.ordr_no, All8_Wrn_sub.prch_date, All8_Wrn_sub.fin_date"
        'strSQL += ", All8_Wrn_sub.cxl_date, All8_Wrn_mtr.ordr_no_moto, All8_Wrn_mtr.ordr_no_aka, All8_Wrn_mtr.cust_no"
        'strSQL += ", All8_Wrn_mtr.cust_lname, All8_Wrn_mtr.zip_code, All8_Wrn_mtr.adrs1, All8_Wrn_mtr.adrs2"
        'strSQL += ", All8_Wrn_mtr.srch_phn, All8_Wrn_sub.line_no, All8_Wrn_sub.item_cat_code1"
        'strSQL += ", All8_Wrn_sub.item_cat_code1_name, All8_Wrn_sub.item_cat_code2, All8_Wrn_sub.item_cat_code2_name"
        'strSQL += ", All8_Wrn_sub.item_cat_code3, All8_Wrn_sub.item_cat_code3_name, All8_Wrn_sub.bend_code"
        'strSQL += ", vdr_mtr.vdr_kana, All8_Wrn_sub.pos_code, All8_Wrn_sub.model_name, All8_Wrn_sub.prch_price"
        'strSQL += ", All8_Wrn_sub.prch_price_tax - All8_Wrn_sub.prch_price AS prch_tax, All8_Wrn_sub.prch_unit"
        'strSQL += ", All8_Wrn_mtr.shop_code, Shop_mtr.[店舗名(漢字)] AS shop_name, All8_Wrn_mtr.op_date"
        'strSQL += ", All8_Wrn_sub.wrn_item_code, All8_Wrn_sub.wrn_item_name, All8_Wrn_sub.wrn_fee"
        'strSQL += ", All8_Wrn_sub.wrn_prod, All8_Wrn_sub.kbn_cd, All8_Wrn_sub.cont_flg, All8_Wrn_sub.close_date"
        'strSQL += ", '0' AS entry_flg, All8_fst_close_date.fst_close_date"
        'strSQL += " FROM All8_Wrn_mtr INNER JOIN"
        'strSQL += " All8_Wrn_sub ON All8_Wrn_mtr.ordr_no = All8_Wrn_sub.ordr_no LEFT OUTER JOIN"
        'strSQL += " All8_fst_close_date ON All8_Wrn_sub.ordr_no = All8_fst_close_date.ordr_no AND"
        'strSQL += " All8_Wrn_sub.line_no = All8_fst_close_date.line_no AND All8_Wrn_sub.seq = All8_fst_close_date.seq LEFT OUTER JOIN"
        'strSQL += " Shop_mtr ON All8_Wrn_mtr.BY_cls = Shop_mtr.BY_cls AND"
        'strSQL += " All8_Wrn_mtr.shop_code = Shop_mtr.shop_code LEFT OUTER JOIN"
        'strSQL += " vdr_mtr ON All8_Wrn_sub.BY_cls = vdr_mtr.BY_cls AND All8_Wrn_sub.bend_code = vdr_mtr.vdr_code"
        'strSQL += " WHERE (All8_Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        'strSQL += " AND (All8_Wrn_sub.cont_flg = 'A')"
        'strSQL += " OR (All8_Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        'strSQL += " AND (All8_Wrn_sub.cont_flg = 'C')"
        'strSQL += " AND (All8_Wrn_sub.fin_date IS NOT NULL)"
        'strSQL += " AND (All8_fst_close_date.fst_close_date IS NOT NULL)"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r1 = DaList1.Fill(DsExport, "CSV")

        strSQL = "SELECT Wrn_mtr.BY_cls, Wrn_mtr.ordr_no, Wrn_sub.prch_date, Wrn_sub.fin_date, Wrn_sub.cxl_date"
        strSQL += ", Wrn_mtr.org_ordr_no AS ordr_no_moto, Wrn_mtr.aka_ordr_no AS ordr_no_aka, Wrn_mtr.cust_no"
        strSQL += ", Wrn_mtr.cust_lname, Wrn_mtr.zip_code, Wrn_mtr.adrs1, Wrn_mtr.adrs2, Wrn_mtr.srch_phn"
        strSQL += ", Wrn_sub.line_no, Wrn_sub.item_cat_code1, Wrn_sub.item_cat_code1_name, Wrn_sub.item_cat_code2"
        strSQL += ", Wrn_sub.item_cat_code2_name, Wrn_sub.item_cat_code3, Wrn_sub.item_cat_code3_name, Wrn_sub.bend_code"
        strSQL += ", Wrn_sub.brnd_name AS vdr_kana, Wrn_sub.pos_code, Wrn_sub.model_name, Wrn_sub.prch_price, Wrn_sub.prch_tax"
        strSQL += ", Wrn_sub.prch_unit, Wrn_mtr.shop_code, Shop_mtr.[店舗名(漢字)] AS shop_name, Wrn_sub.op_date"
        strSQL += ", Wrn_sub.wrn_item_code, Wrn_sub.wrn_item_name, Wrn_sub.wrn_fee, Wrn_sub_2.wrn_prod2 AS wrn_prod"
        strSQL += ", CASE WHEN Wrn_sub.corp_flg = '0' THEN '0100' WHEN Wrn_sub.corp_flg = '1' THEN '0200' WHEN Wrn_sub.corp_flg = '2' THEN '0210' WHEN Wrn_sub.corp_flg = '4' THEN '0400' ELSE '0500' END AS kbn_cd"
        strSQL += ", Wrn_sub.cont_flg"
        strSQL += ", Wrn_sub.close_date, Wrn_mtr.entry_flg, Wrn_sub.cxl_close_date, Wrn_sub.close_cont_flg"
        strSQL += " FROM Wrn_mtr INNER JOIN"
        strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
        strSQL += " Wrn_sub_2 ON Wrn_sub.ordr_no = Wrn_sub_2.ordr_no AND Wrn_sub.line_no = Wrn_sub_2.line_no AND"
        strSQL += " Wrn_sub.seq = Wrn_sub_2.seq LEFT OUTER JOIN"
        strSQL += " Shop_mtr ON Wrn_mtr.BY_cls = Shop_mtr.BY_cls AND Wrn_mtr.shop_code = Shop_mtr.shop_code"
        'strSQL += " WHERE (Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"

        '臨時 2013/07/23
        strSQL += " WHERE (Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        strSQL += " AND (Wrn_sub.close_cont_flg = 'A')"
        strSQL += " OR (Wrn_sub.cxl_close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        strSQL += " AND (Wrn_sub.cont_flg = 'C')"

        ''2013/07/23修正（同月キャンセルを除外）
        'strSQL = "SELECT Wrn_mtr.BY_cls, Wrn_mtr.ordr_no, Wrn_sub.prch_date, Wrn_sub.fin_date, Wrn_sub.cxl_date"
        'strSQL += ", Wrn_mtr.org_ordr_no AS ordr_no_moto, Wrn_mtr.aka_ordr_no AS ordr_no_aka, Wrn_mtr.cust_no"
        'strSQL += ", Wrn_mtr.cust_lname, Wrn_mtr.zip_code, Wrn_mtr.adrs1, Wrn_mtr.adrs2, Wrn_mtr.srch_phn"
        'strSQL += ", Wrn_sub.line_no, Wrn_sub.item_cat_code1, Wrn_sub.item_cat_code1_name, Wrn_sub.item_cat_code2"
        'strSQL += ", Wrn_sub.item_cat_code2_name, Wrn_sub.item_cat_code3, Wrn_sub.item_cat_code3_name, Wrn_sub.bend_code"
        'strSQL += ", Wrn_sub.brnd_name AS vdr_kana, Wrn_sub.pos_code, Wrn_sub.model_name, Wrn_sub.prch_price, Wrn_sub.prch_tax"
        'strSQL += ", Wrn_sub.prch_unit, Wrn_mtr.shop_code, Shop_mtr.[店舗名(漢字)] AS shop_name, Wrn_sub.op_date"
        'strSQL += ", Wrn_sub.wrn_item_code, Wrn_sub.wrn_item_name, Wrn_sub.wrn_fee, Wrn_sub_2.wrn_prod2 AS wrn_prod"
        'strSQL += ", CASE WHEN Wrn_sub.corp_flg = '0' THEN '0100' ELSE '0200' END AS kbn_cd, Wrn_sub.cont_flg"
        'strSQL += ", Wrn_sub.close_date, Wrn_mtr.entry_flg, fst_close_date.fst_close_date"
        'strSQL += " FROM Wrn_mtr INNER JOIN"
        'strSQL += " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
        'strSQL += " Wrn_sub_2 ON Wrn_sub.ordr_no = Wrn_sub_2.ordr_no AND Wrn_sub.line_no = Wrn_sub_2.line_no AND"
        'strSQL += " Wrn_sub.seq = Wrn_sub_2.seq LEFT OUTER JOIN"
        'strSQL += " fst_close_date ON Wrn_sub.ordr_no = fst_close_date.ordr_no AND Wrn_sub.line_no = fst_close_date.line_no AND"
        'strSQL += " Wrn_sub.seq = fst_close_date.seq LEFT OUTER JOIN"
        'strSQL += " Shop_mtr ON Wrn_mtr.BY_cls = Shop_mtr.BY_cls AND Wrn_mtr.shop_code = Shop_mtr.shop_code"
        'strSQL += " WHERE (Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        'strSQL += " AND (Wrn_sub.cont_flg = 'A')"
        'strSQL += " OR (Wrn_sub.close_date = CONVERT(DATETIME, '" & Label01.Text & "', 102))"
        'strSQL += " AND (Wrn_sub.cont_flg = 'C')"
        'strSQL += " AND (Wrn_sub.prch_date IS NOT NULL)"
        'strSQL += " AND (fst_close_date.fst_close_date IS NOT NULL)"

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 3600
        r2 = DaList1.Fill(DsExport, "CSV")
        DB_CLOSE()

        If r1 + r2 = 0 Then
            Me.Activate()
            waitDlg.Close()
            Me.Enabled = True
            MessageBox.Show("該当するデータがありません", "エクスポート", MessageBoxButtons.OK)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        Else
            sw = New System.IO.StreamWriter(Application.StartupPath & "\temp", False, System.Text.Encoding.GetEncoding("Shift-JIS"))

            waitDlg.MainMsg = "データ出力中"            ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = r1 + r2               ' 全体の処理件数を設定
            Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

            WK_seq = Count_Get("006", "SB02 SEQ")

            sbuf = "H"                                      '区分
            sbuf += ",SB02"                                 'データ種類
            sbuf += "," & Format(Now.Date, "yyyyMMdd")      '処理日
            sbuf += "," & r1 + r2                           '明細件数
            sbuf += "," & WK_seq                            '処理番号
            sw.WriteLine(sbuf)

            DtView1 = New DataView(DsExport.Tables("CSV"), "", "ordr_no, line_no", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                sbuf = "B"                                                      '区分
                sbuf += "," & DtView1(i)("BY_cls")                              'システム区分
                sbuf += "," & Format(CDate(Label01.Text), "yyyyMMdd")           '請求日
                If DtView1(i)("BY_cls") = "B" Then
                    DtView1(i)("entry_flg") = ""
                    Select Case Len(Trim(DtView1(i)("ordr_no")))
                        Case Is = 13, 14
                            WK_str = Mid(Trim(DtView1(i)("ordr_no")), 13, 2)
                            If IsNumeric(WK_str) = True Then
                                DtView1(i)("entry_flg") = WK_str.PadLeft(2, "0")
                            End If
                            DtView1(i)("ordr_no") = Mid(Trim(DtView1(i)("ordr_no")), 1, 12)
                    End Select
                Else                    '"Y"
                    DtView1(i)("ordr_no") = Mid(Trim(DtView1(i)("ordr_no")), 1, 13)
                    If DtView1(i)("entry_flg") = "0" Then
                        DtView1(i)("entry_flg") = "00"
                    Else
                        DtView1(i)("entry_flg") = "01"
                    End If
                End If
                sbuf += "," & Trim(DtView1(i)("ordr_no")).PadLeft(13, "0")      '伝票番号
                sbuf += "," & DtView1(i)("entry_flg")                           '手書き区分
                If Not IsDBNull(DtView1(i)("prch_date")) Then
                    sbuf += "," & Format(DtView1(i)("prch_date"), "yyyyMMdd")   '受注日
                Else
                    sbuf += ","
                End If
                If Not IsDBNull(DtView1(i)("fin_date")) Then
                    sbuf += "," & Format(DtView1(i)("fin_date"), "yyyyMMdd")    '完了日
                    sbuf += "," & Format(DtView1(i)("fin_date"), "yyyyMMdd")    '保証開始日
                Else
                    sbuf += ","
                    sbuf += ","
                End If
                If Not IsDBNull(DtView1(i)("fin_date")) Then
                    WK_date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, DtView1(i)("wrn_prod"), DtView1(i)("fin_date")))
                    sbuf += "," & Format(WK_date, "yyyyMMdd")                   '保証終了日
                Else
                    sbuf += ","
                End If
                If Not IsDBNull(DtView1(i)("cxl_date")) Then
                    sbuf += "," & Format(DtView1(i)("cxl_date"), "yyyyMMdd")    'キャンセル日
                Else
                    sbuf += ","
                End If
                sbuf += "," & DtView1(i)("ordr_no_moto")                        '元伝No
                sbuf += "," & DtView1(i)("ordr_no_aka")                         '赤伝No
                sbuf += "," & DtView1(i)("cust_no")                             '顧客番号
                sbuf += "," & Trim(DtView1(i)("cust_lname"))                    '顧客名
                sbuf += "," & Trim(DtView1(i)("zip_code"))                      '郵便番号
                If Not IsDBNull(DtView1(i)("adrs1")) Then
                    sbuf += "," & Trim(DtView1(i)("adrs1"))                     '住所1
                Else
                    sbuf += ","
                End If
                If Not IsDBNull(DtView1(i)("adrs2")) Then
                    sbuf += "," & Trim(DtView1(i)("adrs2"))                         '住所2
                Else
                    sbuf += ","
                End If
                sbuf += "," & Trim(DtView1(i)("srch_phn"))                      '電話番号
                sbuf += "," & DtView1(i)("line_no")                             '行No
                sbuf += "," & DtView1(i)("item_cat_code1")                      '大分類No
                sbuf += "," & DtView1(i)("item_cat_code1_name")                 '大分類名
                sbuf += "," & DtView1(i)("item_cat_code2")                      '中分類No
                sbuf += "," & DtView1(i)("item_cat_code2_name")                 '中分類名
                sbuf += "," & DtView1(i)("item_cat_code3")                      '小分類No
                sbuf += "," & DtView1(i)("item_cat_code3_name")                 '小分類名
                sbuf += "," & Trim(DtView1(i)("bend_code"))                     'メーカーコード
                sbuf += "," & Trim(DtView1(i)("vdr_kana"))                      'メーカー名
                sbuf += "," & DtView1(i)("pos_code")                            '商品コード
                sbuf += "," & Trim(DtView1(i)("model_name"))                    '型式
                sbuf += "," & DtView1(i)("prch_price")                          '売価
                sbuf += "," & DtView1(i)("prch_tax")                            '税額
                sbuf += "," & DtView1(i)("prch_unit")                           '購入数量
                sbuf += "," & DtView1(i)("shop_code")                           '店番
                sbuf += "," & Trim(DtView1(i)("shop_name"))                     '店名
                If Not IsDBNull(DtView1(i)("op_date")) Then
                    sbuf += "," & Format(DtView1(i)("op_date"), "yyyyMMdd")     'データ処理日
                Else
                    sbuf += ","
                End If
                sbuf += "," & i + 1                                             'データ連番
                sbuf += "," & DtView1(i)("wrn_item_code")                       '保証商品コード
                If Not IsDBNull(DtView1(i)("wrn_item_name")) Then
                    sbuf += "," & Trim(DtView1(i)("wrn_item_name"))             '保証商品型式
                Else
                    sbuf += ","
                End If
                sbuf += "," & DtView1(i)("wrn_fee")                             '保証金額
                sbuf += "," & DtView1(i)("wrn_prod")                            '保証期間
                sbuf += "," & DtView1(i)("kbn_cd")                              '保証種類
                If IsDBNull(DtView1(i)("cxl_close_date")) Then
                    sbuf += "," & DtView1(i)("close_cont_flg")                  '加入区分
                Else
                    sbuf += "," & DtView1(i)("cont_flg")                        '加入区分
                End If
                sw.WriteLine(sbuf)
            Next

            sbuf = "E"                                      '区分
            sbuf += ",SB02"                                 'データ種類
            sbuf += "," & Format(Now.Date, "yyyyMMdd")      '処理日
            sbuf += "," & WK_seq                            '処理番号
            sw.WriteLine(sbuf)

            sw.Close()
            Me.Activate()
            waitDlg.Close()

            '［名前を付けて保存］ダイアログボックスを表示
            SaveFileDialog1.FileName = "SB02_" & Format(CDate(Label01.Text), "yyyyMM") & ".csv"
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
    '**  TextChanged
    '**********************************
    Private Sub Date1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.TextChanged
        If Date1.Number <> 0 Then
            Label01.Text = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Date1.Text & "/01")))
        End If
    End Sub

    '**********************************
    '**  終了
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
End Class
