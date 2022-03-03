Public Class F50_Form18_3
    Inherits System.Windows.Forms.Form
    Dim waitDlg As WaitDialog   ''進行状況フォームクラス  

    Public Declare Function GetSystemMenu Lib "user32.dll" Alias "GetSystemMenu" (ByVal hwnd As IntPtr, ByVal bRevert As Long) As IntPtr
    Public Declare Function RemoveMenu Lib "user32.dll" Alias "RemoveMenu" (ByVal hMenu As IntPtr, ByVal nPosition As Long, ByVal wFlags As Long) As Long
    Public Const SC_CLOSE As Long = &HF060
    Public Const MF_BYCOMMAND As Long = &H0

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DsGRD As New DataSet
    Dim DtView1 As DataView
    Dim dttable As DataTable
    Dim dtRow As DataRow

    Dim strSQL, filename As String
    Dim i, j, k, prc_cnt As Integer

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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridEx1 As nMVAR.DataGridEx
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(F50_Form18_3))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.DataGridEx1 = New nMVAR.DataGridEx
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.msg = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button98 = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridEx1
        '
        Me.DataGridEx1.DataMember = ""
        Me.DataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridEx1.Location = New System.Drawing.Point(14, 160)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.ReadOnly = True
        Me.DataGridEx1.Size = New System.Drawing.Size(566, 448)
        Me.DataGridEx1.TabIndex = 1285
        Me.DataGridEx1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGridEx1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "M15_ZIP"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "郵便番号"
        Me.DataGridTextBoxColumn2.MappingName = "zip"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 80
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "都道府県"
        Me.DataGridTextBoxColumn4.MappingName = "ken_code"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "住所"
        Me.DataGridTextBoxColumn5.MappingName = "adrs"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 330
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(114, 643)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 32)
        Me.Button4.TabIndex = 1282
        Me.Button4.Text = "クリア"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 97)
        Me.GroupBox1.TabIndex = 1280
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "データ取込"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(28, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "取込み開始"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(24, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(472, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(496, 32)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(48, 24)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "参照"
        '
        'msg
        '
        Me.msg.ForeColor = System.Drawing.Color.Red
        Me.msg.Location = New System.Drawing.Point(16, 616)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(562, 24)
        Me.msg.TabIndex = 1284
        Me.msg.Text = "msg"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(14, 643)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 32)
        Me.Button1.TabIndex = 1281
        Me.Button1.Text = "更新"
        '
        'Button98
        '
        Me.Button98.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button98.Location = New System.Drawing.Point(508, 644)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(68, 32)
        Me.Button98.TabIndex = 1283
        Me.Button98.Text = "戻る"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.Location = New System.Drawing.Point(124, 24)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(456, 16)
        Me.LinkLabel1.TabIndex = 1286
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://www.post.japanpost.jp/zipcode/dl/kogaki/lzh/ken_all.lzh"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Navy
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 24)
        Me.Label6.TabIndex = 1307
        Me.Label6.Text = "データダウンロード"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'F50_Form18_3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(598, 686)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Controls.Add(Me.DataGridEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "F50_Form18_3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "郵便番号データ取込"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    '**  起動時
    '********************************************************************
    Private Sub F50_Form18_3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inz()       '**  初期処理
        ACES()      '**  権限チェック
        inz_dsp()   '**  初期画面
    End Sub

    '********************************************************************
    '**  初期処理
    '********************************************************************
    Sub inz()
        '×閉じるを使用不可
        Dim lngH As IntPtr
        lngH = GetSystemMenu(Handle, 0)
        RemoveMenu(lngH, SC_CLOSE, MF_BYCOMMAND)

        P_RTN = "0"
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

        DtView1 = New DataView(DsList1.Tables("ACES_CHK"), "exe_code ='518'", "", DataViewRowState.CurrentRows)
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
    '**  初期画面
    '********************************************************************
    Sub inz_dsp()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False

        DsGRD.Clear()
        strSQL = "SELECT * FROM M15_ZIP WHERE (id = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN("nMVAR")
        DaList1.Fill(DsGRD, "M15_ZIP_clr")
        DB_CLOSE()

        'Dim tbl As New DataTable
        'tbl = DsGRD.Tables("M15_ZIP")
        'DataGridEx1.DataSource = tbl
    End Sub

    '********************************************************************
    '**  web
    '********************************************************************
    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.post.japanpost.jp/zipcode/dl/kogaki/lzh/ken_all.lzh")
    End Sub

    '********************************************************************
    '**  参照
    '********************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        msg.Text = Nothing

        With OpenFileDialog1
            .CheckFileExists = True     'ファイルが存在するか確認
            .RestoreDirectory = True    'ディレクトリの復元
            .ReadOnlyChecked = True
            .ShowReadOnly = True
            .Filter = "CSV ﾌｧｲﾙ(*.xls)|*.CSV"
            .FilterIndex = 1            'Filterプロパティの2つ目を表示
            'ダイアログボックスを表示し、［開く]をクリックした場合
            If .ShowDialog = DialogResult.OK Then
                TextBox1.Text = .FileName
            End If
        End With
    End Sub

    '********************************************************************
    '**  取込み開始
    '********************************************************************
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error GoTo err_prc
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing

        If Trim(TextBox1.Text) = Nothing Then
            msg.Text = "取込ファイルを指定してください。"
        Else
            If System.IO.File.Exists(TextBox1.Text) = False Then
                msg.Text = TextBox1.Text & " は存在しません。"
            Else
                DB_OPEN("nMVAR")
                Button1.Enabled = False
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button98.Enabled = False

                DsGRD.Clear()
                strSQL = "SELECT * FROM M15_ZIP WHERE (id = 0)"
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                DaList1.SelectCommand = SqlCmd1
                DaList1.Fill(DsGRD, "M15_ZIP")

                filename = TextBox1.Text
                Dim srFile As New System.IO.StreamReader(filename, System.Text.Encoding.Default)
                Dim strLine As String = srFile.ReadLine()

                Dim WK_str, str(5) As String

                While Not strLine Is Nothing
                    If RTrim(strLine) = Nothing Then GoTo p1

                    WK_str = strLine
                    str(1) = Mid(WK_str, 1, 2) '都道府県CD
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(2) = Mid(WK_str, 2, 7) '郵便番号
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(3) = Mid(WK_str, 2, WK_str.IndexOf(",") - 2) '住所1
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(4) = Mid(WK_str, 2, WK_str.IndexOf(",") - 2) '住所2
                    WK_str = WK_str.Substring(WK_str.IndexOf(",") + 1)
                    str(5) = Mid(WK_str, 2, WK_str.IndexOf(",") - 2) '住所3

                    dttable = DsGRD.Tables("M15_ZIP")
                    dtRow = dttable.NewRow
                    dtRow("zip") = str(2)
                    dtRow("ken_code") = str(1)
                    dtRow("adrs") = str(3) & str(4) & str(5)
                    dttable.Rows.Add(dtRow)
p1:
                    strLine = srFile.ReadLine()
                End While

                srFile.Close()  'ファイルを閉じる 

                Dim tbl As New DataTable
                tbl = DsGRD.Tables("M15_ZIP")
                DataGridEx1.DataSource = tbl

                DB_CLOSE()
                msg.Text = "取込完了！"
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = True
                Button98.Enabled = True
            End If
        End If

        Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub

err_prc:
        If Err.Number = 5 Then
            msg.Text = "ファイルの内容（項目または並び順等）が違っています。"
        Else
            msg.Text = Err.Number & ":" & Err.Description
        End If
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button98.Enabled = True
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  GotFocus
    '********************************************************************
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    End Sub

    '********************************************************************
    '**  LostFocus
    '********************************************************************
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.BackColor = System.Drawing.SystemColors.Window
    End Sub

    '********************************************************************
    '**  更新
    '********************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        msg.Text = Nothing
        Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
        Button98.Enabled = False

        ' 進行状況ダイアログの初期化処理
        waitDlg = New WaitDialog        ' 進行状況ダイアログ
        waitDlg.Owner = Me              ' ダイアログのオーナーを設定する
        waitDlg.MainMsg = Nothing       ' 処理の概要を表示
        waitDlg.ProgressMax = 0         ' 全体の処理件数を設定
        waitDlg.ProgressMin = 0         ' 処理件数の最小値を設定（0件から開始）
        waitDlg.ProgressStep = 1        ' 何件ごとにメータを進めるかを設定
        waitDlg.ProgressValue = 0       ' 最初の件数を設定
        waitDlg.MainMsg = "郵便番号ﾃﾞｰﾀ更新準備中"      ' 進行状況ダイアログのメーターを設定
        waitDlg.Show()                  ' 進行状況ダイアログを表示する

        DB_OPEN("nMVAR")

        '手入力データ作成
        strSQL = "SELECT * FROM M15_ZIP WHERE (reg_date IS NOT NULL) AND (delt_flg = 0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DaList1.Fill(DsGRD, "M15_ZIP")

        '既存データ削除
        strSQL = "DELETE FROM M15_ZIP"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        'オートナンバーリセット
        strSQL = "DBCC CHECKIDENT (M15_ZIP ,RESEED ,0)"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        SqlCmd1.ExecuteNonQuery()

        DtView1 = New DataView(DsGRD.Tables("M15_ZIP"), "", "ken_code, zip", DataViewRowState.CurrentRows)

        waitDlg.MainMsg = "郵便番号ﾃﾞｰﾀ更新中"          ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMsg = ""                    ' 進行状況ダイアログのメーターを設定
        waitDlg.ProgressMax = DtView1.Count         ' 全体の処理件数を設定
        waitDlg.ProgressValue = 0                   ' 最初の件数を設定
        Application.DoEvents()                      ' メッセージ処理を促して表示を更新する

        'データ追加
        For i = 0 To DtView1.Count - 1
            waitDlg.ProgressMsg = Fix((i + 1) * 100 / DtView1.Count) & "%　" & "（" & Format((i + 1), "##,##0") & " / " & Format(DtView1.Count, "##,##0") & " 件）"
            waitDlg.Text = "実行中・・・" & Fix((i + 1) * 100 / DtView1.Count) & "%　"
            Application.DoEvents()  ' メッセージ処理を促して表示を更新する
            waitDlg.PerformStep()   ' 処理カウントを1ステップ進める

            strSQL = "INSERT INTO M15_ZIP (zip, ken_code, adrs, reg_date, delt_flg)"
            strSQL +=  " SELECT '" & DtView1(i)("zip") & "' AS zip"
            strSQL +=  ", '" & DtView1(i)("ken_code") & "' AS ken_code"
            strSQL +=  ", '" & MidB(DtView1(i)("adrs"), 1, 100) & "' AS adrs"
            If Not IsDBNull(DtView1(i)("reg_date")) Then
                strSQL +=  ", '" & DtView1(i)("reg_date") & "' AS reg_date"
            Else
                strSQL +=  ", NULL"
            End If
            strSQL +=  ", 0"

            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            SqlCmd1.ExecuteNonQuery()
        Next
        DB_CLOSE()
        waitDlg.Close()                 ' 進行状況ダイアログを閉じる
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button98.Enabled = True
        msg.Text = "更新しました。"
        P_RTN = "1"
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '********************************************************************
    '**  クリア
    '********************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        msg.Text = Nothing
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        DsGRD.Tables("M15_ZIP").Clear()

        Dim tbl As New DataTable
        tbl = DsGRD.Tables("M15_ZIP_clr")
        DataGridEx1.DataSource = tbl
    End Sub

    '********************************************************************
    '**  戻る
    '********************************************************************
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        DsGRD.Clear()
        DsList1.Clear()
        Close()
    End Sub
End Class
