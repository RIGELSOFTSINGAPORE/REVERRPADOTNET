Public Class F00_Form10_01
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB1 As New DataSet

    Dim strSQL, Err_F As String
    Dim S_Edit04, S_Edit05 As String
    Dim r As Integer

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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Edit06 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Edit05 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit04 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Edit01 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Combo01 As GrapeCity.Win.Input.Interop.Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Edit07 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.Edit06 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Edit05 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit04 = New GrapeCity.Win.Input.Interop.Edit
        Me.Edit01 = New GrapeCity.Win.Input.Interop.Edit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Combo01 = New GrapeCity.Win.Input.Interop.Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Edit07 = New GrapeCity.Win.Input.Interop.Edit
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(752, 652)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 28)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "検索"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Location = New System.Drawing.Point(920, 652)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 9
        Me.Button99.Text = "閉じる"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 88)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(988, 560)
        Me.DataGrid1.TabIndex = 6
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
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
        Me.DataGridTextBoxColumn1.MappingName = "code"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 110
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "氏名"
        Me.DataGridTextBoxColumn2.MappingName = "user_name"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 200
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "氏名カナ"
        Me.DataGridTextBoxColumn3.MappingName = "use_name_kana"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 200
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "電話番号"
        Me.DataGridTextBoxColumn4.MappingName = "tel"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 120
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "大学名"
        Me.DataGridTextBoxColumn5.MappingName = "univ_name"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 190
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(0, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 24)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "電話番号 ："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit06
        '
        Me.Edit06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit06.Format = "9#"
        Me.Edit06.HighlightText = True
        Me.Edit06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit06.LengthAsByte = True
        Me.Edit06.Location = New System.Drawing.Point(136, 56)
        Me.Edit06.MaxLength = 14
        Me.Edit06.Name = "Edit06"
        Me.Edit06.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit06.Size = New System.Drawing.Size(112, 24)
        Me.Edit06.TabIndex = 3
        Me.Edit06.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(556, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 24)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "氏名カナ ："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(0, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 24)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "氏名 ："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit05
        '
        Me.Edit05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit05.HighlightText = True
        Me.Edit05.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Edit05.LengthAsByte = True
        Me.Edit05.Location = New System.Drawing.Point(692, 28)
        Me.Edit05.MaxLength = 50
        Me.Edit05.Name = "Edit05"
        Me.Edit05.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit05.Size = New System.Drawing.Size(300, 24)
        Me.Edit05.TabIndex = 2
        Me.Edit05.Text = "Edit05"
        Me.Edit05.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit04
        '
        Me.Edit04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit04.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit04.LengthAsByte = True
        Me.Edit04.Location = New System.Drawing.Point(136, 28)
        Me.Edit04.MaxLength = 50
        Me.Edit04.Name = "Edit04"
        Me.Edit04.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit04.Size = New System.Drawing.Size(300, 24)
        Me.Edit04.TabIndex = 1
        Me.Edit04.Text = "Edit04"
        Me.Edit04.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Edit01
        '
        Me.Edit01.Format = "A9#"
        Me.Edit01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit01.LengthAsByte = True
        Me.Edit01.Location = New System.Drawing.Point(136, 0)
        Me.Edit01.MaxLength = 10
        Me.Edit01.Name = "Edit01"
        Me.Edit01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit01.Size = New System.Drawing.Size(104, 24)
        Me.Edit01.TabIndex = 0
        Me.Edit01.Text = "EDIT01"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 24)
        Me.Label2.TabIndex = 245
        Me.Label2.Text = "加入番号 ："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(556, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 24)
        Me.Label9.TabIndex = 253
        Me.Label9.Text = "大学 ："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(8, 652)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(728, 28)
        Me.msg.TabIndex = 1346
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(836, 652)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 28)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "クリア"
        '
        'Combo01
        '
        Me.Combo01.AutoSelect = True
        Me.Combo01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Combo01.Location = New System.Drawing.Point(692, 56)
        Me.Combo01.MaxDropDownItems = 20
        Me.Combo01.Name = "Combo01"
        Me.Combo01.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Combo01.Size = New System.Drawing.Size(300, 24)
        Me.Combo01.TabIndex = 5
        Me.Combo01.Value = "Combo01"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(260, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 24)
        Me.Label1.TabIndex = 1349
        Me.Label1.Text = "ｼﾘｱﾙ番号 ："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Edit07
        '
        Me.Edit07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit07.Format = "9#A"
        Me.Edit07.HighlightText = True
        Me.Edit07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit07.LengthAsByte = True
        Me.Edit07.Location = New System.Drawing.Point(396, 56)
        Me.Edit07.MaxLength = 14
        Me.Edit07.Name = "Edit07"
        Me.Edit07.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit07.Size = New System.Drawing.Size(140, 24)
        Me.Edit07.TabIndex = 4
        Me.Edit07.Text = "EDIT07"
        Me.Edit07.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "ｼﾘｱﾙ番号"
        Me.DataGridTextBoxColumn6.MappingName = "s_no"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.Width = 130
        '
        'F00_Form10_01
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Edit07)
        Me.Controls.Add(Me.Combo01)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Edit06)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Edit05)
        Me.Controls.Add(Me.Edit04)
        Me.Controls.Add(Me.Edit01)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button99)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form10_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "加入者検索"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit07, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form10_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理

        Call CmbSet()   '** コンボボックスセット
        Edit01.Text = P_SC1
        Edit04.Text = P_SC2
        Edit05.Text = P_SC3
        Edit06.Text = P_SC4
        Combo01.Text = P_SC5
        Edit07.Text = P_SC6
        If P_SC1 <> Nothing _
            Or P_SC2 <> Nothing _
            Or P_SC3 <> Nothing _
            Or P_SC4 <> Nothing _
            Or P_SC5 <> Nothing _
            Or P_SC6 <> Nothing Then
            Call sql()
        End If

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

        strSQL = "SELECT '' AS code, '' AS user_name, '' AS use_name_kana, '' AS tel, '' AS univ_code, '' AS univ_name, '' AS s_no"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsList1, "scan")

        Dim tbl As New DataTable
        tbl = DsList1.Tables("scan")
        DataGrid1.DataSource = tbl
        DsList1.Clear()

    End Sub

    '********************************************************************
    '** コンボボックスセット
    '********************************************************************
    Sub CmbSet()
        DsCMB1.Clear()
        DB_OPEN("nQGCare")

        '大学
        strSQL = "SELECT univ_code, univ_name FROM M01_univ WHERE (delt_flg = 0) ORDER BY univ_name_kana, univ_name"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsCMB1, "M01_univ")
        Combo01.DataSource = DsCMB1.Tables("M01_univ")
        Combo01.DisplayMember = "univ_name"
        Combo01.ValueMember = "univ_code"

        DB_CLOSE()
    End Sub

    '******************************************************************
    '** データ抽出
    '******************************************************************
    Sub sql()
        Dim WH As String = "0"
        DsList1.Clear()
        strSQL = "SELECT T01_member.code, T01_member.user_name, T01_member.use_name_kana, T01_member.s_no"
        strSQL += ", T01_member.tel, M01_univ.univ_name"
        strSQL += " FROM T01_member LEFT OUTER JOIN"
        strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
        strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code"
        strSQL += " WHERE (T01_member.delt_flg = 0)"
        If iPad = "1" Then
            strSQL += " AND (T05_iPad.code IS NOT NULL)"                            'iPadのみ
        Else
            strSQL += " AND (T05_iPad.code IS NULL)"                                'iPad除く
        End If
        If Edit01.Text <> Nothing Then
            strSQL += " AND (T01_member.code LIKE '%" & Edit01.Text & "%')"
        End If
        If Edit04.Text <> Nothing Then
            S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
            strSQL += " AND (T01_member.user_name_search LIKE '%" & S_Edit04 & "%')"
        End If
        If Edit05.Text <> Nothing Then
            S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
            strSQL += " AND (T01_member.use_name_kana_search LIKE '%" & S_Edit05 & "%')"
        End If
        If Edit06.Text <> Nothing Then
            strSQL += " AND (T01_member.tel LIKE '%" & Edit06.Text & "%')"
        End If
        If Edit07.Text <> Nothing Then
            strSQL += " AND (T01_member.s_no = '" & Edit07.Text & "')"
        End If
        If Combo01.Text <> Nothing Then
            strSQL += " AND (M01_univ.univ_name LIKE '%" & Combo01.Text & "%')"
        End If

        If Edit07.Text <> Nothing Then
            strSQL += " UNION"
            strSQL += " SELECT T01_member.code, T01_member.user_name, T01_member.use_name_kana, T06_sno.s_no"
            strSQL += ", T01_member.tel, M01_univ.univ_name"
            strSQL += " FROM T01_member INNER JOIN"
            strSQL += " T06_sno ON T01_member.code = T06_sno.code LEFT OUTER JOIN"
            strSQL += " T05_iPad ON T01_member.code = T05_iPad.code LEFT OUTER JOIN"
            strSQL += " M01_univ ON T01_member.univ_code = M01_univ.univ_code"
            strSQL += " WHERE (T01_member.delt_flg = 0)"
            If iPad = "1" Then
                strSQL += " AND (T05_iPad.code IS NOT NULL)"                            'iPadのみ
            Else
                strSQL += " AND (T05_iPad.code IS NULL)"                                'iPad除く
            End If
            If Edit01.Text <> Nothing Then
                strSQL += " AND (T01_member.code LIKE '%" & Edit01.Text & "%')"
            End If
            If Edit04.Text <> Nothing Then
                S_Edit04 = Replace(Replace(Edit04.Text, " ", ""), "　", "")
                strSQL += " AND (T01_member.user_name_search LIKE '%" & S_Edit04 & "%')"
            End If
            If Edit05.Text <> Nothing Then
                S_Edit05 = Replace(Replace(Edit05.Text, " ", ""), "　", "")
                strSQL += " AND (T01_member.use_name_kana_search LIKE '%" & S_Edit05 & "%')"
            End If
            If Edit06.Text <> Nothing Then
                strSQL += " AND (T01_member.tel LIKE '%" & Edit06.Text & "%')"
            End If
            strSQL += " AND (T06_sno.s_no = '" & Edit07.Text & "')"
            If Combo01.Text <> Nothing Then
                strSQL += " AND (M01_univ.univ_name LIKE '%" & Combo01.Text & "%')"
            End If
        End If

        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "scan")
        DB_CLOSE()

        If r = 0 Then msg.Text = "対象データなし" Else msg.Text = Nothing
    End Sub

    '******************************************************************
    '** 項目チェック
    '******************************************************************
    Sub F_chk()
        Err_F = "0"
        msg.Text = Nothing

        If Edit01.Text = Nothing _
            And Edit04.Text = Nothing _
            And Edit05.Text = Nothing _
            And Edit06.Text = Nothing _
            And Edit07.Text = Nothing _
            And Combo01.Text = Nothing Then
            msg.Text = "検索条件を指定してください"
            Err_F = "1" : Exit Sub
        End If

    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Edit01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit01.LostFocus
        Edit01.Text = Trim(Edit01.Text)
    End Sub
    Private Sub Edit04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit04.LostFocus
        Edit04.Text = Trim(Edit04.Text)
    End Sub
    Private Sub Edit05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit05.LostFocus
        Edit05.Text = Trim(Edit05.Text)
    End Sub
    Private Sub Edit06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit06.LostFocus
        Edit06.Text = Trim(Edit06.Text)
    End Sub
    Private Sub Edit07_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit07.LostFocus
        Edit07.Text = Trim(Edit07.Text)
    End Sub
    Private Sub Combo01_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo01.LostFocus
        Combo01.Text = Trim(Combo01.Text)
    End Sub

    '********************************************************************
    '**  データグリッド色
    '********************************************************************
    Private Sub DataGridE_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGrid1.Paint
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
                P_RTN = "1"
                P_PRAM1 = DataGrid1(DataGrid1.CurrentRowIndex, 0)
                DsList1.Clear()
                Close()
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '******************************************************************
    '** 検索
    '******************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call F_chk()
        If Err_F = "0" Then
            P_SC1 = Edit01.Text
            P_SC2 = Edit04.Text
            P_SC3 = Edit05.Text
            P_SC4 = Edit06.Text
            P_SC5 = Combo01.Text
            P_SC6 = Edit07.Text
            Call sql()
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** クリア
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        P_SC1 = Nothing : Edit01.Text = Nothing
        P_SC2 = Nothing : Edit04.Text = Nothing
        P_SC3 = Nothing : Edit05.Text = Nothing
        P_SC4 = Nothing : Edit06.Text = Nothing
        P_SC5 = Nothing : Combo01.Text = Nothing
        P_SC6 = Nothing : Edit07.Text = Nothing
        DsList1.Clear()
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        DsList1.Clear()
        DsCMB1.Clear()
        P_RTN = "0"
        Close()
    End Sub
End Class
