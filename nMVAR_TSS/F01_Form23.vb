Public Class F01_Form23
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, DtView2, DtView3, DtView4 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, WK_str, sin, hen, ZH As String
    Dim WK_str1, WK_str2 As String

    Dim i, j, r, pos As Integer
    Dim up_date As Date

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
    'Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.Interop.FunctionKey
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridEx1 As nMVAR_TSS.DataGridEx
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form23))
        Me.Label1 = New System.Windows.Forms.Label
        ' Me.FunctionKey1 = New GrapeCity.Win.Input.Interop.FunctionKey
        Me.f12 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridEx1 = New nMVAR_TSS.DataGridEx
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.f01 = New System.Windows.Forms.Button
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(252, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "見積回答反映"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FunctionKey1
        '
        'Me.FunctionKey1.ActiveKeySet = "Default"
        'Me.FunctionKey1.Location = New System.Drawing.Point(0, 654)
        'Me.FunctionKey1.Name = "FunctionKey1"
        'Me.FunctionKey1.Size = New System.Drawing.Size(874, 0)
        'Me.FunctionKey1.TabIndex = 45
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(768, 8)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 44
        Me.f12.Text = "F12:閉じる"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "TSS_ETMT_ANS"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(860, 588)
        Me.DataGridEx1.TabIndex = 43
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.MappingName = "id"
        Me.DataGridTextBoxColumn19.Width = 0
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "ﾃﾞｰﾀ送信日"
        Me.DataGridTextBoxColumn20.MappingName = "snd_date"
        Me.DataGridTextBoxColumn20.Width = 90
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "ｶﾙﾃ番号"
        Me.DataGridTextBoxColumn1.MappingName = "cust_repr_no"
        Me.DataGridTextBoxColumn1.Width = 120
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "修理管理番号"
        Me.DataGridTextBoxColumn2.MappingName = "rcpt_no"
        Me.DataGridTextBoxColumn2.Width = 110
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "見積区分"
        Me.DataGridTextBoxColumn3.MappingName = "etmt_cls"
        Me.DataGridTextBoxColumn3.Width = 70
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "合計金額（税込）"
        Me.DataGridTextBoxColumn4.MappingName = "etmt_chrg"
        Me.DataGridTextBoxColumn4.Width = 120
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "回答ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn5.MappingName = "etmt_ans"
        Me.DataGridTextBoxColumn5.Width = 90
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "見積回答日"
        Me.DataGridTextBoxColumn6.MappingName = "etmt_ans_date"
        Me.DataGridTextBoxColumn6.Width = 90
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "お客様名"
        Me.DataGridTextBoxColumn7.MappingName = "user_name"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 120
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Location = New System.Drawing.Point(656, 8)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 47
        Me.f01.Text = "F1:反映"
        '
        'F01_Form23
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(874, 654)
        Me.Controls.Add(Me.f01)
        Me.Controls.Add(Me.Label1)
        'Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form23"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "見積回答反映"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F01_Form23_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Me.Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ設定
        DsList1.Clear()
        strSQL = "SELECT TSS_ETMT_ANS.*, T01_REP_MTR.user_name"
        strSQL = strSQL & " FROM TSS_ETMT_ANS LEFT OUTER JOIN"
        strSQL = strSQL & " T01_REP_MTR ON TSS_ETMT_ANS.rcpt_no = T01_REP_MTR.rcpt_no"
        strSQL = strSQL & " WHERE (TSS_ETMT_ANS.upd_date IS NULL)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "TSS_ETMT_ANS")
        DB_CLOSE()

        If r = 0 Then f01.Enabled = False

        Dim tbl As New DataTable
        tbl = DsList1.Tables("TSS_ETMT_ANS")
        DataGridEx1.DataSource = tbl
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
    '**  反映ボタン
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        up_date = Now
        P_HSTY_DATE = up_date

        DtView1 = New DataView(DsList1.Tables("TSS_ETMT_ANS"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1
            If DtView1(i)("etmt_ans") = "01" Then
                ZH = "Z"
            Else
                ZH = "H"
            End If

            '更新済フラグ
            strSQL = "UPDATE TSS_ETMT_ANS"
            strSQL = strSQL & " SET upd_date = CONVERT(DATETIME, '" & up_date & "', 102)"
            strSQL = strSQL & " WHERE (id = " & DtView1(i)("id") & ")"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.CommandTimeout = 600
            DB_OPEN("nMVAR")
            SqlCmd1.ExecuteNonQuery()

            '履歴用
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM T01_REP_MTR"
            strSQL = strSQL & " WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(WK_DsList1, "T01_REP_MTR")
            DB_CLOSE()

            DtView2 = New DataView(WK_DsList1.Tables("T01_REP_MTR"), "", "", DataViewRowState.CurrentRows)
            If DtView2.Count <> 0 Then

                'T01_REP_MTR
                strSQL = "UPDATE T01_REP_MTR"
                strSQL = strSQL & " SET  zh_code = '" & ZH & "'"
                strSQL = strSQL & ", rsrv_cacl_date = CONVERT(DATETIME, '" & DtView1(i)("etmt_ans_date") & "', 102)"
                strSQL = strSQL & " WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                DB_OPEN("nMVAR")
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()

                'HSTY
                '回答受信日
                If Not IsDBNull(DtView2(0)("rsrv_cacl_date")) Then WK_str1 = DtView2(0)("rsrv_cacl_date") Else WK_str1 = Nothing
                If Not IsDBNull(DtView1(i)("etmt_ans_date")) Then WK_str2 = DtView1(i)("etmt_ans_date") Else WK_str2 = Nothing
                If WK_str1 <> WK_str2 Then
                    add_hsty(DtView1(i)("rcpt_no"), "回答受信日", WK_str1, WK_str2)
                End If

                '続行/返却
                If Not IsDBNull(DtView2(0)("zh_code")) Then
                    If DtView2(0)("zh_code") = "Z" Then WK_str1 = "続行" Else WK_str1 = "返却"
                Else
                    WK_str1 = Nothing
                End If
                If ZH = "Z" Then WK_str2 = "続行" Else WK_str2 = "返却"

                If WK_str1 <> WK_str2 Then
                    add_hsty(DtView1(i)("rcpt_no"), "続行/返却", WK_str1, WK_str2)
                End If

            End If
        Next
        MessageBox.Show("反映しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        f01.Enabled = False
        DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  ファンクションキー
    '********************************************************************
    'Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.Interop.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

    '    e.Handled = True        'ファンクションキーに割り付けられた設定を無効にします。
    '    Select Case e.KeyIndex  'ファンクションキーが押下された場合の処理を行います。
    '        Case 0  'F1
    '            f01_Click(sender, e)
    '        Case 1  'F2
    '        Case 2  'F3
    '        Case 3  'F4
    '        Case 4  'F5
    '        Case 5  'F6
    '        Case 6  'F7
    '        Case 7  'F8
    '        Case 8  'F9
    '        Case 9  'F10
    '        Case 10 'F11
    '        Case 11 'F12
    '            f12_Click(sender, e)
    '    End Select
    'End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub f01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.GotFocus
        f01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub f01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.LostFocus
        f01.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
