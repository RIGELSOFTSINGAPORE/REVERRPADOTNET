Public Class F01_Form21
    Inherits System.Windows.Forms.Form

    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1, WK_DsList2 As New DataSet
    Dim DtView1, DtView2, DtView3 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, WK_str, strData, strFile As String
    Dim r, r2, r_sum, i, j, k, pos, WK_sum As Integer
    Dim snd_date As Date
    Dim WK_cls As String
    Dim WK_etmt_meas, WK_etmt_comn As String
    Dim WK_comp_meas, WK_comp_comn As String
    Dim kisyu(3) As String
    Dim WK_part_name, WK_part_F As String

    Dim WK_01, WK_02, WK_09, WK_15, WK_20, WK_21, WK_aka2 As Integer

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
    Friend WithEvents f12 As System.Windows.Forms.Button
    Friend WithEvents f01 As System.Windows.Forms.Button
    Friend WithEvents FunctionKey1 As GrapeCity.Win.Input.FunctionKey
    Friend WithEvents DataGridEx1 As nMVAR_TSS.DataGridEx
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F01_Form21))
        Me.Label1 = New System.Windows.Forms.Label
        Me.f12 = New System.Windows.Forms.Button
        Me.f01 = New System.Windows.Forms.Button
        Me.FunctionKey1 = New GrapeCity.Win.Input.FunctionKey
        Me.DataGridEx1 = New nMVAR_TSS.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(304, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 36)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "見積/完了情報出力"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f12
        '
        Me.f12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f12.Location = New System.Drawing.Point(896, 8)
        Me.f12.Name = "f12"
        Me.f12.Size = New System.Drawing.Size(96, 32)
        Me.f12.TabIndex = 1
        Me.f12.Text = "F12:閉じる"
        '
        'f01
        '
        Me.f01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.f01.Location = New System.Drawing.Point(784, 8)
        Me.f01.Name = "f01"
        Me.f01.Size = New System.Drawing.Size(96, 32)
        Me.f01.TabIndex = 0
        Me.f01.Text = "F1:CSV出力"
        '
        'FunctionKey1
        '
        Me.FunctionKey1.ActiveKeySet = "Default"
        Me.FunctionKey1.Location = New System.Drawing.Point(0, 688)
        Me.FunctionKey1.Name = "FunctionKey1"
        Me.FunctionKey1.Size = New System.Drawing.Size(1002, 0)
        Me.FunctionKey1.TabIndex = 19
        '
        'DataGridEx1
        '
        Me.DataGridEx1.CaptionVisible = False
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(8, 48)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.RowHeaderWidth = 10
        Me.DataGridEx1.Size = New System.Drawing.Size(988, 636)
        Me.DataGridEx1.TabIndex = 20
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGridEx1.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn21})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "TSS_snd"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "区分"
        Me.DataGridTextBoxColumn1.MappingName = "cls_name"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.Width = 70
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "得意先番号"
        Me.DataGridTextBoxColumn2.MappingName = "store_repr_no"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 95
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "受付番号"
        Me.DataGridTextBoxColumn3.MappingName = "rcpt_no"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 70
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "お客様名"
        Me.DataGridTextBoxColumn4.MappingName = "user_name"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "##,##0"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "見積技術料"
        Me.DataGridTextBoxColumn7.MappingName = "etmt_shop_tech_chrg"
        Me.DataGridTextBoxColumn7.NullText = ""
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "##,##0"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "見積部品代"
        Me.DataGridTextBoxColumn8.MappingName = "etmt_shop_part_chrg"
        Me.DataGridTextBoxColumn8.NullText = ""
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = "##,##0"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "見積その他"
        Me.DataGridTextBoxColumn9.MappingName = "etmt_shop_fee"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn10.Format = "##,##0"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "見積送料"
        Me.DataGridTextBoxColumn10.MappingName = "etmt_shop_pstg"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.Width = 60
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "見積日"
        Me.DataGridTextBoxColumn12.MappingName = "etmt_date"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "売上№"
        Me.DataGridTextBoxColumn13.MappingName = "sals_no"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.Width = 70
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn16.Format = "##,##0"
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "完成技術料"
        Me.DataGridTextBoxColumn16.MappingName = "comp_shop_tech_chrg"
        Me.DataGridTextBoxColumn16.NullText = ""
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn17.Format = "##,##0"
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "完成部品代"
        Me.DataGridTextBoxColumn17.MappingName = "comp_shop_part_chrg"
        Me.DataGridTextBoxColumn17.NullText = ""
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn18.Format = "##,##0"
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "完成その他"
        Me.DataGridTextBoxColumn18.MappingName = "comp_shop_fee"
        Me.DataGridTextBoxColumn18.NullText = ""
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn19.Format = "##,##0"
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "完成送料"
        Me.DataGridTextBoxColumn19.MappingName = "comp_shop_pstg"
        Me.DataGridTextBoxColumn19.NullText = ""
        Me.DataGridTextBoxColumn19.Width = 60
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "完成日"
        Me.DataGridTextBoxColumn21.MappingName = "comp_date"
        Me.DataGridTextBoxColumn21.NullText = ""
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(28, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 20)
        Me.CheckBox1.TabIndex = 21
        Me.CheckBox1.Text = "見積情報"
        '
        'CheckBox2
        '
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(28, 24)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(88, 20)
        Me.CheckBox2.TabIndex = 22
        Me.CheckBox2.Text = "完了情報"
        '
        'F01_Form21
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(1002, 688)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.FunctionKey1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.f12)
        Me.Controls.Add(Me.f01)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F01_Form21"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "見積/完了情報出力"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F01_Form21_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()   '**  初期処理
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
        sql()

        Dim tbl As New DataTable
        tbl = DsList1.Tables("TSS_snd")
        DataGridEx1.DataSource = tbl
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        sql()
    End Sub
    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        sql()
    End Sub

    Sub sql()
        Cursor = System.Windows.Forms.Cursors.WaitCursor

        DsList1.Clear()
        r_sum = 0
        DB_OPEN("nMVAR")

        If CheckBox1.Checked = True Then '見積
            strSQL = "SELECT CASE WHEN tss_etmt_stts = '1' THEN '見積新規' ELSE '見積更新' END AS cls_name, T01_REP_MTR.*"
            strSQL = strSQL & " FROM T01_REP_MTR"
            strSQL = strSQL & " WHERE (tss_etmt_stts = '1' OR tss_etmt_stts = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(DsList1, "TSS_snd")
            r_sum = r
        End If

        If CheckBox2.Checked = True Then '完了
            strSQL = "SELECT CASE WHEN tss_comp_stts = '1' THEN '完了新規' ELSE '完了更新' END AS cls_name, T01_REP_MTR.*"
            strSQL = strSQL & " FROM T01_REP_MTR"
            strSQL = strSQL & " WHERE (tss_comp_stts = '1' OR tss_comp_stts = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(DsList1, "TSS_snd")
            r_sum = r_sum + r

            strSQL = "SELECT CASE WHEN tss_aka_stts = '1' THEN '赤伝新規' ELSE '赤伝更新' END AS cls_name, T01_REP_MTR.*"
            strSQL = strSQL & " FROM T01_REP_MTR"
            strSQL = strSQL & " WHERE (tss_aka_stts = '1' OR tss_aka_stts = '2')"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            r = DaList1.Fill(DsList1, "TSS_snd")
            r_sum = r_sum + r
        End If
