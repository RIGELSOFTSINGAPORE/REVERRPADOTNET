Public Class F30_Form01_2
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, DsCMB As New DataSet
    Dim DtView1, DtView2 As DataView
    Dim WK_DtView1 As DataView

    Dim strSQL, WK_str, WK_str2, ERR_F As String
    Dim i, j, WK_sum1, WK_sum2 As Integer

    Dim dsInvoice As New DataSet
    Dim dt2 As DataTable = dsInvoice.Tables.Add("INV2")
    Dim DGTS As New DataGridTableStyle

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
    Friend WithEvents DataGridEx1 As nMVAR_Clct.DataGridEx
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Number001 As GrapeCity.Win.Input.Number
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Number002 As GrapeCity.Win.Input.Number
    Friend WithEvents Number003 As GrapeCity.Win.Input.Number
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Label004 As System.Windows.Forms.Label
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGridEx1 = New nMVAR_Clct.DataGridEx
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Label132 = New System.Windows.Forms.Label
        Me.Number001 = New GrapeCity.Win.Input.Number
        Me.Button1 = New System.Windows.Forms.Button
        Me.Number002 = New GrapeCity.Win.Input.Number
        Me.Number003 = New GrapeCity.Win.Input.Number
        Me.Label1 = New System.Windows.Forms.Label
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Label004 = New System.Windows.Forms.Label
        Me.Edit1 = New GrapeCity.Win.Input.Edit
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(16, 68)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.Size = New System.Drawing.Size(648, 460)
        Me.DataGridEx1.TabIndex = 2
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(504, 564)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 24)
        Me.Button98.TabIndex = 5
        Me.Button98.Text = "戻る"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(12, 568)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 24)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "更新"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(88, 572)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(412, 16)
        Me.msg.TabIndex = 1237
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.Navy
        Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label132.ForeColor = System.Drawing.Color.White
        Me.Label132.Location = New System.Drawing.Point(276, 536)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(52, 20)
        Me.Label132.TabIndex = 1568
        Me.Label132.Text = "合　計"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Number001
        '
        Me.Number001.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number001.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number001.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number001.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number001.Enabled = False
        Me.Number001.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number001.HighlightText = True
        Me.Number001.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number001.Location = New System.Drawing.Point(328, 536)
        Me.Number001.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number001.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number001.Name = "Number001"
        Me.Number001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number001.Size = New System.Drawing.Size(76, 20)
        Me.Number001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number001.TabIndex = 1567
        Me.Number001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number001.Value = Nothing
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(416, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 24)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "全額入金"
        '
        'Number002
        '
        Me.Number002.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number002.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number002.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number002.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number002.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number002.Enabled = False
        Me.Number002.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number002.HighlightText = True
        Me.Number002.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number002.Location = New System.Drawing.Point(404, 536)
        Me.Number002.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number002.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number002.Name = "Number002"
        Me.Number002.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number002.Size = New System.Drawing.Size(76, 20)
        Me.Number002.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number002.TabIndex = 1570
        Me.Number002.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number002.Value = Nothing
        '
        'Number003
        '
        Me.Number003.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.Number003.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Number003.DisplayFormat = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number003.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.DropDownCalculator.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Number003.DropDownCalculator.Size = New System.Drawing.Size(228, 200)
        Me.Number003.Enabled = False
        Me.Number003.Format = New GrapeCity.Win.Input.NumberFormat("###,###,##0", "", "", "-", "", "", "")
        Me.Number003.HighlightText = True
        Me.Number003.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Number003.Location = New System.Drawing.Point(480, 536)
        Me.Number003.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Number003.MinValue = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.Number003.Name = "Number003"
        Me.Number003.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Number003.Size = New System.Drawing.Size(76, 20)
        Me.Number003.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Number003.TabIndex = 1571
        Me.Number003.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Number003.Value = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(36, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 1572
        Me.Label1.Text = "入金日"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Date1
        '
        Me.Date1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM/dd", "", "")
        Me.Date1.HighlightText = GrapeCity.Win.Input.HighlightText.All
        Me.Date1.Location = New System.Drawing.Point(120, 40)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(88, 20)
        Me.Date1.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, True, GrapeCity.Win.Input.ButtonPosition.Inside, False, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.TabIndex = 1
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.Value = Nothing
        '
        'Label004
        '
        Me.Label004.BackColor = System.Drawing.Color.Navy
        Me.Label004.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label004.ForeColor = System.Drawing.Color.White
        Me.Label004.Location = New System.Drawing.Point(36, 16)
        Me.Label004.Name = "Label004"
        Me.Label004.Size = New System.Drawing.Size(84, 20)
        Me.Label004.TabIndex = 1575
        Me.Label004.Text = "入金番号"
        Me.Label004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Edit1
        '
        Me.Edit1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Edit1.HighlightText = True
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(120, 16)
        Me.Edit1.MaxLength = 20
        Me.Edit1.Name = "Edit1"
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(88, 20)
        Me.Edit1.TabIndex = 0
        Me.Edit1.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        '
        'F30_Form01_2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(730, 602)
        Me.Controls.Add(Me.Label004)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Number003)
        Me.Controls.Add(Me.Number002)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label132)
        Me.Controls.Add(Me.Number001)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F30_Form01_2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入金処理"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number002, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number003, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F30_Form01_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        sql()       '**  データセット
        DtGd()
        dtgrd_set()
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date1.Text = Now.Date
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='301'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Select Case DtView1(0)("access_cls")
                Case Is = "2"
                    Button2.Enabled = False
                Case Is = "3"
                    Button2.Enabled = True
                Case Is = "4"
                    Button2.Enabled = True
            End Select
        Else
            Button2.Enabled = False
        End If
    End Sub

    Sub dtgrd_set()
        Dim dc As DataColumn
        dc = New DataColumn("Column1", GetType(String))
        dt2.Columns.Add(dc)
        dc = New DataColumn("Column2", GetType(String))
        dt2.Columns.Add(dc)
        dc = New DataColumn("Column3", GetType(Integer))
        dt2.Columns.Add(dc)
        dc = New DataColumn("Column4", GetType(Integer))
        dt2.Columns.Add(dc)
        dc = New DataColumn("Column5", GetType(Integer))
        dt2.Columns.Add(dc)
        dc = New DataColumn("Column6", GetType(Integer))
        dt2.Columns.Add(dc)

        Dim style1 As New DataGridTextBoxColumn
        Dim style2 As New DataGridTextBoxColumn
        Dim style3 As New MyDataGridTextBoxColumn2
        Dim style4 As New MyDataGridTextBoxColumn2
        Dim style5 As New MyDataGridTextBoxColumn2
        Dim style6 As New MyDataGridTextBoxColumn2

        With style1
            .MappingName = dt2.Columns(0).ColumnName
            .HeaderText = "受付番号"
            .Alignment = HorizontalAlignment.Center
            .Width = 75
            .ReadOnly = True
        End With

        With style2
            .MappingName = dt2.Columns(1).ColumnName
            .HeaderText = "ユーザー名"
            .Alignment = HorizontalAlignment.Left
            .Width = 200
            .ReadOnly = True
        End With

        With style3
            .MappingName = dt2.Columns(2).ColumnName
            .HeaderText = "請求額"
            .Alignment = HorizontalAlignment.Right
            .Format = "##,##0"
            .Width = 76
            .ReadOnly = True
        End With

        With style4
            .MappingName = dt2.Columns(3).ColumnName
            .HeaderText = "未入金額"
            .Alignment = HorizontalAlignment.Right
            .Format = "##,##0"
            .Width = 76
            .ReadOnly = True
        End With

        With style5
            .MappingName = dt2.Columns(4).ColumnName
            .HeaderText = "入金額"
            .Alignment = HorizontalAlignment.Right
            .Format = "##,##0"
            .Width = 76
        End With

        With style6
            .MappingName = dt2.Columns(5).ColumnName
            .HeaderText = "差額"
            .Alignment = HorizontalAlignment.Right
            .Format = "##,##0"
            .Width = 76
            .ReadOnly = True
        End With

        DGTS.GridColumnStyles.Add(style1)
        DGTS.GridColumnStyles.Add(style2)
        DGTS.GridColumnStyles.Add(style3)
        DGTS.GridColumnStyles.Add(style4)
        DGTS.GridColumnStyles.Add(style5)
        DGTS.GridColumnStyles.Add(style6)
        DataGridEx1.TableStyles.Add(DGTS)

        '入力時の自動計算
        AddHandler dt2.ColumnChanged, AddressOf DTChange

        '入力値制限
        Dim tb As TextBox = style5.TextBox
        AddHandler tb.KeyPress, AddressOf tb_KeyPress

    End Sub

    Private Sub DTChange(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        If e.Column.Caption = "clct_amnt" Then
            e.Row.Item("balance") = e.Row.Item("clct_pln") - e.Row.Item("clct_amnt")
            sum()
        End If
    End Sub

    Private Sub tb_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '0-9の文字のみを許可する
        If e.KeyChar < "0"c Or e.KeyChar > "9"c Then
            e.Handled = True
        End If
    End Sub

    '********************************************************************
    '**  データセット
    '********************************************************************
    Sub sql()
        DsList1.Clear()
        DB_OPEN("nMVAR")

        strSQL = "SELECT T21_INVC_SUB.rcpt_no, T01_REP_MTR.user_name, T21_INVC_SUB.invc_amnt, T21_INVC_SUB.invc_amnt AS clct_pln"
        strSQL = strSQL & ", T30.clct_amnt, T20_INVC_MTR.invc_amnt - T30.clct_amnt AS balance, T20_INVC_MTR.iｎvc_no"
        strSQL = strSQL & " FROM T20_INVC_MTR INNER JOIN"
        strSQL = strSQL & " T21_INVC_SUB ON T20_INVC_MTR.iｎvc_no = T21_INVC_SUB.iｎvc_no INNER JOIN"
        strSQL = strSQL & " T01_REP_MTR ON T21_INVC_SUB.rcpt_no = T01_REP_MTR.rcpt_no LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT invc_no, rcpt_no, SUM(clct_amnt) AS clct_amnt FROM T30_CLCT GROUP BY invc_no, rcpt_no) AS T30"
        strSQL = strSQL & " ON T21_INVC_SUB.invc_no = T30.invc_no AND"
        strSQL = strSQL & " T21_INVC_SUB.rcpt_no = T30.rcpt_no"
        strSQL = strSQL & " WHERE (T21_INVC_SUB.fin_flg = 0)"
        strSQL = strSQL & " AND (T21_INVC_SUB.cxl_flg = 0)"
        strSQL = strSQL & " AND (T20_INVC_MTR.invc_no = " & P_PRAM1 & ")"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(dsInvoice, "INV2")
        DB_CLOSE()

        DtView1 = New DataView(dsInvoice.Tables("INV2"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                If IsDBNull(DtView1(i)("clct_amnt")) Then DtView1(i)("clct_amnt") = 0
                If DtView1(i)("clct_amnt") <> 0 Then
                    DtView1(i)("clct_pln") = DtView1(i)("invc_amnt") - DtView1(i)("clct_amnt")
                    DtView1(i)("clct_amnt") = 0
                End If
                DtView1(i)("balance") = DtView1(i)("clct_pln") - DtView1(i)("clct_amnt")
            Next
        End If

        dt2 = dsInvoice.Tables("INV2")
        sum()
    End Sub
    Sub DtGd()
        'Dim tbl As New DataTable
        'tbl = DsList1.Tables("scan")
        'DataGridEx1.DataSource = tbl

        DGTS.MappingName = dt2.TableName
        DGTS.AlternatingBackColor = Color.FromArgb(255, 192, 192)
        DataGridEx1.DataSource = dt2

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

    End Sub

    Sub sum()
        Number001.Value = 0
        Number002.Value = 0
        Number003.Value = 0
        DtView2 = New DataView(dsInvoice.Tables("INV2"), "", "", DataViewRowState.CurrentRows)
        If DtView2.Count <> 0 Then
            For j = 0 To DtView2.Count - 1
                Number001.Value = Number001.Value + DtView2(j)("invc_amnt")
                Number002.Value = Number002.Value + DtView2(j)("clct_amnt")
                Number003.Value = Number003.Value + DtView2(j)("balance")
            Next
        End If
    End Sub

    Sub F_chk()
        ERR_F = "0"

        '入金番号
        CHK_Edit1()
        If msg.Text <> Nothing Then ERR_F = "1" : Edit1.Focus() : Exit Sub

        '入金日
        CHK_Date1()
        If msg.Text <> Nothing Then ERR_F = "1" : Date1.Focus() : Exit Sub


        '入金額
        CHK_amnt()
        If msg.Text <> Nothing Then ERR_F = "1" : Exit Sub

    End Sub

    Sub CHK_Edit1()
        msg.Text = Nothing

        Edit1.Text = Trim(Edit1.Text)
        If Edit1.Text = Nothing Then
            Edit1.BackColor = System.Drawing.Color.Red
            msg.Text = "入金番号が入力されていません。"
            Exit Sub
        End If
        Edit1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_Date1()
        msg.Text = Nothing

        If Date1.Number = 0 Then
            Date1.BackColor = System.Drawing.Color.Red
            msg.Text = "入金日が入力されていません。"
            Exit Sub
        End If
        Date1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Sub CHK_amnt()
        msg.Text = Nothing

        DtView1 = New DataView(dsInvoice.Tables("INV2"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1
            If DtView1(i)("clct_amnt") <> 0 Then
                Exit Sub
            End If
        Next
        msg.Text = "入金額が入力されていません。"
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub Edit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.GotFocus
        Edit1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub
    Private Sub Date1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.GotFocus
        Date1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub Edit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit1.LostFocus
        CHK_Edit1()
    End Sub
    Private Sub Date1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.LostFocus
        CHK_Date1()
    End Sub

    '********************************************************************
    '**  全額入金
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DtView1 = New DataView(dsInvoice.Tables("INV2"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1
            DtView1(i)("clct_amnt") = DtView1(i)("clct_pln")
        Next
        Number002.Value = Number001.Value
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        F_chk()
        If ERR_F = "0" Then

            DB_OPEN("nMVAR")
            DtView1 = New DataView(dsInvoice.Tables("INV2"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1
                If DtView1(i)("clct_amnt") <> 0 Then

                    '入金
                    strSQL = "INSERT INTO T30_CLCT"
                    strSQL = strSQL & " (iｎvc_no, rcpt_no, clct_date, clct_no, clct_amnt)"
                    strSQL = strSQL & " VALUES (" & DtView1(i)("iｎvc_no") & ""
                    strSQL = strSQL & ", '" & DtView1(i)("rcpt_no") & "'"
                    strSQL = strSQL & ", CONVERT(DATETIME, '" & Date1.Text & "', 102)"
                    strSQL = strSQL & ", '" & Edit1.Text & "'"
                    strSQL = strSQL & ", " & DtView1(i)("clct_amnt") & ")"
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.ExecuteNonQuery()

                    If DtView1(i)("clct_pln") > DtView1(i)("clct_amnt") Then  '一部入金
                    Else                                                        '全額入金
                        strSQL = "UPDATE T21_INVC_SUB"
                        strSQL = strSQL & " SET fin_flg = '1'"
                        strSQL = strSQL & " WHERE (iｎvc_no = " & DtView1(i)("iｎvc_no") & ")"
                        strSQL = strSQL & " AND (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        SqlCmd1.ExecuteNonQuery()
                    End If
                End If

            Next
            DB_CLOSE()

            P_PRAM2 = "1"
            msg.Text = "入金処理しました。"
            Button2.Enabled = False
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        P_DsPRT.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
