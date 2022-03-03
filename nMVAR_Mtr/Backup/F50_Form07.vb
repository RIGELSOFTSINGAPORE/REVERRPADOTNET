Public Class F50_Form07
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, DsCMB, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, strFile, strData As String
    Dim i, r1, r2 As Integer

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
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn2 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents DataGrid1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Combo001 As GrapeCity.Win.Input.Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CL001 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F50_Form07))
        Me.Button98 = New System.Windows.Forms.Button
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn2 = New System.Windows.Forms.DataGridBoolColumn
        Me.DataGrid1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button1 = New System.Windows.Forms.Button
        Me.Combo001 = New GrapeCity.Win.Input.Combo
        Me.Label4 = New System.Windows.Forms.Label
        Me.CL001 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(912, 648)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 11
        Me.Button98.Text = "戻る"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ"
        Me.DataGridTextBoxColumn1.MappingName = "grup_code"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "ﾌﾟﾙｰﾌﾟ名"
        Me.DataGridTextBoxColumn2.MappingName = "grup_name"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 200
        '
        'DataGridBoolColumn2
        '
        Me.DataGridBoolColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn2.FalseValue = False
        Me.DataGridBoolColumn2.HeaderText = "削除"
        Me.DataGridBoolColumn2.MappingName = "delt_flg"
        Me.DataGridBoolColumn2.NullValue = CType(resources.GetObject("DataGridBoolColumn2.NullValue"), Object)
        Me.DataGridBoolColumn2.ReadOnly = True
        Me.DataGridBoolColumn2.TrueValue = True
        Me.DataGridBoolColumn2.Width = 50
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Red
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(20, 36)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(964, 604)
        Me.DataGrid1.TabIndex = 9
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridBoolColumn2})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M08_STORE"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "販社ｺｰﾄﾞ"
        Me.DataGridTextBoxColumn3.MappingName = "store_code"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 80
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "販社名"
        Me.DataGridTextBoxColumn4.MappingName = "name"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 300
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "住所"
        Me.DataGridTextBoxColumn5.MappingName = "adrs1"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 198
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(24, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "新規"
        '
        'Combo001
        '
        Me.Combo001.AutoSelect = True
        Me.Combo001.HighlightText = GrapeCity.Win.Input.HighlightText.Field
        Me.Combo001.Location = New System.Drawing.Point(128, 8)
        Me.Combo001.MaxDropDownItems = 45
        Me.Combo001.Name = "Combo001"
        Me.Combo001.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear})
        Me.Combo001.Size = New System.Drawing.Size(228, 24)
        Me.Combo001.Spin = New GrapeCity.Win.Input.Spin(0, 1, True, False, GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Combo001.TabIndex = 1056
        Me.Combo001.TextVAlign = GrapeCity.Win.Input.AlignVertical.Middle
        Me.Combo001.Value = "Combo001"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 24)
        Me.Label4.TabIndex = 1057
        Me.Label4.Text = "ｸﾞﾙｰﾌﾟ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CL001
        '
        Me.CL001.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CL001.Location = New System.Drawing.Point(360, 8)
        Me.CL001.Name = "CL001"
        Me.CL001.Size = New System.Drawing.Size(44, 24)
        Me.CL001.TabIndex = 1234
        Me.CL001.Text = "CL001"
        Me.CL001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CL001.Visible = False
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(800, 648)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(76, 32)
        Me.Button5.TabIndex = 1235
        Me.Button5.Text = "CSV出力"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(588, 648)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 32)
        Me.Button4.TabIndex = 1236
        Me.Button4.Text = "不整合CSV"
        '
        'F50_Form07
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.CL001)
        Me.Controls.Add(Me.Combo001)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F50_Form07"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "販社マスタ"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form07_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
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
        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='507'", "", DataViewRowState.CurrentRows)
        Select Case DtView1(0)("access_cls")
            Case Is = "3", "4"
                Button1.Enabled = True
        End Select
    End Sub

    '********************************************************************
    '**  コンボボックスセット
    '********************************************************************
    Sub CmbSet()

        'グループ
        strSQL = "SELECT cls_code, cls_code + ':' + cls_code_name AS cls_code_name"
        strSQL +=  " FROM M21_CLS_CODE"
        strSQL +=  " WHERE (cls_no = '006') AND (delt_flg = 0)"
        strSQL +=  " ORDER BY dsp_seq, cls_code"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsCMB, "CLS_CODE_006")
        DB_CLOSE()

        Combo001.DataSource = DsCMB.Tables("CLS_CODE_006")
        Combo001.DisplayMember = "cls_code_name"
        Combo001.ValueMember = "cls_code"

        Combo001.SelectedItem = Nothing
        Combo001.Text = Nothing
        CL001.Text = Nothing

    End Sub

    '********************************************************************
    '**  グループ変更
    '********************************************************************
    Private Sub Combo001_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.SelectedIndexChanged
        DsList1.Clear()

        Combo001.Text = Trim(Combo001.Text)
        DtView1 = New DataView(DsCMB.Tables("CLS_CODE_006"), "cls_code_name = '" & Combo001.Text & "'", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            CL001.Text = DtView1(0)("cls_code")
        Else
            CL001.Text = Nothing
        End If

        DB_OPEN("nMVAR")
        If CL001.Text = Nothing Then
            SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "M08_STORE")
        Else
            SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE_3", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 2)
            Pram1.Value = CL001.Text
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(DsList1, "M08_STORE")
        End If
        DB_CLOSE()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("M08_STORE")
        DataGrid1.DataSource = tbl

        'DtView1 = New DataView(DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)
    End Sub

    Private Sub Combo001_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo001.TextChanged
        If Combo001.Text = Nothing Then
            CL001.Text = Nothing

            DsList1.Clear()
            SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE", cnsqlclient)
            SqlCmd1.CommandType = CommandType.StoredProcedure
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nMVAR")
            SqlCmd1.CommandTimeout = 600
            DaList1.Fill(DsList1, "M08_STORE")
            DB_CLOSE()
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
    '**  データグリッド　エンター
    '********************************************************************
    Private Sub DataGrid1_CmdKeyEvent(ByVal keyData As System.Windows.Forms.Keys, ByRef Cancel As Boolean) Handles DataGrid1.CmdKeyEvent
        If DataGrid1.CurrentRowIndex <= DtView1.Count - 1 Then
            Select Case keyData
                Case Is = Keys.Return
                    Cursor = System.Windows.Forms.Cursors.WaitCursor
                    P_PRAM8 = DataGrid1(DataGrid1.CurrentRowIndex, 2)
                    Dim F50_Form07_2 As New F50_Form07_2
                    F50_Form07_2.ShowDialog()
                    If P_RTN = "1" Then '**  画面セット
                        WK_DsList1.Clear()
                        SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE_2", cnsqlclient)
                        SqlCmd1.CommandType = CommandType.StoredProcedure
                        Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
                        Pram1.Value = P_PRAM8
                        DaList1.SelectCommand = SqlCmd1
                        DB_OPEN("nMVAR")
                        SqlCmd1.CommandTimeout = 600
                        DaList1.Fill(WK_DsList1, "M08_STORE")
                        DB_CLOSE()
                        WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "", "", DataViewRowState.CurrentRows)

                        DtView1 = New DataView(DsList1.Tables("M08_STORE"), "store_code = '" & P_PRAM8 & "'", "", DataViewRowState.CurrentRows)
                        DtView1(0)("grup_code") = WK_DtView1(0)("grup_code")
                        DtView1(0)("grup_name") = WK_DtView1(0)("grup_name")
                        DtView1(0)("name") = WK_DtView1(0)("name")
                        DtView1(0)("adrs1") = WK_DtView1(0)("adrs1")
                        DtView1(0)("delt_flg") = WK_DtView1(0)("delt_flg")
                    End If
                    Cursor = System.Windows.Forms.Cursors.Default
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
    Private Sub DataGrid1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim hitinfo As DataGrid.HitTestInfo

        Try
            hitinfo = (CType(sender, DataGrid).HitTest(e.X, e.Y))
            If hitinfo.Row >= 0 Then
                Cursor = System.Windows.Forms.Cursors.WaitCursor
                P_PRAM8 = DataGrid1(DataGrid1.CurrentRowIndex, 2)
                Dim F50_Form07_2 As New F50_Form07_2
                F50_Form07_2.ShowDialog()
                If P_RTN = "1" Then '**  画面セット
                    WK_DsList1.Clear()
                    SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE", cnsqlclient)
                    SqlCmd1.CommandType = CommandType.StoredProcedure
                    'Dim Pram1 As SqlClient.SqlParameter = SqlCmd1.Parameters.Add("@p1", SqlDbType.Char, 4)
                    'Pram1.Value = P_PRAM8
                    DaList1.SelectCommand = SqlCmd1
                    DB_OPEN("nMVAR")
                    SqlCmd1.CommandTimeout = 600
                    DaList1.Fill(WK_DsList1, "M08_STORE")
                    DB_CLOSE()
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M08_STORE"), "store_code = '" & P_PRAM8 & "'", "", DataViewRowState.CurrentRows)

                    DtView1 = New DataView(DsList1.Tables("M08_STORE"), "store_code = '" & P_PRAM8 & "'", "", DataViewRowState.CurrentRows)
                    DtView1(0)("grup_code") = WK_DtView1(0)("grup_code")
                    DtView1(0)("grup_name") = WK_DtView1(0)("grup_name")
                    DtView1(0)("name") = WK_DtView1(0)("name")
                    DtView1(0)("adrs1") = WK_DtView1(0)("adrs1")
                    DtView1(0)("delt_flg") = WK_DtView1(0)("delt_flg")
                End If
                Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '********************************************************************
    '**  新規
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        P_PRAM8 = Nothing
        Dim F50_Form07_2 As New F50_Form07_2
        F50_Form07_2.ShowDialog()
        If P_RTN = "1" Then Combo001_SelectedIndexChanged(sender, e) '**  画面セット
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  CSV出力
    '********************************************************************
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'DataTable作成()
        WK_DsList1.Clear()
        strSQL = "SELECT M08_STORE.*, V_cls_006.cls_code_name AS grup_name, M08_STORE_1.name AS dlvr_name, M08_STORE_2.name AS invc_name"
        strSQL +=  ", V_cls_014.cls_code_name AS price_rprt_name, V_cls_024.cls_code_name AS rpr_rprt_name"
        strSQL +=  ", V_cls_015.cls_code_name AS dlvr_rprt_name, V_cls_021.cls_code_name AS dlvr_rprt_name2"
        strSQL +=  ", M09_SUB_OWN.name AS sub_name"
        strSQL +=  " FROM M08_STORE LEFT OUTER JOIN"
        strSQL +=  " M09_SUB_OWN ON M08_STORE.sub_code = M09_SUB_OWN.sub_code LEFT OUTER JOIN"
        strSQL +=  " V_cls_015 ON M08_STORE.dlvr_rprt_ptn = V_cls_015.cls_code LEFT OUTER JOIN"
        strSQL +=  " V_cls_021 ON M08_STORE.dlvr_rprt_ptn = V_cls_021.cls_code LEFT OUTER JOIN"
        strSQL +=  " V_cls_024 ON M08_STORE.rpr_rprt_ptn = V_cls_024.cls_code LEFT OUTER JOIN"
        strSQL +=  " V_cls_014 ON M08_STORE.price_rprt_ptn = V_cls_014.cls_code LEFT OUTER JOIN"
        strSQL +=  " M08_STORE AS M08_STORE_2 ON M08_STORE.invc_code = M08_STORE_2.store_code LEFT OUTER JOIN"
        strSQL +=  " M08_STORE AS M08_STORE_1 ON M08_STORE.dlvr_code = M08_STORE_1.store_code LEFT OUTER JOIN"
        strSQL +=  " V_cls_006 ON M08_STORE.grup_code = V_cls_006.cls_code"
        If CL001.Text <> Nothing Then
            strSQL +=  " WHERE (M08_STORE.grup_code = '" & CL001.Text & "')"
        End If
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(WK_DsList1, "M08")
        DB_CLOSE()

        WK_DtView1 = New DataView(WK_DsList1.Tables("M08"), "", "grup_code, store_code", DataViewRowState.CurrentRows)
        If WK_DtView1.Count <> 0 Then

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "販社マスタ.CSV"                         'はじめのファイル名を指定する
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
                waitDlg.ProgressMax = WK_DtView1.Count  ' 全体の処理件数を設定
                waitDlg.ProgressValue = 0       ' 最初の件数を設定
                Application.DoEvents()          ' メッセージ処理を促して表示を更新する

                Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

                'データを書き込む
                strData = "グループコード,グループ名,販社コード,販社名称,販社カナ,郵便番号,住所1,住所2,TEL,FAX,個人フラグ"
                strData = strData & ",消費税計算区分（0=四捨五入 1=切捨て 2=切上げ）,締日,修理票保証期間（日）,納入先コード,納入先,請求先コード"
                strData = strData & ",請求先,FAX送信時刻,店舗コード,取引先コード,技術料掛率,技術料マージン率,部品代マージン率"
                strData = strData & ",見積書発行区分（0=印刷 1=FAX 2=TEL）,見積書パターンCD,見積書パターン,見積書部品代出力フラグ"
                strData = strData & ",作業報告書発行フラグ,作業報告書パターンCD,作業報告書パターン,作業報告書金額出力フラグ"
                strData = strData & ",作業報告書送料以下出力フラグ,作業報告書部品代出力フラグ,納品書発行区分（0=発行しない 1=納品書 2=チェーン伝票）"
                strData = strData & ",納品書パターンCD,納品書パターン,請求書発行フラグ,代行修理会社コード,代行修理会社,ＣＣＡＲフラグ,WebDataフラグ"
                strData = strData & ",見積書修理表印刷TEL,見積書修理表印刷FAX,登録日,削除フラグ"
                swFile.WriteLine(strData)

                For i = 0 To WK_DtView1.Count - 1

                    waitDlg.ProgressMsg = Fix((i + 1) * 100 / WK_DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(WK_DtView1.Count, "##,##0") & " 件）"
                    waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / WK_DtView1.Count) & "%"
                    Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                    waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                    strData = WK_DtView1(i)("grup_code")
                    strData = strData & "," & WK_DtView1(i)("grup_name")
                    strData = strData & "," & WK_DtView1(i)("store_code")
                    strData = strData & "," & WK_DtView1(i)("name")
                    strData = strData & "," & WK_DtView1(i)("name_kana")
                    strData = strData & "," & WK_DtView1(i)("zip")
                    strData = strData & "," & WK_DtView1(i)("adrs1")
                    strData = strData & "," & WK_DtView1(i)("adrs2")
                    strData = strData & "," & WK_DtView1(i)("tel")
                    strData = strData & "," & WK_DtView1(i)("fax")
                    If WK_DtView1(i)("idvd_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    strData = strData & "," & WK_DtView1(i)("calc_cls")
                    strData = strData & "," & WK_DtView1(i)("cls_date")
                    strData = strData & "," & WK_DtView1(i)("wrn_period")
                    strData = strData & "," & WK_DtView1(i)("dlvr_code")
                    strData = strData & "," & WK_DtView1(i)("dlvr_name")
                    strData = strData & "," & WK_DtView1(i)("invc_code")
                    strData = strData & "," & WK_DtView1(i)("invc_name")
                    strData = strData & "," & WK_DtView1(i)("fax_snd_time")
                    strData = strData & "," & WK_DtView1(i)("cust_code")
                    strData = strData & "," & WK_DtView1(i)("client_code")
                    strData = strData & "," & WK_DtView1(i)("tech_rate")
                    strData = strData & "," & WK_DtView1(i)("tech_mrgn_rate")
                    strData = strData & "," & WK_DtView1(i)("part_mrgn_rate")
                    strData = strData & "," & WK_DtView1(i)("price_rprt_cls")
                    strData = strData & "," & WK_DtView1(i)("price_rprt_ptn")
                    strData = strData & "," & WK_DtView1(i)("price_rprt_name")
                    If WK_DtView1(i)("price_rprt_part_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    If WK_DtView1(i)("rpr_rprt_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    strData = strData & "," & WK_DtView1(i)("rpr_rprt_ptn")
                    strData = strData & "," & WK_DtView1(i)("rpr_rprt_name")
                    If WK_DtView1(i)("rpr_rprt_amnt_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    If WK_DtView1(i)("rpr_rprt_dvl_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    If WK_DtView1(i)("rpr_rprt_part_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    strData = strData & "," & WK_DtView1(i)("dlvr_rprt_cls")
                    strData = strData & "," & WK_DtView1(i)("dlvr_rprt_ptn")
                    Select Case WK_DtView1(i)("dlvr_rprt_cls")
                        Case Is = "0"
                            strData = strData & ","
                        Case Is = "1"
                            strData = strData & "," & WK_DtView1(i)("dlvr_rprt_name")
                        Case Is = "2"
                            strData = strData & "," & WK_DtView1(i)("dlvr_rprt_name2")
                    End Select
                    If WK_DtView1(i)("invc_rprt_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    strData = strData & "," & WK_DtView1(i)("sub_code")
                    strData = strData & "," & WK_DtView1(i)("sub_name")
                    If WK_DtView1(i)("ccar_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    If WK_DtView1(i)("web_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"
                    strData = strData & "," & WK_DtView1(i)("print_tel")
                    strData = strData & "," & WK_DtView1(i)("print_fax")
                    strData = strData & "," & WK_DtView1(i)("reg_date")
                    If WK_DtView1(i)("delt_flg") = "True" Then strData = strData & ",1" Else strData = strData & ",0"

                    strData = strData.Replace(System.Environment.NewLine, " ")

                    swFile.WriteLine(strData)
                Next
                swFile.Close()          'ファイルを閉じる
                MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                waitDlg.Close()         '進行状況ダイアログを閉じる
                Me.Enabled = True       'オーナーのフォームを無効にする
            End If
        End If
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsCMB.Clear()
        DsList1.Clear()
        WK_DsList1.Clear()
        Close()
    End Sub

    '********************************************************************
    '**  不整合CSV出力
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        'DataTable作成()
        WK_DsList1.Clear()
        DB_OPEN("nMVAR")

        SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE_4", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r1 = DaList1.Fill(WK_DsList1, "M08_4")

        SqlCmd1 = New SqlClient.SqlCommand("sp_M08_STORE_5", cnsqlclient)
        SqlCmd1.CommandType = CommandType.StoredProcedure
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        r2 = DaList1.Fill(WK_DsList1, "M08_5")

        DB_CLOSE()

        If r1 + r2 = 0 Then
            MsgBox("不整合はありませんでした。")
        Else

            Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "販社不整合.CSV"                         'はじめのファイル名を指定する
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

                waitDlg.MainMsg = "不整合CSV出力中"   ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMsg = ""        ' 進行状況ダイアログのメーターを設定
                waitDlg.ProgressMax = r1 + r2   ' 全体の処理件数を設定
                waitDlg.ProgressValue = 0       ' 最初の件数を設定
                Application.DoEvents()          ' メッセージ処理を促して表示を更新する

                Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
                swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

                'データを書き込む
                strData = "納品先（請求先）コード,納品先（請求先）名称,納品先（請求先）グループ,販社コード,販社名称,販社グループ"
                strData = strData & ",納品書発行（納品先）,納品書発行（販社）,"
                strData = strData & ",納品書パターン（納品先）,納品書パターン（販社）,"
                strData = strData & ",締日（請求先）,締日（販社）,"
                strData = strData & ",請求書発行（請求先）,請求書発行（販社）,"
                strData = strData & ",請求書パターン（請求先）,請求書パターン（販社）,"
                strData = strData & ",請求明細表パターン（請求先）,請求明細表パターン（販社）,"
                swFile.WriteLine(strData)

                '納品先
                WK_DtView1 = New DataView(WK_DsList1.Tables("M08_4"), "", "", DataViewRowState.CurrentRows)
                If WK_DtView1.Count <> 0 Then

                    For i = 0 To WK_DtView1.Count - 1

                        waitDlg.ProgressMsg = Fix((i + 1) * 100 / (r1 + r2)) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(r1 + r2, "##,##0") & " 件）"
                        waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / (r1 + r2)) & "%"
                        Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                        waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                        strData = WK_DtView1(i)("dlvr_code")
                        strData = strData & "," & WK_DtView1(i)("dlvr_name")
                        strData = strData & "," & WK_DtView1(i)("grup_name")
                        strData = strData & "," & WK_DtView1(i)("store_code")
                        strData = strData & "," & WK_DtView1(i)("name")
                        strData = strData & "," & WK_DtView1(i)("grup_name2")
                        Select Case WK_DtView1(i)("dlvr_rprt_cls")
                            Case Is = "0"
                                strData = strData & ",しない"
                            Case Is = "1"
                                strData = strData & ",通常"
                            Case Is = "2"
                                strData = strData & ",ﾁｪｰﾝ"
                            Case Else
                                strData = strData & ","
                        End Select
                        Select Case WK_DtView1(i)("dlvr_rprt_cls2")
                            Case Is = "0"
                                strData = strData & ",しない"
                            Case Is = "1"
                                strData = strData & ",通常"
                            Case Is = "2"
                                strData = strData & ",ﾁｪｰﾝ"
                            Case Else
                                strData = strData & ","
                        End Select

                        If WK_DtView1(i)("dlvr_rprt_cls") <> WK_DtView1(i)("dlvr_rprt_cls2") Then
                            strData = strData & ",×"
                        Else
                            strData = strData & ","
                        End If
                        If IsDBNull(WK_DtView1(i)("cls_code_name")) Then WK_DtView1(i)("cls_code_name") = ""
                        If IsDBNull(WK_DtView1(i)("cls_code_name2")) Then WK_DtView1(i)("cls_code_name2") = ""
                        strData = strData & "," & WK_DtView1(i)("cls_code_name")
                        strData = strData & "," & WK_DtView1(i)("cls_code_name2")
                        If WK_DtView1(i)("cls_code_name") <> WK_DtView1(i)("cls_code_name2") Then
                            strData = strData & ",×"
                        Else
                            strData = strData & ","
                        End If

                        swFile.WriteLine(strData)
                    Next

                    '請求先
                    WK_DtView1 = New DataView(WK_DsList1.Tables("M08_5"), "", "", DataViewRowState.CurrentRows)
                    If WK_DtView1.Count <> 0 Then

                        For i = 0 To WK_DtView1.Count - 1

                            waitDlg.ProgressMsg = Fix((r1 + i + 1) * 100 / (r1 + r2)) & "%　（" & Format(r1 + i + 1, "##,##0") & " / " & Format(r1 + r2, "##,##0") & " 件）"
                            waitDlg.Text = "実行中・・・" & Fix((r1 + i + 1) * 100 / (r1 + r2)) & "%"
                            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                            strData = WK_DtView1(i)("invc_code")
                            strData = strData & "," & WK_DtView1(i)("invc_name")
                            strData = strData & "," & WK_DtView1(i)("grup_name")
                            strData = strData & "," & WK_DtView1(i)("store_code")
                            strData = strData & "," & WK_DtView1(i)("name")
                            strData = strData & "," & WK_DtView1(i)("grup_name2")
                            strData = strData & ",,,,,,"
                            strData = strData & "," & WK_DtView1(i)("cls_date")
                            strData = strData & "," & WK_DtView1(i)("cls_date2")
                            If WK_DtView1(i)("cls_date") <> WK_DtView1(i)("cls_date2") Then
                                strData = strData & ",×"
                            Else
                                strData = strData & ","
                            End If
                            If WK_DtView1(i)("invc_rprt_flg") = "True" Then
                                strData = strData & ",印刷"
                            Else
                                strData = strData & ",しない"
                            End If
                            If WK_DtView1(i)("invc_rprt_flg2") = "True" Then
                                strData = strData & ",印刷"
                            Else
                                strData = strData & ",しない"
                            End If
                            If WK_DtView1(i)("invc_rprt_flg") <> WK_DtView1(i)("invc_rprt_flg2") Then
                                strData = strData & ",×"
                            Else
                                strData = strData & ","
                            End If
                            If IsDBNull(WK_DtView1(i)("invc_rprt_ptn_name")) Then WK_DtView1(i)("invc_rprt_ptn_name") = ""
                            If IsDBNull(WK_DtView1(i)("invc_rprt_ptn_name2")) Then WK_DtView1(i)("invc_rprt_ptn_name2") = ""
                            strData = strData & "," & WK_DtView1(i)("invc_rprt_ptn_name")
                            strData = strData & "," & WK_DtView1(i)("invc_rprt_ptn_name2")
                            If WK_DtView1(i)("invc_rprt_ptn_name") <> WK_DtView1(i)("invc_rprt_ptn_name2") Then
                                strData = strData & ",×"
                            Else
                                strData = strData & ","
                            End If
                            If IsDBNull(WK_DtView1(i)("invc_dtl_ptn_name")) Then WK_DtView1(i)("invc_dtl_ptn_name") = ""
                            If IsDBNull(WK_DtView1(i)("invc_dtl_ptn_name2")) Then WK_DtView1(i)("invc_dtl_ptn_name2") = ""
                            strData = strData & "," & WK_DtView1(i)("invc_dtl_ptn_name")
                            strData = strData & "," & WK_DtView1(i)("invc_dtl_ptn_name2")
                            If WK_DtView1(i)("invc_dtl_ptn_name") <> WK_DtView1(i)("invc_dtl_ptn_name2") Then
                                strData = strData & ",×"
                            Else
                                strData = strData & ","
                            End If
                            swFile.WriteLine(strData)
                        Next
                    End If

                    swFile.Close()          'ファイルを閉じる
                    MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    waitDlg.Close()         '進行状況ダイアログを閉じる
                    Me.Enabled = True       'オーナーのフォームを無効にする
                End If
            End If
        End If
        WK_DsList1.Clear()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
