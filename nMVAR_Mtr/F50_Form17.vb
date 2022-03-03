Public Class F50_Form17
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL As String
    Dim i, r, chg_itm As Integer
    Dim M_CLS As String = "M50"

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
    Friend WithEvents Date001 As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Label007 As System.Windows.Forms.Label
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button80 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Date001 = New GrapeCity.Win.Input.Interop.Date
        Me.Label007 = New System.Windows.Forms.Label
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.msg = New System.Windows.Forms.Label
        Me.Button80 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Date001
        '
        Me.Date001.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.Date001.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyy/MM", "", "")
        Me.Date001.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date001.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date001.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyy/MM", "", "")
        Me.Date001.HighlightText = GrapeCity.Win.Input.Interop.HighlightText.All
        Me.Date001.Location = New System.Drawing.Point(112, 12)
        Me.Date001.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2020, 12, 31, 23, 59, 59, 0))
        Me.Date001.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2000, 1, 1, 0, 0, 0, 0))
        Me.Date001.Name = "Date001"
        Me.Date001.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date001.Size = New System.Drawing.Size(92, 28)
        Me.Date001.TabIndex = 1758
        Me.Date001.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date001.Value = Nothing
        '
        'Label007
        '
        Me.Label007.BackColor = System.Drawing.Color.Navy
        Me.Label007.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label007.ForeColor = System.Drawing.Color.White
        Me.Label007.Location = New System.Drawing.Point(12, 12)
        Me.Label007.Name = "Label007"
        Me.Label007.Size = New System.Drawing.Size(100, 28)
        Me.Label007.TabIndex = 1759
        Me.Label007.Text = "対象年月"
        Me.Label007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(12, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.Size = New System.Drawing.Size(404, 464)
        Me.DataGridEx1.TabIndex = 1760
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(12, 520)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(404, 20)
        Me.msg.TabIndex = 1764
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button80
        '
        Me.Button80.BackColor = System.Drawing.SystemColors.Control
        Me.Button80.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button80.Location = New System.Drawing.Point(248, 548)
        Me.Button80.Name = "Button80"
        Me.Button80.Size = New System.Drawing.Size(72, 28)
        Me.Button80.TabIndex = 1762
        Me.Button80.TabStop = False
        Me.Button80.Text = "履歴"
        '
        'Button98
        '
        Me.Button98.BackColor = System.Drawing.SystemColors.Control
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(344, 548)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 28)
        Me.Button98.TabIndex = 1763
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(8, 548)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 28)
        Me.Button1.TabIndex = 1761
        Me.Button1.Text = "更新"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M50_BOCS_TARGET"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "QG名"
        Me.DataGridTextBoxColumn1.MappingName = "name"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 150
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn2.Format = "##,##0"
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "BOCS TARGET"
        Me.DataGridTextBoxColumn2.MappingName = "bocs_target"
        Me.DataGridTextBoxColumn2.NullText = "0"
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'F50_Form17
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.ClientSize = New System.Drawing.Size(430, 584)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button80)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.Date001)
        Me.Controls.Add(Me.Label007)
        Me.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form17"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOCS TARGET"
        CType(Me.Date001, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form17_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        DspSet()    '**  画面セット
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Date001.MaxDate = "9999/12/31 23:59:59"
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        Date001.Text = Format(Now.Date, "yyyy/MM")
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='517'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "2"
                Button1.Enabled = False
            Case Is = "3"
                Button1.Enabled = True
            Case Is = "4"
                Button1.Enabled = True
        End Select
    End Sub

    '********************************************************************
    '**  TextChanged
    '********************************************************************
    Private Sub Date001_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date001.TextChanged
        msg.Text = Nothing
        If Date001.Number <> 0 Then
            DspSet()
        End If
    End Sub

    '********************************************************************
    '**  画面セット
    '********************************************************************
    Sub DspSet()

        DsList1.Clear()
        strSQL = "SELECT M06_RPAR_COMP.rpar_comp_code, M06_RPAR_COMP.name, M50.bocs_target"
        strSQL +=  " FROM M06_RPAR_COMP LEFT OUTER JOIN"
        strSQL +=  " (SELECT proc_date, brch_code, bocs_target FROM M50_BOCS_TARGET WHERE (proc_date = CONVERT(DATETIME, '" & Date001.Text & "/01', 102))) AS M50 ON"
        strSQL +=  " M06_RPAR_COMP.rpar_comp_code = M50.brch_code"
        strSQL +=  " WHERE (M06_RPAR_COMP.own_flg = 1) AND (M06_RPAR_COMP.delt_flg = 0)"
        strSQL +=  " OR (M06_RPAR_COMP.own_flg = 1) AND (M50.bocs_target IS NOT NULL)"
        strSQL +=  " ORDER BY M06_RPAR_COMP.dsp_seq, M06_RPAR_COMP.rpar_comp_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        r = DaList1.Fill(DsList1, "M50_BOCS_TARGET")
        DB_CLOSE()

        If r = 0 Then Button1.Enabled = False Else Button1.Enabled = True

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M50_BOCS_TARGET")
        DataGridEx1.DataSource = tbl

        '新しい行の追加を禁止する
        Dim cm As CurrencyManager
        cm = CType(Me.BindingContext(DataGridEx1.DataSource), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        dv.AllowNew = False

    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_HSTY_DATE = Now
        chg_itm = 0

        DtView1 = New DataView(DsList1.Tables("M50_BOCS_TARGET"), "", "", DataViewRowState.CurrentRows)
        For i = 0 To DtView1.Count - 1

            WK_DsList1.Clear()
            strSQL = "SELECT bocs_target FROM M50_BOCS_TARGET"
            strSQL +=  " WHERE (proc_date = CONVERT(DATETIME, '" & Date001.Text & "/01', 102))"
            strSQL +=  " AND (brch_code = '" & DtView1(i)("rpar_comp_code") & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            r = DaList1.Fill(WK_DsList1, "M50_BOCS_TARGET")
            DB_CLOSE()
            WK_DtView1 = New DataView(WK_DsList1.Tables("M50_BOCS_TARGET"), "", "", DataViewRowState.CurrentRows)

            If Not IsDBNull(DtView1(i)("bocs_target")) Then 'Zero以外
                If r = 0 Then   '登録
                    strSQL = "INSERT INTO M50_BOCS_TARGET"
                    strSQL +=  " (proc_date, brch_code, bocs_target)"
                    strSQL +=  " VALUES (CONVERT(DATETIME, '" & Date001.Text & "/01', 102)"
                    strSQL +=  ", '" & DtView1(i)("rpar_comp_code") & "'"
                    strSQL += ", " & DtView1(i)("bocs_target") & ""
                    strSQL += ")"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Date001.Text, DtView1(i)("name"), "0", DtView1(i)("bocs_target"))
                Else            '更新
                    strSQL = "UPDATE M50_BOCS_TARGET"
                    strSQL +=  " SET bocs_target = " & DtView1(i)("bocs_target") & ""
                    strSQL +=  " WHERE (proc_date = CONVERT(DATETIME, '" & Date001.Text & "/01', 102))"
                    strSQL +=  " AND (brch_code = '" & DtView1(i)("rpar_comp_code") & "')"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Date001.Text, DtView1(i)("name"), WK_DtView1(0)("bocs_target"), DtView1(i)("bocs_target"))
                End If
            Else    'Zero
                If r <> 0 Then  '削除
                    strSQL = "DELETE M50_BOCS_TARGET"
                    strSQL +=  " WHERE (proc_date = CONVERT(DATETIME, '" & Date001.Text & "/01', 102))"
                    strSQL +=  " AND (brch_code = '" & DtView1(i)("rpar_comp_code") & "')"
                    DB_OPEN("nMVAR")
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    SqlCmd1.CommandTimeout = 600
                    SqlCmd1.ExecuteNonQuery()
                    DB_CLOSE()
                    chg_itm = chg_itm + 1 : add_MTR_hsty(M_CLS, Date001.Text, DtView1(i)("name"), WK_DtView1(0)("bocs_target"), "0")
                End If
            End If
        Next

        If chg_itm = 0 Then
            msg.Text = "変更箇所がありません。"
        Else
            msg.Text = "更新しました。"
        End If

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
        Pram4.Value = P_PRAM1 & Trim(Date001.Text)
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
        Close()
    End Sub
End Class
