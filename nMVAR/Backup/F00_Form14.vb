Public Class F00_Form14
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, WK_DtView1 As DataView

    Dim strSQL, Err_F, TSS_F As String
    Dim i As Integer
    Dim WK_str, WK_str2, WK_grup_code As String
    Dim WK_int, WK_int2 As Integer
    Dim rpt_ex_flg As String

    Dim WK_comp_comn As String

    Dim Wk_TAX As Integer
    Dim Wk_TAX_1, Wk_TAX_0 As Decimal

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
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Number1 As GrapeCity.Win.Input.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Edit000 As GrapeCity.Win.Input.Edit
    Friend WithEvents aka As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Number1 = New GrapeCity.Win.Input.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        Me.Button6 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label004 = New System.Windows.Forms.Label
        Me.Edit000 = New GrapeCity.Win.Input.Edit
        Me.aka = New System.Windows.Forms.Label
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(492, 160)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 5
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(20, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "更新"
        '
        'Number1
        '
        Me.Number1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number1.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number1.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number1.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number1.Enabled = False
        Me.Number1.Format = New GrapeCity.Win.Input.NumberFormat("#,###,###", "", "", "-", "", "", "")
        Me.Number1.HighlightText = True
        Me.Number1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number1.Location = New System.Drawing.Point(104, 28)
        Me.Number1.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.Number1.MinValue = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.Number1.Name = "Number1"
        Me.Number1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number1.Size = New System.Drawing.Size(88, 20)
        Me.Number1.TabIndex = 0
        Me.Number1.TabStop = False
        Me.Number1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 1760
        Me.Label1.Text = "赤金額"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.AcceptsReturn = True
        Me.Edit1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(104, 52)
        Me.Edit1.MaxLength = 200
        Me.Edit1.Multiline = True
        Me.Edit1.Name = "Edit1"
        Me.Edit1.ScrollBarMode = GrapeCity.Win.Input.ScrollBarMode.Automatic
        Me.Edit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(460, 76)
        Me.Edit1.TabIndex = 1
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(260, 160)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 24)
        Me.Button6.TabIndex = 4
        Me.Button6.TabStop = False
        Me.Button6.Text = "赤伝印刷"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(20, 136)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(540, 16)
        Me.msg.TabIndex = 1765
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(20, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 76)
        Me.Label2.TabIndex = 1766
        Me.Label2.Text = "理由"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(220, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 20)
        Me.Label3.TabIndex = 1837
        Me.Label3.Text = "赤伝受付番号"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(220, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 20)
        Me.Label4.TabIndex = 1838
        Me.Label4.Text = "完了日（赤伝処理日）"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label004
        '
        Me.Label004.BackColor = System.Drawing.SystemColors.Window
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.Location = New System.Drawing.Point(384, 28)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(112, 20)
        Me.Label004.TabIndex = 1839
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit000
        '
        Me.Edit000.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit000.HighlightText = True
        Me.Edit000.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit000.LengthAsByte = True
        Me.Edit000.Location = New System.Drawing.Point(384, 8)
        Me.Edit000.MaxLength = 9
        Me.Edit000.Name = "Edit000"
        Me.Edit000.ReadOnly = True
        Me.Edit000.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit000.Size = New System.Drawing.Size(112, 20)
        Me.Edit000.TabIndex = 1840
        Me.Edit000.TabStop = False
        Me.Edit000.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Edit000.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'aka
        '
        Me.aka.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.aka.Location = New System.Drawing.Point(168, 164)
        Me.aka.Name = "aka"
        Me.aka.Size = New System.Drawing.Size(24, 16)
        Me.aka.TabIndex = 1865
        Me.aka.Text = "aka"
        Me.aka.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.aka.Visible = False
        '
        'F00_Form14
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(578, 192)
        Me.Controls.Add(Me.aka)
        Me.Controls.Add(Me.Edit000)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Number1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form14"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "赤伝入力"
        CType(Me.Number1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit000, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        DspSet()
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        '消費税率
        Wk_TAX = tax_rate_get(Now) '消費税率取得
        Wk_TAX_0 = Wk_TAX / 100
        Wk_TAX_1 = 1 + Wk_TAX_0

        msg.Text = Nothing
    End Sub

    '********************************************************************
    '**  権限チェック
    '********************************************************************
    Sub ACES()

        SqlCmd1 = New SqlClient.SqlCommand("sp_ACES_CHK", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
        Dim Pram2 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 2)
        Pram1.Value = P_ACES_brch_code
        Pram2.Value = P_ACES_post_code
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "ACES_CHK")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='998'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            aka.Text = DtView1(0)("access_cls")
        Else
            aka.Text = Nothing
        End If
    End Sub

    Sub DspSet()
        Edit1.Enabled = True

        DsList1.Clear()
        strSQL = "SELECT T01_REP_MTR.rcpt_no, T01_REP_MTR.comp_shop_ttl AS amnt, M08_STORE_1.dlvr_rprt_cls, T01_REP_MTR.qg_care_no"
        strSQL += ", T01_REP_MTR.acdt_date, T01_REP_MTR.comp_date, M08_STORE.grup_code, T01_REP_MTR_1.rcpt_no AS rcpt_no_aka"
        strSQL += ", T01_REP_MTR_1.comp_shop_ttl AS aka, T01_REP_MTR_1.comp_comn, T01_REP_MTR_1.sals_date AS sals_date_aka"
        strSQL += ", T01_REP_MTR_1.sals_no AS sals_no_aka, T01_REP_MTR_1.comp_date AS comp_date_aka, T01_REP_MTR.rcpt_cls, T01_REP_MTR.rpar_cls"
        strSQL += " FROM T01_REP_MTR AS T01_REP_MTR_1 RIGHT OUTER JOIN"
        strSQL += " T01_REP_MTR INNER JOIN"
        strSQL += " M08_STORE INNER JOIN"
        strSQL += " M08_STORE AS M08_STORE_1 ON M08_STORE.dlvr_code = M08_STORE_1.store_code ON"
        strSQL += " T01_REP_MTR.store_code = M08_STORE.store_code ON T01_REP_MTR_1.rcpt_no_aka = T01_REP_MTR.rcpt_no"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & P_PRAM1 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

        WK_grup_code = DtView1(0)("grup_code")

        '赤
        If Not IsDBNull(DtView1(0)("aka")) Then
            Number1.Value = DtView1(0)("aka")
        Else
            Number1.Value = DtView1(0)("amnt") * -1
        End If
        If Number1.Value < 0 Then
            Number1.DisabledForeColor = System.Drawing.Color.Red
        Else
            Number1.DisabledForeColor = System.Drawing.Color.Black
        End If
        If aka.Text > "2" Then Button1.Enabled = True Else Button1.Enabled = False
        If Not IsDBNull(DtView1(0)("rcpt_no_aka")) Then
            Edit000.Text = DtView1(0)("rcpt_no_aka")
            Label004.Text = DtView1(0)("comp_date_aka")
            Button1.Enabled = False
            If aka.Text > "2" Then Button6.Enabled = True Else Button6.Enabled = False
        End If
        If Not IsDBNull(DtView1(0)("sals_no_aka")) Then
            Button6.Enabled = False
        End If
        If DtView1(0)("dlvr_rprt_cls") = "0" Then
            Button6.Enabled = False
        End If

        If Not IsDBNull(DtView1(0)("comp_comn")) Then
            Edit1.Text = DtView1(0)("comp_comn")
        End If

    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        F_Check()
        If Err_F = "0" Then
            P_HSTY_DATE = Now

            '赤金額
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM T01_REP_MTR WHERE (rcpt_no = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "T01_REP_MTR")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

            If Mid(WK_DtView1(0)("comp_date"), 1, 7) = Format(Now.Date, "yyyy/MM") Then '当月
                rpt_ex_flg = "1"
            Else
                rpt_ex_flg = "0"
            End If

            Edit000.Text = Count_Get(Mid(P_PRAM1, 1, 2))

            strSQL = "INSERT INTO T01_REP_MTR"
            strSQL += " (rcpt_no, rcpt_ent_empl_code, rcpt_brch_code, rcpt_cls, qg_care_no, arvl_cls, arvl_empl"
            strSQL += ", store_code, store_prsn, store_repr_no, store_accp_date, store_wrn_info, store_tech_rate"
            strSQL += ", store_tech_mrgn_rate, store_part_mrgn_rate, user_name, user_name_kana, zip, adrs1, adrs2, tel1"
            strSQL += ", tel2, rpar_cls, prch_date, vndr_wrn_date, vndr_wrn_date_chk, vndr_code, model_1, model_2, note_kbn, s_n"
            strSQL += ", rpar_comp_code, user_trbl, rcpt_comn, orgnl_vndr_code, wrn_limt_amnt, menseki_amnt, acdt_stts"
            strSQL += ", acdt_date, recv_amnt, tech_rate1, fix1, tech_rate2, part_rate2, etmt_ent_empl_code, etmt_brch_code"
            strSQL += ", etmt_empl_code, tier, vndr_repr_no, etmt_meas, etmt_comn, rsrv_cacl_comn"

            strSQL += ", etmt_cost_tech_chrg, etmt_cost_apes, etmt_cost_part_chrg, etmt_cost_fee, etmt_cost_pstg, etmt_cost_tax, etmt_cost_cxl, etmt_cost_ttl"
            strSQL += ", etmt_shop_tech_chrg, etmt_shop_apes, etmt_shop_part_chrg, etmt_shop_fee, etmt_shop_pstg, etmt_shop_tax, etmt_shop_cxl, etmt_shop_ttl"
            strSQL += ", etmt_eu_tech_chrg, etmt_eu_apes, etmt_eu_part_chrg, etmt_eu_fee, etmt_eu_pstg, etmt_eu_tax, etmt_eu_cxl, etmt_eu_ttl"

            strSQL += ", zh_code, fin_ent_empl_code, repr_empl_code, repr_brch_code, comp_meas, m_tech_seq, comp_comn"

            strSQL += ", comp_cost_tech_chrg, comp_cost_apes, comp_cost_part_chrg, comp_cost_fee, comp_cost_pstg, comp_cost_tax, comp_cost_cxl, comp_cost_ttl"
            strSQL += ", comp_shop_tech_chrg, comp_shop_apes, comp_shop_part_chrg, comp_shop_fee, comp_shop_pstg, comp_shop_tax, comp_shop_cxl, comp_shop_ttl"
            strSQL += ", comp_eu_tech_chrg, comp_eu_apes, comp_eu_part_chrg, comp_eu_fee, comp_eu_pstg, comp_eu_tax, comp_eu_cxl, comp_eu_ttl"

            strSQL += ", zero_code, zero_name, re_rpar_date, rebate, kjo_brch_code, rcpt_no_aka, rcpt_no_kuro"
            strSQL += ", accp_date, etmt_date, rsrv_cacl_date, part_ordr_date, part_rcpt_date, comp_date, sals_date, ship_date"
            strSQL += ", rqst_date, tax_rate, idvd_chrg, aka_flg, rpt_ex_flg)"
            strSQL += " VALUES ('" & Edit000.Text & "'"
            strSQL += ", " & WK_DtView1(0)("rcpt_ent_empl_code") & ""
            strSQL += ", '" & WK_DtView1(0)("rcpt_brch_code") & "'"
            strSQL += ", '" & WK_DtView1(0)("rcpt_cls") & "'"
            strSQL += ", '" & WK_DtView1(0)("qg_care_no") & "'"
            strSQL += ", '07'"  'その他
            strSQL += ", " & WK_DtView1(0)("arvl_empl") & ""
            strSQL += ", '" & WK_DtView1(0)("store_code") & "'"
            strSQL += ", '" & WK_DtView1(0)("store_prsn") & "'"
            strSQL += ", '" & WK_DtView1(0)("store_repr_no") & "'"
            If Not IsDBNull(WK_DtView1(0)("store_accp_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("store_accp_date") & "', 102)" Else strSQL += ", NULL"
            strSQL += ", '" & WK_DtView1(0)("store_wrn_info") & "'"
            If Not IsDBNull(WK_DtView1(0)("store_tech_rate")) Then strSQL += ", " & WK_DtView1(0)("store_tech_rate") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("store_tech_mrgn_rate")) Then strSQL += ", " & WK_DtView1(0)("store_tech_mrgn_rate") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("store_part_mrgn_rate")) Then strSQL += ", " & WK_DtView1(0)("store_part_mrgn_rate") & "" Else strSQL += ", NULL"
            strSQL += ", '" & WK_DtView1(0)("user_name") & "'"
            strSQL += ", '" & WK_DtView1(0)("user_name_kana") & "'"
            strSQL += ", '" & WK_DtView1(0)("zip") & "'"
            strSQL += ", '" & WK_DtView1(0)("adrs1") & "'"
            strSQL += ", '" & WK_DtView1(0)("adrs2") & "'"
            strSQL += ", '" & WK_DtView1(0)("tel1") & "'"
            strSQL += ", '" & WK_DtView1(0)("tel2") & "'"
            strSQL += ", '" & WK_DtView1(0)("rpar_cls") & "'"
            If Not IsDBNull(WK_DtView1(0)("prch_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("prch_date") & "', 102)" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("vndr_wrn_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("vndr_wrn_date") & "', 102)" Else strSQL += ", NULL"
            If WK_DtView1(0)("vndr_wrn_date_chk") = "True" Then strSQL += ", 1" Else strSQL += ", 0"
            strSQL += ", '" & WK_DtView1(0)("vndr_code") & "'"
            strSQL += ", '" & WK_DtView1(0)("model_1") & "'"
            strSQL += ", '" & WK_DtView1(0)("model_2") & "'"
            strSQL += ", '" & WK_DtView1(0)("note_kbn") & "'"
            strSQL += ", '" & WK_DtView1(0)("s_n") & "'"
            strSQL += ", '" & WK_DtView1(0)("rpar_comp_code") & "'"
            strSQL += ", '" & WK_DtView1(0)("user_trbl") & "'"
            strSQL += ", '" & WK_DtView1(0)("rcpt_comn") & "'"
            strSQL += ", '" & WK_DtView1(0)("orgnl_vndr_code") & "'"
            strSQL += ", " & WK_DtView1(0)("wrn_limt_amnt") & ""
            strSQL += ", " & WK_DtView1(0)("menseki_amnt") & ""
            strSQL += ", '" & WK_DtView1(0)("acdt_stts") & "'"
            If Not IsDBNull(WK_DtView1(0)("acdt_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("acdt_date") & "', 102)" Else strSQL += ", NULL"
            strSQL += ", " & WK_DtView1(0)("recv_amnt") & ""
            strSQL += ", " & WK_DtView1(0)("tech_rate1") & ""
            If Not IsDBNull(WK_DtView1(0)("fix1")) Then strSQL += ", " & WK_DtView1(0)("fix1") & ""
            strSQL += ", " & WK_DtView1(0)("tech_rate2") & ""
            strSQL += ", " & WK_DtView1(0)("part_rate2") & ""
            If Not IsDBNull(WK_DtView1(0)("etmt_ent_empl_code")) Then strSQL += ", " & WK_DtView1(0)("etmt_ent_empl_code") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_brch_code")) Then strSQL += ", '" & WK_DtView1(0)("etmt_brch_code") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_empl_code")) Then strSQL += ", " & WK_DtView1(0)("etmt_empl_code") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("tier")) Then strSQL += ", '" & WK_DtView1(0)("tier") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("vndr_repr_no")) Then strSQL += ", '" & WK_DtView1(0)("vndr_repr_no") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_meas")) Then strSQL += ", '" & WK_DtView1(0)("etmt_meas") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_comn")) Then strSQL += ", '" & WK_DtView1(0)("etmt_comn") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("rsrv_cacl_comn")) Then strSQL += ", '" & WK_DtView1(0)("rsrv_cacl_comn") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_tech_chrg")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_tech_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_apes")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_apes") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_part_chrg")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_part_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_fee")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_fee") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_pstg")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_pstg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_tax")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_tax") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_cxl")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_cxl") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_cost_ttl")) Then strSQL += ", " & WK_DtView1(0)("etmt_cost_ttl") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_tech_chrg")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_tech_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_apes")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_apes") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_part_chrg")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_part_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_fee")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_fee") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_pstg")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_pstg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_tax")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_tax") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_cxl")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_cxl") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_shop_ttl")) Then strSQL += ", " & WK_DtView1(0)("etmt_shop_ttl") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_tech_chrg")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_tech_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_apes")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_apes") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_part_chrg")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_part_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_fee")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_fee") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_pstg")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_pstg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_tax")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_tax") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_cxl")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_cxl") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_eu_ttl")) Then strSQL += ", " & WK_DtView1(0)("etmt_eu_ttl") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("zh_code")) Then strSQL += ", '" & WK_DtView1(0)("zh_code") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("fin_ent_empl_code")) Then strSQL += ", " & WK_DtView1(0)("fin_ent_empl_code") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("repr_empl_code")) Then strSQL += ", " & WK_DtView1(0)("repr_empl_code") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("repr_brch_code")) Then strSQL += ", N'" & WK_DtView1(0)("repr_brch_code") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_meas")) Then strSQL += ", '" & WK_DtView1(0)("comp_meas") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("m_tech_seq")) Then strSQL += ", " & WK_DtView1(0)("m_tech_seq") & "" Else strSQL += ", NULL"

            strSQL += ", '" & Edit1.Text & System.Environment.NewLine & "ｵﾘｼﾞﾅﾙの受付番号" & P_PRAM1 & "を赤伝処処理'"

            If Not IsDBNull(WK_DtView1(0)("comp_cost_tech_chrg")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_tech_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_cost_apes")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_apes") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_cost_part_chrg")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_part_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_cost_fee")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_fee") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_cost_pstg")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_pstg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_cost_tax")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_tax") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_cost_cxl")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_cxl") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_cost_ttl")) Then strSQL += ", " & WK_DtView1(0)("comp_cost_ttl") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_tech_chrg")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_tech_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_apes")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_apes") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_part_chrg")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_part_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_fee")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_fee") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_pstg")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_pstg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_tax")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_tax") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_cxl")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_cxl") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_shop_ttl")) Then strSQL += ", " & WK_DtView1(0)("comp_shop_ttl") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_tech_chrg")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_tech_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_apes")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_apes") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_part_chrg")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_part_chrg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_fee")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_fee") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_pstg")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_pstg") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_tax")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_tax") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_cxl")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_cxl") & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("comp_eu_ttl")) Then strSQL += ", " & WK_DtView1(0)("comp_eu_ttl") * -1 & "" Else strSQL += ", NULL"

            If Not IsDBNull(WK_DtView1(0)("zero_code")) Then strSQL += ", '" & WK_DtView1(0)("zero_code") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("zero_name")) Then strSQL += ", '" & WK_DtView1(0)("zero_name") & "'" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("re_rpar_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("re_rpar_date") & "', 102)" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("rebate")) Then strSQL += ", " & WK_DtView1(0)("rebate") * -1 & "" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("kjo_brch_code")) Then strSQL += ", N'" & WK_DtView1(0)("kjo_brch_code") & "'" Else strSQL += ", NULL"
            strSQL += ", '" & WK_DtView1(0)("rcpt_no") & "'"
            strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("accp_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("accp_date") & "', 102)" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("etmt_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("etmt_date") & "', 102)" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("rsrv_cacl_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("rsrv_cacl_date") & "', 102)" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("part_ordr_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("part_ordr_date") & "', 102)" Else strSQL += ", NULL"
            If Not IsDBNull(WK_DtView1(0)("part_rcpt_date")) Then strSQL += ", CONVERT(DATETIME, '" & WK_DtView1(0)("part_rcpt_date") & "', 102)" Else strSQL += ", NULL"
            strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
            strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
            strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
            strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
            strSQL += ", " & WK_DtView1(0)("tax_rate") & ""
            If Not IsDBNull(WK_DtView1(0)("idvd_chrg")) Then strSQL += ", " & WK_DtView1(0)("idvd_chrg") * -1 & "" Else strSQL += ", 0"
            strSQL += ", 1"
            If rpt_ex_flg = "1" Then '当月
                strSQL += ", 1)"
            Else
                strSQL += ", 0)"
            End If
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            Call QA_started_flg_ON(Edit000.Text)    'Q&A 着手済フラグ更新

            'T02更新
            strSQL = "INSERT INTO T02_ATCH_ITEM (rcpt_no, seq, item_code, item_name, amnt, item_unit)"
            strSQL += " SELECT '" & Edit000.Text & "' AS rcpt_no, seq, item_code, item_name, amnt, item_unit"
            strSQL += " FROM T02_ATCH_ITEM AS T02_ATCH_ITEM_1"
            strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            'T03更新
            strSQL = "INSERT INTO T03_REP_CMNT (rcpt_no, kbn, seq, cls_code1, cmnt_code1)"
            strSQL += " SELECT '" & Edit000.Text & "' AS rcpt_no, kbn, seq, cls_code1, cmnt_code1"
            strSQL += " FROM T03_REP_CMNT AS T03_REP_CMNT_1"
            strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            'T04更新
            strSQL = "INSERT INTO T04_REP_PART (rcpt_no, kbn, seq, part_code, part_name, part_amnt, use_qty, zaiko_flg, cost_chrg, shop_chrg"
            strSQL += ", eu_chrg, ordr_no, ordr_no2, ibm_flg)"
            strSQL += " SELECT '" & Edit000.Text & "' AS rcpt_no, kbn, seq, part_code, part_name, part_amnt"
            strSQL += ", use_qty * - 1 AS use_qty, zaiko_flg, cost_chrg * - 1 AS cost_chrg, shop_chrg * - 1 AS shop_chrg"
            strSQL += ", eu_chrg * - 1 AS eu_chrg, ordr_no, ordr_no2, ibm_flg"
            strSQL += " FROM T04_REP_PART AS T04_REP_PART_1"
            strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            WK_int = Number1.Value + RoundDOWN(Number1.Value * WK_DtView1(0)("tax_rate") / 100, 0)
            If Not IsDBNull(WK_DtView1(0)("comp_comn")) Then WK_comp_comn = WK_DtView1(0)("comp_comn") Else WK_comp_comn = Nothing

            add_hsty(P_PRAM1, "赤伝入力", "0", Number1.Value)

            NEVA_Print(Edit000.Text)

            '元データ更新
            strSQL = "UPDATE T01_REP_MTR"
            strSQL += " SET aka_flg = 1"
            If rpt_ex_flg = "1" Then '当月
                strSQL += ", rpt_ex_flg = 1"
            Else
                strSQL += ", rpt_ex_flg = 0"
            End If
            If WK_comp_comn = Nothing Then
                strSQL += ", comp_comn = '" & "受付番号" & Edit000.Text & "にて赤伝処理'"
            Else
                strSQL += ", comp_comn = '" & WK_comp_comn & System.Environment.NewLine & "受付番号" & Edit000.Text & "にて赤伝処理'"
            End If
            strSQL += ", ship_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
            strSQL += ", rqst_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
            strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()
            DB_CLOSE()

            If (DtView1(0)("rcpt_cls") = "02" Or DtView1(0)("rcpt_cls") = "03") And DtView1(0)("rpar_cls") <> "02" Then
                'QG Care 修理金額累計
                QG_HSTY(DtView1(0)("qg_care_no"), Edit000.Text, DtView1(0)("acdt_date"), WK_int)
            End If

            'TSS
            TSS_F = "0"
            WK_DsList1.Clear()
            strSQL = "SELECT T01_REP_MTR.tss_aka_stts, V_TSS_REP_INF.id"
            strSQL += " FROM T01_REP_MTR LEFT OUTER JOIN"
            strSQL += " V_TSS_REP_INF ON T01_REP_MTR.rcpt_no = V_TSS_REP_INF.rcpt_no"
            strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & Edit000.Text & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            DaList1.Fill(WK_DsList1, "T01_REP_MTR")
            DB_CLOSE()

            WK_DtView1 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

            If IsDBNull(WK_DtView1(0)("tss_aka_stts")) Then
                If Not IsDBNull(WK_DtView1(0)("id")) Then
                    TSS_F = "1"
                End If
                Select Case P_PRAM2
                    Case Is = "18"
                        If P_PRAM3 = "07" Then
                            TSS_F = "1"
                        End If
                    Case Is = "19"
                        TSS_F = "1"
                End Select

                If TSS_F = "1" Then
                    strSQL = "UPDATE T01_REP_MTR"
                    strSQL += " SET tss_aka_stts = '1'"
                    strSQL += " WHERE (rcpt_no = '" & Edit000.Text & "')"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN("nMVAR")
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                End If
            End If

            DspSet()
            msg.Text = "更新しました。"
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub F_Check()
        Err_F = "0"
        msg.Text = Nothing

        ''赤金額
        'If Number1.Value = 0 Then
        '    msg.Text = "赤金額を入力してください。"
        '    Number1.Focus()
        '    Err_F = "1" : Exit Sub
        'End If

        '理由
        Edit1.Text = Trim(Edit1.Text)
        If Edit1.Text = Nothing Then
            msg.Text = "理由を入力してください。"
            Edit1.Focus()
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '********************************************************************
    '**  納品書印刷
    '********************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        NEVA_Print(Edit000.Text)
        DspSet()
    End Sub

    Sub NEVA_Print(ByVal SP_rcpt_no)

        WK_DsList1.Clear()
        strSQL = "SELECT M08_STORE_1.dlvr_rprt_cls, M08_STORE_1.grup_code, T01_REP_MTR.sals_date, T01_REP_MTR.sals_no, T01_REP_MTR.ship_date"
        strSQL += " FROM T01_REP_MTR INNER JOIN"
        strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
        strSQL += " M08_STORE AS M08_STORE_1 ON M08_STORE.dlvr_code = M08_STORE_1.store_code"
        strSQL += " WHERE (T01_REP_MTR.rcpt_no = '" & SP_rcpt_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "M08_STORE")
        DB_CLOSE()
        WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)

        Select Case WK_DtView1(0)("dlvr_rprt_cls")
            Case Is = "0"                       '印刷しない
                P_RTN = "1"

            Case Is = "1"
                PRT_PRAM1 = "Print_R_NEVA"      'ネバ伝印刷
                PRT_PRAM2 = SP_rcpt_no
                Dim F70_Form02 As New F70_Form02
                F70_Form02.ShowDialog()

                P_PRAM3 = "neva"
                Dim F00_Form07_2 As New F00_Form07_2
                F00_Form07_2.ShowDialog()

            Case Is = "2"
                PRT_PRAM1 = "Print_R_chain"     'チェーン伝票印刷
                PRT_PRAM2 = SP_rcpt_no
                Dim F70_Form02 As New F70_Form02
                F70_Form02.ShowDialog()

                P_PRAM3 = "neva"
                Dim F00_Form07_2 As New F00_Form07_2
                F00_Form07_2.ShowDialog()
        End Select

        If P_RTN = "1" Then
            If WK_DtView1(0)("dlvr_rprt_cls") <> "0" Then
                DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)

                If IsDBNull(WK_DtView1(0)("sals_no")) Then WK_str2 = Nothing Else WK_str2 = DtView1(0)("WK_DtView1")
                If P_PRAM3 <> WK_str2 Then
                    add_hsty(SP_rcpt_no, "ネバ伝番号", WK_str2, P_PRAM3)
                End If

                strSQL = "UPDATE T01_REP_MTR"
                strSQL += " SET sals_date = '" & Now.Date & "'"
                strSQL += ", sals_no = '" & P2_F00_Form07_2 & "'"
                strSQL += ", sals_no2 = '" & P3_F00_Form07_2 & "'"
                strSQL += ", ship_date = '" & Now.Date & "'"
                strSQL += " WHERE (rcpt_no = '" & SP_rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

            Else
                strSQL = "UPDATE T01_REP_MTR"
                strSQL += " SET sals_date = '" & Now.Date & "'"
                strSQL += ", ship_date = '" & Now.Date & "'"
                strSQL += " WHERE (rcpt_no = '" & SP_rcpt_no & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
            End If

            WK_str = Now.Date
            If IsDBNull(WK_DtView1(0)("sals_date")) Then WK_str2 = Nothing Else WK_str2 = WK_DtView1(0)("sals_date")
            If WK_str <> WK_str2 Then
                add_hsty(SP_rcpt_no, "売上日", WK_str2, WK_str)
            End If

            WK_str = Now.Date
            If IsDBNull(WK_DtView1(0)("ship_date")) Then WK_str2 = Nothing Else WK_str2 = WK_DtView1(0)("ship_date")
            If WK_str <> WK_str2 Then
                add_hsty(SP_rcpt_no, "出荷日", WK_str2, WK_str)
            End If

            sals_ADD(SP_rcpt_no)
        End If

    End Sub

    Sub sals_ADD(ByVal SP_rcpt_no)
        Dim WK_amnt As Integer

        DB_OPEN("nMVAR")

        WK_DsList1.Clear()
        WK_amnt = 0
        strSQL = "SELECT * FROM T10_SALS WHERE (rcpt_no = '" & P_PRAM1 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(WK_DsList1, "T10_SALS")
        DtView2 = New DataView(WK_DsList1.Tables("T10_SALS"), "", "", DataViewRowState.CurrentRows)
        If DtView2.Count <> 0 Then
            For i = 0 To DtView2.Count - 1
                '売上
                strSQL = "INSERT INTO T10_SALS"
                strSQL += " ( rcpt_no, cls, sals_amnt, sals_tax, neva_chek_flg, neva_chek_flg2, neva_chek_date, neva_chek_date2, invc_flg)"
                strSQL += " VALUES ('" & SP_rcpt_no & "'"
                strSQL += ", '" & DtView2(i)("cls") & "'"
                strSQL += ", " & DtView2(i)("sals_amnt") * -1
                strSQL += ", " & RoundDOWN(DtView2(i)("sals_amnt") * -1 * Wk_TAX_0, 0)
                strSQL += ", 1"
                strSQL += ", 1"
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                strSQL += ", 1)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
                WK_amnt = WK_amnt + DtView2(i)("sals_amnt") * -1

                'ｵﾘｼﾞﾅﾙの検収on
                strSQL = "UPDATE T10_SALS"
                strSQL += " SET neva_chek_flg = 1"
                strSQL += ", neva_chek_flg2 = 1"
                If Not IsDBNull(DtView2(i)("neva_chek_date")) Then
                    strSQL += ", neva_chek_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                End If
                If Not IsDBNull(DtView2(i)("neva_chek_date2")) Then
                    strSQL += ", neva_chek_date2 = CONVERT(DATETIME, '" & Now.Date & "', 102)"
                End If
                strSQL += ", invc_flg = 1"
                strSQL += " WHERE (rcpt_no = '" & DtView2(i)("rcpt_no") & "')"
                strSQL += " AND (cls = '" & DtView2(i)("cls") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            Next
        End If

        'WK_DsList1.Clear()
        'strSQL = "SELECT * FROM T10_SALS"
        'strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
        'strSQL += " AND (cls = N'" & i & "')"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'DaList1.SelectCommand = SqlCmd1
        'DaList1.Fill(WK_DsList1, "T10_SALS")
        'WK_DtView1 = New DataView(WK_DsList1.Tables("T10_SALS"), "", "", DataViewRowState.CurrentRows)

        'If WK_DtView1(0)("invc_flg") = False Then
        '    'ｵﾘｼﾞﾅﾙの検収on
        '    strSQL = "UPDATE T10_SALS"
        '    strSQL += " SET neva_chek_flg = 1"
        '    strSQL += ", neva_chek_flg2 = 1"
        '    If Not IsDBNull(WK_DtView1(0)("neva_chek_date")) Then
        '        strSQL += ", neva_chek_date = CONVERT(DATETIME, '" & Now.Date & "', 102)"
        '    End If
        '    If Not IsDBNull(WK_DtView1(0)("neva_chek_date2")) Then
        '        strSQL += ", neva_chek_date2 = CONVERT(DATETIME, '" & Now.Date & "', 102)"
        '    End If
        '    strSQL += ", invc_flg = 1"
        '    strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
        '    strSQL += " AND (cls = '" & i & "')"
        '    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        '    SqlCmd1.ExecuteNonQuery()
        'End If
        '入金
        'strSQL = "INSERT INTO T30_CLCT"
        'strSQL += " (iｎvc_no, rcpt_no, clct_date, clct_no, clct_amnt)"
        'strSQL += " VALUES (0"
        'strSQL += ", '" & SP_rcpt_no & "'"
        'strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
        'strSQL += ", '0'"
        'strSQL += ", " & WK_amnt & ")"
        'SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        'SqlCmd1.ExecuteNonQuery()

        WK_DsList1.Clear()
        strSQL = "SELECT rcpt_no FROM T21_INVC_SUB"
        strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(WK_DsList1, "T21_INVC_SUB")
        WK_DtView1 = New DataView(WK_DsList1.Tables("T21_INVC_SUB"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then   '請求している

            WK_DsList1.Clear()
            strSQL = "SELECT * FROM T30_CLCT"
            strSQL += " WHERE (rcpt_no = '" & P_PRAM1 & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(WK_DsList1, "T30_CLCT")
            WK_DtView1 = New DataView(WK_DsList1.Tables("T30_CLCT"), "", "", DataViewRowState.CurrentRows)
            If WK_DtView1.Count = 0 Then    '入金なし

                'ｵﾘｼﾞﾅﾙの入金
                strSQL = "INSERT INTO T30_CLCT"
                strSQL += " (iｎvc_no, rcpt_no, clct_date, clct_no, clct_amnt)"
                strSQL += " VALUES (0"
                strSQL += ", '" & P_PRAM1 & "'"
                strSQL += ", CONVERT(DATETIME, '" & Now.Date & "', 102)"
                strSQL += ", '0'"
                strSQL += ", " & WK_amnt * -1 & ")"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.ExecuteNonQuery()
            End If
        End If

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Number1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.GotFocus
        Number1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.GotFocus
        Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Number1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Number1.LostFocus
        Number1.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        Edit1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        WK_DsList1.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class