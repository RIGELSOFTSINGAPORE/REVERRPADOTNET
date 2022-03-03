Public Class F00_Form05_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_cnt As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGridEx1 As nMVAR_TSS.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label011 As System.Windows.Forms.Label
    Friend WithEvents Edit001 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label010 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Edit003 As GrapeCity.Win.Input.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form05_2))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label_cnt = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.DataGridEx1 = New nMVAR_TSS.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label011 = New System.Windows.Forms.Label
        Me.Edit001 = New GrapeCity.Win.Input.Edit
        Me.Label010 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Edit003 = New GrapeCity.Win.Input.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.CL001 = New System.Windows.Forms.Label
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label3.Location = New System.Drawing.Point(788, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(188, 24)
        Me.Label3.TabIndex = 1318
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label1.Location = New System.Drawing.Point(788, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 24)
        Me.Label1.TabIndex = 1316
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Label_cnt
        '
        Me.Label_cnt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label_cnt.ForeColor = System.Drawing.Color.White
        Me.Label_cnt.Location = New System.Drawing.Point(884, 124)
        Me.Label_cnt.Name = "Label_cnt"
        Me.Label_cnt.Size = New System.Drawing.Size(88, 16)
        Me.Label_cnt.TabIndex = 1315
        Me.Label_cnt.Text = "Label_cnt"
        Me.Label_cnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(120, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 1309
        Me.Button1.Text = "クリア"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 660)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(872, 24)
        Me.msg.TabIndex = 1314
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(20, 120)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(964, 528)
        Me.DataGridEx1.TabIndex = 1310
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "scan"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "加入番号"
        Me.DataGridTextBoxColumn1.MappingName = "wrn_id"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 90
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "お客様名"
        Me.DataGridTextBoxColumn2.MappingName = "name"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 120
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "カナ"
        Me.DataGridTextBoxColumn3.MappingName = "name_kana"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 120
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "大学名"
        Me.DataGridTextBoxColumn4.MappingName = "uni_name"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 95
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "証券番号"
        Me.DataGridTextBoxColumn5.MappingName = "Securities_no"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 95
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "モデル"
        Me.DataGridTextBoxColumn6.MappingName = "model_name"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 120
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "購入金額"
        Me.DataGridTextBoxColumn7.MappingName = "prch_price"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 80
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "保険開始"
        Me.DataGridTextBoxColumn8.MappingName = "start_date"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 80
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "保証期間"
        Me.DataGridTextBoxColumn9.MappingName = "wrn_prod"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 70
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "ｼﾘｱﾙNo"
        Me.DataGridTextBoxColumn10.MappingName = "s_n"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 90
        '
        'Label011
        '
        Me.Label011.BackColor = System.Drawing.Color.Navy
        Me.Label011.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label011.ForeColor = System.Drawing.Color.White
        Me.Label011.Location = New System.Drawing.Point(20, 48)
        Me.Label011.Name = "Label011"
        Me.Label011.Size = New System.Drawing.Size(112, 24)
        Me.Label011.TabIndex = 1313
        Me.Label011.Text = "モデル"
        Me.Label011.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit001
        '
        Me.Edit001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit001.HighlightText = True
        Me.Edit001.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit001.LengthAsByte = True
        Me.Edit001.Location = New System.Drawing.Point(132, 16)
        Me.Edit001.MaxLength = 30
        Me.Edit001.Name = "Edit001"
        Me.Edit001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit001.Size = New System.Drawing.Size(216, 24)
        Me.Edit001.TabIndex = 1306
        Me.Edit001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label010
        '
        Me.Label010.BackColor = System.Drawing.Color.Navy
        Me.Label010.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label010.ForeColor = System.Drawing.Color.White
        Me.Label010.Location = New System.Drawing.Point(20, 16)
        Me.Label010.Name = "Label010"
        Me.Label010.Size = New System.Drawing.Size(112, 24)
        Me.Label010.TabIndex = 1312
        Me.Label010.Text = "お客様名"
        Me.Label010.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(20, 88)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 24)
        Me.Button4.TabIndex = 1308
        Me.Button4.Text = "検索"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(916, 660)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 1311
        Me.Button98.Text = "戻る"
        '
        'Edit003
        '
        Me.Edit003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit003.HighlightText = True
        Me.Edit003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit003.LengthAsByte = True
        Me.Edit003.Location = New System.Drawing.Point(132, 48)
        Me.Edit003.MaxLength = 14
        Me.Edit003.Name = "Edit003"
        Me.Edit003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit003.Size = New System.Drawing.Size(112, 24)
        Me.Edit003.TabIndex = 1307
        Me.Edit003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label2.Location = New System.Drawing.Point(788, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 24)
        Me.Label2.TabIndex = 1317
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(360, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 1320
        Me.Label7.Text = "大学"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Combo001.Location = New System.Drawing.Point(472, 16)
        Me.Combo001.MaxDropDownItems = 20
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(216, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1319
        Me.Combo001.Value = "Combo001"
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(692, 16)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(52, 20)
        Me.CL001.TabIndex = 1321
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "保険終了"
        Me.DataGridTextBoxColumn11.MappingName = "end_date"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 80
        '
        'F00_Form05_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label_cnt)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Label011)
        Me.Controls.Add(Me.Edit001)
        Me.Controls.Add(Me.Label010)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Edit003)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F00_Form05_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fujitsu"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F00_Form05_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        CmbSet()    '**  コンボボックスセット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        DsList1.Clear()
        strSQL = "SELECT T01_wrn_date.*, M01_insurance_co_decision.start_date, M01_insurance_co_decision.end_date"
        strSQL = strSQL & ", M01_insurance_co_decision.wrn_prod, M02_uni.uni_name"
        strSQL = strSQL & " FROM T01_wrn_date INNER JOIN"
        strSQL = strSQL & " M01_insurance_co_decision ON T01_wrn_date.Securities_no = M01_insurance_co_decision.Securities_no INNER JOIN"
        strSQL = strSQL & " M02_uni ON T01_wrn_date.uni_code = M02_uni.uni_code"
        strSQL = strSQL & " WHERE (T01_wrn_date.wrn_id = '0')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("Fujitsu")
        DaList1.Fill(DsList1, "scan")
        'DsList1.Tables("scan").Clear()
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("scan")
        DataGridEx1.DataSource = tbl

        P_RTN = "0"
        msg.Text = Nothing
        Label_cnt.Text = Nothing
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN("Fujitsu")

        '大学
        strSQL = "SELECT * FROM M02_uni"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "M02_uni")

        Combo001.DataSource = DsCMB.Tables("M02_uni")
        Combo001.DisplayMember = "uni_name"
        Combo001.ValueMember = "uni_code"
        Combo001.Text = Nothing

        DB_CLOSE()
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGridEx1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridEx1.Paint
        If DataGridEx1.CurrentRowIndex >= 0 Then
            DataGridEx1.Select(DataGridEx1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　エンター
    '********************************************************************
    Private Sub DataGridEx1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGridEx1.CmdKeyEvent
        If DataGridEx1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    P_RTN = "1"
                    P_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                    DsList1.Clear()
                    Close()
                Case Is = Keys.Space
                Case Is = Keys.Delete
                Case Is = Keys.Right
                Case Is = Keys.Left
            End Select
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGridEx1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridEx1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                P_RTN = "1"
                P_PRAM1 = DataGridEx1(DataGridEx1.CurrentRowIndex, 0)
                DsList1.Clear()
                Close()
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  検索
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing

        DsList1.Clear()
        strSQL = "SELECT T01_wrn_date.*, M01_insurance_co_decision.start_date, M01_insurance_co_decision.end_date"
        strSQL = strSQL & ", M01_insurance_co_decision.wrn_prod, M02_uni.uni_name"
        strSQL = strSQL & " FROM T01_wrn_date INNER JOIN"
        strSQL = strSQL & " M01_insurance_co_decision ON T01_wrn_date.Securities_no = M01_insurance_co_decision.Securities_no INNER JOIN"
        strSQL = strSQL & " M02_uni ON T01_wrn_date.uni_code = M02_uni.uni_code"
        strSQL = strSQL & " WHERE (T01_wrn_date.wrn_id IS NOT NULL)"
        If Edit001.Text <> Nothing Then
            strSQL = strSQL & " AND (T01_wrn_date.name LIKE N'%" & Label1.Text & "%'"
            strSQL = strSQL & " OR T01_wrn_date.name LIKE N'%" & Label2.Text & "%'"
            strSQL = strSQL & " OR T01_wrn_date.name LIKE N'%" & Label3.Text & "%')"
        End If
        If Combo001.Text <> Nothing Then
            strSQL = strSQL & " AND (T01_wrn_date.uni_code = " & CL001.Text & ")"
        End If
        If Edit003.Text <> Nothing Then
            strSQL = strSQL & " AND (T01_wrn_date.model_name LIKE '%" & Edit003.Text & "%')"
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("Fujitsu")
        DaList1.Fill(DsList1, "scan")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("scan"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count = 0 Then
            DataGridEx1.Enabled = False
            Label_cnt.Text = "0件"
            msg.Text = "該当するデータがありません。"
        Else
            DataGridEx1.Enabled = True
            Label_cnt.Text = Format(DtView1.Count, "##,##0") & "件"
            DataGridEx1.Focus()
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  項目チェック
    '********************************************************************
    Sub CHK_Combo001()   '大学
        msg.Text = Nothing
        CL001.Text = Nothing

        Combo001.Text = Trim(Combo001.Text)
        If Combo001.Text <> Nothing Then
            DtView1 = New DataView(DsCMB.Tables("M02_uni"), "uni_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
            If DtView1.Count = 0 Then
                Combo001.BackColor = System.Drawing.Color.Red
                msg.Text = "該当する大学がありません。"
                Exit Sub
            Else
                CL001.Text = DtView1(0)("uni_code")
            End If
        End If
        Combo001.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit001_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.GotFocus
        Edit001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Edit003_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.GotFocus
        Edit003.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit001_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit001.LostFocus
        Edit001.BackColor = System.Drawing.SystemColors.Window
        Edit001.Text = Trim(Edit001.Text)
        Label1.Text = Edit001.Text.Replace(" ", "　")
        Label2.Text = Label1.Text.Replace("　", " ")
        Label3.Text = Label1.Text.Replace("　", "")
    End Sub
    Private Sub Edit003_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit003.LostFocus
        Edit003.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub Combo001_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo001.LostFocus
        CHK_Combo001()   '受付種別
    End Sub

    '********************************************************************
    '**  クリア
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Edit001.Text = Nothing
        Edit003.Text = Nothing
        Combo001.Text = Nothing
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_RTN = "0"
        DsList1.Clear()
        Close()
    End Sub
End Class
