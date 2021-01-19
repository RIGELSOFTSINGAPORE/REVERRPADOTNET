Public Class F00_Form02_3
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, WK_str As String
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label05 As System.Windows.Forms.Label
    Friend WithEvents Label04 As System.Windows.Forms.Label
    Friend WithEvents Label03 As System.Windows.Forms.Label
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button98 As System.Windows.Forms.Button
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
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form02_3))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
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
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label05 = New System.Windows.Forms.Label
        Me.Label04 = New System.Windows.Forms.Label
        Me.Label03 = New System.Windows.Forms.Label
        Me.Label02 = New System.Windows.Forms.Label
        Me.Label01 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBox5 = New System.Windows.Forms.ComboBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button98 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(12, 152)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(920, 424)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "item_mtr"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "商品"
        Me.DataGridTextBoxColumn1.MappingName = "item_code"
        Me.DataGridTextBoxColumn1.Width = 105
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "商品名"
        Me.DataGridTextBoxColumn2.MappingName = "item_name"
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "メーカー"
        Me.DataGridTextBoxColumn3.MappingName = "vdr_code"
        Me.DataGridTextBoxColumn3.Width = 70
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "メーカー名"
        Me.DataGridTextBoxColumn4.MappingName = "vdr_name"
        Me.DataGridTextBoxColumn4.Width = 110
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "部門"
        Me.DataGridTextBoxColumn5.MappingName = "section_code"
        Me.DataGridTextBoxColumn5.Width = 40
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "部門名"
        Me.DataGridTextBoxColumn6.MappingName = "section_name"
        Me.DataGridTextBoxColumn6.Width = 90
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "ライン"
        Me.DataGridTextBoxColumn7.MappingName = "line_code"
        Me.DataGridTextBoxColumn7.Width = 40
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "ライン名"
        Me.DataGridTextBoxColumn8.MappingName = "line_name"
        Me.DataGridTextBoxColumn8.Width = 90
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "クラス"
        Me.DataGridTextBoxColumn9.MappingName = "cls_code"
        Me.DataGridTextBoxColumn9.Width = 40
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "クラス名"
        Me.DataGridTextBoxColumn10.MappingName = "cls_name"
        Me.DataGridTextBoxColumn10.Width = 90
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "サブクラス"
        Me.DataGridTextBoxColumn11.MappingName = "sub_cls_code"
        Me.DataGridTextBoxColumn11.Width = 60
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "サブクラス名"
        Me.DataGridTextBoxColumn12.MappingName = "sub_cls_name"
        Me.DataGridTextBoxColumn12.Width = 90
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "規格名"
        Me.DataGridTextBoxColumn13.MappingName = "standard_name"
        Me.DataGridTextBoxColumn13.Width = 150
        '
        'Label05
        '
        Me.Label05.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label05.Location = New System.Drawing.Point(464, 120)
        Me.Label05.Name = "Label05"
        Me.Label05.Size = New System.Drawing.Size(80, 24)
        Me.Label05.TabIndex = 1241
        Me.Label05.Visible = False
        '
        'Label04
        '
        Me.Label04.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label04.Location = New System.Drawing.Point(464, 92)
        Me.Label04.Name = "Label04"
        Me.Label04.Size = New System.Drawing.Size(80, 24)
        Me.Label04.TabIndex = 1240
        Me.Label04.Visible = False
        '
        'Label03
        '
        Me.Label03.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label03.Location = New System.Drawing.Point(464, 64)
        Me.Label03.Name = "Label03"
        Me.Label03.Size = New System.Drawing.Size(80, 24)
        Me.Label03.TabIndex = 1239
        Me.Label03.Visible = False
        '
        'Label02
        '
        Me.Label02.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label02.Location = New System.Drawing.Point(464, 36)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(80, 24)
        Me.Label02.TabIndex = 1238
        Me.Label02.Visible = False
        '
        'Label01
        '
        Me.Label01.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label01.Location = New System.Drawing.Point(464, 8)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(80, 24)
        Me.Label01.TabIndex = 1237
        Me.Label01.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Navy
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(16, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 24)
        Me.Label8.TabIndex = 1236
        Me.Label8.Text = "サブクラス"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 24)
        Me.Label6.TabIndex = 1235
        Me.Label6.Text = "クラス"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Navy
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 24)
        Me.Label5.TabIndex = 1234
        Me.Label5.Text = "メーカー"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox5
        '
        Me.ComboBox5.Location = New System.Drawing.Point(140, 120)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox5.TabIndex = 1231
        Me.ComboBox5.Text = "ComboBox5"
        '
        'ComboBox4
        '
        Me.ComboBox4.Location = New System.Drawing.Point(140, 92)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox4.TabIndex = 1230
        Me.ComboBox4.Text = "ComboBox4"
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(140, 64)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox3.TabIndex = 1229
        Me.ComboBox3.Text = "ComboBox3"
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(140, 36)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox2.TabIndex = 1228
        Me.ComboBox2.Text = "ComboBox2"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(140, 8)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(324, 24)
        Me.ComboBox1.TabIndex = 1227
        Me.ComboBox1.Text = "ComboBox1"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Navy
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 24)
        Me.Label7.TabIndex = 1233
        Me.Label7.Text = "ライン"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(16, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 24)
        Me.Label9.TabIndex = 1232
        Me.Label9.Text = "部門"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(856, 584)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(76, 28)
        Me.Button98.TabIndex = 1242
        Me.Button98.Text = "戻る"
        '
        'F00_Form02_3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(944, 619)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Label05)
        Me.Controls.Add(Me.Label04)
        Me.Controls.Add(Me.Label03)
        Me.Controls.Add(Me.Label02)
        Me.Controls.Add(Me.Label01)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F00_Form02_3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "商品検索"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form02_3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call dsp_set()  '** 画面セット

        Dim tbl As New DataTable
        tbl = DsList1.Tables("item_mtr")
        DataGrid1.DataSource = tbl

    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN = "0"
    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DB_OPEN()

        'メーカー
        strSQL = "SELECT vdr_code, vdr_code + ':' + vdr_name AS vdr_name"
        strSQL = strSQL & " FROM vdr_mtr"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "vdr_mtr")

        ComboBox1.DataSource = DsCMB.Tables("vdr_mtr")
        ComboBox1.DisplayMember = "vdr_name"
        ComboBox1.ValueMember = "vdr_code"
        ComboBox1.Text = Nothing

        '部門
        strSQL = "SELECT section_code, section_code + ':' + section_name AS section_name"
        strSQL = strSQL & " FROM section_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "section_mtr")

        ComboBox2.DataSource = DsCMB.Tables("section_mtr")
        ComboBox2.DisplayMember = "section_name"
        ComboBox2.ValueMember = "section_code"
        ComboBox2.Text = Nothing

        'ライン
        strSQL = "SELECT section_code, line_code, line_code + ':' + line_name AS line_name"
        strSQL = strSQL & " FROM line_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "line_mtr")

        ComboBox3.DataSource = DsCMB.Tables("line_mtr")
        ComboBox3.DisplayMember = "line_name"
        ComboBox3.ValueMember = "line_code"
        ComboBox3.Text = Nothing

        'クラス
        strSQL = "SELECT section_code, line_code, cls_code, cls_code + ':' + cls_name AS cls_name"
        strSQL = strSQL & " FROM cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "cls_mtr")

        ComboBox4.DataSource = DsCMB.Tables("cls_mtr")
        ComboBox4.DisplayMember = "cls_name"
        ComboBox4.ValueMember = "cls_code"
        ComboBox4.Text = Nothing

        'サブクラス
        strSQL = "SELECT section_code, line_code, cls_code, sub_cls_code, sub_cls_code + ':' + sub_cls_name AS sub_cls_name"
        strSQL = strSQL & " FROM sub_cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        strSQL = strSQL & " AND (cls_code = '" & Label04.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB, "sub_cls_mtr")

        ComboBox5.DataSource = DsCMB.Tables("sub_cls_mtr")
        ComboBox5.DisplayMember = "sub_cls_name"
        ComboBox5.ValueMember = "sub_cls_code"
        ComboBox5.Text = Nothing

        DB_CLOSE()
    End Sub
    Sub CmbSet_3()          'ライン

        DsCMB.Tables("line_mtr").Clear()
        strSQL = "SELECT section_code, line_code, line_code + ':' + line_name AS line_name"
        strSQL = strSQL & " FROM line_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "line_mtr")
        DB_CLOSE()
        ComboBox3.Text = Nothing
        Label03.Text = Nothing

    End Sub
    Sub CmbSet_4()          'クラス

        DsCMB.Tables("cls_mtr").Clear()
        strSQL = "SELECT section_code, line_code, cls_code, cls_code + ':' + cls_name AS cls_name"
        strSQL = strSQL & " FROM cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "cls_mtr")
        DB_CLOSE()
        ComboBox4.Text = Nothing
        Label04.Text = Nothing

    End Sub
    Sub CmbSet_5()          'サブクラス

        DsCMB.Tables("sub_cls_mtr").Clear()
        strSQL = "SELECT section_code, line_code, cls_code, sub_cls_code, sub_cls_code + ':' + sub_cls_name AS sub_cls_name"
        strSQL = strSQL & " FROM sub_cls_mtr"
        strSQL = strSQL & " WHERE  (delt_flg = 0)"
        strSQL = strSQL & " AND (section_code = '" & Label02.Text & "')"
        strSQL = strSQL & " AND (line_code = '" & Label03.Text & "')"
        strSQL = strSQL & " AND (cls_code = '" & Label04.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsCMB, "sub_cls_mtr")
        DB_CLOSE()
        ComboBox5.Text = Nothing
        Label05.Text = Nothing

    End Sub

    '******************************************************************
    '** 画面セット
    '******************************************************************
    Sub dsp_set()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        DsList1.Clear()

        strSQL = "SELECT item_mtr.item_code, item_mtr.item_name, item_mtr.vdr_code, vdr_mtr.vdr_name"
        strSQL = strSQL & ", item_mtr.section_code, section_mtr.section_name, item_mtr.line_code, line_mtr.line_name"
        strSQL = strSQL & ", item_mtr.cls_code, cls_mtr.cls_name, item_mtr.sub_cls_code, sub_cls_mtr.sub_cls_name"
        strSQL = strSQL & ", item_mtr.standard_name, item_mtr.delt_flg"
        strSQL = strSQL & " FROM item_mtr INNER JOIN"
        strSQL = strSQL & " vdr_mtr ON item_mtr.vdr_code = vdr_mtr.vdr_code INNER JOIN"
        strSQL = strSQL & " section_mtr ON item_mtr.section_code = section_mtr.section_code INNER JOIN"
        strSQL = strSQL & " line_mtr ON item_mtr.section_code = line_mtr.section_code AND"
        strSQL = strSQL & " item_mtr.line_code = line_mtr.line_code INNER JOIN"
        strSQL = strSQL & " cls_mtr ON item_mtr.section_code = cls_mtr.section_code AND item_mtr.line_code = cls_mtr.line_code AND"
        strSQL = strSQL & " item_mtr.cls_code = cls_mtr.cls_code LEFT OUTER JOIN"
        strSQL = strSQL & " sub_cls_mtr ON item_mtr.section_code = sub_cls_mtr.section_code AND"
        strSQL = strSQL & " item_mtr.line_code = sub_cls_mtr.line_code AND item_mtr.cls_code = sub_cls_mtr.cls_code AND"
        strSQL = strSQL & " item_mtr.sub_cls_code = sub_cls_mtr.sub_cls_code"
        If Label01.Text = Nothing _
            And Label02.Text = Nothing _
            And Label03.Text = Nothing _
            And Label04.Text = Nothing _
            And Label05.Text = Nothing Then
            strSQL = strSQL & " WHERE (item_mtr.item_code = '-')"
        Else
            strSQL = strSQL & " WHERE (item_mtr.delt_flg = 0)"
            If Label01.Text <> Nothing Then
                strSQL = strSQL & " AND (item_mtr.vdr_code = '" & Label01.Text & "')"
            End If
            If Label02.Text <> Nothing Then
                strSQL = strSQL & " AND (item_mtr.section_code = '" & Label02.Text & "')"
            End If
            If Label03.Text <> Nothing Then
                strSQL = strSQL & " AND (item_mtr.line_code = '" & Label03.Text & "')"
            End If
            If Label04.Text <> Nothing Then
                strSQL = strSQL & " AND (item_mtr.cls_code = '" & Label04.Text & "')"
            End If
            If Label05.Text <> Nothing Then
                strSQL = strSQL & " AND (item_mtr.sub_cls_code = '" & Label05.Text & "')"
            End If
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        DaList1.Fill(DsList1, "item_mtr")
        DB_CLOSE()

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub CHK_ComboBox1()     'メーカー

        ComboBox1.Text = Trim(ComboBox1.Text)
        WK_DtView1 = New DataView(DsCMB.Tables("vdr_mtr"), "vdr_name = '" & ComboBox1.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            Label01.Text = WK_DtView1(0)("vdr_code")
        Else
            Label01.Text = Nothing
        End If
    End Sub
    Sub CHK_ComboBox2()     '部門

        ComboBox2.Text = Trim(ComboBox2.Text)
        WK_DtView1 = New DataView(DsCMB.Tables("section_mtr"), "section_name = '" & ComboBox2.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Label02.Text <> WK_DtView1(0)("section_code") Then
                Label02.Text = WK_DtView1(0)("section_code")
                Call CmbSet_3()     'ライン
                Call CmbSet_4()     'クラス
                Call CmbSet_5()     'サブクラス
            End If
        Else
            Label02.Text = Nothing
        End If
    End Sub
    Sub CHK_ComboBox3()     'ライン

        ComboBox3.Text = Trim(ComboBox3.Text)
        WK_DtView1 = New DataView(DsCMB.Tables("line_mtr"), "section_code = '" & Label02.Text & "' AND line_name = '" & ComboBox3.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Label03.Text <> WK_DtView1(0)("line_code") Then
                Label03.Text = WK_DtView1(0)("line_code")
                Call CmbSet_4()     'クラス
                Call CmbSet_5()     'サブクラス
            End If
        Else
            Label03.Text = Nothing
        End If
    End Sub
    Sub CHK_ComboBox4()     'クラス

        ComboBox4.Text = Trim(ComboBox4.Text)
        WK_DtView1 = New DataView(DsCMB.Tables("cls_mtr"), "section_code = '" & Label02.Text & "' AND line_code = '" & Label03.Text & "' AND cls_name = '" & ComboBox4.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Label04.Text <> WK_DtView1(0)("cls_code") Then
                Label04.Text = WK_DtView1(0)("cls_code")
                Call CmbSet_5()     'サブクラス
            End If
        Else
            Label04.Text = Nothing
        End If
    End Sub
    Sub CHK_ComboBox5()     'サブクラス

        ComboBox5.Text = Trim(ComboBox5.Text)
        WK_DtView1 = New DataView(DsCMB.Tables("sub_cls_mtr"), "section_code = '" & Label02.Text & "' AND line_code = '" & Label03.Text & "' AND cls_code = '" & Label04.Text & "' AND sub_cls_name = '" & ComboBox5.Text & "'", "", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then
            If Label05.Text <> WK_DtView1(0)("sub_cls_code") Then
                Label05.Text = WK_DtView1(0)("sub_cls_code")
            End If
        Else
            Label05.Text = Nothing
        End If
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGrid1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
        If DataGrid1.CurrentRowIndex >= 0 Then
            DataGrid1.Select(DataGrid1.CurrentRowIndex)
        End If
    End Sub

    '********************************************************************
    '**  データグリッド　クリック
    '********************************************************************
    Private Sub DataGrid1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                P_PRAM1 = DataGrid1(DataGrid1.CurrentRowIndex, 0) & ":" & DataGrid1(DataGrid1.CurrentRowIndex, 1)

                Cursor = System.Windows.Forms.Cursors.Default
                P_RTN = "1"
                WK_DsList1.Clear()
                DsList1.Clear()
                DsCMB.Clear()
                Close()
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '******************************************************************
    '** 戻る
    '******************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_RTN = "0"
        WK_DsList1.Clear()
        DsList1.Clear()
        DsCMB.Clear()
        Close()
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        Call CHK_ComboBox1()    'メーカー
    End Sub
    Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.LostFocus
        Call CHK_ComboBox2()    '部門
    End Sub
    Private Sub ComboBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.LostFocus
        Call CHK_ComboBox3()    'ライン
    End Sub
    Private Sub ComboBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.LostFocus
        Call CHK_ComboBox4()    'クラス
    End Sub
    Private Sub ComboBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.LostFocus
        Call CHK_ComboBox5()    'サブクラス
    End Sub

    '******************************************************************
    '** TextChanged
    '******************************************************************
    Private Sub Label01_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label01.TextChanged
        Call dsp_set()  '** 画面セット
    End Sub
    Private Sub Label02_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label02.TextChanged
        Call dsp_set()  '** 画面セット
    End Sub
    Private Sub Label03_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label03.TextChanged
        Call dsp_set()  '** 画面セット
    End Sub
    Private Sub Label04_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label04.TextChanged
        Call dsp_set()  '** 画面セット
    End Sub
    Private Sub Label05_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label05.TextChanged
        Call dsp_set()  '** 画面セット
    End Sub
End Class