Tab1:
        DB_CLOSE()

        If r_sum = 0 Then
            f01.Enabled = False
        Else
            f01.Enabled = True
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  CSV出力ボタン
    '********************************************************************
    Private Sub f01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f01.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor


        Dim sfd As New SaveFileDialog                           'SaveFileDialogクラスのインスタンスを作成
        sfd.FileName = "見積完了data.CSV"                       'はじめのファイル名を指定する
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

            '進行状況ダイアログの初期化処理
            waitDlg = New WaitDialog            ' 進行状況ダイアログ
            waitDlg.Owner = Me                  ' ダイアログのオーナーを設定する
            waitDlg.MainMsg = Nothing           ' 処理の概要を表示
            waitDlg.ProgressMax = 0             ' 全体の処理件数を設定
            waitDlg.ProgressMin = 0             ' 処理件数の最小値を設定（0件から開始）
            waitDlg.ProgressStep = 1            ' 何件ごとにメータを進めるかを設定
            waitDlg.ProgressValue = 0           ' 最初の件数を設定
            Me.Enabled = False                  ' オーナーのフォームを無効にする
            waitDlg.Show()                      ' 進行状況ダイアログを表示する
            Application.DoEvents()              ' メッセージ処理を促して表示を更新する

            snd_date = Now
            DB_OPEN("nMVAR")

            DtView1 = New DataView(DsList1.Tables("TSS_snd"), "", "", DataViewRowState.CurrentRows)
            For i = 0 To DtView1.Count - 1

                '更新（送信済）
                strSQL = "UPDATE T01_REP_MTR"
                Select Case DtView1(i)("cls_name")
                    Case Is = "見積新規", "見積更新"
                        strSQL = strSQL & " SET tss_etmt_stts = '9'"
                    Case Is = "完了新規", "完了更新"
                        strSQL = strSQL & " SET tss_comp_stts = '9'"
                    Case Is = "赤伝新規", "赤伝更新"
                        strSQL = strSQL & " SET tss_aka_stts = '9'"
                End Select
                strSQL = strSQL & " WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                '区分コード
                Select Case DtView1(i)("cls_name")
                    Case Is = "見積新規"
                        WK_cls = "10"
                    Case Is = "見積更新"
                        WK_cls = "20"
                    Case Is = "完了新規", "赤伝新規"
                        WK_cls = "30"
                    Case Is = "完了更新", "赤伝更新"
                        WK_cls = "40"
                End Select

                'ヘッダー
                strSQL = "INSERT INTO TSS_ETMT_COMP"
                strSQL = strSQL & " (cls, rcd_cls, snd_date, cust_repr_no, rcpt_no, sals_no, comp_meas, comp_comn"
                strSQL = strSQL & ", tech_chrg, pstg, comp_chrg, comp_chrg_tax, comp_chrg_ttl, ajst_cls, ajst"
                strSQL = strSQL & ", max_tech_chrg, max_pstg, max_chrg, max_chrg_tax, max_chrg_ttl, etmt_cx_chrg, etmt_cx_chrg_tax"
                strSQL = strSQL & ", etmt_cx_chrg_ttl, user_cx_chrg, user_cx_chrg_tax, user_cx_chrg_ttl, etmt_cls, etmt_date"
                strSQL = strSQL & ", rep_yn, comp_date, sals_date, rb_cls)"
                strSQL = strSQL & " VALUES ('" & WK_cls & "'"                                       '01cls
                strSQL = strSQL & ", '10'"                                                          '02rcd_cls
                strSQL = strSQL & ", CONVERT(DATETIME, '" & snd_date & "', 102)"                    '03送信日
                strSQL = strSQL & ", '" & DtView1(i)("store_repr_no") & "'"                         '04カルテ番号
                strSQL = strSQL & ", '" & DtView1(i)("rcpt_no") & "'"                               '05受付番号

                Select Case DtView1(i)("cls_name")
                    Case Is = "見積新規", "見積更新"
                        strSQL = strSQL & ", NULL"                                                  '06伝票番号
                        WK_etmt_meas = Trim(DtView1(i)("etmt_meas"))
                        If WK_etmt_meas <> Nothing Then
                            WK_str = WK_etmt_meas.Replace(Chr(34), Chr(34) & Chr(34) & Chr(34)) '"を"""
                        Else
                            WK_str = Nothing
                        End If
                        strSQL = strSQL & ", '" & WK_str & "'"                                      '07対応内容
                        strSQL = strSQL & ", ''"                                                    '08確認事項
                        strSQL = strSQL & ", " & DtView1(i)("etmt_shop_tech_chrg")                  '09技術料（見積仕切）
                        strSQL = strSQL & ", " & DtView1(i)("etmt_shop_pstg")                       '11送料（見積仕切）

                        WK_sum = DtView1(i)("etmt_shop_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_apes")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_fee")
                        WK_sum = WK_sum + DtView1(i)("etmt_shop_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '15合計金額税抜き（見積仕切）
                        strSQL = strSQL & ", " & DtView1(i)("etmt_shop_tax")                        '16合計金額消費税（見積仕切）
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("etmt_shop_tax")               '17合計金額税込み（見積仕切）
                        strSQL = strSQL & ", '0'"                                                   '18値引き区分
                        strSQL = strSQL & ", 0"                                                     '19値引き
                        strSQL = strSQL & ", " & DtView1(i)("etmt_eu_tech_chrg")                    '20技術料（お客様請求）
                        strSQL = strSQL & ", " & DtView1(i)("etmt_eu_pstg")                         '21送料（お客様請求）

                        WK_sum = DtView1(i)("etmt_eu_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_apes")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_fee")
                        WK_sum = WK_sum + DtView1(i)("etmt_eu_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '23合計金額税抜き（お客様請求）
                        strSQL = strSQL & ", " & DtView1(i)("etmt_eu_tax")                          '24合計金額消費税（お客様請求）
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("etmt_eu_tax")                 '25合計金額税込み（お客様請求）

                    Case Is = "完了新規", "完了更新", "赤伝新規", "赤伝更新"
                        If Not IsDBNull(DtView1(i)("sals_no")) Then
                            strSQL = strSQL & ", " & DtView1(i)("sals_no")                          '06伝票番号
                        Else
                            strSQL = strSQL & ", NULL"
                        End If
                        WK_comp_meas = Trim(DtView1(i)("comp_meas"))
                        If WK_comp_meas <> Nothing Then
                            WK_str = WK_comp_meas.Replace(Chr(34), Chr(34) & Chr(34) & Chr(34)) '"を"""
                        Else
                            WK_str = Nothing
                        End If
                        strSQL = strSQL & ", '" & WK_str & "'"                                      '07対応内容
                        strSQL = strSQL & ", ''"                                                    '08確認事項
                        strSQL = strSQL & ", " & DtView1(i)("comp_shop_tech_chrg")                  '09技術料（完了仕切）
                        strSQL = strSQL & ", " & DtView1(i)("comp_shop_pstg")                       '11送料（完了仕切）

                        WK_sum = DtView1(i)("comp_shop_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_apes")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_fee")
                        WK_sum = WK_sum + DtView1(i)("comp_shop_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '15合計金額税抜き（完了仕切）
                        strSQL = strSQL & ", " & DtView1(i)("comp_shop_tax")                        '16合計金額消費税（完了仕切）
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("comp_shop_tax")               '17合計金額税込み（完了仕切）
                        strSQL = strSQL & ", '0'"                                                   '18値引き区分
                        strSQL = strSQL & ", 0"                                                     '19値引き
                        strSQL = strSQL & ", " & DtView1(i)("comp_eu_tech_chrg")                    '20技術料（お客様請求）
                        strSQL = strSQL & ", " & DtView1(i)("comp_eu_pstg")                         '21送料（お客様請求）

                        WK_sum = DtView1(i)("comp_eu_tech_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_apes")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_part_chrg")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_fee")
                        WK_sum = WK_sum + DtView1(i)("comp_eu_pstg")
                        strSQL = strSQL & ", " & WK_sum                                             '23合計金額税抜き（お客様請求）
                        strSQL = strSQL & ", " & DtView1(i)("comp_eu_tax")                          '24合計金額消費税（お客様請求）
                        strSQL = strSQL & ", " & WK_sum + DtView1(i)("comp_eu_tax")                 '25合計金額税込み（お客様請求）

                End Select

                strSQL = strSQL & ", 0"                                                             '26見積キャンセル料税抜き
                strSQL = strSQL & ", 0"                                                             '27見積キャンセル料消費税
                strSQL = strSQL & ", 0"                                                             '28見積キャンセル料税込み
                strSQL = strSQL & ", 0"                                                             '29見積キャンセル料税抜き（お客様請求）
                strSQL = strSQL & ", 0"                                                             '30見積キャンセル料消費税（お客様請求）
                strSQL = strSQL & ", 0"                                                             '31見積キャンセル料税抜き（お客様請求）

                If Not IsDBNull(DtView1(i)("etmt_date")) Then
                    strSQL = strSQL & ", 1"                                                         '32見積区分
                    strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("etmt_date") & "', 102)" '33見積作成日
                Else
                    strSQL = strSQL & ", NULL"
                    strSQL = strSQL & ", NULL"
                End If

                Select Case DtView1(i)("cls_name")
                    Case Is = "見積新規", "見積更新"
                        strSQL = strSQL & ", NULL"                                                  '39修理可否
                        strSQL = strSQL & ", NULL"                                                  '40完了日
                        strSQL = strSQL & ", NULL"                                                  '41出荷日
                        strSQL = strSQL & ", NULL)"                                                 '42赤黒

                    Case Is = "完了新規", "完了更新"
                        If IsDBNull(DtView1(i)("zh_code")) Then DtView1(i)("zh_code") = "Z"
                        Select Case DtView1(i)("zh_code")
                            Case Is = "H"
                                strSQL = strSQL & ", '02'"  '返却                                               '39修理可否
                            Case Else
                                strSQL = strSQL & ", '01'"  '続行
                        End Select
                        strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("comp_date") & "', 102)"         '40完了日

                        If Not IsDBNull(DtView1(i)("sals_date")) Then
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("sals_date") & "', 102)"     '41出荷日
                        Else
                            strSQL = strSQL & ", NULL"
                        End If
                        strSQL = strSQL & ", 1)"                                                                '42赤黒

                    Case Is = "赤伝新規", "赤伝更新"
                        If IsDBNull(DtView1(i)("zh_code")) Then DtView1(i)("zh_code") = "Z"
                        Select Case DtView1(i)("zh_code")
                            Case Is = "H"
                                strSQL = strSQL & ", '02'"  '返却                                               '39修理可否
                            Case Else
                                strSQL = strSQL & ", '01'"  '続行
                        End Select
                        strSQL = strSQL & ", NULL"                                                              '40完了日

                        If Not IsDBNull(DtView1(i)("sals_date")) Then
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & DtView1(i)("sals_date") & "', 102)"     '41出荷日
                        Else
                            strSQL = strSQL & ", NULL"
                        End If
                        strSQL = strSQL & ", 2)"                                                                '42赤黒
                End Select
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()

                '明細
                Select Case DtView1(i)("cls_name")
                    Case Is = "見積新規", "見積更新", "完了新規", "完了更新"

                        WK_part_name = Nothing

                            WK_DsList1.Clear()
                        strSQL = "SELECT * FROM T04_REP_PART"
                        strSQL = strSQL & " WHERE (rcpt_no = '" & DtView1(i)("rcpt_no") & "')"
                        Select Case DtView1(i)("cls_name")
                            Case Is = "見積新規", "見積更新"
                                strSQL = strSQL & " AND (kbn = '1')"
                            Case Is = "完了新規", "完了更新"
                                strSQL = strSQL & " AND (kbn = '2')"
                        End Select
                        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                        DaList1.SelectCommand = SqlCmd1
                        r = DaList1.Fill(WK_DsList1, "T04_REP_PART")

                        If r <> 0 Then
                            DtView2 = New DataView(WK_DsList1.Tables("T04_REP_PART"), "", "", DataViewRowState.CurrentRows)

                            For j = 0 To DtView2.Count - 1
                                If j = 0 Then
                                    WK_part_name = Trim(DtView2(j)("part_name"))
                                Else
                                    WK_part_name = WK_part_name & " " & Trim(DtView2(j)("part_name"))
                                End If
                            Next j
                            strSQL = "INSERT INTO TSS_ETMT_COMP"
                            strSQL = strSQL & " (cls, rcd_cls, snd_date, cust_repr_no"
                            strSQL = strSQL & ", dtl_no, part_no, part_name, part_chrg, user_part_chrg)"
                            strSQL = strSQL & " VALUES ('" & WK_cls & "'"                                       '01cls
                            strSQL = strSQL & ", '20'"                                                          '02rcd_cls
                            strSQL = strSQL & ", CONVERT(DATETIME, '" & snd_date & "', 102)"                    '03送信日
                            strSQL = strSQL & ", '" & DtView1(i)("store_repr_no") & "'"                         '04カルテ番号
                            strSQL = strSQL & ", 1"                                                             '明細No
                            strSQL = strSQL & ", NULL"                                                          'ﾊﾟｰﾂ番号

                            WK_str = WK_part_name
                            If WK_str <> Nothing Then WK_str = WK_str.Replace(Chr(34), Chr(34) & Chr(34) & Chr(34)) '"を"""
                            strSQL = strSQL & ", '" & WK_str & "'"                                              'ﾊﾟｰﾂ名
                            Select Case DtView1(i)("cls_name")
                                Case Is = "見積新規", "見積更新"
                                    strSQL = strSQL & ", " & DtView1(i)("etmt_shop_part_chrg")                  'ﾊﾟｰﾂ金額税別
                                    strSQL = strSQL & ", " & DtView1(i)("etmt_eu_part_chrg") & ")"              'ﾊﾟｰﾂお客様請求税別
                                Case Is = "完了新規", "完了更新"
                                    strSQL = strSQL & ", " & DtView1(i)("comp_shop_part_chrg") & ""
                                    strSQL = strSQL & ", " & DtView1(i)("comp_eu_part_chrg") & ")"
                            End Select

                            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                            SqlCmd1.CommandTimeout = 600
                            SqlCmd1.ExecuteNonQuery()
                        End If
                End Select
            Next i

            '********************************************************************
            '**  CSV出力
            '********************************************************************
            WK_DsList1.Clear()
            strSQL = "SELECT * FROM TSS_ETMT_COMP"
            strSQL = strSQL & " WHERE (snd_date = CONVERT(DATETIME, '" & snd_date & "', 102))"
            strSQL = strSQL & " ORDER BY id"
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            DaList1.Fill(WK_DsList1, "TSS_ETMT_COMP")

            strFile = sfd.FileName   'OKボタンがクリックされたとき

            Dim swFile As New System.IO.StreamWriter(strFile, False, System.Text.Encoding.Default)
            swFile.BaseStream.Seek(0, System.IO.SeekOrigin.End)     'ファイルの末尾に移動する

            DtView1 = New DataView(WK_DsList1.Tables("TSS_ETMT_COMP"), "", "", DataViewRowState.CurrentRows)

            waitDlg.MainMsg = "CSV出力中"       ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMsg = ""            ' 進行状況ダイアログのメーターを設定
            waitDlg.ProgressMax = DtView1.Count ' 全体の処理件数を設定
            waitDlg.ProgressValue = 0           ' 最初の件数を設定
            Application.DoEvents()              ' メッセージ処理を促して表示を更新する

            'strData = "区分,レコード区分,データ送信日,カルテ番号,修理管理番号,E伝番号,対応内容,確認事項,技術料,技術料_負担区分"
            'strData = strData & ",配送料,配送料_負担区分,その他,その他_負担区分,合計金額_税別,消費税,合計金額_税込,値引区分"
            'strData = strData & ",値引額,お客様請求_技術料_税別,お客様請求_配送料,お客様請求_その他,お客様請求　合計金額_税別"
            'strData = strData & ",お客様請求　消費税,お客様請求　合計金額_税込,見積キャンセル料,見積キャンセル料_消費税"
            'strData = strData & ",見積キャンセル料_税込,お客様請求　見積キャンセル料,お客様請求_見積キャンセル料_消費税"
            'strData = strData & ",お客様請求　見積キャンセル料_税込,見積区分,見積作成日,見積連絡日,見積回答日,見積回答連絡日"
            'strData = strData & ",見積回答コード,見積回答日,修理可否コード,修理完了日,出荷日,赤黒区分,修理完了予定日"
            'strData = strData & ",納品予定日,明細No,パーツ番号,パーツ名,パーツ金額_税別,パーツ_負担区分,お客様請求_税別"
            'swFile.WriteLine(strData)

            For i = 0 To DtView1.Count - 1

                waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　（" & Format(i + 1, "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 行）"
                waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%"
                Application.DoEvents()  ' メッセージ処理を促して表示を更新する
                waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

                strData = Chr(34) & DtView1(i)("cls") & Chr(34)                                                 '区分
                strData = strData & "," & Chr(34) & DtView1(i)("rcd_cls") & Chr(34)                             'レコード区分
                strData = strData & "," & Chr(34) & Format(DtView1(i)("snd_date"), "yyyyMMdd") & Chr(34)        'データ送信日
                strData = strData & "," & Chr(34) & DtView1(i)("cust_repr_no") & Chr(34)                        'カルテ番号
                If Not IsDBNull(DtView1(i)("rcpt_no")) Then
                    strData = strData & "," & Chr(34) & Trim(DtView1(i)("rcpt_no")) & Chr(34)                   '修理管理番号
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & DtView1(i)("sals_no") & Chr(34)                             'Ｅ伝番号
                If Not IsDBNull(DtView1(i)("comp_meas")) Then
                    strData = strData & "," & Chr(34) & DtView1(i)("comp_meas") & Chr(34)                       '対応内容
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("comp_comn")) Then
                    strData = strData & "," & Chr(34) & DtView1(i)("comp_comn") & Chr(34)                       '確認事項
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & DtView1(i)("tech_chrg") & Chr(34)                           '技術料
                strData = strData & "," & Chr(34) & Chr(34)                                                     '技術料負担区分
                strData = strData & "," & Chr(34) & DtView1(i)("pstg") & Chr(34)                                '配送料
                strData = strData & "," & Chr(34) & Chr(34)                                                     '配送料負担区分
                strData = strData & "," & Chr(34) & Chr(34)                                                     'その他
                strData = strData & "," & Chr(34) & Chr(34)                                                     'その他負担区分
                strData = strData & "," & Chr(34) & DtView1(i)("comp_chrg") & Chr(34)                           '合計金額税別
                strData = strData & "," & Chr(34) & DtView1(i)("comp_chrg_tax") & Chr(34)                       '消費税
                strData = strData & "," & Chr(34) & DtView1(i)("comp_chrg_ttl") & Chr(34)                       '合計金額税込
                strData = strData & "," & Chr(34) & DtView1(i)("ajst_cls") & Chr(34)                            '割引区分
                strData = strData & "," & Chr(34) & DtView1(i)("ajst") & Chr(34)                                '割引額
                strData = strData & "," & Chr(34) & DtView1(i)("max_tech_chrg") & Chr(34)                       'お客様請求技術料税別
                strData = strData & "," & Chr(34) & DtView1(i)("max_pstg") & Chr(34)                            'お客様請求配送料
                strData = strData & "," & Chr(34) & Chr(34)                                                     'お客様請求その他
                strData = strData & "," & Chr(34) & DtView1(i)("max_chrg") & Chr(34)                            'お客様請求合計金額税別
                strData = strData & "," & Chr(34) & DtView1(i)("max_chrg_tax") & Chr(34)                        'お客様請求消費税
                strData = strData & "," & Chr(34) & DtView1(i)("max_chrg_ttl") & Chr(34)                        'お客様請求合計金額税込
                strData = strData & "," & Chr(34) & DtView1(i)("etmt_cx_chrg") & Chr(34)                        '見積キャンセル料
                strData = strData & "," & Chr(34) & DtView1(i)("etmt_cx_chrg_tax") & Chr(34)                    '見積キャンセル料消費税
                strData = strData & "," & Chr(34) & DtView1(i)("etmt_cx_chrg_ttl") & Chr(34)                    '見積キャンセル料税込
                strData = strData & "," & Chr(34) & DtView1(i)("user_cx_chrg") & Chr(34)                        'お客様請求見積キャンセル料
                strData = strData & "," & Chr(34) & DtView1(i)("user_cx_chrg_tax") & Chr(34)                    'お客様請求見積キャンセル料消費税
                strData = strData & "," & Chr(34) & DtView1(i)("user_cx_chrg_ttl") & Chr(34)                    'お客様請求見積キャンセル料税込
                If Not IsDBNull(DtView1(i)("etmt_date")) Then
                    strData = strData & "," & Chr(34) & DtView1(i)("etmt_cls") & Chr(34)                        '見積区分
                    strData = strData & "," & Chr(34) & Format(DtView1(i)("etmt_date"), "yyyyMMdd") & Chr(34)   '見積作成日
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & Chr(34)                                                     '見積連絡日
                strData = strData & "," & Chr(34) & Chr(34)                                                     '見積回答日
                strData = strData & "," & Chr(34) & Chr(34)                                                     '見積回答連絡日
                strData = strData & "," & Chr(34) & Chr(34)                                                     '見積回答コード
                strData = strData & "," & Chr(34) & Chr(34)                                                     '見積回答日
                strData = strData & "," & Chr(34) & DtView1(i)("rep_yn") & Chr(34)                              '修理可否コード
                If Not IsDBNull(DtView1(i)("comp_date")) Then
                    strData = strData & "," & Chr(34) & Format(DtView1(i)("comp_date"), "yyyyMMdd") & Chr(34)   '修理完了日
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                If Not IsDBNull(DtView1(i)("sals_date")) Then
                    strData = strData & "," & Chr(34) & Format(DtView1(i)("sals_date"), "yyyyMMdd") & Chr(34)   '出荷日
                Else
                    strData = strData & "," & Chr(34) & Chr(34)
                End If
                strData = strData & "," & Chr(34) & DtView1(i)("rb_cls") & Chr(34)                              '赤黒区分
                strData = strData & "," & Chr(34) & Chr(34)                                                     '修理完了予定日
                strData = strData & "," & Chr(34) & Chr(34)                                                     '納品予定日

                strData = strData & "," & Chr(34) & DtView1(i)("dtl_no") & Chr(34)                              '明細行
                strData = strData & "," & Chr(34) & Chr(34)                                                     'パーツ番号
                strData = strData & "," & Chr(34) & DtView1(i)("part_name") & Chr(34)                           'パーツ名
                strData = strData & "," & Chr(34) & DtView1(i)("part_chrg") & Chr(34)                           'パーツ金額税別
                strData = strData & "," & Chr(34) & Chr(34)                                                     'パーツ負担区分
                strData = strData & "," & Chr(34) & DtView1(i)("user_part_chrg") & Chr(34)                      'お客様請求税別
                strData = strData.Replace(System.Environment.NewLine, " ")    '改行を" "
                'strData = strData.Replace(System.Environment.NewLine, " / ")    '改行を/
                swFile.WriteLine(strData)
            Next

            swFile.Close()          'ファイルを閉じる
            DB_CLOSE()
            MessageBox.Show("出力しました。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            waitDlg.Close()         '進行状況ダイアログを閉じる
            Me.Enabled = True       'オーナーのフォームを無効にする
            sql()
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  閉じる・終了ボタン
    '********************************************************************
    Private Sub f12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f12.Click
        DsList1.Clear()
        WK_DsList1.Clear()
        WK_DsList2.Clear()
        Me.Close()
    End Sub

    '********************************************************************
    '**  ファンクションキー
    '********************************************************************
    Private Sub functionKey1_FunctionKeyPress(ByVal sender As System.Object, ByVal e As GrapeCity.Win.Input.FunctionKeyPressEventArgs) Handles FunctionKey1.FunctionKeyPress

        e.Handled = True        'ファンクションキーに割り付けられた設定を無効にします。
        Select Case e.KeyIndex  'ファンクションキーが押下された場合の処理を行います。
            Case 0  'F1
                If f01.Enabled = True Then f01.Focus() : f01_Click(sender, e)
            Case 1  'F2
            Case 2  'F3
            Case 3  'F4
            Case 4  'F5
            Case 5  'F6
            Case 6  'F7
            Case 7  'F8
            Case 8  'F9
            Case 9  'F10
            Case 10 'F11
            Case 11 'F12
                f12_Click(sender, e)
        End Select
    End Sub

    '********************************************************************
    '**  GotFocus 
    '********************************************************************
    Private Sub CheckBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.GotFocus
        CheckBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub CheckBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.GotFocus
        CheckBox2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.GotFocus
        f01.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub
    Private Sub f12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.GotFocus
        f12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub CheckBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.LostFocus
        CheckBox1.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub CheckBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.LostFocus
        CheckBox2.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f01.LostFocus
        f01.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub f12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles f12.LostFocus
        f12.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
