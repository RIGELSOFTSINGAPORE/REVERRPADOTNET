Public Class F50_Form01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DsCMB1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F As String
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
    Friend WithEvents br_imp_seq As System.Windows.Forms.Label
    Friend WithEvents br_Date02 As System.Windows.Forms.Label
    Friend WithEvents br_Date01 As System.Windows.Forms.Label
    Friend WithEvents br_cmb09 As System.Windows.Forms.Label
    Friend WithEvents cmb09 As System.Windows.Forms.Label
    Friend WithEvents imp_seq As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Date02 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date01 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Combo09 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.br_imp_seq = New System.Windows.Forms.Label
        Me.br_Date02 = New System.Windows.Forms.Label
        Me.br_Date01 = New System.Windows.Forms.Label
        Me.br_cmb09 = New System.Windows.Forms.Label
        Me.cmb09 = New System.Windows.Forms.Label
        Me.imp_seq = New GrapeCity.Win.Input.Interop.Edit
        Me.Label3 = New System.Windows.Forms.Label
        Me.Date02 = New GrapeCity.Win.Input.Interop.Date
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date01 = New GrapeCity.Win.Input.Interop.Date
        Me.Combo09 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'br_imp_seq
        '
        Me.br_imp_seq.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_imp_seq.Location = New System.Drawing.Point(855, 37)
        Me.br_imp_seq.Name = "br_imp_seq"
        Me.br_imp_seq.Size = New System.Drawing.Size(120, 16)
        Me.br_imp_seq.TabIndex = 1460
        Me.br_imp_seq.Text = "br_imp_seq"
        Me.br_imp_seq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.br_imp_seq.Visible = False
        '
        'br_Date02
        '
        Me.br_Date02.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date02.Location = New System.Drawing.Point(655, 37)
        Me.br_Date02.Name = "br_Date02"
        Me.br_Date02.Size = New System.Drawing.Size(100, 16)
        Me.br_Date02.TabIndex = 1459
        Me.br_Date02.Text = "br_Date02"
        Me.br_Date02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date02.Visible = False
        '
        'br_Date01
        '
        Me.br_Date01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_Date01.Location = New System.Drawing.Point(527, 37)
        Me.br_Date01.Name = "br_Date01"
        Me.br_Date01.Size = New System.Drawing.Size(100, 16)
        Me.br_Date01.TabIndex = 1458
        Me.br_Date01.Text = "br_Date01"
        Me.br_Date01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.br_Date01.Visible = False
        '
        'br_cmb09
        '
        Me.br_cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.br_cmb09.Location = New System.Drawing.Point(95, 37)
        Me.br_cmb09.Name = "br_cmb09"
        Me.br_cmb09.Size = New System.Drawing.Size(356, 16)
        Me.br_cmb09.TabIndex = 1457
        Me.br_cmb09.Text = "br_cmb09"
        Me.br_cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.br_cmb09.Visible = False
        '
        'cmb09
        '
        Me.cmb09.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cmb09.Location = New System.Drawing.Point(395, 1)
        Me.cmb09.Name = "cmb09"
        Me.cmb09.Size = New System.Drawing.Size(52, 16)
        Me.cmb09.TabIndex = 1456
        Me.cmb09.Text = "cmb09"
        Me.cmb09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmb09.Visible = False
        '
        'imp_seq
        '
        Me.imp_seq.AllowSpace = False
        Me.imp_seq.Format = "9"
        Me.imp_seq.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.imp_seq.Location = New System.Drawing.Point(851, 13)
        Me.imp_seq.MaxLength = 7
        Me.imp_seq.Name = "imp_seq"
        Me.imp_seq.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.imp_seq.Size = New System.Drawing.Size(124, 24)
        Me.imp_seq.TabIndex = 3
        Me.imp_seq.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Right
        Me.imp_seq.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(627, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 24)
        Me.Label3.TabIndex = 1455
        Me.Label3.Text = "～"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date02
        '
        Me.Date02.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date02.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date02.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date02.Location = New System.Drawing.Point(651, 13)
        Me.Date02.Name = "Date02"
        Me.Date02.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date02.Size = New System.Drawing.Size(104, 24)
        Me.Date02.TabIndex = 2
        Me.Date02.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date02.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date02.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(459, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 1453
        Me.Label1.Text = "申込日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Date01
        '
        Me.Date01.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date01.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date01.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Date01.Location = New System.Drawing.Point(523, 13)
        Me.Date01.Name = "Date01"
        Me.Date01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date01.Size = New System.Drawing.Size(104, 24)
        Me.Date01.TabIndex = 1
        Me.Date01.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date01.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date01.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2011, 10, 13, 16, 17, 22, 0))
        '
        'Combo09
        '
        Me.Combo09.AutoSelect = True
        Me.Combo09.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo09.Location = New System.Drawing.Point(95, 13)
        Me.Combo09.MaxDropDownItems = 35
        Me.Combo09.Name = "Combo09"
        Me.Combo09.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo09.Size = New System.Drawing.Size(356, 24)
        Me.Combo09.TabIndex = 0
        Me.Combo09.Value = "Combo09"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(11, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 24)
        Me.Label23.TabIndex = 1452
        Me.Label23.Text = "取扱店"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(771, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 1454
        Me.Label2.Text = "取込み№"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(796, 653)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 28)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "詳細"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T01_member"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(11, 45)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(980, 600)
        Me.DataGrid1.TabIndex = 4
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid1.TabStop = False
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "取扱店"
        Me.DataGridTextBoxColumn1.MappingName = "shop_name"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 465
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "申込日"
        Me.DataGridTextBoxColumn2.MappingName = "Part_date"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 101
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "##,##0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "件数"
        Me.DataGridTextBoxColumn3.MappingName = "cnt"
        Me.DataGridTextBoxColumn3.Width = 60
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "取込み№"
        Me.DataGridTextBoxColumn4.MappingName = "imp_seq"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 90
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(919, 653)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 6
        Me.Button99.Text = "閉じる"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 652)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(752, 28)
        Me.msg.TabIndex = 1463
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "入力日"
        Me.DataGridTextBoxColumn5.MappingName = "reg_date"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 101
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "伝票到着予定日"
        Me.DataGridTextBoxColumn6.MappingName = "neva_arr_date"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 120
        '
        'F50_Form01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.br_imp_seq)
        Me.Controls.Add(Me.br_Date02)
        Me.Controls.Add(Me.br_Date01)
        Me.Controls.Add(Me.br_cmb09)
        Me.Controls.Add(Me.cmb09)
        Me.Controls.Add(Me.imp_seq)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Date02)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date01)
        Me.Controls.Add(Me.Combo09)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入金処理"
        CType(Me.imp_seq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F50_Form01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
        Call CmbSet()   '** コンボボックスセット
        Call sql()      '** SQL

    End Sub

    '********************************************************************
    '** 初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        msg.Text = Nothing

        Combo09.Text = Nothing : cmb09.Text = Nothing : br_cmb09.Text = Nothing
        Date01.Number = 0 : br_Date01.Text = Nothing
        Date02.Number = 0 : br_Date02.Text = Nothing
        imp_seq.Text = Nothing : br_imp_seq.Text = Nothing

    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()

        '取扱店
        strSQL = "SELECT shop_code, shop_name, ittpan FROM M04_shop WHERE (shop_code <> 0) AND (delt_flg = 0) ORDER BY shop_name_kana, shop_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(DsCMB1, "M04_shop")
        DB_CLOSE()
        Combo09.DataSource = DsCMB1.Tables("M04_shop")
        Combo09.DisplayMember = "shop_name"
        Combo09.ValueMember = "shop_code"
        Combo09.Text = Nothing
        Combo09.SelectedIndex = -1

    End Sub

    '********************************************************************
    '** SQL
    '********************************************************************
    Sub sql()
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DsList1.Clear()
        strSQL = "SELECT T01_member.shop_code, M04_shop.shop_name, T01_member.Part_date, T01_member.imp_seq, COUNT(*) AS cnt"
        strSQL += ", T01_member.reg_date, T02_clct.neva_arr_date"
        strSQL += " FROM T01_member INNER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code LEFT OUTER JOIN"
        strSQL += " T02_clct ON T01_member.code = T02_clct.code"
        strSQL += " WHERE (T01_member.delt_flg = 0) AND (T02_clct.clct_date IS NULL) AND (T02_clct.invc_date IS NOT NULL)"
        If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
        If Date01.Number <> 0 Then strSQL += " AND (T01_member.Part_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
        If Date02.Number <> 0 Then strSQL += " AND (T01_member.Part_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
        If imp_seq.Text <> Nothing Then strSQL += " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
        strSQL += " GROUP BY T01_member.shop_code, M04_shop.shop_name, T01_member.Part_date, T01_member.imp_seq"
        strSQL += ", T01_member.reg_date, T02_clct.neva_arr_date"
        strSQL += " ORDER BY M04_shop.shop_name, T01_member.imp_seq"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T01_member")
        DB_CLOSE()

        If r = 0 Then
            Button3.Enabled = False
            msg.Text = "対象データなし"
        Else
            Button3.Enabled = True
            msg.Text = Nothing
        End If

        Dim tbl1 As New DataTable
        tbl1 = DsList1.Tables("T01_member")
        DataGrid1.DataSource = tbl1

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Date01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date01.LostFocus
        If Date01.Text <> br_Date01.Text Then
            Call sql()      '** SQL
            br_Date01.Text = Date01.Text
        End If
    End Sub
    Private Sub Date02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date02.LostFocus
        If Date02.Text <> br_Date02.Text Then
            Call sql()      '** SQL
            br_Date02.Text = Date02.Text
        End If
    End Sub
    Private Sub imp_seq_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles imp_seq.LostFocus
        imp_seq.Text = Trim(imp_seq.Text)
        If imp_seq.Text <> br_imp_seq.Text Then
            Call sql()      '** SQL
            br_imp_seq.Text = imp_seq.Text
        End If
    End Sub
    Private Sub Combo09_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.TextChanged
        Combo09.Text = Trim(Combo09.Text)
        If Combo09.Text <> br_cmb09.Text Then
            Call sql()      '** SQL
            br_cmb09.Text = Combo09.Text
        End If
    End Sub
    Private Sub Combo09_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo09.SelectedIndexChanged
        Combo09.Text = Trim(Combo09.Text)
        If Combo09.Text <> br_cmb09.Text Then
            Call sql()      '** SQL
            br_cmb09.Text = Combo09.Text
        End If
    End Sub

    '******************************************************************
    '** 詳細
    '******************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        P_DsList1.Clear()
        strSQL = "SELECT T01_member.shop_code, M04_shop.shop_name, T01_member.imp_seq, T01_member.code, T01_member.user_name"
        strSQL += ", T01_member.Part_date, T02_clct.invc_date, T02_clct.invc_amnt, T01_member.delt_flg AS clct_F"
        strSQL += " FROM T01_member LEFT OUTER JOIN"
        strSQL += " T02_clct ON T01_member.code = T02_clct.code LEFT OUTER JOIN"
        strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code"
        strSQL += " WHERE (T01_member.delt_flg = 0) AND (T02_clct.clct_date IS NULL) AND (T02_clct.invc_date IS NOT NULL)"
        If Combo09.Text <> Nothing Then strSQL += " AND (M04_shop.shop_name LIKE '%" & Combo09.Text & "%')"
        If Date01.Number <> 0 Then strSQL += " AND (T01_member.Part_date >= CONVERT(DATETIME, '" & Date01.Text & "', 102))"
        If Date02.Number <> 0 Then strSQL += " AND (T01_member.Part_date <= CONVERT(DATETIME, '" & Date02.Text & "', 102))"
        If imp_seq.Text <> Nothing Then strSQL += " AND (T01_member.imp_seq = " & imp_seq.Text & ")"
        strSQL += " ORDER BY M04_shop.shop_name, T01_member.imp_seq, wrn_range, wrn_tem"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        DaList1.Fill(P_DsList1, "T02_clct")
        DB_CLOSE()

        DtView1 = New DataView(P_DsList1.Tables("T02_clct"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                DtView1(i)("clct_F") = "True"
            Next
        End If

        Dim F50_Form01_01 As New F50_Form01_01
        F50_Form01_01.ShowDialog()

        If P_RTN = "1" Then
            Call sql()      '** SQL
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_DsList1.Clear()
        DsList1.Clear()
        DsCMB1.Clear()
        Close()
    End Sub
End Class
