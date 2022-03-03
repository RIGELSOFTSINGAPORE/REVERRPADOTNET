Public Class F40_Form10
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim DtView1 As DataView
    Dim WK_DtView1 As DataView

    Dim strSQL, inz_F, strFile, strData, csv_F As String
    Dim i, r As Integer

    Dim DGTS As New DataGridTableStyle
    'Dim dsInvoice As New DataSet
    'Dim dt2 As DataTable = dsInvoice.Tables.Add("INV2")
    Dim tbl As New DataTable

    Dim style0 As New MyDataGridTextBoxColumn3
    Dim style1 As New DataGridTextBoxColumn
    Dim style2 As New DataGridTextBoxColumn
    Dim style3 As New DataGridTextBoxColumn
    Dim style4 As New DataGridTextBoxColumn
    Dim style5 As New MyDataGridTextBoxColumn1
    Dim style6 As New DataGridTextBoxColumn
    Dim style7 As New DataGridTextBoxColumn
    Dim style8 As New MyDataGridTextBoxColumn2
    Dim style9 As New DataGridTextBoxColumn
    Dim style10 As New DataGridTextBoxColumn


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
    Friend WithEvents cmb_chg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Combo
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents DataGridEx1 As nMVAR_Report.DataGridEx
    Friend WithEvents Button50 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F40_Form10))
        Me.cmb_chg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CL003 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.Combo003 = New GrapeCity.Win.Input.Combo
        Me.Combo002 = New GrapeCity.Win.Input.Combo
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Button50 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.DataGridEx1 = New nMVAR_Report.DataGridEx
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_chg
        '
        Me.cmb_chg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.cmb_chg.Location = New System.Drawing.Point(840, 16)
        Me.cmb_chg.Name = "cmb_chg"
        Me.cmb_chg.Size = New System.Drawing.Size(64, 24)
        Me.cmb_chg.TabIndex = 1253
        Me.cmb_chg.Text = "cmb_chg"
        Me.cmb_chg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmb_chg.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(628, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 24)
        Me.Label2.TabIndex = 1252
        Me.Label2.Text = "自社/他社"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 1251
        Me.Label1.Text = "販社ｸﾞﾙｰﾌﾟ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 24)
        Me.Label4.TabIndex = 1250
        Me.Label4.Text = "拠点"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(728, -8)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(44, 24)
        Me.CL003.TabIndex = 1249
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(432, 0)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(44, 24)
        Me.CL002.TabIndex = 1248
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(172, 0)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(44, 24)
        Me.CL001.TabIndex = 1247
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Combo003
        '
        Me.Combo003.Location = New System.Drawing.Point(712, 16)
        Me.Combo003.MaxDropDownItems = 30
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(124, 24)
        Me.Combo003.TabIndex = 2
        Me.Combo003.Value = "Combo003"
        '
        'Combo002
        '
        Me.Combo002.Location = New System.Drawing.Point(392, 16)
        Me.Combo002.MaxDropDownItems = 30
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(220, 24)
        Me.Combo002.TabIndex = 1
        Me.Combo002.Value = "Combo002"
        '
        'Combo001
        '
        Me.Combo001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.Location = New System.Drawing.Point(68, 16)
        Me.Combo001.MaxDropDownItems = 30
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(220, 24)
        Me.Combo001.TabIndex = 0
        Me.Combo001.Value = "Combo001"
        '
        'Button50
        '
        Me.Button50.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button50.Location = New System.Drawing.Point(816, 584)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(76, 32)
        Me.Button50.TabIndex = 4
        Me.Button50.Text = "明細CSV"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(924, 584)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 5
        Me.Button98.Text = "戻る"
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(12, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(984, 528)
        Me.DataGridEx1.TabIndex = 3
        '
        'F40_Form10
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 623)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.cmb_chg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CL003)
        Me.Controls.Add(Me.CL002)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo003)
        Me.Controls.Add(Me.Combo002)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Button50)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F40_Form10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Back-Log　Daily Status"
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F40_Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz_F = "1"
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        CmbSet()    '**  コンボボックスセット
        inz_F = "0"
        DspSet()    '**  画面セット
        dtgrd_set() '**  データグリッドセット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

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

        Combo001.Enabled = False
        Combo002.Focus()
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='995'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "3", "4"
                    Combo001.Enabled = True
                    Combo001.Focus()
            End Select
        End If

        Button50.Enabled = False : csv_F = "0"
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='996'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "3", "4"
                    Button50.Enabled = True : csv_F = "1"
            End Select
        End If
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()

        '部署
        strSQL = "SELECT brch_code, brch_code + ':' + name AS brch_name"
        strSQL += " FROM M03_BRCH"
        strSQL += " WHERE (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, brch_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "M03_BRCH")
        DB_CLOSE()

        Combo001.DataSource = DsCMB.Tables("M03_BRCH")
        Combo001.DisplayMember = "brch_name"
        Combo001.ValueMember = "brch_code"

        Combo001.SelectedItem = Nothing
        Combo001.Text = P_ACES_brch_code & ":" & P_ACES_brch_name
        CL001.Text = P_EMPL_BRCH

        '販社ｸﾞﾙｰﾌﾟ
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '006') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_006")

        Combo002.DataSource = DsCMB.Tables("CLS_CODE_006")
        Combo002.DisplayMember = "cls_code_name"
        Combo002.ValueMember = "cls_code"

        Combo002.SelectedItem = Nothing
        Combo002.Text = Nothing
        CL002.Text = Nothing

        '自社/他社
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '012') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_012")

        Combo003.DataSource = DsCMB.Tables("CLS_CODE_012")
        Combo003.DisplayMember = "cls_code_name"
        Combo003.ValueMember = "cls_code"

        Combo003.SelectedItem = Nothing
        Combo003.Text = Nothing
        CL003.Text = Nothing

    End Sub

    Sub dtgrd_set()
        Dim dc As DataColumn
        dc = New DataColumn("Column0", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column1", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column2", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column3", GetType(String))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column4", GetType(DateTime))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column5", GetType(Integer))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column6", GetType(Integer))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column7", GetType(DateTime))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column8", GetType(DateTime))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column9", GetType(DateTime))
        tbl.Columns.Add(dc)
        dc = New DataColumn("Column10", GetType(DateTime))
        tbl.Columns.Add(dc)

        With style0
            .FormatInfo = Nothing
            .HeaderText = Nothing
            .MappingName = "rpar_cls"
            .ReadOnly = True
            .Width = 1
        End With

        With style1
            .FormatInfo = Nothing
            .HeaderText = "取次店名"
            .MappingName = "store_name"
            .ReadOnly = True
            .Width = 150
        End With

        With style2
            .Alignment = HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "受付番号"
            .MappingName = "rcpt_no"
            .ReadOnly = True
            .Width = 80
        End With

        With style3
            .FormatInfo = Nothing
            .HeaderText = "お客様名"
            .MappingName = "user_name"
            .ReadOnly = True
            .Width = 130
        End With

        With style4
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "受付日"
            .MappingName = "accp_date"
            .ReadOnly = True
            .Width = 80
        End With

        With style5
            .Alignment = System.Windows.Forms.HorizontalAlignment.Right
            .FormatInfo = Nothing
            .HeaderText = "経過日数"
            .MappingName = "keika"
            .ReadOnly = True
            .Width = 60
        End With

        With style6
            .Alignment = System.Windows.Forms.HorizontalAlignment.Right
            .Format = "##,###"
            .FormatInfo = Nothing
            .HeaderText = "金額"
            .MappingName = "etmt_eu_ttl"
            .NullText = ""
            .ReadOnly = True
            .Width = 55
        End With

        With style7
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "コンタクト最終更新日"
            .MappingName = "contact_date"
            .NullText = ""
            .ReadOnly = True
            .Width = 120
        End With

        With style8
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .FormatInfo = Nothing
            .HeaderText = "見積日付"
            .MappingName = "etmt_date"
            .NullText = ""
            .ReadOnly = True
            .Width = 80
        End With

        With style9
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .Format = ""
            .FormatInfo = Nothing
            .HeaderText = "回答受信日"
            .MappingName = "rsrv_cacl_date"
            .NullText = ""
            .ReadOnly = True
            .Width = 80
        End With

        With style10
            .Alignment = System.Windows.Forms.HorizontalAlignment.Center
            .Format = ""
            .FormatInfo = Nothing
            .HeaderText = "部品発注日"
            .MappingName = "part_ordr_date"
            .NullText = ""
            .ReadOnly = True
            .Width = 90
        End With

        DGTS.GridColumnStyles.Add(style0)
        DGTS.GridColumnStyles.Add(style1)
        DGTS.GridColumnStyles.Add(style2)
        DGTS.GridColumnStyles.Add(style3)
        DGTS.GridColumnStyles.Add(style4)
        DGTS.GridColumnStyles.Add(style5)
        DGTS.GridColumnStyles.Add(style6)
        DGTS.GridColumnStyles.Add(style7)
        DGTS.GridColumnStyles.Add(style8)
        DGTS.GridColumnStyles.Add(style9)
        DGTS.GridColumnStyles.Add(style10)
        DataGridEx1.TableStyles.Add(DGTS)

    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DsList1.Clear()

        strSQL = "SELECT T01_REP_MTR.rcpt_no, T01_REP_MTR.store_code, M08_STORE.name AS store_name, M08_STORE.grup_code"
        strSQL += ", V_cls_006.cls_code_name AS grup_name, T01_REP_MTR.user_name, T01_REP_MTR.accp_date, 0 AS keika"
        strSQL += ", T01_REP_MTR.etmt_eu_ttl, V_T08_CONTACT_1.contact_date, V_T05_INQUIRY_1.inq_date, T01_REP_MTR.etmt_date"
        strSQL += ", T01_REP_MTR.rsrv_cacl_date, T01_REP_MTR.part_ordr_date, T01_REP_MTR.comp_date"
        strSQL += ", T01_REP_MTR.rpar_comp_code, M06_RPAR_COMP.name AS rpar_comp_name, M06_RPAR_COMP.own_flg"
        strSQL += ", T01_REP_MTR.rcpt_brch_code, M03_BRCH.name AS rcpt_brch_name, T01_REP_MTR.rpar_cls"
        strSQL += " FROM T01_REP_MTR INNER JOIN"
        strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
        strSQL += " M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code INNER JOIN"
        strSQL += " M03_BRCH ON T01_REP_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
        strSQL += " V_cls_006 ON M08_STORE.grup_code = V_cls_006.cls_code LEFT OUTER JOIN"
        strSQL += " V_T05_INQUIRY_1 ON T01_REP_MTR.rcpt_no = V_T05_INQUIRY_1.rcpt_no LEFT OUTER JOIN"
        strSQL += " V_T08_CONTACT_1 ON T01_REP_MTR.rcpt_no = V_T08_CONTACT_1.rcpt_no"
        'strSQL += " FROM T01_REP_MTR INNER JOIN"
        'strSQL += " M08_STORE ON T01_REP_MTR.store_code = M08_STORE.store_code INNER JOIN"
        'strSQL += " M06_RPAR_COMP ON T01_REP_MTR.rpar_comp_code = M06_RPAR_COMP.rpar_comp_code INNER JOIN"
        'strSQL += " M03_BRCH ON T01_REP_MTR.rcpt_brch_code = M03_BRCH.brch_code INNER JOIN"
        'strSQL += " V_cls_006 ON M08_STORE.grup_code = V_cls_006.cls_code LEFT OUTER JOIN"
        'strSQL += " V_T08_CONTACT_1 ON T01_REP_MTR.rcpt_no = V_T08_CONTACT_1.rcpt_no"
        strSQL += " WHERE (T01_REP_MTR.comp_date IS NULL)"
        If CL001.Text <> Nothing Then
            strSQL += " AND (T01_REP_MTR.rcpt_brch_code = '" & CL001.Text & "')"
        End If
        If CL002.Text <> Nothing Then
            strSQL += " AND (M08_STORE.grup_code = '" & CL002.Text & "')"
        End If
        If CL003.Text <> Nothing Then
            strSQL += " AND (M06_RPAR_COMP.own_flg = " & CL003.Text & ")"
        End If
        strSQL += " ORDER BY T01_REP_MTR.accp_date, T01_REP_MTR.rcpt_no, T01_REP_MTR.store_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        r = DaList1.Fill(DsList1, "T01_REP_MTR")
        DB_CLOSE()

        If r = 0 Then
            Button50.Enabled = False
        Else
            If csv_F = "1" Then
                Button50.Enabled = True
            End If
            DtView1 = New DataView(DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                DtView1(i)("keika") = DateDiff(DateInterval.Day, DtView1(i)("accp_date").date, Now.Date) '経過日数

                If Not IsDBNull(DtView1(i)("contact_date")) Then
                    If Not IsDBNull(DtView1(i)("inq_date")) Then
                        If DtView1(i)("contact_date") < DtView1(i)("inq_date") Then
                            DtView1(i)("contact_date") = DtView1(i)("inq_date")
                        End If
                    End If
                Else
                    If Not IsDBNull(DtView1(i)("inq_date")) Then
                        DtView1(i)("contact_date") = DtView1(i)("inq_date")
                    End If
                End If

            Next
        End If

        tbl = DsList1.Tables("T01_REP_MTR")
        DGTS.MappingName = "T01_REP_MTR"
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

        With style10
            If CL003.Text = "0" Then
                .HeaderText = "メーカー発送日"
            Else
                .HeaderText = "部品発注日"
            End If
        End With

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  コンボ変更
    '********************************************************************
    '部署
    Private Sub Combo001_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.SelectedIndexChanged
        Combo001.Text = Trim(Combo001.Text)
        DtView1 = New DataView(DsCMB.Tables("M03_BRCH"), "brch_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            CL001.Text = DtView1(0)("brch_code")
        Else
            CL001.Text = Nothing
        End If
        cmb_chg.Text = CL001.Text & CL002.Text & CL003.Text
    End Sub
    Private Sub Combo001_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.TextChanged
        If Combo001.Text = Nothing Then
            CL001.Text = Nothing
            cmb_chg.Text = CL001.Text & CL002.Text & CL003.Text
        End If
    End Sub

    '販社ｸﾞﾙｰﾌﾟ
    Private Sub Combo002_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.SelectedIndexChanged
        Combo002.Text = Trim(Combo002.Text)
        DtView1 = New DataView(DsCMB.Tables("CLS_CODE_006"), "cls_code_name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            CL002.Text = DtView1(0)("cls_code")
        Else
            CL002.Text = Nothing
        End If
        cmb_chg.Text = CL001.Text & CL002.Text & CL003.Text
    End Sub
    Private Sub Combo002_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.TextChanged
        If Combo002.Text = Nothing Then
            CL002.Text = Nothing
            cmb_chg.Text = CL001.Text & CL002.Text & CL003.Text
        End If
    End Sub
    '自社/他社
    Private Sub Combo003_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.SelectedIndexChanged
        Combo003.Text = Trim(Combo003.Text)
        DtView1 = New DataView(DsCMB.Tables("CLS_CODE_012"), "cls_code_name = '" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            If DtView1(0)("cls_code") = "01" Then
                CL003.Text = "1"
            Else
                CL003.Text = "0"
            End If
        Else
            CL003.Text = Nothing
        End If
        cmb_chg.Text = CL001.Text & CL002.Text & CL003.Text
    End Sub
    Private Sub Combo003_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.TextChanged
        If Combo003.Text = Nothing Then
            CL003.Text = Nothing
            cmb_chg.Text = CL001.Text & CL002.Text & CL003.Text
        End If
    End Sub

    Private Sub cmb_chg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_chg.TextChanged
        If inz_F = "0" Then
            DspSet()    '**  画面セット
        End If
    End Sub

    '********************************************************************
    '**  明細CSV
    '********************************************************************
    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "Back-Log_Daily_Status明細.CSV"          'はじめのファイル名を指定する
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
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0       ' 最初の件数を設定
            Application.DoEvents()          ' メッセージ処理を促して表示を更新する

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "拠点,グループ名,取次店名,修理会社,伝票番号,お客様名,受付日,経過日数,金額,コンタクト最終日,見積日付,回答受信日"
            If CL003.Text = "0" Then
                strData += ",メーカー発送日"
            Else
                strData += ",部品発注日"
            End If
            swFile.WriteLine(strData)

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
                waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = DtView1(i)("rcpt_brch_name")                      '拠点
                strData += "," & DtView1(i)("grup_name")           'グループ名
                strData += "," & DtView1(i)("store_name")          '取次店名
                strData += "," & DtView1(i)("rpar_comp_name")      '修理会社
                strData += "," & DtView1(i)("rcpt_no")             '伝票番号
                strData += "," & DtView1(i)("user_name")           'お客様名
                strData += "," & DtView1(i)("accp_date")           '受付日
                strData += "," & DtView1(i)("keika")               '経過日数
                strData += "," & DtView1(i)("etmt_eu_ttl")         '金額
                strData += "," & DtView1(i)("contact_date")        'コンタクト最終日
                strData += "," & DtView1(i)("etmt_date")           '見積日付
                strData += "," & DtView1(i)("rsrv_cacl_date")      '回答受信日
                strData += "," & DtView1(i)("part_ordr_date")      '部品発注日

                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)
            Next

            swFile.Close()          'ファイルを閉じる
            MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            waitDlg.Close()         '進行状況ダイアログを閉じる
            Me.Enabled = True       'オーナーのフォームを無効にする
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        Close()
    End Sub
End Class
