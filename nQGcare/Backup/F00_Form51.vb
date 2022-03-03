Public Class F00_Form51
    Inherits System.Windows.Forms.Form

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, Err_F, WK_str, strFile, strData As String
    Dim i, j, r, n As Integer

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
    Friend WithEvents Date1 As GrapeCity.Win.Input.Date
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button99 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridBoolColumn1 As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F00_Form51))
        Me.Date1 = New GrapeCity.Win.Input.Date
        Me.Label23 = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridBoolColumn1 = New System.Windows.Forms.DataGridBoolColumn
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button99 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Date1
        '
        Me.Date1.DisplayFormat = New GrapeCity.Win.Input.DateDisplayFormat("yyyy/MM", "", "")
        Me.Date1.DropDown = New GrapeCity.Win.Input.DropDown(GrapeCity.Win.Input.ButtonPosition.Inside, True, GrapeCity.Win.Input.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date1.DropDownCalendar.Size = New System.Drawing.Size(158, 165)
        Me.Date1.Format = New GrapeCity.Win.Input.DateFormat("yyyy/MM", "", "")
        Me.Date1.Location = New System.Drawing.Point(100, 8)
        Me.Date1.Name = "Date1"
        Me.Date1.Shortcuts = New GrapeCity.Win.Input.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.KeyActions() {GrapeCity.Win.Input.KeyActions.Clear, GrapeCity.Win.Input.KeyActions.Now})
        Me.Date1.Size = New System.Drawing.Size(96, 24)
        Me.Date1.TabIndex = 0
        Me.Date1.TextHAlign = GrapeCity.Win.Input.AlignHorizontal.Center
        Me.Date1.Value = New GrapeCity.Win.Input.DateTimeEx(New Date(2013, 4, 1, 10, 6, 26, 0))
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(20, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 24)
        Me.Label23.TabIndex = 1431
        Me.Label23.Text = "計上年月"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(12, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeaderWidth = 10
        Me.DataGrid1.Size = New System.Drawing.Size(980, 568)
        Me.DataGrid1.TabIndex = 1
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridBoolColumn1})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "T40"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "加入番号"
        Me.DataGridTextBoxColumn1.MappingName = "加入番号"
        Me.DataGridTextBoxColumn1.Width = 120
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "お客様名"
        Me.DataGridTextBoxColumn7.MappingName = "user_name"
        Me.DataGridTextBoxColumn7.Width = 160
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "計上区分"
        Me.DataGridTextBoxColumn2.MappingName = "計上区分名"
        Me.DataGridTextBoxColumn2.Width = 90
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "##,##0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "計上金額"
        Me.DataGridTextBoxColumn3.MappingName = "計上金額"
        Me.DataGridTextBoxColumn3.Width = 90
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "##,##0"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "預かり金"
        Me.DataGridTextBoxColumn4.MappingName = "預かり金"
        Me.DataGridTextBoxColumn4.Width = 90
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "##,##0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "計上回数"
        Me.DataGridTextBoxColumn5.MappingName = "計上回数"
        Me.DataGridTextBoxColumn5.Width = 90
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn6.Format = "yyyy/MM/dd"
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "登録日"
        Me.DataGridTextBoxColumn6.MappingName = "登録日"
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridBoolColumn1
        '
        Me.DataGridBoolColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridBoolColumn1.FalseValue = False
        Me.DataGridBoolColumn1.HeaderText = "計上確認"
        Me.DataGridBoolColumn1.MappingName = "計上確認"
        Me.DataGridBoolColumn1.NullValue = CType(resources.GetObject("DataGridBoolColumn1.NullValue"), Object)
        Me.DataGridBoolColumn1.TrueValue = True
        Me.DataGridBoolColumn1.Width = 90
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button6.Location = New System.Drawing.Point(628, 648)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(120, 28)
        Me.Button6.TabIndex = 2
        Me.Button6.Text = "計上CSV出力"
        '
        'Button99
        '
        Me.Button99.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button99.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button99.Location = New System.Drawing.Point(916, 648)
        Me.Button99.Name = "Button99"
        Me.Button99.Size = New System.Drawing.Size(72, 28)
        Me.Button99.TabIndex = 4
        Me.Button99.Text = "閉じる"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 648)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(592, 28)
        Me.msg.TabIndex = 1463
        Me.msg.Text = "msg"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(112, 616)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 24)
        Me.Label1.TabIndex = 1464
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(236, 616)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 24)
        Me.Label2.TabIndex = 1465
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(768, 648)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "請求先CSV出力"
        '
        'F00_Form51
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1002, 683)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button99)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Date1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "F00_Form51"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iPad計上リスト"
        CType(Me.Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    '** 起動時
    '******************************************************************
    Private Sub F00_Form51_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call inz()      '** 初期処理
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

        Date1.Text = Format(DateAdd(DateInterval.Month, -1, Now.Date), "yyyy/MM")
    End Sub

    '********************************************************************
    '** SQL
    '********************************************************************
    Sub sql()
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DsList1.Clear()
        strSQL = "SELECT T40_計上.加入番号, T40_計上.計上区分, V_M02_KJO.cls_code_name AS 計上区分名"
        strSQL += ", T40_計上.計上金額, T40_計上.預かり金, T40_計上.計上回数, T40_計上.登録日, T40_計上.計上確認"
        strSQL += ", T05_iPad.corp_flg, T01_member.user_name"
        strSQL += " FROM T40_計上 INNER JOIN"
        strSQL += " V_M02_KJO ON T40_計上.計上区分 = V_M02_KJO.cls_code INNER JOIN"
        strSQL += " T05_iPad ON T40_計上.加入番号 = T05_iPad.code INNER JOIN"
        strSQL += " T01_member ON T40_計上.加入番号 = T01_member.code"
        strSQL += " WHERE (T40_計上.計上月 = N'" & Mid(Date1.Number, 1, 6) & "')"
        strSQL += " AND (T01_member.delt_flg = 0)"
        strSQL += " ORDER BY T40_計上.加入番号, 計上区分名, T40_計上.計上回数"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nQGCare")
        r = DaList1.Fill(DsList1, "T40")
        DB_CLOSE()

        Label1.Text = r & "件"
        If r = 0 Then
            Button6.Enabled = False
            Button1.Enabled = False
            msg.Text = "対象データなし"
            Label2.Text = Nothing
        Else
            strSQL = "SELECT SUM(計上金額) AS 合計 FROM T40_計上 WHERE (計上月 = N'" & Mid(Date1.Number, 1, 6) & "')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(DsList1, "合計")
            DB_CLOSE()
            WK_DtView1 = New DataView(DsList1.Tables("合計"), "", "", DataViewRowState.CurrentRows)
            Label2.Text = "計上額合計：" & Format(WK_DtView1(0)("合計"), "##,##0")

            Button6.Enabled = True
            Button1.Enabled = True
            msg.Text = Nothing
        End If


        Dim tbl1 As New DataTable
        tbl1 = DsList1.Tables("T40")
        DataGrid1.DataSource = tbl1

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** LostFocus
    '******************************************************************
    Private Sub Date1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Date1.LostFocus
        Call sql()      '** SQL
    End Sub

    '******************************************************************
    '** CSV
    '******************************************************************
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "計上リスト" & Mid(Date1.Number, 1, 6) & ".CSV" 'はじめのファイル名を指定する
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
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            P_DsPRT.Clear()
            strSQL = "SELECT T40_計上.加入番号, T40_計上.計上区分, V_M02_KJO.cls_code_name AS 計上区分名"
            strSQL += ", T40_計上.計上金額, T40_計上.預かり金, T40_計上.計上回数, T40_計上.登録日, T40_計上.計上確認"
            strSQL += ", T05_iPad.corp_flg, T01_member.user_name"
            strSQL += " FROM T40_計上 INNER JOIN"
            strSQL += " V_M02_KJO ON T40_計上.計上区分 = V_M02_KJO.cls_code INNER JOIN"
            strSQL += " T05_iPad ON T40_計上.加入番号 = T05_iPad.code INNER JOIN"
            strSQL += " T01_member ON T40_計上.加入番号 = T01_member.code"
            strSQL += " WHERE (T40_計上.計上月 = N'" & Mid(Date1.Number, 1, 6) & "')"
            strSQL += " AND (T01_member.delt_flg = 0)"
            strSQL += " ORDER BY T40_計上.加入番号, 計上区分名, T40_計上.計上回数"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(P_DsPRT, "csv")
            DB_CLOSE()

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "加入番号,加入者,計上月,計上部署,計上金額,預かり金,計上月数"
            swFile.WriteLine(strData)

            DtView1 = New DataView(P_DsPRT.Tables("csv"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                strData = DtView1(i)("加入番号")                        '加入番号
                strData = strData & "," & DtView1(i)("user_name")       '加入者
                strData = strData & "," & Mid(Date1.Number, 1, 6)       '計上月
                strData = strData & "," & DtView1(i)("計上区分名")      '計上部署
                strData = strData & "," & DtView1(i)("計上金額")        '計上金額
                strData = strData & "," & DtView1(i)("預かり金")        '預かり金
                strData = strData & "," & DtView1(i)("計上回数")        '計上月数
                'strData = strData & "," & DtView1(i)("corp_flg")        '法人
                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          'ファイルを閉じる
            MessageBox.Show("CSV出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 請求先CSV
    '******************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "請求先リスト" & Mid(Date1.Number, 1, 6) & ".CSV" 'はじめのファイル名を指定する
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
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            P_DsPRT.Clear()
            strSQL = "SELECT T01_member.code, T01_member.user_name, M04_shop.shop_name"
            strSQL += ", T01_member.makr_wrn_stat, T01_member.wrn_tem, T01_member.wrn_fee"
            strSQL += " FROM T01_member INNER JOIN"
            strSQL += " M04_shop ON T01_member.shop_code = M04_shop.shop_code INNER JOIN"
            strSQL += " T40_計上 ON T01_member.code = T40_計上.加入番号"
            strSQL += " WHERE (T40_計上.計上月 = N'" & Mid(Date1.Number, 1, 6) & "')"
            strSQL += " AND (T40_計上.計上区分 = 1)"
            strSQL += " AND (T01_member.delt_flg = 0)"
            strSQL += " GROUP BY T01_member.user_name, M04_shop.shop_name, T01_member.makr_wrn_stat"
            strSQL += ", T01_member.wrn_tem, T01_member.wrn_fee, T01_member.code"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DB_OPEN("nQGCare")
            DaList1.Fill(P_DsPRT, "csv")
            DB_CLOSE()

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            'データを書き込む
            strData = "加入番号,加入者,請求先,保証開始日,期間,保証料"
            swFile.WriteLine(strData)

            DtView1 = New DataView(P_DsPRT.Tables("csv"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                strData = DtView1(i)("code")                            '加入番号
                strData = strData & "," & DtView1(i)("user_name")       '加入者
                strData = strData & "," & DtView1(i)("shop_name")       '請求先
                strData = strData & "," & DtView1(i)("makr_wrn_stat")   '保証開始日
                strData = strData & "," & DtView1(i)("wrn_tem")         '期間
                strData = strData & "," & DtView1(i)("wrn_fee")         '保証料金
                strData = Replace(strData, System.Environment.NewLine, "")
                swFile.WriteLine(strData)

            Next
            swFile.Close()          'ファイルを閉じる
            MessageBox.Show("CSV出力しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '******************************************************************
    '** 閉じる
    '******************************************************************
    Private Sub Button99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button99.Click
        P_DsPRT.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
