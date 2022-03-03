Public Class F50_Form03
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsList2, DsCMB As New DataSet
    Dim WK_DsList1 As New DataSet
    Dim DtView1 As DataView
    Dim WK_DtView1, WK_DtView2 As DataView

    Dim strSQL, strWH, Err_F, inz_F As String
    Dim i, chg_itm As Integer
    Dim crt_date As Date
    Dim M_CLS As String = "M04"

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
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridBoolColumn2 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGridBoolColumn3 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo002 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Combo003 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents CL002 As System.Windows.Forms.Label
    Friend WithEvents CL003 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_chg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGrid1 = New nMVAR.DataGridEx
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridBoolColumn2 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridBoolColumn3 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button98 = New System.Windows.Forms.Button
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Button80 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo002 = New GrapeCity.Win.Input.Interop.Combo
        Me.Combo003 = New GrapeCity.Win.Input.Interop.Combo
        Me.CL001 = New System.Windows.Forms.Label
        Me.CL002 = New System.Windows.Forms.Label
        Me.CL003 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_chg = New System.Windows.Forms.Label
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "更新"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridBoolColumn1, Me.DataGridBoolColumn2, Me.DataGridBoolColumn3, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M04_BRCH_ACES"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(20, 36)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(964, 604)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "会社名"
        Me.DataGridTextBoxColumn1.MappingName = "comp_name"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 150
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "部署名"
        Me.DataGridTextBoxColumn2.MappingName = "brch_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 220
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "職位"
        Me.DataGridTextBoxColumn3.MappingName = "post_name"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 150
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "処理"
        Me.DataGridTextBoxColumn4.MappingName = "exe_name"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 237
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.AllowNull = False
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "参照"
        Me.DataGridBoolColumn1.MappingName = "acc1"
        Me.DataGridBoolColumn1.NullValue = "False"
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 50
        '
        'DataGridBoolColumn2
        '
        Me.DataGridBoolColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn2.AllowNull = False
        Me.DataGridBoolColumn2.FalseValue = False
        Me.DataGridBoolColumn2.HeaderText = "更新"
        Me.DataGridBoolColumn2.MappingName = "acc2"
        Me.DataGridBoolColumn2.NullValue = "False"
        Me.DataGridBoolColumn2.TrueValue = True
        Me.DataGridBoolColumn2.Width = 50
        '
        'DataGridBoolColumn3
        '
        Me.DataGridBoolColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn3.AllowNull = False
        Me.DataGridBoolColumn3.FalseValue = False
        Me.DataGridBoolColumn3.HeaderText = "削除"
        Me.DataGridBoolColumn3.MappingName = "acc3"
        Me.DataGridBoolColumn3.NullValue = "False"
        Me.DataGridBoolColumn3.TrueValue = True
        Me.DataGridBoolColumn3.Width = 50
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "0"
        Me.DataGridTextBoxColumn6.MappingName = "access_cls"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 0
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.MappingName = "brch_code"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 0
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.MappingName = "post_code"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 0
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.MappingName = "exe_code"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 0
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.MappingName = "access_cls2"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 0
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(912, 648)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 2
        Me.Button98.Text = "戻る"
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(944, 8)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox2.TabIndex = 1148
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(972, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(24, 16)
        Me.CheckBox1.TabIndex = 1147
        Me.CheckBox1.Visible = False
        '
        'Button80
        '
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(812, 648)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(68, 32)
        Me.Button80.TabIndex = 1149
        Me.Button80.Text = "履歴"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(100, 652)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(704, 24)
        Me.msg.TabIndex = 1183
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Combo001
        '
        Me.Combo001.Location = New System.Drawing.Point(88, 8)
        Me.Combo001.MaxDropDownItems = 30
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(220, 24)
        Me.Combo001.TabIndex = 1184
        Me.Combo001.Value = "Combo001"
        '
        'Combo002
        '
        Me.Combo002.Location = New System.Drawing.Point(380, 8)
        Me.Combo002.MaxDropDownItems = 30
        Me.Combo002.Name = "Combo002"
        Me.Combo002.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo002.Size = New System.Drawing.Size(150, 24)
        Me.Combo002.TabIndex = 1185
        Me.Combo002.Value = "Combo002"
        '
        'Combo003
        '
        Me.Combo003.Location = New System.Drawing.Point(600, 8)
        Me.Combo003.MaxDropDownItems = 30
        Me.Combo003.Name = "Combo003"
        Me.Combo003.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo003.Size = New System.Drawing.Size(237, 24)
        Me.Combo003.TabIndex = 1186
        Me.Combo003.Value = "Combo003"
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(88, 32)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(44, 24)
        Me.CL001.TabIndex = 1235
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'CL002
        '
        Me.CL002.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL002.Location = New System.Drawing.Point(384, 32)
        Me.CL002.Name = "CL002"
        Me.CL002.Size = New System.Drawing.Size(44, 24)
        Me.CL002.TabIndex = 1236
        Me.CL002.Text = "CL002"
        Me.CL002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL002.Visible = False
        '
        'CL003
        '
        Me.CL003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL003.Location = New System.Drawing.Point(600, 32)
        Me.CL003.Name = "CL003"
        Me.CL003.Size = New System.Drawing.Size(44, 24)
        Me.CL003.TabIndex = 1237
        Me.CL003.Text = "CL003"
        Me.CL003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL003.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(32, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 24)
        Me.Label4.TabIndex = 1238
        Me.Label4.Text = "部署"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(324, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 1239
        Me.Label1.Text = "職位"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(544, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 24)
        Me.Label2.TabIndex = 1240
        Me.Label2.Text = "処理"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_chg
        '
        Me.cmb_chg.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.cmb_chg.Location = New System.Drawing.Point(844, 8)
        Me.cmb_chg.Name = "cmb_chg"
        Me.cmb_chg.Size = New System.Drawing.Size(64, 24)
        Me.cmb_chg.TabIndex = 1241
        Me.cmb_chg.Text = "cmb_chg"
        Me.cmb_chg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmb_chg.Visible = False
        '
        'F50_Form03
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
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
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form03"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "権限設定マスタ"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo003, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz_F = "1"
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        DsSet()     '**  データセット
        CmbSet()    '**  コンボボックスセット
        inz_F = "0"
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

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

        Button1.Enabled = False
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='503'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "3", "4"
                Button1.Enabled = True
        End Select
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
        Combo001.Text = Nothing
        CL001.Text = Nothing

        '職位
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '004') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_004")

        Combo002.DataSource = DsCMB.Tables("CLS_CODE_004")
        Combo002.DisplayMember = "cls_code_name"
        Combo002.ValueMember = "cls_code"

        Combo002.SelectedItem = Nothing
        Combo002.Text = Nothing
        CL002.Text = Nothing

        '処理
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '010') AND (delt_flg = 0)"
        strSQL += " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "CLS_CODE_010")

        Combo003.DataSource = DsCMB.Tables("CLS_CODE_010")
        Combo003.DisplayMember = "cls_code_name"
        Combo003.ValueMember = "cls_code"

        Combo003.SelectedItem = Nothing
        Combo003.Text = Nothing
        CL003.Text = Nothing

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

    '職位
    Private Sub Combo002_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo002.SelectedIndexChanged
        Combo002.Text = Trim(Combo002.Text)
        DtView1 = New DataView(DsCMB.Tables("CLS_CODE_004"), "cls_code_name = '" & Combo002.Text & "'", "", DataViewRowState.CurrentRows)
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
    '処理
    Private Sub Combo003_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo003.SelectedIndexChanged
        Combo003.Text = Trim(Combo003.Text)
        DtView1 = New DataView(DsCMB.Tables("CLS_CODE_010"), "cls_code_name = '" & Combo003.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            CL003.Text = DtView1(0)("cls_code")
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
    '**  データセット
    '********************************************************************
    Sub DsSet()
        DsList2.Clear()

        strSQL = "SELECT cls_code, cls_code_name"
        strSQL += " FROM M21_CLS_CODE"
        strSQL += " WHERE (cls_no = '009')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList2, "cls009")
        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DsList1.Clear()
        '権限設定マスタ
        strSQL = "SELECT * FROM  V_M04_main"
        strWH = Nothing
        If CL001.Text <> Nothing Then
            strWH = strWH & " WHERE (brch_code = '" & CL001.Text & "')"
        End If
        If CL002.Text <> Nothing Then
            If strWH = Nothing Then strWH = strWH & " WHERE" Else strWH = strWH & " AND"
            strWH = strWH & " (post_code = '" & CL002.Text & "')"
        End If
        If CL003.Text <> Nothing Then
            If strWH = Nothing Then strWH = strWH & " WHERE" Else strWH = strWH & " AND"
            strWH = strWH & " (exe_code = '" & CL003.Text & "')"
        End If
        If strWH <> Nothing Then strSQL += strWH
        strSQL += " ORDER BY comp_code, brch_code, post_code, dsp_seq"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "M04_BRCH_ACES")
        DB_CLOSE()

        'SqlCmd1 = New SqlClient.SqlCommand("sp_M04_BRCH_ACES", cnsqlclient)
        'SqlCmd1.CommandType = CommandType.StoredProcedure
        'DaList1.SelectCommand = SqlCmd1
        'DB_OPEN("nMVAR")
        'SqlCmd1.CommandTimeout = 600
        'DaList1.Fill(DsList1, "M04_BRCH_ACES")
        'DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M04_BRCH_ACES")
        DataGrid1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGrid1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

        DtView1 = New DataView(DsList1.Tables("M04_BRCH_ACES"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                DtView1(i)("acc1") = "False"
                DtView1(i)("acc2") = "False"
                DtView1(i)("acc3") = "False"

                If Not IsDBNull(DtView1(i)("access_cls")) Then
                    Select Case DtView1(i)("access_cls")
                        Case Is = "1"
                        Case Is = "2"
                            DtView1(i)("acc1") = "True"
                        Case Is = "3"
                            DtView1(i)("acc1") = "True"
                            DtView1(i)("acc2") = "True"
                        Case Is = "4"
                            DtView1(i)("acc1") = "True"
                            DtView1(i)("acc2") = "True"
                            DtView1(i)("acc3") = "True"
                    End Select
                End If
            Next
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    ''********************************************************************
    ''**  データグリッド色
    ''********************************************************************
    'Private Sub DataGrid1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
    '    If DataGrid1.CurrentRowIndex >= 0 Then
    '        DataGrid1.Select(DataGrid1.CurrentRowIndex)
    '    End If
    'End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGrid1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim hitinfo As DataGrid.HitTestInfo
        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                Select Case hitinfo.Column 'ﾁｪｯｸﾎﾞｯｸｽ ｸﾘｯｸ
                    Case Is = 4
                        If DataGrid1(DataGrid1.CurrentRowIndex, 4) = "False" Then
                            DataGrid1(DataGrid1.CurrentRowIndex, 4) = CheckBox1.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 7) = "2"
                        Else
                            DataGrid1(DataGrid1.CurrentRowIndex, 4) = CheckBox2.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 5) = CheckBox2.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 6) = CheckBox2.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 7) = "1"
                        End If
                    Case Is = 5
                        If DataGrid1(DataGrid1.CurrentRowIndex, 5) = "False" Then
                            DataGrid1(DataGrid1.CurrentRowIndex, 4) = CheckBox1.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 5) = CheckBox1.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 7) = "3"
                        Else
                            DataGrid1(DataGrid1.CurrentRowIndex, 5) = CheckBox2.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 6) = CheckBox2.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 7) = "2"
                        End If
                    Case Is = 6
                        If DataGrid1(DataGrid1.CurrentRowIndex, 6) = "False" Then
                            DataGrid1(DataGrid1.CurrentRowIndex, 4) = CheckBox1.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 5) = CheckBox1.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 6) = CheckBox1.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 7) = "4"
                        Else
                            DataGrid1(DataGrid1.CurrentRowIndex, 6) = CheckBox2.Checked
                            DataGrid1(DataGrid1.CurrentRowIndex, 7) = "3"
                        End If
                End Select
            End If

        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        chg_itm = 0
        crt_date = Now.Date
        P_HSTY_DATE = Now

        '権限設定マスタ
        WK_DtView1 = New DataView(DsList1.Tables("M04_BRCH_ACES"), "", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            For i = 0 To WK_DtView1.Count - 1
                If IsDBNull(WK_DtView1(i)("access_cls2")) Then
                    'ins
                    strSQL = "INSERT INTO M04_BRCH_ACES"
                    strSQL += " (brch_code, post_code, exe_code, access_cls, reg_date, delt_flg)"
                    strSQL += " VALUES ('" & WK_DtView1(i)("brch_code") & "'"
                    strSQL += ", '" & WK_DtView1(i)("post_code") & "'"
                    strSQL += ", '" & WK_DtView1(i)("exe_code") & "'"
                    If IsDBNull(WK_DtView1(i)("access_cls")) Then
                        strSQL += ", '1'"
                    Else
                        strSQL += ", '" & WK_DtView1(i)("access_cls") & "'"
                    End If
                    strSQL += ", '" & crt_date & "'"
                    strSQL += ", 0"
                    strSQL += ")"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                    chg_itm = chg_itm + 1
                Else
                    If WK_DtView1(i)("access_cls") <> WK_DtView1(i)("access_cls2") Then
                        'upd
                        strSQL = "UPDATE M04_BRCH_ACES"
                        strSQL += " SET access_cls = '" & WK_DtView1(i)("access_cls") & "'"
                        strSQL += " WHERE (brch_code = '" & WK_DtView1(i)("brch_code") & "')"
                        strSQL += " AND (post_code = '" & WK_DtView1(i)("post_code") & "')"
                        strSQL += " AND (exe_code = '" & WK_DtView1(i)("exe_code") & "')"
                        DB_OPEN("nMVAR")
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.CommandTimeout = 600
                        SqlCmd1.ExecuteNonQuery()
                        DB_CLOSE()

                        Dim WK_str, WK_str2 As String
                        WK_DtView2 = New DataView(DsList2.Tables("cls009"), "cls_code='" & WK_DtView1(i)("access_cls") & "'", "", DataViewRowState.CurrentRows)
                        If WK_DtView2.Count <> 0 Then
                            WK_str = WK_DtView2(0)("cls_code_name")
                        End If
                        WK_DtView2 = New DataView(DsList2.Tables("cls009"), "cls_code='" & WK_DtView1(i)("access_cls2") & "'", "", DataViewRowState.CurrentRows)
                        If WK_DtView2.Count <> 0 Then
                            WK_str2 = WK_DtView2(0)("cls_code_name")
                        End If
                        chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, "0", WK_DtView1(i)("comp_name") & " / " & WK_DtView1(i)("brch_name") & " / " & WK_DtView1(i)("post_name") & " / " & WK_DtView1(i)("exe_name"), WK_str2, WK_str)
                    End If
                End If
            Next
        End If

        If chg_itm = 0 Then
            msg.Text = "変更箇所がありません。"
        Else
            msg.Text = "更新しました。"
            DspSet()    '**  画面セット
        End If
        'MessageBox.Show("更新しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'DspSet()    '**  画面セット
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  履歴
    '********************************************************************
    Private Sub Button80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button80.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '変更履歴
        P_DsHsty.Clear()
        SqlCmd1 = New SqlClient.SqlCommand("sp_L02_MTR_HSTY", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        Dim Pram3 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 3)
        Dim Pram4 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p2", SqlDbType.Char, 20)
        Pram3.Value = M_CLS
        Pram4.Value = "0"
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(P_DsHsty, "HSTY")
        DB_CLOSE()

        Dim F80_Form01 As New F80_Form01
        F80_Form01.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsList1.Clear()
        DsList2.Clear()
        Close()
    End Sub
End Class
